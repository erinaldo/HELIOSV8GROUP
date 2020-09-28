<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajaTicket
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCajaTicket))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PopupControlContainer2 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvProveedor = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtCajaOrigen = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerieVenta = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.dropDownBtn = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtNumeroVenta = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtTasaIgv = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtComprobante = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtIgvme = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtMoneda = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtImporteME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtPeriodo = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtImporteMn = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtComprador = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtIgv = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.pnDatos = New System.Windows.Forms.Panel()
        Me.lblAnticipoME = New System.Windows.Forms.Label()
        Me.lblAnticipoMN = New System.Windows.Forms.Label()
        Me.txtAnticipoMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtAnticipoME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.rbSinAnticipo = New System.Windows.Forms.RadioButton()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.rbConAnticipo = New System.Windows.Forms.RadioButton()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtTipoCambioVenta = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.lblVueltoME = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtVueltoME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.lblVueltoMN = New System.Windows.Forms.Label()
        Me.txtVueltoMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.lblReciboME = New System.Windows.Forms.Label()
        Me.txtCobroMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.lblReciboMN = New System.Windows.Forms.Label()
        Me.txtIngresoMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtCobroME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtIngresoME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.pnVentas = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFechaCobro = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.rbFactura = New System.Windows.Forms.RadioButton()
        Me.popupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.cancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.OK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.lsvCliente = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTipoDocVenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerVenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.rbBoleta = New System.Windows.Forms.RadioButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtnroVenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCuenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCliente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gpVSBehavior = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtSeriePedido = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumeroPedido = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintTikect = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialogTicket = New System.Windows.Forms.PrintPreviewDialog()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.DockingClientPanel1 = New Syncfusion.Windows.Forms.Tools.DockingClientPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.pcProveedor = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.btnCarnetEx = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.btnDni = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.btnPassport = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.btnRuc = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtDocProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtApePat = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtNomProv = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbJuridico = New Syncfusion.Windows.Forms.Tools.RadioButtonAdv()
        Me.rbNatural = New Syncfusion.Windows.Forms.Tools.RadioButtonAdv()
        Me.btnCancelarProv = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnGRabarProv = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.pnImpresionTicket = New System.Windows.Forms.Panel()
        Me.txtFechaN = New System.Windows.Forms.DateTimePicker()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtVendedorN = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtCajaN = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtCodMaqN = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCompradorN = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lsvDetalle = New System.Windows.Forms.ListView()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.DigitalGauge2 = New Syncfusion.Windows.Forms.Gauge.DigitalGauge()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.chCliente = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.btnConfigCaja = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnConfiguracion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblIdDoc = New System.Windows.Forms.ToolStripLabel()
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.Panel4.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PopupControlContainer2.SuspendLayout()
        CType(Me.txtCajaOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTasaIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIgvme, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteMn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDatos.SuspendLayout()
        CType(Me.txtAnticipoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAnticipoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambioVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        CType(Me.txtVueltoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVueltoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCobroMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIngresoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCobroME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIngresoME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnVentas.SuspendLayout()
        CType(Me.txtFechaCobro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaCobro.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupControlContainer1.SuspendLayout()
        CType(Me.txtTipoDocVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnroVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpVSBehavior.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSeriePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockingClientPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pcProveedor.SuspendLayout()
        Me.Panel14.SuspendLayout()
        CType(Me.txtDocProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApePat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.rbJuridico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbNatural, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnImpresionTicket.SuspendLayout()
        CType(Me.txtVendedorN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCajaN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodMaqN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompradorN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.chCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GradientPanel1)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.gpVSBehavior)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(367, 680)
        Me.Panel4.TabIndex = 408
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Transparent
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.Panel3)
        Me.GradientPanel1.Controls.Add(Me.pnDatos)
        Me.GradientPanel1.Controls.Add(Me.pnVentas)
        Me.GradientPanel1.Controls.Add(Me.Panel2)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 86)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(367, 594)
        Me.GradientPanel1.TabIndex = 403
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.PopupControlContainer2)
        Me.Panel3.Controls.Add(Me.Label40)
        Me.Panel3.Controls.Add(Me.txtCajaOrigen)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtSerieVenta)
        Me.Panel3.Controls.Add(Me.dropDownBtn)
        Me.Panel3.Controls.Add(Me.txtNumeroVenta)
        Me.Panel3.Controls.Add(Me.txtTasaIgv)
        Me.Panel3.Controls.Add(Me.txtFechaComprobante)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.txtComprobante)
        Me.Panel3.Controls.Add(Me.txtIgvme)
        Me.Panel3.Controls.Add(Me.txtMoneda)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtImporteME)
        Me.Panel3.Controls.Add(Me.txtPeriodo)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtImporteMn)
        Me.Panel3.Controls.Add(Me.txtComprador)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.txtIgv)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtTipoCambio)
        Me.Panel3.Enabled = False
        Me.Panel3.Location = New System.Drawing.Point(0, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(366, 176)
        Me.Panel3.TabIndex = 439
        '
        'PopupControlContainer2
        '
        Me.PopupControlContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PopupControlContainer2.Controls.Add(Me.lsvProveedor)
        Me.PopupControlContainer2.Location = New System.Drawing.Point(132, 175)
        Me.PopupControlContainer2.Name = "PopupControlContainer2"
        Me.PopupControlContainer2.Size = New System.Drawing.Size(218, 75)
        Me.PopupControlContainer2.TabIndex = 495
        Me.PopupControlContainer2.Visible = False
        '
        'lsvProveedor
        '
        Me.lsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProveedor.FullRowSelect = True
        Me.lsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.lsvProveedor.MultiSelect = False
        Me.lsvProveedor.Name = "lsvProveedor"
        Me.lsvProveedor.Size = New System.Drawing.Size(216, 73)
        Me.lsvProveedor.TabIndex = 3
        Me.lsvProveedor.UseCompatibleStateImageBehavior = False
        Me.lsvProveedor.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "IdProveedor"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Proveedor"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Cuenta"
        Me.ColumnHeader7.Width = 200
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Numero"
        Me.ColumnHeader8.Width = 0
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(82, 156)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(35, 13)
        Me.Label40.TabIndex = 421
        Me.Label40.Text = "Caja:"
        '
        'txtCajaOrigen
        '
        Me.txtCajaOrigen.BackColor = System.Drawing.Color.White
        Me.txtCajaOrigen.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtCajaOrigen.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtCajaOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCajaOrigen.CornerRadius = 5
        Me.txtCajaOrigen.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCajaOrigen.FarImage = CType(resources.GetObject("txtCajaOrigen.FarImage"), System.Drawing.Image)
        Me.txtCajaOrigen.FocusBorderColor = System.Drawing.Color.Yellow
        Me.txtCajaOrigen.Location = New System.Drawing.Point(132, 150)
        Me.txtCajaOrigen.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtCajaOrigen.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCajaOrigen.Name = "txtCajaOrigen"
        Me.txtCajaOrigen.ReadOnly = True
        Me.txtCajaOrigen.Size = New System.Drawing.Size(197, 20)
        Me.txtCajaOrigen.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCajaOrigen.TabIndex = 422
        Me.txtCajaOrigen.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(42, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 199
        Me.Label6.Text = "Fecha pedido:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(42, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 200
        Me.Label1.Text = "Comprobante:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(43, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Serie/número:"
        '
        'txtSerieVenta
        '
        Me.txtSerieVenta.Location = New System.Drawing.Point(132, 52)
        Me.txtSerieVenta.MaxLength = 5
        Me.txtSerieVenta.Name = "txtSerieVenta"
        Me.txtSerieVenta.ReadOnly = True
        Me.txtSerieVenta.Size = New System.Drawing.Size(69, 19)
        Me.txtSerieVenta.TabIndex = 205
        Me.txtSerieVenta.TabStop = False
        '
        'dropDownBtn
        '
        Me.dropDownBtn.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dropDownBtn.BackColor = System.Drawing.SystemColors.Highlight
        Me.dropDownBtn.BeforeTouchSize = New System.Drawing.Size(16, 19)
        Me.dropDownBtn.ForeColor = System.Drawing.Color.White
        Me.dropDownBtn.Image = CType(resources.GetObject("dropDownBtn.Image"), System.Drawing.Image)
        Me.dropDownBtn.IsBackStageButton = False
        Me.dropDownBtn.Location = New System.Drawing.Point(334, 150)
        Me.dropDownBtn.Name = "dropDownBtn"
        Me.dropDownBtn.Size = New System.Drawing.Size(16, 19)
        Me.dropDownBtn.TabIndex = 207
        Me.dropDownBtn.UseVisualStyle = True
        '
        'txtNumeroVenta
        '
        Me.txtNumeroVenta.Location = New System.Drawing.Point(203, 52)
        Me.txtNumeroVenta.MaxLength = 20
        Me.txtNumeroVenta.Name = "txtNumeroVenta"
        Me.txtNumeroVenta.ReadOnly = True
        Me.txtNumeroVenta.Size = New System.Drawing.Size(147, 19)
        Me.txtNumeroVenta.TabIndex = 206
        Me.txtNumeroVenta.TabStop = False
        '
        'txtTasaIgv
        '
        Me.txtTasaIgv.BackColor = System.Drawing.Color.White
        Me.txtTasaIgv.BeforeTouchSize = New System.Drawing.Size(92, 20)
        Me.txtTasaIgv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTasaIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTasaIgv.DecimalPlaces = 2
        Me.txtTasaIgv.InterceptArrowKeys = False
        Me.txtTasaIgv.Location = New System.Drawing.Point(258, 124)
        Me.txtTasaIgv.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTasaIgv.Name = "txtTasaIgv"
        Me.txtTasaIgv.ReadOnly = True
        Me.txtTasaIgv.Size = New System.Drawing.Size(92, 20)
        Me.txtTasaIgv.TabIndex = 420
        Me.txtTasaIgv.TabStop = False
        Me.txtTasaIgv.ThousandsSeparator = True
        Me.txtTasaIgv.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
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
        Me.txtFechaComprobante.Calendar.MetroColor = System.Drawing.Color.YellowGreen
        Me.txtFechaComprobante.Calendar.Name = "monthCalendar"
        Me.txtFechaComprobante.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaComprobante.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaComprobante.Calendar.Size = New System.Drawing.Size(214, 174)
        Me.txtFechaComprobante.Calendar.SizeToFit = True
        Me.txtFechaComprobante.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.Calendar.TabIndex = 0
        Me.txtFechaComprobante.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaComprobante.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaComprobante.Calendar.NoneButton.BackColor = System.Drawing.Color.YellowGreen
        Me.txtFechaComprobante.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaComprobante.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaComprobante.Calendar.NoneButton.Location = New System.Drawing.Point(142, 0)
        Me.txtFechaComprobante.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaComprobante.Calendar.NoneButton.Text = "None"
        Me.txtFechaComprobante.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaComprobante.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaComprobante.Calendar.TodayButton.BackColor = System.Drawing.Color.YellowGreen
        Me.txtFechaComprobante.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaComprobante.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaComprobante.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaComprobante.Calendar.TodayButton.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaComprobante.Calendar.TodayButton.Text = "Today"
        Me.txtFechaComprobante.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaComprobante.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaComprobante.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaComprobante.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.txtFechaComprobante.DropDownImage = Nothing
        Me.txtFechaComprobante.DropDownNormalColor = System.Drawing.Color.YellowGreen
        Me.txtFechaComprobante.DropDownPressedColor = System.Drawing.Color.YellowGreen
        Me.txtFechaComprobante.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.txtFechaComprobante.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaComprobante.Location = New System.Drawing.Point(132, 3)
        Me.txtFechaComprobante.MetroColor = System.Drawing.Color.YellowGreen
        Me.txtFechaComprobante.MinValue = New Date(CType(0, Long))
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.ShowCheckBox = False
        Me.txtFechaComprobante.ShowDropButton = False
        Me.txtFechaComprobante.Size = New System.Drawing.Size(218, 20)
        Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.TabIndex = 208
        Me.txtFechaComprobante.TabStop = False
        Me.txtFechaComprobante.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(65, 258)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 419
        Me.Label18.Text = "IGV. ME.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(71, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 400
        Me.Label5.Text = "Moneda:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(65, 235)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 13)
        Me.Label17.TabIndex = 418
        Me.Label17.Text = "IGV. MN.:"
        '
        'txtComprobante
        '
        Me.txtComprobante.Location = New System.Drawing.Point(132, 28)
        Me.txtComprobante.MaxLength = 5
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(218, 19)
        Me.txtComprobante.TabIndex = 402
        Me.txtComprobante.TabStop = False
        Me.txtComprobante.Text = "NOTA DE PEDIDO"
        '
        'txtIgvme
        '
        Me.txtIgvme.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtIgvme.BeforeTouchSize = New System.Drawing.Size(164, 20)
        Me.txtIgvme.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIgvme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIgvme.DecimalPlaces = 2
        Me.txtIgvme.InterceptArrowKeys = False
        Me.txtIgvme.Location = New System.Drawing.Point(132, 255)
        Me.txtIgvme.Maximum = New Decimal(New Integer() {1241513984, 370409800, 542101, 0})
        Me.txtIgvme.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIgvme.Name = "txtIgvme"
        Me.txtIgvme.ReadOnly = True
        Me.txtIgvme.Size = New System.Drawing.Size(164, 20)
        Me.txtIgvme.TabIndex = 417
        Me.txtIgvme.TabStop = False
        Me.txtIgvme.ThousandsSeparator = True
        Me.txtIgvme.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtMoneda
        '
        Me.txtMoneda.Location = New System.Drawing.Point(132, 75)
        Me.txtMoneda.MaxLength = 20
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(69, 19)
        Me.txtMoneda.TabIndex = 403
        Me.txtMoneda.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(51, 210)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 13)
        Me.Label13.TabIndex = 415
        Me.Label13.Text = "Importe ME.:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(208, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 404
        Me.Label7.Text = "Período:"
        '
        'txtImporteME
        '
        Me.txtImporteME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtImporteME.BeforeTouchSize = New System.Drawing.Size(164, 20)
        Me.txtImporteME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteME.DecimalPlaces = 2
        Me.txtImporteME.InterceptArrowKeys = False
        Me.txtImporteME.Location = New System.Drawing.Point(132, 207)
        Me.txtImporteME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtImporteME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteME.Name = "txtImporteME"
        Me.txtImporteME.ReadOnly = True
        Me.txtImporteME.Size = New System.Drawing.Size(164, 20)
        Me.txtImporteME.TabIndex = 416
        Me.txtImporteME.TabStop = False
        Me.txtImporteME.ThousandsSeparator = True
        Me.txtImporteME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(258, 75)
        Me.txtPeriodo.MaxLength = 20
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.Size = New System.Drawing.Size(92, 19)
        Me.txtPeriodo.TabIndex = 405
        Me.txtPeriodo.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(51, 185)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 412
        Me.Label12.Text = "Importe MN.:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(46, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 406
        Me.Label8.Text = "Comprador:"
        '
        'txtImporteMn
        '
        Me.txtImporteMn.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtImporteMn.BeforeTouchSize = New System.Drawing.Size(164, 20)
        Me.txtImporteMn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteMn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteMn.DecimalPlaces = 2
        Me.txtImporteMn.InterceptArrowKeys = False
        Me.txtImporteMn.Location = New System.Drawing.Point(132, 182)
        Me.txtImporteMn.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtImporteMn.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteMn.Name = "txtImporteMn"
        Me.txtImporteMn.ReadOnly = True
        Me.txtImporteMn.Size = New System.Drawing.Size(164, 20)
        Me.txtImporteMn.TabIndex = 414
        Me.txtImporteMn.TabStop = False
        Me.txtImporteMn.ThousandsSeparator = True
        Me.txtImporteMn.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtComprador
        '
        Me.txtComprador.BackColor = System.Drawing.Color.White
        Me.txtComprador.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtComprador.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtComprador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprador.CornerRadius = 5
        Me.txtComprador.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtComprador.FarImage = CType(resources.GetObject("txtComprador.FarImage"), System.Drawing.Image)
        Me.txtComprador.FocusBorderColor = System.Drawing.Color.Yellow
        Me.txtComprador.Location = New System.Drawing.Point(132, 99)
        Me.txtComprador.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtComprador.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtComprador.Name = "txtComprador"
        Me.txtComprador.ReadOnly = True
        Me.txtComprador.Size = New System.Drawing.Size(218, 20)
        Me.txtComprador.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtComprador.TabIndex = 407
        Me.txtComprador.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(51, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 408
        Me.Label9.Text = "Tipo Cambio:"
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtIgv.BeforeTouchSize = New System.Drawing.Size(164, 20)
        Me.txtIgv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIgv.DecimalPlaces = 2
        Me.txtIgv.InterceptArrowKeys = False
        Me.txtIgv.Location = New System.Drawing.Point(132, 231)
        Me.txtIgv.Maximum = New Decimal(New Integer() {1241513984, 370409800, 542101, 0})
        Me.txtIgv.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(164, 20)
        Me.txtIgv.TabIndex = 411
        Me.txtIgv.TabStop = False
        Me.txtIgv.ThousandsSeparator = True
        Me.txtIgv.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(192, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 409
        Me.Label10.Text = "I.G.V.:"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.White
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(51, 20)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.DecimalPlaces = 2
        Me.txtTipoCambio.InterceptArrowKeys = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(132, 124)
        Me.txtTipoCambio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(51, 20)
        Me.txtTipoCambio.TabIndex = 410
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.ThousandsSeparator = True
        Me.txtTipoCambio.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.txtTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'pnDatos
        '
        Me.pnDatos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnDatos.Controls.Add(Me.lblAnticipoME)
        Me.pnDatos.Controls.Add(Me.lblAnticipoMN)
        Me.pnDatos.Controls.Add(Me.txtAnticipoMN)
        Me.pnDatos.Controls.Add(Me.txtAnticipoME)
        Me.pnDatos.Controls.Add(Me.rbSinAnticipo)
        Me.pnDatos.Controls.Add(Me.Label34)
        Me.pnDatos.Controls.Add(Me.rbConAnticipo)
        Me.pnDatos.Controls.Add(Me.Label36)
        Me.pnDatos.Controls.Add(Me.txtTipoCambioVenta)
        Me.pnDatos.Controls.Add(Me.lblVueltoME)
        Me.pnDatos.Controls.Add(Me.Panel8)
        Me.pnDatos.Controls.Add(Me.txtVueltoME)
        Me.pnDatos.Controls.Add(Me.lblVueltoMN)
        Me.pnDatos.Controls.Add(Me.txtVueltoMN)
        Me.pnDatos.Controls.Add(Me.lblReciboME)
        Me.pnDatos.Controls.Add(Me.txtCobroMN)
        Me.pnDatos.Controls.Add(Me.lblReciboMN)
        Me.pnDatos.Controls.Add(Me.txtIngresoMN)
        Me.pnDatos.Controls.Add(Me.Label24)
        Me.pnDatos.Controls.Add(Me.txtCobroME)
        Me.pnDatos.Controls.Add(Me.Label25)
        Me.pnDatos.Controls.Add(Me.txtIngresoME)
        Me.pnDatos.Controls.Add(Me.Label35)
        Me.pnDatos.Enabled = False
        Me.pnDatos.Location = New System.Drawing.Point(0, 185)
        Me.pnDatos.Name = "pnDatos"
        Me.pnDatos.Size = New System.Drawing.Size(366, 185)
        Me.pnDatos.TabIndex = 438
        '
        'lblAnticipoME
        '
        Me.lblAnticipoME.AutoSize = True
        Me.lblAnticipoME.ForeColor = System.Drawing.Color.Black
        Me.lblAnticipoME.Location = New System.Drawing.Point(191, 102)
        Me.lblAnticipoME.Name = "lblAnticipoME"
        Me.lblAnticipoME.Size = New System.Drawing.Size(70, 13)
        Me.lblAnticipoME.TabIndex = 448
        Me.lblAnticipoME.Text = "Anticipo ME.:"
        '
        'lblAnticipoMN
        '
        Me.lblAnticipoMN.AutoSize = True
        Me.lblAnticipoMN.ForeColor = System.Drawing.Color.Black
        Me.lblAnticipoMN.Location = New System.Drawing.Point(16, 103)
        Me.lblAnticipoMN.Name = "lblAnticipoMN"
        Me.lblAnticipoMN.Size = New System.Drawing.Size(71, 13)
        Me.lblAnticipoMN.TabIndex = 446
        Me.lblAnticipoMN.Text = "Anticipo MN.:"
        '
        'txtAnticipoMN
        '
        Me.txtAnticipoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtAnticipoMN.BeforeTouchSize = New System.Drawing.Size(96, 20)
        Me.txtAnticipoMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnticipoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnticipoMN.DecimalPlaces = 2
        Me.txtAnticipoMN.Enabled = False
        Me.txtAnticipoMN.Location = New System.Drawing.Point(91, 99)
        Me.txtAnticipoMN.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtAnticipoMN.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnticipoMN.Name = "txtAnticipoMN"
        Me.txtAnticipoMN.Size = New System.Drawing.Size(96, 20)
        Me.txtAnticipoMN.TabIndex = 447
        Me.txtAnticipoMN.TabStop = False
        Me.txtAnticipoMN.ThousandsSeparator = True
        Me.txtAnticipoMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtAnticipoME
        '
        Me.txtAnticipoME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtAnticipoME.BeforeTouchSize = New System.Drawing.Size(96, 20)
        Me.txtAnticipoME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnticipoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnticipoME.DecimalPlaces = 2
        Me.txtAnticipoME.Enabled = False
        Me.txtAnticipoME.Location = New System.Drawing.Point(265, 99)
        Me.txtAnticipoME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtAnticipoME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnticipoME.Name = "txtAnticipoME"
        Me.txtAnticipoME.Size = New System.Drawing.Size(96, 20)
        Me.txtAnticipoME.TabIndex = 445
        Me.txtAnticipoME.TabStop = False
        Me.txtAnticipoME.ThousandsSeparator = True
        Me.txtAnticipoME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'rbSinAnticipo
        '
        Me.rbSinAnticipo.AutoSize = True
        Me.rbSinAnticipo.Checked = True
        Me.rbSinAnticipo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSinAnticipo.Location = New System.Drawing.Point(228, 26)
        Me.rbSinAnticipo.Name = "rbSinAnticipo"
        Me.rbSinAnticipo.Size = New System.Drawing.Size(66, 17)
        Me.rbSinAnticipo.TabIndex = 444
        Me.rbSinAnticipo.TabStop = True
        Me.rbSinAnticipo.Text = "Efectivo"
        Me.rbSinAnticipo.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(58, 28)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(31, 13)
        Me.Label34.TabIndex = 442
        Me.Label34.Text = "Tipo:"
        '
        'rbConAnticipo
        '
        Me.rbConAnticipo.AutoSize = True
        Me.rbConAnticipo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConAnticipo.Location = New System.Drawing.Point(93, 26)
        Me.rbConAnticipo.Name = "rbConAnticipo"
        Me.rbConAnticipo.Size = New System.Drawing.Size(114, 17)
        Me.rbConAnticipo.TabIndex = 443
        Me.rbConAnticipo.Text = "Anticipo recibido"
        Me.rbConAnticipo.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(20, 79)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(69, 13)
        Me.Label36.TabIndex = 440
        Me.Label36.Text = "Tipo Cambio:"
        '
        'txtTipoCambioVenta
        '
        Me.txtTipoCambioVenta.BackColor = System.Drawing.Color.Yellow
        Me.txtTipoCambioVenta.BeforeTouchSize = New System.Drawing.Size(96, 20)
        Me.txtTipoCambioVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambioVenta.DecimalPlaces = 2
        Me.txtTipoCambioVenta.Location = New System.Drawing.Point(93, 75)
        Me.txtTipoCambioVenta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambioVenta.Name = "txtTipoCambioVenta"
        Me.txtTipoCambioVenta.Size = New System.Drawing.Size(96, 20)
        Me.txtTipoCambioVenta.TabIndex = 441
        Me.txtTipoCambioVenta.TabStop = False
        Me.txtTipoCambioVenta.ThousandsSeparator = True
        Me.txtTipoCambioVenta.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.txtTipoCambioVenta.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'lblVueltoME
        '
        Me.lblVueltoME.AutoSize = True
        Me.lblVueltoME.ForeColor = System.Drawing.Color.Black
        Me.lblVueltoME.Location = New System.Drawing.Point(201, 152)
        Me.lblVueltoME.Name = "lblVueltoME"
        Me.lblVueltoME.Size = New System.Drawing.Size(62, 13)
        Me.lblVueltoME.TabIndex = 427
        Me.lblVueltoME.Text = "Vuelto ME.:"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Controls.Add(Me.Label23)
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(367, 24)
        Me.Panel8.TabIndex = 437
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label23.Location = New System.Drawing.Point(10, 3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(194, 19)
        Me.Label23.TabIndex = 170
        Me.Label23.Text = "Importe de la venta:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVueltoME
        '
        Me.txtVueltoME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtVueltoME.BeforeTouchSize = New System.Drawing.Size(96, 20)
        Me.txtVueltoME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVueltoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVueltoME.DecimalPlaces = 2
        Me.txtVueltoME.Enabled = False
        Me.txtVueltoME.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVueltoME.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtVueltoME.Location = New System.Drawing.Point(265, 149)
        Me.txtVueltoME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtVueltoME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVueltoME.Name = "txtVueltoME"
        Me.txtVueltoME.Size = New System.Drawing.Size(96, 20)
        Me.txtVueltoME.TabIndex = 428
        Me.txtVueltoME.TabStop = False
        Me.txtVueltoME.ThousandsSeparator = True
        Me.txtVueltoME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'lblVueltoMN
        '
        Me.lblVueltoMN.AutoSize = True
        Me.lblVueltoMN.ForeColor = System.Drawing.Color.Black
        Me.lblVueltoMN.Location = New System.Drawing.Point(28, 152)
        Me.lblVueltoMN.Name = "lblVueltoMN"
        Me.lblVueltoMN.Size = New System.Drawing.Size(63, 13)
        Me.lblVueltoMN.TabIndex = 425
        Me.lblVueltoMN.Text = "Vuelto MN.:"
        '
        'txtVueltoMN
        '
        Me.txtVueltoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtVueltoMN.BeforeTouchSize = New System.Drawing.Size(96, 20)
        Me.txtVueltoMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVueltoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVueltoMN.DecimalPlaces = 2
        Me.txtVueltoMN.Enabled = False
        Me.txtVueltoMN.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVueltoMN.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtVueltoMN.Location = New System.Drawing.Point(91, 149)
        Me.txtVueltoMN.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtVueltoMN.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVueltoMN.Name = "txtVueltoMN"
        Me.txtVueltoMN.Size = New System.Drawing.Size(96, 20)
        Me.txtVueltoMN.TabIndex = 426
        Me.txtVueltoMN.TabStop = False
        Me.txtVueltoMN.ThousandsSeparator = True
        Me.txtVueltoMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'lblReciboME
        '
        Me.lblReciboME.AutoSize = True
        Me.lblReciboME.ForeColor = System.Drawing.Color.Black
        Me.lblReciboME.Location = New System.Drawing.Point(191, 126)
        Me.lblReciboME.Name = "lblReciboME"
        Me.lblReciboME.Size = New System.Drawing.Size(72, 13)
        Me.lblReciboME.TabIndex = 423
        Me.lblReciboME.Text = "Recibido ME.:"
        '
        'txtCobroMN
        '
        Me.txtCobroMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtCobroMN.BeforeTouchSize = New System.Drawing.Size(96, 23)
        Me.txtCobroMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCobroMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCobroMN.DecimalPlaces = 2
        Me.txtCobroMN.Enabled = False
        Me.txtCobroMN.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCobroMN.Location = New System.Drawing.Point(93, 48)
        Me.txtCobroMN.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtCobroMN.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCobroMN.Name = "txtCobroMN"
        Me.txtCobroMN.Size = New System.Drawing.Size(96, 23)
        Me.txtCobroMN.TabIndex = 424
        Me.txtCobroMN.TabStop = False
        Me.txtCobroMN.ThousandsSeparator = True
        Me.txtCobroMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'lblReciboMN
        '
        Me.lblReciboMN.AutoSize = True
        Me.lblReciboMN.ForeColor = System.Drawing.Color.Black
        Me.lblReciboMN.Location = New System.Drawing.Point(16, 127)
        Me.lblReciboMN.Name = "lblReciboMN"
        Me.lblReciboMN.Size = New System.Drawing.Size(73, 13)
        Me.lblReciboMN.TabIndex = 421
        Me.lblReciboMN.Text = "Recibido MN.:"
        '
        'txtIngresoMN
        '
        Me.txtIngresoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtIngresoMN.BeforeTouchSize = New System.Drawing.Size(96, 20)
        Me.txtIngresoMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIngresoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIngresoMN.DecimalPlaces = 2
        Me.txtIngresoMN.Location = New System.Drawing.Point(91, 123)
        Me.txtIngresoMN.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtIngresoMN.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIngresoMN.Name = "txtIngresoMN"
        Me.txtIngresoMN.Size = New System.Drawing.Size(96, 20)
        Me.txtIngresoMN.TabIndex = 422
        Me.txtIngresoMN.TabStop = False
        Me.txtIngresoMN.ThousandsSeparator = True
        Me.txtIngresoMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Yellow
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(194, 53)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 13)
        Me.Label24.TabIndex = 419
        Me.Label24.Text = "Importe ME.:"
        '
        'txtCobroME
        '
        Me.txtCobroME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtCobroME.BeforeTouchSize = New System.Drawing.Size(96, 23)
        Me.txtCobroME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCobroME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCobroME.DecimalPlaces = 2
        Me.txtCobroME.Enabled = False
        Me.txtCobroME.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCobroME.Location = New System.Drawing.Point(267, 48)
        Me.txtCobroME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtCobroME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCobroME.Name = "txtCobroME"
        Me.txtCobroME.Size = New System.Drawing.Size(96, 23)
        Me.txtCobroME.TabIndex = 420
        Me.txtCobroME.TabStop = False
        Me.txtCobroME.ThousandsSeparator = True
        Me.txtCobroME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Yellow
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(5, 53)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(84, 13)
        Me.Label25.TabIndex = 417
        Me.Label25.Text = "Monto x cobrar:"
        '
        'txtIngresoME
        '
        Me.txtIngresoME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtIngresoME.BeforeTouchSize = New System.Drawing.Size(96, 20)
        Me.txtIngresoME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIngresoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIngresoME.DecimalPlaces = 2
        Me.txtIngresoME.Enabled = False
        Me.txtIngresoME.Location = New System.Drawing.Point(265, 123)
        Me.txtIngresoME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtIngresoME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIngresoME.Name = "txtIngresoME"
        Me.txtIngresoME.Size = New System.Drawing.Size(96, 20)
        Me.txtIngresoME.TabIndex = 418
        Me.txtIngresoME.TabStop = False
        Me.txtIngresoME.ThousandsSeparator = True
        Me.txtIngresoME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Yellow
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(4, 48)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(367, 23)
        Me.Label35.TabIndex = 421
        '
        'pnVentas
        '
        Me.pnVentas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnVentas.Controls.Add(Me.Label21)
        Me.pnVentas.Controls.Add(Me.txtFechaCobro)
        Me.pnVentas.Controls.Add(Me.Label3)
        Me.pnVentas.Controls.Add(Me.Label22)
        Me.pnVentas.Controls.Add(Me.Label15)
        Me.pnVentas.Controls.Add(Me.rbFactura)
        Me.pnVentas.Controls.Add(Me.popupControlContainer1)
        Me.pnVentas.Controls.Add(Me.Label20)
        Me.pnVentas.Controls.Add(Me.Label19)
        Me.pnVentas.Controls.Add(Me.txtTipoDocVenta)
        Me.pnVentas.Controls.Add(Me.txtSerVenta)
        Me.pnVentas.Controls.Add(Me.rbBoleta)
        Me.pnVentas.Controls.Add(Me.PictureBox3)
        Me.pnVentas.Controls.Add(Me.txtnroVenta)
        Me.pnVentas.Controls.Add(Me.txtCuenta)
        Me.pnVentas.Controls.Add(Me.txtRuc)
        Me.pnVentas.Controls.Add(Me.txtCliente)
        Me.pnVentas.Controls.Add(Me.Label16)
        Me.pnVentas.Enabled = False
        Me.pnVentas.Location = New System.Drawing.Point(-1, 406)
        Me.pnVentas.Name = "pnVentas"
        Me.pnVentas.Size = New System.Drawing.Size(367, 187)
        Me.pnVentas.TabIndex = 436
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(77, 6)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(37, 13)
        Me.Label21.TabIndex = 412
        Me.Label21.Text = "Emitir:"
        '
        'txtFechaCobro
        '
        Me.txtFechaCobro.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaCobro.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaCobro.Calendar.AllowMultipleSelection = False
        Me.txtFechaCobro.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaCobro.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaCobro.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaCobro.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaCobro.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaCobro.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaCobro.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaCobro.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaCobro.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaCobro.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaCobro.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaCobro.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaCobro.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaCobro.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaCobro.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaCobro.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaCobro.Calendar.Name = "monthCalendar"
        Me.txtFechaCobro.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaCobro.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaCobro.Calendar.Size = New System.Drawing.Size(214, 174)
        Me.txtFechaCobro.Calendar.SizeToFit = True
        Me.txtFechaCobro.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaCobro.Calendar.TabIndex = 0
        Me.txtFechaCobro.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaCobro.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaCobro.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaCobro.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaCobro.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaCobro.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaCobro.Calendar.NoneButton.Location = New System.Drawing.Point(142, 0)
        Me.txtFechaCobro.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaCobro.Calendar.NoneButton.Text = "None"
        Me.txtFechaCobro.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaCobro.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaCobro.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaCobro.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaCobro.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaCobro.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaCobro.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaCobro.Calendar.TodayButton.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaCobro.Calendar.TodayButton.Text = "Today"
        Me.txtFechaCobro.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaCobro.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaCobro.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaCobro.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtFechaCobro.DropDownImage = Nothing
        Me.txtFechaCobro.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaCobro.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaCobro.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaCobro.Location = New System.Drawing.Point(124, 27)
        Me.txtFechaCobro.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaCobro.MinValue = New Date(CType(0, Long))
        Me.txtFechaCobro.Name = "txtFechaCobro"
        Me.txtFechaCobro.ShowCheckBox = False
        Me.txtFechaCobro.ShowDropButton = False
        Me.txtFechaCobro.Size = New System.Drawing.Size(218, 20)
        Me.txtFechaCobro.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaCobro.TabIndex = 435
        Me.txtFechaCobro.TabStop = False
        Me.txtFechaCobro.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(66, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 202
        Me.Label3.Text = "Cuenta:"
        Me.Label3.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(44, 30)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 13)
        Me.Label22.TabIndex = 434
        Me.Label22.Text = "Fecha cobro:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(42, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 200
        Me.Label15.Text = "Razón social:"
        Me.Label15.Visible = False
        '
        'rbFactura
        '
        Me.rbFactura.AutoSize = True
        Me.rbFactura.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFactura.Location = New System.Drawing.Point(233, 4)
        Me.rbFactura.Name = "rbFactura"
        Me.rbFactura.Size = New System.Drawing.Size(97, 17)
        Me.rbFactura.TabIndex = 415
        Me.rbFactura.TabStop = True
        Me.rbFactura.Text = "Ticket-Factura"
        Me.rbFactura.UseVisualStyleBackColor = True
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.popupControlContainer1.Controls.Add(Me.cancel)
        Me.popupControlContainer1.Controls.Add(Me.OK)
        Me.popupControlContainer1.Controls.Add(Me.lsvCliente)
        Me.popupControlContainer1.Location = New System.Drawing.Point(50, 187)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(279, 147)
        Me.popupControlContainer1.TabIndex = 201
        Me.popupControlContainer1.Visible = False
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
        'lsvCliente
        '
        Me.lsvCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lsvCliente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvCliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.lsvCliente.FullRowSelect = True
        Me.lsvCliente.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvCliente.Location = New System.Drawing.Point(0, 0)
        Me.lsvCliente.Name = "lsvCliente"
        Me.lsvCliente.Size = New System.Drawing.Size(277, 114)
        Me.lsvCliente.TabIndex = 3
        Me.lsvCliente.UseCompatibleStateImageBehavior = False
        Me.lsvCliente.View = System.Windows.Forms.View.Details
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
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(36, 155)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 13)
        Me.Label20.TabIndex = 432
        Me.Label20.Text = "Comprobante:"
        Me.Label20.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(6, 55)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 13)
        Me.Label19.TabIndex = 421
        Me.Label19.Text = "Serie/número venta:"
        '
        'txtTipoDocVenta
        '
        Me.txtTipoDocVenta.BackColor = System.Drawing.Color.White
        Me.txtTipoDocVenta.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtTipoDocVenta.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtTipoDocVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoDocVenta.CornerRadius = 5
        Me.txtTipoDocVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoDocVenta.FocusBorderColor = System.Drawing.Color.Yellow
        Me.txtTipoDocVenta.Location = New System.Drawing.Point(122, 150)
        Me.txtTipoDocVenta.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtTipoDocVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoDocVenta.Name = "txtTipoDocVenta"
        Me.txtTipoDocVenta.ReadOnly = True
        Me.txtTipoDocVenta.Size = New System.Drawing.Size(218, 20)
        Me.txtTipoDocVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoDocVenta.TabIndex = 433
        Me.txtTipoDocVenta.TabStop = False
        Me.txtTipoDocVenta.Visible = False
        '
        'txtSerVenta
        '
        Me.txtSerVenta.BackColor = System.Drawing.Color.White
        Me.txtSerVenta.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtSerVenta.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtSerVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerVenta.CornerRadius = 5
        Me.txtSerVenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSerVenta.FocusBorderColor = System.Drawing.Color.Yellow
        Me.txtSerVenta.Location = New System.Drawing.Point(122, 52)
        Me.txtSerVenta.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtSerVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerVenta.Name = "txtSerVenta"
        Me.txtSerVenta.ReadOnly = True
        Me.txtSerVenta.Size = New System.Drawing.Size(69, 20)
        Me.txtSerVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtSerVenta.TabIndex = 422
        Me.txtSerVenta.TabStop = False
        '
        'rbBoleta
        '
        Me.rbBoleta.AutoSize = True
        Me.rbBoleta.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBoleta.Location = New System.Drawing.Point(130, 4)
        Me.rbBoleta.Name = "rbBoleta"
        Me.rbBoleta.Size = New System.Drawing.Size(92, 17)
        Me.rbBoleta.TabIndex = 414
        Me.rbBoleta.TabStop = True
        Me.rbBoleta.Text = "Ticket-Boleta"
        Me.rbBoleta.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(246, 80)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 219
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'txtnroVenta
        '
        Me.txtnroVenta.BackColor = System.Drawing.Color.White
        Me.txtnroVenta.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtnroVenta.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtnroVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnroVenta.CornerRadius = 5
        Me.txtnroVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnroVenta.FarImage = CType(resources.GetObject("txtnroVenta.FarImage"), System.Drawing.Image)
        Me.txtnroVenta.FocusBorderColor = System.Drawing.Color.Yellow
        Me.txtnroVenta.Location = New System.Drawing.Point(193, 52)
        Me.txtnroVenta.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtnroVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtnroVenta.Name = "txtnroVenta"
        Me.txtnroVenta.ReadOnly = True
        Me.txtnroVenta.Size = New System.Drawing.Size(147, 20)
        Me.txtnroVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtnroVenta.TabIndex = 423
        Me.txtnroVenta.TabStop = False
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.White
        Me.txtCuenta.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtCuenta.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta.CornerRadius = 5
        Me.txtCuenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCuenta.FocusBorderColor = System.Drawing.Color.Yellow
        Me.txtCuenta.Location = New System.Drawing.Point(124, 128)
        Me.txtCuenta.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtCuenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(67, 20)
        Me.txtCuenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuenta.TabIndex = 431
        Me.txtCuenta.TabStop = False
        Me.txtCuenta.Text = "1213"
        Me.txtCuenta.Visible = False
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.White
        Me.txtRuc.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtRuc.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.CornerRadius = 5
        Me.txtRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRuc.Location = New System.Drawing.Point(124, 80)
        Me.txtRuc.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC6329681
        Me.txtRuc.Size = New System.Drawing.Size(119, 20)
        Me.txtRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtRuc.TabIndex = 428
        Me.txtRuc.Tag = "0"
        Me.txtRuc.Text = "0000"
        Me.txtRuc.Visible = False
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtCliente.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.CornerRadius = 5
        Me.txtCliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCliente.FocusBorderColor = System.Drawing.Color.Yellow
        Me.txtCliente.Location = New System.Drawing.Point(124, 103)
        Me.txtCliente.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtCliente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(216, 20)
        Me.txtCliente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCliente.TabIndex = 430
        Me.txtCliente.TabStop = False
        Me.txtCliente.Tag = "0"
        Me.txtCliente.Text = "Clientes varios"
        Me.txtCliente.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(2, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(110, 13)
        Me.Label16.TabIndex = 429
        Me.Label16.Text = "Buscar cliente x doc.:"
        Me.Label16.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Location = New System.Drawing.Point(0, 376)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(367, 24)
        Me.Panel2.TabIndex = 424
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.Location = New System.Drawing.Point(10, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(194, 19)
        Me.Label14.TabIndex = 170
        Me.Label14.Text = "Datos de la venta:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 62)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(367, 24)
        Me.Panel1.TabIndex = 404
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Location = New System.Drawing.Point(10, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(194, 19)
        Me.Label11.TabIndex = 170
        Me.Label11.Text = "Datos del pedido:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpVSBehavior
        '
        Me.gpVSBehavior.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gpVSBehavior.BorderColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.gpVSBehavior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gpVSBehavior.Controls.Add(Me.Label37)
        Me.gpVSBehavior.Controls.Add(Me.PictureBox2)
        Me.gpVSBehavior.Controls.Add(Me.txtSeriePedido)
        Me.gpVSBehavior.Controls.Add(Me.Label2)
        Me.gpVSBehavior.Controls.Add(Me.txtNumeroPedido)
        Me.gpVSBehavior.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpVSBehavior.Location = New System.Drawing.Point(0, 0)
        Me.gpVSBehavior.Name = "gpVSBehavior"
        Me.gpVSBehavior.Size = New System.Drawing.Size(367, 62)
        Me.gpVSBehavior.TabIndex = 401
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Label37.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label37.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label37.Location = New System.Drawing.Point(0, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(365, 23)
        Me.Label37.TabIndex = 422
        Me.Label37.Text = "Buscar pedido:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(344, 49)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 411
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'txtSeriePedido
        '
        Me.txtSeriePedido.BackColor = System.Drawing.Color.White
        Me.txtSeriePedido.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtSeriePedido.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtSeriePedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSeriePedido.CornerRadius = 5
        Me.txtSeriePedido.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSeriePedido.Enabled = False
        Me.txtSeriePedido.Location = New System.Drawing.Point(123, 31)
        Me.txtSeriePedido.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtSeriePedido.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSeriePedido.Name = "txtSeriePedido"
        Me.txtSeriePedido.ReadOnly = True
        Me.txtSeriePedido.Size = New System.Drawing.Size(77, 20)
        Me.txtSeriePedido.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtSeriePedido.TabIndex = 401
        Me.txtSeriePedido.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(30, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 400
        Me.Label2.Text = "Buscar pedido:"
        '
        'txtNumeroPedido
        '
        Me.txtNumeroPedido.BackColor = System.Drawing.Color.White
        Me.txtNumeroPedido.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtNumeroPedido.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtNumeroPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroPedido.CornerRadius = 5
        Me.txtNumeroPedido.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumeroPedido.FarImage = CType(resources.GetObject("txtNumeroPedido.FarImage"), System.Drawing.Image)
        Me.txtNumeroPedido.FocusBorderColor = System.Drawing.Color.Yellow
        Me.txtNumeroPedido.Location = New System.Drawing.Point(202, 31)
        Me.txtNumeroPedido.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtNumeroPedido.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumeroPedido.Name = "txtNumeroPedido"
        Me.txtNumeroPedido.Size = New System.Drawing.Size(139, 20)
        Me.txtNumeroPedido.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumeroPedido.TabIndex = 399
        Me.txtNumeroPedido.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintTikect
        Me.PageSetupDialog1.EnableMetric = True
        '
        'PrintPreviewDialogTicket
        '
        Me.PrintPreviewDialogTicket.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialogTicket.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialogTicket.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialogTicket.Document = Me.PrintTikect
        Me.PrintPreviewDialogTicket.Enabled = True
        Me.PrintPreviewDialogTicket.Icon = CType(resources.GetObject("PrintPreviewDialogTicket.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialogTicket.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialogTicket.UseAntiAlias = True
        Me.PrintPreviewDialogTicket.Visible = False
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(224, 31)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(53, 56)
        Me.PictureBox6.TabIndex = 2
        Me.PictureBox6.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox6, "Confirmar venta")
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(58, 31)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(53, 56)
        Me.PictureBox7.TabIndex = 4
        Me.PictureBox7.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox7, "Actualizar pedido")
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(169, 31)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(53, 56)
        Me.PictureBox5.TabIndex = 1
        Me.PictureBox5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox5, "Eliminar item de canasta")
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(114, 31)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(53, 56)
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox4, "Agregar item a pedido")
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(3, 31)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(53, 56)
        Me.PictureBox8.TabIndex = 412
        Me.PictureBox8.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox8, "Formato Ticket")
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(921, 22)
        Me.PanelError.TabIndex = 410
        Me.PanelError.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(902, 0)
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
        'DockingClientPanel1
        '
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DockingClientPanel1.Controls.Add(Me.Panel5)
        Me.DockingClientPanel1.Controls.Add(Me.Panel4)
        Me.DockingClientPanel1.Location = New System.Drawing.Point(0, 24)
        Me.DockingClientPanel1.Name = "DockingClientPanel1"
        Me.DockingClientPanel1.Size = New System.Drawing.Size(921, 680)
        Me.DockingClientPanel1.TabIndex = 409
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.pcProveedor)
        Me.Panel5.Controls.Add(Me.pnImpresionTicket)
        Me.Panel5.Controls.Add(Me.lsvDetalle)
        Me.Panel5.Controls.Add(Me.GradientPanel3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(367, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(554, 680)
        Me.Panel5.TabIndex = 409
        '
        'pcProveedor
        '
        Me.pcProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcProveedor.Controls.Add(Me.btnCarnetEx)
        Me.pcProveedor.Controls.Add(Me.btnDni)
        Me.pcProveedor.Controls.Add(Me.btnPassport)
        Me.pcProveedor.Controls.Add(Me.btnRuc)
        Me.pcProveedor.Controls.Add(Me.Panel14)
        Me.pcProveedor.Controls.Add(Me.txtDocProveedor)
        Me.pcProveedor.Controls.Add(Me.Label32)
        Me.pcProveedor.Controls.Add(Me.txtApePat)
        Me.pcProveedor.Controls.Add(Me.Label31)
        Me.pcProveedor.Controls.Add(Me.txtNomProv)
        Me.pcProveedor.Controls.Add(Me.Label30)
        Me.pcProveedor.Controls.Add(Me.GroupBox1)
        Me.pcProveedor.Controls.Add(Me.btnCancelarProv)
        Me.pcProveedor.Controls.Add(Me.btnGRabarProv)
        Me.pcProveedor.Location = New System.Drawing.Point(368, 131)
        Me.pcProveedor.Name = "pcProveedor"
        Me.pcProveedor.Size = New System.Drawing.Size(325, 260)
        Me.pcProveedor.TabIndex = 412
        Me.pcProveedor.Visible = False
        '
        'btnCarnetEx
        '
        Me.btnCarnetEx.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Custom3
        Me.btnCarnetEx.Enabled = False
        Me.btnCarnetEx.Location = New System.Drawing.Point(269, 29)
        Me.btnCarnetEx.Name = "btnCarnetEx"
        Me.btnCarnetEx.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.btnCarnetEx.Size = New System.Drawing.Size(39, 24)
        Me.btnCarnetEx.TabIndex = 409
        Me.btnCarnetEx.TabStop = False
        Me.btnCarnetEx.Values.Text = "CEX"
        '
        'btnDni
        '
        Me.btnDni.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Custom3
        Me.btnDni.Location = New System.Drawing.Point(185, 29)
        Me.btnDni.Name = "btnDni"
        Me.btnDni.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.btnDni.Size = New System.Drawing.Size(39, 24)
        Me.btnDni.TabIndex = 408
        Me.btnDni.TabStop = False
        Me.btnDni.Values.Text = "DNI"
        '
        'btnPassport
        '
        Me.btnPassport.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Custom3
        Me.btnPassport.Enabled = False
        Me.btnPassport.Location = New System.Drawing.Point(227, 29)
        Me.btnPassport.Name = "btnPassport"
        Me.btnPassport.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.btnPassport.Size = New System.Drawing.Size(39, 24)
        Me.btnPassport.TabIndex = 407
        Me.btnPassport.TabStop = False
        Me.btnPassport.Values.Text = "PSP"
        '
        'btnRuc
        '
        Me.btnRuc.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Custom3
        Me.btnRuc.Checked = True
        Me.btnRuc.Location = New System.Drawing.Point(143, 29)
        Me.btnRuc.Name = "btnRuc"
        Me.btnRuc.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.btnRuc.Size = New System.Drawing.Size(39, 24)
        Me.btnRuc.TabIndex = 406
        Me.btnRuc.TabStop = False
        Me.btnRuc.Values.Text = "RUC"
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel14.Controls.Add(Me.Label33)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(323, 24)
        Me.Panel14.TabIndex = 405
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Image = CType(resources.GetObject("Label33.Image"), System.Drawing.Image)
        Me.Label33.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label33.Location = New System.Drawing.Point(10, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(123, 19)
        Me.Label33.TabIndex = 170
        Me.Label33.Text = "Nuevo cliente"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDocProveedor
        '
        Me.txtDocProveedor.BackColor = System.Drawing.Color.White
        Me.txtDocProveedor.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtDocProveedor.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtDocProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocProveedor.CornerRadius = 5
        Me.txtDocProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDocProveedor.Location = New System.Drawing.Point(8, 119)
        Me.txtDocProveedor.MaxLength = 11
        Me.txtDocProveedor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtDocProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDocProveedor.Name = "txtDocProveedor"
        Me.txtDocProveedor.Size = New System.Drawing.Size(135, 20)
        Me.txtDocProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDocProveedor.TabIndex = 404
        Me.txtDocProveedor.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(5, 101)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(88, 13)
        Me.Label32.TabIndex = 403
        Me.Label32.Text = "Nro. documento:"
        '
        'txtApePat
        '
        Me.txtApePat.BackColor = System.Drawing.Color.White
        Me.txtApePat.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtApePat.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtApePat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApePat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApePat.CornerRadius = 5
        Me.txtApePat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtApePat.Location = New System.Drawing.Point(8, 202)
        Me.txtApePat.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtApePat.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtApePat.Name = "txtApePat"
        Me.txtApePat.Size = New System.Drawing.Size(304, 20)
        Me.txtApePat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtApePat.TabIndex = 402
        Me.txtApePat.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(8, 184)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(53, 13)
        Me.Label31.TabIndex = 401
        Me.Label31.Text = "Apellidos:"
        '
        'txtNomProv
        '
        Me.txtNomProv.BackColor = System.Drawing.Color.White
        Me.txtNomProv.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtNomProv.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtNomProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNomProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomProv.CornerRadius = 5
        Me.txtNomProv.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNomProv.Location = New System.Drawing.Point(8, 159)
        Me.txtNomProv.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtNomProv.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNomProv.Name = "txtNomProv"
        Me.txtNomProv.Size = New System.Drawing.Size(304, 20)
        Me.txtNomProv.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNomProv.TabIndex = 400
        Me.txtNomProv.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(5, 143)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 13)
        Me.Label30.TabIndex = 211
        Me.Label30.Text = "Nombres:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbJuridico)
        Me.GroupBox1.Controls.Add(Me.rbNatural)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(309, 42)
        Me.GroupBox1.TabIndex = 210
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Persona:"
        '
        'rbJuridico
        '
        Me.rbJuridico.BeforeTouchSize = New System.Drawing.Size(80, 21)
        Me.rbJuridico.DrawFocusRectangle = False
        Me.rbJuridico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rbJuridico.Location = New System.Drawing.Point(171, 16)
        Me.rbJuridico.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbJuridico.Name = "rbJuridico"
        Me.rbJuridico.Size = New System.Drawing.Size(80, 21)
        Me.rbJuridico.Style = Syncfusion.Windows.Forms.Tools.RadioButtonAdvStyle.Metro
        Me.rbJuridico.TabIndex = 5
        Me.rbJuridico.TabStop = False
        Me.rbJuridico.Text = "Juridico"
        Me.rbJuridico.ThemesEnabled = False
        '
        'rbNatural
        '
        Me.rbNatural.BeforeTouchSize = New System.Drawing.Size(80, 21)
        Me.rbNatural.Checked = True
        Me.rbNatural.DrawFocusRectangle = False
        Me.rbNatural.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rbNatural.Location = New System.Drawing.Point(60, 16)
        Me.rbNatural.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbNatural.Name = "rbNatural"
        Me.rbNatural.Size = New System.Drawing.Size(80, 21)
        Me.rbNatural.Style = Syncfusion.Windows.Forms.Tools.RadioButtonAdvStyle.Metro
        Me.rbNatural.TabIndex = 4
        Me.rbNatural.Text = "Natural"
        Me.rbNatural.ThemesEnabled = False
        '
        'btnCancelarProv
        '
        Me.btnCancelarProv.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnCancelarProv.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnCancelarProv.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.btnCancelarProv.ForeColor = System.Drawing.Color.White
        Me.btnCancelarProv.IsBackStageButton = False
        Me.btnCancelarProv.Location = New System.Drawing.Point(252, 225)
        Me.btnCancelarProv.Name = "btnCancelarProv"
        Me.btnCancelarProv.Size = New System.Drawing.Size(60, 19)
        Me.btnCancelarProv.TabIndex = 209
        Me.btnCancelarProv.TabStop = False
        Me.btnCancelarProv.Text = "Cancelar"
        Me.btnCancelarProv.UseVisualStyle = True
        '
        'btnGRabarProv
        '
        Me.btnGRabarProv.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnGRabarProv.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnGRabarProv.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.btnGRabarProv.ForeColor = System.Drawing.Color.White
        Me.btnGRabarProv.IsBackStageButton = False
        Me.btnGRabarProv.Location = New System.Drawing.Point(190, 225)
        Me.btnGRabarProv.Name = "btnGRabarProv"
        Me.btnGRabarProv.Size = New System.Drawing.Size(60, 19)
        Me.btnGRabarProv.TabIndex = 208
        Me.btnGRabarProv.TabStop = False
        Me.btnGRabarProv.Text = "OK"
        Me.btnGRabarProv.UseVisualStyle = True
        '
        'pnImpresionTicket
        '
        Me.pnImpresionTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnImpresionTicket.Controls.Add(Me.txtFechaN)
        Me.pnImpresionTicket.Controls.Add(Me.ButtonAdv2)
        Me.pnImpresionTicket.Controls.Add(Me.ButtonAdv3)
        Me.pnImpresionTicket.Controls.Add(Me.txtVendedorN)
        Me.pnImpresionTicket.Controls.Add(Me.Label39)
        Me.pnImpresionTicket.Controls.Add(Me.Label38)
        Me.pnImpresionTicket.Controls.Add(Me.txtCajaN)
        Me.pnImpresionTicket.Controls.Add(Me.Label29)
        Me.pnImpresionTicket.Controls.Add(Me.txtCodMaqN)
        Me.pnImpresionTicket.Controls.Add(Me.Label28)
        Me.pnImpresionTicket.Controls.Add(Me.txtCompradorN)
        Me.pnImpresionTicket.Controls.Add(Me.Label27)
        Me.pnImpresionTicket.Controls.Add(Me.Panel9)
        Me.pnImpresionTicket.Location = New System.Drawing.Point(25, 223)
        Me.pnImpresionTicket.Name = "pnImpresionTicket"
        Me.pnImpresionTicket.Size = New System.Drawing.Size(348, 206)
        Me.pnImpresionTicket.TabIndex = 413
        Me.pnImpresionTicket.Visible = False
        '
        'txtFechaN
        '
        Me.txtFechaN.Location = New System.Drawing.Point(100, 107)
        Me.txtFechaN.Name = "txtFechaN"
        Me.txtFechaN.Size = New System.Drawing.Size(216, 20)
        Me.txtFechaN.TabIndex = 419
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(278, 168)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv2.TabIndex = 418
        Me.ButtonAdv2.TabStop = False
        Me.ButtonAdv2.Text = "Cancelar"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(216, 168)
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv3.TabIndex = 417
        Me.ButtonAdv3.TabStop = False
        Me.ButtonAdv3.Text = "OK"
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'txtVendedorN
        '
        Me.txtVendedorN.BackColor = System.Drawing.Color.White
        Me.txtVendedorN.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtVendedorN.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtVendedorN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendedorN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedorN.CornerRadius = 5
        Me.txtVendedorN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendedorN.Location = New System.Drawing.Point(100, 137)
        Me.txtVendedorN.MaxLength = 1000000000
        Me.txtVendedorN.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtVendedorN.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtVendedorN.Name = "txtVendedorN"
        Me.txtVendedorN.Size = New System.Drawing.Size(239, 20)
        Me.txtVendedorN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtVendedorN.TabIndex = 416
        Me.txtVendedorN.TabStop = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label39.Location = New System.Drawing.Point(37, 141)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(57, 13)
        Me.Label39.TabIndex = 415
        Me.Label39.Text = "Vendedor:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label38.Location = New System.Drawing.Point(54, 113)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(40, 13)
        Me.Label38.TabIndex = 413
        Me.Label38.Text = "Fecha:"
        '
        'txtCajaN
        '
        Me.txtCajaN.BackColor = System.Drawing.Color.White
        Me.txtCajaN.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtCajaN.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtCajaN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCajaN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCajaN.CornerRadius = 5
        Me.txtCajaN.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCajaN.Location = New System.Drawing.Point(100, 80)
        Me.txtCajaN.MaxLength = 1000000000
        Me.txtCajaN.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtCajaN.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCajaN.Name = "txtCajaN"
        Me.txtCajaN.Size = New System.Drawing.Size(239, 20)
        Me.txtCajaN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCajaN.TabIndex = 412
        Me.txtCajaN.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(61, 83)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(33, 13)
        Me.Label29.TabIndex = 411
        Me.Label29.Text = "Caja:"
        '
        'txtCodMaqN
        '
        Me.txtCodMaqN.BackColor = System.Drawing.Color.White
        Me.txtCodMaqN.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtCodMaqN.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtCodMaqN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodMaqN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMaqN.CornerRadius = 5
        Me.txtCodMaqN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodMaqN.Location = New System.Drawing.Point(100, 54)
        Me.txtCodMaqN.MaxLength = 1000000000
        Me.txtCodMaqN.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtCodMaqN.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCodMaqN.Name = "txtCodMaqN"
        Me.txtCodMaqN.Size = New System.Drawing.Size(239, 20)
        Me.txtCodMaqN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCodMaqN.TabIndex = 410
        Me.txtCodMaqN.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(7, 55)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(87, 13)
        Me.Label28.TabIndex = 409
        Me.Label28.Text = "Codigo Maquina:"
        '
        'txtCompradorN
        '
        Me.txtCompradorN.BackColor = System.Drawing.Color.White
        Me.txtCompradorN.BeforeTouchSize = New System.Drawing.Size(74, 20)
        Me.txtCompradorN.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtCompradorN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompradorN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompradorN.CornerRadius = 5
        Me.txtCompradorN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCompradorN.Location = New System.Drawing.Point(100, 27)
        Me.txtCompradorN.MaxLength = 1000000000
        Me.txtCompradorN.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtCompradorN.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCompradorN.Name = "txtCompradorN"
        Me.txtCompradorN.Size = New System.Drawing.Size(239, 20)
        Me.txtCompradorN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCompradorN.TabIndex = 408
        Me.txtCompradorN.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(30, 31)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(64, 13)
        Me.Label27.TabIndex = 407
        Me.Label27.Text = "Comprador:"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel9.Controls.Add(Me.Label26)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(346, 24)
        Me.Panel9.TabIndex = 406
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.edit3
        Me.Label26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label26.Location = New System.Drawing.Point(3, 3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(152, 19)
        Me.Label26.TabIndex = 170
        Me.Label26.Text = "Configuración Ticket"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lsvDetalle
        '
        Me.lsvDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvDetalle.Location = New System.Drawing.Point(0, 91)
        Me.lsvDetalle.Name = "lsvDetalle"
        Me.lsvDetalle.Size = New System.Drawing.Size(554, 589)
        Me.lsvDetalle.TabIndex = 409
        Me.lsvDetalle.UseCompatibleStateImageBehavior = False
        Me.lsvDetalle.View = System.Windows.Forms.View.Details
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel3.BorderColor = System.Drawing.Color.White
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.PictureBox8)
        Me.GradientPanel3.Controls.Add(Me.DigitalGauge2)
        Me.GradientPanel3.Controls.Add(Me.PictureBox6)
        Me.GradientPanel3.Controls.Add(Me.PictureBox7)
        Me.GradientPanel3.Controls.Add(Me.PictureBox5)
        Me.GradientPanel3.Controls.Add(Me.PictureBox4)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel3.EnableTouchMode = True
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(554, 91)
        Me.GradientPanel3.TabIndex = 407
        '
        'DigitalGauge2
        '
        Me.DigitalGauge2.BackgroundGradientEndColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.DigitalGauge2.BackgroundGradientStartColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.DigitalGauge2.CharacterCount = 10
        Me.DigitalGauge2.DisplayRecordIndex = 0
        Me.DigitalGauge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DigitalGauge2.ForeColor = System.Drawing.Color.White
        Me.DigitalGauge2.FrameBorderColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.DigitalGauge2.Location = New System.Drawing.Point(302, 0)
        Me.DigitalGauge2.MaximumSize = New System.Drawing.Size(500, 180)
        Me.DigitalGauge2.MinimumSize = New System.Drawing.Size(90, 90)
        Me.DigitalGauge2.Name = "DigitalGauge2"
        Me.DigitalGauge2.OuterFrameGradientEndColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.DigitalGauge2.OuterFrameGradientStartColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.DigitalGauge2.ShowInvisibleSegments = True
        Me.DigitalGauge2.Size = New System.Drawing.Size(250, 90)
        Me.DigitalGauge2.TabIndex = 410
        Me.DigitalGauge2.Value = "0.00"
        Me.DigitalGauge2.VisualStyle = Syncfusion.Windows.Forms.Gauge.ThemeStyle.Black
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Controls.Add(Me.ButtonAdv1)
        Me.Panel7.Controls.Add(Me.chCliente)
        Me.Panel7.Controls.Add(Me.btnConfigCaja)
        Me.Panel7.Controls.Add(Me.btnConfiguracion)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(921, 0)
        Me.Panel7.TabIndex = 408
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(28, 20)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(55, 0)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(28, 20)
        Me.ButtonAdv1.TabIndex = 218
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'chCliente
        '
        Me.chCliente.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.chCliente.DrawFocusRectangle = False
        Me.chCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.chCliente.Location = New System.Drawing.Point(320, 0)
        Me.chCliente.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chCliente.Name = "chCliente"
        Me.chCliente.Size = New System.Drawing.Size(100, 20)
        Me.chCliente.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.chCliente.TabIndex = 217
        Me.chCliente.Text = "Cliente"
        Me.chCliente.ThemesEnabled = False
        Me.chCliente.Visible = False
        '
        'btnConfigCaja
        '
        Me.btnConfigCaja.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnConfigCaja.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnConfigCaja.BeforeTouchSize = New System.Drawing.Size(28, 20)
        Me.btnConfigCaja.ForeColor = System.Drawing.Color.White
        Me.btnConfigCaja.Image = CType(resources.GetObject("btnConfigCaja.Image"), System.Drawing.Image)
        Me.btnConfigCaja.IsBackStageButton = False
        Me.btnConfigCaja.Location = New System.Drawing.Point(1, 0)
        Me.btnConfigCaja.Name = "btnConfigCaja"
        Me.btnConfigCaja.Size = New System.Drawing.Size(28, 20)
        Me.btnConfigCaja.TabIndex = 216
        Me.btnConfigCaja.UseVisualStyle = True
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnConfiguracion.BeforeTouchSize = New System.Drawing.Size(28, 20)
        Me.btnConfiguracion.ForeColor = System.Drawing.Color.White
        Me.btnConfiguracion.Image = CType(resources.GetObject("btnConfiguracion.Image"), System.Drawing.Image)
        Me.btnConfiguracion.IsBackStageButton = False
        Me.btnConfiguracion.Location = New System.Drawing.Point(28, 0)
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(28, 20)
        Me.btnConfiguracion.TabIndex = 211
        Me.btnConfiguracion.UseVisualStyle = True
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.lblPerido, Me.lblTitulo, Me.toolStripSeparator1, Me.lblIdDoc})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(878, 25)
        Me.ToolStrip3.TabIndex = 411
        Me.ToolStrip3.Text = "ToolStrip3"
        Me.ToolStrip3.Visible = False
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(111, 22)
        Me.GuardarToolStripButton.Text = "Confirmar venta"
        Me.GuardarToolStripButton.ToolTipText = "Confirmar venta"
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
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(57, 22)
        Me.lblTitulo.Text = "PERIODO:"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblIdDoc
        '
        Me.lblIdDoc.Name = "lblIdDoc"
        Me.lblIdDoc.Size = New System.Drawing.Size(19, 22)
        Me.lblIdDoc.Text = "00"
        Me.lblIdDoc.Visible = False
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
        'frmCajaTicket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.MediumOrchid
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(2, 4)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(37, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Caja interactiva - cobro de pedidos."
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(921, 716)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.DockingClientPanel1)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Name = "frmCajaTicket"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel4.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PopupControlContainer2.ResumeLayout(False)
        CType(Me.txtCajaOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTasaIgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIgvme, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteMn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDatos.ResumeLayout(False)
        Me.pnDatos.PerformLayout()
        CType(Me.txtAnticipoMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAnticipoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambioVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        CType(Me.txtVueltoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVueltoMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCobroMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIngresoMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCobroME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIngresoME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnVentas.ResumeLayout(False)
        Me.pnVentas.PerformLayout()
        CType(Me.txtFechaCobro.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaCobro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupControlContainer1.ResumeLayout(False)
        CType(Me.txtTipoDocVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnroVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpVSBehavior.ResumeLayout(False)
        Me.gpVSBehavior.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSeriePedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockingClientPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.pcProveedor.ResumeLayout(False)
        Me.pcProveedor.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        CType(Me.txtDocProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApePat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.rbJuridico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbNatural, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnImpresionTicket.ResumeLayout(False)
        Me.pnImpresionTicket.PerformLayout()
        CType(Me.txtVendedorN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCajaN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodMaqN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompradorN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.chCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnConfiguracion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents DockingClientPanel1 As Syncfusion.Windows.Forms.Tools.DockingClientPanel
    Private WithEvents gpVSBehavior As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtNumeroPedido As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtSeriePedido As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtMoneda As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtComprobante As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtNumeroVenta As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtSerieVenta As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtComprador As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtImporteME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtImporteMn As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtIgv As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblIdDoc As System.Windows.Forms.ToolStripLabel
    Friend WithEvents chCliente As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents btnConfigCaja As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Private WithEvents dropDownBtn As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents popupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvCliente As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents cancel As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents OK As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lsvDetalle As System.Windows.Forms.ListView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Private WithEvents PrintTikect As System.Drawing.Printing.PrintDocument
    Private WithEvents PrintPreviewDialogTicket As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents txtIgvme As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTasaIgv As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents pcProveedor As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents btnCarnetEx As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents btnDni As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents btnPassport As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents btnRuc As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Private WithEvents Panel14 As System.Windows.Forms.Panel
    Private WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtDocProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtApePat As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtNomProv As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbJuridico As Syncfusion.Windows.Forms.Tools.RadioButtonAdv
    Friend WithEvents rbNatural As Syncfusion.Windows.Forms.Tools.RadioButtonAdv
    Private WithEvents btnCancelarProv As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents btnGRabarProv As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtRuc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtnroVenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtSerVenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCliente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtTipoDocVenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents rbFactura As System.Windows.Forms.RadioButton
    Friend WithEvents rbBoleta As System.Windows.Forms.RadioButton
    Friend WithEvents txtFechaCobro As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnDatos As System.Windows.Forms.Panel
    Friend WithEvents lblVueltoME As System.Windows.Forms.Label
    Private WithEvents Panel8 As System.Windows.Forms.Panel
    Private WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtVueltoME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents lblVueltoMN As System.Windows.Forms.Label
    Friend WithEvents txtVueltoMN As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents lblReciboME As System.Windows.Forms.Label
    Friend WithEvents txtCobroMN As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents lblReciboMN As System.Windows.Forms.Label
    Friend WithEvents txtIngresoMN As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtCobroME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtIngresoME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents pnVentas As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambioVenta As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents DigitalGauge2 As Syncfusion.Windows.Forms.Gauge.DigitalGauge
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lblAnticipoME As System.Windows.Forms.Label
    Friend WithEvents lblAnticipoMN As System.Windows.Forms.Label
    Friend WithEvents txtAnticipoMN As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtAnticipoME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents rbSinAnticipo As System.Windows.Forms.RadioButton
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents rbConAnticipo As System.Windows.Forms.RadioButton
    Friend WithEvents pnImpresionTicket As System.Windows.Forms.Panel
    Private WithEvents Panel9 As System.Windows.Forms.Panel
    Private WithEvents Label26 As System.Windows.Forms.Label
    Private WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtVendedorN As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtCajaN As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCodMaqN As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCompradorN As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtFechaN As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtCajaOrigen As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents PopupControlContainer2 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvProveedor As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
End Class

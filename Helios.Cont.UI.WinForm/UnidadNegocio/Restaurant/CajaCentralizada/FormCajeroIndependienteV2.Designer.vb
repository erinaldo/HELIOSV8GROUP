Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCajeroIndependienteV2
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCajeroIndependienteV2))
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel9 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btOperacion = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolImportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolEditPedido = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolBuscarVenta = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolSeguimientoCaja = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolCerracaja = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextValoranticipo = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextPagoAnticipoDisponible = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chCobranzaParcial = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.chCredito = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.ChPagoAvanzado = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.chAutoNumeracion = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.PanelVendedorInfo = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ComboCaja = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckEfectivoDefault = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.TextNumIdentrazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextComprador = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextCodigoVendedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PanelCupon = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.TextCodigoCupon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCuponImporte = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LabelCupon = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtTotalIcbper = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextTotalDescuentos = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTotalBase = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalBase2 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalBase3 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalIva = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.lblTotalPercepcion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PanelMontos = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel19 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextSubTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtTotalPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPagoVenta = New System.Windows.Forms.Label()
        Me.LblPagoCredito = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ChBanco = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ChEfectivo = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.PanelLoadingWaith = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv7 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel10 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv8 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel11 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv9 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel12 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv10 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel13 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv11 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel14 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv12 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel15 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv13 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel16 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv14 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.GradientPanel17 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.GradientPanel18 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv15 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel20 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextTotalPagosCliente = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.LabelVueltoCliente = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.LabelTotalCobrarCliente = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        CType(Me.GradientPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel9.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TextValoranticipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPagoAnticipoDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelVendedorInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelVendedorInfo.SuspendLayout()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextComprador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelCupon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCupon.SuspendLayout()
        CType(Me.TextCodigoCupon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCuponImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.txtTotalIcbper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPercepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelMontos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMontos.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.GradientPanel19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel19.SuspendLayout()
        CType(Me.TextSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLoadingWaith.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.GradientPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel10.SuspendLayout()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel11.SuspendLayout()
        CType(Me.GradientPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel12.SuspendLayout()
        CType(Me.GradientPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel13.SuspendLayout()
        CType(Me.GradientPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel14.SuspendLayout()
        CType(Me.GradientPanel15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel15.SuspendLayout()
        CType(Me.GradientPanel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel16.SuspendLayout()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel17.SuspendLayout()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel18.SuspendLayout()
        CType(Me.GradientPanel20, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel20.SuspendLayout()
        CType(Me.TextTotalPagosCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel9
        '
        Me.GradientPanel9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel9.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel9.Controls.Add(Me.ToolStrip1)
        Me.GradientPanel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel9.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel9.Name = "GradientPanel9"
        Me.GradientPanel9.Size = New System.Drawing.Size(1109, 33)
        Me.GradientPanel9.TabIndex = 512
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btOperacion, Me.ToolStripSeparator2, Me.ToolStripLabel3, Me.ToolStripSeparator3, Me.ToolImportar, Me.ToolStripSeparator5, Me.ToolEditPedido, Me.ToolStripSeparator7, Me.ToolBuscarVenta, Me.ToolStripSeparator4, Me.ToolSeguimientoCaja, Me.ToolStripSeparator1, Me.ToolCerracaja, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1107, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btOperacion
        '
        Me.btOperacion.BackColor = System.Drawing.Color.Transparent
        Me.btOperacion.Enabled = False
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btOperacion.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btOperacion.Image = CType(resources.GetObject("btOperacion.Image"), System.Drawing.Image)
        Me.btOperacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btOperacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btOperacion.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(101, 28)
        Me.btOperacion.Text = "Guardar - F2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripLabel3.Image = CType(resources.GetObject("ToolStripLabel3.Image"), System.Drawing.Image)
        Me.ToolStripLabel3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(57, 28)
        Me.ToolStripLabel3.Text = "Cancelar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator3.Visible = False
        '
        'ToolImportar
        '
        Me.ToolImportar.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.ToolImportar.ForeColor = System.Drawing.Color.Black
        Me.ToolImportar.Image = CType(resources.GetObject("ToolImportar.Image"), System.Drawing.Image)
        Me.ToolImportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolImportar.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolImportar.Name = "ToolImportar"
        Me.ToolImportar.Size = New System.Drawing.Size(142, 28)
        Me.ToolImportar.Text = "Importar pedido - F7"
        Me.ToolImportar.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'ToolEditPedido
        '
        Me.ToolEditPedido.Enabled = False
        Me.ToolEditPedido.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.ToolEditPedido.ForeColor = System.Drawing.Color.Black
        Me.ToolEditPedido.Image = CType(resources.GetObject("ToolEditPedido.Image"), System.Drawing.Image)
        Me.ToolEditPedido.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolEditPedido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEditPedido.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolEditPedido.Name = "ToolEditPedido"
        Me.ToolEditPedido.Size = New System.Drawing.Size(106, 28)
        Me.ToolEditPedido.Text = "Editar pedido"
        Me.ToolEditPedido.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator7.Visible = False
        '
        'ToolBuscarVenta
        '
        Me.ToolBuscarVenta.Enabled = False
        Me.ToolBuscarVenta.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.ToolBuscarVenta.ForeColor = System.Drawing.Color.Black
        Me.ToolBuscarVenta.Image = CType(resources.GetObject("ToolBuscarVenta.Image"), System.Drawing.Image)
        Me.ToolBuscarVenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolBuscarVenta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBuscarVenta.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolBuscarVenta.Name = "ToolBuscarVenta"
        Me.ToolBuscarVenta.Size = New System.Drawing.Size(122, 28)
        Me.ToolBuscarVenta.Text = "Buscar venta - F8"
        Me.ToolBuscarVenta.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'ToolSeguimientoCaja
        '
        Me.ToolSeguimientoCaja.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.ToolSeguimientoCaja.ForeColor = System.Drawing.Color.Black
        Me.ToolSeguimientoCaja.Image = CType(resources.GetObject("ToolSeguimientoCaja.Image"), System.Drawing.Image)
        Me.ToolSeguimientoCaja.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolSeguimientoCaja.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSeguimientoCaja.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolSeguimientoCaja.Name = "ToolSeguimientoCaja"
        Me.ToolSeguimientoCaja.Size = New System.Drawing.Size(152, 28)
        Me.ToolSeguimientoCaja.Text = "Aperturas y cierres - F9"
        Me.ToolSeguimientoCaja.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator1.Visible = False
        '
        'ToolCerracaja
        '
        Me.ToolCerracaja.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.ToolCerracaja.ForeColor = System.Drawing.Color.Black
        Me.ToolCerracaja.Image = CType(resources.GetObject("ToolCerracaja.Image"), System.Drawing.Image)
        Me.ToolCerracaja.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolCerracaja.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCerracaja.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolCerracaja.Name = "ToolCerracaja"
        Me.ToolCerracaja.Size = New System.Drawing.Size(118, 28)
        Me.ToolCerracaja.Text = "Cerrar caja - F10"
        Me.ToolCerracaja.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator6.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 549
        Me.Label4.Text = "Anticipo"
        Me.Label4.Visible = False
        '
        'TextValoranticipo
        '
        Me.TextValoranticipo.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextValoranticipo.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextValoranticipo.BorderColor = System.Drawing.Color.Silver
        Me.TextValoranticipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValoranticipo.CornerRadius = 4
        Me.TextValoranticipo.CurrencySymbol = ""
        Me.TextValoranticipo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextValoranticipo.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValoranticipo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValoranticipo.ForeColor = System.Drawing.Color.Black
        Me.TextValoranticipo.Location = New System.Drawing.Point(102, 50)
        Me.TextValoranticipo.Metrocolor = System.Drawing.Color.Silver
        Me.TextValoranticipo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextValoranticipo.Name = "TextValoranticipo"
        Me.TextValoranticipo.NegativeColor = System.Drawing.Color.Silver
        Me.TextValoranticipo.NullString = ""
        Me.TextValoranticipo.PositiveColor = System.Drawing.Color.Black
        Me.TextValoranticipo.ReadOnlyBackColor = System.Drawing.Color.White
        Me.TextValoranticipo.Size = New System.Drawing.Size(81, 23)
        Me.TextValoranticipo.TabIndex = 552
        Me.TextValoranticipo.Text = "0.00"
        Me.TextValoranticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextPagoAnticipoDisponible
        '
        Me.TextPagoAnticipoDisponible.BackGroundColor = System.Drawing.Color.LightGray
        Me.TextPagoAnticipoDisponible.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextPagoAnticipoDisponible.BorderColor = System.Drawing.Color.Silver
        Me.TextPagoAnticipoDisponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPagoAnticipoDisponible.CornerRadius = 4
        Me.TextPagoAnticipoDisponible.CurrencySymbol = ""
        Me.TextPagoAnticipoDisponible.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPagoAnticipoDisponible.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextPagoAnticipoDisponible.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPagoAnticipoDisponible.ForeColor = System.Drawing.Color.Black
        Me.TextPagoAnticipoDisponible.Location = New System.Drawing.Point(15, 50)
        Me.TextPagoAnticipoDisponible.Metrocolor = System.Drawing.Color.Silver
        Me.TextPagoAnticipoDisponible.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPagoAnticipoDisponible.Name = "TextPagoAnticipoDisponible"
        Me.TextPagoAnticipoDisponible.NegativeColor = System.Drawing.Color.Silver
        Me.TextPagoAnticipoDisponible.NullString = ""
        Me.TextPagoAnticipoDisponible.PositiveColor = System.Drawing.Color.Black
        Me.TextPagoAnticipoDisponible.ReadOnly = True
        Me.TextPagoAnticipoDisponible.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.TextPagoAnticipoDisponible.Size = New System.Drawing.Size(81, 23)
        Me.TextPagoAnticipoDisponible.TabIndex = 550
        Me.TextPagoAnticipoDisponible.Text = "0.00"
        Me.TextPagoAnticipoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel1.Location = New System.Drawing.Point(188, 57)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(40, 13)
        Me.LinkLabel1.TabIndex = 551
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Buscar"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft JhengHei UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(614, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 19)
        Me.Label15.TabIndex = 545
        Me.Label15.Text = "Pedido Nro: 000"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(200, 105)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(178, 14)
        Me.Label18.TabIndex = 542
        Me.Label18.Text = "Otras formas de cobranza (Parcial)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(38, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 14)
        Me.Label16.TabIndex = 536
        Me.Label16.Text = "Venta al crédito (Total)"
        '
        'chCobranzaParcial
        '
        Me.chCobranzaParcial.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chCobranzaParcial.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chCobranzaParcial.Checked = False
        Me.chCobranzaParcial.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.chCobranzaParcial.ForeColor = System.Drawing.Color.White
        Me.chCobranzaParcial.Location = New System.Drawing.Point(179, 99)
        Me.chCobranzaParcial.Name = "chCobranzaParcial"
        Me.chCobranzaParcial.Size = New System.Drawing.Size(20, 20)
        Me.chCobranzaParcial.TabIndex = 541
        '
        'chCredito
        '
        Me.chCredito.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chCredito.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chCredito.Checked = False
        Me.chCredito.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.chCredito.Enabled = False
        Me.chCredito.ForeColor = System.Drawing.Color.White
        Me.chCredito.Location = New System.Drawing.Point(17, 63)
        Me.chCredito.Name = "chCredito"
        Me.chCredito.Size = New System.Drawing.Size(20, 20)
        Me.chCredito.TabIndex = 6
        '
        'ChPagoAvanzado
        '
        Me.ChPagoAvanzado.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChPagoAvanzado.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPagoAvanzado.Checked = True
        Me.ChPagoAvanzado.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChPagoAvanzado.Enabled = False
        Me.ChPagoAvanzado.ForeColor = System.Drawing.Color.White
        Me.ChPagoAvanzado.Location = New System.Drawing.Point(17, 35)
        Me.ChPagoAvanzado.Name = "ChPagoAvanzado"
        Me.ChPagoAvanzado.Size = New System.Drawing.Size(20, 20)
        Me.ChPagoAvanzado.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(38, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 14)
        Me.Label8.TabIndex = 532
        Me.Label8.Text = "Cobranza total o parcial"
        '
        'btnCliente
        '
        Me.btnCliente.BackColor = System.Drawing.Color.Transparent
        Me.btnCliente.BackgroundImage = CType(resources.GetObject("btnCliente.BackgroundImage"), System.Drawing.Image)
        Me.btnCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCliente.FlatAppearance.BorderSize = 0
        Me.btnCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCliente.Location = New System.Drawing.Point(295, 21)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(25, 25)
        Me.btnCliente.TabIndex = 540
        Me.ToolTip1.SetToolTip(Me.btnCliente, "Nuevo cliente")
        Me.btnCliente.UseVisualStyleBackColor = False
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(89, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Enabled = False
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERA"})
        Me.cboMoneda.Location = New System.Drawing.Point(203, 24)
        Me.cboMoneda.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(89, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 525
        Me.cboMoneda.Text = "NACIONAL"
        '
        'chAutoNumeracion
        '
        Me.chAutoNumeracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chAutoNumeracion.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chAutoNumeracion.Checked = False
        Me.chAutoNumeracion.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.chAutoNumeracion.ForeColor = System.Drawing.Color.White
        Me.chAutoNumeracion.Location = New System.Drawing.Point(228, 142)
        Me.chAutoNumeracion.Name = "chAutoNumeracion"
        Me.chAutoNumeracion.Size = New System.Drawing.Size(20, 20)
        Me.chAutoNumeracion.TabIndex = 519
        Me.chAutoNumeracion.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(131, 35)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 507
        Me.ProgressBar2.Visible = False
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.txtNumero.BorderColor = System.Drawing.Color.LightGray
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.CornerRadius = 4
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumero.Location = New System.Drawing.Point(104, 140)
        Me.txtNumero.Metrocolor = System.Drawing.Color.LightGray
        Me.txtNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(121, 22)
        Me.txtNumero.TabIndex = 2
        Me.txtNumero.Visible = False
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.txtSerie.BorderColor = System.Drawing.Color.LightGray
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.CornerRadius = 4
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtSerie.Location = New System.Drawing.Point(24, 140)
        Me.txtSerie.Metrocolor = System.Drawing.Color.LightGray
        Me.txtSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(76, 22)
        Me.txtSerie.TabIndex = 1
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(184, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(16, 24)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(184, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 0
        '
        'txtFecha
        '
        Me.txtFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.Checked = False
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecha.Enabled = False
        Me.txtFecha.EnableNullDate = False
        Me.txtFecha.EnableNullKeys = False
        Me.txtFecha.Font = New System.Drawing.Font("Calibri Light", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(407, -22)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(185, 21)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 50
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'PanelVendedorInfo
        '
        Me.PanelVendedorInfo.BackColor = System.Drawing.Color.Transparent
        Me.PanelVendedorInfo.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.PanelVendedorInfo.BorderColor = System.Drawing.Color.Silver
        Me.PanelVendedorInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelVendedorInfo.Controls.Add(Me.Label24)
        Me.PanelVendedorInfo.Controls.Add(Me.ComboCaja)
        Me.PanelVendedorInfo.Controls.Add(Me.GroupBox1)
        Me.PanelVendedorInfo.Controls.Add(Me.GroupBox5)
        Me.PanelVendedorInfo.Controls.Add(Me.GroupBox4)
        Me.PanelVendedorInfo.Controls.Add(Me.Label1)
        Me.PanelVendedorInfo.Controls.Add(Me.txtSerie)
        Me.PanelVendedorInfo.Controls.Add(Me.chAutoNumeracion)
        Me.PanelVendedorInfo.Controls.Add(Me.txtNumero)
        Me.PanelVendedorInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.PanelVendedorInfo.Location = New System.Drawing.Point(86, 105)
        Me.PanelVendedorInfo.Name = "PanelVendedorInfo"
        Me.PanelVendedorInfo.Size = New System.Drawing.Size(932, 115)
        Me.PanelVendedorInfo.TabIndex = 519
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(683, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 13)
        Me.Label24.TabIndex = 641
        Me.Label24.Text = "Cajas activas"
        Me.Label24.Visible = False
        '
        'ComboCaja
        '
        Me.ComboCaja.BackColor = System.Drawing.Color.White
        Me.ComboCaja.BeforeTouchSize = New System.Drawing.Size(207, 21)
        Me.ComboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCaja.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCaja.Location = New System.Drawing.Point(686, 30)
        Me.ComboCaja.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboCaja.Name = "ComboCaja"
        Me.ComboCaja.Size = New System.Drawing.Size(207, 21)
        Me.ComboCaja.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCaja.TabIndex = 640
        Me.ComboCaja.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextValoranticipo)
        Me.GroupBox1.Controls.Add(Me.CheckEfectivoDefault)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.TextPagoAnticipoDisponible)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(899, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(24, 63)
        Me.GroupBox1.TabIndex = 558
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pago con ancticipos"
        Me.GroupBox1.Visible = False
        '
        'CheckEfectivoDefault
        '
        Me.CheckEfectivoDefault.AutoSize = True
        Me.CheckEfectivoDefault.BackColor = System.Drawing.Color.White
        Me.CheckEfectivoDefault.Checked = True
        Me.CheckEfectivoDefault.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckEfectivoDefault.Enabled = False
        Me.CheckEfectivoDefault.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckEfectivoDefault.Location = New System.Drawing.Point(21, 78)
        Me.CheckEfectivoDefault.Name = "CheckEfectivoDefault"
        Me.CheckEfectivoDefault.Size = New System.Drawing.Size(165, 18)
        Me.CheckEfectivoDefault.TabIndex = 20
        Me.CheckEfectivoDefault.Text = "Cargar venta total a efectivo"
        Me.CheckEfectivoDefault.UseVisualStyleBackColor = False
        Me.CheckEfectivoDefault.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.ChPagoAvanzado)
        Me.GroupBox5.Controls.Add(Me.chCobranzaParcial)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.chCredito)
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox5.Location = New System.Drawing.Point(483, 5)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(189, 100)
        Me.GroupBox5.TabIndex = 557
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos del pago"
        Me.GroupBox5.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.RadioButton1)
        Me.GroupBox4.Controls.Add(Me.RadioButton2)
        Me.GroupBox4.Controls.Add(Me.PictureLoad)
        Me.GroupBox4.Controls.Add(Me.TextNumIdentrazon)
        Me.GroupBox4.Controls.Add(Me.TextProveedor)
        Me.GroupBox4.Controls.Add(Me.cboTipoDoc)
        Me.GroupBox4.Controls.Add(Me.txtFecha)
        Me.GroupBox4.Controls.Add(Me.cboMoneda)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.ProgressBar2)
        Me.GroupBox4.Controls.Add(Me.btnCliente)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox4.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(470, 100)
        Me.GroupBox4.TabIndex = 556
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del comprobante de venta"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(442, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 690
        Me.ToolTip1.SetToolTip(Me.Button1, "Editar cliente")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.RadioButton1.Location = New System.Drawing.Point(327, 30)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton1.TabIndex = 688
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Cliente"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.RadioButton2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.RadioButton2.Location = New System.Drawing.Point(396, 30)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(56, 17)
        Me.RadioButton2.TabIndex = 689
        Me.RadioButton2.Text = "Varios"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.White
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(129, 71)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 687
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'TextNumIdentrazon
        '
        Me.TextNumIdentrazon.BackColor = System.Drawing.SystemColors.Info
        BannerTextInfo1.Text = "Buscar x nrodoc. ..."
        Me.BannerTextProvider1.SetBannerText(Me.TextNumIdentrazon, BannerTextInfo1)
        Me.TextNumIdentrazon.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextNumIdentrazon.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumIdentrazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIdentrazon.CornerRadius = 3
        Me.TextNumIdentrazon.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNumIdentrazon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIdentrazon.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNumIdentrazon.Location = New System.Drawing.Point(16, 71)
        Me.TextNumIdentrazon.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumIdentrazon.Name = "TextNumIdentrazon"
        Me.TextNumIdentrazon.Size = New System.Drawing.Size(112, 23)
        Me.TextNumIdentrazon.TabIndex = 685
        '
        'TextProveedor
        '
        Me.TextProveedor.BackColor = System.Drawing.Color.White
        Me.TextProveedor.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProveedor.CornerRadius = 3
        Me.TextProveedor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextProveedor.Enabled = False
        Me.TextProveedor.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextProveedor.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextProveedor.Location = New System.Drawing.Point(129, 71)
        Me.TextProveedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.Size = New System.Drawing.Size(310, 22)
        Me.TextProveedor.TabIndex = 686
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 547
        Me.Label2.Text = "Cliente/Razón social"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 555
        Me.Label1.Text = "Número"
        '
        'TextComprador
        '
        Me.TextComprador.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextComprador.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextComprador.BorderColor = System.Drawing.Color.Silver
        Me.TextComprador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextComprador.CornerRadius = 5
        Me.TextComprador.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextComprador.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextComprador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextComprador.Location = New System.Drawing.Point(295, 24)
        Me.TextComprador.MaxLength = 100
        Me.TextComprador.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextComprador.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextComprador.Name = "TextComprador"
        Me.TextComprador.NearImage = CType(resources.GetObject("TextComprador.NearImage"), System.Drawing.Image)
        Me.TextComprador.ReadOnly = True
        Me.TextComprador.Size = New System.Drawing.Size(264, 23)
        Me.TextComprador.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(293, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Comprador:"
        '
        'TextCodigoVendedor
        '
        Me.TextCodigoVendedor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextCodigoVendedor.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextCodigoVendedor.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoVendedor.CornerRadius = 5
        Me.TextCodigoVendedor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigoVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoVendedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoVendedor.Location = New System.Drawing.Point(17, 24)
        Me.TextCodigoVendedor.MaxLength = 100
        Me.TextCodigoVendedor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextCodigoVendedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoVendedor.Name = "TextCodigoVendedor"
        Me.TextCodigoVendedor.NearImage = CType(resources.GetObject("TextCodigoVendedor.NearImage"), System.Drawing.Image)
        Me.TextCodigoVendedor.ReadOnly = True
        Me.TextCodigoVendedor.Size = New System.Drawing.Size(273, 23)
        Me.TextCodigoVendedor.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Vendedor"
        '
        'PanelCupon
        '
        Me.PanelCupon.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelCupon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelCupon.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.PanelCupon.BorderColor = System.Drawing.Color.Silver
        Me.PanelCupon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelCupon.Controls.Add(Me.ButtonAdv5)
        Me.PanelCupon.Controls.Add(Me.TextCodigoCupon)
        Me.PanelCupon.Controls.Add(Me.TextCuponImporte)
        Me.PanelCupon.Controls.Add(Me.ButtonAdv4)
        Me.PanelCupon.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelCupon.Location = New System.Drawing.Point(1198, 434)
        Me.PanelCupon.Name = "PanelCupon"
        Me.PanelCupon.Size = New System.Drawing.Size(340, 55)
        Me.PanelCupon.TabIndex = 517
        Me.PanelCupon.Visible = False
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.White
        Me.ButtonAdv5.BackgroundImage = CType(resources.GetObject("ButtonAdv5.BackgroundImage"), System.Drawing.Image)
        Me.ButtonAdv5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(28, 28)
        Me.ButtonAdv5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(295, 12)
        Me.ButtonAdv5.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(28, 28)
        Me.ButtonAdv5.TabIndex = 529
        Me.ButtonAdv5.UseVisualStyle = True
        Me.ButtonAdv5.Visible = False
        '
        'TextCodigoCupon
        '
        Me.TextCodigoCupon.BackColor = System.Drawing.Color.White
        Me.TextCodigoCupon.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextCodigoCupon.BorderColor = System.Drawing.Color.LightGray
        Me.TextCodigoCupon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoCupon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoCupon.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoCupon.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoCupon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoCupon.Location = New System.Drawing.Point(8, 14)
        Me.TextCodigoCupon.Metrocolor = System.Drawing.Color.LightGray
        Me.TextCodigoCupon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoCupon.Name = "TextCodigoCupon"
        Me.TextCodigoCupon.NearImage = CType(resources.GetObject("TextCodigoCupon.NearImage"), System.Drawing.Image)
        Me.TextCodigoCupon.Size = New System.Drawing.Size(171, 24)
        Me.TextCodigoCupon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoCupon.TabIndex = 528
        Me.TextCodigoCupon.Visible = False
        '
        'TextCuponImporte
        '
        Me.TextCuponImporte.BackGroundColor = System.Drawing.Color.White
        Me.TextCuponImporte.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextCuponImporte.BorderColor = System.Drawing.Color.Silver
        Me.TextCuponImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCuponImporte.CurrencySymbol = ""
        Me.TextCuponImporte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCuponImporte.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextCuponImporte.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCuponImporte.ForeColor = System.Drawing.Color.Black
        Me.TextCuponImporte.Location = New System.Drawing.Point(182, 13)
        Me.TextCuponImporte.Metrocolor = System.Drawing.Color.Silver
        Me.TextCuponImporte.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCuponImporte.Name = "TextCuponImporte"
        Me.TextCuponImporte.NegativeColor = System.Drawing.Color.Silver
        Me.TextCuponImporte.NullString = ""
        Me.TextCuponImporte.PositiveColor = System.Drawing.Color.Black
        Me.TextCuponImporte.ReadOnly = True
        Me.TextCuponImporte.ReadOnlyBackColor = System.Drawing.Color.White
        Me.TextCuponImporte.Size = New System.Drawing.Size(55, 25)
        Me.TextCuponImporte.TabIndex = 527
        Me.TextCuponImporte.Text = "0.00"
        Me.TextCuponImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(53, 25)
        Me.ButtonAdv4.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(240, 13)
        Me.ButtonAdv4.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(53, 25)
        Me.ButtonAdv4.TabIndex = 526
        Me.ButtonAdv4.Text = ". Cupon ."
        Me.ButtonAdv4.UseVisualStyle = True
        Me.ButtonAdv4.Visible = False
        '
        'GradientPanel7
        '
        Me.GradientPanel7.BackColor = System.Drawing.Color.Honeydew
        Me.GradientPanel7.BackgroundImage = CType(resources.GetObject("GradientPanel7.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel7.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel7.BorderColor = System.Drawing.Color.Gray
        Me.GradientPanel7.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel7.Controls.Add(Me.LabelCupon)
        Me.GradientPanel7.Controls.Add(Me.Label20)
        Me.GradientPanel7.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel7.Location = New System.Drawing.Point(1198, 492)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(340, 55)
        Me.GradientPanel7.TabIndex = 516
        Me.GradientPanel7.Visible = False
        '
        'LabelCupon
        '
        Me.LabelCupon.AutoSize = True
        Me.LabelCupon.BackColor = System.Drawing.Color.Transparent
        Me.LabelCupon.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCupon.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelCupon.Location = New System.Drawing.Point(14, 27)
        Me.LabelCupon.Name = "LabelCupon"
        Me.LabelCupon.Size = New System.Drawing.Size(127, 20)
        Me.LabelCupon.TabIndex = 531
        Me.LabelCupon.Text = "CPN-000-000-000"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(11, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(213, 13)
        Me.Label20.TabIndex = 530
        Me.Label20.Text = "Cupón de dscto. ganado por su compra"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.GradientPanel3.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.Label27)
        Me.GradientPanel3.Controls.Add(Me.txtTotalIcbper)
        Me.GradientPanel3.Controls.Add(Me.TextTotalDescuentos)
        Me.GradientPanel3.Controls.Add(Me.Label19)
        Me.GradientPanel3.Controls.Add(Me.txtTotalBase)
        Me.GradientPanel3.Controls.Add(Me.txtTotalBase2)
        Me.GradientPanel3.Controls.Add(Me.Label11)
        Me.GradientPanel3.Controls.Add(Me.Label14)
        Me.GradientPanel3.Controls.Add(Me.txtTotalBase3)
        Me.GradientPanel3.Controls.Add(Me.txtTotalIva)
        Me.GradientPanel3.Controls.Add(Me.lblTotalPercepcion)
        Me.GradientPanel3.Controls.Add(Me.Label10)
        Me.GradientPanel3.Controls.Add(Me.Label22)
        Me.GradientPanel3.Controls.Add(Me.Label12)
        Me.GradientPanel3.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel3.Location = New System.Drawing.Point(86, 519)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(932, 48)
        Me.GradientPanel3.TabIndex = 515
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(486, 6)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 13)
        Me.Label27.TabIndex = 551
        Me.Label27.Text = "ICBPER"
        '
        'txtTotalIcbper
        '
        Me.txtTotalIcbper.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIcbper.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.txtTotalIcbper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIcbper.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalIcbper.CornerRadius = 5
        Me.txtTotalIcbper.CurrencySymbol = ""
        Me.txtTotalIcbper.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalIcbper.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIcbper.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIcbper.ForeColor = System.Drawing.Color.White
        Me.txtTotalIcbper.Location = New System.Drawing.Point(535, 6)
        Me.txtTotalIcbper.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIcbper.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalIcbper.Name = "txtTotalIcbper"
        Me.txtTotalIcbper.NullString = ""
        Me.txtTotalIcbper.PositiveColor = System.Drawing.Color.White
        Me.txtTotalIcbper.ReadOnly = True
        Me.txtTotalIcbper.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtTotalIcbper.Size = New System.Drawing.Size(104, 15)
        Me.txtTotalIcbper.TabIndex = 552
        Me.txtTotalIcbper.Text = "0.00"
        Me.txtTotalIcbper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextTotalDescuentos
        '
        Me.TextTotalDescuentos.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.TextTotalDescuentos.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextTotalDescuentos.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextTotalDescuentos.CornerRadius = 5
        Me.TextTotalDescuentos.CurrencySymbol = ""
        Me.TextTotalDescuentos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTotalDescuentos.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextTotalDescuentos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalDescuentos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.TextTotalDescuentos.Location = New System.Drawing.Point(766, 26)
        Me.TextTotalDescuentos.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTotalDescuentos.Name = "TextTotalDescuentos"
        Me.TextTotalDescuentos.NullString = ""
        Me.TextTotalDescuentos.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.TextTotalDescuentos.ReadOnly = True
        Me.TextTotalDescuentos.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextTotalDescuentos.Size = New System.Drawing.Size(104, 15)
        Me.TextTotalDescuentos.TabIndex = 500
        Me.TextTotalDescuentos.Text = "0.00"
        Me.TextTotalDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(684, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 499
        Me.Label19.Text = "Descuentos"
        '
        'txtTotalBase
        '
        Me.txtTotalBase.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalBase.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.txtTotalBase.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase.CornerRadius = 5
        Me.txtTotalBase.CurrencySymbol = ""
        Me.txtTotalBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase.ForeColor = System.Drawing.Color.White
        Me.txtTotalBase.Location = New System.Drawing.Point(103, 6)
        Me.txtTotalBase.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase.Name = "txtTotalBase"
        Me.txtTotalBase.NullString = ""
        Me.txtTotalBase.PositiveColor = System.Drawing.Color.White
        Me.txtTotalBase.ReadOnly = True
        Me.txtTotalBase.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtTotalBase.Size = New System.Drawing.Size(104, 15)
        Me.txtTotalBase.TabIndex = 494
        Me.txtTotalBase.Text = "0.00"
        Me.txtTotalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBase2
        '
        Me.txtTotalBase2.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalBase2.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.txtTotalBase2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase2.CornerRadius = 5
        Me.txtTotalBase2.CurrencySymbol = ""
        Me.txtTotalBase2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase2.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase2.ForeColor = System.Drawing.Color.White
        Me.txtTotalBase2.Location = New System.Drawing.Point(103, 26)
        Me.txtTotalBase2.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase2.Name = "txtTotalBase2"
        Me.txtTotalBase2.NullString = ""
        Me.txtTotalBase2.PositiveColor = System.Drawing.Color.White
        Me.txtTotalBase2.ReadOnly = True
        Me.txtTotalBase2.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtTotalBase2.Size = New System.Drawing.Size(104, 15)
        Me.txtTotalBase2.TabIndex = 492
        Me.txtTotalBase2.Text = "0.00"
        Me.txtTotalBase2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(17, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Op. Exonerada"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(17, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Op. Gravada"
        '
        'txtTotalBase3
        '
        Me.txtTotalBase3.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase3.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.txtTotalBase3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase3.CornerRadius = 5
        Me.txtTotalBase3.CurrencySymbol = ""
        Me.txtTotalBase3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase3.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase3.ForeColor = System.Drawing.Color.White
        Me.txtTotalBase3.Location = New System.Drawing.Point(339, 6)
        Me.txtTotalBase3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase3.Name = "txtTotalBase3"
        Me.txtTotalBase3.NullString = ""
        Me.txtTotalBase3.PositiveColor = System.Drawing.Color.White
        Me.txtTotalBase3.ReadOnly = True
        Me.txtTotalBase3.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtTotalBase3.Size = New System.Drawing.Size(104, 15)
        Me.txtTotalBase3.TabIndex = 498
        Me.txtTotalBase3.Text = "0.00"
        Me.txtTotalBase3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIva.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.txtTotalIva.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalIva.CornerRadius = 5
        Me.txtTotalIva.CurrencySymbol = ""
        Me.txtTotalIva.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalIva.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIva.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.ForeColor = System.Drawing.Color.White
        Me.txtTotalIva.Location = New System.Drawing.Point(339, 28)
        Me.txtTotalIva.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.NullString = ""
        Me.txtTotalIva.PositiveColor = System.Drawing.Color.White
        Me.txtTotalIva.ReadOnly = True
        Me.txtTotalIva.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtTotalIva.Size = New System.Drawing.Size(104, 15)
        Me.txtTotalIva.TabIndex = 493
        Me.txtTotalIva.Text = "0.00"
        Me.txtTotalIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalPercepcion
        '
        Me.lblTotalPercepcion.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.lblTotalPercepcion.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.lblTotalPercepcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPercepcion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblTotalPercepcion.CornerRadius = 5
        Me.lblTotalPercepcion.CurrencySymbol = ""
        Me.lblTotalPercepcion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalPercepcion.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.lblTotalPercepcion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPercepcion.ForeColor = System.Drawing.Color.White
        Me.lblTotalPercepcion.Location = New System.Drawing.Point(766, 6)
        Me.lblTotalPercepcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPercepcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.lblTotalPercepcion.Name = "lblTotalPercepcion"
        Me.lblTotalPercepcion.NullString = ""
        Me.lblTotalPercepcion.PositiveColor = System.Drawing.Color.White
        Me.lblTotalPercepcion.ReadOnly = True
        Me.lblTotalPercepcion.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.lblTotalPercepcion.Size = New System.Drawing.Size(104, 15)
        Me.lblTotalPercepcion.TabIndex = 496
        Me.lblTotalPercepcion.Text = "0.00"
        Me.lblTotalPercepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(263, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 497
        Me.Label10.Text = "Op. Inafecta"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(683, 6)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 495
        Me.Label22.Text = "Rendondeo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(263, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "IGV"
        '
        'PanelMontos
        '
        Me.PanelMontos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelMontos.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.PanelMontos.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.PanelMontos.BorderColor = System.Drawing.Color.Silver
        Me.PanelMontos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelMontos.Controls.Add(Me.GradientPanel5)
        Me.PanelMontos.Controls.Add(Me.ButtonAdv2)
        Me.PanelMontos.Controls.Add(Me.ButtonAdv3)
        Me.PanelMontos.Controls.Add(Me.GradientPanel4)
        Me.PanelMontos.Controls.Add(Me.LblPagoCredito)
        Me.PanelMontos.Controls.Add(Me.Label21)
        Me.PanelMontos.Controls.Add(Me.ChBanco)
        Me.PanelMontos.Controls.Add(Me.Label23)
        Me.PanelMontos.Controls.Add(Me.ChEfectivo)
        Me.PanelMontos.Controls.Add(Me.pcLikeCategoria)
        Me.PanelMontos.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelMontos.Location = New System.Drawing.Point(86, 224)
        Me.PanelMontos.Name = "PanelMontos"
        Me.PanelMontos.Size = New System.Drawing.Size(932, 245)
        Me.PanelMontos.TabIndex = 514
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel5.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel5.Controls.Add(Me.GradientPanel19)
        Me.GradientPanel5.Controls.Add(Me.GradientPanel6)
        Me.GradientPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel5.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(930, 63)
        Me.GradientPanel5.TabIndex = 405
        '
        'GradientPanel19
        '
        Me.GradientPanel19.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.GradientPanel19.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel19.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel19.Controls.Add(Me.TextSubTotal)
        Me.GradientPanel19.Controls.Add(Me.Label26)
        Me.GradientPanel19.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel19.Location = New System.Drawing.Point(0, -1)
        Me.GradientPanel19.Name = "GradientPanel19"
        Me.GradientPanel19.Size = New System.Drawing.Size(930, 32)
        Me.GradientPanel19.TabIndex = 223
        '
        'TextSubTotal
        '
        Me.TextSubTotal.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.TextSubTotal.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextSubTotal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextSubTotal.CornerRadius = 5
        Me.TextSubTotal.CurrencySymbol = ""
        Me.TextSubTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextSubTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextSubTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.TextSubTotal.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSubTotal.ForeColor = System.Drawing.Color.White
        Me.TextSubTotal.Location = New System.Drawing.Point(787, 0)
        Me.TextSubTotal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextSubTotal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextSubTotal.Name = "TextSubTotal"
        Me.TextSubTotal.NullString = ""
        Me.TextSubTotal.PositiveColor = System.Drawing.Color.White
        Me.TextSubTotal.ReadOnly = True
        Me.TextSubTotal.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.TextSubTotal.Size = New System.Drawing.Size(141, 25)
        Me.TextSubTotal.TabIndex = 495
        Me.TextSubTotal.Text = "0.00"
        Me.TextSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(13, 10)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 15)
        Me.Label26.TabIndex = 7
        Me.Label26.Text = "SUB TOTAL "
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.GradientPanel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel6.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Controls.Add(Me.txtTotalPagar)
        Me.GradientPanel6.Controls.Add(Me.Label13)
        Me.GradientPanel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel6.Location = New System.Drawing.Point(0, 31)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(930, 32)
        Me.GradientPanel6.TabIndex = 222
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.txtTotalPagar.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.txtTotalPagar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalPagar.CornerRadius = 5
        Me.txtTotalPagar.CurrencySymbol = ""
        Me.txtTotalPagar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPagar.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtTotalPagar.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.White
        Me.txtTotalPagar.Location = New System.Drawing.Point(787, 0)
        Me.txtTotalPagar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.NullString = ""
        Me.txtTotalPagar.PositiveColor = System.Drawing.Color.White
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.txtTotalPagar.Size = New System.Drawing.Size(141, 25)
        Me.txtTotalPagar.TabIndex = 495
        Me.txtTotalPagar.Text = "0.00"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(13, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 15)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "TOTAL A PAGAR"
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(25, 25)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.Image = CType(resources.GetObject("ButtonAdv2.Image"), System.Drawing.Image)
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(628, 6)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(25, 25)
        Me.ButtonAdv2.TabIndex = 526
        Me.ButtonAdv2.UseVisualStyle = True
        Me.ButtonAdv2.Visible = False
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(25, 25)
        Me.ButtonAdv3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.Image = CType(resources.GetObject("ButtonAdv3.Image"), System.Drawing.Image)
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(601, 6)
        Me.ButtonAdv3.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(25, 25)
        Me.ButtonAdv3.TabIndex = 525
        Me.ButtonAdv3.UseVisualStyle = True
        Me.ButtonAdv3.Visible = False
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel4.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.dgvCuentas)
        Me.GradientPanel4.Controls.Add(Me.Panel1)
        Me.GradientPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel4.Location = New System.Drawing.Point(0, 63)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(930, 180)
        Me.GradientPanel4.TabIndex = 523
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCuentas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 27)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvCuentas.Size = New System.Drawing.Size(928, 151)
        Me.dgvCuentas.TabIndex = 426
        Me.dgvCuentas.TableDescriptor.AllowNew = False
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Size = 12.0!
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCuentas.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCuentas.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LavenderBlush)
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        GridColumnDescriptor1.MappingName = "tipo"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor2.MappingName = "identidad"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 19
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.Error = "Object reference not set to an instance of an object."
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor3.HeaderText = "Cuenta"
        GridColumnDescriptor3.MappingName = "entidad"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 190
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.SystemColors.HotTrack
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer)))
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.TextAlign = Syncfusion.Windows.Forms.Grid.GridTextAlign.Right
        GridColumnDescriptor4.HeaderText = "Abono"
        GridColumnDescriptor4.MappingName = "abonado"
        GridColumnDescriptor4.Width = 150
        GridColumnDescriptor5.HeaderText = "T/C"
        GridColumnDescriptor5.MappingName = "tipocambio"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 50
        GridColumnDescriptor6.MappingName = "idforma"
        GridColumnDescriptor6.Width = 20
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Error = "Object reference not set to an instance of an object."
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor7.HeaderText = "Forma de Pago"
        GridColumnDescriptor7.MappingName = "formaPago"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.Width = 190
        GridColumnDescriptor8.HeaderText = "N°Op"
        GridColumnDescriptor8.MappingName = "nrooperacion"
        GridColumnDescriptor8.Width = 70
        Me.dgvCuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CellType = "TextBox"
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.GradientInactiveCaption)
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.Font.Bold = True
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.Font.Size = 12.0!
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryColumnDescriptor1.DataMember = "abonado"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "abonado"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1})
        GridSummaryRowDescriptor1.Title = "Total pagos: "
        Me.dgvCuentas.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.dgvCuentas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 22
        Me.dgvCuentas.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvCuentas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("formaPago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("abonado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nrooperacion")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.UseRightToLeftCompatibleTextBox = True
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblPagoVenta)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(928, 27)
        Me.Panel1.TabIndex = 535
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Firebrick
        Me.Label3.Location = New System.Drawing.Point(13, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 15)
        Me.Label3.TabIndex = 535
        Me.Label3.Text = "SALDO POR PAGAR"
        '
        'lblPagoVenta
        '
        Me.lblPagoVenta.BackColor = System.Drawing.Color.Transparent
        Me.lblPagoVenta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPagoVenta.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.lblPagoVenta.Location = New System.Drawing.Point(661, 0)
        Me.lblPagoVenta.Name = "lblPagoVenta"
        Me.lblPagoVenta.Size = New System.Drawing.Size(267, 27)
        Me.lblPagoVenta.TabIndex = 534
        Me.lblPagoVenta.Text = "0.00"
        Me.lblPagoVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPagoVenta.Visible = False
        '
        'LblPagoCredito
        '
        Me.LblPagoCredito.AutoSize = True
        Me.LblPagoCredito.BackColor = System.Drawing.Color.Transparent
        Me.LblPagoCredito.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPagoCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.LblPagoCredito.Location = New System.Drawing.Point(107, 45)
        Me.LblPagoCredito.Name = "LblPagoCredito"
        Me.LblPagoCredito.Size = New System.Drawing.Size(254, 37)
        Me.LblPagoCredito.TabIndex = 533
        Me.LblPagoCredito.Text = "VENTA AL CREDITO"
        Me.LblPagoCredito.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(596, 345)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 17)
        Me.Label21.TabIndex = 520
        Me.Label21.Text = "Banco"
        '
        'ChBanco
        '
        Me.ChBanco.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChBanco.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChBanco.Checked = False
        Me.ChBanco.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChBanco.ForeColor = System.Drawing.Color.White
        Me.ChBanco.Location = New System.Drawing.Point(573, 344)
        Me.ChBanco.Name = "ChBanco"
        Me.ChBanco.Size = New System.Drawing.Size(20, 20)
        Me.ChBanco.TabIndex = 519
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(508, 345)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 17)
        Me.Label23.TabIndex = 518
        Me.Label23.Text = "Efectivo"
        '
        'ChEfectivo
        '
        Me.ChEfectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChEfectivo.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChEfectivo.Checked = False
        Me.ChEfectivo.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChEfectivo.ForeColor = System.Drawing.Color.White
        Me.ChEfectivo.Location = New System.Drawing.Point(485, 344)
        Me.ChEfectivo.Name = "ChEfectivo"
        Me.ChEfectivo.Size = New System.Drawing.Size(20, 20)
        Me.ChEfectivo.TabIndex = 517
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(8, 92)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 518
        '
        'LsvProveedor
        '
        Me.LsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colCliente, Me.colRUC, Me.colTipoDoc})
        Me.LsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProveedor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LsvProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.LsvProveedor.FullRowSelect = True
        Me.LsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LsvProveedor.HideSelection = False
        Me.LsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.LsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.LsvProveedor.MultiSelect = False
        Me.LsvProveedor.Name = "LsvProveedor"
        Me.LsvProveedor.Size = New System.Drawing.Size(282, 128)
        Me.LsvProveedor.TabIndex = 1
        Me.LsvProveedor.UseCompatibleStateImageBehavior = False
        Me.LsvProveedor.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 219
        '
        'colRUC
        '
        Me.colRUC.Text = "RUC"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PanelLoadingWaith
        '
        Me.PanelLoadingWaith.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelLoadingWaith.Controls.Add(Me.Label6)
        Me.PanelLoadingWaith.Location = New System.Drawing.Point(84, 407)
        Me.PanelLoadingWaith.Name = "PanelLoadingWaith"
        Me.PanelLoadingWaith.Size = New System.Drawing.Size(936, 38)
        Me.PanelLoadingWaith.TabIndex = 520
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri Light", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(420, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 24)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Venta . . ."
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel2.Location = New System.Drawing.Point(2, 103)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(78, 56)
        Me.GradientPanel2.TabIndex = 521
        Me.GradientPanel2.Visible = False
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(76, 54)
        Me.ButtonAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(76, 54)
        Me.ButtonAdv1.TabIndex = 53
        Me.ButtonAdv1.Text = "RECEPCION ANTICIPO"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv6)
        Me.GradientPanel1.Enabled = False
        Me.GradientPanel1.Location = New System.Drawing.Point(2, 163)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(77, 56)
        Me.GradientPanel1.TabIndex = 522
        Me.GradientPanel1.Visible = False
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(75, 54)
        Me.ButtonAdv6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv6.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(75, 54)
        Me.ButtonAdv6.TabIndex = 53
        Me.ButtonAdv6.Text = "GARANTIA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RECEPCION"
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.ButtonAdv7)
        Me.GradientPanel8.Location = New System.Drawing.Point(2, 224)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(78, 56)
        Me.GradientPanel8.TabIndex = 523
        Me.GradientPanel8.Visible = False
        '
        'ButtonAdv7
        '
        Me.ButtonAdv7.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv7.BeforeTouchSize = New System.Drawing.Size(76, 54)
        Me.ButtonAdv7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv7.IsBackStageButton = False
        Me.ButtonAdv7.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv7.Name = "ButtonAdv7"
        Me.ButtonAdv7.Size = New System.Drawing.Size(76, 54)
        Me.ButtonAdv7.TabIndex = 53
        Me.ButtonAdv7.Text = "CUENTAS X COBRAR"
        Me.ButtonAdv7.UseVisualStyle = True
        '
        'GradientPanel10
        '
        Me.GradientPanel10.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel10.Controls.Add(Me.ButtonAdv8)
        Me.GradientPanel10.Location = New System.Drawing.Point(2, 285)
        Me.GradientPanel10.Name = "GradientPanel10"
        Me.GradientPanel10.Size = New System.Drawing.Size(78, 56)
        Me.GradientPanel10.TabIndex = 524
        Me.GradientPanel10.Visible = False
        '
        'ButtonAdv8
        '
        Me.ButtonAdv8.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv8.BeforeTouchSize = New System.Drawing.Size(76, 54)
        Me.ButtonAdv8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv8.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv8.IsBackStageButton = False
        Me.ButtonAdv8.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv8.Name = "ButtonAdv8"
        Me.ButtonAdv8.Size = New System.Drawing.Size(76, 54)
        Me.ButtonAdv8.TabIndex = 53
        Me.ButtonAdv8.Text = "N. CRED." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PARA ANTICIPOS"
        Me.ButtonAdv8.UseVisualStyle = True
        '
        'GradientPanel11
        '
        Me.GradientPanel11.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel11.Controls.Add(Me.ButtonAdv9)
        Me.GradientPanel11.Location = New System.Drawing.Point(2, 345)
        Me.GradientPanel11.Name = "GradientPanel11"
        Me.GradientPanel11.Size = New System.Drawing.Size(78, 56)
        Me.GradientPanel11.TabIndex = 525
        Me.GradientPanel11.Visible = False
        '
        'ButtonAdv9
        '
        Me.ButtonAdv9.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv9.BeforeTouchSize = New System.Drawing.Size(76, 54)
        Me.ButtonAdv9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv9.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv9.IsBackStageButton = False
        Me.ButtonAdv9.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv9.Name = "ButtonAdv9"
        Me.ButtonAdv9.Size = New System.Drawing.Size(76, 54)
        Me.ButtonAdv9.TabIndex = 53
        Me.ButtonAdv9.Text = "N. CRED." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "POR DEV.VENTA"
        Me.ButtonAdv9.UseVisualStyle = True
        '
        'GradientPanel12
        '
        Me.GradientPanel12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel12.BorderColor = System.Drawing.Color.LightCoral
        Me.GradientPanel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel12.Controls.Add(Me.ButtonAdv10)
        Me.GradientPanel12.Location = New System.Drawing.Point(1027, 347)
        Me.GradientPanel12.Name = "GradientPanel12"
        Me.GradientPanel12.Size = New System.Drawing.Size(78, 56)
        Me.GradientPanel12.TabIndex = 530
        Me.GradientPanel12.Visible = False
        '
        'ButtonAdv10
        '
        Me.ButtonAdv10.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv10.BeforeTouchSize = New System.Drawing.Size(76, 54)
        Me.ButtonAdv10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv10.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv10.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv10.IsBackStageButton = False
        Me.ButtonAdv10.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv10.Name = "ButtonAdv10"
        Me.ButtonAdv10.Size = New System.Drawing.Size(76, 54)
        Me.ButtonAdv10.TabIndex = 53
        Me.ButtonAdv10.Text = "CUENTAS X PAGAR"
        Me.ButtonAdv10.UseVisualStyle = True
        '
        'GradientPanel13
        '
        Me.GradientPanel13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel13.BorderColor = System.Drawing.Color.LightCoral
        Me.GradientPanel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel13.Controls.Add(Me.ButtonAdv11)
        Me.GradientPanel13.Location = New System.Drawing.Point(1027, 287)
        Me.GradientPanel13.Name = "GradientPanel13"
        Me.GradientPanel13.Size = New System.Drawing.Size(78, 56)
        Me.GradientPanel13.TabIndex = 529
        Me.GradientPanel13.Visible = False
        '
        'ButtonAdv11
        '
        Me.ButtonAdv11.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv11.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv11.BeforeTouchSize = New System.Drawing.Size(76, 54)
        Me.ButtonAdv11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv11.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv11.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv11.IsBackStageButton = False
        Me.ButtonAdv11.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv11.Name = "ButtonAdv11"
        Me.ButtonAdv11.Size = New System.Drawing.Size(76, 54)
        Me.ButtonAdv11.TabIndex = 53
        Me.ButtonAdv11.Text = "RECLAM. X COBRAR"
        Me.ButtonAdv11.UseVisualStyle = True
        '
        'GradientPanel14
        '
        Me.GradientPanel14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel14.BorderColor = System.Drawing.Color.LightCoral
        Me.GradientPanel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel14.Controls.Add(Me.ButtonAdv12)
        Me.GradientPanel14.Location = New System.Drawing.Point(1027, 226)
        Me.GradientPanel14.Name = "GradientPanel14"
        Me.GradientPanel14.Size = New System.Drawing.Size(78, 56)
        Me.GradientPanel14.TabIndex = 528
        Me.GradientPanel14.Visible = False
        '
        'ButtonAdv12
        '
        Me.ButtonAdv12.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv12.BeforeTouchSize = New System.Drawing.Size(76, 54)
        Me.ButtonAdv12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv12.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv12.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv12.IsBackStageButton = False
        Me.ButtonAdv12.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv12.Name = "ButtonAdv12"
        Me.ButtonAdv12.Size = New System.Drawing.Size(76, 54)
        Me.ButtonAdv12.TabIndex = 53
        Me.ButtonAdv12.Text = "GARANTIA ENTREGAR"
        Me.ButtonAdv12.UseVisualStyle = True
        '
        'GradientPanel15
        '
        Me.GradientPanel15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel15.BorderColor = System.Drawing.Color.LightCoral
        Me.GradientPanel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel15.Controls.Add(Me.ButtonAdv13)
        Me.GradientPanel15.Location = New System.Drawing.Point(1027, 165)
        Me.GradientPanel15.Name = "GradientPanel15"
        Me.GradientPanel15.Size = New System.Drawing.Size(78, 56)
        Me.GradientPanel15.TabIndex = 527
        Me.GradientPanel15.Visible = False
        '
        'ButtonAdv13
        '
        Me.ButtonAdv13.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv13.BeforeTouchSize = New System.Drawing.Size(76, 54)
        Me.ButtonAdv13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv13.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv13.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv13.IsBackStageButton = False
        Me.ButtonAdv13.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv13.Name = "ButtonAdv13"
        Me.ButtonAdv13.Size = New System.Drawing.Size(76, 54)
        Me.ButtonAdv13.TabIndex = 53
        Me.ButtonAdv13.Text = "ANTICIPO ENTREGAR"
        Me.ButtonAdv13.UseVisualStyle = True
        '
        'GradientPanel16
        '
        Me.GradientPanel16.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel16.BorderColor = System.Drawing.Color.LightCoral
        Me.GradientPanel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel16.Controls.Add(Me.ButtonAdv14)
        Me.GradientPanel16.Location = New System.Drawing.Point(1027, 105)
        Me.GradientPanel16.Name = "GradientPanel16"
        Me.GradientPanel16.Size = New System.Drawing.Size(78, 56)
        Me.GradientPanel16.TabIndex = 526
        Me.GradientPanel16.Visible = False
        '
        'ButtonAdv14
        '
        Me.ButtonAdv14.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv14.BeforeTouchSize = New System.Drawing.Size(76, 54)
        Me.ButtonAdv14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv14.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv14.IsBackStageButton = False
        Me.ButtonAdv14.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv14.Name = "ButtonAdv14"
        Me.ButtonAdv14.Size = New System.Drawing.Size(76, 54)
        Me.ButtonAdv14.TabIndex = 53
        Me.ButtonAdv14.Text = "ENTREGAS A RENDIR"
        Me.ButtonAdv14.UseVisualStyle = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label17.Image = CType(resources.GetObject("Label17.Image"), System.Drawing.Image)
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label17.Location = New System.Drawing.Point(11, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 64)
        Me.Label17.TabIndex = 547
        Me.Label17.Text = "Ingresos"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label17.Visible = False
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Image = CType(resources.GetObject("Label25.Image"), System.Drawing.Image)
        Me.Label25.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label25.Location = New System.Drawing.Point(1030, 37)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(74, 64)
        Me.Label25.TabIndex = 548
        Me.Label25.Text = "Egresos"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label25.Visible = False
        '
        'GradientPanel17
        '
        Me.GradientPanel17.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel17.Controls.Add(Me.txtTipoCambio)
        Me.GradientPanel17.Controls.Add(Me.Label7)
        Me.GradientPanel17.Controls.Add(Me.LinkLabel2)
        Me.GradientPanel17.Controls.Add(Me.TextCodigoVendedor)
        Me.GradientPanel17.Controls.Add(Me.Label9)
        Me.GradientPanel17.Controls.Add(Me.TextComprador)
        Me.GradientPanel17.Controls.Add(Me.Label5)
        Me.GradientPanel17.Controls.Add(Me.Label15)
        Me.GradientPanel17.Location = New System.Drawing.Point(86, 44)
        Me.GradientPanel17.Name = "GradientPanel17"
        Me.GradientPanel17.Size = New System.Drawing.Size(932, 56)
        Me.GradientPanel17.TabIndex = 549
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.Silver
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CornerRadius = 4
        Me.txtTipoCambio.CurrencyDecimalDigits = 3
        Me.txtTipoCambio.CurrencySymbol = ""
        Me.txtTipoCambio.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTipoCambio.DecimalValue = New Decimal(New Integer() {3000, 0, 0, 196608})
        Me.txtTipoCambio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoCambio.Location = New System.Drawing.Point(561, 25)
        Me.txtTipoCambio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTipoCambio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.NullString = ""
        Me.txtTipoCambio.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoCambio.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTipoCambio.Size = New System.Drawing.Size(47, 22)
        Me.txtTipoCambio.TabIndex = 645
        Me.txtTipoCambio.Text = "3.000"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(559, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 14)
        Me.Label7.TabIndex = 646
        Me.Label7.Text = "T/c."
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(802, 28)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(125, 13)
        Me.LinkLabel2.TabIndex = 546
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "VER DETALLE DE VENTA"
        Me.LinkLabel2.Visible = False
        '
        'GradientPanel18
        '
        Me.GradientPanel18.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel18.Controls.Add(Me.ButtonAdv15)
        Me.GradientPanel18.Location = New System.Drawing.Point(2, 406)
        Me.GradientPanel18.Name = "GradientPanel18"
        Me.GradientPanel18.Size = New System.Drawing.Size(78, 56)
        Me.GradientPanel18.TabIndex = 550
        Me.GradientPanel18.Visible = False
        '
        'ButtonAdv15
        '
        Me.ButtonAdv15.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv15.BeforeTouchSize = New System.Drawing.Size(76, 54)
        Me.ButtonAdv15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv15.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv15.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv15.IsBackStageButton = False
        Me.ButtonAdv15.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv15.Name = "ButtonAdv15"
        Me.ButtonAdv15.Size = New System.Drawing.Size(76, 54)
        Me.ButtonAdv15.TabIndex = 53
        Me.ButtonAdv15.Text = "INGRESO ESPECIAL"
        Me.ButtonAdv15.UseVisualStyle = True
        '
        'GradientPanel20
        '
        Me.GradientPanel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.GradientPanel20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel20.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel20.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GradientPanel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel20.Controls.Add(Me.TextTotalPagosCliente)
        Me.GradientPanel20.Controls.Add(Me.LabelVueltoCliente)
        Me.GradientPanel20.Controls.Add(Me.Label31)
        Me.GradientPanel20.Controls.Add(Me.Label30)
        Me.GradientPanel20.Controls.Add(Me.LabelTotalCobrarCliente)
        Me.GradientPanel20.Controls.Add(Me.Label28)
        Me.GradientPanel20.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel20.Location = New System.Drawing.Point(86, 470)
        Me.GradientPanel20.Name = "GradientPanel20"
        Me.GradientPanel20.Size = New System.Drawing.Size(932, 48)
        Me.GradientPanel20.TabIndex = 551
        '
        'TextTotalPagosCliente
        '
        Me.TextTotalPagosCliente.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextTotalPagosCliente.BeforeTouchSize = New System.Drawing.Size(264, 23)
        Me.TextTotalPagosCliente.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.TextTotalPagosCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTotalPagosCliente.CornerRadius = 5
        Me.TextTotalPagosCliente.CurrencySymbol = ""
        Me.TextTotalPagosCliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTotalPagosCliente.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextTotalPagosCliente.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalPagosCliente.ForeColor = System.Drawing.Color.White
        Me.TextTotalPagosCliente.Location = New System.Drawing.Point(107, 11)
        Me.TextTotalPagosCliente.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextTotalPagosCliente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTotalPagosCliente.Name = "TextTotalPagosCliente"
        Me.TextTotalPagosCliente.NullString = ""
        Me.TextTotalPagosCliente.PositiveColor = System.Drawing.Color.White
        Me.TextTotalPagosCliente.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextTotalPagosCliente.Size = New System.Drawing.Size(141, 27)
        Me.TextTotalPagosCliente.TabIndex = 642
        Me.TextTotalPagosCliente.Text = "0.00"
        Me.TextTotalPagosCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelVueltoCliente
        '
        Me.LabelVueltoCliente.AutoSize = True
        Me.LabelVueltoCliente.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVueltoCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.LabelVueltoCliente.Location = New System.Drawing.Point(586, 10)
        Me.LabelVueltoCliente.Name = "LabelVueltoCliente"
        Me.LabelVueltoCliente.Size = New System.Drawing.Size(50, 28)
        Me.LabelVueltoCliente.TabIndex = 12
        Me.LabelVueltoCliente.Text = "0.00"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(530, 19)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 15)
        Me.Label31.TabIndex = 11
        Me.Label31.Text = "VUELTO"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(291, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(63, 15)
        Me.Label30.TabIndex = 10
        Me.Label30.Text = "A COBRAR"
        '
        'LabelTotalCobrarCliente
        '
        Me.LabelTotalCobrarCliente.AutoSize = True
        Me.LabelTotalCobrarCliente.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalCobrarCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.LabelTotalCobrarCliente.Location = New System.Drawing.Point(360, 10)
        Me.LabelTotalCobrarCliente.Name = "LabelTotalCobrarCliente"
        Me.LabelTotalCobrarCliente.Size = New System.Drawing.Size(50, 28)
        Me.LabelTotalCobrarCliente.TabIndex = 9
        Me.LabelTotalCobrarCliente.Text = "0.00"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(14, 19)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(86, 15)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "TOTAL  PAGOS"
        '
        'FormCajeroIndependienteV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 2
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ok_icon
        CaptionImage1.Location = New System.Drawing.Point(15, 8)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(16, 16)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(40, 3)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Caja activa"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1109, 568)
        Me.Controls.Add(Me.PanelLoadingWaith)
        Me.Controls.Add(Me.GradientPanel20)
        Me.Controls.Add(Me.GradientPanel18)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GradientPanel12)
        Me.Controls.Add(Me.GradientPanel13)
        Me.Controls.Add(Me.GradientPanel14)
        Me.Controls.Add(Me.GradientPanel15)
        Me.Controls.Add(Me.GradientPanel16)
        Me.Controls.Add(Me.GradientPanel11)
        Me.Controls.Add(Me.GradientPanel10)
        Me.Controls.Add(Me.GradientPanel8)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.PanelVendedorInfo)
        Me.Controls.Add(Me.PanelCupon)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel7)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.PanelMontos)
        Me.Controls.Add(Me.GradientPanel9)
        Me.Controls.Add(Me.GradientPanel17)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "FormCajeroIndependienteV2"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.Text = "Caja"
        CType(Me.GradientPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel9.ResumeLayout(False)
        Me.GradientPanel9.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TextValoranticipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPagoAnticipoDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelVendedorInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelVendedorInfo.ResumeLayout(False)
        Me.PanelVendedorInfo.PerformLayout()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextComprador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelCupon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCupon.ResumeLayout(False)
        Me.PanelCupon.PerformLayout()
        CType(Me.TextCodigoCupon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCuponImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        Me.GradientPanel7.PerformLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.txtTotalIcbper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPercepcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelMontos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMontos.ResumeLayout(False)
        Me.PanelMontos.PerformLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.GradientPanel19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel19.ResumeLayout(False)
        Me.GradientPanel19.PerformLayout()
        CType(Me.TextSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLoadingWaith.ResumeLayout(False)
        Me.PanelLoadingWaith.PerformLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        CType(Me.GradientPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel10.ResumeLayout(False)
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel11.ResumeLayout(False)
        CType(Me.GradientPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel12.ResumeLayout(False)
        CType(Me.GradientPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel13.ResumeLayout(False)
        CType(Me.GradientPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel14.ResumeLayout(False)
        CType(Me.GradientPanel15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel15.ResumeLayout(False)
        CType(Me.GradientPanel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel16.ResumeLayout(False)
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel17.ResumeLayout(False)
        Me.GradientPanel17.PerformLayout()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel18.ResumeLayout(False)
        CType(Me.GradientPanel20, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel20.ResumeLayout(False)
        Me.GradientPanel20.PerformLayout()
        CType(Me.TextTotalPagosCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel9 As Tools.GradientPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btOperacion As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents Label15 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents chCobranzaParcial As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents chCredito As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents ChPagoAvanzado As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnCliente As Button
    Friend WithEvents cboMoneda As Tools.ComboBoxAdv
    Friend WithEvents chAutoNumeracion As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents txtNumero As Tools.TextBoxExt
    Friend WithEvents txtSerie As Tools.TextBoxExt
    Friend WithEvents cboTipoDoc As Tools.ComboBoxAdv
    Friend WithEvents txtFecha As Tools.DateTimePickerAdv
    Private WithEvents PanelVendedorInfo As Tools.GradientPanel
    Friend WithEvents TextCodigoVendedor As Tools.TextBoxExt
    Friend WithEvents Label9 As Label
    Private WithEvents PanelCupon As Tools.GradientPanel
    Friend WithEvents ButtonAdv5 As ButtonAdv
    Friend WithEvents TextCodigoCupon As Tools.TextBoxExt
    Friend WithEvents TextCuponImporte As Tools.CurrencyTextBox
    Friend WithEvents ButtonAdv4 As ButtonAdv
    Private WithEvents GradientPanel7 As Tools.GradientPanel
    Friend WithEvents LabelCupon As Label
    Friend WithEvents Label20 As Label
    Private WithEvents GradientPanel3 As Tools.GradientPanel
    Friend WithEvents TextTotalDescuentos As Tools.CurrencyTextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtTotalBase As Tools.CurrencyTextBox
    Friend WithEvents txtTotalBase2 As Tools.CurrencyTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtTotalBase3 As Tools.CurrencyTextBox
    Friend WithEvents txtTotalIva As Tools.CurrencyTextBox
    Friend WithEvents lblTotalPercepcion As Tools.CurrencyTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label12 As Label
    Private WithEvents PanelMontos As Tools.GradientPanel
    Friend WithEvents lblPagoVenta As Label
    Friend WithEvents GradientPanel5 As Tools.GradientPanel
    Friend WithEvents GradientPanel6 As Tools.GradientPanel
    Friend WithEvents txtTotalPagar As Tools.CurrencyTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents ButtonAdv2 As ButtonAdv
    Friend WithEvents ButtonAdv3 As ButtonAdv
    Private WithEvents GradientPanel4 As Tools.GradientPanel
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
    Friend WithEvents LblPagoCredito As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents ChBanco As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label23 As Label
    Friend WithEvents ChEfectivo As Bunifu.Framework.UI.BunifuCheckbox
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Friend WithEvents ToolImportar As ToolStripButton
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents TextPagoAnticipoDisponible As Tools.CurrencyTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents TextValoranticipo As Tools.CurrencyTextBox
    Friend WithEvents CheckEfectivoDefault As CheckBox
    Friend WithEvents ToolBuscarVenta As ToolStripButton
    Friend WithEvents TextComprador As Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents PanelLoadingWaith As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents GradientPanel10 As Tools.GradientPanel
    Friend WithEvents ButtonAdv8 As ButtonAdv
    Friend WithEvents GradientPanel8 As Tools.GradientPanel
    Friend WithEvents ButtonAdv7 As ButtonAdv
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents ButtonAdv6 As ButtonAdv
    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As ButtonAdv
    Friend WithEvents GradientPanel11 As Tools.GradientPanel
    Friend WithEvents ButtonAdv9 As ButtonAdv
    Friend WithEvents GradientPanel12 As Tools.GradientPanel
    Friend WithEvents ButtonAdv10 As ButtonAdv
    Friend WithEvents GradientPanel13 As Tools.GradientPanel
    Friend WithEvents ButtonAdv11 As ButtonAdv
    Friend WithEvents GradientPanel14 As Tools.GradientPanel
    Friend WithEvents ButtonAdv12 As ButtonAdv
    Friend WithEvents GradientPanel15 As Tools.GradientPanel
    Friend WithEvents ButtonAdv13 As ButtonAdv
    Friend WithEvents GradientPanel16 As Tools.GradientPanel
    Friend WithEvents ButtonAdv14 As ButtonAdv
    Friend WithEvents Label25 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents ToolCerracaja As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolSeguimientoCaja As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolEditPedido As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents Label1 As Label
    Friend WithEvents GradientPanel17 As Tools.GradientPanel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GradientPanel18 As Tools.GradientPanel
    Friend WithEvents ButtonAdv15 As ButtonAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTipoCambio As Tools.CurrencyTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureLoad As PictureBox
    Friend WithEvents TextNumIdentrazon As Tools.TextBoxExt
    Friend WithEvents TextProveedor As Tools.TextBoxExt
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents GradientPanel19 As Tools.GradientPanel
    Friend WithEvents TextSubTotal As Tools.CurrencyTextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents ComboCaja As Tools.ComboBoxAdv
    Friend WithEvents txtTotalIcbper As Tools.CurrencyTextBox
    Friend WithEvents Label27 As Label
    Private WithEvents GradientPanel20 As Tools.GradientPanel
    Friend WithEvents LabelTotalCobrarCliente As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents LabelVueltoCliente As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents TextTotalPagosCliente As Tools.CurrencyTextBox
End Class

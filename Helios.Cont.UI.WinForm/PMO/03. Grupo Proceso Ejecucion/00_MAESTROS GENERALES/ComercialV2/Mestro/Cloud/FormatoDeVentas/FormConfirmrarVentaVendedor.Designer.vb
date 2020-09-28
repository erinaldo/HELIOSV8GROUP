Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConfirmrarVentaVendedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfirmrarVentaVendedor))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
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
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LblPagoCredito = New System.Windows.Forms.Label()
        Me.lblPagoVenta = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtTotalPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ChBanco = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ChEfectivo = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.gradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.chCobranzaParcial = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChPagoDirecto = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.cbocajaPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PanelLoading = New System.Windows.Forms.Panel()
        Me.ProgressBar4 = New System.Windows.Forms.ProgressBar()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.chAutoNumeracion = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.txtruc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TXTcOMPRADOR = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextValoranticipo = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextPagoAnticipoDisponible = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chCredito = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.ChPagoAvanzado = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.PanelCupon = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.TextCodigoCupon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCuponImporte = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LabelCupon = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.TextCodigoVendedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.CheckUsuarioUnico = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboCaja = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GradientPanel9 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolImportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.GradientPanel10 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ComboFechaVencimiento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtFechaVencimiento = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.CheckEfectivoDefault = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.BunifuCheckbox2 = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTienda = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextOrdenventa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNumeroGuia = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPercepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gradientPanel2.SuspendLayout()
        Me.pcLikeCategoria.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cbocajaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLoading.SuspendLayout()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextValoranticipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPagoAnticipoDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelCupon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCupon.SuspendLayout()
        CType(Me.TextCodigoCupon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCuponImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel9.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GradientPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel10.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ComboFechaVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVencimiento.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextOrdenventa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumeroGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel3
        '
        Me.GradientPanel3.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.GradientPanel3.Location = New System.Drawing.Point(1, 524)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(949, 48)
        Me.GradientPanel3.TabIndex = 505
        '
        'TextTotalDescuentos
        '
        Me.TextTotalDescuentos.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.TextTotalDescuentos.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.TextTotalDescuentos.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextTotalDescuentos.CornerRadius = 5
        Me.TextTotalDescuentos.CurrencySymbol = ""
        Me.TextTotalDescuentos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTotalDescuentos.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextTotalDescuentos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalDescuentos.ForeColor = System.Drawing.Color.Black
        Me.TextTotalDescuentos.Location = New System.Drawing.Point(793, 26)
        Me.TextTotalDescuentos.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTotalDescuentos.Name = "TextTotalDescuentos"
        Me.TextTotalDescuentos.NullString = ""
        Me.TextTotalDescuentos.PositiveColor = System.Drawing.Color.Black
        Me.TextTotalDescuentos.ReadOnly = True
        Me.TextTotalDescuentos.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TextTotalDescuentos.Size = New System.Drawing.Size(141, 15)
        Me.TextTotalDescuentos.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextTotalDescuentos.TabIndex = 500
        Me.TextTotalDescuentos.Text = "0.00"
        Me.TextTotalDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(715, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 499
        Me.Label19.Text = "Descuentos"
        '
        'txtTotalBase
        '
        Me.txtTotalBase.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.txtTotalBase.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase.CornerRadius = 5
        Me.txtTotalBase.CurrencySymbol = ""
        Me.txtTotalBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase.Location = New System.Drawing.Point(103, 6)
        Me.txtTotalBase.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase.Name = "txtTotalBase"
        Me.txtTotalBase.NullString = ""
        Me.txtTotalBase.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalBase.ReadOnly = True
        Me.txtTotalBase.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalBase.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalBase.TabIndex = 494
        Me.txtTotalBase.Text = "0.00"
        Me.txtTotalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBase2
        '
        Me.txtTotalBase2.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase2.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.txtTotalBase2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase2.CornerRadius = 5
        Me.txtTotalBase2.CurrencySymbol = ""
        Me.txtTotalBase2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase2.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase2.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase2.Location = New System.Drawing.Point(103, 26)
        Me.txtTotalBase2.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase2.Name = "txtTotalBase2"
        Me.txtTotalBase2.NullString = ""
        Me.txtTotalBase2.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalBase2.ReadOnly = True
        Me.txtTotalBase2.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalBase2.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalBase2.TabIndex = 492
        Me.txtTotalBase2.Text = "0.00"
        Me.txtTotalBase2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
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
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(17, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Op. Gravada"
        '
        'txtTotalBase3
        '
        Me.txtTotalBase3.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase3.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.txtTotalBase3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase3.CornerRadius = 5
        Me.txtTotalBase3.CurrencySymbol = ""
        Me.txtTotalBase3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase3.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase3.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase3.Location = New System.Drawing.Point(458, 6)
        Me.txtTotalBase3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase3.Name = "txtTotalBase3"
        Me.txtTotalBase3.NullString = ""
        Me.txtTotalBase3.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalBase3.ReadOnly = True
        Me.txtTotalBase3.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalBase3.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase3.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalBase3.TabIndex = 498
        Me.txtTotalBase3.Text = "0.00"
        Me.txtTotalBase3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIva.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.txtTotalIva.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalIva.CornerRadius = 5
        Me.txtTotalIva.CurrencySymbol = ""
        Me.txtTotalIva.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalIva.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIva.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.ForeColor = System.Drawing.Color.Black
        Me.txtTotalIva.Location = New System.Drawing.Point(458, 28)
        Me.txtTotalIva.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.NullString = ""
        Me.txtTotalIva.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalIva.ReadOnly = True
        Me.txtTotalIva.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalIva.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalIva.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalIva.TabIndex = 493
        Me.txtTotalIva.Text = "0.00"
        Me.txtTotalIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalPercepcion
        '
        Me.lblTotalPercepcion.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.lblTotalPercepcion.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.lblTotalPercepcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPercepcion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblTotalPercepcion.CornerRadius = 5
        Me.lblTotalPercepcion.CurrencySymbol = ""
        Me.lblTotalPercepcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblTotalPercepcion.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.lblTotalPercepcion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPercepcion.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPercepcion.Location = New System.Drawing.Point(793, 6)
        Me.lblTotalPercepcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPercepcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.lblTotalPercepcion.Name = "lblTotalPercepcion"
        Me.lblTotalPercepcion.NullString = ""
        Me.lblTotalPercepcion.PositiveColor = System.Drawing.Color.Black
        Me.lblTotalPercepcion.ReadOnly = True
        Me.lblTotalPercepcion.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lblTotalPercepcion.Size = New System.Drawing.Size(141, 15)
        Me.lblTotalPercepcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.lblTotalPercepcion.TabIndex = 496
        Me.lblTotalPercepcion.Text = "0.00"
        Me.lblTotalPercepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(382, 8)
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
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(714, 6)
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
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(382, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "IGV"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.GradientPanel4)
        Me.GradientPanel1.Controls.Add(Me.Panel2)
        Me.GradientPanel1.Controls.Add(Me.Panel1)
        Me.GradientPanel1.Controls.Add(Me.Label21)
        Me.GradientPanel1.Controls.Add(Me.ChBanco)
        Me.GradientPanel1.Controls.Add(Me.Label23)
        Me.GradientPanel1.Controls.Add(Me.ChEfectivo)
        Me.GradientPanel1.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel1.Location = New System.Drawing.Point(1, 213)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(949, 305)
        Me.GradientPanel1.TabIndex = 504
        Me.GradientPanel1.ThemesEnabled = True
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel4.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.dgvCuentas)
        Me.GradientPanel4.Controls.Add(Me.ButtonAdv3)
        Me.GradientPanel4.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel4.Location = New System.Drawing.Point(0, 60)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(947, 243)
        Me.GradientPanel4.TabIndex = 523
        '
        'dgvCuentas
        '
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCuentas.BackColor = System.Drawing.Color.White
        Me.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuentas.FreezeCaption = False
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.Size = New System.Drawing.Size(945, 241)
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
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "tipo"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "identidad"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 19
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Cuenta"
        GridColumnDescriptor3.MappingName = "entidad"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 190
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.SystemColors.HotTrack
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer)))
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.TextAlign = Syncfusion.Windows.Forms.Grid.GridTextAlign.Right
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Abono"
        GridColumnDescriptor4.MappingName = "abonado"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 150
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "T/C"
        GridColumnDescriptor5.MappingName = "tipocambio"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 50
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "idforma"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 20
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Error = "Object reference not set to an instance of an object."
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Forma de Pago"
        GridColumnDescriptor7.MappingName = "formaPago"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 190
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "N°Op"
        GridColumnDescriptor8.MappingName = "nrooperacion"
        GridColumnDescriptor8.SerializedImageArray = ""
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
        Me.dgvCuentas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCuentas.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCuentas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("formaPago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("abonado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nrooperacion")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
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
        Me.ButtonAdv3.Location = New System.Drawing.Point(768, -28)
        Me.ButtonAdv3.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(25, 25)
        Me.ButtonAdv3.TabIndex = 525
        Me.ButtonAdv3.UseVisualStyle = True
        Me.ButtonAdv3.Visible = False
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
        Me.ButtonAdv2.Location = New System.Drawing.Point(795, -28)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(25, 25)
        Me.ButtonAdv2.TabIndex = 526
        Me.ButtonAdv2.UseVisualStyle = True
        Me.ButtonAdv2.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GradientPanel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(947, 30)
        Me.Panel2.TabIndex = 536
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.GradientPanel5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel5.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.LblPagoCredito)
        Me.GradientPanel5.Controls.Add(Me.lblPagoVenta)
        Me.GradientPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel5.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(947, 30)
        Me.GradientPanel5.TabIndex = 222
        '
        'LblPagoCredito
        '
        Me.LblPagoCredito.BackColor = System.Drawing.Color.Transparent
        Me.LblPagoCredito.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblPagoCredito.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPagoCredito.ForeColor = System.Drawing.Color.Firebrick
        Me.LblPagoCredito.Location = New System.Drawing.Point(0, 0)
        Me.LblPagoCredito.Name = "LblPagoCredito"
        Me.LblPagoCredito.Size = New System.Drawing.Size(250, 28)
        Me.LblPagoCredito.TabIndex = 533
        Me.LblPagoCredito.Text = "SALDO POR PAGAR"
        Me.LblPagoCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblPagoCredito.Visible = False
        '
        'lblPagoVenta
        '
        Me.lblPagoVenta.AutoSize = True
        Me.lblPagoVenta.BackColor = System.Drawing.Color.Transparent
        Me.lblPagoVenta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPagoVenta.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.lblPagoVenta.Location = New System.Drawing.Point(895, 0)
        Me.lblPagoVenta.Name = "lblPagoVenta"
        Me.lblPagoVenta.Size = New System.Drawing.Size(50, 28)
        Me.lblPagoVenta.TabIndex = 534
        Me.lblPagoVenta.Text = "0.00"
        Me.lblPagoVenta.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GradientPanel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(947, 30)
        Me.Panel1.TabIndex = 535
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BackColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel6.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Controls.Add(Me.txtTotalPagar)
        Me.GradientPanel6.Controls.Add(Me.Label13)
        Me.GradientPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel6.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(947, 30)
        Me.GradientPanel6.TabIndex = 222
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTotalPagar.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.txtTotalPagar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalPagar.CornerRadius = 5
        Me.txtTotalPagar.CurrencySymbol = ""
        Me.txtTotalPagar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPagar.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtTotalPagar.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.White
        Me.txtTotalPagar.Location = New System.Drawing.Point(804, 0)
        Me.txtTotalPagar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.NullString = ""
        Me.txtTotalPagar.PositiveColor = System.Drawing.Color.White
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.ReadOnlyBackColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalPagar.Size = New System.Drawing.Size(141, 27)
        Me.txtTotalPagar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalPagar.TabIndex = 495
        Me.txtTotalPagar.Text = "0.00"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 28)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "TOTAL A PAGAR"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'gradientPanel2
        '
        Me.gradientPanel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.gradientPanel2.BorderColor = System.Drawing.Color.Silver
        Me.gradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gradientPanel2.Controls.Add(Me.pcLikeCategoria)
        Me.gradientPanel2.Controls.Add(Me.Label1)
        Me.gradientPanel2.Controls.Add(Me.GroupBox2)
        Me.gradientPanel2.Controls.Add(Me.GroupBox1)
        Me.gradientPanel2.Controls.Add(Me.PanelLoading)
        Me.gradientPanel2.Controls.Add(Me.chAutoNumeracion)
        Me.gradientPanel2.Controls.Add(Me.txtNumero)
        Me.gradientPanel2.Controls.Add(Me.txtSerie)
        Me.gradientPanel2.Controls.Add(Me.txtFecha)
        Me.gradientPanel2.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gradientPanel2.Location = New System.Drawing.Point(8, 57)
        Me.gradientPanel2.Name = "gradientPanel2"
        Me.gradientPanel2.Size = New System.Drawing.Size(350, 22)
        Me.gradientPanel2.TabIndex = 502
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(381, 78)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 509
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 14)
        Me.Label1.TabIndex = 546
        Me.Label1.Text = "Serie - número"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.chCobranzaParcial)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 321)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 67)
        Me.GroupBox2.TabIndex = 544
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Venta al crédito"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(32, 49)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(178, 14)
        Me.Label18.TabIndex = 542
        Me.Label18.Text = "Otras formas de cobranza (Parcial)"
        '
        'chCobranzaParcial
        '
        Me.chCobranzaParcial.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chCobranzaParcial.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chCobranzaParcial.Checked = False
        Me.chCobranzaParcial.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.chCobranzaParcial.ForeColor = System.Drawing.Color.White
        Me.chCobranzaParcial.Location = New System.Drawing.Point(11, 43)
        Me.chCobranzaParcial.Name = "chCobranzaParcial"
        Me.chCobranzaParcial.Size = New System.Drawing.Size(20, 20)
        Me.chCobranzaParcial.TabIndex = 541
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChPagoDirecto)
        Me.GroupBox1.Controls.Add(Me.cbocajaPago)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 248)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 67)
        Me.GroupBox1.TabIndex = 543
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Venta al contado"
        '
        'ChPagoDirecto
        '
        Me.ChPagoDirecto.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPagoDirecto.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPagoDirecto.Checked = False
        Me.ChPagoDirecto.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.ChPagoDirecto.ForeColor = System.Drawing.Color.White
        Me.ChPagoDirecto.Location = New System.Drawing.Point(13, 21)
        Me.ChPagoDirecto.Name = "ChPagoDirecto"
        Me.ChPagoDirecto.Size = New System.Drawing.Size(20, 20)
        Me.ChPagoDirecto.TabIndex = 4
        Me.ChPagoDirecto.Visible = False
        '
        'cbocajaPago
        '
        Me.cbocajaPago.BackColor = System.Drawing.Color.White
        Me.cbocajaPago.BeforeTouchSize = New System.Drawing.Size(146, 19)
        Me.cbocajaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocajaPago.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbocajaPago.Location = New System.Drawing.Point(159, 21)
        Me.cbocajaPago.MetroBorderColor = System.Drawing.Color.Silver
        Me.cbocajaPago.Name = "cbocajaPago"
        Me.cbocajaPago.Size = New System.Drawing.Size(146, 19)
        Me.cbocajaPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbocajaPago.TabIndex = 528
        Me.cbocajaPago.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(34, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 14)
        Me.Label7.TabIndex = 529
        Me.Label7.Text = "Cobro Total - Caja única"
        Me.Label7.Visible = False
        '
        'PanelLoading
        '
        Me.PanelLoading.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelLoading.Controls.Add(Me.ProgressBar4)
        Me.PanelLoading.Controls.Add(Me.Label24)
        Me.PanelLoading.Location = New System.Drawing.Point(211, 236)
        Me.PanelLoading.Name = "PanelLoading"
        Me.PanelLoading.Size = New System.Drawing.Size(317, 54)
        Me.PanelLoading.TabIndex = 539
        Me.PanelLoading.Visible = False
        '
        'ProgressBar4
        '
        Me.ProgressBar4.Location = New System.Drawing.Point(128, 35)
        Me.ProgressBar4.Name = "ProgressBar4"
        Me.ProgressBar4.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar4.TabIndex = 508
        Me.ProgressBar4.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Calibri Light", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(102, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 24)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Loading . . ."
        '
        'chAutoNumeracion
        '
        Me.chAutoNumeracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chAutoNumeracion.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chAutoNumeracion.Checked = False
        Me.chAutoNumeracion.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.chAutoNumeracion.ForeColor = System.Drawing.Color.White
        Me.chAutoNumeracion.Location = New System.Drawing.Point(224, 114)
        Me.chAutoNumeracion.Name = "chAutoNumeracion"
        Me.chAutoNumeracion.Size = New System.Drawing.Size(20, 20)
        Me.chAutoNumeracion.TabIndex = 519
        Me.chAutoNumeracion.Visible = False
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.txtNumero.BorderColor = System.Drawing.Color.LightGray
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.CornerRadius = 4
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumero.Location = New System.Drawing.Point(100, 112)
        Me.txtNumero.Metrocolor = System.Drawing.Color.LightGray
        Me.txtNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(121, 22)
        Me.txtNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNumero.TabIndex = 2
        Me.txtNumero.Visible = False
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.txtSerie.BorderColor = System.Drawing.Color.LightGray
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.CornerRadius = 4
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtSerie.Location = New System.Drawing.Point(20, 112)
        Me.txtSerie.Metrocolor = System.Drawing.Color.LightGray
        Me.txtSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(76, 22)
        Me.txtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSerie.TabIndex = 1
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFecha.Calendar.AllowMultipleSelection = False
        Me.txtFecha.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFecha.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.txtFecha.Calendar.Size = New System.Drawing.Size(185, 174)
        Me.txtFecha.Calendar.SizeToFit = True
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
        Me.txtFecha.Calendar.NoneButton.Location = New System.Drawing.Point(109, 0)
        Me.txtFecha.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFecha.Calendar.NoneButton.Text = "None"
        Me.txtFecha.Calendar.NoneButton.UseVisualStyle = True
        Me.txtFecha.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.txtFecha.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecha.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecha.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFecha.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFecha.Calendar.TodayButton.Size = New System.Drawing.Size(185, 20)
        Me.txtFecha.Calendar.TodayButton.Text = "Today"
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
        Me.txtFecha.Enabled = False
        Me.txtFecha.EnableNullDate = False
        Me.txtFecha.EnableNullKeys = False
        Me.txtFecha.Font = New System.Drawing.Font("Calibri Light", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.ForeColor = System.Drawing.Color.Black
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(20, 38)
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
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(402, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 26)
        Me.Button1.TabIndex = 560
        Me.ToolTip1.SetToolTip(Me.Button1, "Cliente varios")
        Me.Button1.UseVisualStyleBackColor = False
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
        Me.btnCliente.Location = New System.Drawing.Point(374, 21)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(25, 26)
        Me.btnCliente.TabIndex = 558
        Me.ToolTip1.SetToolTip(Me.btnCliente, "Nuevo cliente")
        Me.btnCliente.UseVisualStyleBackColor = False
        '
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtruc.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.txtruc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.CornerRadius = 4
        Me.txtruc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtruc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtruc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtruc.Location = New System.Drawing.Point(321, 69)
        Me.txtruc.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtruc.Name = "txtruc"
        Me.txtruc.NearImage = CType(resources.GetObject("txtruc.NearImage"), System.Drawing.Image)
        Me.txtruc.ReadOnly = True
        Me.txtruc.Size = New System.Drawing.Size(143, 22)
        Me.txtruc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtruc.TabIndex = 555
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(282, 80)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar1.TabIndex = 557
        Me.ProgressBar1.Visible = False
        '
        'TXTcOMPRADOR
        '
        Me.TXTcOMPRADOR.BackColor = System.Drawing.Color.White
        Me.TXTcOMPRADOR.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.TXTcOMPRADOR.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTcOMPRADOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTcOMPRADOR.CornerRadius = 4
        Me.TXTcOMPRADOR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTcOMPRADOR.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TXTcOMPRADOR.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTcOMPRADOR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTcOMPRADOR.Location = New System.Drawing.Point(12, 69)
        Me.TXTcOMPRADOR.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTcOMPRADOR.Name = "TXTcOMPRADOR"
        Me.TXTcOMPRADOR.NearImage = CType(resources.GetObject("TXTcOMPRADOR.NearImage"), System.Drawing.Image)
        Me.TXTcOMPRADOR.Size = New System.Drawing.Size(303, 22)
        Me.TXTcOMPRADOR.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TXTcOMPRADOR.TabIndex = 556
        '
        'TextValoranticipo
        '
        Me.TextValoranticipo.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextValoranticipo.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.TextValoranticipo.BorderColor = System.Drawing.Color.Silver
        Me.TextValoranticipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValoranticipo.CornerRadius = 4
        Me.TextValoranticipo.CurrencySymbol = ""
        Me.TextValoranticipo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextValoranticipo.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValoranticipo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValoranticipo.ForeColor = System.Drawing.Color.Black
        Me.TextValoranticipo.Location = New System.Drawing.Point(97, 20)
        Me.TextValoranticipo.Metrocolor = System.Drawing.Color.Silver
        Me.TextValoranticipo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextValoranticipo.Name = "TextValoranticipo"
        Me.TextValoranticipo.NegativeColor = System.Drawing.Color.Silver
        Me.TextValoranticipo.NullString = ""
        Me.TextValoranticipo.PositiveColor = System.Drawing.Color.Black
        Me.TextValoranticipo.ReadOnlyBackColor = System.Drawing.Color.White
        Me.TextValoranticipo.Size = New System.Drawing.Size(81, 23)
        Me.TextValoranticipo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextValoranticipo.TabIndex = 552
        Me.TextValoranticipo.Text = "0.00"
        Me.TextValoranticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextPagoAnticipoDisponible
        '
        Me.TextPagoAnticipoDisponible.BackGroundColor = System.Drawing.Color.LightGray
        Me.TextPagoAnticipoDisponible.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.TextPagoAnticipoDisponible.BorderColor = System.Drawing.Color.Silver
        Me.TextPagoAnticipoDisponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPagoAnticipoDisponible.CornerRadius = 4
        Me.TextPagoAnticipoDisponible.CurrencySymbol = ""
        Me.TextPagoAnticipoDisponible.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPagoAnticipoDisponible.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextPagoAnticipoDisponible.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPagoAnticipoDisponible.ForeColor = System.Drawing.Color.Black
        Me.TextPagoAnticipoDisponible.Location = New System.Drawing.Point(10, 20)
        Me.TextPagoAnticipoDisponible.Metrocolor = System.Drawing.Color.Silver
        Me.TextPagoAnticipoDisponible.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPagoAnticipoDisponible.Name = "TextPagoAnticipoDisponible"
        Me.TextPagoAnticipoDisponible.NegativeColor = System.Drawing.Color.Silver
        Me.TextPagoAnticipoDisponible.NullString = ""
        Me.TextPagoAnticipoDisponible.PositiveColor = System.Drawing.Color.Black
        Me.TextPagoAnticipoDisponible.ReadOnly = True
        Me.TextPagoAnticipoDisponible.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.TextPagoAnticipoDisponible.Size = New System.Drawing.Size(81, 23)
        Me.TextPagoAnticipoDisponible.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextPagoAnticipoDisponible.TabIndex = 550
        Me.TextPagoAnticipoDisponible.Text = "0.00"
        Me.TextPagoAnticipoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel1.Location = New System.Drawing.Point(183, 27)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(53, 13)
        Me.LinkLabel1.TabIndex = 551
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Buscar ..."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(39, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 14)
        Me.Label16.TabIndex = 536
        Me.Label16.Text = "Venta al crédito (Total)"
        '
        'chCredito
        '
        Me.chCredito.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chCredito.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chCredito.Checked = False
        Me.chCredito.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.chCredito.ForeColor = System.Drawing.Color.White
        Me.chCredito.Location = New System.Drawing.Point(18, 60)
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
        Me.ChPagoAvanzado.ForeColor = System.Drawing.Color.White
        Me.ChPagoAvanzado.Location = New System.Drawing.Point(18, 32)
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
        Me.Label8.Location = New System.Drawing.Point(39, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 14)
        Me.Label8.TabIndex = 532
        Me.Label8.Text = "Cobranza total o parcial"
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(126, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Enabled = False
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERA"})
        Me.cboMoneda.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMoneda, "NACIONAL"))
        Me.cboMoneda.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMoneda, "EXTRANJERA"))
        Me.cboMoneda.Location = New System.Drawing.Point(242, 24)
        Me.cboMoneda.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(126, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 525
        Me.cboMoneda.Text = "NACIONAL"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(203, 35)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 507
        Me.ProgressBar2.Visible = False
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(224, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(12, 24)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(224, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 0
        '
        'PanelCupon
        '
        Me.PanelCupon.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.PanelCupon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelCupon.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.PanelCupon.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.PanelCupon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelCupon.Controls.Add(Me.Label2)
        Me.PanelCupon.Controls.Add(Me.ButtonAdv5)
        Me.PanelCupon.Controls.Add(Me.TextCodigoCupon)
        Me.PanelCupon.Controls.Add(Me.TextCuponImporte)
        Me.PanelCupon.Controls.Add(Me.ButtonAdv4)
        Me.PanelCupon.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelCupon.Location = New System.Drawing.Point(487, 108)
        Me.PanelCupon.Name = "PanelCupon"
        Me.PanelCupon.Size = New System.Drawing.Size(318, 56)
        Me.PanelCupon.TabIndex = 508
        Me.PanelCupon.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 530
        Me.Label2.Text = "Código cupon"
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.Transparent
        Me.ButtonAdv5.BackgroundImage = CType(resources.GetObject("ButtonAdv5.BackgroundImage"), System.Drawing.Image)
        Me.ButtonAdv5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(28, 28)
        Me.ButtonAdv5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(282, 21)
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
        Me.TextCodigoCupon.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.TextCodigoCupon.BorderColor = System.Drawing.Color.LightGray
        Me.TextCodigoCupon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoCupon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoCupon.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoCupon.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoCupon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoCupon.Location = New System.Drawing.Point(8, 23)
        Me.TextCodigoCupon.Metrocolor = System.Drawing.Color.LightGray
        Me.TextCodigoCupon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoCupon.Name = "TextCodigoCupon"
        Me.TextCodigoCupon.NearImage = CType(resources.GetObject("TextCodigoCupon.NearImage"), System.Drawing.Image)
        Me.TextCodigoCupon.Size = New System.Drawing.Size(159, 24)
        Me.TextCodigoCupon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoCupon.TabIndex = 528
        Me.TextCodigoCupon.Visible = False
        '
        'TextCuponImporte
        '
        Me.TextCuponImporte.BackGroundColor = System.Drawing.Color.White
        Me.TextCuponImporte.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.TextCuponImporte.BorderColor = System.Drawing.Color.Silver
        Me.TextCuponImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCuponImporte.CurrencySymbol = ""
        Me.TextCuponImporte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCuponImporte.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextCuponImporte.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCuponImporte.ForeColor = System.Drawing.Color.Black
        Me.TextCuponImporte.Location = New System.Drawing.Point(169, 22)
        Me.TextCuponImporte.Metrocolor = System.Drawing.Color.Silver
        Me.TextCuponImporte.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCuponImporte.Name = "TextCuponImporte"
        Me.TextCuponImporte.NegativeColor = System.Drawing.Color.Silver
        Me.TextCuponImporte.NullString = ""
        Me.TextCuponImporte.PositiveColor = System.Drawing.Color.Black
        Me.TextCuponImporte.ReadOnly = True
        Me.TextCuponImporte.ReadOnlyBackColor = System.Drawing.Color.White
        Me.TextCuponImporte.Size = New System.Drawing.Size(55, 25)
        Me.TextCuponImporte.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
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
        Me.ButtonAdv4.Location = New System.Drawing.Point(227, 22)
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
        Me.GradientPanel7.Location = New System.Drawing.Point(959, 57)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(163, 56)
        Me.GradientPanel7.TabIndex = 507
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
        Me.Label20.Size = New System.Drawing.Size(42, 13)
        Me.Label20.TabIndex = 530
        Me.Label20.Text = "Cupón"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TextCodigoVendedor
        '
        Me.TextCodigoVendedor.BackColor = System.Drawing.Color.WhiteSmoke
        BannerTextInfo1.Text = "Código"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextCodigoVendedor, BannerTextInfo1)
        Me.TextCodigoVendedor.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.TextCodigoVendedor.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoVendedor.CornerRadius = 4
        Me.TextCodigoVendedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoVendedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoVendedor.Location = New System.Drawing.Point(20, 25)
        Me.TextCodigoVendedor.MaxLength = 10
        Me.TextCodigoVendedor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextCodigoVendedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoVendedor.Name = "TextCodigoVendedor"
        Me.TextCodigoVendedor.NearImage = CType(resources.GetObject("TextCodigoVendedor.NearImage"), System.Drawing.Image)
        Me.TextCodigoVendedor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextCodigoVendedor.Size = New System.Drawing.Size(98, 23)
        Me.TextCodigoVendedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCodigoVendedor.TabIndex = 19
        Me.TextCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.editar_usuario_icono
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(433, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(25, 26)
        Me.Button2.TabIndex = 561
        Me.ToolTip1.SetToolTip(Me.Button2, "Cliente varios")
        Me.Button2.UseVisualStyleBackColor = False
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.GradientPanel8.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel8.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.CheckUsuarioUnico)
        Me.GradientPanel8.Controls.Add(Me.Label6)
        Me.GradientPanel8.Controls.Add(Me.Label4)
        Me.GradientPanel8.Controls.Add(Me.Label17)
        Me.GradientPanel8.Controls.Add(Me.ComboCaja)
        Me.GradientPanel8.Controls.Add(Me.TextCodigoVendedor)
        Me.GradientPanel8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel8.Location = New System.Drawing.Point(0, 38)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(461, 56)
        Me.GradientPanel8.TabIndex = 510
        '
        'CheckUsuarioUnico
        '
        Me.CheckUsuarioUnico.BackColor = System.Drawing.Color.Chocolate
        Me.CheckUsuarioUnico.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckUsuarioUnico.Checked = True
        Me.CheckUsuarioUnico.CheckedOnColor = System.Drawing.Color.Chocolate
        Me.CheckUsuarioUnico.Enabled = False
        Me.CheckUsuarioUnico.ForeColor = System.Drawing.Color.White
        Me.CheckUsuarioUnico.Location = New System.Drawing.Point(328, 28)
        Me.CheckUsuarioUnico.Name = "CheckUsuarioUnico"
        Me.CheckUsuarioUnico.Size = New System.Drawing.Size(20, 20)
        Me.CheckUsuarioUnico.TabIndex = 530
        Me.CheckUsuarioUnico.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(350, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 531
        Me.Label6.Text = "Usuario único"
        Me.Label6.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 14)
        Me.Label4.TabIndex = 230
        Me.Label4.Text = "Vendedor"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(121, 7)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 14)
        Me.Label17.TabIndex = 229
        Me.Label17.Text = "Cajero habilitado"
        '
        'ComboCaja
        '
        Me.ComboCaja.BackColor = System.Drawing.Color.White
        Me.ComboCaja.BeforeTouchSize = New System.Drawing.Size(197, 21)
        Me.ComboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCaja.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCaja.Location = New System.Drawing.Point(124, 27)
        Me.ComboCaja.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboCaja.Name = "ComboCaja"
        Me.ComboCaja.Size = New System.Drawing.Size(197, 21)
        Me.ComboCaja.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCaja.TabIndex = 20
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
        Me.GradientPanel9.Size = New System.Drawing.Size(954, 33)
        Me.GradientPanel9.TabIndex = 511
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btGrabar, Me.ToolStripSeparator2, Me.ToolImportar, Me.ToolStripLabel3, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(952, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btGrabar
        '
        Me.btGrabar.BackColor = System.Drawing.Color.Transparent
        Me.btGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btGrabar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGrabar.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(76, 28)
        Me.btGrabar.Text = "Guardar - F2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'ToolImportar
        '
        Me.ToolImportar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolImportar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolImportar.Image = CType(resources.GetObject("ToolImportar.Image"), System.Drawing.Image)
        Me.ToolImportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolImportar.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolImportar.Name = "ToolImportar"
        Me.ToolImportar.Size = New System.Drawing.Size(99, 28)
        Me.ToolImportar.Text = "Canasta - F3"
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
        Me.ToolStripLabel3.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'GradientPanel10
        '
        Me.GradientPanel10.BackColor = System.Drawing.Color.White
        Me.GradientPanel10.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel10.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel10.Controls.Add(Me.GroupBox3)
        Me.GradientPanel10.Controls.Add(Me.GroupBox6)
        Me.GradientPanel10.Controls.Add(Me.GroupBox5)
        Me.GradientPanel10.Controls.Add(Me.GroupBox4)
        Me.GradientPanel10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel10.Location = New System.Drawing.Point(1, 99)
        Me.GradientPanel10.Name = "GradientPanel10"
        Me.GradientPanel10.Size = New System.Drawing.Size(949, 111)
        Me.GradientPanel10.TabIndex = 512
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ComboFechaVencimiento)
        Me.GroupBox3.Controls.Add(Me.txtFechaVencimiento)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(685, 52)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(245, 52)
        Me.GroupBox3.TabIndex = 560
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha Vencimiento"
        Me.GroupBox3.Visible = False
        '
        'ComboFechaVencimiento
        '
        Me.ComboFechaVencimiento.BackColor = System.Drawing.Color.White
        Me.ComboFechaVencimiento.BeforeTouchSize = New System.Drawing.Size(142, 21)
        Me.ComboFechaVencimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFechaVencimiento.FlatBorderColor = System.Drawing.Color.OrangeRed
        Me.ComboFechaVencimiento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboFechaVencimiento.Items.AddRange(New Object() {"30 DIAS", "60 DIAS", "90 DIAS A MAS"})
        Me.ComboFechaVencimiento.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboFechaVencimiento, "30 DIAS"))
        Me.ComboFechaVencimiento.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboFechaVencimiento, "60 DIAS"))
        Me.ComboFechaVencimiento.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboFechaVencimiento, "90 DIAS A MAS"))
        Me.ComboFechaVencimiento.Location = New System.Drawing.Point(8, 20)
        Me.ComboFechaVencimiento.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboFechaVencimiento.MetroColor = System.Drawing.Color.Silver
        Me.ComboFechaVencimiento.Name = "ComboFechaVencimiento"
        Me.ComboFechaVencimiento.Size = New System.Drawing.Size(142, 21)
        Me.ComboFechaVencimiento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboFechaVencimiento.TabIndex = 500
        Me.ComboFechaVencimiento.Text = "30 DIAS"
        '
        'txtFechaVencimiento
        '
        Me.txtFechaVencimiento.BackColor = System.Drawing.Color.White
        Me.txtFechaVencimiento.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaVencimiento.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaVencimiento.Calendar.AllowMultipleSelection = False
        Me.txtFechaVencimiento.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVencimiento.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaVencimiento.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVencimiento.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVencimiento.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaVencimiento.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaVencimiento.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaVencimiento.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVencimiento.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVencimiento.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaVencimiento.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaVencimiento.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaVencimiento.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaVencimiento.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaVencimiento.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVencimiento.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVencimiento.Calendar.Name = "monthCalendar"
        Me.txtFechaVencimiento.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaVencimiento.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaVencimiento.Calendar.Size = New System.Drawing.Size(80, 174)
        Me.txtFechaVencimiento.Calendar.SizeToFit = True
        Me.txtFechaVencimiento.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVencimiento.Calendar.TabIndex = 0
        Me.txtFechaVencimiento.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaVencimiento.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVencimiento.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVencimiento.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVencimiento.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVencimiento.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaVencimiento.Calendar.NoneButton.Location = New System.Drawing.Point(4, 0)
        Me.txtFechaVencimiento.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaVencimiento.Calendar.NoneButton.Text = "None"
        Me.txtFechaVencimiento.Calendar.NoneButton.UseVisualStyle = True
        Me.txtFechaVencimiento.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.txtFechaVencimiento.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVencimiento.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVencimiento.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVencimiento.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVencimiento.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaVencimiento.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVencimiento.Calendar.TodayButton.Size = New System.Drawing.Size(80, 20)
        Me.txtFechaVencimiento.Calendar.TodayButton.Text = "Today"
        Me.txtFechaVencimiento.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaVencimiento.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVencimiento.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaVencimiento.Checked = False
        Me.txtFechaVencimiento.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaVencimiento.DropDownImage = Nothing
        Me.txtFechaVencimiento.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVencimiento.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVencimiento.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaVencimiento.EnableNullDate = False
        Me.txtFechaVencimiento.EnableNullKeys = False
        Me.txtFechaVencimiento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVencimiento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(154, 21)
        Me.txtFechaVencimiento.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVencimiento.MinValue = New Date(CType(0, Long))
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.ShowCheckBox = False
        Me.txtFechaVencimiento.ShowDropButton = False
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(82, 20)
        Me.txtFechaVencimiento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVencimiento.TabIndex = 1
        Me.txtFechaVencimiento.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.White
        Me.GroupBox6.Controls.Add(Me.CheckEfectivoDefault)
        Me.GroupBox6.Controls.Add(Me.TextValoranticipo)
        Me.GroupBox6.Controls.Add(Me.TextPagoAnticipoDisponible)
        Me.GroupBox6.Controls.Add(Me.LinkLabel1)
        Me.GroupBox6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox6.Location = New System.Drawing.Point(685, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(245, 47)
        Me.GroupBox6.TabIndex = 559
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Pago con anticipos"
        '
        'CheckEfectivoDefault
        '
        Me.CheckEfectivoDefault.AutoSize = True
        Me.CheckEfectivoDefault.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
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
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.ChPagoAvanzado)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.chCredito)
        Me.GroupBox5.Controls.Add(Me.BunifuCheckbox2)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox5.Location = New System.Drawing.Point(490, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(189, 100)
        Me.GroupBox5.TabIndex = 558
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos del pago"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(200, 105)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(178, 14)
        Me.Label25.TabIndex = 542
        Me.Label25.Text = "Otras formas de cobranza (Parcial)"
        '
        'BunifuCheckbox2
        '
        Me.BunifuCheckbox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BunifuCheckbox2.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BunifuCheckbox2.Checked = False
        Me.BunifuCheckbox2.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.BunifuCheckbox2.ForeColor = System.Drawing.Color.White
        Me.BunifuCheckbox2.Location = New System.Drawing.Point(179, 99)
        Me.BunifuCheckbox2.Name = "BunifuCheckbox2"
        Me.BunifuCheckbox2.Size = New System.Drawing.Size(20, 20)
        Me.BunifuCheckbox2.TabIndex = 541
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.cboTipoDoc)
        Me.GroupBox4.Controls.Add(Me.btnCliente)
        Me.GroupBox4.Controls.Add(Me.cboMoneda)
        Me.GroupBox4.Controls.Add(Me.txtruc)
        Me.GroupBox4.Controls.Add(Me.ProgressBar2)
        Me.GroupBox4.Controls.Add(Me.TXTcOMPRADOR)
        Me.GroupBox4.Controls.Add(Me.ProgressBar1)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox4.Location = New System.Drawing.Point(7, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(477, 100)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del comprobante de venta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(9, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 13)
        Me.Label9.TabIndex = 558
        Me.Label9.Text = "Cliente/Razón social"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label15)
        Me.GroupBox7.Controls.Add(Me.txtTienda)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Controls.Add(Me.Label3)
        Me.GroupBox7.Controls.Add(Me.TextOrdenventa)
        Me.GroupBox7.Controls.Add(Me.TextNumeroGuia)
        Me.GroupBox7.Location = New System.Drawing.Point(467, 38)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(482, 56)
        Me.GroupBox7.TabIndex = 513
        Me.GroupBox7.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(351, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 14)
        Me.Label15.TabIndex = 562
        Me.Label15.Text = "Tienda"
        '
        'txtTienda
        '
        Me.txtTienda.BackColor = System.Drawing.Color.White
        Me.txtTienda.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.txtTienda.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTienda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTienda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTienda.CornerRadius = 4
        Me.txtTienda.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTienda.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtTienda.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTienda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTienda.Location = New System.Drawing.Point(354, 26)
        Me.txtTienda.MaxLength = 20
        Me.txtTienda.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTienda.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTienda.Name = "txtTienda"
        Me.txtTienda.Size = New System.Drawing.Size(121, 22)
        Me.txtTienda.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTienda.TabIndex = 561
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(178, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 14)
        Me.Label5.TabIndex = 560
        Me.Label5.Text = "Nro. Orden Venta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 14)
        Me.Label3.TabIndex = 559
        Me.Label3.Text = "Nro. Guia"
        '
        'TextOrdenventa
        '
        Me.TextOrdenventa.BackColor = System.Drawing.Color.White
        Me.TextOrdenventa.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.TextOrdenventa.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextOrdenventa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextOrdenventa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextOrdenventa.CornerRadius = 4
        Me.TextOrdenventa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextOrdenventa.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextOrdenventa.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextOrdenventa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextOrdenventa.Location = New System.Drawing.Point(180, 28)
        Me.TextOrdenventa.MaxLength = 20
        Me.TextOrdenventa.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextOrdenventa.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextOrdenventa.Name = "TextOrdenventa"
        Me.TextOrdenventa.Size = New System.Drawing.Size(165, 22)
        Me.TextOrdenventa.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextOrdenventa.TabIndex = 558
        '
        'TextNumeroGuia
        '
        Me.TextNumeroGuia.BackColor = System.Drawing.Color.White
        Me.TextNumeroGuia.BeforeTouchSize = New System.Drawing.Size(159, 24)
        Me.TextNumeroGuia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumeroGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumeroGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumeroGuia.CornerRadius = 4
        Me.TextNumeroGuia.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumeroGuia.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNumeroGuia.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumeroGuia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNumeroGuia.Location = New System.Drawing.Point(18, 28)
        Me.TextNumeroGuia.MaxLength = 20
        Me.TextNumeroGuia.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumeroGuia.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumeroGuia.Name = "TextNumeroGuia"
        Me.TextNumeroGuia.Size = New System.Drawing.Size(152, 22)
        Me.TextNumeroGuia.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNumeroGuia.TabIndex = 557
        '
        'FormConfirmrarVentaVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 2
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ok_icon
        CaptionImage1.Location = New System.Drawing.Point(15, 9)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(16, 16)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(40, 4)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Venta: Caja"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(954, 576)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GradientPanel8)
        Me.Controls.Add(Me.GradientPanel10)
        Me.Controls.Add(Me.GradientPanel9)
        Me.Controls.Add(Me.gradientPanel2)
        Me.Controls.Add(Me.PanelCupon)
        Me.Controls.Add(Me.GradientPanel7)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.GradientPanel1)
        Me.MaximizeBox = False
        Me.Name = "FormConfirmrarVentaVendedor"
        Me.ShowIcon = False
        Me.Text = "Confirmrar Venta Vendedor"
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPercepcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        Me.GradientPanel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gradientPanel2.ResumeLayout(False)
        Me.gradientPanel2.PerformLayout()
        Me.pcLikeCategoria.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cbocajaPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLoading.ResumeLayout(False)
        Me.PanelLoading.PerformLayout()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextValoranticipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPagoAnticipoDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelCupon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCupon.ResumeLayout(False)
        Me.PanelCupon.PerformLayout()
        CType(Me.TextCodigoCupon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCuponImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        Me.GradientPanel7.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        Me.GradientPanel8.PerformLayout()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel9.ResumeLayout(False)
        Me.GradientPanel9.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GradientPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel10.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.ComboFechaVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVencimiento.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextOrdenventa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumeroGuia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
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
    Private WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents lblPagoVenta As Label
    Friend WithEvents ButtonAdv2 As ButtonAdv
    Friend WithEvents ButtonAdv3 As ButtonAdv
    Private WithEvents GradientPanel4 As Tools.GradientPanel
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
    Friend WithEvents LblPagoCredito As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents ChBanco As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label23 As Label
    Friend WithEvents ChEfectivo As Bunifu.Framework.UI.BunifuCheckbox
    Private WithEvents gradientPanel2 As Tools.GradientPanel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents chCobranzaParcial As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents chCredito As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ChPagoAvanzado As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label8 As Label
    Friend WithEvents ChPagoDirecto As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents cbocajaPago As Tools.ComboBoxAdv
    Friend WithEvents Label7 As Label
    Friend WithEvents PanelLoading As Panel
    Friend WithEvents ProgressBar4 As ProgressBar
    Friend WithEvents Label24 As Label
    Friend WithEvents cboMoneda As Tools.ComboBoxAdv
    Friend WithEvents chAutoNumeracion As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents txtNumero As Tools.TextBoxExt
    Friend WithEvents txtSerie As Tools.TextBoxExt
    Friend WithEvents cboTipoDoc As Tools.ComboBoxAdv
    Friend WithEvents txtFecha As Tools.DateTimePickerAdv
    Private WithEvents PanelCupon As Tools.GradientPanel
    Friend WithEvents ButtonAdv5 As ButtonAdv
    Friend WithEvents TextCodigoCupon As Tools.TextBoxExt
    Friend WithEvents TextCuponImporte As Tools.CurrencyTextBox
    Friend WithEvents ButtonAdv4 As ButtonAdv
    Private WithEvents GradientPanel7 As Tools.GradientPanel
    Friend WithEvents LabelCupon As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolTip1 As ToolTip
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Private WithEvents GradientPanel8 As Tools.GradientPanel
    Friend WithEvents TextCodigoVendedor As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents GradientPanel9 As Tools.GradientPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btGrabar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolImportar As ToolStripButton
    Friend WithEvents ComboCaja As Tools.ComboBoxAdv
    Friend WithEvents Label17 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextValoranticipo As Tools.CurrencyTextBox
    Friend WithEvents TextPagoAnticipoDisponible As Tools.CurrencyTextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents CheckUsuarioUnico As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents btnCliente As Button
    Friend WithEvents txtruc As Tools.TextBoxExt
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents TXTcOMPRADOR As Tools.TextBoxExt
    Private WithEvents GradientPanel10 As Tools.GradientPanel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label25 As Label
    Friend WithEvents BunifuCheckbox2 As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents CheckEfectivoDefault As CheckBox
    Friend WithEvents GradientPanel6 As Tools.GradientPanel
    Friend WithEvents txtTotalPagar As Tools.CurrencyTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GradientPanel5 As Tools.GradientPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtFechaVencimiento As Tools.DateTimePickerAdv
    Friend WithEvents ComboFechaVencimiento As Tools.ComboBoxAdv
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextOrdenventa As Tools.TextBoxExt
    Friend WithEvents TextNumeroGuia As Tools.TextBoxExt
    Friend WithEvents Label15 As Label
    Friend WithEvents txtTienda As Tools.TextBoxExt
    Friend WithEvents Button2 As Button
End Class

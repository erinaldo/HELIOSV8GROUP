Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConfirmaVentaV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfirmaVentaV2))
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
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.gradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chCobranzaParcial = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.chCredito = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChPagoAvanzado = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChPagoDirecto = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.cbocajaPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PanelLoading = New System.Windows.Forms.Panel()
        Me.ProgressBar4 = New System.Windows.Forms.ProgressBar()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.txtruc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.lblValidacion = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.chAutoNumeracion = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.txtTipoDocClie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TXTcOMPRADOR = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.LblPagoCredito = New System.Windows.Forms.Label()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.bgCombos = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.lblPagoVenta = New System.Windows.Forms.Label()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtTotalPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ChBanco = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ChEfectivo = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.txtVentaTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotalNotaVenta = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalBase = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalBase3 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblTotalPercepcion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalBase2 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTotalIva = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextTotalDescuentos = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LabelCupon = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PanelCupon = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.TextCodigoCupon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCuponImporte = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gradientPanel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cbocajaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLoading.SuspendLayout()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoDocClie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVentaTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalNotaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPercepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        CType(Me.PanelCupon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCupon.SuspendLayout()
        CType(Me.TextCodigoCupon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCuponImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gradientPanel2
        '
        Me.gradientPanel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.gradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.gradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gradientPanel2.Controls.Add(Me.GroupBox2)
        Me.gradientPanel2.Controls.Add(Me.GroupBox1)
        Me.gradientPanel2.Controls.Add(Me.PanelLoading)
        Me.gradientPanel2.Controls.Add(Me.btnCliente)
        Me.gradientPanel2.Controls.Add(Me.txtruc)
        Me.gradientPanel2.Controls.Add(Me.lblValidacion)
        Me.gradientPanel2.Controls.Add(Me.ProgressBar1)
        Me.gradientPanel2.Controls.Add(Me.Label5)
        Me.gradientPanel2.Controls.Add(Me.Label4)
        Me.gradientPanel2.Controls.Add(Me.Label3)
        Me.gradientPanel2.Controls.Add(Me.cboMoneda)
        Me.gradientPanel2.Controls.Add(Me.chAutoNumeracion)
        Me.gradientPanel2.Controls.Add(Me.txtTipoDocClie)
        Me.gradientPanel2.Controls.Add(Me.Label6)
        Me.gradientPanel2.Controls.Add(Me.Label2)
        Me.gradientPanel2.Controls.Add(Me.ProgressBar2)
        Me.gradientPanel2.Controls.Add(Me.txtNumero)
        Me.gradientPanel2.Controls.Add(Me.TXTcOMPRADOR)
        Me.gradientPanel2.Controls.Add(Me.txtSerie)
        Me.gradientPanel2.Controls.Add(Me.Label1)
        Me.gradientPanel2.Controls.Add(Me.cboTipoDoc)
        Me.gradientPanel2.Controls.Add(Me.txtFecha)
        Me.gradientPanel2.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gradientPanel2.Location = New System.Drawing.Point(13, 39)
        Me.gradientPanel2.Name = "gradientPanel2"
        Me.gradientPanel2.Size = New System.Drawing.Size(350, 399)
        Me.gradientPanel2.TabIndex = 16
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.chCobranzaParcial)
        Me.GroupBox2.Controls.Add(Me.chCredito)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 325)
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
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(32, 24)
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
        Me.chCobranzaParcial.Location = New System.Drawing.Point(11, 43)
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
        Me.chCredito.ForeColor = System.Drawing.Color.White
        Me.chCredito.Location = New System.Drawing.Point(11, 18)
        Me.chCredito.Name = "chCredito"
        Me.chCredito.Size = New System.Drawing.Size(20, 20)
        Me.chCredito.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChPagoAvanzado)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.ChPagoDirecto)
        Me.GroupBox1.Controls.Add(Me.cbocajaPago)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 252)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 67)
        Me.GroupBox1.TabIndex = 543
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Venta al contado"
        '
        'ChPagoAvanzado
        '
        Me.ChPagoAvanzado.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPagoAvanzado.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPagoAvanzado.Checked = False
        Me.ChPagoAvanzado.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChPagoAvanzado.ForeColor = System.Drawing.Color.White
        Me.ChPagoAvanzado.Location = New System.Drawing.Point(13, 42)
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
        Me.Label8.Location = New System.Drawing.Point(34, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 14)
        Me.Label8.TabIndex = 532
        Me.Label8.Text = "Otras formas de cobranza"
        '
        'ChPagoDirecto
        '
        Me.ChPagoDirecto.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ChPagoDirecto.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPagoDirecto.Checked = True
        Me.ChPagoDirecto.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.ChPagoDirecto.ForeColor = System.Drawing.Color.White
        Me.ChPagoDirecto.Location = New System.Drawing.Point(13, 21)
        Me.ChPagoDirecto.Name = "ChPagoDirecto"
        Me.ChPagoDirecto.Size = New System.Drawing.Size(20, 20)
        Me.ChPagoDirecto.TabIndex = 4
        '
        'cbocajaPago
        '
        Me.cbocajaPago.BackColor = System.Drawing.Color.White
        Me.cbocajaPago.BeforeTouchSize = New System.Drawing.Size(146, 21)
        Me.cbocajaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocajaPago.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbocajaPago.Location = New System.Drawing.Point(159, 21)
        Me.cbocajaPago.MetroBorderColor = System.Drawing.Color.Silver
        Me.cbocajaPago.Name = "cbocajaPago"
        Me.cbocajaPago.Size = New System.Drawing.Size(146, 21)
        Me.cbocajaPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbocajaPago.TabIndex = 528
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
        '
        'PanelLoading
        '
        Me.PanelLoading.Controls.Add(Me.ProgressBar4)
        Me.PanelLoading.Controls.Add(Me.Label24)
        Me.PanelLoading.Location = New System.Drawing.Point(20, 173)
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
        'btnCliente
        '
        Me.btnCliente.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.anadir_user_icon
        Me.btnCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCliente.FlatAppearance.BorderSize = 0
        Me.btnCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCliente.Location = New System.Drawing.Point(196, 173)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(25, 26)
        Me.btnCliente.TabIndex = 540
        Me.btnCliente.Text = "N"
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtruc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtruc.BorderColor = System.Drawing.Color.Silver
        Me.txtruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtruc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtruc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtruc.Location = New System.Drawing.Point(20, 177)
        Me.txtruc.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtruc.Name = "txtruc"
        Me.txtruc.NearImage = CType(resources.GetObject("txtruc.NearImage"), System.Drawing.Image)
        Me.txtruc.Size = New System.Drawing.Size(171, 22)
        Me.txtruc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtruc.TabIndex = 3
        '
        'lblValidacion
        '
        Me.lblValidacion.AutoSize = True
        Me.lblValidacion.BackColor = System.Drawing.Color.Transparent
        Me.lblValidacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidacion.ForeColor = System.Drawing.Color.Blue
        Me.lblValidacion.Location = New System.Drawing.Point(228, 182)
        Me.lblValidacion.Name = "lblValidacion"
        Me.lblValidacion.Size = New System.Drawing.Size(50, 15)
        Me.lblValidacion.TabIndex = 537
        Me.lblValidacion.Text = "VALIDO"
        Me.lblValidacion.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(290, 161)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar1.TabIndex = 535
        Me.ProgressBar1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(17, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 15)
        Me.Label5.TabIndex = 534
        Me.Label5.Text = "Tipo Comprobante"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 15)
        Me.Label4.TabIndex = 527
        Me.Label4.Text = "Información del pago"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(208, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 526
        Me.Label3.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(116, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Enabled = False
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERA"})
        Me.cboMoneda.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMoneda, "NACIONAL"))
        Me.cboMoneda.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMoneda, "EXTRANJERA"))
        Me.cboMoneda.Location = New System.Drawing.Point(211, 24)
        Me.cboMoneda.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(116, 21)
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
        Me.chAutoNumeracion.Location = New System.Drawing.Point(224, 125)
        Me.chAutoNumeracion.Name = "chAutoNumeracion"
        Me.chAutoNumeracion.Size = New System.Drawing.Size(20, 20)
        Me.chAutoNumeracion.TabIndex = 519
        Me.chAutoNumeracion.Visible = False
        '
        'txtTipoDocClie
        '
        Me.txtTipoDocClie.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTipoDocClie.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTipoDocClie.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTipoDocClie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoDocClie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoDocClie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoDocClie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoDocClie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoDocClie.Location = New System.Drawing.Point(21, 177)
        Me.txtTipoDocClie.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTipoDocClie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoDocClie.Name = "txtTipoDocClie"
        Me.txtTipoDocClie.NearImage = CType(resources.GetObject("txtTipoDocClie.NearImage"), System.Drawing.Image)
        Me.txtTipoDocClie.ReadOnly = True
        Me.txtTipoDocClie.Size = New System.Drawing.Size(63, 22)
        Me.txtTipoDocClie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTipoDocClie.TabIndex = 524
        Me.txtTipoDocClie.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 15)
        Me.Label6.TabIndex = 508
        Me.Label6.Text = "Serie-nro."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(21, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 15)
        Me.Label2.TabIndex = 523
        Me.Label2.Text = "Información del cliente"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(211, 63)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 507
        Me.ProgressBar2.Visible = False
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNumero.BorderColor = System.Drawing.Color.LightGray
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumero.Location = New System.Drawing.Point(100, 123)
        Me.txtNumero.Metrocolor = System.Drawing.Color.LightGray
        Me.txtNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(121, 22)
        Me.txtNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumero.TabIndex = 2
        Me.txtNumero.Visible = False
        '
        'TXTcOMPRADOR
        '
        Me.TXTcOMPRADOR.BackColor = System.Drawing.Color.White
        Me.TXTcOMPRADOR.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TXTcOMPRADOR.BorderColor = System.Drawing.Color.LightGray
        Me.TXTcOMPRADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTcOMPRADOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTcOMPRADOR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTcOMPRADOR.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TXTcOMPRADOR.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTcOMPRADOR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTcOMPRADOR.Location = New System.Drawing.Point(20, 205)
        Me.TXTcOMPRADOR.Metrocolor = System.Drawing.Color.LightGray
        Me.TXTcOMPRADOR.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTcOMPRADOR.Name = "TXTcOMPRADOR"
        Me.TXTcOMPRADOR.NearImage = CType(resources.GetObject("TXTcOMPRADOR.NearImage"), System.Drawing.Image)
        Me.TXTcOMPRADOR.ReadOnly = True
        Me.TXTcOMPRADOR.Size = New System.Drawing.Size(303, 22)
        Me.TXTcOMPRADOR.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TXTcOMPRADOR.TabIndex = 521
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtSerie.BorderColor = System.Drawing.Color.LightGray
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtSerie.Location = New System.Drawing.Point(20, 123)
        Me.txtSerie.Metrocolor = System.Drawing.Color.LightGray
        Me.txtSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(76, 22)
        Me.txtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtSerie.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 15)
        Me.Label1.TabIndex = 404
        Me.Label1.Text = "Información del Comprobante"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(224, 21)
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(20, 76)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(224, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 0
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
        Me.txtFecha.Calendar.Size = New System.Drawing.Size(161, 174)
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
        Me.txtFecha.Calendar.NoneButton.Location = New System.Drawing.Point(85, 0)
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
        Me.txtFecha.Calendar.TodayButton.Size = New System.Drawing.Size(161, 20)
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
        Me.txtFecha.ForeColor = System.Drawing.Color.Black
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(20, 24)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(165, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 50
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'LblPagoCredito
        '
        Me.LblPagoCredito.AutoSize = True
        Me.LblPagoCredito.BackColor = System.Drawing.Color.Transparent
        Me.LblPagoCredito.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPagoCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.LblPagoCredito.Location = New System.Drawing.Point(339, 76)
        Me.LblPagoCredito.Name = "LblPagoCredito"
        Me.LblPagoCredito.Size = New System.Drawing.Size(254, 37)
        Me.LblPagoCredito.TabIndex = 533
        Me.LblPagoCredito.Text = "VENTA AL CREDITO"
        Me.LblPagoCredito.Visible = False
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BackgroundImage = CType(resources.GetObject("btOperacion.BackgroundImage"), System.Drawing.Image)
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(146, 33)
        Me.btOperacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btOperacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(882, 4)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(146, 33)
        Me.btOperacion.TabIndex = 17
        Me.btOperacion.UseVisualStyle = True
        '
        'bgCombos
        '
        Me.bgCombos.WorkerSupportsCancellation = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.lblPagoVenta)
        Me.GradientPanel1.Controls.Add(Me.GradientPanel5)
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv3)
        Me.GradientPanel1.Controls.Add(Me.GradientPanel4)
        Me.GradientPanel1.Controls.Add(Me.LblPagoCredito)
        Me.GradientPanel1.Controls.Add(Me.Label21)
        Me.GradientPanel1.Controls.Add(Me.ChBanco)
        Me.GradientPanel1.Controls.Add(Me.Label23)
        Me.GradientPanel1.Controls.Add(Me.ChEfectivo)
        Me.GradientPanel1.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel1.Location = New System.Drawing.Point(369, 39)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(714, 341)
        Me.GradientPanel1.TabIndex = 18
        '
        'lblPagoVenta
        '
        Me.lblPagoVenta.AutoSize = True
        Me.lblPagoVenta.BackColor = System.Drawing.Color.Transparent
        Me.lblPagoVenta.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.lblPagoVenta.Location = New System.Drawing.Point(397, 45)
        Me.lblPagoVenta.Name = "lblPagoVenta"
        Me.lblPagoVenta.Size = New System.Drawing.Size(69, 37)
        Me.lblPagoVenta.TabIndex = 534
        Me.lblPagoVenta.Text = "0.00"
        Me.lblPagoVenta.Visible = False
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel5.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel5.Controls.Add(Me.GradientPanel6)
        Me.GradientPanel5.Location = New System.Drawing.Point(3, 3)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(655, 29)
        Me.GradientPanel5.TabIndex = 405
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel6.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Controls.Add(Me.txtTotalPagar)
        Me.GradientPanel6.Controls.Add(Me.Label13)
        Me.GradientPanel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel6.Location = New System.Drawing.Point(0, -3)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(655, 32)
        Me.GradientPanel6.TabIndex = 222
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTotalPagar.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTotalPagar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalPagar.CornerRadius = 5
        Me.txtTotalPagar.CurrencySymbol = ""
        Me.txtTotalPagar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPagar.Location = New System.Drawing.Point(509, 8)
        Me.txtTotalPagar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.NullString = ""
        Me.txtTotalPagar.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTotalPagar.Size = New System.Drawing.Size(141, 19)
        Me.txtTotalPagar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalPagar.TabIndex = 495
        Me.txtTotalPagar.Text = "0.00"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 15)
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
        Me.ButtonAdv2.Location = New System.Drawing.Point(628, 34)
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
        Me.ButtonAdv3.Location = New System.Drawing.Point(601, 34)
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
        Me.GradientPanel4.Location = New System.Drawing.Point(3, 87)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(706, 249)
        Me.GradientPanel4.TabIndex = 523
        '
        'dgvCuentas
        '
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCuentas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuentas.FreezeCaption = False
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.Size = New System.Drawing.Size(704, 247)
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
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "entidad"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 150
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
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Forma de Pago"
        GridColumnDescriptor7.MappingName = "formaPago"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 300
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "N°Op."
        GridColumnDescriptor8.MappingName = "nrooperacion"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 70
        Me.dgvCuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CellType = "TextBox"
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
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
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("formaPago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("abonado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nrooperacion")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
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
        'txtVentaTotal
        '
        Me.txtVentaTotal.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtVentaTotal.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtVentaTotal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtVentaTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVentaTotal.CornerRadius = 5
        Me.txtVentaTotal.CurrencySymbol = ""
        Me.txtVentaTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtVentaTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVentaTotal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentaTotal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtVentaTotal.Location = New System.Drawing.Point(117, 523)
        Me.txtVentaTotal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtVentaTotal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtVentaTotal.Name = "txtVentaTotal"
        Me.txtVentaTotal.NullString = ""
        Me.txtVentaTotal.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.txtVentaTotal.ReadOnly = True
        Me.txtVentaTotal.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtVentaTotal.Size = New System.Drawing.Size(141, 15)
        Me.txtVentaTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtVentaTotal.TabIndex = 502
        Me.txtVentaTotal.Text = "0.00"
        Me.txtVentaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtVentaTotal.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.Location = New System.Drawing.Point(27, 523)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 501
        Me.Label15.Text = "Venta Total Doc."
        Me.Label15.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(284, 501)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 15)
        Me.Label17.TabIndex = 404
        Me.Label17.Text = "Importes del pago"
        Me.Label17.Visible = False
        '
        'txtTotalNotaVenta
        '
        Me.txtTotalNotaVenta.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalNotaVenta.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTotalNotaVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalNotaVenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalNotaVenta.CornerRadius = 5
        Me.txtTotalNotaVenta.CurrencySymbol = ""
        Me.txtTotalNotaVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalNotaVenta.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNotaVenta.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNotaVenta.ForeColor = System.Drawing.Color.Green
        Me.txtTotalNotaVenta.Location = New System.Drawing.Point(117, 502)
        Me.txtTotalNotaVenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalNotaVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalNotaVenta.Name = "txtTotalNotaVenta"
        Me.txtTotalNotaVenta.NullString = ""
        Me.txtTotalNotaVenta.PositiveColor = System.Drawing.Color.Green
        Me.txtTotalNotaVenta.ReadOnly = True
        Me.txtTotalNotaVenta.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalNotaVenta.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalNotaVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalNotaVenta.TabIndex = 500
        Me.txtTotalNotaVenta.Text = "0.00"
        Me.txtTotalNotaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalNotaVenta.Visible = False
        '
        'txtTotalBase
        '
        Me.txtTotalBase.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTotalBase.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase.CornerRadius = 5
        Me.txtTotalBase.CurrencySymbol = ""
        Me.txtTotalBase.Cursor = System.Windows.Forms.Cursors.Arrow
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
        Me.txtTotalBase.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalBase.TabIndex = 494
        Me.txtTotalBase.Text = "0.00"
        Me.txtTotalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Green
        Me.Label9.Location = New System.Drawing.Point(31, 497)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 499
        Me.Label9.Text = "Venta Total Not."
        Me.Label9.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
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
        Me.txtTotalBase3.BeforeTouchSize = New System.Drawing.Size(100, 20)
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
        Me.txtTotalBase3.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase3.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase3.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalBase3.TabIndex = 498
        Me.txtTotalBase3.Text = "0.00"
        Me.txtTotalBase3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(382, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "IGV"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(382, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 497
        Me.Label10.Text = "Op. Inafecta"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(17, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Op. Exonerada"
        '
        'lblTotalPercepcion
        '
        Me.lblTotalPercepcion.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.lblTotalPercepcion.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.lblTotalPercepcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPercepcion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblTotalPercepcion.CornerRadius = 5
        Me.lblTotalPercepcion.CurrencySymbol = ""
        Me.lblTotalPercepcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblTotalPercepcion.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.lblTotalPercepcion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPercepcion.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPercepcion.Location = New System.Drawing.Point(835, 6)
        Me.lblTotalPercepcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPercepcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.lblTotalPercepcion.Name = "lblTotalPercepcion"
        Me.lblTotalPercepcion.NullString = ""
        Me.lblTotalPercepcion.PositiveColor = System.Drawing.Color.Black
        Me.lblTotalPercepcion.ReadOnly = True
        Me.lblTotalPercepcion.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.lblTotalPercepcion.Size = New System.Drawing.Size(141, 15)
        Me.lblTotalPercepcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.lblTotalPercepcion.TabIndex = 496
        Me.lblTotalPercepcion.Text = "0.00"
        Me.lblTotalPercepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBase2
        '
        Me.txtTotalBase2.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase2.BeforeTouchSize = New System.Drawing.Size(100, 20)
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
        Me.txtTotalBase2.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase2.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalBase2.TabIndex = 492
        Me.txtTotalBase2.Text = "0.00"
        Me.txtTotalBase2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(745, 6)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 495
        Me.Label22.Text = "Rendondeo"
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIva.BeforeTouchSize = New System.Drawing.Size(100, 20)
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
        Me.txtTotalIva.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIva.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalIva.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalIva.TabIndex = 493
        Me.txtTotalIva.Text = "0.00"
        Me.txtTotalIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(1090, 27)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 432
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
        'GradientPanel3
        '
        Me.GradientPanel3.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
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
        Me.GradientPanel3.Location = New System.Drawing.Point(13, 444)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(1019, 48)
        Me.GradientPanel3.TabIndex = 433
        '
        'TextTotalDescuentos
        '
        Me.TextTotalDescuentos.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.TextTotalDescuentos.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextTotalDescuentos.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextTotalDescuentos.CornerRadius = 5
        Me.TextTotalDescuentos.CurrencySymbol = ""
        Me.TextTotalDescuentos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTotalDescuentos.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextTotalDescuentos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalDescuentos.ForeColor = System.Drawing.Color.Black
        Me.TextTotalDescuentos.Location = New System.Drawing.Point(835, 26)
        Me.TextTotalDescuentos.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTotalDescuentos.Name = "TextTotalDescuentos"
        Me.TextTotalDescuentos.NullString = ""
        Me.TextTotalDescuentos.PositiveColor = System.Drawing.Color.Black
        Me.TextTotalDescuentos.ReadOnly = True
        Me.TextTotalDescuentos.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.TextTotalDescuentos.Size = New System.Drawing.Size(141, 15)
        Me.TextTotalDescuentos.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextTotalDescuentos.TabIndex = 500
        Me.TextTotalDescuentos.Text = "0.00"
        Me.TextTotalDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(746, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 499
        Me.Label19.Text = "Descuentos"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv1.BackgroundImage = CType(resources.GetObject("ButtonAdv1.BackgroundImage"), System.Drawing.Image)
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(146, 33)
        Me.ButtonAdv1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButtonAdv1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(730, 4)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(146, 33)
        Me.ButtonAdv1.TabIndex = 501
        Me.ButtonAdv1.UseVisualStyle = True
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
        Me.GradientPanel7.Location = New System.Drawing.Point(730, 384)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(302, 55)
        Me.GradientPanel7.TabIndex = 503
        Me.GradientPanel7.Visible = False
        '
        'LabelCupon
        '
        Me.LabelCupon.AutoSize = True
        Me.LabelCupon.BackColor = System.Drawing.Color.Transparent
        Me.LabelCupon.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCupon.ForeColor = System.Drawing.Color.OrangeRed
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
        'PanelCupon
        '
        Me.PanelCupon.BackColor = System.Drawing.Color.White
        Me.PanelCupon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelCupon.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.PanelCupon.BorderColor = System.Drawing.Color.Green
        Me.PanelCupon.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.PanelCupon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelCupon.Controls.Add(Me.ButtonAdv5)
        Me.PanelCupon.Controls.Add(Me.TextCodigoCupon)
        Me.PanelCupon.Controls.Add(Me.TextCuponImporte)
        Me.PanelCupon.Controls.Add(Me.ButtonAdv4)
        Me.PanelCupon.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelCupon.Location = New System.Drawing.Point(369, 384)
        Me.PanelCupon.Name = "PanelCupon"
        Me.PanelCupon.Size = New System.Drawing.Size(355, 55)
        Me.PanelCupon.TabIndex = 504
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
        Me.ButtonAdv5.Location = New System.Drawing.Point(306, 12)
        Me.ButtonAdv5.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(28, 28)
        Me.ButtonAdv5.TabIndex = 529
        Me.ToolTip1.SetToolTip(Me.ButtonAdv5, "Limpiar")
        Me.ButtonAdv5.UseVisualStyle = True
        Me.ButtonAdv5.Visible = False
        '
        'TextCodigoCupon
        '
        Me.TextCodigoCupon.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Código de cupón ....."
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextCodigoCupon, BannerTextInfo1)
        Me.TextCodigoCupon.BeforeTouchSize = New System.Drawing.Size(100, 20)
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
        Me.TextCodigoCupon.Size = New System.Drawing.Size(183, 24)
        Me.TextCodigoCupon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoCupon.TabIndex = 528
        Me.TextCodigoCupon.Visible = False
        '
        'TextCuponImporte
        '
        Me.TextCuponImporte.BackGroundColor = System.Drawing.Color.White
        Me.TextCuponImporte.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCuponImporte.BorderColor = System.Drawing.Color.Silver
        Me.TextCuponImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCuponImporte.CurrencySymbol = ""
        Me.TextCuponImporte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCuponImporte.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextCuponImporte.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCuponImporte.ForeColor = System.Drawing.Color.Black
        Me.TextCuponImporte.Location = New System.Drawing.Point(193, 13)
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
        Me.ButtonAdv4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(251, 13)
        Me.ButtonAdv4.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(53, 25)
        Me.ButtonAdv4.TabIndex = 526
        Me.ButtonAdv4.Text = ". Cupon ."
        Me.ButtonAdv4.UseVisualStyle = True
        Me.ButtonAdv4.Visible = False
        '
        'FormConfirmaVentaV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Confirmar venta"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1083, 494)
        Me.Controls.Add(Me.PanelCupon)
        Me.Controls.Add(Me.GradientPanel7)
        Me.Controls.Add(Me.txtVentaTotal)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btOperacion)
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Controls.Add(Me.txtTotalNotaVenta)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.gradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormConfirmaVentaV2"
        Me.ShowIcon = False
        Me.Text = "Confirma venta"
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gradientPanel2.ResumeLayout(False)
        Me.gradientPanel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cbocajaPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLoading.ResumeLayout(False)
        Me.PanelLoading.PerformLayout()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoDocClie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVentaTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalNotaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPercepcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        Me.GradientPanel7.PerformLayout()
        CType(Me.PanelCupon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCupon.ResumeLayout(False)
        Me.PanelCupon.PerformLayout()
        CType(Me.TextCodigoCupon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCuponImporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents gradientPanel2 As Tools.GradientPanel
    Friend WithEvents chAutoNumeracion As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label6 As Label
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents txtNumero As Tools.TextBoxExt
    Friend WithEvents txtSerie As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents cboTipoDoc As Tools.ComboBoxAdv
    Friend WithEvents txtFecha As Tools.DateTimePickerAdv
    Friend WithEvents txtTipoDocClie As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents txtruc As Tools.TextBoxExt
    Friend WithEvents TXTcOMPRADOR As Tools.TextBoxExt
    Friend WithEvents cboMoneda As Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents LblPagoCredito As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ChPagoAvanzado As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents ChPagoDirecto As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbocajaPago As Tools.ComboBoxAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btOperacion As ButtonAdv
    Friend WithEvents bgCombos As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Private WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents Label17 As Label
    Friend WithEvents txtVentaTotal As Tools.CurrencyTextBox
    Friend WithEvents GradientPanel5 As Tools.GradientPanel
    Friend WithEvents GradientPanel6 As Tools.GradientPanel
    Friend WithEvents txtTotalPagar As Tools.CurrencyTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtTotalNotaVenta As Tools.CurrencyTextBox
    Friend WithEvents txtTotalBase As Tools.CurrencyTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtTotalBase3 As Tools.CurrencyTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblTotalPercepcion As Tools.CurrencyTextBox
    Friend WithEvents txtTotalBase2 As Tools.CurrencyTextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtTotalIva As Tools.CurrencyTextBox
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Friend WithEvents chCredito As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label16 As Label
    Private WithEvents GradientPanel3 As Tools.GradientPanel
    Friend WithEvents lblValidacion As Label
    Friend WithEvents ButtonAdv1 As ButtonAdv
    Friend WithEvents ButtonAdv2 As ButtonAdv
    Private WithEvents GradientPanel4 As Tools.GradientPanel
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
    Friend WithEvents Label21 As Label
    Friend WithEvents ChBanco As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label23 As Label
    Friend WithEvents ChEfectivo As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents PanelLoading As Panel
    Friend WithEvents ProgressBar4 As ProgressBar
    Friend WithEvents Label24 As Label
    Friend WithEvents btnCliente As Button
    Friend WithEvents ButtonAdv3 As ButtonAdv
    Friend WithEvents Label18 As Label
    Friend WithEvents chCobranzaParcial As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblPagoVenta As Label
    Friend WithEvents TextTotalDescuentos As Tools.CurrencyTextBox
    Friend WithEvents Label19 As Label
    Private WithEvents GradientPanel7 As Tools.GradientPanel
    Friend WithEvents Label20 As Label
    Friend WithEvents LabelCupon As Label
    Private WithEvents PanelCupon As Tools.GradientPanel
    Friend WithEvents TextCuponImporte As Tools.CurrencyTextBox
    Friend WithEvents ButtonAdv4 As ButtonAdv
    Friend WithEvents TextCodigoCupon As Tools.TextBoxExt
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents ButtonAdv5 As ButtonAdv
    Friend WithEvents ToolTip1 As ToolTip
End Class

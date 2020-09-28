Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConfirmaVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfirmaVenta))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.gradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblPagoCredito = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChPagoAvanzado = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.ChPagoDirecto = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbocajaPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.chAutoNumeracion = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.txtTipoDocClie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.txtruc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TXTcOMPRADOR = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.bgCombos = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtVentaTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtTotalPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
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
        Me.TextTotalDescuentos = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalBase2 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTotalIva = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gradientPanel2.SuspendLayout()
        CType(Me.cbocajaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoDocClie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtVentaTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalNotaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        Me.SuspendLayout()
        '
        'gradientPanel2
        '
        Me.gradientPanel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.gradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.gradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gradientPanel2.Controls.Add(Me.ProgressBar1)
        Me.gradientPanel2.Controls.Add(Me.Label5)
        Me.gradientPanel2.Controls.Add(Me.LblPagoCredito)
        Me.gradientPanel2.Controls.Add(Me.Label8)
        Me.gradientPanel2.Controls.Add(Me.ChPagoAvanzado)
        Me.gradientPanel2.Controls.Add(Me.ChPagoDirecto)
        Me.gradientPanel2.Controls.Add(Me.Label7)
        Me.gradientPanel2.Controls.Add(Me.cbocajaPago)
        Me.gradientPanel2.Controls.Add(Me.Label4)
        Me.gradientPanel2.Controls.Add(Me.Label3)
        Me.gradientPanel2.Controls.Add(Me.cboMoneda)
        Me.gradientPanel2.Controls.Add(Me.chAutoNumeracion)
        Me.gradientPanel2.Controls.Add(Me.txtTipoDocClie)
        Me.gradientPanel2.Controls.Add(Me.Label6)
        Me.gradientPanel2.Controls.Add(Me.Label2)
        Me.gradientPanel2.Controls.Add(Me.ProgressBar2)
        Me.gradientPanel2.Controls.Add(Me.txtruc)
        Me.gradientPanel2.Controls.Add(Me.txtNumero)
        Me.gradientPanel2.Controls.Add(Me.TXTcOMPRADOR)
        Me.gradientPanel2.Controls.Add(Me.txtSerie)
        Me.gradientPanel2.Controls.Add(Me.Label1)
        Me.gradientPanel2.Controls.Add(Me.cboTipoDoc)
        Me.gradientPanel2.Controls.Add(Me.txtFecha)
        Me.gradientPanel2.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gradientPanel2.Location = New System.Drawing.Point(13, 19)
        Me.gradientPanel2.Name = "gradientPanel2"
        Me.gradientPanel2.Size = New System.Drawing.Size(350, 395)
        Me.gradientPanel2.TabIndex = 16
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(290, 181)
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
        Me.Label5.Location = New System.Drawing.Point(17, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 15)
        Me.Label5.TabIndex = 534
        Me.Label5.Text = "Tipo Comprobante"
        '
        'LblPagoCredito
        '
        Me.LblPagoCredito.AutoSize = True
        Me.LblPagoCredito.BackColor = System.Drawing.Color.Transparent
        Me.LblPagoCredito.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPagoCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.LblPagoCredito.Location = New System.Drawing.Point(17, 364)
        Me.LblPagoCredito.Name = "LblPagoCredito"
        Me.LblPagoCredito.Size = New System.Drawing.Size(113, 15)
        Me.LblPagoCredito.TabIndex = 533
        Me.LblPagoCredito.Text = "VENTA AL CREDITO"
        Me.LblPagoCredito.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(189, 337)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 14)
        Me.Label8.TabIndex = 532
        Me.Label8.Text = "Otras formas de cobranza"
        '
        'ChPagoAvanzado
        '
        Me.ChPagoAvanzado.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPagoAvanzado.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPagoAvanzado.Checked = False
        Me.ChPagoAvanzado.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChPagoAvanzado.ForeColor = System.Drawing.Color.White
        Me.ChPagoAvanzado.Location = New System.Drawing.Point(168, 335)
        Me.ChPagoAvanzado.Name = "ChPagoAvanzado"
        Me.ChPagoAvanzado.Size = New System.Drawing.Size(20, 20)
        Me.ChPagoAvanzado.TabIndex = 531
        '
        'ChPagoDirecto
        '
        Me.ChPagoDirecto.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ChPagoDirecto.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPagoDirecto.Checked = True
        Me.ChPagoDirecto.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.ChPagoDirecto.ForeColor = System.Drawing.Color.White
        Me.ChPagoDirecto.Location = New System.Drawing.Point(20, 335)
        Me.ChPagoDirecto.Name = "ChPagoDirecto"
        Me.ChPagoDirecto.Size = New System.Drawing.Size(20, 20)
        Me.ChPagoDirecto.TabIndex = 530
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(41, 338)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 14)
        Me.Label7.TabIndex = 529
        Me.Label7.Text = "Cobro Total - Caja única"
        '
        'cbocajaPago
        '
        Me.cbocajaPago.BackColor = System.Drawing.Color.White
        Me.cbocajaPago.BeforeTouchSize = New System.Drawing.Size(189, 21)
        Me.cbocajaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocajaPago.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbocajaPago.Location = New System.Drawing.Point(20, 361)
        Me.cbocajaPago.MetroBorderColor = System.Drawing.Color.Silver
        Me.cbocajaPago.Name = "cbocajaPago"
        Me.cbocajaPago.Size = New System.Drawing.Size(189, 21)
        Me.cbocajaPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbocajaPago.TabIndex = 528
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 311)
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
        Me.Label3.Location = New System.Drawing.Point(21, 257)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 526
        Me.Label3.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(201, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Enabled = False
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERA"})
        Me.cboMoneda.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMoneda, "NACIONAL"))
        Me.cboMoneda.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMoneda, "EXTRANJERA"))
        Me.cboMoneda.Location = New System.Drawing.Point(20, 278)
        Me.cboMoneda.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(201, 21)
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
        Me.chAutoNumeracion.Location = New System.Drawing.Point(224, 142)
        Me.chAutoNumeracion.Name = "chAutoNumeracion"
        Me.chAutoNumeracion.Size = New System.Drawing.Size(20, 20)
        Me.chAutoNumeracion.TabIndex = 519
        Me.chAutoNumeracion.Visible = False
        '
        'txtTipoDocClie
        '
        Me.txtTipoDocClie.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTipoDocClie.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtTipoDocClie.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTipoDocClie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoDocClie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoDocClie.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTipoDocClie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoDocClie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoDocClie.Location = New System.Drawing.Point(227, 225)
        Me.txtTipoDocClie.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTipoDocClie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoDocClie.Name = "txtTipoDocClie"
        Me.txtTipoDocClie.NearImage = CType(resources.GetObject("txtTipoDocClie.NearImage"), System.Drawing.Image)
        Me.txtTipoDocClie.ReadOnly = True
        Me.txtTipoDocClie.Size = New System.Drawing.Size(96, 22)
        Me.txtTipoDocClie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTipoDocClie.TabIndex = 524
        Me.txtTipoDocClie.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 120)
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
        Me.Label2.Location = New System.Drawing.Point(21, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 15)
        Me.Label2.TabIndex = 523
        Me.Label2.Text = "Información del cliente"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(211, 74)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 507
        Me.ProgressBar2.Visible = False
        '
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtruc.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtruc.BorderColor = System.Drawing.Color.Silver
        Me.txtruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtruc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtruc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtruc.Location = New System.Drawing.Point(20, 225)
        Me.txtruc.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtruc.Name = "txtruc"
        Me.txtruc.NearImage = CType(resources.GetObject("txtruc.NearImage"), System.Drawing.Image)
        Me.txtruc.ReadOnly = True
        Me.txtruc.Size = New System.Drawing.Size(121, 22)
        Me.txtruc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtruc.TabIndex = 522
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtNumero.BorderColor = System.Drawing.Color.LightGray
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumero.Location = New System.Drawing.Point(100, 140)
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
        Me.TXTcOMPRADOR.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.TXTcOMPRADOR.BorderColor = System.Drawing.Color.LightGray
        Me.TXTcOMPRADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTcOMPRADOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTcOMPRADOR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTcOMPRADOR.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TXTcOMPRADOR.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTcOMPRADOR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTcOMPRADOR.Location = New System.Drawing.Point(20, 197)
        Me.TXTcOMPRADOR.Metrocolor = System.Drawing.Color.LightGray
        Me.TXTcOMPRADOR.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTcOMPRADOR.Name = "TXTcOMPRADOR"
        Me.TXTcOMPRADOR.NearImage = CType(resources.GetObject("TXTcOMPRADOR.NearImage"), System.Drawing.Image)
        Me.TXTcOMPRADOR.Size = New System.Drawing.Size(303, 22)
        Me.TXTcOMPRADOR.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TXTcOMPRADOR.TabIndex = 521
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtSerie.BorderColor = System.Drawing.Color.LightGray
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtSerie.Location = New System.Drawing.Point(20, 140)
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
        Me.Label1.Location = New System.Drawing.Point(17, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 15)
        Me.Label1.TabIndex = 404
        Me.Label1.Text = "Información del Comprobante"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(224, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(20, 90)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(224, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 218
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
        Me.txtFecha.Location = New System.Drawing.Point(20, 38)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(165, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 0
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(120, 35)
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(316, 423)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(120, 35)
        Me.btOperacion.TabIndex = 17
        Me.btOperacion.Text = "Vender"
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
        Me.GradientPanel1.Controls.Add(Me.txtVentaTotal)
        Me.GradientPanel1.Controls.Add(Me.GradientPanel5)
        Me.GradientPanel1.Controls.Add(Me.Label15)
        Me.GradientPanel1.Controls.Add(Me.Label17)
        Me.GradientPanel1.Controls.Add(Me.txtTotalNotaVenta)
        Me.GradientPanel1.Controls.Add(Me.txtTotalBase)
        Me.GradientPanel1.Controls.Add(Me.Label9)
        Me.GradientPanel1.Controls.Add(Me.Label14)
        Me.GradientPanel1.Controls.Add(Me.txtTotalBase3)
        Me.GradientPanel1.Controls.Add(Me.Label12)
        Me.GradientPanel1.Controls.Add(Me.Label10)
        Me.GradientPanel1.Controls.Add(Me.Label11)
        Me.GradientPanel1.Controls.Add(Me.TextTotalDescuentos)
        Me.GradientPanel1.Controls.Add(Me.txtTotalBase2)
        Me.GradientPanel1.Controls.Add(Me.Label22)
        Me.GradientPanel1.Controls.Add(Me.txtTotalIva)
        Me.GradientPanel1.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel1.Location = New System.Drawing.Point(369, 19)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(376, 395)
        Me.GradientPanel1.TabIndex = 18
        '
        'txtVentaTotal
        '
        Me.txtVentaTotal.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtVentaTotal.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtVentaTotal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtVentaTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVentaTotal.CornerRadius = 5
        Me.txtVentaTotal.CurrencySymbol = ""
        Me.txtVentaTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVentaTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVentaTotal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentaTotal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtVentaTotal.Location = New System.Drawing.Point(227, 149)
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
        'GradientPanel5
        '
        Me.GradientPanel5.BackColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel5.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel5.Controls.Add(Me.GradientPanel6)
        Me.GradientPanel5.Location = New System.Drawing.Point(3, 361)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(368, 29)
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
        Me.GradientPanel6.Size = New System.Drawing.Size(368, 32)
        Me.GradientPanel6.TabIndex = 222
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTotalPagar.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtTotalPagar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalPagar.CornerRadius = 5
        Me.txtTotalPagar.CurrencySymbol = ""
        Me.txtTotalPagar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPagar.Location = New System.Drawing.Point(211, 8)
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
        Me.Label13.Size = New System.Drawing.Size(44, 15)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "TOTAL"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.Location = New System.Drawing.Point(21, 151)
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
        Me.Label17.Location = New System.Drawing.Point(17, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 15)
        Me.Label17.TabIndex = 404
        Me.Label17.Text = "Importes del pago"
        '
        'txtTotalNotaVenta
        '
        Me.txtTotalNotaVenta.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalNotaVenta.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtTotalNotaVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalNotaVenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalNotaVenta.CornerRadius = 5
        Me.txtTotalNotaVenta.CurrencySymbol = ""
        Me.txtTotalNotaVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalNotaVenta.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNotaVenta.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNotaVenta.ForeColor = System.Drawing.Color.Green
        Me.txtTotalNotaVenta.Location = New System.Drawing.Point(227, 169)
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
        Me.txtTotalBase.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtTotalBase.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase.CornerRadius = 5
        Me.txtTotalBase.CurrencySymbol = ""
        Me.txtTotalBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase.Location = New System.Drawing.Point(227, 43)
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
        Me.Label9.Location = New System.Drawing.Point(21, 171)
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
        Me.Label14.Location = New System.Drawing.Point(21, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Op. Gravada"
        '
        'txtTotalBase3
        '
        Me.txtTotalBase3.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase3.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtTotalBase3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase3.CornerRadius = 5
        Me.txtTotalBase3.CurrencySymbol = ""
        Me.txtTotalBase3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase3.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase3.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase3.Location = New System.Drawing.Point(227, 84)
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
        Me.Label12.Location = New System.Drawing.Point(21, 108)
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
        Me.Label10.Location = New System.Drawing.Point(21, 86)
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
        Me.Label11.Location = New System.Drawing.Point(21, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Op. Exonerada"
        '
        'TextTotalDescuentos
        '
        Me.TextTotalDescuentos.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.TextTotalDescuentos.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.TextTotalDescuentos.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextTotalDescuentos.CornerRadius = 5
        Me.TextTotalDescuentos.CurrencySymbol = ""
        Me.TextTotalDescuentos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextTotalDescuentos.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextTotalDescuentos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalDescuentos.ForeColor = System.Drawing.Color.Black
        Me.TextTotalDescuentos.Location = New System.Drawing.Point(227, 127)
        Me.TextTotalDescuentos.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTotalDescuentos.Name = "TextTotalDescuentos"
        Me.TextTotalDescuentos.NullString = ""
        Me.TextTotalDescuentos.PositiveColor = System.Drawing.Color.Black
        Me.TextTotalDescuentos.ReadOnly = True
        Me.TextTotalDescuentos.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.TextTotalDescuentos.Size = New System.Drawing.Size(141, 15)
        Me.TextTotalDescuentos.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextTotalDescuentos.TabIndex = 496
        Me.TextTotalDescuentos.Text = "0.00"
        Me.TextTotalDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBase2
        '
        Me.txtTotalBase2.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase2.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtTotalBase2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase2.CornerRadius = 5
        Me.txtTotalBase2.CurrencySymbol = ""
        Me.txtTotalBase2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase2.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase2.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase2.Location = New System.Drawing.Point(227, 63)
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
        Me.Label22.Location = New System.Drawing.Point(21, 129)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 495
        Me.Label22.Text = "Descuentos"
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIva.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtTotalIva.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalIva.CornerRadius = 5
        Me.txtTotalIva.CurrencySymbol = ""
        Me.txtTotalIva.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalIva.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIva.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.ForeColor = System.Drawing.Color.Black
        Me.txtTotalIva.Location = New System.Drawing.Point(227, 106)
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
        Me.pcLikeCategoria.Location = New System.Drawing.Point(768, 27)
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
        'FormConfirmaVenta
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
        Me.ClientSize = New System.Drawing.Size(756, 463)
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.btOperacion)
        Me.Controls.Add(Me.gradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormConfirmaVenta"
        Me.ShowIcon = False
        Me.Text = "Confirma venta"
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gradientPanel2.ResumeLayout(False)
        Me.gradientPanel2.PerformLayout()
        CType(Me.cbocajaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoDocClie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.txtVentaTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalNotaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        Me.ResumeLayout(False)

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
    Friend WithEvents TextTotalDescuentos As Tools.CurrencyTextBox
    Friend WithEvents txtTotalBase2 As Tools.CurrencyTextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtTotalIva As Tools.CurrencyTextBox
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
End Class

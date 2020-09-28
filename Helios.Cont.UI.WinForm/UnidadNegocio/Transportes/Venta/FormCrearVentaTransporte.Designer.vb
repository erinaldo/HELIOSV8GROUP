Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearVentaTransporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearVentaTransporte))
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
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.BtConfirmarVenta = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextCiudadDestino = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextDestinoUbigeo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextOrigenUbigeo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCiudadOrigen = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextNombres = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextTipoDocIdentidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCodigoIdentidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.textEdad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNumIdent = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.LabelAsientoSel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextFechaProgramada = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextRaZonSocial = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCodigoComprobanteRazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextTipoDocIdentidadRazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel9 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LblPagoCredito = New System.Windows.Forms.Label()
        Me.lblPagoVenta = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtTotalPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ChPagoAvanzado = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chCredito = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TextValoranticipo = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextPagoAnticipoDisponible = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
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
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboCaja = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextCodigoVendedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel11.SuspendLayout()
        CType(Me.TextCiudadDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDestinoUbigeo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextOrigenUbigeo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCiudadOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTipoDocIdentidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoIdentidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textEdad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumIdent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.TextRaZonSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoComprobanteRazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTipoDocIdentidadRazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.GradientPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel9.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.TextValoranticipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPagoAnticipoDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPercepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.Controls.Add(Me.RoundButton21)
        Me.Panel11.Controls.Add(Me.BtConfirmarVenta)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(898, 48)
        Me.Panel11.TabIndex = 504
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(153, 30)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(169, 9)
        Me.RoundButton21.MetroColor = System.Drawing.Color.IndianRed
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(153, 30)
        Me.RoundButton21.TabIndex = 605
        Me.RoundButton21.Text = "Cancelar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'BtConfirmarVenta
        '
        Me.BtConfirmarVenta.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.BtConfirmarVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.BtConfirmarVenta.BeforeTouchSize = New System.Drawing.Size(153, 30)
        Me.BtConfirmarVenta.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BtConfirmarVenta.ForeColor = System.Drawing.Color.White
        Me.BtConfirmarVenta.IsBackStageButton = False
        Me.BtConfirmarVenta.Location = New System.Drawing.Point(12, 9)
        Me.BtConfirmarVenta.MetroColor = System.Drawing.SystemColors.Highlight
        Me.BtConfirmarVenta.Name = "BtConfirmarVenta"
        Me.BtConfirmarVenta.Size = New System.Drawing.Size(153, 30)
        Me.BtConfirmarVenta.TabIndex = 604
        Me.BtConfirmarVenta.Text = "Confirmar venta"
        Me.BtConfirmarVenta.UseVisualStyle = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(17, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 17)
        Me.Label3.TabIndex = 583
        Me.Label3.Text = "Datos del Servicio"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 584
        Me.Label1.Text = "Fecha programada"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 13)
        Me.Label2.TabIndex = 586
        Me.Label2.Text = "Ciudad o lugar de destino (Ubigeo)"
        '
        'TextCiudadDestino
        '
        Me.TextCiudadDestino.BackColor = System.Drawing.Color.White
        Me.TextCiudadDestino.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCiudadDestino.BorderColor = System.Drawing.Color.Silver
        Me.TextCiudadDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCiudadDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCiudadDestino.CornerRadius = 3
        Me.TextCiudadDestino.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCiudadDestino.Enabled = False
        Me.TextCiudadDestino.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCiudadDestino.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCiudadDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCiudadDestino.Location = New System.Drawing.Point(17, 103)
        Me.TextCiudadDestino.MaxLength = 70
        Me.TextCiudadDestino.Metrocolor = System.Drawing.Color.Silver
        Me.TextCiudadDestino.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCiudadDestino.Name = "TextCiudadDestino"
        Me.TextCiudadDestino.NearImage = CType(resources.GetObject("TextCiudadDestino.NearImage"), System.Drawing.Image)
        Me.TextCiudadDestino.Size = New System.Drawing.Size(243, 22)
        Me.TextCiudadDestino.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCiudadDestino.TabIndex = 587
        '
        'TextDestinoUbigeo
        '
        Me.TextDestinoUbigeo.BackColor = System.Drawing.Color.White
        Me.TextDestinoUbigeo.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextDestinoUbigeo.BorderColor = System.Drawing.Color.Silver
        Me.TextDestinoUbigeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDestinoUbigeo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDestinoUbigeo.CornerRadius = 3
        Me.TextDestinoUbigeo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextDestinoUbigeo.Enabled = False
        Me.TextDestinoUbigeo.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextDestinoUbigeo.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDestinoUbigeo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextDestinoUbigeo.Location = New System.Drawing.Point(266, 103)
        Me.TextDestinoUbigeo.MaxLength = 70
        Me.TextDestinoUbigeo.Metrocolor = System.Drawing.Color.Silver
        Me.TextDestinoUbigeo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDestinoUbigeo.Name = "TextDestinoUbigeo"
        Me.TextDestinoUbigeo.Size = New System.Drawing.Size(71, 22)
        Me.TextDestinoUbigeo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextDestinoUbigeo.TabIndex = 588
        '
        'TextOrigenUbigeo
        '
        Me.TextOrigenUbigeo.BackColor = System.Drawing.Color.White
        Me.TextOrigenUbigeo.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextOrigenUbigeo.BorderColor = System.Drawing.Color.Silver
        Me.TextOrigenUbigeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextOrigenUbigeo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextOrigenUbigeo.CornerRadius = 3
        Me.TextOrigenUbigeo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextOrigenUbigeo.Enabled = False
        Me.TextOrigenUbigeo.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextOrigenUbigeo.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextOrigenUbigeo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextOrigenUbigeo.Location = New System.Drawing.Point(266, 150)
        Me.TextOrigenUbigeo.MaxLength = 70
        Me.TextOrigenUbigeo.Metrocolor = System.Drawing.Color.Silver
        Me.TextOrigenUbigeo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextOrigenUbigeo.Name = "TextOrigenUbigeo"
        Me.TextOrigenUbigeo.Size = New System.Drawing.Size(71, 22)
        Me.TextOrigenUbigeo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextOrigenUbigeo.TabIndex = 591
        '
        'TextCiudadOrigen
        '
        Me.TextCiudadOrigen.BackColor = System.Drawing.Color.White
        Me.TextCiudadOrigen.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCiudadOrigen.BorderColor = System.Drawing.Color.Silver
        Me.TextCiudadOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCiudadOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCiudadOrigen.CornerRadius = 3
        Me.TextCiudadOrigen.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCiudadOrigen.Enabled = False
        Me.TextCiudadOrigen.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCiudadOrigen.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCiudadOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCiudadOrigen.Location = New System.Drawing.Point(17, 150)
        Me.TextCiudadOrigen.MaxLength = 70
        Me.TextCiudadOrigen.Metrocolor = System.Drawing.Color.Silver
        Me.TextCiudadOrigen.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCiudadOrigen.Name = "TextCiudadOrigen"
        Me.TextCiudadOrigen.NearImage = CType(resources.GetObject("TextCiudadOrigen.NearImage"), System.Drawing.Image)
        Me.TextCiudadOrigen.Size = New System.Drawing.Size(243, 22)
        Me.TextCiudadOrigen.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCiudadOrigen.TabIndex = 590
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 13)
        Me.Label4.TabIndex = 589
        Me.Label4.Text = "Ciudad o lugar de origen (Ubigeo)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(17, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 17)
        Me.Label5.TabIndex = 592
        Me.Label5.Text = "Datos del Pasajero"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextNombres
        '
        Me.TextNombres.BackColor = System.Drawing.Color.White
        Me.TextNombres.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextNombres.BorderColor = System.Drawing.Color.Silver
        Me.TextNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombres.CornerRadius = 3
        Me.TextNombres.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNombres.Enabled = False
        Me.TextNombres.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNombres.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNombres.Location = New System.Drawing.Point(20, 205)
        Me.TextNombres.MaxLength = 70
        Me.TextNombres.Metrocolor = System.Drawing.Color.Silver
        Me.TextNombres.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNombres.Name = "TextNombres"
        Me.TextNombres.NearImage = CType(resources.GetObject("TextNombres.NearImage"), System.Drawing.Image)
        Me.TextNombres.Size = New System.Drawing.Size(317, 22)
        Me.TextNombres.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNombres.TabIndex = 593
        '
        'TextTipoDocIdentidad
        '
        Me.TextTipoDocIdentidad.BackColor = System.Drawing.Color.White
        Me.TextTipoDocIdentidad.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextTipoDocIdentidad.BorderColor = System.Drawing.Color.Silver
        Me.TextTipoDocIdentidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTipoDocIdentidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTipoDocIdentidad.CornerRadius = 3
        Me.TextTipoDocIdentidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTipoDocIdentidad.Enabled = False
        Me.TextTipoDocIdentidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextTipoDocIdentidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoDocIdentidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextTipoDocIdentidad.Location = New System.Drawing.Point(20, 231)
        Me.TextTipoDocIdentidad.MaxLength = 70
        Me.TextTipoDocIdentidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextTipoDocIdentidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTipoDocIdentidad.Name = "TextTipoDocIdentidad"
        Me.TextTipoDocIdentidad.Size = New System.Drawing.Size(240, 22)
        Me.TextTipoDocIdentidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextTipoDocIdentidad.TabIndex = 594
        '
        'TextCodigoIdentidad
        '
        Me.TextCodigoIdentidad.BackColor = System.Drawing.Color.White
        Me.TextCodigoIdentidad.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCodigoIdentidad.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoIdentidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoIdentidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoIdentidad.CornerRadius = 3
        Me.TextCodigoIdentidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoIdentidad.Enabled = False
        Me.TextCodigoIdentidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoIdentidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoIdentidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoIdentidad.Location = New System.Drawing.Point(266, 231)
        Me.TextCodigoIdentidad.MaxLength = 70
        Me.TextCodigoIdentidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoIdentidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoIdentidad.Name = "TextCodigoIdentidad"
        Me.TextCodigoIdentidad.Size = New System.Drawing.Size(71, 22)
        Me.TextCodigoIdentidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoIdentidad.TabIndex = 595
        '
        'textEdad
        '
        Me.textEdad.BackColor = System.Drawing.Color.White
        Me.textEdad.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.textEdad.BorderColor = System.Drawing.Color.Silver
        Me.textEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textEdad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEdad.CornerRadius = 3
        Me.textEdad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.textEdad.Enabled = False
        Me.textEdad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.textEdad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEdad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.textEdad.Location = New System.Drawing.Point(266, 257)
        Me.textEdad.MaxLength = 70
        Me.textEdad.Metrocolor = System.Drawing.Color.Silver
        Me.textEdad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textEdad.Name = "textEdad"
        Me.textEdad.Size = New System.Drawing.Size(71, 22)
        Me.textEdad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.textEdad.TabIndex = 597
        '
        'TextNumIdent
        '
        Me.TextNumIdent.BackColor = System.Drawing.Color.White
        Me.TextNumIdent.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextNumIdent.BorderColor = System.Drawing.Color.Silver
        Me.TextNumIdent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumIdent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIdent.CornerRadius = 3
        Me.TextNumIdent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumIdent.Enabled = False
        Me.TextNumIdent.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNumIdent.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIdent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNumIdent.Location = New System.Drawing.Point(20, 257)
        Me.TextNumIdent.MaxLength = 70
        Me.TextNumIdent.Metrocolor = System.Drawing.Color.Silver
        Me.TextNumIdent.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumIdent.Name = "TextNumIdent"
        Me.TextNumIdent.Size = New System.Drawing.Size(240, 22)
        Me.TextNumIdent.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNumIdent.TabIndex = 596
        '
        'LabelAsientoSel
        '
        Me.LabelAsientoSel.AutoSize = True
        Me.LabelAsientoSel.BackColor = System.Drawing.Color.Transparent
        Me.LabelAsientoSel.Font = New System.Drawing.Font("Tahoma", 40.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAsientoSel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.LabelAsientoSel.Location = New System.Drawing.Point(158, 319)
        Me.LabelAsientoSel.Name = "LabelAsientoSel"
        Me.LabelAsientoSel.Size = New System.Drawing.Size(57, 65)
        Me.LabelAsientoSel.TabIndex = 599
        Me.LabelAsientoSel.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Yu Gothic Medium", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(121, 295)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 16)
        Me.Label7.TabIndex = 598
        Me.Label7.Text = "Asiento seleccionado:"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.TextFechaProgramada)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.LabelAsientoSel)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.Label7)
        Me.GradientPanel1.Controls.Add(Me.textEdad)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.TextNumIdent)
        Me.GradientPanel1.Controls.Add(Me.TextCiudadDestino)
        Me.GradientPanel1.Controls.Add(Me.TextCodigoIdentidad)
        Me.GradientPanel1.Controls.Add(Me.TextDestinoUbigeo)
        Me.GradientPanel1.Controls.Add(Me.TextTipoDocIdentidad)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.TextNombres)
        Me.GradientPanel1.Controls.Add(Me.TextCiudadOrigen)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Controls.Add(Me.TextOrigenUbigeo)
        Me.GradientPanel1.Location = New System.Drawing.Point(1, 115)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(362, 395)
        Me.GradientPanel1.TabIndex = 600
        '
        'TextFechaProgramada
        '
        Me.TextFechaProgramada.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaProgramada.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaProgramada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaProgramada.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaProgramada.Checked = False
        Me.TextFechaProgramada.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaProgramada.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.TextFechaProgramada.DropDownImage = Nothing
        Me.TextFechaProgramada.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaProgramada.EnableNullDate = False
        Me.TextFechaProgramada.EnableNullKeys = False
        Me.TextFechaProgramada.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaProgramada.Location = New System.Drawing.Point(17, 51)
        Me.TextFechaProgramada.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.MinValue = New Date(CType(0, Long))
        Me.TextFechaProgramada.Name = "TextFechaProgramada"
        Me.TextFechaProgramada.ShowCheckBox = False
        Me.TextFechaProgramada.ShowUpDownOnFocus = True
        Me.TextFechaProgramada.Size = New System.Drawing.Size(243, 21)
        Me.TextFechaProgramada.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaProgramada.TabIndex = 600
        Me.TextFechaProgramada.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.TextRaZonSocial)
        Me.GradientPanel3.Controls.Add(Me.TextCodigoComprobanteRazon)
        Me.GradientPanel3.Controls.Add(Me.TextTipoDocIdentidadRazon)
        Me.GradientPanel3.Controls.Add(Me.TextRuc)
        Me.GradientPanel3.Controls.Add(Me.ProgressBar2)
        Me.GradientPanel3.Controls.Add(Me.Label9)
        Me.GradientPanel3.Controls.Add(Me.GradientPanel5)
        Me.GradientPanel3.Controls.Add(Me.txtFecha)
        Me.GradientPanel3.Controls.Add(Me.GroupBox5)
        Me.GradientPanel3.Controls.Add(Me.cboTipoDoc)
        Me.GradientPanel3.Controls.Add(Me.cboMoneda)
        Me.GradientPanel3.Controls.Add(Me.Label6)
        Me.GradientPanel3.Location = New System.Drawing.Point(368, 54)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(527, 456)
        Me.GradientPanel3.TabIndex = 601
        '
        'TextRaZonSocial
        '
        Me.TextRaZonSocial.BackColor = System.Drawing.Color.White
        Me.TextRaZonSocial.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextRaZonSocial.BorderColor = System.Drawing.Color.Silver
        Me.TextRaZonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRaZonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRaZonSocial.CornerRadius = 3
        Me.TextRaZonSocial.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextRaZonSocial.Enabled = False
        Me.TextRaZonSocial.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextRaZonSocial.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRaZonSocial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRaZonSocial.Location = New System.Drawing.Point(18, 146)
        Me.TextRaZonSocial.MaxLength = 70
        Me.TextRaZonSocial.Metrocolor = System.Drawing.Color.Silver
        Me.TextRaZonSocial.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRaZonSocial.Name = "TextRaZonSocial"
        Me.TextRaZonSocial.NearImage = CType(resources.GetObject("TextRaZonSocial.NearImage"), System.Drawing.Image)
        Me.TextRaZonSocial.Size = New System.Drawing.Size(330, 22)
        Me.TextRaZonSocial.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextRaZonSocial.TabIndex = 608
        '
        'TextCodigoComprobanteRazon
        '
        Me.TextCodigoComprobanteRazon.BackColor = System.Drawing.Color.White
        Me.TextCodigoComprobanteRazon.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCodigoComprobanteRazon.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoComprobanteRazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoComprobanteRazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoComprobanteRazon.CornerRadius = 3
        Me.TextCodigoComprobanteRazon.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigoComprobanteRazon.Enabled = False
        Me.TextCodigoComprobanteRazon.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoComprobanteRazon.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoComprobanteRazon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoComprobanteRazon.Location = New System.Drawing.Point(354, 174)
        Me.TextCodigoComprobanteRazon.MaxLength = 70
        Me.TextCodigoComprobanteRazon.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoComprobanteRazon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoComprobanteRazon.Name = "TextCodigoComprobanteRazon"
        Me.TextCodigoComprobanteRazon.Size = New System.Drawing.Size(108, 22)
        Me.TextCodigoComprobanteRazon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoComprobanteRazon.TabIndex = 607
        '
        'TextTipoDocIdentidadRazon
        '
        Me.TextTipoDocIdentidadRazon.BackColor = System.Drawing.Color.White
        Me.TextTipoDocIdentidadRazon.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextTipoDocIdentidadRazon.BorderColor = System.Drawing.Color.Silver
        Me.TextTipoDocIdentidadRazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTipoDocIdentidadRazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTipoDocIdentidadRazon.CornerRadius = 3
        Me.TextTipoDocIdentidadRazon.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTipoDocIdentidadRazon.Enabled = False
        Me.TextTipoDocIdentidadRazon.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextTipoDocIdentidadRazon.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoDocIdentidadRazon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextTipoDocIdentidadRazon.Location = New System.Drawing.Point(18, 174)
        Me.TextTipoDocIdentidadRazon.MaxLength = 70
        Me.TextTipoDocIdentidadRazon.Metrocolor = System.Drawing.Color.Silver
        Me.TextTipoDocIdentidadRazon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTipoDocIdentidadRazon.Name = "TextTipoDocIdentidadRazon"
        Me.TextTipoDocIdentidadRazon.Size = New System.Drawing.Size(330, 22)
        Me.TextTipoDocIdentidadRazon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextTipoDocIdentidadRazon.TabIndex = 606
        '
        'TextRuc
        '
        Me.TextRuc.BackColor = System.Drawing.Color.White
        Me.TextRuc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextRuc.BorderColor = System.Drawing.Color.Silver
        Me.TextRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRuc.CornerRadius = 3
        Me.TextRuc.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextRuc.Enabled = False
        Me.TextRuc.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextRuc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRuc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRuc.Location = New System.Drawing.Point(354, 146)
        Me.TextRuc.MaxLength = 70
        Me.TextRuc.Metrocolor = System.Drawing.Color.Silver
        Me.TextRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuc.Name = "TextRuc"
        Me.TextRuc.Size = New System.Drawing.Size(108, 22)
        Me.TextRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextRuc.TabIndex = 605
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(315, 51)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 591
        Me.ProgressBar2.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(15, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 601
        Me.Label9.Text = "Razón Social"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.GradientPanel5.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel5.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.GradientPanel9)
        Me.GradientPanel5.Controls.Add(Me.Panel2)
        Me.GradientPanel5.Controls.Add(Me.Panel1)
        Me.GradientPanel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel5.Location = New System.Drawing.Point(0, 202)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(525, 252)
        Me.GradientPanel5.TabIndex = 590
        '
        'GradientPanel9
        '
        Me.GradientPanel9.BorderColor = System.Drawing.Color.DarkGray
        Me.GradientPanel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel9.Controls.Add(Me.dgvCuentas)
        Me.GradientPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel9.Location = New System.Drawing.Point(0, 60)
        Me.GradientPanel9.Name = "GradientPanel9"
        Me.GradientPanel9.Size = New System.Drawing.Size(523, 190)
        Me.GradientPanel9.TabIndex = 538
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCuentas.BackColor = System.Drawing.Color.White
        Me.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvCuentas.Size = New System.Drawing.Size(521, 188)
        Me.dgvCuentas.TabIndex = 539
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
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor3.HeaderText = "Cuenta"
        GridColumnDescriptor3.MappingName = "entidad"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 170
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
        GridColumnDescriptor7.Width = 175
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
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
        Me.dgvCuentas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCuentas.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCuentas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("formaPago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("abonado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nrooperacion")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.UseRightToLeftCompatibleTextBox = True
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GradientPanel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(523, 30)
        Me.Panel2.TabIndex = 537
        '
        'GradientPanel7
        '
        Me.GradientPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.GradientPanel7.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel7.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel7.Controls.Add(Me.LblPagoCredito)
        Me.GradientPanel7.Controls.Add(Me.lblPagoVenta)
        Me.GradientPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel7.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(523, 30)
        Me.GradientPanel7.TabIndex = 222
        '
        'LblPagoCredito
        '
        Me.LblPagoCredito.BackColor = System.Drawing.Color.Transparent
        Me.LblPagoCredito.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblPagoCredito.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.lblPagoVenta.Location = New System.Drawing.Point(471, 0)
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
        Me.Panel1.Size = New System.Drawing.Size(523, 30)
        Me.Panel1.TabIndex = 536
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
        Me.GradientPanel6.Size = New System.Drawing.Size(523, 30)
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
        Me.txtTotalPagar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPagar.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtTotalPagar.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.White
        Me.txtTotalPagar.Location = New System.Drawing.Point(380, 0)
        Me.txtTotalPagar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.NullString = ""
        Me.txtTotalPagar.PositiveColor = System.Drawing.Color.White
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.ReadOnlyBackColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalPagar.Size = New System.Drawing.Size(141, 27)
        Me.txtTotalPagar.TabIndex = 495
        Me.txtTotalPagar.Text = "0.00"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label13.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(236, 28)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "TOTAL A PAGAR"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFecha
        '
        Me.txtFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(18, 41)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(137, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 589
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.ChPagoAvanzado)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.chCredito)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox5.Location = New System.Drawing.Point(18, 67)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(447, 54)
        Me.GroupBox5.TabIndex = 587
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos del pago"
        '
        'ChPagoAvanzado
        '
        Me.ChPagoAvanzado.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChPagoAvanzado.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPagoAvanzado.Checked = True
        Me.ChPagoAvanzado.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChPagoAvanzado.ForeColor = System.Drawing.Color.White
        Me.ChPagoAvanzado.Location = New System.Drawing.Point(18, 22)
        Me.ChPagoAvanzado.Name = "ChPagoAvanzado"
        Me.ChPagoAvanzado.Size = New System.Drawing.Size(20, 20)
        Me.ChPagoAvanzado.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Enabled = False
        Me.Label16.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(189, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 14)
        Me.Label16.TabIndex = 536
        Me.Label16.Text = "Venta al crédito (Total)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(39, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 14)
        Me.Label8.TabIndex = 532
        Me.Label8.Text = "Cobranza total o parcial"
        '
        'chCredito
        '
        Me.chCredito.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chCredito.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chCredito.Checked = False
        Me.chCredito.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.chCredito.ForeColor = System.Drawing.Color.White
        Me.chCredito.Location = New System.Drawing.Point(168, 22)
        Me.chCredito.Name = "chCredito"
        Me.chCredito.Size = New System.Drawing.Size(20, 20)
        Me.chCredito.TabIndex = 6
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(187, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(161, 40)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(187, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 585
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(111, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Enabled = False
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERA"})
        Me.cboMoneda.Location = New System.Drawing.Point(354, 40)
        Me.cboMoneda.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(111, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 586
        Me.cboMoneda.Text = "NACIONAL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(15, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 17)
        Me.Label6.TabIndex = 584
        Me.Label6.Text = "Datos de venta"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.TextValoranticipo)
        Me.GroupBox6.Controls.Add(Me.TextPagoAnticipoDisponible)
        Me.GroupBox6.Controls.Add(Me.LinkLabel1)
        Me.GroupBox6.Enabled = False
        Me.GroupBox6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox6.Location = New System.Drawing.Point(901, 48)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(245, 88)
        Me.GroupBox6.TabIndex = 588
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Pago con anticipos"
        Me.GroupBox6.Visible = False
        '
        'TextValoranticipo
        '
        Me.TextValoranticipo.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextValoranticipo.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextValoranticipo.BorderColor = System.Drawing.Color.Silver
        Me.TextValoranticipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValoranticipo.CornerRadius = 4
        Me.TextValoranticipo.CurrencySymbol = ""
        Me.TextValoranticipo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextValoranticipo.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValoranticipo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValoranticipo.ForeColor = System.Drawing.Color.Black
        Me.TextValoranticipo.Location = New System.Drawing.Point(97, 46)
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
        Me.TextPagoAnticipoDisponible.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextPagoAnticipoDisponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPagoAnticipoDisponible.CornerRadius = 4
        Me.TextPagoAnticipoDisponible.CurrencySymbol = ""
        Me.TextPagoAnticipoDisponible.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPagoAnticipoDisponible.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextPagoAnticipoDisponible.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPagoAnticipoDisponible.ForeColor = System.Drawing.Color.Black
        Me.TextPagoAnticipoDisponible.Location = New System.Drawing.Point(10, 46)
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
        Me.LinkLabel1.Location = New System.Drawing.Point(183, 53)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(53, 13)
        Me.LinkLabel1.TabIndex = 551
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Buscar ..."
        '
        'GradientPanel4
        '
        Me.GradientPanel4.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel4.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.TextTotalDescuentos)
        Me.GradientPanel4.Controls.Add(Me.Label19)
        Me.GradientPanel4.Controls.Add(Me.txtTotalBase)
        Me.GradientPanel4.Controls.Add(Me.txtTotalBase2)
        Me.GradientPanel4.Controls.Add(Me.Label11)
        Me.GradientPanel4.Controls.Add(Me.Label14)
        Me.GradientPanel4.Controls.Add(Me.txtTotalBase3)
        Me.GradientPanel4.Controls.Add(Me.txtTotalIva)
        Me.GradientPanel4.Controls.Add(Me.lblTotalPercepcion)
        Me.GradientPanel4.Controls.Add(Me.Label10)
        Me.GradientPanel4.Controls.Add(Me.Label22)
        Me.GradientPanel4.Controls.Add(Me.Label12)
        Me.GradientPanel4.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel4.Location = New System.Drawing.Point(1, 515)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(895, 48)
        Me.GradientPanel4.TabIndex = 602
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
        Me.TextTotalDescuentos.Location = New System.Drawing.Point(722, 26)
        Me.TextTotalDescuentos.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTotalDescuentos.Name = "TextTotalDescuentos"
        Me.TextTotalDescuentos.NullString = ""
        Me.TextTotalDescuentos.PositiveColor = System.Drawing.Color.Black
        Me.TextTotalDescuentos.ReadOnly = True
        Me.TextTotalDescuentos.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TextTotalDescuentos.Size = New System.Drawing.Size(141, 15)
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
        Me.Label19.Location = New System.Drawing.Point(644, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 499
        Me.Label19.Text = "Descuentos"
        '
        'txtTotalBase
        '
        Me.txtTotalBase.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase.BeforeTouchSize = New System.Drawing.Size(100, 20)
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
        Me.txtTotalBase.TabIndex = 494
        Me.txtTotalBase.Text = "0.00"
        Me.txtTotalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtTotalBase2.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalBase2.Size = New System.Drawing.Size(141, 15)
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
        Me.txtTotalBase3.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTotalBase3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase3.CornerRadius = 5
        Me.txtTotalBase3.CurrencySymbol = ""
        Me.txtTotalBase3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalBase3.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase3.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase3.Location = New System.Drawing.Point(405, 6)
        Me.txtTotalBase3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase3.Name = "txtTotalBase3"
        Me.txtTotalBase3.NullString = ""
        Me.txtTotalBase3.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalBase3.ReadOnly = True
        Me.txtTotalBase3.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalBase3.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase3.TabIndex = 498
        Me.txtTotalBase3.Text = "0.00"
        Me.txtTotalBase3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIva.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTotalIva.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalIva.CornerRadius = 5
        Me.txtTotalIva.CurrencySymbol = ""
        Me.txtTotalIva.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalIva.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIva.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.ForeColor = System.Drawing.Color.Black
        Me.txtTotalIva.Location = New System.Drawing.Point(405, 28)
        Me.txtTotalIva.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.NullString = ""
        Me.txtTotalIva.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalIva.ReadOnly = True
        Me.txtTotalIva.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalIva.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalIva.TabIndex = 493
        Me.txtTotalIva.Text = "0.00"
        Me.txtTotalIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.lblTotalPercepcion.Location = New System.Drawing.Point(722, 6)
        Me.lblTotalPercepcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPercepcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.lblTotalPercepcion.Name = "lblTotalPercepcion"
        Me.lblTotalPercepcion.NullString = ""
        Me.lblTotalPercepcion.PositiveColor = System.Drawing.Color.Black
        Me.lblTotalPercepcion.ReadOnly = True
        Me.lblTotalPercepcion.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lblTotalPercepcion.Size = New System.Drawing.Size(141, 15)
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
        Me.Label10.Location = New System.Drawing.Point(329, 8)
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
        Me.Label22.Location = New System.Drawing.Point(643, 6)
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
        Me.Label12.Location = New System.Drawing.Point(329, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "IGV"
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.GradientPanel8.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel8.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.Label15)
        Me.GradientPanel8.Controls.Add(Me.Label17)
        Me.GradientPanel8.Controls.Add(Me.ComboCaja)
        Me.GradientPanel8.Controls.Add(Me.TextCodigoVendedor)
        Me.GradientPanel8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel8.Location = New System.Drawing.Point(1, 54)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(362, 56)
        Me.GradientPanel8.TabIndex = 603
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(17, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 14)
        Me.Label15.TabIndex = 230
        Me.Label15.Text = "Vendedor"
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
        'TextCodigoVendedor
        '
        Me.TextCodigoVendedor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextCodigoVendedor.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCodigoVendedor.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoVendedor.CornerRadius = 4
        Me.TextCodigoVendedor.Cursor = System.Windows.Forms.Cursors.Arrow
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
        Me.TextCodigoVendedor.TabIndex = 19
        Me.TextCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'FormCrearVentaTransporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.CaptionBarColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(898, 567)
        Me.Controls.Add(Me.GradientPanel8)
        Me.Controls.Add(Me.GradientPanel4)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.GroupBox6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearVentaTransporte"
        Me.ShowIcon = False
        Me.Text = "Venta"
        Me.Panel11.ResumeLayout(False)
        CType(Me.TextCiudadDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDestinoUbigeo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextOrigenUbigeo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCiudadOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTipoDocIdentidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoIdentidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textEdad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumIdent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.TextRaZonSocial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoComprobanteRazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTipoDocIdentidadRazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.GradientPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel9.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        Me.GradientPanel7.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.TextValoranticipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPagoAnticipoDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.GradientPanel4.PerformLayout()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPercepcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        Me.GradientPanel8.PerformLayout()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel11 As Panel

    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextCiudadDestino As Tools.TextBoxExt
    Friend WithEvents TextDestinoUbigeo As Tools.TextBoxExt
    Friend WithEvents TextOrigenUbigeo As Tools.TextBoxExt
    Friend WithEvents TextCiudadOrigen As Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextNombres As Tools.TextBoxExt
    Friend WithEvents TextTipoDocIdentidad As Tools.TextBoxExt
    Friend WithEvents TextCodigoIdentidad As Tools.TextBoxExt
    Friend WithEvents textEdad As Tools.TextBoxExt
    Friend WithEvents TextNumIdent As Tools.TextBoxExt
    Friend WithEvents LabelAsientoSel As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents GradientPanel3 As Tools.GradientPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents cboTipoDoc As Tools.ComboBoxAdv
    Friend WithEvents cboMoneda As Tools.ComboBoxAdv
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents ChPagoAvanzado As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents chCredito As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents TextValoranticipo As Tools.CurrencyTextBox
    Friend WithEvents TextPagoAnticipoDisponible As Tools.CurrencyTextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Private WithEvents GradientPanel4 As Tools.GradientPanel
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
    Friend WithEvents txtFecha As Tools.DateTimePickerAdv
    Friend WithEvents GradientPanel5 As Tools.GradientPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GradientPanel6 As Tools.GradientPanel
    Friend WithEvents txtTotalPagar As Tools.CurrencyTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GradientPanel7 As Tools.GradientPanel
    Friend WithEvents LblPagoCredito As Label
    Friend WithEvents lblPagoVenta As Label
    Private WithEvents GradientPanel8 As Tools.GradientPanel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents ComboCaja As Tools.ComboBoxAdv
    Friend WithEvents TextCodigoVendedor As Tools.TextBoxExt
    Friend WithEvents GradientPanel9 As Tools.GradientPanel
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents TextFechaProgramada As Tools.DateTimePickerAdv
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label9 As Label
    Friend WithEvents TextRuc As Tools.TextBoxExt
    Friend WithEvents TextCodigoComprobanteRazon As Tools.TextBoxExt
    Friend WithEvents TextTipoDocIdentidadRazon As Tools.TextBoxExt
    Friend WithEvents TextRaZonSocial As Tools.TextBoxExt
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents BtConfirmarVenta As RoundButton2
End Class

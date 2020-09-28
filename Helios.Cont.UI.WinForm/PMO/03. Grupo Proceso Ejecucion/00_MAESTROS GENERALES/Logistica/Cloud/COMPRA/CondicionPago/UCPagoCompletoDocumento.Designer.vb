<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCPagoCompletoDocumento
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCPagoCompletoDocumento))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuThinButton24 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.ComboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextCodigoTarjeta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNumOper = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextMonto = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboCuentaFinanciera = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboFormaPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.TextCompraTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextPagado = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextSaldo = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ListDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.ComboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumOper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboCuentaFinanciera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCompraTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPagado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.TextSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.BunifuThinButton21)
        Me.GradientPanel1.Controls.Add(Me.BunifuThinButton24)
        Me.GradientPanel1.Controls.Add(Me.ComboTipoDoc)
        Me.GradientPanel1.Controls.Add(Me.Label6)
        Me.GradientPanel1.Controls.Add(Me.TextCodigoTarjeta)
        Me.GradientPanel1.Controls.Add(Me.TextNumOper)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.TextMonto)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.ComboCuentaFinanciera)
        Me.GradientPanel1.Controls.Add(Me.cboFormaPago)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1129, 67)
        Me.GradientPanel1.TabIndex = 0
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "Reiniciar pago"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(917, 24)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(95, 37)
        Me.BunifuThinButton21.TabIndex = 633
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuThinButton24
        '
        Me.BunifuThinButton24.ActiveBorderThickness = 1
        Me.BunifuThinButton24.ActiveCornerRadius = 20
        Me.BunifuThinButton24.ActiveFillColor = System.Drawing.SystemColors.Highlight
        Me.BunifuThinButton24.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton24.ActiveLineColor = System.Drawing.SystemColors.Highlight
        Me.BunifuThinButton24.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton24.BackgroundImage = CType(resources.GetObject("BunifuThinButton24.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton24.ButtonText = "Agregar pago"
        Me.BunifuThinButton24.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton24.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton24.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton24.IdleBorderThickness = 1
        Me.BunifuThinButton24.IdleCornerRadius = 20
        Me.BunifuThinButton24.IdleFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton24.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton24.IdleLineColor = System.Drawing.SystemColors.Highlight
        Me.BunifuThinButton24.Location = New System.Drawing.Point(816, 24)
        Me.BunifuThinButton24.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton24.Name = "BunifuThinButton24"
        Me.BunifuThinButton24.Size = New System.Drawing.Size(95, 37)
        Me.BunifuThinButton24.TabIndex = 622
        Me.BunifuThinButton24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboTipoDoc
        '
        Me.ComboTipoDoc.BackColor = System.Drawing.Color.White
        Me.ComboTipoDoc.BeforeTouchSize = New System.Drawing.Size(119, 21)
        Me.ComboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboTipoDoc.Items.AddRange(New Object() {"VOUCHER", "RECIBO", "BOLETA"})
        Me.ComboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboTipoDoc, "VOUCHER"))
        Me.ComboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboTipoDoc, "RECIBO"))
        Me.ComboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboTipoDoc, "BOLETA"))
        Me.ComboTipoDoc.Location = New System.Drawing.Point(413, 36)
        Me.ComboTipoDoc.Name = "ComboTipoDoc"
        Me.ComboTipoDoc.Size = New System.Drawing.Size(119, 21)
        Me.ComboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboTipoDoc.TabIndex = 632
        Me.ComboTipoDoc.Text = "VOUCHER"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(410, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 631
        Me.Label6.Text = "Tipo documento"
        '
        'TextCodigoTarjeta
        '
        Me.TextCodigoTarjeta.BackColor = System.Drawing.SystemColors.Info
        Me.TextCodigoTarjeta.BeforeTouchSize = New System.Drawing.Size(88, 25)
        Me.TextCodigoTarjeta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCodigoTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoTarjeta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoTarjeta.CornerRadius = 3
        Me.TextCodigoTarjeta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoTarjeta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoTarjeta.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextCodigoTarjeta.Location = New System.Drawing.Point(629, 34)
        Me.TextCodigoTarjeta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCodigoTarjeta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoTarjeta.Name = "TextCodigoTarjeta"
        Me.TextCodigoTarjeta.Size = New System.Drawing.Size(86, 23)
        Me.TextCodigoTarjeta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCodigoTarjeta.TabIndex = 630
        '
        'TextNumOper
        '
        Me.TextNumOper.BackColor = System.Drawing.SystemColors.Info
        Me.TextNumOper.BeforeTouchSize = New System.Drawing.Size(88, 25)
        Me.TextNumOper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumOper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumOper.CornerRadius = 3
        Me.TextNumOper.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumOper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumOper.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNumOper.Location = New System.Drawing.Point(537, 34)
        Me.TextNumOper.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumOper.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumOper.Name = "TextNumOper"
        Me.TextNumOper.Size = New System.Drawing.Size(86, 23)
        Me.TextNumOper.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNumOper.TabIndex = 629
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(626, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 628
        Me.Label5.Text = "Código tarjeta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(534, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 627
        Me.Label4.Text = "Nro. Operación"
        '
        'TextMonto
        '
        Me.TextMonto.BackGroundColor = System.Drawing.SystemColors.Info
        Me.TextMonto.BeforeTouchSize = New System.Drawing.Size(88, 25)
        Me.TextMonto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMonto.CornerRadius = 5
        Me.TextMonto.CurrencySymbol = ""
        Me.TextMonto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextMonto.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextMonto.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextMonto.Location = New System.Drawing.Point(721, 32)
        Me.TextMonto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextMonto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextMonto.Name = "TextMonto"
        Me.TextMonto.NullString = ""
        Me.TextMonto.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextMonto.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextMonto.Size = New System.Drawing.Size(88, 25)
        Me.TextMonto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextMonto.TabIndex = 626
        Me.TextMonto.Text = "0.00"
        Me.TextMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(721, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 623
        Me.Label3.Text = "Pago abonado"
        '
        'ComboCuentaFinanciera
        '
        Me.ComboCuentaFinanciera.BackColor = System.Drawing.Color.White
        Me.ComboCuentaFinanciera.BeforeTouchSize = New System.Drawing.Size(224, 21)
        Me.ComboCuentaFinanciera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCuentaFinanciera.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCuentaFinanciera.Location = New System.Drawing.Point(183, 36)
        Me.ComboCuentaFinanciera.Name = "ComboCuentaFinanciera"
        Me.ComboCuentaFinanciera.Size = New System.Drawing.Size(224, 21)
        Me.ComboCuentaFinanciera.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCuentaFinanciera.TabIndex = 3
        '
        'cboFormaPago
        '
        Me.cboFormaPago.BackColor = System.Drawing.Color.White
        Me.cboFormaPago.BeforeTouchSize = New System.Drawing.Size(159, 21)
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFormaPago.Location = New System.Drawing.Point(19, 36)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(159, 21)
        Me.cboFormaPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboFormaPago.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(180, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cuenta financiera"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Medio de pago"
        '
        'GridCompra
        '
        Me.GridCompra.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridCompra.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridCompra.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GridCompra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridCompra.FreezeCaption = False
        Me.GridCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridCompra.Location = New System.Drawing.Point(0, 67)
        Me.GridCompra.Name = "GridCompra"
        Me.GridCompra.Size = New System.Drawing.Size(1129, 209)
        Me.GridCompra.TabIndex = 421
        Me.GridCompra.TableDescriptor.AllowNew = False
        Me.GridCompra.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.GridCompra.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GridCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.GridCompra.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.GridCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.GridCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.GridCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.GridCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.GridCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.GridCompra.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "IDforma"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 45
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "MEDIO DE PAGO"
        GridColumnDescriptor2.MappingName = "forma"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 178
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "idCuenta"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 46
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "CUENTA FINANCIERA"
        GridColumnDescriptor4.MappingName = "Cuenta"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 227
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "TIPO DOC"
        GridColumnDescriptor5.MappingName = "tipodoc"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 99
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "NRO. OPER."
        GridColumnDescriptor6.MappingName = "nrooper"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 99
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "CODIGO TARJETA"
        GridColumnDescriptor7.MappingName = "codigoTarjeta"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 122
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "IMPORTE PAGADO"
        GridColumnDescriptor8.MappingName = "monto"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 132
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.MappingName = "action"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 75
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.MappingName = "iddocumento"
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 0
        Me.GridCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10})
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CellType = "TextBox"
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.GradientInactiveCaption)
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.DataMember = "monto"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "monto"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1})
        Me.GridCompra.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.GridCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 29
        Me.GridCompra.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridCompra.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.GridCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("forma"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Cuenta"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipodoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nrooper"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigoTarjeta"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("action"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("iddocumento")})
        Me.GridCompra.Text = "GridGroupingControl2"
        Me.GridCompra.VersionInfo = "12.4400.0.24"
        '
        'TextCompraTotal
        '
        Me.TextCompraTotal.BackGroundColor = System.Drawing.Color.White
        Me.TextCompraTotal.BeforeTouchSize = New System.Drawing.Size(88, 25)
        Me.TextCompraTotal.BorderColor = System.Drawing.SystemColors.Highlight
        Me.TextCompraTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCompraTotal.CornerRadius = 5
        Me.TextCompraTotal.CurrencySymbol = ""
        Me.TextCompraTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCompraTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextCompraTotal.FocusBorderColor = System.Drawing.SystemColors.Highlight
        Me.TextCompraTotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCompraTotal.ForeColor = System.Drawing.Color.Black
        Me.TextCompraTotal.Location = New System.Drawing.Point(730, 25)
        Me.TextCompraTotal.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.TextCompraTotal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCompraTotal.Name = "TextCompraTotal"
        Me.TextCompraTotal.NullString = ""
        Me.TextCompraTotal.PositiveColor = System.Drawing.Color.Black
        Me.TextCompraTotal.ReadOnly = True
        Me.TextCompraTotal.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextCompraTotal.Size = New System.Drawing.Size(88, 25)
        Me.TextCompraTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCompraTotal.TabIndex = 634
        Me.TextCompraTotal.Text = "0.00"
        Me.TextCompraTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(730, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 633
        Me.Label7.Text = "Total compra"
        '
        'TextPagado
        '
        Me.TextPagado.BackGroundColor = System.Drawing.Color.White
        Me.TextPagado.BeforeTouchSize = New System.Drawing.Size(88, 25)
        Me.TextPagado.BorderColor = System.Drawing.SystemColors.Highlight
        Me.TextPagado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPagado.CornerRadius = 5
        Me.TextPagado.CurrencySymbol = ""
        Me.TextPagado.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPagado.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextPagado.FocusBorderColor = System.Drawing.SystemColors.Highlight
        Me.TextPagado.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPagado.ForeColor = System.Drawing.Color.Black
        Me.TextPagado.Location = New System.Drawing.Point(824, 25)
        Me.TextPagado.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.TextPagado.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPagado.Name = "TextPagado"
        Me.TextPagado.NullString = ""
        Me.TextPagado.PositiveColor = System.Drawing.Color.Black
        Me.TextPagado.ReadOnly = True
        Me.TextPagado.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextPagado.Size = New System.Drawing.Size(88, 25)
        Me.TextPagado.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextPagado.TabIndex = 636
        Me.TextPagado.Text = "0.00"
        Me.TextPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(824, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 635
        Me.Label8.Text = "Importe Pagado"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel2.BorderSides = CType((System.Windows.Forms.Border3DSide.Top Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.TextSaldo)
        Me.GradientPanel2.Controls.Add(Me.Label9)
        Me.GradientPanel2.Controls.Add(Me.TextPagado)
        Me.GradientPanel2.Controls.Add(Me.TextCompraTotal)
        Me.GradientPanel2.Controls.Add(Me.Label8)
        Me.GradientPanel2.Controls.Add(Me.Label7)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 424)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(1129, 56)
        Me.GradientPanel2.TabIndex = 623
        '
        'TextSaldo
        '
        Me.TextSaldo.BackGroundColor = System.Drawing.Color.White
        Me.TextSaldo.BeforeTouchSize = New System.Drawing.Size(88, 25)
        Me.TextSaldo.BorderColor = System.Drawing.SystemColors.Highlight
        Me.TextSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextSaldo.CornerRadius = 5
        Me.TextSaldo.CurrencySymbol = ""
        Me.TextSaldo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextSaldo.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextSaldo.FocusBorderColor = System.Drawing.SystemColors.Highlight
        Me.TextSaldo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSaldo.ForeColor = System.Drawing.Color.Black
        Me.TextSaldo.Location = New System.Drawing.Point(918, 25)
        Me.TextSaldo.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.TextSaldo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextSaldo.Name = "TextSaldo"
        Me.TextSaldo.NullString = ""
        Me.TextSaldo.PositiveColor = System.Drawing.Color.Black
        Me.TextSaldo.ReadOnly = True
        Me.TextSaldo.ReadOnlyBackColor = System.Drawing.Color.White
        Me.TextSaldo.Size = New System.Drawing.Size(88, 25)
        Me.TextSaldo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextSaldo.TabIndex = 638
        Me.TextSaldo.Text = "0.00"
        Me.TextSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(918, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 637
        Me.Label9.Text = "Saldo"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel3.BorderSides = CType((System.Windows.Forms.Border3DSide.Top Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.ListDetalle)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 276)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(1129, 148)
        Me.GradientPanel3.TabIndex = 624
        '
        'ListDetalle
        '
        Me.ListDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListDetalle.FullRowSelect = True
        Me.ListDetalle.GridLines = True
        Me.ListDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ListDetalle.Name = "ListDetalle"
        Me.ListDetalle.Size = New System.Drawing.Size(1127, 146)
        Me.ListDetalle.TabIndex = 0
        Me.ListDetalle.UseCompatibleStateImageBehavior = False
        Me.ListDetalle.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Detalle"
        Me.ColumnHeader1.Width = 365
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Monto pagado"
        Me.ColumnHeader2.Width = 111
        '
        'UCPagoCompletoDocumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridCompra)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Name = "UCPagoCompletoDocumento"
        Me.Size = New System.Drawing.Size(1129, 480)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.ComboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumOper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboCuentaFinanciera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCompraTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPagado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.TextSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboCuentaFinanciera As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboFormaPago As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents BunifuThinButton24 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Label3 As Label
    Friend WithEvents TextMonto As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GridCompra As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextCodigoTarjeta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextNumOper As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ComboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label6 As Label
    Friend WithEvents TextPagado As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextCompraTotal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents TextSaldo As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ListDetalle As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
End Class

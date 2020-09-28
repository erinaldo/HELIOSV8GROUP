<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormImpresionPrecuentaTouch
    Inherits System.Windows.Forms.Form

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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImpresionPrecuentaTouch))
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvPedidoDetalle = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.QrCodeImgControl1 = New Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtNroImpresion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtFormato = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.ComboBox1 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFormato = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.dgvPedidoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.Label6)
        Me.GradientPanel1.Controls.Add(Me.dgvPedidoDetalle)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.QrCodeImgControl1)
        Me.GradientPanel1.Controls.Add(Me.Button5)
        Me.GradientPanel1.Controls.Add(Me.txtNroImpresion)
        Me.GradientPanel1.Controls.Add(Me.txtFormato)
        Me.GradientPanel1.Controls.Add(Me.btnImprimir)
        Me.GradientPanel1.Controls.Add(Me.ComboBox1)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.cboFormato)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(509, 373)
        Me.GradientPanel1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(24, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 644
        Me.Label6.Text = "Lista Pedidos"
        '
        'dgvPedidoDetalle
        '
        Me.dgvPedidoDetalle.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgvPedidoDetalle.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvPedidoDetalle.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvPedidoDetalle.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvPedidoDetalle.BackColor = System.Drawing.Color.Black
        Me.dgvPedidoDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPedidoDetalle.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvPedidoDetalle.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.dgvPedidoDetalle.Location = New System.Drawing.Point(27, 100)
        Me.dgvPedidoDetalle.Name = "dgvPedidoDetalle"
        Me.dgvPedidoDetalle.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvPedidoDetalle.Size = New System.Drawing.Size(440, 197)
        Me.dgvPedidoDetalle.TabIndex = 643
        Me.dgvPedidoDetalle.TableDescriptor.AllowNew = False
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.Name = "idDocumento"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderText = "Descripción"
        GridColumnDescriptor2.MappingName = "descripcion"
        GridColumnDescriptor2.Name = "descripcion"
        GridColumnDescriptor2.Width = 350
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridColumnDescriptor3.HeaderText = "Pedido"
        GridColumnDescriptor3.MappingName = "pedido"
        GridColumnDescriptor3.Name = "pedido"
        GridColumnDescriptor3.Width = 0
        Me.dgvPedidoDetalle.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.dgvPedidoDetalle.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 29
        Me.dgvPedidoDetalle.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvPedidoDetalle.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvPedidoDetalle.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("pedido")})
        Me.dgvPedidoDetalle.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgvPedidoDetalle.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.dgvPedidoDetalle.Text = "GridGroupingControl2"
        Me.dgvPedidoDetalle.UseRightToLeftCompatibleTextBox = True
        Me.dgvPedidoDetalle.VersionInfo = "12.4400.0.24"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(463, 377)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 642
        Me.Label4.Text = "Codigo QR"
        Me.Label4.Visible = False
        '
        'QrCodeImgControl1
        '
        Me.QrCodeImgControl1.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M
        Me.QrCodeImgControl1.Image = CType(resources.GetObject("QrCodeImgControl1.Image"), System.Drawing.Image)
        Me.QrCodeImgControl1.Location = New System.Drawing.Point(466, 377)
        Me.QrCodeImgControl1.Name = "QrCodeImgControl1"
        Me.QrCodeImgControl1.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two
        Me.QrCodeImgControl1.Size = New System.Drawing.Size(79, 64)
        Me.QrCodeImgControl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.QrCodeImgControl1.TabIndex = 641
        Me.QrCodeImgControl1.TabStop = False
        Me.QrCodeImgControl1.Text = "QrCodeImgControl1"
        Me.QrCodeImgControl1.Visible = False
        '
        'Button5
        '
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(307, 315)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(156, 45)
        Me.Button5.TabIndex = 470
        Me.Button5.Text = "     Salir [ESC]"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtNroImpresion
        '
        Me.txtNroImpresion.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtNroImpresion.BeforeTouchSize = New System.Drawing.Size(112, 23)
        Me.txtNroImpresion.BorderColor = System.Drawing.Color.Silver
        Me.txtNroImpresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroImpresion.CornerRadius = 4
        Me.txtNroImpresion.CurrencyDecimalDigits = 0
        Me.txtNroImpresion.CurrencySymbol = ""
        Me.txtNroImpresion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNroImpresion.DecimalValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtNroImpresion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroImpresion.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtNroImpresion.Location = New System.Drawing.Point(641, 42)
        Me.txtNroImpresion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNroImpresion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNroImpresion.Name = "txtNroImpresion"
        Me.txtNroImpresion.NullString = ""
        Me.txtNroImpresion.PositiveColor = System.Drawing.Color.WhiteSmoke
        Me.txtNroImpresion.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtNroImpresion.Size = New System.Drawing.Size(94, 23)
        Me.txtNroImpresion.TabIndex = 640
        Me.txtNroImpresion.Text = "1"
        Me.txtNroImpresion.Visible = False
        '
        'txtFormato
        '
        Me.txtFormato.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtFormato.BeforeTouchSize = New System.Drawing.Size(112, 23)
        Me.txtFormato.BorderColor = System.Drawing.Color.Silver
        Me.txtFormato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFormato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFormato.CornerRadius = 3
        Me.txtFormato.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormato.ForeColor = System.Drawing.Color.White
        Me.txtFormato.Location = New System.Drawing.Point(523, 42)
        Me.txtFormato.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtFormato.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFormato.Name = "txtFormato"
        Me.txtFormato.Size = New System.Drawing.Size(112, 23)
        Me.txtFormato.TabIndex = 639
        Me.txtFormato.Visible = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(145, 315)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(156, 45)
        Me.btnImprimir.TabIndex = 466
        Me.btnImprimir.Text = "     Imprimir [F2]"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboBox1.BeforeTouchSize = New System.Drawing.Size(217, 21)
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FlatBorderColor = System.Drawing.Color.Gray
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboBox1.Location = New System.Drawing.Point(27, 44)
        Me.ComboBox1.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(217, 21)
        Me.ComboBox1.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboBox1.TabIndex = 516
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(24, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Seleccionar una impresora"
        '
        'cboFormato
        '
        Me.cboFormato.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cboFormato.BeforeTouchSize = New System.Drawing.Size(217, 21)
        Me.cboFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormato.FlatBorderColor = System.Drawing.Color.Gray
        Me.cboFormato.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFormato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.cboFormato.Location = New System.Drawing.Point(250, 44)
        Me.cboFormato.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboFormato.Name = "cboFormato"
        Me.cboFormato.Size = New System.Drawing.Size(217, 21)
        Me.cboFormato.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cboFormato.TabIndex = 515
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(247, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Tipo de impresión (Formato)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(520, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Formato"
        Me.Label5.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(638, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Nro. Impresión"
        Me.Label2.Visible = False
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'FormImpresionPrecuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 373)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormImpresionPrecuenta"
        Me.ShowIcon = False
        Me.Text = "Imprimir"
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.dgvPedidoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFormato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFormato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Button5 As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents cboFormato As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtFormato As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNroImpresion As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents QrCodeImgControl1 As Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl
    Friend WithEvents dgvPedidoDetalle As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Label6 As Label
End Class

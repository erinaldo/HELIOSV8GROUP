<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormImpresionEquivalencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImpresionEquivalencia))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ChecDomicilio = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.QrCodeImgControl1 = New Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtNroImpresion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.btnCorreo = New System.Windows.Forms.Button()
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
        Me.BgEnvioFactura = New System.ComponentModel.BackgroundWorker()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GradientPanel1.Controls.Add(Me.Button3)
        Me.GradientPanel1.Controls.Add(Me.ChecDomicilio)
        Me.GradientPanel1.Controls.Add(Me.Button2)
        Me.GradientPanel1.Controls.Add(Me.Button1)
        Me.GradientPanel1.Controls.Add(Me.gridGroupingControl1)
        Me.GradientPanel1.Controls.Add(Me.Label6)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.QrCodeImgControl1)
        Me.GradientPanel1.Controls.Add(Me.Button5)
        Me.GradientPanel1.Controls.Add(Me.txtNroImpresion)
        Me.GradientPanel1.Controls.Add(Me.btnPdf)
        Me.GradientPanel1.Controls.Add(Me.btnCorreo)
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
        Me.GradientPanel1.Size = New System.Drawing.Size(717, 373)
        Me.GradientPanel1.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(467, 268)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(119, 44)
        Me.Button3.TabIndex = 701
        Me.Button3.Text = "          Ver PDF [F5]"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ChecDomicilio
        '
        Me.ChecDomicilio.AutoSize = True
        Me.ChecDomicilio.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.ChecDomicilio.Location = New System.Drawing.Point(464, 74)
        Me.ChecDomicilio.Name = "ChecDomicilio"
        Me.ChecDomicilio.Size = New System.Drawing.Size(221, 17)
        Me.ChecDomicilio.TabIndex = 700
        Me.ChecDomicilio.Text = "Imprimir sin domicilio o dirección definida."
        Me.ChecDomicilio.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.MediumSeaGreen
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(74, 71)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(44, 22)
        Me.Button2.TabIndex = 699
        Me.Button2.Text = "--"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.MediumSeaGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(27, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(44, 22)
        Me.Button1.TabIndex = 698
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'gridGroupingControl1
        '
        Me.gridGroupingControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.gridGroupingControl1.BackColor = System.Drawing.Color.Black
        Me.gridGroupingControl1.ColorStyles = Syncfusion.Windows.Forms.ColorStyles.Office2010Black
        Me.gridGroupingControl1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridGroupingControl1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridGroupingControl1.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2010
        Me.gridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.gridGroupingControl1.Location = New System.Drawing.Point(27, 97)
        Me.gridGroupingControl1.Name = "gridGroupingControl1"
        Me.gridGroupingControl1.Office2010ScrollBarsColorScheme = Syncfusion.Windows.Forms.Office2010ColorScheme.Black
        Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.gridGroupingControl1.Size = New System.Drawing.Size(677, 162)
        Me.gridGroupingControl1.TabIndex = 697
        Me.gridGroupingControl1.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "id"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 20
        GridColumnDescriptor2.HeaderText = "Domicilios activos"
        GridColumnDescriptor2.MappingName = "domicilios"
        GridColumnDescriptor2.Width = 620
        Me.gridGroupingControl1.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2})
        Me.gridGroupingControl1.TableDescriptor.TableOptions.CaptionRowHeight = 22
        Me.gridGroupingControl1.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.gridGroupingControl1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None
        Me.gridGroupingControl1.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One
        Me.gridGroupingControl1.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.gridGroupingControl1.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("domicilios")})
        Me.gridGroupingControl1.Text = "gridGroupingControl1"
        Me.gridGroupingControl1.UseRightToLeftCompatibleTextBox = True
        Me.gridGroupingControl1.VersionInfo = "12.1400.0.43"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label6.Location = New System.Drawing.Point(123, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 14)
        Me.Label6.TabIndex = 643
        Me.Label6.Text = "Domicilio(s) del cliente"
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
        Me.Button5.Location = New System.Drawing.Point(592, 268)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(112, 44)
        Me.Button5.TabIndex = 470
        Me.Button5.Text = "     Salir [ESC]"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtNroImpresion
        '
        Me.txtNroImpresion.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtNroImpresion.BeforeTouchSize = New System.Drawing.Size(150, 23)
        Me.txtNroImpresion.BorderColor = System.Drawing.Color.Silver
        Me.txtNroImpresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroImpresion.CornerRadius = 4
        Me.txtNroImpresion.CurrencyDecimalDigits = 0
        Me.txtNroImpresion.CurrencySymbol = ""
        Me.txtNroImpresion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtNroImpresion.DecimalValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtNroImpresion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroImpresion.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtNroImpresion.Location = New System.Drawing.Point(629, 42)
        Me.txtNroImpresion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNroImpresion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNroImpresion.Name = "txtNroImpresion"
        Me.txtNroImpresion.NullString = ""
        Me.txtNroImpresion.PositiveColor = System.Drawing.Color.WhiteSmoke
        Me.txtNroImpresion.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtNroImpresion.Size = New System.Drawing.Size(75, 23)
        Me.txtNroImpresion.TabIndex = 640
        Me.txtNroImpresion.Text = "1"
        '
        'btnPdf
        '
        Me.btnPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPdf.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnPdf.Image = CType(resources.GetObject("btnPdf.Image"), System.Drawing.Image)
        Me.btnPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPdf.Location = New System.Drawing.Point(324, 268)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(137, 44)
        Me.btnPdf.TabIndex = 469
        Me.btnPdf.Text = "          Guardar PDF [F4]"
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'btnCorreo
        '
        Me.btnCorreo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCorreo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnCorreo.Image = CType(resources.GetObject("btnCorreo.Image"), System.Drawing.Image)
        Me.btnCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCorreo.Location = New System.Drawing.Point(175, 268)
        Me.btnCorreo.Name = "btnCorreo"
        Me.btnCorreo.Size = New System.Drawing.Size(143, 44)
        Me.btnCorreo.TabIndex = 468
        Me.btnCorreo.Text = "          Enviar correo [F3]"
        Me.btnCorreo.UseVisualStyleBackColor = True
        '
        'txtFormato
        '
        Me.txtFormato.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtFormato.BeforeTouchSize = New System.Drawing.Size(150, 23)
        Me.txtFormato.BorderColor = System.Drawing.Color.Silver
        Me.txtFormato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFormato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFormato.CornerRadius = 3
        Me.txtFormato.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormato.ForeColor = System.Drawing.Color.White
        Me.txtFormato.Location = New System.Drawing.Point(473, 42)
        Me.txtFormato.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtFormato.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFormato.Name = "txtFormato"
        Me.txtFormato.Size = New System.Drawing.Size(150, 23)
        Me.txtFormato.TabIndex = 639
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(27, 268)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(142, 44)
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
        Me.Label5.Location = New System.Drawing.Point(470, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Formato"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(626, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Nro. Impresión"
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
        'BgEnvioFactura
        '
        Me.BgEnvioFactura.WorkerSupportsCancellation = True
        '
        'FormImpresionEquivalencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 373)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormImpresionEquivalencia"
        Me.ShowIcon = False
        Me.Text = "Imprimir"
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFormato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFormato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Button5 As Button
    Friend WithEvents btnPdf As Button
    Friend WithEvents btnCorreo As Button
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
    Friend WithEvents Label6 As Label
    Private WithEvents gridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ChecDomicilio As CheckBox
    Friend WithEvents BgEnvioFactura As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button3 As Button
End Class

Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabTR_ConfiguracionPrecio
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabTR_ConfiguracionPrecio))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnPrincipal = New System.Windows.Forms.Panel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextFechaProgramada = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTDESTINO = New System.Windows.Forms.TextBox()
        Me.TXTORIGEN = New System.Windows.Forms.TextBox()
        Me.txtImporte = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboActivosFijos = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowPrimerPisoMedio = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowPrimerPisoSector3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowPrimerPisoSector4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowPrimerPisoSector2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowPrimerPisoSector1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowPiso2Medio = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowNumero3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowNumero4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowNumero2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowNumero1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.pnBody = New System.Windows.Forms.Panel()
        Me.notifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnPrincipal.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboActivosFijos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(30, 40)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'pnPrincipal
        '
        Me.pnPrincipal.BackColor = System.Drawing.Color.White
        Me.pnPrincipal.Controls.Add(Me.GradientPanel2)
        Me.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnPrincipal.Name = "pnPrincipal"
        Me.pnPrincipal.Size = New System.Drawing.Size(780, 739)
        Me.pnPrincipal.TabIndex = 8
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.Label7)
        Me.GradientPanel2.Controls.Add(Me.TextFechaProgramada)
        Me.GradientPanel2.Controls.Add(Me.Label6)
        Me.GradientPanel2.Controls.Add(Me.Label5)
        Me.GradientPanel2.Controls.Add(Me.TXTDESTINO)
        Me.GradientPanel2.Controls.Add(Me.TXTORIGEN)
        Me.GradientPanel2.Controls.Add(Me.txtImporte)
        Me.GradientPanel2.Controls.Add(Me.Button1)
        Me.GradientPanel2.Controls.Add(Me.Label4)
        Me.GradientPanel2.Controls.Add(Me.Label3)
        Me.GradientPanel2.Controls.Add(Me.cboActivosFijos)
        Me.GradientPanel2.Controls.Add(Me.GroupBox1)
        Me.GradientPanel2.Controls.Add(Me.GroupBox2)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(780, 739)
        Me.GradientPanel2.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(419, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 16)
        Me.Label7.TabIndex = 733
        Me.Label7.Text = "FECHA"
        '
        'TextFechaProgramada
        '
        Me.TextFechaProgramada.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaProgramada.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaProgramada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaProgramada.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaProgramada.Checked = False
        Me.TextFechaProgramada.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaProgramada.CustomFormat = "dd-MM-yyyy"
        Me.TextFechaProgramada.DropDownImage = Nothing
        Me.TextFechaProgramada.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaProgramada.EnableNullDate = False
        Me.TextFechaProgramada.EnableNullKeys = False
        Me.TextFechaProgramada.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.TextFechaProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaProgramada.Location = New System.Drawing.Point(517, 15)
        Me.TextFechaProgramada.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.MinValue = New Date(CType(0, Long))
        Me.TextFechaProgramada.Name = "TextFechaProgramada"
        Me.TextFechaProgramada.ReadOnly = True
        Me.TextFechaProgramada.ShowCheckBox = False
        Me.TextFechaProgramada.ShowUpDownOnFocus = True
        Me.TextFechaProgramada.Size = New System.Drawing.Size(240, 31)
        Me.TextFechaProgramada.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaProgramada.TabIndex = 732
        Me.TextFechaProgramada.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(419, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 16)
        Me.Label6.TabIndex = 597
        Me.Label6.Text = "DESTINO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 16)
        Me.Label5.TabIndex = 596
        Me.Label5.Text = "ORIGEN"
        '
        'TXTDESTINO
        '
        Me.TXTDESTINO.Location = New System.Drawing.Point(500, 64)
        Me.TXTDESTINO.Name = "TXTDESTINO"
        Me.TXTDESTINO.ReadOnly = True
        Me.TXTDESTINO.Size = New System.Drawing.Size(257, 20)
        Me.TXTDESTINO.TabIndex = 595
        '
        'TXTORIGEN
        '
        Me.TXTORIGEN.Location = New System.Drawing.Point(113, 61)
        Me.TXTORIGEN.Name = "TXTORIGEN"
        Me.TXTORIGEN.ReadOnly = True
        Me.TXTORIGEN.Size = New System.Drawing.Size(272, 20)
        Me.TXTORIGEN.TabIndex = 594
        '
        'txtImporte
        '
        Me.txtImporte.BackGroundColor = System.Drawing.Color.White
        Me.txtImporte.BeforeTouchSize = New System.Drawing.Size(132, 40)
        Me.txtImporte.BorderColor = System.Drawing.Color.Silver
        Me.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporte.CornerRadius = 5
        Me.txtImporte.CurrencySymbol = "S/ "
        Me.txtImporte.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtImporte.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtImporte.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txtImporte.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtImporte.Location = New System.Drawing.Point(101, 97)
        Me.txtImporte.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtImporte.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.NullString = ""
        Me.txtImporte.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.txtImporte.ReadOnlyBackColor = System.Drawing.SystemColors.Info
        Me.txtImporte.Size = New System.Drawing.Size(132, 40)
        Me.txtImporte.TabIndex = 593
        Me.txtImporte.Text = "S/ 0.00"
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Location = New System.Drawing.Point(239, 95)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 42)
        Me.Button1.TabIndex = 592
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 591
        Me.Label4.Text = "IMPORTE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 16)
        Me.Label3.TabIndex = 589
        Me.Label3.Text = "PLACA BUS"
        '
        'cboActivosFijos
        '
        Me.cboActivosFijos.BackColor = System.Drawing.Color.LightGray
        Me.cboActivosFijos.BeforeTouchSize = New System.Drawing.Size(282, 31)
        Me.cboActivosFijos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActivosFijos.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.cboActivosFijos.Location = New System.Drawing.Point(113, 15)
        Me.cboActivosFijos.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboActivosFijos.Name = "cboActivosFijos"
        Me.cboActivosFijos.ReadOnly = True
        Me.cboActivosFijos.Size = New System.Drawing.Size(282, 31)
        Me.cboActivosFijos.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboActivosFijos.TabIndex = 588
        Me.cboActivosFijos.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GradientPanel4)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(38, 150)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(719, 286)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PISO 1"
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.Panel3)
        Me.GradientPanel4.Location = New System.Drawing.Point(18, 22)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(681, 247)
        Me.GradientPanel4.TabIndex = 10
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.FlowPrimerPisoMedio)
        Me.Panel3.Controls.Add(Me.FlowPrimerPisoSector3)
        Me.Panel3.Controls.Add(Me.FlowPrimerPisoSector4)
        Me.Panel3.Controls.Add(Me.FlowPrimerPisoSector2)
        Me.Panel3.Controls.Add(Me.FlowPrimerPisoSector1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(679, 245)
        Me.Panel3.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(0, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(512, 49)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "PASILLO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowPrimerPisoMedio
        '
        Me.FlowPrimerPisoMedio.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlowPrimerPisoMedio.Location = New System.Drawing.Point(512, 98)
        Me.FlowPrimerPisoMedio.Name = "FlowPrimerPisoMedio"
        Me.FlowPrimerPisoMedio.Size = New System.Drawing.Size(167, 49)
        Me.FlowPrimerPisoMedio.TabIndex = 16
        '
        'FlowPrimerPisoSector3
        '
        Me.FlowPrimerPisoSector3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowPrimerPisoSector3.Location = New System.Drawing.Point(0, 147)
        Me.FlowPrimerPisoSector3.Name = "FlowPrimerPisoSector3"
        Me.FlowPrimerPisoSector3.Size = New System.Drawing.Size(679, 49)
        Me.FlowPrimerPisoSector3.TabIndex = 13
        '
        'FlowPrimerPisoSector4
        '
        Me.FlowPrimerPisoSector4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowPrimerPisoSector4.Location = New System.Drawing.Point(0, 196)
        Me.FlowPrimerPisoSector4.Name = "FlowPrimerPisoSector4"
        Me.FlowPrimerPisoSector4.Size = New System.Drawing.Size(679, 49)
        Me.FlowPrimerPisoSector4.TabIndex = 14
        '
        'FlowPrimerPisoSector2
        '
        Me.FlowPrimerPisoSector2.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowPrimerPisoSector2.Location = New System.Drawing.Point(0, 49)
        Me.FlowPrimerPisoSector2.Name = "FlowPrimerPisoSector2"
        Me.FlowPrimerPisoSector2.Size = New System.Drawing.Size(679, 49)
        Me.FlowPrimerPisoSector2.TabIndex = 15
        '
        'FlowPrimerPisoSector1
        '
        Me.FlowPrimerPisoSector1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowPrimerPisoSector1.Location = New System.Drawing.Point(0, 0)
        Me.FlowPrimerPisoSector1.Name = "FlowPrimerPisoSector1"
        Me.FlowPrimerPisoSector1.Size = New System.Drawing.Size(679, 49)
        Me.FlowPrimerPisoSector1.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GradientPanel3)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(38, 442)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(719, 292)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PISO 2"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.Panel5)
        Me.GradientPanel3.Location = New System.Drawing.Point(18, 22)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(681, 247)
        Me.GradientPanel3.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.FlowPiso2Medio)
        Me.Panel5.Controls.Add(Me.FlowNumero3)
        Me.Panel5.Controls.Add(Me.FlowNumero4)
        Me.Panel5.Controls.Add(Me.FlowNumero2)
        Me.Panel5.Controls.Add(Me.FlowNumero1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(679, 245)
        Me.Panel5.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(0, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(512, 49)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "PASILLO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowPiso2Medio
        '
        Me.FlowPiso2Medio.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlowPiso2Medio.Location = New System.Drawing.Point(512, 98)
        Me.FlowPiso2Medio.Name = "FlowPiso2Medio"
        Me.FlowPiso2Medio.Size = New System.Drawing.Size(167, 49)
        Me.FlowPiso2Medio.TabIndex = 15
        '
        'FlowNumero3
        '
        Me.FlowNumero3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowNumero3.Location = New System.Drawing.Point(0, 147)
        Me.FlowNumero3.Name = "FlowNumero3"
        Me.FlowNumero3.Size = New System.Drawing.Size(679, 49)
        Me.FlowNumero3.TabIndex = 13
        '
        'FlowNumero4
        '
        Me.FlowNumero4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowNumero4.Location = New System.Drawing.Point(0, 196)
        Me.FlowNumero4.Name = "FlowNumero4"
        Me.FlowNumero4.Size = New System.Drawing.Size(679, 49)
        Me.FlowNumero4.TabIndex = 14
        '
        'FlowNumero2
        '
        Me.FlowNumero2.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowNumero2.Location = New System.Drawing.Point(0, 49)
        Me.FlowNumero2.Name = "FlowNumero2"
        Me.FlowNumero2.Size = New System.Drawing.Size(679, 49)
        Me.FlowNumero2.TabIndex = 10
        '
        'FlowNumero1
        '
        Me.FlowNumero1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowNumero1.Location = New System.Drawing.Point(0, 0)
        Me.FlowNumero1.Name = "FlowNumero1"
        Me.FlowNumero1.Size = New System.Drawing.Size(679, 49)
        Me.FlowNumero1.TabIndex = 12
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(282, 27)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.cboTipoDoc.Location = New System.Drawing.Point(8, 28)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(282, 27)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 588
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'pnBody
        '
        Me.pnBody.BackColor = System.Drawing.Color.White
        Me.pnBody.Controls.Add(Me.pnPrincipal)
        Me.pnBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBody.Location = New System.Drawing.Point(0, 0)
        Me.pnBody.Name = "pnBody"
        Me.pnBody.Size = New System.Drawing.Size(780, 739)
        Me.pnBody.TabIndex = 9
        '
        'notifyIcon1
        '
        Me.notifyIcon1.Icon = CType(resources.GetObject("notifyIcon1.Icon"), System.Drawing.Icon)
        Me.notifyIcon1.Text = "Proyecto Demo v1.0"
        Me.notifyIcon1.Visible = True
        '
        'TabTR_ConfiguracionPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(780, 739)
        Me.Controls.Add(Me.pnBody)
        Me.Name = "TabTR_ConfiguracionPrecio"
        Me.pnPrincipal.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboActivosFijos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnBody.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents pnPrincipal As Panel
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents pnBody As Panel
    Private WithEvents notifyIcon1 As NotifyIcon
    Friend WithEvents cboActivosFijos As Tools.ComboBoxAdv
    Friend WithEvents cboTipoDoc As Tools.ComboBoxAdv
    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GradientPanel4 As Tools.GradientPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents FlowPrimerPisoMedio As FlowLayoutPanel
    Friend WithEvents FlowPrimerPisoSector3 As FlowLayoutPanel
    Friend WithEvents FlowPrimerPisoSector4 As FlowLayoutPanel
    Friend WithEvents FlowPrimerPisoSector2 As FlowLayoutPanel
    Friend WithEvents FlowPrimerPisoSector1 As FlowLayoutPanel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GradientPanel3 As Tools.GradientPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowPiso2Medio As FlowLayoutPanel
    Friend WithEvents FlowNumero3 As FlowLayoutPanel
    Friend WithEvents FlowNumero4 As FlowLayoutPanel
    Friend WithEvents FlowNumero2 As FlowLayoutPanel
    Friend WithEvents FlowNumero1 As FlowLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtImporte As Tools.CurrencyTextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTDESTINO As TextBox
    Friend WithEvents TXTORIGEN As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextFechaProgramada As Tools.DateTimePickerAdv
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormGenerarComprobanteVenta
    Inherits Syncfusion.Windows.Forms.MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGenerarComprobanteVenta))
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo3 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtruc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TXTcOMPRADOR = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comprobante"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(223, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Items.AddRange(New Object() {"BOLETA", "TICKET BOLETA", "FACTURA", "TICKET FACTURA"})
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "BOLETA"))
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "TICKET BOLETA"))
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "FACTURA"))
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "TICKET FACTURA"))
        Me.cboTipoDoc.Location = New System.Drawing.Point(34, 91)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(223, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 219
        Me.cboTipoDoc.Text = "BOLETA"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.SystemColors.HotTrack
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
        Me.txtFecha.Calendar.Size = New System.Drawing.Size(219, 174)
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
        Me.txtFecha.Calendar.NoneButton.Location = New System.Drawing.Point(147, 0)
        Me.txtFecha.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFecha.Calendar.NoneButton.Text = "None"
        Me.txtFecha.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFecha.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecha.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecha.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFecha.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFecha.Calendar.TodayButton.Size = New System.Drawing.Size(147, 20)
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
        Me.txtFecha.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(34, 40)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(223, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 222
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(143, 38)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.Image = CType(resources.GetObject("RoundButton21.Image"), System.Drawing.Image)
        Me.RoundButton21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(114, 251)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(143, 38)
        Me.RoundButton21.TabIndex = 519
        Me.RoundButton21.Text = "Generar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'BackgroundWorker1
        '
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Numero"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtNumero, BannerTextInfo1)
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNumero.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumero.Location = New System.Drawing.Point(114, 118)
        Me.txtNumero.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(202, 22)
        Me.txtNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumero.TabIndex = 522
        Me.txtNumero.Visible = False
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        BannerTextInfo2.Text = "Serie"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtSerie, BannerTextInfo2)
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtSerie.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtSerie.Location = New System.Drawing.Point(34, 118)
        Me.txtSerie.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(76, 22)
        Me.txtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtSerie.TabIndex = 521
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(35, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 14)
        Me.Label3.TabIndex = 525
        Me.Label3.Text = "Información del cliente"
        '
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtruc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtruc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtruc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtruc.Location = New System.Drawing.Point(209, 208)
        Me.txtruc.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtruc.Name = "txtruc"
        Me.txtruc.NearImage = CType(resources.GetObject("txtruc.NearImage"), System.Drawing.Image)
        Me.txtruc.ReadOnly = True
        Me.txtruc.Size = New System.Drawing.Size(107, 22)
        Me.txtruc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtruc.TabIndex = 524
        '
        'TXTcOMPRADOR
        '
        Me.TXTcOMPRADOR.BackColor = System.Drawing.Color.White
        BannerTextInfo3.Text = "Seleccionar cliente . . ."
        BannerTextInfo3.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TXTcOMPRADOR, BannerTextInfo3)
        Me.TXTcOMPRADOR.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TXTcOMPRADOR.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTcOMPRADOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTcOMPRADOR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTcOMPRADOR.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTcOMPRADOR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTcOMPRADOR.Location = New System.Drawing.Point(34, 181)
        Me.TXTcOMPRADOR.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTcOMPRADOR.Name = "TXTcOMPRADOR"
        Me.TXTcOMPRADOR.NearImage = CType(resources.GetObject("TXTcOMPRADOR.NearImage"), System.Drawing.Image)
        Me.TXTcOMPRADOR.Size = New System.Drawing.Size(282, 22)
        Me.TXTcOMPRADOR.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TXTcOMPRADOR.TabIndex = 523
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(31, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(197, 14)
        Me.Label2.TabIndex = 526
        Me.Label2.Text = "Información del comprobante de venta"
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(379, 40)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 527
        '
        'LsvProveedor
        '
        Me.LsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colCliente, Me.colRUC})
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
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(224, 76)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 520
        Me.ProgressBar2.Visible = False
        '
        'FormGenerarComprobanteVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(180, 24)
        CaptionLabel1.Text = "Generar comprobante de venta"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(364, 301)
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtruc)
        Me.Controls.Add(Me.TXTcOMPRADOR)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormGenerarComprobanteVenta"
        Me.ShowIcon = False
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtNumero As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtSerie As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents txtruc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TXTcOMPRADOR As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Private WithEvents pcLikeCategoria As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents ProgressBar2 As ProgressBar
End Class

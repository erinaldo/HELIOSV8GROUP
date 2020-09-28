Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConfirmacionNotasCompra
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfirmacionNotasCompra))
        Dim BannerTextInfo7 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo8 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo9 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim GridColumnDescriptor21 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor22 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor23 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor24 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor25 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor26 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor27 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor28 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor29 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor30 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtruc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TXTcOMPRADOR = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.TextFechaCompra = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBase = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgCanastaSel = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaCompra.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgCanastaSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(20, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 14)
        Me.Label2.TabIndex = 537
        Me.Label2.Text = "Información de la COMPRA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(24, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 14)
        Me.Label3.TabIndex = 536
        Me.Label3.Text = "Información del cliente"
        '
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BeforeTouchSize = New System.Drawing.Size(202, 22)
        Me.txtruc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtruc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtruc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtruc.Location = New System.Drawing.Point(198, 198)
        Me.txtruc.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtruc.Name = "txtruc"
        Me.txtruc.NearImage = CType(resources.GetObject("txtruc.NearImage"), System.Drawing.Image)
        Me.txtruc.ReadOnly = True
        Me.txtruc.Size = New System.Drawing.Size(107, 22)
        Me.txtruc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtruc.TabIndex = 535
        '
        'TXTcOMPRADOR
        '
        Me.TXTcOMPRADOR.BackColor = System.Drawing.Color.White
        BannerTextInfo7.Text = "Identificar proveedor . . ."
        BannerTextInfo7.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TXTcOMPRADOR, BannerTextInfo7)
        Me.TXTcOMPRADOR.BeforeTouchSize = New System.Drawing.Size(202, 22)
        Me.TXTcOMPRADOR.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTcOMPRADOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTcOMPRADOR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTcOMPRADOR.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTcOMPRADOR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTcOMPRADOR.Location = New System.Drawing.Point(23, 171)
        Me.TXTcOMPRADOR.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTcOMPRADOR.Name = "TXTcOMPRADOR"
        Me.TXTcOMPRADOR.NearImage = CType(resources.GetObject("TXTcOMPRADOR.NearImage"), System.Drawing.Image)
        Me.TXTcOMPRADOR.Size = New System.Drawing.Size(282, 22)
        Me.TXTcOMPRADOR.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TXTcOMPRADOR.TabIndex = 534
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        BannerTextInfo8.Text = "Número"
        BannerTextInfo8.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtNumero, BannerTextInfo8)
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(202, 22)
        Me.txtNumero.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumero.Location = New System.Drawing.Point(103, 115)
        Me.txtNumero.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(202, 22)
        Me.txtNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumero.TabIndex = 533
        Me.txtNumero.Visible = False
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        BannerTextInfo9.Text = "Serie"
        BannerTextInfo9.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtSerie, BannerTextInfo9)
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(202, 22)
        Me.txtSerie.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtSerie.Location = New System.Drawing.Point(23, 115)
        Me.txtSerie.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(76, 22)
        Me.txtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtSerie.TabIndex = 532
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
        Me.RoundButton21.Location = New System.Drawing.Point(344, 298)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(143, 38)
        Me.RoundButton21.TabIndex = 530
        Me.RoundButton21.Text = "Generar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'TextFechaCompra
        '
        Me.TextFechaCompra.BackColor = System.Drawing.SystemColors.HotTrack
        Me.TextFechaCompra.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextFechaCompra.Calendar.AllowMultipleSelection = False
        Me.TextFechaCompra.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaCompra.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaCompra.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaCompra.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaCompra.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextFechaCompra.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TextFechaCompra.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextFechaCompra.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaCompra.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaCompra.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextFechaCompra.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextFechaCompra.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextFechaCompra.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextFechaCompra.Calendar.Iso8601CalenderFormat = False
        Me.TextFechaCompra.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaCompra.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaCompra.Calendar.Name = "monthCalendar"
        Me.TextFechaCompra.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextFechaCompra.Calendar.SelectedDates = New Date(-1) {}
        Me.TextFechaCompra.Calendar.Size = New System.Drawing.Size(219, 174)
        Me.TextFechaCompra.Calendar.SizeToFit = True
        Me.TextFechaCompra.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaCompra.Calendar.TabIndex = 0
        Me.TextFechaCompra.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextFechaCompra.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaCompra.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaCompra.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaCompra.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaCompra.Calendar.NoneButton.IsBackStageButton = False
        Me.TextFechaCompra.Calendar.NoneButton.Location = New System.Drawing.Point(147, 0)
        Me.TextFechaCompra.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextFechaCompra.Calendar.NoneButton.Text = "None"
        Me.TextFechaCompra.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.TextFechaCompra.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaCompra.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaCompra.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaCompra.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaCompra.Calendar.TodayButton.IsBackStageButton = False
        Me.TextFechaCompra.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaCompra.Calendar.TodayButton.Size = New System.Drawing.Size(147, 20)
        Me.TextFechaCompra.Calendar.TodayButton.Text = "Today"
        Me.TextFechaCompra.Calendar.TodayButton.UseVisualStyle = True
        Me.TextFechaCompra.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaCompra.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaCompra.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaCompra.Checked = False
        Me.TextFechaCompra.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaCompra.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.TextFechaCompra.DropDownImage = Nothing
        Me.TextFechaCompra.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaCompra.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaCompra.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaCompra.ForeColor = System.Drawing.Color.White
        Me.TextFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaCompra.Location = New System.Drawing.Point(23, 37)
        Me.TextFechaCompra.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaCompra.MinValue = New Date(CType(0, Long))
        Me.TextFechaCompra.Name = "TextFechaCompra"
        Me.TextFechaCompra.ShowCheckBox = False
        Me.TextFechaCompra.ShowDropButton = False
        Me.TextFechaCompra.Size = New System.Drawing.Size(223, 20)
        Me.TextFechaCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaCompra.TabIndex = 529
        Me.TextFechaCompra.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(223, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Items.AddRange(New Object() {"BOLETA", "FACTURA", "NOTA"})
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "BOLETA"))
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "FACTURA"))
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "NOTA"))
        Me.cboTipoDoc.Location = New System.Drawing.Point(23, 88)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(223, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 528
        Me.cboTipoDoc.Text = "BOLETA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 14)
        Me.Label1.TabIndex = 527
        Me.Label1.Text = "Comprobante"
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(318, 351)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 538
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
        Me.LsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem3})
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
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(272, 156)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 539
        Me.ProgressBar2.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(628, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 14)
        Me.Label4.TabIndex = 540
        Me.Label4.Text = "Valor de compra"
        '
        'TextBase
        '
        Me.TextBase.BackGroundColor = System.Drawing.Color.White
        Me.TextBase.BeforeTouchSize = New System.Drawing.Size(202, 22)
        Me.TextBase.BorderColor = System.Drawing.SystemColors.Highlight
        Me.TextBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBase.CornerRadius = 4
        Me.TextBase.CurrencySymbol = ""
        Me.TextBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextBase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBase.Location = New System.Drawing.Point(719, 283)
        Me.TextBase.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBase.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBase.Name = "TextBase"
        Me.TextBase.NullString = ""
        Me.TextBase.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBase.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBase.Size = New System.Drawing.Size(110, 22)
        Me.TextBase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBase.TabIndex = 543
        Me.TextBase.Text = "0.00"
        Me.TextBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgCanastaSel)
        Me.Panel1.Location = New System.Drawing.Point(325, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 268)
        Me.Panel1.TabIndex = 544
        '
        'dgCanastaSel
        '
        Me.dgCanastaSel.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgCanastaSel.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgCanastaSel.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgCanastaSel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgCanastaSel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgCanastaSel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCanastaSel.FreezeCaption = False
        Me.dgCanastaSel.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgCanastaSel.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgCanastaSel.Location = New System.Drawing.Point(0, 0)
        Me.dgCanastaSel.Name = "dgCanastaSel"
        Me.dgCanastaSel.Size = New System.Drawing.Size(498, 266)
        Me.dgCanastaSel.TabIndex = 497
        Me.dgCanastaSel.TableDescriptor.AllowNew = False
        Me.dgCanastaSel.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgCanastaSel.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgCanastaSel.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgCanastaSel.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgCanastaSel.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgCanastaSel.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgCanastaSel.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgCanastaSel.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgCanastaSel.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgCanastaSel.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgCanastaSel.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgCanastaSel.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgCanastaSel.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgCanastaSel.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgCanastaSel.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgCanastaSel.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor21.HeaderImage = Nothing
        GridColumnDescriptor21.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor21.MappingName = "secuencia"
        GridColumnDescriptor21.SerializedImageArray = ""
        GridColumnDescriptor21.Width = 22
        GridColumnDescriptor22.HeaderImage = Nothing
        GridColumnDescriptor22.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor22.MappingName = "iditem"
        GridColumnDescriptor22.SerializedImageArray = ""
        GridColumnDescriptor22.Width = 26
        GridColumnDescriptor23.HeaderImage = Nothing
        GridColumnDescriptor23.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor23.MappingName = "producto"
        GridColumnDescriptor23.SerializedImageArray = ""
        GridColumnDescriptor23.Width = 178
        GridColumnDescriptor24.HeaderImage = Nothing
        GridColumnDescriptor24.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor24.MappingName = "destino"
        GridColumnDescriptor24.SerializedImageArray = ""
        GridColumnDescriptor24.Width = 10
        GridColumnDescriptor25.HeaderImage = Nothing
        GridColumnDescriptor25.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor25.MappingName = "tipo"
        GridColumnDescriptor25.SerializedImageArray = ""
        GridColumnDescriptor25.Width = 7
        GridColumnDescriptor26.HeaderImage = Nothing
        GridColumnDescriptor26.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor26.MappingName = "cantidad"
        GridColumnDescriptor26.ReadOnly = True
        GridColumnDescriptor26.SerializedImageArray = ""
        GridColumnDescriptor27.HeaderImage = Nothing
        GridColumnDescriptor27.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor27.MappingName = "preciounitario"
        GridColumnDescriptor27.SerializedImageArray = ""
        GridColumnDescriptor27.Width = 87
        GridColumnDescriptor28.HeaderImage = Nothing
        GridColumnDescriptor28.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor28.MappingName = "total"
        GridColumnDescriptor28.SerializedImageArray = ""
        GridColumnDescriptor28.Width = 80
        GridColumnDescriptor29.HeaderImage = Nothing
        GridColumnDescriptor29.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor29.MappingName = "almacen"
        GridColumnDescriptor29.SerializedImageArray = ""
        GridColumnDescriptor30.HeaderImage = Nothing
        GridColumnDescriptor30.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor30.MappingName = "almacenid"
        GridColumnDescriptor30.SerializedImageArray = ""
        Me.dgCanastaSel.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor21, GridColumnDescriptor22, GridColumnDescriptor23, GridColumnDescriptor24, GridColumnDescriptor25, GridColumnDescriptor26, GridColumnDescriptor27, GridColumnDescriptor28, GridColumnDescriptor29, GridColumnDescriptor30})
        Me.dgCanastaSel.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgCanastaSel.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgCanastaSel.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgCanastaSel.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("secuencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("iditem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("destino"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("preciounitario"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("total"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("almacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("almacenid")})
        Me.dgCanastaSel.Text = "GridGroupingControl2"
        Me.dgCanastaSel.VersionInfo = "12.4400.0.24"
        '
        'FormConfirmacionNotasCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 348)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBase)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtruc)
        Me.Controls.Add(Me.TXTcOMPRADOR)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.TextFechaCompra)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormConfirmacionNotasCompra"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaCompra.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgCanastaSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtruc As Tools.TextBoxExt
    Friend WithEvents TXTcOMPRADOR As Tools.TextBoxExt
    Friend WithEvents txtNumero As Tools.TextBoxExt
    Friend WithEvents txtSerie As Tools.TextBoxExt
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents TextFechaCompra As Tools.DateTimePickerAdv
    Friend WithEvents cboTipoDoc As Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBase As Tools.CurrencyTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgCanastaSel As Grid.Grouping.GridGroupingControl
End Class

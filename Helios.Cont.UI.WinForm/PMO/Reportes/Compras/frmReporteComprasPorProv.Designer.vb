<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteComprasPorProv
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteComprasPorProv))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnCliente = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboProv = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.pnArticulo = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.popupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.lsvListadoItems = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColDescrip = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoEx = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdRec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUtiMayor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUtiGranMayor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCUenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPresentacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv7 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtBuscarProducto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.pnFecha = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtINic = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtHasta = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.rbProArt = New System.Windows.Forms.RadioButton()
        Me.rbArticulo = New System.Windows.Forms.RadioButton()
        Me.rbCliente = New System.Windows.Forms.RadioButton()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.pnCliente.SuspendLayout()
        CType(Me.cboProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnArticulo.SuspendLayout()
        Me.popupControlContainer1.SuspendLayout()
        CType(Me.txtBuscarProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFecha.SuspendLayout()
        CType(Me.txtINic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtINic.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHasta.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(90, 166)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(859, 296)
        Me.ReportViewer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnCliente)
        Me.Panel1.Controls.Add(Me.pnArticulo)
        Me.Panel1.Controls.Add(Me.pnFecha)
        Me.Panel1.Controls.Add(Me.rbProArt)
        Me.Panel1.Controls.Add(Me.rbArticulo)
        Me.Panel1.Controls.Add(Me.rbCliente)
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1039, 138)
        Me.Panel1.TabIndex = 1
        '
        'pnCliente
        '
        Me.pnCliente.Controls.Add(Me.Label2)
        Me.pnCliente.Controls.Add(Me.cboProv)
        Me.pnCliente.Location = New System.Drawing.Point(29, 75)
        Me.pnCliente.Name = "pnCliente"
        Me.pnCliente.Size = New System.Drawing.Size(310, 48)
        Me.pnCliente.TabIndex = 233
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "PROVEEDORES"
        '
        'cboProv
        '
        Me.cboProv.BackColor = System.Drawing.Color.White
        Me.cboProv.BeforeTouchSize = New System.Drawing.Size(297, 21)
        Me.cboProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProv.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProv.Location = New System.Drawing.Point(3, 22)
        Me.cboProv.Name = "cboProv"
        Me.cboProv.Size = New System.Drawing.Size(297, 21)
        Me.cboProv.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboProv.TabIndex = 7
        '
        'pnArticulo
        '
        Me.pnArticulo.Controls.Add(Me.Label3)
        Me.pnArticulo.Controls.Add(Me.popupControlContainer1)
        Me.pnArticulo.Controls.Add(Me.txtBuscarProducto)
        Me.pnArticulo.Location = New System.Drawing.Point(343, 75)
        Me.pnArticulo.Name = "pnArticulo"
        Me.pnArticulo.Size = New System.Drawing.Size(310, 48)
        Me.pnArticulo.TabIndex = 232
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "PRODUCTO / ARTÍCULO"
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.popupControlContainer1.Controls.Add(Me.lsvListadoItems)
        Me.popupControlContainer1.Controls.Add(Me.ButtonAdv6)
        Me.popupControlContainer1.Controls.Add(Me.ButtonAdv7)
        Me.popupControlContainer1.Location = New System.Drawing.Point(9, 52)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(298, 147)
        Me.popupControlContainer1.TabIndex = 497
        Me.popupControlContainer1.Visible = False
        '
        'lsvListadoItems
        '
        Me.lsvListadoItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.lsvListadoItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.ColDescrip, Me.colUM, Me.colTipoEx, Me.colIdRec, Me.colUtiMayor, Me.colUtiGranMayor, Me.colCUenta, Me.colPresentacion})
        Me.lsvListadoItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsvListadoItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvListadoItems.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lsvListadoItems.FullRowSelect = True
        Me.lsvListadoItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvListadoItems.HideSelection = False
        Me.lsvListadoItems.Location = New System.Drawing.Point(0, 0)
        Me.lsvListadoItems.MultiSelect = False
        Me.lsvListadoItems.Name = "lsvListadoItems"
        Me.lsvListadoItems.Size = New System.Drawing.Size(296, 145)
        Me.lsvListadoItems.TabIndex = 351
        Me.lsvListadoItems.UseCompatibleStateImageBehavior = False
        Me.lsvListadoItems.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID Item"
        Me.colID.Width = 0
        '
        'ColDescrip
        '
        Me.ColDescrip.Text = "Descripción"
        Me.ColDescrip.Width = 303
        '
        'colUM
        '
        Me.colUM.Text = "U.M."
        Me.colUM.Width = 0
        '
        'colTipoEx
        '
        Me.colTipoEx.Text = "Tipo existencia"
        Me.colTipoEx.Width = 0
        '
        'colIdRec
        '
        Me.colIdRec.Text = "ID Recurso"
        Me.colIdRec.Width = 0
        '
        'colUtiMayor
        '
        Me.colUtiMayor.DisplayIndex = 6
        Me.colUtiMayor.Width = 0
        '
        'colUtiGranMayor
        '
        Me.colUtiGranMayor.DisplayIndex = 7
        Me.colUtiGranMayor.Width = 0
        '
        'colCUenta
        '
        Me.colCUenta.DisplayIndex = 5
        Me.colCUenta.Text = "Cta."
        Me.colCUenta.Width = 0
        '
        'colPresentacion
        '
        Me.colPresentacion.Text = "Pres"
        Me.colPresentacion.Width = 0
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(79, 21)
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(65, 120)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(79, 21)
        Me.ButtonAdv6.TabIndex = 2
        Me.ButtonAdv6.Text = "Cancel"
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'ButtonAdv7
        '
        Me.ButtonAdv7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv7.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv7.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv7.BeforeTouchSize = New System.Drawing.Size(78, 21)
        Me.ButtonAdv7.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv7.IsBackStageButton = False
        Me.ButtonAdv7.Location = New System.Drawing.Point(5, 120)
        Me.ButtonAdv7.Name = "ButtonAdv7"
        Me.ButtonAdv7.Size = New System.Drawing.Size(78, 21)
        Me.ButtonAdv7.TabIndex = 1
        Me.ButtonAdv7.Text = "ButtonAdv7"
        Me.ButtonAdv7.UseVisualStyle = True
        '
        'txtBuscarProducto
        '
        Me.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.txtBuscarProducto.BeforeTouchSize = New System.Drawing.Size(299, 22)
        Me.txtBuscarProducto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.txtBuscarProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscarProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscarProducto.CornerRadius = 5
        Me.txtBuscarProducto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBuscarProducto.Location = New System.Drawing.Point(8, 22)
        Me.txtBuscarProducto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.txtBuscarProducto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBuscarProducto.Name = "txtBuscarProducto"
        Me.txtBuscarProducto.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC6329681
        Me.txtBuscarProducto.Size = New System.Drawing.Size(299, 22)
        Me.txtBuscarProducto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007
        Me.txtBuscarProducto.TabIndex = 215
        '
        'pnFecha
        '
        Me.pnFecha.Controls.Add(Me.Label4)
        Me.pnFecha.Controls.Add(Me.ButtonAdv1)
        Me.pnFecha.Controls.Add(Me.Label5)
        Me.pnFecha.Controls.Add(Me.txtINic)
        Me.pnFecha.Controls.Add(Me.txtHasta)
        Me.pnFecha.Location = New System.Drawing.Point(659, 75)
        Me.pnFecha.Name = "pnFecha"
        Me.pnFecha.Size = New System.Drawing.Size(372, 48)
        Me.pnFecha.TabIndex = 231
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 217
        Me.Label4.Text = "FECHA DESDE"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(101, 32)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(259, 10)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(101, 32)
        Me.ButtonAdv1.TabIndex = 5
        Me.ButtonAdv1.Text = "Generar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(130, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 12)
        Me.Label5.TabIndex = 218
        Me.Label5.Text = "FECHA HASTA"
        '
        'txtINic
        '
        Me.txtINic.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtINic.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtINic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtINic.Calendar.AllowMultipleSelection = False
        Me.txtINic.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtINic.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtINic.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtINic.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtINic.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtINic.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtINic.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINic.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtINic.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtINic.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtINic.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtINic.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtINic.Calendar.Iso8601CalenderFormat = False
        Me.txtINic.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtINic.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.Calendar.Name = "monthCalendar"
        Me.txtINic.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtINic.Calendar.SelectedDates = New Date(-1) {}
        Me.txtINic.Calendar.Size = New System.Drawing.Size(105, 174)
        Me.txtINic.Calendar.SizeToFit = True
        Me.txtINic.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtINic.Calendar.TabIndex = 0
        Me.txtINic.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtINic.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtINic.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtINic.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtINic.Calendar.NoneButton.IsBackStageButton = False
        Me.txtINic.Calendar.NoneButton.Location = New System.Drawing.Point(33, 0)
        Me.txtINic.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtINic.Calendar.NoneButton.Text = "None"
        Me.txtINic.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtINic.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtINic.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtINic.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtINic.Calendar.TodayButton.IsBackStageButton = False
        Me.txtINic.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtINic.Calendar.TodayButton.Size = New System.Drawing.Size(33, 20)
        Me.txtINic.Calendar.TodayButton.Text = "Today"
        Me.txtINic.Calendar.TodayButton.UseVisualStyle = True
        Me.txtINic.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINic.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtINic.CustomFormat = "dd/MM/yyyy"
        Me.txtINic.DropDownImage = Nothing
        Me.txtINic.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtINic.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtINic.Location = New System.Drawing.Point(7, 22)
        Me.txtINic.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.MinValue = New Date(CType(0, Long))
        Me.txtINic.Name = "txtINic"
        Me.txtINic.ShowCheckBox = False
        Me.txtINic.Size = New System.Drawing.Size(109, 20)
        Me.txtINic.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtINic.TabIndex = 216
        Me.txtINic.Value = New Date(2015, 12, 30, 16, 33, 14, 694)
        '
        'txtHasta
        '
        Me.txtHasta.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtHasta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtHasta.Calendar.AllowMultipleSelection = False
        Me.txtHasta.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHasta.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHasta.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtHasta.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtHasta.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtHasta.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtHasta.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHasta.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtHasta.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtHasta.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtHasta.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtHasta.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtHasta.Calendar.Iso8601CalenderFormat = False
        Me.txtHasta.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtHasta.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.Calendar.Name = "monthCalendar"
        Me.txtHasta.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtHasta.Calendar.SelectedDates = New Date(-1) {}
        Me.txtHasta.Calendar.Size = New System.Drawing.Size(105, 174)
        Me.txtHasta.Calendar.SizeToFit = True
        Me.txtHasta.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtHasta.Calendar.TabIndex = 0
        Me.txtHasta.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtHasta.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtHasta.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtHasta.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtHasta.Calendar.NoneButton.IsBackStageButton = False
        Me.txtHasta.Calendar.NoneButton.Location = New System.Drawing.Point(33, 0)
        Me.txtHasta.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtHasta.Calendar.NoneButton.Text = "None"
        Me.txtHasta.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtHasta.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtHasta.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtHasta.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtHasta.Calendar.TodayButton.IsBackStageButton = False
        Me.txtHasta.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtHasta.Calendar.TodayButton.Size = New System.Drawing.Size(33, 20)
        Me.txtHasta.Calendar.TodayButton.Text = "Today"
        Me.txtHasta.Calendar.TodayButton.UseVisualStyle = True
        Me.txtHasta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHasta.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtHasta.CustomFormat = "dd/MM/yyyy"
        Me.txtHasta.DropDownImage = Nothing
        Me.txtHasta.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtHasta.Location = New System.Drawing.Point(132, 22)
        Me.txtHasta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.MinValue = New Date(CType(0, Long))
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.ShowCheckBox = False
        Me.txtHasta.Size = New System.Drawing.Size(109, 20)
        Me.txtHasta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtHasta.TabIndex = 219
        Me.txtHasta.Value = New Date(2015, 12, 30, 16, 33, 14, 694)
        '
        'rbProArt
        '
        Me.rbProArt.AutoSize = True
        Me.rbProArt.Location = New System.Drawing.Point(215, 52)
        Me.rbProArt.Name = "rbProArt"
        Me.rbProArt.Size = New System.Drawing.Size(124, 17)
        Me.rbProArt.TabIndex = 230
        Me.rbProArt.Text = "Proveedor/Antículo"
        Me.rbProArt.UseVisualStyleBackColor = True
        '
        'rbArticulo
        '
        Me.rbArticulo.AutoSize = True
        Me.rbArticulo.Location = New System.Drawing.Point(123, 52)
        Me.rbArticulo.Name = "rbArticulo"
        Me.rbArticulo.Size = New System.Drawing.Size(65, 17)
        Me.rbArticulo.TabIndex = 229
        Me.rbArticulo.Text = "Artículo"
        Me.rbArticulo.UseVisualStyleBackColor = True
        '
        'rbCliente
        '
        Me.rbCliente.AutoSize = True
        Me.rbCliente.Checked = True
        Me.rbCliente.Location = New System.Drawing.Point(29, 52)
        Me.rbCliente.Name = "rbCliente"
        Me.rbCliente.Size = New System.Drawing.Size(77, 17)
        Me.rbCliente.TabIndex = 228
        Me.rbCliente.TabStop = True
        Me.rbCliente.Text = "Proveedor"
        Me.rbCliente.UseVisualStyleBackColor = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Location = New System.Drawing.Point(18, 9)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(922, 37)
        Me.GradientPanel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(257, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COMPRAS POR PROVEEDOR/ARTÍCULOS"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 138)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1039, 28)
        Me.Panel2.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 166)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(90, 296)
        Me.Panel3.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(949, 166)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(90, 296)
        Me.Panel4.TabIndex = 4
        '
        'frmReporteComprasPorProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(30, 8)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(65, 22)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Reporte"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1039, 462)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmReporteComprasPorProv"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnCliente.ResumeLayout(False)
        Me.pnCliente.PerformLayout()
        CType(Me.cboProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnArticulo.ResumeLayout(False)
        Me.pnArticulo.PerformLayout()
        Me.popupControlContainer1.ResumeLayout(False)
        CType(Me.txtBuscarProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFecha.ResumeLayout(False)
        Me.pnFecha.PerformLayout()
        CType(Me.txtINic.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtINic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHasta.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cboProv As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarProducto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtHasta As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtINic As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rbArticulo As System.Windows.Forms.RadioButton
    Friend WithEvents rbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbProArt As System.Windows.Forms.RadioButton
    Friend WithEvents pnCliente As System.Windows.Forms.Panel
    Friend WithEvents pnArticulo As System.Windows.Forms.Panel
    Friend WithEvents pnFecha As System.Windows.Forms.Panel
    Private WithEvents popupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvListadoItems As System.Windows.Forms.ListView
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColDescrip As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUM As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipoEx As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdRec As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUtiMayor As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUtiGranMayor As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCUenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPresentacion As System.Windows.Forms.ColumnHeader
    Private WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv7 As Syncfusion.Windows.Forms.ButtonAdv

End Class

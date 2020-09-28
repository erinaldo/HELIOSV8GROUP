<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteVentasPorCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteVentasPorCliente))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnCliente = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboclientes = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.pnArticulo = New System.Windows.Forms.Panel()
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
        Me.txtbuscar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnFecha = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.dateinicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.datefin = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.rbProArt = New System.Windows.Forms.RadioButton()
        Me.rbArticulo = New System.Windows.Forms.RadioButton()
        Me.rbCliente = New System.Windows.Forms.RadioButton()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1.SuspendLayout()
        Me.pnCliente.SuspendLayout()
        CType(Me.cboclientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnArticulo.SuspendLayout()
        Me.popupControlContainer1.SuspendLayout()
        CType(Me.txtbuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFecha.SuspendLayout()
        CType(Me.dateinicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateinicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datefin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datefin.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1019, 139)
        Me.Panel1.TabIndex = 3
        '
        'pnCliente
        '
        Me.pnCliente.Controls.Add(Me.Label2)
        Me.pnCliente.Controls.Add(Me.cboclientes)
        Me.pnCliente.Location = New System.Drawing.Point(50, 74)
        Me.pnCliente.Name = "pnCliente"
        Me.pnCliente.Size = New System.Drawing.Size(312, 54)
        Me.pnCliente.TabIndex = 231
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "CLIENTES"
        Me.Label2.Visible = False
        '
        'cboclientes
        '
        Me.cboclientes.BackColor = System.Drawing.Color.White
        Me.cboclientes.BeforeTouchSize = New System.Drawing.Size(297, 21)
        Me.cboclientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboclientes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboclientes.Location = New System.Drawing.Point(5, 22)
        Me.cboclientes.Name = "cboclientes"
        Me.cboclientes.Size = New System.Drawing.Size(297, 21)
        Me.cboclientes.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboclientes.TabIndex = 221
        Me.cboclientes.Visible = False
        '
        'pnArticulo
        '
        Me.pnArticulo.Controls.Add(Me.popupControlContainer1)
        Me.pnArticulo.Controls.Add(Me.txtbuscar)
        Me.pnArticulo.Controls.Add(Me.Label3)
        Me.pnArticulo.Location = New System.Drawing.Point(367, 74)
        Me.pnArticulo.Name = "pnArticulo"
        Me.pnArticulo.Size = New System.Drawing.Size(310, 54)
        Me.pnArticulo.TabIndex = 230
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.popupControlContainer1.Controls.Add(Me.lsvListadoItems)
        Me.popupControlContainer1.Controls.Add(Me.ButtonAdv6)
        Me.popupControlContainer1.Controls.Add(Me.ButtonAdv7)
        Me.popupControlContainer1.Location = New System.Drawing.Point(3, 53)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(304, 147)
        Me.popupControlContainer1.TabIndex = 496
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
        Me.lsvListadoItems.Size = New System.Drawing.Size(302, 145)
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
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(85, 21)
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(65, 120)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(85, 21)
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
        Me.ButtonAdv7.BeforeTouchSize = New System.Drawing.Size(84, 21)
        Me.ButtonAdv7.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv7.IsBackStageButton = False
        Me.ButtonAdv7.Location = New System.Drawing.Point(5, 120)
        Me.ButtonAdv7.Name = "ButtonAdv7"
        Me.ButtonAdv7.Size = New System.Drawing.Size(84, 21)
        Me.ButtonAdv7.TabIndex = 1
        Me.ButtonAdv7.Text = "ButtonAdv7"
        Me.ButtonAdv7.UseVisualStyle = True
        '
        'txtbuscar
        '
        Me.txtbuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.txtbuscar.BeforeTouchSize = New System.Drawing.Size(299, 22)
        Me.txtbuscar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.txtbuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbuscar.CornerRadius = 5
        Me.txtbuscar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtbuscar.Location = New System.Drawing.Point(3, 22)
        Me.txtbuscar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.txtbuscar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtbuscar.Name = "txtbuscar"
        Me.txtbuscar.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC6329681
        Me.txtbuscar.Size = New System.Drawing.Size(304, 22)
        Me.txtbuscar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007
        Me.txtbuscar.TabIndex = 222
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "PRODUCTO / ARTÍCULO"
        '
        'pnFecha
        '
        Me.pnFecha.Controls.Add(Me.Label4)
        Me.pnFecha.Controls.Add(Me.Label5)
        Me.pnFecha.Controls.Add(Me.ButtonAdv1)
        Me.pnFecha.Controls.Add(Me.dateinicio)
        Me.pnFecha.Controls.Add(Me.datefin)
        Me.pnFecha.Location = New System.Drawing.Point(680, 74)
        Me.pnFecha.Name = "pnFecha"
        Me.pnFecha.Size = New System.Drawing.Size(318, 54)
        Me.pnFecha.TabIndex = 229
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 12)
        Me.Label4.TabIndex = 217
        Me.Label4.Text = "FECHA DESDE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(119, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 12)
        Me.Label5.TabIndex = 218
        Me.Label5.Text = "FECHA HASTA"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(77, 32)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(237, 12)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(77, 32)
        Me.ButtonAdv1.TabIndex = 220
        Me.ButtonAdv1.Text = "Generar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'dateinicio
        '
        Me.dateinicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.dateinicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.dateinicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.dateinicio.Calendar.AllowMultipleSelection = False
        Me.dateinicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.dateinicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dateinicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.dateinicio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dateinicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dateinicio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.dateinicio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dateinicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateinicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dateinicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.dateinicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.dateinicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.dateinicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.dateinicio.Calendar.Iso8601CalenderFormat = False
        Me.dateinicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.dateinicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dateinicio.Calendar.Name = "monthCalendar"
        Me.dateinicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.dateinicio.Calendar.SelectedDates = New Date(-1) {}
        Me.dateinicio.Calendar.Size = New System.Drawing.Size(105, 174)
        Me.dateinicio.Calendar.SizeToFit = True
        Me.dateinicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dateinicio.Calendar.TabIndex = 0
        Me.dateinicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.dateinicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dateinicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dateinicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.dateinicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.dateinicio.Calendar.NoneButton.IsBackStageButton = False
        Me.dateinicio.Calendar.NoneButton.Location = New System.Drawing.Point(33, 0)
        Me.dateinicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.dateinicio.Calendar.NoneButton.Text = "None"
        Me.dateinicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.dateinicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dateinicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dateinicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.dateinicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.dateinicio.Calendar.TodayButton.IsBackStageButton = False
        Me.dateinicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.dateinicio.Calendar.TodayButton.Size = New System.Drawing.Size(33, 20)
        Me.dateinicio.Calendar.TodayButton.Text = "Today"
        Me.dateinicio.Calendar.TodayButton.UseVisualStyle = True
        Me.dateinicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateinicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.dateinicio.CustomFormat = "dd/MM/yyyy"
        Me.dateinicio.DropDownImage = Nothing
        Me.dateinicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dateinicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dateinicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.dateinicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateinicio.Location = New System.Drawing.Point(5, 24)
        Me.dateinicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dateinicio.MinValue = New Date(CType(0, Long))
        Me.dateinicio.Name = "dateinicio"
        Me.dateinicio.ShowCheckBox = False
        Me.dateinicio.Size = New System.Drawing.Size(109, 20)
        Me.dateinicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dateinicio.TabIndex = 223
        Me.dateinicio.Value = New Date(2015, 12, 30, 16, 33, 14, 694)
        '
        'datefin
        '
        Me.datefin.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.datefin.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.datefin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.datefin.Calendar.AllowMultipleSelection = False
        Me.datefin.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.datefin.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.datefin.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.datefin.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.datefin.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.datefin.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.datefin.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datefin.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datefin.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.datefin.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.datefin.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.datefin.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.datefin.Calendar.HighlightColor = System.Drawing.Color.White
        Me.datefin.Calendar.Iso8601CalenderFormat = False
        Me.datefin.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.datefin.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.datefin.Calendar.Name = "monthCalendar"
        Me.datefin.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.datefin.Calendar.SelectedDates = New Date(-1) {}
        Me.datefin.Calendar.Size = New System.Drawing.Size(105, 174)
        Me.datefin.Calendar.SizeToFit = True
        Me.datefin.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.datefin.Calendar.TabIndex = 0
        Me.datefin.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.datefin.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.datefin.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.datefin.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.datefin.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.datefin.Calendar.NoneButton.IsBackStageButton = False
        Me.datefin.Calendar.NoneButton.Location = New System.Drawing.Point(33, 0)
        Me.datefin.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.datefin.Calendar.NoneButton.Text = "None"
        Me.datefin.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.datefin.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.datefin.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.datefin.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.datefin.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.datefin.Calendar.TodayButton.IsBackStageButton = False
        Me.datefin.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.datefin.Calendar.TodayButton.Size = New System.Drawing.Size(33, 20)
        Me.datefin.Calendar.TodayButton.Text = "Today"
        Me.datefin.Calendar.TodayButton.UseVisualStyle = True
        Me.datefin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datefin.CalendarSize = New System.Drawing.Size(189, 176)
        Me.datefin.CustomFormat = "dd/MM/yyyy"
        Me.datefin.DropDownImage = Nothing
        Me.datefin.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.datefin.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.datefin.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.datefin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datefin.Location = New System.Drawing.Point(121, 24)
        Me.datefin.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.datefin.MinValue = New Date(CType(0, Long))
        Me.datefin.Name = "datefin"
        Me.datefin.ShowCheckBox = False
        Me.datefin.Size = New System.Drawing.Size(109, 20)
        Me.datefin.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.datefin.TabIndex = 224
        Me.datefin.Value = New Date(2015, 12, 30, 16, 33, 14, 694)
        '
        'rbProArt
        '
        Me.rbProArt.AutoSize = True
        Me.rbProArt.Location = New System.Drawing.Point(222, 52)
        Me.rbProArt.Name = "rbProArt"
        Me.rbProArt.Size = New System.Drawing.Size(105, 17)
        Me.rbProArt.TabIndex = 228
        Me.rbProArt.Text = "Cliente/Artículo"
        Me.rbProArt.UseVisualStyleBackColor = True
        '
        'rbArticulo
        '
        Me.rbArticulo.AutoSize = True
        Me.rbArticulo.Location = New System.Drawing.Point(132, 52)
        Me.rbArticulo.Name = "rbArticulo"
        Me.rbArticulo.Size = New System.Drawing.Size(65, 17)
        Me.rbArticulo.TabIndex = 227
        Me.rbArticulo.Text = "Artículo"
        Me.rbArticulo.UseVisualStyleBackColor = True
        '
        'rbCliente
        '
        Me.rbCliente.AutoSize = True
        Me.rbCliente.Checked = True
        Me.rbCliente.Location = New System.Drawing.Point(50, 52)
        Me.rbCliente.Name = "rbCliente"
        Me.rbCliente.Size = New System.Drawing.Size(61, 17)
        Me.rbCliente.TabIndex = 226
        Me.rbCliente.TabStop = True
        Me.rbCliente.Text = "Cliente"
        Me.rbCliente.UseVisualStyleBackColor = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Location = New System.Drawing.Point(39, 9)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(922, 37)
        Me.GradientPanel1.TabIndex = 225
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VENTAS POR CLIENTE/ARTICULO"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 139)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1019, 28)
        Me.Panel2.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 167)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(90, 292)
        Me.Panel3.TabIndex = 6
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(929, 167)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(90, 292)
        Me.Panel4.TabIndex = 7
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(90, 167)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(839, 292)
        Me.ReportViewer1.TabIndex = 8
        '
        'frmReporteVentasPorCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 8)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        CaptionLabel1.Location = New System.Drawing.Point(55, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Reporte"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1019, 459)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmReporteVentasPorCliente"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnCliente.ResumeLayout(False)
        Me.pnCliente.PerformLayout()
        CType(Me.cboclientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnArticulo.ResumeLayout(False)
        Me.pnArticulo.PerformLayout()
        Me.popupControlContainer1.ResumeLayout(False)
        CType(Me.txtbuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFecha.ResumeLayout(False)
        Me.pnFecha.PerformLayout()
        CType(Me.dateinicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateinicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datefin.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datefin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents datefin As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents dateinicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtbuscar As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboclientes As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbArticulo As System.Windows.Forms.RadioButton
    Friend WithEvents rbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbProArt As System.Windows.Forms.RadioButton
    Friend WithEvents pnCliente As System.Windows.Forms.Panel
    Friend WithEvents pnArticulo As System.Windows.Forms.Panel
    Friend WithEvents pnFecha As System.Windows.Forms.Panel
    Private WithEvents popupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Private WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv7 As Syncfusion.Windows.Forms.ButtonAdv
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

End Class

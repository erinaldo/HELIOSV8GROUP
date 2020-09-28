<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalHistorialOC
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalHistorialOC))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnExistencia = New System.Windows.Forms.Panel()
        Me.lblIdDocumento = New System.Windows.Forms.Label()
        Me.txtNombreItem = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.DomainUpDown()
        Me.pnDetallesOC = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDirAlmacen = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaInicioPlazo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtFechaFinPlazo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtIndicaciones = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnExistencia.SuspendLayout()
        Me.pnDetallesOC.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtFechaInicioPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicioPlazo.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinPlazo.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip5)
        Me.Panel1.Controls.Add(Me.PanelError)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(388, 66)
        Me.Panel1.TabIndex = 0
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPerido, Me.ToolStripSeparator1, Me.ToolStripButton1})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 22)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(388, 44)
        Me.ToolStrip5.TabIndex = 423
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'lblPerido
        '
        Me.lblPerido.BackColor = System.Drawing.Color.Transparent
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Image = CType(resources.GetObject("lblPerido.Image"), System.Drawing.Image)
        Me.lblPerido.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPerido.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(115, 41)
        Me.lblPerido.Text = "Período: 2017"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 44)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(84, 41)
        Me.ToolStripButton1.Text = " serv"
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.Maroon
        Me.PanelError.Controls.Add(Me.PictureBox3)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(388, 22)
        Me.PanelError.TabIndex = 424
        Me.PanelError.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(369, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 288
        Me.PictureBox3.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.White
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnExistencia)
        Me.Panel2.Controls.Add(Me.pnDetallesOC)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 66)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(388, 320)
        Me.Panel2.TabIndex = 1
        '
        'pnExistencia
        '
        Me.pnExistencia.Controls.Add(Me.lblIdDocumento)
        Me.pnExistencia.Controls.Add(Me.txtNombreItem)
        Me.pnExistencia.Controls.Add(Me.Label2)
        Me.pnExistencia.Controls.Add(Me.lblCantidad)
        Me.pnExistencia.Controls.Add(Me.txtCantidad)
        Me.pnExistencia.Location = New System.Drawing.Point(3, 6)
        Me.pnExistencia.Name = "pnExistencia"
        Me.pnExistencia.Size = New System.Drawing.Size(382, 52)
        Me.pnExistencia.TabIndex = 275
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.AutoSize = True
        Me.lblIdDocumento.Location = New System.Drawing.Point(10, 13)
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(40, 13)
        Me.lblIdDocumento.TabIndex = 270
        Me.lblIdDocumento.Text = "Label5"
        Me.lblIdDocumento.Visible = False
        '
        'txtNombreItem
        '
        Me.txtNombreItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreItem.Location = New System.Drawing.Point(116, 5)
        Me.txtNombreItem.Name = "txtNombreItem"
        Me.txtNombreItem.ReadOnly = True
        Me.txtNombreItem.Size = New System.Drawing.Size(257, 19)
        Me.txtNombreItem.TabIndex = 266
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(61, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 267
        Me.Label2.Text = "Nombre:"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCantidad.Location = New System.Drawing.Point(55, 30)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(57, 13)
        Me.lblCantidad.TabIndex = 268
        Me.lblCantidad.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(116, 28)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(85, 22)
        Me.txtCantidad.TabIndex = 269
        '
        'pnDetallesOC
        '
        Me.pnDetallesOC.Controls.Add(Me.Label22)
        Me.pnDetallesOC.Controls.Add(Me.Label1)
        Me.pnDetallesOC.Controls.Add(Me.txtDirAlmacen)
        Me.pnDetallesOC.Controls.Add(Me.GroupBox3)
        Me.pnDetallesOC.Controls.Add(Me.cboAlmacen)
        Me.pnDetallesOC.Controls.Add(Me.Label16)
        Me.pnDetallesOC.Controls.Add(Me.txtIndicaciones)
        Me.pnDetallesOC.Enabled = False
        Me.pnDetallesOC.Location = New System.Drawing.Point(3, 60)
        Me.pnDetallesOC.Name = "pnDetallesOC"
        Me.pnDetallesOC.Size = New System.Drawing.Size(382, 257)
        Me.pnDetallesOC.TabIndex = 274
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(15, 32)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 13)
        Me.Label22.TabIndex = 237
        Me.Label22.Text = "Lugar de Entrega:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "Nombre de Almacen:"
        '
        'txtDirAlmacen
        '
        Me.txtDirAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDirAlmacen.Location = New System.Drawing.Point(119, 29)
        Me.txtDirAlmacen.Name = "txtDirAlmacen"
        Me.txtDirAlmacen.Size = New System.Drawing.Size(254, 19)
        Me.txtDirAlmacen.TabIndex = 257
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtFechaInicioPlazo)
        Me.GroupBox3.Controls.Add(Me.txtFechaFinPlazo)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox3.Location = New System.Drawing.Point(118, 60)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(255, 92)
        Me.GroupBox3.TabIndex = 258
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Plazo de entrega:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(31, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 214
        Me.Label3.Text = "Del:"
        '
        'txtFechaInicioPlazo
        '
        Me.txtFechaInicioPlazo.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaInicioPlazo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicioPlazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaInicioPlazo.Calendar.AllowMultipleSelection = False
        Me.txtFechaInicioPlazo.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicioPlazo.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaInicioPlazo.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaInicioPlazo.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaInicioPlazo.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaInicioPlazo.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaInicioPlazo.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicioPlazo.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicioPlazo.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaInicioPlazo.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaInicioPlazo.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaInicioPlazo.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaInicioPlazo.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaInicioPlazo.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicioPlazo.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.Calendar.Name = "monthCalendar"
        Me.txtFechaInicioPlazo.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaInicioPlazo.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaInicioPlazo.Calendar.Size = New System.Drawing.Size(150, 174)
        Me.txtFechaInicioPlazo.Calendar.SizeToFit = True
        Me.txtFechaInicioPlazo.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicioPlazo.Calendar.TabIndex = 0
        Me.txtFechaInicioPlazo.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaInicioPlazo.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicioPlazo.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicioPlazo.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicioPlazo.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaInicioPlazo.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtFechaInicioPlazo.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaInicioPlazo.Calendar.NoneButton.Text = "None"
        Me.txtFechaInicioPlazo.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaInicioPlazo.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicioPlazo.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicioPlazo.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicioPlazo.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaInicioPlazo.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicioPlazo.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtFechaInicioPlazo.Calendar.TodayButton.Text = "Today"
        Me.txtFechaInicioPlazo.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaInicioPlazo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicioPlazo.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicioPlazo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaInicioPlazo.Checked = False
        Me.txtFechaInicioPlazo.CustomFormat = "dd/MM/yyyy "
        Me.txtFechaInicioPlazo.DropDownImage = Nothing
        Me.txtFechaInicioPlazo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaInicioPlazo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaInicioPlazo.Location = New System.Drawing.Point(63, 24)
        Me.txtFechaInicioPlazo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.MinValue = New Date(CType(0, Long))
        Me.txtFechaInicioPlazo.Name = "txtFechaInicioPlazo"
        Me.txtFechaInicioPlazo.ShowCheckBox = False
        Me.txtFechaInicioPlazo.Size = New System.Drawing.Size(154, 20)
        Me.txtFechaInicioPlazo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicioPlazo.TabIndex = 215
        Me.txtFechaInicioPlazo.Value = New Date(2015, 9, 16, 16, 21, 59, 837)
        '
        'txtFechaFinPlazo
        '
        Me.txtFechaFinPlazo.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaFinPlazo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaFinPlazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaFinPlazo.Calendar.AllowMultipleSelection = False
        Me.txtFechaFinPlazo.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaFinPlazo.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaFinPlazo.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaFinPlazo.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaFinPlazo.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaFinPlazo.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaFinPlazo.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFinPlazo.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaFinPlazo.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaFinPlazo.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaFinPlazo.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaFinPlazo.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaFinPlazo.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaFinPlazo.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaFinPlazo.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.Calendar.Name = "monthCalendar"
        Me.txtFechaFinPlazo.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaFinPlazo.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaFinPlazo.Calendar.Size = New System.Drawing.Size(150, 174)
        Me.txtFechaFinPlazo.Calendar.SizeToFit = True
        Me.txtFechaFinPlazo.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaFinPlazo.Calendar.TabIndex = 0
        Me.txtFechaFinPlazo.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaFinPlazo.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaFinPlazo.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaFinPlazo.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaFinPlazo.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaFinPlazo.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtFechaFinPlazo.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaFinPlazo.Calendar.NoneButton.Text = "None"
        Me.txtFechaFinPlazo.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaFinPlazo.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaFinPlazo.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaFinPlazo.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaFinPlazo.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaFinPlazo.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaFinPlazo.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtFechaFinPlazo.Calendar.TodayButton.Text = "Today"
        Me.txtFechaFinPlazo.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaFinPlazo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFinPlazo.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaFinPlazo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaFinPlazo.Checked = False
        Me.txtFechaFinPlazo.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaFinPlazo.DropDownImage = Nothing
        Me.txtFechaFinPlazo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaFinPlazo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaFinPlazo.Location = New System.Drawing.Point(63, 57)
        Me.txtFechaFinPlazo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.MinValue = New Date(CType(0, Long))
        Me.txtFechaFinPlazo.Name = "txtFechaFinPlazo"
        Me.txtFechaFinPlazo.ShowCheckBox = False
        Me.txtFechaFinPlazo.Size = New System.Drawing.Size(154, 20)
        Me.txtFechaFinPlazo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaFinPlazo.TabIndex = 217
        Me.txtFechaFinPlazo.Value = New Date(2015, 9, 16, 16, 22, 4, 448)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(37, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 216
        Me.Label7.Text = "Al:"
        '
        'cboAlmacen
        '
        Me.cboAlmacen.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.BeforeTouchSize = New System.Drawing.Size(254, 21)
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.Location = New System.Drawing.Point(119, 3)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(254, 21)
        Me.cboAlmacen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAlmacen.TabIndex = 238
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(39, 158)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 260
        Me.Label16.Text = "Indicaciones:"
        '
        'txtIndicaciones
        '
        Me.txtIndicaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicaciones.Location = New System.Drawing.Point(116, 158)
        Me.txtIndicaciones.Multiline = True
        Me.txtIndicaciones.Name = "txtIndicaciones"
        Me.txtIndicaciones.Size = New System.Drawing.Size(257, 71)
        Me.txtIndicaciones.TabIndex = 262
        '
        'Timer1
        '
        '
        'frmModalHistorialOC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!)
        CaptionLabel1.Location = New System.Drawing.Point(50, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "DETALLE DE ENTREGA"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(388, 386)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmModalHistorialOC"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnExistencia.ResumeLayout(False)
        Me.pnExistencia.PerformLayout()
        Me.pnDetallesOC.ResumeLayout(False)
        Me.pnDetallesOC.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtFechaInicioPlazo.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicioPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinPlazo.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnExistencia As System.Windows.Forms.Panel
    Friend WithEvents lblIdDocumento As System.Windows.Forms.Label
    Friend WithEvents txtNombreItem As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.DomainUpDown
    Friend WithEvents pnDetallesOC As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDirAlmacen As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaInicioPlazo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtFechaFinPlazo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents cboAlmacen As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtIndicaciones As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class

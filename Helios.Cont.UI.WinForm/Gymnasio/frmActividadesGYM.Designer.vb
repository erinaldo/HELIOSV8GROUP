<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmActividadesGYM
    Inherits frmMaster

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
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.gradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtActividad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgAgenda = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.redTagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.yellowTagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.greenTagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.blueTagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.otherColorTagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.patternToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.diagonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.verticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.horizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.hatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.noneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.timescaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.hourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.minutesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.minutesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.minutesToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.minutesToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.selectImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imageAlignmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.northToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.eastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.southToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.westToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.editItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lstDias = New System.Windows.Forms.CheckedListBox()
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gradientPanel2.SuspendLayout()
        CType(Me.txtActividad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.dgAgenda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contextMenuStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gradientPanel2
        '
        Me.gradientPanel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.gradientPanel2.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.gradientPanel2.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.gradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gradientPanel2.Controls.Add(Me.Label3)
        Me.gradientPanel2.Controls.Add(Me.Label2)
        Me.gradientPanel2.Controls.Add(Me.Label21)
        Me.gradientPanel2.Controls.Add(Me.txtActividad)
        Me.gradientPanel2.Controls.Add(Me.Label1)
        Me.gradientPanel2.Controls.Add(Me.txtFecha)
        Me.gradientPanel2.Location = New System.Drawing.Point(17, 12)
        Me.gradientPanel2.Name = "gradientPanel2"
        Me.gradientPanel2.Size = New System.Drawing.Size(779, 154)
        Me.gradientPanel2.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(217, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 15)
        Me.Label3.TabIndex = 414
        Me.Label3.Text = "Rango de hora: {01 - 24 Horas }"
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(103, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.RoundButton21.Font = New System.Drawing.Font("Ebrima", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(518, 310)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(120, 33)
        Me.RoundButton21.TabIndex = 413
        Me.RoundButton21.Text = "Guardar actividad"
        Me.RoundButton21.UseVisualStyle = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 14)
        Me.Label2.TabIndex = 411
        Me.Label2.Text = "Fec. registro"
        Me.Label2.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(27, 44)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(182, 14)
        Me.Label21.TabIndex = 410
        Me.Label21.Text = "Nombre de la actividad a desarrollar"
        '
        'txtActividad
        '
        Me.txtActividad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtActividad.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtActividad.BorderColor = System.Drawing.Color.Silver
        Me.txtActividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActividad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActividad.CornerRadius = 5
        Me.txtActividad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtActividad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActividad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtActividad.Location = New System.Drawing.Point(30, 68)
        Me.txtActividad.MaxLength = 80
        Me.txtActividad.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtActividad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.Size = New System.Drawing.Size(357, 20)
        Me.txtActividad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtActividad.TabIndex = 407
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(103, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(27, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 14)
        Me.Label1.TabIndex = 404
        Me.Label1.Text = "Clases o actividades"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
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
        Me.txtFecha.Calendar.Size = New System.Drawing.Size(158, 174)
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
        Me.txtFecha.Calendar.NoneButton.Location = New System.Drawing.Point(86, 0)
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
        Me.txtFecha.Calendar.TodayButton.Size = New System.Drawing.Size(86, 20)
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
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(30, 118)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.Size = New System.Drawing.Size(160, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 1
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        Me.txtFecha.Visible = False
        '
        'GradientPanel7
        '
        Me.GradientPanel7.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.GradientPanel7.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel7.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel7.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(809, 10)
        Me.GradientPanel7.TabIndex = 510
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel1.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.RoundButton22)
        Me.GradientPanel1.Controls.Add(Me.RoundButton21)
        Me.GradientPanel1.Controls.Add(Me.lstDias)
        Me.GradientPanel1.Controls.Add(Me.dgAgenda)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Location = New System.Drawing.Point(17, 172)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(780, 367)
        Me.GradientPanel1.TabIndex = 511
        '
        'dgAgenda
        '
        Me.dgAgenda.BackColor = System.Drawing.SystemColors.Window
        Me.dgAgenda.FreezeCaption = False
        Me.dgAgenda.Location = New System.Drawing.Point(30, 44)
        Me.dgAgenda.Name = "dgAgenda"
        Me.dgAgenda.Size = New System.Drawing.Size(451, 299)
        Me.dgAgenda.TabIndex = 2
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.MappingName = "Dia"
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 219
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.CellType = "MaskEdit"
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.MaskEdit.Mask = "##:##"
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.MappingName = "horainicio"
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.CellType = "MaskEdit"
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.MaskEdit.DateSeparator = Global.Microsoft.VisualBasic.ChrW(58)
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.MaskEdit.Mask = "##:##"
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.MaskEdit.UsageMode = Syncfusion.Windows.Forms.Tools.MaskedUsageMode.Normal
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.MappingName = "horafin"
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor15.Width = 113
        Me.dgAgenda.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15})
        Me.dgAgenda.Text = "GridGroupingControl1"
        Me.dgAgenda.VersionInfo = "12.4400.0.24"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Seleccionar Días"
        '
        'contextMenuStrip1
        '
        Me.contextMenuStrip1.Font = New System.Drawing.Font("Ebrima", 8.0!)
        Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.redTagToolStripMenuItem, Me.yellowTagToolStripMenuItem, Me.greenTagToolStripMenuItem, Me.blueTagToolStripMenuItem, Me.otherColorTagToolStripMenuItem, Me.toolStripMenuItem1, Me.patternToolStripMenuItem, Me.timescaleToolStripMenuItem, Me.toolStripMenuItem2, Me.selectImageToolStripMenuItem, Me.imageAlignmentToolStripMenuItem, Me.toolStripMenuItem5, Me.editItemToolStripMenuItem})
        Me.contextMenuStrip1.Name = "contextMenuStrip1"
        Me.contextMenuStrip1.Size = New System.Drawing.Size(158, 242)
        '
        'redTagToolStripMenuItem
        '
        Me.redTagToolStripMenuItem.Name = "redTagToolStripMenuItem"
        Me.redTagToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.redTagToolStripMenuItem.Text = "Red tag"
        Me.redTagToolStripMenuItem.Visible = False
        '
        'yellowTagToolStripMenuItem
        '
        Me.yellowTagToolStripMenuItem.Name = "yellowTagToolStripMenuItem"
        Me.yellowTagToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.yellowTagToolStripMenuItem.Text = "Yellow tag"
        Me.yellowTagToolStripMenuItem.Visible = False
        '
        'greenTagToolStripMenuItem
        '
        Me.greenTagToolStripMenuItem.Name = "greenTagToolStripMenuItem"
        Me.greenTagToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.greenTagToolStripMenuItem.Text = "Green tag"
        Me.greenTagToolStripMenuItem.Visible = False
        '
        'blueTagToolStripMenuItem
        '
        Me.blueTagToolStripMenuItem.Name = "blueTagToolStripMenuItem"
        Me.blueTagToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.blueTagToolStripMenuItem.Text = "Blue tag"
        Me.blueTagToolStripMenuItem.Visible = False
        '
        'otherColorTagToolStripMenuItem
        '
        Me.otherColorTagToolStripMenuItem.Name = "otherColorTagToolStripMenuItem"
        Me.otherColorTagToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.otherColorTagToolStripMenuItem.Text = "Other color tag..."
        Me.otherColorTagToolStripMenuItem.Visible = False
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(154, 6)
        '
        'patternToolStripMenuItem
        '
        Me.patternToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.diagonalToolStripMenuItem, Me.verticalToolStripMenuItem, Me.horizontalToolStripMenuItem, Me.hatchToolStripMenuItem, Me.toolStripMenuItem3, Me.noneToolStripMenuItem})
        Me.patternToolStripMenuItem.Name = "patternToolStripMenuItem"
        Me.patternToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.patternToolStripMenuItem.Text = "Pattern"
        Me.patternToolStripMenuItem.Visible = False
        '
        'diagonalToolStripMenuItem
        '
        Me.diagonalToolStripMenuItem.Name = "diagonalToolStripMenuItem"
        Me.diagonalToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.diagonalToolStripMenuItem.Text = "Diagonal"
        '
        'verticalToolStripMenuItem
        '
        Me.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem"
        Me.verticalToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.verticalToolStripMenuItem.Text = "Vertical"
        '
        'horizontalToolStripMenuItem
        '
        Me.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem"
        Me.horizontalToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.horizontalToolStripMenuItem.Text = "Horizontal"
        '
        'hatchToolStripMenuItem
        '
        Me.hatchToolStripMenuItem.Name = "hatchToolStripMenuItem"
        Me.hatchToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.hatchToolStripMenuItem.Text = "Cross"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(122, 6)
        '
        'noneToolStripMenuItem
        '
        Me.noneToolStripMenuItem.Name = "noneToolStripMenuItem"
        Me.noneToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.noneToolStripMenuItem.Text = "None"
        '
        'timescaleToolStripMenuItem
        '
        Me.timescaleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.hourToolStripMenuItem, Me.minutesToolStripMenuItem, Me.toolStripMenuItem4, Me.minutesToolStripMenuItem1, Me.minutesToolStripMenuItem2, Me.minutesToolStripMenuItem3})
        Me.timescaleToolStripMenuItem.Name = "timescaleToolStripMenuItem"
        Me.timescaleToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.timescaleToolStripMenuItem.Text = "Escala de tiempo"
        '
        'hourToolStripMenuItem
        '
        Me.hourToolStripMenuItem.Name = "hourToolStripMenuItem"
        Me.hourToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.hourToolStripMenuItem.Text = "1 hora"
        '
        'minutesToolStripMenuItem
        '
        Me.minutesToolStripMenuItem.Name = "minutesToolStripMenuItem"
        Me.minutesToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.minutesToolStripMenuItem.Text = "30 minutos"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(128, 22)
        Me.toolStripMenuItem4.Text = "15 minutos"
        '
        'minutesToolStripMenuItem1
        '
        Me.minutesToolStripMenuItem1.Name = "minutesToolStripMenuItem1"
        Me.minutesToolStripMenuItem1.Size = New System.Drawing.Size(128, 22)
        Me.minutesToolStripMenuItem1.Text = "10 minutos"
        '
        'minutesToolStripMenuItem2
        '
        Me.minutesToolStripMenuItem2.Name = "minutesToolStripMenuItem2"
        Me.minutesToolStripMenuItem2.Size = New System.Drawing.Size(128, 22)
        Me.minutesToolStripMenuItem2.Text = "6 minutos"
        '
        'minutesToolStripMenuItem3
        '
        Me.minutesToolStripMenuItem3.Name = "minutesToolStripMenuItem3"
        Me.minutesToolStripMenuItem3.Size = New System.Drawing.Size(128, 22)
        Me.minutesToolStripMenuItem3.Text = "5 minutos"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(154, 6)
        '
        'selectImageToolStripMenuItem
        '
        Me.selectImageToolStripMenuItem.Name = "selectImageToolStripMenuItem"
        Me.selectImageToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.selectImageToolStripMenuItem.Text = "Select Image..."
        Me.selectImageToolStripMenuItem.Visible = False
        '
        'imageAlignmentToolStripMenuItem
        '
        Me.imageAlignmentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.northToolStripMenuItem, Me.eastToolStripMenuItem, Me.southToolStripMenuItem, Me.westToolStripMenuItem})
        Me.imageAlignmentToolStripMenuItem.Name = "imageAlignmentToolStripMenuItem"
        Me.imageAlignmentToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.imageAlignmentToolStripMenuItem.Text = "Image Alignment"
        Me.imageAlignmentToolStripMenuItem.Visible = False
        '
        'northToolStripMenuItem
        '
        Me.northToolStripMenuItem.Name = "northToolStripMenuItem"
        Me.northToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.northToolStripMenuItem.Text = "North"
        '
        'eastToolStripMenuItem
        '
        Me.eastToolStripMenuItem.Name = "eastToolStripMenuItem"
        Me.eastToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.eastToolStripMenuItem.Text = "East"
        '
        'southToolStripMenuItem
        '
        Me.southToolStripMenuItem.Name = "southToolStripMenuItem"
        Me.southToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.southToolStripMenuItem.Text = "South"
        '
        'westToolStripMenuItem
        '
        Me.westToolStripMenuItem.Name = "westToolStripMenuItem"
        Me.westToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.westToolStripMenuItem.Text = "West"
        '
        'toolStripMenuItem5
        '
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        Me.toolStripMenuItem5.Size = New System.Drawing.Size(154, 6)
        '
        'editItemToolStripMenuItem
        '
        Me.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem"
        Me.editItemToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.editItemToolStripMenuItem.Text = "Editar texto"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lstDias
        '
        Me.lstDias.FormattingEnabled = True
        Me.lstDias.Items.AddRange(New Object() {"lunes", "martes", "miercoles", "jueves", "viernes", "sabado", "domingo"})
        Me.lstDias.Location = New System.Drawing.Point(518, 78)
        Me.lstDias.Name = "lstDias"
        Me.lstDias.Size = New System.Drawing.Size(184, 157)
        Me.lstDias.TabIndex = 3
        '
        'RoundButton22
        '
        Me.RoundButton22.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(73, 28)
        Me.RoundButton22.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton22.ForeColor = System.Drawing.Color.White
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(518, 44)
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(73, 28)
        Me.RoundButton22.TabIndex = 414
        Me.RoundButton22.Text = "Procesar"
        Me.RoundButton22.UseVisualStyle = True
        '
        'frmActividadesGYM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 60
        Me.ClientSize = New System.Drawing.Size(809, 551)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel7)
        Me.Controls.Add(Me.gradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActividadesGYM"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gradientPanel2.ResumeLayout(False)
        Me.gradientPanel2.PerformLayout()
        CType(Me.txtActividad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.dgAgenda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contextMenuStrip1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents gradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label21 As Label
    Friend WithEvents txtActividad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents GradientPanel7 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents RoundButton21 As RoundButton2
    Private WithEvents contextMenuStrip1 As ContextMenuStrip
    Private WithEvents redTagToolStripMenuItem As ToolStripMenuItem
    Private WithEvents yellowTagToolStripMenuItem As ToolStripMenuItem
    Private WithEvents greenTagToolStripMenuItem As ToolStripMenuItem
    Private WithEvents blueTagToolStripMenuItem As ToolStripMenuItem
    Private WithEvents otherColorTagToolStripMenuItem As ToolStripMenuItem
    Private WithEvents toolStripMenuItem1 As ToolStripSeparator
    Private WithEvents patternToolStripMenuItem As ToolStripMenuItem
    Private WithEvents diagonalToolStripMenuItem As ToolStripMenuItem
    Private WithEvents verticalToolStripMenuItem As ToolStripMenuItem
    Private WithEvents horizontalToolStripMenuItem As ToolStripMenuItem
    Private WithEvents hatchToolStripMenuItem As ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As ToolStripSeparator
    Private WithEvents noneToolStripMenuItem As ToolStripMenuItem
    Private WithEvents timescaleToolStripMenuItem As ToolStripMenuItem
    Private WithEvents hourToolStripMenuItem As ToolStripMenuItem
    Private WithEvents minutesToolStripMenuItem As ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As ToolStripMenuItem
    Private WithEvents minutesToolStripMenuItem1 As ToolStripMenuItem
    Private WithEvents minutesToolStripMenuItem2 As ToolStripMenuItem
    Private WithEvents minutesToolStripMenuItem3 As ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As ToolStripSeparator
    Private WithEvents selectImageToolStripMenuItem As ToolStripMenuItem
    Private WithEvents imageAlignmentToolStripMenuItem As ToolStripMenuItem
    Private WithEvents northToolStripMenuItem As ToolStripMenuItem
    Private WithEvents eastToolStripMenuItem As ToolStripMenuItem
    Private WithEvents southToolStripMenuItem As ToolStripMenuItem
    Private WithEvents westToolStripMenuItem As ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As ToolStripSeparator
    Private WithEvents editItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents dgAgenda As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Label3 As Label
    Friend WithEvents lstDias As CheckedListBox
    Friend WithEvents RoundButton22 As RoundButton2
End Class

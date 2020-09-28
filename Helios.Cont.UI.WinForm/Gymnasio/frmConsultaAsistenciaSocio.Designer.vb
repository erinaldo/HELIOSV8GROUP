<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaAsistenciaSocio
    Inherits frmMaster

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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaAsistenciaSocio))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel11 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dgvAsistencia = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.TXTcLIENTE = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtdni = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFechaInicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtFechaVcto = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtMembresia = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel11.SuspendLayout()
        CType(Me.dgvAsistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTcLIENTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVcto.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVcto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVcto.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMembresia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel11
        '
        Me.GradientPanel11.BackColor = System.Drawing.Color.White
        Me.GradientPanel11.BorderColor = System.Drawing.Color.MediumSeaGreen
        Me.GradientPanel11.BorderSides = CType((System.Windows.Forms.Border3DSide.Top Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.GradientPanel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel11.Controls.Add(Me.txtMembresia)
        Me.GradientPanel11.Controls.Add(Me.TextBoxExt1)
        Me.GradientPanel11.Controls.Add(Me.Label2)
        Me.GradientPanel11.Controls.Add(Me.txtFechaVcto)
        Me.GradientPanel11.Controls.Add(Me.txtFechaInicio)
        Me.GradientPanel11.Controls.Add(Me.Label1)
        Me.GradientPanel11.Controls.Add(Me.txtdni)
        Me.GradientPanel11.Controls.Add(Me.TXTcLIENTE)
        Me.GradientPanel11.Controls.Add(Me.ButtonAdv6)
        Me.GradientPanel11.Controls.Add(Me.Label21)
        Me.GradientPanel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel11.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel11.Name = "GradientPanel11"
        Me.GradientPanel11.Size = New System.Drawing.Size(671, 151)
        Me.GradientPanel11.TabIndex = 300
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(86, 23)
        Me.ButtonAdv6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(497, 32)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(86, 23)
        Me.ButtonAdv6.TabIndex = 3
        Me.ButtonAdv6.Text = "Consultar"
        Me.ButtonAdv6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(24, 13)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 14)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Socio / Cliente"
        '
        'dgvAsistencia
        '
        Me.dgvAsistencia.BackColor = System.Drawing.SystemColors.Window
        Me.dgvAsistencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAsistencia.FreezeCaption = False
        Me.dgvAsistencia.Location = New System.Drawing.Point(0, 151)
        Me.dgvAsistencia.Name = "dgvAsistencia"
        Me.dgvAsistencia.Size = New System.Drawing.Size(671, 281)
        Me.dgvAsistencia.TabIndex = 302
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "anio"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 73
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "mes"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 86
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "dia"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 85
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "hora"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 137
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "status"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 136
        Me.dgvAsistencia.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5})
        Me.dgvAsistencia.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("anio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("mes"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("dia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("hora"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("status")})
        Me.dgvAsistencia.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvAsistencia.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvAsistencia.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvAsistencia.Text = "gridGroupingControl1"
        Me.dgvAsistencia.VersionInfo = "12.2400.0.20"
        '
        'TXTcLIENTE
        '
        Me.TXTcLIENTE.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TXTcLIENTE.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TXTcLIENTE.BorderColor = System.Drawing.Color.Silver
        Me.TXTcLIENTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTcLIENTE.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTcLIENTE.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTcLIENTE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTcLIENTE.Location = New System.Drawing.Point(27, 35)
        Me.TXTcLIENTE.MaxLength = 10
        Me.TXTcLIENTE.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TXTcLIENTE.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTcLIENTE.Name = "TXTcLIENTE"
        Me.TXTcLIENTE.ReadOnly = True
        Me.TXTcLIENTE.Size = New System.Drawing.Size(321, 20)
        Me.TXTcLIENTE.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TXTcLIENTE.TabIndex = 6
        '
        'txtdni
        '
        Me.txtdni.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtdni.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtdni.BorderColor = System.Drawing.Color.Silver
        Me.txtdni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdni.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtdni.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtdni.Location = New System.Drawing.Point(354, 35)
        Me.txtdni.MaxLength = 10
        Me.txtdni.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtdni.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdni.Name = "txtdni"
        Me.txtdni.ReadOnly = True
        Me.txtdni.Size = New System.Drawing.Size(137, 20)
        Me.txtdni.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtdni.TabIndex = 510
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 14)
        Me.Label1.TabIndex = 511
        Me.Label1.Text = "Fecha contractual (Del - Al)"
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.txtFechaInicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaVcto.Calendar.AllowMultipleSelection = False
        Me.txtFechaVcto.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVcto.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaVcto.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVcto.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaVcto.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaVcto.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaVcto.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVcto.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVcto.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaVcto.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaVcto.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVcto.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.Name = "monthCalendar"
        Me.txtFechaVcto.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaVcto.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaVcto.Calendar.Size = New System.Drawing.Size(117, 174)
        Me.txtFechaVcto.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVcto.Calendar.TabIndex = 0
        Me.txtFechaVcto.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaVcto.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVcto.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVcto.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaVcto.Calendar.NoneButton.Location = New System.Drawing.Point(45, 0)
        Me.txtFechaVcto.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaVcto.Calendar.NoneButton.Text = "None"
        Me.txtFechaVcto.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaVcto.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVcto.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVcto.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaVcto.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVcto.Calendar.TodayButton.Size = New System.Drawing.Size(45, 20)
        Me.txtFechaVcto.Calendar.TodayButton.Text = "Today"
        Me.txtFechaVcto.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaInicio.Checked = False
        Me.txtFechaInicio.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaInicio.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaInicio.DropDownImage = Nothing
        Me.txtFechaInicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaInicio.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaInicio.Location = New System.Drawing.Point(27, 114)
        Me.txtFechaInicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.MinValue = New Date(CType(0, Long))
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.ReadOnly = True
        Me.txtFechaInicio.ShowCheckBox = False
        Me.txtFechaInicio.ShowDropButton = False
        Me.txtFechaInicio.Size = New System.Drawing.Size(133, 20)
        Me.txtFechaInicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicio.TabIndex = 514
        Me.txtFechaInicio.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'txtFechaVcto
        '
        Me.txtFechaVcto.BackColor = System.Drawing.Color.IndianRed
        Me.txtFechaVcto.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaVcto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVcto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaVcto.Calendar.AllowMultipleSelection = False
        Me.txtFechaVcto.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVcto.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaVcto.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVcto.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaVcto.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaVcto.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaVcto.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVcto.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVcto.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaVcto.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaVcto.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVcto.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.Name = "monthCalendar"
        Me.txtFechaVcto.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaVcto.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaVcto.Calendar.Size = New System.Drawing.Size(129, 174)
        Me.txtFechaVcto.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVcto.Calendar.TabIndex = 0
        Me.txtFechaVcto.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaVcto.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVcto.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVcto.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaVcto.Calendar.NoneButton.Location = New System.Drawing.Point(57, 0)
        Me.txtFechaVcto.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaVcto.Calendar.NoneButton.Text = "None"
        Me.txtFechaVcto.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaVcto.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVcto.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVcto.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaVcto.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVcto.Calendar.TodayButton.Size = New System.Drawing.Size(57, 20)
        Me.txtFechaVcto.Calendar.TodayButton.Text = "Today"
        Me.txtFechaVcto.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaVcto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVcto.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVcto.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaVcto.Checked = False
        Me.txtFechaVcto.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVcto.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaVcto.DropDownImage = Nothing
        Me.txtFechaVcto.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaVcto.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaVcto.Location = New System.Drawing.Point(166, 114)
        Me.txtFechaVcto.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.MinValue = New Date(CType(0, Long))
        Me.txtFechaVcto.Name = "txtFechaVcto"
        Me.txtFechaVcto.ReadOnly = True
        Me.txtFechaVcto.ShowCheckBox = False
        Me.txtFechaVcto.ShowDropButton = False
        Me.txtFechaVcto.Size = New System.Drawing.Size(133, 20)
        Me.txtFechaVcto.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVcto.TabIndex = 515
        Me.txtFechaVcto.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(351, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 14)
        Me.Label2.TabIndex = 516
        Me.Label2.Text = "Estado membresía"
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBoxExt1.Location = New System.Drawing.Point(354, 114)
        Me.TextBoxExt1.MaxLength = 10
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.ReadOnly = True
        Me.TextBoxExt1.Size = New System.Drawing.Size(137, 20)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBoxExt1.TabIndex = 517
        '
        'txtMembresia
        '
        Me.txtMembresia.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.txtMembresia.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtMembresia.BorderColor = System.Drawing.Color.MediumSeaGreen
        Me.txtMembresia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMembresia.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMembresia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMembresia.ForeColor = System.Drawing.Color.White
        Me.txtMembresia.Location = New System.Drawing.Point(27, 65)
        Me.txtMembresia.MaxLength = 10
        Me.txtMembresia.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtMembresia.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMembresia.Name = "txtMembresia"
        Me.txtMembresia.NearImage = CType(resources.GetObject("txtMembresia.NearImage"), System.Drawing.Image)
        Me.txtMembresia.ReadOnly = True
        Me.txtMembresia.Size = New System.Drawing.Size(321, 20)
        Me.txtMembresia.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtMembresia.TabIndex = 518
        '
        'frmConsultaAsistenciaSocio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.MediumSeaGreen
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.MediumSeaGreen
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Asistencia"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Text = "Socios"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(671, 432)
        Me.Controls.Add(Me.dgvAsistencia)
        Me.Controls.Add(Me.GradientPanel11)
        Me.Name = "frmConsultaAsistenciaSocio"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel11.ResumeLayout(False)
        Me.GradientPanel11.PerformLayout()
        CType(Me.dgvAsistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTcLIENTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVcto.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVcto.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVcto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMembresia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel11 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label21 As Label
    Private WithEvents dgvAsistencia As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents TXTcLIENTE As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtdni As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFechaVcto As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtFechaInicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMembresia As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class

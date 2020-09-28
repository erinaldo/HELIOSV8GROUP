Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSeleccionarRutaPorFecha
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSeleccionarRutaPorFecha))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextFechaProgramada = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaProgramada.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.RoundButton21)
        Me.GradientPanel1.Controls.Add(Me.TextFechaProgramada)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(633, 50)
        Me.GradientPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha laboral"
        '
        'TextFechaProgramada
        '
        Me.TextFechaProgramada.BackColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaProgramada.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaProgramada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextFechaProgramada.Calendar.AllowMultipleSelection = False
        Me.TextFechaProgramada.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaProgramada.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaProgramada.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaProgramada.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextFechaProgramada.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TextFechaProgramada.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextFechaProgramada.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaProgramada.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaProgramada.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextFechaProgramada.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Calendar.Iso8601CalenderFormat = False
        Me.TextFechaProgramada.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaProgramada.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.Calendar.Name = "monthCalendar"
        Me.TextFechaProgramada.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextFechaProgramada.Calendar.SelectedDates = New Date(-1) {}
        Me.TextFechaProgramada.Calendar.Size = New System.Drawing.Size(241, 174)
        Me.TextFechaProgramada.Calendar.SizeToFit = True
        Me.TextFechaProgramada.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaProgramada.Calendar.TabIndex = 0
        Me.TextFechaProgramada.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextFechaProgramada.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaProgramada.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaProgramada.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Calendar.NoneButton.IsBackStageButton = False
        Me.TextFechaProgramada.Calendar.NoneButton.Location = New System.Drawing.Point(165, 0)
        Me.TextFechaProgramada.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextFechaProgramada.Calendar.NoneButton.Text = "None"
        Me.TextFechaProgramada.Calendar.NoneButton.UseVisualStyle = True
        Me.TextFechaProgramada.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TextFechaProgramada.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaProgramada.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaProgramada.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Calendar.TodayButton.IsBackStageButton = False
        Me.TextFechaProgramada.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaProgramada.Calendar.TodayButton.Size = New System.Drawing.Size(241, 20)
        Me.TextFechaProgramada.Calendar.TodayButton.Text = "Today"
        Me.TextFechaProgramada.Calendar.TodayButton.UseVisualStyle = True
        Me.TextFechaProgramada.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaProgramada.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaProgramada.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaProgramada.Checked = False
        Me.TextFechaProgramada.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaProgramada.CustomFormat = "dd/MM/yyyy"
        Me.TextFechaProgramada.DropDownImage = Nothing
        Me.TextFechaProgramada.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaProgramada.EnableNullDate = False
        Me.TextFechaProgramada.EnableNullKeys = False
        Me.TextFechaProgramada.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaProgramada.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextFechaProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaProgramada.Location = New System.Drawing.Point(87, 15)
        Me.TextFechaProgramada.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.MinValue = New Date(CType(0, Long))
        Me.TextFechaProgramada.Name = "TextFechaProgramada"
        Me.TextFechaProgramada.ShowCheckBox = False
        Me.TextFechaProgramada.ShowUpDownOnFocus = True
        Me.TextFechaProgramada.Size = New System.Drawing.Size(246, 21)
        Me.TextFechaProgramada.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaProgramada.TabIndex = 601
        Me.TextFechaProgramada.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(101, 30)
        Me.RoundButton21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(339, 7)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(101, 30)
        Me.RoundButton21.TabIndex = 602
        Me.RoundButton21.Text = "Consultar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'dgvCuentas
        '
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCuentas.BackColor = System.Drawing.Color.White
        Me.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuentas.FreezeCaption = False
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 50)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.Size = New System.Drawing.Size(633, 269)
        Me.dgvCuentas.TabIndex = 540
        Me.dgvCuentas.TableDescriptor.AllowNew = False
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Size = 12.0!
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCuentas.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCuentas.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "tipo"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 101
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "horasalida"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 140
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "matricula"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 123
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "destino"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 218
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "programacion_id"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "ruta_id"
        GridColumnDescriptor6.SerializedImageArray = ""
        Me.dgvCuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6})
        Me.dgvCuentas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCuentas.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCuentas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("horasalida"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("matricula"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("destino"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("programacion_id"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ruta_id")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
        '
        'FormSeleccionarRutaPorFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.CaptionBarColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.CaptionBarHeight = 55
        Me.CaptionForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionLabel1.Location = New System.Drawing.Point(50, 10)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Rutas"
        CaptionLabel2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel2.Location = New System.Drawing.Point(50, 25)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(190, 24)
        CaptionLabel2.Text = "Seleccionar fecha"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(633, 319)
        Me.Controls.Add(Me.dgvCuentas)
        Me.Controls.Add(Me.GradientPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSeleccionarRutaPorFecha"
        Me.ShowIcon = False
        Me.Text = "Seleccionar Ruta Por Fecha"
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.TextFechaProgramada.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextFechaProgramada As Tools.DateTimePickerAdv
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
End Class

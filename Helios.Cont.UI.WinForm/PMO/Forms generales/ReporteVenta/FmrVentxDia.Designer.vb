<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FmrVentxDia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FmrVentxDia))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rptAportes = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Controls.Add(Me.txtFecha)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1118, 111)
        Me.Panel1.TabIndex = 4
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Location = New System.Drawing.Point(74, 9)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(935, 37)
        Me.GradientPanel1.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(7, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(249, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LISTADO DE COMPROBANTES POR DIA"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
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
        Me.txtFecha.Calendar.Size = New System.Drawing.Size(129, 174)
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
        Me.txtFecha.Calendar.NoneButton.Location = New System.Drawing.Point(57, 0)
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
        Me.txtFecha.Calendar.TodayButton.Size = New System.Drawing.Size(57, 20)
        Me.txtFecha.Calendar.TodayButton.Text = "Today"
        Me.txtFecha.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.Checked = False
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.CustomFormat = "dd/MM/yyyy"
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecha.ForeColor = System.Drawing.Color.Black
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(87, 76)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.Size = New System.Drawing.Size(133, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 12
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(84, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Seleccionar día"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(101, 32)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(244, 66)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(101, 32)
        Me.ButtonAdv1.TabIndex = 10
        Me.ButtonAdv1.Text = "Generar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 111)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1118, 28)
        Me.Panel2.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 139)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(90, 354)
        Me.Panel3.TabIndex = 6
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1028, 139)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(90, 354)
        Me.Panel4.TabIndex = 7
        '
        'rptAportes
        '
        Me.rptAportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptAportes.Location = New System.Drawing.Point(90, 139)
        Me.rptAportes.Name = "rptAportes"
        Me.rptAportes.Size = New System.Drawing.Size(938, 354)
        Me.rptAportes.TabIndex = 8
        '
        'FmrVentxDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 9)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        CaptionLabel1.Location = New System.Drawing.Point(55, 18)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Reporte"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1118, 493)
        Me.Controls.Add(Me.rptAportes)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FmrVentxDia"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents rptAportes As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class

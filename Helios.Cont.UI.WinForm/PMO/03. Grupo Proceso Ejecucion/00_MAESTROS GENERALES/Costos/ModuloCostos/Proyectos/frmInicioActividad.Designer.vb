<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInicioActividad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicioActividad))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtFecInicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtActividad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.txtFecInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecInicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActividad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(109, 41)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(131, 143)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(109, 41)
        Me.ButtonAdv1.TabIndex = 13
        Me.ButtonAdv1.Text = "Confirmar Inicio"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'txtFecInicio
        '
        Me.txtFecInicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFecInicio.Calendar.AllowMultipleSelection = False
        Me.txtFecInicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecInicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecInicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecInicio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecInicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecInicio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFecInicio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFecInicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecInicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecInicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFecInicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFecInicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFecInicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFecInicio.Calendar.Iso8601CalenderFormat = False
        Me.txtFecInicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFecInicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecInicio.Calendar.Name = "monthCalendar"
        Me.txtFecInicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFecInicio.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFecInicio.Calendar.Size = New System.Drawing.Size(152, 174)
        Me.txtFecInicio.Calendar.SizeToFit = True
        Me.txtFecInicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecInicio.Calendar.TabIndex = 0
        Me.txtFecInicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFecInicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecInicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecInicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecInicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFecInicio.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFecInicio.Calendar.NoneButton.Location = New System.Drawing.Point(80, 0)
        Me.txtFecInicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFecInicio.Calendar.NoneButton.Text = "None"
        Me.txtFecInicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFecInicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecInicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecInicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecInicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFecInicio.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFecInicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFecInicio.Calendar.TodayButton.Size = New System.Drawing.Size(80, 20)
        Me.txtFecInicio.Calendar.TodayButton.Text = "Today"
        Me.txtFecInicio.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFecInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecInicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecInicio.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecInicio.CustomFormat = "dd/MM/yyyy"
        Me.txtFecInicio.DropDownImage = Nothing
        Me.txtFecInicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecInicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecInicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecInicio.Location = New System.Drawing.Point(29, 99)
        Me.txtFecInicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecInicio.MinValue = New Date(CType(0, Long))
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.ShowCheckBox = False
        Me.txtFecInicio.Size = New System.Drawing.Size(156, 20)
        Me.txtFecInicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecInicio.TabIndex = 12
        Me.txtFecInicio.Value = New Date(2017, 1, 18, 12, 45, 31, 764)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Inicio ejecutado"
        '
        'txtActividad
        '
        Me.txtActividad.BackColor = System.Drawing.Color.White
        Me.txtActividad.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtActividad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtActividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActividad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtActividad.Location = New System.Drawing.Point(29, 39)
        Me.txtActividad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.ReadOnly = True
        Me.txtActividad.Size = New System.Drawing.Size(304, 22)
        Me.txtActividad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtActividad.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Actividad"
        '
        'frmInicioActividad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 9)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(180, 24)
        CaptionLabel1.Text = "Iniciar Actividad/Tarea"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(365, 194)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.txtFecInicio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtActividad)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInicioActividad"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtFecInicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActividad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtFecInicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtActividad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

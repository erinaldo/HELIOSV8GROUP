<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCulminarActividad
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtActividad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInicio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecCierre = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.txtActividad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecCierre.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Actividad"
        '
        'txtActividad
        '
        Me.txtActividad.BackColor = System.Drawing.Color.White
        Me.txtActividad.BeforeTouchSize = New System.Drawing.Size(304, 22)
        Me.txtActividad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtActividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActividad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtActividad.Location = New System.Drawing.Point(29, 37)
        Me.txtActividad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.ReadOnly = True
        Me.txtActividad.Size = New System.Drawing.Size(304, 22)
        Me.txtActividad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtActividad.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Inicio ejecutado"
        '
        'txtInicio
        '
        Me.txtInicio.BackColor = System.Drawing.Color.White
        Me.txtInicio.BeforeTouchSize = New System.Drawing.Size(304, 22)
        Me.txtInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInicio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInicio.Location = New System.Drawing.Point(29, 99)
        Me.txtInicio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.ReadOnly = True
        Me.txtInicio.Size = New System.Drawing.Size(128, 22)
        Me.txtInicio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtInicio.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(174, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha de culminación o cierre"
        '
        'txtFecCierre
        '
        Me.txtFecCierre.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecCierre.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFecCierre.Calendar.AllowMultipleSelection = False
        Me.txtFecCierre.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecCierre.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecCierre.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecCierre.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecCierre.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecCierre.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFecCierre.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFecCierre.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecCierre.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecCierre.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFecCierre.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFecCierre.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFecCierre.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFecCierre.Calendar.Iso8601CalenderFormat = False
        Me.txtFecCierre.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFecCierre.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecCierre.Calendar.Name = "monthCalendar"
        Me.txtFecCierre.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFecCierre.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFecCierre.Calendar.Size = New System.Drawing.Size(152, 174)
        Me.txtFecCierre.Calendar.SizeToFit = True
        Me.txtFecCierre.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecCierre.Calendar.TabIndex = 0
        Me.txtFecCierre.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFecCierre.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecCierre.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecCierre.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecCierre.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFecCierre.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFecCierre.Calendar.NoneButton.Location = New System.Drawing.Point(80, 0)
        Me.txtFecCierre.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFecCierre.Calendar.NoneButton.Text = "None"
        Me.txtFecCierre.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFecCierre.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecCierre.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecCierre.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecCierre.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFecCierre.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFecCierre.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFecCierre.Calendar.TodayButton.Size = New System.Drawing.Size(80, 20)
        Me.txtFecCierre.Calendar.TodayButton.Text = "Today"
        Me.txtFecCierre.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFecCierre.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecCierre.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecCierre.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecCierre.CustomFormat = "dd/MM/yyyy"
        Me.txtFecCierre.DropDownImage = Nothing
        Me.txtFecCierre.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecCierre.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecCierre.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecCierre.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecCierre.Location = New System.Drawing.Point(177, 100)
        Me.txtFecCierre.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecCierre.MinValue = New Date(CType(0, Long))
        Me.txtFecCierre.Name = "txtFecCierre"
        Me.txtFecCierre.ShowCheckBox = False
        Me.txtFecCierre.Size = New System.Drawing.Size(156, 20)
        Me.txtFecCierre.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecCierre.TabIndex = 5
        Me.txtFecCierre.Value = New Date(2017, 1, 18, 12, 45, 31, 764)
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.OrangeRed
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(109, 41)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(131, 141)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(109, 41)
        Me.ButtonAdv1.TabIndex = 6
        Me.ButtonAdv1.Text = "Confirmar Cierre"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'frmCulminarActividad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        Me.ClientSize = New System.Drawing.Size(365, 194)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.txtFecCierre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtInicio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtActividad)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCulminarActividad"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtActividad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecCierre.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtActividad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInicio As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecCierre As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
End Class

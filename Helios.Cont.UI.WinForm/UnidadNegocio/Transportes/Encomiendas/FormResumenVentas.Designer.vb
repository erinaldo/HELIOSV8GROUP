<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormResumenVentas
    Inherits Syncfusion.Windows.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormResumenVentas))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextFechaMes = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.TextFechaDia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.RBPendiente = New System.Windows.Forms.RadioButton()
        Me.RBAcumuladoDia = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBA4 = New System.Windows.Forms.RadioButton()
        Me.RBTicket = New System.Windows.Forms.RadioButton()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.CirclePictureBox1 = New Helios.Cont.Presentation.WinForm.CirclePictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TextFechaMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaMes.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaDia.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextFechaMes)
        Me.GroupBox1.Controls.Add(Me.TextFechaDia)
        Me.GroupBox1.Controls.Add(Me.RBPendiente)
        Me.GroupBox1.Controls.Add(Me.RBAcumuladoDia)
        Me.GroupBox1.Location = New System.Drawing.Point(172, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(229, 159)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Impresión"
        '
        'TextFechaMes
        '
        Me.TextFechaMes.BackColor = System.Drawing.SystemColors.HotTrack
        Me.TextFechaMes.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaMes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextFechaMes.Calendar.AllowMultipleSelection = False
        Me.TextFechaMes.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaMes.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaMes.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaMes.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaMes.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextFechaMes.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TextFechaMes.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextFechaMes.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaMes.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaMes.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextFechaMes.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextFechaMes.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextFechaMes.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextFechaMes.Calendar.Iso8601CalenderFormat = False
        Me.TextFechaMes.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaMes.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaMes.Calendar.Name = "monthCalendar"
        Me.TextFechaMes.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextFechaMes.Calendar.SelectedDates = New Date(-1) {}
        Me.TextFechaMes.Calendar.Size = New System.Drawing.Size(154, 174)
        Me.TextFechaMes.Calendar.SizeToFit = True
        Me.TextFechaMes.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaMes.Calendar.TabIndex = 0
        Me.TextFechaMes.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextFechaMes.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaMes.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaMes.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaMes.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaMes.Calendar.NoneButton.IsBackStageButton = False
        Me.TextFechaMes.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.TextFechaMes.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextFechaMes.Calendar.NoneButton.Text = "None"
        Me.TextFechaMes.Calendar.NoneButton.UseVisualStyle = True
        Me.TextFechaMes.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TextFechaMes.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaMes.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaMes.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaMes.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaMes.Calendar.TodayButton.IsBackStageButton = False
        Me.TextFechaMes.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaMes.Calendar.TodayButton.Size = New System.Drawing.Size(154, 20)
        Me.TextFechaMes.Calendar.TodayButton.Text = "Today"
        Me.TextFechaMes.Calendar.TodayButton.UseVisualStyle = True
        Me.TextFechaMes.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaMes.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaMes.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaMes.Checked = False
        Me.TextFechaMes.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaMes.CustomFormat = "MM/yyyy"
        Me.TextFechaMes.DropDownImage = Nothing
        Me.TextFechaMes.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaMes.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaMes.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaMes.EnableNullDate = False
        Me.TextFechaMes.EnableNullKeys = False
        Me.TextFechaMes.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaMes.ForeColor = System.Drawing.Color.White
        Me.TextFechaMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaMes.Location = New System.Drawing.Point(39, 111)
        Me.TextFechaMes.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaMes.MinValue = New Date(CType(0, Long))
        Me.TextFechaMes.Name = "TextFechaMes"
        Me.TextFechaMes.ShowCheckBox = False
        Me.TextFechaMes.Size = New System.Drawing.Size(156, 21)
        Me.TextFechaMes.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaMes.TabIndex = 602
        Me.TextFechaMes.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        Me.TextFechaMes.Visible = False
        '
        'TextFechaDia
        '
        Me.TextFechaDia.BackColor = System.Drawing.SystemColors.HotTrack
        Me.TextFechaDia.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaDia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextFechaDia.Calendar.AllowMultipleSelection = False
        Me.TextFechaDia.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaDia.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaDia.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaDia.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaDia.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextFechaDia.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TextFechaDia.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextFechaDia.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaDia.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaDia.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextFechaDia.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextFechaDia.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextFechaDia.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextFechaDia.Calendar.Iso8601CalenderFormat = False
        Me.TextFechaDia.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaDia.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaDia.Calendar.Name = "monthCalendar"
        Me.TextFechaDia.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextFechaDia.Calendar.SelectedDates = New Date(-1) {}
        Me.TextFechaDia.Calendar.Size = New System.Drawing.Size(154, 174)
        Me.TextFechaDia.Calendar.SizeToFit = True
        Me.TextFechaDia.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaDia.Calendar.TabIndex = 0
        Me.TextFechaDia.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextFechaDia.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaDia.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaDia.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaDia.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaDia.Calendar.NoneButton.IsBackStageButton = False
        Me.TextFechaDia.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.TextFechaDia.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextFechaDia.Calendar.NoneButton.Text = "None"
        Me.TextFechaDia.Calendar.NoneButton.UseVisualStyle = True
        Me.TextFechaDia.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TextFechaDia.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaDia.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaDia.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaDia.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaDia.Calendar.TodayButton.IsBackStageButton = False
        Me.TextFechaDia.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaDia.Calendar.TodayButton.Size = New System.Drawing.Size(154, 20)
        Me.TextFechaDia.Calendar.TodayButton.Text = "Today"
        Me.TextFechaDia.Calendar.TodayButton.UseVisualStyle = True
        Me.TextFechaDia.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaDia.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaDia.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaDia.Checked = False
        Me.TextFechaDia.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaDia.CustomFormat = "dd/MM/yyyy"
        Me.TextFechaDia.DropDownImage = Nothing
        Me.TextFechaDia.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaDia.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaDia.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaDia.EnableNullDate = False
        Me.TextFechaDia.EnableNullKeys = False
        Me.TextFechaDia.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaDia.ForeColor = System.Drawing.Color.White
        Me.TextFechaDia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaDia.Location = New System.Drawing.Point(39, 56)
        Me.TextFechaDia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaDia.MinValue = New Date(CType(0, Long))
        Me.TextFechaDia.Name = "TextFechaDia"
        Me.TextFechaDia.ShowCheckBox = False
        Me.TextFechaDia.Size = New System.Drawing.Size(156, 21)
        Me.TextFechaDia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaDia.TabIndex = 601
        Me.TextFechaDia.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'RBPendiente
        '
        Me.RBPendiente.AutoSize = True
        Me.RBPendiente.Location = New System.Drawing.Point(23, 90)
        Me.RBPendiente.Name = "RBPendiente"
        Me.RBPendiente.Size = New System.Drawing.Size(109, 17)
        Me.RBPendiente.TabIndex = 1
        Me.RBPendiente.Text = "Resúmen del mes"
        Me.RBPendiente.UseVisualStyleBackColor = True
        '
        'RBAcumuladoDia
        '
        Me.RBAcumuladoDia.AutoSize = True
        Me.RBAcumuladoDia.Checked = True
        Me.RBAcumuladoDia.Location = New System.Drawing.Point(23, 36)
        Me.RBAcumuladoDia.Name = "RBAcumuladoDia"
        Me.RBAcumuladoDia.Size = New System.Drawing.Size(106, 17)
        Me.RBAcumuladoDia.TabIndex = 0
        Me.RBAcumuladoDia.TabStop = True
        Me.RBAcumuladoDia.Text = "Resúmen del día"
        Me.RBAcumuladoDia.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBA4)
        Me.GroupBox2.Controls.Add(Me.RBTicket)
        Me.GroupBox2.Controls.Add(Me.RoundButton21)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 203)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(372, 67)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Imprimir en formato:"
        '
        'RBA4
        '
        Me.RBA4.AutoSize = True
        Me.RBA4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBA4.Location = New System.Drawing.Point(109, 31)
        Me.RBA4.Name = "RBA4"
        Me.RBA4.Size = New System.Drawing.Size(40, 19)
        Me.RBA4.TabIndex = 7
        Me.RBA4.Text = "A4"
        Me.RBA4.UseVisualStyleBackColor = True
        '
        'RBTicket
        '
        Me.RBTicket.AutoSize = True
        Me.RBTicket.Checked = True
        Me.RBTicket.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBTicket.Location = New System.Drawing.Point(30, 31)
        Me.RBTicket.Name = "RBTicket"
        Me.RBTicket.Size = New System.Drawing.Size(60, 19)
        Me.RBTicket.TabIndex = 6
        Me.RBTicket.TabStop = True
        Me.RBTicket.Text = "Ticket"
        Me.RBTicket.UseVisualStyleBackColor = True
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(123, 33)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.Image = CType(resources.GetObject("RoundButton21.Image"), System.Drawing.Image)
        Me.RoundButton21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(215, 19)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(123, 33)
        Me.RoundButton21.TabIndex = 5
        Me.RoundButton21.Text = "Imprimir"
        Me.RoundButton21.UseVisualStyle = True
        '
        'CirclePictureBox1
        '
        Me.CirclePictureBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CirclePictureBox1.Image = CType(resources.GetObject("CirclePictureBox1.Image"), System.Drawing.Image)
        Me.CirclePictureBox1.Location = New System.Drawing.Point(29, 47)
        Me.CirclePictureBox1.Name = "CirclePictureBox1"
        Me.CirclePictureBox1.Size = New System.Drawing.Size(114, 114)
        Me.CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.CirclePictureBox1.TabIndex = 3
        Me.CirclePictureBox1.TabStop = False
        '
        'FormResumenVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 2
        Me.CaptionBarColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Consultar ventas"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(430, 278)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CirclePictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormResumenVentas"
        Me.ShowIcon = False
        Me.Text = "Resumen Ventas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TextFechaMes.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaDia.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RBPendiente As RadioButton
    Friend WithEvents RBAcumuladoDia As RadioButton
    Friend WithEvents CirclePictureBox1 As CirclePictureBox
    Friend WithEvents TextFechaDia As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents TextFechaMes As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RBA4 As RadioButton
    Friend WithEvents RBTicket As RadioButton
End Class

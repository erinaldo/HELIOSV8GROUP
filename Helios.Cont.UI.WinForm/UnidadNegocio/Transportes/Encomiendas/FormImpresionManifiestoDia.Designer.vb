Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormImpresionManifiestoDia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImpresionManifiestoDia))
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.txtFechaVenta = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboChofer = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextChoferTripulante = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextUnidadVehiculo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBHistorial = New System.Windows.Forms.RadioButton()
        Me.RBAcumuladoDia = New System.Windows.Forms.RadioButton()
        CType(Me.txtFechaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVenta.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboChofer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextChoferTripulante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextUnidadVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(123, 36)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.Image = CType(resources.GetObject("RoundButton21.Image"), System.Drawing.Image)
        Me.RoundButton21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(139, 245)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(123, 36)
        Me.RoundButton21.TabIndex = 595
        Me.RoundButton21.Text = "Imprimir"
        Me.RoundButton21.UseVisualStyle = True
        '
        'txtFechaVenta
        '
        Me.txtFechaVenta.BackColor = System.Drawing.Color.White
        Me.txtFechaVenta.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaVenta.Calendar.AllowMultipleSelection = False
        Me.txtFechaVenta.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVenta.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaVenta.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVenta.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVenta.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaVenta.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaVenta.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaVenta.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVenta.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVenta.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaVenta.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaVenta.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaVenta.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaVenta.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaVenta.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVenta.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVenta.Calendar.Name = "monthCalendar"
        Me.txtFechaVenta.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaVenta.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaVenta.Calendar.Size = New System.Drawing.Size(185, 174)
        Me.txtFechaVenta.Calendar.SizeToFit = True
        Me.txtFechaVenta.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVenta.Calendar.TabIndex = 0
        Me.txtFechaVenta.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaVenta.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVenta.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVenta.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVenta.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVenta.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaVenta.Calendar.NoneButton.Location = New System.Drawing.Point(109, 0)
        Me.txtFechaVenta.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaVenta.Calendar.NoneButton.Text = "None"
        Me.txtFechaVenta.Calendar.NoneButton.UseVisualStyle = True
        Me.txtFechaVenta.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.txtFechaVenta.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVenta.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVenta.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVenta.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVenta.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaVenta.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVenta.Calendar.TodayButton.Size = New System.Drawing.Size(185, 20)
        Me.txtFechaVenta.Calendar.TodayButton.Text = "Today"
        Me.txtFechaVenta.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaVenta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVenta.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVenta.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaVenta.Checked = False
        Me.txtFechaVenta.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVenta.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaVenta.DropDownImage = Nothing
        Me.txtFechaVenta.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVenta.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVenta.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaVenta.EnableNullDate = False
        Me.txtFechaVenta.EnableNullKeys = False
        Me.txtFechaVenta.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVenta.ForeColor = System.Drawing.Color.Black
        Me.txtFechaVenta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaVenta.Location = New System.Drawing.Point(137, 28)
        Me.txtFechaVenta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVenta.MinValue = New Date(CType(0, Long))
        Me.txtFechaVenta.Name = "txtFechaVenta"
        Me.txtFechaVenta.ShowCheckBox = False
        Me.txtFechaVenta.Size = New System.Drawing.Size(187, 25)
        Me.txtFechaVenta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVenta.TabIndex = 610
        Me.txtFechaVenta.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(505, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 19)
        Me.Label2.TabIndex = 611
        Me.Label2.Text = "Chofer:"
        '
        'ComboChofer
        '
        Me.ComboChofer.BackColor = System.Drawing.Color.White
        Me.ComboChofer.BeforeTouchSize = New System.Drawing.Size(328, 19)
        Me.ComboChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboChofer.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboChofer.Location = New System.Drawing.Point(509, 61)
        Me.ComboChofer.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboChofer.Name = "ComboChofer"
        Me.ComboChofer.Size = New System.Drawing.Size(328, 19)
        Me.ComboChofer.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboChofer.TabIndex = 637
        '
        'TextChoferTripulante
        '
        Me.TextChoferTripulante.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextChoferTripulante.BeforeTouchSize = New System.Drawing.Size(335, 22)
        Me.TextChoferTripulante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextChoferTripulante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextChoferTripulante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextChoferTripulante.CornerRadius = 3
        Me.TextChoferTripulante.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextChoferTripulante.FarImage = CType(resources.GetObject("TextChoferTripulante.FarImage"), System.Drawing.Image)
        Me.TextChoferTripulante.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextChoferTripulante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextChoferTripulante.Location = New System.Drawing.Point(30, 207)
        Me.TextChoferTripulante.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextChoferTripulante.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextChoferTripulante.Name = "TextChoferTripulante"
        Me.TextChoferTripulante.Size = New System.Drawing.Size(335, 22)
        Me.TextChoferTripulante.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextChoferTripulante.TabIndex = 650
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(27, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 18)
        Me.Label7.TabIndex = 649
        Me.Label7.Text = "Chofer - tripulante"
        '
        'TextUnidadVehiculo
        '
        Me.TextUnidadVehiculo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextUnidadVehiculo.BeforeTouchSize = New System.Drawing.Size(335, 22)
        Me.TextUnidadVehiculo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextUnidadVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextUnidadVehiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextUnidadVehiculo.CornerRadius = 3
        Me.TextUnidadVehiculo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextUnidadVehiculo.FarImage = CType(resources.GetObject("TextUnidadVehiculo.FarImage"), System.Drawing.Image)
        Me.TextUnidadVehiculo.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextUnidadVehiculo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextUnidadVehiculo.Location = New System.Drawing.Point(30, 146)
        Me.TextUnidadVehiculo.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextUnidadVehiculo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextUnidadVehiculo.Name = "TextUnidadVehiculo"
        Me.TextUnidadVehiculo.Size = New System.Drawing.Size(335, 22)
        Me.TextUnidadVehiculo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextUnidadVehiculo.TabIndex = 648
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(27, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 18)
        Me.Label6.TabIndex = 647
        Me.Label6.Text = "Unidad Vehículo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBHistorial)
        Me.GroupBox1.Controls.Add(Me.RBAcumuladoDia)
        Me.GroupBox1.Controls.Add(Me.txtFechaVenta)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(335, 98)
        Me.GroupBox1.TabIndex = 651
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo impresión"
        '
        'RBHistorial
        '
        Me.RBHistorial.AutoSize = True
        Me.RBHistorial.Checked = True
        Me.RBHistorial.Location = New System.Drawing.Point(17, 65)
        Me.RBHistorial.Name = "RBHistorial"
        Me.RBHistorial.Size = New System.Drawing.Size(72, 17)
        Me.RBHistorial.TabIndex = 611
        Me.RBHistorial.TabStop = True
        Me.RBHistorial.Text = "Selección"
        Me.RBHistorial.UseVisualStyleBackColor = True
        '
        'RBAcumuladoDia
        '
        Me.RBAcumuladoDia.AutoSize = True
        Me.RBAcumuladoDia.Location = New System.Drawing.Point(17, 34)
        Me.RBAcumuladoDia.Name = "RBAcumuladoDia"
        Me.RBAcumuladoDia.Size = New System.Drawing.Size(114, 17)
        Me.RBAcumuladoDia.TabIndex = 0
        Me.RBAcumuladoDia.Text = "Acumulado del día"
        Me.RBAcumuladoDia.UseVisualStyleBackColor = True
        '
        'FormImpresionManifiestoDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 2
        Me.ClientSize = New System.Drawing.Size(402, 287)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextChoferTripulante)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextUnidadVehiculo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboChofer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RoundButton21)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormImpresionManifiestoDia"
        Me.ShowIcon = False
        CType(Me.txtFechaVenta.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboChofer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextChoferTripulante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextUnidadVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents txtFechaVenta As Tools.DateTimePickerAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboChofer As Tools.ComboBoxAdv
    Friend WithEvents TextChoferTripulante As Tools.TextBoxExt
    Friend WithEvents Label7 As Label
    Friend WithEvents TextUnidadVehiculo As Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RBHistorial As RadioButton
    Friend WithEvents RBAcumuladoDia As RadioButton
End Class

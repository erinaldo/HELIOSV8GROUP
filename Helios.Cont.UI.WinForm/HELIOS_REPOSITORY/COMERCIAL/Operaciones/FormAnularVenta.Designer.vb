Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAnularVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAnularVenta))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BunifuThinButton23 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.txtInfoVenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtFechaConfirma = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        CType(Me.txtInfoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaConfirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaConfirma.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(126, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 14)
        Me.Label2.TabIndex = 682
        Me.Label2.Text = "Anular venta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(29, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 683
        Me.Label1.Text = "Información de la venta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(29, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 684
        Me.Label3.Text = "Fecha de confirmación"
        '
        'BunifuThinButton23
        '
        Me.BunifuThinButton23.ActiveBorderThickness = 1
        Me.BunifuThinButton23.ActiveCornerRadius = 20
        Me.BunifuThinButton23.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BunifuThinButton23.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BunifuThinButton23.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton23.BackgroundImage = CType(resources.GetObject("BunifuThinButton23.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton23.ButtonText = "ACEPTAR"
        Me.BunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton23.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton23.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton23.IdleBorderThickness = 1
        Me.BunifuThinButton23.IdleCornerRadius = 20
        Me.BunifuThinButton23.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BunifuThinButton23.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BunifuThinButton23.Location = New System.Drawing.Point(118, 164)
        Me.BunifuThinButton23.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton23.Name = "BunifuThinButton23"
        Me.BunifuThinButton23.Size = New System.Drawing.Size(110, 42)
        Me.BunifuThinButton23.TabIndex = 685
        Me.BunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInfoVenta
        '
        Me.txtInfoVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtInfoVenta.BeforeTouchSize = New System.Drawing.Size(278, 22)
        Me.txtInfoVenta.BorderColor = System.Drawing.Color.Silver
        Me.txtInfoVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInfoVenta.CornerRadius = 4
        Me.txtInfoVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInfoVenta.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtInfoVenta.Location = New System.Drawing.Point(32, 59)
        Me.txtInfoVenta.MaxLength = 20
        Me.txtInfoVenta.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtInfoVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtInfoVenta.Name = "txtInfoVenta"
        Me.txtInfoVenta.ReadOnly = True
        Me.txtInfoVenta.Size = New System.Drawing.Size(278, 22)
        Me.txtInfoVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtInfoVenta.TabIndex = 686
        '
        'txtFechaConfirma
        '
        Me.txtFechaConfirma.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtFechaConfirma.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaConfirma.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaConfirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaConfirma.Calendar.AllowMultipleSelection = False
        Me.txtFechaConfirma.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaConfirma.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaConfirma.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaConfirma.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaConfirma.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaConfirma.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaConfirma.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaConfirma.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaConfirma.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaConfirma.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaConfirma.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaConfirma.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaConfirma.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaConfirma.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaConfirma.Calendar.Name = "monthCalendar"
        Me.txtFechaConfirma.Calendar.Office2007Theme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.txtFechaConfirma.Calendar.Office2010Theme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.txtFechaConfirma.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaConfirma.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaConfirma.Calendar.Size = New System.Drawing.Size(185, 174)
        Me.txtFechaConfirma.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.VS2010
        Me.txtFechaConfirma.Calendar.TabIndex = 0
        Me.txtFechaConfirma.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaConfirma.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtFechaConfirma.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaConfirma.Calendar.NoneButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaConfirma.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaConfirma.Calendar.NoneButton.Location = New System.Drawing.Point(113, 0)
        Me.txtFechaConfirma.Calendar.NoneButton.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.txtFechaConfirma.Calendar.NoneButton.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.txtFechaConfirma.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaConfirma.Calendar.NoneButton.Text = "None"
        Me.txtFechaConfirma.Calendar.NoneButton.UseVisualStyle = False
        '
        '
        '
        Me.txtFechaConfirma.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtFechaConfirma.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaConfirma.Calendar.TodayButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaConfirma.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaConfirma.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaConfirma.Calendar.TodayButton.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.txtFechaConfirma.Calendar.TodayButton.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.txtFechaConfirma.Calendar.TodayButton.Size = New System.Drawing.Size(113, 20)
        Me.txtFechaConfirma.Calendar.TodayButton.Text = "Today"
        Me.txtFechaConfirma.Calendar.TodayButton.UseVisualStyle = False
        Me.txtFechaConfirma.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaConfirma.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaConfirma.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaConfirma.Checked = False
        Me.txtFechaConfirma.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaConfirma.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaConfirma.DropDownImage = Nothing
        Me.txtFechaConfirma.DropDownNormalColor = System.Drawing.SystemColors.Control
        Me.txtFechaConfirma.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaConfirma.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaConfirma.Font = New System.Drawing.Font("Microsoft Tai Le", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaConfirma.ForeColor = System.Drawing.Color.White
        Me.txtFechaConfirma.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaConfirma.Location = New System.Drawing.Point(32, 118)
        Me.txtFechaConfirma.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaConfirma.MinValue = New Date(CType(0, Long))
        Me.txtFechaConfirma.Name = "txtFechaConfirma"
        Me.txtFechaConfirma.Office2007Theme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.txtFechaConfirma.Office2010Theme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.txtFechaConfirma.ShowCheckBox = False
        Me.txtFechaConfirma.Size = New System.Drawing.Size(278, 26)
        Me.txtFechaConfirma.Style = Syncfusion.Windows.Forms.VisualStyle.VS2010
        Me.txtFechaConfirma.TabIndex = 687
        Me.txtFechaConfirma.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'FormAnularVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(351, 214)
        Me.Controls.Add(Me.txtFechaConfirma)
        Me.Controls.Add(Me.txtInfoVenta)
        Me.Controls.Add(Me.BunifuThinButton23)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAnularVenta"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Anular venta"
        CType(Me.txtInfoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaConfirma.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaConfirma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BunifuThinButton23 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents txtInfoVenta As Tools.TextBoxExt
    Friend WithEvents txtFechaConfirma As Tools.DateTimePickerAdv
End Class

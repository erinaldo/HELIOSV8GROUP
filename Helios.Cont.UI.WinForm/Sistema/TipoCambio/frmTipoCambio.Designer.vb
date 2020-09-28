<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTipoCambio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTipoCambio))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFechaIgv = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudTipoCambioCompra = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.nudTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtCambio = New System.Windows.Forms.TextBox()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        CType(Me.txtFechaIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaIgv.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTipoCambioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'txtFechaIgv
        '
        Me.txtFechaIgv.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaIgv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaIgv.Calendar.AllowMultipleSelection = False
        Me.txtFechaIgv.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaIgv.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaIgv.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaIgv.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaIgv.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaIgv.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaIgv.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIgv.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaIgv.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaIgv.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaIgv.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaIgv.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaIgv.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaIgv.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaIgv.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.Calendar.Name = "monthCalendar"
        Me.txtFechaIgv.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaIgv.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaIgv.Calendar.Size = New System.Drawing.Size(153, 174)
        Me.txtFechaIgv.Calendar.SizeToFit = True
        Me.txtFechaIgv.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaIgv.Calendar.TabIndex = 0
        Me.txtFechaIgv.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaIgv.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaIgv.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaIgv.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaIgv.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaIgv.Calendar.NoneButton.Location = New System.Drawing.Point(81, 0)
        Me.txtFechaIgv.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaIgv.Calendar.NoneButton.Text = "None"
        Me.txtFechaIgv.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaIgv.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaIgv.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaIgv.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaIgv.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaIgv.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaIgv.Calendar.TodayButton.Size = New System.Drawing.Size(81, 20)
        Me.txtFechaIgv.Calendar.TodayButton.Text = "Today"
        Me.txtFechaIgv.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaIgv.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIgv.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaIgv.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaIgv.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaIgv.DropDownImage = Nothing
        Me.txtFechaIgv.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaIgv.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaIgv.Location = New System.Drawing.Point(15, 70)
        Me.txtFechaIgv.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.MinValue = New Date(CType(0, Long))
        Me.txtFechaIgv.Name = "txtFechaIgv"
        Me.txtFechaIgv.ShowCheckBox = False
        Me.txtFechaIgv.Size = New System.Drawing.Size(157, 20)
        Me.txtFechaIgv.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaIgv.TabIndex = 407
        Me.txtFechaIgv.Value = New Date(2015, 9, 9, 21, 37, 56, 824)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 408
        Me.Label2.Text = "Compra:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(171, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 409
        Me.Label3.Text = "Venta:"
        '
        'nudTipoCambioCompra
        '
        Me.nudTipoCambioCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.nudTipoCambioCompra.BeforeTouchSize = New System.Drawing.Size(90, 22)
        Me.nudTipoCambioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.nudTipoCambioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTipoCambioCompra.DecimalPlaces = 3
        Me.nudTipoCambioCompra.Location = New System.Drawing.Point(15, 125)
        Me.nudTipoCambioCompra.Maximum = New Decimal(New Integer() {-469762048, -590869294, 5421010, 0})
        Me.nudTipoCambioCompra.MetroColor = System.Drawing.Color.White
        Me.nudTipoCambioCompra.Name = "nudTipoCambioCompra"
        Me.nudTipoCambioCompra.Size = New System.Drawing.Size(90, 22)
        Me.nudTipoCambioCompra.TabIndex = 411
        Me.nudTipoCambioCompra.ThousandsSeparator = True
        Me.nudTipoCambioCompra.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudTipoCambioCompra.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2010
        '
        'nudTipoCambio
        '
        Me.nudTipoCambio.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.nudTipoCambio.BeforeTouchSize = New System.Drawing.Size(90, 22)
        Me.nudTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.nudTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTipoCambio.DecimalPlaces = 3
        Me.nudTipoCambio.Location = New System.Drawing.Point(174, 125)
        Me.nudTipoCambio.Maximum = New Decimal(New Integer() {-469762048, -590869294, 5421010, 0})
        Me.nudTipoCambio.MetroColor = System.Drawing.Color.White
        Me.nudTipoCambio.Name = "nudTipoCambio"
        Me.nudTipoCambio.Size = New System.Drawing.Size(90, 22)
        Me.nudTipoCambio.TabIndex = 410
        Me.nudTipoCambio.ThousandsSeparator = True
        Me.nudTipoCambio.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2010
        '
        'txtCambio
        '
        Me.txtCambio.Location = New System.Drawing.Point(252, 28)
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.Size = New System.Drawing.Size(56, 22)
        Me.txtCambio.TabIndex = 418
        Me.txtCambio.Visible = False
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.SaveToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(60, 22)
        Me.SaveToolStripButton.Text = "&Grabar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.toolStripSeparator})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(338, 25)
        Me.ToolStrip3.TabIndex = 417
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'frmTipoCambio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.DarkRed
        Me.CaptionBarColor = System.Drawing.Color.DarkRed
        Me.CaptionBarHeight = 55
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 9)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(55, 13)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(250, 24)
        CaptionLabel1.Text = "Administrar tipo de cambio"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(338, 159)
        Me.Controls.Add(Me.txtCambio)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.nudTipoCambioCompra)
        Me.Controls.Add(Me.nudTipoCambio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFechaIgv)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTipoCambio"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtFechaIgv.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaIgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTipoCambioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFechaIgv As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudTipoCambioCompra As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents nudTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtCambio As System.Windows.Forms.TextBox
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
End Class

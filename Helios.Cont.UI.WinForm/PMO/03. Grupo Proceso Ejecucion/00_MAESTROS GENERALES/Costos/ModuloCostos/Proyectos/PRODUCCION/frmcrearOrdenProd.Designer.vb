<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcrearOrdenProd
    Inherits frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcrearOrdenProd))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtCantidadProducida = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtActividadActual = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtGlosa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtPU = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.txtCantidadProducida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActividadActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGlosa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(111, 40)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(121, 281)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(111, 40)
        Me.ButtonAdv1.TabIndex = 505
        Me.ButtonAdv1.Text = "Grabar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'txtCantidadProducida
        '
        Me.txtCantidadProducida.BackGroundColor = System.Drawing.Color.White
        Me.txtCantidadProducida.BeforeTouchSize = New System.Drawing.Size(98, 22)
        Me.txtCantidadProducida.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.txtCantidadProducida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadProducida.CurrencyDecimalDigits = 3
        Me.txtCantidadProducida.CurrencySymbol = ""
        Me.txtCantidadProducida.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCantidadProducida.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtCantidadProducida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCantidadProducida.Location = New System.Drawing.Point(127, 228)
        Me.txtCantidadProducida.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCantidadProducida.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCantidadProducida.Name = "txtCantidadProducida"
        Me.txtCantidadProducida.NullString = ""
        Me.txtCantidadProducida.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCantidadProducida.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtCantidadProducida.Size = New System.Drawing.Size(98, 22)
        Me.txtCantidadProducida.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCantidadProducida.TabIndex = 501
        Me.txtCantidadProducida.Text = "0,000 "
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(98, 22)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBoxExt1.Location = New System.Drawing.Point(21, 228)
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.Silver
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.ReadOnly = True
        Me.TextBoxExt1.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBoxExt1.TabIndex = 500
        '
        'txtActividadActual
        '
        Me.txtActividadActual.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtActividadActual.BeforeTouchSize = New System.Drawing.Size(98, 22)
        Me.txtActividadActual.BorderColor = System.Drawing.Color.Silver
        Me.txtActividadActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActividadActual.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtActividadActual.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtActividadActual.Location = New System.Drawing.Point(21, 45)
        Me.txtActividadActual.Metrocolor = System.Drawing.Color.Silver
        Me.txtActividadActual.Name = "txtActividadActual"
        Me.txtActividadActual.ReadOnly = True
        Me.txtActividadActual.Size = New System.Drawing.Size(313, 22)
        Me.txtActividadActual.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtActividadActual.TabIndex = 498
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(124, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cantidad producida"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 205)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cantidad disponible"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Producto Terminado"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(351, 10)
        Me.GradientPanel1.TabIndex = 506
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 14)
        Me.Label4.TabIndex = 507
        Me.Label4.Text = "Fecha de entrega"
        '
        'txtInicio
        '
        Me.txtInicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtInicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtInicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtInicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtInicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.Iso8601CalenderFormat = False
        Me.txtInicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtInicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.Calendar.Name = "monthCalendar"
        Me.txtInicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtInicio.Calendar.SelectedDates = New Date(-1) {}
        Me.txtInicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtInicio.Calendar.TabIndex = 0
        Me.txtInicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtInicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtInicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtInicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.NoneButton.IsBackStageButton = False
        Me.txtInicio.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtInicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtInicio.Calendar.NoneButton.Text = "None"
        Me.txtInicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtInicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtInicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtInicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.TodayButton.IsBackStageButton = False
        Me.txtInicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtInicio.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtInicio.Calendar.TodayButton.Text = "Today"
        Me.txtInicio.Calendar.TodayButton.UseVisualStyle = True
        Me.txtInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInicio.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtInicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtInicio.Checked = False
        Me.txtInicio.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtInicio.CustomFormat = "dd/MM/yyyy"
        Me.txtInicio.DropDownImage = Nothing
        Me.txtInicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtInicio.Location = New System.Drawing.Point(20, 98)
        Me.txtInicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.MinValue = New Date(CType(0, Long))
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.ShowCheckBox = False
        Me.txtInicio.ShowDropButton = False
        Me.txtInicio.Size = New System.Drawing.Size(101, 20)
        Me.txtInicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtInicio.TabIndex = 546
        Me.txtInicio.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 14)
        Me.Label5.TabIndex = 547
        Me.Label5.Text = "Detalle (información extra)"
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.White
        Me.txtGlosa.BeforeTouchSize = New System.Drawing.Size(98, 22)
        Me.txtGlosa.BorderColor = System.Drawing.Color.DarkGray
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlosa.Location = New System.Drawing.Point(21, 150)
        Me.txtGlosa.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGlosa.Size = New System.Drawing.Size(313, 44)
        Me.txtGlosa.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtGlosa.TabIndex = 548
        '
        'txtPU
        '
        Me.txtPU.BackGroundColor = System.Drawing.Color.White
        Me.txtPU.BeforeTouchSize = New System.Drawing.Size(98, 22)
        Me.txtPU.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.txtPU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPU.CurrencyDecimalDigits = 3
        Me.txtPU.CurrencySymbol = ""
        Me.txtPU.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPU.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtPU.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPU.Location = New System.Drawing.Point(236, 228)
        Me.txtPU.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtPU.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtPU.Name = "txtPU"
        Me.txtPU.NullString = ""
        Me.txtPU.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPU.ReadOnly = True
        Me.txtPU.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPU.Size = New System.Drawing.Size(98, 22)
        Me.txtPU.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtPU.TabIndex = 550
        Me.txtPU.Text = "0,000 "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(233, 205)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 14)
        Me.Label6.TabIndex = 549
        Me.Label6.Text = "Precio Unitario"
        '
        'frmcrearOrdenProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Entrega de recursos"
        CaptionLabel2.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.ForestGreen
        CaptionLabel2.Location = New System.Drawing.Point(55, 25)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Producción"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(351, 325)
        Me.Controls.Add(Me.txtPU)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtGlosa)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtInicio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.txtCantidadProducida)
        Me.Controls.Add(Me.TextBoxExt1)
        Me.Controls.Add(Me.txtActividadActual)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcrearOrdenProd"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtCantidadProducida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActividadActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGlosa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtActividadActual As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCantidadProducida As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtPU As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label6 As Label
End Class

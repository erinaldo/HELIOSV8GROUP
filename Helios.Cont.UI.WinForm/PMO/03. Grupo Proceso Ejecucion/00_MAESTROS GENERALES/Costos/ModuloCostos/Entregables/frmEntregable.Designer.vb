<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntregable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntregable))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEntregable = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtDetalle = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboRecurso = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboUM = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCantidad = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFechaEntrega = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtDetalleItem = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        CType(Me.txtEntregable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRecurso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaEntrega.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDetalleItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(276, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Titulo del Entregable"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Detalle (opcional)"
        '
        'txtEntregable
        '
        Me.txtEntregable.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.txtEntregable.BeforeTouchSize = New System.Drawing.Size(46, 22)
        Me.txtEntregable.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtEntregable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntregable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntregable.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEntregable.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtEntregable.Location = New System.Drawing.Point(279, 38)
        Me.txtEntregable.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtEntregable.Name = "txtEntregable"
        Me.txtEntregable.Size = New System.Drawing.Size(46, 22)
        Me.txtEntregable.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtEntregable.TabIndex = 4
        Me.txtEntregable.Visible = False
        '
        'txtDetalle
        '
        Me.txtDetalle.BeforeTouchSize = New System.Drawing.Size(46, 22)
        Me.txtDetalle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetalle.Location = New System.Drawing.Point(33, 196)
        Me.txtDetalle.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDetalle.Multiline = True
        Me.txtDetalle.Name = "txtDetalle"
        Me.txtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetalle.Size = New System.Drawing.Size(292, 60)
        Me.txtDetalle.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtDetalle.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tipo Recurso"
        '
        'cboRecurso
        '
        Me.cboRecurso.BackColor = System.Drawing.Color.White
        Me.cboRecurso.BeforeTouchSize = New System.Drawing.Size(292, 21)
        Me.cboRecurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecurso.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRecurso.Location = New System.Drawing.Point(33, 39)
        Me.cboRecurso.Name = "cboRecurso"
        Me.cboRecurso.Size = New System.Drawing.Size(292, 21)
        Me.cboRecurso.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboRecurso.TabIndex = 7
        '
        'cboUM
        '
        Me.cboUM.BackColor = System.Drawing.Color.White
        Me.cboUM.BeforeTouchSize = New System.Drawing.Size(202, 21)
        Me.cboUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUM.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUM.Location = New System.Drawing.Point(123, 146)
        Me.cboUM.Name = "cboUM"
        Me.cboUM.Size = New System.Drawing.Size(202, 21)
        Me.cboUM.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboUM.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(120, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Unidad Medida"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCantidad.BeforeTouchSize = New System.Drawing.Size(46, 22)
        Me.txtCantidad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCantidad.DoubleValue = 1.0R
        Me.txtCantidad.ForeColor = System.Drawing.Color.White
        Me.txtCantidad.Location = New System.Drawing.Point(33, 145)
        Me.txtCantidad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.NullString = ""
        Me.txtCantidad.PositiveColor = System.Drawing.Color.White
        Me.txtCantidad.Size = New System.Drawing.Size(84, 22)
        Me.txtCantidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCantidad.TabIndex = 11
        Me.txtCantidad.Text = "1.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 265)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha estimada de entrega"
        '
        'txtFechaEntrega
        '
        Me.txtFechaEntrega.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaEntrega.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaEntrega.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaEntrega.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaEntrega.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaEntrega.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaEntrega.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaEntrega.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaEntrega.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaEntrega.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaEntrega.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaEntrega.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaEntrega.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaEntrega.Calendar.Name = "monthCalendar"
        Me.txtFechaEntrega.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaEntrega.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaEntrega.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaEntrega.Calendar.TabIndex = 0
        Me.txtFechaEntrega.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaEntrega.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaEntrega.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaEntrega.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaEntrega.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaEntrega.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaEntrega.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtFechaEntrega.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaEntrega.Calendar.NoneButton.Text = "None"
        Me.txtFechaEntrega.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaEntrega.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaEntrega.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaEntrega.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaEntrega.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaEntrega.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaEntrega.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaEntrega.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtFechaEntrega.Calendar.TodayButton.Text = "Today"
        Me.txtFechaEntrega.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaEntrega.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaEntrega.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaEntrega.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaEntrega.DropDownImage = Nothing
        Me.txtFechaEntrega.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaEntrega.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaEntrega.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaEntrega.Location = New System.Drawing.Point(33, 287)
        Me.txtFechaEntrega.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaEntrega.MinValue = New Date(CType(0, Long))
        Me.txtFechaEntrega.Name = "txtFechaEntrega"
        Me.txtFechaEntrega.ShowCheckBox = False
        Me.txtFechaEntrega.Size = New System.Drawing.Size(232, 20)
        Me.txtFechaEntrega.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaEntrega.TabIndex = 13
        Me.txtFechaEntrega.Value = New Date(2017, 1, 20, 11, 44, 16, 271)
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(115, 37)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(136, 320)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(115, 37)
        Me.ButtonAdv1.TabIndex = 14
        Me.ButtonAdv1.Text = "Guardar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'txtDetalleItem
        '
        Me.txtDetalleItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.txtDetalleItem.BeforeTouchSize = New System.Drawing.Size(46, 22)
        Me.txtDetalleItem.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDetalleItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetalleItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDetalleItem.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetalleItem.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtDetalleItem.Location = New System.Drawing.Point(33, 89)
        Me.txtDetalleItem.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDetalleItem.Name = "txtDetalleItem"
        Me.txtDetalleItem.ReadOnly = True
        Me.txtDetalleItem.Size = New System.Drawing.Size(292, 22)
        Me.txtDetalleItem.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtDetalleItem.TabIndex = 16
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(30, 70)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(80, 13)
        Me.LinkLabel1.TabIndex = 17
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Ref. existencia"
        '
        'frmEntregable
        '
        Me.AcceptButton = Me.ButtonAdv1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.CaptionBarHeight = 55
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.HotTrack
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(20, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel1.Location = New System.Drawing.Point(55, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(180, 24)
        CaptionLabel1.Text = "Administrar Entregables"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(362, 361)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.txtDetalleItem)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.txtFechaEntrega)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboUM)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboRecurso)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDetalle)
        Me.Controls.Add(Me.txtEntregable)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEntregable"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtEntregable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRecurso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaEntrega.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDetalleItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEntregable As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtDetalle As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboRecurso As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboUM As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEntrega As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtDetalleItem As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class

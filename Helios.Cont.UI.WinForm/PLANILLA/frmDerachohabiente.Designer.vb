<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDerachohabiente
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
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDerachohabiente))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombres = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboSexo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtFechaNac = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboVinculo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBoxAdv1 = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.txtNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSexo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaNac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaNac.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVinculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckBoxAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(39, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 14)
        Me.Label3.TabIndex = 511
        Me.Label3.Text = "Información General"
        '
        'txtNombres
        '
        Me.txtNombres.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Ingrese Nombres"
        Me.BannerTextProvider1.SetBannerText(Me.txtNombres, BannerTextInfo1)
        Me.txtNombres.BeforeTouchSize = New System.Drawing.Size(322, 22)
        Me.txtNombres.BorderColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombres.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNombres.Location = New System.Drawing.Point(42, 46)
        Me.txtNombres.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombres.Size = New System.Drawing.Size(322, 22)
        Me.txtNombres.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNombres.TabIndex = 509
        Me.txtNombres.WordWrap = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(201, 79)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 13)
        Me.Label22.TabIndex = 539
        Me.Label22.Text = "Fec. Nacimiento"
        '
        'cboSexo
        '
        Me.cboSexo.BackColor = System.Drawing.Color.White
        Me.cboSexo.BeforeTouchSize = New System.Drawing.Size(154, 21)
        Me.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSexo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSexo.Location = New System.Drawing.Point(40, 100)
        Me.cboSexo.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboSexo.Name = "cboSexo"
        Me.cboSexo.Size = New System.Drawing.Size(154, 21)
        Me.cboSexo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboSexo.TabIndex = 538
        '
        'txtFechaNac
        '
        Me.txtFechaNac.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtFechaNac.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaNac.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaNac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaNac.Calendar.AllowMultipleSelection = False
        Me.txtFechaNac.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaNac.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaNac.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaNac.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaNac.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaNac.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaNac.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaNac.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaNac.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaNac.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaNac.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaNac.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaNac.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaNac.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaNac.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaNac.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaNac.Calendar.Name = "monthCalendar"
        Me.txtFechaNac.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaNac.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaNac.Calendar.Size = New System.Drawing.Size(103, 174)
        Me.txtFechaNac.Calendar.SizeToFit = True
        Me.txtFechaNac.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaNac.Calendar.TabIndex = 0
        Me.txtFechaNac.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaNac.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaNac.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaNac.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaNac.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaNac.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaNac.Calendar.NoneButton.Location = New System.Drawing.Point(31, 0)
        Me.txtFechaNac.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaNac.Calendar.NoneButton.Text = "None"
        Me.txtFechaNac.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaNac.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaNac.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaNac.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaNac.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaNac.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaNac.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaNac.Calendar.TodayButton.Size = New System.Drawing.Size(31, 20)
        Me.txtFechaNac.Calendar.TodayButton.Text = "Today"
        Me.txtFechaNac.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaNac.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaNac.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaNac.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaNac.Checked = False
        Me.txtFechaNac.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaNac.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaNac.DropDownImage = Nothing
        Me.txtFechaNac.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaNac.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaNac.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaNac.ForeColor = System.Drawing.Color.White
        Me.txtFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaNac.Location = New System.Drawing.Point(200, 100)
        Me.txtFechaNac.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaNac.MinValue = New Date(CType(0, Long))
        Me.txtFechaNac.Name = "txtFechaNac"
        Me.txtFechaNac.ShowCheckBox = False
        Me.txtFechaNac.ShowDropButton = False
        Me.txtFechaNac.Size = New System.Drawing.Size(107, 20)
        Me.txtFechaNac.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaNac.TabIndex = 537
        Me.txtFechaNac.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(39, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 535
        Me.Label2.Text = "Sexo"
        '
        'cboVinculo
        '
        Me.cboVinculo.BackColor = System.Drawing.Color.White
        Me.cboVinculo.BeforeTouchSize = New System.Drawing.Size(154, 21)
        Me.cboVinculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVinculo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVinculo.Location = New System.Drawing.Point(40, 149)
        Me.cboVinculo.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboVinculo.Name = "cboVinculo"
        Me.cboVinculo.Size = New System.Drawing.Size(154, 21)
        Me.cboVinculo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboVinculo.TabIndex = 541
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(39, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 540
        Me.Label1.Text = "Vínculo"
        '
        'CheckBoxAdv1
        '
        Me.CheckBoxAdv1.BeforeTouchSize = New System.Drawing.Size(107, 21)
        Me.CheckBoxAdv1.DrawFocusRectangle = False
        Me.CheckBoxAdv1.Location = New System.Drawing.Point(200, 149)
        Me.CheckBoxAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.CheckBoxAdv1.Name = "CheckBoxAdv1"
        Me.CheckBoxAdv1.Size = New System.Drawing.Size(107, 21)
        Me.CheckBoxAdv1.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.CheckBoxAdv1.TabIndex = 542
        Me.CheckBoxAdv1.Text = "Incapacidad"
        Me.CheckBoxAdv1.ThemesEnabled = True
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(111, 37)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(153, 206)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(111, 37)
        Me.ButtonAdv1.TabIndex = 543
        Me.ButtonAdv1.Text = "Grabar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'frmDerachohabiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        Me.ClientSize = New System.Drawing.Size(400, 251)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.CheckBoxAdv1)
        Me.Controls.Add(Me.cboVinculo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cboSexo)
        Me.Controls.Add(Me.txtFechaNac)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNombres)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDerachohabiente"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSexo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaNac.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaNac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVinculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckBoxAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboSexo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtFechaNac As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboVinculo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxAdv1 As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
End Class

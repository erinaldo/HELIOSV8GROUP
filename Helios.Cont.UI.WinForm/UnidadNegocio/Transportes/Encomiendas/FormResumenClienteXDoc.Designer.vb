<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormResumenClienteXDoc
    Inherits Syncfusion.Windows.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormResumenClienteXDoc))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextFechaDia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNroRemitemte = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRemitente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.CirclePictureBox1 = New Helios.Cont.Presentation.WinForm.CirclePictureBox()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.txtConsignado = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNumeroREmitente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TextFechaDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaDia.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtNroRemitemte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemitente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConsignado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroREmitente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextFechaDia)
        Me.GroupBox1.Location = New System.Drawing.Point(120, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(363, 49)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha de Pedido"
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
        Me.TextFechaDia.Calendar.Size = New System.Drawing.Size(165, 174)
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
        Me.TextFechaDia.Calendar.TodayButton.Size = New System.Drawing.Size(165, 20)
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
        Me.TextFechaDia.Location = New System.Drawing.Point(6, 19)
        Me.TextFechaDia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaDia.MinValue = New Date(CType(0, Long))
        Me.TextFechaDia.Name = "TextFechaDia"
        Me.TextFechaDia.ShowCheckBox = False
        Me.TextFechaDia.Size = New System.Drawing.Size(167, 21)
        Me.TextFechaDia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaDia.TabIndex = 601
        Me.TextFechaDia.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtNroRemitemte)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtRemitente)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(471, 123)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Remitente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 612
        Me.Label2.Text = "Telefono"
        '
        'txtNroRemitemte
        '
        Me.txtNroRemitemte.BackColor = System.Drawing.SystemColors.Info
        Me.txtNroRemitemte.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNroRemitemte.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtNroRemitemte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroRemitemte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroRemitemte.CornerRadius = 3
        Me.txtNroRemitemte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNroRemitemte.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroRemitemte.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtNroRemitemte.Location = New System.Drawing.Point(23, 91)
        Me.txtNroRemitemte.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtNroRemitemte.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNroRemitemte.Name = "txtNroRemitemte"
        Me.txtNroRemitemte.ReadOnly = True
        Me.txtNroRemitemte.Size = New System.Drawing.Size(112, 23)
        Me.txtNroRemitemte.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNroRemitemte.TabIndex = 611
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 606
        Me.Label4.Text = "Nombre o Razón Social"
        '
        'txtRemitente
        '
        Me.txtRemitente.BackColor = System.Drawing.Color.White
        Me.txtRemitente.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtRemitente.BorderColor = System.Drawing.Color.Silver
        Me.txtRemitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemitente.CornerRadius = 3
        Me.txtRemitente.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRemitente.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtRemitente.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemitente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtRemitente.Location = New System.Drawing.Point(23, 43)
        Me.txtRemitente.MaxLength = 70
        Me.txtRemitente.Metrocolor = System.Drawing.Color.Silver
        Me.txtRemitente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRemitente.Name = "txtRemitente"
        Me.txtRemitente.Size = New System.Drawing.Size(322, 22)
        Me.txtRemitente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtRemitente.TabIndex = 605
        '
        'CirclePictureBox1
        '
        Me.CirclePictureBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CirclePictureBox1.Image = CType(resources.GetObject("CirclePictureBox1.Image"), System.Drawing.Image)
        Me.CirclePictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.CirclePictureBox1.Name = "CirclePictureBox1"
        Me.CirclePictureBox1.Size = New System.Drawing.Size(102, 93)
        Me.CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.CirclePictureBox1.TabIndex = 3
        Me.CirclePictureBox1.TabStop = False
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "Cerrar"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton21.Location = New System.Drawing.Point(353, 370)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(130, 40)
        Me.BunifuThinButton21.TabIndex = 620
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtConsignado
        '
        Me.txtConsignado.BackColor = System.Drawing.Color.White
        Me.txtConsignado.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtConsignado.BorderColor = System.Drawing.Color.Silver
        Me.txtConsignado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConsignado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConsignado.CornerRadius = 3
        Me.txtConsignado.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConsignado.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtConsignado.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsignado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtConsignado.Location = New System.Drawing.Point(23, 39)
        Me.txtConsignado.MaxLength = 70
        Me.txtConsignado.Metrocolor = System.Drawing.Color.Silver
        Me.txtConsignado.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtConsignado.Name = "txtConsignado"
        Me.txtConsignado.Size = New System.Drawing.Size(322, 22)
        Me.txtConsignado.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtConsignado.TabIndex = 607
        '
        'txtNumeroREmitente
        '
        Me.txtNumeroREmitente.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumeroREmitente.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNumeroREmitente.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtNumeroREmitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroREmitente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroREmitente.CornerRadius = 3
        Me.txtNumeroREmitente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumeroREmitente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroREmitente.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtNumeroREmitente.Location = New System.Drawing.Point(22, 91)
        Me.txtNumeroREmitente.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtNumeroREmitente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumeroREmitente.Name = "txtNumeroREmitente"
        Me.txtNumeroREmitente.ReadOnly = True
        Me.txtNumeroREmitente.Size = New System.Drawing.Size(112, 23)
        Me.txtNumeroREmitente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNumeroREmitente.TabIndex = 612
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtNumeroREmitente)
        Me.GroupBox3.Controls.Add(Me.txtConsignado)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 245)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(471, 118)
        Me.GroupBox3.TabIndex = 621
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Consignado"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(20, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 615
        Me.Label5.Text = "Telefono"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 613
        Me.Label3.Text = "Nombre o Razón Social"
        '
        'FormResumenClienteXDoc
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
        CaptionLabel1.Text = "Consultar"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(492, 410)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CirclePictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormResumenClienteXDoc"
        Me.ShowIcon = False
        Me.Text = "Resumen Ventas"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.TextFechaDia.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtNroRemitemte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemitente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConsignado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroREmitente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CirclePictureBox1 As CirclePictureBox
    Friend WithEvents TextFechaDia As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents txtConsignado As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRemitente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNumeroREmitente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNroRemitemte As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
End Class

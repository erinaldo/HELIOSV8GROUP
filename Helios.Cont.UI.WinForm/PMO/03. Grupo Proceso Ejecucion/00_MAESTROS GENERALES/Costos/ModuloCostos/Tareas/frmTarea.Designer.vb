﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTarea))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.popupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvPersona = New System.Windows.Forms.ListBox()
        Me.ButtonAdv7 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv8 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtDirector = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtdetalle = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNuevoCosto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtFinaliza = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.popupControlContainer1.SuspendLayout()
        CType(Me.txtDirector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNuevoCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFinaliza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFinaliza.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(609, 10)
        Me.GradientPanel1.TabIndex = 433
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel2.Controls.Add(Me.btOperacion)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 175)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(609, 62)
        Me.GradientPanel2.TabIndex = 496
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.White
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(500, 18)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.TabIndex = 1
        Me.ButtonAdv2.Text = "Cancel"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(385, 18)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 0
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.popupControlContainer1.Controls.Add(Me.lsvPersona)
        Me.popupControlContainer1.Controls.Add(Me.ButtonAdv7)
        Me.popupControlContainer1.Controls.Add(Me.ButtonAdv8)
        Me.popupControlContainer1.Location = New System.Drawing.Point(36, 198)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(279, 147)
        Me.popupControlContainer1.TabIndex = 539
        Me.popupControlContainer1.Visible = False
        '
        'lsvPersona
        '
        Me.lsvPersona.BackColor = System.Drawing.SystemColors.Info
        Me.lsvPersona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvPersona.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvPersona.FormattingEnabled = True
        Me.lsvPersona.Location = New System.Drawing.Point(0, 0)
        Me.lsvPersona.Name = "lsvPersona"
        Me.lsvPersona.Size = New System.Drawing.Size(277, 145)
        Me.lsvPersona.TabIndex = 3
        '
        'ButtonAdv7
        '
        Me.ButtonAdv7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv7.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv7.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv7.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.ButtonAdv7.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv7.IsBackStageButton = False
        Me.ButtonAdv7.Location = New System.Drawing.Point(65, 120)
        Me.ButtonAdv7.Name = "ButtonAdv7"
        Me.ButtonAdv7.Size = New System.Drawing.Size(60, 21)
        Me.ButtonAdv7.TabIndex = 2
        Me.ButtonAdv7.Text = "Cancel"
        Me.ButtonAdv7.UseVisualStyle = True
        '
        'ButtonAdv8
        '
        Me.ButtonAdv8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv8.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv8.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv8.BeforeTouchSize = New System.Drawing.Size(59, 21)
        Me.ButtonAdv8.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv8.IsBackStageButton = False
        Me.ButtonAdv8.Location = New System.Drawing.Point(5, 120)
        Me.ButtonAdv8.Name = "ButtonAdv8"
        Me.ButtonAdv8.Size = New System.Drawing.Size(59, 21)
        Me.ButtonAdv8.TabIndex = 1
        Me.ButtonAdv8.Text = "ButtonAdv8"
        Me.ButtonAdv8.UseVisualStyle = True
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(23, 22)
        Me.ButtonAdv6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(292, 53)
        Me.ButtonAdv6.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(23, 22)
        Me.ButtonAdv6.TabIndex = 538
        Me.ButtonAdv6.Text = "..."
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'txtDirector
        '
        Me.txtDirector.BackColor = System.Drawing.Color.White
        Me.txtDirector.BeforeTouchSize = New System.Drawing.Size(78, 22)
        Me.txtDirector.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDirector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDirector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDirector.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDirector.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDirector.Location = New System.Drawing.Point(19, 53)
        Me.txtDirector.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDirector.Name = "txtDirector"
        Me.txtDirector.NearImage = CType(resources.GetObject("txtDirector.NearImage"), System.Drawing.Image)
        Me.txtDirector.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDirector.Size = New System.Drawing.Size(271, 22)
        Me.txtDirector.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtDirector.TabIndex = 533
        Me.txtDirector.WordWrap = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(16, 30)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 532
        Me.Label19.Text = "Responsable"
        '
        'txtdetalle
        '
        Me.txtdetalle.BackColor = System.Drawing.Color.White
        Me.txtdetalle.BeforeTouchSize = New System.Drawing.Size(78, 22)
        Me.txtdetalle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtdetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdetalle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtdetalle.Location = New System.Drawing.Point(331, 49)
        Me.txtdetalle.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtdetalle.Multiline = True
        Me.txtdetalle.Name = "txtdetalle"
        Me.txtdetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtdetalle.Size = New System.Drawing.Size(269, 83)
        Me.txtdetalle.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtdetalle.TabIndex = 520
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(328, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 529
        Me.Label5.Text = "Descripción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 527
        Me.Label3.Text = "Actividad"
        '
        'txtNuevoCosto
        '
        Me.txtNuevoCosto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNuevoCosto.BeforeTouchSize = New System.Drawing.Size(78, 22)
        Me.txtNuevoCosto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNuevoCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNuevoCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNuevoCosto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNuevoCosto.Location = New System.Drawing.Point(16, 110)
        Me.txtNuevoCosto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNuevoCosto.Name = "txtNuevoCosto"
        Me.txtNuevoCosto.NearImage = CType(resources.GetObject("txtNuevoCosto.NearImage"), System.Drawing.Image)
        Me.txtNuevoCosto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNuevoCosto.Size = New System.Drawing.Size(299, 22)
        Me.txtNuevoCosto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNuevoCosto.TabIndex = 518
        Me.txtNuevoCosto.WordWrap = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(477, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 528
        Me.Label4.Text = "Código"
        Me.Label4.Visible = False
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.DarkRed
        Me.txtCodigo.BeforeTouchSize = New System.Drawing.Size(78, 22)
        Me.txtCodigo.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.CornerRadius = 1
        Me.txtCodigo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(477, 21)
        Me.txtCodigo.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCodigo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(78, 22)
        Me.txtCodigo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCodigo.TabIndex = 519
        Me.txtCodigo.Text = "92PY-001"
        Me.txtCodigo.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(125, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 531
        Me.Label8.Text = "Finaliza"
        Me.Label8.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 530
        Me.Label7.Text = "Inicio"
        Me.Label7.Visible = False
        '
        'txtInicio
        '
        Me.txtInicio.BackColor = System.Drawing.Color.ForestGreen
        Me.txtInicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtInicio.Calendar.AllowMultipleSelection = False
        Me.txtInicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtInicio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtInicio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtInicio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.txtInicio.Calendar.Size = New System.Drawing.Size(84, 174)
        Me.txtInicio.Calendar.SizeToFit = True
        Me.txtInicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtInicio.Calendar.TabIndex = 0
        Me.txtInicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtInicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtInicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtInicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.NoneButton.IsBackStageButton = False
        Me.txtInicio.Calendar.NoneButton.Location = New System.Drawing.Point(12, 0)
        Me.txtInicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtInicio.Calendar.NoneButton.Text = "None"
        Me.txtInicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtInicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtInicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtInicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.TodayButton.IsBackStageButton = False
        Me.txtInicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtInicio.Calendar.TodayButton.Size = New System.Drawing.Size(12, 20)
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
        Me.txtInicio.ForeColor = System.Drawing.Color.White
        Me.txtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtInicio.Location = New System.Drawing.Point(19, 163)
        Me.txtInicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.MinValue = New Date(CType(0, Long))
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.ShowCheckBox = False
        Me.txtInicio.ShowDropButton = False
        Me.txtInicio.Size = New System.Drawing.Size(88, 20)
        Me.txtInicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtInicio.TabIndex = 540
        Me.txtInicio.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        Me.txtInicio.Visible = False
        '
        'txtFinaliza
        '
        Me.txtFinaliza.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.txtFinaliza.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFinaliza.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFinaliza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFinaliza.Calendar.AllowMultipleSelection = False
        Me.txtFinaliza.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFinaliza.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFinaliza.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFinaliza.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFinaliza.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFinaliza.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFinaliza.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFinaliza.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinaliza.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFinaliza.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFinaliza.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFinaliza.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFinaliza.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFinaliza.Calendar.Iso8601CalenderFormat = False
        Me.txtFinaliza.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFinaliza.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFinaliza.Calendar.Name = "monthCalendar"
        Me.txtFinaliza.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFinaliza.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFinaliza.Calendar.Size = New System.Drawing.Size(84, 174)
        Me.txtFinaliza.Calendar.SizeToFit = True
        Me.txtFinaliza.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFinaliza.Calendar.TabIndex = 0
        Me.txtFinaliza.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFinaliza.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFinaliza.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFinaliza.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFinaliza.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFinaliza.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFinaliza.Calendar.NoneButton.Location = New System.Drawing.Point(12, 0)
        Me.txtFinaliza.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFinaliza.Calendar.NoneButton.Text = "None"
        Me.txtFinaliza.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFinaliza.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFinaliza.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFinaliza.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFinaliza.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFinaliza.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFinaliza.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFinaliza.Calendar.TodayButton.Size = New System.Drawing.Size(12, 20)
        Me.txtFinaliza.Calendar.TodayButton.Text = "Today"
        Me.txtFinaliza.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFinaliza.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinaliza.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFinaliza.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFinaliza.Checked = False
        Me.txtFinaliza.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFinaliza.CustomFormat = "dd/MM/yyyy"
        Me.txtFinaliza.DropDownImage = Nothing
        Me.txtFinaliza.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFinaliza.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFinaliza.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFinaliza.ForeColor = System.Drawing.Color.White
        Me.txtFinaliza.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFinaliza.Location = New System.Drawing.Point(128, 163)
        Me.txtFinaliza.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFinaliza.MinValue = New Date(CType(0, Long))
        Me.txtFinaliza.Name = "txtFinaliza"
        Me.txtFinaliza.ShowCheckBox = False
        Me.txtFinaliza.ShowDropButton = False
        Me.txtFinaliza.Size = New System.Drawing.Size(88, 20)
        Me.txtFinaliza.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFinaliza.TabIndex = 541
        Me.txtFinaliza.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        Me.txtFinaliza.Visible = False
        '
        'frmTarea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 12)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(180, 24)
        CaptionLabel1.Text = "Administrar actividades"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(609, 237)
        Me.Controls.Add(Me.txtFinaliza)
        Me.Controls.Add(Me.txtInicio)
        Me.Controls.Add(Me.popupControlContainer1)
        Me.Controls.Add(Me.ButtonAdv6)
        Me.Controls.Add(Me.txtDirector)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtdetalle)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNuevoCosto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTarea"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.popupControlContainer1.ResumeLayout(False)
        CType(Me.txtDirector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNuevoCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFinaliza.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFinaliza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents popupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvPersona As System.Windows.Forms.ListBox
    Private WithEvents ButtonAdv7 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv8 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtDirector As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtdetalle As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNuevoCosto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtFinaliza As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
End Class

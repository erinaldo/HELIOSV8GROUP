<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCTrasportePublico
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCTrasportePublico))
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtDatoTraspor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtdniDatosTras = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.cbFechaGuia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToggleConsultas = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.txtdatosTraspubl = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtrucTraspubl = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtobserTrasPubl = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.dtpfechaEntregaBien = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtplacaTraspo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.txtDatoTraspor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdniDatosTras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.cbFechaGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdatosTraspubl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtrucTraspubl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtobserTrasPubl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpfechaEntregaBien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtplacaTraspo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.txtDatoTraspor)
        Me.GradientPanel4.Controls.Add(Me.Label31)
        Me.GradientPanel4.Controls.Add(Me.Label29)
        Me.GradientPanel4.Controls.Add(Me.txtdniDatosTras)
        Me.GradientPanel4.Controls.Add(Me.Label28)
        Me.GradientPanel4.Controls.Add(Me.Label27)
        Me.GradientPanel4.Location = New System.Drawing.Point(3, 173)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(682, 80)
        Me.GradientPanel4.TabIndex = 785
        '
        'txtDatoTraspor
        '
        Me.txtDatoTraspor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDatoTraspor.BeforeTouchSize = New System.Drawing.Size(131, 23)
        Me.txtDatoTraspor.BorderColor = System.Drawing.Color.Silver
        Me.txtDatoTraspor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDatoTraspor.CornerRadius = 4
        Me.txtDatoTraspor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtDatoTraspor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatoTraspor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDatoTraspor.Location = New System.Drawing.Point(170, 45)
        Me.txtDatoTraspor.MaxLength = 20
        Me.txtDatoTraspor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtDatoTraspor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDatoTraspor.Name = "txtDatoTraspor"
        Me.txtDatoTraspor.Size = New System.Drawing.Size(499, 23)
        Me.txtDatoTraspor.TabIndex = 645
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(179, 28)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(79, 14)
        Me.Label31.TabIndex = 646
        Me.Label31.Text = "RAZÓN SOCIAL"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(190, -16)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(27, 14)
        Me.Label29.TabIndex = 644
        Me.Label29.Text = "RUC"
        '
        'txtdniDatosTras
        '
        Me.txtdniDatosTras.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtdniDatosTras.BeforeTouchSize = New System.Drawing.Size(131, 23)
        Me.txtdniDatosTras.BorderColor = System.Drawing.Color.Silver
        Me.txtdniDatosTras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdniDatosTras.CornerRadius = 4
        Me.txtdniDatosTras.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtdniDatosTras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdniDatosTras.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtdniDatosTras.Location = New System.Drawing.Point(16, 45)
        Me.txtdniDatosTras.MaxLength = 20
        Me.txtdniDatosTras.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtdniDatosTras.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdniDatosTras.Name = "txtdniDatosTras"
        Me.txtdniDatosTras.Size = New System.Drawing.Size(140, 23)
        Me.txtdniDatosTras.TabIndex = 641
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(20, 30)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(69, 14)
        Me.Label28.TabIndex = 642
        Me.Label28.Text = "NRO DE DOC"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label27.Location = New System.Drawing.Point(16, 3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(155, 18)
        Me.Label27.TabIndex = 640
        Me.Label27.Text = "Datos del Trasportista"
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Controls.Add(Me.cbFechaGuia)
        Me.GradientPanel6.Controls.Add(Me.Label7)
        Me.GradientPanel6.Controls.Add(Me.ToggleConsultas)
        Me.GradientPanel6.Controls.Add(Me.txtdatosTraspubl)
        Me.GradientPanel6.Controls.Add(Me.txtrucTraspubl)
        Me.GradientPanel6.Controls.Add(Me.GroupBox1)
        Me.GradientPanel6.Controls.Add(Me.Label3)
        Me.GradientPanel6.Controls.Add(Me.Label2)
        Me.GradientPanel6.Controls.Add(Me.txtobserTrasPubl)
        Me.GradientPanel6.Controls.Add(Me.dtpfechaEntregaBien)
        Me.GradientPanel6.Controls.Add(Me.Label1)
        Me.GradientPanel6.Controls.Add(Me.txtplacaTraspo)
        Me.GradientPanel6.Controls.Add(Me.Label38)
        Me.GradientPanel6.Controls.Add(Me.Label22)
        Me.GradientPanel6.Controls.Add(Me.Label9)
        Me.GradientPanel6.Controls.Add(Me.Label21)
        Me.GradientPanel6.Location = New System.Drawing.Point(3, 3)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(682, 160)
        Me.GradientPanel6.TabIndex = 784
        '
        'cbFechaGuia
        '
        Me.cbFechaGuia.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.cbFechaGuia.BorderColor = System.Drawing.Color.Empty
        Me.cbFechaGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cbFechaGuia.CalendarSize = New System.Drawing.Size(189, 176)
        Me.cbFechaGuia.Checked = False
        Me.cbFechaGuia.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.cbFechaGuia.CustomFormat = "dd/MM/yyyy"
        Me.cbFechaGuia.DropDownImage = Nothing
        Me.cbFechaGuia.DropDownNormalColor = System.Drawing.SystemColors.Control
        Me.cbFechaGuia.DropDownPressedColor = System.Drawing.Color.DimGray
        Me.cbFechaGuia.DropDownSelectedColor = System.Drawing.Color.DimGray
        Me.cbFechaGuia.EnableNullDate = False
        Me.cbFechaGuia.EnableNullKeys = False
        Me.cbFechaGuia.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFechaGuia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.cbFechaGuia.Location = New System.Drawing.Point(538, 31)
        Me.cbFechaGuia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cbFechaGuia.MinValue = New Date(CType(0, Long))
        Me.cbFechaGuia.Name = "cbFechaGuia"
        Me.cbFechaGuia.Office2007Theme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.cbFechaGuia.Office2010Theme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cbFechaGuia.ShowCheckBox = False
        Me.cbFechaGuia.Size = New System.Drawing.Size(131, 21)
        Me.cbFechaGuia.Style = Syncfusion.Windows.Forms.VisualStyle.VS2010
        Me.cbFechaGuia.TabIndex = 844
        Me.cbFechaGuia.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(535, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 14)
        Me.Label7.TabIndex = 843
        Me.Label7.Text = "Fecha inicio del traslado"
        '
        'ToggleConsultas
        '
        Me.ToggleConsultas.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ToggleConsultas.ActiveText = "Web"
        Me.ToggleConsultas.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ToggleConsultas.InActiveColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.ToggleConsultas.InActiveText = "API"
        Me.ToggleConsultas.Location = New System.Drawing.Point(456, 27)
        Me.ToggleConsultas.MaximumSize = New System.Drawing.Size(119, 32)
        Me.ToggleConsultas.MinimumSize = New System.Drawing.Size(75, 23)
        Me.ToggleConsultas.Name = "ToggleConsultas"
        Me.ToggleConsultas.Size = New System.Drawing.Size(76, 23)
        Me.ToggleConsultas.SliderColor = System.Drawing.Color.Black
        Me.ToggleConsultas.SlidingAngle = 8
        Me.ToggleConsultas.TabIndex = 842
        Me.ToggleConsultas.Text = "ToggleButton21"
        Me.ToggleConsultas.TextColor = System.Drawing.Color.White
        Me.ToggleConsultas.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.OFF
        Me.ToggleConsultas.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.Android
        '
        'txtdatosTraspubl
        '
        Me.txtdatosTraspubl.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtdatosTraspubl.BeforeTouchSize = New System.Drawing.Size(131, 23)
        Me.txtdatosTraspubl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtdatosTraspubl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdatosTraspubl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdatosTraspubl.CornerRadius = 3
        Me.txtdatosTraspubl.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtdatosTraspubl.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtdatosTraspubl.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdatosTraspubl.ForeColor = System.Drawing.Color.Black
        Me.txtdatosTraspubl.Location = New System.Drawing.Point(170, 81)
        Me.txtdatosTraspubl.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtdatosTraspubl.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdatosTraspubl.Name = "txtdatosTraspubl"
        Me.txtdatosTraspubl.Size = New System.Drawing.Size(362, 22)
        Me.txtdatosTraspubl.TabIndex = 841
        '
        'txtrucTraspubl
        '
        Me.txtrucTraspubl.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtrucTraspubl.BeforeTouchSize = New System.Drawing.Size(131, 23)
        Me.txtrucTraspubl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtrucTraspubl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtrucTraspubl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrucTraspubl.CornerRadius = 3
        Me.txtrucTraspubl.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtrucTraspubl.FarImage = CType(resources.GetObject("txtrucTraspubl.FarImage"), System.Drawing.Image)
        Me.txtrucTraspubl.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtrucTraspubl.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrucTraspubl.ForeColor = System.Drawing.Color.Black
        Me.txtrucTraspubl.Location = New System.Drawing.Point(16, 82)
        Me.txtrucTraspubl.MaxLength = 11
        Me.txtrucTraspubl.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtrucTraspubl.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtrucTraspubl.Name = "txtrucTraspubl"
        Me.txtrucTraspubl.Size = New System.Drawing.Size(139, 22)
        Me.txtrucTraspubl.TabIndex = 840
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.Location = New System.Drawing.Point(170, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(123, 32)
        Me.GroupBox1.TabIndex = 839
        Me.GroupBox1.TabStop = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(62, 11)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton3.TabIndex = 1
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "No"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(14, 11)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(34, 17)
        Me.RadioButton4.TabIndex = 0
        Me.RadioButton4.Text = "Si"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(13, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 14)
        Me.Label3.TabIndex = 838
        Me.Label3.Text = "¿Es trasbordo programado?"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(178, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 14)
        Me.Label2.TabIndex = 835
        Me.Label2.Text = "Observaciones"
        '
        'txtobserTrasPubl
        '
        Me.txtobserTrasPubl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtobserTrasPubl.BeforeTouchSize = New System.Drawing.Size(131, 23)
        Me.txtobserTrasPubl.BorderColor = System.Drawing.Color.Silver
        Me.txtobserTrasPubl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtobserTrasPubl.CornerRadius = 4
        Me.txtobserTrasPubl.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtobserTrasPubl.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtobserTrasPubl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtobserTrasPubl.Location = New System.Drawing.Point(170, 130)
        Me.txtobserTrasPubl.MaxLength = 180
        Me.txtobserTrasPubl.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtobserTrasPubl.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtobserTrasPubl.Name = "txtobserTrasPubl"
        Me.txtobserTrasPubl.Size = New System.Drawing.Size(499, 23)
        Me.txtobserTrasPubl.TabIndex = 834
        '
        'dtpfechaEntregaBien
        '
        Me.dtpfechaEntregaBien.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.dtpfechaEntregaBien.BorderColor = System.Drawing.Color.Empty
        Me.dtpfechaEntregaBien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpfechaEntregaBien.CalendarSize = New System.Drawing.Size(189, 176)
        Me.dtpfechaEntregaBien.Checked = False
        Me.dtpfechaEntregaBien.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.dtpfechaEntregaBien.CustomFormat = "dd/MM/yyyy"
        Me.dtpfechaEntregaBien.DropDownImage = Nothing
        Me.dtpfechaEntregaBien.DropDownNormalColor = System.Drawing.SystemColors.Control
        Me.dtpfechaEntregaBien.DropDownPressedColor = System.Drawing.Color.DimGray
        Me.dtpfechaEntregaBien.DropDownSelectedColor = System.Drawing.Color.DimGray
        Me.dtpfechaEntregaBien.EnableNullDate = False
        Me.dtpfechaEntregaBien.EnableNullKeys = False
        Me.dtpfechaEntregaBien.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechaEntregaBien.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfechaEntregaBien.Location = New System.Drawing.Point(14, 130)
        Me.dtpfechaEntregaBien.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpfechaEntregaBien.MinValue = New Date(CType(0, Long))
        Me.dtpfechaEntregaBien.Name = "dtpfechaEntregaBien"
        Me.dtpfechaEntregaBien.Office2007Theme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.dtpfechaEntregaBien.Office2010Theme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.dtpfechaEntregaBien.ShowCheckBox = False
        Me.dtpfechaEntregaBien.Size = New System.Drawing.Size(143, 21)
        Me.dtpfechaEntregaBien.Style = Syncfusion.Windows.Forms.VisualStyle.VS2010
        Me.dtpfechaEntregaBien.TabIndex = 833
        Me.dtpfechaEntregaBien.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 14)
        Me.Label1.TabIndex = 680
        Me.Label1.Text = "Fecha de entrega de Bienes"
        '
        'txtplacaTraspo
        '
        Me.txtplacaTraspo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtplacaTraspo.BeforeTouchSize = New System.Drawing.Size(131, 23)
        Me.txtplacaTraspo.BorderColor = System.Drawing.Color.Silver
        Me.txtplacaTraspo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtplacaTraspo.CornerRadius = 4
        Me.txtplacaTraspo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtplacaTraspo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtplacaTraspo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtplacaTraspo.Location = New System.Drawing.Point(538, 80)
        Me.txtplacaTraspo.MaxLength = 20
        Me.txtplacaTraspo.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtplacaTraspo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtplacaTraspo.Name = "txtplacaTraspo"
        Me.txtplacaTraspo.Size = New System.Drawing.Size(131, 23)
        Me.txtplacaTraspo.TabIndex = 678
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(542, 61)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(57, 14)
        Me.Label38.TabIndex = 679
        Me.Label38.Text = "Nro placa "
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(178, 63)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(315, 14)
        Me.Label22.TabIndex = 636
        Me.Label22.Text = "Denominación / Apellidos y nombres de Empresa de trasportes"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(13, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(233, 16)
        Me.Label9.TabIndex = 626
        Me.Label9.Text = "Datos de la Unidad Transporte(Público)"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(23, 65)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(92, 14)
        Me.Label21.TabIndex = 633
        Me.Label21.Text = "RUC. / Traspostes"
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'UCTrasportePublico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GradientPanel4)
        Me.Controls.Add(Me.GradientPanel6)
        Me.Name = "UCTrasportePublico"
        Me.Size = New System.Drawing.Size(704, 262)
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.GradientPanel4.PerformLayout()
        CType(Me.txtDatoTraspor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdniDatosTras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        CType(Me.cbFechaGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdatosTraspubl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtrucTraspubl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtobserTrasPubl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpfechaEntregaBien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtplacaTraspo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel4 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtDatoTraspor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label31 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txtdniDatosTras As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents GradientPanel6 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ToggleConsultas As ToggleButton2
    Friend WithEvents txtdatosTraspubl As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtrucTraspubl As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtobserTrasPubl As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents dtpfechaEntregaBien As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents txtplacaTraspo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label38 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Friend WithEvents cbFechaGuia As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label7 As Label
End Class

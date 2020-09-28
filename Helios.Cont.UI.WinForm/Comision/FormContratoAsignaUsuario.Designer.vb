Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormContratoAsignaUsuario
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboUsuarios = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextProducto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateVigencia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboFormaPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumericValorComisionMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.CheckL = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CheckM = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CheckMI = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CheckJ = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CheckV = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CheckS = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CheckD = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.NumericValorComisionME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.ComboUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateVigencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericValorComisionMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericValorComisionME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(330, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo Usuario"
        '
        'ComboUsuarios
        '
        Me.ComboUsuarios.BackColor = System.Drawing.Color.White
        Me.ComboUsuarios.BeforeTouchSize = New System.Drawing.Size(289, 21)
        Me.ComboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUsuarios.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboUsuarios.Location = New System.Drawing.Point(36, 48)
        Me.ComboUsuarios.Name = "ComboUsuarios"
        Me.ComboUsuarios.Size = New System.Drawing.Size(289, 21)
        Me.ComboUsuarios.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboUsuarios.TabIndex = 6
        '
        'TextProducto
        '
        Me.TextProducto.BeforeTouchSize = New System.Drawing.Size(92, 22)
        Me.TextProducto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProducto.CornerRadius = 4
        Me.TextProducto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextProducto.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProducto.Location = New System.Drawing.Point(333, 48)
        Me.TextProducto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextProducto.MinimumSize = New System.Drawing.Size(12, 8)
        Me.TextProducto.Name = "TextProducto"
        Me.TextProducto.ReadOnly = True
        Me.TextProducto.Size = New System.Drawing.Size(92, 22)
        Me.TextProducto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextProducto.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Válido hasta"
        '
        'DateVigencia
        '
        Me.DateVigencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateVigencia.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.DateVigencia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.DateVigencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DateVigencia.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateVigencia.CalendarSize = New System.Drawing.Size(189, 176)
        Me.DateVigencia.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.DateVigencia.CalendarTitleForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.DateVigencia.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.DateVigencia.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.DateVigencia.DropDownImage = Nothing
        Me.DateVigencia.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateVigencia.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateVigencia.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.DateVigencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateVigencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.DateVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateVigencia.Location = New System.Drawing.Point(36, 103)
        Me.DateVigencia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateVigencia.MinValue = New Date(CType(0, Long))
        Me.DateVigencia.Name = "DateVigencia"
        Me.DateVigencia.ShowCheckBox = False
        Me.DateVigencia.Size = New System.Drawing.Size(232, 20)
        Me.DateVigencia.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        Me.DateVigencia.TabIndex = 13
        Me.DateVigencia.Value = New Date(2020, 1, 2, 13, 55, 13, 331)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Forma entrega pago"
        '
        'ComboFormaPago
        '
        Me.ComboFormaPago.BackColor = System.Drawing.Color.White
        Me.ComboFormaPago.BeforeTouchSize = New System.Drawing.Size(232, 21)
        Me.ComboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFormaPago.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboFormaPago.Items.AddRange(New Object() {"EFECTIVO", "DEPOSITO"})
        Me.ComboFormaPago.Location = New System.Drawing.Point(36, 161)
        Me.ComboFormaPago.Name = "ComboFormaPago"
        Me.ComboFormaPago.Size = New System.Drawing.Size(232, 21)
        Me.ComboFormaPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboFormaPago.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(272, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Moneda"
        '
        'ComboMoneda
        '
        Me.ComboMoneda.BackColor = System.Drawing.Color.White
        Me.ComboMoneda.BeforeTouchSize = New System.Drawing.Size(151, 21)
        Me.ComboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMoneda.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboMoneda.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERA"})
        Me.ComboMoneda.Location = New System.Drawing.Point(275, 161)
        Me.ComboMoneda.Name = "ComboMoneda"
        Me.ComboMoneda.Size = New System.Drawing.Size(151, 21)
        Me.ComboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboMoneda.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Restricción de días"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(271, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Valor comisión MN."
        '
        'NumericValorComisionMN
        '
        Me.NumericValorComisionMN.BeforeTouchSize = New System.Drawing.Size(151, 22)
        Me.NumericValorComisionMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.NumericValorComisionMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericValorComisionMN.DecimalPlaces = 2
        Me.NumericValorComisionMN.Location = New System.Drawing.Point(274, 217)
        Me.NumericValorComisionMN.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.NumericValorComisionMN.Name = "NumericValorComisionMN"
        Me.NumericValorComisionMN.Size = New System.Drawing.Size(151, 22)
        Me.NumericValorComisionMN.TabIndex = 20
        Me.NumericValorComisionMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'CheckL
        '
        Me.CheckL.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckL.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckL.Checked = False
        Me.CheckL.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckL.ForeColor = System.Drawing.Color.White
        Me.CheckL.Location = New System.Drawing.Point(36, 234)
        Me.CheckL.Name = "CheckL"
        Me.CheckL.Size = New System.Drawing.Size(20, 20)
        Me.CheckL.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(39, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "L"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(65, 217)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "M"
        '
        'CheckM
        '
        Me.CheckM.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckM.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckM.Checked = False
        Me.CheckM.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckM.ForeColor = System.Drawing.Color.White
        Me.CheckM.Location = New System.Drawing.Point(62, 234)
        Me.CheckM.Name = "CheckM"
        Me.CheckM.Size = New System.Drawing.Size(20, 20)
        Me.CheckM.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(88, 217)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "MI"
        '
        'CheckMI
        '
        Me.CheckMI.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckMI.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckMI.Checked = False
        Me.CheckMI.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckMI.ForeColor = System.Drawing.Color.White
        Me.CheckMI.Location = New System.Drawing.Point(88, 234)
        Me.CheckMI.Name = "CheckMI"
        Me.CheckMI.Size = New System.Drawing.Size(20, 20)
        Me.CheckMI.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(118, 217)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "J"
        '
        'CheckJ
        '
        Me.CheckJ.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckJ.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckJ.Checked = False
        Me.CheckJ.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckJ.ForeColor = System.Drawing.Color.White
        Me.CheckJ.Location = New System.Drawing.Point(115, 234)
        Me.CheckJ.Name = "CheckJ"
        Me.CheckJ.Size = New System.Drawing.Size(20, 20)
        Me.CheckJ.TabIndex = 27
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(144, 217)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(14, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "V"
        '
        'CheckV
        '
        Me.CheckV.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckV.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckV.Checked = False
        Me.CheckV.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckV.ForeColor = System.Drawing.Color.White
        Me.CheckV.Location = New System.Drawing.Point(141, 234)
        Me.CheckV.Name = "CheckV"
        Me.CheckV.Size = New System.Drawing.Size(20, 20)
        Me.CheckV.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(170, 217)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "S"
        '
        'CheckS
        '
        Me.CheckS.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckS.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckS.Checked = False
        Me.CheckS.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckS.ForeColor = System.Drawing.Color.White
        Me.CheckS.Location = New System.Drawing.Point(167, 234)
        Me.CheckS.Name = "CheckS"
        Me.CheckS.Size = New System.Drawing.Size(20, 20)
        Me.CheckS.TabIndex = 31
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(196, 217)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "D"
        '
        'CheckD
        '
        Me.CheckD.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckD.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckD.Checked = False
        Me.CheckD.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckD.ForeColor = System.Drawing.Color.White
        Me.CheckD.Location = New System.Drawing.Point(193, 234)
        Me.CheckD.Name = "CheckD"
        Me.CheckD.Size = New System.Drawing.Size(20, 20)
        Me.CheckD.TabIndex = 33
        '
        'NumericValorComisionME
        '
        Me.NumericValorComisionME.BeforeTouchSize = New System.Drawing.Size(151, 22)
        Me.NumericValorComisionME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.NumericValorComisionME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericValorComisionME.DecimalPlaces = 2
        Me.NumericValorComisionME.Location = New System.Drawing.Point(275, 262)
        Me.NumericValorComisionME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.NumericValorComisionME.Name = "NumericValorComisionME"
        Me.NumericValorComisionME.Size = New System.Drawing.Size(151, 22)
        Me.NumericValorComisionME.TabIndex = 36
        Me.NumericValorComisionME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(272, 244)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Valor comisión ME."
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(89, 36)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(193, 299)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(89, 36)
        Me.ButtonAdv1.TabIndex = 37
        Me.ButtonAdv1.Text = "Aceptar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'FormContratoAsignaUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 337)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.NumericValorComisionME)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.CheckD)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.CheckS)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CheckV)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CheckJ)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CheckMI)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CheckM)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CheckL)
        Me.Controls.Add(Me.NumericValorComisionMN)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboMoneda)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboFormaPago)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateVigencia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextProducto)
        Me.Controls.Add(Me.ComboUsuarios)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormContratoAsignaUsuario"
        Me.ShowIcon = False
        Me.Text = "Asignar Usuario"
        CType(Me.ComboUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateVigencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericValorComisionMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericValorComisionME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboUsuarios As Tools.ComboBoxAdv
    Friend WithEvents TextProducto As Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents DateVigencia As Tools.DateTimePickerAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboFormaPago As Tools.ComboBoxAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboMoneda As Tools.ComboBoxAdv
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents NumericValorComisionMN As Tools.NumericUpDownExt
    Friend WithEvents CheckL As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents CheckM As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label10 As Label
    Friend WithEvents CheckMI As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label11 As Label
    Friend WithEvents CheckJ As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label12 As Label
    Friend WithEvents CheckV As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label13 As Label
    Friend WithEvents CheckS As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label14 As Label
    Friend WithEvents CheckD As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents NumericValorComisionME As Tools.NumericUpDownExt
    Friend WithEvents Label15 As Label
    Friend WithEvents ButtonAdv1 As ButtonAdv
End Class

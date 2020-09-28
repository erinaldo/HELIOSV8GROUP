Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProgramarRutaFecha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProgramarRutaFecha))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextRuta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBVuelta = New System.Windows.Forms.RadioButton()
        Me.RBIda = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextFechaProgramada = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.TextHora = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboActivosFijos = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtManifiesto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFondoMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtNumeroAsientos = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        CType(Me.TextRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboActivosFijos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtManifiesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFondoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroAsientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 19)
        Me.Label2.TabIndex = 588
        Me.Label2.Text = "Ruta"
        '
        'TextRuta
        '
        Me.TextRuta.BackColor = System.Drawing.Color.White
        Me.TextRuta.BeforeTouchSize = New System.Drawing.Size(431, 26)
        Me.TextRuta.BorderColor = System.Drawing.Color.Silver
        Me.TextRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRuta.CornerRadius = 3
        Me.TextRuta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextRuta.Enabled = False
        Me.TextRuta.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextRuta.Font = New System.Drawing.Font("Calibri Light", 12.0!)
        Me.TextRuta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRuta.Location = New System.Drawing.Point(28, 61)
        Me.TextRuta.MaxLength = 70
        Me.TextRuta.Metrocolor = System.Drawing.Color.Silver
        Me.TextRuta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuta.Multiline = True
        Me.TextRuta.Name = "TextRuta"
        Me.TextRuta.NearImage = CType(resources.GetObject("TextRuta.NearImage"), System.Drawing.Image)
        Me.TextRuta.Size = New System.Drawing.Size(310, 67)
        Me.TextRuta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextRuta.TabIndex = 589
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBVuelta)
        Me.GroupBox1.Controls.Add(Me.RBIda)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(568, 195)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 58)
        Me.GroupBox1.TabIndex = 591
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo"
        Me.GroupBox1.Visible = False
        '
        'RBVuelta
        '
        Me.RBVuelta.AutoSize = True
        Me.RBVuelta.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBVuelta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RBVuelta.Location = New System.Drawing.Point(115, 28)
        Me.RBVuelta.Name = "RBVuelta"
        Me.RBVuelta.Size = New System.Drawing.Size(64, 17)
        Me.RBVuelta.TabIndex = 593
        Me.RBVuelta.TabStop = True
        Me.RBVuelta.Text = "VUELTA"
        Me.RBVuelta.UseVisualStyleBackColor = True
        '
        'RBIda
        '
        Me.RBIda.AutoSize = True
        Me.RBIda.Checked = True
        Me.RBIda.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBIda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RBIda.Location = New System.Drawing.Point(45, 28)
        Me.RBIda.Name = "RBIda"
        Me.RBIda.Size = New System.Drawing.Size(44, 17)
        Me.RBIda.TabIndex = 592
        Me.RBIda.TabStop = True
        Me.RBIda.Text = "IDA"
        Me.RBIda.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 145)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 19)
        Me.Label1.TabIndex = 592
        Me.Label1.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 217)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 19)
        Me.Label3.TabIndex = 593
        Me.Label3.Text = "Hora"
        '
        'TextFechaProgramada
        '
        Me.TextFechaProgramada.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaProgramada.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaProgramada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaProgramada.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaProgramada.Checked = False
        Me.TextFechaProgramada.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaProgramada.CustomFormat = "dd/MM/yyyy"
        Me.TextFechaProgramada.DropDownImage = Nothing
        Me.TextFechaProgramada.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaProgramada.EnableNullDate = False
        Me.TextFechaProgramada.EnableNullKeys = False
        Me.TextFechaProgramada.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.TextFechaProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaProgramada.Location = New System.Drawing.Point(28, 167)
        Me.TextFechaProgramada.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.MinValue = New Date(CType(0, Long))
        Me.TextFechaProgramada.Name = "TextFechaProgramada"
        Me.TextFechaProgramada.ShowCheckBox = False
        Me.TextFechaProgramada.ShowUpDownOnFocus = True
        Me.TextFechaProgramada.Size = New System.Drawing.Size(310, 33)
        Me.TextFechaProgramada.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaProgramada.TabIndex = 601
        Me.TextFechaProgramada.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'TextHora
        '
        Me.TextHora.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextHora.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextHora.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextHora.Checked = False
        Me.TextHora.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextHora.CustomFormat = "HH:mm tt"
        Me.TextHora.DropDownImage = Nothing
        Me.TextHora.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextHora.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextHora.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextHora.EnableNullDate = False
        Me.TextHora.EnableNullKeys = False
        Me.TextHora.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.TextHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextHora.Location = New System.Drawing.Point(28, 241)
        Me.TextHora.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextHora.MinValue = New Date(CType(0, Long))
        Me.TextHora.Name = "TextHora"
        Me.TextHora.ShowCheckBox = False
        Me.TextHora.ShowDropButton = False
        Me.TextHora.ShowUpDown = True
        Me.TextHora.Size = New System.Drawing.Size(166, 41)
        Me.TextHora.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextHora.TabIndex = 602
        Me.TextHora.Value = New Date(2020, 1, 3, 11, 17, 0, 0)
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(176, 32)
        Me.RoundButton21.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(69, 543)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(176, 32)
        Me.RoundButton21.TabIndex = 603
        Me.RoundButton21.Text = "Guardar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 20.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label4.Location = New System.Drawing.Point(3, -3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 33)
        Me.Label4.TabIndex = 604
        Me.Label4.Text = "Crear programación"
        '
        'cboActivosFijos
        '
        Me.cboActivosFijos.BackColor = System.Drawing.Color.White
        Me.cboActivosFijos.BeforeTouchSize = New System.Drawing.Size(243, 38)
        Me.cboActivosFijos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActivosFijos.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.cboActivosFijos.Location = New System.Drawing.Point(28, 327)
        Me.cboActivosFijos.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboActivosFijos.Name = "cboActivosFijos"
        Me.cboActivosFijos.Size = New System.Drawing.Size(243, 38)
        Me.cboActivosFijos.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboActivosFijos.TabIndex = 588
        Me.cboActivosFijos.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 301)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 19)
        Me.Label5.TabIndex = 605
        Me.Label5.Text = "Bus - Placa"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 460)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 19)
        Me.Label6.TabIndex = 606
        Me.Label6.Text = "N° Manifiesto"
        '
        'txtManifiesto
        '
        Me.txtManifiesto.BackColor = System.Drawing.Color.White
        Me.txtManifiesto.BeforeTouchSize = New System.Drawing.Size(306, 31)
        Me.txtManifiesto.BorderColor = System.Drawing.Color.Silver
        Me.txtManifiesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManifiesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtManifiesto.CornerRadius = 3
        Me.txtManifiesto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtManifiesto.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtManifiesto.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.txtManifiesto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtManifiesto.Location = New System.Drawing.Point(32, 491)
        Me.txtManifiesto.MaxLength = 70
        Me.txtManifiesto.Metrocolor = System.Drawing.Color.Silver
        Me.txtManifiesto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtManifiesto.Multiline = True
        Me.txtManifiesto.Name = "txtManifiesto"
        Me.txtManifiesto.Size = New System.Drawing.Size(306, 31)
        Me.txtManifiesto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtManifiesto.TabIndex = 607
        Me.txtManifiesto.Text = "1"
        Me.txtManifiesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 380)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 19)
        Me.Label7.TabIndex = 608
        Me.Label7.Text = "Precio Estimado"
        '
        'txtFondoMN
        '
        Me.txtFondoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFondoMN.BeforeTouchSize = New System.Drawing.Size(310, 32)
        Me.txtFondoMN.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtFondoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondoMN.DecimalPlaces = 2
        Me.txtFondoMN.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.txtFondoMN.ForeColor = System.Drawing.Color.Black
        Me.txtFondoMN.Location = New System.Drawing.Point(28, 411)
        Me.txtFondoMN.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtFondoMN.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtFondoMN.Name = "txtFondoMN"
        Me.txtFondoMN.Size = New System.Drawing.Size(310, 32)
        Me.txtFondoMN.TabIndex = 609
        Me.txtFondoMN.TabStop = False
        Me.txtFondoMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFondoMN.ThousandsSeparator = True
        Me.txtFondoMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtNumeroAsientos
        '
        Me.txtNumeroAsientos.BackColor = System.Drawing.Color.White
        Me.txtNumeroAsientos.BeforeTouchSize = New System.Drawing.Size(306, 31)
        Me.txtNumeroAsientos.BorderColor = System.Drawing.Color.Silver
        Me.txtNumeroAsientos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroAsientos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroAsientos.CornerRadius = 3
        Me.txtNumeroAsientos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtNumeroAsientos.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtNumeroAsientos.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.txtNumeroAsientos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumeroAsientos.Location = New System.Drawing.Point(277, 327)
        Me.txtNumeroAsientos.MaxLength = 70
        Me.txtNumeroAsientos.Metrocolor = System.Drawing.Color.Silver
        Me.txtNumeroAsientos.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumeroAsientos.Multiline = True
        Me.txtNumeroAsientos.Name = "txtNumeroAsientos"
        Me.txtNumeroAsientos.Size = New System.Drawing.Size(61, 38)
        Me.txtNumeroAsientos.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumeroAsientos.TabIndex = 610
        Me.txtNumeroAsientos.Text = "0"
        Me.txtNumeroAsientos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FormProgramarRutaFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(361, 586)
        Me.Controls.Add(Me.txtNumeroAsientos)
        Me.Controls.Add(Me.txtFondoMN)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtManifiesto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboActivosFijos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.TextHora)
        Me.Controls.Add(Me.TextFechaProgramada)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextRuta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProgramarRutaFecha"
        Me.ShowIcon = False
        Me.Text = "Programar Ruta"
        CType(Me.TextRuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboActivosFijos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtManifiesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFondoMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroAsientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents TextRuta As Tools.TextBoxExt
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RBVuelta As RadioButton
    Friend WithEvents RBIda As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextFechaProgramada As Tools.DateTimePickerAdv
    Friend WithEvents TextHora As Tools.DateTimePickerAdv
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents Label4 As Label
    Friend WithEvents cboActivosFijos As Tools.ComboBoxAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtManifiesto As Tools.TextBoxExt
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFondoMN As Tools.NumericUpDownExt
    Friend WithEvents txtNumeroAsientos As Tools.TextBoxExt
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearOrgnizacionNegocio
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboTipoEstab = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextColor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDistrito = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboProvincia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboDepartamento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.RoundButton23 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboSegmento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        CType(Me.ComboTipoEstab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProvincia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSegmento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft JhengHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label6.Location = New System.Drawing.Point(35, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 20)
        Me.Label6.TabIndex = 511
        Me.Label6.Text = "Crear Organización"
        '
        'ComboTipoEstab
        '
        Me.ComboTipoEstab.BackColor = System.Drawing.Color.White
        Me.ComboTipoEstab.BeforeTouchSize = New System.Drawing.Size(245, 24)
        Me.ComboTipoEstab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoEstab.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboTipoEstab.Location = New System.Drawing.Point(39, 144)
        Me.ComboTipoEstab.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboTipoEstab.Name = "ComboTipoEstab"
        Me.ComboTipoEstab.Size = New System.Drawing.Size(245, 24)
        Me.ComboTipoEstab.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboTipoEstab.TabIndex = 523
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(39, 123)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 14)
        Me.Label14.TabIndex = 545
        Me.Label14.Text = "Rubro"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(38, 274)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 19)
        Me.Label1.TabIndex = 546
        Me.Label1.Text = "Descripcion de la organización"
        '
        'TextColor
        '
        Me.TextColor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextColor.BeforeTouchSize = New System.Drawing.Size(606, 47)
        Me.TextColor.BorderColor = System.Drawing.Color.Silver
        Me.TextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextColor.CornerRadius = 4
        Me.TextColor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextColor.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextColor.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextColor.Location = New System.Drawing.Point(41, 324)
        Me.TextColor.Metrocolor = System.Drawing.Color.Silver
        Me.TextColor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextColor.Name = "TextColor"
        Me.TextColor.Size = New System.Drawing.Size(606, 24)
        Me.TextColor.TabIndex = 548
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(42, 305)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 14)
        Me.Label9.TabIndex = 547
        Me.Label9.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(435, 214)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 14)
        Me.Label2.TabIndex = 549
        Me.Label2.Text = "Distrito"
        '
        'cboDistrito
        '
        Me.cboDistrito.BackColor = System.Drawing.Color.White
        Me.cboDistrito.BeforeTouchSize = New System.Drawing.Size(210, 24)
        Me.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrito.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDistrito.Location = New System.Drawing.Point(434, 233)
        Me.cboDistrito.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(210, 24)
        Me.cboDistrito.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboDistrito.TabIndex = 550
        '
        'cboProvincia
        '
        Me.cboProvincia.BackColor = System.Drawing.Color.White
        Me.cboProvincia.BeforeTouchSize = New System.Drawing.Size(188, 24)
        Me.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvincia.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProvincia.Location = New System.Drawing.Point(241, 233)
        Me.cboProvincia.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(188, 24)
        Me.cboProvincia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboProvincia.TabIndex = 552
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(242, 214)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 14)
        Me.Label3.TabIndex = 551
        Me.Label3.Text = "Provincia"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(36, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 554
        Me.Label4.Text = "Fecha creación"
        '
        'txtFecha
        '
        Me.txtFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.Checked = False
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecha.Enabled = False
        Me.txtFecha.EnableNullDate = False
        Me.txtFecha.EnableNullKeys = False
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(40, 88)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(241, 24)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 555
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'RoundButton22
        '
        Me.RoundButton22.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(115, 27)
        Me.RoundButton22.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Sunken
        Me.RoundButton22.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton22.ForeColor = System.Drawing.Color.White
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(411, 443)
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(115, 27)
        Me.RoundButton22.TabIndex = 559
        Me.RoundButton22.Text = "CANCELAR"
        Me.RoundButton22.UseVisualStyle = True
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(112, 28)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(532, 443)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(112, 28)
        Me.RoundButton21.TabIndex = 558
        Me.RoundButton21.Text = "GUARDAR"
        Me.RoundButton21.UseVisualStyle = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(39, 214)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 14)
        Me.Label7.TabIndex = 561
        Me.Label7.Text = "Departamento"
        '
        'cboDepartamento
        '
        Me.cboDepartamento.BackColor = System.Drawing.Color.White
        Me.cboDepartamento.BeforeTouchSize = New System.Drawing.Size(195, 24)
        Me.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartamento.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.Location = New System.Drawing.Point(42, 233)
        Me.cboDepartamento.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.Size = New System.Drawing.Size(195, 24)
        Me.cboDepartamento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboDepartamento.TabIndex = 560
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(38, 186)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 19)
        Me.Label8.TabIndex = 562
        Me.Label8.Text = "Ubigeo"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RoundButton23
        '
        Me.RoundButton23.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton23.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.RoundButton23.BeforeTouchSize = New System.Drawing.Size(63, 27)
        Me.RoundButton23.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Sunken
        Me.RoundButton23.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RoundButton23.ForeColor = System.Drawing.Color.White
        Me.RoundButton23.IsBackStageButton = False
        Me.RoundButton23.Location = New System.Drawing.Point(559, 141)
        Me.RoundButton23.Name = "RoundButton23"
        Me.RoundButton23.Size = New System.Drawing.Size(63, 27)
        Me.RoundButton23.TabIndex = 563
        Me.RoundButton23.Text = "+"
        Me.RoundButton23.UseVisualStyle = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(308, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 14)
        Me.Label10.TabIndex = 565
        Me.Label10.Text = "Ciudad"
        '
        'cboSegmento
        '
        Me.cboSegmento.BackColor = System.Drawing.Color.White
        Me.cboSegmento.BeforeTouchSize = New System.Drawing.Size(245, 24)
        Me.cboSegmento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmento.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSegmento.Location = New System.Drawing.Point(308, 144)
        Me.cboSegmento.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboSegmento.Name = "cboSegmento"
        Me.cboSegmento.Size = New System.Drawing.Size(245, 24)
        Me.cboSegmento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboSegmento.TabIndex = 564
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(42, 361)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 14)
        Me.Label5.TabIndex = 556
        Me.Label5.Text = "Dirección"
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(606, 47)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxExt1.CornerRadius = 4
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBoxExt1.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExt1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBoxExt1.Location = New System.Drawing.Point(41, 380)
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.Silver
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Multiline = True
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.Size = New System.Drawing.Size(606, 47)
        Me.TextBoxExt1.TabIndex = 557
        '
        'FormCrearOrgnizacionNegocio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(689, 485)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboSegmento)
        Me.Controls.Add(Me.RoundButton23)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboDepartamento)
        Me.Controls.Add(Me.RoundButton22)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.TextBoxExt1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboProvincia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboDistrito)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextColor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ComboTipoEstab)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearOrgnizacionNegocio"
        Me.ShowIcon = False
        Me.Text = "Crear Organización"
        CType(Me.ComboTipoEstab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProvincia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSegmento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents ComboTipoEstab As Tools.ComboBoxAdv
    Friend WithEvents Label14 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextColor As Tools.TextBoxExt
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboDistrito As Tools.ComboBoxAdv
    Friend WithEvents cboProvincia As Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFecha As Tools.DateTimePickerAdv
    Friend WithEvents RoundButton22 As RoundButton2
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents Label7 As Label
    Friend WithEvents cboDepartamento As Tools.ComboBoxAdv
    Friend WithEvents Label8 As Label
    Friend WithEvents RoundButton23 As RoundButton2
    Friend WithEvents Label10 As Label
    Friend WithEvents cboSegmento As Tools.ComboBoxAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxExt1 As Tools.TextBoxExt
End Class

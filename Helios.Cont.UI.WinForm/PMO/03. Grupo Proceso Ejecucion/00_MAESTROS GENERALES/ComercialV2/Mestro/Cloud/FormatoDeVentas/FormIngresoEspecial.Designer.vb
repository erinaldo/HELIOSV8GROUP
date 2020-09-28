Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormIngresoEspecial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormIngresoEspecial))
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextDetalle = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextImporte = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonGrabar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.ComboCajas = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.TextDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label17.Image = CType(resources.GetObject("Label17.Image"), System.Drawing.Image)
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label17.Location = New System.Drawing.Point(33, 93)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 64)
        Me.Label17.TabIndex = 548
        Me.Label17.Text = "Ingresos"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(127, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 549
        Me.Label5.Text = "Detalle"
        '
        'TextDetalle
        '
        Me.TextDetalle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextDetalle.BeforeTouchSize = New System.Drawing.Size(284, 23)
        Me.TextDetalle.BorderColor = System.Drawing.Color.Silver
        Me.TextDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDetalle.CornerRadius = 5
        Me.TextDetalle.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextDetalle.FarImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.edit4
        Me.TextDetalle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDetalle.ForeColor = System.Drawing.Color.Black
        Me.TextDetalle.Location = New System.Drawing.Point(130, 112)
        Me.TextDetalle.MaxLength = 100
        Me.TextDetalle.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextDetalle.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDetalle.Name = "TextDetalle"
        Me.TextDetalle.Size = New System.Drawing.Size(284, 23)
        Me.TextDetalle.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextDetalle.TabIndex = 0
        Me.TextDetalle.Text = "VARIOS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(127, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 551
        Me.Label1.Text = "Importe"
        '
        'TextImporte
        '
        Me.TextImporte.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.TextImporte.BeforeTouchSize = New System.Drawing.Size(284, 23)
        Me.TextImporte.BorderColor = System.Drawing.Color.Silver
        Me.TextImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextImporte.CornerRadius = 5
        Me.TextImporte.CurrencySymbol = ""
        Me.TextImporte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextImporte.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextImporte.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextImporte.ForeColor = System.Drawing.Color.Black
        Me.TextImporte.Location = New System.Drawing.Point(130, 163)
        Me.TextImporte.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextImporte.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextImporte.Name = "TextImporte"
        Me.TextImporte.NullString = ""
        Me.TextImporte.PositiveColor = System.Drawing.Color.Black
        Me.TextImporte.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TextImporte.Size = New System.Drawing.Size(284, 22)
        Me.TextImporte.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextImporte.TabIndex = 1
        Me.TextImporte.Text = "0.00"
        Me.TextImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 19)
        Me.Label2.TabIndex = 553
        Me.Label2.Text = "Otros Ingresos de caja"
        '
        'ButtonGrabar
        '
        Me.ButtonGrabar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonGrabar.BorderRadius = 7
        Me.ButtonGrabar.ButtonText = "Guardar"
        Me.ButtonGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonGrabar.DisabledColor = System.Drawing.Color.Gray
        Me.ButtonGrabar.Iconcolor = System.Drawing.Color.Transparent
        Me.ButtonGrabar.Iconimage = CType(resources.GetObject("ButtonGrabar.Iconimage"), System.Drawing.Image)
        Me.ButtonGrabar.Iconimage_right = Nothing
        Me.ButtonGrabar.Iconimage_right_Selected = Nothing
        Me.ButtonGrabar.Iconimage_Selected = Nothing
        Me.ButtonGrabar.IconMarginLeft = 0
        Me.ButtonGrabar.IconMarginRight = 0
        Me.ButtonGrabar.IconRightVisible = True
        Me.ButtonGrabar.IconRightZoom = 0R
        Me.ButtonGrabar.IconVisible = True
        Me.ButtonGrabar.IconZoom = 40.0R
        Me.ButtonGrabar.IsTab = False
        Me.ButtonGrabar.Location = New System.Drawing.Point(293, 199)
        Me.ButtonGrabar.Name = "ButtonGrabar"
        Me.ButtonGrabar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.OnHoverTextColor = System.Drawing.Color.White
        Me.ButtonGrabar.selected = False
        Me.ButtonGrabar.Size = New System.Drawing.Size(121, 40)
        Me.ButtonGrabar.TabIndex = 2
        Me.ButtonGrabar.Text = "Guardar"
        Me.ButtonGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ButtonGrabar.Textcolor = System.Drawing.Color.White
        Me.ButtonGrabar.TextFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(130, 213)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(65, 17)
        Me.CheckBox1.TabIndex = 555
        Me.CheckBox1.Text = "Efectivo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'Line21
        '
        Me.Line21.LineColor = System.Drawing.Color.DarkGray
        Me.Line21.Location = New System.Drawing.Point(105, 52)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(1, 170)
        Me.Line21.TabIndex = 554
        Me.Line21.Text = "Line21"
        '
        'ComboCajas
        '
        Me.ComboCajas.BackColor = System.Drawing.Color.White
        Me.ComboCajas.BeforeTouchSize = New System.Drawing.Size(284, 21)
        Me.ComboCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCajas.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCajas.Location = New System.Drawing.Point(130, 65)
        Me.ComboCajas.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboCajas.Name = "ComboCajas"
        Me.ComboCajas.Size = New System.Drawing.Size(284, 21)
        Me.ComboCajas.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCajas.TabIndex = 556
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(127, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 557
        Me.Label3.Text = "Cuenta financiera"
        '
        'FormIngresoEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 2
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(460, 253)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboCajas)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ButtonGrabar)
        Me.Controls.Add(Me.Line21)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextImporte)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextDetalle)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label17)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormIngresoEspecial"
        Me.ShowIcon = False
        Me.Text = "Ingreso Especial"
        CType(Me.TextDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label17 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextDetalle As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents TextImporte As Tools.CurrencyTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Line21 As Line2
    Friend WithEvents ButtonGrabar As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ComboCajas As Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
End Class

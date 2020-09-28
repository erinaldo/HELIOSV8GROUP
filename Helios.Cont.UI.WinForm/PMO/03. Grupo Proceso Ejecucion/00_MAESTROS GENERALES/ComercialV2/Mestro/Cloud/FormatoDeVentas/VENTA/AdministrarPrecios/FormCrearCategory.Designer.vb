Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearCategory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearCategory))
        Me.ComboCategoria = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textCategory = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextPrecioCompra = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.TextUtilidad1 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextUtilidad2 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        CType(Me.ComboCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPrecioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextUtilidad1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextUtilidad2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboCategoria
        '
        Me.ComboCategoria.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboCategoria.BeforeTouchSize = New System.Drawing.Size(303, 21)
        Me.ComboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCategoria.Items.AddRange(New Object() {"PORCENTAJE", "SIN CONFIGURACION"})
        Me.ComboCategoria.Location = New System.Drawing.Point(23, 92)
        Me.ComboCategoria.Name = "ComboCategoria"
        Me.ComboCategoria.Size = New System.Drawing.Size(303, 21)
        Me.ComboCategoria.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboCategoria.TabIndex = 2
        Me.ComboCategoria.Text = "PORCENTAJE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Categoría"
        '
        'textCategory
        '
        Me.textCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.textCategory.BeforeTouchSize = New System.Drawing.Size(117, 20)
        Me.textCategory.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.textCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textCategory.CornerRadius = 4
        Me.textCategory.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.textCategory.FarImage = CType(resources.GetObject("textCategory.FarImage"), System.Drawing.Image)
        Me.textCategory.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCategory.ForeColor = System.Drawing.Color.White
        Me.textCategory.Location = New System.Drawing.Point(23, 38)
        Me.textCategory.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.textCategory.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textCategory.Name = "textCategory"
        Me.textCategory.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.textCategory.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.textCategory.Size = New System.Drawing.Size(303, 22)
        Me.textCategory.TabIndex = 544
        Me.textCategory.ThemesEnabled = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(20, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 545
        Me.Label2.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(350, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 546
        Me.Label3.Text = "Precio compra"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Orange
        Me.Label4.Location = New System.Drawing.Point(56, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 547
        Me.Label4.Text = "% mínimo utilidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(162, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 13)
        Me.Label5.TabIndex = 548
        Me.Label5.Text = "% utilidad rangos inferiores"
        '
        'TextPrecioCompra
        '
        Me.TextPrecioCompra.BeforeTouchSize = New System.Drawing.Size(117, 20)
        Me.TextPrecioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TextPrecioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPrecioCompra.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextPrecioCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TextPrecioCompra.Location = New System.Drawing.Point(353, 199)
        Me.TextPrecioCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextPrecioCompra.Name = "TextPrecioCompra"
        Me.TextPrecioCompra.NullString = ""
        Me.TextPrecioCompra.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TextPrecioCompra.Size = New System.Drawing.Size(100, 20)
        Me.TextPrecioCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Black
        Me.TextPrecioCompra.TabIndex = 552
        Me.TextPrecioCompra.Text = "S/0.00"
        Me.TextPrecioCompra.Visible = False
        Me.TextPrecioCompra.ZeroColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "ACEPTAR"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(112, 199)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(131, 39)
        Me.BunifuThinButton21.TabIndex = 668
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextUtilidad1
        '
        Me.TextUtilidad1.BeforeTouchSize = New System.Drawing.Size(117, 20)
        Me.TextUtilidad1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TextUtilidad1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextUtilidad1.CurrencySymbol = "%"
        Me.TextUtilidad1.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextUtilidad1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextUtilidad1.ForeColor = System.Drawing.Color.Orange
        Me.TextUtilidad1.Location = New System.Drawing.Point(59, 160)
        Me.TextUtilidad1.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextUtilidad1.Name = "TextUtilidad1"
        Me.TextUtilidad1.NullString = ""
        Me.TextUtilidad1.PositiveColor = System.Drawing.Color.Orange
        Me.TextUtilidad1.Size = New System.Drawing.Size(114, 20)
        Me.TextUtilidad1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Black
        Me.TextUtilidad1.TabIndex = 669
        Me.TextUtilidad1.Text = "%0.00"
        Me.TextUtilidad1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextUtilidad1.ZeroColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        '
        'TextUtilidad2
        '
        Me.TextUtilidad2.BeforeTouchSize = New System.Drawing.Size(117, 20)
        Me.TextUtilidad2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TextUtilidad2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextUtilidad2.CurrencySymbol = "%"
        Me.TextUtilidad2.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextUtilidad2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TextUtilidad2.Location = New System.Drawing.Point(179, 160)
        Me.TextUtilidad2.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextUtilidad2.Name = "TextUtilidad2"
        Me.TextUtilidad2.NullString = ""
        Me.TextUtilidad2.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TextUtilidad2.Size = New System.Drawing.Size(116, 20)
        Me.TextUtilidad2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Black
        Me.TextUtilidad2.TabIndex = 670
        Me.TextUtilidad2.Text = "%0.00"
        Me.TextUtilidad2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextUtilidad2.ZeroColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        '
        'FormCrearCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(347, 257)
        Me.Controls.Add(Me.TextUtilidad2)
        Me.Controls.Add(Me.TextUtilidad1)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.TextPrecioCompra)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.textCategory)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboCategoria)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearCategory"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Crear category"
        CType(Me.ComboCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPrecioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextUtilidad1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextUtilidad2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboCategoria As Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents textCategory As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextPrecioCompra As Tools.CurrencyTextBox
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents TextUtilidad1 As Tools.CurrencyTextBox
    Friend WithEvents TextUtilidad2 As Tools.CurrencyTextBox
End Class

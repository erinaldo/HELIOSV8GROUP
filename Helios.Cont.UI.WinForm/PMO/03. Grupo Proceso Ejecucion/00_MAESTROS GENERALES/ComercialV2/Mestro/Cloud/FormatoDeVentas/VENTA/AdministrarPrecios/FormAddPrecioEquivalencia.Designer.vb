Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddPrecioEquivalencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddPrecioEquivalencia))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextValor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.ComboPrecio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextDetalle = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextRangoFin = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextRangoInicio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextValorCredito = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PanelRango = New System.Windows.Forms.Panel()
        Me.PanelPrecio = New System.Windows.Forms.Panel()
        CType(Me.TextValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRangoFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRangoInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextValorCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelRango.SuspendLayout()
        Me.PanelPrecio.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(28, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Detalle"
        '
        'TextValor
        '
        Me.TextValor.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextValor.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.TextValor.BorderColor = System.Drawing.Color.DimGray
        Me.TextValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValor.CornerRadius = 5
        Me.TextValor.CurrencySymbol = ""
        Me.TextValor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextValor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValor.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValor.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextValor.Location = New System.Drawing.Point(31, 130)
        Me.TextValor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextValor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextValor.Name = "TextValor"
        Me.TextValor.NullString = ""
        Me.TextValor.PositiveColor = System.Drawing.Color.WhiteSmoke
        Me.TextValor.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextValor.Size = New System.Drawing.Size(141, 27)
        Me.TextValor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextValor.TabIndex = 641
        Me.TextValor.Text = "0.00"
        Me.TextValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(28, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 18)
        Me.Label4.TabIndex = 642
        Me.Label4.Text = "Agregar Equivalencia"
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "GUARDAR"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(193, 173)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(129, 40)
        Me.BunifuThinButton21.TabIndex = 667
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboPrecio
        '
        Me.ComboPrecio.AutoComplete = False
        Me.ComboPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ComboPrecio.BeforeTouchSize = New System.Drawing.Size(303, 21)
        Me.ComboPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboPrecio.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboPrecio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboPrecio.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ComboPrecio.Items.AddRange(New Object() {"MENOR", "MAYOR", "GRAN MAYOR", "PREMIUM", "CORPORATIVO", "ESPECIAL", "OTRO"})
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "MENOR"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "MAYOR"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "GRAN MAYOR"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "PREMIUM"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "CORPORATIVO"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "ESPECIAL"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "OTRO"))
        Me.ComboPrecio.Location = New System.Drawing.Point(27, 72)
        Me.ComboPrecio.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboPrecio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboPrecio.Name = "ComboPrecio"
        Me.ComboPrecio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.ComboPrecio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.ComboPrecio.Size = New System.Drawing.Size(303, 21)
        Me.ComboPrecio.Style = Syncfusion.Windows.Forms.VisualStyle.VS2010
        Me.ComboPrecio.TabIndex = 670
        Me.ComboPrecio.Text = "MENOR"
        Me.ComboPrecio.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(28, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 545
        Me.Label2.Text = "Precio al contado"
        '
        'TextDetalle
        '
        Me.TextDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextDetalle.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.TextDetalle.BorderColor = System.Drawing.Color.DimGray
        Me.TextDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDetalle.CornerRadius = 4
        Me.TextDetalle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextDetalle.FarImage = CType(resources.GetObject("TextDetalle.FarImage"), System.Drawing.Image)
        Me.TextDetalle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDetalle.ForeColor = System.Drawing.Color.White
        Me.TextDetalle.Location = New System.Drawing.Point(27, 71)
        Me.TextDetalle.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextDetalle.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDetalle.Name = "TextDetalle"
        Me.TextDetalle.Size = New System.Drawing.Size(303, 22)
        Me.TextDetalle.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextDetalle.TabIndex = 544
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(84, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 674
        Me.Label3.Text = "Rango final"
        Me.Label3.Visible = False
        '
        'TextRangoFin
        '
        Me.TextRangoFin.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextRangoFin.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.TextRangoFin.BorderColor = System.Drawing.Color.DimGray
        Me.TextRangoFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRangoFin.CornerRadius = 5
        Me.TextRangoFin.CurrencyDecimalDigits = 0
        Me.TextRangoFin.CurrencySymbol = ""
        Me.TextRangoFin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRangoFin.DecimalValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextRangoFin.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRangoFin.ForeColor = System.Drawing.Color.White
        Me.TextRangoFin.Location = New System.Drawing.Point(83, 32)
        Me.TextRangoFin.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextRangoFin.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRangoFin.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextRangoFin.Name = "TextRangoFin"
        Me.TextRangoFin.NullString = ""
        Me.TextRangoFin.PositiveColor = System.Drawing.Color.White
        Me.TextRangoFin.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextRangoFin.Size = New System.Drawing.Size(73, 27)
        Me.TextRangoFin.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextRangoFin.TabIndex = 673
        Me.TextRangoFin.Text = "1"
        Me.TextRangoFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextRangoFin.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(3, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 672
        Me.Label5.Text = "Cantidad miníma"
        '
        'TextRangoInicio
        '
        Me.TextRangoInicio.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextRangoInicio.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.TextRangoInicio.BorderColor = System.Drawing.Color.DimGray
        Me.TextRangoInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRangoInicio.CornerRadius = 5
        Me.TextRangoInicio.CurrencyDecimalDigits = 0
        Me.TextRangoInicio.CurrencySymbol = ""
        Me.TextRangoInicio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRangoInicio.DecimalValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextRangoInicio.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRangoInicio.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextRangoInicio.Location = New System.Drawing.Point(4, 32)
        Me.TextRangoInicio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextRangoInicio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRangoInicio.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextRangoInicio.Name = "TextRangoInicio"
        Me.TextRangoInicio.NullString = ""
        Me.TextRangoInicio.PositiveColor = System.Drawing.Color.WhiteSmoke
        Me.TextRangoInicio.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextRangoInicio.Size = New System.Drawing.Size(73, 27)
        Me.TextRangoInicio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextRangoInicio.TabIndex = 671
        Me.TextRangoInicio.Text = "1"
        Me.TextRangoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextValorCredito
        '
        Me.TextValorCredito.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextValorCredito.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.TextValorCredito.BorderColor = System.Drawing.Color.DimGray
        Me.TextValorCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValorCredito.CornerRadius = 5
        Me.TextValorCredito.CurrencySymbol = ""
        Me.TextValorCredito.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextValorCredito.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValorCredito.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValorCredito.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextValorCredito.Location = New System.Drawing.Point(3, 26)
        Me.TextValorCredito.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextValorCredito.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextValorCredito.Name = "TextValorCredito"
        Me.TextValorCredito.NullString = ""
        Me.TextValorCredito.PositiveColor = System.Drawing.Color.WhiteSmoke
        Me.TextValorCredito.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextValorCredito.Size = New System.Drawing.Size(141, 27)
        Me.TextValorCredito.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextValorCredito.TabIndex = 676
        Me.TextValorCredito.Text = "0.00"
        Me.TextValorCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(0, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 675
        Me.Label6.Text = "Precio al credito"
        '
        'PanelRango
        '
        Me.PanelRango.Controls.Add(Me.TextRangoInicio)
        Me.PanelRango.Controls.Add(Me.Label5)
        Me.PanelRango.Controls.Add(Me.TextRangoFin)
        Me.PanelRango.Controls.Add(Me.Label3)
        Me.PanelRango.Location = New System.Drawing.Point(336, 34)
        Me.PanelRango.Name = "PanelRango"
        Me.PanelRango.Size = New System.Drawing.Size(158, 70)
        Me.PanelRango.TabIndex = 677
        Me.PanelRango.Visible = False
        '
        'PanelPrecio
        '
        Me.PanelPrecio.Controls.Add(Me.TextValorCredito)
        Me.PanelPrecio.Controls.Add(Me.Label6)
        Me.PanelPrecio.Location = New System.Drawing.Point(178, 104)
        Me.PanelPrecio.Name = "PanelPrecio"
        Me.PanelPrecio.Size = New System.Drawing.Size(152, 56)
        Me.PanelPrecio.TabIndex = 678
        Me.PanelPrecio.Visible = False
        '
        'FormAddPrecioEquivalencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(506, 216)
        Me.Controls.Add(Me.PanelPrecio)
        Me.Controls.Add(Me.PanelRango)
        Me.Controls.Add(Me.ComboPrecio)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextValor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextDetalle)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAddPrecioEquivalencia"
        Me.ShowIcon = False
        Me.Text = "Precio Equivalencia"
        CType(Me.TextValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRangoFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRangoInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextValorCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelRango.ResumeLayout(False)
        Me.PanelRango.PerformLayout()
        Me.PanelPrecio.ResumeLayout(False)
        Me.PanelPrecio.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextValor As Tools.CurrencyTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents ComboPrecio As Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents TextDetalle As Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents TextRangoFin As Tools.CurrencyTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextRangoInicio As Tools.CurrencyTextBox
    Friend WithEvents TextValorCredito As Tools.CurrencyTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents PanelRango As Panel
    Friend WithEvents PanelPrecio As Panel
End Class

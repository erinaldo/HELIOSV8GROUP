Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddPrecioProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddPrecioProducto))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextRangoInicio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextRangoFin = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextContadoSinIgv = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextContadoConIgv = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextCreditoSinIgv = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextCreditoConIgv = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.ComboPrecio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        CType(Me.TextRangoInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRangoFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextContadoSinIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextContadoConIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCreditoSinIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCreditoConIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(26, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 18)
        Me.Label4.TabIndex = 643
        Me.Label4.Text = "Agregar Precio"
        '
        'TextRangoInicio
        '
        Me.TextRangoInicio.BackGroundColor = System.Drawing.Color.White
        Me.TextRangoInicio.BeforeTouchSize = New System.Drawing.Size(99, 23)
        Me.TextRangoInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextRangoInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRangoInicio.CornerRadius = 5
        Me.TextRangoInicio.CurrencySymbol = ""
        Me.TextRangoInicio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRangoInicio.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextRangoInicio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRangoInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRangoInicio.Location = New System.Drawing.Point(281, 62)
        Me.TextRangoInicio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextRangoInicio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRangoInicio.Name = "TextRangoInicio"
        Me.TextRangoInicio.NullString = ""
        Me.TextRangoInicio.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRangoInicio.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextRangoInicio.Size = New System.Drawing.Size(99, 23)
        Me.TextRangoInicio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextRangoInicio.TabIndex = 644
        Me.TextRangoInicio.Text = "0.00"
        Me.TextRangoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(280, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 645
        Me.Label1.Text = "Rango de inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(389, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 647
        Me.Label2.Text = "Rango final"
        '
        'TextRangoFin
        '
        Me.TextRangoFin.BackGroundColor = System.Drawing.Color.White
        Me.TextRangoFin.BeforeTouchSize = New System.Drawing.Size(99, 23)
        Me.TextRangoFin.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextRangoFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRangoFin.CornerRadius = 5
        Me.TextRangoFin.CurrencySymbol = ""
        Me.TextRangoFin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRangoFin.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextRangoFin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRangoFin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRangoFin.Location = New System.Drawing.Point(390, 62)
        Me.TextRangoFin.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextRangoFin.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRangoFin.Name = "TextRangoFin"
        Me.TextRangoFin.NullString = ""
        Me.TextRangoFin.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRangoFin.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextRangoFin.Size = New System.Drawing.Size(95, 23)
        Me.TextRangoFin.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextRangoFin.TabIndex = 646
        Me.TextRangoFin.Text = "0.00"
        Me.TextRangoFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 648
        Me.Label3.Text = "Tipo precio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(24, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 650
        Me.Label5.Text = "Venta al contado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 194)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 654
        Me.Label6.Text = "Precio sin IGV."
        '
        'TextContadoSinIgv
        '
        Me.TextContadoSinIgv.BackGroundColor = System.Drawing.Color.White
        Me.TextContadoSinIgv.BeforeTouchSize = New System.Drawing.Size(99, 23)
        Me.TextContadoSinIgv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextContadoSinIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextContadoSinIgv.CornerRadius = 5
        Me.TextContadoSinIgv.CurrencySymbol = ""
        Me.TextContadoSinIgv.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextContadoSinIgv.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextContadoSinIgv.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextContadoSinIgv.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextContadoSinIgv.Location = New System.Drawing.Point(27, 211)
        Me.TextContadoSinIgv.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextContadoSinIgv.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextContadoSinIgv.Name = "TextContadoSinIgv"
        Me.TextContadoSinIgv.NullString = ""
        Me.TextContadoSinIgv.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextContadoSinIgv.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextContadoSinIgv.Size = New System.Drawing.Size(112, 23)
        Me.TextContadoSinIgv.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextContadoSinIgv.TabIndex = 653
        Me.TextContadoSinIgv.Text = "0.00"
        Me.TextContadoSinIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 652
        Me.Label7.Text = "Precio con IGV."
        '
        'TextContadoConIgv
        '
        Me.TextContadoConIgv.BackGroundColor = System.Drawing.Color.White
        Me.TextContadoConIgv.BeforeTouchSize = New System.Drawing.Size(99, 23)
        Me.TextContadoConIgv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextContadoConIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextContadoConIgv.CornerRadius = 5
        Me.TextContadoConIgv.CurrencySymbol = ""
        Me.TextContadoConIgv.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextContadoConIgv.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextContadoConIgv.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextContadoConIgv.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextContadoConIgv.Location = New System.Drawing.Point(27, 154)
        Me.TextContadoConIgv.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextContadoConIgv.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextContadoConIgv.Name = "TextContadoConIgv"
        Me.TextContadoConIgv.NullString = ""
        Me.TextContadoConIgv.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextContadoConIgv.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextContadoConIgv.Size = New System.Drawing.Size(112, 23)
        Me.TextContadoConIgv.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextContadoConIgv.TabIndex = 651
        Me.TextContadoConIgv.Text = "0.00"
        Me.TextContadoConIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(158, 194)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 659
        Me.Label8.Text = "Precio sin IGV."
        '
        'TextCreditoSinIgv
        '
        Me.TextCreditoSinIgv.BackGroundColor = System.Drawing.Color.White
        Me.TextCreditoSinIgv.BeforeTouchSize = New System.Drawing.Size(99, 23)
        Me.TextCreditoSinIgv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCreditoSinIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCreditoSinIgv.CornerRadius = 5
        Me.TextCreditoSinIgv.CurrencySymbol = ""
        Me.TextCreditoSinIgv.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCreditoSinIgv.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextCreditoSinIgv.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCreditoSinIgv.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCreditoSinIgv.Location = New System.Drawing.Point(159, 211)
        Me.TextCreditoSinIgv.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCreditoSinIgv.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCreditoSinIgv.Name = "TextCreditoSinIgv"
        Me.TextCreditoSinIgv.NullString = ""
        Me.TextCreditoSinIgv.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCreditoSinIgv.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextCreditoSinIgv.Size = New System.Drawing.Size(112, 23)
        Me.TextCreditoSinIgv.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCreditoSinIgv.TabIndex = 658
        Me.TextCreditoSinIgv.Text = "0.00"
        Me.TextCreditoSinIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(156, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 657
        Me.Label9.Text = "Precio con IGV."
        '
        'TextCreditoConIgv
        '
        Me.TextCreditoConIgv.BackGroundColor = System.Drawing.Color.White
        Me.TextCreditoConIgv.BeforeTouchSize = New System.Drawing.Size(99, 23)
        Me.TextCreditoConIgv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCreditoConIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCreditoConIgv.CornerRadius = 5
        Me.TextCreditoConIgv.CurrencySymbol = ""
        Me.TextCreditoConIgv.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCreditoConIgv.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextCreditoConIgv.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCreditoConIgv.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCreditoConIgv.Location = New System.Drawing.Point(157, 154)
        Me.TextCreditoConIgv.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCreditoConIgv.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCreditoConIgv.Name = "TextCreditoConIgv"
        Me.TextCreditoConIgv.NullString = ""
        Me.TextCreditoConIgv.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCreditoConIgv.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextCreditoConIgv.Size = New System.Drawing.Size(112, 23)
        Me.TextCreditoConIgv.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCreditoConIgv.TabIndex = 656
        Me.TextCreditoConIgv.Text = "0.00"
        Me.TextCreditoConIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(156, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 16)
        Me.Label10.TabIndex = 655
        Me.Label10.Text = "venta al credito"
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "Guardar"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(283, 142)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(108, 40)
        Me.BunifuThinButton21.TabIndex = 668
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboPrecio
        '
        Me.ComboPrecio.BackColor = System.Drawing.Color.White
        Me.ComboPrecio.BeforeTouchSize = New System.Drawing.Size(242, 21)
        Me.ComboPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboPrecio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboPrecio.Items.AddRange(New Object() {"MENOR", "MAYOR", "GRAN MAYOR", "PREMIUM", "CORPORATIVO", "ESPECIAL", "OTRO"})
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "MENOR"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "MAYOR"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "GRAN MAYOR"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "PREMIUM"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "CORPORATIVO"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "ESPECIAL"))
        Me.ComboPrecio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboPrecio, "OTRO"))
        Me.ComboPrecio.Location = New System.Drawing.Point(27, 64)
        Me.ComboPrecio.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboPrecio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboPrecio.Name = "ComboPrecio"
        Me.ComboPrecio.Size = New System.Drawing.Size(242, 21)
        Me.ComboPrecio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboPrecio.TabIndex = 669
        '
        'FormAddPrecioProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(516, 193)
        Me.Controls.Add(Me.ComboPrecio)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextCreditoSinIgv)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextCreditoConIgv)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextContadoSinIgv)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextContadoConIgv)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextRangoFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextRangoInicio)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAddPrecioProducto"
        Me.ShowIcon = False
        Me.Text = "Agregar Precio"
        CType(Me.TextRangoInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRangoFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextContadoSinIgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextContadoConIgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCreditoSinIgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCreditoConIgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents TextRangoInicio As Tools.CurrencyTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextRangoFin As Tools.CurrencyTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextContadoSinIgv As Tools.CurrencyTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextContadoConIgv As Tools.CurrencyTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextCreditoSinIgv As Tools.CurrencyTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextCreditoConIgv As Tools.CurrencyTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents ComboPrecio As Tools.ComboBoxAdv
End Class

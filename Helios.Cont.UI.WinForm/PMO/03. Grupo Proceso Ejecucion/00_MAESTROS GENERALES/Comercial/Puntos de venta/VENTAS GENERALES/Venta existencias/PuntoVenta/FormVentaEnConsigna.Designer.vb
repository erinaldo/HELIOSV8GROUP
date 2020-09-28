<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVentaEnConsigna
    Inherits Syncfusion.Windows.Forms.MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextProducto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.CboUnidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ButtonGrabar = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextCant = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextPrecUnitCompra = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextTotalCompra = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextPrecUnitVenta = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.TextProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPrecUnitCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotalCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPrecUnitVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre del producto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(274, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Unidad Medida"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "cantidad a vender"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(368, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 14)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Precio unit.de.venta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(286, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 14)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total"
        '
        'TextProducto
        '
        Me.TextProducto.BackColor = System.Drawing.Color.White
        Me.TextProducto.BeforeTouchSize = New System.Drawing.Size(227, 39)
        Me.TextProducto.BorderColor = System.Drawing.Color.Silver
        Me.TextProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProducto.CornerRadius = 5
        Me.TextProducto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextProducto.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextProducto.Location = New System.Drawing.Point(33, 54)
        Me.TextProducto.Metrocolor = System.Drawing.Color.Silver
        Me.TextProducto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextProducto.Multiline = True
        Me.TextProducto.Name = "TextProducto"
        Me.TextProducto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextProducto.Size = New System.Drawing.Size(227, 39)
        Me.TextProducto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextProducto.TabIndex = 415
        '
        'CboUnidad
        '
        Me.CboUnidad.BackColor = System.Drawing.Color.White
        Me.CboUnidad.BeforeTouchSize = New System.Drawing.Size(135, 21)
        Me.CboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboUnidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboUnidad.Location = New System.Drawing.Point(277, 72)
        Me.CboUnidad.MetroBorderColor = System.Drawing.Color.Silver
        Me.CboUnidad.Name = "CboUnidad"
        Me.CboUnidad.Size = New System.Drawing.Size(135, 21)
        Me.CboUnidad.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.CboUnidad.TabIndex = 416
        '
        'ButtonGrabar
        '
        Me.ButtonGrabar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(103, Byte), Integer))
        Me.ButtonGrabar.BeforeTouchSize = New System.Drawing.Size(119, 34)
        Me.ButtonGrabar.Font = New System.Drawing.Font("Calibri Light", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGrabar.ForeColor = System.Drawing.Color.White
        Me.ButtonGrabar.IsBackStageButton = False
        Me.ButtonGrabar.Location = New System.Drawing.Point(193, 168)
        Me.ButtonGrabar.Name = "ButtonGrabar"
        Me.ButtonGrabar.Size = New System.Drawing.Size(119, 34)
        Me.ButtonGrabar.TabIndex = 420
        Me.ButtonGrabar.Text = "Agregar producto"
        Me.ButtonGrabar.UseVisualStyle = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(145, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 14)
        Me.Label6.TabIndex = 421
        Me.Label6.Text = "Precio unit.compra"
        '
        'TextCant
        '
        Me.TextCant.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextCant.BeforeTouchSize = New System.Drawing.Size(227, 39)
        Me.TextCant.BorderColor = System.Drawing.Color.Silver
        Me.TextCant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCant.CornerRadius = 5
        Me.TextCant.CurrencySymbol = ""
        Me.TextCant.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCant.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextCant.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCant.ForeColor = System.Drawing.Color.Black
        Me.TextCant.Location = New System.Drawing.Point(39, 127)
        Me.TextCant.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextCant.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCant.Name = "TextCant"
        Me.TextCant.NullString = ""
        Me.TextCant.PositiveColor = System.Drawing.Color.Black
        Me.TextCant.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextCant.Size = New System.Drawing.Size(96, 22)
        Me.TextCant.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCant.TabIndex = 497
        Me.TextCant.Text = "0.00"
        Me.TextCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextPrecUnitCompra
        '
        Me.TextPrecUnitCompra.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextPrecUnitCompra.BeforeTouchSize = New System.Drawing.Size(227, 39)
        Me.TextPrecUnitCompra.BorderColor = System.Drawing.Color.Silver
        Me.TextPrecUnitCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPrecUnitCompra.CornerRadius = 5
        Me.TextPrecUnitCompra.CurrencySymbol = ""
        Me.TextPrecUnitCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPrecUnitCompra.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextPrecUnitCompra.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPrecUnitCompra.ForeColor = System.Drawing.Color.Black
        Me.TextPrecUnitCompra.Location = New System.Drawing.Point(148, 127)
        Me.TextPrecUnitCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextPrecUnitCompra.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPrecUnitCompra.Name = "TextPrecUnitCompra"
        Me.TextPrecUnitCompra.NullString = ""
        Me.TextPrecUnitCompra.PositiveColor = System.Drawing.Color.Black
        Me.TextPrecUnitCompra.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextPrecUnitCompra.Size = New System.Drawing.Size(96, 22)
        Me.TextPrecUnitCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextPrecUnitCompra.TabIndex = 498
        Me.TextPrecUnitCompra.Text = "0.00"
        Me.TextPrecUnitCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextTotalCompra
        '
        Me.TextTotalCompra.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextTotalCompra.BeforeTouchSize = New System.Drawing.Size(227, 39)
        Me.TextTotalCompra.BorderColor = System.Drawing.Color.Silver
        Me.TextTotalCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTotalCompra.CornerRadius = 5
        Me.TextTotalCompra.CurrencySymbol = ""
        Me.TextTotalCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTotalCompra.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextTotalCompra.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalCompra.ForeColor = System.Drawing.Color.Black
        Me.TextTotalCompra.Location = New System.Drawing.Point(257, 127)
        Me.TextTotalCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalCompra.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTotalCompra.Name = "TextTotalCompra"
        Me.TextTotalCompra.NullString = ""
        Me.TextTotalCompra.PositiveColor = System.Drawing.Color.Black
        Me.TextTotalCompra.ReadOnly = True
        Me.TextTotalCompra.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextTotalCompra.Size = New System.Drawing.Size(96, 22)
        Me.TextTotalCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextTotalCompra.TabIndex = 499
        Me.TextTotalCompra.Text = "0.00"
        Me.TextTotalCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextPrecUnitVenta
        '
        Me.TextPrecUnitVenta.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextPrecUnitVenta.BeforeTouchSize = New System.Drawing.Size(227, 39)
        Me.TextPrecUnitVenta.BorderColor = System.Drawing.Color.Silver
        Me.TextPrecUnitVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPrecUnitVenta.CornerRadius = 5
        Me.TextPrecUnitVenta.CurrencySymbol = ""
        Me.TextPrecUnitVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPrecUnitVenta.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextPrecUnitVenta.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPrecUnitVenta.ForeColor = System.Drawing.Color.Black
        Me.TextPrecUnitVenta.Location = New System.Drawing.Point(371, 127)
        Me.TextPrecUnitVenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextPrecUnitVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPrecUnitVenta.Name = "TextPrecUnitVenta"
        Me.TextPrecUnitVenta.NullString = ""
        Me.TextPrecUnitVenta.PositiveColor = System.Drawing.Color.Black
        Me.TextPrecUnitVenta.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextPrecUnitVenta.Size = New System.Drawing.Size(96, 22)
        Me.TextPrecUnitVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextPrecUnitVenta.TabIndex = 500
        Me.TextPrecUnitVenta.Text = "0.00"
        Me.TextPrecUnitVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FormVentaEnConsigna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(130, 24)
        CaptionLabel1.Text = "Productos en consigna"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(503, 207)
        Me.Controls.Add(Me.TextPrecUnitVenta)
        Me.Controls.Add(Me.TextTotalCompra)
        Me.Controls.Add(Me.TextPrecUnitCompra)
        Me.Controls.Add(Me.TextCant)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ButtonGrabar)
        Me.Controls.Add(Me.CboUnidad)
        Me.Controls.Add(Me.TextProducto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormVentaEnConsigna"
        Me.ShowIcon = False
        CType(Me.TextProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPrecUnitCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotalCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPrecUnitVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextProducto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents CboUnidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ButtonGrabar As RoundButton2
    Friend WithEvents Label6 As Label
    Friend WithEvents TextCant As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents TextPrecUnitCompra As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents TextTotalCompra As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents TextPrecUnitVenta As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class

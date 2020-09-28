Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCompraRapida
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
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextCantidad = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.txtProducto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingrese cantidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(149, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Almacén"
        '
        'cboAlmacen
        '
        Me.cboAlmacen.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.BeforeTouchSize = New System.Drawing.Size(221, 23)
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.Location = New System.Drawing.Point(152, 108)
        Me.cboAlmacen.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(221, 23)
        Me.cboAlmacen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAlmacen.TabIndex = 217
        '
        'TextCantidad
        '
        Me.TextCantidad.BackGroundColor = System.Drawing.Color.White
        Me.TextCantidad.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCantidad.BorderColor = System.Drawing.Color.Silver
        Me.TextCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCantidad.CurrencyDecimalDigits = 3
        Me.TextCantidad.CurrencySymbol = ""
        Me.TextCantidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCantidad.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.TextCantidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCantidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCantidad.Location = New System.Drawing.Point(44, 108)
        Me.TextCantidad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextCantidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.NullString = ""
        Me.TextCantidad.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCantidad.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextCantidad.Size = New System.Drawing.Size(91, 23)
        Me.TextCantidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCantidad.TabIndex = 494
        Me.TextCantidad.Text = "0.000"
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(95, 31)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(278, 143)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(95, 31)
        Me.RoundButton21.TabIndex = 495
        Me.RoundButton21.Text = "Comprar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.White
        Me.txtProducto.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtProducto.BorderColor = System.Drawing.Color.Silver
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProducto.Enabled = False
        Me.txtProducto.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProducto.Location = New System.Drawing.Point(44, 51)
        Me.txtProducto.Metrocolor = System.Drawing.Color.Silver
        Me.txtProducto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtProducto.Size = New System.Drawing.Size(329, 22)
        Me.txtProducto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtProducto.TabIndex = 500
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 501
        Me.Label3.Text = "Producto"
        '
        'FormCompraRapida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Compra rápida"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(419, 190)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.cboAlmacen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCompraRapida"
        Me.ShowIcon = False
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboAlmacen As Tools.ComboBoxAdv
    Friend WithEvents TextCantidad As Tools.CurrencyTextBox
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents txtProducto As Tools.TextBoxExt
    Friend WithEvents Label3 As Label
End Class

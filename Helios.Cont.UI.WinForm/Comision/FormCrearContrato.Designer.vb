Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearContrato
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
        Me.TextProducto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboUnidadComercial = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ComboCatalogo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboTipoComision = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateVigencia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumericApartir = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PanelUnidadComercial = New System.Windows.Forms.Panel()
        Me.LabelUnidadComercial = New System.Windows.Forms.Label()
        Me.PanelCatalogo = New System.Windows.Forms.Panel()
        Me.LabelCatalogo = New System.Windows.Forms.Label()
        CType(Me.TextProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboUnidadComercial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboTipoComision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateVigencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericApartir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUnidadComercial.SuspendLayout()
        Me.PanelCatalogo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccionar producto"
        '
        'TextProducto
        '
        Me.TextProducto.BeforeTouchSize = New System.Drawing.Size(342, 22)
        Me.TextProducto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProducto.CornerRadius = 4
        Me.TextProducto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextProducto.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProducto.Location = New System.Drawing.Point(39, 43)
        Me.TextProducto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextProducto.MinimumSize = New System.Drawing.Size(12, 8)
        Me.TextProducto.Name = "TextProducto"
        Me.TextProducto.ReadOnly = True
        Me.TextProducto.Size = New System.Drawing.Size(342, 22)
        Me.TextProducto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextProducto.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Unidad Comercial"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Catalogo de precios"
        '
        'ComboUnidadComercial
        '
        Me.ComboUnidadComercial.BackColor = System.Drawing.Color.White
        Me.ComboUnidadComercial.BeforeTouchSize = New System.Drawing.Size(289, 21)
        Me.ComboUnidadComercial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUnidadComercial.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboUnidadComercial.Location = New System.Drawing.Point(39, 94)
        Me.ComboUnidadComercial.Name = "ComboUnidadComercial"
        Me.ComboUnidadComercial.Size = New System.Drawing.Size(289, 21)
        Me.ComboUnidadComercial.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboUnidadComercial.TabIndex = 5
        '
        'ComboCatalogo
        '
        Me.ComboCatalogo.BackColor = System.Drawing.Color.White
        Me.ComboCatalogo.BeforeTouchSize = New System.Drawing.Size(289, 21)
        Me.ComboCatalogo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCatalogo.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCatalogo.Location = New System.Drawing.Point(39, 141)
        Me.ComboCatalogo.Name = "ComboCatalogo"
        Me.ComboCatalogo.Size = New System.Drawing.Size(289, 21)
        Me.ComboCatalogo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCatalogo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Descripción"
        '
        'TextDescripcion
        '
        Me.TextDescripcion.BeforeTouchSize = New System.Drawing.Size(342, 22)
        Me.TextDescripcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDescripcion.CornerRadius = 4
        Me.TextDescripcion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextDescripcion.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDescripcion.Location = New System.Drawing.Point(39, 192)
        Me.TextDescripcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextDescripcion.MinimumSize = New System.Drawing.Size(12, 8)
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(476, 22)
        Me.TextDescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextDescripcion.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(274, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Tipo comisión"
        '
        'ComboTipoComision
        '
        Me.ComboTipoComision.BackColor = System.Drawing.Color.White
        Me.ComboTipoComision.BeforeTouchSize = New System.Drawing.Size(112, 21)
        Me.ComboTipoComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoComision.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboTipoComision.Items.AddRange(New Object() {"MONTO", "PORCENTAJE"})
        Me.ComboTipoComision.Location = New System.Drawing.Point(277, 247)
        Me.ComboTipoComision.Name = "ComboTipoComision"
        Me.ComboTipoComision.Size = New System.Drawing.Size(112, 21)
        Me.ComboTipoComision.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboTipoComision.TabIndex = 10
        Me.ComboTipoComision.Text = "MONTO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Vigencia"
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
        Me.DateVigencia.Location = New System.Drawing.Point(39, 248)
        Me.DateVigencia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateVigencia.MinValue = New Date(CType(0, Long))
        Me.DateVigencia.Name = "DateVigencia"
        Me.DateVigencia.ShowCheckBox = False
        Me.DateVigencia.Size = New System.Drawing.Size(232, 20)
        Me.DateVigencia.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        Me.DateVigencia.TabIndex = 12
        Me.DateVigencia.Value = New Date(2020, 1, 2, 13, 55, 13, 331)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(394, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "A partir de:"
        '
        'NumericApartir
        '
        Me.NumericApartir.BeforeTouchSize = New System.Drawing.Size(120, 20)
        Me.NumericApartir.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.NumericApartir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericApartir.Location = New System.Drawing.Point(395, 248)
        Me.NumericApartir.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.NumericApartir.Name = "NumericApartir"
        Me.NumericApartir.Size = New System.Drawing.Size(120, 20)
        Me.NumericApartir.TabIndex = 14
        Me.NumericApartir.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(89, 36)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(239, 292)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(89, 36)
        Me.ButtonAdv1.TabIndex = 15
        Me.ButtonAdv1.Text = "Aceptar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(385, 49)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(49, 13)
        Me.LinkLabel1.TabIndex = 16
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Buscar..."
        '
        'PanelUnidadComercial
        '
        Me.PanelUnidadComercial.Controls.Add(Me.LabelUnidadComercial)
        Me.PanelUnidadComercial.Location = New System.Drawing.Point(39, 94)
        Me.PanelUnidadComercial.Name = "PanelUnidadComercial"
        Me.PanelUnidadComercial.Size = New System.Drawing.Size(342, 21)
        Me.PanelUnidadComercial.TabIndex = 17
        Me.PanelUnidadComercial.Visible = False
        '
        'LabelUnidadComercial
        '
        Me.LabelUnidadComercial.AutoSize = True
        Me.LabelUnidadComercial.Location = New System.Drawing.Point(3, 4)
        Me.LabelUnidadComercial.Name = "LabelUnidadComercial"
        Me.LabelUnidadComercial.Size = New System.Drawing.Size(90, 13)
        Me.LabelUnidadComercial.TabIndex = 3
        Me.LabelUnidadComercial.Text = "Unidad Comercial"
        '
        'PanelCatalogo
        '
        Me.PanelCatalogo.Controls.Add(Me.LabelCatalogo)
        Me.PanelCatalogo.Location = New System.Drawing.Point(39, 141)
        Me.PanelCatalogo.Name = "PanelCatalogo"
        Me.PanelCatalogo.Size = New System.Drawing.Size(342, 21)
        Me.PanelCatalogo.TabIndex = 18
        Me.PanelCatalogo.Visible = False
        '
        'LabelCatalogo
        '
        Me.LabelCatalogo.AutoSize = True
        Me.LabelCatalogo.Location = New System.Drawing.Point(3, 4)
        Me.LabelCatalogo.Name = "LabelCatalogo"
        Me.LabelCatalogo.Size = New System.Drawing.Size(49, 13)
        Me.LabelCatalogo.TabIndex = 3
        Me.LabelCatalogo.Text = "Catalogo"
        '
        'FormCrearContrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 333)
        Me.Controls.Add(Me.PanelCatalogo)
        Me.Controls.Add(Me.PanelUnidadComercial)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.NumericApartir)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DateVigencia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboTipoComision)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboCatalogo)
        Me.Controls.Add(Me.ComboUnidadComercial)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextProducto)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearContrato"
        Me.ShowIcon = False
        Me.Text = "Crear contrato"
        CType(Me.TextProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboUnidadComercial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboTipoComision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateVigencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericApartir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUnidadComercial.ResumeLayout(False)
        Me.PanelUnidadComercial.PerformLayout()
        Me.PanelCatalogo.ResumeLayout(False)
        Me.PanelCatalogo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextProducto As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboUnidadComercial As Tools.ComboBoxAdv
    Friend WithEvents ComboCatalogo As Tools.ComboBoxAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents TextDescripcion As Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboTipoComision As Tools.ComboBoxAdv
    Friend WithEvents Label6 As Label
    Friend WithEvents DateVigencia As Tools.DateTimePickerAdv
    Friend WithEvents Label7 As Label
    Friend WithEvents NumericApartir As Tools.NumericUpDownExt
    Friend WithEvents ButtonAdv1 As ButtonAdv
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents PanelUnidadComercial As Panel
    Friend WithEvents LabelUnidadComercial As Label
    Friend WithEvents PanelCatalogo As Panel
    Friend WithEvents LabelCatalogo As Label
End Class

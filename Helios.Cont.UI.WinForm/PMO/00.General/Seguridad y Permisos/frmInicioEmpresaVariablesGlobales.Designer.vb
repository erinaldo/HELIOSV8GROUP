<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInicioEmpresaVariablesGlobales
    Inherits frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicioEmpresaVariablesGlobales))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudTipoCambioVenta = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.nudTipoCambioCompra = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtIva = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtMontoVenta = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboTipoVenta = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudTipoCambioVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTipoCambioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtMontoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.cboTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudTipoCambioVenta)
        Me.GroupBox1.Controls.Add(Me.nudTipoCambioCompra)
        Me.GroupBox1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 63)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de cambio del día"
        '
        'nudTipoCambioVenta
        '
        Me.nudTipoCambioVenta.BackGroundColor = System.Drawing.Color.White
        Me.nudTipoCambioVenta.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.nudTipoCambioVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.nudTipoCambioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTipoCambioVenta.CurrencyDecimalDigits = 3
        Me.nudTipoCambioVenta.CurrencySymbol = "V- "
        Me.nudTipoCambioVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nudTipoCambioVenta.DecimalValue = New Decimal(New Integer() {3000, 0, 0, 196608})
        Me.nudTipoCambioVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudTipoCambioVenta.Location = New System.Drawing.Point(103, 25)
        Me.nudTipoCambioVenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nudTipoCambioVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.nudTipoCambioVenta.Name = "nudTipoCambioVenta"
        Me.nudTipoCambioVenta.NullString = ""
        Me.nudTipoCambioVenta.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudTipoCambioVenta.ReadOnly = True
        Me.nudTipoCambioVenta.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.nudTipoCambioVenta.Size = New System.Drawing.Size(62, 22)
        Me.nudTipoCambioVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.nudTipoCambioVenta.TabIndex = 497
        Me.nudTipoCambioVenta.Text = "V- 3.000"
        '
        'nudTipoCambioCompra
        '
        Me.nudTipoCambioCompra.BackGroundColor = System.Drawing.Color.White
        Me.nudTipoCambioCompra.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.nudTipoCambioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.nudTipoCambioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTipoCambioCompra.CurrencyDecimalDigits = 3
        Me.nudTipoCambioCompra.CurrencySymbol = "C- "
        Me.nudTipoCambioCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nudTipoCambioCompra.DecimalValue = New Decimal(New Integer() {3000, 0, 0, 196608})
        Me.nudTipoCambioCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudTipoCambioCompra.Location = New System.Drawing.Point(36, 25)
        Me.nudTipoCambioCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nudTipoCambioCompra.MinimumSize = New System.Drawing.Size(14, 10)
        Me.nudTipoCambioCompra.Name = "nudTipoCambioCompra"
        Me.nudTipoCambioCompra.NullString = ""
        Me.nudTipoCambioCompra.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudTipoCambioCompra.ReadOnly = True
        Me.nudTipoCambioCompra.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.nudTipoCambioCompra.Size = New System.Drawing.Size(62, 22)
        Me.nudTipoCambioCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.nudTipoCambioCompra.TabIndex = 496
        Me.nudTipoCambioCompra.Text = "C- 3.000"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSerie)
        Me.GroupBox2.Controls.Add(Me.txtIva)
        Me.GroupBox2.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(218, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 63)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "IVA."
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtSerie.BorderColor = System.Drawing.Color.Silver
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSerie.Location = New System.Drawing.Point(10, 27)
        Me.txtSerie.MaxLength = 10
        Me.txtSerie.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(101, 20)
        Me.txtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSerie.TabIndex = 5
        Me.txtSerie.Text = "I.G.V."
        '
        'txtIva
        '
        Me.txtIva.BackGroundColor = System.Drawing.Color.White
        Me.txtIva.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtIva.BorderColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.txtIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIva.CurrencyDecimalDigits = 3
        Me.txtIva.CurrencySymbol = ""
        Me.txtIva.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIva.DecimalValue = New Decimal(New Integer() {18000, 0, 0, 196608})
        Me.txtIva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtIva.Location = New System.Drawing.Point(117, 25)
        Me.txtIva.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtIva.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtIva.Name = "txtIva"
        Me.txtIva.NullString = ""
        Me.txtIva.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtIva.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtIva.Size = New System.Drawing.Size(62, 22)
        Me.txtIva.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtIva.TabIndex = 497
        Me.txtIva.Text = "18.000"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMontoVenta)
        Me.GroupBox3.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 90)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 63)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Importe máximo para emitir factura de ventas"
        '
        'txtMontoVenta
        '
        Me.txtMontoVenta.BackGroundColor = System.Drawing.Color.White
        Me.txtMontoVenta.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtMontoVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.txtMontoVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoVenta.CurrencyDecimalDigits = 3
        Me.txtMontoVenta.CurrencySymbol = ""
        Me.txtMontoVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMontoVenta.DecimalValue = New Decimal(New Integer() {699000, 0, 0, 196608})
        Me.txtMontoVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMontoVenta.Location = New System.Drawing.Point(36, 33)
        Me.txtMontoVenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtMontoVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMontoVenta.Name = "txtMontoVenta"
        Me.txtMontoVenta.NullString = ""
        Me.txtMontoVenta.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMontoVenta.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtMontoVenta.Size = New System.Drawing.Size(129, 22)
        Me.txtMontoVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtMontoVenta.TabIndex = 498
        Me.txtMontoVenta.Text = "699.000"
        '
        'GradientPanel7
        '
        Me.GradientPanel7.BorderColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.GradientPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel7.Controls.Add(Me.ButtonAdv6)
        Me.GradientPanel7.Location = New System.Drawing.Point(141, 173)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(152, 34)
        Me.GradientPanel7.TabIndex = 499
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.White
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(150, 32)
        Me.ButtonAdv6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv6.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(150, 32)
        Me.ButtonAdv6.TabIndex = 53
        Me.ButtonAdv6.Text = "Guardar configuración"
        Me.ButtonAdv6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboTipoVenta)
        Me.GroupBox4.Location = New System.Drawing.Point(218, 90)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(198, 64)
        Me.GroupBox4.TabIndex = 505
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Formato de venta"
        '
        'cboTipoVenta
        '
        Me.cboTipoVenta.BackColor = System.Drawing.Color.White
        Me.cboTipoVenta.BeforeTouchSize = New System.Drawing.Size(169, 21)
        Me.cboTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoVenta.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoVenta.Items.AddRange(New Object() {"VENTA DIRECTA", "VENTA MINIMARKET"})
        Me.cboTipoVenta.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoVenta, "VENTA DIRECTA"))
        Me.cboTipoVenta.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoVenta, "VENTA MINIMARKET"))
        Me.cboTipoVenta.Location = New System.Drawing.Point(23, 33)
        Me.cboTipoVenta.Name = "cboTipoVenta"
        Me.cboTipoVenta.Size = New System.Drawing.Size(169, 21)
        Me.cboTipoVenta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoVenta.TabIndex = 502
        Me.cboTipoVenta.Text = "VENTA DIRECTA"
        '
        'frmInicioEmpresaVariablesGlobales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.CaptionBarHeight = 60
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 14)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Variables Globales"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.White
        CaptionLabel2.Location = New System.Drawing.Point(55, 25)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Text = "Configuración"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(446, 214)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GradientPanel7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmInicioEmpresaVariablesGlobales"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.Text = ""
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudTipoCambioVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTipoCambioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtMontoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.cboTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents nudTipoCambioVenta As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents nudTipoCambioCompra As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtIva As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtMontoVenta As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtSerie As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GradientPanel7 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cboTipoVenta As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
End Class

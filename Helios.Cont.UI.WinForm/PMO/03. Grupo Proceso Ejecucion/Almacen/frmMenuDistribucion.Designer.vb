<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuDistribucion
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuDistribucion))
        Me.txtDoc = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chAplicarAll = New System.Windows.Forms.CheckBox()
        Me.cboComprobante = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboAlmacen = New System.Windows.Forms.ComboBox()
        Me.cboEstablecimiento = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.exMenu = New XPanderControl.XPander()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAnio = New System.Windows.Forms.MaskedTextBox()
        Me.txtMes = New System.Windows.Forms.MaskedTextBox()
        Me.txtDia = New System.Windows.Forms.MaskedTextBox()
        Me.cboDestino = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.exMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDoc
        '
        Me.txtDoc.Enabled = False
        Me.txtDoc.Location = New System.Drawing.Point(264, 184)
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.Size = New System.Drawing.Size(47, 22)
        Me.txtDoc.TabIndex = 19
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(138, 229)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(176, 22)
        Me.txtNumero.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label6.Location = New System.Drawing.Point(135, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Número:"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(29, 229)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(103, 22)
        Me.txtSerie.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(26, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Serie:"
        '
        'chAplicarAll
        '
        Me.chAplicarAll.AutoSize = True
        Me.chAplicarAll.Location = New System.Drawing.Point(35, 262)
        Me.chAplicarAll.Name = "chAplicarAll"
        Me.chAplicarAll.Size = New System.Drawing.Size(120, 17)
        Me.chAplicarAll.TabIndex = 14
        Me.chAplicarAll.Text = "Aplicar para todos"
        Me.chAplicarAll.UseVisualStyleBackColor = True
        '
        'cboComprobante
        '
        Me.cboComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComprobante.DropDownWidth = 450
        Me.cboComprobante.FormattingEnabled = True
        Me.cboComprobante.Location = New System.Drawing.Point(29, 184)
        Me.cboComprobante.Name = "cboComprobante"
        Me.cboComprobante.Size = New System.Drawing.Size(232, 21)
        Me.cboComprobante.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(26, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Comprobante:"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(139, 285)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 44)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "&Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(33, 285)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 44)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.FormattingEnabled = True
        Me.cboAlmacen.Location = New System.Drawing.Point(29, 95)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(288, 21)
        Me.cboAlmacen.TabIndex = 3
        '
        'cboEstablecimiento
        '
        Me.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstablecimiento.FormattingEnabled = True
        Me.cboEstablecimiento.Location = New System.Drawing.Point(29, 50)
        Me.cboEstablecimiento.Name = "cboEstablecimiento"
        Me.cboEstablecimiento.Size = New System.Drawing.Size(288, 21)
        Me.cboEstablecimiento.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(26, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Almacen:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(26, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Establecimiento:"
        '
        'exMenu
        '
        Me.exMenu.BackColor = System.Drawing.Color.Transparent
        Me.exMenu.BorderStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.exMenu.CanToggle = False
        Me.exMenu.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exMenu.CaptionFormatFlag = XPanderControl.XPander.FormatFlag.NoWrap
        Me.exMenu.CaptionStyle = XPanderControl.XPander.CaptionStyleEnum.Normal
        Me.exMenu.CaptionText = "Configuración:"
        Me.exMenu.CaptionTextAlign = XPanderControl.XPander.CaptionTextAlignment.Left
        Me.exMenu.ChevronStyle = XPanderControl.XPander.ChevronStyleEnum.Image
        Me.exMenu.CollapsedHighlightImage = CType(resources.GetObject("exMenu.CollapsedHighlightImage"), System.Drawing.Bitmap)
        Me.exMenu.CollapsedImage = CType(resources.GetObject("exMenu.CollapsedImage"), System.Drawing.Bitmap)
        Me.exMenu.Controls.Add(Me.Label10)
        Me.exMenu.Controls.Add(Me.Label9)
        Me.exMenu.Controls.Add(Me.Label8)
        Me.exMenu.Controls.Add(Me.txtAnio)
        Me.exMenu.Controls.Add(Me.txtMes)
        Me.exMenu.Controls.Add(Me.txtDia)
        Me.exMenu.Controls.Add(Me.cboDestino)
        Me.exMenu.Controls.Add(Me.Label7)
        Me.exMenu.Controls.Add(Me.txtDoc)
        Me.exMenu.Controls.Add(Me.cboAlmacen)
        Me.exMenu.Controls.Add(Me.txtNumero)
        Me.exMenu.Controls.Add(Me.Label1)
        Me.exMenu.Controls.Add(Me.Label6)
        Me.exMenu.Controls.Add(Me.Label2)
        Me.exMenu.Controls.Add(Me.txtSerie)
        Me.exMenu.Controls.Add(Me.cboEstablecimiento)
        Me.exMenu.Controls.Add(Me.Label5)
        Me.exMenu.Controls.Add(Me.Button1)
        Me.exMenu.Controls.Add(Me.chAplicarAll)
        Me.exMenu.Controls.Add(Me.Button2)
        Me.exMenu.Controls.Add(Me.Label3)
        Me.exMenu.Controls.Add(Me.cboComprobante)
        Me.exMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.exMenu.ExpandedHighlightImage = CType(resources.GetObject("exMenu.ExpandedHighlightImage"), System.Drawing.Bitmap)
        Me.exMenu.ExpandedImage = CType(resources.GetObject("exMenu.ExpandedImage"), System.Drawing.Bitmap)
        Me.exMenu.Location = New System.Drawing.Point(0, 0)
        Me.exMenu.Name = "exMenu"
        Me.exMenu.Padding = New System.Windows.Forms.Padding(0, 25, 0, 0)
        Me.exMenu.Size = New System.Drawing.Size(344, 338)
        Me.exMenu.TabIndex = 1
        Me.exMenu.TooltipText = Nothing
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label10.Location = New System.Drawing.Point(97, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Año:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label9.Location = New System.Drawing.Point(60, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Mes:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label8.Location = New System.Drawing.Point(26, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Día:"
        '
        'txtAnio
        '
        Me.txtAnio.Location = New System.Drawing.Point(96, 139)
        Me.txtAnio.Mask = "9999"
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(41, 22)
        Me.txtAnio.TabIndex = 24
        Me.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMes
        '
        Me.txtMes.Location = New System.Drawing.Point(63, 139)
        Me.txtMes.Mask = "99"
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Size = New System.Drawing.Size(22, 22)
        Me.txtMes.TabIndex = 23
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDia
        '
        Me.txtDia.Location = New System.Drawing.Point(29, 139)
        Me.txtDia.Mask = "99"
        Me.txtDia.Name = "txtDia"
        Me.txtDia.Size = New System.Drawing.Size(23, 22)
        Me.txtDia.TabIndex = 22
        Me.txtDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboDestino
        '
        Me.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino.DropDownWidth = 450
        Me.cboDestino.FormattingEnabled = True
        Me.cboDestino.Location = New System.Drawing.Point(146, 140)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(171, 21)
        Me.cboDestino.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Location = New System.Drawing.Point(143, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Destino:"
        '
        'frmMenuDistribucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(344, 338)
        Me.ControlBox = False
        Me.Controls.Add(Me.exMenu)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMenuDistribucion"
        Me.Text = "Menú"
        Me.exMenu.ResumeLayout(False)
        Me.exMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstablecimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chAplicarAll As System.Windows.Forms.CheckBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDoc As System.Windows.Forms.TextBox
    Friend WithEvents exMenu As XPanderControl.XPander
    Friend WithEvents cboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAnio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtMes As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDia As System.Windows.Forms.MaskedTextBox
End Class

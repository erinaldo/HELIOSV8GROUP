<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormModificarPecio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormModificarPecio))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.OK = New System.Windows.Forms.Button()
        Me.txtPrecio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBTotal = New System.Windows.Forms.RadioButton()
        Me.RBPrecioVenta = New System.Windows.Forms.RadioButton()
        CType(Me.PasswordTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsernameTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(50, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 23)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "&Ingresar valor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.Location = New System.Drawing.Point(47, 12)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(197, 23)
        Me.UsernameLabel.TabIndex = 6
        Me.UsernameLabel.Text = "&Administrador"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.White
        Me.PasswordTextBox.BeforeTouchSize = New System.Drawing.Size(223, 25)
        Me.PasswordTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PasswordTextBox.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.PasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PasswordTextBox.Location = New System.Drawing.Point(50, 94)
        Me.PasswordTextBox.MaxLength = 20
        Me.PasswordTextBox.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.PasswordTextBox.MinimumSize = New System.Drawing.Size(14, 10)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(223, 21)
        Me.PasswordTextBox.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.PasswordTextBox.TabIndex = 8
        Me.PasswordTextBox.Text = "123"
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLabel.Location = New System.Drawing.Point(47, 68)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(226, 23)
        Me.PasswordLabel.TabIndex = 9
        Me.PasswordLabel.Text = "&Clave"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.White
        Me.UsernameTextBox.BeforeTouchSize = New System.Drawing.Size(223, 25)
        Me.UsernameTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.UsernameTextBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTextBox.Location = New System.Drawing.Point(50, 39)
        Me.UsernameTextBox.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.UsernameTextBox.MinimumSize = New System.Drawing.Size(14, 10)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.NearImage = CType(resources.GetObject("UsernameTextBox.NearImage"), System.Drawing.Image)
        Me.UsernameTextBox.Size = New System.Drawing.Size(223, 25)
        Me.UsernameTextBox.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.UsernameTextBox.TabIndex = 7
        Me.UsernameTextBox.Text = "admin"
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.SystemColors.HotTrack
        Me.OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.OK.FlatAppearance.BorderSize = 0
        Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK.ForeColor = System.Drawing.Color.White
        Me.OK.Location = New System.Drawing.Point(99, 253)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(134, 36)
        Me.OK.TabIndex = 10
        Me.OK.Text = "&Aceptar"
        Me.OK.UseVisualStyleBackColor = False
        '
        'txtPrecio
        '
        Me.txtPrecio.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPrecio.BeforeTouchSize = New System.Drawing.Size(223, 25)
        Me.txtPrecio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecio.CurrencyDecimalDigits = 5
        Me.txtPrecio.CurrencySymbol = ""
        Me.txtPrecio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrecio.DecimalValue = New Decimal(New Integer() {0, 0, 0, 327680})
        Me.txtPrecio.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.ForeColor = System.Drawing.Color.Black
        Me.txtPrecio.Location = New System.Drawing.Point(53, 213)
        Me.txtPrecio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPrecio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.NullString = ""
        Me.txtPrecio.PositiveColor = System.Drawing.Color.Black
        Me.txtPrecio.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtPrecio.Size = New System.Drawing.Size(220, 27)
        Me.txtPrecio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtPrecio.TabIndex = 496
        Me.txtPrecio.Text = "0.00000"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBTotal)
        Me.GroupBox1.Controls.Add(Me.RBPrecioVenta)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(50, 124)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(223, 58)
        Me.GroupBox1.TabIndex = 498
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "&Columna a modificar"
        '
        'RBTotal
        '
        Me.RBTotal.AutoSize = True
        Me.RBTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBTotal.Location = New System.Drawing.Point(150, 26)
        Me.RBTotal.Name = "RBTotal"
        Me.RBTotal.Size = New System.Drawing.Size(52, 19)
        Me.RBTotal.TabIndex = 1
        Me.RBTotal.Text = "Total"
        Me.RBTotal.UseVisualStyleBackColor = True
        '
        'RBPrecioVenta
        '
        Me.RBPrecioVenta.AutoSize = True
        Me.RBPrecioVenta.Checked = True
        Me.RBPrecioVenta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBPrecioVenta.Location = New System.Drawing.Point(23, 26)
        Me.RBPrecioVenta.Name = "RBPrecioVenta"
        Me.RBPrecioVenta.Size = New System.Drawing.Size(106, 19)
        Me.RBPrecioVenta.TabIndex = 0
        Me.RBPrecioVenta.TabStop = True
        Me.RBPrecioVenta.Text = "Precio unitario"
        Me.RBPrecioVenta.UseVisualStyleBackColor = True
        '
        'FormModificarPecio
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.CaptionBarHeight = 55
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.HotTrack
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 10)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Importe Manual"
        CaptionLabel2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.Navy
        CaptionLabel2.Location = New System.Drawing.Point(55, 25)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Manipular precio, importe"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(329, 301)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.OK)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormModificarPecio"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        CType(Me.PasswordTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsernameTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents PasswordTextBox As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents PasswordLabel As Label
    Friend WithEvents UsernameTextBox As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents OK As Button
    Friend WithEvents txtPrecio As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RBTotal As RadioButton
    Friend WithEvents RBPrecioVenta As RadioButton
End Class

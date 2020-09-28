Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddUnidadComercial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddUnidadComercial))
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextUnidadPrincipal = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextUnidadComercial = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextContenidoNeto = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.TextUnidadPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextUnidadComercial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextContenidoNeto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.BunifuThinButton21.Location = New System.Drawing.Point(129, 203)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(129, 40)
        Me.BunifuThinButton21.TabIndex = 668
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(44, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(182, 18)
        Me.Label4.TabIndex = 669
        Me.Label4.Text = "Agregar unidad comercial"
        '
        'TextUnidadPrincipal
        '
        Me.TextUnidadPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextUnidadPrincipal.BeforeTouchSize = New System.Drawing.Size(278, 22)
        Me.TextUnidadPrincipal.BorderColor = System.Drawing.Color.DimGray
        Me.TextUnidadPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextUnidadPrincipal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextUnidadPrincipal.CornerRadius = 4
        Me.TextUnidadPrincipal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextUnidadPrincipal.FarImage = CType(resources.GetObject("TextUnidadPrincipal.FarImage"), System.Drawing.Image)
        Me.TextUnidadPrincipal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextUnidadPrincipal.ForeColor = System.Drawing.Color.White
        Me.TextUnidadPrincipal.Location = New System.Drawing.Point(47, 110)
        Me.TextUnidadPrincipal.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextUnidadPrincipal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextUnidadPrincipal.Name = "TextUnidadPrincipal"
        Me.TextUnidadPrincipal.ReadOnly = True
        Me.TextUnidadPrincipal.Size = New System.Drawing.Size(278, 22)
        Me.TextUnidadPrincipal.TabIndex = 672
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(48, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 671
        Me.Label1.Text = "Unidad principal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(44, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 674
        Me.Label2.Text = "Descripción"
        '
        'TextUnidadComercial
        '
        Me.TextUnidadComercial.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextUnidadComercial.BeforeTouchSize = New System.Drawing.Size(278, 22)
        Me.TextUnidadComercial.BorderColor = System.Drawing.Color.DimGray
        Me.TextUnidadComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextUnidadComercial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextUnidadComercial.CornerRadius = 4
        Me.TextUnidadComercial.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextUnidadComercial.FarImage = CType(resources.GetObject("TextUnidadComercial.FarImage"), System.Drawing.Image)
        Me.TextUnidadComercial.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextUnidadComercial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextUnidadComercial.Location = New System.Drawing.Point(47, 58)
        Me.TextUnidadComercial.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextUnidadComercial.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextUnidadComercial.Name = "TextUnidadComercial"
        Me.TextUnidadComercial.Size = New System.Drawing.Size(278, 22)
        Me.TextUnidadComercial.TabIndex = 675
        '
        'TextContenidoNeto
        '
        Me.TextContenidoNeto.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextContenidoNeto.BeforeTouchSize = New System.Drawing.Size(278, 22)
        Me.TextContenidoNeto.BorderColor = System.Drawing.Color.Silver
        Me.TextContenidoNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextContenidoNeto.CornerRadius = 4
        Me.TextContenidoNeto.CurrencySymbol = ""
        Me.TextContenidoNeto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextContenidoNeto.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextContenidoNeto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextContenidoNeto.Location = New System.Drawing.Point(47, 162)
        Me.TextContenidoNeto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextContenidoNeto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextContenidoNeto.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TextContenidoNeto.Name = "TextContenidoNeto"
        Me.TextContenidoNeto.NullString = ""
        Me.TextContenidoNeto.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextContenidoNeto.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextContenidoNeto.Size = New System.Drawing.Size(102, 20)
        Me.TextContenidoNeto.TabIndex = 681
        Me.TextContenidoNeto.Text = "0.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(48, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 680
        Me.Label6.Text = "Contenido"
        '
        'FormAddUnidadComercial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(386, 257)
        Me.Controls.Add(Me.TextContenidoNeto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextUnidadComercial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextUnidadPrincipal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAddUnidadComercial"
        Me.ShowIcon = False
        Me.Text = "Unidad comercial"
        CType(Me.TextUnidadPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextUnidadComercial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextContenidoNeto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Label4 As Label
    Friend WithEvents TextUnidadPrincipal As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextUnidadComercial As Tools.TextBoxExt
    Friend WithEvents TextContenidoNeto As Tools.CurrencyTextBox
    Friend WithEvents Label6 As Label
End Class

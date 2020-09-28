Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormNuevoCatalogoPrecios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNuevoCatalogoPrecios))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextNombreCatalogo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        CType(Me.TextNombreCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(23, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 16)
        Me.Label4.TabIndex = 535
        Me.Label4.Text = "Nombre Catalogo/Lista"
        '
        'TextNombreCatalogo
        '
        Me.TextNombreCatalogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextNombreCatalogo.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.TextNombreCatalogo.BorderColor = System.Drawing.Color.DimGray
        Me.TextNombreCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNombreCatalogo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombreCatalogo.CornerRadius = 4
        Me.TextNombreCatalogo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNombreCatalogo.FarImage = CType(resources.GetObject("TextNombreCatalogo.FarImage"), System.Drawing.Image)
        Me.TextNombreCatalogo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombreCatalogo.ForeColor = System.Drawing.Color.White
        Me.TextNombreCatalogo.Location = New System.Drawing.Point(25, 49)
        Me.TextNombreCatalogo.MaxLength = 50
        Me.TextNombreCatalogo.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextNombreCatalogo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNombreCatalogo.Name = "TextNombreCatalogo"
        Me.TextNombreCatalogo.Size = New System.Drawing.Size(303, 22)
        Me.TextNombreCatalogo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNombreCatalogo.TabIndex = 544
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
        Me.BunifuThinButton21.Location = New System.Drawing.Point(120, 79)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(116, 40)
        Me.BunifuThinButton21.TabIndex = 668
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormNuevoCatalogoPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(358, 123)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.TextNombreCatalogo)
        Me.Controls.Add(Me.Label4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormNuevoCatalogoPrecios"
        Me.ShowIcon = False
        Me.Text = "Crear Catalogo de Precio"
        CType(Me.TextNombreCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents TextNombreCatalogo As Tools.TextBoxExt
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
End Class

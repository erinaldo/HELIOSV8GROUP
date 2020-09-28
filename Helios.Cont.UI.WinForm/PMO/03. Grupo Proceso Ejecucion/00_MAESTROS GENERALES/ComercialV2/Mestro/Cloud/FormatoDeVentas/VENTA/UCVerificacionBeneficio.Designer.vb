<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCVerificacionBeneficio
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCVerificacionBeneficio))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFiltrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBeneficioFinal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.ButtonAddServicio = New Bunifu.Framework.UI.BunifuThinButton2()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBeneficioFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Beneficio obtenido"
        '
        'txtFiltrar
        '
        Me.txtFiltrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.txtFiltrar.BeforeTouchSize = New System.Drawing.Size(266, 22)
        Me.txtFiltrar.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.txtFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrar.CornerRadius = 4
        Me.txtFiltrar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFiltrar.FarImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_engine1
        Me.txtFiltrar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.ForeColor = System.Drawing.Color.White
        Me.txtFiltrar.Location = New System.Drawing.Point(22, 59)
        Me.txtFiltrar.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtFiltrar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.txtFiltrar.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.txtFiltrar.Size = New System.Drawing.Size(266, 22)
        Me.txtFiltrar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtFiltrar.TabIndex = 544
        Me.txtFiltrar.ThemesEnabled = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(19, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 545
        Me.Label2.Text = "Aplica a:"
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(266, 22)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxExt1.CornerRadius = 4
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBoxExt1.FarImage = CType(resources.GetObject("TextBoxExt1.FarImage"), System.Drawing.Image)
        Me.TextBoxExt1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExt1.ForeColor = System.Drawing.Color.White
        Me.TextBoxExt1.Location = New System.Drawing.Point(22, 106)
        Me.TextBoxExt1.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.TextBoxExt1.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.TextBoxExt1.Size = New System.Drawing.Size(266, 22)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBoxExt1.TabIndex = 546
        Me.TextBoxExt1.ThemesEnabled = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(19, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 12)
        Me.Label3.TabIndex = 547
        Me.Label3.Text = "Beneficio resultante"
        '
        'TextBeneficioFinal
        '
        Me.TextBeneficioFinal.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.TextBeneficioFinal.BeforeTouchSize = New System.Drawing.Size(266, 22)
        Me.TextBeneficioFinal.BorderColor = System.Drawing.Color.Yellow
        Me.TextBeneficioFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBeneficioFinal.CornerRadius = 5
        Me.TextBeneficioFinal.CurrencySymbol = ""
        Me.TextBeneficioFinal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBeneficioFinal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextBeneficioFinal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBeneficioFinal.ForeColor = System.Drawing.Color.Yellow
        Me.TextBeneficioFinal.Location = New System.Drawing.Point(22, 158)
        Me.TextBeneficioFinal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBeneficioFinal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBeneficioFinal.Name = "TextBeneficioFinal"
        Me.TextBeneficioFinal.NearImage = CType(resources.GetObject("TextBeneficioFinal.NearImage"), System.Drawing.Image)
        Me.TextBeneficioFinal.NullString = ""
        Me.TextBeneficioFinal.PositiveColor = System.Drawing.Color.Yellow
        Me.TextBeneficioFinal.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBeneficioFinal.Size = New System.Drawing.Size(156, 27)
        Me.TextBeneficioFinal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBeneficioFinal.TabIndex = 642
        Me.TextBeneficioFinal.Text = "0.00"
        Me.TextBeneficioFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ButtonAddServicio
        '
        Me.ButtonAddServicio.ActiveBorderThickness = 1
        Me.ButtonAddServicio.ActiveCornerRadius = 20
        Me.ButtonAddServicio.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.ButtonAddServicio.ActiveForecolor = System.Drawing.Color.White
        Me.ButtonAddServicio.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.ButtonAddServicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.ButtonAddServicio.BackgroundImage = CType(resources.GetObject("ButtonAddServicio.BackgroundImage"), System.Drawing.Image)
        Me.ButtonAddServicio.ButtonText = "Agregar"
        Me.ButtonAddServicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAddServicio.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddServicio.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAddServicio.IdleBorderThickness = 1
        Me.ButtonAddServicio.IdleCornerRadius = 20
        Me.ButtonAddServicio.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.ButtonAddServicio.IdleForecolor = System.Drawing.Color.White
        Me.ButtonAddServicio.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.ButtonAddServicio.Location = New System.Drawing.Point(198, 150)
        Me.ButtonAddServicio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonAddServicio.Name = "ButtonAddServicio"
        Me.ButtonAddServicio.Size = New System.Drawing.Size(90, 37)
        Me.ButtonAddServicio.TabIndex = 694
        Me.ButtonAddServicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ButtonAddServicio.Visible = False
        '
        'UCVerificacionBeneficio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.Controls.Add(Me.ButtonAddServicio)
        Me.Controls.Add(Me.TextBeneficioFinal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxExt1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UCVerificacionBeneficio"
        Me.Size = New System.Drawing.Size(308, 206)
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBeneficioFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtFiltrar As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBeneficioFinal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents ButtonAddServicio As Bunifu.Framework.UI.BunifuThinButton2
End Class

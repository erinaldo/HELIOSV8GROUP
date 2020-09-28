<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCantidades
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCantidades))
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtiditem = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtidmovimiento = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonAdv16 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtdescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcantmax = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtcantmin = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        CType(Me.txtiditem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidmovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcantmax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcantmin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(16, 56)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(89, 13)
        Me.Label28.TabIndex = 418
        Me.Label28.Text = "Cantidad Maxima"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(143, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 419
        Me.Label1.Text = "Cantidad Minima"
        '
        'txtiditem
        '
        Me.txtiditem.BackColor = System.Drawing.Color.White
        Me.txtiditem.BeforeTouchSize = New System.Drawing.Size(218, 20)
        Me.txtiditem.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtiditem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtiditem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtiditem.CornerRadius = 5
        Me.txtiditem.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtiditem.FocusBorderColor = System.Drawing.Color.YellowGreen
        Me.txtiditem.Location = New System.Drawing.Point(274, 39)
        Me.txtiditem.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtiditem.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtiditem.Multiline = True
        Me.txtiditem.Name = "txtiditem"
        Me.txtiditem.Size = New System.Drawing.Size(63, 20)
        Me.txtiditem.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtiditem.TabIndex = 420
        Me.txtiditem.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(284, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 421
        Me.Label2.Text = "iditem"
        '
        'txtidmovimiento
        '
        Me.txtidmovimiento.BackColor = System.Drawing.Color.White
        Me.txtidmovimiento.BeforeTouchSize = New System.Drawing.Size(218, 20)
        Me.txtidmovimiento.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtidmovimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidmovimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidmovimiento.CornerRadius = 5
        Me.txtidmovimiento.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtidmovimiento.FocusBorderColor = System.Drawing.Color.YellowGreen
        Me.txtidmovimiento.Location = New System.Drawing.Point(389, 39)
        Me.txtidmovimiento.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtidmovimiento.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtidmovimiento.Multiline = True
        Me.txtidmovimiento.Name = "txtidmovimiento"
        Me.txtidmovimiento.Size = New System.Drawing.Size(63, 20)
        Me.txtidmovimiento.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtidmovimiento.TabIndex = 422
        Me.txtidmovimiento.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(386, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 423
        Me.Label3.Text = "idalmacen"
        '
        'ButtonAdv16
        '
        Me.ButtonAdv16.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv16.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv16.BeforeTouchSize = New System.Drawing.Size(67, 32)
        Me.ButtonAdv16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv16.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv16.IsBackStageButton = False
        Me.ButtonAdv16.Location = New System.Drawing.Point(15, 119)
        Me.ButtonAdv16.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv16.Name = "ButtonAdv16"
        Me.ButtonAdv16.Size = New System.Drawing.Size(67, 32)
        Me.ButtonAdv16.TabIndex = 424
        Me.ButtonAdv16.Text = "Grabar"
        Me.ButtonAdv16.UseVisualStyle = True
        Me.ButtonAdv16.UseVisualStyleBackColor = False
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(66, 32)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(136, 119)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(66, 32)
        Me.ButtonAdv1.TabIndex = 425
        Me.ButtonAdv1.Text = "Cancelar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'txtdescripcion
        '
        Me.txtdescripcion.BackColor = System.Drawing.Color.White
        Me.txtdescripcion.BeforeTouchSize = New System.Drawing.Size(218, 20)
        Me.txtdescripcion.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtdescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescripcion.CornerRadius = 5
        Me.txtdescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtdescripcion.FocusBorderColor = System.Drawing.Color.YellowGreen
        Me.txtdescripcion.Location = New System.Drawing.Point(19, 33)
        Me.txtdescripcion.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtdescripcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdescripcion.Multiline = True
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.ReadOnly = True
        Me.txtdescripcion.Size = New System.Drawing.Size(201, 20)
        Me.txtdescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtdescripcion.TabIndex = 426
        Me.txtdescripcion.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(17, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 427
        Me.Label4.Text = "Descripción:"
        '
        'txtcantmax
        '
        Me.txtcantmax.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtcantmax.BeforeTouchSize = New System.Drawing.Size(218, 20)
        Me.txtcantmax.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtcantmax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcantmax.CornerRadius = 5
        Me.txtcantmax.CurrencySymbol = ""
        Me.txtcantmax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcantmax.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtcantmax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtcantmax.Location = New System.Drawing.Point(12, 81)
        Me.txtcantmax.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtcantmax.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtcantmax.Name = "txtcantmax"
        Me.txtcantmax.NearImage = CType(resources.GetObject("txtcantmax.NearImage"), System.Drawing.Image)
        Me.txtcantmax.NullString = ""
        Me.txtcantmax.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtcantmax.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcantmax.Size = New System.Drawing.Size(114, 20)
        Me.txtcantmax.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtcantmax.TabIndex = 492
        Me.txtcantmax.Text = "0.00"
        '
        'txtcantmin
        '
        Me.txtcantmin.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtcantmin.BeforeTouchSize = New System.Drawing.Size(218, 20)
        Me.txtcantmin.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtcantmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcantmin.CornerRadius = 5
        Me.txtcantmin.CurrencySymbol = ""
        Me.txtcantmin.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtcantmin.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtcantmin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtcantmin.Location = New System.Drawing.Point(146, 81)
        Me.txtcantmin.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtcantmin.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtcantmin.Name = "txtcantmin"
        Me.txtcantmin.NearImage = CType(resources.GetObject("txtcantmin.NearImage"), System.Drawing.Image)
        Me.txtcantmin.NullString = ""
        Me.txtcantmin.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtcantmin.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcantmin.Size = New System.Drawing.Size(103, 20)
        Me.txtcantmin.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtcantmin.TabIndex = 493
        Me.txtcantmin.Text = "0.00"
        '
        'frmCantidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 174)
        Me.Controls.Add(Me.txtcantmin)
        Me.Controls.Add(Me.txtcantmax)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtdescripcion)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.ButtonAdv16)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtidmovimiento)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtiditem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label28)
        Me.Name = "frmCantidades"
        Me.Text = ""
        CType(Me.txtiditem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidmovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcantmax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcantmin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtiditem As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtidmovimiento As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonAdv16 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtdescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcantmax As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtcantmin As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class

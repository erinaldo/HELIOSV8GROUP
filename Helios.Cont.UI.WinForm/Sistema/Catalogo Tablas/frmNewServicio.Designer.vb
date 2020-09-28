<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewServicio
    Inherits frmMaster

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
        Dim MetroColorTable1 As Syncfusion.Windows.Forms.MetroColorTable = New Syncfusion.Windows.Forms.MetroColorTable()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblidservicio = New System.Windows.Forms.Label()
        Me.txtDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCodigoCuenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboCuenta = New Syncfusion.Windows.Forms.Tools.MultiColumnComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(201, 159)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 33)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(278, 159)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 33)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Descripcion"
        '
        'lblidservicio
        '
        Me.lblidservicio.AutoSize = True
        Me.lblidservicio.Location = New System.Drawing.Point(318, 88)
        Me.lblidservicio.Name = "lblidservicio"
        Me.lblidservicio.Size = New System.Drawing.Size(40, 13)
        Me.lblidservicio.TabIndex = 4
        Me.lblidservicio.Text = "Label2"
        Me.lblidservicio.Visible = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.BeforeTouchSize = New System.Drawing.Size(352, 49)
        Me.txtDescripcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.CornerRadius = 5
        Me.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescripcion.Location = New System.Drawing.Point(15, 36)
        Me.txtDescripcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtDescripcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(352, 49)
        Me.txtDescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDescripcion.TabIndex = 448
        Me.txtDescripcion.TabStop = False
        '
        'txtCodigoCuenta
        '
        Me.txtCodigoCuenta.BackColor = System.Drawing.Color.White
        Me.txtCodigoCuenta.BeforeTouchSize = New System.Drawing.Size(352, 49)
        Me.txtCodigoCuenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCuenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoCuenta.Location = New System.Drawing.Point(264, 124)
        Me.txtCodigoCuenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoCuenta.Name = "txtCodigoCuenta"
        Me.txtCodigoCuenta.Size = New System.Drawing.Size(89, 22)
        Me.txtCodigoCuenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCodigoCuenta.TabIndex = 488
        '
        'cboCuenta
        '
        Me.cboCuenta.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboCuenta.BackColor = System.Drawing.Color.White
        Me.cboCuenta.BeforeTouchSize = New System.Drawing.Size(245, 21)
        Me.cboCuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuenta.Location = New System.Drawing.Point(13, 124)
        Me.cboCuenta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboCuenta.Name = "cboCuenta"
        MetroColorTable1.ArrowChecked = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        MetroColorTable1.ArrowInActive = System.Drawing.Color.White
        MetroColorTable1.ArrowNormal = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ArrowNormalBackGround = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ArrowPushed = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ArrowPushedBackGround = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ScrollerBackground = System.Drawing.Color.White
        MetroColorTable1.ThumbChecked = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        MetroColorTable1.ThumbInActive = System.Drawing.Color.White
        MetroColorTable1.ThumbNormal = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ThumbPushed = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ThumbPushedBorder = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cboCuenta.ScrollMetroColorTable = MetroColorTable1
        Me.cboCuenta.Size = New System.Drawing.Size(245, 21)
        Me.cboCuenta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCuenta.TabIndex = 487
        Me.cboCuenta.Text = "Selecione una cuenta contable"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(13, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 11)
        Me.Label9.TabIndex = 486
        Me.Label9.Text = "CUENTA CONTABLE"
        '
        'frmNewServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.Silver
        Me.CaptionBarHeight = 50
        Me.ClientSize = New System.Drawing.Size(375, 201)
        Me.Controls.Add(Me.txtCodigoCuenta)
        Me.Controls.Add(Me.cboCuenta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblidservicio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmNewServicio"
        Me.ShowIcon = False
        Me.Text = "Nuevo Servicio"
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblidservicio As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCodigoCuenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboCuenta As Syncfusion.Windows.Forms.Tools.MultiColumnComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class

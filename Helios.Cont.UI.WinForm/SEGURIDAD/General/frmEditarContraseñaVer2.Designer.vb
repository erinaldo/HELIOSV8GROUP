Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditarContraseñaVer2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarContraseñaVer2))
        Me.txtPass = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAlias = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.lblidusuario = New System.Windows.Forms.Label()
        Me.txtContraAntiguo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcontraRepetir = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.txtPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        CType(Me.txtContraAntiguo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcontraRepetir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPass
        '
        Me.txtPass.BackColor = System.Drawing.Color.White
        Me.txtPass.BeforeTouchSize = New System.Drawing.Size(222, 20)
        Me.txtPass.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPass.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPass.Location = New System.Drawing.Point(25, 144)
        Me.txtPass.MaxLength = 11
        Me.txtPass.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtPass.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(223, 20)
        Me.txtPass.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPass.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 14)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Nueva Contraseña"
        '
        'txtAlias
        '
        Me.txtAlias.BackColor = System.Drawing.Color.White
        Me.txtAlias.BeforeTouchSize = New System.Drawing.Size(222, 20)
        Me.txtAlias.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlias.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAlias.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlias.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAlias.Location = New System.Drawing.Point(27, 39)
        Me.txtAlias.MaxLength = 10
        Me.txtAlias.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtAlias.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(222, 20)
        Me.txtAlias.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtAlias.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 14)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Alias"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel1.Location = New System.Drawing.Point(143, 240)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(105, 24)
        Me.GradientPanel1.TabIndex = 502
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.White
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(103, 22)
        Me.ButtonAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv1.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(103, 22)
        Me.ButtonAdv1.TabIndex = 0
        Me.ButtonAdv1.Text = "Cancelar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'GradientPanel7
        '
        Me.GradientPanel7.BorderColor = System.Drawing.Color.OrangeRed
        Me.GradientPanel7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel7.Controls.Add(Me.ButtonAdv6)
        Me.GradientPanel7.Location = New System.Drawing.Point(27, 240)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(108, 24)
        Me.GradientPanel7.TabIndex = 501
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(108, 24)
        Me.ButtonAdv6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv6.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(108, 24)
        Me.ButtonAdv6.TabIndex = 0
        Me.ButtonAdv6.Text = "     Grabar"
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'lblidusuario
        '
        Me.lblidusuario.AutoSize = True
        Me.lblidusuario.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidusuario.Location = New System.Drawing.Point(101, 9)
        Me.lblidusuario.Name = "lblidusuario"
        Me.lblidusuario.Size = New System.Drawing.Size(13, 14)
        Me.lblidusuario.TabIndex = 503
        Me.lblidusuario.Text = "0"
        Me.lblidusuario.Visible = False
        '
        'txtContraAntiguo
        '
        Me.txtContraAntiguo.BackColor = System.Drawing.Color.White
        Me.txtContraAntiguo.BeforeTouchSize = New System.Drawing.Size(222, 20)
        Me.txtContraAntiguo.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtContraAntiguo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContraAntiguo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtContraAntiguo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContraAntiguo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtContraAntiguo.Location = New System.Drawing.Point(25, 91)
        Me.txtContraAntiguo.MaxLength = 11
        Me.txtContraAntiguo.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtContraAntiguo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtContraAntiguo.Name = "txtContraAntiguo"
        Me.txtContraAntiguo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraAntiguo.Size = New System.Drawing.Size(224, 20)
        Me.txtContraAntiguo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtContraAntiguo.TabIndex = 504
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 14)
        Me.Label1.TabIndex = 505
        Me.Label1.Text = "Contraseña antigua"
        '
        'txtcontraRepetir
        '
        Me.txtcontraRepetir.BackColor = System.Drawing.Color.White
        Me.txtcontraRepetir.BeforeTouchSize = New System.Drawing.Size(222, 20)
        Me.txtcontraRepetir.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtcontraRepetir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcontraRepetir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcontraRepetir.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcontraRepetir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtcontraRepetir.Location = New System.Drawing.Point(27, 198)
        Me.txtcontraRepetir.MaxLength = 11
        Me.txtcontraRepetir.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtcontraRepetir.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtcontraRepetir.Name = "txtcontraRepetir"
        Me.txtcontraRepetir.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontraRepetir.Size = New System.Drawing.Size(222, 20)
        Me.txtcontraRepetir.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtcontraRepetir.TabIndex = 506
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 14)
        Me.Label2.TabIndex = 507
        Me.Label2.Text = "repetir contraseña"
        '
        'frmEditarContraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.CaptionBarColor = System.Drawing.SystemColors.MenuHighlight
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(273, 279)
        Me.Controls.Add(Me.txtcontraRepetir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtContraAntiguo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblidusuario)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel7)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAlias)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmEditarContraseña"
        Me.ShowIcon = False
        CType(Me.txtPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        CType(Me.txtContraAntiguo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcontraRepetir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPass As Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAlias As Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As ButtonAdv
    Friend WithEvents GradientPanel7 As Tools.GradientPanel
    Friend WithEvents ButtonAdv6 As ButtonAdv
    Friend WithEvents lblidusuario As Label
    Friend WithEvents txtContraAntiguo As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents txtcontraRepetir As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
End Class

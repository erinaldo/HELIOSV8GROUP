<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInformation
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInformation))
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.btnAceptar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancelar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PanelTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.Label2)
        Me.PanelTop.Controls.Add(Me.PictureBox1)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(287, 144)
        Me.PanelTop.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAceptar.BorderRadius = 7
        Me.btnAceptar.ButtonText = "ACEPTAR"
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.DisabledColor = System.Drawing.Color.Gray
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Iconcolor = System.Drawing.Color.Transparent
        Me.btnAceptar.Iconimage = Nothing
        Me.btnAceptar.Iconimage_right = Nothing
        Me.btnAceptar.Iconimage_right_Selected = Nothing
        Me.btnAceptar.Iconimage_Selected = Nothing
        Me.btnAceptar.IconMarginLeft = 0
        Me.btnAceptar.IconMarginRight = 0
        Me.btnAceptar.IconRightVisible = True
        Me.btnAceptar.IconRightZoom = 0R
        Me.btnAceptar.IconVisible = True
        Me.btnAceptar.IconZoom = 90.0R
        Me.btnAceptar.IsTab = False
        Me.btnAceptar.Location = New System.Drawing.Point(29, 272)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnAceptar.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnAceptar.OnHoverTextColor = System.Drawing.Color.White
        Me.btnAceptar.selected = False
        Me.btnAceptar.Size = New System.Drawing.Size(94, 45)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAceptar.Textcolor = System.Drawing.Color.White
        Me.btnAceptar.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(7, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(271, 71)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Piense bien la opcion que va elegir, elija cuidadosamente."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.White
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(12, 155)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(266, 23)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Text = "MESSAGE"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(59, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 115)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(91, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 41)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "AVISO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelar.BorderRadius = 7
        Me.btnCancelar.ButtonText = "CANCELAR"
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DisabledColor = System.Drawing.Color.Gray
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Iconcolor = System.Drawing.Color.Transparent
        Me.btnCancelar.Iconimage = Nothing
        Me.btnCancelar.Iconimage_right = Nothing
        Me.btnCancelar.Iconimage_right_Selected = Nothing
        Me.btnCancelar.Iconimage_Selected = Nothing
        Me.btnCancelar.IconMarginLeft = 0
        Me.btnCancelar.IconMarginRight = 0
        Me.btnCancelar.IconRightVisible = True
        Me.btnCancelar.IconRightZoom = 0R
        Me.btnCancelar.IconVisible = True
        Me.btnCancelar.IconZoom = 90.0R
        Me.btnCancelar.IsTab = False
        Me.btnCancelar.Location = New System.Drawing.Point(159, 272)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnCancelar.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnCancelar.OnHoverTextColor = System.Drawing.Color.White
        Me.btnCancelar.selected = False
        Me.btnCancelar.Size = New System.Drawing.Size(94, 45)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCancelar.Textcolor = System.Drawing.Color.White
        Me.btnCancelar.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'FrmInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(287, 329)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.PanelTop)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmInformation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmInformation"
        Me.PanelTop.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTop As Panel
    Friend WithEvents btnAceptar As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCancelar As Bunifu.Framework.UI.BunifuFlatButton
End Class

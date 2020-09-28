<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSuccess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSuccess))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.esclarecerForm = New Bunifu.Framework.UI.BunifuFormFadeTransition(Me.components)
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PanelTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'esclarecerForm
        '
        Me.esclarecerForm.Delay = 1
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.PictureBox1)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(287, 144)
        Me.PanelTop.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(103, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 115)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(12, 150)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(266, 23)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "MESSAGE"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(7, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(271, 71)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Acción Completada Correctamente. usted puede seguir usando el sistema"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btnAceptar.Location = New System.Drawing.Point(41, 267)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnAceptar.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnAceptar.OnHoverTextColor = System.Drawing.Color.White
        Me.btnAceptar.selected = False
        Me.btnAceptar.Size = New System.Drawing.Size(205, 45)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAceptar.Textcolor = System.Drawing.Color.White
        Me.btnAceptar.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'FrmSuccess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(287, 329)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.PanelTop)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSuccess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSuccess"
        Me.PanelTop.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents esclarecerForm As Bunifu.Framework.UI.BunifuFormFadeTransition
    Friend WithEvents PanelTop As Panel
    Friend WithEvents lblMessage As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAceptar As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PictureBox1 As PictureBox
End Class

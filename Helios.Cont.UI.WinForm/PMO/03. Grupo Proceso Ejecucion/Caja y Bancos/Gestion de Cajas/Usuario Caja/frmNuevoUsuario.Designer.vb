<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoUsuario))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.pcTrabajador = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.txtApmatTrab = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtDniTrab = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAppatTrab = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtNombreTrab = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.btGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pcTrabajador.SuspendLayout()
        CType(Me.txtApmatTrab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDniTrab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAppatTrab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreTrab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.PegarToolStripButton, Me.lblIdDocumento})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(324, 25)
        Me.ToolStrip3.TabIndex = 407
        Me.ToolStrip3.Text = "ToolStrip3"
        Me.ToolStrip3.Visible = False
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PegarToolStripButton.Text = "&Cancelar"
        Me.PegarToolStripButton.Visible = False
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(19, 22)
        Me.lblIdDocumento.Text = "00"
        Me.lblIdDocumento.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(324, 25)
        Me.ToolStrip1.TabIndex = 408
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(119, 22)
        Me.lblEstado.Text = "Estado: nuevo usuario"
        '
        'pcTrabajador
        '
        Me.pcTrabajador.Controls.Add(Me.txtApmatTrab)
        Me.pcTrabajador.Controls.Add(Me.Label37)
        Me.pcTrabajador.Controls.Add(Me.txtDniTrab)
        Me.pcTrabajador.Controls.Add(Me.Label17)
        Me.pcTrabajador.Controls.Add(Me.txtAppatTrab)
        Me.pcTrabajador.Controls.Add(Me.Label21)
        Me.pcTrabajador.Controls.Add(Me.txtNombreTrab)
        Me.pcTrabajador.Controls.Add(Me.Label22)
        Me.pcTrabajador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcTrabajador.IgnoreKeys = True
        Me.pcTrabajador.Location = New System.Drawing.Point(0, 45)
        Me.pcTrabajador.Name = "pcTrabajador"
        Me.pcTrabajador.Size = New System.Drawing.Size(324, 215)
        Me.pcTrabajador.TabIndex = 421
        '
        'txtApmatTrab
        '
        Me.txtApmatTrab.BackColor = System.Drawing.Color.White
        Me.txtApmatTrab.BeforeTouchSize = New System.Drawing.Size(132, 20)
        Me.txtApmatTrab.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtApmatTrab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApmatTrab.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApmatTrab.CornerRadius = 5
        Me.txtApmatTrab.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtApmatTrab.Location = New System.Drawing.Point(11, 157)
        Me.txtApmatTrab.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtApmatTrab.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtApmatTrab.Name = "txtApmatTrab"
        Me.txtApmatTrab.Size = New System.Drawing.Size(304, 20)
        Me.txtApmatTrab.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtApmatTrab.TabIndex = 407
        Me.txtApmatTrab.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label37.Location = New System.Drawing.Point(11, 139)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(91, 13)
        Me.Label37.TabIndex = 406
        Me.Label37.Text = "Apellido Materno:"
        '
        'txtDniTrab
        '
        Me.txtDniTrab.BackColor = System.Drawing.Color.White
        Me.txtDniTrab.BeforeTouchSize = New System.Drawing.Size(132, 20)
        Me.txtDniTrab.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtDniTrab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDniTrab.CornerRadius = 5
        Me.txtDniTrab.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDniTrab.Location = New System.Drawing.Point(8, 27)
        Me.txtDniTrab.MaxLength = 8
        Me.txtDniTrab.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtDniTrab.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDniTrab.Name = "txtDniTrab"
        Me.txtDniTrab.Size = New System.Drawing.Size(132, 20)
        Me.txtDniTrab.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDniTrab.TabIndex = 404
        Me.txtDniTrab.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(11, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 13)
        Me.Label17.TabIndex = 403
        Me.Label17.Text = "Nro. D.N.I.:"
        '
        'txtAppatTrab
        '
        Me.txtAppatTrab.BackColor = System.Drawing.Color.White
        Me.txtAppatTrab.BeforeTouchSize = New System.Drawing.Size(132, 20)
        Me.txtAppatTrab.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtAppatTrab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAppatTrab.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAppatTrab.CornerRadius = 5
        Me.txtAppatTrab.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAppatTrab.Location = New System.Drawing.Point(11, 114)
        Me.txtAppatTrab.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtAppatTrab.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtAppatTrab.Name = "txtAppatTrab"
        Me.txtAppatTrab.Size = New System.Drawing.Size(304, 20)
        Me.txtAppatTrab.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtAppatTrab.TabIndex = 402
        Me.txtAppatTrab.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(11, 96)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(89, 13)
        Me.Label21.TabIndex = 401
        Me.Label21.Text = "Apellido Paterno:"
        '
        'txtNombreTrab
        '
        Me.txtNombreTrab.BackColor = System.Drawing.Color.White
        Me.txtNombreTrab.BeforeTouchSize = New System.Drawing.Size(132, 20)
        Me.txtNombreTrab.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtNombreTrab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreTrab.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreTrab.CornerRadius = 5
        Me.txtNombreTrab.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNombreTrab.Location = New System.Drawing.Point(11, 71)
        Me.txtNombreTrab.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtNombreTrab.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNombreTrab.Name = "txtNombreTrab"
        Me.txtNombreTrab.Size = New System.Drawing.Size(304, 20)
        Me.txtNombreTrab.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNombreTrab.TabIndex = 400
        Me.txtNombreTrab.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(11, 54)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 13)
        Me.Label22.TabIndex = 211
        Me.Label22.Text = "Nombres:"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.ToolStrip5)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(324, 45)
        Me.Panel7.TabIndex = 422
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPerido, Me.btGrabar})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip5.Size = New System.Drawing.Size(324, 45)
        Me.ToolStrip5.TabIndex = 1
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'lblPerido
        '
        Me.lblPerido.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPerido.BackColor = System.Drawing.Color.Transparent
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Image = CType(resources.GetObject("lblPerido.Image"), System.Drawing.Image)
        Me.lblPerido.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(94, 42)
        Me.lblPerido.Text = "Período: 2015"
        Me.lblPerido.Visible = False
        '
        'btGrabar
        '
        Me.btGrabar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(44, 42)
        Me.btGrabar.Text = "Grabar pedido"
        '
        'frmNuevoUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(2, 4)
        CaptionImage1.Name = "CaptionImage1"
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(150, 24)
        CaptionLabel1.Text = "Nuevo Usuario"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(324, 260)
        Me.Controls.Add(Me.pcTrabajador)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.Panel7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNuevoUsuario"
        Me.ShowIcon = False
        Me.Text = ""
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pcTrabajador.ResumeLayout(False)
        Me.pcTrabajador.PerformLayout()
        CType(Me.txtApmatTrab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDniTrab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAppatTrab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreTrab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PegarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Private WithEvents pcTrabajador As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents txtApmatTrab As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtDniTrab As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAppatTrab As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtNombreTrab As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btGrabar As System.Windows.Forms.ToolStripButton
End Class

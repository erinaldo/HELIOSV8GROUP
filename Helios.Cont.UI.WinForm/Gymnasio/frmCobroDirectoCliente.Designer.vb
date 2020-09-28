<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCobroDirectoCliente
    Inherits frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCobroDirectoCliente))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.txtCliente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btPagos = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btAsistencia = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btMembresias = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chHuella = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ImagenHuella = New System.Windows.Forms.PictureBox()
        Me.ImageListAdv2 = New Syncfusion.Windows.Forms.Tools.ImageListAdv(Me.components)
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.ImagenHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.BeforeTouchSize = New System.Drawing.Size(220, 23)
        Me.txtCliente.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.txtCliente.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.CornerRadius = 5
        Me.txtCliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtCliente.Location = New System.Drawing.Point(14, 259)
        Me.txtCliente.MaxLength = 11
        Me.txtCliente.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCliente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(220, 23)
        Me.txtCliente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCliente.TabIndex = 0
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 239)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Consultar socio x DNI."
        '
        'btPagos
        '
        Me.btPagos.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btPagos.BackColor = System.Drawing.Color.OrangeRed
        Me.btPagos.BeforeTouchSize = New System.Drawing.Size(112, 30)
        Me.btPagos.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPagos.ForeColor = System.Drawing.Color.White
        Me.btPagos.Image = CType(resources.GetObject("btPagos.Image"), System.Drawing.Image)
        Me.btPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPagos.IsBackStageButton = False
        Me.btPagos.Location = New System.Drawing.Point(244, 311)
        Me.btPagos.Name = "btPagos"
        Me.btPagos.Size = New System.Drawing.Size(112, 30)
        Me.btPagos.TabIndex = 13
        Me.btPagos.Text = "            Ver pagos"
        Me.btPagos.UseVisualStyle = True
        '
        'btAsistencia
        '
        Me.btAsistencia.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btAsistencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.btAsistencia.BeforeTouchSize = New System.Drawing.Size(113, 30)
        Me.btAsistencia.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAsistencia.ForeColor = System.Drawing.Color.White
        Me.btAsistencia.Image = CType(resources.GetObject("btAsistencia.Image"), System.Drawing.Image)
        Me.btAsistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btAsistencia.IsBackStageButton = False
        Me.btAsistencia.Location = New System.Drawing.Point(129, 311)
        Me.btAsistencia.Name = "btAsistencia"
        Me.btAsistencia.Size = New System.Drawing.Size(113, 30)
        Me.btAsistencia.TabIndex = 14
        Me.btAsistencia.Text = "         Ver asistencia"
        Me.btAsistencia.UseVisualStyle = True
        '
        'Panel1
        '
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(655, 352)
        Me.Panel1.TabIndex = 15
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.btMembresias)
        Me.Panel3.Controls.Add(Me.btAsistencia)
        Me.Panel3.Controls.Add(Me.btPagos)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtCliente)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(284, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(371, 352)
        Me.Panel3.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label3.Location = New System.Drawing.Point(15, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 14)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Ststus"
        '
        'btMembresias
        '
        Me.btMembresias.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btMembresias.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.btMembresias.BeforeTouchSize = New System.Drawing.Size(113, 30)
        Me.btMembresias.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMembresias.ForeColor = System.Drawing.Color.White
        Me.btMembresias.Image = CType(resources.GetObject("btMembresias.Image"), System.Drawing.Image)
        Me.btMembresias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btMembresias.IsBackStageButton = False
        Me.btMembresias.Location = New System.Drawing.Point(14, 311)
        Me.btMembresias.Name = "btMembresias"
        Me.btMembresias.Size = New System.Drawing.Size(113, 30)
        Me.btMembresias.TabIndex = 15
        Me.btMembresias.Text = "            Membresías"
        Me.btMembresias.UseVisualStyle = True
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(371, 222)
        Me.Panel4.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 19)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Soft Pack ERP inc."
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Panel2.Controls.Add(Me.chHuella)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.GradientPanel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(284, 352)
        Me.Panel2.TabIndex = 0
        '
        'chHuella
        '
        Me.chHuella.AutoSize = True
        Me.chHuella.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chHuella.Location = New System.Drawing.Point(17, 68)
        Me.chHuella.Name = "chHuella"
        Me.chHuella.Size = New System.Drawing.Size(158, 17)
        Me.chHuella.TabIndex = 412
        Me.chHuella.Text = "Activar detección de huella"
        Me.chHuella.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(13, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 19)
        Me.Label6.TabIndex = 411
        Me.Label6.Text = "Consultar por huella:"
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel5.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.GradientPanel5.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.ImagenHuella)
        Me.GradientPanel5.Enabled = False
        Me.GradientPanel5.Location = New System.Drawing.Point(16, 92)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(254, 250)
        Me.GradientPanel5.TabIndex = 410
        '
        'ImagenHuella
        '
        Me.ImagenHuella.BackColor = System.Drawing.Color.White
        Me.ImagenHuella.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagenHuella.Image = CType(resources.GetObject("ImagenHuella.Image"), System.Drawing.Image)
        Me.ImagenHuella.Location = New System.Drawing.Point(0, 0)
        Me.ImagenHuella.Name = "ImagenHuella"
        Me.ImagenHuella.Size = New System.Drawing.Size(252, 248)
        Me.ImagenHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImagenHuella.TabIndex = 0
        Me.ImagenHuella.TabStop = False
        '
        'ImageListAdv2
        '
        Me.ImageListAdv2.Images.AddRange(New System.Drawing.Image() {CType(resources.GetObject("ImageListAdv2.Images"), System.Drawing.Image)})
        Me.ImageListAdv2.ImageSize = New System.Drawing.Size(256, 256)
        '
        'frmCobroDirectoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.CaptionBarHeight = 60
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(55, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Información de Socios"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(655, 353)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCobroDirectoCliente"
        Me.ShowIcon = False
        Me.Text = "'"
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.ImagenHuella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtCliente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents btPagos As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btAsistencia As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents btMembresias As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Private WithEvents GradientPanel5 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ImagenHuella As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel4 As Panel
    Private WithEvents ImageListAdv2 As Syncfusion.Windows.Forms.Tools.ImageListAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents chHuella As CheckBox
End Class

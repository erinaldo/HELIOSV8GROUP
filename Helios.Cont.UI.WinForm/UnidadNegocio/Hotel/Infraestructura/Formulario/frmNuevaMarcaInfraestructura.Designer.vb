<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevaMarcaInfraestructura
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevaMarcaInfraestructura))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.txtDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.chClasificacion = New System.Windows.Forms.CheckBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtCategoria = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvCategoria = New System.Windows.Forms.ListBox()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv10 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.BeforeTouchSize = New System.Drawing.Size(559, 44)
        Me.txtDescripcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescripcion.Location = New System.Drawing.Point(29, 109)
        Me.txtDescripcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtDescripcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(303, 61)
        Me.txtDescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDescripcion.TabIndex = 416
        Me.txtDescripcion.TabStop = False
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel2.Controls.Add(Me.btOperacion)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 184)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(355, 54)
        Me.GradientPanel2.TabIndex = 431
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.White
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(229, 13)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.TabIndex = 9
        Me.ButtonAdv2.Text = "Cancel"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(114, 13)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 8
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(29, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 436
        Me.Label1.Text = "Descripción"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(355, 10)
        Me.GradientPanel1.TabIndex = 437
        '
        'chClasificacion
        '
        Me.chClasificacion.AutoSize = True
        Me.chClasificacion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chClasificacion.ForeColor = System.Drawing.Color.DimGray
        Me.chClasificacion.Location = New System.Drawing.Point(23, 4)
        Me.chClasificacion.Name = "chClasificacion"
        Me.chClasificacion.Size = New System.Drawing.Size(132, 17)
        Me.chClasificacion.TabIndex = 521
        Me.chClasificacion.Text = "Asignar Clasificación"
        Me.chClasificacion.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Black
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(278, 51)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 534
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'txtCategoria
        '
        Me.txtCategoria.BackColor = System.Drawing.Color.White
        Me.txtCategoria.BeforeTouchSize = New System.Drawing.Size(559, 44)
        Me.txtCategoria.BorderColor = System.Drawing.Color.DimGray
        Me.txtCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategoria.CornerRadius = 4
        Me.txtCategoria.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoria.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoria.ForeColor = System.Drawing.Color.White
        Me.txtCategoria.Location = New System.Drawing.Point(23, 51)
        Me.txtCategoria.Metrocolor = System.Drawing.Color.LightGray
        Me.txtCategoria.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtCategoria.Size = New System.Drawing.Size(253, 22)
        Me.txtCategoria.TabIndex = 533
        Me.txtCategoria.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(20, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 13)
        Me.Label8.TabIndex = 532
        Me.Label8.Text = "Grupo o Clasificación"
        Me.Label8.Visible = False
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcLikeCategoria.Controls.Add(Me.lsvCategoria)
        Me.pcLikeCategoria.Controls.Add(Me.ButtonAdv3)
        Me.pcLikeCategoria.Controls.Add(Me.ButtonAdv10)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(364, 13)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(193, 80)
        Me.pcLikeCategoria.TabIndex = 535
        Me.pcLikeCategoria.Visible = False
        '
        'lsvCategoria
        '
        Me.lsvCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvCategoria.Dock = System.Windows.Forms.DockStyle.Top
        Me.lsvCategoria.FormattingEnabled = True
        Me.lsvCategoria.Location = New System.Drawing.Point(0, 0)
        Me.lsvCategoria.Name = "lsvCategoria"
        Me.lsvCategoria.Size = New System.Drawing.Size(191, 104)
        Me.lsvCategoria.TabIndex = 3
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(59, 110)
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv3.TabIndex = 2
        Me.ButtonAdv3.Text = "Cancel"
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'ButtonAdv10
        '
        Me.ButtonAdv10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv10.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv10.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv10.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv10.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv10.IsBackStageButton = False
        Me.ButtonAdv10.Location = New System.Drawing.Point(3, 110)
        Me.ButtonAdv10.Name = "ButtonAdv10"
        Me.ButtonAdv10.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv10.TabIndex = 1
        Me.ButtonAdv10.Text = "OK"
        Me.ButtonAdv10.UseVisualStyle = True
        '
        'frmNuevaMarcaInfraestructura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(18, 9)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(25, 25)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.Gray
        CaptionLabel1.Location = New System.Drawing.Point(40, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(170, 24)
        CaptionLabel1.Text = "Sub clasificación."
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(355, 238)
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.chClasificacion)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.txtDescripcion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNuevaMarcaInfraestructura"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents chClasificacion As CheckBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents txtCategoria As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label8 As Label
    Private WithEvents pcLikeCategoria As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvCategoria As ListBox
    Private WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv10 As Syncfusion.Windows.Forms.ButtonAdv
End Class

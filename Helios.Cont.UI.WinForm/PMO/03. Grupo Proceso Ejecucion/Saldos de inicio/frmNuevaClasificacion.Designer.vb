<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevaClasificacion
    Inherits frmMaster

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
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevaClasificacion))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtClasificacion = New Helios.Cont.Presentation.WinForm.TextboxJiu(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblidClasificacion = New System.Windows.Forms.Label()
        Me.chkCodigo = New System.Windows.Forms.CheckBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClasificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(23, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 19)
        Me.Label1.TabIndex = 440
        Me.Label1.Text = "Descripción SubClasificacion"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.txtDescripcion.BeforeTouchSize = New System.Drawing.Size(353, 79)
        Me.txtDescripcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescripcion.ForeColor = System.Drawing.Color.White
        Me.txtDescripcion.Location = New System.Drawing.Point(27, 115)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDescripcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtDescripcion.MinimumSize = New System.Drawing.Size(16, 12)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(353, 79)
        Me.txtDescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDescripcion.TabIndex = 439
        Me.txtDescripcion.TabStop = False
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.White
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(117, 42)
        Me.ButtonAdv2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(262, 277)
        Me.ButtonAdv2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonAdv2.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(117, 42)
        Me.ButtonAdv2.TabIndex = 438
        Me.ButtonAdv2.Text = "Cancel"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(117, 42)
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(139, 277)
        Me.btOperacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btOperacion.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(117, 42)
        Me.btOperacion.TabIndex = 437
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(412, 12)
        Me.GradientPanel1.TabIndex = 441
        '
        'txtClasificacion
        '
        Me.txtClasificacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.txtClasificacion.BeforeTouchSize = New System.Drawing.Size(353, 79)
        Me.txtClasificacion.ForeColor = System.Drawing.Color.White
        Me.txtClasificacion.Location = New System.Drawing.Point(27, 37)
        Me.txtClasificacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtClasificacion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtClasificacion.Name = "txtClasificacion"
        Me.txtClasificacion.ReadOnly = True
        Me.txtClasificacion.Size = New System.Drawing.Size(206, 25)
        Me.txtClasificacion.TabIndex = 448
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(23, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 19)
        Me.Label2.TabIndex = 447
        Me.Label2.Text = "Clasificacion"
        '
        'lblidClasificacion
        '
        Me.lblidClasificacion.AutoSize = True
        Me.lblidClasificacion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidClasificacion.ForeColor = System.Drawing.Color.White
        Me.lblidClasificacion.Location = New System.Drawing.Point(240, 44)
        Me.lblidClasificacion.Name = "lblidClasificacion"
        Me.lblidClasificacion.Size = New System.Drawing.Size(17, 19)
        Me.lblidClasificacion.TabIndex = 446
        Me.lblidClasificacion.Text = "0"
        Me.lblidClasificacion.Visible = False
        '
        'chkCodigo
        '
        Me.chkCodigo.AutoSize = True
        Me.chkCodigo.ForeColor = System.Drawing.Color.White
        Me.chkCodigo.Location = New System.Drawing.Point(26, 225)
        Me.chkCodigo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkCodigo.Name = "chkCodigo"
        Me.chkCodigo.Size = New System.Drawing.Size(107, 23)
        Me.chkCodigo.TabIndex = 450
        Me.chkCodigo.Text = "Usar Codigo"
        Me.chkCodigo.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.ForeColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(138, 222)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(241, 25)
        Me.txtCodigo.TabIndex = 449
        Me.txtCodigo.Visible = False
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.White
        Me.lblCodigo.Location = New System.Drawing.Point(210, 82)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(17, 19)
        Me.lblCodigo.TabIndex = 451
        Me.lblCodigo.Text = "0"
        '
        'frmNuevaClasificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(30, 9)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(20, 20)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.Gold
        CaptionLabel1.Location = New System.Drawing.Point(60, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "SubClasificación de existencias."
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(412, 370)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.chkCodigo)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtClasificacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblidClasificacion)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.ButtonAdv2)
        Me.Controls.Add(Me.btOperacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNuevaClasificacion"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClasificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtClasificacion As TextboxJiu
    Friend WithEvents Label2 As Label
    Friend WithEvents lblidClasificacion As Label
    Friend WithEvents chkCodigo As CheckBox
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents lblCodigo As Label
End Class

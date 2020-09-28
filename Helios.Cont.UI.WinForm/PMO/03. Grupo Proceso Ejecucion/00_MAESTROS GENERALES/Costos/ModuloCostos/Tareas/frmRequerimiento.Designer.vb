<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequerimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRequerimiento))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProyecto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtActividad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCategoria = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.txtProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActividad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proyecto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tarea/Actividad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Clasificación recurso"
        '
        'txtProyecto
        '
        Me.txtProyecto.BackColor = System.Drawing.Color.DarkRed
        Me.txtProyecto.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtProyecto.BorderColor = System.Drawing.Color.Silver
        Me.txtProyecto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProyecto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProyecto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProyecto.ForeColor = System.Drawing.Color.White
        Me.txtProyecto.Location = New System.Drawing.Point(32, 49)
        Me.txtProyecto.MaxLength = 20
        Me.txtProyecto.Metrocolor = System.Drawing.Color.Silver
        Me.txtProyecto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProyecto.Name = "txtProyecto"
        Me.txtProyecto.ReadOnly = True
        Me.txtProyecto.Size = New System.Drawing.Size(306, 20)
        Me.txtProyecto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProyecto.TabIndex = 221
        Me.txtProyecto.Text = "Proyecto"
        '
        'txtActividad
        '
        Me.txtActividad.BackColor = System.Drawing.Color.Chocolate
        Me.txtActividad.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtActividad.BorderColor = System.Drawing.Color.Silver
        Me.txtActividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActividad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtActividad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActividad.ForeColor = System.Drawing.Color.White
        Me.txtActividad.Location = New System.Drawing.Point(32, 98)
        Me.txtActividad.MaxLength = 20
        Me.txtActividad.Metrocolor = System.Drawing.Color.Silver
        Me.txtActividad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.Size = New System.Drawing.Size(306, 20)
        Me.txtActividad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtActividad.TabIndex = 222
        Me.txtActividad.Text = "Actividad"
        '
        'txtCategoria
        '
        Me.txtCategoria.BackColor = System.Drawing.Color.White
        Me.txtCategoria.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtCategoria.BorderColor = System.Drawing.Color.LightCoral
        Me.txtCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategoria.CornerRadius = 1
        Me.txtCategoria.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCategoria.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCategoria.Location = New System.Drawing.Point(32, 158)
        Me.txtCategoria.Metrocolor = System.Drawing.Color.LightCoral
        Me.txtCategoria.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtCategoria.Size = New System.Drawing.Size(253, 22)
        Me.txtCategoria.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCategoria.TabIndex = 494
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(286, 159)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 493
        Me.PictureBox2.TabStop = False
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(123, 259)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 495
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 496
        Me.Label4.Text = "Cantidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(186, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 497
        Me.Label5.Text = "Importe"
        '
        'frmRequerimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.MediumSeaGreen
        Me.CaptionBarColor = System.Drawing.Color.MediumSeaGreen
        Me.CaptionBarHeight = 55
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(55, 18)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(180, 24)
        CaptionLabel1.Text = "Asignación de recursos"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(376, 303)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btOperacion)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.txtActividad)
        Me.Controls.Add(Me.txtProyecto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRequerimiento"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActividad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProyecto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtActividad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCategoria As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class

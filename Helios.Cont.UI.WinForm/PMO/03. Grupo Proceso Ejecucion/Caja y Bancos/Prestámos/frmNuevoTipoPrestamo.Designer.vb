<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoTipoPrestamo
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtServicioNew = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtidservicio = New System.Windows.Forms.Label()
        Me.txtTipoPrestamo = New System.Windows.Forms.TextBox()
        CType(Me.txtServicioNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 13)
        Me.Label1.TabIndex = 409
        Me.Label1.Text = "Descripcion tipo prestamo:"
        '
        'txtServicioNew
        '
        Me.txtServicioNew.BackColor = System.Drawing.Color.White
        Me.txtServicioNew.BeforeTouchSize = New System.Drawing.Size(417, 32)
        Me.txtServicioNew.BorderColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtServicioNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtServicioNew.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServicioNew.CornerRadius = 5
        Me.txtServicioNew.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtServicioNew.Location = New System.Drawing.Point(22, 47)
        Me.txtServicioNew.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtServicioNew.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtServicioNew.Multiline = True
        Me.txtServicioNew.Name = "txtServicioNew"
        Me.txtServicioNew.Size = New System.Drawing.Size(417, 32)
        Me.txtServicioNew.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtServicioNew.TabIndex = 408
        Me.txtServicioNew.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(574, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 411
        Me.Label2.Text = "Observaciones"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Visible = False
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.BeforeTouchSize = New System.Drawing.Size(417, 32)
        Me.txtObservaciones.BorderColor = System.Drawing.Color.Silver
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtObservaciones.Location = New System.Drawing.Point(586, 96)
        Me.txtObservaciones.Metrocolor = System.Drawing.Color.Silver
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(405, 61)
        Me.txtObservaciones.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtObservaciones.TabIndex = 410
        Me.txtObservaciones.Text = "tipo de prestamos "
        Me.txtObservaciones.Visible = False
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.White
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(207, 98)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv1.TabIndex = 419
        Me.ButtonAdv1.Text = "Cancel"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(67, 98)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 418
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'txtidservicio
        '
        Me.txtidservicio.AutoSize = True
        Me.txtidservicio.Location = New System.Drawing.Point(423, 184)
        Me.txtidservicio.Name = "txtidservicio"
        Me.txtidservicio.Size = New System.Drawing.Size(40, 13)
        Me.txtidservicio.TabIndex = 420
        Me.txtidservicio.Text = "Label4"
        Me.txtidservicio.Visible = False
        '
        'txtTipoPrestamo
        '
        Me.txtTipoPrestamo.Location = New System.Drawing.Point(206, 13)
        Me.txtTipoPrestamo.Name = "txtTipoPrestamo"
        Me.txtTipoPrestamo.Size = New System.Drawing.Size(100, 22)
        Me.txtTipoPrestamo.TabIndex = 421
        Me.txtTipoPrestamo.Visible = False
        '
        'frmNuevoTipoPrestamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.ClientSize = New System.Drawing.Size(459, 158)
        Me.Controls.Add(Me.txtTipoPrestamo)
        Me.Controls.Add(Me.txtidservicio)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.btOperacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtServicioNew)
        Me.Name = "frmNuevoTipoPrestamo"
        Me.ShowIcon = False
        Me.Text = "Tipo Prestamo"
        CType(Me.txtServicioNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtServicioNew As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtidservicio As System.Windows.Forms.Label
    Friend WithEvents txtTipoPrestamo As System.Windows.Forms.TextBox
End Class

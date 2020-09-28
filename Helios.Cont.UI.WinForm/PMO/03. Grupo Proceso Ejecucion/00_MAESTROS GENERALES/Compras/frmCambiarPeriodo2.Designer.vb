<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiarPeriodo2
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
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambiarPeriodo2))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.txtNuevoPeriodoAnio = New System.Windows.Forms.MaskedTextBox()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtNuevoPeriodoMes = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNuevoPeriodoAnio
        '
        Me.txtNuevoPeriodoAnio.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtNuevoPeriodoAnio.Location = New System.Drawing.Point(173, 97)
        Me.txtNuevoPeriodoAnio.Mask = "0000"
        Me.txtNuevoPeriodoAnio.Name = "txtNuevoPeriodoAnio"
        Me.txtNuevoPeriodoAnio.Size = New System.Drawing.Size(41, 22)
        Me.txtNuevoPeriodoAnio.TabIndex = 9
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(107, 34)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(145, 135)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(107, 34)
        Me.ButtonAdv1.TabIndex = 11
        Me.ButtonAdv1.Text = "Cambiar período"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'txtNuevoPeriodoMes
        '
        Me.txtNuevoPeriodoMes.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtNuevoPeriodoMes.Location = New System.Drawing.Point(145, 97)
        Me.txtNuevoPeriodoMes.Mask = "00"
        Me.txtNuevoPeriodoMes.Name = "txtNuevoPeriodoMes"
        Me.txtNuevoPeriodoMes.Size = New System.Drawing.Size(22, 22)
        Me.txtNuevoPeriodoMes.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(142, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 14)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Período a cambiar"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.Color.White
        Me.txtPeriodo.BeforeTouchSize = New System.Drawing.Size(214, 22)
        Me.txtPeriodo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPeriodo.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.txtPeriodo.Location = New System.Drawing.Point(24, 97)
        Me.txtPeriodo.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.Size = New System.Drawing.Size(110, 22)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPeriodo.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(21, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 14)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Período actual"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.BeforeTouchSize = New System.Drawing.Size(214, 22)
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFecha.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(244, 44)
        Me.txtFecha.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(123, 22)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtFecha.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(241, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 14)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Fecha"
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(214, 22)
        Me.txtNumero.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.txtNumero.Location = New System.Drawing.Point(24, 44)
        Me.txtNumero.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(214, 22)
        Me.txtNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumero.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(21, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Nro. Comprobante"
        '
        'frmCambiarPeriodo2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.HotTrack
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Comprobante"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 22)
        CaptionLabel2.Text = "Cambio Período"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(389, 169)
        Me.Controls.Add(Me.txtNuevoPeriodoAnio)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.txtNuevoPeriodoMes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambiarPeriodo2"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNuevoPeriodoAnio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtNuevoPeriodoMes As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

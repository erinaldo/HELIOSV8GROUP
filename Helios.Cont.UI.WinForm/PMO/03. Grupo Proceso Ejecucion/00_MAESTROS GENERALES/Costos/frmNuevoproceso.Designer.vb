<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoproceso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoproceso))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNuevoCosto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtSubdetalle = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.txtNuevoCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubdetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(22, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 441
        Me.Label3.Text = "Nombre EDT"
        '
        'txtNuevoCosto
        '
        Me.txtNuevoCosto.BackColor = System.Drawing.Color.White
        Me.txtNuevoCosto.BeforeTouchSize = New System.Drawing.Size(274, 22)
        Me.txtNuevoCosto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNuevoCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNuevoCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNuevoCosto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNuevoCosto.Location = New System.Drawing.Point(22, 47)
        Me.txtNuevoCosto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNuevoCosto.Name = "txtNuevoCosto"
        Me.txtNuevoCosto.NearImage = CType(resources.GetObject("txtNuevoCosto.NearImage"), System.Drawing.Image)
        Me.txtNuevoCosto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNuevoCosto.Size = New System.Drawing.Size(274, 22)
        Me.txtNuevoCosto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNuevoCosto.TabIndex = 440
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
        Me.ButtonAdv2.Location = New System.Drawing.Point(194, 200)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.TabIndex = 443
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
        Me.btOperacion.Location = New System.Drawing.Point(79, 200)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 442
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'txtSubdetalle
        '
        Me.txtSubdetalle.BackColor = System.Drawing.Color.White
        Me.txtSubdetalle.BeforeTouchSize = New System.Drawing.Size(274, 22)
        Me.txtSubdetalle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSubdetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubdetalle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSubdetalle.Location = New System.Drawing.Point(22, 106)
        Me.txtSubdetalle.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSubdetalle.Multiline = True
        Me.txtSubdetalle.Name = "txtSubdetalle"
        Me.txtSubdetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSubdetalle.Size = New System.Drawing.Size(274, 74)
        Me.txtSubdetalle.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtSubdetalle.TabIndex = 444
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(22, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 445
        Me.Label6.Text = "Describir EDT"
        '
        'frmNuevoproceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(30, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Administrar EDTs"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(326, 240)
        Me.Controls.Add(Me.txtSubdetalle)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ButtonAdv2)
        Me.Controls.Add(Me.btOperacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNuevoCosto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNuevoproceso"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtNuevoCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubdetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNuevoCosto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtSubdetalle As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class

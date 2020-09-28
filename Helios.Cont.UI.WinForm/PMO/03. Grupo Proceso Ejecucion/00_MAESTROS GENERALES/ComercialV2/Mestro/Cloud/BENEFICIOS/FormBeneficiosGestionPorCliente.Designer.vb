<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBeneficiosGestionPorCliente
    Inherits Syncfusion.Windows.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBeneficiosGestionPorCliente))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextNroDocEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TextNroDocEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextNroDocEntidad)
        Me.GroupBox4.Controls.Add(Me.TextEntidad)
        Me.GroupBox4.Location = New System.Drawing.Point(40, 28)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(471, 68)
        Me.GroupBox4.TabIndex = 228
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del Cliente"
        '
        'TextNroDocEntidad
        '
        Me.TextNroDocEntidad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextNroDocEntidad.BeforeTouchSize = New System.Drawing.Size(335, 22)
        Me.TextNroDocEntidad.BorderColor = System.Drawing.Color.Silver
        Me.TextNroDocEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNroDocEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNroDocEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNroDocEntidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNroDocEntidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNroDocEntidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNroDocEntidad.Location = New System.Drawing.Point(354, 27)
        Me.TextNroDocEntidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextNroDocEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNroDocEntidad.Name = "TextNroDocEntidad"
        Me.TextNroDocEntidad.ReadOnly = True
        Me.TextNroDocEntidad.Size = New System.Drawing.Size(98, 22)
        Me.TextNroDocEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNroDocEntidad.TabIndex = 225
        '
        'TextEntidad
        '
        Me.TextEntidad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextEntidad.BeforeTouchSize = New System.Drawing.Size(335, 22)
        Me.TextEntidad.BorderColor = System.Drawing.Color.Silver
        Me.TextEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextEntidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextEntidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEntidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextEntidad.Location = New System.Drawing.Point(13, 27)
        Me.TextEntidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextEntidad.Name = "TextEntidad"
        Me.TextEntidad.NearImage = CType(resources.GetObject("TextEntidad.NearImage"), System.Drawing.Image)
        Me.TextEntidad.ReadOnly = True
        Me.TextEntidad.Size = New System.Drawing.Size(335, 22)
        Me.TextEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextEntidad.TabIndex = 224
        '
        'FormBeneficiosGestionPorCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 479)
        Me.Controls.Add(Me.GroupBox4)
        Me.MaximizeBox = False
        Me.Name = "FormBeneficiosGestionPorCliente"
        Me.ShowIcon = False
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TextNroDocEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextNroDocEntidad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextEntidad As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class

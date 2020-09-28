Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTipoImpresionEncomienda
    Inherits MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTipoImpresionEncomienda))
        Me.CirclePictureBox1 = New Helios.Cont.Presentation.WinForm.CirclePictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBPendiente = New System.Windows.Forms.RadioButton()
        Me.RBAcumulado = New System.Windows.Forms.RadioButton()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        CType(Me.CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CirclePictureBox1
        '
        Me.CirclePictureBox1.Image = CType(resources.GetObject("CirclePictureBox1.Image"), System.Drawing.Image)
        Me.CirclePictureBox1.Location = New System.Drawing.Point(28, 25)
        Me.CirclePictureBox1.Name = "CirclePictureBox1"
        Me.CirclePictureBox1.Size = New System.Drawing.Size(100, 101)
        Me.CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CirclePictureBox1.TabIndex = 0
        Me.CirclePictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBPendiente)
        Me.GroupBox1.Controls.Add(Me.RBAcumulado)
        Me.GroupBox1.Location = New System.Drawing.Point(150, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(229, 100)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Impresión"
        '
        'RBPendiente
        '
        Me.RBPendiente.AutoSize = True
        Me.RBPendiente.Location = New System.Drawing.Point(23, 59)
        Me.RBPendiente.Name = "RBPendiente"
        Me.RBPendiente.Size = New System.Drawing.Size(135, 17)
        Me.RBPendiente.TabIndex = 1
        Me.RBPendiente.Text = "Elemento seleccionado"
        Me.RBPendiente.UseVisualStyleBackColor = True
        '
        'RBAcumulado
        '
        Me.RBAcumulado.AutoSize = True
        Me.RBAcumulado.Checked = True
        Me.RBAcumulado.Location = New System.Drawing.Point(23, 36)
        Me.RBAcumulado.Name = "RBAcumulado"
        Me.RBAcumulado.Size = New System.Drawing.Size(114, 17)
        Me.RBAcumulado.TabIndex = 0
        Me.RBAcumulado.TabStop = True
        Me.RBAcumulado.Text = "Acumulado del día"
        Me.RBAcumulado.UseVisualStyleBackColor = True
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(137, 33)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.Image = CType(resources.GetObject("RoundButton21.Image"), System.Drawing.Image)
        Me.RoundButton21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(242, 136)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(137, 33)
        Me.RoundButton21.TabIndex = 2
        Me.RoundButton21.Text = "Imprimir"
        Me.RoundButton21.UseVisualStyle = True
        '
        'FormTipoImpresionEncomienda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 2
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(403, 179)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CirclePictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormTipoImpresionEncomienda"
        Me.ShowIcon = False
        Me.Text = "Imprimir reporte"
        CType(Me.CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CirclePictureBox1 As CirclePictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RBPendiente As RadioButton
    Friend WithEvents RBAcumulado As RadioButton
    Friend WithEvents RoundButton21 As RoundButton2
End Class

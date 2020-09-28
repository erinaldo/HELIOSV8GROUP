Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUbigeo
    Inherits MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUbigeo))
        Me.cbProvincia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cbDepartamento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cbDis = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardarUbig = New System.Windows.Forms.ToolStripButton()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        CType(Me.cbProvincia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbProvincia
        '
        Me.cbProvincia.BackColor = System.Drawing.Color.White
        Me.cbProvincia.BeforeTouchSize = New System.Drawing.Size(155, 21)
        Me.cbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProvincia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProvincia.Location = New System.Drawing.Point(93, 39)
        Me.cbProvincia.MetroBorderColor = System.Drawing.SystemColors.HotTrack
        Me.cbProvincia.Name = "cbProvincia"
        Me.cbProvincia.Size = New System.Drawing.Size(155, 21)
        Me.cbProvincia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbProvincia.TabIndex = 779
        '
        'cbDepartamento
        '
        Me.cbDepartamento.BackColor = System.Drawing.Color.White
        Me.cbDepartamento.BeforeTouchSize = New System.Drawing.Size(155, 21)
        Me.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartamento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDepartamento.Location = New System.Drawing.Point(93, 16)
        Me.cbDepartamento.MetroBorderColor = System.Drawing.SystemColors.HotTrack
        Me.cbDepartamento.Name = "cbDepartamento"
        Me.cbDepartamento.Size = New System.Drawing.Size(155, 21)
        Me.cbDepartamento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbDepartamento.TabIndex = 780
        '
        'cbDis
        '
        Me.cbDis.BackColor = System.Drawing.Color.White
        Me.cbDis.BeforeTouchSize = New System.Drawing.Size(155, 21)
        Me.cbDis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDis.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDis.Location = New System.Drawing.Point(93, 62)
        Me.cbDis.MetroBorderColor = System.Drawing.SystemColors.HotTrack
        Me.cbDis.Name = "cbDis"
        Me.cbDis.Size = New System.Drawing.Size(155, 21)
        Me.cbDis.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbDis.TabIndex = 778
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(8, 22)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(82, 13)
        Me.Label31.TabIndex = 777
        Me.Label31.Text = "Departamento"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(8, 66)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(45, 13)
        Me.Label32.TabIndex = 776
        Me.Label32.Text = "Distrito"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(8, 46)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 13)
        Me.Label30.TabIndex = 775
        Me.Label30.Text = "Provincia"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardarUbig})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(295, 42)
        Me.ToolStrip1.TabIndex = 781
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardarUbig
        '
        Me.btnGuardarUbig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardarUbig.Image = CType(resources.GetObject("btnGuardarUbig.Image"), System.Drawing.Image)
        Me.btnGuardarUbig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarUbig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardarUbig.Name = "btnGuardarUbig"
        Me.btnGuardarUbig.Size = New System.Drawing.Size(39, 39)
        Me.btnGuardarUbig.Text = "ToolStripButton1"
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.cbDepartamento)
        Me.GradientPanel4.Controls.Add(Me.Label30)
        Me.GradientPanel4.Controls.Add(Me.cbProvincia)
        Me.GradientPanel4.Controls.Add(Me.Label32)
        Me.GradientPanel4.Controls.Add(Me.Label31)
        Me.GradientPanel4.Controls.Add(Me.cbDis)
        Me.GradientPanel4.Location = New System.Drawing.Point(12, 55)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(264, 95)
        Me.GradientPanel4.TabIndex = 782
        '
        'FormUbigeo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.Teal
        Me.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(295, 158)
        Me.Controls.Add(Me.GradientPanel4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "FormUbigeo"
        Me.ShowIcon = False
        Me.Text = "UBIGEO"
        CType(Me.cbProvincia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.GradientPanel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbProvincia As Tools.ComboBoxAdv
    Friend WithEvents cbDepartamento As Tools.ComboBoxAdv
    Friend WithEvents cbDis As Tools.ComboBoxAdv
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardarUbig As ToolStripButton
    Friend WithEvents GradientPanel4 As Tools.GradientPanel
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditarCargo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarCargo))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.cboCargos = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.lblidusuario = New System.Windows.Forms.Label()
        CType(Me.cboCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCargos
        '
        Me.cboCargos.BackColor = System.Drawing.Color.White
        Me.cboCargos.BeforeTouchSize = New System.Drawing.Size(201, 21)
        Me.cboCargos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCargos.FlatBorderColor = System.Drawing.Color.OrangeRed
        Me.cboCargos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCargos.Location = New System.Drawing.Point(26, 37)
        Me.cboCargos.MetroBorderColor = System.Drawing.Color.YellowGreen
        Me.cboCargos.MetroColor = System.Drawing.Color.YellowGreen
        Me.cboCargos.Name = "cboCargos"
        Me.cboCargos.Size = New System.Drawing.Size(201, 21)
        Me.cboCargos.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCargos.TabIndex = 508
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(23, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 14)
        Me.Label11.TabIndex = 509
        Me.Label11.Text = "Cargos"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel1.Location = New System.Drawing.Point(143, 78)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(105, 24)
        Me.GradientPanel1.TabIndex = 511
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.White
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(103, 22)
        Me.ButtonAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv1.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(103, 22)
        Me.ButtonAdv1.TabIndex = 0
        Me.ButtonAdv1.Text = "Cancelar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'GradientPanel7
        '
        Me.GradientPanel7.BorderColor = System.Drawing.Color.OrangeRed
        Me.GradientPanel7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel7.Controls.Add(Me.ButtonAdv6)
        Me.GradientPanel7.Location = New System.Drawing.Point(27, 78)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(108, 24)
        Me.GradientPanel7.TabIndex = 510
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(108, 24)
        Me.ButtonAdv6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv6.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(108, 24)
        Me.ButtonAdv6.TabIndex = 0
        Me.ButtonAdv6.Text = "     Grabar"
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'lblidusuario
        '
        Me.lblidusuario.AutoSize = True
        Me.lblidusuario.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidusuario.Location = New System.Drawing.Point(186, 16)
        Me.lblidusuario.Name = "lblidusuario"
        Me.lblidusuario.Size = New System.Drawing.Size(13, 14)
        Me.lblidusuario.TabIndex = 512
        Me.lblidusuario.Text = "0"
        Me.lblidusuario.Visible = False
        '
        'frmEditarCargo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.Tomato
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(400, 24)
        CaptionLabel1.Text = "Asignar Cargo"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(263, 115)
        Me.Controls.Add(Me.lblidusuario)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel7)
        Me.Controls.Add(Me.cboCargos)
        Me.Controls.Add(Me.Label11)
        Me.Name = "frmEditarCargo"
        Me.ShowIcon = False
        CType(Me.cboCargos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboCargos As Tools.ComboBoxAdv
    Friend WithEvents Label11 As Label
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As ButtonAdv
    Friend WithEvents GradientPanel7 As Tools.GradientPanel
    Friend WithEvents ButtonAdv6 As ButtonAdv
    Friend WithEvents lblidusuario As Label
End Class

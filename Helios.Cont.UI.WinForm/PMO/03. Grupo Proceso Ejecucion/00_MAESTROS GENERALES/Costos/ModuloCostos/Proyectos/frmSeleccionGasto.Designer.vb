<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionGasto
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
        Me.cboGastoPadre = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboGastohijo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel20 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        CType(Me.cboGastoPadre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboGastohijo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel20, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboGastoPadre
        '
        Me.cboGastoPadre.BackColor = System.Drawing.Color.White
        Me.cboGastoPadre.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboGastoPadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGastoPadre.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGastoPadre.Location = New System.Drawing.Point(32, 49)
        Me.cboGastoPadre.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboGastoPadre.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboGastoPadre.Name = "cboGastoPadre"
        Me.cboGastoPadre.Size = New System.Drawing.Size(294, 21)
        Me.cboGastoPadre.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboGastoPadre.TabIndex = 509
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(29, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
        Me.Label5.TabIndex = 508
        Me.Label5.Text = "Gasto Padre"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.OrangeRed
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(119, 37)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(124, 148)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(119, 37)
        Me.ButtonAdv1.TabIndex = 510
        Me.ButtonAdv1.Text = "Aceptar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'cboGastohijo
        '
        Me.cboGastohijo.BackColor = System.Drawing.Color.White
        Me.cboGastohijo.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboGastohijo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGastohijo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGastohijo.Location = New System.Drawing.Point(32, 101)
        Me.cboGastohijo.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboGastohijo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboGastohijo.Name = "cboGastohijo"
        Me.cboGastohijo.Size = New System.Drawing.Size(294, 21)
        Me.cboGastohijo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboGastohijo.TabIndex = 512
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(29, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 14)
        Me.Label1.TabIndex = 511
        Me.Label1.Text = "Gasto especifico"
        '
        'GradientPanel20
        '
        Me.GradientPanel20.BackColor = System.Drawing.Color.White
        Me.GradientPanel20.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel20.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel20.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel20.Name = "GradientPanel20"
        Me.GradientPanel20.Size = New System.Drawing.Size(370, 10)
        Me.GradientPanel20.TabIndex = 513
        '
        'frmSeleccionGasto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        Me.ClientSize = New System.Drawing.Size(370, 203)
        Me.Controls.Add(Me.GradientPanel20)
        Me.Controls.Add(Me.cboGastohijo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.cboGastoPadre)
        Me.Controls.Add(Me.Label5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionGasto"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.cboGastoPadre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboGastohijo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel20, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboGastoPadre As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboGastohijo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel20 As Syncfusion.Windows.Forms.Tools.GradientPanel
End Class

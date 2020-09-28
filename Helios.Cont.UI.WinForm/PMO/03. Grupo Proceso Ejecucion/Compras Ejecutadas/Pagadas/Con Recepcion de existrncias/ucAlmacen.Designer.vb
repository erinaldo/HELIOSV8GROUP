<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAlmacen
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.components = New System.ComponentModel.Container()
        Me.AutoLabel1 = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEstable = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboAlmacen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.cboEstable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AutoLabel1
        '
        Me.AutoLabel1.AutoSize = False
        Me.AutoLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.AutoLabel1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_cesta_rojo
        Me.AutoLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AutoLabel1.Location = New System.Drawing.Point(27, 16)
        Me.AutoLabel1.Name = "AutoLabel1"
        Me.AutoLabel1.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Custom
        Me.AutoLabel1.Size = New System.Drawing.Size(180, 27)
        Me.AutoLabel1.TabIndex = 1
        Me.AutoLabel1.Text = "Configuración Almacén"
        Me.AutoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(140, 24)
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(144, 134)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(140, 24)
        Me.ButtonAdv2.TabIndex = 3
        Me.ButtonAdv2.Text = "Seleccionar (clic)"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Establecimiento:"
        '
        'cboEstable
        '
        Me.cboEstable.BackColor = System.Drawing.Color.White
        Me.cboEstable.BeforeTouchSize = New System.Drawing.Size(268, 21)
        Me.cboEstable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstable.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstable.Location = New System.Drawing.Point(16, 65)
        Me.cboEstable.Name = "cboEstable"
        Me.cboEstable.Size = New System.Drawing.Size(268, 21)
        Me.cboEstable.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEstable.TabIndex = 213
        '
        'cboAlmacen
        '
        Me.cboAlmacen.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.BeforeTouchSize = New System.Drawing.Size(268, 21)
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.Location = New System.Drawing.Point(16, 107)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(268, 21)
        Me.cboAlmacen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAlmacen.TabIndex = 215
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(13, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 214
        Me.Label2.Text = "Seleccione almacén:"
        '
        'ucAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.cboAlmacen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboEstable)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonAdv2)
        Me.Controls.Add(Me.AutoLabel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucAlmacen"
        Me.Size = New System.Drawing.Size(295, 161)
        CType(Me.cboEstable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AutoLabel1 As Syncfusion.Windows.Forms.Tools.AutoLabel
    Private WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEstable As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboAlmacen As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class

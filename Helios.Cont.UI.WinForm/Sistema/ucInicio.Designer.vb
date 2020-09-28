<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucInicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucInicio))
        Me.AutoLabel1 = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEstablecimiento = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtAnio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.txtEstablecimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AutoLabel1
        '
        Me.AutoLabel1.AutoSize = False
        Me.AutoLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.AutoLabel1.Image = CType(resources.GetObject("AutoLabel1.Image"), System.Drawing.Image)
        Me.AutoLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AutoLabel1.Location = New System.Drawing.Point(21, 15)
        Me.AutoLabel1.Name = "AutoLabel1"
        Me.AutoLabel1.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Custom
        Me.AutoLabel1.Size = New System.Drawing.Size(180, 27)
        Me.AutoLabel1.TabIndex = 2
        Me.AutoLabel1.Text = "Configuración de Inicio"
        Me.AutoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(14, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Establecimiento predeterminado:"
        '
        'txtEstablecimiento
        '
        Me.txtEstablecimiento.BackColor = System.Drawing.Color.White
        Me.txtEstablecimiento.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtEstablecimiento.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.txtEstablecimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstablecimiento.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEstablecimiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.txtEstablecimiento.Location = New System.Drawing.Point(17, 72)
        Me.txtEstablecimiento.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.txtEstablecimiento.Name = "txtEstablecimiento"
        Me.txtEstablecimiento.ReadOnly = True
        Me.txtEstablecimiento.Size = New System.Drawing.Size(305, 20)
        Me.txtEstablecimiento.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtEstablecimiento.TabIndex = 33
        '
        'txtAnio
        '
        Me.txtAnio.BackColor = System.Drawing.Color.White
        Me.txtAnio.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtAnio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.txtAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.txtAnio.Location = New System.Drawing.Point(17, 118)
        Me.txtAnio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.ReadOnly = True
        Me.txtAnio.Size = New System.Drawing.Size(76, 20)
        Me.txtAnio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtAnio.TabIndex = 35
        Me.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(14, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Período Laboral:"
        '
        'ucInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.txtAnio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEstablecimiento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AutoLabel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucInicio"
        Me.Size = New System.Drawing.Size(333, 149)
        CType(Me.txtEstablecimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AutoLabel1 As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEstablecimiento As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtAnio As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormInformacionTransporte
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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtPlacaRemolque = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtBrevete = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCertificado = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNombreConductor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtPlacaVehiculo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtMarcaVehiculo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtTipoVehiculo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        CType(Me.txtPlacaRemolque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBrevete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCertificado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlacaVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarcaVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(300, 240)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(59, 22)
        Me.Button3.TabIndex = 540
        Me.Button3.Text = "&Cerrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(238, 240)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 22)
        Me.Button2.TabIndex = 539
        Me.Button2.Text = "&Aceptar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtPlacaRemolque
        '
        Me.txtPlacaRemolque.BackColor = System.Drawing.Color.White
        Me.txtPlacaRemolque.BeforeTouchSize = New System.Drawing.Size(51, 22)
        Me.txtPlacaRemolque.BorderColor = System.Drawing.Color.Silver
        Me.txtPlacaRemolque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlacaRemolque.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlacaRemolque.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacaRemolque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPlacaRemolque.Location = New System.Drawing.Point(119, 108)
        Me.txtPlacaRemolque.MaxLength = 10
        Me.txtPlacaRemolque.Metrocolor = System.Drawing.Color.Silver
        Me.txtPlacaRemolque.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtPlacaRemolque.Name = "txtPlacaRemolque"
        Me.txtPlacaRemolque.Size = New System.Drawing.Size(240, 20)
        Me.txtPlacaRemolque.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPlacaRemolque.TabIndex = 538
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(15, 112)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(92, 12)
        Me.Label19.TabIndex = 537
        Me.Label19.Text = "PLACA REMOLQUE:"
        '
        'txtBrevete
        '
        Me.txtBrevete.BackColor = System.Drawing.Color.White
        Me.txtBrevete.BeforeTouchSize = New System.Drawing.Size(51, 22)
        Me.txtBrevete.BorderColor = System.Drawing.Color.Silver
        Me.txtBrevete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrevete.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBrevete.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrevete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBrevete.Location = New System.Drawing.Point(119, 157)
        Me.txtBrevete.MaxLength = 10
        Me.txtBrevete.Metrocolor = System.Drawing.Color.Silver
        Me.txtBrevete.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBrevete.Name = "txtBrevete"
        Me.txtBrevete.Size = New System.Drawing.Size(80, 20)
        Me.txtBrevete.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtBrevete.TabIndex = 536
        '
        'txtCertificado
        '
        Me.txtCertificado.BackColor = System.Drawing.Color.White
        Me.txtCertificado.BeforeTouchSize = New System.Drawing.Size(51, 22)
        Me.txtCertificado.BorderColor = System.Drawing.Color.Silver
        Me.txtCertificado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCertificado.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCertificado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertificado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCertificado.Location = New System.Drawing.Point(119, 201)
        Me.txtCertificado.MaxLength = 10
        Me.txtCertificado.Metrocolor = System.Drawing.Color.Silver
        Me.txtCertificado.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCertificado.Name = "txtCertificado"
        Me.txtCertificado.Size = New System.Drawing.Size(181, 20)
        Me.txtCertificado.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCertificado.TabIndex = 535
        '
        'txtNombreConductor
        '
        Me.txtNombreConductor.BackColor = System.Drawing.Color.White
        Me.txtNombreConductor.BeforeTouchSize = New System.Drawing.Size(51, 22)
        Me.txtNombreConductor.BorderColor = System.Drawing.Color.Silver
        Me.txtNombreConductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreConductor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNombreConductor.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreConductor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNombreConductor.Location = New System.Drawing.Point(119, 134)
        Me.txtNombreConductor.MaxLength = 10
        Me.txtNombreConductor.Metrocolor = System.Drawing.Color.Silver
        Me.txtNombreConductor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNombreConductor.Name = "txtNombreConductor"
        Me.txtNombreConductor.ReadOnly = True
        Me.txtNombreConductor.Size = New System.Drawing.Size(240, 20)
        Me.txtNombreConductor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNombreConductor.TabIndex = 534
        '
        'txtPlacaVehiculo
        '
        Me.txtPlacaVehiculo.BackColor = System.Drawing.Color.White
        Me.txtPlacaVehiculo.BeforeTouchSize = New System.Drawing.Size(51, 22)
        Me.txtPlacaVehiculo.BorderColor = System.Drawing.Color.Silver
        Me.txtPlacaVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlacaVehiculo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlacaVehiculo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacaVehiculo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPlacaVehiculo.Location = New System.Drawing.Point(119, 56)
        Me.txtPlacaVehiculo.MaxLength = 10
        Me.txtPlacaVehiculo.Metrocolor = System.Drawing.Color.Silver
        Me.txtPlacaVehiculo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtPlacaVehiculo.Name = "txtPlacaVehiculo"
        Me.txtPlacaVehiculo.Size = New System.Drawing.Size(80, 20)
        Me.txtPlacaVehiculo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPlacaVehiculo.TabIndex = 533
        '
        'txtMarcaVehiculo
        '
        Me.txtMarcaVehiculo.BackColor = System.Drawing.Color.White
        Me.txtMarcaVehiculo.BeforeTouchSize = New System.Drawing.Size(51, 22)
        Me.txtMarcaVehiculo.BorderColor = System.Drawing.Color.Silver
        Me.txtMarcaVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarcaVehiculo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMarcaVehiculo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarcaVehiculo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMarcaVehiculo.Location = New System.Drawing.Point(119, 82)
        Me.txtMarcaVehiculo.MaxLength = 10
        Me.txtMarcaVehiculo.Metrocolor = System.Drawing.Color.Silver
        Me.txtMarcaVehiculo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMarcaVehiculo.Name = "txtMarcaVehiculo"
        Me.txtMarcaVehiculo.Size = New System.Drawing.Size(103, 20)
        Me.txtMarcaVehiculo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtMarcaVehiculo.TabIndex = 532
        '
        'txtTipoVehiculo
        '
        Me.txtTipoVehiculo.BackColor = System.Drawing.Color.White
        Me.txtTipoVehiculo.BeforeTouchSize = New System.Drawing.Size(51, 22)
        Me.txtTipoVehiculo.BorderColor = System.Drawing.Color.Silver
        Me.txtTipoVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoVehiculo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoVehiculo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoVehiculo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoVehiculo.Location = New System.Drawing.Point(119, 32)
        Me.txtTipoVehiculo.MaxLength = 10
        Me.txtTipoVehiculo.Metrocolor = System.Drawing.Color.Silver
        Me.txtTipoVehiculo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoVehiculo.Name = "txtTipoVehiculo"
        Me.txtTipoVehiculo.Size = New System.Drawing.Size(80, 20)
        Me.txtTipoVehiculo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoVehiculo.TabIndex = 531
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(66, 138)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 12)
        Me.Label14.TabIndex = 530
        Me.Label14.Text = "NOMBRE:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(50, 165)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(59, 12)
        Me.Label23.TabIndex = 529
        Me.Label23.Text = "N° BREVETE:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(116, 184)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(145, 12)
        Me.Label24.TabIndex = 528
        Me.Label24.Text = "CERTIFICADO DE INSCRIPCION:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(77, 63)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(36, 12)
        Me.Label25.TabIndex = 527
        Me.Label25.Text = "PLACA:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(68, 86)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(45, 12)
        Me.Label26.TabIndex = 526
        Me.Label26.Text = "MARCA:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(33, 42)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(79, 12)
        Me.Label34.TabIndex = 525
        Me.Label34.Text = "TIPO VEHICULO:"
        '
        'FormInformacionTransporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 284)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtPlacaRemolque)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtBrevete)
        Me.Controls.Add(Me.txtCertificado)
        Me.Controls.Add(Me.txtNombreConductor)
        Me.Controls.Add(Me.txtPlacaVehiculo)
        Me.Controls.Add(Me.txtMarcaVehiculo)
        Me.Controls.Add(Me.txtTipoVehiculo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label34)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormInformacionTransporte"
        CType(Me.txtPlacaRemolque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBrevete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCertificado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreConductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlacaVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarcaVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents txtPlacaRemolque As Tools.TextBoxExt
    Friend WithEvents Label19 As Label
    Friend WithEvents txtBrevete As Tools.TextBoxExt
    Friend WithEvents txtCertificado As Tools.TextBoxExt
    Friend WithEvents txtNombreConductor As Tools.TextBoxExt
    Friend WithEvents txtPlacaVehiculo As Tools.TextBoxExt
    Friend WithEvents txtMarcaVehiculo As Tools.TextBoxExt
    Friend WithEvents txtTipoVehiculo As Tools.TextBoxExt
    Friend WithEvents Label14 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label34 As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormNuevoReserva
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNuevoReserva))
        Me.pnBuscardor = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnReserva = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.cboRutas = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEdad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.pnBuscardor.SuspendLayout()
        CType(Me.cboRutas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEdad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnBuscardor
        '
        Me.pnBuscardor.BackColor = System.Drawing.Color.White
        Me.pnBuscardor.Controls.Add(Me.ListView1)
        Me.pnBuscardor.Controls.Add(Me.Label1)
        Me.pnBuscardor.Controls.Add(Me.btnReserva)
        Me.pnBuscardor.Controls.Add(Me.cboRutas)
        Me.pnBuscardor.Controls.Add(Me.Label14)
        Me.pnBuscardor.Controls.Add(Me.txtEdad)
        Me.pnBuscardor.Controls.Add(Me.Label5)
        Me.pnBuscardor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBuscardor.Location = New System.Drawing.Point(0, 0)
        Me.pnBuscardor.Name = "pnBuscardor"
        Me.pnBuscardor.Size = New System.Drawing.Size(346, 450)
        Me.pnBuscardor.TabIndex = 692
        Me.pnBuscardor.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(25, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 19)
        Me.Label1.TabIndex = 697
        Me.Label1.Text = "Imagen"
        '
        'btnReserva
        '
        Me.btnReserva.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnReserva.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnReserva.BeforeTouchSize = New System.Drawing.Size(273, 32)
        Me.btnReserva.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.btnReserva.ForeColor = System.Drawing.Color.White
        Me.btnReserva.IsBackStageButton = False
        Me.btnReserva.Location = New System.Drawing.Point(24, 406)
        Me.btnReserva.Name = "btnReserva"
        Me.btnReserva.Size = New System.Drawing.Size(273, 32)
        Me.btnReserva.TabIndex = 696
        Me.btnReserva.Text = "Agregar"
        Me.btnReserva.UseVisualStyle = True
        Me.btnReserva.Visible = False
        '
        'cboRutas
        '
        Me.cboRutas.BackColor = System.Drawing.Color.White
        Me.cboRutas.BeforeTouchSize = New System.Drawing.Size(273, 27)
        Me.cboRutas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRutas.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.cboRutas.Location = New System.Drawing.Point(29, 47)
        Me.cboRutas.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboRutas.Name = "cboRutas"
        Me.cboRutas.Size = New System.Drawing.Size(273, 27)
        Me.cboRutas.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboRutas.TabIndex = 692
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(25, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 19)
        Me.Label14.TabIndex = 691
        Me.Label14.Text = "Agencia"
        '
        'txtEdad
        '
        Me.txtEdad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtEdad.BeforeTouchSize = New System.Drawing.Size(212, 27)
        Me.txtEdad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEdad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEdad.CornerRadius = 3
        Me.txtEdad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtEdad.Font = New System.Drawing.Font("Calibri Light", 12.0!)
        Me.txtEdad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEdad.Location = New System.Drawing.Point(24, 114)
        Me.txtEdad.MaxLength = 8
        Me.txtEdad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtEdad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.NearImage = CType(resources.GetObject("txtEdad.NearImage"), System.Drawing.Image)
        Me.txtEdad.Size = New System.Drawing.Size(212, 27)
        Me.txtEdad.TabIndex = 690
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(26, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(210, 14)
        Me.Label5.TabIndex = 689
        Me.Label5.Text = "Descipción (Maximo 3 caracteres)"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "RESERVADO.png")
        Me.ImageList1.Images.SetKeyName(1, "reservado1.png")
        Me.ImageList1.Images.SetKeyName(2, "reservado2.png")
        Me.ImageList1.Images.SetKeyName(3, "reservado4.png")
        Me.ImageList1.Images.SetKeyName(4, "reservado7.png")
        Me.ImageList1.Images.SetKeyName(5, "reservado9.png")
        Me.ImageList1.Images.SetKeyName(6, "reservado10.png")
        Me.ImageList1.Images.SetKeyName(7, "reservado13.png")
        Me.ImageList1.Images.SetKeyName(8, "reservado14.png")
        Me.ImageList1.Images.SetKeyName(9, "reservado15.png")
        Me.ImageList1.Images.SetKeyName(10, "reservado16.png")
        Me.ImageList1.Images.SetKeyName(11, "reservado17.png")
        Me.ImageList1.Images.SetKeyName(12, "reservado18.png")
        Me.ImageList1.Images.SetKeyName(13, "reservado20.png")
        Me.ImageList1.Images.SetKeyName(14, "reservado21.png")
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(29, 175)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(273, 225)
        Me.ListView1.TabIndex = 698
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'FormNuevoReserva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 450)
        Me.Controls.Add(Me.pnBuscardor)
        Me.Name = "FormNuevoReserva"
        Me.Text = "Configurar Reserva"
        Me.pnBuscardor.ResumeLayout(False)
        Me.pnBuscardor.PerformLayout()
        CType(Me.cboRutas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEdad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnBuscardor As Panel
    Friend WithEvents txtEdad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents cboRutas As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label14 As Label
    Friend WithEvents btnReserva As RoundButton2
    Friend WithEvents Label1 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ListView1 As ListView
End Class

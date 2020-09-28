<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaFE
    Inherits frmMaster

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
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.cboTickets = New System.Windows.Forms.ComboBox()
        Me.txtCodigoRespuesta = New System.Windows.Forms.TextBox()
        Me.txtRespuesta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnvalidar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnReenviar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(279, 86)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Consultar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(29, 280)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(174, 22)
        Me.txtNumero.TabIndex = 1
        '
        'cboTickets
        '
        Me.cboTickets.FormattingEnabled = True
        Me.cboTickets.Location = New System.Drawing.Point(30, 86)
        Me.cboTickets.Name = "cboTickets"
        Me.cboTickets.Size = New System.Drawing.Size(236, 21)
        Me.cboTickets.TabIndex = 19
        '
        'txtCodigoRespuesta
        '
        Me.txtCodigoRespuesta.Location = New System.Drawing.Point(30, 142)
        Me.txtCodigoRespuesta.Name = "txtCodigoRespuesta"
        Me.txtCodigoRespuesta.Size = New System.Drawing.Size(135, 22)
        Me.txtCodigoRespuesta.TabIndex = 20
        '
        'txtRespuesta
        '
        Me.txtRespuesta.Location = New System.Drawing.Point(30, 190)
        Me.txtRespuesta.Name = "txtRespuesta"
        Me.txtRespuesta.Size = New System.Drawing.Size(236, 22)
        Me.txtRespuesta.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Estado:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Mensaje:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Tickets Sin Validar"
        '
        'btnvalidar
        '
        Me.btnvalidar.BackColor = System.Drawing.Color.Brown
        Me.btnvalidar.BeforeTouchSize = New System.Drawing.Size(93, 34)
        Me.btnvalidar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnvalidar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnvalidar.IsBackStageButton = False
        Me.btnvalidar.Location = New System.Drawing.Point(29, 228)
        Me.btnvalidar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnvalidar.Name = "btnvalidar"
        Me.btnvalidar.Size = New System.Drawing.Size(93, 34)
        Me.btnvalidar.TabIndex = 25
        Me.btnvalidar.Text = "Validar"
        Me.btnvalidar.Visible = False
        '
        'btnReenviar
        '
        Me.btnReenviar.BackColor = System.Drawing.Color.Red
        Me.btnReenviar.BeforeTouchSize = New System.Drawing.Size(93, 34)
        Me.btnReenviar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReenviar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnReenviar.IsBackStageButton = False
        Me.btnReenviar.Location = New System.Drawing.Point(139, 228)
        Me.btnReenviar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnReenviar.Name = "btnReenviar"
        Me.btnReenviar.Size = New System.Drawing.Size(93, 34)
        Me.btnReenviar.TabIndex = 26
        Me.btnReenviar.Text = "Reenviar"
        Me.btnReenviar.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Tipo de Ticket"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"FACTURAS ANULADAS", "RESUMEN DE BOLETAS", "RESUMEN DE NOTAS CREDITO BOLETAS", "RESUMEN BOLETAS ANULADAS"})
        Me.ComboBox1.Location = New System.Drawing.Point(30, 32)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(236, 21)
        Me.ComboBox1.TabIndex = 28
        Me.ComboBox1.Text = "RESUMEN DE BOLETAS"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(279, 32)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 29
        Me.Button2.Text = "Buscar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmConsultaFE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(372, 276)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnReenviar)
        Me.Controls.Add(Me.btnvalidar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRespuesta)
        Me.Controls.Add(Me.txtCodigoRespuesta)
        Me.Controls.Add(Me.cboTickets)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmConsultaFE"
        Me.ShowIcon = False
        Me.Text = ""
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents cboTickets As ComboBox
    Friend WithEvents txtCodigoRespuesta As TextBox
    Friend WithEvents txtRespuesta As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnvalidar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnReenviar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button2 As Button
End Class

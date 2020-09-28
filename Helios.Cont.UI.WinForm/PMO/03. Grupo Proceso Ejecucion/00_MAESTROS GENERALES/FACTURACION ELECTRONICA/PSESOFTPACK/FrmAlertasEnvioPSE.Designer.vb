<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAlertasEnvioPSE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAlertasEnvioPSE))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.bg = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.lblnotaboletas = New System.Windows.Forms.LinkLabel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblboletaspendientes = New System.Windows.Forms.LinkLabel()
        Me.LBLBOLETASELIMINADAS = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblFacturasAnuladas = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFacturasPendientes = New System.Windows.Forms.LinkLabel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblNotasPendiente = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel5)
        Me.GroupBox2.Controls.Add(Me.Panel4)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.lblnotaboletas)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblboletaspendientes)
        Me.GroupBox2.Controls.Add(Me.LBLBOLETASELIMINADAS)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 165)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(777, 167)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "BOLETAS ELECTRONICAS"
        '
        'Panel5
        '
        Me.Panel5.BackgroundImage = CType(resources.GetObject("Panel5.BackgroundImage"), System.Drawing.Image)
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel5.Location = New System.Drawing.Point(447, 21)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(28, 28)
        Me.Panel5.TabIndex = 431
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel4.Location = New System.Drawing.Point(710, 21)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(28, 28)
        Me.Panel4.TabIndex = 430
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel3.Location = New System.Drawing.Point(149, 21)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(28, 28)
        Me.Panel3.TabIndex = 429
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(66, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "BOLETAS "
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.SteelBlue
        Me.Button6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button6.Location = New System.Drawing.Point(539, 83)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(156, 53)
        Me.Button6.TabIndex = 20
        Me.Button6.Text = "ENVIAR NOTAS DE CREDITO"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'lblnotaboletas
        '
        Me.lblnotaboletas.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblnotaboletas.AutoSize = True
        Me.lblnotaboletas.LinkColor = System.Drawing.Color.Red
        Me.lblnotaboletas.Location = New System.Drawing.Point(607, 56)
        Me.lblnotaboletas.Name = "lblnotaboletas"
        Me.lblnotaboletas.Size = New System.Drawing.Size(13, 13)
        Me.lblnotaboletas.TabIndex = 19
        Me.lblnotaboletas.TabStop = True
        Me.lblnotaboletas.Text = "0"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.SteelBlue
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button2.Location = New System.Drawing.Point(19, 83)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(156, 53)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "ENVIAR RESUMEN DE BOLETAS"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(564, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "NOTAS DE CREDITO"
        '
        'lblboletaspendientes
        '
        Me.lblboletaspendientes.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblboletaspendientes.AutoSize = True
        Me.lblboletaspendientes.LinkColor = System.Drawing.Color.Red
        Me.lblboletaspendientes.Location = New System.Drawing.Point(88, 56)
        Me.lblboletaspendientes.Name = "lblboletaspendientes"
        Me.lblboletaspendientes.Size = New System.Drawing.Size(13, 13)
        Me.lblboletaspendientes.TabIndex = 11
        Me.lblboletaspendientes.TabStop = True
        Me.lblboletaspendientes.Text = "0"
        '
        'LBLBOLETASELIMINADAS
        '
        Me.LBLBOLETASELIMINADAS.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.LBLBOLETASELIMINADAS.AutoSize = True
        Me.LBLBOLETASELIMINADAS.LinkColor = System.Drawing.Color.Red
        Me.LBLBOLETASELIMINADAS.Location = New System.Drawing.Point(339, 56)
        Me.LBLBOLETASELIMINADAS.Name = "LBLBOLETASELIMINADAS"
        Me.LBLBOLETASELIMINADAS.Size = New System.Drawing.Size(13, 13)
        Me.LBLBOLETASELIMINADAS.TabIndex = 15
        Me.LBLBOLETASELIMINADAS.TabStop = True
        Me.LBLBOLETASELIMINADAS.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(296, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "BOLETAS ANULADAS"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.SteelBlue
        Me.Button5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button5.Location = New System.Drawing.Point(271, 83)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(156, 53)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "ENVIAR BOLETAS ANULADAS"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Panel22)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.lblFacturasAnuladas)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblFacturasPendientes)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.lblNotasPendiente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(777, 150)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FACTURAS ELECTRONICAS"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel2.Location = New System.Drawing.Point(704, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(28, 28)
        Me.Panel2.TabIndex = 431
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Location = New System.Drawing.Point(443, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(28, 28)
        Me.Panel1.TabIndex = 430
        '
        'Panel22
        '
        Me.Panel22.BackgroundImage = CType(resources.GetObject("Panel22.BackgroundImage"), System.Drawing.Image)
        Me.Panel22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel22.Location = New System.Drawing.Point(149, 21)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(28, 28)
        Me.Panel22.TabIndex = 429
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(67, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "FACTURAS "
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.MediumOrchid
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(508, 83)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(187, 51)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "ENVIAR FACTURAS ANULADAS"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'lblFacturasAnuladas
        '
        Me.lblFacturasAnuladas.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblFacturasAnuladas.AutoSize = True
        Me.lblFacturasAnuladas.LinkColor = System.Drawing.Color.Red
        Me.lblFacturasAnuladas.Location = New System.Drawing.Point(599, 44)
        Me.lblFacturasAnuladas.Name = "lblFacturasAnuladas"
        Me.lblFacturasAnuladas.Size = New System.Drawing.Size(13, 13)
        Me.lblFacturasAnuladas.TabIndex = 14
        Me.lblFacturasAnuladas.TabStop = True
        Me.lblFacturasAnuladas.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(546, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "FACTURAS ANULADAS"
        '
        'lblFacturasPendientes
        '
        Me.lblFacturasPendientes.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblFacturasPendientes.AutoSize = True
        Me.lblFacturasPendientes.LinkColor = System.Drawing.Color.Red
        Me.lblFacturasPendientes.Location = New System.Drawing.Point(89, 40)
        Me.lblFacturasPendientes.Name = "lblFacturasPendientes"
        Me.lblFacturasPendientes.Size = New System.Drawing.Size(13, 13)
        Me.lblFacturasPendientes.TabIndex = 5
        Me.lblFacturasPendientes.TabStop = True
        Me.lblFacturasPendientes.Text = "0"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.MediumOrchid
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(271, 83)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(157, 51)
        Me.Button4.TabIndex = 16
        Me.Button4.Text = "ENVIAR NOTAS DE CREDITO"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MediumOrchid
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(20, 83)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 51)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "ENVIAR FACTURAS"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblNotasPendiente
        '
        Me.lblNotasPendiente.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblNotasPendiente.AutoSize = True
        Me.lblNotasPendiente.LinkColor = System.Drawing.Color.Red
        Me.lblNotasPendiente.Location = New System.Drawing.Point(347, 40)
        Me.lblNotasPendiente.Name = "lblNotasPendiente"
        Me.lblNotasPendiente.Size = New System.Drawing.Size(13, 13)
        Me.lblNotasPendiente.TabIndex = 6
        Me.lblNotasPendiente.TabStop = True
        Me.lblNotasPendiente.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(304, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "NOTA DE CREDITO"
        '
        'FrmAlertasEnvioPSE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.Red
        Me.CaptionBarColor = System.Drawing.Color.Red
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(30, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(250, 24)
        CaptionLabel1.Text = "Pendientes de Envio"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(787, 341)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAlertasEnvioPSE"
        Me.ShowIcon = False
        Me.Text = ""
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bg As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents lblboletaspendientes As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents LBLBOLETASELIMINADAS As LinkLabel
    Friend WithEvents lblnotaboletas As LinkLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel22 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents lblFacturasAnuladas As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents lblFacturasPendientes As LinkLabel
    Friend WithEvents Button4 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lblNotasPendiente As LinkLabel
    Friend WithEvents Label2 As Label
End Class

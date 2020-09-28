<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasterFacturacionFE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMasterFacturacionFE))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.lblFacturasPendientes = New System.Windows.Forms.LinkLabel()
        Me.lblNotasPendiente = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblboletaspendientes = New System.Windows.Forms.LinkLabel()
        Me.lblResumenpendiente = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFacturasAnuladas = New System.Windows.Forms.LinkLabel()
        Me.lblvalidarbajas = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LBLRESUMENBAJAVALIDAR = New System.Windows.Forms.LinkLabel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LBLBOLETASELIMINADAS = New System.Windows.Forms.LinkLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblnotaboletas = New System.Windows.Forms.LinkLabel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MediumPurple
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(25, 89)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 51)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "ENVIAR FACTURAS"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button2.Location = New System.Drawing.Point(19, 83)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(156, 53)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "ENVIAR BOLETAS"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.MediumPurple
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(484, 89)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(166, 51)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "COMUNICAR ANULADOS"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.Location = New System.Drawing.Point(24, 81)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(155, 66)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "VALIDAR TICKETS (RESUMENES Y BAJAS DE FACTURAS)"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.SteelBlue
        Me.Button5.Location = New System.Drawing.Point(826, 433)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(187, 42)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "REENVIO DE RESUMEN DE BOLETAS"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'lblFacturasPendientes
        '
        Me.lblFacturasPendientes.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblFacturasPendientes.AutoSize = True
        Me.lblFacturasPendientes.LinkColor = System.Drawing.Color.Red
        Me.lblFacturasPendientes.Location = New System.Drawing.Point(94, 46)
        Me.lblFacturasPendientes.Name = "lblFacturasPendientes"
        Me.lblFacturasPendientes.Size = New System.Drawing.Size(13, 13)
        Me.lblFacturasPendientes.TabIndex = 5
        Me.lblFacturasPendientes.TabStop = True
        Me.lblFacturasPendientes.Text = "0"
        '
        'lblNotasPendiente
        '
        Me.lblNotasPendiente.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblNotasPendiente.AutoSize = True
        Me.lblNotasPendiente.LinkColor = System.Drawing.Color.Red
        Me.lblNotasPendiente.Location = New System.Drawing.Point(326, 46)
        Me.lblNotasPendiente.Name = "lblNotasPendiente"
        Me.lblNotasPendiente.Size = New System.Drawing.Size(13, 13)
        Me.lblNotasPendiente.TabIndex = 6
        Me.lblNotasPendiente.TabStop = True
        Me.lblNotasPendiente.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "FACTURAS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(277, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "NOTAS DE CREDITO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(63, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "BOLETAS"
        '
        'lblboletaspendientes
        '
        Me.lblboletaspendientes.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblboletaspendientes.AutoSize = True
        Me.lblboletaspendientes.LinkColor = System.Drawing.Color.Red
        Me.lblboletaspendientes.Location = New System.Drawing.Point(79, 42)
        Me.lblboletaspendientes.Name = "lblboletaspendientes"
        Me.lblboletaspendientes.Size = New System.Drawing.Size(13, 13)
        Me.lblboletaspendientes.TabIndex = 11
        Me.lblboletaspendientes.TabStop = True
        Me.lblboletaspendientes.Text = "0"
        '
        'lblResumenpendiente
        '
        Me.lblResumenpendiente.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblResumenpendiente.AutoSize = True
        Me.lblResumenpendiente.LinkColor = System.Drawing.Color.Red
        Me.lblResumenpendiente.Location = New System.Drawing.Point(539, 41)
        Me.lblResumenpendiente.Name = "lblResumenpendiente"
        Me.lblResumenpendiente.Size = New System.Drawing.Size(13, 13)
        Me.lblResumenpendiente.TabIndex = 13
        Me.lblResumenpendiente.TabStop = True
        Me.lblResumenpendiente.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(484, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "RESUMEN POR VALIDAR"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(498, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "FACTURAS ANULADAS"
        '
        'lblFacturasAnuladas
        '
        Me.lblFacturasAnuladas.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblFacturasAnuladas.AutoSize = True
        Me.lblFacturasAnuladas.LinkColor = System.Drawing.Color.Red
        Me.lblFacturasAnuladas.Location = New System.Drawing.Point(549, 46)
        Me.lblFacturasAnuladas.Name = "lblFacturasAnuladas"
        Me.lblFacturasAnuladas.Size = New System.Drawing.Size(13, 13)
        Me.lblFacturasAnuladas.TabIndex = 14
        Me.lblFacturasAnuladas.TabStop = True
        Me.lblFacturasAnuladas.Text = "0"
        '
        'lblvalidarbajas
        '
        Me.lblvalidarbajas.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblvalidarbajas.AutoSize = True
        Me.lblvalidarbajas.LinkColor = System.Drawing.Color.Red
        Me.lblvalidarbajas.Location = New System.Drawing.Point(76, 41)
        Me.lblvalidarbajas.Name = "lblvalidarbajas"
        Me.lblvalidarbajas.Size = New System.Drawing.Size(13, 13)
        Me.lblvalidarbajas.TabIndex = 17
        Me.lblvalidarbajas.TabStop = True
        Me.lblvalidarbajas.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(210, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "COMUNICACION DE BAJA POR VALIDAR"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Panel22)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.lblNotasPendiente)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblFacturasPendientes)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.lblFacturasAnuladas)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(706, 157)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FACTURAS ELECTRONICAS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel5)
        Me.GroupBox2.Controls.Add(Me.Panel4)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Controls.Add(Me.Button7)
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblnotaboletas)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.LBLBOLETASELIMINADAS)
        Me.GroupBox2.Controls.Add(Me.lblboletaspendientes)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(702, 146)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "BOLETAS ELECTRONICAS"
        '
        'LBLRESUMENBAJAVALIDAR
        '
        Me.LBLRESUMENBAJAVALIDAR.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.LBLRESUMENBAJAVALIDAR.AutoSize = True
        Me.LBLRESUMENBAJAVALIDAR.LinkColor = System.Drawing.Color.Red
        Me.LBLRESUMENBAJAVALIDAR.Location = New System.Drawing.Point(338, 41)
        Me.LBLRESUMENBAJAVALIDAR.Name = "LBLRESUMENBAJAVALIDAR"
        Me.LBLRESUMENBAJAVALIDAR.Size = New System.Drawing.Size(13, 13)
        Me.LBLRESUMENBAJAVALIDAR.TabIndex = 17
        Me.LBLRESUMENBAJAVALIDAR.TabStop = True
        Me.LBLRESUMENBAJAVALIDAR.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(283, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(158, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "RESUMEN BAJA POR VALIDAR"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(501, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "BOLETAS ANULADAS"
        '
        'LBLBOLETASELIMINADAS
        '
        Me.LBLBOLETASELIMINADAS.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.LBLBOLETASELIMINADAS.AutoSize = True
        Me.LBLBOLETASELIMINADAS.LinkColor = System.Drawing.Color.Red
        Me.LBLBOLETASELIMINADAS.Location = New System.Drawing.Point(544, 42)
        Me.LBLBOLETASELIMINADAS.Name = "LBLBOLETASELIMINADAS"
        Me.LBLBOLETASELIMINADAS.Size = New System.Drawing.Size(13, 13)
        Me.LBLBOLETASELIMINADAS.TabIndex = 15
        Me.LBLBOLETASELIMINADAS.TabStop = True
        Me.LBLBOLETASELIMINADAS.Text = "0"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ItemSize = New System.Drawing.Size(90, 18)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(735, 358)
        Me.TabControl1.TabIndex = 20
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(727, 332)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DOCUMENTOS ELECTRONICOS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.lblvalidarbajas)
        Me.TabPage3.Controls.Add(Me.LBLRESUMENBAJAVALIDAR)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.lblResumenpendiente)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(769, 332)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TICKETS"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(269, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "NOTAS DE CREDITO"
        '
        'lblnotaboletas
        '
        Me.lblnotaboletas.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.lblnotaboletas.AutoSize = True
        Me.lblnotaboletas.LinkColor = System.Drawing.Color.Red
        Me.lblnotaboletas.Location = New System.Drawing.Point(308, 42)
        Me.lblnotaboletas.Name = "lblnotaboletas"
        Me.lblnotaboletas.Size = New System.Drawing.Size(13, 13)
        Me.lblnotaboletas.TabIndex = 17
        Me.lblnotaboletas.TabStop = True
        Me.lblnotaboletas.Text = "0"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Button6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button6.Location = New System.Drawing.Point(253, 83)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(156, 53)
        Me.Button6.TabIndex = 18
        Me.Button6.Text = "ENVIAR NOTAS"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Button7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button7.Location = New System.Drawing.Point(490, 83)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(156, 53)
        Me.Button7.TabIndex = 19
        Me.Button7.Text = "ENVIAR ANULADOS"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.MediumPurple
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(257, 89)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(157, 51)
        Me.Button8.TabIndex = 16
        Me.Button8.Text = "ENVIAR NOTAS"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Panel22
        '
        Me.Panel22.BackgroundImage = CType(resources.GetObject("Panel22.BackgroundImage"), System.Drawing.Image)
        Me.Panel22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel22.Location = New System.Drawing.Point(151, 31)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(28, 28)
        Me.Panel22.TabIndex = 430
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Location = New System.Drawing.Point(385, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(28, 28)
        Me.Panel1.TabIndex = 431
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel2.Location = New System.Drawing.Point(622, 21)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(28, 28)
        Me.Panel2.TabIndex = 432
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel3.Location = New System.Drawing.Point(147, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(28, 28)
        Me.Panel3.TabIndex = 430
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel4.Location = New System.Drawing.Point(381, 25)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(28, 28)
        Me.Panel4.TabIndex = 431
        '
        'Panel5
        '
        Me.Panel5.BackgroundImage = CType(resources.GetObject("Panel5.BackgroundImage"), System.Drawing.Image)
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel5.Location = New System.Drawing.Point(618, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(28, 28)
        Me.Panel5.TabIndex = 432
        '
        'frmMasterFacturacionFE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.SteelBlue
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(30, 10)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Comprobantes Electronicos"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(735, 358)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button5)
        Me.Name = "frmMasterFacturacionFE"
        Me.ShowIcon = False
        Me.Text = ""
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents lblFacturasPendientes As LinkLabel
    Friend WithEvents lblNotasPendiente As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblboletaspendientes As LinkLabel
    Friend WithEvents lblResumenpendiente As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblFacturasAnuladas As LinkLabel
    Friend WithEvents lblvalidarbajas As LinkLabel
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents LBLBOLETASELIMINADAS As LinkLabel
    Friend WithEvents LBLRESUMENBAJAVALIDAR As LinkLabel
    Friend WithEvents Label8 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label9 As Label
    Friend WithEvents lblnotaboletas As LinkLabel
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel22 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
End Class

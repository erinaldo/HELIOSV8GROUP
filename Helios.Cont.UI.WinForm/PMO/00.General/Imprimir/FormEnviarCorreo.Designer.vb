<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEnviarCorreo
    Inherits frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEnviarCorreo))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.TextBoxTEXTO = New System.Windows.Forms.TextBox()
        Me.TextBoxASUNTO = New System.Windows.Forms.TextBox()
        Me.TextBoxDESTINO = New System.Windows.Forms.TextBox()
        Me.TextBoxCONTRASEÑA = New System.Windows.Forms.TextBox()
        Me.TextBoxUSUARIO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PanelLoading = New System.Windows.Forms.Panel()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDireccionEnvio = New System.Windows.Forms.TextBox()
        Me.QrCodeImgControl1 = New Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BG = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelLoading.SuspendLayout()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'TextBoxTEXTO
        '
        Me.TextBoxTEXTO.BackColor = System.Drawing.Color.White
        Me.TextBoxTEXTO.ForeColor = System.Drawing.Color.Black
        Me.TextBoxTEXTO.Location = New System.Drawing.Point(110, 82)
        Me.TextBoxTEXTO.Multiline = True
        Me.TextBoxTEXTO.Name = "TextBoxTEXTO"
        Me.TextBoxTEXTO.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxTEXTO.Size = New System.Drawing.Size(357, 64)
        Me.TextBoxTEXTO.TabIndex = 15
        '
        'TextBoxASUNTO
        '
        Me.TextBoxASUNTO.BackColor = System.Drawing.Color.White
        Me.TextBoxASUNTO.ForeColor = System.Drawing.Color.Black
        Me.TextBoxASUNTO.Location = New System.Drawing.Point(110, 54)
        Me.TextBoxASUNTO.Name = "TextBoxASUNTO"
        Me.TextBoxASUNTO.ReadOnly = True
        Me.TextBoxASUNTO.Size = New System.Drawing.Size(357, 22)
        Me.TextBoxASUNTO.TabIndex = 14
        '
        'TextBoxDESTINO
        '
        Me.TextBoxDESTINO.BackColor = System.Drawing.Color.White
        Me.TextBoxDESTINO.ForeColor = System.Drawing.Color.Black
        Me.TextBoxDESTINO.Location = New System.Drawing.Point(110, 5)
        Me.TextBoxDESTINO.Multiline = True
        Me.TextBoxDESTINO.Name = "TextBoxDESTINO"
        Me.TextBoxDESTINO.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDESTINO.Size = New System.Drawing.Size(358, 42)
        Me.TextBoxDESTINO.TabIndex = 13
        '
        'TextBoxCONTRASEÑA
        '
        Me.TextBoxCONTRASEÑA.BackColor = System.Drawing.Color.White
        Me.TextBoxCONTRASEÑA.ForeColor = System.Drawing.Color.Black
        Me.TextBoxCONTRASEÑA.Location = New System.Drawing.Point(108, 209)
        Me.TextBoxCONTRASEÑA.Name = "TextBoxCONTRASEÑA"
        Me.TextBoxCONTRASEÑA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxCONTRASEÑA.ReadOnly = True
        Me.TextBoxCONTRASEÑA.Size = New System.Drawing.Size(146, 22)
        Me.TextBoxCONTRASEÑA.TabIndex = 12
        Me.TextBoxCONTRASEÑA.UseSystemPasswordChar = True
        '
        'TextBoxUSUARIO
        '
        Me.TextBoxUSUARIO.BackColor = System.Drawing.Color.White
        Me.TextBoxUSUARIO.ForeColor = System.Drawing.Color.Black
        Me.TextBoxUSUARIO.Location = New System.Drawing.Point(108, 155)
        Me.TextBoxUSUARIO.Name = "TextBoxUSUARIO"
        Me.TextBoxUSUARIO.ReadOnly = True
        Me.TextBoxUSUARIO.Size = New System.Drawing.Size(357, 22)
        Me.TextBoxUSUARIO.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Email Empresa :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-13, 212)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Contraseña Empresa :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Email Destino :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(55, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Asunto :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Descripciòn :"
        '
        'PanelLoading
        '
        Me.PanelLoading.Controls.Add(Me.ProgressBar2)
        Me.PanelLoading.Controls.Add(Me.Label7)
        Me.PanelLoading.Location = New System.Drawing.Point(4, 14)
        Me.PanelLoading.Name = "PanelLoading"
        Me.PanelLoading.Size = New System.Drawing.Size(472, 145)
        Me.PanelLoading.TabIndex = 434
        Me.PanelLoading.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(207, 79)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(73, 11)
        Me.ProgressBar2.TabIndex = 508
        Me.ProgressBar2.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(193, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 24)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Enviando . . ."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(58, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Envio:"
        '
        'txtDireccionEnvio
        '
        Me.txtDireccionEnvio.BackColor = System.Drawing.Color.White
        Me.txtDireccionEnvio.ForeColor = System.Drawing.Color.Black
        Me.txtDireccionEnvio.Location = New System.Drawing.Point(108, 181)
        Me.txtDireccionEnvio.Name = "txtDireccionEnvio"
        Me.txtDireccionEnvio.ReadOnly = True
        Me.txtDireccionEnvio.Size = New System.Drawing.Size(357, 22)
        Me.txtDireccionEnvio.TabIndex = 21
        '
        'QrCodeImgControl1
        '
        Me.QrCodeImgControl1.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M
        Me.QrCodeImgControl1.Image = CType(resources.GetObject("QrCodeImgControl1.Image"), System.Drawing.Image)
        Me.QrCodeImgControl1.Location = New System.Drawing.Point(2, 233)
        Me.QrCodeImgControl1.Name = "QrCodeImgControl1"
        Me.QrCodeImgControl1.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two
        Me.QrCodeImgControl1.Size = New System.Drawing.Size(124, 116)
        Me.QrCodeImgControl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.QrCodeImgControl1.TabIndex = 437
        Me.QrCodeImgControl1.TabStop = False
        Me.QrCodeImgControl1.Text = "QrCodeImgControl1"
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GradientPanel6.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel6.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(488, 10)
        Me.GradientPanel6.TabIndex = 469
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(95, 27)
        Me.ButtonAdv4.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(278, 4)
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(95, 27)
        Me.ButtonAdv4.TabIndex = 529
        Me.ButtonAdv4.Text = "Enviar"
        Me.ButtonAdv4.UseVisualStyle = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.TextBoxCONTRASEÑA)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label6)
        Me.GradientPanel1.Controls.Add(Me.TextBoxDESTINO)
        Me.GradientPanel1.Controls.Add(Me.txtDireccionEnvio)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.TextBoxUSUARIO)
        Me.GradientPanel1.Controls.Add(Me.TextBoxASUNTO)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Controls.Add(Me.TextBoxTEXTO)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 10)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(488, 155)
        Me.GradientPanel1.TabIndex = 530
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(95, 27)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(379, 4)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(95, 27)
        Me.ButtonAdv1.TabIndex = 531
        Me.ButtonAdv1.Text = "Cerrar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv4)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 165)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(488, 35)
        Me.GradientPanel2.TabIndex = 531
        '
        'BG
        '
        Me.BG.WorkerReportsProgress = True
        Me.BG.WorkerSupportsCancellation = True
        '
        'Timer1
        '
        '
        'FormEnviarCorreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.White
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 5)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(55, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.CornflowerBlue
        CaptionLabel1.Location = New System.Drawing.Point(65, 0)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(100, 50)
        CaptionLabel1.Text = "Enviar archivo"
        CaptionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.CornflowerBlue
        CaptionLabel2.Location = New System.Drawing.Point(65, 13)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(100, 50)
        CaptionLabel2.Text = "Pdf, xml..."
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(488, 199)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.PanelLoading)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel6)
        Me.Controls.Add(Me.QrCodeImgControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEnviarCorreo"
        Me.ShowIcon = False
        Me.Text = ""
        Me.PanelLoading.ResumeLayout(False)
        Me.PanelLoading.PerformLayout()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents TextBoxTEXTO As TextBox
    Friend WithEvents TextBoxASUNTO As TextBox
    Friend WithEvents TextBoxDESTINO As TextBox
    Friend WithEvents TextBoxCONTRASEÑA As TextBox
    Friend WithEvents TextBoxUSUARIO As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PanelLoading As Panel
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDireccionEnvio As TextBox
    Friend WithEvents QrCodeImgControl1 As Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl
    Friend WithEvents GradientPanel6 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents BG As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As Timer
End Class

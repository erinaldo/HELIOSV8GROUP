<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class HeliosLogin
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HeliosLogin))
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtRUC = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PanelLoading = New System.Windows.Forms.Panel()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SfDLicense = New System.Windows.Forms.SaveFileDialog()
        Me.OfDLicense = New System.Windows.Forms.OpenFileDialog()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtRUC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PasswordTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsernameTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLoading.SuspendLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.OK.BackgroundImage = CType(resources.GetObject("OK.BackgroundImage"), System.Drawing.Image)
        Me.OK.FlatAppearance.BorderSize = 0
        Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK.ForeColor = System.Drawing.Color.White
        Me.OK.Location = New System.Drawing.Point(32, 283)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 23)
        Me.OK.TabIndex = 3
        Me.OK.Text = "&OK"
        Me.OK.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.Cancel.Location = New System.Drawing.Point(132, 283)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 4
        Me.Cancel.Text = "&Cancel"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.txtRUC)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.Panel1)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.PictureBox1)
        Me.GradientPanel1.Controls.Add(Me.UsernameLabel)
        Me.GradientPanel1.Controls.Add(Me.PasswordTextBox)
        Me.GradientPanel1.Controls.Add(Me.PasswordLabel)
        Me.GradientPanel1.Controls.Add(Me.UsernameTextBox)
        Me.GradientPanel1.Controls.Add(Me.OK)
        Me.GradientPanel1.Controls.Add(Me.Cancel)
        Me.GradientPanel1.Location = New System.Drawing.Point(309, 90)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(260, 333)
        Me.GradientPanel1.TabIndex = 10
        '
        'txtRUC
        '
        Me.txtRUC.BackColor = System.Drawing.Color.White
        Me.txtRUC.BeforeTouchSize = New System.Drawing.Size(194, 22)
        Me.txtRUC.BorderColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRUC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRUC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRUC.Location = New System.Drawing.Point(32, 154)
        Me.txtRUC.MaxLength = 12
        Me.txtRUC.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRUC.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRUC.Name = "txtRUC"
        Me.txtRUC.Size = New System.Drawing.Size(194, 22)
        Me.txtRUC.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtRUC.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(220, 23)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "RUC./DNI."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(258, 45)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(258, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Login"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(86, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "S O F T - P A C K"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(32, 53)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 52)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.Location = New System.Drawing.Point(29, 179)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&Usuario"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.White
        Me.PasswordTextBox.BeforeTouchSize = New System.Drawing.Size(194, 22)
        Me.PasswordTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PasswordTextBox.Location = New System.Drawing.Point(32, 253)
        Me.PasswordTextBox.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.PasswordTextBox.MinimumSize = New System.Drawing.Size(14, 10)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(194, 22)
        Me.PasswordTextBox.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.PasswordTextBox.TabIndex = 2
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLabel.Location = New System.Drawing.Point(29, 231)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "&Password"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.White
        Me.UsernameTextBox.BeforeTouchSize = New System.Drawing.Size(194, 22)
        Me.UsernameTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.UsernameTextBox.Location = New System.Drawing.Point(32, 203)
        Me.UsernameTextBox.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.UsernameTextBox.MinimumSize = New System.Drawing.Size(14, 10)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.NearImage = CType(resources.GetObject("UsernameTextBox.NearImage"), System.Drawing.Image)
        Me.UsernameTextBox.Size = New System.Drawing.Size(194, 22)
        Me.UsernameTextBox.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.UsernameTextBox.TabIndex = 1
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel1.Location = New System.Drawing.Point(173, 170)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(87, 14)
        Me.LinkLabel1.TabIndex = 434
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Verificar licencia"
        Me.LinkLabel1.Visible = False
        '
        'PanelLoading
        '
        Me.PanelLoading.Controls.Add(Me.ProgressBar2)
        Me.PanelLoading.Controls.Add(Me.Label4)
        Me.PanelLoading.Location = New System.Drawing.Point(594, 223)
        Me.PanelLoading.Name = "PanelLoading"
        Me.PanelLoading.Size = New System.Drawing.Size(252, 180)
        Me.PanelLoading.TabIndex = 14
        Me.PanelLoading.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(99, 84)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 509
        Me.ProgressBar2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(54, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Validando licencia . . ."
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.White
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(194, 22)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.DodgerBlue
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt1.Location = New System.Drawing.Point(84, 187)
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.DodgerBlue
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.Size = New System.Drawing.Size(194, 22)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextBoxExt1.TabIndex = 12
        Me.TextBoxExt1.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'SfDLicense
        '
        Me.SfDLicense.FileName = "License.lic"
        Me.SfDLicense.Filter = """License|*.lic"""
        '
        'OfDLicense
        '
        Me.OfDLicense.FileName = "OpenFileDialog1"
        '
        'HeliosLogin
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.White
        Me.CancelButton = Me.Cancel
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 0
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionFont = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(858, 542)
        Me.ControlBox = False
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.PanelLoading)
        Me.Controls.Add(Me.TextBoxExt1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HeliosLogin"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Login"
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtRUC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PasswordTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsernameTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLoading.ResumeLayout(False)
        Me.PanelLoading.PerformLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents UsernameTextBox As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents PasswordTextBox As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtRUC As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents SfDLicense As SaveFileDialog
    Friend WithEvents OfDLicense As OpenFileDialog
    Friend WithEvents PanelLoading As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents LinkLabel1 As LinkLabel
End Class

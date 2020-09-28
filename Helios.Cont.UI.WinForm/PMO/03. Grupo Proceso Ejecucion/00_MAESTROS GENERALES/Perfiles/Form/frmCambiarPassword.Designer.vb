<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class frmCambiarPassword
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambiarPassword))
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtRUC = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRepetirPassword = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNuevoPassword = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtRUC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRepetirPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNuevoPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PasswordTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsernameTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.OK.Location = New System.Drawing.Point(32, 381)
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
        Me.Cancel.Location = New System.Drawing.Point(132, 381)
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
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Controls.Add(Me.txtRepetirPassword)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.txtNuevoPassword)
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
        Me.GradientPanel1.Size = New System.Drawing.Size(260, 421)
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
        Me.txtRUC.Location = New System.Drawing.Point(32, 139)
        Me.txtRUC.MaxLength = 12
        Me.txtRUC.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRUC.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRUC.Name = "txtRUC"
        Me.txtRUC.Size = New System.Drawing.Size(194, 22)
        Me.txtRUC.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtRUC.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(197, 23)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "RUC./DNI."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRepetirPassword
        '
        Me.txtRepetirPassword.BackColor = System.Drawing.Color.White
        Me.txtRepetirPassword.BeforeTouchSize = New System.Drawing.Size(194, 22)
        Me.txtRepetirPassword.BorderColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRepetirPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRepetirPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRepetirPassword.Location = New System.Drawing.Point(32, 344)
        Me.txtRepetirPassword.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRepetirPassword.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRepetirPassword.Name = "txtRepetirPassword"
        Me.txtRepetirPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtRepetirPassword.Size = New System.Drawing.Size(194, 22)
        Me.txtRepetirPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtRepetirPassword.TabIndex = 12
        Me.txtRepetirPassword.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 322)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(197, 23)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Repetir nuevo password"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNuevoPassword
        '
        Me.txtNuevoPassword.BackColor = System.Drawing.Color.White
        Me.txtNuevoPassword.BeforeTouchSize = New System.Drawing.Size(194, 22)
        Me.txtNuevoPassword.BorderColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNuevoPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNuevoPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNuevoPassword.Location = New System.Drawing.Point(32, 287)
        Me.txtNuevoPassword.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNuevoPassword.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNuevoPassword.Name = "txtNuevoPassword"
        Me.txtNuevoPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtNuevoPassword.Size = New System.Drawing.Size(194, 22)
        Me.txtNuevoPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNuevoPassword.TabIndex = 0
        Me.txtNuevoPassword.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 266)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(197, 23)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Nuevo password"
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
        Me.Label2.Text = "Cambiar Password"
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
        Me.UsernameLabel.Location = New System.Drawing.Point(29, 163)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(197, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&Alias"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.White
        Me.PasswordTextBox.BeforeTouchSize = New System.Drawing.Size(194, 22)
        Me.PasswordTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PasswordTextBox.Location = New System.Drawing.Point(32, 237)
        Me.PasswordTextBox.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.PasswordTextBox.MinimumSize = New System.Drawing.Size(14, 10)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.PasswordTextBox.Size = New System.Drawing.Size(194, 22)
        Me.PasswordTextBox.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.PasswordTextBox.TabIndex = 2
        Me.PasswordTextBox.UseSystemPasswordChar = True
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLabel.Location = New System.Drawing.Point(29, 215)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(197, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "&Password  Antiguo"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.White
        Me.UsernameTextBox.BeforeTouchSize = New System.Drawing.Size(194, 22)
        Me.UsernameTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.UsernameTextBox.Location = New System.Drawing.Point(32, 187)
        Me.UsernameTextBox.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.UsernameTextBox.MinimumSize = New System.Drawing.Size(14, 10)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.NearImage = CType(resources.GetObject("UsernameTextBox.NearImage"), System.Drawing.Image)
        Me.UsernameTextBox.Size = New System.Drawing.Size(194, 22)
        Me.UsernameTextBox.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.UsernameTextBox.TabIndex = 1
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
        'frmCambiarPassword
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
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambiarPassword"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Login"
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtRUC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRepetirPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNuevoPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PasswordTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsernameTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents txtNuevoPassword As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRepetirPassword As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRUC As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label5 As Label
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTablaPrincipalCalzados
    Inherits MetroForm

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TextItem1 As Syncfusion.Windows.Forms.Tools.TextItem = New Syncfusion.Windows.Forms.Tools.TextItem()
        Dim TextItem2 As Syncfusion.Windows.Forms.Tools.TextItem = New Syncfusion.Windows.Forms.Tools.TextItem()
        Dim TextItem3 As Syncfusion.Windows.Forms.Tools.TextItem = New Syncfusion.Windows.Forms.Tools.TextItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTablaPrincipalCalzados))
        Dim TextItem4 As Syncfusion.Windows.Forms.Tools.TextItem = New Syncfusion.Windows.Forms.Tools.TextItem()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BannerImageCollection = New Syncfusion.Windows.Forms.Tools.ImageListAdv(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.RoundButton23 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.HubTile5 = New Syncfusion.Windows.Forms.Tools.HubTile()
        Me.PasswordTextBox = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.UsernameTextBox = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.PasswordTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsernameTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Lime
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.ProgressBar2)
        Me.GradientPanel1.Controls.Add(Me.RoundButton23)
        Me.GradientPanel1.Controls.Add(Me.GradientPanel2)
        Me.GradientPanel1.Controls.Add(Me.PasswordTextBox)
        Me.GradientPanel1.Controls.Add(Me.UsernameTextBox)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1018, 393)
        Me.GradientPanel1.TabIndex = 4
        '
        'BannerImageCollection
        '
        Me.BannerImageCollection.Images.AddRange(New System.Drawing.Image() {CType(resources.GetObject("BannerImageCollection.Images"), System.Drawing.Image)})
        Me.BannerImageCollection.ImageSize = New System.Drawing.Size(700, 393)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Cornsilk
        Me.Label4.Location = New System.Drawing.Point(803, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 19)
        Me.Label4.TabIndex = 563
        Me.Label4.Text = "Validando usuario . . ."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(795, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 28)
        Me.Label1.TabIndex = 564
        Me.Label1.Text = "Login Usuario"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Lime
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Right
        Me.GradientPanel2.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.HubTile5)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(700, 391)
        Me.GradientPanel2.TabIndex = 565
        '
        'RoundButton23
        '
        Me.RoundButton23.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton23.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.RoundButton23.BeforeTouchSize = New System.Drawing.Size(261, 36)
        Me.RoundButton23.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton23.ForeColor = System.Drawing.Color.White
        Me.RoundButton23.IsBackStageButton = False
        Me.RoundButton23.Location = New System.Drawing.Point(729, 257)
        Me.RoundButton23.MetroColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.RoundButton23.Name = "RoundButton23"
        Me.RoundButton23.Size = New System.Drawing.Size(261, 36)
        Me.RoundButton23.TabIndex = 566
        Me.RoundButton23.Text = "INGRESAR"
        Me.RoundButton23.UseVisualStyle = True
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(843, 302)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 567
        Me.ProgressBar2.Visible = False
        '
        'HubTile5
        '
        TextItem1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TextItem1.HubTile = Me.HubTile5
        TextItem1.Text = "Finanzas"
        Me.HubTile5.Banner = TextItem1
        Me.HubTile5.BannerColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.HubTile5.BannerHeight = 50
        TextItem2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        TextItem2.HubTile = Me.HubTile5
        Me.HubTile5.Body = TextItem2
        Me.HubTile5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HubTile5.EnableSelectionMarker = False
        Me.HubTile5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        TextItem3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        TextItem3.HubTile = Me.HubTile5
        Me.HubTile5.Footer = TextItem3
        Me.HubTile5.ImageSource = CType(resources.GetObject("HubTile5.ImageSource"), System.Drawing.Image)
        Me.HubTile5.Location = New System.Drawing.Point(0, 0)
        Me.HubTile5.Margin = New System.Windows.Forms.Padding(1)
        Me.HubTile5.MinimumSize = New System.Drawing.Size(100, 100)
        Me.HubTile5.Name = "HubTile5"
        Me.HubTile5.PulseScale = 100
        Me.HubTile5.Size = New System.Drawing.Size(698, 389)
        Me.HubTile5.TabIndex = 11
        Me.HubTile5.Tag = "14"
        TextItem4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        TextItem4.HubTile = Me.HubTile5
        Me.HubTile5.Title = TextItem4
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PasswordTextBox.BeforeTouchSize = New System.Drawing.Size(261, 29)
        Me.PasswordTextBox.BorderColor = System.Drawing.Color.Gray
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.CornerRadius = 4
        Me.PasswordTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PasswordTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.ForeColor = System.Drawing.Color.White
        Me.PasswordTextBox.Location = New System.Drawing.Point(729, 180)
        Me.PasswordTextBox.MaxLength = 20
        Me.PasswordTextBox.Metrocolor = System.Drawing.Color.Silver
        Me.PasswordTextBox.MinimumSize = New System.Drawing.Size(14, 10)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.NearImage = CType(resources.GetObject("PasswordTextBox.NearImage"), System.Drawing.Image)
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(261, 29)
        Me.PasswordTextBox.TabIndex = 562
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.UsernameTextBox.BeforeTouchSize = New System.Drawing.Size(261, 29)
        Me.UsernameTextBox.BorderColor = System.Drawing.Color.Gray
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameTextBox.CornerRadius = 4
        Me.UsernameTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.UsernameTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTextBox.ForeColor = System.Drawing.Color.White
        Me.UsernameTextBox.Location = New System.Drawing.Point(729, 135)
        Me.UsernameTextBox.MaxLength = 70
        Me.UsernameTextBox.Metrocolor = System.Drawing.Color.Silver
        Me.UsernameTextBox.MinimumSize = New System.Drawing.Size(14, 10)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.NearImage = CType(resources.GetObject("UsernameTextBox.NearImage"), System.Drawing.Image)
        Me.UsernameTextBox.Size = New System.Drawing.Size(261, 29)
        Me.UsernameTextBox.TabIndex = 561
        '
        'FormTablaPrincipalCalzados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 393)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormTablaPrincipalCalzados"
        Me.ShowIcon = False
        Me.Text = "FormTablaPrincipalCalzados"
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.PasswordTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsernameTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents GradientPanel1 As Tools.GradientPanel
    Private WithEvents BannerImageCollection As Tools.ImageListAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents UsernameTextBox As Tools.TextBoxExt
    Friend WithEvents PasswordTextBox As Tools.TextBoxExt
    Private WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundButton23 As RoundButton2
    Private WithEvents HubTile5 As Tools.HubTile
    Friend WithEvents ProgressBar2 As ProgressBar
End Class

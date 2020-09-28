Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabP_RestaurantMaster
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabP_RestaurantMaster))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.RoundButton26 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton25 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton24 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton23 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Line22 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(30, 40)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.RoundButton22)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox7)
        Me.Panel1.Controls.Add(Me.PictureBox6)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.RoundButton26)
        Me.Panel1.Controls.Add(Me.RoundButton25)
        Me.Panel1.Controls.Add(Me.RoundButton24)
        Me.Panel1.Controls.Add(Me.RoundButton23)
        Me.Panel1.Controls.Add(Me.Line22)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1135, 590)
        Me.Panel1.TabIndex = 0
        '
        'RoundButton22
        '
        Me.RoundButton22.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton22.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.RoundButton22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(299, 72)
        Me.RoundButton22.FlatAppearance.BorderSize = 0
        Me.RoundButton22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton22.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.RoundButton22.ForeColor = System.Drawing.Color.White
        Me.RoundButton22.Image = CType(resources.GetObject("RoundButton22.Image"), System.Drawing.Image)
        Me.RoundButton22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(507, 475)
        Me.RoundButton22.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(299, 72)
        Me.RoundButton22.TabIndex = 768
        Me.RoundButton22.Text = "CONFIGURACIÓN"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium", 20.0!)
        Me.Label1.Location = New System.Drawing.Point(507, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(318, 31)
        Me.Label1.TabIndex = 767
        Me.Label1.Text = "MENÚ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.BackgroundImage = CType(resources.GetObject("PictureBox7.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox7.Location = New System.Drawing.Point(402, 370)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(51, 59)
        Me.PictureBox7.TabIndex = 766
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.BackgroundImage = CType(resources.GetObject("PictureBox6.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox6.Location = New System.Drawing.Point(402, 166)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(51, 59)
        Me.PictureBox6.TabIndex = 765
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImage = CType(resources.GetObject("PictureBox5.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox5.Location = New System.Drawing.Point(402, 466)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(51, 59)
        Me.PictureBox5.TabIndex = 764
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox4.Location = New System.Drawing.Point(402, 264)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(51, 59)
        Me.PictureBox4.TabIndex = 763
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox3.Location = New System.Drawing.Point(402, 72)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(51, 59)
        Me.PictureBox3.TabIndex = 762
        Me.PictureBox3.TabStop = False
        '
        'RoundButton26
        '
        Me.RoundButton26.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton26.BackColor = System.Drawing.Color.IndianRed
        Me.RoundButton26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.RoundButton26.BeforeTouchSize = New System.Drawing.Size(299, 72)
        Me.RoundButton26.FlatAppearance.BorderSize = 0
        Me.RoundButton26.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton26.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.RoundButton26.ForeColor = System.Drawing.Color.White
        Me.RoundButton26.Image = CType(resources.GetObject("RoundButton26.Image"), System.Drawing.Image)
        Me.RoundButton26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton26.IsBackStageButton = False
        Me.RoundButton26.Location = New System.Drawing.Point(507, 285)
        Me.RoundButton26.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RoundButton26.Name = "RoundButton26"
        Me.RoundButton26.Size = New System.Drawing.Size(299, 72)
        Me.RoundButton26.TabIndex = 761
        Me.RoundButton26.Text = "CAJA CENTRALIZADA"
        '
        'RoundButton25
        '
        Me.RoundButton25.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton25.BackColor = System.Drawing.Color.Gray
        Me.RoundButton25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.RoundButton25.BeforeTouchSize = New System.Drawing.Size(299, 72)
        Me.RoundButton25.FlatAppearance.BorderSize = 0
        Me.RoundButton25.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton25.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.RoundButton25.ForeColor = System.Drawing.Color.White
        Me.RoundButton25.Image = CType(resources.GetObject("RoundButton25.Image"), System.Drawing.Image)
        Me.RoundButton25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton25.IsBackStageButton = False
        Me.RoundButton25.Location = New System.Drawing.Point(507, 195)
        Me.RoundButton25.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RoundButton25.Name = "RoundButton25"
        Me.RoundButton25.Size = New System.Drawing.Size(299, 72)
        Me.RoundButton25.TabIndex = 757
        Me.RoundButton25.Text = "VENTA DIRECTA"
        '
        'RoundButton24
        '
        Me.RoundButton24.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton24.BackColor = System.Drawing.Color.CadetBlue
        Me.RoundButton24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RoundButton24.BeforeTouchSize = New System.Drawing.Size(299, 72)
        Me.RoundButton24.FlatAppearance.BorderSize = 0
        Me.RoundButton24.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton24.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.RoundButton24.ForeColor = System.Drawing.Color.White
        Me.RoundButton24.Image = CType(resources.GetObject("RoundButton24.Image"), System.Drawing.Image)
        Me.RoundButton24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton24.IsBackStageButton = False
        Me.RoundButton24.Location = New System.Drawing.Point(507, 379)
        Me.RoundButton24.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RoundButton24.Name = "RoundButton24"
        Me.RoundButton24.Size = New System.Drawing.Size(299, 72)
        Me.RoundButton24.TabIndex = 756
        Me.RoundButton24.Text = "RESERVACIÓN"
        '
        'RoundButton23
        '
        Me.RoundButton23.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton23.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RoundButton23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.RoundButton23.BeforeTouchSize = New System.Drawing.Size(299, 72)
        Me.RoundButton23.FlatAppearance.BorderSize = 0
        Me.RoundButton23.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton23.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.RoundButton23.ForeColor = System.Drawing.Color.White
        Me.RoundButton23.Image = CType(resources.GetObject("RoundButton23.Image"), System.Drawing.Image)
        Me.RoundButton23.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton23.IsBackStageButton = False
        Me.RoundButton23.Location = New System.Drawing.Point(507, 101)
        Me.RoundButton23.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RoundButton23.Name = "RoundButton23"
        Me.RoundButton23.Size = New System.Drawing.Size(299, 72)
        Me.RoundButton23.TabIndex = 755
        Me.RoundButton23.Text = "CONTROL DE MESAS"
        '
        'Line22
        '
        Me.Line22.BackColor = System.Drawing.Color.White
        Me.Line22.LineColor = System.Drawing.Color.White
        Me.Line22.Location = New System.Drawing.Point(499, 40)
        Me.Line22.Name = "Line22"
        Me.Line22.Size = New System.Drawing.Size(2, 530)
        Me.Line22.TabIndex = 748
        Me.Line22.Text = "Line22"
        '
        'TabP_RestaurantMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.Panel1)
        Me.Name = "TabP_RestaurantMaster"
        Me.Size = New System.Drawing.Size(1135, 590)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Private WithEvents ToggleConsultas As ToggleButton2
    Private WithEvents Line21 As Line2
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents TextboxJiu1 As TextboxJiu
    Friend WithEvents Line22 As Line2
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RoundButton25 As RoundButton2
    Friend WithEvents RoundButton24 As RoundButton2
    Friend WithEvents RoundButton23 As RoundButton2
    Friend WithEvents RoundButton26 As RoundButton2
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundButton22 As RoundButton2
End Class

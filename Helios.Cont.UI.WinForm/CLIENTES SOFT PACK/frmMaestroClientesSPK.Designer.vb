<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaestroClientesSPK
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaestroClientesSPK))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel11 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ToggleButton21 = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PopupControlContainer2 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel11.SuspendLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupControlContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel11
        '
        Me.GradientPanel11.BackColor = System.Drawing.Color.White
        Me.GradientPanel11.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel11.BorderSides = CType((System.Windows.Forms.Border3DSide.Top Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.GradientPanel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel11.Controls.Add(Me.cboAnio)
        Me.GradientPanel11.Controls.Add(Me.ProgressBar1)
        Me.GradientPanel11.Controls.Add(Me.ToggleButton21)
        Me.GradientPanel11.Controls.Add(Me.ButtonAdv4)
        Me.GradientPanel11.Controls.Add(Me.ButtonAdv6)
        Me.GradientPanel11.Controls.Add(Me.cboMesCompra)
        Me.GradientPanel11.Controls.Add(Me.Label21)
        Me.GradientPanel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel11.Location = New System.Drawing.Point(0, 49)
        Me.GradientPanel11.Name = "GradientPanel11"
        Me.GradientPanel11.Size = New System.Drawing.Size(792, 37)
        Me.GradientPanel11.TabIndex = 294
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.Location = New System.Drawing.Point(190, 9)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.cboAnio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cboAnio.Size = New System.Drawing.Size(60, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnio.TabIndex = 460
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(618, 7)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 459
        Me.ProgressBar1.Visible = False
        '
        'ToggleButton21
        '
        Me.ToggleButton21.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ToggleButton21.ActiveText = "Filtro activo"
        Me.ToggleButton21.BackColor = System.Drawing.Color.Transparent
        Me.ToggleButton21.InActiveColor = System.Drawing.Color.WhiteSmoke
        Me.ToggleButton21.InActiveText = "Sin filtros"
        Me.ToggleButton21.Location = New System.Drawing.Point(479, 2)
        Me.ToggleButton21.MaximumSize = New System.Drawing.Size(135, 51)
        Me.ToggleButton21.MinimumSize = New System.Drawing.Size(93, 30)
        Me.ToggleButton21.Name = "ToggleButton21"
        Me.ToggleButton21.Size = New System.Drawing.Size(119, 30)
        Me.ToggleButton21.SliderColor = System.Drawing.Color.Black
        Me.ToggleButton21.SlidingAngle = 5
        Me.ToggleButton21.TabIndex = 458
        Me.ToggleButton21.Text = "ToggleButton21"
        Me.ToggleButton21.TextColor = System.Drawing.Color.White
        Me.ToggleButton21.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.OFF
        Me.ToggleButton21.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.IOS
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(119, 23)
        Me.ButtonAdv4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.Image = CType(resources.GetObject("ButtonAdv4.Image"), System.Drawing.Image)
        Me.ButtonAdv4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(341, 7)
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(119, 23)
        Me.ButtonAdv4.TabIndex = 4
        Me.ButtonAdv4.Text = "Cambiar período"
        Me.ButtonAdv4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv4.UseVisualStyle = True
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(86, 23)
        Me.ButtonAdv6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(253, 7)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(86, 23)
        Me.ButtonAdv6.TabIndex = 3
        Me.ButtonAdv6.Text = "Consultar"
        Me.ButtonAdv6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(121, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(65, 9)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(121, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(14, 14)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(47, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Período"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(792, 49)
        Me.Panel1.TabIndex = 293
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButton2, Me.ToolStripButton14, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(792, 49)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(13, 46)
        Me.ToolStripLabel1.Text = "  "
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton14.Image = CType(resources.GetObject("ToolStripButton14.Image"), System.Drawing.Image)
        Me.ToolStripButton14.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.Size = New System.Drawing.Size(34, 46)
        Me.ToolStripButton14.Text = "Proveedor"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(34, 46)
        Me.ToolStripButton1.Text = "Eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 49)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(34, 46)
        Me.ToolStripButton2.Text = "Proveedor"
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.MistyRose
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.PopupControlContainer2)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 86)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(792, 22)
        Me.PanelError.TabIndex = 295
        Me.PanelError.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Location = New System.Drawing.Point(773, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 288
        Me.PictureBox1.TabStop = False
        '
        'PopupControlContainer2
        '
        Me.PopupControlContainer2.BackColor = System.Drawing.SystemColors.Info
        Me.PopupControlContainer2.Controls.Add(Me.ListBox1)
        Me.PopupControlContainer2.Location = New System.Drawing.Point(283, 25)
        Me.PopupControlContainer2.Name = "PopupControlContainer2"
        Me.PopupControlContainer2.Size = New System.Drawing.Size(182, 87)
        Me.PopupControlContainer2.TabIndex = 5
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.Items.AddRange(New Object() {"Compra al credito c/recep. exist.", "Compra al credito c/exist. transit.", "Compra al contado c/recep. exist.", "Compra al contado c/exist. transit.", "Nuevo proveedor"})
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(182, 87)
        Me.ListBox1.TabIndex = 0
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Maroon
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'frmMaestroClientesSPK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.CaptionBarHeight = 60
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 14)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Clientes SoftPack"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.White
        CaptionLabel2.Location = New System.Drawing.Point(55, 25)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Mantenimiento general"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(792, 339)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.GradientPanel11)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMaestroClientesSPK"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel11.ResumeLayout(False)
        Me.GradientPanel11.PerformLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupControlContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel11 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ToggleButton21 As ToggleButton2
    Friend WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label21 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Private WithEvents ToolStripButton14 As ToolStripButton
    Private WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Private WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents PanelError As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PopupControlContainer2 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents lblEstado As Label
End Class

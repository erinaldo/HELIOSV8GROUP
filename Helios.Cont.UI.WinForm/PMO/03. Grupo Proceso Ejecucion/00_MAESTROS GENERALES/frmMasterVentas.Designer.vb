<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasterVentas
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMasterVentas))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionImage2 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripPanelItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.rbPeriodo = New Syncfusion.Windows.Forms.Tools.ToolStripRadioButton()
        Me.rbDia = New Syncfusion.Windows.Forms.Tools.ToolStripRadioButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.PopupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lstVenta = New System.Windows.Forms.ListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.panel9 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DropDownBarItem1 = New Syncfusion.Windows.Forms.Tools.XPMenus.DropDownBarItem()
        Me.BarItem1 = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.PopupControlContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panel9.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PanelError)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 49)
        Me.Panel1.TabIndex = 1
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(1000, 22)
        Me.PanelError.TabIndex = 290
        Me.PanelError.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(981, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 288
        Me.PictureBox1.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStripButton1, Me.ToolStripButton9, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripLabel1, Me.ToolStripPanelItem1, Me.ToolStripButton8, Me.ToolStripButton10})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1000, 49)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(94, 46)
        Me.ToolStripLabel2.Text = "Período: 2015"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(44, 46)
        Me.ToolStripButton1.Text = "Eliminar"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(44, 46)
        Me.ToolStripButton9.Text = "Visualizar"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(44, 46)
        Me.ToolStripButton2.Text = "Actualizar"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(44, 46)
        Me.ToolStripButton3.Text = "Agregar filtro"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(77, 46)
        Me.ToolStripLabel1.Text = "Reportes"
        '
        'ToolStripPanelItem1
        '
        Me.ToolStripPanelItem1.CausesValidation = False
        Me.ToolStripPanelItem1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripPanelItem1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rbPeriodo, Me.rbDia})
        Me.ToolStripPanelItem1.Name = "ToolStripPanelItem1"
        Me.ToolStripPanelItem1.Size = New System.Drawing.Size(84, 49)
        Me.ToolStripPanelItem1.Text = "ToolStripPanelItem1"
        Me.ToolStripPanelItem1.Transparent = True
        '
        'rbPeriodo
        '
        Me.rbPeriodo.Checked = True
        Me.rbPeriodo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbPeriodo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rbPeriodo.Name = "rbPeriodo"
        Me.rbPeriodo.Size = New System.Drawing.Size(80, 17)
        Me.rbPeriodo.Text = "Por período"
        '
        'rbDia
        '
        Me.rbDia.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rbDia.Name = "rbDia"
        Me.rbDia.Size = New System.Drawing.Size(58, 17)
        Me.rbDia.Text = "Por día"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(44, 46)
        Me.ToolStripButton8.Text = "Area de agrupamiento"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(44, 46)
        Me.ToolStripButton10.Text = "Agrupar"
        '
        'PopupControlContainer1
        '
        Me.PopupControlContainer1.BackColor = System.Drawing.SystemColors.Info
        Me.PopupControlContainer1.Controls.Add(Me.lstVenta)
        Me.PopupControlContainer1.Location = New System.Drawing.Point(242, 56)
        Me.PopupControlContainer1.Name = "PopupControlContainer1"
        Me.PopupControlContainer1.Size = New System.Drawing.Size(126, 103)
        Me.PopupControlContainer1.TabIndex = 4
        '
        'lstVenta
        '
        Me.lstVenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstVenta.FormattingEnabled = True
        Me.lstVenta.HorizontalScrollbar = True
        Me.lstVenta.Items.AddRange(New Object() {"Pedido", "Ticket Directo", "Venta normal al Credito", "Venta normal directa", "Servicios al Contado", "Servicios al Credito ", "Nuevo cliente"})
        Me.lstVenta.Location = New System.Drawing.Point(0, 0)
        Me.lstVenta.Name = "lstVenta"
        Me.lstVenta.Size = New System.Drawing.Size(126, 103)
        Me.lstVenta.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.panel9)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 49)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(179, 625)
        Me.Panel2.TabIndex = 11
        '
        'panel9
        '
        Me.panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.panel9.Controls.Add(Me.ToolStrip2)
        Me.panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel9.Location = New System.Drawing.Point(0, 572)
        Me.panel9.Name = "panel9"
        Me.panel9.Size = New System.Drawing.Size(179, 53)
        Me.panel9.TabIndex = 12
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton6, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton7})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip2.Size = New System.Drawing.Size(179, 53)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(24, 50)
        Me.ToolStripButton6.Text = "Add Nota de credito"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(24, 50)
        Me.ToolStripButton4.Text = "Add Nota de crédito"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(24, 50)
        Me.ToolStripButton5.Text = "Agrupar"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(37, 50)
        Me.ToolStripButton7.Text = "0"
        Me.ToolStripButton7.ToolTipText = "Pedidos pendientes"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btOperacion)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(179, 41)
        Me.Panel3.TabIndex = 11
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(131, 30)
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(26, 5)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(131, 30)
        Me.btOperacion.TabIndex = 0
        Me.btOperacion.Text = "Crear"
        Me.btOperacion.UseVisualStyle = True
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(636, 280)
        Me.TabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlAdv1.EnableTouchMode = True
        Me.TabControlAdv1.FocusOnTabClick = False
        Me.TabControlAdv1.ItemSize = New System.Drawing.Size(118, 33)
        Me.TabControlAdv1.Location = New System.Drawing.Point(179, 49)
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.Size = New System.Drawing.Size(821, 625)
        Me.TabControlAdv1.TabIndex = 12
        Me.TabControlAdv1.ThemesEnabled = True
        '
        'DropDownBarItem1
        '
        Me.DropDownBarItem1.BarName = "DropDownBarItem1"
        Me.DropDownBarItem1.CustomTextFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DropDownBarItem1.ID = "Crear ventas"
        Me.DropDownBarItem1.ShowToolTipInPopUp = False
        Me.DropDownBarItem1.SizeToFit = True
        Me.DropDownBarItem1.Text = "Crear Ventas"
        '
        'BarItem1
        '
        Me.BarItem1.BarName = "BarItem1"
        Me.BarItem1.ShowToolTipInPopUp = False
        Me.BarItem1.SizeToFit = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmMasterVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(55, 18)
        CaptionImage1.Name = "CaptionImage2"
        CaptionImage1.Size = New System.Drawing.Size(100, 20)
        CaptionImage2.BackColor = System.Drawing.Color.Transparent
        CaptionImage2.Image = CType(resources.GetObject("CaptionImage2.Image"), System.Drawing.Image)
        CaptionImage2.Location = New System.Drawing.Point(38, 13)
        CaptionImage2.Name = "CaptionImage1"
        CaptionImage2.Size = New System.Drawing.Size(28, 28)
        Me.CaptionImages.Add(CaptionImage1)
        Me.CaptionImages.Add(CaptionImage2)
        CaptionLabel1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(70, 16)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "100.00"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1000, 674)
        Me.Controls.Add(Me.TabControlAdv1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMasterVentas"
        Me.ShowIcon = False
        Me.Text = "Gestión de ventas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PopupControlContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.panel9.ResumeLayout(False)
        Me.panel9.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents panel9 As System.Windows.Forms.Panel
    Private WithEvents treeViewAdv2 As Syncfusion.Windows.Forms.Tools.TreeViewAdv
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents TabControlAdv1 As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents TabPageAdv1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Private WithEvents dgvVentasTicket As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents TabPageAdv2 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Private WithEvents dgvVentasnormales As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripPanelItem1 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents rbPeriodo As Syncfusion.Windows.Forms.Tools.ToolStripRadioButton
    Friend WithEvents rbDia As Syncfusion.Windows.Forms.Tools.ToolStripRadioButton
    Private WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DropDownBarItem1 As Syncfusion.Windows.Forms.Tools.XPMenus.DropDownBarItem
    Friend WithEvents BarItem1 As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
    Friend WithEvents PopupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lstVenta As System.Windows.Forms.ListBox
    Private WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPageAdv3 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Private WithEvents dgvClientes As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents TabPageAdv4 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Private WithEvents dgvAnticipos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

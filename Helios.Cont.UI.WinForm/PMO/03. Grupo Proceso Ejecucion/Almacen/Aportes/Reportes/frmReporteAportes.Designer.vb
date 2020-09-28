<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteAportes
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteAportes))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.QRibbonCaption2 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.KryptonCheckButton6 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton7 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KryptonCheckButton8 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton9 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton10 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.rptCompras = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.KryptonCheckButton4 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton5 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.txtidProveedor = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.LinkProveedor = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.KryptonCheckButton1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton2 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        CType(Me.QRibbonCaption2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(3, 16)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(839, 25)
        Me.ReportViewer1.TabIndex = 5
        '
        'QRibbonCaption2
        '
        Me.QRibbonCaption2.Location = New System.Drawing.Point(3, 136)
        Me.QRibbonCaption2.Name = "QRibbonCaption2"
        Me.QRibbonCaption2.Size = New System.Drawing.Size(845, 28)
        Me.QRibbonCaption2.TabIndex = 292
        Me.QRibbonCaption2.Text = Nothing
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ReportViewer1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(845, 44)
        Me.GroupBox1.TabIndex = 295
        Me.GroupBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.KryptonCheckButton6)
        Me.Panel1.Controls.Add(Me.KryptonCheckButton7)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.KryptonCheckButton8)
        Me.Panel1.Controls.Add(Me.KryptonCheckButton9)
        Me.Panel1.Controls.Add(Me.KryptonCheckButton10)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(845, 70)
        Me.Panel1.TabIndex = 296
        '
        'KryptonCheckButton6
        '
        Me.KryptonCheckButton6.Location = New System.Drawing.Point(751, 12)
        Me.KryptonCheckButton6.Name = "KryptonCheckButton6"
        Me.KryptonCheckButton6.Size = New System.Drawing.Size(243, 25)
        Me.KryptonCheckButton6.TabIndex = 297
        Me.KryptonCheckButton6.Values.Text = "Por Periodo,Proveedor,Empresa,Establecimiento"
        '
        'KryptonCheckButton7
        '
        Me.KryptonCheckButton7.Location = New System.Drawing.Point(560, 12)
        Me.KryptonCheckButton7.Name = "KryptonCheckButton7"
        Me.KryptonCheckButton7.Size = New System.Drawing.Size(185, 25)
        Me.KryptonCheckButton7.TabIndex = 296
        Me.KryptonCheckButton7.Values.Text = "Por Periodo,Proveedor,Empresa"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(94, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(32, 20)
        Me.TextBox1.TabIndex = 295
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(94, 42)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(378, 20)
        Me.TextBox2.TabIndex = 294
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel1.Location = New System.Drawing.Point(476, 46)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(45, 13)
        Me.LinkLabel1.TabIndex = 293
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Cambiar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 292
        Me.Label1.Text = "Nombre/Razón:"
        '
        'KryptonCheckButton8
        '
        Me.KryptonCheckButton8.Location = New System.Drawing.Point(345, 12)
        Me.KryptonCheckButton8.Name = "KryptonCheckButton8"
        Me.KryptonCheckButton8.Size = New System.Drawing.Size(209, 25)
        Me.KryptonCheckButton8.TabIndex = 290
        Me.KryptonCheckButton8.Values.Text = "Por Periodo,Bonificaciones,Empresa"
        '
        'KryptonCheckButton9
        '
        Me.KryptonCheckButton9.Location = New System.Drawing.Point(209, 11)
        Me.KryptonCheckButton9.Name = "KryptonCheckButton9"
        Me.KryptonCheckButton9.Size = New System.Drawing.Size(130, 25)
        Me.KryptonCheckButton9.TabIndex = 287
        Me.KryptonCheckButton9.Values.Text = "Por Periodo,Empresa"
        '
        'KryptonCheckButton10
        '
        Me.KryptonCheckButton10.Location = New System.Drawing.Point(6, 11)
        Me.KryptonCheckButton10.Name = "KryptonCheckButton10"
        Me.KryptonCheckButton10.Size = New System.Drawing.Size(197, 25)
        Me.KryptonCheckButton10.TabIndex = 289
        Me.KryptonCheckButton10.Values.Text = "Por Periodo,Empresa,Establecimientos"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButton1, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 41)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(845, 25)
        Me.ToolStrip1.TabIndex = 293
        Me.ToolStrip1.Text = "ToolStrip4"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStripLabel1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripLabel1.Text = "PERIODO:"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.Yellow
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(141, 22)
        Me.ToolStripButton1.Text = "REPORTE DE COMPRAS"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.AliceBlue
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(54, 22)
        Me.ToolStripLabel2.Text = "01/2014"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(845, 25)
        Me.ToolStrip2.TabIndex = 294
        Me.ToolStrip2.Text = "ToolStrip3"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(110, 22)
        Me.ToolStripButton2.Text = "Reporte de Compras"
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'rptCompras
        '
        Me.rptCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCompras.Location = New System.Drawing.Point(0, 120)
        Me.rptCompras.Name = "rptCompras"
        Me.rptCompras.Size = New System.Drawing.Size(1168, 363)
        Me.rptCompras.TabIndex = 293
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel3.Controls.Add(Me.KryptonCheckButton4)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton5)
        Me.Panel3.Controls.Add(Me.txtidProveedor)
        Me.Panel3.Controls.Add(Me.txtProveedor)
        Me.Panel3.Controls.Add(Me.LinkProveedor)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton1)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1168, 70)
        Me.Panel3.TabIndex = 292
        '
        'KryptonCheckButton4
        '
        Me.KryptonCheckButton4.Location = New System.Drawing.Point(536, 12)
        Me.KryptonCheckButton4.Name = "KryptonCheckButton4"
        Me.KryptonCheckButton4.Size = New System.Drawing.Size(243, 25)
        Me.KryptonCheckButton4.TabIndex = 297
        Me.KryptonCheckButton4.Values.Text = "Por Periodo,Proveedor,Empresa,Establecimiento"
        '
        'KryptonCheckButton5
        '
        Me.KryptonCheckButton5.Location = New System.Drawing.Point(345, 12)
        Me.KryptonCheckButton5.Name = "KryptonCheckButton5"
        Me.KryptonCheckButton5.Size = New System.Drawing.Size(185, 25)
        Me.KryptonCheckButton5.TabIndex = 296
        Me.KryptonCheckButton5.Values.Text = "Por Periodo,Proveedor,Empresa"
        '
        'txtidProveedor
        '
        Me.txtidProveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtidProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidProveedor.Location = New System.Drawing.Point(94, 42)
        Me.txtidProveedor.Name = "txtidProveedor"
        Me.txtidProveedor.ReadOnly = True
        Me.txtidProveedor.Size = New System.Drawing.Size(32, 20)
        Me.txtidProveedor.TabIndex = 295
        Me.txtidProveedor.Text = "0"
        Me.txtidProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtidProveedor.Visible = False
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.Location = New System.Drawing.Point(94, 42)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(378, 20)
        Me.txtProveedor.TabIndex = 294
        '
        'LinkProveedor
        '
        Me.LinkProveedor.AutoSize = True
        Me.LinkProveedor.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkProveedor.Location = New System.Drawing.Point(476, 46)
        Me.LinkProveedor.Name = "LinkProveedor"
        Me.LinkProveedor.Size = New System.Drawing.Size(45, 13)
        Me.LinkProveedor.TabIndex = 293
        Me.LinkProveedor.TabStop = True
        Me.LinkProveedor.Text = "Cambiar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 292
        Me.Label6.Text = "Nombre/Razón:"
        '
        'KryptonCheckButton1
        '
        Me.KryptonCheckButton1.Location = New System.Drawing.Point(209, 11)
        Me.KryptonCheckButton1.Name = "KryptonCheckButton1"
        Me.KryptonCheckButton1.Size = New System.Drawing.Size(130, 25)
        Me.KryptonCheckButton1.TabIndex = 287
        Me.KryptonCheckButton1.Values.Text = "Por Periodo,Empresa"
        '
        'KryptonCheckButton2
        '
        Me.KryptonCheckButton2.Location = New System.Drawing.Point(6, 11)
        Me.KryptonCheckButton2.Name = "KryptonCheckButton2"
        Me.KryptonCheckButton2.Size = New System.Drawing.Size(197, 25)
        Me.KryptonCheckButton2.TabIndex = 289
        Me.KryptonCheckButton2.Values.Text = "Por Periodo,Empresa,Establecimientos"
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip4.BackgroundImage = CType(resources.GetObject("ToolStrip4.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.lblDescripcion, Me.lblPerido})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip4.Size = New System.Drawing.Size(1168, 25)
        Me.ToolStrip4.TabIndex = 286
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblTitulo.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(74, 22)
        Me.lblTitulo.Text = "PERIODO:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.Color.Yellow
        Me.lblDescripcion.Image = CType(resources.GetObject("lblDescripcion.Image"), System.Drawing.Image)
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(138, 22)
        Me.lblDescripcion.Text = "REPORTE DE APORTES"
        '
        'lblPerido
        '
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(54, 22)
        Me.lblPerido.Text = "01/2014"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.lblEstado})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(1168, 25)
        Me.ToolStrip3.TabIndex = 285
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Image = CType(resources.GetObject("lblEstado.Image"), System.Drawing.Image)
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(117, 22)
        Me.lblEstado.Text = "Consultas interactivas"
        '
        'frmReporteAportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 483)
        Me.Controls.Add(Me.rptCompras)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Controls.Add(Me.ToolStrip3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmReporteAportes"
        Me.Text = "Reportes interactivos: aportes."
        CType(Me.QRibbonCaption2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents QRibbonCaption2 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents KryptonCheckButton6 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton7 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KryptonCheckButton8 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton9 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton10 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents KryptonCheckButton4 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton5 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents txtidProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LinkProveedor As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents KryptonCheckButton1 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton2 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents rptCompras As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class

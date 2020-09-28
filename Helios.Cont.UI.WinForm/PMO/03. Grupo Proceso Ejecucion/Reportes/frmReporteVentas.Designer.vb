<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteVentas
    Inherits Qios.DevSuite.Components.Ribbon.QRibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteVentas))
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.KryptonCheckButton1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.txtidCliente = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.LinkProveedor = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.KryptonCheckButton2 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rptCompras = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.KryptonCheckButton3 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip4.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(1000, 28)
        Me.QRibbonCaption1.TabIndex = 1
        Me.QRibbonCaption1.Text = "Reporte Ventas"
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip4.BackgroundImage = CType(resources.GetObject("ToolStrip4.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.lblDescripcion, Me.lblPerido})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 53)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(1000, 25)
        Me.ToolStrip4.TabIndex = 285
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
        Me.lblDescripcion.Size = New System.Drawing.Size(125, 22)
        Me.lblDescripcion.Text = "REPORTE DE Ventas"
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
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(1000, 25)
        Me.ToolStrip3.TabIndex = 286
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
        Me.lblEstado.Size = New System.Drawing.Size(101, 22)
        Me.lblEstado.Text = "Reporte de Ventas"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.KryptonCheckButton3)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton1)
        Me.Panel3.Controls.Add(Me.txtidCliente)
        Me.Panel3.Controls.Add(Me.txtCliente)
        Me.Panel3.Controls.Add(Me.LinkProveedor)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 78)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1000, 70)
        Me.Panel3.TabIndex = 292
        '
        'KryptonCheckButton1
        '
        Me.KryptonCheckButton1.Location = New System.Drawing.Point(209, 11)
        Me.KryptonCheckButton1.Name = "KryptonCheckButton1"
        Me.KryptonCheckButton1.Size = New System.Drawing.Size(135, 25)
        Me.KryptonCheckButton1.TabIndex = 296
        Me.KryptonCheckButton1.Values.Text = "Por Pediodo,Empresa"
        '
        'txtidCliente
        '
        Me.txtidCliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtidCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidCliente.Location = New System.Drawing.Point(57, 42)
        Me.txtidCliente.Name = "txtidCliente"
        Me.txtidCliente.ReadOnly = True
        Me.txtidCliente.Size = New System.Drawing.Size(32, 20)
        Me.txtidCliente.TabIndex = 295
        Me.txtidCliente.Text = "0"
        Me.txtidCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtidCliente.Visible = False
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Location = New System.Drawing.Point(57, 42)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(378, 20)
        Me.txtCliente.TabIndex = 294
        '
        'LinkProveedor
        '
        Me.LinkProveedor.AutoSize = True
        Me.LinkProveedor.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkProveedor.Location = New System.Drawing.Point(441, 49)
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
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 292
        Me.Label6.Text = "Cliente:"
        '
        'KryptonCheckButton2
        '
        Me.KryptonCheckButton2.Location = New System.Drawing.Point(6, 11)
        Me.KryptonCheckButton2.Name = "KryptonCheckButton2"
        Me.KryptonCheckButton2.Size = New System.Drawing.Size(197, 25)
        Me.KryptonCheckButton2.TabIndex = 289
        Me.KryptonCheckButton2.Values.Text = "Por Periodo,Empresa,Establecimientos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rptCompras)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 148)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1000, 304)
        Me.GroupBox2.TabIndex = 293
        Me.GroupBox2.TabStop = False
        '
        'rptCompras
        '
        Me.rptCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCompras.Location = New System.Drawing.Point(3, 16)
        Me.rptCompras.Name = "rptCompras"
        Me.rptCompras.Size = New System.Drawing.Size(994, 285)
        Me.rptCompras.TabIndex = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboPeriodo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 29)
        '
        'cboPeriodo
        '
        Me.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboPeriodo.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(121, 21)
        '
        'KryptonCheckButton3
        '
        Me.KryptonCheckButton3.Location = New System.Drawing.Point(350, 11)
        Me.KryptonCheckButton3.Name = "KryptonCheckButton3"
        Me.KryptonCheckButton3.Size = New System.Drawing.Size(171, 25)
        Me.KryptonCheckButton3.TabIndex = 297
        Me.KryptonCheckButton3.Values.Text = "Por Pediodo,Empresa,Cliente"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmReporteVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 452)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "frmReporteVentas"
        Me.Text = "Reporte Ventas"
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtidCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents LinkProveedor As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents KryptonCheckButton2 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rptCompras As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents KryptonCheckButton1 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton3 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class

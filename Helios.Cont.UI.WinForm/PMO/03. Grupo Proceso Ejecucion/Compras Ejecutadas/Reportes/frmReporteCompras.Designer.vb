<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteCompras))
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rptCompras = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.KryptonCheckButton4 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton5 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.txtidProveedor = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.LinkProveedor = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.KryptonCheckButton3 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton2 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ToolStrip3.Size = New System.Drawing.Size(997, 25)
        Me.ToolStrip3.TabIndex = 284
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
        Me.lblEstado.Size = New System.Drawing.Size(110, 22)
        Me.lblEstado.Text = "Reporte de Compras"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(997, 430)
        Me.Panel1.TabIndex = 286
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 70)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(997, 360)
        Me.Panel2.TabIndex = 290
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rptCompras)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(997, 360)
        Me.GroupBox2.TabIndex = 288
        Me.GroupBox2.TabStop = False
        '
        'rptCompras
        '
        Me.rptCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCompras.Location = New System.Drawing.Point(3, 16)
        Me.rptCompras.Name = "rptCompras"
        Me.rptCompras.Size = New System.Drawing.Size(991, 341)
        Me.rptCompras.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.KryptonCheckButton4)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton5)
        Me.Panel3.Controls.Add(Me.txtidProveedor)
        Me.Panel3.Controls.Add(Me.txtProveedor)
        Me.Panel3.Controls.Add(Me.LinkProveedor)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton3)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton1)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(997, 70)
        Me.Panel3.TabIndex = 291
        '
        'KryptonCheckButton4
        '
        Me.KryptonCheckButton4.Location = New System.Drawing.Point(751, 12)
        Me.KryptonCheckButton4.Name = "KryptonCheckButton4"
        Me.KryptonCheckButton4.Size = New System.Drawing.Size(243, 25)
        Me.KryptonCheckButton4.TabIndex = 297
        Me.KryptonCheckButton4.Values.Text = "Por Periodo,Proveedor,Empresa,Establecimiento"
        '
        'KryptonCheckButton5
        '
        Me.KryptonCheckButton5.Location = New System.Drawing.Point(560, 12)
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
        Me.LinkProveedor.Size = New System.Drawing.Size(46, 13)
        Me.LinkProveedor.TabIndex = 293
        Me.LinkProveedor.TabStop = True
        Me.LinkProveedor.Text = "Cambiar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 292
        Me.Label6.Text = "Nombre/Razón:"
        '
        'KryptonCheckButton3
        '
        Me.KryptonCheckButton3.Location = New System.Drawing.Point(345, 12)
        Me.KryptonCheckButton3.Name = "KryptonCheckButton3"
        Me.KryptonCheckButton3.Size = New System.Drawing.Size(209, 25)
        Me.KryptonCheckButton3.TabIndex = 290
        Me.KryptonCheckButton3.Values.Text = "Por Periodo,Bonificaciones,Empresa"
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
        'Timer1
        '
        Me.Timer1.Interval = 1000
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
        'Timer2
        '
        Me.Timer2.Enabled = True
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
        Me.ToolStrip4.Size = New System.Drawing.Size(997, 25)
        Me.ToolStrip4.TabIndex = 283
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
        Me.lblDescripcion.Size = New System.Drawing.Size(141, 22)
        Me.lblDescripcion.Text = "REPORTE DE COMPRAS"
        '
        'lblPerido
        '
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(54, 22)
        Me.lblPerido.Text = "01/2014"
        '
        'frmReporteCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 480)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmReporteCompras"
        Me.Text = "Reporte Compras"
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents KryptonCheckButton1 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents KryptonCheckButton2 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents KryptonCheckButton3 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents txtidProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LinkProveedor As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents KryptonCheckButton5 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton4 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents rptCompras As Microsoft.Reporting.WinForms.ReportViewer
End Class

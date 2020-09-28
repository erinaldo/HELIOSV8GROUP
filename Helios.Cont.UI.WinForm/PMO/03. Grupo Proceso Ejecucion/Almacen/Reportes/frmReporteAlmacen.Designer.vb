<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteAlmacen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteAlmacen))
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.KryptonCheckButton6 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton5 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton4 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton3 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonCheckButton2 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.PanelProductos = New System.Windows.Forms.Panel()
        Me.lstProductos = New System.Windows.Forms.ListBox()
        Me.rptCompras = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbldesde = New System.Windows.Forms.Label()
        Me.lblhasta = New System.Windows.Forms.Label()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboalmacen = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cbotipoexistencia = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PanelProductos.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.ToolStrip3.Size = New System.Drawing.Size(1017, 25)
        Me.ToolStrip3.TabIndex = 288
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
        Me.lblEstado.Size = New System.Drawing.Size(108, 22)
        Me.lblEstado.Text = "Reporte de Almacen"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel3.Controls.Add(Me.KryptonCheckButton6)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton5)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton4)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton3)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton1)
        Me.Panel3.Controls.Add(Me.KryptonCheckButton2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1017, 47)
        Me.Panel3.TabIndex = 293
        '
        'KryptonCheckButton6
        '
        Me.KryptonCheckButton6.Location = New System.Drawing.Point(827, 11)
        Me.KryptonCheckButton6.Name = "KryptonCheckButton6"
        Me.KryptonCheckButton6.Size = New System.Drawing.Size(60, 25)
        Me.KryptonCheckButton6.TabIndex = 294
        Me.KryptonCheckButton6.Values.Text = "Kardex"
        '
        'KryptonCheckButton5
        '
        Me.KryptonCheckButton5.Location = New System.Drawing.Point(710, 11)
        Me.KryptonCheckButton5.Name = "KryptonCheckButton5"
        Me.KryptonCheckButton5.Size = New System.Drawing.Size(111, 25)
        Me.KryptonCheckButton5.TabIndex = 293
        Me.KryptonCheckButton5.Values.Text = "Guias de Remision"
        '
        'KryptonCheckButton4
        '
        Me.KryptonCheckButton4.Location = New System.Drawing.Point(478, 11)
        Me.KryptonCheckButton4.Name = "KryptonCheckButton4"
        Me.KryptonCheckButton4.Size = New System.Drawing.Size(226, 25)
        Me.KryptonCheckButton4.TabIndex = 292
        Me.KryptonCheckButton4.Values.Text = "Stock por Almacen y Tipo de Existencia"
        '
        'KryptonCheckButton3
        '
        Me.KryptonCheckButton3.Location = New System.Drawing.Point(330, 11)
        Me.KryptonCheckButton3.Name = "KryptonCheckButton3"
        Me.KryptonCheckButton3.Size = New System.Drawing.Size(142, 25)
        Me.KryptonCheckButton3.TabIndex = 291
        Me.KryptonCheckButton3.Values.Text = "Bind Car no Valorizado"
        '
        'KryptonCheckButton1
        '
        Me.KryptonCheckButton1.Location = New System.Drawing.Point(160, 11)
        Me.KryptonCheckButton1.Name = "KryptonCheckButton1"
        Me.KryptonCheckButton1.Size = New System.Drawing.Size(164, 25)
        Me.KryptonCheckButton1.TabIndex = 290
        Me.KryptonCheckButton1.Values.Text = "Por Establecimiento , Fecha"
        '
        'KryptonCheckButton2
        '
        Me.KryptonCheckButton2.Location = New System.Drawing.Point(6, 11)
        Me.KryptonCheckButton2.Name = "KryptonCheckButton2"
        Me.KryptonCheckButton2.Size = New System.Drawing.Size(148, 25)
        Me.KryptonCheckButton2.TabIndex = 289
        Me.KryptonCheckButton2.Values.Text = "Por Existencias , Fecha"
        '
        'PanelProductos
        '
        Me.PanelProductos.Controls.Add(Me.lstProductos)
        Me.PanelProductos.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelProductos.Location = New System.Drawing.Point(0, 97)
        Me.PanelProductos.Name = "PanelProductos"
        Me.PanelProductos.Size = New System.Drawing.Size(170, 327)
        Me.PanelProductos.TabIndex = 295
        '
        'lstProductos
        '
        Me.lstProductos.BackColor = System.Drawing.Color.Snow
        Me.lstProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstProductos.FormattingEnabled = True
        Me.lstProductos.Location = New System.Drawing.Point(0, 0)
        Me.lstProductos.Name = "lstProductos"
        Me.lstProductos.Size = New System.Drawing.Size(170, 327)
        Me.lstProductos.TabIndex = 0
        '
        'rptCompras
        '
        Me.rptCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCompras.Location = New System.Drawing.Point(170, 97)
        Me.rptCompras.Name = "rptCompras"
        Me.rptCompras.Size = New System.Drawing.Size(847, 327)
        Me.rptCompras.TabIndex = 296
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(463, 27)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(165, 20)
        Me.DateTimePicker1.TabIndex = 297
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(678, 27)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(168, 20)
        Me.DateTimePicker2.TabIndex = 298
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'lbldesde
        '
        Me.lbldesde.AutoSize = True
        Me.lbldesde.BackColor = System.Drawing.Color.Transparent
        Me.lbldesde.Location = New System.Drawing.Point(416, 33)
        Me.lbldesde.Name = "lbldesde"
        Me.lbldesde.Size = New System.Drawing.Size(41, 13)
        Me.lbldesde.TabIndex = 299
        Me.lbldesde.Text = "Desde:"
        '
        'lblhasta
        '
        Me.lblhasta.AutoSize = True
        Me.lblhasta.BackColor = System.Drawing.Color.Transparent
        Me.lblhasta.Location = New System.Drawing.Point(634, 33)
        Me.lblhasta.Name = "lblhasta"
        Me.lblhasta.Size = New System.Drawing.Size(39, 13)
        Me.lblhasta.TabIndex = 300
        Me.lblhasta.Text = "Hasta:"
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip4.BackgroundImage = CType(resources.GetObject("ToolStrip4.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.lblDescripcion, Me.lblPerido, Me.ToolStripSeparator1, Me.cboalmacen, Me.ToolStripSeparator2, Me.cbotipoexistencia})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(1017, 25)
        Me.ToolStrip4.TabIndex = 287
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
        Me.lblDescripcion.Size = New System.Drawing.Size(139, 22)
        Me.lblDescripcion.Text = "REPORTE DE ALMACEN"
        '
        'lblPerido
        '
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(54, 22)
        Me.lblPerido.Text = "01/2014"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cboalmacen
        '
        Me.cboalmacen.Name = "cboalmacen"
        Me.cboalmacen.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cbotipoexistencia
        '
        Me.cbotipoexistencia.Name = "cbotipoexistencia"
        Me.cbotipoexistencia.Size = New System.Drawing.Size(121, 25)
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
        'frmReporteAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 424)
        Me.Controls.Add(Me.lblhasta)
        Me.Controls.Add(Me.lbldesde)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.rptCompras)
        Me.Controls.Add(Me.PanelProductos)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteAlmacen"
        Me.Text = "Reportes Almacen"
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.PanelProductos.ResumeLayout(False)
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents KryptonCheckButton2 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents PanelProductos As System.Windows.Forms.Panel
    Friend WithEvents lstProductos As System.Windows.Forms.ListBox
    Friend WithEvents rptCompras As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbldesde As System.Windows.Forms.Label
    Friend WithEvents lblhasta As System.Windows.Forms.Label
    Friend WithEvents KryptonCheckButton1 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton3 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton4 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton5 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton6 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents cboalmacen As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cbotipoexistencia As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
End Class

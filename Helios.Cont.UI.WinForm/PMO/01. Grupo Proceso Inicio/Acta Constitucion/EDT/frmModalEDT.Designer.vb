<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalEDT
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalEDT))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.grbFechaEDT = New System.Windows.Forms.GroupBox()
        Me.nupHitos = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDiasTrabajados = New System.Windows.Forms.NumericUpDown()
        Me.lblNombreHito = New System.Windows.Forms.Label()
        Me.txtFechaIEDT = New System.Windows.Forms.DateTimePicker()
        Me.lblFecInicioEDT = New System.Windows.Forms.Label()
        Me.lblDescripcionEDT = New System.Windows.Forms.Label()
        Me.txtDescripcionEDT = New System.Windows.Forms.TextBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.lblId = New System.Windows.Forms.Label()
        Me.txtDirector = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCambiar = New System.Windows.Forms.Label()
        Me.txtIdResponsable = New System.Windows.Forms.TextBox()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.grbFechaEDT.SuspendLayout()
        CType(Me.nupHitos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasTrabajados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.ImprimirToolStripButton, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(419, 25)
        Me.ToolStrip1.TabIndex = 92
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(60, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'ImprimirToolStripButton
        '
        Me.ImprimirToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ImprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton.Name = "ImprimirToolStripButton"
        Me.ImprimirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimirToolStripButton.Text = "Volver"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'grbFechaEDT
        '
        Me.grbFechaEDT.BackColor = System.Drawing.Color.Transparent
        Me.grbFechaEDT.Controls.Add(Me.nupHitos)
        Me.grbFechaEDT.Controls.Add(Me.Label4)
        Me.grbFechaEDT.Controls.Add(Me.txtDiasTrabajados)
        Me.grbFechaEDT.Controls.Add(Me.lblNombreHito)
        Me.grbFechaEDT.Controls.Add(Me.txtFechaIEDT)
        Me.grbFechaEDT.Controls.Add(Me.lblFecInicioEDT)
        Me.grbFechaEDT.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.grbFechaEDT.Location = New System.Drawing.Point(9, 154)
        Me.grbFechaEDT.Name = "grbFechaEDT"
        Me.grbFechaEDT.Size = New System.Drawing.Size(405, 64)
        Me.grbFechaEDT.TabIndex = 489
        Me.grbFechaEDT.TabStop = False
        '
        'nupHitos
        '
        Me.nupHitos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.nupHitos.Enabled = False
        Me.nupHitos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupHitos.Location = New System.Drawing.Point(9, 31)
        Me.nupHitos.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.nupHitos.Name = "nupHitos"
        Me.nupHitos.Size = New System.Drawing.Size(92, 20)
        Me.nupHitos.TabIndex = 514
        Me.nupHitos.ThousandsSeparator = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(290, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 513
        Me.Label4.Text = "Dias de Atraso:"
        '
        'txtDiasTrabajados
        '
        Me.txtDiasTrabajados.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtDiasTrabajados.Enabled = False
        Me.txtDiasTrabajados.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasTrabajados.Location = New System.Drawing.Point(293, 32)
        Me.txtDiasTrabajados.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.txtDiasTrabajados.Name = "txtDiasTrabajados"
        Me.txtDiasTrabajados.Size = New System.Drawing.Size(86, 20)
        Me.txtDiasTrabajados.TabIndex = 512
        Me.txtDiasTrabajados.ThousandsSeparator = True
        '
        'lblNombreHito
        '
        Me.lblNombreHito.AutoSize = True
        Me.lblNombreHito.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreHito.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblNombreHito.Location = New System.Drawing.Point(6, 16)
        Me.lblNombreHito.Name = "lblNombreHito"
        Me.lblNombreHito.Size = New System.Drawing.Size(78, 13)
        Me.lblNombreHito.TabIndex = 511
        Me.lblNombreHito.Text = "N° Entregable:"
        '
        'txtFechaIEDT
        '
        Me.txtFechaIEDT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaIEDT.Location = New System.Drawing.Point(125, 32)
        Me.txtFechaIEDT.Name = "txtFechaIEDT"
        Me.txtFechaIEDT.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaIEDT.TabIndex = 4
        '
        'lblFecInicioEDT
        '
        Me.lblFecInicioEDT.AutoSize = True
        Me.lblFecInicioEDT.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblFecInicioEDT.Location = New System.Drawing.Point(122, 16)
        Me.lblFecInicioEDT.Name = "lblFecInicioEDT"
        Me.lblFecInicioEDT.Size = New System.Drawing.Size(81, 13)
        Me.lblFecInicioEDT.TabIndex = 62
        Me.lblFecInicioEDT.Text = "Fecha Entrega:"
        '
        'lblDescripcionEDT
        '
        Me.lblDescripcionEDT.AutoSize = True
        Me.lblDescripcionEDT.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripcionEDT.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDescripcionEDT.Location = New System.Drawing.Point(6, 234)
        Me.lblDescripcionEDT.Name = "lblDescripcionEDT"
        Me.lblDescripcionEDT.Size = New System.Drawing.Size(65, 13)
        Me.lblDescripcionEDT.TabIndex = 487
        Me.lblDescripcionEDT.Text = "Descripción:"
        '
        'txtDescripcionEDT
        '
        Me.txtDescripcionEDT.Location = New System.Drawing.Point(5, 250)
        Me.txtDescripcionEDT.Multiline = True
        Me.txtDescripcionEDT.Name = "txtDescripcionEDT"
        Me.txtDescripcionEDT.Size = New System.Drawing.Size(409, 56)
        Me.txtDescripcionEDT.TabIndex = 488
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = CType(resources.GetObject("ToolStrip2.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.lblEstado})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(419, 25)
        Me.ToolStrip2.TabIndex = 490
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(81, 22)
        Me.lblEstado.Text = "Nuevo Registro"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.BackColor = System.Drawing.Color.Transparent
        Me.lblId.Location = New System.Drawing.Point(524, 31)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(42, 13)
        Me.lblId.TabIndex = 491
        Me.lblId.Text = "ID0000"
        Me.lblId.Visible = False
        '
        'txtDirector
        '
        Me.txtDirector.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtDirector.Enabled = False
        Me.txtDirector.Location = New System.Drawing.Point(70, 76)
        Me.txtDirector.Name = "txtDirector"
        Me.txtDirector.ReadOnly = True
        Me.txtDirector.Size = New System.Drawing.Size(292, 20)
        Me.txtDirector.TabIndex = 493
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(6, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 492
        Me.Label2.Text = "Responsable:"
        '
        'lblCambiar
        '
        Me.lblCambiar.AutoSize = True
        Me.lblCambiar.BackColor = System.Drawing.Color.Transparent
        Me.lblCambiar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblCambiar.Location = New System.Drawing.Point(368, 79)
        Me.lblCambiar.Name = "lblCambiar"
        Me.lblCambiar.Size = New System.Drawing.Size(46, 13)
        Me.lblCambiar.TabIndex = 494
        Me.lblCambiar.Text = "Cambiar"
        '
        'txtIdResponsable
        '
        Me.txtIdResponsable.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtIdResponsable.Enabled = False
        Me.txtIdResponsable.Location = New System.Drawing.Point(9, 76)
        Me.txtIdResponsable.Name = "txtIdResponsable"
        Me.txtIdResponsable.ReadOnly = True
        Me.txtIdResponsable.Size = New System.Drawing.Size(55, 20)
        Me.txtIdResponsable.TabIndex = 495
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(9, 122)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(405, 20)
        Me.txtConcepto.TabIndex = 509
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(6, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 508
        Me.Label1.Text = "Concepto:"
        '
        'frmModalEDT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(419, 312)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIdResponsable)
        Me.Controls.Add(Me.lblCambiar)
        Me.Controls.Add(Me.txtDirector)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.grbFechaEDT)
        Me.Controls.Add(Me.lblDescripcionEDT)
        Me.Controls.Add(Me.txtDescripcionEDT)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmModalEDT"
        Me.Text = "E.D.T."
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grbFechaEDT.ResumeLayout(False)
        Me.grbFechaEDT.PerformLayout()
        CType(Me.nupHitos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasTrabajados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grbFechaEDT As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaIEDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecInicioEDT As System.Windows.Forms.Label
    Friend WithEvents lblDescripcionEDT As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionEDT As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents lblCambiar As System.Windows.Forms.Label
    Friend WithEvents txtDirector As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdResponsable As System.Windows.Forms.TextBox
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nupHitos As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDiasTrabajados As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblNombreHito As System.Windows.Forms.Label
End Class

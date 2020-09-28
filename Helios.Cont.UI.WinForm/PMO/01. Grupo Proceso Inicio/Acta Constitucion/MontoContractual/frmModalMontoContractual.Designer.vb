<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalMontoContractual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalMontoContractual))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblNombreHito = New System.Windows.Forms.Label()
        Me.lblDescripcionEDT = New System.Windows.Forms.Label()
        Me.grbFechaEDT = New System.Windows.Forms.GroupBox()
        Me.nupHitos = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDiasTrabajados = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.NumericUpDown()
        Me.nupPorcentaje = New System.Windows.Forms.NumericUpDown()
        Me.txtFechaFacturacion = New System.Windows.Forms.DateTimePicker()
        Me.lblFecInicioEDT = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grbFechaEDT.SuspendLayout()
        CType(Me.nupHitos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasTrabajados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupPorcentaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ToolStrip2.Size = New System.Drawing.Size(506, 25)
        Me.ToolStrip2.TabIndex = 492
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
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.ImprimirToolStripButton, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(506, 25)
        Me.ToolStrip1.TabIndex = 491
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
        'lblNombreHito
        '
        Me.lblNombreHito.AutoSize = True
        Me.lblNombreHito.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreHito.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblNombreHito.Location = New System.Drawing.Point(6, 16)
        Me.lblNombreHito.Name = "lblNombreHito"
        Me.lblNombreHito.Size = New System.Drawing.Size(84, 13)
        Me.lblNombreHito.TabIndex = 493
        Me.lblNombreHito.Text = "Numero de hito:"
        '
        'lblDescripcionEDT
        '
        Me.lblDescripcionEDT.AutoSize = True
        Me.lblDescripcionEDT.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripcionEDT.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDescripcionEDT.Location = New System.Drawing.Point(13, 59)
        Me.lblDescripcionEDT.Name = "lblDescripcionEDT"
        Me.lblDescripcionEDT.Size = New System.Drawing.Size(57, 13)
        Me.lblDescripcionEDT.TabIndex = 497
        Me.lblDescripcionEDT.Text = "Concepto:"
        '
        'grbFechaEDT
        '
        Me.grbFechaEDT.BackColor = System.Drawing.Color.Transparent
        Me.grbFechaEDT.Controls.Add(Me.nupHitos)
        Me.grbFechaEDT.Controls.Add(Me.Label4)
        Me.grbFechaEDT.Controls.Add(Me.txtDiasTrabajados)
        Me.grbFechaEDT.Controls.Add(Me.Label1)
        Me.grbFechaEDT.Controls.Add(Me.Label3)
        Me.grbFechaEDT.Controls.Add(Me.txtMonto)
        Me.grbFechaEDT.Controls.Add(Me.nupPorcentaje)
        Me.grbFechaEDT.Controls.Add(Me.lblNombreHito)
        Me.grbFechaEDT.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.grbFechaEDT.Location = New System.Drawing.Point(16, 111)
        Me.grbFechaEDT.Name = "grbFechaEDT"
        Me.grbFechaEDT.Size = New System.Drawing.Size(485, 63)
        Me.grbFechaEDT.TabIndex = 499
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
        Me.nupHitos.Size = New System.Drawing.Size(95, 20)
        Me.nupHitos.TabIndex = 510
        Me.nupHitos.ThousandsSeparator = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(350, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 503
        Me.Label4.Text = "Dias de atraso:"
        '
        'txtDiasTrabajados
        '
        Me.txtDiasTrabajados.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtDiasTrabajados.Enabled = False
        Me.txtDiasTrabajados.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasTrabajados.Location = New System.Drawing.Point(353, 32)
        Me.txtDiasTrabajados.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.txtDiasTrabajados.Name = "txtDiasTrabajados"
        Me.txtDiasTrabajados.Size = New System.Drawing.Size(95, 20)
        Me.txtDiasTrabajados.TabIndex = 502
        Me.txtDiasTrabajados.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(122, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 503
        Me.Label1.Text = "%:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(235, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 501
        Me.Label3.Text = "Monto(más IGV)"
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtMonto.DecimalPlaces = 2
        Me.txtMonto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(235, 31)
        Me.txtMonto.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(95, 20)
        Me.txtMonto.TabIndex = 500
        Me.txtMonto.ThousandsSeparator = True
        '
        'nupPorcentaje
        '
        Me.nupPorcentaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.nupPorcentaje.DecimalPlaces = 2
        Me.nupPorcentaje.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupPorcentaje.Location = New System.Drawing.Point(125, 32)
        Me.nupPorcentaje.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.nupPorcentaje.Name = "nupPorcentaje"
        Me.nupPorcentaje.Size = New System.Drawing.Size(92, 20)
        Me.nupPorcentaje.TabIndex = 502
        Me.nupPorcentaje.ThousandsSeparator = True
        '
        'txtFechaFacturacion
        '
        Me.txtFechaFacturacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaFacturacion.Location = New System.Drawing.Point(351, 75)
        Me.txtFechaFacturacion.Name = "txtFechaFacturacion"
        Me.txtFechaFacturacion.Size = New System.Drawing.Size(150, 21)
        Me.txtFechaFacturacion.TabIndex = 4
        '
        'lblFecInicioEDT
        '
        Me.lblFecInicioEDT.AutoSize = True
        Me.lblFecInicioEDT.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblFecInicioEDT.Location = New System.Drawing.Point(348, 59)
        Me.lblFecInicioEDT.Name = "lblFecInicioEDT"
        Me.lblFecInicioEDT.Size = New System.Drawing.Size(97, 13)
        Me.lblFecInicioEDT.TabIndex = 62
        Me.lblFecInicioEDT.Text = "Fecha facturación:"
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(16, 75)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(318, 21)
        Me.txtConcepto.TabIndex = 507
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(12, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Observaciones:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(15, 204)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(486, 73)
        Me.txtObservaciones.TabIndex = 509
        '
        'frmModalMontoContractual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(506, 287)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.txtFechaFacturacion)
        Me.Controls.Add(Me.lblFecInicioEDT)
        Me.Controls.Add(Me.grbFechaEDT)
        Me.Controls.Add(Me.lblDescripcionEDT)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmModalMontoContractual"
        Me.Text = "Monto Contractual"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grbFechaEDT.ResumeLayout(False)
        Me.grbFechaEDT.PerformLayout()
        CType(Me.nupHitos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasTrabajados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupPorcentaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblNombreHito As System.Windows.Forms.Label
    Friend WithEvents lblDescripcionEDT As System.Windows.Forms.Label
    Friend WithEvents grbFechaEDT As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaFacturacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecInicioEDT As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDiasTrabajados As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.NumericUpDown
    Friend WithEvents nupPorcentaje As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents nupHitos As System.Windows.Forms.NumericUpDown
End Class

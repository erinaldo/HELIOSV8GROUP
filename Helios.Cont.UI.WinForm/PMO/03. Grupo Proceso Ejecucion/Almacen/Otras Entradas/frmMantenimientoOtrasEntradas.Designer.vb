<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoOtrasEntradas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimientoOtrasEntradas))
        Me.lsvProduccion = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsvProduccion
        '
        Me.lsvProduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProduccion.FullRowSelect = True
        Me.lsvProduccion.GridLines = True
        Me.lsvProduccion.HideSelection = False
        Me.lsvProduccion.Location = New System.Drawing.Point(0, 50)
        Me.lsvProduccion.MultiSelect = False
        Me.lsvProduccion.Name = "lsvProduccion"
        Me.lsvProduccion.Size = New System.Drawing.Size(704, 323)
        Me.lsvProduccion.TabIndex = 287
        Me.lsvProduccion.UseCompatibleStateImageBehavior = False
        Me.lsvProduccion.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
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
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.lblEstado, Me.ToolStripSeparator1, Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.ImprimirToolStripButton, Me.toolStripSeparator})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(704, 25)
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
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblEstado.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ok4
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(213, 22)
        Me.lblEstado.Text = "Registro de Otras entradas (Almacén)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.NuevoToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(58, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AbrirToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.AbrirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.pencil
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(63, 22)
        Me.GuardarToolStripButton.Text = "Eliminar"
        '
        'ImprimirToolStripButton
        '
        Me.ImprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimirToolStripButton.Image = CType(resources.GetObject("ImprimirToolStripButton.Image"), System.Drawing.Image)
        Me.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton.Name = "ImprimirToolStripButton"
        Me.ImprimirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimirToolStripButton.Text = "&Imprimir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.White
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.ToolStripButton7, Me.lblDescripcion, Me.lblPerido})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip4.Size = New System.Drawing.Size(704, 25)
        Me.ToolStrip4.TabIndex = 285
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblTitulo.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(74, 22)
        Me.lblTitulo.Text = "PERIODO:"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Salir"
        Me.ToolStripButton7.Visible = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblDescripcion.Image = CType(resources.GetObject("lblDescripcion.Image"), System.Drawing.Image)
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(198, 22)
        Me.lblDescripcion.Text = "LISTADO DE OTROS MOVIMIENTOS"
        '
        'lblPerido
        '
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(54, 22)
        Me.lblPerido.Text = "01/2014"
        '
        'frmMantenimientoOtrasEntradas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 373)
        Me.Controls.Add(Me.lsvProduccion)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Name = "frmMantenimientoOtrasEntradas"
        Me.Text = "Otros Movimientos de Almacén"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lsvProduccion As System.Windows.Forms.ListView
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
End Class

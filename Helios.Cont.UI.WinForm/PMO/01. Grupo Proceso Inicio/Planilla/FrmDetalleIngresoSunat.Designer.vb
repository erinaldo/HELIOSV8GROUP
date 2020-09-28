<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalleIngresoSunat
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetalleIngresoSunat))
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.INGRESOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INGRESOSASIGNACIONESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INGRESOSBONIFICACIONESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INGRESOSINDEMNIZACIONESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DESCUENTOSALTRABAJADORToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONCEPTOSVARIOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OTROSCONCEPTOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvIngresoSunat = New System.Windows.Forms.DataGridView()
        Me.idIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodSunat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CtaCont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idpadre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvIngresoSunat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtDescripcion.Location = New System.Drawing.Point(93, 24)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(352, 20)
        Me.txtDescripcion.TabIndex = 96
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(21, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Descripcion:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(482, 27)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(89, 13)
        Me.LinkLabel1.TabIndex = 97
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Conceptos Sunat"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INGRESOSToolStripMenuItem, Me.INGRESOSASIGNACIONESToolStripMenuItem, Me.INGRESOSBONIFICACIONESToolStripMenuItem, Me.INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem, Me.INGRESOSINDEMNIZACIONESToolStripMenuItem, Me.DESCUENTOSALTRABAJADORToolStripMenuItem, Me.CONCEPTOSVARIOSToolStripMenuItem, Me.OTROSCONCEPTOSToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(312, 180)
        '
        'INGRESOSToolStripMenuItem
        '
        Me.INGRESOSToolStripMenuItem.Name = "INGRESOSToolStripMenuItem"
        Me.INGRESOSToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.INGRESOSToolStripMenuItem.Text = "INGRESOS"
        '
        'INGRESOSASIGNACIONESToolStripMenuItem
        '
        Me.INGRESOSASIGNACIONESToolStripMenuItem.Name = "INGRESOSASIGNACIONESToolStripMenuItem"
        Me.INGRESOSASIGNACIONESToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.INGRESOSASIGNACIONESToolStripMenuItem.Text = "INGRESOS: ASIGNACIONES"
        '
        'INGRESOSBONIFICACIONESToolStripMenuItem
        '
        Me.INGRESOSBONIFICACIONESToolStripMenuItem.Name = "INGRESOSBONIFICACIONESToolStripMenuItem"
        Me.INGRESOSBONIFICACIONESToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.INGRESOSBONIFICACIONESToolStripMenuItem.Text = "INGRESOS: BONIFICACIONES"
        '
        'INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem
        '
        Me.INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem.Name = "INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem"
        Me.INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem.Text = "INGRESOS: GRATIFICACIONES/AGUINALDOS"
        '
        'INGRESOSINDEMNIZACIONESToolStripMenuItem
        '
        Me.INGRESOSINDEMNIZACIONESToolStripMenuItem.Name = "INGRESOSINDEMNIZACIONESToolStripMenuItem"
        Me.INGRESOSINDEMNIZACIONESToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.INGRESOSINDEMNIZACIONESToolStripMenuItem.Text = "INGRESOS: INDEMNIZACIONES"
        '
        'DESCUENTOSALTRABAJADORToolStripMenuItem
        '
        Me.DESCUENTOSALTRABAJADORToolStripMenuItem.Name = "DESCUENTOSALTRABAJADORToolStripMenuItem"
        Me.DESCUENTOSALTRABAJADORToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.DESCUENTOSALTRABAJADORToolStripMenuItem.Text = "DESCUENTOS AL TRABAJADOR"
        '
        'CONCEPTOSVARIOSToolStripMenuItem
        '
        Me.CONCEPTOSVARIOSToolStripMenuItem.Name = "CONCEPTOSVARIOSToolStripMenuItem"
        Me.CONCEPTOSVARIOSToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.CONCEPTOSVARIOSToolStripMenuItem.Text = "CONCEPTOS VARIOS"
        '
        'OTROSCONCEPTOSToolStripMenuItem
        '
        Me.OTROSCONCEPTOSToolStripMenuItem.Name = "OTROSCONCEPTOSToolStripMenuItem"
        Me.OTROSCONCEPTOSToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.OTROSCONCEPTOSToolStripMenuItem.Text = "OTROS CONCEPTOS"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtCodigo.Location = New System.Drawing.Point(93, 46)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(53, 20)
        Me.txtCodigo.TabIndex = 98
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtDescripcion)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(812, 72)
        Me.Panel1.TabIndex = 103
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(21, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Codigo:"
        '
        'dgvIngresoSunat
        '
        Me.dgvIngresoSunat.AllowUserToAddRows = False
        Me.dgvIngresoSunat.AllowUserToResizeRows = False
        Me.dgvIngresoSunat.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvIngresoSunat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIngresoSunat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idIngreso, Me.CodSunat, Me.Descripcion, Me.CtaCont, Me.idpadre})
        Me.dgvIngresoSunat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIngresoSunat.Location = New System.Drawing.Point(0, 122)
        Me.dgvIngresoSunat.Name = "dgvIngresoSunat"
        Me.dgvIngresoSunat.ReadOnly = True
        Me.dgvIngresoSunat.RowHeadersVisible = False
        Me.dgvIngresoSunat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIngresoSunat.Size = New System.Drawing.Size(812, 281)
        Me.dgvIngresoSunat.TabIndex = 485
        '
        'idIngreso
        '
        Me.idIngreso.HeaderText = "idIngresoSunat"
        Me.idIngreso.Name = "idIngreso"
        Me.idIngreso.ReadOnly = True
        '
        'CodSunat
        '
        Me.CodSunat.HeaderText = "CodigoSunat"
        Me.CodSunat.Name = "CodSunat"
        Me.CodSunat.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "CuentaContable"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'CtaCont
        '
        Me.CtaCont.HeaderText = "Descripcion"
        Me.CtaCont.Name = "CtaCont"
        Me.CtaCont.ReadOnly = True
        Me.CtaCont.Width = 420
        '
        'idpadre
        '
        Me.idpadre.HeaderText = "IdPadre"
        Me.idpadre.Name = "idpadre"
        Me.idpadre.ReadOnly = True
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
        Me.ToolStrip2.Size = New System.Drawing.Size(812, 25)
        Me.ToolStrip2.TabIndex = 101
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripButton, Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.ImprimirToolStripButton1, Me.toolStripSeparator, Me.AyudaToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(812, 25)
        Me.ToolStrip1.TabIndex = 100
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(58, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.pencil
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.cross
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(63, 22)
        Me.GuardarToolStripButton.Text = "Eliminar"
        '
        'ImprimirToolStripButton1
        '
        Me.ImprimirToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimirToolStripButton1.Image = CType(resources.GetObject("ImprimirToolStripButton1.Image"), System.Drawing.Image)
        Me.ImprimirToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton1.Name = "ImprimirToolStripButton1"
        Me.ImprimirToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ImprimirToolStripButton1.Text = "&Imprimir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'AyudaToolStripButton
        '
        Me.AyudaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AyudaToolStripButton.Image = CType(resources.GetObject("AyudaToolStripButton.Image"), System.Drawing.Image)
        Me.AyudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AyudaToolStripButton.Name = "AyudaToolStripButton"
        Me.AyudaToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AyudaToolStripButton.Text = "Ay&uda"
        '
        'FrmDetalleIngresoSunat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 403)
        Me.Controls.Add(Me.dgvIngresoSunat)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmDetalleIngresoSunat"
        Me.Text = "DetalleIngresoSunat"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvIngresoSunat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvIngresoSunat As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AyudaToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents INGRESOSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INGRESOSASIGNACIONESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INGRESOSBONIFICACIONESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INGRESOSGRATIFICACIONESAGUINALDOSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INGRESOSINDEMNIZACIONESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DESCUENTOSALTRABAJADORToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONCEPTOSVARIOSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OTROSCONCEPTOSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents idIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodSunat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CtaCont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idpadre As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

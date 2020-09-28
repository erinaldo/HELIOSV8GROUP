<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActaConstitucionAprobado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActaConstitucionAprobado))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvPropuesta = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EXISTENCIAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SERVICIOCONTRATOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RECURSOSHUMANOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.idActividad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIdEx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFechaIn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoRecurso = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.colDetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostoUni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.igv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrecFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSustento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReferenciaSustento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtrosDeduc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeducPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalRetencion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvPropuesta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPropuesta
        '
        Me.dgvPropuesta.AllowUserToAddRows = False
        Me.dgvPropuesta.AllowUserToResizeRows = False
        Me.dgvPropuesta.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvPropuesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPropuesta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idActividad, Me.colIdEx, Me.colFechaIn2, Me.colDesc, Me.TipoRecurso, Me.colDetalle, Me.colUM, Me.colCan, Me.colCostoUni, Me.igv, Me.colPrecFinal, Me.colSustento, Me.colReferenciaSustento, Me.Total, Me.OtrosDeduc, Me.DeducPlanilla, Me.TotalAporte, Me.TotalRetencion, Me.idItem})
        Me.dgvPropuesta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPropuesta.Location = New System.Drawing.Point(0, 50)
        Me.dgvPropuesta.Name = "dgvPropuesta"
        Me.dgvPropuesta.ReadOnly = True
        Me.dgvPropuesta.RowHeadersVisible = False
        Me.dgvPropuesta.Size = New System.Drawing.Size(669, 347)
        Me.dgvPropuesta.TabIndex = 484
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(669, 25)
        Me.ToolStrip1.TabIndex = 485
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Volver"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        Me.ToolStrip2.Size = New System.Drawing.Size(669, 25)
        Me.ToolStrip2.TabIndex = 486
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
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel1.Location = New System.Drawing.Point(557, 34)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(112, 13)
        Me.LinkLabel1.TabIndex = 489
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Cambiar Tipo Recurso"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXISTENCIAToolStripMenuItem, Me.SERVICIOCONTRATOToolStripMenuItem, Me.RECURSOSHUMANOSToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(183, 70)
        '
        'EXISTENCIAToolStripMenuItem
        '
        Me.EXISTENCIAToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue
        Me.EXISTENCIAToolStripMenuItem.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.t_shirt
        Me.EXISTENCIAToolStripMenuItem.Name = "EXISTENCIAToolStripMenuItem"
        Me.EXISTENCIAToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.EXISTENCIAToolStripMenuItem.Text = "EXISTENCIA"
        '
        'SERVICIOCONTRATOToolStripMenuItem
        '
        Me.SERVICIOCONTRATOToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue
        Me.SERVICIOCONTRATOToolStripMenuItem.Image = CType(resources.GetObject("SERVICIOCONTRATOToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SERVICIOCONTRATOToolStripMenuItem.Name = "SERVICIOCONTRATOToolStripMenuItem"
        Me.SERVICIOCONTRATOToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.SERVICIOCONTRATOToolStripMenuItem.Text = "SERVICIO-CONTRATO"
        '
        'RECURSOSHUMANOSToolStripMenuItem
        '
        Me.RECURSOSHUMANOSToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue
        Me.RECURSOSHUMANOSToolStripMenuItem.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.aaa
        Me.RECURSOSHUMANOSToolStripMenuItem.Name = "RECURSOSHUMANOSToolStripMenuItem"
        Me.RECURSOSHUMANOSToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.RECURSOSHUMANOSToolStripMenuItem.Text = "RECURSOS HUMANOS"
        '
        'idActividad
        '
        Me.idActividad.HeaderText = "Actividad"
        Me.idActividad.Name = "idActividad"
        Me.idActividad.ReadOnly = True
        Me.idActividad.Visible = False
        '
        'colIdEx
        '
        Me.colIdEx.HeaderText = "IdItem"
        Me.colIdEx.Name = "colIdEx"
        Me.colIdEx.ReadOnly = True
        Me.colIdEx.Visible = False
        Me.colIdEx.Width = 20
        '
        'colFechaIn2
        '
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.colFechaIn2.DefaultCellStyle = DataGridViewCellStyle1
        Me.colFechaIn2.HeaderText = "Fecha Ing."
        Me.colFechaIn2.Name = "colFechaIn2"
        Me.colFechaIn2.ReadOnly = True
        Me.colFechaIn2.Width = 70
        '
        'colDesc
        '
        Me.colDesc.HeaderText = "Descripción"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Width = 200
        '
        'TipoRecurso
        '
        Me.TipoRecurso.HeaderText = "Tipo Recurso"
        Me.TipoRecurso.Name = "TipoRecurso"
        Me.TipoRecurso.ReadOnly = True
        Me.TipoRecurso.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TipoRecurso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TipoRecurso.Width = 130
        '
        'colDetalle
        '
        Me.colDetalle.HeaderText = "Detalle extra"
        Me.colDetalle.Name = "colDetalle"
        Me.colDetalle.ReadOnly = True
        '
        'colUM
        '
        Me.colUM.HeaderText = "U.M."
        Me.colUM.Name = "colUM"
        Me.colUM.ReadOnly = True
        Me.colUM.Width = 50
        '
        'colCan
        '
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.colCan.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCan.HeaderText = "Cant."
        Me.colCan.Name = "colCan"
        Me.colCan.ReadOnly = True
        Me.colCan.Width = 55
        '
        'colCostoUni
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.colCostoUni.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCostoUni.HeaderText = "Costo Unit."
        Me.colCostoUni.Name = "colCostoUni"
        Me.colCostoUni.ReadOnly = True
        Me.colCostoUni.Width = 60
        '
        'igv
        '
        Me.igv.HeaderText = "Importe igv"
        Me.igv.Name = "igv"
        Me.igv.ReadOnly = True
        '
        'colPrecFinal
        '
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.colPrecFinal.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPrecFinal.HeaderText = "Precio Final"
        Me.colPrecFinal.Name = "colPrecFinal"
        Me.colPrecFinal.ReadOnly = True
        Me.colPrecFinal.Width = 65
        '
        'colSustento
        '
        Me.colSustento.HeaderText = "Tipo"
        Me.colSustento.Name = "colSustento"
        Me.colSustento.ReadOnly = True
        '
        'colReferenciaSustento
        '
        Me.colReferenciaSustento.HeaderText = "Sustento"
        Me.colReferenciaSustento.Name = "colReferenciaSustento"
        Me.colReferenciaSustento.ReadOnly = True
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Visible = False
        '
        'OtrosDeduc
        '
        Me.OtrosDeduc.HeaderText = "OtrosDeduc"
        Me.OtrosDeduc.Name = "OtrosDeduc"
        Me.OtrosDeduc.ReadOnly = True
        Me.OtrosDeduc.Visible = False
        '
        'DeducPlanilla
        '
        Me.DeducPlanilla.HeaderText = "DeducPlanilla"
        Me.DeducPlanilla.Name = "DeducPlanilla"
        Me.DeducPlanilla.ReadOnly = True
        Me.DeducPlanilla.Visible = False
        '
        'TotalAporte
        '
        Me.TotalAporte.HeaderText = "Total Aporte"
        Me.TotalAporte.Name = "TotalAporte"
        Me.TotalAporte.ReadOnly = True
        Me.TotalAporte.Visible = False
        '
        'TotalRetencion
        '
        Me.TotalRetencion.HeaderText = "Total Retencion"
        Me.TotalRetencion.Name = "TotalRetencion"
        Me.TotalRetencion.ReadOnly = True
        Me.TotalRetencion.Visible = False
        '
        'idItem
        '
        Me.idItem.HeaderText = "IdItem"
        Me.idItem.Name = "idItem"
        Me.idItem.ReadOnly = True
        Me.idItem.Visible = False
        '
        'frmActaConstitucionAprobado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 397)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.dgvPropuesta)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmActaConstitucionAprobado"
        CType(Me.dgvPropuesta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPropuesta As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EXISTENCIAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SERVICIOCONTRATOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RECURSOSHUMANOSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents idActividad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIdEx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaIn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoRecurso As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colDetalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCostoUni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents igv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecFinal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSustento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReferenciaSustento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtrosDeduc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeducPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalRetencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idItem As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

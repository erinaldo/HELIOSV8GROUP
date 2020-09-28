<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimientoCaja))
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripButton()
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.lsvProduccion = New System.Windows.Forms.ListView()
        Me.colIDDocumento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovimiento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columerDo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCajaOrigen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCajaDes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMoneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImporteMN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoCambio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip3.BackgroundImage = CType(resources.GetObject("ToolStrip3.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.lblEstado, Me.ToolStripSeparator1, Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.toolStripSeparator})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(844, 25)
        Me.ToolStrip3.TabIndex = 287
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
        Me.lblEstado.ForeColor = System.Drawing.Color.Navy
        Me.lblEstado.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ok4
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(176, 22)
        Me.lblEstado.Text = "Registro movimientos de caja."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.NuevoToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(58, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AbrirToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.AbrirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ResumeRequest
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GuardarToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_eliminar
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(63, 22)
        Me.GuardarToolStripButton.Text = "Eliminar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip4.BackgroundImage = CType(resources.GetObject("ToolStrip4.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.ToolStripButton7, Me.lblDescripcion, Me.lblPeriodo})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(844, 25)
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
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Salir"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblDescripcion.Image = CType(resources.GetObject("lblDescripcion.Image"), System.Drawing.Image)
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(205, 22)
        Me.lblDescripcion.Text = "LISTADO DE MOVIMIENTOS DE CAJA"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPeriodo.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(54, 22)
        Me.lblPeriodo.Text = "01/2014"
        '
        'lsvProduccion
        '
        Me.lsvProduccion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIDDocumento, Me.colFecha, Me.colMovimiento, Me.colTipoDoc, Me.columerDo, Me.colCajaOrigen, Me.colCajaDes, Me.colMoneda, Me.colImporteMN, Me.colTipoCambio, Me.colME})
        Me.lsvProduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProduccion.FullRowSelect = True
        Me.lsvProduccion.GridLines = True
        Me.lsvProduccion.HideSelection = False
        Me.lsvProduccion.Location = New System.Drawing.Point(0, 50)
        Me.lsvProduccion.MultiSelect = False
        Me.lsvProduccion.Name = "lsvProduccion"
        Me.lsvProduccion.Size = New System.Drawing.Size(844, 388)
        Me.lsvProduccion.TabIndex = 288
        Me.lsvProduccion.UseCompatibleStateImageBehavior = False
        Me.lsvProduccion.View = System.Windows.Forms.View.Details
        '
        'colIDDocumento
        '
        Me.colIDDocumento.Text = "ID"
        Me.colIDDocumento.Width = 0
        '
        'colFecha
        '
        Me.colFecha.Text = "Fecha Mov."
        Me.colFecha.Width = 159
        '
        'colMovimiento
        '
        Me.colMovimiento.Text = "Movimiento"
        Me.colMovimiento.Width = 176
        '
        'colTipoDoc
        '
        Me.colTipoDoc.Text = "Tipo Comp."
        Me.colTipoDoc.Width = 134
        '
        'columerDo
        '
        Me.columerDo.Text = "Numero doc'"
        Me.columerDo.Width = 95
        '
        'colCajaOrigen
        '
        Me.colCajaOrigen.Text = "Caja origen"
        Me.colCajaOrigen.Width = 131
        '
        'colCajaDes
        '
        Me.colCajaDes.Text = "Caja destino"
        Me.colCajaDes.Width = 121
        '
        'colMoneda
        '
        Me.colMoneda.Text = "Moneda"
        Me.colMoneda.Width = 53
        '
        'colImporteMN
        '
        Me.colImporteMN.Text = "Importe mn."
        Me.colImporteMN.Width = 78
        '
        'colTipoCambio
        '
        Me.colTipoCambio.Text = "t/c."
        Me.colTipoCambio.Width = 41
        '
        'colME
        '
        Me.colME.Text = "Importe me."
        Me.colME.Width = 82
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
        'frmMantenimientoCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 438)
        Me.Controls.Add(Me.lsvProduccion)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMantenimientoCaja"
        Me.Text = "frmMantenimientoCaja"
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPeriodo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lsvProduccion As System.Windows.Forms.ListView
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents colIDDocumento As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMovimiento As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipoDoc As System.Windows.Forms.ColumnHeader
    Friend WithEvents columerDo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCajaOrigen As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCajaDes As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImporteMN As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipoCambio As System.Windows.Forms.ColumnHeader
    Friend WithEvents colME As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
End Class

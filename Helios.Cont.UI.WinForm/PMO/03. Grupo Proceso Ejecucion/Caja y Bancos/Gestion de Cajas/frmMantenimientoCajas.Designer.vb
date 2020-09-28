<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoCajas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimientoCajas))
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lsvCajas = New System.Windows.Forms.ListView()
        Me.colIdCaja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCaja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.COLcUENTA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMoneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEliminarCaja = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lsvCajaUsuario = New System.Windows.Forms.ListView()
        Me.colID2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAperutra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCierre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPersona = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCajaDestino = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFondoMN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFondoME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIngAdicMN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIngAdicME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHabilitado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEnUso = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado, Me.ToolStripSeparator1, Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.ImprimirToolStripButton, Me.toolStripSeparator})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(799, 25)
        Me.ToolStrip3.TabIndex = 286
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.Maroon
        Me.lblEstado.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(94, 22)
        Me.lblEstado.Text = "Lista de Cajas"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.NuevoToolStripButton.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(94, 22)
        Me.NuevoToolStripButton.Text = "&Nueva cuenta"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AbrirToolStripButton.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.AbrirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ResumeRequest
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GuardarToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_eliminar
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(99, 22)
        Me.GuardarToolStripButton.Text = "Eliminar cuenta"
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lsvCajas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(799, 173)
        Me.Panel1.TabIndex = 287
        '
        'lsvCajas
        '
        Me.lsvCajas.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lsvCajas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIdCaja, Me.colCaja, Me.colTipo, Me.COLcUENTA, Me.colMoneda})
        Me.lsvCajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvCajas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lsvCajas.FullRowSelect = True
        Me.lsvCajas.GridLines = True
        Me.lsvCajas.HideSelection = False
        Me.lsvCajas.Location = New System.Drawing.Point(0, 0)
        Me.lsvCajas.MultiSelect = False
        Me.lsvCajas.Name = "lsvCajas"
        Me.lsvCajas.Size = New System.Drawing.Size(799, 173)
        Me.lsvCajas.TabIndex = 288
        Me.lsvCajas.UseCompatibleStateImageBehavior = False
        Me.lsvCajas.View = System.Windows.Forms.View.Details
        '
        'colIdCaja
        '
        Me.colIdCaja.Text = "ID"
        Me.colIdCaja.Width = 0
        '
        'colCaja
        '
        Me.colCaja.Text = "Caja"
        Me.colCaja.Width = 213
        '
        'colTipo
        '
        Me.colTipo.Text = "Tipo"
        Me.colTipo.Width = 126
        '
        'COLcUENTA
        '
        Me.COLcUENTA.Text = "Cta. contable"
        Me.COLcUENTA.Width = 97
        '
        'colMoneda
        '
        Me.colMoneda.Text = "Moneda"
        Me.colMoneda.Width = 130
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 198)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(799, 27)
        Me.Panel2.TabIndex = 288
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Maroon
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator3, Me.ToolStripButton2, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripSeparator5, Me.btnEliminarCaja, Me.lblPerido, Me.lblTitulo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(799, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.DarkMagenta
        Me.ToolStripLabel1.Image = CType(resources.GetObject("ToolStripLabel1.Image"), System.Drawing.Image)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripLabel1.Text = "Usuarios por caja:"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripButton1.Text = "Aperturar Caja"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripButton2.Text = "Cerrar/arqueo caja"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(85, 22)
        Me.ToolStripButton3.Text = "Ver reporte"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnEliminarCaja
        '
        Me.btnEliminarCaja.ForeColor = System.Drawing.Color.Crimson
        Me.btnEliminarCaja.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_eliminar
        Me.btnEliminarCaja.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminarCaja.Name = "btnEliminarCaja"
        Me.btnEliminarCaja.Size = New System.Drawing.Size(97, 22)
        Me.btnEliminarCaja.Text = "Eliminar caja "
        '
        'lblPerido
        '
        Me.lblPerido.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.Crimson
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(54, 22)
        Me.lblPerido.Text = "01/2014"
        '
        'lblTitulo
        '
        Me.lblTitulo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitulo.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ok_icon
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(74, 22)
        Me.lblTitulo.Text = "PERIODO:"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lsvCajaUsuario)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 225)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(799, 193)
        Me.Panel3.TabIndex = 289
        '
        'lsvCajaUsuario
        '
        Me.lsvCajaUsuario.BackColor = System.Drawing.Color.MistyRose
        Me.lsvCajaUsuario.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID2, Me.colAperutra, Me.colCierre, Me.colPersona, Me.colCajaDestino, Me.colFondoMN, Me.colFondoME, Me.colIngAdicMN, Me.colIngAdicME, Me.colHabilitado, Me.colEnUso})
        Me.lsvCajaUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvCajaUsuario.ForeColor = System.Drawing.Color.Crimson
        Me.lsvCajaUsuario.FullRowSelect = True
        Me.lsvCajaUsuario.HideSelection = False
        Me.lsvCajaUsuario.Location = New System.Drawing.Point(0, 0)
        Me.lsvCajaUsuario.MultiSelect = False
        Me.lsvCajaUsuario.Name = "lsvCajaUsuario"
        Me.lsvCajaUsuario.Size = New System.Drawing.Size(799, 193)
        Me.lsvCajaUsuario.TabIndex = 289
        Me.lsvCajaUsuario.UseCompatibleStateImageBehavior = False
        Me.lsvCajaUsuario.View = System.Windows.Forms.View.Details
        '
        'colID2
        '
        Me.colID2.Text = "ID"
        Me.colID2.Width = 0
        '
        'colAperutra
        '
        Me.colAperutra.Text = "Fecha Apertura"
        Me.colAperutra.Width = 127
        '
        'colCierre
        '
        Me.colCierre.Text = "Fecha cierre"
        Me.colCierre.Width = 136
        '
        'colPersona
        '
        Me.colPersona.Text = "Persona"
        Me.colPersona.Width = 226
        '
        'colCajaDestino
        '
        Me.colCajaDestino.Text = "Caja destino"
        Me.colCajaDestino.Width = 148
        '
        'colFondoMN
        '
        Me.colFondoMN.Text = "Fondo m.n."
        Me.colFondoMN.Width = 77
        '
        'colFondoME
        '
        Me.colFondoME.Text = "Fondo m.e."
        Me.colFondoME.Width = 79
        '
        'colIngAdicMN
        '
        Me.colIngAdicMN.Text = "Ingreso mn."
        Me.colIngAdicMN.Width = 80
        '
        'colIngAdicME
        '
        Me.colIngAdicME.Text = "Ingreso me."
        Me.colIngAdicME.Width = 74
        '
        'colHabilitado
        '
        Me.colHabilitado.Text = "Habilitado"
        Me.colHabilitado.Width = 70
        '
        'colEnUso
        '
        Me.colEnUso.Text = "En uso"
        Me.colEnUso.Width = 46
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
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
        'frmMantenimientoCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 418)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.MaximizeBox = False
        Me.Name = "frmMantenimientoCajas"
        Me.Text = "Gestión de Cajas"
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lsvCajas As System.Windows.Forms.ListView
    Friend WithEvents colIdCaja As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCaja As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents COLcUENTA As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lsvCajaUsuario As System.Windows.Forms.ListView
    Friend WithEvents colID2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAperutra As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPersona As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFondoMN As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents colFondoME As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIngAdicMN As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIngAdicME As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHabilitado As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colEnUso As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCajaDestino As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCierre As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents colMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEliminarCaja As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
End Class

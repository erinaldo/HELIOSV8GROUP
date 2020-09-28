<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasterTabla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMasterTabla))
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTabla = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TipoDeMedioDePagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoDeDocumentoDeIdentidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntidadFinancieraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoDeMonedaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoDeExistenciaTabla5ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnidadDeMedidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CódigoDelLibroORegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoDeComprobanteDePagoODocumentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoEstablecimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NacionalidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargosUOcupaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GradoDeInstrucciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.lsvTablas = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDescri = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtidtabla = New System.Windows.Forms.TextBox()
        Me.idTabla = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.ToolStrip2.Size = New System.Drawing.Size(668, 25)
        Me.ToolStrip2.TabIndex = 94
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
        Me.ToolStrip1.Size = New System.Drawing.Size(668, 25)
        Me.ToolStrip1.TabIndex = 93
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(21, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Tabla:"
        '
        'txtTabla
        '
        Me.txtTabla.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTabla.Location = New System.Drawing.Point(61, 23)
        Me.txtTabla.Name = "txtTabla"
        Me.txtTabla.ReadOnly = True
        Me.txtTabla.Size = New System.Drawing.Size(352, 20)
        Me.txtTabla.TabIndex = 96
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TipoDeMedioDePagoToolStripMenuItem, Me.TipoDeDocumentoDeIdentidadToolStripMenuItem, Me.EntidadFinancieraToolStripMenuItem, Me.TipoDeMonedaToolStripMenuItem, Me.TipoDeExistenciaTabla5ToolStripMenuItem, Me.UnidadDeMedidaToolStripMenuItem, Me.CódigoDelLibroORegistroToolStripMenuItem, Me.TipoDeComprobanteDePagoODocumentoToolStripMenuItem, Me.TipoEstablecimientosToolStripMenuItem, Me.NacionalidadesToolStripMenuItem, Me.CargosUOcupaciónToolStripMenuItem, Me.GradoDeInstrucciónToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(286, 268)
        '
        'TipoDeMedioDePagoToolStripMenuItem
        '
        Me.TipoDeMedioDePagoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TipoDeMedioDePagoToolStripMenuItem.Name = "TipoDeMedioDePagoToolStripMenuItem"
        Me.TipoDeMedioDePagoToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.TipoDeMedioDePagoToolStripMenuItem.Text = "Tipo de Medio de Pago"
        '
        'TipoDeDocumentoDeIdentidadToolStripMenuItem
        '
        Me.TipoDeDocumentoDeIdentidadToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TipoDeDocumentoDeIdentidadToolStripMenuItem.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.gear
        Me.TipoDeDocumentoDeIdentidadToolStripMenuItem.Name = "TipoDeDocumentoDeIdentidadToolStripMenuItem"
        Me.TipoDeDocumentoDeIdentidadToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.TipoDeDocumentoDeIdentidadToolStripMenuItem.Text = "Tipo de Documento de Identidad"
        '
        'EntidadFinancieraToolStripMenuItem
        '
        Me.EntidadFinancieraToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.EntidadFinancieraToolStripMenuItem.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.gear
        Me.EntidadFinancieraToolStripMenuItem.Name = "EntidadFinancieraToolStripMenuItem"
        Me.EntidadFinancieraToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.EntidadFinancieraToolStripMenuItem.Text = "Entidad Financiera"
        '
        'TipoDeMonedaToolStripMenuItem
        '
        Me.TipoDeMonedaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TipoDeMonedaToolStripMenuItem.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.gear
        Me.TipoDeMonedaToolStripMenuItem.Name = "TipoDeMonedaToolStripMenuItem"
        Me.TipoDeMonedaToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.TipoDeMonedaToolStripMenuItem.Text = "Tipo de Moneda"
        '
        'TipoDeExistenciaTabla5ToolStripMenuItem
        '
        Me.TipoDeExistenciaTabla5ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TipoDeExistenciaTabla5ToolStripMenuItem.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.gear
        Me.TipoDeExistenciaTabla5ToolStripMenuItem.Name = "TipoDeExistenciaTabla5ToolStripMenuItem"
        Me.TipoDeExistenciaTabla5ToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.TipoDeExistenciaTabla5ToolStripMenuItem.Text = "Tipo de Existencia tabla(5)"
        '
        'UnidadDeMedidaToolStripMenuItem
        '
        Me.UnidadDeMedidaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UnidadDeMedidaToolStripMenuItem.Image = CType(resources.GetObject("UnidadDeMedidaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UnidadDeMedidaToolStripMenuItem.Name = "UnidadDeMedidaToolStripMenuItem"
        Me.UnidadDeMedidaToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.UnidadDeMedidaToolStripMenuItem.Text = "Unidad de Medida"
        '
        'CódigoDelLibroORegistroToolStripMenuItem
        '
        Me.CódigoDelLibroORegistroToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CódigoDelLibroORegistroToolStripMenuItem.Image = CType(resources.GetObject("CódigoDelLibroORegistroToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CódigoDelLibroORegistroToolStripMenuItem.Name = "CódigoDelLibroORegistroToolStripMenuItem"
        Me.CódigoDelLibroORegistroToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.CódigoDelLibroORegistroToolStripMenuItem.Text = "Código del Libro o Registro"
        '
        'TipoDeComprobanteDePagoODocumentoToolStripMenuItem
        '
        Me.TipoDeComprobanteDePagoODocumentoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TipoDeComprobanteDePagoODocumentoToolStripMenuItem.Image = CType(resources.GetObject("TipoDeComprobanteDePagoODocumentoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TipoDeComprobanteDePagoODocumentoToolStripMenuItem.Name = "TipoDeComprobanteDePagoODocumentoToolStripMenuItem"
        Me.TipoDeComprobanteDePagoODocumentoToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.TipoDeComprobanteDePagoODocumentoToolStripMenuItem.Text = "Tipo de Comprobante de Pago o Documento"
        '
        'TipoEstablecimientosToolStripMenuItem
        '
        Me.TipoEstablecimientosToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TipoEstablecimientosToolStripMenuItem.Image = CType(resources.GetObject("TipoEstablecimientosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TipoEstablecimientosToolStripMenuItem.Name = "TipoEstablecimientosToolStripMenuItem"
        Me.TipoEstablecimientosToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.TipoEstablecimientosToolStripMenuItem.Text = "Tipo Establecimientos"
        '
        'NacionalidadesToolStripMenuItem
        '
        Me.NacionalidadesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NacionalidadesToolStripMenuItem.Image = CType(resources.GetObject("NacionalidadesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NacionalidadesToolStripMenuItem.Name = "NacionalidadesToolStripMenuItem"
        Me.NacionalidadesToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.NacionalidadesToolStripMenuItem.Text = "Nacionalidades"
        '
        'CargosUOcupaciónToolStripMenuItem
        '
        Me.CargosUOcupaciónToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CargosUOcupaciónToolStripMenuItem.Image = CType(resources.GetObject("CargosUOcupaciónToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CargosUOcupaciónToolStripMenuItem.Name = "CargosUOcupaciónToolStripMenuItem"
        Me.CargosUOcupaciónToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.CargosUOcupaciónToolStripMenuItem.Text = "Cargos u Ocupación"
        '
        'GradoDeInstrucciónToolStripMenuItem
        '
        Me.GradoDeInstrucciónToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GradoDeInstrucciónToolStripMenuItem.Image = CType(resources.GetObject("GradoDeInstrucciónToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GradoDeInstrucciónToolStripMenuItem.Name = "GradoDeInstrucciónToolStripMenuItem"
        Me.GradoDeInstrucciónToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.GradoDeInstrucciónToolStripMenuItem.Text = "Grado de Instrucción"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(417, 27)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(90, 13)
        Me.LinkLabel1.TabIndex = 97
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Seleccionar Tabla"
        '
        'lsvTablas
        '
        Me.lsvTablas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colDescri, Me.idTabla})
        Me.lsvTablas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvTablas.FullRowSelect = True
        Me.lsvTablas.HideSelection = False
        Me.lsvTablas.Location = New System.Drawing.Point(0, 122)
        Me.lsvTablas.MultiSelect = False
        Me.lsvTablas.Name = "lsvTablas"
        Me.lsvTablas.Size = New System.Drawing.Size(668, 266)
        Me.lsvTablas.TabIndex = 98
        Me.lsvTablas.UseCompatibleStateImageBehavior = False
        Me.lsvTablas.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "Código"
        Me.colID.Width = 50
        '
        'colDescri
        '
        Me.colDescri.Text = "Descripción"
        Me.colDescri.Width = 580
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.txtidtabla)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtTabla)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(668, 72)
        Me.Panel1.TabIndex = 99
        '
        'txtidtabla
        '
        Me.txtidtabla.Location = New System.Drawing.Point(535, 24)
        Me.txtidtabla.Name = "txtidtabla"
        Me.txtidtabla.Size = New System.Drawing.Size(53, 20)
        Me.txtidtabla.TabIndex = 98
        Me.txtidtabla.Visible = False
        '
        'idTabla
        '
        Me.idTabla.Width = 0
        '
        'frmMasterTabla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(668, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.lsvTablas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMasterTabla"
        Me.Text = "Tabla Maestra: Mantenimiento."
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AyudaToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTabla As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lsvTablas As System.Windows.Forms.ListView
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDescri As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TipoDeMedioDePagoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoDeDocumentoDeIdentidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntidadFinancieraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoDeMonedaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoDeExistenciaTabla5ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnidadDeMedidaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CódigoDelLibroORegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoDeComprobanteDePagoODocumentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoEstablecimientosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NacionalidadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargosUOcupaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GradoDeInstrucciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtidtabla As System.Windows.Forms.TextBox
    Friend WithEvents idTabla As System.Windows.Forms.ColumnHeader
End Class

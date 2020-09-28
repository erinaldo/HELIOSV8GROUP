<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoVentaPagada
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimientoVentaPagada))
        Me.lsvListaPedidos = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtIndice = New System.Windows.Forms.ToolStripTextBox()
        Me.txtIndiceTotal = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.rmCompra = New Syncfusion.Windows.Forms.Tools.RadialMenu()
        Me.rmEditarCompra = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmEliminarDoc = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmNotas = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmiNotaCredito = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmiNotaDebito = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmTributos = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmRemision = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmNuevaCompra = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.rmCompra.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsvListaPedidos
        '
        Me.lsvListaPedidos.BackColor = System.Drawing.Color.White
        Me.lsvListaPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvListaPedidos.FullRowSelect = True
        Me.lsvListaPedidos.GridLines = True
        Me.lsvListaPedidos.HideSelection = False
        Me.lsvListaPedidos.Location = New System.Drawing.Point(0, 75)
        Me.lsvListaPedidos.MultiSelect = False
        Me.lsvListaPedidos.Name = "lsvListaPedidos"
        Me.lsvListaPedidos.Size = New System.Drawing.Size(704, 298)
        Me.lsvListaPedidos.TabIndex = 288
        Me.lsvListaPedidos.UseCompatibleStateImageBehavior = False
        Me.lsvListaPedidos.View = System.Windows.Forms.View.Details
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
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.White
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripSeparator2, Me.txtIndice, Me.txtIndiceTotal, Me.ToolStripSeparator4, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 50)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(704, 25)
        Me.ToolStrip2.TabIndex = 289
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "ToolStripButton4"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'txtIndice
        '
        Me.txtIndice.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtIndice.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIndice.Name = "txtIndice"
        Me.txtIndice.ReadOnly = True
        Me.txtIndice.Size = New System.Drawing.Size(50, 25)
        Me.txtIndice.Text = "0"
        '
        'txtIndiceTotal
        '
        Me.txtIndiceTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtIndiceTotal.Name = "txtIndiceTotal"
        Me.txtIndiceTotal.Size = New System.Drawing.Size(37, 22)
        Me.txtIndiceTotal.Text = "de {0}"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "ToolStripButton5"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "ToolStripButton6"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_docsql
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripButton1.Text = "&Proforma"
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
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(120, 22)
        Me.lblEstado.Text = "Ventas directas (Ticket)"
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
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButton3, Me.ToolStripLabel2, Me.lblPerido})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(704, 25)
        Me.ToolStrip1.TabIndex = 290
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripLabel1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripLabel1.Text = "PERIODO:"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Salir"
        Me.ToolStripButton3.Visible = False
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(224, 22)
        Me.ToolStripLabel2.Text = "LISTADO DE VENTAS TICKET AL CREDITO"
        '
        'lblPerido
        '
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblPerido.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.iconoBusqueda
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(70, 22)
        Me.lblPerido.Text = "01/2014"
        Me.lblPerido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'rmCompra
        '
        Me.rmCompra.CenterCircleRimColor = System.Drawing.Color.LightBlue
        Me.rmCompra.Controls.Add(Me.rmEditarCompra)
        Me.rmCompra.Controls.Add(Me.rmEliminarDoc)
        Me.rmCompra.Controls.Add(Me.rmNotas)
        Me.rmCompra.Controls.Add(Me.rmTributos)
        Me.rmCompra.Controls.Add(Me.rmRemision)
        Me.rmCompra.Controls.Add(Me.rmNuevaCompra)
        Me.rmCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rmCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.rmCompra.HighlightedArcColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rmCompra.Items.Add(Me.rmEditarCompra)
        Me.rmCompra.Items.Add(Me.rmEliminarDoc)
        Me.rmCompra.Items.Add(Me.rmNotas)
        Me.rmCompra.Items.Add(Me.rmTributos)
        Me.rmCompra.Items.Add(Me.rmRemision)
        Me.rmCompra.Items.Add(Me.rmNuevaCompra)
        Me.rmCompra.Location = New System.Drawing.Point(331, 91)
        Me.rmCompra.MaximumSize = New System.Drawing.Size(700, 700)
        Me.rmCompra.MinimumSize = New System.Drawing.Size(150, 150)
        Me.rmCompra.Name = "rmCompra"
        Me.rmCompra.OuterArcColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.rmCompra.OuterRimThickness = 20
        Me.rmCompra.RimBackground = System.Drawing.Color.LightBlue
        Me.rmCompra.Size = New System.Drawing.Size(230, 230)
        Me.rmCompra.TabIndex = 291
        Me.rmCompra.Visible = False
        Me.rmCompra.WedgeCount = 6
        '
        'rmEditarCompra
        '
        Me.rmEditarCompra.BackColor = System.Drawing.Color.GhostWhite
        Me.rmEditarCompra.Location = New System.Drawing.Point(0, 0)
        Me.rmEditarCompra.Name = "rmEditarCompra"
        Me.rmEditarCompra.Size = New System.Drawing.Size(0, 0)
        Me.rmEditarCompra.TabIndex = 2
        Me.rmEditarCompra.Text = "Editar"
        '
        'rmEliminarDoc
        '
        Me.rmEliminarDoc.BackColor = System.Drawing.Color.GhostWhite
        Me.rmEliminarDoc.Location = New System.Drawing.Point(0, 0)
        Me.rmEliminarDoc.Name = "rmEliminarDoc"
        Me.rmEliminarDoc.Size = New System.Drawing.Size(0, 0)
        Me.rmEliminarDoc.TabIndex = 2
        Me.rmEliminarDoc.Text = "Eliminar"
        '
        'rmNotas
        '
        Me.rmNotas.BackColor = System.Drawing.Color.GhostWhite
        Me.rmNotas.Items.Add(Me.rmiNotaCredito)
        Me.rmNotas.Items.Add(Me.rmiNotaDebito)
        Me.rmNotas.Location = New System.Drawing.Point(0, 0)
        Me.rmNotas.Name = "rmNotas"
        Me.rmNotas.Size = New System.Drawing.Size(0, 0)
        Me.rmNotas.TabIndex = 2
        Me.rmNotas.Text = "Notas"
        '
        'rmiNotaCredito
        '
        Me.rmiNotaCredito.Location = New System.Drawing.Point(0, 0)
        Me.rmiNotaCredito.Name = "rmiNotaCredito"
        Me.rmiNotaCredito.Size = New System.Drawing.Size(0, 0)
        Me.rmiNotaCredito.TabIndex = 2
        Me.rmiNotaCredito.Text = "Nota Crédito"
        '
        'rmiNotaDebito
        '
        Me.rmiNotaDebito.Location = New System.Drawing.Point(0, 0)
        Me.rmiNotaDebito.Name = "rmiNotaDebito"
        Me.rmiNotaDebito.Size = New System.Drawing.Size(0, 0)
        Me.rmiNotaDebito.TabIndex = 3
        Me.rmiNotaDebito.Text = "Nota Débito"
        '
        'rmTributos
        '
        Me.rmTributos.BackColor = System.Drawing.Color.GhostWhite
        Me.rmTributos.Location = New System.Drawing.Point(0, 0)
        Me.rmTributos.Name = "rmTributos"
        Me.rmTributos.Size = New System.Drawing.Size(0, 0)
        Me.rmTributos.TabIndex = 2
        Me.rmTributos.Text = "Tributos"
        '
        'rmRemision
        '
        Me.rmRemision.BackColor = System.Drawing.Color.GhostWhite
        Me.rmRemision.Location = New System.Drawing.Point(0, 0)
        Me.rmRemision.Name = "rmRemision"
        Me.rmRemision.Size = New System.Drawing.Size(0, 0)
        Me.rmRemision.TabIndex = 2
        Me.rmRemision.Text = "Guías"
        '
        'rmNuevaCompra
        '
        Me.rmNuevaCompra.BackColor = System.Drawing.Color.GhostWhite
        Me.rmNuevaCompra.Location = New System.Drawing.Point(0, 0)
        Me.rmNuevaCompra.Name = "rmNuevaCompra"
        Me.rmNuevaCompra.Size = New System.Drawing.Size(0, 0)
        Me.rmNuevaCompra.TabIndex = 2
        Me.rmNuevaCompra.Text = "Venta"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'frmMantenimientoVentaPagada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 373)
        Me.Controls.Add(Me.rmCompra)
        Me.Controls.Add(Me.lsvListaPedidos)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmMantenimientoVentaPagada"
        Me.Text = "Ventas con Ticket al crédito"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.rmCompra.ResumeLayout(False)
        Me.rmCompra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lsvListaPedidos As System.Windows.Forms.ListView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtIndice As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txtIndiceTotal As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents rmCompra As Syncfusion.Windows.Forms.Tools.RadialMenu
    Friend WithEvents rmEditarCompra As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmEliminarDoc As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmNotas As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmTributos As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmRemision As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmNuevaCompra As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents rmiNotaCredito As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmiNotaDebito As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalExistencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalExistencia))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCuentas = New System.Windows.Forms.ComboBox()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.txtFiltro = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.rbNombre = New System.Windows.Forms.RadioButton()
        Me.rbCodigo = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lsvListadoItems = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColDescrip = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoEx = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdRec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCUenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarExistenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtIndice = New System.Windows.Forms.ToolStripTextBox()
        Me.txtIndiceTotal = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.txtClas = New System.Windows.Forms.ToolStripTextBox()
        Me.txtClasID = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lsvServicios = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblRows = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtEstable = New System.Windows.Forms.ToolStripTextBox()
        Me.txtIDEstable = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.QRibbonApplicationButton1 = New Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton()
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.QRibbonApplicationButton2 = New Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton()
        Me.btnNuevaEx = New Qios.DevSuite.Components.QCompositeMenuItem()
        Me.btnGasto = New Qios.DevSuite.Components.QCompositeMenuItem()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.cboCuentas)
        Me.GroupBox1.Controls.Add(Me.txtServicio)
        Me.GroupBox1.Controls.Add(Me.txtFiltro)
        Me.GroupBox1.Controls.Add(Me.rbNombre)
        Me.GroupBox1.Controls.Add(Me.rbCodigo)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(726, 67)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar Por:"
        '
        'cboCuentas
        '
        Me.cboCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCuentas.DropDownWidth = 180
        Me.cboCuentas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboCuentas.FormattingEnabled = True
        Me.cboCuentas.Location = New System.Drawing.Point(60, 43)
        Me.cboCuentas.Name = "cboCuentas"
        Me.cboCuentas.Size = New System.Drawing.Size(290, 21)
        Me.cboCuentas.TabIndex = 29
        Me.cboCuentas.Visible = False
        '
        'txtServicio
        '
        Me.txtServicio.BackColor = System.Drawing.Color.LavenderBlush
        Me.txtServicio.Enabled = False
        Me.txtServicio.Location = New System.Drawing.Point(8, 42)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(50, 20)
        Me.txtServicio.TabIndex = 28
        Me.txtServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtServicio.Visible = False
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(7, 42)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(279, 19)
        Me.txtFiltro.TabIndex = 27
        Me.txtFiltro.Visible = False
        '
        'rbNombre
        '
        Me.rbNombre.AutoSize = True
        Me.rbNombre.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.rbNombre.Location = New System.Drawing.Point(10, 21)
        Me.rbNombre.Name = "rbNombre"
        Me.rbNombre.Size = New System.Drawing.Size(58, 17)
        Me.rbNombre.TabIndex = 1
        Me.rbNombre.Text = "Gastos"
        Me.rbNombre.UseVisualStyleBackColor = True
        '
        'rbCodigo
        '
        Me.rbCodigo.AutoSize = True
        Me.rbCodigo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.rbCodigo.Location = New System.Drawing.Point(86, 21)
        Me.rbCodigo.Name = "rbCodigo"
        Me.rbCodigo.Size = New System.Drawing.Size(78, 17)
        Me.rbCodigo.TabIndex = 0
        Me.rbCodigo.Text = "Existencias"
        Me.rbCodigo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.TabControl)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 120)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(726, 357)
        Me.Panel1.TabIndex = 25
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(726, 357)
        Me.TabControl.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lsvListadoItems)
        Me.TabPage2.Controls.Add(Me.ToolStrip2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(718, 331)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Lista de items."
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lsvListadoItems
        '
        Me.lsvListadoItems.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lsvListadoItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.ColDescrip, Me.colUM, Me.colTipoEx, Me.colIdRec, Me.colCUenta})
        Me.lsvListadoItems.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lsvListadoItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsvListadoItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvListadoItems.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lsvListadoItems.FullRowSelect = True
        Me.lsvListadoItems.GridLines = True
        Me.lsvListadoItems.HideSelection = False
        Me.lsvListadoItems.Location = New System.Drawing.Point(3, 28)
        Me.lsvListadoItems.MultiSelect = False
        Me.lsvListadoItems.Name = "lsvListadoItems"
        Me.lsvListadoItems.Size = New System.Drawing.Size(712, 300)
        Me.lsvListadoItems.TabIndex = 349
        Me.lsvListadoItems.UseCompatibleStateImageBehavior = False
        Me.lsvListadoItems.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID Item"
        Me.colID.Width = 0
        '
        'ColDescrip
        '
        Me.ColDescrip.Text = "Descripción"
        Me.ColDescrip.Width = 303
        '
        'colUM
        '
        Me.colUM.Text = "U.M."
        '
        'colTipoEx
        '
        Me.colTipoEx.Text = "Tipo existencia"
        Me.colTipoEx.Width = 91
        '
        'colIdRec
        '
        Me.colIdRec.Text = "ID Recurso"
        Me.colIdRec.Width = 0
        '
        'colCUenta
        '
        Me.colCUenta.Text = "Cta."
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarExistenciaToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(154, 26)
        '
        'EditarExistenciaToolStripMenuItem
        '
        Me.EditarExistenciaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EditarExistenciaToolStripMenuItem.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.pencil
        Me.EditarExistenciaToolStripMenuItem.Name = "EditarExistenciaToolStripMenuItem"
        Me.EditarExistenciaToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.EditarExistenciaToolStripMenuItem.Text = "Editar existencia"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ToolStrip2.BackgroundImage = CType(resources.GetObject("ToolStrip2.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripSeparator2, Me.txtIndice, Me.txtIndiceTotal, Me.ToolStripSeparator6, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripSeparator9, Me.ToolStripLabel6, Me.txtClas, Me.txtClasID, Me.ToolStripLabel7})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(712, 25)
        Me.ToolStrip2.TabIndex = 350
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Inicio"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Previo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'txtIndice
        '
        Me.txtIndice.Name = "txtIndice"
        Me.txtIndice.ReadOnly = True
        Me.txtIndice.Size = New System.Drawing.Size(50, 25)
        Me.txtIndice.Text = "0"
        '
        'txtIndiceTotal
        '
        Me.txtIndiceTotal.Name = "txtIndiceTotal"
        Me.txtIndiceTotal.Size = New System.Drawing.Size(37, 22)
        Me.txtIndiceTotal.Text = "de {0}"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "siguiente"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Último"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(77, 22)
        Me.ToolStripLabel6.Text = "Clasificación:"
        '
        'txtClas
        '
        Me.txtClas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtClas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClas.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtClas.Name = "txtClas"
        Me.txtClas.ReadOnly = True
        Me.txtClas.Size = New System.Drawing.Size(190, 25)
        '
        'txtClasID
        '
        Me.txtClasID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtClasID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClasID.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtClasID.Name = "txtClasID"
        Me.txtClasID.ReadOnly = True
        Me.txtClasID.Size = New System.Drawing.Size(30, 25)
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel7.Text = "Cambiar"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lsvServicios)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(718, 331)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Listado de Gastos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lsvServicios
        '
        Me.lsvServicios.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lsvServicios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvServicios.FullRowSelect = True
        Me.lsvServicios.HideSelection = False
        Me.lsvServicios.Location = New System.Drawing.Point(3, 3)
        Me.lsvServicios.MultiSelect = False
        Me.lsvServicios.Name = "lsvServicios"
        Me.lsvServicios.Size = New System.Drawing.Size(712, 325)
        Me.lsvServicios.TabIndex = 7
        Me.lsvServicios.UseCompatibleStateImageBehavior = False
        Me.lsvServicios.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Descripcion"
        Me.ColumnHeader1.Width = 361
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Thistle
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.toolStripSeparator1, Me.lblRows, Me.ToolStripSeparator8, Me.ToolStripLabel1, Me.txtEstable, Me.txtIDEstable, Me.ToolStripLabel4, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(859, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.NuevoToolStripButton.ForeColor = System.Drawing.Color.White
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(60, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.AbrirToolStripButton.ForeColor = System.Drawing.Color.White
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(41, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Enabled = False
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.White
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(52, 22)
        Me.GuardarToolStripButton.Text = "&Eliminar"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblRows
        '
        Me.lblRows.ActiveLinkColor = System.Drawing.Color.Red
        Me.lblRows.ForeColor = System.Drawing.Color.Yellow
        Me.lblRows.Name = "lblRows"
        Me.lblRows.Size = New System.Drawing.Size(30, 22)
        Me.lblRows.Text = "Filas"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(94, 22)
        Me.ToolStripLabel1.Text = "Establecimiento:"
        Me.ToolStripLabel1.Visible = False
        '
        'txtEstable
        '
        Me.txtEstable.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtEstable.Name = "txtEstable"
        Me.txtEstable.ReadOnly = True
        Me.txtEstable.Size = New System.Drawing.Size(190, 25)
        Me.txtEstable.Visible = False
        '
        'txtIDEstable
        '
        Me.txtIDEstable.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDEstable.Name = "txtIDEstable"
        Me.txtIDEstable.ReadOnly = True
        Me.txtIDEstable.Size = New System.Drawing.Size(30, 25)
        Me.txtIDEstable.Visible = False
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.ForeColor = System.Drawing.Color.Yellow
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel4.Text = "Cambiar"
        Me.ToolStripLabel4.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Refresh"
        Me.ToolStripButton1.Visible = False
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'QRibbonApplicationButton1
        '
        Me.QRibbonApplicationButton1.Checked = True
        Me.QRibbonApplicationButton1.Configuration.Padding = New Qios.DevSuite.Components.QPadding(12, 11, -10, -9)
        Me.QRibbonApplicationButton1.ForegroundImage = CType(resources.GetObject("QRibbonApplicationButton1.ForegroundImage"), System.Drawing.Image)
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.ApplicationButton = Me.QRibbonApplicationButton2
        Me.QRibbonCaption1.BackgroundImageAlign = Qios.DevSuite.Components.QImageAlign.RepeatedVertical
        Me.QRibbonCaption1.CaptionFont = New System.Drawing.Font("Tahoma", 10.0!)
        Me.QRibbonCaption1.FontScope = Qios.DevSuite.Components.QFontScope.Local
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(726, 28)
        Me.QRibbonCaption1.TabIndex = 27
        Me.QRibbonCaption1.Text = "Listado de Recursos"
        '
        'QRibbonApplicationButton2
        '
        Me.QRibbonApplicationButton2.Checked = True
        Me.QRibbonApplicationButton2.ChildItems.Add(Me.btnNuevaEx)
        Me.QRibbonApplicationButton2.ChildItems.Add(Me.btnGasto)
        Me.QRibbonApplicationButton2.Configuration.Padding = New Qios.DevSuite.Components.QPadding(12, 12, -10, -4)
        Me.QRibbonApplicationButton2.ForegroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.t_shirt
        Me.QRibbonApplicationButton2.ToolTipText = "Agregar nuevo item (Ctr + N)"
        '
        'btnNuevaEx
        '
        Me.btnNuevaEx.Configuration.TitleConfiguration.FontDefinition = New Qios.DevSuite.Components.QFontDefinition("Tahoma", False, False, False, False, 8.0!)
        Me.btnNuevaEx.Title = "Nueva existencia"
        '
        'btnGasto
        '
        Me.btnGasto.Configuration.TitleConfiguration.FontDefinition = New Qios.DevSuite.Components.QFontDefinition("Tahoma", False, False, False, False, 8.0!)
        Me.btnGasto.Title = "Nuevo Gasto"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(726, 25)
        Me.ToolStrip3.TabIndex = 28
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'lblEstado
        '
        Me.lblEstado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblEstado.Image = CType(resources.GetObject("lblEstado.Image"), System.Drawing.Image)
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(46, 22)
        Me.lblEstado.Text = "Estado"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(726, 67)
        Me.Panel2.TabIndex = 29
        '
        'frmModalExistencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 477)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "frmModalExistencia"
        Me.Text = "Listado de Recursos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rbCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lsvListadoItems As System.Windows.Forms.ListView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtIndice As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txtIndiceTotal As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtClas As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txtClasID As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblRows As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtEstable As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txtIDEstable As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColDescrip As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUM As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipoEx As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdRec As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCUenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents QRibbonApplicationButton1 As Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents QRibbonApplicationButton2 As Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevaEx As Qios.DevSuite.Components.QCompositeMenuItem
    Friend WithEvents btnGasto As Qios.DevSuite.Components.QCompositeMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtFiltro As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarExistenciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboCuentas As System.Windows.Forms.ComboBox
    Friend WithEvents txtServicio As System.Windows.Forms.TextBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lsvServicios As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
End Class

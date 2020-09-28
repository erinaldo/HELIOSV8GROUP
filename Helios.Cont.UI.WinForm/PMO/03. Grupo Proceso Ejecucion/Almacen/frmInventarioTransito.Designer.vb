<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventarioTransito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventarioTransito))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MERCADERIAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MATERIAPRIMAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ENVASESYEMBALAJESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeleccionarTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.lsvDistribucion = New System.Windows.Forms.ListView()
        Me.checked = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoRegistro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.btnDistriNromal = New System.Windows.Forms.ToolStripButton()
        Me.btnDistribucionMasiva = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtEstablecimiento = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dropDownBtn = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtExistencia = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.popupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lstEstables = New System.Windows.Forms.ListBox()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.OK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.PopupControlContainer2 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lstTipoExistencia = New System.Windows.Forms.ListBox()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripLabel()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.popupControlContainer1.SuspendLayout()
        Me.PopupControlContainer2.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
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
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MERCADERIAToolStripMenuItem, Me.MATERIAPRIMAToolStripMenuItem, Me.ENVASESYEMBALAJESToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(198, 70)
        '
        'MERCADERIAToolStripMenuItem
        '
        Me.MERCADERIAToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MERCADERIAToolStripMenuItem.Name = "MERCADERIAToolStripMenuItem"
        Me.MERCADERIAToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.MERCADERIAToolStripMenuItem.Text = "MERCADERIA"
        '
        'MATERIAPRIMAToolStripMenuItem
        '
        Me.MATERIAPRIMAToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MATERIAPRIMAToolStripMenuItem.Name = "MATERIAPRIMAToolStripMenuItem"
        Me.MATERIAPRIMAToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.MATERIAPRIMAToolStripMenuItem.Text = "MATERIA PRIMA"
        '
        'ENVASESYEMBALAJESToolStripMenuItem
        '
        Me.ENVASESYEMBALAJESToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ENVASESYEMBALAJESToolStripMenuItem.Name = "ENVASESYEMBALAJESToolStripMenuItem"
        Me.ENVASESYEMBALAJESToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ENVASESYEMBALAJESToolStripMenuItem.Text = "ENVASES Y EMBALAJES"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarTodoToolStripMenuItem})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(156, 26)
        '
        'SeleccionarTodoToolStripMenuItem
        '
        Me.SeleccionarTodoToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.SeleccionarTodoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SeleccionarTodoToolStripMenuItem.Image = CType(resources.GetObject("SeleccionarTodoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SeleccionarTodoToolStripMenuItem.Name = "SeleccionarTodoToolStripMenuItem"
        Me.SeleccionarTodoToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.SeleccionarTodoToolStripMenuItem.Text = "Seleccionar Todo"
        '
        'lsvDistribucion
        '
        Me.lsvDistribucion.BackColor = System.Drawing.Color.White
        Me.lsvDistribucion.CheckBoxes = True
        Me.lsvDistribucion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.checked, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.colTipoRegistro})
        Me.lsvDistribucion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvDistribucion.FullRowSelect = True
        Me.lsvDistribucion.GridLines = True
        Me.lsvDistribucion.HideSelection = False
        Me.lsvDistribucion.Location = New System.Drawing.Point(0, 123)
        Me.lsvDistribucion.MultiSelect = False
        Me.lsvDistribucion.Name = "lsvDistribucion"
        Me.lsvDistribucion.Size = New System.Drawing.Size(850, 257)
        Me.lsvDistribucion.TabIndex = 61
        Me.lsvDistribucion.UseCompatibleStateImageBehavior = False
        Me.lsvDistribucion.View = System.Windows.Forms.View.Details
        '
        'checked
        '
        Me.checked.Text = "Id Almacen"
        Me.checked.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Id Documento"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Id Item"
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Descripcion Item"
        Me.ColumnHeader4.Width = 229
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cantidad"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "U.M."
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Monto Soles"
        Me.ColumnHeader7.Width = 78
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Monto USD"
        Me.ColumnHeader8.Width = 78
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Id Proveedor"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Proveedor"
        Me.ColumnHeader10.Width = 254
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "N° Doc."
        Me.ColumnHeader11.Width = 134
        '
        'colTipoRegistro
        '
        Me.colTipoRegistro.Text = "TP"
        Me.colTipoRegistro.Width = 50
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ToolStrip3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 97)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(850, 26)
        Me.Panel2.TabIndex = 292
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDistriNromal, Me.btnDistribucionMasiva, Me.ToolStripSeparator2, Me.lblEstado})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(850, 26)
        Me.ToolStrip3.TabIndex = 283
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'btnDistriNromal
        '
        Me.btnDistriNromal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnDistriNromal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnDistriNromal.Image = CType(resources.GetObject("btnDistriNromal.Image"), System.Drawing.Image)
        Me.btnDistriNromal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDistriNromal.Name = "btnDistriNromal"
        Me.btnDistriNromal.Size = New System.Drawing.Size(94, 23)
        Me.btnDistriNromal.Text = "Procesar Item"
        '
        'btnDistribucionMasiva
        '
        Me.btnDistribucionMasiva.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnDistribucionMasiva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnDistribucionMasiva.Image = CType(resources.GetObject("btnDistribucionMasiva.Image"), System.Drawing.Image)
        Me.btnDistribucionMasiva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDistribucionMasiva.Name = "btnDistribucionMasiva"
        Me.btnDistribucionMasiva.Size = New System.Drawing.Size(101, 23)
        Me.btnDistribucionMasiva.Text = "Procesar Grupo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 26)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(44, 23)
        Me.lblEstado.Text = "Estado"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.ButtonAdv6)
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(850, 72)
        Me.Panel1.TabIndex = 291
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel2.Controls.Add(Me.txtEstablecimiento)
        Me.GradientPanel2.Location = New System.Drawing.Point(7, 27)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(314, 41)
        Me.GradientPanel2.TabIndex = 204
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(26, 19)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(283, 14)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(26, 19)
        Me.ButtonAdv1.TabIndex = 207
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'txtEstablecimiento
        '
        Me.txtEstablecimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstablecimiento.Location = New System.Drawing.Point(14, 14)
        Me.txtEstablecimiento.Name = "txtEstablecimiento"
        Me.txtEstablecimiento.ReadOnly = True
        Me.txtEstablecimiento.Size = New System.Drawing.Size(264, 19)
        Me.txtEstablecimiento.TabIndex = 206
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Location = New System.Drawing.Point(7, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(314, 24)
        Me.Panel4.TabIndex = 203
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(10, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 19)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Establecimiento:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.dropDownBtn)
        Me.GradientPanel1.Controls.Add(Me.txtExistencia)
        Me.GradientPanel1.Location = New System.Drawing.Point(325, 27)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(314, 41)
        Me.GradientPanel1.TabIndex = 202
        '
        'dropDownBtn
        '
        Me.dropDownBtn.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dropDownBtn.BackColor = System.Drawing.SystemColors.Highlight
        Me.dropDownBtn.BeforeTouchSize = New System.Drawing.Size(26, 19)
        Me.dropDownBtn.ForeColor = System.Drawing.Color.White
        Me.dropDownBtn.Image = CType(resources.GetObject("dropDownBtn.Image"), System.Drawing.Image)
        Me.dropDownBtn.IsBackStageButton = False
        Me.dropDownBtn.Location = New System.Drawing.Point(283, 14)
        Me.dropDownBtn.Name = "dropDownBtn"
        Me.dropDownBtn.Size = New System.Drawing.Size(26, 19)
        Me.dropDownBtn.TabIndex = 207
        Me.dropDownBtn.UseVisualStyle = True
        '
        'txtExistencia
        '
        Me.txtExistencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExistencia.Location = New System.Drawing.Point(14, 14)
        Me.txtExistencia.Name = "txtExistencia"
        Me.txtExistencia.ReadOnly = True
        Me.txtExistencia.Size = New System.Drawing.Size(264, 19)
        Me.txtExistencia.TabIndex = 206
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Location = New System.Drawing.Point(325, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(314, 24)
        Me.Panel3.TabIndex = 201
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Location = New System.Drawing.Point(10, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(194, 19)
        Me.Label11.TabIndex = 170
        Me.Label11.Text = "Tipo de Existencia:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.popupControlContainer1.Controls.Add(Me.lstEstables)
        Me.popupControlContainer1.Controls.Add(Me.ButtonAdv3)
        Me.popupControlContainer1.Controls.Add(Me.ButtonAdv2)
        Me.popupControlContainer1.Controls.Add(Me.cancel)
        Me.popupControlContainer1.Controls.Add(Me.OK)
        Me.popupControlContainer1.Location = New System.Drawing.Point(351, 155)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(197, 113)
        Me.popupControlContainer1.TabIndex = 201
        Me.popupControlContainer1.Visible = False
        '
        'lstEstables
        '
        Me.lstEstables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstEstables.FormattingEnabled = True
        Me.lstEstables.Location = New System.Drawing.Point(0, 0)
        Me.lstEstables.Name = "lstEstables"
        Me.lstEstables.Size = New System.Drawing.Size(195, 111)
        Me.lstEstables.TabIndex = 3
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(63, 86)
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv3.TabIndex = 209
        Me.ButtonAdv3.Text = "Cancelar"
        Me.ButtonAdv3.UseVisualStyle = True
        Me.ButtonAdv3.Visible = False
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(1, 86)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv2.TabIndex = 208
        Me.ButtonAdv2.Text = "OK"
        Me.ButtonAdv2.UseVisualStyle = True
        Me.ButtonAdv2.Visible = False
        '
        'cancel
        '
        Me.cancel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.cancel.BackColor = System.Drawing.SystemColors.Highlight
        Me.cancel.BeforeTouchSize = New System.Drawing.Size(156, 72)
        Me.cancel.ForeColor = System.Drawing.Color.White
        Me.cancel.IsBackStageButton = False
        Me.cancel.Location = New System.Drawing.Point(65, 120)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(156, 72)
        Me.cancel.TabIndex = 2
        Me.cancel.Text = "Cancel"
        Me.cancel.UseVisualStyle = True
        '
        'OK
        '
        Me.OK.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.OK.BackColor = System.Drawing.SystemColors.Highlight
        Me.OK.BeforeTouchSize = New System.Drawing.Size(156, 72)
        Me.OK.ForeColor = System.Drawing.Color.White
        Me.OK.IsBackStageButton = False
        Me.OK.Location = New System.Drawing.Point(5, 120)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(156, 72)
        Me.OK.TabIndex = 1
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyle = True
        '
        'PopupControlContainer2
        '
        Me.PopupControlContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PopupControlContainer2.Controls.Add(Me.lstTipoExistencia)
        Me.PopupControlContainer2.Controls.Add(Me.ButtonAdv4)
        Me.PopupControlContainer2.Controls.Add(Me.ButtonAdv5)
        Me.PopupControlContainer2.Location = New System.Drawing.Point(194, 162)
        Me.PopupControlContainer2.Name = "PopupControlContainer2"
        Me.PopupControlContainer2.Size = New System.Drawing.Size(182, 152)
        Me.PopupControlContainer2.TabIndex = 205
        Me.PopupControlContainer2.Visible = False
        '
        'lstTipoExistencia
        '
        Me.lstTipoExistencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstTipoExistencia.FormattingEnabled = True
        Me.lstTipoExistencia.Location = New System.Drawing.Point(0, 0)
        Me.lstTipoExistencia.Name = "lstTipoExistencia"
        Me.lstTipoExistencia.Size = New System.Drawing.Size(180, 150)
        Me.lstTipoExistencia.TabIndex = 3
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(63, 86)
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv4.TabIndex = 209
        Me.ButtonAdv4.Text = "Cancelar"
        Me.ButtonAdv4.UseVisualStyle = True
        Me.ButtonAdv4.Visible = False
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(1, 86)
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv5.TabIndex = 208
        Me.ButtonAdv5.Text = "OK"
        Me.ButtonAdv5.UseVisualStyle = True
        Me.ButtonAdv5.Visible = False
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.White
        Me.ToolStrip5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPerido, Me.lblTitulo, Me.ToolStripButton7, Me.lblDescripcion})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(850, 25)
        Me.ToolStrip5.TabIndex = 290
        Me.ToolStrip5.Text = "ToolStrip5"
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
        Me.lblDescripcion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblDescripcion.Image = CType(resources.GetObject("lblDescripcion.Image"), System.Drawing.Image)
        Me.lblDescripcion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(140, 22)
        Me.lblDescripcion.Text = "Existencias en tránsito."
        '
        'lblTitulo
        '
        Me.lblTitulo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(58, 22)
        Me.lblTitulo.Text = "PERIODO:"
        '
        'lblPerido
        '
        Me.lblPerido.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(54, 22)
        Me.lblPerido.Text = "01/2014"
        Me.lblPerido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.White
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(26, 19)
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(645, 42)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(26, 19)
        Me.ButtonAdv6.TabIndex = 403
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'frmInventarioTransito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 380)
        Me.Controls.Add(Me.PopupControlContainer2)
        Me.Controls.Add(Me.popupControlContainer1)
        Me.Controls.Add(Me.lsvDistribucion)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmInventarioTransito"
        Me.Text = "Existencias en tránsito"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.popupControlContainer1.ResumeLayout(False)
        Me.PopupControlContainer2.ResumeLayout(False)
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lsvDistribucion As System.Windows.Forms.ListView
    Friend WithEvents checked As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnDistriNromal As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDistribucionMasiva As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MERCADERIAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MATERIAPRIMAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ENVASESYEMBALAJESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SeleccionarTodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Private WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtEstablecimiento As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents dropDownBtn As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtExistencia As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents popupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Private WithEvents cancel As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents OK As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lstEstables As System.Windows.Forms.ListBox
    Private WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents PopupControlContainer2 As Syncfusion.Windows.Forms.PopupControlContainer
    Private WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lstTipoExistencia As System.Windows.Forms.ListBox
    Friend WithEvents colTipoRegistro As System.Windows.Forms.ColumnHeader
    Private WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
End Class

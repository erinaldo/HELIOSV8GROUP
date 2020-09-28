<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlmacenTransfenciaSobrante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlmacenTransfenciaSobrante))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboTipoExistencia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtProveedor = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtNumero = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSerie = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTipoDoc = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCompra = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.idDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Secue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idArt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Art = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Can1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidadRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PMme = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importeSoles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importeDolares = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Almacen = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.almacenDestino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.btGrabar = New System.Windows.Forms.ToolStripButton()
        Me.btnAprobar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 45)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(945, 25)
        Me.ToolStrip1.TabIndex = 411
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(142, 22)
        Me.lblEstado.Text = "Estado: nuevo movimiento."
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.toolStripSeparator1, Me.lblIdDocumento})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 45)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(945, 25)
        Me.ToolStrip3.TabIndex = 413
        Me.ToolStrip3.Text = "ToolStrip3"
        Me.ToolStrip3.Visible = False
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(19, 22)
        Me.lblIdDocumento.Text = "00"
        Me.lblIdDocumento.Visible = False
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Location = New System.Drawing.Point(91, 109)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(181, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 401
        '
        'cboTipoExistencia
        '
        Me.cboTipoExistencia.BackColor = System.Drawing.Color.White
        Me.cboTipoExistencia.BeforeTouchSize = New System.Drawing.Size(155, 21)
        Me.cboTipoExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoExistencia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoExistencia.Location = New System.Drawing.Point(6, 67)
        Me.cboTipoExistencia.Name = "cboTipoExistencia"
        Me.cboTipoExistencia.Size = New System.Drawing.Size(155, 21)
        Me.cboTipoExistencia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoExistencia.TabIndex = 211
        Me.cboTipoExistencia.TabStop = False
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'dockingManager1
        '
        Me.dockingManager1.ActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.AutoHideTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.DockLayoutStream = CType(resources.GetObject("dockingManager1.DockLayoutStream"), System.IO.MemoryStream)
        Me.dockingManager1.DockTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.HostControl = Me
        Me.dockingManager1.InActiveCaptionBackground = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer)))
        Me.dockingManager1.InActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dockingManager1.MetroCaptionColor = System.Drawing.Color.White
        Me.dockingManager1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.dockingManager1.ReduceFlickeringInRtl = False
        Me.dockingManager1.SplitterWidth = 1
        Me.dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"))
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.txtProveedor)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txtNumero)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtSerie)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtTipoDoc)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 70)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(945, 37)
        Me.Panel1.TabIndex = 417
        '
        'txtProveedor
        '
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Location = New System.Drawing.Point(653, 9)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(280, 19)
        Me.txtProveedor.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(590, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Proveedor:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(562, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(18, 18)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'txtNumero
        '
        Me.txtNumero.Enabled = False
        Me.txtNumero.Location = New System.Drawing.Point(387, 8)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(193, 19)
        Me.txtNumero.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(337, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Número:"
        '
        'txtSerie
        '
        Me.txtSerie.Enabled = False
        Me.txtSerie.Location = New System.Drawing.Point(195, 8)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(120, 19)
        Me.txtSerie.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(160, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Serie:"
        '
        'txtTipoDoc
        '
        Me.txtTipoDoc.DisplayMember = "99"
        Me.txtTipoDoc.Enabled = False
        Me.txtTipoDoc.Location = New System.Drawing.Point(55, 8)
        Me.txtTipoDoc.Name = "txtTipoDoc"
        Me.txtTipoDoc.ReadOnly = True
        Me.txtTipoDoc.Size = New System.Drawing.Size(99, 19)
        Me.txtTipoDoc.TabIndex = 1
        Me.txtTipoDoc.Text = "NOTIFICACION"
        Me.txtTipoDoc.ValueMember = "99"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Doc's.:"
        '
        'dgvCompra
        '
        Me.dgvCompra.AllowUserToAddRows = False
        Me.dgvCompra.AllowUserToDeleteRows = False
        Me.dgvCompra.AllowUserToOrderColumns = True
        Me.dgvCompra.AllowUserToResizeColumns = False
        Me.dgvCompra.AllowUserToResizeRows = False
        Me.dgvCompra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idDocumento, Me.Secue, Me.idArt, Me.Art, Me.Can1, Me.cantidadRef, Me.PrecioUnitario, Me.PMme, Me.importeSoles, Me.importeDolares, Me.Almacen, Me.almacenDestino})
        Me.dgvCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompra.Location = New System.Drawing.Point(0, 107)
        Me.dgvCompra.MultiSelect = False
        Me.dgvCompra.Name = "dgvCompra"
        Me.dgvCompra.ReadOnly = True
        Me.dgvCompra.RowHeadersWidth = 25
        Me.dgvCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCompra.Size = New System.Drawing.Size(945, 254)
        Me.dgvCompra.TabIndex = 418
        Me.dgvCompra.TabStop = False
        '
        'idDocumento
        '
        Me.idDocumento.Frozen = True
        Me.idDocumento.HeaderText = "idDocumento"
        Me.idDocumento.Name = "idDocumento"
        Me.idDocumento.ReadOnly = True
        Me.idDocumento.Visible = False
        '
        'Secue
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        Me.Secue.DefaultCellStyle = DataGridViewCellStyle1
        Me.Secue.Frozen = True
        Me.Secue.HeaderText = "Secuencia"
        Me.Secue.Name = "Secue"
        Me.Secue.ReadOnly = True
        Me.Secue.Visible = False
        Me.Secue.Width = 30
        '
        'idArt
        '
        Me.idArt.Frozen = True
        Me.idArt.HeaderText = "idArt"
        Me.idArt.Name = "idArt"
        Me.idArt.ReadOnly = True
        Me.idArt.Visible = False
        '
        'Art
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Art.DefaultCellStyle = DataGridViewCellStyle2
        Me.Art.Frozen = True
        Me.Art.HeaderText = "Articulo"
        Me.Art.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.Art.Name = "Art"
        Me.Art.ReadOnly = True
        Me.Art.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Art.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Art.Width = 220
        '
        'Can1
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.Can1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Can1.Frozen = True
        Me.Can1.HeaderText = "Cant"
        Me.Can1.Name = "Can1"
        Me.Can1.ReadOnly = True
        Me.Can1.Width = 50
        '
        'cantidadRef
        '
        Me.cantidadRef.HeaderText = "Cant. dev."
        Me.cantidadRef.Name = "cantidadRef"
        Me.cantidadRef.ReadOnly = True
        Me.cantidadRef.Width = 70
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.HeaderText = "PM mn"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        '
        'PMme
        '
        Me.PMme.HeaderText = "PM me"
        Me.PMme.Name = "PMme"
        Me.PMme.ReadOnly = True
        '
        'importeSoles
        '
        Me.importeSoles.HeaderText = "V.C."
        Me.importeSoles.Name = "importeSoles"
        Me.importeSoles.ReadOnly = True
        '
        'importeDolares
        '
        Me.importeDolares.HeaderText = "V.C."
        Me.importeDolares.Name = "importeDolares"
        Me.importeDolares.ReadOnly = True
        '
        'Almacen
        '
        Me.Almacen.HeaderText = "Almacen"
        Me.Almacen.Name = "Almacen"
        Me.Almacen.ReadOnly = True
        Me.Almacen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Almacen.Text = "Elegir Almacen"
        Me.Almacen.ToolTipText = "Elegir Almacen"
        '
        'almacenDestino
        '
        Me.almacenDestino.HeaderText = "Almacen Destino"
        Me.almacenDestino.Name = "almacenDestino"
        Me.almacenDestino.ReadOnly = True
        Me.almacenDestino.Visible = False
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(91, 37)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(150, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 212
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.ToolStrip5)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(945, 45)
        Me.Panel7.TabIndex = 419
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPerido, Me.btGrabar, Me.btnAprobar, Me.ToolStripButton1})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip5.Size = New System.Drawing.Size(945, 45)
        Me.ToolStrip5.TabIndex = 1
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'lblPerido
        '
        Me.lblPerido.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPerido.BackColor = System.Drawing.Color.Transparent
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Image = CType(resources.GetObject("lblPerido.Image"), System.Drawing.Image)
        Me.lblPerido.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(94, 42)
        Me.lblPerido.Text = "Período: 2015"
        '
        'btGrabar
        '
        Me.btGrabar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(44, 42)
        Me.btGrabar.Text = "Grabar"
        '
        'btnAprobar
        '
        Me.btnAprobar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAprobar.Image = CType(resources.GetObject("btnAprobar.Image"), System.Drawing.Image)
        Me.btnAprobar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(44, 42)
        Me.btnAprobar.Text = "Aprobar asientos seleccionados"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(44, 42)
        Me.ToolStripButton1.Text = "Aprobar asientos seleccionados"
        '
        'frmAlmacenTransfenciaSobrante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        Me.ClientSize = New System.Drawing.Size(945, 361)
        Me.Controls.Add(Me.dgvCompra)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.Panel7)
        Me.Name = "frmAlmacenTransfenciaSobrante"
        Me.ShowIcon = False
        Me.Text = "Devolución de existencias"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboMoneda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboTipoExistencia As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtNumero As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvCompra As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents txtTipoDoc As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtProveedor As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents idDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Secue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idArt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Art As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Can1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidadRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PMme As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importeSoles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importeDolares As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Almacen As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents almacenDestino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAprobar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class

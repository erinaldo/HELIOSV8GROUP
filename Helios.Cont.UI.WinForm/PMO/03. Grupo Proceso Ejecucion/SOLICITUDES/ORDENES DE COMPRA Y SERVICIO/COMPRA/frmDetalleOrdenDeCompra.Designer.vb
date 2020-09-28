<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleOrdenDeCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleOrdenDeCompra))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.DMIngreso = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.cboTipoExistencia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.PanelDGV = New System.Windows.Forms.Panel()
        Me.dgvHistorialDetalle = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvOrdenCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.panel15 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnExistencia = New System.Windows.Forms.Panel()
        Me.lblIdDocumento = New System.Windows.Forms.Label()
        Me.txtNombreItem = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.DomainUpDown()
        Me.pnDetallesOC = New System.Windows.Forms.Panel()
        Me.txtNotas = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDirAlmacen = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaInicioPlazo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtFechaFinPlazo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtFechaFinGarantia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFechaInicioGarantia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.cboAlmacen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.btnCancelarProv = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnGRabarProv = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtIndicaciones = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RbPorExistencia = New System.Windows.Forms.RadioButton()
        Me.rbTodo = New System.Windows.Forms.RadioButton()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.popupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvProveedor = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.OK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        CType(Me.DMIngreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDGV.SuspendLayout()
        CType(Me.dgvHistorialDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgvOrdenCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel15.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnExistencia.SuspendLayout()
        Me.pnDetallesOC.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtFechaInicioPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicioPlazo.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinPlazo.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.txtFechaFinGarantia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinGarantia.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicioGarantia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicioGarantia.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        Me.popupControlContainer1.SuspendLayout()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DMIngreso
        '
        Me.DMIngreso.ActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.DMIngreso.AutoHideSelectionStyle = Syncfusion.Windows.Forms.Tools.AutoHideSelectionStyle.Click
        Me.DMIngreso.AutoHideTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.DMIngreso.DisallowFloating = True
        Me.DMIngreso.DockBehavior = Syncfusion.Windows.Forms.Tools.DockBehavior.VS2010
        Me.DMIngreso.DockLayoutStream = CType(resources.GetObject("DMIngreso.DockLayoutStream"), System.IO.MemoryStream)
        Me.DMIngreso.DockTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.DMIngreso.DragProviderStyle = Syncfusion.Windows.Forms.Tools.DragProviderStyle.VS2012
        Me.DMIngreso.HostControl = Me
        Me.DMIngreso.InActiveCaptionBackground = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer)))
        Me.DMIngreso.InActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.DMIngreso.MetroButtonColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DMIngreso.MetroCaptionColor = System.Drawing.Color.White
        Me.DMIngreso.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DMIngreso.MetroSplitterBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.DMIngreso.ReduceFlickeringInRtl = False
        Me.DMIngreso.SplitterWidth = 1
        Me.DMIngreso.ThemesEnabled = True
        Me.DMIngreso.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.DMIngreso.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"))
        Me.DMIngreso.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"))
        Me.DMIngreso.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"))
        Me.DMIngreso.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"))
        Me.DMIngreso.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"))
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
        'PanelDGV
        '
        Me.PanelDGV.Controls.Add(Me.dgvHistorialDetalle)
        Me.PanelDGV.Controls.Add(Me.dgvOrdenCompra)
        Me.PanelDGV.Controls.Add(Me.panel15)
        Me.PanelDGV.Controls.Add(Me.Panel3)
        Me.PanelDGV.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelDGV.Location = New System.Drawing.Point(0, 101)
        Me.PanelDGV.Name = "PanelDGV"
        Me.PanelDGV.Size = New System.Drawing.Size(1038, 285)
        Me.PanelDGV.TabIndex = 401
        '
        'dgvHistorialDetalle
        '
        Me.dgvHistorialDetalle.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvHistorialDetalle.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvHistorialDetalle.BackColor = System.Drawing.SystemColors.Window
        Me.dgvHistorialDetalle.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvHistorialDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHistorialDetalle.FreezeCaption = False
        Me.dgvHistorialDetalle.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvHistorialDetalle.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvHistorialDetalle.Location = New System.Drawing.Point(289, 24)
        Me.dgvHistorialDetalle.Name = "dgvHistorialDetalle"
        Me.dgvHistorialDetalle.Size = New System.Drawing.Size(749, 261)
        Me.dgvHistorialDetalle.TabIndex = 399
        Me.dgvHistorialDetalle.TableDescriptor.AllowNew = False
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvHistorialDetalle.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.Name = "idDocumento"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "secuencia"
        GridColumnDescriptor2.Name = "secuencia"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "cant."
        GridColumnDescriptor3.MappingName = "cantidad"
        GridColumnDescriptor3.Name = "cantidad "
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 50
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "idAlmacen"
        GridColumnDescriptor4.Name = "idAlmacen"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Nombre almacén"
        GridColumnDescriptor5.MappingName = "nombreAlmacen"
        GridColumnDescriptor5.Name = "nombreAlmacen"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 150
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Dirección"
        GridColumnDescriptor6.MappingName = "direccionAlmacen"
        GridColumnDescriptor6.Name = "direccionAlmacen"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 230
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Fecha inicio"
        GridColumnDescriptor7.MappingName = "fechainicio"
        GridColumnDescriptor7.Name = "fechainicio"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 130
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Fecha fin"
        GridColumnDescriptor8.MappingName = "fechaFin"
        GridColumnDescriptor8.Name = "fechaFin"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 130
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.MappingName = "indicaciones"
        GridColumnDescriptor9.Name = "indicaciones"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 150
        Me.dgvHistorialDetalle.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9})
        Me.dgvHistorialDetalle.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvHistorialDetalle.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvHistorialDetalle.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad "), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombreAlmacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("direccionAlmacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechainicio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaFin")})
        Me.dgvHistorialDetalle.Text = "GridGroupingControl2"
        Me.dgvHistorialDetalle.VersionInfo = "12.4400.0.24"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripMenuItem4})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 48)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(117, 22)
        Me.ToolStripMenuItem3.Text = "Editar"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(117, 22)
        Me.ToolStripMenuItem4.Text = "Eliminar"
        '
        'dgvOrdenCompra
        '
        Me.dgvOrdenCompra.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvOrdenCompra.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvOrdenCompra.BackColor = System.Drawing.SystemColors.Window
        Me.dgvOrdenCompra.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvOrdenCompra.FreezeCaption = False
        Me.dgvOrdenCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvOrdenCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvOrdenCompra.Location = New System.Drawing.Point(0, 24)
        Me.dgvOrdenCompra.Name = "dgvOrdenCompra"
        Me.dgvOrdenCompra.Size = New System.Drawing.Size(289, 261)
        Me.dgvOrdenCompra.TabIndex = 397
        Me.dgvOrdenCompra.TableDescriptor.AllowNew = False
        Me.dgvOrdenCompra.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvOrdenCompra.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvOrdenCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvOrdenCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvOrdenCompra.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvOrdenCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvOrdenCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvOrdenCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvOrdenCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvOrdenCompra.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvOrdenCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvOrdenCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvOrdenCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvOrdenCompra.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor10.AllowSort = False
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "ID"
        GridColumnDescriptor10.MappingName = "idDocumento"
        GridColumnDescriptor10.Name = "idDocumento"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 50
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "Cant."
        GridColumnDescriptor11.MappingName = "cantidad"
        GridColumnDescriptor11.Name = "cantidad"
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 50
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "Descripción"
        GridColumnDescriptor12.MappingName = "descripcionItem"
        GridColumnDescriptor12.Name = "descripcionItem"
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 200
        Me.dgvOrdenCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12})
        Me.dgvOrdenCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvOrdenCompra.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvOrdenCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionItem")})
        Me.dgvOrdenCompra.Text = "GridGroupingControl2"
        Me.dgvOrdenCompra.VersionInfo = "12.4400.0.24"
        '
        'panel15
        '
        Me.panel15.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.panel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panel15.Controls.Add(Me.Label5)
        Me.panel15.Controls.Add(Me.Label4)
        Me.panel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel15.Location = New System.Drawing.Point(0, 0)
        Me.panel15.Name = "panel15"
        Me.panel15.Size = New System.Drawing.Size(1038, 24)
        Me.panel15.TabIndex = 400
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(596, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 19)
        Me.Label5.TabIndex = 171
        Me.Label5.Text = "HISTORIAL DE ENTREGA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(76, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 19)
        Me.Label4.TabIndex = 170
        Me.Label4.Text = "LISTA DE EXISTENCIAS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnExistencia)
        Me.Panel3.Controls.Add(Me.pnDetallesOC)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Location = New System.Drawing.Point(970, 101)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(352, 510)
        Me.Panel3.TabIndex = 0
        Me.Panel3.Visible = False
        '
        'pnExistencia
        '
        Me.pnExistencia.Controls.Add(Me.lblIdDocumento)
        Me.pnExistencia.Controls.Add(Me.txtNombreItem)
        Me.pnExistencia.Controls.Add(Me.Label2)
        Me.pnExistencia.Controls.Add(Me.lblCantidad)
        Me.pnExistencia.Controls.Add(Me.txtCantidad)
        Me.pnExistencia.Location = New System.Drawing.Point(5, 44)
        Me.pnExistencia.Name = "pnExistencia"
        Me.pnExistencia.Size = New System.Drawing.Size(342, 52)
        Me.pnExistencia.TabIndex = 273
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.AutoSize = True
        Me.lblIdDocumento.Location = New System.Drawing.Point(10, 13)
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(40, 13)
        Me.lblIdDocumento.TabIndex = 270
        Me.lblIdDocumento.Text = "Label5"
        Me.lblIdDocumento.Visible = False
        '
        'txtNombreItem
        '
        Me.txtNombreItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreItem.Location = New System.Drawing.Point(112, 5)
        Me.txtNombreItem.Name = "txtNombreItem"
        Me.txtNombreItem.ReadOnly = True
        Me.txtNombreItem.Size = New System.Drawing.Size(223, 19)
        Me.txtNombreItem.TabIndex = 266
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(61, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 267
        Me.Label2.Text = "Nombre:"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCantidad.Location = New System.Drawing.Point(55, 30)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(57, 13)
        Me.lblCantidad.TabIndex = 268
        Me.lblCantidad.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(112, 28)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(85, 22)
        Me.txtCantidad.TabIndex = 269
        '
        'pnDetallesOC
        '
        Me.pnDetallesOC.Controls.Add(Me.txtNotas)
        Me.pnDetallesOC.Controls.Add(Me.Label22)
        Me.pnDetallesOC.Controls.Add(Me.Label1)
        Me.pnDetallesOC.Controls.Add(Me.txtDirAlmacen)
        Me.pnDetallesOC.Controls.Add(Me.GroupBox3)
        Me.pnDetallesOC.Controls.Add(Me.GroupBox4)
        Me.pnDetallesOC.Controls.Add(Me.cboAlmacen)
        Me.pnDetallesOC.Controls.Add(Me.btnCancelarProv)
        Me.pnDetallesOC.Controls.Add(Me.Label16)
        Me.pnDetallesOC.Controls.Add(Me.btnGRabarProv)
        Me.pnDetallesOC.Controls.Add(Me.Label18)
        Me.pnDetallesOC.Controls.Add(Me.txtIndicaciones)
        Me.pnDetallesOC.Enabled = False
        Me.pnDetallesOC.Location = New System.Drawing.Point(5, 98)
        Me.pnDetallesOC.Name = "pnDetallesOC"
        Me.pnDetallesOC.Size = New System.Drawing.Size(342, 329)
        Me.pnDetallesOC.TabIndex = 272
        '
        'txtNotas
        '
        Me.txtNotas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotas.Location = New System.Drawing.Point(115, 295)
        Me.txtNotas.Multiline = True
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Size = New System.Drawing.Size(220, 27)
        Me.txtNotas.TabIndex = 266
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(15, 32)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 13)
        Me.Label22.TabIndex = 237
        Me.Label22.Text = "Lugar de Entrega:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "Nombre de Almacen:"
        '
        'txtDirAlmacen
        '
        Me.txtDirAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDirAlmacen.Location = New System.Drawing.Point(112, 29)
        Me.txtDirAlmacen.Name = "txtDirAlmacen"
        Me.txtDirAlmacen.Size = New System.Drawing.Size(223, 19)
        Me.txtDirAlmacen.TabIndex = 257
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtFechaInicioPlazo)
        Me.GroupBox3.Controls.Add(Me.txtFechaFinPlazo)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox3.Location = New System.Drawing.Point(111, 60)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(223, 92)
        Me.GroupBox3.TabIndex = 258
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Plazo de entrega:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(31, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 214
        Me.Label3.Text = "Del:"
        '
        'txtFechaInicioPlazo
        '
        Me.txtFechaInicioPlazo.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaInicioPlazo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicioPlazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaInicioPlazo.Calendar.AllowMultipleSelection = False
        Me.txtFechaInicioPlazo.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicioPlazo.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaInicioPlazo.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaInicioPlazo.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaInicioPlazo.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaInicioPlazo.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaInicioPlazo.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicioPlazo.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicioPlazo.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaInicioPlazo.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaInicioPlazo.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaInicioPlazo.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaInicioPlazo.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaInicioPlazo.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicioPlazo.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.Calendar.Name = "monthCalendar"
        Me.txtFechaInicioPlazo.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaInicioPlazo.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaInicioPlazo.Calendar.Size = New System.Drawing.Size(150, 174)
        Me.txtFechaInicioPlazo.Calendar.SizeToFit = True
        Me.txtFechaInicioPlazo.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicioPlazo.Calendar.TabIndex = 0
        Me.txtFechaInicioPlazo.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaInicioPlazo.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicioPlazo.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicioPlazo.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicioPlazo.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaInicioPlazo.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtFechaInicioPlazo.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaInicioPlazo.Calendar.NoneButton.Text = "None"
        Me.txtFechaInicioPlazo.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaInicioPlazo.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicioPlazo.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicioPlazo.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicioPlazo.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaInicioPlazo.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicioPlazo.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtFechaInicioPlazo.Calendar.TodayButton.Text = "Today"
        Me.txtFechaInicioPlazo.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaInicioPlazo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicioPlazo.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicioPlazo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaInicioPlazo.Checked = False
        Me.txtFechaInicioPlazo.CustomFormat = "dd/MM/yyyy "
        Me.txtFechaInicioPlazo.DropDownImage = Nothing
        Me.txtFechaInicioPlazo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaInicioPlazo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaInicioPlazo.Location = New System.Drawing.Point(63, 24)
        Me.txtFechaInicioPlazo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioPlazo.MinValue = New Date(CType(0, Long))
        Me.txtFechaInicioPlazo.Name = "txtFechaInicioPlazo"
        Me.txtFechaInicioPlazo.ShowCheckBox = False
        Me.txtFechaInicioPlazo.Size = New System.Drawing.Size(154, 20)
        Me.txtFechaInicioPlazo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicioPlazo.TabIndex = 215
        Me.txtFechaInicioPlazo.Value = New Date(2015, 9, 16, 16, 21, 59, 837)
        '
        'txtFechaFinPlazo
        '
        Me.txtFechaFinPlazo.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaFinPlazo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaFinPlazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaFinPlazo.Calendar.AllowMultipleSelection = False
        Me.txtFechaFinPlazo.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaFinPlazo.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaFinPlazo.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaFinPlazo.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaFinPlazo.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaFinPlazo.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaFinPlazo.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFinPlazo.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaFinPlazo.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaFinPlazo.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaFinPlazo.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaFinPlazo.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaFinPlazo.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaFinPlazo.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaFinPlazo.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.Calendar.Name = "monthCalendar"
        Me.txtFechaFinPlazo.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaFinPlazo.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaFinPlazo.Calendar.Size = New System.Drawing.Size(150, 174)
        Me.txtFechaFinPlazo.Calendar.SizeToFit = True
        Me.txtFechaFinPlazo.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaFinPlazo.Calendar.TabIndex = 0
        Me.txtFechaFinPlazo.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaFinPlazo.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaFinPlazo.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaFinPlazo.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaFinPlazo.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaFinPlazo.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtFechaFinPlazo.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaFinPlazo.Calendar.NoneButton.Text = "None"
        Me.txtFechaFinPlazo.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaFinPlazo.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaFinPlazo.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaFinPlazo.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaFinPlazo.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaFinPlazo.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaFinPlazo.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtFechaFinPlazo.Calendar.TodayButton.Text = "Today"
        Me.txtFechaFinPlazo.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaFinPlazo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFinPlazo.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaFinPlazo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaFinPlazo.Checked = False
        Me.txtFechaFinPlazo.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaFinPlazo.DropDownImage = Nothing
        Me.txtFechaFinPlazo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaFinPlazo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaFinPlazo.Location = New System.Drawing.Point(63, 57)
        Me.txtFechaFinPlazo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinPlazo.MinValue = New Date(CType(0, Long))
        Me.txtFechaFinPlazo.Name = "txtFechaFinPlazo"
        Me.txtFechaFinPlazo.ShowCheckBox = False
        Me.txtFechaFinPlazo.Size = New System.Drawing.Size(154, 20)
        Me.txtFechaFinPlazo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaFinPlazo.TabIndex = 217
        Me.txtFechaFinPlazo.Value = New Date(2015, 9, 16, 16, 22, 4, 448)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(37, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 216
        Me.Label7.Text = "Al:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.txtFechaFinGarantia)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.txtFechaInicioGarantia)
        Me.GroupBox4.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox4.Location = New System.Drawing.Point(111, 158)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(223, 92)
        Me.GroupBox4.TabIndex = 259
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Plazo de vencimiento:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(27, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(27, 13)
        Me.Label17.TabIndex = 219
        Me.Label17.Text = "Del:"
        '
        'txtFechaFinGarantia
        '
        Me.txtFechaFinGarantia.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaFinGarantia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaFinGarantia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaFinGarantia.Calendar.AllowMultipleSelection = False
        Me.txtFechaFinGarantia.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaFinGarantia.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaFinGarantia.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaFinGarantia.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinGarantia.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaFinGarantia.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaFinGarantia.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaFinGarantia.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFinGarantia.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaFinGarantia.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaFinGarantia.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaFinGarantia.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaFinGarantia.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaFinGarantia.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaFinGarantia.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaFinGarantia.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinGarantia.Calendar.Name = "monthCalendar"
        Me.txtFechaFinGarantia.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaFinGarantia.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaFinGarantia.Calendar.Size = New System.Drawing.Size(150, 174)
        Me.txtFechaFinGarantia.Calendar.SizeToFit = True
        Me.txtFechaFinGarantia.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaFinGarantia.Calendar.TabIndex = 0
        Me.txtFechaFinGarantia.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaFinGarantia.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaFinGarantia.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinGarantia.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaFinGarantia.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaFinGarantia.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaFinGarantia.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtFechaFinGarantia.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaFinGarantia.Calendar.NoneButton.Text = "None"
        Me.txtFechaFinGarantia.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaFinGarantia.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaFinGarantia.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinGarantia.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaFinGarantia.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaFinGarantia.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaFinGarantia.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaFinGarantia.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtFechaFinGarantia.Calendar.TodayButton.Text = "Today"
        Me.txtFechaFinGarantia.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaFinGarantia.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFinGarantia.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaFinGarantia.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaFinGarantia.Checked = False
        Me.txtFechaFinGarantia.CustomFormat = "dd/MM/yyyy "
        Me.txtFechaFinGarantia.DropDownImage = Nothing
        Me.txtFechaFinGarantia.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinGarantia.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinGarantia.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaFinGarantia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaFinGarantia.Location = New System.Drawing.Point(59, 57)
        Me.txtFechaFinGarantia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaFinGarantia.MinValue = New Date(CType(0, Long))
        Me.txtFechaFinGarantia.Name = "txtFechaFinGarantia"
        Me.txtFechaFinGarantia.ShowCheckBox = False
        Me.txtFechaFinGarantia.Size = New System.Drawing.Size(154, 20)
        Me.txtFechaFinGarantia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaFinGarantia.TabIndex = 222
        Me.txtFechaFinGarantia.Value = New Date(2015, 9, 16, 16, 22, 11, 193)
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(33, 64)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(20, 13)
        Me.Label21.TabIndex = 221
        Me.Label21.Text = "Al:"
        '
        'txtFechaInicioGarantia
        '
        Me.txtFechaInicioGarantia.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaInicioGarantia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicioGarantia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaInicioGarantia.Calendar.AllowMultipleSelection = False
        Me.txtFechaInicioGarantia.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicioGarantia.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaInicioGarantia.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaInicioGarantia.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioGarantia.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaInicioGarantia.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaInicioGarantia.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaInicioGarantia.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicioGarantia.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicioGarantia.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaInicioGarantia.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaInicioGarantia.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaInicioGarantia.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaInicioGarantia.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaInicioGarantia.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicioGarantia.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioGarantia.Calendar.Name = "monthCalendar"
        Me.txtFechaInicioGarantia.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaInicioGarantia.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaInicioGarantia.Calendar.Size = New System.Drawing.Size(150, 174)
        Me.txtFechaInicioGarantia.Calendar.SizeToFit = True
        Me.txtFechaInicioGarantia.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicioGarantia.Calendar.TabIndex = 0
        Me.txtFechaInicioGarantia.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaInicioGarantia.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicioGarantia.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioGarantia.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicioGarantia.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicioGarantia.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaInicioGarantia.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtFechaInicioGarantia.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaInicioGarantia.Calendar.NoneButton.Text = "None"
        Me.txtFechaInicioGarantia.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaInicioGarantia.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicioGarantia.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioGarantia.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicioGarantia.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicioGarantia.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaInicioGarantia.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicioGarantia.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtFechaInicioGarantia.Calendar.TodayButton.Text = "Today"
        Me.txtFechaInicioGarantia.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaInicioGarantia.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicioGarantia.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicioGarantia.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaInicioGarantia.Checked = False
        Me.txtFechaInicioGarantia.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaInicioGarantia.DropDownImage = Nothing
        Me.txtFechaInicioGarantia.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioGarantia.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioGarantia.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaInicioGarantia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaInicioGarantia.Location = New System.Drawing.Point(59, 24)
        Me.txtFechaInicioGarantia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicioGarantia.MinValue = New Date(CType(0, Long))
        Me.txtFechaInicioGarantia.Name = "txtFechaInicioGarantia"
        Me.txtFechaInicioGarantia.ShowCheckBox = False
        Me.txtFechaInicioGarantia.Size = New System.Drawing.Size(154, 20)
        Me.txtFechaInicioGarantia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicioGarantia.TabIndex = 220
        Me.txtFechaInicioGarantia.Value = New Date(2015, 9, 16, 16, 22, 8, 72)
        '
        'cboAlmacen
        '
        Me.cboAlmacen.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.BeforeTouchSize = New System.Drawing.Size(223, 19)
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.Location = New System.Drawing.Point(112, 3)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(223, 19)
        Me.cboAlmacen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAlmacen.TabIndex = 238
        '
        'btnCancelarProv
        '
        Me.btnCancelarProv.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnCancelarProv.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnCancelarProv.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.btnCancelarProv.ForeColor = System.Drawing.Color.White
        Me.btnCancelarProv.IsBackStageButton = False
        Me.btnCancelarProv.Location = New System.Drawing.Point(273, 330)
        Me.btnCancelarProv.Name = "btnCancelarProv"
        Me.btnCancelarProv.Size = New System.Drawing.Size(60, 19)
        Me.btnCancelarProv.TabIndex = 265
        Me.btnCancelarProv.TabStop = False
        Me.btnCancelarProv.Text = "Cancelar"
        Me.btnCancelarProv.UseVisualStyle = True
        Me.btnCancelarProv.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(39, 262)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 260
        Me.Label16.Text = "Indicaciones:"
        '
        'btnGRabarProv
        '
        Me.btnGRabarProv.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnGRabarProv.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnGRabarProv.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.btnGRabarProv.ForeColor = System.Drawing.Color.White
        Me.btnGRabarProv.IsBackStageButton = False
        Me.btnGRabarProv.Location = New System.Drawing.Point(211, 330)
        Me.btnGRabarProv.Name = "btnGRabarProv"
        Me.btnGRabarProv.Size = New System.Drawing.Size(60, 19)
        Me.btnGRabarProv.TabIndex = 264
        Me.btnGRabarProv.TabStop = False
        Me.btnGRabarProv.Text = "&Grabar"
        Me.btnGRabarProv.UseVisualStyle = True
        Me.btnGRabarProv.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(70, 295)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 13)
        Me.Label18.TabIndex = 261
        Me.Label18.Text = "Notas:"
        '
        'txtIndicaciones
        '
        Me.txtIndicaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicaciones.Location = New System.Drawing.Point(115, 262)
        Me.txtIndicaciones.Multiline = True
        Me.txtIndicaciones.Name = "txtIndicaciones"
        Me.txtIndicaciones.Size = New System.Drawing.Size(220, 27)
        Me.txtIndicaciones.TabIndex = 262
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbPorExistencia)
        Me.GroupBox2.Controls.Add(Me.rbTodo)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(342, 31)
        Me.GroupBox2.TabIndex = 271
        Me.GroupBox2.TabStop = False
        '
        'RbPorExistencia
        '
        Me.RbPorExistencia.AutoSize = True
        Me.RbPorExistencia.Location = New System.Drawing.Point(164, 9)
        Me.RbPorExistencia.Name = "RbPorExistencia"
        Me.RbPorExistencia.Size = New System.Drawing.Size(67, 17)
        Me.RbPorExistencia.TabIndex = 2
        Me.RbPorExistencia.Text = "&Por Item"
        Me.RbPorExistencia.UseVisualStyleBackColor = True
        '
        'rbTodo
        '
        Me.rbTodo.AutoSize = True
        Me.rbTodo.Location = New System.Drawing.Point(40, 9)
        Me.rbTodo.Name = "rbTodo"
        Me.rbTodo.Size = New System.Drawing.Size(50, 17)
        Me.rbTodo.TabIndex = 1
        Me.rbTodo.Text = "&Todo"
        Me.rbTodo.UseVisualStyleBackColor = True
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox3)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(1038, 22)
        Me.PanelError.TabIndex = 422
        Me.PanelError.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1019, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 288
        Me.PictureBox3.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'Timer1
        '
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GradientPanel3)
        Me.Panel4.Controls.Add(Me.GradientPanel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 22)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1038, 79)
        Me.Panel4.TabIndex = 423
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel3.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.Label6)
        Me.GradientPanel3.Controls.Add(Me.popupControlContainer1)
        Me.GradientPanel3.Controls.Add(Me.txtRuc)
        Me.GradientPanel3.Controls.Add(Me.txtProveedor)
        Me.GradientPanel3.Location = New System.Drawing.Point(280, 6)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(684, 64)
        Me.GradientPanel3.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(16, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 14)
        Me.Label6.TabIndex = 496
        Me.Label6.Text = "Información del Proveedor"
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.popupControlContainer1.Controls.Add(Me.lsvProveedor)
        Me.popupControlContainer1.Controls.Add(Me.cancel)
        Me.popupControlContainer1.Controls.Add(Me.OK)
        Me.popupControlContainer1.Location = New System.Drawing.Point(366, 99)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(279, 147)
        Me.popupControlContainer1.TabIndex = 494
        Me.popupControlContainer1.Visible = False
        '
        'lsvProveedor
        '
        Me.lsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProveedor.FullRowSelect = True
        Me.lsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.lsvProveedor.MultiSelect = False
        Me.lsvProveedor.Name = "lsvProveedor"
        Me.lsvProveedor.Size = New System.Drawing.Size(277, 145)
        Me.lsvProveedor.TabIndex = 3
        Me.lsvProveedor.UseCompatibleStateImageBehavior = False
        Me.lsvProveedor.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IdProveedor"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Proveedor"
        Me.ColumnHeader2.Width = 250
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Cuenta"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Numero"
        '
        'cancel
        '
        Me.cancel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.cancel.BackColor = System.Drawing.SystemColors.Highlight
        Me.cancel.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cancel.ForeColor = System.Drawing.Color.White
        Me.cancel.IsBackStageButton = False
        Me.cancel.Location = New System.Drawing.Point(65, 120)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(60, 21)
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
        Me.OK.BeforeTouchSize = New System.Drawing.Size(59, 21)
        Me.OK.ForeColor = System.Drawing.Color.White
        Me.OK.IsBackStageButton = False
        Me.OK.Location = New System.Drawing.Point(5, 120)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(59, 21)
        Me.OK.TabIndex = 1
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyle = True
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.White
        Me.txtRuc.BeforeTouchSize = New System.Drawing.Size(315, 22)
        Me.txtRuc.BorderColor = System.Drawing.Color.Silver
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRuc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtRuc.Location = New System.Drawing.Point(339, 36)
        Me.txtRuc.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.NearImage = CType(resources.GetObject("txtRuc.NearImage"), System.Drawing.Image)
        Me.txtRuc.Size = New System.Drawing.Size(153, 22)
        Me.txtRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtRuc.TabIndex = 218
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.White
        Me.txtProveedor.BeforeTouchSize = New System.Drawing.Size(315, 22)
        Me.txtProveedor.BorderColor = System.Drawing.Color.Silver
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProveedor.Location = New System.Drawing.Point(19, 36)
        Me.txtProveedor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.NearImage = CType(resources.GetObject("txtProveedor.NearImage"), System.Drawing.Image)
        Me.txtProveedor.Size = New System.Drawing.Size(315, 22)
        Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProveedor.TabIndex = 216
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.txtNumero)
        Me.GradientPanel1.Controls.Add(Me.Label30)
        Me.GradientPanel1.Controls.Add(Me.txtSerie)
        Me.GradientPanel1.Controls.Add(Me.txtFecha)
        Me.GradientPanel1.Location = New System.Drawing.Point(12, 6)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(266, 64)
        Me.GradientPanel1.TabIndex = 17
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(315, 22)
        Me.txtNumero.BorderColor = System.Drawing.Color.Silver
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumero.Location = New System.Drawing.Point(127, 182)
        Me.txtNumero.MaxLength = 20
        Me.txtNumero.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(174, 20)
        Me.txtNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNumero.TabIndex = 215
        Me.txtNumero.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.DimGray
        Me.Label30.Location = New System.Drawing.Point(17, 13)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(39, 14)
        Me.Label30.TabIndex = 495
        Me.Label30.Text = "Fecha"
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(315, 22)
        Me.txtSerie.BorderColor = System.Drawing.Color.Silver
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSerie.Location = New System.Drawing.Point(20, 182)
        Me.txtSerie.MaxLength = 10
        Me.txtSerie.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(101, 20)
        Me.txtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSerie.TabIndex = 4
        Me.txtSerie.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.txtFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFecha.Calendar.AllowMultipleSelection = False
        Me.txtFecha.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFecha.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFecha.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecha.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFecha.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.Iso8601CalenderFormat = False
        Me.txtFecha.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFecha.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.Name = "monthCalendar"
        Me.txtFecha.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFecha.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFecha.Calendar.Size = New System.Drawing.Size(129, 174)
        Me.txtFecha.Calendar.SizeToFit = True
        Me.txtFecha.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.Calendar.TabIndex = 0
        Me.txtFecha.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFecha.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecha.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecha.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFecha.Calendar.NoneButton.Location = New System.Drawing.Point(57, 0)
        Me.txtFecha.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFecha.Calendar.NoneButton.Text = "None"
        Me.txtFecha.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFecha.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecha.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecha.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFecha.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFecha.Calendar.TodayButton.Size = New System.Drawing.Size(57, 20)
        Me.txtFecha.Calendar.TodayButton.Text = "Today"
        Me.txtFecha.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.Checked = False
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecha.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(20, 38)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(133, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 1
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'frmDetalleOrdenDeCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.MediumSeaGreen
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(30, 10)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(70, 10)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(400, 40)
        CaptionLabel1.Text = "DETALLES DE ENTREGA"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1038, 389)
        Me.Controls.Add(Me.PanelDGV)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.PanelError)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MetroColor = System.Drawing.Color.Maroon
        Me.Name = "frmDetalleOrdenDeCompra"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ""
        CType(Me.DMIngreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDGV.ResumeLayout(False)
        CType(Me.dgvHistorialDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgvOrdenCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel15.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnExistencia.ResumeLayout(False)
        Me.pnExistencia.PerformLayout()
        Me.pnDetallesOC.ResumeLayout(False)
        Me.pnDetallesOC.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtFechaInicioPlazo.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicioPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinPlazo.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.txtFechaFinGarantia.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinGarantia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicioGarantia.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicioGarantia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.GradientPanel3,System.ComponentModel.ISupportInitialize).EndInit
        Me.GradientPanel3.ResumeLayout(false)
        Me.GradientPanel3.PerformLayout
        Me.popupControlContainer1.ResumeLayout(false)
        CType(Me.txtRuc,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtProveedor,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GradientPanel1,System.ComponentModel.ISupportInitialize).EndInit
        Me.GradientPanel1.ResumeLayout(false)
        Me.GradientPanel1.PerformLayout
        CType(Me.txtNumero,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtSerie,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFecha.Calendar,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Private WithEvents DMIngreso As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents cboTipoExistencia As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents PanelDGV As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents btnCancelarProv As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents btnGRabarProv As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtIndicaciones As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents cboAlmacen As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFinGarantia As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtFechaInicioGarantia As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaInicioPlazo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtFechaFinPlazo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDirAlmacen As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombreItem As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents dgvOrdenCompra As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents lblIdDocumento As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.DomainUpDown
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RbPorExistencia As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodo As System.Windows.Forms.RadioButton
    Friend WithEvents pnDetallesOC As System.Windows.Forms.Panel
    Friend WithEvents dgvHistorialDetalle As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents pnExistencia As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtNotas As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents popupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvProveedor As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents cancel As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents OK As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtRuc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtNumero As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Private WithEvents panel15 As System.Windows.Forms.Panel
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCanastaPedidoDeVentas
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCanastaPedidoDeVentas))
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
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel15 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboMonedaCobro = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ButtonAdv15 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.DateTimePickerAdv1 = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.popupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvProveedor = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.OK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtCliente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.GridPedidos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel15.SuspendLayout()
        CType(Me.cboMonedaCobro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimePickerAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupControlContainer1.SuspendLayout()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel15
        '
        Me.GradientPanel15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel15.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GradientPanel15.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel15.Controls.Add(Me.ProgressBar1)
        Me.GradientPanel15.Controls.Add(Me.ButtonAdv3)
        Me.GradientPanel15.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel15.Controls.Add(Me.Label17)
        Me.GradientPanel15.Controls.Add(Me.cboMonedaCobro)
        Me.GradientPanel15.Controls.Add(Me.ButtonAdv15)
        Me.GradientPanel15.Controls.Add(Me.DateTimePickerAdv1)
        Me.GradientPanel15.Controls.Add(Me.Label39)
        Me.GradientPanel15.Controls.Add(Me.popupControlContainer1)
        Me.GradientPanel15.Controls.Add(Me.txtRuc)
        Me.GradientPanel15.Controls.Add(Me.Label40)
        Me.GradientPanel15.Controls.Add(Me.txtCliente)
        Me.GradientPanel15.Controls.Add(Me.Label41)
        Me.GradientPanel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel15.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel15.Name = "GradientPanel15"
        Me.GradientPanel15.Size = New System.Drawing.Size(717, 61)
        Me.GradientPanel15.TabIndex = 252
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 8)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(40, 8)
        Me.ProgressBar1.TabIndex = 507
        Me.ProgressBar1.Visible = False
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(97, 32)
        Me.ButtonAdv3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.Image = CType(resources.GetObject("ButtonAdv3.Image"), System.Drawing.Image)
        Me.ButtonAdv3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(195, 18)
        Me.ButtonAdv3.MetroColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(97, 32)
        Me.ButtonAdv3.TabIndex = 506
        Me.ButtonAdv3.Text = "         Ver detalle"
        Me.ButtonAdv3.UseVisualStyle = True
        Me.ButtonAdv3.UseVisualStyleBackColor = False
        Me.ButtonAdv3.Visible = False
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(88, 32)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.Image = CType(resources.GetObject("ButtonAdv2.Image"), System.Drawing.Image)
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(105, 18)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(88, 32)
        Me.ButtonAdv2.TabIndex = 505
        Me.ButtonAdv2.Text = "           Eliminar pedido"
        Me.ButtonAdv2.UseVisualStyle = True
        Me.ButtonAdv2.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Corbel", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(391, 131)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 504
        Me.Label17.Text = "MONEDA"
        Me.Label17.Visible = False
        '
        'cboMonedaCobro
        '
        Me.cboMonedaCobro.BackColor = System.Drawing.Color.White
        Me.cboMonedaCobro.BeforeTouchSize = New System.Drawing.Size(119, 21)
        Me.cboMonedaCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonedaCobro.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonedaCobro.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERA"})
        Me.cboMonedaCobro.Location = New System.Drawing.Point(388, 150)
        Me.cboMonedaCobro.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboMonedaCobro.Name = "cboMonedaCobro"
        Me.cboMonedaCobro.Size = New System.Drawing.Size(119, 21)
        Me.cboMonedaCobro.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMonedaCobro.TabIndex = 503
        Me.cboMonedaCobro.Text = "NACIONAL"
        Me.cboMonedaCobro.Visible = False
        '
        'ButtonAdv15
        '
        Me.ButtonAdv15.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv15.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ButtonAdv15.BeforeTouchSize = New System.Drawing.Size(92, 32)
        Me.ButtonAdv15.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv15.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv15.Image = CType(resources.GetObject("ButtonAdv15.Image"), System.Drawing.Image)
        Me.ButtonAdv15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv15.IsBackStageButton = False
        Me.ButtonAdv15.Location = New System.Drawing.Point(11, 18)
        Me.ButtonAdv15.MetroColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ButtonAdv15.Name = "ButtonAdv15"
        Me.ButtonAdv15.Size = New System.Drawing.Size(92, 32)
        Me.ButtonAdv15.TabIndex = 423
        Me.ButtonAdv15.Text = "      Actualizar"
        Me.ButtonAdv15.UseVisualStyle = True
        Me.ButtonAdv15.UseVisualStyleBackColor = False
        '
        'DateTimePickerAdv1
        '
        Me.DateTimePickerAdv1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.DateTimePickerAdv1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.DateTimePickerAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DateTimePickerAdv1.CalendarSize = New System.Drawing.Size(189, 176)
        Me.DateTimePickerAdv1.Checked = False
        Me.DateTimePickerAdv1.CustomFormat = "MM/yyyy"
        Me.DateTimePickerAdv1.DropDownImage = Nothing
        Me.DateTimePickerAdv1.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateTimePickerAdv1.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateTimePickerAdv1.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.DateTimePickerAdv1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAdv1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAdv1.Location = New System.Drawing.Point(518, 150)
        Me.DateTimePickerAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateTimePickerAdv1.MinValue = New Date(CType(0, Long))
        Me.DateTimePickerAdv1.Name = "DateTimePickerAdv1"
        Me.DateTimePickerAdv1.ShowCheckBox = False
        Me.DateTimePickerAdv1.ShowDropButton = False
        Me.DateTimePickerAdv1.ShowUpDown = True
        Me.DateTimePickerAdv1.Size = New System.Drawing.Size(87, 20)
        Me.DateTimePickerAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.DateTimePickerAdv1.TabIndex = 497
        Me.DateTimePickerAdv1.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        Me.DateTimePickerAdv1.Visible = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Corbel", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(516, 131)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(54, 13)
        Me.Label39.TabIndex = 496
        Me.Label39.Text = "PERIODO"
        Me.Label39.Visible = False
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.popupControlContainer1.Controls.Add(Me.lsvProveedor)
        Me.popupControlContainer1.Controls.Add(Me.cancel)
        Me.popupControlContainer1.Controls.Add(Me.OK)
        Me.popupControlContainer1.Location = New System.Drawing.Point(404, 127)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(279, 147)
        Me.popupControlContainer1.TabIndex = 495
        Me.popupControlContainer1.Visible = False
        '
        'lsvProveedor
        '
        Me.lsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProveedor.FullRowSelect = True
        Me.lsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvProveedor.HideSelection = False
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
        Me.txtRuc.BeforeTouchSize = New System.Drawing.Size(257, 20)
        Me.txtRuc.BorderColor = System.Drawing.Color.Silver
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRuc.Location = New System.Drawing.Point(286, 149)
        Me.txtRuc.Metrocolor = System.Drawing.Color.Silver
        Me.txtRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(96, 20)
        Me.txtRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtRuc.TabIndex = 425
        Me.txtRuc.Visible = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Corbel", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(288, 131)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(28, 13)
        Me.Label40.TabIndex = 424
        Me.Label40.Text = "RUC"
        Me.Label40.Visible = False
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.BeforeTouchSize = New System.Drawing.Size(257, 20)
        Me.txtCliente.BorderColor = System.Drawing.Color.Silver
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCliente.Location = New System.Drawing.Point(23, 149)
        Me.txtCliente.Metrocolor = System.Drawing.Color.Silver
        Me.txtCliente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtCliente.Size = New System.Drawing.Size(257, 20)
        Me.txtCliente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCliente.TabIndex = 13
        Me.txtCliente.Visible = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Corbel", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(21, 131)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(114, 13)
        Me.Label41.TabIndex = 12
        Me.Label41.Text = "BUSCAR PROVEEDOR"
        Me.Label41.Visible = False
        '
        'GridPedidos
        '
        Me.GridPedidos.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GridPedidos.BackColor = System.Drawing.Color.White
        Me.GridPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridPedidos.Enabled = False
        Me.GridPedidos.Location = New System.Drawing.Point(0, 61)
        Me.GridPedidos.Name = "GridPedidos"
        Me.GridPedidos.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridPedidos.Size = New System.Drawing.Size(717, 279)
        Me.GridPedidos.TabIndex = 254
        GridColumnDescriptor1.HeaderText = "Tipo venta"
        GridColumnDescriptor1.MappingName = "tipoCompra"
        GridColumnDescriptor1.Name = "tipoCompra"
        GridColumnDescriptor2.AllowSort = False
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor2.HeaderText = "Fecha"
        GridColumnDescriptor2.MappingName = "fechaDoc"
        GridColumnDescriptor2.Name = "fechaDoc"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 140
        GridColumnDescriptor3.AllowSort = False
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.SystemColors.HotTrack
        GridColumnDescriptor3.HeaderText = "Comprador / Cliente"
        GridColumnDescriptor3.MappingName = "pedido"
        GridColumnDescriptor3.Name = "pedido"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 200
        GridColumnDescriptor4.AllowSort = False
        GridColumnDescriptor4.HeaderText = "Tipo Doc."
        GridColumnDescriptor4.MappingName = "tipoDoc"
        GridColumnDescriptor4.Name = "tipoDoc"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.Width = 65
        GridColumnDescriptor5.AllowSort = False
        GridColumnDescriptor5.MappingName = "serie"
        GridColumnDescriptor5.Name = "serie"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 40
        GridColumnDescriptor6.AllowSort = False
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor6.HeaderText = "Nro. pedido"
        GridColumnDescriptor6.MappingName = "numeroDoc"
        GridColumnDescriptor6.Name = "numeroDoc"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.Width = 65
        GridColumnDescriptor7.AllowSort = False
        GridColumnDescriptor7.HeaderText = "Doc. Identidad"
        GridColumnDescriptor7.MappingName = "NroDocEntidad"
        GridColumnDescriptor7.Name = "NroDocEntidad"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.Width = 80
        GridColumnDescriptor8.AllowSort = False
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor8.HeaderText = "Razón Social"
        GridColumnDescriptor8.MappingName = "NombreEntidad"
        GridColumnDescriptor8.Name = "NombreEntidad"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.Width = 220
        GridColumnDescriptor9.AllowSort = False
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor9.HeaderText = "Venta"
        GridColumnDescriptor9.MappingName = "importeTotal"
        GridColumnDescriptor9.Name = "importeTotal"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.Width = 97
        GridColumnDescriptor10.AllowSort = False
        GridColumnDescriptor10.MappingName = "tcDolLoc"
        GridColumnDescriptor10.Name = "tcDolLoc"
        GridColumnDescriptor11.HeaderText = "Venta M.E."
        GridColumnDescriptor11.MappingName = "importeUS"
        GridColumnDescriptor11.Name = "importeUS"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor12.HeaderText = "Moneda"
        GridColumnDescriptor12.MappingName = "monedaDoc"
        GridColumnDescriptor12.Name = "monedaDoc"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.Width = 55
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor13.MappingName = "estado"
        GridColumnDescriptor13.Name = "estado"
        GridColumnDescriptor13.Width = 50
        GridColumnDescriptor14.MappingName = "idcliente"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.Width = 0
        Me.GridPedidos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("idDocumento", "idDocumento"), GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("usuarioActualizacion", "usuarioActualizacion"), GridColumnDescriptor13, GridColumnDescriptor14})
        Me.GridPedidos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("pedido"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numeroDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monedaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeTotal"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeUS")})
        Me.GridPedidos.Text = "GridGroupingControl1"
        Me.GridPedidos.TopLevelGroupOptions.ShowCaption = True
        Me.GridPedidos.UseRightToLeftCompatibleTextBox = True
        Me.GridPedidos.VersionInfo = "12.4400.0.24"
        '
        'FormCanastaPedidoDeVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Confirmar venta"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(717, 340)
        Me.Controls.Add(Me.GridPedidos)
        Me.Controls.Add(Me.GradientPanel15)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormCanastaPedidoDeVentas"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.Text = "Canasta Pedido De Ventas"
        CType(Me.GradientPanel15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel15.ResumeLayout(False)
        Me.GradientPanel15.PerformLayout()
        CType(Me.cboMonedaCobro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimePickerAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupControlContainer1.ResumeLayout(False)
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel15 As Tools.GradientPanel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ButtonAdv3 As ButtonAdv
    Friend WithEvents ButtonAdv2 As ButtonAdv
    Friend WithEvents Label17 As Label
    Friend WithEvents cboMonedaCobro As Tools.ComboBoxAdv
    Friend WithEvents ButtonAdv15 As ButtonAdv
    Friend WithEvents DateTimePickerAdv1 As Tools.DateTimePickerAdv
    Friend WithEvents Label39 As Label
    Private WithEvents popupControlContainer1 As PopupControlContainer
    Friend WithEvents lsvProveedor As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Private WithEvents cancel As ButtonAdv
    Private WithEvents OK As ButtonAdv
    Friend WithEvents txtRuc As Tools.TextBoxExt
    Friend WithEvents Label40 As Label
    Friend WithEvents txtCliente As Tools.TextBoxExt
    Friend WithEvents Label41 As Label
    Friend WithEvents GridPedidos As Grid.Grouping.GridGroupingControl
End Class

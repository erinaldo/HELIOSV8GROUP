Imports Syncfusion.Windows.Forms
Partial Class FormNuevoRubro
    Inherits MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNuevoRubro))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.rbConControl = New System.Windows.Forms.RadioButton()
        Me.rbSinControl = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboNegocioOrg = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.dgPedidos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboProvinciaOrigen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ComboRegionOrigen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ComboDistritoOrigen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton4 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboProvinciaOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboRegionOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboDistritoOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(26, 107)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(272, 39)
        Me.TextBox1.TabIndex = 0
        '
        'rbConControl
        '
        Me.rbConControl.AutoSize = True
        Me.rbConControl.Checked = True
        Me.rbConControl.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.rbConControl.Location = New System.Drawing.Point(360, 95)
        Me.rbConControl.Name = "rbConControl"
        Me.rbConControl.Size = New System.Drawing.Size(140, 17)
        Me.rbConControl.TabIndex = 1024
        Me.rbConControl.TabStop = True
        Me.rbConControl.Text = "CONTROL COMERCIAL"
        Me.rbConControl.UseVisualStyleBackColor = True
        '
        'rbSinControl
        '
        Me.rbSinControl.AutoSize = True
        Me.rbSinControl.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.rbSinControl.Location = New System.Drawing.Point(506, 95)
        Me.rbSinControl.Name = "rbSinControl"
        Me.rbSinControl.Size = New System.Drawing.Size(132, 17)
        Me.rbSinControl.TabIndex = 1025
        Me.rbSinControl.Text = "CONTROL DE APOYO"
        Me.rbSinControl.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(8, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 19)
        Me.Label1.TabIndex = 1026
        Me.Label1.Text = "Unidad Organica"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(23, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 1027
        Me.Label2.Text = "Descripción"
        '
        'cboNegocioOrg
        '
        Me.cboNegocioOrg.BackColor = System.Drawing.Color.White
        Me.cboNegocioOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNegocioOrg.FormattingEnabled = True
        Me.cboNegocioOrg.Location = New System.Drawing.Point(343, 152)
        Me.cboNegocioOrg.Name = "cboNegocioOrg"
        Me.cboNegocioOrg.Size = New System.Drawing.Size(285, 21)
        Me.cboNegocioOrg.TabIndex = 1029
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CheckBox1.Location = New System.Drawing.Point(344, 129)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(109, 17)
        Me.CheckBox1.TabIndex = 1028
        Me.CheckBox1.Text = "Asignar Modulo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'dgPedidos
        '
        Me.dgPedidos.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.SelectAll
        Me.dgPedidos.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgPedidos.BackColor = System.Drawing.SystemColors.Window
        Me.dgPedidos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgPedidos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgPedidos.Location = New System.Drawing.Point(343, 209)
        Me.dgPedidos.Name = "dgPedidos"
        Me.dgPedidos.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgPedidos.Size = New System.Drawing.Size(285, 223)
        Me.dgPedidos.TabIndex = 1030
        Me.dgPedidos.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.MappingName = "DETALLE"
        GridColumnDescriptor2.Name = "DETALLE"
        GridColumnDescriptor2.Width = 200
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridColumnDescriptor3.MappingName = "ESTADO"
        GridColumnDescriptor3.Name = "ESTADO"
        GridColumnDescriptor3.Width = 60
        Me.dgPedidos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.dgPedidos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgPedidos.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgPedidos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DETALLE"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ESTADO")})
        Me.dgPedidos.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgPedidos.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgPedidos.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgPedidos.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.dgPedidos.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgPedidos.Text = "GridGroupingControl2"
        Me.dgPedidos.TopLevelGroupOptions.IsExpandedInitialValue = True
        Me.dgPedidos.TopLevelGroupOptions.RepaintCaptionWhenItemsChanged = True
        Me.dgPedidos.TopLevelGroupOptions.ShowAddNewRecordAfterDetails = False
        Me.dgPedidos.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = True
        Me.dgPedidos.TopLevelGroupOptions.ShowCaption = False
        Me.dgPedidos.TopLevelGroupOptions.ShowCaptionPlusMinus = False
        Me.dgPedidos.TopLevelGroupOptions.ShowCaptionSummaryCells = False
        Me.dgPedidos.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.dgPedidos.TopLevelGroupOptions.ShowEmptyGroups = False
        Me.dgPedidos.TopLevelGroupOptions.ShowFilterBar = False
        Me.dgPedidos.TopLevelGroupOptions.ShowGroupFooter = False
        Me.dgPedidos.TopLevelGroupOptions.ShowGroupHeader = False
        Me.dgPedidos.TopLevelGroupOptions.ShowGroupIndentAsCoveredRange = False
        Me.dgPedidos.TopLevelGroupOptions.ShowGroupPreview = False
        Me.dgPedidos.TopLevelGroupOptions.ShowGroupSummaryWhenCollapsed = False
        Me.dgPedidos.TopLevelGroupOptions.ShowStackedHeaders = True
        Me.dgPedidos.TopLevelGroupOptions.ShowSummaries = True
        Me.dgPedidos.UseRightToLeftCompatibleTextBox = True
        Me.dgPedidos.VersionInfo = "12.4400.0.24"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(341, 183)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 1032
        Me.Label3.Text = "Detalle de modulos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(23, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 1034
        Me.Label4.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(26, 181)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(272, 39)
        Me.txtDireccion.TabIndex = 1033
        '
        'txttelefono
        '
        Me.txttelefono.Location = New System.Drawing.Point(130, 256)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(75, 20)
        Me.txttelefono.TabIndex = 1035
        '
        'txtCelular
        '
        Me.txtCelular.Location = New System.Drawing.Point(221, 256)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(77, 20)
        Me.txtCelular.TabIndex = 1036
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(127, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 1037
        Me.Label5.Text = "Telefono"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(218, 237)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 1038
        Me.Label6.Text = "Celular"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(330, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(177, 19)
        Me.Label7.TabIndex = 1039
        Me.Label7.Text = "Tipo de Unidad Organica"
        '
        'ComboProvinciaOrigen
        '
        Me.ComboProvinciaOrigen.BackColor = System.Drawing.Color.White
        Me.ComboProvinciaOrigen.BeforeTouchSize = New System.Drawing.Size(272, 21)
        Me.ComboProvinciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboProvinciaOrigen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboProvinciaOrigen.Location = New System.Drawing.Point(26, 361)
        Me.ComboProvinciaOrigen.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboProvinciaOrigen.Name = "ComboProvinciaOrigen"
        Me.ComboProvinciaOrigen.Size = New System.Drawing.Size(272, 21)
        Me.ComboProvinciaOrigen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboProvinciaOrigen.TabIndex = 1045
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(23, 340)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 13)
        Me.Label26.TabIndex = 1044
        Me.Label26.Text = "Provincia"
        '
        'ComboRegionOrigen
        '
        Me.ComboRegionOrigen.BackColor = System.Drawing.Color.White
        Me.ComboRegionOrigen.BeforeTouchSize = New System.Drawing.Size(272, 21)
        Me.ComboRegionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboRegionOrigen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboRegionOrigen.Location = New System.Drawing.Point(26, 308)
        Me.ComboRegionOrigen.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboRegionOrigen.Name = "ComboRegionOrigen"
        Me.ComboRegionOrigen.Size = New System.Drawing.Size(272, 21)
        Me.ComboRegionOrigen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboRegionOrigen.TabIndex = 1043
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(23, 287)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(51, 13)
        Me.Label25.TabIndex = 1042
        Me.Label25.Text = "Regiones"
        '
        'ComboDistritoOrigen
        '
        Me.ComboDistritoOrigen.BackColor = System.Drawing.Color.White
        Me.ComboDistritoOrigen.BeforeTouchSize = New System.Drawing.Size(272, 21)
        Me.ComboDistritoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDistritoOrigen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboDistritoOrigen.Location = New System.Drawing.Point(26, 411)
        Me.ComboDistritoOrigen.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboDistritoOrigen.Name = "ComboDistritoOrigen"
        Me.ComboDistritoOrigen.Size = New System.Drawing.Size(272, 21)
        Me.ComboDistritoOrigen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboDistritoOrigen.TabIndex = 1041
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(26, 392)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 1040
        Me.Label8.Text = "Distrito"
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BackColor = System.Drawing.Color.White
        Me.GradientPanel8.BackgroundImage = CType(resources.GetObject("GradientPanel8.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel8.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel8.Controls.Add(Me.PictureLoad)
        Me.GradientPanel8.Controls.Add(Me.BunifuFlatButton1)
        Me.GradientPanel8.Controls.Add(Me.BunifuFlatButton4)
        Me.GradientPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel8.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(652, 49)
        Me.GradientPanel8.TabIndex = 1031
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(304, 10)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 661
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 5
        Me.BunifuFlatButton1.ButtonText = "CERRAR"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = Nothing
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(155, 10)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(144, 23)
        Me.BunifuFlatButton1.TabIndex = 28
        Me.BunifuFlatButton1.Text = "CERRAR"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton4
        '
        Me.BunifuFlatButton4.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton4.BorderRadius = 5
        Me.BunifuFlatButton4.ButtonText = "GRABAR"
        Me.BunifuFlatButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton4.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton4.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton4.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton4.Iconimage = Nothing
        Me.BunifuFlatButton4.Iconimage_right = Nothing
        Me.BunifuFlatButton4.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton4.Iconimage_Selected = Nothing
        Me.BunifuFlatButton4.IconMarginLeft = 0
        Me.BunifuFlatButton4.IconMarginRight = 0
        Me.BunifuFlatButton4.IconRightVisible = True
        Me.BunifuFlatButton4.IconRightZoom = 0R
        Me.BunifuFlatButton4.IconVisible = True
        Me.BunifuFlatButton4.IconZoom = 90.0R
        Me.BunifuFlatButton4.IsTab = False
        Me.BunifuFlatButton4.Location = New System.Drawing.Point(11, 10)
        Me.BunifuFlatButton4.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton4.Name = "BunifuFlatButton4"
        Me.BunifuFlatButton4.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton4.selected = False
        Me.BunifuFlatButton4.Size = New System.Drawing.Size(140, 23)
        Me.BunifuFlatButton4.TabIndex = 27
        Me.BunifuFlatButton4.Text = "GRABAR"
        Me.BunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton4.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton4.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(23, 237)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 1047
        Me.Label16.Text = "Inicio de oper."
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtPeriodo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtPeriodo.Checked = False
        Me.txtPeriodo.CustomFormat = "MM/yyyy"
        Me.txtPeriodo.DropDownImage = Nothing
        Me.txtPeriodo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtPeriodo.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtPeriodo.Location = New System.Drawing.Point(26, 256)
        Me.txtPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.MinValue = New Date(CType(0, Long))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ShowCheckBox = False
        Me.txtPeriodo.ShowDropButton = False
        Me.txtPeriodo.ShowUpDown = True
        Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.TabIndex = 1046
        Me.txtPeriodo.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        '
        'FormNuevoRubro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionBarHeight = 45
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.tor4
        CaptionImage1.Location = New System.Drawing.Point(10, 10)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(50, 3)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Unidad Organica"
        CaptionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.White
        CaptionLabel2.Location = New System.Drawing.Point(50, 20)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(300, 24)
        CaptionLabel2.Text = "Organizar Unid. Org."
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(652, 450)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.ComboProvinciaOrigen)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.ComboRegionOrigen)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.ComboDistritoOrigen)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCelular)
        Me.Controls.Add(Me.txttelefono)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GradientPanel8)
        Me.Controls.Add(Me.dgPedidos)
        Me.Controls.Add(Me.cboNegocioOrg)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rbSinControl)
        Me.Controls.Add(Me.rbConControl)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "FormNuevoRubro"
        Me.ShowIcon = False
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboProvinciaOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboRegionOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboDistritoOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents rbConControl As RadioButton
    Friend WithEvents rbSinControl As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboNegocioOrg As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents dgPedidos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel8 As Tools.GradientPanel
    Friend WithEvents PictureLoad As PictureBox
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton4 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents txttelefono As TextBox
    Friend WithEvents txtCelular As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboProvinciaOrigen As Tools.ComboBoxAdv
    Friend WithEvents Label26 As Label
    Friend WithEvents ComboRegionOrigen As Tools.ComboBoxAdv
    Friend WithEvents Label25 As Label
    Friend WithEvents ComboDistritoOrigen As Tools.ComboBoxAdv
    Friend WithEvents Label8 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtPeriodo As Tools.DateTimePickerAdv
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCUnidOrganica_Jerarq
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCUnidOrganica_Jerarq))
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIdUOJe = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtBusqUniOrgaJerar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.lblNroNiv = New System.Windows.Forms.Label()
        Me.Line22 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.cbrubroOrg = New System.Windows.Forms.ComboBox()
        Me.cbsegmentoOrg = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnNuevo = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbNivelesOrg = New System.Windows.Forms.ComboBox()
        Me.PanelBody = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.DGUnidJerarquia = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnGuarTodo = New Bunifu.Framework.UI.BunifuFlatButton()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtIdUOJe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBusqUniOrgaJerar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBody.SuspendLayout()
        CType(Me.DGUnidJerarquia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.btnGuarTodo)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.txtIdUOJe)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.PictureBox2)
        Me.GradientPanel1.Controls.Add(Me.txtBusqUniOrgaJerar)
        Me.GradientPanel1.Controls.Add(Me.lblNroNiv)
        Me.GradientPanel1.Controls.Add(Me.Line22)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton2)
        Me.GradientPanel1.Controls.Add(Me.cbrubroOrg)
        Me.GradientPanel1.Controls.Add(Me.cbsegmentoOrg)
        Me.GradientPanel1.Controls.Add(Me.Label6)
        Me.GradientPanel1.Controls.Add(Me.Label8)
        Me.GradientPanel1.Controls.Add(Me.btnNuevo)
        Me.GradientPanel1.Controls.Add(Me.Label9)
        Me.GradientPanel1.Controls.Add(Me.cbNivelesOrg)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(801, 207)
        Me.GradientPanel1.TabIndex = 903
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(24, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 979
        Me.Label3.Text = "Nro U.O"
        '
        'txtIdUOJe
        '
        Me.txtIdUOJe.BackColor = System.Drawing.SystemColors.Info
        Me.txtIdUOJe.BeforeTouchSize = New System.Drawing.Size(467, 22)
        Me.txtIdUOJe.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtIdUOJe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdUOJe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdUOJe.CornerRadius = 3
        Me.txtIdUOJe.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtIdUOJe.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdUOJe.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtIdUOJe.Location = New System.Drawing.Point(15, 133)
        Me.txtIdUOJe.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtIdUOJe.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtIdUOJe.Name = "txtIdUOJe"
        Me.txtIdUOJe.Size = New System.Drawing.Size(66, 23)
        Me.txtIdUOJe.TabIndex = 978
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(90, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 13)
        Me.Label1.TabIndex = 977
        Me.Label1.Text = "BUSQUEDA  UNIDAD ORGÁNICA DE NIVEL:"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(532, 135)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 976
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'txtBusqUniOrgaJerar
        '
        Me.txtBusqUniOrgaJerar.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtBusqUniOrgaJerar.BeforeTouchSize = New System.Drawing.Size(467, 22)
        Me.txtBusqUniOrgaJerar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtBusqUniOrgaJerar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBusqUniOrgaJerar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqUniOrgaJerar.CornerRadius = 3
        Me.txtBusqUniOrgaJerar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBusqUniOrgaJerar.FarImage = CType(resources.GetObject("txtBusqUniOrgaJerar.FarImage"), System.Drawing.Image)
        Me.txtBusqUniOrgaJerar.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtBusqUniOrgaJerar.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqUniOrgaJerar.ForeColor = System.Drawing.Color.Black
        Me.txtBusqUniOrgaJerar.Location = New System.Drawing.Point(87, 133)
        Me.txtBusqUniOrgaJerar.MaxLength = 400
        Me.txtBusqUniOrgaJerar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtBusqUniOrgaJerar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBusqUniOrgaJerar.Name = "txtBusqUniOrgaJerar"
        Me.txtBusqUniOrgaJerar.NearImage = CType(resources.GetObject("txtBusqUniOrgaJerar.NearImage"), System.Drawing.Image)
        Me.txtBusqUniOrgaJerar.Size = New System.Drawing.Size(467, 22)
        Me.txtBusqUniOrgaJerar.TabIndex = 974
        '
        'lblNroNiv
        '
        Me.lblNroNiv.AutoSize = True
        Me.lblNroNiv.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroNiv.ForeColor = System.Drawing.Color.Red
        Me.lblNroNiv.Location = New System.Drawing.Point(327, 107)
        Me.lblNroNiv.Name = "lblNroNiv"
        Me.lblNroNiv.Size = New System.Drawing.Size(13, 19)
        Me.lblNroNiv.TabIndex = 975
        Me.lblNroNiv.Text = "."
        '
        'Line22
        '
        Me.Line22.LineColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Line22.Location = New System.Drawing.Point(10, 167)
        Me.Line22.Name = "Line22"
        Me.Line22.Size = New System.Drawing.Size(700, 1)
        Me.Line22.TabIndex = 953
        Me.Line22.Text = "Line22"
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = "Nuevo nivel"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton2.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = Nothing
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = True
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 90.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(690, 107)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(87, 18)
        Me.BunifuFlatButton2.TabIndex = 952
        Me.BunifuFlatButton2.Text = "Nuevo nivel"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.SystemColors.HotTrack
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Segoe UI Semibold", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'cbrubroOrg
        '
        Me.cbrubroOrg.BackColor = System.Drawing.Color.White
        Me.cbrubroOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbrubroOrg.FormattingEnabled = True
        Me.cbrubroOrg.Location = New System.Drawing.Point(15, 30)
        Me.cbrubroOrg.Name = "cbrubroOrg"
        Me.cbrubroOrg.Size = New System.Drawing.Size(204, 21)
        Me.cbrubroOrg.TabIndex = 948
        '
        'cbsegmentoOrg
        '
        Me.cbsegmentoOrg.BackColor = System.Drawing.Color.White
        Me.cbsegmentoOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbsegmentoOrg.FormattingEnabled = True
        Me.cbsegmentoOrg.Location = New System.Drawing.Point(15, 78)
        Me.cbsegmentoOrg.Name = "cbsegmentoOrg"
        Me.cbsegmentoOrg.Size = New System.Drawing.Size(207, 21)
        Me.cbsegmentoOrg.TabIndex = 951
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label6.Location = New System.Drawing.Point(23, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 17)
        Me.Label6.TabIndex = 950
        Me.Label6.Text = "ESTABLECIMIENTO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label8.Location = New System.Drawing.Point(23, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 17)
        Me.Label8.TabIndex = 949
        Me.Label8.Text = "RUBRO"
        '
        'btnNuevo
        '
        Me.btnNuevo.Activecolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevo.BorderRadius = 5
        Me.btnNuevo.ButtonText = "AGREGAR"
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.DisabledColor = System.Drawing.Color.Gray
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnNuevo.Iconcolor = System.Drawing.Color.Transparent
        Me.btnNuevo.Iconimage = Nothing
        Me.btnNuevo.Iconimage_right = Nothing
        Me.btnNuevo.Iconimage_right_Selected = Nothing
        Me.btnNuevo.Iconimage_Selected = Nothing
        Me.btnNuevo.IconMarginLeft = 0
        Me.btnNuevo.IconMarginRight = 0
        Me.btnNuevo.IconRightVisible = True
        Me.btnNuevo.IconRightZoom = 0R
        Me.btnNuevo.IconVisible = True
        Me.btnNuevo.IconZoom = 90.0R
        Me.btnNuevo.IsTab = False
        Me.btnNuevo.Location = New System.Drawing.Point(15, 177)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnNuevo.selected = False
        Me.btnNuevo.Size = New System.Drawing.Size(98, 23)
        Me.btnNuevo.TabIndex = 947
        Me.btnNuevo.Text = "AGREGAR"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNuevo.Textcolor = System.Drawing.Color.White
        Me.btnNuevo.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label9.Location = New System.Drawing.Point(568, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 17)
        Me.Label9.TabIndex = 547
        Me.Label9.Text = "NIVELES"
        '
        'cbNivelesOrg
        '
        Me.cbNivelesOrg.BackColor = System.Drawing.Color.White
        Me.cbNivelesOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNivelesOrg.FormattingEnabled = True
        Me.cbNivelesOrg.Location = New System.Drawing.Point(560, 133)
        Me.cbNivelesOrg.Name = "cbNivelesOrg"
        Me.cbNivelesOrg.Size = New System.Drawing.Size(207, 21)
        Me.cbNivelesOrg.TabIndex = 546
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PanelBody.BorderColor = System.Drawing.Color.Gainsboro
        Me.PanelBody.BorderSides = CType((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Right), System.Windows.Forms.Border3DSide)
        Me.PanelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBody.Controls.Add(Me.DGUnidJerarquia)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 207)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(801, 267)
        Me.PanelBody.TabIndex = 905
        '
        'DGUnidJerarquia
        '
        Me.DGUnidJerarquia.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DGUnidJerarquia.BackColor = System.Drawing.Color.White
        Me.DGUnidJerarquia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGUnidJerarquia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGUnidJerarquia.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGUnidJerarquia.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.DGUnidJerarquia.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.DGUnidJerarquia.Location = New System.Drawing.Point(0, 0)
        Me.DGUnidJerarquia.Name = "DGUnidJerarquia"
        Me.DGUnidJerarquia.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.DGUnidJerarquia.Size = New System.Drawing.Size(799, 265)
        Me.DGUnidJerarquia.TabIndex = 840
        Me.DGUnidJerarquia.TableDescriptor.AllowNew = False
        GridColumnDescriptor5.MappingName = "descripcion"
        GridColumnDescriptor5.Width = 450
        GridColumnDescriptor6.MappingName = "tipo"
        GridColumnDescriptor6.Width = 150
        Me.DGUnidJerarquia.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("NroOrganizacion"), GridColumnDescriptor5, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("Estado"), GridColumnDescriptor6})
        Me.DGUnidJerarquia.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.DGUnidJerarquia.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.DGUnidJerarquia.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NroOrganizacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Estado")})
        Me.DGUnidJerarquia.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DGUnidJerarquia.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.DGUnidJerarquia.Text = "gridGroupingControl1"
        Me.DGUnidJerarquia.TopLevelGroupOptions.ShowCaption = False
        Me.DGUnidJerarquia.UseRightToLeftCompatibleTextBox = True
        Me.DGUnidJerarquia.VersionInfo = "12.2400.0.20"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnGuarTodo
        '
        Me.btnGuarTodo.Activecolor = System.Drawing.Color.Green
        Me.btnGuarTodo.BackColor = System.Drawing.Color.Green
        Me.btnGuarTodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGuarTodo.BorderRadius = 5
        Me.btnGuarTodo.ButtonText = "GUARDAR"
        Me.btnGuarTodo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuarTodo.DisabledColor = System.Drawing.Color.Gray
        Me.btnGuarTodo.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuarTodo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnGuarTodo.Iconcolor = System.Drawing.Color.Transparent
        Me.btnGuarTodo.Iconimage = Nothing
        Me.btnGuarTodo.Iconimage_right = Nothing
        Me.btnGuarTodo.Iconimage_right_Selected = Nothing
        Me.btnGuarTodo.Iconimage_Selected = Nothing
        Me.btnGuarTodo.IconMarginLeft = 0
        Me.btnGuarTodo.IconMarginRight = 0
        Me.btnGuarTodo.IconRightVisible = True
        Me.btnGuarTodo.IconRightZoom = 0R
        Me.btnGuarTodo.IconVisible = True
        Me.btnGuarTodo.IconZoom = 90.0R
        Me.btnGuarTodo.IsTab = False
        Me.btnGuarTodo.Location = New System.Drawing.Point(117, 177)
        Me.btnGuarTodo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGuarTodo.Name = "btnGuarTodo"
        Me.btnGuarTodo.Normalcolor = System.Drawing.Color.Green
        Me.btnGuarTodo.OnHovercolor = System.Drawing.Color.Green
        Me.btnGuarTodo.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnGuarTodo.selected = False
        Me.btnGuarTodo.Size = New System.Drawing.Size(94, 22)
        Me.btnGuarTodo.TabIndex = 1022
        Me.btnGuarTodo.Text = "GUARDAR"
        Me.btnGuarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnGuarTodo.Textcolor = System.Drawing.Color.White
        Me.btnGuarTodo.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'UCUnidOrganica_Jerarq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "UCUnidOrganica_Jerarq"
        Me.Size = New System.Drawing.Size(801, 474)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtIdUOJe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBusqUniOrgaJerar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBody.ResumeLayout(False)
        CType(Me.DGUnidJerarquia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label9 As Label
    Friend WithEvents cbNivelesOrg As ComboBox
    Friend WithEvents PanelBody As Syncfusion.Windows.Forms.Tools.GradientPanel
    Public WithEvents DGUnidJerarquia As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Private WithEvents btnNuevo As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents cbrubroOrg As ComboBox
    Friend WithEvents cbsegmentoOrg As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Line22 As Line2
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents txtBusqUniOrgaJerar As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents lblNroNiv As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtIdUOJe As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents btnGuarTodo As Bunifu.Framework.UI.BunifuFlatButton
End Class

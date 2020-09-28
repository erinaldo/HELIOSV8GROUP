<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCComisionDesembolso
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCComisionDesembolso))
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboTipoComision = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.NumericTotalComisionesAfavor = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.NumericTotalDesembolso = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.bunifuFlatButton6 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextUsuario = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCodigo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BunifuFlatButton4 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.GridProducts = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1.SuspendLayout()
        CType(Me.ComboTipoComision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericTotalComisionesAfavor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericTotalDesembolso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ComboTipoComision)
        Me.Panel1.Controls.Add(Me.NumericTotalComisionesAfavor)
        Me.Panel1.Controls.Add(Me.NumericTotalDesembolso)
        Me.Panel1.Controls.Add(Me.bunifuFlatButton6)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TextUsuario)
        Me.Panel1.Controls.Add(Me.TextCodigo)
        Me.Panel1.Controls.Add(Me.BunifuFlatButton4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1097, 50)
        Me.Panel1.TabIndex = 309
        '
        'ComboTipoComision
        '
        Me.ComboTipoComision.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboTipoComision.BeforeTouchSize = New System.Drawing.Size(95, 21)
        Me.ComboTipoComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoComision.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboTipoComision.Items.AddRange(New Object() {"DNI", "CODIGO"})
        Me.ComboTipoComision.Location = New System.Drawing.Point(9, 18)
        Me.ComboTipoComision.Name = "ComboTipoComision"
        Me.ComboTipoComision.Size = New System.Drawing.Size(95, 21)
        Me.ComboTipoComision.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboTipoComision.TabIndex = 676
        Me.ComboTipoComision.Text = "DNI"
        '
        'NumericTotalComisionesAfavor
        '
        Me.NumericTotalComisionesAfavor.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.NumericTotalComisionesAfavor.BeforeTouchSize = New System.Drawing.Size(120, 22)
        Me.NumericTotalComisionesAfavor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.NumericTotalComisionesAfavor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericTotalComisionesAfavor.DecimalPlaces = 2
        Me.NumericTotalComisionesAfavor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericTotalComisionesAfavor.ForeColor = System.Drawing.Color.White
        Me.NumericTotalComisionesAfavor.Location = New System.Drawing.Point(563, 18)
        Me.NumericTotalComisionesAfavor.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericTotalComisionesAfavor.MetroColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.NumericTotalComisionesAfavor.Name = "NumericTotalComisionesAfavor"
        Me.NumericTotalComisionesAfavor.Size = New System.Drawing.Size(120, 22)
        Me.NumericTotalComisionesAfavor.TabIndex = 675
        Me.NumericTotalComisionesAfavor.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'NumericTotalDesembolso
        '
        Me.NumericTotalDesembolso.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.NumericTotalDesembolso.BeforeTouchSize = New System.Drawing.Size(120, 22)
        Me.NumericTotalDesembolso.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.NumericTotalDesembolso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericTotalDesembolso.DecimalPlaces = 2
        Me.NumericTotalDesembolso.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericTotalDesembolso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.NumericTotalDesembolso.Location = New System.Drawing.Point(687, 18)
        Me.NumericTotalDesembolso.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericTotalDesembolso.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.NumericTotalDesembolso.Name = "NumericTotalDesembolso"
        Me.NumericTotalDesembolso.Size = New System.Drawing.Size(120, 22)
        Me.NumericTotalDesembolso.TabIndex = 674
        Me.NumericTotalDesembolso.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        '
        'bunifuFlatButton6
        '
        Me.bunifuFlatButton6.Activecolor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.bunifuFlatButton6.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.bunifuFlatButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bunifuFlatButton6.BorderRadius = 5
        Me.bunifuFlatButton6.ButtonText = "CONSULTAR"
        Me.bunifuFlatButton6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bunifuFlatButton6.DisabledColor = System.Drawing.Color.Gray
        Me.bunifuFlatButton6.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.bunifuFlatButton6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.bunifuFlatButton6.Iconcolor = System.Drawing.Color.Transparent
        Me.bunifuFlatButton6.Iconimage = CType(resources.GetObject("bunifuFlatButton6.Iconimage"), System.Drawing.Image)
        Me.bunifuFlatButton6.Iconimage_right = Nothing
        Me.bunifuFlatButton6.Iconimage_right_Selected = Nothing
        Me.bunifuFlatButton6.Iconimage_Selected = Nothing
        Me.bunifuFlatButton6.IconMarginLeft = 0
        Me.bunifuFlatButton6.IconMarginRight = 0
        Me.bunifuFlatButton6.IconRightVisible = True
        Me.bunifuFlatButton6.IconRightZoom = 0R
        Me.bunifuFlatButton6.IconVisible = True
        Me.bunifuFlatButton6.IconZoom = 40.0R
        Me.bunifuFlatButton6.IsTab = False
        Me.bunifuFlatButton6.Location = New System.Drawing.Point(468, 17)
        Me.bunifuFlatButton6.Margin = New System.Windows.Forms.Padding(2)
        Me.bunifuFlatButton6.Name = "bunifuFlatButton6"
        Me.bunifuFlatButton6.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.bunifuFlatButton6.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.bunifuFlatButton6.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.bunifuFlatButton6.selected = False
        Me.bunifuFlatButton6.Size = New System.Drawing.Size(90, 23)
        Me.bunifuFlatButton6.TabIndex = 667
        Me.bunifuFlatButton6.Text = "CONSULTAR"
        Me.bunifuFlatButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.bunifuFlatButton6.Textcolor = System.Drawing.Color.White
        Me.bunifuFlatButton6.TextFont = New System.Drawing.Font("Quicksand Medium", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(930, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 673
        Me.Label1.Text = "Filtros "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextUsuario
        '
        Me.TextUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextUsuario.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextUsuario.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextUsuario.CornerRadius = 4
        Me.TextUsuario.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextUsuario.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextUsuario.ForeColor = System.Drawing.Color.White
        Me.TextUsuario.Location = New System.Drawing.Point(206, 17)
        Me.TextUsuario.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextUsuario.MinimumSize = New System.Drawing.Size(12, 8)
        Me.TextUsuario.Name = "TextUsuario"
        Me.TextUsuario.ReadOnly = True
        Me.TextUsuario.Size = New System.Drawing.Size(257, 22)
        Me.TextUsuario.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextUsuario.TabIndex = 11
        '
        'TextCodigo
        '
        Me.TextCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextCodigo.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCodigo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigo.CornerRadius = 4
        Me.TextCodigo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigo.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigo.ForeColor = System.Drawing.Color.White
        Me.TextCodigo.Location = New System.Drawing.Point(108, 17)
        Me.TextCodigo.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextCodigo.MinimumSize = New System.Drawing.Size(12, 8)
        Me.TextCodigo.Name = "TextCodigo"
        Me.TextCodigo.Size = New System.Drawing.Size(92, 22)
        Me.TextCodigo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigo.TabIndex = 10
        '
        'BunifuFlatButton4
        '
        Me.BunifuFlatButton4.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.BackgroundImage = CType(resources.GetObject("BunifuFlatButton4.BackgroundImage"), System.Drawing.Image)
        Me.BunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton4.BorderRadius = 5
        Me.BunifuFlatButton4.ButtonText = "CONFIRMAR"
        Me.BunifuFlatButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton4.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton4.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.BunifuFlatButton4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton4.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton4.Iconimage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_docsql
        Me.BunifuFlatButton4.Iconimage_right = Nothing
        Me.BunifuFlatButton4.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton4.Iconimage_Selected = Nothing
        Me.BunifuFlatButton4.IconMarginLeft = 0
        Me.BunifuFlatButton4.IconMarginRight = 0
        Me.BunifuFlatButton4.IconRightVisible = True
        Me.BunifuFlatButton4.IconRightZoom = 0R
        Me.BunifuFlatButton4.IconVisible = True
        Me.BunifuFlatButton4.IconZoom = 40.0R
        Me.BunifuFlatButton4.IsTab = False
        Me.BunifuFlatButton4.Location = New System.Drawing.Point(811, 17)
        Me.BunifuFlatButton4.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton4.Name = "BunifuFlatButton4"
        Me.BunifuFlatButton4.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton4.selected = False
        Me.BunifuFlatButton4.Size = New System.Drawing.Size(114, 23)
        Me.BunifuFlatButton4.TabIndex = 27
        Me.BunifuFlatButton4.Text = "CONFIRMAR"
        Me.BunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton4.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton4.TextFont = New System.Drawing.Font("Quicksand Medium", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'GridProducts
        '
        Me.GridProducts.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.GridProducts.BackColor = System.Drawing.SystemColors.Window
        Me.GridProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridProducts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridProducts.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2016
        Me.GridProducts.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2016Black
        Me.GridProducts.Location = New System.Drawing.Point(0, 50)
        Me.GridProducts.Name = "GridProducts"
        Me.GridProducts.Office2016ScrollBarsColorScheme = Syncfusion.Windows.Forms.ScrollBarOffice2016ColorScheme.Black
        Me.GridProducts.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridProducts.Size = New System.Drawing.Size(1097, 476)
        Me.GridProducts.TabIndex = 310
        Me.GridProducts.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderText = "Usuario"
        GridColumnDescriptor1.MappingName = "usuario"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 90
        GridColumnDescriptor2.HeaderText = "Fecha"
        GridColumnDescriptor2.MappingName = "fechaventa"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor3.HeaderText = "Tipo doc."
        GridColumnDescriptor3.MappingName = "tipodoc"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor4.HeaderText = "Nro.venta"
        GridColumnDescriptor4.MappingName = "nroventa"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor5.HeaderText = "Moneda"
        GridColumnDescriptor5.MappingName = "moneda"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 50
        GridColumnDescriptor6.HeaderText = "Producto"
        GridColumnDescriptor6.MappingName = "producto"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.Width = 190
        GridColumnDescriptor7.HeaderText = "Unidad comercial"
        GridColumnDescriptor7.MappingName = "unidadcomercial"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.Width = 80
        GridColumnDescriptor8.HeaderText = "Catalogo"
        GridColumnDescriptor8.MappingName = "catalogo"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor9.HeaderText = "Total"
        GridColumnDescriptor9.MappingName = "importeventa"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.Width = 70
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.Error = "Object reference not set to an instance of an object."
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        GridColumnDescriptor10.HeaderText = "Comisión"
        GridColumnDescriptor10.MappingName = "importecomision"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.Width = 70
        GridColumnDescriptor11.HeaderText = "Estado venta"
        GridColumnDescriptor11.MappingName = "estadoventa"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.Width = 60
        GridColumnDescriptor12.HeaderText = "Estado comisión"
        GridColumnDescriptor12.MappingName = "estadocomision"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.Width = 60
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.Color.Yellow
        GridColumnDescriptor13.MappingName = "desembolso"
        GridColumnDescriptor13.Width = 75
        GridColumnDescriptor14.MappingName = "comision"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.Width = 20
        Me.GridProducts.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("usuariocode"), GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14})
        Me.GridProducts.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 28
        Me.GridProducts.TableDescriptor.TableOptions.RecordRowHeight = 28
        Me.GridProducts.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaventa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nroventa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("moneda"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidadcomercial"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeventa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importecomision"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estadocomision"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("desembolso")})
        Me.GridProducts.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One
        Me.GridProducts.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.GridProducts.TableOptions.SelectionTextColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridProducts.Text = "GridGroupingControl1"
        Me.GridProducts.UseRightToLeftCompatibleTextBox = True
        Me.GridProducts.VersionInfo = "16.4460.0.42"
        '
        'UCComisionDesembolso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.GridProducts)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UCComisionDesembolso"
        Me.Size = New System.Drawing.Size(1097, 526)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ComboTipoComision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericTotalComisionesAfavor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericTotalDesembolso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Private WithEvents bunifuFlatButton6 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label1 As Label
    Friend WithEvents TextUsuario As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextCodigo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents BunifuFlatButton4 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents NumericTotalDesembolso As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents GridProducts As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents NumericTotalComisionesAfavor As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents ComboTipoComision As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
End Class

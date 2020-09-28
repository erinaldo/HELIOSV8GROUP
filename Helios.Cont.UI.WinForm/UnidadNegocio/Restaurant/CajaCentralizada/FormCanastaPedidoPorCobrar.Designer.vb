Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCanastaPedidoPorCobrar
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCanastaPedidoPorCobrar))
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
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.GradientPanel15 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton10 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton17 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton5 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton4 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboMonedaCobro = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.DateTimePickerAdv1 = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.popupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtInfraestructura = New System.Windows.Forms.Label()
        CType(Me.GradientPanel15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel15.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.cboMonedaCobro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimePickerAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupControlContainer1.SuspendLayout()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel15
        '
        Me.GradientPanel15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel15.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GradientPanel15.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel15.Controls.Add(Me.GradientPanel1)
        Me.GradientPanel15.Controls.Add(Me.Label17)
        Me.GradientPanel15.Controls.Add(Me.cboMonedaCobro)
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
        Me.GradientPanel15.Size = New System.Drawing.Size(1135, 43)
        Me.GradientPanel15.TabIndex = 252
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BackgroundImage = CType(resources.GetObject("GradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton10)
        Me.GradientPanel1.Controls.Add(Me.ProgressBar1)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton2)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton17)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton5)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton4)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1133, 41)
        Me.GradientPanel1.TabIndex = 695
        '
        'BunifuFlatButton10
        '
        Me.BunifuFlatButton10.Activecolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton10.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton10.BorderRadius = 5
        Me.BunifuFlatButton10.ButtonText = "RETORNAR AL MENU"
        Me.BunifuFlatButton10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton10.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton10.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton10.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton10.Iconimage = Nothing
        Me.BunifuFlatButton10.Iconimage_right = Nothing
        Me.BunifuFlatButton10.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton10.Iconimage_Selected = Nothing
        Me.BunifuFlatButton10.IconMarginLeft = 0
        Me.BunifuFlatButton10.IconMarginRight = 0
        Me.BunifuFlatButton10.IconRightVisible = True
        Me.BunifuFlatButton10.IconRightZoom = 0R
        Me.BunifuFlatButton10.IconVisible = True
        Me.BunifuFlatButton10.IconZoom = 90.0R
        Me.BunifuFlatButton10.IsTab = False
        Me.BunifuFlatButton10.Location = New System.Drawing.Point(991, 8)
        Me.BunifuFlatButton10.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton10.Name = "BunifuFlatButton10"
        Me.BunifuFlatButton10.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton10.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton10.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton10.selected = False
        Me.BunifuFlatButton10.Size = New System.Drawing.Size(133, 23)
        Me.BunifuFlatButton10.TabIndex = 692
        Me.BunifuFlatButton10.Text = "RETORNAR AL MENU"
        Me.BunifuFlatButton10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton10.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton10.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(117, 23)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(40, 8)
        Me.ProgressBar1.TabIndex = 507
        Me.ProgressBar1.Visible = False
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.Peru
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 5
        Me.BunifuFlatButton2.ButtonText = "VER DETALLE"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BunifuFlatButton2.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
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
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(873, 8)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.Peru
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Peru
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton2.TabIndex = 694
        Me.BunifuFlatButton2.Text = "VER DETALLE"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton17
        '
        Me.BunifuFlatButton17.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton17.BorderRadius = 5
        Me.BunifuFlatButton17.ButtonText = "ACTUALIZAR"
        Me.BunifuFlatButton17.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton17.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton17.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton17.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton17.Iconimage = Nothing
        Me.BunifuFlatButton17.Iconimage_right = Nothing
        Me.BunifuFlatButton17.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton17.Iconimage_Selected = Nothing
        Me.BunifuFlatButton17.IconMarginLeft = 0
        Me.BunifuFlatButton17.IconMarginRight = 0
        Me.BunifuFlatButton17.IconRightVisible = True
        Me.BunifuFlatButton17.IconRightZoom = 0R
        Me.BunifuFlatButton17.IconVisible = True
        Me.BunifuFlatButton17.IconZoom = 90.0R
        Me.BunifuFlatButton17.IsTab = False
        Me.BunifuFlatButton17.Location = New System.Drawing.Point(649, 8)
        Me.BunifuFlatButton17.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton17.Name = "BunifuFlatButton17"
        Me.BunifuFlatButton17.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton17.selected = False
        Me.BunifuFlatButton17.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton17.TabIndex = 692
        Me.BunifuFlatButton17.Text = "ACTUALIZAR"
        Me.BunifuFlatButton17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton17.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton17.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton5
        '
        Me.BunifuFlatButton5.Activecolor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.BunifuFlatButton5.BackColor = System.Drawing.Color.Green
        Me.BunifuFlatButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton5.BorderRadius = 5
        Me.BunifuFlatButton5.ButtonText = "ELIMINAR"
        Me.BunifuFlatButton5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton5.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton5.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton5.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton5.Iconimage = Nothing
        Me.BunifuFlatButton5.Iconimage_right = Nothing
        Me.BunifuFlatButton5.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton5.Iconimage_Selected = Nothing
        Me.BunifuFlatButton5.IconMarginLeft = 0
        Me.BunifuFlatButton5.IconMarginRight = 0
        Me.BunifuFlatButton5.IconRightVisible = True
        Me.BunifuFlatButton5.IconRightZoom = 0R
        Me.BunifuFlatButton5.IconVisible = True
        Me.BunifuFlatButton5.IconZoom = 90.0R
        Me.BunifuFlatButton5.IsTab = False
        Me.BunifuFlatButton5.Location = New System.Drawing.Point(761, 8)
        Me.BunifuFlatButton5.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton5.Name = "BunifuFlatButton5"
        Me.BunifuFlatButton5.Normalcolor = System.Drawing.Color.Green
        Me.BunifuFlatButton5.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.BunifuFlatButton5.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton5.selected = False
        Me.BunifuFlatButton5.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton5.TabIndex = 693
        Me.BunifuFlatButton5.Text = "ELIMINAR"
        Me.BunifuFlatButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton5.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton5.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton4
        '
        Me.BunifuFlatButton4.Activecolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.BunifuFlatButton4.BackColor = System.Drawing.Color.DarkRed
        Me.BunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton4.BorderRadius = 5
        Me.BunifuFlatButton4.ButtonText = "COBRAR"
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
        Me.BunifuFlatButton4.Location = New System.Drawing.Point(4, 9)
        Me.BunifuFlatButton4.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton4.Name = "BunifuFlatButton4"
        Me.BunifuFlatButton4.Normalcolor = System.Drawing.Color.DarkRed
        Me.BunifuFlatButton4.OnHovercolor = System.Drawing.Color.DarkRed
        Me.BunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton4.selected = False
        Me.BunifuFlatButton4.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton4.TabIndex = 672
        Me.BunifuFlatButton4.Text = "COBRAR"
        Me.BunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton4.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton4.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.txtRuc.BeforeTouchSize = New System.Drawing.Size(100, 20)
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
        Me.txtCliente.BeforeTouchSize = New System.Drawing.Size(100, 20)
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
        Me.GridPedidos.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.GridPedidos.BackColor = System.Drawing.Color.White
        Me.GridPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridPedidos.Enabled = False
        Me.GridPedidos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridPedidos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridPedidos.Location = New System.Drawing.Point(0, 82)
        Me.GridPedidos.Name = "GridPedidos"
        Me.GridPedidos.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridPedidos.Size = New System.Drawing.Size(1135, 508)
        Me.GridPedidos.TabIndex = 254
        Me.GridPedidos.TableDescriptor.AllowNew = False
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
        GridColumnDescriptor3.Width = 300
        GridColumnDescriptor4.AllowSort = False
        GridColumnDescriptor4.HeaderText = "Tipo Doc."
        GridColumnDescriptor4.MappingName = "tipoDoc"
        GridColumnDescriptor4.Name = "tipoDoc"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.Width = 90
        GridColumnDescriptor5.AllowSort = False
        GridColumnDescriptor5.MappingName = "serie"
        GridColumnDescriptor5.Name = "serie"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 40
        GridColumnDescriptor6.AllowSort = False
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor6.HeaderText = "Nro. Pre Cuenta"
        GridColumnDescriptor6.MappingName = "numeroDoc"
        GridColumnDescriptor6.Name = "numeroDoc"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.Width = 100
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
        GridColumnDescriptor9.HeaderText = "Importe Venta"
        GridColumnDescriptor9.MappingName = "importeTotal"
        GridColumnDescriptor9.Name = "importeTotal"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.Width = 120
        GridColumnDescriptor10.AllowSort = False
        GridColumnDescriptor10.MappingName = "tcDolLoc"
        GridColumnDescriptor10.Name = "tcDolLoc"
        GridColumnDescriptor11.HeaderText = "Moneda"
        GridColumnDescriptor11.MappingName = "monedaDoc"
        GridColumnDescriptor11.Name = "monedaDoc"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.Width = 55
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor12.MappingName = "estado"
        GridColumnDescriptor12.Name = "estado"
        GridColumnDescriptor12.Width = 50
        GridColumnDescriptor13.MappingName = "idcliente"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.Width = 0
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridColumnDescriptor14.HeaderText = "Cobrar"
        GridColumnDescriptor14.MappingName = "validar"
        GridColumnDescriptor14.Name = "validar"
        Me.GridPedidos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("idDocumento", "idDocumento"), GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("importeUS", "importeUS"), GridColumnDescriptor11, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("usuarioActualizacion", "usuarioActualizacion"), GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14})
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.PositiveColor = System.Drawing.Color.White
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.DeepSkyBlue)
        GridSummaryColumnDescriptor1.DataMember = "importeTotal"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "Summary 1"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1})
        Me.GridPedidos.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.GridPedidos.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridPedidos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridPedidos.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridPedidos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("pedido"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numeroDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeTotal"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("validar")})
        Me.GridPedidos.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.GridPedidos.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.GridPedidos.Text = "GridGroupingControl1"
        Me.GridPedidos.TopLevelGroupOptions.ShowCaption = True
        Me.GridPedidos.UseRightToLeftCompatibleTextBox = True
        Me.GridPedidos.VersionInfo = "12.4400.0.24"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtInfraestructura)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1135, 39)
        Me.Panel1.TabIndex = 255
        '
        'txtInfraestructura
        '
        Me.txtInfraestructura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInfraestructura.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfraestructura.Location = New System.Drawing.Point(0, 0)
        Me.txtInfraestructura.Name = "txtInfraestructura"
        Me.txtInfraestructura.Size = New System.Drawing.Size(1135, 39)
        Me.txtInfraestructura.TabIndex = 0
        Me.txtInfraestructura.Text = "MESA"
        Me.txtInfraestructura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormCanastaPedidoPorCobrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridPedidos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GradientPanel15)
        Me.Name = "FormCanastaPedidoPorCobrar"
        Me.Size = New System.Drawing.Size(1135, 590)
        CType(Me.GradientPanel15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel15.ResumeLayout(False)
        Me.GradientPanel15.PerformLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.cboMonedaCobro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimePickerAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupControlContainer1.ResumeLayout(False)
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel15 As Tools.GradientPanel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label17 As Label
    Friend WithEvents cboMonedaCobro As Tools.ComboBoxAdv
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
    Friend WithEvents Panel1 As Panel
    Private WithEvents BunifuFlatButton4 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton5 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton17 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents txtInfraestructura As Label
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Private WithEvents BunifuFlatButton10 As Bunifu.Framework.UI.BunifuFlatButton
End Class

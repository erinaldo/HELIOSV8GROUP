<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControlCanastaTouchRestaurant
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim GridColumnDescriptor51 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor52 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor53 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor54 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor55 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor56 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor57 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor58 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor59 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor60 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GridTotales = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.PanelBody3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.PanellOTES = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ListInventario = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton15 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        CType(Me.GridTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.PanelBody3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBody3.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        CType(Me.PanellOTES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanellOTES.SuspendLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridTotales
        '
        Me.GridTotales.BackColor = System.Drawing.Color.White
        Me.GridTotales.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridTotales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTotales.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridTotales.FreezeCaption = False
        Me.GridTotales.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridTotales.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridTotales.Location = New System.Drawing.Point(0, 0)
        Me.GridTotales.Name = "GridTotales"
        Me.GridTotales.Size = New System.Drawing.Size(810, 165)
        Me.GridTotales.TabIndex = 411
        Me.GridTotales.TableDescriptor.AllowNew = False
        GridColumnDescriptor51.HeaderImage = Nothing
        GridColumnDescriptor51.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor51.HeaderText = "Gr."
        GridColumnDescriptor51.MappingName = "destino"
        GridColumnDescriptor51.ReadOnly = True
        GridColumnDescriptor51.SerializedImageArray = ""
        GridColumnDescriptor51.Width = 40
        GridColumnDescriptor52.HeaderImage = Nothing
        GridColumnDescriptor52.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor52.HeaderText = "id"
        GridColumnDescriptor52.MappingName = "idItem"
        GridColumnDescriptor52.ReadOnly = True
        GridColumnDescriptor52.SerializedImageArray = ""
        GridColumnDescriptor52.Width = 0
        GridColumnDescriptor53.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor53.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor53.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor53.HeaderImage = Nothing
        GridColumnDescriptor53.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor53.HeaderText = "PRODUCTO"
        GridColumnDescriptor53.MappingName = "descripcion"
        GridColumnDescriptor53.ReadOnly = True
        GridColumnDescriptor53.SerializedImageArray = ""
        GridColumnDescriptor53.Width = 313
        GridColumnDescriptor54.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor54.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 3
        GridColumnDescriptor54.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor54.Appearance.AnyRecordFieldCell.Text = ".000"
        GridColumnDescriptor54.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor54.HeaderImage = Nothing
        GridColumnDescriptor54.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor54.HeaderText = "STOCK"
        GridColumnDescriptor54.MappingName = "cantidad"
        GridColumnDescriptor54.ReadOnly = True
        GridColumnDescriptor54.SerializedImageArray = ""
        GridColumnDescriptor54.Width = 70
        GridColumnDescriptor55.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor55.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor55.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(18, Byte), Integer))
        GridColumnDescriptor55.HeaderImage = Nothing
        GridColumnDescriptor55.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor55.HeaderText = "U.M."
        GridColumnDescriptor55.MappingName = "unidad"
        GridColumnDescriptor55.ReadOnly = True
        GridColumnDescriptor55.SerializedImageArray = ""
        GridColumnDescriptor55.Width = 55
        GridColumnDescriptor56.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MistyRose)
        GridColumnDescriptor56.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor56.HeaderImage = Nothing
        GridColumnDescriptor56.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor56.HeaderText = "UNIDAD COMERCIAL"
        GridColumnDescriptor56.MappingName = "cboEquivalencias"
        GridColumnDescriptor56.SerializedImageArray = ""
        GridColumnDescriptor56.Width = 163
        GridColumnDescriptor57.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MistyRose)
        GridColumnDescriptor57.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor57.HeaderImage = Nothing
        GridColumnDescriptor57.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor57.HeaderText = "CATALOGO DE PRECIOS"
        GridColumnDescriptor57.MappingName = "cboPrecios"
        GridColumnDescriptor57.SerializedImageArray = ""
        GridColumnDescriptor57.Width = 150
        GridColumnDescriptor58.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor58.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor58.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.SystemColors.HotTrack
        GridColumnDescriptor58.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.GradientInactiveCaption)
        GridColumnDescriptor58.HeaderImage = Nothing
        GridColumnDescriptor58.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor58.HeaderText = "PREC. VENTA"
        GridColumnDescriptor58.MappingName = "importeMn"
        GridColumnDescriptor58.ReadOnly = True
        GridColumnDescriptor58.SerializedImageArray = ""
        GridColumnDescriptor58.Width = 0
        GridColumnDescriptor59.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor59.HeaderImage = Nothing
        GridColumnDescriptor59.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor59.HeaderText = "Venta"
        GridColumnDescriptor59.MappingName = "btnVender"
        GridColumnDescriptor59.ReadOnly = True
        GridColumnDescriptor59.SerializedImageArray = ""
        GridColumnDescriptor59.Width = 0
        GridColumnDescriptor60.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor60.HeaderImage = Nothing
        GridColumnDescriptor60.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor60.HeaderText = "Consultar"
        GridColumnDescriptor60.MappingName = "btConsultarstock"
        GridColumnDescriptor60.SerializedImageArray = ""
        GridColumnDescriptor60.Width = 0
        Me.GridTotales.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor51, GridColumnDescriptor52, GridColumnDescriptor53, GridColumnDescriptor54, GridColumnDescriptor55, GridColumnDescriptor56, GridColumnDescriptor57, GridColumnDescriptor58, GridColumnDescriptor59, GridColumnDescriptor60})
        Me.GridTotales.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridTotales.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridTotales.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("destino"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cboEquivalencias"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cboPrecios"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeMn"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("btnVender"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("btConsultarstock")})
        Me.GridTotales.Text = "gridGroupingControl1"
        Me.GridTotales.TopLevelGroupOptions.ShowCaption = False
        Me.GridTotales.VersionInfo = "12.2400.0.20"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.GridTotales)
        Me.GradientPanel1.Controls.Add(Me.PanelBody3)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(812, 329)
        Me.GradientPanel1.TabIndex = 412
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(92, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 413
        Me.btnOK.Text = "Ocultar"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'PanelBody3
        '
        Me.PanelBody3.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelBody3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBody3.Controls.Add(Me.PanelBody)
        Me.PanelBody3.Controls.Add(Me.GradientPanel4)
        Me.PanelBody3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBody3.Location = New System.Drawing.Point(0, 165)
        Me.PanelBody3.Name = "PanelBody3"
        Me.PanelBody3.Size = New System.Drawing.Size(810, 162)
        Me.PanelBody3.TabIndex = 412
        '
        'PanelBody
        '
        Me.PanelBody.Controls.Add(Me.PanellOTES)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 29)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(808, 131)
        Me.PanelBody.TabIndex = 411
        '
        'PanellOTES
        '
        Me.PanellOTES.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PanellOTES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanellOTES.Controls.Add(Me.ListInventario)
        Me.PanellOTES.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanellOTES.Location = New System.Drawing.Point(0, 0)
        Me.PanellOTES.Name = "PanellOTES"
        Me.PanellOTES.Size = New System.Drawing.Size(808, 131)
        Me.PanellOTES.TabIndex = 410
        Me.PanellOTES.Visible = False
        '
        'ListInventario
        '
        Me.ListInventario.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ListInventario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListInventario.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListInventario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListInventario.FullRowSelect = True
        Me.ListInventario.GridLines = True
        Me.ListInventario.Location = New System.Drawing.Point(0, 0)
        Me.ListInventario.Name = "ListInventario"
        Me.ListInventario.Size = New System.Drawing.Size(806, 129)
        Me.ListInventario.TabIndex = 0
        Me.ListInventario.UseCompatibleStateImageBehavior = False
        Me.ListInventario.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Almacen"
        Me.ColumnHeader2.Width = 157
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Lote"
        Me.ColumnHeader3.Width = 110
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "LoteCode"
        Me.ColumnHeader4.Width = 70
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cantidad"
        Me.ColumnHeader5.Width = 75
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Fecha Compra"
        Me.ColumnHeader6.Width = 109
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Fec. Vcto."
        Me.ColumnHeader7.Width = 114
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Sustentado"
        Me.ColumnHeader8.Width = 106
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BackColor = System.Drawing.Color.White
        Me.GradientPanel4.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel4.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.btnOK)
        Me.GradientPanel4.Controls.Add(Me.BunifuFlatButton15)
        Me.GradientPanel4.Controls.Add(Me.sliderTop)
        Me.GradientPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel4.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(808, 29)
        Me.GradientPanel4.TabIndex = 0
        '
        'BunifuFlatButton15
        '
        Me.BunifuFlatButton15.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton15.BorderRadius = 0
        Me.BunifuFlatButton15.ButtonText = "PRECIOS"
        Me.BunifuFlatButton15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton15.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton15.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton15.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton15.Iconimage = Nothing
        Me.BunifuFlatButton15.Iconimage_right = Nothing
        Me.BunifuFlatButton15.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton15.Iconimage_Selected = Nothing
        Me.BunifuFlatButton15.IconMarginLeft = 0
        Me.BunifuFlatButton15.IconMarginRight = 0
        Me.BunifuFlatButton15.IconRightVisible = True
        Me.BunifuFlatButton15.IconRightZoom = 0R
        Me.BunifuFlatButton15.IconVisible = True
        Me.BunifuFlatButton15.IconZoom = 90.0R
        Me.BunifuFlatButton15.IsTab = False
        Me.BunifuFlatButton15.Location = New System.Drawing.Point(3, 2)
        Me.BunifuFlatButton15.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton15.Name = "BunifuFlatButton15"
        Me.BunifuFlatButton15.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton15.selected = False
        Me.BunifuFlatButton15.Size = New System.Drawing.Size(83, 18)
        Me.BunifuFlatButton15.TabIndex = 23
        Me.BunifuFlatButton15.Text = "PRECIOS"
        Me.BunifuFlatButton15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton15.Textcolor = System.Drawing.SystemColors.HotTrack
        Me.BunifuFlatButton15.TextFont = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.SystemColors.Highlight
        Me.sliderTop.Location = New System.Drawing.Point(2, 23)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(84, 6)
        Me.sliderTop.TabIndex = 22
        Me.sliderTop.TabStop = False
        '
        'UserControlCanasta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "UserControlCanasta"
        Me.Size = New System.Drawing.Size(812, 329)
        CType(Me.GridTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.PanelBody3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBody3.ResumeLayout(False)
        Me.PanelBody.ResumeLayout(False)
        CType(Me.PanellOTES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanellOTES.ResumeLayout(False)
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents GridTotales As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents PanelBody3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents PanelBody As Panel
    Friend WithEvents PanellOTES As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ListInventario As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents GradientPanel4 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents BunifuFlatButton15 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Friend WithEvents btnOK As Button
End Class

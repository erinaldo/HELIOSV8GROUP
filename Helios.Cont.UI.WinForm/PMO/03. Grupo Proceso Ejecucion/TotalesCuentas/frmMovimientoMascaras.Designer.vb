<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientoMascaras
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.gridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ButtonAdv2)
        Me.Panel2.Controls.Add(Me.ButtonAdv1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(864, 36)
        Me.Panel2.TabIndex = 210
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(142, 23)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(12, 5)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(142, 23)
        Me.ButtonAdv1.TabIndex = 0
        Me.ButtonAdv1.Text = "ButtonAdv1"
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado, Me.ToolStripSeparator1, Me.ToolStripLabel1})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(864, 25)
        Me.ToolStrip4.TabIndex = 208
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(117, 22)
        Me.lblEstado.Text = "Estado: nueva venta."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripLabel1.Text = "&Atras"
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.BackgroundImageAlign = Qios.DevSuite.Components.QImageAlign.RepeatedVertical
        Me.QRibbonCaption1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(864, 28)
        Me.QRibbonCaption1.TabIndex = 207
        Me.QRibbonCaption1.Text = "Máscaras por Tipo Existencias"
        '
        'gridGroupingControl1
        '
        Me.gridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
        Me.gridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridGroupingControl1.FreezeCaption = False
        Me.gridGroupingControl1.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.gridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.gridGroupingControl1.Location = New System.Drawing.Point(0, 89)
        Me.gridGroupingControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.gridGroupingControl1.Name = "gridGroupingControl1"
        Me.gridGroupingControl1.Size = New System.Drawing.Size(864, 433)
        Me.gridGroupingControl1.TabIndex = 211
        Me.gridGroupingControl1.TableDescriptor.AllowNew = False
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyGroupCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        Me.gridGroupingControl1.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.gridGroupingControl1.TableDescriptor.Appearance.ColumnHeaderCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        Me.gridGroupingControl1.TableDescriptor.Appearance.GroupCaptionCell.CellType = "ColumnHeader"
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor1.Appearance.RecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idEmpresa"
        GridColumnDescriptor1.Name = "idEmpresa"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor2.Appearance.RecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Tipo Existencia"
        GridColumnDescriptor2.MappingName = "tipoExistencia"
        GridColumnDescriptor2.Name = "tipoExistencia"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 150
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "cuentraCompraFil"
        GridColumnDescriptor3.Name = "cuentraCompraFil"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor4.Appearance.RecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Cuenta"
        GridColumnDescriptor4.MappingName = "cuentaCompra"
        GridColumnDescriptor4.Name = "cuentaCompra"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 90
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor5.Appearance.ColumnHeaderCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
        GridColumnDescriptor5.Appearance.ColumnHeaderWithFilterCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
        GridColumnDescriptor5.Appearance.FilterBarCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor5.Appearance.GroupCaptionSummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor5.Appearance.RecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor5.Appearance.RecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Cuenta Almacén"
        GridColumnDescriptor5.MappingName = "CuentaAlmacenContado"
        GridColumnDescriptor5.Name = "CuentaAlmacenContado"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 100
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor6.Appearance.RecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor6.Appearance.RecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Descripción "
        GridColumnDescriptor6.MappingName = "DescripciónAlmacenContado"
        GridColumnDescriptor6.Name = "DescripciónAlmacenContado"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 170
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor7.Appearance.RecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Cuenta Tránsito"
        GridColumnDescriptor7.MappingName = "CuentaAlmacen"
        GridColumnDescriptor7.Name = "CuentaAlmacen"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 100
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor8.Appearance.RecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Descripción Tránsito"
        GridColumnDescriptor8.MappingName = "DescripciónAlmacen"
        GridColumnDescriptor8.Name = "DescripciónAlmacen"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 170
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor9.Appearance.RecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Cuenta Almacén "
        GridColumnDescriptor9.MappingName = "CuentaAlmacenFisico"
        GridColumnDescriptor9.Name = "CuentaAlmacenFisico"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 100
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor10.Appearance.RecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Descripcion Almacén "
        GridColumnDescriptor10.MappingName = "descripcionAlmacenFisico"
        GridColumnDescriptor10.Name = "descripcionAlmacenFisico"
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 170
        Me.gridGroupingControl1.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10})
        Me.gridGroupingControl1.TableDescriptor.StackedHeaderRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 1", "-", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idEmpresa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("tipoExistencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("cuentaCompra")}), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 2", "Mascaras de Compras al Contado", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("CuentaAlmacenContado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("DescripciónAlmacenContado")}), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 3", "Máscaras de Compras al Crédito", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("DescripciónAlmacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("CuentaAlmacenFisico"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("descripcionAlmacenFisico"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idEmpresa")})}))
        Me.gridGroupingControl1.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 24
        Me.gridGroupingControl1.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.gridGroupingControl1.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cuentaCompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("CuentaAlmacenContado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DescripciónAlmacenContado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("CuentaAlmacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DescripciónAlmacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("CuentaAlmacenFisico"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionAlmacenFisico")})
        Me.gridGroupingControl1.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Standard, System.Drawing.Color.DeepSkyBlue, Syncfusion.Windows.Forms.Grid.GridBorderWeight.Medium)
        Me.gridGroupingControl1.TableOptions.ShowRecordPlusMinus = False
        Me.gridGroupingControl1.TableOptions.ShowTableIndent = False
        Me.gridGroupingControl1.Text = "gridGroupingControl1"
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordAfterDetails = False
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowStackedHeaders = True
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowSummaries = False
        Me.gridGroupingControl1.VersionInfo = "4.200.0.60"
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(142, 23)
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(160, 5)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(142, 23)
        Me.ButtonAdv2.TabIndex = 1
        Me.ButtonAdv2.Text = "Editar"
        '
        'frmMovimientoMascaras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 522)
        Me.Controls.Add(Me.gridGroupingControl1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "frmMovimientoMascaras"
        Me.Text = "Máscaras por Tipo Existencias"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Private WithEvents gridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
End Class

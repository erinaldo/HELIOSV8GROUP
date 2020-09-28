<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientoMascarasItems
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
        Dim GridStackedHeaderDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.GridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ToolStrip4.SuspendLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(864, 10)
        Me.Panel2.TabIndex = 210
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
        Me.QRibbonCaption1.Text = "Máscaras por Items"
        '
        'GridGroupingControl1
        '
        Me.GridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
        Me.GridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridGroupingControl1.FreezeCaption = False
        Me.GridGroupingControl1.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridGroupingControl1.Location = New System.Drawing.Point(0, 63)
        Me.GridGroupingControl1.Name = "GridGroupingControl1"
        Me.GridGroupingControl1.Size = New System.Drawing.Size(864, 459)
        Me.GridGroupingControl1.TabIndex = 211
        Me.GridGroupingControl1.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idEmpresa"
        GridColumnDescriptor1.Name = "idEmpresa"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "tipoExistencia"
        GridColumnDescriptor2.MappingName = "tipoExistencia"
        GridColumnDescriptor2.Name = "tipoExistencia"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor3.Appearance.RecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Cuenta"
        GridColumnDescriptor3.MappingName = "cuentaCompra"
        GridColumnDescriptor3.Name = "cuentaCompra"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 100
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor4.Appearance.ColumnHeaderCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
        GridColumnDescriptor4.Appearance.FilterBarCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor4.Appearance.GroupCaptionSummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.MenuHighlight)
        GridColumnDescriptor4.Appearance.RecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Descripcion"
        GridColumnDescriptor4.MappingName = "descripcionItem"
        GridColumnDescriptor4.Name = "descripcionItem"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 200
        GridColumnDescriptor5.Appearance.AddNewRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor5.Appearance.AddNewRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor5.Appearance.FilterBarCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info)
        GridColumnDescriptor5.Appearance.RecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Cuenta"
        GridColumnDescriptor5.MappingName = "CuentaAlmacenContado"
        GridColumnDescriptor5.Name = "CuentaAlmacenContado"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 100
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor6.Appearance.RecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Descripción"
        GridColumnDescriptor6.MappingName = "DescripciónAlmacenContado"
        GridColumnDescriptor6.Name = "DescripciónAlmacenContado"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 170
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor7.Appearance.RecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Cuenta Tránsito"
        GridColumnDescriptor7.MappingName = "CuentaAlmacen"
        GridColumnDescriptor7.Name = "CuentaAlmacen"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 100
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor8.Appearance.RecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Descripción Tránsito"
        GridColumnDescriptor8.MappingName = "DescripciónAlmacen"
        GridColumnDescriptor8.Name = "DescripciónAlmacen"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 170
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor9.Appearance.RecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Cuenta Almacén "
        GridColumnDescriptor9.MappingName = "CuentaAlmacenFisico"
        GridColumnDescriptor9.Name = "CuentaAlmacenFisico"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 100
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor10.Appearance.RecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Descripción Almacén "
        GridColumnDescriptor10.MappingName = "descripcionAlmacenFisico"
        GridColumnDescriptor10.Name = "descripcionAlmacenFisico"
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 170
        Me.GridGroupingControl1.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10})
        GridStackedHeaderDescriptor1.HeaderText = "Máscaras de Compras al Contado"
        GridStackedHeaderDescriptor1.Name = "StackedHeader 2"
        GridStackedHeaderDescriptor1.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("CuentaAlmacenContado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("DescripciónAlmacenContado")})
        Me.GridGroupingControl1.TableDescriptor.StackedHeaderRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 1", "-", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idEmpresa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("tipoExistencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("cuentaCompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("descripcionItem")}), GridStackedHeaderDescriptor1, New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 3", "Máscaras de Compras al Crédito", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("CuentaAlmacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("DescripciónAlmacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("CuentaAlmacenFisico"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("descripcionAlmacenFisico")})}))
        Me.GridGroupingControl1.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridGroupingControl1.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridGroupingControl1.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridGroupingControl1.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cuentaCompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("CuentaAlmacenContado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DescripciónAlmacenContado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("CuentaAlmacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DescripciónAlmacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("CuentaAlmacenFisico"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionAlmacenFisico")})
        Me.GridGroupingControl1.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Standard, System.Drawing.Color.DeepSkyBlue, Syncfusion.Windows.Forms.Grid.GridBorderWeight.Medium)
        Me.GridGroupingControl1.TableOptions.ShowRecordPlusMinus = False
        Me.GridGroupingControl1.TableOptions.ShowTableIndent = False
        Me.GridGroupingControl1.Text = "GridGroupingControl1"
        Me.GridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = True
        Me.GridGroupingControl1.TopLevelGroupOptions.ShowCaptionPlusMinus = True
        Me.GridGroupingControl1.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.GridGroupingControl1.TopLevelGroupOptions.ShowStackedHeaders = True
        Me.GridGroupingControl1.TopLevelGroupOptions.ShowSummaries = False
        Me.GridGroupingControl1.VersionInfo = "13.1400.0.21"
        '
        'frmMovimientoMascarasItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 522)
        Me.Controls.Add(Me.GridGroupingControl1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "frmMovimientoMascarasItems"
        Me.Text = "Máscaras por Items"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents GridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

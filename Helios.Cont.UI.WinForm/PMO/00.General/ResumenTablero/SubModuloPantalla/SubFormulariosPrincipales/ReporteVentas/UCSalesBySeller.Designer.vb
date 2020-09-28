<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCSalesBySeller
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
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.DgvComprobantes = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.DgvComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvComprobantes
        '
        Me.DgvComprobantes.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DgvComprobantes.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.DgvComprobantes.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.DgvComprobantes.BackColor = System.Drawing.SystemColors.Window
        Me.DgvComprobantes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvComprobantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvComprobantes.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.DgvComprobantes.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.DgvComprobantes.InvalidateAllWhenListChanged = True
        Me.DgvComprobantes.Location = New System.Drawing.Point(0, 0)
        Me.DgvComprobantes.Name = "DgvComprobantes"
        Me.DgvComprobantes.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.DgvComprobantes.Size = New System.Drawing.Size(994, 492)
        Me.DgvComprobantes.TabIndex = 419
        Me.DgvComprobantes.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderText = "Tipo"
        GridColumnDescriptor2.MappingName = "tipoCompra"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 80
        GridColumnDescriptor3.HeaderText = "Fecha"
        GridColumnDescriptor3.MappingName = "fechaDoc"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 80
        GridColumnDescriptor4.HeaderText = "TipoDoc."
        GridColumnDescriptor4.MappingName = "tipoDoc"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.Width = 70
        GridColumnDescriptor5.HeaderText = "Serie"
        GridColumnDescriptor5.MappingName = "serie"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 70
        GridColumnDescriptor6.HeaderText = "Número"
        GridColumnDescriptor6.MappingName = "numeroDoc"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.Width = 80
        GridColumnDescriptor7.HeaderText = "Razon Social"
        GridColumnDescriptor7.MappingName = "NombreEntidad"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.Width = 220
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor8.HeaderText = "Importe"
        GridColumnDescriptor8.MappingName = "importeTotal"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.Width = 70
        GridColumnDescriptor9.HeaderText = "Moneda"
        GridColumnDescriptor9.MappingName = "monedaDoc"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.Width = 70
        GridColumnDescriptor10.HeaderText = "Vendedor"
        GridColumnDescriptor10.MappingName = "usuarioActualizacion"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.Width = 150
        GridColumnDescriptor11.MappingName = "enviosunat"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.Width = 0
        Me.DgvComprobantes.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11})
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor1.DataMember = "importeTotal"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "bi"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1})
        GridSummaryRowDescriptor1.Title = "Total ventas"
        Me.DgvComprobantes.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.DgvComprobantes.TableDescriptor.TableOptions.AllowSortColumns = True
        Me.DgvComprobantes.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.DgvComprobantes.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.DgvComprobantes.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.DgvComprobantes.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoCompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("serie"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numeroDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NombreEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeTotal"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monedaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("usuarioActualizacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("enviosunat")})
        Me.DgvComprobantes.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DgvComprobantes.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.DgvComprobantes.TableOptions.ShowRecordPlusMinus = True
        Me.DgvComprobantes.TableOptions.ShowRowHeader = True
        Me.DgvComprobantes.TableOptions.ShowTableIndent = True
        Me.DgvComprobantes.Text = "GridGroupingControl2"
        Me.DgvComprobantes.TopLevelGroupOptions.ShowCaption = False
        Me.DgvComprobantes.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.DgvComprobantes.UseRightToLeftCompatibleTextBox = True
        Me.DgvComprobantes.VersionInfo = "12.4400.0.24"
        '
        'UCSalesBySeller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DgvComprobantes)
        Me.Name = "UCSalesBySeller"
        Me.Size = New System.Drawing.Size(994, 492)
        CType(Me.DgvComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvComprobantes As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

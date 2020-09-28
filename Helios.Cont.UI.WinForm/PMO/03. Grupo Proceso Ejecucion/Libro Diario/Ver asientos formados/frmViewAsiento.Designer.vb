<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewAsiento
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim GridBaseStyle1 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
        Dim GridBaseStyle2 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
        Dim GridBaseStyle3 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
        Dim GridBaseStyle4 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
        Dim GridRangeStyle1 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle2 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle3 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle4 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle5 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle6 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle7 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle8 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle9 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle10 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle11 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle12 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim GridRangeStyle13 As Syncfusion.Windows.Forms.Grid.GridRangeStyle = New Syncfusion.Windows.Forms.Grid.GridRangeStyle()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GridControl1 = New Syncfusion.Windows.Forms.Grid.GridControl()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        GridBaseStyle1.Name = "Column Header"
        GridBaseStyle1.StyleInfo.BaseStyle = "Header"
        GridBaseStyle1.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridBaseStyle2.Name = "Header"
        GridBaseStyle2.StyleInfo.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.Borders.Left = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.CellType = "Header"
        GridBaseStyle2.StyleInfo.Font.Bold = True
        GridBaseStyle2.StyleInfo.Interior = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(184, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(216, Byte), Integer)))
        GridBaseStyle2.StyleInfo.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
        GridBaseStyle3.Name = "Standard"
        GridBaseStyle3.StyleInfo.Font.Facename = "Tahoma"
        GridBaseStyle3.StyleInfo.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridBaseStyle4.Name = "Row Header"
        GridBaseStyle4.StyleInfo.BaseStyle = "Header"
        GridBaseStyle4.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
        GridBaseStyle4.StyleInfo.Interior = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Horizontal, System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(184, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(216, Byte), Integer)))
        Me.GridControl1.BaseStylesMap.AddRange(New Syncfusion.Windows.Forms.Grid.GridBaseStyle() {GridBaseStyle1, GridBaseStyle2, GridBaseStyle3, GridBaseStyle4})
        Me.GridControl1.ColWidthEntries.AddRange(New Syncfusion.Windows.Forms.Grid.GridColWidth() {New Syncfusion.Windows.Forms.Grid.GridColWidth(0, 50), New Syncfusion.Windows.Forms.Grid.GridColWidth(1, 80), New Syncfusion.Windows.Forms.Grid.GridColWidth(2, 171), New Syncfusion.Windows.Forms.Grid.GridColWidth(3, 269), New Syncfusion.Windows.Forms.Grid.GridColWidth(4, 80), New Syncfusion.Windows.Forms.Grid.GridColWidth(5, 80), New Syncfusion.Windows.Forms.Grid.GridColWidth(6, 80), New Syncfusion.Windows.Forms.Grid.GridColWidth(7, 80), New Syncfusion.Windows.Forms.Grid.GridColWidth(8, 80), New Syncfusion.Windows.Forms.Grid.GridColWidth(9, 80)})
        Me.GridControl1.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 6, 1, 7), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 4, 1, 5)})
        Me.GridControl1.DefaultGridBorderStyle = Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid
        Me.GridControl1.DefaultRowHeight = 20
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.GridControl1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GridControl1.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        'Me.GridControl1.IsSpreadsheetFillSeries = False
        Me.GridControl1.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MetroScrollBars = True
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Properties.ColHeaders = False
        Me.GridControl1.Properties.DisplayHorzLines = False
        Me.GridControl1.Properties.ForceImmediateRepaint = False
        Me.GridControl1.Properties.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.GridControl1.Properties.MarkColHeader = False
        Me.GridControl1.Properties.MarkRowHeader = False
        Me.GridControl1.Properties.RowHeaders = False
        GridRangeStyle1.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Table
        GridRangeStyle1.StyleInfo.Font.Bold = False
        GridRangeStyle1.StyleInfo.Font.Facename = "Segoe UI"
        GridRangeStyle1.StyleInfo.Font.Italic = False
        GridRangeStyle1.StyleInfo.Font.Size = 8.0!
        GridRangeStyle1.StyleInfo.Font.Strikeout = False
        GridRangeStyle1.StyleInfo.Font.Underline = False
        GridRangeStyle1.StyleInfo.Font.Unit = System.Drawing.GraphicsUnit.Point
        GridRangeStyle2.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Rows(1, 2)
        GridRangeStyle2.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridRangeStyle3.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(1, 1)
        GridRangeStyle3.StyleInfo.Font.Bold = True
        GridRangeStyle3.StyleInfo.Text = "Código"
        GridRangeStyle4.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(1, 2)
        GridRangeStyle4.StyleInfo.Font.Bold = True
        GridRangeStyle4.StyleInfo.Text = "Cuenta"
        GridRangeStyle5.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(1, 3)
        GridRangeStyle5.StyleInfo.Font.Bold = True
        GridRangeStyle5.StyleInfo.Text = "Descripción"
        GridRangeStyle6.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(1, 4)
        GridRangeStyle6.StyleInfo.Font.Bold = True
        GridRangeStyle6.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridRangeStyle6.StyleInfo.Text = "M.N."
        GridRangeStyle7.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(1, 5)
        GridRangeStyle7.StyleInfo.Font.Bold = True
        GridRangeStyle8.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(1, 6)
        GridRangeStyle8.StyleInfo.Font.Bold = True
        GridRangeStyle8.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridRangeStyle8.StyleInfo.Text = "M.E."
        GridRangeStyle9.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(1, 7)
        GridRangeStyle9.StyleInfo.Font.Bold = True
        GridRangeStyle10.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(2, 4)
        GridRangeStyle10.StyleInfo.Text = "DEBE"
        GridRangeStyle11.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(2, 5)
        GridRangeStyle11.StyleInfo.Text = "HABER"
        GridRangeStyle12.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(2, 6)
        GridRangeStyle12.StyleInfo.Text = "DEBE"
        GridRangeStyle13.Range = Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cell(2, 7)
        GridRangeStyle13.StyleInfo.Text = "HABER"
        Me.GridControl1.RangeStyles.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeStyle() {GridRangeStyle1, GridRangeStyle2, GridRangeStyle3, GridRangeStyle4, GridRangeStyle5, GridRangeStyle6, GridRangeStyle7, GridRangeStyle8, GridRangeStyle9, GridRangeStyle10, GridRangeStyle11, GridRangeStyle12, GridRangeStyle13})
        Me.GridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GridControl1.RowHeightEntries.AddRange(New Syncfusion.Windows.Forms.Grid.GridRowHeight() {New Syncfusion.Windows.Forms.Grid.GridRowHeight(0, 30), New Syncfusion.Windows.Forms.Grid.GridRowHeight(1, 22), New Syncfusion.Windows.Forms.Grid.GridRowHeight(2, 22), New Syncfusion.Windows.Forms.Grid.GridRowHeight(3, 22), New Syncfusion.Windows.Forms.Grid.GridRowHeight(4, 22), New Syncfusion.Windows.Forms.Grid.GridRowHeight(5, 22), New Syncfusion.Windows.Forms.Grid.GridRowHeight(6, 22), New Syncfusion.Windows.Forms.Grid.GridRowHeight(7, 22), New Syncfusion.Windows.Forms.Grid.GridRowHeight(8, 22), New Syncfusion.Windows.Forms.Grid.GridRowHeight(9, 22)})
        Me.GridControl1.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeAsRangeStylesIntoCode
        Me.GridControl1.Size = New System.Drawing.Size(858, 267)
        Me.GridControl1.SmartSizeBox = False
        'Me.GridControl1.SpreadsheetLikeSelection = False
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ThemesEnabled = True
        Me.GridControl1.UseRightToLeftCompatibleTextBox = True
        '
        'frmViewAsiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonHoverColor = System.Drawing.Color.WhiteSmoke
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(30, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Visualizar Asiento"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(858, 267)
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "frmViewAsiento"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.Text = ""
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As Syncfusion.Windows.Forms.Grid.GridControl
End Class

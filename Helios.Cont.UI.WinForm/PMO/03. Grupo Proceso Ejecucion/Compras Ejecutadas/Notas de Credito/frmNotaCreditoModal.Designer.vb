<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaCreditoModal
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
        Dim GridStyleInfo1 As Syncfusion.Windows.Forms.Grid.GridStyleInfo = New Syncfusion.Windows.Forms.Grid.GridStyleInfo()
        Me.cboTipoExistencia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboPrestamos = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboTipoEntidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GDB = New Syncfusion.Windows.Forms.Grid.GridDataBoundGrid()
        Me.idDocumento = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.tipoCompra = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.Fecha = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.periodo = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.TipoDoc = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.Serie = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.Numero = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.moneda = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.txtRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.MaskedEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GDB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboTipoExistencia
        '
        Me.cboTipoExistencia.BackColor = System.Drawing.Color.White
        Me.cboTipoExistencia.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cboTipoExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoExistencia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoExistencia.Location = New System.Drawing.Point(76, 6)
        Me.cboTipoExistencia.Name = "cboTipoExistencia"
        Me.cboTipoExistencia.Size = New System.Drawing.Size(181, 21)
        Me.cboTipoExistencia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoExistencia.TabIndex = 211
        '
        'cboPrestamos
        '
        Me.cboPrestamos.BackColor = System.Drawing.Color.White
        Me.cboPrestamos.BeforeTouchSize = New System.Drawing.Size(68, 21)
        Me.cboPrestamos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrestamos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrestamos.Location = New System.Drawing.Point(260, 32)
        Me.cboPrestamos.Name = "cboPrestamos"
        Me.cboPrestamos.Size = New System.Drawing.Size(68, 21)
        Me.cboPrestamos.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboPrestamos.TabIndex = 429
        Me.cboPrestamos.Visible = False
        '
        'cboTipoEntidad
        '
        Me.cboTipoEntidad.BackColor = System.Drawing.Color.White
        Me.cboTipoEntidad.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cboTipoEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEntidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoEntidad.Location = New System.Drawing.Point(76, 6)
        Me.cboTipoEntidad.Name = "cboTipoEntidad"
        Me.cboTipoEntidad.Size = New System.Drawing.Size(181, 21)
        Me.cboTipoEntidad.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoEntidad.TabIndex = 211
        '
        'GDB
        '
        Me.GDB.AllowDragSelectedCols = True
        Me.GDB.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        GridBaseStyle1.Name = "Column Header"
        GridBaseStyle1.StyleInfo.BaseStyle = "Header"
        GridBaseStyle1.StyleInfo.CellType = "ColumnHeaderCell"
        GridBaseStyle1.StyleInfo.Enabled = False
        GridBaseStyle1.StyleInfo.Font.Bold = True
        GridBaseStyle1.StyleInfo.Font.Size = 8.0!
        GridBaseStyle1.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridBaseStyle1.StyleInfo.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        GridBaseStyle2.Name = "Header"
        GridBaseStyle2.StyleInfo.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.Borders.Left = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
        GridBaseStyle2.StyleInfo.CellType = "Header"
        GridBaseStyle2.StyleInfo.Font.Bold = True
        GridBaseStyle2.StyleInfo.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
        GridBaseStyle2.StyleInfo.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
        GridBaseStyle3.Name = "Standard"
        GridBaseStyle3.StyleInfo.CheckBoxOptions.CheckedValue = "True"
        GridBaseStyle3.StyleInfo.CheckBoxOptions.UncheckedValue = "False"
        GridBaseStyle3.StyleInfo.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        GridBaseStyle4.Name = "Row Header"
        GridBaseStyle4.StyleInfo.BaseStyle = "Header"
        GridBaseStyle4.StyleInfo.CellType = "RowHeaderCell"
        GridBaseStyle4.StyleInfo.Enabled = True
        GridBaseStyle4.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
        Me.GDB.BaseStylesMap.AddRange(New Syncfusion.Windows.Forms.Grid.GridBaseStyle() {GridBaseStyle1, GridBaseStyle2, GridBaseStyle3, GridBaseStyle4})
        Me.GDB.ColorStyles = Syncfusion.Windows.Forms.ColorStyles.Office2010Blue
        Me.GDB.DefaultRowHeight = 20
        Me.GDB.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GDB.EnableAddNew = False
        Me.GDB.EnableEdit = False
        Me.GDB.EnableRemove = False
        Me.GDB.GridBoundColumns.AddRange(New Syncfusion.Windows.Forms.Grid.GridBoundColumn() {Me.idDocumento, Me.tipoCompra, Me.Fecha, Me.periodo, Me.TipoDoc, Me.Serie, Me.Numero, Me.moneda})
        Me.GDB.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GDB.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        'Me.GDB.IsSpreadsheetFillSeries = False
        Me.GDB.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One
        Me.GDB.Location = New System.Drawing.Point(0, 84)
        Me.GDB.MetroScrollBars = True
        Me.GDB.Name = "GDB"
        Me.GDB.OptimizeInsertRemoveCells = True
        Me.GDB.Properties.ForceImmediateRepaint = False
        Me.GDB.Properties.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.GDB.Properties.MarkColHeader = False
        Me.GDB.Properties.MarkRowHeader = False
        Me.GDB.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GDB.Size = New System.Drawing.Size(604, 365)
        Me.GDB.SmartSizeBox = False
        Me.GDB.SortBehavior = Syncfusion.Windows.Forms.Grid.GridSortBehavior.DoubleClick
        'Me.GDB.SpreadsheetLikeSelection = False
        Me.GDB.TabIndex = 437
        GridStyleInfo1.BaseStyle = "Standard"
        Me.GDB.TableStyle = GridStyleInfo1
        Me.GDB.Text = "GridDataBoundGrid1"
        Me.GDB.ThemesEnabled = True
        Me.GDB.TransparentBackground = True
        Me.GDB.UseListChangedEvent = True
        Me.GDB.UseRightToLeftCompatibleTextBox = True
        '
        'idDocumento
        '
        Me.idDocumento.HeaderText = "idDocumento"
        Me.idDocumento.Hidden = True
        Me.idDocumento.MappingName = "idDocumento"
        Me.idDocumento.Position = 1
        Me.idDocumento.Width = 5
        '
        'tipoCompra
        '
        Me.tipoCompra.HeaderText = "T.C."
        Me.tipoCompra.Hidden = False
        Me.tipoCompra.MappingName = "tipoCompra"
        Me.tipoCompra.Position = 2
        Me.tipoCompra.Width = 60
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Hidden = False
        Me.Fecha.MappingName = "Fecha"
        Me.Fecha.Position = 3
        Me.Fecha.Width = -1
        '
        'periodo
        '
        Me.periodo.HeaderText = "periodo"
        Me.periodo.Hidden = False
        Me.periodo.MappingName = "periodo"
        Me.periodo.Position = 4
        Me.periodo.Width = -1
        '
        'TipoDoc
        '
        Me.TipoDoc.HeaderText = "Tipo Doc."
        Me.TipoDoc.Hidden = False
        Me.TipoDoc.MappingName = "TipoDoc"
        Me.TipoDoc.Position = 5
        Me.TipoDoc.Width = 65
        '
        'Serie
        '
        Me.Serie.HeaderText = "Serie"
        Me.Serie.Hidden = False
        Me.Serie.MappingName = "Serie"
        Me.Serie.Position = 6
        Me.Serie.Width = 70
        '
        'Numero
        '
        Me.Numero.HeaderText = "Numero"
        Me.Numero.Hidden = False
        Me.Numero.MappingName = "Numero"
        Me.Numero.Position = 7
        Me.Numero.Width = 150
        '
        'moneda
        '
        Me.moneda.HeaderText = "moneda"
        Me.moneda.Hidden = False
        Me.moneda.MappingName = "moneda"
        Me.moneda.Position = 8
        Me.moneda.Width = -1
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.White
        Me.txtRuc.BeforeTouchSize = New System.Drawing.Size(224, 20)
        Me.txtRuc.BorderColor = System.Drawing.SystemColors.Highlight
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRuc.Location = New System.Drawing.Point(63, 58)
        Me.txtRuc.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC6329681
        Me.txtRuc.Size = New System.Drawing.Size(224, 20)
        Me.txtRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtRuc.TabIndex = 436
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(17, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 435
        Me.Label9.Text = "Buscar:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.Color.White
        Me.txtPeriodo.BeforeTouchSize = New System.Drawing.Size(224, 20)
        Me.txtPeriodo.BorderColor = System.Drawing.SystemColors.Highlight
        Me.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPeriodo.Location = New System.Drawing.Point(63, 34)
        Me.txtPeriodo.Mask = "##/####"
        Me.txtPeriodo.MaxLength = 7
        Me.txtPeriodo.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.fecha_del_calendario_icono_6664_64
        Me.txtPeriodo.Size = New System.Drawing.Size(86, 20)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPeriodo.TabIndex = 434
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(13, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 433
        Me.Label10.Text = "Período:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(604, 25)
        Me.ToolStrip1.TabIndex = 438
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(156, 22)
        Me.lblEstado.Text = "Estado: búsqueda interactiva."
        '
        'frmNotaCreditoModal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(604, 449)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GDB)
        Me.Controls.Add(Me.txtRuc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.Label10)
        Me.MaximizeBox = False
        Me.Name = "frmNotaCreditoModal"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Buscar Comprobante"
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GDB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTipoExistencia As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboPrestamos As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboTipoEntidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.MaskedEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRuc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GDB As Syncfusion.Windows.Forms.Grid.GridDataBoundGrid
    Friend WithEvents idDocumento As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents tipoCompra As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents Fecha As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents periodo As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents TipoDoc As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents Serie As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents Numero As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents moneda As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormImportarProductos
    Inherits MetroForm

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
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor28 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor29 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor30 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor31 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor32 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor33 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor34 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor35 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor36 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtDia = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.dgvCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RoundButton21)
        Me.Panel1.Controls.Add(Me.ProgressBar2)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cboAlmacen)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.TxtDia)
        Me.Panel1.Controls.Add(Me.cboAnio)
        Me.Panel1.Controls.Add(Me.cboMesCompra)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(979, 80)
        Me.Panel1.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(282, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 14)
        Me.Label9.TabIndex = 528
        Me.Label9.Text = "Almacén de destino"
        '
        'cboAlmacen
        '
        Me.cboAlmacen.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.BeforeTouchSize = New System.Drawing.Size(278, 21)
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.Location = New System.Drawing.Point(285, 35)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(278, 21)
        Me.cboAlmacen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAlmacen.TabIndex = 527
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(19, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 14)
        Me.Label12.TabIndex = 526
        Me.Label12.Text = "Información del comprobante"
        '
        'TxtDia
        '
        Me.TxtDia.AllowNull = True
        Me.TxtDia.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtDia.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TxtDia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TxtDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDia.CurrencyDecimalDigits = 0
        Me.TxtDia.CurrencySymbol = ""
        Me.TxtDia.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtDia.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TxtDia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtDia.Location = New System.Drawing.Point(22, 36)
        Me.TxtDia.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TxtDia.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TxtDia.Name = "TxtDia"
        Me.TxtDia.NegativeColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TxtDia.NullString = ""
        Me.TxtDia.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtDia.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtDia.Size = New System.Drawing.Size(51, 20)
        Me.TxtDia.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TxtDia.TabIndex = 525
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.Location = New System.Drawing.Point(208, 35)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.cboAnio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cboAnio.Size = New System.Drawing.Size(60, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnio.TabIndex = 524
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(127, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(77, 35)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(127, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 523
        '
        'dgvCompra
        '
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCompra.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompra.FreezeCaption = False
        Me.dgvCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue
        Me.dgvCompra.Location = New System.Drawing.Point(0, 80)
        Me.dgvCompra.Name = "dgvCompra"
        Me.dgvCompra.Size = New System.Drawing.Size(979, 396)
        Me.dgvCompra.TabIndex = 418
        Me.dgvCompra.TableDescriptor.AllowNew = False
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCompra.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor28.HeaderImage = Nothing
        GridColumnDescriptor28.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor28.MappingName = "codigo"
        GridColumnDescriptor28.ReadOnly = True
        GridColumnDescriptor28.SerializedImageArray = ""
        GridColumnDescriptor29.AllowSort = False
        GridColumnDescriptor29.HeaderImage = Nothing
        GridColumnDescriptor29.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor29.HeaderText = "GR."
        GridColumnDescriptor29.MappingName = "gravado"
        GridColumnDescriptor29.SerializedImageArray = ""
        GridColumnDescriptor29.Width = 30
        GridColumnDescriptor30.AllowSort = False
        GridColumnDescriptor30.HeaderImage = Nothing
        GridColumnDescriptor30.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor30.MappingName = "idProducto"
        GridColumnDescriptor30.ReadOnly = True
        GridColumnDescriptor30.SerializedImageArray = ""
        GridColumnDescriptor31.AllowSort = False
        GridColumnDescriptor31.HeaderImage = Nothing
        GridColumnDescriptor31.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor31.HeaderText = "ITEM"
        GridColumnDescriptor31.MappingName = "item"
        GridColumnDescriptor31.ReadOnly = True
        GridColumnDescriptor31.SerializedImageArray = ""
        GridColumnDescriptor31.Width = 381
        GridColumnDescriptor32.AllowSort = False
        GridColumnDescriptor32.HeaderImage = Nothing
        GridColumnDescriptor32.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor32.HeaderText = "U.M."
        GridColumnDescriptor32.MappingName = "um"
        GridColumnDescriptor32.ReadOnly = True
        GridColumnDescriptor32.SerializedImageArray = ""
        GridColumnDescriptor32.Width = 50
        GridColumnDescriptor33.AllowSort = False
        GridColumnDescriptor33.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor33.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor33.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Cornsilk)
        GridColumnDescriptor33.HeaderImage = Nothing
        GridColumnDescriptor33.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor33.HeaderText = "CANT."
        GridColumnDescriptor33.MappingName = "cantidad"
        GridColumnDescriptor33.SerializedImageArray = ""
        GridColumnDescriptor33.Width = 70
        GridColumnDescriptor34.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor34.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor34.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)))
        GridColumnDescriptor34.HeaderImage = Nothing
        GridColumnDescriptor34.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor34.MappingName = "menor"
        GridColumnDescriptor34.SerializedImageArray = ""
        GridColumnDescriptor34.Width = 70
        GridColumnDescriptor35.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor35.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor35.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)))
        GridColumnDescriptor35.HeaderImage = Nothing
        GridColumnDescriptor35.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor35.MappingName = "mayor"
        GridColumnDescriptor35.SerializedImageArray = ""
        GridColumnDescriptor35.Width = 70
        GridColumnDescriptor36.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor36.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor36.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)))
        GridColumnDescriptor36.HeaderImage = Nothing
        GridColumnDescriptor36.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor36.MappingName = "gmayor"
        GridColumnDescriptor36.SerializedImageArray = ""
        GridColumnDescriptor36.Width = 70
        Me.dgvCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor28, GridColumnDescriptor29, GridColumnDescriptor30, GridColumnDescriptor31, GridColumnDescriptor32, GridColumnDescriptor33, GridColumnDescriptor34, GridColumnDescriptor35, GridColumnDescriptor36})
        Me.dgvCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompra.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCompra.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("gravado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idProducto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("item"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("um"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("menor"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("mayor"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("gmayor")})
        Me.dgvCompra.Text = "GridGroupingControl2"
        Me.dgvCompra.VersionInfo = "12.4400.0.24"
        '
        'BackgroundWorker1
        '
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(530, 17)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 529
        Me.ProgressBar2.Visible = False
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(99, 31)
        Me.RoundButton21.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(836, 25)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(99, 31)
        Me.RoundButton21.TabIndex = 530
        Me.RoundButton21.Text = "Grabar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'FormImportarProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 476)
        Me.Controls.Add(Me.dgvCompra)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormImportarProductos"
        Me.ShowIcon = False
        Me.Text = "Generar Nuevo Aporte de existencias"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvCompra As Grid.Grouping.GridGroupingControl
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtDia As Tools.CurrencyTextBox
    Friend WithEvents cboAnio As Tools.ComboBoxAdv
    Friend WithEvents cboMesCompra As Tools.ComboBoxAdv
    Friend WithEvents Label9 As Label
    Friend WithEvents cboAlmacen As Tools.ComboBoxAdv
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents RoundButton21 As RoundButton2
End Class

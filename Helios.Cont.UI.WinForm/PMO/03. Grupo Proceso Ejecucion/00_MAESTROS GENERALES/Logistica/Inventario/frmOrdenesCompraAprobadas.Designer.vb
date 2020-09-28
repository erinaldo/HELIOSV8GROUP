<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenesCompraAprobadas
    Inherits frmMaster

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
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenesCompraAprobadas))
        Me.dgvOrdenCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel35 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        CType(Me.dgvOrdenCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel35.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvOrdenCompra
        '
        Me.dgvOrdenCompra.BackColor = System.Drawing.SystemColors.Window
        Me.dgvOrdenCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOrdenCompra.FreezeCaption = False
        Me.dgvOrdenCompra.Location = New System.Drawing.Point(0, 37)
        Me.dgvOrdenCompra.Name = "dgvOrdenCompra"
        Me.dgvOrdenCompra.Size = New System.Drawing.Size(954, 458)
        Me.dgvOrdenCompra.TabIndex = 255
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Tipo"
        GridColumnDescriptor1.MappingName = "tipoCompra"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 90
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Fecha"
        GridColumnDescriptor2.MappingName = "fechaDoc"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 120
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Tipo Doc"
        GridColumnDescriptor3.MappingName = "tipoDoc"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 50
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Serie"
        GridColumnDescriptor4.MappingName = "serie"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 60
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Número"
        GridColumnDescriptor5.MappingName = "numeroDoc"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 125
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Proveedor"
        GridColumnDescriptor6.MappingName = "nombrePersona"
        GridColumnDescriptor6.Name = "nombrePersona"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 250
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "M.N."
        GridColumnDescriptor7.MappingName = "importeTotal"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 70
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "T/c"
        GridColumnDescriptor8.MappingName = "tcDolLoc"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 60
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "M.E."
        GridColumnDescriptor9.MappingName = "importeUS"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 70
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Moneda"
        GridColumnDescriptor10.MappingName = "monedaDoc"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 50
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.MappingName = "situacion"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 50
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.MappingName = "idDocumento"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.HeaderText = "Pago"
        GridColumnDescriptor13.MappingName = "estado"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 70
        Me.dgvOrdenCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13})
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor1.DataMember = "importeTotal"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "importeTotal"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor2.DataMember = "importeUS"
        GridSummaryColumnDescriptor2.Format = "{Sum}"
        GridSummaryColumnDescriptor2.Name = "importeUS"
        GridSummaryColumnDescriptor2.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1, GridSummaryColumnDescriptor2})
        Me.dgvOrdenCompra.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.dgvOrdenCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoCompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("serie"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numeroDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombrePersona"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeTotal"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tcDolLoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeUS"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monedaDoc")})
        Me.dgvOrdenCompra.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvOrdenCompra.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvOrdenCompra.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvOrdenCompra.Text = "gridGroupingControl1"
        Me.dgvOrdenCompra.VersionInfo = "12.2400.0.20"
        '
        'Panel35
        '
        Me.Panel35.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Panel35.Controls.Add(Me.Button1)
        Me.Panel35.Controls.Add(Me.Label51)
        Me.Panel35.Controls.Add(Me.Label59)
        Me.Panel35.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel35.Location = New System.Drawing.Point(0, 0)
        Me.Panel35.Name = "Panel35"
        Me.Panel35.Size = New System.Drawing.Size(954, 37)
        Me.Panel35.TabIndex = 254
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DimGray
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Corbel", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(238, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Ver detalle orden"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label51.Location = New System.Drawing.Point(75, 12)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(146, 13)
        Me.Label51.TabIndex = 2
        Me.Label51.Text = "/ Orden compra aprobadas"
        '
        'Label59
        '
        Me.Label59.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.Black
        Me.Label59.Image = CType(resources.GetObject("Label59.Image"), System.Drawing.Image)
        Me.Label59.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label59.Location = New System.Drawing.Point(5, 6)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(71, 25)
        Me.Label59.TabIndex = 0
        Me.Label59.Text = "LISTA"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmOrdenesCompraAprobadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(954, 495)
        Me.Controls.Add(Me.dgvOrdenCompra)
        Me.Controls.Add(Me.Panel35)
        Me.Name = "frmOrdenesCompraAprobadas"
        Me.ShowIcon = False
        Me.Text = "Ordenes de Compra aprobadas"
        CType(Me.dgvOrdenCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel35.ResumeLayout(False)
        Me.Panel35.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents dgvOrdenCompra As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel35 As Panel
    Friend WithEvents Label51 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents Button1 As Button
End Class

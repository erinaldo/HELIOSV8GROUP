<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUltimasOtrasSalidasAlmacen
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
        Dim GridColumnDescriptor23 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor24 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor25 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor26 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor27 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor28 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor29 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor30 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor31 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor32 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor33 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridStackedHeaderDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor()
        Dim GridStackedHeaderDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAlmacen = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboMov = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvEntrada = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboMov, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboMov)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(749, 42)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Location = New System.Drawing.Point(287, 13)
        Me.txtAlmacen.MaxLength = 5
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.Size = New System.Drawing.Size(262, 19)
        Me.txtAlmacen.TabIndex = 210
        Me.txtAlmacen.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 209
        Me.Label2.Text = "Almacen:"
        '
        'cboMov
        '
        Me.cboMov.BackColor = System.Drawing.Color.White
        Me.cboMov.BeforeTouchSize = New System.Drawing.Size(154, 21)
        Me.cboMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMov.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMov.Items.AddRange(New Object() {"", "5 últimas entradas", "10 últimas entradas", "15 últimas entradas"})
        Me.cboMov.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMov, ""))
        Me.cboMov.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMov, "5 últimas entradas"))
        Me.cboMov.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMov, "10 últimas entradas"))
        Me.cboMov.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMov, "15 últimas entradas"))
        Me.cboMov.Location = New System.Drawing.Point(43, 12)
        Me.cboMov.Name = "cboMov"
        Me.cboMov.Size = New System.Drawing.Size(154, 21)
        Me.cboMov.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMov.TabIndex = 207
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 208
        Me.Label1.Text = "Ver:"
        '
        'dgvEntrada
        '
        Me.dgvEntrada.BackColor = System.Drawing.SystemColors.Window
        Me.dgvEntrada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEntrada.FreezeCaption = False
        Me.dgvEntrada.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvEntrada.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvEntrada.Location = New System.Drawing.Point(0, 42)
        Me.dgvEntrada.Name = "dgvEntrada"
        Me.dgvEntrada.Size = New System.Drawing.Size(749, 262)
        Me.dgvEntrada.TabIndex = 208
        Me.dgvEntrada.TableDescriptor.AllowNew = False
        GridColumnDescriptor23.HeaderImage = Nothing
        GridColumnDescriptor23.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor23.HeaderText = "Fecha"
        GridColumnDescriptor23.MappingName = "FechaDoc"
        GridColumnDescriptor23.ReadOnly = True
        GridColumnDescriptor23.SerializedImageArray = ""
        GridColumnDescriptor24.HeaderImage = Nothing
        GridColumnDescriptor24.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor24.HeaderText = "Tipo"
        GridColumnDescriptor24.MappingName = "tipoCompra"
        GridColumnDescriptor24.ReadOnly = True
        GridColumnDescriptor24.SerializedImageArray = ""
        GridColumnDescriptor25.HeaderImage = Nothing
        GridColumnDescriptor25.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor25.HeaderText = "Tipo Doc."
        GridColumnDescriptor25.MappingName = "TipoDoc"
        GridColumnDescriptor25.ReadOnly = True
        GridColumnDescriptor25.SerializedImageArray = ""
        GridColumnDescriptor26.HeaderImage = Nothing
        GridColumnDescriptor26.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor26.HeaderText = "Descripción"
        GridColumnDescriptor26.MappingName = "descripcionItem"
        GridColumnDescriptor26.ReadOnly = True
        GridColumnDescriptor26.SerializedImageArray = ""
        GridColumnDescriptor26.Width = 190
        GridColumnDescriptor27.HeaderImage = Nothing
        GridColumnDescriptor27.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor27.HeaderText = "U.M."
        GridColumnDescriptor27.MappingName = "unidad1"
        GridColumnDescriptor27.ReadOnly = True
        GridColumnDescriptor27.SerializedImageArray = ""
        GridColumnDescriptor28.HeaderImage = Nothing
        GridColumnDescriptor28.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor28.HeaderText = "Bonif."
        GridColumnDescriptor28.MappingName = "bonificacion"
        GridColumnDescriptor28.ReadOnly = True
        GridColumnDescriptor28.SerializedImageArray = ""
        GridColumnDescriptor28.Width = 50
        GridColumnDescriptor29.HeaderImage = Nothing
        GridColumnDescriptor29.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor29.HeaderText = "Cantidad"
        GridColumnDescriptor29.MappingName = "monto1"
        GridColumnDescriptor29.Name = "monto1"
        GridColumnDescriptor29.SerializedImageArray = ""
        GridColumnDescriptor30.HeaderImage = Nothing
        GridColumnDescriptor30.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor30.HeaderText = "P.U."
        GridColumnDescriptor30.MappingName = "precioUnitario"
        GridColumnDescriptor30.ReadOnly = True
        GridColumnDescriptor30.SerializedImageArray = ""
        GridColumnDescriptor30.Width = 70
        GridColumnDescriptor31.HeaderImage = Nothing
        GridColumnDescriptor31.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor31.HeaderText = "P.U."
        GridColumnDescriptor31.MappingName = "precioUnitarioUS"
        GridColumnDescriptor31.ReadOnly = True
        GridColumnDescriptor31.SerializedImageArray = ""
        GridColumnDescriptor31.Width = 70
        GridColumnDescriptor32.HeaderImage = Nothing
        GridColumnDescriptor32.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor32.HeaderText = "Importe"
        GridColumnDescriptor32.MappingName = "importe"
        GridColumnDescriptor32.ReadOnly = True
        GridColumnDescriptor32.SerializedImageArray = ""
        GridColumnDescriptor32.Width = 90
        GridColumnDescriptor33.HeaderImage = Nothing
        GridColumnDescriptor33.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor33.HeaderText = "Importe"
        GridColumnDescriptor33.MappingName = "importeUS"
        GridColumnDescriptor33.ReadOnly = True
        GridColumnDescriptor33.SerializedImageArray = ""
        GridColumnDescriptor33.Width = 120
        Me.dgvEntrada.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor23, GridColumnDescriptor24, GridColumnDescriptor25, GridColumnDescriptor26, GridColumnDescriptor27, GridColumnDescriptor28, GridColumnDescriptor29, GridColumnDescriptor30, GridColumnDescriptor31, GridColumnDescriptor32, GridColumnDescriptor33})
        GridStackedHeaderDescriptor5.Appearance.StackedHeaderCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.ActiveCaption)
        GridStackedHeaderDescriptor5.Appearance.StackedHeaderCell.TextColor = System.Drawing.SystemColors.ButtonHighlight
        GridStackedHeaderDescriptor5.Appearance.StackedHeaderCell.Themed = False
        GridStackedHeaderDescriptor5.HeaderText = "M O N E D A - N A C I O N A L"
        GridStackedHeaderDescriptor5.Name = "StackedHeader 2"
        GridStackedHeaderDescriptor5.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("precioUnitario"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importe")})
        GridStackedHeaderDescriptor6.Appearance.StackedHeaderCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.ActiveCaption)
        GridStackedHeaderDescriptor6.Appearance.StackedHeaderCell.TextColor = System.Drawing.SystemColors.ControlLightLight
        GridStackedHeaderDescriptor6.Appearance.StackedHeaderCell.Themed = False
        GridStackedHeaderDescriptor6.HeaderText = "M O N E D A - E X T R A N J E R A"
        GridStackedHeaderDescriptor6.Name = "StackedHeader 3"
        GridStackedHeaderDescriptor6.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("precioUnitarioUS"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeUS")})
        Me.dgvEntrada.TableDescriptor.StackedHeaderRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 1", "S O U R C E", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("FechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("tipoCompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("descripcionItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("unidad1"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("bonificacion")}), GridStackedHeaderDescriptor5, GridStackedHeaderDescriptor6}))
        Me.dgvEntrada.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvEntrada.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvEntrada.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("FechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoCompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad1"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("bonificacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monto1"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("precioUnitario"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importe"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("precioUnitarioUS"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeUS")})
        Me.dgvEntrada.Text = "GridGroupingControl1"
        Me.dgvEntrada.TopLevelGroupOptions.ShowCaption = False
        Me.dgvEntrada.VersionInfo = "12.4400.0.24"
        '
        'frmUltimasOtrasSalidasAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 304)
        Me.Controls.Add(Me.dgvEntrada)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUltimasOtrasSalidasAlmacen"
        Me.Text = "Ultimas entradas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cboMov, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEntrada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAlmacen As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboMov As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvEntrada As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentasXCobrarAcreencias
    Inherits frmMaster

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
        Dim GridColumnDescriptor43 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor44 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor45 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor46 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor47 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor48 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor49 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor50 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor51 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor52 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor53 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor54 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor55 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor56 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentasXCobrarAcreencias))
        Me.dgvGeneralCobros = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel41 = New System.Windows.Forms.Panel()
        Me.ButtonAdv89 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv88 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv48 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv47 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv49 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel40 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        CType(Me.dgvGeneralCobros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel41.SuspendLayout()
        Me.Panel40.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvGeneralCobros
        '
        Me.dgvGeneralCobros.BackColor = System.Drawing.SystemColors.Window
        Me.dgvGeneralCobros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGeneralCobros.FreezeCaption = False
        Me.dgvGeneralCobros.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvGeneralCobros.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvGeneralCobros.Location = New System.Drawing.Point(0, 106)
        Me.dgvGeneralCobros.Name = "dgvGeneralCobros"
        Me.dgvGeneralCobros.Size = New System.Drawing.Size(966, 467)
        Me.dgvGeneralCobros.TabIndex = 252
        Me.dgvGeneralCobros.TableDescriptor.AllowNew = False
        GridColumnDescriptor43.HeaderImage = Nothing
        GridColumnDescriptor43.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor43.MappingName = "idProveedor"
        GridColumnDescriptor43.ReadOnly = True
        GridColumnDescriptor43.SerializedImageArray = ""
        GridColumnDescriptor43.Width = 0
        GridColumnDescriptor44.HeaderImage = Nothing
        GridColumnDescriptor44.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor44.MappingName = "cuenta"
        GridColumnDescriptor44.SerializedImageArray = ""
        GridColumnDescriptor44.Width = 50
        GridColumnDescriptor45.HeaderImage = Nothing
        GridColumnDescriptor45.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor45.MappingName = "descripcion"
        GridColumnDescriptor45.SerializedImageArray = ""
        GridColumnDescriptor45.Width = 180
        GridColumnDescriptor46.HeaderImage = Nothing
        GridColumnDescriptor46.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor46.HeaderText = "Razon Social"
        GridColumnDescriptor46.MappingName = "razonSocial"
        GridColumnDescriptor46.ReadOnly = True
        GridColumnDescriptor46.SerializedImageArray = ""
        GridColumnDescriptor46.Width = 180
        GridColumnDescriptor47.HeaderImage = Nothing
        GridColumnDescriptor47.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor47.HeaderText = "Deuda"
        GridColumnDescriptor47.MappingName = "deuda"
        GridColumnDescriptor47.ReadOnly = True
        GridColumnDescriptor47.SerializedImageArray = ""
        GridColumnDescriptor47.Width = 70
        GridColumnDescriptor48.HeaderImage = Nothing
        GridColumnDescriptor48.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor48.HeaderText = "monto Cobrado"
        GridColumnDescriptor48.MappingName = "montoPago"
        GridColumnDescriptor48.ReadOnly = True
        GridColumnDescriptor48.SerializedImageArray = ""
        GridColumnDescriptor48.Width = 70
        GridColumnDescriptor49.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Red)
        GridColumnDescriptor49.HeaderImage = Nothing
        GridColumnDescriptor49.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor49.HeaderText = "Saldo"
        GridColumnDescriptor49.MappingName = "saldo"
        GridColumnDescriptor49.ReadOnly = True
        GridColumnDescriptor49.SerializedImageArray = ""
        GridColumnDescriptor49.Width = 70
        GridColumnDescriptor50.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Gold)
        GridColumnDescriptor50.HeaderImage = Nothing
        GridColumnDescriptor50.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor50.HeaderText = "Monto Vencido"
        GridColumnDescriptor50.MappingName = "montoVencido"
        GridColumnDescriptor50.ReadOnly = True
        GridColumnDescriptor50.SerializedImageArray = ""
        GridColumnDescriptor50.Width = 0
        GridColumnDescriptor51.HeaderImage = Nothing
        GridColumnDescriptor51.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor51.MappingName = "montoProg"
        GridColumnDescriptor51.ReadOnly = True
        GridColumnDescriptor51.SerializedImageArray = ""
        GridColumnDescriptor51.Width = 70
        GridColumnDescriptor52.HeaderImage = Nothing
        GridColumnDescriptor52.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor52.HeaderText = "Deuda ME"
        GridColumnDescriptor52.MappingName = "deudaME"
        GridColumnDescriptor52.ReadOnly = True
        GridColumnDescriptor52.SerializedImageArray = ""
        GridColumnDescriptor52.Width = 70
        GridColumnDescriptor53.HeaderImage = Nothing
        GridColumnDescriptor53.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor53.HeaderText = "monto Cobrado ME"
        GridColumnDescriptor53.MappingName = "montoPagoME"
        GridColumnDescriptor53.ReadOnly = True
        GridColumnDescriptor53.SerializedImageArray = ""
        GridColumnDescriptor53.Width = 70
        GridColumnDescriptor54.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Red)
        GridColumnDescriptor54.HeaderImage = Nothing
        GridColumnDescriptor54.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor54.HeaderText = "Saldo ME"
        GridColumnDescriptor54.MappingName = "saldome"
        GridColumnDescriptor54.ReadOnly = True
        GridColumnDescriptor54.SerializedImageArray = ""
        GridColumnDescriptor54.Width = 70
        GridColumnDescriptor55.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Gold)
        GridColumnDescriptor55.HeaderImage = Nothing
        GridColumnDescriptor55.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor55.HeaderText = "Monto Vencido ME"
        GridColumnDescriptor55.MappingName = "montoVencidoME"
        GridColumnDescriptor55.ReadOnly = True
        GridColumnDescriptor55.SerializedImageArray = ""
        GridColumnDescriptor55.Width = 0
        GridColumnDescriptor56.HeaderImage = Nothing
        GridColumnDescriptor56.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor56.MappingName = "montoProgME"
        GridColumnDescriptor56.ReadOnly = True
        GridColumnDescriptor56.SerializedImageArray = ""
        GridColumnDescriptor56.Width = 70
        Me.dgvGeneralCobros.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor43, GridColumnDescriptor44, GridColumnDescriptor45, GridColumnDescriptor46, GridColumnDescriptor47, GridColumnDescriptor48, GridColumnDescriptor49, GridColumnDescriptor50, GridColumnDescriptor51, GridColumnDescriptor52, GridColumnDescriptor53, GridColumnDescriptor54, GridColumnDescriptor55, GridColumnDescriptor56})
        Me.dgvGeneralCobros.TableDescriptor.StackedHeaderRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 1", "DEUDA MN", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("deuda"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoPago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("saldo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoProg"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoVencido")}), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 2", "DEUDA ME", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("deudaME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoPagoME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("saldome"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoProgME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoVencidoME")})}))
        Me.dgvGeneralCobros.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvGeneralCobros.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvGeneralCobros.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvGeneralCobros.Text = "GridGroupingControl3"
        Me.dgvGeneralCobros.VersionInfo = "12.4400.0.24"
        '
        'Panel41
        '
        Me.Panel41.BackColor = System.Drawing.Color.PeachPuff
        Me.Panel41.Controls.Add(Me.ButtonAdv89)
        Me.Panel41.Controls.Add(Me.ButtonAdv88)
        Me.Panel41.Controls.Add(Me.ButtonAdv48)
        Me.Panel41.Controls.Add(Me.ButtonAdv47)
        Me.Panel41.Controls.Add(Me.ButtonAdv49)
        Me.Panel41.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel41.Location = New System.Drawing.Point(0, 37)
        Me.Panel41.Name = "Panel41"
        Me.Panel41.Size = New System.Drawing.Size(966, 69)
        Me.Panel41.TabIndex = 251
        '
        'ButtonAdv89
        '
        Me.ButtonAdv89.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv89.BackColor = System.Drawing.Color.Olive
        Me.ButtonAdv89.BeforeTouchSize = New System.Drawing.Size(106, 51)
        Me.ButtonAdv89.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv89.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv89.IsBackStageButton = False
        Me.ButtonAdv89.Location = New System.Drawing.Point(499, 12)
        Me.ButtonAdv89.MetroColor = System.Drawing.Color.GreenYellow
        Me.ButtonAdv89.Name = "ButtonAdv89"
        Me.ButtonAdv89.Size = New System.Drawing.Size(106, 51)
        Me.ButtonAdv89.TabIndex = 532
        Me.ButtonAdv89.Text = "Cuentas por cobrar diversas"
        Me.ButtonAdv89.UseVisualStyle = True
        Me.ButtonAdv89.UseVisualStyleBackColor = False
        '
        'ButtonAdv88
        '
        Me.ButtonAdv88.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv88.BackColor = System.Drawing.Color.Olive
        Me.ButtonAdv88.BeforeTouchSize = New System.Drawing.Size(117, 51)
        Me.ButtonAdv88.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv88.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv88.IsBackStageButton = False
        Me.ButtonAdv88.Location = New System.Drawing.Point(376, 12)
        Me.ButtonAdv88.MetroColor = System.Drawing.Color.GreenYellow
        Me.ButtonAdv88.Name = "ButtonAdv88"
        Me.ButtonAdv88.Size = New System.Drawing.Size(117, 51)
        Me.ButtonAdv88.TabIndex = 531
        Me.ButtonAdv88.Text = "Cuentas por cobrar (Personas, socios, director, gerente)"
        Me.ButtonAdv88.UseVisualStyle = True
        Me.ButtonAdv88.UseVisualStyleBackColor = False
        '
        'ButtonAdv48
        '
        Me.ButtonAdv48.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv48.BackColor = System.Drawing.Color.Olive
        Me.ButtonAdv48.BeforeTouchSize = New System.Drawing.Size(106, 51)
        Me.ButtonAdv48.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv48.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv48.IsBackStageButton = False
        Me.ButtonAdv48.Location = New System.Drawing.Point(262, 12)
        Me.ButtonAdv48.MetroColor = System.Drawing.Color.GreenYellow
        Me.ButtonAdv48.Name = "ButtonAdv48"
        Me.ButtonAdv48.Size = New System.Drawing.Size(106, 51)
        Me.ButtonAdv48.TabIndex = 530
        Me.ButtonAdv48.Text = "Letras por cobrar"
        Me.ButtonAdv48.UseVisualStyle = True
        Me.ButtonAdv48.UseVisualStyleBackColor = False
        '
        'ButtonAdv47
        '
        Me.ButtonAdv47.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv47.BackColor = System.Drawing.Color.Olive
        Me.ButtonAdv47.BeforeTouchSize = New System.Drawing.Size(106, 51)
        Me.ButtonAdv47.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv47.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv47.IsBackStageButton = False
        Me.ButtonAdv47.Location = New System.Drawing.Point(149, 12)
        Me.ButtonAdv47.MetroColor = System.Drawing.Color.GreenYellow
        Me.ButtonAdv47.Name = "ButtonAdv47"
        Me.ButtonAdv47.Size = New System.Drawing.Size(106, 51)
        Me.ButtonAdv47.TabIndex = 529
        Me.ButtonAdv47.Text = "Otras Acreencias"
        Me.ButtonAdv47.UseVisualStyle = True
        Me.ButtonAdv47.UseVisualStyleBackColor = False
        '
        'ButtonAdv49
        '
        Me.ButtonAdv49.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv49.BackColor = System.Drawing.Color.Olive
        Me.ButtonAdv49.BeforeTouchSize = New System.Drawing.Size(106, 51)
        Me.ButtonAdv49.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv49.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv49.IsBackStageButton = False
        Me.ButtonAdv49.Location = New System.Drawing.Point(30, 12)
        Me.ButtonAdv49.MetroColor = System.Drawing.Color.GreenYellow
        Me.ButtonAdv49.Name = "ButtonAdv49"
        Me.ButtonAdv49.Size = New System.Drawing.Size(106, 51)
        Me.ButtonAdv49.TabIndex = 527
        Me.ButtonAdv49.Text = "Acreencias"
        Me.ButtonAdv49.UseVisualStyle = True
        Me.ButtonAdv49.UseVisualStyleBackColor = False
        '
        'Panel40
        '
        Me.Panel40.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel40.Controls.Add(Me.Label16)
        Me.Panel40.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel40.Location = New System.Drawing.Point(0, 0)
        Me.Panel40.Name = "Panel40"
        Me.Panel40.Size = New System.Drawing.Size(966, 37)
        Me.Panel40.TabIndex = 250
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Image = CType(resources.GetObject("Label16.Image"), System.Drawing.Image)
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Location = New System.Drawing.Point(5, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(250, 25)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "CUENTAS POR COBRAR (ACREENCIAS)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCuentasXCobrarAcreencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 573)
        Me.Controls.Add(Me.dgvGeneralCobros)
        Me.Controls.Add(Me.Panel41)
        Me.Controls.Add(Me.Panel40)
        Me.Name = "frmCuentasXCobrarAcreencias"
        Me.Text = "Cuentas por cobrar (Acreencias)"
        CType(Me.dgvGeneralCobros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel41.ResumeLayout(False)
        Me.Panel40.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvGeneralCobros As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel41 As System.Windows.Forms.Panel
    Friend WithEvents ButtonAdv89 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv88 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv48 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv47 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv49 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Panel40 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class

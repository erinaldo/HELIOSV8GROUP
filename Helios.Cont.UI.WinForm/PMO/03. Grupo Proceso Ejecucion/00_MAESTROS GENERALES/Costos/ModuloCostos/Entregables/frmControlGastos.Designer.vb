<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlGastos
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.TabPageAdv1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.dgvEntregables = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlAdv1.SuspendLayout()
        Me.TabPageAdv1.SuspendLayout()
        CType(Me.dgvEntregables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.ActiveTabColor = System.Drawing.Color.Black
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(636, 280)
        Me.TabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv1)
        Me.TabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlAdv1.EnableTouchMode = True
        Me.TabControlAdv1.FocusOnTabClick = False
        Me.TabControlAdv1.ItemSize = New System.Drawing.Size(118, 33)
        Me.TabControlAdv1.Location = New System.Drawing.Point(0, 0)
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.Size = New System.Drawing.Size(956, 485)
        Me.TabControlAdv1.TabIndex = 253
        Me.TabControlAdv1.TabPanelBackColor = System.Drawing.Color.AliceBlue
        Me.TabControlAdv1.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererBlendDark)
        Me.TabControlAdv1.ThemesEnabled = True
        '
        'TabPageAdv1
        '
        Me.TabPageAdv1.Controls.Add(Me.dgvEntregables)
        Me.TabPageAdv1.Controls.Add(Me.Panel3)
        Me.TabPageAdv1.Image = Nothing
        Me.TabPageAdv1.ImageSize = New System.Drawing.Size(25, 25)
        Me.TabPageAdv1.Location = New System.Drawing.Point(2, 34)
        Me.TabPageAdv1.Name = "TabPageAdv1"
        Me.TabPageAdv1.ShowCloseButton = True
        Me.TabPageAdv1.Size = New System.Drawing.Size(952, 449)
        Me.TabPageAdv1.TabBackColor = System.Drawing.Color.ForestGreen
        Me.TabPageAdv1.TabIndex = 1
        Me.TabPageAdv1.Text = "Listado de Gastos"
        Me.TabPageAdv1.ThemesEnabled = True
        '
        'dgvEntregables
        '
        Me.dgvEntregables.BackColor = System.Drawing.SystemColors.Window
        Me.dgvEntregables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEntregables.FreezeCaption = False
        Me.dgvEntregables.Location = New System.Drawing.Point(0, 37)
        Me.dgvEntregables.Name = "dgvEntregables"
        Me.dgvEntregables.Size = New System.Drawing.Size(952, 412)
        Me.dgvEntregables.TabIndex = 250
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Tipo Gasto"
        GridColumnDescriptor1.MappingName = "tipoGasto"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 180
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "idGasto"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 0
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "Gasto"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 180
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "compras"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 0
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "inventario"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 0
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "finanzas"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 0
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "libro"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 0
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.MappingName = "cuenta"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 0
        Me.dgvEntregables.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        Me.dgvEntregables.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoGasto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idGasto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Gasto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("compras"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("inventario"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("finanzas"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("libro"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cuenta")})
        Me.dgvEntregables.TableOptions.AllowDragColumns = False
        Me.dgvEntregables.TableOptions.AllowDropDownCell = False
        Me.dgvEntregables.TableOptions.AllowMultiColumnSort = False
        Me.dgvEntregables.TableOptions.AllowSortColumns = False
        Me.dgvEntregables.Text = "GridGroupingControl1"
        Me.dgvEntregables.VersionInfo = "12.4400.0.24"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.PeachPuff
        Me.Panel3.Controls.Add(Me.ButtonAdv5)
        Me.Panel3.Controls.Add(Me.ButtonAdv4)
        Me.Panel3.Controls.Add(Me.ButtonAdv3)
        Me.Panel3.Controls.Add(Me.ButtonAdv1)
        Me.Panel3.Controls.Add(Me.ButtonAdv2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(952, 37)
        Me.Panel3.TabIndex = 245
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(189, 21)
        Me.ButtonAdv5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(715, 6)
        Me.ButtonAdv5.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(189, 21)
        Me.ButtonAdv5.TabIndex = 527
        Me.ButtonAdv5.Text = "Salida  de Gastos - Finanzas"
        Me.ButtonAdv5.UseVisualStyle = True
        Me.ButtonAdv5.Visible = False
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.Color.MediumOrchid
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(189, 21)
        Me.ButtonAdv4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(520, 6)
        Me.ButtonAdv4.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(189, 21)
        Me.ButtonAdv4.TabIndex = 526
        Me.ButtonAdv4.Text = "Salida  de Gastos - Asiento Manual"
        Me.ButtonAdv4.UseVisualStyle = True
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.Color.SteelBlue
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(180, 21)
        Me.ButtonAdv3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(325, 6)
        Me.ButtonAdv3.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(180, 21)
        Me.ButtonAdv3.TabIndex = 525
        Me.ButtonAdv3.Text = "Salida de Gastos - Servicios"
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.ForestGreen
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(143, 21)
        Me.ButtonAdv1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(164, 8)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(143, 21)
        Me.ButtonAdv1.TabIndex = 524
        Me.ButtonAdv1.Text = "Gastos de Inventario"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(59, 21)
        Me.ButtonAdv2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(25, 8)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(59, 21)
        Me.ButtonAdv2.TabIndex = 522
        Me.ButtonAdv2.Text = "Consultar"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'frmControlGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.IndianRed
        Me.CaptionBarColor = System.Drawing.Color.IndianRed
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI Symbol", 10.0!, System.Drawing.FontStyle.Bold)
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(80, 10)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Hoja de Confirmacion de Gastos"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(956, 485)
        Me.Controls.Add(Me.TabControlAdv1)
        Me.Name = "frmControlGastos"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlAdv1.ResumeLayout(False)
        Me.TabPageAdv1.ResumeLayout(False)
        CType(Me.dgvEntregables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControlAdv1 As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents TabPageAdv1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents dgvEntregables As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
End Class

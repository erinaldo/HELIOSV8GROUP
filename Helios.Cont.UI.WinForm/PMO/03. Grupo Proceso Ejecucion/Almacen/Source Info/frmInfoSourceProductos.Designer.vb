<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoSourceProductos
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
        Me.ComboBoxAdv1 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.comboBoxAdv2 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.checkBox1 = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.checkBox2 = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.checkBox3 = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.checkBox4 = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.GDBSource = New Syncfusion.Windows.Forms.Grid.GridDataBoundGrid()
        Me.idEstablecimiento = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.NomAlmacen = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.origenRecaudo = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.tipoExistencia = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.descripcion = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.idUnidad = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.unidadMedida = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.cantidad = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.importeSoles = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        Me.Presentacion = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comboBoxAdv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GDBSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxAdv1
        '
        Me.ComboBoxAdv1.BackColor = System.Drawing.Color.White
        Me.ComboBoxAdv1.BeforeTouchSize = New System.Drawing.Size(121, 23)
        Me.ComboBoxAdv1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAdv1.Items.AddRange(New Object() {"Office2010Blue", "Office2010Black", "Office2010Silver", "Office2007Blue", "Office2007Black", "Office2007Silver", "Metro", "System", "None"})
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2010Blue"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2010Black"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2010Silver"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2007Blue"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2007Black"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Office2007Silver"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "Metro"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "System"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "None"))
        Me.ComboBoxAdv1.Location = New System.Drawing.Point(762, 269)
        Me.ComboBoxAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboBoxAdv1.Name = "ComboBoxAdv1"
        Me.ComboBoxAdv1.Size = New System.Drawing.Size(121, 23)
        Me.ComboBoxAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboBoxAdv1.TabIndex = 1
        '
        'comboBoxAdv2
        '
        Me.comboBoxAdv2.BackColor = System.Drawing.Color.White
        Me.comboBoxAdv2.BeforeTouchSize = New System.Drawing.Size(121, 23)
        Me.comboBoxAdv2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboBoxAdv2.Items.AddRange(New Object() {"StandardLabels", "MergedLabels"})
        Me.comboBoxAdv2.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.comboBoxAdv2, "StandardLabels"))
        Me.comboBoxAdv2.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.comboBoxAdv2, "MergedLabels"))
        Me.comboBoxAdv2.Location = New System.Drawing.Point(779, 202)
        Me.comboBoxAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.comboBoxAdv2.Name = "comboBoxAdv2"
        Me.comboBoxAdv2.Size = New System.Drawing.Size(121, 23)
        Me.comboBoxAdv2.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.comboBoxAdv2.TabIndex = 2
        '
        'checkBox1
        '
        Me.checkBox1.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.checkBox1.Checked = True
        Me.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBox1.DrawFocusRectangle = False
        Me.checkBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBox1.Location = New System.Drawing.Point(725, 48)
        Me.checkBox1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(141, 18)
        Me.checkBox1.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.checkBox1.TabIndex = 3
        Me.checkBox1.Text = "ShowCardCellBorders"
        Me.checkBox1.ThemesEnabled = False
        '
        'checkBox2
        '
        Me.checkBox2.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.checkBox2.Checked = True
        Me.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBox2.DrawFocusRectangle = False
        Me.checkBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBox2.Location = New System.Drawing.Point(725, 84)
        Me.checkBox2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.checkBox2.Name = "checkBox2"
        Me.checkBox2.Size = New System.Drawing.Size(141, 17)
        Me.checkBox2.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.checkBox2.TabIndex = 4
        Me.checkBox2.Text = "ShowCaption"
        Me.checkBox2.ThemesEnabled = False
        '
        'checkBox3
        '
        Me.checkBox3.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.checkBox3.DrawFocusRectangle = False
        Me.checkBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBox3.Location = New System.Drawing.Point(725, 130)
        Me.checkBox3.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.checkBox3.Name = "checkBox3"
        Me.checkBox3.Size = New System.Drawing.Size(141, 18)
        Me.checkBox3.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.checkBox3.TabIndex = 5
        Me.checkBox3.Text = "ApplyRoundedCorner"
        Me.checkBox3.ThemesEnabled = False
        '
        'checkBox4
        '
        Me.checkBox4.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.checkBox4.Checked = True
        Me.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBox4.DrawFocusRectangle = False
        Me.checkBox4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkBox4.Location = New System.Drawing.Point(725, 166)
        Me.checkBox4.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.checkBox4.Name = "checkBox4"
        Me.checkBox4.Size = New System.Drawing.Size(141, 21)
        Me.checkBox4.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.checkBox4.TabIndex = 6
        Me.checkBox4.Text = "BrowseOnly"
        Me.checkBox4.ThemesEnabled = False
        '
        'GDBSource
        '
        Me.GDBSource.AllowDragSelectedCols = True
        Me.GDBSource.BackColor = System.Drawing.Color.White
        Me.GDBSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GDBSource.DataMember = ""
        Me.GDBSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GDBSource.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GDBSource.GridBoundColumns.AddRange(New Syncfusion.Windows.Forms.Grid.GridBoundColumn() {Me.idEstablecimiento, Me.NomAlmacen, Me.origenRecaudo, Me.tipoExistencia, Me.descripcion, Me.idUnidad, Me.unidadMedida, Me.cantidad, Me.importeSoles, Me.Presentacion})
        'Me.GDBSource.IsSpreadsheetFillSeries = False
        Me.GDBSource.Location = New System.Drawing.Point(0, 0)
        Me.GDBSource.Name = "GDBSource"
        Me.GDBSource.OptimizeInsertRemoveCells = True
        Me.GDBSource.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GDBSource.Size = New System.Drawing.Size(897, 463)
        Me.GDBSource.SmartSizeBox = False
        Me.GDBSource.SortBehavior = Syncfusion.Windows.Forms.Grid.GridSortBehavior.DoubleClick
        'Me.GDBSource.SpreadsheetLikeSelection = False
        Me.GDBSource.TabIndex = 7
        Me.GDBSource.Text = "gridDataBoundGrid1"
        Me.GDBSource.ThemesEnabled = True
        Me.GDBSource.UseListChangedEvent = True
        Me.GDBSource.UseRightToLeftCompatibleTextBox = True
        '
        'idEstablecimiento
        '
        Me.idEstablecimiento.HeaderText = "IdEstablecimiento"
        Me.idEstablecimiento.Hidden = False
        Me.idEstablecimiento.MappingName = "idEstablecimiento"
        Me.idEstablecimiento.Position = 1
        Me.idEstablecimiento.Width = -1
        '
        'NomAlmacen
        '
        Me.NomAlmacen.HeaderText = "Almacen"
        Me.NomAlmacen.Hidden = False
        Me.NomAlmacen.MappingName = "NomAlmacen"
        Me.NomAlmacen.Position = 2
        Me.NomAlmacen.Width = -1
        '
        'origenRecaudo
        '
        Me.origenRecaudo.HeaderText = "Origen Recaudo"
        Me.origenRecaudo.Hidden = False
        Me.origenRecaudo.MappingName = "origenRecaudo"
        Me.origenRecaudo.Position = 3
        Me.origenRecaudo.Width = -1
        '
        'tipoExistencia
        '
        Me.tipoExistencia.HeaderText = "Tipo Existencia"
        Me.tipoExistencia.Hidden = False
        Me.tipoExistencia.MappingName = "tipoExistencia"
        Me.tipoExistencia.Position = 4
        Me.tipoExistencia.Width = -1
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Hidden = False
        Me.descripcion.MappingName = "descripcion"
        Me.descripcion.Position = 5
        Me.descripcion.Width = -1
        '
        'idUnidad
        '
        Me.idUnidad.HeaderText = "Unidad"
        Me.idUnidad.Hidden = False
        Me.idUnidad.MappingName = "idUnidad"
        Me.idUnidad.Position = 6
        Me.idUnidad.Width = -1
        '
        'unidadMedida
        '
        Me.unidadMedida.HeaderText = "Unidad Medida"
        Me.unidadMedida.Hidden = False
        Me.unidadMedida.MappingName = "unidadMedida"
        Me.unidadMedida.Position = 7
        Me.unidadMedida.Width = -1
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Hidden = False
        Me.cantidad.MappingName = "cantidad"
        Me.cantidad.Position = 8
        Me.cantidad.Width = -1
        '
        'importeSoles
        '
        Me.importeSoles.HeaderText = "Importe MN"
        Me.importeSoles.Hidden = False
        Me.importeSoles.MappingName = "importeSoles"
        Me.importeSoles.Position = 9
        Me.importeSoles.Width = -1
        '
        'Presentacion
        '
        Me.Presentacion.HeaderText = "Presentacion"
        Me.Presentacion.Hidden = False
        Me.Presentacion.MappingName = "Presentacion"
        Me.Presentacion.Position = 10
        Me.Presentacion.Width = -1
        '
        'frmInfoSourceProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(897, 463)
        Me.Controls.Add(Me.GDBSource)
        Me.Controls.Add(Me.checkBox4)
        Me.Controls.Add(Me.checkBox3)
        Me.Controls.Add(Me.checkBox2)
        Me.Controls.Add(Me.checkBox1)
        Me.Controls.Add(Me.comboBoxAdv2)
        Me.Controls.Add(Me.ComboBoxAdv1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoSourceProductos"
        Me.Text = "Bind Card"
        CType(Me.ComboBoxAdv1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.comboBoxAdv2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.checkBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.checkBox2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.checkBox3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.checkBox4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GDBSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Private WithEvents ComboBoxAdv1 As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Private WithEvents comboBoxAdv2 As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Private WithEvents checkBox1 As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Private WithEvents checkBox2 As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Private WithEvents checkBox3 As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Private WithEvents checkBox4 As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Public WithEvents GDBSource As Syncfusion.Windows.Forms.Grid.GridDataBoundGrid
    Friend WithEvents idEstablecimiento As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents NomAlmacen As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents origenRecaudo As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents tipoExistencia As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents descripcion As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents idUnidad As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents unidadMedida As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents cantidad As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents importeSoles As Syncfusion.Windows.Forms.Grid.GridBoundColumn
    Friend WithEvents Presentacion As Syncfusion.Windows.Forms.Grid.GridBoundColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteCaja))
        Dim GridColumnDescriptor25 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor26 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor27 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor28 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor29 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor30 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.dgvReporteCaja = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel20.SuspendLayout()
        CType(Me.dgvReporteCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel18.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel20.Controls.Add(Me.Label82)
        Me.Panel20.Controls.Add(Me.Label84)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.Location = New System.Drawing.Point(0, 0)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(867, 37)
        Me.Panel20.TabIndex = 416
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label82.Location = New System.Drawing.Point(148, 12)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(51, 13)
        Me.Label82.TabIndex = 1
        Me.Label82.Text = "/ Listado"
        '
        'Label84
        '
        Me.Label84.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.Black
        Me.Label84.Image = CType(resources.GetObject("Label84.Image"), System.Drawing.Image)
        Me.Label84.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label84.Location = New System.Drawing.Point(5, 6)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(144, 25)
        Me.Label84.TabIndex = 0
        Me.Label84.Text = "REPORTES DE CAJA"
        Me.Label84.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvReporteCaja
        '
        Me.dgvReporteCaja.BackColor = System.Drawing.SystemColors.Window
        Me.dgvReporteCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReporteCaja.FreezeCaption = False
        Me.dgvReporteCaja.Location = New System.Drawing.Point(0, 88)
        Me.dgvReporteCaja.Name = "dgvReporteCaja"
        Me.dgvReporteCaja.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvReporteCaja.NestedTableGroupOptions.ShowCaption = False
        Me.dgvReporteCaja.Size = New System.Drawing.Size(867, 305)
        Me.dgvReporteCaja.TabIndex = 415
        Me.dgvReporteCaja.TableDescriptor.ChildGroupOptions.ShowCaption = False
        GridColumnDescriptor25.HeaderImage = Nothing
        GridColumnDescriptor25.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor25.HeaderText = "Fecha Registro"
        GridColumnDescriptor25.MappingName = "fechaRegistro"
        GridColumnDescriptor25.Name = "fechaRegistro"
        GridColumnDescriptor25.SerializedImageArray = ""
        GridColumnDescriptor25.Width = 130
        GridColumnDescriptor26.HeaderImage = Nothing
        GridColumnDescriptor26.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor26.MappingName = "idPersona"
        GridColumnDescriptor26.Name = "idPersona"
        GridColumnDescriptor26.SerializedImageArray = ""
        GridColumnDescriptor27.HeaderImage = Nothing
        GridColumnDescriptor27.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor27.MappingName = "idCaja"
        GridColumnDescriptor27.Name = "idCaja"
        GridColumnDescriptor27.SerializedImageArray = ""
        GridColumnDescriptor28.HeaderImage = Nothing
        GridColumnDescriptor28.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor28.HeaderText = "Nombre "
        GridColumnDescriptor28.MappingName = "nombre"
        GridColumnDescriptor28.Name = "nombre"
        GridColumnDescriptor28.SerializedImageArray = ""
        GridColumnDescriptor28.Width = 350
        GridColumnDescriptor29.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridColumnDescriptor29.HeaderImage = Nothing
        GridColumnDescriptor29.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor29.MappingName = "DNI"
        GridColumnDescriptor29.Name = "DNI"
        GridColumnDescriptor29.SerializedImageArray = ""
        GridColumnDescriptor29.Width = 100
        GridColumnDescriptor30.HeaderImage = Nothing
        GridColumnDescriptor30.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor30.HeaderText = "Estado"
        GridColumnDescriptor30.MappingName = "estado"
        GridColumnDescriptor30.Name = "estado"
        GridColumnDescriptor30.SerializedImageArray = ""
        GridColumnDescriptor30.Width = 100
        Me.dgvReporteCaja.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor25, GridColumnDescriptor26, GridColumnDescriptor27, GridColumnDescriptor28, GridColumnDescriptor29, GridColumnDescriptor30})
        Me.dgvReporteCaja.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaRegistro"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombre"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DNI"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado")})
        Me.dgvReporteCaja.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvReporteCaja.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvReporteCaja.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvReporteCaja.Text = "GridGroupingControl1"
        Me.dgvReporteCaja.VersionInfo = "12.2400.0.20"
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel18.Controls.Add(Me.Button3)
        Me.Panel18.Controls.Add(Me.Button2)
        Me.Panel18.Controls.Add(Me.Button1)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel18.Location = New System.Drawing.Point(0, 37)
        Me.Panel18.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(867, 51)
        Me.Panel18.TabIndex = 414
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Corbel", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(240, 15)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 28)
        Me.Button3.TabIndex = 414
        Me.Button3.Text = "Actualizar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.OrangeRed
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Corbel", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(139, 15)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Cierre de Caja"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Corbel", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(8, 15)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 27)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Apertura de Caja"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmReporteCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(867, 393)
        Me.Controls.Add(Me.dgvReporteCaja)
        Me.Controls.Add(Me.Panel18)
        Me.Controls.Add(Me.Panel20)
        Me.Name = "frmReporteCaja"
        Me.ShowIcon = False
        Me.Text = "Reporte Caja"
        Me.Panel20.ResumeLayout(False)
        Me.Panel20.PerformLayout()
        CType(Me.dgvReporteCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel18.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Private WithEvents dgvReporteCaja As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As Button
End Class

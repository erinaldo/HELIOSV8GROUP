<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCVentaProductosAcumulado
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
        Me.dgPedidos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgPedidos
        '
        Me.dgPedidos.BackColor = System.Drawing.Color.Black
        Me.dgPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPedidos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgPedidos.FreezeCaption = False
        Me.dgPedidos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2010
        Me.dgPedidos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.dgPedidos.Location = New System.Drawing.Point(0, 0)
        Me.dgPedidos.Name = "dgPedidos"
        Me.dgPedidos.Office2010ScrollBarsColorScheme = Syncfusion.Windows.Forms.Office2010ColorScheme.Black
        Me.dgPedidos.Size = New System.Drawing.Size(1077, 364)
        Me.dgPedidos.TabIndex = 419
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Producto"
        GridColumnDescriptor1.MappingName = "Producto"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 279
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Afectacion"
        GridColumnDescriptor2.MappingName = "afectacion"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 80
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "cantidad"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 80
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "unidad"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 78
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "total"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 110
        Me.dgPedidos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5})
        Me.dgPedidos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("afectacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("total")})
        Me.dgPedidos.Text = "GridGroupingControl2"
        Me.dgPedidos.TopLevelGroupOptions.ShowSummaries = True
        Me.dgPedidos.VersionInfo = "12.4400.0.24"
        '
        'UCVentaProductosAcumulado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgPedidos)
        Me.Name = "UCVentaProductosAcumulado"
        Me.Size = New System.Drawing.Size(1077, 364)
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgPedidos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

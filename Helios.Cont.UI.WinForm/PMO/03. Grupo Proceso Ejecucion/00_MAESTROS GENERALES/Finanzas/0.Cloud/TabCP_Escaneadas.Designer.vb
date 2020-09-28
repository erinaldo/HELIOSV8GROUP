<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TabCP_Escaneadas
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GridEscan = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GridEscan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridEscan
        '
        Me.GridEscan.BackColor = System.Drawing.SystemColors.Window
        Me.GridEscan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEscan.FreezeCaption = False
        Me.GridEscan.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridEscan.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridEscan.Location = New System.Drawing.Point(0, 0)
        Me.GridEscan.Name = "GridEscan"
        Me.GridEscan.Size = New System.Drawing.Size(841, 383)
        Me.GridEscan.TabIndex = 0
        Me.GridEscan.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "nrodoc"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 143
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "importe"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 83
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "proveedor"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 196
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "siteproveedor"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 170
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Estado de validación"
        GridColumnDescriptor5.MappingName = "estado"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 139
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "fecha"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 93
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "unidad"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 101
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.MappingName = "fechacreacion"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 101
        Me.GridEscan.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        Me.GridEscan.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridEscan.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridEscan.Text = "GridGroupingControl1"
        Me.GridEscan.VersionInfo = "12.4400.0.24"
        '
        'TabCP_Escaneadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridEscan)
        Me.Name = "TabCP_Escaneadas"
        Me.Size = New System.Drawing.Size(841, 383)
        CType(Me.GridEscan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridEscan As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

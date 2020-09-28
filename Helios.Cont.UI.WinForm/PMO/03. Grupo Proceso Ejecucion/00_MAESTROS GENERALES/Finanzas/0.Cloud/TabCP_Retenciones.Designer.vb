<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TabCP_Retenciones
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
        Me.GridRetencion = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GridRetencion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridRetencion
        '
        Me.GridRetencion.BackColor = System.Drawing.SystemColors.Window
        Me.GridRetencion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridRetencion.FreezeCaption = False
        Me.GridRetencion.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridRetencion.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridRetencion.Location = New System.Drawing.Point(0, 0)
        Me.GridRetencion.Name = "GridRetencion"
        Me.GridRetencion.Size = New System.Drawing.Size(841, 383)
        Me.GridRetencion.TabIndex = 1
        Me.GridRetencion.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "nrodoc"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 143
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "motivo"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 203
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "estadoliberacion"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 107
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "retenidapor"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 125
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "fechaVcto"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 134
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "importe"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 83
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "unidad"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 155
        Me.GridRetencion.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        Me.GridRetencion.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridRetencion.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridRetencion.Text = "GridGroupingControl1"
        Me.GridRetencion.VersionInfo = "12.4400.0.24"
        '
        'TabCP_Retenciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridRetencion)
        Me.Name = "TabCP_Retenciones"
        Me.Size = New System.Drawing.Size(841, 383)
        CType(Me.GridRetencion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridRetencion As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

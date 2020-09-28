<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalSistemas
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
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.dgModulos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.AsegurableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dgModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AsegurableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgModulos
        '
        Me.dgModulos.BackColor = System.Drawing.SystemColors.Window
        Me.dgModulos.DataSource = Me.AsegurableBindingSource
        Me.dgModulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgModulos.FreezeCaption = False
        Me.dgModulos.Location = New System.Drawing.Point(0, 0)
        Me.dgModulos.Name = "dgModulos"
        Me.dgModulos.ShowRelationFields = Syncfusion.Grouping.ShowRelationFields.Hide
        Me.dgModulos.Size = New System.Drawing.Size(593, 397)
        Me.dgModulos.TabIndex = 0
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "ID"
        GridColumnDescriptor1.MappingName = "IDAsegurable"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 53
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Asegurable"
        GridColumnDescriptor2.MappingName = "Nombre"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 327
        GridColumnDescriptor3.AllowSort = False
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "Descripcion"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 0
        Me.dgModulos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.dgModulos.TableDescriptor.GroupedColumns.AddRange(New Syncfusion.Grouping.SortColumnDescriptor() {New Syncfusion.Grouping.SortColumnDescriptor("Descripcion", System.ComponentModel.ListSortDirection.Ascending)})
        Me.dgModulos.Text = "GridGroupingControl1"
        Me.dgModulos.VersionInfo = "12.4400.0.24"
        '
        'AsegurableBindingSource
        '
        Me.AsegurableBindingSource.DataSource = GetType(Helios.Seguridad.Business.Entity.Asegurable)
        '
        'frmModalSistemas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionFont = New System.Drawing.Font("Corbel", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(593, 397)
        Me.Controls.Add(Me.dgModulos)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModalSistemas"
        Me.ShowIcon = False
        Me.Text = "Seleccionar modulo"
        CType(Me.dgModulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AsegurableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgModulos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents AsegurableBindingSource As System.Windows.Forms.BindingSource
End Class

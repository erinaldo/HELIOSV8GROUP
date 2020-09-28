<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProdItems
    Inherits System.Windows.Forms.Form

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
        Me.lsvAlmacen = New System.Windows.Forms.ListView()
        Me.IdProducto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descipcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lsvAlmacen
        '
        Me.lsvAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvAlmacen.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IdProducto, Me.Descipcion})
        Me.lsvAlmacen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvAlmacen.FullRowSelect = True
        Me.lsvAlmacen.GridLines = True
        Me.lsvAlmacen.HideSelection = False
        Me.lsvAlmacen.Location = New System.Drawing.Point(0, 0)
        Me.lsvAlmacen.MultiSelect = False
        Me.lsvAlmacen.Name = "lsvAlmacen"
        Me.lsvAlmacen.Size = New System.Drawing.Size(276, 149)
        Me.lsvAlmacen.TabIndex = 290
        Me.lsvAlmacen.UseCompatibleStateImageBehavior = False
        Me.lsvAlmacen.View = System.Windows.Forms.View.Details
        '
        'IdProducto
        '
        Me.IdProducto.Text = "ID"
        Me.IdProducto.Width = 0
        '
        'Descipcion
        '
        Me.Descipcion.Text = "Descripcion"
        Me.Descipcion.Width = 270
        '
        'FrmProdItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(276, 149)
        Me.Controls.Add(Me.lsvAlmacen)
        Me.Name = "FrmProdItems"
        Me.Text = "FrmProdItems"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsvAlmacen As System.Windows.Forms.ListView
    Friend WithEvents IdProducto As System.Windows.Forms.ColumnHeader
    Friend WithEvents Descipcion As System.Windows.Forms.ColumnHeader
End Class

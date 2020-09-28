<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCHospedados
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ListInventario = New System.Windows.Forms.ListView()
        Me.ColID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColPrecio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCantMinima = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColImporteContado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColImporteCredito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ListInventario
        '
        Me.ListInventario.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ListInventario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListInventario.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColID, Me.ColPrecio, Me.ColCantMinima, Me.ColImporteContado, Me.ColImporteCredito})
        Me.ListInventario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListInventario.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListInventario.FullRowSelect = True
        Me.ListInventario.GridLines = True
        Me.ListInventario.Location = New System.Drawing.Point(0, 0)
        Me.ListInventario.Name = "ListInventario"
        Me.ListInventario.Size = New System.Drawing.Size(746, 180)
        Me.ListInventario.TabIndex = 1
        Me.ListInventario.UseCompatibleStateImageBehavior = False
        Me.ListInventario.View = System.Windows.Forms.View.Details
        '
        'ColID
        '
        Me.ColID.Text = "ID"
        Me.ColID.Width = 0
        '
        'ColPrecio
        '
        Me.ColPrecio.Text = "Nombre Completo"
        Me.ColPrecio.Width = 350
        '
        'ColCantMinima
        '
        Me.ColCantMinima.Text = "Nro. Documento"
        Me.ColCantMinima.Width = 115
        '
        'ColImporteContado
        '
        Me.ColImporteContado.Text = "Nacionalidad"
        Me.ColImporteContado.Width = 116
        '
        'ColImporteCredito
        '
        Me.ColImporteCredito.Text = "Sexo"
        Me.ColImporteCredito.Width = 119
        '
        'UCHospedados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListInventario)
        Me.Name = "UCHospedados"
        Me.Size = New System.Drawing.Size(746, 180)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListInventario As ListView
    Friend WithEvents ColID As ColumnHeader
    Friend WithEvents ColPrecio As ColumnHeader
    Friend WithEvents ColCantMinima As ColumnHeader
    Friend WithEvents ColImporteContado As ColumnHeader
    Friend WithEvents ColImporteCredito As ColumnHeader
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCPreciosCanastaVenta
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
        Me.ListInventario = New System.Windows.Forms.ListView()
        Me.ColID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColPrecio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCantMinima = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColImporteContado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColImporteCredito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColImporteContadoUSD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColImporteCreditoUSD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ListInventario
        '
        Me.ListInventario.BackColor = System.Drawing.Color.Black
        Me.ListInventario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListInventario.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColID, Me.ColPrecio, Me.ColCantMinima, Me.ColImporteContado, Me.ColImporteContadoUSD, Me.ColImporteCredito, Me.ColImporteCreditoUSD})
        Me.ListInventario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListInventario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListInventario.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ListInventario.FullRowSelect = True
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
        Me.ColPrecio.Text = "Descripción"
        Me.ColPrecio.Width = 234
        '
        'ColCantMinima
        '
        Me.ColCantMinima.Text = "Cant. miníma"
        Me.ColCantMinima.Width = 95
        '
        'ColImporteContado
        '
        Me.ColImporteContado.Text = "Precio contado"
        Me.ColImporteContado.Width = 99
        '
        'ColImporteCredito
        '
        Me.ColImporteCredito.DisplayIndex = 4
        Me.ColImporteCredito.Text = "Precio al credito"
        Me.ColImporteCredito.Width = 106
        '
        'ColImporteContadoUSD
        '
        Me.ColImporteContadoUSD.Text = "Contado US"
        Me.ColImporteContadoUSD.Width = 93
        '
        'ColImporteCreditoUSD
        '
        Me.ColImporteCreditoUSD.Text = "Prec. credito US"
        Me.ColImporteCreditoUSD.Width = 99
        '
        'UCPreciosCanastaVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListInventario)
        Me.Name = "UCPreciosCanastaVenta"
        Me.Size = New System.Drawing.Size(746, 180)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListInventario As ListView
    Friend WithEvents ColID As ColumnHeader
    Friend WithEvents ColPrecio As ColumnHeader
    Friend WithEvents ColCantMinima As ColumnHeader
    Friend WithEvents ColImporteContado As ColumnHeader
    Friend WithEvents ColImporteCredito As ColumnHeader
    Friend WithEvents ColImporteContadoUSD As ColumnHeader
    Friend WithEvents ColImporteCreditoUSD As ColumnHeader
End Class

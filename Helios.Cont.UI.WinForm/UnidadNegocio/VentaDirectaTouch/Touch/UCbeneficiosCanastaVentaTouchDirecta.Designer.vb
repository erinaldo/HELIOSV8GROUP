<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCbeneficiosCanastaVentaTouchDirecta
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
        Me.ColIDBen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColBen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColTipoBen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColAfecta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColValorEval = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColConve = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColResul = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ListInventario
        '
        Me.ListInventario.BackColor = System.Drawing.Color.Black
        Me.ListInventario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListInventario.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColIDBen, Me.ColBen, Me.ColTipoBen, Me.ColAfecta, Me.ColValorEval, Me.ColConve, Me.ColResul})
        Me.ListInventario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListInventario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListInventario.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ListInventario.FullRowSelect = True
        Me.ListInventario.HideSelection = False
        Me.ListInventario.Location = New System.Drawing.Point(0, 0)
        Me.ListInventario.Name = "ListInventario"
        Me.ListInventario.Size = New System.Drawing.Size(746, 180)
        Me.ListInventario.TabIndex = 1
        Me.ListInventario.UseCompatibleStateImageBehavior = False
        Me.ListInventario.View = System.Windows.Forms.View.Details
        '
        'ColIDBen
        '
        Me.ColIDBen.Text = "ID"
        Me.ColIDBen.Width = 0
        '
        'ColBen
        '
        Me.ColBen.Text = "BENEFICIO"
        Me.ColBen.Width = 234
        '
        'ColTipoBen
        '
        Me.ColTipoBen.Text = "TIPO"
        Me.ColTipoBen.Width = 95
        '
        'ColAfecta
        '
        Me.ColAfecta.Text = "AFECTACION"
        Me.ColAfecta.Width = 99
        '
        'ColValorEval
        '
        Me.ColValorEval.Text = "VALOR EVALUADO"
        Me.ColValorEval.Width = 93
        '
        'ColConve
        '
        Me.ColConve.Text = "CONVERSION"
        Me.ColConve.Width = 106
        '
        'ColResul
        '
        Me.ColResul.Text = "BENEFICIO FINAL"
        Me.ColResul.Width = 99
        '
        'UCbeneficiosCanastaVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListInventario)
        Me.Name = "UCbeneficiosCanastaVenta"
        Me.Size = New System.Drawing.Size(746, 180)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListInventario As ListView
    Friend WithEvents ColIDBen As ColumnHeader
    Friend WithEvents ColBen As ColumnHeader
    Friend WithEvents ColTipoBen As ColumnHeader
    Friend WithEvents ColAfecta As ColumnHeader
    Friend WithEvents ColConve As ColumnHeader
    Friend WithEvents ColValorEval As ColumnHeader
    Friend WithEvents ColResul As ColumnHeader

End Class

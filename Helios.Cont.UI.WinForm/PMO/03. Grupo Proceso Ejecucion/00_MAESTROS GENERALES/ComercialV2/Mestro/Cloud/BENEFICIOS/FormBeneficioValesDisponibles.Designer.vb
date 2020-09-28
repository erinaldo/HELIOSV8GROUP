Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBeneficioValesDisponibles
    Inherits MetroForm

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
        Me.LsvCupones = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDescripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColValor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColVigente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'LsvCupones
        '
        Me.LsvCupones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colDescripcion, Me.ColValor, Me.ColVigente})
        Me.LsvCupones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvCupones.FullRowSelect = True
        Me.LsvCupones.GridLines = True
        Me.LsvCupones.Location = New System.Drawing.Point(0, 0)
        Me.LsvCupones.Name = "LsvCupones"
        Me.LsvCupones.Size = New System.Drawing.Size(537, 295)
        Me.LsvCupones.TabIndex = 2
        Me.LsvCupones.UseCompatibleStateImageBehavior = False
        Me.LsvCupones.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 37
        '
        'colDescripcion
        '
        Me.colDescripcion.Text = "Cupon"
        Me.colDescripcion.Width = 304
        '
        'ColValor
        '
        Me.ColValor.Text = "Valor cupon"
        Me.ColValor.Width = 87
        '
        'ColVigente
        '
        Me.ColVigente.Text = "Vigencia"
        Me.ColVigente.Width = 102
        '
        'FormBeneficioValesDisponibles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 295)
        Me.Controls.Add(Me.LsvCupones)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBeneficioValesDisponibles"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LsvCupones As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colDescripcion As ColumnHeader
    Friend WithEvents ColValor As ColumnHeader
    Friend WithEvents ColVigente As ColumnHeader
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCanastaCompraDetalle
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Me.lsvCanasta = New System.Windows.Forms.ListView()
        Me.colSec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPres = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colValCompra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIGV = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImportemn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colValCompraME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIGVUS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImporteme = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lsvCanasta
        '
        Me.lsvCanasta.BackColor = System.Drawing.Color.White
        Me.lsvCanasta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSec, Me.colIdItem, Me.colItem, Me.colUM, Me.colPres, Me.colCantidad, Me.colValCompra, Me.colIGV, Me.colImportemn, Me.colValCompraME, Me.colIGVUS, Me.colImporteme})
        Me.lsvCanasta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvCanasta.FullRowSelect = True
        Me.lsvCanasta.GridLines = True
        Me.lsvCanasta.Location = New System.Drawing.Point(0, 0)
        Me.lsvCanasta.Name = "lsvCanasta"
        Me.lsvCanasta.Size = New System.Drawing.Size(798, 322)
        Me.lsvCanasta.TabIndex = 9
        Me.lsvCanasta.UseCompatibleStateImageBehavior = False
        Me.lsvCanasta.View = System.Windows.Forms.View.Details
        '
        'colSec
        '
        Me.colSec.Text = "Sec"
        Me.colSec.Width = 0
        '
        'colIdItem
        '
        Me.colIdItem.Text = "IDItem"
        Me.colIdItem.Width = 0
        '
        'colItem
        '
        Me.colItem.Text = "Descripción"
        Me.colItem.Width = 219
        '
        'colUM
        '
        Me.colUM.Text = "U.M."
        Me.colUM.Width = 47
        '
        'colPres
        '
        Me.colPres.Text = "Presentación"
        Me.colPres.Width = 84
        '
        'colCantidad
        '
        Me.colCantidad.Text = "Can"
        Me.colCantidad.Width = 54
        '
        'colValCompra
        '
        Me.colValCompra.Text = "VC."
        '
        'colIGV
        '
        Me.colIGV.Text = "IGV."
        '
        'colImportemn
        '
        Me.colImportemn.Text = "Total"
        Me.colImportemn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImportemn.Width = 69
        '
        'colValCompraME
        '
        Me.colValCompraME.Text = "V.C."
        '
        'colIGVUS
        '
        Me.colIGVUS.Text = "IGV."
        '
        'colImporteme
        '
        Me.colImporteme.Text = "Total"
        Me.colImporteme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImporteme.Width = 74
        '
        'frmCanastaCompraDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 322)
        Me.Controls.Add(Me.lsvCanasta)
        Me.Name = "frmCanastaCompraDetalle"
        Me.Text = "Detalle existencias"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsvCanasta As System.Windows.Forms.ListView
    Friend WithEvents colSec As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents colItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUM As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPres As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImportemn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImporteme As System.Windows.Forms.ColumnHeader
    Friend WithEvents colValCompra As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIGV As System.Windows.Forms.ColumnHeader
    Friend WithEvents colValCompraME As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIGVUS As System.Windows.Forms.ColumnHeader
End Class

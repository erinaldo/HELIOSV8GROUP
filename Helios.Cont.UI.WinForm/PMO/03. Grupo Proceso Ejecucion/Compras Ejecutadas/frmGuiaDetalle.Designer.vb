<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaDetalle
    Inherits Qios.DevSuite.Components.Ribbon.QRibbonForm

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
        Me.components = New System.ComponentModel.Container()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.lsvCanasta = New System.Windows.Forms.ListView()
        Me.colSec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPres = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImportemn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImporteme = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEstable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAnlmac = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(798, 28)
        Me.QRibbonCaption1.TabIndex = 0
        Me.QRibbonCaption1.Text = "Detalle de items distribuidos"
        '
        'lsvCanasta
        '
        Me.lsvCanasta.BackColor = System.Drawing.Color.LavenderBlush
        Me.lsvCanasta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSec, Me.colCantidad, Me.colIdItem, Me.colItem, Me.colUM, Me.colPres, Me.colImportemn, Me.colImporteme, Me.colEstable, Me.colAnlmac})
        Me.lsvCanasta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvCanasta.FullRowSelect = True
        Me.lsvCanasta.GridLines = True
        Me.lsvCanasta.Location = New System.Drawing.Point(0, 28)
        Me.lsvCanasta.Name = "lsvCanasta"
        Me.lsvCanasta.Size = New System.Drawing.Size(798, 294)
        Me.lsvCanasta.TabIndex = 11
        Me.lsvCanasta.UseCompatibleStateImageBehavior = False
        Me.lsvCanasta.View = System.Windows.Forms.View.Details
        '
        'colSec
        '
        Me.colSec.Text = "Sec"
        Me.colSec.Width = 0
        '
        'colCantidad
        '
        Me.colCantidad.Text = "Cant."
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
        'colImportemn
        '
        Me.colImportemn.Text = "Importe"
        Me.colImportemn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImportemn.Width = 100
        '
        'colImporteme
        '
        Me.colImporteme.Text = "Importe me."
        Me.colImporteme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImporteme.Width = 100
        '
        'colEstable
        '
        Me.colEstable.Text = "Establecimiento"
        Me.colEstable.Width = 95
        '
        'colAnlmac
        '
        Me.colAnlmac.Text = "Almacén"
        Me.colAnlmac.Width = 87
        '
        'frmGuiaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 322)
        Me.Controls.Add(Me.lsvCanasta)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaDetalle"
        Me.Text = "Detalle de items distribuidos"
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents lsvCanasta As System.Windows.Forms.ListView
    Friend WithEvents colSec As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents colItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUM As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPres As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImportemn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImporteme As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEstable As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAnlmac As System.Windows.Forms.ColumnHeader
End Class

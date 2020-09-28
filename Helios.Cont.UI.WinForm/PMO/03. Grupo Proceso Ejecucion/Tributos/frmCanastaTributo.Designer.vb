<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCanastaTributo
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
        Me.components = New System.ComponentModel.Container()
        Me.lsvCanasta = New System.Windows.Forms.ListView()
        Me.colSec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPres = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPorc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImportemn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImporteme = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.SuspendLayout()
        '
        'lsvCanasta
        '
        Me.lsvCanasta.BackColor = System.Drawing.Color.White
        Me.lsvCanasta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSec, Me.colIdItem, Me.colItem, Me.colUM, Me.colPres, Me.colPorc, Me.colImportemn, Me.colImporteme})
        Me.lsvCanasta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvCanasta.FullRowSelect = True
        Me.lsvCanasta.GridLines = True
        Me.lsvCanasta.Location = New System.Drawing.Point(0, 0)
        Me.lsvCanasta.Name = "lsvCanasta"
        Me.lsvCanasta.Size = New System.Drawing.Size(798, 322)
        Me.lsvCanasta.TabIndex = 10
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
        'colPorc
        '
        Me.colPorc.Text = "%"
        Me.colPorc.Width = 54
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
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'frmCanastaTributo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 322)
        Me.Controls.Add(Me.lsvCanasta)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCanastaTributo"
        Me.Text = "Detalle de items"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsvCanasta As System.Windows.Forms.ListView
    Friend WithEvents colSec As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents colItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUM As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPres As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPorc As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImportemn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImporteme As System.Windows.Forms.ColumnHeader
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
End Class

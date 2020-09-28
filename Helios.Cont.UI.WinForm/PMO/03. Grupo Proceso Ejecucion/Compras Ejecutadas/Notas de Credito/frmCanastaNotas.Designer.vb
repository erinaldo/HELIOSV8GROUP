<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCanastaNotas
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
        Me.lsvCanasta = New System.Windows.Forms.ListView()
        Me.colSec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPres = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImportemn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImporteme = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdAlmacen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdActividad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoEx = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNotaMn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNotaME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDebitoMN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNBMe = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTotalmn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTotalME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCanCredito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCantDebito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTotalCant = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lsvCanasta
        '
        Me.lsvCanasta.BackColor = System.Drawing.Color.LavenderBlush
        Me.lsvCanasta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSec, Me.colIdItem, Me.colItem, Me.colUM, Me.colPres, Me.colCantidad, Me.colImportemn, Me.colImporteme, Me.colIdAlmacen, Me.colIdActividad, Me.colTipoEx, Me.colNotaMn, Me.colNotaME, Me.colDebitoMN, Me.colNBMe, Me.colTotalmn, Me.colTotalME, Me.colCanCredito, Me.colCantDebito, Me.colTotalCant})
        Me.lsvCanasta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvCanasta.FullRowSelect = True
        Me.lsvCanasta.GridLines = True
        Me.lsvCanasta.Location = New System.Drawing.Point(0, 28)
        Me.lsvCanasta.Name = "lsvCanasta"
        Me.lsvCanasta.Size = New System.Drawing.Size(798, 294)
        Me.lsvCanasta.TabIndex = 6
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
        Me.colPres.Width = 70
        '
        'colCantidad
        '
        Me.colCantidad.Text = "Can"
        Me.colCantidad.Width = 54
        '
        'colImportemn
        '
        Me.colImportemn.Text = "Importe"
        Me.colImportemn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImportemn.Width = 0
        '
        'colImporteme
        '
        Me.colImporteme.Text = "Importe me."
        Me.colImporteme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImporteme.Width = 0
        '
        'colIdAlmacen
        '
        Me.colIdAlmacen.Text = "Almacen"
        Me.colIdAlmacen.Width = 0
        '
        'colIdActividad
        '
        Me.colIdActividad.Text = "Actividad"
        Me.colIdActividad.Width = 0
        '
        'colTipoEx
        '
        Me.colTipoEx.Text = "Tipo Ex"
        Me.colTipoEx.Width = 0
        '
        'colNotaMn
        '
        Me.colNotaMn.Text = "NC. mn."
        Me.colNotaMn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colNotaMn.Width = 0
        '
        'colNotaME
        '
        Me.colNotaME.Text = "NC me."
        Me.colNotaME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colNotaME.Width = 0
        '
        'colDebitoMN
        '
        Me.colDebitoMN.Text = "ND mn."
        Me.colDebitoMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colDebitoMN.Width = 0
        '
        'colNBMe
        '
        Me.colNBMe.Text = "ND me."
        Me.colNBMe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colNBMe.Width = 0
        '
        'colTotalmn
        '
        Me.colTotalmn.Text = "Total mn."
        Me.colTotalmn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotalmn.Width = 80
        '
        'colTotalME
        '
        Me.colTotalME.Text = "Total me."
        Me.colTotalME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotalME.Width = 78
        '
        'colCanCredito
        '
        Me.colCanCredito.Text = "NC cant."
        '
        'colCantDebito
        '
        Me.colCantDebito.Text = "ND cant."
        '
        'colTotalCant
        '
        Me.colTotalCant.Text = "Saldo cant."
        Me.colTotalCant.Width = 76
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(798, 28)
        Me.QRibbonCaption1.TabIndex = 7
        Me.QRibbonCaption1.Text = "Información del detalle de la compra."
        '
        'frmCanastaNotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 322)
        Me.Controls.Add(Me.lsvCanasta)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "frmCanastaNotas"
        Me.Text = "Información del detalle de la compra."
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents colIdAlmacen As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdActividad As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipoEx As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNotaMn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNotaME As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDebitoMN As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNBMe As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTotalmn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTotalME As System.Windows.Forms.ColumnHeader
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents colCanCredito As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCantDebito As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTotalCant As System.Windows.Forms.ColumnHeader
End Class

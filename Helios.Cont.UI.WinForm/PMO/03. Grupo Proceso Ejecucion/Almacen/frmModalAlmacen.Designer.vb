<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalAlmacen
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
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.lsvAlmacen = New System.Windows.Forms.ListView()
        Me.colIdAlmacen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAlmacen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEncargado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.lblEstado})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(417, 25)
        Me.ToolStrip3.TabIndex = 288
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.Black
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(124, 22)
        Me.lblEstado.Text = "Seleccionar. (doble click)"
        '
        'lsvAlmacen
        '
        Me.lsvAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvAlmacen.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIdAlmacen, Me.colAlmacen, Me.colEncargado})
        Me.lsvAlmacen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvAlmacen.FullRowSelect = True
        Me.lsvAlmacen.GridLines = True
        Me.lsvAlmacen.HideSelection = False
        Me.lsvAlmacen.Location = New System.Drawing.Point(0, 25)
        Me.lsvAlmacen.MultiSelect = False
        Me.lsvAlmacen.Name = "lsvAlmacen"
        Me.lsvAlmacen.Size = New System.Drawing.Size(417, 225)
        Me.lsvAlmacen.TabIndex = 289
        Me.lsvAlmacen.UseCompatibleStateImageBehavior = False
        Me.lsvAlmacen.View = System.Windows.Forms.View.Details
        '
        'colIdAlmacen
        '
        Me.colIdAlmacen.Width = 0
        '
        'colAlmacen
        '
        Me.colAlmacen.Text = "Almacén"
        Me.colAlmacen.Width = 270
        '
        'colEncargado
        '
        Me.colEncargado.Text = "Encargado"
        Me.colEncargado.Width = 145
        '
        'frmModalAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 250)
        Me.Controls.Add(Me.lsvAlmacen)
        Me.Controls.Add(Me.ToolStrip3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModalAlmacen"
        Me.Text = "Almacén"
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lsvAlmacen As System.Windows.Forms.ListView
    Friend WithEvents colIdAlmacen As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAlmacen As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEncargado As System.Windows.Forms.ColumnHeader
End Class

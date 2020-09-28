<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControlPreciosCompraVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControlPreciosCompraVenta))
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextStockTotal = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextProductoSel = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListInventario = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colprecUnit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.TextStockTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextProductoSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackgroundImage = CType(resources.GetObject("GradientPanel2.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel2.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel2.BorderSides = CType((System.Windows.Forms.Border3DSide.Top Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.TextStockTotal)
        Me.GradientPanel2.Controls.Add(Me.Label2)
        Me.GradientPanel2.Controls.Add(Me.TextProductoSel)
        Me.GradientPanel2.Controls.Add(Me.Label1)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(815, 33)
        Me.GradientPanel2.TabIndex = 2
        Me.GradientPanel2.Visible = False
        '
        'TextStockTotal
        '
        Me.TextStockTotal.BackColor = System.Drawing.Color.White
        Me.TextStockTotal.BeforeTouchSize = New System.Drawing.Size(317, 22)
        Me.TextStockTotal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextStockTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextStockTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextStockTotal.CornerRadius = 4
        Me.TextStockTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextStockTotal.FarImage = CType(resources.GetObject("TextStockTotal.FarImage"), System.Drawing.Image)
        Me.TextStockTotal.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextStockTotal.ForeColor = System.Drawing.Color.Black
        Me.TextStockTotal.Location = New System.Drawing.Point(492, 4)
        Me.TextStockTotal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextStockTotal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextStockTotal.Name = "TextStockTotal"
        Me.TextStockTotal.ReadOnly = True
        Me.TextStockTotal.Size = New System.Drawing.Size(81, 22)
        Me.TextStockTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextStockTotal.TabIndex = 403
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(453, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 402
        Me.Label2.Text = "Stock"
        '
        'TextProductoSel
        '
        Me.TextProductoSel.BackColor = System.Drawing.Color.White
        Me.TextProductoSel.BeforeTouchSize = New System.Drawing.Size(317, 22)
        Me.TextProductoSel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextProductoSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProductoSel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProductoSel.CornerRadius = 4
        Me.TextProductoSel.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextProductoSel.FarImage = CType(resources.GetObject("TextProductoSel.FarImage"), System.Drawing.Image)
        Me.TextProductoSel.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProductoSel.ForeColor = System.Drawing.Color.Black
        Me.TextProductoSel.Location = New System.Drawing.Point(130, 4)
        Me.TextProductoSel.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextProductoSel.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextProductoSel.Name = "TextProductoSel"
        Me.TextProductoSel.ReadOnly = True
        Me.TextProductoSel.Size = New System.Drawing.Size(317, 22)
        Me.TextProductoSel.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextProductoSel.TabIndex = 401
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Producto seleccionado"
        '
        'ListInventario
        '
        Me.ListInventario.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ListInventario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListInventario.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.colprecUnit, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.ListInventario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListInventario.FullRowSelect = True
        Me.ListInventario.GridLines = True
        Me.ListInventario.Location = New System.Drawing.Point(0, 33)
        Me.ListInventario.Name = "ListInventario"
        Me.ListInventario.Size = New System.Drawing.Size(815, 78)
        Me.ListInventario.TabIndex = 3
        Me.ListInventario.UseCompatibleStateImageBehavior = False
        Me.ListInventario.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Almacen"
        Me.ColumnHeader2.Width = 113
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Lote"
        Me.ColumnHeader3.Width = 97
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "LoteCode"
        Me.ColumnHeader4.Width = 70
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cantidad"
        Me.ColumnHeader5.Width = 63
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Fecha Compra"
        Me.ColumnHeader6.Width = 109
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Fec. Vcto."
        Me.ColumnHeader7.Width = 98
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Sustentado"
        Me.ColumnHeader8.Width = 106
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Ultimo precio"
        Me.ColumnHeader9.Width = 86
        '
        'colprecUnit
        '
        Me.colprecUnit.Text = "Prec.unitario"
        Me.colprecUnit.Width = 74
        '
        'UserControlPreciosCompraVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListInventario)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Name = "UserControlPreciosCompraVenta"
        Me.Size = New System.Drawing.Size(815, 111)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.TextStockTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextProductoSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents TextStockTotal As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents TextProductoSel As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents ListInventario As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents colprecUnit As ColumnHeader
End Class

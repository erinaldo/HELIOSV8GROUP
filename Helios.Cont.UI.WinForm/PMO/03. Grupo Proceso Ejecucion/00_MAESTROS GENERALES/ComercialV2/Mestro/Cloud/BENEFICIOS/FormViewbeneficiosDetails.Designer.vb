Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormViewbeneficiosDetails
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormViewbeneficiosDetails))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LsvProducts = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColAlmacen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btGrabar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LsvProducts)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(460, 180)
        Me.Panel1.TabIndex = 0
        '
        'LsvProducts
        '
        Me.LsvProducts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colItem, Me.ColCantidad, Me.ColAlmacen})
        Me.LsvProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProducts.FullRowSelect = True
        Me.LsvProducts.GridLines = True
        Me.LsvProducts.Location = New System.Drawing.Point(0, 0)
        Me.LsvProducts.Name = "LsvProducts"
        Me.LsvProducts.Size = New System.Drawing.Size(460, 180)
        Me.LsvProducts.TabIndex = 1
        Me.LsvProducts.UseCompatibleStateImageBehavior = False
        Me.LsvProducts.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 37
        '
        'colItem
        '
        Me.colItem.Text = "ITEM"
        Me.colItem.Width = 304
        '
        'ColCantidad
        '
        Me.ColCantidad.Text = "Cantidad"
        Me.ColCantidad.Width = 63
        '
        'ColAlmacen
        '
        Me.ColAlmacen.Text = "ALM"
        Me.ColAlmacen.Width = 50
        '
        'btGrabar
        '
        Me.btGrabar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btGrabar.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btGrabar.BeforeTouchSize = New System.Drawing.Size(117, 30)
        Me.btGrabar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGrabar.ForeColor = System.Drawing.Color.White
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btGrabar.IsBackStageButton = False
        Me.btGrabar.Location = New System.Drawing.Point(172, 186)
        Me.btGrabar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(117, 30)
        Me.btGrabar.TabIndex = 238
        Me.btGrabar.Text = "Confirmar"
        Me.btGrabar.UseVisualStyle = True
        '
        'FormViewbeneficiosDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(460, 219)
        Me.Controls.Add(Me.btGrabar)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormViewbeneficiosDetails"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.Text = "Detalle beneficios"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents LsvProducts As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colItem As ColumnHeader
    Friend WithEvents ColCantidad As ColumnHeader
    Friend WithEvents ColAlmacen As ColumnHeader
    Friend WithEvents btGrabar As ButtonAdv
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBuscarEntidades
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
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucBuscarEntidades))
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextLikeCliente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.TextLikeCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.GradientPanel3)
        Me.pcLikeCategoria.Controls.Add(Me.GradientPanel2)
        Me.pcLikeCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcLikeCategoria.Location = New System.Drawing.Point(0, 0)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(352, 194)
        Me.pcLikeCategoria.TabIndex = 834
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GradientPanel3.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.LsvProveedor)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 25)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(352, 169)
        Me.GradientPanel3.TabIndex = 3
        '
        'LsvProveedor
        '
        Me.LsvProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.LsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colCliente, Me.colRUC, Me.colTipoDoc})
        Me.LsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProveedor.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LsvProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LsvProveedor.FullRowSelect = True
        Me.LsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LsvProveedor.HideSelection = False
        Me.LsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.LsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.LsvProveedor.MultiSelect = False
        Me.LsvProveedor.Name = "LsvProveedor"
        Me.LsvProveedor.Size = New System.Drawing.Size(350, 167)
        Me.LsvProveedor.TabIndex = 1
        Me.LsvProveedor.UseCompatibleStateImageBehavior = False
        Me.LsvProveedor.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 219
        '
        'colRUC
        '
        Me.colRUC.Text = "RUC"
        Me.colRUC.Width = 90
        '
        'colTipoDoc
        '
        Me.colTipoDoc.Width = 0
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.TextLikeCliente)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(352, 25)
        Me.GradientPanel2.TabIndex = 2
        '
        'TextLikeCliente
        '
        Me.TextLikeCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        BannerTextInfo1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(0, Byte), Integer))
        BannerTextInfo1.Text = "Buscar cliente..."
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextLikeCliente, BannerTextInfo1)
        Me.TextLikeCliente.BeforeTouchSize = New System.Drawing.Size(350, 25)
        Me.TextLikeCliente.BorderColor = System.Drawing.Color.DimGray
        Me.TextLikeCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextLikeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextLikeCliente.CornerRadius = 4
        Me.TextLikeCliente.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextLikeCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextLikeCliente.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextLikeCliente.ForeColor = System.Drawing.Color.White
        Me.TextLikeCliente.Location = New System.Drawing.Point(0, 0)
        Me.TextLikeCliente.MaxLength = 10
        Me.TextLikeCliente.Metrocolor = System.Drawing.Color.LightGray
        Me.TextLikeCliente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextLikeCliente.Name = "TextLikeCliente"
        Me.TextLikeCliente.NearImage = CType(resources.GetObject("TextLikeCliente.NearImage"), System.Drawing.Image)
        Me.TextLikeCliente.Size = New System.Drawing.Size(350, 25)
        Me.TextLikeCliente.TabIndex = 829
        '
        'ucBuscarEntidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucBuscarEntidades"
        Me.Size = New System.Drawing.Size(352, 194)
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.TextLikeCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pcLikeCategoria As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents TextLikeCliente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
End Class

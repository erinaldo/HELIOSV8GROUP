<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucBuscarCategorias
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
        Me.components = New System.ComponentModel.Container()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LsvCategorias = New System.Windows.Forms.ListView()
        Me.idItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.descripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextLikeCliente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.TextLikeCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.GradientPanel3)
        Me.pcLikeCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcLikeCategoria.Location = New System.Drawing.Point(0, 25)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(469, 214)
        Me.pcLikeCategoria.TabIndex = 835
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GradientPanel3.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.LsvCategorias)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel3.Margin = New System.Windows.Forms.Padding(4)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(469, 214)
        Me.GradientPanel3.TabIndex = 3
        '
        'LsvCategorias
        '
        Me.LsvCategorias.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.LsvCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LsvCategorias.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idItem, Me.descripcion})
        Me.LsvCategorias.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LsvCategorias.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LsvCategorias.FullRowSelect = True
        Me.LsvCategorias.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LsvCategorias.HideSelection = False
        Me.LsvCategorias.Location = New System.Drawing.Point(0, 0)
        Me.LsvCategorias.Margin = New System.Windows.Forms.Padding(4)
        Me.LsvCategorias.MultiSelect = False
        Me.LsvCategorias.Name = "LsvCategorias"
        Me.LsvCategorias.Size = New System.Drawing.Size(467, 208)
        Me.LsvCategorias.TabIndex = 1
        Me.LsvCategorias.UseCompatibleStateImageBehavior = False
        Me.LsvCategorias.View = System.Windows.Forms.View.Details
        '
        'idItem
        '
        Me.idItem.Text = "ID"
        Me.idItem.Width = 0
        '
        'descripcion
        '
        Me.descripcion.Text = "Descripcion"
        Me.descripcion.Width = 219
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(271, 40)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(132, 22)
        Me.TextBox1.TabIndex = 836
        Me.TextBox1.Text = "0"
        Me.TextBox1.Visible = False
        '
        'TextLikeCliente
        '
        Me.TextLikeCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TextLikeCliente.BeforeTouchSize = New System.Drawing.Size(469, 25)
        Me.TextLikeCliente.BorderColor = System.Drawing.Color.DimGray
        Me.TextLikeCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextLikeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextLikeCliente.CornerRadius = 4
        Me.TextLikeCliente.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextLikeCliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextLikeCliente.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextLikeCliente.ForeColor = System.Drawing.Color.White
        Me.TextLikeCliente.Location = New System.Drawing.Point(0, 0)
        Me.TextLikeCliente.MaxLength = 10
        Me.TextLikeCliente.Metrocolor = System.Drawing.Color.LightGray
        Me.TextLikeCliente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextLikeCliente.Name = "TextLikeCliente"
        Me.TextLikeCliente.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.search
        Me.TextLikeCliente.Size = New System.Drawing.Size(469, 25)
        Me.TextLikeCliente.TabIndex = 837
        '
        'ucBuscarCategorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Controls.Add(Me.TextLikeCliente)
        Me.Controls.Add(Me.TextBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ucBuscarCategorias"
        Me.Size = New System.Drawing.Size(469, 239)
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.TextLikeCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents pcLikeCategoria As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents LsvCategorias As ListView
    Friend WithEvents idItem As ColumnHeader
    Friend WithEvents descripcion As ColumnHeader
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextLikeCliente As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class

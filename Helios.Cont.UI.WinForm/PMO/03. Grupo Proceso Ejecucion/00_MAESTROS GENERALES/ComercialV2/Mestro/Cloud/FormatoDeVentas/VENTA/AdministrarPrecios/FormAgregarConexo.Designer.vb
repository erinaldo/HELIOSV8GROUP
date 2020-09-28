Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAgregarConexo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAgregarConexo))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboUnidades = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textCantidad = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProducto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PopupProductos = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ListProductos = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.PictureLoadingProduct = New System.Windows.Forms.PictureBox()
        Me.TextFraccion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ComboUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupProductos.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.PictureLoadingProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFraccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 18)
        Me.Label4.TabIndex = 643
        Me.Label4.Text = "Agregar producto conexo"
        '
        'ComboUnidades
        '
        Me.ComboUnidades.AutoComplete = False
        Me.ComboUnidades.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ComboUnidades.BeforeTouchSize = New System.Drawing.Size(229, 21)
        Me.ComboUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUnidades.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboUnidades.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboUnidades.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ComboUnidades.Location = New System.Drawing.Point(19, 131)
        Me.ComboUnidades.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboUnidades.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboUnidades.Name = "ComboUnidades"
        Me.ComboUnidades.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.ComboUnidades.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.ComboUnidades.Size = New System.Drawing.Size(229, 21)
        Me.ComboUnidades.Style = Syncfusion.Windows.Forms.VisualStyle.VS2010
        Me.ComboUnidades.TabIndex = 673
        Me.ComboUnidades.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(16, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 671
        Me.Label1.Text = "Unidad Comercial"
        '
        'textCantidad
        '
        Me.textCantidad.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.textCantidad.BeforeTouchSize = New System.Drawing.Size(108, 27)
        Me.textCantidad.BorderColor = System.Drawing.Color.DimGray
        Me.textCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textCantidad.CornerRadius = 5
        Me.textCantidad.CurrencySymbol = ""
        Me.textCantidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textCantidad.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.textCantidad.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCantidad.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.textCantidad.Location = New System.Drawing.Point(254, 177)
        Me.textCantidad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.textCantidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textCantidad.Name = "textCantidad"
        Me.textCantidad.NullString = ""
        Me.textCantidad.PositiveColor = System.Drawing.Color.WhiteSmoke
        Me.textCantidad.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.textCantidad.Size = New System.Drawing.Size(108, 27)
        Me.textCantidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.textCantidad.TabIndex = 677
        Me.textCantidad.Text = "0.00"
        Me.textCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(255, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 676
        Me.Label3.Text = "Cantidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(16, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 678
        Me.Label5.Text = "Seleccionar producto"
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtProducto.BeforeTouchSize = New System.Drawing.Size(108, 27)
        Me.txtProducto.BorderColor = System.Drawing.Color.DimGray
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.CornerRadius = 4
        Me.txtProducto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProducto.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.White
        Me.txtProducto.Location = New System.Drawing.Point(15, 76)
        Me.txtProducto.Metrocolor = System.Drawing.Color.DimGray
        Me.txtProducto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.NearImage = CType(resources.GetObject("txtProducto.NearImage"), System.Drawing.Image)
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(347, 22)
        Me.txtProducto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProducto.TabIndex = 679
        '
        'PopupProductos
        '
        Me.PopupProductos.Controls.Add(Me.GradientPanel3)
        Me.PopupProductos.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupProductos.ForeColor = System.Drawing.Color.White
        Me.PopupProductos.Location = New System.Drawing.Point(491, 56)
        Me.PopupProductos.Name = "PopupProductos"
        Me.PopupProductos.Size = New System.Drawing.Size(562, 147)
        Me.PopupProductos.TabIndex = 680
        Me.PopupProductos.Visible = False
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.ListProductos)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(562, 147)
        Me.GradientPanel3.TabIndex = 0
        '
        'ListProductos
        '
        Me.ListProductos.BackColor = System.Drawing.Color.Black
        Me.ListProductos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListProductos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListProductos.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListProductos.ForeColor = System.Drawing.Color.White
        Me.ListProductos.FullRowSelect = True
        Me.ListProductos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListProductos.Location = New System.Drawing.Point(0, 0)
        Me.ListProductos.Name = "ListProductos"
        Me.ListProductos.Size = New System.Drawing.Size(560, 145)
        Me.ListProductos.TabIndex = 0
        Me.ListProductos.UseCompatibleStateImageBehavior = False
        Me.ListProductos.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = "ID"
        Me.ID.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Producto"
        Me.ColumnHeader1.Width = 289
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "U.M."
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Contenido"
        Me.ColumnHeader3.Width = 74
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Ultima compra"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Precio"
        Me.ColumnHeader5.Width = 91
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "GUARDAR"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(133, 226)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(129, 40)
        Me.BunifuThinButton21.TabIndex = 681
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureLoadingProduct
        '
        Me.PictureLoadingProduct.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoadingProduct.Image = CType(resources.GetObject("PictureLoadingProduct.Image"), System.Drawing.Image)
        Me.PictureLoadingProduct.Location = New System.Drawing.Point(340, 77)
        Me.PictureLoadingProduct.Name = "PictureLoadingProduct"
        Me.PictureLoadingProduct.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoadingProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoadingProduct.TabIndex = 682
        Me.PictureLoadingProduct.TabStop = False
        Me.PictureLoadingProduct.Visible = False
        '
        'TextFraccion
        '
        Me.TextFraccion.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextFraccion.BeforeTouchSize = New System.Drawing.Size(108, 27)
        Me.TextFraccion.BorderColor = System.Drawing.Color.DimGray
        Me.TextFraccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFraccion.CornerRadius = 5
        Me.TextFraccion.CurrencySymbol = ""
        Me.TextFraccion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextFraccion.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextFraccion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFraccion.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextFraccion.Location = New System.Drawing.Point(254, 125)
        Me.TextFraccion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextFraccion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextFraccion.Name = "TextFraccion"
        Me.TextFraccion.NullString = ""
        Me.TextFraccion.PositiveColor = System.Drawing.Color.WhiteSmoke
        Me.TextFraccion.ReadOnly = True
        Me.TextFraccion.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextFraccion.Size = New System.Drawing.Size(108, 27)
        Me.TextFraccion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextFraccion.TabIndex = 684
        Me.TextFraccion.Text = "0.00"
        Me.TextFraccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(255, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 683
        Me.Label2.Text = "Fraccion"
        '
        'FormAgregarConexo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(395, 271)
        Me.Controls.Add(Me.TextFraccion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureLoadingProduct)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.PopupProductos)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.textCantidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboUnidades)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAgregarConexo"
        Me.ShowIcon = False
        Me.Text = "Agregar item"
        CType(Me.ComboUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupProductos.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.PictureLoadingProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFraccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents ComboUnidades As Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents textCantidad As Tools.CurrencyTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtProducto As Tools.TextBoxExt
    Private WithEvents PopupProductos As PopupControlContainer
    Friend WithEvents GradientPanel3 As Tools.GradientPanel
    Friend WithEvents ListProductos As ListView
    Friend WithEvents ID As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents PictureLoadingProduct As PictureBox
    Friend WithEvents TextFraccion As Tools.CurrencyTextBox
    Friend WithEvents Label2 As Label
End Class

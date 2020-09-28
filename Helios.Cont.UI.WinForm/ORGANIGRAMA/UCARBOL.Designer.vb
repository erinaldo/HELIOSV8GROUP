<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCARBOL
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "Jiuni", "12345678"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCARBOL))
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnGuarTodo = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PopupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboBusqArb = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBusqueARBOL = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.btnNuevo = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.TrVOrganigrama = New System.Windows.Forms.TreeView()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.PopupControlContainer1.SuspendLayout()
        CType(Me.txtBusqueARBOL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.btnGuarTodo)
        Me.GradientPanel1.Controls.Add(Me.PopupControlContainer1)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.cboBusqArb)
        Me.GradientPanel1.Controls.Add(Me.Label6)
        Me.GradientPanel1.Controls.Add(Me.txtBusqueARBOL)
        Me.GradientPanel1.Controls.Add(Me.btnNuevo)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(795, 64)
        Me.GradientPanel1.TabIndex = 903
        '
        'btnGuarTodo
        '
        Me.btnGuarTodo.Activecolor = System.Drawing.Color.Green
        Me.btnGuarTodo.BackColor = System.Drawing.Color.Green
        Me.btnGuarTodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGuarTodo.BorderRadius = 5
        Me.btnGuarTodo.ButtonText = "BUSCAR"
        Me.btnGuarTodo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuarTodo.DisabledColor = System.Drawing.Color.Gray
        Me.btnGuarTodo.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuarTodo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnGuarTodo.Iconcolor = System.Drawing.Color.Transparent
        Me.btnGuarTodo.Iconimage = Nothing
        Me.btnGuarTodo.Iconimage_right = Nothing
        Me.btnGuarTodo.Iconimage_right_Selected = Nothing
        Me.btnGuarTodo.Iconimage_Selected = Nothing
        Me.btnGuarTodo.IconMarginLeft = 0
        Me.btnGuarTodo.IconMarginRight = 0
        Me.btnGuarTodo.IconRightVisible = True
        Me.btnGuarTodo.IconRightZoom = 0R
        Me.btnGuarTodo.IconVisible = True
        Me.btnGuarTodo.IconZoom = 90.0R
        Me.btnGuarTodo.IsTab = False
        Me.btnGuarTodo.Location = New System.Drawing.Point(597, 28)
        Me.btnGuarTodo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGuarTodo.Name = "btnGuarTodo"
        Me.btnGuarTodo.Normalcolor = System.Drawing.Color.Green
        Me.btnGuarTodo.OnHovercolor = System.Drawing.Color.Green
        Me.btnGuarTodo.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnGuarTodo.selected = False
        Me.btnGuarTodo.Size = New System.Drawing.Size(94, 22)
        Me.btnGuarTodo.TabIndex = 1021
        Me.btnGuarTodo.Text = "BUSCAR"
        Me.btnGuarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnGuarTodo.Textcolor = System.Drawing.Color.White
        Me.btnGuarTodo.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PopupControlContainer1
        '
        Me.PopupControlContainer1.Controls.Add(Me.ListView1)
        Me.PopupControlContainer1.Location = New System.Drawing.Point(210, 101)
        Me.PopupControlContainer1.Name = "PopupControlContainer1"
        Me.PopupControlContainer1.Size = New System.Drawing.Size(296, 163)
        Me.PopupControlContainer1.TabIndex = 955
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(296, 163)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "ID"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cliente"
        Me.ColumnHeader5.Width = 300
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "RUC"
        Me.ColumnHeader6.Width = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(245, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 17)
        Me.Label1.TabIndex = 954
        Me.Label1.Text = "Descripcion de la Organización"
        Me.Label1.Visible = False
        '
        'cboBusqArb
        '
        Me.cboBusqArb.BackColor = System.Drawing.Color.White
        Me.cboBusqArb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBusqArb.FormattingEnabled = True
        Me.cboBusqArb.Items.AddRange(New Object() {"TODO", "POR DESCRIPCION"})
        Me.cboBusqArb.Location = New System.Drawing.Point(18, 28)
        Me.cboBusqArb.Name = "cboBusqArb"
        Me.cboBusqArb.Size = New System.Drawing.Size(207, 21)
        Me.cboBusqArb.TabIndex = 953
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label6.Location = New System.Drawing.Point(26, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 17)
        Me.Label6.TabIndex = 952
        Me.Label6.Text = "Busqueda"
        '
        'txtBusqueARBOL
        '
        Me.txtBusqueARBOL.BackColor = System.Drawing.Color.White
        Me.txtBusqueARBOL.BeforeTouchSize = New System.Drawing.Size(266, 22)
        Me.txtBusqueARBOL.BorderColor = System.Drawing.Color.Silver
        Me.txtBusqueARBOL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBusqueARBOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqueARBOL.CornerRadius = 4
        Me.txtBusqueARBOL.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBusqueARBOL.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqueARBOL.Location = New System.Drawing.Point(231, 27)
        Me.txtBusqueARBOL.Metrocolor = System.Drawing.Color.Silver
        Me.txtBusqueARBOL.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBusqueARBOL.Name = "txtBusqueARBOL"
        Me.txtBusqueARBOL.NearImage = CType(resources.GetObject("txtBusqueARBOL.NearImage"), System.Drawing.Image)
        Me.txtBusqueARBOL.Size = New System.Drawing.Size(266, 22)
        Me.txtBusqueARBOL.TabIndex = 949
        Me.txtBusqueARBOL.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Activecolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevo.BorderRadius = 5
        Me.btnNuevo.ButtonText = "ACTUALIZAR"
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.DisabledColor = System.Drawing.Color.Gray
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnNuevo.Iconcolor = System.Drawing.Color.Transparent
        Me.btnNuevo.Iconimage = Nothing
        Me.btnNuevo.Iconimage_right = Nothing
        Me.btnNuevo.Iconimage_right_Selected = Nothing
        Me.btnNuevo.Iconimage_Selected = Nothing
        Me.btnNuevo.IconMarginLeft = 0
        Me.btnNuevo.IconMarginRight = 0
        Me.btnNuevo.IconRightVisible = True
        Me.btnNuevo.IconRightZoom = 0R
        Me.btnNuevo.IconVisible = True
        Me.btnNuevo.IconZoom = 90.0R
        Me.btnNuevo.IsTab = False
        Me.btnNuevo.Location = New System.Drawing.Point(695, 26)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnNuevo.selected = False
        Me.btnNuevo.Size = New System.Drawing.Size(90, 23)
        Me.btnNuevo.TabIndex = 948
        Me.btnNuevo.Text = "ACTUALIZAR"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNuevo.Textcolor = System.Drawing.Color.White
        Me.btnNuevo.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'TrVOrganigrama
        '
        Me.TrVOrganigrama.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrVOrganigrama.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrVOrganigrama.Location = New System.Drawing.Point(0, 64)
        Me.TrVOrganigrama.Name = "TrVOrganigrama"
        Me.TrVOrganigrama.Size = New System.Drawing.Size(795, 350)
        Me.TrVOrganigrama.TabIndex = 904
        '
        'UCARBOL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TrVOrganigrama)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "UCARBOL"
        Me.Size = New System.Drawing.Size(795, 414)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.PopupControlContainer1.ResumeLayout(False)
        CType(Me.txtBusqueARBOL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents TrVOrganigrama As TreeView
    Private WithEvents btnNuevo As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents txtBusqueARBOL As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents cboBusqArb As ComboBox
    Friend WithEvents Label6 As Label
    Private WithEvents PopupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Private WithEvents btnGuarTodo As Bunifu.Framework.UI.BunifuFlatButton
End Class

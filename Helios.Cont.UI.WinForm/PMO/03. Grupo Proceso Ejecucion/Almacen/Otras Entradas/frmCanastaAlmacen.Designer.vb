<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCanastaAlmacen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCanastaAlmacen))
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtBusqueda = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboExistencia = New Qios.DevSuite.Components.QComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAlmacenOrigen = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lsvExistencias = New System.Windows.Forms.ListView()
        Me.colEstableAlmacen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDestino = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProducto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPres = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImporteMN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImporteME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPMmn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colpmme = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip4.BackgroundImage = CType(resources.GetObject("ToolStrip4.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.lblDescripcion})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(724, 25)
        Me.ToolStrip4.TabIndex = 288
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Salir"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.Color.Black
        Me.lblDescripcion.Image = CType(resources.GetObject("lblDescripcion.Image"), System.Drawing.Image)
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(236, 22)
        Me.lblDescripcion.Text = "BUSQUEDA DE PRODUCTOS POR ALMACEN"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.txtBusqueda)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cboExistencia)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtAlmacenOrigen)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(724, 106)
        Me.Panel1.TabIndex = 291
        '
        'txtBusqueda
        '
        Me.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqueda.Location = New System.Drawing.Point(129, 79)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(261, 19)
        Me.txtBusqueda.TabIndex = 296
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 295
        Me.Label3.Text = "Buscar producto:"
        '
        'cboExistencia
        '
        Me.cboExistencia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboExistencia.Items.AddRange(New Object() {"MERCADERIA", "MATERIA PRIMA"})
        Me.cboExistencia.Location = New System.Drawing.Point(129, 52)
        Me.cboExistencia.Name = "cboExistencia"
        Me.cboExistencia.SelectedIndex = 0
        Me.cboExistencia.SelectedItem = "MERCADERIA"
        Me.cboExistencia.Size = New System.Drawing.Size(261, 19)
        Me.cboExistencia.TabIndex = 294
        Me.cboExistencia.Text = "MERCADERIA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 293
        Me.Label1.Text = "Tipo de existencia:"
        '
        'txtAlmacenOrigen
        '
        Me.txtAlmacenOrigen.Location = New System.Drawing.Point(129, 27)
        Me.txtAlmacenOrigen.Name = "txtAlmacenOrigen"
        Me.txtAlmacenOrigen.ReadOnly = True
        Me.txtAlmacenOrigen.Size = New System.Drawing.Size(261, 19)
        Me.txtAlmacenOrigen.TabIndex = 292
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 291
        Me.Label2.Text = "Almacén de origen:"
        '
        'lsvExistencias
        '
        Me.lsvExistencias.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colEstableAlmacen, Me.colDestino, Me.colIdItem, Me.colProducto, Me.colUM, Me.colPres, Me.colCantidad, Me.colImporteMN, Me.colImporteME, Me.colPMmn, Me.colpmme})
        Me.lsvExistencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvExistencias.FullRowSelect = True
        Me.lsvExistencias.HideSelection = False
        Me.lsvExistencias.Location = New System.Drawing.Point(0, 131)
        Me.lsvExistencias.Name = "lsvExistencias"
        Me.lsvExistencias.Size = New System.Drawing.Size(724, 266)
        Me.lsvExistencias.TabIndex = 292
        Me.lsvExistencias.UseCompatibleStateImageBehavior = False
        Me.lsvExistencias.View = System.Windows.Forms.View.Details
        '
        'colEstableAlmacen
        '
        Me.colEstableAlmacen.Text = "Estable"
        Me.colEstableAlmacen.Width = 0
        '
        'colDestino
        '
        Me.colDestino.Text = "Destino"
        Me.colDestino.Width = 19
        '
        'colProducto
        '
        Me.colProducto.Text = "Producto"
        Me.colProducto.Width = 233
        '
        'colUM
        '
        Me.colUM.Text = "U.M."
        Me.colUM.Width = 62
        '
        'colPres
        '
        Me.colPres.Text = "Presentación"
        Me.colPres.Width = 77
        '
        'colCantidad
        '
        Me.colCantidad.Text = "Cantidad"
        '
        'colImporteMN
        '
        Me.colImporteMN.Text = "Costo mn."
        Me.colImporteMN.Width = 80
        '
        'colImporteME
        '
        Me.colImporteME.Text = "Costo me."
        Me.colImporteME.Width = 68
        '
        'colPMmn
        '
        Me.colPMmn.Text = "PM mn."
        '
        'colpmme
        '
        Me.colpmme.Text = "PM me."
        '
        'colIdItem
        '
        Me.colIdItem.Text = "ItemID"
        Me.colIdItem.Width = 0
        '
        'frmCanastaAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 397)
        Me.Controls.Add(Me.lsvExistencias)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCanastaAlmacen"
        Me.Text = "frmCanastaAlmacen"
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacenOrigen As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboExistencia As Qios.DevSuite.Components.QComboBox
    Friend WithEvents lsvExistencias As System.Windows.Forms.ListView
    Friend WithEvents txtBusqueda As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents colProducto As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUM As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPres As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImporteMN As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImporteME As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPMmn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colpmme As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEstableAlmacen As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDestino As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdItem As System.Windows.Forms.ColumnHeader
End Class

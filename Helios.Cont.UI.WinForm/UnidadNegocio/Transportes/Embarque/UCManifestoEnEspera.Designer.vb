<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCManifestoEnEspera
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCManifestoEnEspera))
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ListProgramacionEmbarque = New System.Windows.Forms.ListView()
        Me.prog_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.bunifuFlatButton7 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.GroupBar1 = New Syncfusion.Windows.Forms.Tools.GroupBar()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ListEncomiendas = New System.Windows.Forms.ListView()
        Me.ColIDVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColIDRemitente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColRemitente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColOrigen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColIDConsig = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColConsignado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColDestino = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColContenido = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColImporte = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColEstadoPago = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListPasajeros = New System.Windows.Forms.ListView()
        Me.Asiento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBarItem1 = New Syncfusion.Windows.Forms.Tools.GroupBarItem()
        Me.GroupBarItem2 = New Syncfusion.Windows.Forms.Tools.GroupBarItem()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.GroupBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBar1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BorderColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel8.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.ListProgramacionEmbarque)
        Me.GradientPanel8.Controls.Add(Me.bunifuFlatButton7)
        Me.GradientPanel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.GradientPanel8.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(531, 468)
        Me.GradientPanel8.TabIndex = 595
        '
        'ListProgramacionEmbarque
        '
        Me.ListProgramacionEmbarque.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListProgramacionEmbarque.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListProgramacionEmbarque.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.prog_id, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.ListProgramacionEmbarque.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListProgramacionEmbarque.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListProgramacionEmbarque.FullRowSelect = True
        Me.ListProgramacionEmbarque.GridLines = True
        Me.ListProgramacionEmbarque.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListProgramacionEmbarque.HideSelection = False
        Me.ListProgramacionEmbarque.Location = New System.Drawing.Point(0, 0)
        Me.ListProgramacionEmbarque.Name = "ListProgramacionEmbarque"
        Me.ListProgramacionEmbarque.Size = New System.Drawing.Size(529, 466)
        Me.ListProgramacionEmbarque.TabIndex = 589
        Me.ListProgramacionEmbarque.UseCompatibleStateImageBehavior = False
        Me.ListProgramacionEmbarque.View = System.Windows.Forms.View.Details
        '
        'prog_id
        '
        Me.prog_id.Text = "ID"
        Me.prog_id.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Ruta"
        Me.ColumnHeader5.Width = 177
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Fecha y hora programada"
        Me.ColumnHeader6.Width = 139
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Nro. asientos"
        Me.ColumnHeader7.Width = 80
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Vendidos"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Reservados"
        Me.ColumnHeader9.Width = 70
        '
        'bunifuFlatButton7
        '
        Me.bunifuFlatButton7.Activecolor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.bunifuFlatButton7.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.bunifuFlatButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bunifuFlatButton7.BorderRadius = 0
        Me.bunifuFlatButton7.ButtonText = "VEHICULOS"
        Me.bunifuFlatButton7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bunifuFlatButton7.DisabledColor = System.Drawing.Color.Gray
        Me.bunifuFlatButton7.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bunifuFlatButton7.Iconcolor = System.Drawing.Color.Transparent
        Me.bunifuFlatButton7.Iconimage = Nothing
        Me.bunifuFlatButton7.Iconimage_right = Nothing
        Me.bunifuFlatButton7.Iconimage_right_Selected = Nothing
        Me.bunifuFlatButton7.Iconimage_Selected = Nothing
        Me.bunifuFlatButton7.IconMarginLeft = 0
        Me.bunifuFlatButton7.IconMarginRight = 0
        Me.bunifuFlatButton7.IconRightVisible = True
        Me.bunifuFlatButton7.IconRightZoom = 0R
        Me.bunifuFlatButton7.IconVisible = True
        Me.bunifuFlatButton7.IconZoom = 90.0R
        Me.bunifuFlatButton7.IsTab = False
        Me.bunifuFlatButton7.Location = New System.Drawing.Point(169, 42)
        Me.bunifuFlatButton7.Margin = New System.Windows.Forms.Padding(2)
        Me.bunifuFlatButton7.Name = "bunifuFlatButton7"
        Me.bunifuFlatButton7.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.bunifuFlatButton7.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.bunifuFlatButton7.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.bunifuFlatButton7.selected = False
        Me.bunifuFlatButton7.Size = New System.Drawing.Size(103, 18)
        Me.bunifuFlatButton7.TabIndex = 595
        Me.bunifuFlatButton7.Text = "VEHICULOS"
        Me.bunifuFlatButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.bunifuFlatButton7.Textcolor = System.Drawing.Color.White
        Me.bunifuFlatButton7.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'GroupBar1
        '
        Me.GroupBar1.AllowDrop = True
        Me.GroupBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.GroupBar1.BeforeTouchSize = New System.Drawing.Size(578, 468)
        Me.GroupBar1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.GroupBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GroupBar1.CollapseImage = CType(resources.GetObject("GroupBar1.CollapseImage"), System.Drawing.Image)
        Me.GroupBar1.Controls.Add(Me.Panel1)
        Me.GroupBar1.Controls.Add(Me.Panel2)
        Me.GroupBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBar1.ExpandButtonToolTip = Nothing
        Me.GroupBar1.ExpandImage = CType(resources.GetObject("GroupBar1.ExpandImage"), System.Drawing.Image)
        Me.GroupBar1.FlatLook = True
        Me.GroupBar1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.GroupBar1.GroupBarDropDownToolTip = Nothing
        Me.GroupBar1.GroupBarItems.AddRange(New Syncfusion.Windows.Forms.Tools.GroupBarItem() {Me.GroupBarItem1, Me.GroupBarItem2})
        Me.GroupBar1.IndexOnVisibleItems = True
        Me.GroupBar1.Location = New System.Drawing.Point(531, 0)
        Me.GroupBar1.MinimizeButtonToolTip = Nothing
        Me.GroupBar1.Name = "GroupBar1"
        Me.GroupBar1.NavigationPaneTooltip = Nothing
        Me.GroupBar1.Office2007Theme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.GroupBar1.PopupClientSize = New System.Drawing.Size(0, 0)
        Me.GroupBar1.SelectedItem = 0
        Me.GroupBar1.Size = New System.Drawing.Size(578, 468)
        Me.GroupBar1.TabIndex = 596
        Me.GroupBar1.Text = "GroupBar1"
        Me.GroupBar1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2010
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ListEncomiendas)
        Me.Panel2.Location = New System.Drawing.Point(1, 467)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(576, 1)
        Me.Panel2.TabIndex = 1
        '
        'ListEncomiendas
        '
        Me.ListEncomiendas.BackColor = System.Drawing.SystemColors.Window
        Me.ListEncomiendas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListEncomiendas.CheckBoxes = True
        Me.ListEncomiendas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColIDVenta, Me.ColIDRemitente, Me.ColRemitente, Me.ColOrigen, Me.ColIDConsig, Me.ColConsignado, Me.ColDestino, Me.ColContenido, Me.ColImporte, Me.ColEstadoPago})
        Me.ListEncomiendas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListEncomiendas.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListEncomiendas.FullRowSelect = True
        Me.ListEncomiendas.GridLines = True
        Me.ListEncomiendas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListEncomiendas.HideSelection = False
        Me.ListEncomiendas.Location = New System.Drawing.Point(0, 0)
        Me.ListEncomiendas.Name = "ListEncomiendas"
        Me.ListEncomiendas.Size = New System.Drawing.Size(576, 1)
        Me.ListEncomiendas.TabIndex = 591
        Me.ListEncomiendas.UseCompatibleStateImageBehavior = False
        Me.ListEncomiendas.View = System.Windows.Forms.View.Details
        '
        'ColIDVenta
        '
        Me.ColIDVenta.Text = "IDDocumento"
        Me.ColIDVenta.Width = 0
        '
        'ColIDRemitente
        '
        Me.ColIDRemitente.Text = "IDRemitente"
        Me.ColIDRemitente.Width = 14
        '
        'ColRemitente
        '
        Me.ColRemitente.Text = "Remitente"
        Me.ColRemitente.Width = 155
        '
        'ColOrigen
        '
        Me.ColOrigen.Text = "Ciudad origen"
        Me.ColOrigen.Width = 87
        '
        'ColIDConsig
        '
        Me.ColIDConsig.Text = "IDConsig"
        Me.ColIDConsig.Width = 10
        '
        'ColConsignado
        '
        Me.ColConsignado.Text = "Consignado"
        Me.ColConsignado.Width = 119
        '
        'ColDestino
        '
        Me.ColDestino.Text = "Destino"
        Me.ColDestino.Width = 99
        '
        'ColContenido
        '
        Me.ColContenido.Text = "Contenido"
        Me.ColContenido.Width = 91
        '
        'ColImporte
        '
        Me.ColImporte.Text = "Importe"
        '
        'ColEstadoPago
        '
        Me.ColEstadoPago.Text = "Pago"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.ListPasajeros)
        Me.Panel1.Location = New System.Drawing.Point(1, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 422)
        Me.Panel1.TabIndex = 0
        '
        'ListPasajeros
        '
        Me.ListPasajeros.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListPasajeros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListPasajeros.CheckBoxes = True
        Me.ListPasajeros.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Asiento, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListPasajeros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListPasajeros.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPasajeros.FullRowSelect = True
        Me.ListPasajeros.GridLines = True
        Me.ListPasajeros.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListPasajeros.HideSelection = False
        Me.ListPasajeros.Location = New System.Drawing.Point(0, 0)
        Me.ListPasajeros.Name = "ListPasajeros"
        Me.ListPasajeros.Size = New System.Drawing.Size(576, 422)
        Me.ListPasajeros.TabIndex = 590
        Me.ListPasajeros.UseCompatibleStateImageBehavior = False
        Me.ListPasajeros.View = System.Windows.Forms.View.Details
        '
        'Asiento
        '
        Me.Asiento.Text = "Asiento"
        Me.Asiento.Width = 51
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "IDPerson"
        Me.ColumnHeader12.Width = 0
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Apellidos y nombres"
        Me.ColumnHeader13.Width = 231
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "DNI"
        Me.ColumnHeader14.Width = 71
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Destino"
        Me.ColumnHeader15.Width = 94
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Nro.Venta"
        Me.ColumnHeader16.Width = 65
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Importe"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IDServ"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Servicio"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "IDVenta"
        '
        'GroupBarItem1
        '
        Me.GroupBarItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.GroupBarItem1.Client = Me.Panel1
        Me.GroupBarItem1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBarItem1.Text = "LISTA DE PASAJEROS"
        '
        'GroupBarItem2
        '
        Me.GroupBarItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.GroupBarItem2.Client = Me.Panel2
        Me.GroupBarItem2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBarItem2.Text = "ENCOMIENDAS"
        '
        'UCManifestoEnEspera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBar1)
        Me.Controls.Add(Me.GradientPanel8)
        Me.Name = "UCManifestoEnEspera"
        Me.Size = New System.Drawing.Size(1109, 468)
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        CType(Me.GroupBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBar1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel8 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ListProgramacionEmbarque As ListView
    Friend WithEvents prog_id As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Private WithEvents bunifuFlatButton7 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents GroupBar1 As Syncfusion.Windows.Forms.Tools.GroupBar
    Friend WithEvents GroupBarItem1 As Syncfusion.Windows.Forms.Tools.GroupBarItem
    Friend WithEvents GroupBarItem2 As Syncfusion.Windows.Forms.Tools.GroupBarItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListPasajeros As ListView
    Friend WithEvents Asiento As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ListEncomiendas As ListView
    Friend WithEvents ColIDVenta As ColumnHeader
    Friend WithEvents ColIDRemitente As ColumnHeader
    Friend WithEvents ColRemitente As ColumnHeader
    Friend WithEvents ColOrigen As ColumnHeader
    Friend WithEvents ColIDConsig As ColumnHeader
    Friend WithEvents ColConsignado As ColumnHeader
    Friend WithEvents ColDestino As ColumnHeader
    Friend WithEvents ColContenido As ColumnHeader
    Friend WithEvents ColImporte As ColumnHeader
    Friend WithEvents ColEstadoPago As ColumnHeader
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorialPagosMembresia
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistorialPagosMembresia))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDolares = New System.Windows.Forms.Label()
        Me.lblSoles = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lsvHistorial = New System.Windows.Forms.ListView()
        Me.colIdCompra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdProv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEntidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFechaCObr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMoneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCompro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoCambio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumOper = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMontoSoles = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMontoUSD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImporteITF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImporteITFme = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.ToolStrip4)
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(695, 52)
        Me.Panel1.TabIndex = 8
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.White
        Me.ToolStrip4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado, Me.lblIdDocumento, Me.ToolStripButton1})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(695, 25)
        Me.ToolStrip4.TabIndex = 1
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.Crimson
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(98, 22)
        Me.lblEstado.Text = "Gestión de pagos."
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblIdDocumento.ForeColor = System.Drawing.Color.Crimson
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(13, 22)
        Me.lblIdDocumento.Text = "0"
        Me.lblIdDocumento.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = CType(resources.GetObject("ToolStrip2.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.ImprimirToolStripButton, Me.toolStripSeparator})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(695, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Salir"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(123, 22)
        Me.ToolStripLabel1.Text = "HISTORIAL DE PAGOS"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AbrirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.pencil
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GuardarToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.cross
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(63, 22)
        Me.GuardarToolStripButton.Text = "Eliminar"
        '
        'ImprimirToolStripButton
        '
        Me.ImprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimirToolStripButton.Image = CType(resources.GetObject("ImprimirToolStripButton.Image"), System.Drawing.Image)
        Me.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton.Name = "ImprimirToolStripButton"
        Me.ImprimirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimirToolStripButton.Text = "&Imprimir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lblDolares)
        Me.Panel2.Controls.Add(Me.lblSoles)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 367)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(695, 25)
        Me.Panel2.TabIndex = 9
        '
        'lblDolares
        '
        Me.lblDolares.BackColor = System.Drawing.Color.Olive
        Me.lblDolares.Font = New System.Drawing.Font("Segoe UI", 8.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDolares.ForeColor = System.Drawing.Color.White
        Me.lblDolares.Location = New System.Drawing.Point(598, 0)
        Me.lblDolares.Name = "lblDolares"
        Me.lblDolares.Size = New System.Drawing.Size(96, 24)
        Me.lblDolares.TabIndex = 1
        Me.lblDolares.Text = "0.00"
        Me.lblDolares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSoles
        '
        Me.lblSoles.BackColor = System.Drawing.Color.SteelBlue
        Me.lblSoles.Font = New System.Drawing.Font("Segoe UI", 8.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoles.ForeColor = System.Drawing.Color.White
        Me.lblSoles.Location = New System.Drawing.Point(502, 0)
        Me.lblSoles.Name = "lblSoles"
        Me.lblSoles.Size = New System.Drawing.Size(96, 24)
        Me.lblSoles.TabIndex = 0
        Me.lblSoles.Text = "0.00"
        Me.lblSoles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lsvHistorial)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 52)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(695, 315)
        Me.Panel3.TabIndex = 10
        '
        'lsvHistorial
        '
        Me.lsvHistorial.BackColor = System.Drawing.Color.LavenderBlush
        Me.lsvHistorial.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIdCompra, Me.colIdProv, Me.colEntidad, Me.colFechaCObr, Me.colMoneda, Me.colTipoDoc, Me.colCompro, Me.colTipoCambio, Me.colNumOper, Me.colIdDoc, Me.colMontoSoles, Me.colMontoUSD, Me.colImporteITF, Me.colImporteITFme})
        Me.lsvHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvHistorial.FullRowSelect = True
        Me.lsvHistorial.GridLines = True
        Me.lsvHistorial.HideSelection = False
        Me.lsvHistorial.Location = New System.Drawing.Point(0, 0)
        Me.lsvHistorial.MultiSelect = False
        Me.lsvHistorial.Name = "lsvHistorial"
        Me.lsvHistorial.Size = New System.Drawing.Size(695, 315)
        Me.lsvHistorial.TabIndex = 0
        Me.lsvHistorial.UseCompatibleStateImageBehavior = False
        Me.lsvHistorial.View = System.Windows.Forms.View.Details
        '
        'colIdCompra
        '
        Me.colIdCompra.Text = "ID Compra"
        Me.colIdCompra.Width = 0
        '
        'colIdProv
        '
        Me.colIdProv.Text = "Id Entidad"
        Me.colIdProv.Width = 0
        '
        'colEntidad
        '
        Me.colEntidad.Text = "Entidad"
        Me.colEntidad.Width = 149
        '
        'colFechaCObr
        '
        Me.colFechaCObr.Text = "Fecha cobro"
        Me.colFechaCObr.Width = 143
        '
        'colMoneda
        '
        Me.colMoneda.Text = "Moneda"
        Me.colMoneda.Width = 25
        '
        'colTipoDoc
        '
        Me.colTipoDoc.Text = "TipoDoc"
        Me.colTipoDoc.Width = 0
        '
        'colCompro
        '
        Me.colCompro.Text = "Comprobante"
        Me.colCompro.Width = 98
        '
        'colTipoCambio
        '
        Me.colTipoCambio.Text = "t/c."
        Me.colTipoCambio.Width = 43
        '
        'colNumOper
        '
        Me.colNumOper.Text = "Número oper."
        Me.colNumOper.Width = 89
        '
        'colIdDoc
        '
        Me.colIdDoc.Text = "IdDocumento"
        Me.colIdDoc.Width = 0
        '
        'colMontoSoles
        '
        Me.colMontoSoles.Text = "Importe s/."
        Me.colMontoSoles.Width = 74
        '
        'colMontoUSD
        '
        Me.colMontoUSD.Text = "Importe me."
        Me.colMontoUSD.Width = 71
        '
        'colImporteITF
        '
        Me.colImporteITF.Text = "I.T.F. m.n."
        '
        'colImporteITFme
        '
        Me.colImporteITFme.Text = "I.T.F. m.e."
        '
        'frmHistorialPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 392)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmHistorialPagos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblDolares As System.Windows.Forms.Label
    Friend WithEvents lblSoles As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lsvHistorial As System.Windows.Forms.ListView
    Friend WithEvents colIdCompra As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEntidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFechaCObr As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipoDoc As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCompro As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipoCambio As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNumOper As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdDoc As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMontoSoles As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMontoUSD As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImporteITF As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImporteITFme As System.Windows.Forms.ColumnHeader
End Class

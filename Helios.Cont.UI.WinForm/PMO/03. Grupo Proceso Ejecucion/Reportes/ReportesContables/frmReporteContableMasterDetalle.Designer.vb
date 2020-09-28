<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteContableMasterDetalle
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.dgvMovimientoDetalle = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHaberT = New System.Windows.Forms.TextBox()
        Me.txtDebeT = New System.Windows.Forms.TextBox()
        Me.txtDebeS = New System.Windows.Forms.TextBox()
        Me.txtHaberS = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDebeSUSD = New System.Windows.Forms.TextBox()
        Me.txtHaberSUSD = New System.Windows.Forms.TextBox()
        Me.txtDebeTUSD = New System.Windows.Forms.TextBox()
        Me.txtHaberTUSD = New System.Windows.Forms.TextBox()
        Me.idDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.origen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.razonSocial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nroDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.debe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.haber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.debeUSD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.haberUSD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMovimientoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.BackgroundImageAlign = Qios.DevSuite.Components.QImageAlign.RepeatedVertical
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(961, 28)
        Me.QRibbonCaption1.TabIndex = 3
        Me.QRibbonCaption1.Text = "Reporte Contable - Detalle"
        '
        'txtCuenta
        '
        Me.txtCuenta.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtCuenta.Location = New System.Drawing.Point(0, 28)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(961, 20)
        Me.txtCuenta.TabIndex = 4
        '
        'dgvMovimientoDetalle
        '
        Me.dgvMovimientoDetalle.AllowUserToAddRows = False
        Me.dgvMovimientoDetalle.AllowUserToDeleteRows = False
        Me.dgvMovimientoDetalle.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovimientoDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMovimientoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimientoDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idDocumento, Me.origen, Me.fecha, Me.razonSocial, Me.descripcion, Me.nroDoc, Me.debe, Me.haber, Me.debeUSD, Me.haberUSD})
        Me.dgvMovimientoDetalle.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvMovimientoDetalle.Location = New System.Drawing.Point(0, 48)
        Me.dgvMovimientoDetalle.Name = "dgvMovimientoDetalle"
        Me.dgvMovimientoDetalle.ReadOnly = True
        DataGridViewCellStyle6.NullValue = Nothing
        Me.dgvMovimientoDetalle.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvMovimientoDetalle.Size = New System.Drawing.Size(961, 336)
        Me.dgvMovimientoDetalle.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(615, 393)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "TOTALES:"
        '
        'txtHaberT
        '
        Me.txtHaberT.BackColor = System.Drawing.Color.Red
        Me.txtHaberT.ForeColor = System.Drawing.SystemColors.Window
        Me.txtHaberT.Location = New System.Drawing.Point(749, 390)
        Me.txtHaberT.Name = "txtHaberT"
        Me.txtHaberT.Size = New System.Drawing.Size(63, 20)
        Me.txtHaberT.TabIndex = 7
        Me.txtHaberT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebeT
        '
        Me.txtDebeT.BackColor = System.Drawing.Color.Red
        Me.txtDebeT.ForeColor = System.Drawing.SystemColors.Window
        Me.txtDebeT.Location = New System.Drawing.Point(680, 390)
        Me.txtDebeT.Name = "txtDebeT"
        Me.txtDebeT.Size = New System.Drawing.Size(67, 20)
        Me.txtDebeT.TabIndex = 8
        Me.txtDebeT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebeS
        '
        Me.txtDebeS.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDebeS.Location = New System.Drawing.Point(680, 414)
        Me.txtDebeS.Name = "txtDebeS"
        Me.txtDebeS.Size = New System.Drawing.Size(67, 20)
        Me.txtDebeS.TabIndex = 10
        Me.txtDebeS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHaberS
        '
        Me.txtHaberS.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtHaberS.Location = New System.Drawing.Point(749, 414)
        Me.txtHaberS.Name = "txtHaberS"
        Me.txtHaberS.Size = New System.Drawing.Size(63, 20)
        Me.txtHaberS.TabIndex = 9
        Me.txtHaberS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(621, 417)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "SALDOS:"
        '
        'txtDebeSUSD
        '
        Me.txtDebeSUSD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDebeSUSD.Location = New System.Drawing.Point(815, 414)
        Me.txtDebeSUSD.Name = "txtDebeSUSD"
        Me.txtDebeSUSD.Size = New System.Drawing.Size(67, 20)
        Me.txtDebeSUSD.TabIndex = 15
        Me.txtDebeSUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHaberSUSD
        '
        Me.txtHaberSUSD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtHaberSUSD.Location = New System.Drawing.Point(884, 414)
        Me.txtHaberSUSD.Name = "txtHaberSUSD"
        Me.txtHaberSUSD.Size = New System.Drawing.Size(77, 20)
        Me.txtHaberSUSD.TabIndex = 14
        Me.txtHaberSUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebeTUSD
        '
        Me.txtDebeTUSD.BackColor = System.Drawing.Color.Red
        Me.txtDebeTUSD.ForeColor = System.Drawing.SystemColors.Window
        Me.txtDebeTUSD.Location = New System.Drawing.Point(815, 390)
        Me.txtDebeTUSD.Name = "txtDebeTUSD"
        Me.txtDebeTUSD.Size = New System.Drawing.Size(67, 20)
        Me.txtDebeTUSD.TabIndex = 13
        Me.txtDebeTUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHaberTUSD
        '
        Me.txtHaberTUSD.BackColor = System.Drawing.Color.Red
        Me.txtHaberTUSD.ForeColor = System.Drawing.SystemColors.Window
        Me.txtHaberTUSD.Location = New System.Drawing.Point(884, 390)
        Me.txtHaberTUSD.Name = "txtHaberTUSD"
        Me.txtHaberTUSD.Size = New System.Drawing.Size(77, 20)
        Me.txtHaberTUSD.TabIndex = 12
        Me.txtHaberTUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'idDocumento
        '
        Me.idDocumento.FillWeight = 5.0!
        Me.idDocumento.HeaderText = "ID"
        Me.idDocumento.Name = "idDocumento"
        Me.idDocumento.ReadOnly = True
        Me.idDocumento.Width = 5
        '
        'origen
        '
        Me.origen.HeaderText = "Origen"
        Me.origen.Name = "origen"
        Me.origen.ReadOnly = True
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Width = 80
        '
        'razonSocial
        '
        Me.razonSocial.HeaderText = "Razón Social"
        Me.razonSocial.Name = "razonSocial"
        Me.razonSocial.ReadOnly = True
        Me.razonSocial.Width = 200
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 170
        '
        'nroDoc
        '
        Me.nroDoc.HeaderText = "#"
        Me.nroDoc.Name = "nroDoc"
        Me.nroDoc.ReadOnly = True
        Me.nroDoc.Width = 80
        '
        'debe
        '
        DataGridViewCellStyle2.Format = "N2"
        Me.debe.DefaultCellStyle = DataGridViewCellStyle2
        Me.debe.HeaderText = "Debe"
        Me.debe.Name = "debe"
        Me.debe.ReadOnly = True
        Me.debe.Width = 70
        '
        'haber
        '
        DataGridViewCellStyle3.Format = "N2"
        Me.haber.DefaultCellStyle = DataGridViewCellStyle3
        Me.haber.HeaderText = "Haber"
        Me.haber.Name = "haber"
        Me.haber.ReadOnly = True
        Me.haber.Width = 70
        '
        'debeUSD
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.Format = "N2"
        Me.debeUSD.DefaultCellStyle = DataGridViewCellStyle4
        Me.debeUSD.HeaderText = "Debe USD"
        Me.debeUSD.Name = "debeUSD"
        Me.debeUSD.ReadOnly = True
        Me.debeUSD.Width = 70
        '
        'haberUSD
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Format = "N2"
        Me.haberUSD.DefaultCellStyle = DataGridViewCellStyle5
        Me.haberUSD.HeaderText = "Haber USD"
        Me.haberUSD.Name = "haberUSD"
        Me.haberUSD.ReadOnly = True
        Me.haberUSD.Width = 70
        '
        'frmReporteContableMasterDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 439)
        Me.Controls.Add(Me.txtDebeSUSD)
        Me.Controls.Add(Me.txtHaberSUSD)
        Me.Controls.Add(Me.txtDebeTUSD)
        Me.Controls.Add(Me.txtHaberTUSD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDebeS)
        Me.Controls.Add(Me.txtHaberS)
        Me.Controls.Add(Me.txtDebeT)
        Me.Controls.Add(Me.txtHaberT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvMovimientoDetalle)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "frmReporteContableMasterDetalle"
        Me.Text = "Reporte Contable - Detalle"
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMovimientoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents dgvMovimientoDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHaberT As System.Windows.Forms.TextBox
    Friend WithEvents txtDebeT As System.Windows.Forms.TextBox
    Friend WithEvents txtDebeS As System.Windows.Forms.TextBox
    Friend WithEvents txtHaberS As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDebeSUSD As System.Windows.Forms.TextBox
    Friend WithEvents txtHaberSUSD As System.Windows.Forms.TextBox
    Friend WithEvents txtDebeTUSD As System.Windows.Forms.TextBox
    Friend WithEvents txtHaberTUSD As System.Windows.Forms.TextBox
    Friend WithEvents idDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents origen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents razonSocial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nroDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents debe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents haber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents debeUSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents haberUSD As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

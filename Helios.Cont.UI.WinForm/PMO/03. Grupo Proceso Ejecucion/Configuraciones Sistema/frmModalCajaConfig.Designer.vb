<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalCajaConfig
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
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtEstablecimiento = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.lsvCajas = New System.Windows.Forms.ListView()
        Me.colIdCaja = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colDescripcion = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.cTipo = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colMoneda = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colCuenta = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.QRibbonInputBox1 = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboMoneda = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboTipo = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.QRibbonCaption1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        CType(Me.cboMoneda,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cboTipo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(443, 28)
        Me.QRibbonCaption1.TabIndex = 0
        Me.QRibbonCaption1.Text = "Búscar entidad financiera"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(24, 71)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(99, 20)
        Me.KryptonLabel2.TabIndex = 3
        Me.KryptonLabel2.Values.Text = "Establecimiento:"
        '
        'txtEstablecimiento
        '
        Me.txtEstablecimiento.Location = New System.Drawing.Point(125, 71)
        Me.txtEstablecimiento.Name = "txtEstablecimiento"
        Me.txtEstablecimiento.ReadOnly = true
        Me.txtEstablecimiento.Size = New System.Drawing.Size(264, 19)
        Me.txtEstablecimiento.TabIndex = 4
        '
        'lsvCajas
        '
        Me.lsvCajas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIdCaja, Me.colDescripcion, Me.cTipo, Me.colMoneda, Me.colCuenta})
        Me.lsvCajas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lsvCajas.FullRowSelect = True
        Me.lsvCajas.HideSelection = False
        Me.lsvCajas.Location = New System.Drawing.Point(0, 125)
        Me.lsvCajas.MultiSelect = False
        Me.lsvCajas.Name = "lsvCajas"
        Me.lsvCajas.Size = New System.Drawing.Size(443, 169)
        Me.lsvCajas.TabIndex = 5
        Me.lsvCajas.UseCompatibleStateImageBehavior = False
        Me.lsvCajas.View = System.Windows.Forms.View.Details
        '
        'colIdCaja
        '
        Me.colIdCaja.Text = "ID"
        Me.colIdCaja.Width = 0
        '
        'colDescripcion
        '
        Me.colDescripcion.Text = "Descripción"
        Me.colDescripcion.Width = 324
        '
        'cTipo
        '
        Me.cTipo.Text = "Tipo"
        Me.cTipo.Width = 0
        '
        'colMoneda
        '
        Me.colMoneda.Text = "Moneda"
        Me.colMoneda.Width = 21
        '
        'colCuenta
        '
        Me.colCuenta.Text = "Cta contable"
        Me.colCuenta.Width = 74
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = true
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(395, 74)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(44, 13)
        Me.LinkLabel1.TabIndex = 6
        Me.LinkLabel1.TabStop = true
        Me.LinkLabel1.Text = "cambiar"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(8, 94)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(117, 20)
        Me.KryptonLabel3.TabIndex = 7
        Me.KryptonLabel3.Values.Text = "Buscar por nombre:"
        '
        'QRibbonInputBox1
        '
        Me.QRibbonInputBox1.Location = New System.Drawing.Point(125, 94)
        Me.QRibbonInputBox1.Name = "QRibbonInputBox1"
        Me.QRibbonInputBox1.Size = New System.Drawing.Size(264, 19)
        Me.QRibbonInputBox1.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.Panel1.Controls.Add(Me.cboMoneda)
        Me.Panel1.Controls.Add(Me.KryptonLabel4)
        Me.Panel1.Controls.Add(Me.cboTipo)
        Me.Panel1.Controls.Add(Me.KryptonLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(443, 31)
        Me.Panel1.TabIndex = 11
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.DropDownWidth = 195
        Me.cboMoneda.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Ribbon
        Me.cboMoneda.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERA"})
        Me.cboMoneda.Location = New System.Drawing.Point(275, 5)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue
        Me.cboMoneda.Size = New System.Drawing.Size(114, 21)
        Me.cboMoneda.TabIndex = 14
        Me.cboMoneda.Text = "NACIONAL"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(215, 6)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(59, 20)
        Me.KryptonLabel4.TabIndex = 13
        Me.KryptonLabel4.Values.Text = "Moneda:"
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.DropDownWidth = 195
        Me.cboTipo.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Ribbon
        Me.cboTipo.Items.AddRange(New Object() {"EFECTIVO", "BANCO"})
        Me.cboTipo.Location = New System.Drawing.Point(99, 5)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue
        Me.cboTipo.Size = New System.Drawing.Size(114, 21)
        Me.cboTipo.TabIndex = 12
        Me.cboTipo.Text = "EFECTIVO"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(39, 7)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(58, 20)
        Me.KryptonLabel1.TabIndex = 11
        Me.KryptonLabel1.Values.Text = "Tipo E.F.:"
        '
        'frmModalCajaConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 294)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.QRibbonInputBox1)
        Me.Controls.Add(Me.KryptonLabel3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.lsvCajas)
        Me.Controls.Add(Me.txtEstablecimiento)
        Me.Controls.Add(Me.KryptonLabel2)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Font = New System.Drawing.Font("Tahoma", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmModalCajaConfig"
        Me.Text = "Búscar entidad financiera"
        CType(Me.QRibbonCaption1,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me.cboMoneda,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboTipo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtEstablecimiento As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents lsvCajas As System.Windows.Forms.ListView
    Friend WithEvents colIdCaja As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents cTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCuenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents QRibbonInputBox1 As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents colMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboMoneda As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboTipo As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class

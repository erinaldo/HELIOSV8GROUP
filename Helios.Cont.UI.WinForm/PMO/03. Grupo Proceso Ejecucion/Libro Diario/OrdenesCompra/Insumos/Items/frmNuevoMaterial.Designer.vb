<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoMaterial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoMaterial))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbAfecta = New System.Windows.Forms.RadioButton()
        Me.rbnoAfecta = New System.Windows.Forms.RadioButton()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.txtExistenciaID = New System.Windows.Forms.TextBox()
        Me.txtExistencia = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPresenID = New System.Windows.Forms.TextBox()
        Me.txtPresen = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtumID = New System.Windows.Forms.TextBox()
        Me.txtum = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtClasifID = New System.Windows.Forms.TextBox()
        Me.txtClasif = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.QRibbonApplicationButton1 = New Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.txtCodigo = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtDescripcion = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtCuentaID = New Femiani.Forms.UI.Input.CoolTextBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbAfecta)
        Me.GroupBox1.Controls.Add(Me.rbnoAfecta)
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.GroupBox1.Location = New System.Drawing.Point(102, 259)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(332, 81)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Origen Destino:"
        '
        'rbAfecta
        '
        Me.rbAfecta.AutoSize = True
        Me.rbAfecta.Checked = True
        Me.rbAfecta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rbAfecta.Location = New System.Drawing.Point(17, 26)
        Me.rbAfecta.Name = "rbAfecta"
        Me.rbAfecta.Size = New System.Drawing.Size(116, 17)
        Me.rbAfecta.TabIndex = 1
        Me.rbAfecta.TabStop = True
        Me.rbAfecta.Text = "1 - Afecto al I.G.V."
        Me.rbAfecta.UseVisualStyleBackColor = True
        '
        'rbnoAfecta
        '
        Me.rbnoAfecta.AutoSize = True
        Me.rbnoAfecta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rbnoAfecta.Location = New System.Drawing.Point(17, 49)
        Me.rbnoAfecta.Name = "rbnoAfecta"
        Me.rbnoAfecta.Size = New System.Drawing.Size(132, 17)
        Me.rbnoAfecta.TabIndex = 0
        Me.rbnoAfecta.Text = "2 - No Afecto al I.G.V."
        Me.rbnoAfecta.UseVisualStyleBackColor = True
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel5.LinkColor = System.Drawing.Color.DarkMagenta
        Me.LinkLabel5.Location = New System.Drawing.Point(440, 132)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel5.TabIndex = 41
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Cambiar"
        '
        'txtExistenciaID
        '
        Me.txtExistenciaID.BackColor = System.Drawing.Color.Plum
        Me.txtExistenciaID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtExistenciaID.Location = New System.Drawing.Point(399, 127)
        Me.txtExistenciaID.Multiline = True
        Me.txtExistenciaID.Name = "txtExistenciaID"
        Me.txtExistenciaID.ReadOnly = True
        Me.txtExistenciaID.Size = New System.Drawing.Size(35, 21)
        Me.txtExistenciaID.TabIndex = 40
        Me.txtExistenciaID.Text = "01"
        '
        'txtExistencia
        '
        Me.txtExistencia.BackColor = System.Drawing.Color.Plum
        Me.txtExistencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtExistencia.Location = New System.Drawing.Point(102, 127)
        Me.txtExistencia.Multiline = True
        Me.txtExistencia.Name = "txtExistencia"
        Me.txtExistencia.ReadOnly = True
        Me.txtExistencia.Size = New System.Drawing.Size(295, 21)
        Me.txtExistencia.TabIndex = 2
        Me.txtExistencia.Text = "MERCADERIA"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Label16.Location = New System.Drawing.Point(14, 132)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 13)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Tipo Existencia:"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.Color.DarkMagenta
        Me.LinkLabel3.Location = New System.Drawing.Point(440, 213)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel3.TabIndex = 36
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Cambiar"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.DarkMagenta
        Me.LinkLabel2.Location = New System.Drawing.Point(440, 184)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel2.TabIndex = 35
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Cambiar"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DarkMagenta
        Me.LinkLabel1.Location = New System.Drawing.Point(440, 158)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel1.TabIndex = 34
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Cambiar"
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.Thistle
        Me.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCuenta.Location = New System.Drawing.Point(174, 231)
        Me.txtCuenta.Multiline = True
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(260, 21)
        Me.txtCuenta.TabIndex = 21
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Label15.Location = New System.Drawing.Point(16, 236)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Cuenta Ctable:"
        '
        'txtPresenID
        '
        Me.txtPresenID.BackColor = System.Drawing.Color.Thistle
        Me.txtPresenID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPresenID.Location = New System.Drawing.Point(399, 205)
        Me.txtPresenID.Multiline = True
        Me.txtPresenID.Name = "txtPresenID"
        Me.txtPresenID.ReadOnly = True
        Me.txtPresenID.Size = New System.Drawing.Size(35, 21)
        Me.txtPresenID.TabIndex = 30
        Me.txtPresenID.Text = "09"
        '
        'txtPresen
        '
        Me.txtPresen.BackColor = System.Drawing.Color.Thistle
        Me.txtPresen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPresen.Location = New System.Drawing.Point(102, 205)
        Me.txtPresen.Multiline = True
        Me.txtPresen.Name = "txtPresen"
        Me.txtPresen.ReadOnly = True
        Me.txtPresen.Size = New System.Drawing.Size(295, 21)
        Me.txtPresen.TabIndex = 20
        Me.txtPresen.Text = "UNIDADES"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Label14.Location = New System.Drawing.Point(23, 210)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Presentación:"
        '
        'txtumID
        '
        Me.txtumID.BackColor = System.Drawing.Color.Thistle
        Me.txtumID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtumID.Location = New System.Drawing.Point(399, 179)
        Me.txtumID.Multiline = True
        Me.txtumID.Name = "txtumID"
        Me.txtumID.ReadOnly = True
        Me.txtumID.Size = New System.Drawing.Size(35, 21)
        Me.txtumID.TabIndex = 27
        Me.txtumID.Text = "07"
        '
        'txtum
        '
        Me.txtum.BackColor = System.Drawing.Color.Thistle
        Me.txtum.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtum.Location = New System.Drawing.Point(102, 179)
        Me.txtum.Multiline = True
        Me.txtum.Name = "txtum"
        Me.txtum.ReadOnly = True
        Me.txtum.Size = New System.Drawing.Size(295, 21)
        Me.txtum.TabIndex = 6
        Me.txtum.Text = "UNIDADES"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Label13.Location = New System.Drawing.Point(62, 184)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "U.M.:"
        '
        'txtClasifID
        '
        Me.txtClasifID.BackColor = System.Drawing.Color.Thistle
        Me.txtClasifID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtClasifID.Location = New System.Drawing.Point(399, 153)
        Me.txtClasifID.Multiline = True
        Me.txtClasifID.Name = "txtClasifID"
        Me.txtClasifID.ReadOnly = True
        Me.txtClasifID.Size = New System.Drawing.Size(35, 21)
        Me.txtClasifID.TabIndex = 24
        '
        'txtClasif
        '
        Me.txtClasif.BackColor = System.Drawing.Color.Thistle
        Me.txtClasif.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtClasif.Location = New System.Drawing.Point(102, 153)
        Me.txtClasif.Multiline = True
        Me.txtClasif.Name = "txtClasif"
        Me.txtClasif.ReadOnly = True
        Me.txtClasif.Size = New System.Drawing.Size(295, 21)
        Me.txtClasif.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Label3.Location = New System.Drawing.Point(27, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Clasificación:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Label2.Location = New System.Drawing.Point(31, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripción:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Label1.Location = New System.Drawing.Point(52, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.ApplicationButton = Me.QRibbonApplicationButton1
        Me.QRibbonCaption1.BackgroundImageAlign = Qios.DevSuite.Components.QImageAlign.RepeatedVertical
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(498, 28)
        Me.QRibbonCaption1.TabIndex = 456
        Me.QRibbonCaption1.Text = "Recurso"
        '
        'QRibbonApplicationButton1
        '
        Me.QRibbonApplicationButton1.Checked = True
        Me.QRibbonApplicationButton1.Configuration.Padding = New Qios.DevSuite.Components.QPadding(12, 11, -10, -9)
        Me.QRibbonApplicationButton1.ForegroundImage = CType(resources.GetObject("QRibbonApplicationButton1.ForegroundImage"), System.Drawing.Image)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(498, 25)
        Me.ToolStrip1.TabIndex = 457
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblEstado
        '
        Me.lblEstado.Enabled = False
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(136, 22)
        Me.lblEstado.Text = "Estado: nueva existencia"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(102, 80)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(100, 19)
        Me.txtCodigo.TabIndex = 458
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(102, 103)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(332, 19)
        Me.txtDescripcion.TabIndex = 459
        '
        'txtCuentaID
        '
        Me.txtCuentaID.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.txtCuentaID.BackColor = System.Drawing.SystemColors.Window
        Me.txtCuentaID.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.txtCuentaID.Location = New System.Drawing.Point(102, 231)
        Me.txtCuentaID.Name = "txtCuentaID"
        Me.txtCuentaID.Padding = New System.Windows.Forms.Padding(4)
        Me.txtCuentaID.PopupWidth = 120
        Me.txtCuentaID.SelectedItemBackColor = System.Drawing.SystemColors.Highlight
        Me.txtCuentaID.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtCuentaID.Size = New System.Drawing.Size(70, 22)
        Me.txtCuentaID.TabIndex = 460
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'frmNuevoMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 364)
        Me.Controls.Add(Me.txtCuentaID)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LinkLabel5)
        Me.Controls.Add(Me.txtExistenciaID)
        Me.Controls.Add(Me.txtExistencia)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.txtClasif)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.txtClasifID)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtPresenID)
        Me.Controls.Add(Me.txtum)
        Me.Controls.Add(Me.txtPresen)
        Me.Controls.Add(Me.txtumID)
        Me.Controls.Add(Me.Label14)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNuevoMaterial"
        Me.Text = "Recurso"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPresenID As System.Windows.Forms.TextBox
    Friend WithEvents txtPresen As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtumID As System.Windows.Forms.TextBox
    Friend WithEvents txtum As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtClasifID As System.Windows.Forms.TextBox
    Friend WithEvents txtClasif As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtExistenciaID As System.Windows.Forms.TextBox
    Friend WithEvents txtExistencia As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAfecta As System.Windows.Forms.RadioButton
    Friend WithEvents rbnoAfecta As System.Windows.Forms.RadioButton
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents txtCodigo As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents QRibbonApplicationButton1 As Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton
    Friend WithEvents txtDescripcion As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtCuentaID As Femiani.Forms.UI.Input.CoolTextBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class

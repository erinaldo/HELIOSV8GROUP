<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroCajaUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistroCajaUsuario))
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtEstablecimiento = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbExtra = New System.Windows.Forms.RadioButton()
        Me.rbNac = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipo = New Qios.DevSuite.Components.QComboBox()
        Me.txtCuenta = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.txtCaja = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtClave = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.txtPersona = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFechaApertura = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.QRibbonApplicationButton2 = New Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtFondoME = New System.Windows.Forms.NumericUpDown()
        Me.txtTipoCambio = New System.Windows.Forms.NumericUpDown()
        Me.txtFondoMN = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cboTipoCajaDestino = New Qios.DevSuite.Components.QComboBox()
        Me.txtCuentaCajaDestino = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.txtCajaDestino = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.txtFondoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFondoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.txtEstablecimiento)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(387, 50)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Establecimiento - caja:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(330, 22)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(44, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "cambiar"
        '
        'txtEstablecimiento
        '
        Me.txtEstablecimiento.Location = New System.Drawing.Point(6, 19)
        Me.txtEstablecimiento.Name = "txtEstablecimiento"
        Me.txtEstablecimiento.ReadOnly = True
        Me.txtEstablecimiento.Size = New System.Drawing.Size(316, 19)
        Me.txtEstablecimiento.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbExtra)
        Me.GroupBox2.Controls.Add(Me.rbNac)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cboTipo)
        Me.GroupBox2.Controls.Add(Me.txtCuenta)
        Me.GroupBox2.Controls.Add(Me.LinkLabel2)
        Me.GroupBox2.Controls.Add(Me.txtCaja)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(387, 89)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Caja de Origen:"
        '
        'rbExtra
        '
        Me.rbExtra.AutoSize = True
        Me.rbExtra.Location = New System.Drawing.Point(184, 26)
        Me.rbExtra.Name = "rbExtra"
        Me.rbExtra.Size = New System.Drawing.Size(76, 17)
        Me.rbExtra.TabIndex = 9
        Me.rbExtra.Text = "Extranjera"
        Me.rbExtra.UseVisualStyleBackColor = True
        '
        'rbNac
        '
        Me.rbNac.AutoSize = True
        Me.rbNac.Checked = True
        Me.rbNac.Location = New System.Drawing.Point(107, 26)
        Me.rbNac.Name = "rbNac"
        Me.rbNac.Size = New System.Drawing.Size(65, 17)
        Me.rbNac.TabIndex = 8
        Me.rbNac.TabStop = True
        Me.rbNac.Text = "Nacional"
        Me.rbNac.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Moneda:"
        '
        'cboTipo
        '
        Me.cboTipo.Enabled = False
        Me.cboTipo.Items.AddRange(New Object() {"BANCO", "EFECTIVO"})
        Me.cboTipo.Location = New System.Drawing.Point(6, 56)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.SelectedIndex = 0
        Me.cboTipo.SelectedItem = "BANCO"
        Me.cboTipo.Size = New System.Drawing.Size(59, 19)
        Me.cboTipo.TabIndex = 6
        Me.cboTipo.Text = "BANCO"
        '
        'txtCuenta
        '
        Me.txtCuenta.Enabled = False
        Me.txtCuenta.Location = New System.Drawing.Point(276, 56)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(46, 19)
        Me.txtCuenta.TabIndex = 5
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Enabled = False
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.Location = New System.Drawing.Point(330, 59)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(44, 13)
        Me.LinkLabel2.TabIndex = 4
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "cambiar"
        '
        'txtCaja
        '
        Me.txtCaja.Enabled = False
        Me.txtCaja.Location = New System.Drawing.Point(67, 56)
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.ReadOnly = True
        Me.txtCaja.Size = New System.Drawing.Size(207, 19)
        Me.txtCaja.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtClave)
        Me.GroupBox3.Controls.Add(Me.LinkLabel3)
        Me.GroupBox3.Controls.Add(Me.txtPersona)
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 269)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(387, 92)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Persona Encargarda:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Clave para ingreso a la caja:"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(6, 65)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(318, 19)
        Me.txtClave.TabIndex = 5
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel3.Location = New System.Drawing.Point(330, 22)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(44, 13)
        Me.LinkLabel3.TabIndex = 4
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "cambiar"
        '
        'txtPersona
        '
        Me.txtPersona.Location = New System.Drawing.Point(6, 19)
        Me.txtPersona.Name = "txtPersona"
        Me.txtPersona.ReadOnly = True
        Me.txtPersona.Size = New System.Drawing.Size(318, 19)
        Me.txtPersona.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 374)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha registro:"
        '
        'txtFechaApertura
        '
        Me.txtFechaApertura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaApertura.Location = New System.Drawing.Point(103, 370)
        Me.txtFechaApertura.Name = "txtFechaApertura"
        Me.txtFechaApertura.Size = New System.Drawing.Size(97, 20)
        Me.txtFechaApertura.TabIndex = 5
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado, Me.lblPeriodo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(405, 25)
        Me.ToolStrip1.TabIndex = 458
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblEstado
        '
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(44, 22)
        Me.lblEstado.Text = "Estado"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(47, 22)
        Me.lblPeriodo.Text = "00/2015"
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.ApplicationButton = Me.QRibbonApplicationButton2
        Me.QRibbonCaption1.BackgroundImageAlign = Qios.DevSuite.Components.QImageAlign.RepeatedVertical
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(405, 28)
        Me.QRibbonCaption1.TabIndex = 459
        Me.QRibbonCaption1.Text = "Aperturar Caja"
        '
        'QRibbonApplicationButton2
        '
        Me.QRibbonApplicationButton2.Checked = True
        Me.QRibbonApplicationButton2.Configuration.Padding = New Qios.DevSuite.Components.QPadding(12, 11, -10, -9)
        Me.QRibbonApplicationButton2.ForegroundImage = CType(resources.GetObject("QRibbonApplicationButton2.ForegroundImage"), System.Drawing.Image)
        Me.QRibbonApplicationButton2.ToolTipText = "Grabar (Ctr + G)"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtFondoME)
        Me.GroupBox4.Controls.Add(Me.txtTipoCambio)
        Me.GroupBox4.Controls.Add(Me.txtFondoMN)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 399)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(387, 50)
        Me.GroupBox4.TabIndex = 460
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Importe Fondo Entregado:"
        '
        'txtFondoME
        '
        Me.txtFondoME.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFondoME.DecimalPlaces = 2
        Me.txtFondoME.Enabled = False
        Me.txtFondoME.Location = New System.Drawing.Point(239, 19)
        Me.txtFondoME.Maximum = New Decimal(New Integer() {-1981284352, -1966660860, 0, 0})
        Me.txtFondoME.Name = "txtFondoME"
        Me.txtFondoME.Size = New System.Drawing.Size(120, 20)
        Me.txtFondoME.TabIndex = 8
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.DecimalPlaces = 2
        Me.txtTipoCambio.Location = New System.Drawing.Point(169, 19)
        Me.txtTipoCambio.Maximum = New Decimal(New Integer() {-1981284352, -1966660860, 0, 0})
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(51, 20)
        Me.txtTipoCambio.TabIndex = 7
        Me.txtTipoCambio.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'txtFondoMN
        '
        Me.txtFondoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFondoMN.DecimalPlaces = 2
        Me.txtFondoMN.Location = New System.Drawing.Point(9, 19)
        Me.txtFondoMN.Maximum = New Decimal(New Integer() {-1981284352, -1966660860, 0, 0})
        Me.txtFondoMN.Name = "txtFondoMN"
        Me.txtFondoMN.Size = New System.Drawing.Size(120, 20)
        Me.txtFondoMN.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(144, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "t/c.:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cboTipoCajaDestino)
        Me.GroupBox6.Controls.Add(Me.txtCuentaCajaDestino)
        Me.GroupBox6.Controls.Add(Me.LinkLabel4)
        Me.GroupBox6.Controls.Add(Me.txtCajaDestino)
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(10, 207)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(387, 57)
        Me.GroupBox6.TabIndex = 462
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Caja de Destino:"
        '
        'cboTipoCajaDestino
        '
        Me.cboTipoCajaDestino.Items.AddRange(New Object() {"BANCO", "EFECTIVO"})
        Me.cboTipoCajaDestino.Location = New System.Drawing.Point(6, 24)
        Me.cboTipoCajaDestino.Name = "cboTipoCajaDestino"
        Me.cboTipoCajaDestino.SelectedIndex = 0
        Me.cboTipoCajaDestino.SelectedItem = "BANCO"
        Me.cboTipoCajaDestino.Size = New System.Drawing.Size(59, 19)
        Me.cboTipoCajaDestino.TabIndex = 6
        Me.cboTipoCajaDestino.Text = "BANCO"
        '
        'txtCuentaCajaDestino
        '
        Me.txtCuentaCajaDestino.Location = New System.Drawing.Point(276, 24)
        Me.txtCuentaCajaDestino.Name = "txtCuentaCajaDestino"
        Me.txtCuentaCajaDestino.ReadOnly = True
        Me.txtCuentaCajaDestino.Size = New System.Drawing.Size(46, 19)
        Me.txtCuentaCajaDestino.TabIndex = 5
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel4.Location = New System.Drawing.Point(330, 27)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(44, 13)
        Me.LinkLabel4.TabIndex = 4
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "cambiar"
        '
        'txtCajaDestino
        '
        Me.txtCajaDestino.Location = New System.Drawing.Point(67, 24)
        Me.txtCajaDestino.Name = "txtCajaDestino"
        Me.txtCajaDestino.ReadOnly = True
        Me.txtCajaDestino.Size = New System.Drawing.Size(207, 19)
        Me.txtCajaDestino.TabIndex = 2
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmRegistroCajaUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 461)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Controls.Add(Me.txtFechaApertura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegistroCajaUsuario"
        Me.Text = "Aperturar Caja"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.txtFondoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFondoMN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEstablecimiento As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCaja As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPersona As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFechaApertura As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents QRibbonApplicationButton2 As Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCuenta As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents cboTipo As Qios.DevSuite.Components.QComboBox
    Friend WithEvents rbExtra As System.Windows.Forms.RadioButton
    Friend WithEvents rbNac As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoCajaDestino As Qios.DevSuite.Components.QComboBox
    Friend WithEvents txtCuentaCajaDestino As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCajaDestino As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtClave As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtFondoME As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtTipoCambio As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtFondoMN As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPeriodo As System.Windows.Forms.ToolStripLabel
End Class

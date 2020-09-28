<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoAlmacen
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoAlmacen))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.gpVSBehavior = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtDireccion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtEncargado = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtdescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtEstablecimiento = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtEmpresa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudPorGanancia = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerAdv1 = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpVSBehavior.SuspendLayout()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.txtEncargado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstablecimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorGanancia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimePickerAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.lblPerido, Me.lblTitulo, Me.PegarToolStripButton, Me.toolStripSeparator1, Me.lblIdDocumento})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(426, 25)
        Me.ToolStrip3.TabIndex = 405
        Me.ToolStrip3.Text = "ToolStrip3"
        Me.ToolStrip3.Visible = False
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'lblPerido
        '
        Me.lblPerido.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(48, 22)
        Me.lblPerido.Text = "01/2014"
        Me.lblPerido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.lblPerido.Visible = False
        '
        'lblTitulo
        '
        Me.lblTitulo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(57, 22)
        Me.lblTitulo.Text = "PERIODO:"
        Me.lblTitulo.Visible = False
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.Image = CType(resources.GetObject("PegarToolStripButton.Image"), System.Drawing.Image)
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PegarToolStripButton.Text = "&Cancelar"
        Me.PegarToolStripButton.Visible = False
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(19, 22)
        Me.lblIdDocumento.Text = "00"
        Me.lblIdDocumento.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(426, 25)
        Me.ToolStrip1.TabIndex = 406
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(127, 22)
        Me.lblEstado.Text = "Estado: nuevo almacén."
        '
        'gpVSBehavior
        '
        Me.gpVSBehavior.BackColor = System.Drawing.Color.White
        Me.gpVSBehavior.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpVSBehavior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gpVSBehavior.Controls.Add(Me.txtDireccion)
        Me.gpVSBehavior.Controls.Add(Me.Label8)
        Me.gpVSBehavior.Controls.Add(Me.GradientPanel2)
        Me.gpVSBehavior.Controls.Add(Me.txtEncargado)
        Me.gpVSBehavior.Controls.Add(Me.txtdescripcion)
        Me.gpVSBehavior.Controls.Add(Me.txtEstablecimiento)
        Me.gpVSBehavior.Controls.Add(Me.txtEmpresa)
        Me.gpVSBehavior.Controls.Add(Me.Label5)
        Me.gpVSBehavior.Controls.Add(Me.nudPorGanancia)
        Me.gpVSBehavior.Controls.Add(Me.Label7)
        Me.gpVSBehavior.Controls.Add(Me.Label6)
        Me.gpVSBehavior.Controls.Add(Me.cboTipoDoc)
        Me.gpVSBehavior.Controls.Add(Me.Label1)
        Me.gpVSBehavior.Controls.Add(Me.DateTimePickerAdv1)
        Me.gpVSBehavior.Controls.Add(Me.Label2)
        Me.gpVSBehavior.Controls.Add(Me.Label4)
        Me.gpVSBehavior.Controls.Add(Me.Label3)
        Me.gpVSBehavior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpVSBehavior.Location = New System.Drawing.Point(0, 0)
        Me.gpVSBehavior.Name = "gpVSBehavior"
        Me.gpVSBehavior.Size = New System.Drawing.Size(426, 319)
        Me.gpVSBehavior.TabIndex = 408
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDireccion.BeforeTouchSize = New System.Drawing.Size(265, 22)
        Me.txtDireccion.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccion.CornerRadius = 4
        Me.txtDireccion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDireccion.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(115, 153)
        Me.txtDireccion.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtDireccion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDireccion.Size = New System.Drawing.Size(265, 39)
        Me.txtDireccion.TabIndex = 434
        Me.txtDireccion.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(49, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 14)
        Me.Label8.TabIndex = 433
        Me.Label8.Text = "Dirección:"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel2.Controls.Add(Me.btOperacion)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 259)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(424, 58)
        Me.GradientPanel2.TabIndex = 432
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.White
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(280, 15)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.TabIndex = 9
        Me.ButtonAdv2.Text = "Cancel"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(165, 15)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 8
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'txtEncargado
        '
        Me.txtEncargado.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtEncargado.BeforeTouchSize = New System.Drawing.Size(265, 22)
        Me.txtEncargado.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtEncargado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEncargado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEncargado.CornerRadius = 4
        Me.txtEncargado.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEncargado.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEncargado.Location = New System.Drawing.Point(115, 198)
        Me.txtEncargado.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtEncargado.MinimumSize = New System.Drawing.Size(12, 8)
        Me.txtEncargado.Name = "txtEncargado"
        Me.txtEncargado.Size = New System.Drawing.Size(265, 22)
        Me.txtEncargado.TabIndex = 402
        '
        'txtdescripcion
        '
        Me.txtdescripcion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtdescripcion.BeforeTouchSize = New System.Drawing.Size(265, 22)
        Me.txtdescripcion.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtdescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescripcion.CornerRadius = 4
        Me.txtdescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtdescripcion.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescripcion.Location = New System.Drawing.Point(115, 125)
        Me.txtdescripcion.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtdescripcion.MinimumSize = New System.Drawing.Size(12, 8)
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(265, 22)
        Me.txtdescripcion.TabIndex = 401
        '
        'txtEstablecimiento
        '
        Me.txtEstablecimiento.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtEstablecimiento.BeforeTouchSize = New System.Drawing.Size(265, 22)
        Me.txtEstablecimiento.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtEstablecimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstablecimiento.CornerRadius = 4
        Me.txtEstablecimiento.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEstablecimiento.Enabled = False
        Me.txtEstablecimiento.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstablecimiento.Location = New System.Drawing.Point(115, 40)
        Me.txtEstablecimiento.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtEstablecimiento.MinimumSize = New System.Drawing.Size(12, 8)
        Me.txtEstablecimiento.Name = "txtEstablecimiento"
        Me.txtEstablecimiento.ReadOnly = True
        Me.txtEstablecimiento.Size = New System.Drawing.Size(265, 22)
        Me.txtEstablecimiento.TabIndex = 400
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtEmpresa.BeforeTouchSize = New System.Drawing.Size(265, 22)
        Me.txtEmpresa.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpresa.CornerRadius = 4
        Me.txtEmpresa.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtEmpresa.Enabled = False
        Me.txtEmpresa.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresa.Location = New System.Drawing.Point(115, 12)
        Me.txtEmpresa.Metrocolor = System.Drawing.Color.Silver
        Me.txtEmpresa.MinimumSize = New System.Drawing.Size(12, 8)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(265, 22)
        Me.txtEmpresa.TabIndex = 399
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(54, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 14)
        Me.Label5.TabIndex = 214
        Me.Label5.Text = "Empresa:"
        '
        'nudPorGanancia
        '
        Me.nudPorGanancia.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.nudPorGanancia.BeforeTouchSize = New System.Drawing.Size(117, 22)
        Me.nudPorGanancia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudPorGanancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudPorGanancia.DecimalPlaces = 2
        Me.nudPorGanancia.Location = New System.Drawing.Point(263, 231)
        Me.nudPorGanancia.Maximum = New Decimal(New Integer() {-469762048, -590869294, 5421010, 0})
        Me.nudPorGanancia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudPorGanancia.Name = "nudPorGanancia"
        Me.nudPorGanancia.Size = New System.Drawing.Size(117, 22)
        Me.nudPorGanancia.TabIndex = 398
        Me.nudPorGanancia.ThousandsSeparator = True
        Me.nudPorGanancia.Visible = False
        Me.nudPorGanancia.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(180, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 215
        Me.Label7.Text = "% de utilidad:"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(16, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 14)
        Me.Label6.TabIndex = 213
        Me.Label6.Text = "Establecimiento:"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(204, 22)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Enabled = False
        Me.cboTipoDoc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Items.AddRange(New Object() {"ALMACEN FISICO"})
        Me.cboTipoDoc.Location = New System.Drawing.Point(115, 96)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Gainsboro
        Me.cboTipoDoc.MetroColor = System.Drawing.Color.Gainsboro
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(204, 22)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 214
        Me.cboTipoDoc.Text = "ALMACEN FISICO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(66, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 14)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "Fecha:"
        '
        'DateTimePickerAdv1
        '
        Me.DateTimePickerAdv1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.DateTimePickerAdv1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.DateTimePickerAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DateTimePickerAdv1.CalendarSize = New System.Drawing.Size(189, 176)
        Me.DateTimePickerAdv1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.DateTimePickerAdv1.DropDownImage = Nothing
        Me.DateTimePickerAdv1.DropDownNormalColor = System.Drawing.Color.ForestGreen
        Me.DateTimePickerAdv1.DropDownPressedColor = System.Drawing.Color.ForestGreen
        Me.DateTimePickerAdv1.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.DateTimePickerAdv1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAdv1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAdv1.Location = New System.Drawing.Point(115, 69)
        Me.DateTimePickerAdv1.MetroColor = System.Drawing.Color.ForestGreen
        Me.DateTimePickerAdv1.MinValue = New Date(CType(0, Long))
        Me.DateTimePickerAdv1.Name = "DateTimePickerAdv1"
        Me.DateTimePickerAdv1.ShowCheckBox = False
        Me.DateTimePickerAdv1.Size = New System.Drawing.Size(204, 20)
        Me.DateTimePickerAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.DateTimePickerAdv1.TabIndex = 213
        Me.DateTimePickerAdv1.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(73, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 14)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Tipo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(56, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 14)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(43, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 14)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "Encargado:"
        '
        'txtFechaComprobante
        '
        Me.txtFechaComprobante.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaComprobante.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaComprobante.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaComprobante.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.txtFechaComprobante.DropDownImage = Nothing
        Me.txtFechaComprobante.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaComprobante.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaComprobante.Location = New System.Drawing.Point(76, 21)
        Me.txtFechaComprobante.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.MinValue = New Date(CType(0, Long))
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.ShowCheckBox = False
        Me.txtFechaComprobante.Size = New System.Drawing.Size(181, 20)
        Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.TabIndex = 208
        Me.txtFechaComprobante.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'frmNuevoAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.MediumSeaGreen
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.MediumSeaGreen
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 8)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(55, 18)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Administración de almacenes"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(426, 319)
        Me.Controls.Add(Me.gpVSBehavior)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNuevoAlmacen"
        Me.ShowIcon = False
        Me.Text = ""
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpVSBehavior.ResumeLayout(False)
        Me.gpVSBehavior.PerformLayout()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.txtEncargado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstablecimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorGanancia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimePickerAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PegarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Private WithEvents gpVSBehavior As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents cboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents DateTimePickerAdv1 As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudPorGanancia As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtEstablecimiento As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtEmpresa As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtEncargado As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtdescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class

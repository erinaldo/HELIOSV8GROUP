<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportesLibroDiario
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.QRibbonApplicationButton1 = New Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ExpandCollapsePanel1 = New MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpPeriodoMes = New System.Windows.Forms.DateTimePicker()
        Me.dtpPeriodoAnio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtidProveedor = New System.Windows.Forms.TextBox()
        Me.LinkTipoDoc = New System.Windows.Forms.LinkLabel()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LinkProveedor = New System.Windows.Forms.LinkLabel()
        Me.txtIdComprobante = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandCollapsePanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(605, 25)
        Me.ToolStrip1.TabIndex = 48
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
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.ApplicationButton = Me.QRibbonApplicationButton1
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(605, 28)
        Me.QRibbonCaption1.TabIndex = 47
        Me.QRibbonCaption1.Text = "Reportes - Libro Diario"
        '
        'QRibbonApplicationButton1
        '
        Me.QRibbonApplicationButton1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._30659
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel5.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel5.Location = New System.Drawing.Point(67, 114)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(233, 13)
        Me.LinkLabel5.TabIndex = 292
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "5. Reporte listado de libro diario por codigo libro."
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel4.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel4.Location = New System.Drawing.Point(67, 92)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(250, 13)
        Me.LinkLabel4.TabIndex = 291
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "4. Reporte listado de libro diario por fecha progreso."
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel3.Location = New System.Drawing.Point(67, 70)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(216, 13)
        Me.LinkLabel3.TabIndex = 290
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "3. Reporte listado de libro diario por período."
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel2.Location = New System.Drawing.Point(67, 48)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(211, 13)
        Me.LinkLabel2.TabIndex = 289
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "2. Reporte listado de libro diario por entidad"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel1.Location = New System.Drawing.Point(67, 25)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(232, 13)
        Me.LinkLabel1.TabIndex = 288
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "1. Reporte listado de libro diario por documento."
        '
        'ExpandCollapsePanel1
        '
        Me.ExpandCollapsePanel1.BackColor = System.Drawing.Color.Transparent
        Me.ExpandCollapsePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ExpandCollapsePanel1.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal
        Me.ExpandCollapsePanel1.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle
        Me.ExpandCollapsePanel1.Controls.Add(Me.Label2)
        Me.ExpandCollapsePanel1.Controls.Add(Me.dtpPeriodoMes)
        Me.ExpandCollapsePanel1.Controls.Add(Me.dtpPeriodoAnio)
        Me.ExpandCollapsePanel1.Controls.Add(Me.GroupBox3)
        Me.ExpandCollapsePanel1.Controls.Add(Me.Label8)
        Me.ExpandCollapsePanel1.Controls.Add(Me.txtidProveedor)
        Me.ExpandCollapsePanel1.Controls.Add(Me.LinkTipoDoc)
        Me.ExpandCollapsePanel1.Controls.Add(Me.txtDocumento)
        Me.ExpandCollapsePanel1.Controls.Add(Me.txtComprobante)
        Me.ExpandCollapsePanel1.Controls.Add(Me.Label1)
        Me.ExpandCollapsePanel1.Controls.Add(Me.txtProveedor)
        Me.ExpandCollapsePanel1.Controls.Add(Me.Label3)
        Me.ExpandCollapsePanel1.Controls.Add(Me.Label6)
        Me.ExpandCollapsePanel1.Controls.Add(Me.LinkProveedor)
        Me.ExpandCollapsePanel1.Controls.Add(Me.txtIdComprobante)
        Me.ExpandCollapsePanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExpandCollapsePanel1.ExpandedHeight = 0
        Me.ExpandCollapsePanel1.IsExpanded = True
        Me.ExpandCollapsePanel1.Location = New System.Drawing.Point(0, 53)
        Me.ExpandCollapsePanel1.Name = "ExpandCollapsePanel1"
        Me.ExpandCollapsePanel1.Size = New System.Drawing.Size(605, 113)
        Me.ExpandCollapsePanel1.TabIndex = 291
        Me.ExpandCollapsePanel1.Text = "Buscar:"
        Me.ExpandCollapsePanel1.UseAnimation = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.LinkLabel5)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.LinkLabel4)
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.LinkLabel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 166)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(605, 136)
        Me.Panel2.TabIndex = 293
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.Location = New System.Drawing.Point(3, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 293
        Me.Label10.Text = "Libro Diario:"
        '
        'dtpPeriodoMes
        '
        Me.dtpPeriodoMes.CustomFormat = "MMMM"
        Me.dtpPeriodoMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodoMes.Location = New System.Drawing.Point(137, 46)
        Me.dtpPeriodoMes.Name = "dtpPeriodoMes"
        Me.dtpPeriodoMes.ShowUpDown = True
        Me.dtpPeriodoMes.Size = New System.Drawing.Size(117, 20)
        Me.dtpPeriodoMes.TabIndex = 60
        Me.dtpPeriodoMes.Visible = False
        '
        'dtpPeriodoAnio
        '
        Me.dtpPeriodoAnio.CustomFormat = "yyyy"
        Me.dtpPeriodoAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodoAnio.Location = New System.Drawing.Point(275, 46)
        Me.dtpPeriodoAnio.Name = "dtpPeriodoAnio"
        Me.dtpPeriodoAnio.ShowUpDown = True
        Me.dtpPeriodoAnio.Size = New System.Drawing.Size(99, 20)
        Me.dtpPeriodoAnio.TabIndex = 59
        Me.dtpPeriodoAnio.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtFechaInicio)
        Me.GroupBox3.Controls.Add(Me.txtFechaFin)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(137, 70)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(449, 36)
        Me.GroupBox3.TabIndex = 61
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha:"
        Me.GroupBox3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Desde:"
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaInicio.Location = New System.Drawing.Point(98, 11)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(135, 20)
        Me.txtFechaInicio.TabIndex = 44
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaFin.Location = New System.Drawing.Point(301, 11)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(135, 20)
        Me.txtFechaFin.TabIndex = 46
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(254, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Hasta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(78, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 15)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Periodo:"
        Me.Label8.Visible = False
        '
        'txtidProveedor
        '
        Me.txtidProveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtidProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidProveedor.Location = New System.Drawing.Point(175, 45)
        Me.txtidProveedor.Name = "txtidProveedor"
        Me.txtidProveedor.ReadOnly = True
        Me.txtidProveedor.Size = New System.Drawing.Size(32, 20)
        Me.txtidProveedor.TabIndex = 53
        Me.txtidProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtidProveedor.Visible = False
        '
        'LinkTipoDoc
        '
        Me.LinkTipoDoc.AutoSize = True
        Me.LinkTipoDoc.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkTipoDoc.Location = New System.Drawing.Point(377, 48)
        Me.LinkTipoDoc.Name = "LinkTipoDoc"
        Me.LinkTipoDoc.Size = New System.Drawing.Size(54, 15)
        Me.LinkTipoDoc.TabIndex = 55
        Me.LinkTipoDoc.TabStop = True
        Me.LinkTipoDoc.Text = "Cambiar"
        Me.LinkTipoDoc.Visible = False
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(161, 45)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(219, 20)
        Me.txtDocumento.TabIndex = 49
        '
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.Location = New System.Drawing.Point(150, 46)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(221, 20)
        Me.txtComprobante.TabIndex = 56
        Me.txtComprobante.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Documento:"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.Location = New System.Drawing.Point(210, 45)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(273, 20)
        Me.txtProveedor.TabIndex = 52
        Me.txtProveedor.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(78, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Tipo:"
        Me.Label3.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(78, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 15)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Nombre/Razón:"
        Me.Label6.Visible = False
        '
        'LinkProveedor
        '
        Me.LinkProveedor.AutoSize = True
        Me.LinkProveedor.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkProveedor.Location = New System.Drawing.Point(489, 48)
        Me.LinkProveedor.Name = "LinkProveedor"
        Me.LinkProveedor.Size = New System.Drawing.Size(54, 15)
        Me.LinkProveedor.TabIndex = 51
        Me.LinkProveedor.TabStop = True
        Me.LinkProveedor.Text = "Cambiar"
        Me.LinkProveedor.Visible = False
        '
        'txtIdComprobante
        '
        Me.txtIdComprobante.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtIdComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdComprobante.Location = New System.Drawing.Point(116, 46)
        Me.txtIdComprobante.Name = "txtIdComprobante"
        Me.txtIdComprobante.ReadOnly = True
        Me.txtIdComprobante.Size = New System.Drawing.Size(32, 20)
        Me.txtIdComprobante.TabIndex = 58
        Me.txtIdComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdComprobante.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(258, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 15)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "-"
        Me.Label2.Visible = False
        '
        'frmReportesLibroDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 305)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ExpandCollapsePanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "frmReportesLibroDiario"
        Me.Text = "Reportes - Libro Diario"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandCollapsePanel1.ResumeLayout(False)
        Me.ExpandCollapsePanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents QRibbonApplicationButton1 As Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton
    Friend WithEvents ExpandCollapsePanel1 As MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpPeriodoMes As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPeriodoAnio As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtidProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LinkTipoDoc As System.Windows.Forms.LinkLabel
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LinkProveedor As System.Windows.Forms.LinkLabel
    Friend WithEvents txtIdComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class

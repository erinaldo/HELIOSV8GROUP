<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionEmpresaMDI
    Inherits Syncfusion.Windows.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionEmpresaMDI))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cboTipo = New Qios.DevSuite.Components.QComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAgrgarAnio = New System.Windows.Forms.Button()
        Me.lstAños = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnMostrarAll = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtmontomaximo = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIva = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.cboEstablecimiento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.MonthPeriodo = New Syncfusion.Windows.Forms.Tools.MonthCalendarAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.nudTipoCambioCompra = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtFechaIgv = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.nudTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboEmpresa = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudTCTransaccionVenta = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.nudTCTransaccionCompra = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.txtmontomaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEstablecimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MonthPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTipoCambioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaIgv.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTCTransaccionVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTCTransaccionCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bw
        '
        Me.bw.WorkerReportsProgress = True
        Me.bw.WorkerSupportsCancellation = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.DarkRed
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(189, 309)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 25)
        Me.PictureBox2.TabIndex = 461
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Eliminar T/C")
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.DarkRed
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(331, 272)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 25)
        Me.PictureBox1.TabIndex = 460
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Ver Lista T/C")
        Me.PictureBox1.Visible = False
        '
        'PictureBox16
        '
        Me.PictureBox16.BackColor = System.Drawing.Color.DarkRed
        Me.PictureBox16.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(299, 272)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(26, 25)
        Me.PictureBox16.TabIndex = 459
        Me.PictureBox16.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox16, "Obtener último tipo de cambio")
        Me.PictureBox16.Visible = False
        '
        'PictureBox17
        '
        Me.PictureBox17.BackColor = System.Drawing.Color.DarkRed
        Me.PictureBox17.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(161, 309)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(26, 25)
        Me.PictureBox17.TabIndex = 458
        Me.PictureBox17.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox17, "Nuevo Tipo de cambio")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(345, 25)
        Me.ToolStrip1.TabIndex = 23
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(109, 22)
        Me.ToolStripLabel1.Text = "Iniciar con empresa:"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Salir"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Agregar Empresa"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.cboTipo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 373)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(780, 0)
        Me.Panel1.TabIndex = 19
        Me.Panel1.Visible = False
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.DimGray
        Me.Button2.Location = New System.Drawing.Point(261, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cboTipo
        '
        Me.cboTipo.ColorScheme.TextColor.SetColor("LunaBlue", System.Drawing.SystemColors.HotTrack, False)
        Me.cboTipo.Items.AddRange(New Object() {"PLANEAMIENTO", "CONTABILIDAD", "CAJA", "PUNTO DE VENTA"})
        Me.cboTipo.Location = New System.Drawing.Point(12, 8)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.SelectedIndex = 1
        Me.cboTipo.SelectedItem = "CONTABILIDAD"
        Me.cboTipo.Size = New System.Drawing.Size(41, 19)
        Me.cboTipo.TabIndex = 1
        Me.cboTipo.Text = "CONTABILIDAD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Area de trabajo:"
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(785, 207)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(97, 10)
        Me.Panel3.TabIndex = 17
        Me.Panel3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "2. Año:"
        '
        'btnAgrgarAnio
        '
        Me.btnAgrgarAnio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAgrgarAnio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgrgarAnio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.btnAgrgarAnio.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAgrgarAnio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgrgarAnio.Location = New System.Drawing.Point(785, 234)
        Me.btnAgrgarAnio.Name = "btnAgrgarAnio"
        Me.btnAgrgarAnio.Size = New System.Drawing.Size(97, 10)
        Me.btnAgrgarAnio.TabIndex = 15
        Me.btnAgrgarAnio.Text = "AGREGAR AÑO"
        Me.btnAgrgarAnio.UseVisualStyleBackColor = True
        Me.btnAgrgarAnio.Visible = False
        '
        'lstAños
        '
        Me.lstAños.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lstAños.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstAños.ForeColor = System.Drawing.Color.White
        Me.lstAños.FormattingEnabled = True
        Me.lstAños.Location = New System.Drawing.Point(785, 12)
        Me.lstAños.Name = "lstAños"
        Me.lstAños.ScrollAlwaysVisible = True
        Me.lstAños.Size = New System.Drawing.Size(97, 54)
        Me.lstAños.TabIndex = 16
        Me.lstAños.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(785, 82)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 10)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "ACEPTAR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'btnMostrarAll
        '
        Me.btnMostrarAll.BackColor = System.Drawing.Color.Transparent
        Me.btnMostrarAll.BackgroundImage = CType(resources.GetObject("btnMostrarAll.BackgroundImage"), System.Drawing.Image)
        Me.btnMostrarAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMostrarAll.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.btnMostrarAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMostrarAll.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnMostrarAll.Location = New System.Drawing.Point(785, 162)
        Me.btnMostrarAll.Name = "btnMostrarAll"
        Me.btnMostrarAll.Size = New System.Drawing.Size(82, 36)
        Me.btnMostrarAll.TabIndex = 6
        Me.btnMostrarAll.Text = "&Salir"
        Me.btnMostrarAll.UseVisualStyleBackColor = False
        Me.btnMostrarAll.Visible = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.Transparent
        Me.btnEditar.BackgroundImage = CType(resources.GetObject("btnEditar.BackgroundImage"), System.Drawing.Image)
        Me.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnEditar.Location = New System.Drawing.Point(785, 150)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(82, 10)
        Me.btnEditar.TabIndex = 4
        Me.btnEditar.Text = "Edi&tar"
        Me.btnEditar.UseVisualStyleBackColor = False
        Me.btnEditar.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnNuevo.Location = New System.Drawing.Point(785, 117)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(82, 10)
        Me.btnNuevo.TabIndex = 2
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        Me.btnNuevo.Visible = False
        '
        'txtmontomaximo
        '
        Me.txtmontomaximo.BackColor = System.Drawing.Color.White
        Me.txtmontomaximo.BeforeTouchSize = New System.Drawing.Size(120, 21)
        Me.txtmontomaximo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtmontomaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmontomaximo.DecimalPlaces = 2
        Me.txtmontomaximo.ForeColor = System.Drawing.Color.Black
        Me.txtmontomaximo.Location = New System.Drawing.Point(419, 164)
        Me.txtmontomaximo.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.txtmontomaximo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtmontomaximo.Name = "txtmontomaximo"
        Me.txtmontomaximo.Size = New System.Drawing.Size(120, 21)
        Me.txtmontomaximo.TabIndex = 446
        Me.txtmontomaximo.Value = New Decimal(New Integer() {700, 0, 0, 0})
        Me.txtmontomaximo.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(417, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 13)
        Me.Label1.TabIndex = 445
        Me.Label1.Text = "IDENTIFICAR CLIENTES A PARTIR DE -"
        '
        'txtIva
        '
        Me.txtIva.BackColor = System.Drawing.Color.White
        Me.txtIva.BeforeTouchSize = New System.Drawing.Size(120, 21)
        Me.txtIva.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIva.DecimalPlaces = 2
        Me.txtIva.ForeColor = System.Drawing.Color.Black
        Me.txtIva.Location = New System.Drawing.Point(640, 164)
        Me.txtIva.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIva.Name = "txtIva"
        Me.txtIva.Size = New System.Drawing.Size(120, 21)
        Me.txtIva.TabIndex = 444
        Me.txtIva.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'cboEstablecimiento
        '
        Me.cboEstablecimiento.BackColor = System.Drawing.Color.White
        Me.cboEstablecimiento.BeforeTouchSize = New System.Drawing.Size(341, 21)
        Me.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstablecimiento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstablecimiento.Location = New System.Drawing.Point(419, 110)
        Me.cboEstablecimiento.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboEstablecimiento.Name = "cboEstablecimiento"
        Me.cboEstablecimiento.Size = New System.Drawing.Size(341, 21)
        Me.cboEstablecimiento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEstablecimiento.TabIndex = 443
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DimGray
        Me.Label21.Location = New System.Drawing.Point(420, 17)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(121, 13)
        Me.Label21.TabIndex = 441
        Me.Label21.Text = "IDENTIFICAR EMPRESA"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(638, 144)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 13)
        Me.Label31.TabIndex = 440
        Me.Label31.Text = "% - I.V.A."
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(112, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.Location = New System.Drawing.Point(19, 43)
        Me.cboAnio.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Size = New System.Drawing.Size(112, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnio.TabIndex = 448
        '
        'MonthPeriodo
        '
        Me.MonthPeriodo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.MonthPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MonthPeriodo.BottomHeight = 30
        Me.MonthPeriodo.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.MonthPeriodo.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MonthPeriodo.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MonthPeriodo.DaysColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MonthPeriodo.DaysFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.MonthPeriodo.DaysHeaderInterior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        Me.MonthPeriodo.EnableTouchMode = True
        Me.MonthPeriodo.FirstDayOfWeek = System.Windows.Forms.Day.Monday
        Me.MonthPeriodo.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.MonthPeriodo.HeaderHeight = 34
        Me.MonthPeriodo.HeaderStartColor = System.Drawing.Color.White
        Me.MonthPeriodo.HighlightColor = System.Drawing.Color.Black
        Me.MonthPeriodo.Iso8601CalenderFormat = False
        Me.MonthPeriodo.Location = New System.Drawing.Point(19, 71)
        Me.MonthPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MonthPeriodo.Name = "MonthPeriodo"
        Me.MonthPeriodo.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.MonthPeriodo.SelectedDates = New Date() {New Date(2016, 11, 2, 0, 0, 0, 0)}
        Me.MonthPeriodo.Size = New System.Drawing.Size(338, 195)
        Me.MonthPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.MonthPeriodo.TabIndex = 447
        Me.MonthPeriodo.ThemedEnabledScrollButtons = False
        Me.MonthPeriodo.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.MonthPeriodo.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.MonthPeriodo.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MonthPeriodo.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.MonthPeriodo.NoneButton.ForeColor = System.Drawing.Color.White
        Me.MonthPeriodo.NoneButton.IsBackStageButton = False
        Me.MonthPeriodo.NoneButton.Location = New System.Drawing.Point(266, 0)
        Me.MonthPeriodo.NoneButton.Size = New System.Drawing.Size(72, 30)
        Me.MonthPeriodo.NoneButton.Text = "None"
        Me.MonthPeriodo.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.MonthPeriodo.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.MonthPeriodo.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MonthPeriodo.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.MonthPeriodo.TodayButton.ForeColor = System.Drawing.Color.White
        Me.MonthPeriodo.TodayButton.IsBackStageButton = False
        Me.MonthPeriodo.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.MonthPeriodo.TodayButton.Size = New System.Drawing.Size(266, 30)
        Me.MonthPeriodo.TodayButton.Text = "Hoy"
        Me.MonthPeriodo.TodayButton.UseVisualStyle = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(240, 15)
        Me.Label3.TabIndex = 449
        Me.Label3.Text = "1. Identificar el periodo y la fecha de trabajo."
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Left
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Location = New System.Drawing.Point(399, 12)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(11, 362)
        Me.GradientPanel1.TabIndex = 450
        '
        'nudTipoCambioCompra
        '
        Me.nudTipoCambioCompra.BackColor = System.Drawing.Color.Honeydew
        Me.nudTipoCambioCompra.BeforeTouchSize = New System.Drawing.Size(65, 21)
        Me.nudTipoCambioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudTipoCambioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTipoCambioCompra.DecimalPlaces = 3
        Me.nudTipoCambioCompra.ForeColor = System.Drawing.Color.Black
        Me.nudTipoCambioCompra.InterceptArrowKeys = False
        Me.nudTipoCambioCompra.Location = New System.Drawing.Point(19, 337)
        Me.nudTipoCambioCompra.Maximum = New Decimal(New Integer() {-469762048, -590869294, 5421010, 0})
        Me.nudTipoCambioCompra.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudTipoCambioCompra.Name = "nudTipoCambioCompra"
        Me.nudTipoCambioCompra.ReadOnly = True
        Me.nudTipoCambioCompra.Size = New System.Drawing.Size(65, 21)
        Me.nudTipoCambioCompra.TabIndex = 453
        Me.nudTipoCambioCompra.ThousandsSeparator = True
        Me.nudTipoCambioCompra.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudTipoCambioCompra.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtFechaIgv
        '
        Me.txtFechaIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtFechaIgv.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaIgv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaIgv.Calendar.AllowMultipleSelection = False
        Me.txtFechaIgv.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaIgv.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaIgv.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaIgv.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaIgv.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaIgv.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaIgv.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIgv.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaIgv.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaIgv.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaIgv.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaIgv.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaIgv.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaIgv.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaIgv.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.Calendar.Name = "monthCalendar"
        Me.txtFechaIgv.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaIgv.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaIgv.Calendar.Size = New System.Drawing.Size(85, 174)
        Me.txtFechaIgv.Calendar.SizeToFit = True
        Me.txtFechaIgv.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaIgv.Calendar.TabIndex = 0
        Me.txtFechaIgv.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaIgv.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaIgv.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaIgv.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaIgv.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaIgv.Calendar.NoneButton.Location = New System.Drawing.Point(13, 0)
        Me.txtFechaIgv.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaIgv.Calendar.NoneButton.Text = "None"
        Me.txtFechaIgv.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaIgv.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaIgv.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaIgv.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaIgv.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaIgv.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaIgv.Calendar.TodayButton.Size = New System.Drawing.Size(13, 20)
        Me.txtFechaIgv.Calendar.TodayButton.Text = "Today"
        Me.txtFechaIgv.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaIgv.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIgv.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaIgv.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaIgv.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaIgv.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaIgv.DropDownImage = Nothing
        Me.txtFechaIgv.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaIgv.ForeColor = System.Drawing.Color.White
        Me.txtFechaIgv.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaIgv.Location = New System.Drawing.Point(161, 337)
        Me.txtFechaIgv.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaIgv.MinValue = New Date(CType(0, Long))
        Me.txtFechaIgv.Name = "txtFechaIgv"
        Me.txtFechaIgv.ReadOnly = True
        Me.txtFechaIgv.ShowCheckBox = False
        Me.txtFechaIgv.ShowDropButton = False
        Me.txtFechaIgv.Size = New System.Drawing.Size(89, 21)
        Me.txtFechaIgv.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaIgv.TabIndex = 452
        Me.txtFechaIgv.Value = New Date(2015, 9, 9, 21, 37, 56, 824)
        '
        'nudTipoCambio
        '
        Me.nudTipoCambio.BackColor = System.Drawing.Color.Honeydew
        Me.nudTipoCambio.BeforeTouchSize = New System.Drawing.Size(67, 21)
        Me.nudTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTipoCambio.DecimalPlaces = 3
        Me.nudTipoCambio.ForeColor = System.Drawing.Color.Black
        Me.nudTipoCambio.InterceptArrowKeys = False
        Me.nudTipoCambio.Location = New System.Drawing.Point(90, 337)
        Me.nudTipoCambio.Maximum = New Decimal(New Integer() {-469762048, -590869294, 5421010, 0})
        Me.nudTipoCambio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudTipoCambio.Name = "nudTipoCambio"
        Me.nudTipoCambio.ReadOnly = True
        Me.nudTipoCambio.Size = New System.Drawing.Size(67, 21)
        Me.nudTipoCambio.TabIndex = 451
        Me.nudTipoCambio.ThousandsSeparator = True
        Me.nudTipoCambio.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.SeaGreen
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(79, 59)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(681, 219)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(79, 59)
        Me.ButtonAdv1.TabIndex = 462
        Me.ButtonAdv1.Text = "Guardar"
        Me.ButtonAdv1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'cboEmpresa
        '
        Me.cboEmpresa.BackColor = System.Drawing.Color.White
        Me.cboEmpresa.BeforeTouchSize = New System.Drawing.Size(341, 21)
        Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpresa.Location = New System.Drawing.Point(419, 43)
        Me.cboEmpresa.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(341, 21)
        Me.cboEmpresa.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEmpresa.TabIndex = 463
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(420, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 464
        Me.Label5.Text = "ESTABLECIMIENTO"
        '
        'nudTCTransaccionVenta
        '
        Me.nudTCTransaccionVenta.BackColor = System.Drawing.Color.MistyRose
        Me.nudTCTransaccionVenta.BeforeTouchSize = New System.Drawing.Size(64, 21)
        Me.nudTCTransaccionVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudTCTransaccionVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTCTransaccionVenta.DecimalPlaces = 3
        Me.nudTCTransaccionVenta.Location = New System.Drawing.Point(324, 337)
        Me.nudTCTransaccionVenta.Maximum = New Decimal(New Integer() {-469762048, -590869294, 5421010, 0})
        Me.nudTCTransaccionVenta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudTCTransaccionVenta.Name = "nudTCTransaccionVenta"
        Me.nudTCTransaccionVenta.Size = New System.Drawing.Size(64, 21)
        Me.nudTCTransaccionVenta.TabIndex = 458
        Me.nudTCTransaccionVenta.ThousandsSeparator = True
        Me.nudTCTransaccionVenta.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudTCTransaccionVenta.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'nudTCTransaccionCompra
        '
        Me.nudTCTransaccionCompra.BackColor = System.Drawing.Color.MistyRose
        Me.nudTCTransaccionCompra.BeforeTouchSize = New System.Drawing.Size(65, 21)
        Me.nudTCTransaccionCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudTCTransaccionCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTCTransaccionCompra.DecimalPlaces = 3
        Me.nudTCTransaccionCompra.Location = New System.Drawing.Point(255, 337)
        Me.nudTCTransaccionCompra.Maximum = New Decimal(New Integer() {-469762048, -590869294, 5421010, 0})
        Me.nudTCTransaccionCompra.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudTCTransaccionCompra.Name = "nudTCTransaccionCompra"
        Me.nudTCTransaccionCompra.Size = New System.Drawing.Size(65, 21)
        Me.nudTCTransaccionCompra.TabIndex = 459
        Me.nudTCTransaccionCompra.ThousandsSeparator = True
        Me.nudTCTransaccionCompra.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudTCTransaccionCompra.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(158, 15)
        Me.Label8.TabIndex = 467
        Me.Label8.Text = "Tipo de cambio configurado"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(17, 318)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 12)
        Me.Label9.TabIndex = 468
        Me.Label9.Text = "COMPRA"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(88, 318)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 12)
        Me.Label10.TabIndex = 469
        Me.Label10.Text = "VENTA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(324, 318)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 12)
        Me.Label6.TabIndex = 471
        Me.Label6.Text = "VENTA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(253, 318)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 12)
        Me.Label7.TabIndex = 470
        Me.Label7.Text = "COMPRA"
        '
        'frmSeleccionEmpresaMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BorderColor = System.Drawing.Color.DarkRed
        Me.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionFont = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 4)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(55, 10)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Elegir  y configurar empresa"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(780, 373)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.nudTCTransaccionVenta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.nudTCTransaccionCompra)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.nudTipoCambio)
        Me.Controls.Add(Me.nudTipoCambioCompra)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboEmpresa)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox16)
        Me.Controls.Add(Me.PictureBox17)
        Me.Controls.Add(Me.txtFechaIgv)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboAnio)
        Me.Controls.Add(Me.MonthPeriodo)
        Me.Controls.Add(Me.txtmontomaximo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIva)
        Me.Controls.Add(Me.cboEstablecimiento)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnAgrgarAnio)
        Me.Controls.Add(Me.lstAños)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnMostrarAll)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionEmpresaMDI"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.txtmontomaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEstablecimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MonthPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTipoCambioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaIgv.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaIgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTCTransaccionVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTCTransaccionCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnMostrarAll As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAgrgarAnio As System.Windows.Forms.Button
    Friend WithEvents lstAños As System.Windows.Forms.ListBox
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboTipo As Qios.DevSuite.Components.QComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtmontomaximo As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIva As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents cboEstablecimiento As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents MonthPeriodo As Syncfusion.Windows.Forms.Tools.MonthCalendarAdv
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents nudTipoCambioCompra As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtFechaIgv As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents nudTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboEmpresa As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents nudTCTransaccionVenta As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents nudTCTransaccionCompra As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class

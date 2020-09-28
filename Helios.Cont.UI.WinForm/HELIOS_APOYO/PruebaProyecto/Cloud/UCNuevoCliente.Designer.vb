Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCNuevoCliente
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCNuevoCliente))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnroDocumento = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboNroTrab = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboHorarioLab = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboSector = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cbotipoempresa = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNomCorto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtPeriodoCierre = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboProductosSoftpack = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cmAdministrar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.btGrabar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.rbUnidManual = New System.Windows.Forms.RadioButton()
        Me.rbUnidGeneral = New System.Windows.Forms.RadioButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtDir = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtFono1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtFono2 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtPaginaWeb = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtApellidos = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNombres = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnroDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazonSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNroTrab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboHorarioLab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbotipoempresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomCorto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodoCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProductosSoftpack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmAdministrar.SuspendLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFono1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFono2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaginaWeb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApellidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox3)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(1011, 22)
        Me.PanelError.TabIndex = 410
        Me.PanelError.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(992, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 288
        Me.PictureBox3.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(186, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Items.AddRange(New Object() {"RUC", "DNI", "PASSAPORTE", "CARNET DE EXTRANJERIA"})
        Me.cboTipoDoc.Location = New System.Drawing.Point(46, 99)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(186, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 418
        Me.cboTipoDoc.Text = "RUC"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(43, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 421
        Me.Label2.Text = "Tipo Doc.:"
        '
        'txtnroDocumento
        '
        Me.txtnroDocumento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtnroDocumento.BeforeTouchSize = New System.Drawing.Size(429, 20)
        Me.txtnroDocumento.BorderColor = System.Drawing.Color.Silver
        Me.txtnroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnroDocumento.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnroDocumento.Location = New System.Drawing.Point(238, 98)
        Me.txtnroDocumento.MaxLength = 11
        Me.txtnroDocumento.Metrocolor = System.Drawing.Color.Silver
        Me.txtnroDocumento.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtnroDocumento.Name = "txtnroDocumento"
        Me.txtnroDocumento.Size = New System.Drawing.Size(216, 20)
        Me.txtnroDocumento.TabIndex = 419
        Me.txtnroDocumento.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(235, 78)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(88, 14)
        Me.Label32.TabIndex = 420
        Me.Label32.Text = "Nro. documento:"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRazonSocial.BeforeTouchSize = New System.Drawing.Size(429, 20)
        Me.txtRazonSocial.BorderColor = System.Drawing.Color.Silver
        Me.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRazonSocial.Location = New System.Drawing.Point(46, 160)
        Me.txtRazonSocial.Metrocolor = System.Drawing.Color.Silver
        Me.txtRazonSocial.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(408, 20)
        Me.txtRazonSocial.TabIndex = 422
        Me.txtRazonSocial.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(43, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 14)
        Me.Label1.TabIndex = 423
        Me.Label1.Text = "Razon Social (sunat)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(234, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 14)
        Me.Label3.TabIndex = 424
        Me.Label3.Text = "Número de Trabajadores"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(43, 263)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 425
        Me.Label4.Text = "Horario laboral"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(43, 326)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 14)
        Me.Label5.TabIndex = 426
        Me.Label5.Text = "Dirección"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(43, 378)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 14)
        Me.Label6.TabIndex = 427
        Me.Label6.Text = "Sector Empresarial"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(232, 377)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 14)
        Me.Label7.TabIndex = 428
        Me.Label7.Text = "Tipo empresa"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(736, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 14)
        Me.Label8.TabIndex = 429
        Me.Label8.Text = "Pagina web"
        '
        'cboNroTrab
        '
        Me.cboNroTrab.BackColor = System.Drawing.Color.White
        Me.cboNroTrab.BeforeTouchSize = New System.Drawing.Size(163, 21)
        Me.cboNroTrab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNroTrab.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNroTrab.Location = New System.Drawing.Point(237, 218)
        Me.cboNroTrab.Name = "cboNroTrab"
        Me.cboNroTrab.Size = New System.Drawing.Size(163, 21)
        Me.cboNroTrab.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboNroTrab.TabIndex = 430
        '
        'cboHorarioLab
        '
        Me.cboHorarioLab.BackColor = System.Drawing.Color.White
        Me.cboHorarioLab.BeforeTouchSize = New System.Drawing.Size(186, 21)
        Me.cboHorarioLab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHorarioLab.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHorarioLab.Location = New System.Drawing.Point(46, 281)
        Me.cboHorarioLab.Name = "cboHorarioLab"
        Me.cboHorarioLab.Size = New System.Drawing.Size(186, 21)
        Me.cboHorarioLab.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboHorarioLab.TabIndex = 431
        '
        'cboSector
        '
        Me.cboSector.BackColor = System.Drawing.Color.White
        Me.cboSector.BeforeTouchSize = New System.Drawing.Size(186, 21)
        Me.cboSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSector.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSector.Location = New System.Drawing.Point(46, 398)
        Me.cboSector.Name = "cboSector"
        Me.cboSector.Size = New System.Drawing.Size(186, 21)
        Me.cboSector.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboSector.TabIndex = 433
        '
        'cbotipoempresa
        '
        Me.cbotipoempresa.BackColor = System.Drawing.Color.White
        Me.cbotipoempresa.BeforeTouchSize = New System.Drawing.Size(212, 21)
        Me.cbotipoempresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotipoempresa.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotipoempresa.Location = New System.Drawing.Point(238, 398)
        Me.cbotipoempresa.Name = "cbotipoempresa"
        Me.cbotipoempresa.Size = New System.Drawing.Size(212, 21)
        Me.cbotipoempresa.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbotipoempresa.TabIndex = 434
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(533, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 20)
        Me.Label9.TabIndex = 436
        Me.Label9.Text = "Datos del Contacto"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(146, 20)
        Me.Label10.TabIndex = 438
        Me.Label10.Text = "Datos de la empresa"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(557, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 14)
        Me.Label11.TabIndex = 439
        Me.Label11.Text = "Nombres"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(557, 123)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 14)
        Me.Label12.TabIndex = 441
        Me.Label12.Text = "Apellidos"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(652, 181)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 14)
        Me.Label13.TabIndex = 445
        Me.Label13.Text = "Telefono 2"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(557, 181)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 14)
        Me.Label14.TabIndex = 443
        Me.Label14.Text = "Telefono 1"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(43, 198)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 14)
        Me.Label15.TabIndex = 448
        Me.Label15.Text = "Nombre corto"
        '
        'txtNomCorto
        '
        Me.txtNomCorto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNomCorto.BeforeTouchSize = New System.Drawing.Size(429, 20)
        Me.txtNomCorto.BorderColor = System.Drawing.Color.Silver
        Me.txtNomCorto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNomCorto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomCorto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNomCorto.Location = New System.Drawing.Point(46, 218)
        Me.txtNomCorto.MaxLength = 50
        Me.txtNomCorto.Metrocolor = System.Drawing.Color.Silver
        Me.txtNomCorto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNomCorto.Name = "txtNomCorto"
        Me.txtNomCorto.Size = New System.Drawing.Size(185, 20)
        Me.txtNomCorto.TabIndex = 449
        Me.txtNomCorto.TabStop = False
        Me.txtNomCorto.Text = "CONTACTO"
        '
        'txtPeriodoCierre
        '
        Me.txtPeriodoCierre.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtPeriodoCierre.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodoCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodoCierre.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtPeriodoCierre.Checked = False
        Me.txtPeriodoCierre.CustomFormat = "MM/yyyy"
        Me.txtPeriodoCierre.DropDownImage = Nothing
        Me.txtPeriodoCierre.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodoCierre.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodoCierre.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtPeriodoCierre.Enabled = False
        Me.txtPeriodoCierre.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodoCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtPeriodoCierre.Location = New System.Drawing.Point(770, 260)
        Me.txtPeriodoCierre.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodoCierre.MinValue = New Date(CType(0, Long))
        Me.txtPeriodoCierre.Name = "txtPeriodoCierre"
        Me.txtPeriodoCierre.ShowCheckBox = False
        Me.txtPeriodoCierre.ShowDropButton = False
        Me.txtPeriodoCierre.ShowUpDown = True
        Me.txtPeriodoCierre.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodoCierre.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodoCierre.TabIndex = 452
        Me.txtPeriodoCierre.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        Me.txtPeriodoCierre.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(767, 243)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 13)
        Me.Label17.TabIndex = 453
        Me.Label17.Text = "Cierre"
        Me.Label17.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(668, 243)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 451
        Me.Label16.Text = "Inicio de oper."
        Me.Label16.Visible = False
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtPeriodo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtPeriodo.Checked = False
        Me.txtPeriodo.CustomFormat = "MM/yyyy"
        Me.txtPeriodo.DropDownImage = Nothing
        Me.txtPeriodo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtPeriodo.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtPeriodo.Location = New System.Drawing.Point(671, 262)
        Me.txtPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.MinValue = New Date(CType(0, Long))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ShowCheckBox = False
        Me.txtPeriodo.ShowDropButton = False
        Me.txtPeriodo.ShowUpDown = True
        Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.TabIndex = 450
        Me.txtPeriodo.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        Me.txtPeriodo.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(557, 243)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(95, 14)
        Me.Label18.TabIndex = 454
        Me.Label18.Text = "Producto de venta"
        '
        'cboProductosSoftpack
        '
        Me.cboProductosSoftpack.BackColor = System.Drawing.Color.White
        Me.cboProductosSoftpack.BeforeTouchSize = New System.Drawing.Size(92, 21)
        Me.cboProductosSoftpack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProductosSoftpack.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProductosSoftpack.Location = New System.Drawing.Point(560, 263)
        Me.cboProductosSoftpack.Name = "cboProductosSoftpack"
        Me.cboProductosSoftpack.Size = New System.Drawing.Size(92, 21)
        Me.cboProductosSoftpack.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboProductosSoftpack.TabIndex = 455
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(158, 41)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(831, 387)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(158, 41)
        Me.ButtonAdv1.TabIndex = 456
        Me.ButtonAdv1.Text = "Grabar Usuario"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'cmAdministrar
        '
        Me.cmAdministrar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.EditarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.cmAdministrar.Name = "cmAdministrar"
        Me.cmAdministrar.Size = New System.Drawing.Size(118, 70)
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(432, 160)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 620
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'btGrabar
        '
        Me.btGrabar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.btGrabar.BeforeTouchSize = New System.Drawing.Size(166, 41)
        Me.btGrabar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGrabar.ForeColor = System.Drawing.Color.White
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btGrabar.IsBackStageButton = False
        Me.btGrabar.Location = New System.Drawing.Point(659, 387)
        Me.btGrabar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(166, 41)
        Me.btGrabar.TabIndex = 447
        Me.btGrabar.Text = "Grabar Empresa"
        Me.btGrabar.UseVisualStyle = True
        '
        'rbUnidManual
        '
        Me.rbUnidManual.AutoSize = True
        Me.rbUnidManual.Checked = True
        Me.rbUnidManual.Enabled = False
        Me.rbUnidManual.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbUnidManual.Location = New System.Drawing.Point(805, 307)
        Me.rbUnidManual.Name = "rbUnidManual"
        Me.rbUnidManual.Size = New System.Drawing.Size(62, 18)
        Me.rbUnidManual.TabIndex = 623
        Me.rbUnidManual.TabStop = True
        Me.rbUnidManual.Text = "Manual"
        Me.rbUnidManual.UseVisualStyleBackColor = True
        '
        'rbUnidGeneral
        '
        Me.rbUnidGeneral.AutoSize = True
        Me.rbUnidGeneral.Enabled = False
        Me.rbUnidGeneral.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbUnidGeneral.Location = New System.Drawing.Point(715, 309)
        Me.rbUnidGeneral.Name = "rbUnidGeneral"
        Me.rbUnidGeneral.Size = New System.Drawing.Size(64, 18)
        Me.rbUnidGeneral.TabIndex = 622
        Me.rbUnidGeneral.Text = "General"
        Me.rbUnidGeneral.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(557, 311)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(136, 14)
        Me.Label20.TabIndex = 621
        Me.Label20.Text = "Unidad Organica de Apoyo"
        '
        'txtDir
        '
        Me.txtDir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDir.BeforeTouchSize = New System.Drawing.Size(429, 20)
        Me.txtDir.BorderColor = System.Drawing.Color.Silver
        Me.txtDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDir.Location = New System.Drawing.Point(46, 346)
        Me.txtDir.Metrocolor = System.Drawing.Color.Silver
        Me.txtDir.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDir.Name = "txtDir"
        Me.txtDir.Size = New System.Drawing.Size(408, 20)
        Me.txtDir.TabIndex = 624
        Me.txtDir.TabStop = False
        '
        'txtFono1
        '
        Me.txtFono1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFono1.BeforeTouchSize = New System.Drawing.Size(429, 20)
        Me.txtFono1.BorderColor = System.Drawing.Color.Silver
        Me.txtFono1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFono1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFono1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFono1.Location = New System.Drawing.Point(560, 198)
        Me.txtFono1.Metrocolor = System.Drawing.Color.Silver
        Me.txtFono1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFono1.Name = "txtFono1"
        Me.txtFono1.Size = New System.Drawing.Size(89, 20)
        Me.txtFono1.TabIndex = 625
        Me.txtFono1.TabStop = False
        '
        'txtFono2
        '
        Me.txtFono2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFono2.BeforeTouchSize = New System.Drawing.Size(429, 20)
        Me.txtFono2.BorderColor = System.Drawing.Color.Silver
        Me.txtFono2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFono2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFono2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFono2.Location = New System.Drawing.Point(655, 198)
        Me.txtFono2.Metrocolor = System.Drawing.Color.Silver
        Me.txtFono2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFono2.Name = "txtFono2"
        Me.txtFono2.Size = New System.Drawing.Size(75, 20)
        Me.txtFono2.TabIndex = 626
        Me.txtFono2.TabStop = False
        '
        'txtPaginaWeb
        '
        Me.txtPaginaWeb.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPaginaWeb.BeforeTouchSize = New System.Drawing.Size(429, 20)
        Me.txtPaginaWeb.BorderColor = System.Drawing.Color.Silver
        Me.txtPaginaWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaginaWeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaginaWeb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaginaWeb.Location = New System.Drawing.Point(739, 198)
        Me.txtPaginaWeb.Metrocolor = System.Drawing.Color.Silver
        Me.txtPaginaWeb.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtPaginaWeb.Name = "txtPaginaWeb"
        Me.txtPaginaWeb.Size = New System.Drawing.Size(250, 20)
        Me.txtPaginaWeb.TabIndex = 627
        Me.txtPaginaWeb.TabStop = False
        '
        'txtApellidos
        '
        Me.txtApellidos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtApellidos.BeforeTouchSize = New System.Drawing.Size(429, 20)
        Me.txtApellidos.BorderColor = System.Drawing.Color.Silver
        Me.txtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtApellidos.Location = New System.Drawing.Point(560, 140)
        Me.txtApellidos.Metrocolor = System.Drawing.Color.Silver
        Me.txtApellidos.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.Size = New System.Drawing.Size(429, 20)
        Me.txtApellidos.TabIndex = 628
        Me.txtApellidos.TabStop = False
        '
        'txtNombres
        '
        Me.txtNombres.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNombres.BeforeTouchSize = New System.Drawing.Size(429, 20)
        Me.txtNombres.BorderColor = System.Drawing.Color.Silver
        Me.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombres.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNombres.Location = New System.Drawing.Point(560, 85)
        Me.txtNombres.Metrocolor = System.Drawing.Color.Silver
        Me.txtNombres.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(429, 20)
        Me.txtNombres.TabIndex = 629
        Me.txtNombres.TabStop = False
        '
        'UCNuevoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 45
        CaptionImage1.BackColor = System.Drawing.Color.White
        CaptionImage1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.almacen
        CaptionImage1.Location = New System.Drawing.Point(15, 2)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(45, 45)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(65, 4)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Empresa"
        CaptionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.Location = New System.Drawing.Point(65, 20)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(300, 24)
        CaptionLabel2.Text = "Lista de Empresas"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(1011, 440)
        Me.Controls.Add(Me.txtNombres)
        Me.Controls.Add(Me.txtApellidos)
        Me.Controls.Add(Me.txtPaginaWeb)
        Me.Controls.Add(Me.txtFono2)
        Me.Controls.Add(Me.txtFono1)
        Me.Controls.Add(Me.txtDir)
        Me.Controls.Add(Me.rbUnidManual)
        Me.Controls.Add(Me.rbUnidGeneral)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.PictureLoad)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.cboProductosSoftpack)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtPeriodoCierre)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.txtNomCorto)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btGrabar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbotipoempresa)
        Me.Controls.Add(Me.cboSector)
        Me.Controls.Add(Me.cboHorarioLab)
        Me.Controls.Add(Me.cboNroTrab)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRazonSocial)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtnroDocumento)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.PanelError)
        Me.Name = "UCNuevoCliente"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnroDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazonSocial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNroTrab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboHorarioLab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbotipoempresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomCorto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodoCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProductosSoftpack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmAdministrar.ResumeLayout(False)
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFono1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFono2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaginaWeb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApellidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelError As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents cboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents txtnroDocumento As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label32 As Label
    Friend WithEvents txtRazonSocial As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cboNroTrab As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboHorarioLab As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboSector As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cbotipoempresa As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents btGrabar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label15 As Label
    Friend WithEvents txtNomCorto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtPeriodoCierre As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents cboProductosSoftpack As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label18 As Label
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents PictureLoad As PictureBox
    Friend WithEvents cmAdministrar As ContextMenuStrip
    Friend WithEvents NuevoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents rbUnidManual As RadioButton
    Friend WithEvents rbUnidGeneral As RadioButton
    Friend WithEvents Label20 As Label
    Friend WithEvents txtNombres As Tools.TextBoxExt
    Friend WithEvents txtApellidos As Tools.TextBoxExt
    Friend WithEvents txtPaginaWeb As Tools.TextBoxExt
    Friend WithEvents txtFono2 As Tools.TextBoxExt
    Friend WithEvents txtFono1 As Tools.TextBoxExt
    Friend WithEvents txtDir As Tools.TextBoxExt
End Class

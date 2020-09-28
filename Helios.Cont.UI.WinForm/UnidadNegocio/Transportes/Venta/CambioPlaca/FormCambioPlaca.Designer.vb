<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCambioPlaca
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCambioPlaca))
        Me.pnBuscardor = New System.Windows.Forms.Panel()
        Me.BtConfirmarVenta = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.pnHora = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNuevaHora = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNuevaFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.lblTotalAsientos = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chBoxProgramacion = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtEdad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.lblReserva = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblVendedios = New System.Windows.Forms.Label()
        Me.lblLibres = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel49 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel50 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextRuta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextFechaProgramada = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.TextHora = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.cboActivosFijos = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.pnBuscardor.SuspendLayout()
        Me.pnHora.SuspendLayout()
        CType(Me.txtNuevaHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNuevaFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtEdad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboActivosFijos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnBuscardor
        '
        Me.pnBuscardor.BackColor = System.Drawing.Color.White
        Me.pnBuscardor.Controls.Add(Me.BtConfirmarVenta)
        Me.pnBuscardor.Controls.Add(Me.pnHora)
        Me.pnBuscardor.Controls.Add(Me.lblTotalAsientos)
        Me.pnBuscardor.Controls.Add(Me.Label11)
        Me.pnBuscardor.Controls.Add(Me.Panel2)
        Me.pnBuscardor.Controls.Add(Me.Label13)
        Me.pnBuscardor.Controls.Add(Me.chBoxProgramacion)
        Me.pnBuscardor.Controls.Add(Me.Label7)
        Me.pnBuscardor.Controls.Add(Me.Label6)
        Me.pnBuscardor.Controls.Add(Me.Panel1)
        Me.pnBuscardor.Controls.Add(Me.cboActivosFijos)
        Me.pnBuscardor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBuscardor.Location = New System.Drawing.Point(0, 0)
        Me.pnBuscardor.Name = "pnBuscardor"
        Me.pnBuscardor.Size = New System.Drawing.Size(735, 539)
        Me.pnBuscardor.TabIndex = 692
        Me.pnBuscardor.Visible = False
        '
        'BtConfirmarVenta
        '
        Me.BtConfirmarVenta.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.BtConfirmarVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.BtConfirmarVenta.BeforeTouchSize = New System.Drawing.Size(298, 40)
        Me.BtConfirmarVenta.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BtConfirmarVenta.ForeColor = System.Drawing.Color.White
        Me.BtConfirmarVenta.IsBackStageButton = False
        Me.BtConfirmarVenta.Location = New System.Drawing.Point(414, 392)
        Me.BtConfirmarVenta.Name = "BtConfirmarVenta"
        Me.BtConfirmarVenta.Size = New System.Drawing.Size(298, 40)
        Me.BtConfirmarVenta.TabIndex = 727
        Me.BtConfirmarVenta.Text = "Confirmar cambio"
        Me.BtConfirmarVenta.UseVisualStyle = True
        '
        'pnHora
        '
        Me.pnHora.Controls.Add(Me.Label14)
        Me.pnHora.Controls.Add(Me.txtNuevaHora)
        Me.pnHora.Controls.Add(Me.Label15)
        Me.pnHora.Controls.Add(Me.txtNuevaFecha)
        Me.pnHora.Enabled = False
        Me.pnHora.Location = New System.Drawing.Point(414, 236)
        Me.pnHora.Name = "pnHora"
        Me.pnHora.Size = New System.Drawing.Size(298, 123)
        Me.pnHora.TabIndex = 726
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label14.Location = New System.Drawing.Point(3, 4)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 19)
        Me.Label14.TabIndex = 722
        Me.Label14.Text = "Fecha"
        '
        'txtNuevaHora
        '
        Me.txtNuevaHora.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtNuevaHora.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNuevaHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNuevaHora.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtNuevaHora.Checked = False
        Me.txtNuevaHora.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtNuevaHora.CustomFormat = "HH:mm tt"
        Me.txtNuevaHora.DropDownImage = Nothing
        Me.txtNuevaHora.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtNuevaHora.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtNuevaHora.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtNuevaHora.EnableNullDate = False
        Me.txtNuevaHora.EnableNullKeys = False
        Me.txtNuevaHora.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtNuevaHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtNuevaHora.Location = New System.Drawing.Point(3, 89)
        Me.txtNuevaHora.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtNuevaHora.MinValue = New Date(CType(0, Long))
        Me.txtNuevaHora.Name = "txtNuevaHora"
        Me.txtNuevaHora.ShowCheckBox = False
        Me.txtNuevaHora.ShowDropButton = False
        Me.txtNuevaHora.ShowUpDown = True
        Me.txtNuevaHora.Size = New System.Drawing.Size(147, 25)
        Me.txtNuevaHora.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtNuevaHora.TabIndex = 725
        Me.txtNuevaHora.Value = New Date(2020, 1, 3, 11, 17, 0, 0)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label15.Location = New System.Drawing.Point(3, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 19)
        Me.Label15.TabIndex = 723
        Me.Label15.Text = "Hora"
        '
        'txtNuevaFecha
        '
        Me.txtNuevaFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtNuevaFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNuevaFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNuevaFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtNuevaFecha.Checked = False
        Me.txtNuevaFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtNuevaFecha.CustomFormat = "dd/MM/yyyy"
        Me.txtNuevaFecha.DropDownImage = Nothing
        Me.txtNuevaFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtNuevaFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtNuevaFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtNuevaFecha.EnableNullDate = False
        Me.txtNuevaFecha.EnableNullKeys = False
        Me.txtNuevaFecha.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtNuevaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtNuevaFecha.Location = New System.Drawing.Point(3, 23)
        Me.txtNuevaFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtNuevaFecha.MinValue = New Date(CType(0, Long))
        Me.txtNuevaFecha.Name = "txtNuevaFecha"
        Me.txtNuevaFecha.ShowCheckBox = False
        Me.txtNuevaFecha.ShowUpDownOnFocus = True
        Me.txtNuevaFecha.Size = New System.Drawing.Size(243, 25)
        Me.txtNuevaFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtNuevaFecha.TabIndex = 724
        Me.txtNuevaFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'lblTotalAsientos
        '
        Me.lblTotalAsientos.AutoSize = True
        Me.lblTotalAsientos.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalAsientos.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAsientos.ForeColor = System.Drawing.Color.Black
        Me.lblTotalAsientos.Location = New System.Drawing.Point(563, 147)
        Me.lblTotalAsientos.Name = "lblTotalAsientos"
        Me.lblTotalAsientos.Size = New System.Drawing.Size(29, 17)
        Me.lblTotalAsientos.TabIndex = 721
        Me.lblTotalAsientos.Text = "(0)"
        Me.lblTotalAsientos.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(411, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(143, 14)
        Me.Label11.TabIndex = 720
        Me.Label11.Text = "Condiciòn de Asientos"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel2.Location = New System.Drawing.Point(414, 135)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(42, 47)
        Me.Panel2.TabIndex = 718
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(459, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 17)
        Me.Label13.TabIndex = 719
        Me.Label13.Text = "Total Asientos"
        '
        'chBoxProgramacion
        '
        Me.chBoxProgramacion.BackColor = System.Drawing.Color.White
        Me.chBoxProgramacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chBoxProgramacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chBoxProgramacion.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.chBoxProgramacion.ForeColor = System.Drawing.Color.Black
        Me.chBoxProgramacion.Location = New System.Drawing.Point(414, 195)
        Me.chBoxProgramacion.Name = "chBoxProgramacion"
        Me.chBoxProgramacion.Size = New System.Drawing.Size(298, 35)
        Me.chBoxProgramacion.TabIndex = 714
        Me.chBoxProgramacion.Text = "Crear nueva programacion"
        Me.chBoxProgramacion.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label7.Location = New System.Drawing.Point(411, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 18)
        Me.Label7.TabIndex = 713
        Me.Label7.Text = "SELECCION DE BUS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(414, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 19)
        Me.Label6.TabIndex = 712
        Me.Label6.Text = "Bus - Placa"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtEdad)
        Me.Panel1.Controls.Add(Me.lblReserva)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.lblVendedios)
        Me.Panel1.Controls.Add(Me.lblLibres)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Panel49)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Panel50)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TextRuta)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TextFechaProgramada)
        Me.Panel1.Controls.Add(Me.TextHora)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(397, 539)
        Me.Panel1.TabIndex = 710
        '
        'txtEdad
        '
        Me.txtEdad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtEdad.BeforeTouchSize = New System.Drawing.Size(358, 30)
        Me.txtEdad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEdad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEdad.CornerRadius = 3
        Me.txtEdad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtEdad.Enabled = False
        Me.txtEdad.Font = New System.Drawing.Font("Calibri Light", 12.0!)
        Me.txtEdad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEdad.Location = New System.Drawing.Point(29, 277)
        Me.txtEdad.MaxLength = 8
        Me.txtEdad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtEdad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.NearImage = CType(resources.GetObject("txtEdad.NearImage"), System.Drawing.Image)
        Me.txtEdad.Size = New System.Drawing.Size(188, 27)
        Me.txtEdad.TabIndex = 722
        '
        'lblReserva
        '
        Me.lblReserva.AutoSize = True
        Me.lblReserva.BackColor = System.Drawing.Color.Transparent
        Me.lblReserva.Enabled = False
        Me.lblReserva.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblReserva.ForeColor = System.Drawing.Color.Black
        Me.lblReserva.Location = New System.Drawing.Point(243, 415)
        Me.lblReserva.Name = "lblReserva"
        Me.lblReserva.Size = New System.Drawing.Size(29, 17)
        Me.lblReserva.TabIndex = 721
        Me.lblReserva.Text = "(0)"
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.reservado4
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel4.Enabled = False
        Me.Panel4.Location = New System.Drawing.Point(28, 407)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(42, 47)
        Me.Panel4.TabIndex = 720
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Enabled = False
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(73, 415)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(146, 17)
        Me.Label19.TabIndex = 719
        Me.Label19.Text = "Asientos  Reservados"
        '
        'lblVendedios
        '
        Me.lblVendedios.AutoSize = True
        Me.lblVendedios.BackColor = System.Drawing.Color.Transparent
        Me.lblVendedios.Enabled = False
        Me.lblVendedios.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblVendedios.ForeColor = System.Drawing.Color.Black
        Me.lblVendedios.Location = New System.Drawing.Point(201, 486)
        Me.lblVendedios.Name = "lblVendedios"
        Me.lblVendedios.Size = New System.Drawing.Size(29, 17)
        Me.lblVendedios.TabIndex = 718
        Me.lblVendedios.Text = "(0)"
        '
        'lblLibres
        '
        Me.lblLibres.AutoSize = True
        Me.lblLibres.BackColor = System.Drawing.Color.Transparent
        Me.lblLibres.Enabled = False
        Me.lblLibres.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblLibres.ForeColor = System.Drawing.Color.Black
        Me.lblLibres.Location = New System.Drawing.Point(178, 355)
        Me.lblLibres.Name = "lblLibres"
        Me.lblLibres.Size = New System.Drawing.Size(29, 17)
        Me.lblLibres.TabIndex = 717
        Me.lblLibres.Text = "(0)"
        Me.lblLibres.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Enabled = False
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(26, 322)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(143, 14)
        Me.Label12.TabIndex = 716
        Me.Label12.Text = "Condiciòn de Asientos"
        '
        'Panel49
        '
        Me.Panel49.BackgroundImage = CType(resources.GetObject("Panel49.BackgroundImage"), System.Drawing.Image)
        Me.Panel49.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel49.Enabled = False
        Me.Panel49.Location = New System.Drawing.Point(29, 343)
        Me.Panel49.Name = "Panel49"
        Me.Panel49.Size = New System.Drawing.Size(42, 47)
        Me.Panel49.TabIndex = 710
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Enabled = False
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(74, 355)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 17)
        Me.Label8.TabIndex = 712
        Me.Label8.Text = "Total Asientos"
        '
        'Panel50
        '
        Me.Panel50.BackgroundImage = CType(resources.GetObject("Panel50.BackgroundImage"), System.Drawing.Image)
        Me.Panel50.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel50.Enabled = False
        Me.Panel50.Location = New System.Drawing.Point(29, 471)
        Me.Panel50.Name = "Panel50"
        Me.Panel50.Size = New System.Drawing.Size(42, 47)
        Me.Panel50.TabIndex = 714
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(70, 486)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 17)
        Me.Label9.TabIndex = 711
        Me.Label9.Text = "Asientos Vendidos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(223, 18)
        Me.Label4.TabIndex = 704
        Me.Label4.Text = "PROGRAMACION SELECIONADO"
        '
        'TextRuta
        '
        Me.TextRuta.BackColor = System.Drawing.Color.White
        Me.TextRuta.BeforeTouchSize = New System.Drawing.Size(358, 30)
        Me.TextRuta.BorderColor = System.Drawing.Color.Silver
        Me.TextRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRuta.CornerRadius = 3
        Me.TextRuta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextRuta.Enabled = False
        Me.TextRuta.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextRuta.Font = New System.Drawing.Font("Calibri Light", 12.0!)
        Me.TextRuta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRuta.Location = New System.Drawing.Point(29, 62)
        Me.TextRuta.MaxLength = 70
        Me.TextRuta.Metrocolor = System.Drawing.Color.Silver
        Me.TextRuta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuta.Multiline = True
        Me.TextRuta.Name = "TextRuta"
        Me.TextRuta.NearImage = CType(resources.GetObject("TextRuta.NearImage"), System.Drawing.Image)
        Me.TextRuta.Size = New System.Drawing.Size(358, 30)
        Me.TextRuta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextRuta.TabIndex = 699
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(29, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 698
        Me.Label2.Text = "Ruta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(29, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 19)
        Me.Label1.TabIndex = 700
        Me.Label1.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(29, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 19)
        Me.Label3.TabIndex = 701
        Me.Label3.Text = "Hora"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(29, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 19)
        Me.Label5.TabIndex = 705
        Me.Label5.Text = "Bus - Placa"
        '
        'TextFechaProgramada
        '
        Me.TextFechaProgramada.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaProgramada.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaProgramada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaProgramada.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaProgramada.Checked = False
        Me.TextFechaProgramada.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaProgramada.CustomFormat = "dd/MM/yyyy"
        Me.TextFechaProgramada.DropDownImage = Nothing
        Me.TextFechaProgramada.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaProgramada.Enabled = False
        Me.TextFechaProgramada.EnableNullDate = False
        Me.TextFechaProgramada.EnableNullKeys = False
        Me.TextFechaProgramada.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TextFechaProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaProgramada.Location = New System.Drawing.Point(29, 129)
        Me.TextFechaProgramada.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.MinValue = New Date(CType(0, Long))
        Me.TextFechaProgramada.Name = "TextFechaProgramada"
        Me.TextFechaProgramada.ShowCheckBox = False
        Me.TextFechaProgramada.ShowUpDownOnFocus = True
        Me.TextFechaProgramada.Size = New System.Drawing.Size(243, 25)
        Me.TextFechaProgramada.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaProgramada.TabIndex = 702
        Me.TextFechaProgramada.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'TextHora
        '
        Me.TextHora.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextHora.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextHora.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextHora.Checked = False
        Me.TextHora.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextHora.CustomFormat = "HH:mm tt"
        Me.TextHora.DropDownImage = Nothing
        Me.TextHora.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextHora.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextHora.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextHora.Enabled = False
        Me.TextHora.EnableNullDate = False
        Me.TextHora.EnableNullKeys = False
        Me.TextHora.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TextHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextHora.Location = New System.Drawing.Point(29, 195)
        Me.TextHora.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextHora.MinValue = New Date(CType(0, Long))
        Me.TextHora.Name = "TextHora"
        Me.TextHora.ShowCheckBox = False
        Me.TextHora.ShowDropButton = False
        Me.TextHora.ShowUpDown = True
        Me.TextHora.Size = New System.Drawing.Size(147, 25)
        Me.TextHora.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextHora.TabIndex = 703
        Me.TextHora.Value = New Date(2020, 1, 3, 11, 17, 0, 0)
        '
        'cboActivosFijos
        '
        Me.cboActivosFijos.BackColor = System.Drawing.Color.White
        Me.cboActivosFijos.BeforeTouchSize = New System.Drawing.Size(243, 29)
        Me.cboActivosFijos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActivosFijos.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cboActivosFijos.Location = New System.Drawing.Point(414, 64)
        Me.cboActivosFijos.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboActivosFijos.Name = "cboActivosFijos"
        Me.cboActivosFijos.Size = New System.Drawing.Size(243, 29)
        Me.cboActivosFijos.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboActivosFijos.TabIndex = 697
        Me.cboActivosFijos.Visible = False
        '
        'FormCambioPlaca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 539)
        Me.Controls.Add(Me.pnBuscardor)
        Me.Name = "FormCambioPlaca"
        Me.Text = "CambioPlaca"
        Me.pnBuscardor.ResumeLayout(False)
        Me.pnBuscardor.PerformLayout()
        Me.pnHora.ResumeLayout(False)
        Me.pnHora.PerformLayout()
        CType(Me.txtNuevaHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNuevaFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtEdad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboActivosFijos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnBuscardor As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents TextRuta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextFechaProgramada As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents cboActivosFijos As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents TextHora As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblReserva As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents lblVendedios As Label
    Friend WithEvents lblLibres As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel49 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel50 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents pnHora As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents txtNuevaHora As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label15 As Label
    Friend WithEvents txtNuevaFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents lblTotalAsientos As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents chBoxProgramacion As CheckBox
    Friend WithEvents txtEdad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BtConfirmarVenta As RoundButton2
End Class

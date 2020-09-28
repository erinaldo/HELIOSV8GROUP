Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabP_IdentificacionCliente
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim BannerTextInfo4 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabP_IdentificacionCliente))
        Dim BannerTextInfo5 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo6 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.TextNumIdentrazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.textDireccion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtTipo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.RoundButton26 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblEstadoCliente = New System.Windows.Forms.Label()
        Me.RoundButton25 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton24 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton23 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Line24 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.Line23 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Line22 = New Helios.Cont.Presentation.WinForm.Line2()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(30, 40)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'TextNumIdentrazon
        '
        Me.TextNumIdentrazon.BackColor = System.Drawing.Color.White
        BannerTextInfo4.Mode = Syncfusion.Windows.Forms.BannerTextMode.EditMode
        BannerTextInfo4.Text = "DNI"
        BannerTextInfo4.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextNumIdentrazon, BannerTextInfo4)
        Me.TextNumIdentrazon.BeforeTouchSize = New System.Drawing.Size(351, 52)
        Me.TextNumIdentrazon.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumIdentrazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIdentrazon.CornerRadius = 8
        Me.TextNumIdentrazon.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumIdentrazon.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNumIdentrazon.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIdentrazon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNumIdentrazon.Location = New System.Drawing.Point(646, 221)
        Me.TextNumIdentrazon.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.MinimumSize = New System.Drawing.Size(26, 22)
        Me.TextNumIdentrazon.Name = "TextNumIdentrazon"
        Me.TextNumIdentrazon.NearImage = CType(resources.GetObject("TextNumIdentrazon.NearImage"), System.Drawing.Image)
        Me.TextNumIdentrazon.Size = New System.Drawing.Size(351, 26)
        Me.TextNumIdentrazon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNumIdentrazon.TabIndex = 702
        Me.TextNumIdentrazon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextProveedor
        '
        Me.TextProveedor.BackColor = System.Drawing.Color.White
        Me.TextProveedor.BeforeTouchSize = New System.Drawing.Size(351, 52)
        Me.TextProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProveedor.CornerRadius = 8
        Me.TextProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextProveedor.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextProveedor.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextProveedor.Location = New System.Drawing.Point(646, 265)
        Me.TextProveedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProveedor.MinimumSize = New System.Drawing.Size(26, 22)
        Me.TextProveedor.Multiline = True
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.NearImage = CType(resources.GetObject("TextProveedor.NearImage"), System.Drawing.Image)
        Me.TextProveedor.Size = New System.Drawing.Size(351, 52)
        Me.TextProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextProveedor.TabIndex = 747
        Me.TextProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textDireccion
        '
        Me.textDireccion.BackColor = System.Drawing.Color.White
        BannerTextInfo5.Mode = Syncfusion.Windows.Forms.BannerTextMode.EditMode
        BannerTextInfo5.Text = "DNI"
        BannerTextInfo5.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.textDireccion, BannerTextInfo5)
        Me.textDireccion.BeforeTouchSize = New System.Drawing.Size(351, 52)
        Me.textDireccion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.textDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textDireccion.CornerRadius = 8
        Me.textDireccion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.textDireccion.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.textDireccion.Font = New System.Drawing.Font("Calibri Light", 12.0!)
        Me.textDireccion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.textDireccion.Location = New System.Drawing.Point(608, 543)
        Me.textDireccion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.textDireccion.MinimumSize = New System.Drawing.Size(26, 22)
        Me.textDireccion.Name = "textDireccion"
        Me.textDireccion.NearImage = CType(resources.GetObject("textDireccion.NearImage"), System.Drawing.Image)
        Me.textDireccion.Size = New System.Drawing.Size(315, 27)
        Me.textDireccion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.textDireccion.TabIndex = 760
        Me.textDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.textDireccion.Visible = False
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.Color.White
        BannerTextInfo6.Mode = Syncfusion.Windows.Forms.BannerTextMode.EditMode
        BannerTextInfo6.Text = "DNI"
        BannerTextInfo6.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtTipo, BannerTextInfo6)
        Me.txtTipo.BeforeTouchSize = New System.Drawing.Size(351, 52)
        Me.txtTipo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipo.CornerRadius = 8
        Me.txtTipo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipo.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtTipo.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipo.Location = New System.Drawing.Point(1026, 221)
        Me.txtTipo.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTipo.MinimumSize = New System.Drawing.Size(26, 22)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.NearImage = CType(resources.GetObject("txtTipo.NearImage"), System.Drawing.Image)
        Me.txtTipo.Size = New System.Drawing.Size(83, 26)
        Me.txtTipo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipo.TabIndex = 767
        Me.txtTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTipo.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(735, 184)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(211, 25)
        Me.Label10.TabIndex = 693
        Me.Label10.Text = "BUSCAR PERSONA"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel1.Controls.Add(Me.txtTipo)
        Me.Panel1.Controls.Add(Me.PictureBox7)
        Me.Panel1.Controls.Add(Me.PictureBox6)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.RoundButton26)
        Me.Panel1.Controls.Add(Me.textDireccion)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.lblEstadoCliente)
        Me.Panel1.Controls.Add(Me.RoundButton25)
        Me.Panel1.Controls.Add(Me.RoundButton24)
        Me.Panel1.Controls.Add(Me.RoundButton23)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.RoundButton22)
        Me.Panel1.Controls.Add(Me.Line24)
        Me.Panel1.Controls.Add(Me.Line23)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Line22)
        Me.Panel1.Controls.Add(Me.TextProveedor)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.TextNumIdentrazon)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1135, 590)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox7
        '
        Me.PictureBox7.BackgroundImage = CType(resources.GetObject("PictureBox7.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox7.Location = New System.Drawing.Point(352, 350)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(51, 59)
        Me.PictureBox7.TabIndex = 766
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackgroundImage = CType(resources.GetObject("PictureBox6.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox6.Location = New System.Drawing.Point(288, 408)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(51, 59)
        Me.PictureBox6.TabIndex = 765
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImage = CType(resources.GetObject("PictureBox5.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox5.Location = New System.Drawing.Point(210, 451)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(51, 59)
        Me.PictureBox5.TabIndex = 764
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox4.Location = New System.Drawing.Point(128, 408)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(51, 59)
        Me.PictureBox4.TabIndex = 763
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox3.Location = New System.Drawing.Point(61, 350)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(51, 59)
        Me.PictureBox3.TabIndex = 762
        Me.PictureBox3.TabStop = False
        '
        'RoundButton26
        '
        Me.RoundButton26.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton26.BackColor = System.Drawing.Color.CadetBlue
        Me.RoundButton26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.RoundButton26.BeforeTouchSize = New System.Drawing.Size(127, 102)
        Me.RoundButton26.FlatAppearance.BorderSize = 0
        Me.RoundButton26.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton26.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.RoundButton26.ForeColor = System.Drawing.Color.White
        Me.RoundButton26.Image = CType(resources.GetObject("RoundButton26.Image"), System.Drawing.Image)
        Me.RoundButton26.IsBackStageButton = False
        Me.RoundButton26.Location = New System.Drawing.Point(691, 408)
        Me.RoundButton26.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RoundButton26.Name = "RoundButton26"
        Me.RoundButton26.Size = New System.Drawing.Size(127, 102)
        Me.RoundButton26.TabIndex = 761
        Me.RoundButton26.Text = "VENTA DIRECTA"
        Me.RoundButton26.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(163, 225)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(155, 148)
        Me.PictureBox2.TabIndex = 759
        Me.PictureBox2.TabStop = False
        '
        'lblEstadoCliente
        '
        Me.lblEstadoCliente.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEstadoCliente.ForeColor = System.Drawing.Color.Red
        Me.lblEstadoCliente.Location = New System.Drawing.Point(668, 162)
        Me.lblEstadoCliente.Name = "lblEstadoCliente"
        Me.lblEstadoCliente.Size = New System.Drawing.Size(315, 23)
        Me.lblEstadoCliente.TabIndex = 758
        Me.lblEstadoCliente.Text = "ESTADO"
        Me.lblEstadoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEstadoCliente.Visible = False
        '
        'RoundButton25
        '
        Me.RoundButton25.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton25.BackColor = System.Drawing.Color.CadetBlue
        Me.RoundButton25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.RoundButton25.BeforeTouchSize = New System.Drawing.Size(127, 102)
        Me.RoundButton25.FlatAppearance.BorderSize = 0
        Me.RoundButton25.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton25.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.RoundButton25.ForeColor = System.Drawing.Color.White
        Me.RoundButton25.Image = CType(resources.GetObject("RoundButton25.Image"), System.Drawing.Image)
        Me.RoundButton25.IsBackStageButton = False
        Me.RoundButton25.Location = New System.Drawing.Point(957, 408)
        Me.RoundButton25.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RoundButton25.Name = "RoundButton25"
        Me.RoundButton25.Size = New System.Drawing.Size(127, 102)
        Me.RoundButton25.TabIndex = 757
        Me.RoundButton25.Text = "CONTROL"
        Me.RoundButton25.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'RoundButton24
        '
        Me.RoundButton24.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton24.BackColor = System.Drawing.Color.CadetBlue
        Me.RoundButton24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RoundButton24.BeforeTouchSize = New System.Drawing.Size(127, 102)
        Me.RoundButton24.FlatAppearance.BorderSize = 0
        Me.RoundButton24.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton24.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.RoundButton24.ForeColor = System.Drawing.Color.White
        Me.RoundButton24.Image = CType(resources.GetObject("RoundButton24.Image"), System.Drawing.Image)
        Me.RoundButton24.IsBackStageButton = False
        Me.RoundButton24.Location = New System.Drawing.Point(824, 408)
        Me.RoundButton24.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RoundButton24.Name = "RoundButton24"
        Me.RoundButton24.Size = New System.Drawing.Size(127, 102)
        Me.RoundButton24.TabIndex = 756
        Me.RoundButton24.Text = "RESERVACIÓN"
        Me.RoundButton24.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'RoundButton23
        '
        Me.RoundButton23.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton23.BackColor = System.Drawing.Color.CadetBlue
        Me.RoundButton23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.RoundButton23.BeforeTouchSize = New System.Drawing.Size(127, 102)
        Me.RoundButton23.FlatAppearance.BorderSize = 0
        Me.RoundButton23.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton23.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.RoundButton23.ForeColor = System.Drawing.Color.White
        Me.RoundButton23.Image = CType(resources.GetObject("RoundButton23.Image"), System.Drawing.Image)
        Me.RoundButton23.IsBackStageButton = False
        Me.RoundButton23.Location = New System.Drawing.Point(558, 408)
        Me.RoundButton23.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RoundButton23.Name = "RoundButton23"
        Me.RoundButton23.Size = New System.Drawing.Size(127, 102)
        Me.RoundButton23.TabIndex = 755
        Me.RoundButton23.Text = "RECEPCIÓN"
        Me.RoundButton23.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(194, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 30)
        Me.Label1.TabIndex = 754
        Me.Label1.Text = "HOTEL"
        '
        'RoundButton22
        '
        Me.RoundButton22.BackColor = System.Drawing.Color.CadetBlue
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(351, 36)
        Me.RoundButton22.FlatAppearance.BorderSize = 0
        Me.RoundButton22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundButton22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(646, 332)
        Me.RoundButton22.MetroColor = System.Drawing.Color.White
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(351, 36)
        Me.RoundButton22.TabIndex = 753
        Me.RoundButton22.Text = "CONSULTAR"
        '
        'Line24
        '
        Me.Line24.BackColor = System.Drawing.Color.White
        Me.Line24.LineColor = System.Drawing.Color.White
        Me.Line24.Location = New System.Drawing.Point(882, 134)
        Me.Line24.Name = "Line24"
        Me.Line24.Size = New System.Drawing.Size(115, 3)
        Me.Line24.TabIndex = 751
        Me.Line24.Text = "Line24"
        '
        'Line23
        '
        Me.Line23.BackColor = System.Drawing.Color.White
        Me.Line23.LineColor = System.Drawing.Color.White
        Me.Line23.Location = New System.Drawing.Point(646, 134)
        Me.Line23.Name = "Line23"
        Me.Line23.Size = New System.Drawing.Size(115, 3)
        Me.Line23.TabIndex = 750
        Me.Line23.Text = "Line23"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(761, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(121, 104)
        Me.PictureBox1.TabIndex = 749
        Me.PictureBox1.TabStop = False
        '
        'Line22
        '
        Me.Line22.BackColor = System.Drawing.Color.White
        Me.Line22.LineColor = System.Drawing.Color.White
        Me.Line22.Location = New System.Drawing.Point(499, 40)
        Me.Line22.Name = "Line22"
        Me.Line22.Size = New System.Drawing.Size(2, 530)
        Me.Line22.TabIndex = 748
        Me.Line22.Text = "Line22"
        '
        'TabP_IdentificacionCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.Panel1)
        Me.Name = "TabP_IdentificacionCliente"
        Me.Size = New System.Drawing.Size(1135, 590)
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Private WithEvents ToggleConsultas As ToggleButton2
    Private WithEvents Line21 As Line2
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents TextboxJiu1 As TextboxJiu
    Friend WithEvents TextNumIdentrazon As Tools.TextBoxExt
    Friend WithEvents Label10 As Label
    Friend WithEvents TextProveedor As Tools.TextBoxExt
    Friend WithEvents Line22 As Line2
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundButton22 As RoundButton2
    Friend WithEvents Line24 As Line2
    Friend WithEvents Line23 As Line2
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblEstadoCliente As Label
    Friend WithEvents RoundButton25 As RoundButton2
    Friend WithEvents RoundButton24 As RoundButton2
    Friend WithEvents RoundButton23 As RoundButton2
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents textDireccion As Tools.TextBoxExt
    Friend WithEvents RoundButton26 As RoundButton2
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents txtTipo As Tools.TextBoxExt
End Class

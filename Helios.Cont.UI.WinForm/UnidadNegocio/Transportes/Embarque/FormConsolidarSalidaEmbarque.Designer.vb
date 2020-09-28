Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConsolidarSalidaEmbarque
    Inherits MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConsolidarSalidaEmbarque))
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextFechaEmbarque = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.TextFechaProgramada = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.TextNumPasajeros = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCodigoPlaca = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextRuta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextSeriePlaca = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextLicencia2 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextChofer2 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNumIdent2 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextLicencia1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextChofer1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNumIdent1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.licencia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PCChofer2 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.ListChofer2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtdestino = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.RoundButton24 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.CirclePictureBox1 = New Helios.Cont.Presentation.WinForm.CirclePictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNroImpresion = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        CType(Me.TextFechaEmbarque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumPasajeros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextSeriePlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TextLicencia2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextChofer2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumIdent2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TextLicencia1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextChofer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumIdent1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        Me.PCChofer2.SuspendLayout()
        CType(Me.txtdestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(428, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha de embarque:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(428, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha programada:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Vehículo/Bus"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(714, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nro. pasajeros"
        Me.Label4.Visible = False
        '
        'TextFechaEmbarque
        '
        Me.TextFechaEmbarque.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaEmbarque.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaEmbarque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaEmbarque.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaEmbarque.Checked = False
        Me.TextFechaEmbarque.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaEmbarque.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.TextFechaEmbarque.DropDownImage = Nothing
        Me.TextFechaEmbarque.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEmbarque.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEmbarque.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaEmbarque.EnableNullDate = False
        Me.TextFechaEmbarque.EnableNullKeys = False
        Me.TextFechaEmbarque.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaEmbarque.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaEmbarque.Location = New System.Drawing.Point(431, 110)
        Me.TextFechaEmbarque.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEmbarque.MinValue = New Date(CType(0, Long))
        Me.TextFechaEmbarque.Name = "TextFechaEmbarque"
        Me.TextFechaEmbarque.ShowCheckBox = False
        Me.TextFechaEmbarque.ShowUpDownOnFocus = True
        Me.TextFechaEmbarque.Size = New System.Drawing.Size(243, 21)
        Me.TextFechaEmbarque.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaEmbarque.TabIndex = 601
        Me.TextFechaEmbarque.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'TextFechaProgramada
        '
        Me.TextFechaProgramada.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaProgramada.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaProgramada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaProgramada.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaProgramada.Checked = False
        Me.TextFechaProgramada.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaProgramada.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.TextFechaProgramada.DropDownImage = Nothing
        Me.TextFechaProgramada.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaProgramada.Enabled = False
        Me.TextFechaProgramada.EnableNullDate = False
        Me.TextFechaProgramada.EnableNullKeys = False
        Me.TextFechaProgramada.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaProgramada.Location = New System.Drawing.Point(431, 56)
        Me.TextFechaProgramada.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.MinValue = New Date(CType(0, Long))
        Me.TextFechaProgramada.Name = "TextFechaProgramada"
        Me.TextFechaProgramada.ShowCheckBox = False
        Me.TextFechaProgramada.ShowUpDownOnFocus = True
        Me.TextFechaProgramada.Size = New System.Drawing.Size(243, 21)
        Me.TextFechaProgramada.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaProgramada.TabIndex = 602
        Me.TextFechaProgramada.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'TextNumPasajeros
        '
        Me.TextNumPasajeros.BackColor = System.Drawing.Color.White
        Me.TextNumPasajeros.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.TextNumPasajeros.BorderColor = System.Drawing.Color.Silver
        Me.TextNumPasajeros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumPasajeros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumPasajeros.CornerRadius = 3
        Me.TextNumPasajeros.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumPasajeros.Enabled = False
        Me.TextNumPasajeros.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNumPasajeros.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.TextNumPasajeros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNumPasajeros.Location = New System.Drawing.Point(717, 108)
        Me.TextNumPasajeros.MaxLength = 70
        Me.TextNumPasajeros.Metrocolor = System.Drawing.Color.Silver
        Me.TextNumPasajeros.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumPasajeros.Multiline = True
        Me.TextNumPasajeros.Name = "TextNumPasajeros"
        Me.TextNumPasajeros.Size = New System.Drawing.Size(71, 26)
        Me.TextNumPasajeros.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNumPasajeros.TabIndex = 605
        '
        'TextCodigoPlaca
        '
        Me.TextCodigoPlaca.BackColor = System.Drawing.Color.White
        Me.TextCodigoPlaca.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.TextCodigoPlaca.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoPlaca.CornerRadius = 3
        Me.TextCodigoPlaca.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigoPlaca.Enabled = False
        Me.TextCodigoPlaca.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoPlaca.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoPlaca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoPlaca.Location = New System.Drawing.Point(256, 109)
        Me.TextCodigoPlaca.MaxLength = 70
        Me.TextCodigoPlaca.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoPlaca.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoPlaca.Name = "TextCodigoPlaca"
        Me.TextCodigoPlaca.Size = New System.Drawing.Size(136, 22)
        Me.TextCodigoPlaca.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoPlaca.TabIndex = 607
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 608
        Me.Label6.Text = "Ruta - Destino"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label8.Location = New System.Drawing.Point(3, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 18)
        Me.Label8.TabIndex = 614
        Me.Label8.Text = "Consolidación de ruta"
        '
        'TextRuta
        '
        Me.TextRuta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextRuta.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextRuta.BorderColor = System.Drawing.Color.Silver
        Me.TextRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRuta.CornerRadius = 4
        Me.TextRuta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextRuta.Enabled = False
        Me.TextRuta.FarImage = CType(resources.GetObject("TextRuta.FarImage"), System.Drawing.Image)
        Me.TextRuta.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRuta.ForeColor = System.Drawing.Color.Black
        Me.TextRuta.Location = New System.Drawing.Point(7, 53)
        Me.TextRuta.Metrocolor = System.Drawing.Color.Silver
        Me.TextRuta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuta.Name = "TextRuta"
        Me.TextRuta.Size = New System.Drawing.Size(199, 24)
        Me.TextRuta.TabIndex = 609
        '
        'TextSeriePlaca
        '
        Me.TextSeriePlaca.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextSeriePlaca.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.TextSeriePlaca.BorderColor = System.Drawing.Color.Silver
        Me.TextSeriePlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextSeriePlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextSeriePlaca.CornerRadius = 4
        Me.TextSeriePlaca.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextSeriePlaca.FarImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.TextSeriePlaca.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSeriePlaca.ForeColor = System.Drawing.Color.Black
        Me.TextSeriePlaca.Location = New System.Drawing.Point(7, 107)
        Me.TextSeriePlaca.Metrocolor = System.Drawing.Color.Silver
        Me.TextSeriePlaca.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextSeriePlaca.Name = "TextSeriePlaca"
        Me.TextSeriePlaca.Size = New System.Drawing.Size(243, 24)
        Me.TextSeriePlaca.TabIndex = 603
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.Location = New System.Drawing.Point(4, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 18)
        Me.Label9.TabIndex = 616
        Me.Label9.Text = "Tripulantes"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextLicencia2)
        Me.GroupBox3.Controls.Add(Me.TextChofer2)
        Me.GroupBox3.Controls.Add(Me.TextNumIdent2)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(7, 88)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(612, 53)
        Me.GroupBox3.TabIndex = 618
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Chofer 2"
        '
        'TextLicencia2
        '
        Me.TextLicencia2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextLicencia2.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.TextLicencia2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextLicencia2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextLicencia2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextLicencia2.CornerRadius = 3
        Me.TextLicencia2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextLicencia2.FarImage = CType(resources.GetObject("TextLicencia2.FarImage"), System.Drawing.Image)
        Me.TextLicencia2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextLicencia2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextLicencia2.Location = New System.Drawing.Point(415, 22)
        Me.TextLicencia2.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextLicencia2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextLicencia2.Name = "TextLicencia2"
        Me.TextLicencia2.Size = New System.Drawing.Size(183, 22)
        Me.TextLicencia2.TabIndex = 592
        '
        'TextChofer2
        '
        Me.TextChofer2.BackColor = System.Drawing.Color.White
        Me.TextChofer2.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.TextChofer2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextChofer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextChofer2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextChofer2.CornerRadius = 3
        Me.TextChofer2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextChofer2.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextChofer2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextChofer2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextChofer2.Location = New System.Drawing.Point(10, 22)
        Me.TextChofer2.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextChofer2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextChofer2.Name = "TextChofer2"
        Me.TextChofer2.NearImage = CType(resources.GetObject("TextChofer2.NearImage"), System.Drawing.Image)
        Me.TextChofer2.Size = New System.Drawing.Size(282, 22)
        Me.TextChofer2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextChofer2.TabIndex = 586
        '
        'TextNumIdent2
        '
        Me.TextNumIdent2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextNumIdent2.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.TextNumIdent2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdent2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumIdent2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIdent2.CornerRadius = 3
        Me.TextNumIdent2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNumIdent2.Enabled = False
        Me.TextNumIdent2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIdent2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNumIdent2.Location = New System.Drawing.Point(298, 22)
        Me.TextNumIdent2.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdent2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumIdent2.Name = "TextNumIdent2"
        Me.TextNumIdent2.NearImage = CType(resources.GetObject("TextNumIdent2.NearImage"), System.Drawing.Image)
        Me.TextNumIdent2.ReadOnly = True
        Me.TextNumIdent2.Size = New System.Drawing.Size(111, 22)
        Me.TextNumIdent2.TabIndex = 587
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextLicencia1)
        Me.GroupBox2.Controls.Add(Me.TextChofer1)
        Me.GroupBox2.Controls.Add(Me.TextNumIdent1)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(612, 55)
        Me.GroupBox2.TabIndex = 617
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Chofer 1"
        '
        'TextLicencia1
        '
        Me.TextLicencia1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextLicencia1.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.TextLicencia1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextLicencia1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextLicencia1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextLicencia1.CornerRadius = 3
        Me.TextLicencia1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextLicencia1.FarImage = CType(resources.GetObject("TextLicencia1.FarImage"), System.Drawing.Image)
        Me.TextLicencia1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextLicencia1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextLicencia1.Location = New System.Drawing.Point(415, 23)
        Me.TextLicencia1.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextLicencia1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextLicencia1.Name = "TextLicencia1"
        Me.TextLicencia1.Size = New System.Drawing.Size(183, 22)
        Me.TextLicencia1.TabIndex = 591
        '
        'TextChofer1
        '
        Me.TextChofer1.BackColor = System.Drawing.Color.White
        Me.TextChofer1.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.TextChofer1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextChofer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextChofer1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextChofer1.CornerRadius = 3
        Me.TextChofer1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextChofer1.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextChofer1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextChofer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextChofer1.Location = New System.Drawing.Point(10, 23)
        Me.TextChofer1.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextChofer1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextChofer1.Name = "TextChofer1"
        Me.TextChofer1.NearImage = CType(resources.GetObject("TextChofer1.NearImage"), System.Drawing.Image)
        Me.TextChofer1.Size = New System.Drawing.Size(282, 22)
        Me.TextChofer1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextChofer1.TabIndex = 590
        '
        'TextNumIdent1
        '
        Me.TextNumIdent1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextNumIdent1.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.TextNumIdent1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdent1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumIdent1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIdent1.CornerRadius = 3
        Me.TextNumIdent1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNumIdent1.Enabled = False
        Me.TextNumIdent1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIdent1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNumIdent1.Location = New System.Drawing.Point(298, 23)
        Me.TextNumIdent1.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdent1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumIdent1.Name = "TextNumIdent1"
        Me.TextNumIdent1.NearImage = CType(resources.GetObject("TextNumIdent1.NearImage"), System.Drawing.Image)
        Me.TextNumIdent1.ReadOnly = True
        Me.TextNumIdent1.Size = New System.Drawing.Size(111, 22)
        Me.TextNumIdent1.TabIndex = 589
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(997, 53)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 619
        '
        'LsvProveedor
        '
        Me.LsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colCliente, Me.colRUC, Me.colTipoDoc, Me.licencia})
        Me.LsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProveedor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LsvProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.LsvProveedor.FullRowSelect = True
        Me.LsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LsvProveedor.HideSelection = False
        Me.LsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem3})
        Me.LsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.LsvProveedor.MultiSelect = False
        Me.LsvProveedor.Name = "LsvProveedor"
        Me.LsvProveedor.Size = New System.Drawing.Size(282, 128)
        Me.LsvProveedor.TabIndex = 1
        Me.LsvProveedor.UseCompatibleStateImageBehavior = False
        Me.LsvProveedor.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 219
        '
        'colRUC
        '
        Me.colRUC.Text = "RUC"
        '
        'PCChofer2
        '
        Me.PCChofer2.Controls.Add(Me.ListChofer2)
        Me.PCChofer2.Location = New System.Drawing.Point(900, 209)
        Me.PCChofer2.Name = "PCChofer2"
        Me.PCChofer2.Size = New System.Drawing.Size(282, 128)
        Me.PCChofer2.TabIndex = 620
        '
        'ListChofer2
        '
        Me.ListChofer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListChofer2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListChofer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListChofer2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListChofer2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.ListChofer2.FullRowSelect = True
        Me.ListChofer2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListChofer2.HideSelection = False
        Me.ListChofer2.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem4})
        Me.ListChofer2.Location = New System.Drawing.Point(0, 0)
        Me.ListChofer2.MultiSelect = False
        Me.ListChofer2.Name = "ListChofer2"
        Me.ListChofer2.Size = New System.Drawing.Size(282, 128)
        Me.ListChofer2.TabIndex = 1
        Me.ListChofer2.UseCompatibleStateImageBehavior = False
        Me.ListChofer2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Cliente"
        Me.ColumnHeader2.Width = 219
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "RUC"
        '
        'txtdestino
        '
        Me.txtdestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtdestino.BeforeTouchSize = New System.Drawing.Size(71, 26)
        Me.txtdestino.BorderColor = System.Drawing.Color.Silver
        Me.txtdestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdestino.CornerRadius = 4
        Me.txtdestino.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtdestino.Enabled = False
        Me.txtdestino.FarImage = CType(resources.GetObject("txtdestino.FarImage"), System.Drawing.Image)
        Me.txtdestino.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdestino.ForeColor = System.Drawing.Color.Black
        Me.txtdestino.Location = New System.Drawing.Point(212, 53)
        Me.txtdestino.Metrocolor = System.Drawing.Color.Silver
        Me.txtdestino.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdestino.Name = "txtdestino"
        Me.txtdestino.Size = New System.Drawing.Size(199, 24)
        Me.txtdestino.TabIndex = 626
        '
        'RoundButton24
        '
        Me.RoundButton24.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton24.BackColor = System.Drawing.Color.FromArgb(CType(CType(134, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.RoundButton24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RoundButton24.BeforeTouchSize = New System.Drawing.Size(153, 93)
        Me.RoundButton24.Font = New System.Drawing.Font("Yu Gothic", 14.0!)
        Me.RoundButton24.ForeColor = System.Drawing.Color.White
        Me.RoundButton24.Image = CType(resources.GetObject("RoundButton24.Image"), System.Drawing.Image)
        Me.RoundButton24.IsBackStageButton = False
        Me.RoundButton24.Location = New System.Drawing.Point(651, 5)
        Me.RoundButton24.Name = "RoundButton24"
        Me.RoundButton24.Size = New System.Drawing.Size(153, 93)
        Me.RoundButton24.TabIndex = 625
        Me.RoundButton24.Text = "MANIFIESTO"
        Me.RoundButton24.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.RoundButton24.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.RoundButton24.UseVisualStyle = True
        '
        'Line21
        '
        Me.Line21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Line21.LineColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Line21.Location = New System.Drawing.Point(0, 285)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(989, 5)
        Me.Line21.TabIndex = 615
        Me.Line21.Text = "Line21"
        '
        'CirclePictureBox1
        '
        Me.CirclePictureBox1.BackgroundImage = CType(resources.GetObject("CirclePictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.CirclePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CirclePictureBox1.Location = New System.Drawing.Point(689, 3)
        Me.CirclePictureBox1.Name = "CirclePictureBox1"
        Me.CirclePictureBox1.Size = New System.Drawing.Size(115, 98)
        Me.CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CirclePictureBox1.TabIndex = 612
        Me.CirclePictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TextNumPasajeros)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.PCChofer2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.pcLikeCategoria)
        Me.Panel1.Controls.Add(Me.txtdestino)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextFechaEmbarque)
        Me.Panel1.Controls.Add(Me.TextFechaProgramada)
        Me.Panel1.Controls.Add(Me.TextSeriePlaca)
        Me.Panel1.Controls.Add(Me.TextCodigoPlaca)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TextRuta)
        Me.Panel1.Controls.Add(Me.CirclePictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(989, 137)
        Me.Panel1.TabIndex = 627
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtNroImpresion)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.RoundButton24)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 137)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(989, 148)
        Me.Panel2.TabIndex = 628
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCuentas.BackColor = System.Drawing.Color.White
        Me.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 290)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvCuentas.Size = New System.Drawing.Size(989, 388)
        Me.dgvCuentas.TabIndex = 629
        Me.dgvCuentas.TableDescriptor.AllowNew = False
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Size = 12.0!
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCuentas.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCuentas.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor8.MappingName = "id"
        GridColumnDescriptor8.Width = 0
        GridColumnDescriptor9.HeaderText = "Asiento"
        GridColumnDescriptor9.MappingName = "asiento"
        GridColumnDescriptor9.Width = 96
        GridColumnDescriptor10.HeaderText = "Identificaciòn"
        GridColumnDescriptor10.MappingName = "dni"
        GridColumnDescriptor10.Name = "dni"
        GridColumnDescriptor10.Width = 134
        GridColumnDescriptor11.HeaderText = "Pasajero"
        GridColumnDescriptor11.MappingName = "pasajero"
        GridColumnDescriptor11.Name = "pasajero"
        GridColumnDescriptor11.Width = 300
        GridColumnDescriptor12.HeaderText = "Edad"
        GridColumnDescriptor12.MappingName = "edad"
        GridColumnDescriptor12.Name = "edad"
        GridColumnDescriptor12.Width = 70
        GridColumnDescriptor13.HeaderText = "Número venta"
        GridColumnDescriptor13.MappingName = "numero"
        GridColumnDescriptor13.Width = 115
        GridColumnDescriptor14.HeaderText = "Importe"
        GridColumnDescriptor14.MappingName = "importe"
        GridColumnDescriptor14.Width = 115
        Me.dgvCuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14})
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.CellType = "TextBox"
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.GradientInactiveCaption)
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor2.Name = "Row 1"
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.Font.Bold = True
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.Font.Size = 12.0!
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryColumnDescriptor2.DataMember = "importe"
        GridSummaryColumnDescriptor2.Format = "{Sum}"
        GridSummaryColumnDescriptor2.Name = "abonado"
        GridSummaryColumnDescriptor2.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor2.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor2})
        GridSummaryRowDescriptor2.Title = "Total pagos: "
        Me.dgvCuentas.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor2)
        Me.dgvCuentas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCuentas.TableDescriptor.TableOptions.RecordRowHeight = 30
        Me.dgvCuentas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("id"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("asiento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("dni"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("pasajero"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("edad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numero"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importe")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.UseRightToLeftCompatibleTextBox = True
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(683, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 626
        Me.Label5.Text = "Nro. de Impresión"
        Me.Label5.Visible = False
        '
        'txtNroImpresion
        '
        Me.txtNroImpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNroImpresion.BeforeTouchSize = New System.Drawing.Size(75, 29)
        Me.txtNroImpresion.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtNroImpresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroImpresion.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtNroImpresion.ForeColor = System.Drawing.Color.Black
        Me.txtNroImpresion.Location = New System.Drawing.Point(692, 116)
        Me.txtNroImpresion.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtNroImpresion.Name = "txtNroImpresion"
        Me.txtNroImpresion.Size = New System.Drawing.Size(75, 29)
        Me.txtNroImpresion.TabIndex = 721
        Me.txtNroImpresion.TabStop = False
        Me.txtNroImpresion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtNroImpresion.ThousandsSeparator = True
        Me.txtNroImpresion.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtNroImpresion.Visible = False
        Me.txtNroImpresion.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'FormConsolidarSalidaEmbarque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BorderThickness = 2
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(989, 678)
        Me.Controls.Add(Me.dgvCuentas)
        Me.Controls.Add(Me.Line21)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormConsolidarSalidaEmbarque"
        Me.ShowIcon = False
        Me.Text = "Consolidar Salida Embarque"
        CType(Me.TextFechaEmbarque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumPasajeros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextSeriePlaca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TextLicencia2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextChofer2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumIdent2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TextLicencia1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextChofer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumIdent1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        Me.PCChofer2.ResumeLayout(False)
        CType(Me.txtdestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextFechaEmbarque As Tools.DateTimePickerAdv
    Friend WithEvents TextFechaProgramada As Tools.DateTimePickerAdv
    Friend WithEvents TextSeriePlaca As Tools.TextBoxExt
    Friend WithEvents TextNumPasajeros As Tools.TextBoxExt
    Friend WithEvents TextCodigoPlaca As Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents TextRuta As Tools.TextBoxExt
    Friend WithEvents CirclePictureBox1 As CirclePictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Line21 As Line2
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextLicencia2 As Tools.TextBoxExt
    Friend WithEvents TextChofer2 As Tools.TextBoxExt
    Friend WithEvents TextNumIdent2 As Tools.TextBoxExt
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextLicencia1 As Tools.TextBoxExt
    Friend WithEvents TextChofer1 As Tools.TextBoxExt
    Friend WithEvents TextNumIdent1 As Tools.TextBoxExt
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Private WithEvents PCChofer2 As PopupControlContainer
    Friend WithEvents ListChofer2 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents RoundButton24 As RoundButton2
    Friend WithEvents txtdestino As Tools.TextBoxExt
    Friend WithEvents licencia As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNroImpresion As Tools.NumericUpDownExt
End Class

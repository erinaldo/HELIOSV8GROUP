Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBusquedaDocXEntidad
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
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBusquedaDocXEntidad))
        Me.PanelRegistro = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxAdv1 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TXTcOMPRADOR = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TXTdIA = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ChMes = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChDia = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFechapERIODO = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboCriterio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboFiltros = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PanelRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelRegistro.SuspendLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTdIA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTdIA.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechapERIODO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechapERIODO.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboCriterio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelRegistro
        '
        Me.PanelRegistro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelRegistro.BorderColor = System.Drawing.Color.Silver
        Me.PanelRegistro.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.PanelRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelRegistro.Controls.Add(Me.Label1)
        Me.PanelRegistro.Controls.Add(Me.TXTdIA)
        Me.PanelRegistro.Controls.Add(Me.ChMes)
        Me.PanelRegistro.Controls.Add(Me.Label9)
        Me.PanelRegistro.Controls.Add(Me.ChDia)
        Me.PanelRegistro.Controls.Add(Me.Label8)
        Me.PanelRegistro.Controls.Add(Me.txtFechapERIODO)
        Me.PanelRegistro.Controls.Add(Me.Label7)
        Me.PanelRegistro.Controls.Add(Me.Label6)
        Me.PanelRegistro.Controls.Add(Me.ComboCriterio)
        Me.PanelRegistro.Controls.Add(Me.Label5)
        Me.PanelRegistro.Controls.Add(Me.ComboFiltros)
        Me.PanelRegistro.Controls.Add(Me.TextBoxExt1)
        Me.PanelRegistro.Controls.Add(Me.Label4)
        Me.PanelRegistro.Controls.Add(Me.ComboBoxAdv1)
        Me.PanelRegistro.Controls.Add(Me.Label3)
        Me.PanelRegistro.Controls.Add(Me.RoundButton21)
        Me.PanelRegistro.Controls.Add(Me.cboTipoDoc)
        Me.PanelRegistro.Controls.Add(Me.Label2)
        Me.PanelRegistro.Controls.Add(Me.ProgressBar1)
        Me.PanelRegistro.Controls.Add(Me.pcLikeCategoria)
        Me.PanelRegistro.Controls.Add(Me.TXTcOMPRADOR)
        Me.PanelRegistro.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelRegistro.Location = New System.Drawing.Point(0, 0)
        Me.PanelRegistro.Name = "PanelRegistro"
        Me.PanelRegistro.Size = New System.Drawing.Size(872, 223)
        Me.PanelRegistro.TabIndex = 414
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.White
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(340, 22)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt1.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextBoxExt1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBoxExt1.Location = New System.Drawing.Point(689, 196)
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.Size = New System.Drawing.Size(81, 22)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextBoxExt1.TabIndex = 515
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(686, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 14)
        Me.Label4.TabIndex = 514
        Me.Label4.Text = "Criterio"
        '
        'ComboBoxAdv1
        '
        Me.ComboBoxAdv1.BackColor = System.Drawing.Color.White
        Me.ComboBoxAdv1.BeforeTouchSize = New System.Drawing.Size(143, 21)
        Me.ComboBoxAdv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAdv1.Enabled = False
        Me.ComboBoxAdv1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAdv1.Items.AddRange(New Object() {"TODOS", "BOLETAS", "FACTURAS", "PROFORMAS", "NOTAS"})
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "TODOS"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "BOLETAS"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "FACTURAS"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "PROFORMAS"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "NOTAS"))
        Me.ComboBoxAdv1.Location = New System.Drawing.Point(540, 197)
        Me.ComboBoxAdv1.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboBoxAdv1.Name = "ComboBoxAdv1"
        Me.ComboBoxAdv1.Size = New System.Drawing.Size(143, 21)
        Me.ComboBoxAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboBoxAdv1.TabIndex = 512
        Me.ComboBoxAdv1.Text = "TODOS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(534, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 511
        Me.Label3.Text = "Filtrar por"
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(105, 23)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(776, 195)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(105, 23)
        Me.RoundButton21.TabIndex = 510
        Me.RoundButton21.Text = "CONSULTAR"
        Me.RoundButton21.UseVisualStyle = True
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(143, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Enabled = False
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Items.AddRange(New Object() {"24 HORAS", "48 HORAS", "72 HORAS", "PERIODO"})
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "24 HORAS"))
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "48 HORAS"))
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "72 HORAS"))
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "PERIODO"))
        Me.cboTipoDoc.Location = New System.Drawing.Point(391, 197)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(143, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 509
        Me.cboTipoDoc.Text = "24 HORAS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(388, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 14)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Ultimos movimientos"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(114, 103)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar1.TabIndex = 507
        Me.ProgressBar1.Visible = False
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(840, 71)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 432
        '
        'LsvProveedor
        '
        Me.LsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colCliente, Me.colRUC, Me.colTipoDoc})
        Me.LsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProveedor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LsvProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.LsvProveedor.FullRowSelect = True
        Me.LsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
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
        'TXTcOMPRADOR
        '
        Me.TXTcOMPRADOR.BackColor = System.Drawing.Color.White
        Me.TXTcOMPRADOR.BeforeTouchSize = New System.Drawing.Size(340, 22)
        Me.TXTcOMPRADOR.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTcOMPRADOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTcOMPRADOR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTcOMPRADOR.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TXTcOMPRADOR.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTcOMPRADOR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTcOMPRADOR.Location = New System.Drawing.Point(114, 91)
        Me.TXTcOMPRADOR.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTcOMPRADOR.Name = "TXTcOMPRADOR"
        Me.TXTcOMPRADOR.NearImage = CType(resources.GetObject("TXTcOMPRADOR.NearImage"), System.Drawing.Image)
        Me.TXTcOMPRADOR.Size = New System.Drawing.Size(340, 22)
        Me.TXTcOMPRADOR.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TXTcOMPRADOR.TabIndex = 220
        '
        'TXTdIA
        '
        Me.TXTdIA.BackColor = System.Drawing.Color.Gainsboro
        Me.TXTdIA.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TXTdIA.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TXTdIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TXTdIA.Calendar.AllowMultipleSelection = False
        Me.TXTdIA.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TXTdIA.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTdIA.Calendar.BottomHeight = 30
        Me.TXTdIA.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TXTdIA.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TXTdIA.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TXTdIA.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TXTdIA.Calendar.EnableTouchMode = True
        Me.TXTdIA.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTdIA.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TXTdIA.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TXTdIA.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TXTdIA.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TXTdIA.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TXTdIA.Calendar.Iso8601CalenderFormat = False
        Me.TXTdIA.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TXTdIA.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.Calendar.Name = "monthCalendar"
        Me.TXTdIA.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TXTdIA.Calendar.SelectedDates = New Date(-1) {}
        Me.TXTdIA.Calendar.Size = New System.Drawing.Size(80, 174)
        Me.TXTdIA.Calendar.SizeToFit = True
        Me.TXTdIA.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TXTdIA.Calendar.TabIndex = 0
        Me.TXTdIA.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TXTdIA.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TXTdIA.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TXTdIA.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TXTdIA.Calendar.NoneButton.IsBackStageButton = False
        Me.TXTdIA.Calendar.NoneButton.Location = New System.Drawing.Point(4, 0)
        Me.TXTdIA.Calendar.NoneButton.Size = New System.Drawing.Size(72, 30)
        Me.TXTdIA.Calendar.NoneButton.Text = "None"
        Me.TXTdIA.Calendar.NoneButton.UseVisualStyle = True
        Me.TXTdIA.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TXTdIA.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TXTdIA.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TXTdIA.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TXTdIA.Calendar.TodayButton.IsBackStageButton = False
        Me.TXTdIA.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TXTdIA.Calendar.TodayButton.Size = New System.Drawing.Size(80, 30)
        Me.TXTdIA.Calendar.TodayButton.Text = "Today"
        Me.TXTdIA.Calendar.TodayButton.UseVisualStyle = True
        Me.TXTdIA.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTdIA.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TXTdIA.Checked = False
        Me.TXTdIA.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TXTdIA.CustomFormat = "dd/MM/yyyy"
        Me.TXTdIA.DropDownImage = Nothing
        Me.TXTdIA.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TXTdIA.EnableNullDate = False
        Me.TXTdIA.EnableNullKeys = False
        Me.TXTdIA.EnableTouchMode = True
        Me.TXTdIA.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTdIA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TXTdIA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TXTdIA.Location = New System.Drawing.Point(26, 92)
        Me.TXTdIA.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.MinValue = New Date(CType(0, Long))
        Me.TXTdIA.Name = "TXTdIA"
        Me.TXTdIA.ShowCheckBox = False
        Me.TXTdIA.ShowDropButton = False
        Me.TXTdIA.Size = New System.Drawing.Size(82, 20)
        Me.TXTdIA.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TXTdIA.TabIndex = 530
        Me.TXTdIA.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'ChMes
        '
        Me.ChMes.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChMes.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChMes.Checked = False
        Me.ChMes.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.ChMes.ForeColor = System.Drawing.Color.White
        Me.ChMes.Location = New System.Drawing.Point(545, 39)
        Me.ChMes.Name = "ChMes"
        Me.ChMes.Size = New System.Drawing.Size(20, 20)
        Me.ChMes.TabIndex = 529
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(566, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 14)
        Me.Label9.TabIndex = 528
        Me.Label9.Text = "POR MES"
        '
        'ChDia
        '
        Me.ChDia.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ChDia.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChDia.Checked = True
        Me.ChDia.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.ChDia.ForeColor = System.Drawing.Color.White
        Me.ChDia.Location = New System.Drawing.Point(466, 39)
        Me.ChDia.Name = "ChDia"
        Me.ChDia.Size = New System.Drawing.Size(20, 20)
        Me.ChDia.TabIndex = 527
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(487, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 14)
        Me.Label8.TabIndex = 526
        Me.Label8.Text = "POR DIA"
        '
        'txtFechapERIODO
        '
        Me.txtFechapERIODO.BackColor = System.Drawing.Color.Gainsboro
        Me.txtFechapERIODO.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechapERIODO.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechapERIODO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechapERIODO.Calendar.AllowMultipleSelection = False
        Me.txtFechapERIODO.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechapERIODO.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechapERIODO.Calendar.BottomHeight = 30
        Me.txtFechapERIODO.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechapERIODO.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechapERIODO.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechapERIODO.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechapERIODO.Calendar.EnableTouchMode = True
        Me.txtFechapERIODO.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechapERIODO.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechapERIODO.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechapERIODO.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechapERIODO.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechapERIODO.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechapERIODO.Calendar.Iso8601CalenderFormat = False
        Me.txtFechapERIODO.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechapERIODO.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.Calendar.Name = "monthCalendar"
        Me.txtFechapERIODO.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechapERIODO.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechapERIODO.Calendar.Size = New System.Drawing.Size(80, 174)
        Me.txtFechapERIODO.Calendar.SizeToFit = True
        Me.txtFechapERIODO.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechapERIODO.Calendar.TabIndex = 0
        Me.txtFechapERIODO.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechapERIODO.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechapERIODO.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechapERIODO.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechapERIODO.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechapERIODO.Calendar.NoneButton.Location = New System.Drawing.Point(4, 0)
        Me.txtFechapERIODO.Calendar.NoneButton.Size = New System.Drawing.Size(72, 30)
        Me.txtFechapERIODO.Calendar.NoneButton.Text = "None"
        Me.txtFechapERIODO.Calendar.NoneButton.UseVisualStyle = True
        Me.txtFechapERIODO.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.txtFechapERIODO.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechapERIODO.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechapERIODO.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechapERIODO.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechapERIODO.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechapERIODO.Calendar.TodayButton.Size = New System.Drawing.Size(80, 30)
        Me.txtFechapERIODO.Calendar.TodayButton.Text = "Today"
        Me.txtFechapERIODO.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechapERIODO.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechapERIODO.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechapERIODO.Checked = False
        Me.txtFechapERIODO.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechapERIODO.CustomFormat = "MM/yyyy"
        Me.txtFechapERIODO.DropDownImage = Nothing
        Me.txtFechapERIODO.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechapERIODO.EnableNullDate = False
        Me.txtFechapERIODO.EnableNullKeys = False
        Me.txtFechapERIODO.EnableTouchMode = True
        Me.txtFechapERIODO.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechapERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechapERIODO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechapERIODO.Location = New System.Drawing.Point(26, 92)
        Me.txtFechapERIODO.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.MinValue = New Date(CType(0, Long))
        Me.txtFechapERIODO.Name = "txtFechapERIODO"
        Me.txtFechapERIODO.ShowCheckBox = False
        Me.txtFechapERIODO.ShowDropButton = False
        Me.txtFechapERIODO.Size = New System.Drawing.Size(82, 20)
        Me.txtFechapERIODO.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechapERIODO.TabIndex = 525
        Me.txtFechapERIODO.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        Me.txtFechapERIODO.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(23, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 524
        Me.Label7.Text = "PERIODO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(209, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 522
        Me.Label6.Text = "COMPROBANTE"
        '
        'ComboCriterio
        '
        Me.ComboCriterio.BackColor = System.Drawing.Color.White
        Me.ComboCriterio.BeforeTouchSize = New System.Drawing.Size(242, 21)
        Me.ComboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCriterio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCriterio.Location = New System.Drawing.Point(212, 39)
        Me.ComboCriterio.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ComboCriterio.Name = "ComboCriterio"
        Me.ComboCriterio.Size = New System.Drawing.Size(242, 21)
        Me.ComboCriterio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCriterio.TabIndex = 523
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(23, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 520
        Me.Label5.Text = "FILTRAR POR"
        '
        'ComboFiltros
        '
        Me.ComboFiltros.BackColor = System.Drawing.Color.White
        Me.ComboFiltros.BeforeTouchSize = New System.Drawing.Size(180, 21)
        Me.ComboFiltros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFiltros.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboFiltros.Items.AddRange(New Object() {"COMPROBANTE", "CLIENTE", "IMPORTE"})
        Me.ComboFiltros.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboFiltros, "COMPROBANTE"))
        Me.ComboFiltros.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboFiltros, "CLIENTE"))
        Me.ComboFiltros.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboFiltros, "IMPORTE"))
        Me.ComboFiltros.Location = New System.Drawing.Point(26, 39)
        Me.ComboFiltros.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ComboFiltros.Name = "ComboFiltros"
        Me.ComboFiltros.Size = New System.Drawing.Size(180, 21)
        Me.ComboFiltros.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboFiltros.TabIndex = 521
        Me.ComboFiltros.Text = "COMPROBANTE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(111, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 13)
        Me.Label1.TabIndex = 531
        Me.Label1.Text = "CRITERIO DE BÚSQUEDA"
        '
        'FormBusquedaDocXEntidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(872, 261)
        Me.Controls.Add(Me.PanelRegistro)
        Me.Name = "FormBusquedaDocXEntidad"
        Me.ShowIcon = False
        CType(Me.PanelRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelRegistro.ResumeLayout(False)
        Me.PanelRegistro.PerformLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTdIA.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTdIA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechapERIODO.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechapERIODO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboCriterio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelRegistro As Tools.GradientPanel
    Friend WithEvents ProgressBar1 As ProgressBar
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Friend WithEvents TXTcOMPRADOR As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents cboTipoDoc As Tools.ComboBoxAdv
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents ComboBoxAdv1 As Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxExt1 As Tools.TextBoxExt
    Friend WithEvents TXTdIA As Tools.DateTimePickerAdv
    Friend WithEvents ChMes As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label9 As Label
    Friend WithEvents ChDia As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFechapERIODO As Tools.DateTimePickerAdv
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboCriterio As Tools.ComboBoxAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboFiltros As Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
End Class

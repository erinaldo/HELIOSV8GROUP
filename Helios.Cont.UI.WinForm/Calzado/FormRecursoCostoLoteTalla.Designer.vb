Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRecursoCostoLoteTalla
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
        Dim MetroColorTable1 As Syncfusion.Windows.Forms.MetroColorTable = New Syncfusion.Windows.Forms.MetroColorTable()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRecursoCostoLoteTalla))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextCategory = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextDisponible = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboTallas = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboDetalleTallas = New Syncfusion.Windows.Forms.Tools.MultiColumnComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextUsa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextUK = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextEur = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCm = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CurrencyStock = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.ButtonAdd = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.TextCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboTallas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboDetalleTallas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextUsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextUK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(21, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Categoría"
        '
        'TextCategory
        '
        Me.TextCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.TextCategory.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextCategory.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TextCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TextCategory.Location = New System.Drawing.Point(24, 39)
        Me.TextCategory.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextCategory.Name = "TextCategory"
        Me.TextCategory.ReadOnly = True
        Me.TextCategory.Size = New System.Drawing.Size(284, 22)
        Me.TextCategory.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Black
        Me.TextCategory.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(311, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cantidad x distribuir"
        '
        'TextDisponible
        '
        Me.TextDisponible.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.TextDisponible.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextDisponible.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TextDisponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDisponible.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDisponible.ForeColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TextDisponible.Location = New System.Drawing.Point(314, 32)
        Me.TextDisponible.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextDisponible.Name = "TextDisponible"
        Me.TextDisponible.ReadOnly = True
        Me.TextDisponible.Size = New System.Drawing.Size(109, 29)
        Me.TextDisponible.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Black
        Me.TextDisponible.TabIndex = 3
        Me.TextDisponible.Text = "0.00"
        Me.TextDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tallas"
        '
        'ComboTallas
        '
        Me.ComboTallas.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboTallas.BeforeTouchSize = New System.Drawing.Size(104, 21)
        Me.ComboTallas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTallas.Location = New System.Drawing.Point(24, 98)
        Me.ComboTallas.Name = "ComboTallas"
        Me.ComboTallas.Size = New System.Drawing.Size(104, 21)
        Me.ComboTallas.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboTallas.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(131, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tabla de tallas"
        '
        'ComboDetalleTallas
        '
        Me.ComboDetalleTallas.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ComboDetalleTallas.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboDetalleTallas.BeforeTouchSize = New System.Drawing.Size(174, 21)
        Me.ComboDetalleTallas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDetalleTallas.DropDownWidth = 440
        Me.ComboDetalleTallas.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboDetalleTallas.Location = New System.Drawing.Point(134, 98)
        Me.ComboDetalleTallas.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ComboDetalleTallas.Name = "ComboDetalleTallas"
        MetroColorTable1.ArrowChecked = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        MetroColorTable1.ArrowCheckedBorderColor = System.Drawing.Color.Empty
        MetroColorTable1.ArrowInActive = System.Drawing.Color.White
        MetroColorTable1.ArrowNormal = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ArrowNormalBackGround = System.Drawing.Color.Empty
        MetroColorTable1.ArrowNormalBorderColor = System.Drawing.Color.Empty
        MetroColorTable1.ArrowPushed = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ArrowPushedBackGround = System.Drawing.Color.Empty
        MetroColorTable1.ArrowPushedBorderColor = System.Drawing.Color.Empty
        MetroColorTable1.ScrollerBackground = System.Drawing.Color.White
        MetroColorTable1.ThumbChecked = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        MetroColorTable1.ThumbCheckedBorderColor = System.Drawing.Color.Empty
        MetroColorTable1.ThumbInActive = System.Drawing.Color.White
        MetroColorTable1.ThumbNormal = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ThumbNormalBorderColor = System.Drawing.Color.Empty
        MetroColorTable1.ThumbPushed = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ThumbPushedBorder = System.Drawing.Color.Empty
        MetroColorTable1.ThumbPushedBorderColor = System.Drawing.Color.Empty
        Me.ComboDetalleTallas.ScrollMetroColorTable = MetroColorTable1
        Me.ComboDetalleTallas.Size = New System.Drawing.Size(174, 21)
        Me.ComboDetalleTallas.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboDetalleTallas.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(311, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "USA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(389, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "UK"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(472, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "EUR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(549, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "CM"
        '
        'TextUsa
        '
        Me.TextUsa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.TextUsa.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextUsa.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TextUsa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextUsa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TextUsa.Location = New System.Drawing.Point(314, 97)
        Me.TextUsa.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextUsa.Name = "TextUsa"
        Me.TextUsa.ReadOnly = True
        Me.TextUsa.Size = New System.Drawing.Size(72, 22)
        Me.TextUsa.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Black
        Me.TextUsa.TabIndex = 12
        Me.TextUsa.Text = "0.00"
        Me.TextUsa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextUK
        '
        Me.TextUK.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.TextUK.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextUK.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TextUK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextUK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TextUK.Location = New System.Drawing.Point(392, 97)
        Me.TextUK.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextUK.Name = "TextUK"
        Me.TextUK.ReadOnly = True
        Me.TextUK.Size = New System.Drawing.Size(72, 22)
        Me.TextUK.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Black
        Me.TextUK.TabIndex = 13
        Me.TextUK.Text = "0.00"
        Me.TextUK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextEur
        '
        Me.TextEur.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.TextEur.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextEur.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TextEur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEur.ForeColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TextEur.Location = New System.Drawing.Point(470, 97)
        Me.TextEur.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextEur.Name = "TextEur"
        Me.TextEur.ReadOnly = True
        Me.TextEur.Size = New System.Drawing.Size(72, 22)
        Me.TextEur.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Black
        Me.TextEur.TabIndex = 14
        Me.TextEur.Text = "0.00"
        Me.TextEur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextCm
        '
        Me.TextCm.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.TextCm.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextCm.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.TextCm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TextCm.Location = New System.Drawing.Point(548, 97)
        Me.TextCm.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextCm.Name = "TextCm"
        Me.TextCm.ReadOnly = True
        Me.TextCm.Size = New System.Drawing.Size(72, 22)
        Me.TextCm.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Black
        Me.TextCm.TabIndex = 15
        Me.TextCm.Text = "0.00"
        Me.TextCm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Magenta
        Me.Label9.Location = New System.Drawing.Point(635, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 19)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Stock"
        '
        'CurrencyStock
        '
        Me.CurrencyStock.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CurrencyStock.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.CurrencyStock.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.CurrencyStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CurrencyStock.CurrencySymbol = ""
        Me.CurrencyStock.DecimalValue = New Decimal(New Integer() {100, 0, 0, 131072})
        Me.CurrencyStock.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrencyStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.CurrencyStock.Location = New System.Drawing.Point(626, 94)
        Me.CurrencyStock.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.CurrencyStock.Name = "CurrencyStock"
        Me.CurrencyStock.NullString = ""
        Me.CurrencyStock.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.CurrencyStock.Size = New System.Drawing.Size(60, 25)
        Me.CurrencyStock.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Black
        Me.CurrencyStock.TabIndex = 17
        Me.CurrencyStock.Text = "1.00"
        Me.CurrencyStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CurrencyStock.ZeroColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.ButtonAdd.BeforeTouchSize = New System.Drawing.Size(64, 23)
        Me.ButtonAdd.ForeColor = System.Drawing.Color.White
        Me.ButtonAdd.IsBackStageButton = False
        Me.ButtonAdd.Location = New System.Drawing.Point(692, 96)
        Me.ButtonAdd.MetroColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(64, 23)
        Me.ButtonAdd.TabIndex = 18
        Me.ButtonAdd.Text = "Agregar"
        Me.ButtonAdd.UseVisualStyle = True
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.ListView1.ForeColor = System.Drawing.Color.White
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(24, 131)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(786, 236)
        Me.ListView1.TabIndex = 19
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Genero"
        Me.ColumnHeader1.Width = 157
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "USA"
        Me.ColumnHeader2.Width = 106
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "UK"
        Me.ColumnHeader3.Width = 81
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "EUR"
        Me.ColumnHeader4.Width = 94
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "CM"
        Me.ColumnHeader5.Width = 84
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ID"
        Me.ColumnHeader6.Width = 0
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(52, 23)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(758, 96)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(52, 23)
        Me.ButtonAdv1.TabIndex = 20
        Me.ButtonAdv1.Text = "Quitar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.ActiveBorderThickness = 1
        Me.btOperacion.ActiveCornerRadius = 20
        Me.btOperacion.ActiveFillColor = System.Drawing.SystemColors.HotTrack
        Me.btOperacion.ActiveForecolor = System.Drawing.Color.White
        Me.btOperacion.ActiveLineColor = System.Drawing.SystemColors.HotTrack
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btOperacion.BackgroundImage = CType(resources.GetObject("btOperacion.BackgroundImage"), System.Drawing.Image)
        Me.btOperacion.ButtonText = "GRABAR"
        Me.btOperacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.Black
        Me.btOperacion.IdleBorderThickness = 1
        Me.btOperacion.IdleCornerRadius = 20
        Me.btOperacion.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btOperacion.IdleForecolor = System.Drawing.Color.White
        Me.btOperacion.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btOperacion.Location = New System.Drawing.Point(359, 375)
        Me.btOperacion.Margin = New System.Windows.Forms.Padding(5)
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(123, 45)
        Me.btOperacion.TabIndex = 680
        Me.btOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Cantidad"
        Me.ColumnHeader7.Width = 80
        '
        'FormRecursoCostoLoteTalla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(840, 423)
        Me.Controls.Add(Me.btOperacion)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ButtonAdd)
        Me.Controls.Add(Me.CurrencyStock)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextCm)
        Me.Controls.Add(Me.TextEur)
        Me.Controls.Add(Me.TextUK)
        Me.Controls.Add(Me.TextUsa)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboDetalleTallas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboTallas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextDisponible)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextCategory)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRecursoCostoLoteTalla"
        Me.ShowIcon = False
        Me.Text = "Confirmar items"
        CType(Me.TextCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboTallas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboDetalleTallas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextUsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextUK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextCategory As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents TextDisponible As Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboTallas As Tools.ComboBoxAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboDetalleTallas As Tools.MultiColumnComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextUsa As Tools.TextBoxExt
    Friend WithEvents TextUK As Tools.TextBoxExt
    Friend WithEvents TextEur As Tools.TextBoxExt
    Friend WithEvents TextCm As Tools.TextBoxExt
    Friend WithEvents Label9 As Label
    Friend WithEvents CurrencyStock As Tools.CurrencyTextBox
    Friend WithEvents ButtonAdd As ButtonAdv
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ButtonAdv1 As ButtonAdv
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents btOperacion As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents ColumnHeader7 As ColumnHeader
End Class

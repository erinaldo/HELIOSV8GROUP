Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCanastaProductsGeneral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCanastaProductsGeneral))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BunifuThinButton22 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.ToggleProducts = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckStock = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.BunifuThinButton24 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.txtFiltrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GridTotales = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel2.SuspendLayout()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BunifuThinButton22)
        Me.Panel2.Controls.Add(Me.ToggleProducts)
        Me.Panel2.Controls.Add(Me.BunifuThinButton21)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.CheckStock)
        Me.Panel2.Controls.Add(Me.BunifuThinButton24)
        Me.Panel2.Controls.Add(Me.txtFiltrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(844, 45)
        Me.Panel2.TabIndex = 120
        '
        'BunifuThinButton22
        '
        Me.BunifuThinButton22.ActiveBorderThickness = 1
        Me.BunifuThinButton22.ActiveCornerRadius = 20
        Me.BunifuThinButton22.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.BunifuThinButton22.ActiveForecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton22.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.BunifuThinButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton22.BackgroundImage = CType(resources.GetObject("BunifuThinButton22.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton22.ButtonText = "Actualizar DV"
        Me.BunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton22.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton22.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton22.IdleBorderThickness = 1
        Me.BunifuThinButton22.IdleCornerRadius = 20
        Me.BunifuThinButton22.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.BunifuThinButton22.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton22.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.BunifuThinButton22.Location = New System.Drawing.Point(571, 4)
        Me.BunifuThinButton22.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton22.Name = "BunifuThinButton22"
        Me.BunifuThinButton22.Size = New System.Drawing.Size(90, 37)
        Me.BunifuThinButton22.TabIndex = 667
        Me.BunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToggleProducts
        '
        Me.ToggleProducts.ActiveColor = System.Drawing.Color.Gray
        Me.ToggleProducts.ActiveText = "DB"
        Me.ToggleProducts.BackColor = System.Drawing.Color.Transparent
        Me.ToggleProducts.InActiveColor = System.Drawing.Color.WhiteSmoke
        Me.ToggleProducts.InActiveText = "Virtual"
        Me.ToggleProducts.Location = New System.Drawing.Point(668, 8)
        Me.ToggleProducts.MaximumSize = New System.Drawing.Size(135, 51)
        Me.ToggleProducts.MinimumSize = New System.Drawing.Size(93, 30)
        Me.ToggleProducts.Name = "ToggleProducts"
        Me.ToggleProducts.Size = New System.Drawing.Size(95, 30)
        Me.ToggleProducts.SliderColor = System.Drawing.Color.Black
        Me.ToggleProducts.SlidingAngle = 5
        Me.ToggleProducts.TabIndex = 666
        Me.ToggleProducts.Text = "ToggleButton21"
        Me.ToggleProducts.TextColor = System.Drawing.Color.White
        Me.ToggleProducts.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.[ON]
        Me.ToggleProducts.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.IOS
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "Nuevo producto"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(473, 4)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(90, 37)
        Me.BunifuThinButton21.TabIndex = 665
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuThinButton21.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(811, -18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 664
        Me.Label3.Text = "Venta con stock"
        Me.Label3.Visible = False
        '
        'CheckStock
        '
        Me.CheckStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckStock.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckStock.Checked = True
        Me.CheckStock.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckStock.ForeColor = System.Drawing.Color.White
        Me.CheckStock.Location = New System.Drawing.Point(788, -22)
        Me.CheckStock.Name = "CheckStock"
        Me.CheckStock.Size = New System.Drawing.Size(20, 20)
        Me.CheckStock.TabIndex = 663
        Me.CheckStock.Visible = False
        '
        'BunifuThinButton24
        '
        Me.BunifuThinButton24.ActiveBorderThickness = 1
        Me.BunifuThinButton24.ActiveCornerRadius = 20
        Me.BunifuThinButton24.ActiveFillColor = System.Drawing.SystemColors.Highlight
        Me.BunifuThinButton24.ActiveForecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton24.ActiveLineColor = System.Drawing.SystemColors.Highlight
        Me.BunifuThinButton24.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton24.BackgroundImage = CType(resources.GetObject("BunifuThinButton24.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton24.ButtonText = "Buscar"
        Me.BunifuThinButton24.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton24.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton24.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton24.IdleBorderThickness = 1
        Me.BunifuThinButton24.IdleCornerRadius = 20
        Me.BunifuThinButton24.IdleFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton24.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton24.IdleLineColor = System.Drawing.SystemColors.Highlight
        Me.BunifuThinButton24.Location = New System.Drawing.Point(375, 4)
        Me.BunifuThinButton24.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton24.Name = "BunifuThinButton24"
        Me.BunifuThinButton24.Size = New System.Drawing.Size(90, 37)
        Me.BunifuThinButton24.TabIndex = 662
        Me.BunifuThinButton24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFiltrar
        '
        Me.txtFiltrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtFiltrar.BeforeTouchSize = New System.Drawing.Size(356, 22)
        Me.txtFiltrar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.txtFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrar.CornerRadius = 4
        Me.txtFiltrar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFiltrar.FarImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtFiltrar.FocusBorderColor = System.Drawing.Color.Silver
        Me.txtFiltrar.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.ForeColor = System.Drawing.Color.White
        Me.txtFiltrar.Location = New System.Drawing.Point(12, 13)
        Me.txtFiltrar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtFiltrar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(356, 22)
        Me.txtFiltrar.TabIndex = 400
        '
        'GridTotales
        '
        Me.GridTotales.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GridTotales.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridTotales.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.White
        Me.GridTotales.BackColor = System.Drawing.Color.Black
        Me.GridTotales.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridTotales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTotales.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridTotales.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.GridTotales.Location = New System.Drawing.Point(0, 45)
        Me.GridTotales.Name = "GridTotales"
        Me.GridTotales.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridTotales.Size = New System.Drawing.Size(844, 483)
        Me.GridTotales.TabIndex = 410
        Me.GridTotales.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Error = "Object reference not set to an instance of an object."
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor1.HeaderText = "Gr."
        GridColumnDescriptor1.MappingName = "destino"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 40
        GridColumnDescriptor2.HeaderText = "id"
        GridColumnDescriptor2.MappingName = "idItem"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 0
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Black)
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor3.HeaderText = "PRODUCTO"
        GridColumnDescriptor3.MappingName = "descripcion"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 313
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 3
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Black)
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Text = ".000"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor4.HeaderText = "STOCK"
        GridColumnDescriptor4.MappingName = "cantidad"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.Width = 70
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Black)
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor5.HeaderText = "U.M."
        GridColumnDescriptor5.MappingName = "unidad"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 55
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Gainsboro)
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor6.HeaderText = "UNIDAD COMERCIAL"
        GridColumnDescriptor6.MappingName = "cboEquivalencias"
        GridColumnDescriptor6.Width = 163
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Gainsboro)
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor7.HeaderText = "CATALOGO DE PRECIOS"
        GridColumnDescriptor7.MappingName = "cboPrecios"
        GridColumnDescriptor7.Width = 150
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.SystemColors.HotTrack
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.GradientInactiveCaption)
        GridColumnDescriptor8.HeaderText = "PREC. VENTA"
        GridColumnDescriptor8.MappingName = "importeMn"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.Width = 0
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor9.HeaderText = "Venta"
        GridColumnDescriptor9.MappingName = "btnVender"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.Width = 0
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor10.HeaderText = "Consultar"
        GridColumnDescriptor10.MappingName = "btConsultarstock"
        GridColumnDescriptor10.Width = 0
        Me.GridTotales.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10})
        Me.GridTotales.TableDescriptor.TableOptions.CaptionRowHeight = 22
        Me.GridTotales.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridTotales.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridTotales.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("destino"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cboEquivalencias"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cboPrecios"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeMn"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("btnVender"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("btConsultarstock")})
        Me.GridTotales.Text = "gridGroupingControl1"
        Me.GridTotales.UseRightToLeftCompatibleTextBox = True
        Me.GridTotales.VersionInfo = "12.2400.0.20"
        '
        'FormCanastaProductsGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(844, 528)
        Me.Controls.Add(Me.GridTotales)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCanastaProductsGeneral"
        Me.ShowIcon = False
        Me.Text = "Canasta de Productos"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTotales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents BunifuThinButton22 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents ToggleProducts As ToggleButton2
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckStock As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents BunifuThinButton24 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents txtFiltrar As Tools.TextBoxExt
    Public WithEvents GridTotales As Grid.Grouping.GridGroupingControl
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAsignarPreciosArticulos
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
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor17 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor18 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextMenor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.TextMayor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextGranMayor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.dgvCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.TextMenor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMayor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextGranMayor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(25, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero de productos seleccionados: 0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Precio x menor"
        '
        'TextMenor
        '
        Me.TextMenor.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TextMenor.BeforeTouchSize = New System.Drawing.Size(147, 22)
        Me.TextMenor.BorderColor = System.Drawing.Color.Silver
        Me.TextMenor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMenor.CurrencyDecimalDigits = 3
        Me.TextMenor.CurrencySymbol = ""
        Me.TextMenor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextMenor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.TextMenor.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextMenor.Location = New System.Drawing.Point(28, 94)
        Me.TextMenor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextMenor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextMenor.Name = "TextMenor"
        Me.TextMenor.NullString = ""
        Me.TextMenor.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.TextMenor.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextMenor.Size = New System.Drawing.Size(77, 22)
        Me.TextMenor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextMenor.TabIndex = 494
        Me.TextMenor.Text = "0.000"
        '
        'RoundButton22
        '
        Me.RoundButton22.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(109, 34)
        Me.RoundButton22.Font = New System.Drawing.Font("Calibri Light", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton22.ForeColor = System.Drawing.Color.White
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(457, 82)
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(109, 34)
        Me.RoundButton22.TabIndex = 495
        Me.RoundButton22.Text = "Grabar"
        Me.RoundButton22.UseVisualStyle = True
        '
        'TextMayor
        '
        Me.TextMayor.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextMayor.BeforeTouchSize = New System.Drawing.Size(147, 22)
        Me.TextMayor.BorderColor = System.Drawing.Color.Silver
        Me.TextMayor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMayor.CurrencyDecimalDigits = 3
        Me.TextMayor.CurrencySymbol = ""
        Me.TextMayor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextMayor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.TextMayor.ForeColor = System.Drawing.Color.Black
        Me.TextMayor.Location = New System.Drawing.Point(119, 94)
        Me.TextMayor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextMayor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextMayor.Name = "TextMayor"
        Me.TextMayor.NullString = ""
        Me.TextMayor.PositiveColor = System.Drawing.Color.Black
        Me.TextMayor.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextMayor.Size = New System.Drawing.Size(77, 22)
        Me.TextMayor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextMayor.TabIndex = 497
        Me.TextMayor.Text = "0.000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(116, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 14)
        Me.Label3.TabIndex = 496
        Me.Label3.Text = "Precio x mayor"
        '
        'TextGranMayor
        '
        Me.TextGranMayor.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.TextGranMayor.BeforeTouchSize = New System.Drawing.Size(147, 22)
        Me.TextGranMayor.BorderColor = System.Drawing.Color.Silver
        Me.TextGranMayor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextGranMayor.CurrencyDecimalDigits = 3
        Me.TextGranMayor.CurrencySymbol = ""
        Me.TextGranMayor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextGranMayor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.TextGranMayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextGranMayor.Location = New System.Drawing.Point(211, 94)
        Me.TextGranMayor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextGranMayor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextGranMayor.Name = "TextGranMayor"
        Me.TextGranMayor.NullString = ""
        Me.TextGranMayor.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextGranMayor.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextGranMayor.Size = New System.Drawing.Size(77, 22)
        Me.TextGranMayor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextGranMayor.TabIndex = 499
        Me.TextGranMayor.Text = "0.000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(208, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 14)
        Me.Label4.TabIndex = 498
        Me.Label4.Text = "Precio x gran mayor"
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.SystemColors.HotTrack
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(109, 34)
        Me.RoundButton21.Font = New System.Drawing.Font("Calibri Light", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(339, 82)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(109, 34)
        Me.RoundButton21.TabIndex = 500
        Me.RoundButton21.Text = "Cambiar precios"
        Me.RoundButton21.UseVisualStyle = True
        '
        'dgvCompra
        '
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCompra.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompra.FreezeCaption = False
        Me.dgvCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue
        Me.dgvCompra.Location = New System.Drawing.Point(0, 0)
        Me.dgvCompra.Name = "dgvCompra"
        Me.dgvCompra.Size = New System.Drawing.Size(698, 327)
        Me.dgvCompra.TabIndex = 501
        Me.dgvCompra.TableDescriptor.AllowNew = False
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCompra.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor13.AllowSort = False
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.MappingName = "idProducto"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 0
        GridColumnDescriptor14.AllowSort = False
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.HeaderText = "ITEM"
        GridColumnDescriptor14.MappingName = "item"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 300
        GridColumnDescriptor15.AllowSort = False
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.HeaderText = "Marca"
        GridColumnDescriptor15.MappingName = "marca"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor15.Width = 90
        GridColumnDescriptor16.HeaderImage = Nothing
        GridColumnDescriptor16.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor16.HeaderText = "Prec. menor"
        GridColumnDescriptor16.MappingName = "menor"
        GridColumnDescriptor16.SerializedImageArray = ""
        GridColumnDescriptor16.Width = 80
        GridColumnDescriptor17.HeaderImage = Nothing
        GridColumnDescriptor17.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor17.HeaderText = "Prec. mayor"
        GridColumnDescriptor17.MappingName = "mayor"
        GridColumnDescriptor17.SerializedImageArray = ""
        GridColumnDescriptor17.Width = 80
        GridColumnDescriptor18.HeaderImage = Nothing
        GridColumnDescriptor18.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor18.HeaderText = "Prec. gran mayor"
        GridColumnDescriptor18.MappingName = "gmayor"
        GridColumnDescriptor18.SerializedImageArray = ""
        GridColumnDescriptor18.Width = 100
        Me.dgvCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16, GridColumnDescriptor17, GridColumnDescriptor18})
        Me.dgvCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompra.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCompra.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idProducto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("item"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("marca"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("menor"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("mayor"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("gmayor")})
        Me.dgvCompra.Text = "GridGroupingControl2"
        Me.dgvCompra.VersionInfo = "12.4400.0.24"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgvCompra)
        Me.Panel1.Location = New System.Drawing.Point(12, 126)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(700, 329)
        Me.Panel1.TabIndex = 502
        '
        'FormAsignarPreciosArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 460)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.TextGranMayor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextMayor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RoundButton22)
        Me.Controls.Add(Me.TextMenor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAsignarPreciosArticulos"
        Me.ShowIcon = False
        Me.Text = "Confirmar precios"
        CType(Me.TextMenor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMayor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextGranMayor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextMenor As Tools.CurrencyTextBox
    Friend WithEvents RoundButton22 As RoundButton2
    Friend WithEvents TextMayor As Tools.CurrencyTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextGranMayor As Tools.CurrencyTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents dgvCompra As Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel1 As Panel
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAnticiposVigentesPersona
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
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.GradientPanel17 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GridBeneficios = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel17.SuspendLayout()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridBeneficios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel17
        '
        Me.GradientPanel17.BackColor = System.Drawing.Color.White
        Me.GradientPanel17.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel17.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel17.Controls.Add(Me.TextRuc)
        Me.GradientPanel17.Controls.Add(Me.TextPersona)
        Me.GradientPanel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel17.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel17.Name = "GradientPanel17"
        Me.GradientPanel17.Size = New System.Drawing.Size(686, 40)
        Me.GradientPanel17.TabIndex = 513
        '
        'TextRuc
        '
        Me.TextRuc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextRuc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextRuc.BorderColor = System.Drawing.Color.Silver
        Me.TextRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuc.CornerRadius = 5
        Me.TextRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRuc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRuc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRuc.Location = New System.Drawing.Point(361, 5)
        Me.TextRuc.MaxLength = 100
        Me.TextRuc.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuc.Name = "TextRuc"
        Me.TextRuc.ReadOnly = True
        Me.TextRuc.Size = New System.Drawing.Size(110, 23)
        Me.TextRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextRuc.TabIndex = 21
        '
        'TextPersona
        '
        Me.TextPersona.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextPersona.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextPersona.BorderColor = System.Drawing.Color.Silver
        Me.TextPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPersona.CornerRadius = 5
        Me.TextPersona.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPersona.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPersona.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextPersona.Location = New System.Drawing.Point(11, 5)
        Me.TextPersona.MaxLength = 100
        Me.TextPersona.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPersona.Name = "TextPersona"
        Me.TextPersona.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.TextPersona.ReadOnly = True
        Me.TextPersona.Size = New System.Drawing.Size(344, 23)
        Me.TextPersona.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextPersona.TabIndex = 20
        '
        'GridBeneficios
        '
        Me.GridBeneficios.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.GridBeneficios.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridBeneficios.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridBeneficios.BackColor = System.Drawing.Color.Gainsboro
        Me.GridBeneficios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridBeneficios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridBeneficios.FreezeCaption = False
        Me.GridBeneficios.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridBeneficios.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridBeneficios.Location = New System.Drawing.Point(0, 40)
        Me.GridBeneficios.Name = "GridBeneficios"
        Me.GridBeneficios.Size = New System.Drawing.Size(686, 273)
        Me.GridBeneficios.TabIndex = 514
        Me.GridBeneficios.TableDescriptor.AllowNew = False
        Me.GridBeneficios.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.GridBeneficios.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GridBeneficios.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridBeneficios.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridBeneficios.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.GridBeneficios.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.GridBeneficios.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridBeneficios.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridBeneficios.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.GridBeneficios.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridBeneficios.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridBeneficios.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.GridBeneficios.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.GridBeneficios.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.GridBeneficios.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.GridBeneficios.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.MappingName = "iddocumeto"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 34
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Código"
        GridColumnDescriptor9.MappingName = "codigo"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 124
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Fecha"
        GridColumnDescriptor10.MappingName = "fecha"
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 110
        GridColumnDescriptor11.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "Tipo"
        GridColumnDescriptor11.MappingName = "tipo"
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 103
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "Importe anticipo"
        GridColumnDescriptor12.MappingName = "importe"
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 102
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.HeaderText = "Monto realizado"
        GridColumnDescriptor13.MappingName = "usado"
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 101
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.SystemColors.HotTrack
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.HeaderText = "Saldo"
        GridColumnDescriptor14.MappingName = "saldo"
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 100
        Me.GridBeneficios.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14})
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.GradientActiveCaption)
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor2.Name = "Row 1"
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor2.DataMember = "saldo"
        GridSummaryColumnDescriptor2.Format = "{Sum}"
        GridSummaryColumnDescriptor2.Name = "saldo"
        GridSummaryColumnDescriptor2.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor2.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor2})
        GridSummaryRowDescriptor2.Title = "Total disponible"
        Me.GridBeneficios.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor2)
        Me.GridBeneficios.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 29
        Me.GridBeneficios.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridBeneficios.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.GridBeneficios.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importe"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("usado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("saldo")})
        Me.GridBeneficios.Text = "GridGroupingControl2"
        Me.GridBeneficios.VersionInfo = "12.4400.0.24"
        '
        'FormAnticiposVigentesPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(686, 313)
        Me.Controls.Add(Me.GridBeneficios)
        Me.Controls.Add(Me.GradientPanel17)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAnticiposVigentesPersona"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.Text = "Anticipos vigentes"
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel17.ResumeLayout(False)
        Me.GradientPanel17.PerformLayout()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridBeneficios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel17 As Tools.GradientPanel
    Friend WithEvents TextPersona As Tools.TextBoxExt
    Friend WithEvents TextRuc As Tools.TextBoxExt
    Friend WithEvents GridBeneficios As Grid.Grouping.GridGroupingControl
End Class

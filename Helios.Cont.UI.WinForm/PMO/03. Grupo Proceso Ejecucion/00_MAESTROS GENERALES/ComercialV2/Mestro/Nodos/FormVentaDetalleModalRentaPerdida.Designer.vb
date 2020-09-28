Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormVentaDetalleModalRentaPerdida
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVentaDetalleModalRentaPerdida))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextCliente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextComprobante = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgvCompra)
        Me.Panel1.Location = New System.Drawing.Point(15, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(947, 381)
        Me.Panel1.TabIndex = 407
        '
        'dgvCompra
        '
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCompra.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCompra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompra.FreezeCaption = False
        Me.dgvCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Silver
        Me.dgvCompra.Location = New System.Drawing.Point(0, 0)
        Me.dgvCompra.Name = "dgvCompra"
        Me.dgvCompra.Size = New System.Drawing.Size(945, 379)
        Me.dgvCompra.TabIndex = 505
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
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idproducto"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.InactiveBorder)
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.Text = "producto"
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Detalle producto"
        GridColumnDescriptor2.MappingName = "producto"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 238
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "marca"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 102
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "U.M."
        GridColumnDescriptor4.MappingName = "unidad"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 93
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Cantidad"
        GridColumnDescriptor5.MappingName = "cantidad"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Total Venta"
        GridColumnDescriptor6.MappingName = "totalventa"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 99
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Valor venta"
        GridColumnDescriptor7.MappingName = "valorventa"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Costo sin iva"
        GridColumnDescriptor8.MappingName = "costo"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 75
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.MappingName = "rentabilidad"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 75
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Resultado %"
        GridColumnDescriptor10.MappingName = "perdidaganancia"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 100
        Me.dgvCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10})
        Me.dgvCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompra.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCompra.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idproducto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("marca"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("totalventa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("valorventa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("costo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("rentabilidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("perdidaganancia")})
        Me.dgvCompra.Text = "GridGroupingControl2"
        Me.dgvCompra.VersionInfo = "12.4400.0.24"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(976, 10)
        Me.GradientPanel1.TabIndex = 432
        '
        'TextCliente
        '
        Me.TextCliente.BackColor = System.Drawing.SystemColors.HotTrack
        Me.TextCliente.BeforeTouchSize = New System.Drawing.Size(346, 22)
        Me.TextCliente.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCliente.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCliente.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCliente.ForeColor = System.Drawing.Color.White
        Me.TextCliente.Location = New System.Drawing.Point(16, 33)
        Me.TextCliente.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCliente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCliente.Name = "TextCliente"
        Me.TextCliente.NearImage = CType(resources.GetObject("TextCliente.NearImage"), System.Drawing.Image)
        Me.TextCliente.ReadOnly = True
        Me.TextCliente.Size = New System.Drawing.Size(346, 22)
        Me.TextCliente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCliente.TabIndex = 434
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 433
        Me.Label1.Text = "CLIENTE"
        '
        'TextComprobante
        '
        Me.TextComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextComprobante.BeforeTouchSize = New System.Drawing.Size(346, 22)
        Me.TextComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextComprobante.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextComprobante.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextComprobante.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextComprobante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextComprobante.Location = New System.Drawing.Point(368, 33)
        Me.TextComprobante.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextComprobante.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextComprobante.Name = "TextComprobante"
        Me.TextComprobante.NearImage = CType(resources.GetObject("TextComprobante.NearImage"), System.Drawing.Image)
        Me.TextComprobante.ReadOnly = True
        Me.TextComprobante.Size = New System.Drawing.Size(346, 22)
        Me.TextComprobante.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextComprobante.TabIndex = 436
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(365, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 15)
        Me.Label2.TabIndex = 435
        Me.Label2.Text = "NRO. VENTA"
        '
        'FormVentaDetalleModalRentaPerdida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        CaptionLabel1.ForeColor = System.Drawing.SystemColors.Highlight
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Rentabilidad"
        CaptionLabel2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel2.Location = New System.Drawing.Point(55, 25)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Text = "Detalle de Venta"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(976, 446)
        Me.Controls.Add(Me.TextComprobante)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormVentaDetalleModalRentaPerdida"
        Me.ShowIcon = False
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvCompra As Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents TextCliente As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents TextComprobante As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
End Class

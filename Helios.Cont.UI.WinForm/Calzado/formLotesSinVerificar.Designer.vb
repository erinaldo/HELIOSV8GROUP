Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formLotesSinVerificar
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
        Me.GridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridGroupingControl1
        '
        Me.GridGroupingControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.GridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
        Me.GridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridGroupingControl1.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2016Black
        Me.GridGroupingControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridGroupingControl1.Name = "GridGroupingControl1"
        Me.GridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridGroupingControl1.Size = New System.Drawing.Size(926, 483)
        Me.GridGroupingControl1.TabIndex = 0
        Me.GridGroupingControl1.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderText = "ID"
        GridColumnDescriptor1.MappingName = "codigolote"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderText = "Nro. lote"
        GridColumnDescriptor2.MappingName = "NroLote"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 94
        GridColumnDescriptor3.HeaderText = "Fecha compra"
        GridColumnDescriptor3.MappingName = "fechaCompra"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 150
        GridColumnDescriptor4.HeaderText = "Tipo doc."
        GridColumnDescriptor4.MappingName = "tipodoc"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.Width = 100
        GridColumnDescriptor5.HeaderText = "Nro. compra"
        GridColumnDescriptor5.MappingName = "nrocompra"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 121
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Text = "0"
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Yellow
        GridColumnDescriptor6.HeaderText = "Cantidad"
        GridColumnDescriptor6.MappingName = "cantidadtotal"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.Width = 118
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor7.HeaderText = "Acción"
        GridColumnDescriptor7.MappingName = "btConfirmar"
        GridColumnDescriptor7.Width = 96
        Me.GridGroupingControl1.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("obj"), GridColumnDescriptor7})
        Me.GridGroupingControl1.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridGroupingControl1.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridGroupingControl1.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigolote"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NroLote"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaCompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipodoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nrocompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidadtotal"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("btConfirmar")})
        Me.GridGroupingControl1.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.GridGroupingControl1.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.GridGroupingControl1.Text = "GridGroupingControl1"
        Me.GridGroupingControl1.UseRightToLeftCompatibleTextBox = True
        Me.GridGroupingControl1.VersionInfo = "16.4460.0.42"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(926, 0)
        Me.GradientPanel1.TabIndex = 1
        '
        'formLotesSinVerificar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(926, 483)
        Me.Controls.Add(Me.GridGroupingControl1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "formLotesSinVerificar"
        Me.ShowIcon = False
        Me.Text = "Lotes Sin Verificar"
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridGroupingControl1 As Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCReporteVentaProductos
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.dgPedidos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgPedidos
        '
        Me.dgPedidos.BackColor = System.Drawing.Color.Black
        Me.dgPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPedidos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgPedidos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2010
        Me.dgPedidos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.dgPedidos.HorizontalScrollTips = True
        Me.dgPedidos.Location = New System.Drawing.Point(0, 0)
        Me.dgPedidos.Name = "dgPedidos"
        Me.dgPedidos.Office2010ScrollBarsColorScheme = Syncfusion.Windows.Forms.Office2010ColorScheme.Black
        Me.dgPedidos.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgPedidos.Size = New System.Drawing.Size(1077, 364)
        Me.dgPedidos.TabIndex = 418
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor2.HeaderText = "Documento"
        GridColumnDescriptor2.MappingName = "nomDoc"
        GridColumnDescriptor2.Width = 70
        GridColumnDescriptor3.HeaderText = "Serie"
        GridColumnDescriptor3.MappingName = "serie"
        GridColumnDescriptor3.Width = 70
        GridColumnDescriptor4.HeaderText = "Numero"
        GridColumnDescriptor4.MappingName = "numero"
        GridColumnDescriptor4.Width = 80
        GridColumnDescriptor5.HeaderText = "NªDoc"
        GridColumnDescriptor5.MappingName = "docClie"
        GridColumnDescriptor5.Width = 70
        GridColumnDescriptor6.HeaderText = "Cliente"
        GridColumnDescriptor6.MappingName = "cliente"
        GridColumnDescriptor6.Width = 150
        GridColumnDescriptor7.HeaderText = "Tipo venta"
        GridColumnDescriptor7.MappingName = "tipoCompra"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.Width = 90
        GridColumnDescriptor8.HeaderText = "Fecha"
        GridColumnDescriptor8.MappingName = "fechaDoc"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.Width = 126
        GridColumnDescriptor9.HeaderText = "Producto"
        GridColumnDescriptor9.MappingName = "Producto"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.Width = 222
        GridColumnDescriptor10.HeaderText = "Afectacion"
        GridColumnDescriptor10.MappingName = "afectacion"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.Width = 67
        GridColumnDescriptor11.HeaderText = "V.Venta"
        GridColumnDescriptor11.MappingName = "valorventa"
        GridColumnDescriptor12.HeaderText = "IVA."
        GridColumnDescriptor12.MappingName = "iva"
        GridColumnDescriptor13.HeaderText = "P.U."
        GridColumnDescriptor13.MappingName = "preciounitario"
        GridColumnDescriptor14.MappingName = "total"
        GridColumnDescriptor14.Width = 83
        GridColumnDescriptor15.HeaderText = "Vendedor"
        GridColumnDescriptor15.MappingName = "usuarioActualizacion"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.Width = 150
        GridColumnDescriptor16.HeaderText = "Con Stock"
        GridColumnDescriptor16.MappingName = "AfectaStock"
        GridColumnDescriptor16.ReadOnly = True
        GridColumnDescriptor16.Width = 66
        Me.dgPedidos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("unidad"), GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16})
        Me.dgPedidos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoCompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nomDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("serie"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numero"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("docClie"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cliente"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("afectacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("valorventa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("iva"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("preciounitario"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("total"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("AfectaStock")})
        Me.dgPedidos.Text = "GridGroupingControl2"
        Me.dgPedidos.TopLevelGroupOptions.ShowSummaries = True
        Me.dgPedidos.UseRightToLeftCompatibleTextBox = True
        Me.dgPedidos.VersionInfo = "12.4400.0.24"
        '
        'UCReporteVentaProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgPedidos)
        Me.Name = "UCReporteVentaProductos"
        Me.Size = New System.Drawing.Size(1077, 364)
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgPedidos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

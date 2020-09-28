Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Windows.Forms.Grid
Public Class UCRentabilidadXfecha

#Region "Attributes"
    Public UCResumenVentasCustom As UCRentabilidad
#End Region


#Region "Constructors"
    'Public Sub New(fecha As Date, idEstablecimiento As Integer, form As UCResumenVentasRentabilidad)

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    UCResumenVentasCustom = form
    '    FormatoGrid()
    'End Sub

    Public Sub New(lista As List(Of InventarioMovimiento), form As UCRentabilidad)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCResumenVentasCustom = form
        FormatoGrid()
        GetRentabilidad(lista)
    End Sub

#End Region

#Region "Formato GRID"
    Private Sub FormatoGrid()
        Me.GridRentabilidad.Appearance.ColumnHeaderCell.Interior = New BrushInfo(GradientStyle.Vertical, Color.Black, Color.Black)
        Me.GridRentabilidad.TopLevelGroupOptions.ShowCaption = False
        Dim colorF As GridMetroColors = New GridMetroColors()
        colorF.HeaderColor.NormalColor = Color.Black
        colorF.HeaderColor.HoverColor = Color.Empty
        Me.GridRentabilidad.SetMetroStyle(colorF)
        Me.GridRentabilidad.AllowProportionalColumnSizing = False
        '     Me.GridRentabilidad.DisplayVerticalLines = False
        Me.GridRentabilidad.BrowseOnly = True
        Me.GridRentabilidad.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        Me.GridRentabilidad.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        Me.GridRentabilidad.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Me.GridRentabilidad.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        Me.GridRentabilidad.TableOptions.ShowRowHeader = False
        Me.GridRentabilidad.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(30, 30, 30))
        Dim captionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Me.GridRentabilidad.Table.DefaultRecordRowHeight = 30
        Me.GridRentabilidad.Table.DefaultColumnHeaderRowHeight = 35
        Me.GridRentabilidad.Appearance.AnyCell.TextColor = Color.White
        Me.GridRentabilidad.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        Me.GridRentabilidad.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        Me.GridRentabilidad.TableDescriptor.Appearance.AnyCell.Borders.Bottom = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.GridRentabilidad.TableDescriptor.Appearance.AnyCell.Borders.Right = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.GridRentabilidad.TableDescriptor.Appearance.AnyHeaderCell.Borders.Top = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.GridRentabilidad.GridOfficeScrollBars = OfficeScrollBars.Metro
        Me.GridRentabilidad.TableControl.MetroColorTable.ScrollerBackground = Color.FromArgb(45, 45, 45)
        Me.GridRentabilidad.TableControl.MetroColorTable.ArrowNormal = Color.FromArgb(195, 195, 195)
        Me.GridRentabilidad.TableControl.MetroColorTable.ArrowChecked = Color.FromArgb(94, 171, 222)
        Me.GridRentabilidad.TableControl.MetroColorTable.ThumbNormal = Color.FromArgb(31, 31, 31)
        Me.GridRentabilidad.TableControl.MetroColorTable.ThumbPushed = Color.FromArgb(94, 171, 222)
        '   Me.GridRentabilidad.TableControl.HScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Disabled
    End Sub
#End Region

#Region "Methods"
    Private Sub GetRentabilidad(lista As List(Of InventarioMovimiento))
        Dim dt As New DataTable
        dt.Columns.Add("almacen")
        dt.Columns.Add("tipoex")
        dt.Columns.Add("afectacion")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("contenido")
        dt.Columns.Add("preciounitario")
        dt.Columns.Add("totalventa")
        dt.Columns.Add("valorventa")
        dt.Columns.Add("costo")
        dt.Columns.Add("rentabilidad")
        dt.Columns.Add("costoiva")
        dt.Columns.Add("rentabilidadiva")
        dt.Columns.Add("nroLote")
        dt.Columns.Add("comprobante")

        dt.Columns.Add("categoria")
        dt.Columns.Add("subcategoria")
        dt.Columns.Add("marca")

        Dim preciounitario As Decimal = 0
        Dim rentabilidad As Decimal = 0
        Dim rentabilidadConIva As Decimal = 0

        'Dim totalrentaSinIva As Decimal = 0
        'Dim totalrentaSConIva As Decimal = 0
        For Each i In lista
            If i.cantidad.GetValueOrDefault > 0 Then
                preciounitario = Math.Round(i.monto.GetValueOrDefault / i.cantidad.GetValueOrDefault, 2)
            Else
                preciounitario = 0
            End If

            rentabilidad = i.ValorDeVenta.GetValueOrDefault - i.montoOther.GetValueOrDefault
            '  totalrentaSinIva += rentabilidad

            rentabilidadConIva = i.monto.Value - (i.montoOther.GetValueOrDefault * 1.18)
            ' totalrentaSConIva += rentabilidadConIva


            Dim categoria As String = "-"
            Dim Subcategoria As String = "-"
            Dim Marca As String = "-"

            If i.customProducto IsNot Nothing Then
                If i.customProducto.item IsNot Nothing Then
                    categoria = i.customProducto.item.descripcion
                End If
                If i.customProducto.CustomSubCategoria IsNot Nothing Then
                    Subcategoria = i.customProducto.CustomSubCategoria.descripcion
                End If

                If i.customProducto.customMarca IsNot Nothing Then
                    Marca = i.customProducto.customMarca.descripcion
                End If

            End If


            If i.tipoExistencia = "GS" Then
                'dt.Rows.Add("-",
                '        i.tipoExistencia, i.destinoGravadoItem,
                '        i.descripcion, i.unidad,
                '        "1", preciounitario,
                '        i.monto.GetValueOrDefault.ToString("N2"), i.ValorDeVenta.GetValueOrDefault.ToString("N2"),
                '        i.montoOther.GetValueOrDefault.ToString("N2"), rentabilidad.ToString("N2"),
                '        i.montoOther.GetValueOrDefault.ToString("N2"),
                '        rentabilidadConIva.ToString("N2"),
                '        "-",
                '        "-",
                '        categoria, Subcategoria, Marca)
            Else


                Dim Contenido = ""

                If i.contenido_neto IsNot Nothing Then
                    Contenido = i.contenido_neto
                Else
                    Contenido = 1
                End If

                dt.Rows.Add(i.NombreAlmacen,
                        i.tipoExistencia, i.destinoGravadoItem,
                        i.descripcion, i.unidad, i.cantidad / Contenido,
                        i.cantidad, preciounitario,
                        i.monto.GetValueOrDefault.ToString("N2"), i.ValorDeVenta.GetValueOrDefault.ToString("N2"),
                        i.montoOther.GetValueOrDefault.ToString("N2"), rentabilidad.ToString("N2"),
                        i.montoOther.GetValueOrDefault.ToString("N2"),
                        rentabilidadConIva.ToString("N2"),
                        $"{i.customLote.codigoLote} - {i.customLote.nroLote}",
                        If(i.serie = "9907", $"{"NOTA"}-{i.numero}", $"{i.serie}-{i.numero}"),
                        categoria, Subcategoria, Marca)
            End If


        Next
        GridRentabilidad.DataSource = dt
        Dim rentaSinIgv As Decimal = lista.Sum(Function(o) o.ValorDeVenta.GetValueOrDefault) - lista.Sum(Function(o) o.montoOther.GetValueOrDefault)
        Dim rentaconIgv As Decimal = lista.Sum(Function(o) o.monto.GetValueOrDefault) - (lista.Sum(Function(o) o.montoOther.GetValueOrDefault) * 1.18)


        UCResumenVentasCustom.LabelTotalRentaSinIva.Text = rentaSinIgv.ToString("N2")
        '    UCResumenVentasCustom.LabelTotalRentaConIva.Text = rentaconIgv.ToString("N2")
    End Sub
#End Region

#Region "Events"

#End Region

End Class

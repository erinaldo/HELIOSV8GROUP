Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid

Public Class frmCostoVentaTipoExistencia
    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0
    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0
#Region "Métodos"
    Dim be2 As New InventarioMovimiento
    Dim Lista_Libre As New List(Of InventarioMovimiento)
    Public Sub New(be As InventarioMovimiento)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GridCFGInventarios(dgDetalle)
        GetLSV(be)
        Lista_Libre = GetCostoVentaXtipoExistencia(be)
    End Sub

    Sub GridCFGInventarios(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        'grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.FromKnownColor(KnownColor.HotTrack) '  Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Private Sub GetLSV(be As InventarioMovimiento)
        Dim lista = GetCostoVentaXtipoExistencia(be)

        Dim sumObj = (From InventarioMovimientoes In lista
                      Group InventarioMovimientoes By InventarioMovimientoes.tipoProducto Into g = Group
                      Select
                          tipoProducto,
                          monto = CType(g.Sum(Function(p) p.monto), Decimal?)).ToList

        'Dim lista2 = (From s In lista Select s.tipoProducto).Distinct.ToList

        Dim strTipoEx As String = Nothing
        For Each i In sumObj
            Select Case i.tipoProducto
                Case TipoExistencia.Mercaderia
                    strTipoEx = "Mercadería"
                Case TipoExistencia.ActivoInmovilizado
                    strTipoEx = "Activo Inmovilizado"
                Case TipoExistencia.EnvasesEmbalajes
                    strTipoEx = "Envases y Embalajes"
                Case TipoExistencia.MaterialAuxiliar_SuministroRepuesto
                    strTipoEx = "Materiales Auxiliares Suministros y Repuestos"
                Case TipoExistencia.MateriaPrima
                    strTipoEx = "Materia Prima"
                Case TipoExistencia.ProductosEnProceso
                    strTipoEx = "Productos en Proceso"
                Case TipoExistencia.ProductoTerminado
                    strTipoEx = "Productos terminados"
                Case TipoExistencia.SubProductosDesechos
                    strTipoEx = "Sub Productos y desechos"

            End Select

            Dim n As New ListViewItem(strTipoEx)

            'Dim SumaTipoProd = Aggregate s In lista
            '                       Where s.tipoProducto = i
            '                           Into Sum(s.monto)

            n.SubItems.Add(i.monto.GetValueOrDefault)
            lsvCostoVentas.Items.Add(n)
        Next

        'For Each i In lista2
        '    Dim n As New ListViewItem(i)

        '    Dim SumaTipoProd = Aggregate s In lista
        '                           Where s.tipoProducto = i
        '                               Into Sum(s.monto)

        '    n.SubItems.Add(SumaTipoProd.GetValueOrDefault)
        '    lsvCostoVentas.Items.Add(n)
        'Next


    End Sub

    Private Function GetCostoVentaXtipoExistencia(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim New_listaInventario As List(Of InventarioMovimiento)

        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim sumaCostoVenta As Decimal = 0
        'Dim valTipoExistencia As String = Nothing


        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        New_listaInventario = New List(Of InventarioMovimiento)
        listaInventario = inventario.GetKardexByAnio(be)


        For Each i As InventarioMovimiento In listaInventario
            cantidadDeficit = 0
            importeDeficit = 0
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then ' AndAlso valTipoExistencia = i.tipoProducto Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If

                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If

                    pmAcumnulado = precUnit
                Case "S", "D"
                    Dim n As New ListViewItem(i.tipoProducto)
                    n.SubItems.Add(i.monto)

                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

                    If producto = i.idItem Then 'AndAlso valTipoExistencia = i.tipoProducto Then
                        productoCache = i.nombreItem
                        'canSaldo += CDec(i.cantidad)

                        Select Case i.tipoOperacion
                            Case "9913"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo = ImporteSaldo

                            Case "9914"
                                canSaldo = canSaldo
                                ImporteSaldo += i.monto

                            Case "9916"
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += i.monto

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0
                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If

                    Select Case i.tipoOperacion
                        Case "9913"
                            'dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            'dr(11) = (0)
                            'dr(12) = 0.0

                        Case "9914"
                            'dr(10) = 0.0
                            'dr(11) = (0)
                            'dr(12) = i.monto * -1

                            '   Case "9916"
                            'dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            'dr(11) = (0)
                            'dr(12) = i.monto * -1

                        Case Else
                            If i.tipoOperacion = "01" Then
                                Dim valCap = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1
                                sumaCostoVenta += valCap

                                New_listaInventario.Add(New InventarioMovimiento With {.tipoProducto = i.tipoProducto, .monto = valCap, .idDocumento = i.idDocumento, .tipoOperacion = "01"})
                            ElseIf i.tipoOperacion = "9916" Then
                                Dim valCap = i.monto  'i.monto (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1
                                sumaCostoVenta += valCap

                                'sumaCostoVenta += i.monto

                                New_listaInventario.Add(New InventarioMovimiento With {.tipoProducto = i.tipoProducto, .monto = valCap, .idDocumento = i.idDocumento, .tipoOperacion = "9916"})
                            End If
                            'dr(12) =  '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    'dr(13) = (FormatNumber(canSaldo, 4))
                    'dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    'dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select

            producto = i.idItem
            productoCache = i.nombreItem
            'valTipoExistencia = i.tipoProducto

        Next

        Return New_listaInventario
    End Function


    Private Sub GetInventarioSelXtipoExistencia(tipoex As String)
        Dim invSA As New inventarioMovimientoSA
        Dim compraSA As New DocumentoCompraSA
        Dim compra As New documentocompra
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim venta As New documentoventaAbarrotes
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("fecha")
        dt.Columns.Add("numero")
        dt.Columns.Add("cliente")
        dt.Columns.Add("moneda")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")

        For Each i In Lista_Libre.Where(Function(o) o.tipoProducto = tipoex).ToList 'invSA.GetSelXtipoExistenciaVenta(New InventarioMovimiento With {.idAlmacen = be2.idAlmacen, .fecha = be2.fecha, .tipoProducto = tipoex})

            Select Case i.tipoOperacion
                Case StatusTipoOperacion.VENTA
                    venta = ventaSA.GetUbicar_documentoventaAbarrotesPorID(i.idDocumento)

                    If Not IsNothing(venta) Then
                        entidad = entidadSA.UbicarEntidadPorID(venta.idCliente).FirstOrDefault


                        If Not IsNothing(entidad) Then
                            dt.Rows.Add(i.idDocumento, venta.tipoDocumento, venta.fechaDoc,
                                    venta.serie, entidad.nombreCompleto,
                                    venta.moneda,
                                    i.monto, i.montoUSD)
                        Else
                            dt.Rows.Add(i.idDocumento, venta.tipoDocumento, venta.fechaDoc,
                                    venta.serie, "-",
                                    venta.moneda,
                                    i.monto, i.montoUSD)
                        End If
                    End If
                Case StatusTipoOperacion.NC_DEVOLUCION_DE_EXISTENCIAS
                    compra = compraSA.UbicarDocumentoCompra(i.idDocumento)
                    entidad = entidadSA.UbicarEntidadPorID(compra.idProveedor).FirstOrDefault

                    If Not IsNothing(compra) Then
                        dt.Rows.Add(i.idDocumento, compra.tipoDoc, compra.fechaDoc,
                             compra.serie, entidad.nombreCompleto,
                             compra.monedaDoc,
                             i.monto, i.montoUSD)
                    End If

            End Select

            
            
        Next
        dgDetalle.DataSource = dt
    End Sub

#End Region


    Private Sub frmCostoVentaTipoExistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEmpresa.Text = Gempresas.NomEmpresa
        txtEstable.Text = GEstableciento.NombreEstablecimiento
    End Sub

    Private Sub lsvCostoVentas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCostoVentas.MouseDoubleClick
        Cursor = Cursors.WaitCursor
        Dim l As ListViewItem = lsvCostoVentas.SelectedItems(0)
        Dim strTipoEx As String = Nothing
        Select Case l.SubItems(0).Text
            Case "Mercadería"
                strTipoEx = TipoExistencia.Mercaderia
            Case "Activo Inmovilizado"
                strTipoEx = TipoExistencia.ActivoInmovilizado
            Case "Envases y Embalajes"
                strTipoEx = TipoExistencia.EnvasesEmbalajes
            Case "Materiales Auxiliares Suministros y Repuestos"
                strTipoEx = TipoExistencia.MaterialAuxiliar_SuministroRepuesto
            Case "Materia Prima"
                strTipoEx = TipoExistencia.MateriaPrima
            Case "Productos en Proceso"
                strTipoEx = TipoExistencia.ProductosEnProceso
            Case "Productos terminados"
                strTipoEx = TipoExistencia.ProductoTerminado
            Case "Sub Productos y desechos"
                strTipoEx = TipoExistencia.SubProductosDesechos

        End Select

        GetInventarioSelXtipoExistencia(strTipoEx)
        Cursor = Cursors.Default
    End Sub

    Private Sub lsvCostoVentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCostoVentas.SelectedIndexChanged

    End Sub
End Class
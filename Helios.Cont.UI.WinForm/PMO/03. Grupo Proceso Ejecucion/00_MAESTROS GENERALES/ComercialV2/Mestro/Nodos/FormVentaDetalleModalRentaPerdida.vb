Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormVentaDetalleModalRentaPerdida

    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0
    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim listaInventario As New List(Of InventarioMovimiento)
    Dim TotalMercaderia As Decimal = CDec(0.0)
    Dim TotalProductoTerminado As Decimal = CDec(0.0)
    Dim TotalSubProductosTerminados As Decimal = CDec(0.0)

    Public Sub New(idDocumento As Integer, Cliente As String, comprobante As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextCliente.Text = Cliente
        TextComprobante.Text = comprobante
        GetCostoVenta(idDocumento)
        FormatoGridAvanzado(dgvCompra, True, False, 10.0F)
    End Sub

#Region "Methdos"
    Private Sub GetCostoVenta(idDocumento As Integer)
        Dim NuevaListaInventario As New List(Of InventarioMovimiento)
        Dim cierreSA As New CierreInventarioSA
        Dim cierre As New cierreinventario
        Dim listaCierre As New List(Of cierreinventario)
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim codigoLotex As Integer = 0
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim almacenSA As New almacenSA
        Dim documentosa As New documentoVentaAbarrotesSA
        Dim listaInventario2 As New List(Of InventarioMovimiento)
        '-----------------------------------------------------------------------------------------------------
        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m

        Dim almacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        '    ListaCurar = New List(Of totalesAlmacen)

        NuevaListaInventario = New List(Of InventarioMovimiento)
        Dim costoSalida As Decimal = 0
        For Each al In almacenes

            listaInventario = inventario.GetRentabilidadPorComprobante(New InventarioMovimiento With
                                                           {
                                                           .idAlmacen = al.idAlmacen,
                                                           .idDocumento = idDocumento
                                                           })

            ImporteSaldo = 0
            canSaldo = 0
            For Each i As InventarioMovimiento In listaInventario
                costoSalida = 0
                cantidadDeficit = 0
                importeDeficit = 0

                Select Case i.tipoRegistro
                    Case "E", "EA", "EC"
                        If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
                            If i.tipoOperacion = 9916 Then
                                productoCache = i.nombreItem
                                canSaldo += CDec(i.cantidad.GetValueOrDefault)
                                ImporteSaldo += CDec(i.monto.GetValueOrDefault)
                                costoSalida = CDec(i.monto.GetValueOrDefault)
                            Else
                                productoCache = i.nombreItem
                                canSaldo += CDec(i.cantidad.GetValueOrDefault)
                                ImporteSaldo += CDec(i.monto.GetValueOrDefault)
                            End If


                        Else
                            cantidadDeficit = canSaldo
                            importeDeficit = ImporteSaldo

                            canSaldo = 0
                            ImporteSaldo = 0

                            'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                            canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                            ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
                            canSaldo = CDec(i.cantidad.GetValueOrDefault) + canSaldo
                            ImporteSaldo = CDec(i.monto.GetValueOrDefault) + ImporteSaldo

                        End If
                        If canSaldo > 0 Then
                            precUnit = ImporteSaldo / canSaldo
                        Else
                            precUnit = 0
                        End If
                        pmAcumnulado = precUnit
                    Case "S", "D"
                        Dim co As Decimal = 0
                        co = CDec(i.cantidad.GetValueOrDefault) * pmAcumnulado

                        If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
                            productoCache = i.nombreItem
                            'canSaldo += CDec(i.cantidad)

                            Select Case i.tipoOperacion
                                Case "9913"
                                    canSaldo += CDec(i.cantidad.GetValueOrDefault)
                                    ImporteSaldo = ImporteSaldo

                                Case "9914"
                                    canSaldo = canSaldo
                                    ImporteSaldo += i.monto.GetValueOrDefault

                                Case "9916"
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo += i.monto.GetValueOrDefault

                                    costoSalida = i.monto.GetValueOrDefault * -1

                                Case StatusTipoOperacion.REVERSIONES
                                    canSaldo += CDec(i.cantidad.GetValueOrDefault)
                                    ImporteSaldo += i.monto.GetValueOrDefault

                                Case Else
                                    canSaldo += CDec(i.cantidad.GetValueOrDefault)
                                    ImporteSaldo += co

                                    costoSalida = co * -1
                            End Select

                        Else
                            cantidadDeficit = canSaldo
                            importeDeficit = ImporteSaldo

                            canSaldo = 0
                            ImporteSaldo = 0
                            'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                            canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                            ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault

                            canSaldo += CDec(i.cantidad.GetValueOrDefault)
                            ImporteSaldo += CDec((i.cantidad.GetValueOrDefault * pmAcumnulado))
                        End If

                        If canSaldo > 0 Then
                            precUnit = ImporteSaldo / canSaldo
                        Else
                            precUnit = 0
                        End If

                        pmAcumnulado = precUnit
                End Select

                producto = i.idItem
                codigoLotex = i.customLote.codigoLote
                productoCache = i.nombreItem

                NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                         .idDocumentoRef = i.idDocumento,
                                         .tipoOperacion = i.tipoOperacion,
                                         .fecha = i.fecha,
                                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                            .NombreAlmacen = al.descripcionAlmacen,
                                            .NombrePresentacion = GEstableciento.NombreEstablecimiento,
                                         .idAlmacen = i.idAlmacen,
                                         .idItem = i.idItem,
                                         .descripcion = i.nombreItem,
                                         .tipoExistencia = i.tipoProducto,
                                         .unidad = i.unidad,
                                         .CantSaldo = (canSaldo),
                                           .saldoMonto = ImporteSaldo,
                                         .CostoSalida = costoSalida,
                                         .monto = (i.monto).GetValueOrDefault,
                                         .nrolote = codigoLotex = i.customLote.codigoLote,
                                         .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault,
                                         .cantidad = CInt(i.cantidad.GetValueOrDefault * -1),
                                         .presentacion = i.NombrePresentacion,
                                         .destinoGravadoItem = i.destinoGravadoItem,
                                         .montoOther = i.montoOther.GetValueOrDefault})
            Next
        Next

        'listaInventario2 = documentosa.getListaServiosXVenta(New InventarioMovimiento With {.fecha = New DateTime(anio, mes, 1)}, txtFecha.Value, txtFecha.Value, "Dia")

        'If (Not IsNothing(listaInventario2)) Then
        '    For Each i As InventarioMovimiento In listaInventario2
        '        NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                    .idDocumentoRef = i.idDocumento,
        '                                    .tipoOperacion = i.tipoOperacion,
        '                                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                    .NombreAlmacen = Nothing,
        '                                    .NombrePresentacion = GEstableciento.NombreEstablecimiento,
        '                                    .idAlmacen = i.idAlmacen,
        '                                    .idItem = i.idItem,
        '                                    .descripcion = i.nombreItem,
        '                                    .tipoExistencia = i.tipoExistencia,
        '                                    .unidad = i.unidad,
        '                                    .nrolote = codigoLotex = i.customLote.codigoLote,
        '                                    .CantSaldo = CInt(i.cantidad.GetValueOrDefault * -1),
        '                                    .saldoMonto = ImporteSaldo,
        '                                    .monto = i.monto.GetValueOrDefault,
        '                                    .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault,
        '                                 .presentacion = i.NombrePresentacion,
        '                                 .destinoGravadoItem = i.destinoGravadoItem,
        '                                 .montoOther = i.montoOther.GetValueOrDefault})
        '    Next
        'End If
        CargarCostoVenta(NuevaListaInventario)

    End Sub

    Public Function GetGananciaPerdida(VentaTotal As Decimal, costoCompraSinIva As Decimal, ValorVenta As Decimal) As Decimal

        Dim resultadoUtilidadOperdida = ValorVenta - costoCompraSinIva
        Dim resultadoCosto = resultadoUtilidadOperdida / costoCompraSinIva
        Dim ValorPorcentaje = resultadoCosto * 100

        Return ValorPorcentaje
    End Function

    Sub CargarCostoVenta(lista As List(Of InventarioMovimiento))
        Dim documentoSA As New DocumentoSA
        Dim dt As New DataTable
        Dim listaTipoExistencia As New List(Of String)
        listaTipoExistencia.Add(TipoExistencia.Mercaderia)
        listaTipoExistencia.Add(TipoExistencia.ProductoTerminado)
        listaTipoExistencia.Add(TipoExistencia.SubProductosDesechos)
        listaTipoExistencia.Add(TipoExistencia.ServicioGasto)

        TotalMercaderia = CDec(0.0)
        TotalProductoTerminado = CDec(0.0)
        TotalSubProductosTerminados = CDec(0.0)


        Dim condicion As New List(Of String)
        condicion.Add(StatusTipoOperacion.VENTA)
        condicion.Add(StatusTipoOperacion.NC_DEVOLUCION_DE_EXISTENCIAS)
        Dim consulta = (From n In lista
                        Where condicion.Contains(n.tipoOperacion) _
                        And listaTipoExistencia.Contains(n.tipoExistencia)).ToList

        listaInventario = consulta
        dt.Columns.Add("idproducto")
        dt.Columns.Add("producto")
        dt.Columns.Add("marca")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("totalventa")
        dt.Columns.Add("valorventa")
        dt.Columns.Add("costo")
        dt.Columns.Add("rentabilidad")
        dt.Columns.Add("perdidaganancia")

        For Each i In listaInventario
            dt.Rows.Add(i.idItem, i.descripcion, String.Empty, i.unidad, i.cantidad, FormatNumber(i.monto, 2), FormatNumber(i.ValorDeVenta, 2), FormatNumber(i.montoOther, 2), FormatNumber(i.ValorDeVenta - i.montoOther, 2),
                        FormatNumber(GetGananciaPerdida(i.monto, i.montoOther, i.ValorDeVenta), 2))
        Next
        dgvCompra.DataSource = dt

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            'Checks for the column name when the cellvalue is greater than 5.
            'ENTRADAS A ALMACEN
            If e.TableCellIdentity.Column.MappingName = "perdidaganancia" _
                AndAlso CDbl(Fix(e.Style.CellValue)) > 5 AndAlso CDbl(Fix(e.Style.CellValue)) < 10 Then
                e.Style.BackColor = Color.FromArgb(41, 196, 44)
                e.Style.TextColor = Color.White

            ElseIf e.TableCellIdentity.Column.MappingName = "perdidaganancia" _
                AndAlso CDbl(Fix(e.Style.CellValue)) <= 4 Then
                e.Style.BackColor = Color.Red
                e.Style.TextColor = Color.White

            ElseIf e.TableCellIdentity.Column.MappingName = "perdidaganancia" _
                AndAlso CDbl(Fix(e.Style.CellValue)) >= 10 Then
                e.Style.BackColor = Color.FromKnownColor(KnownColor.HotTrack)
                e.Style.TextColor = Color.White
            End If

        End If
    End Sub
#End Region

End Class
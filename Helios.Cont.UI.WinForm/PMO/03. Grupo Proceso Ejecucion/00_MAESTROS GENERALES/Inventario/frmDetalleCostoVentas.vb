Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmDetalleCostoVentas
    Inherits frmMaster

#Region "Variables"
    Dim filter As New GridExcelFilter()
    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0
    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0
#End Region

#Region "Constructors"

    Public Sub New(strTipoEx As String, estable As Integer, almacen As Integer, Lista_Libre As List(Of InventarioMovimiento))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Select Case strTipoEx
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
        GetInventarioSelXtipoExistencia(strTipoEx, estable, almacen, Lista_Libre)
    End Sub

    Public Sub New(anio As Integer, mes As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.SelectedValue = String.Format("{0:00}", mes)
        txtAnio.Value = New Date(anio, DiaLaboral.Month, 1)
        FormatoGridAvanzado(dgvCostoVenta, True, False)
        GetCostoVenta(anio, mes)
        txtAnio.Visible = True
    End Sub

#End Region

#Region "Métodos"
    Private Sub GetInventarioSelXtipoExistencia(strTipoEx As String, estable As Integer, almacen As Integer, listaInventario As List(Of InventarioMovimiento))
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

        For Each i In listaInventario.Where(Function(o) o.tipoProducto = strTipoEx And o.idEstablecimiento = estable And o.idAlmacen = almacen).ToList 'invSA.GetSelXtipoExistenciaVenta(New InventarioMovimiento With {.idAlmacen = be2.idAlmacen, .fecha = be2.fecha, .tipoProducto = tipoex})

            Select Case i.tipoOperacion
                Case StatusTipoOperacion.VENTA
                    venta = ventaSA.GetUbicar_documentoventaAbarrotesPorID(i.idDocumento)

                    If Not IsNothing(venta) Then
                        entidad = entidadSA.UbicarEntidadPorID(venta.idCliente).FirstOrDefault


                        If Not IsNothing(entidad) Then
                            dt.Rows.Add(i.idDocumento, venta.tipoDocumento, venta.fechaDoc,
                                   CInt(venta.serie) & "-" & CInt(venta.numeroDoc), entidad.nombreCompleto,
                                    venta.moneda,
                                    i.monto, i.montoUSD)
                        Else
                            dt.Rows.Add(i.idDocumento, venta.tipoDocumento, venta.fechaDoc,
                                    CInt(venta.serie) & "-" & CInt(venta.numeroDoc), "-",
                                    venta.moneda,
                                    i.monto, i.montoUSD)
                        End If
                    End If
                Case StatusTipoOperacion.NC_DEVOLUCION_DE_EXISTENCIAS
                    compra = compraSA.UbicarDocumentoCompra(i.idDocumento)
                    entidad = entidadSA.UbicarEntidadPorID(compra.idProveedor).FirstOrDefault

                    If Not IsNothing(compra) Then
                        dt.Rows.Add(i.idDocumento, compra.tipoDoc, compra.fechaDoc,
                              compra.serie & "-" & CInt(compra.numeroDoc), entidad.nombreCompleto,
                             compra.monedaDoc,
                             i.monto, i.montoUSD)
                    End If

            End Select



        Next
        'GridGroupingControl1.DataSource = dt
    End Sub

    Sub CargarCostoVenta(lista As List(Of InventarioMovimiento))
        Dim dt As New DataTable
        Dim listaTipoExistencia As New List(Of String)
        listaTipoExistencia.Add(TipoExistencia.Mercaderia)
        listaTipoExistencia.Add(TipoExistencia.ProductoTerminado)
        listaTipoExistencia.Add(TipoExistencia.SubProductosDesechos)

        Dim condicion As New List(Of String)
        condicion.Add(StatusTipoOperacion.VENTA)
        condicion.Add(StatusTipoOperacion.NC_DEVOLUCION_DE_EXISTENCIAS)
        Dim consulta = (From n In lista
                        Where condicion.Contains(n.tipoOperacion) _
                        And listaTipoExistencia.Contains(n.tipoExistencia)).ToList
        'Group n By n.NombreAlmacen,
        '                n.idAlmacen, n.tipoExistencia,
        '                n.tipoOperacion Into g = Group
        '                Select
        '                NombreAlmacen,
        '                idAlmacen,
        '                tipoExistencia,
        '                tipoOperacion,
        '                monto = CType(g.Sum(Function(p) p.monto), Decimal?)).ToList


        dt.Columns.Add("idDocumento")
        dt.Columns.Add("tipoOperacion")
        dt.Columns.Add("idAlmacen")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("unidad")
        dt.Columns.Add("monto")
        dt.Columns.Add("costoventa")
        dt.Columns.Add("rentabilidad")
        For Each i In consulta
            dt.Rows.Add(i.idDocumentoRef,
                        i.tipoOperacion,
                        i.idAlmacen,
                        i.idItem,
                        i.descripcion,
                        i.tipoExistencia,
                        i.unidad,
                        i.monto,
                        i.ValorDeVenta.GetValueOrDefault,
                        (i.ValorDeVenta.GetValueOrDefault - i.monto))
        Next

        dgvCostoVenta.DataSource = dt
    End Sub

    Private Sub GetCostoVenta(anio As Integer, mes As Integer)
        Dim NuevaListaInventario As New List(Of InventarioMovimiento)
        Dim cierreSA As New CierreInventarioSA
        Dim cierre As New cierreinventario
        Dim listaCierre As New List(Of cierreinventario)
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim almacenSA As New almacenSA
        '-----------------------------------------------------------------------------------------------------
        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m

        Dim almacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        '    ListaCurar = New List(Of totalesAlmacen)

        NuevaListaInventario = New List(Of InventarioMovimiento)
        Dim costoSalida As Decimal = 0
        For Each al In almacenes

            listaInventario = inventario.GetMovimientosKardexByMes(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(anio, mes, 1)}, Nothing)

            ImporteSaldo = 0
            canSaldo = 0
            For Each i As InventarioMovimiento In listaInventario
                costoSalida = 0
                cantidadDeficit = 0
                importeDeficit = 0

                Select Case i.tipoRegistro
                    Case "E", "EA", "EC"
                        If producto = i.idItem Then
                            productoCache = i.nombreItem
                            canSaldo += CDec(i.cantidad)
                            ImporteSaldo += CDec(i.monto)
                        Else
                            cantidadDeficit = canSaldo
                            importeDeficit = ImporteSaldo

                            canSaldo = 0
                            ImporteSaldo = 0

                            'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                            canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                            ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
                            canSaldo = CDec(i.cantidad) + canSaldo
                            ImporteSaldo = CDec(i.monto) + ImporteSaldo

                        End If
                        If canSaldo > 0 Then
                            precUnit = ImporteSaldo / canSaldo
                        Else
                            precUnit = 0
                        End If
                        pmAcumnulado = precUnit
                    Case "S", "D"
                        Dim co As Decimal = 0
                        co = CDec(i.cantidad) * pmAcumnulado

                        If producto = i.idItem Then
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

                                    costoSalida = i.monto * -1

                                Case StatusTipoOperacion.REVERSIONES
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo += i.monto

                                Case Else
                                    canSaldo += CDec(i.cantidad)
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

                            canSaldo += CDec(i.cantidad)
                            ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                        End If

                        If canSaldo > 0 Then
                            precUnit = ImporteSaldo / canSaldo
                        Else
                            precUnit = 0
                        End If

                        pmAcumnulado = precUnit
                End Select

                producto = i.idItem
                productoCache = i.nombreItem

                NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                         .idDocumentoRef = i.idDocumento,
                                         .tipoOperacion = i.tipoOperacion,
                                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                         .idAlmacen = i.idAlmacen,
                                         .idItem = i.idItem,
                                         .descripcion = i.nombreItem,
                                         .tipoExistencia = i.tipoProducto,
                                         .unidad = i.unidad,
                                         .CantSaldo = canSaldo,
                                         .saldoMonto = ImporteSaldo,
                                         .monto = costoSalida,
                                         .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault})
            Next
        Next
        CargarCostoVenta(NuevaListaInventario)
    End Sub

#End Region

#Region "Events"
    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        LoadingAnimator.Wire(dgvCostoVenta.TableControl)
        GetCostoVenta(txtAnio.Value.Year, Integer.Parse(cboMesCompra.SelectedValue))
        LoadingAnimator.UnWire(dgvCostoVenta.TableControl)
    End Sub

    Private Sub ToggleButton21_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            dgvCostoVenta.TopLevelGroupOptions.ShowFilterBar = True
            dgvCostoVenta.NestedTableGroupOptions.ShowFilterBar = True
            dgvCostoVenta.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvCostoVenta.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvCostoVenta.OptimizeFilterPerformance = True
            dgvCostoVenta.ShowNavigationBar = True
            filter.WireGrid(dgvCostoVenta)
        Else
            filter.ClearFilters(dgvCostoVenta)
            dgvCostoVenta.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub
#End Region

End Class
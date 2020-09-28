Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class UCCierresDelPeriodo

#Region "Attributes"
    Public Property cierreMensualSA As New WCFService.ServiceAccess.empresaCierreMensualSA
    Public Property empresaAnioSA As New WCFService.ServiceAccess.empresaPeriodoSA
    Public Property CierreContableSA As New CierreContableSA
    Public Property movimientosSA As New MovimientoSA
    Public Property planContableSA As New cuentaplanContableEmpresaSA
    Public Property docCajaSA As New DocumentoCajaSA
    Public Property cierreCajaSA As New CierreCajaSA
    Public Property TotalesAlmacenSA As New TotalesAlmacenSA
    Public Property cierreSA As New CierreInventarioSA
    Public Property cierre As New cierreinventario
    Public Property lista As List(Of cierreinventario)
    Public Property listaCaja As List(Of cierreCaja)
    Public Property obj As cierreCaja
    Public Property cierreContable As cierrecontable
    Public Property listaContable As List(Of cierrecontable)
    'Dim objPleaseWait As New FeedbackForm()
    'Dim ListaCurar As List(Of totalesAlmacen)
    Dim ListaCurarNueva As List(Of totalesAlmacen)

    Dim fechaSeleccionadaCierre As DateTime
    Public Property VerificaCierre As String

    Dim empresaPeriodoBE As New empresaPeriodo
#End Region

    Sub New(VerificaCierrex As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Add any initialization after the InitializeComponent() call.
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "GASTOS", Me.Text, GEstableciento.IdEstablecimiento)
        bg.WorkerSupportsCancellation = True
        GetCierres()

        empresaPeriodoBE.idEmpresa = Gempresas.IdEmpresaRuc
        empresaPeriodoBE.idCentroCosto = GEstableciento.IdEstablecimiento

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(empresaPeriodoBE)
        cboAnio.SelectedValue = AnioGeneral

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = MesGeneral



        VerificaCierre = VerificaCierrex
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "GASTOS", Me.Text, GEstableciento.IdEstablecimiento)
        bg.WorkerSupportsCancellation = True
        ' Add any initialization after the InitializeComponent() call.
        GetCierres()


        empresaPeriodoBE.idEmpresa = Gempresas.IdEmpresaRuc
        empresaPeriodoBE.idCentroCosto = GEstableciento.IdEstablecimiento

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(empresaPeriodoBE)
        cboAnio.SelectedValue = AnioGeneral

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = MesGeneral
    End Sub


#Region "Methods"

    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, IdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, IdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial

    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen

    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)

    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre

    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        'lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"

    '        MessageBox.Show("Este módulo no contiene una configuración disponible, intentelo más tarde.!")

    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            'Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (usuario.IDRol > 0) Then
                Dim RecuperacionNumeracion = numeracionSA.NumeracionBoletasSelV2(GEstableciento.IdEstablecimiento, "GASTOS", "", usuario.IDRol)
                If (Not IsNothing(RecuperacionNumeracion)) Then
                    GConfiguracion = New GConfiguracionModulo
                    GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                    GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                Else
                    Throw New Exception("Verificar configuración")
                End If
            Else
                Throw New Exception("Verificar datos")
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminarCierre(n As ListViewItem)

        Dim periodoSuperior = New Date(CInt(n.SubItems(0).Text), CInt(n.SubItems(1).Text), 1)
        periodoSuperior = periodoSuperior.AddMonths(1)

        Dim existeCierreSuperior = cierreMensualSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                                    .anio = periodoSuperior.Year,
                                                                                                   .mes = periodoSuperior.Month,
                                                                                                   .idCentroCosto = GEstableciento.IdEstablecimiento})

        If existeCierreSuperior = True Then
            MessageBox.Show("Debe eliminar primero el cierre del período: " & periodoSuperior.Month & "/" & periodoSuperior.Year, "Validar cierre", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Cursor = Cursors.Default
            Exit Sub
        End If

        cierreMensualSA.EliminarCierre(New Business.Entity.empresaCierreMensual With {
                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                .anio = Integer.Parse(n.SubItems(0).Text),
                                .mes = Integer.Parse(n.SubItems(1).Text)})

        ListView1.SelectedItems(0).Remove()
    End Sub

    Private Sub GetCierres()
        ListView1.Items.Clear()
        For Each i In cierreMensualSA.GetCierresByEmpresa(New Business.Entity.empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
            Dim n As New ListViewItem(i.anio)
            n.SubItems.Add(i.mes)
            n.SubItems.Add(MonthName(i.mes, False))
            ListView1.Items.Add(n)
        Next
    End Sub



    Function GetCierreCostoVenta(anio As Integer, mes As Integer) As List(Of cierreCostoVenta)
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
        Dim ListacierreCosto As New List(Of cierreCostoVenta)
        '-----------------------------------------------------------------------------------------------------
        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        'PRUEBA
        Dim ListaPmVenta As New List(Of InventarioMovimiento)
        Dim pmVenta As InventarioMovimiento
        'fin prueba


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

                        'prueba
                        If i.tipoOperacion = "9913" Then

                            If ListaPmVenta.Count > 0 Then
                                Dim consulta = (From j In ListaPmVenta
                                                Where j.nrolote = i.customLote.codigoLote And
                                                j.idDocumento = i.idDocumentoRef).FirstOrDefault

                                i.monto = CDec(i.cantidad) * consulta.precUnite.GetValueOrDefault

                            End If
                        End If
                        'end prueba

                        If producto = i.idItem Then
                            If i.tipoOperacion = 9916 Then
                                productoCache = i.nombreItem
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += CDec(i.monto)
                                costoSalida = CDec(i.monto)
                            Else
                                productoCache = i.nombreItem
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += CDec(i.monto)
                            End If


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
                                Case "9943"

                                    canSaldo = canSaldo
                                    ImporteSaldo += i.monto

                                Case "9940"
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo = ImporteSaldo

                                Case "9914"
                                    canSaldo = canSaldo
                                    ImporteSaldo += i.monto

                                Case "9941"
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo += co' i.monto

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

                        If i.tipoOperacion = "01" Then
                            pmVenta = New InventarioMovimiento
                            pmVenta.idDocumento = i.idDocumento
                            pmVenta.nrolote = i.customLote.codigoLote
                            If precUnit > 0 Then
                                pmVenta.precUnite = precUnit
                            ElseIf precUnit = 0 Then

                                pmVenta.precUnite = (co) / (i.cantidad)
                            End If

                            ListaPmVenta.Add(pmVenta)
                        End If
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
        ListacierreCosto = MontoCierreCostoVenta(NuevaListaInventario)



        'asiento cierrre costo ventas
        Dim asiento As asiento
        Dim nMovmiento As movimiento
        For Each c In ListacierreCosto
            Select Case c.tipoExistencia
                Case TipoExistencia.Mercaderia
                    If c.importe > 0 Then
                        asiento = New asiento
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc
                        asiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        asiento.idEntidad = 0
                        asiento.nombreEntidad = "SIN IDENTIDAD"
                        asiento.tipoEntidad = "OT"
                        asiento.fechaProceso = fechaSeleccionadaCierre
                        asiento.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year
                        asiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                        asiento.tipo = "D"
                        asiento.tipoAsiento = ASIENTO_CONTABLE.CostoVenta
                        asiento.importeMN = c.importe.GetValueOrDefault
                        asiento.importeME = 0
                        asiento.glosa = "Costo de ventas mercadería"
                        asiento.usuarioActualizacion = usuario.IDUsuario
                        asiento.fechaActualizacion = Date.Now
                        listaAsientosCostoVenta.Add(asiento)

                        nMovmiento = New movimiento
                        nMovmiento.cuenta = "691"
                        nMovmiento.descripcion = "Costo de ventas Mercaderia"
                        nMovmiento.tipo = "D"
                        nMovmiento.monto = c.importe.GetValueOrDefault
                        nMovmiento.montoUSD = 0
                        nMovmiento.usuarioActualizacion = usuario.IDUsuario
                        nMovmiento.fechaActualizacion = Date.Now
                        asiento.movimiento.Add(nMovmiento)

                        nMovmiento = New movimiento
                        nMovmiento.cuenta = "20111"
                        nMovmiento.descripcion = "Costo de ventas Mercaderia"
                        nMovmiento.tipo = "H"
                        nMovmiento.monto = c.importe.GetValueOrDefault
                        nMovmiento.montoUSD = 0
                        nMovmiento.usuarioActualizacion = usuario.IDUsuario
                        nMovmiento.fechaActualizacion = Date.Now
                        asiento.movimiento.Add(nMovmiento)
                    End If
                Case TipoExistencia.ProductoTerminado
                    If c.importe > 0 Then
                        asiento = New asiento
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc
                        asiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        asiento.idEntidad = 0
                        asiento.nombreEntidad = "SIN IDENTIDAD"
                        asiento.tipoEntidad = "OT"
                        asiento.fechaProceso = fechaSeleccionadaCierre
                        asiento.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year
                        asiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                        asiento.tipo = "D"
                        asiento.tipoAsiento = ASIENTO_CONTABLE.CostoVenta
                        asiento.importeMN = c.importe.GetValueOrDefault
                        asiento.importeME = 0
                        asiento.glosa = "Costo de ventas ProductoTerminado"
                        asiento.usuarioActualizacion = usuario.IDUsuario
                        asiento.fechaActualizacion = Date.Now
                        listaAsientosCostoVenta.Add(asiento)

                        nMovmiento = New movimiento
                        nMovmiento.cuenta = "692"
                        nMovmiento.descripcion = "Costo de ventas ProductoTerminado"
                        nMovmiento.tipo = "D"
                        nMovmiento.monto = c.importe.GetValueOrDefault
                        nMovmiento.montoUSD = 0
                        nMovmiento.usuarioActualizacion = usuario.IDUsuario
                        nMovmiento.fechaActualizacion = Date.Now
                        asiento.movimiento.Add(nMovmiento)

                        nMovmiento = New movimiento
                        nMovmiento.cuenta = "211"
                        nMovmiento.descripcion = "Costo de ventas ProductoTerminado"
                        nMovmiento.tipo = "H"
                        nMovmiento.monto = c.importe.GetValueOrDefault
                        nMovmiento.montoUSD = 0
                        nMovmiento.usuarioActualizacion = usuario.IDUsuario
                        nMovmiento.fechaActualizacion = Date.Now
                        asiento.movimiento.Add(nMovmiento)
                    End If
                Case TipoExistencia.SubProductosDesechos
                    If c.importe > 0 Then
                        asiento = New asiento
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc
                        asiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        asiento.idEntidad = 0
                        asiento.nombreEntidad = "SIN IDENTIDAD"
                        asiento.tipoEntidad = "OT"
                        asiento.fechaProceso = fechaSeleccionadaCierre
                        asiento.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year
                        asiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                        asiento.tipo = "D"
                        asiento.tipoAsiento = ASIENTO_CONTABLE.CostoVenta
                        asiento.importeMN = c.importe.GetValueOrDefault
                        asiento.importeME = 0
                        asiento.glosa = "Costo de ventas SubProductosDesechos"
                        asiento.usuarioActualizacion = usuario.IDUsuario
                        asiento.fechaActualizacion = Date.Now
                        listaAsientosCostoVenta.Add(asiento)

                        nMovmiento = New movimiento
                        nMovmiento.cuenta = "693"
                        nMovmiento.descripcion = "Costo de ventas SubProductosDesechos"
                        nMovmiento.tipo = "D"
                        nMovmiento.monto = c.importe.GetValueOrDefault
                        nMovmiento.montoUSD = 0
                        nMovmiento.usuarioActualizacion = usuario.IDUsuario
                        nMovmiento.fechaActualizacion = Date.Now
                        asiento.movimiento.Add(nMovmiento)

                        nMovmiento = New movimiento
                        nMovmiento.cuenta = "221"
                        nMovmiento.descripcion = "Costo de ventas SubProductosDesechos"
                        nMovmiento.tipo = "H"
                        nMovmiento.monto = c.importe.GetValueOrDefault
                        nMovmiento.montoUSD = 0
                        nMovmiento.usuarioActualizacion = usuario.IDUsuario
                        nMovmiento.fechaActualizacion = Date.Now
                        asiento.movimiento.Add(nMovmiento)
                    End If
            End Select

        Next



        Return ListacierreCosto
    End Function




    Function MontoCierreCostoVenta(lista As List(Of InventarioMovimiento)) As List(Of cierreCostoVenta)
        Dim documentoSA As New DocumentoSA
        Dim cierreCostoVenta As New cierreCostoVenta
        Dim ListacierreCosto As New List(Of cierreCostoVenta)
        Dim listaTipoExistencia As New List(Of String)
        listaTipoExistencia.Add(TipoExistencia.Mercaderia)
        listaTipoExistencia.Add(TipoExistencia.ProductoTerminado)
        listaTipoExistencia.Add(TipoExistencia.SubProductosDesechos)

        Dim TotalMercaderia As Decimal = CDec(0.0)
        Dim TotalProductoTerminado As Decimal = CDec(0.0)
        Dim TotalSubProductosTerminados As Decimal = CDec(0.0)


        Dim condicion As New List(Of String)
        condicion.Add(StatusTipoOperacion.VENTA)
        condicion.Add(StatusTipoOperacion.NC_DEVOLUCION_DE_EXISTENCIAS)
        Dim consulta = (From n In lista
                        Where condicion.Contains(n.tipoOperacion) _
                        And listaTipoExistencia.Contains(n.tipoExistencia)).ToList


        For Each i In consulta
            If i.tipoOperacion = "9916" Then
                Dim documentoOperacion = documentoSA.UbicarDocumento(i.idDocumentoRef)
                Select Case documentoOperacion.tipoOperacion
                    Case StatusTipoOperacion.COMPRA

                    Case StatusTipoOperacion.VENTA

                        If i.tipoExistencia = TipoExistencia.Mercaderia Then
                            TotalMercaderia -= i.monto
                        ElseIf i.tipoExistencia = TipoExistencia.ProductoTerminado Then
                            TotalProductoTerminado -= i.monto
                        ElseIf i.tipoExistencia = TipoExistencia.SubProductosDesechos Then
                            TotalSubProductosTerminados -= i.monto
                        End If
                End Select
            Else

                If i.tipoExistencia = TipoExistencia.Mercaderia Then
                    TotalMercaderia += i.monto
                ElseIf i.tipoExistencia = TipoExistencia.ProductoTerminado Then
                    TotalProductoTerminado += i.monto
                ElseIf i.tipoExistencia = TipoExistencia.SubProductosDesechos Then
                    TotalSubProductosTerminados += i.monto
                End If
            End If

        Next


        cierreCostoVenta = New cierreCostoVenta
        cierreCostoVenta.tipoExistencia = TipoExistencia.Mercaderia
        cierreCostoVenta.importe = TotalMercaderia
        ListacierreCosto.Add(cierreCostoVenta)


        cierreCostoVenta = New cierreCostoVenta
        cierreCostoVenta.tipoExistencia = TipoExistencia.ProductoTerminado
        cierreCostoVenta.importe = TotalProductoTerminado
        ListacierreCosto.Add(cierreCostoVenta)

        cierreCostoVenta = New cierreCostoVenta
        cierreCostoVenta.tipoExistencia = TipoExistencia.SubProductosDesechos
        cierreCostoVenta.importe = TotalSubProductosTerminados
        ListacierreCosto.Add(cierreCostoVenta)

        Return ListacierreCosto

    End Function





    Function CargarCostoVenta(lista As List(Of InventarioMovimiento)) As List(Of cierreCostoVenta)
        Dim listaTipoExistencia As New List(Of String)
        listaTipoExistencia.Add(TipoExistencia.Mercaderia)
        listaTipoExistencia.Add(TipoExistencia.ProductoTerminado)
        listaTipoExistencia.Add(TipoExistencia.SubProductosDesechos)

        Dim condicion As New List(Of String)
        condicion.Add(StatusTipoOperacion.VENTA)
        condicion.Add(StatusTipoOperacion.NC_DEVOLUCION_DE_EXISTENCIAS)
        Dim consulta = (From n In lista
                        Where condicion.Contains(n.tipoOperacion) _
                        And listaTipoExistencia.Contains(n.tipoExistencia)
                        Group n By n.NombreAlmacen,
                        n.idAlmacen, n.tipoExistencia,
                        n.tipoOperacion Into g = Group
                        Select
                        NombreAlmacen,
                        idAlmacen,
                        tipoExistencia,
                        tipoOperacion,
                        monto = CType(g.Sum(Function(p) p.monto), Decimal?)).ToList

        CargarCostoVenta = New List(Of cierreCostoVenta)
        listaAsientosCostoVenta = New List(Of asiento)
        'generando asiento del costo de ventas
        Dim asiento As asiento
        Dim nMovmiento As movimiento
        For Each c In consulta
            Select Case c.tipoExistencia
                Case TipoExistencia.Mercaderia
                    asiento = New asiento
                    asiento.idEmpresa = Gempresas.IdEmpresaRuc
                    asiento.idCentroCostos = GEstableciento.IdEstablecimiento
                    asiento.idEntidad = 0
                    asiento.nombreEntidad = "SIN IDENTIDAD"
                    asiento.tipoEntidad = "OT"
                    asiento.fechaProceso = fechaSeleccionadaCierre
                    asiento.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year
                    asiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                    asiento.tipo = "D"
                    asiento.tipoAsiento = ASIENTO_CONTABLE.CostoVenta
                    asiento.importeMN = c.monto.GetValueOrDefault
                    asiento.importeME = 0
                    asiento.glosa = "Costo de ventas mercadería"
                    asiento.usuarioActualizacion = usuario.IDUsuario
                    asiento.fechaActualizacion = Date.Now
                    listaAsientosCostoVenta.Add(asiento)

                    nMovmiento = New movimiento
                    nMovmiento.cuenta = "69111"
                    nMovmiento.descripcion = "Costo de ventas Mercaderia"
                    nMovmiento.tipo = "D"
                    nMovmiento.monto = c.monto.GetValueOrDefault
                    nMovmiento.montoUSD = 0
                    nMovmiento.usuarioActualizacion = usuario.IDUsuario
                    nMovmiento.fechaActualizacion = Date.Now
                    asiento.movimiento.Add(nMovmiento)

                    nMovmiento = New movimiento
                    nMovmiento.cuenta = "20111"
                    nMovmiento.descripcion = "Costo de ventas Mercaderia"
                    nMovmiento.tipo = "H"
                    nMovmiento.monto = c.monto.GetValueOrDefault
                    nMovmiento.montoUSD = 0
                    nMovmiento.usuarioActualizacion = usuario.IDUsuario
                    nMovmiento.fechaActualizacion = Date.Now
                    asiento.movimiento.Add(nMovmiento)

                Case TipoExistencia.ProductoTerminado

                    asiento = New asiento
                    asiento.idEmpresa = Gempresas.IdEmpresaRuc
                    asiento.idCentroCostos = GEstableciento.IdEstablecimiento
                    asiento.idEntidad = 0
                    asiento.nombreEntidad = "SIN IDENTIDAD"
                    asiento.tipoEntidad = "OT"
                    asiento.fechaProceso = fechaSeleccionadaCierre
                    asiento.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year
                    asiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                    asiento.tipo = "D"
                    asiento.tipoAsiento = ASIENTO_CONTABLE.CostoVenta
                    asiento.importeMN = c.monto.GetValueOrDefault
                    asiento.importeME = 0
                    asiento.glosa = "Costo de ventas ProductoTerminado"
                    asiento.usuarioActualizacion = usuario.IDUsuario
                    asiento.fechaActualizacion = Date.Now
                    listaAsientosCostoVenta.Add(asiento)

                    nMovmiento = New movimiento
                    nMovmiento.cuenta = "69211"
                    nMovmiento.descripcion = "Costo de ventas ProductoTerminado"
                    nMovmiento.tipo = "D"
                    nMovmiento.monto = c.monto.GetValueOrDefault
                    nMovmiento.montoUSD = 0
                    nMovmiento.usuarioActualizacion = usuario.IDUsuario
                    nMovmiento.fechaActualizacion = Date.Now
                    asiento.movimiento.Add(nMovmiento)

                    nMovmiento = New movimiento
                    nMovmiento.cuenta = "211"
                    nMovmiento.descripcion = "Costo de ventas ProductoTerminado"
                    nMovmiento.tipo = "H"
                    nMovmiento.monto = c.monto.GetValueOrDefault
                    nMovmiento.montoUSD = 0
                    nMovmiento.usuarioActualizacion = usuario.IDUsuario
                    nMovmiento.fechaActualizacion = Date.Now
                    asiento.movimiento.Add(nMovmiento)

                Case TipoExistencia.SubProductosDesechos

                    asiento = New asiento
                    asiento.idEmpresa = Gempresas.IdEmpresaRuc
                    asiento.idCentroCostos = GEstableciento.IdEstablecimiento
                    asiento.idEntidad = 0
                    asiento.nombreEntidad = "SIN IDENTIDAD"
                    asiento.tipoEntidad = "OT"
                    asiento.fechaProceso = fechaSeleccionadaCierre
                    asiento.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year
                    asiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                    asiento.tipo = "D"
                    asiento.tipoAsiento = ASIENTO_CONTABLE.CostoVenta
                    asiento.importeMN = c.monto.GetValueOrDefault
                    asiento.importeME = 0
                    asiento.glosa = "Costo de ventas SubProductosDesechos"
                    asiento.usuarioActualizacion = usuario.IDUsuario
                    asiento.fechaActualizacion = Date.Now
                    listaAsientosCostoVenta.Add(asiento)

                    nMovmiento = New movimiento
                    nMovmiento.cuenta = "69311"
                    nMovmiento.descripcion = "Costo de ventas SubProductosDesechos"
                    nMovmiento.tipo = "D"
                    nMovmiento.monto = c.monto.GetValueOrDefault
                    nMovmiento.montoUSD = 0
                    nMovmiento.usuarioActualizacion = usuario.IDUsuario
                    nMovmiento.fechaActualizacion = Date.Now
                    asiento.movimiento.Add(nMovmiento)

                    nMovmiento = New movimiento
                    nMovmiento.cuenta = "221"
                    nMovmiento.descripcion = "Costo de ventas SubProductosDesechos"
                    nMovmiento.tipo = "H"
                    nMovmiento.monto = c.monto.GetValueOrDefault
                    nMovmiento.montoUSD = 0
                    nMovmiento.usuarioActualizacion = usuario.IDUsuario
                    nMovmiento.fechaActualizacion = Date.Now
                    asiento.movimiento.Add(nMovmiento)
            End Select

        Next


        For Each i In consulta
            CargarCostoVenta.Add(New cierreCostoVenta With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                            .idCentroCosto = i.idAlmacen,
                                                            .periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & fechaSeleccionadaCierre.Year,
                                                            .tipoExistencia = i.tipoExistencia,
                                                            .tipoOperacion = i.tipoOperacion,
                                                            .anio = fechaSeleccionadaCierre.Year,
                                                            .mes = fechaSeleccionadaCierre.Month,
                                                            .dia = fechaSeleccionadaCierre.Day,
                                                            .importe = i.monto.GetValueOrDefault,
                                                            .importeUS = 0,
                                                            .usuarioModificacion = usuario.IDUsuario,
                                                            .fechaModificacion = Date.Now})
        Next

        Return CargarCostoVenta
    End Function


    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0
    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0
    Dim listaAsientosCostoVenta As New List(Of asiento)

    Private Function GetCierreInventario() As documento
        Dim NuevaListaInventario As New List(Of InventarioMovimiento)
        Dim ndocumento As documento
        Dim cierreSA As New CierreInventarioSA
        Dim cierre As New cierreinventario
        Dim cierreResultados As New cierreResultados
        Dim listaCierre As New List(Of cierreinventario)
        Dim listaCierreResultados As New List(Of cierreResultados)
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim codigoLotex As Integer = 0
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim almacenSA As New almacenSA
        Dim ListaCostoVenta As New List(Of cierreCostoVenta)
        Dim CierreCostoVenta As New cierreCostoVenta
        Dim listaCierreCostoVenta As New List(Of cierreCostoVenta)
        Dim listaEntregables As New List(Of recursoCostoDetalle)
        Dim CierreEntregables As New cierreEntregables
        Dim ListaEntregablesCierre As New List(Of cierreEntregables)
        '-----------------------------------------------------------------------------------------------------
        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        '''
        'PRUEBA
        Dim ListaPmVenta As New List(Of InventarioMovimiento)
        Dim pmVenta As InventarioMovimiento
        'fin prueba

        Dim almacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        '    ListaCurar = New List(Of totalesAlmacen)
        'fdssdfsdf
        NuevaListaInventario = New List(Of InventarioMovimiento)
        Dim costoSalida As Decimal = 0
        For Each al In almacenes

            listaInventario = inventario.GetMovimientosKardexByMes(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(fechaSeleccionadaCierre.Year, fechaSeleccionadaCierre.Month, 1)}, Nothing)

            ImporteSaldo = 0
            canSaldo = 0
            For Each i As InventarioMovimiento In listaInventario
                costoSalida = 0
                cantidadDeficit = 0
                importeDeficit = 0

                Select Case i.tipoRegistro
                    Case "E", "EA", "EC"


                        'prueba
                        If i.tipoOperacion = "9913" Then

                            If ListaPmVenta.Count > 0 Then
                                Dim consulta = (From j In ListaPmVenta
                                                Where j.nrolote = i.customLote.codigoLote And
                                                j.idDocumento = i.idDocumentoRef).FirstOrDefault

                                i.monto = CDec(i.cantidad) * consulta.precUnite.GetValueOrDefault

                            End If
                        End If
                        'end prueba


                        If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
                            'productoCache = i.nombreItem
                            'canSaldo += CDec(i.cantidad)
                            'ImporteSaldo += CDec(i.monto)

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

                        If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
                            productoCache = i.nombreItem
                            'canSaldo += CDec(i.cantidad)

                            Select Case i.tipoOperacion
                                Case "9913"
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo = ImporteSaldo

                                Case "9943"

                                    canSaldo = canSaldo
                                    ImporteSaldo += i.monto

                                Case "9940"
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo = ImporteSaldo

                                Case "9914"
                                    canSaldo = canSaldo
                                    ImporteSaldo += i.monto

                                Case "9941"
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo += co' i.monto

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

                        If i.tipoOperacion = "01" Then
                            pmVenta = New InventarioMovimiento
                            pmVenta.idDocumento = i.idDocumento
                            pmVenta.nrolote = i.customLote.codigoLote
                            If precUnit > 0 Then
                                pmVenta.precUnite = precUnit
                            ElseIf precUnit = 0 Then

                                pmVenta.precUnite = (co) / (i.cantidad)
                            End If

                            ListaPmVenta.Add(pmVenta)
                        End If

                End Select

                producto = i.idItem
                codigoLotex = i.customLote.codigoLote
                productoCache = i.nombreItem

                NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                         .nrolote = i.customLote.codigoLote,
                                         .tipoOperacion = i.tipoOperacion,
                                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                         .idAlmacen = i.idAlmacen,
                                         .idItem = i.idItem,
                                         .descripcion = i.nombreItem,
                                         .tipoExistencia = i.tipoProducto,
                                         .unidad = i.unidad,
                                         .CantSaldo = canSaldo,
                                         .saldoMonto = ImporteSaldo,
                                         .monto = costoSalida})
            Next
        Next

        'listaAsientosCostoVenta = New List(Of asiento)
        'Dim listaCostVenta = CargarCostoVenta(NuevaListaInventario)

        Dim listaAGuardar = (From n In NuevaListaInventario
                             Select n.idItem, n.idAlmacen, n.nrolote
                             Order By idItem).Distinct.ToList()

        'asignando cierre de inventario
        '----------------------------------------------------------------------------------




        ndocumento = New documento
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        'ndocumento.tipoDoc = "9901"
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.nroDoc = GConfiguracion.ConfigComprobante
        ndocumento.fechaProceso = New DateTime(fechaSeleccionadaCierre.Year, fechaSeleccionadaCierre.Month, fechaSeleccionadaCierre.Day)
        ndocumento.moneda = "1"
        ndocumento.idEntidad = usuario.IDUsuario
        ndocumento.entidad = usuario.CustomUsuario.Full_Name
        ndocumento.tipoEntidad = "US"
        ndocumento.nrodocEntidad = usuario.CustomUsuario.NroDocumento
        ndocumento.tipoOperacion = StatusTipoOperacion.CIERRES
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = Date.Now

        For Each c In listaAGuardar
            Dim obj = NuevaListaInventario.Where(Function(o) o.idItem = c.idItem And o.idAlmacen = c.idAlmacen And o.nrolote = c.nrolote).LastOrDefault

            cierre = New cierreinventario
            cierre.idEmpresa = Gempresas.IdEmpresaRuc
            cierre.codigoLote = c.nrolote
            cierre.idCentroCosto = GEstableciento.IdEstablecimiento
            cierre.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & fechaSeleccionadaCierre.Year
            cierre.idAlmacen = c.idAlmacen
            cierre.idItem = obj.idItem
            cierre.NomItem = obj.descripcion
            cierre.anio = fechaSeleccionadaCierre.Year
            cierre.mes = fechaSeleccionadaCierre.Month
            cierre.dia = DateTime.Now.Day
            cierre.TipoExistencia = obj.tipoExistencia
            cierre.cantidad = obj.CantSaldo
            cierre.importe = obj.saldoMonto
            cierre.importeUS = 0
            cierre.unidad = obj.unidad
            cierre.usuarioModificacion = usuario.IDUsuario
            cierre.fechaModificacion = DateTime.Now
            listaCierre.Add(cierre)

            'cierre = New cierreinventario
            'cierre.idEmpresa = Gempresas.IdEmpresaRuc
            'cierre.idCentroCosto = almacenSA.GetUbicar_almacenPorID(c.idAlmacen).idEstablecimiento
            'cierre.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & fechaSeleccionadaCierre.Year
            'cierre.idAlmacen = c.idAlmacen
            'cierre.idItem = c.idItem
            'cierre.NomItem = c.descripcion
            'cierre.anio = fechaSeleccionadaCierre.Year
            'cierre.mes = fechaSeleccionadaCierre.Month
            'cierre.dia = DateTime.Now.Day
            'cierre.TipoExistencia = c.tipoExistencia
            'cierre.cantidad = c.cantidad
            'cierre.importe = c.importeSoles
            'cierre.importeUS = 0
            'cierre.unidad = "UND"
            'cierre.usuarioModificacion = usuario.IDUsuario
            'cierre.fechaModificacion = DateTime.Now
            'listaCierre.Add(cierre)
        Next

        'cierre de resultados

        cierreResultados = New cierreResultados
        cierreResultados.idEmpresa = Gempresas.IdEmpresaRuc
        cierreResultados.idCentroCosto = GEstableciento.IdEstablecimiento
        cierreResultados.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & fechaSeleccionadaCierre.Year
        cierreResultados.montoImpuesto = txtImpuestoRenta.Value
        cierreResultados.montoImpuestoUSD = txtImpuestoRenta.Value
        cierreResultados.utilidadPerdida = txtUilidad.Value
        cierreResultados.utilidadPerdidaUSD = txtUilidad.Value
        cierreResultados.anio = fechaSeleccionadaCierre.Year
        cierreResultados.mes = fechaSeleccionadaCierre.Month
        cierreResultados.usuarioActualizacion = usuario.IDUsuario
        cierreResultados.fechaActualizacion = DateTime.Now
        listaCierreResultados.Add(cierreResultados)

        '------------------------------------------------------------------------------------------------------------

        'Cierre Costo de Ventas


        ListaCostoVenta = GetCierreCostoVenta(fechaSeleccionadaCierre.Year, fechaSeleccionadaCierre.Month)

        For Each c In ListaCostoVenta

            CierreCostoVenta = New cierreCostoVenta
            CierreCostoVenta.idEmpresa = Gempresas.IdEmpresaRuc
            CierreCostoVenta.idCentroCosto = GEstableciento.IdEstablecimiento
            CierreCostoVenta.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & fechaSeleccionadaCierre.Year
            CierreCostoVenta.anio = fechaSeleccionadaCierre.Year
            CierreCostoVenta.mes = fechaSeleccionadaCierre.Month
            CierreCostoVenta.dia = DateTime.Now.Day
            CierreCostoVenta.tipoExistencia = c.tipoExistencia
            CierreCostoVenta.tipoOperacion = "01"
            CierreCostoVenta.importe = c.importe
            CierreCostoVenta.importeUS = 0
            CierreCostoVenta.usuarioModificacion = usuario.IDUsuario
            CierreCostoVenta.fechaModificacion = DateTime.Now
            listaCierreCostoVenta.Add(CierreCostoVenta)
        Next
        '--------------------------------------------------------------------------------------------------------------
        'cierre de entregables proyexctos


        listaEntregables = GetCierreEntregables(fechaSeleccionadaCierre.Year, fechaSeleccionadaCierre.Month)
        For Each i In listaEntregables

            CierreEntregables = New cierreEntregables
            CierreEntregables.idEmpresa = Gempresas.IdEmpresaRuc
            CierreEntregables.idCentroCosto = GEstableciento.IdEstablecimiento
            CierreEntregables.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & fechaSeleccionadaCierre.Year
            CierreEntregables.anio = fechaSeleccionadaCierre.Year
            CierreEntregables.mes = fechaSeleccionadaCierre.Month
            CierreEntregables.dia = DateTime.Now.Day
            CierreEntregables.tipoOperacion = "01"
            CierreEntregables.importe = i.montoMN
            CierreEntregables.importeUS = 0
            CierreEntregables.usuarioModificacion = usuario.IDUsuario
            CierreEntregables.fechaModificacion = DateTime.Now
            CierreEntregables.idCosto = i.idCosto
            ListaEntregablesCierre.Add(CierreEntregables)


        Next

        '--------------------------------------------------------------------------------------------------------------
        ndocumento.cierreEntregables = ListaEntregablesCierre

        ndocumento.cierreCostoVenta = listaCierreCostoVenta
        ' ndocumento.asiento = listaAsientosCostoVenta
        ndocumento.cierreResultados = listaCierreResultados
        ndocumento.cierreinventario = listaCierre
        'ndocumento.cierreCostoVenta = listaCostVenta
        ndocumento.asiento = listaAsientosCostoVenta.ToList
        Return ndocumento
        '  cierreSA.CerrarByPeriodo(ndocumento)

        '  TotalesSA.GetCurarKardexCaberas(ListaCurar)
        '     MessageBox.Show("Inventario cerrado correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function


    Function GetCierreEntregables(anio As Integer, mes As Integer) As List(Of recursoCostoDetalle)
        Dim recursoSA As New recursoCostoSA
        Dim listaRecurso As New List(Of recursoCostoDetalle)
        Dim fechaPeriodo As DateTime = New DateTime(anio, mes, 1)

        listaRecurso = recursoSA.CierreDeEntregables(fechaPeriodo, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

        Dim asiento As asiento
        Dim nMovmiento As movimiento
        For Each c In listaRecurso

            If c.montoMN > 0 Then
                asiento = New asiento
                asiento.idEmpresa = Gempresas.IdEmpresaRuc
                asiento.idCentroCostos = GEstableciento.IdEstablecimiento
                asiento.idEntidad = 0
                asiento.nombreEntidad = "SIN IDENTIDAD"
                asiento.tipoEntidad = "OT"
                asiento.fechaProceso = fechaSeleccionadaCierre
                asiento.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year
                asiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                asiento.tipo = "D"
                asiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                asiento.importeMN = c.montoMN.GetValueOrDefault
                asiento.importeME = 0
                asiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & c.NombreCosto
                asiento.usuarioActualizacion = usuario.IDUsuario
                asiento.fechaActualizacion = Date.Now
                listaAsientosCostoVenta.Add(asiento)

                nMovmiento = New movimiento
                nMovmiento.cuenta = c.cuenta
                nMovmiento.descripcion = c.NombreCosto
                nMovmiento.tipo = "D"
                nMovmiento.monto = c.montoMN.GetValueOrDefault
                nMovmiento.montoUSD = 0
                nMovmiento.usuarioActualizacion = usuario.IDUsuario
                nMovmiento.fechaActualizacion = Date.Now
                asiento.movimiento.Add(nMovmiento)

                nMovmiento = New movimiento
                nMovmiento.cuenta = "791"
                nMovmiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
                nMovmiento.tipo = "H"
                nMovmiento.monto = c.montoMN.GetValueOrDefault
                nMovmiento.montoUSD = 0
                nMovmiento.usuarioActualizacion = usuario.IDUsuario
                nMovmiento.fechaActualizacion = Date.Now
                asiento.movimiento.Add(nMovmiento)

                ''2
                asiento = New asiento
                asiento.idEmpresa = Gempresas.IdEmpresaRuc
                asiento.idCentroCostos = GEstableciento.IdEstablecimiento
                asiento.idEntidad = 0
                asiento.nombreEntidad = "SIN IDENTIDAD"
                asiento.tipoEntidad = "OT"
                asiento.fechaProceso = fechaSeleccionadaCierre
                asiento.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year
                asiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                asiento.tipo = "D"
                asiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                asiento.importeMN = c.montoMN.GetValueOrDefault
                asiento.importeME = 0
                asiento.glosa = "Por determinacion del costo de producto terminado" & " " & c.NombreCosto
                asiento.usuarioActualizacion = usuario.IDUsuario
                asiento.fechaActualizacion = Date.Now
                listaAsientosCostoVenta.Add(asiento)

                nMovmiento = New movimiento
                nMovmiento.cuenta = "211"
                nMovmiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                nMovmiento.tipo = "D"
                nMovmiento.monto = c.montoMN.GetValueOrDefault
                nMovmiento.montoUSD = 0
                nMovmiento.usuarioActualizacion = usuario.IDUsuario
                nMovmiento.fechaActualizacion = Date.Now
                asiento.movimiento.Add(nMovmiento)

                nMovmiento = New movimiento
                nMovmiento.cuenta = "711"
                nMovmiento.descripcion = "VARIACI?N DE PRODUCTOS TERMINADOS"
                nMovmiento.tipo = "H"
                nMovmiento.monto = c.montoMN.GetValueOrDefault
                nMovmiento.montoUSD = 0
                nMovmiento.usuarioActualizacion = usuario.IDUsuario
                nMovmiento.fechaActualizacion = Date.Now
                asiento.movimiento.Add(nMovmiento)

                ''3
                asiento = New asiento
                asiento.idEmpresa = Gempresas.IdEmpresaRuc
                asiento.idCentroCostos = GEstableciento.IdEstablecimiento
                asiento.idEntidad = 0
                asiento.nombreEntidad = "SIN IDENTIDAD"
                asiento.tipoEntidad = "OT"
                asiento.fechaProceso = fechaSeleccionadaCierre
                asiento.periodo = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year
                asiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                asiento.tipo = "D"
                asiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                asiento.importeMN = c.montoMN.GetValueOrDefault
                asiento.importeME = 0
                asiento.glosa = "Por determinacion del costo de venta por valoración" & " " & c.NombreCosto
                asiento.usuarioActualizacion = usuario.IDUsuario
                asiento.fechaActualizacion = Date.Now
                listaAsientosCostoVenta.Add(asiento)

                nMovmiento = New movimiento
                nMovmiento.cuenta = "694"
                nMovmiento.descripcion = "SERVICIOS"
                nMovmiento.tipo = "D"
                nMovmiento.monto = c.montoMN.GetValueOrDefault
                nMovmiento.montoUSD = 0
                nMovmiento.usuarioActualizacion = usuario.IDUsuario
                nMovmiento.fechaActualizacion = Date.Now
                asiento.movimiento.Add(nMovmiento)

                nMovmiento = New movimiento
                nMovmiento.cuenta = "211"
                nMovmiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                nMovmiento.tipo = "H"
                nMovmiento.monto = c.montoMN.GetValueOrDefault
                nMovmiento.montoUSD = 0
                nMovmiento.usuarioActualizacion = usuario.IDUsuario
                nMovmiento.fechaActualizacion = Date.Now
                asiento.movimiento.Add(nMovmiento)

            End If
        Next

        Return listaRecurso

    End Function


    Private Function GetCierreInventarioNuevo2() As List(Of totalesAlmacen)
        Dim NuevaListaInventario As New List(Of InventarioMovimiento)
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim codigoLotex As Integer = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim almacenSA As New almacenSA
        '-----------------------------------------------------------------------------------------------------
        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        Dim fechaNueva = (fechaSeleccionadaCierre).AddMonths(1)
        Dim almacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        '    ListaCurar = New List(Of totalesAlmacen)

        GetCierreInventarioNuevo2 = New List(Of totalesAlmacen)
        NuevaListaInventario = New List(Of InventarioMovimiento)
        For Each al In almacenes

            listaInventario = inventario.GetMovimientosKardexByMes(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(fechaNueva.Year, fechaNueva.Month, 1)}, Nothing)

            ImporteSaldo = 0
            canSaldo = 0
            For Each i As InventarioMovimiento In listaInventario

                cantidadDeficit = 0
                importeDeficit = 0

                Select Case i.tipoRegistro
                    Case "E", "EA", "EC"
                        If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
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

                        If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
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

                                Case StatusTipoOperacion.REVERSIONES
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
                codigoLotex = i.customLote.codigoLote
                productoCache = i.nombreItem

                NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                         .nrolote = i.customLote.codigoLote,
                                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                         .idAlmacen = i.idAlmacen,
                                         .idItem = i.idItem,
                                         .descripcion = i.nombreItem,
                                         .tipoExistencia = i.tipoProducto,
                                         .unidad = i.unidad,
                                         .CantSaldo = canSaldo,
                                         .saldoMonto = ImporteSaldo})
            Next
        Next



        Dim listaAGuardar = (From n In NuevaListaInventario
                             Select n.idItem, n.idAlmacen, n.nrolote
                             Order By idItem).Distinct.ToList()

        'asignando cierre de inventario
        '----------------------------------------------------------------------------------


        For Each c In listaAGuardar
            Dim obj = NuevaListaInventario.Where(Function(o) o.idItem = c.idItem And o.idAlmacen = c.idAlmacen And o.nrolote = c.nrolote).LastOrDefault

            GetCierreInventarioNuevo2.Add(New totalesAlmacen With {.idAlmacen = c.idAlmacen,
                                                                   .idItem = obj.idItem,
                                                                   .cantidad = obj.CantSaldo,
                                                                   .importeSoles = obj.saldoMonto,
                                                                   .importeDolares = 0})


        Next
        Return GetCierreInventarioNuevo2
    End Function

    'Private Function GetCierreInventarioNuevo() As List(Of totalesAlmacen)
    '    Dim cierreSA As New CierreInventarioSA
    '    Dim cierre As New cierreinventario
    '    Dim listaCierre As New List(Of cierreinventario)
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim inventario As New inventarioMovimientoSA
    '    Dim listaInventario As New List(Of InventarioMovimiento)
    '    Dim producto As String = Nothing
    '    Dim cantidadDeficit As Decimal = 0
    '    Dim importeDeficit As Decimal = 0
    '    Dim productoCache As String = Nothing
    '    Dim almacenSA As New almacenSA
    '    '-----------------------------------------------------------------------------------------------------
    '    ImporteSaldo = 0
    '    canSaldo = 0
    '    '''''''''''''''m

    '    Dim almacenes = almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)
    '    ListaCurarNueva = New List(Of totalesAlmacen)
    '    For Each al In almacenes

    '        listaInventario = inventario.GetMovimientosKardexByMes(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(txtfecha.Value.Year, fechaSeleccionadaCierre.Month + 1, 1)}, Nothing)

    '        Dim conteoLimite = 0
    '        ImporteSaldo = 0
    '        canSaldo = 0
    '        For Each i As InventarioMovimiento In listaInventario
    '            'definiendo limite de articulo
    '            Dim conteoArticulo = listaInventario.Where(Function(o) o.idItem = i.idItem).Count
    '            conteoLimite += 1

    '            cantidadDeficit = 0
    '            importeDeficit = 0

    '            Select Case i.tipoRegistro
    '                Case "E", "EA", "EC"
    '                    If producto = i.idItem Then
    '                        productoCache = i.nombreItem
    '                        canSaldo += CDec(i.cantidad)
    '                        ImporteSaldo += CDec(i.monto)
    '                    Else
    '                        cantidadDeficit = canSaldo
    '                        importeDeficit = ImporteSaldo

    '                        canSaldo = 0
    '                        ImporteSaldo = 0

    '                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
    '                        canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
    '                        ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
    '                        canSaldo = CDec(i.cantidad) + canSaldo
    '                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

    '                    End If
    '                    If canSaldo > 0 Then
    '                        precUnit = ImporteSaldo / canSaldo
    '                    Else
    '                        precUnit = 0
    '                    End If
    '                    pmAcumnulado = precUnit
    '                Case "S", "D"
    '                    Dim co As Decimal = 0
    '                    co = CDec(i.cantidad) * pmAcumnulado

    '                    If producto = i.idItem Then
    '                        productoCache = i.nombreItem
    '                        'canSaldo += CDec(i.cantidad)

    '                        Select Case i.tipoOperacion
    '                            Case "9913"
    '                                canSaldo += CDec(i.cantidad)
    '                                ImporteSaldo = ImporteSaldo

    '                            Case "9914"
    '                                canSaldo = canSaldo
    '                                ImporteSaldo += i.monto

    '                            Case "9916"
    '                                canSaldo += CDec(i.cantidad)
    '                                ImporteSaldo += i.monto

    '                            Case StatusTipoOperacion.REVERSIONES
    '                                canSaldo += CDec(i.cantidad)
    '                                ImporteSaldo += i.monto

    '                            Case Else
    '                                canSaldo += CDec(i.cantidad)
    '                                ImporteSaldo += co
    '                        End Select

    '                    Else
    '                        cantidadDeficit = canSaldo
    '                        importeDeficit = ImporteSaldo

    '                        canSaldo = 0
    '                        ImporteSaldo = 0
    '                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
    '                        canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
    '                        ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault

    '                        canSaldo += CDec(i.cantidad)
    '                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
    '                    End If

    '                    If canSaldo > 0 Then
    '                        precUnit = ImporteSaldo / canSaldo
    '                    Else
    '                        precUnit = 0
    '                    End If

    '                    pmAcumnulado = precUnit
    '            End Select

    '            producto = i.idItem
    '            productoCache = i.nombreItem

    '            If conteoLimite = conteoArticulo Then
    '                ListaCurarNueva.Add(New totalesAlmacen With {.descripcion = i.nombreItem,
    '                                                        .tipoExistencia = i.tipoProducto,
    '                                                        .idItem = i.idItem,
    '                                                        .idAlmacen = i.idAlmacen,
    '                                                        .cantidad = canSaldo,
    '                                                        .importeSoles = ImporteSaldo,
    '                                                        .importeDolares = 0})
    '                conteoLimite = 0
    '            End If
    '        Next
    '    Next
    '    Return ListaCurarNueva
    'End Function

    Public Sub GetCerrarPeriodoFull()
        Dim curaSA As New TotalesAlmacenSA
        Dim cierre As New empresaCierreMensual
        Dim cierreSA As New empresaCierreMensualSA
        Try
            'ListaCurar = New List(Of totalesAlmacen)
            ListaCurarNueva = New List(Of totalesAlmacen)

            cierre = New empresaCierreMensual
            cierre.anio = fechaSeleccionadaCierre.Year
            cierre.mes = fechaSeleccionadaCierre.Month
            cierre.idEmpresa = Gempresas.IdEmpresaRuc
            cierre.idCentroCosto = GEstableciento.IdEstablecimiento
            cierre.status = True
            cierre.tipoCierre = statusTipoCierre.CierreMensual
            cierre.usuarioActualizacion = usuario.IDUsuario
            cierre.fechaActualizacion = fechaSeleccionadaCierre
            cierreSA.GrabarCierrePeriodo(cierre, GetCierreInventario)
            '  curaSA.GetCurarKardexCaberas(GetCierreInventarioNuevo2)
            MessageBox.Show("Inventario cerrado correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ProgressBar1.Visible = False
        End Try
    End Sub

    Public Sub CierreInventario()
        cierreSA = New CierreInventarioSA
        cierre = New cierreinventario
        lista = New List(Of cierreinventario)
        Dim listaCierre = TotalesAlmacenSA.GetProductosXempresa(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})

        For Each r In listaCierre
            cierre = New cierreinventario
            cierre.idEmpresa = Gempresas.IdEmpresaRuc
            cierre.idCentroCosto = GEstableciento.IdEstablecimiento
            cierre.periodo = fechaSeleccionadaCierre.Month & "/" & fechaSeleccionadaCierre.Year
            cierre.idAlmacen = r.idAlmacen
            cierre.idItem = r.idItem
            cierre.anio = fechaSeleccionadaCierre.Year
            cierre.mes = fechaSeleccionadaCierre.Month
            cierre.dia = fechaSeleccionadaCierre.Day
            cierre.cantidad = r.cantidad
            cierre.importe = r.importeSoles
            cierre.importeUS = r.importeDolares
            cierre.unidad = r.unidadMedida
            cierre.usuarioModificacion = usuario.IDUsuario
            cierre.fechaModificacion = DateTime.Now
            lista.Add(cierre)
        Next
        cierreSA.CerrarInventario(lista)
    End Sub

    Public Sub cierreCuentasFinancieras()
        Dim lista = docCajaSA.ListaDeCajasPorCerrar(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .periodo = String.Format("0:00", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year})

        listaCaja = New List(Of cierreCaja)
        For Each i In lista
            obj = New cierreCaja
            obj.idEntidadFinanciera = i.entidadFinanciera
            obj.idEmpresa = Gempresas.IdEmpresaRuc
            obj.idEstablecimiento = CInt(GEstableciento.IdEstablecimiento)
            obj.periodo = fechaSeleccionadaCierre.Month & fechaSeleccionadaCierre.Year
            obj.fechaProceso = fechaSeleccionadaCierre
            obj.anio = fechaSeleccionadaCierre.Year
            obj.mes = CInt(fechaSeleccionadaCierre.Month)
            obj.dia = fechaSeleccionadaCierre.Day
            obj.montoMN = i.montoSoles
            obj.montoME = i.montoUsd
            obj.usuarioActualizacion = usuario.IDUsuario
            obj.fechaActualizacion = DateTime.Now
            listaCaja.Add(obj)
        Next
        cierreCajaSA.GrabarListaCierreCaja(listaCaja)
    End Sub

    Public Sub CerraCuentasContables()

        listaContable = New List(Of cierrecontable)
        Dim periodo As String = String.Format("{0:00}", fechaSeleccionadaCierre.Month) & "/" & fechaSeleccionadaCierre.Year
        Dim periodoAnt As String = String.Format("{0:00}", fechaSeleccionadaCierre.Month - 1) & fechaSeleccionadaCierre.Year
        Dim lista = movimientosSA.GetCierreContablePeriodo(New asiento With {.periodo = periodo}, periodoAnt)

        For Each r In lista
            cierreContable = New cierrecontable()
            cierreContable.idEmpresa = Gempresas.IdEmpresaRuc
            cierreContable.idCentroCosto = GEstableciento.IdEstablecimiento
            cierreContable.periodo = periodo.Replace("/", "")
            cierreContable.cuenta = r.cuenta
            cierreContable.tipoasiento = r.tipo
            cierreContable.anio = CInt(fechaSeleccionadaCierre.Year)
            cierreContable.mes = CInt(fechaSeleccionadaCierre.Month)
            Select Case r.tipo
                Case "D"
                    cierreContable.monto = r.monto
                    cierreContable.montoUSD = r.montoUSD
                Case "H"
                    cierreContable.monto = r.monto
                    cierreContable.montoUSD = r.montoUSD
            End Select

            cierreContable.usuarioActualizacion = usuario.IDUsuario
            cierreContable.fechaActualizacion = DateTime.Now
            listaContable.Add(cierreContable)
        Next r
        CierreContableSA.GrabarListaAsientosCierre(listaContable)
    End Sub

    Private Sub bg_DoWork(sender As Object, e As DoWorkEventArgs) Handles bg.DoWork
        GetCerrarPeriodoFull()
    End Sub

    Private Sub bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted
        ProgressBar1.Visible = False
        Cerrar.Text = "Cerrar mes"
        GetCierres()
        VerificaCierre = "Cerrado"
        Tag = "Cerrado"
        'If VerificaCierre = "Cerrado" Then
        '    Close()
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ListView1.SelectedItems.Count > 0 Then
                EliminarCierre(ListView1.SelectedItems(0))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GetCierres()
    End Sub

    Private Sub Cerrar_Click(sender As Object, e As EventArgs) Handles Cerrar.Click
        Try
            Dim boxUserSA As New cajaUsuarioSA
            Dim be As New cajaUsuario
            be.idEmpresa = Gempresas.IdEmpresaRuc
            be.idEstablecimiento = GEstableciento.IdEstablecimiento

            'Dim Count = boxUserSA.ListBoxClosedPendingCount(be)

            'If Count > 0 Then
            '    MessageBox.Show("Tiene Arqueo pendientes")
            '    Exit Sub
            'End If
            'Dim cajasVencidas2 = ListaCajasActivas.Where(Function(o) o.fechaRegistro.Value.Date < Date.Now.Date).ToList
            If ListaCajasActivas.Count > 0 Then

                Dim FormCajaActivas As New FormCajaActivas(ListaCajasActivas)
                FormCajaActivas.StartPosition = FormStartPosition.CenterParent
                FormCajaActivas.ShowDialog(Me)

                ListaCajasActivas = boxUserSA.ListadoCajaXEstado(New cajaUsuario With {
                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                 .estadoCaja = "A"
                                                 })
            End If

            ListaCajasActivas = boxUserSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })

            If ListaCajasActivas.Count > 0 Then
                MessageBox.Show("Debe cerrar La Caja Abiertas")
                Exit Sub
            End If







            If Cerrar.Text = "Cerrar mes" Then
                If chValidarCierre.Checked = True Then

                    '     Cerrar.Text = "Cancelar"

                    Dim fechaAnt = fechaSeleccionadaCierre
                    fechaAnt = fechaAnt.AddMonths(-1)
                    Dim periodoAnteriorEstaCerrado = cierreMensualSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                    If periodoAnteriorEstaCerrado = True Then
                        If bg.IsBusy <> True Then
                            ' Start the asynchronous operation.
                            ProgressBar1.Visible = True
                            ProgressBar1.Style = ProgressBarStyle.Marquee
                            bg.RunWorkerAsync()
                        End If
                    Else
                        MessageBox.Show("Debe cerrar el período: " & fechaAnt.Month & "/" & fechaAnt.Year & vbCrLf &
                                        "para realizar el cierre del período actual: " & fechaSeleccionadaCierre.Month & "/" & fechaSeleccionadaCierre.Year)
                    End If
                Else
                    ' sin validacion
                    If bg.IsBusy <> True Then
                        ProgressBar1.Visible = True
                        ' Start the asynchronous operation.
                        bg.RunWorkerAsync()
                    End If
                End If
            ElseIf Cerrar.Text = "Cancelar" Then
                If bg.WorkerSupportsCancellation = True Then
                    ' Cancel the asynchronous operation.
                    bg.CancelAsync()
                    ProgressBar1.Visible = False
                    Cerrar.Text = "Cerrar mes"
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ProgressBar1.Visible = False
        End Try
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked

    End Sub


#End Region



End Class

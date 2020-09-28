Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class UCRentabilidad

#Region "Variables"
    Dim filter As New GridExcelFilter()
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

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

#End Region

#Region "Attributes"
    Public Property UCRentabilidadXfecha As UCRentabilidadXfecha
#End Region

#Region "Methods"
    Public Sub GetEstablecimientos()
        Dim centroSA As New establecimientoSA

        ComboUnidad.DataSource = centroSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN" And o.idCentroCosto = GEstableciento.IdEstablecimiento).ToList
        ComboUnidad.DisplayMember = "nombre"
        ComboUnidad.ValueMember = "idCentroCosto"
        ComboUnidad.SelectedValue = GEstableciento.IdEstablecimiento
    End Sub

    Public Sub ConsultaReporte()
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim lista = listaInventario.Where(Function(o) o.fecha.Value.Year = txtFecha.Value.Year And o.fecha.Value.Month = txtFecha.Value.Month And o.fecha.Value.Day = txtFecha.Value.Day).ToList
        If (lista.Count > 0) Then
            Me.reportName = "Helios.Cont.Presentation.WinForm.RentabilidadXDia.rdlc"
            Me.reportData = lista ' listaInventario.ToList 'ventaSA.GetArticulosVendidosByDia(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaDoc = txtFecha.Value})
            Me.nombreMainDS = "DSRentaDia"
            Dim reporte As New ReportDataSource(nombreMainDS, reportData)
            ReportViewer1.KeepSessionAlive = True
            ReportViewer1.Reset()
            ReportViewer1.LocalReport.DataSources.Add(reporte)
            ReportViewer1.LocalReport.Refresh()
            ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
            ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
            Dim oParams As New List(Of ReportParameter)
            oParams.Add(New ReportParameter("EmpresaRP", Gempresas.NomEmpresa))
            oParams.Add(New ReportParameter("DiaRP", txtFecha.Value.Date.ToString))
            ReportViewer1.ShowParameterPrompts = True
            ReportViewer1.LocalReport.SetParameters(oParams)
            ReportViewer1.RefreshReport()
            ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = 75
        End If
    End Sub

    Public Sub ConsultaReporteMes()
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim lista = listaInventario.Where(Function(o) o.fecha.Value.Year = txtFecha.Value.Year And o.fecha.Value.Month = txtFecha.Value.Month).ToList
        Me.reportName = "Helios.Cont.Presentation.WinForm.RentabilidadXMes.rdlc"
        Me.reportData = lista ' listaInventario.ToList 'ventaSA.GetArticulosVendidosByDia(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaDoc = txtFecha.Value})
        Me.nombreMainDS = "DSRentaDia"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("EmpresaRP", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("DiaRP", txtFecha.Value.Date.ToString))
        ReportViewer1.ShowParameterPrompts = True
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

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

    End Sub

    Private Sub GetCostoVentaMes(anio As Integer, mes As Integer, dia As Integer)
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

            listaInventario = inventario.GetRentabilidadV2(New InventarioMovimiento With
                                                           {
                                                           .idAlmacen = al.idAlmacen, .fecha = New DateTime(anio, mes, 1)
                                                           }, New DateTime(anio, mes, 1), New DateTime(anio, mes, 1), "Mes")



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
                            canSaldo = canSaldo + i.cantidad.GetValueOrDefault
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
                            canSaldo = canSaldo + i.cantidad.GetValueOrDefault
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
                                         .serie = i.serie,
                                         .numero = i.numero,
                                         .idAlmacen = i.idAlmacen,
                                         .idItem = i.idItem,
                                         .descripcion = i.nombreItem,
                                         .tipoExistencia = i.tipoProducto,
                                         .unidad = i.unidad,
                                         .CantSaldo = (canSaldo),
                                         .saldoMonto = ImporteSaldo,
                                         .CostoSalida = costoSalida,
                                         .monto = (i.monto).GetValueOrDefault,
                                         .nrolote = codigoLotex,
                                         .customLote = i.customLote,
                                         .customProducto = i.customProducto,
                                         .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault,
                                         .cantidad = (i.cantidad.GetValueOrDefault * -1),
                                         .presentacion = i.NombrePresentacion,
                                         .destinoGravadoItem = i.destinoGravadoItem,
                                         .montoOther = i.montoOther.GetValueOrDefault})
            Next
        Next

        listaInventario2 = documentosa.getListaServiosXVenta(New InventarioMovimiento With {.fecha = New DateTime(anio, mes, 1)}, txtFecha.Value, txtFecha.Value, "Dia")

        If (Not IsNothing(listaInventario2)) Then
            For Each i As InventarioMovimiento In listaInventario2
                NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                            .idDocumentoRef = i.idDocumento,
                                            .tipoOperacion = i.tipoOperacion,
                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                            .serie = i.serie,
                                            .fecha = i.fecha,
                                            .numero = i.numero,
                                            .NombreAlmacen = Nothing,
                                            .NombrePresentacion = GEstableciento.NombreEstablecimiento,
                                            .idAlmacen = i.idAlmacen,
                                            .idItem = i.idItem,
                                            .descripcion = i.nombreItem,
                                            .tipoExistencia = i.tipoExistencia,
                                            .unidad = i.unidad,
                                            .nrolote = codigoLotex,
                                            .customLote = i.customLote,
                                            .CantSaldo = CInt(i.cantidad.GetValueOrDefault * -1),
                                            .saldoMonto = ImporteSaldo,
                                            .monto = i.monto.GetValueOrDefault,
                                            .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault,
                                         .presentacion = i.NombrePresentacion,
                                         .destinoGravadoItem = i.destinoGravadoItem,
                                         .montoOther = i.montoOther.GetValueOrDefault})
            Next
        End If
        CargarCostoVenta(NuevaListaInventario)

    End Sub

    Private Sub GetCostoVenta(anio As Integer, mes As Integer, dia As Integer)
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
        'PRUEBA
        Dim ListaPmVenta As New List(Of InventarioMovimiento)
        Dim pmVenta As InventarioMovimiento
        'fin prueba

        Dim almacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        '    ListaCurar = New List(Of totalesAlmacen)

        NuevaListaInventario = New List(Of InventarioMovimiento)
        Dim costoSalida As Decimal = 0
        For Each al In almacenes

            listaInventario = inventario.GetRentabilidadV2(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(anio, mes, 1)}, txtFecha.Value, txtFecha.Value, "Dia")

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
                            canSaldo = canSaldo + i.cantidad.GetValueOrDefault
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
                            canSaldo = canSaldo + i.cantidad.GetValueOrDefault
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


                        If i.tipoOperacion = "01" Then
                            pmVenta = New InventarioMovimiento
                            pmVenta.idDocumento = i.idDocumento
                            pmVenta.nrolote = i.customLote.codigoLote
                            If precUnit > 0 Then
                                pmVenta.precUnite = precUnit
                            ElseIf precUnit = 0 Then

                                If (i.cantidad.GetValueOrDefault > 0) Then
                                    pmVenta.precUnite = (co) / (i.cantidad)
                                Else
                                    pmVenta.precUnite = 0
                                End If
                            End If

                            ListaPmVenta.Add(pmVenta)
                        End If
                End Select

                producto = i.idItem
                codigoLotex = i.customLote.codigoLote
                productoCache = i.nombreItem

                NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                         .idDocumentoRef = i.idDocumento,
                                         .contenido_neto = i.contenido_neto,
                                         .tipoOperacion = i.tipoOperacion,
                                         .fecha = i.fecha,
                                         .idEstablecimiento = ComboUnidad.SelectedValue,
                                         .serie = i.serie,
                                         .numero = i.numero,
                                         .NombreAlmacen = al.descripcionAlmacen,
                                         .NombrePresentacion = ComboUnidad.Text,
                                         .idAlmacen = i.idAlmacen,
                                         .idItem = i.idItem,
                                         .descripcion = i.nombreItem,
                                         .tipoExistencia = i.tipoProducto,
                                         .unidad = i.unidad,
                                         .CantSaldo = (canSaldo),
                                         .saldoMonto = ImporteSaldo,
                                         .CostoSalida = costoSalida,
                                         .monto = (i.monto).GetValueOrDefault,
                                         .customLote = i.customLote,
                                         .customProducto = i.customProducto,
                                         .nrolote = codigoLotex,
                                         .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault,
                                         .cantidad = (i.cantidad.GetValueOrDefault * -1),
                                         .presentacion = i.NombrePresentacion,
                                         .destinoGravadoItem = i.destinoGravadoItem,
                                         .montoOther = i.montoOther.GetValueOrDefault})
            Next
        Next

        listaInventario2 = documentosa.getListaServiosXVenta(New InventarioMovimiento With {.fecha = New DateTime(anio, mes, 1)}, txtFecha.Value, txtFecha.Value, "Dia")

        If (Not IsNothing(listaInventario2)) Then
            For Each i As InventarioMovimiento In listaInventario2
                NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                            .idDocumentoRef = i.idDocumento,
                                            .tipoOperacion = i.tipoOperacion,
                                            .idEstablecimiento = ComboUnidad.SelectedValue,
                                            .serie = i.serie,
                                            .fecha = i.fecha,
                                            .numero = i.numero,
                                            .NombreAlmacen = Nothing,
                                            .NombrePresentacion = ComboUnidad.Text,
                                            .idAlmacen = i.idAlmacen,
                                            .idItem = i.idItem,
                                            .descripcion = i.nombreItem,
                                            .tipoExistencia = i.tipoExistencia,
                                            .unidad = i.unidad,
                                            .nrolote = codigoLotex,
                                            .customLote = i.customLote,
                                            .CantSaldo = CInt(i.cantidad.GetValueOrDefault * -1),
                                            .cantidad = CInt(i.cantidad.GetValueOrDefault * -1),
                                            .saldoMonto = ImporteSaldo,
                                            .monto = i.monto.GetValueOrDefault,
                                            .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault,
                                         .presentacion = i.NombrePresentacion,
                                         .destinoGravadoItem = i.destinoGravadoItem,
                                         .montoOther = i.montoOther.GetValueOrDefault})
            Next
        End If
        CargarCostoVenta(NuevaListaInventario)

    End Sub
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Value = Date.Now
        'GetEstablecimientos()

        cboMesPedido.DataSource = ListaDeMeses()
        cboMesPedido.ValueMember = "Codigo"
        cboMesPedido.DisplayMember = "Mes"
        cboMesPedido.SelectedValue = String.Format("{0:00}", CInt(Date.Now.Month))

        cboAnio.Text = DateTime.Now.Year


        'ReportViewer1 = New ReportViewer With {.Dock = DockStyle.Fill, .Visible = True}
        'panel5.Controls.Add(ReportViewer1)
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click

        Try


            Me.Cursor = Cursors.WaitCursor
            'ReportViewer1 = New ReportViewer

            panel5.Controls.Clear()

            Select Case ComboReporte.Text
                Case "VENTA POR DIA"
                    GetCostoVenta(txtFecha.Value.Year, txtFecha.Value.Month, txtFecha.Value.Day)
                    Dim lista = listaInventario.Where(Function(o) o.fecha.Value.Year = txtFecha.Value.Year And o.fecha.Value.Month = txtFecha.Value.Month And o.fecha.Value.Day = txtFecha.Value.Day).ToList
                    UCRentabilidadXfecha = New UCRentabilidadXfecha(lista, Me) With {.Dock = DockStyle.Fill}
                    panel5.Controls.Add(UCRentabilidadXfecha)
              '  ConsultaReporte()
                Case "VENTA POR MES"
                    Dim periodo = CInt(cboMesPedido.SelectedValue) & "/" & cboAnio.Text
                    Dim fecha = GetPeriodoConvertirToDate(periodo)
                    GetCostoVentaMes(fecha.Year, fecha.Month, fecha.Day)
                    Dim lista = listaInventario.Where(Function(o) o.fecha.Value.Year = fecha.Year And o.fecha.Value.Month = fecha.Month).ToList
                    UCRentabilidadXfecha = New UCRentabilidadXfecha(lista, Me) With {.Dock = DockStyle.Fill}
                    panel5.Controls.Add(UCRentabilidadXfecha)
                    'ConsultaReporteMes()
            End Select
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub ComboReporte_Click(sender As Object, e As EventArgs) Handles ComboReporte.Click

    End Sub

    Private Sub ComboReporte_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboReporte.SelectedValueChanged
        Select Case ComboReporte.Text
            Case "VENTA POR DIA"
                txtFecha.Visible = True
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False

            Case "VENTA POR MES"
                txtFecha.Visible = False
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False


            Case "VENTA POR VENDEDOR"

                ComboUsuarios.Visible = True
                LabelUsuarios.Visible = True

            Case "VENTA POR ARTICULOS"
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False

            Case Else

                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False

        End Select
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        If UCRentabilidadXfecha IsNot Nothing Then
            UCRentabilidadXfecha.GridRentabilidad.TopLevelGroupOptions.ShowFilterBar = True
            UCRentabilidadXfecha.GridRentabilidad.NestedTableGroupOptions.ShowFilterBar = True
            UCRentabilidadXfecha.GridRentabilidad.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In UCRentabilidadXfecha.GridRentabilidad.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            UCRentabilidadXfecha.GridRentabilidad.OptimizeFilterPerformance = True
            UCRentabilidadXfecha.GridRentabilidad.ShowNavigationBar = True
            filter.WireGrid(UCRentabilidadXfecha.GridRentabilidad)
        End If

    End Sub
#End Region

End Class

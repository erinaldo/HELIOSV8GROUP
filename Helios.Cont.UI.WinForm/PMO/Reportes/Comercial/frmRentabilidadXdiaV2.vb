Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmRentabilidadXdiaV2
    Inherits frmMaster
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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Value = DateTime.Now
    End Sub

#Region "Métodos"

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
                        If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
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

                        'aumentado
                        costoSalida += CDec(i.monto)
                End Select

                producto = i.idItem
                codigoLotex = i.customLote.codigoLote
                productoCache = i.nombreItem
                'Dim prueba As Decimal = costoSalida
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
                                         .CantSaldo = canSaldo,
                                         .saldoMonto = ImporteSaldo,
                                         .CostoSalida = costoSalida,
                                         .monto = i.monto * -1,
                                         .nrolote = codigoLotex = i.customLote.codigoLote,
                                         .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault * -1,
                                         .cantidad = CInt(i.cantidad * -1),
                                         .presentacion = i.NombrePresentacion,
                                         .destinoGravadoItem = i.destinoGravadoItem,
                                         .montoOther = i.montoOther})
            Next
        Next

        listaInventario2 = documentosa.getListaServiosXVenta(New InventarioMovimiento With {.fecha = New DateTime(anio, mes, 1)}, txtFecha.Value, txtFecha.Value, "Dia")

        If (Not IsNothing(listaInventario2)) Then
            For Each i As InventarioMovimiento In listaInventario2
                NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                            .idDocumentoRef = i.idDocumento,
                                            .tipoOperacion = i.tipoOperacion,
                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                            .NombreAlmacen = Nothing,
                                            .NombrePresentacion = GEstableciento.NombreEstablecimiento,
                                            .idAlmacen = i.idAlmacen,
                                            .idItem = i.idItem,
                                            .descripcion = i.nombreItem,
                                            .tipoExistencia = i.tipoExistencia,
                                            .unidad = i.unidad,
                                            .CantSaldo = canSaldo,
                                            .saldoMonto = ImporteSaldo,
                                            .CostoSalida = costoSalida,
                                            .monto = i.monto,
                                            .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault})
            Next
        End If
        CargarCostoVenta(NuevaListaInventario)
    End Sub

    'Public Sub ConsultaReporteRentabilidad()
    '    'Dim ventaSA As New documentoVentaAbarrotesSA
    '    Dim ventaSA As New inventarioMovimientoSA
    '    Me.reportName = "Helios.Cont.Presentation.WinForm.rpvRentabilidadXdia.rdlc"
    '    'Me.reportData = ventaSA.GetRentabilidadPorDia(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaDoc = txtFecha.Value})
    '    'Me.reportData = ventaSA.GetRentabilidad(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc}, txtFecha.Value, txtFecha.Value)
    '    Me.reportData = listaInventario ' ventaSA.GetRentabilidad(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc}, txtFecha.Value, txtFecha.Value)
    '    Me.nombreMainDS = "DSRentabilidad"
    '    Dim reporte As New ReportDataSource(nombreMainDS, reportData)
    '    ReportViewer1.KeepSessionAlive = True
    '    ReportViewer1.Reset()
    '    ReportViewer1.LocalReport.DataSources.Add(reporte)
    '    ReportViewer1.LocalReport.Refresh()
    '    ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
    '    ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
    '    Dim oParams As New List(Of ReportParameter)
    '    oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
    '    oParams.Add(New ReportParameter("rpDia", txtFecha.Value.Date))
    '    ReportViewer1.LocalReport.SetParameters(oParams)
    '    ReportViewer1.RefreshReport()
    '    ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
    '    ReportViewer1.ZoomMode = ZoomMode.Percent
    '    ReportViewer1.ZoomPercent = 75
    'End Sub

    Public Sub ConsultaReporte()
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim lista = listaInventario.Where(Function(o) o.fecha.Value.Year = txtFecha.Value.Year And o.fecha.Value.Month = txtFecha.Value.Month And o.fecha.Value.Day = txtFecha.Value.Day).ToList
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
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

#End Region

    Private Sub frmrentabilidadXdia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        GetCostoVenta(txtFecha.Value.Year, txtFecha.Value.Month, txtFecha.Value.Day)
        ConsultaReporte()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class

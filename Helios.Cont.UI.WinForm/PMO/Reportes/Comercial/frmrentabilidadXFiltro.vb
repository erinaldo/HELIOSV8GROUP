Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Imports Syncfusion.Windows.Forms

Public Class frmrentabilidadXFiltro
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
    'Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim listaInventario As New List(Of InventarioMovimiento)
    Dim TotalMercaderia As Decimal = CDec(0.0)
    Dim TotalProductoTerminado As Decimal = CDec(0.0)
    Dim TotalSubProductosTerminados As Decimal = CDec(0.0)
    Public Property listaItem As New List(Of detalleitems)
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of detalleitems))
    Friend Delegate Sub SetDataSourceDelegateEntidad(ByVal lista As List(Of entidad))
    Public Property listaClientes As New List(Of entidad)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Value = DateTime.Now
        GetItem()
        threadClientes()
    End Sub

#Region "Métodos"

    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetItem()
        Dim detalleitemsSA As New detalleitemsSA
        Dim lista = detalleitemsSA.GetExistenciasByEstablecimiento(GEstableciento.IdEstablecimiento)
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of detalleitems))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaItem = New List(Of detalleitems)
            listaItem = lista
        End If
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim entidadSA As New entidadSA
        Dim lista = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateEntidad(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
            'ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub FillLSVItem(consulta As List(Of detalleitems))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.tipoExistencia)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            LsvProveedor.Items.Add(n)
        Next
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

            'por item la busqueda
            If (rbItem.Checked = True) Then
                If (chDia.Checked = True) Then
                    listaInventario = inventario.GetRentabilidadV2(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(anio, mes, 1), .idItem = txtItem.Tag}, txtFecha.Value, txtFecha.Value, "ItemDia")
                ElseIf (chMes.Checked = True) Then
                    listaInventario = inventario.GetRentabilidadV2(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(anio, mes, 1), .idItem = txtItem.Tag}, txtFecha.Value, txtFecha.Value, "ItemMes")
                End If

                'por cliente la busqueda
            ElseIf (rbCliente.Checked = True) Then
                If (chDia.Checked = True) Then
                    listaInventario = inventario.GetRentabilidadV2(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(anio, mes, 1), .idItem = txtItem.Tag}, txtFecha.Value, txtFecha.Value, "ClienteDia")
                ElseIf (chMes.Checked = True) Then
                    listaInventario = inventario.GetRentabilidadV2(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(anio, mes, 1), .idItem = txtItem.Tag}, txtFecha.Value, txtFecha.Value, "ClienteMes")
                End If
            End If

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
                                            .nrolote = codigoLotex = i.customLote.codigoLote,
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

    Public Sub ConsultaReporte2()
        Dim ventaSA As New documentoVentaAbarrotesSA
        If (rbItem.Checked = True) Then
            If (chDia.Checked = True) Then
                Dim lista = listaInventario.Where(Function(o) o.fecha.Value.Year = txtFecha.Value.Year And o.fecha.Value.Month = txtFecha.Value.Month And o.fecha.Value.Day = txtFecha.Value.Day And o.idItem = txtItem.Tag).ToList
                Me.reportName = "Helios.Cont.Presentation.WinForm.RentabilidadXFiltro.rdlc"
                Me.reportData = lista ' listaInventario.ToList 'ventaSA.GetArticulosVendidosByDia(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaDoc = txtFecha.Value})
                Me.nombreMainDS = "DSRentaXFiltro"
            ElseIf (chMes.Checked = True) Then
                Dim lista = listaInventario.Where(Function(o) o.fecha.Value.Year = txtFecha.Value.Year And o.fecha.Value.Month = txtFecha.Value.Month And o.idItem = txtItem.Tag).ToList
                Me.reportName = "Helios.Cont.Presentation.WinForm.RentabilidadXFiltroMes.rdlc"
                Me.reportData = lista ' listaInventario.ToList 'ventaSA.GetArticulosVendidosByDia(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaDoc = txtFecha.Value})
                Me.nombreMainDS = "DSRentaXFiltro"
            End If
        ElseIf (rbCliente.Checked = True) Then
            If (chDia.Checked = True) Then
                Dim lista = listaInventario.Where(Function(o) o.fecha.Value.Year = txtFecha.Value.Year And o.fecha.Value.Month = txtFecha.Value.Month And o.fecha.Value.Day = txtFecha.Value.Day).ToList
                Me.reportName = "Helios.Cont.Presentation.WinForm.RentabilidadXClienteDia.rdlc"
                Me.reportData = lista 'listaInventario.ToList 'ventaSA.GetArticulosVendidosByDia(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaDoc = txtFecha.Value})
                Me.nombreMainDS = "DSRentaXFiltro"
            ElseIf (chMes.Checked = True) Then
                Dim lista = listaInventario.Where(Function(o) o.fecha.Value.Year = txtFecha.Value.Year And o.fecha.Value.Month = txtFecha.Value.Month).ToList
                Me.reportName = "Helios.Cont.Presentation.WinForm.RentabilidadXClienteMes.rdlc"
                Me.reportData = lista 'listaInventario.ToList 'ventaSA.GetArticulosVendidosByDia(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaDoc = txtFecha.Value})
                Me.nombreMainDS = "DSRentaXFiltro"
            End If
        End If
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer3.KeepSessionAlive = True
        ReportViewer3.Reset()
        ReportViewer3.LocalReport.DataSources.Add(reporte)
        ReportViewer3.LocalReport.Refresh()
        ReportViewer3.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer3.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        If (rbItem.Checked = True) Then
            If (chDia.Checked = True) Then
                oParams.Add(New ReportParameter("EmpresaRP", Gempresas.NomEmpresa))
                oParams.Add(New ReportParameter("DiaRP", txtFecha.Value.Date.ToString))
                oParams.Add(New ReportParameter("Item", txtItem.Text))
            ElseIf (chMes.Checked = True) Then
                oParams.Add(New ReportParameter("EmpresaRP", Gempresas.NomEmpresa))
                oParams.Add(New ReportParameter("DiaRP", txtFecha.Value.Date.ToString))
                oParams.Add(New ReportParameter("Item", txtItem.Text))
            End If
        ElseIf (rbCliente.Checked = True) Then
            If (chDia.Checked = True) Then
                oParams.Add(New ReportParameter("EmpresaRP", Gempresas.NomEmpresa))
                oParams.Add(New ReportParameter("DiaRP", txtFecha.Value.Date.ToString))
                oParams.Add(New ReportParameter("Item", txtItem.Text))
            ElseIf (chMes.Checked = True) Then
                oParams.Add(New ReportParameter("EmpresaRP", Gempresas.NomEmpresa))
                oParams.Add(New ReportParameter("DiaRP", txtFecha.Value.Date.ToString))
                oParams.Add(New ReportParameter("Item", txtItem.Text))
            End If
        End If
        ReportViewer3.LocalReport.SetParameters(oParams)
        ReportViewer3.RefreshReport()
        ReportViewer3.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer3.ZoomMode = ZoomMode.Percent
        ReportViewer3.ZoomPercent = 75
    End Sub

#End Region

    Private Sub frmrentabilidadXdia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If (txtItem.Text.Length > 0) Then
            If (txtItem.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)) Then
                If (rbItem.Checked = True) Then
                    GetCostoVenta(txtFecha.Value.Year, txtFecha.Value.Month, txtFecha.Value.Day)
                    ConsultaReporte2()
                ElseIf (rbCliente.Checked = True) Then
                    GetCostoVenta(txtFecha.Value.Year, txtFecha.Value.Month, txtFecha.Value.Day)
                    ConsultaReporte2()
                End If
            Else
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ChPagoDirecto_OnChange(sender As Object, e As EventArgs) Handles chMes.OnChange
        If (chMes.Checked = True) Then
            txtFecha.Format = DateTimePickerFormat.Custom
            txtFecha.CustomFormat = "MM/yyyy"
            chMes.Checked = True
            chDia.Checked = False
            txtItem.Text = String.Empty
            txtFecha.Value = Date.Now
            ReportViewer3.Reset()
        End If
    End Sub

    Private Sub chDia_OnChange(sender As Object, e As EventArgs) Handles chDia.OnChange
        If (chDia.Checked = True) Then
            txtFecha.Format = DateTimePickerFormat.Custom
            txtFecha.CustomFormat = "dd/MM/yyyy"
            chMes.Checked = False
            chDia.Checked = True
            txtItem.Text = String.Empty
            txtFecha.Value = Date.Now
            ReportViewer3.Reset()

        End If
    End Sub

    Private Sub LsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If LsvProveedor.SelectedItems.Count > 0 Then
                txtItem.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                txtItem.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                txtItem.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If
        End If
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtItem.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtItem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItem.KeyDown
        If (rbItem.Checked = True) Then
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            Else
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                Me.pcLikeCategoria.Size = New Size(350, 180)
                Me.pcLikeCategoria.ParentControl = Me.txtItem
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
                Dim consulta = (From n In listaItem
                                Where (n.descripcionItem.StartsWith(txtItem.Text.ToUpper))).ToList

                FillLSVItem(consulta)
                e.Handled = True
            End If

            If e.KeyCode = Keys.Down Then
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                Me.pcLikeCategoria.Size = New Size(350, 180)
                Me.pcLikeCategoria.ParentControl = Me.txtItem
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
                LsvProveedor.Focus()
            End If
            '   End If

            ' e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then
                If Me.pcLikeCategoria.IsShowing() Then
                    Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
                End If
            End If

        ElseIf (rbCliente.Checked = True) Then
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            Else
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                Me.pcLikeCategoria.Size = New Size(350, 180)
                Me.pcLikeCategoria.ParentControl = Me.txtItem
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
                Dim consulta2 = (From n In listaClientes
                                 Where n.nombreCompleto.StartsWith(txtItem.Text.ToUpper)).ToList


                'consulta2.AddRange(consulta2)
                FillLSVClientes(consulta2)
                e.Handled = True
            End If

            If e.KeyCode = Keys.Down Then
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                Me.pcLikeCategoria.Size = New Size(350, 180)
                Me.pcLikeCategoria.ParentControl = Me.txtItem
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
                LsvProveedor.Focus()
            End If
            '   End If

            ' e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then
                If Me.pcLikeCategoria.IsShowing() Then
                    Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
                End If
            End If
        End If


    End Sub

    Private Sub rbItem_CheckedChanged(sender As Object, e As EventArgs) Handles rbItem.CheckedChanged
        If (rbItem.Checked = True) Then
            rbItem.Checked = True
            'rbDocumento.Checked = False
            rbCliente.Checked = False
            Panel5.Visible = True
            ReportViewer3.Reset()
            txtItem.Text = ""
        End If
    End Sub

    'Private Sub rbDocumento_CheckedChanged(sender As Object, e As EventArgs)
    '    If (rbDocumento.Checked = True) Then
    '        rbDocumento.Checked = True
    '        rbItem.Checked = False
    '        rbCliente.Checked = False
    '        Panel5.Visible = False
    '        ReportViewer3.Reset()
    '        txtItem.Text = ""
    '    End If
    'End Sub

    Private Sub rbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbCliente.CheckedChanged
        If (rbCliente.Checked = True) Then
            rbCliente.Checked = True
            rbItem.Checked = False
            'rbDocumento.Checked = False
            Panel5.Visible = True
            ReportViewer3.Reset()
            txtItem.Text = ""
        End If
    End Sub

    Private Sub txtItem_TextChanged(sender As Object, e As EventArgs) Handles txtItem.TextChanged
        txtItem.ForeColor = Color.Black
        txtItem.Tag = Nothing
        'If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        '    txtruc.Visible = True
        'Else
        '    txtruc.Visible = False
        'End If
    End Sub
End Class

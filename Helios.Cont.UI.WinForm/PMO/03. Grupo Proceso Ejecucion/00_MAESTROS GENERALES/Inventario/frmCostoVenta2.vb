Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmCostoVenta2
    Inherits frmMaster


    Public Property FechaPeriodo() As DateTime
    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0
    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0

    Dim listaNueva As New List(Of InventarioMovimiento)
#Region "Métodos"


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' ListaPorCerrar()
        'Me.WindowState = FormWindowState.Maximized
        Dim str = CDate("1/" & PeriodoGeneral)
        FechaPeriodo = str

        txtAnioCompra.Text = AnioGeneral
        Meses()
    End Sub


    Private Sub Meses()
        Dim listaMeses As New List(Of MesesAnio)
        Dim obj As New MesesAnio

        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x
        'cboMes.DisplayMember = "Mes"
        'cboMes.ValueMember = "Codigo"
        'cboMes.DataSource = listaMeses

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

    Sub Grabar()
        Dim obj As New cierreCostoVenta
        Dim cierreSA As New cierreCostoVentaSA
        Dim lista As New List(Of cierreCostoVenta)
        Dim objDocumento As New documento()
        Dim asiento As New List(Of asiento)
        Dim ListaAsiento As New List(Of asiento)
        Try




            With objDocumento
                'objDocumento = New documento
                objDocumento.idEmpresa = Gempresas.IdEmpresaRuc
                objDocumento.idCentroCosto = GEstableciento.IdEstablecimiento
                objDocumento.idProyecto = 0
                objDocumento.tipoDoc = "01"
                objDocumento.fechaProceso = DateTime.Now
                objDocumento.nroDoc = "2354235"
                objDocumento.idOrden = "1"
                objDocumento.tipoOperacion = "99"
                objDocumento.usuarioActualizacion = "Jiuni"
                objDocumento.fechaActualizacion = DateTime.Now
            End With




            For Each i As Record In GridGroupingControl1.Table.Records
                obj = New cierreCostoVenta

                obj.idEmpresa = Gempresas.IdEmpresaRuc
                obj.idCentroCosto = CInt(GEstableciento.IdEstablecimiento)
                obj.periodo = PeriodoGeneral.Replace("/", "")

                obj.anio = AnioGeneral
                obj.mes = CInt(MesGeneral)
                obj.dia = FechaPeriodo.Day
                obj.tipoExistencia = i.GetValue("tipoExistencia")
                obj.tipoOperacion = i.GetValue("tipoOperacion")
                obj.importe = CDec(i.GetValue("importe"))
                obj.importeUS = CDec(i.GetValue("importe"))
                obj.usuarioModificacion = "Jiuni"
                obj.fechaModificacion = DateTime.Now
                lista.Add(obj)
            Next



            asiento = asientoCosto()
            'ListaAsiento.Add(asiento)
            objDocumento.asiento = asiento



            cierreSA.GrabarListaCierreCostoVenta(lista, objDocumento)
            MessageBox.Show("Cierre realizado con éxito")
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Function asientoCosto() As List(Of asiento)
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim listaAs As New List(Of asiento)
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        For Each i As Record In GridGroupingControl1.Table.Records
            If CDec(i.GetValue("importe")) > 0 Then


                nAsiento = New asiento
                nAsiento.idDocumento = 0
                nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                'nAsiento.idEntidad = lblIdProveedor
                'nAsiento.idEntidad = txtProveedor.Tag
                'nAsiento.nombreEntidad = lblNomProveedor
                'nAsiento.nombreEntidad = txtProveedor.Text
                'nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                'nAsiento.tipoEntidad = txttipoProveedor.Text
                nAsiento.fechaProceso = DateTime.Now
                nAsiento.codigoLibro = "1"
                nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
                'nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
                nAsiento.tipoAsiento = "CCV"
                'correccin asientos
                nAsiento.importeMN = CDec(i.GetValue("importe")) ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
                nAsiento.importeME = CDec(i.GetValue("importe"))  ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
                nAsiento.glosa = "CIERRE DE COSTO VENTAS"
                nAsiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.fechaActualizacion = DateTime.Now

                'For Each i As DataGridViewRow In dgvDetalleItems.Rows

                'aquiiiiiiiiiiiiiiiiii!()


                'For Each i As DataGridViewRow In dgvPagosVarios.Rows
                If CDec(i.GetValue("importe")) > 0 Then

                    Select Case i.GetValue("tipoExistencia")
                        Case "01"  'mercaderia

                            If i.GetValue("tipoOperacion") = "01" Then
                                nAsiento.movimiento.Add(AS_HaberAsiento01(i.GetValue("importe"), i.GetValue("importe")))
                                nAsiento.movimiento.Add(AS_DebeAsiento01(i.GetValue("importe"), i.GetValue("importe")))
                            ElseIf i.GetValue("tipoOperacion") = "9916" Then
                                nAsiento.movimiento.Add(AS_HaberAsiento019916(i.GetValue("importe"), i.GetValue("importe")))
                                nAsiento.movimiento.Add(AS_DebeAsiento019916(i.GetValue("importe"), i.GetValue("importe")))
                            End If

                        Case "02" 'prod terminado

                            If i.GetValue("tipoOperacion") = "01" Then
                                nAsiento.movimiento.Add(AS_HaberAsiento02(i.GetValue("importe"), i.GetValue("importe")))
                                nAsiento.movimiento.Add(AS_DebeAsiento02(i.GetValue("importe"), i.GetValue("importe")))
                            ElseIf i.GetValue("tipoOperacion") = "9916" Then
                                nAsiento.movimiento.Add(AS_HaberAsiento029916(i.GetValue("importe"), i.GetValue("importe")))
                                nAsiento.movimiento.Add(AS_DebeAsiento029916(i.GetValue("importe"), i.GetValue("importe")))
                            End If

                        Case "06"  'sub producto


                            If i.GetValue("tipoOperacion") = "01" Then
                                nAsiento.movimiento.Add(AS_HaberAsiento06(i.GetValue("importe"), i.GetValue("importe")))
                                nAsiento.movimiento.Add(AS_DebeAsiento06(i.GetValue("importe"), i.GetValue("importe")))
                            ElseIf i.GetValue("tipoOperacion") = "9916" Then
                                nAsiento.movimiento.Add(AS_HaberAsiento069916(i.GetValue("importe"), i.GetValue("importe")))
                                nAsiento.movimiento.Add(AS_DebeAsiento069916(i.GetValue("importe"), i.GetValue("importe")))
                            End If

                    End Select
                End If
            End If

            listaAs.Add(nAsiento)
        Next


        Return listaAs
    End Function
#Region "Cuentas Segun Tipo Existencia y Operacion"


    Public Function AS_HaberAsiento01(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "20111",
      .descripcion = "Costo",
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_DebeAsiento01(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "691",
      .descripcion = "Mercaderías",
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_HaberAsiento019916(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "691",
      .descripcion = "Mercaderías",
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_DebeAsiento019916(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "20111",
      .descripcion = "Costo",
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    'prod terminado

    Public Function AS_HaberAsiento02(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "211",
      .descripcion = "PRODUCTOS MANUFACTURADOS",
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_DebeAsiento02(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "692",
      .descripcion = "PRODUCTOS TERMINADOS",
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_HaberAsiento029916(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "692",
      .descripcion = "PRODUCTOS TERMINADOS",
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_DebeAsiento029916(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "211",
      .descripcion = "PRODUCTOS MANUFACTURADOS",
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    'sub producto

    Public Function AS_HaberAsiento06(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "221",
      .descripcion = "SUBPRODUCTOS",
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_DebeAsiento06(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "693",
      .descripcion = "SUBPRODUCTOS, DESECHOS Y DESPERDICIOS",
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_HaberAsiento069916(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "693",
      .descripcion = "SUBPRODUCTOS, DESECHOS Y DESPERDICIOS",
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_DebeAsiento069916(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "221",
      .descripcion = "SUBPRODUCTOS",
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function
#End Region
   
    Private Sub GetLSV(be As InventarioMovimiento)

        Try
            Dim lista = GetCostoVentaXtipoExistencia(be)

            'If Not IsNothing(lista) Then
            'Else

            '    MessageBox.Show("Este Periodo Tiene cierre")
            '    Exit Sub

            'End If





            listaNueva = lista
            Dim dt As New DataTable()
            dt.Columns.Add("estable")
            dt.Columns.Add("almacen")
            dt.Columns.Add("tipo")
            dt.Columns.Add("tipoOperacion")
            dt.Columns.Add("importe")
            dt.Columns.Add("idestable")
            dt.Columns.Add("idalmacen")
            dt.Columns.Add("tipoExistencia")



            Dim sumObj = (From InventarioMovimientoes In lista
                          Group InventarioMovimientoes By InventarioMovimientoes.idEstablecimiento, InventarioMovimientoes.NomEstablecimiento, InventarioMovimientoes.NombreAlmacen, _
                          InventarioMovimientoes.idAlmacen, InventarioMovimientoes.tipoProducto, InventarioMovimientoes.tipoOperacion Into g = Group
                          Select
                          idEstablecimiento,
                          NomEstablecimiento,
                          NombreAlmacen,
                          idAlmacen,
                          tipoProducto,
                          tipoOperacion,
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
                dt.Rows.Add(i.NomEstablecimiento, i.NombreAlmacen, strTipoEx, i.tipoOperacion, i.monto.GetValueOrDefault, i.idEstablecimiento, i.idAlmacen, i.tipoProducto)

            Next
            GridGroupingControl1.DataSource = dt
            'For Each i In lista2
            '    Dim n As New ListViewItem(i)

            '    Dim SumaTipoProd = Aggregate s In lista
            '                           Where s.tipoProducto = i
            '                               Into Sum(s.monto)

            '    n.SubItems.Add(SumaTipoProd.GetValueOrDefault)
            '    lsvCostoVentas.Items.Add(n)
            'Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetCostoVentaXtipoExistencia(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim New_listaInventario As List(Of InventarioMovimiento)

        Dim producto As String = Nothing
        Dim camp_almacen As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim sumaCostoVenta As Decimal = 0
        'Dim valTipoExistencia As String = Nothing


        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        New_listaInventario = New List(Of InventarioMovimiento)
        ' listaInventario = inventario.GetKardexByAnioAlmacenAll(be)
        listaInventario = inventario.GetCostoVentaMensual(be)



        For Each i As InventarioMovimiento In listaInventario
            cantidadDeficit = 0
            importeDeficit = 0
            Select Case i.tipoRegistro
                Case "E" ', "EA", "EC"
                    
                        If i.tipoOperacion = "9916" Then
                            New_listaInventario.Add(New InventarioMovimiento With {.idEstablecimiento = i.idEstablecimiento, .NombreAlmacen = i.NombreAlmacen, .NomEstablecimiento = i.NomEstablecimiento, .idAlmacen = i.idAlmacen, .tipoProducto = i.tipoProducto, .monto = i.monto, .idDocumento = i.idDocumento, .tipoOperacion = "9916"})
                        End If
          

                Case "S" ', "D"
                    Dim n As New ListViewItem(i.tipoProducto)
                    n.SubItems.Add(i.monto)




                    'Case Else
                    If i.tipoOperacion = "01" Then


                        New_listaInventario.Add(New InventarioMovimiento With {.idEstablecimiento = i.idEstablecimiento, .NombreAlmacen = i.NombreAlmacen, .NomEstablecimiento = i.NomEstablecimiento, .idAlmacen = i.idAlmacen, .tipoProducto = i.tipoProducto, .monto = (i.monto * -1), .idDocumento = i.idDocumento, .tipoOperacion = "01"})

                    End If



            End Select
        Next



        'For Each i As InventarioMovimiento In listaInventario
        '    cantidadDeficit = 0
        '    importeDeficit = 0
        '    Select Case i.tipoRegistro
        '        Case "E", "EA", "EC"
        '            If producto = i.idItem AndAlso camp_almacen = i.idAlmacen Then ' AndAlso valTipoExistencia = i.tipoProducto Then
        '                productoCache = i.nombreItem
        '                canSaldo += CDec(i.cantidad)
        '                ImporteSaldo += CDec(i.monto)
        '                If i.tipoOperacion = "9916" Then
        '                    New_listaInventario.Add(New InventarioMovimiento With {.idEstablecimiento = i.idEstablecimiento, .NombreAlmacen = i.NombreAlmacen, .NomEstablecimiento = i.NomEstablecimiento, .idAlmacen = i.idAlmacen, .tipoProducto = i.tipoProducto, .monto = i.monto, .idDocumento = i.idDocumento, .tipoOperacion = "9916"})
        '                End If
        '            Else
        '                cantidadDeficit = canSaldo
        '                importeDeficit = ImporteSaldo

        '                canSaldo = 0
        '                ImporteSaldo = 0

        '                'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
        '                canSaldo = canSaldo + saldoCantidadAnual
        '                ImporteSaldo = ImporteSaldo + saldoImporteAnual
        '                canSaldo = CDec(i.cantidad) + canSaldo
        '                ImporteSaldo = CDec(i.monto) + ImporteSaldo

        '                If i.tipoOperacion = "9916" Then
        '                    New_listaInventario.Add(New InventarioMovimiento With {.idEstablecimiento = i.idEstablecimiento, .NombreAlmacen = i.NombreAlmacen, .NomEstablecimiento = i.NomEstablecimiento, .idAlmacen = i.idAlmacen, .tipoProducto = i.tipoProducto, .monto = i.monto, .idDocumento = i.idDocumento, .tipoOperacion = "9916"})
        '                End If

        '            End If

        '            If canSaldo > 0 Then
        '                precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
        '            Else
        '                precUnit = 0
        '            End If

        '            pmAcumnulado = precUnit
        '        Case "S", "D"
        '            Dim n As New ListViewItem(i.tipoProducto)
        '            n.SubItems.Add(i.monto)

        '            Dim co As Decimal = 0
        '            co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

        '            If producto = i.idItem AndAlso camp_almacen = i.idAlmacen Then 'AndAlso valTipoExistencia = i.tipoProducto Then
        '                productoCache = i.nombreItem
        '                'canSaldo += CDec(i.cantidad)

        '                Select Case i.tipoOperacion
        '                    Case "9913"
        '                        canSaldo += CDec(i.cantidad)
        '                        ImporteSaldo = ImporteSaldo

        '                    Case "9914"
        '                        canSaldo = canSaldo
        '                        ImporteSaldo += i.monto

        '                    Case "9916"
        '                        canSaldo += CDec(i.cantidad)
        '                        ImporteSaldo += i.monto

        '                    Case Else
        '                        canSaldo += CDec(i.cantidad)
        '                        ImporteSaldo += co
        '                End Select

        '            Else
        '                cantidadDeficit = canSaldo
        '                importeDeficit = ImporteSaldo

        '                canSaldo = 0
        '                ImporteSaldo = 0
        '                'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
        '                canSaldo = canSaldo + saldoCantidadAnual
        '                ImporteSaldo = ImporteSaldo + saldoImporteAnual

        '                canSaldo += CDec(i.cantidad)
        '                ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
        '            End If

        '            Select Case i.tipoOperacion
        '                Case "9913"
        '                    'dr(10) = (FormatNumber(i.cantidad, 4)) * -1
        '                    'dr(11) = (0)
        '                    'dr(12) = 0.0

        '                Case "9914"
        '                    'dr(10) = 0.0
        '                    'dr(11) = (0)
        '                    'dr(12) = i.monto * -1

        '                    '   Case "9916"
        '                    'dr(10) = (FormatNumber(i.cantidad, 4)) * -1
        '                    'dr(11) = (0)
        '                    'dr(12) = i.monto * -1

        '                Case Else
        '                    If i.tipoOperacion = "01" Then
        '                        Dim valCap = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1
        '                        sumaCostoVenta += valCap

        '                        New_listaInventario.Add(New InventarioMovimiento With {.idEstablecimiento = i.idEstablecimiento, .NombreAlmacen = i.NombreAlmacen, .NomEstablecimiento = i.NomEstablecimiento, .idAlmacen = i.idAlmacen, .tipoProducto = i.tipoProducto, .monto = valCap, .idDocumento = i.idDocumento, .tipoOperacion = "01"})
        '                    ElseIf i.tipoOperacion = "9916" Then
        '                        Dim valCap = i.monto  'i.monto (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1
        '                        sumaCostoVenta += valCap

        '                        'sumaCostoVenta += i.monto

        '                        New_listaInventario.Add(New InventarioMovimiento With {.idEstablecimiento = i.idEstablecimiento, .NombreAlmacen = i.NombreAlmacen, .NomEstablecimiento = i.NomEstablecimiento, .idAlmacen = i.idAlmacen, .tipoProducto = i.tipoProducto, .monto = valCap, .idDocumento = i.idDocumento, .tipoOperacion = "9916"})
        '                    End If
        '                    'dr(12) =  '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
        '            End Select
        '            'dr(13) = (FormatNumber(canSaldo, 4))
        '            'dr(14) = (FormatNumber(ImporteSaldo, 4))
        '            If canSaldo > 0 Then
        '                precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
        '            Else
        '                precUnit = 0
        '            End If
        '            'dr(15) = precUnit
        '            pmAcumnulado = precUnit
        '    End Select
        '    camp_almacen = i.idAlmacen
        '    producto = i.idItem
        '    productoCache = i.nombreItem
        '    'valTipoExistencia = i.tipoProducto

        'Next

        Return New_listaInventario



    End Function
#End Region

    Private Sub frmCostoVenta2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEmpresa.Text = Gempresas.NomEmpresa
        CaptionLabels(0).Text = "Costo de ventas - " & AnioGeneral
    End Sub

    Private Sub btConsultar_Click(sender As Object, e As EventArgs) Handles btConsultar.Click
        Cursor = Cursors.WaitCursor


        Dim mess = String.Format("{0:00}", cboMesCompra.SelectedValue)
        Select Case cboReporte.Text
            Case "X EMPRESA"
                'GetLSV(New InventarioMovimiento With {.fecha = New DateTime(AnioGeneral, MesGeneral, 1), .idEmpresa = Gempresas.IdEmpresaRuc})
                GetLSV(New InventarioMovimiento With {.fecha = New DateTime(AnioGeneral, mess, 1), .idEmpresa = Gempresas.IdEmpresaRuc})
            Case "X ESTABLECIMIENTO"


        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = GridGroupingControl1.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmDetalleCostoVentas(r.GetValue("tipo"), Val(r.GetValue("idestable")), Val(r.GetValue("idalmacen")), listaNueva)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Grabar()
    End Sub

    Private Sub drgdfg()
        Throw New NotImplementedException
    End Sub

End Class
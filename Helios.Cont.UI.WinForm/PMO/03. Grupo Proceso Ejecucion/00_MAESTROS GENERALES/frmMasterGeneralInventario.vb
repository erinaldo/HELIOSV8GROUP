Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping

Public Class frmMasterGeneralInventario
    Inherits frmMaster
    Dim colorx As New GridMetroColors()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        LoadEstablecimientos()
        Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvTransito)
        GridCFG(dgvAlmacen)
        GridCFG(dgvKardex)
        GridCFG(dgvKardexVal)
        GridCFGKardex(dgvKardex2)
        GridCFGKardex(dgvAsiento)
        GridCFGKardex(dgvMov)
        OptimizeGrid(dgvKardex2)
        GridCFGKardex(dgvStockMin)
        GridCFGKardexx(GridGroupingControl1)
        GridCFG(dgvMov)
        lblPeriodo.Text = "Período: " & PeriodoGeneral
        LoadTipoExistencia()
        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        txtEstablecimiento.Tag = GEstableciento.IdEstablecimiento
        SetRenderer()
        CargarAlmacenes()
        ConteoproductosMenoresaSTOCK()
        ConteoproductosMayoresSTOCK()
        txtPeriodo.Visible = True
        txtFechaDesde.Visible = False
        txtFechaHasta.Visible = False
        Label6.Visible = False
        getAlertasInventario()
    End Sub

#Region "metodo"
    Private Sub getAlertasInventario()
        Dim documentoSA As New DocumentoCompraSA

        Dim conteo1 = documentoSA.GetNumAlertasInventariosSinAsiento(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                  .fechaContable = PeriodoGeneral,
                                                                                  .aprobado = "N", .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS})


        lblAlertasgeneral.Text = conteo1
    End Sub
    Sub Almacenes()
        Dim almacenSA As New almacenSA
        Dim almacenes As New List(Of almacen)
        Dim dt As New DataTable()

        dt.Columns.Add("idalmacen")
        dt.Columns.Add("nombre")
        dt.Columns.Add("tipo")

        almacenes = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)

        For Each i In almacenes
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAlmacen
            dr(1) = i.descripcionAlmacen
            dr(2) = i.tipo
            dt.Rows.Add(dr)
        Next
        dgvAlmacen.DataSource = dt


    End Sub


    Sub VentasCantidadStock(cantidad As String, fechaini As Date, fechafin As Date, mayor As Decimal, menor As Decimal, nombre As String)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoventa As New List(Of documentoventaAbarrotesDet)
        Dim dt As New DataTable(nombre)


        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("monto")
        dt.Columns.Add("stock")
        dt.Columns.Add("idalmacen")


        documentoventa = documentoSA.VentasCantidadStock(cantidad, fechaini, fechafin, mayor, menor)

        For Each i In documentoventa
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.nombreItem
            dr(2) = i.monto1
            dr(3) = i.monto2

            dr(4) = i.NombreProveedor


            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt


    End Sub


    Sub LoadProductosMayorStock()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacen As New List(Of totalesAlmacen)
        Dim dt As New DataTable()
        Dim almacenSA As New almacenSA

        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("NomAlmacen")
        dt.Columns.Add("stock")
        dt.Columns.Add("cantminima")
        dt.Columns.Add("cantmaxima") 'idalmacen

        totalesAlmacen = totalesAlmacenSA.ProductosMayoresStock(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento})

        'Me.HubTile3.Title.Text = totalesAlmacen.Count
        'Me.HubTile3.Title.TextColor = Color.White

        lblmayor.Text = totalesAlmacen.Count

        For Each i In totalesAlmacen
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.idAlmacen

            dr(3) = almacenSA.GetUbicar_almacenPorID(i.idAlmacen).descripcionAlmacen

            dr(4) = i.cantidad
            dr(5) = i.cantidadMinima
            dr(6) = i.cantidadMaxima

            dt.Rows.Add(dr)
        Next
        dgvStockMin.DataSource = dt
        Me.dgvStockMin.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub



    Sub LoadProductosPocoStock()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacen As New List(Of totalesAlmacen)
        Dim dt As New DataTable()
        Dim almacenSA As New almacenSA

        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("NomAlmacen")
        dt.Columns.Add("stock")
        dt.Columns.Add("cantminima")
        dt.Columns.Add("cantmaxima") 'idalmacen

        totalesAlmacen = totalesAlmacenSA.ProductosMenoresStock(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento})

        'Me.HubTileNuevosItems.Title.Text = totalesAlmacen.Count
        'Me.HubTileNuevosItems.Title.TextColor = Color.White

        lblmenor.Text = totalesAlmacen.Count

        For Each i In totalesAlmacen
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.idAlmacen

            dr(3) = almacenSA.GetUbicar_almacenPorID(i.idAlmacen).descripcionAlmacen

            dr(4) = i.cantidad
            dr(5) = i.cantidadMinima
            dr(6) = i.cantidadMaxima

            dt.Rows.Add(dr)
        Next
        dgvStockMin.DataSource = dt
        Me.dgvStockMin.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub




    Public Sub ConteoproductosMenoresaSTOCK()
        Dim totalesSA As New TotalesAlmacenSA
        Dim totales As New List(Of totalesAlmacen)

        totales = totalesSA.ProductosMenoresStock(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento})

        'Me.HubTileNuevosItems.Title.Text = totales.Count
        'Me.HubTileNuevosItems.Title.TextColor = Color.White
        lblmenor.Text = totales.Count
    End Sub

    Public Sub ConteoproductosMayoresSTOCK()
        Dim totalesSA As New TotalesAlmacenSA
        Dim totales As New List(Of totalesAlmacen)

        totales = totalesSA.ProductosMayoresStock(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento})

        'Me.HubTile3.Title.Text = totales.Count
        'Me.HubTile3.Title.TextColor = Color.White

        lblmayor.Text = totales.Count
    End Sub

    Public Sub EditarCantMaxMin()
        Dim objitem As New totalesAlmacen
        Dim totales As New totalesAlmacenRPTSA

        Try
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idAlmacen = Me.dgvKardex.Table.CurrentRecord.GetValue("idalmacen")
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento
            objitem.idItem = Me.dgvKardex.Table.CurrentRecord.GetValue("idItem")
            objitem.cantidadMaxima = Me.dgvKardex.Table.CurrentRecord.GetValue("cantmax")
            objitem.cantidadMinima = Me.dgvKardex.Table.CurrentRecord.GetValue("cantmin")

            totales.EditarCantMaxMin(objitem)
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Item registrado!"

        Catch ex As Exception
            'Manejo de errores
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub
#End Region




#Region "KDX"

    Private Function getParentTableKardexPorAnioMarca() As DataTable
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - año " & AnioGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))


        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerMarcaPorAlmacenesPorAnio(txtAlmacenKardex.Tag, cboMarca.SelectedValue, AnioGeneral)
            If x = 0 Then
                totalsaldo += i.monto
                cantidadSaldo += i.cantidad
                If (totalsaldo = 0) Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If
            Else
                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If

            End If


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                dr(4) = i.marca
            Else

                dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(7) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(8) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(8) = 0
                    End If

                    '(FormatNumber(i.precUnite, 2))
                    dr(9) = (FormatNumber(i.monto, 2))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    dr(10) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(11) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(11) = 0
                    End If
                    ' (FormatNumber(i.precUnite, 2))
                    dr(12) = (FormatNumber(i.monto, 2))
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
            End Select
            dr(16) = i.idDocumento
            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorDiaMarca() As DataTable
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0
        Dim tablaSA As New tablaDetalleSA

        Dim dt As New DataTable("kárdex - día " & DateTime.Now.Date & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))


        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerMarcaPorAlmacenes(txtAlmacenKardex.Tag, cboMarca.SelectedValue)
            If x = 0 Then
                totalsaldo += i.monto
                cantidadSaldo += i.cantidad
                If (totalsaldo = 0) Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If
            Else
                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If

            End If


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = str
            dr(1) = i.destinoGravadoItem
            dr(2) = i.nombreItem
            If i.marca Is Nothing Then
                dr(3) = i.marca
            Else

                dr(3) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(4) = i.tipoProducto
            dr(5) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(6) = (FormatNumber(i.cantidad, 2))
                    dr(7) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2) ' (FormatNumber(i.precUnite, 2))
                    dr(8) = (FormatNumber(i.monto, 2))
                    dr(9) = ("0.00")
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(6) = ("0.00")
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = (FormatNumber(i.cantidad, 2))
                    dr(10) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2) ' (FormatNumber(i.precUnite, 2))
                    dr(11) = (FormatNumber(i.monto, 2))
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
            End Select

            dt.Rows.Add(dr)
        Next
        Return dt



    End Function


    'Private Function getParentTableKardexMarca() As DataTable
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim inventario As New inventarioMovimientoSA
    '    Dim totalsaldo As Decimal = 0
    '    Dim cantidadSaldo As Decimal = 0
    '    Dim PrecioPromedio As Decimal = 0
    '    Dim x = 0

    '    Dim dt As New DataTable("kárdex - período " & PeriodoGeneral & " ")
    '    Dim documentoCajaSA As New DocumentoCajaSA

    '    dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
    '    dt.Columns.Add(New DataColumn("marca", GetType(String)))
    '    'lower case p
    '    dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
    '    dt.Columns.Add(New DataColumn("unidad", GetType(String)))

    '    dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

    '    dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

    '    dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

    '    Dim str As String
    '    For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesExistenciaMarca(txtAlmacenKardex.Tag, ComboBoxAdv1.SelectedValue, cboMarca.SelectedValue)
    '        If x = 0 Then
    '            totalsaldo += i.monto
    '            cantidadSaldo += i.cantidad
    '            If (totalsaldo = 0) Then
    '                PrecioPromedio = 0
    '            Else
    '                If cantidadSaldo > 0 Then
    '                    PrecioPromedio = totalsaldo / cantidadSaldo
    '                End If
    '            End If
    '        Else
    '            totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
    '            cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
    '            If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
    '                PrecioPromedio = 0
    '            Else
    '                If cantidadSaldo > 0 Then
    '                    PrecioPromedio = totalsaldo / cantidadSaldo
    '                End If
    '            End If

    '        End If


    '        Dim dr As DataRow = dt.NewRow()
    '        str = Nothing
    '        str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
    '        dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
    '        dr(1) = str
    '        dr(2) = i.destinoGravadoItem
    '        dr(3) = i.nombreItem
    '        If i.marca Is Nothing Then
    '            dr(4) = i.marca
    '        Else

    '            dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
    '        End If
    '        dr(5) = i.tipoProducto
    '        dr(6) = i.unidad

    '        Select Case i.tipoRegistro
    '            Case "E", "EA", "EC"
    '                dr(7) = (FormatNumber(i.cantidad, 2))
    '                If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
    '                    dr(8) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
    '                Else
    '                    dr(8) = 0
    '                End If

    '                '(FormatNumber(i.precUnite, 2))
    '                dr(9) = (FormatNumber(i.monto, 2))
    '                dr(10) = ("0.00")
    '                dr(11) = ("0.00")
    '                dr(12) = ("0.00")
    '                dr(13) = (FormatNumber(cantidadSaldo, 2))
    '                dr(14) = (FormatNumber(totalsaldo, 2))
    '                dr(15) = (FormatNumber(PrecioPromedio, 2))
    '            Case "S", "D"
    '                dr(7) = ("0.00")
    '                dr(8) = ("0.00")
    '                dr(9) = ("0.00")
    '                dr(10) = (FormatNumber(i.cantidad, 2))
    '                If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
    '                    dr(11) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
    '                Else
    '                    dr(11) = 0
    '                End If
    '                ' (FormatNumber(i.precUnite, 2))
    '                dr(12) = (FormatNumber(i.monto, 2))
    '                dr(13) = (FormatNumber(cantidadSaldo, 2))
    '                dr(14) = (FormatNumber(totalsaldo, 2))
    '                dr(15) = (FormatNumber(PrecioPromedio, 2))
    '        End Select
    '        dr(16) = i.idDocumento
    '        dt.Rows.Add(dr)
    '    Next
    '    Return dt
    'End Function

    Private Function getParentTableKardexPorPeriodoMarca() As DataTable
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))



        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerMarcaPorAlmacenesPorMes(txtAlmacenKardex.Tag, cboMarca.SelectedValue, AnioGeneral, MesGeneral)
            If x = 0 Then
                totalsaldo += i.monto
                cantidadSaldo += i.cantidad
                If (totalsaldo = 0) Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If
            Else
                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If

            End If


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                dr(4) = i.marca
            Else

                dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(7) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(8) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(8) = 0
                    End If

                    '(FormatNumber(i.precUnite, 2))
                    dr(9) = (FormatNumber(i.monto, 2))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    dr(10) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(11) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(11) = 0
                    End If
                    ' (FormatNumber(i.precUnite, 2))
                    dr(12) = (FormatNumber(i.monto, 2))
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
            End Select
            dr(16) = i.idDocumento
            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorPeriodo() As DataTable
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))



        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorMes(txtAlmacenKardex.Tag, lstProductos.SelectedValue, AnioGeneral, MesGeneral)
            If x = 0 Then
                totalsaldo += i.monto
                cantidadSaldo += i.cantidad
                If (totalsaldo = 0) Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If
            Else
                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If

            End If


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                dr(4) = i.marca
            Else

                dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(7) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(8) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(8) = 0
                    End If

                    '(FormatNumber(i.precUnite, 2))
                    dr(9) = (FormatNumber(i.monto, 2))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    dr(10) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(11) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(11) = 0
                    End If
                    ' (FormatNumber(i.precUnite, 2))
                    dr(12) = (FormatNumber(i.monto, 2))
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
            End Select
            dr(16) = i.idDocumento
            dt.Rows.Add(dr)
        Next



        Return dt



    End Function

    'Private Sub generarCostoVenta()
    '    Dim nuevaListaInventario As New List(Of InventarioMovimiento)
    '    Dim inventario As New inventarioMovimientoSA
    '    Dim producto As String = Nothing
    '    Dim cantidadDeficit As Decimal = 0
    '    Dim importeDeficit As Decimal = 0
    '    Dim productoCache As String = Nothing
    '    ImporteSaldo = 0
    '    canSaldo = 0

    '    nuevaListaInventario = New List(Of InventarioMovimiento)
    '    '''''''''''''''m
    '    For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorMesAll(txtAlmacenKardex.Tag, txtPeriodo.Value.Year, txtPeriodo.Value.Month)
    '        cantidadDeficit = 0
    '        importeDeficit = 0
    '        Select Case i.tipoRegistro
    '            Case "E", "EA", "EC"
    '                If producto = i.idItem Then
    '                    productoCache = i.nombreItem
    '                    canSaldo += CDec(i.cantidad)
    '                    ImporteSaldo += CDec(i.monto)
    '                Else
    '                    cantidadDeficit = canSaldo
    '                    importeDeficit = ImporteSaldo

    '                    canSaldo = 0
    '                    ImporteSaldo = 0

    '                    ObtenerSaldoInicioXmesDefault(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem)
    '                    canSaldo = canSaldo + saldoCantidadAnual
    '                    ImporteSaldo = ImporteSaldo + saldoImporteAnual
    '                    canSaldo = CDec(i.cantidad) + canSaldo
    '                    ImporteSaldo = CDec(i.monto) + ImporteSaldo

    '                End If

    '                If canSaldo > 0 Then
    '                    precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
    '                Else
    '                    precUnit = 0
    '                End If
    '                pmAcumnulado = precUnit

    '            Case "S", "D"
    '                Dim co As Decimal = 0
    '                co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

    '                If producto = i.idItem Then
    '                    productoCache = i.nombreItem
    '                    'canSaldo += CDec(i.cantidad)

    '                    Select Case i.tipoOperacion

    '                        Case "9913"
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo = ImporteSaldo

    '                        Case "9914"
    '                            canSaldo = canSaldo
    '                            ImporteSaldo += i.monto

    '                        Case Else
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo += co
    '                    End Select

    '                Else
    '                    cantidadDeficit = canSaldo
    '                    importeDeficit = ImporteSaldo

    '                    canSaldo = 0
    '                    ImporteSaldo = 0
    '                    ObtenerSaldoInicioXmesDefault(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem)
    '                    canSaldo = canSaldo + saldoCantidadAnual
    '                    ImporteSaldo = ImporteSaldo + saldoImporteAnual

    '                    canSaldo += CDec(i.cantidad)
    '                    ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
    '                End If

    '                Select Case i.tipoOperacion
    '                    Case "9913"


    '                    Case "9914"

    '                    Case Else

    '                End Select

    '                If canSaldo > 0 Then
    '                    precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
    '                Else
    '                    precUnit = 0
    '                End If
    '                pmAcumnulado = precUnit
    '        End Select
    '        producto = i.idItem
    '        productoCache = i.nombreItem
    '        nuevaListaInventario.Add()
    '    Next

    'End Sub

    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0

    Private Sub ListaMercaderiasXperiodoTodosProductosTodo()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing

        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex - período " & txtPeriodo.Value.Month & "/" & txtPeriodo.Value.Year)
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
        dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))

        Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorMesAll(txtAlmacenKardex.Tag, txtPeriodo.Value.Year, txtPeriodo.Value.Month)
            cantidadDeficit = 0
            importeDeficit = 0

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                dr(4) = i.marca
            Else
                dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad
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

                        ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If
                    dr(7) = (FormatNumber(i.cantidad, 4))
                    If CDec(i.cantidad) > 0 Then
                        dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                    Else
                        dr(8) = 0
                    End If
                    dr(9) = (FormatNumber(i.monto, 4))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit

                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

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

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0
                        ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")

                    Select Case i.tipoOperacion
                        Case "9913"
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = 0.0

                        Case "9914"
                            dr(10) = 0.0
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case Else
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select
            dr(16) = i.idDocumento
            dr(17) = i.idInventario

            producto = i.idItem
            productoCache = i.nombreItem

            dt.Rows.Add(dr)
        Next
        dgvKardex2.DataSource = dt
        dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub



    Private Sub ListaMercaderiasXperiodoTodosProductos()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing

        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex - período " & txtPeriodo.Value.Month & "/" & txtPeriodo.Value.Year)
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
        dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))

        Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        For Each i As InventarioMovimiento In inventario.ObtenerProdXAlmacenesXMesAllXExist(txtAlmacenKardex.Tag, txtPeriodo.Value.Year, txtPeriodo.Value.Month, ComboBoxAdv1.SelectedValue)
            cantidadDeficit = 0
            importeDeficit = 0

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                '      dr(4) = i.marca
            Else
                '     dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad
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

                        ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If
                    dr(7) = (FormatNumber(i.cantidad, 4))
                    If CDec(i.cantidad) > 0 Then
                        dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                    Else
                        dr(8) = 0
                    End If
                    dr(9) = (FormatNumber(i.monto, 4))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

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

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0
                        ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")

                    Select Case i.tipoOperacion
                        Case "9913"
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = 0.0

                        Case "9914"
                            dr(10) = 0.0
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case "9916"
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case Else
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select
            dr(16) = i.idDocumento
            dr(17) = i.idInventario

            producto = i.idItem
            productoCache = i.nombreItem

            dt.Rows.Add(dr)
        Next
        dgvKardex2.DataSource = dt
        dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Private Sub ListaMercaderiasXperiodoXproducto()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim ImporteSaldoXProducto As Decimal = 0
        Dim canSaldoXproducto As Decimal = 0
        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
        dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))

        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorMes(txtAlmacenKardex.Tag, txtBuscarProducto.Tag, txtPeriodo.Value.Year, txtPeriodo.Value.Month)
            cantidadDeficit = 0
            importeDeficit = 0

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                dr(4) = i.marca
            Else
                dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldoXproducto += CDec(i.cantidad)
                        ImporteSaldoXProducto += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldoXproducto
                        importeDeficit = ImporteSaldoXProducto

                        canSaldoXproducto = 0
                        ImporteSaldoXProducto = 0

                        ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldoXproducto = canSaldoXproducto + saldoCantidadAnual
                        ImporteSaldoXProducto = ImporteSaldoXProducto + saldoImporteAnual
                        canSaldoXproducto = CDec(i.cantidad) + canSaldoXproducto
                        ImporteSaldoXProducto = CDec(i.monto) + ImporteSaldoXProducto

                    End If
                    dr(7) = (FormatNumber(i.cantidad, 4))
                    dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                    dr(9) = (FormatNumber(i.monto, 4))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(canSaldoXproducto, 4))
                    dr(14) = (FormatNumber(ImporteSaldoXProducto, 4))
                    If canSaldoXproducto > 0 Then
                        precUnit = Math.Round(ImporteSaldoXProducto / canSaldoXproducto, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit

                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        'canSaldoXproducto += CDec(i.cantidad)
                        Select Case i.tipoOperacion
                            Case "9913"
                                canSaldoXproducto += CDec(i.cantidad)
                                ImporteSaldoXProducto = ImporteSaldoXProducto

                            Case "9914"

                                canSaldoXproducto = canSaldoXproducto
                                ImporteSaldoXProducto += i.monto
                            Case Else
                                canSaldoXproducto += CDec(i.cantidad)
                                ImporteSaldoXProducto += co
                        End Select


                    Else

                        Select Case i.tipoOperacion
                            Case "9913"

                            Case Else
                                cantidadDeficit = canSaldoXproducto
                                importeDeficit = ImporteSaldoXProducto

                                canSaldoXproducto = 0
                                ImporteSaldoXProducto = 0
                                ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                                canSaldoXproducto = canSaldoXproducto + saldoCantidadAnual
                                ImporteSaldoXProducto = ImporteSaldoXProducto + saldoImporteAnual

                                canSaldoXproducto += CDec(i.cantidad)
                                ImporteSaldoXProducto += CDec((i.cantidad * pmAcumnulado))
                        End Select

                    End If
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    'dr(10) = (FormatNumber(i.cantidad, 4))

                    Select Case i.tipoOperacion
                        Case "9913" 'DISMINUIR CANTIDAD
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = 0.0

                        Case "9914" 'DISMINUIR IMPORTE

                            dr(10) = 0.0
                            dr(11) = (0)
                            dr(12) = i.monto * -1
                        Case Else
                            dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            dr(11) = (0)
                            dr(12) = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select

                    dr(13) = (FormatNumber(canSaldoXproducto, 4))
                    dr(14) = (FormatNumber(ImporteSaldoXProducto, 4))
                    If canSaldoXproducto > 0 Then
                        precUnit = Math.Round(ImporteSaldoXProducto / canSaldoXproducto, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select
            dr(16) = i.idDocumento
            dr(17) = i.idInventario

            producto = i.idItem
            productoCache = i.nombreItem

            dt.Rows.Add(dr)
        Next
        dgvKardex2.DataSource = dt
        dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Private Sub ListaXproductoRangoFechas()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim ImporteSaldoXProducto As Decimal = 0
        Dim canSaldoXproducto As Decimal = 0
        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
        dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorRango(txtAlmacenKardex.Tag, txtBuscarProducto.Tag, txtFechaDesde.Value, txtFechaHasta.Value)
            cantidadDeficit = 0
            importeDeficit = 0

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                dr(4) = i.marca
            Else
                dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldoXproducto += CDec(i.cantidad)
                        ImporteSaldoXProducto += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldoXproducto
                        importeDeficit = ImporteSaldoXProducto

                        canSaldoXproducto = 0
                        ImporteSaldoXProducto = 0

                        '    ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldoXproducto = canSaldoXproducto + saldoCantidadAnual
                        ImporteSaldoXProducto = ImporteSaldoXProducto + saldoImporteAnual
                        canSaldoXproducto = CDec(i.cantidad) + canSaldoXproducto
                        ImporteSaldoXProducto = CDec(i.monto) + ImporteSaldoXProducto

                    End If
                    dr(7) = (FormatNumber(i.cantidad, 4))
                    dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                    dr(9) = (FormatNumber(i.monto, 4))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(canSaldoXproducto, 4))
                    dr(14) = (FormatNumber(ImporteSaldoXProducto, 4))
                    If canSaldoXproducto > 0 Then
                        precUnit = Math.Round(ImporteSaldoXProducto / canSaldoXproducto, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit

                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldoXproducto += CDec(i.cantidad)
                        ImporteSaldoXProducto += co
                    Else
                        cantidadDeficit = canSaldoXproducto
                        importeDeficit = ImporteSaldoXProducto

                        canSaldoXproducto = 0
                        ImporteSaldoXProducto = 0
                        '     ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldoXproducto = canSaldoXproducto + saldoCantidadAnual
                        ImporteSaldoXProducto = ImporteSaldoXProducto + saldoImporteAnual

                        canSaldoXproducto += CDec(i.cantidad)
                        ImporteSaldoXProducto += CDec((i.cantidad * pmAcumnulado))
                    End If
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    dr(10) = (FormatNumber(i.cantidad, 4))
                    dr(11) = (0)
                    dr(12) = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    dr(13) = (FormatNumber(canSaldoXproducto, 4))
                    dr(14) = (FormatNumber(ImporteSaldoXProducto, 4))
                    If canSaldoXproducto > 0 Then
                        precUnit = Math.Round(ImporteSaldoXProducto / canSaldoXproducto, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select
            dr(16) = i.idDocumento

            producto = i.idItem
            productoCache = i.nombreItem

            dt.Rows.Add(dr)
        Next
        dgvKardex2.DataSource = dt
        dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub


    Private Sub ListaMercaderiasXrangoFechas()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim canSaldo As Decimal = 0
        Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing

        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex - período " & txtPeriodo.Value.Month & "/" & txtPeriodo.Value.Year)
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
        dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        Dim str As String
        ImporteSaldo = 0
        canSaldo = 0
        For Each i As InventarioMovimiento In inventario.ObtenerKardexRangoFecha(txtAlmacenKardex.Tag, txtFechaDesde.Value, txtFechaHasta.Value)
            cantidadDeficit = 0
            importeDeficit = 0

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                dr(4) = i.marca
            Else
                dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad
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

                        '    ObtenerSaldoInicioXmes(cboAño.Text, 1, i.codigoProducto, dt)
                        canSaldo = canSaldo + 0 'saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + 0 'saldoImporteAnual
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If
                    dr(7) = (FormatNumber(i.cantidad, 4))
                    dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                    dr(9) = (FormatNumber(i.monto, 4))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit

                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += co
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0
                        '  ObtenerSaldoInicioXmes(cboAño.Text, 1, i.codigoProducto, dt)
                        canSaldo = canSaldo + 0 ' saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + 0 ' saldoImporteAnual

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    dr(10) = (FormatNumber(i.cantidad, 4))
                    dr(11) = (0)
                    dr(12) = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    dr(13) = (FormatNumber(canSaldo, 4))
                    dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select
            dr(16) = i.idDocumento

            producto = i.idItem
            productoCache = i.nombreItem

            dt.Rows.Add(dr)
        Next
        dgvKardex2.DataSource = dt
        dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Private Function getParentTableKardexPorPeriodoAll() As DataTable
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))


        Dim str As String
        Dim codItem As Integer = 0
        Dim cou As Integer = 0
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorMesAll(txtAlmacenKardex.Tag, AnioGeneral, MesGeneral)
            If cou = 0 Then
                If x = 0 Then
                    totalsaldo += i.monto
                    cantidadSaldo += i.cantidad
                    If (totalsaldo = 0) Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                Else
                    totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If

                End If
            Else
                If codItem = i.idItem Then
                    If x = 0 Then
                        totalsaldo += i.monto
                        cantidadSaldo += i.cantidad
                        If (totalsaldo = 0) Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If
                    Else
                        totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                        cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                        If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If

                    End If
                Else
                    cantidadSaldo = i.cantidad
                    totalsaldo = i.monto
                End If
            End If

            codItem = i.idItem

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                dr(4) = i.marca
            Else

                dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(7) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(8) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(8) = 0
                    End If

                    '(FormatNumber(i.precUnite, 2))
                    dr(9) = (FormatNumber(i.monto, 2))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    dr(10) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(11) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(11) = 0
                    End If
                    ' (FormatNumber(i.precUnite, 2))
                    dr(12) = (FormatNumber(i.monto, 2))
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
            End Select
            dr(16) = i.idDocumento
            dt.Rows.Add(dr)
            cou += 1
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorAnio() As DataTable
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - año " & AnioGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))


        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorAnio(txtAlmacenKardex.Tag, lstProductos.SelectedValue, AnioGeneral)
            If x = 0 Then
                totalsaldo += i.monto
                cantidadSaldo += i.cantidad
                If (totalsaldo = 0) Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If
            Else
                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If

            End If


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                dr(4) = i.marca
            Else

                dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(7) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(8) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(8) = 0
                    End If

                    '(FormatNumber(i.precUnite, 2))
                    dr(9) = (FormatNumber(i.monto, 2))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    dr(10) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(11) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(11) = 0
                    End If
                    ' (FormatNumber(i.precUnite, 2))
                    dr(12) = (FormatNumber(i.monto, 2))
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
            End Select
            dr(16) = i.idDocumento
            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorAnioAll() As DataTable
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - año " & AnioGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))


        Dim str As String
        Dim codItem As Integer = 0
        Dim cou As Integer = 0
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorAnioAll(txtAlmacenKardex.Tag, AnioGeneral)

            If cou = 0 Then
                If x = 0 Then
                    totalsaldo += i.monto
                    cantidadSaldo += i.cantidad
                    If (totalsaldo = 0) Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                Else
                    totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If

                End If
            Else
                If codItem = i.idItem Then
                    If x = 0 Then
                        totalsaldo += i.monto
                        cantidadSaldo += i.cantidad
                        If (totalsaldo = 0) Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If
                    Else
                        totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                        cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                        If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If

                    End If
                Else
                    totalsaldo = i.monto
                    cantidadSaldo = i.cantidad
                End If
            End If



            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            If i.marca Is Nothing Then
                dr(4) = i.marca
            Else

                dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad

            codItem = i.idItem
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(7) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(8) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(8) = 0
                    End If

                    '(FormatNumber(i.precUnite, 2))
                    dr(9) = (FormatNumber(i.monto, 2))
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    dr(10) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(11) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(11) = 0
                    End If
                    ' (FormatNumber(i.precUnite, 2))
                    dr(12) = (FormatNumber(i.monto, 2))
                    dr(13) = (FormatNumber(cantidadSaldo, 2))
                    dr(14) = (FormatNumber(totalsaldo, 2))
                    dr(15) = (FormatNumber(PrecioPromedio, 2))
            End Select
            dr(16) = i.idDocumento
            dt.Rows.Add(dr)
            cou += 1
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorDia() As DataTable
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0
        Dim tablaSA As New tablaDetalleSA

        Dim dt As New DataTable("kárdex - día " & DateTime.Now.Date & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))


        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenes(txtAlmacenKardex.Tag, lstProductos.SelectedValue)
            If x = 0 Then
                totalsaldo += i.monto
                cantidadSaldo += i.cantidad
                If (totalsaldo = 0) Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If
            Else
                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If

            End If


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = str
            dr(1) = i.destinoGravadoItem
            dr(2) = i.nombreItem
            If i.marca Is Nothing Then
                dr(3) = i.marca
            Else

                dr(3) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(4) = i.tipoProducto
            dr(5) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(6) = (FormatNumber(i.cantidad, 2))
                    dr(7) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2) ' (FormatNumber(i.precUnite, 2))
                    dr(8) = (FormatNumber(i.monto, 2))
                    dr(9) = ("0.00")
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(6) = ("0.00")
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = (FormatNumber(i.cantidad, 2))
                    dr(10) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2) ' (FormatNumber(i.precUnite, 2))
                    dr(11) = (FormatNumber(i.monto, 2))
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
            End Select

            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorDiaAll() As DataTable
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0
        Dim tablaSA As New tablaDetalleSA

        Dim dt As New DataTable("kárdex - día " & DateTime.Now.Date & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))

        Dim str As String
        Dim codItem As Integer = 0
        Dim cou As Integer = 0
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesXdiaAll(txtAlmacenKardex.Tag)
            If cou = 0 Then
                If x = 0 Then
                    totalsaldo += i.monto
                    cantidadSaldo += i.cantidad
                    If (totalsaldo = 0) Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                Else
                    totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If

                End If
            Else
                If codItem = i.idItem Then
                    If x = 0 Then
                        totalsaldo += i.monto
                        cantidadSaldo += i.cantidad
                        If (totalsaldo = 0) Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If
                    Else
                        totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                        cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                        If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If

                    End If
                Else
                    totalsaldo = i.monto
                    cantidadSaldo = i.cantidad
                End If
            End If
            codItem = i.idItem
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = str
            dr(1) = i.destinoGravadoItem
            dr(2) = i.nombreItem
            If i.marca Is Nothing Then
                dr(3) = i.marca
            Else

                dr(3) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            End If
            dr(4) = i.tipoProducto
            dr(5) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(6) = (FormatNumber(i.cantidad, 2))
                    dr(7) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2) ' (FormatNumber(i.precUnite, 2))
                    dr(8) = (FormatNumber(i.monto, 2))
                    dr(9) = ("0.00")
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(6) = ("0.00")
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = (FormatNumber(i.cantidad, 2))
                    dr(10) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2) ' (FormatNumber(i.precUnite, 2))
                    dr(11) = (FormatNumber(i.monto, 2))
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
            End Select

            dt.Rows.Add(dr)
        Next
        Return dt



    End Function



    'agre 






    'Public Sub ListaKardexPorMarca()
    '    Try
    '        Dim parentTable As DataTable = getParentTableKardexMarca()
    '        Me.dgvKardex2.DataSource = parentTable
    '        dgvKardex2.TableDescriptor.Relations.Clear()
    '        'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
    '        'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '        'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
    '        dgvKardex2.GroupDropPanel.Visible = True
    '        dgvKardex2.TableDescriptor.GroupedColumns.Clear()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'end agre



    Public Sub ListaKardexPorPeriodoMarca()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorPeriodoMarca()
            Me.dgvKardex2.DataSource = parentTable
            dgvKardex2.TableDescriptor.Relations.Clear()
            'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
            'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvKardex2.GroupDropPanel.Visible = True
            'dgvKardex2.TableDescriptor.GroupedColumns.Clear()

            dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.TableDescriptor.GroupedColumns.Clear()
            If dgvKardex2.Table.Records.Count > 0 Then
                page.Wire(dgvKardex2, parentTable)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub







    Public Sub ListaKardexPorPeriodo()
        Try

            Dim parentTable As DataTable = getParentTableKardexPorPeriodo()
            Me.dgvKardex2.DataSource = parentTable
            dgvKardex2.TableDescriptor.Relations.Clear()
            'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
            'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False

            dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.TableDescriptor.GroupedColumns.Clear()

            If dgvKardex2.Table.Records.Count > 0 Then
                page.Wire(dgvKardex2, parentTable)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Dim page = New Pager With {.PageSize = 10}
    Public Sub ListaKardexPorPeriodoAll()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorPeriodoAll()


            Me.dgvKardex2.DataSource = parentTable
            dgvKardex2.TableDescriptor.Relations.Clear()
            'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
            'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.TableDescriptor.GroupedColumns.Clear()
            If dgvKardex2.Table.Records.Count > 0 Then
                Dim page = New Pager With {.PageSize = 10}
                page.Wire(dgvKardex2, parentTable)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ListaKardexPorAnioMarca()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorAnioMarca()
            Me.dgvKardex2.DataSource = parentTable
            dgvKardex2.TableDescriptor.Relations.Clear()
            'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
            'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.TableDescriptor.GroupedColumns.Clear()
            If dgvKardex2.Table.Records.Count > 0 Then
                page.Wire(dgvKardex2, parentTable)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Sub ListaKardexPorAnio()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorAnio()
            Me.dgvKardex2.DataSource = parentTable
            dgvKardex2.TableDescriptor.Relations.Clear()
            'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
            'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.TableDescriptor.GroupedColumns.Clear()
            If dgvKardex2.Table.Records.Count > 0 Then
                page.Wire(dgvKardex2, parentTable)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaKardexPorAnioAll()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorAnioAll()
            Me.dgvKardex2.DataSource = parentTable
            dgvKardex2.TableDescriptor.Relations.Clear()
            'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
            'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.TableDescriptor.GroupedColumns.Clear()
            If dgvKardex2.Table.Records.Count > 0 Then
                page.Wire(dgvKardex2, parentTable)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ListaKardexPorDiaMarca()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorDiaMarca()
            Me.dgvKardex2.DataSource = parentTable
            'dgvKardex2.TableDescriptor.Relations.Clear()
            'dgvKardex2.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            'dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvKardex2.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvKardex2.GroupDropPanel.Visible = True
            'dgvKardex2.TableDescriptor.GroupedColumns.Clear()
            dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.TableDescriptor.GroupedColumns.Clear()
            If dgvKardex2.Table.Records.Count > 0 Then
                page.Wire(dgvKardex2, parentTable)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaKardexPorDia()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorDia()
            Me.dgvKardex2.DataSource = parentTable
            'dgvKardex2.TableDescriptor.Relations.Clear()
            'dgvKardex2.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            'dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
            '    dgvKardex2.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.TableDescriptor.GroupedColumns.Clear()
            If dgvKardex2.Table.Records.Count > 0 Then
                page.Wire(dgvKardex2, parentTable)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaKardexPorDiaAll()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorDiaAll()
            Me.dgvKardex2.DataSource = parentTable
            'dgvKardex2.TableDescriptor.Relations.Clear()
            'dgvKardex2.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            'dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvKardex2.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvKardex2.GroupDropPanel.Visible = True
            'dgvKardex2.TableDescriptor.GroupedColumns.Clear()

            '   page.Wire(dgvKardex2, parentTable)

            dgvKardex2.GroupDropPanel.Visible = True
            dgvKardex2.TableDescriptor.GroupedColumns.Clear()
            If dgvKardex2.Table.Records.Count > 0 Then
                page.Wire(dgvKardex2, parentTable)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "OTM"

    Public Sub EliminarTransferenciaAlmacen(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim objDestino As New totalesAlmacen
        Dim ListaOrigen As New List(Of totalesAlmacen)
        Dim ListaDestino As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        'For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
        '    If Not IsNothing(i.almacenRef) Then
        '        almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
        '        If Not IsNothing(almacen) Then
        '            If Not almacen.tipo = "AV" Then
        '                objNuevo = New totalesAlmacen
        '                objNuevo.SecuenciaDetalle = i.secuencia
        '                objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
        '                objNuevo.idEstablecimiento = almacen.idEstablecimiento
        '                objNuevo.idAlmacen = almacen.idAlmacen
        '                objNuevo.origenRecaudo = i.destino
        '                objNuevo.idItem = i.idItem
        '                objNuevo.TipoDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")

        '                objNuevo.importeSoles = i.importe
        '                objNuevo.importeDolares = i.importeUS

        '                objNuevo.cantidad = i.monto1
        '                objNuevo.precioUnitarioCompra = i.precioUnitario

        '                objNuevo.montoIsc = i.montoIsc
        '                objNuevo.montoIscUS = i.montoIscUS

        '                ListaOrigen.Add(objNuevo)
        '            End If
        '            almacen = almacenSA.GetUbicar_almacenPorID(i.almacenDestino)
        '            objDestino = New totalesAlmacen
        '            objDestino.SecuenciaDetalle = i.secuencia
        '            objDestino.idEmpresa = Gempresas.IdEmpresaRuc
        '            objDestino.idEstablecimiento = almacen.idEstablecimiento
        '            objDestino.idAlmacen = almacen.idAlmacen
        '            objDestino.origenRecaudo = i.destino
        '            objDestino.idItem = i.idItem
        '            objDestino.TipoDoc = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")

        '            objDestino.importeSoles = i.importe
        '            objDestino.importeDolares = i.importeUS

        '            objDestino.cantidad = i.monto1
        '            objDestino.precioUnitarioCompra = i.precioUnitario

        '            objDestino.montoIsc = i.montoIsc
        '            objDestino.montoIscUS = i.montoIscUS
        '            ListaDestino.Add(objDestino)
        '        End If

        '    End If

        'Next
        documentoSA.DeleteOtrasTransAlmacenOESL(objDocumento)
    End Sub

    Public Sub RemoveCompra(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvMov.Table.CurrentRecord.GetValue("tipoDoc")

                        objNuevo.importeSoles = i.importe
                        objNuevo.importeDolares = i.importeUS

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteOtrasEntradas(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarOtrasSalidas(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvMov.Table.CurrentRecord.GetValue("tipoDoc")

                        objNuevo.importeSoles = i.importe
                        objNuevo.importeDolares = i.importeUS

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteOtrasSalidasDeAlmacen(objDocumento, ListaTotales)
    End Sub

    Private Function getTableMovPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String) As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("destino", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarPorPeriodoEntradas(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strPeriodo, TIPO_COMPRA.OTRAS_ENTRADAS, StatusTipoConsulta.XUNIDAD_ORGANICA)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.destino
                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
                    dr(1) = "TRANSFERENCIA ENTRE ALMACENES"
                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
                    dr(1) = "ENTRADA DE EXISTENCIAS"
                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS
                    dr(1) = "SALIDA DE EXISTENCIAS"
            End Select

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Public Sub ListaEntradas(strPeriodo As String)
        Try

            Dim parentTable As DataTable = getTableMovPorPeriodo(GEstableciento.IdEstablecimiento, strPeriodo)
            Me.dgvMov.DataSource = parentTable
            dgvMov.TableDescriptor.Relations.Clear()
            dgvMov.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvMov.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvMov.Appearance.AnyRecordFieldCell.Enabled = False
            dgvMov.GroupDropPanel.Visible = True
            dgvMov.TableDescriptor.GroupedColumns.Clear()


            If dgvMov.Table.Records.Count > 0 Then
                page.Wire(dgvMov, parentTable)
            End If

            If dgvMov.Table.Records.Count > 0 Then
                dgvMov.Table.Records(0).SetCurrent()
                dgvMov.Table.Records(0).SetSelected(True)

                VerAsientosByDocumento(dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
            End If

            PanelError.Visible = True
            lblEstado.Text = "Lista de movimientos período: - " & PeriodoGeneral
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Métodos"
    Private Sub VerAsientosByDocumento(intIdDocumento As Integer)
        Dim movimientoSA As New MovimientoSA
        Dim movimiento As New List(Of movimiento)

        Dim dt As New DataTable()
        dt.Columns.Add("idAsiento")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("debe")
        dt.Columns.Add("haber")
        Dim codAsiento As Integer = 0
        Dim conteo As Integer = 0

        movimiento = movimientoSA.UbicarAsientoXidDocumento(intIdDocumento)

        Dim consulta = (From n In movimiento _
                       Where Not n.tipoAsiento = "ACCA").ToList

        For Each i In consulta

            If codAsiento = i.idAsiento Then
                Dim dr As DataRow = dt.NewRow
                dr(0) = i.idAsiento
                dr(1) = i.cuenta
                dr(2) = i.descripcion
                Select Case i.tipo
                    Case "D"
                        dr(3) = i.monto
                        dr(4) = 0.0
                    Case "H"
                        dr(3) = 0.0
                        dr(4) = i.monto
                End Select
                dt.Rows.Add(dr)
            Else
                conteo += 1

                Dim dr1 As DataRow = dt.NewRow
                dr1(0) = String.Empty
                dr1(1) = String.Empty
                dr1(2) = String.Empty
                dr1(3) = String.Empty
                dr1(4) = String.Empty
                dt.Rows.Add(dr1)

                Dim dr0 As DataRow = dt.NewRow
                dr0(0) = i.idAsiento
                dr0(1) = String.Empty
                dr0(2) = "Asiento N° " & conteo
                dr0(3) = String.Empty
                dr0(4) = String.Empty
                dt.Rows.Add(dr0)


                Dim dr As DataRow = dt.NewRow
                dr(0) = i.idAsiento
                dr(1) = i.cuenta
                dr(2) = i.descripcion
                Select Case i.tipo
                    Case "D"
                        dr(3) = i.monto
                        dr(4) = 0.0
                    Case "H"
                        dr(3) = 0.0
                        dr(4) = i.monto
                End Select
                dt.Rows.Add(dr)
            End If

            codAsiento = i.idAsiento
        Next
        dgvAsiento.DataSource = dt

    End Sub

    Private Function getParentTableTotalAlmacenValTodo() As DataTable
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))

        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductoPorAlmacenTipoExTodo(txtAlmacen2.Tag)
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Function getParentTableTotalAlmacenVal(strTipoExistencia As String, strNomProducto As String) As DataTable
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))

        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductoPorAlmacenTipoEx(txtAlmacen2.Tag, strTipoExistencia, strNomProducto)
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function



    Private Function getParentTableTotalAlmacenTodo() As DataTable
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))

        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductoPorAlmacenTipoExTodo(txtAlmacen.Tag)
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function



    Private Function getParentTableTotalAlmacen(strTipoExistencia As String, strNomProducto As String) As DataTable
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))

        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductoPorAlmacenTipoEx(txtAlmacen.Tag, strTipoExistencia, strNomProducto)
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function




    Public Sub BuscarProductoTodo()
        Dim parentTable As DataTable = getParentTableTotalAlmacenTodo()
        Me.dgvKardex.DataSource = parentTable
        dgvKardex.TableDescriptor.Relations.Clear()
        dgvKardex.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvKardex.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvKardex.Appearance.AnyRecordFieldCell.Enabled = False
        dgvKardex.GroupDropPanel.Visible = True
        dgvKardex.TableDescriptor.GroupedColumns.Clear()
        dgvKardex.TableDescriptor.GroupedColumns.Add("Clasificicacion")


        If dgvKardex.Table.Records.Count > 0 Then
            page.Wire(dgvKardex, parentTable)
        End If


        '    Me.dgvTotales.TableDescriptor.VisibleColumns.Remove("Clasificicacion")
    End Sub


    Public Sub BuscarProductoPorDescripcion()
        Dim parentTable As DataTable = getParentTableTotalAlmacen(cboTipoExistencia.SelectedValue, txtFiltro.Text.Trim)
        Me.dgvKardex.DataSource = parentTable
        dgvKardex.TableDescriptor.Relations.Clear()
        dgvKardex.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvKardex.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvKardex.Appearance.AnyRecordFieldCell.Enabled = False
        dgvKardex.GroupDropPanel.Visible = True
        dgvKardex.TableDescriptor.GroupedColumns.Clear()
        dgvKardex.TableDescriptor.GroupedColumns.Add("Clasificicacion")


        If dgvKardex.Table.Records.Count > 0 Then
            page.Wire(dgvKardex, parentTable)
        End If


        '    Me.dgvTotales.TableDescriptor.VisibleColumns.Remove("Clasificicacion")
    End Sub


    Public Sub BuscarProductoPorDescripcionValTodo()
        Dim parentTable As DataTable = getParentTableTotalAlmacenValTodo()
        Me.dgvKardexVal.DataSource = parentTable
        dgvKardexVal.TableDescriptor.Relations.Clear()
        dgvKardexVal.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvKardexVal.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvKardexVal.Appearance.AnyRecordFieldCell.Enabled = False
        dgvKardexVal.GroupDropPanel.Visible = True
        dgvKardexVal.TableDescriptor.GroupedColumns.Clear()
        dgvKardexVal.TableDescriptor.GroupedColumns.Add("Clasificicacion")


        If dgvKardexVal.Table.Records.Count > 0 Then
            page.Wire(dgvKardexVal, parentTable)
        End If


        '    Me.dgvTotales.TableDescriptor.VisibleColumns.Remove("Clasificicacion")
    End Sub


    Public Sub BuscarProductoPorDescripcionVal()
        Dim parentTable As DataTable = getParentTableTotalAlmacenVal(cboTipoExistencia2.SelectedValue, txtFiltro2.Text.Trim)
        Me.dgvKardexVal.DataSource = parentTable
        dgvKardexVal.TableDescriptor.Relations.Clear()
        dgvKardexVal.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvKardexVal.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvKardexVal.Appearance.AnyRecordFieldCell.Enabled = False
        dgvKardexVal.GroupDropPanel.Visible = True
        dgvKardexVal.TableDescriptor.GroupedColumns.Clear()
        dgvKardexVal.TableDescriptor.GroupedColumns.Add("Clasificicacion")


        If dgvKardexVal.Table.Records.Count > 0 Then
            page.Wire(dgvKardexVal, parentTable)
        End If


        '    Me.dgvTotales.TableDescriptor.VisibleColumns.Remove("Clasificicacion")
    End Sub


    Private Sub CargarAlmacenes()
        Dim almacenSA As New almacenSA
        Dim tablaSA As New tablaDetalleSA

        lstAlmacen.DisplayMember = "descripcionAlmacen"
        lstAlmacen.ValueMember = "idAlmacen"
        lstAlmacen.DataSource = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)

        lstAlmacen2.DisplayMember = "descripcionAlmacen"
        lstAlmacen2.ValueMember = "idAlmacen"
        lstAlmacen2.DataSource = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)


        lstAlmacenKardex.DisplayMember = "descripcionAlmacen"
        lstAlmacenKardex.ValueMember = "idAlmacen"
        lstAlmacenKardex.DataSource = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)

        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        cboTipoExistencia2.ValueMember = "codigoDetalle"
        cboTipoExistencia2.DisplayMember = "descripcion"
        cboTipoExistencia2.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        cboMarca.DisplayMember = "descripcion"
        cboMarca.ValueMember = "codigoDetalle"
        cboMarca.DataSource = tablaSA.GetListaTablaDetalle(503, "1")

        Dim eNtidad As New List(Of tabladetalle)
        Dim objENtidad As New tabladetalle With {.codigoDetalle = -1, .descripcion = "TODOS"}


        eNtidad = tablaSA.GetListaTablaDetalle(5, "1")
        eNtidad.Add(objENtidad)

        ComboBoxAdv1.ValueMember = "codigoDetalle"
        ComboBoxAdv1.DisplayMember = "descripcion"
        ComboBoxAdv1.DataSource = eNtidad
        'ComboBoxAdv1.ValueMember = "codigoDetalle"
        'ComboBoxAdv1.DisplayMember = "descripcion"
        'ComboBoxAdv1.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

    End Sub

    Private Sub LoadEstablecimientos()
        Dim estableSA As New establecimientoSA
        lstEstables.DisplayMember = "nombre"
        lstEstables.ValueMember = "idCentroCosto"
        lstEstables.DataSource = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
    End Sub

    Sub LoadTipoExistencia()
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)
        Dim lista As New List(Of String)
        lista.Add("PRODUCTO TERMINADO")
        'lista.Add("ENVASES Y EMBALAJES")
        'lista.Add("MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS")
        lista.Add("PRODUCTOS EN PROCESO")

        lista.Add("ACTIVO INMOVILIZADO")
        lista.Add("SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS")

        tabla = tablaSA.GetListaTablaDetalle(5, "1")

        Dim con = (From n In tabla _
                   Where Not lista.Contains(n.descripcion) _
                  Select n).ToList

        lstTipoExistencia.ValueMember = "codigoDetalle"
        lstTipoExistencia.DisplayMember = "descripcion"
        lstTipoExistencia.DataSource = con ' tablaSA.GetListaTablaDetalle(5, "1").Except(tabla)
    End Sub
#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Private Sub OptimizeGrid(gridGroupingControl As GridGroupingControl)
        ' Couple settings to perform better:
        gridGroupingControl.Engine.CounterLogic = EngineCounters.FilteredRecords
        gridGroupingControl.Engine.AllowedOptimizations = EngineOptimizations.DisableCounters Or EngineOptimizations.RecordsAsDisplayElements Or EngineOptimizations.VirtualMode
        gridGroupingControl.TableOptions.VerticalPixelScroll = False
        gridGroupingControl.Engine.TableOptions.ColumnsMaxLengthStrategy = GridColumnsMaxLengthStrategy.FirstNRecords
        gridGroupingControl.Engine.TableOptions.ColumnsMaxLengthFirstNRecords = 100
    End Sub


    Sub GridCFGKardexx(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = True
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub



    Sub GridCFGKardex(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0

    Public Sub ObtenerSaldoInicioXmes(intAnio As Integer, intMEs As Integer, intCodigoProducto As Integer, dt As DataTable)
        Dim cierreSA As New CierreInventarioSA
        Dim cierre As New cierreinventario

        cierre = cierreSA.RecuperarCierre(intAnio, intMEs, intCodigoProducto)

        If Not IsNothing(cierre) Then
            saldoCantidadAnual = cierre.cantidad
            saldoImporteAnual = cierre.importe
        Else
            saldoCantidadAnual = 0
            saldoImporteAnual = 0
        End If

        Dim dr As DataRow = dt.NewRow
        dr(0) = ""
        dr(1) = ""
        dr(2) = ""

        Select Case intMEs
            Case 1
                dr(3) = "Saldo: Mes-" & 12
            Case Else
                dr(3) = "Saldo: Mes-" & intMEs - 1
        End Select
        dr(4) = ""
        dr(5) = ""
        dr(6) = ""

        dr(7) = (0)
        dr(8) = (0)
        dr(9) = (0)

        dr(10) = (0)
        dr(11) = (0)
        dr(12) = (0)

        dr(13) = (saldoCantidadAnual)
        dr(14) = (saldoImporteAnual)

        If saldoCantidadAnual > 0 Then
            dr(15) = Math.Round(saldoImporteAnual / saldoCantidadAnual, 6)
            pmAcumnulado = Math.Round(saldoImporteAnual / saldoCantidadAnual, 6)
        Else
            dr(15) = 0
            pmAcumnulado = 0
        End If
        '      ImporteSaldo = saldoImporteAnual
        dt.Rows.Add(dr)

    End Sub


    Public Sub ObtenerSaldoInicioXmesDefault(intAnio As Integer, intMEs As Integer, intCodigoProducto As Integer)
        Dim cierreSA As New CierreInventarioSA
        Dim cierre As New cierreinventario

        cierre = cierreSA.RecuperarCierre(intAnio, intMEs, intCodigoProducto)

        If Not IsNothing(cierre) Then
            saldoCantidadAnual = cierre.cantidad
            saldoImporteAnual = cierre.importe
        Else
            saldoCantidadAnual = 0
            saldoImporteAnual = 0
        End If

        If saldoCantidadAnual > 0 Then
            pmAcumnulado = Math.Round(saldoImporteAnual / saldoCantidadAnual, 6)
        Else
            pmAcumnulado = 0
        End If

    End Sub

    Public Sub ListadoItemsEnTransito(strMes As String, strAnio As String, strTipoEx As String)
        Dim inventarioBL As New inventarioMovimientoSA
        Dim totalesBL As New TotalesAlmacenSA
        Dim dt As New DataTable()
        Dim str As String
        dt.Columns.Add("origen") ' 0
        dt.Columns.Add("tipoExistencia") ' 1
        dt.Columns.Add("idAlmacen") ' 2
        dt.Columns.Add("almacen") ' 3
        dt.Columns.Add("idDocumento") ' 4

        dt.Columns.Add("idProveedor") ' 5
        dt.Columns.Add("Razon") ' 6

        dt.Columns.Add("idItem") ' 7
        dt.Columns.Add("descripcion") ' 8
        dt.Columns.Add("cantidad") ' 9
        dt.Columns.Add("unidad") ' 10
        dt.Columns.Add("precUnit") '11
        dt.Columns.Add("importeMN") ' 12
        dt.Columns.Add("importeME") ' 13
        dt.Columns.Add("idInventario") ' 14
        dt.Columns.Add("cuenta") ' 15
        dt.Columns.Add("fechaCompra") ' 16

        dt.Columns.Add("comprobanteCompra") ' 17
        dt.Columns.Add("nroCompra") ' 18
        dt.Columns.Add("tipoCambio") ' 19
        dt.Columns.Add("precUnitME") ' 20
        dt.Columns.Add("origen2") ' 21
        dt.Columns.Add("docRef") ' 22
        dt.Columns.Add("evento") ' 23
        dt.Columns.Add("origen3") ' 24
        dt.Columns.Add("bonifica") ' 25
        dt.Columns.Add("empaque") ' 26
        dt.Columns.Add("fecVcto") ' 27
        dt.Columns.Add("proveedor") ' 28
        dt.Columns.Add("secCompra") ' 29
        dt.Columns.Add("tp") ' 29

        For Each i In inventarioBL.ObtenerProductosEnTransito(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "AV", strMes, strAnio, strTipoEx)
            Dim n As New ListViewItem(i.destinoGravadoItem)


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
            dr(0) = (i.destinoGravadoItem)
            dr(1) = (i.tipoProducto)
            dr(2) = (i.idAlmacen)
            dr(3) = ("ALM. VIRT") 'i.NombreAlmacen)
            dr(4) = (i.idDocumento)
            dr(5) = (i.IdProveedor)
            'dr(6) = (String.Concat(i.nombreProveedor, " | t/c: ", i.ComprobanteCompra, " | Nro: ", i.NumDocCompra))
            dr(6) = i.nombreProveedor
            dr(7) = (i.idItem)
            dr(8) = (String.Concat(i.descripcion, " - ", i.NombrePresentacion))
            dr(9) = (i.cantidad)
            dr(10) = (i.unidad)
            dr(11) = (FormatNumber(i.precUnite, 2))
            dr(12) = (FormatNumber(i.monto, 2))
            dr(13) = (FormatNumber(i.montoUSD, 2))
            dr(14) = (i.idInventario)
            dr(15) = (i.cuentaOrigen)
            dr(16) = (FormatDateTime(i.fecha, DateFormat.GeneralDate))

            dr(17) = (i.ComprobanteCompra)
            dr(18) = (i.NumDocCompra)
            dr(19) = (i.TipoCambio)
            dr(20) = (FormatNumber(i.precUniteUSD, 2))
            dr(21) = (i.destinoGravadoItem)
            dr(22) = (i.idDocumentoRef)
            dr(23) = (i.preEvento)
            dr(24) = ("INTERNO")
            dr(25) = (i.glosa)
            dr(26) = (i.presentacion)
            dr(27) = ""
            'If IsNothing(i.fechavcto) Then
            '    dr(0) = ("N")
            'Else
            '    dr(0) = (i.fechavcto)
            'End If
            dr(28) = (i.nombreProveedor)
            dr(29) = (i.Secuencia)
            dr(30) = (i.tipoRegistro)
            dt.Rows.Add(dr)
        Next
        dgvTransito.DataSource = dt
        dgvTransito.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended


    End Sub
#End Region

    Private Sub frmMasterGeneralInventario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMasterGeneralInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim s As New DateTime
        s = DateTime.Now
        Dim addDay As DateTime = s.AddDays(CInt(-30))
        txtFechafin.Value = DateTime.Now
        txtFechainicio.Value = addDay

        Me.PopupMenusManager1.SetXPContextMenu(Me.PictureBox1, Me.PopupMenu1)
        TabPageAdv1.Parent = TabControlAdv1
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv6.Parent = Nothing
        TabPageAdv7.Parent = Nothing
        TabPageAdv8.Parent = Nothing
        btUpdate.Visible = True
        btEdit.Visible = False
        btDelete.Visible = False


        txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)

        Me.dgvKardex2.ContextMenu = Me.ContextMenu1

    End Sub

    Private Sub contextMenuStrip_ItemClicked2(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvKardex2.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Visualizar documento de origen..." Then
                '   Me.dgvCompra.Table.CurrentRecord.Delete()
                Select Case Me.dgvKardex2.Table.CurrentRecord.GetValue("Movimiento")
                    Case "COMPRA", "OTRAS ENTRADAS A ALMACEN", "TRANSFERENCIA ENTRE ALMACENES", "OTRAS SALIDAS DE ALMACEN", "NC-DISMINUIR CANTIDAD", "NC-DISMINUIR IMPORTE", "NC-DISMINUIR CANTIDAD E IMPORTE", "NC-DEVOLUCION DE EXISTENCIAS"
                        Dim a As New frmInfoSourceAlmacen(Me.dgvKardex2.Table.CurrentRecord.GetValue("Movimiento"), Me.dgvKardex2.Table.CurrentRecord.GetValue("idDocumento"))
                        ' Me.dgvCompra.TableDescriptor.Columns("CompanyName").HeaderText = "Hello"
                        a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha operación"
                        a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Proveedor y/o trabajador"
                        a.StartPosition = FormStartPosition.CenterParent
                        a.ShowDialog()
                    Case "VENTA" ', "OTRAS SALIDAS DE ALMACEN"
                        Dim a As New frmInfoSourceAlmacen(Me.dgvKardex2.Table.CurrentRecord.GetValue("Movimiento"), Me.dgvKardex2.Table.CurrentRecord.GetValue("idDocumento"))
                        a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha venta"
                        a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Cliente"
                        a.StartPosition = FormStartPosition.CenterParent
                        a.ShowDialog()
                    Case "APORTES"
                        Dim a As New frmInfoSourceAlmacen(Me.dgvKardex2.Table.CurrentRecord.GetValue("Movimiento"), Me.dgvKardex2.Table.CurrentRecord.GetValue("idDocumento"))
                        a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha venta"
                        a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Trabajador"
                        a.StartPosition = FormStartPosition.CenterParent
                        a.ShowDialog()
                End Select


            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub contextMenuStrip_ItemClicked22(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvKardex.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Ver proveedores" Then
                '   Me.dgvCompra.Table.CurrentRecord.Delete()
                If (Not IsNothing(Me.dgvKardex.Table.CurrentRecord.GetValue("idItem"))) Then
                    With frmTotalAlmacenDetalle
                        .txtAlmacen.Text = txtAlmacen.Text
                        .txtExistencias.Text = Me.dgvKardex.Table.CurrentRecord.GetValue("descripcion")
                        .BuscarProductoPorDescripcion(Me.dgvKardex.Table.CurrentRecord.GetValue("idItem"))
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                End If


            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.dgvKardex2.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvKardex2.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvKardex2.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub gridGroupingControl2_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.dgvKardex.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvKardex.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvKardex.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub PopupControlContainer3_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer3.BeforePopup
        Me.PopupControlContainer3.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PopupControlContainer3_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles PopupControlContainer3.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstEstables.SelectedItems.Count > 0 Then
                Me.txtEstablecimiento.Tag = lstEstables.SelectedValue
                txtEstablecimiento.Text = lstEstables.Text
                '  ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtEstablecimiento.Focus()
        End If
    End Sub

    Private Sub PopupControlContainer3_Popup(sender As Object, e As EventArgs) Handles PopupControlContainer3.Popup
        lstEstables.Focus()
    End Sub

    Private Sub txtEstablecimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEstablecimiento.KeyDown
        If e.KeyCode = Keys.Down Then
            If Not Me.PopupControlContainer3.IsShowing() Then
                ' Let the popup align around the source textBox.
                PopupControlContainer3.Font = New Font("Segoe UI", 8)
                PopupControlContainer3.Size = New Size(264, 109)
                Me.PopupControlContainer3.ParentControl = Me.txtEstablecimiento
                Me.PopupControlContainer3.ShowPopup(Point.Empty)
                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer3.IsShowing() Then
                Me.PopupControlContainer3.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub PopupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer1.BeforePopup
        Me.PopupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub


    Private Sub PopupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstTipoExistencia.SelectedItems.Count > 0 Then
                Me.txtExistencia.Tag = lstTipoExistencia.SelectedValue
                txtExistencia.Text = lstTipoExistencia.Text


            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtExistencia.Focus()
        End If
    End Sub

    Private Sub txtEstablecimiento_TextChanged(sender As Object, e As EventArgs) Handles txtEstablecimiento.TextChanged

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        PopupControlContainer3.Font = New Font("Segoe UI", 8)
        PopupControlContainer3.Size = New Size(264, 109)
        Me.PopupControlContainer3.ParentControl = Me.txtEstablecimiento
        Me.PopupControlContainer3.ShowPopup(Point.Empty)
    End Sub

    Private Sub PopupControlContainer1_Popup(sender As Object, e As EventArgs) Handles PopupControlContainer1.Popup
        lstTipoExistencia.Focus()
    End Sub

    Private Sub txtExistencia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtExistencia.KeyDown
        If e.KeyCode = Keys.Down Then
            If Not Me.PopupControlContainer1.IsShowing() Then
                ' Let the popup align around the source textBox.
                PopupControlContainer1.Font = New Font("Segoe UI", 8)
                PopupControlContainer1.Size = New Size(256, 109)
                Me.PopupControlContainer1.ParentControl = Me.txtExistencia
                Me.PopupControlContainer1.ShowPopup(Point.Empty)
                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer1.IsShowing() Then
                Me.PopupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub dropDownBtn_Click(sender As Object, e As EventArgs) Handles dropDownBtn.Click
        PopupControlContainer1.Font = New Font("Segoe UI", 8)
        PopupControlContainer1.Size = New Size(256, 109)
        Me.PopupControlContainer1.ParentControl = Me.txtExistencia
        Me.PopupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Existencias en tránsito"
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv6.Parent = Nothing
                TabPageAdv7.Parent = Nothing
                TabPageAdv8.Parent = Nothing
                btEdit.Visible = False
                btDelete.Visible = False
                btUpdate.Visible = True


                ToolStripButton11.Visible = True
                ToolStripButton1.Visible = True
            Case "Inventario de existencias"


                dgvKardex.Table.Records.DeleteAll()

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv6.Parent = Nothing
                TabPageAdv7.Parent = Nothing
                TabPageAdv8.Parent = Nothing
                btEdit.Visible = False
                btDelete.Visible = False
                btUpdate.Visible = True

                ToolStripButton11.Visible = False
                ToolStripButton1.Visible = False

            Case "Inventario de existencias valorizado"

                dgvKardexVal.Table.Records.DeleteAll()

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = TabControlAdv1
                TabPageAdv6.Parent = Nothing
                TabPageAdv7.Parent = Nothing
                TabPageAdv8.Parent = Nothing
                btEdit.Visible = False
                btDelete.Visible = False
                btUpdate.Visible = True

                ToolStripButton11.Visible = False
                ToolStripButton1.Visible = False
            Case "Kardex general"
                GridCFGKardex(dgvKardex2)
                OptimizeGrid(dgvKardex2)

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = TabControlAdv1
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv6.Parent = Nothing
                TabPageAdv7.Parent = Nothing
                TabPageAdv8.Parent = Nothing
                btEdit.Visible = False
                btDelete.Visible = False
                btUpdate.Visible = True

                ToolStripButton11.Visible = False
                ToolStripButton1.Visible = False

            Case "Otros movimientos"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = TabControlAdv1
                TabPageAdv5.Parent = Nothing
                TabPageAdv6.Parent = Nothing
                TabPageAdv7.Parent = Nothing
                TabPageAdv8.Parent = Nothing
                btEdit.Visible = True
                btDelete.Visible = True
                btUpdate.Visible = True
                ToolStripButton11.Visible = False
                ToolStripButton1.Visible = False

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Existencias en tránsito"
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv6.Parent = Nothing
                TabPageAdv7.Parent = Nothing
                TabPageAdv8.Parent = Nothing
                btEdit.Visible = False
                btDelete.Visible = False
                btUpdate.Visible = True


                ToolStripButton11.Visible = True
                ToolStripButton1.Visible = True
            Case "Inventario de existencias"


                'dgvKardex.TableDescriptor.Relations.Clear()
                'dgvKardex.DataSource = Nothing
                dgvKardex.Table.Records.DeleteAll()

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv6.Parent = Nothing
                TabPageAdv7.Parent = Nothing
                TabPageAdv8.Parent = Nothing
                btEdit.Visible = False
                btDelete.Visible = False
                btUpdate.Visible = True

                ToolStripButton11.Visible = False
                ToolStripButton1.Visible = False

            Case "Inventario de existencias valorizado"
                'dgvKardexVal.DataSource = Nothing
                dgvKardexVal.Table.Records.DeleteAll()

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = TabControlAdv1
                TabPageAdv6.Parent = Nothing
                TabPageAdv7.Parent = Nothing
                TabPageAdv8.Parent = Nothing
                btEdit.Visible = False
                btDelete.Visible = False
                btUpdate.Visible = True

                ToolStripButton11.Visible = False
                ToolStripButton1.Visible = False
            Case "Kardex general"
                GridCFGKardex(dgvKardex2)
                OptimizeGrid(dgvKardex2)

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = TabControlAdv1
                TabPageAdv4.Parent = Nothing
                TabPageAdv5.Parent = Nothing
                TabPageAdv6.Parent = Nothing
                TabPageAdv7.Parent = Nothing
                TabPageAdv8.Parent = Nothing
                btEdit.Visible = False
                btDelete.Visible = False
                btUpdate.Visible = True

                ToolStripButton11.Visible = False
                ToolStripButton1.Visible = False

            Case "Otros movimientos"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = TabControlAdv1
                TabPageAdv5.Parent = Nothing
                TabPageAdv6.Parent = Nothing
                TabPageAdv7.Parent = Nothing
                TabPageAdv8.Parent = Nothing
                ListaEntradas(PeriodoGeneral)
                btEdit.Visible = True
                btDelete.Visible = True
                btUpdate.Visible = True
                ToolStripButton11.Visible = False
                ToolStripButton1.Visible = False

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.PopupControlContainer2.ParentControl = Me.btOperacion
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub lstTipoExistencia_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstTipoExistencia.MouseDoubleClick
        Me.PopupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lstTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTipoExistencia.SelectedIndexChanged

    End Sub

    Private Sub lstEstables_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstEstables.MouseDoubleClick
        Me.PopupControlContainer3.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lstEstables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEstables.SelectedIndexChanged

    End Sub
    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()
    Private Sub dgvTransito_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvTransito.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvTransito.TableControl.Selections.Clear()
        End If
    End Sub
    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub
    Private Sub dgvTransito_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvTransito.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvTransito)
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Existencias en tránsito"
                filter.ClearFilters(Me.dgvTransito)
                Me.dgvTransito.TopLevelGroupOptions.ShowFilterBar = False
            Case "Inventario de existencias"
                filter.ClearFilters(Me.dgvKardex)
                Me.dgvKardex.TopLevelGroupOptions.ShowFilterBar = False
            Case "Kardex general"
                filter.ClearFilters(Me.dgvKardex2)
                Me.dgvKardex2.TopLevelGroupOptions.ShowFilterBar = False
            Case "Otros movimientos"
                filter.ClearFilters(Me.dgvMov)
                Me.dgvMov.TopLevelGroupOptions.ShowFilterBar = False
        End Select


    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Existencias en tránsito"
                dgvTransito.TableDescriptor.GroupedColumns.Clear()
                If dgvTransito.ShowGroupDropArea = True Then
                    dgvTransito.ShowGroupDropArea = False
                Else
                    dgvTransito.ShowGroupDropArea = True
                End If
            Case "Inventario de existencias"
                dgvKardex.TableDescriptor.GroupedColumns.Clear()
                If dgvKardex.ShowGroupDropArea = True Then
                    dgvKardex.ShowGroupDropArea = False
                Else
                    dgvKardex.ShowGroupDropArea = True
                End If
            Case "Kardex general"
                dgvKardex2.TableDescriptor.GroupedColumns.Clear()
                If dgvKardex2.ShowGroupDropArea = True Then
                    dgvKardex2.ShowGroupDropArea = False
                Else
                    dgvKardex2.ShowGroupDropArea = True
                End If
            Case "Otros movimientos"
                dgvMov.TableDescriptor.GroupedColumns.Clear()
                If dgvMov.ShowGroupDropArea = True Then
                    dgvMov.ShowGroupDropArea = False
                Else
                    dgvMov.ShowGroupDropArea = True
                End If
        End Select


    End Sub
    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Existencias en tránsito"
                Me.dgvTransito.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvTransito.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvTransito.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvTransito.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
                'For Each col As GridColumnDescriptor In td.Columns
                '    col.AllowFilter = True
                'Next

                Me.dgvTransito.OptimizeFilterPerformance = True
                Me.dgvTransito.ShowNavigationBar = True

                filter.WireGrid(dgvTransito)
                'Me.dgvVentasTicket.TopLevelGroupOptions.ShowFilterBar = False

            Case "Inventario de existencias"
                Me.dgvKardex.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvKardex.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvKardex.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvKardex.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
                'For Each col As GridColumnDescriptor In td.Columns
                '    col.AllowFilter = True
                'Next

                Me.dgvKardex.OptimizeFilterPerformance = True
                Me.dgvKardex.ShowNavigationBar = True

                filter.WireGrid(dgvKardex)
                'Me.dgvVentasTicket.TopLevelGroupOptions.ShowFilterBar = False

            Case "Kardex general"
                Me.dgvKardex2.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvKardex2.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvKardex2.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvKardex2.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
                'For Each col As GridColumnDescriptor In td.Columns
                '    col.AllowFilter = True
                'Next

                Me.dgvKardex2.OptimizeFilterPerformance = True
                Me.dgvKardex2.ShowNavigationBar = True

                filter.WireGrid(dgvKardex2)
                'Me.dgvVentasTicket.TopLevelGroupOptions.ShowFilterBar = False

            Case "Otros movimientos"
                Me.dgvMov.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvMov.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvMov.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvMov.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
                'For Each col As GridColumnDescriptor In td.Columns
                '    col.AllowFilter = True
                'Next

                Me.dgvMov.OptimizeFilterPerformance = True
                Me.dgvMov.ShowNavigationBar = True

                filter.WireGrid(dgvMov)
        End Select


    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Me.dgvTransito.Table.SelectedRecords.Clear()
        Me.dgvTransito.Table.Records.SelectAll()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim itemsBL As New itemSA
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        With frmDistribucionMasiva
            .lblPerido.Text = PeriodoGeneral
            .cargarCombos("All")
            .StartPosition = FormStartPosition.CenterParent
            .dgvDistribucion.Rows.Clear()

            If dgvTransito.Table.SelectedRecords.Count > 0 Then
                If MessageBoxAdv.Show("Desea aprobar los productos seleccionados", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    For Each rec As SelectedRecord In dgvTransito.Table.SelectedRecords
                        .dgvDistribucion.Rows.Add(GEstableciento.IdEstablecimiento,
                                                  "",
                                                  GEstableciento.NombreEstablecimiento,
                                                  "",
                                                  rec.Record.GetValue("origen"),
                                                  rec.Record.GetValue("fechaCompra"),
                                                  "99",
                                                  "0",
                                                  "0",
                                                  "NACIONAL",
                                                  rec.Record.GetValue("idItem"),
                                                  rec.Record.GetValue("descripcion"),
                                                  rec.Record.GetValue("cantidad"),
                                                  rec.Record.GetValue("unidad"),
                                                  rec.Record.GetValue("tipoExistencia"),
                                                  rec.Record.GetValue("precUnit"),
                                                  rec.Record.GetValue("importeMN"),
                                                  rec.Record.GetValue("precUnitME"),
                                                  rec.Record.GetValue("importeME"),
                                                  "D",
                                                  rec.Record.GetValue("cuenta"),
                                                  rec.Record.GetValue("idDocumento"),
                                                  rec.Record.GetValue("idInventario"),
                                                  rec.Record.GetValue("idAlmacen"),
                                                  rec.Record.GetValue("evento"),
                                                  IIf(Mid(rec.Record.GetValue("bonifica"), 1, 1) = "B", "1", "0"),
                                                  rec.Record.GetValue("empaque"),
                                                  IIf(rec.Record.GetValue("fecVcto") = "N", Nothing, rec.Record.GetValue("fecVcto")),
                                                  rec.Record.GetValue("idProveedor"),
                                                  rec.Record.GetValue("Razon"),
                                                   rec.Record.GetValue("secCompra"),
                                                  itemsBL.GetUbicaCategoriaItem_Utilidad(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, rec.Record.GetValue("idItem")))

                        .contarMontos()
                    Next


                End If
            End If
            .ShowDialog()
        End With
        If datos.Count > 0 Then
            If datos(0).Estado = "Grabado" Then
                dgvTransito.Table.Records.DeleteAll()
            End If
        End If
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen.SelectedItems.Count > 0 Then
                Me.txtAlmacen.Tag = lstAlmacen.SelectedValue
                txtAlmacen.Text = lstAlmacen.Text
                '      ObtenerTotales(txtAlmacen.ValueMember)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacen.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        pcAlmacen.Font = New Font("Segoe UI", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtAlmacen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub
    '  Dim ContextMenuStrip2 = New ContextMenuStrip()
    Private Sub lstAlmacen_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAlmacen.MouseDoubleClick
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
        If (dgvKardex.TableModel.RowCount > 0) Then
            'ContextMenuStrip2 = New ContextMenuStrip()
            'ContextMenuStrip2.Items.Add("Ver proveedores")
            'AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
            'AddHandler Me.dgvKardex.TableControlMouseDown, AddressOf dgvTotales_TableControlMouseDown
        End If
    End Sub

    Private Sub dgvKardex_SaveValue(sender As Object, e As FieldValueEventArgs) Handles dgvKardex.SaveValue

    End Sub
    Private Sub dgvTotales_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs) Handles dgvKardex.TableControlMouseDown
        Dim row As Integer = 0, col As Integer = 0
        Me.dgvKardex.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvKardex.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvKardex.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cboTipoExistencia.SelectedIndex > -1 Then
            dgvKardex.Table.Records.DeleteAll()
            If Not txtAlmacen.Text.Trim.Length > 0 Then
                lblEstado.Text = "Debe elegir un almacén válido"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
            Else
                If txtFiltro.Text.Trim.Length > 0 Then
                    BuscarProductoPorDescripcion()
                Else
                    lblEstado.Text = "Debe escribir el nombre del producto a buscar"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)

                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Dim srtBusqueda As String
    Private Sub txtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyDown
        LoadingAnimator.Wire(Me.dgvTransito.TableControl)

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not txtAlmacen.Text.Trim.Length > 0 Then
                lblEstado.Text = "Debe elegir un almacén válido"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
            Else
                If txtFiltro.Text.Trim.Length > 0 Then
                    BuscarProductoPorDescripcion()
                    srtBusqueda = txtFiltro.Text
                Else
                    lblEstado.Text = "Debe escribir el nombre del producto a buscar"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)

                End If
            End If
        End If

        LoadingAnimator.UnWire(Me.dgvTransito.TableControl)
    End Sub

    Private Sub dgvKardex_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvKardex.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvKardex.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvKardex_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvKardex.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvKardex)
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub pcAlmacenKardex_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcAlmacenKardex.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacenKardex.SelectedItems.Count > 0 Then
                Me.txtAlmacenKardex.Tag = lstAlmacenKardex.SelectedValue
                txtAlmacenKardex.Text = lstAlmacenKardex.Text
                dgvKardex2.Table.Records.DeleteAll()
                '  ListadoItemsEnTransito(MesGeneral, AnioGeneral, txtExistencia.ValueMember)
                '       ObetnerListaProductosLST(txtAlmacen.ValueMember)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacenKardex.Focus()
        End If
    End Sub

    Private Sub pcAlmacenKardex_Popup(sender As Object, e As EventArgs) Handles pcAlmacenKardex.Popup
        lstAlmacenKardex.Focus()
    End Sub

    Private Sub ButtonAdv12_Click(sender As Object, e As EventArgs) Handles ButtonAdv12.Click
        pcAlmacenKardex.Font = New Font("Segoe UI", 8)
        pcAlmacenKardex.Size = New Size(260, 110)
        Me.pcAlmacenKardex.ParentControl = Me.txtAlmacenKardex
        Me.pcAlmacenKardex.ShowPopup(Point.Empty)
    End Sub
    Public Sub ObetnerListaProductosLSTPorItem(intIdAlmacen As Integer, strProducto As String, strTipoExistencia As String)
        Dim totalesSA As New TotalesAlmacenSA

        lstProductos.DisplayMember = "descripcion"
        lstProductos.ValueMember = "idItem"
        lstProductos.DataSource = totalesSA.GetProductoPorAlmacenTipoEx(intIdAlmacen, strTipoExistencia, strProducto)


        lblEstado.Text = "Productos encontrados: " & lstProductos.Items.Count
    End Sub


    Public Sub ObetnerListaProductosLSTPorExistencia(intIdAlmacen As Integer, strTipoExistencia As String)
        Dim totalesSA As New TotalesAlmacenSA

        lstProductos.DisplayMember = "descripcion"
        lstProductos.ValueMember = "idItem"
        lstProductos.DataSource = totalesSA.GetProductoPorTipoExistencia(intIdAlmacen, strTipoExistencia)


        lblEstado.Text = "Productos encontrados: " & lstProductos.Items.Count
    End Sub


    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If txtAlmacenKardex.Text.Trim.Length > 0 Then
                    pcProductos.Font = New Font("Segoe UI", 8)
                    Me.pcProductos.ParentControl = Me.txtBuscarProducto
                    Me.pcProductos.ShowPopup(Point.Empty)
                    ObetnerListaProductosLSTPorItem(txtAlmacenKardex.Tag, txtBuscarProducto.Text.Trim, ComboBoxAdv1.SelectedValue)
                    Me.Cursor = Cursors.Arrow
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged

    End Sub

    Private Sub ComboBoxAdv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv1.SelectedIndexChanged
        'Me.Cursor = Cursors.WaitCursor
        'dgvKardex2.Table.Records.DeleteAll()
        'If txtAlmacenKardex.Text.Trim.Length > 0 Then
        '    If Label10.Visible = True Then
        '        pcProductos.Font = New Font("Segoe UI", 8)
        '        Me.pcProductos.ParentControl = Me.txtBuscarProducto
        '        Me.pcProductos.ShowPopup(Point.Empty)
        '        ObetnerListaProductosLSTPorItem(txtAlmacenKardex.Tag, txtBuscarProducto.Text.Trim, ComboBoxAdv1.SelectedValue)
        '        ' Me.Cursor = Cursors.Arrow


        '        'ElseIf Label6.Visible = True Then

        '        '    If txtAlmacenKardex.Text.Trim.Length > 0 Then
        '        '        If ComboBoxAdv1.Text.Trim.Length > 0 Then
        '        '            If cboMarca.Text.Trim.Length > 0 Then
        '        '                ListaKardexPorMarca()
        '        '            Else
        '        '                lblEstado.Text = "Elija una marca"
        '        '                PanelError.Visible = True
        '        '                Timer1.Enabled = True
        '        '                TiempoEjecutar(10)
        '        '            End If
        '        '        End If
        '        '    End If
        '    End If
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstAlmacenKardex_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAlmacenKardex.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If lstAlmacenKardex.SelectedItems.Count > 0 Then
            Me.pcAlmacenKardex.HidePopup(PopupCloseType.Done)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbAnio_CheckChanged(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
        '    If txtAlmacenKardex.Text.Trim.Length > 0 Then
        '        dgvKardex2.Table.Records.DeleteAll()
        '        If rbAnio.Checked = True Then
        '            If Label10.Visible = True Then
        '                If lstProductos.SelectedItems.Count > 0 Then
        '                    Dim statusForm As New FeedbackForm()
        '                    statusForm.Tag = "CEX"
        '                    statusForm.Show("PROCESANDO ITEMS...!")
        '                    '    ObtenerProducto(lstProductos.SelectedValue)
        '                    ListaKardexPorAnio()
        '            End If

        '        ElseIf Label6.Visible = True Then
        '            If cboMarca.Text.Trim.Length > 0 Then
        '                Dim statusForm As New FeedbackForm()
        '                statusForm.Tag = "CEX"
        '                statusForm.Show("PROCESANDO ITEMS...!")
        '                If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
        '                    ListaKardexPorAnioMarca()
        '                End If
        '            End If

        '        End If
        '    End If
        'End If

        'ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
        '    ListaKardexPorAnioAll()
        'End If

        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbPeriodo_CheckChanged(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
        '    If txtAlmacenKardex.Text.Trim.Length > 0 Then
        '        dgvKardex2.Table.Records.DeleteAll()
        '        If rbPeriodo.Checked = True Then
        '            If Label10.Visible = True Then
        '                Dim statusForm As New FeedbackForm()
        '                statusForm.Tag = "CEX"
        '                statusForm.Show("PROCESANDO ITEMS...!")

        '                If lstProductos.SelectedItems.Count > 0 Then
        '                    '    ObtenerProducto(lstProductos.SelectedValue)
        '                    ListaKardexPorPeriodo()
        '                    '  LoadKardexProductosPorMes(txtAlmacen.ValueMember, lstProductos.SelectedValue, AnioGeneral, MesGeneral)
        '                End If

        '        ElseIf Label6.Visible = True Then
        '            If cboMarca.Text.Trim.Length > 0 Then
        '                Dim statusForm As New FeedbackForm()
        '                statusForm.Tag = "CEX"
        '                statusForm.Show("PROCESANDO ITEMS...!")
        '                If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
        '                    ListaKardexPorPeriodoMarca()
        '                End If
        '            End If

        '        End If
        '    End If
        '    End If

        'ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
        '    ListaKardexPorPeriodoAll()
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbDia_CheckChanged(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor

        'If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
        '    If txtAlmacenKardex.Text.Trim.Length > 0 Then
        '        dgvKardex2.Table.Records.DeleteAll()
        '        If rbDia.Checked = True Then
        '            If Label10.Visible = True Then
        '                If lstProductos.SelectedItems.Count > 0 Then
        '                    Dim statusForm As New FeedbackForm()
        '                    statusForm.Tag = "CEX"
        '                    statusForm.Show("PROCESANDO ITEMS...!")
        '                    '   ObtenerProducto(lstProductos.SelectedValue)
        '                    ListaKardexPorDia()
        '                End If

        '            ElseIf Label6.Visible = True Then
        '                If cboMarca.Text.Trim.Length > 0 Then
        '                    Dim statusForm As New FeedbackForm()
        '                    statusForm.Tag = "CEX"
        '                    statusForm.Show("PROCESANDO ITEMS...!")
        '                    If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
        '                        ListaKardexPorDiaMarca()
        '                    End If
        '                End If

        '            End If
        '        End If


        '    End If

        'ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
        'If rbDia.Checked = True Then
        '    Dim statusForm As New FeedbackForm()
        '    statusForm.Tag = "CEX"
        '    statusForm.Show("PROCESANDO ITEMS...!")
        '    ListaKardexPorDiaAll()
        '    End If
        'End If

        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pcProductos_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcProductos.BeforePopup

    End Sub

    Private Sub pcProductos_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProductos.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstProductos.SelectedItems.Count > 0 Then
                If txtAlmacenKardex.Text.Trim.Length > 0 Then
                    txtBuscarProducto.Text = lstProductos.Text
                    txtBuscarProducto.Tag = lstProductos.SelectedValue
                    'If rbPeriodo.Checked = True Then
                    '    If lstProductos.SelectedItems.Count > 0 Then
                    '        '    ObtenerProducto(lstProductos.SelectedValue)
                    '        ' LoadKardexProductosPorMes(txtAlmacen.ValueMember, lstProductos.SelectedValue, AnioGeneral, MesGeneral)
                    '        ListaKardexPorPeriodo()
                    '    End If
                    'ElseIf rbDia.Checked = True Then
                    '    '     ObtenerProducto(lstProductos.SelectedValue)
                    '    ListaKardexPorDia()
                    '    '   LoadKardexProductos(txtAlmacen.ValueMember, lstProductos.SelectedValue)
                    'ElseIf rbAnio.Checked = True Then
                    '    ListaKardexPorAnio()
                    'End If
                End If
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtBuscarProducto.Focus()
        End If
    End Sub

    Private Sub pcProductos_Popup(sender As Object, e As EventArgs) Handles pcProductos.Popup
        lstProductos.Focus()
    End Sub

    Private Sub lstProductos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstProductos.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If lstProductos.SelectedItems.Count > 0 Then
            Me.pcProductos.HidePopup(PopupCloseType.Done)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvKardex2_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvKardex2.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvKardex2.TableControl.Selections.Clear()
        End If

        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            'Checks for the column name when the cellvalue is greater than 5.
            'ENTRADAS A ALMACEN
            If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.FromArgb(225, 240, 190)
            End If
            If e.TableCellIdentity.Column.MappingName = "monto" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.FromArgb(225, 240, 190)
            End If


            'SALIDAS A ALMACEN
            If e.TableCellIdentity.Column.MappingName = "cantidad1" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.FromArgb(255, 192, 192) '
            End If
            If e.TableCellIdentity.Column.MappingName = "monto1" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                e.Style.BackColor = Color.FromArgb(255, 192, 192)
            End If

        End If

    End Sub

    Private Sub dgvKardex2_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvKardex2.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvKardex2)
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            Select Case ListBox1.Text
                Case "Transferencia entre almacenes"

                    With frmMovimientoAlmacen
                        .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                        '  .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        .lblPerido.Text = PeriodoGeneral
                        '.cambioMovimiento()
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

                Case "Otras entradas a almcén"
                    With frmMovOtrasEntradas
                        .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                        '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        .lblPerido.Text = PeriodoGeneral
                        '     .cambioMovimiento()
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

                Case "Otras sálidas de almacén"
                    With frmOtrasSalidasDeAlmacen
                        '    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                        '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        .lblPerido.Text = PeriodoGeneral
                        '     .cambioMovimiento()
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

            End Select
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.btOperacion.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If ListBox1.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btUpdate_Click(sender As Object, e As EventArgs) Handles btUpdate.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Existencias en tránsito"

                If txtExistencia.Text.Trim.Length > 0 Then
                    If lstTipoExistencia.SelectedItems.Count > 0 Then
                        'Me.txtExistencia.ValueMember = lstTipoExistencia.SelectedValue
                        'txtExistencia.Text = lstTipoExistencia.Text
                        ListadoItemsEnTransito(MesGeneral, AnioGeneral, txtExistencia.Tag)
                        TabPageAdv1.Parent = TabControlAdv1
                        TabPageAdv2.Parent = Nothing
                        TabPageAdv3.Parent = Nothing
                        TabPageAdv4.Parent = Nothing
                        btEdit.Visible = False
                        btDelete.Visible = False
                        btUpdate.Visible = True


                        ToolStripButton11.Visible = True
                        ToolStripButton1.Visible = True
                    Else
                        lblEstado.Text = "Debe elegir una existencia"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(5)

                    End If
                Else
                    lblEstado.Text = "Debe elegir una existencia"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                End If
            Case "Inventario de existencias"
                If Not txtAlmacen.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Debe elegir un almacén válido"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                Else
                    If txtFiltro.Text.Trim.Length > 0 Then

                        BuscarProductoPorDescripcion()
                        TabPageAdv1.Parent = Nothing
                        TabPageAdv2.Parent = TabControlAdv1
                        TabPageAdv3.Parent = Nothing
                        TabPageAdv4.Parent = Nothing
                        btEdit.Visible = False
                        btDelete.Visible = False
                        btUpdate.Visible = True
                        ToolStripButton11.Visible = False
                        ToolStripButton1.Visible = False
                        srtBusqueda = txtFiltro.Text
                    Else
                        lblEstado.Text = "Debe escribir el nombre del producto a buscar"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(5)

                    End If
                End If

            Case "Kardex general"

                'If txtAlmacenKardex.Text.Trim.Length > 0 Then
                '    If rbPeriodo.Checked = True Then
                '        Dim statusForm As New FeedbackForm()
                '        statusForm.Tag = "CEX"
                '        statusForm.Show("PROCESANDO ITEMS...!")
                '        If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
                '            If lstProductos.SelectedItems.Count > 0 Then
                '                If Label10.Visible = True Then
                '                    ListaKardexPorPeriodo()
                '                End If
                '            End If
                '        ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
                '            ListaKardexPorPeriodoAll()
                '        End If

                '    ElseIf rbDia.Checked = True Then
                '        '    ObtenerProducto(lstProductos.SelectedValue)
                '        Dim statusForm As New FeedbackForm()
                '        statusForm.Tag = "CEX"
                '        statusForm.Show("PROCESANDO ITEMS...!")
                '        If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
                '            If Label10.Visible = True Then
                '                ListaKardexPorDia()
                '            End If
                '        ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
                '            ListaKardexPorDiaAll()
                '        End If

                '        '   LoadKardexProductos(txtAlmacen.ValueMember, lstProductos.SelectedValue)
                '        ElseIf rbAnio.Checked = True Then
                '            Dim statusForm As New FeedbackForm()
                '            statusForm.Tag = "CEX"
                '            statusForm.Show("PROCESANDO ITEMS...!")
                '            If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
                '            If Label10.Visible = True Then
                '                ListaKardexPorAnio()
                '            End If
                '        ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then

                '            ListaKardexPorAnioAll()
                '        End If

                '        End If

                'Else
                '    lblEstado.Text = "Debe elegir un almacén válido"
                '    PanelError.Visible = True
                '    Timer1.Enabled = True
                '    TiempoEjecutar(5)
                'End If

            Case "Otros movimientos"

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = TabControlAdv1
                ListaEntradas(PeriodoGeneral)
                btEdit.Visible = True
                btDelete.Visible = True
                btUpdate.Visible = True
                ToolStripButton11.Visible = False
                ToolStripButton1.Visible = False


        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvMov_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvMov.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvMov.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick
        If Not IsNothing(dgvMov.Table.CurrentRecord) Then
            VerAsientosByDocumento(dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
        End If
    End Sub

    Private Sub dgvMov_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvMov.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvMov)
    End Sub

    Private Sub btEdit_Click(sender As Object, e As EventArgs) Handles btEdit.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Existencias en tránsito"

            Case "Inventario de existencias"

            Case "Kardex general"

            Case "Otros movimientos"
                If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                    If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "TRANSFERENCIA ENTRE ALMACENES" Then ' TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES Then
                        With frmMovimientoAlmacen
                            .btGrabar.Enabled = False
                            .ToolStripButton1.Enabled = False
                            .GuardarToolStripButton.Enabled = False
                            .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .ShowDialog()
                        End With '
                    ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "ENTRADA DE EXISTENCIAS" Then
                        With frmMovOtrasEntradas
                            .btGrabar.Enabled = False
                            .GuardarToolStripButton.Enabled = True
                            .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With
                    ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "SALIDA DE EXISTENCIAS" Then
                        With frmOtrasSalidasDeAlmacen
                            .btGrabar.Enabled = False
                            .GuardarToolStripButton.Enabled = True
                            .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With
                    End If

                End If

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Existencias en tránsito"

            Case "Inventario de existencias"

            Case "Kardex general"

            Case "Otros movimientos"
                If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                    If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "TRANSFERENCIA ENTRE ALMACENES" Then
                        If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            EliminarTransferenciaAlmacen(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                            Me.dgvMov.Table.CurrentRecord.Delete()
                            PanelError.Visible = True
                            lblEstado.Text = "entrada eliminada!"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If
                    ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "ENTRADA DE EXISTENCIAS" Then
                        If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            RemoveCompra(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                            Me.dgvMov.Table.CurrentRecord.Delete()
                            PanelError.Visible = True
                            lblEstado.Text = "entrada eliminada!"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If
                    ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "SALIDA DE EXISTENCIAS" Then
                        If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            EliminarOtrasSalidas(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                            Me.dgvMov.Table.CurrentRecord.Delete()
                            PanelError.Visible = True
                            lblEstado.Text = "Registro eliminado!"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If
                    End If

                End If

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub PanelError_Paint(sender As Object, e As PaintEventArgs) Handles PanelError.Paint

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseClick
        Me.PopupMenu1.Show(CType(sender, Control), New Point(e.X, e.Y))
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv1.Click

    End Sub

    Private Sub BarItem1_DoubleClick(sender As Object, e As EventArgs) Handles BarItem1.DoubleClick

    End Sub

    Private Sub BarItem1_Click(sender As Object, e As EventArgs) Handles BarItem1.Click

        If txtBuscarProducto.Visible = True Then

            txtBuscarProducto.Visible = False

            '   Label6.Visible = False
            cboMarca.Visible = False


            Label12.Visible = False
            ComboBoxAdv1.Visible = False

        Else
            txtBuscarProducto.Visible = True

            '   Label6.Visible = False
            cboMarca.Visible = False


            Label12.Visible = True
            ComboBoxAdv1.Visible = True
        End If

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

    End Sub

    Private Sub lstProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProductos.SelectedIndexChanged

    End Sub

    Private Sub BarItem2_Click(sender As Object, e As EventArgs) Handles BarItem2.Click


        '      Label10.Visible = False
        txtBuscarProducto.Visible = False

        '     Label6.Visible = True
        cboMarca.Visible = True

        Label12.Visible = False
        ComboBoxAdv1.Visible = False


    End Sub

    Private Sub cboMarca_Click(sender As Object, e As EventArgs) Handles cboMarca.Click

    End Sub

    Private Sub cboMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMarca.SelectedIndexChanged
        'If txtAlmacenKardex.Text.Trim.Length > 0 Then
        '    If ComboBoxAdv1.Text.Trim.Length > 0 Then
        '        If cboMarca.Text.Trim.Length > 0 Then
        '            ListaKardexPorMarca()
        '        Else
        '            lblEstado.Text = "Elija una marca"
        '            PanelError.Visible = True
        '            Timer1.Enabled = True
        '            TiempoEjecutar(10)
        '        End If
        '    End If
        'Else
        '    lblEstado.Text = "Seleccione un almacen"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub txtAlmacenKardex_TextChanged(sender As Object, e As EventArgs) Handles txtAlmacenKardex.TextChanged

    End Sub

    Private Sub tbIGV_Click(sender As Object, e As EventArgs) Handles tbIGV.Click


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub
    Sub ConsultasKardex()
        Select Case cboConsulta.Text
            Case "POR PERIODO"

                If txtBuscarProducto.Visible = True Then
                    ListaMercaderiasXperiodoXproducto()
                Else

                    If ComboBoxAdv1.Text = "TODOS" Then
                        ListaMercaderiasXperiodoTodosProductosTodo()
                    Else
                        ListaMercaderiasXperiodoTodosProductos()
                    End If

                End If
            Case "RANGO DE FECHA"
                If txtBuscarProducto.Visible = True Then
                    ListaXproductoRangoFechas()
                Else
                    ListaMercaderiasXrangoFechas()
                End If
        End Select
    End Sub
    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        '  Me.Cursor = Cursors.WaitCursor
        LoadingAnimator.Wire(Me.dgvKardex2.TableControl)


        If txtAlmacenKardex.Text.Trim.Length > 0 Then
            ConsultasKardex()

        Else
            PanelError.Visible = True
            lblEstado.Text = "Elija un alamacen"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If


        'If txtAlmacenKardex.Text.Trim.Length > 0 Then
        '    If rbPeriodo.Checked = True Then
        '        Dim statusForm As New FeedbackForm()
        '        statusForm.Tag = "CEX"
        '        statusForm.Show("PROCESANDO ITEMS...!")
        '        If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
        '            If Label10.Visible = True Then
        '                If lstProductos.SelectedItems.Count > 0 Then
        '                    '   ListaMercaderiasXperiodo()
        '                Else
        '                    lblEstado.Text = "Seleccione un producto"
        '                    PanelError.Visible = True
        '                    Timer1.Enabled = True
        '                    TiempoEjecutar(5)
        '                End If
        '            ElseIf Label6.Visible = True Then
        '                If cboMarca.Text.Trim.Length > 0 Then
        '                    ListaKardexPorPeriodoMarca()
        '                Else
        '                    lblEstado.Text = "Seleccione una marca"
        '                    PanelError.Visible = True
        '                    Timer1.Enabled = True
        '                    TiempoEjecutar(5)
        '                End If

        '            End If
        '        ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
        '            ListaMercaderiasXperiodoTodosProductos()
        '        End If
        '    ElseIf rbDia.Checked = True Then
        '        '    ObtenerProducto(lstProductos.SelectedValue)
        '        Dim statusForm As New FeedbackForm()
        '        statusForm.Tag = "CEX"
        '        statusForm.Show("PROCESANDO ITEMS...!")
        '        If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
        '            If Label10.Visible = True Then
        '                If lstProductos.SelectedItems.Count > 0 Then
        '                    ListaKardexPorDia()
        '                Else
        '                    lblEstado.Text = "Seleccione un producto"
        '                    PanelError.Visible = True
        '                    Timer1.Enabled = True
        '                    TiempoEjecutar(5)
        '                End If
        '            ElseIf Label6.Visible = True Then
        '                If cboMarca.Text.Trim.Length > 0 Then
        '                    ListaKardexPorDiaMarca()
        '                Else
        '                    lblEstado.Text = "Seleccione una marca"
        '                    PanelError.Visible = True
        '                    Timer1.Enabled = True
        '                    TiempoEjecutar(5)
        '                End If

        '            End If
        '        ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
        '            ListaKardexPorDiaAll()
        '        End If
        '        '   LoadKardexProductos(txtAlmacen.ValueMember, lstProductos.SelectedValue)
        '    ElseIf rbAnio.Checked = True Then
        '        Dim statusForm As New FeedbackForm()
        '        statusForm.Tag = "CEX"
        '        statusForm.Show("PROCESANDO ITEMS...!")
        '        If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
        '            If Label10.Visible = True Then
        '                If lstProductos.SelectedItems.Count > 0 Then
        '                    ListaKardexPorAnio()
        '                Else
        '                    lblEstado.Text = "Seleccione un producto"
        '                    PanelError.Visible = True
        '                    Timer1.Enabled = True
        '                    TiempoEjecutar(5)
        '                End If
        '            ElseIf Label6.Visible = True Then
        '                If cboMarca.Text.Trim.Length > 0 Then
        '                    ListaKardexPorAnioMarca()
        '                Else
        '                    lblEstado.Text = "Seleccione una marca"
        '                    PanelError.Visible = True
        '                    Timer1.Enabled = True
        '                    TiempoEjecutar(5)
        '                End If
        '            End If
        '        ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then

        '            ListaKardexPorAnioAll()
        '        End If
        '    End If
        'Else
        '    lblEstado.Text = "Debe elegir un almacén válido"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(5)
        'End If

        LoadingAnimator.UnWire(Me.dgvKardex2.TableControl)
        'Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
        tbIGV.Renderer = styleRenderer1
        'Dim styleRenderer2 As New StyledRenderer()
        'tbIGV.Renderer = styleRenderer2
        'Dim styleRenderer3 As New StyledRenderer()
        'toggleButton11.Renderer = styleRenderer3
        'Dim styleRenderer4 As New StyledRenderer()
        'toggleButton12.Renderer = styleRenderer4
        ' Panel2.Visible = False
    End Sub
    Private Sub tbIGV_ToggleStateChanged(sender As Object, e As Tools.ToggleStateChangedEventArgs) Handles tbIGV.ToggleStateChanged

        If e.ToggleState = Tools.ToggleButtonState.Active Then

            dgvKardex2.Table.Records.DeleteAll()
            PictureBox2.Visible = True

            '    Label10.Visible = True
            txtBuscarProducto.Visible = True
            Label12.Visible = True
            ComboBoxAdv1.Visible = True
        Else
            dgvKardex2.Table.Records.DeleteAll()
            '     Label10.Visible = False
            txtBuscarProducto.Visible = False

            '      Label6.Visible = False
            cboMarca.Visible = False

            PictureBox2.Visible = False


            Label12.Visible = False
            ComboBoxAdv1.Visible = False
        End If

    End Sub

    Private Sub cboTipoExistencia_Click(sender As Object, e As EventArgs) Handles cboTipoExistencia.Click

    End Sub

    Private Sub txtExistencia_TextChanged(sender As Object, e As EventArgs) Handles txtExistencia.TextChanged

    End Sub

    Private Sub dgvKardex2_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardex2.TableControlCellClick

    End Sub

    Private Sub dgvKardex_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardex.TableControlCellClick

    End Sub

    Private Sub dgvTransito_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvTransito.TableControlCellClick

    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click

        If txtAlmacen.Text.Trim.Length > 0 Then
            Dim a As New frmInfoSourceProductos(txtAlmacen.Tag)
            'a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha operación"
            'a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Proveedor y/o trabajador"
            a.StartPosition = FormStartPosition.CenterParent
            a.ShowDialog()
        Else
            lblEstado.Text = "Debe elegir un almacen"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        LoadingAnimator.Wire(Me.dgvTransito.TableControl)
        ListadoItemsEnTransito(MesGeneral, AnioGeneral, txtExistencia.Tag)
        LoadingAnimator.UnWire(Me.dgvTransito.TableControl)
    End Sub

    Private Sub cboConsulta_Click(sender As Object, e As EventArgs) Handles cboConsulta.Click

    End Sub

    Private Sub cboConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConsulta.SelectedIndexChanged
        If cboConsulta.Text = "POR PERIODO" Then
            txtPeriodo.Visible = True
            txtFechaDesde.Visible = False
            txtFechaHasta.Visible = False
            Label6.Visible = False
        ElseIf cboConsulta.Text = "RANGO DE FECHA" Then
            txtPeriodo.Visible = False
            txtFechaDesde.Visible = True
            txtFechaHasta.Visible = True
            Label6.Visible = True
        End If
    End Sub

    Private Sub dgvKardex_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvKardex.TableControlCurrentCellEditingComplete


    End Sub

    Private Sub ButtonAdv16_Click(sender As Object, e As EventArgs) Handles ButtonAdv16.Click

        If Not IsNothing(Me.dgvKardex.Table.CurrentRecord) Then

            Me.Cursor = Cursors.WaitCursor
            Dim f As New frmCantidades

            f.txtcantmax.Text = Me.dgvKardex.Table.CurrentRecord.GetValue("cantmax")
            f.txtcantmin.Text = Me.dgvKardex.Table.CurrentRecord.GetValue("cantmin")
            f.txtidmovimiento.Text = Me.dgvKardex.Table.CurrentRecord.GetValue("idmovimiento")
            f.txtiditem.Text = Me.dgvKardex.Table.CurrentRecord.GetValue("idItem")
            f.txtdescripcion.Text = Me.dgvKardex.Table.CurrentRecord.GetValue("descripcion")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            If txtFiltro.Text.Trim.Length > 0 Then
                If txtAlmacen.Text.Trim.Length > 0 Then
                    BuscarProductoPorDescripcion()
                End If
            End If

            Me.Cursor = Cursors.Arrow





        End If
    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        pcAlmacen2.Font = New Font("Segoe UI", 8)
        pcAlmacen2.Size = New Size(260, 110)
        Me.pcAlmacen2.ParentControl = Me.txtAlmacen2
        Me.pcAlmacen2.ShowPopup(Point.Empty)
    End Sub

    Private Sub pcAlmacen2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen2.BeforePopup
        Me.pcAlmacen2.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcAlmacen2.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen2.SelectedItems.Count > 0 Then
                Me.txtAlmacen2.Tag = lstAlmacen2.SelectedValue
                txtAlmacen2.Text = lstAlmacen2.Text
                '      ObtenerTotales(txtAlmacen.ValueMember)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacen2.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAlmacen.SelectedIndexChanged

    End Sub

    Private Sub lstAlmacen2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAlmacen2.MouseDoubleClick
        Me.pcAlmacen2.HidePopup(PopupCloseType.Done)
        If (dgvKardex2.TableModel.RowCount > 0) Then
            'ContextMenuStrip2 = New ContextMenuStrip()
            'ContextMenuStrip2.Items.Add("Ver proveedores")
            'AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
            'AddHandler Me.dgvKardex.TableControlMouseDown, AddressOf dgvTotales_TableControlMouseDown
        End If
    End Sub

    Private Sub lstAlmacen2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAlmacen2.SelectedIndexChanged

    End Sub

    Private Sub TextBoxExt2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltro2.KeyDown
        LoadingAnimator.Wire(Me.dgvKardexVal.TableControl)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not txtAlmacen2.Text.Trim.Length > 0 Then
                lblEstado.Text = "Debe elegir un almacén válido"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
            Else
                If txtFiltro2.Text.Trim.Length > 0 Then

                    BuscarProductoPorDescripcionVal()
                    srtBusqueda = txtFiltro2.Text
                Else
                    lblEstado.Text = "Debe escribir el nombre del producto a buscar"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(5)

                End If
            End If
        End If
        LoadingAnimator.UnWire(Me.dgvKardexVal.TableControl)
    End Sub

    Private Sub TextBoxExt2_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro2.TextChanged

    End Sub

    Private Sub btnCard2_Click(sender As Object, e As EventArgs) Handles btnCard2.Click
        If txtAlmacen2.Text.Trim.Length > 0 Then
            Dim a As New frmInfoSourceProductos(txtAlmacen2.Tag)
            'a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha operación"
            'a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Proveedor y/o trabajador"
            a.StartPosition = FormStartPosition.CenterParent
            a.ShowDialog()
        Else
            lblEstado.Text = "Debe elegir un almacen"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        If Not IsNothing(Me.dgvKardexVal.Table.CurrentRecord) Then

            Me.Cursor = Cursors.WaitCursor
            Dim f As New frmCantidades

            f.txtcantmax.Text = Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmax")
            f.txtcantmin.Text = Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmin")
            f.txtidmovimiento.Text = Me.dgvKardexVal.Table.CurrentRecord.GetValue("idmovimiento")
            f.txtiditem.Text = Me.dgvKardexVal.Table.CurrentRecord.GetValue("idItem")
            f.txtdescripcion.Text = Me.dgvKardexVal.Table.CurrentRecord.GetValue("descripcion")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            If txtFiltro2.Text.Trim.Length > 0 Then
                If txtAlmacen2.Text.Trim.Length > 0 Then
                    BuscarProductoPorDescripcionVal()
                End If
            End If

            Me.Cursor = Cursors.Arrow





        End If
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovimientoAlmacen
            .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '  .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '.cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            '    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboTipoExistencia2_Click(sender As Object, e As EventArgs) Handles cboTipoExistencia2.Click

    End Sub

    Private Sub MenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvKardex2.Table.CurrentRecord) Then

            '   Me.dgvCompra.Table.CurrentRecord.Delete()
            Select Case Me.dgvKardex2.Table.CurrentRecord.GetValue("Movimiento")
                Case "COMPRA", "OTRAS ENTRADAS A ALMACEN", "TRANSFERENCIA ENTRE ALMACENES", "OTRAS SALIDAS DE ALMACEN", "NC-DISMINUIR CANTIDAD", "NC-DISMINUIR IMPORTE", "NC-DISMINUIR CANTIDAD E IMPORTE", "NC-DEVOLUCION DE EXISTENCIAS"
                    Dim a As New frmInfoSourceAlmacen(Me.dgvKardex2.Table.CurrentRecord.GetValue("Movimiento"), Me.dgvKardex2.Table.CurrentRecord.GetValue("idDocumento"))
                    ' Me.dgvCompra.TableDescriptor.Columns("CompanyName").HeaderText = "Hello"
                    a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha operación"
                    a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Proveedor y/o trabajador"
                    a.StartPosition = FormStartPosition.CenterParent
                    a.ShowDialog()
                Case "VENTA" ', "OTRAS SALIDAS DE ALMACEN"
                    Dim a As New frmInfoSourceAlmacen(Me.dgvKardex2.Table.CurrentRecord.GetValue("Movimiento"), Me.dgvKardex2.Table.CurrentRecord.GetValue("idDocumento"))
                    a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha venta"
                    a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Cliente"
                    a.StartPosition = FormStartPosition.CenterParent
                    a.ShowDialog()
                Case "APORTES"
                    Dim a As New frmInfoSourceAlmacen(Me.dgvKardex2.Table.CurrentRecord.GetValue("Movimiento"), Me.dgvKardex2.Table.CurrentRecord.GetValue("idDocumento"))
                    a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha venta"
                    a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Trabajador"
                    a.StartPosition = FormStartPosition.CenterParent
                    a.ShowDialog()
            End Select

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub MenuItem2_Click(sender As Object, e As EventArgs) Handles MenuItem2.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvKardex2.Table.CurrentRecord) Then

            'Select Case Me.dgvKardex2.Table.CurrentRecord.GetValue("Movimiento")
            '    Case "COMPRA", "OTRAS ENTRADAS A ALMACEN", "TRANSFERENCIA ENTRE ALMACENES", "OTRAS SALIDAS DE ALMACEN", "NC-DISMINUIR CANTIDAD", "NC-DISMINUIR IMPORTE", "NC-DISMINUIR CANTIDAD E IMPORTE", "NC-DEVOLUCION DE EXISTENCIAS"

            '    Case "VENTA" ', "OTRAS SALIDAS DE ALMACEN"

            '    Case "APORTES"
            'End Select

            'Dim f As New frmEditOperacionSoloFechas(Me.dgvKardex2.Table.CurrentRecord.GetValue("idDocumento"))
            'f.CodInventario = Me.dgvKardex2.Table.CurrentRecord.GetValue("codigo")
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        Me.Cursor = Cursors.WaitCursor
        Dim rf As New RecordFilterDescriptor("Movimiento", New FilterCondition(FilterCompareOperator.Equals, "VENTA"))
        Me.dgvKardex2.TableDescriptor.RecordFilters.Add(rf)
        Dim f As New frmCostoVenta(dgvKardex2)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.dgvKardex2.TableDescriptor.RecordFilters.Clear()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTileNuevosItems_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv6.Parent = TabControlAdv1
        TabPageAdv7.Parent = Nothing
        TabPageAdv8.Parent = Nothing
        lblstockmn.Text = "Productos con menor stock"
        LoadProductosPocoStock()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvStockMin_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvStockMin.QueryCellStyleInfo

        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then

            'If e.TableCellIdentity.Column.MappingName = "stock" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
            If e.TableCellIdentity.Column.MappingName = "stock" Then
                e.Style.BackColor = Color.FromArgb(255, 192, 192) '
            End If

        End If


    End Sub

    Private Sub dgvStockMin_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvStockMin.TableControlCellClick

    End Sub

    Private Sub ButtonAdv17_Click_1(sender As Object, e As EventArgs)

        'If cbotiempo.Text.Trim.Length > 0 Then
        'Else
        '    MessageBox.Show("seleccione rango de tiempo")
        '    Exit Sub
        'End If

        'Dim fechaini As Date
        'Dim fechafin As Date

        'Select Case TreeViewAdv1.SelectedNode.Text
        '    Case "0 - 10 unidades"
        '        If cbotiempo.Text = "1 a 30 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 1, 1)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("1", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "31 a 60 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 2, 1)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("1", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "61 a 90 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 3, 3)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("1", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "91 a mas dias" Then
        '            Dim s As New DateTime(AnioGeneral, 4, 3)
        '            Dim f As New DateTime(AnioGeneral, 12, 31)
        '            fechaini = s
        '            fechafin = f
        '            VentasCantidadStock("1", fechaini, fechafin)
        '        End If


        '    Case "11 - 100 unidades"

        '        If cbotiempo.Text = "1 a 30 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 1, 1)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("2", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "31 a 60 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 2, 1)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("2", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "61 a 90 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 3, 3)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("2", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "91 a mas dias" Then
        '            Dim s As New DateTime(AnioGeneral, 4, 3)
        '            Dim f As New DateTime(AnioGeneral, 12, 31)
        '            fechaini = s
        '            fechafin = f
        '            VentasCantidadStock("2", fechaini, fechafin)
        '        End If

        '    Case "101 - 500 unidades"

        '        If cbotiempo.Text = "1 a 30 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 1, 1)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("3", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "31 a 60 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 2, 1)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("3", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "61 a 90 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 3, 3)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("3", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "91 a mas dias" Then
        '            Dim s As New DateTime(AnioGeneral, 4, 3)
        '            Dim f As New DateTime(AnioGeneral, 12, 31)
        '            fechaini = s
        '            fechafin = f
        '            VentasCantidadStock("3", fechaini, fechafin)
        '        End If

        '    Case "501 - a mas"

        '        If cbotiempo.Text = "1 a 30 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 1, 1)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("4", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "31 a 60 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 2, 1)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("4", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "61 a 90 dias" Then
        '            Dim s As New DateTime(AnioGeneral, 3, 3)
        '            Dim addDay As DateTime = s.AddDays(CInt(30))
        '            fechaini = s
        '            fechafin = addDay
        '            VentasCantidadStock("4", fechaini, fechafin)
        '        ElseIf cbotiempo.Text = "91 a mas dias" Then
        '            Dim s As New DateTime(AnioGeneral, 4, 3)
        '            Dim f As New DateTime(AnioGeneral, 12, 31)
        '            fechaini = s
        '            fechafin = f
        '            VentasCantidadStock("4", fechaini, fechafin)
        '        End If

        'End Select


    End Sub

    'Private Sub HubTile2_Click(sender As Object, e As EventArgs) Handles HubTile2.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    TabPageAdv1.Parent = Nothing
    '    TabPageAdv2.Parent = Nothing
    '    TabPageAdv3.Parent = Nothing
    '    TabPageAdv4.Parent = Nothing
    '    TabPageAdv5.Parent = Nothing
    '    TabPageAdv6.Parent = Nothing
    '    TabPageAdv7.Parent = TabControlAdv1
    '    TabPageAdv8.Parent = Nothing

    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub TreeViewAdv1_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub TreeViewAdv1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TreeViewAdv1.MouseDoubleClick


    '    'If ckadelante.Checked = True Then

    '    '    VentasCantidadStock("1", txtFechainicio.Value, txtFechafin.Value)
    '    'ElseIf ckatraz.Checked = True Then

    '    '    VentasCantidadStock("1", txtFechainicio.Value, txtFechafin.Value)
    '    'End If

    '    Select Case TreeViewAdv1.SelectedNode.Text
    '        Case "0 - 10 unidades"

    '            VentasCantidadStock("1", txtFechainicio.Value, txtFechafin.Value, CDec(10.0), CDec(0.0))

    '        Case "11 - 100 unidades"

    '            VentasCantidadStock("2", txtFechainicio.Value, txtFechafin.Value, CDec(100.0), CDec(11))

    '        Case "101 - 500 unidades"

    '            VentasCantidadStock("3", txtFechainicio.Value, txtFechafin.Value, CDec(500.0), CDec(101))

    '        Case "501 - a mas"

    '            VentasCantidadStock("4", txtFechainicio.Value, txtFechafin.Value, CDec(99999999), CDec(501))

    '        Case "0 - a mas"

    '            VentasCantidadStock("4", txtFechainicio.Value, txtFechafin.Value, CDec(99999999), CDec(0))

    '    End Select




    '    'If cbotiempo.Text.Trim.Length > 0 Then
    '    'Else
    '    '    MessageBox.Show("seleccione rango de tiempo")
    '    '    Exit Sub
    '    'End If

    '    '        Dim fechaini As Date
    '    '        Dim fechafin As Date

    '    '        Select Case TreeViewAdv1.SelectedNode.Text
    '    '            Case "0 - 10 unidades"
    '    '                If cbotiempo.Text = "1 a 30 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 1, 1)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("1", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "31 a 60 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 2, 1)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("1", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "61 a 90 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 3, 3)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("1", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "91 a mas dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 4, 3)
    '    '                    Dim f As New DateTime(AnioGeneral, 12, 31)
    '    '                    fechaini = s
    '    '                    fechafin = f
    '    '                    VentasCantidadStock("1", fechaini, fechafin)
    '    '                End If


    '    '            Case "11 - 100 unidades"

    '    '                If cbotiempo.Text = "1 a 30 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 1, 1)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("2", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "31 a 60 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 2, 1)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("2", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "61 a 90 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 3, 3)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("2", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "91 a mas dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 4, 3)
    '    '                    Dim f As New DateTime(AnioGeneral, 12, 31)
    '    '                    fechaini = s
    '    '                    fechafin = f
    '    '                    VentasCantidadStock("2", fechaini, fechafin)
    '    '                End If

    '    '            Case "101 - 500 unidades"

    '    '                If cbotiempo.Text = "1 a 30 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 1, 1)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("3", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "31 a 60 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 2, 1)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("3", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "61 a 90 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 3, 3)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("3", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "91 a mas dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 4, 3)
    '    '                    Dim f As New DateTime(AnioGeneral, 12, 31)
    '    '                    fechaini = s
    '    '                    fechafin = f
    '    '                    VentasCantidadStock("3", fechaini, fechafin)
    '    '                End If

    '    '            Case "501 - a mas"

    '    '                If cbotiempo.Text = "1 a 30 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 1, 1)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("4", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "31 a 60 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 2, 1)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("4", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "61 a 90 dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 3, 3)
    '    '                    Dim addDay As DateTime = s.AddDays(CInt(30))
    '    '                    fechaini = s
    '    '                    fechafin = addDay
    '    '                    VentasCantidadStock("4", fechaini, fechafin)
    '    '                ElseIf cbotiempo.Text = "91 a mas dias" Then
    '    '                    Dim s As New DateTime(AnioGeneral, 4, 3)
    '    '                    Dim f As New DateTime(AnioGeneral, 12, 31)
    '    '                    fechaini = s
    '    '                    fechafin = f
    '    '                    VentasCantidadStock("4", fechaini, fechafin)
    '    '                End If

    '    '        End Select

    'End Sub



    Private Sub cbofiltrodias_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cbofiltrodias_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If cbofiltrodias.Text = "30 dias atraz" Then
        '    Dim s As New DateTime
        '    s = DateTime.Now
        '    Dim addDay As DateTime = s.AddDays(CInt(-30))
        '    txtFechafin.Value = DateTime.Now
        '    txtFechainicio.Value = addDay
        'ElseIf cbofiltrodias.Text = "60 dias atraz" Then
        '    Dim s As New DateTime
        '    s = DateTime.Now
        '    Dim addDay As DateTime = s.AddDays(CInt(-60))
        '    txtFechafin.Value = DateTime.Now
        '    txtFechainicio.Value = addDay
        'ElseIf cbofiltrodias.Text = "90 dias atraz" Then
        '    Dim s As New DateTime
        '    s = DateTime.Now
        '    Dim addDay As DateTime = s.AddDays(CInt(-90))
        '    txtFechafin.Value = DateTime.Now
        '    txtFechainicio.Value = addDay
        'End If
    End Sub

    Private Sub HubTile3_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv6.Parent = TabControlAdv1
        TabPageAdv7.Parent = Nothing
        TabPageAdv8.Parent = Nothing
        lblstockmn.Text = "Productos con mayor stock"
        LoadProductosMayorStock()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cbodiaatras_ValueChanged(sender As Object, e As EventArgs) Handles cbodiaatras.ValueChanged

        Dim valor = cbodiaatras.Value
        Dim s As New DateTime
        s = DateTime.Now
        Dim addDay As DateTime = s.AddDays(CInt(-(valor)))
        txtFechafin.Value = DateTime.Now
        txtFechainicio.Value = addDay

    End Sub

    Private Sub cbotiempo_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            nudespecifica.Visible = True
        End If
    End Sub

    Private Sub ButtonAdv17_Click_2(sender As Object, e As EventArgs) Handles ButtonAdv17.Click
        VentasCantidadStock("1", txtFechainicio.Value, txtFechafin.Value, nudespecifica.Value, CDec(0.0), "filtro de 0 a " + nudespecifica.Value.ToString)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged

        If ComboBox1.Text.Trim.Length > 0 Then
        Else
            Exit Sub
        End If

        If ComboBox1.Text = "0 - 10 unidades" Then
            VentasCantidadStock("1", txtFechainicio.Value, txtFechafin.Value, CDec(10.0), CDec(0.0), "filtro de 0 - 10 unidades")
        ElseIf ComboBox1.Text = "11 - 100 unidades" Then
            VentasCantidadStock("2", txtFechainicio.Value, txtFechafin.Value, CDec(100.0), CDec(11), "filtro de 11 - 100 unidades")
        ElseIf ComboBox1.Text = "101 - 500 unidades" Then
            VentasCantidadStock("3", txtFechainicio.Value, txtFechafin.Value, CDec(500.0), CDec(101), "filtro de 101 - 500 unidades")
        ElseIf ComboBox1.Text = "501 - a mas" Then
            VentasCantidadStock("4", txtFechainicio.Value, txtFechafin.Value, CDec(99999999), CDec(501), "filtro de 501 - a mas unidades")
        ElseIf ComboBox1.Text = "0 - a mas" Then
            VentasCantidadStock("4", txtFechainicio.Value, txtFechafin.Value, CDec(99999999), CDec(0), "filtro de  0 - a mas unidades")
        End If

    End Sub

    Private Sub Panel14_MouseClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub Panel14_MouseDoubleClick(sender As Object, e As MouseEventArgs)


    End Sub



    Private Sub Label20_MouseClick(sender As Object, e As MouseEventArgs) Handles Label20.MouseClick
        Me.Cursor = Cursors.WaitCursor
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv6.Parent = TabControlAdv1
        TabPageAdv7.Parent = Nothing
        TabPageAdv8.Parent = Nothing
        lblstockmn.Text = "Productos con mayor stock"
        LoadProductosMayorStock()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label24_MouseClick(sender As Object, e As MouseEventArgs) Handles Label24.MouseClick
        Me.Cursor = Cursors.WaitCursor
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv6.Parent = TabControlAdv1
        TabPageAdv7.Parent = Nothing
        TabPageAdv8.Parent = Nothing
        lblstockmn.Text = "Productos con menor stock"
        LoadProductosPocoStock()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label22_MouseClick(sender As Object, e As MouseEventArgs) Handles Label22.MouseClick
        Me.Cursor = Cursors.WaitCursor
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv6.Parent = Nothing
        TabPageAdv7.Parent = Nothing
        TabPageAdv8.Parent = TabControlAdv1
        Almacenes()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label18_MouseClick(sender As Object, e As MouseEventArgs) Handles Label18.MouseClick
        Me.Cursor = Cursors.WaitCursor
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv5.Parent = Nothing
        TabPageAdv6.Parent = Nothing
        TabPageAdv7.Parent = TabControlAdv1
        TabPageAdv8.Parent = Nothing
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub lstAlmacenKardex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAlmacenKardex.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv22_Click(sender As Object, e As EventArgs) Handles ButtonAdv22.Click
        LoadingAnimator.Wire(Me.dgvTransito.TableControl)


        If Not txtAlmacen.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe elegir un almacén válido"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(5)
        Else

            BuscarProductoTodo()


        End If


        LoadingAnimator.UnWire(Me.dgvTransito.TableControl)
    End Sub

    Private Sub ButtonAdv23_Click(sender As Object, e As EventArgs) Handles ButtonAdv23.Click
        LoadingAnimator.Wire(Me.dgvKardexVal.TableControl)

        If Not txtAlmacen2.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe elegir un almacén válido"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(5)
        Else

            BuscarProductoPorDescripcionValTodo()
            srtBusqueda = txtFiltro2.Text

        End If

        LoadingAnimator.UnWire(Me.dgvKardexVal.TableControl)
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        If Not IsNothing(dgvAsiento.Table.CurrentRecord) Then
            Dim asientoSA As New AsientoSA
            asientoSA.DeletePorIdAsiento(Val(dgvAsiento.Table.CurrentRecord.GetValue("idAsiento")))
            If Not IsNothing(dgvMov.Table.CurrentRecord) Then
                VerAsientosByDocumento(dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
            End If
            MessageBoxAdv.Show("Asiento eliminado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub lblAlertasgeneral_Click(sender As Object, e As EventArgs) Handles lblAlertasgeneral.Click

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub
End Class
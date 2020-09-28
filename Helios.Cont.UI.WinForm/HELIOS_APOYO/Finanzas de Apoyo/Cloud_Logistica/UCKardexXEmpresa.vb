Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms.Grid

Public Class UCKardexXEmpresa

#Region "Attributes"
    Public Property ListaCurar As List(Of totalesAlmacen)
    Public Property ListaNegativosKardex As List(Of totalesAlmacen)
    Public Property ListaCantidadNegativa As List(Of totalesAlmacen)
    Public Property ListaMontoNegativa As List(Of totalesAlmacen)
    Public Property listaCostoVentaMayorAventa As List(Of totalesAlmacen)
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public almacenSA As New almacenSA
    Public Property EnvioSelect As BusquedaExstencia
    Public inventario As New inventarioMovimientoSA

    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0
    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtPeriodo.Value = Date.Now
        FormatoGridAvanzado(dgvKardex2, True, False, 7.5F)
        OrdenamientoGrid(dgvKardex2, False)
        ListarUnidOrganicas()
        CargarCMB()

    End Sub
#End Region

#Region "Events"
    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try
            PictureLoad.Visible = True
            Dim periodo = txtPeriodo.Value
            Dim almacenRef = cboAlmacen.SelectedValue
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetKardexByAnio(almacenRef, periodo)))
            thread.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Methods"

    Public Sub ListarUnidOrganicas()

        Dim consulta = ListaUnidadOrganica.Where(Function(o) o.TipoEstab = "UN").ToList

        cboUnidOrg.ValueMember = "idCentroCosto"
        cboUnidOrg.DisplayMember = "nombre"
        cboUnidOrg.DataSource = consulta

    End Sub

    Private Sub CargarCMB()
        Dim lista As New List(Of tabladetalle)
        Dim listaAlmacen As New List(Of almacen)
        '   listaAlmacen.Add(New almacen With {.idAlmacen = 0, .descripcionAlmacen = "-Todos-"})
        listaAlmacen.AddRange(almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = cboUnidOrg.SelectedValue, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = listaAlmacen
    End Sub

    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            dgvKardex2.DataSource = table
            dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvKardex2.TopLevelGroupOptions.ShowCaption = True
            dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            'LinkLabel1.Text = "Saldos Neg: " & ListaNegativosKardex.Count
            'LinkMontoNega.Text = "Imp. Neg: " & ListaMontoNegativa.Count
            'LinkCantNega.Text = "Cant. Neg: " & ListaCantidadNegativa.Count
            'lblCosto.Text = "Costo: " & listaCostoVentaMayorAventa.Count
            PictureLoad.Visible = False
        End If
    End Sub


    Private Sub GetKardexByAnio(intIdAlmacen As Integer, periodo As Date)

        Try



            Dim tablaSA As New tablaDetalleSA
            Dim inventario As New inventarioMovimientoSA
            Dim listaInventario As New List(Of InventarioMovimiento)
            'Dim canSaldo As Decimal = 0
            'Dim ImporteSaldo As Decimal = 0
            Dim producto As String = Nothing
            Dim CodigoLotex As Integer = 0
            Dim cantidadDeficit As Decimal = 0
            Dim importeDeficit As Decimal = 0
            Dim productoCache As String = Nothing
            '-----------------------------------------------------------------------------------------------------
            Dim costoSalida As Decimal = 0
            'PRUEBA
            Dim ListaPmVenta As New List(Of InventarioMovimiento)
            Dim pmVenta As InventarioMovimiento
            'fin prueba
            '
            Dim dt As New DataTable("kárdex - Período " & MonthName(periodo.Month) & "-" & periodo.Year)
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
            dt.Columns.Add(New DataColumn("valorventa", GetType(Decimal))) '.PM
            dt.Columns.Add(New DataColumn("costoventa", GetType(Decimal)))
            dt.Columns.Add(New DataColumn("nrolote", GetType(String)))
            dt.Columns.Add(New DataColumn("unidOrg", GetType(String)))
            Dim str As String


            ImporteSaldo = 0
            canSaldo = 0
            '''''''''''''''m
            '     Select Case cboFechaFiltroKardex.Text
            'Case "FECHA LABORAL"
            '    If CheckBox3.Checked = True Then
            '        listaInventario = inventario.GetKardexByAnioDiaLaboralLote(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1), .nrolote = txtFiltroLote.Text})
            '    Else
            '        listaInventario = inventario.GetKardexByAnioDiaLaboral(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
            '    End If

            'Case "FECHA DOCUMENTO" '
            '    If CheckBox3.Checked = True Then
            '        listaInventario = inventario.GetKardexByfechaDocumentoLote(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1), .nrolote = txtFiltroLote.Text})
            '    Else
            '    listaInventario = inventario.GetKardexByAnio(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
            'listaInventario = inventario.GetMovimientosKardexByMes(New InventarioMovimiento With {.idAlmacen = intIdAlmacen, .fecha = New DateTime(periodo.Year, periodo.Month, 1)}, Nothing)

            Select Case cboUnidOrg.Text
                Case "TODO"

                    listaInventario = inventario.GetMovimientosKardexByMesSustentado(
                                             New InventarioMovimiento With
                                             {
                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                             .idEstablecimiento = Nothing,
                                             .tipoConsulta = StatusTipoConsulta.XEmpresa,
                                             .customLote = New recursoCostoLote With {.productoSustentado = If(RBSustentados.Checked, True, False)},
                                             .idAlmacen = intIdAlmacen,
                                             .fecha = New DateTime(periodo.Year, periodo.Month, 1)
                                             }, Nothing)


                    ListaNegativosKardex = New List(Of totalesAlmacen)
                    ListaCantidadNegativa = New List(Of totalesAlmacen)
                    ListaMontoNegativa = New List(Of totalesAlmacen)
                    listaCostoVentaMayorAventa = New List(Of totalesAlmacen)
                    For Each i As InventarioMovimiento In listaInventario
                        cantidadDeficit = 0
                        importeDeficit = 0

                        costoSalida = 0

                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
                        dr(0) = i.DetalleTipoOperacion ' tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
                        dr(1) = str
                        dr(2) = i.destinoGravadoItem
                        dr(3) = i.nombreItem
                        dr(4) = ""
                        'If i.marca Is Nothing Then
                        '    '      dr(4) = i.marca
                        'Else
                        '    '     dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
                        'End If
                        dr(5) = i.tipoProducto
                        dr(6) = i.unidad
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



                                If producto = i.idItem AndAlso CodigoLotex = i.customLote.codigoLote Then
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
                                ' dr(7) = (FormatNumber(i.cantidad, 4))
                                dr(7) = i.cantidad
                                If CDec(i.cantidad) > 0 Then
                                    'dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                                    dr(8) = CDec(i.monto) / CDec(i.cantidad)
                                Else
                                    dr(8) = 0
                                End If
                                dr(9) = i.monto

                                dr(10) = ("0.00")
                                dr(11) = ("0.00")
                                dr(12) = ("0.00")
                                dr(13) = canSaldo
                                dr(14) = ImporteSaldo
                                If canSaldo > 0 Then
                                    precUnit = ImporteSaldo / canSaldo
                                Else
                                    precUnit = 0
                                End If
                                dr(15) = precUnit
                                pmAcumnulado = precUnit



                            Case "S", "D"
                                Dim co As Decimal = 0
                                co = CDec(i.cantidad) * pmAcumnulado

                                If producto = i.idItem AndAlso CodigoLotex = i.customLote.codigoLote Then
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

                                'Case "9926"
                                '    canSaldo += CDec(i.cantidad)
                                '    ImporteSaldo += i.monto

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
                                dr(7) = ("0.00")
                                dr(8) = ("0.00")
                                dr(9) = ("0.00")

                                Select Case i.tipoOperacion
                                    Case "9913"
                                        dr(10) = i.cantidad * -1
                                        dr(11) = (0)
                                        dr(12) = 0.0

                                    Case "9914"
                                        dr(10) = 0.0
                                        dr(11) = (0)
                                        dr(12) = i.monto * -1
                                    Case "9943"
                                        dr(10) = 0.0
                                        dr(11) = (0)
                                        dr(12) = i.monto * -1

                                    Case "9916"
                                        dr(10) = i.cantidad * -1
                                        dr(11) = (0)
                                        dr(12) = i.monto * -1
                                    Case "9940"

                                        dr(10) = i.cantidad * -1
                                        dr(11) = (0)
                                        dr(12) = (0)


                                    Case StatusTipoOperacion.REVERSIONES
                                        'canSaldo += CDec(i.cantidad)
                                        'ImporteSaldo = ImporteSaldo
                                        'Case "9926"
                                        dr(10) = i.cantidad * -1
                                        dr(11) = (0)
                                        dr(12) = i.monto * -1

                                    Case Else
                                        dr(10) = i.cantidad * -1
                                        dr(11) = (0)
                                        dr(12) = CDec(i.cantidad) * pmAcumnulado * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                                End Select
                                dr(13) = canSaldo
                                dr(14) = ImporteSaldo
                                If canSaldo > 0 Then
                                    precUnit = ImporteSaldo / canSaldo
                                Else
                                    precUnit = 0
                                End If
                                dr(15) = precUnit
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
                        dr(16) = i.idDocumento
                        dr(17) = i.idInventario
                        dr(18) = i.ValorDeVenta.GetValueOrDefault
                        dr(20) = i.customLote.nroLote
                        producto = i.idItem
                        CodigoLotex = i.customLote.codigoLote
                        productoCache = i.nombreItem

                        'If CDec(dr(10)) < 0 Then
                        If CDec(canSaldo) < 0 Then
                            ListaNegativosKardex.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                              .idAlmacen = i.idAlmacen,
                                                                              .NomAlmacen = cboAlmacen.Text,
                                                                              .descripcion = i.nombreItem,
                                                                              .cantidad = i.cantidad})
                        End If

                        If CDec(dr(10)) < 0 Then
                            ListaCantidadNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                              .idAlmacen = i.idAlmacen,
                                                                              .NomAlmacen = cboAlmacen.Text,
                                                                              .descripcion = i.nombreItem,
                                                                              .cantidad = i.cantidad})
                        End If

                        If CDec(dr(12)) < 0 Then
                            ListaMontoNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                              .idAlmacen = i.idAlmacen,
                                                                              .NomAlmacen = cboAlmacen.Text,
                                                                              .descripcion = i.nombreItem,
                                                                              .cantidad = i.cantidad})
                        End If

                        If CDec(dr(12)) > i.ValorDeVenta.GetValueOrDefault Then
                            listaCostoVentaMayorAventa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                             .idAlmacen = i.idAlmacen,
                                                                             .NomAlmacen = cboAlmacen.Text,
                                                                             .descripcion = i.nombreItem,
                                                                             .importeSoles = i.ValorDeVenta})
                        End If

                        dr(21) = ListaUnidadOrganica.Where(Function(O) O.idCentroCosto = i.idEstablecimiento).First.nombre
                        dt.Rows.Add(dr)
                    Next


                Case Else
                    listaInventario = inventario.GetMovimientosKardexByMesSustentado(
                                  New InventarioMovimiento With
                                  {
                                        .idEmpresa = Gempresas.IdEmpresaRuc,
                                             .idEstablecimiento = cboUnidOrg.SelectedValue,
                                             .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA,
                                  .customLote = New recursoCostoLote With {.productoSustentado = If(RBSustentados.Checked, True, False)},
                                  .idAlmacen = intIdAlmacen,
                                  .fecha = New DateTime(periodo.Year, periodo.Month, 1)
                                  }, Nothing)



                    ListaNegativosKardex = New List(Of totalesAlmacen)
                    ListaCantidadNegativa = New List(Of totalesAlmacen)
                    ListaMontoNegativa = New List(Of totalesAlmacen)
                    listaCostoVentaMayorAventa = New List(Of totalesAlmacen)
                    For Each i As InventarioMovimiento In listaInventario
                        cantidadDeficit = 0
                        importeDeficit = 0

                        costoSalida = 0

                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
                        dr(0) = i.DetalleTipoOperacion ' tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
                        dr(1) = str
                        dr(2) = i.destinoGravadoItem
                        dr(3) = i.nombreItem
                        dr(4) = ""
                        'If i.marca Is Nothing Then
                        '    '      dr(4) = i.marca
                        'Else
                        '    '     dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
                        'End If
                        dr(5) = i.tipoProducto
                        dr(6) = i.unidad
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



                                If producto = i.idItem AndAlso CodigoLotex = i.customLote.codigoLote Then
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
                                ' dr(7) = (FormatNumber(i.cantidad, 4))
                                dr(7) = i.cantidad
                                If CDec(i.cantidad) > 0 Then
                                    'dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                                    dr(8) = CDec(i.monto) / CDec(i.cantidad)
                                Else
                                    dr(8) = 0
                                End If
                                dr(9) = i.monto

                                dr(10) = ("0.00")
                                dr(11) = ("0.00")
                                dr(12) = ("0.00")
                                dr(13) = canSaldo
                                dr(14) = ImporteSaldo
                                If canSaldo > 0 Then
                                    precUnit = ImporteSaldo / canSaldo
                                Else
                                    precUnit = 0
                                End If
                                dr(15) = precUnit
                                pmAcumnulado = precUnit



                            Case "S", "D"
                                Dim co As Decimal = 0
                                co = CDec(i.cantidad) * pmAcumnulado

                                If producto = i.idItem AndAlso CodigoLotex = i.customLote.codigoLote Then
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

                                'Case "9926"
                                '    canSaldo += CDec(i.cantidad)
                                '    ImporteSaldo += i.monto

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
                                dr(7) = ("0.00")
                                dr(8) = ("0.00")
                                dr(9) = ("0.00")

                                Select Case i.tipoOperacion
                                    Case "9913"
                                        dr(10) = i.cantidad * -1
                                        dr(11) = (0)
                                        dr(12) = 0.0

                                    Case "9914"
                                        dr(10) = 0.0
                                        dr(11) = (0)
                                        dr(12) = i.monto * -1
                                    Case "9943"
                                        dr(10) = 0.0
                                        dr(11) = (0)
                                        dr(12) = i.monto * -1

                                    Case "9916"
                                        dr(10) = i.cantidad * -1
                                        dr(11) = (0)
                                        dr(12) = i.monto * -1
                                    Case "9940"

                                        dr(10) = i.cantidad * -1
                                        dr(11) = (0)
                                        dr(12) = (0)


                                    Case StatusTipoOperacion.REVERSIONES
                                        'canSaldo += CDec(i.cantidad)
                                        'ImporteSaldo = ImporteSaldo
                                        'Case "9926"
                                        dr(10) = i.cantidad * -1
                                        dr(11) = (0)
                                        dr(12) = i.monto * -1

                                    Case Else
                                        dr(10) = i.cantidad * -1
                                        dr(11) = (0)
                                        dr(12) = CDec(i.cantidad) * pmAcumnulado * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                                End Select
                                dr(13) = canSaldo
                                dr(14) = ImporteSaldo
                                If canSaldo > 0 Then
                                    precUnit = ImporteSaldo / canSaldo
                                Else
                                    precUnit = 0
                                End If
                                dr(15) = precUnit
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
                        dr(16) = i.idDocumento
                        dr(17) = i.idInventario
                        dr(18) = i.ValorDeVenta.GetValueOrDefault
                        dr(20) = i.customLote.nroLote
                        producto = i.idItem
                        CodigoLotex = i.customLote.codigoLote
                        productoCache = i.nombreItem

                        'If CDec(dr(10)) < 0 Then
                        If CDec(canSaldo) < 0 Then
                            ListaNegativosKardex.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                              .idAlmacen = i.idAlmacen,
                                                                              .NomAlmacen = cboAlmacen.Text,
                                                                              .descripcion = i.nombreItem,
                                                                              .cantidad = i.cantidad})
                        End If

                        If CDec(dr(10)) < 0 Then
                            ListaCantidadNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                              .idAlmacen = i.idAlmacen,
                                                                              .NomAlmacen = cboAlmacen.Text,
                                                                              .descripcion = i.nombreItem,
                                                                              .cantidad = i.cantidad})
                        End If

                        If CDec(dr(12)) < 0 Then
                            ListaMontoNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                              .idAlmacen = i.idAlmacen,
                                                                              .NomAlmacen = cboAlmacen.Text,
                                                                              .descripcion = i.nombreItem,
                                                                              .cantidad = i.cantidad})
                        End If

                        If CDec(dr(12)) > i.ValorDeVenta.GetValueOrDefault Then
                            listaCostoVentaMayorAventa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                             .idAlmacen = i.idAlmacen,
                                                                             .NomAlmacen = cboAlmacen.Text,
                                                                             .descripcion = i.nombreItem,
                                                                             .importeSoles = i.ValorDeVenta})
                        End If

                        dr(21) = cboUnidOrg.Text
                        dt.Rows.Add(dr)
                    Next

            End Select



            setDataSource(dt)
            'dgvKardex2.DataSource = dt
            'dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvKardex2.TopLevelGroupOptions.ShowCaption = True
            'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            'LinkLabel1.Text = "Saldos Neg: " & ListaNegativosKardex.Count
            'LinkMontoNega.Text = "Imp. Neg: " & ListaMontoNegativa.Count
            'LinkCantNega.Text = "Cant. Neg: " & ListaCantidadNegativa.Count
            'lblCosto.Text = "Costo: " & listaCostoVentaMayorAventa.Count
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub GetKardexByAnio(intIdAlmacen As Integer, periodo As Date)

    '    Dim tablaSA As New tablaDetalleSA
    '    Dim inventario As New inventarioMovimientoSA
    '    Dim listaInventario As New List(Of InventarioMovimiento)
    '    'Dim canSaldo As Decimal = 0
    '    'Dim ImporteSaldo As Decimal = 0
    '    Dim producto As String = Nothing
    '    Dim CodigoLotex As Integer = 0


    '    Dim cantidadDeficit As Decimal = 0
    '    Dim importeDeficit As Decimal = 0
    '    Dim productoCache As String = Nothing
    '    '-----------------------------------------------------------------------------------------------------

    '    Dim dt As New DataTable("kárdex - Período " & MonthName(periodo.Month) & "-" & periodo.Year)
    '    Dim documentoCajaSA As New DocumentoCajaSA

    '    dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
    '    dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
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
    '    dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
    '    dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("valorventa", GetType(Decimal))) '.PM
    '    dt.Columns.Add(New DataColumn("costoventa", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("nrolote", GetType(String)))
    '    Dim str As String

    '    ImporteSaldo = 0
    '    canSaldo = 0
    '    '''''''''''''''m
    '    '     Select Case cboFechaFiltroKardex.Text
    '    'Case "FECHA LABORAL"
    '    '    If CheckBox3.Checked = True Then
    '    '        listaInventario = inventario.GetKardexByAnioDiaLaboralLote(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1), .nrolote = txtFiltroLote.Text})
    '    '    Else
    '    '        listaInventario = inventario.GetKardexByAnioDiaLaboral(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
    '    '    End If

    '    'Case "FECHA DOCUMENTO" '
    '    '    If CheckBox3.Checked = True Then
    '    '        listaInventario = inventario.GetKardexByfechaDocumentoLote(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1), .nrolote = txtFiltroLote.Text})
    '    '    Else
    '    '    listaInventario = inventario.GetKardexByAnio(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
    '    'listaInventario = inventario.GetMovimientosKardexByMes(New InventarioMovimiento With {.idAlmacen = intIdAlmacen, .fecha = New DateTime(periodo.Year, periodo.Month, 1)}, Nothing)

    '    listaInventario = inventario.GetMovimientosKardexByMesSustentado(
    '        New InventarioMovimiento With
    '        {
    '        .customLote = New recursoCostoLote With {.productoSustentado = If(RBSustentados.Checked, True, False)},
    '        .idAlmacen = intIdAlmacen,
    '        .fecha = New DateTime(periodo.Year, periodo.Month, 1)
    '        }, Nothing)


    '    ListaNegativosKardex = New List(Of totalesAlmacen)
    '    ListaCantidadNegativa = New List(Of totalesAlmacen)
    '    ListaMontoNegativa = New List(Of totalesAlmacen)
    '    listaCostoVentaMayorAventa = New List(Of totalesAlmacen)
    '    For Each i As InventarioMovimiento In listaInventario
    '        cantidadDeficit = 0
    '        importeDeficit = 0

    '        Dim dr As DataRow = dt.NewRow()
    '        str = Nothing
    '        str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
    '        dr(0) = i.DetalleTipoOperacion ' tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
    '        dr(1) = str
    '        dr(2) = i.destinoGravadoItem
    '        dr(3) = i.nombreItem
    '        dr(4) = ""
    '        'If i.marca Is Nothing Then
    '        '    '      dr(4) = i.marca
    '        'Else
    '        '    '     dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
    '        'End If
    '        dr(5) = i.tipoProducto
    '        dr(6) = i.unidad
    '        Select Case i.tipoRegistro
    '            Case "E", "EA", "EC"
    '                If producto = i.idItem AndAlso CodigoLotex = i.customLote.codigoLote Then
    '                    productoCache = i.nombreItem
    '                    canSaldo += CDec(i.cantidad)
    '                    ImporteSaldo += CDec(i.monto)
    '                Else

    '                    cantidadDeficit = canSaldo
    '                    importeDeficit = ImporteSaldo

    '                    canSaldo = 0
    '                    ImporteSaldo = 0

    '                    'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
    '                    canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
    '                    ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
    '                    canSaldo = CDec(i.cantidad) + canSaldo
    '                    ImporteSaldo = CDec(i.monto) + ImporteSaldo

    '                End If
    '                ' dr(7) = (FormatNumber(i.cantidad, 4))
    '                dr(7) = i.cantidad
    '                If CDec(i.cantidad) > 0 Then
    '                    'dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
    '                    dr(8) = CDec(i.monto) / CDec(i.cantidad)
    '                Else
    '                    dr(8) = 0
    '                End If
    '                dr(9) = i.monto

    '                dr(10) = ("0.00")
    '                dr(11) = ("0.00")
    '                dr(12) = ("0.00")
    '                dr(13) = canSaldo
    '                dr(14) = ImporteSaldo
    '                If canSaldo > 0 Then
    '                    precUnit = ImporteSaldo / canSaldo
    '                Else
    '                    precUnit = 0
    '                End If
    '                dr(15) = precUnit
    '                pmAcumnulado = precUnit
    '            Case "S", "D"
    '                Dim co As Decimal = 0
    '                co = CDec(i.cantidad) * pmAcumnulado

    '                If producto = i.idItem AndAlso CodigoLotex = i.customLote.codigoLote Then
    '                    productoCache = i.nombreItem
    '                    'canSaldo += CDec(i.cantidad)

    '                    Select Case i.tipoOperacion
    '                        Case "9913"
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo = ImporteSaldo

    '                        Case "9914"
    '                            canSaldo = canSaldo
    '                            ImporteSaldo += i.monto

    '                        Case "9916"
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo += i.monto

    '                            'Case "9926"
    '                            '    canSaldo += CDec(i.cantidad)
    '                            '    ImporteSaldo += i.monto

    '                        Case StatusTipoOperacion.REVERSIONES
    '                            canSaldo += CDec(i.cantidad)
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
    '                    'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
    '                    canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
    '                    ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault

    '                    canSaldo += CDec(i.cantidad)
    '                    ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
    '                End If
    '                dr(7) = ("0.00")
    '                dr(8) = ("0.00")
    '                dr(9) = ("0.00")

    '                Select Case i.tipoOperacion
    '                    Case "9913"
    '                        dr(10) = i.cantidad * -1
    '                        dr(11) = (0)
    '                        dr(12) = 0.0

    '                    Case "9914"
    '                        dr(10) = 0.0
    '                        dr(11) = (0)
    '                        dr(12) = i.monto * -1

    '                    Case "9916"
    '                        dr(10) = i.cantidad * -1
    '                        dr(11) = (0)
    '                        dr(12) = i.monto * -1


    '                    Case StatusTipoOperacion.REVERSIONES
    '                        'canSaldo += CDec(i.cantidad)
    '                        'ImporteSaldo = ImporteSaldo
    '                        'Case "9926"
    '                        dr(10) = i.cantidad * -1
    '                        dr(11) = (0)
    '                        dr(12) = i.monto * -1

    '                    Case Else
    '                        dr(10) = i.cantidad * -1
    '                        dr(11) = (0)
    '                        dr(12) = CDec(i.cantidad) * pmAcumnulado * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
    '                End Select
    '                dr(13) = canSaldo
    '                dr(14) = ImporteSaldo
    '                If canSaldo > 0 Then
    '                    precUnit = ImporteSaldo / canSaldo
    '                Else
    '                    precUnit = 0
    '                End If
    '                dr(15) = precUnit
    '                pmAcumnulado = precUnit
    '        End Select
    '        dr(16) = i.idDocumento
    '        dr(17) = i.idInventario
    '        dr(18) = i.ValorDeVenta.GetValueOrDefault
    '        dr(20) = i.customLote.nroLote
    '        producto = i.idItem
    '        CodigoLotex = i.customLote.codigoLote
    '        productoCache = i.nombreItem

    '        'If CDec(dr(10)) < 0 Then
    '        If CDec(canSaldo) < 0 Then
    '            ListaNegativosKardex.Add(New totalesAlmacen With {.idItem = i.idItem,
    '                                                              .idAlmacen = i.idAlmacen,
    '                                                              .NomAlmacen = cboAlmacen.Text,
    '                                                              .descripcion = i.nombreItem,
    '                                                              .cantidad = i.cantidad})
    '        End If

    '        If CDec(dr(10)) < 0 Then
    '            ListaCantidadNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
    '                                                              .idAlmacen = i.idAlmacen,
    '                                                              .NomAlmacen = cboAlmacen.Text,
    '                                                              .descripcion = i.nombreItem,
    '                                                              .cantidad = i.cantidad})
    '        End If

    '        If CDec(dr(12)) < 0 Then
    '            ListaMontoNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
    '                                                              .idAlmacen = i.idAlmacen,
    '                                                              .NomAlmacen = cboAlmacen.Text,
    '                                                              .descripcion = i.nombreItem,
    '                                                              .cantidad = i.cantidad})
    '        End If

    '        If CDec(dr(12)) > i.ValorDeVenta.GetValueOrDefault Then
    '            listaCostoVentaMayorAventa.Add(New totalesAlmacen With {.idItem = i.idItem,
    '                                                             .idAlmacen = i.idAlmacen,
    '                                                             .NomAlmacen = cboAlmacen.Text,
    '                                                             .descripcion = i.nombreItem,
    '                                                             .importeSoles = i.ValorDeVenta})
    '        End If

    '        dt.Rows.Add(dr)
    '    Next
    '    setDataSource(dt)
    '    'dgvKardex2.DataSource = dt
    '    'dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '    'dgvKardex2.TopLevelGroupOptions.ShowCaption = True
    '    'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
    '    'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    '    'LinkLabel1.Text = "Saldos Neg: " & ListaNegativosKardex.Count
    '    'LinkMontoNega.Text = "Imp. Neg: " & ListaMontoNegativa.Count
    '    'LinkCantNega.Text = "Cant. Neg: " & ListaCantidadNegativa.Count
    '    'lblCosto.Text = "Costo: " & listaCostoVentaMayorAventa.Count
    'End Sub

    Private Sub GetKardexPeridoByExistencia(envio As BusquedaExstencia, mes As Integer, anio As Integer, intIdAlmacen As Integer)

        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim codigoLotex As Integer = 0
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing

        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex / " & envio.NombreExistencia & ", " & mes & "/" & anio)
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
        dt.Columns.Add(New DataColumn("valorventa", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("nrolote", GetType(String)))
        Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        'GetKardexPeridoByExistencia
        '''''''''''''''m
        listaCostoVentaMayorAventa = New List(Of totalesAlmacen)
        ListaNegativosKardex = New List(Of totalesAlmacen)
        ListaCantidadNegativa = New List(Of totalesAlmacen)
        ListaMontoNegativa = New List(Of totalesAlmacen)
        For Each i As InventarioMovimiento In inventario.GetMovimientosKardexByArticuloSNAT(
            New InventarioMovimiento With
            {
            .customLote = New recursoCostoLote With {.productoSustentado = If(RBSustentados.Checked, True, False)},
            .idAlmacen = intIdAlmacen,
            .fecha = New DateTime(anio, mes, 1),
            .tipoProducto = envio.TipoExistencia,
            .idItem = envio.IdExistencia},
            New cierreinventario With
            {
            .anio = anio,
            .mes = mes - 1
            })

            cantidadDeficit = 0
            importeDeficit = 0

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = i.DetalleTipoOperacion ' tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            dr(4) = ""
            'If i.marca Is Nothing Then
            '    '      dr(4) = i.marca
            'Else
            '    '     dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            'End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad
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
                    ' dr(7) = (FormatNumber(i.cantidad, 4))
                    dr(7) = i.cantidad
                    If CDec(i.cantidad) > 0 Then
                        'dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                        dr(8) = CDec(i.monto) / CDec(i.cantidad)
                    Else
                        dr(8) = 0
                    End If
                    dr(9) = i.monto

                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = canSaldo
                    dr(14) = ImporteSaldo
                    If canSaldo > 0 Then
                        precUnit = ImporteSaldo / canSaldo
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
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

                                'Case "9926"
                                '    canSaldo += CDec(i.cantidad)
                                '    ImporteSaldo += i.monto

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
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")

                    Select Case i.tipoOperacion
                        Case "9913"
                            dr(10) = i.cantidad * -1
                            dr(11) = (0)
                            dr(12) = 0.0

                        Case "9914"
                            dr(10) = 0.0
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case "9916"
                            dr(10) = i.cantidad * -1
                            dr(11) = (0)
                            dr(12) = i.monto * -1


                        Case StatusTipoOperacion.REVERSIONES
                            'canSaldo += CDec(i.cantidad)
                            'ImporteSaldo = ImporteSaldo
                            'Case "9926"
                            dr(10) = i.cantidad * -1
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case Else
                            dr(10) = i.cantidad * -1
                            dr(11) = (0)
                            dr(12) = CDec(i.cantidad) * pmAcumnulado * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    dr(13) = canSaldo
                    dr(14) = ImporteSaldo
                    If canSaldo > 0 Then
                        precUnit = ImporteSaldo / canSaldo
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit

            End Select
            dr(16) = i.idDocumento
            dr(17) = i.idInventario
            dr(18) = i.ValorDeVenta.GetValueOrDefault
            dr(19) = i.customLote.nroLote
            producto = i.idItem
            codigoLotex = i.customLote.codigoLote
            productoCache = i.nombreItem

            'If CDec(dr(10)) < 0 Then
            If CDec(canSaldo) < 0 Then
                ListaNegativosKardex.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboAlmacen.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(10)) < 0 Then
                ListaCantidadNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboAlmacen.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(12)) < 0 Then
                ListaMontoNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboAlmacen.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(12)) > i.ValorDeVenta.GetValueOrDefault Then
                listaCostoVentaMayorAventa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                 .idAlmacen = i.idAlmacen,
                                                                 .NomAlmacen = cboAlmacen.Text,
                                                                 .descripcion = i.nombreItem,
                                                                 .importeSoles = i.ValorDeVenta})
            End If

            dt.Rows.Add(dr)
        Next
        setDataSource(dt)
        'dgvKardex2.DataSource = dt
        'dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'dgvKardex2.TopLevelGroupOptions.ShowCaption = True
        'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        'lblCosto.Text = "Costo: " & listaCostoVentaMayorAventa.Count
    End Sub

    Private Sub GetMovimientosKardexByExistencia(envio As BusquedaExstencia, mes As Integer, anio As Integer, intIdAlmacen As Integer)

        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim codigoLotex As Integer = 0
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing

        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex / " & envio.NombreExistencia & ", " & mes & "/" & anio)
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
        dt.Columns.Add(New DataColumn("valorventa", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("nrolote", GetType(String)))
        dt.Columns.Add(New DataColumn("unidOrg", GetType(String)))

        Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        'GetKardexPeridoByExistencia
        '''''''''''''''m
        listaCostoVentaMayorAventa = New List(Of totalesAlmacen)
        ListaNegativosKardex = New List(Of totalesAlmacen)
        ListaCantidadNegativa = New List(Of totalesAlmacen)
        ListaMontoNegativa = New List(Of totalesAlmacen)
        For Each i As InventarioMovimiento In inventario.GetMovimientosKardexByExistencia(
            New InventarioMovimiento With
            {
            .customLote = New recursoCostoLote With {.productoSustentado = If(RBSustentados.Checked, True, False)},
            .idAlmacen = intIdAlmacen,
            .fecha = New DateTime(anio, mes, 1),
            .tipoProducto = envio.TipoExistencia},
            New cierreinventario With
            {
            .anio = anio,
            .mes = mes - 1
            })

            cantidadDeficit = 0
            importeDeficit = 0

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            dr(0) = i.DetalleTipoOperacion ' tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            dr(4) = ""
            'If i.marca Is Nothing Then
            '    '      dr(4) = i.marca
            'Else
            '    '     dr(4) = tablaSA.GetUbicarTablaID(503, i.marca).descripcion
            'End If
            dr(5) = i.tipoProducto
            dr(6) = i.unidad
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
                    ' dr(7) = (FormatNumber(i.cantidad, 4))
                    dr(7) = i.cantidad
                    If CDec(i.cantidad) > 0 Then
                        'dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
                        dr(8) = CDec(i.monto) / CDec(i.cantidad)
                    Else
                        dr(8) = 0
                    End If
                    dr(9) = i.monto

                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = ("0.00")
                    dr(13) = canSaldo
                    dr(14) = ImporteSaldo
                    If canSaldo > 0 Then
                        precUnit = ImporteSaldo / canSaldo
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
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

                                'Case "9926"
                                '    canSaldo += CDec(i.cantidad)
                                '    ImporteSaldo += i.monto

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
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")

                    Select Case i.tipoOperacion
                        Case "9913"
                            dr(10) = i.cantidad * -1
                            dr(11) = (0)
                            dr(12) = 0.0

                        Case "9914"
                            dr(10) = 0.0
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case "9916"
                            dr(10) = i.cantidad * -1
                            dr(11) = (0)
                            dr(12) = i.monto * -1


                        Case StatusTipoOperacion.REVERSIONES
                            'canSaldo += CDec(i.cantidad)
                            'ImporteSaldo = ImporteSaldo
                            'Case "9926"
                            dr(10) = i.cantidad * -1
                            dr(11) = (0)
                            dr(12) = i.monto * -1

                        Case Else
                            dr(10) = i.cantidad * -1
                            dr(11) = (0)
                            dr(12) = CDec(i.cantidad) * pmAcumnulado * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    dr(13) = canSaldo
                    dr(14) = ImporteSaldo
                    If canSaldo > 0 Then
                        precUnit = ImporteSaldo / canSaldo
                    Else
                        precUnit = 0
                    End If
                    dr(15) = precUnit
                    pmAcumnulado = precUnit

            End Select
            dr(16) = i.idDocumento
            dr(17) = i.idInventario
            dr(18) = i.ValorDeVenta.GetValueOrDefault
            dr(19) = i.customLote.nroLote
            producto = i.idItem
            codigoLotex = i.customLote.codigoLote
            productoCache = i.nombreItem

            'If CDec(dr(10)) < 0 Then
            If CDec(canSaldo) < 0 Then
                ListaNegativosKardex.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboAlmacen.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(10)) < 0 Then
                ListaCantidadNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboAlmacen.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(12)) < 0 Then
                ListaMontoNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboAlmacen.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(12)) > i.ValorDeVenta.GetValueOrDefault Then
                listaCostoVentaMayorAventa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                 .idAlmacen = i.idAlmacen,
                                                                 .NomAlmacen = cboAlmacen.Text,
                                                                 .descripcion = i.nombreItem,
                                                                 .importeSoles = i.ValorDeVenta})
            End If

            dr(20) = ListaUnidadOrganica.Where(Function(o) o.idCentroCosto = i.idEstablecimiento).First.nombre

            dt.Rows.Add(dr)
        Next
        setDataSource(dt)
        'dgvKardex2.DataSource = dt
        'dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'dgvKardex2.TopLevelGroupOptions.ShowCaption = True
        'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        'lblCosto.Text = "Costo: " & listaCostoVentaMayorAventa.Count
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try
            Dim f As New frmBusquedaKardex(cboAlmacen.SelectedValue)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                EnvioSelect = New BusquedaExstencia

                Dim anio As Integer = txtPeriodo.Value.Year
                Dim mes As Integer = txtPeriodo.Value.Month
                Dim almacen = cboAlmacen.SelectedValue

                Dim envio = CType(f.Tag, BusquedaExstencia)
                txtArticuloSelec.Text = envio.NombreExistencia
                txtArticuloSelec.Tag = envio.IdExistencia
                EnvioSelect = envio
                PictureLoad.Visible = True

                If envio.UnidadMedida = "NO" Then
                    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetKardexPeridoByExistencia(envio, mes, anio, almacen)))
                    thread.Start()
                ElseIf envio.UnidadMedida = "SI" Then

                    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetMovimientosKardexByExistencia(envio, mes, anio, almacen)))
                    thread.Start()

                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click

    End Sub

    Private Sub cboUnidOrg_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboUnidOrg.SelectionChangeCommitted
        Dim lista As New List(Of tabladetalle)
        Dim listaAlmacen As New List(Of almacen)
        '   listaAlmacen.Add(New almacen With {.idAlmacen = 0, .descripcionAlmacen = "-Todos-"})
        listaAlmacen.AddRange(almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = cboUnidOrg.SelectedValue, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = listaAlmacen
    End Sub
#End Region
End Class

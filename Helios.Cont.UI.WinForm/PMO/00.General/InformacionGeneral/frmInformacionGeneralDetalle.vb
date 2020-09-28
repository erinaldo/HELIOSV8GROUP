Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GridHelperClasses
Public Class frmInformacionGeneralDetalle

#Region "Attributes"
    Dim ListDocVentaAbarrotesDet As New List(Of documentoventaAbarrotesDet)
    Public fechaInicio As DateTime
    Public fechaFin As DateTime
    Public periodo As String
    Public tipo As String
    Public idPersonas As List(Of String)
    Public listausuario As List(Of Usuario)
    Public IntAnioGeneral As Integer
    Public listobjVentaporCaja As New List(Of documentoventaAbarrotesDet)
    Public Property ListaEstadoFinancierosMaster() As New List(Of estadosFinancieros)
    Dim listaInventario As New List(Of InventarioMovimiento)
    '****kardex
    Dim almacenSA As New almacenSA
    Dim tablaSA As New tablaDetalleSA
    Dim inventario As New inventarioMovimientoSA
    Public Property ListaCurar As List(Of totalesAlmacen)
    Public Property ListaNegativosKardex As List(Of totalesAlmacen)
    Public Property ListaCantidadNegativa As List(Of totalesAlmacen)
    Public Property ListaMontoNegativa As List(Of totalesAlmacen)
    Dim listaCostoVentaMayorAventa As List(Of totalesAlmacen)
    Public Property TotalesSA As New TotalesAlmacenSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim ListatabladetalleMaster As List(Of tabladetalle)
    Dim listaDocCaja As List(Of documentoCaja)

#Region "Variables"
    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0
    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0
    Dim ImporteSaldoME As Decimal = 0
    Dim SaldoSoles As Decimal = 0
    Dim SaldoUSD As Decimal = 0
    Dim SaldoSolesNN As Decimal = 0
    Dim SaldoUSDNN As Decimal = 0
    Dim SaldoSolesNN1 As Decimal = 0
    Dim SaldoUSDNN1 As Decimal = 0
    Dim saldoImporteAnualME As Decimal = 0
#End Region

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvCompras)
        FormatoGrid(dgPedidos)
        FormatoGrid(dgvMov)
        FormatoGrid(dgvOtrosMov)
        FormatoGrid(dgvKardex2)
        ClipBoardDocumento = New documento
        CargarCMB()
    End Sub
#End Region

#Region "Methods"
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

    Public Sub CargarCMB()
        Dim lista As New List(Of tabladetalle)
        Dim listaAlmacen As New List(Of almacen)
        '   listaAlmacen.Add(New almacen With {.idAlmacen = 0, .descripcionAlmacen = "-Todos-"})
        listaAlmacen.AddRange(almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        cboalmacenKardex.DisplayMember = "descripcionAlmacen"
        cboalmacenKardex.ValueMember = "idAlmacen"
        cboalmacenKardex.DataSource = listaAlmacen
    End Sub

    Public Sub movimientoMN()
        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.None
        pnInventario.Visible = False
        pnkardex.Dock = DockStyle.None
        pnkardex.Visible = False
        Panel7.Visible = True
        Panel7.Dock = DockStyle.Fill
        FormatoGrid(dgvMovimiento)
    End Sub

    Public Sub CargarCajasTipo2(tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            ListaEstadoFinancierosMaster = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = tiping,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            cboEntidadFinanciera.DataSource = ListaEstadoFinancierosMaster
            cboEntidadFinanciera.DisplayMember = "descripcion"
            cboEntidadFinanciera.ValueMember = "idestado"
            cboEntidadFinanciera.SelectedValue = -1
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarCajasTipoOperqacionMovimiento(listaOperacion As List(Of String))
        Dim estadoSA As New tablaDetalleSA
        Dim objTablaDet As tabladetalle
        Try
            objTablaDet = New tabladetalle
            objTablaDet.idtabla = 12
            objTablaDet.descripcion = "TODO"
            objTablaDet.codigoDetalle = "00"

            ListatabladetalleMaster = (estadoSA.GetListaTablaDetalleXusuario(12, "1", listaOperacion))
            ListatabladetalleMaster.Add(objTablaDet)

            cbtipoOperacionMov.DataSource = ListatabladetalleMaster
            cbtipoOperacionMov.DisplayMember = "descripcion"
            cbtipoOperacionMov.ValueMember = "codigoDetalle"
            cbtipoOperacionMov.SelectedValue = "00"

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarCajasTipoOperqacion(listaOperacion As List(Of String))
        Dim estadoSA As New tablaDetalleSA
        Dim objTablaDet As tabladetalle
        Try
            objTablaDet = New tabladetalle
            objTablaDet.idtabla = 12
            objTablaDet.descripcion = "TODO"
            objTablaDet.codigoDetalle = "00"

            ListatabladetalleMaster = (estadoSA.GetListaTablaDetalleXusuario(12, "1", listaOperacion))
            ListatabladetalleMaster.Add(objTablaDet)

            cboTipoOperacion.DataSource = ListatabladetalleMaster
            cboTipoOperacion.DisplayMember = "descripcion"
            cboTipoOperacion.ValueMember = "codigoDetalle"
            cboTipoOperacion.SelectedValue = "00"
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetKardexByAnio(strTipo As String, listaID As List(Of String), tipo As String, periodo As String, fechaInicio As DateTime, fechaFin As DateTime, idAlmacen As Integer)

        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA

        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex - Período " & MonthName(txtPeriodo.Value.Month) & "-" & txtPeriodo.Value.Year)
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

        Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        Select Case strTipo
            Case "ALL"
                listaInventario = inventario.GetMovimientosKardexByMesAllAlmacenXusuario(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)}, listaID, tipo, periodo, fechaInicio, fechaFin)
            Case "ALMACEN"
                listaInventario = inventario.GetMovimientosKardexByMesXusuario(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)}, listaID, tipo, periodo, fechaInicio, fechaFin)
            Case "ALMACENID"
                listaInventario = inventario.GetMovimientosKardexByMesXusuario(New InventarioMovimiento With {.idAlmacen = idAlmacen, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)}, listaID, tipo, periodo, fechaInicio, fechaFin)
        End Select


        ListaNegativosKardex = New List(Of totalesAlmacen)
        ListaCantidadNegativa = New List(Of totalesAlmacen)
        ListaMontoNegativa = New List(Of totalesAlmacen)
        listaCostoVentaMayorAventa = New List(Of totalesAlmacen)
        For Each i As InventarioMovimiento In listaInventario
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
            producto = i.idItem
            productoCache = i.nombreItem

            'If CDec(dr(10)) < 0 Then
            If CDec(canSaldo) < 0 Then
                ListaNegativosKardex.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboalmacenKardex.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(10)) < 0 Then
                ListaCantidadNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboalmacenKardex.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(12)) < 0 Then
                ListaMontoNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboalmacenKardex.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(12)) > i.ValorDeVenta.GetValueOrDefault Then
                listaCostoVentaMayorAventa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                 .idAlmacen = i.idAlmacen,
                                                                 .NomAlmacen = cboalmacenKardex.Text,
                                                                 .descripcion = i.nombreItem,
                                                                 .importeSoles = i.ValorDeVenta})
            End If

            dt.Rows.Add(dr)
        Next
        dgvKardex2.DataSource = dt
        dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvKardex2.TopLevelGroupOptions.ShowCaption = True
        'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

    End Sub

    Public Sub GetKardexXFiltrosXActualizacion(strTipo As String)

        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitme As Decimal = 0
        Dim productoCache As String = Nothing
        Dim consulta As New List(Of InventarioMovimiento)
        Dim dt As New DataTable("kárdex - Período " & MonthName(txtPeriodo.Value.Month) & "-" & txtPeriodo.Value.Year)

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

        Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m

        Select Case strTipo
            Case "FILTRO"
                consulta = (From c In listaInventario Where c.tipoOperacion = cboTipoOperacion.SelectedValue).ToList
            Case "ACTUALIZACION"
                consulta = (From c In listaInventario Select c).ToList
        End Select


        ListaNegativosKardex = New List(Of totalesAlmacen)
        ListaCantidadNegativa = New List(Of totalesAlmacen)
        ListaMontoNegativa = New List(Of totalesAlmacen)
        listaCostoVentaMayorAventa = New List(Of totalesAlmacen)

        dgvKardex2.Table.Records.DeleteAll()

        For Each i As InventarioMovimiento In consulta
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
            producto = i.idItem
            productoCache = i.nombreItem

            'If CDec(dr(10)) < 0 Then
            If CDec(canSaldo) < 0 Then
                ListaNegativosKardex.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboalmacenKardex.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(10)) < 0 Then
                ListaCantidadNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboalmacenKardex.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(12)) < 0 Then
                ListaMontoNegativa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                  .idAlmacen = i.idAlmacen,
                                                                  .NomAlmacen = cboalmacenKardex.Text,
                                                                  .descripcion = i.nombreItem,
                                                                  .cantidad = i.cantidad})
            End If

            If CDec(dr(12)) > i.ValorDeVenta.GetValueOrDefault Then
                listaCostoVentaMayorAventa.Add(New totalesAlmacen With {.idItem = i.idItem,
                                                                 .idAlmacen = i.idAlmacen,
                                                                 .NomAlmacen = cboalmacenKardex.Text,
                                                                 .descripcion = i.nombreItem,
                                                                 .importeSoles = i.ValorDeVenta})
            End If

            dt.Rows.Add(dr)
        Next
        dgvKardex2.DataSource = dt
        dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvKardex2.TopLevelGroupOptions.ShowCaption = True
        'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

    End Sub

    Public Sub kardex()
        FormatoGrid(dgvKardex2)
        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.None
        pnInventario.Visible = False
        pnkardex.Dock = DockStyle.Fill
        pnkardex.Visible = True
        Panel12.Visible = True
    End Sub


    Sub ConsultasKardex()
        Dim strPeriodo As String = Nothing
        strPeriodo = periodo
        GetTableXperiodo(strPeriodo, listausuario, IntAnioGeneral)
    End Sub

    Private Sub movimientoXFiltroAndActualizacion(strTipo As String)
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitme As Decimal = 0
        Dim productoCache As String = Nothing
        Dim consulta As New List(Of documentoCaja)
        Dim dt As New DataTable("Movimientos período - " & PeriodoGeneral)
        Dim documentoCajaSA As New DocumentoCajaSA

        SaldoSoles = 0
        SaldoUSD = 0
        SaldoSolesNN = 0
        SaldoUSDNN = 0
        SaldoSolesNN1 = 0
        SaldoUSDNN1 = 0

        'Select Case txtMonedaKardex.Text

        '    Case "NACIONAL"
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer))) '0
        dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        'lower case p
        dt.Columns.Add(New DataColumn("UsuarioCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoUsuario", GetType(String))) '3
        dt.Columns.Add(New DataColumn("mov", GetType(String)))
        dt.Columns.Add(New DataColumn("item", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String))) '6
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String))) '8
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("entradaMN")) '10
        dt.Columns.Add(New DataColumn("entradaME"))
        dt.Columns.Add(New DataColumn("salidaMN")) '12
        dt.Columns.Add(New DataColumn("salidaME"))
        dt.Columns.Add(New DataColumn("saldoMN")) '14
        dt.Columns.Add(New DataColumn("saldoME"))
        dt.Columns.Add(New DataColumn("usuario")) '15
        dt.Columns.Add(New DataColumn("tipoOperacion")) '16
        dt.Columns.Add(New DataColumn("descripcionOperacion"))
        dt.Columns.Add(New DataColumn("origenIng"))

        dgvMovimiento.Table.TableDescriptor.Columns("moneda").Width = 0
        dgvMovimiento.Table.TableDescriptor.Columns("tipoCambio").Width = 0
        dgvMovimiento.Table.TableDescriptor.Columns("entradaME").Width = 0
        dgvMovimiento.Table.TableDescriptor.Columns("salidaME").Width = 0
        dgvMovimiento.Table.TableDescriptor.Columns("saldoME").Width = 0

        ImporteSaldo = 0
        ImporteSaldoME = 0
        'canSaldo = 0

        Select Case strTipo
            Case "FILTRO"
                consulta = (From c In listaDocCaja Where c.tipoOperacion = cbtipoOperacionMov.SelectedValue).ToList
            Case "ACTUALIZACION"
                consulta = (From c In listaDocCaja Select c).ToList
        End Select

        For Each i In consulta
            importeDeficit = 0
            importeDeficitme = 0

            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            dr(1) = i.fechaCobro
            dr(2) = i.dni
            dr(3) = i.tipousuario
            Select Case i.tipoMovimiento
                Case "DC"

                    If producto = i.IdEntidadFinanciera Then
                        productoCache = i.NombreCaja
                        ImporteSaldo += (i.montoSoles.GetValueOrDefault)
                        ImporteSaldoME += (i.montoUsd.GetValueOrDefault)
                    Else
                        importeDeficit = ImporteSaldo
                        importeDeficitme = ImporteSaldoME
                        ImporteSaldo = 0
                        ImporteSaldoME = 0
                        '    ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)
                        ImporteSaldo = saldoImporteAnual
                        ImporteSaldoME = saldoImporteAnualME
                        ImporteSaldo = (i.montoSoles.GetValueOrDefault) + ImporteSaldo
                        ImporteSaldoME = (i.montoUsd.GetValueOrDefault) + ImporteSaldoME
                    End If

                    dr(10) = (i.montoSoles)
                    dr(11) = (i.montoUsd)
                    dr(12) = 0
                    dr(13) = 0
                    dr(14) = (ImporteSaldo)
                    dr(15) = (ImporteSaldoME)


                    dr(4) = "ENTRADA"

                Case "PG"
                    Dim co As Decimal = 0
                    Dim come As Decimal = 0
                    co = CDec(i.montoSoles)
                    come = CDec(i.montoUsd)

                    If producto = i.IdEntidadFinanciera Then
                        productoCache = i.NombreCaja
                        ImporteSaldo -= co
                        ImporteSaldoME -= come
                    Else
                        importeDeficit = ImporteSaldo
                        importeDeficitme = ImporteSaldoME

                        ImporteSaldo = 0
                        ImporteSaldoME = 0
                        '   ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)

                        ImporteSaldo = saldoImporteAnual
                        ImporteSaldoME = saldoImporteAnualME

                        ImporteSaldo -= (i.montoSoles.GetValueOrDefault)
                        ImporteSaldoME -= (i.montoUsd.GetValueOrDefault)
                    End If
                    dr(10) = 0
                    dr(11) = 0
                    dr(12) = i.montoSoles.GetValueOrDefault
                    dr(13) = i.montoUsd.GetValueOrDefault
                    dr(14) = ImporteSaldo
                    dr(15) = ImporteSaldoME

                    dr(4) = "SALIDA"

            End Select
            dr(5) = i.DetalleItem
            dr(6) = i.tipoDocPago
            dr(7) = i.NumeroDocumento
            dr(8) = i.moneda

            If (Not IsNothing(i.tipoCambio)) Then
                dr(9) = i.tipoCambio
            Else
                dr(9) = i.difTipoCambio
            End If

            Dim nombreCompleto = (From a In listausuario Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

            dr(16) = nombreCompleto.Full_Name
            dr(17) = (i.tipoOperacion)
            dr(18) = (i.NombreOperacion)
            dr(19) = (i.NomCajaDestino)
            producto = CStr(i.IdEntidadFinanciera)
            productoCache = i.NombreCaja
            dt.Rows.Add(dr)
        Next
        dgvMovimiento.DataSource = dt

    End Sub



    Private Sub GetTableXperiodo(Periodo As String, listaID As List(Of Usuario), intAnio As Integer)
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitme As Decimal = 0
        Dim productoCache As String = Nothing

        Dim dt As New DataTable("Movimientos período - " & PeriodoGeneral)
        Dim documentoCajaSA As New DocumentoCajaSA

        SaldoSoles = 0
        SaldoUSD = 0
        SaldoSolesNN = 0
        SaldoUSDNN = 0
        SaldoSolesNN1 = 0
        SaldoUSDNN1 = 0

        Select Case txtMonedaKardex.Text

            Case "NACIONAL"
                dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer))) '0
                dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
                'lower case p
                dt.Columns.Add(New DataColumn("UsuarioCaja", GetType(String)))
                dt.Columns.Add(New DataColumn("tipoUsuario", GetType(String))) '3
                dt.Columns.Add(New DataColumn("mov", GetType(String)))
                dt.Columns.Add(New DataColumn("item", GetType(String)))
                dt.Columns.Add(New DataColumn("tipoDoc", GetType(String))) '6
                dt.Columns.Add(New DataColumn("numero", GetType(String)))
                dt.Columns.Add(New DataColumn("moneda", GetType(String))) '8
                dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("entradaMN")) '10
                dt.Columns.Add(New DataColumn("entradaME"))
                dt.Columns.Add(New DataColumn("salidaMN")) '12
                dt.Columns.Add(New DataColumn("salidaME"))
                dt.Columns.Add(New DataColumn("saldoMN")) '14
                dt.Columns.Add(New DataColumn("saldoME"))
                dt.Columns.Add(New DataColumn("usuario")) '15
                dt.Columns.Add(New DataColumn("tipoOperacion")) '16
                dt.Columns.Add(New DataColumn("descripcionOperacion"))

                dgvMovimiento.Table.TableDescriptor.Columns("moneda").Width = 0
                dgvMovimiento.Table.TableDescriptor.Columns("tipoCambio").Width = 0
                dgvMovimiento.Table.TableDescriptor.Columns("entradaME").Width = 0
                dgvMovimiento.Table.TableDescriptor.Columns("salidaME").Width = 0
                dgvMovimiento.Table.TableDescriptor.Columns("saldoME").Width = 0

                ImporteSaldo = 0
                ImporteSaldoME = 0
                'canSaldo = 0

                For Each i In documentoCajaSA.ObtenerCajaOnlineXUsuario(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), Periodo, cboEntidadFinanciera.SelectedValue, idPersonas, tipo, fechaInicio, fechaFin, intAnio)
                    importeDeficit = 0
                    importeDeficitme = 0

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.idDocumento
                    dr(1) = i.fechaCobro
                    dr(2) = i.dni
                    dr(3) = i.tipousuario
                    Select Case i.tipoMovimiento
                        Case "DC"

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo += (i.montoSoles.GetValueOrDefault)
                                ImporteSaldoME += (i.montoUsd.GetValueOrDefault)
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME
                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '    ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)
                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME
                                ImporteSaldo = (i.montoSoles.GetValueOrDefault) + ImporteSaldo
                                ImporteSaldoME = (i.montoUsd.GetValueOrDefault) + ImporteSaldoME
                            End If

                            dr(10) = (i.montoSoles)
                            dr(11) = (i.montoUsd)
                            dr(12) = 0
                            dr(13) = 0
                            dr(14) = (ImporteSaldo)
                            dr(15) = (ImporteSaldoME)


                            dr(4) = "ENTRADA"

                        Case "PG"
                            Dim co As Decimal = 0
                            Dim come As Decimal = 0
                            co = CDec(i.montoSoles)
                            come = CDec(i.montoUsd)

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo -= co
                                ImporteSaldoME -= come
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME

                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '   ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)

                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME

                                ImporteSaldo -= (i.montoSoles.GetValueOrDefault)
                                ImporteSaldoME -= (i.montoUsd.GetValueOrDefault)
                            End If
                            dr(10) = 0
                            dr(11) = 0
                            dr(12) = i.montoSoles.GetValueOrDefault
                            dr(13) = i.montoUsd.GetValueOrDefault
                            dr(14) = ImporteSaldo
                            dr(15) = ImporteSaldoME

                            dr(4) = "SALIDA"

                    End Select
                    dr(5) = i.DetalleItem
                    dr(6) = i.tipoDocPago
                    dr(7) = i.NumeroDocumento
                    dr(8) = i.moneda

                    If (Not IsNothing(i.tipoCambio)) Then
                        dr(9) = i.tipoCambio
                    Else
                        dr(9) = i.difTipoCambio
                    End If

                    Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

                    dr(16) = nombreCompleto.Full_Name
                    dr(17) = (i.tipoOperacion)
                    dr(18) = (i.NombreOperacion)
                    producto = CStr(i.IdEntidadFinanciera)
                    productoCache = i.NombreCaja
                    dt.Rows.Add(dr)
                Next
                dgvMovimiento.DataSource = dt
            Case "EXTRANJERA"
                dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
                dt.Columns.Add(New DataColumn("fecha", GetType(String)))
                'lower case p
                dt.Columns.Add(New DataColumn("UsuarioCaja", GetType(String)))
                dt.Columns.Add(New DataColumn("tipoUsuario", GetType(String)))
                dt.Columns.Add(New DataColumn("mov", GetType(String)))
                dt.Columns.Add(New DataColumn("item", GetType(String)))
                dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
                dt.Columns.Add(New DataColumn("numero", GetType(String)))
                dt.Columns.Add(New DataColumn("moneda", GetType(String)))
                dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("entradaMN")) '10
                dt.Columns.Add(New DataColumn("entradaME"))
                dt.Columns.Add(New DataColumn("salidaMN")) '12
                dt.Columns.Add(New DataColumn("salidaME"))
                dt.Columns.Add(New DataColumn("saldoMN")) '14
                dt.Columns.Add(New DataColumn("saldoME"))
                dt.Columns.Add(New DataColumn("tipoOperacion"))
                dt.Columns.Add(New DataColumn("descripcionOperacion"))
                dgvMovimiento.Table.TableDescriptor.Columns("moneda").Width = 0
                dgvMovimiento.Table.TableDescriptor.Columns("tipoCambio").Width = 80
                dgvMovimiento.Table.TableDescriptor.Columns("entradaME").Width = 90
                dgvMovimiento.Table.TableDescriptor.Columns("salidaME").Width = 90
                dgvMovimiento.Table.TableDescriptor.Columns("saldoME").Width = 90
                ImporteSaldo = 0
                ImporteSaldoME = 0

                For Each i In documentoCajaSA.ObtenerCajaOnlineXUsuario(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), Periodo, cboEntidadFinanciera.SelectedValue, idPersonas, tipo, fechaInicio, fechaFin, intAnio)
                    importeDeficit = 0
                    importeDeficitme = 0

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.idDocumento
                    dr(1) = i.fechaCobro
                    dr(2) = i.dni
                    dr(3) = i.tipousuario
                    Select Case i.tipoMovimiento
                        Case "DC"

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo += (i.montoSoles)
                                ImporteSaldoME += (i.montoUsd)
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME
                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '       ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)
                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME
                                ImporteSaldo = (i.montoSoles) + ImporteSaldo
                                ImporteSaldoME = (i.montoUsd) + ImporteSaldoME
                            End If

                            dr(10) = (i.montoSoles) '.ToString("N2")
                            dr(11) = (i.montoUsd) '.ToString("N2")
                            dr(12) = 0
                            dr(13) = 0
                            dr(14) = (ImporteSaldo) '.ToString("N2")
                            dr(15) = (ImporteSaldoME) '.ToString("N2")

                            dr(4) = "ENTRADA"

                        Case "PG"
                            Dim co As Decimal = 0
                            Dim come As Decimal = 0
                            co = CDec(i.montoSoles)
                            come = CDec(i.montoUsd)

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo -= co
                                ImporteSaldoME -= come
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME

                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '        ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)

                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME

                                ImporteSaldo -= (i.montoSoles.GetValueOrDefault)
                                ImporteSaldoME -= (i.montoUsd.GetValueOrDefault)
                            End If
                            dr(10) = 0
                            dr(11) = 0
                            dr(12) = (i.montoSoles)
                            dr(13) = (i.montoUsd)
                            dr(14) = (ImporteSaldo)
                            dr(15) = (ImporteSaldoME)
                            dr(4) = "SALIDA"



                    End Select
                    dr(5) = i.DetalleItem
                    dr(6) = i.tipoDocPago
                    dr(7) = i.NumeroDocumento
                    dr(8) = i.moneda

                    If (Not IsNothing(i.tipoCambio)) Then
                        dr(9) = i.tipoCambio
                    Else
                        dr(9) = i.difTipoCambio
                    End If

                    Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

                    dr(16) = nombreCompleto.Full_Name
                    dr(17) = (i.tipoOperacion)
                    dr(18) = (i.NombreOperacion)

                    producto = CStr(i.IdEntidadFinanciera)
                    productoCache = i.NombreCaja

                    dt.Rows.Add(dr)

                Next
                dgvMovimiento.DataSource = dt
        End Select

    End Sub

    Public Sub GetTableXMovimientoXInformeGeneral(Periodo As String, listaID As List(Of Usuario), idEstablec As Integer, tipo As String, fechaInicio As DateTime, fechaFin As DateTime, intAnio As Integer)
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitme As Decimal = 0
        Dim productoCache As String = Nothing

        Dim dt As New DataTable("Movimientos período - " & PeriodoGeneral)
        Dim documentoCajaSA As New DocumentoCajaSA

        SaldoSoles = 0
        SaldoUSD = 0
        SaldoSolesNN = 0
        SaldoUSDNN = 0
        SaldoSolesNN1 = 0
        SaldoUSDNN1 = 0

        'Select Case txtMonedaKardex.Text

        'Case "NACIONAL"
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer))) '0
        dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        'lower case p
        dt.Columns.Add(New DataColumn("UsuarioCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoUsuario", GetType(String))) '3
        dt.Columns.Add(New DataColumn("mov", GetType(String)))
        dt.Columns.Add(New DataColumn("item", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String))) '6
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String))) '8
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("entradaMN")) '10
        dt.Columns.Add(New DataColumn("entradaME"))
        dt.Columns.Add(New DataColumn("salidaMN")) '12
        dt.Columns.Add(New DataColumn("salidaME"))
        dt.Columns.Add(New DataColumn("saldoMN")) '14
        dt.Columns.Add(New DataColumn("saldoME"))
        dt.Columns.Add(New DataColumn("usuario")) '15
        dt.Columns.Add(New DataColumn("tipoOperacion")) '16
        dt.Columns.Add(New DataColumn("descripcionOperacion"))
        dt.Columns.Add(New DataColumn("origenIng"))

        dgvMovimiento.Table.TableDescriptor.Columns("moneda").Width = 0
        dgvMovimiento.Table.TableDescriptor.Columns("tipoCambio").Width = 0
        dgvMovimiento.Table.TableDescriptor.Columns("entradaME").Width = 0
        dgvMovimiento.Table.TableDescriptor.Columns("salidaME").Width = 0
        dgvMovimiento.Table.TableDescriptor.Columns("saldoME").Width = 0

        ImporteSaldo = 0
        ImporteSaldoME = 0
        'canSaldo = 0

        listaDocCaja = documentoCajaSA.ObtenerCajaOnlineXUsuario(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), Periodo, idEstablec, idPersonas, tipo, fechaInicio, fechaFin, intAnio)

        For Each i In listaDocCaja
            importeDeficit = 0
            importeDeficitme = 0

            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            dr(1) = i.fechaCobro
            dr(2) = i.dni
            dr(3) = i.tipousuario
            Select Case i.tipoMovimiento
                Case "DC"

                    If producto = i.IdEntidadFinanciera Then
                        productoCache = i.NombreCaja
                        ImporteSaldo += (i.montoSoles.GetValueOrDefault)
                        ImporteSaldoME += (i.montoUsd.GetValueOrDefault)
                    Else
                        importeDeficit = ImporteSaldo
                        importeDeficitme = ImporteSaldoME
                        ImporteSaldo = 0
                        ImporteSaldoME = 0
                        '    ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)
                        ImporteSaldo = saldoImporteAnual
                        ImporteSaldoME = saldoImporteAnualME
                        ImporteSaldo = (i.montoSoles.GetValueOrDefault) + ImporteSaldo
                        ImporteSaldoME = (i.montoUsd.GetValueOrDefault) + ImporteSaldoME
                    End If

                    dr(10) = (i.montoSoles)
                    dr(11) = (i.montoUsd)
                    dr(12) = 0
                    dr(13) = 0
                    dr(14) = (ImporteSaldo)
                    dr(15) = (ImporteSaldoME)


                    dr(4) = "ENTRADA"

                Case "PG"
                    Dim co As Decimal = 0
                    Dim come As Decimal = 0
                    co = CDec(i.montoSoles)
                    come = CDec(i.montoUsd)

                    If producto = i.IdEntidadFinanciera Then
                        productoCache = i.NombreCaja
                        ImporteSaldo -= co
                        ImporteSaldoME -= come
                    Else
                        importeDeficit = ImporteSaldo
                        importeDeficitme = ImporteSaldoME

                        ImporteSaldo = 0
                        ImporteSaldoME = 0
                        '   ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)

                        ImporteSaldo = saldoImporteAnual
                        ImporteSaldoME = saldoImporteAnualME

                        ImporteSaldo -= (i.montoSoles.GetValueOrDefault)
                        ImporteSaldoME -= (i.montoUsd.GetValueOrDefault)
                    End If
                    dr(10) = 0
                    dr(11) = 0
                    dr(12) = i.montoSoles.GetValueOrDefault
                    dr(13) = i.montoUsd.GetValueOrDefault
                    dr(14) = ImporteSaldo
                    dr(15) = ImporteSaldoME

                    dr(4) = "SALIDA"

            End Select
            dr(5) = i.DetalleItem
            dr(6) = i.tipoDocPago
            dr(7) = i.NumeroDocumento
            dr(8) = i.moneda

            If (Not IsNothing(i.tipoCambio)) Then
                dr(9) = i.tipoCambio
            Else
                dr(9) = i.difTipoCambio
            End If

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

            dr(16) = nombreCompleto.Full_Name
            dr(17) = (i.tipoOperacion)
            dr(18) = (i.NombreOperacion)
            dr(19) = (i.NomCajaDestino)
            producto = CStr(i.IdEntidadFinanciera)
            productoCache = i.NombreCaja
            dt.Rows.Add(dr)
        Next
        dgvMovimiento.DataSource = dt

    End Sub

    Public Sub GetMovPorPeriodo(tipo As String, estado As String, descripcion As String, ListacajausuarioXCuentasXcompra As List(Of documentocompra), listaID As List(Of Usuario))
        Dim dt As New DataTable("Movimientos")
        Dim documentoCajaOBJ As New List(Of documentocompra)

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
        dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))

        If (estado = "CMP") Then
            documentoCajaOBJ = (From a In ListacajausuarioXCuentasXcompra Where (a.tipoCompra) = estado).ToList
        ElseIf (estado = "TEAR") Then
            documentoCajaOBJ = (From a In ListacajausuarioXCuentasXcompra Where (a.tipoCompra) = "TEA" And a.estadoEntrega = "DC").ToList
        ElseIf (estado = "TEA") Then
            documentoCajaOBJ = (From a In ListacajausuarioXCuentasXcompra Where (a.tipoCompra) = "TEA" And a.estadoEntrega = "PN" Or a.estadoEntrega = "DC").ToList
        Else
            documentoCajaOBJ = (From a In ListacajausuarioXCuentasXcompra Where (a.tipoCompra) = estado).ToList
        End If


        Dim str As String
        For Each i As documentocompra In documentoCajaOBJ
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento

            dr(1) = descripcion
            'Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
            '    dr(1) = "ENTRADA DE EXISTENCIAS"
            'Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS
            '    dr(1) = "SALIDA DE EXISTENCIAS"

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

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

            dr(14) = nombreCompleto.Full_Name
            dt.Rows.Add(dr)

        Next
        dgvMov.DataSource = dt
        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.Fill
        pnInventario.Visible = True

    End Sub

    'Public Sub GetMovPorPeriodoRecepcion(tipo As String, estado As String, descripcion As String, listaPersonaID As List(Of String), ListacajausuarioXCuentasXcompra As List(Of documentocompradetalle), listaID As List(Of Usuario))
    '    Dim dt As New DataTable("Movimientos")
    '    Dim documentoCajaOBJ As New List(Of documentocompra)

    '    dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("destino", GetType(String)))
    '    'lower case p
    '    dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
    '    dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
    '    dt.Columns.Add(New DataColumn("serie", GetType(String)))
    '    dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

    '    dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
    '    dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
    '    dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
    '    dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

    '    dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

    '    dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
    '    dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))


    '    Dim compraTransferenciaRecepcion = (From a In ListacajausuarioXCuentasXcompra Where a.tipoCompra = TIPO_COMPRA.TRANSFERENCIA_ENTRE_ALMACEN _
    '                   And a.estadoPago = "DC" And listaPersonaID.Contains(a.usuarioModificacion))



    '    Dim str As String
    '    For Each i As documentocompradetalle In compraTransferenciaRecepcion
    '        Dim dr As DataRow = dt.NewRow()
    '        str = Nothing
    '        str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
    '        dr(0) = i.idDocumento

    '        dr(1) = descripcion
    '        'Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
    '        '    dr(1) = "ENTRADA DE EXISTENCIAS"
    '        'Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS
    '        '    dr(1) = "SALIDA DE EXISTENCIAS"

    '        dr(2) = str
    '        dr(3) = i.TipoDoc
    '        dr(4) = i.Serie
    '        dr(5) = i.NumDoc
    '        dr(6) = i.TipoDoc
    '        dr(7) = i.entregable
    '        dr(8) = i.NombreProveedor
    '        dr(9) = i.TipoRegistro
    '        dr(10) = i.importe
    '        dr(11) = i.tipoCambio
    '        dr(12) = i.importeUS
    '        dr(13) = i.Moneda

    '        Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

    '        dr(14) = nombreCompleto.Full_Name
    '        dt.Rows.Add(dr)

    '    Next
    '    dgvMov.DataSource = dt
    '    Panel10.Dock = DockStyle.None
    '    Panel10.Visible = False
    '    pnInventario.Dock = DockStyle.Fill
    '    pnInventario.Visible = True

    'End Sub


    Public Sub GetMovPorPeriodoTransito(periodo As String, movimiento As String, tipo As String, listaUsuario As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, listaID As List(Of Usuario))
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Período:  ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal"))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS"))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))

        dt.Columns.Add("detraccion")
        dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))


        Dim listaCompra As New List(Of String)
        listaCompra.Add(TIPO_COMPRA.COMPRA)
        listaCompra.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        listaCompra.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        'listaCompra.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        'listaCompra.Add(TIPO_COMPRA.OTRAS_SALIDAS)

        'Dim ventaCreditoPOS = (From a In ListacajausuarioXCuentasXcompra Where listaCompra.Contains(a.tipoCompra)).ToList

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarComprasTransitoInfGeneral(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, periodo, listaCompra, tipo, listaUsuario, fechaInicio, fechaFin)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = TIPO_COMPRA.COMPRA_TRANSITO
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.numeroDoc
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona

            If i.tipoCompra = "BOFR" Then
                dr(10) = CDec(0.0)
                dr(11) = CDec(0.0)
                dr(12) = CDec(0.0)
            Else
                dr(10) = CDec(i.importeTotal).ToString("N2")
                dr(11) = i.tcDolLoc
                dr(12) = i.importeUS
            End If

            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select

            Select Case i.aprobado
                Case "S"
                    dr(17) = "Aprobado"
                Case Else
                    dr(17) = "Pendiente"
            End Select
            dr(18) = i.Atraso
            dr(19) = If(i.tieneDetraccion = "S", "Si", "No")

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

            dr(20) = nombreCompleto.Full_Name

            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt
        dgvCompras.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        dgvCompras.TopLevelGroupOptions.ShowCaption = True

        Panel10.Dock = DockStyle.Fill
        Panel10.Visible = True
        pnInventario.Dock = DockStyle.None
        pnInventario.Visible = False


        'Dim dt As New DataTable("Movimientos")
        'Dim documentoCajaOBJ As New List(Of documentocompra)
        'Dim consultaSA As New DocumentoCompraSA

        'dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("destino", GetType(String)))
        ''lower case p
        'dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        'dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        'dt.Columns.Add(New DataColumn("serie", GetType(String)))
        'dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        'dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        'dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        'dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        'dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))

        'Dim listaCompra As New List(Of String)
        'listaCompra.Add(TIPO_COMPRA.COMPRA)
        'listaCompra.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        'listaCompra.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)

        'Dim str As String
        'For Each i In consultaSA.GetListarComprasTransitoInfGeneral(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, periodo, listaCompra, tipo, listausuario, fechaInicio, fechaFin)
        '    Dim dr As DataRow = dt.NewRow()
        '    str = Nothing
        '    str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
        '    dr(0) = i.IdDocumento

        '    dr(1) = "COMPRAS EN TRANSITO"

        '    dr(2) = str
        '    dr(3) = i.tipoDoc
        '    dr(4) = i.serie
        '    dr(5) = i.numeroDoc
        '    dr(6) = i.tipoDoc
        '    dr(7) = i.numeroDoc
        '    dr(8) = i.NombreEntidad
        '    dr(9) = i.TipoPersona
        '    dr(10) = i.importeTotal
        '    dr(11) = i.tcDolLoc
        '    'dr(12) = i.Column2
        '    dr(13) = i.monedaDoc

        '    Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

        '    dr(14) = nombreCompleto.Full_Name
        '    dt.Rows.Add(dr)

        'Next
        'dgvMov.DataSource = dt
        'Panel10.Dock = DockStyle.None
        'Panel10.Visible = False
        'pnInventario.Dock = DockStyle.Fill
        'pnInventario.Visible = True

    End Sub


    Public Sub GetMovPorPeriodoTransitoRecep(periodo As String, movimiento As String, tipo As String, listaUsuario As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, listaID As List(Of Usuario))
        Dim dt As New DataTable("Movimientos")
        Dim documentoCajaOBJ As New List(Of documentocompra)
        Dim consultaSA As New DocumentoCompraSA

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
        dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))

        Dim listaCompra As New List(Of String)
        listaCompra.Add(TIPO_COMPRA.COMPRA)
        listaCompra.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        listaCompra.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)

        Dim str As String
        For Each i In consultaSA.GetListarComprasTransitoInfGeneralRecepcion(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, periodo, listaCompra, tipo, listausuario, fechaInicio, fechaFin)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.IdDocumento

            dr(1) = "COMPRAS EN TRANSITO - RECEPCION"

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDoc
            dr(7) = i.numeroDoc
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            'dr(12) = i.Column2
            dr(13) = i.monedaDoc

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

            dr(14) = nombreCompleto.Full_Name
            dt.Rows.Add(dr)

        Next
        dgvMov.DataSource = dt
        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.Fill
        pnInventario.Visible = True

    End Sub

    Public Sub GetMovPorPeriodoTransferenciaRecep(periodo As String, movimiento As String, tipo As String, listaUsuario As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, listaID As List(Of Usuario))
        Dim dt As New DataTable("Movimientos")
        Dim documentoCajaOBJ As New List(Of documentocompra)
        Dim consultaSA As New DocumentoCompraSA

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
        dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))

        Dim listaCompra As New List(Of String)
        listaCompra.Add(TIPO_COMPRA.TRANSFERENCIA_ENTRE_ALMACEN)


        Dim str As String
        For Each i In consultaSA.GetListarTransferenciaRecepcionInfGeneral(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, periodo, listaCompra, tipo, listaUsuario, fechaInicio, fechaFin)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento

            dr(1) = "TRANSFERENCIA ENTRE ALMACENES - RECEPCION"

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDoc
            dr(7) = i.numeroDoc
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            'dr(12) = i.Column2
            dr(13) = i.monedaDoc

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

            dr(14) = nombreCompleto.Full_Name
            dt.Rows.Add(dr)

        Next
        dgvMov.DataSource = dt
        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.Fill
        pnInventario.Visible = True

    End Sub

    Public Sub GetMovPorPeriodoTransferencia(periodo As String, movimiento As String, tipo As String, listaUsuario As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, listaID As List(Of Usuario))
        Dim dt As New DataTable("Movimientos")
        Dim documentoCajaOBJ As New List(Of documentocompra)
        Dim consultaSA As New DocumentoCompraSA

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
        dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))

        Dim listaCompra As New List(Of String)
        listaCompra.Add(TIPO_COMPRA.TRANSFERENCIA_ENTRE_ALMACEN)


        Dim str As String
        For Each i In consultaSA.GetListarTransferenciaInfGeneral(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, periodo, listaCompra, tipo, listaUsuario, fechaInicio, fechaFin)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento

            dr(1) = "TRANSFERENCIA ENTRE ALMACENES"

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDoc
            dr(7) = i.numeroDoc
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            'dr(12) = i.Column2
            dr(13) = i.monedaDoc

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

            dr(14) = nombreCompleto.Full_Name
            dt.Rows.Add(dr)

        Next
        dgvMov.DataSource = dt
        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.Fill
        pnInventario.Visible = True

    End Sub

    Public Sub GetMovPorPeriodoOtrasEntradas(periodo As String, movimiento As String, tipo As String, listaUsuario As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, listaID As List(Of Usuario))
        Dim dt As New DataTable("Movimientos")
        Dim documentoCajaOBJ As New List(Of documentocompra)
        Dim consultaSA As New DocumentoCompraSA

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
        dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))

        Dim listaCompra As New List(Of String)
        listaCompra.Add(TIPO_COMPRA.OTRAS_ENTRADAS)

        Dim str As String
        For Each i In consultaSA.GetListarTransferenciaInfGeneral(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, periodo, listaCompra, tipo, listaUsuario, fechaInicio, fechaFin)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento

            dr(1) = "OTRAS ENTRADAS A ALMACEN"

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDoc
            dr(7) = i.numeroDoc
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            'dr(12) = i.Column2
            dr(13) = i.monedaDoc

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

            dr(14) = nombreCompleto.Full_Name
            dt.Rows.Add(dr)

        Next
        dgvMov.DataSource = dt
        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.Fill
        pnInventario.Visible = True

    End Sub

    Public Sub GetMovPorPeriodoOtrasSalidas(periodo As String, movimiento As String, tipo As String, listaUsuario As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, listaID As List(Of Usuario))
        Dim dt As New DataTable("Movimientos")
        Dim documentoCajaOBJ As New List(Of documentocompra)
        Dim consultaSA As New DocumentoCompraSA

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
        dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))

        Dim listaCompra As New List(Of String)
        listaCompra.Add(TIPO_COMPRA.OTRAS_SALIDAS)

        Dim str As String
        For Each i In consultaSA.GetListarTransferenciaInfGeneral(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, periodo, listaCompra, tipo, listaUsuario, fechaInicio, fechaFin)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento

            dr(1) = "OTRAS SALIDAS DE ALMACEN"

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDoc
            dr(7) = i.numeroDoc
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            'dr(12) = i.Column2
            dr(13) = i.monedaDoc

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

            dr(14) = nombreCompleto.Full_Name
            dt.Rows.Add(dr)

        Next
        dgvMov.DataSource = dt
        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.Fill
        pnInventario.Visible = True

    End Sub
   
    Public Sub getTableComprasPorPeriodoContado(periodo As String, movimiento As String, tipo As String, listaUsuario As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, listaID As List(Of Usuario))
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Período:  ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal"))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS"))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))

        dt.Columns.Add("detraccion")
        dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))


        Dim listaCompra As New List(Of String)
        listaCompra.Add(TIPO_COMPRA.COMPRA)
        listaCompra.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        listaCompra.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        'listaCompra.Add(TIPO_COMPRA.OTRAS_ENTRADAS)
        'listaCompra.Add(TIPO_COMPRA.OTRAS_SALIDAS)

        'Dim ventaCreditoPOS = (From a In ListacajausuarioXCuentasXcompra Where listaCompra.Contains(a.tipoCompra)).ToList

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarComprasPorPeriodoGeneralInfGeneral(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, periodo, listaCompra, tipo, listaUsuario, fechaInicio, fechaFin)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.numeroDoc
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona

            If i.tipoCompra = "BOFR" Then
                dr(10) = CDec(0.0)
                dr(11) = CDec(0.0)
                dr(12) = CDec(0.0)
            Else
                dr(10) = CDec(i.importeTotal).ToString("N2")
                dr(11) = i.tcDolLoc
                dr(12) = i.importeUS
            End If



            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select

            Select Case i.aprobado
                Case "S"
                    dr(17) = "Aprobado"
                Case Else
                    dr(17) = "Pendiente"
            End Select
            dr(18) = i.Atraso
            dr(19) = If(i.tieneDetraccion = "S", "Si", "No")

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

            dr(20) = nombreCompleto.Full_Name

            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt
        dgvCompras.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        dgvCompras.TopLevelGroupOptions.ShowCaption = True

        Panel10.Dock = DockStyle.Fill
        Panel10.Visible = True
        pnInventario.Dock = DockStyle.None
        pnInventario.Visible = False
    End Sub

    Public Sub GetListaVentasPorPeriodo(periodo As String, movimiento As String, tipo As String, listaUsuario As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, listaID As List(Of Usuario), tipoVenta As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim ventaCreditoPOS As New List(Of documentoventaAbarrotes)
        Dim dt As New DataTable("")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))
        Dim str As String



        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasInformeGeneral(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, periodo, movimiento, tipo, listaUsuario, fechaInicio, fechaFin, tipoVenta)

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
            End Select
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"
                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

            dr(16) = nombreCompleto.Full_Name

            dt.Rows.Add(dr)
        Next
        dgPedidos.DataSource = dt

        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.None
        pnInventario.Visible = False
        Panel2.Dock = DockStyle.Fill
        Panel2.Visible = True
    End Sub

    Public Sub GetListaVentasPorPeriodoCajaCentralizado(tipo As String, estado As String, ListacajausuarioDetalleTE As List(Of documentoventaAbarrotes), listaID As List(Of Usuario))
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim ventaCreditoPOS As New List(Of documentoventaAbarrotes)
        Dim dt As New DataTable("")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioOperacion", GetType(String)))
        Dim str As String

        Select Case tipo
            Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                ventaCreditoPOS = (From a In ListacajausuarioDetalleTE Where a.tipoVenta = tipo _
                   Or a.tipoVenta = "VTK").ToList
            Case Else
                ventaCreditoPOS = (From a In ListacajausuarioDetalleTE Where a.tipoVenta = tipo _
                    And a.estadoCobro = estado).ToList
        End Select


        For Each i As documentoventaAbarrotes In ventaCreditoPOS

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
            End Select
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"
                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select

            Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioActualizacion).FirstOrDefault

            dr(16) = nombreCompleto.Full_Name

            dt.Rows.Add(dr)
        Next
        dgPedidos.DataSource = dt

        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.None
        pnInventario.Visible = False
        Panel2.Dock = DockStyle.Fill
        Panel2.Visible = True
    End Sub


    Public Sub GetMovimientosPeriodo(intAnio As Integer, intMes As Integer, movimiento As String, tipo As String, listaUsuario As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, listaID As List(Of Usuario))
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim ListaCaja As New List(Of documentoCaja)
        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA
        'Dim idCaja As Integer

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))

        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles"))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd"))

        dt.Columns.Add(New DataColumn("NomCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NomCajaDestino", GetType(String)))
        dt.Columns.Add(New DataColumn("UsuarioOperacion", GetType(String)))

        Dim str As String

        'Select Case tipo
        '    Case "ALL"
        '        ListaCaja = (From a In ListacajausuarioXEntidadFinanciera).ToList
        '    Case Else
        '        ListaCaja = (From a In ListacajausuarioXEntidadFinanciera Where (a.movimientoCaja) = tipo).ToList
        'End Select

        listaDocCaja = documentoCajaSA.ObtenerMovimientosPorPeriodoFinanzasInforGeneral(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intAnio, intMes, movimiento, tipo, listaUsuario, fechaInicio, fechaFin)

        For Each i As documentoCaja In listaDocCaja

            Select Case i.movimientoCaja
                Case "TEC"
                    If i.tipoMovimiento = "PG" Then
                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                        dr(0) = i.idDocumento
                        dr(1) = i.tipoOperacion
                        dr(3) = str
                        Select Case i.movimientoCaja
                            Case "OEC"
                                dr(2) = "OTRAS ENTRADA DE CAJA"
                            Case "OSC"
                                dr(2) = "OTRAS SALIDA DE CAJA"
                            Case "TEC"
                                dr(2) = "TRANSFERENCIA ENTRE CAJAS"
                        End Select
                        dr(3) = str

                        dr(4) = i.numeroOperacion
                        Select Case i.moneda
                            Case 1
                                dr(5) = "NACIONAL"
                            Case 2
                                dr(5) = "EXTRANJERA"
                        End Select
                        dr(6) = FormatNumber(i.montoSoles, 2)
                        dr(7) = i.tipoCambio
                        dr(8) = FormatNumber(i.montoUsd, 2)
                        dr(9) = i.NomCajaOrigen
                        dr(10) = i.NomCajaDestino
                        Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

                        dr(11) = nombreCompleto.Full_Name
                        dt.Rows.Add(dr)
                    End If
                Case "OEC"
                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    Select Case i.movimientoCaja
                        Case "OEC"
                            dr(2) = "OTRAS ENTRADA DE CAJA"
                    End Select
                    dr(3) = str
                    dr(4) = i.numeroOperacion
                    Select Case i.moneda
                        Case 1
                            dr(5) = "NACIONAL"
                        Case 1
                            dr(5) = "NACIONAL"
                    End Select
                    dr(6) = CDec(i.montoSoles).ToString("N2")
                    dr(7) = i.tipoCambio
                    dr(8) = CDec(i.montoUsd).ToString("N2")
                    dr(9) = "-"
                    dr(10) = i.NomCajaOrigen

                    Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

                    dr(11) = nombreCompleto.Full_Name
                    dt.Rows.Add(dr)

                Case "OSC"

                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    Select Case i.movimientoCaja
                        Case "OSC"
                            dr(2) = "OTRAS SALIDA DE CAJA"
                    End Select
                    dr(3) = str
                    dr(4) = i.movimientoCaja
                    Select Case i.moneda
                        Case 2
                            dr(5) = "EXTRANJERA"
                        Case 1
                            dr(5) = "NACIONAL"
                    End Select
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = i.NomCajaOrigen
                    dr(10) = "-"
                    Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

                    dr(11) = nombreCompleto.Full_Name
                    dt.Rows.Add(dr)

                Case "AR"

                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    Select Case i.movimientoCaja
                        Case "AR"
                            dr(2) = "ANTICIPO RECIBIDOS"
                    End Select
                    dr(3) = str
                    dr(4) = i.movimientoCaja
                    Select Case i.moneda
                        Case 2
                            dr(5) = "EXTRANJERA"
                        Case 1
                            dr(5) = "NACIONAL"
                    End Select
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = i.NomCajaOrigen
                    dr(10) = "-"
                    Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

                    dr(11) = nombreCompleto.Full_Name
                    dt.Rows.Add(dr)

                Case "IPV"

                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = "CAJA CENTRALIZADA"
                    dr(3) = str
                    dr(4) = i.movimientoCaja
                    Select Case i.moneda
                        Case 2
                            dr(5) = "EXTRANJERA"
                        Case 1
                            dr(5) = "NACIONAL"
                    End Select
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = i.NomCajaOrigen
                    dr(10) = "-"
                    Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

                    dr(11) = nombreCompleto.Full_Name
                    dt.Rows.Add(dr)

                Case Else

                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = "INGRESO POR VENTAS"
                    dr(3) = str
                    dr(4) = i.movimientoCaja
                    Select Case i.moneda
                        Case 2
                            dr(5) = "EXTRANJERA"
                        Case 1
                            dr(5) = "NACIONAL"
                    End Select
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = i.NomCajaOrigen
                    dr(10) = "-"
                    Dim nombreCompleto = (From a In listaID Where a.IDUsuario = i.usuarioModificacion).FirstOrDefault

                    dr(11) = nombreCompleto.Full_Name
                    dt.Rows.Add(dr)
            End Select

        Next

        dgvOtrosMov.DataSource = dt

        Panel10.Dock = DockStyle.None
        Panel10.Visible = False
        pnInventario.Dock = DockStyle.None
        pnInventario.Visible = False
        Panel2.Dock = DockStyle.None
        Panel2.Visible = False
        pnFinanzas.Dock = DockStyle.Fill
        pnFinanzas.Visible = True

    End Sub

#End Region

#Region "Events"

#End Region

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles tsbCompras.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        If dgvCompras.Table.Records.Count > 0 Then
            If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                Select Case Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra")
                    Case TIPO_COMPRA.COMPRA, TIPO_COMPRA.COMPRA_PAGADA
                        Dim f As New frmEditcompra(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.WindowState = FormWindowState.Normal
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()

                    Case TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                        Dim f As New frmReciboHonorarios(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.WindowState = FormWindowState.Normal
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.ShowDialog()

                    Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO
                        Dim f As New frmServicioPublico(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.WindowState = FormWindowState.Normal
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.ShowDialog()

                    Case TIPO_COMPRA.COMPRA_TRANSITO  'FALTA METODO ELIMINAR
                        Dim f As New frmEditcompra()
                        f.WindowState = FormWindowState.Normal
                        f.UbicarDocumentoTransito(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()

                        'Case TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA  'FALTA METODO ELIMINAR
                        '    Dim f As New frmCompraAnticipada(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        '    f.WindowState = FormWindowState.Normal
                        '    f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        '    f.StartPosition = FormStartPosition.CenterParent
                        '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        '    f.ShowDialog()

                End Select
            Else
                MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles tsbOtrosMovimiento.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "TRANSFERENCIA(S) A OTRO (S) ALMACENE(S)" _
                Or Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "RECEPCION DE INVENTARIO EN TRANSITO POR TRANSFERENCIAS" Then ' TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES Then
                With frmMovimientoAlmacen
                    .btGrabar.Enabled = False
                    .ToolStripButton1.Enabled = False
                    .GuardarToolStripButton.Enabled = False
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    .StartPosition = FormStartPosition.CenterParent
                    .WindowState = FormWindowState.Normal
                    .ShowDialog()
                End With '
            ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "OTROS INGRESOS A ALMACÉN" Then
                With frmMovOtrasEntradas
                    .btGrabar.Enabled = False
                    .GuardarToolStripButton.Enabled = True
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    .WindowState = FormWindowState.Normal
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "OTRAS SALIDAS DE ALMACÉN" Then
                With frmOtrasSalidasDeAlmacen
                    .btGrabar.Enabled = False
                    .GuardarToolStripButton.Enabled = True
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    .WindowState = FormWindowState.Normal
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LoadingAnimator.UnWire(Me.dgvMov.TableControl)
        End If
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
            Select Case dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
                Case TIPO_VENTA.VENTA_GENERAL
                    Dim f As New frmVenta(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()
                Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                    Dim f As New frmVentaPV(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()
                Case TIPO_VENTA.VENTA_POS_DIRECTA
                    Dim f As New frmVentaPVdirecta(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()
                Case TIPO_VENTA.VENTA_AL_TICKET
                    Dim f As New frmVentaPV(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.WindowState = FormWindowState.Maximized
                    f.ShowDialog()
            End Select
        Else
            MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim movimiento As String

        If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then
            movimiento = Me.dgvOtrosMov.Table.CurrentRecord.GetValue("movimiento")
            If Me.dgvOtrosMov.Table.CurrentRecord.GetValue("movimiento") = "9909" Then
                Dim f As New frmEntradaSalidaCaja(StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO)

                '.Panel6.Visible = False
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.UbicarDocumento(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()


            ElseIf Me.dgvOtrosMov.Table.CurrentRecord.GetValue("movimiento") = "OTRAS SALIDA DE CAJA" Then
                Dim f As New frmEntradaSalidaCaja(StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO)
                '.Panel6.Visible = False
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.UbicarDocumento(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()


            ElseIf Me.dgvOtrosMov.Table.CurrentRecord.GetValue("movimiento") = "ANTICIPO RECIBIDOS" Then
                Dim f As New frmAnticiposModal(StatusTipoOperacion.ANTICIPOS_RECIBIDOS)
                '.Panel6.Visible = False
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.UbicarDocumento(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

            ElseIf Me.dgvOtrosMov.Table.CurrentRecord.GetValue("movimiento") = "ANTICIPO OTORGADOS" Then
                Dim f As New frmAnticiposModal(StatusTipoOperacion.ANTICIPOS_OTORGADOS)
                '.Panel6.Visible = False
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.UbicarDocumento(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

            ElseIf Me.dgvOtrosMov.Table.CurrentRecord.GetValue("movimiento") = "APORTES" Then
                With frmAporte
                    '.Panel6.Visible = False
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If


        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        LoadingAnimator.Wire(dgvKardex2.TableControl)
        Try
            GetKardexByAnio("ALMACEN", idPersonas, tipo, periodo, fechaInicio, fechaFin, Nothing)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        LoadingAnimator.UnWire(dgvKardex2.TableControl)
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        dgvKardex2.Table.Records.DeleteAll()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo2(CuentaFinanciera.Efectivo)
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo2(CuentaFinanciera.Banco)
        ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo2(CuentaFinanciera.Tarjeta_Credito)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        If (cboEntidadFinanciera.Text.Length > 0) Then
            ConsultasKardex()
        Else
            MessageBox.Show("Debe seleccionar una entidad financiera!")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub cboEntidadFinanciera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntidadFinanciera.SelectedIndexChanged
        dgvKardex2.Table.Records.DeleteAll()

        Dim cod = cboEntidadFinanciera.SelectedValue

        If IsNumeric(cod) Then
            If (Not IsNothing(ListaEstadoFinancierosMaster)) Then
                Dim conusulta = (From a In ListaEstadoFinancierosMaster Where a.idestado = cod Select a).FirstOrDefault
                If (Not IsNothing(conusulta)) Then
                    txtMonedaKardex.Text = conusulta.codigo
                End If
            End If
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Select Case cboTipoOperacion.Text
            Case "TODO"
                GetKardexXFiltrosXActualizacion("ACTUALIZACION")
            Case Else
                GetKardexXFiltrosXActualizacion("FILTRO")
        End Select
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Select Case cbtipoOperacionMov.Text
            Case "TODO"
                movimientoXFiltroAndActualizacion("ACTUALIZACION")
            Case Else
                movimientoXFiltroAndActualizacion("FILTRO")
        End Select

    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        GetKardexXFiltrosXActualizacion("ACTUALIZACION")
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        movimientoXFiltroAndActualizacion("ACTUALIZACION")
    End Sub

End Class
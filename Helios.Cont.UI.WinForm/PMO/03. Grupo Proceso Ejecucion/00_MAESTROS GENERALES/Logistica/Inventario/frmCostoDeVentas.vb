Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid

Public Class frmCostoDeVentas
    Inherits frmMaster

    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0
    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

#Region "Constructor"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCostoVenta, True, False)

        txtPeriodo.Value = DiaLaboral
        txtPeriodo.Visible = True
        'GetCostoVenta(anio, mes)
    End Sub

#End Region


#Region "Métodos"

    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            dgvCostoVenta.DataSource = table
            lblMercaderia.Text = TotalMercaderia
            lblProductoTerminado.Text = TotalProductoTerminado
            lblSubProducto.Text = TotalSubProductosTerminados
            ProgressBar1.Visible = False
        End If
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
        Dim codigoLotex As Integer = 0
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
                End Select

                producto = i.idItem
                codigoLotex = i.customLote.codigoLote
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
                                         .nrolote = i.customLote.codigoLote,
                                         .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault})
            Next
        Next
        CargarCostoVenta(NuevaListaInventario)
    End Sub



    Dim TotalMercaderia As Decimal = CDec(0.0)
    Dim TotalProductoTerminado As Decimal = CDec(0.0)
    Dim TotalSubProductosTerminados As Decimal = CDec(0.0)

    Sub CargarCostoVenta(lista As List(Of InventarioMovimiento))
        Dim documentoSA As New DocumentoSA
        Dim dt As New DataTable
        Dim listaTipoExistencia As New List(Of String)
        listaTipoExistencia.Add(TipoExistencia.Mercaderia)
        listaTipoExistencia.Add(TipoExistencia.ProductoTerminado)
        listaTipoExistencia.Add(TipoExistencia.SubProductosDesechos)

        TotalMercaderia = CDec(0.0)
        TotalProductoTerminado = CDec(0.0)
        TotalSubProductosTerminados = CDec(0.0)


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
        dt.Columns.Add("codigoLote")
        For Each i In consulta
            If i.tipoOperacion = "9916" Then
                Dim documentoOperacion = documentoSA.UbicarDocumento(i.idDocumentoRef)
                Select Case documentoOperacion.tipoOperacion
                    Case StatusTipoOperacion.COMPRA

                    Case StatusTipoOperacion.VENTA
                        dt.Rows.Add(i.idDocumentoRef,
                                        i.tipoOperacion,
                                        i.idAlmacen,
                                        i.idItem,
                                        i.descripcion,
                                        i.tipoExistencia,
                                        i.unidad,
                                        i.monto * -1,
                                        i.ValorDeVenta.GetValueOrDefault * -1,
                                        (i.ValorDeVenta.GetValueOrDefault - i.monto) * -1,
                                    i.nrolote)

                        If i.tipoExistencia = TipoExistencia.Mercaderia Then
                            TotalMercaderia -= i.monto
                        ElseIf i.tipoExistencia = TipoExistencia.ProductoTerminado Then
                            TotalProductoTerminado -= i.monto
                        ElseIf i.tipoExistencia = TipoExistencia.SubProductosDesechos Then
                            TotalSubProductosTerminados -= i.monto
                        End If
                End Select

            Else
                dt.Rows.Add(i.idDocumentoRef,
                        i.tipoOperacion,
                        i.idAlmacen,
                        i.idItem,
                        i.descripcion,
                        i.tipoExistencia,
                        i.unidad,
                        i.monto,
                        i.ValorDeVenta.GetValueOrDefault,
                        (i.ValorDeVenta.GetValueOrDefault - i.monto), i.nrolote)

                If i.tipoExistencia = TipoExistencia.Mercaderia Then
                    TotalMercaderia += i.monto
                ElseIf i.tipoExistencia = TipoExistencia.ProductoTerminado Then
                    TotalProductoTerminado += i.monto
                ElseIf i.tipoExistencia = TipoExistencia.SubProductosDesechos Then
                    TotalSubProductosTerminados += i.monto
                End If

            End If



        Next

        setDataSource(dt)

    End Sub

    'Private Sub setDataSource(ByVal table As DataTable)
    '    If Me.InvokeRequired Then
    '        'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

    '        Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
    '        Invoke(deleg, New Object() {table})
    '    Else
    '        dgvCostoVenta.DataSource = table
    '        ProgressBar1.Visible = False
    '    End If
    'End Sub
    Sub FormatoGridAvanzado(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FullRowSelect = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

#End Region


    Private Sub frmCostoDeVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetCostoVenta(txtPeriodo.Value.Year, txtPeriodo.Value.Month)))
        thread.Start()
    End Sub
End Class
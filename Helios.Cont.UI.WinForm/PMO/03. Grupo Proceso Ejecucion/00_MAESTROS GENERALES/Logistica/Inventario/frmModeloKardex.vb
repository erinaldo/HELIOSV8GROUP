Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.GroupingGridExcelConverter

Public Class frmModeloKardex

#Region "Attributes"
    Dim almacenSA As New almacenSA
    Dim tablaSA As New tablaDetalleSA
    Dim inventario As New inventarioMovimientoSA
    Public Property ListaCurar As List(Of totalesAlmacen)
    Public Property ListaNegativosKardex As List(Of totalesAlmacen)
    Public Property ListaCantidadNegativa As List(Of totalesAlmacen)
    Public Property ListaMontoNegativa As List(Of totalesAlmacen)

    Public Property TotalesSA As New TotalesAlmacenSA

    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0
    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0

    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFGKardex(dgvKardex2)
        CargarCMB()
        txtPeriodo.Value = DiaLaboral
        Label24.Visible = True
        txtPeriodo.Visible = True
        Panel1.Visible = True
        Panel44.Visible = True
        ValidandoModulos()
    End Sub
#End Region

#Region "Methods"
    Private Sub ValidandoModulos()

        If Gempresas.IDProducto = "23" Then ' PosV00
            'entradas
            Panel37.Visible = False
            Panel44.Visible = False
        Else

        End If
    End Sub

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
        For Each i As InventarioMovimiento In inventario.GetMovimientosKardexByArticulo(New InventarioMovimiento With {.idAlmacen = intIdAlmacen, .fecha = New DateTime(anio, mes, 1),
                                                                                                                    .tipoProducto = envio.TipoExistencia, .idItem = envio.IdExistencia}, New cierreinventario With {.anio = anio, .mes = mes - 1})

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
        setDataSource(dt)
        'dgvKardex2.DataSource = dt
        'dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'dgvKardex2.TopLevelGroupOptions.ShowCaption = True
        'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'dgvKardex2.TableDescriptor.Columns("nombreItem").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        'lblCosto.Text = "Costo: " & listaCostoVentaMayorAventa.Count
    End Sub

    Sub GridCFGKardex(GGC As GridGroupingControl)
        Dim colorx As New GridMetroColors()
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
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Private Sub CargarCMB()
        Dim lista As New List(Of tabladetalle)
        Dim listaAlmacen As New List(Of almacen)
        '   listaAlmacen.Add(New almacen With {.idAlmacen = 0, .descripcionAlmacen = "-Todos-"})
        listaAlmacen.AddRange(almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        cboalmacenKardex.DisplayMember = "descripcionAlmacen"
        cboalmacenKardex.ValueMember = "idAlmacen"
        cboalmacenKardex.DataSource = listaAlmacen
    End Sub

    'Private Sub GetKardexByAnio()
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim inventario As New inventarioMovimientoSA
    '    Dim listaInventario As New List(Of InventarioMovimiento)
    '    'Dim canSaldo As Decimal = 0
    '    'Dim ImporteSaldo As Decimal = 0
    '    Dim producto As String = Nothing
    '    Dim cantidadDeficit As Decimal = 0
    '    Dim importeDeficit As Decimal = 0
    '    Dim productoCache As String = Nothing

    '    '-----------------------------------------------------------------------------------------------------

    '    Dim dt As New DataTable("kárdex - Año " & txtPeriodo.Value.Year)
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

    '    Dim str As String

    '    ImporteSaldo = 0
    '    canSaldo = 0
    '    '''''''''''''''m

    '    Select Case cboFechaFiltroKardex.Text
    '        Case "FECHA LABORAL"
    '            If CheckBox3.Checked = True Then
    '                listaInventario = inventario.GetKardexByAnioDiaLaboralLote(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1), .nrolote = txtFiltroLote.Text})
    '            Else
    '                listaInventario = inventario.GetKardexByAnioDiaLaboral(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fechaLaboral = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
    '            End If

    '        Case "FECHA DOCUMENTO" '
    '            If CheckBox3.Checked = True Then
    '                listaInventario = inventario.GetKardexByfechaDocumentoLote(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1), .nrolote = txtFiltroLote.Text})
    '            Else
    '                '    listaInventario = inventario.GetKardexByAnio(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
    '                listaInventario = inventario.GetMovimientosKardexByMes(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)}, New cierreinventario With {.anio = txtPeriodo.Value.Year, .mes = txtPeriodo.Value.Month - 1})
    '            End If

    '    End Select

    '    For Each i As InventarioMovimiento In listaInventario
    '        cantidadDeficit = 0
    '        importeDeficit = 0

    '        Dim dr As DataRow = dt.NewRow()
    '        str = Nothing
    '        str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
    '        dr(0) = i.tipoOperacion ' tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
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
    '                If producto = i.idItem Then
    '                    productoCache = i.nombreItem
    '                    canSaldo += CDec(i.cantidad)
    '                    ImporteSaldo += CDec(i.monto)
    '                Else
    '                    cantidadDeficit = canSaldo
    '                    importeDeficit = ImporteSaldo

    '                    canSaldo = 0
    '                    ImporteSaldo = 0

    '                    'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
    '                    canSaldo = canSaldo + saldoCantidadAnual
    '                    ImporteSaldo = ImporteSaldo + saldoImporteAnual
    '                    canSaldo = CDec(i.cantidad) + canSaldo
    '                    ImporteSaldo = CDec(i.monto) + ImporteSaldo

    '                End If
    '                dr(7) = (FormatNumber(i.cantidad, 4))
    '                If CDec(i.cantidad) > 0 Then
    '                    dr(8) = (Math.Round(CDec(i.monto) / CDec(i.cantidad), 4))
    '                Else
    '                    dr(8) = 0
    '                End If
    '                dr(9) = (FormatNumber(i.monto, 4))
    '                dr(10) = ("0.00")
    '                dr(11) = ("0.00")
    '                dr(12) = ("0.00")
    '                dr(13) = (FormatNumber(canSaldo, 4))
    '                dr(14) = (FormatNumber(ImporteSaldo, 4))
    '                If canSaldo > 0 Then
    '                    precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
    '                Else
    '                    precUnit = 0
    '                End If
    '                dr(15) = precUnit
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

    '                        Case "9916"
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo += i.monto

    '                            'Case "9926"
    '                            '    canSaldo += CDec(i.cantidad)
    '                            '    ImporteSaldo += i.monto

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
    '                    canSaldo = canSaldo + saldoCantidadAnual
    '                    ImporteSaldo = ImporteSaldo + saldoImporteAnual

    '                    canSaldo += CDec(i.cantidad)
    '                    ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
    '                End If
    '                dr(7) = ("0.00")
    '                dr(8) = ("0.00")
    '                dr(9) = ("0.00")

    '                Select Case i.tipoOperacion
    '                    Case "9913"
    '                        dr(10) = (FormatNumber(i.cantidad, 4)) * -1
    '                        dr(11) = (0)
    '                        dr(12) = 0.0

    '                    Case "9914"
    '                        dr(10) = 0.0
    '                        dr(11) = (0)
    '                        dr(12) = i.monto * -1

    '                    Case "9916"
    '                        dr(10) = (FormatNumber(i.cantidad, 4)) * -1
    '                        dr(11) = (0)
    '                        dr(12) = i.monto * -1

    '                        'Case "9926"
    '                        '    dr(10) = (FormatNumber(i.cantidad, 4)) * -1
    '                        '    dr(11) = (0)
    '                        '    dr(12) = i.monto * -1

    '                    Case Else
    '                        dr(10) = (FormatNumber(i.cantidad, 4)) * -1
    '                        dr(11) = (0)
    '                        dr(12) = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1 '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
    '                End Select
    '                dr(13) = (FormatNumber(canSaldo, 4))
    '                dr(14) = (FormatNumber(ImporteSaldo, 4))
    '                If canSaldo > 0 Then
    '                    precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
    '                Else
    '                    precUnit = 0
    '                End If
    '                dr(15) = precUnit
    '                pmAcumnulado = precUnit
    '        End Select
    '        dr(16) = i.idDocumento
    '        dr(17) = i.idInventario

    '        producto = i.idItem
    '        productoCache = i.nombreItem

    '        dt.Rows.Add(dr)
    '    Next
    '    dgvKardex2.DataSource = dt
    '    dgvKardex2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '    dgvKardex2.TopLevelGroupOptions.ShowCaption = True
    'End Sub

    Private Function GetCorrecionTotalesAlmacenAll() As List(Of totalesAlmacen)
        Dim NuevaListaInventario As New List(Of InventarioMovimiento)
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

        GetCorrecionTotalesAlmacenAll = New List(Of totalesAlmacen)
        NuevaListaInventario = New List(Of InventarioMovimiento)
        For Each al In almacenes

            listaInventario = inventario.GetMovimientosKardexByMes(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)}, Nothing)

            ImporteSaldo = 0
            canSaldo = 0
            For Each i As InventarioMovimiento In listaInventario

                cantidadDeficit = 0
                importeDeficit = 0

                Select Case i.tipoRegistro
                    Case "E", "EA", "EC"
                        If producto = i.idItem AndAlso codigoLotex = i.customLote.nroLote Then
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

                        If producto = i.idItem AndAlso codigoLotex = i.customLote.nroLote Then
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
                codigoLotex = i.customLote.nroLote
                productoCache = i.nombreItem

                NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                   .idAlmacen = i.idAlmacen,
                                                                   .idItem = i.idItem,
                                                                   .descripcion = i.nombreItem,
                                                                   .tipoExistencia = i.tipoProducto,
                                                                   .unidad = i.unidad,
                                                                   .CantSaldo = canSaldo,
                                                                   .nrolote = codigoLotex = i.customLote.nroLote,
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

            GetCorrecionTotalesAlmacenAll.Add(New totalesAlmacen With
                                              {
                                              .idAlmacen = c.idAlmacen,
                                              .codigoLote = c.nrolote,
                                              .idItem = obj.idItem,
                                              .cantidad = obj.CantSaldo,
                                              .importeSoles = obj.saldoMonto,
                                              .importeDolares = 0
                                              })
        Next
        Return GetCorrecionTotalesAlmacenAll
    End Function


    Private Sub GetKardexByAnioCuracion()
        TotalesSA.GetCurarKardexCaberas(GetCorrecionTotalesAlmacenAll)
        MessageBox.Show("Inventario corregido con éxito", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub GetCierreInventario()
        Dim NuevaListaInventario As New List(Of InventarioMovimiento)
        Dim ndocumento As documento
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

        '-----------------------------------------------------------------------------------------------------
        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m
        listaInventario = inventario.GetMovimientosKardexByMes(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)}, New cierreinventario With {.anio = txtPeriodo.Value.Year, .mes = txtPeriodo.Value.Month - 1})
        NuevaListaInventario = New List(Of InventarioMovimiento)
        For Each i As InventarioMovimiento In listaInventario
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
            productoCache = i.nombreItem

            'If conteoLimite = conteoArticulo Then
            '    ListaCurar.Add(New totalesAlmacen With {.descripcion = i.nombreItem,
            '                                            .tipoExistencia = i.tipoProducto,
            '                                            .idItem = i.idItem,
            '                                            .idAlmacen = i.idAlmacen,
            '                                            .cantidad = canSaldo,
            '                                            .importeSoles = ImporteSaldo,
            '                                            .importeDolares = 0})
            '    conteoLimite = 0
            'End If
            ''llenando inventario con saldo por producto
            NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                    .idAlmacen = i.idAlmacen,
                                                                    .idItem = i.idItem,
                                                                    .descripcion = i.nombreItem,
                                                                    .tipoExistencia = i.tipoProducto,
                                                                    .unidad = i.unidad,
                                                                    .CantSaldo = canSaldo,
                                                                    .saldoMonto = ImporteSaldo})

        Next

        Dim listaAGuardar = (From n In NuevaListaInventario
                             Select n.idItem, n.idAlmacen
                             Order By idItem).Distinct.ToList()
        'asignando cierre de inventario
        '----------------------------------------------------------------------------------

        ndocumento = New documento
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = "9901"
        ndocumento.fechaProceso = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)
        ndocumento.moneda = "1"
        ndocumento.idEntidad = 0
        ndocumento.entidad = "SIN IDENTIDAD"
        ndocumento.tipoEntidad = "OT"
        ndocumento.tipoOperacion = StatusTipoOperacion.CIERRES
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = Date.Now

        For Each c In listaAGuardar ' ListaCurar

            Dim obj = NuevaListaInventario.Where(Function(o) o.idItem = c.idItem And o.idAlmacen = c.idAlmacen).LastOrDefault

            cierre = New cierreinventario
            cierre.idEmpresa = Gempresas.IdEmpresaRuc
            cierre.idCentroCosto = GEstableciento.IdEstablecimiento
            cierre.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & txtPeriodo.Value.Year
            cierre.idAlmacen = cboalmacenKardex.SelectedValue
            cierre.idItem = obj.idItem
            cierre.NomItem = obj.descripcion
            cierre.anio = txtPeriodo.Value.Year
            cierre.mes = txtPeriodo.Value.Month
            cierre.dia = DateTime.Now.Day
            cierre.TipoExistencia = obj.tipoExistencia
            cierre.cantidad = obj.CantSaldo
            cierre.importe = obj.saldoMonto
            cierre.importeUS = 0
            cierre.unidad = obj.unidad
            cierre.usuarioModificacion = usuario.IDUsuario
            cierre.fechaModificacion = DateTime.Now
            listaCierre.Add(cierre)
        Next
        ndocumento.cierreinventario = listaCierre

        cierreSA.CerrarByPeriodo(ndocumento)

        '  TotalesSA.GetCurarKardexCaberas(ListaCurar)
        MessageBox.Show("Inventario cerrado correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            LinkLabel1.Text = "Saldos Neg: " & ListaNegativosKardex.Count
            LinkMontoNega.Text = "Imp. Neg: " & ListaMontoNegativa.Count
            LinkCantNega.Text = "Cant. Neg: " & ListaCantidadNegativa.Count
            lblCosto.Text = "Costo: " & listaCostoVentaMayorAventa.Count
            ProgressBar1.Visible = False
        End If
    End Sub

    Dim listaCostoVentaMayorAventa As List(Of totalesAlmacen)
    Private Sub GetKardexByAnio(intIdAlmacen As Integer, periodo As Date)

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
        listaInventario = inventario.GetMovimientosKardexByMes(New InventarioMovimiento With {.idAlmacen = intIdAlmacen, .fecha = New DateTime(periodo.Year, periodo.Month, 1)}, Nothing)
        '            End If

        '    End Select

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
                    If producto = i.idItem AndAlso CodigoLotex = i.customLote.codigoLote Then
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

                    If producto = i.idItem AndAlso CodigoLotex = i.customLote.codigoLote Then
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
            dr(20) = i.customLote.nroLote
            producto = i.idItem
            CodigoLotex = i.customLote.codigoLote
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
#End Region

#Region "Events"
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New frmModalNegativos(ListaNegativosKardex)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        Try
            ProgressBar1.Visible = True
            ProgressBar1.Style = ProgressBarStyle.Marquee
            Dim periodo = txtPeriodo.Value
            Dim almacenRef = cboalmacenKardex.SelectedValue
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetKardexByAnio(almacenRef, periodo)))
            thread.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then

            dgvKardex2.TableDescriptor.Columns("precUnite").Width = 0
            dgvKardex2.TableDescriptor.Columns("precUnite1").Width = 0
            dgvKardex2.TableDescriptor.Columns("precUnite2").Width = 0
            dgvKardex2.TableDescriptor.Columns("monto").Width = 0
            dgvKardex2.TableDescriptor.Columns("monto1").Width = 0
            dgvKardex2.TableDescriptor.Columns("monto2").Width = 0


            dgvKardex2.TableDescriptor.Columns("cantidad").Width = 70
            dgvKardex2.TableDescriptor.Columns("cantidad1").Width = 70
            dgvKardex2.TableDescriptor.Columns("cantidad2").Width = 70

        Else

            dgvKardex2.TableDescriptor.Columns("precUnite").Width = 70
            dgvKardex2.TableDescriptor.Columns("precUnite1").Width = 70
            dgvKardex2.TableDescriptor.Columns("precUnite2").Width = 70
            dgvKardex2.TableDescriptor.Columns("monto").Width = 70
            dgvKardex2.TableDescriptor.Columns("monto1").Width = 70
            dgvKardex2.TableDescriptor.Columns("monto2").Width = 70

            dgvKardex2.TableDescriptor.Columns("cantidad").Width = 70
            dgvKardex2.TableDescriptor.Columns("cantidad1").Width = 70
            dgvKardex2.TableDescriptor.Columns("cantidad2").Width = 70

        End If
    End Sub

    Private Sub Panel44_Click(sender As Object, e As EventArgs) Handles Panel44.Click
        Dim f As New frmCostoDeVentas
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        'LoadingAnimator.Wire(dgvKardex2.TableControl)
        'Try
        '    GetCierreInventario()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

        'LoadingAnimator.UnWire(dgvKardex2.TableControl)
        'Dim f As New frmCostoVentaTipoExistencia(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub
    Public Property EnvioSelect As BusquedaExstencia
    Private Sub Panel22_Click(sender As Object, e As EventArgs) Handles Panel22.Click
        Try
            Dim f As New frmBusquedaKardex(cboalmacenKardex.SelectedValue)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                EnvioSelect = New BusquedaExstencia

                Dim anio As Integer = txtPeriodo.Value.Year
                Dim mes As Integer = txtPeriodo.Value.Month
                Dim almacen = cboalmacenKardex.SelectedValue

                Dim envio = CType(f.Tag, BusquedaExstencia)
                txtArticuloSelec.Text = envio.NombreExistencia
                txtArticuloSelec.Tag = envio.IdExistencia
                EnvioSelect = envio
                ProgressBar1.Visible = True
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetKardexPeridoByExistencia(envio, mes, anio, almacen)))
                thread.Start()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        If e.TableCellIdentity.RowIndex <> -1 Then
            Dim rec As GridRecordRow =
                TryCast(dgvKardex2.Table.DisplayElements(e.TableCellIdentity.RowIndex), GridRecordRow)

            If rec IsNot Nothing Then
                ' Applies format by checking the value Row1
                Dim dr As DataRowView = TryCast(rec.GetData(), DataRowView)
                If dr IsNot Nothing AndAlso CDec(dr("monto1")) > CDec(dr("valorventa")) Then
                    e.Style.Enabled = False
                    e.Style.BackColor = Color.Yellow
                    e.Style.TextColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub dgvKardex2_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvKardex2.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvKardex2)
    End Sub


    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        LoadingAnimator.Wire(dgvKardex2.TableControl)
        GetKardexByAnioCuracion()
        LoadingAnimator.UnWire(dgvKardex2.TableControl)
    End Sub

    Private Sub LinkCantNega_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkCantNega.LinkClicked
        Dim f As New frmModalNegativos(ListaCantidadNegativa)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub LinkMontoNega_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkMontoNega.LinkClicked
        Dim f As New frmModalNegativos(ListaMontoNegativa)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub frmModeloKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Ver documento de origen...")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler Me.dgvKardex2.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        dgvKardex2.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = dgvKardex2.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvKardex2.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvKardex2.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Ver documento de origen..." Then
                '   Me.dgvCompra.Table.CurrentRecord.Delete()
                Select Case Me.dgvKardex2.Table.CurrentRecord.GetValue("Movimiento")
                    Case "COMPRA", "OTRAS ENTRADAS A ALMACEN", "TRANSFERENCIA ENTRE ALMACENES", "OTRAS SALIDAS DE ALMACEN", "NC-DISMINUIR CANTIDAD", "NC-DISMINUIR IMPORTE", "NC-DISMINUIR CANTIDAD E IMPORTE", "NC-DEVOLUCION DE EXISTENCIAS",
                        "NOTA DE CREDITO ESPECIAL", "NOTA DE DEBITO ESPECIAL"
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

    Private Sub Panel28_Click(sender As Object, e As EventArgs) Handles Panel28.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.dgvKardex2, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Exportar kardex a un archivo excel ahora?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If
    End Sub

    Private Sub lblCosto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblCosto.LinkClicked
        Dim f As New frmModalNegativos(listaCostoVentaMayorAventa)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub Panel37_Click(sender As Object, e As EventArgs) Handles Panel37.Click
        LoadingAnimator.Wire(dgvKardex2.TableControl)
        Dim f As New frmDetalleCostoVentas(txtPeriodo.Value.Year, txtPeriodo.Value.Month)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        LoadingAnimator.UnWire(dgvKardex2.TableControl)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If EnvioSelect IsNot Nothing Then
            Dim anio As Integer = txtPeriodo.Value.Year
            Dim mes As Integer = txtPeriodo.Value.Month
            Dim almacen = cboalmacenKardex.SelectedValue

            ProgressBar1.Visible = True
            ProgressBar1.Style = ProgressBarStyle.Marquee
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetKardexPeridoByExistencia(EnvioSelect, mes, anio, almacen)))
            thread.Start()
        End If
    End Sub
#End Region

End Class
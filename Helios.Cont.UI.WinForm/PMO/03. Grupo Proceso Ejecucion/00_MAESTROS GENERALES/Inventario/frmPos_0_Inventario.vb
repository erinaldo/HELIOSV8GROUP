Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.GroupingGridExcelConverter
Public Class frmPos_0_Inventario
    Inherits frmMaster

    Dim colorx As New GridMetroColors()
    Dim lblAlertaStock As Label


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TabDashboard.Parent = Nothing
        TabTransito.Parent = Nothing
        TabInventario.Parent = TabControlAdv1
        TabKardex.Parent = Nothing
        TabMovimientos.Parent = Nothing
        TabAlertaInventario.Parent = Nothing
        TabPageAdv2.Parent = Nothing

        lblAlertaStock = New Label
        GridCFGInventarios(dgvKardexVal)
        GridCFG2(dgvTransito)
        GridCFG2(dgvEnvioAlmacen)
        GridCFGKardex(dgvKardex2)
        GridCFGKardex(dgvStockMinimo)
        CargarCMB()
        GridColumnConfig()
        GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        
        lblPeriodo.Text = "Período: " & PeriodoGeneral
        txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
    End Sub

    Public Sub New(be As totalesAlmacen)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblAlertaStock = New Label
        ToolStripButton15.Visible = False
        ToolStripButton16.Visible = False
        GridCFGKardex(dgvStockMinimo)

        TabDashboard.Parent = Nothing
        TabTransito.Parent = Nothing
        TabInventario.Parent = Nothing
        TabMovimientos.Parent = Nothing
        TabKardex.Parent = Nothing
        TabAlertaInventario.Parent = TabControlAdv1
        TabPageAdv2.Parent = Nothing

        GetInventarioEnAlerta(be)
        treeViewAdv2.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

#Region "métodos"
    Private Sub Meses()
        Dim listaMeses As New List(Of MesesAnio)
        Dim obj As New MesesAnio

        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = "01"
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
        dgvRotacion.DataSource = dt


    End Sub

    Public Sub GetInventarioEnAlertaConteo(be As totalesAlmacen)
        Dim totalSA As New TotalesAlmacenSA

        lblAlertaStock.Text = totalSA.GetAlertaIventarioMinimoConteo(be)

    End Sub

    Public Sub GetInventarioEnAlerta(be As totalesAlmacen)
        Dim totalSA As New TotalesAlmacenSA
        Dim dt As New DataTable()

        dt.Columns.Add("idAlmacen")
        dt.Columns.Add("almacen")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")
        dt.Columns.Add("cantidadMinima")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        'dt.Columns.Add("iditem")
        'dt.Columns.Add("item")
        'dt.Columns.Add("unidad")

        For Each i In totalSA.GetAlertaIventarioMinimo(be)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAlmacen
            dr(1) = i.NomAlmacen
            dr(2) = i.cantidad
            dr(3) = i.importeSoles
            dr(4) = i.importeDolares
            dr(5) = i.cantidadMinima
            dr(6) = i.idItem
            dr(7) = i.descripcion
            dr(8) = i.idUnidad
            dt.Rows.Add(dr)
        Next
        dgvStockMinimo.DataSource = dt

    End Sub

    Public Sub GetProveedoresEnTransito(be As documentocompra)
        Dim invSA As New inventarioMovimientoSA

        cboproveedor.DisplayMember = "nombreCompleto"
        cboproveedor.ValueMember = "idEntidad"
        cboproveedor.DataSource = invSA.GetProveedoresEnTransito(be)

    End Sub

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

    Sub GridCFGInventarios(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Sub GridCFG2(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Function ValidarExistenciaDisponible(column As String) As Decimal
        Dim sumaMN As Decimal = 0
        For Each i As Record In dgvEnvioAlmacen.Table.Records
            sumaMN += CDec(i.GetValue(column))
        Next

        Return sumaMN
    End Function


    Sub GuiaRemision(objDocumentoCompra As documento, envio As EnvioExistencia)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        Dim itemSA As New detalleitemsSA
        'REGISTRANDO LA GUIA DE REMISION
        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0
        With objDocumentoCompra
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "99"
            .fechaProceso = envio.FechaEnvio
            .nroDoc = envio.Serie & "-" & envio.Numero
            .idOrden = Nothing
            .tipoOperacion = "02"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With guiaRemisionBE
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = envio.FechaEnvio
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            .serie = envio.Serie
            .numeroDoc = envio.Numero
            .idEntidad = Nothing ' docCompra.idProveedor
            .monedaDoc = Nothing ' docCompra.monedaDoc
            .tasaIgv = Nothing ' docCompra.tasaIgv
            .tipoCambio = Nothing ' docCompra.tcDolLoc
            .importeMN = 0
            .importeME = 0
            .glosa = "Guía de remisión por compras realizadas, distribución masiva"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE
        sumaMN = 0
        sumaME = 0
        For Each i As SelectedRecord In dgvTransito.Table.SelectedRecords
            sumaMN += CDec(i.Record.GetValue("saldoMontoMN"))
            sumaME += CDec(i.Record.GetValue("saldoMontoME"))

            documentoguiaDetalle = New documentoguiaDetalle
            documentoguiaDetalle.idDocumento = 0
            documentoguiaDetalle.idItem = Val(i.Record.GetValue("idItem"))
            documentoguiaDetalle.descripcionItem = i.Record.GetValue("descripcion")
            documentoguiaDetalle.destino = i.Record.GetValue("origen")
            documentoguiaDetalle.unidadMedida = i.Record.GetValue("unidad")
            documentoguiaDetalle.cantidad = CDec(i.Record.GetValue("saldoCan"))
            documentoguiaDetalle.precioUnitario = 0
            documentoguiaDetalle.precioUnitarioUS = 0
            documentoguiaDetalle.importeMN = CDec(i.Record.GetValue("saldoMontoMN"))
            documentoguiaDetalle.importeME = CDec(i.Record.GetValue("saldoMontoME"))
            documentoguiaDetalle.idDocumentoPadre = Val(i.Record.GetValue("idDocumento"))
            documentoguiaDetalle.almacenRef = envio.Almacen

            documentoguiaDetalle.secuencia = Val(i.Record.GetValue("secCompra"))

            documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
            documentoguiaDetalle.fechaModificacion = DateTime.Now
            ListaGuiaDetalle.Add(documentoguiaDetalle)
        Next
        objDocumentoCompra.documentoGuia.importeMN = sumaMN
        objDocumentoCompra.documentoGuia.importeME = sumaME
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub GuiaRemisionParcial(objDocumentoCompra As documento, envio As EnvioExistencia)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0
        With objDocumentoCompra
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "99"
            .fechaProceso = envio.FechaEnvio
            .nroDoc = envio.Serie & "-" & envio.Numero
            .idOrden = Nothing
            .tipoOperacion = "02"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With guiaRemisionBE
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = envio.FechaEnvio
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            .serie = envio.Serie
            .numeroDoc = envio.Numero
            .idEntidad = Nothing ' docCompra.idProveedor
            .monedaDoc = Nothing ' docCompra.monedaDoc
            .tasaIgv = Nothing ' docCompra.tasaIgv
            .tipoCambio = Nothing ' docCompra.tcDolLoc
            .importeMN = 0
            .importeME = 0
            .glosa = "Guía de remisión por compras realizadas, distribución masiva"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE
        sumaMN = 0
        sumaME = 0

        For Each i As Record In dgvEnvioAlmacen.Table.Records
            sumaMN += CDec(i.GetValue("montoMN"))
            sumaME += CDec(i.GetValue("montoME"))

            documentoguiaDetalle = New documentoguiaDetalle
            documentoguiaDetalle.idDocumento = 0
            documentoguiaDetalle.idItem = Val(i.GetValue("iditem"))
            documentoguiaDetalle.descripcionItem = i.GetValue("item")
            documentoguiaDetalle.destino = i.GetValue("gravado")
            documentoguiaDetalle.unidadMedida = i.GetValue("unidad")
            If Not CDec(i.GetValue("cantidad")) > 0 Then
                Throw New Exception("La cantidad Debe ser mayor a cero." & vbCrLf & "Item: " & i.GetValue("item"))
            End If
            documentoguiaDetalle.cantidad = CDec(i.GetValue("cantidad"))
            documentoguiaDetalle.precioUnitario = 0
            documentoguiaDetalle.precioUnitarioUS = 0

            If Not CDec(i.GetValue("montoMN")) > 0 Then
                Throw New Exception("El costo (MN.) Debe ser mayor a cero." & vbCrLf & "Item: " & i.GetValue("item"))
            End If

            If Not CDec(i.GetValue("montoME")) > 0 Then
                Throw New Exception("El costo (ME.) Debe ser mayor a cero." & vbCrLf & "Item: " & i.GetValue("item"))
            End If

            documentoguiaDetalle.importeMN = CDec(i.GetValue("montoMN"))
            documentoguiaDetalle.importeME = CDec(i.GetValue("montoME"))
            documentoguiaDetalle.idDocumentoPadre = Val(i.GetValue("idDocumento"))

            Dim codAlmacen = i.GetValue("almacenEnvio")
            If Not codAlmacen.ToString.Trim.Length > 0 Then
                Throw New Exception("Debe seleccionar un almacén." & vbCrLf & "Item: " & i.GetValue("item"))
            End If
            documentoguiaDetalle.almacenRef = Val(i.GetValue("almacenEnvio"))

            documentoguiaDetalle.secuencia = Val(i.GetValue("secuencia"))

            documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
            documentoguiaDetalle.fechaModificacion = DateTime.Now
            ListaGuiaDetalle.Add(documentoguiaDetalle)
        Next

        objDocumentoCompra.documentoGuia.importeMN = sumaMN
        objDocumentoCompra.documentoGuia.importeME = sumaME
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Private Sub GetMovPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)
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
        dgvMov.DataSource = dt

    End Sub

    Private Sub GrabarEnvioMasivo(envio As EnvioExistencia)
        Dim invSA As New inventarioMovimientoSA
        Dim documento As New documento
        Dim obj As New InventarioMovimiento()
        Dim listaExistencias As New List(Of InventarioMovimiento)
        Dim almacenSA As New almacenSA
        Dim almacenTransito As New almacen


        dgvTransito.TableControl.CurrentCell.EndEdit()
        dgvTransito.TableControl.Table.TableDirty = True
        dgvTransito.TableControl.Table.EndEdit()

        listaExistencias = New List(Of InventarioMovimiento)

        GuiaRemision(documento, envio)

        almacenTransito = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
        For Each i As SelectedRecord In dgvTransito.Table.SelectedRecords
            obj = New InventarioMovimiento With
                  {
                       .idorigenDetalle = Val(i.Record.GetValue("secCompra")),
                       .idEmpresa = Gempresas.IdEmpresaRuc,
                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                       .idAlmacen = envio.Almacen,
                       .TipoAlmacen = TipoAlmacen.Deposito,
                       .tipoOperacion = "02",
                       .tipoDocAlmacen = envio.TipoDoc,
                       .serie = envio.Serie,
                       .numero = envio.Numero,
                       .idDocumento = Val(i.Record.GetValue("idDocumento")),
                       .idDocumentoRef = Val(i.Record.GetValue("idDocumento")),
                       .idItem = Val(i.Record.GetValue("idItem")),
                       .descripcion = i.Record.GetValue("descripcion"),
                       .fecha = CType(envio.FechaEnvio, DateTime),
                       .tipoRegistro = Status.Entrada_almacen,
                       .destinoGravadoItem = i.Record.GetValue("origen"),
                       .tipoProducto = i.Record.GetValue("tipoExistencia"),
                       .cantidad = CType(i.Record.GetValue("saldoCan"), Decimal),
                       .unidad = i.Record.GetValue("unidad"),
                       .cantidad2 = 0,
                       .unidad2 = 0,
                       .precUnite = 0,
                       .precUniteUSD = 0,
                       .monto = CDec(i.Record.GetValue("saldoMontoMN")),
                       .montoUSD = CDec(i.Record.GetValue("saldoMontoME")),
                       .status = Status.Distribuido,
                       .entragado = Status.Entrada_almacen,
                       .usuarioActualizacion = usuario.IDUsuario,
                       .fechaActualizacion = DateTime.Now
                }
            listaExistencias.Add(obj)


            'Registro de la Salida

            obj = New InventarioMovimiento With
                 {
                      .idorigenDetalle = Val(i.Record.GetValue("secCompra")),
                      .idEmpresa = Gempresas.IdEmpresaRuc,
                      .idEstablecimiento = almacenTransito.idEstablecimiento,
                      .idAlmacen = almacenTransito.idAlmacen,
                      .TipoAlmacen = TipoAlmacen.transito,
                      .tipoOperacion = "02",
                      .tipoDocAlmacen = envio.TipoDoc,
                      .serie = envio.Serie,
                      .numero = envio.Numero,
                      .idDocumento = Val(i.Record.GetValue("idDocumento")),
                      .idDocumentoRef = Val(i.Record.GetValue("idDocumento")),
                      .idItem = Val(i.Record.GetValue("idItem")),
                      .descripcion = i.Record.GetValue("descripcion"),
                      .fecha = CType(envio.FechaEnvio, DateTime),
                      .tipoRegistro = Status.Salida_almacen,
                      .destinoGravadoItem = i.Record.GetValue("origen"),
                      .tipoProducto = i.Record.GetValue("tipoExistencia"),
                      .cantidad = CDec(i.Record.GetValue("saldoCan")) * -1,
                      .unidad = i.Record.GetValue("unidad"),
                      .cantidad2 = 0,
                      .unidad2 = 0,
                      .precUnite = 0,
                      .precUniteUSD = 0,
                      .monto = CDec(i.Record.GetValue("saldoMontoMN")) * -1,
                      .montoUSD = CDec(i.Record.GetValue("saldoMontoME")) * -1,
                      .status = Status.Distribuido,
                      .entragado = Status.Entrada_almacen,
                      .usuarioActualizacion = usuario.IDUsuario,
                      .fechaActualizacion = DateTime.Now
               }
            listaExistencias.Add(obj)
        Next
        documento.InventarioMovimiento = listaExistencias

        If rbParcial.Checked = True Then
            documento.TipoEnvio = "PARCIAL"
        ElseIf rbCompleta.Checked = True Then
            documento.TipoEnvio = "MASIVO"
        End If

        invSA.GrabarEnvioTransito(documento)
        MessageBox.Show("Existencia enviada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Dispose()
    End Sub

    Private Sub GrabarEnvioParcial(envio As EnvioExistencia)
        Dim invSA As New inventarioMovimientoSA
        Dim documento As New documento
        Dim obj As New InventarioMovimiento()
        Dim listaExistencias As New List(Of InventarioMovimiento)
        Dim almacenSA As New almacenSA
        Dim almacenTransito As New almacen


        dgvEnvioAlmacen.TableControl.CurrentCell.EndEdit()
        dgvEnvioAlmacen.TableControl.Table.TableDirty = True
        dgvEnvioAlmacen.TableControl.Table.EndEdit()


        listaExistencias = New List(Of InventarioMovimiento)

        GuiaRemisionParcial(documento, envio)

        almacenTransito = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
        For Each i As Record In dgvEnvioAlmacen.Table.Records

            Dim codAlmacen = i.GetValue("almacenEnvio")
            If Not codAlmacen.ToString.Trim.Length > 0 Then
                MessageBox.Show("Debe seleccionar un almacén." & vbCrLf & "item: " & i.GetValue("item"))
                Exit Sub
            End If

            obj = New InventarioMovimiento With
                  {
                       .idorigenDetalle = Val(i.GetValue("secuencia")),
                       .idEmpresa = Gempresas.IdEmpresaRuc,
                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                       .idAlmacen = Val(i.GetValue("almacenEnvio")),
                       .TipoAlmacen = TipoAlmacen.Deposito,
                       .tipoOperacion = "02",
                       .tipoDocAlmacen = envio.TipoDoc,
                       .serie = envio.Serie,
                       .numero = envio.Numero,
                       .idDocumento = Val(i.GetValue("idDocumento")),
                       .idDocumentoRef = Val(i.GetValue("idDocumento")),
                       .idItem = Val(i.GetValue("iditem")),
                       .descripcion = i.GetValue("item"),
                       .fecha = CType(envio.FechaEnvio, DateTime),
                       .tipoRegistro = Status.Entrada_almacen,
                       .destinoGravadoItem = i.GetValue("gravado"),
                       .tipoProducto = i.GetValue("tipoEx"),
                       .cantidad = CType(i.GetValue("cantidad"), Decimal),
                       .unidad = i.GetValue("unidad"),
                       .cantidad2 = 0,
                       .unidad2 = 0,
                       .precUnite = 0,
                       .precUniteUSD = 0,
                       .monto = CDec(i.GetValue("montoMN")),
                       .montoUSD = CDec(i.GetValue("montoME")),
                       .status = Status.Distribuido,
                       .entragado = Status.Entrada_almacen,
                       .usuarioActualizacion = usuario.IDUsuario,
                       .fechaActualizacion = DateTime.Now
                }
            listaExistencias.Add(obj)


            'Registro de la Salida

            obj = New InventarioMovimiento With
                 {
                      .idorigenDetalle = Val(i.GetValue("secuencia")),
                      .idEmpresa = Gempresas.IdEmpresaRuc,
                      .idEstablecimiento = almacenTransito.idEstablecimiento,
                      .idAlmacen = almacenTransito.idAlmacen,
                      .TipoAlmacen = TipoAlmacen.transito,
                      .tipoOperacion = "02",
                      .tipoDocAlmacen = envio.TipoDoc,
                      .serie = envio.Serie,
                      .numero = envio.Numero,
                      .idDocumento = Val(i.GetValue("idDocumento")),
                      .idDocumentoRef = Val(i.GetValue("idDocumento")),
                      .idItem = Val(i.GetValue("iditem")),
                      .descripcion = i.GetValue("item"),
                      .fecha = CType(envio.FechaEnvio, DateTime),
                      .tipoRegistro = Status.Salida_almacen,
                      .destinoGravadoItem = i.GetValue("gravado"),
                      .tipoProducto = i.GetValue("tipoEx"),
                      .cantidad = CDec(i.GetValue("cantidad")) * -1,
                      .unidad = i.GetValue("unidad"),
                      .cantidad2 = 0,
                      .unidad2 = 0,
                      .precUnite = 0,
                      .precUniteUSD = 0,
                      .monto = CDec(i.GetValue("montoMN")) * -1,
                      .montoUSD = CDec(i.GetValue("montoME")) * -1,
                      .status = Status.Distribuido,
                      .entragado = Status.Entrada_almacen,
                      .usuarioActualizacion = usuario.IDUsuario,
                      .fechaActualizacion = DateTime.Now
               }
            listaExistencias.Add(obj)
        Next
        documento.InventarioMovimiento = listaExistencias

        If rbParcial.Checked = True Then
            documento.TipoEnvio = "PARCIAL"
        ElseIf rbCompleta.Checked = True Then
            documento.TipoEnvio = "MASIVO"
        End If

        invSA.GrabarEnvioTransito(documento)
        MessageBox.Show("Existencia enviada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub AsiganarItem(intNumero As Integer)

        'Select Case intNumero
        '    Case 1
        '        Dim r As Record = dgvTransito.Table.CurrentRecord

        '        Me.dgvEnvioAlmacen.Table.AddNewRecord.SetCurrent()
        '        Me.dgvEnvioAlmacen.Table.AddNewRecord.BeginEdit()
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("idDocumento", r.GetValue("idDocumento"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("secuencia", r.GetValue("secCompra"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("fecha", r.GetValue("fechaCompra"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("tipodoc", r.GetValue("comprobanteCompra"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("serie", 1)
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("numero", 1)
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("iditem", r.GetValue("idItem"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("gravado", r.GetValue("origen"))

        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("item", r.GetValue("descripcion"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("unidad", r.GetValue("unidad"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("tipoEx", r.GetValue("tipoExistencia"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("cantidad", r.GetValue("cantidad"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", r.GetValue("importeMN"))
        '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoME", r.GetValue("importeME"))

        '        Me.dgvEnvioAlmacen.Table.AddNewRecord.EndEdit()
        '    Case Else
        For x = 0 To intNumero - 1
            Dim r As Record = dgvTransito.Table.CurrentRecord
            Dim cantidad As Decimal = Math.Round(CDec(r.GetValue("cantidad")) / intNumero, 2)
            Dim montoMN As Decimal = Math.Round(CDec(r.GetValue("importeMN")) / intNumero, 2)
            Dim montoME As Decimal = Math.Round(CDec(r.GetValue("importeME")) / intNumero, 2)
            Dim precunitMN As Decimal = Math.Round(CDec(r.GetValue("saldoMontoMN")) / CDec(r.GetValue("saldoCan")), 2)
            Dim precunitME As Decimal = Math.Round(CDec(r.GetValue("saldoMontoME")) / CDec(r.GetValue("saldoCan")), 2)

            Me.dgvEnvioAlmacen.Table.AddNewRecord.SetCurrent()
            Me.dgvEnvioAlmacen.Table.AddNewRecord.BeginEdit()
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("idDocumento", r.GetValue("idDocumento"))
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("secuencia", r.GetValue("secCompra"))
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("fecha", r.GetValue("fechaCompra"))
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("tipodoc", r.GetValue("comprobanteCompra"))
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("serie", 1)
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("numero", 1)
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("iditem", r.GetValue("idItem"))
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("gravado", r.GetValue("origen"))

            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("item", r.GetValue("descripcion"))
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("unidad", r.GetValue("unidad"))
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("tipoEx", r.GetValue("tipoExistencia"))
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("cantidad", 0) ' cantidad)
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", 0) 'montoMN)
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoME", 0) ' montoME)
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("puMN", precunitMN) ' montoME)
            Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("puME", precunitME) ' montoME)

            Me.dgvEnvioAlmacen.Table.AddNewRecord.EndEdit()
        Next
        'End Select

    End Sub

    Private Sub GridColumnConfig()
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("iditem")
        dt.Columns.Add("gravado")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        dt.Columns.Add("almacenEnvio")
        dt.Columns.Add("puMN")
        dt.Columns.Add("puME")

        dgvEnvioAlmacen.DataSource = dt
    End Sub

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

    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0

    Private Sub GetKardexByPerido()
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
        For Each i As InventarioMovimiento In inventario.GetKardexByPerido(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
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
        dgvKardex2.TopLevelGroupOptions.ShowCaption = True
    End Sub

    Private Sub GetKardexByAnio()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing

        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex - Año " & txtPeriodo.Value.Year)
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
        For Each i As InventarioMovimiento In inventario.GetKardexByAnio(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)})
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

                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
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
                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
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
        dgvKardex2.TopLevelGroupOptions.ShowCaption = True
    End Sub

    Private Sub GetKardexPeridoByExistencia(envio As BusquedaExstencia)
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing

        '-----------------------------------------------------------------------------------------------------

        Dim dt As New DataTable("kárdex / " & envio.NombreExistencia & ", " & txtPeriodo.Value.Month & "/" & txtPeriodo.Value.Year)
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
        For Each i As InventarioMovimiento In inventario.GetKardexPeridoByExistencia(New InventarioMovimiento With {.idAlmacen = cboalmacenKardex.SelectedValue, .fecha = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1),
                                                                                                                    .tipoExistencia = envio.TipoExistencia, .idItem = envio.IdExistencia})
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
        dgvKardex2.TopLevelGroupOptions.ShowCaption = True
    End Sub


    Public Sub GetInventarioTransito(strMes As String, strAnio As String, strTipoEx As String)
        Dim inventarioBL As New DocumentoCompraSA
        Dim compra As New documentocompra
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

        dt.Columns.Add("guiaCan") ' 29
        dt.Columns.Add("guiaMontoMN") ' 29
        dt.Columns.Add("guiaMontoME") ' 29
        dt.Columns.Add("saldoCan") ' 29
        dt.Columns.Add("saldoMontoMN") ' 29
        dt.Columns.Add("saldoMontoME") ' 29

        compra = New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                           .tipoCompra = TIPO_COMPRA.COMPRA, .idProveedor = cboproveedor.SelectedValue, .TipoExistencia = cboTipoExistenciaTransito.SelectedValue}


        For Each i In inventarioBL.GetExistenciaTransito(compra)


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = (i.destino)
            dr(1) = (i.tipoExistencia)
            dr(2) = (i.almacenRef)
            dr(3) = ("ALM. VIRT") 'i.NombreAlmacen)
            dr(4) = (i.idDocumento)
            dr(5) = (i.idEntidad)
            dr(6) = i.NombreProveedor
            dr(7) = i.idItem
            dr(8) = i.descripcionItem
            dr(9) = (i.monto1)
            dr(10) = (i.unidad1)
            If (CDec(i.monto1) > 0) Then
                dr(11) = Math.Round(CDec(i.montokardex) / CDec(i.monto1), 2)
                dr(20) = Math.Round(CDec(i.montokardexUS) / CDec(i.monto1), 2)
            End If
            dr(12) = (FormatNumber(i.montokardex, 2))
            dr(13) = (FormatNumber(i.montokardexUS, 2))
            dr(14) = String.Empty
            dr(15) = String.Empty
            dr(16) = (FormatDateTime(i.FechaDoc, DateFormat.GeneralDate))

            dr(17) = (i.TipoDoc)
            dr(18) = i.Serie & "-" & i.NumDoc
            dr(19) = (i.tipoCambio)
            dr(21) = (i.destino)
            dr(22) = (i.idDocumento)
            dr(23) = Nothing
            dr(24) = ("INTERNO")
            dr(25) = (i.Glosa)
            dr(26) = String.Empty
            dr(27) = ""
            dr(28) = (i.NombreProveedor)
            dr(29) = (i.secuencia)
            dr(30) = String.Empty

            dr(31) = i.GuiaCantidad
            dr(32) = i.GuiaMontoMN
            dr(33) = i.GuiaMontoME
            dr(34) = i.SaldoCantidad
            dr(35) = i.SaldoMontoMN
            dr(36) = i.SaldoMontoME
            dt.Rows.Add(dr)
        Next
        dgvTransito.DataSource = dt
        dgvTransito.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

    End Sub

    Private Sub GetInventarioValorizado(intIdAlmacen As Integer)
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
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))

        For Each i As totalesAlmacen In totalesAlmacenSA.GetProductosByAlmacen(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                               .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                               .idAlmacen = intIdAlmacen,
                                                                               .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, cboTipoExistencia.SelectedValue)
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
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dt.Rows.Add(dr)
        Next
        dgvKardexVal.DataSource = dt
    End Sub

    Private Sub CargarCMB()
        Dim almacenSA As New almacenSA
        Dim almacen As New List(Of almacen)
        Dim tablaSA As New tablaDetalleSA
        Dim lista As New List(Of tabladetalle)

        almacen = New List(Of almacen)
        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacen

        almacen = New List(Of almacen)
        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        cboalmacenKardex.DisplayMember = "descripcionAlmacen"
        cboalmacenKardex.ValueMember = "idAlmacen"
        cboalmacenKardex.DataSource = almacen
        cboalmacenKardex.Text = "ALM CENTRAL"
        ' cboalmacenKardex.se = 0

        lista = New List(Of tabladetalle)
        lista = tablaSA.GetListaTablaDetalle(5, "1")
        lista.Add(New tabladetalle With {.idtabla = 5, .codigoDetalle = "00", .codigoDetalle2 = "00", .descripcion = "-Todos-"})

        cboTipoExistenciaTransito.DisplayMember = "descripcion"
        cboTipoExistenciaTransito.ValueMember = "codigoDetalle"
        cboTipoExistenciaTransito.DataSource = lista
        cboTipoExistenciaTransito.SelectedValue = "00"

        'lista = New List(Of tabladetalle)
        'lista = tablaSA.GetListaTablaDetalle(5, "1")
        'lista.Add(New tabladetalle With {.idtabla = 5, .codigoDetalle = "00", .codigoDetalle2 = "00", .descripcion = "-Todos-"})

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = lista

    End Sub

#End Region

    Private Sub frmPos_0_Inventario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmPos_0_Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtfecInicio.Value = DiaLaboral
        txtfecFin.Value = DiaLaboral
        txtAnioCompra.Text = AnioGeneral
        Meses()
        Dim almacenSA As New almacenSA
        treeViewAdv2.BackColor = Color.MediumSeaGreen


        ToolStripButton15.Visible = False
        ToolStripButton16.Visible = False


        lblAlertaStock.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblAlertaStock.AutoSize = False
        lblAlertaStock.BackColor = Color.Transparent
        lblAlertaStock.Dock = DockStyle.Fill
        lblAlertaStock.ForeColor = Color.Yellow
        lblAlertaStock.TextAlign = ContentAlignment.MiddleLeft
        Me.treeViewAdv2.Nodes(3).CustomControl = lblAlertaStock

        cboAlmacen.Enabled = True
        cboTipoExistencia.Enabled = False
        cboalmacenKardex.Enabled = True
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        LoadingAnimator.Wire(Me.dgvKardexVal.TableControl)
        If cboAlmacen.SelectedIndex > -1 Then
            Dim codAlmacen = cboAlmacen.SelectedValue
            If IsNumeric(codAlmacen) Then
                GetInventarioValorizado(codAlmacen)
            End If
        End If
        LoadingAnimator.UnWire(Me.dgvKardexVal.TableControl)
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Dashboard"
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                TabDashboard.Parent = TabControlAdv1
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabKardex.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
            Case "transito"
                GridCFG2(dgvTransito)
                ToolStripButton15.Visible = True
                ToolStripButton16.Visible = True
                GridCFG2(dgvTransito)
                TabDashboard.Parent = Nothing
                TabTransito.Parent = TabControlAdv1
                TabInventario.Parent = Nothing
                TabKardex.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
            Case "resumen"
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGInventarios(dgvKardexVal)
                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabKardex.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabInventario.Parent = TabControlAdv1

            Case "kardex"
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGKardex(dgvKardex2)

                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabKardex.Parent = TabControlAdv1

            Case "periodo"
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGKardex(dgvMov)

                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = TabControlAdv1
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = Nothing
            Case "Alerta"

                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGKardex(dgvStockMinimo)

                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
            Case "rotacion"
                ToolStripButton15.Visible = False
                ToolStripButton16.Visible = False
                GridCFGKardex(dgvRotacion)

                TabDashboard.Parent = Nothing
                TabTransito.Parent = Nothing
                TabInventario.Parent = Nothing
                TabMovimientos.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAlertaInventario.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1

        End Select
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        If cboTipoExistenciaTransito.SelectedIndex > -1 Then
            GetInventarioTransito(MesGeneral, AnioGeneral, cboTipoExistenciaTransito.SelectedValue)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        Me.dgvTransito.Table.SelectedRecords.Clear()
        Me.dgvTransito.Table.Records.SelectAll()
    End Sub

    'Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
    '    Try
    '        If dgvTransito.Table.SelectedRecords.Count > 0 Then
    '            If rbParcial.Checked = True Then
    '                Dim f As New frmEnvioExistencia
    '                f.Movimiento = "Parcial"
    '                f.Label6.Visible = False
    '                f.Label2.Visible = False
    '                f.cboAlmacen.Visible = False
    '                f.cboAlmacen.Visible = False
    '                f.cboEstable.Visible = False
    '                f.StartPosition = FormStartPosition.CenterParent
    '                f.ShowDialog()
    '                If Not IsNothing(f.Tag) Then
    '                    Dim envio = CType(f.Tag, EnvioExistencia)
    '                    GrabarEnvioParcial(envio)
    '                End If


    '            Else
    '                Dim f As New frmEnvioExistencia
    '                f.Movimiento = "Masivo"
    '                f.StartPosition = FormStartPosition.CenterParent
    '                f.Label6.Visible = True
    '                f.Label2.Visible = True
    '                f.cboAlmacen.Visible = True
    '                f.cboAlmacen.Visible = True
    '                f.ShowDialog()
    '                If Not IsNothing(f.Tag) Then
    '                    Dim envio = CType(f.Tag, EnvioExistencia)
    '                    GrabarEnvioMasivo(envio)
    '                End If
    '            End If
    '            dgvEnvioAlmacen.Table.Records.DeleteAll()
    '            ButtonAdv15_Click(sender, e)
    '            GetCountExistenciaTransito()
    '        Else
    '            MessageBox.Show("Debe seleccionar items para el envio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End Try
    'End Sub

    Private Sub Panel16_Click(sender As Object, e As EventArgs) Handles Panel16.Click
        If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
            dgvEnvioAlmacen.Table.Records.DeleteAll()
            AsiganarItem(txtNumero.Value)
        End If
    End Sub

    Private Sub Panel16_Paint(sender As Object, e As PaintEventArgs) Handles Panel16.Paint

    End Sub

    Private Sub rbCompleta_CheckChanged(sender As Object, e As EventArgs) Handles rbCompleta.CheckChanged
        If rbCompleta.Checked = True Then
            ToolStripButton15.Visible = True
            'ToolStripButton16.Visible = True
            Panel14.Visible = False
        End If
    End Sub

    Private Sub rbParcial_CheckChanged(sender As Object, e As EventArgs) Handles rbParcial.CheckChanged
        If rbParcial.Checked = True Then
            ToolStripButton15.Visible = False
            'ToolStripButton16.Visible = False
            Panel14.Visible = True
        End If
    End Sub

    Private Sub dgvTransito_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvTransito.TableControlCellClick
        If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
            txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
            txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
        End If
    End Sub

    Private Sub dgvEnvioAlmacen_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvEnvioAlmacen.SelectedRecordsChanged
        If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
            If (CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan") > 0)) Then
                rbCompleta.Enabled = True
                rbParcial.Enabled = True
                txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
            Else
                ToolStripButton15.Visible = True
                rbCompleta.Checked = True
                Panel14.Visible = False
                rbCompleta.Enabled = True
                rbParcial.Enabled = False
                txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
            End If
        End If
    End Sub

    Private Sub dgvEnvioAlmacen_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEnvioAlmacen.TableControlCellClick
        If Not IsNothing(dgvTransito.Table.CurrentRecord) Then
            If (CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan") > 0)) Then
                rbCompleta.Enabled = True
                rbParcial.Enabled = True
                txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
            Else
                ToolStripButton15.Visible = True
                rbCompleta.Checked = True
                Panel14.Visible = False
                rbCompleta.Enabled = True
                rbParcial.Enabled = False
                txtCanDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoCan")).ToString("N2")
                txtMontoDisponible.Text = CDec(dgvTransito.Table.CurrentRecord.GetValue("saldoMontoMN")).ToString("N2")
            End If

        End If
    End Sub

    Private Sub dgvEnvioAlmacen_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvEnvioAlmacen.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0
        Dim PUmn As Decimal = 0
        Dim PUme As Decimal = 0
        If Not IsNothing(Me.dgvTransito.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 9
                    Dim colCan = ValidarExistenciaDisponible("cantidad")
                    If CDec(txtCanDisponible.Text) < colCan Then
                        MessageBox.Show("La cantidad disponible no debe exceder!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("cantidad", 0)
                        Exit Sub
                    Else
                        PUmn = CType(dgvEnvioAlmacen.Table.CurrentRecord.GetValue("puMN"), Decimal)
                        PUme = CType(dgvEnvioAlmacen.Table.CurrentRecord.GetValue("puME"), Decimal)

                        colMN = PUmn * Val(Me.dgvEnvioAlmacen.Table.CurrentRecord.GetValue("cantidad"))
                        colME = PUme * Val(Me.dgvEnvioAlmacen.Table.CurrentRecord.GetValue("cantidad"))
                        dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", colMN)
                        dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoME", colME)
                    End If
                    'Case 10
                    '    Dim colMonto = ValidarExistenciaDisponible("montoMN")
                    '    If CDec(txtMontoDisponible.Text) < colMonto Then
                    '        MessageBox.Show("El monto disponible no debe exceder!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '        Me.dgvEnvioAlmacen.Table.CurrentRecord.SetValue("montoMN", 0)
                    '        Exit Sub
                    '    End If
            End Select
        End If
    End Sub

    Private Sub Panel15_Click(sender As Object, e As EventArgs) Handles Panel15.Click
        If Not IsNothing(dgvEnvioAlmacen.Table.CurrentRecord) Then
            dgvEnvioAlmacen.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub Panel15_Paint(sender As Object, e As PaintEventArgs) Handles Panel15.Paint

    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        LoadingAnimator.Wire(Me.dgvKardex2.TableControl)
        GetKardexByAnio()
        LoadingAnimator.UnWire(Me.dgvKardex2.TableControl)
    End Sub

    Private Sub CompraDeExistenciasServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDeExistenciasServiciosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabMovimientos Then

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "0000"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    ' .lblPerido.Text = PeriodoGeneral
                    '     .cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDeServiciosPúblicosToolStripMenuItem.Click
        If TabControlAdv1.SelectedTab Is TabMovimientos Then
            Me.Cursor = Cursors.WaitCursor
            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .cboOperacion.SelectedValue = "0001"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    '  .lblPerido.Text = PeriodoGeneral
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If


            Me.Cursor = Cursors.Arrow
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub RegistroDeHonorariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeHonorariosToolStripMenuItem.Click
        If TabControlAdv1.SelectedTab Is TabMovimientos Then
            Me.Cursor = Cursors.WaitCursor
            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmMovimientoAlmacen
                    .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    '   .lblPerido.Text = PeriodoGeneral
                    '.cambioMovimiento()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
            Me.Cursor = Cursors.Arrow
        Else
            MessageBoxAdv.Show("Debe seleccionar movimientos del período !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        'Dim f As New frmNuevoAlmacen
        'f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub Panel22_Click(sender As Object, e As EventArgs) Handles Panel22.Click
        LoadingAnimator.Wire(Me.dgvKardex2.TableControl)
        Dim f As New frmBusquedaKardex(cboalmacenKardex.SelectedValue)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim envio = CType(f.Tag, BusquedaExstencia)
            GetKardexPeridoByExistencia(envio)
        End If
        LoadingAnimator.UnWire(Me.dgvKardex2.TableControl)
    End Sub

    Private Sub Panel22_Paint(sender As Object, e As PaintEventArgs) Handles Panel22.Paint

    End Sub

    Private Sub ConsignacioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsignacioneToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .cboOperacion.SelectedValue = "03.01"
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PromociónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromociónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .cboOperacion.SelectedValue = "07.01"
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PremioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PremioToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .cboOperacion.SelectedValue = "08.01"
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DonaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonaciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .cboOperacion.SelectedValue = "09.01"
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ProductosTerminadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosTerminadosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .cboOperacion.SelectedValue = "10.03"
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SubProductosDesechosYDesperdiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubProductosDesechosYDesperdiciosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .cboOperacion.SelectedValue = "9904"
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ProductosEnProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosEnProcesoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .cboOperacion.SelectedValue = "10.07"
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .cboOperacion.SelectedValue = "05"
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OtrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtrosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovOtrasEntradas
            .cboOperacion.SelectedValue = "0000"
            .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ConsignacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsignacionesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            .cboOperacion.SelectedValue = "04.01"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PremioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PremioToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            .cboOperacion.SelectedValue = "08.02"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DonaciónToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DonaciónToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            .cboOperacion.SelectedValue = "09.02"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            '     .cambioMovimiento()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RetiroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetiroToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            .cboOperacion.SelectedValue = "12"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub MermasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MermasToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            .cboOperacion.SelectedValue = "13"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DesmedorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesmedorsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            .cboOperacion.SelectedValue = "14"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DestrucciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DestrucciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            .cboOperacion.SelectedValue = "15"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            .GroupBox2.Visible = True
            .cboOperacion.SelectedValue = "10.01"
            .rbCosto.Checked = True
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DevolucionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DevolucionesToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            .cboOperacion.SelectedValue = "06"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OtrosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OtrosToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        With frmOtrasSalidasDeAlmacen
            .cboOperacion.SelectedValue = "0001"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Dashboard"

            Case "transito"

            Case "resumen"

            Case "kardex"

            Case "periodo"
                '       GetMovPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)

            Case "Alerta"
                GetInventarioEnAlerta(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        End Select
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        If TabControlAdv1.SelectedTab Is TabMovimientos Then
            If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "TRANSFERENCIA ENTRE ALMACENES" Then ' TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES Then
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
                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "ENTRADA DE EXISTENCIAS" Then
                    With frmMovOtrasEntradas
                        .btGrabar.Enabled = False
                        .GuardarToolStripButton.Enabled = True
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                        .WindowState = FormWindowState.Normal
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "SALIDA DE EXISTENCIAS" Then
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
            End If
        End If
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        If TabControlAdv1.SelectedTab Is TabMovimientos Then
            If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then

                'If MessageBox.Show("eliminar el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "TRANSFERENCIA ENTRE ALMACENES" Then
                '    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                '        EliminarTransferenciaAlmacen(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                '        Me.dgvMov.Table.CurrentRecord.Delete()
                '        PanelError.Visible = True
                '        lblEstado.Text = "entrada eliminada!"
                '        'Timer1.Enabled = True
                '        'TiempoEjecutar(10)
                '    End If
                If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "ENTRADA DE EXISTENCIAS" Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        RemoveCompra(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                        Me.dgvMov.Table.CurrentRecord.Delete()
                        PanelError.Visible = True
                        lblEstado.Text = "entrada eliminada!"
                        'Timer1.Enabled = True
                        'TiempoEjecutar(10)
                    End If
                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "SALIDA DE EXISTENCIAS" Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarOtrasSalidas(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                        Me.dgvMov.Table.CurrentRecord.Delete()
                        PanelError.Visible = True
                        lblEstado.Text = "Registro eliminado!"
                        'Timer1.Enabled = True
                        'TiempoEjecutar(10)
                    End If
                End If
                'End If


            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
            LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        If TabControlAdv1.SelectedTab Is TabMovimientos Then
            '       GetMovPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        ElseIf TabControlAdv1.SelectedTab Is TabAlertaInventario Then
            GetInventarioEnAlerta(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        End If
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()
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

    Private Sub dgvKardex2_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardex2.TableControlCellClick

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
    Private Sub dgvKardex2_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvKardex2.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvKardex2)
    End Sub

    Private Sub PanelError_Paint(sender As Object, e As PaintEventArgs) Handles PanelError.Paint

    End Sub


    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Cursor = Cursors.WaitCursor
        If cboConsultaRotacion.Text = "0 - 10 unidades" Then
            VentasCantidadStock("1", txtfecInicio.Value, txtfecFin.Value, CDec(10.0), CDec(0.0), "filtro de 0 - 10 unidades")
        ElseIf cboConsultaRotacion.Text = "11 - 100 unidades" Then
            VentasCantidadStock("2", txtfecInicio.Value, txtfecFin.Value, CDec(100.0), CDec(11), "filtro de 11 - 100 unidades")
        ElseIf cboConsultaRotacion.Text = "101 - 500 unidades" Then
            VentasCantidadStock("3", txtfecInicio.Value, txtfecFin.Value, CDec(500.0), CDec(101), "filtro de 101 - 500 unidades")
        ElseIf cboConsultaRotacion.Text = "501 - a mas" Then
            VentasCantidadStock("4", txtfecInicio.Value, txtfecFin.Value, CDec(99999999), CDec(501), "filtro de 501 - a mas unidades")
        ElseIf cboConsultaRotacion.Text = "0 - a mas" Then
            VentasCantidadStock("4", txtfecInicio.Value, txtfecFin.Value, CDec(99999999), CDec(0), "filtro de  0 - a mas unidades")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub txtDiasAtraso_ValueChanged(sender As Object, e As EventArgs) Handles txtDiasAtraso.ValueChanged
        Dim valor = txtDiasAtraso.Value
        Dim s As New DateTime
        s = DateTime.Now
        Dim addDay As DateTime = s.AddDays(CInt(-(valor)))
        txtfecFin.Value = DateTime.Now
        txtfecInicio.Value = addDay
    End Sub
    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If TabControlAdv1.SelectedTab Is TabInventario Then
            Me.dgvKardexVal.TopLevelGroupOptions.ShowFilterBar = True
            Me.dgvKardexVal.NestedTableGroupOptions.ShowFilterBar = True
            Me.dgvKardexVal.ChildGroupOptions.ShowFilterBar = True

            For Each col As GridColumnDescriptor In Me.dgvKardexVal.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True
        End If
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        If TabControlAdv1.SelectedTab Is TabInventario Then
            dgvKardexVal.TableDescriptor.GroupedColumns.Clear()
            If dgvKardexVal.ShowGroupDropArea = True Then
                dgvKardexVal.ShowGroupDropArea = False
            Else
                dgvKardexVal.ShowGroupDropArea = True
            End If
        End If

    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        If TabControlAdv1.SelectedTab Is TabInventario Then
            filter.ClearFilters(Me.dgvKardexVal)
            Me.dgvKardexVal.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub Panel28_Click(sender As Object, e As EventArgs) Handles Panel28.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.dgvKardexVal, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Do you wish to open the xls file now?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If


    End Sub

    Private Sub dgvKardexVal_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardexVal.TableControlCellClick

    End Sub

    Private Sub dgvKardexVal_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvKardexVal.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim totalesSA As New TotalesAlmacenSA
        If Not IsNothing(Me.dgvKardexVal.Table.CurrentRecord) Then

            dgvKardexVal.TableControl.CurrentCell.EndEdit()
            dgvKardexVal.TableControl.Table.TableDirty = True
            dgvKardexVal.TableControl.Table.EndEdit()

            Select Case ColIndex
                Case 10 'max
                    If CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmax")) <= 0 Then
                        MessageBox.Show("El número ingresado debe ser mayor a cero", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    'If CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmin")) <= 0 Then
                    '    MessageBox.Show("El número ingresado debe ser mayor a cero", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Exit Sub
                    'End If

                    Dim canMax As Decimal = CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmax"))
                    Dim canMin As Decimal = CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmin"))

                    If canMax <= canMin Then
                        MessageBox.Show("La cantidad máxima debe ser mayor a la cantidad mínima", "Informmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    totalesSA.ActulizarCantidadesByItem(New totalesAlmacen With {.idMovimiento = dgvKardexVal.Table.CurrentRecord.GetValue("idmovimiento"),
                                                                                 .cantidadMaxima = canMax, .cantidadMinima = canMin})

                    MessageBox.Show("Datos actualizados", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dgvKardexVal.Table.CurrentRecord.SetValue("cantmax", canMax.ToString("N2"))

                    GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
                Case 11 ' min

                    'If CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmax")) <= 0 Then
                    '    MessageBox.Show("El número ingresado debe ser mayor a cero", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Exit Sub
                    'End If

                    If CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmin")) <= 0 Then
                        MessageBox.Show("El número ingresado debe ser mayor a cero", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Dim canMax As Decimal = CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmax"))
                    Dim canMin As Decimal = CDec(Me.dgvKardexVal.Table.CurrentRecord.GetValue("cantmin"))

                    If canMin >= canMax Then
                        MessageBox.Show("La cantidad mínima no pueder ser mayor o igual a la cantidad máxima", "Informmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    totalesSA.ActulizarCantidadesByItem(New totalesAlmacen With {.idMovimiento = dgvKardexVal.Table.CurrentRecord.GetValue("idmovimiento"),
                                                                                 .cantidadMaxima = canMax, .cantidadMinima = canMin})

                    MessageBox.Show("Datos actualizados", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dgvKardexVal.Table.CurrentRecord.SetValue("cantmin", canMin.ToString("N2"))
                    GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
            End Select

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
    End Sub

    Private Sub Panel28_Paint(sender As Object, e As PaintEventArgs) Handles Panel28.Paint

    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        If cboMesCompra.Text.Trim.Length > 0 Then
            GetMovPorPeriodo(GEstableciento.IdEstablecimiento, cboMesCompra.SelectedValue & "/" & AnioGeneral)
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesCompra.Select()
            cboMesCompra.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        Dim r As Record = dgvMov.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmCambiarPeriodo2(New documentocompra With {.idDocumento = Val(r.GetValue("idDocumento"))})
            f.operacion = StatusTipoOperacion.COMPRA
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            ButtonAdv19_Click(sender, e)
        End If
    End Sub

    Private Sub GradientPanel11_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel11.Paint

    End Sub
End Class
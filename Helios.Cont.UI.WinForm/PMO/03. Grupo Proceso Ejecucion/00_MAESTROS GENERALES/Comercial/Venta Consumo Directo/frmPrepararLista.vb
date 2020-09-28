Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmPrepararLista
    Inherits frmMaster
    Public Property ListaProductosByAlmacen() As List(Of totalesAlmacen)
    Public Property ListaColoresUsados() As List(Of totalesAlmacen)


    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        GridCFG(dgvDetalle)
        GridCFGDetalle(dgvProceso)
        GridCFG(dgPLantilla)
        ' Add any initialization after the InitializeComponent() call.
        ListaProductosByAlmacen = New List(Of totalesAlmacen)
        LoadControls()
        Tag = intIdDocumento

        UbicarDetalleVenta(intIdDocumento)
        ListaColoresUsados = New List(Of totalesAlmacen)

    End Sub

#Region "Métodos"
    Sub GridCFGDetalle(grid As GridGroupingControl)
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
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()
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

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub GetPLantillasByArticulo(be As detalleitems)
        Dim plantillaSA As New articuloplantillaSA
        Dim plantilla As New List(Of articuloplantilla)
        Dim dt As New DataTable
        Dim valPadre As Integer = 0

        dt.Columns.Add("idpadre")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("color")
        dt.Columns.Add("cantidad")

        plantilla = plantillaSA.GetPlantillaByArticulo(be)
        If plantilla.Count > 0 Then
            valPadre = plantilla(0).idpadre
        End If
        Dim conteo As Integer = 1

        For Each i In plantilla
            If valPadre = i.idpadre Then

            Else
                valPadre = i.idpadre
                conteo = conteo + 1
            End If
            dt.Rows.Add(i.idpadre, "Platilla " & conteo, i.descripcion, i.cant)
        Next
        dgPLantilla.DataSource = dt
        dgPLantilla.TableDescriptor.GroupedColumns.Clear()
        dgPLantilla.TableDescriptor.GroupedColumns.Add("descripcion")
    End Sub

    Public Sub LoadControls()
        Dim almacenSA As New almacenSA

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})


    End Sub

    Public Sub GetColumnMapping(intPT As Integer)
        If ListaColoresUsados.Count > 0 Then
            Dim dt As New DataTable
            dt.Columns.Add("idalmacen")
            dt.Columns.Add("almacen")
            dt.Columns.Add("iditem")
            dt.Columns.Add("item")
            dt.Columns.Add("um")
            dt.Columns.Add("cant")
            dt.Columns.Add("pu")
            dt.Columns.Add("costo")
            dt.Columns.Add("stock")
            dt.Columns.Add("requerido")

            For Each i In ListaColoresUsados.Where(Function(o) o.idItemPadre = intPT)
                dt.Rows.Add(i.idAlmacen, String.Empty, i.idItem, i.descripcion, i.idUnidad, i.cantidad, i.precioUnitarioCompra, i.importeSoles, i.cantidadMaxima, CDec(txtCantDisponible.Text) * i.cantidad)
                'obj.idAlmacen = cboAlmacen.SelectedValue
                'obj.idItem = Val(i.GetValue("iditem"))
                'obj.descripcion = i.GetValue("item")
                'obj.idUnidad = txtUMRQ.Text
                'obj.tipoExistencia = TipoExistencia.MateriaPrima
                'obj.cantidad = CDec(i.GetValue("cant"))
                'obj.importeSoles = CDec(i.GetValue("costo"))
                'obj.TipoAcces = "SC"
                'obj.idItemPadre = txtProductoTerminado.Tag
                'lista.Add(obj)
            Next

            dgvProceso.DataSource = dt
        End If


    End Sub


    Sub editarItem(iditem As Integer)
        Dim r As Record = dgvProceso.Table.CurrentRecord
        Dim obj = ListaColoresUsados.Where(Function(o) o.idItem = iditem).FirstOrDefault
        If Not IsNothing(obj) Then
            obj.cantidad = CDec(r.GetValue("cant"))
            obj.importeSoles = CDec(r.GetValue("cant")) * CDec(r.GetValue("pu"))
        End If
    End Sub

    Sub UbicarDetalleVenta(intIdDocumento As Integer)
        Dim ventaSA As New documentoVentaAbarrotesDetSA
        Dim dt As New DataTable()
        dt.Columns.Add("sec")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("marca")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        Dim cant As Decimal = 0
        For Each i In ventaSA.UbicarDetallePinturas(intIdDocumento)
            cant += CDec(i.monto1.GetValueOrDefault)
            dt.Rows.Add(i.secuencia,
                        i.idItem, i.nombreItem, i.NomMarca, "Glns.", i.monto1.GetValueOrDefault)
        Next
        lblPedido.Text = cant.ToString("N2")
        dgvDetalle.DataSource = dt
    End Sub

#End Region

#Region "Asientos"
    Public Function AsientoTransferenciaMercaderiaToMatPrima() As List(Of asiento)
        'Dim docSA As New documentoconsumodirectoSA
        'Dim Lista As New List(Of documentoconsumodirecto)
        'Dim venta As New documentoventaAbarrotes
        'Dim ventaSA As New documentoVentaAbarrotesSA
        Dim nAsiento As New asiento
        Dim listaAsiento As New List(Of asiento)
        Dim nMovimiento As New movimiento
        Dim totaMN As Decimal = 0
        Dim totaME As Decimal = 0


        listaAsiento = New List(Of asiento)

        'venta = ventaSA.GetUbicar_documentoventaAbarrotesPorID(Me.Tag)

        'Lista = docSA.GetConsumoByidDocumento(New documentoconsumodirecto With {.idDocumento = Val(Me.Tag)})

        'Asiento Transferencia de mercaderia a materia prima
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento

        nAsiento.idEntidad = 0
        nAsiento.nombreEntidad = lblNomCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE

        nAsiento.fechaProceso = txtFechaEntrega.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Por la transferencia de mercaderia a materia prima"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now


        totaMN = 0
        totaME = 0
        For Each i In ListaColoresUsados
            totaMN += i.importeSoles

            nMovimiento = New movimiento
            nMovimiento.cuenta = "241"
            nMovimiento.descripcion = i.descripcion
            nMovimiento.tipo = "D"
            nMovimiento.monto = i.importeSoles
            nMovimiento.montoUSD = 0
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "20111"
            nMovimiento.descripcion = i.descripcion
            nMovimiento.tipo = "H"
            nMovimiento.monto = i.importeSoles
            nMovimiento.montoUSD = 0
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)
        Next
        nAsiento.importeMN = totaMN
        nAsiento.importeME = 0
        listaAsiento.Add(nAsiento)

        '------------------------------------------------------------------------------------------------

        'Asiento Salida de materia prima a produccion
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = 0
        nAsiento.nombreEntidad = lblNomCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFechaEntrega.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Sálida de materia prima a producción"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        totaMN = 0
        totaME = 0
        For Each i In ListaColoresUsados
            totaMN += i.importeSoles

            nMovimiento = New movimiento
            nMovimiento.cuenta = "6121"
            nMovimiento.descripcion = i.descripcion
            nMovimiento.tipo = "D"
            nMovimiento.monto = i.importeSoles
            nMovimiento.montoUSD = 0
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "241"
            nMovimiento.descripcion = i.descripcion
            nMovimiento.tipo = "H"
            nMovimiento.monto = i.importeSoles
            nMovimiento.montoUSD = 0
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)
        Next
        nAsiento.importeMN = totaMN
        nAsiento.importeME = 0
        listaAsiento.Add(nAsiento)

        '------------------------------------------------------------------------------------------------

        Return listaAsiento
    End Function

    Public Function AsientoProductoTerminado() As List(Of asiento)
        Dim nAsiento As New asiento
        Dim ListaGeneralAsiento As New List(Of asiento)
        Dim nMovimiento As New movimiento
        Dim consumoSA As New documentoconsumodirectoSA
        Dim venta As New documentoVentaAbarrotesDetSA
        Dim Listaventa As New List(Of documentoventaAbarrotesDet)
        Dim totalMN As Decimal = 0

        ListaGeneralAsiento = New List(Of asiento)
        Listaventa = New List(Of documentoventaAbarrotesDet)

        'Asiento Transferencia de mercaderia a materia prima
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        'If txtCliente.Text.Trim.Length > 0 Then
        nAsiento.idEntidad = 0
        nAsiento.nombreEntidad = lblNomCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        'End If
        nAsiento.fechaProceso = txtFechaEntrega.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Productos en proceso"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        totalMN = 0

        Listaventa = venta.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(Tag))

        For Each i In Listaventa.Where(Function(o) o.tipoExistencia = TipoExistencia.ProductoTerminado).ToList

            nMovimiento = New movimiento
            nMovimiento.cuenta = "231"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            nMovimiento.monto = ListaColoresUsados.Where(Function(o) o.idItemPadre = i.idItem).Sum(Function(o) o.importeSoles) '  consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            totalMN += CDec(nMovimiento.monto)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "713"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = ListaColoresUsados.Where(Function(o) o.idItemPadre = i.idItem).Sum(Function(o) o.importeSoles)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next
        nAsiento.importeMN = totalMN
        nAsiento.importeME = 0
        ListaGeneralAsiento.Add(nAsiento)


        'Asiento Producto terminado culminado
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = 0
        nAsiento.nombreEntidad = lblNomCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE

        nAsiento.fechaProceso = txtFechaEntrega.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Productos terminados concluidos"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        totalMN = 0
        For Each i In Listaventa.Where(Function(o) o.tipoExistencia = TipoExistencia.ProductoTerminado).ToList

            nMovimiento = New movimiento
            nMovimiento.cuenta = "713"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            nMovimiento.monto = ListaColoresUsados.Where(Function(o) o.idItemPadre = i.idItem).Sum(Function(o) o.importeSoles) 'consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            'totalMN += CDec(nMovimiento.monto)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "231"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = ListaColoresUsados.Where(Function(o) o.idItemPadre = i.idItem).Sum(Function(o) o.importeSoles) ' consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            '-------------- costo----------------------------------------------------------

            nMovimiento = New movimiento
            nMovimiento.cuenta = "921"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            nMovimiento.monto = ListaColoresUsados.Where(Function(o) o.idItemPadre = i.idItem).Sum(Function(o) o.importeSoles) ' consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            totalMN += CDec(nMovimiento.monto)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "791"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = ListaColoresUsados.Where(Function(o) o.idItemPadre = i.idItem).Sum(Function(o) o.importeSoles) ' consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

        Next
        nAsiento.importeMN = totalMN
        nAsiento.importeME = 0
        ListaGeneralAsiento.Add(nAsiento)

        '-----------------------------------------------------------------------------------------------
        'Asiento Ingreso productos terminados a almacen
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento

        nAsiento.idEntidad = 0
        nAsiento.nombreEntidad = lblNomCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE

        nAsiento.fechaProceso = txtFechaEntrega.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Ingreso de productos terminados a almacén"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        totalMN = 0
        For Each i In Listaventa.Where(Function(o) o.tipoExistencia = TipoExistencia.ProductoTerminado).ToList

            nMovimiento = New movimiento
            nMovimiento.cuenta = "211"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            nMovimiento.monto = ListaColoresUsados.Where(Function(o) o.idItemPadre = i.idItem).Sum(Function(o) o.importeSoles) ' consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            totalMN += CDec(nMovimiento.monto)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "713"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = ListaColoresUsados.Where(Function(o) o.idItemPadre = i.idItem).Sum(Function(o) o.importeSoles) 'consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next
        nAsiento.importeMN = totalMN
        nAsiento.importeME = 0
        ListaGeneralAsiento.Add(nAsiento)

        Return ListaGeneralAsiento
    End Function

    Public Function AsientoCostoVenta() As List(Of asiento)
        Dim nAsiento As New asiento
        Dim ListaGeneralAsiento As New List(Of asiento)
        Dim nMovimiento As New movimiento
        Dim consumoSA As New documentoconsumodirectoSA
        Dim venta As New documentoVentaAbarrotesDetSA
        Dim Listaventa As New List(Of documentoventaAbarrotesDet)
        Dim totalMN As Decimal = 0

        Listaventa = New List(Of documentoventaAbarrotesDet)

        ListaGeneralAsiento = New List(Of asiento)
        'Asiento Transferencia de mercaderia a materia prima
        nAsiento = New asiento
        nAsiento.idDocumento = CInt(Me.Tag)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        'If txtCliente.Text.Trim.Length > 0 Then
        nAsiento.idEntidad = 0
        nAsiento.nombreEntidad = lblNomCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        'End If
        nAsiento.fechaProceso = txtFechaEntrega.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = 0
        nAsiento.importeME = 0
        nAsiento.glosa = "Asiento de costo de ventas"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        totalMN = 0
        Listaventa = venta.GetUbicar_documentoventaAbarrotesDetPorIDocumento(Val(Tag))
        For Each i In Listaventa.Where(Function(o) o.tipoExistencia = TipoExistencia.ProductoTerminado).ToList

            nMovimiento = New movimiento
            nMovimiento.cuenta = "692"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
            nMovimiento.monto = ListaColoresUsados.Where(Function(o) o.idItemPadre = i.idItem).Sum(Function(o) o.importeSoles) 'consumoSA.GetSumaBySecuencia(New documentoconsumodirecto With {.secuencia = i.secuencia})
            totalMN += CDec(nMovimiento.monto)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "211"
            nMovimiento.descripcion = i.nombreItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = ListaColoresUsados.Where(Function(o) o.idItemPadre = i.idItem).Sum(Function(o) o.importeSoles)
            nMovimiento.montoUSD = 0
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next
        nAsiento.importeMN = totalMN
        nAsiento.importeME = 0
        ListaGeneralAsiento.Add(nAsiento)
        Return ListaGeneralAsiento
    End Function
#End Region

#Region "Grabar Datos"
    Public Sub Grabar()
        Dim doc As New documento
        Dim docConsumo As New documentoconsumodirecto
        Dim listaConsumo As New List(Of documentoconsumodirecto)
        Dim consumoSA As New documentoconsumodirectoSA
        Dim listaAsientos As New List(Of asiento)

        doc = New documento
        doc.idDocumento = Val(Me.Tag)

        listaConsumo = New List(Of documentoconsumodirecto)
        listaAsientos = New List(Of asiento)

        For Each i In ListaColoresUsados
            docConsumo = New documentoconsumodirecto
            '    docConsumo.secuencia = gdg
            docConsumo.idDocumento = Val(Me.Tag)
            docConsumo.idProductoPadre = i.idMovimiento
            docConsumo.almacen = i.idAlmacen
            docConsumo.idMateriaPrima = i.idItem
            docConsumo.descripcion = i.descripcion
            docConsumo.tipoexistencia = i.tipoExistencia
            docConsumo.unidad = i.idUnidad
            docConsumo.cant = i.cantidad
            docConsumo.costo = i.importeSoles
            listaConsumo.Add(docConsumo)
        Next
        'GetSaveConsumo

        listaAsientos.AddRange(AsientoTransferenciaMercaderiaToMatPrima)
        listaAsientos.AddRange(AsientoProductoTerminado)
        listaAsientos.AddRange(AsientoCostoVenta)

        doc.asiento = listaAsientos

        consumoSA.GetSaveConsumo(doc, listaConsumo)
        MessageBox.Show("Preparación concluída", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
#End Region

    Private Sub frmPrepararLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaEntrega.Value = DateTime.Now
    End Sub

    Function EsCorrecto(intIditem As Integer) As Boolean
        For Each i In dgvProceso.Table.Records
            If intIditem = Val(i.GetValue("iditem")) Then
                MessageBox.Show("El artículo seleccionado ya esta en la canasta," & vbCrLf & "Ingrese otro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub lstProductos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstProductos.MouseDoubleClick
        Dim obj As New totalesAlmacen
        Dim r As Record = dgvDetalle.Table.CurrentRecord
        If Not IsNothing(r) Then
            If lstProductos.SelectedItems.Count > 0 Then
                If lstProductos.SelectedItems.Count > 0 Then
                    'txtBuscar.Text = lstProductos.Text
                    'txtBuscar.Tag = lstProductos.SelectedValue
                    'txtBuscar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                    If EsCorrecto(lstProductos.SelectedValue) = True Then
                        obj = New totalesAlmacen
                        Dim c = ListaProductosByAlmacen.Where(Function(o) o.idItem = lstProductos.SelectedValue).FirstOrDefault
                        Dim pm As Decimal = 0
                        If c.cantidad > 0 Then
                            pm = c.importeSoles / c.cantidad
                        Else
                            pm = 0
                        End If
                        obj.idEmpresa = c.idEmpresa
                        obj.idEstablecimiento = c.idEstablecimiento
                        obj.origenRecaudo = c.origenRecaudo
                        obj.idItem = c.idItem
                        obj.descripcion = c.descripcion
                        obj.tipoExistencia = c.tipoExistencia
                        obj.idUnidad = c.idUnidad
                        obj.idAlmacen = c.idAlmacen


                        'obj.idAlmacen = cboAlmacen.SelectedValue
                        'obj.idItem = Val(i.GetValue("iditem"))
                        'obj.descripcion = i.GetValue("item")
                        'obj.idUnidad = txtUMRQ.Text
                        'obj.tipoExistencia = TipoExistencia.MateriaPrima
                        obj.idMovimiento = Val(dgvDetalle.Table.CurrentRecord.GetValue("sec"))
                        obj.cantidadMaxima = c.cantidad
                        obj.cantidad = 0
                        obj.precioUnitarioCompra = pm
                        obj.importeSoles = 0
                        obj.importeDolares = 0

                        obj.TipoAcces = "SC"
                        obj.idItemPadre = Val(txtProductoSeleccionado.Tag) ' Val(dgvDetalle.Table.CurrentRecord.GetValue("iditem"))
                        ListaColoresUsados.Add(obj)


                        dgvDetalle.TableControl.CurrentCell.EndEdit()
                        dgvDetalle.TableControl.Table.TableDirty = True
                        dgvDetalle.TableControl.Table.EndEdit()
                        GetColumnMapping(Val(txtProductoSeleccionado.Tag))
                    End If

                  

                End If
            End If
        Else
            MessageBox.Show("Debe seleccionar un pedido para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
          
            Dim consulta = (From n In ListaProductosByAlmacen _
                     Where n.descripcion.Contains(txtBuscar.Text) And n.tipoExistencia = TipoExistencia.Mercaderia).ToList

            lstProductos.DataSource = consulta
            lstProductos.DisplayMember = "descripcion"
            lstProductos.ValueMember = "idItem"
            e.Handled = True
        End If

    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        
    End Sub

    Private Sub cboAlmacen_Click(sender As Object, e As EventArgs) Handles cboAlmacen.Click

    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlmacen.SelectedIndexChanged
        Dim totalesSA As New TotalesAlmacenSA

        ListaProductosByAlmacen = New List(Of totalesAlmacen)
        If Not IsNothing(cboAlmacen.SelectedValue) Then
            ListaProductosByAlmacen = totalesSA.GetListaProductosPorAlmacen(cboAlmacen.SelectedValue)
        End If
        txtBuscar.Clear()
        txtBuscar.Select()
    End Sub

    Private Sub dgvDetalle_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvDetalle.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvDetalle.Table.CurrentRecord
        If Not IsNothing(r) Then
            txtProductoSeleccionado.Text = r.GetValue("item")
            txtProductoSeleccionado.Tag = Val(r.GetValue("iditem"))
            txtCantDisponible.Text = CDec(r.GetValue("cantidad"))
            GetColumnMapping(r.GetValue("iditem"))
            GetPLantillasByArticulo(New detalleitems With {.codigodetalle = Val(r.GetValue("iditem"))})
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvProceso_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvProceso.TableControlCellClick

    End Sub
    Sub calculo()
        Dim colRequerido As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colPM As Decimal = 0
        Dim colCosto As Decimal = 0
        Dim disponible As Decimal = 0
        disponible = CDec(dgvProceso.Table.CurrentRecord.GetValue("stock"))
        colCantidad = CDec(dgvProceso.Table.CurrentRecord.GetValue("cant"))
        colRequerido = colCantidad * CDec(txtCantDisponible.Text)

        If colCantidad > disponible Then
            MessageBox.Show("Debe ingresar una cantidad menor o igual a la disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If colCantidad <= 0 Then
            dgvProceso.Table.CurrentRecord.SetValue("cant", 0)
            MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        colPM = CDec(dgvProceso.Table.CurrentRecord.GetValue("pu"))
        colCosto = colCantidad * colPM
        dgvProceso.Table.CurrentRecord.SetValue("costo", colCosto)
        dgvProceso.Table.CurrentRecord.SetValue("requerido", colRequerido)

        editarItem(dgvProceso.Table.CurrentRecord.GetValue("iditem"))
    End Sub
    Private Sub dgvProceso_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvProceso.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvProceso.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 3
                    Dim colRequerido As Decimal = 0
                    Dim colCantidad As Decimal = 0
                    Dim colPM As Decimal = 0
                    Dim colCosto As Decimal = 0
                    Dim disponible As Decimal = 0
                    disponible = CDec(dgvProceso.Table.CurrentRecord.GetValue("stock"))
                    colCantidad = CDec(dgvProceso.Table.CurrentRecord.GetValue("cant"))
                    colRequerido = colCantidad * CDec(txtCantDisponible.Text)

                    If colCantidad > disponible Then
                        MessageBox.Show("Debe ingresar una cantidad menor o igual a la disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    If colCantidad <= 0 Then
                        dgvProceso.Table.CurrentRecord.SetValue("cant", 0)
                        MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    colPM = CDec(dgvProceso.Table.CurrentRecord.GetValue("pu"))
                    colCosto = colCantidad * colPM
                    dgvProceso.Table.CurrentRecord.SetValue("costo", colCosto)
                    dgvProceso.Table.CurrentRecord.SetValue("requerido", colRequerido)

                    editarItem(dgvProceso.Table.CurrentRecord.GetValue("iditem"))

                    'txtCostoRequerido.DoubleValue = GetSumaByColumn("costo")
                    'txtCantRequerida.DoubleValue = GetSumaByColumn("cant")
            End Select
        End If
    End Sub

    Private Sub btnFabricar_Click(sender As Object, e As EventArgs) Handles btnFabricar.Click
        If ListaColoresUsados.Count > 0 Then
            Grabar()
        Else
            MessageBox.Show("Debe realizar la preparacion de los pedidos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

    End Sub

    Private Sub dgPLantilla_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgPLantilla.TableControlCellClick
        Dim r As Record = dgPLantilla.Table.CurrentRecord
        If Not IsNothing(r) Then
            txtBuscar.Text = r.GetValue("color")
        End If
    End Sub

    Private Sub lstProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProductos.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim r As Record
        r = dgvProceso.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim n = ListaColoresUsados.Where(Function(o) o.idItem = Val(r.GetValue("iditem"))).FirstOrDefault
            ListaColoresUsados.Remove(n)
            r.Delete()
        Else
            MessageBox.Show("Debe seleccionar un item a eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 1 / 1
                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 3 / 4
                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 1 / 2

                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 1 / 4
                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 1 / 8
                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        If dgvProceso.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProceso.Table.CurrentRecord) Then
                Dim valor As Decimal = 1 / 32
                Dim col = dgvProceso.Table.CurrentRecord.GetValue("cant")
                If Not IsNothing(col) Then
                    dgvProceso.Table.CurrentRecord.SetValue("cant", valor)
                Else
                    MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                calculo()
            Else
                MessageBox.Show("Debe seleccionar un color válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim f As New frmPlantilla
        f = New frmPlantilla
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub
End Class
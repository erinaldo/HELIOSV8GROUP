Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class frmCierreTotalProduccion

    'Public Sub New(grid As GridGroupingControl)

    '    ' Esta llamada es exigida por el diseñador.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    GridCFGDetetail(dgvCierre)
    '    GetLoadGrid(grid)
    '    GetAlmacenes()
    '    GetStatus()
    '    cboStatus.Text = "Entrega normal"
    '    txtInicio.Value = New DateTime(AnioGeneral, MesGeneral, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
    'End Sub

    Public Sub New(r As Record)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GridCFGDetetail(dgvCierre)
        GetLoadGridByrecord(r)
        GetAlmacenes()
        GetStatus()
        cboStatus.Text = "Entrega normal"
        txtInicio.Value = New DateTime(AnioGeneral, MesGeneral, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
    End Sub

#Region "Mètodos"

    Sub GetStatus()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(CInt(StatusProductosTerminados.Entregado), "Entrega normal")
        dt.Rows.Add(CInt(StatusProductosTerminados.Erroneo), "Entrega con Errores")
        dt.Rows.Add(CInt(StatusProductosTerminados.Observado), "Entrega con observaciones")

        cboStatus.ValueMember = "id"
        cboStatus.DisplayMember = "name"
        cboStatus.DataSource = dt
    End Sub

    Dim sumaMN As Decimal = 0
    Dim sumaME As Decimal = 0
    Sub GrabarDefault()
        Dim asiento As asiento
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim mov As movimiento
        Dim listaAsiento As List(Of asiento)

        dgvCierre.TableControl.CurrentCell.EndEdit()
        dgvCierre.TableControl.Table.TableDirty = True
        dgvCierre.TableControl.Table.EndEdit()

        sumaMN = 0
        sumaME = 0
        'ListaAsientonTransito = New List(Of asiento)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = "99"
            .fechaProceso = txtInicio.Value
            .nroDoc = Nothing
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = StatusTipoOperacion.RETORNO_DE_PRODUCTOS_TERMINADOS
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .tipoOperacion = StatusTipoOperacion.RETORNO_DE_PRODUCTOS_TERMINADOS
            .situacion = "00"
            .idPadre = 0
            .codigoLibro = "13"
            .tipoDoc = "99"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            .fechaDoc = txtInicio.Value ' PERIODO
            .fechaContable = PeriodoGeneral
            .serie = Nothing
            .numeroDoc = Nothing ' txtNumero.Text
            .aprobado = "N"

            'If chProv.Checked = True Then
            '    .idProveedor = CInt(txtProveedor.Tag)

            'ElseIf chCli.Checked = True Then
            '    .idProveedor = CInt(txtProveedor.Tag)
            'ElseIf chTrab.Checked = True Then
            '    .idPersona = CInt(txtProveedor.Tag)
            'End If

            .nombreProveedor = Nothing ' txtProveedor.Text

            '.monedaDoc = IIf(cboMoneda.SelectedValue = "1", "1", "2")
            .monedaDoc = "1"

            .tasaIgv = 0 ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = 0 ' txtTipoCambio.DecimalValue
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = sumaMN
            .importeUS = sumaME

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = "Entrada de productos terminados" 'txtGlosa.Text
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        '  GuiaRemision(ndocumento)


        'ASIENTOS CONTABLES CIERRE ORDEN DE PRODUCCION
        listaAsiento = New List(Of asiento)
        asiento = New asiento
        asiento.idEmpresa = Gempresas.IdEmpresaRuc
        asiento.idCentroCostos = GEstableciento.IdEstablecimiento
        asiento.fechaProceso = txtInicio.Value
        asiento.codigoLibro = "13"
        asiento.tipo = "D"
        asiento.tipoAsiento = "AS.A"
        asiento.importeMN = sumaMN
        asiento.importeME = sumaME
        asiento.glosa = "Envío de Productos terminados a almacenes"
        asiento.usuarioActualizacion = usuario.IDUsuario
        asiento.fechaActualizacion = Date.Now
        listaAsiento.Add(asiento)

        Dim almacenSA As New almacenSA

        If dgvCierre.Table.Records IsNot Nothing AndAlso dgvCierre.Table.Records.Count > 0 Then
            For Each r As Record In dgvCierre.Table.Records
                Dim alm = r.GetValue("almacen")
                If alm.ToString.Trim.Length <= 0 Then
                    MessageBox.Show("Debe indicar el almacén de envío, " & vbCrLf & "de la existencia " & r.GetValue("item"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                    Cursor = Cursors.Default
                End If

                If IsNumeric(r.GetValue("cant")) Then
                    If CDec(r.GetValue("cant")) <= 0 Then
                        MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If


                Select Case r.GetValue("tipoex")
                    Case TipoExistencia.ProductoTerminado
                        '1Asiento
                        mov = New movimiento
                        mov.cuenta = "211"
                        mov.descripcion = r.GetValue("item")
                        mov.tipo = "D"
                        mov.monto = CDec(r.GetValue("costoMN"))
                        mov.montoUSD = 0
                        mov.usuarioActualizacion = usuario.IDUsuario
                        mov.fechaActualizacion = Date.Now
                        asiento.movimiento.Add(mov)

                        '2 asiento
                        mov = New movimiento
                        mov.cuenta = "711"
                        mov.descripcion = r.GetValue("item")
                        mov.tipo = "D"
                        mov.monto = CDec(r.GetValue("costoMN"))
                        mov.montoUSD = 0
                        mov.usuarioActualizacion = usuario.IDUsuario
                        mov.fechaActualizacion = Date.Now
                        asiento.movimiento.Add(mov)
                    Case TipoExistencia.SubProductosDesechos

                        '1Asiento
                        mov = New movimiento
                        mov.cuenta = "221"
                        mov.descripcion = r.GetValue("item")
                        mov.tipo = "D"
                        mov.monto = CDec(r.GetValue("costoMN"))
                        mov.montoUSD = 0
                        mov.usuarioActualizacion = usuario.IDUsuario
                        mov.fechaActualizacion = Date.Now
                        asiento.movimiento.Add(mov)

                        '2 asiento
                        mov = New movimiento
                        mov.cuenta = "711"
                        mov.descripcion = r.GetValue("item")
                        mov.tipo = "D"
                        mov.monto = CDec(r.GetValue("costoMN"))
                        mov.montoUSD = 0
                        mov.usuarioActualizacion = usuario.IDUsuario
                        mov.fechaActualizacion = Date.Now
                        asiento.movimiento.Add(mov)
                End Select



                objDocumentoCompraDet = New documentocompradetalle
                objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                objDocumentoCompraDet.Serie = Nothing ' txtSerie.Text
                objDocumentoCompraDet.NumDoc = Nothing ' txtNumero.Text.Trim
                objDocumentoCompraDet.TipoDoc = "99"
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
                objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
                objDocumentoCompraDet.TipoOperacion = StatusTipoOperacion.RETORNO_DE_PRODUCTOS_TERMINADOS ' cboOperacion.SelectedValue
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.FechaDoc = txtInicio.Value
                objDocumentoCompraDet.CuentaProvedor = "4212"
                objDocumentoCompraDet.NombreProveedor = Nothing ' txtProveedor.Text.Trim
                objDocumentoCompraDet.destino = r.GetValue("gravado")
                objDocumentoCompraDet.idItem = r.GetValue("iditem")
                objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoex") '  r.GetValue("tipoEx")
                objDocumentoCompraDet.descripcionItem = r.GetValue("item")
                objDocumentoCompraDet.unidad1 = r.GetValue("unidad")


                objDocumentoCompraDet.monto1 = CDec(r.GetValue("cant"))
                objDocumentoCompraDet.unidad2 = r.GetValue("idpresen") 'IDPRESENTACION
                objDocumentoCompraDet.monto2 = r.GetValue("presentacion") ' PRESENTACION
                objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pm"))
                objDocumentoCompraDet.precioUnitarioUS = 0
                objDocumentoCompraDet.importe = CType(r.GetValue("costoMN"), Decimal)
                objDocumentoCompraDet.importeUS = CType(r.GetValue("costoME"), Decimal)

                sumaMN += CDec(r.GetValue("costoMN"))
                sumaME += CDec(r.GetValue("costoME"))
                objDocumentoCompraDet.FechaVcto = Nothing
                objDocumentoCompraDet.preEvento = Nothing
                objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(r.GetValue("almacen")).idEstablecimiento
                objDocumentoCompraDet.almacenRef = Val(r.GetValue("almacen")) ' cboAlmacen.SelectedValue
                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoCompraDet.fechaModificacion = DateTime.Now
                objDocumentoCompraDet.Glosa = "Entrada de productos terminados a almmacén"
                objDocumentoCompraDet.idCosto = Val(r.GetValue("idcosto"))
                objDocumentoCompraDet.Status = cboStatus.SelectedValue
                ListaDetalle.Add(objDocumentoCompraDet)
            Next

        End If

        asiento.importeMN = sumaMN
        asiento.importeME = sumaME



        'ASIENTOS CONTABLES
        asiento = New asiento
        asiento.idEmpresa = Gempresas.IdEmpresaRuc
        asiento.idCentroCostos = GEstableciento.IdEstablecimiento
        asiento.fechaProceso = txtInicio.Value
        asiento.codigoLibro = "13"
        asiento.tipo = "D"
        asiento.tipoAsiento = "AS.A"
        asiento.importeMN = sumaMN
        asiento.importeME = sumaME
        asiento.glosa = "Cierre Productos terminados"
        asiento.usuarioActualizacion = usuario.IDUsuario
        asiento.fechaActualizacion = Date.Now
        listaAsiento.Add(asiento)
        '1 asiento
        mov = New movimiento
        mov.cuenta = "713"
        mov.descripcion = "Cierre productos terminados"
        mov.tipo = "D"
        mov.monto = sumaMN
        mov.montoUSD = sumaME
        mov.usuarioActualizacion = usuario.IDUsuario
        mov.fechaActualizacion = Date.Now
        asiento.movimiento.Add(mov)

        mov = New movimiento
        mov.cuenta = "231"
        mov.descripcion = "Cierre productos terminados"
        mov.tipo = "H"
        mov.monto = sumaMN
        mov.montoUSD = sumaME
        mov.usuarioActualizacion = usuario.IDUsuario
        mov.fechaActualizacion = Date.Now
        asiento.movimiento.Add(mov)

        '2 asiento

        mov = New movimiento
        mov.cuenta = "92"
        mov.descripcion = "Cierre productos terminados"
        mov.tipo = "D"
        mov.monto = sumaMN
        mov.montoUSD = sumaME
        mov.usuarioActualizacion = usuario.IDUsuario
        mov.fechaActualizacion = Date.Now
        asiento.movimiento.Add(mov)

        mov = New movimiento
        mov.cuenta = "791"
        mov.descripcion = "Cierre productos terminados"
        mov.tipo = "H"
        mov.monto = sumaMN
        mov.montoUSD = sumaME
        mov.usuarioActualizacion = usuario.IDUsuario
        mov.fechaActualizacion = Date.Now
        asiento.movimiento.Add(mov)

        ndocumento.asiento = listaAsiento
        ndocumento.documentocompra.importeTotal = sumaMN
        ndocumento.documentocompra.importeUS = sumaME
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        CompraSA.GrabarRetornoProductosTerminados(ndocumento)
        MessageBoxAdv.Show("Artículos envíados a almacén correctamente!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub


    Private Sub GetAlmacenes()
        Dim almacenSA As New almacenSA

        Dim ggcStyle As GridTableCellStyleInfo = dgvCierre.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Sub GridCFGDetetail(grid As GridGroupingControl)
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
        'grid.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'grid.TableOptions.SelectionBackColor = Color.Gray
        ''Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
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

    Public Sub GetLoadGrid(grid As GridGroupingControl)
        Dim articulo As New detalleitems
        Dim articulosa As New detalleitemsSA
        Dim conteo = 1
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("idpresen")
        dt.Columns.Add("presentacion")
        dt.Columns.Add("cant")
        dt.Columns.Add("pm")
        dt.Columns.Add("costoMN")
        dt.Columns.Add("costoME")
        dt.Columns.Add("almacen")
        dt.Columns.Add("idcosto")
        dt.Columns.Add("gravado")
        dt.Columns.Add("tipoex")
        For Each r As Record In grid.Table.Records
            articulo = articulosa.InvocarProductoID(Val(r.GetValue("iditem")))


            dt.Rows.Add(conteo,
                        articulo.codigodetalle,
                        articulo.descripcionItem,
                        articulo.unidad1,
                        articulo.presentacion,
                        articulo.presentacion,
                        0,
                        0,
                        r.GetValue("importereal"),
                        0, Nothing, r.GetValue("idcosto"),
                        articulo.origenProducto, articulo.tipoExistencia)

            conteo += 1
        Next
        dgvCierre.DataSource = dt
    End Sub


    Public Sub GetLoadGridByrecord(r As Record)
        Dim articulo As New detalleitems
        Dim articulosa As New detalleitemsSA
        Dim conteo = 1
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("idpresen")
        dt.Columns.Add("presentacion")
        dt.Columns.Add("cant")
        dt.Columns.Add("pm")
        dt.Columns.Add("costoMN")
        dt.Columns.Add("costoME")
        dt.Columns.Add("almacen")
        dt.Columns.Add("idcosto")
        dt.Columns.Add("gravado")
        dt.Columns.Add("tipoex")

        articulo = articulosa.InvocarProductoID(Val(r.GetValue("iditem")))


            dt.Rows.Add(conteo,
                        articulo.codigodetalle,
                        articulo.descripcionItem,
                        articulo.unidad1,
                        articulo.presentacion,
                        articulo.presentacion,
                        0,
                        0,
                        r.GetValue("importereal"),
                        0, Nothing, r.GetValue("idcosto"),
                        articulo.origenProducto, articulo.tipoExistencia)

        dgvCierre.DataSource = dt
    End Sub

#End Region

    Private Sub frmCierreTotalProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvCierre_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCierre.TableControlCellClick

    End Sub

    Private Sub dgvCierre_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCierre.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Cursor = Cursors.WaitCursor
        If dgvCierre.Table.Records.Count > 0 Then
            GrabarDefault()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvCierre_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCierre.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim r As Record = dgvCierre.Table.CurrentRecord
        If Not IsNothing(r) Then
            Select Case ColIndex

                Case 6 ' cantidad
                    Dim colCantidad As Decimal = CDec(r.GetValue("cant"))
                    Dim colCosto As Decimal = CDec(r.GetValue("costoMN"))
                    Dim colPM As Decimal = 0
                    If colCosto > 0 AndAlso colCantidad > 0 Then
                        colPM = colCosto / colCantidad
                    End If

                    r.SetValue("pm", colPM)

                Case 8 ' importe costo
                    Dim colCantidad As Decimal = CDec(r.GetValue("cant"))
                    Dim colCosto As Decimal = CDec(r.GetValue("costoMN"))
                    Dim colPM As Decimal = 0
                    If colCosto > 0 AndAlso colCantidad > 0 Then
                        colPM = colCosto / colCantidad
                    End If

                    r.SetValue("pm", colPM)

            End Select
        End If
    End Sub

    Private Sub cboStatus_Click(sender As Object, e As EventArgs) Handles cboStatus.Click

    End Sub

    Private Sub txtInicio_ValueChanged(sender As Object, e As EventArgs) Handles txtInicio.ValueChanged

    End Sub
End Class
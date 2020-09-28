Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class UC_FormBienesAlquilerPreciosEquivalencia
    Public listaProductos As List(Of detalleitems)

#Region "Attributes"
    Public Property LabelMaximoN As Label
    Public Property LabelMinimoN As Label
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridBlack(GridProductos, False)
        FormatoGridBlack(GridEquivalencia, False)
        FormatoGridBlack(GridPrecios, False)
        FormatoGridBlack(GridPrecioProducto, False)
        FormatoGrid(GridProductos)
        FormatoGrid(GridEquivalencia)
        FormatoGrid(GridPrecios)
        FormatoGrid(GridPrecioProducto)
        'FormatoGridAvanzado(GridConexos, False, False, 9.0F)
        FormatoGridBlack(GridConexos, False)
        GridProductos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GridEquivalencia.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GridPrecios.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GridPrecioProducto.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GroupBar1.BorderStyle = BorderStyle.None
        GetCombos()
        GridEquivalencia.TableDescriptor.Columns("contenidoneto").Appearance.AnyRecordFieldCell.TextColor = Color.Black
        'GridEquivalencia.TableControl.mouse += New MouseEventHandler(TableControl_MouseUp);
        LabelMaximoN = New Label
        LabelMinimoN = New Label
        'Centrar(Me)
    End Sub
#End Region

#Region "Methods"
    Private Sub GetCombos()
        Dim tablaSA As New tablaDetalleSA
        Dim ggcStyle As GridTableCellStyleInfo = GridEquivalencia.TableDescriptor.Columns("detalle").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
        ggcStyle.ValueMember = "codigoDetalle"
        ggcStyle.DisplayMember = "descripcion"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Private Sub PreciosSelCatalogo(idEquivalencia As Integer, idCatalogo As Integer, idProducto As Integer)
        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        Dim equivalencias = Productos.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

        Dim catalogoPrec = equivalencias.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault

        If equivalencias IsNot Nothing Then
            If catalogoPrec IsNot Nothing Then
                Dim precios = catalogoPrec.detalleitemequivalencia_precios.ToList

                Dim dt As New DataTable
                dt.Columns.Add("id")
                dt.Columns.Add("rangoinicio")
                dt.Columns.Add("rangofin")
                dt.Columns.Add("tipoprecio")
                dt.Columns.Add("PrecioContado")
                dt.Columns.Add("PrecioContadoUSD")
                dt.Columns.Add("PrecioCredito")
                dt.Columns.Add("PrecioCreditoUSD")
                dt.Columns.Add("btEliminar")

                For Each i In precios
                    dt.Rows.Add(
                        i.precio_id,
                        i.rango_inicio,
                        i.rango_final,
                        i.precioCode,
                        i.precio.GetValueOrDefault,
                        i.precioUSD.GetValueOrDefault,
                        i.precioCredito.GetValueOrDefault,
                        i.precioCreditoUSD.GetValueOrDefault)
                Next
                GridPrecios.DataSource = dt
            End If
        End If
    End Sub
    'Private Sub PreciosSelEquivalencia(idEquivalencia As Integer, idProducto As Integer)
    '    Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
    '    Dim equivalencias = Productos.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

    '    If equivalencias IsNot Nothing Then
    '        Dim precios = equivalencias.detalleitemequivalencia_precios.ToList

    '        Dim dt As New DataTable
    '        dt.Columns.Add("id")
    '        dt.Columns.Add("rangoinicio")
    '        dt.Columns.Add("rangofin")
    '        dt.Columns.Add("tipoprecio")
    '        dt.Columns.Add("PrecioContado")
    '        dt.Columns.Add("PrecioCredito")
    '        dt.Columns.Add("btEliminar")

    '        For Each i In precios
    '            dt.Rows.Add(i.precio_id, i.rango_inicio, i.rango_final, i.precioCode, i.precio.GetValueOrDefault, i.precioCredito.GetValueOrDefault)
    '        Next
    '        GridPrecios.DataSource = dt
    '    End If


    'End Sub

    Private Sub ItemsConexosSelProducto(idProducto As Integer)

        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        Dim ListaItemsConexos = Productos.detalleitems_conexo.ToList

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("detalle")
        dt.Columns.Add("unidadcomercial")
        dt.Columns.Add("fraccion")
        dt.Columns.Add("cantidad")

        For Each i In ListaItemsConexos
            '   Dim item = prodSA.InvocarProductoID(i.codigodetalle)
            dt.Rows.Add(i.conexo_id, i.detalle, i.unidadComercial, i.fraccion.GetValueOrDefault, i.cantidad.GetValueOrDefault)
        Next
        GridConexos.DataSource = dt
    End Sub

    Private Sub EquivalenciaSelProducto(idProducto As Integer)
        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        Dim equivalencias As List(Of detalleitem_equivalencias) = Nothing

        Select Case CheckInactivos.Checked
            Case True
                equivalencias = Productos.detalleitem_equivalencias.ToList
            Case False
                equivalencias = Productos.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList
        End Select

        Dim dt As New DataTable
        dt.Columns.Add("IDEQ")
        dt.Columns.Add("detalle")
        dt.Columns.Add("unidadcomercial")
        dt.Columns.Add("contenido")
        dt.Columns.Add("fraccion")
        dt.Columns.Add("btNuevoPrecio")
        dt.Columns.Add("estado", GetType(Boolean))
        dt.Columns.Add("contenidoneto")
        For Each i In equivalencias
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.unidadComercial, i.contenido, i.fraccionUnidad, "", i.estado_bool, i.contenido_neto.GetValueOrDefault)
        Next
        GridEquivalencia.DataSource = dt
    End Sub

    Private Sub PreciosSelProducto(idProducto As Integer)
        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        Dim precios = Productos.detalleitem_precios.ToList

        Dim dt As New DataTable

        dt.Columns.Add("id")
        dt.Columns.Add("rangoinicio")
        dt.Columns.Add("rangofin")
        dt.Columns.Add("tipoprecio")
        dt.Columns.Add("contadoPrecioConIgv")
        dt.Columns.Add("contadoPrecioSinIgv")
        dt.Columns.Add("creditoPrecioConIgv")
        dt.Columns.Add("creditoPrecioSinIgv")
        dt.Columns.Add("btEliminar")

        For Each i In precios
            dt.Rows.Add(
                i.precio_id,
                i.rango_inicio,
                i.rango_final,
                i.tipo_precio,
                i.VContadoPrecioConIgv,
                i.VContadoPrecioSinIgv,
                i.VCreditoPrecioConIgv,
                i.VCreditoPrecioSinIgv)
        Next
        GridPrecioProducto.DataSource = dt
    End Sub

    Private Sub GetProductos()
        Dim conteo As Integer = 0
        Dim listaSA As New detalleitemsSA
        Dim tipoex As String

        listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = txtFiltrar.Text
                                                          })

        'listaProductos = listaSA.GetProductosWithEquivalenciasV2(New detalleitems With
        '                                                  {
        '                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                  .descripcionItem = txtFiltrar.Text
        '                                                  })


        Dim dt As New DataTable
        dt.Columns.Add("categoria")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idproducto")
        dt.Columns.Add("codigo")
        dt.Columns.Add("producto")
        dt.Columns.Add("unidad")
        dt.Columns.Add("composicion")
        dt.Columns.Add("tipoexistencia")
        dt.Columns.Add("estado")

        GridEquivalencia.Table.Records.DeleteAll()
        GridPrecios.Table.Records.DeleteAll()
        GridPrecioProducto.Table.Records.DeleteAll()

        For Each i In listaProductos

            Select Case i.tipoExistencia
                Case TipoExistencia.Mercaderia
                    tipoex = "Mercaderia"
                Case TipoExistencia.ProductoTerminado
                    tipoex = "Producto Terminado"
                Case TipoExistencia.MateriaPrima
                    tipoex = "Materia Prima"
                Case TipoExistencia.MaterialAuxiliar_SuministroRepuesto
                    tipoex = "Materiales Auxiliares Suministros y Repuestos"
                Case TipoExistencia.EnvasesEmbalajes
                    tipoex = "Envases y Embalajes"
                Case TipoExistencia.ProductosEnProceso
                    tipoex = "Productos en Proceso"
                Case TipoExistencia.SubProductosDesechos
                    tipoex = "Sub productos desechos y desperdicios"
                Case TipoExistencia.Kit
                    tipoex = "KIT"
            End Select

            If i.detalleitem_equivalencias IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
                dt.Rows.Add(
                    i.idItem,
                    i.origenProducto,
                    i.codigodetalle,
                    i.codigo,
                    i.descripcionItem,
                    i.unidad1,
                    If(i.detalleitem_equivalencias IsNot Nothing, i.detalleitem_equivalencias.FirstOrDefault.detalle, ""),
                    tipoex,
                    i.estado
                    )
            Else
                dt.Rows.Add(
                    i.idItem,
                    i.origenProducto,
                    i.codigodetalle,
                    i.codigo,
                    i.descripcionItem,
                    i.unidad1,
                    "",
                    tipoex,
                    i.estado
                    )
            End If


            conteo = conteo + 1
        Next
        GridProductos.DataSource = dt
    End Sub

    Private Sub FormatoGrid(grid As GridGroupingControl)
        For Each i In grid.TableDescriptor.Columns
            i.AllowSort = False
            i.Appearance.AnyRecordFieldCell.TextColor = Color.White
            i.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.White
        Next
    End Sub

    Private Sub EditarEquivalencia(r As Record)
        Dim equivalenciaSA As New detalleitem_equivalenciasSA
        Dim obj As New detalleitem_equivalencias With
                                                 {
                                                 .Action = BaseBE.EntityAction.UPDATE,
                                                 .equivalencia_id = Integer.Parse(r.GetValue("IDEQ")),
                                                 .detalle = r.GetValue("detalle"),
                                                 .unidadComercial = r.GetValue("unidadcomercial"),
                                                 .contenido = Decimal.Parse(r.GetValue("contenido")),
                                                 .fraccionUnidad = Decimal.Parse(r.GetValue("fraccion")),
                                                 .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")),
                                                 .contenido_neto = Decimal.Parse(r.GetValue("contenidoneto")),
                                                 .estado = "A",
                                                 .usuarioActualizacion = usuario.IDUsuario,
                                                 .fechaActualizacion = Date.Now
                                                 }
        equivalenciaSA.SaveEquivalencia(obj)


        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
        Dim equivalencias = Productos.detalleitem_equivalencias.ToList
        Dim OBJEquivalencia = equivalencias.Where(Function(e) e.equivalencia_id = Integer.Parse(r.GetValue("IDEQ"))).SingleOrDefault
        OBJEquivalencia.detalle = r.GetValue("detalle")
        OBJEquivalencia.unidadComercial = r.GetValue("unidadcomercial")
        OBJEquivalencia.contenido = Decimal.Parse(r.GetValue("contenido"))
        OBJEquivalencia.fraccionUnidad = Decimal.Parse(r.GetValue("fraccion"))
        OBJEquivalencia.contenido_neto = Decimal.Parse(r.GetValue("contenidoneto"))
        ' MessageBox.Show("Equivalencia editada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Close()
    End Sub

    'Private Sub EditarEquivalencia(r As Record, columna As String, valor As Object)
    '    Dim equivalenciaSA As New detalleitem_equivalenciasSA

    '    Select Case columna
    '        Case "unidadcomercial"
    '            Dim obj As New detalleitem_equivalencias With
    '                                             {
    '                                             .Action = BaseBE.EntityAction.UPDATE,
    '                                             .equivalencia_id = Integer.Parse(r.GetValue("IDEQ")),
    '                                             .detalle = r.GetValue("detalle"),
    '                                             .unidadComercial = valor.ToString(),
    '                                             .contenido = Decimal.Parse(r.GetValue("contenido")),
    '                                             .fraccionUnidad = Decimal.Parse(r.GetValue("fraccion")),
    '                                             .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")),
    '                                             .contenido_neto = Decimal.Parse(r.GetValue("contenidoneto")),
    '                                             .estado = "A",
    '                                             .usuarioActualizacion = usuario.IDUsuario,
    '                                             .fechaActualizacion = Date.Now
    '                                             }
    '            equivalenciaSA.SaveEquivalencia(obj)
    '        Case "contenido"

    '            Dim obj As New detalleitem_equivalencias With
    '                                             {
    '                                             .Action = BaseBE.EntityAction.UPDATE,
    '                                             .equivalencia_id = Integer.Parse(r.GetValue("IDEQ")),
    '                                             .detalle = r.GetValue("detalle"),
    '                                             .unidadComercial = r.GetValue("unidadcomercial"),
    '                                             .contenido = Decimal.Parse(r.GetValue("contenido")),
    '                                             .fraccionUnidad = Decimal.Parse(r.GetValue("fraccion")),
    '                                             .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")),
    '                                             .contenido_neto = Decimal.Parse(valor),
    '                                             .estado = "A",
    '                                             .usuarioActualizacion = usuario.IDUsuario,
    '                                             .fechaActualizacion = Date.Now
    '                                             }
    '            equivalenciaSA.SaveEquivalencia(obj)

    '    End Select




    '    Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
    '    Dim equivalencias = Productos.detalleitem_equivalencias.ToList
    '    Dim OBJEquivalencia = equivalencias.Where(Function(e) e.equivalencia_id = Integer.Parse(r.GetValue("IDEQ"))).SingleOrDefault
    '    OBJEquivalencia.detalle = r.GetValue("detalle")
    '    OBJEquivalencia.unidadComercial = r.GetValue("unidadcomercial")
    '    OBJEquivalencia.contenido = Decimal.Parse(r.GetValue("contenido"))
    '    OBJEquivalencia.fraccionUnidad = Decimal.Parse(r.GetValue("fraccion"))
    '    OBJEquivalencia.contenido_neto = Decimal.Parse(r.GetValue("contenidoneto"))
    '    ' MessageBox.Show("Equivalencia editada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    'Close()
    'End Sub

    Private Sub EditarPrecio(r As Record)
        Dim precioSA As New detalleitemequivalencia_preciosSA

        '.rango_final = Decimal.Parse(r.GetValue("rangofin")),
        Dim obj As New detalleitemequivalencia_precios With
                       {
                       .Action = BaseBE.EntityAction.UPDATE,
                       .idCatalogo = ComboCatalogoPrecios.SelectedValue,
                       .precio_id = Integer.Parse(r.GetValue("id")),
                       .rango_inicio = Decimal.Parse(r.GetValue("rangoinicio")),
                       .equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ")),
                       .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")),
                       .precioCode = r.GetValue("tipoprecio"),
                       .precio = Decimal.Parse(r.GetValue("PrecioContado")),
                       .precioUSD = Decimal.Parse(r.GetValue("PrecioContadoUSD")),
                       .precioCredito = Decimal.Parse(r.GetValue("PrecioCredito")),
                       .precioCreditoUSD = Decimal.Parse(r.GetValue("PrecioCreditoUSD")),
                       .usuarioActualizacion = usuario.IDUsuario,
                       .fechaActualizacion = Date.Now
        }
        precioSA.PrecioEquivalenciaSave(obj)

        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
        Dim equivalencias = Productos.detalleitem_equivalencias.ToList
        Dim OBJEquivalencia = equivalencias.Where(Function(e) e.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))).SingleOrDefault

        If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
            Dim ObjCatalogo = OBJEquivalencia.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CInt(ComboCatalogoPrecios.SelectedValue)).SingleOrDefault

            Dim listaPrecios = ObjCatalogo.detalleitemequivalencia_precios.ToList

            Dim objPrecio = listaPrecios.Where(Function(p) p.precio_id = obj.precio_id).SingleOrDefault
            objPrecio.precioCode = obj.precioCode
            objPrecio.precio = obj.precio
            objPrecio.precioUSD = obj.precioUSD
            objPrecio.precioCredito = obj.precioCredito
            objPrecio.precioCreditoUSD = obj.precioCreditoUSD
            objPrecio.rango_inicio = obj.rango_inicio
            'objPrecio.rango_final = obj.rango_final
        End If

        ' MessageBox.Show("Equivalencia editada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Close()
    End Sub

    Private Sub GetChangeStatusAgencia(rowIndex As Integer, tipo As String)
        Dim equivalenciaSA As New detalleitem_equivalenciasSA
        If rowIndex <> -1 Then
            Dim idEquivalencia = Integer.Parse(Me.GridEquivalencia.TableModel(rowIndex, 1).CellValue)
            Dim obj As New detalleitem_equivalencias With
            {
            .equivalencia_id = idEquivalencia,
            .estado = tipo
            }
            equivalenciaSA.ChangeEstatusEquivalencia(obj)
            GridEquivalencia.Refresh()

            'editando objeto
            Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
            Dim equivalencias = Productos.detalleitem_equivalencias.ToList
            Dim OBJEquivalencia = equivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault
            OBJEquivalencia.estado = tipo
        End If
    End Sub
#End Region

#Region "Events"
    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()

    Private Sub GridEquivalencia_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridEquivalencia.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New documentocompra
        Dim RowIndex As Integer = e.Inner.RowIndex

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim valCheck = Me.GridEquivalencia.TableModel(RowIndex, 8).CellValue
            Select Case valCheck
                Case "False" 'TRUE
                    GetChangeStatusAgencia(RowIndex, "I")
                    'MessageBox.Show(True)
                Case Else ' FALSE
                    GetChangeStatusAgencia(RowIndex, "A")
                    'MessageBox.Show(False)
            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub GridProductos_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridProductos.TableControlKeyDown
        Try

            Dim cc As GridCurrentCell = GridProductos.TableControl.CurrentCell
            If cc.RowIndex > -1 Then
                If e.Inner.KeyCode = Keys.Up Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        If cc.RowIndex = 2 Then

                            CleanPrices()

                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                            PreciosSelProducto(idProducto)

                            EquivalenciaSelProducto(idProducto)
                            PreciosSelProducto(idProducto)
                        Else
                            CleanPrices()

                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                            PreciosSelProducto(idProducto)


                            EquivalenciaSelProducto(idProducto)
                            PreciosSelProducto(idProducto)

                        End If

                    End If
                ElseIf e.Inner.KeyCode = Keys.Down Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex + 1, cc.ColIndex), GridTableCellStyleInfo)
                        If style IsNot Nothing Then
                            ' Dim rows = dgvCompra.Table.Records.Count
                            If style.TableCellIdentity IsNot Nothing Then
                                Dim currenrecord = style.TableCellIdentity.DisplayElement.GetRecord()
                                If currenrecord IsNot Nothing Then
                                    CleanPrices()
                                    Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                                    PreciosSelProducto(idProducto)

                                    EquivalenciaSelProducto(idProducto)
                                    PreciosSelProducto(idProducto)
                                End If
                            End If

                        End If

                    End If

                Else
                    cc.ConfirmChanges()
                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                    Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                    PreciosSelProducto(idProducto)

                    EquivalenciaSelProducto(idProducto)
                    PreciosSelProducto(idProducto)
                    CleanPrices()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                GetProductos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Dim frmNuevaExistencia As New frmNuevaExistencia
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If

            If Gempresas.Regimen = "1" Then
                .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            Else
                .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            End If


            'UCNuenExistencia.chClasificacion.Checked = False
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        If frmNuevaExistencia.Tag IsNot Nothing Then
            Dim c = CType(frmNuevaExistencia.Tag, detalleitems)
            txtFiltrar.Text = c.descripcionItem
            GetProductos()
        End If
    End Sub

    Private Sub TableControl_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim tableControl As GridTableControl = TryCast(sender, GridTableControl)
            Dim style As GridTableCellStyleInfo = CType(tableControl.PointToTableCellStyle(New Point(e.X, e.Y)), GridTableCellStyleInfo)
            Dim pt As Point = tableControl.PointToClient(Control.MousePosition)

            If style.TableCellIdentity.DisplayElement.Kind = DisplayElementKind.ColumnHeader Then
                Me.ContextMenuStrip1.Show(tableControl, pt)
            ElseIf style.TableCellIdentity.DisplayElement.Kind = DisplayElementKind.Caption Then
                Me.ContextMenuStrip1.Show(tableControl, pt)
            ElseIf style.TableCellIdentity.ColIndex = 0 Then
                Me.ContextMenuStrip1.Show(tableControl, pt)
            ElseIf style.TableCellIdentity.DisplayElement.Kind = DisplayElementKind.Record Then
                Me.ContextMenuStrip1.Show(tableControl, pt)
            End If
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridEquivalencia.TableControlCellClick
        Dim r As Record = GridEquivalencia.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridEquivalencia.Table.Records.Count > 0 Then
                GridPrecios.Table.Records.DeleteAll()
                Dim idEQ = Integer.Parse(r.GetValue("IDEQ"))
                Dim RecProducto = GridProductos.Table.CurrentRecord

                CatalogoPreciosSelEquivalencia(idEQ, Integer.Parse(RecProducto.GetValue("idproducto")))

                'PreciosSelEquivalencia(idEQ, Integer.Parse(RecProducto.GetValue("idproducto")))
            End If
        End If
    End Sub

    Private Sub CatalogoPreciosSelEquivalencia(idEquivalencia As Integer, idProducto As Integer)
        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        Dim equivalencias = Productos.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

        If equivalencias IsNot Nothing Then
            Dim ListaCatalogoPrecios = equivalencias.detalleitemequivalencia_catalogos.ToList
            ComboCatalogoPrecios.DataSource = ListaCatalogoPrecios
            ComboCatalogoPrecios.DisplayMember = "nombre_corto"
            ComboCatalogoPrecios.ValueMember = "idCatalogo"

            If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
                If GridEquivalencia.Table.Records.Count > 0 Then
                    GridPrecios.Table.Records.DeleteAll()
                    Dim idCatalogo = Integer.Parse(ComboCatalogoPrecios.SelectedValue)
                    Dim RecProducto = GridProductos.Table.CurrentRecord

                    ' CatalogoPreciosSelEquivalencia(idCatalogo, Integer.Parse(RecProducto.GetValue("idproducto")))
                    PreciosSelCatalogo(idEquivalencia, idCatalogo, idProducto)
                End If
            End If

            'Dim dt As New DataTable
            'dt.Columns.Add("id")
            'dt.Columns.Add("rangoinicio")
            'dt.Columns.Add("rangofin")
            'dt.Columns.Add("tipoprecio")
            'dt.Columns.Add("PrecioContado")
            'dt.Columns.Add("PrecioCredito")
            'dt.Columns.Add("btEliminar")

            'For Each i In precios
            '    dt.Rows.Add(i.precio_id, i.rango_inicio, i.rango_final, i.precioCode, i.precio.GetValueOrDefault, i.precioCredito.GetValueOrDefault)
            'Next
            'GridPrecios.DataSource = dt
        End If
    End Sub

    Private Sub GridProductos_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridProductos.TableControlCellClick
        Dim r As Record = GridProductos.Table.CurrentRecord
        If r IsNot Nothing Then
            CleanPrices()

            GridEquivalencia.Table.Records.DeleteAll()
            GridPrecios.Table.Records.DeleteAll()

            TabConceptos.TabPages(1).Enabled = False

            If GridProductos.Table.Records.Count > 0 Then
                Dim idProducto = Integer.Parse(r.GetValue("idproducto"))
                EquivalenciaSelProducto(idProducto)
                PreciosSelProducto(idProducto)
                If r.GetValue("tipoexistencia") = "KIT" Then
                    TabConceptos.TabPages(1).Enabled = True
                    ItemsConexosSelProducto(idProducto)
                End If
            End If
        End If
    End Sub

    Private Sub CleanPrices()
        ListLotes.Items.Clear()
        LabelCostoUnitMin.Text = "0"
        LabelCostoUnitMax.Text = "0"
        LabelMaximoN.Text = "0"
        LabelMaximoN.Tag = 0
        LabelMinimoN.Text = "0"
        LabelMinimoN.Tag = 0
    End Sub

    Private Sub GridEquivalencia_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridEquivalencia.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim cc As GridCurrentCell = GridEquivalencia.TableControl.CurrentCell
        'cc.ConfirmChanges()
        'If cc.Renderer IsNot Nothing Then

        '    If cc.ColIndex > -1 Then
        '        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

        '        If style.TableCellIdentity.Column.Name = "detalle" Or style.TableCellIdentity.Column.Name = "fraccion" _
        '            Or style.TableCellIdentity.Column.Name = "unidadcomercial" Then

        '            If cc.Renderer IsNot Nothing Then

        '                If e.TableControl.Model.Modified = True Then
        '                    Dim text As String = cc.Renderer.ControlText

        '                    If text.Trim.Length > 0 Then
        '                        If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
        '                            EditarEquivalencia(GridEquivalencia.Table.CurrentRecord)
        '                        End If
        '                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
        '                    End If
        '                End If
        '            End If

        '        ElseIf style.TableCellIdentity.Column.Name = "contenidoneto" Then

        '            If cc.Renderer IsNot Nothing Then

        '                If e.TableControl.Model.Modified = True Then
        '                    Dim text As String = cc.Renderer.ControlText
        '                    Dim sty As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex)

        '                    Dim r = sty.TableCellIdentity.DisplayElement.GetRecord() ' style.TableCellIdentity.Table.CurrentRecord ' GridEquivalencia.Table.CurrentRecord
        '                    'calculando representacion
        '                    If GridEquivalencia.Table.Records.Count = 1 Then
        '                        If CDec(cc.Renderer.ControlText) > 0 Then
        '                            r.SetValue("contenido", CDec(cc.Renderer.ControlText) / CDec(cc.Renderer.ControlText))
        '                        Else
        '                            r.SetValue("contenido", 0)
        '                        End If
        '                    Else
        '                            If IsNumeric(cc.Renderer.ControlText) Then
        '                            If CDec(cc.Renderer.ControlText) > 0 Then
        '                                Dim primeraFila = Decimal.Parse(GridEquivalencia.Table.Records(0).GetValue("contenidoneto"))
        '                                r.SetValue("contenido", primeraFila / CDec(cc.Renderer.ControlText))
        '                            Else
        '                                r.SetValue("contenido", 0)
        '                                r.SetValue("fraccion", 0)
        '                                EditarEquivalencia(r)
        '                                Exit Sub
        '                            End If
        '                        End If
        '                    End If
        '                    Dim contenido = Decimal.Parse(r.GetValue("contenido"))
        '                    Dim fraccion As Decimal = 0
        '                    If contenido > 0 Then
        '                        fraccion = 1 / contenido
        '                    End If
        '                    r.SetValue("fraccion", fraccion)


        '                    If text.Trim.Length > 0 Then
        '                        If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
        '                            EditarEquivalencia(GridEquivalencia.Table.CurrentRecord)
        '                        End If
        '                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
        '                    End If
        '                End If
        '            End If

        '        ElseIf style.TableCellIdentity.Column.Name = "contenido" Then

        '            'If cc.Renderer IsNot Nothing Then

        '            '    If e.TableControl.Model.Modified = True Then
        '            '        Dim text As String = cc.Renderer.ControlText

        '            '        If text.Trim.Length > 0 Then
        '            '            If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then

        '            '                Dim contenido = CDec(cc.Renderer.ControlText)
        '            '                Dim result = 1 / contenido
        '            '                GridEquivalencia.Table.CurrentRecord.SetValue("fraccion", result)

        '            '                EditarEquivalencia(GridEquivalencia.Table.CurrentRecord)
        '            '            End If
        '            '            'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
        '            '        End If
        '            '    End If
        '            'End If

        '        ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
        '            'If cc.Renderer IsNot Nothing Then
        '            '    Dim text As String = cc.Renderer.ControlText

        '            '    If text.Trim.Length > 0 Then
        '            '        If GridCompra.Table.CurrentRecord IsNot Nothing Then
        '            '            GetCalculoItem(GridCompra.Table.CurrentRecord)
        '            '            EditarItemVenta(GridCompra.Table.CurrentRecord)
        '            '            '   FormPurchase.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
        '            '        End If
        '            '        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
        '            '    End If
        '            'End If
        '        End If
        '    End If
        'End If
        ''Dim r As Record = GridEquivalencia.Table.CurrentRecord
        ''If r IsNot Nothing Then

        ''End If
    End Sub

    Private Sub GridPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPrecios.TableControlCellClick

    End Sub

    Private Sub GridPrecios_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridPrecios.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim cc As GridCurrentCell = GridPrecios.TableControl.CurrentCell
        'cc.ConfirmChanges()
        'If cc.Renderer IsNot Nothing Then

        '    If cc.ColIndex > -1 Then
        '        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

        '        Select Case style.TableCellIdentity.Column.Name
        '            Case "rangoinicio", "rangofin", "tipoprecio", "PrecioContado", "PrecioCredito", "PrecioContadoUSD", "PrecioCreditoUSD"
        '                If cc.Renderer IsNot Nothing Then

        '                    If e.TableControl.Model.Modified = True Then
        '                        Dim text As String = cc.Renderer.ControlText

        '                        If text.Trim.Length > 0 Then
        '                            If GridPrecios.Table.CurrentRecord IsNot Nothing Then
        '                                EditarPrecio(GridPrecios.Table.CurrentRecord)
        '                            End If
        '                            'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
        '                        End If
        '                    End If
        '                End If
        '        End Select

        '        'If style.TableCellIdentity.Column.Name = "detalle" Or style.TableCellIdentity.Column.Name = "fraccion" Then
        '        '    If cc.Renderer IsNot Nothing Then

        '        '        If e.TableControl.Model.Modified = True Then
        '        '            Dim text As String = cc.Renderer.ControlText

        '        '            If text.Trim.Length > 0 Then
        '        '                If GridPrecios.Table.CurrentRecord IsNot Nothing Then
        '        '                    EditarPrecio(GridPrecios.Table.CurrentRecord)
        '        '                End If
        '        '                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
        '        '            End If
        '        '        End If
        '        '    End If


        '        'ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
        '        '    'If cc.Renderer IsNot Nothing Then
        '        '    '    Dim text As String = cc.Renderer.ControlText

        '        '    '    If text.Trim.Length > 0 Then
        '        '    '        If GridCompra.Table.CurrentRecord IsNot Nothing Then
        '        '    '            GetCalculoItem(GridCompra.Table.CurrentRecord)
        '        '    '            EditarItemVenta(GridCompra.Table.CurrentRecord)
        '        '    '            '   FormPurchase.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
        '        '    '        End If
        '        '    '        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
        '        '    '    End If
        '        '    'End If
        '        'End If
        '    End If
        'End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            If GridProductos.Table.CurrentRecord IsNot Nothing Then
                Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                Dim equivalencias = Productos.detalleitem_equivalencias.ToList

                Dim obj As New detalleitem_equivalencias With
                {
                .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
                }

                Dim f As New FormAddPrecioEquivalencia
                f.objEntiad = obj
                f.Label4.Text = "Agregar equivalencia"
                f.TipoEntidad = "EQUIVALENCIA"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, detalleitem_equivalencias)
                    Productos.detalleitem_equivalencias.Add(New detalleitem_equivalencias With
                                                            {
                                                            .equivalencia_id = c.equivalencia_id,
                                                            .codigodetalle = c.codigodetalle,
                                                            .detalle = c.detalle,
                                                            .fraccionUnidad = c.fraccionUnidad,
                                                            .usuarioActualizacion = c.usuarioActualizacion,
                                                            .fechaActualizacion = c.fechaActualizacion
                                                            })

                    EquivalenciaSelProducto(c.codigodetalle)
                End If
            Else

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If GridProductos.Table.CurrentRecord IsNot Nothing Then
            Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
            Dim equivalencias = Productos.detalleitem_equivalencias.ToList
            If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
                Dim OBJEquivalencia = equivalencias.Where(Function(eq) eq.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))).SingleOrDefault

                If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
                    Dim objCatalogo = OBJEquivalencia.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = ComboCatalogoPrecios.SelectedValue).SingleOrDefault

                    Dim listaPrecios = objCatalogo.detalleitemequivalencia_precios.ToList

                    Dim obj As New detalleitemequivalencia_precios With
                    {
                    .equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ")),
                    .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
                }

                    Dim f As New FormAddPrecioEquivalencia
                    f.objEntiad = obj
                    f.Label4.Text = "Agregar precio"
                    f.TipoEntidad = "PRECIO"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, detalleitemequivalencia_precios)
                        objCatalogo.detalleitemequivalencia_precios.Add(c)
                        PreciosSelCatalogo(c.equivalencia_id, c.idCatalogo, c.codigodetalle)
                    End If
                End If
            End If
        Else

        End If
    End Sub

    Private Sub GridPrecioProducto_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridPrecioProducto.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridEquivalencia.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 6 Then
                e.Inner.Style.Description = "Eliminar"
                'e.Inner.Style.BackColor = Color.Black
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridEquivalencia.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim equivalenciaSA As New detalleitem_equivalenciasSA
        Try
            If e.Inner.ColIndex = 6 Then
                If MessageBox.Show("Desea eliminar el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim idEquivalencia = GridEquivalencia.TableModel(e.Inner.RowIndex, 1).CellValue

                    'Dim EQ = ListaEquivalencia.Where(Function(o) o.IDGUI = idEquivalencia).Single
                    equivalenciaSA.SaveEquivalencia(New detalleitem_equivalencias With
                                                    {
                                                    .Action = BaseBE.EntityAction.DELETE,
                                                    .equivalencia_id = idEquivalencia
                                                    })

                    ' GridEquivalencia.Table.CurrentRecord.Delete()

                    Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault

                    Dim equivalencias = Productos.detalleitem_equivalencias.ToList
                    Dim OBJEquivalencia = equivalencias.Where(Function(eq) eq.equivalencia_id = Integer.Parse(idEquivalencia)).SingleOrDefault

                    Productos.detalleitem_equivalencias.Remove(OBJEquivalencia)
                    EquivalenciaSelProducto(Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridPrecioProducto_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridPrecioProducto.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitem_preciosSA
        Try
            If e.Inner.ColIndex = 9 Then
                If MessageBox.Show("Desea eliminar el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim idPrecio = GridPrecioProducto.TableModel(e.Inner.RowIndex, 1).CellValue

                    'Dim EQ = ListaEquivalencia.Where(Function(o) o.IDGUI = idEquivalencia).Single
                    precioSA.DetalleItemPrecioSave(New detalleitem_precios With
                                                    {
                                                    .Action = BaseBE.EntityAction.DELETE,
                                                    .precio_id = idPrecio
                                                    })

                    ' GridEquivalencia.Table.CurrentRecord.Delete()

                    Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault

                    Dim ListaPrecios = Productos.detalleitem_precios.ToList
                    Dim OBJEquivalencia = ListaPrecios.Where(Function(eq) eq.precio_id = Integer.Parse(idPrecio)).SingleOrDefault

                    Productos.detalleitem_precios.Remove(OBJEquivalencia)
                    PreciosSelProducto(Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridPrecios_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridPrecios.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridPrecios_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridPrecios.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Try
            If e.Inner.ColIndex = 9 Then
                If GridProductos.Table.CurrentRecord IsNot Nothing Then
                    If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
                        If MessageBox.Show("Desea eliminar el precio seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim idPrecio = GridPrecios.TableModel(e.Inner.RowIndex, 1).CellValue

                            'Dim EQ = ListaEquivalencia.Where(Function(o) o.IDGUI = idEquivalencia).Single
                            precioSA.PrecioEquivalenciaSave(New detalleitemequivalencia_precios With
                                                            {
                                                            .Action = BaseBE.EntityAction.DELETE,
                                                            .precio_id = idPrecio
                                                            })


                            Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                            Dim equivalencias = Productos.detalleitem_equivalencias.ToList
                            Dim OBJEquivalencia = equivalencias.Where(Function(eq) eq.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))).SingleOrDefault

                            If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
                                Dim ObjCatalogo = OBJEquivalencia.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = ComboCatalogoPrecios.SelectedValue).SingleOrDefault

                                Dim listaPrecios = ObjCatalogo.detalleitemequivalencia_precios.ToList

                                Dim objPrecio = ObjCatalogo.detalleitemequivalencia_precios.Where(Function(p) p.precio_id = idPrecio).SingleOrDefault

                                ObjCatalogo.detalleitemequivalencia_precios.Remove(objPrecio)

                                PreciosSelCatalogo(Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ")), CInt(ComboCatalogoPrecios.SelectedValue), Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")))
                            End If
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AddPrecio(be As detalleitemequivalencia_precios) As detalleitemequivalencia_precios
        '.rango_final = TextRangoFin.DecimalValue,
        Dim precioSA As New detalleitemequivalencia_preciosSA

        Dim obj As New detalleitemequivalencia_precios With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .idCatalogo = be.idCatalogo,
        .equivalencia_id = be.equivalencia_id,
        .codigodetalle = be.codigodetalle,
        .rango_inicio = be.rango_inicio,
        .precioCode = be.precioCode,
        .precio = be.precio,
        .precioCredito = be.precioCredito,
        .estado = 1,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        Dim prec = precioSA.PrecioEquivalenciaSave(obj)
        Return prec
    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Try
        '    If GridProductos.Table.CurrentRecord IsNot Nothing Then
        '        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
        '        Dim equivalencias = Productos.detalleitem_equivalencias.ToList

        '        Dim obj As New detalleitems With
        '        {
        '        .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
        '        }

        '        Dim f As New FormAddPrecioProducto
        '        f.objEntiad = obj
        '        f.StartPosition = FormStartPosition.CenterParent
        '        f.ShowDialog(Me)
        '        If f.Tag IsNot Nothing Then

        '            Dim c = CType(f.Tag, detalleitem_precios)
        '            Productos.detalleitem_precios.Add(c)


        '            Productos.detalleitem_equivalencias.Add(New detalleitem_equivalencias With
        '                                                    {
        '                                                    .equivalencia_id = c.equivalencia_id,
        '                                                    .codigodetalle = c.codigodetalle,
        '                                                    .detalle = c.detalle,
        '                                                    .fraccionUnidad = c.fraccionUnidad,
        '                                                    .usuarioActualizacion = c.usuarioActualizacion,
        '                                                    .fechaActualizacion = c.fechaActualizacion
        '                                                    })

        '            EquivalenciaSelProducto(c.codigodetalle)
        '            PreciosSelProducto(c.codigodetalle)
        '        End If
        '    Else

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        If GridProductos.Table.CurrentRecord IsNot Nothing Then
            Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
            Dim equivalencias = Productos.detalleitem_equivalencias.ToList
            If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
                Dim OBJEquivalencia = equivalencias.Where(Function(eq) eq.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))).SingleOrDefault

                If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
                    Dim objCatalogo = OBJEquivalencia.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = ComboCatalogoPrecios.SelectedValue).SingleOrDefault

                    Dim listaPrecios = objCatalogo.detalleitemequivalencia_precios.ToList

                    Dim obj As New detalleitemequivalencia_precios With
                        {
                        .idCatalogo = objCatalogo.idCatalogo,
                        .equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ")),
                        .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
                    }

                    Dim precioName = $"{"Precio"}-{listaPrecios.Count + 1}"
                    Dim maxCantidadDiponible As Decimal = listaPrecios.Max(Function(d) d.rango_inicio).GetValueOrDefault
                    maxCantidadDiponible = maxCantidadDiponible + 1

                    Dim nuevoPrice = AddPrecio(New detalleitemequivalencia_precios With
                              {
                              .idCatalogo = obj.idCatalogo,
                              .equivalencia_id = obj.equivalencia_id,
                              .codigodetalle = obj.codigodetalle,
                              .rango_inicio = maxCantidadDiponible,
                              .precioCode = precioName,
                              .precio = 0,
                              .precioCredito = 0
                              })

                    objCatalogo.detalleitemequivalencia_precios.Add(nuevoPrice)
                    PreciosSelCatalogo(obj.equivalencia_id, obj.idCatalogo, obj.codigodetalle)

                    'Dim f As New FormAddPrecioEquivalencia
                    'f.ComboPrecio.Visible = True
                    'f.PanelPrecio.Visible = True
                    'f.PanelRango.Visible = True
                    'f.objEntiad = obj
                    'f.Label4.Text = "Agregar precio"
                    'f.TipoEntidad = "PRECIO"
                    'f.StartPosition = FormStartPosition.CenterParent
                    'f.ShowDialog(Me)
                    'If f.Tag IsNot Nothing Then
                    '    Dim c = CType(f.Tag, detalleitemequivalencia_precios)
                    '    objCatalogo.detalleitemequivalencia_precios.Add(c)
                    '    PreciosSelCatalogo(c.equivalencia_id, c.idCatalogo, c.codigodetalle)
                    'End If
                Else
                    MessageBox.Show("Indicar el catalogo de precios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Indicar la unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar producto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub FormExistenciaPreciosEquivalencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBar1_GroupBarItemSelected(sender As Object, e As EventArgs) Handles GroupBar1.GroupBarItemSelected

    End Sub

    Private Sub GridPrecioProducto_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPrecioProducto.TableControlCellClick

    End Sub

    Private Sub GridPrecioProducto_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridPrecioProducto.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridPrecioProducto.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                Select Case style.TableCellIdentity.Column.Name
                    Case "tipoprecio", "contadoPrecioConIgv", "contadoPrecioSinIgv", "creditoPrecioConIgv", "creditoPrecioSinIgv"

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            If text.Trim.Length > 0 Then
                                If GridPrecioProducto.Table.CurrentRecord IsNot Nothing Then
                                    EditarPrecioProducto(GridPrecioProducto.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If

                    Case "rangoinicio", "rangofin"
                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            If text.Trim.Length > 0 Then
                                If IsNumeric(text) Then
                                    If GridPrecioProducto.Table.CurrentRecord IsNot Nothing Then
                                        EditarPrecioProducto(GridPrecioProducto.Table.CurrentRecord)
                                    End If
                                Else
                                    MessageBox.Show("Debe ingresar un formato correcto de número", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                End Select

            End If
        End If
    End Sub

    Private Sub EditarPrecioProducto(r As Record)
        Dim precioSA As New detalleitem_preciosSA
        Dim obj As New detalleitem_precios With {
                                                 .Action = BaseBE.EntityAction.UPDATE,
                                                 .ultimoCosto = 0,
                                                 .tipo_rango = "M",
                                                 .precio_id = Integer.Parse(r.GetValue("id")),
                                                 .rango_inicio = Decimal.Parse(r.GetValue("rangoinicio")),
                                                 .rango_final = Decimal.Parse(r.GetValue("rangofin")),
                                                 .tipo_precio = r.GetValue("tipoprecio"),
                                                 .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")),
                                                 .VContadoPrecioConIgv = Decimal.Parse(r.GetValue("contadoPrecioConIgv")),
                                                 .VContadoPrecioSinIgv = Decimal.Parse(r.GetValue("contadoPrecioSinIgv")),
                                                 .VCreditoPrecioConIgv = Decimal.Parse(r.GetValue("creditoPrecioConIgv")),
                                                 .VCreditoPrecioSinIgv = Decimal.Parse(r.GetValue("creditoPrecioSinIgv")),
                                                 .usuarioActualizacion = usuario.IDUsuario,
                                                 .fechaActualizacion = Date.Now
                                                 }
        precioSA.DetalleItemPrecioSave(obj)


        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
        Dim ListPrecios = Productos.detalleitem_precios.ToList
        Dim objPrecio = ListPrecios.Where(Function(e) e.precio_id = Integer.Parse(GridPrecioProducto.Table.CurrentRecord.GetValue("id"))).SingleOrDefault

        If objPrecio IsNot Nothing Then
            With objPrecio
                .rango_inicio = obj.rango_inicio
                .rango_final = obj.rango_final
                .tipo_precio = obj.tipo_precio
                .ultimoCosto = obj.ultimoCosto
                .VContadoPrecioConIgv = obj.VContadoPrecioConIgv
                .VContadoPrecioSinIgv = obj.VContadoPrecioSinIgv
                .VCreditoPrecioConIgv = obj.VCreditoPrecioConIgv
                .VCreditoPrecioSinIgv = obj.VCreditoPrecioSinIgv
            End With
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            If GridProductos.Table.CurrentRecord IsNot Nothing Then
                Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                Dim equivalencias = Productos.detalleitem_equivalencias.ToList

                Dim obj As New detalleitem_equivalencias With
                {
                .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
                }

                Dim f As New FormAddPrecioEquivalencia
                f.objEntiad = obj
                f.Label4.Text = "Agregar equivalencia"
                f.TipoEntidad = "EQUIVALENCIA"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, detalleitem_equivalencias)
                    Productos.detalleitem_equivalencias.Add(New detalleitem_equivalencias With
                                                            {
                                                            .equivalencia_id = c.equivalencia_id,
                                                            .codigodetalle = c.codigodetalle,
                                                            .detalle = c.detalle,
                                                            .fraccionUnidad = c.fraccionUnidad,
                                                            .estado = "A",
                                                            .usuarioActualizacion = c.usuarioActualizacion,
                                                            .fechaActualizacion = c.fechaActualizacion
                                                            })

                    EquivalenciaSelProducto(c.codigodetalle)
                End If
            Else

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboCatalogoPrecios_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GradientPanel5_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel5.Paint

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim r As Record = GridEquivalencia.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim RecProducto = GridProductos.Table.CurrentRecord
            If RecProducto IsNot Nothing Then
                Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = RecProducto.GetValue("idproducto")).SingleOrDefault
                Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(d) d.equivalencia_id = r.GetValue("IDEQ")).SingleOrDefault

                Dim f As New FormNuevoCatalogoPrecios
                If equivalenciaOBJ.detalleitemequivalencia_catalogos IsNot Nothing Then
                    f.TextNombreCatalogo.Text = $"Lista - {equivalenciaOBJ.detalleitemequivalencia_catalogos.Count}"
                Else
                    f.TextNombreCatalogo.Text = $"Lista - 1"
                End If
                f.CodigoEquivalencia = CInt(r.GetValue("IDEQ"))
                f.CodigoProducto = Integer.Parse(RecProducto.GetValue("idproducto"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, detalleitemequivalencia_catalogos)
                    ADDCatalogoItem(c)
                End If
            Else
                MessageBox.Show("Indicar un producto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Indicar una unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ADDCatalogoItem(c As detalleitemequivalencia_catalogos)
        Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = c.codigodetalle).SingleOrDefault
        Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = c.equivalencia_id).SingleOrDefault

        equivalenciaOBJ.detalleitemequivalencia_catalogos.Add(c)
        CatalogoPreciosSelEquivalencia(equivalenciaOBJ.equivalencia_id, productoOBJ.codigodetalle)
    End Sub

    Private Sub EDITCatalogoItem(c As detalleitemequivalencia_catalogos)
        Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = c.codigodetalle).SingleOrDefault
        Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = c.equivalencia_id).SingleOrDefault

        Dim objSelCatalogo = equivalenciaOBJ.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = c.idCatalogo).SingleOrDefault

        objSelCatalogo.nombre_corto = c.nombre_corto
        objSelCatalogo.nombre_largo = c.nombre_largo

        CatalogoPreciosSelEquivalencia(equivalenciaOBJ.equivalencia_id, productoOBJ.codigodetalle)
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If ComboCatalogoPrecios.Items.Count > 0 Then
            Dim r As Record = GridEquivalencia.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim RecProducto = GridProductos.Table.CurrentRecord
                If RecProducto IsNot Nothing Then
                    Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = RecProducto.GetValue("idproducto")).SingleOrDefault
                    Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(eq) eq.equivalencia_id = r.GetValue("IDEQ")).SingleOrDefault

                    Dim codCatalogo = Integer.Parse(ComboCatalogoPrecios.SelectedValue)

                    Dim objSelCatalogo = equivalenciaOBJ.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = codCatalogo).SingleOrDefault


                    Dim f As New FormNuevoCatalogoPrecios(Integer.Parse(ComboCatalogoPrecios.SelectedValue), ComboCatalogoPrecios.Text, objSelCatalogo.predeterminado)
                    f.CodigoEquivalencia = CInt(r.GetValue("IDEQ"))
                    f.CodigoProducto = Integer.Parse(RecProducto.GetValue("idproducto"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, detalleitemequivalencia_catalogos)
                        EDITCatalogoItem(c)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ComboCatalogoPrecios_Click_1(sender As Object, e As EventArgs) Handles ComboCatalogoPrecios.Click

    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Try
            If GridProductos.Table.CurrentRecord IsNot Nothing Then
                Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                Dim equivalencias = Productos.detalleitem_equivalencias.ToList

                Dim obj As New detalleitem_equivalencias With
                {
                .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
                }

                Dim f As New FormAddUnidadComercial(equivalencias) ' FormAddPrecioEquivalencia
                f.objEntiad = obj
                f.TextUnidadPrincipal.Text = Productos.unidad1
                f.TextUnidadPrincipal.Tag = Productos.unidad1
                'f.Label4.Text = "Agregar equivalencia"
                'f.TipoEntidad = "EQUIVALENCIA"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, detalleitem_equivalencias)
                    Productos.detalleitem_equivalencias.Add(New detalleitem_equivalencias With
                                                            {
                                                            .equivalencia_id = c.equivalencia_id,
                                                            .codigodetalle = c.codigodetalle,
                                                            .detalle = c.detalle,
                                                            .unidadComercial = c.unidadComercial,
                                                            .contenido = c.contenido,
                                                            .contenido_neto = c.contenido_neto,
                                                            .fraccionUnidad = c.fraccionUnidad,
                                                            .estado = "A",
                                                            .usuarioActualizacion = c.usuarioActualizacion,
                                                            .fechaActualizacion = c.fechaActualizacion
                                                            })

                    EquivalenciaSelProducto(c.codigodetalle)

                    'agregando catalogo

                    Dim equivalenciaOBJ = Productos.detalleitem_equivalencias.Where(Function(d) d.equivalencia_id = c.equivalencia_id).SingleOrDefault

                    Dim form As New FormNuevoCatalogoPrecios
                    If equivalenciaOBJ.detalleitemequivalencia_catalogos IsNot Nothing Then
                        form.TextNombreCatalogo.Text = $"Lista - {equivalenciaOBJ.detalleitemequivalencia_catalogos.Count}"
                    Else
                        form.TextNombreCatalogo.Text = $"Lista - 1"
                    End If
                    form.CodigoEquivalencia = c.equivalencia_id
                    form.CodigoProducto = c.codigodetalle
                    form.StartPosition = FormStartPosition.CenterParent
                    form.ShowDialog(Me)
                    If form.Tag IsNot Nothing Then
                        Dim cat = CType(form.Tag, detalleitemequivalencia_catalogos)
                        ADDCatalogoItem(cat)
                    End If

                End If
            Else
                MessageBox.Show("Indicar un producto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim catalogoSA As New detalleitemequivalencia_catalogosSA
        If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
            Dim obj As New detalleitemequivalencia_catalogos

            obj.idCatalogo = ComboCatalogoPrecios.SelectedValue
            obj.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))
            obj.predeterminado = True

            catalogoSA.CatalogoPredeterminado(obj)
            MessageBox.Show("Catalogo predeterminado con éxito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Seleccionar una equivalencia!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        'Try
        '    Dim r As Record = GridProductos.Table.CurrentRecord
        '    If r Is Nothing Then Exit Sub

        '    Dim uc As Record = GridEquivalencia.Table.CurrentRecord
        '    If uc Is Nothing Then Exit Sub

        '    Dim f As New FormCatalogoUnidadComercial(Me)
        '    f.TextProducto.Tag = r.GetValue("idproducto")
        '    f.TextProducto.Text = r.GetValue("producto")
        '    f.TextUnidadComercial.Text = uc.GetValue("unidadcomercial")
        '    f.TextUnidadComercial.Tag = Integer.Parse(uc.GetValue("IDEQ"))
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog(Me)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub ComboMoneda_Click(sender As Object, e As EventArgs) Handles ComboMoneda.Click

    End Sub

    Private Sub ComboCatalogoPrecios_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboCatalogoPrecios.SelectedValueChanged
        If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
            Dim r As Record = GridEquivalencia.Table.CurrentRecord
            If r IsNot Nothing Then
                If GridEquivalencia.Table.Records.Count > 0 Then
                    GridPrecios.Table.Records.DeleteAll()
                    Dim idCatalogo = Integer.Parse(ComboCatalogoPrecios.SelectedValue)
                    Dim RecProducto = GridProductos.Table.CurrentRecord

                    ' CatalogoPreciosSelEquivalencia(idCatalogo, Integer.Parse(RecProducto.GetValue("idproducto")))
                    PreciosSelCatalogo(CInt(r.GetValue("IDEQ")), idCatalogo, Integer.Parse(RecProducto.GetValue("idproducto")))
                End If
            End If

        End If
    End Sub

    Private Sub ComboMoneda_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboMoneda.SelectedValueChanged
        If ComboMoneda.Text = "NUEVO SOL" Then
            GridPrecios.TableDescriptor.Columns("PrecioContado").Width = 75
            GridPrecios.TableDescriptor.Columns("PrecioCredito").Width = 75

            GridPrecios.TableDescriptor.Columns("PrecioContadoUSD").Width = 0
            GridPrecios.TableDescriptor.Columns("PrecioCreditoUSD").Width = 0
        ElseIf ComboMoneda.Text = "DOLARES AMERICANOS" Then
            GridPrecios.TableDescriptor.Columns("PrecioContado").Width = 0
            GridPrecios.TableDescriptor.Columns("PrecioCredito").Width = 0

            GridPrecios.TableDescriptor.Columns("PrecioContadoUSD").Width = 75
            GridPrecios.TableDescriptor.Columns("PrecioCreditoUSD").Width = 75
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlCurrentCellAcceptedChanges(sender As Object, e As GridTableControlCancelEventArgs) Handles GridEquivalencia.TableControlCurrentCellAcceptedChanges

        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim cc As GridCurrentCell = GridEquivalencia.TableControl.CurrentCell
        'cc.ConfirmChanges()
        'If cc.Renderer IsNot Nothing Then

        '    If cc.ColIndex > -1 Then
        '        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

        '        If style.TableCellIdentity.Column.Name = "detalle" Or style.TableCellIdentity.Column.Name = "fraccion" _
        '            Or style.TableCellIdentity.Column.Name = "unidadcomercial" Then

        '            If cc.Renderer IsNot Nothing Then

        '                If e.TableControl.Model.Modified = True Then
        '                    Dim text As String = cc.Renderer.ControlText

        '                    If text.Trim.Length > 0 Then
        '                        If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
        '                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
        '                            EditarEquivalencia(r)
        '                        End If
        '                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
        '                    End If
        '                End If
        '            End If

        '        ElseIf style.TableCellIdentity.Column.Name = "contenidoneto" Then

        '            If cc.Renderer IsNot Nothing Then

        '                If e.TableControl.Model.Modified = True Then

        '                    Dim sty As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex)

        '                    Dim text As String = cc.Renderer.ControlText
        '                    Dim r = sty.TableCellIdentity.DisplayElement.GetRecord() 'GridEquivalencia.Table.CurrentRecord
        '                    'calculando representacion
        '                    If GridEquivalencia.Table.Records.Count = 1 Then
        '                        If CDec(cc.Renderer.ControlText) > 0 Then
        '                            r.SetValue("contenido", CDec(cc.Renderer.ControlText) / CDec(cc.Renderer.ControlText))
        '                        Else
        '                            r.SetValue("contenido", 0)
        '                        End If
        '                    Else
        '                        If IsNumeric(cc.Renderer.ControlText) Then
        '                            If CDec(cc.Renderer.ControlText) > 0 Then
        '                                Dim primeraFila = Decimal.Parse(GridEquivalencia.Table.Records(0).GetValue("contenidoneto"))
        '                                r.SetValue("contenido", primeraFila / CDec(cc.Renderer.ControlText))
        '                            Else
        '                                r.SetValue("contenido", 0)
        '                                r.SetValue("fraccion", 0)
        '                                EditarEquivalencia(r)
        '                                Exit Sub
        '                            End If
        '                        End If
        '                    End If
        '                    Dim contenido = Decimal.Parse(r.GetValue("contenido"))
        '                    Dim fraccion As Decimal = 0
        '                    If contenido > 0 Then
        '                        fraccion = 1 / contenido
        '                    End If
        '                    r.SetValue("fraccion", fraccion)


        '                    If text.Trim.Length > 0 Then
        '                        If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
        '                            EditarEquivalencia(r)
        '                        End If
        '                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
        '                    End If
        '                End If
        '            End If

        '        ElseIf style.TableCellIdentity.Column.Name = "contenido" Then

        '            'If cc.Renderer IsNot Nothing Then

        '            '    If e.TableControl.Model.Modified = True Then
        '            '        Dim text As String = cc.Renderer.ControlText

        '            '        If text.Trim.Length > 0 Then
        '            '            If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then

        '            '                Dim contenido = CDec(cc.Renderer.ControlText)
        '            '                Dim result = 1 / contenido
        '            '                GridEquivalencia.Table.CurrentRecord.SetValue("fraccion", result)

        '            '                EditarEquivalencia(GridEquivalencia.Table.CurrentRecord)
        '            '            End If
        '            '            'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
        '            '        End If
        '            '    End If
        '            'End If

        '        ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
        '            'If cc.Renderer IsNot Nothing Then
        '            '    Dim text As String = cc.Renderer.ControlText

        '            '    If text.Trim.Length > 0 Then
        '            '        If GridCompra.Table.CurrentRecord IsNot Nothing Then
        '            '            GetCalculoItem(GridCompra.Table.CurrentRecord)
        '            '            EditarItemVenta(GridCompra.Table.CurrentRecord)
        '            '            '   FormPurchase.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
        '            '        End If
        '            '        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
        '            '    End If
        '            'End If
        '        End If
        '    End If
        'End If

    End Sub

    Public Function IsInRange(ByVal valorMin As Decimal, ByVal ValorMax As Decimal, ByVal Valor As Decimal) As Boolean
        If Valor >= valorMin AndAlso Valor <= ValorMax Then Return True
        Return False
    End Function

    Private Sub GridEquivalencia_TableControlCurrentCellValidated(sender As Object, e As GridTableControlEventArgs) Handles GridEquivalencia.TableControlCurrentCellValidated
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridEquivalencia.TableControl.CurrentCell
        'cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

            If style.TableCellIdentity.Column.Name = "contenidoneto" Then
                Dim oldValue = CDec(Me.GridEquivalencia.TableModel(cc.RowIndex, 4).CellValue)
                Dim newValue = CDec(cc.Renderer.ControlText)

                Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                Dim equivalencias = Productos.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList
                ' Dim OBJEquivalencia = equivalencias.Where(Function(eq) eq.equivalencia_id = Integer.Parse(r.GetValue("IDEQ"))).SingleOrDefault





                If oldValue <> newValue Then
                    Dim mensaje = $"Valor nuevo: {newValue.ToString("N2")}, valor anterior: {oldValue.ToString("N2")} Desea guardar cambios ?"
                    If MessageBox.Show(mensaje, "Validando celdas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Me.GridEquivalencia.EndUpdate(True)

                        Dim sty As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex)

                        Dim text As String = cc.Renderer.ControlText
                        Dim r = sty.TableCellIdentity.DisplayElement.GetRecord() 'GridEquivalencia.Table.CurrentRecord
                        r.SetValue("contenidoneto", newValue)
                        'calculando representacion
                        If GridEquivalencia.Table.Records.Count = 1 Then
                            If CDec(cc.Renderer.ControlText) > 0 Then
                                r.SetValue("contenido", CDec(cc.Renderer.ControlText) / CDec(cc.Renderer.ControlText))
                            Else
                                r.SetValue("contenido", 0)
                            End If
                        Else
                            If IsNumeric(cc.Renderer.ControlText) Then
                                If CDec(cc.Renderer.ControlText) > 0 Then
                                    Dim primeraFila = Decimal.Parse(GridEquivalencia.Table.Records(0).GetValue("contenidoneto"))
                                    r.SetValue("contenido", primeraFila / CDec(cc.Renderer.ControlText))
                                Else
                                    r.SetValue("contenido", 0)
                                    r.SetValue("fraccion", 0)

                                    Dim max = equivalencias.Where(Function(o) o.estado = "A" And o.flag = "MAX").Max(Function(o) o.contenido_neto).GetValueOrDefault
                                    Dim mIN = equivalencias.Where(Function(o) o.estado = "A" And o.flag = "MIN").Min(Function(o) o.contenido_neto).GetValueOrDefault

                                    Dim dentroDeRango = IsInRange(mIN, max, newValue)

                                    If dentroDeRango Then
                                        Dim existe = equivalencias.Any(Function(o) o.contenido_neto = newValue)

                                        If existe Then
                                            MessageBox.Show("Contenido ingresado ya existe, ingrese otro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            cc.RejectChanges()
                                            Me.GridEquivalencia.TableModel(cc.RowIndex, 4).CellValue = oldValue
                                            Me.GridEquivalencia.EndUpdate(True)
                                            EquivalenciaSelProducto(Productos.codigodetalle)
                                            Exit Sub
                                        End If

                                        EditarEquivalencia(r)
                                        Exit Sub
                                    Else
                                        MessageBox.Show("El valor esta fuera del rango permitido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        cc.RejectChanges()
                                        Me.GridEquivalencia.TableModel(cc.RowIndex, 4).CellValue = oldValue
                                        Me.GridEquivalencia.EndUpdate(True)
                                        EquivalenciaSelProducto(Productos.codigodetalle)
                                        Exit Sub
                                    End If

                                End If
                            End If
                        End If
                        Dim contenido = Decimal.Parse(r.GetValue("contenido"))
                        Dim fraccion As Decimal = 0
                        If contenido > 0 Then
                            fraccion = 1 / contenido
                        End If
                        r.SetValue("fraccion", fraccion)


                        If text.Trim.Length > 0 Then
                            If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then

                                Dim max = equivalencias.Where(Function(o) o.estado = "A" And o.flag = "MAX").Max(Function(o) o.contenido_neto).GetValueOrDefault
                                Dim mIN = equivalencias.Where(Function(o) o.estado = "A" And o.flag = "MIN").Min(Function(o) o.contenido_neto).GetValueOrDefault

                                Dim dentroDeRango = IsInRange(mIN, max, newValue)

                                If dentroDeRango Then
                                    Dim existe = equivalencias.Any(Function(o) o.contenido_neto = newValue)

                                    If existe Then
                                        MessageBox.Show("Contenido ingresado ya existe, ingrese otro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        cc.RejectChanges()
                                        Me.GridEquivalencia.TableModel(cc.RowIndex, 4).CellValue = oldValue
                                        Me.GridEquivalencia.EndUpdate(True)
                                        EquivalenciaSelProducto(Productos.codigodetalle)
                                        Exit Sub
                                    End If

                                    EditarEquivalencia(r)
                                Else
                                    MessageBox.Show("El valor esta fuera del rango permitido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    cc.RejectChanges()
                                    Me.GridEquivalencia.TableModel(cc.RowIndex, 4).CellValue = oldValue
                                    Me.GridEquivalencia.EndUpdate(True)
                                    EquivalenciaSelProducto(Productos.codigodetalle)
                                    Exit Sub
                                End If
                            End If
                            'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                        End If

                    Else
                        cc.RejectChanges()
                        Me.GridEquivalencia.TableModel(cc.RowIndex, 4).CellValue = oldValue
                        Me.GridEquivalencia.EndUpdate(True)
                    End If
                End If

            ElseIf style.TableCellIdentity.Column.Name = "unidadcomercial" Then

                If cc.Renderer IsNot Nothing Then
                    Dim text As String = cc.Renderer.ControlText
                    Dim oldValue = Me.GridEquivalencia.TableModel(cc.RowIndex, 3).CellValue
                    Dim newValue = text
                    Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                    If oldValue <> newValue Then
                        Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} Desea guardar cambios ?"
                        If MessageBox.Show(mensaje, "Unidad comercial", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Me.GridEquivalencia.EndUpdate(True)
                            r.SetValue("unidadcomercial", newValue)
                            If text.Trim.Length > 0 Then
                                If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then

                                    EditarEquivalencia(r)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        Else
                            cc.RejectChanges()
                            Me.GridEquivalencia.TableModel(cc.RowIndex, 3).CellValue = oldValue
                            Me.GridEquivalencia.EndUpdate(True)
                        End If
                    End If
                End If
            End If


        End If


    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        If GridProductos.Table.CurrentRecord IsNot Nothing Then
            Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
            Dim equivalencias = Productos.detalleitem_equivalencias.ToList
            If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
                Dim OBJEquivalencia = equivalencias.Where(Function(eq) eq.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))).SingleOrDefault

                If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
                    Dim objCatalogo = OBJEquivalencia.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = ComboCatalogoPrecios.SelectedValue).SingleOrDefault

                    Dim listaPrecios = objCatalogo.detalleitemequivalencia_precios.ToList

                    Dim obj As New detalleitemequivalencia_precios With
                        {
                        .idCatalogo = objCatalogo.idCatalogo,
                        .equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ")),
                        .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
                    }

                    Dim precioName = $"{"Precio"}-{listaPrecios.Count + 1}"
                    Dim maxCantidadDiponible As Decimal = listaPrecios.Max(Function(d) d.rango_inicio).GetValueOrDefault
                    maxCantidadDiponible = maxCantidadDiponible + 1

                    Dim nuevoPrice = AddPrecio(New detalleitemequivalencia_precios With
                              {
                              .idCatalogo = obj.idCatalogo,
                              .equivalencia_id = obj.equivalencia_id,
                              .codigodetalle = obj.codigodetalle,
                              .rango_inicio = maxCantidadDiponible,
                              .precioCode = precioName,
                              .precio = 0,
                              .precioCredito = 0
                              })

                    objCatalogo.detalleitemequivalencia_precios.Add(nuevoPrice)
                    PreciosSelCatalogo(obj.equivalencia_id, obj.idCatalogo, obj.codigodetalle)

                    'Dim f As New FormAddPrecioEquivalencia
                    'f.ComboPrecio.Visible = True
                    'f.PanelPrecio.Visible = True
                    'f.PanelRango.Visible = True
                    'f.objEntiad = obj
                    'f.Label4.Text = "Agregar precio"
                    'f.TipoEntidad = "PRECIO"
                    'f.StartPosition = FormStartPosition.CenterParent
                    'f.ShowDialog(Me)
                    'If f.Tag IsNot Nothing Then
                    '    Dim c = CType(f.Tag, detalleitemequivalencia_precios)
                    '    objCatalogo.detalleitemequivalencia_precios.Add(c)
                    '    PreciosSelCatalogo(c.equivalencia_id, c.idCatalogo, c.codigodetalle)
                    'End If
                Else
                    MessageBox.Show("Indicar el catalogo de precios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Indicar la unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar producto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim r As Record = GridEquivalencia.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim RecProducto = GridProductos.Table.CurrentRecord
            If RecProducto IsNot Nothing Then
                Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = RecProducto.GetValue("idproducto")).SingleOrDefault
                Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(d) d.equivalencia_id = r.GetValue("IDEQ")).SingleOrDefault

                Dim f As New FormNuevoCatalogoPrecios
                If equivalenciaOBJ.detalleitemequivalencia_catalogos IsNot Nothing Then
                    f.TextNombreCatalogo.Text = $"Lista - {equivalenciaOBJ.detalleitemequivalencia_catalogos.Count}"
                Else
                    f.TextNombreCatalogo.Text = $"Lista - 1"
                End If
                f.CodigoEquivalencia = CInt(r.GetValue("IDEQ"))
                f.CodigoProducto = Integer.Parse(RecProducto.GetValue("idproducto"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, detalleitemequivalencia_catalogos)
                    ADDCatalogoItem(c)
                End If
            Else
                MessageBox.Show("Indicar un producto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Indicar una unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            If GridProductos.Table.CurrentRecord IsNot Nothing Then
                Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                Dim equivalencias = Productos.detalleitem_equivalencias.ToList


                Dim existeSolo = equivalencias.Any(Function(o) o.flag = "SOLO")
                If existeSolo Then
                    MessageBox.Show("No puede agregar mas unidades para este producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim obj As New detalleitem_equivalencias With
                {
                .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
                }

                Dim f As New FormAddUnidadComercial(equivalencias) ' FormAddPrecioEquivalencia
                f.objEntiad = obj
                f.TextUnidadPrincipal.Text = Productos.unidad1
                f.TextUnidadPrincipal.Tag = Productos.unidad1
                'f.Label4.Text = "Agregar equivalencia"
                'f.TipoEntidad = "EQUIVALENCIA"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, detalleitem_equivalencias)
                    Productos.detalleitem_equivalencias.Add(New detalleitem_equivalencias With
                                                            {
                                                            .equivalencia_id = c.equivalencia_id,
                                                            .codigodetalle = c.codigodetalle,
                                                            .detalle = c.detalle,
                                                            .unidadComercial = c.unidadComercial,
                                                            .contenido = c.contenido,
                                                            .contenido_neto = c.contenido_neto,
                                                            .fraccionUnidad = c.fraccionUnidad,
                                                            .estado = "A",
                                                            .usuarioActualizacion = c.usuarioActualizacion,
                                                            .fechaActualizacion = c.fechaActualizacion
                                                            })

                    EquivalenciaSelProducto(c.codigodetalle)

                    'agregando catalogo

                    Dim equivalenciaOBJ = Productos.detalleitem_equivalencias.Where(Function(d) d.equivalencia_id = c.equivalencia_id).SingleOrDefault

                    Dim form As New FormNuevoCatalogoPrecios
                    If equivalenciaOBJ.detalleitemequivalencia_catalogos IsNot Nothing Then
                        form.TextNombreCatalogo.Text = $"Lista - {equivalenciaOBJ.detalleitemequivalencia_catalogos.Count}"
                    Else
                        form.TextNombreCatalogo.Text = $"Lista - 1"
                    End If
                    form.CodigoEquivalencia = c.equivalencia_id
                    form.CodigoProducto = c.codigodetalle
                    form.StartPosition = FormStartPosition.CenterParent
                    form.ShowDialog(Me)
                    If form.Tag IsNot Nothing Then
                        Dim cat = CType(form.Tag, detalleitemequivalencia_catalogos)
                        ADDCatalogoItem(cat)
                    End If

                End If
            Else
                MessageBox.Show("Indicar un producto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        If ComboCatalogoPrecios.Items.Count > 0 Then
            Dim r As Record = GridEquivalencia.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim RecProducto = GridProductos.Table.CurrentRecord
                If RecProducto IsNot Nothing Then
                    Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = RecProducto.GetValue("idproducto")).SingleOrDefault
                    Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(eq) eq.equivalencia_id = r.GetValue("IDEQ")).SingleOrDefault

                    Dim codCatalogo = Integer.Parse(ComboCatalogoPrecios.SelectedValue)

                    Dim objSelCatalogo = equivalenciaOBJ.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = codCatalogo).SingleOrDefault


                    Dim f As New FormNuevoCatalogoPrecios(Integer.Parse(ComboCatalogoPrecios.SelectedValue), ComboCatalogoPrecios.Text, objSelCatalogo.predeterminado)
                    f.CodigoEquivalencia = CInt(r.GetValue("IDEQ"))
                    f.CodigoProducto = Integer.Parse(RecProducto.GetValue("idproducto"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, detalleitemequivalencia_catalogos)
                        EDITCatalogoItem(c)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim catalogoSA As New detalleitemequivalencia_catalogosSA
        If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
            Dim obj As New detalleitemequivalencia_catalogos

            obj.idCatalogo = ComboCatalogoPrecios.SelectedValue
            obj.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))
            obj.predeterminado = True

            catalogoSA.CatalogoPredeterminado(obj)
            MessageBox.Show("Catalogo predeterminado con éxito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Seleccionar una equivalencia!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Try
            'Dim r As Record = GridProductos.Table.CurrentRecord
            'If r Is Nothing Then Exit Sub

            'Dim uc As Record = GridEquivalencia.Table.CurrentRecord
            'If uc Is Nothing Then Exit Sub

            'Dim f As New FormCatalogoUnidadComercial(Me)
            'f.TextProducto.Tag = r.GetValue("idproducto")
            'f.TextProducto.Text = r.GetValue("producto")
            'f.TextUnidadComercial.Text = uc.GetValue("unidadcomercial")
            'f.TextUnidadComercial.Tag = Integer.Parse(uc.GetValue("IDEQ"))
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        If GridProductos.Table.CurrentRecord IsNot Nothing Then
            Dim idProducto = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
            EquivalenciaSelProducto(idProducto)
        End If
    End Sub

    Private Sub CheckInactivos_CheckedChanged(sender As Object, e As EventArgs) Handles CheckInactivos.CheckedChanged
        If GridProductos.Table.CurrentRecord IsNot Nothing Then
            Dim idProducto = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
            EquivalenciaSelProducto(idProducto)
        End If
    End Sub

    Private Sub GridPrecios_TableControlCurrentCellValidated(sender As Object, e As GridTableControlEventArgs) Handles GridPrecios.TableControlCurrentCellValidated
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridPrecios.TableControl.CurrentCell
        'cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                Select Case style.TableCellIdentity.Column.Name
                    Case "rangoinicio" ', "rangofin", "tipoprecio", "PrecioContado", "PrecioCredito", "PrecioContadoUSD", "PrecioCreditoUSD"
                        If cc.Renderer IsNot Nothing Then

                            Dim oldValue = CDec(Me.GridPrecios.TableModel(cc.RowIndex, 2).CellValue)
                            Dim newValue = CDec(cc.Renderer.ControlText)
                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                            If oldValue <> newValue Then
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} {vbCrLf} Guardar cambios ?"
                                    If MessageBox.Show(mensaje, "Cant. mínima", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                        If r IsNot Nothing Then
                                            r.SetValue("rangoinicio", newValue)
                                            EditarPrecio(r)
                                        End If
                                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                    Else
                                        cc.RejectChanges()
                                        Me.GridPrecios.TableModel(cc.RowIndex, 2).CellValue = oldValue
                                        Me.GridPrecios.EndUpdate(True)
                                    End If
                                End If
                            End If
                        End If

                    Case "PrecioContado"
                        If cc.Renderer IsNot Nothing Then

                            Dim oldValue = CDec(Me.GridPrecios.TableModel(cc.RowIndex, 5).CellValue)
                            Dim newValue = CDec(cc.Renderer.ControlText)
                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                            If oldValue <> newValue Then
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} {vbCrLf} Guardar cambios ?"
                                    If MessageBox.Show(mensaje, "Precio contado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                        If r IsNot Nothing Then
                                            r.SetValue("PrecioContado", newValue)
                                            EditarPrecio(r)
                                        End If
                                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                    Else
                                        cc.RejectChanges()
                                        Me.GridPrecios.TableModel(cc.RowIndex, 5).CellValue = oldValue
                                        Me.GridPrecios.EndUpdate(True)
                                    End If
                                End If
                            End If
                        End If

                    Case "PrecioCredito"
                        If cc.Renderer IsNot Nothing Then

                            Dim oldValue = CDec(Me.GridPrecios.TableModel(cc.RowIndex, 7).CellValue)
                            Dim newValue = CDec(cc.Renderer.ControlText)
                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                            If oldValue <> newValue Then
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} {vbCrLf} Guardar cambios ?"
                                    If MessageBox.Show(mensaje, "Precio Credito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                        If r IsNot Nothing Then
                                            r.SetValue("PrecioCredito", newValue)
                                            EditarPrecio(r)
                                        End If
                                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                    Else
                                        cc.RejectChanges()
                                        Me.GridPrecios.TableModel(cc.RowIndex, 7).CellValue = oldValue
                                        Me.GridPrecios.EndUpdate(True)
                                    End If
                                End If
                            End If
                        End If
                End Select


            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        MsgBox("Maximo")
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        MsgBox("Minimo")
    End Sub

    Private Sub GridEquivalencia_TableControlCellMouseUp(sender As Object, e As GridTableControlCellMouseEventArgs) Handles GridEquivalencia.TableControlCellMouseUp

    End Sub

    Private Sub GridEquivalencia_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs) Handles GridEquivalencia.TableControlMouseDown
        'Dim styleinfo As GridTableCellStyleInfo = e.TableControl.PointToTableCellStyle(New Point(e.Inner.X, e.Inner.Y))

        'If e.Inner.Button = MouseButtons.Right AndAlso styleinfo.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
        '    Me.ContextMenuStrip1.Show(Me.GridEquivalencia, Me.GridEquivalencia.PointToClient(Control.MousePosition))
        'ElseIf e.Inner.Button = MouseButtons.Right AndAlso styleinfo.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell Then
        '    Me.ContextMenuStrip1.Show(Me.GridEquivalencia, Me.GridEquivalencia.PointToClient(Control.MousePosition))
        'End If
    End Sub

    Private Sub GridEquivalencia_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridEquivalencia.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "contenidoneto" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            If GridProductos.Table.CurrentRecord IsNot Nothing Then
                Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                Dim equivalencias = Productos.detalleitem_equivalencias.ToList

                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("IDEQ").ToString()
                Dim prodEQ = equivalencias.Where(Function(o) o.equivalencia_id = value).SingleOrDefault

                If prodEQ IsNot Nothing Then
                    Select Case prodEQ.flag
                        Case "MIN", "MAX"

                            e.Style.ReadOnly = True
                        Case Else
                            e.Style.ReadOnly = True
                    End Select
                End If
            End If
        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "estado" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then
            If GridProductos.Table.CurrentRecord IsNot Nothing Then
                Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                Dim equivalencias = Productos.detalleitem_equivalencias.ToList

                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("IDEQ").ToString()
                Dim prodEQ = equivalencias.Where(Function(o) o.equivalencia_id = value).SingleOrDefault

                If prodEQ IsNot Nothing Then
                    Select Case prodEQ.flag
                        Case "MIN", "MAX"

                            e.Style.ReadOnly = True
                        Case Else
                            e.Style.ReadOnly = False
                    End Select
                End If
            End If
        End If
    End Sub

    Private Sub txtProducto_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListProductos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListProductos.MouseDoubleClick
        If ListProductos.SelectedItems.Count > 0 Then

            Dim cod = GridProductos.Table.CurrentRecord.GetValue("idproducto")


            Dim itemProd = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(cod)).SingleOrDefault
            If itemProd IsNot Nothing Then

                itemProd.detalleitems_conexo.Add(New detalleitems_conexo With
                                      {
                                      .customdetalleitems = itemProd,
                                      .codigodetalle = itemProd.codigodetalle, .detalle = itemProd.descripcionItem,
                                      .cantidad = 1,
                                      .idProducto = itemProd.codigodetalle,
                                      .customEquivalencia = itemProd.detalleitem_equivalencias.FirstOrDefault,
                                      .equivalencia_id = itemProd.detalleitem_equivalencias.FirstOrDefault.equivalencia_id,
                                      .unidadComercial = itemProd.detalleitem_equivalencias.FirstOrDefault.detalle,
                                      .fraccion = itemProd.detalleitem_equivalencias.FirstOrDefault.fraccionUnidad
                                      })

                ItemsConexosSelProducto(itemProd.codigodetalle)
            End If

        End If
    End Sub

    Private Sub BunifuFlatButton8_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton8.Click
        If GridProductos.Table.CurrentRecord IsNot Nothing Then
            Dim f As New FormAgregarConexo
            f.txtProducto.ReadOnly = False
            f.ComboUnidades.Visible = True
            f.idProductoPadre = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim prod = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                Dim c = CType(f.Tag, detalleitems_conexo)
                prod.detalleitems_conexo.Add(c)
                ItemsConexosSelProducto(prod.codigodetalle)
            End If
        Else
            MessageBox.Show("Seleccione un producto valido")
        End If
    End Sub

    Private Sub BunifuFlatButton9_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton9.Click
        Dim itemSA As New detalleitems_conexoSA
        If GridConexos.Table.CurrentRecord IsNot Nothing Then

            If MessageBox.Show("Eliminar item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim codConexo = Integer.Parse(GridConexos.Table.CurrentRecord.GetValue("id"))
                GridConexos.Table.CurrentRecord.Delete()
                itemSA.SaveConexo(New detalleitems_conexo With {.Action = BaseBE.EntityAction.DELETE, .conexo_id = codConexo})

                Dim prod = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                If prod IsNot Nothing Then
                    Dim listaConexos = prod.detalleitems_conexo.ToList
                    Dim conexo = listaConexos.Where(Function(o) o.conexo_id = codConexo).SingleOrDefault
                    listaConexos.Remove(conexo)
                    prod.detalleitems_conexo.Remove(conexo)
                End If
                ItemsConexosSelProducto(Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")))
            End If


        End If
    End Sub

    Private Sub chkEquivalencia_CheckedChanged(sender As Object, e As EventArgs) Handles chkEquivalencia.CheckedChanged
        If chkEquivalencia.Checked = True Then
            GridEquivalencia.TableDescriptor.Columns("fraccion").Width = 75
            GridEquivalencia.TableDescriptor.Columns("contenido").Width = 75
        ElseIf chkEquivalencia.Checked = False Then

            GridEquivalencia.TableDescriptor.Columns("fraccion").Width = 0
            GridEquivalencia.TableDescriptor.Columns("contenido").Width = 0
        End If
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        If GridProductos.Table.CurrentRecord IsNot Nothing Then

            Dim afectacion As String = GridProductos.Table.CurrentRecord.GetValue("gravado")

            ListLotes.Items.Clear()
            Dim ventaSA As New documentoVentaAbarrotesSA
            Dim lotes = ventaSA.ConsultaLotesDisponiblesAdmin(New documentoventaAbarrotesDet With {.idItem = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))})
            Dim coniva As Decimal = 0
            Dim conIvaMaximo As Decimal = 0
            Dim conIvaMinimo As Decimal = 0

            Dim Maximo = lotes.Max(Function(o) o.GetPrice).GetValueOrDefault
            conIvaMaximo = Maximo * 0.18
            conIvaMaximo = conIvaMaximo + Maximo

            Dim Minimo = lotes.Min(Function(o) o.GetPrice).GetValueOrDefault
            conIvaMinimo = Minimo * 0.18
            conIvaMinimo = conIvaMinimo + Minimo

#Region "Maximo"
            LabelCostoUnitMax.Text = Maximo
            ' LabelCostoUnitMax.Tag = conIvaMaximo

            LabelMaximoN.Text = Maximo
            LabelMaximoN.Tag = conIvaMaximo
#End Region

#Region "Minimo"
            LabelCostoUnitMin.Text = Minimo
            ' LabelCostoUnitMin.Tag = conIvaMinimo

            LabelMinimoN.Text = Minimo
            LabelMinimoN.Tag = conIvaMinimo
#End Region

            Dim sumaStock As Decimal = 0
            For Each i In lotes.OrderByDescending(Function(o) o.fechaProduccion).ToList
                sumaStock += CDec(i.stock)
                Select Case afectacion
                    Case "1"
                        coniva = i.precioUnitarioIva.GetValueOrDefault * 0.18
                        coniva = coniva + i.precioUnitarioIva.GetValueOrDefault

                        Dim n As New ListViewItem(i.codigoLote)
                        n.SubItems.Add(i.fechaProduccion.GetValueOrDefault)
                        n.SubItems.Add(coniva.ToString("N2"))
                        n.SubItems.Add(Math.Round(i.precioUnitarioIva.GetValueOrDefault / i.cantidad.GetValueOrDefault, 2))

                        n.SubItems.Add(i.stock.GetValueOrDefault)
                        n.SubItems.Add(i.UnidadComercial)
                        n.SubItems.Add(i.Proveedor)
                        ListLotes.Items.Add(n)
                    Case "2"
                        coniva = i.precioUnitarioIva.GetValueOrDefault * 0.18
                        coniva = coniva + i.precioUnitarioIva.GetValueOrDefault


                        Dim n As New ListViewItem(i.codigoLote)
                        n.SubItems.Add(i.fechaProduccion.GetValueOrDefault)
                        n.SubItems.Add(coniva.ToString("N2"))
                        n.SubItems.Add(Math.Round(i.precioUnitarioIva.GetValueOrDefault / i.cantidad.GetValueOrDefault, 2))
                        n.SubItems.Add(i.stock.GetValueOrDefault)
                        n.SubItems.Add(i.UnidadComercial)
                        n.SubItems.Add(i.Proveedor)
                        ListLotes.Items.Add(n)
                End Select
            Next

            If ListLotes.Items.Count > 0 Then
                Dim n1 As New ListViewItem("")
                n1.SubItems.Add("Total")
                n1.SubItems.Add("")
                n1.SubItems.Add("")
                n1.SubItems.Add(sumaStock)
                n1.SubItems.Add("")
                n1.SubItems.Add("")
                ListLotes.Items.Add(n1)
            End If

        End If
    End Sub

    Private Sub LabelCostoUnitMax_Click(sender As Object, e As EventArgs) Handles LabelCostoUnitMax.Click

    End Sub

    Private Sub ListLotes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListLotes.SelectedIndexChanged

    End Sub

    Private Sub GetListProductos(consulta As List(Of detalleitems))
        ListProductos.Items.Clear()
        For Each i In consulta
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.composicion)
            If i.recursoCostoLote.Count > 0 Then
                n.SubItems.Add(i.recursoCostoLote.FirstOrDefault.fechaentrada.GetValueOrDefault)
                n.SubItems.Add(i.recursoCostoLote.FirstOrDefault.precioUnitarioIva.GetValueOrDefault)
            Else
                n.SubItems.Add("-")
                n.SubItems.Add("-")
            End If

            ListProductos.Items.Add(n)
        Next
        ListProductos.Refresh()
    End Sub

    Private Sub CombopRICES_Click(sender As Object, e As EventArgs) Handles CombopRICES.Click


    End Sub

    Private Sub ListLotes_MouseMove(sender As Object, e As MouseEventArgs) Handles ListLotes.MouseMove
        'Dim item As ListViewItem = ListLotes.GetItemAt(e.X, e.Y)
        'Dim info As ListViewHitTestInfo = ListLotes.HitTest(e.X, e.Y)

        'If (item IsNot Nothing) AndAlso (info.SubItem IsNot Nothing) Then
        '    ToolTip1.SetToolTip(ListLotes, info.SubItem.Text)
        '    ToolTip1.IsBalloon = True
        '    ToolTip1.Show(info.SubItem.Text, ListLotes, e.X, e.Y, 2000)
        'Else
        '    ToolTip1.SetToolTip(ListLotes, "")
        '    ToolTip1.IsBalloon = False
        'End If
    End Sub

    Private Sub CombopRICES_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CombopRICES.SelectionChangeCommitted
        Try
            If CombopRICES.Text = "SIN IGV" Then
                If Decimal.Parse(LabelCostoUnitMax.Text) > 0 Then
                    LabelCostoUnitMax.Text = LabelMaximoN.Text
                    LabelCostoUnitMin.Text = LabelMinimoN.Text
                End If

            ElseIf CombopRICES.Text = "CON IGV" Then
                If Decimal.Parse(LabelCostoUnitMax.Text) > 0 Then
                    LabelCostoUnitMax.Text = LabelMaximoN.Tag
                    LabelCostoUnitMin.Text = LabelMinimoN.Tag
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    'Private void gridControl1_CurrentCellValidated(Object sender, EventArgs e)
    '{
    'GridCurrentCell cc = this.gridControl1.CurrentCell;
    'String newValue = cc.Renderer.ControlText;
    'String oldValue = this.gridControl1[cc.RowIndex, cc.ColIndex].Text;
    'If (oldValue! = newValue)
    '{
    'If (MessageBox.Show("[Value Changed to]: " + newValue + " [OldVaue ]: " + oldValue + " \n\nWant to Save ?", "Validating Cells", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
    '{
    'this.gridControl1.EndUpdate();
    '}
    'Else
    '{
    'cc.RejectChanges();
    'this.gridControl1[cc.RowIndex, cc.ColIndex].Text = oldValue;
    'this.gridControl1.EndUpdate();
    '}
    '}
    '}

#End Region

End Class
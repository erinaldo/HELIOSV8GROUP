Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.WinForms.ListView
Imports System.Collections.Specialized
Imports System.Xml
Public Class UCPrincipalProductos

#Region "Variables"

    Public listaProductos As List(Of detalleitems)
    Public ListCategories As List(Of item)
    Public m_xmld As Xml.XmlDocument
    Public Property LabelMaximoN As Label
    Public Property LabelMinimoN As Label

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridAvanzado(GridProductos, False, False, 9.0F)
        'FormatoGridAvanzado(GridEquivalencia, False, False, 9.0F)
        FormatoGridAvanzado(GridPrecios, False, False, 9.0F)
        FormatoGridAvanzado(GridPrecioProducto, False, False, 9.0F)
        FormatoGrid(GridProductos)
        'FormatoGrid(GridEquivalencia)
        'FormatoGrid(GridPrecios)
        FormatoGrid(GridPrecioProducto)
        FormatoGridBlack(GridConexos, False)


        GridProductos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GridEquivalencia.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GridPrecios.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GridPrecioProducto.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        'GroupBar1.BorderStyle = BorderStyle.None
        GetCombos()
        'GetCategories()
        GridEquivalencia.TableDescriptor.Columns("contenidoneto").Appearance.AnyRecordFieldCell.TextColor = Color.Black
        'GridEquivalencia.TableControl.mouse += New MouseEventHandler(TableControl_MouseUp);
        LabelMaximoN = New Label
        LabelMinimoN = New Label
        'Centrar(Me)
        'AddHandler sfListView1.View.SourceCollectionChanged, AddressOf View_SourceCollectionChanged

    End Sub

#End Region




#Region "Metodos"

    Private Sub EDITCatalogoItem(c As detalleitemequivalencia_catalogos)
        Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = c.codigodetalle).SingleOrDefault
        Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = c.equivalencia_id).SingleOrDefault

        Dim objSelCatalogo = equivalenciaOBJ.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = c.idCatalogo).SingleOrDefault

        objSelCatalogo.nombre_corto = c.nombre_corto
        objSelCatalogo.nombre_largo = c.nombre_largo

        CatalogoPreciosSelEquivalencia(equivalenciaOBJ.equivalencia_id, productoOBJ.codigodetalle)
    End Sub
    Private Sub CambiarEstado(estado As String)
        Dim itemSA As New detalleitemsSA
        itemSA.CambiarEstadoItem(New detalleitems With
                                 {
                                 .codigodetalle = GridProductos.Table.CurrentRecord.GetValue("idproducto"),
                                 .estado = estado
                                 })
        If estado = "A" Then
            GridProductos.Table.CurrentRecord.SetValue("estado", "Activo")
        Else
            GridProductos.Table.CurrentRecord.SetValue("estado", "Inactivo")
        End If
        MessageBox.Show("El producto cambio de estado", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Private Sub GetCategories()

    '    dockingManager1.DockControlInAutoHideMode(panelCategorie, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 200)

    '    dockingManager1.SetDockLabel(panelCategorie, "Categorías")
    '    dockingManager1.VisualStyle = VisualStyle.Office2016Black

    '    Dim itemSA As New itemSA
    '    ListCategories = New List(Of item)
    '    ListCategories.Add(New item With {
    '        .idItem = 0,
    '        .descripcion = "All"
    '         })
    '    Try
    '        ListCategories.AddRange(itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc))
    '        sfListView1.DataSource = ListCategories
    '        sfListView1.DisplayMember = "descripcion"
    '        sfListView1.ValueMember = "idItem"


    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub GetCombos()
        Dim tablaSA As New tablaDetalleSA
        Dim ggcStyle As GridTableCellStyleInfo = GridEquivalencia.TableDescriptor.Columns("detalle").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
        ggcStyle.ValueMember = "codigoDetalle"
        ggcStyle.DisplayMember = "descripcion"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Private Sub CleanPrices()
        'ListLotes.Items.Clear()
        'LabelCostoUnitMin.Text = "0"
        'LabelCostoUnitMax.Text = "0"
        LabelMaximoN.Text = "0"
        LabelMaximoN.Tag = 0
        LabelMinimoN.Text = "0"
        LabelMinimoN.Tag = 0
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
                                                  .codigo = r.GetValue("codigo").ToString(),
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

    Private Sub ADDCatalogoItem(c As detalleitemequivalencia_catalogos)
        Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = c.codigodetalle).SingleOrDefault
        Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = c.equivalencia_id).SingleOrDefault

        equivalenciaOBJ.detalleitemequivalencia_catalogos.Add(c)
        CatalogoPreciosSelEquivalencia(equivalenciaOBJ.equivalencia_id, productoOBJ.codigodetalle)
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
    Public Function IsInRange(ByVal valorMin As Decimal, ByVal ValorMax As Decimal, ByVal Valor As Decimal) As Boolean
        If Valor >= valorMin AndAlso Valor <= ValorMax Then Return True
        Return False
    End Function
    Private Sub PreciosSelCatalogo(idEquivalencia As Integer, idCatalogo As Integer, idProducto As Integer)
        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        Dim equivalencias = Productos.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

        Dim catalogoPrec = equivalencias.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault

        If equivalencias IsNot Nothing Then
            If catalogoPrec IsNot Nothing Then
                'Dim precios = catalogoPrec.detalleitemequivalencia_precios.ToList
                Dim ListPrices = catalogoPrec.detalleitemequivalencia_precios.ToList

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

                'For Each i In precios
                '    dt.Rows.Add(
                '        i.precio_id,
                '        i.rango_inicio,
                '        i.rango_final,
                '        i.precioCode,
                '        i.precio.GetValueOrDefault,
                '        i.precioUSD.GetValueOrDefault,
                '        i.precioCredito.GetValueOrDefault,
                '        i.precioCreditoUSD.GetValueOrDefault)
                'Next
                If Productos.item IsNot Nothing Then
                    'BunifuFlatButton11.Visible = False
                Else
                    'BunifuFlatButton11.Visible = True
                End If

                If Productos.item IsNot Nothing Then ' CATEGORIES HAS
                    Dim firstPercent = Productos.item.firstpercent.GetValueOrDefault
                    Dim beforePercent = Productos.item.beforepercent.GetValueOrDefault
                    Dim precioCompra = Productos.precioCompra.GetValueOrDefault


                    Select Case Productos.item.preciocompratipo
                        Case "PCT"

                            'TextFirstDescuento.Value = firstPercent
                            'TextBeforeDescuento.Value = beforePercent
                            'TextPrecioCompraNuevo.Value = precioCompra
                            If ListPrices.Count = 0 Then

                            ElseIf ListPrices.Count = 1 Then

                                If equivalencias.flag = "MAX" Or equivalencias.flag = "SOLO" Then
                                    Dim result = precioCompra * (firstPercent / 100)
                                    result = result + precioCompra

                                    For Each i In ListPrices
                                        dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)
                                    Next
                                Else
                                    Dim eqprec = Productos.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX" Or e.flag = "SOLO").SingleOrDefault
                                    Dim valorUnitarioItem = Productos.precioCompra / eqprec.contenido_neto

                                    For Each i In ListPrices '.OrderByDescending(Function(o) o.precio_id).ToList
                                        Dim result = valorUnitarioItem * (firstPercent / 100)
                                        result = result + valorUnitarioItem

                                        dt.Rows.Add(
                                            i.precio_id,
                                            i.rango_inicio,
                                            i.rango_final,
                                            i.precioCode,
                                            result,
                                            0,
                                            result,
                                            0)
                                    Next
                                End If


                            ElseIf ListPrices.Count > 1 Then
                                Dim eqprec = Productos.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX" Or e.flag = "SOLO").SingleOrDefault
                                Dim valorUnitarioItem = Productos.precioCompra / eqprec.contenido_neto
                                Dim ultimoIndex = ListPrices.Count - 1
                                Dim index = 0


                                'Dim UnidadPrincipal = _product.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX").SingleOrDefault
                                'Dim RestoUnidades = _product.detalleitem_equivalencias.Where(Function(e) e.flag <> "MAX").ToList
                                If equivalencias.flag = "MAX" Or equivalencias.flag = "SOLO" Then
                                    For Each i In ListPrices '.OrderByDescending(Function(o) o.precio_id).ToList
                                        If index = ultimoIndex Then
                                            Dim result = precioCompra * (beforePercent / 100)
                                            result = result + precioCompra

                                            dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)
                                        Else

                                            Dim result = precioCompra * (firstPercent / 100)
                                            result = result + precioCompra

                                            dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)

                                        End If
                                        index += 1
                                    Next


                                Else


                                    For Each i In ListPrices '.OrderByDescending(Function(o) o.precio_id).ToList
                                        If index = ultimoIndex Then
                                            Dim result = valorUnitarioItem * (beforePercent / 100)
                                            result = result + valorUnitarioItem

                                            dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)
                                        Else

                                            Dim result = valorUnitarioItem * (firstPercent / 100)
                                            result = result + valorUnitarioItem

                                            dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)

                                        End If
                                        index += 1
                                    Next
                                End If

                            End If


                        Case Else ' CONFIGURACION NORMAL

                            'TextFirstDescuento.Value = Productos.firstpercent.GetValueOrDefault
                            'TextBeforeDescuento.Value = Productos.beforepercent.GetValueOrDefault
                            'TextPrecioCompraNuevo.Value = Productos.precioCompra.GetValueOrDefault

                            For Each i In ListPrices
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
                    End Select

                Else
                    Select Case Productos.preciocompratipo
                        Case "PCT"
                            Dim firstPercent = Productos.firstpercent.GetValueOrDefault
                            Dim beforePercent = Productos.beforepercent.GetValueOrDefault
                            Dim precioCompra = Productos.precioCompra.GetValueOrDefault

                            'TextFirstDescuento.Value = firstPercent
                            'TextBeforeDescuento.Value = beforePercent
                            'TextPrecioCompraNuevo.Value = precioCompra

                            If ListPrices.Count = 0 Then

                            ElseIf ListPrices.Count = 1 Then

                                If equivalencias.flag = "MAX" Or equivalencias.flag = "SOLO" Then
                                    Dim result = precioCompra * (firstPercent / 100)
                                    result = result + precioCompra

                                    For Each i In ListPrices
                                        dt.Rows.Add(
                                            i.precio_id,
                                            i.rango_inicio,
                                            i.rango_final,
                                            i.precioCode,
                                            result,
                                            0,
                                            result,
                                            0)
                                    Next
                                Else
                                    Dim eqprec = Productos.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX" Or e.flag = "SOLO").SingleOrDefault
                                    Dim valorUnitarioItem = Productos.precioCompra / eqprec.contenido_neto

                                    For Each i In ListPrices '.OrderByDescending(Function(o) o.precio_id).ToList
                                        Dim result = valorUnitarioItem * (firstPercent / 100)
                                        result = result + valorUnitarioItem

                                        dt.Rows.Add(
                                            i.precio_id,
                                            i.rango_inicio,
                                            i.rango_final,
                                            i.precioCode,
                                            result,
                                            0,
                                            result,
                                            0)
                                    Next
                                End If

                            ElseIf ListPrices.Count > 1 Then
                                Dim eqprec = Productos.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX" Or e.flag = "SOLO").SingleOrDefault
                                Dim valorUnitarioItem = Productos.precioCompra / eqprec.contenido_neto
                                Dim ultimoIndex = ListPrices.Count - 1
                                Dim index = 0


                                'Dim UnidadPrincipal = _product.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX").SingleOrDefault
                                'Dim RestoUnidades = _product.detalleitem_equivalencias.Where(Function(e) e.flag <> "MAX").ToList
                                If equivalencias.flag = "MAX" Or equivalencias.flag = "SOLO" Then
                                    For Each i In ListPrices '.OrderByDescending(Function(o) o.precio_id).ToList
                                        If index = ultimoIndex Then
                                            Dim result = precioCompra * (beforePercent / 100)
                                            result = result + precioCompra

                                            dt.Rows.Add(
                                            i.precio_id,
                                            i.rango_inicio,
                                            i.rango_final,
                                            i.precioCode,
                                            result,
                                            0,
                                            result,
                                            0)
                                        Else

                                            Dim result = precioCompra * (firstPercent / 100)
                                            result = result + precioCompra

                                            dt.Rows.Add(
                                            i.precio_id,
                                            i.rango_inicio,
                                            i.rango_final,
                                            i.precioCode,
                                            result,
                                            0,
                                            result,
                                            0)

                                        End If
                                        index += 1
                                    Next


                                Else


                                    For Each i In ListPrices '.OrderByDescending(Function(o) o.precio_id).ToList
                                        If index = ultimoIndex Then
                                            Dim result = valorUnitarioItem * (beforePercent / 100)
                                            result = result + valorUnitarioItem

                                            dt.Rows.Add(
                                            i.precio_id,
                                            i.rango_inicio,
                                            i.rango_final,
                                            i.precioCode,
                                            result,
                                            0,
                                            result,
                                            0)
                                        Else

                                            Dim result = valorUnitarioItem * (firstPercent / 100)
                                            result = result + valorUnitarioItem

                                            dt.Rows.Add(
                                            i.precio_id,
                                            i.rango_inicio,
                                            i.rango_final,
                                            i.precioCode,
                                            result,
                                            0,
                                            result,
                                            0)

                                        End If
                                        index += 1
                                    Next
                                End If




                            End If


                        Case Else ' CONFIGURACION NORMAL

                            'TextFirstDescuento.Value = Productos.firstpercent.GetValueOrDefault
                            'TextBeforeDescuento.Value = Productos.beforepercent.GetValueOrDefault
                            'TextPrecioCompraNuevo.Value = Productos.precioCompra.GetValueOrDefault

                            For Each i In ListPrices
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
                    End Select
                End If

                GridPrecios.DataSource = dt
            End If
        End If
    End Sub
    Private Sub EditProductClothing()
        Cursor = Cursors.WaitCursor
        Dim r As Record = GridProductos.Table.CurrentRecord
        ' If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_PRODUCTO_Botón___, AutorizacionRolList) Then
        ' If TextBoxExt1.Text.Trim.Length > 0 Then
        If r IsNot Nothing Then
            Dim idProducto = Integer.Parse(r.GetValue("idproducto"))
            Dim f As New FormCrearExistenciaNueva(idProducto)
            f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Seleccione un producto válido", "Seleccinar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ' End If
        End If

        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub EditProductClothingcomerciales()
        Cursor = Cursors.WaitCursor
        Dim r As Record = GridProductos.Table.CurrentRecord
        ' If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_PRODUCTO_Botón___, AutorizacionRolList) Then
        ' If TextBoxExt1.Text.Trim.Length > 0 Then
        If r IsNot Nothing Then
            Dim idProducto = Integer.Parse(r.GetValue("idproducto"))
            'Dim f As New FormCrearExistenciaNueva(idProducto)
            'f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()



            Dim f As New frmNuevaExistencia(Val(r.GetValue("idproducto")))
            f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

        Else
            MessageBox.Show("Seleccione un producto válido", "Seleccinar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ' End If
        End If

        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GetProductos()
        Dim conteo As Integer = 0
        Dim listaSA As New detalleitemsSA
        Dim tipoex As String = String.Empty


        Select Case ComboConsulta.Text
            Case "NOMBRE"
                listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .typeConsult = ComboConsulta.Text,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = txtFiltrar.Text
                                                          })

            Case "CATEGORIA"
                listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                     {
                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                     .typeConsult = ComboConsulta.Text,
                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                     .idItem = ComboItem.SelectedValue
                                                     })


            Case "SUB CATEGORIA"
                listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                   {
                                                   .idEmpresa = Gempresas.IdEmpresaRuc,
                                                   .typeConsult = ComboConsulta.Text,
                                                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                   .unidad2 = ComboItem.SelectedValue
                                                   })
            Case "MARCA"

                listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                   {
                                                   .idEmpresa = Gempresas.IdEmpresaRuc,
                                                   .typeConsult = ComboConsulta.Text,
                                                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                   .marcaRef = ComboItem.SelectedValue
                                                   })

            Case "TALLA"

                listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                   {
                                                   .idEmpresa = Gempresas.IdEmpresaRuc,
                                                   .typeConsult = ComboConsulta.Text,
                                                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                   .talla = ComboItem.Text
                                                   })

            Case "COLOR"
                listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                  {
                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                  .typeConsult = ComboConsulta.Text,
                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                  .Color = ComboItem.Text
                                                  })
            Case "PESO"

            Case Else

        End Select




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
        dt.Columns.Add("sel", GetType(Boolean))


        dt.Columns.Add("SubCategoria")
        dt.Columns.Add("Marca")
        dt.Columns.Add("Talla")
        dt.Columns.Add("Color")
        dt.Columns.Add("Peso")


        GridEquivalencia.Table.Records.DeleteAll()
        GridPrecios.Table.Records.DeleteAll()
        'GridPrecioProducto.Table.Records.DeleteAll()

        For Each i In listaProductos
            i.Assign = False
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
                   If(i.item IsNot Nothing, i.item.descripcion, "-"),
                    i.origenProducto,
                    i.codigodetalle,
                    i.codigo,
                    i.descripcionItem,
                    i.unidad1,
                    If(i.detalleitem_equivalencias IsNot Nothing, i.detalleitem_equivalencias.FirstOrDefault.detalle, ""),
                    tipoex,
                    i.estado, False, i.CustomSubCategoria.descripcion, i.customMarca.descripcion, i.talla, i.color, i.Peso
                    )
            Else
                dt.Rows.Add(
                     If(i.item IsNot Nothing, i.item.descripcion, "-"),
                    i.origenProducto,
                    i.codigodetalle,
                    i.codigo,
                    i.descripcionItem,
                    i.unidad1,
                    "",
                    tipoex,
                    i.estado, False, i.CustomSubCategoria.descripcion, i.customMarca.descripcion, i.talla, i.color, i.Peso
                    )
            End If

            conteo = conteo + 1
        Next
        GridProductos.DataSource = dt
    End Sub

    Private Sub EquivalenciaSelProducto(idProducto As Integer)
        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        Dim equivalencias As List(Of detalleitem_equivalencias) = Nothing

        Select Case CheckInactivos.Checked
            Case True
                equivalencias = Productos.detalleitem_equivalencias.OrderByDescending(Function(z) z.contenido_neto).ToList



            Case False

                If usuario.tipoNegocio = "1" Then
                    equivalencias = Productos.detalleitem_equivalencias.Where(Function(o) o.estado = "A").OrderByDescending(Function(z) z.contenido_neto).ToList
                Else
                    equivalencias = Productos.detalleitem_equivalencias.Where(Function(o) o.estado = "A").OrderBy(Function(z) z.contenido_neto).ToList
                End If


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
        dt.Columns.Add("codigo")
        For Each i In equivalencias
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.unidadComercial, i.contenido, i.fraccionUnidad, "", i.estado_bool, i.contenido_neto.GetValueOrDefault, i.codigo)
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

    Private Sub llenarDetalle(idProducto As Integer)
        Try

            lblTipoBien.Text = "-"
            lblClasificacion.Text = "-"
            lblCategoria.Text = "-"
            lblSubCategoria.Text = "-"
            lblMarca.Text = "-"
            lblPresentacion.Text = "-"
            lblColor.Text = "-"
            lblTalla.Text = "-"
            lblAdcional1.Text = "-"
            lblAdicional2.Text = "-"



            Dim _product = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

            lblTipoBien.Text = _product.tipoBien
            lblClasificacion.Text = _product.customClasificacion.descripcion
            lblCategoria.Text = _product.customCategoria.descripcion
            lblSubCategoria.Text = _product.CustomSubCategoria.descripcion
            lblMarca.Text = _product.customMarca.descripcion
            lblPresentacion.Text = _product.customPresentacion.descripcion
            lblColor.Text = _product.color
            lblTalla.Text = _product.talla
            lblAdcional1.Text = _product.electricidad
            lblAdicional2.Text = _product.transmision
            lblCodigoInterno.Text = _product.codigoInterno
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetProductPrice(idProducto As Integer)
        'Dim productoSA As New WCFService.ServiceAccess.detalleitemsSA
        ComboBoxAdv1.Enabled = True
        TextFirstDescuento.Enabled = True
        TextBeforeDescuento.Enabled = True
        Dim _product = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault ' productoSA.GetUbicaProductoID(iDProducto)
        If _product.preciocompratipo = "PCT" Then
            ComboBoxAdv1.Text = "PORCENTAJE"
        Else
            ComboBoxAdv1.Text = "MONTO FIJO"
        End If


        If _product.item IsNot Nothing Then
            Dim category = _product.item

            TextFirstDescuento.Enabled = False
            TextBeforeDescuento.Enabled = False

            If category.preciocompratipo = "NN" Then
                TextNivel.Text = "Categoría sin confi."
                BunifuFlatButton11.Visible = True

                TextFirstDescuento.Value = _product.firstpercent.GetValueOrDefault
                TextBeforeDescuento.Value = _product.beforepercent.GetValueOrDefault
                TextPrecioCompraNuevo.Value = _product.precioCompra.GetValueOrDefault

                Select Case _product.preciocompratipo
                    Case "PCT"
                        ComboBoxAdv1.Text = "PORCENTAJE"

                    Case Else
                        ComboBoxAdv1.Text = "MONTO FIJO"

                End Select

            ElseIf category.preciocompratipo = "PCT" Then
                ComboBoxAdv1.Enabled = False
                TextNivel.Text = "Categoría {%}"
                BunifuFlatButton11.Visible = True
                ComboBoxAdv1.Text = "PORCENTAJE"

                TextFirstDescuento.Value = category.firstpercent.GetValueOrDefault
                TextBeforeDescuento.Value = category.beforepercent.GetValueOrDefault
                TextPrecioCompraNuevo.Value = _product.precioCompra.GetValueOrDefault
            End If
        Else
            TextFirstDescuento.Value = _product.firstpercent.GetValueOrDefault
            TextBeforeDescuento.Value = _product.beforepercent.GetValueOrDefault
            TextPrecioCompraNuevo.Value = _product.precioCompra.GetValueOrDefault
            Select Case _product.preciocompratipo
                Case "PCT"
                    TextNivel.Text = "Item {%}"
                    BunifuFlatButton11.Visible = True
                    ComboBoxAdv1.Text = "PORCENTAJE"
                Case "FJ"
                    TextNivel.Text = "Item {0.00}"
                    BunifuFlatButton11.Visible = True
                    ComboBoxAdv1.Text = "MONTO FIJO"
                Case Else
                    TextNivel.Text = "Item {0.00}"
                    BunifuFlatButton11.Visible = True
                    ComboBoxAdv1.Text = "MONTO FIJO"
            End Select

            'TextNivel.Text = "SIN CONFIGURACION"
        End If

    End Sub

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

#End Region

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

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

    Private Sub btnNuevoProducto_Click(sender As Object, e As EventArgs) Handles btnNuevoProducto.Click
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


            '.UCNuenExistencia.chClasificacion.Checked = False
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

    Private Sub btnEditarProducto_Click(sender As Object, e As EventArgs) Handles btnEditarProducto.Click
        Dim rubro As Integer = 1
        m_xmld = New XmlDocument()
        m_xmld.Load("C:\SPKconfiguration.xml")
        Dim m_nodeAPI = m_xmld.SelectNodes("/spk/company/deal")
        For Each m_node In m_nodeAPI
            'Obtenemos el Elemento RUC
            Dim ApiCodigo = m_node.ChildNodes.Item(0).InnerText
            If ApiCodigo.ToString.Trim.Length > 0 Then
                rubro = ApiCodigo
                Exit For
            End If
        Next

        If rubro = 1 Then
            'CreateProductGeneric()
            EditProductClothingcomerciales()
        ElseIf rubro = 2 Then
            EditProductClothing()
        End If
    End Sub

    Private Sub GridProductos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridProductos.TableControlCellClick
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
                GetProductPrice(idProducto)
                If r.GetValue("tipoexistencia") = "KIT" Then
                    TabConceptos.TabPages(1).Enabled = True
                    ItemsConexosSelProducto(idProducto)
                End If


                llenarDetalle(idProducto)


            End If
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridEquivalencia.TableControlCellClick
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

    Private Sub GridEquivalencia_TableControlCurrentCellValidated(sender As Object, e As GridTableControlEventArgs) Handles GridEquivalencia.TableControlCurrentCellValidated
        Dim equivalenciaSA As New detalleitem_equivalenciasSA
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
            ElseIf style.TableCellIdentity.Column.Name = "codigo" Then
                If cc.Renderer IsNot Nothing Then
                    Dim text As String = cc.Renderer.ControlText
                    Dim oldValue = Me.GridEquivalencia.TableModel(cc.RowIndex, 9).CellValue
                    Dim newValue = text
                    Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                    If oldValue <> newValue Then
                        Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} Desea guardar cambios ?"
                        If MessageBox.Show(mensaje, "Unidad comercial", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Me.GridEquivalencia.EndUpdate(True)
                            r.SetValue("codigo", newValue)
                            If text.Trim.Length > 0 Then
                                If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then

                                    Dim codigoExiste = equivalenciaSA.GetExisteCodeUnidadComercial(New detalleitem_equivalencias() With
                                                                                                   {
                                                                                                   .codigo = newValue
                                                                                                   })

                                    If (codigoExiste) Then
                                        cc.RejectChanges()
                                        Me.GridEquivalencia.TableModel(cc.RowIndex, 9).CellValue = oldValue
                                        Me.GridEquivalencia.EndUpdate(True)
                                        MessageBox.Show("El codigo ingresado no está disponible, ingrese otro!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    Else
                                        EditarEquivalencia(r)
                                    End If
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        Else
                            cc.RejectChanges()
                            Me.GridEquivalencia.TableModel(cc.RowIndex, 9).CellValue = oldValue
                            Me.GridEquivalencia.EndUpdate(True)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

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

    Private Sub GridPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPrecios.TableControlCellClick

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

                    Case "PrecioContadoUSD"
                        If cc.Renderer IsNot Nothing Then

                            Dim oldValue = CDec(Me.GridPrecios.TableModel(cc.RowIndex, 6).CellValue)
                            Dim newValue = CDec(cc.Renderer.ControlText)
                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                            If oldValue <> newValue Then
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} {vbCrLf} Guardar cambios ?"
                                    If MessageBox.Show(mensaje, "Precio Contado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                        If r IsNot Nothing Then
                                            r.SetValue("PrecioContadoUSD", newValue)
                                            EditarPrecio(r)
                                        End If
                                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                    Else
                                        cc.RejectChanges()
                                        Me.GridPrecios.TableModel(cc.RowIndex, 6).CellValue = oldValue
                                        Me.GridPrecios.EndUpdate(True)
                                    End If
                                End If
                            End If
                        End If

                    Case "PrecioCreditoUSD"
                        If cc.Renderer IsNot Nothing Then

                            Dim oldValue = CDec(Me.GridPrecios.TableModel(cc.RowIndex, 8).CellValue)
                            Dim newValue = CDec(cc.Renderer.ControlText)
                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                            If oldValue <> newValue Then
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} {vbCrLf} Guardar cambios ?"
                                    If MessageBox.Show(mensaje, "Precio Credito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                        If r IsNot Nothing Then
                                            r.SetValue("PrecioCreditoUSD", newValue)
                                            EditarPrecio(r)
                                        End If
                                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                    Else
                                        cc.RejectChanges()
                                        Me.GridPrecios.TableModel(cc.RowIndex, 8).CellValue = oldValue
                                        Me.GridPrecios.EndUpdate(True)
                                    End If
                                End If
                            End If
                        End If

                End Select


            End If
        End If
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

    Private Sub btnNuevaUnidadComercial_Click(sender As Object, e As EventArgs) Handles btnNuevaUnidadComercial.Click
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

    Private Sub btnActualizarUnidadComercial_Click(sender As Object, e As EventArgs) Handles btnActualizarUnidadComercial.Click
        If GridProductos.Table.CurrentRecord IsNot Nothing Then
            Dim idProducto = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
            EquivalenciaSelProducto(idProducto)
        End If
    End Sub

    Private Sub btnNuevoCatalogo_Click(sender As Object, e As EventArgs) Handles btnNuevoCatalogo.Click
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

    Private Sub btnNuevoPrecio_Click(sender As Object, e As EventArgs) Handles btnNuevoPrecio.Click
        Try
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


                    Else
                        MessageBox.Show("Indicar el catalogo de precios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Indicar la unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe seleccionar producto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    Private Sub ComboConsulta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboConsulta.SelectionChangeCommitted
        Cursor = Cursors.WaitCursor
        Dim itemsa As New itemSA
        Dim tablasa As New tablaDetalleSA

        ComboItem.DataSource = Nothing
        Select Case ComboConsulta.Text
            Case "CATEGORIA"
                Dim lstCategorias = itemsa.GetListaItemsPorTipo(New item With {.idEmpresa = Gempresas.IdEmpresaRuc, .tipo = TipoGrupoArticulo.CategoriaGeneral})
                ComboItem.DataSource = lstCategorias
                ComboItem.DisplayMember = "descripcion"
                ComboItem.ValueMember = "idItem"
                ComboItem.Visible = True
                txtFiltrar.Visible = False
            Case "SUB CATEGORIA"
                Dim lstCategorias = itemsa.GetListaItemsPorTipo(New item With {.idEmpresa = Gempresas.IdEmpresaRuc, .tipo = TipoGrupoArticulo.SubCategoriaGeneral})
                ComboItem.DataSource = lstCategorias
                ComboItem.DisplayMember = "descripcion"
                ComboItem.ValueMember = "idItem"
                ComboItem.Visible = True
                txtFiltrar.Visible = False
            Case "MARCA"
                Dim lstCategorias = itemsa.GetListaItemsPorTipo(New item With {.idEmpresa = Gempresas.IdEmpresaRuc, .tipo = TipoGrupoArticulo.Marca})
                ComboItem.DataSource = lstCategorias
                ComboItem.DisplayMember = "descripcion"
                ComboItem.ValueMember = "idItem"
                ComboItem.Visible = True
                txtFiltrar.Visible = False
            Case "TALLA"
                Dim lstTablas = tablasa.GetListaTablaDetalle(18, "1")
                ComboItem.DataSource = lstTablas
                ComboItem.DisplayMember = "descripcion"
                ComboItem.ValueMember = "codigoDetalle"
                ComboItem.Visible = True
                txtFiltrar.Visible = False
            Case "COLOR"
                Dim lstTablas = tablasa.GetListaTablaDetalle(19, "1")
                ComboItem.DataSource = lstTablas
                ComboItem.DisplayMember = "descripcion"
                ComboItem.ValueMember = "codigoDetalle"
                ComboItem.Visible = True
                txtFiltrar.Visible = False
            Case "PESO"
                ComboItem.Visible = False
                txtFiltrar.Visible = True
            Case Else
                ComboItem.Visible = False
                txtFiltrar.Visible = True
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub ComboItem_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            GetProductos()
        End If
    End Sub

    Private Sub btnInactivar_Click(sender As Object, e As EventArgs) Handles btnInactivar.Click
        Dim r As Record = GridProductos.Table.CurrentRecord



        If r IsNot Nothing Then
            Dim idProducto = Integer.Parse(r.GetValue("idproducto"))

            CambiarEstado("I")



        Else
            MessageBox.Show("Seleccione un producto válido", "Seleccinar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ' End If
        End If



    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
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

    Private Sub BunifuFlatButton10_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton10.Click
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
            Dim r As Record = GridProductos.Table.CurrentRecord
            If r Is Nothing Then Exit Sub

            Dim uc As Record = GridEquivalencia.Table.CurrentRecord
            If uc Is Nothing Then Exit Sub

            Dim f As New FormCatalogoUnidadComercial(Me)
            f.TextProducto.Tag = r.GetValue("idproducto")
            f.TextProducto.Text = r.GetValue("producto")
            f.TextUnidadComercial.Text = uc.GetValue("unidadcomercial")
            f.TextUnidadComercial.Tag = Integer.Parse(uc.GetValue("IDEQ"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class

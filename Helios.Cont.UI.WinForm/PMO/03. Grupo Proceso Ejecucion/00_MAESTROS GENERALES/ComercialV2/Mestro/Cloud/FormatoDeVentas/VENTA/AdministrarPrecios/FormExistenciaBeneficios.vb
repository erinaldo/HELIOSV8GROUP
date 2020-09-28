Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Helios.Cont.Presentation.WinForm

Public Class FormExistenciaBeneficios
#Region "Attributes"
    Public listaProductos As List(Of detalleitems)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridBlack(GridProductos, False)
        FormatoGridBlack(GridEquivalencia, False)
        FormatoGridBlack(GridBeneficioImporte, False)
        FormatoGridBlack(GridBeneficioVolumen, False)
        FormatoGridBlack(GridPrecioProducto, False)
        FormatoGrid(GridProductos)
        FormatoGrid(GridEquivalencia)
        FormatoGrid(GridBeneficioImporte)
        FormatoGrid(GridPrecioProducto)
        FormatoGrid(GridBeneficioVolumen)
        GridBeneficioVolumen.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GridProductos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GridEquivalencia.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GridBeneficioImporte.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GridPrecioProducto.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        GroupBar1.BorderStyle = BorderStyle.None
        GetCombos()
        GridEquivalencia.TableDescriptor.Columns("contenidoneto").Appearance.AnyRecordFieldCell.TextColor = Color.Black
        Centrar(Me)
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

    Private Sub BeneficiosSelUnidadComercial(idEquivalencia As Integer, idProducto As Integer)
        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        Dim equivalencias = Productos.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

        If equivalencias IsNot Nothing Then
            Dim ListaBeneficios = equivalencias.detalleitemequivalencia_beneficio.Where(Function(o) o.tipoafectacion = "IMPORTE").ToList

            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("beneficio")
            dt.Columns.Add("tipo")
            dt.Columns.Add("campoAfecto")
            dt.Columns.Add("valorEvaluado")
            dt.Columns.Add("valorConversion")
            dt.Columns.Add("beneficiofinal")

            For Each i In ListaBeneficios
                dt.Rows.Add(i.beneficio_id, i.beneficio_detalle, i.tipobeneficio, i.tipoafectacion, i.valor_evaluado.GetValueOrDefault, i.valor_conversion, i.valor_beneficio.GetValueOrDefault)
            Next
            GridBeneficioImporte.DataSource = dt
        End If
    End Sub

    Private Sub BeneficiosSelUnidadComercialCantidades(idEquivalencia As Integer, idProducto As Integer)
        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        Dim equivalencias = Productos.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

        If equivalencias IsNot Nothing Then
            Dim ListaBeneficios = equivalencias.detalleitemequivalencia_beneficio.Where(Function(o) o.tipoafectacion = "CANTIDAD").ToList

            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("beneficio")
            dt.Columns.Add("tipo")
            dt.Columns.Add("campoAfecto")
            dt.Columns.Add("valorEvaluado")
            dt.Columns.Add("valorConversion")
            dt.Columns.Add("beneficiofinal")

            For Each i In ListaBeneficios
                dt.Rows.Add(i.beneficio_id, i.beneficio_detalle, i.tipobeneficio, i.tipoafectacion, i.valor_evaluado.GetValueOrDefault, i.valor_conversion, i.valor_beneficio.GetValueOrDefault)
            Next
            GridBeneficioVolumen.DataSource = dt
        End If
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
                GridBeneficioImporte.DataSource = dt
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

    Private Sub EquivalenciaSelProducto(idProducto As Integer)
        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        Dim equivalencias = Productos.detalleitem_equivalencias.ToList

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
        GridBeneficioImporte.Table.Records.DeleteAll()
        GridPrecioProducto.Table.Records.DeleteAll()

        For Each i In listaProductos

            If i.detalleitem_equivalencias IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
                dt.Rows.Add(
                    i.idItem,
                    i.origenProducto,
                    i.codigodetalle,
                    i.codigo,
                    i.descripcionItem,
                    i.unidad1,
                    If(i.detalleitem_equivalencias IsNot Nothing, i.detalleitem_equivalencias.FirstOrDefault.detalle, ""),
                    i.tipoExistencia,
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
                    i.tipoExistencia,
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

    Private Sub EditarPrecio(r As Record)
        Dim precioSA As New detalleitemequivalencia_preciosSA

        '.rango_final = Decimal.Parse(r.GetValue("rangofin")),
        'Dim obj As New detalleitemequivalencia_precios With
        '               {
        '               .Action = BaseBE.EntityAction.UPDATE,
        '               .idCatalogo = ComboCatalogoPrecios.SelectedValue,
        '               .precio_id = Integer.Parse(r.GetValue("id")),
        '               .rango_inicio = Decimal.Parse(r.GetValue("rangoinicio")),
        '               .equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ")),
        '               .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")),
        '               .precioCode = r.GetValue("tipoprecio"),
        '               .precio = Decimal.Parse(r.GetValue("PrecioContado")),
        '               .precioUSD = Decimal.Parse(r.GetValue("PrecioContadoUSD")),
        '               .precioCredito = Decimal.Parse(r.GetValue("PrecioCredito")),
        '               .precioCreditoUSD = Decimal.Parse(r.GetValue("PrecioCreditoUSD")),
        '               .usuarioActualizacion = usuario.IDUsuario,
        '               .fechaActualizacion = Date.Now
        '}
        'precioSA.PrecioEquivalenciaSave(obj)

        Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
        Dim equivalencias = Productos.detalleitem_equivalencias.ToList
        Dim OBJEquivalencia = equivalencias.Where(Function(e) e.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))).SingleOrDefault

        'If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
        '    Dim ObjCatalogo = OBJEquivalencia.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CInt(ComboCatalogoPrecios.SelectedValue)).SingleOrDefault

        '    Dim listaPrecios = ObjCatalogo.detalleitemequivalencia_precios.ToList

        '    Dim objPrecio = listaPrecios.Where(Function(p) p.precio_id = obj.precio_id).SingleOrDefault
        '    objPrecio.precioCode = obj.precioCode
        '    objPrecio.precio = obj.precio
        '    objPrecio.precioUSD = obj.precioUSD
        '    objPrecio.precioCredito = obj.precioCredito
        '    objPrecio.precioCreditoUSD = obj.precioCreditoUSD
        '    objPrecio.rango_inicio = obj.rango_inicio
        '    'objPrecio.rango_final = obj.rango_final
        'End If

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
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                            PreciosSelProducto(idProducto)

                            EquivalenciaSelProducto(idProducto)
                            PreciosSelProducto(idProducto)
                        Else
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

    Private Sub GridEquivalencia_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridEquivalencia.TableControlCellClick
        Dim r As Record = GridEquivalencia.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridEquivalencia.Table.Records.Count > 0 Then
                GridBeneficioImporte.Table.Records.DeleteAll()
                Dim idEQ = Integer.Parse(r.GetValue("IDEQ"))
                Dim RecProducto = GridProductos.Table.CurrentRecord

                BeneficiosSelUnidadComercial(idEQ, Integer.Parse(RecProducto.GetValue("idproducto")))
                BeneficiosSelUnidadComercialCantidades(idEQ, Integer.Parse(RecProducto.GetValue("idproducto")))
                'PreciosSelEquivalencia(idEQ, Integer.Parse(RecProducto.GetValue("idproducto")))
            End If
        End If
    End Sub

    Private Sub GridProductos_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridProductos.TableControlCellClick
        Dim r As Record = GridProductos.Table.CurrentRecord
        If r IsNot Nothing Then
            GridEquivalencia.Table.Records.DeleteAll()
            GridBeneficioImporte.Table.Records.DeleteAll()

            If GridProductos.Table.Records.Count > 0 Then
                Dim idProducto = Integer.Parse(r.GetValue("idproducto"))
                EquivalenciaSelProducto(idProducto)
                PreciosSelProducto(idProducto)
            End If
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridEquivalencia.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridEquivalencia.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "detalle" Or style.TableCellIdentity.Column.Name = "fraccion" _
                    Or style.TableCellIdentity.Column.Name = "unidadcomercial" Then

                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            If text.Trim.Length > 0 Then
                                If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
                                    EditarEquivalencia(GridEquivalencia.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If

                ElseIf style.TableCellIdentity.Column.Name = "contenidoneto" Then

                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText
                            Dim r = GridEquivalencia.Table.CurrentRecord
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
                                        EditarEquivalencia(r)
                                        Exit Sub
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
                                    EditarEquivalencia(GridEquivalencia.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If

                ElseIf style.TableCellIdentity.Column.Name = "contenido" Then

                    'If cc.Renderer IsNot Nothing Then

                    '    If e.TableControl.Model.Modified = True Then
                    '        Dim text As String = cc.Renderer.ControlText

                    '        If text.Trim.Length > 0 Then
                    '            If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then

                    '                Dim contenido = CDec(cc.Renderer.ControlText)
                    '                Dim result = 1 / contenido
                    '                GridEquivalencia.Table.CurrentRecord.SetValue("fraccion", result)

                    '                EditarEquivalencia(GridEquivalencia.Table.CurrentRecord)
                    '            End If
                    '            'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                    '        End If
                    '    End If
                    'End If

                ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
                    'If cc.Renderer IsNot Nothing Then
                    '    Dim text As String = cc.Renderer.ControlText

                    '    If text.Trim.Length > 0 Then
                    '        If GridCompra.Table.CurrentRecord IsNot Nothing Then
                    '            GetCalculoItem(GridCompra.Table.CurrentRecord)
                    '            EditarItemVenta(GridCompra.Table.CurrentRecord)
                    '            '   FormPurchase.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
                    '        End If
                    '        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
                    '    End If
                    'End If
                End If
            End If
        End If
        'Dim r As Record = GridEquivalencia.Table.CurrentRecord
        'If r IsNot Nothing Then

        'End If
    End Sub

    Private Sub GridPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridBeneficioImporte.TableControlCellClick

    End Sub

    Private Sub GridPrecios_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridBeneficioImporte.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridBeneficioImporte.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                Select Case style.TableCellIdentity.Column.Name
                    Case "rangoinicio", "rangofin", "tipoprecio", "PrecioContado", "PrecioCredito", "PrecioContadoUSD", "PrecioCreditoUSD"
                        If cc.Renderer IsNot Nothing Then

                            If e.TableControl.Model.Modified = True Then
                                Dim text As String = cc.Renderer.ControlText

                                If text.Trim.Length > 0 Then
                                    If GridBeneficioImporte.Table.CurrentRecord IsNot Nothing Then
                                        EditarPrecio(GridBeneficioImporte.Table.CurrentRecord)
                                    End If
                                    'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                End If
                            End If
                        End If
                End Select

                'If style.TableCellIdentity.Column.Name = "detalle" Or style.TableCellIdentity.Column.Name = "fraccion" Then
                '    If cc.Renderer IsNot Nothing Then

                '        If e.TableControl.Model.Modified = True Then
                '            Dim text As String = cc.Renderer.ControlText

                '            If text.Trim.Length > 0 Then
                '                If GridPrecios.Table.CurrentRecord IsNot Nothing Then
                '                    EditarPrecio(GridPrecios.Table.CurrentRecord)
                '                End If
                '                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                '            End If
                '        End If
                '    End If


                'ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
                '    'If cc.Renderer IsNot Nothing Then
                '    '    Dim text As String = cc.Renderer.ControlText

                '    '    If text.Trim.Length > 0 Then
                '    '        If GridCompra.Table.CurrentRecord IsNot Nothing Then
                '    '            GetCalculoItem(GridCompra.Table.CurrentRecord)
                '    '            EditarItemVenta(GridCompra.Table.CurrentRecord)
                '    '            '   FormPurchase.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
                '    '        End If
                '    '        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
                '    '    End If
                '    'End If
                'End If
            End If
        End If
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

                'If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
                '    Dim objCatalogo = OBJEquivalencia.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = ComboCatalogoPrecios.SelectedValue).SingleOrDefault

                '    Dim listaPrecios = objCatalogo.detalleitemequivalencia_precios.ToList

                '    Dim obj As New detalleitemequivalencia_precios With
                '    {
                '    .equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ")),
                '    .codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))
                '}

                '    Dim f As New FormAddPrecioEquivalencia
                '    f.objEntiad = obj
                '    f.Label4.Text = "Agregar precio"
                '    f.TipoEntidad = "PRECIO"
                '    f.StartPosition = FormStartPosition.CenterParent
                '    f.ShowDialog(Me)
                '    If f.Tag IsNot Nothing Then
                '        Dim c = CType(f.Tag, detalleitemequivalencia_precios)
                '        objCatalogo.detalleitemequivalencia_precios.Add(c)
                '        PreciosSelCatalogo(c.equivalencia_id, c.idCatalogo, c.codigodetalle)
                '    End If
                'End If
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

    Private Sub GridPrecios_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridBeneficioImporte.TableControlDrawCell
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

    Private Sub GridPrecios_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridBeneficioImporte.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Try
            If e.Inner.ColIndex = 9 Then
                If GridProductos.Table.CurrentRecord IsNot Nothing Then
                    If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
                        If MessageBox.Show("Desea eliminar el precio seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim idPrecio = GridBeneficioImporte.TableModel(e.Inner.RowIndex, 1).CellValue

                            'Dim EQ = ListaEquivalencia.Where(Function(o) o.IDGUI = idEquivalencia).Single
                            precioSA.PrecioEquivalenciaSave(New detalleitemequivalencia_precios With
                                                            {
                                                            .Action = BaseBE.EntityAction.DELETE,
                                                            .precio_id = idPrecio
                                                            })


                            Dim Productos = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                            Dim equivalencias = Productos.detalleitem_equivalencias.ToList
                            Dim OBJEquivalencia = equivalencias.Where(Function(eq) eq.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))).SingleOrDefault

                            'If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
                            '    Dim ObjCatalogo = OBJEquivalencia.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = ComboCatalogoPrecios.SelectedValue).SingleOrDefault

                            '    Dim listaPrecios = ObjCatalogo.detalleitemequivalencia_precios.ToList

                            '    Dim objPrecio = ObjCatalogo.detalleitemequivalencia_precios.Where(Function(p) p.precio_id = idPrecio).SingleOrDefault

                            '    ObjCatalogo.detalleitemequivalencia_precios.Remove(objPrecio)

                            '    PreciosSelCatalogo(Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ")), CInt(ComboCatalogoPrecios.SelectedValue), Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto")))
                            'End If
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

    Private Sub ADDBeneficioItem(c As detalleitemequivalencia_beneficio)
        Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = c.codigodetalle).SingleOrDefault
        Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = c.equivalencia_id).SingleOrDefault

        equivalenciaOBJ.detalleitemequivalencia_beneficio.Add(c)
        BeneficiosSelUnidadComercial(equivalenciaOBJ.equivalencia_id, productoOBJ.codigodetalle)
        '   CatalogoPreciosSelEquivalencia(equivalenciaOBJ.equivalencia_id, productoOBJ.codigodetalle)
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        Dim r As Record = GridEquivalencia.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim RecProducto = GridProductos.Table.CurrentRecord
            If RecProducto IsNot Nothing Then
                Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = RecProducto.GetValue("idproducto")).SingleOrDefault
                Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(d) d.equivalencia_id = r.GetValue("IDEQ")).SingleOrDefault

                If ToggleBeneficio.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                    'MsgBox("Cantidad")
                    Dim f As New FormAddBeneficioProducto

                    f.GetComboMotivo("IMPORTE")
                    f.comboMotivo.Text = "Por importe de consumo"
                    'f.comboMotivo.Enabled = False
                    f.ComboAtributoAfectado.Text = "IMPORTE"
                    f.ComboAtributoAfectado.Enabled = False
                    'If equivalenciaOBJ.detalleitemequivalencia_beneficio IsNot Nothing Then
                    '    f.TextNombreCatalogo.Text = $"Lista - {equivalenciaOBJ.detalleitemequivalencia_catalogos.Count}"
                    'Else
                    '    f.TextNombreCatalogo.Text = $"Lista - 1"
                    'End If
                    'f.CodigoEquivalencia = CInt(r.GetValue("IDEQ"))
                    'f.CodigoProducto = Integer.Parse(RecProducto.GetValue("idproducto"))
                    f.objEntiad = equivalenciaOBJ
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, detalleitemequivalencia_beneficio)
                        ADDBeneficioItem(c)
                    End If
                    'MsgBox("Importe")

                ElseIf ToggleBeneficio.ToggleState = ToggleButton2.ToggleButtonState.OFF Then



                    Dim f As New FormAddBeneficioProducto

                    'f.comboMotivo.Enabled = False
                    f.GetComboMotivo("CANTIDAD")
                    f.comboMotivo.Text = "Por volumen de compras"
                    f.ComboAtributoAfectado.Text = "CANTIDAD"
                    f.ComboAtributoAfectado.Enabled = False
                    'If equivalenciaOBJ.detalleitemequivalencia_beneficio IsNot Nothing Then
                    '    f.TextNombreCatalogo.Text = $"Lista - {equivalenciaOBJ.detalleitemequivalencia_catalogos.Count}"
                    'Else
                    '    f.TextNombreCatalogo.Text = $"Lista - 1"
                    'End If
                    'f.CodigoEquivalencia = CInt(r.GetValue("IDEQ"))
                    'f.CodigoProducto = Integer.Parse(RecProducto.GetValue("idproducto"))
                    f.objEntiad = equivalenciaOBJ
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, detalleitemequivalencia_beneficio)
                        ADDBeneficioItem(c)
                    End If
                End If



            Else
                MessageBox.Show("Indicar un producto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Indicar una unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        If GridBeneficioImporte.Table.CurrentRecord IsNot Nothing Then
            Dim r As Record = GridEquivalencia.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim RecProducto = GridProductos.Table.CurrentRecord
                If RecProducto IsNot Nothing Then
                    Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = RecProducto.GetValue("idproducto")).SingleOrDefault
                    Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(eq) eq.equivalencia_id = r.GetValue("IDEQ")).SingleOrDefault
                    Dim objSelBeneficio = equivalenciaOBJ.detalleitemequivalencia_beneficio.Where(Function(o) o.beneficio_id = Integer.Parse(GridBeneficioImporte.Table.CurrentRecord.GetValue("id"))).SingleOrDefault

                    Dim f As New FormAddBeneficioProducto(objSelBeneficio)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, detalleitemequivalencia_beneficio)
                        EDITBeneficioItem(c)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        If GridBeneficioImporte.Table.CurrentRecord IsNot Nothing Then
            Dim r As Record = GridEquivalencia.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim RecProducto = GridProductos.Table.CurrentRecord
                If RecProducto IsNot Nothing Then

                    If MessageBox.Show("Eliminar el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = RecProducto.GetValue("idproducto")).SingleOrDefault
                        Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(eq) eq.equivalencia_id = r.GetValue("IDEQ")).SingleOrDefault
                        Dim objSelBeneficio = equivalenciaOBJ.detalleitemequivalencia_beneficio.Where(Function(o) o.beneficio_id = Integer.Parse(GridBeneficioImporte.Table.CurrentRecord.GetValue("id"))).SingleOrDefault

                        DELETEBeneficioItem(objSelBeneficio)
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub EDITBeneficioItem(c As detalleitemequivalencia_beneficio)
        Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = c.codigodetalle).SingleOrDefault
        Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = c.equivalencia_id).SingleOrDefault

        Dim objSelBeneficio = equivalenciaOBJ.detalleitemequivalencia_beneficio.Where(Function(o) o.beneficio_id = c.beneficio_id).SingleOrDefault

        objSelBeneficio.beneficio_detalle = c.beneficio_detalle
        objSelBeneficio.tipobeneficio = c.tipobeneficio
        objSelBeneficio.tipoafectacion = c.tipoafectacion
        objSelBeneficio.valor_evaluado = c.valor_evaluado
        objSelBeneficio.valor_beneficio = c.valor_beneficio
        objSelBeneficio.lote_id = c.lote_id
        objSelBeneficio.estado = 1
        objSelBeneficio.usuarioActualizacion = usuario.IDUsuario
        objSelBeneficio.fechaActualizacion = Date.Now
        '   CatalogoPreciosSelEquivalencia(equivalenciaOBJ.equivalencia_id, productoOBJ.codigodetalle)
        BeneficiosSelUnidadComercial(equivalenciaOBJ.equivalencia_id, productoOBJ.codigodetalle)
    End Sub

    Private Sub FormExistenciaBeneficios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.GridBeneficioImporte.TableDescriptor.AllowEdit = False
    End Sub

    Private Sub ToggleBeneficio_Click(sender As Object, e As EventArgs) Handles ToggleBeneficio.Click

    End Sub

    Private Sub DELETEBeneficioItem(c As detalleitemequivalencia_beneficio)
        Dim beneficioSA As New detalleitemequivalencia_beneficioSA
        Dim productoOBJ = listaProductos.Where(Function(p) p.codigodetalle = c.codigodetalle).SingleOrDefault
        Dim equivalenciaOBJ = productoOBJ.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = c.equivalencia_id).SingleOrDefault

        Dim objSelBeneficio = equivalenciaOBJ.detalleitemequivalencia_beneficio.Where(Function(o) o.beneficio_id = c.beneficio_id).SingleOrDefault

        objSelBeneficio.Action = BaseBE.EntityAction.DELETE
        objSelBeneficio.beneficio_detalle = c.beneficio_detalle
        objSelBeneficio.tipobeneficio = c.tipobeneficio
        objSelBeneficio.tipoafectacion = c.tipoafectacion
        objSelBeneficio.valor_evaluado = c.valor_evaluado
        objSelBeneficio.valor_beneficio = c.valor_beneficio
        objSelBeneficio.lote_id = c.lote_id
        objSelBeneficio.estado = 1
        objSelBeneficio.usuarioActualizacion = usuario.IDUsuario
        objSelBeneficio.fechaActualizacion = Date.Now
        '   CatalogoPreciosSelEquivalencia(equivalenciaOBJ.equivalencia_id, productoOBJ.codigodetalle)
        equivalenciaOBJ.detalleitemequivalencia_beneficio.Remove(objSelBeneficio)
        beneficioSA.BeneficioSave(objSelBeneficio)
        BeneficiosSelUnidadComercial(equivalenciaOBJ.equivalencia_id, productoOBJ.codigodetalle)
    End Sub

    Private Sub ToggleBeneficio_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleBeneficio.ButtonStateChanged
        If ToggleBeneficio.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            'MsgBox("Cantidad")
            TabControl1.SelectTab(1)

        ElseIf ToggleBeneficio.ToggleState = ToggleButton2.ToggleButtonState.OFF Then


            'MsgBox("Importe")
            TabControl1.SelectTab(0)
        End If
    End Sub
#End Region

End Class
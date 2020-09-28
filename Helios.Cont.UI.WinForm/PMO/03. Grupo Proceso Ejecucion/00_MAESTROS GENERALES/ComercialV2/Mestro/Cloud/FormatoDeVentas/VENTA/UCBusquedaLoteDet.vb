Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class UCBusquedaLoteDet

#Region "Atributos"

    Public Property UCEstructuraCabeceraVenta As UCEstructuraCabeceraVentaV2
    Private UCPreciosCanastaVenta As UCPreciosCanastaVenta

    Public Property listaCaracteristicas As New List(Of caracteristicaItem)

#End Region

#Region "Constructor"

    Sub New(cabezera As UCEstructuraCabeceraVentaV2)

        UCEstructuraCabeceraVenta = cabezera


        ' This call is required by the designer.
        InitializeComponent()

        UCPreciosCanastaVenta = New UCPreciosCanastaVenta With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCPreciosCanastaVenta)

        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCell


        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DisplayMember = "nombre_corto"
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.ValueMember = "idCatalogo"

        '     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive


        FormatoGridBlack(GridTotales, False)

        FormatoGridBlack(GridProductos, True)
        ' Add any initialization after the InitializeComponent() call.
        GridTotales.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        If txtFiltrar.Text.Trim.Length >= 2 Then
            Dim listaSA As New detalleitemsSA
            ' GetProductosWithInventario
            'GetProductosWithEquivalencias
            Dim dt As New DataTable
            dt.Columns.Add("destino")
            dt.Columns.Add("idItem")
            dt.Columns.Add("descripcion")
            dt.Columns.Add("cantidad")
            dt.Columns.Add("unidad")
            dt.Columns.Add("cboEquivalencias")
            dt.Columns.Add("cboPrecios")
            dt.Columns.Add("importeMn")
            dt.Columns.Add("idLote")
            dt.Columns.Add("idDetalleLote")
            dt.Columns.Add("DetalleAdicional")
            dt.Columns.Add("idSubClasificacion")
            dt.Columns.Add("numeracion")
            dt.Columns.Add("idCaracteristica")


            UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosLoteDetalle(New detalleitems With
                                                              {
                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                              .descripcionItem = txtFiltrar.Text
                                                              })


            'UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioLote(New detalleitems With
            '                                                  {
            '                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
            '                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
            '                                                  .descripcionItem = txtFiltrar.Text
            '                                                  })


            Dim StockTotal As Decimal = 0
            For Each i In UCEstructuraCabeceraVenta.listaProductos
                'dt.Rows.Add(
                '    i.origenProducto,
                '    i.codigodetalle,
                '    i.descripcionItem,
                '    i.composicion,
                '    i.unidad1)
                '   Dim catalagoDefault As Object

                Dim catalagoDefault = i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

                'StockTotal = 0
                'If CheckStock.Checked = True Then
                '    StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
                'End If

                'StockTotal,
                For Each j In i.totalesAlmacen

                    Dim origen = (From o In i.recursoCostoLote
                                  Where o.codigoLote = j.codigoLote).FirstOrDefault


                    dt.Rows.Add(
                  i.origenProducto,
                  i.codigodetalle,
                  i.descripcionItem,
                   j.cantidad,
                  i.unidad1,
                  i.detalleitem_equivalencias.FirstOrDefault.equivalencia_id,
                  If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing),
                  0,
                  j.codigoLote,
                  Nothing,
                  Nothing,
                  i.idItem.GetValueOrDefault,
                  Nothing,
                  i.idCaracteristica)

                Next

                '              If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precioCode, "0"),
                'If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precio, "0"))
            Next
            GridTotales.DataSource = dt
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        End If
    End Sub

    Private Sub GridTotales_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridTotales.TableControlCellClick
        Dim r As Record = GridTotales.Table.CurrentRecord
        If r IsNot Nothing Then

            If GridTotales.Table.Records.Count > 0 Then


                GridProductos.Table.Records.DeleteAll()


                'Dim r As Record = GridTotales.Table.CurrentRecord
                If r IsNot Nothing Then
                    If GridTotales.Table.Records.Count > 0 Then
                        Dim value As String = r.GetValue("idItem").ToString()

                        'lblIdItem.Text = value
                        'idSubClasificacion.Text = r.GetValue("idSubClasificacion").ToString()
                        'lblProducto.Text = r.GetValue("descripcion").ToString()
                        'lblidmodelo.Text = r.GetValue("idCaracteristica").ToString()

                        'lblidLote.Text = r.GetValue("idLote").ToString()

                        'Dim listaXLote = (From z In UCEstructuraCabeceraVenta.listaProductos
                        '                  Where z.codigodetalle = value).FirstOrDefault

                        btnlote.Text = r.GetValue("idLote").ToString()
                        lnlnameProducto.Text = r.GetValue("descripcion").ToString()
                        LLendarDetalle(value, r.GetValue("idLote").ToString(), r.GetValue("idCaracteristica").ToString(), r.GetValue("idSubClasificacion").ToString())




                    End If
                End If


            End If
        End If
    End Sub

#End Region

#Region "Metodos"

    Public Sub listaCamposModelo(idClas As Integer, idPadre As Integer)


        GridProductos.Table.Records.DeleteAll()


        Dim caracteristicasSA As New caracteristicaItemSA

        Dim item As New caracteristicaItem
        item.idPadre = idClas
        item.idSubClasificacion = idPadre
        item.tipo = "DET"

        Dim consulta = caracteristicasSA.listaCamposModelo(item)


        listaCaracteristicas = consulta


        Dim dt As New DataTable("Lista de productos ")

        dt.Columns.Add("Nº")
        dt.Columns.Add("idLote")
        dt.Columns.Add("idDetalleLote")
        For Each i In consulta

            'dgvDetalles.Table.AddNewRecord.SetCurrent()
            'dgvDetalles.Table.AddNewRecord.BeginEdit()
            'dgvDetalles.Table.CurrentRecord.SetValue("idCaracteristica", i.idCaracteristica)
            'dgvDetalles.Table.CurrentRecord.SetValue("campo", i.campo)
            'dgvDetalles.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
            'dgvDetalles.Table.AddNewRecord.EndEdit()
            dt.Columns.Add(i.campo)

        Next
        GridProductos.DataSource = dt


        ' detalleLotes(Label4.Text)






    End Sub

    Public Sub LLendarDetalle(idItem As String, idlote As String, idmodelo As String, idclas As String)

        GridProductos.Table.Records.DeleteAll()

        'If cboLotes.Text.Trim.Length > 0 Then



        Dim listaXLote = (From z In UCEstructuraCabeceraVenta.listaProductos
                          Where z.codigodetalle = idItem).FirstOrDefault

        Dim listaXLote2 = (From x In listaXLote.recursoCostoLote
                           Where x.codigoProducto = idItem And x.codigoLote = idlote).FirstOrDefault



        'listaCamposModelo(listaXLote2.idCaracteristica, idSubClasificacion.Text)
        'listaCamposModelo(lblidmodelo.Text, idSubClasificacion.Text)
        listaCamposModelo(idmodelo, idclas)

        'For Each i In listaXLote2


        'Dim cantidades2 = (From i In listaXLote2.LoteDetalle
        '                   Group i By
        '                      i.numeracion, i.idDetalleLote
        '                  Into g = Group
        '                   Select New With {
        '                      .numeracion = numeracion,
        '                      .idDetalleLote = idDetalleLote}).Distinct.ToList

        Dim cantidades = (From i In listaXLote2.LoteDetalle
                          Select
                              i.numeracion Distinct).ToList

        'Dim cantidades2 = (listaXLote2.LoteDetalle(Function(x) x.numeracion, X.idDetalleLote).groupby(Function(o) o.numeracion, X.idDetalleLote).tolist




        For Each i In cantidades

            Dim item = (From h In listaXLote2.LoteDetalle
                        Where h.numeracion = i).ToList


            GridProductos.Table.AddNewRecord.SetCurrent()
            GridProductos.Table.AddNewRecord.BeginEdit()

            GridProductos.Table.CurrentRecord.SetValue("Nº", i)
            GridProductos.Table.CurrentRecord.SetValue("idLote", idlote)
            GridProductos.Table.CurrentRecord.SetValue("idDetalleLote", item.First.idDetalleLote)

            For Each x In item
                GridProductos.Table.CurrentRecord.SetValue(x.campo, x.descripcion)
            Next

            GridProductos.Table.AddNewRecord.EndEdit()


        Next

        GridProductos.TableDescriptor.Columns("idLote").Width = 0
        GridProductos.TableDescriptor.Columns("idDetalleLote").Width = 0


        'For Each j In listaXLote2.LoteDetalle

        '    sdfsdf


        '    GridProductos.Table.AddNewRecord.SetCurrent()
        '    GridProductos.Table.AddNewRecord.BeginEdit()

        '    GridProductos.Table.CurrentRecord.SetValue("conteo", 1)
        '    GridProductos.Table.CurrentRecord.SetValue("idLote", j.codigoLote)
        '    GridProductos.Table.CurrentRecord.SetValue("idDetalleLote", j.idDetalleLote)
        '    GridProductos.Table.CurrentRecord.SetValue("marca", j.marca)
        '    GridProductos.Table.CurrentRecord.SetValue("color", j.color)
        '    GridProductos.Table.CurrentRecord.SetValue("modelo", j.modelo)
        '    GridProductos.Table.CurrentRecord.SetValue("codigo", j.codigo)
        '    GridProductos.Table.CurrentRecord.SetValue("año", j.año)

        '    GridProductos.Table.AddNewRecord.EndEdit()
        'Next



        'Next
        'End If

    End Sub

    Private Sub GridTotales_KeyDown(sender As Object, e As KeyEventArgs) Handles GridTotales.KeyDown

    End Sub


    Private Sub GridTotales_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridTotales.TableControlKeyDown
        Try
            Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
            If cc.RowIndex > -1 Then
                If e.Inner.KeyCode = Keys.Up Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)
                        '                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        'Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                        If currenrecord IsNot Nothing Then
                            Dim value As String = currenrecord.GetValue("idItem").ToString()
                            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                            Dim idEquiva = currenrecord.GetValue("cboEquivalencias").ToString()

                            If idEquiva.Trim.Length > 0 Then
                                Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                Dim idCat = currenrecord.GetValue("cboPrecios").ToString()
                                If idCat.Trim.Length > 0 Then
                                    Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault
                                    UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                    If OBJCatalog IsNot Nothing Then

                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)

                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                    End If
                                Else
                                End If
                            End If
                        End If

                    End If
                ElseIf e.Inner.KeyCode = Keys.Down Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex + 1, cc.ColIndex), GridTableCellStyleInfo)
                        If style.TableCellIdentity IsNot Nothing Then
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            ' Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                            '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                            If currenrecord IsNot Nothing Then
                                Dim value As String = currenrecord.GetValue("idItem").ToString()
                                Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                                Dim idEquiva = currenrecord.GetValue("cboEquivalencias").ToString()

                                If idEquiva.Trim.Length > 0 Then
                                    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                    Dim idCat = currenrecord.GetValue("cboPrecios").ToString()
                                    If idCat.Trim.Length > 0 Then
                                        Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                                        UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                        If OBJCatalog IsNot Nothing Then
                                            Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                            UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                        End If

                                    Else
                                    End If
                                End If
                            End If
                        End If

                    End If

                Else
                    If cc IsNot Nothing Then
                        'cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                        'Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        'Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))

                        If currenrecord IsNot Nothing Then
                            Dim value As String = currenrecord.GetValue("idItem").ToString()
                            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                            Dim idEquiva = currenrecord.GetValue("cboEquivalencias").ToString()

                            If idEquiva.Trim.Length > 0 Then
                                Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                Dim idCat = currenrecord.GetValue("cboPrecios").ToString()
                                If idCat.Trim.Length > 0 Then
                                    Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault
                                    UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                    If OBJCatalog IsNot Nothing Then
                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                    End If
                                Else
                                End If
                            End If
                        End If


                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function AddItemNuevaListaPrecios(be As detalleitemequivalencia_precios, rangoMinimo As Decimal?, max As Decimal) As detalleitemequivalencia_precios

        AddItemNuevaListaPrecios = New detalleitemequivalencia_precios
        AddItemNuevaListaPrecios = be
        AddItemNuevaListaPrecios.rango_inicio = rangoMinimo
        AddItemNuevaListaPrecios.rango_final = max
    End Function

    Private Function GetCalculoPrecioVenta(cantidadVenta As Decimal, idProducto As Integer, idEquivalencia As Integer, idCatalogo As Integer) As Decimal
        GetCalculoPrecioVenta = 0
        Dim objProducto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        If objProducto IsNot Nothing Then
            Dim listaEquivalencias = objProducto.detalleitem_equivalencias.ToList

            Dim objEQ = listaEquivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

            Dim catalogoOBJ = objEQ.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault

            If catalogoOBJ IsNot Nothing Then

                Dim ListaPrecios = catalogoOBJ.detalleitemequivalencia_precios.ToList
                Dim listaDeRangos = ConvertirPreciosArangos(ListaPrecios)

                If listaDeRangos.Count = 0 Or listaDeRangos Is Nothing Then
                    Throw New Exception("El producto no tiene precios de venta asignados")
                End If

                For Each i In listaDeRangos
                    Dim rango_inicio = i.rango_inicio
                    Dim rango_fin = i.rango_final
                    If cantidadVenta >= rango_inicio AndAlso rango_fin = 0 Then
                        If UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text = "PRE VENTA" Then

                            Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
                                Case "NUEVO SOL"
                                    If i.precio.GetValueOrDefault > 0 Then
                                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                    Else
                                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                    End If

                                Case Else
                                    'DOLARES

                                    If i.precioUSD.GetValueOrDefault > 0 Then
                                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                    Else
                                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                    End If

                            End Select


                        Else

                            Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
                                Case "NUEVO SOL"
                                    Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                                        Case "CONTADO"
                                            If i.precio.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                            End If

                                        Case "CREDITO"
                                            If i.precioCredito.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
                                            End If
                                    End Select
                                Case Else
                                    'DOLARES
                                    Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                                        Case "CONTADO"
                                            If i.precioUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                            End If

                                        Case "CREDITO"
                                            If i.precioCreditoUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault / TmpTipoCambio
                                            End If
                                    End Select
                            End Select
                        End If
                        Exit Function
                    End If
                    If cantidadVenta >= rango_inicio AndAlso cantidadVenta <= rango_fin Then
                        If UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text = "PRE VENTA" Then

                            Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
                                Case "NUEVO SOL"
                                    If i.precio.GetValueOrDefault > 0 Then
                                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                    Else
                                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                    End If
                                Case Else
                                    'DOLARES

                                    If i.precioUSD.GetValueOrDefault > 0 Then
                                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                    Else
                                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                    End If
                            End Select


                        Else

                            Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
                                Case "NUEVO SOL"
                                    Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                                        Case "CONTADO"
                                            If i.precio.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                            End If

                                        Case "CREDITO"
                                            If i.precioCredito.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
                                            End If

                                    End Select
                                Case Else
                                    'DOLARES -----------------

                                    Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                                        Case "CONTADO"
                                            If i.precioUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                            End If

                                        Case "CREDITO"
                                            If i.precioCreditoUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault / TmpTipoCambio
                                            End If

                                    End Select
                            End Select


                        End If
                        Exit Function
                    End If
                Next
            Else
                Throw New Exception("Debe configurar los catálogos de precios!")
            End If
        End If
    End Function

    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("fraccion")


        dt.Columns(0).ColumnMapping = MappingType.Hidden

        For Each i In lista.Where(Function(o) o.estado = "A").ToList
            dt.Rows.Add(i.equivalencia_id, i.unidadComercial, i.fraccionUnidad)
        Next
        Return dt
    End Function

    Private Function GetCatalogoPrecios(lista As List(Of detalleitemequivalencia_catalogos)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("idCatalogo")
        dt.Columns.Add("nombre_corto")

        dt.Columns(0).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.idCatalogo, i.nombre_corto)
        Next

        'Dim dt As New DataTable
        'dt.Columns.Add("idCatalogo")
        'dt.Columns.Add("nombre_corto")
        'dt.Columns.Add("Cant.minima")
        'dt.Columns.Add("Al credito")
        'dt.Columns.Add("Al contado")
        'For Each i In lista
        '    dt.Rows.Add(i.idCatalogo, i.nombre_corto)
        '    For Each prec In i.detalleitemequivalencia_precios
        '        dt.Rows.Add(Nothing, Nothing, prec.rango_inicio, prec.precioCredito, prec.precio)
        '    Next
        'Next
        Return dt
    End Function

#End Region

    Private Function ConvertirPreciosArangos(lista As List(Of detalleitemequivalencia_precios)) As List(Of detalleitemequivalencia_precios)
        '   Dim ListaEntera = GetConverToListInteger(lista)

        ConvertirPreciosArangos = New List(Of detalleitemequivalencia_precios)

        Dim maxValor = lista.Max(Function(o) o.rango_inicio).GetValueOrDefault
        Dim max As Decimal = 0
        For index = 0 To lista.Count - 1
            Dim rangoMinimo = lista(index).rango_inicio
            If rangoMinimo = maxValor Then
                max = 0
            Else
                Dim max1 = lista(index + 1).rango_inicio.GetValueOrDefault
                If max1 <= 1 Then
                    max = lista(index + 1).rango_inicio.GetValueOrDefault - 0.01
                Else
                    max = lista(index + 1).rango_inicio.GetValueOrDefault - 1
                End If
            End If
            ConvertirPreciosArangos.Add(AddItemNuevaListaPrecios(lista(index), rangoMinimo, max))
        Next
    End Function

    Private Sub GridTotales_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridTotales.TableControlCurrentCellCloseDropDown
        Try
            Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
            cc.ConfirmChanges()

            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)


                If style.TableCellIdentity.Column.Name = "cboEquivalencias" Then

                    'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                    'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()


                    '  Dim CodigoEQ As String = cc.Renderer.ControlText
                    'Dim r As Record = GridTotales.Table.CurrentRecord
                    If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
                        cc.EndEdit()
                        '   Dim cc As GridCurrentCell = e.TableControl.CurrentCell
                        '   Dim cr As GridComboBoxCellRenderer = TryCast(cc.Renderer, GridComboBoxCellRenderer)

                        'If cc.Renderer.HasFocusControl IsNot Nothing Then
                        '    Console.WriteLine(cr.ListBoxPart.SelectedIndex)
                        'End If
                        Select Case cc.MoveToColIndex
                            Case 6

                                'Dim DetalleItemLote = style.TableCellIdentity.Table.CurrentRecord.GetValue("idDetalleLote").ToString
                                Dim DetalleItemLote = style.TableCellIdentity.Table.CurrentRecord.GetValue("numeracion").ToString

                                Dim Lote = style.TableCellIdentity.Table.CurrentRecord.GetValue("idLote").ToString

                                Dim DetalleAdicional = style.TableCellIdentity.Table.CurrentRecord.GetValue("DetalleAdicional").ToString

                                If DetalleItemLote = "" Then
                                    MessageBox.Show("Debe Seleccionar un Detalle Del Articulo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If

                                If e.Inner.PopupCloseType = Syncfusion.Windows.Forms.PopupCloseType.Canceled Then

                                ElseIf e.Inner.PopupCloseType = Syncfusion.Windows.Forms.PopupCloseType.Deactivated Then

                                ElseIf e.Inner.PopupCloseType = Syncfusion.Windows.Forms.PopupCloseType.Done Then
                                    Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
                                    Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias")

                                    Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

                                    Dim UnidadesLista = producto.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

                                    Dim Unidades = UnidadesLista.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault

                                    If Unidades Is Nothing Then
                                        MessageBox.Show("Indicar una unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If

                                    If Unidades.detalleitemequivalencia_catalogos IsNot Nothing Then
                                        If Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                                            Dim cataPredeterminado = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True AndAlso c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault

                                            If cataPredeterminado IsNot Nothing Then
                                                style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cataPredeterminado.idCatalogo)

                                            ElseIf Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                                                style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", Unidades.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                                            End If
                                        Else
                                            MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                    Else
                                        ' MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If

                                    Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
                                    Dim cat As detalleitemequivalencia_catalogos = Nothing

                                    If IsNumeric(idCatalogo) Then
                                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
                                    ElseIf idCatalogo.ToString.Trim.Length > 0 Then
                                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault

                                        Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                    Else
                                        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If



                                    If cat IsNot Nothing Then
                                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
                                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = cat.idCatalogo).SingleOrDefault

                                        Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                    Else
                                        MessageBox.Show("Identificar un catalogo de precios valido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Exit Sub
                                    End If


                                    Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)

                                    'Dim formCantidad As New FormAsignarCantidadVenta
                                    'formCantidad.StartPosition = FormStartPosition.CenterParent
                                    'formCantidad.ShowDialog(Me)
                                    'If formCantidad.Tag IsNot Nothing Then
                                    '    If IsNumeric(formCantidad.Tag) Then
                                    '        Dim inp = CDec(formCantidad.Tag) 'InputBox("Ingreser cantidad", "Atención", "")
                                    '        '   If inp IsNot Nothing Then
                                    '        If IsNumeric(inp) Then
                                    '            If (inp) > 0 Then

                                    '                Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), codiProducto, Unidades.equivalencia_id, cat.idCatalogo)

                                    '                If precioventaFormula <= 0 Then
                                    '                    MessageBox.Show("Precio de venta debe ser mayor a cero!", "Validar precio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    '                    Exit Sub
                                    '                End If
                                    '                precioVenta = precioventaFormula
                                    '                UCEstructuraCabeceraVenta.AgregarProductoLoteDetalle(inp, codiProducto, precioventaFormula, Unidades, cat.idCatalogo, DetalleItemLote, Lote, DetalleAdicional)
                                    '                UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
                                    '                GridTotales.Table.CurrentRecord.EndEdit()
                                    '                'Me.GridTotales.TableControl.CurrentCell.CloseDropDown(Syncfusion.Windows.Forms.PopupCloseType.Done)
                                    '                'Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                                    '                'Me.GridTotales.TableControl.CurrentCell.CloseDropDown(Syncfusion.Windows.Forms.PopupCloseType.Deactivated)
                                    '                Me.GridTotales.TableControl.CurrentCell.MoveTo(cc.RowIndex, 1, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                                    '                'GridTotales.Table.Records(GridTotales.Table.Records.Count - 1).SetCurrent()
                                    '                'GridTotales.Table.Records(GridTotales.Table.Records.Count - 1).BeginEdit()
                                    '                Me.ActiveControl = Me.GridTotales.TableControl
                                    '                GridTotales.WantTabKey = True
                                    '                txtFiltrar.Clear()
                                    '                txtFiltrar.Select()
                                    '                'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                                    '                'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
                                    '            Else
                                    '                MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    '                Me.Cursor = Cursors.Default
                                    '                Exit Sub
                                    '            End If
                                    '        Else
                                    '            MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    '            Me.Cursor = Cursors.Default
                                    '            Exit Sub
                                    '        End If
                                    '    End If
                                    'End If
                                    Dim inp = 1

                                    Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), codiProducto, Unidades.equivalencia_id, cat.idCatalogo)

                                    If precioventaFormula <= 0 Then
                                        MessageBox.Show("Precio de venta debe ser mayor a cero!", "Validar precio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Exit Sub
                                    End If
                                    precioVenta = precioventaFormula
                                    UCEstructuraCabeceraVenta.AgregarProductoLoteDetalle(inp, codiProducto, precioventaFormula, Unidades, cat.idCatalogo, DetalleItemLote, Lote, DetalleAdicional)
                                    UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
                                    GridTotales.Table.CurrentRecord.EndEdit()
                                    'Me.GridTotales.TableControl.CurrentCell.CloseDropDown(Syncfusion.Windows.Forms.PopupCloseType.Done)
                                    'Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                                    'Me.GridTotales.TableControl.CurrentCell.CloseDropDown(Syncfusion.Windows.Forms.PopupCloseType.Deactivated)
                                    Me.GridTotales.TableControl.CurrentCell.MoveTo(cc.RowIndex, 1, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                                    'GridTotales.Table.Records(GridTotales.Table.Records.Count - 1).SetCurrent()
                                    'GridTotales.Table.Records(GridTotales.Table.Records.Count - 1).BeginEdit()
                                    Me.ActiveControl = Me.GridTotales.TableControl
                                    GridTotales.WantTabKey = True
                                    txtFiltrar.Clear()
                                    txtFiltrar.Select()


                                End If


                            Case Else

                        End Select


                    End If
                ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
                    If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
                        cc.EndEdit()
                        Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
                        Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias")

                        Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

                        Dim Unidades = producto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault


                        Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
                        Dim cat As detalleitemequivalencia_catalogos = Nothing

                        If IsNumeric(idCatalogo) Then
                            cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
                        ElseIf idCatalogo.ToString.Trim.Length > 0 Then
                            cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault

                            Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                            UCPreciosCanastaVenta.GetDetallePrecios(lista)
                        Else
                            MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If

                        'If idCatalogo.ToString.Trim.Length > 0 Then
                        '    'cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
                        '    cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
                        'Else
                        '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '    Me.Cursor = Cursors.Default
                        '    Exit Sub
                        'End If

                        If cat IsNot Nothing Then
                            style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
                            cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = cat.idCatalogo).SingleOrDefault

                            Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                            UCPreciosCanastaVenta.GetDetallePrecios(lista)
                        Else

                        End If
                    End If


                    'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                    'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                ElseIf style.TableCellIdentity.Column.Name = "importeMn" Then

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar precios")
        End Try
    End Sub

    Private Sub GridTotales_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridTotales.TableControlCurrentCellKeyDown
        Try
            If e.Inner.KeyCode = Keys.Enter Then
                Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
                Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
                cc.ConfirmChanges()
                If cc.Renderer IsNot Nothing Then

                    If cc.ColIndex > -1 Then
                        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                        If style.TableCellIdentity.Column.Name = "cboEquivalenciasss" Then


                            cc.EndEdit()
                            e.TableControl.Table.EndEdit()
                            'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                            'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()

                            Dim equivalencia = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias") ' GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                            Dim CatalogoPrecio As Integer = 0 ' style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios") ' GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

                            Dim codiProducto As Integer = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
                            ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                            Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).SingleOrDefault ' GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

                            If eqLista.productoRestringido = True Then
                                If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If

                            Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                                If objEQ.detalleitemequivalencia_catalogos.Count > 0 Then
                                    Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

                                    If catalogPredeterminado IsNot Nothing Then
                                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                                        CatalogoPrecio = catalogPredeterminado.idCatalogo
                                    Else
                                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                                        CatalogoPrecio = objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo
                                    End If

                                    Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                                Else
                                    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            Else

                                MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Cursor = Cursors.Default
                                Exit Sub
                                'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                            End If

                            'Agregando Producto
                            '-----------------------------------------------------------------------------------------
                            '*******************************************************************************************
                            'If CatalogoPrecio.ToString.Trim.Length = 0 Then
                            '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Me.Cursor = Cursors.Default
                            '    Exit Sub
                            'End If


                            'Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                            '  Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                            'Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                            '   If inp IsNot Nothing Then
                            'If IsNumeric(inp) Then
                            'If (inp) > 0 Then

                            'Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), codiProducto, equivalencia, CatalogoPrecio)
                            'precioVenta = precioventaFormula

                            'UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, codiProducto, precioventaFormula, objEQ, CatalogoPrecio)
                            'UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)

                            'Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                            'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                            'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
                            'Else
                            ' MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '           Me.Cursor = Cursors.Default
                            '  Exit Sub
                            'End If
                            'Else
                            '   MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '  Me.Cursor = Cursors.Default
                            ' Exit Sub
                            'End If


                            '-------------------------------------------------------------------------------------------------------------------------------
                            '-------------------------------------------------------------------------------------------------------------------------------

                            'CODIGO OLD---------------------------------------------------------------------------------------------------------------------------
                            '-------------------------------------------------------------------------------------------------------------------------------
                            '-------------------------------------------------------------------------------------------------------------------------------


                            'Dim equivalencia = GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                            'Dim CatalogoPrecio = GridTotales.Table.CurrentRecord.GetValue("cboPrecios")
                            '' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                            'Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

                            'If eqLista.productoRestringido = True Then
                            '    If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            '        Me.Cursor = Cursors.Default
                            '        Exit Sub
                            '    End If
                            'End If

                            'Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            'Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            ''Agregando Producto
                            ''-----------------------------------------------------------------------------------------
                            ''*******************************************************************************************

                            'If CatalogoPrecio.ToString.Trim.Length = 0 Then
                            '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Me.Cursor = Cursors.Default
                            '    Exit Sub
                            'End If

                            'Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                            'Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                            'Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                            'If inp IsNot Nothing Then
                            '    If IsNumeric(inp) Then
                            '        If (inp) > 0 Then

                            '            Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                            '            precioVenta = precioventaFormula

                            '            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, CatalogoPrecio)
                            '            UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
                            '        Else
                            '            MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '            Me.Cursor = Cursors.Default
                            '            Exit Sub
                            '        End If
                            '    Else
                            '        MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '        Me.Cursor = Cursors.Default
                            '        Exit Sub
                            '    End If
                            'Else
                            '    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Me.Cursor = Cursors.Default
                            'End If


                            'End If
                        ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
                            If Me.GridTotales.Table.CurrentRecord IsNot Nothing Then
                                Dim equivalencia = GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                                Dim CatalogoPrecio = GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

                                If CatalogoPrecio.ToString.Trim.Length = 0 Then
                                    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If

                                If equivalencia.ToString.Trim.Length = 0 Then
                                    MessageBox.Show("Debe ingresar una equivalencia valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If


                                Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                                Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                                Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                                '   If inp IsNot Nothing Then
                                If IsNumeric(inp) Then
                                    If (inp) > 0 Then

                                        Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                                        precioVenta = precioventaFormula

                                        Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                                        Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                                        Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio)
                                        UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)

                                    Else
                                        MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                'Else
                                '    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                '    Me.Cursor = Cursors.Default
                                'End If
                            End If
                            Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                            Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                            'If Me.GridTotales.Table.CurrentRecord IsNot Nothing Then
                            '    Dim equivalencia = GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                            '    Dim CatalogoPrecio = GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

                            '    If CatalogoPrecio.ToString.Trim.Length = 0 Then
                            '        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '        Me.Cursor = Cursors.Default
                            '        Exit Sub
                            '    End If

                            '    If equivalencia.ToString.Trim.Length = 0 Then
                            '        MessageBox.Show("Debe ingresar una equivalencia valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '        Me.Cursor = Cursors.Default
                            '        Exit Sub
                            '    End If


                            '    Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                            '    Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                            '    Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                            '    If inp IsNot Nothing Then
                            '        If IsNumeric(inp) Then
                            '            If (inp) > 0 Then

                            '                Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                            '                precioVenta = precioventaFormula

                            '                Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                            '                Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            '                Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            '                UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, CatalogoPrecio)
                            '                UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
                            '            Else
                            '                MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '                Me.Cursor = Cursors.Default
                            '                Exit Sub
                            '            End If
                            '        Else
                            '            MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '            Me.Cursor = Cursors.Default
                            '            Exit Sub
                            '        End If
                            '    Else
                            '        MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '        Me.Cursor = Cursors.Default
                            '    End If
                            'End If
                            'ElseIf style.TableCellIdentity.Column.Name = "descripcion" Then
                            'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                            'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                        ElseIf style.TableCellIdentity.Column.Name = "descripcion" Then
                            Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                            'If Me.GridTotales.TableControl.CurrentCell.CloseDropDown(Syncfusion.Windows.Forms.PopupCloseType.Deactivated) Then
                            Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                            'End If
                        ElseIf style.TableCellIdentity.Column.Name = "cboEquivalencias" Then
                            Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                        ElseIf style.TableCellIdentity.Column.Name = "destino" Then
                            Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar!")
        End Try
    End Sub

    Private Sub GridTotales_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridTotales.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboEquivalencias" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim listaEquivalencias = prod.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

            '   If value = "a" Then
            e.Style.DataSource = GetEquivalencias(listaEquivalencias)
            e.Style.DisplayMember = "unidadComercial"
            e.Style.ValueMember = "equivalencia_id"
            'ElseIf value = "b" Then
            '    e.Style.DataSource = ZipCodes
            '    e.Style.DisplayMember = "City"
            '    e.Style.ValueMember = "Class"
            'ElseIf value = "c" Then
            '    e.Style.DataSource = Shippers
            '    e.Style.DisplayMember = "Shipper ID"
            '    e.Style.ValueMember = "Company Name"
            'End If
        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboPrecios" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim idEquiva = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cboEquivalencias").ToString()
            If idEquiva.Trim.Length > 0 Then
                Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                Dim listaPreciosVenta = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
                e.Style.DataSource = listaPreciosVenta
                e.Style.DisplayMember = "nombre_corto"
                e.Style.ValueMember = "idCatalogo"
            Else
                e.Style.DataSource = Nothing
                e.Style.DisplayMember = "nombre_corto"
                e.Style.ValueMember = "idCatalogo"
            End If
            'If idEquiva.Trim.Length > 0 Then
            '    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
            '    Dim listaPreciosVenta = GetPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
            '    e.Style.DataSource = listaPreciosVenta
            '    e.Style.DisplayMember = "precioCode"
            '    e.Style.ValueMember = "precio"
            'Else
            '    e.Style.DataSource = Nothing
            '    e.Style.DisplayMember = "precioCode"
            '    e.Style.ValueMember = "precio"
            'End If
        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "importeMn" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then


        End If
    End Sub

    Private Sub GridProductos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridProductos.TableControlCellClick

    End Sub

    Private Sub GridProductos_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridProductos.TableControlCellDoubleClick
        Dim DetalleAdicional As String = ""
        Dim r As Record = GridProductos.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridProductos.Table.Records.Count > 0 Then
                'Dim value As String = r.GetValue("idLote").ToString()

                Dim p As Record = GridTotales.Table.CurrentRecord
                If p IsNot Nothing Then
                    If GridTotales.Table.Records.Count > 0 Then
                        p.SetValue("idLote", r.GetValue("idLote").ToString())
                        p.SetValue("idDetalleLote", r.GetValue("idDetalleLote").ToString())
                        p.SetValue("numeracion", r.GetValue("Nº").ToString())

                        Dim cont As Integer = 0
                        For Each i In listaCaracteristicas
                            cont += 1
                            If cont = 1 Then
                                DetalleAdicional = i.campo & ": " & r.GetValue(i.campo).ToString()
                            ElseIf cont = listaCaracteristicas.Count Then
                                DetalleAdicional = DetalleAdicional & " - " & i.campo & ": " & r.GetValue(i.campo).ToString()
                            Else
                                DetalleAdicional = DetalleAdicional & " - " & i.campo & ": " & r.GetValue(i.campo).ToString()
                            End If

                        Next

                        'Dim DetalleAdicional = r.GetValue("color").ToString() & "-" & r.GetValue("marca").ToString() & "-" & r.GetValue("modelo").ToString()

                        p.SetValue("DetalleAdicional", DetalleAdicional)
                    End If
                End If


            End If
        End If
    End Sub
End Class

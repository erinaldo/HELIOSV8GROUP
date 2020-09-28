Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Imports Syncfusion.Windows.Forms
Imports System.Text.RegularExpressions

Public Class UCBusquedaSegmento

#Region "Atributos"

    Public Property UCEstructuraCabeceraVenta As UCEstructuraCabeceraVentaV2
    Private UCPreciosCanastaVenta As UCPreciosCanastaVenta
    Dim listaCategoriasItem As New List(Of item)

#End Region

#Region "Constructor"

    Sub New(ucVenta As UCEstructuraCabeceraVentaV2)

        ' This call is required by the designer.
        InitializeComponent()

        UCPreciosCanastaVenta = New UCPreciosCanastaVenta With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCPreciosCanastaVenta)
        'FormatoGridAvanzado(GridTotales, False, False, 9.0F)
        FormatoGridBlack(GridTotales, False)
        UCEstructuraCabeceraVenta = ucVenta
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


        'Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        'Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DisplayMember = "precioCode"
        'Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.ValueMember = "precio"
        ''     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
        'Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive

        'OrdenamientoGrid(GridTotales, False)
        GridTotales.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

    End Sub

#End Region

#Region "Metodos"
    Public Sub ListaCateriasItem()
        Dim categoriaSA As New itemSA
        ' categoriaSA.GetListaPadre()
        listaCategoriasItem = New List(Of item)
        listaCategoriasItem = categoriaSA.GetListaCategoriasItem(New item With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc
                                                          })
    End Sub
    Public Function validarBusqueda()
        Dim CONTEO = 0

        If chkc.Checked = True Then

            If txtClasificacion.Tag = Nothing Then
                CONTEO += 1
            End If

        ElseIf chks.Checked = True Then

            If txtSubClasificacion.Tag = Nothing Then
                CONTEO += 1
            End If

        ElseIf chkm.Checked = True Then

            If txtMarca.Text.Trim.Length = 0 Then
                CONTEO += 1
            End If

        ElseIf chkmo.Checked = True Then

            If txtModelo.Text.Trim.Length = 0 Then
                CONTEO += 1
            End If

        End If




        'Select Case cboTipoBusqueda.Text
        '    Case "POR CLASIFICACION"

        '        If txtClasificacion.Tag = Nothing Then
        '            CONTEO += 1
        '        End If

        '        If txtSubClasificacion.Tag = Nothing Then
        '            CONTEO += 1
        '        End If

        '        If txtMarca.Text.Trim.Length = 0 Then
        '            CONTEO += 1
        '        End If

        '        If txtModelo.Text.Trim.Length = 0 Then
        '            CONTEO += 1
        '        End If


        '    Case "POR MARCA MODELO"

        '        If txtMarca.Text.Trim.Length = 0 Then
        '            CONTEO += 1
        '        End If

        '        If txtModelo.Text.Trim.Length = 0 Then
        '            CONTEO += 1
        '        End If

        '    Case "POR MARCA"

        '        If txtMarca.Text.Trim.Length = 0 Then
        '            CONTEO += 1
        '        End If

        '    Case "POR SUBCLASIFICACION"

        '        If txtSubClasificacion.Tag = Nothing Then
        '            CONTEO += 1
        '        End If

        '        If txtMarca.Text.Trim.Length = 0 Then
        '            CONTEO += 1
        '        End If

        '        If txtModelo.Text.Trim.Length = 0 Then
        '            CONTEO += 1
        '        End If

        'End Select

        Return CONTEO
    End Function

    Private Function AddItemNuevaListaPrecios(be As detalleitemequivalencia_precios, rangoMinimo As Decimal?, max As Decimal) As detalleitemequivalencia_precios

        AddItemNuevaListaPrecios = New detalleitemequivalencia_precios
        AddItemNuevaListaPrecios = be
        AddItemNuevaListaPrecios.rango_inicio = rangoMinimo
        AddItemNuevaListaPrecios.rango_final = max
    End Function

    Private Sub GetProductosEnAlmacen(idProducto As Integer)
        Dim invSA As New TotalesAlmacenSA

        Dim listaInventario = invSA.GetDetalleLoteXproductoFullAlmacen(New totalesAlmacen With
                                                                       {
                                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                       .idItem = idProducto
                                                                       })

        ListInventario.Items.Clear()

        For Each i In listaInventario
            Dim n As New ListViewItem(i.idAlmacen)
            n.SubItems.Add(i.NomAlmacen)
            n.SubItems.Add(i.CustomLote.codigoLote)
            n.SubItems.Add(i.CustomLote.nroLote)
            n.SubItems.Add(i.cantidad)
            n.SubItems.Add(i.CustomLote.fechaentrada)
            n.SubItems.Add(i.CustomLote.fechaVcto)
            n.SubItems.Add(i.CustomLote.productoSustentado)
            ListInventario.Items.Add(n)
        Next
        ListInventario.Refresh()

        Dim cantidadTotal = listaInventario.Sum(Function(o) o.cantidad)
        TextStockTotal.Text = CDec(cantidadTotal).ToString("N2")

        Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        TextProductoSel.Text = producto.descripcionItem
    End Sub

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

#End Region


    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Dim rpta = validarBusqueda()

        If rpta > 0 Then
            MessageBox.Show("Seleccione el campo seleccionado")
            Exit Sub
        End If


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


            If chkc.Checked = True And chks.Checked = True And chkm.Checked = True And chkmo.Checked = True Then '1


                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Tag,
                                                                  .modelo = txtModelo.Text
                                                                  }, "1")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text,
                                                                  .modelo = txtModelo.Text
                                                                }, "1")
                End If

            ElseIf chkc.Checked = False And chks.Checked = True And chkm.Checked = True And chkmo.Checked = True Then '2

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text,
                                                                  .modelo = txtModelo.Text
                                                                  }, "2")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text,
                                                                  .modelo = txtModelo.Text
                                                                }, "2")
                End If

            ElseIf chkc.Checked = False And chks.Checked = False And chkm.Checked = True And chkmo.Checked = True Then '3

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .marcaRef = txtMarca.Text,
                                                                  .modelo = txtModelo.Text
                                                                  }, "3")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .marcaRef = txtMarca.Text,
                                                                  .modelo = txtModelo.Text
                                                                }, "3")
                End If


            ElseIf chkc.Checked = False And chks.Checked = False And chkm.Checked = False And chkmo.Checked = True Then '4

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .modelo = txtModelo.Text
                                                                  }, "4")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .modelo = txtModelo.Text
                                                                }, "4")
                End If

            ElseIf chkc.Checked = True And chks.Checked = False And chkm.Checked = False And chkmo.Checked = False Then '5

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag
                                                                  }, "5")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag
                                                                }, "5")
                End If

            ElseIf chkc.Checked = True And chks.Checked = True And chkm.Checked = False And chkmo.Checked = False Then '6

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .idItem = txtSubClasificacion.Tag
                                                                  }, "6")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .idItem = txtSubClasificacion.Tag
                                                                }, "6")
                End If

            ElseIf chkc.Checked = True And chks.Checked = True And chkm.Checked = True And chkmo.Checked = False Then '7

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text
                                                                  }, "7")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text
                                                                }, "7")
                End If

                'ElseIf chkc.Checked = True And chks.Checked = True And chkm.Checked = True And chkmo.Checked = True Then '8



            ElseIf chkc.Checked = True And chks.Checked = False And chkm.Checked = True And chkmo.Checked = False Then '9

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text
                                                                  }, "9")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text
                                                                }, "9")
                End If

            ElseIf chkc.Checked = True And chks.Checked = False And chkm.Checked = True And chkmo.Checked = True Then '10

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text,
                                                                  .modelo = txtModelo.Text
                                                                  }, "10")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text,
                                                                  .modelo = txtModelo.Text
                                                                }, "10")
                End If

                'ElseIf chkc.Checked = True And chks.Checked = False And chkm.Checked = False And chkmo.Checked = True Then '11


            ElseIf chkc.Checked = False And chks.Checked = True And chkm.Checked = False And chkmo.Checked = True Then '12

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .modelo = txtModelo.Text
                                                                  }, "12")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .modelo = txtModelo.Text
                                                                }, "12")
                End If

            ElseIf chkc.Checked = False And chks.Checked = True And chkm.Checked = False And chkmo.Checked = False Then '13

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idItem = txtSubClasificacion.Tag
                                                                  }, "13")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idItem = txtSubClasificacion.Tag
                                                                }, "13")
                End If

            ElseIf chkc.Checked = False And chks.Checked = False And chkm.Checked = True And chkmo.Checked = False Then  '14

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .marcaRef = txtMarca.Text
                                                                  }, "14")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .marcaRef = txtMarca.Text
                                                                }, "14")
                End If

            ElseIf chkc.Checked = True And chks.Checked = True And chkm.Checked = False And chkmo.Checked = True Then  '15

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .modelo = txtModelo.Text
                                                                  }, "15")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idClasificacion = txtClasificacion.Tag,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .modelo = txtModelo.Text
                                                                }, "15")
                End If

            ElseIf chkc.Checked = False And chks.Checked = True And chkm.Checked = True And chkmo.Checked = False Then  '16

                If CheckStock.Checked = True Then
                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioParam(New detalleitems With
                                                                  {
                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                  .descripcionItem = txtFiltrar.Text,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text
                                                                  }, "16")

                Else

                    UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasParam(New detalleitems With
                                                                {
                                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                .descripcionItem = txtFiltrar.Text,
                                                                  .idItem = txtSubClasificacion.Tag,
                                                                  .marcaRef = txtMarca.Text
                                                                }, "16")
                End If

            Else
                MessageBox.Show("Falta caso")
                Exit Sub
            End If



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

                StockTotal = 0
                If CheckStock.Checked = True Then
                    StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
                End If

                dt.Rows.Add(
                  i.origenProducto,
                  i.codigodetalle,
                  i.descripcionItem,
                  StockTotal,
                  i.unidad1,
                  i.detalleitem_equivalencias.FirstOrDefault.equivalencia_id, If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing), 0)
                '              If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precioCode, "0"),
                'If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precio, "0"))
            Next
            GridTotales.DataSource = dt
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        End If
    End Sub

    Private Sub txtClasificacion_TextChanged(sender As Object, e As EventArgs) Handles txtClasificacion.TextChanged
        txtClasificacion.ForeColor = Color.White
        txtClasificacion.Tag = Nothing
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub txtClasificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClasificacion.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcClasificacion.Font = New Font("Segoe UI", 8)
            Me.pcClasificacion.Size = New Size(241, 110)
            Me.pcClasificacion.ParentControl = Me.txtClasificacion
            Me.pcClasificacion.ShowPopup(Point.Empty)
            'Dim consulta = (From n In listaClasificacion
            '                Where n.descripcion.StartsWith(txtClasificacion.Text)).ToList

            Dim consulta = (From n In listaCategoriasItem
                            Where n.descripcion.StartsWith(txtClasificacion.Text) And n.tipo = TipoGrupoArticulo.CategoriaGeneral).ToList


            lsvClasificacion.DataSource = consulta
            lsvClasificacion.DisplayMember = "descripcion"
            lsvClasificacion.ValueMember = "idItem"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcClasificacion.Font = New Font("Segoe UI", 8)
            Me.pcClasificacion.Size = New Size(241, 110)
            Me.pcClasificacion.ParentControl = Me.txtClasificacion
            Me.pcClasificacion.ShowPopup(Point.Empty)
            lsvClasificacion.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcClasificacion.IsShowing() Then
                Me.pcClasificacion.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtSubClasificacion_TextChanged(sender As Object, e As EventArgs) Handles txtSubClasificacion.TextChanged
        txtSubClasificacion.ForeColor = Color.White
        txtSubClasificacion.Tag = Nothing
    End Sub

    Private Sub txtSubClasificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSubClasificacion.KeyDown
        'If txtClasificacion.Tag Is Nothing Then

        '    MessageBox.Show("Seleccione una Clasificacion")
        '    Exit Sub
        'End If

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtSubClasificacion
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            'Dim consulta = (From n In listaCategoria
            '                Where n.descripcion.StartsWith(txtSubClasificacion.Text)).ToList

            'Dim consulta = (From n In listaCategoriasItem
            '                Where n.descripcion.StartsWith(txtSubClasificacion.Text) And n.idPadre = txtClasificacion.Tag And n.tipo = TipoGrupoArticulo.SubClasificacion).ToList

            Dim consulta = (From n In listaCategoriasItem
                            Where n.descripcion.StartsWith(txtSubClasificacion.Text) And n.tipo = TipoGrupoArticulo.SubCategoriaGeneral).ToList

            lsvCategoria.DataSource = consulta
            lsvCategoria.DisplayMember = "descripcion"
            lsvCategoria.ValueMember = "idItem"
            'e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtSubClasificacion
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            lsvCategoria.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtMarca_TextChanged(sender As Object, e As EventArgs) Handles txtMarca.TextChanged
        txtMarca.ForeColor = Color.White
        txtMarca.Tag = Nothing
    End Sub

    Private Sub txtMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMarca.KeyDown
        'If txtSubClasificacion.Tag Is Nothing Then

        '    MessageBox.Show("Seleccione una Clasificacion")
        '    Exit Sub
        'End If

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcSubCategoria.Font = New Font("Segoe UI", 8)
            Me.pcSubCategoria.Size = New Size(241, 110)
            Me.pcSubCategoria.ParentControl = Me.txtMarca
            Me.pcSubCategoria.ShowPopup(Point.Empty)
            'Dim consulta = (From n In listaSubCategoria
            '                Where n.descripcion.StartsWith(txtMarca.Text)).ToList


            'Dim consulta = (From n In listaCategoriasItem
            '                Where n.descripcion.StartsWith(txtMarca.Text) And n.idPadre = txtSubClasificacion.Tag And n.tipo = TipoGrupoArticulo.Marca).ToList

            Dim consulta = (From n In listaCategoriasItem
                            Where n.descripcion.StartsWith(txtMarca.Text) And n.tipo = TipoGrupoArticulo.Marca).ToList

            lsvSubCategoria.DataSource = consulta
            lsvSubCategoria.DisplayMember = "descripcion"
            lsvSubCategoria.ValueMember = "idItem"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcSubCategoria.Font = New Font("Segoe UI", 8)
            Me.pcSubCategoria.Size = New Size(241, 110)
            Me.pcSubCategoria.ParentControl = Me.txtMarca
            Me.pcSubCategoria.ShowPopup(Point.Empty)
            lsvSubCategoria.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcSubCategoria.IsShowing() Then
                Me.pcSubCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtModelo_TextChanged(sender As Object, e As EventArgs) Handles txtModelo.TextChanged
        txtModelo.ForeColor = Color.White
        txtModelo.Tag = Nothing
    End Sub

    Private Sub txtModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtModelo.KeyDown
        'If txtMarca.Tag Is Nothing Then

        '    MessageBox.Show("Seleccione una Marca")
        '    Exit Sub
        'End If


        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.PCModelo.Font = New Font("Segoe UI", 8)
            Me.PCModelo.Size = New Size(241, 110)
            Me.PCModelo.ParentControl = Me.txtModelo
            Me.PCModelo.ShowPopup(Point.Empty)
            'Dim consulta = (From n In listaSubCategoria
            '                Where n.descripcion.StartsWith(txtModelo.Text)).ToList



            'Dim consulta = (From n In listaCategoriasItem
            '                Where n.descripcion.StartsWith(txtModelo.Text) And n.idPadre = txtMarca.Tag And n.tipo = TipoGrupoArticulo.Presentacion).ToList
            Dim consulta = (From n In listaCategoriasItem
                            Where n.descripcion.StartsWith(txtModelo.Text) And n.tipo = TipoGrupoArticulo.Presentacion).ToList

            lsvModelo.DataSource = consulta
            lsvModelo.DisplayMember = "descripcion"
            lsvModelo.ValueMember = "idItem"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.PCModelo.Font = New Font("Segoe UI", 8)
            Me.PCModelo.Size = New Size(241, 110)
            Me.PCModelo.ParentControl = Me.txtModelo
            Me.PCModelo.ShowPopup(Point.Empty)
            lsvModelo.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PCModelo.IsShowing() Then
                Me.PCModelo.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub lsvClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvClasificacion.SelectedIndexChanged

    End Sub

    Private Sub lsvClasificacion_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvClasificacion.MouseDoubleClick
        Me.pcClasificacion.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcClasificacion_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcClasificacion.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvClasificacion.SelectedItems.Count > 0 Then
                txtClasificacion.Text = lsvClasificacion.Text
                txtClasificacion.Tag = lsvClasificacion.SelectedValue
                'txtSubCategoria.Clear()
                txtClasificacion.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                ' Label43.Text = "0 items"
                '  Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtClasificacion.Focus()
        End If
    End Sub

    Private Sub lsvSubCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvSubCategoria.SelectedIndexChanged

    End Sub

    Private Sub lsvSubCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvSubCategoria.MouseDoubleClick
        Me.pcSubCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcSubCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcSubCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor
        'If txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvSubCategoria.SelectedItems.Count > 0 Then
                txtMarca.Text = lsvSubCategoria.Text
                txtMarca.Tag = lsvSubCategoria.SelectedValue
                txtMarca.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If
        'End If


        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtMarca.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCategoria.SelectedIndexChanged

    End Sub

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCategoria.SelectedItems.Count > 0 Then
                txtSubClasificacion.Text = lsvCategoria.Text
                txtSubClasificacion.Tag = lsvCategoria.SelectedValue
                txtMarca.Clear()
                txtSubClasificacion.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                ' Label43.Text = "0 items"
                '  Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtSubClasificacion.Focus()
        End If
    End Sub

    Private Sub lsvModelo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvModelo.SelectedIndexChanged

    End Sub

    Private Sub lsvModelo_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvModelo.MouseDoubleClick
        Me.PCModelo.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub PCModelo_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PCModelo.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvModelo.SelectedItems.Count > 0 Then
                txtModelo.Text = lsvModelo.Text
                txtModelo.Tag = lsvModelo.SelectedValue
                'txtMarca.Clear()
                txtModelo.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                ' Label43.Text = "0 items"
                '  Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtModelo.Focus()
        End If
    End Sub

    Private Sub UCBusquedaSegmento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaCateriasItem()
    End Sub

    Private Sub GridTotales_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridTotales.TableControlCellClick
        Dim r As Record = GridTotales.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridTotales.Table.Records.Count > 0 Then
                Dim value As String = r.GetValue("idItem").ToString()
                Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

                If idEquiva.Trim.Length > 0 Then
                    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                    Dim idCat = r.GetValue("cboPrecios").ToString()
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

    Private Sub GridTotales_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridTotales.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = "Agregar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            ElseIf e.Inner.ColIndex = 10 Then
                e.Inner.Style.Description = "Stock"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
            End If
        End If
    End Sub

    Private Sub GridTotales_TableControlCurrentCellShowingDropDown(sender As Object, e As GridTableControlCurrentCellShowingDropDownEventArgs) Handles GridTotales.TableControlCurrentCellShowingDropDown
        '      e.Inner.Size = New Size(100, 100)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            'If cc.ColIndex > -1 Then
            '    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)
            '    Dim r = style.TableCellIdentity.Table.CurrentRecord
            '    If style.TableCellIdentity.Column.Name = "importeMn" Then
            '        'If cc.Renderer IsNot Nothing Then
            '        Dim text As String = cc.Renderer.ControlText

            '            'If text.Trim.Length > 0 Then

            '            Dim value As String = e.TableControl.Table.TableModel(cc.RowIndex, 2).CellValue
            '                Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
            '                Dim idEquiva = e.TableControl.Table.TableModel(cc.RowIndex, 6).CellValue.ToString()

            '                If idEquiva.Trim.Length > 0 Then
            '                    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single

            '                    Dim idCat = e.TableControl.Table.TableModel(cc.RowIndex, 7).CellValue.ToString()
            '                    If idCat.Trim.Length > 0 Then

            '                        Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

            '                        'Dim listaCatalog = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
            '                        Dim listaPreciosVenta = GetDetallePrecios(OBJCatalog.detalleitemequivalencia_precios.ToList)


            '                        'style2.DataSource = listaPreciosVenta 'OBJCatalog.detalleitemequivalencia_precios.ToList
            '                        'style2.DisplayMember = "precio"
            '                        'style2.ValueMember = "precio_id"

            '                        Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
            '                        Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DisplayMember = "precioCode"
            '                        Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.ValueMember = "precio"
            '                        Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DataSource = listaPreciosVenta
            '                        '     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
            '                        Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
            '                    Else
            '                        'style2.DataSource = Nothing
            '                        'style2.DisplayMember = "precio"
            '                        'style2.ValueMember = "precio_id"
            '                    End If


            '                End If
            '            'End If

            '            'End If


            '        ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
            '        'If cc.Renderer IsNot Nothing Then
            '        '    Dim text As String = cc.Renderer.ControlText

            '        '    If text.Trim.Length > 0 Then
            '        '        If GridCompra.Table.CurrentRecord IsNot Nothing Then
            '        '            GetCalculoItem(GridCompra.Table.CurrentRecord)
            '        '            EditarItemVenta(GridCompra.Table.CurrentRecord)
            '        '            '   FormPurchase.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
            '        '        End If
            '        '        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
            '        '    End If
            '        'End If
            '    End If
            'End If
        End If
    End Sub

    Private Sub GridTotales_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridTotales.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 9 Then

                Dim equivalencia = GridTotales.TableModel(e.Inner.RowIndex, 6).CellValue
                Dim CatalogoPrecio = GridTotales.TableModel(e.Inner.RowIndex, 7).CellValue

                If equivalencia.ToString.Trim.Length = 0 Then
                    MessageBox.Show("Debe ingresar una equivalencia valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                'If precio.ToString.Trim.Length = 0 Then
                '    MessageBox.Show("Debe ingresar un precio valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Me.Cursor = Cursors.Default
                '    Exit Sub
                'End If


                Dim idProducto = GridTotales.TableModel(e.Inner.RowIndex, 2).CellValue

                Dim precioVenta = 0 ' CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                If inp IsNot Nothing Then
                    If IsNumeric(inp) Then
                        If (inp) > 0 Then

                            Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                            precioVenta = precioventaFormula

                            Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                            If eqLista.productoRestringido = True Then
                                If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If

                            Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            Dim idcatalogo = GridTotales.TableModel(e.Inner.RowIndex, 7).CellValue

                            If idcatalogo.ToString.Trim.Length = 0 Then
                                MessageBox.Show("Debe ingresar un catalogo de precio valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If

                            Dim objCatalogo = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idcatalogo).SingleOrDefault


                            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, objCatalogo.idCatalogo)
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
                Else
                    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Default
                End If
                'MsgBox("Cantidad: " & inp)
            ElseIf e.Inner.ColIndex = 10 Then
                Dim idProducto = GridTotales.TableModel(e.Inner.RowIndex, 2).CellValue
                GetProductosEnAlmacen(idProducto)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar")
        End Try

        Me.Cursor = Cursors.Default
    End Sub


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

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click

        Try


            If Not txtCodigo.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese un Codigo")
                Exit Sub
            End If


            If txtCodigo.Text.Trim.Length > 0 Then
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


                Dim tipocargo As String = ""


                Select Case cboCargosAResponsabilidad.Text

                    Case "CLASIFICACION"

                        tipocargo = TipoGrupoArticulo.CategoriaGeneral

                    Case "SUB CLASIFICACION"
                        tipocargo = TipoGrupoArticulo.SubCategoriaGeneral
                    Case "MARCA"
                        tipocargo = TipoGrupoArticulo.Marca
                    Case "PRESENTACION/MODELO"
                        tipocargo = TipoGrupoArticulo.Presentacion
                End Select



                UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioCodigos(New detalleitems With
                                                                      {
                                                                      .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                      .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                      .codigoInterno = txtCodigo.Text
                                                                      }, tipocargo)



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

                    StockTotal = 0
                    If CheckStock.Checked = True Then
                        StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
                    End If

                    dt.Rows.Add(
                      i.origenProducto,
                      i.codigodetalle,
                      i.descripcionItem,
                      StockTotal,
                      i.unidad1,
                      i.detalleitem_equivalencias.FirstOrDefault.equivalencia_id, If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing), 0)
                    '              If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precioCode, "0"),
                    'If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precio, "0"))
                Next
                GridTotales.DataSource = dt
                GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
                GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            End If
        Catch ex As Exception

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
End Class

Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.XlsIO

Public Class FormImportarExcelInventario
#Region "Properties"
    Private listaCompraDetalle As List(Of documentocompradetalle)
    Private eng As ExcelEngine
    Private workBook As IWorkbook
    Public Property listaProductos As List(Of detalleitems)
    Public Property listaProductosGrabados As List(Of detalleitems)


    Public Property ListaTotalItem As New List(Of item)
    Public Property listaGuardarClasificacion As New List(Of item)
    Public Property listaGuardarCategorias As New List(Of item)
    Public Property listaGuardarSubCategoria As New List(Of item)
    Public Property listaGuardarMarca As New List(Of item)
    Public Property listaGuardarPresentacion As New List(Of item)
    Public Property conteoserie = 1
    Public Property conteocolor = 1
    Public Property conteoadicional1 = 1
    Public Property conteoadicional2 = 1
    Public Property ListaColorTalla As New List(Of tabladetalle)

    Public Property ListaDeterminado As New List(Of item)

    Public Property ListaCodigoUnidad As New List(Of String)

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetAlmacenes()
        CargarDeterminados()
    End Sub



    Public Sub CargarDeterminados()
        Dim itemSA As New itemSA

        ListaDeterminado = itemSA.ListaTotalItem(New item With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})

    End Sub

    Private Sub GetAlmacenes()
        Dim almacenSA As New almacenSA

        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Cursor = Cursors.WaitCursor
        Dim strDestination As String = Nothing

        Dim dlgResult As DialogResult
        Dim ruta As String = Nothing
        Try

            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls" '
                '  .ShowDialog()
                dlgResult = .ShowDialog
                strDestination = .FileName
                ruta = strDestination
            End With
            Me.dataGrid1.DataSource = Nothing
            If dlgResult <> DialogResult.Cancel Then
                eng = New ExcelEngine()
                'workBook = eng.Excel.Workbooks.Open("D:\Formato Inventario 2019.xlsx")
                workBook = eng.Excel.Workbooks.Open(ruta)
                Dim sheet As IWorksheet = workBook.Worksheets(0)
                sheet.EnableSheetCalculations()
                Dim dt As DataTable = New DataTable("Input Data")
                dt = sheet.ExportDataTable(3, 1, sheet.Rows.Count + 10, 32, ExcelExportDataTableOptions.None)
                Me.dataGrid1.DataSource = dt
                ' Me.button1.Enabled = False
                Dim tabStyle As DataGridTableStyle = New DataGridTableStyle()
                tabStyle.MappingName = dt.TableName
                Me.dataGrid1.TableStyles.Add(tabStyle)

                For i As Integer = 0 To 22 - 1

                    Select Case i
                        Case 3
                            tabStyle.GridColumnStyles(i).Width = 300
                        Case 4
                            tabStyle.GridColumnStyles(i).Width = 50
                        Case Else
                            tabStyle.GridColumnStyles(i).Width = 60
                    End Select

                    'tabStyle.GridColumnStyles(i).HeaderText = String.Format("{0}", ChrW((CInt("A"c) + i)))
                    tabStyle.GridColumnStyles(i).Alignment = HorizontalAlignment.Left
                Next

                tabStyle.HeaderBackColor = Color.LightSteelBlue
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Function BuscarCodigoMarcaCategoriaSubCategoria(lista As List(Of detalleitems)) As List(Of detalleitems)

        Dim nuevalista As New List(Of detalleitems)

        For Each i In lista

            Dim objeto As New detalleitems
            objeto = i

            If objeto.MarcaTemporal IsNot Nothing Then

                Dim marca = (From j In ListaTotalItem Where j.descripcion = objeto.MarcaTemporal And j.tipo = TipoGrupoArticulo.Marca).FirstOrDefault

                If marca IsNot Nothing Then
                    objeto.marcaRef = marca.idItem
                End If

            End If

            If objeto.PresentacionTemporal IsNot Nothing Then

                Dim presentacion = (From j In ListaTotalItem Where j.descripcion = objeto.PresentacionTemporal And j.tipo = TipoGrupoArticulo.Presentacion).FirstOrDefault

                If presentacion IsNot Nothing Then
                    objeto.idCaracteristica = presentacion.idItem
                    objeto.presentacion = presentacion.descripcion
                End If

            End If

            If objeto.ClasificacionTemporal IsNot Nothing Then
                Dim Categoria = (From j In ListaTotalItem Where j.descripcion = objeto.ClasificacionTemporal And j.tipo = TipoGrupoArticulo.Principal).FirstOrDefault

                If Categoria IsNot Nothing Then
                    objeto.idClasificacion = Categoria.idItem
                End If
            End If

            If objeto.CategoriaTemporal IsNot Nothing Then
                Dim Categoria = (From j In ListaTotalItem Where j.descripcion = objeto.CategoriaTemporal And j.tipo = TipoGrupoArticulo.CategoriaGeneral).FirstOrDefault

                If Categoria IsNot Nothing Then
                    objeto.idItem = Categoria.idItem
                End If
            End If
            If objeto.SubCategoriaTemporal IsNot Nothing Then
                Dim SubCategoria = (From j In ListaTotalItem Where j.descripcion = objeto.SubCategoriaTemporal And j.tipo = TipoGrupoArticulo.SubCategoriaGeneral).FirstOrDefault

                If SubCategoria IsNot Nothing Then
                    objeto.unidad2 = SubCategoria.idItem
                End If
            End If

            nuevalista.Add(objeto)

        Next

        Return nuevalista
    End Function

    Public Function BuscarPadrePrincipal() As List(Of item)
        Dim itemsa As New itemSA
        Dim listaNueva As New List(Of item)

        ListaTotalItem = New List(Of item)

        ListaTotalItem = itemsa.ListaTotalItem(New item With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})

        For Each i In listaGuardarCategorias

            Dim objeto As New item
            objeto = i
            Dim Categoria = (From j In ListaTotalItem Where j.descripcion = objeto.PadreTemportal And j.tipo = TipoGrupoArticulo.Principal).FirstOrDefault

            If Categoria IsNot Nothing Then
                objeto.idPadre = Categoria.idItem
            End If

            listaNueva.Add(objeto)
        Next

        Return listaNueva

    End Function


    Public Function BuscarPadreMarca() As List(Of item)
        Dim itemsa As New itemSA
        Dim listaNueva As New List(Of item)

        ListaTotalItem = New List(Of item)

        ListaTotalItem = itemsa.ListaTotalItem(New item With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})

        For Each i In listaGuardarPresentacion

            Dim objeto As New item
            objeto = i
            Dim Marca = (From j In ListaTotalItem Where j.descripcion = objeto.PadreTemportal And j.tipo = TipoGrupoArticulo.Marca).FirstOrDefault

            If Marca IsNot Nothing Then
                objeto.idPadre = Marca.idItem
            End If

            listaNueva.Add(objeto)
        Next

        Return listaNueva

    End Function

    Public Function BuscarPadreCategoria() As List(Of item)
        Dim itemsa As New itemSA
        Dim listaNueva As New List(Of item)

        ListaTotalItem = New List(Of item)

        ListaTotalItem = itemsa.ListaTotalItem(New item With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})

        For Each i In listaGuardarSubCategoria

            Dim objeto As New item
            objeto = i
            Dim Categoria = (From j In ListaTotalItem Where j.descripcion = objeto.PadreTemportal And j.tipo = TipoGrupoArticulo.CategoriaGeneral).FirstOrDefault

            If Categoria IsNot Nothing Then
                objeto.idPadre = Categoria.idItem
            End If

            listaNueva.Add(objeto)
        Next

        Return listaNueva

    End Function


    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click



        Cursor = Cursors.WaitCursor
        Dim listaUnidades As List(Of detalleitem_equivalencias) = Nothing
        listaProductos = New List(Of detalleitems)
        Dim producto As detalleitems = Nothing
        Dim productoSA As New detalleitemsSA
        Dim itemsa As New itemSA
        Dim tabladetallesa As New tablaDetalleSA
        ListaCodigoUnidad = New List(Of String)

        Dim index As Integer = 0
        Dim dt As New DataTable
        Try
            listaCompraDetalle = New List(Of documentocompradetalle)
            ' Dim vista = dataGrid1.Item.DataSource
            dt = dataGrid1.DataSource
            For i = 0 To dt.Rows.Count + 5
                If index = 200 Then
                    MsgBox("200")

                ElseIf index = 300 Then
                    MsgBox("300")
                ElseIf index = 400 Then
                    MsgBox("400")
                ElseIf index = 500 Then
                    MsgBox("500")
                End If

                If dataGrid1.Item(index, 14).ToString.Trim.Length > 0 Then
                    producto = New detalleitems
                    listaProductos.Add(producto)
                    AllProductGeneral(index, producto)
                    listaUnidades = New List(Of detalleitem_equivalencias)
                    producto.detalleitem_equivalencias = listaUnidades
                    listaUnidades.Add(AddUnidadMedidad(index, producto, True))
                ElseIf dataGrid1.Item(index, 14).ToString.Trim.Length = 0 And dataGrid1.Item(index, 16).ToString.Trim.Length > 0 Then
                    listaUnidades.Add(AddUnidadMedidad(index, producto, False))
                ElseIf dataGrid1.Item(index, 14).ToString.Trim.Length = 0 And dataGrid1.Item(index, 16).ToString.Trim.Length = 0 Then
                    MsgBox("Importacion terminada!")
                    Exit For
                End If
                index = index + 1
            Next




            If listaGuardarClasificacion.Count > 0 Then
                itemsa.GrabarListaDeItemTipo(listaGuardarClasificacion)

                Dim listaCategorias As List(Of item) = BuscarPadrePrincipal()
                itemsa.GrabarListaDeItemTipo(listaCategorias)

                Dim listaSubCategorias As List(Of item) = BuscarPadreCategoria()
                itemsa.GrabarListaDeItemTipo(listaSubCategorias)

            End If


            'If listaGuardarCategorias.Count > 0 Then

            '    itemsa.GrabarListaDeItemTipo(listaGuardarCategorias)

            '    Dim listaSubCategorias As List(Of item) = BuscarPadreCategoria()
            '    itemsa.GrabarListaDeItemTipo(listaSubCategorias)
            'Else
            '    If listaGuardarSubCategoria.Count > 0 Then
            '        itemsa.GrabarListaDeItemTipo(listaGuardarSubCategoria)
            '    End If
            'End If

            If listaGuardarMarca.Count > 0 Then

                itemsa.GrabarListaDeItemTipo(listaGuardarMarca)


                Dim listaPresentacion As List(Of item) = BuscarPadreMarca()
                itemsa.GrabarListaDeItemTipo(listaPresentacion)

            End If


            If ListaColorTalla.Count > 0 Then
                tabladetallesa.GrabarListaTallaColor(ListaColorTalla)
            End If




            ListaTotalItem = New List(Of item)
            ListaTotalItem = itemsa.ListaTotalItem(New item With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})

            If ListaTotalItem.Count > 0 Then
                Dim listanueva = BuscarCodigoMarcaCategoriaSubCategoria(listaProductos)
            End If

            productoSA.SaveListaProducto(listaProductos)
            listaProductosGrabados = productoSA.GetProductosWithEquivalenciasEstablecimiento(New detalleitems With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})
            'listaProductos = lista
            MessageBox.Show("productos registrados!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Cursor = Cursors.Default
    End Sub

    'Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
    '    Cursor = Cursors.WaitCursor
    '    Dim listaUnidades As List(Of detalleitem_equivalencias) = Nothing
    '    listaProductos = New List(Of detalleitems)
    '    Dim producto As detalleitems = Nothing
    '    Dim productoSA As New detalleitemsSA
    '    Dim index As Integer = 0
    '    Dim dt As New DataTable
    '    Try
    '        listaCompraDetalle = New List(Of documentocompradetalle)
    '        ' Dim vista = dataGrid1.Item.DataSource
    '        dt = dataGrid1.DataSource
    '        For i = 0 To dt.Rows.Count + 5
    '            If index = 200 Then
    '                MsgBox("200")

    '            ElseIf index = 300 Then
    '                MsgBox("300")
    '            ElseIf index = 400 Then
    '                MsgBox("400")
    '            ElseIf index = 500 Then
    '                MsgBox("500")
    '            End If




    '            If dataGrid1.Item(index, 3).ToString.Trim.Length > 0 Then
    '                producto = New detalleitems
    '                listaProductos.Add(producto)
    '                AllProductGeneral(index, producto)
    '                listaUnidades = New List(Of detalleitem_equivalencias)
    '                producto.detalleitem_equivalencias = listaUnidades
    '                listaUnidades.Add(AddUnidadMedidad(index, producto, True))
    '            ElseIf dataGrid1.Item(index, 3).ToString.Trim.Length = 0 And dataGrid1.Item(index, 6).ToString.Trim.Length > 0 Then
    '                listaUnidades.Add(AddUnidadMedidad(index, producto, False))
    '            ElseIf dataGrid1.Item(index, 3).ToString.Trim.Length = 0 And dataGrid1.Item(index, 6).ToString.Trim.Length = 0 Then
    '                MsgBox("Importacion terminada!")
    '                Exit For
    '            End If
    '            index = index + 1
    '        Next
    '        productoSA.SaveListaProducto(listaProductos)
    '        listaProductosGrabados = productoSA.GetProductosWithEquivalenciasEstablecimiento(New detalleitems With {.idEstablecimiento = GEstableciento.IdEstablecimiento})
    '        'listaProductos = lista
    '        MessageBox.Show("productos registrados!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    '    Cursor = Cursors.Default
    'End Sub



    Private Function AddUnidadMedidad(index As Integer, producto As detalleitems, EsUnidadPrincipal As Boolean) As detalleitem_equivalencias
        Dim listaPrecio As New List(Of detalleitemequivalencia_precios)
        Dim listaPrecioEspecial As New List(Of detalleitemequivalencia_precios)
        Dim listaPrecioGranMayor As New List(Of detalleitemequivalencia_precios)

        Dim stock As Decimal = Decimal.Parse(dataGrid1.Item(index, 21))
        Dim CostoTotal As Decimal = 0 'Decimal.Parse(dataGrid1.Item(index, 13))

        Dim unidadPrincipal = dataGrid1.Item(index, 16)
        Dim UnidadComercial = dataGrid1.Item(index, 17)

        'codigo por unidad
        Dim codeBar = dataGrid1.Item(index, 18)

        Dim contenido = dataGrid1.Item(index, 19)

        'Dim Representacion As Decimal = Decimal.Parse(dataGrid1.Item(index, 20))
        'Dim Equivalencia As Decimal = 1 / Decimal.Parse(Representacion)
        Dim precioCompraUnitario As Decimal = dataGrid1.Item(index, 22)
        precioCompraUnitario = CDec(precioCompraUnitario)

        Dim stockReal As Decimal = stock / contenido  'Equivalencia * stock
        CostoTotal = stockReal * precioCompraUnitario

        Select Case producto.origenProducto
            Case OperacionGravada.Grabado
                CostoTotal = Math.Round(CDec(CalculoBaseImponible(CostoTotal, CDec(1.18))), 2)
            Case OperacionGravada.Exonerado, OperacionGravada.Inafecto
                CostoTotal = CostoTotal
        End Select

#Region "Precios"
        If dataGrid1.Item(index, 24).ToString.Trim.Length > 0 Then
            Dim rango1 = Decimal.Parse(dataGrid1.Item(index, 24))
            Dim Precio1 = Decimal.Parse(dataGrid1.Item(index, 25))
            If Precio1 > 0 And rango1 >= 0 Then
                listaPrecio.Add(New detalleitemequivalencia_precios With
                                {
                                .rango_inicio = rango1,
                                .rango_final = 0,
                                .precioCode = "Precio A",
                                .precio = Precio1,
                                .precioCredito = Precio1,
                                .estado = 1,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = Date.Now
                                })
            End If
        End If


        If dataGrid1.Item(index, 26).ToString.Trim.Length > 0 Then
            Dim rango2 = Decimal.Parse(dataGrid1.Item(index, 26))
            Dim Precio2 = Decimal.Parse(dataGrid1.Item(index, 27))
            If Precio2 > 0 And rango2 >= 0 Then
                listaPrecio.Add(New detalleitemequivalencia_precios With
                                {
                                .rango_inicio = rango2,
                                .rango_final = 0,
                                .precioCode = "Precio B",
                                .precio = Precio2,
                                .precioCredito = Precio2,
                                .estado = 1,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = Date.Now
                                })
            End If
        End If

        If dataGrid1.Item(index, 28).ToString.Trim.Length > 0 Then
            Dim rango3 = Decimal.Parse(dataGrid1.Item(index, 28))
            Dim Precio3 = Decimal.Parse(dataGrid1.Item(index, 29))
            If Precio3 > 0 And rango3 >= 0 Then
                listaPrecio.Add(New detalleitemequivalencia_precios With
                                {
                                .rango_inicio = rango3,
                                .rango_final = 0,
                                .precioCode = "Precio C",
                                .precio = Precio3,
                                .precioCredito = Precio3,
                                .estado = 1,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = Date.Now
                                })
            End If
        End If

        If dataGrid1.Item(index, 30).ToString.Trim.Length > 0 Then
            Dim precioEspecial = Decimal.Parse(dataGrid1.Item(index, 30))
            If precioEspecial > 0 Then
                listaPrecioEspecial.Add(New detalleitemequivalencia_precios With
                                {
                                .rango_inicio = 0,
                                .rango_final = 0,
                                .precioCode = "Precio especial",
                                .precio = precioEspecial,
                                .precioCredito = precioEspecial,
                                .estado = 1,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = Date.Now
                                })
            End If
        End If

        If dataGrid1.Item(index, 31).ToString.Trim.Length > 0 Then
            Dim precioEspecial = Decimal.Parse(dataGrid1.Item(index, 31))
            If precioEspecial > 0 Then
                listaPrecioGranMayor.Add(New detalleitemequivalencia_precios With
                                {
                                .rango_inicio = 0,
                                .rango_final = 0,
                                .precioCode = "Precio Gran Mayor",
                                .precio = precioEspecial,
                                .precioCredito = precioEspecial,
                                .estado = 1,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = Date.Now
                                })
            End If
        End If

#End Region

        If EsUnidadPrincipal Then
            producto.unidad1 = unidadPrincipal
            producto.unidad2 = "0"
        End If
        If codeBar.ToString.Length > 0 Then

            Return New detalleitem_equivalencias With
                          {
                          .Stock = stockReal,
                          .CostoTotal = CostoTotal,
                          .detalle = unidadPrincipal,
                          .unidadComercial = UnidadComercial,
                          .contenido = 0,'Representacion,
                          .codigo = codeBar,
                          .fraccionUnidad = 0, 'Equivalencia,
                          .contenido_neto = Decimal.Parse(contenido),
                          .estado = "A",
                          .usuarioActualizacion = usuario.IDUsuario,
                          .fechaActualizacion = Date.Now,
                          .detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos) From
                            {
                                New detalleitemequivalencia_catalogos With
                                {
                                .nombre_corto = "LISTA A",
                                .nombre_largo = "LISTA A",
                                .predeterminado = True,
                                .estado = 1,
                                .detalleitemequivalencia_precios = listaPrecio
                                },
                                New detalleitemequivalencia_catalogos With
                                {
                                .nombre_corto = "LISTA B",
                                .nombre_largo = "LISTA B",
                                .predeterminado = False,
                                .estado = 1,
                                .detalleitemequivalencia_precios = listaPrecioEspecial
                                },
                                New detalleitemequivalencia_catalogos With
                                {
                                .nombre_corto = "LISTA C",
                                .nombre_largo = "LISTA C",
                                .predeterminado = False,
                                .estado = 1,
                                .detalleitemequivalencia_precios = listaPrecioGranMayor
                                }
                             }
                          }

        Else

            Return New detalleitem_equivalencias With
                          {
                          .Stock = stockReal,
                          .CostoTotal = CostoTotal,
                          .detalle = unidadPrincipal,
                          .unidadComercial = UnidadComercial,
                          .contenido = 0,'Representacion,
                          .fraccionUnidad = 0, 'Equivalencia,
                          .contenido_neto = Decimal.Parse(contenido),
                          .estado = "A",
                          .usuarioActualizacion = usuario.IDUsuario,
                          .fechaActualizacion = Date.Now,
                          .detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos) From
                            {
                                New detalleitemequivalencia_catalogos With
                                {
                                .nombre_corto = "LISTA A",
                                .nombre_largo = "LISTA A",
                                .predeterminado = True,
                                .estado = 1,
                                .detalleitemequivalencia_precios = listaPrecio
                                },
                                New detalleitemequivalencia_catalogos With
                                {
                                .nombre_corto = "LISTA B",
                                .nombre_largo = "LISTA B",
                                .predeterminado = False,
                                .estado = 1,
                                .detalleitemequivalencia_precios = listaPrecioEspecial
                                },
                                New detalleitemequivalencia_catalogos With
                                {
                                .nombre_corto = "LISTA C",
                                .nombre_largo = "LISTA C",
                                .predeterminado = False,
                                .estado = 1,
                                .detalleitemequivalencia_precios = listaPrecioGranMayor
                                }
                             }
                          }
        End If
    End Function

    '    Private Function AddUnidadMedidad(index As Integer, producto As detalleitems, EsUnidadPrincipal As Boolean) As detalleitem_equivalencias
    '        Dim listaPrecio As New List(Of detalleitemequivalencia_precios)
    '        Dim listaPrecioEspecial As New List(Of detalleitemequivalencia_precios)
    '        Dim listaPrecioGranMayor As New List(Of detalleitemequivalencia_precios)

    '        Dim stock As Decimal = Decimal.Parse(dataGrid1.Item(index, 12))
    '        Dim CostoTotal As Decimal = 0 'Decimal.Parse(dataGrid1.Item(index, 13))



    '        Dim unidadPrincipal = dataGrid1.Item(index, 6)
    '        Dim UnidadComercial = dataGrid1.Item(index, 7)

    '        Dim contenido = dataGrid1.Item(index, 8)

    '        Dim Representacion As Decimal = Decimal.Parse(dataGrid1.Item(index, 9))
    '        Dim Equivalencia As Decimal = 1 / Decimal.Parse(Representacion)
    '        Dim precioCompraUnitario As Decimal = dataGrid1.Item(index, 13)
    '        precioCompraUnitario = CDec(precioCompraUnitario)

    '        Dim stockReal As Decimal = Equivalencia * stock
    '        CostoTotal = stockReal * precioCompraUnitario



    '        Select Case producto.origenProducto
    '            Case OperacionGravada.Grabado
    '                CostoTotal = Math.Round(CDec(CalculoBaseImponible(CostoTotal, CDec(1.18))), 2)
    '            Case OperacionGravada.Exonerado, OperacionGravada.Inafecto
    '                CostoTotal = CostoTotal
    '        End Select


    '#Region "Precios"
    '        If dataGrid1.Item(index, 15).ToString.Trim.Length > 0 Then
    '            Dim rango1 = Decimal.Parse(dataGrid1.Item(index, 15))
    '            Dim Precio1 = Decimal.Parse(dataGrid1.Item(index, 16))
    '            If Precio1 > 0 And rango1 >= 0 Then
    '                listaPrecio.Add(New detalleitemequivalencia_precios With
    '                                {
    '                                .rango_inicio = rango1,
    '                                .rango_final = 0,
    '                                .precioCode = "Precio A",
    '                                .precio = Precio1,
    '                                .precioCredito = Precio1,
    '                                .estado = 1,
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = Date.Now
    '                                })
    '            End If
    '        End If


    '        If dataGrid1.Item(index, 17).ToString.Trim.Length > 0 Then
    '            Dim rango2 = Decimal.Parse(dataGrid1.Item(index, 17))
    '            Dim Precio2 = Decimal.Parse(dataGrid1.Item(index, 18))
    '            If Precio2 > 0 And rango2 >= 0 Then
    '                listaPrecio.Add(New detalleitemequivalencia_precios With
    '                                {
    '                                .rango_inicio = rango2,
    '                                .rango_final = 0,
    '                                .precioCode = "Precio B",
    '                                .precio = Precio2,
    '                                .precioCredito = Precio2,
    '                                .estado = 1,
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = Date.Now
    '                                })
    '            End If
    '        End If

    '        If dataGrid1.Item(index, 19).ToString.Trim.Length > 0 Then
    '            Dim rango3 = Decimal.Parse(dataGrid1.Item(index, 19))
    '            Dim Precio3 = Decimal.Parse(dataGrid1.Item(index, 20))
    '            If Precio3 > 0 And rango3 >= 0 Then
    '                listaPrecio.Add(New detalleitemequivalencia_precios With
    '                                {
    '                                .rango_inicio = rango3,
    '                                .rango_final = 0,
    '                                .precioCode = "Precio C",
    '                                .precio = Precio3,
    '                                .precioCredito = Precio3,
    '                                .estado = 1,
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = Date.Now
    '                                })
    '            End If
    '        End If

    '        If dataGrid1.Item(index, 21).ToString.Trim.Length > 0 Then
    '            Dim precioEspecial = Decimal.Parse(dataGrid1.Item(index, 21))
    '            If precioEspecial > 0 Then
    '                listaPrecioEspecial.Add(New detalleitemequivalencia_precios With
    '                                {
    '                                .rango_inicio = 0,
    '                                .rango_final = 0,
    '                                .precioCode = "Precio especial",
    '                                .precio = precioEspecial,
    '                                .precioCredito = precioEspecial,
    '                                .estado = 1,
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = Date.Now
    '                                })
    '            End If
    '        End If

    '        If dataGrid1.Item(index, 22).ToString.Trim.Length > 0 Then
    '            Dim precioEspecial = Decimal.Parse(dataGrid1.Item(index, 22))
    '            If precioEspecial > 0 Then
    '                listaPrecioGranMayor.Add(New detalleitemequivalencia_precios With
    '                                {
    '                                .rango_inicio = 0,
    '                                .rango_final = 0,
    '                                .precioCode = "Precio Gran Mayor",
    '                                .precio = precioEspecial,
    '                                .precioCredito = precioEspecial,
    '                                .estado = 1,
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = Date.Now
    '                                })
    '            End If
    '        End If

    '#End Region

    '        If EsUnidadPrincipal Then
    '            producto.unidad1 = unidadPrincipal
    '            producto.unidad2 = "0"
    '        End If

    '        Return New detalleitem_equivalencias With
    '                          {
    '                          .Stock = stockReal,
    '                          .CostoTotal = CostoTotal,
    '                          .detalle = unidadPrincipal,
    '                          .unidadComercial = UnidadComercial,
    '                          .contenido = Representacion,
    '                          .fraccionUnidad = Equivalencia,
    '                          .contenido_neto = Decimal.Parse(contenido),
    '                          .estado = "A",
    '                          .usuarioActualizacion = usuario.IDUsuario,
    '                          .fechaActualizacion = Date.Now,
    '                          .detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos) From
    '                            {
    '                                New detalleitemequivalencia_catalogos With
    '                                {
    '                                .nombre_corto = "LISTA A",
    '                                .nombre_largo = "LISTA A",
    '                                .predeterminado = True,
    '                                .estado = 1,
    '                                .detalleitemequivalencia_precios = listaPrecio
    '                                },
    '                                New detalleitemequivalencia_catalogos With
    '                                {
    '                                .nombre_corto = "LISTA B",
    '                                .nombre_largo = "LISTA B",
    '                                .predeterminado = False,
    '                                .estado = 1,
    '                                .detalleitemequivalencia_precios = listaPrecioEspecial
    '                                },
    '                                New detalleitemequivalencia_catalogos With
    '                                {
    '                                .nombre_corto = "LISTA C",
    '                                .nombre_largo = "LISTA C",
    '                                .predeterminado = False,
    '                                .estado = 1,
    '                                .detalleitemequivalencia_precios = listaPrecioGranMayor
    '                                }
    '                             }
    '                          }

    '    End Function




    Private Sub AllProductGeneral(index As Integer, producto As detalleitems)
        'codigo
        Dim codigo = dataGrid1.Item(index, 0)
        'codigo interno
        Dim codigoInterno = dataGrid1.Item(index, 1)
        'afectacion
        Dim afectacion = dataGrid1.Item(index, 2)
        'prohibido
        Dim prohibido = dataGrid1.Item(index, 3)

        'tipoBien
        Dim tipoBien = dataGrid1.Item(index, 4)

        'Clasificacion
        Dim clasificacion = dataGrid1.Item(index, 5)

        'Categoria
        Dim categoria = dataGrid1.Item(index, 6)
        'SubCategoria
        Dim subcategoria = dataGrid1.Item(index, 7)
        'Marca
        Dim marca = dataGrid1.Item(index, 8)

        'Presentacion
        Dim presentacion = dataGrid1.Item(index, 9)


        'serie
        Dim serie = dataGrid1.Item(index, 10)

        'color
        Dim color = dataGrid1.Item(index, 11)

        'adicional1
        Dim adicional1 = dataGrid1.Item(index, 12)
        'adicional2
        Dim adicional2 = dataGrid1.Item(index, 13)

        'producto
        Dim productoName = dataGrid1.Item(index, 14)

        productoName = LimpiarCadenaNombreFichero(productoName, "")

        If Trim(productoName.ToString).Trim.Length = 0 Then
            'MessageBox.Show("Verificar producto", "Validar espacios en blanco, teclas especiales", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Throw New Exception("Verificar producto, Validar espacios en blanco y teclas especiales")
        End If

        If Trim(productoName.ToString).Trim.Length > 200 Then
            Me.Cursor = Cursors.Default
            Throw New Exception("El máximo de catecteres permitido es {200}.")
        End If


        'peso

        Dim peso = dataGrid1.Item(index, 15)

        If peso.ToString.Length = 0 Then
            peso = "0"
        End If


        Dim codigoUnidad = dataGrid1.Item(index, 18)

        If codigoUnidad.ToString.Length > 0 Then

            Dim consulta = (From i In ListaCodigoUnidad Where i = codigoUnidad).Count

            If consulta > 0 Then


                Throw New Exception("El codigo :" & " " & codigoUnidad & " " & "se repite revise su excel")
            Else
                ListaCodigoUnidad.Add(codigoUnidad)
            End If


        End If



        'Dim peso = If(dataGrid1.Item(index, 15).ToString.Trim.Length = 0, "0", dataGrid1.Item(index, 8))




        Dim code As Guid
        code = Guid.NewGuid
        producto.Filtros = code.ToString
        producto.tipoBien = tipoBien
        producto.tipoItem = "MULT"
        producto.idEmpresa = General.Gempresas.IdEmpresaRuc
        producto.idEstablecimiento = General.GEstableciento.IdEstablecimiento
        producto.tipoExistencia = "01"
        producto.preciocompratipo = "NN"

        If codigo.ToString.Length > 0 Then
            producto.codigo = codigo
        End If

        If codigoInterno.ToString.Length > 0 Then
            producto.codigoInterno = codigoInterno
        End If

        producto.origenProducto = afectacion
        producto.productoRestringido = If(prohibido = "SI" Or prohibido = "S", True, False)
        producto.descripcionItem = productoName
        'producto.presentacion = productoName
        producto.Peso = peso
        producto.unidad1 = "ZZ"
        producto.unidad2 = "0"
        producto.estado = "A"
        producto.usuarioActualizacion = usuario.IDUsuario
        producto.fechaActualizacion = Date.Now

        producto.igv = 18
        producto.preciocompratipo = "FJ"
        producto.precioCompra = 0
        producto.firstpercent = 0
        producto.beforepercent = 0


        'If serie.ToString.Length > 0 Then
        '    producto.talla = serie
        'Else
        '    producto.talla = "SIN DETERMINAR"
        'End If
        'If color.ToString.Length > 0 Then
        '    producto.color = color
        'Else
        '    producto.color = "SIN DETERMINAR"
        'End If
        'If adicional1.ToString.Length > 0 Then
        '    producto.electricidad = adicional1
        'Else
        '    producto.electricidad = "SIN DETERMINAR"
        'End If
        'If adicional2.ToString.Length > 0 Then
        '    producto.transmision = adicional2
        'Else
        '    producto.transmision = "SIN DETERMINAR"
        'End If

        '---------------INGRESO DE TALLA - COLOR - ADICIONAL - ADICIONAL2 ----------------------------

        'ingresando para grabar color
        If color.ToString.Length > 0 Then

            color = LimpiarCadenaNombreFichero(color, "")
            color = Trim(color.ToString.Trim)

            Dim colornuevo = (From i In ListaColorTalla Where i.descripcion = color And i.idtabla = 19).FirstOrDefault

            If colornuevo Is Nothing Then

                conteocolor += 1

                Dim objeto As New tabladetalle
                objeto.idtabla = 19
                objeto.codigoDetalle = conteocolor
                objeto.codigoDetalle2 = "N"
                objeto.descripcion = color
                objeto.estadodetalle = 1
                objeto.fechaModificacion = DateTime.Now
                objeto.usuarioModificacion = 1
                ListaColorTalla.Add(objeto)
            End If


            producto.color = color
        Else
            producto.color = "SIN DETERMINAR"
        End If

        'ingresando para grabar talla
        If serie.ToString.Length > 0 Then

            serie = LimpiarCadenaNombreFichero(serie, "")
            serie = Trim(serie.ToString.Trim)

            Dim tallanuevo = (From i In ListaColorTalla Where i.descripcion = serie And i.idtabla = 18).FirstOrDefault

            If tallanuevo Is Nothing Then

                conteoserie += 1

                Dim objeto As New tabladetalle
                objeto.idtabla = 18
                objeto.codigoDetalle = conteoserie
                objeto.codigoDetalle2 = "N"
                objeto.descripcion = serie
                objeto.estadodetalle = 1
                objeto.fechaModificacion = DateTime.Now
                objeto.usuarioModificacion = 1
                ListaColorTalla.Add(objeto)
            End If
            producto.talla = serie
        Else
            producto.talla = "SIN DETERMINAR"
        End If

        'ingresando para grabar adicional1
        If adicional1.ToString.Length > 0 Then

            adicional1 = LimpiarCadenaNombreFichero(adicional1, "")
            adicional1 = Trim(adicional1.ToString.Trim)

            Dim adicional1nuevo = (From i In ListaColorTalla Where i.descripcion = adicional1 And i.idtabla = 25).FirstOrDefault

            If adicional1nuevo Is Nothing Then

                conteoadicional1 += 1

                Dim objeto As New tabladetalle
                objeto.idtabla = 25
                objeto.codigoDetalle = conteoadicional1
                objeto.codigoDetalle2 = "N"
                objeto.descripcion = adicional1
                objeto.estadodetalle = 1
                objeto.fechaModificacion = DateTime.Now
                objeto.usuarioModificacion = 1
                ListaColorTalla.Add(objeto)
            End If
            producto.electricidad = adicional1
        Else
            producto.electricidad = "SIN DETERMINAR"
        End If

        'ingresando para grabar adicional2
        If adicional2.ToString.Length > 0 Then

            adicional2 = LimpiarCadenaNombreFichero(adicional2, "")
            adicional2 = Trim(adicional2.ToString.Trim)

            Dim adicional2nuevo = (From i In ListaColorTalla Where i.descripcion = adicional2 And i.idtabla = 26).FirstOrDefault

            If adicional2 Is Nothing Then

                conteoadicional2 += 1

                Dim objeto As New tabladetalle
                objeto.idtabla = 26
                objeto.codigoDetalle = conteoadicional2
                objeto.codigoDetalle2 = "N"
                objeto.descripcion = adicional2
                objeto.estadodetalle = 1
                objeto.fechaModificacion = DateTime.Now
                objeto.usuarioModificacion = 1
                ListaColorTalla.Add(objeto)
            End If
            producto.transmision = adicional2
        Else
            producto.transmision = "SIN DETERMINAR"
        End If

        '---------------INGRESO DE CATEGORIA - SUBCATEGORIA----------------------------

        'ingresando categoriaPrincipal para grabar

        If clasificacion.ToString.Length > 0 Then

            clasificacion = LimpiarCadenaNombreFichero(clasificacion, "")
            clasificacion = Trim(clasificacion.ToString.Trim)

            producto.ClasificacionTemporal = clasificacion

            Dim clasificacionnueva = (From i In listaGuardarClasificacion Where i.descripcion = clasificacion And i.tipo = TipoGrupoArticulo.Principal).FirstOrDefault

            If clasificacionnueva Is Nothing Then
                Dim objeto As New item
                objeto.tipo = TipoGrupoArticulo.Principal
                objeto.idEmpresa = Gempresas.IdEmpresaRuc
                objeto.idEstablecimiento = GEstableciento.IdEstablecimiento
                objeto.descripcion = clasificacion
                objeto.fechaIngreso = DateTime.Now
                objeto.utilidad = 0
                objeto.utilidadmayor = 0
                objeto.utilidadgranmayor = 0
                objeto.preciocompratipo = "NN"
                objeto.usuarioActualizacion = usuario.IDUsuario
                objeto.fechaActualizacion = DateTime.Now
                listaGuardarClasificacion.Add(objeto)
            End If

        Else
            Dim catDet = (From i In ListaDeterminado
                          Where i.descripcion = "SIN CLASIFICACION").FirstOrDefault

            If catDet IsNot Nothing Then
                producto.ClasificacionTemporal = "SIN CLASIFICACION"
                producto.idClasificacion = catDet.idItem
            End If
        End If

        'ingresando categoria para grabar
        If categoria.ToString.Length > 0 Then

            categoria = LimpiarCadenaNombreFichero(categoria, "")
            categoria = Trim(categoria.ToString.Trim)

            producto.CategoriaTemporal = categoria

            Dim categorianueva = (From i In listaGuardarCategorias Where i.descripcion = categoria And i.tipo = TipoGrupoArticulo.CategoriaGeneral).FirstOrDefault

            If categorianueva Is Nothing Then
                Dim objeto As New item
                objeto.tipo = TipoGrupoArticulo.CategoriaGeneral
                objeto.idEmpresa = Gempresas.IdEmpresaRuc
                objeto.idEstablecimiento = GEstableciento.IdEstablecimiento
                objeto.descripcion = categoria
                objeto.fechaIngreso = DateTime.Now
                objeto.utilidad = 0
                objeto.utilidadmayor = 0
                objeto.utilidadgranmayor = 0
                objeto.preciocompratipo = "NN"
                objeto.usuarioActualizacion = usuario.IDUsuario
                objeto.fechaActualizacion = DateTime.Now
                objeto.PadreTemportal = clasificacion
                listaGuardarCategorias.Add(objeto)
            End If

        Else
            Dim catDet = (From i In ListaDeterminado
                          Where i.descripcion = "SIN CATEGORIA").FirstOrDefault

            If catDet IsNot Nothing Then
                producto.CategoriaTemporal = "SIN CATEGORIA"
                producto.idItem = catDet.idItem
            End If
        End If


        'ingresando Subcategoria para grabar

        If subcategoria.ToString.Length > 0 Then


            subcategoria = LimpiarCadenaNombreFichero(subcategoria, "")
            subcategoria = Trim(subcategoria.ToString.Trim)


            producto.SubCategoriaTemporal = subcategoria
            Dim subcategorianueva = (From i In listaGuardarSubCategoria Where i.descripcion = subcategoria And i.tipo = TipoGrupoArticulo.SubCategoriaGeneral).FirstOrDefault

            If subcategorianueva Is Nothing Then
                Dim objeto As New item
                objeto.tipo = TipoGrupoArticulo.SubCategoriaGeneral
                objeto.idEmpresa = Gempresas.IdEmpresaRuc
                objeto.idEstablecimiento = GEstableciento.IdEstablecimiento
                objeto.descripcion = subcategoria
                objeto.fechaIngreso = DateTime.Now
                objeto.utilidad = 0
                objeto.utilidadmayor = 0
                objeto.utilidadgranmayor = 0
                objeto.preciocompratipo = "NN"
                objeto.usuarioActualizacion = usuario.IDUsuario
                objeto.fechaActualizacion = DateTime.Now
                objeto.PadreTemportal = categoria
                objeto.preciocompratipo = "NN"
                objeto.precioCompra = 0
                objeto.firstpercent = 0
                objeto.beforepercent = 0
                listaGuardarSubCategoria.Add(objeto)
            End If



        Else

            Dim catDet = (From i In ListaDeterminado
                          Where i.descripcion = "SIN SUBCATEGORIA").FirstOrDefault

            If catDet IsNot Nothing Then
                producto.unidad2 = catDet.idItem
                producto.SubCategoriaTemporal = "SIN SUBCATEGORIA"
            End If

        End If




        'ingresando Marca para grabar
        If marca.ToString.Length > 0 Then

            marca = LimpiarCadenaNombreFichero(marca, "")
            marca = Trim(marca.ToString.Trim)

            If marca = "SIN MARCA" Then

                Dim catDet = (From i In ListaDeterminado
                              Where i.descripcion = "SIN MARCA").FirstOrDefault

                If catDet IsNot Nothing Then
                    producto.marcaRef = catDet.idItem
                    producto.MarcaTemporal = "SIN MARCA"
                End If

            Else

                producto.MarcaTemporal = marca
                Dim marcanueva = (From i In listaGuardarMarca Where i.descripcion = marca And i.tipo = TipoGrupoArticulo.Marca).FirstOrDefault

                If marcanueva Is Nothing Then
                    Dim objeto As New item
                    objeto.tipo = TipoGrupoArticulo.Marca
                    objeto.idEmpresa = Gempresas.IdEmpresaRuc
                    objeto.idEstablecimiento = GEstableciento.IdEstablecimiento
                    objeto.descripcion = marca
                    objeto.fechaIngreso = DateTime.Now
                    objeto.utilidad = 0
                    objeto.utilidadmayor = 0
                    objeto.utilidadgranmayor = 0
                    objeto.preciocompratipo = "NN"
                    objeto.usuarioActualizacion = usuario.IDUsuario
                    objeto.fechaActualizacion = DateTime.Now
                    listaGuardarMarca.Add(objeto)
                End If

            End If

        Else

            Dim catDet = (From i In ListaDeterminado
                          Where i.descripcion = "SIN MARCA").FirstOrDefault

            If catDet IsNot Nothing Then
                producto.marcaRef = catDet.idItem
                producto.MarcaTemporal = "SIN MARCA"
            End If
        End If

        'ingresando Presentacion para grabar

        If presentacion.ToString.Length > 0 Then

            presentacion = LimpiarCadenaNombreFichero(presentacion, "")
            presentacion = Trim(presentacion.ToString.Trim)

            If presentacion = "SIN PRESENTACION" Then

                    Dim catDet = (From i In ListaDeterminado
                                  Where i.descripcion = "SIN PRESENTACION").FirstOrDefault

                    If catDet IsNot Nothing Then
                    producto.idCaracteristica = catDet.idItem
                    producto.PresentacionTemporal = "SIN MARCA"
                    End If

                Else

                    producto.PresentacionTemporal = presentacion
                    Dim presentacionnueva = (From i In listaGuardarPresentacion Where i.descripcion = presentacion And i.tipo = TipoGrupoArticulo.Presentacion).FirstOrDefault

                    If presentacionnueva Is Nothing Then
                        Dim objeto As New item
                        objeto.tipo = TipoGrupoArticulo.Presentacion
                        objeto.idEmpresa = Gempresas.IdEmpresaRuc
                        objeto.idEstablecimiento = GEstableciento.IdEstablecimiento
                        objeto.descripcion = presentacion
                        objeto.fechaIngreso = DateTime.Now
                        objeto.utilidad = 0
                        objeto.preciocompratipo = "NN"
                        objeto.utilidadmayor = 0
                        objeto.utilidadgranmayor = 0
                        objeto.usuarioActualizacion = usuario.IDUsuario
                        objeto.fechaActualizacion = DateTime.Now
                        objeto.PadreTemportal = marca
                        listaGuardarPresentacion.Add(objeto)
                    End If

                End If

            Else

                Dim preDet = (From i In ListaDeterminado
                          Where i.descripcion = "SIN PRESENTACION").FirstOrDefault

            If preDet IsNot Nothing Then
                producto.idCaracteristica = preDet.idItem
                producto.PresentacionTemporal = "SIN PRESENTACION"
            End If
        End If

    End Sub



    'version helios 7
    'Private Sub AllProductGeneral(index As Integer, producto As detalleitems)
    '    'codigo
    '    Dim codigo = dataGrid1.Item(index, 0)
    '    'afectacion
    '    Dim afectacion = dataGrid1.Item(index, 1)
    '    'prohibido
    '    Dim prohibido = dataGrid1.Item(index, 2)


    '    'Categoria
    '    Dim categoria = dataGrid1.Item(index, 3)
    '    'SubCategoria
    '    Dim subcategoria = dataGrid1.Item(index, 4)
    '    'Marca
    '    Dim marca = dataGrid1.Item(index, 5)




    '    'producto
    '    Dim productoName = dataGrid1.Item(index, 6)

    '    productoName = LimpiarCadenaNombreFichero(productoName, "")

    '    If Trim(productoName.ToString).Trim.Length = 0 Then
    '        'MessageBox.Show("Verificar producto", "Validar espacios en blanco, teclas especiales", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Me.Cursor = Cursors.Default
    '        Throw New Exception("Verificar producto, Validar espacios en blanco y teclas especiales")
    '    End If

    '    If Trim(productoName.ToString).Trim.Length > 200 Then
    '        Me.Cursor = Cursors.Default
    '        Throw New Exception("El máximo de catecteres permitido es {200}.")
    '    End If

    '    'serie
    '    Dim serie = dataGrid1.Item(index, 7)



    '    'color
    '    Dim color = dataGrid1.Item(index, 8)








    '    'peso
    '    Dim peso = If(dataGrid1.Item(index, 9).ToString.Trim.Length = 0, "0", dataGrid1.Item(index, 5))

    '    Dim code As Guid
    '    code = Guid.NewGuid
    '    producto.Filtros = code.ToString
    '    producto.idEmpresa = General.Gempresas.IdEmpresaRuc
    '    producto.idEstablecimiento = General.GEstableciento.IdEstablecimiento
    '    producto.tipoExistencia = "01"
    '    producto.codigo = codigo
    '    producto.origenProducto = afectacion
    '    producto.productoRestringido = If(prohibido = "SI" Or prohibido = "S", True, False)
    '    producto.descripcionItem = productoName
    '    producto.presentacion = productoName
    '    producto.Peso = peso
    '    producto.unidad1 = "ZZ"
    '    producto.unidad2 = "0"
    '    producto.estado = "A"
    '    producto.usuarioActualizacion = usuario.IDUsuario
    '    producto.fechaActualizacion = Date.Now
    '    If serie.ToString.Length > 0 Then
    '        producto.talla = serie
    '    End If
    '    If color.ToString.Length > 0 Then
    '        producto.color = color
    '    End If

    '    If categoria.ToString.Length > 0 Then


    '        categoria = LimpiarCadenaNombreFichero(categoria, "")
    '        categoria = Trim(categoria.ToString.Trim)


    '        producto.CategoriaTemporal = categoria


    '        Dim categorianueva = (From i In listaGuardarCategorias Where i.descripcion = categoria And i.tipo = TipoGrupoArticulo.CategoriaGeneral).FirstOrDefault

    '        If categorianueva Is Nothing Then
    '            Dim objeto As New item
    '            objeto.tipo = TipoGrupoArticulo.CategoriaGeneral
    '            objeto.idEmpresa = Gempresas.IdEmpresaRuc
    '            objeto.idEstablecimiento = GEstableciento.IdEstablecimiento
    '            objeto.descripcion = categoria
    '            objeto.fechaIngreso = DateTime.Now
    '            objeto.utilidad = 0
    '            objeto.utilidadmayor = 0
    '            objeto.utilidadgranmayor = 0
    '            objeto.usuarioActualizacion = usuario.IDUsuario
    '            objeto.fechaActualizacion = DateTime.Now
    '            listaGuardarCategorias.Add(objeto)
    '        End If


    '    Else

    '        Dim catDet = (From i In ListaDeterminado
    '                      Where i.descripcion = "SIN CATEGORIA").FirstOrDefault

    '        If catDet IsNot Nothing Then

    '            producto.CategoriaTemporal = "SIN CATEGORIA"
    '            producto.idItem = catDet.idItem

    '        End If


    '    End If







    '    If color.ToString.Length > 0 Then

    '        color = LimpiarCadenaNombreFichero(color, "")
    '        color = Trim(color.ToString.Trim)

    '        Dim colornuevo = (From i In ListaColorTalla Where i.descripcion = color And i.idtabla = 19).FirstOrDefault

    '        If colornuevo Is Nothing Then

    '            conteocolor += 1

    '            Dim objeto As New tabladetalle
    '            objeto.idtabla = 19
    '            objeto.codigoDetalle = conteocolor
    '            objeto.codigoDetalle2 = "N"
    '            objeto.descripcion = color
    '            objeto.estadodetalle = 1
    '            objeto.fechaModificacion = DateTime.Now
    '            objeto.usuarioModificacion = 1
    '            ListaColorTalla.Add(objeto)
    '        End If

    '    End If


    '    If serie.ToString.Length > 0 Then

    '        serie = LimpiarCadenaNombreFichero(serie, "")
    '        serie = Trim(serie.ToString.Trim)

    '        Dim tallanuevo = (From i In ListaColorTalla Where i.descripcion = serie And i.idtabla = 18).FirstOrDefault

    '        If tallanuevo Is Nothing Then

    '            conteoserie += 1

    '            Dim objeto As New tabladetalle
    '            objeto.idtabla = 18
    '            objeto.codigoDetalle = conteoserie
    '            objeto.codigoDetalle2 = "N"
    '            objeto.descripcion = serie
    '            objeto.estadodetalle = 1
    '            objeto.fechaModificacion = DateTime.Now
    '            objeto.usuarioModificacion = 1
    '            ListaColorTalla.Add(objeto)
    '        End If

    '    End If




    '    If subcategoria.ToString.Length > 0 Then


    '        subcategoria = LimpiarCadenaNombreFichero(subcategoria, "")
    '        subcategoria = Trim(subcategoria.ToString.Trim)


    '        producto.SubCategoriaTemporal = subcategoria
    '        Dim subcategorianueva = (From i In listaGuardarSubCategoria Where i.descripcion = subcategoria And i.tipo = TipoGrupoArticulo.SubCategoriaGeneral).FirstOrDefault

    '        If subcategorianueva Is Nothing Then
    '            Dim objeto As New item
    '            objeto.tipo = TipoGrupoArticulo.SubCategoriaGeneral
    '            objeto.idEmpresa = Gempresas.IdEmpresaRuc
    '            objeto.idEstablecimiento = GEstableciento.IdEstablecimiento
    '            objeto.descripcion = subcategoria
    '            objeto.fechaIngreso = DateTime.Now
    '            objeto.utilidad = 0
    '            objeto.utilidadmayor = 0
    '            objeto.utilidadgranmayor = 0
    '            objeto.usuarioActualizacion = usuario.IDUsuario
    '            objeto.fechaActualizacion = DateTime.Now
    '            objeto.PadreTemportal = categoria
    '            listaGuardarSubCategoria.Add(objeto)
    '        End If



    '    Else

    '        Dim catDet = (From i In ListaDeterminado
    '                      Where i.descripcion = "SIN SUBCATEGORIA").FirstOrDefault

    '        If catDet IsNot Nothing Then
    '            producto.unidad2 = catDet.idItem
    '            producto.SubCategoriaTemporal = "SIN SUBCATEGORIA"
    '        End If

    '    End If





    '    If marca.ToString.Length > 0 Then


    '        marca = LimpiarCadenaNombreFichero(marca, "")
    '        marca = Trim(marca.ToString.Trim)

    '        If marca = "SIN MARCA" Then

    '            Dim catDet = (From i In ListaDeterminado
    '                          Where i.descripcion = "SIN MARCA").FirstOrDefault

    '            If catDet IsNot Nothing Then
    '                producto.marcaRef = catDet.idItem
    '                producto.MarcaTemporal = "SIN MARCA"
    '            End If

    '        Else



    '            producto.MarcaTemporal = marca
    '            Dim marcanueva = (From i In listaGuardarMarca Where i.descripcion = marca And i.tipo = TipoGrupoArticulo.Marca).FirstOrDefault

    '            If marcanueva Is Nothing Then
    '                Dim objeto As New item
    '                objeto.tipo = TipoGrupoArticulo.Marca
    '                objeto.idEmpresa = Gempresas.IdEmpresaRuc
    '                objeto.idEstablecimiento = GEstableciento.IdEstablecimiento
    '                objeto.descripcion = marca
    '                objeto.fechaIngreso = DateTime.Now
    '                objeto.utilidad = 0
    '                objeto.utilidadmayor = 0
    '                objeto.utilidadgranmayor = 0
    '                objeto.usuarioActualizacion = usuario.IDUsuario
    '                objeto.fechaActualizacion = DateTime.Now
    '                listaGuardarMarca.Add(objeto)
    '            End If


    '        End If


    '    Else

    '        Dim catDet = (From i In ListaDeterminado
    '                      Where i.descripcion = "SIN MARCA").FirstOrDefault

    '        If catDet IsNot Nothing Then
    '            producto.marcaRef = catDet.idItem
    '            producto.MarcaTemporal = "SIN MARCA"
    '        End If
    '    End If
    'End Sub


    'antiguo

    'Private Sub AllProductGeneral(index As Integer, producto As detalleitems)
    '    'codigo
    '    Dim codigo = dataGrid1.Item(index, 0)
    '    'afectacion
    '    Dim afectacion = dataGrid1.Item(index, 1)
    '    'prohibido
    '    Dim prohibido = dataGrid1.Item(index, 2)
    '    'producto
    '    Dim productoName = dataGrid1.Item(index, 3)

    '    productoName = LimpiarCadenaNombreFichero(productoName, "")

    '    If Trim(productoName.ToString).Trim.Length = 0 Then
    '        'MessageBox.Show("Verificar producto", "Validar espacios en blanco, teclas especiales", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Me.Cursor = Cursors.Default
    '        Throw New Exception("Verificar producto, Validar espacios en blanco y teclas especiales")
    '    End If

    '    If Trim(productoName.ToString).Trim.Length > 200 Then
    '        Me.Cursor = Cursors.Default
    '        Throw New Exception("El máximo de catecteres permitido es {200}.")
    '    End If

    '    'serie
    '    Dim serie = dataGrid1.Item(index, 4)
    '    'peso
    '    Dim peso = If(dataGrid1.Item(index, 5).ToString.Trim.Length = 0, "0", dataGrid1.Item(index, 5))

    '    Dim code As Guid
    '    code = Guid.NewGuid
    '    producto.Filtros = code.ToString
    '    producto.idEmpresa = General.Gempresas.IdEmpresaRuc
    '    producto.idEstablecimiento = General.GEstableciento.IdEstablecimiento
    '    producto.tipoExistencia = "01"
    '    producto.codigo = codigo
    '    producto.origenProducto = afectacion
    '    producto.productoRestringido = If(prohibido = "SI" Or prohibido = "S", True, False)
    '    producto.descripcionItem = productoName
    '    producto.presentacion = productoName
    '    producto.Peso = peso
    '    producto.unidad1 = "ZZ"
    '    producto.unidad2 = "0"
    '    producto.estado = "A"
    '    producto.usuarioActualizacion = usuario.IDUsuario
    '    producto.fechaActualizacion = Date.Now

    'End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim Inventarios = listaProductosGrabados.ToList()
            Dim rows = listaProductosGrabados.ToList.Count
            Dim paginado = 400
            Dim numeroPaginas = rows / paginado
            Dim ParteEntera = Int(numeroPaginas)
            Dim ParteDecimal = numeroPaginas - ParteEntera
            If ParteDecimal > 0 Then
                ParteDecimal = 1
            End If
            Dim SumSkips = 0
            '---------------------------------------------------------
            For i = 1 To ParteEntera
                If i = 1 Then
                    Dim t = Inventarios.Take(paginado).ToList
                    SumSkips += paginado
                    GrabarCompra(t)
                Else
                    Dim t = Inventarios.Skip(SumSkips).Take(paginado).ToList
                    SumSkips += paginado
                    GrabarCompra(t)
                End If
            Next

            For i = 1 To ParteDecimal
                Dim t = Inventarios.Skip(SumSkips).ToList
                GrabarCompra(t)
            Next

            If FormMaestroLogistica IsNot Nothing Then
                FormMaestroLogistica.ThreadTransito()
            End If
            MsgBox("Registros grabados")
            '  GrabarCompra()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

#End Region

#Region "Methods"
    Private Sub GrabarCompra()
        Dim compraSA As New DocumentoCompraSA
        Dim obj As New documento
        obj = MappingDocumento()
        MappingDocumentoCompraCabecera(obj)
        MappingDocumentoCompraCabeceraDetalle(obj)
        compraSA.GrabarAporteGeneral(obj)
        MessageBox.Show("Compra registrada!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If FormMaestroLogistica IsNot Nothing Then
            FormMaestroLogistica.ThreadTransito()
        End If
        Close()
    End Sub

    Private Sub GrabarCompra(t As List(Of detalleitems))
        Dim compraSA As New DocumentoCompraSA
        Dim obj As New documento
        obj = MappingDocumento()
        MappingDocumentoCompraCabecera(obj)
        MappingDocumentoCompraCabeceraDetalleV2(obj, t)
        compraSA.GrabarAporteGeneral(obj)
        'MessageBox.Show("Compra registrada!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'If FormMaestroLogistica IsNot Nothing Then
        '    FormMaestroLogistica.ThreadTransito()
        'End If
        'Close()
    End Sub

    Private Sub MappingDocumentoCompraCabeceraDetalle(obj As documento)
        Dim objDet As documentocompradetalle

        For Each i In listaProductosGrabados

            Dim prod = listaProductos.Where(Function(o) o.Filtros = i.Filtros).SingleOrDefault
            Dim listaEquivalencias = prod.detalleitem_equivalencias.ToList

            Dim stockTotal As Decimal = 0 'listaEquivalencias.Sum(Function(o) o.Stock)

            For Each j In listaEquivalencias
                stockTotal += j.Stock
            Next

            Dim CostoTotal = listaEquivalencias.Sum(Function(o) o.CostoTotal)


            '  For Each eq In i.detalleitem_equivalencias
            objDet = New documentocompradetalle With
                {
                .CustomListaInventarioMovimiento = AddInventarioMovimiento(i, stockTotal, CostoTotal),
                .CustomProducto = i,
                .equivalencia_id = 0,
                .idItem = i.codigodetalle,
                .descripcionItem = i.descripcionItem,
                .tipoExistencia = i.tipoExistencia,
                .destino = i.origenProducto,
                .unidad1 = i.unidad1,
                .monto1 = stockTotal,
                .unidad2 = Nothing,
                .monto2 = 0,
                .precioUnitario = 0,
                .precioUnitarioUS = 0,
                .importe = CostoTotal,
                .importeUS = 0,
                .montokardex = CostoTotal,
                .montoIsc = 0,
                .montoIgv = 0,
                .otrosTributos = 0,
                .montokardexUS = 0,
                .montoIscUS = 0,
                .montoIgvUS = 0,
                .otrosTributosUS = 0,
                .percepcionMN = 0,
                .percepcionME = 0,
                .bonificacion = "N",
                .nrolote = "-",
                .almacenRef = Integer.Parse(cboAlmacen.SelectedValue),
                .entregable = "N",
                .estadoPago = "PG",
                .ItemEntregadototal = "E",
                .usuarioModificacion = usuario.IDUsuario,
                .fechaModificacion = Date.Now
                }
            obj.documentocompra.documentocompradetalle.Add(objDet)
            '  Next


        Next
    End Sub

    Private Sub MappingDocumentoCompraCabeceraDetalleV2(obj As documento, ListaProductosPagina As List(Of detalleitems))
        Dim objDet As documentocompradetalle

        For Each i In ListaProductosPagina

            Dim prod = listaProductos.Where(Function(o) o.Filtros = i.Filtros).SingleOrDefault
            Dim listaEquivalencias = prod.detalleitem_equivalencias.ToList

            Dim stockTotal As Decimal = 0 'listaEquivalencias.Sum(Function(o) o.Stock)

            For Each j In listaEquivalencias
                stockTotal += j.Stock
            Next

            Dim CostoTotal As Decimal = listaEquivalencias.Sum(Function(o) o.CostoTotal)

            'Select Case i.origenProducto
            '    Case OperacionGravada.Grabado
            '        CostoTotal = Math.Round(CDec(CalculoBaseImponible(CostoTotal, 1.18)), 2)
            '    Case OperacionGravada.Inafecto, OperacionGravada.Exonerado
            '        CostoTotal = CostoTotal
            'End Select

            '  For Each eq In i.detalleitem_equivalencias
            objDet = New documentocompradetalle With
                {
                .CustomListaInventarioMovimiento = AddInventarioMovimiento(i, stockTotal, CostoTotal),
                .CustomProducto = i,
                .equivalencia_id = 0,
                .idItem = i.codigodetalle,
                .descripcionItem = i.descripcionItem,
                .tipoExistencia = i.tipoExistencia,
                .destino = i.origenProducto,
                .unidad1 = i.unidad1,
                .monto1 = stockTotal,
                .unidad2 = Nothing,
                .monto2 = 0,
                .precioUnitario = 0,
                .precioUnitarioUS = 0,
                .importe = CostoTotal,
                .importeUS = 0,
                .montokardex = CostoTotal,
                .montoIsc = 0,
                .montoIgv = 0,
                .otrosTributos = 0,
                .montokardexUS = 0,
                .montoIscUS = 0,
                .montoIgvUS = 0,
                .otrosTributosUS = 0,
                .percepcionMN = 0,
                .percepcionME = 0,
                .bonificacion = "N",
                .nrolote = "-",
                .almacenRef = Integer.Parse(cboAlmacen.SelectedValue),
                .entregable = "N",
                .estadoPago = "PG",
                .ItemEntregadototal = "E",
                .usuarioModificacion = usuario.IDUsuario,
                .fechaModificacion = Date.Now
                }
            obj.documentocompra.documentocompradetalle.Add(objDet)
            '  Next


        Next
    End Sub

    Private Function AddInventarioMovimiento(i As detalleitems, stock As Decimal, costoTotal As Decimal) As List(Of InventarioMovimiento)
        Dim cantidad As Decimal = stock

        '    Dim prod = listaProductosGrabados.Where(Function(o) o.Filtros = i.Filtros).SingleOrDefault

        Dim totalcosto As Decimal = costoTotal

        Return New List(Of InventarioMovimiento) From
            {
            New InventarioMovimiento With
                {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .idAlmacen = cboAlmacen.SelectedValue,
        .nrolote = 0,
        .tipoOperacion = StatusTipoOperacion.SALDO_INICIAL_O_CIERRES,
        .tipoDocAlmacen = "99",
        .serie = "1",
        .numero = "1",
        .descripcion = i.descripcionItem,
        .fechaLaboral = Date.Now,
        .fecha = Date.Now,
        .tipoRegistro = "E",
        .destinoGravadoItem = i.origenProducto,
        .tipoProducto = i.tipoExistencia,
        .OrigentipoProducto = "N",
        .idItem = i.codigodetalle,
        .cantidad = cantidad,
        .unidad = i.unidad1,
        .cantidad2 = 0,
        .unidad2 = "-",
        .precUnite = 0,
        .precUniteUSD = 0,
        .monto = totalcosto,
        .montoUSD = 0,
        .disponible = 0,
        .status = "E",
        .entragado = "S",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
            }
    End Function

    Private Function MappingDocumento() As documento
        Dim fechaCompra = DateTime.Now

        Dim NUMERO_DOC As String = String.Empty
        Dim OPERACION_DOC As String = String.Empty
        NUMERO_DOC = "0"
        OPERACION_DOC = StatusTipoOperacion.SALDO_INICIAL_O_CIERRES

        MappingDocumento = New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idProyecto = 0,
        .tipoDoc = "9907",
        .fechaProceso = fechaCompra,
        .moneda = "1",
        .idEntidad = VarClienteGeneral.idEntidad,
        .entidad = "VARIOS",
        .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR,
        .nrodocEntidad = "-",
        .nroDoc = NUMERO_DOC,
        .idOrden = 0,
        .tipoOperacion = OPERACION_DOC,
        .IdPerfil = usuario.IDRol,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
    End Function

    Private Sub MappingDocumentoCompraCabecera(be As documento)
        Dim base1 As Decimal = 0
        Dim base2 As Decimal = 0

        Dim base1ME As Decimal = 0
        Dim base2ME As Decimal = 0

        Dim iva1 As Decimal = 0
        Dim iva1ME As Decimal = 0
        Dim iva2 As Decimal = 0
        Dim total As Decimal = 0 ' 
        Dim totalME As Decimal = 0 ' UCEstructuraDocumentocabecera.txtTotalPagar.DecimalValue

        Dim TIPOCOMPRA As String = String.Empty

        TIPOCOMPRA = TIPO_COMPRA.APORTE_INICIAL

        Select Case be.moneda
            Case "1"
                base1 = 0
                base2 = 0
                base1ME = 0
                base2ME = 0
                iva1 = 0
                iva1ME = 0

                total = 0
                totalME = 0
            Case "2"

                base1ME = 0
                base2ME = 0

                base1 = 0
                base2 = 0

                iva1ME = 0
                iva1 = 0

                totalME = 0
                total = 0
        End Select

        Dim obj As New documentocompra With
        {
        .codigoLibro = "8",
        .idEmpresa = be.idEmpresa,
        .idCentroCosto = be.idCentroCosto,
        .fechaLaboral = Date.Now,
        .fechaDoc = be.fechaProceso,
        .fechaVcto = Nothing,
        .fechaContable = GetPeriodo(be.fechaProceso, True),
        .tipoDoc = be.tipoDoc,
        .serie = "1",
        .numeroDoc = "0",
        .idProveedor = be.idEntidad,
        .monedaDoc = be.moneda,
        .tasaIgv = 0,
        .tcDolLoc = 1,
        .tipocambio = 1,
        .bi01 = base1,
        .bi02 = base2,
        .bi03 = 0,
        .bi04 = 0,
        .isc01 = 0,
        .isc02 = 0,
        .isc03 = 0,
        .igv01 = iva1,
        .igv02 = 0,
        .igv03 = 0,
        .otc01 = 0,
        .otc02 = 0,
        .otc03 = 0,
        .otc04 = 0,
        .bi01us = base1ME,
        .bi02us = base2ME,
        .bi03us = 0,
        .bi04us = 0,
        .isc01us = 0,
        .isc02us = 0,
        .isc03us = 0,
        .igv01us = iva1ME,
        .igv02us = 0,
        .igv03us = 0,
        .otc01us = 0,
        .otc02us = 0,
        .otc03us = 0,
        .otc04us = 0,
        .percepcion = 0,
        .percepcionus = 0,
        .importeTotal = total,
        .importeUS = totalME,
        .destino = TIPOCOMPRA,
        .estadoPago = TIPO_COMPRA.PAGO.PAGADO,
        .glosa = "Entrada de mercadería INICIAL",
        .TIPOCOMPRA = TIPOCOMPRA,
        .sustentado = "S",
        .idPadre = 0,
        .aprobado = "S",
        .apruebaPago = "S",
        .tieneDetraccion = "N",
        .situacion = statusComprobantes.Normal,
        .estadoEntrega = "1",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        be.documentocompra = obj
        be.documentocompra.documentocompradetalle = New List(Of documentocompradetalle)
    End Sub
#End Region
End Class
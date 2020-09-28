Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.GroupingGridExcelConverter
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmServicioPrecios
    Implements IBusquedaAvanzadaProductos


#Region "Attributes"
    Public Property EstadoManipulacion() As String
    Dim listaSubCategoria As New List(Of itemServicio)
    Dim listaUM As New List(Of tabladetalle)

    Dim itemSA As New detalleitemsSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.WindowState = FormWindowState.Normal
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvExistencias, False, 11.0F)
        'FormatoGridPequeño(dgvExistencias, False)
        FormatoGridPequeño(GridGroupingControl2, True)
        GetTableGrid()

        txtSubCategoria.Text = "SIN DETERMINAR"
        txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        txtSubCategoria.Tag = 1
    End Sub
#End Region

    Public Sub New(producto As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        FormatoGridPequeño(dgvExistencias, False, 11.0F)
        'FormatoGridPequeño(dgvExistencias, False)
        FormatoGridPequeño(GridGroupingControl2, True)

    End Sub

#Region "Methods"

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idItem", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("clasificacion", GetType(String))
        dt.Columns.Add("marca", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("codigoBarra", GetType(Integer))
        dt.Columns.Add("menor", GetType(Decimal))
        dt.Columns.Add("menorME", GetType(Decimal))
        dt.Columns.Add("mayor", GetType(Decimal))
        dt.Columns.Add("mayorME", GetType(Decimal))
        dt.Columns.Add("gmayor", GetType(Decimal))
        dt.Columns.Add("gmayorME", GetType(Decimal))

        dgvExistencias.DataSource = dt

    End Sub

    Public Sub GrabarItemServicio()
        Dim objitem As New servicio
        Dim listaServicio As New List(Of servicio)
        'Dim objitem As New detalleitems
        Dim itemSA As New servicioSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'Dim c As New RecuperarCarteras
        Try
            'Se asigna cada uno de los datos registrados

            For Each r As Record In dgvExistencias.Table.Records
                objitem = New servicio
                objitem.idItemServicio = txtSubCategoria.Tag
                objitem.idEmpresa = Gempresas.IdEmpresaRuc
                objitem.idEstablecimiento = CInt(GEstableciento.IdEstablecimiento)  ' frmCanastaExistencias.cboEstablecimiento.SelectedValue)
                objitem.idPadre = 0
                objitem.fecha = DateTime.Now
                objitem.tipo = "C"
                objitem.tipoExist = "GS"
                objitem.tipoServicio = "SP"
                objitem.costo = "DIARIO"
                objitem.valor = 0
                objitem.categoria = CInt(txtCategoria.Tag)
                objitem.subCategoria = txtSubCategoria.Tag
                objitem.cuenta = "74111"
                objitem.observaciones = "INGRESO DE SERVICIO BASICO CON FECHA " & Date.Now
                objitem.estado = "A"
                objitem.usuarioActualizacion = usuario.IDUsuario
                objitem.fechaActualizacion = Date.Now

                objitem.unidadMedida = r.GetValue("marca").ToString
                If (r.GetValue("descripcion").ToString = "") Then
                    Throw New Exception("Debe ingresar una descripcion")
                Else
                    objitem.descripcion = r.GetValue("descripcion")
                End If

                Select Case r.GetValue("gravado")
                    Case "1"
                        objitem.codigo = OperacionGravada.Grabado
                    Case "2"
                        objitem.codigo = OperacionGravada.Exonerado
                    Case "3"
                        objitem.codigo = OperacionGravada.Inafecto
                End Select

                'Precios
                objitem.CustomPrecios = New List(Of configuracionPrecioProducto)
                objitem.CustomPrecios.Add(New configuracionPrecioProducto With {.fecha = DateTime.Now, .tipo = 1,
                                      .idPrecio = 1, .descripcion = "Precio por Menor", .precioMN = r.GetValue("menor"), .precioME = 0.00, .tipoModalidad = "GS"})

                objitem.CustomPrecios.Add(New configuracionPrecioProducto With {.fecha = DateTime.Now, .tipo = 1,
                                      .idPrecio = 2, .descripcion = "Precio por Mayor", .precioMN = r.GetValue("mayor"), .precioME = 0.00, .tipoModalidad = "GS"})

                objitem.CustomPrecios.Add(New configuracionPrecioProducto With {.fecha = DateTime.Now, .tipo = 1,
                                      .idPrecio = 3, .descripcion = "Precio por Gran Mayor", .precioMN = r.GetValue("gmayor"), .precioME = 0.00, .tipoModalidad = "GS"})


                listaServicio.Add(objitem)
            Next


            Dim codxIdtem As Integer = itemSA.InsertItemServicio(listaServicio)
            '  Me.lblEstado.Text = "Item registrado!"
            'c.Cuenta = "Grabado"
            'c.ID = codxIdtem
            'c.IdEvento = txtSubCategoria.Tag
            'c.NomEvento = txtSubCategoria.Text
            'datos.Add(c)
            '---------------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------------
            'If (MessageBox.Show("Desea asignar el precio ahora ?", "Precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            '    Dim form As New frmExistenciaPrecios(txtProductoNew.Text.Trim)
            '    form.StartPosition = FormStartPosition.CenterParent
            '    form.ShowDialog(Me)
            'End If
            '---------------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------------
            Dispose()

        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            MessageBox.Show("La existencia ingresada tiene un codigo que ya esta siendo utilizada cambie el codigo", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Sub Productoshijos()
        Dim categoriaSA As New itemServicioSA

        Dim lista = categoriaSA.GetListaItemsPorTipo(New itemServicio With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .tipo = "M"
                                                             })

        listaSubCategoria = New List(Of itemServicio)
        listaSubCategoria.Add(New itemServicio With {
                              .idItemServicio = 0, .descripcion = "SIN DETERMINAR"})
        listaSubCategoria.AddRange(lista)

        'Label43.Text = listaSubCategoria.Count & " items"
        'categoriaSA.GetListaMarcaPadre(Val(txtCategoria.Tag))
    End Sub

    Dim listaCategoria As New List(Of itemServicio)
    Private Sub CMBClasificacion()
        Dim categoriaSA As New itemServicioSA
        ' categoriaSA.GetListaPadre()
        listaCategoria = New List(Of itemServicio)
        listaCategoria = categoriaSA.GetListaItemsPorTipo(New itemServicio With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .tipo = TipoGrupoArticulo.CategoriaGeneral
                                                          })

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

    Private Sub GetExistenciasNombre(nombre As String)
        Dim itemSA As New detalleitemsSA
        Dim TipoExistencia() As String = {Constantes.TipoExistencia.Mercaderia, Constantes.TipoExistencia.ProductoTerminado, Constantes.TipoExistencia.SubProductosDesechos}

        Dim dt As New DataTable("Precios Generales")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        dt.Columns.Add(New DataColumn("menor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("menorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayorME", GetType(Decimal)))
        dt.Columns.Add("ultimacompra")
        dt.Columns.Add("ultimacompraConIGV")
        dt.Columns.Add("precRef")
        dt.Columns.Add("init")
        dt.Columns.Add("coninit")
        dt.Columns.Add("sel")

        Dim NuevaDescripcion As String = String.Empty
        Dim delimitadores() As String = {" "}
        Dim vectoraux() As String
        vectoraux = nombre.Split(delimitadores, StringSplitOptions.None)

        'mostrar resultado
        For Each item As String In vectoraux
            NuevaDescripcion += item & "%"
        Next

        For Each i In itemSA.GetExistenciasByempresaNombreFull(Gempresas.IdEmpresaRuc, NuevaDescripcion).Where(Function(o) TipoExistencia.Contains(o.tipoExistencia)).ToList
            'For Each i In itemSA.GetExistenciasByempresaNombre(nombre).Where(Function(o) TipoExistencia.Contains(o.tipoExistencia)).ToList
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = (i.codigo & "   " & "-" & "   " & i.descripcionItem)
            dr(2) = i.NomClasificacion
            dr(3) = i.unidad1 'i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.NomMarca ' i.codigo
            dr(7) = i.precioMenor
            dr(8) = i.precioMenorME.GetValueOrDefault

            dr(9) = i.precioMayor
            dr(10) = i.precioMayorME.GetValueOrDefault

            dr(11) = i.precioGranMayor
            dr(12) = i.precioGranMayorME.GetValueOrDefault
            'If i.CustomTotalAlmacen IsNot Nothing Then
            '    Dim valPrecUnitarioSinIGV As Decimal = CDec(i.CustomTotalAlmacen.importeSoles) / CDec(i.CustomTotalAlmacen.cantidad)

            '    Dim precioCompraConIva As Decimal = 0
            '    If i.CustomTotalAlmacen.origenRecaudo = 1 Then
            '        precioCompraConIva = valPrecUnitarioSinIGV + (valPrecUnitarioSinIGV * 0.18)
            '    Else
            '        precioCompraConIva = valPrecUnitarioSinIGV
            '    End If

            '    dr(10) = valPrecUnitarioSinIGV
            '    dr(11) = precioCompraConIva
            'End If
            ' dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault ' i.precioCompra.GetValueOrDefault
            If i.CustomDetalleCompra IsNot Nothing Then
                If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                    If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalSinIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    Else

                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim iva = precioTotalConIva2 * 0.18
                                precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva2).ToString("N2") '0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = 0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    End If

                End If
            End If

            If i.InventarioInicio IsNot Nothing Then
                'Select Case i.CustomDetalleCompra.destino
                '    Case 1
                If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                                 i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then

                    Dim precioSinIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2)

                    Dim precioConIva = (precioSinIva * 0.18) + precioSinIva


                    dr(16) = Math.Round(precioSinIva, 2)
                    dr(17) = Math.Round(precioConIva, 2)
                Else
                    dr(16) = 0
                    dr(17) = 0
                End If
                '    Case Else
                '        'If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                '        '    i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then
                '        '    Dim precioConIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2) * 0.18
                '        '    precioConIva = Math.Round(precioConIva + i.InventarioInicio.importeMN.GetValueOrDefault, 2)
                '        '    dr(13) = precioConIva
                '        'Else
                '        '    dr(13) = 0
                '        'End If

                'End Select

            End If
            dr(18) = False
            dt.Rows.Add(dr)
        Next

        If Me.dgvExistencias.Table.Records.Count <= 0 Then
            '  MessageBox.Show("El nombre del producto ingresado no existe", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
        End If


        Me.dgvExistencias.DataSource = dt
        Me.dgvExistencias.Engine.BindToCurrencyManager = False

        Me.dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvExistencias.TopLevelGroupOptions.ShowCaption = True
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

        dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    ''' <summary>
    ''' Buscar producto por coincidencia
    ''' </summary>
    ''' <param name="nombre"></param>
    Private Sub GetExistenciasNombreContains(empresa As String, tipo As String, nombre As String)
        Dim itemSA As New detalleitemsSA
        Dim TipoExistencia() As String = {Constantes.TipoExistencia.Mercaderia, Constantes.TipoExistencia.ProductoTerminado, Constantes.TipoExistencia.SubProductosDesechos}

        Dim dt As New DataTable("Precios Generales")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        dt.Columns.Add(New DataColumn("menor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("menorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayorME", GetType(Decimal)))
        dt.Columns.Add("ultimacompra")
        dt.Columns.Add("ultimacompraConIGV")
        dt.Columns.Add("precRef")
        dt.Columns.Add("init")
        dt.Columns.Add("coninit")
        dt.Columns.Add("sel")

        Dim productos = itemSA.GetDetalleItemsXEmpresa(empresa, GEstableciento.IdEstablecimiento, tipo, nombre)


        For Each i In productos 'itemSA.GetExistenciasByempresaNombreFull(Gempresas.IdEmpresaRuc, NuevaDescripcion).Where(Function(o) TipoExistencia.Contains(o.tipoExistencia)).ToList
            'For Each i In itemSA.GetExistenciasByempresaNombre(nombre).Where(Function(o) TipoExistencia.Contains(o.tipoExistencia)).ToList
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = (i.codigo & "   " & "-" & "   " & i.descripcionItem)
            dr(2) = i.NomClasificacion
            dr(3) = i.unidad1 'i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.NomMarca ' i.codigo
            dr(7) = i.precioMenor
            dr(8) = i.precioMenorME.GetValueOrDefault

            dr(9) = i.precioMayor
            dr(10) = i.precioMayorME.GetValueOrDefault

            dr(11) = i.precioGranMayor
            dr(12) = i.precioGranMayorME.GetValueOrDefault
            'If i.CustomTotalAlmacen IsNot Nothing Then
            '    Dim valPrecUnitarioSinIGV As Decimal = CDec(i.CustomTotalAlmacen.importeSoles) / CDec(i.CustomTotalAlmacen.cantidad)

            '    Dim precioCompraConIva As Decimal = 0
            '    If i.CustomTotalAlmacen.origenRecaudo = 1 Then
            '        precioCompraConIva = valPrecUnitarioSinIGV + (valPrecUnitarioSinIGV * 0.18)
            '    Else
            '        precioCompraConIva = valPrecUnitarioSinIGV
            '    End If

            '    dr(10) = valPrecUnitarioSinIGV
            '    dr(11) = precioCompraConIva
            'End If
            ' dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault ' i.precioCompra.GetValueOrDefault
            If i.CustomDetalleCompra IsNot Nothing Then
                If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                    If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalSinIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    Else

                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim iva = precioTotalConIva2 * 0.18
                                precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva2).ToString("N2") '0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = 0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    End If

                End If
            End If

            If i.InventarioInicio IsNot Nothing Then
                'Select Case i.CustomDetalleCompra.destino
                '    Case 1
                If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                                 i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then

                    Dim precioSinIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2)

                    Dim precioConIva = (precioSinIva * 0.18) + precioSinIva


                    dr(16) = Math.Round(precioSinIva, 2)
                    dr(17) = Math.Round(precioConIva, 2)
                Else
                    dr(16) = 0
                    dr(17) = 0
                End If
                '    Case Else
                '        'If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                '        '    i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then
                '        '    Dim precioConIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2) * 0.18
                '        '    precioConIva = Math.Round(precioConIva + i.InventarioInicio.importeMN.GetValueOrDefault, 2)
                '        '    dr(13) = precioConIva
                '        'Else
                '        '    dr(13) = 0
                '        'End If

                'End Select

            End If
            dr(18) = False
            dt.Rows.Add(dr)
        Next

        If Me.dgvExistencias.Table.Records.Count <= 0 Then
            '  MessageBox.Show("El nombre del producto ingresado no existe", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
        End If


        Me.dgvExistencias.DataSource = dt
        Me.dgvExistencias.Engine.BindToCurrencyManager = False

        Me.dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvExistencias.TopLevelGroupOptions.ShowCaption = True
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

        dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Private Sub GetExistenciasCodigoBarra(codigobarra As String)
        Dim dt As New DataTable("Precios Generales")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        dt.Columns.Add(New DataColumn("menor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("menorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayorME", GetType(Decimal)))
        dt.Columns.Add("ultimacompra")
        dt.Columns.Add("ultimacompraConIGV")
        dt.Columns.Add("precRef")
        dt.Columns.Add("init")
        dt.Columns.Add("coninit")
        dt.Columns.Add("sel")
        For Each i In itemSA.GetExistenciasByempresaCodigo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, codigobarra)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = (i.codigo & "   " & "-" & "   " & i.descripcionItem)
            dr(2) = i.NomClasificacion
            dr(3) = i.unidad1 'i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.NomMarca ' i.codigo
            dr(7) = i.precioMenor
            dr(8) = i.precioMenorME.GetValueOrDefault

            dr(9) = i.precioMayor
            dr(10) = i.precioMayorME.GetValueOrDefault

            dr(11) = i.precioGranMayor
            dr(12) = i.precioGranMayorME.GetValueOrDefault
            'If i.CustomTotalAlmacen IsNot Nothing Then
            '    Dim valPrecUnitarioSinIGV As Decimal = CDec(i.CustomTotalAlmacen.importeSoles) / CDec(i.CustomTotalAlmacen.cantidad)

            '    Dim precioCompraConIva As Decimal = 0
            '    If i.CustomTotalAlmacen.origenRecaudo = 1 Then
            '        precioCompraConIva = valPrecUnitarioSinIGV + (valPrecUnitarioSinIGV * 0.18)
            '    Else
            '        precioCompraConIva = valPrecUnitarioSinIGV
            '    End If

            '    dr(10) = valPrecUnitarioSinIGV
            '    dr(11) = precioCompraConIva
            'End If
            ' dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault ' i.precioCompra.GetValueOrDefault
            If i.CustomDetalleCompra IsNot Nothing Then
                If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                    If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalSinIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    Else

                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim iva = precioTotalConIva2 * 0.18
                                precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva2).ToString("N2") '0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = 0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    End If

                End If
            End If

            If i.InventarioInicio IsNot Nothing Then
                'Select Case i.CustomDetalleCompra.destino
                '    Case 1
                If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                                 i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then

                    Dim precioSinIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2)

                    Dim precioConIva = (precioSinIva * 0.18) + precioSinIva


                    dr(16) = Math.Round(precioSinIva, 2)
                    dr(17) = Math.Round(precioConIva, 2)
                Else
                    dr(16) = 0
                    dr(17) = 0
                End If
                '    Case Else
                '        'If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                '        '    i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then
                '        '    Dim precioConIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2) * 0.18
                '        '    precioConIva = Math.Round(precioConIva + i.InventarioInicio.importeMN.GetValueOrDefault, 2)
                '        '    dr(13) = precioConIva
                '        'Else
                '        '    dr(13) = 0
                '        'End If

                'End Select

            End If
            dr(18) = False
            dt.Rows.Add(dr)
        Next

        If Me.dgvExistencias.Table.Records.Count <= 0 Then
            '  MessageBox.Show("El nombre del producto ingresado no existe", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
        End If


        Me.dgvExistencias.DataSource = dt
        Me.dgvExistencias.Engine.BindToCurrencyManager = False

        Me.dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvExistencias.TopLevelGroupOptions.ShowCaption = True
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.One
        If Me.dgvExistencias.Table.Records.Count <= 0 Then
            MessageBox.Show("El codigo ingresado no Existe", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub GetPreciosXMarca(marca As String)
        Dim TipoExistencia() As String =
            {
            Constantes.TipoExistencia.Mercaderia,
            Constantes.TipoExistencia.ProductoTerminado,
            Constantes.TipoExistencia.SubProductosDesechos
        }

        Dim dt As New DataTable("Precios Generales")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        dt.Columns.Add(New DataColumn("menor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("menorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayorME", GetType(Decimal)))
        dt.Columns.Add("ultimacompra")
        dt.Columns.Add("ultimacompraConIGV")
        dt.Columns.Add("precRef")
        dt.Columns.Add("init")
        dt.Columns.Add("coninit")
        dt.Columns.Add("sel")

        Dim lista = itemSA.GetProductosBusquedaPersonalizada(New detalleitems With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .unidad2 = marca
                                                             }, "MARCA")

        For Each i In lista

            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = (i.codigo & "   " & "-" & "   " & i.descripcionItem)
            dr(2) = i.NomClasificacion
            dr(3) = i.unidad1 'i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.NomMarca ' i.codigo
            dr(7) = i.precioMenor
            dr(8) = i.precioMenorME

            dr(9) = i.precioMayor
            dr(10) = i.precioMayorME

            dr(11) = i.precioGranMayor
            dr(12) = i.precioGranMayorME
            'If i.CustomTotalAlmacen IsNot Nothing Then
            '    Dim valPrecUnitarioSinIGV As Decimal = CDec(i.CustomTotalAlmacen.importeSoles) / CDec(i.CustomTotalAlmacen.cantidad)

            '    Dim precioCompraConIva As Decimal = 0
            '    If i.CustomTotalAlmacen.origenRecaudo = 1 Then
            '        precioCompraConIva = valPrecUnitarioSinIGV + (valPrecUnitarioSinIGV * 0.18)
            '    Else
            '        precioCompraConIva = valPrecUnitarioSinIGV
            '    End If

            '    dr(10) = valPrecUnitarioSinIGV
            '    dr(11) = precioCompraConIva
            'End If
            dr(15) = i.precioCompra.GetValueOrDefault
            If i.CustomDetalleCompra IsNot Nothing Then
                If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                    If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = precioTotalSinIva
                                dr(14) = precioTotalConIva
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = precioTotalConIva
                                dr(14) = precioTotalConIva
                        End Select

                    Else

                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim iva = precioTotalConIva2 * 0.18
                                precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                dr(13) = precioTotalConIva
                                dr(14) = precioTotalConIva2 '0 'precioTotalConIva
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = precioTotalConIva
                                dr(14) = 0 'precioTotalConIva
                        End Select

                    End If

                End If
            End If

            If i.InventarioInicio IsNot Nothing Then
                'Select Case i.CustomDetalleCompra.destino
                '    Case 1
                If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                                 i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then

                    Dim precioSinIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2)

                    Dim precioConIva = (precioSinIva * 0.18) + precioSinIva


                    dr(16) = Math.Round(precioSinIva, 2)
                    dr(17) = Math.Round(precioConIva, 2)
                Else
                    dr(16) = 0
                    dr(17) = 0
                End If
                '    Case Else
                '        'If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                '        '    i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then
                '        '    Dim precioConIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2) * 0.18
                '        '    precioConIva = Math.Round(precioConIva + i.InventarioInicio.importeMN.GetValueOrDefault, 2)
                '        '    dr(13) = precioConIva
                '        'Else
                '        '    dr(13) = 0
                '        'End If

                'End Select

            End If
            dr(18) = False
            dt.Rows.Add(dr)
        Next

        dgvExistencias.DataSource = dt
        dgvExistencias.Engine.BindToCurrencyManager = False
        dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgvExistencias.TopLevelGroupOptions.ShowCaption = True
        dgvExistencias.ShowRowHeaders = True
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvExistencias.TableDescriptor.Columns("menorME").ReadOnly = False
        dgvExistencias.TableDescriptor.Columns("mayorME").ReadOnly = False
        dgvExistencias.TableDescriptor.Columns("gmayorME").ReadOnly = False
        'dgvExistencias.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FCEEE9")
    End Sub

    Private Sub GetPreciosXGrupo(IDCAT As Integer)
        Dim TipoExistencia() As String =
            {
            Constantes.TipoExistencia.Mercaderia,
            Constantes.TipoExistencia.ProductoTerminado,
            Constantes.TipoExistencia.SubProductosDesechos
        }

        Dim dt As New DataTable("Precios Generales")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        dt.Columns.Add(New DataColumn("menor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("menorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayorME", GetType(Decimal)))
        dt.Columns.Add("ultimacompra")
        dt.Columns.Add("ultimacompraConIGV")
        dt.Columns.Add("precRef")
        dt.Columns.Add("init")
        dt.Columns.Add("coninit")
        dt.Columns.Add("sel")

        Dim lista = itemSA.GetProductosBusquedaPersonalizada(New detalleitems With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idItem = IDCAT
                                                             }, "CLASIFICACION")

        For Each i In lista

            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = (i.codigo & "   " & "-" & "   " & i.descripcionItem)
            dr(2) = i.NomClasificacion
            dr(3) = i.unidad1 'i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.NomMarca ' i.codigo
            dr(7) = i.precioMenor
            dr(8) = i.precioMenorME

            dr(9) = i.precioMayor
            dr(10) = i.precioMayorME

            dr(11) = i.precioGranMayor
            dr(12) = i.precioGranMayorME
            'If i.CustomTotalAlmacen IsNot Nothing Then
            '    Dim valPrecUnitarioSinIGV As Decimal = CDec(i.CustomTotalAlmacen.importeSoles) / CDec(i.CustomTotalAlmacen.cantidad)

            '    Dim precioCompraConIva As Decimal = 0
            '    If i.CustomTotalAlmacen.origenRecaudo = 1 Then
            '        precioCompraConIva = valPrecUnitarioSinIGV + (valPrecUnitarioSinIGV * 0.18)
            '    Else
            '        precioCompraConIva = valPrecUnitarioSinIGV
            '    End If

            '    dr(10) = valPrecUnitarioSinIGV
            '    dr(11) = precioCompraConIva
            'End If
            dr(15) = i.precioCompra.GetValueOrDefault
            If i.CustomDetalleCompra IsNot Nothing Then
                If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                    If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = precioTotalSinIva
                                dr(14) = precioTotalConIva
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = precioTotalConIva
                                dr(14) = precioTotalConIva
                        End Select

                    Else

                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim iva = precioTotalConIva2 * 0.18
                                precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                dr(13) = precioTotalConIva
                                dr(14) = precioTotalConIva2 '0 'precioTotalConIva
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = precioTotalConIva
                                dr(14) = 0 'precioTotalConIva
                        End Select

                    End If

                End If
            End If

            If i.InventarioInicio IsNot Nothing Then
                'Select Case i.CustomDetalleCompra.destino
                '    Case 1
                If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                                 i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then

                    Dim precioSinIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2)

                    Dim precioConIva = (precioSinIva * 0.18) + precioSinIva


                    dr(16) = Math.Round(precioSinIva, 2)
                    dr(17) = Math.Round(precioConIva, 2)
                Else
                    dr(16) = 0
                    dr(17) = 0
                End If
                '    Case Else
                '        'If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                '        '    i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then
                '        '    Dim precioConIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2) * 0.18
                '        '    precioConIva = Math.Round(precioConIva + i.InventarioInicio.importeMN.GetValueOrDefault, 2)
                '        '    dr(13) = precioConIva
                '        'Else
                '        '    dr(13) = 0
                '        'End If

                'End Select

            End If
            dr(18) = False
            dt.Rows.Add(dr)
        Next

        dgvExistencias.DataSource = dt
        dgvExistencias.Engine.BindToCurrencyManager = False
        dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgvExistencias.TopLevelGroupOptions.ShowCaption = True
        dgvExistencias.ShowRowHeaders = True
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvExistencias.TableDescriptor.Columns("menorME").ReadOnly = False
        dgvExistencias.TableDescriptor.Columns("mayorME").ReadOnly = False
        dgvExistencias.TableDescriptor.Columns("gmayorME").ReadOnly = False
        'dgvExistencias.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FCEEE9")
    End Sub

    Private Sub GetArticulosSinAlmacen(tipo As String)
        Dim TipoExistencia() As String = {Constantes.TipoExistencia.Mercaderia, Constantes.TipoExistencia.ProductoTerminado, Constantes.TipoExistencia.SubProductosDesechos}
        Dim dt As New DataTable("Precios Generales")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        dt.Columns.Add(New DataColumn("menor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("menorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayorME", GetType(Decimal)))
        dt.Columns.Add("ultimacompra")
        dt.Columns.Add("ultimacompraConIGV")
        dt.Columns.Add("precRef")
        dt.Columns.Add("init")
        dt.Columns.Add("coninit")
        dt.Columns.Add("sel")

        For Each i In itemSA.GetTipoExistenciasByEmpresaConPrecios(Gempresas.IdEmpresaRuc, tipo).Where(Function(o) TipoExistencia.Contains(o.tipoExistencia) And o.CustomDetalleCompra Is Nothing).ToList

            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = (i.codigo & "   " & "-" & "   " & i.descripcionItem)
            dr(2) = i.NomClasificacion
            dr(3) = i.unidad1 'i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.NomMarca ' i.codigo
            dr(7) = i.precioMenor
            dr(8) = i.precioMenorME

            dr(9) = i.precioMayor
            dr(10) = i.precioMayorME

            dr(11) = i.precioGranMayor
            dr(12) = i.precioGranMayorME
            'If i.CustomTotalAlmacen IsNot Nothing Then
            '    Dim valPrecUnitarioSinIGV As Decimal = CDec(i.CustomTotalAlmacen.importeSoles) / CDec(i.CustomTotalAlmacen.cantidad)

            '    Dim precioCompraConIva As Decimal = 0
            '    If i.CustomTotalAlmacen.origenRecaudo = 1 Then
            '        precioCompraConIva = valPrecUnitarioSinIGV + (valPrecUnitarioSinIGV * 0.18)
            '    Else
            '        precioCompraConIva = valPrecUnitarioSinIGV
            '    End If

            '    dr(10) = valPrecUnitarioSinIGV
            '    dr(11) = precioCompraConIva
            'End If
            'dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault ' i.precioCompra.GetValueOrDefault
            If i.CustomDetalleCompra IsNot Nothing Then
                If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                    If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalSinIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    Else

                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim iva = precioTotalConIva2 * 0.18
                                precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva2).ToString("N2") '0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = 0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    End If

                End If
            End If

            If i.InventarioInicio IsNot Nothing Then
                'Select Case i.CustomDetalleCompra.destino
                '    Case 1
                If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                                 i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then

                    Dim precioSinIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2)

                    Dim precioConIva = (precioSinIva * 0.18) + precioSinIva


                    dr(16) = Math.Round(precioSinIva, 2)
                    dr(17) = Math.Round(precioConIva, 2)
                Else
                    dr(16) = 0
                    dr(17) = 0
                End If
                '    Case Else
                '        'If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                '        '    i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then
                '        '    Dim precioConIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2) * 0.18
                '        '    precioConIva = Math.Round(precioConIva + i.InventarioInicio.importeMN.GetValueOrDefault, 2)
                '        '    dr(13) = precioConIva
                '        'Else
                '        '    dr(13) = 0
                '        'End If

                'End Select

            End If
            dr(18) = False
            dt.Rows.Add(dr)
        Next

        dgvExistencias.DataSource = dt
        dgvExistencias.Engine.BindToCurrencyManager = False
        dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgvExistencias.TopLevelGroupOptions.ShowCaption = True
        dgvExistencias.ShowRowHeaders = True
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        dgvExistencias.TableDescriptor.Columns("menorME").ReadOnly = False
        dgvExistencias.TableDescriptor.Columns("mayorME").ReadOnly = False
        dgvExistencias.TableDescriptor.Columns("gmayorME").ReadOnly = False
        dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'dgvExistencias.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FCEEE9")
    End Sub

    Private Sub GetPreciosDirecto(tipo As String)
        Dim TipoExistencia() As String = {Constantes.TipoExistencia.Mercaderia, Constantes.TipoExistencia.ProductoTerminado, Constantes.TipoExistencia.SubProductosDesechos}
        Dim dt As New DataTable("Precios Generales")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        dt.Columns.Add(New DataColumn("menor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("menorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayorME", GetType(Decimal)))
        dt.Columns.Add("ultimacompra")
        dt.Columns.Add("ultimacompraConIGV")
        dt.Columns.Add("precRef")
        dt.Columns.Add("init")
        dt.Columns.Add("coninit")
        dt.Columns.Add("sel")

        For Each i In itemSA.GetTipoExistenciasByEmpresaConPrecios(Gempresas.IdEmpresaRuc, tipo).Where(Function(o) TipoExistencia.Contains(o.tipoExistencia)).ToList

            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = (i.codigo & "   " & "-" & "   " & i.descripcionItem)
            dr(2) = i.NomClasificacion
            dr(3) = i.unidad1 'i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.NomMarca ' i.codigo
            dr(7) = i.precioMenor
            dr(8) = i.precioMenorME

            dr(9) = i.precioMayor
            dr(10) = i.precioMayorME

            dr(11) = i.precioGranMayor
            dr(12) = i.precioGranMayorME
            'If i.CustomTotalAlmacen IsNot Nothing Then
            '    Dim valPrecUnitarioSinIGV As Decimal = CDec(i.CustomTotalAlmacen.importeSoles) / CDec(i.CustomTotalAlmacen.cantidad)

            '    Dim precioCompraConIva As Decimal = 0
            '    If i.CustomTotalAlmacen.origenRecaudo = 1 Then
            '        precioCompraConIva = valPrecUnitarioSinIGV + (valPrecUnitarioSinIGV * 0.18)
            '    Else
            '        precioCompraConIva = valPrecUnitarioSinIGV
            '    End If

            '    dr(10) = valPrecUnitarioSinIGV
            '    dr(11) = precioCompraConIva
            'End If
            'dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault ' i.precioCompra.GetValueOrDefault
            If i.CustomDetalleCompra IsNot Nothing Then
                If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                    If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalSinIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    Else

                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim iva = precioTotalConIva2 * 0.18
                                precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva2).ToString("N2") '0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = 0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    End If

                End If
            End If

            If i.InventarioInicio IsNot Nothing Then
                'Select Case i.CustomDetalleCompra.destino
                '    Case 1
                If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                                 i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then

                    Dim precioSinIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2)

                    Dim precioConIva = (precioSinIva * 0.18) + precioSinIva


                    dr(16) = Math.Round(precioSinIva, 2)
                    dr(17) = Math.Round(precioConIva, 2)
                Else
                    dr(16) = 0
                    dr(17) = 0
                End If
                '    Case Else
                '        'If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                '        '    i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then
                '        '    Dim precioConIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2) * 0.18
                '        '    precioConIva = Math.Round(precioConIva + i.InventarioInicio.importeMN.GetValueOrDefault, 2)
                '        '    dr(13) = precioConIva
                '        'Else
                '        '    dr(13) = 0
                '        'End If

                'End Select

            End If
            dr(18) = False
            dt.Rows.Add(dr)
        Next

        dgvExistencias.DataSource = dt
        dgvExistencias.Engine.BindToCurrencyManager = False
        dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgvExistencias.TopLevelGroupOptions.ShowCaption = True
        dgvExistencias.ShowRowHeaders = True
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        dgvExistencias.TableDescriptor.Columns("menorME").ReadOnly = False
        dgvExistencias.TableDescriptor.Columns("mayorME").ReadOnly = False
        dgvExistencias.TableDescriptor.Columns("gmayorME").ReadOnly = False
        dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'dgvExistencias.TableOptions.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#FCEEE9")
    End Sub

    Private Sub GetPreciosDirectoSinPrecios(tipo As Integer)
        Dim TipoExistencia() As String = {Constantes.TipoExistencia.Mercaderia, Constantes.TipoExistencia.ProductoTerminado, Constantes.TipoExistencia.SubProductosDesechos}
        Dim dt As New DataTable("Productos sin precios")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        dt.Columns.Add(New DataColumn("menor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("menorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("mayorME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("gmayorME", GetType(Decimal)))
        dt.Columns.Add("ultimacompra")
        dt.Columns.Add("ultimacompraConIGV")
        dt.Columns.Add("precRef")
        dt.Columns.Add("init")
        dt.Columns.Add("coninit")
        dt.Columns.Add("sel")

        For Each i In itemSA.GetProductosSinAsignarPrecios(New detalleitems With {.idEmpresa = Gempresas.IdEmpresaRuc}) '.Where(Function(o) TipoExistencia.Contains(o.tipoExistencia) And o.precioMenor = 0 And o.precioMayor = 0 And o.precioGranMayor = 0).ToList
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = (i.codigo & "   " & "-" & "   " & i.descripcionItem)
            dr(2) = i.NomClasificacion
            dr(3) = i.unidad1 'i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.NomMarca ' i.codigo
            dr(7) = i.precioMenor
            dr(8) = i.precioMenorME.GetValueOrDefault

            dr(9) = i.precioMayor
            dr(10) = i.precioMayorME.GetValueOrDefault

            dr(11) = i.precioGranMayor
            dr(12) = i.precioGranMayorME.GetValueOrDefault
            'If i.CustomTotalAlmacen IsNot Nothing Then
            '    Dim valPrecUnitarioSinIGV As Decimal = CDec(i.CustomTotalAlmacen.importeSoles) / CDec(i.CustomTotalAlmacen.cantidad)

            '    Dim precioCompraConIva As Decimal = 0
            '    If i.CustomTotalAlmacen.origenRecaudo = 1 Then
            '        precioCompraConIva = valPrecUnitarioSinIGV + (valPrecUnitarioSinIGV * 0.18)
            '    Else
            '        precioCompraConIva = valPrecUnitarioSinIGV
            '    End If

            '    dr(10) = valPrecUnitarioSinIGV
            '    dr(11) = precioCompraConIva
            'End If
            ' dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault ' i.precioCompra.GetValueOrDefault
            If i.CustomDetalleCompra IsNot Nothing Then
                If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                    If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalSinIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva).ToString("N2")
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    Else

                        Select Case i.CustomDetalleCompra.destino
                            Case 1
                                Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                Dim iva = precioTotalConIva2 * 0.18
                                precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                Dim precioTotalConIva =
                       i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = CDec(precioTotalConIva2).ToString("N2") '0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            Case Else

                                Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                dr(13) = CDec(precioTotalConIva).ToString("N2")
                                dr(14) = 0 'precioTotalConIva
                                dr(15) = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                        End Select

                    End If

                End If
            End If

            If i.InventarioInicio IsNot Nothing Then
                'Select Case i.CustomDetalleCompra.destino
                '    Case 1
                If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                                 i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then

                    Dim precioSinIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2)

                    Dim precioConIva = (precioSinIva * 0.18) + precioSinIva


                    dr(16) = Math.Round(precioSinIva, 2)
                    dr(17) = Math.Round(precioConIva, 2)
                Else
                    dr(16) = 0
                    dr(17) = 0
                End If
                '    Case Else
                '        'If i.InventarioInicio.monto1.GetValueOrDefault > 0 AndAlso
                '        '    i.InventarioInicio.importeMN.GetValueOrDefault > 0 Then
                '        '    Dim precioConIva = Math.Round(i.InventarioInicio.importeMN.GetValueOrDefault / i.InventarioInicio.monto1.GetValueOrDefault, 2) * 0.18
                '        '    precioConIva = Math.Round(precioConIva + i.InventarioInicio.importeMN.GetValueOrDefault, 2)
                '        '    dr(13) = precioConIva
                '        'Else
                '        '    dr(13) = 0
                '        'End If

                'End Select

            End If
            dr(18) = False
            dt.Rows.Add(dr)
        Next

        dgvExistencias.DataSource = dt
        dgvExistencias.Engine.BindToCurrencyManager = False
        dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgvExistencias.TopLevelGroupOptions.ShowCaption = False
        dgvExistencias.ShowRowHeaders = True
        dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvExistencias.TableOptions.SelectionBackColor = Color.Gray
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvExistencias.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Private Sub GetPrecios(tipo As Integer)
        Dim TipoExistencia() As String = {Constantes.TipoExistencia.Mercaderia, Constantes.TipoExistencia.ProductoTerminado, Constantes.TipoExistencia.SubProductosDesechos}
        Dim dt As New DataTable("Precios Generales")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        For Each i In itemSA.GetTipoExistenciasByempresa(tipo).Where(Function(o) TipoExistencia.Contains(o.tipoExistencia)).ToList
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = (i.codigo & "   " & "-" & "   " & i.descripcionItem)
            dr(2) = i.NomClasificacion
            dr(3) = i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.codigo
            dt.Rows.Add(dr)
        Next

        dgvExistencias.DataSource = dt
        dgvExistencias.Engine.BindToCurrencyManager = False
        dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgvExistencias.TopLevelGroupOptions.ShowCaption = False
    End Sub

    Public Sub UbicarUltimosPreciosExistencias(intIdItem As Integer)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, intIdItem)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "1", "CON IVA", "SIN IVA")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl2.DataSource = dt

    End Sub

#End Region

#Region "Events"
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgvExistencias.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmNuevaExistencia
            f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
            '.cboTipoExistencia.SelectedValue = "01"
            f.Precios = True
            f.IdAlmacenPrecio = TmpIdAlmacen
            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            f.UCNuenExistencia.UbicarProducto(r.GetValue("idItem"))
            ' f.txtCodigoBarra.Text = Me.dgvExistencias.Table.CurrentRecord.GetValue("codigoBarra")
            f.UCNuenExistencia.txtCodigoBarra.ReadOnly = False
            f.UCNuenExistencia.Label7.Visible = False
            f.UCNuenExistencia.cboTipoExistencia.Visible = False
            f.Label2.Visible = False
            f.UCNuenExistencia.cboIgv.Visible = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, detalleitems)
                r.SetValue("descripcion", c.descripcionItem)
                r.SetValue("clasificacion", c.NomClasificacion)
                r.SetValue("marca", c.NomMarca)
                r.SetValue("gravado", c.origenProducto)
                r.SetValue("tipoExistencia", c.tipoExistencia)
                r.SetValue("codigoBarra", c.codigo)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvExistencias_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvExistencias.QueryCellStyleInfo

        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            If e.TableCellIdentity.Column.MappingName = "menor" Then
                Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                    Dim r As Record = el.GetRecord()
                    If r Is Nothing Then Return
                    Dim PrecioVenta As Decimal? = r.GetValue("menor")

                    If IsNumeric(PrecioVenta) Then
                        Select Case ComboDigitos.Text
                            Case "PRECIOS 2 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N2")
                            Case "PRECIOS 5 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N5")
                        End Select
                    End If
                End If
            ElseIf e.TableCellIdentity.Column.MappingName = "mayor" Then
                Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                    Dim r As Record = el.GetRecord()
                    If r Is Nothing Then Return
                    Dim PrecioVenta As Decimal? = r.GetValue("mayor")

                    If IsNumeric(PrecioVenta) Then
                        Select Case ComboDigitos.Text
                            Case "PRECIOS 2 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N2")
                            Case "PRECIOS 5 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N5")
                        End Select
                    End If
                End If
            ElseIf e.TableCellIdentity.Column.MappingName = "gmayor" Then
                Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                    Dim r As Record = el.GetRecord()
                    If r Is Nothing Then Return
                    Dim PrecioVenta As Decimal? = r.GetValue("gmayor")

                    If IsNumeric(PrecioVenta) Then
                        Select Case ComboDigitos.Text
                            Case "PRECIOS 2 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N2")
                            Case "PRECIOS 5 DIGITOS"
                                e.Style.CellValue = CDec(PrecioVenta).ToString("N5")
                        End Select
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GridGroupingControl2_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridGroupingControl2.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            GridGroupingControl2.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub GridGroupingControl2_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles GridGroupingControl2.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, GridGroupingControl2)
    End Sub

    Private Sub frmExistenciaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bgCombos.RunWorkerAsync()
        CMBClasificacion()
        'Productoshijos()

        RoundButton21.Visible = True
        ComboDigitos.Text = "PRECIOS 2 DIGITOS"
        ComboDigitos.Size = New Size(160, 21)
        GridGroupingControl2.ShowColumnHeaders = True
        PanelPreciosDetalle.Visible = False
        With dgvExistencias
            .TableDescriptor.Columns("menor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 2
            .TableDescriptor.Columns("mayor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 2
            .TableDescriptor.Columns("gmayor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 2
        End With

        dgvExistencias.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    'Private Sub GrabarPrecio()

    '    Dim listaPrecio As New List(Of configuracionPrecioProducto)
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    If (value) > 0 Then
    '        Dim precio As New configuracionPrecioProducto
    '        precio.idPrecio = tipoPrecio
    '        precio.idproducto = r.GetValue("idItem")
    '        precio.fecha = DateTime.Now
    '        precio.tipo = 1
    '        precio.valPorcentaje = 0
    '        precio.nroLote = Nothing
    '        Select Case tipoPrecio
    '            Case 1
    '                precio.descripcion = "Precio por Menor"
    '            Case 2
    '                precio.descripcion = "Precio por Mayor"
    '            Case 3
    '                precio.descripcion = "Precio por Gran Mayor"
    '        End Select
    '        precio.precioMN = value
    '        precio.precioME = value / TmpTipoCambio

    '        listaPrecio = New List(Of configuracionPrecioProducto)
    '        listaPrecio.Add(precio)
    '        precioSA.GrabarPrecio(listaPrecio)
    '    End If


    'End Sub

    Private Sub GrabarPrecio(precioMenor As Decimal, PrecioMayor As Decimal, PrecioGranMayor As Decimal, idProducto As Integer)
        Me.Cursor = Cursors.WaitCursor
        'Dim numero = nudCantMin.Value

        'If MessageBoxAdv.Show("va a guardar con cantidad mínima " + CStr(numero) + "?", "atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        If EstadoManipulacion = ENTITY_ACTIONS.INSERT Then
            GrabarItemServicio()
        Else
            'EditarItemEstablec()
        End If
        'End If
        Me.Cursor = Cursors.Arrow


        'Dim listaPrecio As New List(Of configuracionPrecioProducto)
        'Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim precio As New configuracionPrecioProducto
        'listaPrecio = New List(Of configuracionPrecioProducto)

        'dgvExistencias.TableControl.CurrentCell.EndEdit()
        'dgvExistencias.TableControl.Table.TableDirty = True
        'dgvExistencias.TableControl.Table.EndEdit()

        ''If (precioMenor) > 0 Then
        ''Dim precio As New configuracionPrecioProducto
        'precio = New configuracionPrecioProducto
        'precio.idPrecio = 1
        'precio.idproducto = idProducto
        'precio.fecha = DateTime.Now
        'precio.tipo = 1
        'precio.valPorcentaje = 0
        'precio.nroLote = Nothing
        'precio.descripcion = "Precio por Menor"
        'precio.precioMN = precioMenor
        'precio.precioME = precioMenor / TmpTipoCambio
        'listaPrecio.Add(precio)
        ''      End If


        ''  If (PrecioMayor) > 0 Then
        ''Dim precio As New configuracionPrecioProducto
        'precio = New configuracionPrecioProducto
        'precio.idPrecio = 2
        'precio.idproducto = idProducto
        'precio.fecha = DateTime.Now
        'precio.tipo = 1
        'precio.valPorcentaje = 0
        'precio.nroLote = Nothing
        'precio.descripcion = "Precio por Mayor"
        'precio.precioMN = PrecioMayor
        'precio.precioME = PrecioMayor / TmpTipoCambio
        'listaPrecio.Add(precio)
        ''  End If


        ''    If (PrecioGranMayor) > 0 Then
        ''Dim precio As New configuracionPrecioProducto
        'precio = New configuracionPrecioProducto
        'precio.idPrecio = 3
        'precio.idproducto = idProducto
        'precio.fecha = DateTime.Now
        'precio.tipo = 1
        'precio.valPorcentaje = 0
        'precio.nroLote = Nothing
        'precio.descripcion = "Precio por Gran Mayor"
        'precio.precioMN = PrecioGranMayor
        'precio.precioME = PrecioGranMayor / TmpTipoCambio
        'listaPrecio.Add(precio)
        ''End If
        'precioSA.GrabarPrecio(listaPrecio)
        'MsgBox("Precio actualizado", MsgBoxStyle.Information, "Done!")
    End Sub
    Private Sub GrabarPrecio(precioMenor As Decimal, precioMenorME As Decimal,
                             PrecioMayor As Decimal, PrecioMayorME As Decimal,
                             PrecioGranMayor As Decimal, PrecioGranMayorME As Decimal,
                             idProducto As Integer)
        Dim listaPrecio As New List(Of configuracionPrecioProducto)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        listaPrecio = New List(Of configuracionPrecioProducto)

        dgvExistencias.TableControl.CurrentCell.EndEdit()
        dgvExistencias.TableControl.Table.TableDirty = True
        dgvExistencias.TableControl.Table.EndEdit()

        '    If (precioMenor) > 0 Then
        precio = New configuracionPrecioProducto
        precio.idPrecio = 1
        precio.idproducto = idProducto
        precio.fecha = DateTime.Now
        precio.tipo = 1
        precio.valPorcentaje = 0
        precio.nroLote = Nothing
        precio.descripcion = "Precio por Menor"
        precio.precioMN = precioMenor
        precio.precioME = precioMenorME
        listaPrecio.Add(precio)
        '  End If


        '    If (PrecioMayor) > 0 Then
        'Dim precio As New configuracionPrecioProducto
        precio = New configuracionPrecioProducto
        precio.idPrecio = 2
        precio.idproducto = idProducto
        precio.fecha = DateTime.Now
        precio.tipo = 1
        precio.valPorcentaje = 0
        precio.nroLote = Nothing
        precio.descripcion = "Precio por Mayor"
        precio.precioMN = PrecioMayor
        precio.precioME = PrecioMayorME
        listaPrecio.Add(precio)
        '   End If


        ' If (PrecioGranMayor) > 0 Then
        'Dim precio As New configuracionPrecioProducto
        precio = New configuracionPrecioProducto
        precio.idPrecio = 3
        precio.idproducto = idProducto
        precio.fecha = DateTime.Now
        precio.tipo = 1
        precio.valPorcentaje = 0
        precio.nroLote = Nothing
        precio.descripcion = "Precio por Gran Mayor"
        precio.precioMN = PrecioGranMayor
        precio.precioME = PrecioGranMayorME
        listaPrecio.Add(precio)
        '    End If
        precioSA.GrabarPrecio(listaPrecio)
        MsgBox("Precio actualizado", MsgBoxStyle.Information, "Done!")
    End Sub

    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvExistencias.TableControlPushButtonClick
        'Me.Cursor = Cursors.WaitCursor
        'Try
        '    If e.Inner.ColIndex = 19 Then

        '        Dim precioMenor = dgvExistencias.TableModel(e.Inner.RowIndex, 7).CellValue
        '        Dim precioMenorME = dgvExistencias.TableModel(e.Inner.RowIndex, 8).CellValue
        '        Dim precioMayor = dgvExistencias.TableModel(e.Inner.RowIndex, 9).CellValue
        '        Dim precioMayorME = dgvExistencias.TableModel(e.Inner.RowIndex, 10).CellValue
        '        Dim preciogranmayor = dgvExistencias.TableModel(e.Inner.RowIndex, 11).CellValue
        '        Dim preciogranmayorME = dgvExistencias.TableModel(e.Inner.RowIndex, 12).CellValue
        '        Dim idProducto = dgvExistencias.TableModel(e.Inner.RowIndex, 15).CellValue

        '        'If CheckboxMoneda.Checked = True Then
        '        '    GrabarPrecio(precioMenor, precioMenorME,
        '        '             precioMayor, precioMayorME,
        '        '             preciogranmayor, preciogranmayorME,
        '        '             idProducto)
        '        'Else
        '        GrabarPrecio(precioMenor, precioMayor, preciogranmayor, idProducto)
        '        'End If

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvExistencias.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 19 Then
                e.Inner.Style.Description = "Grabar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub dgvExistencias_TableControlDrawCellBackground(sender As Object, e As GridTableControlDrawCellBackgroundEventArgs) Handles dgvExistencias.TableControlDrawCellBackground

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
        Dim r As Record = dgvExistencias.Table.CurrentRecord
        If dgvExistencias.Table.CurrentRecord IsNot Nothing Then
            'GetInventarioLotesByItem(dgvExistencias.Table.CurrentRecord)
            Dim f As New frmUltimasCompras
            f.txtItem.Text = r.GetValue("descripcion")
            f.txtItem.ValueMember = r.GetValue("idItem")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub Panel28_Click(sender As Object, e As EventArgs) Handles Panel28.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.dgvExistencias, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Desea abrir el archivo ahora?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If
    End Sub
    Dim filter As New GridExcelFilter()

    Private Sub dgvExistencias_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvExistencias.TableControlKeyDown

        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvExistencias.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Or dgvExistencias.TableControl.CurrentCell IsNot Nothing Then
            Select Case cc.ColIndex


                Case 7 ' 
                    Dim r As Record = dgvExistencias.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        r.SetValue("menor", r.GetValue("menor"))
                    End If

            End Select
        End If
    End Sub

    Private Sub dgvExistencias_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvExistencias.TableControlKeyPress
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvExistencias.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Or dgvExistencias.TableControl.CurrentCell IsNot Nothing Then
            Select Case cc.ColIndex


                Case 7 ' 
                    Dim r As Record = dgvExistencias.Table.CurrentRecord
                    If Not IsNothing(r) Then


                        r.SetValue("menor", r.GetValue("menor"))

                    End If

            End Select
        End If
    End Sub

    Private Sub dgvExistencias_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvExistencias.TableControlKeyUp
        Dim cc As GridCurrentCell = dgvExistencias.TableControl.CurrentCell
        Dim style As GridTableCellStyleInfo = TryCast(cc.Renderer.CurrentStyle, GridTableCellStyleInfo)

        If style IsNot Nothing Then

            '   Select Case style.TableCellIdentity.Column.Name
            'Case "cantidad"
            '    If e.Inner.KeyData = Keys.Enter Then
            '        'e.TableControl.Table.CurrentRecord.SetCurrent("pumn")
            '        'e.TableControl.CurrentCell.MoveTo(cc.RowIndex, cc.ColIndex + 1, GridSetCurrentCellOptions.SetFocus)
            '    End If
            'Case "pumn"
            '    If e.Inner.KeyData = Keys.Enter Then
            '        e.TableControl.Table.CurrentRecord.SetCurrent("totalmn")
            '    End If

            'Case "pume"
            '    If e.Inner.KeyData = Keys.Enter Then
            '        e.TableControl.Table.CurrentRecord.SetCurrent("totalme")
            '    End If

            'Case "totalmn"
            '    If e.Inner.KeyData = Keys.Enter Then
            '        e.TableControl.Table.CurrentRecord.SetCurrent("cantidad")
            '    End If

            'Case "totalme"
            '    If e.Inner.KeyData = Keys.Enter Then
            '        e.TableControl.Table.CurrentRecord.SetCurrent("cantidad")
            '    End If

            'Case "codBarra"
            '    e.TableControl.Table.CurrentRecord.SetCurrent("cantidad")
            'Case Else
            If e.Inner.KeyData = Keys.Enter Then
                ' // e.TableControl.Table.CurrentRecord.SetCurrent("FirstColumnName")
                e.TableControl.CurrentCell.MoveTo(cc.RowIndex, cc.ColIndex + 1, GridSetCurrentCellOptions.SetFocus)
            End If
            '   End Select
        End If
    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        GetSelecGridCheck(True)
        Cursor = Cursors.Default
    End Sub

    Private Sub GetSelecGridCheck(valor As Boolean)
        For Each i In dgvExistencias.Table.Records
            i.SetValue("sel", valor)
        Next
    End Sub

    Private Sub QuitarSelecciónToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        GetSelecGridCheck(False)
        Cursor = Cursors.Default
    End Sub

    Private Sub AsignarPrecioAProductoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New FormAsignarPreciosArticulos(dgvExistencias)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub dgvExistencias_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvExistencias.TableControlCurrentCellEditingComplete
        Try
            Dim cc As GridCurrentCell = dgvExistencias.TableControl.CurrentCell
            cc.ConfirmChanges()
            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                'If style.TableCellIdentity.Column.Name = "precRef" Then
                '    Dim text As String = cc.Renderer.ControlText

                '    If text.Trim.Length > 0 Then
                '        Dim valuePrecioCompra As Decimal = Convert.ToDecimal(text)
                '        cc.Renderer.ControlValue = valuePrecioCompra
                '        Dim idProducto = Me.dgvExistencias.Table.CurrentRecord.GetValue("idItem")
                '        itemSA.actualizarPrecioCompra(New detalleitems With
                '                                      {
                '                                      .codigodetalle = idProducto,
                '                                      .precioCompra = valuePrecioCompra
                '                                      })
                '        MessageBox.Show("Precio de compra actualizado!", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    End If
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BpusquedaAvanzadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BpusquedaAvanzadaToolStripMenuItem.Click
        Dim f As New FormVentaBusquedaAvanzada
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Public Sub BusquedaAvanzadaProductos(be As BusquedaAvanzadaProductos) Implements IBusquedaAvanzadaProductos.BusquedaAvanzadaProductos
        If be IsNot Nothing Then
            Select Case be.tipo
                Case "MARCA"
                    BuscarXMarca(be.codigo)
                Case "CLASIFICACION"
                    BuscarXGrupo(be.codigo)
            End Select
        End If
    End Sub

    Private Sub BuscarXGrupo(IdCat As Integer)
        GetPreciosXGrupo(IdCat)
    End Sub

    Private Sub BuscarXMarca(codigo As String)
        GetPreciosXMarca(codigo)
    End Sub

    Private Sub NuevoAporteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        Try
            Dim fecha As Date = Date.Now
            Dim f As New FormOtrasEntradasAlmacen(dgvExistencias) ' frmMovOtrasEntradas
            f.txtGlosa.Text = "Por aportes de inventario"
            f.txtGlosa.Enabled = False
            f.ChPrecios.Checked = True
            f.cboOperacion.Enabled = False
            f.PanelIndentificacion.Visible = False
            f.lblPerido.Text = GetPeriodo(fecha, True) 'cboMes.SelectedValue & "/" & cboAnio.Text
            f.cboOperacion.SelectedValue = "0000"
            f.cboOperacion.Text = "APORTES"
            f.lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show(Me)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub NuevaEntradaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        Dim fecha As Date = Date.Now
        Dim f As New FormOtrasEntradasAlmacen 'frmMovOtrasEntradas
        f.lblPerido.Text = GetPeriodo(fecha, True) ' cboMes.SelectedValue & "/" & cboAnio.Text
        f.cboOperacion.SelectedValue = "0000"
        f.lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.PanelIndentificacion.Visible = True
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show(Me)
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvExistencias_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvExistencias.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)

        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()

        If Me.dgvExistencias.TableModel(e.Inner.RowIndex, e.Inner.ColIndex).Text = "False" Then
            currenrecord.SetSelected(True)
        Else
            currenrecord.SetSelected(False)
        End If
    End Sub

    Private Sub CompraRapidaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        Try
            Dim r As Record = dgvExistencias.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim f As New FormCompraRapida(New detalleitems With
                                              {
                                              .codigodetalle = r.GetValue("idItem"),
                                              .descripcionItem = r.GetValue("descripcion")
                                              })
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show(Me)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ArtículosSinAlmacénToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtículosSinAlmacénToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        GetArticulosSinAlmacen(TipoExistencia.Mercaderia)
        Cursor = Cursors.Default
    End Sub


    Private Sub ComboDigitos_SelectedIndexChanged(sender As Object, e As EventArgs)
        Select Case ComboDigitos.Text
            Case "PRECIOS 2 DIGITOS"
                With dgvExistencias
                    .TableDescriptor.Columns("menor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 2
                    .TableDescriptor.Columns("mayor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 2
                    .TableDescriptor.Columns("gmayor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 2
                End With
            Case "PRECIOS 3 DIGITOS"
                With dgvExistencias
                    .TableDescriptor.Columns("menor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 3
                    .TableDescriptor.Columns("mayor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 3
                    .TableDescriptor.Columns("gmayor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 3
                End With
            Case "PRECIOS 4 DIGITOS"
                With dgvExistencias
                    .TableDescriptor.Columns("menor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 4
                    .TableDescriptor.Columns("mayor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 4
                    .TableDescriptor.Columns("gmayor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 4
                End With
            Case "PRECIOS 5 DIGITOS"
                With dgvExistencias
                    .TableDescriptor.Columns("menor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 5
                    .TableDescriptor.Columns("mayor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 5
                    .TableDescriptor.Columns("gmayor").Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 5
                End With
        End Select
        dgvExistencias.Refresh()
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Me.dgvExistencias.Table.AddNewRecord.SetCurrent()
        Me.dgvExistencias.Table.AddNewRecord.BeginEdit()
        Me.dgvExistencias.Table.CurrentRecord.SetValue("idItem", Nothing) '0
        Me.dgvExistencias.Table.CurrentRecord.SetValue("descripcion", "")
        Me.dgvExistencias.Table.CurrentRecord.SetValue("clasificacion", "")
        Me.dgvExistencias.Table.CurrentRecord.SetValue("marca", "NIU")
        Me.dgvExistencias.Table.CurrentRecord.SetValue("gravado", 1)
        Me.dgvExistencias.Table.CurrentRecord.SetValue("tipoExistencia", TipoRecurso.SERVICIO)
        Me.dgvExistencias.Table.CurrentRecord.SetValue("codigoBarra", Nothing)
        Me.dgvExistencias.Table.CurrentRecord.SetValue("menor", 0.00)
        Me.dgvExistencias.Table.CurrentRecord.SetValue("menorME", 0.00)
        Me.dgvExistencias.Table.CurrentRecord.SetValue("mayor", 0.00)
        Me.dgvExistencias.Table.CurrentRecord.SetValue("mayorME", 0.00)
        Me.dgvExistencias.Table.CurrentRecord.SetValue("gmayor", 0.00)
        Me.dgvExistencias.Table.CurrentRecord.SetValue("gmayorME", 0.00)
        Me.dgvExistencias.Table.AddNewRecord.EndEdit()

    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        If (Not IsNothing(dgvExistencias.Table.CurrentRecord)) Then
            dgvExistencias.Table.CurrentRecord.Delete()
        Else
            MessageBox.Show("Debe seleccionar un item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton23.Click
        If (dgvExistencias.Table.Records.Count > 0) Then
            GrabarItemServicio()
        Else
            MessageBox.Show("Debe ingresar un servicio!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim datos As List(Of itemServicio) = itemServicio.Instance()
        datos.Clear()

        Dim f As New frmNuevaClasificacion
        f.Tag = "GS"
        f.txtDescripcion.Text = txtCategoria.Text
        txtCategoria.Clear()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        CMBClasificacion()
        If datos.Count > 0 Then
            txtCategoria.Text = datos(0).descripcion
            txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCategoria.Tag = CInt(datos(0).idItemServicio)
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim datos As List(Of itemServicio) = itemServicio.Instance()
        datos.Clear()


        Dim f As New frmNuevaMarca
        f.Tag = "GS"
        f.StartPosition = FormStartPosition.CenterParent
        f.txtCodigo.Tag = txtCategoria.Tag
        f.txtCodigo.Text = txtCategoria.Tag

        f.txtDescripcion.Text = txtSubCategoria.Text
        txtSubCategoria.Clear()

        f.ShowDialog()
        Productoshijos()

        If datos.Count > 0 Then
            txtSubCategoria.Text = datos(0).descripcion
            txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtSubCategoria.Tag = CInt(datos(0).idItemServicio)
        End If
        'Else
        '    MessageBox.Show("seleccione una clasificacion")
        'End If
    End Sub

    Private Sub dgvExistencias_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvExistencias.TableControlCellClick

    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged

    End Sub

    Private Sub bgCombos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgCombos.DoWork
        Dim TablaSA As New tablaDetalleSA
        listaUM = TablaSA.GetListaTablaDetalle(6, "1")
    End Sub

    Private Sub bgCombos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgCombos.RunWorkerCompleted
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("NAME")
        dt.Rows.Add(1, "1 - GRAVADO")
        dt.Rows.Add(2, "2 - EXONERADO")
        dt.Rows.Add(3, "3 - INAFECTO")

        Dim ggcStyle As GridTableCellStyleInfo = dgvExistencias.TableDescriptor.Columns(4).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = dt
        ggcStyle.ValueMember = "ID"
        ggcStyle.DisplayMember = "NAME"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvExistencias.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvExistencias.ShowRowHeaders = False

        Dim ggcStyle2 As GridTableCellStyleInfo = dgvExistencias.TableDescriptor.Columns(3).Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = listaUM
        ggcStyle2.ValueMember = "descripcion"
        ggcStyle2.DisplayMember = "codigoDetalle2"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive
        dgvExistencias.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvExistencias.ShowRowHeaders = False

    End Sub

    Private Sub frmServicioPrecios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        bgCombos.CancelAsync()
    End Sub



#End Region

End Class
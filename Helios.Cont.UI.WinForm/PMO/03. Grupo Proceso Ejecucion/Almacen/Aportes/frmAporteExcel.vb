Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion
Imports Syncfusion.Windows.Forms

Public Class frmAporteExcel
    Inherits frmMaster

    Public Property SerieAp() As String
    Public Property NumeroAp() As String

    Private selectedRows As New List(Of DataGridViewRow)
    Private selectedRowsRevision As New List(Of DataGridViewRow)
    Private selectedRowsProductos As New List(Of DataGridViewRow)
    Private toolTipShowing As Boolean
    Public Property ManipulacionEstado() As String
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        LoadControlesDefault()
        lblPeriodo.Text = PeriodoGeneral
    End Sub

#Region "CATEGORIA"
    Public Class ClasificacionProductos

        Private _name As String
        Private _id As Integer
        Public Sub New(ByVal name As String, ByVal id As Integer)
            _name = name
            _id = id
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
    End Class

    'Public Sub GrabarCategoria()
    '    Dim itemSA As New itemSA
    '    Dim item As New item
    '    Try
    '        With item
    '            .idEmpresa = Gempresas.IdEmpresaRuc
    '            .idEstablecimiento = GEstableciento.IdEstablecimiento
    '            .descripcion = txtNewClasificacion.Text.Trim
    '            .fechaIngreso = DateTime.Now
    '            .usuarioActualizacion = "Jiuni"
    '            .fechaActualizacion = DateTime.Now
    '        End With

    '        Dim codx As Integer = itemSA.SaveCategoria(item)
    '        lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx))
    '        Me.txtCategoria.ValueMember = CStr(codx)
    '        txtCategoria.Text = txtNewClasificacion.Text.Trim
    '        ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue)
    '    Catch ex As Exception
    '        lblEstado.Text = (ex.Message)
    '    End Try
    'End Sub
#End Region

#Region "CLASES ABSTRACTAS"
    Private Shared datosCat As List(Of Categoria)
    Private Shared datosProductos As List(Of Productos)

    Private Class Categoria
        Public Property idCategoria As Integer
        Public Property NombreCategoria As String
        'Public Property Country As String

        Public Shared Function GetAsientos() As List(Of Categoria)

            If datosCat Is Nothing Then
                datosCat = New List(Of Categoria)
            End If

            Return datosCat
        End Function

        Private Sub AddAsiento(objCategoria As Categoria)
            datosCat.Add(objCategoria)
        End Sub

    End Class

    Public Class Productos

        Public Property IdProducto As String
        Public Property tipoAporte As String
        Public Property idCategoria As Integer
        Public Property NomCategoria As String
        Public Property Cuenta As String
        Public Property Descripcion As String
        Public Property TipoExistencia As String
        Public Property OrigenGravado As String
        Public Property Presentacion As String
        Public Property NomPresentacion As String
        Public Property UnidadMedida As String
        Public Property NomUnidadMedida As String
        Public Property Cantidad As Decimal
        Public Property PrecioUnitMN As Decimal
        Public Property PrecioUnitME As Decimal
        Public Property Importemn As Decimal
        Public Property Importeme As Decimal
        Public Property Existe As String


        Public Shared Function GetMovimientosProductos() As List(Of Productos)

            If datosProductos Is Nothing Then
                datosProductos = New List(Of Productos)
            End If

            Return datosProductos
        End Function

        Public Sub AddMovimiento(nMovimiento As Productos)
            datosProductos.Add(nMovimiento)
        End Sub
    End Class

    Private Sub DeleteCategoriaPorID(id As Integer)

        Dim queryResults = (From cat In datosCat _
                           Where cat.idCategoria = id).First
        datosCat.Remove(queryResults)

        Dim ListaMov = (From n In datosProductos _
                  Where n.idCategoria = id).ToList

        For Each i In ListaMov
            datosProductos.Remove(i)
        Next

        lstCategoria.DataSource = Nothing
        lstCategoria.DisplayMember = "NombreCategoria"
        lstCategoria.ValueMember = "idCategoria"
        lstCategoria.DataSource = datosCat

        If Not datosProductos.Count > 0 Then
            dgvProducto.Rows.Clear()
        End If

    End Sub

    Private Sub DeleteProductoID(id As String)

        Dim queryResults = (From cust In datosProductos _
                           Where cust.IdProducto = id).First
        datosProductos.Remove(queryResults)

        If Not datosProductos.Count > 0 Then
            dgvProducto.Rows.Clear()
        End If

    End Sub

    Private Sub ActualizarProductoID(ByVal objProd As Productos, ByVal caso As Byte)

        Dim queryResults = (From cust In datosProductos _
                           Where cust.IdProducto = objProd.IdProducto).First

        Select Case caso
            Case 1
                With queryResults
                    .Presentacion = objProd.Presentacion
                    .NomPresentacion = objProd.NomPresentacion
                End With
            Case 2
                With queryResults

                    .UnidadMedida = objProd.UnidadMedida
                    .NomUnidadMedida = objProd.NomUnidadMedida
                End With
        End Select
    End Sub

    Private Sub ubicarProductoPorID(id As Integer)

        Dim queryResults = (From cust In datosProductos _
                           Where cust.idCategoria = id).ToList

        If queryResults.Count > 0 Then
            dgvProducto.Rows.Clear()
            For Each I As Productos In queryResults
                dgvProducto.Rows.Add(I.IdProducto, I.OrigenGravado, I.tipoAporte,
                                               I.IdProducto, I.Descripcion, I.TipoExistencia,
                                               I.Presentacion, I.NomPresentacion,
                                               I.UnidadMedida, I.NomUnidadMedida,
                                                I.Cantidad, I.PrecioUnitMN,
                                               I.PrecioUnitME,
                                               I.Importemn,
                                               I.Importeme,
                                               Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, I.Cuenta, I.Existe)
            Next
            For Each i As DataGridViewRow In dgvProducto.Rows
                If i.Cells(17).Value = "S" Then
                    i.DefaultCellStyle.BackColor = Color.LightYellow
                Else
                    i.DefaultCellStyle.BackColor = Color.White
                End If
            Next
            lblEstado.Text = "Listado de productos"
        Else
            dgvProducto.Rows.Clear()
        End If


    End Sub

    Private Function ListarProductosPorCategoria(id As Integer) As List(Of Productos)

        Dim queryResults = (From cust In datosProductos _
                           Where cust.idCategoria = id).ToList

        Return queryResults
    End Function
#End Region

    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        'txtNumDoc.Text = .serie
    '                        'txtNumDoc.Visible = True
    '                        '    txtNumeroComp.Visible = False
    '                        txtTipoDoc.ValueMember = GConfiguracion.TipoComprobante
    '                        txtTipoDoc.Text = GConfiguracion.NombreComprobante
    '                        '    LinkTipoDoc.Enabled = False
    '                        '      txtNumDoc.Enabled = False
    '                    End With
    '                Case "M"
    '                    '    txtNumDoc.Visible = True
    '                    '  txtNumeroComp.Visible = True
    '                    '   LinkTipoDoc.Enabled = True
    '                    '  txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        Timer1.Enabled = True
    '        QTabControl1.Enabled = False
    '        '      TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GrabarButton()
        Me.Cursor = Cursors.WaitCursor
        Try
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                If Not txtProveedor.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese un accionista válido!"
                    Exit Sub
                End If

                If Not txtAlmacen.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese un almacén válido!"
                    Exit Sub
                End If
                If dgvNuevoDoc.Rows.Count > 0 Then
                    GrabarAporte()
                Else
                    lblEstado.Text = "Debe haber al menos una fila en la canasta de aportes"
                End If
            Else
                If Not txtProveedor.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese un accionista válido!"
                    Exit Sub
                End If

                Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                If Filas > 0 Then
                    UpdateAporte()
                Else
                    Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Protected Overrides Function ProcessCmdKey( _
     ByRef msg As System.Windows.Forms.Message, _
     ByVal keyData As System.Windows.Forms.Keys) As Boolean


        If (keyData <> Keys.Control + Keys.G) And (keyData <> Keys.F2) Then _
            Return MyBase.ProcessCmdKey(msg, keyData)


        If Keys.Control + Keys.G Then

            Me.Cursor = Cursors.WaitCursor
            GrabarButton()
            Me.Cursor = Cursors.Arrow
        End If

        Return True

    End Function

#Region "Métodos"
    Public Sub LoadControlesDefault()
        Dim almacenSA As New almacenSA
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim categoriaSA As New itemSA

        lstAlmacen.DisplayMember = "descripcionAlmacen"
        lstAlmacen.ValueMember = "idAlmacen"
        lstAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")

        lsvProveedor.Items.Clear()
        For Each i As entidad In entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim n As New ListViewItem(i.idEntidad)
            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.cuentaAsiento)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next

        For Each i In categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
            lstCategoria.Items.Add(New ClasificacionProductos(i.descripcion, i.idItem))
        Next
        lstCategoria.DisplayMember = "Name"
        lstCategoria.ValueMember = "Id"
    End Sub

    Public ListadoItems As New List(Of item)
    Dim ListaAsientonTransito As New List(Of asiento)
    Public Function AsientoContableAporte() As asiento
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim nMovimientoAporte As New movimiento
        Dim ListaAsiento As New List(Of asiento)


        With nAsiento
            .idAsiento = 0
            .idDocumento = 0
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idDocumentoRef = Nothing
            .idAlmacen = txtAlmacen.ValueMember
            .nombreAlmacen = txtAlmacen.Text
            .idEntidad = txtProveedor.ValueMember
            .nombreEntidad = txtProveedor.Text
            .tipoEntidad = "PR"
            .fechaProceso = txtFechaComprobante.Value
            .codigoLibro = "5"
            .tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            .tipoAsiento = ASIENTO_CONTABLE.APORTE_EXISTENCIA
            .importeMN = lblTotalAdquisiones.Text
            .importeME = lblTotalUS.Text
            .glosa = "POR APORTE DE EXISTENCIAS"
            .usuarioActualizacion = "JIUNI"
            .fechaActualizacion = DateTime.Now
        End With

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(17).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                nMovimiento = New movimiento
                nMovimiento.idmovimiento = 0
                nMovimiento.idAsiento = 0
                nMovimiento.cuenta = dgvNuevoDoc.Rows(i.Index).Cells(18).Value
                nMovimiento.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(6).Value
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(15).Value)
                nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(16).Value)
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                nAsiento.movimiento.Add(nMovimiento)
            End If
        Next

        nMovimientoAporte = New movimiento
        nMovimientoAporte.idmovimiento = 0
        nMovimientoAporte.idAsiento = 0
        nMovimientoAporte.cuenta = "50"
        nMovimientoAporte.descripcion = "APORTE DE EXISTENCIAS"
        nMovimientoAporte.tipo = "H"
        nMovimientoAporte.monto = CDec(lblTotalAdquisiones.Text)
        nMovimientoAporte.montoUSD = CDec(lblTotalUS.Text)
        nMovimientoAporte.usuarioActualizacion = "Jiuni"
        nMovimientoAporte.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimientoAporte)

        Return nAsiento
    End Function

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objTabla As New tablaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA
        Dim CategoriaSA As New itemSA
        Try
            With objDoc.UbicarDocumento(intIdDocumento)
                txtFechaComprobante.Value = .fechaProceso
                'COMPROBANTE
                With objTabla.GetUbicarTablaID(10, .tipoDoc)
                    txtTipoDoc.ValueMember = .codigoDetalle
                    txtTipoDoc.Text = .descripcion
                End With
            End With

            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                lblIdDocumento.Text = .idDocumento
                lblPeriodo.Text = .fechaContable
                'txtNumDoc.ValueMember = .serie
                'txtNumDoc.Text = .numeroDoc
                If .monedaDoc = "1" Then
                    cboMoneda.Text = "MONEDA NACIONAL"
                ElseIf .monedaDoc = "2" Then
                    cboMoneda.Text = "MONEDA EXTRANJERA"
                End If

                'txtSerieComp.Text = .serie
                'txtNumeroComp.Text = .numeroDoc
                'PROVEEDOR
                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                '  txtRuc.Text = nEntidad.nrodoc
                txtCuenta.Text = nEntidad.cuentaAsiento
                txtProveedor.ValueMember = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

                '_::::::::::::::::::        :::::::::::::::::::
                txtTipoCambio.Value = .tcDolLoc
            End With


            'DETALLE DE LA COMPRA
            dgvNuevoDoc.Rows.Clear()
            Dim strCuenta As String
            Dim IDCat As String
            Dim NomCat As String
            Dim IdUM As String
            Dim NomUM As String
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)
                If i.destino = "1" Then
                    VALUEDES = "1"
                ElseIf i.destino.Trim = "2" Then
                    VALUEDES = "2"
                ElseIf i.destino.Trim = "3" Then
                    VALUEDES = "3"
                ElseIf i.destino.Trim = "4" Then
                    VALUEDES = "4"
                End If
                With objTabla.GetUbicarTablaID(6, i.unidad1)
                    IdUM = .codigoDetalle
                    NomUM = .descripcion
                End With
                With insumosSA.InvocarProductoID(i.idItem)
                    strCuenta = .cuenta
                    IDCat = .idItem
                    NomCat = CategoriaSA.UbicarCategoriaPorID(IDCat).descripcion
                End With

                dgvNuevoDoc.Rows.Add(i.secuencia,
                                     VALUEDES,
                                     "EXISTENCIA", IDCat, NomCat,
                                     i.idItem,
                                     i.descripcionItem, i.tipoExistencia,
                                     i.unidad2,
                                     i.monto2,
                                     IdUM, NomUM,
                                     FormatNumber(i.monto1, 2),
                                     FormatNumber(i.precioUnitario, 2),
                                     FormatNumber(i.precioUnitarioUS, 2),
                                     FormatNumber(i.importe, 2),
                                     FormatNumber(i.importeUS, 2),
                                     Business.Entity.BaseBE.EntityAction.UPDATE,
                                     strCuenta,
                                     i.almacenRef)
            Next
            COntarDGV()
        Catch ex As Exception
            lblEstado.Text = "No se pudo cargar la información. " & ex.Message
        End Try

    End Sub

    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = GEstableciento.IdEstablecimiento
            objTotalesDet.idAlmacen = txtAlmacen.ValueMember
            objTotalesDet.origenRecaudo = i.Cells(1).Value()
            objTotalesDet.tipoCambio = txtTipoCambio.Value
            objTotalesDet.tipoExistencia = i.Cells(7).Value()
            objTotalesDet.idItem = i.Cells(5).Value()
            objTotalesDet.descripcion = i.Cells(6).Value()
            objTotalesDet.idUnidad = i.Cells(10).Value()
            objTotalesDet.unidadMedida = i.Cells(11).Value()
            objTotalesDet.cantidad = CType(i.Cells(12).Value(), Decimal)
            objTotalesDet.precioUnitarioCompra = CType(i.Cells(13).Value(), Decimal)

            objTotalesDet.importeSoles = CType(i.Cells(15).Value(), Decimal)
            objTotalesDet.importeDolares = CType(i.Cells(16).Value(), Decimal)

            objTotalesDet.montoIsc = 0
            objTotalesDet.montoIscUS = 0
            objTotalesDet.Otros = 0
            objTotalesDet.OtrosUS = 0
            objTotalesDet.porcentajeUtilidad = 0
            objTotalesDet.importePorcentaje = 0
            objTotalesDet.importePorcentajeUS = 0
            objTotalesDet.precioVenta = 0
            objTotalesDet.precioVentaUS = 0
            objTotalesDet.usuarioActualizacion = "NN"
            objTotalesDet.fechaActualizacion = Date.Now
            ListaTotales.Add(objTotalesDet)
        Next

        Return ListaTotales
    End Function

    Sub InsertProductos()
        Dim itemSA As New itemSA

        Dim listaProductos As New List(Of Productos)
        Dim CategoriaBL As New item
        Dim nProducto As New detalleitems

        For Each i In datosCat
            CategoriaBL = New item
            CategoriaBL.idItem = i.idCategoria
            CategoriaBL.idEmpresa = Gempresas.IdEmpresaRuc
            CategoriaBL.idEstablecimiento = GEstableciento.IdEstablecimiento
            CategoriaBL.fechaIngreso = DateTime.Now
            CategoriaBL.descripcion = i.NombreCategoria

            listaProductos = ListarProductosPorCategoria(i.idCategoria)
            '  Dim CONTEO As Integer = 0
            For Each x In listaProductos
                If x.Existe = "N" Then
                    nProducto = New detalleitems
                    nProducto.idEmpresa = Gempresas.IdEmpresaRuc
                    nProducto.idEstablecimiento = GEstableciento.IdEstablecimiento
                    nProducto.cuenta = x.Cuenta
                    nProducto.idItem = x.idCategoria
                    nProducto.descripcionItem = x.Descripcion
                    nProducto.presentacion = x.Presentacion
                    nProducto.unidad1 = x.UnidadMedida
                    nProducto.tipoExistencia = x.TipoExistencia
                    nProducto.origenProducto = x.OrigenGravado
                    nProducto.tipoProducto = "I"
                    nProducto.estado = "1"
                    nProducto.usuarioActualizacion = "Jiuni"
                    nProducto.fechaActualizacion = DateTime.Now
                    nProducto.idItem = x.idCategoria
                    CategoriaBL.detalleitems.Add(nProducto)

                End If
            Next
            ListadoItems.Add(CategoriaBL)
        Next
        itemSA.GrabarProductosExcel(ListadoItems)
        lblEstado.Text = "Lista de productos registradas correctamente"
        lblEstado.Image = My.Resources.ok4

        LoadDGVAporte()
        QTabPage2.Parent = QTabControl1
        QTabPage3.Parent = Nothing
        '  QRibbonApplicationButton1.IsVisible(Qios.DevSuite.Components.QPartVisibilitySelectionTypes.IncludeVisible)
    End Sub

    Public Sub COntarDGV()
        Dim cImporteMN As Decimal = 0
        Dim cImporteME As Decimal = 0

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            cImporteMN += CDec(i.Cells(15).Value)
            cImporteME += CDec(i.Cells(16).Value)
        Next
        lblTotalAdquisiones.Text = cImporteMN.ToString("N2")
        lblTotalUS.Text = cImporteME.ToString("N2")
    End Sub

    Public Sub LoadDGVAporte()
        Dim productoBE As New detalleitems
        Dim productoSA As New detalleitemsSA
        Dim listaProductos As New List(Of Productos)
        Dim cImporteMN As Decimal = 0
        Dim cImporteME As Decimal = 0

        QRibbonApplicationButton1.Visible = True
        dgvNuevoDoc.Rows.Clear()
        For Each i In datosCat
            listaProductos = ListarProductosPorCategoria(i.idCategoria)
            '  Dim CONTEO As Integer = 0
            For Each x In listaProductos
                cImporteMN += CDec(x.Importemn)
                cImporteME += CDec(x.Importeme)
                productoBE = productoSA.InvocarProductoNombre(x.Descripcion, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
                dgvNuevoDoc.Rows.Add("00", productoBE.origenProducto, x.tipoAporte, productoBE.idItem, x.NomCategoria,
                                     productoBE.codigodetalle, productoBE.descripcionItem, productoBE.tipoExistencia,
                                     productoBE.presentacion, x.NomPresentacion, productoBE.unidad1, x.NomUnidadMedida,
                                     x.Cantidad, x.PrecioUnitMN, x.PrecioUnitME, x.Importemn, x.Importeme,
                                     Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, productoBE.cuenta)

            Next
        Next
        lblTotalAdquisiones.Text = cImporteMN.ToString("N2")
        lblTotalUS.Text = cImporteME.ToString("N2")
    End Sub

    Public Sub GrabarAporte()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim numeracionSA As New NumeracionBoletaSA
        '  Dim numeracion As New numeracionBoletas

        '        numeracion = numeracionSA.ObtenerDocumentoPorEstablecimiento(GEstableciento.IdEstablecimiento, "00001", "APORT", "VOU")
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = GConfiguracion.TipoComprobante
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = GConfiguracion.Serie
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "17"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idPadre = 0 ' lblIdDocumento.Text
            .codigoLibro = "5"
            .tipoDoc = GConfiguracion.TipoComprobante
            .tipoDocEntidad = GConfiguracion.TipoComprobante
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaContable = lblPeriodo.Text
            .serie = GConfiguracion.Serie
            .numeroDoc = GConfiguracion.Serie
            .idProveedor = txtProveedor.ValueMember
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2")
            .tasaIgv = 0
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = CDec(lblTotalAdquisiones.Text)
            .importeUS = CDec(lblTotalUS.Text)

            .destino = TIPO_COMPRA.APORTE_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            '.glosa = IIf(IsNothing(txtGlosa.Text) Or String.IsNullOrEmpty(txtGlosa.Text) Or String.IsNullOrWhiteSpace(txtGlosa.Text), Nothing, Trim(txtGlosa.Text.Trim))
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.APORTE_EXISTENCIAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'ASIENTOS CONTABLES
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.TipoDoc = "9901"
            objDocumentoCompraDet.NumDoc = Nothing
            objDocumentoCompraDet.Serie = Nothing
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If i.Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf i.Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf i.Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf i.Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If

            objDocumentoCompraDet.CuentaItem = i.Cells(18).Value()
            objDocumentoCompraDet.idItem = i.Cells(5).Value()
            objDocumentoCompraDet.descripcionItem = i.Cells(6).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(7).Value()
            objDocumentoCompraDet.unidad2 = i.Cells(8).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = i.Cells(9).Value() ' PRESENTACION
            objDocumentoCompraDet.unidad1 = i.Cells(10).Value().ToString.Trim

            If Not IsNumeric(i.Cells(12).Value) Then
                lblEstado.Text = "La cantidad debe ser mayor a '0', verificar celda."
                lblEstado.Image = My.Resources.warning2
                Exit Sub
            End If
            objDocumentoCompraDet.monto1 = CDec(i.Cells(12).Value())

            If Not IsNumeric(i.Cells(13).Value) Then
                lblEstado.Text = "Inidcar el precio unitario!!"
                lblEstado.Image = My.Resources.warning2
                Exit Sub
            End If
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(13).Value())

            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(14).Value())
            objDocumentoCompraDet.importe = CDec(i.Cells(15).Value())
            objDocumentoCompraDet.importeUS = CDec(i.Cells(16).Value())

            objDocumentoCompraDet.montokardex = 0
            objDocumentoCompraDet.montoIsc = 0
            objDocumentoCompraDet.montoIgv = 0
            objDocumentoCompraDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = 0
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = 0
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = Nothing 'i.Cells(23).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = "N"
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.almacenRef = txtAlmacen.ValueMember
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = "Por Aporte de existencias"

            ' objDocumentoCompraDet.BonificacionMN =

            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        nAsiento = AsientoContableAporte()
        ListaAsientonTransito.Add(nAsiento)
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen()

        Dim xcod As Integer = CompraSA.SaveAporteExistencia(ndocumento, ListaTotales)
        lblEstado.Text = "Aporte registrado!"
        lblEstado.Image = My.Resources.ok4

        'Dim n As New ListViewItem(xcod)
        'n.UseItemStyleForSubItems = False
        'n.SubItems.Add("02").BackColor = Color.FromArgb(225, 240, 190)
        'n.SubItems.Add(ndocumento.documentocompra.fechaDoc)
        'n.SubItems.Add(ndocumento.documentocompra.tipoDoc)
        'n.SubItems.Add(ndocumento.documentocompra.serie)
        'n.SubItems.Add(ndocumento.documentocompra.numeroDoc)

        'entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First()
        'n.SubItems.Add(entidad.tipoDoc)
        'n.SubItems.Add(txtRuc.Text)
        'n.SubItems.Add(txtProveedor.Text)
        'n.SubItems.Add(txtTipoEntidad.Text)

        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeTotal, 2))
        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.tcDolLoc, 2))
        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeUS, 2))
        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.monedaDoc, 2))
        'n.SubItems.Add(TIPO_COMPRA.COMPRA_PAGADA)
        ' n.Group = g

        'With frmMantenimientoComprasPagadas
        '    '  Dim strNom = .lsvProduccion.Groups(g.Name.First)
        '    '   n.Group = .lsvProduccion.Groups(txtProveedor.Text)
        '    .lsvProduccion.Items.Add(n)
        'End With
        Dispose()
    End Sub

    Public Sub UpdateAporte()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim objTotalesDet As New totalesAlmacen()
        Dim objActividadDeleteEO As New totalesAlmacen()
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaDeleteEO As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim numeracion As New numeracionBoletas
        Dim almacenSA As New almacenSA

        numeracion = numeracionSA.ObtenerDocumentoPorEstablecimiento(GEstableciento.IdEstablecimiento, "00001", "APORT", "VOU")
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "9901"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = GConfiguracion.Serie ' txtNumDoc.ValueMember & "-" & txtNumDoc.Text
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "17"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idDocumento = lblIdDocumento.Text
            .idPadre = 0 ' lblIdDocumento.Text
            .codigoLibro = "5"
            .tipoDoc = "9901"
            .tipoDocEntidad = numeracion.tipo
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaContable = lblPeriodo.Text
            .serie = SerieAp
            .numeroDoc = NumeroAp
            .idProveedor = txtProveedor.ValueMember
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2")
            .tasaIgv = 0
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = CDec(lblTotalAdquisiones.Text)
            .importeUS = CDec(lblTotalUS.Text)

            .destino = TIPO_COMPRA.APORTE_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = "Por Aporte de existencias"
            '.glosa = IIf(IsNothing(txtGlosa.Text) Or String.IsNullOrEmpty(txtGlosa.Text) Or String.IsNullOrWhiteSpace(txtGlosa.Text), Nothing, Trim(txtGlosa.Text.Trim))
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.APORTE_EXISTENCIAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'ASIENTOS CONTABLES
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            objDocumentoCompraDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value ' i.Cells(0).Value
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(19).Value).idEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.TipoDoc = "9901"
            objDocumentoCompraDet.NumDoc = NumeroAp
            objDocumentoCompraDet.Serie = SerieAp
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If dgvNuevoDoc.Rows(i.Index).Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If

            objDocumentoCompraDet.CuentaItem = dgvNuevoDoc.Rows(i.Index).Cells(18).Value()
            objDocumentoCompraDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(5).Value()
            objDocumentoCompraDet.descripcionItem = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
            objDocumentoCompraDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(7).Value()
            objDocumentoCompraDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(8).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(9).Value() ' PRESENTACION
            objDocumentoCompraDet.unidad1 = i.Cells(10).Value().ToString.Trim

            If Not IsNumeric(dgvNuevoDoc.Rows(i.Index).Cells(12).Value()) Then
                lblEstado.Text = "La cantidad debe ser mayor a '0', verificar celda."
                lblEstado.Image = My.Resources.warning2
                Exit Sub
            End If
            objDocumentoCompraDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(12).Value())

            If Not IsNumeric(dgvNuevoDoc.Rows(i.Index).Cells(13).Value()) Then
                lblEstado.Text = "Indicar el precio unitario de la celda."
                lblEstado.Image = My.Resources.warning2
                Exit Sub
            End If
            objDocumentoCompraDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(13).Value())

            objDocumentoCompraDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value())
            objDocumentoCompraDet.importe = CDec(dgvNuevoDoc.Rows(i.Index).Cells(15).Value())
            objDocumentoCompraDet.importeUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(16).Value())

            objDocumentoCompraDet.montokardex = 0
            objDocumentoCompraDet.montoIsc = 0
            objDocumentoCompraDet.montoIgv = 0
            objDocumentoCompraDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = 0
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = 0
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = Nothing 'i.Cells(23).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = "N"
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.almacenRef = dgvNuevoDoc.Rows(i.Index).Cells(19).Value
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = "Por Aporte de existencias"


            If dgvNuevoDoc.Rows(i.Index).Cells(17).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(17).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(17).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If
            ListaDetalle.Add(objDocumentoCompraDet)

            '-----------------------------------------------------------------------------------------------------------------
            If dgvNuevoDoc.Rows(i.Index).Cells(17).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.TipoDoc = txtTipoDoc.Text
                objTotalesDet.Modulo = "N"
                objTotalesDet.idEstablecimiento = GEstableciento.IdEstablecimiento ' almacensa.GetUbicar_almacenPorID(CInt(i.Cells(30).Value())).idEstablecimiento
                objTotalesDet.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(19).Value()
                objTotalesDet.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objTotalesDet.tipoCambio = "2.77"
                objTotalesDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(7).Value()
                objTotalesDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(5).Value()
                objTotalesDet.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
                objTotalesDet.idUnidad = dgvNuevoDoc.Rows(i.Index).Cells(10).Value()
                objTotalesDet.unidadMedida = Nothing

                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(12).Value(), Decimal)
                objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(13).Value(), Decimal)
                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(15).Value(), Decimal)
                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(16).Value(), Decimal)

                objTotalesDet.montoIsc = 0
                objTotalesDet.montoIscUS = 0
                objTotalesDet.Otros = 0
                objTotalesDet.OtrosUS = 0
                objTotalesDet.porcentajeUtilidad = 0
                objTotalesDet.importePorcentaje = 0
                objTotalesDet.importePorcentajeUS = 0
                objTotalesDet.precioVenta = 0
                objTotalesDet.precioVentaUS = 0
                objTotalesDet.usuarioActualizacion = "NN"
                objTotalesDet.fechaActualizacion = Date.Now
                ListaTotales.Add(objTotalesDet)
            End If


            If dgvNuevoDoc.Rows(i.Index).Cells(17).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Or
       dgvNuevoDoc.Rows(i.Index).Cells(17).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then

                objActividadDeleteEO = New totalesAlmacen
                objActividadDeleteEO.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objActividadDeleteEO.TipoDoc = txtTipoDoc.Text
                objActividadDeleteEO.SecuenciaDetalle = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
                objActividadDeleteEO.idEmpresa = Gempresas.IdEmpresaRuc
                objActividadDeleteEO.Modulo = "N"
                objActividadDeleteEO.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(19).Value()).idEstablecimiento
                objActividadDeleteEO.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(19).Value()
                objActividadDeleteEO.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objActividadDeleteEO.tipoCambio = txtTipoCambio.Value
                objActividadDeleteEO.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(7).Value()
                objActividadDeleteEO.idItem = dgvNuevoDoc.Rows(i.Index).Cells(5).Value()
                objActividadDeleteEO.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
                ListaDeleteEO.Add(objActividadDeleteEO)
            End If
        Next
        nAsiento = AsientoContableAporte()
        ListaAsientonTransito.Add(nAsiento)
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle


        CompraSA.UpdateAporteExistencia(ndocumento, ListaTotales, ListaDeleteEO)
        lblEstado.Text = "Aporte modificado!"
        lblEstado.Image = My.Resources.ok4

        'Dim n As New ListViewItem(xcod)
        'n.UseItemStyleForSubItems = False
        'n.SubItems.Add("02").BackColor = Color.FromArgb(225, 240, 190)
        'n.SubItems.Add(ndocumento.documentocompra.fechaDoc)
        'n.SubItems.Add(ndocumento.documentocompra.tipoDoc)
        'n.SubItems.Add(ndocumento.documentocompra.serie)
        'n.SubItems.Add(ndocumento.documentocompra.numeroDoc)

        'entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First()
        'n.SubItems.Add(entidad.tipoDoc)
        'n.SubItems.Add(txtRuc.Text)
        'n.SubItems.Add(txtProveedor.Text)
        'n.SubItems.Add(txtTipoEntidad.Text)

        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeTotal, 2))
        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.tcDolLoc, 2))
        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeUS, 2))
        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.monedaDoc, 2))
        'n.SubItems.Add(TIPO_COMPRA.COMPRA_PAGADA)
        ' n.Group = g

        'With frmMantenimientoComprasPagadas
        '    '  Dim strNom = .lsvProduccion.Groups(g.Name.First)
        '    '   n.Group = .lsvProduccion.Groups(txtProveedor.Text)
        '    .lsvProduccion.Items.Add(n)
        'End With
        Dispose()
    End Sub

    Public Sub AGregarCategoriaListbox()
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()

        Dim datosCat As List(Of Categoria) = Categoria.GetAsientos()
        Dim datosProductos As List(Of Productos) = Productos.GetMovimientosProductos()


        'With frmModalComprobantesTabla
        '    .x_Establecimiento = GEstableciento.IdEstablecimiento
        '    .lblTipo.Text = Tablas.Clasificacion
        '    .ToolStrip1.Enabled = True
        '    .Tablax = Tablas.Clasificacion
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        Dim nCat As New Categoria With {.idCategoria = datos(0).ID,
        '                         .NombreCategoria = datos(0).NombreCampo.Trim}

        '        datosCat.Add(nCat)
        '        lstCategoria.DataSource = Nothing
        '        lstCategoria.DisplayMember = "NombreCategoria"
        '        lstCategoria.ValueMember = "idCategoria"
        '        lstCategoria.DataSource = datosCat
        '        lblEstado.Text = "Categoria agregada"
        '    End If
        'End With
    End Sub

    Enum Tablas
        TipoExistencia = 5
        Clasificacion = 0
        UnidadMedidad = 6
        Presentacion = 21
        Cuenta = 3
    End Enum

    Sub ComprobanteShows(caso As Tablas)
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .x_Establecimiento = GEstableciento.IdEstablecimiento
        '    .lblTipo.Text = caso
        '    Select Case caso
        '        Case Tablas.Clasificacion
        '            .ToolStrip1.Enabled = True
        '            .Tablax = frmModalComprobantesTabla.Tablas.Clasificacion
        '    End Select
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        Select Case caso
        '            Case Tablas.TipoExistencia

        '            Case Tablas.Clasificacion
        '                dgvNuevoDoc.Item(3, dgvNuevoDoc.CurrentRow.Index).Value = datos(0).ID
        '                dgvNuevoDoc.Item(4, dgvNuevoDoc.CurrentRow.Index).Value = datos(0).NombreCampo
        '                Me.lblEstado.Image = My.Resources.ok4
        '                Me.lblEstado.Text = "Done!: Clasificación." ' String.Empty
        '                Me.lblEstado.ForeColor = Color.Black
        '            Case Tablas.UnidadMedidad
        '                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value = datos(0).ID
        '                '  txtum.Text = datos(0).NombreCampo
        '                Me.lblEstado.Image = My.Resources.ok4
        '                Me.lblEstado.Text = "Done!: Unidad de Medida." ' String.Empty
        '                Me.lblEstado.ForeColor = Color.Black
        '            Case Tablas.Presentacion
        '                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value = datos(0).ID
        '                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value = datos(0).NombreCampo
        '                Me.lblEstado.Image = My.Resources.ok4
        '                Me.lblEstado.Text = "Done!: Presentación." ' String.Empty
        '                Me.lblEstado.ForeColor = Color.Black
        '            Case Tablas.Cuenta

        '        End Select
        '        '    Timer1.Enabled = False
        '    Else
        '        'Select Case caso
        '        '    Case Tablas.TipoExistencia
        '        '        'txtExistenciaID.Text = String.Empty
        '        '        'txtExistencia.Text = String.Empty
        '        '    Case Tablas.Clasificacion
        '        '        txtClasifID.Text = String.Empty
        '        '        txtClasif.Text = String.Empty
        '        '    Case Tablas.UnidadMedidad
        '        '        txtumID.Text = String.Empty
        '        '        txtum.Text = String.Empty
        '        '    Case Tablas.Presentacion
        '        '        txtPresenID.Text = String.Empty
        '        '        txtPresen.Text = String.Empty
        '        '    Case Tablas.Cuenta
        '        '        'txtCuentaID.Text = String.Empty
        '        '        'txtCuenta.Text = String.Empty
        '        'End Select
        '        MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Sub CargarExcel()
        Dim strDestination As String = Nothing
        Dim productoSA As New detalleitemsSA()
        Dim productoBE As New detalleitems
        Dim dlgResult As DialogResult
        Dim itemSA As New itemSA
        Dim strIdCategoria As String
        Dim strNomCategoria As String

        Dim tabladetalleSA As New tablaDetalleSA
        Dim strIdPresentacion As String
        Dim strNomPresentacion As String

        Dim strIdUnidad As String
        Dim strNomUnidad As String

        Dim strTipoExistencia As String = Nothing

        Dim strCuenta As String = Nothing
        Try
            dgvRevision.Rows.Clear()
            'Show dialog
            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls" '
                '  .ShowDialog()
                dlgResult = .ShowDialog
                strDestination = .FileName
                '  txtRuta.Text = strDestination
            End With
            'If (strDestination <> "OpenFileDialog1") Then
            If dlgResult <> DialogResult.Cancel Then
                Dim fileName = strDestination ' "C:\Users\Jiuni\Desktop\CArpeta Compartida\SERVER NET\Name2.xls" '
                Dim book = New LinqToExcel.ExcelQueryFactory(fileName)
                Dim users = From x In book.Worksheet(Of Producto)() _
                            Select x
                For Each i In users
                    If CStr(i.detalle.Trim.Length > 0) Then
                        productoBE = productoSA.InvocarProductoNombre(i.detalle, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
                        If Not IsNothing(productoBE) Then
                            With itemSA.UbicarCategoriaPorID(productoBE.idItem)
                                strIdCategoria = .idItem
                                strNomCategoria = .descripcion
                            End With
                            With tabladetalleSA.GetUbicarTablaID(21, productoBE.presentacion)
                                strIdPresentacion = .codigoDetalle
                                strNomPresentacion = .descripcion
                            End With

                            With tabladetalleSA.GetUbicarTablaID(6, productoBE.unidad1)
                                strIdUnidad = .codigoDetalle
                                strNomUnidad = .descripcion
                            End With

                            dgvRevision.Rows.Add("0", productoBE.origenProducto, i.tipoAporte, strIdCategoria, strNomCategoria,
                                                 productoBE.idItem, i.detalle, productoBE.tipoExistencia,
                                                 strIdPresentacion, strNomPresentacion,
                                                 strIdUnidad, strNomUnidad,
                                                  i.cantidadAporte, i.precioUnit,
                                                 Math.Round(i.precioUnit / txtTipoCambio.Value, 2),
                                                 Math.Round(i.cantidadAporte * i.precioUnit, 2),
                                                 Math.Round(i.cantidadAporte * (Math.Round(i.precioUnit / txtTipoCambio.Value, 2)), 2),
                                                 Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, productoBE.cuenta, "S")
                        Else
                            If i.tipoExistencia = "MERCADERIA" Then
                                strTipoExistencia = "01"
                                strCuenta = "601111"
                            ElseIf i.tipoExistencia = "MATERIA PRIMA" Then
                                strTipoExistencia = "03"
                                strCuenta = "602111"
                            End If

                            dgvRevision.Rows.Add("0", i.gravado, i.tipoAporte, Nothing, Nothing,
                                                 "00", i.detalle, strTipoExistencia,
                                                 i.presentacion, i.presentacion,
                                                 Nothing, i.unidadMedida,
                                                 i.cantidadAporte, i.precioUnit,
                                                 Math.Round(i.precioUnit / txtTipoCambio.Value, 2),
                                                 Math.Round(i.cantidadAporte * i.precioUnit, 2),
                                                 Math.Round(i.cantidadAporte * (Math.Round(i.precioUnit / txtTipoCambio.Value, 2)), 2),
                                                 Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, strCuenta, "N")
                        End If

                    End If
                Next
                '     lblRows.Text = dgvImportar.Rows.Count & " fila(s)"
            End If
            For Each i As DataGridViewRow In dgvRevision.Rows
                If i.Cells(19).Value = "S" Then
                    i.DefaultCellStyle.BackColor = Color.LightYellow
                Else
                    i.DefaultCellStyle.BackColor = Color.White
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Dim fileName = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "names.xls")


    End Sub

    Sub CargarExcelCascada()
        Dim strDestination As String = Nothing
        Dim productoSA As New detalleitemsSA()
        Dim productoBE As New detalleitems
        Dim dlgResult As DialogResult
        Dim itemSA As New itemSA
        Dim strIdCategoria As String
        Dim strNomCategoria As String

        Dim tabladetalleSA As New tablaDetalleSA
        Dim strIdPresentacion As String
        Dim strNomPresentacion As String

        Dim strIdUnidad As String
        Dim strNomUnidad As String

        Dim strTipoExistencia As String = Nothing

        Dim strCuenta As String = Nothing
        Try
            dgvProducto.Rows.Clear()
            'Show dialog
            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls" '
                '  .ShowDialog()
                dlgResult = .ShowDialog
                strDestination = .FileName
                '  txtRuta.Text = strDestination
            End With
            'If (strDestination <> "OpenFileDialog1") Then
            If dlgResult <> DialogResult.Cancel Then
                Dim Produc As New Productos
                Dim fileName = strDestination ' "C:\Users\Jiuni\Desktop\CArpeta Compartida\SERVER NET\Name2.xls" '
                Dim book = New LinqToExcel.ExcelQueryFactory(fileName)
                Dim users = From x In book.Worksheet(Of Producto)(txtLibro.Text.Trim) _
                            Select x
                For Each i As Producto In users
                    If CStr(i.detalle.Trim.Length > 0) Then
                        productoBE = productoSA.InvocarProductoNombre(i.detalle, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
                        If Not IsNothing(productoBE) Then
                            With itemSA.UbicarCategoriaPorID(productoBE.idItem)
                                strIdCategoria = .idItem
                                strNomCategoria = .descripcion
                            End With
                            With tabladetalleSA.GetUbicarTablaID(21, productoBE.presentacion)
                                strIdPresentacion = .codigoDetalle
                                strNomPresentacion = .descripcion
                            End With

                            With tabladetalleSA.GetUbicarTablaID(6, productoBE.unidad1)
                                strIdUnidad = .codigoDetalle
                                strNomUnidad = .descripcion
                            End With

                            Produc = New Productos With {.IdProducto = productoBE.codigodetalle,
                                                              .tipoAporte = i.tipoAporte,
                                                              .idCategoria = lstCategoria.SelectedValue,
                                                              .NomCategoria = lstCategoria.Text,
                                                              .Cuenta = productoBE.cuenta,
                                                              .Descripcion = productoBE.descripcionItem,
                                                              .TipoExistencia = productoBE.tipoExistencia,
                                                              .OrigenGravado = productoBE.origenProducto,
                                                              .Presentacion = strIdPresentacion,
                                                              .NomPresentacion = strNomPresentacion,
                                                              .UnidadMedida = strIdUnidad,
                                                              .NomUnidadMedida = strNomUnidad,
                                                              .Cantidad = i.cantidadAporte,
                                                              .PrecioUnitMN = i.precioUnit,
                                                              .PrecioUnitME = Math.Round(i.precioUnit / txtTipoCambio.Value, 2),
                                                              .Importemn = Math.Round(i.cantidadAporte * i.precioUnit, 2),
                                                              .Importeme = Math.Round(i.cantidadAporte * (Math.Round(i.precioUnit / txtTipoCambio.Value, 2)), 2),
                                                              .Existe = "S"}

                            datosProductos.Add(Produc)



                            'dgvRevision.Rows.Add("0", productoBE.origenProducto, i.tipoAporte, strIdCategoria, strNomCategoria,
                            '                     productoBE.idItem, i.detalle, productoBE.tipoExistencia,
                            '                     strIdPresentacion, strNomPresentacion,
                            '                     strIdUnidad, strNomUnidad,
                            '                      i.cantidadAporte, i.precioUnit,
                            '                     Math.Round(i.precioUnit / txtTipoCambio.NumericValue, 2),
                            '                     Math.Round(i.cantidadAporte * i.precioUnit, 2),
                            '                     Math.Round(i.cantidadAporte * (Math.Round(i.precioUnit / txtTipoCambio.NumericValue, 2)), 2),
                            '                     Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, productoBE.cuenta, "S")
                        Else

                            If i.tipoExistencia = "MERCADERIA" Then
                                strTipoExistencia = "01"
                                strCuenta = "601111"
                            ElseIf i.tipoExistencia = "MATERIA PRIMA" Then
                                strTipoExistencia = "03"
                                strCuenta = "602111"
                            End If

                            Produc = New Productos With {.IdProducto = "PR" & datosProductos.Count + 1,
                                                          .tipoAporte = i.tipoAporte,
                                                          .idCategoria = lstCategoria.SelectedValue,
                                                          .NomCategoria = lstCategoria.Text,
                                                          .Cuenta = strCuenta,
                                                          .Descripcion = i.detalle,
                                                          .TipoExistencia = strTipoExistencia,
                                                          .OrigenGravado = i.gravado,
                                                          .Presentacion = Nothing,
                                                          .NomPresentacion = Nothing,
                                                          .UnidadMedida = Nothing,
                                                          .NomUnidadMedida = Nothing,
                                                          .Cantidad = i.cantidadAporte,
                                                          .PrecioUnitMN = i.precioUnit,
                                                          .PrecioUnitME = Math.Round(i.precioUnit / txtTipoCambio.Value, 2),
                                                          .Importemn = Math.Round(i.cantidadAporte * i.precioUnit, 2),
                                                          .Importeme = Math.Round(i.cantidadAporte * (Math.Round(i.precioUnit / txtTipoCambio.Value, 2)), 2),
                                                          .Existe = "N"}


                            datosProductos.Add(Produc)

                            'dgvRevision.Rows.Add("0", i.gravado, i.tipoAporte, Nothing, Nothing,
                            '                     "00", i.detalle, strTipoExistencia,
                            '                     i.presentacion, i.presentacion,
                            '                     Nothing, i.unidadMedida,
                            '                     i.cantidadAporte, i.precioUnit,
                            '                     Math.Round(i.precioUnit / txtTipoCambio.NumericValue, 2),
                            '                     Math.Round(i.cantidadAporte * i.precioUnit, 2),
                            '                     Math.Round(i.cantidadAporte * (Math.Round(i.precioUnit / txtTipoCambio.NumericValue, 2)), 2),
                            '                     Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, strCuenta, "N")
                        End If

                    End If
                Next
                '     lblRows.Text = dgvImportar.Rows.Count & " fila(s)"
            End If

            ubicarProductoPorID(lstCategoria.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Dim fileName = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "names.xls")


    End Sub
#End Region

    Private Sub frmAporteExcel_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub btnExcel_MenuItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QMenuCancelEventArgs) Handles btnExcel.MenuItemActivating
        Me.Cursor = Cursors.WaitCursor
        CargarExcel()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub cboMoneda_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub PerformSelection()
        For Each dgvRow As DataGridViewRow In dgvNuevoDoc.Rows
            If (selectedRows.Contains(dgvRow)) Then
                dgvRow.Selected = True
            Else
                dgvRow.Selected = False
            End If
        Next
    End Sub

    Private Sub PerformSelectionRevision()
        For Each dgvRow As DataGridViewRow In dgvRevision.Rows
            If (selectedRowsRevision.Contains(dgvRow)) Then
                dgvRow.Selected = True
            Else
                dgvRow.Selected = False
            End If
        Next
    End Sub

    Private Sub PerformSelectionProductos()
        For Each dgvRow As DataGridViewRow In dgvProducto.Rows
            If (selectedRowsProductos.Contains(dgvRow)) Then
                dgvRow.Selected = True
            Else
                dgvRow.Selected = False
            End If
        Next
    End Sub

    Private Sub dgvNuevoDoc_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)


    End Sub

    Private Sub dgvNuevoDoc_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
    Private Sub dgvNuevoDoc_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        'If dgvNuevoDoc.Rows.Count > 0 Then
        '    If e.ColumnIndex = 4 Then
        '        ComprobanteShows(Tablas.Clasificacion)

        '    ElseIf e.ColumnIndex = 9 Then
        '        ComprobanteShows(Tablas.Presentacion)

        '    ElseIf e.ColumnIndex = 10 Then
        '        ComprobanteShows(Tablas.UnidadMedidad)
        '    End If
        'End If

    End Sub
    Private _cellValue As String = [String].Empty

    Private Sub dgvNuevoDoc_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
    Private Sub dgvNuevoDoc_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        'If dgvNuevoDoc.Rows.Count > 0 Then
        '    If e.Button <> MouseButtons.Right Then
        '        Return
        '    End If

        '    If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then
        '        Return
        '    End If

        '    'enviamos el valor de la celda a la variable _cellValue
        '    '   _cellValue = dgvNuevoDoc(e.ColumnIndex, e.RowIndex).Value.ToString()

        '    'Definimos el lugar donde aparecera el scontextMenuStrip
        '    ContextMenuStrip1.Show(MousePosition)
        'End If
        ''Preguntamos si el boton pulsado del Mouse es el Derecho
        ''si no lo es no salimos sin hacer nada mas

    End Sub


    Private Sub ContextMenuStrip1_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        Select Case e.ClickedItem.Text
            Case "Asignar Clasificacion"
                Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                datos.Clear()
                'With frmModalComprobantesTabla
                '    .x_Establecimiento = GEstableciento.IdEstablecimiento
                '    .lblTipo.Text = Tablas.Clasificacion
                '    'Select Case caso
                '    '    Case Tablas.Clasificacion
                '    .ToolStrip1.Enabled = True
                '    .Tablax = Tablas.Clasificacion
                '    'End Select
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                '    If datos.Count > 0 Then

                '        If Me.dgvNuevoDoc.SelectedRows.Count > 0 Then
                '            Dim FilasSelect As DataGridViewSelectedRowCollection
                '            FilasSelect = Me.dgvNuevoDoc.SelectedRows
                '            'Dim PrimeraFila As Integer = FilasSelect.Item(0).Index
                '            'Dim NumFilas As Integer = FilasSelect.Count

                '            For Each i As DataGridViewRow In FilasSelect
                '                dgvNuevoDoc.Rows(i.Index).Cells(3).Value = datos(0).ID
                '                dgvNuevoDoc.Rows(i.Index).Cells(4).Value = datos(0).NombreCampo
                '            Next
                '            dgvNuevoDoc.ClearSelection()
                '            selectedRows.Clear()
                '        End If

                '    End If
                'End With

                '
                'Copiamos el valor de la variable _cellValue al ClipBoard
                '
                'Clipboard.SetText(_cellValue)
                'Exit Select
            Case "Asignar presentacion"
                Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                datos.Clear()
                'With frmModalComprobantesTabla
                '    .x_Establecimiento = GEstableciento.IdEstablecimiento
                '    .lblTipo.Text = Tablas.Presentacion
                '    'Select Case caso
                '    '    Case Tablas.Clasificacion
                '    '  .ToolStrip1.Enabled = True
                '    .Tablax = Tablas.Presentacion
                '    'End Select
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                '    If datos.Count > 0 Then

                '        If Me.dgvNuevoDoc.SelectedRows.Count > 0 Then
                '            Dim FilasSelect As DataGridViewSelectedRowCollection
                '            FilasSelect = Me.dgvNuevoDoc.SelectedRows
                '            Dim PrimeraFila As Integer = FilasSelect.Item(0).Index
                '            Dim NumFilas As Integer = FilasSelect.Count

                '            For Each i As DataGridViewRow In FilasSelect
                '                dgvNuevoDoc.Rows(i.Index).Cells(8).Value = datos(0).ID
                '                dgvNuevoDoc.Rows(i.Index).Cells(9).Value = datos(0).NombreCampo
                '            Next
                '            dgvNuevoDoc.ClearSelection()
                '            selectedRows.Clear()
                '        End If

                '    End If
                'End With
            Case "Asignar unidad de medida"

                Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                datos.Clear()
                'With frmModalComprobantesTabla
                '    .x_Establecimiento = GEstableciento.IdEstablecimiento
                '    .lblTipo.Text = Tablas.UnidadMedidad
                '    'Select Case caso
                '    '    Case Tablas.Clasificacion
                '    '  .ToolStrip1.Enabled = True
                '    .Tablax = Tablas.UnidadMedidad
                '    'End Select
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                '    If datos.Count > 0 Then

                '        If Me.dgvNuevoDoc.SelectedRows.Count > 0 Then
                '            Dim FilasSelect As DataGridViewSelectedRowCollection
                '            FilasSelect = Me.dgvNuevoDoc.SelectedRows
                '            Dim PrimeraFila As Integer = FilasSelect.Item(0).Index
                '            Dim NumFilas As Integer = FilasSelect.Count

                '            For Each i As DataGridViewRow In FilasSelect
                '                dgvNuevoDoc.Rows(i.Index).Cells(10).Value = datos(0).ID
                '                '    dgvNuevoDoc.Rows(i.Index).Cells(9).Value = datos(0).NombreCampo
                '            Next
                '            dgvNuevoDoc.ClearSelection()
                '            selectedRows.Clear()
                '        End If

                '    End If
                'End With
            Case "Limpiar seleccion"
                dgvNuevoDoc.ClearSelection()
                selectedRows.Clear()
            Case "copyRowValue"
                '
                'Copiamos el valor de toda la Fila selccionada al ClipBoard
                '
                Dim dataObj As DataObject = dgvNuevoDoc.GetClipboardContent()
                If dataObj IsNot Nothing Then
                    Clipboard.SetDataObject(dataObj)
                End If
                Exit Select

            Case "deleteRow"
                '
                'Identificamos la Fila actualmente seleccionada
                '
                Dim row As DataGridViewRow = dgvNuevoDoc.CurrentRow
                '
                'Preguntamos si el valor de Row es diferente de null, esto para evitar posibles
                'excepciones de referencias Nulas
                '
                If row IsNot Nothing Then
                    dgvNuevoDoc.Rows.Remove(row)
                End If

                Exit Select
        End Select
    End Sub
    'Sub AlmacenModConf()
    '    Dim almacenSA As New almacenSA
    '    Dim estableSA As New establecimientoSA
    '    With almacenSA.GetUbicar_almacenPorID(GConfiguracion.IdAlmacen)
    '        txtAlmacen.ValueMember = GConfiguracion.IdAlmacen
    '        txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '        With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '            'txtEstableAlmacen.ValueMember = .idCentroCosto
    '            'txtEstableAlmacen.Text = .nombre
    '        End With
    '    End With
    'End Sub
    Private Sub frmAporteExcel_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'QTabPage1.Parent = Nothing
        'datosCat.Clear()
        'datosProductos.Clear()
        'QTabPage2.Parent = Nothing
        '   QRibbonApplicationButton1.Visible = False
        For Each i As DataGridViewColumn In dgvNuevoDoc.Columns
            i.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For Each i As DataGridViewColumn In dgvRevision.Columns
            i.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        '    AlmacenModConf()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmModalAlmacen
            .ObtenerAlmacenes(GEstableciento.IdEstablecimiento)
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                txtAlmacen.ValueMember = datos(0).ID
                txtAlmacen.Text = datos(0).NombreEntidad
            End If

        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        CargarExcel()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        For Each i As DataGridViewRow In dgvRevision.Rows
            If i.Cells(19).Value = "S" Then
                i.DefaultCellStyle.BackColor = Color.LightYellow
            Else
                i.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub dgvRevision_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRevision.CellClick
        If dgvRevision.Rows.Count > 0 Then
            If e.RowIndex > -1 Then


                If Not dgvRevision.Item(19, e.RowIndex).Value = "S" Then
                    If e.ColumnIndex = 4 Then
                        menClasifi.Visible = True
                        menPresen.Visible = False
                        menUnidad.Visible = False
                        '    Me.DataGridView1.Rows(e.RowIndex).Selected = Me.DataGridView1.CurrentCell.Value
                        'End If
                        If e.RowIndex > -1 Then
                            If (selectedRowsRevision.Contains(dgvRevision.Rows(e.RowIndex))) Then
                                selectedRowsRevision.Remove(dgvRevision.CurrentRow)
                            Else
                                selectedRowsRevision.Add(dgvRevision.CurrentRow)
                            End If
                            PerformSelectionRevision()
                        End If
                    ElseIf e.ColumnIndex = 9 Then
                        menClasifi.Visible = False
                        menPresen.Visible = True
                        menUnidad.Visible = False

                        If e.RowIndex > -1 Then
                            If (selectedRowsRevision.Contains(dgvRevision.Rows(e.RowIndex))) Then
                                selectedRowsRevision.Remove(dgvRevision.CurrentRow)
                            Else
                                selectedRowsRevision.Add(dgvRevision.CurrentRow)
                            End If
                            PerformSelectionRevision()
                        End If
                    ElseIf e.ColumnIndex = 11 Then
                        menClasifi.Visible = False
                        menPresen.Visible = False
                        menUnidad.Visible = True

                        If e.RowIndex > -1 Then
                            If (selectedRowsRevision.Contains(dgvRevision.Rows(e.RowIndex))) Then
                                selectedRowsRevision.Remove(dgvRevision.CurrentRow)
                            Else
                                selectedRowsRevision.Add(dgvRevision.CurrentRow)
                            End If
                            PerformSelectionRevision()
                        End If
                    End If
                Else
                    dgvRevision.Rows(e.RowIndex).Selected = False
                End If
            End If
        End If
    End Sub

    'Private Sub ContextMenuStrip2_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip2.ItemClicked
    '    Select Case e.ClickedItem.Text
    '        Case "Asignar Clasificacion"
    '            Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
    '            datos.Clear()
    '            With frmModalComprobantesTabla
    '                .x_Establecimiento = GEstableciento.IdEstablecimiento
    '                .lblTipo.Text = Tablas.Clasificacion
    '                'Select Case caso
    '                '    Case Tablas.Clasificacion
    '                .ToolStrip1.Enabled = True
    '                .Tablax = Tablas.Clasificacion
    '                'End Select
    '                .StartPosition = FormStartPosition.CenterParent
    '                .ShowDialog()
    '                If datos.Count > 0 Then

    '                    If Me.dgvRevision.SelectedRows.Count > 0 Then
    '                        Dim FilasSelect As DataGridViewSelectedRowCollection
    '                        FilasSelect = Me.dgvRevision.SelectedRows
    '                        'Dim PrimeraFila As Integer = FilasSelect.Item(0).Index
    '                        'Dim NumFilas As Integer = FilasSelect.Count

    '                        For Each i As DataGridViewRow In FilasSelect
    '                            dgvRevision.Rows(i.Index).Cells(3).Value = datos(0).ID
    '                            dgvRevision.Rows(i.Index).Cells(4).Value = datos(0).NombreCampo
    '                        Next
    '                        dgvRevision.ClearSelection()
    '                        selectedRowsRevision.Clear()
    '                    End If

    '                End If
    '            End With

    '            '
    '            'Copiamos el valor de la variable _cellValue al ClipBoard
    '            '
    '            'Clipboard.SetText(_cellValue)
    '            'Exit Select
    '        Case "Asignar presentacion"
    '            Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
    '            datos.Clear()
    '            With frmModalComprobantesTabla
    '                .x_Establecimiento = GEstableciento.IdEstablecimiento
    '                .lblTipo.Text = Tablas.Presentacion
    '                'Select Case caso
    '                '    Case Tablas.Clasificacion
    '                '  .ToolStrip1.Enabled = True
    '                .Tablax = Tablas.Presentacion
    '                'End Select
    '                .StartPosition = FormStartPosition.CenterParent
    '                .ShowDialog()
    '                If datos.Count > 0 Then

    '                    If Me.dgvRevision.SelectedRows.Count > 0 Then
    '                        Dim FilasSelect As DataGridViewSelectedRowCollection
    '                        FilasSelect = Me.dgvRevision.SelectedRows
    '                        Dim PrimeraFila As Integer = FilasSelect.Item(0).Index
    '                        Dim NumFilas As Integer = FilasSelect.Count

    '                        For Each i As DataGridViewRow In FilasSelect
    '                            dgvRevision.Rows(i.Index).Cells(8).Value = datos(0).ID
    '                            dgvRevision.Rows(i.Index).Cells(9).Value = datos(0).NombreCampo
    '                        Next
    '                        dgvRevision.ClearSelection()
    '                        selectedRowsRevision.Clear()
    '                    End If

    '                End If
    '            End With
    '        Case "Asignar unidad de medida"

    '            Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
    '            datos.Clear()
    '            With frmModalComprobantesTabla
    '                .x_Establecimiento = GEstableciento.IdEstablecimiento
    '                .lblTipo.Text = Tablas.UnidadMedidad
    '                'Select Case caso
    '                '    Case Tablas.Clasificacion
    '                '  .ToolStrip1.Enabled = True
    '                .Tablax = Tablas.UnidadMedidad
    '                'End Select
    '                .StartPosition = FormStartPosition.CenterParent
    '                .ShowDialog()
    '                If datos.Count > 0 Then

    '                    If Me.dgvRevision.SelectedRows.Count > 0 Then
    '                        Dim FilasSelect As DataGridViewSelectedRowCollection
    '                        FilasSelect = Me.dgvRevision.SelectedRows
    '                        Dim PrimeraFila As Integer = FilasSelect.Item(0).Index
    '                        Dim NumFilas As Integer = FilasSelect.Count

    '                        For Each i As DataGridViewRow In FilasSelect
    '                            dgvRevision.Rows(i.Index).Cells(10).Value = datos(0).ID
    '                            '    dgvRevision.Rows(i.Index).Cells(9).Value = datos(0).NombreCampo
    '                        Next
    '                        dgvRevision.ClearSelection()
    '                        selectedRowsRevision.Clear()
    '                    End If

    '                End If
    '            End With
    '        Case "Limpiar seleccion"
    '            dgvRevision.ClearSelection()
    '            selectedRowsRevision.Clear()
    '        Case "copyRowValue"
    '            '
    '            'Copiamos el valor de toda la Fila selccionada al ClipBoard
    '            '
    '            Dim dataObj As DataObject = dgvRevision.GetClipboardContent()
    '            If dataObj IsNot Nothing Then
    '                Clipboard.SetDataObject(dataObj)
    '            End If
    '            Exit Select

    '        Case "deleteRow"
    '            '
    '            'Identificamos la Fila actualmente seleccionada
    '            '
    '            Dim row As DataGridViewRow = dgvRevision.CurrentRow
    '            '
    '            'Preguntamos si el valor de Row es diferente de null, esto para evitar posibles
    '            'excepciones de referencias Nulas
    '            '
    '            If row IsNot Nothing Then
    '                dgvRevision.Rows.Remove(row)
    '            End If

    '            Exit Select
    '    End Select
    'End Sub

    Private Sub dgvRevision_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRevision.CellMouseClick
        If dgvRevision.Rows.Count > 0 Then
            If e.Button <> MouseButtons.Right Then
                Return
            End If

            If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then
                Return
            End If

            'enviamos el valor de la celda a la variable _cellValue
            '   _cellValue = dgvNuevoDoc(e.ColumnIndex, e.RowIndex).Value.ToString()

            'Definimos el lugar donde aparecera el scontextMenuStrip
            ContextMenuStrip2.Show(MousePosition)
        End If
        'Preguntamos si el boton pulsado del Mouse es el Derecho
        'si no lo es no salimos sin hacer nada mas
    End Sub

    Private Sub dgvRevision_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRevision.CellContentClick

    End Sub

    Private Sub lstCategoria_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstCategoria.MouseClick
        Me.lstCategoria.ContextMenuStrip = Me.menCategoria
    End Sub

    Private Sub lstCategoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstCategoria.SelectedIndexChanged
        If lstCategoria.SelectedItems.Count > 0 Then
            txtLibro.Text = lstCategoria.Text
            ubicarProductoPorID(lstCategoria.SelectedValue)
        End If
    End Sub

    Private Sub NuevaCategoriaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevaCategoriaToolStripMenuItem.Click
        AGregarCategoriaListbox()
    End Sub




    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        CargarExcelCascada()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvProducto_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProducto.CellClick
        If dgvProducto.Rows.Count > 0 Then
            If e.RowIndex > -1 Then
                If Not dgvProducto.Item(17, e.RowIndex).Value = "S" Then
                    'If e.ColumnIndex = 4 Then
                    '    menPresen.Visible = False
                    '    menUnidad.Visible = False
                    '    '    Me.DataGridView1.Rows(e.RowIndex).Selected = Me.DataGridView1.CurrentCell.Value
                    '    'End If
                    '    If e.RowIndex > -1 Then
                    '        If (selectedRowsProductos.Contains(dgvProducto.Rows(e.RowIndex))) Then
                    '            selectedRowsProductos.Remove(dgvProducto.CurrentRow)
                    '        Else
                    '            selectedRowsProductos.Add(dgvProducto.CurrentRow)
                    '        End If
                    '        PerformSelectionProductos()
                    '    End If
                    If e.ColumnIndex = 7 Then

                        menPresentacion.Visible = True
                        menUnidadMedida.Visible = False

                        If e.RowIndex > -1 Then
                            If (selectedRowsProductos.Contains(dgvProducto.Rows(e.RowIndex))) Then
                                selectedRowsProductos.Remove(dgvProducto.CurrentRow)
                            Else
                                selectedRowsProductos.Add(dgvProducto.CurrentRow)
                            End If
                            PerformSelectionProductos()
                        End If
                    ElseIf e.ColumnIndex = 9 Then
                        menPresentacion.Visible = False
                        menUnidadMedida.Visible = True

                        If e.RowIndex > -1 Then
                            If (selectedRowsProductos.Contains(dgvProducto.Rows(e.RowIndex))) Then
                                selectedRowsProductos.Remove(dgvProducto.CurrentRow)
                            Else
                                selectedRowsProductos.Add(dgvProducto.CurrentRow)
                            End If
                            PerformSelectionProductos()
                        End If
                    End If
                Else
                    dgvProducto.Rows(e.RowIndex).Selected = False
                End If
            End If
        End If
    End Sub

    Private Sub dgvProducto_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProducto.CellContentClick

    End Sub

    Private Sub dgvProducto_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProducto.CellMouseClick
        If dgvProducto.Rows.Count > 0 Then
            If e.Button <> MouseButtons.Right Then
                Return
            End If

            If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then
                Return
            End If

            'enviamos el valor de la celda a la variable _cellValue
            '   _cellValue = dgvNuevoDoc(e.ColumnIndex, e.RowIndex).Value.ToString()

            'Definimos el lugar donde aparecera el scontextMenuStrip
            cmenProductos.Show(MousePosition)
        End If
        'Preguntamos si el boton pulsado del Mouse es el Derecho
        'si no lo es no salimos sin hacer nada mas
    End Sub

    Private Sub dgvProducto_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvProducto.RowPostPaint
        Dim grid As DataGridView = TryCast(sender, DataGridView)

        If Not grid.RowHeadersVisible Then
            Return
        End If

        'this method overrides the DataGridView's RowPostPaint event 
        'in order to automatically draw numbers on the row header cells
        'and to automatically adjust the width of the column containing
        'the row header cells so that it can accommodate the new row
        'numbers,

        'store a string representation of the row number in 'strRowNumber'
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()

        'prepend leading zeros to the string if necessary to improve
        'appearance. For example, if there are ten rows in the grid,
        'row seven will be numbered as "07" instead of "7". Similarly, if 
        'there are 100 rows in the grid, row seven will be numbered as "007".
        While strRowNumber.Length < grid.RowCount.ToString().Length
            strRowNumber = Convert.ToString("0") & strRowNumber
        End While

        'determine the display size of the row number string using
        'the DataGridView's current font.
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, grid.Font)

        'adjust the width of the column that contains the row header cells 
        'if necessary
        If grid.RowHeadersWidth < CInt(size.Width + 20) Then
            grid.RowHeadersWidth = CInt(size.Width + 20)
        End If

        'this brush will be used to draw the row number string on the
        'row header cell using the system's current ControlText color
        Dim b As Brush = SystemBrushes.ControlText

        'draw the row number string on the current row header cell using
        'the brush defined above and the DataGridView's default font
        e.Graphics.DrawString(strRowNumber, grid.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub dgvProducto_RowPrePaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvProducto.RowPrePaint
        Select Case dgvProducto.Rows(e.RowIndex).Cells("colAporte").Value
            Case "EXISTENCIA"
                dgvProducto.Rows(e.RowIndex).Cells("colAporte").Style.ForeColor = Color.Green
            Case "DINERO"
                dgvProducto.Rows(e.RowIndex).Cells("colAporte").Style.ForeColor = Color.Red
                'Case "Entregado"
                '    dgvProducto.Rows(e.RowIndex).Cells("Estado").Style.ForeColor = Color.Green
                'Case Else
                '    dgvProducto.Rows(e.RowIndex).Cells("Estado").Style.ForeColor = Color.Black
        End Select
    End Sub

    Private Sub btnSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguiente.Click

    End Sub

    Private Sub menCategoria_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles menCategoria.ItemClicked

    End Sub

    Private Sub menCategoria_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles menCategoria.Opening

    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening

    End Sub

    'Private Sub cmenProductos_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cmenProductos.ItemClicked
    '    Dim nProducto As New Productos
    '    Select Case e.ClickedItem.Text
    '        Case "Asignar Clasificacion"
    '            Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
    '            datos.Clear()
    '            With frmModalComprobantesTabla
    '                .x_Establecimiento = GEstableciento.IdEstablecimiento
    '                .lblTipo.Text = Tablas.Clasificacion
    '                'Select Case caso
    '                '    Case Tablas.Clasificacion
    '                .ToolStrip1.Enabled = True
    '                .Tablax = Tablas.Clasificacion
    '                'End Select
    '                .StartPosition = FormStartPosition.CenterParent
    '                .ShowDialog()
    '                If datos.Count > 0 Then

    '                    If Me.dgvProducto.SelectedRows.Count > 0 Then
    '                        Dim FilasSelect As DataGridViewSelectedRowCollection
    '                        FilasSelect = Me.dgvProducto.SelectedRows
    '                        'Dim PrimeraFila As Integer = FilasSelect.Item(0).Index
    '                        'Dim NumFilas As Integer = FilasSelect.Count

    '                        For Each i As DataGridViewRow In FilasSelect
    '                            dgvProducto.Rows(i.Index).Cells(3).Value = datos(0).ID
    '                            dgvProducto.Rows(i.Index).Cells(4).Value = datos(0).NombreCampo
    '                        Next
    '                        dgvProducto.ClearSelection()
    '                        selectedRowsProductos.Clear()
    '                    End If

    '                End If
    '            End With

    '            '
    '            'Copiamos el valor de la variable _cellValue al ClipBoard
    '            '
    '            'Clipboard.SetText(_cellValue)
    '            'Exit Select
    '        Case "Asignar presentacion"
    '            Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
    '            datos.Clear()
    '            With frmModalComprobantesTabla
    '                .x_Establecimiento = GEstableciento.IdEstablecimiento
    '                .lblTipo.Text = Tablas.Presentacion
    '                'Select Case caso
    '                '    Case Tablas.Clasificacion
    '                '  .ToolStrip1.Enabled = True
    '                .Tablax = Tablas.Presentacion
    '                'End Select
    '                .StartPosition = FormStartPosition.CenterParent
    '                .ShowDialog()
    '                If datos.Count > 0 Then

    '                    If Me.dgvProducto.SelectedRows.Count > 0 Then
    '                        Dim FilasSelect As DataGridViewSelectedRowCollection
    '                        FilasSelect = Me.dgvProducto.SelectedRows
    '                        Dim PrimeraFila As Integer = FilasSelect.Item(0).Index
    '                        Dim NumFilas As Integer = FilasSelect.Count


    '                        For Each i As DataGridViewRow In FilasSelect
    '                            nProducto = New Productos
    '                            nProducto.IdProducto = dgvProducto.Rows(i.Index).Cells(0).Value
    '                            nProducto.Presentacion = datos(0).ID
    '                            nProducto.NomPresentacion = datos(0).NombreCampo
    '                            dgvProducto.Rows(i.Index).Cells(6).Value = datos(0).ID
    '                            dgvProducto.Rows(i.Index).Cells(7).Value = datos(0).NombreCampo
    '                            ActualizarProductoID(nProducto, 1)
    '                        Next
    '                        dgvProducto.ClearSelection()
    '                        selectedRowsProductos.Clear()
    '                    End If

    '                End If
    '            End With
    '        Case "Asignar unidad de medida"

    '            Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
    '            datos.Clear()
    '            With frmModalComprobantesTabla
    '                .x_Establecimiento = GEstableciento.IdEstablecimiento
    '                .lblTipo.Text = Tablas.UnidadMedidad
    '                'Select Case caso
    '                '    Case Tablas.Clasificacion
    '                '  .ToolStrip1.Enabled = True
    '                .Tablax = Tablas.UnidadMedidad
    '                'End Select
    '                .StartPosition = FormStartPosition.CenterParent
    '                .ShowDialog()
    '                If datos.Count > 0 Then

    '                    If Me.dgvProducto.SelectedRows.Count > 0 Then
    '                        Dim FilasSelect As DataGridViewSelectedRowCollection
    '                        FilasSelect = Me.dgvProducto.SelectedRows
    '                        Dim PrimeraFila As Integer = FilasSelect.Item(0).Index
    '                        Dim NumFilas As Integer = FilasSelect.Count

    '                        For Each i As DataGridViewRow In FilasSelect
    '                            nProducto = New Productos
    '                            nProducto.IdProducto = dgvProducto.Rows(i.Index).Cells(0).Value
    '                            nProducto.UnidadMedida = datos(0).ID
    '                            nProducto.NomUnidadMedida = datos(0).NombreCampo
    '                            dgvProducto.Rows(i.Index).Cells(8).Value = datos(0).ID
    '                            dgvProducto.Rows(i.Index).Cells(9).Value = datos(0).NombreCampo
    '                            ActualizarProductoID(nProducto, 2)
    '                        Next
    '                        dgvProducto.ClearSelection()
    '                        selectedRowsProductos.Clear()
    '                    End If

    '                End If
    '            End With
    '        Case "Limpiar seleccion"
    '            dgvProducto.ClearSelection()
    '            selectedRowsProductos.Clear()
    '        Case "copyRowValue"
    '            '
    '            'Copiamos el valor de toda la Fila selccionada al ClipBoard
    '            '
    '            Dim dataObj As DataObject = dgvProducto.GetClipboardContent()
    '            If dataObj IsNot Nothing Then
    '                Clipboard.SetDataObject(dataObj)
    '            End If
    '            Exit Select

    '        Case "deleteRow"
    '            '
    '            'Identificamos la Fila actualmente seleccionada
    '            '
    '            Dim row As DataGridViewRow = dgvProducto.CurrentRow
    '            '
    '            'Preguntamos si el valor de Row es diferente de null, esto para evitar posibles
    '            'excepciones de referencias Nulas
    '            '
    '            If row IsNot Nothing Then
    '                dgvProducto.Rows.Remove(row)
    '            End If

    '            Exit Select
    '    End Select
    'End Sub

    Private Sub cmenProductos_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmenProductos.Opening

    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvProducto.Rows.Count > 0 Then
            InsertProductos()
        Else
            lblEstado.Text = "Debe haber al menos una fila en la canasta de aportes"
        End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub cboModo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboModo.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboModo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboModo.SelectedIndexChanged
        datosCat = New List(Of Categoria)
        datosProductos = New List(Of Productos)
        If cboModo.Text = "DEFAULT" Then
            QTabPage1.Parent = Nothing
            QTabPage2.Parent = QTabControl1
            QTabPage3.Parent = Nothing
            QRibbonApplicationButton1.Visible = True
            dgvNuevoDoc.Rows.Clear()
            datosCat.Clear()
            datosProductos.Clear()
        ElseIf cboModo.Text = "EXCEL" Then
            QTabPage1.Parent = Nothing
            QTabPage2.Parent = Nothing
            QTabPage3.Parent = QTabControl1
            QRibbonApplicationButton1.Visible = False
            lstCategoria.DataSource = Nothing
            datosCat.Clear()
            datosProductos.Clear()
        End If
    End Sub

    Private Sub dgvNuevoDoc_CellContentClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellContentClick

    End Sub

    Private Sub dgvNuevoDoc_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellEndEdit
        Dim colCantidad As Decimal = 0
        Dim colPUmn As Decimal = 0
        Dim colPUme As Decimal = 0
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0
        Try
            If dgvNuevoDoc.Rows.Count > 0 Then
                If Not CStr(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese una cantidad válida!"
                    lblEstado.Image = My.Resources.warning2
                    Exit Sub
                Else
                    colCantidad = dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value
                End If

                If IsNothing(dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value) Then
                    lblEstado.Text = "Ingrese un precio unitario válido!"
                    lblEstado.Image = My.Resources.warning2
                    Exit Sub
                Else
                    If Not CStr(dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un precio unitario válida!"
                        lblEstado.Image = My.Resources.warning2
                        Exit Sub
                    Else
                        colPUmn = dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value
                    End If
                End If

                colPUme = Math.Round(colPUmn / CDec(txtTipoCambio.Value), 2).ToString("N2")
                colMN = (colCantidad * colPUmn) '.ToString("N2")
                colME = (colCantidad * colPUme) '.ToString("N2")
                dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value = colPUme
                dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value = colMN
                dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value = colME
                COntarDGV()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try

    End Sub

    Private Sub dgvNuevoDoc_CellMouseClick1(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvNuevoDoc.CellMouseClick
        If dgvNuevoDoc.Rows.Count > 0 Then
            If e.Button <> MouseButtons.Right Then
                Return
            End If

            If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then
                Return
            End If

            'enviamos el valor de la celda a la variable _cellValue
            '   _cellValue = dgvNuevoDoc(e.ColumnIndex, e.RowIndex).Value.ToString()

            'Definimos el lugar donde aparecera el scontextMenuStrip
            menItems.Show(MousePosition)
            QuitarItemToolStripMenuItem.Enabled = True
        Else
            menItems.Show(MousePosition)
            QuitarItemToolStripMenuItem.Enabled = False
        End If
    End Sub


    Sub MostrarDetalle()
        Me.Cursor = Cursors.WaitCursor
        Dim productoBE As New detalleitemsSA
        Dim objInsumo As GInsumo = GInsumo.InstanceSingle()
        objInsumo.Clear()
        With frmModalExistencia
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            '       lblTotalItems.Text = "Nro. de items: " & dgvNuevoDoc.Rows.Count

            If Not IsNothing(objInsumo.descripcionItem) Then
                'dgvNuevoDoc.Rows.Add(0, objInsumo.origenProducto, objInsumo.IdInsumo, objInsumo.descripcionItem,
                '                     objInsumo.presentacion,
                '                         objInsumo.Nombrepresentacion, objInsumo.unidad1, objInsumo.Cantidad, objInsumo.PU, objInsumo.PU, objInsumo.Total, objInsumo.Total, 0,
                '                      0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                '                      objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso)

                dgvNuevoDoc.Rows.Add("00", objInsumo.origenProducto, "EXISTENCIA", objInsumo.idClasificacion, objInsumo.NomClasificacion,
                                    objInsumo.IdInsumo, objInsumo.descripcionItem, objInsumo.tipoExistencia,
                                    objInsumo.presentacion, objInsumo.Nombrepresentacion, objInsumo.unidad1, objInsumo.unidadNombre,
                                    "0.00", "0.00", "0.00", "0.00", "0.00",
                                    Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, objInsumo.cuenta)


            End If

            If dgvNuevoDoc.Visible Then
                If dgvNuevoDoc.Rows.Count > 0 Then
                    Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(dgvNuevoDoc.Rows.Count - 1).Cells(12)
                    Me.dgvNuevoDoc.BeginEdit(True)
                End If
            Else

            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub menItems_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles menItems.ItemClicked
        Select Case e.ClickedItem.Text
            Case "Agregar Item"
                MostrarDetalle()
                COntarDGV()
                Exit Select
            Case "Quitar Item"
                Dim row As DataGridViewRow = dgvNuevoDoc.CurrentRow
                '
                'Preguntamos si el valor de Row es diferente de null, esto para evitar posibles
                'excepciones de referencias Nulas
                '
                If row IsNot Nothing Then
                    dgvNuevoDoc.Rows.Remove(row)
                End If
                COntarDGV()
                Exit Select
            Case "deleteRow"
                '
                'Identificamos la Fila actualmente seleccionada
                '

        End Select
    End Sub
    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvNuevoDoc.CurrentCell()

        If Celda.ColumnIndex = 12 Or Celda.ColumnIndex = 13 Or Celda.ColumnIndex = 14 Then

            If e.KeyChar = "."c Or e.KeyChar = ","c Then

                If InStr(Celda.EditedFormattedValue.ToString, ".", CompareMethod.Text) > 0 Then

                    e.Handled = True
                Else

                    e.Handled = False
                End If
            Else

                If Len(Trim(Celda.EditedFormattedValue.ToString)) > 0 Then

                    If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                        e.Handled = False
                    Else

                        e.Handled = True
                    End If
                Else

                    If e.KeyChar = "0"c Then

                        e.Handled = True
                    Else

                        If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                            e.Handled = False
                        Else

                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub dgvNuevoDoc_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvNuevoDoc.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvNuevoDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvNuevoDoc.KeyDown
        Dim conteo As Integer = dgvNuevoDoc.Rows.Count
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case (dgvNuevoDoc.CurrentCell.ColumnIndex)
                    Case 12
                        If cboMoneda.Text = "MONEDA NACIONAL" Then
                            If conteo = 1 Then
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(13, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(13, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            End If
                        Else
                            If conteo = 1 Then
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(14, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(14, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            End If
                        End If
                        'Case 3
                        '    Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(0, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                        'Case 10 Or 11
                        '    Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(23, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs)

    End Sub

    Private Sub dgvNuevoDoc_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvNuevoDoc.RowPostPaint
        Dim grid As DataGridView = TryCast(sender, DataGridView)

        If Not grid.RowHeadersVisible Then
            Return
        End If

        'this method overrides the DataGridView's RowPostPaint event 
        'in order to automatically draw numbers on the row header cells
        'and to automatically adjust the width of the column containing
        'the row header cells so that it can accommodate the new row
        'numbers,

        'store a string representation of the row number in 'strRowNumber'
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()

        'prepend leading zeros to the string if necessary to improve
        'appearance. For example, if there are ten rows in the grid,
        'row seven will be numbered as "07" instead of "7". Similarly, if 
        'there are 100 rows in the grid, row seven will be numbered as "007".
        While strRowNumber.Length < grid.RowCount.ToString().Length
            strRowNumber = Convert.ToString("0") & strRowNumber
        End While

        'determine the display size of the row number string using
        'the DataGridView's current font.
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, grid.Font)

        'adjust the width of the column that contains the row header cells 
        'if necessary
        If grid.RowHeadersWidth < CInt(size.Width + 20) Then
            grid.RowHeadersWidth = CInt(size.Width + 20)
        End If

        'this brush will be used to draw the row number string on the
        'row header cell using the system's current ControlText color
        Dim b As Brush = SystemBrushes.ControlText

        'draw the row number string on the current row header cell using
        'the brush defined above and the DataGridView's default font
        e.Graphics.DrawString(strRowNumber, grid.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                If Not txtProveedor.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese un accionista válido!"
                    Exit Sub
                End If

                If Not txtAlmacen.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese un almacén válido!"
                    Exit Sub
                End If
                If dgvNuevoDoc.Rows.Count > 0 Then
                    GrabarAporte()
                Else
                    lblEstado.Text = "Debe haber al menos una fila en la canasta de aportes"
                End If
            Else
                If Not txtProveedor.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese un accionista válido!"
                    Exit Sub
                End If

                Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                If Filas > 0 Then
                    UpdateAporte()
                Else
                    Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen.SelectedItems.Count > 0 Then
                Me.txtAlmacen.ValueMember = lstAlmacen.SelectedValue
                txtAlmacen.Text = lstAlmacen.Text
                ''  ListadoItemsEnTransito(MesGeneral, AnioGeneral, txtExistencia.ValueMember)
                'ObetnerListaProductosLST(txtAlmacen.ValueMember)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacen.Focus()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtAlmacen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub ButtonAdv6_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv6.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv3.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub


    Private Sub ButtonAdv8_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv8.Click
        Me.pcProveedor.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv7_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv7.Click
        Me.pcProveedor.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcProveedor_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcProveedor.BeforePopup
        Me.pcProveedor.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcProveedor_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcProveedor.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub dropDownBtn_Click(sender As System.Object, e As System.EventArgs) Handles dropDownBtn.Click
        pcProveedor.Font = New Font("Tahoma", 8)
        Me.pcProveedor.ParentControl = Me.txtProveedor
        Me.pcProveedor.ShowPopup(Point.Empty)
    End Sub

    Private Sub AsignarClasificacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarClasificacionToolStripMenuItem.Click

    End Sub
End Class
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmPantallaAportesDeInicio
    Implements IExistencias

    Public Property doc As New documentoLibroDiario
    Public Property documentoLibroSA As New documentoLibroDiarioSA
    Public Property EmpresaSA As New empresaSA
    Public Property selEmpresa As New empresa
    Public Alert As Alert
    Public Property ItemSelEstado As String
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvExistencias, False, False)
        dgvExistencias.BorderStyle = BorderStyle.FixedSingle
        selEmpresa = EmpresaSA.UbicarEmpresaRuc(Gempresas.IdEmpresaRuc)
        Dim fechaInicio = GetPeriodoConvertirToDate(selEmpresa.inicioOperacion)
        fechaInicio = fechaInicio.AddMonths(1)
        LblPeriodo.Text = GetPeriodo(fechaInicio, True)
        GConfiguracion = New GConfiguracionModulo
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "AST", Me.Text, GEstableciento.IdEstablecimiento)
        LoadCombos()
        doc = documentoLibroSA.GetRecuperarAporteExistencia(GetIniciarAporteExistencias)
        CMBClasificacion()
        txtFechaVcto.Value = Date.Now
        txtCategoria.Select()
    End Sub

    Dim listaCategoria As New List(Of item)
    Private Sub CMBClasificacion()
        Dim categoriaSA As New itemSA

        listaCategoria = New List(Of item)

        listaCategoria = categoriaSA.GetListaPadre()

    End Sub

    Sub GetInventarioDGV(idalmacen As Integer)
        Dim invSA As New inventarioMovimientoSA
        Dim dt As New DataTable
        dt.Columns.Add("iditem")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("detalle")
        dt.Columns.Add("unidad")
        dt.Columns.Add("tipoexistencia")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("costo")
        dt.Columns.Add("idInv")
        dt.Columns.Add("codigo")
        dt.Columns.Add("codigoLote")
        dt.Columns.Add("total")
        dt.Columns.Add("pu")

        Dim fechaPeriodo = CType("01" & "/" & selEmpresa.inicioOperacion, Date)
        fechaPeriodo = fechaPeriodo.AddMonths(1)
        Dim costoTotal As Decimal = 0
        Dim precunit As Decimal = 0
        For Each i In invSA.GetListaInicioExistencia(fechaPeriodo, selEmpresa.idEmpresa, idalmacen).OrderBy(Function(o) o.descripcion).ToList
            costoTotal = 0
            costoTotal = Math.Round(i.monto.GetValueOrDefault * 0.18, 2)
            costoTotal = Math.Round(costoTotal + i.monto.GetValueOrDefault, 2)

            Dim total2 = i.monto.GetValueOrDefault * 0.18
            total2 = total2 + i.monto.GetValueOrDefault
            If i.cantidad.GetValueOrDefault > 0 AndAlso i.monto.GetValueOrDefault > 0 Then
                precunit = costoTotal / i.cantidad.GetValueOrDefault
            Else
                precunit = 0
            End If

            dt.Rows.Add(i.idItem, i.Secuencia, i.descripcion, i.unidad, i.tipoExistencia,
                        i.cantidad, i.monto, i.idInventario, i.codigoBarra, i.nrolote, costoTotal, precunit)
        Next
        setDataSource(dt)
    End Sub
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            dgvExistencias.DataSource = table
            dgvExistencias.TableDescriptor.Columns("detalle").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvExistencias.TableDescriptor.Columns("detalle").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            ProgressBar1.Visible = False

        End If
    End Sub

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
    '                        '  GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        'txtSerie.Text = .serie
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            'If Not IsNothing(.configAlmacen) Then
    '            '    Dim estableSA As New establecimientoSA
    '            '    With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '            '        GConfiguracion.IdAlmacen = .idAlmacen
    '            '        GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '            '        'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '            '        'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '            '        With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '            '            'txtIdEstableAlmacen.Text = .idCentroCosto
    '            '            'txtEstableAlmacen.Text = .nombre
    '            '        End With
    '            '    End With
    '            'End If
    '            'If Not IsNothing(.ConfigentidadFinanciera) Then
    '            '    With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '            '        GConfiguracion.IDCaja = .idestado
    '            '        GConfiguracion.NomCaja = .descripcion
    '            '    End With
    '            'End If

    '        End With
    '    Else
    '        '    lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Function GrabarNuevoArticulo() As detalleitems
        Dim objitem As New detalleitems
        Dim itemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim c As New RecuperarCarteras
        Try
            'Se asigna cada uno de los datos registrados
            objitem.idItem = 0 ' CInt(txtCategoria.Tag)
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.marcaRef = Nothing
            objitem.descripcionItem = txtArticulo.Text.Trim
            objitem.presentacion = "09"
            objitem.unidad1 = cboUnidades.SelectedValue
            objitem.cuenta = "601111"
            objitem.cantMax = 100
            objitem.cantMinima = 10
            objitem.codigo = txtCodigo.Text
            objitem.tipoExistencia = cboTipoExistencia.SelectedValue
            Select Case cboIgv.Text
                Case "1 - GRAVADO"
                    objitem.origenProducto = OperacionGravada.Grabado
                Case "2 - EXONERADO"
                    objitem.origenProducto = OperacionGravada.Exonerado
                Case "3 - INAFECTO"
                    objitem.origenProducto = OperacionGravada.Inafecto
            End Select
            objitem.tipoProducto = "I"
            objitem.usuarioActualizacion = usuario.IDUsuario
            objitem.fechaActualizacion = DateTime.Now
            'If Precios = True Then
            objitem.idAlmacen = Nothing

            'Dim codxIdtem As Integer = itemSA.InsertItemDualTabla(objitem)
            '      Return objitem
        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            MessageBox.Show("La existencia ingresada tiene un codigo que ya esta siendo utilizada cambie el codigo", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        Return objitem
    End Function

    Private Function GetIniciarAporteExistencias() As documento
        Dim documento As New documento
        Dim documentoLibroDiario As New documentoLibroDiario

        '    selEmpresa = EmpresaSA.UbicarEmpresaRuc(Gempresas.IdEmpresaRuc)
        Dim fechaPeriodo = CType("01" & "/" & selEmpresa.inicioOperacion, Date)
        fechaPeriodo = fechaPeriodo.AddMonths(1)

        documento = New documento
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = fechaPeriodo
        documento.idEntidad = usuario.IDUsuario
        documento.entidad = usuario.CustomUsuario.Full_Name
        documento.nrodocEntidad = usuario.CustomUsuario.NroDocumento
        documento.tipoEntidad = "US"
        documento.nroDoc = "1"
        documento.tipoOperacion = "105"
        documento.idOrden = Nothing
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now

        documentoLibroDiario = New documentoLibroDiario
        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = "APT_EXT"
        documentoLibroDiario.fecha = fechaPeriodo
        documentoLibroDiario.fechaPeriodo = String.Format("{0:00}", fechaPeriodo.Month) & "/" & fechaPeriodo.Year
        documentoLibroDiario.tipoRazonSocial = "OT"
        documentoLibroDiario.razonSocial = Nothing
        documentoLibroDiario.infoReferencial = "Por ingreso de existencias por apertura"

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = "105"
        documentoLibroDiario.moneda = "1"
        documentoLibroDiario.tipoCambio = TmpTipoCambio
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = fechaPeriodo
        documentoLibroDiario.tieneCosto = "N"
        documentoLibroDiario.idCosto = Nothing
        documentoLibroDiario.importeMN = 0
        documentoLibroDiario.importeME = 0
        documento.documentoLibroDiario = documentoLibroDiario

        Return documento
    End Function

    Private Sub LoadCombos()
        Dim tablasa As New tablaDetalleSA
        Dim almacenSA As New almacenSA
        cboalmacenKardex.DataSource = almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)
        cboalmacenKardex.DisplayMember = "descripcionAlmacen"
        cboalmacenKardex.ValueMember = "idAlmacen"

        cboTipoExistencia.DataSource = tablasa.GetListaTablaDetalle(5, "1")
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"

        cboUnidades.DataSource = tablasa.GetListaTablaDetalle(6, "1")
        cboUnidades.DisplayMember = "descripcion"
        cboUnidades.ValueMember = "codigoDetalle2"
        cboUnidades.Text = "UNIDADES"
        'cboIgv.Text = "2 - EXONERADO"
    End Sub
    Dim empresaPeriodoSA As New empresaCierreMensualSA
    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim fechaActual As DateTime = DateTime.Now
            'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = doc.fecha.Value.Year, .mes = doc.fecha.Value.Month})

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaActual.Year, .mes = fechaActual.Month})
            If Not IsNothing(valida) Then
                If valida = True Then
                    'MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Alert = New Alert("Debe abrir el período", General.Constantes.alertType.Errors)
                    Alert.TopMost = True
                    Alert.Show()
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If ValidarGrabado() = True Then
                GrabarProducto()
                BunifuThinButton22_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
    End Sub
    'txtCant.DecimalValue * (txtprecioUnit.DecimalValue / 1.18)
    Private Sub GrabarProducto()
        Dim nuevoArticulo As New detalleitems
        Dim detalleItemSA As New detalleitemsSA
        Dim item As New totalesAlmacen
        Dim inv As New InventarioMovimiento
        Dim lote As New recursoCostoLote
        Dim strTipoIva As String = Nothing
        Dim ImporteCosto As Decimal = 0

        'Dim art = detalleItemSA.InvocarProductoID(txtArticulo.Tag)

        Select Case cboIgv.Text
            Case "1 - GRAVADO"
                strTipoIva = "1"
                ImporteCosto = TextBase.DecimalValue'  txtCant.DecimalValue * (txtprecioUnit.DecimalValue / 1.18)
            Case "2 - EXONERADO"
                strTipoIva = "2"
                ImporteCosto = txtCosto.DecimalValue
            Case "3 - INAFECTO"
                strTipoIva = "3"
                ImporteCosto = txtCosto.DecimalValue
        End Select

        lote = New recursoCostoLote
        If CheckBox1.Checked = False Then
            If txtNroLote.Text.Trim.Length > 0 Then
                lote.nroLote = txtNroLote.Text.Trim
            Else
                lote.nroLote = "-"
            End If
            lote.fechaentrada = DateTime.Now
            lote.fechaProduccion = txtFechaVcto.Value
            lote.fechaVcto = txtFechaVcto.Value
            lote.productoSustentado = True
        Else
            lote.fechaentrada = DateTime.Now
            lote.nroLote = "-"
            lote.fechaProduccion = Nothing
            lote.fechaVcto = Nothing
            lote.productoSustentado = True
        End If
        lote.detalle = txtArticulo.Text.Trim

        item = New totalesAlmacen With {
            .CustomLote = lote,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .idAlmacen = cboalmacenKardex.SelectedValue,
            .origenRecaudo = strTipoIva,
            .tipoCambio = 0,
            .tipoExistencia = cboTipoExistencia.SelectedValue,
            .idItem = 0,
            .descripcion = txtArticulo.Text,
            .idUnidad = cboUnidades.SelectedValue,
            .unidadMedida = cboUnidades.SelectedValue,
            .cantidad = txtCant.DecimalValue,
            .precioUnitarioCompra = 0,
            .importeSoles = ImporteCosto,
            .importeDolares = 0,
            .montoIsc = 0,
            .montoIscUS = 0,
            .Otros = 0,
            .OtrosUS = 0,
            .porcentajeUtilidad = 0,
            .importePorcentaje = 0,
            .importePorcentajeUS = 0,
            .precioVenta = 0,
            .precioVentaUS = 0,
            .cantidadMaxima = 100,
            .cantidadMinima = 10,
            .status = StatusArticulo.Activo,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now
           }

        inv = New InventarioMovimiento
        inv.idEmpresa = Gempresas.IdEmpresaRuc
        inv.idEstablecimiento = GEstableciento.IdEstablecimiento
        inv.idAlmacen = cboalmacenKardex.SelectedValue
        inv.nrolote = "-"
        inv.tipoOperacion = StatusTipoOperacion.SALDO_INICIAL_O_CIERRES
        inv.tipoDocAlmacen = "99"
        inv.serie = doc.serie
        inv.numero = doc.nroDoc
        inv.idDocumento = doc.idDocumento
        inv.idDocumentoRef = doc.idDocumento
        inv.descripcion = txtArticulo.Text.Trim
        inv.fechaLaboral = Date.Now
        inv.fecha = DateTime.Now ' doc.fecha
        inv.tipoRegistro = "E"
        inv.destinoGravadoItem = strTipoIva
        inv.tipoProducto = cboTipoExistencia.SelectedValue
        inv.OrigentipoProducto = "I"
        inv.cuentaOrigen = "60111"
        inv.idItem = 0
        inv.marca = Nothing
        inv.presentacion = Nothing
        inv.fechavcto = Nothing
        inv.cantidad = txtCant.DecimalValue
        inv.unidad = cboUnidades.SelectedValue
        inv.cantidad2 = 0
        inv.unidad2 = Nothing
        inv.precUnite = 0
        inv.precUniteUSD = 0
        inv.monto = ImporteCosto '  txtCosto.DecimalValue
        inv.montoUSD = 0
        inv.montoOther = 0
        inv.monedaOther = "1"
        inv.disponible = 0
        inv.disponible2 = 0
        inv.saldoMonto = 0
        inv.saldoMontoUsd = 0
        inv.status = "D"
        inv.entragado = "SI"
        inv.preEvento = Nothing
        inv.usuarioActualizacion = usuario.IDUsuario
        inv.consignado = Nothing
        inv.fechaActualizacion = Date.Now

        Dim listaItemsParecidos = detalleItemSA.GetExistenciasByempresaNombre(txtArticulo.Text.Trim, Gempresas.IdEmpresaRuc)
        If listaItemsParecidos.Count > 0 Then
            Dim f As New FormArticulosHomogeneos(listaItemsParecidos)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Select Case f.Tag
                    Case "Cancel"
                        Exit Sub
                End Select
            End If
        End If

        nuevoArticulo = GrabarNuevoArticulo()
        GetPrecios(nuevoArticulo, DateTime.Now) 'doc.fecha)

        If ItemSelEstado = "Existe" Then
            nuevoArticulo.codigodetalle = txtArticulo.Tag
            documentoLibroSA.GrabaritemExistenciaInicioExistente(nuevoArticulo, item, inv)
        Else
            documentoLibroSA.GrabaritemExistenciaInicio(nuevoArticulo, item, inv)
        End If
        txtArticulo.Clear()
        txtCodigo.Clear()
        txtArticulo.Select()

        txtprecioMenor.DecimalValue = 0
        txtprecioMayor.DecimalValue = 0
        txtprecioGranmayor.DecimalValue = 0

        txtprecioUnit.DecimalValue = 0
        txtCant.DecimalValue = 0
        txtCosto.DecimalValue = 0
        txtNroLote.Clear()

        Alert = New Alert("Producto Agregado", General.Constantes.alertType.success)
        Alert.TopMost = True
        Alert.Show()
    End Sub

    Sub GetPrecios(nuevoArticulo As detalleitems, fecha As DateTime)
        Dim precio As configuracionPrecioProducto
        '-------- AGREGANDO PRECIOS GENERALES ------------------------

        nuevoArticulo.CustomPrecios = New List(Of configuracionPrecioProducto)

        'X menor
        precio = New configuracionPrecioProducto
        precio.idPrecio = 1
        precio.fecha = New Date(fecha.Year, fecha.Month, 1)
        precio.tipo = 1
        precio.valPorcentaje = 0
        precio.nroLote = Nothing
        precio.descripcion = "Precio por Menor"
        precio.precioMN = txtprecioMenor.DecimalValue
        precio.precioME = 0
        nuevoArticulo.CustomPrecios.Add(precio)

        'X mayor
        precio = New configuracionPrecioProducto
        precio.idPrecio = 2
        precio.fecha = New Date(fecha.Year, fecha.Month, 1)
        precio.tipo = 1
        precio.valPorcentaje = 0
        precio.nroLote = Nothing
        precio.descripcion = "Precio por Mayor"
        precio.precioMN = txtprecioMayor.DecimalValue
        precio.precioME = 0
        nuevoArticulo.CustomPrecios.Add(precio)

        'X gran mayor
        precio = New configuracionPrecioProducto
        precio.idPrecio = 3
        precio.fecha = New Date(fecha.Year, fecha.Month, 1)
        precio.tipo = 1
        precio.valPorcentaje = 0
        precio.nroLote = Nothing
        precio.descripcion = "Precio por Gran Mayor"
        precio.precioMN = txtprecioGranmayor.DecimalValue
        precio.precioME = 0
        nuevoArticulo.CustomPrecios.Add(precio)
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs)

    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        'If Not txtCategoria.Text.Trim.Length > 0 Then
        '    ErrorProvider1.SetError(txtCategoria, "Ingrese la clasificación general")
        '    listaErrores += 1
        'Else
        '    ErrorProvider1.SetError(txtCategoria, Nothing)
        'End If

        'If txtCategoria.Text.Trim.Length > 0 Then
        '    If txtCategoria.ForeColor = Color.Black Then
        '        ErrorProvider1.SetError(txtCategoria, "Verificar el ingreso correcto de la clasificación general")
        '        listaErrores += 1
        '    Else
        '        ErrorProvider1.SetError(txtCategoria, Nothing)
        '    End If
        'End If


        If txtArticulo.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtArticulo, "Ingrese un artículo")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtArticulo, Nothing)
        End If
        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        Dim codAlmacen = cboalmacenKardex.SelectedValue
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventarioDGV(codAlmacen)))
        thread.Start()
    End Sub

    Private Sub dgvExistencias_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvExistencias.TableControlCellClick

    End Sub
    Dim inv As InventarioMovimiento
    Dim invSA As New inventarioMovimientoSA
    Private Sub dgvExistencias_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvExistencias.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim r As Record = dgvExistencias.Table.CurrentRecord
        Dim fechaActual As DateTime = DateTime.Now
        If r IsNot Nothing Then
            Select Case ColIndex
                Case 8 'precio unitario
                    'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = doc.fecha.Value.Year, .mes = doc.fecha.Value.Month})

                    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaActual.Year, .mes = fechaActual.Month})

                    If Not IsNothing(valida) Then
                        If valida = True Then
                            MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                    CalculoItemByPrec(invSA, r)
                Case 7
                    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaActual.Year, .mes = fechaActual.Month})
                    If Not IsNothing(valida) Then
                        If valida = True Then
                            MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                    CalculoItem(invSA, r)

                Case 12
                    Dim baseImponible As Decimal = 0
                    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaActual.Year, .mes = fechaActual.Month})
                    If Not IsNothing(valida) Then
                        If valida = True Then
                            MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                    If CDec(r.GetValue("total")) > 0 Then
                        baseImponible = Math.Round(CDec(r.GetValue("total")) / 1.18, 2)
                    Else
                        baseImponible = 0
                    End If
                    r.SetValue("costo", baseImponible)
                    CalculoItem(invSA, r)
            End Select
        End If
    End Sub

    Private Sub CalculoItemByPrec(invSA As inventarioMovimientoSA, r As Record)
        Dim baseImponible As Decimal = 0
        Dim cantidad As Decimal = r.GetValue("cantidad")
        Dim precio As Decimal = r.GetValue("pu")

        Dim Total As Decimal = cantidad * precio
        baseImponible = Total / 1.18
        r.SetValue("costo", baseImponible)
        r.SetValue("total", Total)

        inv = New InventarioMovimiento
        inv.nrolote = r.GetValue("codigoLote")
        inv.Secuencia = r.GetValue("secuencia")
        inv.idAlmacen = cboalmacenKardex.SelectedValue
        inv.idInventario = Integer.Parse(r.GetValue("idInv"))
        inv.idItem = Integer.Parse(r.GetValue("iditem"))
        inv.fecha = doc.fecha
        inv.cantidad = Decimal.Parse(r.GetValue("cantidad"))
        inv.monto = baseImponible ' Decimal.Parse(r.GetValue("costo"))
        invSA.EditarArticuloInicio(inv)
    End Sub

    Private Sub CalculoItem(invSA As inventarioMovimientoSA, r As Record)
        Dim baseImponible As Decimal = 0
        'Dim cantidad As Decimal = r.GetValue("cantidad")
        'Dim precio As Decimal = r.GetValue("pu")

        'Dim Total As Decimal = cantidad * precio

        If CDec(r.GetValue("total")) > 0 Then
            baseImponible = CDec(r.GetValue("total")) / 1.18
        Else
            baseImponible = 0
        End If
        inv = New InventarioMovimiento
        inv.nrolote = r.GetValue("codigoLote")
        inv.Secuencia = r.GetValue("secuencia")
        inv.idAlmacen = cboalmacenKardex.SelectedValue
        inv.idInventario = Integer.Parse(r.GetValue("idInv"))
        inv.idItem = Integer.Parse(r.GetValue("iditem"))
        inv.fecha = doc.fecha
        inv.cantidad = Decimal.Parse(r.GetValue("cantidad"))
        inv.monto = baseImponible ' Decimal.Parse(r.GetValue("costo"))
        invSA.EditarArticuloInicio(inv)
    End Sub

    Private Sub EliminarItem(invSA As inventarioMovimientoSA, r As Record)
        inv = New InventarioMovimiento
        inv.nrolote = r.GetValue("codigoLote")
        inv.Secuencia = r.GetValue("secuencia")
        inv.idAlmacen = cboalmacenKardex.SelectedValue
        inv.idInventario = Integer.Parse(r.GetValue("idInv"))
        inv.idItem = Integer.Parse(r.GetValue("iditem"))
        inv.fecha = doc.fecha
        inv.cantidad = Decimal.Parse(r.GetValue("cantidad"))
        inv.monto = Decimal.Parse(r.GetValue("costo"))
        invSA.EliminarArticuloInicio(inv)

        Alert = New Alert("Artículo eliminado", alertType.info)
        Alert.TopMost = True
        Alert.Show()
        r.Delete()
    End Sub

    Private Sub txtCant_TextChanged(sender As Object, e As EventArgs) Handles txtCant.TextChanged
        CalculoCosto()
    End Sub

    Private Sub CalculoCosto()
        txtCosto.DecimalValue = txtCant.DecimalValue * txtprecioUnit.DecimalValue
        If txtCosto.DecimalValue > 0 Then
            TextBase.DecimalValue = CalculoBaseImponible(txtCosto.DecimalValue, 1.18)
        Else
            TextBase.DecimalValue = 0
        End If
    End Sub

    Private Sub txtprecioUnit_TextChanged(sender As Object, e As EventArgs) Handles txtprecioUnit.TextChanged
        CalculoCosto()
    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged
        txtCategoria.ForeColor = Color.Black
        txtCategoria.Tag = Nothing
    End Sub

    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaCategoria
                            Where n.descripcion.StartsWith(txtCategoria.Text)).ToList

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
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
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

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCategoria.SelectedItems.Count > 0 Then
                txtCategoria.Text = lsvCategoria.Text
                txtCategoria.Tag = lsvCategoria.SelectedValue
                txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim datos As List(Of item) = item.Instance()
        datos.Clear()

        Dim f As New frmNuevaClasificacion
        f.txtDescripcion.Text = txtCategoria.Text
        txtCategoria.Clear()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        CMBClasificacion()
        If datos.Count > 0 Then
            txtCategoria.Text = datos(0).descripcion
            txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCategoria.Tag = CInt(datos(0).idItem)
        End If
    End Sub

    Private Sub txtCant_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCant.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            CalculoCosto()
            txtprecioUnit.Select()
        End If
    End Sub

    Private Sub txtprecioUnit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecioUnit.KeyPress

    End Sub

    Private Sub txtprecioUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtprecioUnit.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            CalculoCosto()
            txtprecioMenor.Select()
        End If
    End Sub

    Private Sub txtCosto_TextChanged(sender As Object, e As EventArgs) Handles txtCosto.TextChanged
        CalculoCosto()
    End Sub

    Private Sub txtCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCosto.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            CalculoCosto()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtNroLote.Clear()
            txtFechaVcto.Enabled = False
            txtNroLote.Enabled = False
        Else
            txtFechaVcto.Enabled = True
            txtNroLote.Enabled = True
        End If
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgvExistencias.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New frmEditarArticuloLote(r.GetValue("iditem"), r.GetValue("codigoLote"), cboalmacenKardex.SelectedValue)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            BunifuThinButton22_Click(sender, e)
        Else
            MessageBox.Show("Debe seleccionar un artículo válido", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub frmPantallaAportesDeInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = False
        dgvExistencias.TableDescriptor.Columns("cantidad").ReadOnly = False
        dgvExistencias.TableDescriptor.Columns("costo").ReadOnly = True
        If Gempresas.Regimen = "1" Then
            cboIgv.Text = "1 - GRAVADO"
            cboIgv.Enabled = True
        Else
            cboIgv.Text = "2 - EXONERADO"
            cboIgv.Enabled = True
        End If
    End Sub

    Private Sub txtprecioMenor_TextChanged(sender As Object, e As EventArgs) Handles txtprecioMenor.TextChanged

    End Sub

    Private Sub txtprecioMenor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtprecioMenor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtprecioMayor.Select()
        End If

    End Sub

    Private Sub txtprecioMayor_TextChanged(sender As Object, e As EventArgs) Handles txtprecioMayor.TextChanged

    End Sub

    Private Sub txtprecioMayor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtprecioMayor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtprecioGranmayor.Select()
        End If
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim r As Record = dgvExistencias.Table.CurrentRecord
            If r IsNot Nothing Then
                If MessageBox.Show("Va eliminar el artículo seleccionado ?", "Atención", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    EliminarItem(invSA, r)
                End If
            Else
                MessageBox.Show("Debe seleccionar un artículo válido", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Atención!")
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub lsvCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCategoria.SelectedIndexChanged

    End Sub

    Public Sub EnviarItem(productoBE As detalleitems) Implements IExistencias.EnviarItem
        Try
            ItemSelEstado = "Existe"
            txtArticulo.Text = productoBE.descripcionItem
            txtArticulo.Tag = productoBE.codigodetalle
            txtCodigo.Text = productoBE.codigo
            cboUnidades.SelectedValue = productoBE.unidad1
            cboIgv.SelectedValue = productoBE.origenProducto
            cboTipoExistencia.SelectedValue = productoBE.tipoExistencia
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New FormCanastaCompras
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub
End Class
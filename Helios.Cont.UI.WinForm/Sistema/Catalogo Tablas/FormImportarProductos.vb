Imports Helios.Cont.Business.Entity
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports System.ComponentModel

Public Class FormImportarProductos

#Region "Attributes"
    Dim Alert As Alert
    Dim conf As New GConfiguracionModulo
#End Region

#Region "Constructors"
    Public Sub New(grid As List(Of Record))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCompra, False, False)
        LoadCombos()
        GetProducts(grid)
        BackgroundWorker1.RunWorkerAsync()
    End Sub

#End Region

#Region "Methods"

    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
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
                GConfiguracion.TipoComprobante = "9901" 'RecuperacionNumeracion.tipo
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

    'Public Function ConfigurarComprobanteVenta(moduloConfiguracion As moduloConfiguracion) As GConfiguracionModulo
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion2.TipoComprobante = "9901" ' .tipo
    '                        GConfiguracion2.Serie = .serie
    '                        GConfiguracion2.ValorActual = .valorInicial

    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else

    '    End If
    '    Return GConfiguracion2
    'End Function

    Dim sumaMN As Decimal = 0
    Dim sumaME As Decimal = 0
    Sub GrabarVouCher()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento
        Dim provSel As New entidad
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaTotalesOrigen As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        Dim fechaEnvio = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)

        sumaMN = 0
        sumaME = 0

        provSel = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, Nothing, GEstableciento.IdEstablecimiento)

        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = "9901"  ' "99"
        ndocumento.fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) ' txtFechaComprobante.Value
        ndocumento.nroDoc = conf.Serie & "-" & conf.Serie
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.moneda = "1"
        ndocumento.idEntidad = provSel.idEntidad
        ndocumento.entidad = "Varios"
        ndocumento.nrodocEntidad = "-"
        ndocumento.tipoEntidad = provSel.tipoEntidad
        ndocumento.tipoOperacion = "17"
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now
        '-------------------------------------------------------------------------------------------------
        nDocumentoCompra = New documentocompra
        nDocumentoCompra.situacion = "17"
        nDocumentoCompra.idPadre = 0
        nDocumentoCompra.codigoLibro = "13"
        nDocumentoCompra.tipoDoc = "9901"
        nDocumentoCompra.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCompra.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCompra.fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        nDocumentoCompra.fechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) 'txtFechaComprobante.Value ' PERIODO
        nDocumentoCompra.fechaContable = GetPeriodo(fechaEnvio.Date, True)
        nDocumentoCompra.serie = conf.Serie
        nDocumentoCompra.numeroDoc = conf.Serie
        nDocumentoCompra.aprobado = "N"

        nDocumentoCompra.idProveedor = provSel.idEntidad
        nDocumentoCompra.nombreProveedor = "Varios"

        nDocumentoCompra.monedaDoc = "1"
        nDocumentoCompra.tasaIgv = 0
        nDocumentoCompra.tcDolLoc = TmpTipoCambio
        nDocumentoCompra.tipoRecaudo = Nothing
        nDocumentoCompra.regimen = Nothing
        nDocumentoCompra.tasaRegimen = 0
        nDocumentoCompra.nroRegimen = Nothing
        nDocumentoCompra.importeTotal = sumaMN
        nDocumentoCompra.importeUS = sumaME
        nDocumentoCompra.destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
        nDocumentoCompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        nDocumentoCompra.glosa = "Por aporte de inventario de inicio"
        nDocumentoCompra.referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty
        nDocumentoCompra.tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
        nDocumentoCompra.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCompra.fechaActualizacion = DateTime.Now
        ndocumento.documentocompra = nDocumentoCompra

        '  GuiaRemision(ndocumento)

        'ASIENTOS CONTABLES
        Dim almacenSA As New almacenSA
        Dim costoSA As New recursoCostoLoteSA
        If dgvCompra.Table.Records IsNot Nothing AndAlso dgvCompra.Table.Records.Count > 0 Then
            Dim precios As New List(Of configuracionPrecioProducto)
            For Each r As Record In dgvCompra.Table.Records

                If r.GetValue("menor").ToString.Trim.Length > 0 Then

                    If Decimal.Parse(r.GetValue("menor")) > 0 Then
                        precios.Add(
                            New configuracionPrecioProducto With
                            {
                            .fecha = DateTime.Now,
                            .tipo = 1,
                            .valPorcentaje = 0,
                            .idproducto = Integer.Parse(r.GetValue("idProducto")),
                            .idPrecio = 1,
                            .descripcion = "Precio por Menor",
                            .precioMN = Decimal.Parse(r.GetValue("menor")),
                            .precioME = 0
                            })
                    End If
                End If
                If r.GetValue("mayor").ToString.Trim.Length > 0 Then
                    If Decimal.Parse(r.GetValue("mayor")) > 0 Then
                        precios.Add(
                            New configuracionPrecioProducto With
                            {
                            .fecha = DateTime.Now,
                            .tipo = 1,
                            .valPorcentaje = 0,
                            .idproducto = Integer.Parse(r.GetValue("idProducto")),
                            .idPrecio = 2,
                            .descripcion = "Precio por Mayor",
                            .precioMN = Decimal.Parse(r.GetValue("mayor")),
                            .precioME = 0
                            })
                    End If
                End If

                If r.GetValue("gmayor").ToString.Trim.Length > 0 Then
                    If Decimal.Parse(r.GetValue("gmayor")) > 0 Then
                        precios.Add(
                            New configuracionPrecioProducto With
                            {
                            .fecha = DateTime.Now,
                            .tipo = 1,
                            .valPorcentaje = 0,
                            .idproducto = Integer.Parse(r.GetValue("idProducto")),
                            .idPrecio = 3,
                            .descripcion = "Precio por Gran Mayor",
                            .precioMN = Decimal.Parse(r.GetValue("gmayor")),
                            .precioME = 0
                            })
                    End If
                End If


                If precios.Count = 0 Then
                    Throw New Exception("Debe ingresar al menos un precio de venta")
                End If


                objDocumentoCompraDet = New documentocompradetalle
                objDocumentoCompraDet.CustomPrecios = precios

                ndocumento.documentocompra.AsigancionDeLotes = "POR LOTES"
                Dim nroLotex = "0"

                If nroLotex.ToString.Trim.Length > 0 Then
                    objDocumentoCompraDet.nrolote = nroLotex

                    objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                    objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = nroLotex
                    objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = fechaEnvio
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = Nothing
                    objDocumentoCompraDet.CustomRecursoCostoLote.productoSustentado = True
                Else
                    objDocumentoCompraDet.nrolote = CInt(conf.Serie) & "-" & CInt(conf.Serie)

                    objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaentrada = ndocumento.documentocompra.fechaDoc
                    objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = CInt(conf.Serie) & "-" & CInt(conf.Serie)
                    objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaProduccion = fechaEnvio
                    objDocumentoCompraDet.CustomRecursoCostoLote.fechaVcto = Nothing
                    objDocumentoCompraDet.CustomRecursoCostoLote.productoSustentado = True
                End If

                objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                objDocumentoCompraDet.Serie = conf.Serie
                objDocumentoCompraDet.NumDoc = conf.Serie
                objDocumentoCompraDet.TipoDoc = "9901" ' "99"
                objDocumentoCompraDet.FlagModificaPrecioVenta = Nothing ' Me.dgvMov.Table.CurrentRecord.GetValue("valCheck")
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
                objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
                objDocumentoCompraDet.porcUtimenor = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("utiMenor")
                objDocumentoCompraDet.porcUtimayor = 0 'Me.dgvMov.Table.CurrentRecord.GetValue("utiMayor")
                objDocumentoCompraDet.porcUtigranMayor = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("utiGranMayor")
                objDocumentoCompraDet.TipoOperacion = "17"
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.FechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) 'txtFechaComprobante.Value
                objDocumentoCompraDet.CuentaProvedor = "4212"
                objDocumentoCompraDet.NombreProveedor = "Varios"
                objDocumentoCompraDet.destino = r.GetValue("grav")
                objDocumentoCompraDet.idItem = r.GetValue("idPriducto")
                objDocumentoCompraDet.tipoExistencia = "01"
                objDocumentoCompraDet.descripcionItem = r.GetValue("item")
                objDocumentoCompraDet.unidad1 = r.GetValue("um")

                If IsNumeric(r.GetValue("cantidad")) Then
                    If CDec(r.GetValue("cantidad")) <= 0 Then
                        MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                'If IsNumeric(r.GetValue("importeMN")) Then
                '    If CDec(r.GetValue("importeMN")) <= 0 Then
                '        MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        Me.Cursor = Cursors.Arrow
                '        Exit Sub
                '    End If
                'Else
                '    MessageBox.Show("El valor del importe debe ser mayor a cero", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Me.Cursor = Cursors.Arrow
                '    Exit Sub
                'End If


                objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad"))
                objDocumentoCompraDet.unidad2 = Nothing
                objDocumentoCompraDet.monto2 = Nothing
                objDocumentoCompraDet.precioUnitario = 0 ' CDec(r.GetValue("precMN"))
                objDocumentoCompraDet.precioUnitarioUS = 0 ' CDec(r.GetValue("precME"))

                Select Case r.GetValue("gravado")
                    Case 1
                        objDocumentoCompraDet.importe = 0 ' CType(r.GetValue("MontoBase"), Decimal)
                        objDocumentoCompraDet.importeUS = 0 ' Math.Round(CDec(r.GetValue("MontoBase")) / TmpTipoCambio, 2)

                    Case Else
                        objDocumentoCompraDet.importe = 0 ' CType(r.GetValue("importeMN"), Decimal)
                        objDocumentoCompraDet.importeUS = 0 ' CType(r.GetValue("importeME"), Decimal)
                End Select
                sumaMN += 0 'CDec(r.GetValue("importeMN"))
                sumaME += 0 'CDec(r.GetValue("importeME"))


                objDocumentoCompraDet.FechaVcto = Nothing
                objDocumentoCompraDet.preEvento = Nothing
                objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(cboAlmacen.SelectedValue).idEstablecimiento
                objDocumentoCompraDet.almacenRef = cboAlmacen.SelectedValue
                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoCompraDet.fechaModificacion = DateTime.Now
                objDocumentoCompraDet.Glosa = "Por aporte de iventario inicial"
                ListaDetalle.Add(objDocumentoCompraDet)
            Next

        End If
        ndocumento.documentocompra.importeTotal = sumaMN
        ndocumento.documentocompra.importeUS = sumaME
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        Dim xcod As Integer = CompraSA.SaveOtrasEntradasDefault(ndocumento, ListaTotales)
        Alert = New Alert("Entrada guardada", alertType.success)
        Alert.TopMost = True
        Alert.Show()
        Dispose()
    End Sub

    Private Sub GetCMBMeses()
        Dim listaAnios As New empresaPeriodoSA
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = listaAnios.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
    End Sub

    Private Sub LoadCombos()
        Dim almacenSA As New almacenSA

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        GetCMBMeses()
    End Sub

    Private Sub GetProducts(grid As List(Of Record))
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("menor")
        dt.Columns.Add("mayor")
        dt.Columns.Add("gmayor")

        For Each i In grid
            dt.Rows.Add(0, i.GetValue("impuesto"),
                        i.GetValue("codigo"),
                        i.GetValue("descripcion"),
                        i.GetValue("unidad"), 0, 0, 0, 0)
        Next
        dgvCompra.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then

        End If
    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            If TxtDia.Text.Trim.Length > 0 Then
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
            Else
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                TxtDia.Clear()
            End If
        End If
    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            TxtDia_TextChanged(sender, e)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim strIdModulo As String = Nothing
        strIdModulo = "TEA"
        Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        configuracionModuloV2(strIDEmpresa, strIdModulo, "", GEstableciento.IdEstablecimiento)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar2.Visible = False
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Cursor = Cursors.WaitCursor
        Try
            GrabarVouCher()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
    End Sub
#End Region
End Class
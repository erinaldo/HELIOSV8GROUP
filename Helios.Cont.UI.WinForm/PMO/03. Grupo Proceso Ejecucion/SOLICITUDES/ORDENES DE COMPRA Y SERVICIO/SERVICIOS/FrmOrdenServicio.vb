Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class FrmOrdenServicio
    Inherits frmMaster

    Sub ControlsHide()

    End Sub


#Region "Manipulación Data"

    Public Sub UbicarDocumentos(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim entidadSA As New entidadSA
        Dim tablaDetalleSA As New tablaDetalleSA
        Dim docOtros As New DocumentoOtrosDatosSA

        With documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)


            With docOtros.UbicarDocumentoOtros(intIdDocumento)
                fechainicio.Value = .fechaInicio
                fechafin.Value = .fechaFin
                CboPago.Text = tablaDetalleSA.GetUbicarTablaID(501, .condicionPago).descripcion
                txtVcto.Text = .Vcto
                cboModalidad.Text = tablaDetalleSA.GetUbicarTablaID(1, .Modalidad).descripcion
                txtcto.Text = .ctaDeposito
                txtFinaciera.Text = .institucionFinanciera
                txtContratacion.Text = .objetoContratacion
                txtImporteContratacion.Text = .importeContratacionMN
                'txtImporteContratacion.Text = .importeContratacionMN
                txtPeriodoValorizacion.Text = .periodoValorizacion
                txtPenalidades.Text = .penalidades
                'txtDetracciones.Text = .etracciones
                'txtAdelanto.Text = .adelanto
                'txtFondoGarantia.Text = .fondoGarantia

                If (.moneda = "1") Then
                    CboMonedaPago.DisplayMember = "NACIONAL"
                    CboMonedaPago.SelectedValue = CInt(1)

                ElseIf (.moneda = "2") Then
                    CboMonedaPago.DisplayMember = "EXTRANJERA"
                    CboMonedaPago.SelectedValue = CInt(2)

                End If


            End With

            With entidadSA.UbicarEntidadPorID(.idProveedor).First
                txtProveedor.Text = .nombreCompleto
                txtProveedor.ValueMember = .idEntidad
                txtRuc.Text = .nrodoc
                txtCuenta.Text = .cuentaAsiento
            End With

            If (.monedaDoc = "1") Then
                cboMoneda.DisplayMember = "NACIONAL"
                cboMoneda.SelectedValue = CInt(1)

            ElseIf (.monedaDoc = "2") Then
                cboMoneda.DisplayMember = "EXTRANJERA"
                cboMoneda.SelectedValue = CInt(2)

            End If

            'With tablaDetalleSA.GetUbicarTablaID("10", .tipoDoc)
            '    cboTipoDoc.DisplayMember = .descripcion
            '    cboTipoDoc.SelectedValue = .codigoDetalle
            'End With
            txtFechaComprobante.Value = .fechaDoc

            'txtContratacion.Text = .
        End With
        dgvCompra.Rows.Clear()
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(intIdDocumento)
            dgvCompra.Rows.Add(i.secuencia, "1", i.idItem, i.descripcionItem, i.entregable, i.fechaEntrega, Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia)


        Next
    End Sub




    Sub GrabarSolicitud()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim objDocOtros As New documentoOtrosDatos()
        Dim g As New ListViewGroup

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "00"
            .tipoDoc = TXTComprobante.ValueMember
            .fechaProceso = txtFechaComprobante.Value
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With
        With nDocumentoCompra
            .codigoLibro = "1"
            .serie = GConfiguracion.Serie
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .tipoDoc = "00"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .tipoRecaudo = Nothing
            .regimen = Nothing

            .monedaDoc = cboMoneda.SelectedValue
            .idProveedor = txtProveedor.ValueMember
            .nombreProveedor = txtProveedor.Text
            .tipoDoc = TXTComprobante.ValueMember
            .fechaContable = lblPerido.Text
            .nroRegimen = Nothing
            '.importeTotal = lblTotalAdquisiones.Text 'MARTIN
            '.importeUS = lblTotalUS.Text 'MARTIN
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.ORDEN_SERVICIO    'MARTIN
            .estadoPago = "P"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra


        With objDocOtros
            .CentroCostos = CInt("1")
            .moneda = CInt(CboMonedaPago.SelectedValue)
            .fechaInicio = fechainicio.Value
            .fechaFin = fechafin.Value
            .condicionPago = CboPago.SelectedValue
            .Vcto = txtVcto.Text
            .Modalidad = cboModalidad.SelectedValue
            .ctaDeposito = txtcto.Text
            .institucionFinanciera = txtFinaciera.Text
            .estado = "P"
            .objetoContratacion = txtContratacion.Text
            '.importeContratacion = txtImporteContratacion.Text
            .periodoValorizacion = txtPeriodoValorizacion.Text
            .penalidades = txtPenalidades.Text
            '.adelanto = txtAdelanto.Text
            '.etracciones = txtDetracciones.Text
            '.fondoGarantia = txtFondoGarantia.Text
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        '  ndocumento.documentocompra.documentoOtrosDatos = objDocOtros


        Dim S As Integer = 0
        For Each i As DataGridViewRow In dgvCompra.Rows
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.idItem = CDec(i.Cells(2).Value()) 'IDITEM
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            objDocumentoCompraDet.fechaEntrega = i.Cells(5).Value()
            objDocumentoCompraDet.entregable = i.Cells(4).Value()
            objDocumentoCompraDet.Action = i.Cells(6).Value()

            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing
            ListaDetalle.Add(objDocumentoCompraDet)
        Next
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'CompraSA.GrabarOrdenes(ndocumento)

    End Sub


#End Region

#Region "Variables DetalleCompra"
    Public Property nudBase4 As Decimal = 0
    Public Property nudBase1 As Decimal = 0
    Public Property nudBase2 As Decimal = 0
    Public Property nudBase3 As Decimal = 0

    Public Property nudMontoIgv1 As Decimal = 0
    Public Property nudMontoIgv2 As Decimal = 0
    Public Property nudMontoIgv3 As Decimal = 0

    Public Property nudBaseus4 As Decimal = 0
    Public Property nudBaseus1 As Decimal = 0
    Public Property nudBaseus2 As Decimal = 0
    Public Property nudBaseus3 As Decimal = 0

    Public Property nudMontoIgvus1 As Decimal = 0
    Public Property nudMontoIgvus2 As Decimal = 0
    Public Property nudMontoIgvus3 As Decimal = 0

    Public Property nudIsc1 As Decimal = 0
    Public Property nudIsc2 As Decimal = 0
    Public Property nudIsc3 As Decimal = 0
    Public Property nudIscus1 As Decimal = 0
    Public Property nudIscus2 As Decimal = 0
    Public Property nudIscus3 As Decimal = 0

    Public Property nudOtrosTributosus1 As Decimal = 0
    Public Property nudOtrosTributosus2 As Decimal = 0
    Public Property nudOtrosTributosus3 As Decimal = 0
    Public Property nudOtrosTributosus4 As Decimal = 0

    Public Property nudOtrosTributos1 As Decimal = 0
    Public Property nudOtrosTributos2 As Decimal = 0
    Public Property nudOtrosTributos3 As Decimal = 0
    Public Property nudOtrosTributos4 As Decimal = 0

    Public Property txtIdComprobanteCaja As Integer
    Public Property txtComprobanteCaja As String
    Public Property txtNumCaja As String
    Public Property txtIdEstablecimientoCaja As Integer
    Public Property txtEstablecimientoCaja As String
    Public Property txtIdCaja As Integer
    Public Property txtCaja As String
    Public Property txtCuentaEF As String

    '   Public Property GlosaCompra As String = Nothing
#End Region

    Public Property Flag() As String
    Dim UserControl1 As New ucConfiguracion
    Dim toolTip As Popup
    Public ManipulacionEstado As String
    Private CheckBoxClicked As Boolean = False
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public fecha As DateTime

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        SelecIDEstable = Nothing
        SelecNombreEstable = Nothing
        SelectIdAlmacen = Nothing
        SelectNombreAlmacen = Nothing
        IdAlmacenBack = Nothing

        GConfiguracion = New GConfiguracionModulo

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "OC", "ORDEN DE COMPRA", GEstableciento.IdEstablecimiento)
        ObtenerListaControlesLoad()
        CargarCMBGastos()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.dockingManager1.DockControl(Me.Panel2, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        'Me.dockingManager1.DockControl(Me.PanelServicios, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        'dockingManager1.DockControlInAutoHideMode(PanelServicios, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        '' Me.Panel2.BringToFront()
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        '  Me.dockingClientPanel1.SizeToFit = True
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        ' dockingManager1.SetDockVisibility ( panel)
        dockingManager1.SetDockLabel(Panel2, "Existencias")

        'INICIO PERIODO
        lblPerido.Text = PeriodoGeneral
        ControlsHide()
        txtFechaComprobante.Select()
    End Sub

#Region "Métodos"
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
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre
    '                    End With
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
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
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

    Sub CALCULO_TRIBUTOS()





    End Sub

    'Private Sub ListadoProductosPorCategoria(strCategoria As String)
    '    Dim itemSA As New detalleitemsSA
    '    lsvListadoItems.Items.Clear()
    '    Try
    '        For Each i In itemSA.ListaProductosClasificados(GEstableciento.IdEstablecimiento, strCategoria)
    '            Dim n As New ListViewItem(i.codigodetalle)
    '            n.SubItems.Add(i.descripcionItem)
    '            n.SubItems.Add(i.unidad1)
    '            n.SubItems.Add(i.tipoExistencia)
    '            n.SubItems.Add(String.Empty)
    '            n.SubItems.Add(i.cuenta)
    '            lsvListadoItems.Items.Add(n)
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub ListadoProductosPorCategoriaTipoExistencia(strCategoria As Integer, strTipoExistencia As String)
        'Dim itemSA As New detalleitemsSA
        'lsvListadoItems.Items.Clear()
        'Try
        '    For Each i In itemSA.GetUbicarDetalleItemTipoExistencia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strCategoria, strTipoExistencia)
        '        Dim n As New ListViewItem(i.codigodetalle)
        '        n.SubItems.Add(i.descripcionItem)
        '        n.SubItems.Add(i.unidad1)
        '        n.SubItems.Add(i.tipoExistencia)
        '        n.SubItems.Add(String.Empty)
        '        n.SubItems.Add(i.cuenta)
        '        lsvListadoItems.Items.Add(n)
        '    Next
        'Catch ex As Exception

        'End Try
    End Sub

    Public Sub ObtenerListaControlesLoad()
        'Dim personaSA As New PersonaSA
        'Dim tablaSA As New tablaDetalleSA
        'Dim categoriaSA As New itemSA

        'lsvProveedor.Items.Clear()
        'For Each i As Persona In personaSA.ObtenerPersona(Gempresas.IdEmpresaRuc)
        '    Dim n As New ListViewItem(i.idPersona)
        '    n.SubItems.Add(i.nombreCompleto)
        '    'n.SubItems.Add(i.cuentaAsiento)
        '    'n.SubItems.Add(i.nrodoc)
        '    lsvProveedor.Items.Add(n)
        'Next
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim categoriaSA As New itemSA

        lsvProveedor.Items.Clear()
        For Each i As entidad In entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim n As New ListViewItem(i.idEntidad)
            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.cuentaAsiento)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next


        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0

        cboModalidad.DisplayMember = "descripcion"
        cboModalidad.ValueMember = "codigoDetalle"
        cboModalidad.DataSource = tablaSA.GetListaTablaDetalle(1, "1")

        CboPago.DisplayMember = "descripcion"
        CboPago.ValueMember = "codigoDetalle"
        CboPago.DataSource = tablaSA.GetListaTablaDetalle(501, "1")

        CboMonedaPago.ValueMember = "id"
        CboMonedaPago.DisplayMember = "name"
        CboMonedaPago.DataSource = dt
        CboMonedaPago.SelectedIndex = 0

        'COMPROBANTE TIPO DOCUMENTOS
        'cboTipoDoc.DisplayMember = "descripcion"
        'cboTipoDoc.ValueMember = "codigoDetalle"
        'cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(10, "1")

        'TIPO DE EXISTENCIA
        'cboTipoExistencia.DisplayMember = "descripcion"
        'cboTipoExistencia.ValueMember = "codigoDetalle"
        'cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        'UNIDAD DE MEDIDA
        'CboUM.ValueMember = "codigoDetalle"
        'CboUM.DisplayMember = "descripcion"
        'CboUM.DataSource = tablaSA.GetListaTablaDetalle(6, "1")

        'lstCategoria.DisplayMember = "descripcion"
        'lstCategoria.ValueMember = "idItem"
        'lstCategoria.DataSource = categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento)

    End Sub
#End Region

#Region "CESTO SERVICIOS"
    Public Sub CargarGastoCuentaPAdreLIke()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Try
            'lsvServicios.Columns.Clear()
            'lsvServicios.Items.Clear()
            'lsvServicios.Columns.Add("Cuenta", 75)
            'lsvServicios.Columns.Add("Descripcion", 318)
            '  lsvServicios.Columns.Add("Cuenta Padre", 0)
            For Each i As cuentaplanContableEmpresa In cuentaSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, "18")
                Dim n As New ListViewItem(i.cuenta)
                n.SubItems.Add(i.descripcion)
                'lsvServicios.Items.Add(n)
            Next
        Catch ex As Exception
            lblEstado.Text = "Error al obtener Cuentas." & vbCrLf & ex.Message
        End Try
    End Sub

    'Public Sub CargarListaGasto()
    '    Dim cuentaSA As New mascaraGastosEmpresaSA
    '    Try

    '        '  lsvServicios.Columns.Add("Cuenta Padre", 0)
    '        For Each i As mascaraGastosEmpresa In cuentaSA.ObtenerMascaraGastos(Gempresas.IdEmpresaRuc, txtServicio.Text)
    '            Dim n As New ListViewItem(i.cuentaCompra)
    '            n.SubItems.Add(i.descripcionCompra)
    '            lsvServicios.Items.Add(n)
    '        Next
    '    Catch ex As Exception
    '        lblEstado.Text = ("Error al cargar datos. " & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    'Public Sub CargarCMBGastos()
    '    Dim planContableSA As New cuentaplanContableEmpresaSA
    '    Try
    '        cboCuentas.DataSource = Nothing
    '        cboCuentas.DisplayMember = "descripcion"
    '        cboCuentas.ValueMember = "cuenta"
    '        cboCuentas.DataSource = planContableSA.LoadCuentasGastos(Gempresas.IdEmpresaRuc)
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '    End Try

    'End Sub
#End Region

#Region "Métodos DGV"
    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvCompra.CurrentCell()

        If Celda.ColumnIndex = 7 Or Celda.ColumnIndex = 8 Then

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

    

    Private Sub MyMethodOnCheckBoxes()
        'DO WHAT EVER WHEN THE SELECTED CHECKBOX IS CHECKED
        If CheckBoxClicked Then
            'DO WHAT DO YOU WANT TO, WHEN CHECKBOX IS NOT CHECKED!!
            '  MsgBox(True)

            dgvCompra.Item(29, dgvCompra.CurrentRow.Index).Value = "S"

        ElseIf Not CheckBoxClicked Then

            dgvCompra.Item(29, dgvCompra.CurrentRow.Index).Value = "N"

        End If
    End Sub


    

    


#End Region

#Region "Manipulación Data"

    Function DocObligacion() As documento
        Dim documento As New documento
        Dim documentoObligacion As New documentoObligacionTributaria
        Dim documentoDetalle As New List(Of documentoObligacionDetalle)
        Dim objdocumentoDetalle As New documentoObligacionDetalle
        Dim docTributoSA As New DocumentoObligacionTributariaSA

        With documento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaProceso = fecha
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With documentoObligacion
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .codigoLibro = "8"
            .fechaDoc = fecha
            .periodo = lblPerido.Text


            .idEntidad = txtProveedor.ValueMember
            .tipoOperacion = "02"
            .idEntidadFinanciera = Nothing
            .tipoDesposito = Nothing

            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")




            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        documento.documentoObligacionTributaria = documentoObligacion

        objdocumentoDetalle = New documentoObligacionDetalle
        objdocumentoDetalle.idItem = Nothing

        objdocumentoDetalle.destino = "0"
        objdocumentoDetalle.unidadMedida = Nothing
        objdocumentoDetalle.cantidad = Nothing
        objdocumentoDetalle.precioUnitario = Nothing
        objdocumentoDetalle.precioUnitarioUS = Nothing
        objdocumentoDetalle.porcTributo = Nothing

        objdocumentoDetalle.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        objdocumentoDetalle.fechaActualizacion = DateTime.Now
        documentoDetalle.Add(objdocumentoDetalle)

        documento.documentoObligacionTributaria.documentoObligacionDetalle = documentoDetalle

        Return documento
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

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim estadoF As New EstadosFinancierosSA

        Dim inventarioBL As New inventarioMovimientoSA
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen

        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle
        Try
            'chObligacion.Visible = False
            With objDoc.UbicarDocumento(intIdDocumento)
                fecha = .fechaProceso
                txtFechaComprobante.Text = .fechaProceso
                'COMPROBANTE
                'With objTabla.GetUbicarTablaID(10, .tipoDoc)
                'cboTipoDoc.SelectedValue = .tipoDoc
                'cboTipoDoc.Text = .descripcion
                'End With
            End With

            DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            If Not IsNothing(DocumentoGuia) Then
                With DocumentoGuia

                End With
            End If

            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                lblIdDocumento.Text = .idDocumento
                'cboTipoDoc.SelectedValue = .tipoDoc

                'With objTabla.GetUbicarTablaID(10, .tipoDoc)
                '    txtComprobante.Text = .descripcion
                'End With


                lblPerido.Text = .fechaContable


                'PROVEEDOR
                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                'txtCuenta.Text = nEntidad.cuentaAsiento
                txtProveedor.ValueMember = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

                '_::::::::::::::::::        :::::::::::::::::::
                'txtTipoCambio.Value = .tcDolLoc

            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Rows.Clear()

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

                Select Case i.tipoExistencia
                    Case "GS"
                        dgvCompra.Rows.Add(i.secuencia,
                                    VALUEDES,
                                    i.idItem,
                                    i.descripcionItem,
                                    i.unidad2,
                                    i.monto2,
                                    i.unidad1,
                                    FormatNumber(i.monto1, 2),
                                    FormatNumber(i.precioUnitario, 2),
                                    FormatNumber(i.precioUnitarioUS, 2),
                                    FormatNumber(i.importe, 2),
                                    FormatNumber(i.importeUS, 2),
                                    FormatNumber(i.montokardex, 2),
                                    FormatNumber(i.montoIsc, 2),
                                    FormatNumber(i.montoIgv, 2),
                                    FormatNumber(i.otrosTributos, 2),
                                    FormatNumber(i.montokardexUS, 2),
                                    FormatNumber(i.montoIscUS, 2),
                                    FormatNumber(i.montoIgvUS, 2),
                                    FormatNumber(i.otrosTributosUS, 2),
                                    Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
                                    i.idItem,
                                    i.preEvento,
                                    Nothing, Nothing, Nothing,
                                    IIf(i.bonificacion = "S", "S", "N"), Nothing, i.bonificacion, i.almacenRef)
                    Case Else

                        dgvCompra.Rows.Add(i.secuencia,
                                    VALUEDES,
                                    i.idItem,
                                    i.descripcionItem,
                                    i.unidad2,
                                    i.monto2,
                                    i.unidad1,
                                    FormatNumber(i.monto1, 2),
                                    FormatNumber(i.precioUnitario, 2),
                                    FormatNumber(i.precioUnitarioUS, 2),
                                    FormatNumber(i.importe, 2),
                                    FormatNumber(i.importeUS, 2),
                                    FormatNumber(i.montokardex, 2),
                                    FormatNumber(i.montoIsc, 2),
                                    FormatNumber(i.montoIgv, 2),
                                    FormatNumber(i.otrosTributos, 2),
                                    FormatNumber(i.montokardexUS, 2),
                                    FormatNumber(i.montoIscUS, 2),
                                    FormatNumber(i.montoIgvUS, 2),
                                    FormatNumber(i.otrosTributosUS, 2),
                                    Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
                                    insumosSA.InvocarProductoID(i.idItem).cuenta,
                                    i.preEvento,
                                    Nothing, Nothing, Nothing,
                                    IIf(i.bonificacion = "S", "S", "N"), Nothing, i.bonificacion, i.almacenRef)
                End Select


            Next


            '    lblTotalItems.Text = "Nro. de items: " & dgvCompra.Rows.Count

            'TotalesCabeceras()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .descripcion = txtProveedor.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.ValueMember
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS

        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cCuenta As String, cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO
        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .destinoCompra
                End With
            Case "02", "03", "04", "05"
                With mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, cCuenta, strTipoExistencia)
                    nMovimiento.cuenta = .destinoCompra
                End With
        End Select


        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .destinoCompra2
                End With
            Case "02", "03", "04", "05"
                With mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, cCuenta, strTipoExistencia)
                    nMovimiento.cuenta = .destinoCompra2
                End With
        End Select


        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Public Function AsientoCabeceraCompra(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        'ASIENTO POR LA COMPRA
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = PeriodoGeneral
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.ValueMember
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.OrdenServicio
        'nAsiento.importeMN = CDec(lblTotalAdquisiones.Text)
        'nAsiento.importeME = CDec(lblTotalUS.Text)

        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function


   

    Public Function ASBOF(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.ValueMember
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.BONIFICACION
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function



    Sub UpdateOtros()
        Dim nRecursoSA As New DocumentoOtrosDatosSA
        Dim nRecurso As New documentoOtrosDatos
        For i = 0 To dgvCompra.Rows.Count - 1
            'nRecurso = New documentoOtrosDatos With {
            '.idDocumento = CInt(lblIdDocumento.Text),
            '.fechaInicio = fechainicio.Value,
            '.fechaFin = fechafin.Value,
            '.condicionPago = CboPago.SelectedValue,
            ' .CentroCostos = CInt("1"),
            '.Vcto = txtVcto.Text,
            '.Modalidad = cboModalidad.SelectedValue,
            '.ctaDeposito = txtcto.Text,
            '.institucionFinanciera = txtFinaciera.Text,
            '.estado = "P",
            '.moneda = CInt(CboMonedaPago.SelectedValue),
            '.objetoContratacion = txtContratacion.Text,
            ''.importeContratacion = txtImporteContratacion.Text,
            '.periodoValorizacion = txtPeriodoValorizacion.Text,
            '.penalidades = txtPenalidades.Text,
            ''.adelanto = txtAdelanto.Text,
            ''.etracciones = txtDetracciones.Text,
            ''.fondoGarantia = txtFondoGarantia.Text,
            '.usuarioActualizacion = "Jiuni",
            '.fechaActualizacion = DateTime.Now}

            If (nRecursoSA.UpdateOtros(nRecurso)) Then
                lblEstado.Text = " editado!"
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        Next


    End Sub

    'martin upodate doc

    Sub UpdateDoc()
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        For i = 0 To dgvCompra.Rows.Count - 1
            nRecurso = New documentocompra With {
            .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
            .idDocumento = CInt(lblIdDocumento.Text),
            .fechaDoc = txtFechaComprobante.Value,
            .tipoDoc = TXTComprobante.ValueMember,
            .idProveedor = txtProveedor.ValueMember,
            .monedaDoc = cboMoneda.SelectedValue}
            If (nRecursoSA.UpdateDoc(nRecurso)) Then
                UpdateOtros()
                lblEstado.Text = " editado!"
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        Next


    End Sub
    'martin update
    Sub UpdateCompra()
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompradetalle
        For i = 0 To dgvCompra.Rows.Count - 1
            Dim a As Integer
            If dgvCompra.Item(6, i).Value = Business.Entity.BaseBE.EntityAction.UPDATE Then
                a = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvCompra.Item(6, i).Value = Business.Entity.BaseBE.EntityAction.INSERT Then
                a = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvCompra.Item(6, i).Value = Business.Entity.BaseBE.EntityAction.DELETE Then
                a = Business.Entity.BaseBE.EntityAction.DELETE
            End If
            'Dim a As Integer
            nRecurso = New documentocompradetalle With {
            .usuarioModificacion = "jiuni",
            .fechaModificacion = DateTime.Now,
            .Action = a,
            .idDocumento = CInt(lblIdDocumento.Text),
            .idItem = dgvCompra.Item(2, i).Value.ToString,
            .descripcionItem = dgvCompra.Item(3, i).Value.ToString,
            .secuencia = dgvCompra.Item(0, i).Value.ToString,
            .entregable = dgvCompra.Item(4, i).Value.ToString,
            .fechaEntrega = dgvCompra.Item(5, i).Value}

            'If dgvCompra.Item(7, i).Value.ToString = 0 Then
            '    lblEstado.Text = "debe ingresar cantidades mayor a cero"
            '    Exit Sub
            'End If
            If (nRecursoSA.UpdateOrdenCompra(nRecurso, "tipo")) Then
                lblEstado.Text = " editado!"
                lblEstado.Image = My.Resources.ok4
                UpdateDoc()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        Next
    End Sub

    Enum Sys
        Inicio
        Proceso
    End Enum

    Sub InfoConfiguracion(n As Sys)
        If Not IsNothing(GConfiguracion) Then
            If Not IsNothing(GConfiguracion.NomModulo) Then
                UserControl1.lblCodigo.Text = "C1"
                UserControl1.lblModulo.Text = Me.Text
                UserControl1.lblConfiguracion.Text = IIf(GConfiguracion.TipoConfiguracion = "M", "MANUAL", "PROGRAMADA")
                UserControl1.lblComprobante.Text = GConfiguracion.NombreComprobante
                UserControl1.lblSerie.Text = GConfiguracion.Serie
                UserControl1.lblNumImpresiones.Text = IIf(IsNothing(GConfiguracion.ValorActual), 0, GConfiguracion.ValorActual)
                UserControl1.lblAlmacen.Text = GConfiguracion.NombreAlmacen
                UserControl1.lblCaja.Text = GConfiguracion.NomCaja
                ' position the tooltip with its stem towards the right end of the button
                If n = Sys.Inicio Then
                ElseIf n = Sys.Proceso Then
                    toolTip.Show(btnConfiguracion)
                End If
            End If
        End If
    End Sub

#End Region


    Private Sub frmCompraCreditoSinRecepcion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

   

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub tbnAlmacen_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnConfiguracion_Click(sender As System.Object, e As System.EventArgs) Handles btnConfiguracion.Click
        InfoConfiguracion(Sys.Proceso)
    End Sub

    Private Sub chObligacion_CheckStateChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp

    End Sub

    Private Sub btnVer_Click(sender As System.Object, e As System.EventArgs)
        dockingManager1.SetDockVisibility(Panel2, True)
        'dockingManager1.SetDockVisibility(PanelServicios, True)

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        If dgvCompra.Rows.Count > 0 Then
            If Not IsNothing(dgvCompra.CurrentRow) Then
                If dgvCompra.Item(6, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    dgvCompra.Rows.RemoveAt(dgvCompra.CurrentCell.RowIndex)
                ElseIf dgvCompra.Item(6, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
                    dgvCompra.Item(6, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvCompra.CurrentRow.Index
                    dgvCompra.CurrentCell = Nothing
                    Me.dgvCompra.Rows(pos).Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub rbRetencion_CheckChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub rbDetraccion_CheckChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub rbPercepcion_CheckChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub nudPorcentajeTributo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            CALCULO_TRIBUTOS()
        End If
    End Sub

    Private Sub nudPorcentajeTributo_ValueChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub dropDownBtn_Click_1(sender As System.Object, e As System.EventArgs)
        Me.popupControlContainer1.ParentControl = Me.txtProveedor
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs)
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs)
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub cancel_Click(sender As System.Object, e As System.EventArgs)
        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs)
        If dgvCompra.Rows.Count > 0 Then

        End If
    End Sub

    Private Sub cboTipoDoc_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub chFormato_CheckStateChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            cboMoneda.Select()
        End If
    End Sub

    Private Sub cboMoneda_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboMoneda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            dropDownBtn.Focus()
        End If
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True

        End If
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub txtSerieGuia_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub txtNumeroGuia_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    

    Private Sub dgvCompra_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)

    End Sub

    Private Sub dgvCompra_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvCompra_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub dgvCompra_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)

    End Sub

    Private Sub dgvCompra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)


    End Sub

    Private Sub dgvCompra_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Dim grid As DataGridView = TryCast(sender, DataGridView)

        If Not grid.RowHeadersVisible Then
            Return
        End If
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        While strRowNumber.Length < grid.RowCount.ToString().Length
            strRowNumber = Convert.ToString("0") & strRowNumber
        End While

        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, grid.Font)

        If grid.RowHeadersWidth < CInt(size.Width + 20) Then
            grid.RowHeadersWidth = CInt(size.Width + 20)
        End If

        Dim b As Brush = SystemBrushes.ControlText


        e.Graphics.DrawString(strRowNumber, grid.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs)
        If e.PopupCloseType = PopupCloseType.Done Then

        End If

        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then

        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ButtonCategoria_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoExistencia_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA

    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboCuentas_Click(sender As System.Object, e As System.EventArgs) Handles cboCuentas.Click

    End Sub

    Private Sub cboCuentas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCuentas.SelectedIndexChanged

    End Sub

    Private Sub lsvServicios_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click


        Me.Cursor = Cursors.WaitCursor
        Try
            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"
                lblEstado.Image = My.Resources.warning2
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"
                lblEstado.Image = My.Resources.ok4
            End If

            If Not IsNothing(GConfiguracion.NomModulo) Then
                Select Case GConfiguracion.TipoConfiguracion
                    Case "M"

                    Case "P"

                End Select
            End If
            If dgvCompra.Rows.Count > 0 Then
                If lblIdDocumento.Text = "00" Then
                    Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                    Me.lblEstado.Text = "Done!"

                    GrabarSolicitud()
                    Dispose()

                ElseIf lblIdDocumento.Text > 0 Then
                    Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    If Filas > 0 Then
                        UpdateCompra()
                        Dispose()
                    Else
                        Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                        Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                        'Timer1.Enabled = True
                        'TiempoEjecutar(5)
                    End If
                End If
            Else
                Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Ingrese items a la canasta de compra!"

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
            'Timer1.Enabled = True
            'TiempoEjecutar(5)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnConfiguracion_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnConfiguracion.MouseLeave
        'toolTip.Close()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        If dgvCompra.Rows.Count > 0 Then

        End If
    End Sub

    Private Sub Panel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub dgvCompra_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs)


    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lblTotalBaseUS_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ButtonAdv2_Click_1(sender As System.Object, e As System.EventArgs)
        'Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv1_Click_1(sender As System.Object, e As System.EventArgs)
        'Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub PopupControlContainer2_BeforeCloseUp(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        'Me.PopupControlContainer2.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer2_CloseUp1(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs)
        If e.PopupCloseType = PopupCloseType.Done Then
            
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            'Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub ButtonCategoria_Click_1(sender As System.Object, e As System.EventArgs)
       
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick1(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        
    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoExistencia_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged1(sender As Object, e As System.EventArgs)
        
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton4_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lstCategoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub dgvCompra_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

    End Sub

   


    Public Sub CargarCMBGastos()
        Dim planContableSA As New cuentaplanContableEmpresaSA
        Try

        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

   

    Private Sub lsvServicios_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TabPage2_Click(sender As System.Object, e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub FrmOrdenServicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblPerido.Text = PeriodoGeneral
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        toolTip = New Popup(UserControl1)
        toolTip.AutoClose = False
        toolTip.FocusOnOpen = False
        toolTip.ShowingAnimation = PopupAnimations.Blend
        InfoConfiguracion(Sys.Inicio)
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            cboMoneda.SelectedValue = 1
        ElseIf IsNothing(ManipulacionEstado) Then
            cboMoneda.SelectedValue = 1
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
            txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        Else
            If DocumentoCompraSA.TieneItemsEnAV(CInt(lblIdDocumento.Text)) = True Then
            Else
            End If
        End If
        If lblIdDocumento.Text > 0 Then
            UbicarDocumentos(lblIdDocumento.Text)
        End If
    End Sub

    Private Sub btnAgregar_Click_1(sender As System.Object, e As System.EventArgs)
        'If lsvServicios.SelectedItems.Count > 0 Then
        'Dim n As New GInsumo()
        'Dim objInsumo As GInsumo = GInsumo.InstanceSingle
        'objInsumo.Clear()
        'objInsumo.origenProducto = "1"
        'objInsumo.IdActividadRecurso = Nothing ' lsvListadoItems.SelectedItems(0).SubItems(7).Text
        'objInsumo.IdInsumo = lsvServicios.SelectedItems(0).SubItems(0).Text
        'objInsumo.descripcionItem = lsvServicios.SelectedItems(0).SubItems(1).Text
        'objInsumo.tipoExistencia = TipoRecurso.SERVICIO
        'objInsumo.unidad1 = 0.0
        'objInsumo.Cantidad = 0.0
        'objInsumo.PU = 0.0
        'objInsumo.Total = 0.0
        'objInsumo.cuenta = lsvServicios.SelectedItems(0).SubItems(0).Text

        dgvCompra.Rows.Add(0, "1", "GG", txtDescripcion.Text, txtOrdenEntregable.Text,
                              fecha1.Value, Business.Entity.BaseBE.EntityAction.INSERT)
        'End If
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        If dgvCompra.Rows.Count > 0 Then

            If Not IsNothing(dgvCompra.CurrentRow) Then

                If dgvCompra.Item(6, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    dgvCompra.Rows.RemoveAt(dgvCompra.CurrentCell.RowIndex)
                ElseIf dgvCompra.Item(6, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
                    dgvCompra.Item(6, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvCompra.CurrentRow.Index

                    dgvCompra.CurrentCell = Nothing
                    Me.dgvCompra.Rows(pos).Visible = False
                End If
                
            End If
        End If
    End Sub

    Private Sub btnVer_Click_1(sender As System.Object, e As System.EventArgs) Handles btnVer.Click
        dockingManager1.SetDockVisibility(Panel2, True)
        'dockingManager1.SetDockVisibility(PanelServicios, True)
    End Sub

    Private Sub btnAgregar_Click_2(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        dgvCompra.Rows.Add(0, "GG", "0", txtDescripcion.Text,
                                     txtOrdenEntregable.Text,
                                        fecha1.Value,
                                      Business.Entity.BaseBE.EntityAction.INSERT)
    End Sub

    Private Sub dropDownBtn_Click(sender As System.Object, e As System.EventArgs) Handles dropDownBtn.Click
        Me.popupControlContainer1.ParentControl = Me.txtProveedor
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub OK_Click_1(sender As System.Object, e As System.EventArgs) Handles OK.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub popupControlContainer1_BeforePopup_1(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp_1(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                'txtTelefono.Text = lsvProveedor.SelectedItems(0).SubItems(4).Text
                'txtCorreo.Text = lsvProveedor.SelectedItems(0).SubItems(5).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

End Class
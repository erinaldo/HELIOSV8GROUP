Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class frmModalTransferenciaCaja
    Inherits frmMaster
    Public fecha As DateTime
    Public ManipulacionEstado As String
    Dim sumatoria As Decimal
    Public Property ListaAsientos As New List(Of asiento)
    Public Property frmSeleccionCuentaFinanciera As frmSeleccionCuentaFinanciera
    Public idDocumento As Integer
    Public Property tipoPersona As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        '' Add any initialization after the InitializeComponent() call.
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
        ObtenerTablaGenerales()
        txtAnioCompra.Text = DateTime.Now.Year
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "TF", Me.Text, GEstableciento.IdEstablecimiento)
        txtTipoCambio.Value = TmpTipoCambio
    End Sub
#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "DatosEntidades"
    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA
        cbotipoOperacion.ValueMember = "codigoDetalle"
        cbotipoOperacion.DisplayMember = "descripcion"
        cbotipoOperacion.DataSource = tablaSA.GetListaTablaDetalleMotivo(12, "1", "9911")
    End Sub

#End Region

#Region "Manipulación Data"


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
    '                    End With
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
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

    Public Function Glosa() As String
        Return "Por transferencia de cajas con fecha " & fecha
    End Function



    Sub Calculo()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value
        If tcambio > 0 Then
            Imn = txtFondoMN.Value
            txtFondoME.Value = Math.Round(Imn / tcambio, 2)
        End If
    End Sub

    Public Sub AsientoContableTransferencia()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento

        asientoBL.periodo = GetPeriodo(txtPeriodo.Value, True)
        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
        asientoBL.idEntidad = txtCliente2.Tag
        asientoBL.nombreEntidad = txtCliente2.Text
        asientoBL.tipoEntidad = tipoPersona
        asientoBL.NroDocEntidad = txtRuc2.Text
        asientoBL.fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        asientoBL.codigoLibro = "1"
        asientoBL.tipo = "D"
        asientoBL.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        asientoBL.importeMN = CDec(txtFondoMN.Value)
        asientoBL.importeME = CDec(txtFondoME.Value)
        asientoBL.glosa = Glosa()


        nMovimiento = New movimiento
        nMovimiento.cuenta = txtCF_cuentaContable.Text
        'nMovimiento.descripcion = txtCajaOrigen.Text
        nMovimiento.descripcion = txtCF_name.Text
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(txtFondoMN.Value)
        nMovimiento.montoUSD = CDec(txtFondoME.Value)
        nMovimiento.usuarioActualizacion = txtCF_name.Tag
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = txtCF_cuentaContable2.Text
        'nMovimiento.descripcion = txtCajaDestino.Text
        nMovimiento.descripcion = txtCF_name2.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(txtFondoMN.Value)
        nMovimiento.montoUSD = CDec(txtFondoME.Value)
        nMovimiento.usuarioActualizacion = txtCF_name2.tag
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)
        ListaAsientos.Add(asientoBL)
    End Sub

    Public Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim alEFSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim establecimientoSA As New establecimientoSA
        Try

            Dim docCaja = documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)
            If docCaja IsNot Nothing Then
                Select Case docCaja.tipoMovimiento
                    'lblMovimiento.Text = "TRANSFERENCIA ENTRE CAJAS"
                End Select

                idDocumento = docCaja.idDocumento
                txtComprobante.Text = "COMPROBANTE DE CAJA"
                txtPeriodo.Value = GetPeriodoConvertirToDate(docCaja.periodo)
                Dim mesOperacion = String.Format("{0:00}", docCaja.fechaProceso.Value.Month)
                cboMesCompra.SelectedValue = mesOperacion 'String.Format("0:00", .fechaProceso.Value.Month)
                TxtDia.Text = docCaja.fechaProceso.Value.Day
                txtAnioCompra.Text = docCaja.fechaProceso.Value.Year
                Dim codigoDoc = docCaja.formapago
                cbotipoOperacion.Text = "TRANSFERENCIA ENTRE CAJAS"
                cbotipoOperacion.Tag = 9911
                SaldoEFMN.Text = docCaja.montoSoles
                SaldoEFME.Text = docCaja.montoUsd
                With alEFSA.GetUbicar_estadosFinancierosPorID(docCaja.entidadFinancieraDestino)
                    Select Case .tipo
                        Case CuentaFinanciera.Banco
                            txtCF_tipo.Text = "CUENTAS EN BANCO"
                        Case CuentaFinanciera.Efectivo
                            txtCF_tipo.Text = "CUENTAS EN EFECTIVO"
                        Case CuentaFinanciera.Tarjeta_Credito
                            txtCF_tipo.Text = "TARJETA DE CREDITO"
                    End Select

                    Select Case .codigo
                        Case 1
                            txtCF_moneda.Tag = 1
                            txtCF_moneda.Text = "NACIONAL"
                        Case 2
                            txtCF_moneda.Tag = 2
                            txtCF_moneda.Text = "EXTRANJERA"
                    End Select

                    txtCF_name.Tag = .idestado
                    txtCF_name.Text = .descripcion
                    txtCF_cuentaContable.Text = .cuenta
                End With

                With alEFSA.GetUbicar_estadosFinancierosPorID(docCaja.entidadFinanciera)
                    Select Case .tipo
                        Case CuentaFinanciera.Banco
                            txtCF_tipo2.Text = "CUENTAS EN BANCO"
                        Case CuentaFinanciera.Efectivo
                            txtCF_tipo2.Text = "CUENTAS EN EFECTIVO"
                        Case CuentaFinanciera.Tarjeta_Credito
                            txtCF_tipo2.Text = "TARJETA DE CREDITO"
                    End Select

                    Select Case .codigo
                        Case 1
                            txtCF_moneda2.Tag = 1
                            txtCF_moneda2.Text = "NACIONAL"
                        Case 2
                            txtCF_moneda2.Tag = 2
                            txtCF_moneda2.Text = "EXTRANJERA"
                    End Select

                    txtCF_name2.Tag = .idestado
                    txtCF_name2.Text = .descripcion
                    txtCF_cuentaContable2.Text = .cuenta
                End With

            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub GrabarTransferenciaCaja()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim idNumeracion As Integer
        Dim idCaja As Integer

        Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
            Case 3, 4
                idCaja = GFichaUsuarios.IdCajaUsuario
            Case Else
                idCaja = 0
        End Select

        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9908"
            .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .nroDoc = idNumeracion ' txtNumeroComp.Text
            .idOrden = Nothing
            .moneda = txtCF_moneda.Tag
            .idEntidad = txtCliente2.Tag
            .entidad = txtCliente2.Text
            .tipoEntidad = tipoPersona
            .nrodocEntidad = txtRuc2.Text
            .tipoOperacion = StatusTipoOperacion.TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            .periodo = GetPeriodo(txtPeriodo.Value, True)
            .movimientoCaja = MovimientoCaja.TrasferenciaEntreCajas
            .codigoLibro = "1"
            .tipoOperacion = StatusTipoOperacion.TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO
            .tipoCambio = TmpTipoCambio
            '   .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = MovimientoCaja.SalidaDinero
            .TipoDocumentoPago = "9908"
            .codigoProveedor = txtCliente2.Tag 'txtPersona.ValueMember
            .idPersonal = txtCliente2.Tag
            .tipoPersona = tipoPersona
            .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .fechaCobro = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .tipoDocPago = "9908"
            .numeroDoc = idNumeracion
            .moneda = txtCF_moneda.Tag
            '.entidadFinanciera = txtCajaOrigen.ValueMember
            .entidadFinanciera = txtCF_name.Tag
            ' .entidadFinancieraDestino = txtCajaDestino.ValueMember
            .entidadFinancieraDestino = txtCF_name2.Tag
            .numeroOperacion = Nothing

            Select Case txtCF_moneda.Tag
                Case 1
                    .montoSoles = txtFondoMN.Value
                    .montoUsd = CDec(txtFondoMN.Value / TmpTipoCambio).ToString("N2")
                Case 2
                    .montoSoles = sumatoria
                    .montoUsd = txtFondoME.Value
            End Select


            If (txtDescripcion.Text.Length > 0) Then
                .glosa = txtDescripcion.Text
            Else
                .glosa = Glosa()
            End If
            .idCajaUsuario = idCaja
            .numeroOperacion = Nothing
            .ctaCorrienteDeposito = Nothing
            'OJO FALTA
            '.bancoEntidad = cboEntidades.SelectedValue
            '.ctaIntebancaria = txtCuentaCorriente.Text
            .entregado = "SI"
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = DateTime.Now
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.fecha = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = "Por transferencia de dinero"
        ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
        ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
        ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
        ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
        ndocumentoCajaDetalle.entregado = "SI"
        'ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.moneda = txtCF_moneda.Tag
        ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
        ndocumentoCajaDetalle.idCajaPadre = 0
        ndocumentoCajaDetalle.idCajaUsuario = idCaja
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        AsientoContableTransferencia()
        ndocumento.asiento = ListaAsientos

        documentoCajaSA.SaveGroupCajaOtrosMovimientosME(ndocumento)
        lblEstado.Text = "Caja registrada correctamente!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub

    Public Sub GrabarTransferenciaCajaReversion()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim idNumeracion As Integer
        Dim idCaja As Integer
        Dim tipoEntidad As String = Nothing
        Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
            Case 3, 4
                idCaja = GFichaUsuarios.IdCajaUsuario
            Case Else
                idCaja = 0
        End Select

        Select Case txtCF_tipo.Text
            Case "CUENTA EN EFECTIVO"
                tipoEntidad = "EF"
            Case "TARJETA DE CREDITO"
                tipoEntidad = "BC"
            Case "TARJETA DE CREDITO"
                tipoEntidad = "TC"
        End Select

        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9908"
            .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .nroDoc = idNumeracion ' txtNumeroComp.Text
            .idOrden = Nothing
            .moneda = txtCF_moneda.Tag
            .idEntidad = txtCF_name.Tag
            .entidad = txtCF_name.Text
            .tipoEntidad = tipoEntidad
            .nrodocEntidad = usuario.CustomUsuario.NroDocumento
            .tipoOperacion = StatusTipoOperacion.REVERSIONES
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            .periodo = GetPeriodo(txtPeriodo.Value, True)
            .movimientoCaja = "RV"
            .codigoLibro = "1"
            .tipoOperacion = StatusTipoOperacion.REVERSIONES
            .tipoCambio = TmpTipoCambio
            '   .idDocumento = lblIdDocumento.Text
            .periodo = txtPeriodo.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = MovimientoCaja.SalidaDinero
            .TipoDocumentoPago = "9908"
            .codigoProveedor = Nothing 'txtPersona.ValueMember
            .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .fechaCobro = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .tipoDocPago = "9908"
            .numeroDoc = idNumeracion
            .moneda = txtCF_moneda.Tag
            '.entidadFinanciera = txtCajaOrigen.ValueMember
            .entidadFinanciera = txtCF_name.Tag
            ' .entidadFinancieraDestino = txtCajaDestino.ValueMember
            .entidadFinancieraDestino = txtCF_name2.Tag
            .numeroOperacion = Nothing

            Select Case txtCF_moneda.Tag
                Case 1
                    .montoSoles = txtFondoMN.Value
                    .montoUsd = CDec(txtFondoMN.Value / TmpTipoCambio).ToString("N2")
                Case 2
                    .montoSoles = sumatoria
                    .montoUsd = txtFondoME.Value
            End Select


            If (txtDescripcion.Text.Length > 0) Then
                .glosa = txtDescripcion.Text
            Else
                .glosa = Glosa()
            End If
            .idCajaUsuario = idCaja
            .numeroOperacion = Nothing
            .ctaCorrienteDeposito = Nothing
            'OJO FALTA
            '.bancoEntidad = cboEntidades.SelectedValue
            '.ctaIntebancaria = txtCuentaCorriente.Text
            .entregado = "SI"
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = DateTime.Now
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.fecha = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = "Por transferencia de dinero"
        ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
        ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
        ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
        ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
        ndocumentoCajaDetalle.entregado = "SI"
        'ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.moneda = txtCF_moneda.Tag
        ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
        ndocumentoCajaDetalle.idCajaPadre = idDocumento
        ndocumentoCajaDetalle.idCajaUsuario = idCaja
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        AsientoContableTransferencia()
        ndocumento.asiento = ListaAsientos

        documentoCajaSA.SaveGroupCajaOtrosMovimientosME(ndocumento)
        lblEstado.Text = "Caja registrada correctamente!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub
#End Region
#Region "Métodos"
    'Private Sub ObtenerCuentasFinancierasPorMoneda(strIdMoneda As String)
    '    Dim cFinancieraSA As New EstadosFinancierosSA
    '    gridGroupingControl1.DataSource = cFinancieraSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, strIdMoneda)
    '    gridGroupingControl1.TableDescriptor.GroupedColumns.Add("tipo")
    '    gridGroupingControl1.TableDescriptor.Relations.Clear()
    '    gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '    gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '    gridGroupingControl1.Appearance.AnyRecordFieldCell.Enabled = False
    '    gridGroupingControl1.GroupDropPanel.Visible = False
    'End Sub

    'Public Sub CargarListas()
    '    Dim tablaSA As New tablaDetalleSA
    '    cboTipoDoc.DisplayMember = "descripcion"
    '    cboTipoDoc.ValueMember = "codigoDetalle"
    '    cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(1, "1")

    '    cboMoneda.DisplayMember = "descripcion"
    '    cboMoneda.ValueMember = "codigoDetalle"
    '    cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")


    'End Sub
#End Region

    Private Sub frmTransferenciaCaja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    'Private Sub txtFondoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoMN.ValueChanged
    '    If (txtFondoMN.Value <= lblDeudaPendientemn.Value) Then
    '        CargarEntidadesXMN()
    '    Else
    '        txtFondoMN.Value = 0.0
    '        txtFondoMNDestino.Value = 0.0
    '        lblEstado.Text = "Debe ingresar un importe permitido!"
    '        PanelError.Visible = True
    '        Timer1.Enabled = True
    '        TiempoEjecutar(10)
    '    End If

    'End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs)
        If (txtCF_name2.tag > 0) Then
            Calculo()
        Else
            lblEstado.Text = "Debe ingresar una cuenta destino!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Exit Sub
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _cuenta As String

        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal cuenta As String)
            _name = name
            _id = id
            _cuenta = cuenta
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

        Public Property Cuenta() As String
            Get
                Return _cuenta
            End Get
            Set(ByVal value As String)
                _cuenta = value
            End Set
        End Property

    End Class


    Private Sub cboTipoOrigen_SelectedValueChanged(sender As Object, e As EventArgs)
        txtFondoMN.Value = 0
        txtFondoME.Value = 0
      
        txtDescripcion.Clear()
        txtDescripcion.Text = ""

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TxtDia.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar la fecha de registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtDia.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        frmSeleccionCuentaFinanciera = New frmSeleccionCuentaFinanciera
        Dim fechaActual As DateTime = Format(Now, txtAnioCompra.Text & "-" & cboMesCompra.SelectedValue & "-" & TxtDia.Text)
        'frmSeleccionCuentaFinanciera.txtPeriodo.Value = txtPeriodo.Value
        frmSeleccionCuentaFinanciera.txtPeriodo.Value = fechaActual
        frmSeleccionCuentaFinanciera.GetCuentasFinancieras("CUENTAS EN EFECTIVO")
        frmSeleccionCuentaFinanciera.StartPosition = FormStartPosition.CenterParent
        frmSeleccionCuentaFinanciera.ShowDialog()
        If frmSeleccionCuentaFinanciera.Tag IsNot Nothing Then
            txtFondoMN.Value = 0
            txtFondoME.Value = 0
            'txtTipoCambio.Value = 0
            SaldoEFME.DoubleValue = 0
            SaldoEFMN.DoubleValue = 0

            Dim c = CType(frmSeleccionCuentaFinanciera.Tag, estadosFinancieros)
            Select Case c.tipo
                Case "EF"
                    txtCF_tipo.Tag = c.tipo
                    txtCF_tipo.Text = "CUENTA EN EFECTIVO"
                Case "BC"
                    txtCF_tipo.Tag = c.tipo
                    txtCF_tipo.Text = "CUENTAS EN BANCO"
                Case "TC"
                    txtCF_tipo.Tag = c.tipo
                    txtCF_tipo.Text = "TARJETA DE CREDITO"
            End Select
            txtCF_name.Text = c.descripcion
            txtCF_name.Tag = c.idestado

            Select Case c.codigo
                Case 1
                    txtCF_moneda.Tag = 1
                    txtCF_moneda.Text = "NACIONAL"
                Case 2
                    txtCF_moneda.Tag = 2
                    txtCF_moneda.Text = "EXTRANJERA"
            End Select

            txtCF_cuentaContable.Text = c.cuenta
            SaldoEFMN.DoubleValue = c.importeBalanceMN.GetValueOrDefault
            SaldoEFME.DoubleValue = 0
            'cargarCtasFinan()
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If TxtDia.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar la fecha de registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtDia.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        frmSeleccionCuentaFinanciera = New frmSeleccionCuentaFinanciera
        Dim fechaActual As DateTime = Format(Now, txtAnioCompra.Text & "-" & cboMesCompra.SelectedValue & "-" & TxtDia.Text)
        'frmSeleccionCuentaFinanciera.txtPeriodo.Value = txtPeriodo.Value
        frmSeleccionCuentaFinanciera.txtPeriodo.Value = fechaActual
        frmSeleccionCuentaFinanciera.GetCuentasFinancieras("CUENTAS EN EFECTIVO")
        frmSeleccionCuentaFinanciera.StartPosition = FormStartPosition.CenterParent
        frmSeleccionCuentaFinanciera.ShowDialog()
        If frmSeleccionCuentaFinanciera.Tag IsNot Nothing Then
            txtFondoMN.Value = 0
            txtFondoME.Value = 0
            'txtTipoCambio.Value = 0
            SaldoEFME2.DoubleValue = 0
            SaldoEFMN2.DoubleValue = 0

            Dim c = CType(frmSeleccionCuentaFinanciera.Tag, estadosFinancieros)
            Select Case c.tipo
                Case "EF"
                    txtCF_tipo2.Tag = c.tipo
                    txtCF_tipo2.Text = "CUENTA EN EFECTIVO"
                Case "BC"
                    txtCF_tipo2.Tag = c.tipo
                    txtCF_tipo2.Text = "CUENTAS EN BANCO"
                Case "TC"
                    txtCF_tipo2.Tag = c.tipo
                    txtCF_tipo2.Text = "TARJETA DE CREDITO"
            End Select
            txtCF_name2.Text = c.descripcion
            txtCF_name2.Tag = c.idestado

            Select Case c.codigo
                Case 1
                    txtCF_moneda2.Tag = 1
                    txtCF_moneda2.Text = "NACIONAL"
                Case 2
                    txtCF_moneda2.Tag = 2
                    txtCF_moneda2.Text = "EXTRANJERA"
            End Select

            txtCF_cuentaContable2.Text = c.cuenta
            SaldoEFMN2.DoubleValue = c.importeBalanceMN.GetValueOrDefault
            SaldoEFME2.DoubleValue = 0
            'cargarCtasFinan()
        End If
    End Sub

    Private Sub txtFondoMN_Click(sender As Object, e As EventArgs) Handles txtFondoMN.Click
        txtFondoMN.Select(0, txtFondoMN.Text.Length)
    End Sub

    Private Sub txtFondoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoMN.ValueChanged
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then

            Select Case txtCF_moneda.Text
                Case "NACIONAL"
                    txtFondoMN.Select(0, txtFondoMN.Text.Length)
                    Calculo()
                    Select Case lblMovimiento.Tag
                        Case "TEC"
                            If (txtFondoMN.Value <= SaldoEFMN.DoubleValue) Then
                                txtFondoMN.Select(0, txtFondoMN.Text.Length)
                            Else
                                lblEstado.Text = "Debe ingresar un importe menor o igual!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                txtFondoMN.Value = 0.0
                                txtFondoMN.Select(0, txtFondoMN.Text.Length)
                            End If

                    End Select
            End Select
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Try
            If TxtDia.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar la fecha de registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtDia.Select()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            Select Case ManipulacionEstado
                Case ENTITY_ACTIONS.INSERT
                    GrabarTransferenciaCaja()
                Case ENTITY_ACTIONS.UPDATE
                    GrabarTransferenciaCajaReversion()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        dispose
    End Sub

    Private Sub chProv_Click(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        tipoPersona = "PR"
    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        tipoPersona = "CL"
    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chCli.Checked = False
        chTrab.Checked = True
        tipoPersona = "TR"
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If (chProv.Checked = True) Then
            Cursor = Cursors.WaitCursor
            Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.PROVEEDOR)
            f.CaptionLabels(0).Text = "Proveedor"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = DirectCast(f.Tag, entidad)
                'Dim c = CType(f.Tag, entidad)
                txtCliente2.Text = c.nombreCompleto
                txtCliente2.Tag = c.idEntidad
                txtRuc2.Text = c.nrodoc
                txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If
            Cursor = Cursors.Default
        ElseIf (chCli.Checked = True) Then
            Cursor = Cursors.WaitCursor
            Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
            f.CaptionLabels(0).Text = "Cliente"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = DirectCast(f.Tag, entidad)
                'Dim c = CType(f.Tag, entidad)
                txtCliente2.Text = c.nombreCompleto
                txtCliente2.Tag = c.idEntidad
                txtRuc2.Text = c.nrodoc
                txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If
            Cursor = Cursors.Default
        ElseIf (chTrab.Checked = True) Then
            Cursor = Cursors.WaitCursor
            Dim f As New frmTrabajadorBusqueda()
            f.CaptionLabels(0).Text = "Trabajador"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = DirectCast(f.Tag, Planilla.Business.Entity.Personal)
                'Dim c = CType(f.Tag, entidad)
                txtCliente2.Text = c.FullName
                txtCliente2.Tag = c.IDPersonal
                txtRuc2.Text = c.Numerodocumento
                txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If txtAnioCompra.Text.Trim.Length > 0 Then
            If Not IsNothing(cboMesCompra.SelectedValue) Then
                txtPeriodo.Value = GetPeriodoConvertirToDate(cboMesCompra.SelectedValue & "/" & txtAnioCompra.Text)
                If TxtDia.Text.Trim.Length > 0 Then
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), txtAnioCompra.Text)
                Else
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), txtAnioCompra.Text)
                    TxtDia.Clear()
                End If
                TxtDia_TextChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then
            txtCF_tipo.Clear()
            txtCF_name.Clear()
            txtCF_moneda.Clear()
            txtCF_cuentaContable.Clear()
            SaldoEFMN.DoubleValue = 0
            SaldoEFME.DoubleValue = 0

            txtCF_tipo2.Clear()
            txtCF_name2.Clear()
            txtCF_moneda2.Clear()
            txtCF_cuentaContable2.Clear()
            SaldoEFMN2.DoubleValue = 0
            SaldoEFME2.DoubleValue = 0
        End If
    End Sub

    Private Sub cboMesCompra_Click(sender As Object, e As EventArgs) Handles cboMesCompra.Click

    End Sub
End Class
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmEntradaSalidaCaja
    Inherits frmMaster

#Region "Attributes"
    Dim Alert As Alert
    Public Property ListaMovimientos As New List(Of movimiento)
    Public Property frmSeleccionCuentaFinanciera As frmSeleccionCuentaFinanciera
    Public Property tipoPersona As String
    Public Property nroDocumento As String
    Public Property ListaAsientos As New List(Of asiento)
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property ManipulacionEstado() As String
    Private comboTable As DataTable
    Private comboTableCuentas As DataTable
    Public Property sumaMN() As Decimal
    Public Property sumaME() As Decimal

    Public ListaTipoOperacion As List(Of tabladetalle)
    Public ListaCtaBancaria As List(Of tabladetalle)
    '  Public ListaEntidad As List(Of tabladetalle)
    Public Property strTipo As String

    Dim lblIdDocumento As Integer

#End Region

#Region "Constructors"
    Public Sub New(Tipo As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "OES", Me.Text, GEstableciento.IdEstablecimiento)

        strTipo = Tipo

        bgwCombos.RunWorkerAsync()
    End Sub
#End Region

#Region "Métodos"

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

    Public Sub GetCombos()
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA

        ListaTipoOperacion = New List(Of tabladetalle)
        ListaCtaBancaria = New List(Of tabladetalle)
        '  ListaEntidad = New List(Of tabladetalle)

        ListaTipoOperacion = tablaDetalleSA.GetListaTablaDetalleMotivo(12, "1", strTipo)
        ListaCtaBancaria = tablaDetalleSA.GetListaTablaDetalle(1, "1")
        '    ListaEntidad = tablaDetalleSA.GetListaTablaDetalle(3, "1")

    End Sub

    Public Sub Loadcontroles()


        'cboEntidad.ValueMember = "codigoDetalle"
        'cboEntidad.DisplayMember = "descripcion"
        'cboEntidad.DataSource = ListaEntidad

        cbotipoOperacion.ValueMember = "codigoDetalle"
        cbotipoOperacion.DisplayMember = "descripcion"
        cbotipoOperacion.DataSource = ListaTipoOperacion

        cboTipoDocumento.DataSource = ListaCtaBancaria
        cboTipoDocumento.DisplayMember = "descripcion"
        cboTipoDocumento.ValueMember = "codigoDetalle"

    End Sub

    Private Sub cargarCtasFinan()
        If txtCF_tipo.Tag = "EF" Then
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")
            ListaDocPago(lista)
            cboTipoDocumento.SelectedValue = "001"
        ElseIf txtCF_tipo.Tag = "BC" Then
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("003")
            lista.Add("007")
            lista.Add("111")
            ListaDocPago(lista)
            cboTipoDocumento.SelectedValue = "001"
        ElseIf txtCF_tipo.Tag = "TC" Then
            Dim lista As New List(Of String)
            lista.Add("001")
            ListaDocPago(lista)
            cboTipoDocumento.SelectedValue = "001"
        End If
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

    Public Function GetTableAsientos() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Return dt

    End Function


    Public Sub GetTableAlmacen2()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        comboTableh = New DataTable("Cuentas")
        comboTableh.Columns.Add("idCuenta")
        comboTableh.Columns.Add("descripcionCuenta")

        For Each i In cuentaSA.ObtenerCuentasPorEmpresaEscalableV2(Gempresas.IdEmpresaRuc)
            comboTableh.Rows.Add(New Object() {i.cuenta, i.descripcion})
        Next

    End Sub

    Function GetMaxIDMovimiento() As Integer
        If ListaMovimientos.Count > 0 Then
            Return ListaMovimientos.Max(Function(o) o.idmovimiento)
        Else
            Return 0
        End If
    End Function

    Sub RegsitarMovimiento(nAsiento As asiento)
        Dim n As New movimiento
        n.cuenta = "10"
        n.idAsiento = nAsiento.idAsiento
        n.idmovimiento = GetMaxIDMovimiento() + 1
        n.tipo = "D"
        n.Cant = 1
        n.PUmn = 0
        n.PUme = 0
        n.monto = 0
        n.montoUSD = 0
        ListaMovimientos.Add(n)
    End Sub

    Sub RegistrarAsientos()
        Dim nAsiento As New asiento

        If ListaAsientonTransito.Count > 0 Then
            nAsiento.idAsiento = ListaAsientonTransito.Count + 1
        Else
            nAsiento.idAsiento = 1
        End If
        nAsiento.Descripcion = "Asiento Nro. " & ListaAsientonTransito.Count + 1
        ListaAsientonTransito.Add(nAsiento)


    End Sub


    Sub updateMovimiento(r As Record)

        Try
            Dim consulta = (From n In ListaMovimientos
                            Where n.idmovimiento = r.GetValue("id")).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.cuenta = r.GetValue("cuenta")
                Dim md = r.GetValue("Modulo").ToString
                If md.Trim.Length > 0 Then
                    consulta.nombreEntidad = r.GetValue("Modulo")
                Else
                    consulta.nombreEntidad = String.Empty
                End If

                Dim des = r.GetValue("descripcion").ToString
                If des.Trim.Length > 0 Then
                    consulta.descripcion = r.GetValue("descripcion")
                Else
                    consulta.descripcion = String.Empty
                End If
                consulta.tipo = r.GetValue("tipoAsiento")
                consulta.Cant = r.GetValue("cant")
                consulta.PUmn = r.GetValue("pumn")
                consulta.PUme = r.GetValue("pume")
                consulta.monto = r.GetValue("importeMN")
                consulta.montoUSD = r.GetValue("importeME")
            End If

            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub


    Public Sub ListaDocPago(listaCuenta As List(Of String))
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)

        'tabla = tablaSA.GetListaTablaDetalle(1, "1")
        tabla = (From n In ListaCtaBancaria
                 Where listaCuenta.Contains(n.codigoDetalle)
                 Select n).ToList
        If (Not IsNothing(tabla)) Then
            cboTipoDocumento.DataSource = tabla
            cboTipoDocumento.ValueMember = "codigoDetalle"
            cboTipoDocumento.DisplayMember = "descripcion"
            cboTipoDocumento.SelectedValue = "001"
        End If

    End Sub

#Region "Manipulación Data"
    Public Sub AsientoContableCaja()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento

        asientoBL = New asiento
        asientoBL.periodo = GetPeriodo(txtPeriodo.Value, True)
        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
        asientoBL.idEntidad = txtCF_name.Tag
        asientoBL.nombreEntidad = txtCF_name.Text
        asientoBL.tipoEntidad = txtCF_tipo.Tag
        asientoBL.fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        asientoBL.codigoLibro = "1"
        asientoBL.tipo = "D"
        Select Case lblMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"
                asientoBL.tipoAsiento = ASIENTO_CONTABLE.Finanzas
            Case "OTRAS SALIDAS DE CAJA"
                asientoBL.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        End Select
        asientoBL.importeMN = CDec(txtFondoMN.Value)
        asientoBL.importeME = CDec(txtFondoME.Value)
        asientoBL.glosa = Glosa()


        Select Case lblMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"
                nMovimiento = New movimiento
                nMovimiento.cuenta = txtCF_cuentaContable.Text
                'nMovimiento.descripcion = txtCajaOrigen.Text
                nMovimiento.descripcion = txtCF_name.Text
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(txtFondoMN.Value)
                nMovimiento.montoUSD = CDec(txtFondoME.Value)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "2000"
                nMovimiento.descripcion = "Por entradas de dinero"
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(txtFondoMN.Value)
                nMovimiento.montoUSD = CDec(txtFondoME.Value)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
            Case "OTRAS SALIDAS DE CAJA"

                nMovimiento = New movimiento
                nMovimiento.cuenta = "3000"
                nMovimiento.descripcion = "Por salida de dinero"
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(txtFondoMN.Value)
                nMovimiento.montoUSD = CDec(txtFondoME.Value)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = txtCF_cuentaContable.Text
                ' nMovimiento.descripcion = txtCajaOrigen.Text
                nMovimiento.descripcion = txtCF_name.Text
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(txtFondoMN.Value)
                nMovimiento.montoUSD = CDec(txtFondoME.Value)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)

        End Select
        ListaAsientos.Add(asientoBL)
    End Sub

    Public Function Glosa() As String
        Return "Por movimientos " & lblMovimiento.Text & " con fecha " & New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
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

    Sub CalculoDolares()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value

        If tcambio > 0 Then
            Imn = txtFondoME.Value
            txtFondoMN.Value = Math.Round(Imn * tcambio, 2).ToString("N2")
        End If

    End Sub

    Public Sub UbicarDocumentoEditar(intIdDocumento As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim alEFSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim establecimientoSA As New establecimientoSA
        Dim entidadsa As New entidadSA

        Try

            Dim docCaja = documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)
            If docCaja IsNot Nothing Then

                Select Case docCaja.tipoMovimiento
                    Case MovimientoCaja.SalidaDinero
                        lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                        cbotipoOperacion.Text = "OTRAS SALIDAS DE CAJA"
                    Case MovimientoCaja.EntradaDinero
                        lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                        cbotipoOperacion.Text = "OTRAS ENTRADAS A CAJA"
                End Select

                lblIdDocumento = docCaja.idDocumento
                txtComprobante.Text = "VOUCHER CONTABLE: " & docCaja.numeroDoc
                txtPeriodo.Value = GetPeriodoConvertirToDate(docCaja.periodo)
                Dim mesOperacion = String.Format("{0:00}", docCaja.fechaProceso.Value.Month)
                cboMesCompra.SelectedValue = mesOperacion 'String.Format("0:00", .fechaProceso.Value.Month)
                TxtDia.Text = docCaja.fechaProceso.Value.Day
                txtAnioCompra.Text = docCaja.fechaProceso.Value.Year
                txtHora.Value = docCaja.fechaProceso
                Dim codigoDoc = docCaja.formapago
                nroDocumento = docCaja.numeroDoc
                With alEFSA.GetUbicar_estadosFinancierosPorID(docCaja.entidadFinanciera)
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
                            txtCF_moneda.Tag = .codigo
                            txtCF_moneda.Text = "NACIONAL"
                        Case 2
                            txtCF_moneda.Tag = .codigo
                            txtCF_moneda.Text = "EXTRANJERA"
                    End Select
                    txtCF_name.Tag = .idestado
                    txtCF_name.Text = .descripcion
                    txtCF_cuentaContable.Text = .cuenta
                End With
                cboTipoDocumento.SelectedValue = codigoDoc
                Select Case codigoDoc
                    Case "001"

                        txtNumOper.Text = docCaja.numeroOperacion
                        '    txtCuentaCorriente.Text = docCaja.ctaCorrienteDeposito

                        'If (Not IsNothing(docCaja.bancoEntidad)) Then
                        '    cboEntidad.SelectedValue = docCaja.bancoEntidad
                        'End If

                    Case "007" 'cheques

                        txtNumOper.Text = docCaja.numeroOperacion
                        '    txtCuentaCorriente.Text = docCaja.ctaCorrienteDeposito
                        'If (Not IsNothing(docCaja.bancoEntidad)) Then
                        '    cboEntidad.SelectedValue = docCaja.bancoEntidad
                        'End If

                    Case "111"

                        txtNumOper.Text = docCaja.numeroOperacion
                        '   txtCuentaCorriente.Text = docCaja.ctaCorrienteDeposito
                        'If (Not IsNothing(docCaja.bancoEntidad)) Then
                        '    cboEntidad.SelectedValue = docCaja.bancoEntidad
                        'End If

                    Case "109"

                        txtNumOper.Text = docCaja.numeroOperacion
                        '   txtCuentaCorriente.Text = docCaja.ctaCorrienteDeposito
                        'If (Not IsNothing(docCaja.bancoEntidad)) Then
                        '    cboEntidad.SelectedValue = docCaja.bancoEntidad
                        'End If
                End Select
                txtTipoCambio.Value = docCaja.tipoCambio
                txtFondoMN.Value = docCaja.montoSoles
                txtFondoME.Value = docCaja.montoUsd
                txtDescripcion.Text = docCaja.glosa

                Select Case docCaja.tipoPersona
                    Case "CL"
                        With entidadsa.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, "CL", docCaja.codigoProveedor)
                            txtCliente2.Text = .nombreCompleto
                            txtRuc2.Text = .nrodoc
                            txtCliente2.Tag = .idEntidad
                        End With
                        chProv.Checked = False
                        chTrab.Checked = False
                        chCli.Checked = True
                    Case "PR"
                        With entidadsa.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, "PR", docCaja.codigoProveedor)
                            txtCliente2.Text = .nombreCompleto
                            txtRuc2.Text = .nrodoc
                            txtCliente2.Tag = .idEntidad
                        End With
                        chProv.Checked = True
                        chCli.Checked = False
                        chTrab.Checked = False
                    Case "TR"
                        With entidadsa.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, "PR", docCaja.codigoProveedor)
                            txtCliente2.Text = .nombreCompleto
                            txtRuc2.Text = .nrodoc
                            txtCliente2.Tag = .idEntidad
                        End With
                        chTrab.Checked = True
                        chCli.Checked = False
                        chProv.Checked = False
                End Select

            End If

            'With documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento).First
            '    lblSecuenciaDetalle.Text = .secuencia
            'End With


            ' cboMovimiento.Enabled = False
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub UPDATEOtrosMovimientos()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim idCaja As Integer

        If (Not IsNothing(GFichaUsuarios.IdCajaUsuario)) Then
            idCaja = GFichaUsuarios.IdCajaUsuario
        Else
            idCaja = 0
        End If

        ndocumento = New documento
        With ndocumento
            .idDocumento = lblIdDocumento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "9908"
            .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
            'idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .nroDoc = nroDocumento
            .idOrden = Nothing
            .moneda = Val(txtCF_moneda.Tag)
            .idEntidad = txtCliente2.Tag
            .entidad = txtCliente2.Text
            If (chProv.Checked = True) Then
                .tipoEntidad = "PR"
            ElseIf (chCli.Checked = True) Then
                .tipoEntidad = "CL"
            ElseIf (chTrab.Checked = True) Then
                .tipoEntidad = "TR"
            End If
            .nrodocEntidad = txtRuc2.Text
            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"
                    .tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                Case "OTRAS SALIDAS DE CAJA"
                    .tipoOperacion = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
            End Select
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            .idDocumento = lblIdDocumento
            .periodo = GetPeriodo(txtPeriodo.Value, True)
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .TipoDocumentoPago = "9908"
            .formapago = cboTipoDocumento.SelectedValue
            .codigoProveedor = txtCliente2.Tag  'txtPersona.ValueMember
            .idPersonal = txtCliente2.Tag
            If (chProv.Checked = True) Then
                .tipoPersona = "PR"
            ElseIf (chCli.Checked = True) Then
                .tipoPersona = "CL"
            ElseIf (chTrab.Checked = True) Then
                .tipoPersona = "TR"
            End If
            .codigoLibro = "1"
            .tipoDocPago = "9908"
            .numeroDoc = nroDocumento
            .moneda = txtCF_moneda.Tag
            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"
                    .tipoMovimiento = MovimientoCaja.EntradaDinero
                    .tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                    .movimientoCaja = (MovimientoCaja.Otras_Entradas)
                    .entidadFinanciera = txtCF_name.Tag
                Case "OTRAS SALIDAS DE CAJA"
                    .tipoMovimiento = MovimientoCaja.SalidaDinero
                    .tipoOperacion = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
                    .entidadFinanciera = txtCF_name.Tag
                    .movimientoCaja = (MovimientoCaja.Otras_Saliadas)
            End Select



            If cboTipoDocumento.SelectedValue = "001" Then
                .numeroOperacion = txtNumOper.Text.Trim
                '   .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                '     .bancoEntidad = cboEntidad.SelectedValue
                .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .fechaCobro = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .entregado = "SI"

            ElseIf cboTipoDocumento.SelectedValue = "007" Then ' cheques
                .numeroOperacion = txtNumOper.Text.Trim
                '    .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .fechaCobro = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .entregado = "NO"
            ElseIf cboTipoDocumento.SelectedValue = "111" Then
                .numeroOperacion = txtNumOper.Text.Trim
                '   .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .fechaCobro = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .entregado = "NO"
            ElseIf cboTipoDocumento.SelectedValue = "109" Then
                .numeroOperacion = txtNumOper.Text.Trim
                '    .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaCobro = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .entregado = "NO"
            End If
            .tipoCambio = txtTipoCambio.Value
            .montoSoles = txtFondoMN.Value
            .montoUsd = txtFondoME.Value
            .idCajaUsuario = idCaja
            .glosa = txtDescripcion.Text.Trim
            .estado = "N"
            .idcosto = Nothing
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        Select Case txtCF_moneda.Tag
            Case 1
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                ndocumentoCajaDetalle.idItem = "00"
                ndocumentoCajaDetalle.DetalleItem = Glosa()
                ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
                ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
                ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
                ndocumentoCajaDetalle.entregado = "SI"
                ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                ndocumentoCajaDetalle.documentoAfectado = 0
                ndocumentoCajaDetalle.moneda = 1
                ndocumentoCajaDetalle.idCajaUsuario = idCaja
                ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaModificacion = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
            Case 2
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                ndocumentoCajaDetalle.idItem = "00"
                ndocumentoCajaDetalle.DetalleItem = Glosa()

                If (lblMovimiento.Tag = "OEC") Then
                    ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
                    ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
                    ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                    ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                    ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                Else
                    ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
                    ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
                    ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                    ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                    ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                End If
                ndocumentoCajaDetalle.idDocumento = lblIdDocumento
                ndocumentoCajaDetalle.entregado = "SI"
                ndocumentoCajaDetalle.documentoAfectado = 0
                ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaModificacion = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                ndocumentoCajaDetalle.idCajaUsuario = idCaja
                ndocumentoCajaDetalle.moneda = 2
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
        End Select

        'AsientoContableCaja()
        'ndocumento.asiento = ListaAsientos


        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        documentoCajaSA.EditarGroupCaja(ndocumento)
        lblEstado.Text = "Caja actualizada correctamente!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
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
                    Case MovimientoCaja.SalidaDinero
                        lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                    Case MovimientoCaja.EntradaDinero
                        lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                End Select

                lblIdDocumento = docCaja.idDocumento
                txtComprobante.Text = "VOUCHER CONTABLE: " & docCaja.numeroDoc
                txtPeriodo.Value = GetPeriodoConvertirToDate(docCaja.periodo)
                Dim mesOperacion = String.Format("{0:00}", docCaja.fechaProceso.Value.Month)
                cboMesCompra.SelectedValue = mesOperacion 'String.Format("0:00", .fechaProceso.Value.Month)
                TxtDia.Text = docCaja.fechaProceso.Value.Day
                txtAnioCompra.Text = docCaja.fechaProceso.Value.Year
                Dim codigoDoc = docCaja.formapago
                cbotipoOperacion.Text = "APORTES"
                With alEFSA.GetUbicar_estadosFinancierosPorID(docCaja.entidadFinanciera)
                    Select Case .tipo
                        Case CuentaFinanciera.Banco
                            txtCF_tipo.Text = "CUENTAS EN BANCO"
                        Case CuentaFinanciera.Efectivo
                            txtCF_tipo.Text = "CUENTAS EN EFECTIVO"
                        Case CuentaFinanciera.Tarjeta_Credito
                            txtCF_tipo.Text = "TARJETA DE CREDITO"
                    End Select
                    txtCF_moneda.Text = .codigo
                    txtCF_name.Tag = .idestado
                    txtCF_name.Text = .descripcion
                    txtCF_cuentaContable.Text = .cuenta
                End With
                cboTipoDocumento.SelectedValue = codigoDoc
                Select Case codigoDoc
                    Case "001"

                        txtNumOper.Text = docCaja.numeroOperacion
                        'txtCuentaCorriente.Text = docCaja.ctaCorrienteDeposito

                        'If (Not IsNothing(docCaja.bancoEntidad)) Then
                        '    cboEntidad.SelectedValue = docCaja.bancoEntidad
                        'End If

                    Case "007" 'cheques

                        txtNumOper.Text = docCaja.numeroOperacion
                        '      txtCuentaCorriente.Text = docCaja.ctaCorrienteDeposito
                        'If (Not IsNothing(docCaja.bancoEntidad)) Then
                        '    cboEntidad.SelectedValue = docCaja.bancoEntidad
                        'End If

                    Case "111"

                        txtNumOper.Text = docCaja.numeroOperacion
                        'txtCuentaCorriente.Text = docCaja.ctaCorrienteDeposito
                        'If (Not IsNothing(docCaja.bancoEntidad)) Then
                        '    cboEntidad.SelectedValue = docCaja.bancoEntidad
                        'End If

                    Case "109"

                        txtNumOper.Text = docCaja.numeroOperacion
                        'txtCuentaCorriente.Text = docCaja.ctaCorrienteDeposito
                        'If (Not IsNothing(docCaja.bancoEntidad)) Then
                        '    cboEntidad.SelectedValue = docCaja.bancoEntidad
                        'End If
                End Select
                txtTipoCambio.Value = docCaja.tipoCambio
                txtFondoMN.Value = docCaja.montoSoles
                txtFondoME.Value = docCaja.montoUsd
                txtDescripcion.Text = docCaja.glosa
            End If

            'With documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento).First
            '    lblSecuenciaDetalle.Text = .secuencia
            'End With
            ' cboMovimiento.Enabled = False
            ButtonAdv5.Enabled = False
            LinkLabel1.Visible = False
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub GrabarOtrosMovimientos()
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

        'Select Case usuario.TieneCaja
        '    Case True
        '        idCaja = GFichaUsuarios.IdCajaUsuario
        '    Case False
        '        idCaja = 0
        'End Select

        If (Not IsNothing(GFichaUsuarios.IdCajaUsuario)) Then
            idCaja = GFichaUsuarios.IdCajaUsuario
        Else
            idCaja = 0
        End If

        ndocumento = New documento
        With ndocumento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "9908"
            .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
            idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .nroDoc = idNumeracion
            .idOrden = Nothing
            .moneda = Val(txtCF_moneda.Tag)
            .idEntidad = txtCliente2.Tag
            .entidad = txtCliente2.Text
            If (chProv.Checked = True) Then
                .tipoEntidad = "PR"
            ElseIf (chCli.Checked = True) Then
                .tipoEntidad = "CL"
            ElseIf (chTrab.Checked = True) Then
                .tipoEntidad = "TR"
            End If
            .nrodocEntidad = txtRuc2.Text
            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"
                    .tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                Case "OTRAS SALIDAS DE CAJA"
                    .tipoOperacion = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
            End Select
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            .periodo = GetPeriodo(txtPeriodo.Value, True)
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .TipoDocumentoPago = "9908"
            .formapago = cboTipoDocumento.SelectedValue
            .codigoProveedor = txtCliente2.Tag  'txtPersona.ValueMember
            .idPersonal = txtCliente2.Tag
            If (chProv.Checked = True) Then
                .tipoPersona = "PR"
            ElseIf (chCli.Checked = True) Then
                .tipoPersona = "CL"
            ElseIf (chTrab.Checked = True) Then
                .tipoPersona = "TR"
            End If
            .codigoLibro = "1"
            .tipoDocPago = "9908"
            .numeroDoc = idNumeracion
            .moneda = txtCF_moneda.Tag
            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"
                    .tipoMovimiento = MovimientoCaja.EntradaDinero
                    .tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                    .movimientoCaja = (MovimientoCaja.Otras_Entradas)
                    .entidadFinanciera = txtCF_name.Tag
                Case "OTRAS SALIDAS DE CAJA"
                    .tipoMovimiento = MovimientoCaja.SalidaDinero
                    .tipoOperacion = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
                    .entidadFinanciera = txtCF_name.Tag
                    .movimientoCaja = (MovimientoCaja.Otras_Saliadas)
            End Select



            If cboTipoDocumento.SelectedValue = "001" Then
                .numeroOperacion = txtNumOper.Text.Trim
                '  .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                '  .bancoEntidad = cboEntidad.SelectedValue
                .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .fechaCobro = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .entregado = "SI"

            ElseIf cboTipoDocumento.SelectedValue = "007" Then ' cheques
                .numeroOperacion = txtNumOper.Text.Trim
                '  .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .fechaCobro = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .entregado = "NO"
            ElseIf cboTipoDocumento.SelectedValue = "111" Then
                .numeroOperacion = txtNumOper.Text.Trim
                ' .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .fechaCobro = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                .entregado = "NO"
            ElseIf cboTipoDocumento.SelectedValue = "109" Then
                .numeroOperacion = txtNumOper.Text.Trim
                '   .ctaCorrienteDeposito = txtCuentaCorriente.Text
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaCobro = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .entregado = "NO"
            End If
            .tipoCambio = txtTipoCambio.Value
            .montoSoles = txtFondoMN.Value
            .montoUsd = txtFondoME.Value
            .idCajaUsuario = idCaja
            .glosa = txtDescripcion.Text.Trim
            .estado = "N"
            .idcosto = Nothing
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        Select Case txtCF_moneda.Tag
            Case 1
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                ndocumentoCajaDetalle.idItem = "00"
                ndocumentoCajaDetalle.DetalleItem = Glosa()
                ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
                ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
                ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
                ndocumentoCajaDetalle.entregado = "SI"
                ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                ndocumentoCajaDetalle.documentoAfectado = 0
                ndocumentoCajaDetalle.moneda = 1
                ndocumentoCajaDetalle.idCajaUsuario = idCaja
                ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaModificacion = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
            Case 2
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                ndocumentoCajaDetalle.idItem = "00"
                ndocumentoCajaDetalle.DetalleItem = Glosa()

                If (lblMovimiento.Tag = "OEC") Then
                    ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
                    ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
                    ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                    ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                    ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                Else
                    ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
                    ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
                    ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                    ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                    ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                End If

                ndocumentoCajaDetalle.entregado = "SI"
                ndocumentoCajaDetalle.documentoAfectado = 0
                ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaModificacion = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))
                ndocumentoCajaDetalle.idCajaUsuario = idCaja
                ndocumentoCajaDetalle.moneda = 2
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
        End Select

        'AsientoContableCaja()
        'ndocumento.asiento = ListaAsientos


        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        Dim xCodigoDoc As Integer = documentoCajaSA.SaveGroupCajaOtrosMovimientosSingleME(ndocumento)
        lblEstado.Text = "Caja registrada correctamente!"
        Select Case lblMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"
                Alert = New Alert("Ingreso registrado", alertType.success)
                Alert.TopMost = True
                Alert.Show()
            Case "OTRAS SALIDAS DE CAJA"
                Alert = New Alert("Gasto registrado", alertType.success)
                Alert.TopMost = True
                Alert.Show()
        End Select
        Close()
    End Sub

#End Region

#End Region




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

    Private Sub frmEntradaSalidaCaja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Dim comboTableh As New DataTable

    Private Sub frmEntradaSalidaCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTableAlmacen2()
    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs)
        Select Case txtCF_moneda.Text
            Case 1
                Calculo()
            Case 2
                CalculoDolares()
        End Select
    End Sub


    Private Sub btGrabar_Click(sender As Object, e As EventArgs)

        If Not txtCF_name.Text.Length > 0 Then
            lblEstado.Text = "Ingrese la entidad financiera."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtCF_name.Select()
            Exit Sub
        End If

        If Not cbotipoOperacion.Text.Length > 0 Then
            lblEstado.Text = "Ingrese tipo de operación."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            cbotipoOperacion.Select()
            Exit Sub
        End If

        If Not txtDescripcion.Text.Length > 0 Then
            lblEstado.Text = "Ingrese el detalle del motivo."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtDescripcion.Select()
            Exit Sub
        End If

        Select Case txtCF_moneda.Text
            Case 1
                If Not txtTipoCambio.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                    Exit Sub
                End If

                If Not txtFondoMN.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtFondoMN.Select(0, txtFondoMN.Text.Length)
                    Exit Sub
                End If

            Case 2

                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        If Not txtFondoME.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoME.Select(0, txtFondoME.Text.Length)
                            Exit Sub
                        End If

                        If Not txtTipoCambio.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If
                    Case "OTRAS SALIDAS DE CAJA"
                        If Not txtFondoME.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoME.Select(0, txtFondoME.Text.Length)
                            Exit Sub
                        End If
                End Select

        End Select

        If cboTipoDocumento.SelectedValue = "001" Then
            If Not cboTipoDocumento.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo documento."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboTipoDocumento.Select()
                Exit Sub
            End If

            If Not txtNumOper.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Exit Sub
            End If


            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"

                Case "OTRAS SALIDAS DE CAJA"
                    'If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                    '    lblEstado.Text = "Ingrese el número de cuenta."
                    '    Timer1.Enabled = True
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)
                    '    txtCuentaCorriente.Select()
                    '    Exit Sub
                    'End If
            End Select

        ElseIf cboTipoDocumento.SelectedValue = "007" Then

        ElseIf cboTipoDocumento.SelectedValue = "109" Then
            If Not cboTipoDocumento.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo documento."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboTipoDocumento.Select()
                Exit Sub
            End If

            If Not txtNumOper.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Exit Sub
            End If

        ElseIf cboTipoDocumento.SelectedValue = "111" Then

        End If


        Dim debetotal As Decimal
        Dim habertotal As Decimal
        Dim ListaMovimiento As New List(Of movimiento)

        debetotal = CDec(0.0)
        habertotal = CDec(0.0)

        'If lstAsiento.SelectedItems.Count > 0 Then
        '    Dim consulta = (From n In ListaMovimientos).ToList
        '    If consulta.Count > 0 Then
        '        ListaMovimiento = consulta
        '        For i As Integer = 0 To ListaMovimiento.Count - 1

        '            If ListaMovimiento(i).monto > 0 Then

        '                For j As Integer = 0 To 6
        '                    Select Case ListaMovimiento(i).tipo

        '                        Case "D"
        '                            Select Case j

        '                                Case 3
        '                                    debetotal += ListaMovimiento(i).monto
        '                            End Select

        '                        Case "H"
        '                            Select Case j

        '                                Case 3
        '                                    habertotal += ListaMovimiento(i).monto
        '                            End Select
        '                    End Select
        '                Next
        '            Else
        '                lblEstado.Text = "Las montos del asiento deben ser mayor a 0"
        '                PanelError.Visible = True
        '                Timer1.Enabled = True
        '                TiempoEjecutar(10)
        '                Exit Sub

        '            End If

        '        Next
        '    End If
        'End If

        'If debetotal > 0 Then
        '    If habertotal > 0 Then
        '        If debetotal = habertotal Then

        ''''''''''''''''''''''''''''''''''''''''

        Select Case ManipulacionEstado
            Case ENTITY_ACTIONS.INSERT
                GrabarOtrosMovimientos()
            Case ENTITY_ACTIONS.UPDATE
                UPDATEOtrosMovimientos()
        End Select

        ''''''''''''''''''''''''''''''''''

        '        Else

        'lblEstado.Text = "Las Asientos deben cuadrar"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)

        '        End If
        '    Else
        'lblEstado.Text = "Ingrese un Monto Haber"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        '    End If
        'Else
        'lblEstado.Text = "Ingrese un monto Debe"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        'End If



    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumOper.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'txtImporteCompramn.Clear()
        End Try
    End Sub

    Private Sub txtFondoMN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFondoMN.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        txtTipoCambio.Select()
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)

                    Case "OTRAS SALIDAS DE CAJA"
                        If (txtFondoMN.Value <= SaldoEFMN.DoubleValue And txtFondoMN.Value <> 0) Then
                            txtTipoCambio.Select()
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Else
                            lblEstado.Text = "Debe ingresar un importe menor o igual!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoMN.Value = 0.0
                            txtFondoMN.Select(0, txtFondoMN.Text.Length)
                        End If

                End Select

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub


    Private Sub txtFondoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoMN.ValueChanged
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            Select Case txtCF_moneda.Tag
                Case 1
                    Calculo()
                    Select Case lblMovimiento.Text
                        Case "OTRAS ENTRADAS A CAJA"

                        Case "OTRAS SALIDAS DE CAJA"
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

    Private Sub txtTipoCambio_ValueChanged_1(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        'Select Case cboMoneda.SelectedValue
        '    Case 1
        '        Calculo()
        '        cargarDatos()
        '    Case 2
        '        Select Case lblMovimiento.Text
        '            Case "OTRAS ENTRADAS A CAJA"
        '                CalculoDolares()
        '                cargarDatos()
        '            Case "OTRAS SALIDAS DE CAJA"
        '                CalculoDolares()
        '                cargarDatos()
        '                If (txtFondoME.Value > 0 And txtTipoCambio.Value > 0) Then
        '                    CargarDiferenciasdeImporte()
        '                End If
        '        End Select

        'End Select
    End Sub

    Private Sub txtNumOper_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumOper.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        Select Case txtCF_moneda.Text
                            Case 1
                                txtFondoMN.Select()
                                txtFondoMN.Select(0, txtFondoMN.Text.Length)
                            Case 2
                                txtFondoME.Select()
                                txtFondoME.Select(0, txtFondoME.Text.Length)
                        End Select

                    Case "OTRAS SALIDAS DE CAJA"
                        'txtCuentaCorriente.Select()
                End Select

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub txtCuentaCorriente_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                Select Case lblMovimiento.Text
                    Case "OTRAS SALIDAS DE CAJA"
                        Select Case txtCF_moneda.Text
                            Case 1
                                txtFondoMN.Select()
                                txtFondoMN.Select(0, txtFondoMN.Text.Length)
                            Case 2
                                txtFondoME.Select()
                                txtFondoME.Select(0, txtFondoME.Text.Length)
                        End Select
                End Select

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        If TxtDia.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar la fecha de registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtDia.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim fechaActual As DateTime = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second)) ' Format(Now, txtAnioCompra.Text & "-" & cboMesCompra.SelectedValue & "-" & txtDia.text)

        frmSeleccionCuentaFinanciera = New frmSeleccionCuentaFinanciera
        'frmSeleccionCuentaFinanciera.txtPeriodo.Value = txtPeriodo.Value
        frmSeleccionCuentaFinanciera.txtPeriodo.Value = fechaActual
        frmSeleccionCuentaFinanciera.GetCuentasFinancieras("CUENTAS EN EFECTIVO")
        frmSeleccionCuentaFinanciera.StartPosition = FormStartPosition.CenterParent
        frmSeleccionCuentaFinanciera.ShowDialog()
        If frmSeleccionCuentaFinanciera.Tag IsNot Nothing Then
            txtFondoMN.Value = 0
            txtFondoME.Value = 0
            'txtTipoCambio.Value = 0
            txtNumOper.Clear()
            'txtCuentaCorriente.Clear()
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

            Select Case c.codigo
                Case 1
                    txtCF_moneda.Tag = c.codigo
                    txtCF_moneda.Text = "NACIONAL"
                Case 2
                    txtCF_moneda.Tag = c.codigo
                    txtCF_moneda.Text = "EXTRANJERA"
            End Select

            txtCF_name.Text = c.descripcion
            txtCF_name.Tag = c.idestado
            txtCF_cuentaContable.Text = c.cuenta
            SaldoEFMN.DoubleValue = c.importeBalanceMN.GetValueOrDefault
            SaldoEFME.DoubleValue = 0
            cargarCtasFinan()
        End If
    End Sub

    Private Sub cboTipoDocumento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDocumento.SelectedValueChanged
        If Not IsNothing(cboTipoDocumento.SelectedValue) Then
            Dim v = cboTipoDocumento.SelectedValue.ToString
            Select Case v
                Case "109"
                    '    cboEntidad.Visible = False
                    '    PictureBox1.Visible = False
                    '    txtCuentaCorriente.Visible = False
                    txtNumOper.Visible = False
                Case "001"
                    'cboEntidad.Visible = True
                    'PictureBox1.Visible = True
                    'txtCuentaCorriente.Visible = True
                    txtNumOper.Visible = True
            End Select
        End If
    End Sub

    Private Sub ButtonAdv5_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv5.Click

        If TxtDia.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar la fecha de registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtDia.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If Not txtCF_name.Text.Length > 0 Then
            lblEstado.Text = "Ingrese la entidad financiera."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtCF_name.Select()
            Exit Sub
        End If

        If Not cbotipoOperacion.Text.Length > 0 Then
            lblEstado.Text = "Ingrese tipo de operación."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            cbotipoOperacion.Select()
            Exit Sub
        End If

        If Not txtDescripcion.Text.Length > 0 Then
            lblEstado.Text = "Ingrese el detalle del motivo."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtDescripcion.Select()
            Exit Sub
        End If

        If Not txtRuc2.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el personal"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtRuc2.Select()
            Exit Sub
        End If

        Select Case txtCF_moneda.Text
            Case 1
                If Not txtTipoCambio.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                    Exit Sub
                End If

                If Not txtFondoMN.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtFondoMN.Select(0, txtFondoMN.Text.Length)
                    Exit Sub
                End If

            Case 2

                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        If Not txtFondoME.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoME.Select(0, txtFondoME.Text.Length)
                            Exit Sub
                        End If

                        If Not txtTipoCambio.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If
                    Case "OTRAS SALIDAS DE CAJA"
                        If Not txtFondoME.Value > 0 Then
                            lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            txtFondoME.Select(0, txtFondoME.Text.Length)
                            Exit Sub
                        End If
                End Select

        End Select

        If cboTipoDocumento.SelectedValue = "001" Then
            If Not cboTipoDocumento.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo documento."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboTipoDocumento.Select()
                Exit Sub
            End If

            If Not txtNumOper.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Exit Sub
            End If


            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"

                Case "OTRAS SALIDAS DE CAJA"
                    'If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                    '    lblEstado.Text = "Ingrese el número de cuenta."
                    '    Timer1.Enabled = True
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)
                    '    txtCuentaCorriente.Select()
                    '    Exit Sub
                    'End If
            End Select

        ElseIf cboTipoDocumento.SelectedValue = "007" Then

        ElseIf cboTipoDocumento.SelectedValue = "109" Then
            If Not cboTipoDocumento.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo documento."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboTipoDocumento.Select()
                Exit Sub
            End If

            'If Not txtNumOper.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingrese el número de operación."
            '    Timer1.Enabled = True
            '    PanelError.Visible = True
            '    TiempoEjecutar(10)
            '    txtNumOper.Select()
            '    Exit Sub
            'End If

        ElseIf cboTipoDocumento.SelectedValue = "111" Then

        End If


        Dim debetotal As Decimal
        Dim habertotal As Decimal
        Dim ListaMovimiento As New List(Of movimiento)

        debetotal = CDec(0.0)
        habertotal = CDec(0.0)


        ''''''''''''''''''''''''''''''''''''''''
        Try
            Select Case ManipulacionEstado
                Case ENTITY_ACTIONS.INSERT
                    GrabarOtrosMovimientos()
                Case ENTITY_ACTIONS.UPDATE
                    UPDATEOtrosMovimientos()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try

    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        tipoPersona = "CL"
    End Sub

    Private Sub chProv_Click(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        tipoPersona = "PR"
    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chCli.Checked = False
        chTrab.Checked = True
        tipoPersona = "TR"
    End Sub

    Private Sub ButtonAdv4_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
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
            Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.PERSONAL_PLANILLA)
            f.CaptionLabels(0).Text = "Trabajadores"
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
        End If
    End Sub

    Private Sub txtFondoMN_Click(sender As Object, e As EventArgs) Handles txtFondoMN.Click
        txtFondoMN.Select(0, txtFondoMN.Text.Length)
    End Sub

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then
            txtCF_tipo.Clear()
            txtCF_name.Clear()
            txtCF_moneda.Clear()
            txtCF_cuentaContable.Clear()
            SaldoEFMN.DoubleValue = 0
            SaldoEFME.DoubleValue = 0
        End If
    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
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
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If chProv.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo proveedor"
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chCli.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo Cliente"
            f.strTipo = TIPO_ENTIDAD.CLIENTE
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chTrab.Checked = True Then
            Dim f As New frmNuevoTrabajador
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub bgwCombos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwCombos.DoWork
        GetCombos()
    End Sub

    Private Sub bgwCombos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwCombos.RunWorkerCompleted
        Loadcontroles()
    End Sub

    Private Sub txtDia_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtHora_ValueChanged(sender As Object, e As EventArgs) Handles txtHora.ValueChanged
        txtCF_tipo.Clear()
        txtCF_name.Clear()
        txtCF_moneda.Clear()
        txtCF_cuentaContable.Clear()
        SaldoEFMN.DoubleValue = 0
        SaldoEFME.DoubleValue = 0
    End Sub

    Private Sub txtFondoME_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoME.ValueChanged

    End Sub
End Class
Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms

Public Class FormTablaPrincipal
#Region "Attributes"
    Private UCMantenimiento As UCControlMantenimiento
    Public Property i As Integer = 0
    'Public Property objPleaseWait As FeedbackForm2
    Public Property ConfiguracionInicioSA As New ConfiguracionInicioSA
    Public Property entidadSA As New entidadSA
    Public Property configuracionCuentasSA As New EstadosFinancierosConfiguracionPagosSA
    Public Property usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
    Public Property cajaUsuarioSA As New cajaUsuarioSA
    Private Property FormRepositoryLogistica As FormRepositoryLogistica
    Private Property FormRepositoryComercial As FormRepositoryComercial
    Private Property FormRepositoryFinanzas As FormRepositoryFinanzas
    Private Property FormPrecios As FormExistenciaPreciosEquivalencia

    Private Property FormExistenciaPrecioV1 As FormExistenciaPrecioV1

    Private Property FormUsuarioSPK As FormUsuarioSPK
    Public Property listaInventario As List(Of totalesAlmacen)
    Private FormExistenciaBeneficios As FormExistenciaBeneficios

    Private datosSA As New datosGeneralesSA
    Private FormCajeroIndependiente As FormCajeroIndependiente
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Timer1.Enabled = True
        UCMantenimiento = New UCControlMantenimiento With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCMantenimiento)
        UCMantenimiento.Visible = False
    End Sub
#End Region

#Region "Methods"

    Public Sub AlertasPseConsulta()
        Dim documentosa As New documentoVentaAbarrotesSA

        'Dim consulta = documentosa.AlertaPSE(Gempresas.IdEmpresaRuc)

        'Dim Cant = (consulta.CantFact + consulta.CantNotaFact + consulta.CantFactAnu +
        'consulta.CantBol + consulta.CantNotaBol + consulta.CantBolAnu)

        Dim consulta = documentosa.AlertaEnvioPSE(Gempresas.IdEmpresaRuc)

        Dim Cant = (consulta.CpePen + consulta.AnuPen)


        If My.Computer.Network.IsAvailable = True Then

            'Dim f As New FrmAlertasEnvioPSE

            'f.lblFacturasPendientes.Text = consulta.CantFact
            'f.lblNotasPendiente.Text = consulta.CantNotaFact
            'f.lblFacturasAnuladas.Text = consulta.CantFactAnu
            'f.lblboletaspendientes.Text = consulta.CantBol
            'f.lblnotaboletas.Text = consulta.CantNotaBol
            'f.LBLBOLETASELIMINADAS.Text = consulta.CantBolAnu
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()

            Dim f As New FormEnviosPendientesPse  'frmMasterFacturacionPSE
            f.StartPosition = FormStartPosition.CenterParent
            f.lblAnulados.Text = consulta.AnuPen
            f.lblCpe.Text = consulta.CpePen
            f.ShowDialog()
        Else
            MsgBox("NO TIENE ACCESO A INTERNET !!ALERTA TIENE CPE PENDIENTES DE ENVIO")
            'MsgBox("No tengo conexión a Internet")
        End If




    End Sub

    Public Sub AlertasPSE()
        Dim documentosa As New documentoVentaAbarrotesSA

        'Dim consulta = documentosa.AlertaPSE(Gempresas.IdEmpresaRuc)

        'Dim Cant = (consulta.CantFact + consulta.CantNotaFact + consulta.CantFactAnu +
        'consulta.CantBol + consulta.CantNotaBol + consulta.CantBolAnu)

        Dim consulta = documentosa.AlertaEnvioPSE(Gempresas.IdEmpresaRuc)

        Dim Cant = (consulta.CpePen + consulta.AnuPen)

        If Cant > 0 Then
            If My.Computer.Network.IsAvailable = True Then

                'Dim f As New FrmAlertasEnvioPSE

                'f.lblFacturasPendientes.Text = consulta.CantFact
                'f.lblNotasPendiente.Text = consulta.CantNotaFact
                'f.lblFacturasAnuladas.Text = consulta.CantFactAnu

                'f.lblboletaspendientes.Text = consulta.CantBol
                'f.lblnotaboletas.Text = consulta.CantNotaBol
                'f.LBLBOLETASELIMINADAS.Text = consulta.CantBolAnu


                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()


                Dim f As New FormEnviosPendientesPse  'frmMasterFacturacionPSE
                f.StartPosition = FormStartPosition.CenterParent
                f.lblAnulados.Text = consulta.AnuPen
                f.lblCpe.Text = consulta.CpePen
                f.ShowDialog()

            Else
                MsgBox("NO TIENE ACCESO A INTERNET !!ALERTA TIENE CPE PENDIENTES DE ENVIO")

            End If
        End If



    End Sub

    Private Sub GetConfiguracionpagos()
        Dim pagoSA As New EstadosFinancierosConfiguracionPagosSA

        ListConfigurationPays = New List(Of estadosFinancierosConfiguracionPagos)
        ListConfigurationPays = pagoSA.GetConfigurationPay(New estadosFinancierosConfiguracionPagos With
                {
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                                                           })

        ListaCuentasFinancierasConfiguradas = ListConfigurationPays
    End Sub

    Private Sub GetConfiguracionInicioBasico()
        Try
            Dim centroCostosConfSA As New centroCostosXNComercialSA
            Dim consultaConf As New centroCostosXNComercial
            Dim cierreSA As New empresaCierreMensualSA
            Dim tipoCambioSA As New tipoCambioSA
            Dim configuracion As New configuracionInicio
            Dim inicio = ConfiguracionInicioSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            Dim anioSA As New empresaPeriodoSA

            '   LinkLabel2.Visible = False
            Dim existeAnio = anioSA.GetUbicar_empresaPeriodoPorID(Gempresas.IdEmpresaRuc, Date.Now.Year, GEstableciento.IdEstablecimiento)
            If existeAnio Is Nothing Then
                Dim nuevoAnio As New empresaPeriodo With
                    {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .idCentroCosto = GEstableciento.IdEstablecimiento,
                    .periodo = Date.Now.Year,
                    .cerrado = False,
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = Date.Now
                    }
                anioSA.InsertarPeriodo(nuevoAnio)

                existeAnio = nuevoAnio
            End If

            Dim tipoCambioDelDia = tipoCambioSA.ObtenerTipoCambioXfecha(Gempresas.IdEmpresaRuc, Date.Now.Date, GEstableciento.IdEstablecimiento)

            If tipoCambioDelDia Is Nothing Then
                'Agregar nueva instancia
                Dim objTC As New tipoCambio With
                                      {
                                      .idEmpresa = Gempresas.IdEmpresaRuc,
                                      .fechaIgv = Date.Now,
                                      .idRegulador = 100,
                                      .compra = 3,
                                      .venta = 3,
                                      .usuarioModificacion = usuario.IDUsuario,
                                      .fechaModificacion = Date.Now
                                      }

                '  tipoCambioSA.InsertTC(objTC)
                tipoCambioDelDia = objTC
            Else
                'utilizar instancia recuperada
            End If


            configuracion = New configuracionInicio With
                    {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .idCentroCosto = GEstableciento.IdEstablecimiento,
                    .periodo = String.Format("{0:00}", Date.Now.Month) & "/" & Date.Now.Year,
                    .anio = existeAnio.periodo,
                    .mes = Date.Now.Month,
                    .dia = Date.Now,
                    .tipocambio = 3,
                    .iva = 18,
                    .tipoIva = "IVA",
                    .montoMaximo = 699,
                    .proyecto = "N",
                    .tipoCambioTransacCompra = 3,
                    .tipoCambioTransacVenta = 3,
                    .cronogramaPagos = False,
                    .usacronogramapago = False,
                    .FormatoVenta = "MKT"
                    }

            If inicio Is Nothing Then
                'crear nueva instancia
                ConfiguracionInicioSA.InsertConfigInicio(configuracion)
                inicio = configuracion
                tmpConfigInicio = configuracion
            Else
                'actualizar instancia creada
                configuracion.iva = inicio.iva
                configuracion.montoMaximo = inicio.montoMaximo
                ConfiguracionInicioSA.EditarConfigInicio(configuracion)
                tmpConfigInicio = inicio
            End If

            'Variables y etiquetas
            AnioGeneral = existeAnio.periodo
            MesGeneral = String.Format("{0:00}", Date.Now.Month)
            DiaLaboral = Date.Now
            PeriodoGeneral = String.Format("{0:00}", Date.Now.Month) & "/" & existeAnio.periodo

            TmpTipoCambio = 3
            TmpTipoCambioTransaccionCompra = 3
            TmpTipoCambioTransaccionVenta = 3
            TmpIGV = inicio.iva
            MontoMaximoCliente = inicio.montoMaximo

            'ValidandoCierre
            Dim fechaAnt = New Date(Date.Now.Year, CInt(Date.Now.Month), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Dim f As New frmselectCierre("No Cerrado")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If f.Tag = "No Cerrado" Then
                    Exit Sub
                End If
                If IsNothing(f.Tag) Then
                    Exit Sub
                End If
            End If
            'CaptionLabels(1).Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            LabelUsuario.Text = "USUARIO:" & vbCrLf & usuario.Alias
            Select Case tmpConfigInicio.FormatoVenta
                Case "FACT"
                    BannerTile.Enabled = False
                    ButtonAdv11.Enabled = False
                    ButtonAdv6.Enabled = False
                    ButtonAdv2.Enabled = False
                Case "FACSV"
                    BannerTile.Enabled = False
                    ButtonAdv11.Enabled = False
                    ButtonAdv6.Enabled = False
                    ButtonAdv2.Enabled = False
                Case Else
                    BannerTile.Enabled = True
                    ButtonAdv11.Enabled = True
                    ButtonAdv6.Enabled = True
                    ButtonAdv2.Enabled = True
            End Select

            consultaConf = centroCostosConfSA.GetListaNegociosDisponibles(New centroCostosXNComercial With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})

            htHotel.Visible = False
            htPiscina.Visible = False
            htRestaurante.Visible = False
            htTransporte.Visible = False
            HubTile11.Visible = False
            Select Case consultaConf.nombreComercial
                Case "RESTAURANTE"
                    FlowLayoutPanel1.Visible = True
                    htRestaurante.Visible = True
                Case "PISCINA"
                    FlowLayoutPanel1.Visible = True
                    htPiscina.Visible = True
                Case "HOTEL"
                    FlowLayoutPanel1.Visible = True
                    htHotel.Visible = True
                Case "TRANSPORTE"
                    FlowLayoutPanel1.Visible = True
                    htTransporte.Visible = True
                Case "VENTA_DIRECTA"
                    FlowLayoutPanel1.Visible = True
                    HubTile11.Visible = True
                Case Else
                    FlowLayoutPanel1.Visible = False
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FormLogeoNuevoIntro()
        'Dim Login As New FormOrgainizacion
        'Login.StartPosition = FormStartPosition.CenterParent
        'Login.ShowDialog(Me)
        'Application.DoEvents()
        'GetConfiguracionInicioBasico()
        'If bg.IsBusy <> True Then
        '    ' Start the asynchronous operation.
        '    bg.RunWorkerAsync()
        'End If

        Me.Dispose()
        Dim Login As New FormOrgainizacionV2
        Login.StartPosition = FormStartPosition.CenterParent
        Login.ShowDialog()
        Application.DoEvents()
        'GetConfiguracionInicioBasico()
        'If bg.IsBusy <> True Then
        '    ' Start the asynchronous operation.
        '    bg.RunWorkerAsync()
        'End If

    End Sub

    Private Sub FormLogeoNuevo()
        ' GetDeshabilitarControles()

        'objPleaseWait = New FeedbackForm2()
        'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        'objPleaseWait.Show()
        Application.DoEvents()
        GetConfiguracionInicioBasico()
        If bg.IsBusy <> True Then
            ' Start the asynchronous operation.
            bg.RunWorkerAsync()
        End If
    End Sub
#End Region

#Region "Events"
    Private Sub FormTablaPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Centrar(Me)
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i += 1000
        If i = 1000 Then
            i = 0
            Timer1.Stop()
            FormLogeoNuevo()
            'FormLogeo()
        End If
        PanelBody.Enabled = True
    End Sub

    Private Sub bg_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bg.DoWork
        Dim detalleitemsSA As New detalleitemsSA
        Dim inventarioSA As New TotalesAlmacenSA
        VarClienteGeneral = entidadSA.UbicarEntidadVarios("VR", General.Gempresas.IdEmpresaRuc, String.Empty, GEstableciento.IdEstablecimiento)

        'ListaCuentasFinancierasConfiguradas = configuracionCuentasSA.GetConfigurationPay(New estadosFinancierosConfiguracionPagos With
        '                                     {
        '                                     .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                     .idEstablecimiento = GEstableciento.IdEstablecimiento
        '                                     })

        UsuariosList = usuarioListSA.ListadoUsuariosv2()
        Seguridad.General.ListaUsuariosSoftpack = UsuariosList
        ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })

        CustomListaDatosGenerales = datosSA.UbicaEmpresaFull(New datosGenerales With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})
        ListadoProductosSingleton = detalleitemsSA.GetProductosWithInventario(New detalleitems With {
                                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                              .descripcionItem = ""
                                                                              })


        listaInventario = inventarioSA.GetInventarioAcumulado(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

        GetConfiguracionpagos()
    End Sub


    Public Sub LogeoUsuarioCaja()
        Try


            Dim usuarioSel = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).FirstOrDefault
            If usuarioSel IsNot Nothing Then
                BunifuFlatButton17.Text = usuarioSel.Full_Name
                BunifuFlatButton17.Tag = usuarioSel.IDUsuario


                'Dim cargo = (From i In PositionList Where i.idCargo = usuarioSel.idCargo).FirstOrDefault

                'If cargo IsNot Nothing Then

                BunifuFlatButton5.Text = usuario.nombreCargo

                'End If


                Dim cajaAct = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault


                If cajaAct IsNot Nothing Then


                    BunifuFlatButton7.Text = "ABIERTO"
                    BunifuFlatButton7.Textcolor = Color.FromArgb(250, 203, 81)

                End If

                'Dim cajaSA As New cajaUsuarioSA
                'Dim be As New cajaUsuario
                'be.idEmpresa = Gempresas.IdEmpresaRuc
                'be.idEstablecimiento = GEstableciento.IdEstablecimiento
                'be.idPersona = usuario.IDUsuario

                'Dim Cant = cajaSA.ListBoxClosedPendingUser(be)
                'BunifuCustomLabel18.Text = Cant


            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub AbrirCajaGeneral()
        Dim usuarioSel = UsuariosList.Where(Function(o) o.TipoDocumento = "SUPER").FirstOrDefault
        If usuarioSel IsNot Nothing Then

            Dim CargoSelec = usuarioSel.UsuarioRol.FirstOrDefault  ' super usuairo solo tiene 1 rol 
            If CargoSelec IsNot Nothing Then


                Dim cajaSA As New cajaUsuarioSA
                Dim objCaja As New cajaUsuario
                Dim documentoCajaSA As New DocumentoCajaSA
                Dim UserDetalle As New cajaUsuariodetalle
                Dim ListaUserDetalle As New List(Of cajaUsuariodetalle)
                Try
                    objCaja = New cajaUsuario

                    Dim shostname As String
                    shostname = System.Net.Dns.GetHostName
                    With objCaja
                        .IDRol = CargoSelec.IDRol
                        .tipoCaja = Tipo_Caja.GENERAL
                        .namepc = shostname
                        .idEmpresa = Gempresas.IdEmpresaRuc
                        .idEstablecimiento = GEstableciento.IdEstablecimiento
                        .periodo = GetPeriodo(Date.Now, True)
                        .idPersona = usuarioSel.IDUsuario
                        .idCajaOrigen = 0
                        .idCajaDestino = 0
                        .moneda = "1"
                        .tipoCambio = TmpTipoCambio
                        .fechaRegistro = Date.Now
                        .fondoMN = 0
                        .fondoME = 0
                        .ingresoAdicMN = 0
                        .ingresoAdicME = 0
                        .otrosIngresosMN = 0
                        .otrosIngresosME = 0
                        .otrosEgresosMN = 0
                        .otrosEgresosME = 0
                        .estadoCaja = "A"
                        .enUso = "N"
                        .usuarioActualizacion = usuario.IDUsuario
                        .fechaActualizacion = DateTime.Now
                    End With

                    ListaUserDetalle = New List(Of cajaUsuariodetalle)

                    For Each d In ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991" And o.tipoCaja <> "EP").ToList
                        UserDetalle = New cajaUsuariodetalle
                        UserDetalle.idEntidad = Integer.Parse(d.identidad)
                        UserDetalle.moneda = d.moneda

                        If UserDetalle.moneda = "1" Then
                            UserDetalle.importeMN = CDec(0.0)
                            UserDetalle.importeME = 0
                        ElseIf UserDetalle.moneda = "2" Then
                            UserDetalle.importeMN = 0
                            UserDetalle.importeME = CDec(0.0)
                        End If

                        UserDetalle.tipoCambio = TmpTipoCambio
                        UserDetalle.usuarioActualizacion = usuario.IDUsuario
                        UserDetalle.idConfiguracion = Integer.Parse(d.idConfiguracion)
                        UserDetalle.fechaActualizacion = DateTime.Now
                        ListaUserDetalle.Add(UserDetalle)
                    Next
                    objCaja.cajaUsuariodetalle = ListaUserDetalle
                    If ListaUserDetalle.Count = 0 Then Exit Sub
                    Dim codigoUsuarioClave = documentoCajaSA.SaveCajaAdministrativaApertura(Nothing, objCaja, Nothing)
                    ListaCajasActivas = cajaSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                     .estadoCaja = "A"
                                                                     })

                Catch ex As Exception

                End Try


            End If

        End If




    End Sub




    Private Sub bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted

        PictureLoading.Visible = False
        If ListaCajasActivas IsNot Nothing Then
            If ListaCajasActivas.Count > 0 Then

                'Dim cajasVencidas2 = ListaCajasActivas.Where(Function(o) o.fechaRegistro.Value.Date < Date.Now.Date And o.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA).ToList
                Dim cajasVencidas2 = ListaCajasActivas.Where(Function(o) o.fechaRegistro.Value.Date < Date.Now.Date).ToList
                If cajasVencidas2.Count > 0 Then



                    Dim FormCajaActivas As New FormCajaActivas(cajasVencidas2)
                    FormCajaActivas.StartPosition = FormStartPosition.CenterParent
                    FormCajaActivas.ShowDialog(Me)

                    ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                     .estadoCaja = "A"
                                                     })







                    'If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then


                    '    Dim CajaAdmi = (From i In cajasVencidas2 Where i.tipoCaja = Tipo_Caja.ADMINISTRATIVO).ToList

                    '    If CajaAdmi.Count > 0 Then
                    '        Dim FormCajaActivas As New FormCajaActivas(CajaAdmi, usuario.tipoCaja)
                    '        FormCajaActivas.StartPosition = FormStartPosition.CenterParent
                    '        FormCajaActivas.ShowDialog(Me)

                    '        ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                    '                                         .idEmpresa = Gempresas.IdEmpresaRuc,
                    '                                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    '                                         .estadoCaja = "A"
                    '                                         })

                    '    End If


                    'ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then


                    '    Dim CajasPos = (From i In cajasVencidas2 Where i.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA).ToList

                    '    If CajasPos.Count > 0 Then
                    '        Dim FormCajaActivas As New FormCajaActivas(CajasPos, usuario.tipoCaja)
                    '        FormCajaActivas.StartPosition = FormStartPosition.CenterParent
                    '        FormCajaActivas.ShowDialog(Me)

                    '        ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                    '                                         .idEmpresa = Gempresas.IdEmpresaRuc,
                    '                                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    '                                         .estadoCaja = "A"
                    '                                         })

                    '    End If


                    'End If


                End If

            End If

            Dim cajaActiva = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

            If cajaActiva Is Nothing Then
                AbrirCajaGeneral()
            End If



        End If

        If Gempresas.ubigeo IsNot Nothing Then
            ButtonAdv5.Text = "NUEVA VENTA"
        Else
            ButtonAdv5.Text = "NOTA VENTA"
        End If

        GetStockEscaso()
        LogeoUsuarioCaja()
        WebBrowser1.Navigate("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaMovil.jsp")
        LabelEmpresa.Text = Gempresas.NomEmpresa.ToLower
        lblCentroNegocio.Text = GEstableciento.NombreEstablecimiento.ToLower
    End Sub

    Private Sub GetStockEscaso()
        'Dim minCantidad = listaInventario.Max(Function(o) o.cantidadMinima)
        'minCantidad = minCantidad + 5

        'Dim minCantidadRequerimiento = listaInventario.Max(Function(o) o.cantidadMinima)
        'minCantidadRequerimiento = minCantidadRequerimiento - 5

        'Dim SinStock As Decimal = listaInventario.Where(Function(o) o.cantidad <= 0).Count
        'Dim stockRequeri As Decimal = listaInventario.Where(Function(o) o.cantidad < o.cantidadMinima And o.cantidad > 0).Count
        'Dim stockMinimo As Decimal = listaInventario.Where(Function(o) o.cantidad = o.cantidadMinima).Count
        'Dim stockBase As Decimal = listaInventario.Where(Function(o) o.cantidad > o.cantidadMinima AndAlso o.cantidad <= minCantidad).Count
        If listaInventario IsNot Nothing Then
            If listaInventario.Count > 0 Then
                Dim resultado = listaInventario.FirstOrDefault.cantidad ' SinStock + stockRequeri + stockMinimo + stockBase
                ButtonAdv14.Text = "STOCK ESCASO: " & resultado
            Else
                ButtonAdv14.Text = "STOCK ESCASO: " & 0
            End If
        Else
            ButtonAdv14.Text = "STOCK ESCASO: " & 0
        End If


    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs)

    End Sub

    Private Sub BannerTile_Click(sender As Object, e As EventArgs) Handles BannerTile.Click
        Me.Cursor = Cursors.WaitCursor

        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.LOGISTICA_, AutorizacionRolList) Then
        If validarPermisos(PermisosDelSistema.LOGISTICA_, AutorizacionRolList) = 1 Then
            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormRepositoryLogistica").SingleOrDefault
            If frm Is Nothing Then
                FormRepositoryLogistica = New FormRepositoryLogistica
                FormRepositoryLogistica.StartPosition = FormStartPosition.CenterScreen
                FormRepositoryLogistica.Show()
            Else
                FormRepositoryLogistica.WindowState = FormWindowState.Normal
                FormRepositoryLogistica.BringToFront()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click



        Me.Close()
    End Sub

    Private Sub HubTile3_Click(sender As Object, e As EventArgs) Handles HubTile3.Click
        Me.Cursor = Cursors.WaitCursor

        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.COMERCIAL_, AutorizacionRolList) Then
        If validarPermisos(PermisosDelSistema.COMERCIAL_, AutorizacionRolList) = 1 Then
            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormRepositoryComercial").SingleOrDefault
            If frm Is Nothing Then
                FormRepositoryComercial = New FormRepositoryComercial
                FormRepositoryComercial.StartPosition = FormStartPosition.CenterScreen
                FormRepositoryComercial.Show()
            Else
                FormRepositoryComercial.WindowState = FormWindowState.Normal
                FormRepositoryComercial.BringToFront()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ADMINISTRAR_PRECIOS__, AutorizacionRolList) Then
        'If validarPermisos(PermisosDelSistema.GESTION_DE_PRECIOS_, AutorizacionRolList) = 1 Then

        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormExistenciaPreciosEquivalencia").SingleOrDefault
            ' Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormExistenciaPrecioV1").SingleOrDefault

            'If frm Is Nothing Then
            '    FormExistenciaPrecioV1 = New FormExistenciaPrecioV1
            '    FormExistenciaPrecioV1.StartPosition = FormStartPosition.CenterScreen
            '    FormExistenciaPrecioV1.Show(Me)
            'Else
            '    FormExistenciaPrecioV1.WindowState = FormWindowState.Normal
            '    FormExistenciaPrecioV1.BringToFront()
            'End If

            If frm Is Nothing Then
                FormPrecios = New FormExistenciaPreciosEquivalencia
                FormPrecios.StartPosition = FormStartPosition.CenterScreen
                FormPrecios.Show(Me)
            Else
                FormPrecios.WindowState = FormWindowState.Normal
                FormPrecios.BringToFront()
            End If
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor

        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_COMPRA_Formulario___, AutorizacionRolList) Then
        If validarPermisos(PermisosDelSistema.INGRESO_DE_COMPRAS_, AutorizacionRolList) = 1 Then
            Dim f As New FormCrearCompra("COMPRAS")
            f.ComboComprobante.Enabled = True
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click

        Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

        If cajaActivaGeneral Is Nothing Then
            AbrirCajaGeneral()
        End If

        If validarPermisos(PermisosDelSistema.VENTA_, AutorizacionRolList) = 1 Then



            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If

            If GconfigCaja = "2" Then


                Dim querybox As cajaUsuario

                If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then
                    querybox = (From i In ListaCajasActivas
                                Where i.tipoCaja = Tipo_Caja.GENERAL And i.estadoCaja = "A").FirstOrDefault
                ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then
                    querybox = (From i In ListaCajasActivas
                                Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).FirstOrDefault

                End If

                If querybox IsNot Nothing Then
                    Else
                        MessageBox.Show("Su usuario no tiene una caja aperturada")
                        Exit Sub
                    End If
                End If
                If ButtonAdv5.Text = "NOTA VENTA" Then
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "NOTA DE VENTA"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            Else
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "VENTA"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            End If
        End If
    End Sub

    Private Sub HubTile5_Click(sender As Object, e As EventArgs) Handles HubTile5.Click
        Me.Cursor = Cursors.WaitCursor

        Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

        If cajaActivaGeneral Is Nothing Then
            AbrirCajaGeneral()
        End If


        If validarPermisos(PermisosDelSistema.FINANZAS_, AutorizacionRolList) = 1 Then
            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormRepositoryFinanzas").SingleOrDefault
            If frm Is Nothing Then
                FormRepositoryFinanzas = New FormRepositoryFinanzas
                FormRepositoryFinanzas.StartPosition = FormStartPosition.CenterScreen
                FormRepositoryFinanzas.Show()
            Else
                FormRepositoryFinanzas.WindowState = FormWindowState.Normal
                FormRepositoryFinanzas.BringToFront()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile1_Click(sender As Object, e As EventArgs) Handles HubTile1.Click
        UCMantenimiento.BringToFront()
        UCMantenimiento.Show()
        UCMantenimiento.Visible = True
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "PRINCIPAL"
                UCMantenimiento.Visible = False
                PanelBody.Visible = True
        End Select
    End Sub

    Private Sub BunifuCustomLabel9_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel9.Click
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.CIERRE_MENSUAL_, AutorizacionRolList) Then
        If validarPermisos(PermisosDelSistema.CIERRE_DE_PERIODO_, AutorizacionRolList) = 1 Then
            Dim f As New frmselectCierre
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_INGRESO_Botón___, AutorizacionRolList) Then

        Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

        If cajaActivaGeneral Is Nothing Then
            AbrirCajaGeneral()
        End If

        If validarPermisos(PermisosDelSistema.INGRESO_DE_EFECTIVO_, AutorizacionRolList) = 1 Then


            ' Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            'If Not IsNothing(cajaUsuario) Then
            '    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

            Dim f As New FormRealizacionDePagos
            f.txtAnioCompra.Text = DateTime.Now.Year
            f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
            f.txtHora.Value = DateTime.Now
            f.TxtDia.Text = DateTime.Now.Day ' ""
            f.StartPosition = FormStartPosition.CenterParent
            f.txtTipoCambio.Value = TmpTipoCambio
            f.ShowDialog(Me)
            'Else
            '    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_SALIDA_CAJA_Botón___, AutorizacionRolList) Then


        Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

        If cajaActivaGeneral Is Nothing Then
            AbrirCajaGeneral()
        End If
        If validarPermisos(PermisosDelSistema.SALIDA_DE_EFECTIVO_, AutorizacionRolList) = 1 Then
            'Else
            '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
            '    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            '    If Not IsNothing(cajaUsuario) Then
            '  GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
            Dim f As New FormPagoEgreso
            f.txtAnioCompra.Text = DateTime.Now.Year
            f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
            f.txtHora.Value = DateTime.Now
            f.TxtDia.Text = DateTime.Now.Day ' ""
            f.StartPosition = FormStartPosition.CenterParent
            f.txtTipoCambio.Value = TmpTipoCambio
            f.ShowDialog(Me)
            'Else
            '    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv17_Click(sender As Object, e As EventArgs) Handles ButtonAdv17.Click

        If validarPermisos(PermisosDelSistema.TRANSFERENCIA_ENTRE_ALMACENES_, AutorizacionRolList) = 1 Then

            'Cursor = Cursors.WaitCursor
            'Dim f As New FormProductosTransito
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog(Me)
            'Cursor = Cursors.Default
            Dim f As New FormSalidasInventarioVenta
            'f.ComboComprobante.Text = "TRANSFERENCIA ENTRE ALMACENES"
            'f.ComboComprobante.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub sliderTop_Click(sender As Object, e As EventArgs) Handles sliderTop.Click

    End Sub

    Private Sub BunifuiOSSwitch1_OnValueChange(sender As Object, e As EventArgs) Handles BunifuiOSSwitch1.OnValueChange
        If BunifuiOSSwitch1.Value = True Then
            Label3.ForeColor = Color.Black
            Label4.ForeColor = Color.Black
            PanelBody.BackColor = Color.FromArgb(255, 243, 243)
            'PanelBody.BackgroundColor.BackColor = Color.WhiteSmoke
        ElseIf BunifuiOSSwitch1.Value = False Then
            Label3.ForeColor = Color.WhiteSmoke
            Label4.ForeColor = Color.WhiteSmoke
            PanelBody.BackColor = Color.FromArgb(36, 41, 46)
        End If
    End Sub

    Private Sub panelheader_Paint(sender As Object, e As PaintEventArgs) Handles panelheader.Paint

    End Sub

    Private Function TerminarProceso(ByVal StrNombreProceso As String,
    Optional ByVal DecirSINO As Boolean = True) As Boolean
        ' Variables para usar Wmi  
        Dim ListaProcesos As Object
        Dim ObjetoWMI As Object
        Dim ProcesoACerrar As Object

        TerminarProceso = False

        ObjetoWMI = GetObject("winmgmts:")

        If ObjetoWMI Is DBNull.Value = False Then

            'instanciamos la variable  
            ListaProcesos = ObjetoWMI.InstancesOf("win32_process")

            For Each ProcesoACerrar In ListaProcesos
                If UCase(ProcesoACerrar.Name) = UCase(StrNombreProceso) Then
                    If DecirSINO Then
                        '   If MsgBox("¿Matar el proceso " & _
                        'ProcesoACerrar.Name & vbNewLine & "...¿Está seguro?", _
                        '                      vbYesNo + vbCritical) = vbYes Then

                        ProcesoACerrar.Terminate(0)
                        TerminarProceso = True
                        '  End If
                    Else
                        'Matamos el proceso con el método Terminate  
                        ProcesoACerrar.Terminate(0)
                        TerminarProceso = True
                    End If
                End If

            Next
        End If

        'Elimina las variables  
        ListaProcesos = Nothing
        ObjetoWMI = Nothing
    End Function

    Private Sub FormTablaPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Gempresas.ubigeo > 0 Then

            AlertasPSE()

        End If

        If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            TerminarProceso("Helios.Cont.Presentation.WinForm")
            TerminarProceso("SMSvcHost.exe")
            Application.ExitThread()
            'bg.s

            If bg IsNot Nothing Then

            End If
            '       bg.CancelAsync()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub bunifuCustomLabel1_Click(sender As Object, e As EventArgs) Handles bunifuCustomLabel1.Click
        'Dim f As New FormImportarExcelInventario
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog(Me)
    End Sub

    Private Sub BunifuCustomLabel3_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel3.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.FACTURACION_ELECTRONICA___, AutorizacionRolList) Then

        If Gempresas.ubigeo > 0 Then

            AlertasPseConsulta()
        Else
            MessageBox.Show("Debe habilitar la facturación electronica", "Ubigeo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    'Public Function validarPermisos(idaseg As Integer, lista As List(Of AutorizacionRol)) As Integer

    '    Dim consulta = (From i In lista
    '                    Where i.IDAsegurable = idaseg).Count

    '    Return consulta
    'End Function


    Private Sub HubTile2_Click(sender As Object, e As EventArgs) Handles HubTile2.Click

        Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

        If cajaActivaGeneral Is Nothing Then
            AbrirCajaGeneral()
        End If

        If validarPermisos(PermisosDelSistema.CAJA_, AutorizacionRolList) = 1 Then


            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If

            If GconfigCaja = "2" Then

                Dim querybox = (From i In ListaCajasActivas
                                Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).FirstOrDefault

                If querybox IsNot Nothing Then
                Else
                    MessageBox.Show("Su usuario no tiene una caja aperturada")
                    Exit Sub
                End If
            End If

            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormCajeroIndependiente").SingleOrDefault
            If frm Is Nothing Then


                If usuario.tipoCaja = "POS" Then

                    FormCajeroIndependiente = New FormCajeroIndependiente
                    FormCajeroIndependiente.StartPosition = FormStartPosition.CenterScreen
                    FormCajeroIndependiente.Show()

                Else
                    MessageBox.Show("Su cargo no puede apertar Caja Pos", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                FormCajeroIndependiente.WindowState = FormWindowState.Normal
                FormCajeroIndependiente.BringToFront()
            End If

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub HubTile7_Click(sender As Object, e As EventArgs) Handles HubTile7.Click
        Try


            Me.Cursor = Cursors.WaitCursor
            'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ABRIR_CAJA_Formulario___, AutorizacionRolList) Then

            Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

            If cajaActivaGeneral Is Nothing Then
                AbrirCajaGeneral()
            End If

            If validarPermisos(PermisosDelSistema.CIERRE_DE_CAJA_, AutorizacionRolList) = 1 Then

                If usuario.tipoCaja = "POS" Then
                    Dim f As New FormCrearCajero
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                Else
                    MessageBox.Show("Su cargo no puede apertar Caja Pos", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs) Handles ButtonAdv10.Click
        If Gempresas.ubigeo > 0 Then

            AlertasPseConsulta()
        Else
            MessageBox.Show("Debe habilitar la facturación electronica", "Ubigeo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv12_Click(sender As Object, e As EventArgs) Handles ButtonAdv12.Click
        Dim f As New FormVentaNueva
        f.ComboComprobante.Enabled = False
        f.ComboComprobante.Text = "PRE VENTA"
        f.CheckDistribucion.Checked = False
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click


        'If validarPermisos(PermisosDelSistema.MODULO_DE_USUARIOS_, AutorizacionRolList) = 1 Then


        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormUsuarioSPK").SingleOrDefault
        If frm Is Nothing Then
            FormUsuarioSPK = New FormUsuarioSPK
            FormUsuarioSPK.Show()
        Else
            FormUsuarioSPK.WindowState = FormWindowState.Normal
            FormUsuarioSPK.BringToFront()
        End If


        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If




    End Sub

    Private Sub ButtonAdv11_Click(sender As Object, e As EventArgs) Handles ButtonAdv11.Click
        Me.Cursor = Cursors.WaitCursor

        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_COMPRA_Formulario___, AutorizacionRolList) Then
        If validarPermisos(PermisosDelSistema.ENTRADA_INVENTARIO_, AutorizacionRolList) = 1 Then
            Dim f As New FormCrearCompra("ALMACEN")
            f.ComboComprobante.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton16_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton16.Click

    End Sub

    Private Sub BunifuCustomLabel11_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel11.Click
        FormLogeoNuevoIntro()
    End Sub

    Private Sub ButtonAdv13_Click(sender As Object, e As EventArgs) Handles ButtonAdv13.Click
        'Dim Form As New FormRepositoryComercial("Cierre cajero")


        'If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

        '    Dim boxUserSA As New cajaUsuarioSA
        '    Dim be As New cajaUsuario
        '    be.idEmpresa = Gempresas.IdEmpresaRuc
        '    Dim Count = boxUserSA.ListBoxClosedPendingCount(be)

        '    be.idEstablecimiento = GEstableciento.IdEstablecimiento
        '    If Count > 0 Then
        '        MessageBox.Show("Tiene Arqueo pendientes No puede Cerrar la Caja Àdministrativa")
        '        Exit Sub
        '    End If

        'End If

        Dim Form As New FormCierreXUsuario()
            Form.StartPosition = FormStartPosition.CenterScreen
            Form.ShowDialog(Me)



    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If validarPermisos(PermisosDelSistema.SALIDA_DE_INVENTARIO_, AutorizacionRolList) = 1 Then
            Dim f As New FormVentaNueva
            f.ComboComprobante.Text = "OTRA SALIDA DE ALMACEN"
            f.ComboComprobante.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ADMINISTRAR_PRECIOS__, AutorizacionRolList) Then
        If validarPermisos(PermisosDelSistema.SALIDA_DE_INVENTARIO_, AutorizacionRolList) = 1 Then
            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormExistenciaBeneficios").SingleOrDefault
            'Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormExistenciaPrecioV1").SingleOrDefault

            'If frm Is Nothing Then
            '    FormExistenciaPrecioV1 = New FormExistenciaPrecioV1
            '    FormExistenciaPrecioV1.StartPosition = FormStartPosition.CenterScreen
            '    FormExistenciaPrecioV1.Show(Me)
            'Else
            '    FormExistenciaPrecioV1.WindowState = FormWindowState.Normal
            '    FormExistenciaPrecioV1.BringToFront()
            'End If

            If frm Is Nothing Then
                FormExistenciaBeneficios = New FormExistenciaBeneficios
                FormExistenciaBeneficios.StartPosition = FormStartPosition.CenterScreen
                FormExistenciaBeneficios.Show(Me)
            Else
                FormExistenciaBeneficios.WindowState = FormWindowState.Normal
                FormExistenciaBeneficios.BringToFront()
            End If




        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        Dim f As New FormInventarioEscaso
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click

        If validarPermisos(PermisosDelSistema.VENTA_, AutorizacionRolList) = 1 Then


            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If

            If ButtonAdv5.Text = "NOTA VENTA" Then
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "NOTA DE VENTA"
                f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            Else
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "VENTA"
                f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ButtonAdv16_Click(sender As Object, e As EventArgs) Handles ButtonAdv16.Click
        Dim f As New FormVentaNueva
        f.ComboComprobante.Enabled = False
        f.ComboComprobante.Text = "PRE VENTA"
        f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub HubTile6_Click(sender As Object, e As EventArgs) Handles HubTile6.Click

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub HubTile8_Click(sender As Object, e As EventArgs) Handles HubTile8.Click
        'Dim f As New formLotesSinVerificar
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog(Me)
    End Sub

    Private Sub HubTile9_Click(sender As Object, e As EventArgs) Handles HubTile9.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim ventaSA = New documentoVentaAbarrotesSA
        Dim doc = ventaSA.GetVentaID(New documento() With {.idDocumento = 23477})


        'Dim ventaSA As New documentoVentaAbarrotesSA
        'ventaSA.ConfirmarTransferencia(New documento With
        '    {
        '    .idDocumento = 22440
        '    })
    End Sub

    Private Sub HubTile4_Click(sender As Object, e As EventArgs) Handles HubTile4.Click

    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click

        Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

        If cajaActivaGeneral Is Nothing Then
            AbrirCajaGeneral()
        End If



        If validarPermisos(PermisosDelSistema.VENTA_, AutorizacionRolList) = 1 Then


            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If


            If GconfigCaja = "2" Then

                Dim querybox = (From i In ListaCajasActivas
                                Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).FirstOrDefault

                If querybox IsNot Nothing Then
                Else
                    MessageBox.Show("Su usuario no tiene una caja aperturada")
                    Exit Sub
                End If
            End If

            If ButtonAdv5.Text = "NOTA VENTA" Then
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "NOTA DE VENTA"
                f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            Else
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "VENTA"
                f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Dim f As New FormVentaNueva
        f.ComboComprobante.Enabled = False
        f.ComboComprobante.Text = "PRE VENTA"
        f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
        f.CheckDistribucion.Checked = False
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub ButtonAdv20_Click(sender As Object, e As EventArgs) Handles ButtonAdv20.Click
        Dim form As New ComisionMaster
        form.StartPosition = FormStartPosition.CenterScreen
        form.Show()
    End Sub

    Private Sub ButtonAdv21_Click(sender As Object, e As EventArgs) Handles ButtonAdv21.Click
        If validarPermisos(PermisosDelSistema.VENTA_, AutorizacionRolList) = 1 Then



            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If

            If ButtonAdv5.Text = "NOTA VENTA" Then
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "NOTA DE VENTA"
                f.StartPosition = FormStartPosition.CenterParent
                f.CheckDistribucion.Checked = True
                f.Show(Me)
            Else
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "VENTA"
                f.CheckDistribucion.Checked = True
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            End If
        End If
    End Sub

    Private Sub ButtonAdv22_Click(sender As Object, e As EventArgs) Handles ButtonAdv22.Click
        If validarPermisos(PermisosDelSistema.VENTA_, AutorizacionRolList) = 1 Then


            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If

            If ButtonAdv5.Text = "NOTA VENTA" Then
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "NOTA DE VENTA"
                f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                f.CheckDistribucion.Checked = True
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            Else
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "VENTA"
                f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                f.CheckDistribucion.Checked = True
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv24_Click(sender As Object, e As EventArgs) Handles ButtonAdv24.Click
        Dim f As New frmCajasAbiertas
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
    End Sub

    Private Sub BunifuCustomLabel4_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel4.Click
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.CIERRE_MENSUAL_, AutorizacionRolList) Then
        'If validarPermisos(PermisosDelSistema.CIERRE_DE_PERIODO_, AutorizacionRolList) = 1 Then
        Dim f As New LinkTextBoxExt.FormOrganigramaEmpresaV2
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub HubTile11_Click(sender As Object, e As EventArgs) Handles HubTile11.Click
        Try

            If validarPermisos(PermisosDelSistema.VENTA_, AutorizacionRolList) = 1 Then

                If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                    MessageBox.Show("Debe registrar una caja para realizar la venta")
                    ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                    Exit Sub
                End If

                If GconfigCaja = "2" Then

                    Dim querybox = (From i In ListaCajasActivas
                                    Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).FirstOrDefault

                    If querybox IsNot Nothing Then
                    Else
                        MessageBox.Show("Su usuario no tiene una caja aperturada")
                        Exit Sub
                    End If
                End If
                Dim f As New FormVentaTouchDirecta
                f.GetComboSecundario()
                'f.UCEstructuraCabeceraVentaV2.PanelCenter.Size = New Size(521, 114)
                f.UCEstructuraCabeceraVentaV2.pnVEntaDirecta.Visible = True
                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Visible = False
                f.UCEstructuraCabeceraVentaV2.CargarCategorias()
                f.ComboComprobante.Text = "NOTA DE VENTA"
                'f.StartPosition = FormStartPosition.CenterScreen
                f.Show()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '// resolucion 1024 * 768
        'Try
        '    Dim cajaUsuarioSA As New cajaUsuarioSA

        '    If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
        '        MessageBox.Show("Debe registrar una caja para realizar la venta")
        '        ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
        '                                                         .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                         .estadoCaja = "A"
        '                                                         })
        '        Exit Sub
        '    End If

        '    Dim f As New FormVentaTouchDirecta1024
        '    f.GetComboSecundario()
        '    'f.UCEstructuraCabeceraVentaV2.PanelCenter.Size = New Size(521, 114)
        '    f.UCEstructuraCabeceraVentaV2.pnVEntaDirecta.Visible = True
        '    f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Visible = False
        '    f.UCEstructuraCabeceraVentaV2.CargarCategorias()
        '    f.ComboComprobante.Text = "NOTA DE VENTA"
        '    'f.StartPosition = FormStartPosition.CenterScreen
        '    f.Show()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub HtHotel_Click(sender As Object, e As EventArgs) Handles htHotel.Click
        If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
            MessageBox.Show("Debe registrar una caja para realizar la venta")
            ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
            Exit Sub
        End If

        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormControlHotel").SingleOrDefault

        If frm Is Nothing Then
            FormControlHotel = New FormControlHotel
            FormControlHotel.Show()
        Else
            FormControlHotel.WindowState = FormWindowState.Normal
            FormControlHotel.BringToFront()
        End If
    End Sub

    Private Sub HtRestaurante_Click(sender As Object, e As EventArgs) Handles htRestaurante.Click
        Try

            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If

            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormControlRestaurant").SingleOrDefault

            If frm Is Nothing Then
                FormControlRestaurant = New FormControlRestaurant
                FormControlRestaurant.Show()
            Else
                FormControlRestaurant.WindowState = FormWindowState.Normal
                FormControlRestaurant.BringToFront()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        System.Diagnostics.Process.Start("http://www.spk.com.pe")
    End Sub

    Private Sub BunifuCustomLabel5_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel5.Click
        MessageBox.Show(usuario.IDRol & usuario.nombreCargo)
    End Sub

    'Private Sub BunifuCustomLabel8_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel8.Click
    '    Dim f As New FormOrganigrama
    '    f.WindowState = FormWindowState.Normal
    '    f.Show()
    'End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click

    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click

    End Sub


#End Region


End Class
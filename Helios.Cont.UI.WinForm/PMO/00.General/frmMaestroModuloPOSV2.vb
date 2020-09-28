Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports Tulpep.NotificationWindow

Public Class frmMaestroModuloPOSV2

#Region "Attributes"
    Public Property usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
    Dim cajaUsuarioSA As New cajaUsuarioSA
    Dim entidadSA As New entidadSA
    Dim configuracionCuentasSA As New EstadosFinancierosConfiguracionPagosSA
    Private objPleaseWait As New FeedbackForm2()
    Private FormPrecios As FormExistenciaPreciosEquivalencia ' frmExistenciaPrecios
    Private TableroGeneral As frmTableroGeneral
    Private formLogistica As FormMaestroLogistica
    Private formMantenimiento As FormMantenimientoGeneral
    Private frmInformacionFinanzas As frmInformacionFinanzas
    Private formComercial As FormMaestroComercial
    Private formFinanzas As FormCajaMaestro
    Private FormMantenimientoGeneralEspecial As FormMantenimientoGeneralEspecial
    Private frmDatosGenerales As frmDatosGenerales
    Private FormConfiguracion As FormConfiguracion
    Dim i As Integer = 0
    Property totalSA As New TotalesAlmacenSA
    Public Property LightBox As HeliosLogin
    'Public Property Login As FormOrgainizacion
    Public empresaPeriodoSA As New empresaCierreMensualSA
    Public Property empresaSA As New empresaSA
    Private Property ConfiguracionInicioSA As New ConfiguracionInicioSA
    Private Property FormCajeroIndependiente As FormCajeroIndependiente
    Protected Friend conteoEnTransito As Integer = 0
    Protected Friend conteoStockMinimo As Integer = 0
    Protected Friend conteoArticulosSinPrecio As Decimal = 0
    Protected Friend conteoArticulosVencidos As Decimal = 0
    Protected Friend conteoArticulosSinAlmacen As Decimal = 0
    Protected Friend conteoTransArticulosPendientes As Decimal = 0
    Protected Friend conteoTransArticulosConfirmados As Decimal = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' FormLogeoNuevo()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Me.splashControl1.SplashControlPanel.BorderType = SplashBorderType.None
        'Me.splashControl1.ShowDialogSplash(Me)
        'Me.splashControl1.AutoMode = False

        'Me.splashControl1.HostForm = Me
    End Sub
#End Region

#Region "Methods"
    ''' <summary>
    ''' Configuración para empresas pequeñas
    ''' </summary>
    Private Sub GetConfiguracionInicioBasico()
        Dim cierreSA As New empresaCierreMensualSA
        Dim tipoCambioSA As New tipoCambioSA
        Dim configuracion As New configuracionInicio
        Dim inicio = ConfiguracionInicioSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Dim anioSA As New empresaPeriodoSA

        LinkLabel2.Visible = False
        Dim existeAnio = anioSA.GetUbicar_empresaPeriodoPorID(Gempresas.IdEmpresaRuc, Date.Now.Year, GEstableciento.IdEstablecimiento)
        If existeAnio Is Nothing Then
            Dim nuevoAnio As New empresaPeriodo With
                {
                .idEmpresa = Gempresas.IdEmpresaRuc,
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

            tipoCambioSA.InsertTC(objTC)
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

        'txtAnio.Value = New Date(existeAnio.periodo, Date.Now.Month, 1)
        'Label5.Text = "Período: " & String.Format("{0:00}", Date.Now.Month) & "/" & existeAnio.periodo
        'lblEmpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
        'Label24.Text = GEstableciento.NombreEstablecimiento
        Label15.Text = usuario.Alias

        If Gempresas.ubigeo > 0 Then 'si usa facturacion electronica
            AlertasPSE()

        End If

        'ValidandoCierre
        Dim fechaAnt = New Date(Date.Now.Year, CInt(Date.Now.Month), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
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
        CaptionLabels(1).Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc

    End Sub

    Public Sub AlertasPSE()
        Dim documentosa As New documentoVentaAbarrotesSA

        Dim consulta = documentosa.AlertaPSE(Gempresas.IdEmpresaRuc)

        Dim Cant = (consulta.CantFact + consulta.CantNotaFact + consulta.CantFactAnu +
        consulta.CantBol + consulta.CantNotaBol + consulta.CantBolAnu)



        If Cant > 0 Then
            If My.Computer.Network.IsAvailable = True Then
                'MsgBox("Tengo conexión a Internet")
                Dim f As New FrmAlertasEnvioPSE 'frmMasterFacturacionPSE

                f.lblFacturasPendientes.Text = consulta.CantFact
                f.lblNotasPendiente.Text = consulta.CantNotaFact
                f.lblFacturasAnuladas.Text = consulta.CantFactAnu

                f.lblboletaspendientes.Text = consulta.CantBol
                f.lblnotaboletas.Text = consulta.CantNotaBol
                f.LBLBOLETASELIMINADAS.Text = consulta.CantBolAnu


                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MsgBox("NO TIENE ACCESO A INTERNET !!ALERTA TIENE CPE PENDIENTES DE ENVIO")
                'MsgBox("No tengo conexión a Internet")
            End If
        End If



    End Sub

    Private Sub GetConfiguracionInicio()
        Dim tipoCambioSA As New tipoCambioSA
        Dim tipoCambioDelDia As New TipoCambioSunatV2
        Dim configuracion As New configuracionInicio

        'ultima configuracion de inicio de la empresa
        Dim f As New frmInicioEmpresaUnica(New empresa With {.idEmpresa = Gempresas.IdEmpresaRuc})
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        '  txtAnio.Value = New Date(Date.Now.Year, Date.Now.Month, 1)
        'Label5.Text = "Período: " & String.Format("{0:00}", CInt(MesGeneral)) & "/" & AnioGeneral
        CaptionLabels(1).Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
        'Label24.Text = GEstableciento.NombreEstablecimiento
        Label15.Text = usuario.Alias
    End Sub

    Private Sub FormLogeo()
        GetDeshabilitarControles()
        LightBox = New HeliosLogin
        LightBox.SetBounds(Left, Top, ClientRectangle.Width, ClientRectangle.Height)
        LightBox.Owner = Me
        LightBox.ShowDialog()

        objPleaseWait = New FeedbackForm2()
        objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        objPleaseWait.Show()
        Application.DoEvents()

        '   GetConfiguracionInicio()
        GetConfiguracionInicioBasico()

        If Not IsNothing(LightBox.Tag) Then
            If Not IsNothing(usuario) Then
                SplitButton1.BackColor = Color.FromKnownColor(KnownColor.HotTrack)
                '    DockingClientPanel1.Enabled = True
                SplitButton1.Text = usuario.Alias
            End If
            If bg.IsBusy <> True Then
                ' Start the asynchronous operation.
                bg.RunWorkerAsync()
            End If
        Else
            MatarProceso("Helios.Cont.Presentation.WinForm")
            MatarProceso("SMSvcHost.exe")
            Application.ExitThread()
            Close()
        End If
    End Sub

    Private Sub FormLogeoNuevo()
        GetDeshabilitarControles()
        'Dim Login As New FormOrgainizacion
        'Login.StartPosition = FormStartPosition.CenterParent
        'Login.ShowDialog(Me)

        objPleaseWait = New FeedbackForm2()
        objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        objPleaseWait.Show()
        Application.DoEvents()

        '   GetConfiguracionInicio()
        GetConfiguracionInicioBasico()


        If Not IsNothing(usuario) Then
            SplitButton1.BackColor = Color.FromKnownColor(KnownColor.HotTrack)
            '    DockingClientPanel1.Enabled = True
            SplitButton1.Text = usuario.Alias
        End If
        If bg.IsBusy <> True Then
            ' Start the asynchronous operation.
            bg.RunWorkerAsync()
        End If

    End Sub

    Private Sub FormLogeoNuevoIntro()
        GetDeshabilitarControles()
        Dim Login As New FormOrgainizacion
        Login.StartPosition = FormStartPosition.CenterParent
        Login.ShowDialog(Me)

        objPleaseWait = New FeedbackForm2()
        objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        objPleaseWait.Show()
        Application.DoEvents()

        '   GetConfiguracionInicio()
        GetConfiguracionInicioBasico()


        If Not IsNothing(usuario) Then
            SplitButton1.BackColor = Color.FromKnownColor(KnownColor.HotTrack)
            '    DockingClientPanel1.Enabled = True
            SplitButton1.Text = usuario.Alias
        End If
        If bg.IsBusy <> True Then
            ' Start the asynchronous operation.
            bg.RunWorkerAsync()
        End If

    End Sub

    Private Sub GetDeshabilitarControles()
        BannerTile.Enabled = False
        HubTile3.Enabled = False
        hubTile1.Enabled = False
        hubTile2.Enabled = False
        ButtonAdv2.Enabled = False
        ButtonAdv3.Enabled = False
        ButtonAdv4.Enabled = False
        ButtonAdv5.Enabled = False
        ButtonAdv17.Enabled = False
        ButtonAdv1.Enabled = False
    End Sub

    Private Sub GetHabilitarControles()
        BannerTile.Enabled = True
        HubTile3.Enabled = True
        hubTile1.Enabled = True
        hubTile2.Enabled = True
        ButtonAdv2.Enabled = True
        ButtonAdv3.Enabled = True
        ButtonAdv4.Enabled = True
        ButtonAdv5.Enabled = True
        ButtonAdv17.Enabled = True
        ButtonAdv1.Enabled = True
        'ButtonAdv1.Visible = True
    End Sub

    Sub Inicio()
        usuario = New AutenticacionUsuario
        usuario.CustomUsuario = New Usuario
        Dim LightBox As New HeliosLogin
        LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
        LightBox.Owner = Me
        LightBox.ShowDialog()

        If Not IsNothing(usuario) Then
            ' SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
            SplitButton1.BackColor = Color.FromKnownColor(KnownColor.HotTrack)
            '  DockingClientPanel1.Enabled = True
            SplitButton1.Text = usuario.Alias

            Select Case (LightBox.empresaSPK.FirstOrDefault.TieneCaja)
                Case True
                    CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)
                Case False
                    Dim init As New frmInicioEmpresa
                    init.StartPosition = FormStartPosition.CenterParent
                    init.ShowDialog()
            End Select

            '       Label24.Text = GEstableciento.NombreEstablecimiento


        Else
            SplitButton1.BackColor = Color.FromKnownColor(KnownColor.HotTrack)
            SplitButton1.Text = "Usuario"
            '    DockingClientPanel1.Enabled = False
            MessageBox.Show("Usario o clave incorrectos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Private Function MatarProceso(ByVal StrNombreProceso As String,
    Optional ByVal DecirSINO As Boolean = True) As Boolean
        ' Variables para usar Wmi  
        Dim ListaProcesos As Object
        Dim ObjetoWMI As Object
        Dim ProcesoACerrar As Object

        MatarProceso = False

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
                        MatarProceso = True
                        '  End If
                    Else
                        'Matamos el proceso con el método Terminate  
                        ProcesoACerrar.Terminate(0)
                        MatarProceso = True
                    End If
                End If

            Next
        End If

        'Elimina las variables  
        ListaProcesos = Nothing
        ObjetoWMI = Nothing
    End Function

    Private Function GetCountExistenciaTransito() As Integer
        Dim compraSA As New DocumentoCompraSA


        'Return compraSA.GetCountExistenciaTransito(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                                               .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                               .tipoCompra = TIPO_COMPRA.COMPRA})

        Return compraSA.GetCountExistenciaTransito(New documentocompra With {
                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                 .StatusEntregaProductosTransito = "1"})

    End Function

    Public Sub GetTransitoConteoTransferencia()
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim documentocompra = New List(Of documentocompra)
        documentocompra = DocumentoCompraSA.GetTransferenciasByEmpresa(GEstableciento.IdEstablecimiento)
        Dim i = (From a In documentocompra Where a.estadoEntrega = "PN").Count
        Dim x = (From a In documentocompra Where a.estadoEntrega = "DC").Count

        conteoTransArticulosPendientes = i
        conteoTransArticulosConfirmados = x

        'If i > 0 Then
        '    notify = New PopupNotifier
        '    notify.Image = ImageList1.Images(0)
        '    notify.TitleFont = New Font("Century Gothic", 10, FontStyle.Bold)
        '    notify.BorderColor = Color.FromKnownColor(KnownColor.HotTrack)
        '    notify.HeaderColor = Color.FromKnownColor(KnownColor.HotTrack)

        '    notify.TitleColor = Color.FromKnownColor(KnownColor.HotTrack)
        '    notify.TitleText = "ARTICULOS EN TRANSITO"
        '    notify.TitleFont = New Font("Century Gothic", 10, FontStyle.Bold)

        '    notify.BodyColor = Color.LavenderBlush
        '    notify.BorderColor = Color.FromArgb(75, 164, 249)

        '    notify.ContentText = "{" & i.ToString & "}" & " ARTICULOS PENDIENTES DE ENVIO A ALMACÉN"
        '    notify.ContentFont = New Font("Century Gothic", 9)
        '    notify.ContentColor = Color.Black
        '    notify.Popup()
        'End If

    End Sub

    Public Function GetInventarioEnAlertaConteo(be As totalesAlmacen) As Integer
        Return totalSA.GetAlertaIventarioMinimoConteo(be)
    End Function

    Private Sub GetUsuariosSoftpack()
        Dim usuariosSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
        Seguridad.General.ListaUsuariosSoftpack = usuariosSA.GetListaUsuarios()
    End Sub

    Private Sub GetConfiguracionpagos()
        Dim pagoSA As New EstadosFinancierosConfiguracionPagosSA

        ListConfigurationPays = New List(Of estadosFinancierosConfiguracionPagos)
        ListConfigurationPays = pagoSA.GetConfigurationPay(New estadosFinancierosConfiguracionPagos With
                {
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                                                           })

    End Sub

    Private Sub GetAlertas()
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        Dim productoSA As New detalleitemsSA
        conteoEnTransito = GetCountExistenciaTransito()
        ' conteoStockMinimo = GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        conteoArticulosSinPrecio = ConteoProductosSinPrecio()
        conteoArticulosVencidos = TotalesAlmacenSA.GetProductosXvencerMesCount(Gempresas.IdEmpresaRuc, DateTime.Now.Year, DateTime.Now.Month)
        Dim contar = productoSA.GetArticulosSinAlmacen(Gempresas.IdEmpresaRuc, 2)
        conteoArticulosSinAlmacen = contar(0).capacidad
    End Sub

    Public Function ConteoProductosSinPrecio() As Integer
        Dim totales As New List(Of totalesAlmacen)
        totales = totalSA.NumProductosSinListaPrecio(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento})

        Return totales.Count
    End Function

    Private Sub GrabarConfiInicio()
        Dim config As New configuracionInicio
        Dim existe As New configuracionInicio
        Dim configsa As New ConfiguracionInicioSA
        With config
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .idalmacenVenta = TmpIdAlmacen
            .anio = CStr(DateTime.Now.Year)
            .mes = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month))
            .dia = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            .periodo = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month)) & "/" & DateTime.Now.Year
            .tipocambio = TmpTipoCambio
            .iva = TmpIGV
            .tipoIva = TmpTipoIVA
            .retencion4ta = TmpRetencion4

            existe = configsa.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

            If Not IsNothing(existe) Then
                configsa.EditarConfigInicio(config)
            Else
                'configsa.InsertConfigInicio(config)
            End If

            AnioGeneral = CStr(DateTime.Now.Year)
            MesGeneral = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month))
            DiaLaboral = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month)) & "/" & DateTime.Now.Year

        End With
    End Sub

    Private Sub GetAlertaCompleted()
        'dgvLogistica.Table.Records(3).SetValue("info", conteoEnTransito)
        'dgvLogistica.Table.Records(2).SetValue("info", conteoTransArticulosConfirmados)
        'dgvLogistica.Table.Records(4).SetValue("info", conteoTransArticulosPendientes)

        If conteoEnTransito > 0 Then
            AlertProductTransito.Text = conteoEnTransito
            AlertProductTransito.Image = ImageListAlertas.Images(3)

            Dim notify As New PopupNotifier
            notify.Image = ImageList1.Images(0)
            notify.TitleFont = New Font("Century Gothic", 10, FontStyle.Bold)
            notify.BorderColor = Color.FromKnownColor(KnownColor.HotTrack)
            notify.HeaderColor = Color.FromKnownColor(KnownColor.HotTrack)

            notify.TitleColor = Color.FromKnownColor(KnownColor.HotTrack)
            notify.TitleText = "ARTICULOS EN TRANSITO"
            notify.TitleFont = New Font("Century Gothic", 10, FontStyle.Bold)

            notify.BodyColor = Color.LavenderBlush
            notify.BorderColor = Color.FromArgb(75, 164, 249)

            If conteoEnTransito = 1 Then
                notify.ContentText = "{" & conteoEnTransito.ToString & "}" & " ARTICULO PENDIENTE DE ENVIO A ALMACÉN"
            Else
                notify.ContentText = "{" & conteoEnTransito.ToString & "}" & " ARTICULOS PENDIENTES DE ENVIO A ALMACÉN"
            End If
            notify.ContentFont = New Font("Century Gothic", 9)
            notify.ContentColor = Color.Black
            notify.Delay = 10000
            notify.Popup()
        Else
            AlertProductTransito.Text = 0
            AlertProductTransito.Image = ImageListAlertas.Images(2)
        End If
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

    Public Sub CargarConfiguracionInicioUsuariosDeCaja(strIdEmpresa As String)
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio
        Dim estableSA As New establecimientoSA
        Dim almaceSa As New almacenSA
        Dim cierreCajaSA As New CierreCajaSA
        Dim cierreInventarioSA As New CierreInventarioSA
        config = configSA.ObtenerConfigXempresa(strIdEmpresa, GEstableciento.IdEstablecimiento)

        If Not IsNothing(config) Then
            With config
                GEstableciento = New GEstablecimiento
                GEstableciento.IdEstablecimiento = .idCentroCosto
                GEstableciento.NombreEstablecimiento = estableSA.UbicaEstablecimientoPorID(.idCentroCosto).nombre
                Dim nomEmpresa = "EMR NEGOCIOS SAC." ' lblEstablecimiento.Text ' Gempresas.NomEmpresa
                Gempresas = New GEmpresa
                Gempresas.IdEmpresaRuc = CStr(strIdEmpresa).Trim
                Gempresas.NomEmpresa = nomEmpresa
                'TmpNombreAlmacen = almaceSa.GetUbicar_almacenPorID(.idalmacenVenta).descripcionAlmacen
                AnioGeneral = .anio
                MesGeneral = .mes
                DiaLaboral = .dia
                PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(.mes)) & "/" & .anio
                TmpTipoCambio = .tipocambio
                TmpIGV = .iva
                TmpTipoIVA = .tipoIva
                TmpRetencion4 = .retencion4ta.GetValueOrDefault
            End With
        End If
    End Sub

    Private Sub SplitButton1_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles SplitButton1.DropDowItemClicked
        Try
            Select Case e.ClickedItem.Text
                Case "Iniciar Sesion", "Cerrar Sesion"
                    FormLogeoNuevoIntro()
            End Select
            'Select Case e.ClickedItem.Text
            '    Case "Iniciar Sesion"
            '        '   Inicio()
            '        FormLogeo()
            '    Case "Cerrar Sesion"
            '        '    SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
            '        SplitButton1.BackColor = Color.FromKnownColor(KnownColor.HotTrack)
            '        SplitButton1.Text = "Usuario"
            '        '    DockingClientPanel1.Enabled = False
            '        '   Inicio()
            '        FormLogeo()
            'End Select
            'CaptionLabels(1).Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            '   Label5.Text = PeriodoGeneral
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'FormLogeo()
            FormLogeoNuevo()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i += 1000
        If i = 1000 Then
            i = 0
            Timer1.Stop()
            FormLogeoNuevo()
            'FormLogeo()
        End If
        Panel1.Enabled = True
    End Sub

    Private Sub frmMaestroModuloPOSV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)
        Me.SplitButton1.Style = Syncfusion.Windows.Forms.Tools.SplitButtonVisualStyle.Metro
        Me.SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
        Me.WindowState = FormWindowState.Normal
        Timer1.Enabled = True
        TmpProduccionPorLotes = True
        ' bunifuElipse1.ElipseRadius = 22
    End Sub

    Private Sub BannerTile_Click(sender As Object, e As EventArgs) Handles BannerTile.Click
        Me.Cursor = Cursors.WaitCursor

        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.PANEL_LOGISTICA__, AutorizacionRolList) Then
            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormMaestroLogistica").SingleOrDefault
            If frm Is Nothing Then
                formLogistica = New FormMaestroLogistica
                formLogistica.StartPosition = FormStartPosition.CenterScreen
                formLogistica.Show(Me)
            Else
                formLogistica.WindowState = FormWindowState.Normal
                formLogistica.BringToFront()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile3_Click(sender As Object, e As EventArgs) Handles HubTile3.Click
        Me.Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.PANEL_COMERCIAL__, AutorizacionRolList) Then
            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormMaestroComercial").SingleOrDefault
            If frm Is Nothing Then
                formComercial = New FormMaestroComercial
                formComercial.StartPosition = FormStartPosition.CenterScreen
                formComercial.Show(Me)
            Else
                formComercial.WindowState = FormWindowState.Normal
                formComercial.BringToFront()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub hubTile1_Click(sender As Object, e As EventArgs) Handles hubTile1.Click
        Me.Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.PANEL_FINANZAS__, AutorizacionRolList) Then
            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormCajaMaestro").SingleOrDefault
            If frm Is Nothing Then
                formFinanzas = New FormCajaMaestro
                formFinanzas.StartPosition = FormStartPosition.CenterScreen
                formFinanzas.Show(Me)
            Else
                formFinanzas.WindowState = FormWindowState.Normal
                formFinanzas.BringToFront()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.RESUMEN_DIARIO__, AutorizacionRolList) Then
        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "frmTableroGeneral").SingleOrDefault
        If frm Is Nothing Then
            'TableroGeneral = New frmTableroGeneral
            'TableroGeneral.StartPosition = FormStartPosition.CenterScreen
            'TableroGeneral.Show(Me)
            frmInformacionFinanzas = New frmInformacionFinanzas
            frmInformacionFinanzas.StartPosition = FormStartPosition.CenterScreen
            frmInformacionFinanzas.Show(Me)
        Else
            TableroGeneral.WindowState = FormWindowState.Normal
            TableroGeneral.BringToFront()
        End If
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.CONFIGURACION_VARIABLES_GLOBALES__, AutorizacionRolList) Then
            Dim f As New frmInicioEmpresaVariablesGlobales
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Cursor = Cursors.WaitCursor

        '     If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ENTREGA_DE_INVENTARIO__, AutorizacionRolList) Then
        Dim f As New FormConfiguracionPago
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        'Dim FormPreparacionArticulosVenta = New FormPreparacionArticulosVenta
        'FormPreparacionArticulosVenta.StartPosition = FormStartPosition.CenterScreen
        'FormPreparacionArticulosVenta.Show(Me)
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv17_Click(sender As Object, e As EventArgs) Handles ButtonAdv17.Click
        Cursor = Cursors.WaitCursor
        Dim cierreSA As New empresaCierreMensualSA
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.CAJA_CENTRALIZADA__, AutorizacionRolList) Then

            'Dim fechaAnt = DateTime.Now
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    End If
            'End If

            'Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)

            'Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)


            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormCajeroIndependiente").SingleOrDefault
            If frm Is Nothing Then
                Dim cajaUsuario = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                    FormCajeroIndependiente = New FormCajeroIndependiente
                    FormCajeroIndependiente.StartPosition = FormStartPosition.CenterParent
                    FormCajeroIndependiente.Show(Me)
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                FormCajeroIndependiente.WindowState = FormWindowState.Normal
                FormCajeroIndependiente.BringToFront()
            End If

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim f As New FormVentaVendedorGeneral 'FormVendedorConStock
        f.chPedido.Checked = True
        f.TextComprador.Clear()
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show(Me)

        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.COTIZACION_PROFORMA_Formulario___, AutorizacionRolList) Then
        '    Dim f As New FormVentaNuevoPosV2 'frmVentaNuevoPOS
        '    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
        '    f.StartPosition = FormStartPosition.CenterScreen
        '    f.Show(Me)
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cierreSA As New empresaCierreMensualSA
        Try

            Dim f As New FormVentaNueva
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)

            '   If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.VENTA_ELECTRONICAS_SI_Formulario___, AutorizacionRolList) Then
            'Dim fechaAnt = DateTime.Now
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    End If
            'End If


            'Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            'Dim cajaUsuario = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault

            'If Not IsNothing(cajaUsuario) Then
            '    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

            '    'Dim f As New FormVentaVendedorGeneral 'FormVendedorConStock
            '    'f.chPedido.Checked = False
            '    'f.TextComprador.Text = "VARIOS"
            '    'f.StartPosition = FormStartPosition.CenterScreen
            '    '    f.Show(Me)
            '    'Else
            '    '    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    'End If
            '    'Else
            '    '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
        'Dim cajaUsuarioSA As New cajaUsuarioSA
        'Dim cierreSA As New empresaCierreMensualSA
        'Try
        '    Dim fechaAnt = DateTime.Now
        '    fechaAnt = fechaAnt.AddMonths(-1)
        '    Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        '    If periodoAnteriorEstaCerrado = False Then
        '        MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
        '        Cursor = Cursors.Default
        '        Exit Sub
        '    End If

        '    Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
        '    If Not IsNothing(valida) Then
        '        If valida = True Then
        '            MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        End If
        '    End If

        '    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
        '    If Not IsNothing(cajaUsuario) Then
        '        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

        '        Dim f As New FormVentaGeneral ' frmVentaNuevoFormato
        '        f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
        '        f.StartPosition = FormStartPosition.CenterScreen
        '        ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '        f.Show(Me)
        '    Else
        '        MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Try
            'Dim fechaAnt = DateTime.Now
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Cursor = Cursors.Default
            '        Exit Sub
            '    End If
            'End If
            Me.Cursor = Cursors.WaitCursor

            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_COMPRA_Formulario___, AutorizacionRolList) Then
                'Dim f As New FormCrearCompra()
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog(Me)
                'Dim f As New FormCompras
                'f.ComboBoxAdv2.Visible = False
                'f.CaptionLabels(0).Text = "Compra al crédito"
                'f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
                'f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
                'f.cboMesCompra.Enabled = True
                ''   f.txtDia.Value = DateTime.Now
                'f.StartPosition = FormStartPosition.CenterScreen
                'f.WindowState = FormWindowState.Normal
                'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                'f.Show(Me)

            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ABRIR_CAJA_Formulario___, AutorizacionRolList) Then
            Dim f As New FormCrearCajero
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ADMINISTRAR_PRECIOS__, AutorizacionRolList) Then
            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormExistenciaPreciosEquivalencia").SingleOrDefault
            If frm Is Nothing Then
                FormPrecios = New FormExistenciaPreciosEquivalencia
                FormPrecios.StartPosition = FormStartPosition.CenterScreen
                FormPrecios.Show(Me)
            Else
                FormPrecios.WindowState = FormWindowState.Normal
                FormPrecios.BringToFront()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub BtDashBoard_Click(sender As Object, e As EventArgs) Handles BtDashBoard.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ADMINISTRAR_CIERRES__, AutorizacionRolList) Then
            Dim f As New frmselectCierre
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub bg_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bg.DoWork
        VarClienteGeneral = entidadSA.UbicarEntidadVarios("VR", General.Gempresas.IdEmpresaRuc, String.Empty, GEstableciento.IdEstablecimiento)
        ListaCuentasFinancierasConfiguradas = configuracionCuentasSA.GetConfigurationPay(New estadosFinancierosConfiguracionPagos With
                                             {
                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                             .idEstablecimiento = GEstableciento.IdEstablecimiento
                                             })
        UsuariosList = usuarioListSA.ListadoUsuariosv2()
        ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
        GetAlertas()
        GetConfiguracionpagos()
        GetTransitoConteoTransferencia()
        GetUsuariosSoftpack()
    End Sub

    Private Sub bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted
        GetAlertaCompleted()
        If conteoArticulosVencidos > 0 Then
            AlertProductXvencer.Text = conteoArticulosVencidos
            AlertProductXvencer.Image = ImageListAlertas.Images(1)
        Else
            AlertProductXvencer.Text = 0
            AlertProductXvencer.Image = ImageListAlertas.Images(0)
            'Dim frm As New frmAlertForm
            'frm.StartPosition = FormStartPosition.CenterParent
            'frm.ShowDialog()
        End If

        If conteoTransArticulosPendientes > 0 Then
            AlertProductTrasnfer.Text = conteoTransArticulosPendientes
            AlertProductTrasnfer.Image = ImageListAlertas.Images(5)
        Else
            AlertProductTrasnfer.Text = 0
            AlertProductTrasnfer.Image = ImageListAlertas.Images(4)
        End If

        If conteoArticulosSinAlmacen > 0 Then
            LabelArticulosSinAlmacen.Text = conteoArticulosSinAlmacen
        Else
            LabelArticulosSinAlmacen.Text = 0
        End If

        GetHabilitarControles()
        objPleaseWait.Close()
    End Sub

    Private Sub frmMaestroModuloPOSV2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

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

    Private Sub AlertProductXvencer_Click(sender As Object, e As EventArgs) Handles AlertProductXvencer.Click
        If conteoArticulosVencidos > 0 Then
            Dim frm As New frmAlertForm
            frm.StartPosition = FormStartPosition.CenterParent
            frm.ShowDialog(Me)
        End If
    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.USUARIOS_DEL_SISTEMA__, AutorizacionRolList) Then
            Dim f As New FormMaestroUsuarios 'frmMaestroSistemaUsers
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub AlertProductTransito_Click(sender As Object, e As EventArgs) Handles AlertProductTransito.Click
        If conteoEnTransito > 0 Then
            Dim f As New frmExistenciasEnTransito
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.CENTRAL_DE_REPORTES__, AutorizacionRolList) Then
            Dim F As New frmMasterModelReportePOS
            F.StartPosition = FormStartPosition.CenterParent
            F.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub hubTile2_Click(sender As Object, e As EventArgs) Handles hubTile2.Click
        Me.Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.PANEL_MANTENIMIENTO_DEL_SISTEMA__, AutorizacionRolList) Then
            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormMantenimientoGeneral").SingleOrDefault
            If frm Is Nothing Then
                formMantenimiento = New FormMantenimientoGeneral
                formMantenimiento.StartPosition = FormStartPosition.CenterScreen
                formMantenimiento.Show(Me)
            Else
                formMantenimiento.WindowState = FormWindowState.Normal
                formMantenimiento.BringToFront()
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.FACTURACION_ELECTRONICA___, AutorizacionRolList) Then
            Dim f As New frmMasterFacturacionPSE
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        'Dim f As New FormMantenimientoComprasRapidas
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()


        'Dim f As New frmMasterFacturacionPSE
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()

        Dim f As New FormCuentasPagarAnalisis
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        'Dim cajaUsuarioSA As New cajaUsuarioSA
        'Dim cierreSA As New empresaCierreMensualSA
        'Try
        '    Dim fechaAnt = DateTime.Now
        '    fechaAnt = fechaAnt.AddMonths(-1)
        '    Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        '    If periodoAnteriorEstaCerrado = False Then
        '        MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
        '        Cursor = Cursors.Default
        '        Exit Sub
        '    End If

        '    Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = DateTime.Now.Year, .mes = DateTime.Now.Month})
        '    If Not IsNothing(valida) Then
        '        If valida = True Then
        '            MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        End If
        '    End If

        '    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
        '    If Not IsNothing(cajaUsuario) Then
        '        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

        '        Dim f As New FormVentaGeneralServ  ' frmVentaNuevoFormato
        '        f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
        '        f.StartPosition = FormStartPosition.CenterScreen
        '        ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '        f.Show(Me)
        '    Else
        '        MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'Cursor = Cursors.Default
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.CAJA_CENTRALIZADA_Sin_inventario___, AutorizacionRolList) Then
            Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                Dim f As New frmPedidoPendienteEspecial
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            Else
                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Dim FormPruebaFact As New FormVentaVendedorGeneral ' FormPruebaFact
        FormPruebaFact.StartPosition = FormStartPosition.CenterParent
        FormPruebaFact.ShowDialog()
        'FormMantenimientoGeneralEspecial = New FormMantenimientoGeneralEspecial
        'FormMantenimientoGeneralEspecial.StartPosition = FormStartPosition.CenterScreen
        'FormMantenimientoGeneralEspecial.Show(Me)
    End Sub

    Private Sub Panel7_Click(sender As Object, e As EventArgs) Handles Panel7.Click
        FormConfiguracion = New FormConfiguracion
        FormConfiguracion.StartPosition = FormStartPosition.CenterScreen
        FormConfiguracion.Show(Me)
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles LabelArticulosSinAlmacen.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim f As New FormExistenciasSinAlamcen
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            bg.RunWorkerAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub frmMaestroModuloPOSV2_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmMaestroModuloPOSV2_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub SplitButton1_Click(sender As Object, e As EventArgs) Handles SplitButton1.Click

    End Sub

#End Region

End Class
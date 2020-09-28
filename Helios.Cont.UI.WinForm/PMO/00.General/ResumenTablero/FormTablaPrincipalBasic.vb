Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class FormTablaPrincipalBasic


#Region "Variables"

    Public Property tiempo As Integer = 0
    Public Property ConfiguracionInicioSA As New ConfiguracionInicioSA
    Public Property cajaUsuarioSA As New cajaUsuarioSA
    Public Property entidadSA As New entidadSA

    Private datosSA As New datosGeneralesSA
    Public Property usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
    Private Property UCPrincipalVentas As UCPrincipalVentas
    Private Property UCPrincipalCompras As UCPrincipalCompras
    Private Property UCPrincipalProductos As UCPrincipalProductos
    Private Property UCPrincipalUsuarios As UCPrincipalUsuarios
    Private Property UCPrincipalKaredex As UCPrincipalKardex
    Private Property UCPrincipalFinanzas As UCPrincipalFinanzas
    Private Property UCPrincipalCajaAdministrativa As UCPrincipalCajaAdministrativa
    Private Property UCPrincipalCajaPos As UCPrincipalCajaPos
    Private Property UCPrincipalSistema As UCPrincipalSistema

    Private Property UCPrincipalProveedores As UCPrincipalProveedores
    Private Property UCPrincipalClientes As UCPrincipalClientes

    Private Property UCPrincipalReportes As UCPrincipalReportes
    Private Property UCPrincipalAlmacenes As UCPrincipalAlmacenes

    Public Property listaInventario As List(Of totalesAlmacen)
#End Region

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'BunifuFlatButton1.selected = True



        UCPrincipalVentas = New UCPrincipalVentas With {.Dock = DockStyle.Fill, .Visible = False}
        UCPrincipalCompras = New UCPrincipalCompras With {.Dock = DockStyle.Fill, .Visible = False}
        UCPrincipalProductos = New UCPrincipalProductos With {.Dock = DockStyle.Fill, .Visible = False}
        'UCPrincipalUsuarios = New UCPrincipalUsuarios With {.Dock = DockStyle.Fill, .Visible = False}
        'UCPrincipalFinanzas = New UCPrincipalFinanzas With {.Dock = DockStyle.Fill, .Visible = False}
        UCPrincipalKaredex = New UCPrincipalKardex With {.Dock = DockStyle.Fill, .Visible = False}
        'UCPrincipalSistema = New UCPrincipalSistema With {.Dock = DockStyle.Fill, .Visible = False}
        'UCPrincipalCajaAdministrativa = New UCPrincipalCajaAdministrativa With {.Dock = DockStyle.Fill, .Visible = False}
        'UCPrincipalCajaPos = New UCPrincipalCajaPos With {.Dock = DockStyle.Fill, .Visible = False}
        'UCPrincipalProveedores = New UCPrincipalProveedores With {.Dock = DockStyle.Fill, .Visible = False}
        'UCPrincipalClientes = New UCPrincipalClientes With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCPrincipalVentas)
        PanelBody.Controls.Add(UCPrincipalCompras)
        PanelBody.Controls.Add(UCPrincipalProductos)
        'PanelBody.Controls.Add(UCPrincipalUsuarios)
        'PanelBody.Controls.Add(UCPrincipalFinanzas)
        PanelBody.Controls.Add(UCPrincipalKaredex)
        'PanelBody.Controls.Add(UCPrincipalSistema)
        'PanelBody.Controls.Add(UCPrincipalCajaAdministrativa)
        'PanelBody.Controls.Add(UCPrincipalCajaPos)
        'PanelBody.Controls.Add(UCPrincipalProveedores)
        'PanelBody.Controls.Add(UCPrincipalClientes)




    End Sub

#Region "Metodos"

    Public Sub OcultarTodos()
        If UCPrincipalProductos IsNot Nothing Then
            UCPrincipalProductos.Visible = False
        End If
        If UCPrincipalCompras IsNot Nothing Then
            UCPrincipalCompras.Visible = False
        End If
        If UCPrincipalVentas IsNot Nothing Then
            UCPrincipalVentas.Visible = False
        End If
        If UCPrincipalUsuarios IsNot Nothing Then
            UCPrincipalUsuarios.Visible = False
        End If
        If UCPrincipalKaredex IsNot Nothing Then
            UCPrincipalKaredex.Visible = False
        End If
        If UCPrincipalFinanzas IsNot Nothing Then
            UCPrincipalFinanzas.Visible = False
        End If
        If UCPrincipalSistema IsNot Nothing Then
            UCPrincipalSistema.Visible = False
        End If
        If UCPrincipalCajaAdministrativa IsNot Nothing Then
            UCPrincipalCajaAdministrativa.Visible = False
        End If
        If UCPrincipalClientes IsNot Nothing Then
            UCPrincipalClientes.Visible = False
        End If
        If UCPrincipalProveedores IsNot Nothing Then
            UCPrincipalProveedores.Visible = False
        End If
        If UCPrincipalCajaPos IsNot Nothing Then
            UCPrincipalCajaPos.Visible = False
        End If
        If UCPrincipalAlmacenes IsNot Nothing Then
            UCPrincipalAlmacenes.Visible = False
        End If
        If UCPrincipalReportes IsNot Nothing Then
            UCPrincipalReportes.Visible = False
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
    Private Sub FormLogeoNuevoIntro()
        Me.Dispose()
        Dim Login As New FormOrgainizacionV2
        Login.StartPosition = FormStartPosition.CenterParent
        Login.ShowDialog()
        Application.DoEvents()
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

    Public Sub LogeoUsuarioCaja()
        Try
            Dim usuarioSel = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).FirstOrDefault
            If usuarioSel IsNot Nothing Then
                lblNombreUsuario.Text = usuarioSel.Nombres
                lblNombreUsuario.Tag = usuarioSel.IDUsuario
                'BunifuFlatButton5.Text = usuario.nombreCargo
                If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then
                    btnCaja.Text = "  Caja"
                    Dim cajaAdmi = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL And o.estadoCaja = "A").SingleOrDefault
                    If cajaAdmi IsNot Nothing Then
                        lblEstadoCaja.Text = "Caja Abierta"

                    End If
                ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then
                    btnCaja.Text = "  Caja Pos"
                    Dim cajaPos = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault
                    If cajaPos IsNot Nothing Then
                        lblEstadoCaja.Text = "Caja Abierta"

                    End If
                End If
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

    Private Sub FormLogeoNuevo()
        Application.DoEvents()
        GetConfiguracionInicioBasico()
        If bg.IsBusy <> True Then
            bg.RunWorkerAsync()
        End If
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

            'LabelUsuario.Text = "USUARIO:" & vbCrLf & usuario.Alias
            Select Case tmpConfigInicio.FormatoVenta
                Case "FACT"

                Case "FACSV"

                Case Else

            End Select

            consultaConf = centroCostosConfSA.GetListaNegociosDisponibles(New centroCostosXNComercial With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region


    Private Sub FormTablaPrincipalBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnDashBoard.selected = True
        Timer1.Enabled = True
    End Sub

    Private Sub bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted
        If ListaCajasActivas IsNot Nothing Then
            If ListaCajasActivas.Count > 0 Then
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
                End If
            End If
            Dim cajaActiva = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault
            If cajaActiva Is Nothing Then
                AbrirCajaGeneral()
            End If
        End If

        'GetStockEscaso()
        LogeoUsuarioCaja()
        lblEmpresa.Text = Gempresas.NomEmpresa.ToLower
        lblUnidadNegocio.Text = GEstableciento.NombreEstablecimiento.ToLower
        PictureLoading.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tiempo += 1000
        If tiempo = 1000 Then
            tiempo = 0
            Timer1.Stop()
            FormLogeoNuevo()
        End If
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        If PanelMenu.Width = 150 Then
            PanelMenu.Width = 40
        ElseIf PanelMenu.Width = 40 Then
            PanelMenu.Width = 150
        End If
    End Sub

    Private Sub btnDashBoard_Click(sender As Object, e As EventArgs) Handles btnDashBoard.Click, btnProductos.Click, btnVenta.Click, btnClientes.Click, btnCompras.Click, btnProveedores.Click, btnKardex.Click, btnFinanzas.Click, btnCaja.Click, btnSistema.Click, btnUsuarios.Click, btnReportes.Click, btnAlmacenes.Click

        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "  Inicio"
                OcultarTodos()
            Case "  Productos"
                If validarPermisos(PermisosDelSistema.GESTION_DE_PRECIOS_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalProductos IsNot Nothing Then
                        UCPrincipalProductos.Visible = True
                        UCPrincipalProductos.BringToFront()
                        UCPrincipalProductos.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "  Venta"
                If validarPermisos(PermisosDelSistema.COMERCIAL_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalVentas IsNot Nothing Then
                        UCPrincipalVentas.Visible = True
                        UCPrincipalVentas.BringToFront()
                        UCPrincipalVentas.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "  Clientes"
                If validarPermisos(PermisosDelSistema.CLIENTES_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalClientes IsNot Nothing Then
                        UCPrincipalClientes.Visible = True
                        UCPrincipalClientes.BringToFront()
                        UCPrincipalClientes.Show()
                    Else
                        UCPrincipalClientes = New UCPrincipalClientes With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCPrincipalClientes)
                        UCPrincipalClientes.Visible = True
                        UCPrincipalClientes.BringToFront()
                        UCPrincipalClientes.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "  Proveedores"
                If validarPermisos(PermisosDelSistema.PROVEEDORES_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalProveedores IsNot Nothing Then
                        UCPrincipalProveedores.Visible = True
                        UCPrincipalProveedores.BringToFront()
                        UCPrincipalProveedores.Show()
                    Else
                        UCPrincipalProveedores = New UCPrincipalProveedores With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCPrincipalProveedores)
                        UCPrincipalProveedores.Visible = True
                        UCPrincipalProveedores.BringToFront()
                        UCPrincipalProveedores.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "  Compra"
                If validarPermisos(PermisosDelSistema.LOGISTICA_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalCompras IsNot Nothing Then
                        UCPrincipalCompras.Visible = True
                        UCPrincipalCompras.BringToFront()
                        UCPrincipalCompras.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "  Usuarios"
                If validarPermisos(PermisosDelSistema.MODULO_DE_USUARIOS_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalUsuarios IsNot Nothing Then
                        UCPrincipalUsuarios.Visible = True
                        UCPrincipalUsuarios.BringToFront()
                        UCPrincipalUsuarios.Show()
                    Else
                        UCPrincipalUsuarios = New UCPrincipalUsuarios With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCPrincipalUsuarios)
                        UCPrincipalUsuarios.Visible = True
                        UCPrincipalUsuarios.BringToFront()
                        UCPrincipalUsuarios.Show()
                    End If
                ElseIf (usuario.nombreCargo = "SUPER_ADMINISTRADOR") Then
                    OcultarTodos()
                    If UCPrincipalUsuarios IsNot Nothing Then
                        UCPrincipalUsuarios.Visible = True
                        UCPrincipalUsuarios.BringToFront()
                        UCPrincipalUsuarios.Show()
                    Else
                        UCPrincipalUsuarios = New UCPrincipalUsuarios With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCPrincipalUsuarios)
                        UCPrincipalUsuarios.Visible = True
                        UCPrincipalUsuarios.BringToFront()
                        UCPrincipalUsuarios.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "  Sistema"
                If validarPermisos(PermisosDelSistema.MODULO_DE_MANTENIMIENTO_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalSistema IsNot Nothing Then
                        UCPrincipalSistema.Visible = True
                        UCPrincipalSistema.BringToFront()
                        UCPrincipalSistema.Show()
                    Else
                        UCPrincipalSistema = New UCPrincipalSistema With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCPrincipalSistema)
                        UCPrincipalSistema.Visible = True
                        UCPrincipalSistema.BringToFront()
                        UCPrincipalSistema.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "  Kardex"
                If validarPermisos(PermisosDelSistema.CONTROL_KARDEX_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalKaredex IsNot Nothing Then
                        UCPrincipalKaredex.Visible = True
                        UCPrincipalKaredex.BringToFront()
                        UCPrincipalKaredex.Show()
                        'Else
                        '    UCPrincipalKaredex = New UCPrincipalKardex With {.Dock = DockStyle.Fill, .Visible = False}
                        '    PanelBody.Controls.Add(UCPrincipalKaredex)
                        '    UCPrincipalKaredex.Visible = True
                        '    UCPrincipalKaredex.BringToFront()
                        '    UCPrincipalKaredex.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "  Finanzas"
                If validarPermisos(PermisosDelSistema.FINANZAS_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalFinanzas IsNot Nothing Then
                        UCPrincipalFinanzas.Visible = True
                        UCPrincipalFinanzas.BringToFront()
                        UCPrincipalFinanzas.Show()
                    Else
                        UCPrincipalFinanzas = New UCPrincipalFinanzas With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCPrincipalFinanzas)
                        UCPrincipalFinanzas.Visible = True
                        UCPrincipalFinanzas.BringToFront()
                        UCPrincipalFinanzas.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "  Caja"
                If validarPermisos(PermisosDelSistema.CONFIGURAR_CAJAS_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalCajaAdministrativa IsNot Nothing Then
                        UCPrincipalCajaAdministrativa.Visible = True
                        UCPrincipalCajaAdministrativa.BringToFront()
                        UCPrincipalCajaAdministrativa.Show()
                    Else
                        UCPrincipalCajaAdministrativa = New UCPrincipalCajaAdministrativa With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCPrincipalCajaAdministrativa)
                        UCPrincipalCajaAdministrativa.Visible = True
                        UCPrincipalCajaAdministrativa.BringToFront()
                        UCPrincipalCajaAdministrativa.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "  Caja Pos"
                If validarPermisos(PermisosDelSistema.CAJA_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCPrincipalCajaPos IsNot Nothing Then
                        UCPrincipalCajaPos.Visible = True
                        UCPrincipalCajaPos.BringToFront()
                        UCPrincipalCajaPos.Show()

                    Else
                        UCPrincipalCajaPos = New UCPrincipalCajaPos With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCPrincipalCajaPos)
                        UCPrincipalCajaPos.Visible = True
                        UCPrincipalCajaPos.BringToFront()
                        UCPrincipalCajaPos.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Case "  Reportes"

                OcultarTodos()

                If UCPrincipalReportes IsNot Nothing Then
                    UCPrincipalReportes.Visible = True
                    UCPrincipalReportes.BringToFront()
                    UCPrincipalReportes.Show()

                Else
                    UCPrincipalReportes = New UCPrincipalReportes With {.Dock = DockStyle.Fill, .Visible = False}
                    PanelBody.Controls.Add(UCPrincipalReportes)
                    UCPrincipalReportes.Visible = True
                    UCPrincipalReportes.BringToFront()
                    UCPrincipalReportes.Show()
                End If

            Case "  Almacenes"
                If validarPermisos(PermisosDelSistema.ALMACEN_, AutorizacionRolList) = 1 Then

                    OcultarTodos()

                    If UCPrincipalAlmacenes IsNot Nothing Then
                        UCPrincipalAlmacenes.Visible = True
                        UCPrincipalAlmacenes.BringToFront()
                        UCPrincipalAlmacenes.Show()

                    Else
                        UCPrincipalAlmacenes = New UCPrincipalAlmacenes With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCPrincipalAlmacenes)
                        UCPrincipalAlmacenes.Visible = True
                        UCPrincipalAlmacenes.BringToFront()
                        UCPrincipalAlmacenes.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
        End Select
    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnMaximizar_Click(sender As Object, e As EventArgs) Handles btnMaximizar.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        ElseIf Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub bg_DoWork(sender As Object, e As DoWorkEventArgs) Handles bg.DoWork
        Dim detalleitemsSA As New detalleitemsSA
        Dim inventarioSA As New TotalesAlmacenSA
        VarClienteGeneral = entidadSA.UbicarEntidadVarios("VR", General.Gempresas.IdEmpresaRuc, String.Empty, GEstableciento.IdEstablecimiento)


        UsuariosList = usuarioSA.ListadoUsuariosv2()
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

    Private Sub lblCerrarSesion_Click(sender As Object, e As EventArgs) Handles lblCerrarSesion.Click
        FormLogeoNuevoIntro()
    End Sub

    Private Sub LinkPaginaWeb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkPaginaWeb.LinkClicked
        System.Diagnostics.Process.Start("http://www.spk.com.pe")
    End Sub


    Private Sub btnFacturacionElectronica_Click(sender As Object, e As EventArgs) Handles btnFacturacionElectronica.Click
        If Gempresas.ubigeo > 0 Then

            AlertasPseConsulta()
        Else
            MessageBox.Show("Debe habilitar la facturación electronica", "Ubigeo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub FormTablaPrincipalBasic_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub PanelGrafico2_Tick(sender As Object, e As EventArgs) Handles PanelGrafico2.Tick
        Try


            PanelGrafico2.Stop()



            Me.Grafico2.Series("Series1").Points.AddXY("ENE", 20)
            Me.Grafico2.Series("Series1").Points.AddXY("FEB", 40)
            Me.Grafico2.Series("Series1").Points.AddXY("MAR", 70)
            Me.Grafico2.Series("Series1").Points.AddXY("ABR", 80)
            Me.Grafico2.Series("Series1").Points.AddXY("MAY", 50)
            Me.Grafico2.Series("Series1").Points.AddXY("JUN", 70)
            Me.Grafico2.Series("Series1").Points.AddXY("JUL", 90)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PanelGrafico_Tick(sender As Object, e As EventArgs) Handles PanelGrafico.Tick
        PanelGrafico.Stop()

        Me.Grafico1.Series("Series1").Points.AddXY("LUN", 20)
        Me.Grafico1.Series("Series1").Points.AddXY("MAR", 40)
        Me.Grafico1.Series("Series1").Points.AddXY("MIE", 70)
        Me.Grafico1.Series("Series1").Points.AddXY("JUE", 80)
        Me.Grafico1.Series("Series1").Points.AddXY("VIE", 50)
        Me.Grafico1.Series("Series1").Points.AddXY("SAB", 70)
        Me.Grafico1.Series("Series1").Points.AddXY("DOM", 90)
    End Sub
End Class
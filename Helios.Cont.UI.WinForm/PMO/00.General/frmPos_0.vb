Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports ExtendedListBoxControl.ExtendedListBoxItemClasses
Public Class frmPos_0
    Inherits frmMaster


    Public Property ManipulacionEstado() As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.splashControl1.SplashControlPanel.BorderType = SplashBorderType.None
        Me.splashControl1.ShowDialogSplash(Me)
        Me.splashControl1.AutoMode = False

        Me.splashControl1.HostForm = Me
        ' Add any initialization after the InitializeComponent() call.
        DockingClientPanel1.Enabled = False
        ' _ls = ls
    End Sub

   
    Dim gradientLabel1 As New GradientLabel
    Dim toolTipInfo1 As New ToolTipInfo()
    '    Private _ls As LoadStyle
    'Public Enum LoadStyle
    '    OnLoad
    '    OnShown
    '    OnShownDoEvents
    'End Enum

    Public Enum Asegurable 'Los códigos son los que están asignados en la BD
        Seguridad = 1
        AltaUsuario = 2
        UsuarioEnRol = 3
    End Enum

    Private Function CheckForm(_form As Form) As Form

        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return f
            End If
        Next

        Return Nothing

    End Function

#Region "Métodos"
    Private Sub AlertaMovAlmacen()
        Dim compraSA As New DocumentoCompraSA
        Dim compra As New List(Of documentocompra)

        compra = compraSA.GetAlertaMovimientosAlmacen

        For Each t In compra
            Select Case t.tipoCompra
                Case "OEA"
                    HubTile4.Title.Text = t.importeTotal
                Case "OSA"
                    HubTile6.Title.Text = t.importeTotal
                Case "TEA"
                    HubTile7.Title.Text = t.importeTotal
            End Select
        Next
    End Sub


    Private Sub AlertasVenta()
        Dim ventaSA As New documentoVentaAbarrotesSA
        lblAlertaVenta.Text = ventaSA.ListadoventasObservadasConteo(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .notificacionAsiento = "S"})
    End Sub

    Public Sub GetInventarioEnAlertaConteo(be As totalesAlmacen)
        Dim totalSA As New TotalesAlmacenSA

        lblAlertaStock.Text = totalSA.GetAlertaIventarioMinimoConteo(be)

    End Sub

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
            'If IsDate(New DateTime(cboAnios.Text, txtMes.Value.Month, txtDiaLaboral.Value.Day)) Then
            .dia = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            'Else
            'Throw New Exception("Validar la fecha")
            'End If
            .periodo = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month)) & "/" & DateTime.Now.Year
            .tipocambio = TmpTipoCambio
            .iva = TmpIGV
            .tipoIva = TmpTipoIVA
            .retencion4ta = TmpRetencion4

            'If rbConIva.Checked = True Then
            '    .tipoIva = "SIVA"
            'ElseIf rbSinIVA.Checked = True Then
            '    .tipoIva = "NIVA"
            'End If

            existe = configsa.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

            If Not IsNothing(existe) Then
                configsa.EditarConfigInicio(config)
            Else
                'configsa.InsertConfigInicio(config)
            End If
            'GEstableciento = New GEstablecimiento
            'GEstableciento.IdEstablecimiento = GEstableciento.IdEstablecimiento
            'GEstableciento.NombreEstablecimiento = GEstableciento.NombreEstablecimiento
            'TmpIdAlmacen = TmpIdAlmacen
            'TmpNombreAlmacen = TmpNombreAlmacen
            AnioGeneral = CStr(DateTime.Now.Year)
            MesGeneral = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month))
            DiaLaboral = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month)) & "/" & DateTime.Now.Year
            'TmpTipoCambio = TmpTipoCambio
            'TmpIGV = TmpIGV
            'If rbConIva.Checked = True Then
            '    TmpTipoIVA = "SIVA"
            'Else
            '    TmpTipoIVA = "NIVA"
            'End If
            'TmpTipoIVA = TmpTipoIVA
            'Dispose()
        End With
    End Sub

    Public Sub anioverificar()
        Dim AnioSA As New empresaPeriodoSA
        Dim Anio As New empresaPeriodo

        Anio.idEmpresa = Gempresas.IdEmpresaRuc
        Anio.periodo = CStr(DateTime.Now.Year)
        Anio.usuarioActualizacion = "Jiuni"
        Anio.fechaActualizacion = DateTime.Now
        Anio.message = "verificar"
        AnioSA.InsertarPeriodo(Anio)

    End Sub

    Public Sub CargarConfiguracionInicioUsuariosDeCaja(strIdEmpresa As String)
        'Dim configSA As New ConfiguracionInicioSA
        'Dim config As New configuracionInicio
        'Dim estableSA As New establecimientoSA
        'Dim almaceSa As New almacenSA
        'Dim cierreCajaSA As New CierreCajaSA
        'Dim cierreInventarioSA As New CierreInventarioSA
        'config = configSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc)

        'If Not IsNothing(config) Then
        '    With config
        '        GEstableciento = New GEstablecimiento
        '        GEstableciento.IdEstablecimiento = .idEstablecimiento
        '        GEstableciento.NombreEstablecimiento = estableSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
        '        TmpIdAlmacen = .idalmacenVenta
        '        TmpNombreAlmacen = almaceSa.GetUbicar_almacenPorID(.idalmacenVenta).descripcionAlmacen
        '        AnioGeneral = .anio
        '        MesGeneral = .mes
        '        DiaLaboral = .dia
        '        PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(.mes)) & "/" & .anio
        '        TmpTipoCambio = .tipocambio
        '        TmpIGV = .iva
        '        TmpTipoIVA = .tipoIva
        '        TmpRetencion4 = .retencion4ta.GetValueOrDefault
        '    End With

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
                Dim nomEmpresa = Gempresas.NomEmpresa
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
            'TmpIdAlmacen = .idalmacenVenta
            'CajaInicioSaldo()
        End If
        'CajaInicioSaldo()

    End Sub

    Sub CajaInicioSaldo()
        Dim EfSA As New EstadosFinancierosSA
        Dim Ef As New estadosFinancieros
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        'Dim cajaUsuarioSA As New cajaUsuarioSA

        Ef = EfSA.GetUbicar_estadosFinancierosPorID(TmpIdEntidadFinanciera)
        If Not IsNothing(Ef) Then
            GFichaUsuarios = New GFichaUsuario
            GFichaUsuarios.IdCajaUsuario = usuario.IDUsuario
            GFichaUsuarios.IdPersona = usuario.IDUsuario
            GFichaUsuarios.NombrePersona = usuario.CustomUsuario.Nombres & ", " & usuario.CustomUsuario.ApellidoPaterno & " " & usuario.CustomUsuario.ApellidoMaterno
            GFichaUsuarios.ClaveUsuario = String.Empty
            GFichaUsuarios.IdCajaOrigen = TmpIdEntidadFinanciera
            GFichaUsuarios.IdCajaDestino = TmpIdEntidadFinanciera
            GFichaUsuarios.cuentaDestino = Ef.cuenta
            GFichaUsuarios.NomCajaDestinb = Ef.descripcion
            GFichaUsuarios.FechaApertura = DateTime.Now
            GFichaUsuarios.Moneda = Ef.codigo

            GFichaUsuarios.TipoCambio = Ef.tipocambio
            GFichaUsuarios.FondoMN = Ef.importeBalanceMN
            GFichaUsuarios.FondoME = Ef.importeBalanceME
            GFichaUsuarios.EstadoCaja = "A"
            GFichaUsuarios.EnUso = ""
            UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
        End If
    End Sub

    Public Sub CargarConfiguracionInicio(strIdEmpresa As String)
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio
        Dim estableSA As New establecimientoSA
        Dim almaceSa As New almacenSA
        Dim cierreCajaSA As New CierreCajaSA
        Dim cierreInventarioSA As New CierreInventarioSA


    End Sub
#End Region

#Region "Terminar Procesor"
    Private Function TerminarProceso(ByVal StrNombreProceso As String, _
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
#End Region

    Private Sub frmPos_0_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            TerminarProceso("Helios.Cont.Presentation.WinForm")
            TerminarProceso("SMSvcHost.exe")
            Application.ExitThread()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmPos_0_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SplitButton1.Style = Syncfusion.Windows.Forms.Tools.SplitButtonVisualStyle.Metro
        '   Me.SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
        Me.PopupMenusManager1.SetXPContextMenu(Me.PictureBox1, Me.PopupMenu1)
        BarItem1.Enabled = False
        BarItem2.Enabled = False
        BarItem3.Visible = False
        BarItem5.Visible = False

        '    If _ls = LoadStyle.OnLoad Then
        

        dockingManager1.DockControlInAutoHideMode(PanelReporte, DockingStyle.Right, 264)
        dockingManager1.SetDockLabel(PanelReporte, "Reportes")
        

        ' End If
        Me.WindowState = FormWindowState.Normal
        Timer1.Enabled = True

    End Sub

    'Sub InicioTablasGenerales()
    '    Dim tablaSA As New tablaDetalleSA

    '    ListaComprobantes = tablaSA.GetListaTablaDetalle(10, "1")
    '    ListaUnidadMedida = tablaSA.GetListaTablaDetalle(10, "1")
    '    ListaPresentacion = tablaSA.GetListaTablaDetalle(10, "1")

    'End Sub

    Private Sub HubTile2_Click(sender As Object, e As EventArgs) Handles HubTile2.Click
        Me.Cursor = Cursors.WaitCursor
        '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.INVENTARIO, AutorizacionRolList) Then
        If Me.Name = MaestrosGenerales.PuntoVentaBasico Then
            ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico
            Dim f As New frmPos_0_Inventario
            f.Size = New Size(1340, 708)
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Else
            Dim f As New frmInventario
            f.Show()
        End If

        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BannerTile_Click(sender As Object, e As EventArgs) Handles BannerTile.Click
        Me.Cursor = Cursors.WaitCursor
        ' If AutorizacionRolSA.TienePermiso(ModuloAsegurable.COMPRAS, AutorizacionRolList) Then
        'Dim val As Object = CheckForm(frmMasterComprasGenerales)
        If Me.Name = MaestrosGenerales.PuntoVentaBasico Then
            ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico
            Dim f As New frmPos_0_Compras
            f.Size = New Size(1340, 708)
            f.StartPosition = FormStartPosition.CenterScreen
            f.Select()
            f.BringToFront()
            f.Show()
            'Dim f As New frmPos_0_Compras
            'f.Size = New Size(1340, 708)
            'f.StartPosition = FormStartPosition.CenterScreen
            'f.Show()
        Else
            ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaAvanzado

            Dim f As New frmMasterComprasGenerales
            f.Show()
        End If
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile3_Click(sender As Object, e As EventArgs) Handles HubTile3.Click
        Me.Cursor = Cursors.WaitCursor
        '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.COMERCIAL, AutorizacionRolList) Then

        If Me.Name = MaestrosGenerales.PuntoVentaBasico Then
            ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico
            Dim f As New frmPos_0_Venta
            f.Size = New Size(1340, 708)
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Else
            Dim f As New frmMasterGeneralVentas
            f.Show()
        End If


        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile5_Click(sender As Object, e As EventArgs) Handles HubTile5.Click
        Me.Cursor = Cursors.WaitCursor
        '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.FINANZAS, AutorizacionRolList) Then
        Me.Cursor = Cursors.WaitCursor
        ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico
        Dim f As New frmUsuariosFinanza
        f.Size = New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Function MatarProceso(ByVal StrNombreProceso As String, _
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

    Private Sub HubTile1_Click(sender As Object, e As EventArgs) Handles HubTile1.Click
        Me.Cursor = Cursors.WaitCursor
        ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico
        Dim f As New frmTablasGenerales
        f.Size = New Size(1040, 670) ' New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub
    Dim i As Integer = 0
    Dim LightBox As New HeliosLogin
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i += 1000
        If i = 1000 Then
            i = 0
            Timer1.Stop()

            LightBox = New HeliosLogin

            LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
            LightBox.Owner = Me
            LightBox.ShowDialog()

            If Not IsNothing(LightBox.Tag) Then
                If Not IsNothing(usuario) Then
                    SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
                    DockingClientPanel1.Enabled = True
                    SplitButton1.Text = usuario.Alias
                    Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                        Case 1 ' ADMINISTRADOR

                            'Dim init As New frmInicioEmpresa
                            'init.StartPosition = FormStartPosition.CenterParent
                            'init.ShowDialog()

                            'CargarConfiguracionInicio(Gempresas.IdEmpresaRuc)
                            '     CoNteoNotifi()

                            Dim fSel As New frmInicioEmpresa
                            fSel.StartPosition = FormStartPosition.CenterParent
                            fSel.ShowDialog()
                            Label5.Text = "Período: " & PeriodoGeneral
                            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
                            Label24.Text = GEstableciento.NombreEstablecimiento
                        Case 2 ' USUARI BASICO => SOLO ACCESO AL PUNTP DE VENTA'
                            'CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)
                            CargarConfiguracionInicioUsuariosDeCaja("20392657020")

                        Case 3 ' USUARIO PUNTO DE VENTA MANJEJO DE EFECTIVO
                            'Dim empresa As String
                            'empresa = Gempresas.IdEmpresaRuc

                            Dim fSel As New frmInicioEmpresa
                            fSel.StartPosition = FormStartPosition.CenterParent
                            fSel.ShowDialog()
                            Label5.Text = "Período: " & PeriodoGeneral
                            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
                            Label24.Text = GEstableciento.NombreEstablecimiento
                            'Label5.Text = "Período: " & PeriodoGeneral
                    End Select

                    AlertaMovAlmacen()
                End If
            Else
                'MessageBox.Show("Verificar si el usuario o clave es correcta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Inicio()

                'Exit Sub
                MatarProceso("Helios.Cont.Presentation.WinForm")
                MatarProceso("SMSvcHost.exe")
                Application.ExitThread()
                Close()
            End If


            'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
            '    Case 1 ' ADMINISTRADOR
            '        Dim fSel As New frmInicioEmpresa
            '        fSel.StartPosition = FormStartPosition.CenterParent
            '        fSel.ShowDialog()
            '        Label5.Text = "Período: " & PeriodoGeneral
            '        lblEmpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            '        'AlertasVenta()
            '        'AlertaMovAlmacen()
            '        'GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})

            '    Case 2 ' USUARI BASICO => SOLO ACCESO AL PUNTP DE VENTA

            '    Case 3 ' USUARIO PUNTO DE VENTA MANJEJO DE EFECTIVO
            '        Label5.Text = "Período: " & PeriodoGeneral
            '        'lblEmpresa.Text = Gempresas.NomEmpresa & " - " & "20569026602"
            'End Select


        End If
    End Sub

    Private Sub HubTile9_Click(sender As Object, e As EventArgs) Handles HubTile9.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ef As New EstadosFinancierosSA
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuarioSA As New UsuarioSA
        Dim usuarioxls As New Usuario
        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)

        If Not IsNothing(cajaUsuario) Then
            usuarioxls = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = usuario.IDUsuario})

            Dim F As New frmCobroPedidos
            F.txtNomUser.Text = usuarioxls.Full_Name
            'F.txtCajaOrigen.Tag = CInt(cajaUsuario.idCajaOrigen)
            'F.txtCajaOrigen.Text = ef.GetUbicar_estadosFinancierosPorID(CInt(cajaUsuario.idCajaOrigen)).descripcion
            '   F.GetObtenerSaldoEF()
            'F.GridPago()


            If IsNothing(cajaUsuario.idPadre) Then
                F.txtTipoUser.Text = "Usuario Responsable"
                F.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
            Else
                F.txtTipoUser.Text = "Usuario Dependiente"
                F.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
            End If

            F.StartPosition = FormStartPosition.CenterParent
            F.ShowDialog()
            'Dim f As New frmCajaTicket
            'f.SinAnticipo()
            'f.Show()
        Else
            MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile13_Click(sender As Object, e As EventArgs) Handles HubTile13.Click
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)

        If Not IsNothing(cajaUsuario) Then
            Dim f As New frmVentaPV
            f.lblPerido.Text = PeriodoGeneral
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Else
            MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Sub Inicio()
        usuario = New AutenticacionUsuario
        usuario.CustomUsuario = New Usuario
        Dim LightBox As New HeliosLogin
        LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
        LightBox.Owner = Me
        LightBox.ShowDialog()

        If Not IsNothing(usuario) Then
            SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
            DockingClientPanel1.Enabled = True
            SplitButton1.Text = usuario.Alias
            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 1 ' ADMINISTRADOR

                    Dim init As New frmInicioEmpresa
                    init.StartPosition = FormStartPosition.CenterParent
                    init.ShowDialog()

                    'CargarConfiguracionInicio(Gempresas.IdEmpresaRuc)
                    '     CoNteoNotifi()
                Case 2 ' USUARI BASICO => SOLO ACCESO AL PUNTP DE VENTA
                    CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)

                Case 3 ' USUARIO PUNTO DE VENTA MANJEJO DE EFECTIVO
                    CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)
            End Select

            Label24.Text = GEstableciento.NombreEstablecimiento
        Else
            SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
            SplitButton1.Text = "Usuario"
            DockingClientPanel1.Enabled = False
            MessageBox.Show("Usario o clave incorrectos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'MatarProceso("SMSvcHost.exe")
            'Application.ExitThread()
            'Me.Close()
        End If
    End Sub

    Private Sub SplitButton1_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub
    Private Sub HubTile14_Click(sender As Object, e As EventArgs) Handles HubTile14.Click

        Dim ef As New EstadosFinancierosSA
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuarioSA As New UsuarioSA
        Dim usuarioxls As New Usuario
        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)

        If Not IsNothing(cajaUsuario) Then
            Dim f As New frmVentaPVdirecta
            f.lblPerido.Text = PeriodoGeneral
            f.btGrabar.Enabled = True
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            'f.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            f.lblPerido.Text = PeriodoGeneral
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Else
            MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub SplitButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SplitButton1_Click_1(sender As Object, e As EventArgs) Handles SplitButton1.Click

    End Sub

    Private Sub SplitButton1_DropDowItemClicked1(sender As Object, e As ToolStripItemClickedEventArgs) Handles SplitButton1.DropDowItemClicked
        Try
            Select Case e.ClickedItem.Text
                Case "Iniciar Sesion"
                    Inicio()
                Case "Cerrar Sesion"
                    SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
                    SplitButton1.Text = "Usuario"
                    DockingClientPanel1.Enabled = False
                    Inicio()
                Case "Información Empresa"
                    'Dim f As New frmInicioTrabajoEmpresa
                    'f.StartPosition = FormStartPosition.CenterParent
                    'f.ShowDialog()
            End Select
            lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            Label5.Text = PeriodoGeneral

            AlertasVenta()
            AlertaMovAlmacen()
            GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Inicio()
        End Try
    End Sub

    Private Sub HubTile4_Click(sender As Object, e As EventArgs) Handles HubTile4.Click
        Me.Cursor = Cursors.WaitCursor

        Dim f As New frmResumenMovByOperacion(GEstableciento.IdEstablecimiento, DiaLaboral, "OEA")
        f.CaptionLabels(0).Text = "Otras Entradas a almacén"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        'With frmMovOtrasEntradas
        '    .lblPerido.Text = PeriodoGeneral
        '    .cboOperacion.SelectedValue = "0000"
        '    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    .lblPerido.Text = PeriodoGeneral
        '    '   .cambioMovimiento()
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile6_Click(sender As Object, e As EventArgs) Handles HubTile6.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmResumenMovByOperacion(GEstableciento.IdEstablecimiento, DiaLaboral, "OSA")
        f.CaptionLabels(0).Text = "Otras salidas de almacén"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        'With frmOtrasSalidasDeAlmacen
        '    .lblPerido.Text = PeriodoGeneral
        '    .cboOperacion.SelectedValue = "0001"
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvReporte_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvReporte.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case lsvReporte.SelectedItems(0).Text
            Case "Registro de compras del mes"
                Dim f As New frmComprasXmes
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
            Case "Registro de compras del día"
                Dim f As New frmComprasXdia
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
            Case "Stock actual"
                Dim f As New frmReporteListaInventario
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
            Case "Kardex General"

            Case "Otros Movimientos de almacén"

                Dim f As New frmReporteMovAlmacen
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
            Case "Lista de precios"
                Dim f As New frmReporteListaPrecios
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
            Case "Registro de ventas del mes"
                Dim f As New frmRptListadoFactura
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
            Case "Ventas del día"
                Dim f As New FmrVentxDia
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
            Case "Rentabilidad por mes"
                Dim f As New frmrentabilidadXmes
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
            Case "Rentabilidad por día"
                Dim f As New frmrentabilidadXdia
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()

            Case "Artículos vendidos por mes"
                Dim f As New frmArticulosVendidosByMes
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()

            Case "Artículos vendidos por día"
                Dim f As New frmArticulosVendidosByDia
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()

            Case "Artículos comprados por período"
                Dim f As New frmArticulosComprasPeriodo
                f.StartPosition = FormStartPosition.CenterParent
                f.Size = New Size(1340, 708)
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvReporte.SelectedIndexChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        'Me.Cursor = Cursors.WaitCursor
        ''Dim LightBox As New frmConfigInicioXempresa(Gempresas.IdEmpresaRuc)
        ''LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
        ''LightBox.Owner = Me
        ''LightBox.ShowDialog()
        ''Label5.Text = "periodo: " & PeriodoGeneral

        'Dim f As New frmSeleccionEmpresaMDI ' frmInicioEmpresa
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()

        'Label5.Text = "Período: " & PeriodoGeneral
        ''   lblEmpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
        'AlertasVenta()
        'AlertaMovAlmacen()
        'GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})

        ''  AreaTrabajo()
        'Me.Cursor = Cursors.Arrow


        Me.Cursor = Cursors.WaitCursor


        '    If AutorizacionRolSA.TienePermiso(ModuloAsegurable.CONFIG_INICIO, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")

        'Dim val As Object = CheckForm(frmMasterComprasGenerales)

        Dim f As New frmInicioEmpresa
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        Label5.Text = "Período: " & PeriodoGeneral
        lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
        Label24.Text = GEstableciento.NombreEstablecimiento
        'Else
        'MessageBox.Show("Usuario no autorizado")
        'End If


        AlertasVenta()
        AlertaMovAlmacen()
        GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})

        '  AreaTrabajo()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile7_Click(sender As Object, e As EventArgs) Handles HubTile7.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmResumenMovByOperacion(GEstableciento.IdEstablecimiento, DiaLaboral, "TEA")
        f.CaptionLabels(0).Text = "Transferencia entre almacenes"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        'With frmMovimientoAlmacen
        '    .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .lblPerido.Text = PeriodoGeneral
        '    '.cambioMovimiento()
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        'Dim f As New frmInicioTrabajoEmpresa
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim f As New frmListaPermisos
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmInfoMovimientoDia
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles lblAlertaVenta.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmAlertaVentas
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        AlertasVenta()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub lblAlertaStock_Click(sender As Object, e As EventArgs) Handles lblAlertaStock.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmPos_0_Inventario(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        f.Size = New Size(1040, 670) ' New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Me.Cursor = Cursors.WaitCursor
        AlertasVenta()
        AlertaMovAlmacen()
        GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub HubTile8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label13_Click_1(sender As Object, e As EventArgs) Handles Label13.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim f As New frmAperturaCajaXUsuario
            f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
            f.UbicarCajaUsuario(usuario.IDUsuario)
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim f As New frmCerrarCajaXUsuario
            f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
            f.UbicarCajaUsuario(usuario.IDUsuario)
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BtDashBoard_Click(sender As Object, e As EventArgs) Handles BtDashBoard.Click
        Me.Cursor = Cursors.WaitCursor
        Dim F As New frmTableroPorDia
        'Dim f As New frmDashBoard
        F.StartPosition = FormStartPosition.CenterParent
        F.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel37_Click(sender As Object, e As EventArgs) Handles Panel37.Click
        Dim f As New frmCostoVenta2
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub Panel37_Paint(sender As Object, e As PaintEventArgs) Handles Panel37.Paint

    End Sub
End Class
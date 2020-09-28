Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports ExtendedListBoxControl.ExtendedListBoxItemClasses
Public Class frmMaestroModuloV2

#Region "Attributes"
    Dim i As Integer = 0
    Public Property LightBox As New HeliosLogin
    Public empresaPeriodoSA As New empresaCierreMensualSA
    Public Property empresaSA As New empresaSA
    Private Property ConfiguracionInicioSA As New ConfiguracionInicioSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.splashControl1.SplashControlPanel.BorderType = SplashBorderType.None
        Me.splashControl1.ShowDialogSplash(Me)
        Me.splashControl1.AutoMode = False

        Me.splashControl1.HostForm = Me
        DockingClientPanel1.Enabled = False
    End Sub
#End Region

#Region "Methods"

    'Sub ValidarFechaActual()
    '    Dim fechaInicio As Date = DiaLaboral

    '    If fechaInicio.Date <> Date.Now.Date Then

    '        TerminarProceso("Helios.Cont.Presentation.WinForm")
    '        TerminarProceso("SMSvcHost.exe")
    '        Application.ExitThread()
    '        '  Application.Restart()
    '        'For Each frm As Form In Application.OpenForms
    '        '    If frm IsNot Me Then

    '        '        If frm.Name = "FeedbackForm" Then

    '        '        Else
    '        '            frm.Close()
    '        '        End If
    '        '        'Cerramos todos los formularios menos el formulario principal que contiene el menú
    '        '    End If
    '        'Next
    '        'Timer2.Enabled = False
    '        'Inicio()
    '        'lblEstablecimiento.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
    '        'Label5.Text = PeriodoGeneral
    '    End If
    'End Sub

    Sub Inicio()
        usuario = New AutenticacionUsuario
        usuario.CustomUsuario = New Usuario
        Dim LightBox As New HeliosLogin
        LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
        LightBox.Owner = Me
        LightBox.ShowDialog()

        If Not IsNothing(usuario) Then
            ' SplitButton1.BackColor = Color.FromArgb(92, 184, 92)
            SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
            DockingClientPanel1.Enabled = True
            SplitButton1.Text = usuario.Alias
            'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
            '    Case 1 ' ADMINISTRADOR

            '        Dim init As New frmInicioEmpresa
            '        init.StartPosition = FormStartPosition.CenterParent
            '        init.ShowDialog()

            '        'CargarConfiguracionInicio(Gempresas.IdEmpresaRuc)
            '        '     CoNteoNotifi()
            '    Case 2 ' USUARI BASICO => SOLO ACCESO AL PUNTP DE VENTA
            '        CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)

            '    Case 3, 4 ' USUARIO PUNTO DE VENTA MANJEJO DE EFECTIVO
            '        CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)
            'End Select

            Select Case (LightBox.empresaSPK.FirstOrDefault.TieneCaja)
                Case True
                    CargarConfiguracionInicioUsuariosDeCaja(Gempresas.IdEmpresaRuc)
                Case False
                    Dim init As New frmInicioEmpresa
                    init.StartPosition = FormStartPosition.CenterParent
                    init.ShowDialog()
            End Select

            Label24.Text = GEstableciento.NombreEstablecimiento

            'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
            '    Case 1
            '        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Administrador POS"
            '    Case 2
            '        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Atención (Pre-venta)"
            '    Case 3
            '        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Cajero (Caja centralizada)"
            '    Case 4
            '        Label15.Text = usuario.CustomUsuario.Full_Name & "-" & "Cajero (Venta Directa)"

            'End Select


        Else
            '  SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
            SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
            SplitButton1.Text = "Usuario"
            DockingClientPanel1.Enabled = False
            MessageBox.Show("Usario o clave incorrectos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'MatarProceso("SMSvcHost.exe")
            'Application.ExitThread()
            'Me.Close()
        End If
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
#End Region

#Region "Events"
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CENTRO_DE_GASTOS__, AutorizacionRolList) Then
        Dim f As New frmMaestroGastos
            f.ShowDialog()
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub Panel37_Click(sender As Object, e As EventArgs) Handles Panel37.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CENTRO_DE_COSTOS__, AutorizacionRolList) Then
            Dim f As New frmCostoVenta2
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtDashBoard_Click(sender As Object, e As EventArgs) Handles BtDashBoard.Click
        Cursor = Cursors.WaitCursor
        '  If AutorizacionRolSA.TienePermiso(AsegurablesSistema.INFORMACION_GERENCIAL_Dashword__, AutorizacionRolList) Then
        'Dim F As New frmTableroPorDia
        ''Dim f As New frmDashBoard
        'F.StartPosition = FormStartPosition.CenterParent
        'F.ShowDialog()
        With frmInformacionGeneral
                .lblPerido.Text = PeriodoGeneral
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub frmMaestroModuloV2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            TerminarProceso("Helios.Cont.Presentation.WinForm")
            TerminarProceso("SMSvcHost.exe")
            Application.ExitThread()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMaestroModuloV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)
        Me.SplitButton1.Style = Syncfusion.Windows.Forms.Tools.SplitButtonVisualStyle.Metro
        Me.SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
        Me.PopupMenusManager1.SetXPContextMenu(Me.PictureBox1, Me.PopupMenu1)

        Me.WindowState = FormWindowState.Normal
        Timer1.Enabled = True
        TmpProduccionPorLotes = True
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
        Label5.Text = "Período: " & String.Format("{0:00}", CInt(MesGeneral)) & "/" & AnioGeneral
        lblEpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
        Label24.Text = GEstableciento.NombreEstablecimiento
        Label15.Text = usuario.Alias
    End Sub

    Private Sub FormLogeo()
        LightBox = New HeliosLogin
        LightBox.SetBounds(Left, Top, ClientRectangle.Width, ClientRectangle.Height)
        LightBox.Owner = Me
        LightBox.ShowDialog()
        GetConfiguracionInicio()
        If Not IsNothing(LightBox.Tag) Then
            If Not IsNothing(usuario) Then
                SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
                DockingClientPanel1.Enabled = True
                SplitButton1.Text = usuario.Alias
                Timer2.Enabled = True
            End If
        Else
            MatarProceso("Helios.Cont.Presentation.WinForm")
            MatarProceso("SMSvcHost.exe")
            Application.ExitThread()
            Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i += 1000
        If i = 1000 Then
            i = 0
            Timer1.Stop()
            FormLogeo()
        End If
        Panel1.Enabled = True
    End Sub

    Private Sub BannerTile_Click(sender As Object, e As EventArgs) Handles BannerTile.Click
        Me.Cursor = Cursors.WaitCursor
        Dim atorizado = AutorizacionRolSA.TienePermiso(AsegurablesSistema.PANEL_LOGISTICA__, AutorizacionRolList)
        Select Case atorizado
            Case True
                Dim f As New FormMaestroLogistica ' frmLogisticaMaestro 'frmMasterComprasGenerales
                'f.Size = New Size(1340, 708)
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show()
            Case False
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Case Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Select
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistema.LOGISTICA, AutorizacionRolList) Then
        '    Dim f As New frmLogisticaMaestro 'frmMasterComprasGenerales
        '    'f.Size = New Size(1340, 708)
        '    '   f.StartPosition = FormStartPosition.CenterScreen
        '    f.Show()
        'Else
        '    MessageBox.Show("Usuario no autorizado")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(ModuloAsegurable.INVENTARIO, AutorizacionRolList) Then
        '    'MessageBox.Show("Usuario autorizado")
        '    Dim f As New frmInventario ' frmMasterGeneralInventario
        '    f.Size = New Size(1340, 708)
        '    f.StartPosition = FormStartPosition.CenterScreen
        '    f.Show()
        'Else
        '    MessageBox.Show("Usuario no autorizado")
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv13_Click(sender As Object, e As EventArgs) Handles ButtonAdv13.Click
        '   If AutorizacionRolSA.TienePermiso(AsegurablesSistema.PANEL_PLANILLA__, AutorizacionRolList) Then
        'Dim f As New frmMaestroPlanilla
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()
        '  Else
        ' MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Me.Cursor = Cursors.WaitCursor
        ' If AutorizacionRolSA.TienePermiso(AsegurablesSistema.PANEL_CONTABILIDAD__, AutorizacionRolList) Then
        '  MessageBox.Show("Usuario autorizado")
        'Dim f As New frmContabilidadMaestro
        '    f.Show()
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile3_Click(sender As Object, e As EventArgs) Handles HubTile3.Click
        Me.Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.PANEL_COMERCIAL__, AutorizacionRolList) Then
            '   MessageBox.Show("Usuario autorizado")
            Dim f As New FormMaestroComercial ' frmMaestroComercial ' frmMasterGeneralVentas
            'f.Size = New Size(1340, 708)
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        'Me.Cursor = Cursors.WaitCursor

        'If AutorizacionRolSA.TienePermiso(ModuloAsegurable.LISTA_PRECIOS, AutorizacionRolList) Then
        '    'MessageBox.Show("Usuario autorizado")
        '    Dim f As New frmTablasGenerales
        '    'f.Size = New Size(1040, 670) ' New Size(1340, 708)
        '    f.StartPosition = FormStartPosition.CenterScreen
        '    f.Show()
        'Else
        '    MessageBox.Show("Usuario no autorizado")
        'End If


        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HubTile5_Click(sender As Object, e As EventArgs) Handles HubTile5.Click
        Cursor = Cursors.WaitCursor
        '  If AutorizacionRolSA.TienePermiso(AsegurablesSistema.PANEL_FINANZAS__, AutorizacionRolList) Then
        Dim f As New FormCajaMaestro ' frmCashFlow  ' frmMasterCajas
        f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        '  If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CENTRAL_DE_REPORTES__, AutorizacionRolList) Then
        Dim F As New frmMasterModelReporte
            F.StartPosition = FormStartPosition.CenterParent
            F.ShowDialog()
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ButtonAdv11_Click(sender As Object, e As EventArgs) Handles ButtonAdv11.Click
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistema.PANEL_PROYECTOS__, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")
        Dim f As New frmMaestroProyectos 'frmMasterpmo '  frmcentralProyectos ' frmCrearPaquetesTrabajo
        f.StartPosition = FormStartPosition.CenterParent
        ' f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        'Else
        'MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        Cursor = Cursors.WaitCursor
        '   If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CIERRES__, AutorizacionRolList) Then
        Dim f As New frmselectCierre
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv17_Click(sender As Object, e As EventArgs) Handles ButtonAdv17.Click
        Me.Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.ASIGNACION_DE_COSTOS_Y_GASTOS__, AutorizacionRolList) Then
            Dim f As New frmAlertaCostos
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CONFIGURACION_DE_INICIO__, AutorizacionRolList) Then
            Dim f As New frmInicioEmpresaVariablesGlobales ' frmInicioEmpresa
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            'Label5.Text = "Período: " & PeriodoGeneral
            'lblEmpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            'Label24.Text = GEstableciento.NombreEstablecimiento

            ''If bg.IsBusy <> True Then
            ''    ' Start the asynchronous operation.
            ''    bg.RunWorkerAsync()
            ''End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SplitButton1_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles SplitButton1.DropDowItemClicked
        Try
            Select Case e.ClickedItem.Text
                Case "Iniciar Sesion"
                    '   Inicio()
                    FormLogeo()
                Case "Cerrar Sesion"
                    '    SplitButton1.BackColor = Color.FromArgb(22, 165, 220)
                    SplitButton1.BackColor = Color.FromArgb(213, 79, 185)
                    SplitButton1.Text = "Usuario"
                    DockingClientPanel1.Enabled = False
                    '   Inicio()
                    FormLogeo()
            End Select
            lblEpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
            Label5.Text = PeriodoGeneral
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FormLogeo()
        End Try
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CONFIGURACION_DE_INICIO__, AutorizacionRolList) Then
            Dim f As New frmListaPermisos
            f.WindowState = FormWindowState.Maximized
            f.ShowDialog()
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        '  If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CENTRO_DE_COSTOS__, AutorizacionRolList) Then
        Dim f As New frmCentroCostosV2
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Cursor = Cursors.WaitCursor
        With frmInformacionGeneral
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        '   If AutorizacionRolSA.TienePermiso(AsegurablesSistema.HOJA_DE_TRABAJO__, AutorizacionRolList) Then
        Dim f As New FrmHojaTrabajo
            f.Show()
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub btAbrirCaja_Click(sender As Object, e As EventArgs) Handles btAbrirCaja.Click
        Dim f As New frmDetalleEmpresa
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        'Me.Cursor = Cursors.WaitCursor
        'Try
        '    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
        '    If Not IsNothing(valida) Then
        '        If valida = True Then
        '            MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        End If
        '    End If

        '    If AutorizacionRolSA.TienePermiso(AsegurablesSistema.COBRANZA_DE_TICKETS, AutorizacionRolList) Then
        '        Dim ef As New EstadosFinancierosSA
        '        Dim cajaUsuario As New cajaUsuario
        '        Dim cajaUsuarioSA As New cajaUsuarioSA
        '        Dim usuarioSA As New UsuarioSA
        '        Dim usuarioxls As New Usuario
        '        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)

        '        If Not IsNothing(cajaUsuario) Then
        '            usuarioxls = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = usuario.IDUsuario})

        '            Dim F As New frmCobroPedidos
        '            F.txtNomUser.Text = usuarioxls.Full_Name
        '            'F.txtCajaOrigen.Tag = CInt(cajaUsuario.idCajaOrigen)
        '            'F.txtCajaOrigen.Text = ef.GetUbicar_estadosFinancierosPorID(CInt(cajaUsuario.idCajaOrigen)).descripcion
        '            '   F.GetObtenerSaldoEF()
        '            'F.GridPago()


        '            If IsNothing(cajaUsuario.idPadre) Then
        '                F.txtTipoUser.Text = "Usuario Responsable"
        '                F.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
        '            Else
        '                F.txtTipoUser.Text = "Usuario Dependiente"
        '                F.txtTipoUser.Tag = cajaUsuario.idcajaUsuario
        '            End If

        '            F.StartPosition = FormStartPosition.CenterParent
        '            F.ShowDialog()
        '            'Dim f As New frmCajaTicket
        '            'f.SinAnticipo()
        '            'f.Show()
        '        Else
        '            MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End If

        '    Else
        '        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv16_Click(sender As Object, e As EventArgs) Handles ButtonAdv16.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim fechaAnt = New Date(AnioGeneral, MesGeneral, 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            If AutorizacionRolSA.TienePermiso(AsegurablesSistema.PRE_VENTA_Formulario__, AutorizacionRolList) Then
                Dim f As New frmVentaPV
                f.lblPerido.Text = MesGeneral & "/" & AnioGeneral
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.WindowState = FormWindowState.Maximized
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btCerrarCaja_Click(sender As Object, e As EventArgs) Handles btCerrarCaja.Click
        Try
            Dim fechaAnt = New Date(AnioGeneral, MesGeneral, 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = AnioGeneral, .mes = CInt(MesGeneral)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If


            If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CAJA_CENTRALIZADA_Formulario__, AutorizacionRolList) Then
                Dim ef As New EstadosFinancierosSA
                Dim cajaUsuario As New cajaUsuario
                Dim cajaUsuarioSA As New cajaUsuarioSA
                Dim usuarioSA As New UsuarioSA
                Dim usuarioxls As New Usuario
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                    With frmVentaPVdirecta
                        .lblPerido.Text = MesGeneral & "/" & AnioGeneral
                        '.btGrabar.Enabled = True
                        .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                        .StartPosition = FormStartPosition.CenterParent
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        '     If AutorizacionRolSA.TienePermiso(AsegurablesSistema.REGISTRO_PEDIDOS__, AutorizacionRolList) Then

        Dim fechaAnt = New Date(AnioGeneral, MesGeneral, 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim f As New frmPedidoPendiente
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim fechaAnt = New Date(AnioGeneral, MesGeneral, 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If AutorizacionRolSA.TienePermiso(AsegurablesSistema.MOVIMIENTO_INVENTARIO_OTRAS_ENTRADAS_Otros_Formulario__, AutorizacionRolList) Then
                With frmMovOtrasEntradas
                    .lblPerido.Text = PeriodoGeneral
                    .cboOperacion.SelectedValue = "0000"
                    .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv12_Click(sender As Object, e As EventArgs) Handles ButtonAdv12.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim fechaAnt = New Date(AnioGeneral, MesGeneral, 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If AutorizacionRolSA.TienePermiso(AsegurablesSistema.MOVIMIENTO_INVENTARIO_OTRAS_SALIDAS_Otros_Formulario__, AutorizacionRolList) Then
                With frmOtrasSalidasDeAlmacen
                    .lblPerido.Text = PeriodoGeneral
                    .cboOperacion.SelectedValue = "0001"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CONTROL_PATRIMONIAL__, AutorizacionRolList) Then

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub lblAbrirCaja_Click(sender As Object, e As EventArgs) Handles lblAbrirCaja.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CAJA_ABRIR_CERRAR_Formulario__, AutorizacionRolList) Then
            Cursor = Cursors.WaitCursor
            With frmAperturaCajaXUsuario
                .UbicarCajaUsuario(usuario.IDUsuario)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
            Cursor = Cursors.Default
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub lblCerrarCaja_Click(sender As Object, e As EventArgs) Handles lblCerrarCaja.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.CERRAR_CAJA_Formulario__, AutorizacionRolList) Then
            Cursor = Cursors.WaitCursor
            If (Not IsNothing(GFichaUsuarios.IdPersona)) Then
                With frmCerrarCajaXUsuario
                    .UbicarCajaUsuario(GFichaUsuarios.IdPersona)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
            Cursor = Cursors.Default
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs) Handles ButtonAdv10.Click
        Try
            Dim fechaAnt = New Date(AnioGeneral, MesGeneral, 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If AutorizacionRolSA.TienePermiso(AsegurablesSistema.NUEVO__Formulario_OTROS_INGRESOS__, AutorizacionRolList) Then
                Cursor = Cursors.WaitCursor
                Dim f As New frmEntradaSalidaCaja(StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO)
                f.txtPeriodo.Value = New Date(AnioGeneral, CInt(MesGeneral), Date.Now.Day)
                f.lblMovimiento.Tag = "OEC"
                f.lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.txtTipoCambio.Value = TmpTipoCambio
                f.cboMesCompra.SelectedValue = MesGeneral
                f.cboMesCompra.Enabled = True
                f.TxtDia.Text = ""
                f.txtHora.Value = New Date(AnioGeneral, CInt(MesGeneral), Date.Now.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                Cursor = Cursors.Default
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonAdv1_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Try

            Dim fechaAnt = New Date(AnioGeneral, MesGeneral, 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If AutorizacionRolSA.TienePermiso(AsegurablesSistema.NUEVO_Formulario_SALIDA_ANTICIPO__, AutorizacionRolList) Then
                Cursor = Cursors.WaitCursor
                Dim f As New frmEntradaSalidaCaja(StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO)
                f.txtPeriodo.Value = New Date(AnioGeneral, CInt(MesGeneral), 1)
                f.lblMovimiento.Tag = "OSC"
                f.lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.txtTipoCambio.Value = TmpTipoCambio
                f.cboMesCompra.SelectedValue = MesGeneral
                f.cboMesCompra.Enabled = True
                '   f.txtDia.Value = New Date(AnioGeneral, CInt(MesGeneral), DiaLaboral.Day)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                Cursor = Cursors.Default
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistema.RECONOCIMIENTO_Y_ASIGNACIÓN_DE_INGRESOS__, AutorizacionRolList) Then

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Me.Cursor = Cursors.WaitCursor

        'If AutorizacionRolSA.TienePermiso(ModuloAsegurable.LISTA_PRECIOS, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")
        Dim f As New frmFormatosPlevb
        'f.Size = New Size(1040, 670) ' New Size(1340, 708)
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        'Else
        '    MessageBox.Show("Usuario no autorizado")
        'End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'ValidarFechaActual()
        'Timer2.Enabled = True
    End Sub
    Private Sub ButtonAdv20_Click(sender As Object, e As EventArgs) Handles ButtonAdv20.Click
        Dim cierreSA As New empresaCierreMensualSA
        Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            Dim fechaAnt = New Date(AnioGeneral, MesGeneral, 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                With frmVenta
                    .lblPerido.Text = MesGeneral & "/" & AnioGeneral
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        'Dim f As New frmMaestroSistemaUsers
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.Show()
    End Sub

    Private Sub SplitButton1_Click(sender As Object, e As EventArgs) Handles SplitButton1.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim f As New frmTableroGeneral
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
    End Sub
#End Region

    Private Sub ButtonAdv24_Click(sender As Object, e As EventArgs) Handles ButtonAdv24.Click
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistema.PANEL_PROYECTOS__, AutorizacionRolList) Then
        'MessageBox.Show("Usuario autorizado")
        Dim f As New frmMaestroGasto  'frmMasterpmo '  frmcentralProyectos ' frmCrearPaquetesTrabajo
        f.StartPosition = FormStartPosition.CenterParent
        ' f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        'Else
        'MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv25_Click(sender As Object, e As EventArgs) Handles ButtonAdv25.Click
        Dim f As New frmAsignaciondeServicios
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub
End Class
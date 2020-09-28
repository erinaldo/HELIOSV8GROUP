Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Public Class frmPantallaVendedorPOS

#Region "Attributes"
    Dim i As Integer = 0
    Public Property LightBox As HeliosLogin
    Public Property ConfiguracionInicioSA As New ConfiguracionInicioSA
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
    Private Property frmComprasMaestro As frmComprasMaestro
    Private Property frmExistenciaPrecios As frmExistenciaPrecios
    Private Property FormRegistroVentasXUsuario As FormRegistroVentasXUsuario

    Dim clienteSoftpack As clientesSoftPack
    Public Property empresaSPK As New List(Of clientesSoftPack)
    Private Property SelEstablecimiento As centrocosto
    Private Property EstablecimientoSA As New establecimientoSA
    Private Property SelEmpresa As empresa
    Private Property empresaSA As New empresaSA
    Private Property entidadSA As New entidadSA
    Private Property usuarioListSA As New Seguridad.WCFService.ServiceAccess.UsuarioSA
    Private Property cajaUsuarioSA As New cajaUsuarioSA
    Private FormPrecios As frmExistenciaPrecios
    Private Property formLogistica As FormMaestroLogistica
#End Region

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        splashControl1.SplashControlPanel.BorderType = SplashBorderType.None
        splashControl1.ShowDialogSplash(Me)
        splashControl1.AutoMode = False
        splashControl1.HostForm = Me
    End Sub

    Private Sub frmPantallaVendedorPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)
        Timer1.Enabled = True
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Close()
    End Sub

    Private Sub GetConfiguracionInicio()
        Dim tipoCambioSA As New tipoCambioSA
        Dim configuracion As New configuracionInicio
        Dim inicio = ConfiguracionInicioSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Dim anioSA As New empresaPeriodoSA


        Dim existeAnio = anioSA.GetUbicar_empresaPeriodoPorID(Gempresas.IdEmpresaRuc, Date.Now.Year, GEstableciento.IdEstablecimiento)
        If existeAnio Is Nothing Then
            Throw New Exception("Debe registrar un año válido")
        End If

        Dim tipoCambioDelDia = tipoCambioSA.ObtenerTipoCambioXfecha(Gempresas.IdEmpresaRuc, Date.Now.Date, GEstableciento.IdEstablecimiento)

        If tipoCambioDelDia Is Nothing Then
            'Agregar nueva instancia
            Throw New Exception("Debe registrar un tipo de cambio del día")

        Else
            'utilizar instancia recuperada
        End If




        If inicio Is Nothing Then
            'crear nueva instancia
            Throw New Exception("Debe registrar una configuración para empezar a trabajar")

        Else
            'actualizar instancia creada
        End If

        'Variables y etiquetas
        tmpConfigInicio = configuracion

        AnioGeneral = existeAnio.periodo
        MesGeneral = String.Format("{0:00}", inicio.mes)
        DiaLaboral = inicio.dia
        ButtonAdv4.Text = inicio.dia.Value.Day
        Dim DayName = WeekdayName(Weekday(inicio.dia))

        ButtonAdv3.Text = DayName
        PeriodoGeneral = String.Format("{0:00}", inicio.mes) & "/" & existeAnio.periodo

        TmpTipoCambio = 3
        TmpTipoCambioTransaccionCompra = 3
        TmpTipoCambioTransaccionVenta = 3
        TmpIGV = inicio.iva
        MontoMaximoCliente = inicio.montoMaximo

        'txtAnio.Value = New Date(existeAnio.periodo, Date.Now.Month, 1)
        'Label5.Text = "Período: " & String.Format("{0:00}", Date.Now.Month) & "/" & existeAnio.periodo
        'lblEmpresa.Text = Gempresas.NomEmpresa & " - " & Gempresas.IdEmpresaRuc
        'Label24.Text = GEstableciento.NombreEstablecimiento
        'lblNombreUsuario.Text = usuario.CustomUsuario.Full_Name
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


    Private Sub GetGlobalMapping()
        Dim LISTA As New List(Of centrocosto)
        SelEmpresa = empresaSA.UbicarEmpresaRuc(empresaSPK.FirstOrDefault.nroDoc)

        SelEstablecimiento = New centrocosto
        LISTA = EstablecimientoSA.ObtenerListaEstablecimientos(SelEmpresa.idEmpresa)

        SelEstablecimiento = (From I In LISTA
                              Where I.TipoEstab = "UN").FirstOrDefault

        Gempresas = New GEmpresa With
            {
            .IDProducto = "39",
            .IdEmpresaRuc = SelEmpresa.idEmpresa,
            .IDCliente = SelEmpresa.idclientespk,
            .NomCorto = SelEmpresa.nombreCorto,
            .NomEmpresa = SelEmpresa.razonSocial,
            .Ruc = SelEmpresa.ruc,
            .InicioOpeaciones = SelEmpresa.inicioOperacion,
            .Regimen = SelEmpresa.regimen
        }

        GEstableciento = New GEstablecimiento
        GEstableciento.IdEstablecimiento = SelEstablecimiento.idCentroCosto
        GEstableciento.NombreEstablecimiento = SelEstablecimiento.nombre

        UsuariosList = usuarioListSA.ListadoUsuariosv2()
        VarClienteGeneral = entidadSA.UbicarEntidadVarios("VR", General.Gempresas.IdEmpresaRuc, String.Empty, GEstableciento.IdEstablecimiento)
        ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
        'AnioGeneral = cboAnio.Text
        'MesGeneral = String.Format("{0:00}", Convert.ToInt32(Me.txtFechaInicio.Value.Month))
        'DiaLaboral = txtFechaInicio.Value
        'PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(Me.txtFechaInicio.Value.Month)) & "/" & cboAnio.Text
        'TmpTipoCambio = nudTipoCambioVenta.DecimalValue
        'TmpTipoCambioTransaccionCompra = nudTipoCambioCompra.DecimalValue
        'TmpTipoCambioTransaccionVenta = nudTipoCambioVenta.DecimalValue
        'TmpIGV = 18.0
        'MontoMaximoCliente = 699.0
    End Sub

    Private Sub ValidarRucCliente(ruc As String)
        empresaSPK = New List(Of clientesSoftPack)
        empresaSPK = ClientesSoftPackSA.GetEmpresasClientes(ruc)

    End Sub

    Private Sub FormLogeo()
        'LightBox = New HeliosLogin

        'LightBox.SetBounds(Left, Top, ClientRectangle.Width, ClientRectangle.Height)
        'LightBox.Owner = Me
        'LightBox.ShowDialog()
        'GetConfiguracionInicio()
        'If Not IsNothing(LightBox.Tag) Then
        '    If Not IsNothing(usuario) Then
        '        GradientPanel3.Enabled = True
        '        GradientPanel7.Enabled = True
        '        GradientPanel1.Enabled = True
        '        GradientPanel2.Enabled = True
        '        GradientPanel4.Enabled = True
        '        GradientPanel5.Enabled = True
        '    End If
        'Else
        '    MatarProceso("Helios.Cont.Presentation.WinForm")
        '    MatarProceso("SMSvcHost.exe")
        '    Application.ExitThread()
        '    Close()
        'End If

        Dim usuarioListSA As New UsuarioSA
        'LightBox = New HeliosLogin
        'FAlta jalar empresa por default


        ValidarRucCliente("20568825706")
        'ValidarRucCliente("20508447494") ' señora eli
        'ValidarRucCliente("10449245691")
        'ValidarRucCliente("20486529131")
        GetGlobalMapping()

        UsuariosList = usuarioListSA.ListadoUsuariosv2()
        'LightBox.SetBounds(Left, Top, ClientRectangle.Width, ClientRectangle.Height)
        'LightBox.Owner = Me
        'LightBox.ShowDialog()
        GetConfiguracionInicio()
        'If Not IsNothing(LightBox.Tag) Then
        If Not IsNothing(usuario) Then
            GradientPanel3.Enabled = True
            GradientPanel7.Enabled = True
            GradientPanel1.Enabled = True
            GradientPanel2.Enabled = True
            GradientPanel4.Enabled = True
            GradientPanel5.Enabled = True
        End If
        'Else
        '    MatarProceso("Helios.Cont.Presentation.WinForm")
        '    MatarProceso("SMSvcHost.exe")
        '    Application.ExitThread()
        '    Close()
        'End If


    End Sub

    'Private Sub FormLogeo()
    '    LightBox = New HeliosLogin

    '    LightBox.SetBounds(Left, Top, ClientRectangle.Width, ClientRectangle.Height)
    '    LightBox.Owner = Me
    '    LightBox.ShowDialog()
    '    GetConfiguracionInicio()
    '    If Not IsNothing(LightBox.Tag) Then
    '        If Not IsNothing(usuario) Then
    '            GradientPanel3.Enabled = True
    '            GradientPanel7.Enabled = True
    '            GradientPanel1.Enabled = True
    '            GradientPanel2.Enabled = True
    '            GradientPanel4.Enabled = True
    '            GradientPanel5.Enabled = True
    '        End If
    '    Else
    '        MatarProceso("Helios.Cont.Presentation.WinForm")
    '        MatarProceso("SMSvcHost.exe")
    '        Application.ExitThread()
    '        Close()
    '    End If

    'End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            i += 1000
            If i = 1000 Then
                i = 0
                Timer1.Stop()
                FormLogeo()
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
            Timer1.Stop()
            GradientPanel3.Enabled = False
            GradientPanel7.Enabled = False
            GradientPanel1.Enabled = False
            GradientPanel2.Enabled = False
            GradientPanel4.Enabled = False
            GradientPanel5.Enabled = False
            FormLogeo()
        End Try
    End Sub

    Private Sub frmPantallaVendedorPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            MatarProceso("Helios.Cont.Presentation.WinForm")
            MatarProceso("SMSvcHost.exe")
            Application.ExitThread()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        Try
            'Dim f As New FormVentaVendedorGeneral 'FormVendedorConStock
            'f.StartPosition = FormStartPosition.CenterScreen
            'f.Show(Me)
            Dim f As New FormVentaVendedorGeneral 'FormVendedorConStock
            f.chPedido.Checked = True
            f.TextComprador.Clear()
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show(Me)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Try
            FormLogeo()
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            GradientPanel3.Enabled = False
            GradientPanel7.Enabled = False
            GradientPanel1.Enabled = False
            GradientPanel2.Enabled = False
            GradientPanel4.Enabled = False
            GradientPanel5.Enabled = False
            FormLogeo()
        End Try
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormMaestroLogistica").SingleOrDefault
        If frm Is Nothing Then
            formLogistica = New FormMaestroLogistica
            formLogistica.StartPosition = FormStartPosition.CenterScreen
            formLogistica.Show(Me)
        Else
            formLogistica.WindowState = FormWindowState.Normal
            formLogistica.BringToFront()
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim f As New FormRegistroProformasXUsuario()
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        'Dim f As New frmFormularioCotizacion
        'f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.StartPosition = FormStartPosition.CenterParent
        'f.Show(Me)

        Dim f As New FormVendedorConStock ' frmVentaNuevoFormato
        'Select Case tmpConfigInicio.FormatoVenta
        'Case "MKT"
        '    f.RBProforma.Checked = True
        'Case Else
        f.inicioComprobante = "PROFORMA"
        ' End Select
        'f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
        f.StartPosition = FormStartPosition.CenterScreen
        ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.Show(Me)
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        'FormRegistroVentasXUsuario = New FormRegistroVentasXUsuario
        'FormRegistroVentasXUsuario.StartPosition = FormStartPosition.CenterParent
        'FormRegistroVentasXUsuario.ShowDialog()
        Dim f As New FormRegistroVentasXUsuario()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub lblNombreUsuario_Click(sender As Object, e As EventArgs) Handles lblNombreUsuario.Click

    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs)
        Dim f As New FormRegistroVentasXUsuario()
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ADMINISTRAR_PRECIOS__, AutorizacionRolList) Then
        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "frmExistenciaPrecios").SingleOrDefault
            If frm Is Nothing Then
            FormPrecios = New frmExistenciaPrecios
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
End Class
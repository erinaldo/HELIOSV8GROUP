Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports JNetFx.Framework.General
Imports Helios.General
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms
Imports System.IO
Imports Portable.Licensing
Imports Portable.Licensing.Validation
Imports System.Data.Entity.DbFunctions

Public Class HeliosLogin '
    Inherits frmMaster
    '20486529131
    ''' <summary>
    ''' True: Si es usuario de Caja, False: no tiene caja
    ''' </summary>
    ''' <returns></returns>

    Public Property empresaSPK As New List(Of clientesSoftPack)
    Private Property SelEmpresa As empresa
    Private Property SelEstablecimiento As centrocosto
    Private Property EstablecimientoSA As New establecimientoSA
    Private Property empresaSA As New empresaSA
    Dim clienteSoftpack As clientesSoftPack
    Public Delegate Sub _delegadoValidarRUCDNI()
    Private ULicense As Portable.Licensing.License
    '   Private Property SelCliente As New clientesSoftPack
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        HabilitarControles(True)
    End Sub


    Public Property ControlBounds() As Rectangle
        Get
            Return m_ControlBounds
        End Get
        Set(ByVal value As Rectangle)
            m_ControlBounds = value
        End Set
    End Property
    Private m_ControlBounds As Rectangle


    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Using brush As Brush = New SolidBrush(Color.FromArgb(30, Color.Black))
            e.Graphics.FillRectangle(brush, e.ClipRectangle)
        End Using
    End Sub


    Private Sub ValidarRUCDNICorrecto()
        If txtRUC.InvokeRequired Then
            Dim deleg As New _delegadoValidarRUCDNI(AddressOf ValidarRUCDNICorrecto)
            Invoke(deleg, New Object() {})
        Else
            ValidarRucCliente(txtRUC.Text.Trim)
        End If
    End Sub

    'Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    '    Using brush As Brush = New SolidBrush(Color.FromArgb(45, Color.WhiteSmoke))
    '        e.Graphics.FillRectangle(brush, e.ClipRectangle)
    '    End Using
    '    Me.Opacity = 68
    'End Sub

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Public Sub HabilitarUsoCaja(intIdUsuario As Integer)
        'Dim cajaUsuarioSA As New cajaUsuarioSA
        'Dim cajaUsuario As New cajaUsuario
        'Dim efSA As New EstadosFinancierosSA
        'Dim NEstadosSA As New estadosFinancieros


        'GFichaUsuarios = GFichaUsuario.InstanceSingle()
        'GFichaUsuarios.Clear()
        'Dim UsuarioEstadoCaja As New UsuarioEstadoCaja

        'cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(intIdUsuario, "A", "S", Nothing)

        'If Not IsNothing(cajaUsuario) Then
        '    With cajaUsuario
        '        NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaOrigen)
        '        GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
        '        GFichaUsuarios.IdPersona = .idPersona
        '        GFichaUsuarios.NombrePersona = usuario.Alias
        '        GFichaUsuarios.ClaveUsuario = .claveIngreso
        '        GFichaUsuarios.IdCajaOrigen = .idCajaOrigen
        '        GFichaUsuarios.IdCajaDestino = .idCajaOrigen
        '        GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
        '        GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
        '        GFichaUsuarios.FechaApertura = .fechaRegistro
        '        GFichaUsuarios.Moneda = .moneda
        '        GFichaUsuarios.TipoCambio = .tipoCambio
        '        GFichaUsuarios.FondoMN = .fondoMN
        '        GFichaUsuarios.FondoME = .fondoME
        '        GFichaUsuarios.EstadoCaja = .idcajaUsuario
        '        GFichaUsuarios.EnUso = .idcajaUsuario
        '        UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
        '    End With
        'Else
        '    'MessageBoxAdv.Show("No tiene asiganda una caja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    'Throw New Exception("No tiene asiganda una caja!")
        'End If


        ''With cajaUsuarioSA.UbicarCajaAsignadaUser(txtDni.Text.Trim, "A", "S", txtClave.Text.Trim)
        ''    NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaDestino)
        ''    GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
        ''    GFichaUsuarios.IdPersona = .idPersona
        ''    GFichaUsuarios.NombrePersona = txtPersona.Text.Trim
        ''    GFichaUsuarios.ClaveUsuario = .claveIngreso
        ''    GFichaUsuarios.IdCajaOrigen = .idCajaOrigen
        ''    GFichaUsuarios.IdCajaDestino = .idCajaDestino
        ''    GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
        ''    GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
        ''    GFichaUsuarios.FechaApertura = .fechaRegistro
        ''    GFichaUsuarios.Moneda = .moneda
        ''    GFichaUsuarios.TipoCambio = .tipoCambio
        ''    GFichaUsuarios.FondoMN = CDec(.fondoMN + (montoMNF))
        ''    GFichaUsuarios.FondoME = CDec(.fondoME + (montoMEF))
        ''    GFichaUsuarios.EstadoCaja = .idcajaUsuario
        ''    GFichaUsuarios.EnUso = .idcajaUsuario
        ''End With
        'Dispose()

        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario
        Dim efSA As New EstadosFinancierosSA
        Dim NEstadosSA As New estadosFinancieros


        GFichaUsuarios = GFichaUsuario.InstanceSingle()
        GFichaUsuarios.Clear()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja

        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(intIdUsuario, "A", "S", Nothing)

        '
        If Not IsNothing(cajaUsuario) Then
            With cajaUsuario
                'NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaOrigen)
                GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
                GFichaUsuarios.IdPersona = .idPersona
                GFichaUsuarios.NombrePersona = usuario.Alias
                GFichaUsuarios.ClaveUsuario = .claveIngreso
                GFichaUsuarios.IdCajaOrigen = .idCajaOrigen.GetValueOrDefault
                GFichaUsuarios.IdCajaDestino = .idCajaOrigen.GetValueOrDefault
                GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
                GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
                GFichaUsuarios.FechaApertura = .fechaRegistro
                GFichaUsuarios.Moneda = .moneda
                GFichaUsuarios.TipoCambio = .tipoCambio
                GFichaUsuarios.FondoMN = .fondoMN
                GFichaUsuarios.FondoME = .fondoME
                GFichaUsuarios.EstadoCaja = .estadoCaja
                GFichaUsuarios.EnUso = .idcajaUsuario
                UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
            End With
        Else
            'MessageBoxAdv.Show("No tiene asiganda una caja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Throw New Exception("No tiene asiganda una caja!")
        End If

        Dispose()
    End Sub


    Sub autenticar()

        Dim estado As Boolean
        Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
        Dim AutorizacionRolSA As New AutorizacionRolSA
        Dim VerificarCajaSA As New cajaUsuarioSA
        Dim UsuarioCompleto() As String, AliasUsuario As String 'IDCliente As String,
        SelEmpresa = New empresa
        clienteSoftpack = New clientesSoftPack

        If Not ValidarOK() Then Exit Sub

        usuario = New AutenticacionUsuario
        UsuarioCompleto = UsernameTextBox.Text.Trim.Split("\")
        If UsuarioCompleto.Length = 2 Then
            AliasUsuario = UsuarioCompleto(1).Trim
            ' IDCliente = UsuarioCompleto(0)
        Else
            AliasUsuario = UsernameTextBox.Text.Trim
            ' IDCliente = "GENERICO"
        End If
        usuario.Alias = AliasUsuario
        usuario.Contrasena = PasswordTextBox.Text.Trim
        usuario.IDCliente = empresaSPK.FirstOrDefault.idclientespk ' txtRUC.Text.Trim ' IDCliente
        SelEmpresa = empresaSA.UbicarEmpresaRuc(empresaSPK.FirstOrDefault.nroDoc)
        '  clienteSoftpack = ClientesSoftPackSA.GetEmpresasClientes("20392657020").FirstOrDefault
        clienteSoftpack = ClientesSoftPackSA.GetProductoClientesXID(empresaSPK.FirstOrDefault.idclientespk)
        If AutenticacionUsuarioSA.AutenticarUsuario(usuario) Then
            UserAccesoPermitido = True
            'Se supone que FORM1 es un MDI y que todos los formularios lo utilizan.
            AutenticacionUsuario = usuario

            'Se obtiene los permisos necesarios
            AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol})

            '  AutorizacionRolList = AutorizacionRolSA.GetAutorizacionesELI(New AutorizacionRol With {.IDCliente = SelEmpresa.idclientespk, .IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol})

            'Me.Close()

            estado = VerificarCajaSA.VerificarCajaEstadoXUsuario(usuario.IDUsuario)
            empresaSPK.FirstOrDefault.TieneCaja = estado
            usuario.TieneCaja = estado
            GetGlobalMapping()
            If usuario.TieneCaja = True Then
                Dim usuarioCaja = VerificarCajaSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If usuarioCaja IsNot Nothing Then
                    GetGlobalMappingCajaUsuario(usuarioCaja)
                Else
                    MessageBox.Show("Verificar la asiganción de cajas", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
            Tag = "Grabado"
        Else
            'MessageBox.Show("Usuario o clave incorrecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub GetGlobalMappingCajaUsuario(be As cajaUsuario)
        GFichaUsuarios = New GFichaUsuario
        GFichaUsuarios.IdCajaUsuario = be.idcajaUsuario
        GFichaUsuarios.IdPersona = usuario.IDUsuario
        GFichaUsuarios.NombrePersona = usuario.CustomUsuario.Nombres & ", " & usuario.CustomUsuario.ApellidoPaterno & " " & usuario.CustomUsuario.ApellidoMaterno
        GFichaUsuarios.ClaveUsuario = String.Empty
    End Sub

    Dim fso As New FeedbackForm
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        If txtRUC.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar el RUC", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If UsernameTextBox.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar un nombre de usuario válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If PasswordTextBox.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar una clave válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Me.SuspendLayout()
        fso = New FeedbackForm
        fso.StartPosition = FormStartPosition.CenterScreen
        fso.TopMost = True
        fso.Show()
        Me.ResumeLayout(True)
        fso.Refresh()
        ValidarRUCDNICorrecto()
        If empresaSPK.Count > 0 Then
            Call BackgroundWorker1.RunWorkerAsync()
        Else
            MessageBox.Show("Debe ingresar correctamente el RUC", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            fso.Dispose()
            txtRUC.Select()
            Exit Sub
        End If

        'Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
        'Dim AutorizacionRolSA As New AutorizacionRolSA
        'Dim UsuarioCompleto() As String, IDCliente As String, AliasUsuario As String

        'If Not ValidarOK() Then Exit Sub
        'Try
        '    usuario = New AutenticacionUsuario
        '    UsuarioCompleto = UsernameTextBox.Text.Trim.Split("\")
        '    If UsuarioCompleto.Length = 2 Then
        '        AliasUsuario = UsuarioCompleto(1).Trim
        '        IDCliente = UsuarioCompleto(0)
        '    Else
        '        AliasUsuario = UsernameTextBox.Text.Trim
        '        IDCliente = "GENERICO"
        '    End If
        '    usuario.Alias = AliasUsuario
        '    usuario.Contrasena = PasswordTextBox.Text.Trim
        '    usuario.IDCliente = IDCliente
        '    If AutenticacionUsuarioSA.AutenticarUsuario(usuario) Then

        '        UserAccesoPermitido = True
        '        'Se supone que FORM1 es un MDI y que todos los formularios lo utilizan.
        '        AutenticacionUsuario = usuario

        '        'Se obtiene los permisos necesarios
        '        AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol})
        '        'Me.Close()

        '        Dim lista = AutorizacionRolSA.GetListaAutorizacionesxPadre(New AutorizacionRol With {.IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol},
        '                                                                New Asegurable With {.IDCliente = IDCliente, .CodAsegurable = "EMPRESA"})


        '        If usuario.CustomUsuario.CustomUsuarioRol.IDRol = 1 Then

        '        ElseIf usuario.CustomUsuario.CustomUsuarioRol.IDRol = 2 Then

        '        ElseIf usuario.CustomUsuario.CustomUsuarioRol.IDRol = 3 Then
        '            HabilitarUsoCaja(usuario.IDUsuario)
        '        End If
        '        Tag = "Grabado"

        '        Dispose()

        '    Else
        '        UserAccesoPermitido = False

        '        '    Form1.Show()
        '        'frmSeleccionEmpresaMDI.AutenticacionUsuario = Nothing
        '        MessageBox.Show("Usuario y/o contraseña incorrecta")
        '    End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

    End Sub

    Private Function ValidarOK() As Boolean
        ValidarOK = True
        If UsernameTextBox.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(UsernameTextBox, "Ingrese alias de usuario")
            ValidarOK = False
        Else
            ErrorProvider1.SetError(UsernameTextBox, String.Empty)
        End If

        If PasswordTextBox.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(PasswordTextBox, "Ingrese contraseña")
            ValidarOK = False
        Else
            ErrorProvider1.SetError(PasswordTextBox, String.Empty)
        End If
    End Function

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        'UserAccesoPermitido = False
        'If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        usuario = Nothing
        MatarProceso("Helios.Cont.Presentation.WinForm")
        MatarProceso("SMSvcHost.exe")
        Application.ExitThread()
        'End If
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
    Private Sub HeliosLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If MessageBoxAdv.Show("S O F T - P A C K, ¿Desea salir?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '    MatarProceso("SMSvcHost.exe")
        '    Application.ExitThread()
        'Else
        '    UserAccesoPermitido = False
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub HeliosLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'txtRUC.Text = "10088331287"

        txtRUC.Focus()
        txtRUC.Select()
        GradientPanel1.Left = (Me.ClientSize.Width - GradientPanel1.Width) / 2
        GradientPanel1.Top = (Me.ClientSize.Height - GradientPanel1.Height) / 2
    End Sub

    Private Sub UsernameTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles UsernameTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            PasswordTextBox.Focus()
            PasswordTextBox.Select()
        End If
    End Sub

    Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UsernameTextBox.TextChanged

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        autenticar()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'fso.Close()
        fso.Dispose()
        Me.Enabled = True
        If Tag = "Grabado" Then

            If (empresaSPK.FirstOrDefault.TieneCaja = False) Then
                Close()
            ElseIf (empresaSPK.FirstOrDefault.TieneCaja = True) Then
                HabilitarUsoCaja(usuario.IDUsuario)
                Close()
            End If

            'If usuario.CustomUsuario.CustomUsuarioRol.IDRol = 1 Then

            'ElseIf usuario.CustomUsuario.CustomUsuarioRol.IDRol = 2 Then

            'ElseIf usuario.CustomUsuario.CustomUsuarioRol.IDRol = 3 Then
            '    HabilitarUsoCaja(usuario.IDUsuario)
            'ElseIf usuario.CustomUsuario.CustomUsuarioRol.IDRol = 4 Then
            '    HabilitarUsoCaja(usuario.IDUsuario)
            'End If

            'Dispose()
        Else
            MessageBox.Show("Verifique el ingreso correcto del Usuario o clave", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UsernameTextBox.Select()
        End If

    End Sub
    ''' <summary>
    ''' Fill Variables globales
    ''' </summary>
    Private Sub GetGlobalMapping()
        SelEstablecimiento = New centrocosto
        SelEstablecimiento = EstablecimientoSA.ObtenerListaEstablecimientos(SelEmpresa.idEmpresa).FirstOrDefault
        Gempresas = New GEmpresa With
            {
            .IDProducto = clienteSoftpack.IDProducto,
            .IdEmpresaRuc = SelEmpresa.idEmpresa,
            .IDCliente = SelEmpresa.idclientespk,
            .NomCorto = SelEmpresa.nombreCorto,
            .NomEmpresa = SelEmpresa.razonSocial,
            .Ruc = SelEmpresa.ruc,
            .InicioOpeaciones = SelEmpresa.inicioOperacion,
            .Regimen = SelEmpresa.regimen,
            .direccionEmpresa = SelEmpresa.direccion,
            .TelefonoEmpresa = SelEmpresa.telefono & "-" & SelEmpresa.celular,
            .departamento = SelEmpresa.departamento,
            .provincia = SelEmpresa.provincia,
            .distrito = SelEmpresa.distrito,
            .ubigeo = SelEmpresa.ubigeo
        }

        GEstableciento = New GEstablecimiento
        GEstableciento.IdEstablecimiento = SelEstablecimiento.idCentroCosto
        GEstableciento.NombreEstablecimiento = SelEstablecimiento.nombre
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
    Private Sub txtRUC_TextChanged(sender As Object, e As EventArgs) Handles txtRUC.TextChanged
        'If txtRUC.Text.Trim.Length = 11 Then
        '    '  ValidarRucCliente(txtRUC.Text.Trim)
        '    ValidarRUCDNICorrecto()
        'ElseIf txtRUC.Text.Trim.Length = 8 Then
        '    '  ValidarRucCliente(txtRUC.Text.Trim)
        '    ValidarRUCDNICorrecto()
        'Else
        '    txtRUC.ForeColor = Color.Black
        'End If
    End Sub

    Private Sub ValidarRucCliente(ruc As String)
        empresaSPK = New List(Of clientesSoftPack)
        empresaSPK = ClientesSoftPackSA.GetEmpresasClientes(ruc)
        If empresaSPK.Count = 1 Then
            txtRUC.ForeColor = Color.FromArgb(192, 0, 192)
        ElseIf empresaSPK.Count = 0 Then
            txtRUC.ForeColor = Color.Red
        Else
            txtRUC.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtRUC_LostFocus(sender As Object, e As EventArgs) Handles txtRUC.LostFocus
        'If txtRUC.Text.Trim.Length = 11 Then
        '    '  ValidarRucCliente(txtRUC.Text.Trim)
        '    ValidarRUCDNICorrecto()
        'ElseIf txtRUC.Text.Trim.Length = 8 Then
        '    '  ValidarRucCliente(txtRUC.Text.Trim)
        '    ValidarRUCDNICorrecto()
        'Else
        '    txtRUC.ForeColor = Color.Black
        'End If
    End Sub

    Private Sub txtRUC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRUC.KeyDown
        'Cursor = Cursors.WaitCursor
        'If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
        '    e.SuppressKeyPress = True
        '    txtRUC_LostFocus(sender, e)
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        'End If
    End Sub

    Private Sub HabilitarControles(v As Boolean)
        UsernameTextBox.Enabled = v
        PasswordTextBox.Enabled = v
        OK.Enabled = v
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        PanelLoading.Visible = True
        ProgressBar2.Visible = True
        ProgressBar2.Style = ProgressBarStyle.Marquee
        'Dim OfDLicense As New OpenFileDialog()
        'Dim LicStreamReader As StreamReader
        'Dim myStream As Stream = Nothing

        'OfDLicense.InitialDirectory = "c:\"
        'OfDLicense.Filter = "License (*.lic)|*.lic"
        'OfDLicense.FilterIndex = 1
        'OfDLicense.RestoreDirectory = True

        'If OfDLicense.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        Try
            'myStream = OfDLicense.OpenFile()
            'If (myStream IsNot Nothing) Then
            If File.Exists("C:\Users\Jiuni\Documents\juan.lic") Then
                ULicense = Portable.Licensing.License.Load(File.ReadAllText("C:\Users\Jiuni\Documents\juan.lic"))
                If ULicense.Expiration <= Date.Now Then
                    MessageBox.Show("Su periodo de prueba a vencido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TextBoxExt1.Text = "Licencia expirada"
                    HabilitarControles(False)
                Else
                    TextBoxExt1.Text = "Licencia verificada"
                    HabilitarControles(True)
                End If
                PanelLoading.Visible = False
            Else
                TextBoxExt1.Text = "Licencia no encontrada!"
                PanelLoading.Visible = False
                HabilitarControles(False)
            End If

            'End If
        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
        Finally
            ' Check this again, since we need to make sure we didn't throw an exception on open.
            'If (myStream IsNot Nothing) Then
            '    myStream.Close()
            'End If
        End Try
    End Sub
End Class

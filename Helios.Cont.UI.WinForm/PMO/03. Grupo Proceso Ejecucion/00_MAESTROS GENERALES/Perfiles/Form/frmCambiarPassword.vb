Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports JNetFx.Framework.General
Imports Helios.General
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms

Public Class frmCambiarPassword '
    Inherits frmMaster

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


    '   Private Property SelCliente As New clientesSoftPack
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

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

    Private Sub ValidarPasswordCorrecto()
        If txtNuevoPassword.InvokeRequired Then
            Dim deleg As New _delegadoValidarRUCDNI(AddressOf ValidarPasswordCorrecto)
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


    Sub autenticar()
        Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
        Dim AutenticacionUsuario As New AutenticacionUsuario

        AutenticacionUsuario.Alias = UsernameTextBox.Text
        AutenticacionUsuario.Contrasena = PasswordTextBox.Text
        AutenticacionUsuario.PasswordNuevo = txtNuevoPassword.Text
        AutenticacionUsuario.IDCliente = empresaSPK.FirstOrDefault.idclientespk

        'If Not ValidarOK() Then Exit Sub
        If AutenticacionUsuarioSA.CambiarContrasena(AutenticacionUsuario) Then
            Tag = "Grabado"
        Else
            Tag = Nothing
        End If
    End Sub

    Dim fso As New FeedbackForm
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        If txtNuevoPassword.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar nuevo password", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        If txtRepetirPassword.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar la clave", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtRUC.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar RUC/DNI correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Me.SuspendLayout()
        'fso = New FeedbackForm
        'fso.StartPosition = FormStartPosition.CenterScreen
        'fso.TopMost = True
        'fso.Show()
        'Me.ResumeLayout(True)
        'fso.Refresh()
        ValidarPasswordCorrecto()

        If txtRepetirPassword.Text = txtNuevoPassword.Text Then
            Call BackgroundWorker1.RunWorkerAsync()
        Else
            MessageBox.Show("Las contraseñas no coinciden", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'fso.Dispose()
            txtNuevoPassword.Select()
            txtNuevoPassword.Text = String.Empty
            txtRepetirPassword.Text = String.Empty
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

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        autenticar()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'fso.Close()
        fso.Dispose()
        Me.Enabled = True
        If Tag = "Grabado" Then

            'If (empresaSPK.Count <= 0) Then
            'MessageBox.Show("Verifique el ingreso correcto del Usuario o clave", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'Close()
            'ElseIf (empresaSPK.Count > 0) Then
            MessageBox.Show("Se actualizo la contraseña correctamente", "Felicitaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'HabilitarUsoCaja(usuario.IDUsuario)
            Close()
            'End If

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
            .Regimen = SelEmpresa.regimen
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
    Private Sub txtRUC_TextChanged(sender As Object, e As EventArgs) Handles txtNuevoPassword.TextChanged
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

    'Private Sub ValidarRucCliente(ruc As String)
    '    Dim autenticacionUsuarioBE As New AutenticacionUsuario
    '    Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
    '    Dim validadUsuario As Boolean
    '    autenticacionUsuarioBE.Alias = UsernameTextBox.Text
    '    autenticacionUsuarioBE.Contrasena = PasswordTextBox.Text

    '    validadUsuario = AutenticacionUsuarioSA.AutenticarUsuario(autenticacionUsuarioBE)
    '    If validadUsuario = True Then
    '        txtNuevoPassword.ForeColor = Color.FromArgb(192, 0, 192)
    '    ElseIf validadUsuario = False Then
    '        txtNuevoPassword.ForeColor = Color.Red
    '    Else
    '        txtNuevoPassword.ForeColor = Color.Black
    '    End If
    'End Sub

    Private Sub txtRUC_LostFocus(sender As Object, e As EventArgs) Handles txtNuevoPassword.LostFocus
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

    Private Sub PasswordTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PasswordTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNuevoPassword.Focus()
            txtNuevoPassword.Select()
        End If
    End Sub

    Private Sub txtNuevoPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNuevoPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtRepetirPassword.Focus()
            txtRepetirPassword.Select()
        End If
    End Sub

    Private Sub txtRUC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRUC.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            UsernameTextBox.Focus()
            UsernameTextBox.Select()
        End If
    End Sub
End Class

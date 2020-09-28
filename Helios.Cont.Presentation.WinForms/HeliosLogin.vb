Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports JNetFx.Framework.General
Imports Helios.General
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms

Public Class HeliosLogin
    Inherits frmMaster

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
            m_ControlBounds = Value
        End Set
    End Property
    Private m_ControlBounds As Rectangle


    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Using brush As Brush = New SolidBrush(Color.FromArgb(30, Color.Black))
            e.Graphics.FillRectangle(brush, e.ClipRectangle)
        End Using
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
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario
        Dim efSA As New EstadosFinancierosSA
        Dim NEstadosSA As New estadosFinancieros


        GFichaUsuarios = GFichaUsuario.InstanceSingle()
        GFichaUsuarios.Clear()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja

        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(intIdUsuario, "A", "S", Nothing)

        If Not IsNothing(cajaUsuario) Then
            With cajaUsuario
                NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaOrigen)
                GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
                GFichaUsuarios.IdPersona = .idPersona
                GFichaUsuarios.NombrePersona = usuario.Alias
                GFichaUsuarios.ClaveUsuario = .claveIngreso
                GFichaUsuarios.IdCajaOrigen = .idCajaOrigen
                GFichaUsuarios.IdCajaDestino = .idCajaOrigen
                GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
                GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
                GFichaUsuarios.FechaApertura = .fechaRegistro
                GFichaUsuarios.Moneda = .moneda
                GFichaUsuarios.TipoCambio = .tipoCambio
                GFichaUsuarios.FondoMN = .fondoMN
                GFichaUsuarios.FondoME = .fondoME
                GFichaUsuarios.EstadoCaja = .idcajaUsuario
                GFichaUsuarios.EnUso = .idcajaUsuario
                UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
            End With
        Else
            'MessageBoxAdv.Show("No tiene asiganda una caja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Throw New Exception("No tiene asiganda una caja!")
        End If

        
        'With cajaUsuarioSA.UbicarCajaAsignadaUser(txtDni.Text.Trim, "A", "S", txtClave.Text.Trim)
        '    NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaDestino)
        '    GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
        '    GFichaUsuarios.IdPersona = .idPersona
        '    GFichaUsuarios.NombrePersona = txtPersona.Text.Trim
        '    GFichaUsuarios.ClaveUsuario = .claveIngreso
        '    GFichaUsuarios.IdCajaOrigen = .idCajaOrigen
        '    GFichaUsuarios.IdCajaDestino = .idCajaDestino
        '    GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
        '    GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
        '    GFichaUsuarios.FechaApertura = .fechaRegistro
        '    GFichaUsuarios.Moneda = .moneda
        '    GFichaUsuarios.TipoCambio = .tipoCambio
        '    GFichaUsuarios.FondoMN = CDec(.fondoMN + (montoMNF))
        '    GFichaUsuarios.FondoME = CDec(.fondoME + (montoMEF))
        '    GFichaUsuarios.EstadoCaja = .idcajaUsuario
        '    GFichaUsuarios.EnUso = .idcajaUsuario
        'End With
        Dispose()
    End Sub


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
        Dim AutorizacionRolSA As New AutorizacionRolSA
        Dim UsuarioCompleto() As String, IDCliente As String, AliasUsuario As String

        If Not ValidarOK() Then Exit Sub
        Try
            usuario = New AutenticacionUsuario
            UsuarioCompleto = UsernameTextBox.Text.Trim.Split("\")
            If UsuarioCompleto.Length = 2 Then
                AliasUsuario = UsuarioCompleto(1).Trim
                IDCliente = UsuarioCompleto(0)
            Else
                AliasUsuario = UsernameTextBox.Text.Trim
                IDCliente = "GENERICO"
            End If
            usuario.Alias = AliasUsuario
            usuario.Contrasena = PasswordTextBox.Text.Trim
            usuario.IDCliente = IDCliente
            If AutenticacionUsuarioSA.AutenticarUsuario(usuario) Then

                UserAccesoPermitido = True
                'Se supone que FORM1 es un MDI y que todos los formularios lo utilizan.
                AutenticacionUsuario = usuario

                'Se obtiene los permisos necesarios
                AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol})
                'Me.Close()

                Dim lista = AutorizacionRolSA.GetListaAutorizacionesxPadre(New AutorizacionRol With {.IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol},
                                                                        New Asegurable With {.IDCliente = IDCliente, .CodAsegurable = "EMPRESA"})


                If usuario.CustomUsuario.CustomUsuarioRol.IDRol = 1 Then

                ElseIf usuario.CustomUsuario.CustomUsuarioRol.IDRol = 2 Then

                ElseIf usuario.CustomUsuario.CustomUsuarioRol.IDRol = 3 Then
                    HabilitarUsoCaja(usuario.IDUsuario)
                End If
                Dispose()

            Else
                UserAccesoPermitido = False

                '    Form1.Show()
                'frmSeleccionEmpresaMDI.AutenticacionUsuario = Nothing
                MessageBox.Show("Usuario y/o contraseña incorrecta")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

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
        MatarProceso("SMSvcHost.exe")
        Application.ExitThread()
        'End If
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
        UsernameTextBox.Focus()
        UsernameTextBox.Select()
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
End Class

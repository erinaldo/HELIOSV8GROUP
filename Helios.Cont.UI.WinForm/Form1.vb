
Imports Helios.Cont.Business.Entity

'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class Form1


    Public Shared AutenticacionUsuario As AutenticacionUsuario
    Public Shared AutorizacionRolList As List(Of AutorizacionRol)

    Public Enum Asegurable 'Los códigos son los que están asignados en la BD
        Seguridad = 1
        AltaUsuario = 2
        UsuarioEnRol = 3
    End Enum

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim AsientoSA = New AsientoSA()
        DataGridView1.AutoGenerateColumns = True
        DataGridView1.DataSource = AsientoSA.ObtenerListaAsientos()
    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '    HeliosLogin.ShowDialog(Me)
    End Sub

    Private Sub btnOpcion1_Click(sender As System.Object, e As System.EventArgs) Handles btnOpcion1.Click
        If AutorizacionRolSA.TienePermiso(Asegurable.Seguridad, AutorizacionRolList) Then
            MessageBox.Show("Usuario autorizado")
        Else
            MessageBox.Show("Usuario no autorizado")
        End If
    End Sub

    Private Sub btnOpcion2_Click(sender As System.Object, e As System.EventArgs) Handles btnOpcion2.Click
        If AutorizacionRolSA.TienePermiso(Asegurable.AltaUsuario, AutorizacionRolList) Then
            MessageBox.Show("Usuario autorizado")
        Else
            MessageBox.Show("Usuario no autorizado")
        End If
    End Sub

    Private Sub btnOpcion3_Click(sender As System.Object, e As System.EventArgs) Handles btnOpcion3.Click
        If AutorizacionRolSA.TienePermiso(Asegurable.UsuarioEnRol, AutorizacionRolList) Then
            MessageBox.Show("Usuario autorizado")
        Else
            MessageBox.Show("Usuario no autorizado")
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If AutorizacionRolSA.TienePermiso(10, AutorizacionRolList) Then 'Prueba cuando el código no está configurado en BD
            MessageBox.Show("Usuario autorizado")
        Else
            MessageBox.Show("Usuario no autorizado")
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        With frmSeleccionEmpresaMDI
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim Usuario As New AutenticacionUsuario
        Usuario.CustomUsuario = New Usuario

        With Usuario.CustomUsuario
            .Action = Helios.Seguridad.Business.Entity.BaseBE.EntityAction.INSERT
            .ApellidoPaterno = "Hinostroza"
            .ApellidoMaterno = "Inga"
            .IDCliente = "GENERICO"
            .Nombres = "Jagner"
            .TipoDocumento = ""
            .NroDocumento = ""
            .CorreoElectronico = ""
            .UsuarioActualizacion = "yo"
            .FechaActualizacion = Date.Now
        End With

        With Usuario
            .Action = Helios.Seguridad.Business.Entity.BaseBE.EntityAction.INSERT
            .Alias = "42629130"
            .Contrasena = "123445"
            .CorreoElectronico = ""
            .EstaAutenticado = True
            .FechaActualizacion = Date.Now
            .PreguntaSecreta = ""
            .RespuestaSecreta = ""
            .UltimaFechaCambioPassword = Date.Now
            .UltimaFechaLogueo = Date.Now
            .UsuarioActualizacion = "yo"
        End With

        Usuario.CustomUsuario.CustomUsuarioRol = New UsuarioRol
        With Usuario.CustomUsuario.CustomUsuarioRol
            .Action = Helios.Seguridad.Business.Entity.BaseBE.EntityAction.INSERT
            .IDRol = 2
            .UsuarioActualizacion = "yo"
            .FechaActualizacion = Date.Now
        End With

        Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
        AutenticacionUsuarioSA.AutenticacionUsuarioGrabarTodo(Usuario)
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim ProyectoSA = New ProyectoPlaneacionSA
        Dim prject As New ProyectoPlaneacion()
        prject.Action = Business.Entity.BaseBE.EntityAction.INSERT
        prject.idEmpresa = "A1"
        prject.idEstablecimiento = 1
        prject.nombreProyecto = "PROJECT A"
        '  prject.descripcion = "PROJECT A"
        prject.responsable = "1"
        '   ProyectoSA.GrabarProyecto(prject)
    End Sub
End Class

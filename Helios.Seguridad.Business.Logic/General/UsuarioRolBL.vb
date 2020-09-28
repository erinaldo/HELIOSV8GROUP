Imports Helios.Seguridad.Business.Entity
Imports System.Transactions
Public Class UsuarioRolBL
    Inherits BaseBL


    Public Function InserRoleUser(objRol As UsuarioRol) As UsuarioRol
        Try
            Using ts As New TransactionScope

                Dim consulta = (From i In SeguridadData.UsuarioRol Where i.IDRol = objRol.IDRol And
                                                                       i.IDUsuario = objRol.IDUsuario).Count


                If consulta = 0 Then


                    SeguridadData.UsuarioRol.Add(objRol)
                    SeguridadData.SaveChanges()
                    ts.Complete()

                Else
                    Throw New Exception("Este Cargo ya fue asignado a este usuario")
                End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objRol
    End Function

    Public Function GetListaUsuariosXPerfil() As List(Of UsuarioRol)
        Dim obj As New UsuarioRol
        Dim lista As New List(Of UsuarioRol)

        Dim consulta = (From ur In SeguridadData.UsuarioRol
                        Select
                            ur.Usuario.Nombres,
                            ur.Usuario.ApellidoPaterno,
                            ur.Usuario.ApellidoMaterno,
                            IDUsuario = CType(ur.Usuario.IDUsuario, Int32?),
                            ur.Usuario.IDCliente,
                            ur.Rol.Nombre,
                            ur.FechaActualizacion).ToList

        For Each i In consulta
            obj = New UsuarioRol
            obj.IDUsuario = i.IDUsuario
            obj.IdCliente = i.IDCliente
            obj.nombreUsuario = i.Nombres + " " + i.ApellidoPaterno + " " + i.ApellidoMaterno
            obj.nombrePerfil = i.Nombre
            obj.FechaActualizacion = i.FechaActualizacion

            lista.Add(obj)
        Next


        Return lista
    End Function

    Public Function GetListaUsuariosXPerfilXCliente(ClienteID As String) As List(Of UsuarioRol)
        Dim obj As New UsuarioRol
        Dim lista As New List(Of UsuarioRol)

        Dim consulta = (From ur In SeguridadData.UsuarioRol
                        Join rol In SeguridadData.Rol On New With {ur.IDRol} Equals New With {rol.IDRol}
                        Where
                            ur.Usuario.IDCliente = ClienteID
                        Select
                            ur.IDUsuario,
                            ur.IDRol,
                            ur.UsuarioActualizacion,
                            ur.FechaActualizacion,
                            Column1 = CType(ur.Usuario.IDUsuario, Int32?),
                            ur.Usuario.IDCliente,
                            ur.Usuario.Nombres,
                            ur.Usuario.ApellidoPaterno,
                            ur.Usuario.ApellidoMaterno,
                            ur.Usuario.TipoDocumento,
                            ur.Usuario.NroDocumento,
                            ur.Usuario.CorreoElectronico,
                            Column2 = ur.Usuario.UsuarioActualizacion,
                            Column3 = CType(ur.Usuario.FechaActualizacion, DateTime?),
                            Column4 = rol.IDRol,
                                                     rol.Nombre,
                            rol.Descripcion,
                            Column6 = rol.UsuarioActualizacion,
                            Column7 = rol.FechaActualizacion).ToList

        For Each i In consulta
            obj = New UsuarioRol
            obj.IDUsuario = i.IDUsuario
            obj.IdCliente = i.IDCliente
            obj.nombreUsuario = i.Nombres + " " + i.ApellidoPaterno + " " + i.ApellidoMaterno
            obj.nombrePerfil = i.Nombre
            obj.FechaActualizacion = i.FechaActualizacion

            lista.Add(obj)
        Next


        Return lista
    End Function

    Public Function GetListaUsuariosXPerfilAndPassword(ClienteID As String) As List(Of UsuarioRol)
        Dim obj As New UsuarioRol
        Dim lista As New List(Of UsuarioRol)
        Dim encriptador As New JNetFx.Framework.General.Cryptography


        Dim consulta = (From UR In SeguridadData.UsuarioRol
                        Join AUTENTICACION In SeguridadData.AutenticacionUsuario On New With {UR.IDUsuario} Equals New With {AUTENTICACION.IDUsuario}
                        Where
                            UR.Usuario.IDCliente = ClienteID
                        Select
                            UR.Usuario.IDCliente,
                            UR.Usuario.IDUsuario,
                            UR.Usuario.Nombres,
                            UR.Usuario.ApellidoPaterno,
                            UR.Usuario.ApellidoMaterno,
                            UR.Usuario.FechaActualizacion,
                            NombrePerfil = UR.Rol.Nombre,
                            AUTENTICACION.Alias,
                            AUTENTICACION.Contrasena).ToList

        For Each i In consulta
            obj = New UsuarioRol
            obj.IDUsuario = i.IDUsuario
            obj.IdCliente = i.IDCliente
            obj.nombreUsuario = i.Nombres + " " + i.ApellidoPaterno + " " + i.ApellidoMaterno
            obj.nombrePerfil = i.NombrePerfil
            obj.aliasUsuario = i.Alias
            obj.password = (i.Contrasena)
            obj.FechaActualizacion = i.FechaActualizacion

            lista.Add(obj)
        Next


        Return lista
    End Function

    Public Function GetListaCargosXPerfilAndPassword(autorizacionRolBE As AutenticacionUsuario) As List(Of UsuarioRol)
        Dim obj As New UsuarioRol
        Dim lista As New List(Of UsuarioRol)
        Dim encriptador As New JNetFx.Framework.General.Cryptography
        Dim autenticacionBL As New AutenticacionUsuarioBL

        Dim resultadoAutenticacion = autenticacionBL.EsUsuarioAutenticadoLogin(New AutenticacionUsuario With {.IdEmpresa = autorizacionRolBE.IdEmpresa, .IDEstablecimiento = autorizacionRolBE.IDEstablecimiento _
                                                                               , .Alias = autorizacionRolBE.Alias, .Contrasena = autorizacionRolBE.Contrasena})



        'For Each i In resultadoAutenticacion.CustomUsuario.CustomListaUsuarioRol
        '    obj = New UsuarioRol
        '    obj.IDUsuario = i.IDUsuario
        '    obj.IDRol = i.IDRol
        '    obj.nombrePerfil = i.nombrePerfil
        '    obj.predeterminado = i.predeterminado

        '    lista.Add(obj)
        'Next


        Return lista
    End Function

    Public Function updateEstadoRoleUser(objRol As UsuarioRol) As UsuarioRol
        Try
            Using ts As New TransactionScope

                Dim consulta = (From i In SeguridadData.UsuarioRol Where i.IDRol = objRol.IDRol And
                                                                       i.IDUsuario = objRol.IDUsuario).FirstOrDefault


                If Not IsNothing(consulta) Then

                    consulta.estado = objRol.estado
                    SeguridadData.SaveChanges()
                    ts.Complete()

                Else
                    Throw New Exception("Verificar Datos")
                End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objRol
    End Function

End Class

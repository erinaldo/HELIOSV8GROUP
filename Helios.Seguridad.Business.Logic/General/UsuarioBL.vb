Imports Helios.Seguridad.Business.Entity
Imports System.Transactions

Public Class UsuarioBL
    Inherits BaseBL

    Public Function UpdateCargoXID(usuario As Usuario) As Usuario
        Dim obj As New Usuario


        Dim consulta = (From s In SeguridadData.Usuario
                        Where s.IDUsuario = usuario.IDUsuario
                        Select s).FirstOrDefault

        If (Not IsNothing(consulta)) Then
            consulta.idCargo = usuario.idCargo
            SeguridadData.SaveChanges()
        End If

        Return usuario
    End Function

    Public Function GetUpdateUsuario(objRol As Usuario) As Usuario
        Try
            Using ts As New TransactionScope

                Dim consulta = (From i In SeguridadData.Usuario Where i.IDUsuario = objRol.IDUsuario).First()

                If consulta IsNot Nothing Then




                    If objRol.idUsuarioResponsable IsNot Nothing Then

                        consulta.idUsuarioResponsable = objRol.idUsuarioResponsable


                    End If


                    SeguridadData.SaveChanges()
                    ts.Complete()

                    Return consulta
                Else
                    Throw New Exception("no Se puede actualizar")
                End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub Insert(ByVal usuario As Usuario)

        SeguridadData.Usuario.Add(usuario)
        SeguridadData.AutenticacionUsuario.Add(usuario.AutenticacionUsuario)

        Using ts As New TransactionScope
            SeguridadData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub Update(ByVal usuario As Usuario)
        SeguridadData.Usuario.Attach(usuario)
        'SeguridadData.ObjectStateManager.GetObjectStateEntry(usuario).ChangeState(EntityState.Modified)
        SeguridadData.SaveChanges()
    End Sub

    Public Function ListadoUsuarios() As List(Of Usuario)
        Dim obj As New Usuario
        Dim lista As New List(Of Usuario)

        Dim consulta = (From s In SeguridadData.Usuario.Include("UsuarioRol")
                        Select s).ToList

        For Each i In consulta
            obj = New Usuario
            obj.IDUsuario = i.IDUsuario
            obj.IDCliente = i.IDCliente
            obj.Nombres = i.Nombres
            obj.ApellidoPaterno = i.ApellidoPaterno
            obj.ApellidoMaterno = i.ApellidoMaterno
            obj.TipoDocumento = i.TipoDocumento
            obj.NroDocumento = i.NroDocumento
            obj.CorreoElectronico = i.CorreoElectronico
            obj.Rol = i.UsuarioRol(0).IDRol
            'Select Case i.UsuarioRol(0).IDRol
            '    Case 1
            '        obj.Rol = "Administrador"
            '    Case 2
            '        obj.Rol = "Usuario básico"
            '    Case 3
            '        obj.Rol = "Cajero"
            'End Select
            lista.Add(obj)
        Next


        Return lista
    End Function


    Public Function ListadoUsuariosSoloCargoNoResp(be As Usuario) As List(Of Usuario)
        Dim obj As New Usuario
        Dim lista As New List(Of Usuario)

        Dim consulta = (From s In SeguridadData.Usuario
                        Join i In SeguridadData.UsuarioRol On s.IDUsuario Equals i.IDUsuario
                        Where s.idUsuarioResponsable = 0 And i.IDRol = be.IDRol
                        Select
                            s.IDUsuario,
                             idclie = s.IDCliente,
                            s.Nombres,
                            s.ApellidoPaterno,
                            s.ApellidoMaterno,
                            s.TipoDocumento,
                            s.NroDocumento,
                            s.estado,
                            s.codigo,
                            s.CorreoElectronico,
                           i.IDRol,
                            nombrecargo = (From h In SeguridadData.Rol
                                           Where h.IDRol = i.IDRol
                                           Select h.Descripcion).FirstOrDefault
                            ).ToList

        For Each i In consulta
            obj = New Usuario
            obj.IDUsuario = i.IDUsuario


            obj.IDCliente = i.idclie


            obj.Nombres = i.Nombres
            obj.ApellidoPaterno = i.ApellidoPaterno
            obj.ApellidoMaterno = i.ApellidoMaterno
            obj.TipoDocumento = i.TipoDocumento
            obj.NroDocumento = i.NroDocumento
            obj.estado = i.estado
            obj.codigo = i.codigo
            obj.CorreoElectronico = i.CorreoElectronico
            'obj.Rol = i.UsuarioRol(0).IDRol
            obj.idCargo = i.IDRol
            obj.nombrecargo = i.nombrecargo
            'Select Case i.UsuarioRol(0).IDRol
            '    Case 1
            '        obj.Rol = "Administrador"
            '    Case 2
            '        obj.Rol = "Usuario básico"
            '    Case 3
            '        obj.Rol = "Cajero"
            'End Select
            lista.Add(obj)
        Next


        Return lista
    End Function

    Public Function ListadoUsuariosConResponsable(be As Usuario) As List(Of Usuario)
        Dim obj As New Usuario
        Dim lista As New List(Of Usuario)

        Dim consulta = (From s In SeguridadData.Usuario
                        Join i In SeguridadData.UsuarioRol On i.IDUsuario Equals s.IDUsuario
                        Where s.idUsuarioResponsable = be.idUsuarioResponsable And i.IDRol = be.IDRol
                        Select
                            s.IDUsuario,
                             idclie = s.IDCliente,
                            s.Nombres,
                                               s.ApellidoPaterno,
                            s.ApellidoMaterno,
                            s.TipoDocumento,
                            s.NroDocumento,
                            s.estado,
                            s.codigo,
                            s.CorreoElectronico,
                            i.IDRol,
                            nombrecargo = (From h In SeguridadData.Rol
                                           Where h.IDRol = i.IDRol
                                           Select h.Descripcion).FirstOrDefault
                            ).ToList

        For Each i In consulta
            obj = New Usuario
            obj.IDUsuario = i.IDUsuario


            obj.IDCliente = i.idclie


            obj.Nombres = i.Nombres
            obj.ApellidoPaterno = i.ApellidoPaterno
            obj.ApellidoMaterno = i.ApellidoMaterno
            obj.TipoDocumento = i.TipoDocumento
            obj.NroDocumento = i.NroDocumento
            obj.estado = i.estado
            obj.codigo = i.codigo
            obj.CorreoElectronico = i.CorreoElectronico
            'obj.Rol = i.UsuarioRol(0).IDRol
            obj.idCargo = i.IDRol
            obj.nombrecargo = i.nombrecargo
            'Select Case i.UsuarioRol(0).IDRol
            '    Case 1
            '        obj.Rol = "Administrador"
            '    Case 2
            '        obj.Rol = "Usuario básico"
            '    Case 3
            '        obj.Rol = "Cajero"
            'End Select
            lista.Add(obj)
        Next


        Return lista
    End Function


    Public Function ListadoUsuariosXclienteCargo(usuarioBE As Usuario) As List(Of Usuario)
        'Dim obj As New Usuario
        'Dim lista As New List(Of Usuario)

        'Dim consulta = (From s In SeguridadData.Usuario
        '                Select
        '                    s.IDUsuario,
        '                     idclie = s.IDCliente,
        '                    s.Nombres,
        '                    s.ApellidoPaterno,
        '                    s.ApellidoMaterno,
        '                    s.TipoDocumento,
        '                    s.NroDocumento,
        '                    s.estado,
        '                    s.codigo,
        '                    s.CorreoElectronico,
        '                    s.idCargo,
        '                    nombrecargo = (From i In SeguridadData.jerarquiaCargo
        '                                   Where i.idCargo = s.idCargo
        '                                   Select i.descripcion).FirstOrDefault
        '                    ).ToList

        'For Each i In consulta
        '    obj = New Usuario
        '    obj.IDUsuario = i.IDUsuario


        '    obj.IDCliente = i.idclie


        '    obj.Nombres = i.Nombres
        '    obj.ApellidoPaterno = i.ApellidoPaterno
        '    obj.ApellidoMaterno = i.ApellidoMaterno
        '    obj.TipoDocumento = i.TipoDocumento
        '    obj.NroDocumento = i.NroDocumento
        '    obj.estado = i.estado
        '    obj.codigo = i.codigo
        '    obj.CorreoElectronico = i.CorreoElectronico
        '    'obj.Rol = i.UsuarioRol(0).IDRol
        '    obj.idCargo = i.idCargo
        '    obj.nombrecargo = i.nombrecargo
        '    'Select Case i.UsuarioRol(0).IDRol
        '    '    Case 1
        '    '        obj.Rol = "Administrador"
        '    '    Case 2
        '    '        obj.Rol = "Usuario básico"
        '    '    Case 3
        '    '        obj.Rol = "Cajero"
        '    'End Select
        '    lista.Add(obj)
        'Next


        'Return lista
    End Function

    Public Function ListadoUsuariosXcliente(IDCliente As String) As List(Of Usuario)
        Dim obj As New Usuario
        Dim lista As New List(Of Usuario)

        Dim consulta = (From s In SeguridadData.Usuario.Include("UsuarioRol")
                        Where s.IDCliente = IDCliente
                        Select s).ToList

        For Each i In consulta
            obj = New Usuario
            obj.IDUsuario = i.IDUsuario
            obj.IDCliente = i.IDCliente
            obj.Nombres = i.Nombres
            obj.ApellidoPaterno = i.ApellidoPaterno
            obj.ApellidoMaterno = i.ApellidoMaterno
            obj.TipoDocumento = i.TipoDocumento
            obj.NroDocumento = i.NroDocumento
            obj.estado = i.estado
            obj.codigo = i.codigo
            obj.CorreoElectronico = i.CorreoElectronico
            obj.Rol = i.UsuarioRol(0).IDRol
            'Select Case i.UsuarioRol(0).IDRol
            '    Case 1
            '        obj.Rol = "Administrador"
            '    Case 2
            '        obj.Rol = "Usuario básico"
            '    Case 3
            '        obj.Rol = "Cajero"
            'End Select
            lista.Add(obj)
        Next


        Return lista
    End Function

    Public Function ListadoUsuariosconteo() As Integer
        Dim obj As New Usuario
        Dim lista As New List(Of Usuario)

        Dim consulta = (From s In SeguridadData.Usuario _
                       Join rol In SeguridadData.UsuarioRol _
                       On s.IDUsuario Equals rol.IDUsuario _
                       Where rol.IDRol = 3 _
                       Select s).Count

        Return consulta
    End Function

    Public Function ListadoUsuariosPuntoVenta(usuarioRol As UsuarioRol) As List(Of Usuario)
        Dim obj As New Usuario
        Dim lista As New List(Of Usuario)

        Dim consulta = (From s In SeguridadData.Usuario _
                        Join rol In SeguridadData.UsuarioRol _
                        On s.IDUsuario Equals rol.IDUsuario _
                        Where rol.IDRol = usuarioRol.IDRol _
                        Select s).ToList

        For Each i In consulta
            obj = New Usuario
            obj.IDUsuario = i.IDUsuario
            obj.IDCliente = i.IDCliente
            obj.Nombres = i.Nombres
            obj.ApellidoPaterno = i.ApellidoPaterno
            obj.ApellidoMaterno = i.ApellidoMaterno
            obj.TipoDocumento = i.TipoDocumento
            obj.NroDocumento = i.NroDocumento
            obj.CorreoElectronico = i.CorreoElectronico
            obj.UsuarioActualizacion = i.UsuarioActualizacion
            obj.FechaActualizacion = i.FechaActualizacion
            lista.Add(obj)
        Next
        Return lista
    End Function

    'Public Function UbicarUsuarioXnombre(valorNombre As String) As List(Of Usuario)
    '    Dim consulta = (From s In SeguridadData.Usuario _
    '                    Where s.Nombres.Contains(valorNombre) _
    '                    Select s).ToList
    '    Return consulta
    'End Function
    Public Function UbicarUsuarioXid(usuario As Usuario)
        Dim consulta = (From s In SeguridadData.Usuario _
                        Where s.IDUsuario = usuario.IDUsuario).FirstOrDefault
        Return consulta
    End Function

    Public Function UbicarUsuarioCaja(usuario As Usuario)
        Dim obj As New Usuario
        Dim consulta = (From i In SeguridadData.Usuario _
                        Join a In SeguridadData.AutenticacionUsuario _
                        On i.IDUsuario Equals a.IDUsuario
                        Where i.IDUsuario = usuario.IDUsuario).First

        If (Not IsNothing(consulta)) Then
            obj = New Usuario
            obj.IDUsuario = consulta.i.IDUsuario
            obj.IDCliente = consulta.i.IDCliente
            obj.Nombres = consulta.i.Nombres
            obj.ApellidoPaterno = consulta.i.ApellidoPaterno
            obj.ApellidoMaterno = consulta.i.ApellidoMaterno
            obj.TipoDocumento = consulta.i.TipoDocumento
            obj.NroDocumento = consulta.i.NroDocumento
            obj.CorreoElectronico = consulta.i.CorreoElectronico
            obj.UsuarioActualizacion = consulta.i.UsuarioActualizacion
            obj.FechaActualizacion = consulta.i.FechaActualizacion
            obj.userName = consulta.a.Alias
            'obj.password = consulta.a.Contrasena
        End If

        Return obj
    End Function

    Public Sub DeletePersonaXCaja(ByVal usuarioBE As Usuario)
        Using ts As New TransactionScope

            Dim autenticacion As AutenticacionUsuario = SeguridadData.AutenticacionUsuario.Where(Function(o) o.IDUsuario = usuarioBE.IDUsuario).First
            CType(SeguridadData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(autenticacion)

            Dim usuarioRol As UsuarioRol = SeguridadData.UsuarioRol.Where(Function(o) o.IDUsuario = usuarioBE.IDUsuario).First
            CType(SeguridadData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(usuarioRol)

            Dim consulta As Usuario = SeguridadData.Usuario.Where(Function(o) o.IDUsuario = usuarioBE.IDUsuario).First
            CType(SeguridadData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            SeguridadData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UpdateUsuarioXID(usuario As Usuario) As Usuario
        Dim obj As New Usuario


        Dim consulta = (From s In SeguridadData.Usuario
                        Where s.IDUsuario = usuario.IDUsuario
                        Select s).FirstOrDefault

        If (Not IsNothing(consulta)) Then
            consulta.estado = usuario.estado
            SeguridadData.SaveChanges()
        End If

        Return usuario
    End Function

    Public Function UpdateUsuarioCodigoAsignado(usuario As Usuario) As Usuario
        Dim obj As New Usuario
        Try
            Dim consultaCodigo = (From s In SeguridadData.Usuario
                                  Where s.codigo = usuario.codigo
                                  Select s).FirstOrDefault

            If (IsNothing(consultaCodigo)) Then
                Dim consulta = (From s In SeguridadData.Usuario
                                Where s.IDUsuario = usuario.IDUsuario
                                Select s).FirstOrDefault

                If (Not IsNothing(consulta)) Then
                    consulta.codigo = usuario.codigo
                    SeguridadData.SaveChanges()
                End If
            Else
                Throw New Exception("Existe el codigo - Elija otro!")
            End If
        Catch ex As Exception
            Throw ex
        End Try


        Return usuario
    End Function

    Public Function ListadoUsuariosv2() As List(Of Usuario)
        Dim obj As New Usuario
        Dim lista As New List(Of Usuario)
        Dim listRole As New List(Of UsuarioRol)

        Dim consulta = (From s In SeguridadData.Usuario.Include("UsuarioRol").Include("AutenticacionUsuario")
                        Select s).ToList

        For Each i In consulta
            listRole = New List(Of UsuarioRol)
            obj = New Usuario
            obj.IDUsuario = i.IDUsuario
            obj.IDCliente = i.IDCliente
            obj.Nombres = i.Nombres
            obj.ApellidoPaterno = i.ApellidoPaterno
            obj.ApellidoMaterno = i.ApellidoMaterno
            obj.TipoDocumento = i.TipoDocumento
            obj.NroDocumento = i.NroDocumento
            obj.CorreoElectronico = i.CorreoElectronico
            obj.codigo = i.codigo
            obj.estado = i.estado
            obj.CustomUsuarioRol = New UsuarioRol
            obj.CustomUsuarioRol.IDRol = i.UsuarioRol(0).IDRol
            obj.CustomUsuarioRol.IDUsuario = i.UsuarioRol(0).IDUsuario
            obj.Rol = i.UsuarioRol(0).IDRol
            obj.IDRol = i.UsuarioRol(0).IDRol
            obj.idCargo = i.UsuarioRol(0).IDRol
            obj.idUsuarioResponsable = i.idUsuarioResponsable

            For Each k In i.UsuarioRol

                Dim ob As New UsuarioRol
                ob.IDRol = k.IDRol
                ob.IDUsuario = k.IDUsuario
                ob.FechaActualizacion = k.FechaActualizacion
                ob.UsuarioActualizacion = k.UsuarioActualizacion
                Dim role = (From z In SeguridadData.Rol Where z.IDRol = k.IDRol Select z).SingleOrDefault
                If role IsNot Nothing Then
                    ob.nombrePerfil = role.Nombre
                    ob.tipoEF = role.tipoEF
                    ob.estado = k.estado
                End If
                listRole.Add(ob)
            Next
            obj.UsuarioRol = listRole
            'Select Case i.UsuarioRol(0).IDRol
            '    Case 1
            '        obj.Rol = "Administrador"
            '    Case 2
            '        obj.Rol = "Usuario básico"
            '    Case 3
            '        obj.Rol = "Cajero"
            'End Select
            obj.CustomAutenticacionUsuario = New AutenticacionUsuario
            obj.CustomAutenticacionUsuario.Alias = i.AutenticacionUsuario(0).Alias.ToUpper
            obj.CustomAutenticacionUsuario.Contrasena = i.AutenticacionUsuario(0).Contrasena
            lista.Add(obj)
        Next


        Return lista
    End Function

End Class

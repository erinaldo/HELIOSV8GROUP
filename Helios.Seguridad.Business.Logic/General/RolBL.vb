Imports Helios.Seguridad.Business.Entity
Imports System.Transactions

Public Class RolBL
    Inherits BaseBL

    'Public Function CrearRol()


    Public Function UpdateRole(objRol As Rol) As Rol
        Try
            Using ts As New TransactionScope

                Dim consulta = (From i In SeguridadData.Rol Where i.IDRol = objRol.IDRol).First()

                If consulta IsNot Nothing Then


                    consulta.Nombre = objRol.Nombre

                    If objRol.idPadre IsNot Nothing Then

                        consulta.idPadre = objRol.idPadre


                    End If


                    SeguridadData.SaveChanges()
                    ts.Complete()

                Else
                    Throw New Exception("no Se puede actualizar")
                End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objRol
    End Function

    Public Function RolSearch(be As Rol) As Rol

        Try

            Dim consulta = (From i In SeguridadData.Rol
                            Where i.IDRol = be.IDRol).FirstOrDefault

            Return consulta

        Catch ex As Exception

        End Try

    End Function


    Public Function RoleList(bjCargo As Rol) As List(Of Rol)
        Try
            Dim rolBE As New Rol
            Dim listaRol As New List(Of Rol)

            'Dim consulta = (From i In SeguridadData.Rol Join x In SeguridadData.RolXGrupoEmp On i.IDRol Equals x.IDRol Where x.IDReferencia = bjCargo.IDEstablecimiento And i.control = "UN").ToList
            Dim consulta = (From i In SeguridadData.Rol).ToList
            For Each objRol In consulta
                rolBE = New Rol

                rolBE.IDRol = objRol.IDRol
                rolBE.[Nombre] = objRol.[Nombre]
                rolBE.[Descripcion] = objRol.[Descripcion]
                rolBE.idPadre = objRol.idPadre
                rolBE.tipo = objRol.tipo
                rolBE.control = objRol.control
                'rolBE.IDEmpresa = objRol.x.ID
                'rolBE.IDEstablecimiento = objRol.x.IDReferencia
                rolBE.[UsuarioActualizacion] = objRol.[UsuarioActualizacion]
                rolBE.[FechaActualizacion] = objRol.[FechaActualizacion]

                listaRol.Add(rolBE)
            Next

            Return listaRol

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RoleListXUnidOrg(bjCargo As Rol) As List(Of Rol)
        Try
            Dim rolBE As New Rol
            Dim listaRol As New List(Of Rol)

            Dim consulta = (From i In SeguridadData.Rol Where bjCargo.listaID.Contains(i.IDRol)).ToList

            For Each objRol In consulta
                rolBE = New Rol

                rolBE.IDRol = objRol.IDRol
                rolBE.[Nombre] = objRol.[Nombre]
                rolBE.[Descripcion] = objRol.[Descripcion]
                rolBE.idPadre = objRol.idPadre
                rolBE.tipo = objRol.tipo
                rolBE.control = objRol.control
                rolBE.[UsuarioActualizacion] = objRol.[UsuarioActualizacion]
                rolBE.[FechaActualizacion] = objRol.[FechaActualizacion]

                listaRol.Add(rolBE)
            Next

            Return listaRol

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RoleListSingle(bjCargo As Rol) As List(Of Rol)
        Try
            Dim rolBE As New Rol
            Dim listaRol As New List(Of Rol)
            Dim lista As New List(Of String)

            lista.Add("GR")
            'lista.Add("UN")


            Dim consulta = (From i In SeguridadData.Rol Where lista.Contains(i.control)).ToList

            For Each objRol In consulta
                rolBE = New Rol

                rolBE.IDRol = objRol.IDRol
                rolBE.[Nombre] = objRol.[Nombre]
                rolBE.[Descripcion] = objRol.[Descripcion]
                rolBE.idPadre = objRol.idPadre
                rolBE.tipo = objRol.tipo
                rolBE.control = objRol.control
                rolBE.[UsuarioActualizacion] = objRol.[UsuarioActualizacion]
                rolBE.[FechaActualizacion] = objRol.[FechaActualizacion]

                listaRol.Add(rolBE)
            Next

            Return listaRol

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RoleRegister(objRol As Rol) As Rol
        Try

            Using ts As New TransactionScope

                Dim consulta = (From i In SeguridadData.Rol Where i.Nombre = objRol.Nombre _
                                                                                                          And i.idEmpresa = objRol.idEmpresa).Count


                If consulta = 0 Then

                    Dim conteo = (From be In SeguridadData.Rol Select be Where be.control = "SA").Count

                    If (conteo >= 0) Then

                        SeguridadData.Rol.Add(objRol)


                        SeguridadData.SaveChanges()

                        ts.Complete()
                    End If


                Else
                    Throw New Exception("El nombre del cargo ya existe")
                End If


            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return objRol

    End Function

    Public Function RoleRegisterSingle(objRol As Rol) As Rol
        Try
            Using ts As New TransactionScope

                Dim consulta = (From i In SeguridadData.Rol Where i.Nombre = objRol.Nombre _
                                                                                                          And i.idEmpresa = objRol.idEmpresa).Count


                If consulta = 0 Then

                    'Dim conteo = (From be In SeguridadData.Rol Select be Where be.control = "SA").Count

                    'If (conteo >= 0) Then

                    SeguridadData.Rol.Add(objRol)
                    SeguridadData.SaveChanges()

                    'Dim IDRol = objRol.IDRol
                    'objRolGRupoEmpBE = New RolXGrupoEmp
                    'objRolGRupoEmpBE.IDRol = IDRol
                    'objRolGRupoEmpBE.IDPadre = Nothing
                    'objRolGRupoEmpBE.descripcion = Nothing
                    'objRolGRupoEmpBE.IDReferencia = objRol.i
                    'objRolGRupoEmpBE.tipo = "UN"
                    'objRolGRupoEmpBE.estado = True
                    'objRolGRupoEmpBE.UsuarioActualizacion = "ADMINISTRADOR"
                    'objRolGRupoEmpBE.FechaActualizacion = DateTime.Now

                    'rolGRupoEmpBL.GetInserRolesXgrupoEmpSingle(objRolGRupoEmpBE)


                    ts.Complete()
                    'End If


                Else
                    Throw New Exception("El nombre del cargo ya existe")
                End If


            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return objRol

    End Function

    Public Function RolInsertSingle(objRol As Rol) As Rol
        Try

            Dim objRolGRupoEmpBE As Rol
            Using ts As New TransactionScope

                Dim consulta = (From i In SeguridadData.Rol Where i.Nombre = objRol.Nombre And i.control = "GR").Count


                If consulta = 0 Then

                    'Dim conteo = (From be In SeguridadData.Rol Select be Where be.control = "SA").Count

                    'If (conteo >= 0) Then

                    objRolGRupoEmpBE = New Rol

                    objRolGRupoEmpBE.idPadre = objRol.idPadre
                    objRolGRupoEmpBE.Nombre = objRol.Nombre
                    objRolGRupoEmpBE.Descripcion = objRol.Nombre
                    objRolGRupoEmpBE.idEmpresa = objRol.idEmpresa
                    objRolGRupoEmpBE.tipo = objRol.tipo
                    objRolGRupoEmpBE.tipoEF = objRol.tipoEF
                    objRolGRupoEmpBE.control = objRol.control
                    objRolGRupoEmpBE.UsuarioActualizacion = "ADMINISTRADOR"
                    objRolGRupoEmpBE.FechaActualizacion = DateTime.Now

                    SeguridadData.Rol.Add(objRolGRupoEmpBE)
                    SeguridadData.SaveChanges()

                    ts.Complete()
                    'End If


                Else
                    Throw New Exception("El nombre del cargo ya existe")
                End If


            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return objRol

    End Function

    Public Function GetRoles() As List(Of Rol)
        Return SeguridadData.Rol.ToList()
        Try

            Dim rolBE As New Rol
            Dim listaRol As New List(Of Rol)

            Dim consulta = (From i In SeguridadData.Rol).ToList

            For Each item In consulta
                rolBE = New Rol
                rolBE.IDRol = item.IDRol
                rolBE.idEmpresa = item.idEmpresa
                rolBE.[Nombre] = item.[Nombre]
                rolBE.[Descripcion] = item.[Descripcion]
                rolBE.tipo = item.tipo
                rolBE.tipoEF = item.tipoEF
                rolBE.idPadre = item.idPadre
                rolBE.[UsuarioActualizacion] = item.[UsuarioActualizacion]
                rolBE.[FechaActualizacion] = item.[FechaActualizacion]

                listaRol.Add(rolBE)
            Next

            Return listaRol

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetRolesXcliente(ByVal Rol As Rol) As List(Of Rol)
        Try

            Dim rolBE As New Rol
            Dim listaRol As New List(Of Rol)

            Dim consulta = (From i In SeguridadData.Rol Where i.idEmpresa = Rol.idEmpresa).ToList

            For Each item In consulta
                rolBE = New Rol
                rolBE.IDRol = item.IDRol
                rolBE.[Descripcion] = item.[Descripcion]
                rolBE.idEmpresa = item.idEmpresa
                rolBE.idPadre = item.idPadre
                rolBE.[UsuarioActualizacion] = item.[UsuarioActualizacion]
                rolBE.[FechaActualizacion] = item.[FechaActualizacion]

                listaRol.Add(rolBE)
            Next

            Return listaRol

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetRolesXEstablecimiento(ByVal Rol As Rol) As List(Of Rol)
        Try
            'Dim Consulta = SeguridadData.Rol.Where(Function(o) o.IDEmpresa = Rol.IDEmpresa And o.IDEstablecimiento = Rol.IDEstablecimiento).ToList()
            Dim rolBE As New Rol
            Dim listaRol As New List(Of Rol)

            If (Rol.control = "SA") Then
                Dim consulta = (From a In SeguridadData.Rol.Where(Function(o) o.idEmpresa = Rol.idEmpresa).ToList)

                For Each item In consulta
                    rolBE = New Rol With {
                    .IDRol = item.IDRol,
                    .[Nombre] = item.[Nombre],
                    .[Descripcion] = item.[Descripcion],
                    .idEmpresa = item.idEmpresa,
                    .idPadre = item.idPadre,
                    .control = item.control,
                    .[UsuarioActualizacion] = item.[UsuarioActualizacion],
                    .[FechaActualizacion] = item.[FechaActualizacion]
                    }

                    listaRol.Add(rolBE)

                Next

            ElseIf (Rol.control = "GR") Then
                Dim consulta = (From a In SeguridadData.Rol.ToList)


                For Each item In consulta
                    rolBE = New Rol With {
                          .IDRol = item.IDRol,
                                .[Nombre] = item.[Nombre],
                    .[Descripcion] = item.[Descripcion],
                    .idEmpresa = item.idEmpresa,
                       .idPadre = item.idPadre,
                               .control = item.control,
                    .[UsuarioActualizacion] = item.[UsuarioActualizacion],
                    .[FechaActualizacion] = item.[FechaActualizacion]
                    }

                    listaRol.Add(rolBE)

                Next
            End If



            Return listaRol
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateGrupo(ByVal usuarios As List(Of Usuario), ByVal rol As Rol)
        Dim RolUsuarioBE As UsuarioRol
        Dim objUsuario As Usuario
        For Each Usuario In usuarios
            objUsuario = Usuario
            Select Case Usuario.Action
                Case BaseBE.EntityAction.INSERT
                    RolUsuarioBE = New UsuarioRol With {.IDRol = rol.IDRol, .IDUsuario = objUsuario.IDUsuario}
                    SeguridadData.UsuarioRol.Add(RolUsuarioBE)
                Case BaseBE.EntityAction.DELETE
                    RolUsuarioBE = (From be In SeguridadData.UsuarioRol Where be.IDUsuario = objUsuario.IDUsuario And be.IDRol = rol.IDRol)
                    'SeguridadData.de(RolUsuarioBE)
            End Select
        Next

        Using ts As New TransactionScope
            SeguridadData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function GetInserRoles(objRol As Rol) As Rol
        Try
            Using ts As New TransactionScope

                'Dim consulta = (From i In SeguridadData.Rol Where i.idCargo = objRol.idCargo And i.IDEmpresa = objRol.IDEmpresa And i.IDEstablecimiento = objRol.IDEstablecimiento).Count
                Dim consulta = (From i In SeguridadData.Rol).Count

                If consulta = 0 Then

                    Dim conteo = (From be In SeguridadData.Rol Select be).Count

                    If (conteo >= 0) Then
                        objRol.IDRol = conteo + 1
                        SeguridadData.Rol.Add(objRol)
                        SeguridadData.SaveChanges()
                        ts.Complete()
                    End If
                Else
                    Throw New Exception("El cargo ya tienes permiso Creado")
                End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objRol
    End Function

    Public Function GetInserRolSingle(objRol As Rol) As Rol
        Try
            Using ts As New TransactionScope

                Dim consulta = (From i In SeguridadData.Rol Where i.Nombre = objRol.Nombre And i.idEmpresa = objRol.idEmpresa).Count
                'Dim consulta = (From i In SeguridadData.Rol).Count

                If consulta = 0 Then

                    Dim conteo = (From be In SeguridadData.Rol Select be).Count

                    If (conteo >= 0) Then
                        objRol.IDRol = conteo + 1
                        SeguridadData.Rol.Add(objRol)
                        SeguridadData.SaveChanges()
                        ts.Complete()
                    End If
                Else
                    Throw New Exception("El cargo ya tienes permiso Creado")
                End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objRol
    End Function

    Public Function ListadoRolesXID(idRol As Integer) As Rol
        Dim RolBE As Rol
        Try
            RolBE = (From be In SeguridadData.Rol Where be.IDRol = idRol).FirstOrDefault
            Return RolBE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListadoRolesClienteXID(rol As Rol) As Rol
        Dim RolBE As Rol
        Try
            RolBE = (From be In SeguridadData.Rol Where be.IDRol = rol.IDRol).FirstOrDefault
            Return RolBE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUpdateRol(ByVal ObjRol As Rol)
        Try

            Using ts As New TransactionScope

                Dim rolBE As Rol = (From be In SeguridadData.Rol Where be.IDRol = ObjRol.IDRol).FirstOrDefault

                If (Not IsNothing(rolBE)) Then
                    rolBE.Nombre = ObjRol.Nombre
                    rolBE.Descripcion = ObjRol.Descripcion
                    SeguridadData.SaveChanges()
                    ts.Complete()
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

End Class
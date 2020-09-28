Imports Helios.Seguridad.Business.Entity
Imports System.Transactions

Public Class AutorizacionRolBL
    Inherits BaseBL



    Public Function GetAsegurableXRolDesactivo(ByVal item As AutorizacionRol) As List(Of AutorizacionRol)

        Dim objeto As AutorizacionRol
        Dim lista As New List(Of AutorizacionRol)


        Dim consulta = (From padre In SeguridadData.AutorizacionRol
                        Join i In SeguridadData.Asegurable On padre.IDAsegurable Equals i.IDAsegurable
                        Where padre.IDRol = item.IDRol And i.IDEmpresa And i.IDEstablecimiento = item.IDEstablecimiento).ToList

        For Each i In consulta
            objeto = New AutorizacionRol

            objeto.IDAsegurable = i.padre.IDAsegurable
            objeto.IDRol = i.padre.IDRol
            objeto.IDModulo = i.padre.IDModulo
            objeto.EstaAutorizado = i.padre.EstaAutorizado
            objeto.Descripcion = i.i.Descripcion
            objeto.Nombre = i.i.Nombre

            lista.Add(objeto)

        Next

        Return lista
    End Function


    Public Function GetAsegurableXRol(ByVal item As AutorizacionRol) As List(Of AutorizacionRol)

        Dim lista = GetAsegurableSoloRol(item).Union(GetAsegurableSistema(item)).ToList
        Return lista
    End Function

    Public Function GetAsegurableSoloRol(ByVal item As AutorizacionRol) As List(Of AutorizacionRol)

        Dim objeto As AutorizacionRol
        Dim lista As New List(Of AutorizacionRol)


        Dim consulta = (From padre In SeguridadData.AutorizacionRol
                        Join i In SeguridadData.Asegurable On padre.IDAsegurable Equals i.IDAsegurable
                        Where padre.IDRol = item.IDRol And i.IDEmpresa = item.IdEmpresa And
                            i.IDEstablecimiento = item.IDEstablecimiento).ToList

        For Each i In consulta
            objeto = New AutorizacionRol

            objeto.IDAsegurable = i.padre.IDAsegurable
            'objeto.IDRolXGrupoEmp = i.padre.IDRolXGrupoEmp
            objeto.IDRol = i.padre.IDRol
            objeto.EstaAutorizado = i.padre.EstaAutorizado
            objeto.Descripcion = i.i.Descripcion
            objeto.Nombre = i.i.Nombre
            objeto.IDModulo = i.i.IDModulo

            lista.Add(objeto)

        Next

        Return lista
    End Function


    Public Function GetAsegurableSistema(ByVal item As AutorizacionRol) As List(Of AutorizacionRol)

        Dim objeto As AutorizacionRol
        Dim lista As New List(Of AutorizacionRol)


        Dim consulta = (From padre In SeguridadData.Asegurable
                        Where padre.IDEmpresa = item.IdEmpresa And padre.IDEstablecimiento = item.IDEstablecimiento).ToList

        For Each i In consulta
            objeto = New AutorizacionRol
            objeto.IDModulo = i.IDModulo
            objeto.IDAsegurable = i.IDAsegurable
            objeto.Descripcion = i.Descripcion
            objeto.Nombre = i.Nombre
            lista.Add(objeto)

        Next

        Return lista
    End Function

    Public Sub GetUpdateAutorizacion(be As AutorizacionRol)
        Dim obj = SeguridadData.AutorizacionRol.Where(Function(o) o.IDRol = be.IDRol And
                                                          o.IDAsegurable = be.IDAsegurable).FirstOrDefault

        obj.EstaAutorizado = be.EstaAutorizado
        '  SeguridadData.AutorizacionRol.Attach(obj)
        SeguridadData.SaveChanges()
    End Sub

    Public Sub GetUpdateAutorizacionXcliente(be As AutorizacionRol)
        Dim obj = SeguridadData.AutorizacionRol.Where(Function(o) o.IDRol = be.IDRol And
                                                          o.IDAsegurable = be.IDAsegurable).FirstOrDefault

        obj.EstaAutorizado = be.EstaAutorizado
        '  SeguridadData.AutorizacionRol.Attach(obj)
        SeguridadData.SaveChanges()
    End Sub




    Public Sub EliminarPermisoRol(ByVal be As AutorizacionRol)
        Dim consulta = (From i In SeguridadData.AutorizacionRol
                        Where i.IDAsegurable = be.IDAsegurable And i.IDRol = be.IDRol And
                            i.IDUsuario = be.IDUsuario And i.IDModulo = be.IDModulo).FirstOrDefault

        If Not consulta Is Nothing Then

            be.Action = BaseBE.EntityAction.DELETE
            'InsertItem(be)

            Using ts As New TransactionScope

                CType(SeguridadData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)

                'scope.DBContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                SeguridadData.SaveChanges()
                ts.Complete()
            End Using
        Else
            Throw New Exception("El permiso no se pudo eliminar.")
        End If
    End Sub

    Public Sub RegistrarPermisoRol(ByVal be As AutorizacionRol)


        Dim consulta = (From i In SeguridadData.AutorizacionRol
                        Where i.IDAsegurable = be.IDAsegurable And
                             i.IDRol = be.IDRol).FirstOrDefault

        If consulta Is Nothing Then


            be.Action = BaseBE.EntityAction.INSERT
            InsertItem(be)
        Else

            Throw New Exception("El permiso ya esta activo.")
        End If


    End Sub

    Public Sub InsertItem(ByVal Asegurables As AutorizacionRol)
        Select Case Asegurables.Action
            Case BaseBE.EntityAction.INSERT
                SeguridadData.AutorizacionRol.Add(Asegurables)
            Case BaseBE.EntityAction.UPDATE
                SeguridadData.AutorizacionRol.Attach(Asegurables)
                'SeguridadData.ObjectStateManager.GetObjectStateEntry(AutorizacionRol).ChangeState(EntityState.Modified)
            Case BaseBE.EntityAction.DELETE
                SeguridadData.AutorizacionRol.Remove(Asegurables)
                'IDRol = AutorizacionRol.IDRol
                'IDAsegurable = AutorizacionRol.IDAsegurable
                'AutorizacionRolBE = (From be In SeguridadData.AutorizacionRol
                '                     Where be.IDRol = IDRol And be.IDAsegurable = IDAsegurable).Single
                'SeguridadData.Delete(AutorizacionRolBE)
        End Select
        Using ts As New TransactionScope
            SeguridadData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateGrupo(ByVal Asegurables As List(Of AutorizacionRol))
        Dim AutorizacionRolBE As AutorizacionRol
        Dim IDRol As Integer, IDAsegurable As Integer
        For Each AutorizacionRol In Asegurables
            Select Case AutorizacionRol.Action
                Case BaseBE.EntityAction.INSERT
                    SeguridadData.AutorizacionRol.Add(AutorizacionRol)
                Case BaseBE.EntityAction.UPDATE
                    SeguridadData.AutorizacionRol.Attach(AutorizacionRol)
                    'SeguridadData.ObjectStateManager.GetObjectStateEntry(AutorizacionRol).ChangeState(EntityState.Modified)
                Case BaseBE.EntityAction.DELETE
                    IDRol = AutorizacionRol.IDRol
                    IDAsegurable = AutorizacionRol.IDAsegurable
                    AutorizacionRolBE = (From be In SeguridadData.AutorizacionRol
                                         Where be.IDRol = IDRol And be.IDAsegurable = IDAsegurable).Single
                    'SeguridadData.Delete(AutorizacionRolBE)
            End Select
        Next
        Using ts As New TransactionScope
            SeguridadData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertarListaAsegurables(productoAquirido As List(Of Asegurable), idRol As Integer, IDUsuario As Integer)
        Dim autorizacionRol As New AutorizacionRol
        Using ts As New TransactionScope
            For Each i In productoAquirido
                autorizacionRol = New AutorizacionRol With
                    {
                    .Action = BaseBE.EntityAction.INSERT,
                    .IDRol = idRol,
                    .IDUsuario = IDUsuario,
                    .IDAsegurable = i.IDAsegurable,
                    .IDModulo = i.IDModulo,
                    .IDProducto = 39,
                    .EstaAutorizado = True,
                    .UsuarioActualizacion = "Sistema",
                    .FechaActualizacion = Date.Now
                    }
                InsertItem(autorizacionRol)
            Next
            SeguridadData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetAutorizacionesByRol(ByVal be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim o As New AutorizacionRol
        Dim lista As New List(Of AutorizacionRol)
        Dim IDRol As Integer
        IDRol = be.IDRol

        Dim consulta = (From obj In SeguridadData.AutorizacionRol
                        Join rol In SeguridadData.Rol
                        On rol.IDRol Equals obj.IDRol
                        Join aseg In SeguridadData.Asegurable
                        On aseg.IDAsegurable Equals obj.IDAsegurable
                        Where obj.IDRol = IDRol).ToList

        For Each i In consulta
            o = New AutorizacionRol
            o.IDAsegurable = i.obj.IDAsegurable
            o.Nomasegurable = i.aseg.Nombre
            o.Categoria = i.aseg.Descripcion
            o.EstaAutorizado = i.obj.EstaAutorizado
            lista.Add(o)
        Next
        Return lista
    End Function

    Public Function GetAutorizacionesRolXcliente(ByVal be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim o As New AutorizacionRol
        Dim lista As New List(Of AutorizacionRol)
        Dim IDRol As Integer
        IDRol = be.IDRol

        Dim consulta = (From obj In SeguridadData.AutorizacionRol
                        Join rol In SeguridadData.Rol
                        On rol.IDRol Equals obj.IDRol
                        Join aseg In SeguridadData.Asegurable
                        On aseg.IDAsegurable Equals obj.IDAsegurable And aseg.IDEmpresa Equals obj.IdEmpresa And aseg.IDEstablecimiento Equals obj.IDEstablecimiento
                        Where obj.IDRol = IDRol And obj.IdEmpresa = be.IdEmpresa And obj.IDEstablecimiento = be.IDEstablecimiento).ToList

        For Each i In consulta
            o = New AutorizacionRol
            o.IDAsegurable = i.obj.IDAsegurable
            o.Nomasegurable = i.aseg.Nombre
            o.Categoria = i.aseg.Descripcion
            o.EstaAutorizado = i.obj.EstaAutorizado
            lista.Add(o)
        Next
        Return lista
    End Function

    Public Function GetAutorizacionesRolXProducto(ByVal be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim o As New AutorizacionRol
        Dim lista As New List(Of AutorizacionRol)
        Dim IDRol As Integer
        IDRol = be.IDRol

        Dim consulta = (From obj In SeguridadData.AutorizacionRol
                        Join rol In SeguridadData.Rol
                        On rol.IDRol Equals obj.IDRol
                        Join aseg In SeguridadData.Asegurable
                        On aseg.IDAsegurable Equals obj.IDAsegurable
                        Where obj.IDRol = IDRol _
                            And obj.IDProducto = be.IDProducto).ToList

        For Each i In consulta
            o = New AutorizacionRol
            o.IDAsegurable = i.obj.IDAsegurable
            o.Nomasegurable = i.aseg.Nombre
            o.Categoria = i.aseg.Descripcion
            o.EstaAutorizado = i.obj.EstaAutorizado
            lista.Add(o)
        Next
        Return lista
    End Function

    Public Function GetAutorizacionesELI(ByVal be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim obj As New AutorizacionRol
        Dim IDRol As Integer
        IDRol = be.IDRol

        Dim consulta = (From autoriza In SeguridadData.AutorizacionRol
                        Where autoriza.IDRol = IDRol).ToList

        GetAutorizacionesELI = New List(Of AutorizacionRol)
        For Each i In consulta
            obj = New AutorizacionRol With
                {
                .IDRol = i.IDRol,
                .IDAsegurable = i.IDAsegurable,
                           .IDProducto = i.IDProducto,
                .EstaAutorizado = i.EstaAutorizado,
                .UsuarioActualizacion = i.UsuarioActualizacion,
                .FechaActualizacion = i.FechaActualizacion
                }
            GetAutorizacionesELI.Add(obj)
        Next
        'Return (From obj In SeguridadData.AutorizacionRol
        '        Where obj.IDRol = IDRol And obj.IDUsuario = be.IDUsuario).ToList

    End Function

    Public Function GetAllByRol(ByVal be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim obj As New AutorizacionRol
        Dim IDRol As Integer
        IDRol = be.IDRol
        Dim IDRolGrupoEmp As Integer
        'IDRolGrupoEmp = be.IDRolXGrupoEmp

        Dim consulta = (From autoriza In SeguridadData.AutorizacionRol
                        Join det In SeguridadData.Asegurable
                            On det.IDAsegurable Equals autoriza.IDAsegurable
                        Where autoriza.IDRol = IDRol And
                            autoriza.IDUsuario = be.IDUsuario And det.IDEmpresa = be.IdEmpresa And
                            det.IDEstablecimiento = be.IDEstablecimiento).ToList

        GetAllByRol = New List(Of AutorizacionRol)
        For Each i In consulta
            obj = New AutorizacionRol With
                {
                .IDRol = i.autoriza.IDRol,
                .IDAsegurable = i.autoriza.IDAsegurable,
                .IDModulo = i.autoriza.IDModulo,
                               .IDProducto = i.autoriza.IDProducto,
                .Formulario = i.det.CodRef,
                .Nomasegurable = i.det.Nombre,
                .EstaAutorizado = i.autoriza.EstaAutorizado,
                .UsuarioActualizacion = i.autoriza.UsuarioActualizacion,
                .FechaActualizacion = i.autoriza.FechaActualizacion
                }
            GetAllByRol.Add(obj)
        Next
        'Return (From obj In SeguridadData.AutorizacionRol
        '        Where obj.IDRol = IDRol And obj.IDUsuario = be.IDUsuario).ToList

    End Function

    Public Function GetListaAutorizacionesSingle(ByVal be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim obj As New AutorizacionRol
        Dim IDRol As Integer
        IDRol = be.IDRol
        Dim IDRolGrupoEmp As Integer
        'IDRolGrupoEmp = be.IDRolXGrupoEmp

        Dim consulta = (From autoriza In SeguridadData.AutorizacionRol
                        Join det In SeguridadData.Asegurable
                            On det.IDAsegurable Equals autoriza.IDAsegurable
                        Where autoriza.IDRol = IDRol And autoriza.IDUsuario = be.IDUsuario And det.IDEmpresa = be.IdEmpresa And
                            det.IDEstablecimiento = be.IDEstablecimiento).ToList

        GetListaAutorizacionesSingle = New List(Of AutorizacionRol)
        For Each i In consulta
            obj = New AutorizacionRol With
                {
                .IDRol = i.autoriza.IDRol,
                .IDAsegurable = i.autoriza.IDAsegurable,
                               .IDProducto = i.autoriza.IDProducto,
                .Formulario = i.det.CodRef,
                .Nomasegurable = i.det.Nombre,
                .EstaAutorizado = i.autoriza.EstaAutorizado,
                .UsuarioActualizacion = i.autoriza.UsuarioActualizacion,
                .FechaActualizacion = i.autoriza.FechaActualizacion
                }
            GetListaAutorizacionesSingle.Add(obj)
        Next
        'Return (From obj In SeguridadData.AutorizacionRol
        '        Where obj.IDRol = IDRol And obj.IDUsuario = be.IDUsuario).ToList

    End Function
    ''' <summary>
    ''' Obtiene la lista de asegurables dis
    ''' </summary>
    ''' <param name="objAutorizacionRol"></param>
    ''' <param name="objAsegurable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllByRolAsegurablePadre(ByVal objAutorizacionRol As AutorizacionRol,
                                               ByVal objAsegurable As Asegurable) As List(Of Asegurable)
        Return (From a In SeguridadData.AutorizacionRol
                Join b In SeguridadData.Asegurable On a.IDAsegurable Equals b.IDAsegurable
                Join c In SeguridadData.Asegurable On c.IDAsegurable Equals b.IDAsegurablePadre
                Where a.IDRol = objAutorizacionRol.IDRol AndAlso
                c.IDEmpresa = objAsegurable.IDEmpresa AndAlso c.IDEstablecimiento = objAsegurable.IDEstablecimiento AndAlso
                c.CodAsegurable = objAsegurable.CodAsegurable AndAlso
                a.EstaAutorizado = True
                Select b).ToList
    End Function

    Public Sub InsertProductoXPerfil(ByVal Asegurables As List(Of AutorizacionRol))
        Try
            Using ts As New TransactionScope
                For Each consulta In Asegurables
                    SeguridadData.AutorizacionRol.Add(consulta)
                Next
                SeguridadData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProductoXRolXID(ByVal autorizacionRol As AutorizacionRol) As AutorizacionRol
        Dim autorizacionRolBE As New AutorizacionRol

        'Dim consulta = (From ar In SeguridadData.AutorizacionRol
        '                Where
        '                    CLng(ar.IDRol) = autorizacionRol.IDRol
        '                Group ar.Producto By ar.Producto.nombre Into g = Group
        '                Select New With {
        '                    nombre
        '                    }).FirstOrDefault

        'If (Not IsNothing(consulta)) Then
        '        autorizacionRolBE.Nomasegurable = consulta.nombre
        '    End If
        Return autorizacionRolBE
    End Function

End Class

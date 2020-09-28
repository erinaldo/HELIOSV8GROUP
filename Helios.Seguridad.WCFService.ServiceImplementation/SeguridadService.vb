' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in both code and config file together.
Imports Helios.Seguridad.WCFService.ServiceContract
Imports Helios.Seguridad.WCFService.MessageContract
Imports Helios.Seguridad.Business.Logic
Imports Helios.Seguridad.Business.Entity
Imports JNetFx.Framework.Data.WCFService


Public Class SeguridadService
    Implements ISeguridadService


#Region "AutenticacionUsuario"
    Public Function AutenticarUsuarioSingle(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse Implements ISeguridadService.AutenticarUsuarioSingle
        Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL

        Dim response As New AutenticacionUsuarioResponse
        ' request.AutenticacionUsuario.IDCliente = "GENERICO" ' SOLO PARA LA SEÑORA ELI
        response.rpta = AutenticacionUsuarioBL.EsUsuarioAutenticadoSingle(request.AutenticacionUsuario)
        If response.rpta Then
            'response.Usuario = request.AutenticacionUsuario.Usuario
            'response.UsuarioRol = request.AutenticacionUsuario.Usuario.UsuarioRol.FirstOrDefault
            response.Usuario = request.AutenticacionUsuario.CustomUsuario
            response.UsuarioRol = request.AutenticacionUsuario.CustomUsuario.CustomUsuarioRol
            response.AutenticacionUsuario = request.AutenticacionUsuario
            response.Usuario.UsuarioRol.Clear()
            response.AutenticacionUsuario.Usuario = Nothing
        End If

        Return response
    End Function

    Public Function getRecuperarUsaurioLogeo(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse Implements ISeguridadService.getRecuperarUsaurioLogeo
        Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL

        Dim response As New AutenticacionUsuarioResponse
        ' request.AutenticacionUsuario.IDCliente = "GENERICO" ' SOLO PARA LA SEÑORA ELI
        response.rpta = AutenticacionUsuarioBL.EsUsuarioAutenticadoLogin(request.AutenticacionUsuario)
        If response.rpta Then
            'response.Usuario = request.AutenticacionUsuario.Usuario
            'response.UsuarioRol = request.AutenticacionUsuario.Usuario.UsuarioRol.FirstOrDefault
            response.Usuario = request.AutenticacionUsuario.CustomUsuario
            response.ListaUsuarioRol = request.AutenticacionUsuario.CustomUsuario.CustomListaUsuarioRol
            response.AutenticacionUsuario = request.AutenticacionUsuario
            response.Usuario.UsuarioRol.Clear()
            response.AutenticacionUsuario.Usuario = Nothing
        End If

        Return response
    End Function

    Public Function EsUsuarioAutenticadoConfPrecio(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse Implements ISeguridadService.EsUsuarioAutenticadoConfPrecio
        Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL

        Dim response As New AutenticacionUsuarioResponse
        ' request.AutenticacionUsuario.IDCliente = "GENERICO" ' SOLO PARA LA SEÑORA ELI
        response.rpta = AutenticacionUsuarioBL.EsUsuarioAutenticadoConfPrecio(request.AutenticacionUsuario)
        If response.rpta Then
            'response.Usuario = request.AutenticacionUsuario.Usuario
            'response.UsuarioRol = request.AutenticacionUsuario.Usuario.UsuarioRol.FirstOrDefault
            response.Usuario = request.AutenticacionUsuario.CustomUsuario
            response.UsuarioRol = request.AutenticacionUsuario.CustomUsuario.CustomUsuarioRol
            response.AutenticacionUsuario = request.AutenticacionUsuario
            response.Usuario.UsuarioRol.Clear()
            response.AutenticacionUsuario.Usuario = Nothing
        End If

        Return response
    End Function

    Public Function AutenticarUsuario(ByVal request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse Implements ISeguridadService.AutenticarUsuario
        Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL

        Dim response As New AutenticacionUsuarioResponse
        ' request.AutenticacionUsuario.IDCliente = "GENERICO" ' SOLO PARA LA SEÑORA ELI
        response.rpta = AutenticacionUsuarioBL.EsUsuarioAutenticado(request.AutenticacionUsuario)
        If response.rpta Then
            'response.Usuario = request.AutenticacionUsuario.Usuario
            'response.UsuarioRol = request.AutenticacionUsuario.Usuario.UsuarioRol.FirstOrDefault
            response.Usuario = request.AutenticacionUsuario.CustomUsuario
            response.UsuarioRol = request.AutenticacionUsuario.CustomUsuario.CustomUsuarioRol
            response.AutenticacionUsuario = request.AutenticacionUsuario
            response.Usuario.UsuarioRol.Clear()
            response.AutenticacionUsuario.Usuario = Nothing
        End If

        Return response
    End Function

    'Public Function getRecuperarUsaurioLogeo(ByRef usuario As AutenticacionUsuarioRequest) As AutenticacionUsuario Implements ISeguridadService.getRecuperarUsaurioLogeo
    '    Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL

    '    Dim response As New AutenticacionUsuarioResponse
    '    ' request.AutenticacionUsuario.IDCliente = "GENERICO" ' SOLO PARA LA SEÑORA ELI
    '    response.AutenticacionUsuario = AutenticacionUsuarioBL.getRecuperarUsaurioLogeo(usuario.AutenticacionUsuario)

    '    Return response.AutenticacionUsuario
    'End Function

    Public Function AutenticacionUsuarioGrabarTodo(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse Implements ServiceContract.ISeguridadService.AutenticacionUsuarioGrabarTodo
        Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL
        Dim response As New AutenticacionUsuarioResponse
        'AutenticacionUsuarioBL.AutenticacionUsuarioGrabarTodo(request.AutenticacionUsuario)
        response.idPersona = AutenticacionUsuarioBL.AutenticacionUsuarioGrabarTodo(request.AutenticacionUsuario)
        Return response
    End Function

    Public Function AutenticacionUsuarioGrabarTodoXModulo(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse Implements ServiceContract.ISeguridadService.AutenticacionUsuarioGrabarTodoXModulo
        Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL
        Dim response As New AutenticacionUsuarioResponse
        'AutenticacionUsuarioBL.AutenticacionUsuarioGrabarTodo(request.AutenticacionUsuario)
        response.idPersona = AutenticacionUsuarioBL.AutenticacionUsuarioGrabarTodoXModulo(request.AutenticacionUsuario, request.listaAsegurableRol)
        Return response
    End Function

#End Region
#Region "AutorizacionRol"
    Public Function ObtenerListaAutorizaciones(request As MessageContract.AutorizacionRolRequest) As MessageContract.AutorizacionRolResponse Implements ServiceContract.ISeguridadService.ObtenerListaAutorizaciones
        Dim AutorizacionRolBL As New AutorizacionRolBL

        Dim response As New AutorizacionRolResponse
        response.AutorizacionRolList = AutorizacionRolBL.GetAllByRol(request.AutorizacionRol)

        Return response
    End Function

    Public Function GetListaAutorizacionesSingle(request As MessageContract.AutorizacionRolRequest) As MessageContract.AutorizacionRolResponse Implements ServiceContract.ISeguridadService.GetListaAutorizacionesSingle
        Dim AutorizacionRolBL As New AutorizacionRolBL

        Dim response As New AutorizacionRolResponse
        response.AutorizacionRolList = AutorizacionRolBL.GetListaAutorizacionesSingle(request.AutorizacionRol)

        Return response
    End Function

    Public Function ObtenerListaAutorizacionesPorAsegurablePadre(request As MessageContract.AutorizacionRolRequest) As MessageContract.AutorizacionRolResponse Implements ServiceContract.ISeguridadService.ObtenerListaAutorizacionesPorAsegurablePadre
        Dim AutorizacionRolBL As New AutorizacionRolBL
        Dim response As New AutorizacionRolResponse
        response.AsegurableList = AutorizacionRolBL.GetAllByRolAsegurablePadre(request.AutorizacionRol, request.Asegurable)
        Return response
    End Function
#End Region

    Public Function ListadoUsuariosXcliente(request As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.ListadoUsuariosXcliente
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.ListadoUsuarios = usuarioBL.ListadoUsuariosXcliente(request.IDCliente)

        Return response
    End Function

    Public Function GetListaAsegurablesXClientePOS(request As AsegurableRequest) As AsegurableResponse Implements ISeguridadService.GetListaAsegurablesXClientePOS
        Dim AsegurableBL As New AsegurableBL
        Dim response As New AsegurableResponse
        response.ListadoAsegurables = AsegurableBL.GetListaAsegurablesXClientePOS(request.ObjAsegurables)
        Return response
    End Function

    Public Function ListadoUsuarios() As UsuarioResponse Implements ISeguridadService.ListadoUsuarios
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.ListadoUsuarios = usuarioBL.ListadoUsuarios()

        Return response
    End Function

    Public Function ListadoUsuariosconteo() As Integer Implements ISeguridadService.ListadoUsuariosconteo
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.UsuarioConteo = usuarioBL.ListadoUsuariosconteo()
        Return response.UsuarioConteo
    End Function

    Public Function ListadoUsuariosPuntoVenta(usuarioRol As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.ListadoUsuariosPuntoVenta
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.ListadoUsuarios = usuarioBL.ListadoUsuariosPuntoVenta(usuarioRol.UsuarioRol)

        Return response
    End Function

    Public Function UbicarUsuarioXid(request As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.UbicarUsuarioXid
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.Usuario = usuarioBL.UbicarUsuarioXid(request.Usuario)

        Return response
    End Function

    Public Function UbicarUsuarioCaja(request As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.UbicarUsuarioCaja
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.Usuario = usuarioBL.UbicarUsuarioCaja(request.Usuario)

        Return response
    End Function

    Public Sub DeletePersonaXCaja(request As UsuarioRequest) Implements ISeguridadService.DeletePersonaXCaja
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        usuarioBL.DeletePersonaXCaja(request.Usuario)
    End Sub

    Public Function UpdateUsuarioXID(request As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.UpdateUsuarioXID
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.Usuario = usuarioBL.UpdateUsuarioXID(request.Usuario)

        Return response
    End Function

    Public Function UpdateUsuarioCodigoAsignado(request As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.UpdateUsuarioCodigoAsignado
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.Usuario = usuarioBL.UpdateUsuarioCodigoAsignado(request.Usuario)

        Return response
    End Function

    Public Function Ping() As Boolean Implements IServiceBase.Ping
        Return True
    End Function

    Public Function ListadoRolesXID(request As RolRequest) As RolResponse Implements ISeguridadService.ListadoRolesXID
        Dim RolBL As New RolBL
        Dim response As New RolResponse
        response.ObjRoles = RolBL.ListadoRolesXID(request.idRol)
        Return response
    End Function

    Public Function ListadoRolesClienteXID(request As RolRequest) As RolResponse Implements ISeguridadService.ListadoRolesClienteXID
        Dim RolBL As New RolBL
        Dim response As New RolResponse
        response.ObjRoles = RolBL.ListadoRolesClienteXID(request.ObjRoles)
        Return response
    End Function

    Public Function ListadoRoles() As RolResponse Implements ISeguridadService.ListadoRoles
        Dim RolBL As New RolBL
        Dim response As New RolResponse
        response.ListadoRoles = RolBL.GetRoles()
        Return response
    End Function

    Public Function ListadoAsegurableXID(request As AsegurableRequest) As AsegurableResponse Implements ISeguridadService.ListadoAsegurableXID
        Dim AsegurableBL As New AsegurableBL
        Dim response As New AsegurableResponse
        response.ObjAsegurables = AsegurableBL.ListadoAsegurableXID(request.idAsegurables)
        Return response
    End Function

    Public Function updateAsegurable(be As AsegurableRequest) As AsegurableResponse Implements ISeguridadService.updateAsegurable
        Dim AsegurableBL As New AsegurableBL
        Dim response As New AsegurableResponse
        response.ObjAsegurables = AsegurableBL.updateAsegurable(be.ObjAsegurables)
        Return response
    End Function

    Public Function GetInsertAsegurable(be As AsegurableRequest) As AsegurableResponse Implements ISeguridadService.GetInsertAsegurable
        Dim AsegurableBL As New AsegurableBL
        Dim response As New AsegurableResponse
        response.ObjAsegurables = AsegurableBL.GetInsertAsegurable(be.ObjAsegurables)
        Return response
    End Function

    Public Function GetUpdateRol(be As RolRequest) As RolResponse Implements ISeguridadService.GetUpdateRol
        Dim RolBL As New RolBL
        Dim response As New RolResponse
        response.ObjRoles = RolBL.GetUpdateRol(be.ObjRoles)
        Return response
    End Function

    Public Function GetAsegurables() As AsegurableResponse Implements ISeguridadService.GetAsegurables
        Dim AsegurableBL As New AsegurableBL
        Dim response As New AsegurableResponse
        response.ListadoAsegurables = AsegurableBL.GetAsegurables()
        Return response
    End Function

    Public Function GetListaAsegurables(be As AsegurableRequest) As AsegurableResponse Implements ISeguridadService.GetListaAsegurables
        Dim AsegurableBL As New AsegurableBL
        Dim response As New AsegurableResponse
        response.ListadoAsegurables = AsegurableBL.GetListaAsegurables(be.ListadoAsegurablesID)
        Return response
    End Function

    Public Function GetAutorizacionesByRol(be As AutorizacionRolRequest) As AutorizacionRolResponse Implements ISeguridadService.GetAutorizacionesByRol
        Dim AutorizaBL As New AutorizacionRolBL
        Dim response As New AutorizacionRolResponse
        response.AutorizacionRolList = AutorizaBL.GetAutorizacionesByRol(be.AutorizacionRol)
        Return response
    End Function

    Public Function GetAutorizacionesELI(be As AutorizacionRolRequest) As AutorizacionRolResponse Implements ISeguridadService.GetAutorizacionesELI
        Dim AutorizaBL As New AutorizacionRolBL
        Dim response As New AutorizacionRolResponse
        response.AutorizacionRolList = AutorizaBL.GetAutorizacionesELI(be.AutorizacionRol)
        Return response
    End Function

    Public Function GetListaXgrupoEmp(be As rolXGrupoEmpRequest) As rolXGrupoEmpResponse Implements ISeguridadService.GetListaXgrupoEmp
        'Dim AutorizaBL As New RolXGrupoEmpBL
        'Dim response As New rolXGrupoEmpResponse
        'response.ListadoRolXGrupoEmp = AutorizaBL.GetListaXgrupoEmp(be.ObjrolXGrupoEmp)
        'Return response
    End Function

    Public Function GetAutorizacionesRolXProducto(be As AutorizacionRolRequest) As AutorizacionRolResponse Implements ISeguridadService.GetAutorizacionesRolXProducto
        Dim AutorizaBL As New AutorizacionRolBL
        Dim response As New AutorizacionRolResponse
        response.AutorizacionRolList = AutorizaBL.GetAutorizacionesRolXProducto(be.AutorizacionRol)
        Return response
    End Function

    Public Sub InsertProductoXPerfil(request As AutorizacionRolRequest) Implements ISeguridadService.InsertProductoXPerfil
        Dim AutorizaBL As New AutorizacionRolBL
        Dim response As New AutorizacionRolResponse
        AutorizaBL.InsertProductoXPerfil(request.AutorizacionRolList)
    End Sub

    Public Function GetProductoXRolXID(be As AutorizacionRolRequest) As AutorizacionRolResponse Implements ISeguridadService.GetProductoXRolXID
        Dim AutorizaBL As New AutorizacionRolBL
        Dim response As New AutorizacionRolResponse
        response.AutorizacionRol = AutorizaBL.GetProductoXRolXID(be.AutorizacionRol)
        Return response
    End Function

    Public Sub InsertItem(request As AutorizacionRolRequest) Implements ISeguridadService.InsertItem
        Dim AutorizaBL As New AutorizacionRolBL
        Dim response As New AutorizacionRolResponse
        AutorizaBL.InsertItem(request.AutorizacionRol)
    End Sub

    Public Sub GetUpdateAutorizacion(request As AutorizacionRolRequest) Implements ISeguridadService.GetUpdateAutorizacion
        Dim AutorizaBL As New AutorizacionRolBL
        Dim response As New AutorizacionRolResponse
        AutorizaBL.GetUpdateAutorizacion(request.AutorizacionRol)
    End Sub

    Public Function GetInserRoles(request As RolRequest) As RolResponse Implements ISeguridadService.GetInserRoles
        Dim RolBL As New RolBL
        Dim response As New RolResponse
        response.ObjRoles = RolBL.GetInserRoles(request.ObjRoles)
        Return response
    End Function

    Public Function GetInsertAsegurableProducto(be As ProductoRequest) As ProductoResponse Implements ISeguridadService.GetInsertAsegurableProducto
        Dim AsegurableBL As New ProductoBL
        Dim response As New ProductoResponse
        response.ObjProducto = AsegurableBL.GetInsertAsegurableProducto(be.ObjProducto)
        Return response
    End Function


    Public Function GetAsegurableProducto(be As ProductoRequest) As ProductoResponse Implements ISeguridadService.GetAsegurableProducto
        Dim AsegurableBL As New ProductoBL
        Dim response As New ProductoResponse
        response.ListadoProducto = AsegurableBL.GetAsegurableProducto(be.tipoProducto)
        Return response
    End Function

    Public Function GetListaAsegurableProducto(be As ProductoRequest) As ProductoResponse Implements ISeguridadService.GetListaAsegurableProducto
        Dim AsegurableBL As New ProductoBL
        Dim response As New ProductoResponse
        response.ListadoProducto = AsegurableBL.GetListaAsegurableProducto(be.tipoProducto)
        Return response
    End Function

    Public Function ListadoTipoProducto() As ProductoResponse Implements ISeguridadService.ListadoTipoProducto
        Dim AsegurableBL As New ProductoBL
        Dim response As New ProductoResponse
        response.ListadoProducto = AsegurableBL.ListadoTipoProducto()
        Return response
    End Function

    Public Function GetAsegurableProductoDetalle(be As ProductoDetalleRequest) As productoDetalleResponse Implements ISeguridadService.GetAsegurableProductoDetalle
        Dim AsegurableBL As New productoDetalleBL
        Dim response As New productoDetalleResponse
        response.ListadoProductoDetalle = AsegurableBL.GetAsegurableProductoDetalle(be.idProductoDetalle)
        Return response
    End Function

    Public Sub insertProductoDetalle(request As ProductoDetalleRequest) Implements ISeguridadService.insertProductoDetalle
        Dim ProducDetalleBL As New productoDetalleBL
        Dim response As New productoDetalleResponse
        ProducDetalleBL.insertProductoDetalle(request.ObjProductoDetalle)
    End Sub

    Public Sub InsertItemProducto(request As ProductoRequest) Implements ISeguridadService.InsertItemProducto
        Dim AutorizaBL As New ProductoBL
        Dim response As New productoDetalleResponse
        AutorizaBL.InsertItemProducto(request.ObjProducto)
    End Sub

    Public Function ListadoProductoXID(request As ProductoRequest) As ProductoResponse Implements ISeguridadService.ListadoProductoXID
        Dim AsegurableBL As New ProductoBL
        Dim response As New ProductoResponse
        response.ObjProducto = AsegurableBL.ListadoProductoXID(request.idProducto)
        Return response
    End Function

    Public Function GetListaUsuariosXPerfil() As UsuarioRolResponse Implements ISeguridadService.GetListaUsuariosXPerfil
        Dim UsuarioRolBL As New UsuarioRolBL
        Dim response As New UsuarioRolResponse
        response.ListadoUsuarioRol = UsuarioRolBL.GetListaUsuariosXPerfil()
        Return response
    End Function

    Public Function GetListaUsuariosXPerfilXCliente(request As UsuarioRolRequest) As UsuarioRolResponse Implements ISeguridadService.GetListaUsuariosXPerfilXCliente
        Dim UsuarioRolBL As New UsuarioRolBL
        Dim response As New UsuarioRolResponse
        response.ListadoUsuarioRol = UsuarioRolBL.GetListaUsuariosXPerfilXCliente(request.ClieneID)
        Return response
    End Function

    Public Function GetListaUsuariosXPerfilAndPassword(request As UsuarioRolRequest) As UsuarioRolResponse Implements ISeguridadService.GetListaUsuariosXPerfilAndPassword
        Dim UsuarioRolBL As New UsuarioRolBL
        Dim response As New UsuarioRolResponse
        response.ListadoUsuarioRol = UsuarioRolBL.GetListaUsuariosXPerfilAndPassword(request.ClieneID)
        Return response
    End Function

    Public Function GetListaCargosXPerfilAndPassword(request As UsuarioRolRequest) As UsuarioRolResponse Implements ISeguridadService.GetListaCargosXPerfilAndPassword
        Dim UsuarioRolBL As New UsuarioRolBL
        Dim response As New UsuarioRolResponse
        response.ListadoUsuarioRol = UsuarioRolBL.GetListaCargosXPerfilAndPassword(request.ObjUsuarioAutenticacion)
        Return response
    End Function

    Public Function updateEstadoRoleUser(request As UsuarioRolRequest) As UsuarioRolResponse Implements ISeguridadService.updateEstadoRoleUser
        Dim UsuarioRolBL As New UsuarioRolBL
        Dim response As New UsuarioRolResponse
        response.ObjUsuarioRol = UsuarioRolBL.updateEstadoRoleUser(request.ObjUsuarioRol)
        Return response
    End Function

    Public Function GetListaAsegurablesPadre(request As AsegurableRequest) As AsegurableResponse Implements ISeguridadService.GetListaAsegurablesPadre
        Dim AsegurableBL As New AsegurableBL
        Dim response As New AsegurableResponse
        response.ListadoAsegurables = AsegurableBL.GetListaAsegurablesPadre(request.ObjAsegurables)
        Return response
    End Function

    Public Function GetListaAsegurablesXCliente(request As AsegurableRequest) As AsegurableResponse Implements ISeguridadService.GetListaAsegurablesXCliente
        Dim AsegurableBL As New AsegurableBL
        Dim response As New AsegurableResponse
        response.ListadoAsegurables = AsegurableBL.GetListaAsegurablesXCliente(request.ObjAsegurables)
        Return response
    End Function

    Public Function GetAsegurablesByPadreXcliente(request As AsegurableRequest) As AsegurableResponse Implements ISeguridadService.GetAsegurablesByPadreXcliente
        Dim AsegurableBL As New AsegurableBL
        Dim response As New AsegurableResponse
        response.ListadoAsegurables = AsegurableBL.GetAsegurablesByPadreXcliente(request.ObjAsegurables)
        Return response
    End Function

    Public Function GetRolesXcliente(request As RolRequest) As RolResponse Implements ISeguridadService.GetRolesXcliente
        Dim RolBL As New RolBL
        Dim response As New RolResponse
        response.ListadoRoles = RolBL.GetRolesXcliente(request.ObjRoles)
        Return response
    End Function

    Public Function GetRolesXEstablecimiento(request As RolRequest) As RolResponse Implements ISeguridadService.GetRolesXEstablecimiento
        Dim RolBL As New RolBL
        Dim response As New RolResponse
        response.ListadoRoles = RolBL.GetRolesXEstablecimiento(request.ObjRoles)
        Return response
    End Function

    Public Function RolInsertSingle(request As RolRequest) As RolResponse Implements ISeguridadService.RolInsertSingle
        Dim RolBL As New RolBL
        Dim response As New RolResponse
        response.ObjRoles = RolBL.RolInsertSingle(request.ObjRoles)
        Return response
    End Function

    Public Sub GetUpdateAutorizacionXcliente(request As AutorizacionRolRequest) Implements ISeguridadService.GetUpdateAutorizacionXcliente
        Dim autorizacionBL As New AutorizacionRolBL
        '  Dim response As New AutorizacionRolResponse
        autorizacionBL.GetUpdateAutorizacionXcliente(request.AutorizacionRol)
    End Sub

    Public Function GetAutorizacionesRolXcliente(be As AutorizacionRolRequest) As AutorizacionRolResponse Implements ISeguridadService.GetAutorizacionesRolXcliente
        Dim autorizacionBL As New AutorizacionRolBL
        Dim response As New AutorizacionRolResponse
        response.AutorizacionRolList = autorizacionBL.GetAutorizacionesRolXcliente(be.AutorizacionRol)
        Return response
    End Function

    Public Function GetAsegurableXidCliente(request As AsegurableRequest) As AsegurableResponse Implements ISeguridadService.GetAsegurableXidCliente
        Dim asegurableBL As New AsegurableBL
        Dim response As New AsegurableResponse
        response.ListadoAsegurables = asegurableBL.GetAsegurableXidCliente(request.ObjAsegurables)
        Return response
    End Function

    Public Sub GrabarAdministradorDefault(request As AutenticacionUsuarioRequest) Implements ISeguridadService.GrabarAdministradorDefault
        Dim autenticacionBL As New AutenticacionUsuarioBL
        autenticacionBL.GrabarAdministradorDefault(request.AutenticacionUsuario)
    End Sub

    Public Sub GrabarSuperAdministradorDefault(request As AutenticacionUsuarioRequest) Implements ISeguridadService.GrabarSuperAdministradorDefault
        Dim autenticacionBL As New AutenticacionUsuarioBL
        autenticacionBL.GrabarSuperAdministradorDefault(request.AutenticacionUsuario)
    End Sub

    Public Function CambiarContrasena(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse Implements ISeguridadService.CambiarContrasena
        Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL

        Dim response As New AutenticacionUsuarioResponse
        response.rpta = AutenticacionUsuarioBL.AutenticacionUsuarioModificarContrasena(request.AutenticacionUsuario, request.NuevaContrasena)
        Return response
    End Function

    Public Function EsUsuarioAutenticadoLoginRecuperarPassword(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse Implements ISeguridadService.EsUsuarioAutenticadoLoginRecuperarPassword
        Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL

        Dim response As New AutenticacionUsuarioResponse
        ' request.AutenticacionUsuario.IDCliente = "GENERICO" ' SOLO PARA LA SEÑORA ELI
        response.password = AutenticacionUsuarioBL.EsUsuarioAutenticadoLoginRecuperarPassword(request.AutenticacionUsuario)

        Return response
    End Function


    Public Function ListadoUsuariosv2() As UsuarioResponse Implements ISeguridadService.ListadoUsuariosv2
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.ListadoUsuarios = usuarioBL.ListadoUsuariosv2()

        Return response
    End Function

    Public Function GetAsegurableXRol(request As AutorizacionRolRequest) As AutorizacionRolResponse Implements ISeguridadService.GetAsegurableXRol
        Dim AutorizaBL As New AutorizacionRolBL
        Dim response As New AutorizacionRolResponse
        response.AutorizacionRolList = AutorizaBL.GetAsegurableXRol(request.AutorizacionRol)
        Return response
    End Function

    Public Sub RegistrarPermisoRol(request As AutorizacionRolRequest) Implements ISeguridadService.RegistrarPermisoRol
        Dim autorizacionBL As New AutorizacionRolBL
        '  Dim response As New AutorizacionRolResponse
        autorizacionBL.RegistrarPermisoRol(request.AutorizacionRol)
    End Sub

    Public Sub EliminarPermisoRol(request As AutorizacionRolRequest) Implements ISeguridadService.EliminarPermisoRol
        Dim autorizacionBL As New AutorizacionRolBL
        '  Dim response As New AutorizacionRolResponse
        autorizacionBL.EliminarPermisoRol(request.AutorizacionRol)
    End Sub

    Public Function ListadoUsuariosXclienteCargo(request As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.ListadoUsuariosXclienteCargo
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.ListadoUsuarios = usuarioBL.ListadoUsuariosXclienteCargo(request.Usuario)

        Return response
    End Function

    Public Function ListadoUsuariosConResponsable(request As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.ListadoUsuariosConResponsable
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.ListadoUsuarios = usuarioBL.ListadoUsuariosConResponsable(request.Usuario)

        Return response
    End Function

    Public Function ListadoUsuariosSoloCargoNoResp(request As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.ListadoUsuariosSoloCargoNoResp
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.ListadoUsuarios = usuarioBL.ListadoUsuariosSoloCargoNoResp(request.Usuario)

        Return response
    End Function

    Public Function GetUpdateUsuario(request As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.GetUpdateUsuario
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.Usuario = usuarioBL.GetUpdateUsuario(request.Usuario)

        Return response
    End Function
    Public Function UpdateCargoXID(request As UsuarioRequest) As UsuarioResponse Implements ISeguridadService.UpdateCargoXID
        Dim usuarioBL As New UsuarioBL
        Dim response As New UsuarioResponse
        response.Usuario = usuarioBL.UpdateCargoXID(request.Usuario)

        Return response
    End Function
    Public Function UpdateContrasenaUsuario(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse Implements ISeguridadService.UpdateContrasenaUsuario
        Dim usuarioBL As New AutenticacionUsuarioBL
        Dim response As New AutenticacionUsuarioResponse
        response.AutenticacionUsuario = usuarioBL.UpdateContrasenaUsuario(request.AutenticacionUsuario)

        Return response
    End Function

    Public Function BuscarContraseñaAliasUser(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse Implements ISeguridadService.BuscarContraseñaAliasUser
        Dim usuarioBL As New AutenticacionUsuarioBL
        Dim response As New AutenticacionUsuarioResponse
        response.AutenticacionUsuario = usuarioBL.BuscarContraseñaAliasUser(request.AutenticacionUsuario)

        Return response
    End Function

    Public Function RoleRegister(request As RolRequest) As RolResponse Implements ISeguridadService.RoleRegister
        Dim AutorizaBL As New RolBL
        Dim response As New RolResponse
        response.ObjRoles = AutorizaBL.RoleRegister(request.ObjRoles)
        Return response
    End Function

    Public Function RoleRegisterSingle(request As RolRequest) As RolResponse Implements ISeguridadService.RoleRegisterSingle
        Dim AutorizaBL As New RolBL
        Dim response As New RolResponse
        response.ObjRoles = AutorizaBL.RoleRegisterSingle(request.ObjRoles)
        Return response
    End Function

    Public Function RoleList(bjCargo As RolRequest) As RolResponse Implements ISeguridadService.RoleList
        Dim AutorizaBL As New RolBL
        Dim response As New RolResponse
        response.ListadoRoles = AutorizaBL.RoleList(bjCargo.ObjRoles)
        Return response
    End Function

    Public Function RoleListXUnidOrg(bjCargo As RolRequest) As RolResponse Implements ISeguridadService.RoleListXUnidOrg
        Dim AutorizaBL As New RolBL
        Dim response As New RolResponse
        response.ListadoRoles = AutorizaBL.RoleListXUnidOrg(bjCargo.ObjRoles)
        Return response
    End Function

    Public Function RoleListSingle(bjCargo As RolRequest) As RolResponse Implements ISeguridadService.RoleListSingle
        Dim AutorizaBL As New RolBL
        Dim response As New RolResponse
        response.ListadoRoles = AutorizaBL.RoleListSingle(bjCargo.ObjRoles)
        Return response
    End Function

    Public Function RolSearch(request As RolRequest) As RolResponse Implements ISeguridadService.RolSearch
        Dim AutorizaBL As New RolBL
        Dim response As New RolResponse
        response.ObjRoles = AutorizaBL.RolSearch(request.ObjRoles)
        Return response
    End Function

    Public Function UpdateRole(request As RolRequest) As RolResponse Implements ISeguridadService.UpdateRole
        Dim AutorizaBL As New RolBL
        Dim response As New RolResponse
        response.ObjRoles = AutorizaBL.UpdateRole(request.ObjRoles)
        Return response
    End Function

    Public Function InserRoleUser(request As UsuarioRolRequest) As UsuarioRolResponse Implements ISeguridadService.InserRoleUser
        Dim RolBL As New UsuarioRolBL
        Dim response As New UsuarioRolResponse
        response.ObjUsuarioRol = RolBL.InserRoleUser(request.ObjUsuarioRol)
        Return response
    End Function


End Class

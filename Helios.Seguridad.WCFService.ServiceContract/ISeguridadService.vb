
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports Helios.Seguridad.Business.Entity
'Imports JNetFx.Framework.General.WCFService
Imports Helios.Seguridad.WCFService.MessageContract
Imports JNetFx.Framework.Data.WCFService

<ServiceContract()> _
Public Interface ISeguridadService
    Inherits IServiceBase

    <OperationContract()>
    Function UpdateCargoXID(request As UsuarioRequest) As UsuarioResponse

    <OperationContract()>
    Function BuscarContraseñaAliasUser(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse

    <OperationContract()>
    Function UpdateContrasenaUsuario(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse


    <OperationContract()>
    Function RoleList(bjCargo As RolRequest) As RolResponse

    <OperationContract()>
    Function RoleListXUnidOrg(bjCargo As RolRequest) As RolResponse

    <OperationContract()>
    Function RoleListSingle(bjCargo As RolRequest) As RolResponse


    <OperationContract()>
    Function RolSearch(request As RolRequest) As RolResponse

    <OperationContract()>
    Function RoleRegister(request As RolRequest) As RolResponse

    <OperationContract()>
    Function RoleRegisterSingle(request As RolRequest) As RolResponse

    <OperationContract()>
    Function UpdateRole(request As RolRequest) As RolResponse

    <OperationContract()>
    Sub GrabarAdministradorDefault(request As AutenticacionUsuarioRequest)

    <OperationContract()>
    Sub GrabarSuperAdministradorDefault(request As AutenticacionUsuarioRequest)

    <OperationContract()>
    Sub GetUpdateAutorizacion(request As AutorizacionRolRequest)

    <OperationContract()>
    Function GetAsegurableXRol(request As AutorizacionRolRequest) As AutorizacionRolResponse


    <OperationContract()>
    Sub GetUpdateAutorizacionXcliente(request As AutorizacionRolRequest)

    <OperationContract()>
    Sub RegistrarPermisoRol(request As AutorizacionRolRequest)

    <OperationContract()>
    Sub EliminarPermisoRol(request As AutorizacionRolRequest)


    <OperationContract()>
    Sub InsertItem(request As AutorizacionRolRequest)

    <OperationContract()>
    Function GetAsegurableXidCliente(ByVal request As AsegurableRequest) As AsegurableResponse

    <OperationContract()>
    Function GetProductoXRolXID(request As AutorizacionRolRequest) As AutorizacionRolResponse

    <OperationContract()>
    Sub InsertProductoXPerfil(request As AutorizacionRolRequest)

    <OperationContract()>
    Function GetAsegurables() As AsegurableResponse

    <OperationContract()>
    Function GetListaAsegurables(request As AsegurableRequest) As AsegurableResponse

    <OperationContract()>
    Function ListadoAsegurableXID(request As AsegurableRequest) As AsegurableResponse

    <OperationContract()>
    Function updateAsegurable(request As AsegurableRequest) As AsegurableResponse

    <OperationContract()> _
    Function GetInsertAsegurable(request As AsegurableRequest) As AsegurableResponse

    <OperationContract()>
    Function AutenticarUsuario(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse

    <OperationContract()>
    Function getRecuperarUsaurioLogeo(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse

    <OperationContract()>
    Function EsUsuarioAutenticadoConfPrecio(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse

    <OperationContract()>
    Function AutenticarUsuarioSingle(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse

    <OperationContract()>
    Function ObtenerListaAutorizaciones(request As AutorizacionRolRequest) As AutorizacionRolResponse

    <OperationContract()>
    Function GetListaAutorizacionesSingle(request As AutorizacionRolRequest) As AutorizacionRolResponse

    <OperationContract()>
    Function GetAutorizacionesByRol(ByVal be As AutorizacionRolRequest) As AutorizacionRolResponse

    <OperationContract()>
    Function GetAutorizacionesRolXcliente(ByVal be As AutorizacionRolRequest) As AutorizacionRolResponse

    <OperationContract()>
    Function GetAutorizacionesRolXProducto(ByVal be As AutorizacionRolRequest) As AutorizacionRolResponse

    <OperationContract()>
    Function GetAutorizacionesELI(ByVal be As AutorizacionRolRequest) As AutorizacionRolResponse

    <OperationContract()>
    Function GetListaXgrupoEmp(ByVal be As rolXGrupoEmpRequest) As rolXGrupoEmpResponse

    <OperationContract()>
    Function ObtenerListaAutorizacionesPorAsegurablePadre(request As AutorizacionRolRequest) As AutorizacionRolResponse

    <OperationContract()>
    Function AutenticacionUsuarioGrabarTodo(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse

    <OperationContract()>
    Function AutenticacionUsuarioGrabarTodoXModulo(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse

    <OperationContract()>
    Function ListadoUsuarios() As UsuarioResponse

    <OperationContract()>
    Function GetUpdateUsuario(request As UsuarioRequest) As UsuarioResponse


    <OperationContract()>
    Function ListadoUsuariosXcliente(request As UsuarioRequest) As UsuarioResponse

    <OperationContract()>
    Function ListadoUsuariosXclienteCargo(request As UsuarioRequest) As UsuarioResponse

    <OperationContract()>
    Function ListadoUsuariosConResponsable(request As UsuarioRequest) As UsuarioResponse

    <OperationContract()>
    Function ListadoUsuariosSoloCargoNoResp(request As UsuarioRequest) As UsuarioResponse


    <OperationContract()>
    Function GetListaAsegurablesXClientePOS(request As AsegurableRequest) As AsegurableResponse

    <OperationContract()>
    Function ListadoRoles() As RolResponse

    <OperationContract()>
    Function GetRolesXcliente(request As RolRequest) As RolResponse

    <OperationContract()>
    Function GetRolesXEstablecimiento(request As RolRequest) As RolResponse

    <OperationContract()>
    Function RolInsertSingle(request As RolRequest) As RolResponse

    <OperationContract()>
    Function ListadoRolesXID(request As RolRequest) As RolResponse

    <OperationContract()>
    Function ListadoRolesClienteXID(request As RolRequest) As RolResponse

    <OperationContract()>
    Function GetInserRoles(request As RolRequest) As RolResponse

    <OperationContract()>
    Function InserRoleUser(request As UsuarioRolRequest) As UsuarioRolResponse


    <OperationContract()>
    Function GetUpdateRol(request As RolRequest) As RolResponse

    <OperationContract()>
    Function ListadoUsuariosconteo() As Integer


    <OperationContract()>
    Function ListadoUsuariosPuntoVenta(usuarioRol As UsuarioRequest) As UsuarioResponse

    <OperationContract()>
    Function UbicarUsuarioXid(request As UsuarioRequest) As UsuarioResponse

    <OperationContract()>
    Function UbicarUsuarioCaja(request As UsuarioRequest) As UsuarioResponse


    <OperationContract()>
    Sub DeletePersonaXCaja(request As UsuarioRequest)

    <OperationContract()>
    Function UpdateUsuarioXID(request As UsuarioRequest) As UsuarioResponse

    <OperationContract()>
    Function UpdateUsuarioCodigoAsignado(request As UsuarioRequest) As UsuarioResponse


    <OperationContract()>
    Function GetInsertAsegurableProducto(request As ProductoRequest) As ProductoResponse


    <OperationContract()>
    Function GetListaAsegurableProducto(request As ProductoRequest) As ProductoResponse

    <OperationContract()>
    Function GetAsegurableProducto(request As ProductoRequest) As ProductoResponse


    <OperationContract()>
    Function ListadoTipoProducto() As ProductoResponse

    <OperationContract()>
    Function GetAsegurableProductoDetalle(request As ProductoDetalleRequest) As productoDetalleResponse

    <OperationContract()>
    Sub insertProductoDetalle(request As ProductoDetalleRequest)

    <OperationContract()>
    Sub InsertItemProducto(request As ProductoRequest)

    <OperationContract()>
    Function ListadoProductoXID(request As ProductoRequest) As ProductoResponse

    <OperationContract()>
    Function GetListaUsuariosXPerfil() As UsuarioRolResponse

    <OperationContract()>
    Function GetListaUsuariosXPerfilXCliente(request As UsuarioRolRequest) As UsuarioRolResponse

    <OperationContract()>
    Function GetListaUsuariosXPerfilAndPassword(request As UsuarioRolRequest) As UsuarioRolResponse

    <OperationContract()>
    Function GetListaCargosXPerfilAndPassword(request As UsuarioRolRequest) As UsuarioRolResponse

    <OperationContract()>
    Function updateEstadoRoleUser(request As UsuarioRolRequest) As UsuarioRolResponse

    <OperationContract()>
    Function GetListaAsegurablesPadre(request As AsegurableRequest) As AsegurableResponse


    <OperationContract()>
    Function GetListaAsegurablesXCliente(request As AsegurableRequest) As AsegurableResponse


    <OperationContract()>
    Function GetAsegurablesByPadreXcliente(request As AsegurableRequest) As AsegurableResponse

    <OperationContract()>
    Function CambiarContrasena(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse

    <OperationContract()>
    Function ListadoUsuariosv2() As UsuarioResponse

    <OperationContract()>
    Function EsUsuarioAutenticadoLoginRecuperarPassword(request As AutenticacionUsuarioRequest) As AutenticacionUsuarioResponse


End Interface

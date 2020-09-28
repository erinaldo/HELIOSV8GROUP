Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.MessageContract
Public Class RolSA



    Public Function RolSearch(be As Rol) As Rol
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.RolSearch(New RolRequest() With {.ObjRoles = be})
        Return Response.ObjRoles
    End Function


    Public Function UpdateRole(be As Rol) As Rol
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.UpdateRole(New RolRequest() With {.ObjRoles = be})
        Return Response.ObjRoles
    End Function


    Public Function RoleList(bjCargo As Rol) As List(Of Rol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.RoleList(New RolRequest() With {.ObjRoles = bjCargo})
        Return Response.ListadoRoles
    End Function

    Public Function RoleListXUnidOrg(bjCargo As Rol) As List(Of Rol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.RoleListXUnidOrg(New RolRequest() With {.ObjRoles = bjCargo})
        Return Response.ListadoRoles
    End Function

    Public Function RoleListSingle(bjCargo As Rol) As List(Of Rol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.RoleListSingle(New RolRequest() With {.ObjRoles = bjCargo})
        Return Response.ListadoRoles
    End Function

    Public Function RoleRegister(be As Rol) As Rol
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.RoleRegister(New RolRequest() With {.ObjRoles = be})
        Return Response.ObjRoles
    End Function

    Public Function RoleRegisterSingle(be As Rol) As Rol
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.RoleRegisterSingle(New RolRequest() With {.ObjRoles = be})
        Return Response.ObjRoles
    End Function

    Public Function ListadoRoles() As List(Of Rol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoRoles()
        Return Response.ListadoRoles
    End Function

    Public Function GetRolesXcliente(objRol As Rol) As List(Of Rol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetRolesXcliente(New RolRequest() With {.ObjRoles = objRol})
        Return Response.ListadoRoles
    End Function

    Public Function GetRolesXEstablecimiento(objRol As Rol) As List(Of Rol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetRolesXEstablecimiento(New RolRequest() With {.ObjRoles = objRol})
        Return Response.ListadoRoles
    End Function

    Public Function RolInsertSingle(objRol As Rol) As Rol
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.RolInsertSingle(New RolRequest() With {.ObjRoles = objRol})
        Return Response.ObjRoles
    End Function

    Public Function ListadoRolesXID(IdRol As Integer) As Rol
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoRolesXID(New RolRequest With {.idRol = IdRol})
        Return Response.ObjRoles
    End Function

    Public Function ListadoRolesClienteXID(be As Rol) As Rol
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoRolesClienteXID(New RolRequest With {.ObjRoles = be})
        Return Response.ObjRoles
    End Function

    Public Function insertRol(objRol As Rol) As Rol
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetInserRoles(New RolRequest() With {.ObjRoles = objRol})
        Return Response.ObjRoles
    End Function

    Public Function updateRol(objRol As Rol) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetUpdateRol(New RolRequest() With {.ObjRoles = objRol})
        Return Response.idRol
    End Function

End Class

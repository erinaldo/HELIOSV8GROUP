Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.MessageContract
Imports Helios.general
Public Class AutorizacionRolSA

    Public Function GetAsegurableXRol(be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetAsegurableXRol(New AutorizacionRolRequest() With {.AutorizacionRol = be})
        Return Response.AutorizacionRolList
    End Function
    Public Sub GetUpdateAutorizacion(be As AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetUpdateAutorizacion(New AutorizacionRolRequest() With {.AutorizacionRol = be})
    End Sub

    Public Sub EliminarPermisoRol(be As AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPermisoRol(New AutorizacionRolRequest() With {.AutorizacionRol = be})
    End Sub

    Public Sub RegistrarPermisoRol(be As AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.RegistrarPermisoRol(New AutorizacionRolRequest() With {.AutorizacionRol = be})
    End Sub

    Public Sub GetUpdateAutorizacionXcliente(be As AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetUpdateAutorizacionXcliente(New AutorizacionRolRequest() With {.AutorizacionRol = be})
    End Sub

    Public Sub InsertItem(be As AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertItem(New AutorizacionRolRequest() With {.AutorizacionRol = be})
    End Sub

    Public Sub InsertProductoXPerfil(be As List(Of AutorizacionRol))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertProductoXPerfil(New AutorizacionRolRequest() With {.AutorizacionRolList = be})
    End Sub

    Public Function GetProductoXRolXID(AutorizacionRolBE As AutorizacionRol) As AutorizacionRol
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetProductoXRolXID(New AutorizacionRolRequest() With {.AutorizacionRol = AutorizacionRolBE})
        Return Response.AutorizacionRol
    End Function

    Public Function GetAutorizacionesByRol(be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetAutorizacionesByRol(New AutorizacionRolRequest() With {.AutorizacionRol = be})
        Return Response.AutorizacionRolList
    End Function

    Public Function GetAutorizacionesRolXcliente(be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetAutorizacionesRolXcliente(New AutorizacionRolRequest() With {.AutorizacionRol = be})
        Return Response.AutorizacionRolList
    End Function


    Public Function GetAutorizacionesRolXProducto(be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetAutorizacionesRolXProducto(New AutorizacionRolRequest() With {.AutorizacionRol = be})
        Return Response.AutorizacionRolList
    End Function

    Public Function GetAutorizacionesELI(be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetAutorizacionesELI(New AutorizacionRolRequest() With {.AutorizacionRol = be})
        Return Response.AutorizacionRolList
    End Function

    Public Function GetListaAutorizaciones(ByVal be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ObtenerListaAutorizaciones(New AutorizacionRolRequest() With {.AutorizacionRol = be})
        Return Response.AutorizacionRolList
    End Function

    Public Function GetListaAutorizacionesSingle(ByVal be As AutorizacionRol) As List(Of AutorizacionRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetListaAutorizacionesSingle(New AutorizacionRolRequest() With {.AutorizacionRol = be})
        Return Response.AutorizacionRolList
    End Function

    Public Shared Function TienePermiso(ByVal IDAsegurable As Integer, ByVal lista As List(Of AutorizacionRol)) As Boolean
        Dim be = lista.Where(Function(a) a.IDAsegurable = IDAsegurable).FirstOrDefault
        TienePermiso = False
        If be IsNot Nothing AndAlso be.EstaAutorizado Then
            TienePermiso = True
        End If
    End Function




    Public Function GetListaAutorizacionesxPadre(ByVal objAutorizacionRol As AutorizacionRol,
                                                 ByVal objAsegurable As Asegurable) As List(Of Asegurable)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ObtenerListaAutorizacionesPorAsegurablePadre(New AutorizacionRolRequest() With {.AutorizacionRol = objAutorizacionRol,
                                                                                                                .Asegurable = objAsegurable})
        Return Response.AsegurableList
    End Function

End Class

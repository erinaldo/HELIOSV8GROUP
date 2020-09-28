Imports Helios.Cont.Business.Entity
Public Class ConfiguracionPrecioSA

    Public Sub GrabarPrecioGeneral(listaProductos As configuracionPrecio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarPrecioGeneral(listaProductos)
    End Sub

    Public Sub UpdatePrecioGeneral(listaProductos As configuracionPrecio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdatePrecioGeneral(listaProductos)
    End Sub

    Public Sub DeletePrecioGeneral(listaProductos As configuracionPrecio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeletePrecioGeneral(listaProductos)
    End Sub

    Public Function ListadoPrecios() As List(Of configuracionPrecio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoPrecios()
    End Function

    Public Function EncontrarPrecioXitem(configBE As configuracionPrecio) As configuracionPrecio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.EncontrarPrecioXitem(configBE)
    End Function
End Class

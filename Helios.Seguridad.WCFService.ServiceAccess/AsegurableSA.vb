Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.MessageContract
Public Class AsegurableSA
    Public Function ListadoAsegurables() As List(Of Asegurable)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetAsegurables()
        Return Response.ListadoAsegurables
    End Function

    Public Function GetAsegurableXidCliente(objAsegurable As Asegurable) As List(Of Asegurable)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetAsegurableXidCliente(New AsegurableRequest With {.ObjAsegurables = objAsegurable})
        Return Response.ListadoAsegurables
    End Function

    Public Function ListadoAsegurablesxFullID(listaAsegurables As List(Of Integer)) As List(Of Asegurable)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetListaAsegurables(New AsegurableRequest() With {.ListadoAsegurablesID = listaAsegurables})
        Return Response.ListadoAsegurables
    End Function

    Public Function insertAsegurable(objAsegurable As Asegurable) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetInsertAsegurable(New AsegurableRequest() With {.ObjAsegurables = objAsegurable})
        Return Response.idAsegurables
    End Function

    Public Function ListadoAsegurableXID(IdAsegurable As Integer) As Asegurable
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoAsegurableXID(New AsegurableRequest With {.idAsegurables = IdAsegurable})
        Return Response.ObjAsegurables
    End Function

    Public Function updateAsegurable(objAsegurable As Asegurable) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.updateAsegurable(New AsegurableRequest() With {.ObjAsegurables = objAsegurable})
        Return Response.idAsegurables
    End Function

    Public Function GetListaAsegurablesPadre(ObjAsegurable As Asegurable) As List(Of Asegurable)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetListaAsegurablesPadre(New AsegurableRequest() With {.ObjAsegurables = ObjAsegurable})
        Return Response.ListadoAsegurables
    End Function

    Public Function GetListaAsegurablesXCliente(ObjAsegurable As Asegurable) As List(Of Asegurable)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetListaAsegurablesXCliente(New AsegurableRequest() With {.ObjAsegurables = ObjAsegurable})
        Return Response.ListadoAsegurables
    End Function

    Public Function GetAsegurablesByPadreXcliente(ObjAsegurable As Asegurable) As List(Of Asegurable)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetAsegurablesByPadreXcliente(New AsegurableRequest() With {.ObjAsegurables = ObjAsegurable})
        Return Response.ListadoAsegurables
    End Function
End Class

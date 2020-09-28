Imports Helios.Cont.Business.Entity

Public Class RutasSA
    Public Function GellAllRutas(be As rutas) As List(Of rutas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GellAllRutas(be)
    End Function

    Public Sub InsertarRuta(be As rutas)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertarRuta(be)
    End Sub

    Public Function GetRutaSelCodigo(be As rutas) As rutas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRutaSelCodigo(be)
    End Function

    Public Function RutaSelID(be As rutas) As rutas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RutaSelID(be)
    End Function
End Class

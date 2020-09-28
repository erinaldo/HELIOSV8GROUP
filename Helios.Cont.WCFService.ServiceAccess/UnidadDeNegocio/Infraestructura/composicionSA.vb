Imports Helios.Cont.Business.Entity
Public Class composicionSA

    Public Function SaveComposicionFull(listaComposicion As List(Of composicion)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveComposicionFull(listaComposicion)
    End Function

    Public Function GetUbicarComposicion(composicionBE As composicion) As List(Of composicion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarComposicion(composicionBE)
    End Function

    Public Function UpdateComposicionFull(composicionBE As composicion, listaComposicion As List(Of composicion))
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateComposicionFull(composicionBE, listaComposicion)
    End Function

    Public Function GetUbicarComposicionXId(composicionBE As composicion) As List(Of composicion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarComposicionXId(composicionBE)
    End Function

End Class

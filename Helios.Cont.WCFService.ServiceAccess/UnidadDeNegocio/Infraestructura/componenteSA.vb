Imports Helios.Cont.Business.Entity
Public Class componenteSA
    Public Function getListaComponente(componenteBE As componente) As List(Of componente)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getListaComponente(componenteBE)
    End Function

    Public Function getListaComponenteXTipo(componenteBE As componente) As List(Of componente)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getListaComponenteXTipo(componenteBE)
    End Function

    Public Function SaveComponenteFull(i As List(Of componente)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveComponenteFull(i)
    End Function

    Public Function SaveComponente(ComponenteBE As componente) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveComponente(ComponenteBE)
    End Function

    Public Function getListaComponenteXIdPadre(componenteBE As componente) As List(Of componente)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getListaComponenteXIdPadre(componenteBE)
    End Function

End Class

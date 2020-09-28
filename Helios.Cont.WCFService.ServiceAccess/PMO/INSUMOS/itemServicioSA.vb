Imports Helios.Cont.Business.Entity
Public Class itemServicioSA


    Public Function SaveCategoriaServicio(nCat As itemServicio) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveInsumoServicio(nCat)
    End Function

    Public Function GetListaItemsPorTipo(be As itemServicio) As List(Of itemServicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaItemServicioPorTipo(be)
    End Function

    Public Function UbicarCategoriaServicioPorID(intIdCategoria As Integer) As itemServicio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCategoriaServicioPorID(intIdCategoria)
    End Function

End Class

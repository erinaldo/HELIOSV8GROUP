Imports Helios.Cont.Business.Entity
Public Class categoriaInfraestructuraSA

    Public Function GetUbicarCategoriaInfraestructura(categoriaInfraestructuraBE As categoriaInfraestructura) As List(Of categoriaInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarCategoriaInfraestructura(categoriaInfraestructuraBE)
    End Function

    Public Function GetUbicarCategoriaAndListaSubCategoria(categoriaInfraestructuraBE As categoriaInfraestructura) As List(Of categoriaInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarCategoriaAndListaSubCategoria(categoriaInfraestructuraBE)
    End Function

    Public Function SaveCategoriaInfraestructura(objCategoria As categoriaInfraestructura) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCategoriaInfraestructura(objCategoria)
    End Function

    Public Function GetUbicarCategoriaInfraestructuraXID(categoriaInfraestructuraBE As categoriaInfraestructura) As categoriaInfraestructura
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarCategoriaInfraestructuraXID(categoriaInfraestructuraBE)
    End Function

End Class

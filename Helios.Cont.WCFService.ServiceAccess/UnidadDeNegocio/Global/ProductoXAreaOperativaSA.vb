Imports Helios.Cont.Business.Entity
Public Class ProductoXAreaOperativaSA

    Public Function GetProductoXAreaOperativaxID(be As ProductoXAreaOperativa) As List(Of ProductoXAreaOperativa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductoXAreaOperativaxID(be)
    End Function

    Public Function GetInsertarProductoXAreaOperativaSingle(con As productoxAreaOperativa) As productoxAreaOperativa
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInsertarProductoXAreaOperativaSingle(con)
    End Function

End Class

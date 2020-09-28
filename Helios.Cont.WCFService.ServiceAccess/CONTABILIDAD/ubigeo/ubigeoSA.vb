Imports Helios.Cont.Business.Entity
Public Class ubigeoSA
    Public Function listarUbigeo() As List(Of ubigeo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.listarUbigeo()
    End Function

#Region "UBIGEO FABIO"

    Public Function ListarGetUbigeos() As List(Of regiones)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarGetUbigeos()
    End Function
#End Region
End Class

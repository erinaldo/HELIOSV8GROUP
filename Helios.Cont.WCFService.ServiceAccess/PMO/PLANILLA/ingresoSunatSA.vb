Imports Helios.Cont.Business.Entity
Public Class ingresoSunatSA


    Public Function ObtenerTablaPorId(intIdPadre As Integer) As List(Of ingresoSunat)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of ingresoSunat)
        miLista = miServicio.GetUbicarIdPadre(intIdPadre)
        Return miLista
    End Function


    Public Function InsertarIngresoSunat(ByVal nCodSunat As ingresoSunat) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarIngresoSunat(nCodSunat)
    End Function

    Public Function UpdateIngresoSunat(ByVal nCodSunat As ingresoSunat) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarIngresoSunat(nCodSunat)
        Return True
    End Function

    Public Function DeleteIngresoSunat(ByVal nCodSunat As ingresoSunat) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteIngresoSunat(nCodSunat)
        Return True
    End Function


End Class

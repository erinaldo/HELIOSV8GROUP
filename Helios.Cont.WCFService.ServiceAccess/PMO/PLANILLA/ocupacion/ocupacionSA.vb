Imports Helios.Cont.Business.Entity
Public Class ocupacionSA

    Public Function GetUbicarOcupacionPorID(intCodOcupacion As Integer) As ocupacion
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As ocupacion
        miLista = miServicio.GetUbicarOcupacionPorID(intCodOcupacion)
        Return miLista
    End Function

    Public Function GetUbicarOcupacionPorNombre(strNombre As String, intIdEstable As Integer) As ocupacion
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As ocupacion
        miLista = miServicio.GetUbicarOcupacionPorNombre(strNombre, intIdEstable)
        Return miLista
    End Function

    Public Function ObtenerOcupacion(idEstable As Integer) As List(Of ocupacion)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of ocupacion)
        miLista = miServicio.GetUbicarOcupacion(idEstable)
        Return miLista
    End Function


    Public Function InsertarOcupacion(ByVal codOcupa As ocupacion) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarOcupacion(codOcupa)
    End Function

    Public Function UpdateOcupacion(ByVal codOcupa As ocupacion) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarOcupacion(codOcupa)
        Return True
    End Function

    Public Function DeleteOcupacion(ByVal codOcupa As ocupacion) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteOcupacion(codOcupa)
        Return True
    End Function

End Class

Imports Helios.Cont.Business.Entity
Public Class distribucionNumeracionAOSA

    Public Function InsertNumeracionXAreaOperativa(ByVal numeracionBoletasBE As distribucionNumeracionAO) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertNumeracionXAreaOperativa(numeracionBoletasBE)
    End Function

    Public Function InsertAreaOperativaNumeracion(ByVal numeracionBoletasBE As distribucionNumeracionAO) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertAreaOperativaNumeracion(numeracionBoletasBE)
    End Function

    Public Function InsertListaNumeracionAo(conItem As List(Of distribucionNumeracionAO)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertListaNumeracionAo(conItem)
    End Function

End Class

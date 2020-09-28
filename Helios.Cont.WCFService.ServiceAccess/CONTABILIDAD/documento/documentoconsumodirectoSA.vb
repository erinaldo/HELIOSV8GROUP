Imports Helios.Cont.Business.Entity
Public Class documentoconsumodirectoSA

    Public Function GetConsumoByidDocumento(be As documentoconsumodirecto) As List(Of documentoconsumodirecto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsumoByidDocumento(be)
    End Function

    Public Function GetSumaBySecuencia(be As documentoconsumodirecto) As Decimal
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaBySecuencia(be)
    End Function

    Public Sub GetSaveConsumo(doc As documento, lista As List(Of documentoconsumodirecto))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetSaveConsumo(doc, lista)
    End Sub
End Class

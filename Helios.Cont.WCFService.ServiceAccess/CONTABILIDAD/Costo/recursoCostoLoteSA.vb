Imports Helios.Cont.Business.Entity
Public Class recursoCostoLoteSA

    Public Function GetLotesSelVerificacion(be As recursoCostoLote) As List(Of recursoCostoLote)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetLotesSelVerificacion(be)
    End Function

    Public Function GetLotes() As List(Of recursoCostoLote)

    End Function

    Public Function ExisteCodigoLote(lote As String) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ExisteCodigoLote(lote)
    End Function

    Public Function GetLoteByID(codigoLote As Integer) As recursoCostoLote
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetLoteByID(codigoLote)
    End Function

    Public Sub EditarLote(recursoCostoLote As recursoCostoLote)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarLote(recursoCostoLote)
    End Sub
End Class

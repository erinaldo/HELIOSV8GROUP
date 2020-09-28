Imports Helios.Cont.Business.Entity

Public Class LoteDetalleSA

    Public Sub GuardarLoteDetalle(be As recursoCostoLote, lista As List(Of LoteDetalle))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GuardarLoteDetalle(be, lista)
    End Sub

End Class

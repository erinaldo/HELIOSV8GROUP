Imports Helios.Cont.Business.Entity
Public Class documentoAnticipoDetalleSA



    Public Function ObtenerCuentasPagadasAnticipo(strDocumentoAfectado As Integer) As List(Of documentoAnticipoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorPagarAnticipoDetails(strDocumentoAfectado)
    End Function

End Class

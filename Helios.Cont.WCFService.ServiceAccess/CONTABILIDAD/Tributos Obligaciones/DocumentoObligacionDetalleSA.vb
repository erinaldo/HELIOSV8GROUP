Imports Helios.Cont.Business.Entity
Public Class DocumentoObligacionDetalleSA

    Public Function ComprobanteTieneTributo(intIdDocumentoOrigen As Integer) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ExistenDatosDetalleObligacion(intIdDocumentoOrigen)
    End Function

    Public Function UbicarDetallePorTributo(intIdDocumento As Integer) As List(Of documentoObligacionDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDetallePorTributo(intIdDocumento)
    End Function
End Class

Imports Helios.Cont.Business.Entity
Public Class DocumentoGuiaDetalleSA
    Public Function UbicarDocumentoGuiaDetalle(intIdDocumento As Integer) As List(Of documentoguiaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoGuiaDetalle(intIdDocumento)
    End Function

    Public Function UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento As Integer) As documentoguiaDetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
    End Function

    Public Function GetAlmacenesDistribuidosParaEmision(secuenciaCompra As Integer, idCompra As Integer) As List(Of documentoguiaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAlmacenesDistribuidosParaEmision(secuenciaCompra, idCompra)
    End Function

    Public Function UbicarDocumentoGuiaRemision(stremp As String, periodo As String) As List(Of documentoguiaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarGuiaRemision(stremp, periodo)
    End Function

    Public Function UbicarGuiaDetallePorIdDocumentoguia(intIdDocumento As Integer) As List(Of documentoguiaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarGuiaDetallePorIdDocumentoguia(intIdDocumento)
    End Function
End Class

Imports Helios.Cont.Business.Entity
Public Class DocumentoGuiaDetalleCondicionSA
    Public Sub SaveGuiaRemisionCondicion(objDocumento As List(Of documentoguiaDetalleCondicion), objDocumentoDet As List(Of documentoguiaDetalle))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveGuiaRemisionCondicion(objDocumento, objDocumentoDet)
    End Sub

    Function UbicarDocumentoGuiaDetCondicionFull(intIdDocumento As Integer) As List(Of documentoguiaDetalleCondicion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoGuiaDetCondicionFull(intIdDocumento)
    End Function

    Public Sub SaveGuiaRemisionCondicionTransferenciaAlmacenSC(objDocumento As List(Of documentoguiaDetalleCondicion), objDocumentoDet As List(Of documentoguiaDetalle), objListaAsiento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveGuiaRemisionCondicionTransferenciaAlmacenSC(objDocumento, objDocumentoDet, objListaAsiento)
    End Sub



End Class

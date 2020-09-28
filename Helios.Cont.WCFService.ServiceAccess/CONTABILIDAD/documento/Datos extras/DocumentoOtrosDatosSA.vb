Imports Helios.Cont.Business.Entity
Public Class DocumentoOtrosDatosSA

    Public Function UbicarDocumentoOtros(intIdDocumento As Integer) As documentoOtrosDatos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoOtros(intIdDocumento)
    End Function

    Public Function UbicarDocumentoOtrosReferencia(intIdDocumento As Integer) As documentoOtrosDatos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoOtrosReferencia(intIdDocumento)
    End Function

    Public Function UpdateOtros(ByVal be As documentoOtrosDatos) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateDocOtros(be)
        Return True
    End Function

    Public Sub GrabarDatosEntregaOrdenesFull(ByVal documentoOtrosDatosBE As List(Of documentoOtrosDatos), intIdDocumento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDatosEntregaOrdenesFull(documentoOtrosDatosBE, intIdDocumento)
    End Sub

    Public Function UbicarDocumentoOtrosHistorialEntrega(intIdDocumento As Integer) As List(Of documentoOtrosDatos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoOtrosHistorialEntrega(intIdDocumento)
    End Function

    Public Function DeleteSingleOC(ByVal idDocumento As Integer) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteSingleOC(idDocumento)
        Return True
    End Function

    Public Sub GrabarDatosEntregaOrdenes(ByVal documentoOtrosDatosBE As documentoOtrosDatos, ByVal documentoCompraDeatlle As documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDatosEntregaOrdenes(documentoOtrosDatosBE, documentoCompraDeatlle)
    End Sub

    Public Sub GrabarDatosEntregaOrdeneCompra(ByVal documentoOtrosDatosBE As documentoOtrosDatos, ByVal intidDocumento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDatosEntregaOrdeneCompra(documentoOtrosDatosBE, intidDocumento)
    End Sub

End Class

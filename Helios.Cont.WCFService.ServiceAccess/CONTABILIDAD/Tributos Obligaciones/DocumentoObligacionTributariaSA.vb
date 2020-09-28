Imports Helios.Cont.Business.Entity
Public Class DocumentoObligacionTributariaSA

    Public Function SaveObligacion(objDocumento As documento, intIdDocumentoOrigen As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveObligacion(objDocumento, intIdDocumentoOrigen)
    End Function

    Public Sub UpdateTributo(objDocumento As documento, intIdDocumentoOrigen As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateTributo(objDocumento, intIdDocumentoOrigen)
    End Sub

    Public Function UbicarDocumentoObligacion(intIdDocumento As Integer) As documentoObligacionTributaria
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoObligacion(intIdDocumento)
    End Function

    Public Function ListadoTributoPorIdDocumentoOrigen(intIdDocumentoOrigen) As List(Of documentoObligacionTributaria)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoTributoPorIdDocumentoOrigen(intIdDocumentoOrigen)
    End Function

    Public Function UbicarTributoPorIdDocumentoCompra(intIdDocumento As Integer) As documentoObligacionTributaria
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarTributoPorIdDocumentoCompra(intIdDocumento)
    End Function

    Public Sub EliminarObligacion(intIdDocumento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarObligacion(intIdDocumento)
    End Sub

    Public Sub EliminarObligacionPercepcion(intIdDocumento As Integer, intIdDocumentoTributo As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarObligacionPercepcion(intIdDocumento, intIdDocumentoTributo)
    End Sub

End Class

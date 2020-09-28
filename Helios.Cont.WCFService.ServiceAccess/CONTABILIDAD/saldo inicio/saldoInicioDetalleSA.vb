Imports Helios.Cont.Business.Entity
Public Class saldoInicioDetalleSA
    Public Function ListadoMercaderiaXidDocumento(intIdDocumento As Integer) As List(Of saldoInicioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoMercaderiaXidDocumento(intIdDocumento)
    End Function

    Public Function ListadoDetalleSaldoXidDocumento(intIdDocumento As Integer) As List(Of saldoInicioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoDetalleSaldoXidDocumento(intIdDocumento)
    End Function
End Class

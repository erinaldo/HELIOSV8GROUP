Imports Helios.Cont.Business.Entity
Public Class documentoPedidoDetSA

    Public Function GetUbicar_DocveNTAxIdDistribucion(documentoPedidoBE As documentoPedido) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_DocveNTAxIdDistribucion(documentoPedidoBE)
    End Function

    Public Function GetUbicar_DocXInfraXAreaFull(documentoPedidoBE As documentoPedido) As List(Of documentoPedidoDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_DocXInfraXAreaFull(documentoPedidoBE)
    End Function

    Public Sub EditarEstadoPedido(i As documentoPedidoDet)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarEstadoPedido(i)
    End Sub

    Public Sub EditarEstadoPedidoMasivo(i As List(Of documentoPedidoDet))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarEstadoPedidoMasivo(i)
    End Sub

    Public Sub EditarEstadoDocPedidoMasivo(i As distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarEstadoDocPedidoMasivo(i)
    End Sub

    Public Function GetUbicar_DocveNTAxIdCliente(documentoPedidoBE As documentoPedido) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_DocveNTAxIdCliente(documentoPedidoBE)
    End Function

End Class

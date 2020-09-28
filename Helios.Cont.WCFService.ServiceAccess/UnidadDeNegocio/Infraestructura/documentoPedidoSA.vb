Imports Helios.Cont.Business.Entity
Public Class documentoPedidoSA

    Public Function getListaInfraestructuraFullPedido(infraestructuraBE As infraestructura) As List(Of infraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getListaInfraestructuraFullPedido(infraestructuraBE)
    End Function


End Class

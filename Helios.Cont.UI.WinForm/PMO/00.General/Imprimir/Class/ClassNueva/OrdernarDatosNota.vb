Public Class OrdernarDatosNota
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerNroPedido(ByVal NroPedido As String) As String
        Dim delimitado() As String = NroPedido.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerFechaPedido(ByVal FechaPedido As String) As String
        Dim delimitado() As String = FechaPedido.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerOrdenCompra(ByVal OrdenCompra As String) As String
        Dim delimitado() As String = OrdenCompra.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function ObtenerFechaOrden(ByVal FechaOrden As String) As String
        Dim delimitado() As String = FechaOrden.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function ObtenerGuiaRemision(ByVal GuiaRemision As String) As String
        Dim delimitado() As String = GuiaRemision.Split(delimitador)
        Return delimitado(4)
    End Function

    Public Function ObtenerFechaGuia(ByVal FechaGuia As String) As String
        Dim delimitado() As String = FechaGuia.Split(delimitador)
        Return delimitado(5)
    End Function

    Public Function ObtenerMotivoEmision(ByVal MotivoEmision As String) As String
        Dim delimitado() As String = MotivoEmision.Split(delimitador)
        Return delimitado(6)
    End Function

    Public Function ObtenerDocumento(ByVal Documento As String) As String
        Dim delimitado() As String = Documento.Split(delimitador)
        Return delimitado(7)
    End Function

    Public Function ObtenerNumeroDocumento(ByVal NumeroDocumento As String) As String
        Dim delimitado() As String = NumeroDocumento.Split(delimitador)
        Return delimitado(8)
    End Function


    Public Function GenerarTotal(ByVal NroPedido As String,
                                 ByVal FechaPedido As String,
                                 ByVal OrdenCompra As String,
                                 ByVal FechaOrden As String,
                                 ByVal GuiaRemision As String,
                                 ByVal FechaGuia As String,
                                 ByVal MotivoEmision As String,
                                 ByVal Documento As String,
                                   ByVal NumeroDocumento As String) As String
        GenerarTotal = NroPedido + delimitador(0) +
        FechaPedido + delimitador(0) +
        OrdenCompra + delimitador(0) +
        FechaOrden + delimitador(0) +
        GuiaRemision + delimitador(0) +
        FechaGuia + delimitador(0) +
        MotivoEmision + delimitador(0) +
        Documento + delimitador(0) +
        NumeroDocumento
    End Function
End Class

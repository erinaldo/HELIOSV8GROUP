Public Class OrdernarSubEncabezadoInicioTraslado
    Public delimitador() As Char = "^"

    'fechaEmisiom, fechaInicioTraslado, motivoDeTraslado, ModalidadTransporte,
    '                                                           TipoDeTraslado, PesoBruto

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function OrdernarfechaEmision(ByVal fechaEmision As String) As String
        Dim delimitado() As String = fechaEmision.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerfechaInicioTraslado(ByVal fechaInicioTraslado As String) As String
        Dim delimitado() As String = fechaInicioTraslado.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenermotivoDeTraslado(ByVal motivoDeTraslado As String) As String
        Dim delimitado() As String = motivoDeTraslado.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function ObtenerModalidadTransporte(ByVal ModalidadTransporte As String) As String
        Dim delimitado() As String = ModalidadTransporte.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function ObtenerTipoDeTraslado(ByVal TipoDeTraslado As String) As String
        Dim delimitado() As String = TipoDeTraslado.Split(delimitador)
        Return delimitado(4)
    End Function

    Public Function ObtenerPesoBruto(ByVal PesoBruto As String) As String
        Dim delimitado() As String = PesoBruto.Split(delimitador)
        Return delimitado(5)
    End Function

    Public Function GenerarImprimir(ByVal fechaEmisiom As String, ByVal fechaInicioTraslado As String, ByVal motivoDeTraslado As String,
                                      ByVal ModalidadTransporte As String, ByVal TipoDeTraslado As String, ByVal PesoBruto As String) As String

        GenerarImprimir = fechaEmisiom + delimitador(0) +
                            fechaInicioTraslado + delimitador(0) +
                            motivoDeTraslado + delimitador(0) +
                            ModalidadTransporte + delimitador(0) +
                            TipoDeTraslado + delimitador(0) +
                            PesoBruto
    End Function

End Class

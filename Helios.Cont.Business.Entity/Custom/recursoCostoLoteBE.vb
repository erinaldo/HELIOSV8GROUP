Partial Public Class recursoCostoLote
    Inherits BaseBE

    Public Property UnidadComercial As String
    Public Property TipoDoc As String
    Public Property serieDoc As String
    Public Property numerodoc As String
    Public Property Proveedor As String
    Public Property stock As Decimal?

    Public Property CustomCompraDetail As documentocompradetalle

    Public Property CustomCompra As documentocompra

    Public Property CustomProducto As detalleitems

    Public Property CustomRecursoCostoLoteTallaList As List(Of recursoCostoLoteTalla)


    Public ReadOnly Property GetPrice() As Decimal?
        Get
            If cantidad > 0 Then
                Return precioUnitarioIva / cantidad
            Else
                Return 0
            End If
        End Get
    End Property

End Class

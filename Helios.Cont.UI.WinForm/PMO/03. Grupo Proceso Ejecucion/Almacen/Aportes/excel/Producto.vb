Option Strict On
Public Class Producto

    Public Property _tipoAporte() As String
    Public Property _clasificacion() As String
    Public Property _gravado() As String
    Public Property _detalle() As String
    Public Property _unidadMedida() As String
    Public Property _presentacion() As String
    Public Property _tipoExistencia() As String
    Public Property _cantidadAporte() As Decimal
    Public Property _precioUnit() As Decimal

    Property tipoAporte() As String
        Get
            Return _tipoAporte
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _tipoAporte = "N"
            Else
                _tipoAporte = value
            End If
        End Set
    End Property

    Property clasificacion() As String
        Get
            Return _clasificacion
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _clasificacion = "N"
            Else
                _clasificacion = value
            End If
        End Set
    End Property

    Property gravado() As String
        Get
            Return _gravado
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _gravado = "N"
            Else
                _gravado = value
            End If
        End Set
    End Property

    Property detalle() As String
        Get
            Return _detalle
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _detalle = "N"
            Else
                _detalle = value
            End If
        End Set
    End Property

    Property unidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _unidadMedida = "N"
            Else
                _unidadMedida = value
            End If
        End Set
    End Property

    Property presentacion() As String
        Get
            Return _presentacion
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _presentacion = "N"
            Else
                _presentacion = value
            End If
        End Set
    End Property

    Property tipoExistencia() As String
        Get
            Return _tipoExistencia
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _tipoExistencia = "N"
            Else
                _tipoExistencia = value
            End If
        End Set
    End Property

    Property cantidadAporte() As Decimal
        Get
            Return _cantidadAporte
        End Get
        Set(ByVal value As Decimal)
            If IsNothing(value) Then
                _cantidadAporte = 0
            Else
                _cantidadAporte = value
            End If
        End Set
    End Property

    Property precioUnit() As Decimal
        Get
            Return _precioUnit
        End Get
        Set(ByVal value As Decimal)
            If IsNothing(value) Then
                _precioUnit = 0
            Else
                _precioUnit = value
            End If
        End Set
    End Property

End Class

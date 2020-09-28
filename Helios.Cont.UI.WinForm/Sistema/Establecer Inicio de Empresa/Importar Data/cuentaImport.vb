Option Strict On
Public Class cuentaImport
    Private Property _cuenta As String
    Private Property _descripcion As String
    Private Property _tipoAsiento As String
    Private Property _debe As Decimal
    Private Property _haber As Decimal

    Public Property cuenta() As String
        Get
            Return _cuenta
        End Get
        Set(ByVal value As String)
            _cuenta = value
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property tipoAsiento() As String
        Get
            Return _tipoAsiento
        End Get
        Set(ByVal value As String)
            _tipoAsiento = value
        End Set
    End Property

    Public Property debe() As Decimal
        Get
            Return _debe
        End Get
        Set(ByVal value As Decimal)
            _debe = value
        End Set
    End Property

    Public Property haber() As Decimal
        Get
            Return _haber
        End Get
        Set(ByVal value As Decimal)
            _haber = value
        End Set
    End Property



End Class

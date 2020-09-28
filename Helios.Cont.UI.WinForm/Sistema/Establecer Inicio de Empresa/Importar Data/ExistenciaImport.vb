Option Strict On
Public Class ExistenciaImport
    Private Property _codigodetalle As String
    Private Property _idEmpresa() As String
    Private Property _descripcionItem() As String
    Private Property _presentacion() As String
    Private Property _unidad1() As String
    Private Property _tipoExistencia() As String
    Private Property _origenProducto() As String
    Private Property _tipoProducto() As String

    Private Property _stock() As Decimal
    Private Property _cantMinima() As Decimal
    Private Property _cantMaxima() As Decimal
    Private Property _costoMN() As Decimal
    Private Property _costoME() As Decimal

    Private Property _precio_menor() As Decimal
    Private Property _precio_mayor() As Decimal
    Private Property _precio_granmayor() As Decimal


    Public Property precio_granmayor() As Decimal
        Get
            Return _precio_granmayor
        End Get
        Set(ByVal value As Decimal)
            _precio_granmayor = value
        End Set
    End Property


    Public Property precio_mayor() As Decimal
        Get
            Return _precio_mayor
        End Get
        Set(ByVal value As Decimal)
            _precio_mayor = value
        End Set
    End Property


    Public Property precio_menor() As Decimal
        Get
            Return _precio_menor
        End Get
        Set(ByVal value As Decimal)
            _precio_menor = value
        End Set
    End Property

    Public Property stock() As Decimal
        Get
            Return _stock
        End Get
        Set(ByVal value As Decimal)
            _stock = value
        End Set
    End Property

    Public Property cantMinima() As Decimal
        Get
            Return _cantMinima
        End Get
        Set(ByVal value As Decimal)
            _cantMinima = value
        End Set
    End Property

    Public Property cantMaxima() As Decimal
        Get
            Return _cantMaxima
        End Get
        Set(ByVal value As Decimal)
            _cantMaxima = value
        End Set
    End Property

    Public Property costoMN() As Decimal
        Get
            Return _costoMN
        End Get
        Set(ByVal value As Decimal)
            _costoMN = value
        End Set
    End Property

    Public Property costoME() As Decimal
        Get
            Return _costoME
        End Get
        Set(ByVal value As Decimal)
            _costoME = value
        End Set
    End Property

    Public Property codigodetalle() As String
        Get
            Return _codigodetalle
        End Get
        Set(ByVal value As String)
            _codigodetalle = value
        End Set
    End Property

    Public Property idEmpresa() As String
        Get
            Return _idEmpresa
        End Get
        Set(ByVal value As String)
            _idEmpresa = value
        End Set
    End Property

    Public Property descripcionItem() As String
        Get
            Return _descripcionItem
        End Get
        Set(ByVal value As String)
            _descripcionItem = value
        End Set
    End Property

    Public Property presentacion() As String
        Get
            Return _presentacion
        End Get
        Set(ByVal value As String)
            _presentacion = value
        End Set
    End Property

    Public Property unidad1() As String
        Get
            Return _unidad1
        End Get
        Set(ByVal value As String)
            _unidad1 = value
        End Set
    End Property

    Public Property tipoExistencia() As String
        Get
            Return _tipoExistencia
        End Get
        Set(ByVal value As String)
            _tipoExistencia = value
        End Set
    End Property

    Public Property origenProducto() As String
        Get
            Return _origenProducto
        End Get
        Set(ByVal value As String)
            _origenProducto = value
        End Set
    End Property

    Public Property tipoProducto() As String
        Get
            Return _tipoProducto
        End Get
        Set(ByVal value As String)
            _tipoProducto = value
        End Set
    End Property


End Class

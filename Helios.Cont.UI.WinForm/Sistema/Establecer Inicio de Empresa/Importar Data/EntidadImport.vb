Option Strict On
Public Class EntidadImport
    Public Property _idEntidad() As Integer
    Public Property _idEmpresa() As String
    Public Property _tipoEntidad() As String
    Public Property _tipoPersona() As String
    Public Property _tipoDoc() As String
    Public Property _nrodoc() As String
    Public Property _nombreCompleto() As String
    Public Property _direccion() As String
    Public Property _telefono() As String
    Public Property _celular() As String
    Public Property _email() As String
    Public Property _moneda() As String
    Public Property _tipoCambio() As Decimal?
    Public Property _importeMN() As Decimal?
    Public Property _importeME() As Decimal?

    Property moneda() As String
        Get
            Return _moneda
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _moneda = "N"
            Else
                _moneda = value
            End If
        End Set
    End Property

    Property tipoCambio() As Decimal?
        Get
            Return _tipoCambio
        End Get
        Set(ByVal value As Decimal?)
            _tipoCambio = value
        End Set
    End Property

    Property importeMN() As Decimal?
        Get
            Return _importeMN
        End Get
        Set(ByVal value As Decimal?)
            _importeMN = value
        End Set
    End Property

    Property importeME() As Decimal?
        Get
            Return _importeME
        End Get
        Set(ByVal value As Decimal?)
            _importeME = value
        End Set
    End Property

    Property idEntidad() As Integer
        Get
            Return _idEntidad
        End Get
        Set(ByVal value As Integer)
            _idEntidad = value
        End Set
    End Property

    Property idEmpresa() As String
        Get
            Return _idEmpresa
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _idEmpresa = "N"
            Else
                _idEmpresa = value
            End If
        End Set
    End Property

    Property tipoEntidad() As String
        Get
            Return _tipoEntidad
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _tipoEntidad = "N"
            Else
                _tipoEntidad = value
            End If
        End Set
    End Property

    Property tipoPersona() As String
        Get
            Return _tipoPersona
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _tipoPersona = "N"
            Else
                _tipoPersona = value
            End If
        End Set
    End Property

    Property tipoDoc() As String
        Get
            Return _tipoDoc
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _tipoDoc = "N"
            Else
                _tipoDoc = value
            End If
        End Set
    End Property

    Property nrodoc() As String
        Get
            Return _nrodoc
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _nrodoc = "N"
            Else
                _nrodoc = value
            End If
        End Set
    End Property

    Property nombreCompleto() As String
        Get
            Return _nombreCompleto
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _nombreCompleto = "N"
            Else
                _nombreCompleto = value
            End If
        End Set
    End Property

    Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _direccion = "N"
            Else
                _direccion = value
            End If
        End Set
    End Property

    Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _telefono = "N"
            Else
                _telefono = value
            End If
        End Set
    End Property

    Property celular() As String
        Get
            Return _celular
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _celular = "N"
            Else
                _celular = value
            End If
        End Set
    End Property

    Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _email = "N"
            Else
                _email = value
            End If
        End Set
    End Property

End Class





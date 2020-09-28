Option Strict On
Public Class Entregable
    Private _nroEntregable As Integer
    Private _dniResponsable As Integer
    Private _nomResponsable As String
    Private _apPatResponsable As String
    Private _apMatResponsable As String
    Private _concepto As String
    Private _FechaEntregable As DateTime
    Private _Descripcion As String

    Property nomResponsable() As String
        Get
            Return _nomResponsable.Trim
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _nomResponsable = "N"
            Else
                If value.Trim.Length > 0 Then
                    _nomResponsable = value.ToUpper
                Else
                    _nomResponsable = "N"
                End If
            End If
        End Set
    End Property

    Property dniResponsable() As Integer
        Get
            Return _dniResponsable
        End Get
        Set(ByVal value As Integer)
            If IsNothing(value) Then
                _dniResponsable = 0
            Else
                _dniResponsable = CInt(value)
            End If
        End Set
    End Property

    Property apPatResponsable() As String
        Get
            Return _apPatResponsable
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _apPatResponsable = "N"
            Else
                If value.Trim.Length > 0 Then
                    _apPatResponsable = value
                Else
                    _apPatResponsable = "N"
                End If
            End If
        End Set
    End Property

    Property apMatResponsable() As String
        Get
            Return _apMatResponsable
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _apMatResponsable = "N"
            Else
                If value.Trim.Length > 0 Then
                    _apMatResponsable = value
                Else
                    _apMatResponsable = "N"
                End If
            End If
        End Set
    End Property

    Property concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _concepto = "N"
            Else
                If value.Trim.Length > 0 Then
                    _concepto = value
                Else
                    _concepto = "N"
                End If
            End If
        End Set
    End Property

    Property nroEntregable() As Integer
        Get
            Return _nroEntregable
        End Get
        Set(ByVal value As Integer)
            If IsNothing(value) Then
                _nroEntregable = 0
            Else
                _nroEntregable = CInt(value)
            End If
        End Set
    End Property

    Property FechaEntregable() As DateTime
        Get
            Return _FechaEntregable
        End Get
        Set(ByVal value As DateTime)
            If IsNothing(value) Then
                _FechaEntregable = Date.Now
            Else
                _FechaEntregable = CDate(value)
            End If
        End Set
    End Property

    Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _Descripcion = "N"
            Else
                If value.Trim.Length > 0 Then
                    _Descripcion = value
                Else
                    _Descripcion = "N"
                End If
            End If
        End Set
    End Property

End Class

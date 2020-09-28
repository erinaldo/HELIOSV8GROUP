Public Class Personas

    Private NumDoc As String
    Private Nombres As String
    Private Appat As String
    Private Apmat As String
    Private NomCompleto As String

    Sub New(ByVal numero As String, ByVal nom As String, ByVal ap As String, ByVal am As String)
        Me._NumDoc = numero
        Me._Nombres = nom
        Me._Appat = ap
        Me._Apmat = am
    End Sub

    Public Property _NumDoc() As String
        Get
            Return NumDoc
        End Get
        Set(ByVal value As String)
            If value.Trim.Length > 0 Then
                NumDoc = value
            Else
                Throw New Exception("Ingrese el Número de documento")
            End If
        End Set
    End Property

    Public Property _Nombres() As String
        Get
            Return Nombres
        End Get
        Set(ByVal value As String)
            If value.Trim.Length > 0 Then
                Nombres = value
            Else
                Throw New Exception("Ingrese un Nombre válido")
            End If
        End Set
    End Property

    Public Property _Appat() As String
        Get
            Return Appat
        End Get
        Set(ByVal value As String)
            If value.Trim.Length > 0 Then
                Appat = value
            Else
                Throw New Exception("Ingrese el apellido paterno")
            End If

        End Set
    End Property

    Public Property _Apmat() As String
        Get
            Return Apmat
        End Get
        Set(ByVal value As String)
            If value.Trim.Length > 0 Then
                Apmat = value
            Else
                Throw New Exception("Ingrese el apellido materno")
            End If

        End Set
    End Property

    Public ReadOnly Property _NomCompleto() As String
        Get
            Return String.Concat(_Appat, Space(1), _Apmat, ", ", _Nombres)
        End Get
    End Property

End Class

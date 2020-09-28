
Public Class RecuperarTablas

    Private Shared datos As List(Of RecuperarTablas)

    Public Shared Function Instance() As List(Of RecuperarTablas)

        If datos Is Nothing Then
            datos = New List(Of RecuperarTablas)
        End If

        Return datos
    End Function

    Private m_ID As String
    Public Property ID() As String
        Get
            Return m_ID
        End Get
        Set(ByVal value As String)
            m_ID = value
        End Set
    End Property

    Private m_Codigo As String
    Public Property Codigo() As String
        Get
            Return m_Codigo
        End Get
        Set(ByVal value As String)
            m_Codigo = value
        End Set
    End Property

    Private m_Nombre As String
    Public Property NombreCampo() As String
        Get
            Return m_Nombre
        End Get
        Set(ByVal value As String)
            m_Nombre = value
        End Set
    End Property

End Class

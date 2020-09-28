Imports System.Collections.Generic
'Imports System.Linq
Imports System.Text
Public Class RecuperarSerie

    Private Shared datos As List(Of RecuperarSerie)

    Public Shared Function Instance() As List(Of RecuperarSerie)

        If datos Is Nothing Then
            datos = New List(Of RecuperarSerie)
        End If

        Return datos
    End Function

    Private m_Serie As String
    Public Property Serie() As String
        Get
            Return m_Serie
        End Get
        Set(ByVal value As String)
            m_Serie = value
        End Set
    End Property

End Class

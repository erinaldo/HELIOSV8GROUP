Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Public Class RecuperarEntidadFinanciera
    Private Shared datos As List(Of RecuperarEntidadFinanciera)

    Public Shared Function Instance() As List(Of RecuperarEntidadFinanciera)

        If datos Is Nothing Then
            datos = New List(Of RecuperarEntidadFinanciera)
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

    Private m_NombreEntidad As String
    Public Property NombreEntidad() As String
        Get
            Return m_NombreEntidad
        End Get
        Set(ByVal value As String)
            m_NombreEntidad = value
        End Set
    End Property

    Private m_Cuenta As String
    Public Property Cuenta() As String
        Get
            Return m_Cuenta
        End Get
        Set(ByVal value As String)
            m_Cuenta = value
        End Set
    End Property

End Class

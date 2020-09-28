Public Class RecuperarDatosPlaneamiento
    Private Shared datos As List(Of RecuperarDatosPlaneamiento)

    Public Shared Function Instance() As List(Of RecuperarDatosPlaneamiento)

        If datos Is Nothing Then
            datos = New List(Of RecuperarDatosPlaneamiento)
        End If

        Return datos
    End Function

    Private m_TipoSustento As String
    Public Property TipoSustento() As String
        Get
            Return m_TipoSustento
        End Get
        Set(ByVal value As String)
            m_TipoSustento = value
        End Set
    End Property

    Private m_Monto2 As Decimal
    Public Property Monto2() As Decimal
        Get
            Return m_Monto2
        End Get
        Set(ByVal value As Decimal)
            m_Monto2 = value
        End Set
    End Property

  
End Class

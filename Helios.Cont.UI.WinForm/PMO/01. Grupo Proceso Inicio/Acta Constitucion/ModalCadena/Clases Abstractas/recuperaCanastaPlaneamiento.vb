Public Class recuperaCanastaPlaneamiento
    Private Shared datos As List(Of recuperaCanastaPlaneamiento)

    Public Shared Function Instance() As List(Of recuperaCanastaPlaneamiento)

        If datos Is Nothing Then
            datos = New List(Of recuperaCanastaPlaneamiento)
        End If
        Return datos
    End Function
    Public Property SinTarea() As Boolean

    Public Property m_Dato1() As String
    Public Property m_Dato2() As String
    Public Property m_Dato3() As String
    Public Property m_Dato4() As String
    Public Property m_Dato5() As String
    Public Property m_Dato6() As String
    Public Property m_Dato7() As String
    Public Property m_Dato8() As String
    Public Property m_Dato9() As String
    Public Property m_Dato10() As String
    Public Property m_Dato11() As String
    Public Property m_Dato12() As String
    Public Property m_Dato13() As String
    Public Property m_Dato14() As String
    Public Property m_Dato15() As String
    Public Property m_Dato16() As String
    Public Property m_Dato17() As String
    Public Property m_Dato18() As String
    Public Property m_Dato19() As String
    Public Property m_Dato20() As String
    Public Property m_Dato21() As String
    Public Property m_Dato22() As String
    Public Property m_Dato23() As String
    Public Property m_Dato24() As String
    Public Property m_Dato25() As String
    Public Property m_Dato26() As String
    Public Property m_Dato27() As String
    Public Property m_Dato28() As String
    Public Property m_Dato29() As String
    Public Property m_Dato30() As String

    Public Property GrupoOperacional() As String
    Public Property IdPersonal() As String
    Public Property Personal() As String
    Public Property FechaInicio() As Date?
    Public Property FechaFin() As Date?
    Public Property HoraInicio() As String
    Public Property HoraFin() As String
    Public Property Ocurrencias() As String

    Public Property Estado() As String

  

End Class

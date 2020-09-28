Partial Public Class Usuario
    Inherits BaseBE

    Property CustomUsuarioRol As UsuarioRol
    Property CustomAutenticacionUsuario As AutenticacionUsuario

    Property CustomListaUsuarioRol As List(Of UsuarioRol)

    Public ReadOnly Property Full_Name() As String
        Get
            Return String.Format("{0} {1} {2}", ApellidoPaterno, ApellidoMaterno, Nombres)
        End Get
    End Property
    Public Property Rol() As String

    Public Property userName() As String


    Public Property password() As String

    Public Property nombrecargo() As String

    Public Property IDRol() As Integer

End Class

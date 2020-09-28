Partial Public Class AutenticacionUsuario
    Inherits BaseBE

    Public Property EstaAutenticado As Boolean
    Public Property TieneCaja As Boolean?
    Public Property IdEmpresa() As String
    Public Property IDEstablecimiento() As Integer
    Property CustomUsuario As Usuario
    Property IDCliente As String
    Property AliasLogin As String
    Property PasswordNuevo As String

    Public Property numeracion() As Integer
    Public Property IDRol() As Integer
    Public Property nombreCargo() As String

    Public Property tipoCaja() As String

    Public Property tipoCargo() As String

    Public Property tipoNegocio() As String

End Class

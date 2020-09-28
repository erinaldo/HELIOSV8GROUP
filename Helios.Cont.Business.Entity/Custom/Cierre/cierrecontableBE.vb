Partial Public Class cierrecontable
    Inherits BaseBE

    Public Property dia() As Integer

    Public Property CustomAsiento As asiento

    Public Property cuentaCierre As String
    Public Property DebeCierre() As Decimal
    Public Property HaberCierre() As Decimal

    Public Property cuentaMovimiento As String
    Public Property DebeMovimiento() As Decimal
    Public Property HaberMovimiento() As Decimal

    Public Property nomCuenta() As String
    Public Property codigoLibro() As String

End Class

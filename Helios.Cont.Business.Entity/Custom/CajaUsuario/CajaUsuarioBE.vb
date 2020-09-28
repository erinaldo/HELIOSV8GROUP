Partial Public Class cajaUsuario
    Inherits BaseBE
    Public Property CustomListaUsuarios As List(Of Integer)


    Public Property IdDocumentoVenta() As Integer
    Public Property NombrePersona() As String
    Public Property numeroDocumento() As String
    Public Property NombreCajaOrigen() As String
    Public Property NombreCajaDestino() As String
    Public Property cuentaCajaOrigen() As Integer
    Public Property CuentaCajaDestino() As Integer

    Public Property idEntidad() As Integer
    Public Property NombreEntidad() As String
    Public Property Tipo() As String

    Public ReadOnly Property Saldo() As String
        Get
            Return fondoMN + ingresoAdicMN - otrosEgresosMN
        End Get
       
    End Property

    Public ReadOnly Property SaldoME() As String
        Get
            Return fondoME + ingresoAdicME - otrosEgresosME
        End Get

    End Property

End Class

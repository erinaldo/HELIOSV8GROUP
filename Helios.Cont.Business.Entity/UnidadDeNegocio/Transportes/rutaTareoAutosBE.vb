Partial Public Class rutaTareoAutos
    Inherits BaseBE

    Public Property customRuta As rutas

    Public Property customruta_horarios As ruta_horarios

    Public Property customRuta_HorarioServicios As ruta_HorarioServicios

    Public Property customPersona As Persona

    Public Property customEntidad As entidad

    Public Property Asiento As Integer

    Public Property ImporteVenta As Decimal

    Public Property TipoDocVenta As String

    Public Property tipoPersona() As String

    Public ReadOnly Property GetNameLarge() As String
        Get
            Return $"{customRuta.ciudadOrigen}-{customRuta.ciudadDestino}"
        End Get
    End Property
End Class

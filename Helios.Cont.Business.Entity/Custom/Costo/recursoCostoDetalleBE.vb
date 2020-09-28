Partial Public Class recursoCostoDetalle
    Inherits BaseBE

    Public Property NombreCosto() As String
    Public Property ManoObra() As String
    Public Property NombreProceso() As String
    Public Property MesTrabajado() As Integer
    Public Property actividad() As String
    Public Property IdProyecto() As Integer
    Public Property CantEjecutada() As Decimal
    Public Property NomActividad() As String
    Public Property idActividad() As String
    Public Property cuenta() As String
    Public Property montoCosto() As Decimal
    Public Property cantidadCosto() As Decimal

    Public ReadOnly Property MDP() As String
        Get
            Dim STR As String = Nothing
            Select Case ManoObra
                Case "MATERIA PRIMA DIRECTA"
                    STR = "MDP"

                Case "MANO DE OBRA DIRECTA"
                    STR = "MOD"

                Case "COSTOS INDIRECTOS DE FABRICACION"
                    STR = "CIF"
            End Select
            Return STR
        End Get
    End Property

    Public Property TipoOperacionBase() As String
    Public Property tipoDocBase() As String
    Public Property NroComprobateBase() As String


End Class

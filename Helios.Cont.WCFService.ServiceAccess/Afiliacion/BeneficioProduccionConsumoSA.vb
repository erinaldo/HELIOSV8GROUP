Imports Helios.Cont.Business.Entity
Public Class BeneficioProduccionConsumoSA
    Public Function GetBeneficiosSelTipo(be As beneficioProduccionConsumo) As List(Of beneficioProduccionConsumo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetBeneficiosSelTipo(be)
    End Function

    Public Function BeneficioSelID(be As beneficioProduccionConsumo) As beneficioProduccionConsumo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BeneficioSelID(be)
    End Function
End Class

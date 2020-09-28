Imports Helios.Cont.Business.Entity

Public Class beneficioProduccionConsumoBL
    Inherits BaseBL

    Public Function GetBeneficiosSelTipo(be As beneficioProduccionConsumo) As List(Of beneficioProduccionConsumo)

        Return HeliosData.beneficioProduccionConsumo.ToList

    End Function

    Public Function BeneficioSelID(be As beneficioProduccionConsumo) As beneficioProduccionConsumo
        Return HeliosData.beneficioProduccionConsumo.Where(Function(o) o.produccion_id = be.produccion_id).SingleOrDefault
    End Function

End Class

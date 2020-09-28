Imports Helios.Cont.Business.Entity

Public Class beneficioSA
    Public Function BeneficioSelXID(be As beneficio) As beneficio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BeneficioSelXID(be)
    End Function

    Public Sub RegisterClientBeneficeCupon(be As beneficio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.RegisterClientBeneficeCupon(be)
    End Sub

    Public Sub RegisterClientBenefice(be As beneficio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.RegisterClientBenefice(be)
    End Sub

    Public Function BeneficioSelClienteProductions(be As beneficio) As beneficio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BeneficioSelClienteProductions(be)
    End Function

    Public Function BeneficioListaClienteProductions(be As beneficio) As List(Of beneficio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BeneficioListaClienteProductions(be)
    End Function

    Public Function CatalogoDeClientesBeneficio(be As entidad) As List(Of entidad)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CatalogoDeClientesBeneficio(be)
    End Function

    Public Function BeneficioListaClienteProductionCupones(be As beneficio) As List(Of beneficio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BeneficioListaClienteProductionCupones(be)
    End Function
End Class

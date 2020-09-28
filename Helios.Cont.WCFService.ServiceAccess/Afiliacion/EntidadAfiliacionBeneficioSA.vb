Imports Helios.Cont.Business.Entity
Public Class EntidadAfiliacionBeneficioSA
    Public Sub EntidadAfiliacionBeneficioSave(be As EntidadAfiliacionBeneficio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EntidadAfiliacionBeneficioSave(be)
    End Sub

    Public Function EntidadAfiliacionBeneficioStatus(be As EntidadAfiliacionBeneficio) As List(Of EntidadAfiliacionBeneficio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.EntidadAfiliacionBeneficioStatus(be)
    End Function

    Public Sub ChangeStatusAfiliado(be As EntidadAfiliacionBeneficio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ChangeStatusAfiliado(be)
    End Sub

    Public Function GetEntidadAfiliacionConteo(be As EntidadAfiliacionBeneficio) As List(Of EntidadAfiliacionBeneficio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEntidadAfiliacionConteo(be)
    End Function
End Class

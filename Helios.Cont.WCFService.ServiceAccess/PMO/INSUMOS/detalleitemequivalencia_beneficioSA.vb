Imports Helios.Cont.Business.Entity
Public Class detalleitemequivalencia_beneficioSA

    Public Function BeneficioSave(be As detalleitemequivalencia_beneficio) As detalleitemequivalencia_beneficio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BeneficioSave(be)
    End Function

End Class

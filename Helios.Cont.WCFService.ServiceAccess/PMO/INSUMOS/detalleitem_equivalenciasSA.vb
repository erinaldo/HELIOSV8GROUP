Imports Helios.Cont.Business.Entity

Public Class detalleitem_equivalenciasSA

    Public Function GetExisteCodeUnidadComercial(be As detalleitem_equivalencias) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExisteCodeUnidadComercial(be)
    End Function
    Public Function SaveEquivalencia(be As detalleitem_equivalencias) As detalleitem_equivalencias
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveEquivalencia(be)
    End Function

    Public Function EquivalenciaSelID(be As detalleitem_equivalencias) As detalleitem_equivalencias
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.EquivalenciaSelID(be)
    End Function

    Public Sub ChangeEstatusEquivalencia(obj As detalleitem_equivalencias)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ChangeEstatusEquivalencia(obj)
    End Sub
End Class

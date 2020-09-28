Imports Helios.Cont.Business.Entity
Public Class entidadAtributosSA
    Public Function AtributoEntidadSave(be As entidadAtributos) As entidadAtributos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.AtributoEntidadSave(be)
    End Function
End Class

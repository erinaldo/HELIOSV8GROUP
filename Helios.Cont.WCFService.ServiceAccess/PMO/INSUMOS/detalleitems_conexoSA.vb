Imports Helios.Cont.Business.Entity
Public Class detalleitems_conexoSA
    Public Function SaveConexo(be As detalleitems_conexo) As detalleitems_conexo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveConexo(be)
    End Function
End Class

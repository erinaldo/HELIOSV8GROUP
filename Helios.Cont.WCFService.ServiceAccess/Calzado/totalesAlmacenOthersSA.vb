Imports Helios.Cont.Business.Entity
Public Class totalesAlmacenOthersSA
    Public Function GetInventarioSelCodigo(be As totalesAlmacenOthers) As List(Of totalesAlmacenOthers)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventarioSelCodigo(be)
    End Function
End Class

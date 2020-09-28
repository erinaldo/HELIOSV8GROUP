Imports Helios.Cont.Business.Entity
Public Class TablaSA
    Function GetListaTabla() As List(Of tabla)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaTabla()
    End Function
End Class

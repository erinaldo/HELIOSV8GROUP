Imports Helios.Cont.Business.Entity
Public Class recursoCostoLoteTallaSA
    Public Sub recursoCostoLoteTallaSave(be As recursoCostoLoteTalla)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.recursoCostoLoteTallaSave(be)
    End Sub

    Public Sub recursoCostoLoteTallaSaveList(be As List(Of recursoCostoLoteTalla))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.recursoCostoLoteTallaSaveList(be)
    End Sub

    Public Sub RegistrarItems(be As recursoCostoLote)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.RegistrarItems(be)
    End Sub

End Class

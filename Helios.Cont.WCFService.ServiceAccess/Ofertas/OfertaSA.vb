Imports Helios.Cont.Business.Entity
Public Class OfertaSA

    Public Function OfertaSelCodigo(be As oferta) As oferta
        Dim servicio = General.GetHeliosProxy()
        Return servicio.OfertaSelCodigo(be)
    End Function

    Public Sub SaveOferta(be As oferta)
        Dim servicio = General.GetHeliosProxy()
        servicio.SaveOferta(be)
    End Sub

    Public Function OfertaSel(be As oferta) As oferta
        Dim servicio = General.GetHeliosProxy()
        Return servicio.OfertaSel(be)
    End Function

    Public Function OfertaSelAll(be As oferta) As List(Of oferta)
        Dim servicio = General.GetHeliosProxy()
        Return servicio.OfertaSelAll(be)
    End Function

End Class

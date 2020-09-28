Imports Helios.Cont.Business.Entity
Public Class cierreCostoVentaSA

    Public Function GetListado_cierreCostoVenta(cierreBE As cierreCostoVenta) As List(Of cierreCostoVenta)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListado_cierreCostoVenta(cierreBE)
    End Function


    Public Sub GrabarListaCierreCostoVenta(lista As List(Of cierreCostoVenta), objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarListaCierreCostoVenta(lista, objDocumento)
    End Sub

End Class

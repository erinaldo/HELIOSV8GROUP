Imports Helios.Cont.Business.Entity
Public Class totalesAlmacenRPTSA
    Function ObtenerProrAlmacenesPeriodoRPT(intIdAlmacen As Integer, strTipoEx As Integer, strBusqueda As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProrAlmacenesPeriodoRPT(intIdAlmacen, strTipoEx, strBusqueda)
    End Function

    Public Sub EditarCantMaxMin(ByVal totalesBE As totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateCantMaxMin(totalesBE)
    End Sub

End Class

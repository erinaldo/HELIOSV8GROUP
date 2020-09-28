Imports Helios.Cont.Business.Entity
Public Class documentoPrestamoSA

    Public Function ListadoMontosCuentas(idDoc As Integer) As List(Of documentoPrestamoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoMontosCuentas(idDoc)
    End Function

    Public Sub InsertPrestamoRecibido(documentoBE As documento, prestamobe As prestamos, listaDocumentos As List(Of documentoPrestamos), listaDetalle As List(Of documentoPrestamoDetalle))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertPrestamoRecibido(documentoBE, prestamobe, listaDocumentos, listaDetalle)
    End Sub


    Public Function ListadoFechasCuotas(idDoc As Integer) As List(Of documentoPrestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoFechasCuotas(idDoc)
    End Function


    Public Sub UpdateFechaPrestamos(documentoBE As prestamos, listaDocumentos As List(Of documentoPrestamos))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ActualizarFechaPrestamo(documentoBE, listaDocumentos)
    End Sub


    Public Sub InsertPrestamoOtorgado(documentoBE As documento, listaDocumentos As List(Of documentoPrestamos), listaDetalle As List(Of documentoPrestamoDetalle))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertPrestamoOtorgado(documentoBE, listaDocumentos, listaDetalle)
    End Sub





End Class

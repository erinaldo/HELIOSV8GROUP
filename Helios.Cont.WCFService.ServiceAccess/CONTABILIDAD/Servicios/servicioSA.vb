Imports Helios.Cont.Business.Entity
Public Class servicioSA

    Public Sub EditarTipoPrestamo(servicioBE As servicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarTipoPrestamo(servicioBE)
    End Sub



    Public Function GrabarTipoPrestamoPadre(servicioBE As servicio, detalleBE As List(Of servicio)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarTipoPrestamoPadre(servicioBE, detalleBE)
    End Function


    Public Function ListaConceptosPrestamo(codigo As String, tipoPrestamo As String) As List(Of servicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarConceptosPrestamos(codigo, tipoPrestamo)
    End Function

    Public Sub EditarConceptoPrestamo(servicioBE As servicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarConceptoPrestamo(servicioBE)
    End Sub

    Public Function GrabarConceptoPrestamo(servicioBE As servicio) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarConceptoPrestamo(servicioBE)
    End Function


    Public Sub UpdateServicio(servicioBE As servicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateServicio(servicioBE)
    End Sub


    Public Function GrabarNewServicio(servicioBE As servicio) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarNewServicio(servicioBE)
    End Function

    Public Function ListadoServiciosPadreTipo(ByVal tipo As String) As List(Of servicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoServiciosPadreTipo(tipo)
    End Function


    Public Function ListadoServiciosHijosXIdTipo(servicioBE As servicio) As List(Of servicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoServiciosHijosXIdTipo(servicioBE)
    End Function

    Public Function GrabarServicioPadre(servicioBE As servicio) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarServicioPadre(servicioBE)
    End Function

    Public Sub EliminarServicioPadreHijo(servicioBE As servicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarServicioPadreHijo(servicioBE)
    End Sub

    Public Sub EditarServicioPadre(servicioBE As servicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarServicioPadre(servicioBE)
    End Sub

    Public Function UbicarServicioPorId(servicioBE As servicio) As servicio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarServicioPorId(servicioBE)
    End Function
    Public Function ListadoServiciosHijos() As List(Of servicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoServiciosHijos()
    End Function

    Public Function ListadoServiciosHijosXtipo(servicioBE As servicio) As List(Of servicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoServiciosHijosXtipo(servicioBE)
    End Function

    Public Function GrabarServicio(servicioBE As servicio) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarServicio(servicioBE)
    End Function

    Public Sub EliminarServicio(servicioBE As servicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarServicio(servicioBE)
    End Sub

    Public Function InsertItemServicio(ByVal ProductoBE As List(Of servicio)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertItemServicio(ProductoBE)
    End Function

    Public Function InsertItemServicioSimple(ByVal ProductoBE As servicio) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertItemServicioSimple(ProductoBE)
    End Function

    Public Function GetListaServicios(ByVal ProductoBE As servicio) As List(Of servicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaServicios(ProductoBE)
    End Function

    Public Sub CambiarEstadoItemServicio(be As servicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarEstadoItemServicio(be)
    End Sub

    Public Function GetServicioByEmpresaConPrecios(empresa As String, tipo As String) As List(Of servicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetServicioByEmpresaConPrecios(empresa, tipo)
    End Function

    Public Function GetServicioSinAlmacenSearchText(empresa As String, search As String) As List(Of servicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetServicioSinAlmacenSearchText(empresa, search)
    End Function

    Public Function GetUbicaServicioID(intIdProducto As Integer) As servicio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicaServicioID(intIdProducto)
    End Function

    Public Function updateItemServicio(ByVal ProductoBE As servicio) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateItemServicio(ProductoBE)
    End Function

    Public Function GetServicioByEmpresaSinPrecios(empresa As String, tipo As String) As List(Of servicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetServicioByEmpresaSinPrecios(empresa, tipo)
    End Function

    Public Function ListadoServicios(SERVCIOBE As servicio) As List(Of servicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoServicios(SERVCIOBE)
    End Function

End Class

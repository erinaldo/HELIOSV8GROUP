Imports Helios.Cont.Business.Entity
Public Class tablaDetalleSA

    Public Sub GrabarListaTallaColor(be As List(Of tabladetalle))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarListaTallaColor(be)
    End Sub
    Public Function GetListaTablaDetalleTipos(strEstado As String) As List(Of tabladetalle)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of tabladetalle)
        miLista = miServicio.GetListaTablaDetalleTipos(strEstado)
        Return miLista
    End Function

    Public Sub CambiarStatusItem(be As tabladetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarStatusItem(be)
    End Sub

    Public Function GetListaTablaDetalleTodo(intIdTabla As Integer) As List(Of tabladetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaTablaDetalleTodo(intIdTabla)
    End Function

    Public Function ObtenerMaxTabla(be As tabladetalle) As String
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMaxTabla(be)
    End Function

    Public Function GetListaTablaDetalleMotivo(intIdTabla As Integer, strEstado As String, codigo As String) As List(Of tabladetalle)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of tabladetalle)
        miLista = miServicio.GetListaTablaDetalleMotivo(intIdTabla, strEstado, codigo)
        Return miLista
    End Function

    Public Function InsertarMarca(ByVal nTabDet As tabladetalle) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarMarca(nTabDet)
    End Function

    Public Function GetUbicarTablaexistenciaCambioInventario() As List(Of tabladetalle)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of tabladetalle)
        miLista = miServicio.GetUbicarTablaexistenciaCambioInventario()
        Return miLista
    End Function


    Public Function GetUbicarTablaexistencia() As List(Of tabladetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarTablaexistencia()
    End Function

    Public Function ObtenerTablaFull() As IList
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerTablaFull()
    End Function

    Public Function ObtenerTablaMaximo() As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerTablaMaximo()
    End Function

    Public Function GetListaTablaID(strDescripcion As String) As String
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaTablaID(strDescripcion)
    End Function

    Public Function ObtenerTablaPorNombre(strNombre As String) As List(Of tabladetalle)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of tabladetalle)
        miLista = miServicio.GetUbicarTablaNombre(strNombre)
        Return miLista
    End Function

    Public Function GetListaTablaDetalle(intIdTabla As Integer, strEstado As String) As List(Of tabladetalle)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of tabladetalle)
        miLista = miServicio.GetListaTablaDetalle(intIdTabla, strEstado)
        Return miLista
    End Function

    Public Function GetListaTablaDetalleXusuario(intIdTabla As Integer, strEstado As String, listaoperacion As List(Of String)) As List(Of tabladetalle)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of tabladetalle)
        miLista = miServicio.GetListaTablaDetalleXusuario(intIdTabla, strEstado, listaoperacion)
        Return miLista
    End Function

    Public Function InsertarTablaDetalle(ByVal nTabDet As tabladetalle) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarTablaDetalle(nTabDet)
    End Function

    Public Function UpdateTablaDetalle(ByVal nTabDet As tabladetalle) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarTablaDetalle(nTabDet)
        Return True
    End Function

    Public Function DeleteTablaDetalle(ByVal nTabDet As tabladetalle) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteTablaDetalle(nTabDet)
        Return True
    End Function

    Public Function GetUbicarTablaID(intIdTabla As Integer, strCodigo As String) As tabladetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarTablaID(intIdTabla, strCodigo)
    End Function
End Class

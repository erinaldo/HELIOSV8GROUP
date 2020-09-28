Imports Helios.Cont.Business.Entity
Public Class almacenSA

    Public Function GetEsAlmacenVirtual(intIdAlmacen As Integer) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEsAlmacenVirtual(intIdAlmacen)
    End Function

    Public Function GetListar_almaUbiPunto(intIdEstablecimiento As Integer) As List(Of almacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_almaPuntoUbi(intIdEstablecimiento)
    End Function

    Public Function GetListar_almacenesTipo(intIdEstablecimiento As Integer, tipo As String) As List(Of almacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_almacenesTipo(intIdEstablecimiento, tipo)
    End Function

    Public Function GetListar_almacenesTipobyEmpresa(almacenBE As almacen) As List(Of almacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_almacenesTipobyEmpresa(almacenBE)
    End Function

    Public Function GetListar_almacenExceptAV(almacenBE As almacen) As List(Of almacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_almacenExceptAV(almacenBE)
    End Function

    Public Function GetListar_almacenALL(idEmpresa As String) As List(Of almacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_almacenALL(idEmpresa)
    End Function

    Public Function GetListar_almacenes(intIdEstablecimiento As Integer) As List(Of almacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_almacenes(intIdEstablecimiento)
    End Function

    Public Function GetUbicar_almacenPorID(idAlmacen As Integer) As almacen
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_almacenPorID(idAlmacen)
    End Function

    Public Function GetUbicar_almacenVirtual(intIdEstablecimiento As Integer) As almacen
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_almacenVirtual(intIdEstablecimiento)
    End Function

    Public Sub CambiarEstadoAlmacen(almacen As almacen)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarEstadoAlmacen(almacen)
    End Sub

    Public Function GetUbicar_almacenPredeterminado(intIdEstablecimiento As Integer) As almacen
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_almacenPredeterminado(intIdEstablecimiento)
    End Function

    Public Sub InsertNuevaAlmacen(lista As almacen)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertNuevaAlmacen(lista)
    End Sub


    Public Sub UpdateNuevaAlmacen(lista As almacen)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateNuevaAlmacen(lista)
    End Sub

    Public Sub DeleteNuevoAlmacen(ByVal almacenBE As almacen)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteNuevoAlmacen(almacenBE)
    End Sub


    Public Function GetEsAlmacenVirtualXFull(strIdempresa As String, intIdEstblec As Integer, intTipo As String) As almacen
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEsAlmacenVirtualXFull(strIdempresa, intIdEstblec, intTipo)
    End Function

    Public Function GetListar_almacenPorUsuario(idEmpresa As String, idEstable As Integer, listaPersona As List(Of String), intAnio As Integer, intMes As Integer, fechaInicio As DateTime, fechaFin As DateTime, tipo As String, intDia As Integer) As List(Of almacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_almacenPorUsuario(idEmpresa, idEstable, listaPersona, intAnio, intMes, fechaInicio, fechaFin, tipo, intDia)
    End Function

End Class

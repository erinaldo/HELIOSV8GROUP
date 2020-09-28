Imports Helios.Cont.Business.Entity

Public Class detalleitemcatalogo_comisionSA

    Public Function detalleitemcatalogo_comisionJoinList(be As detalleitemcatalogo_comision) As List(Of detalleitemcatalogo_comision)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.detalleitemcatalogo_comisionJoinList(be)
    End Function

    ''' <summary>
    ''' Registrar una comision
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Function detalleitemcatalogo_comisionSave(be As detalleitemcatalogo_comision)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.detalleitemcatalogo_comisionSave(be)
    End Function

    ''' <summary>
    ''' Seleccionar comision por catalogo de precios
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Function detalleitemcatalogo_comisionSelCatalogo(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.detalleitemcatalogo_comisionSave(be)
    End Function

    ''' <summary>
    ''' Seleccionar comision por unidad comercial del producto
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Function detalleitemcatalogo_comisionSelUnidadComercial(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.detalleitemcatalogo_comisionSelUnidadComercial(be)
    End Function

    ''' <summary>
    ''' Obtener todos las comisiones creadas por unidad o establecimiento
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Function detalleitemcatalogo_comisionList(be As detalleitemcatalogo_comision) As List(Of detalleitemcatalogo_comision)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.detalleitemcatalogo_comisionList(be)
    End Function

End Class

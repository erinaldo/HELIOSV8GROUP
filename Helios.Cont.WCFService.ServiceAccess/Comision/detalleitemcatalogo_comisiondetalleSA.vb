Imports Helios.Cont.Business.Entity
Public Class detalleitemcatalogo_comisiondetalleSA

    ''' <summary>
    ''' Asignar Usuario a una comision vigente
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Function detalleitemcatalogo_comisiondetalleSave(be As detalleitemcatalogo_comisiondetalle) As detalleitemcatalogo_comisiondetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.detalleitemcatalogo_comisiondetalleSave(be)
    End Function
End Class

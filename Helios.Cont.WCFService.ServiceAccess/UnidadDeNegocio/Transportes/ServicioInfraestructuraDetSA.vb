Imports Helios.Cont.Business.Entity
Public Class ServicioInfraestructuraDetSA
    Public Sub InsertServicioInfraestructuradet(objDocumento As List(Of servicioInfraestructuraDet))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertServicioInfraestructuraDet(objDocumento)
    End Sub

    Public Sub InsertServicioInfraestructuraSingle(objDocumento As servicioInfraestructuraDet)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertServicioInfraestructuraSingle(objDocumento)
    End Sub

    Public Function GellAllServiciosInfraDet(IdServicio As Integer) As List(Of servicioInfraestructuraDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GellAllServiciosInfraDet(IdServicio)
    End Function

    Public Function GellAllServiciosInfraDetxID(IdServicio As Integer, IdServicioDet As Integer) As servicioInfraestructuraDet
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GellAllServiciosInfraDetxID(IdServicio, IdServicioDet)
    End Function
End Class

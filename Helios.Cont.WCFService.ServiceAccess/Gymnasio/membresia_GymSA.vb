Imports Helios.Cont.Business.Entity
Public Class membresia_GymSA

    ''' <summary>
    ''' Registrar una nueva membresía
    ''' </summary>
    ''' <param name="be"> objeto tipo membresía</param>
    Public Sub GrabarMembresia(be As membresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarMembresia(be)
    End Sub

    Public Function UbicarMembresia(id As Integer) As membresia_Gym
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarMembresia(id)
    End Function

    Public Sub EditarMembresia(be As membresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarMembresia(be)
    End Sub

    Public Function GetMembresias() As List(Of membresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMembresias()
    End Function

    Public Shared Sub GrabarClienteMembresia(documento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarClienteMembresia(documento)
    End Sub

    Public Shared Function GetMembresiasByStatus(be As membresia_Gym) As List(Of membresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMembresiasByStatus(be)
    End Function
End Class

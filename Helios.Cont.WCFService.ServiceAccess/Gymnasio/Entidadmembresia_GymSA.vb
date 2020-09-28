Imports Helios.Cont.Business.Entity
Public Class Entidadmembresia_GymSA

    ''' <summary>
    ''' Historial de membresías contratadas x Socio
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Shared Function GetMembresiasContratadasXSocio(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMembresiasContratadasXSocio(be)
    End Function

    ''' <summary>
    ''' Registra la lista de membresias vencidas del día
    ''' </summary>
    ''' <param name="be">Lista de membresias enviadas a vencer</param>
    Public Shared Sub GetMembresiasVencidasDelDia(be As List(Of Entidadmembresia_Gym))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetMembresiasVencidasDelDia(be)
    End Sub

    ''' <summary>
    ''' Obtiene el número total de comprobantes vencidos: contador
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Shared Function GetMembresiasPorStatusMembresiaXfechaConteo(be As Entidadmembresia_Gym) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMembresiasPorStatusMembresiaXfechaConteo(be)
    End Function

    Public Shared Function GetMembresiasPorStatusMembresiaXfecha(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMembresiasPorStatusMembresiaXfecha(be)
    End Function

    Public Shared Function GetMembresiaActivaXSocio(be As Entidadmembresia_Gym) As Entidadmembresia_Gym
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMembresiaActivaXSocio(be)
    End Function

    Public Shared Function GetRegistroMembresiasByEmpresa(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRegistroMembresiasByEmpresa(be)
    End Function

    Public Shared Function GetDocumentoCajaMembresiaByDocumento(iddocumento As Integer) As Entidadmembresia_Gym
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDocumentoCajaMembresiaByDocumento(iddocumento)
    End Function

    Public Shared Function GetRegistroMembresiasByPeriodo(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRegistroMembresiasByPeriodo(be)
    End Function

    Public Shared Function GetUbicarDocumentoMembresia(idDocumento As Integer) As Entidadmembresia_Gym
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarDocumentoMembresia(idDocumento)
    End Function

    Public Shared Sub GetConfirmarInicio(be As Entidadmembresia_Gym, IsEnabled As Boolean)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetConfirmarInicio(be, IsEnabled)
    End Sub

    Public Shared Function GetMembresiasPorVencer(entidadmembresia_Gym As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMembresiasPorVencer(entidadmembresia_Gym)
    End Function

    Public Shared Function GetMembresiasPorVencerPeriodo(entidadmembresia_Gym As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMembresiasPorVencerPeriodo(entidadmembresia_Gym)
    End Function

    Public Shared Sub GetEliminarMembresia(be As Entidadmembresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetEliminarMembresia(be)
    End Sub
End Class

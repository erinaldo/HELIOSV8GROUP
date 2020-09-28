Imports Helios.Cont.Business.Entity

Public Class membresia_congelamientoSA

    Public Shared Function GetMaximoMinimoFechaCongelamiento(be As membresia_congelamiento) As membresia_congelamiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMaximoMinimoFechaCongelamiento(be)
    End Function

    Public Shared Sub GrabarGrupoCongelamiento(be As List(Of membresia_congelamiento))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarGrupoCongelamiento(be)
    End Sub

    Public Shared Function GetSumaCongelamientoByPeriodo(be As membresia_congelamiento) As List(Of membresia_congelamiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaCongelamientoByPeriodo(be)
    End Function

    Public Shared Sub GrabarCongelamiento(be As membresia_congelamiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarCongelamiento(be)
    End Sub

    Public Shared Function GetCongelamientoByDocumento(idDocumento As Integer) As List(Of membresia_congelamiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCongelamientoByDocumento(idDocumento)
    End Function

    Public Shared Sub EliminarCongelamiento(idcongelamiento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCongelamiento(idcongelamiento)
    End Sub

    Public Shared Sub GetCambiarEstado(membresia_Gym As membresia_Gym)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetCambiarEstado(membresia_Gym)
    End Sub
End Class

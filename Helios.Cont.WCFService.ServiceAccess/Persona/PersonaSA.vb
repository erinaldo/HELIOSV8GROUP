Imports Helios.Cont.Business.Entity
Public Class PersonaSA

    Public Function ObtenerPersonaNumDocPorNivelxDescripcion(ByVal strIDEmpresa As String, strNivel As String, strbusqueda As String) As List(Of Persona)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPersonaNumDocPorNivelxDescripcion(strIDEmpresa, strNivel, strbusqueda)
    End Function

    Public Function ObtenerPersona(PersonaBE As Persona) As List(Of Persona)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPersona(PersonaBE)
    End Function

    Public Function ObtenerPersonaNumDocPorNivel(ByVal strIDEmpresa As String, ByVal strNumDoc As String, strNivel As String) As Persona
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPersonaNumDocPorNivel(strIDEmpresa, strNumDoc, strNivel)
    End Function

    Public Function ObtenerPersonaNumDoc(strEmpresa As String, strNumDoc As String) As Persona
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPersonaNumDoc(strEmpresa, strNumDoc)
    End Function

    Public Function ObtenerPersonaPorNombres(strIDEmpresa As String, strNombres As String) As List(Of Persona)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPersonaPorNombres(strIDEmpresa, strNombres)
    End Function

    Public Function InsertPersona(nPersona As Persona) As Persona
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertPersona(nPersona)
    End Function

    Public Sub EditarPersona(nPersona As Persona)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdatePersona(nPersona)
    End Sub

    Public Sub EliminarPersona(nPersona As Persona)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeletePersona(nPersona)
    End Sub

End Class

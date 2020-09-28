Imports Helios.Cont.Business.Entity
Public Class personaBeneficioSA

    Public Sub SavePersonaBeneficio(ListaobjPersona As List(Of personaBeneficio), idDocumento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SavePersonaBeneficio(ListaobjPersona, idDocumento)
    End Sub

    Public Function ListarPersonaBeneficioXHabitacion(personas As personaBeneficio) As List(Of personaBeneficio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarPersonaBeneficioXHabitacion(personas)
    End Function

    Public Function UbicarHospedadoPorRucNro(strEmpresa As String, strNroDoc As String) As personaBeneficio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarHospedadoPorRucNro(strEmpresa, strNroDoc)
    End Function

    Public Function UbicarHospedadoPorID(PersonaBE As personaBeneficio) As personaBeneficio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarHospedadoPorID(PersonaBE)
    End Function

    Public Function ListarPersonaXHabXCliente(personas As personaBeneficio) As List(Of personaBeneficio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarPersonaXHabXCliente(personas)
    End Function

    Public Function ListarPersonaBeneficioXHabitacionActivo(personas As personaBeneficio) As List(Of personaBeneficio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarPersonaBeneficioXHabitacionActivo(personas)
    End Function

    Public Function ListarHospedadosXCliente(personasBE As personaBeneficio) As List(Of personaBeneficio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarHospedadosXCliente(personasBE)
    End Function

    Public Function ListarPersonaBeneficio(personas As personaBeneficio) As List(Of personaBeneficio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarPersonaBeneficio(personas)
    End Function

    Public Function ListarPersonaFull(personas As personaBeneficio) As List(Of personaBeneficio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarPersonaFull(personas)
    End Function
End Class

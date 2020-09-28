Imports Helios.Cont.Business.Entity
Public Class OrganizacionSA

    Public Function GetObtenerOrganizacion(strEmpresa As String) As List(Of organizacion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerOrganizacion(strEmpresa)
    End Function


    Public Function SaveOrganizacion(OrganizacionBE As organizacion) As organizacion
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveOrganizacion(OrganizacionBE)
    End Function

    Public Function GetObtenerParcialOrgani(strBE As organizacion) As List(Of organizacion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerParcialOrgani(strBE)
    End Function

    Public Sub ListOrgani(ByVal OrganizacionBE As List(Of organizacion))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ListOrgani(OrganizacionBE)
    End Sub

    Public Function GetOrganizacion(be As organizacion) As List(Of organizacion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetOrganizacion(be)
    End Function

    Public Function GetObtenerOrganigramaXPerfil(strBE As organizacion) As List(Of organizacion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerOrganigramaXPerfil(strBE)
    End Function

End Class

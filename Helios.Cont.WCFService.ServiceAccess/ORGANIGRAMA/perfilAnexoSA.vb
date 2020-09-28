Imports Helios.Cont.Business.Entity
Public Class perfilAnexoSA
    Public Sub SavePerfilAnexo(ByVal PerfilAnexoBE As List(Of perfilAnexo))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SavePerfilAnexo(PerfilAnexoBE)
    End Sub

    Public Sub UpdatePerfilAnexoSingle(ByVal PerfilAnexoBE As perfilAnexo)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdatePerfilAnexoSingle(PerfilAnexoBE)
    End Sub

    Public Sub SavePerfilAnexoSingle(ByVal PerfilAnexoBE As perfilAnexo)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SavePerfilAnexoSingle(PerfilAnexoBE)
    End Sub

    Public Function GetObtenerPerfilAnexo(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerPerfilAnexo(PerfilAnexoBE)
    End Function

    Public Function GetObtenerPerfilAnexoXID(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerPerfilAnexoXID(PerfilAnexoBE)
    End Function

    Public Function GetObtenerPerfilIDestablecimiento(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerPerfilIDestablecimiento(PerfilAnexoBE)
    End Function
End Class

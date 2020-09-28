Imports Helios.Cont.Business.Entity
Public Class mascaraContableExistenciaSA

    Public Function GetUbicar_mascaraContableExistenciaPorEmpresaCF(idEmpresa As String, strCuenta As String, strTipoEx As String) As mascaraContableExistencia
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_mascaraContableExistenciaPorEmpresaCF(idEmpresa, strCuenta, strTipoEx)
    End Function

    Function ObtenerMascaraExistencias(ByVal strIdEmpresa As String, ByVal strTipoExistencia As String) As List(Of mascaraContableExistencia)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMascaraExistencias(strIdEmpresa, strTipoExistencia)
    End Function

    Public Function InsertMascaraContableExistenciaSingle(ByVal mascaraContableExistBE As mascaraContableExistencia) As String
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertMascaraContableExistenciaSingle(mascaraContableExistBE)
    End Function

    Public Function UpdateMascaraContableExistenciaSingle(ByVal mascaraContableExistBE As mascaraContableExistencia) As String
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateMascaraContableExistenciaSingle(mascaraContableExistBE)
    End Function

End Class

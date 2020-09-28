Imports Helios.Cont.Business.Entity
Public Class mascaraContable2SA

    Public Function GetUbicar_mascaraContable2PorEmpresa(strIEmpresa As String, strCuenta As String) As mascaraContable2
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_mascaraContable2PorEmpresa(strIEmpresa, strCuenta)
    End Function

    Public Function ObtenerMascaraContableMercaderia(strEmpresa As String, InitCuenta As String) As IList(Of mascaraContable2)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMascaraContableMercaderia(strEmpresa, InitCuenta)
    End Function

    Public Function ObtenerMascaraContable2PorEmpresa(strIdEmpresa As String) As List(Of mascaraContable2)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMascaraContable2PorEmpresa(strIdEmpresa)
    End Function

    Public Function ObtenerMascaraContable2PorItems(strIdEmpresa As String) As List(Of mascaraContable2)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMascaraContable2PorItems(strIdEmpresa)
    End Function

    Public Function InsertarMascaraSingle(ByVal mascaraContable2BE As mascaraContable2) As Integer
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertarMascaraSingle(mascaraContable2BE)
        Return True
    End Function

    Public Function UpdateMascaraContable2(ByVal mascaraContable2BE As mascaraContable2) As String
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateMascaraContable2(mascaraContable2BE)
    End Function


End Class

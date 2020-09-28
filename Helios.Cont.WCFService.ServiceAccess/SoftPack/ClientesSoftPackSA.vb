Imports Helios.Cont.Business.Entity
Public Class ClientesSoftPackSA

    Public Shared Sub GrabarClienteSoftPack(be As clientesSoftPack, empresaBE As empresa, listaCentoCosto As List(Of centrocosto))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarClienteSoftPack(be, empresaBE, listaCentoCosto)
    End Sub

    Public Shared Function GetEmpresasClientes(RucCliente As String) As List(Of clientesSoftPack)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEmpresasClientes(RucCliente)
    End Function

    Public Shared Function GetProductoClientesXID(ClienteID As String) As clientesSoftPack
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductoClientesXID(ClienteID)
    End Function

End Class

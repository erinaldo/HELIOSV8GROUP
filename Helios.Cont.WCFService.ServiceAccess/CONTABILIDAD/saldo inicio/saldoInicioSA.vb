Imports Helios.Cont.Business.Entity
Public Class saldoInicioSA
    Public Function SaldosXpagarXproveedor(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, intIdProveedor As Integer) As List(Of saldoInicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaldosXpagarXproveedor(strEmpresa, intIdEstablecimiento, strPeriodo, intIdProveedor)
    End Function

    Public Function InsertarSaldos(documentoBE As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarSaldos(documentoBE)
    End Function

    Public Function InsertarAporteInicio(documentoBE As documento, listaProductosAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarAporteInicio(documentoBE, listaProductosAlmacen)
    End Function

    Public Function ListadoSaldosXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of saldoInicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoSaldosXperiodo(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Sub DeleteSaldoAporte(ByVal documentoBE As documento, ListaItemsAeliminar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteSaldoAporte(documentoBE, ListaItemsAeliminar)
    End Sub

    Public Function UbicarSaldoXidDocumento(intIdDocumento As Integer) As saldoInicio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarSaldoXidDocumento(intIdDocumento)
    End Function
End Class

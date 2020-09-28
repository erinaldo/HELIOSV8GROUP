Imports Helios.Cont.Business.Entity
Public Class documentoCompraRPTSA

    Public Function LidtadoNotasXempresa(fecINic As DateTime, fecHasta As DateTime, idProv As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.LidtadoNotasXempresa(fecINic, fecHasta, idProv)
    End Function

    Public Function GetListarComprasPorANioReporte(intIdEstablecimiento As Integer, ANio As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorANioReporte(intIdEstablecimiento, ANio)
    End Function

    Public Function GetListarComprasPorDiaReporte(intIdEstablecimiento As Integer, fechaDia As Date) As List(Of documentocompra)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorDiaReporte(intIdEstablecimiento, fechaDia)
    End Function

    Public Function GetListarComprasPorPeriodoReporte(intIdEstablecimiento As Integer,
                                             strPeriodo As String) As List(Of documentocompra)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodoReporte(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarMvimientosAlmacenPorDiaReporte(intIdEstablecimiento As Integer, strTipoCompra As String) As List(Of documentocompra)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarMvimientosAlmacenPorDiaReporte(intIdEstablecimiento, strTipoCompra)
    End Function

    Public Function OntenerListadoComprasPorPeriodo(strEmpresa As String, intIdEstablecimiento As Integer,
                                             strPeriodo As String) As List(Of documentocompra)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoComprasPorPeriodo(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function


    'martin
    Public Function OntenerListadoComprasPorEmpresa(strEmpresa As String,
                                             strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoComprasPorEmpresa(strEmpresa, strPeriodo)
    End Function


    'martin lista de compras con bonificacion
    Public Function OntenerListadoComprasConBonificacion(strEmpresa As String, intIdEstablecimiento As Integer,
                                             strPeriodo As String) As List(Of documentocompradetalle)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoComprasConBonificacion(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    'martin compra por proveedor empresa periodo

    Public Function OntenerListadoComprasPorProveedor(strEmpresa As String, intIdProveedor As Integer,
                                             strPeriodo As String) As List(Of documentocompra)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoComprasPorProveedor(strEmpresa, intIdProveedor, strPeriodo)
    End Function

    'martin compra por proveedor periodo y establecimiento

    Public Function OntenerListadoComprasPorProveedorEstablec(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer,
                                             strPeriodo As String) As List(Of documentocompra)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoComprasPorProveedorEstablec(strEmpresa, intIdEstablecimiento, intIdProveedor, strPeriodo)

    End Function


    'martin reporte de compra por aportaciones

    Public Function OntenerListadoComprasPorAportacionesPorDia(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentocompra)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoComprasPorAportacionesPorDia(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function OntenerListadoComprasPorAportaciones(strEmpresa As String, intIdEstablecimiento As Integer,
                                             strPeriodo As String) As List(Of documentocompra)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoComprasPorAportaciones(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function


    'martin reporte de compra aportaciones empresa

    Public Function OntenerListadoComprasAportacionesPorEmpresa(strEmpresa As String,
                               strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoComprasAportacionesPorEmpresa(strEmpresa, strPeriodo)
    End Function

    'martin aportaciones por empresa proveedor

    Public Function OntenerListadoComprasAportacionesPorProveedor(strEmpresa As String, intIdProveedor As Integer,
                                             strPeriodo As String) As List(Of documentocompra)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoComprasAportacionesProveedor(strEmpresa, intIdProveedor, strPeriodo)
    End Function

    'martin aportaciones por proveedor establecimeinto

    Public Function OntenerListadoComprasAportacionesPorProveedorEstablec(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer,
                                             strPeriodo As String) As List(Of documentocompra)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoComprasAportacionesPorProveedorEstablec(strEmpresa, intIdEstablecimiento, intIdProveedor, strPeriodo)

    End Function
End Class

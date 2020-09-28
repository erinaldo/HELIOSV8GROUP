Imports Helios.Cont.Business.Entity
Public Class documentoVentaRPTSA
    Public Function OntenerListadoVentasAbaXDia(strEmpresa As String, intIdEstablecimiento As String, day As Date) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoVentasAbarrotesDia(strEmpresa, intIdEstablecimiento, day)
    End Function

    Public Function OntenerListadoVentasAbarrotesPorMes(strEmpresa As String, intIdEstablecimiento As String,
                                            mes As Integer, anio As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoVentasAbarrotesPorMes(strEmpresa, intIdEstablecimiento, mes, anio)
    End Function

    'martin reporte ventasabarrotes pro empresa y establecimiento
    Public Function OntenerListadoVentasAbarrotesPorPeriodo(strEmpresa As String, intIdEstablecimiento As Integer,
                                             strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoVentasAbarrotes(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function OntenerListadoVentasAbarrotesPorDia(strEmpresa As String, intIdEstablecimiento As Integer, strTipoCompra As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoVentasAbarrotesPorDia(strEmpresa, intIdEstablecimiento, strTipoCompra)
    End Function

    'martin ventas abarrotes empresa

    Public Function OntenerListadoVentasAbarrotesPorEmpresa(strEmpresa As String,
                                             strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoVentasAbarrotesEmpresa(strEmpresa, strPeriodo)
    End Function

    'martin ventas por cliente

    Public Function OntenerListadoVentasAbarrotesPorCliente(strEmpresa As String, intIdEstablecimiento As Integer,
                                             strPeriodo As String, intIdCliente As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoVentasAbarrotesPorCliente(strEmpresa, intIdEstablecimiento, strPeriodo, intIdCliente)
    End Function

End Class

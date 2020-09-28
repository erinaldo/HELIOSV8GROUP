Imports Helios.Cont.Business.Entity
Public Class EstadosFinancierosSA

#Region "DEPURADO"
    Public Function ObtenerEstadosFinancierosPorEstablecimiento(estadoFinancieroBE As estadosFinancieros) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerEstadosFinancierosPorEstablecimiento(estadoFinancieroBE)
    End Function
#End Region

    Public Function GetCuentasFinancierasEmpresaXtipoFecha(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipoFecha_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasFinancierasEmpresaXtipoFecha(be)
    End Function

    Public Function GetCuentasFinancierasEmpresaXtipo(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipo_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasFinancierasEmpresaXtipo(be)
    End Function

    Public Function GetCuentasFinancierasEmpresaXtipoXidCaja(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipoXIdCaja_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasFinancierasEmpresaXtipoXidCaja(be)
    End Function

    Public Function GetSaldoCuentasFinancieraCajeroActivo(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraCajeroActivo_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSaldoCuentasFinancieraCajeroActivo(be)
    End Function
    Public Function GetEstadoCajasTodosDetalleByMensual(be As documentoCaja, periodoAnt As String)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoCajasTodosDetalleByMensual(be, periodoAnt)
    End Function

    Public Function GetEstadoCajasTodosDetalleByDia(be As documentoCaja) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoCajasTodosDetalleByDia(be)
    End Function

    Public Function GetEstadoCajasTodosDetalleByDiaAllEmpresa(be As documentoCaja) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoCajasTodosDetalleByDiaAllEmpresa(be)
    End Function

    Public Function GetEstadoCajasTodosByDia(be As documentoCaja) As estadosFinancieros
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoCajasTodosByDia(be)
    End Function

    Public Function GetEstadoCajasTodosByDiaAllEmpresa(be As documentoCaja) As estadosFinancieros
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoCajasTodosByDiaAllEmpresa(be)
    End Function

    Public Function GetCuentasFinancierasByEmpresa(ByVal idEmpresa As String, ByVal strTipo As String) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasFinancierasByEmpresa(idEmpresa, strTipo)
    End Function

    Public Function GetEstadoCajasTodos() As estadosFinancieros
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoCajasTodos()
    End Function

    Public Function GetEstadoCajasTodosDetalle() As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoCajasTodosDetalle()
    End Function

    Public Function GetEstadoSaldoXEFME(idestado As Integer) As estadosFinancieros
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoSaldoXEFME(idestado)
    End Function

    Public Function GetCuentasByTipoDeAporteInicio(be As estadosFinancieros) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasByTipoDeAporteInicio(be)
    End Function

    Public Function ListadoEstadosFinanConteo(strIdEmpresa As String, intEstablec As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoEstadosFinanConteo(strIdEmpresa, intEstablec)
    End Function

    Public Function GetSumaCuentasByTipo(be As estadosFinancieros) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaCuentasByTipo(be)
    End Function

    Public Function GetEstadoSaldoEF(EF As estadosFinancieros) As estadosFinancieros
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoSaldoEF(EF)
    End Function

    'agre
    Public Function ObtenerEFPorCuentaFinanciera(estadosFinancierosBE As estadosFinancieros) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerEFPorCuentaFinanciera(estadosFinancierosBE)
    End Function

    Public Function ObtenerEstadosFinancierosPorTipo(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, strBusqueda As String) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerEstadosFinancierosPorTipo1(intIdEstablecimiento, strTipo, strBusqueda)
    End Function
    'end agre

    Public Function ObtenerEstadosFinancierosPorMonedaXdescripcion(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, strBusqueda As String) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerEstadosFinancierosPorMonedaXdescripcion(intIdEstablecimiento, strTipo, strBusqueda)
    End Function

    Public Function ObtenerEstadosFinancierosPorTipo(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerEstadosFinancierosPorTipo(intIdEstablecimiento, strTipo)
    End Function



    Public Function ObtenerEstadosFinancierosPorMoneda(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, ByVal strMoneda As String) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerEstadosFinancierosPorMoneda(intIdEstablecimiento, strTipo, strMoneda)
    End Function

    Public Function GetUbicar_estadosFinancierosPorID(idestado As Integer) As estadosFinancieros
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_estadosFinancierosPorID(idestado)
    End Function

    Public Function ObtenerEstadosFinancierosPredeterminado(intIdEstablecimiento As Integer) As estadosFinancieros
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerEstadosFinancierosPredeterminado(intIdEstablecimiento)
    End Function

    Public Sub DeleteEF(estadosFinancierosBE As estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteEF(estadosFinancierosBE)
    End Sub

    Public Function InsertEF(estadosFinancierosBE As estadosFinancieros) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertEF(estadosFinancierosBE)
    End Function

    Public Function GrabarEFApertura(estadosFinancierosBE As estadosFinancieros, docume As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarEFApertura(estadosFinancierosBE, docume)
    End Function

    Public Function InsertEFDoc(ByVal estadosFinancierosBE As estadosFinancieros, docume As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertEFDoc(estadosFinancierosBE, docume)
    End Function

    Public Sub UpdateEF(estadosFinancierosBE As estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateEF(estadosFinancierosBE)
    End Sub

    Public Sub UpdateEFDoc(ByVal estadosFinancierosBE As estadosFinancieros, Optional docume As documento = Nothing)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateEFDoc(estadosFinancierosBE, docume)
    End Sub

    Public Sub DeleteEntidadFinancieraReferencia(ByVal estadosFinancierosBE As estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteEntidadFinancieraReferencia(estadosFinancierosBE)
    End Sub

    Public Function ObtenerEstadosFinancierosPorCodigo(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strCodigo As Integer) As estadosFinancieros
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerEstadosFinancierosPorCodigo(strIdEmpresa, intIdEstablecimiento, strCodigo)
    End Function

    Public Function GetEstadoSaldoEFME(idestado As Integer, fechaCombrobante As DateTime) As estadosFinancieros
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoSaldoEFME(idestado, fechaCombrobante)
    End Function

    Public Function ObtenerEFPorCuentaFinancieraDestino(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, cuentaOrigen As Integer, tipoMo As Integer) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerEFPorCuentaFinancieraDestino(intIdEstablecimiento, strTipo, cuentaOrigen, tipoMo)
    End Function

    Public Function GetEstadoCajasInformacionGeneral(be As documentoCaja, listaPersona As List(Of String), tipo As String, fechaIncio As DateTime, fechaFin As DateTime, intAnio As Integer, intMes As Integer, strEmpresa As String, idEstablec As Integer, intDia As Integer) As List(Of estadosFinancieros)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEstadoCajasInformacionGeneral(be, listaPersona, tipo, fechaIncio, fechaFin, intAnio, intMes, strEmpresa, idEstablec, intDia)
    End Function


End Class

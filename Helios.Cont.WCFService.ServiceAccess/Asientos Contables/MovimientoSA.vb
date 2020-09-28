Imports Helios.Cont.Business.Entity
Public Class MovimientoSA
    ''' <summary>
    ''' Obtener LIsta para cerrar el periodo contable
    ''' </summary>
    ''' <param name="be"> período contable actual</param>
    ''' <param name="periodoAnt">período contable anterior</param>
    ''' <returns></returns>
    Public Function GetCierreContablePeriodo(be As asiento, periodoAnt As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCierreContablePeriodo(be, periodoAnt)
    End Function

    Public Function TxtPleLibroDiarioV2(idempresa As String, anio As String, mes As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TxtPleLibroDiarioV2(idempresa, anio, mes)
    End Function

    Public Function TxtPleLibroDiario(periodo As String, idempresa As String) As List(Of usp_PleLibroDiario_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TxtPleLibroDiario(periodo, idempresa)
    End Function

    Public Function CuentaVentasNetasMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaVentasNetasMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaCostoVentaMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaCostoVentaMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaUtilidadOperativaMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaUtilidadOperativaMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaOtrosIngresoMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaOtrosIngresoMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaVentasNetas2Mensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaVentasNetas2Mensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaOtrosIngreso(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaOtrosIngreso(asientoBE)
    End Function

    Public Function CuentaUtilidadOperativa(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaUtilidadOperativa(asientoBE)
    End Function

    Public Function CuentaCostoVenta(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaCostoVenta(asientoBE)
    End Function

    Public Function CuentaVentasNetas2(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaVentasNetas2(asientoBE)
    End Function

    Public Function CuentaVentasNetas(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaVentasNetas(asientoBE)
    End Function

    Public Sub EditarMovimientosContablesByAsiento(movimiento As movimiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarMovimientosContablesByAsiento(movimiento)
    End Sub

    Public Function CuentaEntregaRendir(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaEntregaRendir(asientoBE)
    End Function

    Public Function CuentaAnticipos(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaAnticipos(asientoBE)
    End Function

    Public Function CuentaCobroComercial(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaCobroComercial(asientoBE)
    End Function

    Public Function CuentaPagoLetras(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaPagoLetras(asientoBE)
    End Function

    Public Function CuentaPagoComercialRel(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaPagoComercialRel(asientoBE)
    End Function


    Public Function CuentaPagoComercial(asientoBE As asiento) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaPagoComercial(asientoBE)
    End Function

    Public Function BalanceGeneralAnual(asientoBE As asiento) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.BalanceGeneralAnual(asientoBE)
        Return miLista
    End Function

    Public Function BuscarCuentasBalance(strPeriodo As Integer) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.BuscarCuentasBalance(strPeriodo)
        Return miLista
    End Function


    Public Function BuscarCuentasFull(strPeriodo As Integer) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.BuscarCuentasFull(strPeriodo)
        Return miLista
    End Function

    Function UbicarMovimientosXidDocumento(intIdAsiento As Integer) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarMovimientosXidDocumento(intIdAsiento)
    End Function

    Public Function UbicarAsientoXidDocumento(intIdDocumento As Integer) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarAsientoXidDocumento(intIdDocumento)
    End Function

    Public Function GetObetnerCierrePorPeriodo(strEmpresa As String, intIdEstablecimiento As Integer, anio As Integer, mes As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObetnerCierrePorPeriodo(strEmpresa, intIdEstablecimiento, anio, mes)
    End Function

    Public Function UbicarMovimientoPorAsiento(intIdAsiento As Integer) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.UbicarMovimientoPorAsiento(intIdAsiento)
        Return miLista
    End Function

    Public Function BuscarMovimientosFull(strPeriodo As Integer) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.BuscarMovimientosFull(strPeriodo)
        Return miLista
    End Function

    Public Function BuscarMovimientosPorMes(strPeriodo As Integer, intMes As Integer) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.BuscarMovimientosPorMes(strPeriodo, intMes)
        Return miLista
    End Function

    Public Function BuscarMovimientosPorAcumulado(strFechaDesde As Date, strFechaHasta As Date) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.BuscarMovimientosPorAcumulado(strFechaDesde, strFechaHasta)
        Return miLista
    End Function

    Public Function GetUbicarDocumentoDetallePorIdDocumento(strCuenta As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarDocumentoDetallePorIdDocumento(strCuenta)
    End Function

    Public Function GetUbicarMovimiento(strCuenta As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarMovimiento(strCuenta)
    End Function

    Public Function BalanceGeneralMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.BalanceGeneralMensual(anioPeriodo, mesPeriodo, idEmpresa)
        Return miLista
    End Function

    Public Function CuentaPagoComercialMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaPagoComercialMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaPagoComercialRelMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaPagoComercialRelMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaPagoLetrasMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaPagoLetrasMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaCobroComercialMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaCobroComercialMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaAnticiposMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaAnticiposMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaEntregaRendirMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaEntregaRendirMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

End Class

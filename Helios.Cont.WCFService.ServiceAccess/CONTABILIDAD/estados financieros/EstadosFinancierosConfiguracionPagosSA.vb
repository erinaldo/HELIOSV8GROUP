Imports Helios.Cont.Business.Entity
Public Class EstadosFinancierosConfiguracionPagosSA

    ''' <summary>
    ''' Configururacion de pagos predeterminada
    ''' </summary>
    ''' <param name="Be"></param>
    ''' <returns></returns>
    Public Function GetConfigurationPay(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConfigurationPay(Be)
    End Function

    Public Function GetPaySaldoCaja(Be As estadosFinancierosConfiguracionPagos) As estadosFinancierosConfiguracionPagos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPaySaldoCaja(Be)
    End Function

    Public Function GetConfigurationPaySaldo(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConfigurationPaySaldo(Be)
    End Function

    Public Function GetConfigurationPaySaldoCajero(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConfigurationPaySaldoCajero(Be)
    End Function

    Public Function ConfiguracionTieneCajasActivas(idConfiguracion As Integer) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConfiguracionTieneCajasActivas(idConfiguracion)
    End Function


    Public Function BuscarConfiguracionCreada(idemp As String, idestab As String, idconf As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarConfiguracionCreada(idemp, idestab, idconf)
    End Function


    Public Sub GrabarConfiguracionList(lista As List(Of estadosFinancierosConfiguracionPagos))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarConfiguracionList(lista)
    End Sub

    Public Function GetConfigurationPayBancarios(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConfigurationPayBancarios(Be)
    End Function
    Public Function GetConfigurationPayCaja(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConfigurationPayCaja(Be)
    End Function


End Class

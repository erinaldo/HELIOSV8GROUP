Imports Helios.Cont.Business.Entity
Public Class cuentaplanContableEmpresaSA

    Public Function CuentasCostoGastoSinModulo(ByVal strIdEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of cuentaplanContableEmpresa)
        miLista = miServicio.CuentasCostoGastoSinModulo(strIdEmpresa)
        Return miLista
    End Function

    Public Function CuentasServicios(strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentasServicios(strEmpresa)
    End Function

    Public Function LoadEstructuraLibroDiario(strEmpresa As String, strPeriodo As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of cuentaplanContableEmpresa)
        miLista = miServicio.LoadEstructuraLibroDiario(strEmpresa, strPeriodo)
        Return miLista
    End Function

    Public Function ObtenerCuentasPorEmpresaConcepto(strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of cuentaplanContableEmpresa)
        miLista = miServicio.LoadCuentasConceptos(strEmpresa)
        Return miLista
    End Function

    Public Function ObtenerMaxCuentabyCuenta(be As cuentaplanContableEmpresa) As cuentaplanContableEmpresa
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMaxCuentabyCuenta(be)
    End Function

    Public Function CuentaExistenteEnBD(cuentaBE As cuentaplanContableEmpresa) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CuentaExistenteEnBD(cuentaBE)
    End Function

    Public Sub InsertarListaDeCuentas(ListaCuentas As List(Of cuentaplanContableEmpresa))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertarListaDeCuentas(ListaCuentas)
    End Sub

    Function LoadCuentasActInmov(strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.LoadCuentasActInmov(strEmpresa)
    End Function

    Public Function ListarCuentasPorPadreDescrip(strEmpresa As String, strCuentaPadre As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarCuentasPorPadreDescrip(strEmpresa, strCuentaPadre)
    End Function

    Public Sub GrabarCuenta(cuenta As cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarCuenta(cuenta)
    End Sub

    Public Sub EditarCuenta(ByVal cuentaBE As cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarCuenta(cuentaBE)
    End Sub

    Public Sub EliminarCuenta(ByVal cuentaBE As cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCuenta(cuentaBE)
    End Sub

    Public Function ListarCuentasPorPadre(strEmpresa As String, strCuentaPadre As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarCuentasPorPadre(strEmpresa, strCuentaPadre)
    End Function

    Public Function LoadCuentasPagoHonorarios(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.LoadCuentasPagoHonorarios(strEmpresa)
    End Function

    Public Function LoadCuentasServicios(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.LoadCuentasServicios(strEmpresa)
    End Function

    Function LoadCuentasGastosPadre(strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.LoadCuentasGastosPadre(strEmpresa)
    End Function

    Public Function LoadCuentasGastos(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.LoadCuentasGastos(strEmpresa)
    End Function

    Public Function ObtenerCuentasConf(strEmpresa As String, strCuenta As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of cuentaplanContableEmpresa)
        miLista = miServicio.ObtenerCuentasConf(strEmpresa, strCuenta)
        Return miLista
    End Function

    Public Function ObtenerCuentaPorID(strEmpresa As String, strCuenta As String) As cuentaplanContableEmpresa
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As cuentaplanContableEmpresa
        miLista = miServicio.ObtenerCuentaPorID(strEmpresa, strCuenta)
        Return miLista
    End Function

    Public Function ObtenerCuentasPorEmpresa(strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of cuentaplanContableEmpresa)
        miLista = miServicio.ObtenerCuentasPorEmpresa(strEmpresa)
        Return miLista
    End Function

    Public Function ObtenerCuentasPorEmpresaEscalable(ByVal strIdEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of cuentaplanContableEmpresa)
        miLista = miServicio.ObtenerCuentasPorEmpresaEscalable(strIdEmpresa)
        Return miLista
    End Function

    Public Function ObtenerCuentasPorEmpresaEscalableV2(ByVal strIdEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of cuentaplanContableEmpresa)
        miLista = miServicio.ObtenerCuentasPorEmpresaEscalableV2(strIdEmpresa)
        Return miLista
    End Function

End Class

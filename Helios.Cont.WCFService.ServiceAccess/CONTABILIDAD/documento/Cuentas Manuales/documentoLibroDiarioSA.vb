Imports Helios.Cont.Business.Entity
Public Class documentoLibroDiarioSA

    Public Sub GrabaritemExistenciaInicioExistente(nuevoarticulo As detalleitems, item As totalesAlmacen, inv As InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabaritemExistenciaInicioExistente(nuevoarticulo, item, inv)
    End Sub

    Public Function ListaDeReconocimientosxEntregable(idEntregable As Integer) As List(Of documentoLibroDiario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaDeReconocimientosxEntregable(idEntregable)
    End Function

    Public Function ListarAsientosManualesSinCosteo(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarAsientosManualesSinCosteo(compraBE)
    End Function

    Public Sub GrabarDocumentoProyecto(documento As documento, idEntregable As Integer, listaR As List(Of recursoCostoDetalle), estadoProy As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDocumentoProyecto(documento, idEntregable, listaR, estadoProy)
    End Sub

    Public Function HistorialCosteo(idEntregable As Integer) As List(Of documentoLibroDiario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.HistorialCosteo(idEntregable)
    End Function

    Public Sub EnvioCostoGastoLibro(i As List(Of documentoLibroDiarioDetalle))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EnvioCostoGastoLibro(i)
    End Sub

    Public Sub GrabarReconocmientoIngreso(documento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarReconocmientoIngreso(documento)
    End Sub

    Public Function ListaDeReconocimientos() As List(Of documentoLibroDiario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaDeReconocimientos()
    End Function

    Public Function ListaRecursosGastoLibroEntregable(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosGastoLibroEntregable(compraBE)
    End Function

    Public Function GetRecuperarAporteExistencia(be As documento) As documentoLibroDiario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRecuperarAporteExistencia(be)
    End Function

    Public Function ListaRecursosCostoLibroEntregable(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosCostoLibroEntregable(compraBE)
    End Function

    Public Function GetListaEstadoCuenta422(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta422(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta)
    End Function

    Public Function GetListaEstadoCuenta422Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta422Mensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta432(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta432(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta)
    End Function

    Public Function GetListaEstadoCuenta432Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta432Mensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoXCuentaActivoInverso(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoXCuentaActivoInverso(strEmpresa, intIdEstablecimiento, cuenta)
    End Function

    Public Function GetUbicar_EstadoXCuentaActivoInversoMensual(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoXCuentaActivoInversoMensual(strEmpresa, intIdEstablecimiento, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function TienenAperturaInventario(be As documentoLibroDiario) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TienenAperturaInventario(be)
    End Function

    Public Function ListaRecursosCostoLibro(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosCostoLibro(compraBE)
    End Function

    Public Sub ActualizarDocumentoLibroDiarioASM(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ActualizarDocumentoLibroDiarioASM(objDocumento)
    End Sub

    Public Sub CambiarPeriodoLibroDiario(be As documentoLibroDiario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarPeriodoLibroDiario(be)
    End Sub

    Public Function GetListaEstadoCuenta11y18(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta11y18(strEmpresa, intIdEstablecimiento, tipoCuenta)
    End Function

    Public Function GetListaEstadoCuenta11y18Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta11y18Mensual(strEmpresa, intIdEstablecimiento, tipoCuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta40(strEmpresa As String, intIdEstablecimiento As Integer, tipo As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta40(strEmpresa, intIdEstablecimiento, tipo)
    End Function

    Public Function GetUbicar_EstadoCuenta40Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipo As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta40Mensual(strEmpresa, intIdEstablecimiento, tipo, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta30al38(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta30al38(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta30al38Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta30al38Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta20al28(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta20al28(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta1413(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta1413(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta1413Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta1413Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function


    Public Function GetUbicar_EstadoCuenta16(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta16(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetListaEstadoCuenta16Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta16Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta16Anual(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta16Anual(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta16Mensual(strEmpresa As String, intIdEstablecimiento As Integer, PeriodoCont As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta16Mensual(strEmpresa, intIdEstablecimiento, PeriodoCont)
    End Function

    Public Function GetUbicar_EstadoCuenta14(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta14(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta14Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta14Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function


    Public Function GetUbicar_EstadoCuenta123133(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta123133(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta123133Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta123133Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoXCuentaActivo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoXCuentaActivo(strEmpresa, intIdEstablecimiento, cuenta)
    End Function

    Public Function GetUbicar_EstadoXCuentaActivoMensual(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoXCuentaActivoMensual(strEmpresa, intIdEstablecimiento, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta122Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta122Mensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta132Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta132Mensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta122(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta122(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta)
    End Function

    Public Function GetUbicar_EstadoXCuentaPasivo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoXCuentaPasivo(strEmpresa, intIdEstablecimiento, cuenta)
    End Function

    Public Sub GrabaritemExistenciaInicio(nuevoarticulo As detalleitems, item As totalesAlmacen, inv As InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabaritemExistenciaInicio(nuevoarticulo, item, inv)
    End Sub

    Public Function GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa, intIdEstablecimiento, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta46Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta46Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta46Anual(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta46Anual(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta13(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta13(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta13Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta13Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta12(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta12(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetListaEstadoCuenta12Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta12Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta43(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta43(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta43Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta43Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta42(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta42(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetListaEstadoCuenta42Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaEstadoCuenta42Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta423433(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta423433(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta423433Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta423433Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta41(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta41(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta41Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta41Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    'Public Function EstadoCobroEntregasarendir() As documentoLibroDiario
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.EstadoCobroEntregasarendir()
    'End Function

    'Public Function EstadoCobroCuenta422432() As documentoLibroDiario
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.EstadoCobroCuenta422432()
    'End Function

    'Public Function EstadoCobroCuenta141617() As documentoLibroDiario
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.EstadoCobroCuenta141617()
    'End Function


    'Public Function EstadoPagoCuenta122132() As documentoLibroDiario
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.EstadoPagoCuenta122132()
    'End Function

    'Public Function EstadoPagoCuenta44454647() As documentoLibroDiario
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.EstadoPagoCuenta44454647()
    'End Function



    'Public Function EstadoCobroCuenta13() As documentoLibroDiario
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.EstadoCobroCuenta13()
    'End Function


    'Public Function EstadoPagoCuenta43() As documentoLibroDiario
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.EstadoPagoCuenta43()
    'End Function

    'Public Function EstadoRemuneracionesPago() As documentoLibroDiario
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.EstadoRemuneracionesPago()
    'End Function

    'Public Function EstadoLetrasCobroPago() As documentoLibroDiario
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.EstadoLetrasCobroPago()
    'End Function

    Public Function UbicarCobrosPorAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCobrosPorAsientoManualMNME(strEmpresa, intIdEstablecimiento, strRuc)
    End Function


    Public Function UbicarCobrosPorAsientoManualRazon(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, moneda As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCobrosPorAsientoManualRazon(strEmpresa, intIdEstablecimiento, strRuc, moneda)
    End Function

    Public Function UbicarPagosPorAsientoManualRazon(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, moneda As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosPorAsientoManualRazon(strEmpresa, intIdEstablecimiento, strRuc, moneda)
    End Function

    Public Function UbicarTodoPagosAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarTodoPagosAsientoManualMNME(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function UbicarPagosPorAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosPorAsientoManualMNME(strEmpresa, intIdEstablecimiento, strRuc)
    End Function

    Public Function UbicarGastosModulo(iddoc As Integer) As documentoLibroDiario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarGastosModulo(iddoc)
    End Function

    Public Function UbicarDocumentoCompraDetalle(intIdDocumento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoModuloDetalle(intIdDocumento)
    End Function

    Public Function SaveSaldo(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGastosXModulo(objDocumento)
    End Function

    Public Function ListarGastosModulo(tipo As String, periodo As String) As List(Of documentoLibroDiario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarGastosModulo(tipo, periodo)
    End Function

    Public Sub ActualizarGastoModulo(objDocumento As documentoLibroDiario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateGastoModulo(objDocumento)
    End Sub

    Public Function UbicarPagoModulosTodoProveedor(strEmpresa As String, intIdEstablecimiento As Integer, idprov As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosModuloTodoProveedor(strEmpresa, intIdEstablecimiento, idprov)
    End Function


    Public Function UbicarPagoModulosTodo(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosModuloTodo(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function UbicarPagoModulos(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, strPeriodo As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosModulo(strEmpresa, intIdEstablecimiento, cuenta, strPeriodo)
    End Function

    Public Function UbicarCobrosModulosTodoProveedor(strEmpresa As String, intIdEstablecimiento As Integer, idprov As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCobrosModuloTodoProveedor(strEmpresa, intIdEstablecimiento, idprov)
    End Function

    Public Function UbicarCobroModulosTodo(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCobrosModuloTodo(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function UbicarCobroModulos(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, strPeriodo As String) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCobrosModulo(strEmpresa, intIdEstablecimiento, cuenta, strPeriodo)
    End Function

    Public Function GetExistenciasInicio(be As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciasInicio(be)
    End Function

    Public Function GetSumaInicioExistencias(be As documentoLibroDiario) As documentoLibroDiario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaInicioExistencias(be)
    End Function

    Public Function GetCuentasAperturaEmpresa(be As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasAperturaEmpresa(be)
    End Function

    Public Function MostrarPagosVariosCP(intIdDocumentoPadre As Integer) As List(Of documentoLibroDiario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.MostrarPagosVariosCP(intIdDocumentoPadre)
    End Function

    Public Function GrabarAjustes(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarAjustes(objDocumento)
    End Function

    Public Sub DeleteLibroDiario(ByVal intIdDocumento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteLibroDiario(intIdDocumento)
    End Sub

    Public Sub ActualizarDocumentoLibroDiario(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ActualizarDocumentoLibroDiario(objDocumento)
    End Sub

    Public Function UbicarDocumentoLibroDiario(intIdDocumento As Integer) As documentoLibroDiario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoLibroDiario(intIdDocumento)
    End Function

    Public Function GrabarLibro(documento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarLibro(documento)
    End Function
    Public Function ListaLibroContable(libroBE As documentoLibroDiario) As List(Of documentoLibroDiario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaLibroContable(libroBE)
    End Function

    Public Function GetUbicar_documentoLibroDiarioDetallePorIDDocumento(idDoc As Integer) As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentoLibroDiarioDetallePorIDDocumento(idDoc)
    End Function
End Class

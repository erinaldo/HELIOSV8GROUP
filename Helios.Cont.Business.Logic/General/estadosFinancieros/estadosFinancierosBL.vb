Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class estadosFinancierosBL
    Inherits BaseBL

    Public Function GetCuentasFinancierasEmpresaXtipoFecha(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipoFecha_Result)
        Dim fecha = be.fechaBalance
        Dim fechaAnterior = CDate(be.fechaBalance).AddMonths(-1)
        Dim periodoActual = GetPeriodo(fecha, True)
        Dim periodoAnterior = GetPeriodo(fechaAnterior, False)

        Return HeliosData.GetSaldoCuentasFinancieraEmpresaXtipoFecha(be.idEmpresa, be.idEstablecimiento, periodoAnterior, fecha, be.tipo).ToList

    End Function

    Public Function GetCuentasFinancierasEmpresaXtipo(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipo_Result)
        Dim fecha = be.fechaBalance
        Dim fechaAnterior = CDate(be.fechaBalance).AddMonths(-1)
        Dim periodoActual = GetPeriodo(fecha, True)
        Dim periodoAnterior = GetPeriodo(fechaAnterior, False)

        Return HeliosData.GetSaldoCuentasFinancieraEmpresaXtipo(be.idEmpresa, periodoAnterior, periodoActual, be.tipo).ToList

    End Function

    Public Function GetSaldoCuentasFinancieraCajeroActivo(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraCajeroActivo_Result)
        Dim fecha = be.fechaBalance
        Dim fechaAnterior = CDate(be.fechaBalance).AddMonths(-1)
        Dim periodoActual = GetPeriodo(fecha, True)
        Dim periodoAnterior = GetPeriodo(fechaAnterior, False)

        Return HeliosData.GetSaldoCuentasFinancieraCajeroActivo(be.idEmpresa, be.idEstablecimiento, periodoAnterior, fecha, be.tipo, be.IdCaja).ToList

    End Function

    Public Function GetCuentasFinancierasEmpresaXtipoXidCaja(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipoXIdCaja_Result)
        Dim fecha = be.fechaBalance
        Dim fechaAnterior = CDate(be.fechaBalance).AddMonths(-1)
        Dim periodoActual = GetPeriodo(fecha, True)
        Dim periodoAnterior = GetPeriodo(fechaAnterior, False)

        Return HeliosData.GetSaldoCuentasFinancieraEmpresaXtipoXIdCaja(be.idEmpresa, periodoAnterior, periodoActual, be.tipo, be.idCaja).ToList

    End Function

    Public Function GetEstadoSaldoXEFME(idestado As Integer) As estadosFinancieros
        Dim Entrdadas = (Aggregate n In HeliosData.documentoCaja Join
                         d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
                       Where n.entidadFinanciera = idestado And n.tipoMovimiento = "DC"
                       Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

        Dim Salidas = (Aggregate n In HeliosData.documentoCaja Join
                         d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
                       Where n.entidadFinanciera = idestado And n.tipoMovimiento = "PG"
                       Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

        Dim SalidaCajaAsignado = (Aggregate n In HeliosData.cajaUsuario
                                 Where n.idCajaOrigen = idestado And n.estadoCaja = "A"
                      Into sumMN = Sum(n.fondoMN), sumME = Sum(n.fondoME))


        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        'totalMN = CDec((Entrdadas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault) - SalidaCajaAsignado.sumMN.GetValueOrDefault)
        'totalME = CDec((Entrdadas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault) - SalidaCajaAsignado.sumME.GetValueOrDefault)
        totalMN = CDec((Entrdadas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault))
        totalME = CDec((Entrdadas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault))
        Dim finanzas As New estadosFinancieros With {.importeBalanceMN = totalMN,
                                                     .importeBalanceME = totalME}

        Return finanzas
    End Function


    Public Function GetSumaCuentasByTipo(be As estadosFinancieros) As List(Of estadosFinancieros)
        Dim obj As New estadosFinancieros
        Dim Lista As New List(Of estadosFinancieros)

        Dim consulta = (From EstadosFinancieros In HeliosData.estadosFinancieros _
                       Where EstadosFinancieros.importeBalanceMN > CDec(0) _
                       And EstadosFinancieros.idEmpresa = be.idEmpresa _
                       Group EstadosFinancieros By _
                       EstadosFinancieros.tipo, _
                       EstadosFinancieros.codigo _
                       Into g = Group _
                       Select _
                       tipo, _
                       moneda = codigo, _
                       totalMN = CType(g.Sum(Function(p) p.importeBalanceMN), Decimal?), _
                       totalME = CType(g.Sum(Function(p) p.importeBalanceME), Decimal?)).ToList


        For Each i In consulta
            obj = New estadosFinancieros
            obj.tipo = i.tipo
            obj.codigo = i.moneda
            obj.importeBalanceMN = i.totalMN
            obj.importeBalanceME = i.totalME
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function ListadoEstadosFinanConteo(strIdEmpresa As String, intEstablec As Integer) As Integer

        Dim consulta = (From s In HeliosData.estadosFinancieros _
                       Where s.idEmpresa = strIdEmpresa _
                       And s.idEstablecimiento = intEstablec _
                       Select s).Count

        Return consulta
    End Function

    Public Function GetCuentasByTipoDeAporteInicio(be As estadosFinancieros) As List(Of estadosFinancieros)
        Dim obj As New estadosFinancieros
        Dim Lista As New List(Of estadosFinancieros)

        Dim consulta = (From EstadosFinancieros In HeliosData.estadosFinancieros _
                       Where EstadosFinancieros.importeBalanceMN > CDec(0) _
                       And EstadosFinancieros.idEmpresa = be.idEmpresa).ToList


        For Each i In consulta
            obj = New estadosFinancieros
            obj.idestado = i.idestado
            obj.idEstablecimiento = i.idEstablecimiento
            obj.idBanco = i.idBanco
            obj.cuenta = i.cuenta
            obj.codigo = i.codigo
            obj.tipo = i.tipo
            obj.descripcion = i.descripcion
            obj.nroCtaCorriente = i.nroCtaCorriente
            obj.tipocambio = i.tipocambio
            obj.fechaBalance = i.fechaBalance
            obj.importeBalanceMN = i.importeBalanceMN
            obj.importeBalanceME = i.importeBalanceME
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetEstadoSaldoEF(EF As estadosFinancieros) As estadosFinancieros
        'Try
        Dim Entrdadas = (Aggregate n In HeliosData.documentoCaja _
                       Where n.entidadFinanciera = EF.idestado And n.tipoMovimiento = "DC" _
                       Into sumMN = Sum(n.montoSoles), sumME = Sum(n.montoUsd))

        Dim Salidas = (Aggregate n In HeliosData.documentoCaja _
                       Where n.entidadFinanciera = EF.idestado And n.tipoMovimiento = "PG" _
                       Into sumMN = Sum(n.montoSoles), sumME = Sum(n.montoUsd))


        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        totalMN = Entrdadas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault
        totalME = Entrdadas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault

        Dim finanzas As New estadosFinancieros With {.importeBalanceMN = totalMN,
                                                     .importeBalanceME = totalME}

        Return finanzas
        'Catch ex As Exception

        'End Try
    End Function

    Public Function Insert(ByVal estadosFinancierosBE As estadosFinancieros) As Integer
        Using ts As New TransactionScope
            HeliosData.estadosFinancieros.Add(estadosFinancierosBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return estadosFinancierosBE.idestado
        End Using
    End Function

    Public Function InsertEFDoc(ByVal estadosFinancierosBE As estadosFinancieros, docume As documento) As Integer
        Dim docCajaBL As New documentoCajaBL
        Using ts As New TransactionScope
            'Dim cox = Insert(estadosFinancierosBE)

            Dim consulta = 0

            If estadosFinancierosBE.tipo = "BH" Then

                consulta = (From i In HeliosData.estadosFinancieros
                            Where i.tipo = estadosFinancierosBE.tipo And
                                  i.nroCtaCorriente = estadosFinancierosBE.nroCtaCorriente And
                                    i.idEstablecimiento = estadosFinancierosBE.idEstablecimiento).Count

            ElseIf estadosFinancierosBE.tipo = "EF" Then
                consulta = (From i In HeliosData.estadosFinancieros
                            Where i.tipo = estadosFinancierosBE.tipo And
                                  i.descripcion = estadosFinancierosBE.descripcion And
                                  i.idEstablecimiento = estadosFinancierosBE.idEstablecimiento).Count
            End If

            If consulta = 0 Then

                Dim cox = Insert(estadosFinancierosBE)
            ElseIf consulta > 0 Then

                Throw New Exception("La entidad Financiera ya existe!")
            End If


            'docume.documentoCaja.entidadFinanciera = cox
            'docume.asiento(0).idEntidad = cox
            'Dim idDoc = docCajaBL.SaveGroupCajaOtrosMovimientosSingle(docume)

            'Dim EF As estadosFinancieros = HeliosData.estadosFinancieros.Where(Function(o) o.idestado = cox).FirstOrDefault
            'EF.usuarioActualizacion = idDoc


            HeliosData.SaveChanges()
            ts.Complete()
            Return estadosFinancierosBE.idestado
        End Using
    End Function


    Public Function GrabarEFApertura(ByVal estadosFinancierosBE As estadosFinancieros, docume As documento) As Integer
        Dim docCajaBL As New documentoCajaBL
        Using ts As New TransactionScope

            Dim cox = Insert(estadosFinancierosBE)

            docume.documentoCaja.entidadFinanciera = cox
            '   docume.asiento(0).idEntidad = cox
            Dim idDoc = docCajaBL.GrabarEFApertura(docume)

            'Dim EF As estadosFinancieros = HeliosData.estadosFinancieros.Where(Function(o) o.idestado = cox).FirstOrDefault
            'EF.usuarioActualizacion = idDoc

            HeliosData.SaveChanges()
            ts.Complete()
            Return estadosFinancierosBE.idestado
        End Using
    End Function

    Public Sub Update(ByVal estadosFinancierosBE As estadosFinancieros)
        Using ts As New TransactionScope
            Dim estadosFinancieros As estadosFinancieros = HeliosData.estadosFinancieros.Where(Function(o) _
                                            o.idestado = estadosFinancierosBE.idestado _
                                            And o.idEmpresa = estadosFinancierosBE.idEmpresa _
                                            And o.idEstablecimiento = estadosFinancierosBE.idEstablecimiento).First()

            estadosFinancieros.cuenta = estadosFinancierosBE.cuenta
            estadosFinancieros.codigo = estadosFinancierosBE.codigo
            estadosFinancieros.tipo = estadosFinancierosBE.tipo
            estadosFinancieros.descripcion = estadosFinancierosBE.descripcion
            estadosFinancieros.nroCtaCorriente = estadosFinancierosBE.nroCtaCorriente
            estadosFinancieros.predeterminado = estadosFinancierosBE.predeterminado
            estadosFinancieros.usuarioActualizacion = estadosFinancierosBE.usuarioActualizacion
            estadosFinancieros.fechaActualizacion = estadosFinancierosBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(estadosFinancieros).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Update2(ByVal estadosFinancierosBE As estadosFinancieros)
        Using ts As New TransactionScope
            Dim estadosFinancieros As estadosFinancieros = HeliosData.estadosFinancieros.Where(Function(o) _
                                            o.idestado = estadosFinancierosBE.idestado _
                                            And o.idEmpresa = estadosFinancierosBE.idEmpresa _
                                            And o.idEstablecimiento = estadosFinancierosBE.idEstablecimiento).First()

            estadosFinancieros.cuenta = estadosFinancierosBE.cuenta
            estadosFinancieros.codigo = estadosFinancierosBE.codigo
            estadosFinancieros.tipo = estadosFinancierosBE.tipo
            estadosFinancieros.descripcion = estadosFinancierosBE.descripcion
            estadosFinancieros.nroCtaCorriente = estadosFinancierosBE.nroCtaCorriente
            estadosFinancieros.predeterminado = estadosFinancierosBE.predeterminado
            estadosFinancieros.fechaBalance = estadosFinancierosBE.fechaBalance
            estadosFinancieros.importeBalanceMN = estadosFinancierosBE.importeBalanceMN
            estadosFinancieros.importeBalanceME = estadosFinancierosBE.importeBalanceME
            'estadosFinancieros.usuarioActualizacion = estadosFinancierosBE.usuarioActualizacion
            'estadosFinancieros.fechaActualizacion = estadosFinancierosBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(estadosFinancieros).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub DeleteEntidadFinancieraReferencia(ByVal estadosFinancierosBE As estadosFinancieros)


        Dim documentoCaja As New documentoCajaDetalleBL
        Dim total As Integer = 0

        Using ts As New TransactionScope
            Try


                Dim cajaUsuario As Integer = HeliosData.cajaUsuario.Where(Function(o) o.idCajaOrigen = estadosFinancierosBE.idestado).Count
                Dim objDocoCaja As Integer = HeliosData.documentoCaja.Where(Function(o) o.entidadFinanciera = estadosFinancierosBE.idestado).Count

                total = cajaUsuario + objDocoCaja

                If (total = 0) Then

                    Dim estadosFinancieros As estadosFinancieros = HeliosData.estadosFinancieros.Where(Function(o) _
                                                o.idestado = estadosFinancierosBE.idestado).First()

                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(estadosFinancieros)
                    HeliosData.SaveChanges()
                Else
                    Throw New Exception("La Entidad no puede ser eliminada!")
                End If

                HeliosData.SaveChanges()
                ts.Complete()

            Catch ex As Exception
                Throw ex
            End Try
        End Using

    End Sub


    Public Sub UpdateEFDoc(ByVal estadosFinancierosBE As estadosFinancieros, Optional docume As documento = Nothing)
        Dim docCajaBL As New documentoCajaBL
        Dim documeBL As New documentoBL
        Using ts As New TransactionScope
            Update2(estadosFinancierosBE)
            If Not IsNothing(docume) Then
                documeBL.DeleteSingleVariable(CInt(docume.idDocumento))
                docume.documentoCaja.entidadFinanciera = estadosFinancierosBE.idestado
                docume.asiento(0).idEntidad = estadosFinancierosBE.idestado
                Dim idDoc = docCajaBL.SaveGroupCajaOtrosMovimientosSingle(docume)

                Dim EF As estadosFinancieros = HeliosData.estadosFinancieros.Where(Function(o) o.idestado = estadosFinancierosBE.idestado).FirstOrDefault
                EF.usuarioActualizacion = idDoc

            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal estadosFinancierosBE As estadosFinancieros)
        Dim estadosFinancieros As estadosFinancieros = HeliosData.estadosFinancieros.Where(Function(o) _
                                           o.idestado = estadosFinancierosBE.idestado).First()

        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(estadosFinancieros)
        HeliosData.SaveChanges()
    End Sub

    Public Function GetListar_estadosFinancieros() As List(Of estadosFinancieros)
        Return (From a In HeliosData.estadosFinancieros Select a).ToList
    End Function

    Public Function GetUbicar_estadosFinancierosPorID(idestado As Integer) As estadosFinancieros
        Return (From a In HeliosData.estadosFinancieros
                 Where a.idestado = idestado Select a).First
    End Function

    Public Function ObtenerEstadosFinancierosPorMoneda(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, ByVal strMoneda As String) As List(Of estadosFinancieros)

        Return (From n In HeliosData.estadosFinancieros
                Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                           And n.tipo = strTipo And n.codigo = strMoneda
                Select n).ToList

    End Function


    'AGRE MARTIN

    Public Function ObtenerEstadosFinancierosTipo(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, strBusqueda As String) As List(Of estadosFinancieros)

        Dim estadoF As New estadosFinancieros
        Dim lista As New List(Of estadosFinancieros)

        Dim con = (From n In HeliosData.estadosFinancieros
                   Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                           And n.descripcion.Contains(strBusqueda) _
                           And n.tipo = strTipo
                   Select n).ToList

        For Each i In con
            estadoF = New estadosFinancieros
            estadoF.idestado = i.idestado
            estadoF.idEmpresa = i.idEmpresa
            estadoF.idEstablecimiento = i.idEstablecimiento
            estadoF.cuenta = i.cuenta
            estadoF.codigo = i.codigo
            estadoF.tipo = i.tipo
            estadoF.descripcion = i.descripcion & "-" & IIf(i.codigo = "1", "NAC", "EX") & " " & i.nroCtaCorriente
            estadoF.nroCtaCorriente = i.nroCtaCorriente
            estadoF.predeterminado = i.predeterminado
            estadoF.usuarioActualizacion = i.usuarioActualizacion
            estadoF.fechaActualizacion = i.fechaActualizacion
            lista.Add(estadoF)
        Next
        Return lista
    End Function

    'END AGRE

    Public Function ObtenerEstadosFinancierosPorMonedaXdescripcion(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, strBusqueda As String) As List(Of estadosFinancieros)

        Dim estadoF As New estadosFinancieros
        Dim lista As New List(Of estadosFinancieros)

        Dim con = (From n In HeliosData.estadosFinancieros
                   Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                           And n.descripcion.Contains(strBusqueda)
                   Select n).ToList

        For Each i In con
            estadoF = New estadosFinancieros
            estadoF.idestado = i.idestado
            estadoF.idEmpresa = i.idEmpresa
            estadoF.idEstablecimiento = i.idEstablecimiento
            estadoF.cuenta = i.cuenta
            estadoF.codigo = i.codigo
            estadoF.tipo = i.tipo
            estadoF.descripcion = i.descripcion & "-" & IIf(i.codigo = "1", "NAC", "EX") & " " & i.nroCtaCorriente
            estadoF.nroCtaCorriente = i.nroCtaCorriente
            estadoF.predeterminado = i.predeterminado
            estadoF.usuarioActualizacion = i.usuarioActualizacion
            estadoF.fechaActualizacion = i.fechaActualizacion
            lista.Add(estadoF)
        Next
        Return lista
    End Function

    Public Function ObtenerEstadosFinancierosPorTipo(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String) As List(Of estadosFinancieros)
        Dim obj As New estadosFinancieros
        Dim Lista As New List(Of estadosFinancieros)
        Dim consulta = (From n In HeliosData.estadosFinancieros
                        Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                           And n.codigo = strTipo
                        Select n).ToList

        For Each i In consulta
            obj = New estadosFinancieros
            obj.idestado = i.idestado
            obj.descripcion = i.descripcion
            obj.tipo = IIf(i.tipo = "BC", "BANCO", "EFECTIVO")
            obj.codigo = IIf(i.codigo = 1, "NACIONAL", "EXTRANJERA")
            obj.cuenta = i.cuenta
            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function ObtenerEFPorCuentaFinanciera(estadosFinancierosBE As estadosFinancieros) As List(Of estadosFinancieros)
        Try
            Dim obj As New estadosFinancieros
            Dim Lista As New List(Of estadosFinancieros)

            Select Case estadosFinancierosBE.tipoConsulta

                Case "EMPRESA"
                    Dim consulta = (From n In HeliosData.estadosFinancieros
                                    Where n.idEmpresa = estadosFinancierosBE.idEmpresa And
                                         n.tipo = estadosFinancierosBE.tipo
                                    Select n).ToList

                    For Each i In consulta
                        obj = New estadosFinancieros
                        obj.idestado = i.idestado
                        obj.descripcion = i.descripcion
                        obj.tipo = IIf(i.tipo = "BC", "BANCO", "EFECTIVO")
                        obj.codigo = IIf(i.codigo = 1, "NACIONAL", "EXTRANJERA")
                        obj.cuenta = i.cuenta
                        Lista.Add(obj)
                    Next

                Case "UNIDAD_ORGANICA"

                    Dim consulta = (From n In HeliosData.estadosFinancieros
                                    Where n.idEmpresa = estadosFinancierosBE.idEmpresa And
                                    n.idEstablecimiento = estadosFinancierosBE.idEstablecimiento And
                                   n.tipo = estadosFinancierosBE.tipo
                                    Select n).ToList

                    For Each i In consulta
                        obj = New estadosFinancieros
                        obj.idestado = i.idestado
                        obj.descripcion = i.descripcion
                        obj.tipo = IIf(i.tipo = "BC", "BANCO", "EFECTIVO")
                        obj.codigo = IIf(i.codigo = 1, "NACIONAL", "EXTRANJERA")
                        obj.cuenta = i.cuenta
                        Lista.Add(obj)
                    Next

            End Select

            Return Lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetCuentasFinancierasByEmpresa(ByVal idEmpresa As String, ByVal strTipo As String) As List(Of estadosFinancieros)
        Dim obj As New estadosFinancieros
        Dim Lista As New List(Of estadosFinancieros)
        Dim consulta = (From n In HeliosData.estadosFinancieros _
                           Where n.idEmpresa = idEmpresa _
                           And n.tipo = strTipo _
                           Select n).ToList

        For Each i In consulta
            obj = New estadosFinancieros
            obj.idestado = i.idestado
            obj.descripcion = i.descripcion
            obj.tipo = IIf(i.tipo = "BC", "BANCO", "EFECTIVO")
            obj.codigo = IIf(i.codigo = 1, "NACIONAL", "EXTRANJERA")
            obj.cuenta = i.cuenta
            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function ObtenerEstadosFinancierosPorEstablecimiento(estadoFinancieroBE As estadosFinancieros) As List(Of estadosFinancieros)

        Try
            Select Case estadoFinancieroBE.tipoConsulta
                Case "EMPRESA"
                    Return (From n In HeliosData.estadosFinancieros
                            Where n.idEmpresa = estadoFinancieroBE.idEmpresa
                            Select n).ToList

                Case "UNIDAD_ORGANICA"
                    Return (From n In HeliosData.estadosFinancieros
                            Where n.idEmpresa = estadoFinancieroBE.idEmpresa And
                                    n.idEstablecimiento = estadoFinancieroBE.idEstablecimiento
                            Select n).ToList

            End Select
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerEstadosFinancierosPredeterminado(ByVal intIdEstablecimiento As Integer) As estadosFinancieros

        Return (From n In HeliosData.estadosFinancieros
                Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                           And n.predeterminado = "S").First

    End Function

    Public Function ObtenerEstadosFinancierosPorCodigo(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strCodigo As Integer) As estadosFinancieros

        Return (From n In HeliosData.estadosFinancieros
                Where n.idEmpresa = strIdEmpresa _
                           And n.idestado = strCodigo).FirstOrDefault
    End Function

    'Public Function GetEstadoSaldoEFME(idestado As Integer) As estadosFinancieros
    '    Dim lista As New List(Of String)
    '    lista.Add("2")
    '    lista.Add("0")

    '    'Try
    '    Dim Entrdadas = (Aggregate n In HeliosData.documentoCaja Join
    '                     d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
    '                   Where n.entidadFinanciera = idestado And n.tipoMovimiento = "DC" And
    '                   lista.Contains(d.estadoCaja) _
    '                   Into sumMN = Sum(d.montoSolesRef), sumME = Sum(d.montoUsdRef))

    '    Dim Salidas = (Aggregate n In HeliosData.documentoCaja Join
    '                     d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
    '                   Where n.entidadFinanciera = idestado And n.tipoMovimiento = "PG" And
    '                   lista.Contains(d.estadoCaja) _
    '                   Into sumMN = Sum(d.montoSolesRef), sumME = Sum(d.montoUsdRef))


    '    Dim totalMN As Decimal = 0
    '    Dim totalME As Decimal = 0
    '    totalMN = Entrdadas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault
    '    totalME = Entrdadas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault

    '    Dim finanzas As New estadosFinancieros With {.importeBalanceMN = totalMN,
    '                                                 .importeBalanceME = totalME}

    '    Return finanzas
    '    'Catch ex As Exception

    '    'End Try
    'End Function

    Public Function GetEstadoSaldoEFME(idestado As Integer, fechaProceso As DateTime) As estadosFinancieros
        Dim periodoActual = String.Format("{0:00}", fechaProceso.Month) & "/" & fechaProceso.Year
        Dim periodoA = fechaProceso.AddMonths(-1)
        Dim periodoAnt = String.Format("{0:00}", periodoA.Month) & periodoA.Year

        Dim con = HeliosData.GetSaldobyCuentaFinanciera(idestado, periodoAnt, periodoActual).FirstOrDefault

        'Dim con = (From c In HeliosData.documentoCaja
        '           Where
        '         c.entidadFinanciera = idestado _
        '         And c.tipoOperacion <> StatusTipoOperacion.CIERRES
        '           Group New With {c} By
        '         c.tipoMovimiento
        '         Into g = Group
        '           Order By
        '         tipoMovimiento
        '           Select
        '         tipoMovimiento,
        '         totalMN = CType(g.Sum(Function(p) p.c.montoSoles), Decimal?),
        '         totalME = CType(g.Sum(Function(p) p.c.montoUsd), Decimal?)).FirstOrDefault
        'Dim Entrdadas = (Aggregate n In HeliosData.documentoCaja Join
        '                    d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
        '                  Where n.entidadFinanciera = idestado And n.tipoMovimiento = "DC" _
        '                  And d.fecha <= fechaProceso _
        '                  Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

        'Dim Salidas = (Aggregate n In HeliosData.documentoCaja Join
        '                 d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
        '               Where n.entidadFinanciera = idestado And n.tipoMovimiento = "PG" _
        '                And d.fecha <= fechaProceso _
        '               Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

        'Dim SalidaCajaAsignado = (Aggregate n In HeliosData.cajaUsuario
        '                         Where n.idCajaOrigen = idestado And n.estadoCaja = "A" _
        '                            And n.fechaRegistro <= fechaProceso _
        '              Into sumMN = Sum(n.fondoMN), sumME = Sum(n.fondoME))


        'Dim totalEntredasDeDineroMN As Decimal = 0
        'Dim totalSalidasDeDineroMN As Decimal = 0
        'Dim totalEntredasDeDineroME As Decimal = 0
        'Dim totalSalidasDeDineroME As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim saldoME As Decimal = 0

        If Not IsNothing(con) Then
            'Select Case con.tipoMovimiento
            '    Case "DC"
            '        totalEntredasDeDineroMN = con.totalMN.GetValueOrDefault
            '        totalEntredasDeDineroME = con.totalME.GetValueOrDefault
            '    Case "PG"
            '        totalSalidasDeDineroMN = con.totalMN.GetValueOrDefault
            '        totalSalidasDeDineroME = con.totalME.GetValueOrDefault
            'End Select

            saldoMN = (con.SaldoAnterior.GetValueOrDefault + con.Cobros.GetValueOrDefault) - con.Pagos.GetValueOrDefault
            saldoME = 0 'totalEntredasDeDineroME - totalSalidasDeDineroME

        End If
        'saldoMN = totalEntredasDeDineroMN - totalSalidasDeDineroMN
        'saldoME = totalEntredasDeDineroME - totalSalidasDeDineroME

        Dim finanzas As New estadosFinancieros With {.importeBalanceMN = saldoMN,
                                                     .importeBalanceME = saldoME}

        Return finanzas
    End Function


    Public Function GetEstadoCajasTodos() As estadosFinancieros
        Dim Entrdadas = (Aggregate n In HeliosData.documentoCaja Join
                            d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
                          Where n.tipoMovimiento = "DC" And n.idEmpresa = Gempresas.IdEmpresaRuc _
                          Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

        Dim Salidas = (Aggregate n In HeliosData.documentoCaja Join
                         d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
                       Where n.tipoMovimiento = "PG" And n.idEmpresa = Gempresas.IdEmpresaRuc _
                       Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))



        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        'totalMN = CDec((Entrdadas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault) - SalidaCajaAsignado.sumMN.GetValueOrDefault)
        'totalME = CDec((Entrdadas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault) - SalidaCajaAsignado.sumME.GetValueOrDefault)
        totalMN = CDec((Entrdadas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault))
        totalME = CDec((Entrdadas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault))
        Dim finanzas As New estadosFinancieros With {.importeBalanceMN = totalMN,
                                                     .importeBalanceME = totalME}

        Return finanzas
    End Function

    Public Function GetEstadoCajasTodosByDia(be As documentoCaja) As estadosFinancieros
        Dim Entrdadas = (Aggregate n In HeliosData.documentoCaja Join
                            d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento
                          Where n.tipoMovimiento = "DC" And n.idEmpresa = Gempresas.IdEmpresaRuc _
                          And n.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
                          And n.fechaProceso.Value.Month = be.fechaProceso.Value.Month _
                          And n.fechaProceso.Value.Day = be.fechaProceso.Value.Day
                          Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

        Dim Salidas = (Aggregate n In HeliosData.documentoCaja Join
                         d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento
                       Where n.tipoMovimiento = "PG" And n.idEmpresa = Gempresas.IdEmpresaRuc _
                       And n.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
                          And n.fechaProceso.Value.Month = be.fechaProceso.Value.Month _
                          And n.fechaProceso.Value.Day = be.fechaProceso.Value.Day
                       Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))



        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        'totalMN = CDec((Entrdadas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault) - SalidaCajaAsignado.sumMN.GetValueOrDefault)
        'totalME = CDec((Entrdadas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault) - SalidaCajaAsignado.sumME.GetValueOrDefault)
        totalMN = CDec((Entrdadas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault))
        totalME = CDec((Entrdadas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault))
        Dim finanzas As New estadosFinancieros With {.importeBalanceMN = totalMN,
                                                     .importeBalanceME = totalME}

        Return finanzas
    End Function

    Public Function GetEstadoCajasTodosByDiaAllEmpresa(be As documentoCaja) As estadosFinancieros
        Dim Entrdadas = (Aggregate n In HeliosData.documentoCaja Join
                            d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
                          Where n.tipoMovimiento = "DC" _
                          And n.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
                          And n.fechaProceso.Value.Month = be.fechaProceso.Value.Month _
                          And n.fechaProceso.Value.Day = be.fechaProceso.Value.Day _
                          Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))

        Dim Salidas = (Aggregate n In HeliosData.documentoCaja Join
                         d In HeliosData.documentoCajaDetalle On n.idDocumento Equals d.idDocumento _
                         Where n.tipoMovimiento = "PG" _
                         And n.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
                         And n.fechaProceso.Value.Month = be.fechaProceso.Value.Month _
                         And n.fechaProceso.Value.Day = be.fechaProceso.Value.Day _
                         Into sumMN = Sum(d.montoSoles), sumME = Sum(d.montoUsd))



        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        'totalMN = CDec((Entrdadas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault) - SalidaCajaAsignado.sumMN.GetValueOrDefault)
        'totalME = CDec((Entrdadas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault) - SalidaCajaAsignado.sumME.GetValueOrDefault)
        totalMN = CDec((Entrdadas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault))
        totalME = CDec((Entrdadas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault))
        Dim finanzas As New estadosFinancieros With {.importeBalanceMN = totalMN,
                                                     .importeBalanceME = totalME}

        Return finanzas
    End Function

    Public Function GetEstadoCajasTodosDetalle() As List(Of estadosFinancieros)
        Dim obj As New estadosFinancieros
        Dim Lista As New List(Of estadosFinancieros)
        Try
            Dim con = From ef In HeliosData.estadosFinancieros _
                      Where _
                      ef.idEmpresa = Gempresas.IdEmpresaRuc _
                      Order By _
                      ef.tipo _
                      Select _
                      ef.descripcion, _
                      ef.codigo, _
                      ef.tipo, _
                      Ingreso = (CType((Aggregate t1 In _
                                        (From c In HeliosData.documentoCaja _
                                         Where _
                                         c.entidadFinanciera = CStr(ef.idestado) And _
                                         c.tipoMovimiento = "DC" _
                                         Select New With { _
                                             c.montoSoles _
                                         }) Into Sum(t1.montoSoles)), Decimal?)), _
                     Salida = (CType((Aggregate t1 In _
                                      (From c In HeliosData.documentoCaja _
                                       Where _
                                       c.entidadFinanciera = CStr(ef.idestado) And _
                                       c.tipoMovimiento = "PG" _
                                       Select New With { _
                                           c.montoSoles _
                                       }) Into Sum(t1.montoSoles)), Decimal?))


            For Each i In con
                obj = New estadosFinancieros
                obj.descripcion = i.descripcion
                obj.codigo = i.codigo
                obj.tipo = i.tipo
                obj.Ingresos = i.Ingreso.GetValueOrDefault
                obj.Salidas = i.Salida.GetValueOrDefault
                Lista.Add(obj)
            Next

        Catch ex As Exception
            Throw ex
        End Try
        

        Return Lista
    End Function

    Public Function GetEstadoCajasTodosDetalleByDia(be As documentoCaja) As List(Of estadosFinancieros)
        Dim obj As New estadosFinancieros
        Dim Lista As New List(Of estadosFinancieros)
        Try
            Dim con = From ef In HeliosData.estadosFinancieros
                      Where
                      ef.idEmpresa = Gempresas.IdEmpresaRuc
                      Order By
                      ef.tipo
                      Select
                      ef.descripcion,
                      ef.codigo,
                      ef.tipo,
                      Ingreso = (CType((Aggregate t1 In
                                        (From c In HeliosData.documentoCaja
                                         Where
                                         c.entidadFinanciera = CStr(ef.idestado) And
                                         c.tipoMovimiento = "DC" _
                                         And c.tipoOperacion <> StatusTipoOperacion.CIERRES _
                                         And c.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
                                         And c.fechaProceso.Value.Month = be.fechaProceso.Value.Month _
                                         And c.fechaProceso.Value.Day = be.fechaProceso.Value.Day
                                         Select New With {
                                             c.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                     Salida = (CType((Aggregate t1 In
                                      (From c In HeliosData.documentoCaja
                                       Where
                                           c.entidadFinanciera = CStr(ef.idestado) And
                                           c.tipoMovimiento = "PG" _
                                           And c.tipoOperacion <> StatusTipoOperacion.CIERRES _
                                           And c.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
                                           And c.fechaProceso.Value.Month = be.fechaProceso.Value.Month _
                                           And c.fechaProceso.Value.Day = be.fechaProceso.Value.Day
                                       Select New With {
                                           c.montoSoles
                                       }) Into Sum(t1.montoSoles)), Decimal?))


            For Each i In con
                obj = New estadosFinancieros
                obj.descripcion = i.descripcion
                obj.codigo = i.codigo
                obj.tipo = i.tipo
                obj.Ingresos = i.Ingreso.GetValueOrDefault
                obj.Salidas = i.Salida.GetValueOrDefault
                Lista.Add(obj)
            Next

        Catch ex As Exception
            Throw ex
        End Try


        Return Lista
    End Function

    Public Function GetEstadoCajasTodosDetalleByMensual(be As documentoCaja, periodoAnt As String) As List(Of estadosFinancieros)
        Dim obj As New estadosFinancieros
        Dim Lista As New List(Of estadosFinancieros)
        Try
            'Dim con = From ef In HeliosData.estadosFinancieros
            '          Where
            '          ef.idEmpresa = be.idEmpresa
            '          Order By
            '          ef.tipo
            '          Select
            '          ef.idEstablecimiento,
            '          ef.idestado,
            '          ef.descripcion,
            '          ef.codigo,
            '          ef.tipo,
            '          Ingreso = (CType((Aggregate t1 In
            '                            (From c In HeliosData.documentoCaja
            '                             Where
            '                                 c.idEmpresa = be.idEmpresa And
            '                                 c.entidadFinanciera = CStr(ef.idestado) And
            '                                 c.tipoMovimiento = "DC" _
            '                                 And c.tipoOperacion <> StatusTipoOperacion.CIERRES _
            '                                 And c.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
            '                                 And c.fechaProceso.Value.Month = be.fechaProceso.Value.Month
            '                             Select New With {
            '                                 c.montoSoles
            '                             }) Into Sum(t1.montoSoles)), Decimal?)),
            '         Salida = (CType((Aggregate t1 In
            '                          (From c In HeliosData.documentoCaja
            '                           Where
            '                               c.idEmpresa = be.idEmpresa And
            '                               c.entidadFinanciera = CStr(ef.idestado) And
            '                               c.tipoMovimiento = "PG" _
            '                               And c.tipoOperacion <> StatusTipoOperacion.CIERRES _
            '                               And c.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
            '                               And c.fechaProceso.Value.Month = be.fechaProceso.Value.Month
            '                           Select New With {
            '                               c.montoSoles
            '                           }) Into Sum(t1.montoSoles)), Decimal?)),
            'SaldoAnteriorEF = (From c In HeliosData.cierreCaja
            '                   Where
            '                        c.idEmpresa = be.idEmpresa And
            '                        c.periodo = periodoAnt And
            '                        c.idEntidadFinanciera = ef.idestado
            '                   Select New With
            '                               {
            '                                   c.montoMN
            '                               }).FirstOrDefault().montoMN


            Dim con = From ef In HeliosData.estadosFinancieros
                      Where
                      ef.idEmpresa = be.idEmpresa And
                          ef.idEstablecimiento = be.idEstablecimiento And
                          ef.tipo <> "EP"
                      Order By
                      ef.tipo
                      Select
                      ef.idEstablecimiento,
                      ef.idestado,
                      ef.descripcion,
                      ef.codigo,
                      ef.tipo,
                      Ingreso = (CType((Aggregate t1 In
                                        (From c In HeliosData.documentoCaja
                                         Where
                                             c.idEmpresa = be.idEmpresa And
                                             c.idEstablecimiento = be.idEstablecimiento And
                                             c.entidadFinancieraDestino = CStr(ef.idestado) And
                                             c.tipoMovimiento = "DC" And
                                             c.estado = "1" _
                                             And c.fechaProcesoDestino.Value.Year = be.fechaProcesoDestino.Value.Year _
                                             And c.fechaProcesoDestino.Value.Month = be.fechaProcesoDestino.Value.Month
                                         Select New With {
                                             c.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                      IngresoME = (CType((Aggregate t1 In
                                        (From c In HeliosData.documentoCaja
                                         Where
                                             c.idEmpresa = be.idEmpresa And
                                              c.idEstablecimiento = be.idEstablecimiento And
                                             c.entidadFinancieraDestino = CStr(ef.idestado) And
                                             c.tipoMovimiento = "DC" And
                                             c.estado = "1" _
                                             And c.fechaProcesoDestino.Value.Year = be.fechaProcesoDestino.Value.Year _
                                             And c.fechaProcesoDestino.Value.Month = be.fechaProcesoDestino.Value.Month
                                         Select New With {
                                             c.montoUsd
                                         }) Into Sum(t1.montoUsd)), Decimal?)),
                     Salida = (CType((Aggregate t1 In
                                      (From c In HeliosData.documentoCaja
                                       Where
                                           c.idEmpresa = be.idEmpresa And
                                            c.idEstablecimiento = be.idEstablecimiento And
                                           c.entidadFinancieraDestino = CStr(ef.idestado) And
                                           c.tipoMovimiento = "PG" And
                                           c.estado = "1" _
                                           And c.fechaProcesoDestino.Value.Year = be.fechaProcesoDestino.Value.Year _
                                           And c.fechaProcesoDestino.Value.Month = be.fechaProcesoDestino.Value.Month
                                       Select New With {
                                           c.montoSoles
                                       }) Into Sum(t1.montoSoles)), Decimal?)),
                          SalidaME = (CType((Aggregate t1 In
                                      (From c In HeliosData.documentoCaja
                                       Where
                                           c.idEmpresa = be.idEmpresa And
                                            c.idEstablecimiento = be.idEstablecimiento And
                                           c.entidadFinancieraDestino = CStr(ef.idestado) And
                                           c.tipoMovimiento = "PG" And
                                           c.estado = "1" _
                                           And c.fechaProcesoDestino.Value.Year = be.fechaProcesoDestino.Value.Year _
                                           And c.fechaProcesoDestino.Value.Month = be.fechaProcesoDestino.Value.Month
                                       Select New With {
                                           c.montoUsd
                                       }) Into Sum(t1.montoUsd)), Decimal?))

            For Each i In con
                obj = New estadosFinancieros
                obj.idEstablecimiento = i.idEstablecimiento
                obj.idestado = i.idestado
                obj.descripcion = i.descripcion
                obj.codigo = i.codigo
                obj.tipo = i.tipo
                obj.Ingresos = i.Ingreso.GetValueOrDefault
                obj.IngresosME = i.IngresoME.GetValueOrDefault
                obj.Salidas = i.Salida.GetValueOrDefault
                obj.SalidasME = i.SalidaME.GetValueOrDefault
                obj.SaldoAnterior = 0 ' i.SaldoAnteriorEF.GetValueOrDefault
                Lista.Add(obj)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return Lista
    End Function


    Public Function GetEstadoCajasTodosDetalleByDiaAllEmpresa(be As documentoCaja) As List(Of estadosFinancieros)
        Dim obj As New estadosFinancieros
        Dim Lista As New List(Of estadosFinancieros)
        Try
            Dim con = From ef In HeliosData.estadosFinancieros
                      Join emp In HeliosData.empresa
                      On ef.idEmpresa Equals emp.idEmpresa
                      Order By
                      ef.tipo
                      Select
                      emp.nombreCorto,
                      ef.idEmpresa,
                      ef.descripcion,
                      ef.codigo,
                      ef.tipo,
                      Ingreso = (CType((Aggregate t1 In
                                        (From c In HeliosData.documentoCaja
                                         Where
                                         c.entidadFinanciera = CStr(ef.idestado) And
                                         c.tipoMovimiento = "DC" _
                                         And c.tipoOperacion <> StatusTipoOperacion.CIERRES _
                                         And c.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
                                         And c.fechaProceso.Value.Month = be.fechaProceso.Value.Month _
                                         And c.fechaProceso.Value.Day = be.fechaProceso.Value.Day
                                         Select New With {
                                             c.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                     Salida = (CType((Aggregate t1 In
                                      (From c In HeliosData.documentoCaja
                                       Where
                                           c.entidadFinanciera = CStr(ef.idestado) And
                                           c.tipoMovimiento = "PG" _
                                           And c.tipoOperacion <> StatusTipoOperacion.CIERRES _
                                           And c.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
                                           And c.fechaProceso.Value.Month = be.fechaProceso.Value.Month _
                                           And c.fechaProceso.Value.Day = be.fechaProceso.Value.Day
                                       Select New With {
                                           c.montoSoles
                                       }) Into Sum(t1.montoSoles)), Decimal?))


            For Each i In con
                obj = New estadosFinancieros
                obj.idEmpresa = i.idEmpresa
                obj.NomCortoEmpresa = i.nombreCorto
                obj.descripcion = i.descripcion
                obj.codigo = i.codigo
                obj.tipo = i.tipo
                obj.Ingresos = i.Ingreso.GetValueOrDefault
                obj.Salidas = i.Salida.GetValueOrDefault
                Lista.Add(obj)
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return Lista
    End Function

    Public Function ObtenerEFPorCuentaFinancieraDestino(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, cuentaOrigen As Integer, moneda As Integer) As List(Of estadosFinancieros)
        Dim obj As New estadosFinancieros
        Dim Lista As New List(Of estadosFinancieros)
        Dim consulta = (From n In HeliosData.estadosFinancieros
                        Where n.idEmpresa = Gempresas.IdEmpresaRuc _
                           And n.tipo = strTipo _
                           And n.idestado <> cuentaOrigen
                        Select n).ToList

        For Each i In consulta

            If (moneda = i.codigo) Then
                obj = New estadosFinancieros
                obj.idestado = i.idestado
                obj.descripcion = i.descripcion
                obj.tipo = i.tipo
                obj.codigo = IIf(i.codigo = 1, "NACIONAL", "EXTRANJERA")
                obj.cuenta = i.cuenta
                Lista.Add(obj)

            End If


            'Select Case moneda
            '    Case 1 = i.codigo
            '        obj = New estadosFinancieros
            '        obj.idestado = i.idestado
            '        obj.descripcion = i.descripcion
            '        obj.tipo = i.tipo
            '        obj.codigo = IIf(i.codigo = 1, "NACIONAL", "EXTRANJERA")
            '        obj.cuenta = i.cuenta
            '        Lista.Add(obj)
            '    Case Else
            '        obj = New estadosFinancieros
            '        obj.idestado = i.idestado
            '        obj.descripcion = i.descripcion
            '        obj.tipo = i.tipo ' IIf(i.tipo = "BC", "BANCO", "EFECTIVO")
            '        obj.codigo = IIf(i.codigo = 1, "NACIONAL", "EXTRANJERA")
            '        obj.cuenta = i.cuenta
            '        Lista.Add(obj)
            'End Select
        Next
        Return Lista
    End Function

    'Public Function GetEstadoCajasInformacionGeneral(be As documentoCaja, listaPersona As List(Of String), tipoBusqueda As String, fechaInicio As DateTime, fechaFin As DateTime, intAnio As Integer, intMes As Integer, strEmpresa As String, idEstablec As Integer) As List(Of estadosFinancieros)
    '    Dim obj As New estadosFinancieros
    '    Dim Lista As New List(Of estadosFinancieros)
    '    Dim periodo As String
    '    Try

    '        Select Case tipoBusqueda
    '            Case "XDia"

    '                Dim con = From ef In HeliosData.estadosFinancieros
    '                          Where
    '                                ef.idEmpresa = strEmpresa And
    '                                ef.idEstablecimiento = idEstablec
    '                          Order By
    '                                ef.tipo()
    '                          Select
    '                                ef.descripcion,
    '                                ef.codigo,
    '                                ef.tipo,
    '                                ef.idestado,
    '     Ingreso = (CType((Aggregate t1 In
    '                       (From c In HeliosData.documentoCaja
    '                        Where
    '                            c.entidadFinanciera = CStr(ef.idestado) And
    '                            c.tipoMovimiento = "DC" _
    '                        And CStr(c.fechaProceso) >= fechaInicio And
    '                            CStr(c.fechaProceso) <= fechaFin And
    '                            listaPersona.Contains(c.usuarioModificacion) And
    '                            c.idEmpresa = strEmpresa And
    '                            c.idEstablecimiento = idEstablec
    '                        Select New With {
    '                           c.montoSoles
    '                       }) Into Sum(t1.montoSoles)), Decimal?)),
    '    Salida = (CType((Aggregate t1 In
    '                     (From c In HeliosData.documentoCaja
    '                      Where
    '                            c.entidadFinanciera = CStr(ef.idestado) _
    '                            And CStr(c.fechaProceso) >= fechaInicio And
    '                            CStr(c.fechaProceso) <= fechaFin And
    '                            c.tipoMovimiento = "PG" _
    '                            And listaPersona.Contains(c.usuarioModificacion) And
    '                            c.idEmpresa = strEmpresa And
    '                            c.idEstablecimiento = idEstablec
    '                      Select New With {
    '                          c.montoSoles
    '                      }) Into Sum(t1.montoSoles)), Decimal?))

    '                For Each i In con
    '                    obj = New estadosFinancieros
    '                    obj.descripcion = i.descripcion
    '                    obj.codigo = i.codigo
    '                    obj.tipo = i.tipo
    '                    obj.Ingresos = i.Ingreso.GetValueOrDefault
    '                    obj.Salidas = i.Salida.GetValueOrDefault
    '                    obj.idestado = i.idestado
    '                    Lista.Add(obj)
    '                Next

    '            Case "XPeriodo"
    '                periodo = (CStr(intMes) + "/" + CStr(intAnio))
    '                Dim con = From ef In HeliosData.estadosFinancieros
    '                          Where
    '                                ef.idEmpresa = strEmpresa And
    '                                ef.idEstablecimiento = idEstablec
    '                          Order By
    '                                ef.tipo
    '                          Select
    '                                ef.descripcion,
    '                                ef.codigo,
    '                                ef.tipo,
    '                                  ef.idestado,
    '      Ingreso = (CType((Aggregate t1 In
    '                        (From c In HeliosData.documentoCaja
    '                         Where
    '                                c.entidadFinanciera = CStr(ef.idestado) And
    '                                c.fechaProceso.Value.Year = intAnio And
    '                                  c.fechaProceso.Value.Month = intMes And
    '                                c.tipoMovimiento = "DC" _
    '                                And listaPersona.Contains(c.usuarioModificacion) And
    '                                c.idEmpresa = strEmpresa And
    '                                c.idEstablecimiento = idEstablec
    '                         Select New With {
    '                            c.montoSoles
    '                        }) Into Sum(t1.montoSoles)), Decimal?)),
    '     Salida = (CType((Aggregate t1 In
    '                      (From c In HeliosData.documentoCaja
    '                       Where
    '                            c.entidadFinanciera = CStr(ef.idestado) And
    '                                 c.fechaProceso.Value.Year = intAnio And
    '                                  c.fechaProceso.Value.Month = intMes And
    '                            c.tipoMovimiento = "PG" _
    '                            And listaPersona.Contains(c.usuarioModificacion) _
    '                            And c.idEmpresa = strEmpresa And
    '                            c.idEstablecimiento = idEstablec
    '                       Select New With {
    '                           c.montoSoles
    '                       }) Into Sum(t1.montoSoles)), Decimal?))

    '                For Each i In con
    '                    obj = New estadosFinancieros
    '                    obj.descripcion = i.descripcion
    '                    obj.codigo = i.codigo
    '                    obj.tipo = i.tipo
    '                    obj.Ingresos = i.Ingreso.GetValueOrDefault
    '                    obj.Salidas = i.Salida.GetValueOrDefault
    '                    obj.idestado = i.idestado
    '                    Lista.Add(obj)
    '                Next

    '            Case "XTodo"

    '                Dim con = From ef In HeliosData.estadosFinancieros
    '                          Where
    '                                ef.idEmpresa = strEmpresa And
    '                                ef.idEstablecimiento = idEstablec
    '                          Order By
    '                                ef.tipo
    '                          Select
    '                                ef.descripcion,
    '                                ef.codigo,
    '                                ef.tipo,
    '                                  ef.idestado,
    '     Ingreso = (CType((Aggregate t1 In
    '                       (From c In HeliosData.documentoCaja
    '                        Where
    '                                    c.entidadFinanciera = CStr(ef.idestado) And
    '                                    c.fechaProceso.Value.Year = intAnio And
    '                                    c.tipoMovimiento = "DC" _
    '                                    And listaPersona.Contains(c.usuarioModificacion) And
    '                                    c.idEmpresa = strEmpresa And
    '                                    c.idEstablecimiento = idEstablec
    '                        Select New With {
    '                           c.montoSoles
    '                       }) Into Sum(t1.montoSoles)), Decimal?)),
    '    Salida = (CType((Aggregate t1 In
    '                     (From c In HeliosData.documentoCaja
    '                      Where c.entidadFinanciera = CStr(ef.idestado) And
    '                             c.fechaProceso.Value.Year = intAnio And
    '                            c.tipoMovimiento = "PG" _
    '                            And listaPersona.Contains(c.usuarioModificacion) _
    '                            And c.idEmpresa = strEmpresa And
    '                            c.idEstablecimiento = idEstablec
    '                      Select New With {
    '                          c.montoSoles
    '                      }) Into Sum(t1.montoSoles)), Decimal?))

    '                For Each i In con
    '                    obj = New estadosFinancieros
    '                    obj.descripcion = i.descripcion
    '                    obj.codigo = i.codigo
    '                    obj.tipo = i.tipo
    '                    obj.Ingresos = i.Ingreso.GetValueOrDefault
    '                    obj.Salidas = i.Salida.GetValueOrDefault
    '                    obj.idestado = i.idestado
    '                    Lista.Add(obj)
    '                Next

    '        End Select



    '    Catch ex As Exception
    '        Throw ex
    '    End Try


    '    Return Lista
    'End Function

    Public Function GetEstadoCajasInformacionGeneral(be As documentoCaja, listaPersona As List(Of String), tipoBusqueda As String, fechaInicio As DateTime, fechaFin As DateTime, intAnio As Integer, intMes As Integer, strEmpresa As String, idEstablec As Integer, intDia As Integer) As List(Of estadosFinancieros)
        Dim obj As New estadosFinancieros
        Dim Lista As New List(Of estadosFinancieros)
        Dim periodo As String
        Try

            Select Case tipoBusqueda
                Case "XDia"

                    Dim con = From ef In HeliosData.estadosFinancieros
                              Where
                                    ef.idEmpresa = strEmpresa And
                                    ef.idEstablecimiento = idEstablec
                              Order By
                                    ef.tipo()
                              Select
                                    ef.descripcion,
                                    ef.codigo,
                                    ef.tipo,
                                    ef.idestado,
         Ingreso = (CType((Aggregate t1 In
                           (From c In HeliosData.documentoCaja
                            Where
                                c.entidadFinanciera = CStr(ef.idestado) And
                                c.tipoMovimiento = "DC" _
                            And CStr(c.fechaProceso) >= fechaInicio And
                                CStr(c.fechaProceso) <= fechaFin And
                                listaPersona.Contains(c.usuarioModificacion) And
                                c.idEmpresa = strEmpresa And
                                c.idEstablecimiento = idEstablec
                            Select New With {
                               c.montoSoles
                           }) Into Sum(t1.montoSoles)), Decimal?)),
        Salida = (CType((Aggregate t1 In
                         (From c In HeliosData.documentoCaja
                          Where
                                c.entidadFinanciera = CStr(ef.idestado) _
                                And CStr(c.fechaProceso) >= fechaInicio And
                                CStr(c.fechaProceso) <= fechaFin And
                                c.tipoMovimiento = "PG" _
                                And listaPersona.Contains(c.usuarioModificacion) And
                                c.idEmpresa = strEmpresa And
                                c.idEstablecimiento = idEstablec
                          Select New With {
                              c.montoSoles
                          }) Into Sum(t1.montoSoles)), Decimal?))

                    For Each i In con
                        obj = New estadosFinancieros
                        obj.descripcion = i.descripcion
                        obj.codigo = i.codigo
                        obj.tipo = i.tipo
                        obj.Ingresos = i.Ingreso.GetValueOrDefault
                        obj.Salidas = i.Salida.GetValueOrDefault
                        obj.idestado = i.idestado
                        Lista.Add(obj)
                    Next

                Case "XPeriodo"
                    periodo = (CStr(intMes) + "/" + CStr(intAnio))
                    Dim con = From ef In HeliosData.estadosFinancieros
                              Where
                                    ef.idEmpresa = strEmpresa And
                                    ef.idEstablecimiento = idEstablec
                              Order By
                                    ef.tipo
                              Select
                                    ef.descripcion,
                                    ef.codigo,
                                    ef.tipo,
                                      ef.idestado,
          Ingreso = (CType((Aggregate t1 In
                            (From c In HeliosData.documentoCaja
                             Where
                                    c.entidadFinanciera = CStr(ef.idestado) And
                                    c.fechaProceso.Value.Year = intAnio And
                                      c.fechaProceso.Value.Month = intMes And
                                    c.tipoMovimiento = "DC" _
                                    And listaPersona.Contains(c.usuarioModificacion) And
                                    c.idEmpresa = strEmpresa And
                                    c.idEstablecimiento = idEstablec
                             Select New With {
                                c.montoSoles
                            }) Into Sum(t1.montoSoles)), Decimal?)),
         Salida = (CType((Aggregate t1 In
                          (From c In HeliosData.documentoCaja
                           Where
                                c.entidadFinanciera = CStr(ef.idestado) And
                                     c.fechaProceso.Value.Year = intAnio And
                                      c.fechaProceso.Value.Month = intMes And
                                c.tipoMovimiento = "PG" _
                                And listaPersona.Contains(c.usuarioModificacion) _
                                And c.idEmpresa = strEmpresa And
                                c.idEstablecimiento = idEstablec
                           Select New With {
                               c.montoSoles
                           }) Into Sum(t1.montoSoles)), Decimal?))

                    For Each i In con
                        obj = New estadosFinancieros
                        obj.descripcion = i.descripcion
                        obj.codigo = i.codigo
                        obj.tipo = i.tipo
                        obj.Ingresos = i.Ingreso.GetValueOrDefault
                        obj.Salidas = i.Salida.GetValueOrDefault
                        obj.idestado = i.idestado
                        Lista.Add(obj)
                    Next

                Case "XTodo"

                    Dim con = From ef In HeliosData.estadosFinancieros
                              Where
                                    ef.idEmpresa = strEmpresa And
                                    ef.idEstablecimiento = idEstablec
                              Order By
                                    ef.tipo
                              Select
                                    ef.descripcion,
                                    ef.codigo,
                                    ef.tipo,
                                      ef.idestado,
         Ingreso = (CType((Aggregate t1 In
                           (From c In HeliosData.documentoCaja
                            Where
                                        c.entidadFinanciera = CStr(ef.idestado) And
                                        c.fechaProceso.Value.Year = intAnio And
                                        c.tipoMovimiento = "DC" _
                                        And listaPersona.Contains(c.usuarioModificacion) And
                                        c.idEmpresa = strEmpresa And
                                        c.idEstablecimiento = idEstablec
                            Select New With {
                               c.montoSoles
                           }) Into Sum(t1.montoSoles)), Decimal?)),
        Salida = (CType((Aggregate t1 In
                         (From c In HeliosData.documentoCaja
                          Where c.entidadFinanciera = CStr(ef.idestado) And
                                 c.fechaProceso.Value.Year = intAnio And
                                c.tipoMovimiento = "PG" _
                                And listaPersona.Contains(c.usuarioModificacion) _
                                And c.idEmpresa = strEmpresa And
                                c.idEstablecimiento = idEstablec
                          Select New With {
                              c.montoSoles
                          }) Into Sum(t1.montoSoles)), Decimal?))

                    For Each i In con
                        obj = New estadosFinancieros
                        obj.descripcion = i.descripcion
                        obj.codigo = i.codigo
                        obj.tipo = i.tipo
                        obj.Ingresos = i.Ingreso.GetValueOrDefault
                        obj.Salidas = i.Salida.GetValueOrDefault
                        obj.idestado = i.idestado
                        Lista.Add(obj)
                    Next

                Case "XHora"

                    Dim con = From ef In HeliosData.estadosFinancieros
                              Where
                                    ef.idEmpresa = strEmpresa And
                                    ef.idEstablecimiento = idEstablec
                              Order By
                                    ef.tipo
                              Select
                                    ef.descripcion,
                                    ef.codigo,
                                    ef.tipo,
                                      ef.idestado,
                            Ingreso = (CType((Aggregate t1 In
                           (From c In HeliosData.documentoCaja
                            Where
                                        c.entidadFinanciera = CStr(ef.idestado) And
                                         c.fechaProceso.Value.Year = intAnio And
                                            c.fechaProceso.Value.Month = intMes And
                                             c.fechaProceso.Value.Day = intDia And
                                        c.fechaProceso.Value.Hour >= fechaInicio.Hour And
                                        c.fechaProceso.Value.Hour <= fechaFin.Hour And
                                        c.tipoMovimiento = "DC" _
                                        And listaPersona.Contains(c.usuarioModificacion) And
                                        c.idEmpresa = strEmpresa And
                                        c.idEstablecimiento = idEstablec
                            Select New With {
                               c.montoSoles
                           }) Into Sum(t1.montoSoles)), Decimal?)),
                        Salida = (CType((Aggregate t1 In
                         (From c In HeliosData.documentoCaja
                          Where c.entidadFinanciera = CStr(ef.idestado) And
                                        c.fechaProceso.Value = fechaInicio.Date And
                                        c.fechaProceso.Value.Hour >= fechaInicio.Hour And
                                        c.fechaProceso.Value.Hour <= fechaFin.Hour And
                                c.tipoMovimiento = "PG" _
                                And listaPersona.Contains(c.usuarioModificacion) _
                                And c.idEmpresa = strEmpresa And
                                c.idEstablecimiento = idEstablec
                          Select New With {
                              c.montoSoles
                          }) Into Sum(t1.montoSoles)), Decimal?))

                    For Each i In con
                        obj = New estadosFinancieros
                        obj.descripcion = i.descripcion
                        obj.codigo = i.codigo
                        obj.tipo = i.tipo
                        obj.Ingresos = i.Ingreso.GetValueOrDefault
                        obj.Salidas = i.Salida.GetValueOrDefault
                        obj.idestado = i.idestado
                        Lista.Add(obj)
                    Next

            End Select

        Catch ex As Exception
            Throw ex
        End Try


        Return Lista
    End Function

End Class

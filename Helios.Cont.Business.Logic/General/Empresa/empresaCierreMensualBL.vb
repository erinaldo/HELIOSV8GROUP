Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports Helios.General

Public Class empresaCierreMensualBL
    Inherits BaseBL

    Public Function GetValidaFechaInicioOperacion(idempresa As String, fechaActual As Date, IdEstablecimiento As Integer) As String
        Try
            GetValidaFechaInicioOperacion = "False"
            Dim fechaAnterior = fechaActual.AddMonths(-1)
            'statusTipoCierre.AperturaEmpresa
            Dim obj = HeliosData.empresaCierreMensual.Where(Function(o) o.idEmpresa = idempresa And o.idCentroCosto = IdEstablecimiento And o.tipoCierre = 1).Single
            Dim fechaInicio = New Date(obj.anio, obj.mes, 1)

            If fechaInicio.Date = fechaActual.Date Then
                GetValidaFechaInicioOperacion = "True"
            ElseIf fechaActual.Date < fechaInicio.Date Then
                GetValidaFechaInicioOperacion = "True"
                'Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
            ElseIf fechaAnterior.Date < fechaInicio.Date Then
                GetValidaFechaInicioOperacion = "True"
                'Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
            ElseIf fechaAnterior.Date = fechaInicio.Date Then
                '    GetValidaFechaInicioOperacion = True
                GetValidaFechaInicioOperacion = "TrueV"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub CerrarLogistica(be As empresaCierreMensual, documento As documento)
        Dim cierreInvBL As New cierreinventarioBL
        Try
            Using ts As New TransactionScope
                'cerrando inventario
                Dim idDocumento = cierreInvBL.CerrarByPeriodo(documento)
                be.idDocumento = idDocumento
                HeliosData.empresaCierreMensual.Add(be)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CerrarFinanzas(be As empresaCierreMensual, documento As documento)
        Dim documentoBL As New documentoBL
        Dim documentoCierre2 As New documento
        Dim documentoCaja As New documentoCaja
        Dim documentoCajadetalle As New documentoCajaDetalle
        Dim documentoCajaBL As New documentoCajaBL
        Dim documentoCajaDetBL As New documentoCajaDetalleBL
        Dim cajaBL As New estadosFinancierosBL
        Dim listaCaja As New List(Of cierreCaja)
        Dim objCierre As New cierreCaja
        Dim cierreCajaBL As New cierreCajaBL

        Try
            Dim periodo As String = String.Format("{0:00}", be.mes) & be.anio
            Dim periodo2 As String = String.Format("{0:00}", be.mes) & "/" & be.anio
            Dim fechaProceso = GetPeriodoConvertirToDate(periodo2)
            Dim periodoAnt As String = String.Format("{0:00}", be.mes - 1) & be.anio
            Using ts As New TransactionScope
                ''Cierre de cuentas financieras
                Dim listaCuentasFinancieras = cajaBL.GetEstadoCajasTodosDetalleByMensual(New documentoCaja With {.idEmpresa = be.idEmpresa, .periodo = periodo2, .fechaProceso = fechaProceso}, periodoAnt)

                listaCaja = New List(Of cierreCaja)
                Dim nuevaFechaCaja = New DateTime(be.anio, be.mes, 1, 0, 0, 0)
                nuevaFechaCaja = nuevaFechaCaja.AddMonths(1)

                documentoBL.InsertDocCierre(documento)

                For Each i In listaCuentasFinancieras
                    documentoCierre2 = New documento
                    documentoCierre2.idEmpresa = documento.idEmpresa
                    documentoCierre2.idCentroCosto = documento.idCentroCosto
                    documentoCierre2.tipoDoc = "-"
                    documentoCierre2.fechaProceso = nuevaFechaCaja 'New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
                    documentoCierre2.moneda = i.codigo
                    documentoCierre2.idEntidad = i.idestado
                    documentoCierre2.entidad = i.descripcion
                    documentoCierre2.tipoEntidad = "EF"
                    documentoCierre2.nrodocEntidad = "-"
                    documentoCierre2.nroDoc = "-"
                    documentoCierre2.tipoOperacion = StatusTipoOperacion.CIERRES
                    documentoCierre2.usuarioActualizacion = be.usuarioActualizacion
                    documentoCierre2.fechaActualizacion = Date.Now
                    documentoBL.Insert(documentoCierre2)

                    documentoCaja = New documentoCaja
                    documentoCaja.idDocumento = documentoCierre2.idDocumento ' idDocumento
                    documentoCaja.idEmpresa = documento.idEmpresa
                    documentoCaja.idEstablecimiento = documento.idCentroCosto
                    documentoCaja.entidadFinanciera = i.idestado
                    documentoCaja.codigoLibro = StatusCodigoLibroContable.LIBRO_CAJA_Y_BANCOS
                    documentoCaja.tipoMovimiento = "DC"
                    documentoCaja.idPersonal = 0
                    documentoCaja.fechaProceso = nuevaFechaCaja ' New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
                    documentoCaja.periodo = String.Format("{0:00}", nuevaFechaCaja.Month) & "/" & nuevaFechaCaja.Year
                    documentoCaja.fechaCobro = nuevaFechaCaja ' New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
                    documentoCaja.tipoDocPago = "0"
                    documentoCaja.numeroDoc = "-"
                    documentoCaja.moneda = i.codigo
                    documentoCaja.tipoOperacion = StatusTipoOperacion.CIERRES
                    documentoCaja.numeroOperacion = "-"
                    documentoCaja.tipoCambio = 1
                    documentoCaja.montoSoles = (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) '  i.SaldoAnterior.GetValueOrDefault + (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) '  i.SaldoCaja.GetValueOrDefault ' listaCuentasFinancieras.Sum(Function(o) o.SaldoCaja).GetValueOrDefault
                    documentoCaja.montoUsd = 0
                    documentoCaja.glosa = "Cierre de la EF. " & i.descripcion
                    documentoCaja.entregado = "SI"
                    documentoCaja.movimientoCaja = "CIE"
                    documentoCaja.usuarioModificacion = be.usuarioActualizacion
                    documentoCaja.fechaModificacion = Date.Now
                    documentoCajaBL.Insert(documentoCaja, documentoCierre2.idDocumento)

                    '---------------------------------------------------------------------
                    documentoCajadetalle = New documentoCajaDetalle
                    documentoCajadetalle.idDocumento = documentoCierre2.idDocumento ' idDocumento
                    documentoCajadetalle.entidadFinanciera = i.idestado
                    documentoCajadetalle.fecha = nuevaFechaCaja 'New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
                    documentoCajadetalle.idItem = 0
                    documentoCajadetalle.DetalleItem = "Cierre de caja: " & i.descripcion
                    documentoCajadetalle.montoSoles = (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) '  i.SaldoAnterior.GetValueOrDefault + (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) ' i.SaldoCaja.GetValueOrDefault
                    documentoCajadetalle.montoUsd = 0
                    documentoCajadetalle.diferTipoCambio = 0
                    documentoCajadetalle.entregado = "SI"
                    documentoCajadetalle.documentoAfectado = documento.idDocumento
                    documentoCajadetalle.usuarioModificacion = be.usuarioActualizacion
                    documentoCajadetalle.fechaModificacion = Date.Now
                    documentoCajaDetBL.InsertarNuevaFila(documentoCajadetalle)
                    '-----------------------------------------------------------------------------

                    objCierre = New cierreCaja
                    objCierre.idEntidadFinanciera = i.idestado
                    objCierre.idDocumento = documento.idDocumento
                    objCierre.idEmpresa = documento.idEmpresa
                    objCierre.idEstablecimiento = i.idEstablecimiento
                    objCierre.periodo = periodo
                    objCierre.fechaProceso = be.fechaActualizacion
                    objCierre.anio = be.anio
                    objCierre.mes = be.mes
                    objCierre.dia = be.fechaActualizacion.Value.Day
                    objCierre.montoMN = (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) '  i.SaldoAnterior.GetValueOrDefault + (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) 'i.SaldoCaja.GetValueOrDefault 'i.SaldoCajaCierre.GetValueOrDefault
                    objCierre.montoME = 0
                    objCierre.usuarioActualizacion = be.usuarioActualizacion
                    objCierre.fechaActualizacion = DateTime.Now
                    listaCaja.Add(objCierre)
                Next
                cierreCajaBL.GrabarListaCierreCaja(listaCaja)

                HeliosData.empresaCierreMensual.Add(be)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CierreContabilidad(be As empresaCierreMensual, documento As documento)
        Dim listaContableFull As New List(Of cierrecontable)
        Dim cierrecontable As New cierrecontable()
        Dim movimientosBL As New movimientoBL
        Dim documentoBL As New documentoBL
        Dim cierrecontableBL As New cierrecontableBL
        Try
            Dim periodo As String = String.Format("{0:00}", be.mes) & be.anio
            Dim periodo2 As String = String.Format("{0:00}", be.mes) & "/" & be.anio
            Dim fechaProceso = GetPeriodoConvertirToDate(periodo2)
            Dim periodoAnt As String = String.Format("{0:00}", be.mes - 1) & be.anio

            Using ts As New TransactionScope

                documentoBL.InsertDocCierre(documento)

                Dim listaContable = movimientosBL.GetCierreContablePeriodo(New asiento With {.periodo = periodo2, .idEmpresa = be.idEmpresa}, periodoAnt)
                listaContableFull = New List(Of cierrecontable)
                For Each r In listaContable
                    cierrecontable = New cierrecontable()
                    cierrecontable.idDocumento = documento.idDocumento
                    cierrecontable.idEmpresa = be.idEmpresa
                    cierrecontable.idCentroCosto = documento.idCentroCosto
                    cierrecontable.periodo = periodo
                    cierrecontable.cuenta = r.cuenta
                    cierrecontable.tipoasiento = r.tipo
                    cierrecontable.anio = be.anio
                    cierrecontable.mes = be.mes
                    Select Case r.tipo
                        Case "D"
                            cierrecontable.monto = r.monto + r.Montocero
                            cierrecontable.montoUSD = r.montoUSD + r.MontoceroUSD
                        Case "H"
                            cierrecontable.monto = r.monto + r.Montocero
                            cierrecontable.montoUSD = r.montoUSD + r.MontoceroUSD
                    End Select

                    cierrecontable.usuarioActualizacion = be.usuarioActualizacion
                    cierrecontable.fechaActualizacion = be.fechaActualizacion
                    listaContableFull.Add(cierrecontable)
                Next r
                cierrecontableBL.GrabarListaAsientosCierre(listaContableFull)

                HeliosData.empresaCierreMensual.Add(be)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EditarEmpresaCierreMensual(listaCierre As empresaCierreMensual)
        Try


            Dim cierreBL As New empresaCierreMensualBL
            Using ts As New TransactionScope

                HeliosData.empresaCierreMensual.Add(listaCierre)

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub GrabarCierrePeriodo(be As empresaCierreMensual, documento As documento)
        Dim documentoCierre2 As New documento
        Dim documentoBL As New documentoBL
        Dim documentoCaja As New documentoCaja
        Dim documentoCajadetalle As New documentoCajaDetalle
        Dim documentoCajaBL As New documentoCajaBL
        Dim documentoCajaDetBL As New documentoCajaDetalleBL
        Dim costoVentaBL As New cierreCostoVentaBL
        Dim cajaBL As New estadosFinancierosBL
        Dim movimientosBL As New movimientoBL
        Dim listaCaja As New List(Of cierreCaja)
        Dim listaInv As New List(Of cierreinventario)
        Dim listaContableFull As New List(Of cierrecontable)
        Dim cierrecontableBL As New cierrecontableBL
        Dim obj As New cierreinventario
        Dim objCierre As New cierreCaja
        Dim cierrecontable As New cierrecontable()
        Dim inventarioBL As New totalesAlmacenBL
        Dim cierreInvBL As New cierreinventarioBL
        Dim cierreCajaBL As New cierreCajaBL
        Dim cierreResultadosBL As New cierreResultadosBL
        Dim asientoBL As New AsientoBL
        Dim cierreEntregableBL As New cierreEntregablesBL

        Try

            Dim con = HeliosData.empresaCierreMensual.Where(Function(o) o.idEmpresa = be.idEmpresa And o.idCentroCosto = be.idCentroCosto And
                                                            o.anio = be.anio And o.mes = be.mes).FirstOrDefault

            If Not IsNothing(con) Then
                Throw New Exception("El periodo ingresado ya está registrado" & vbCrLf & "ingrese otro porfavor!")
            End If
            Using ts As New TransactionScope
                'cerrando inventario
                Dim idDocumento = cierreInvBL.CerrarByPeriodo(documento)
                be.idDocumento = idDocumento
                'cierre costo de ventas
                '       costoVentaBL.GrabarListaCierreCostoVentaV2(documento.cierreCostoVenta.ToList, idDocumento, documento)

                If Not IsNothing(documento.asiento) Then
                    If documento.asiento.Count > 0 Then
                        documento.idDocumento = idDocumento
                        asientoBL.SavebyGroupDoc(documento)
                    End If
                End If


                Dim periodoActual = New Date(be.anio, be.mes, 1)
                Dim periodoAnterior = periodoActual.AddMonths(-1)
                Dim fechaProcesoActual = GetPeriodoConvertirToDate(GetPeriodo(periodoActual, True))
                'Dim periodo As String = String.Format("{0:00}", be.mes) & be.anio
                'Dim periodo2 As String = String.Format("{0:00}", be.mes) & "/" & be.anio

                'Dim periodoAnt As String = String.Format("{0:00}", be.mes - 1) & be.anio


                '' Cierre Cuentas Contables

                Dim listaContable = movimientosBL.GetCierreContablePeriodo(New asiento With {.periodo = GetPeriodo(periodoActual, True), .idEmpresa = be.idEmpresa, .idCentroCostos = be.idCentroCosto}, GetPeriodo(periodoAnterior, False))
                listaContableFull = New List(Of cierrecontable)
                For Each r In listaContable
                    cierrecontable = New cierrecontable()
                    cierrecontable.idDocumento = idDocumento
                    cierrecontable.idEmpresa = be.idEmpresa
                    cierrecontable.idCentroCosto = documento.idCentroCosto
                    cierrecontable.periodo = GetPeriodo(periodoActual, False)
                    cierrecontable.cuenta = r.cuenta
                    cierrecontable.tipoasiento = r.tipo
                    cierrecontable.anio = be.anio
                    cierrecontable.mes = be.mes
                    Select Case r.tipo
                        Case "D"
                            cierrecontable.monto = r.monto + r.Montocero
                            cierrecontable.montoUSD = r.montoUSD + r.MontoceroUSD
                        Case "H"
                            cierrecontable.monto = r.monto + r.Montocero
                            cierrecontable.montoUSD = r.montoUSD + r.MontoceroUSD
                    End Select

                    cierrecontable.usuarioActualizacion = be.usuarioActualizacion
                    cierrecontable.fechaActualizacion = be.fechaActualizacion
                    listaContableFull.Add(cierrecontable)
                Next r
                cierrecontableBL.GrabarListaAsientosCierre(listaContableFull)
                '----------------------------------------------------------------


                ''Cierre de cuentas financieras
                Dim listaCuentasFinancieras = cajaBL.GetEstadoCajasTodosDetalleByMensual(New documentoCaja With {.idEmpresa = be.idEmpresa, .idEstablecimiento = be.idCentroCosto, .periodo = GetPeriodo(periodoActual, True), .fechaProcesoDestino = fechaProcesoActual}, GetPeriodo(periodoAnterior, False))

                listaCaja = New List(Of cierreCaja)
                Dim nuevaFechaCaja = New DateTime(be.anio, be.mes, 1, 0, 0, 0)
                nuevaFechaCaja = nuevaFechaCaja.AddMonths(1)
                For Each i In listaCuentasFinancieras
                    documentoCierre2 = New documento
                    documentoCierre2.idEmpresa = documento.idEmpresa
                    documentoCierre2.idCentroCosto = documento.idCentroCosto
                    documentoCierre2.tipoDoc = "-"
                    documentoCierre2.fechaProceso = nuevaFechaCaja 'New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
                    documentoCierre2.moneda = i.codigo
                    documentoCierre2.idEntidad = i.idestado
                    documentoCierre2.entidad = i.descripcion
                    documentoCierre2.tipoEntidad = "EF"
                    documentoCierre2.nrodocEntidad = "-"
                    documentoCierre2.nroDoc = "-"
                    documentoCierre2.tipoOperacion = StatusTipoOperacion.CIERRES
                    documentoCierre2.usuarioActualizacion = be.usuarioActualizacion
                    documentoCierre2.fechaActualizacion = Date.Now
                    documentoBL.Insert(documentoCierre2)

                    documentoCaja = New documentoCaja
                    documentoCaja.estado = "1"
                    documentoCaja.idDocumento = documentoCierre2.idDocumento ' idDocumento
                    documentoCaja.idEmpresa = documento.idEmpresa
                    documentoCaja.idEstablecimiento = documento.idCentroCosto
                    documentoCaja.entidadFinancieraDestino = i.idestado
                    documentoCaja.codigoLibro = StatusCodigoLibroContable.LIBRO_CAJA_Y_BANCOS
                    documentoCaja.tipoMovimiento = "DC"
                    documentoCaja.idPersonal = 0
                    documentoCaja.tipoEntidadFinanciera = "EF"
                    documentoCaja.fechaProcesoDestino = nuevaFechaCaja ' New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
                    documentoCaja.periodo = String.Format("{0:00}", nuevaFechaCaja.Month) & "/" & nuevaFechaCaja.Year
                    documentoCaja.fechaCobro = nuevaFechaCaja ' New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
                    documentoCaja.tipoDocPago = "0"
                    documentoCaja.numeroDoc = "-"
                    documentoCaja.moneda = i.codigo
                    documentoCaja.tipoOperacion = StatusTipoOperacion.CIERRES
                    documentoCaja.numeroOperacion = "-"
                    documentoCaja.tipoCambio = 1
                    documentoCaja.montoSoles = (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) '  i.SaldoAnterior.GetValueOrDefault + (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) '  i.SaldoCaja.GetValueOrDefault ' listaCuentasFinancieras.Sum(Function(o) o.SaldoCaja).GetValueOrDefault
                    documentoCaja.montoUsd = (i.IngresosME.GetValueOrDefault - i.SalidasME.GetValueOrDefault)
                    documentoCaja.glosa = "Cierre de la EF. " & i.descripcion
                    documentoCaja.entregado = "SI"
                    documentoCaja.movimientoCaja = "CIE"
                    documentoCaja.usuarioModificacion = be.usuarioActualizacion
                    documentoCaja.fechaModificacion = Date.Now
                    documentoCajaBL.Insert(documentoCaja, documentoCierre2.idDocumento)

                    '---------------------------------------------------------------------
                    documentoCajadetalle = New documentoCajaDetalle
                    documentoCajadetalle.idDocumento = documentoCierre2.idDocumento ' idDocumento
                    documentoCajadetalle.entidadFinanciera = i.idestado
                    documentoCajadetalle.fecha = nuevaFechaCaja 'New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
                    documentoCajadetalle.idItem = 0
                    documentoCajadetalle.DetalleItem = "Cierre de caja: " & i.descripcion
                    documentoCajadetalle.montoSoles = (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) '  i.SaldoAnterior.GetValueOrDefault + (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) ' i.SaldoCaja.GetValueOrDefault
                    documentoCajadetalle.montoUsd = (i.IngresosME.GetValueOrDefault - i.SalidasME.GetValueOrDefault)
                    documentoCajadetalle.diferTipoCambio = 0
                    documentoCajadetalle.entregado = "SI"
                    documentoCajadetalle.documentoAfectado = idDocumento
                    documentoCajadetalle.usuarioModificacion = be.usuarioActualizacion
                    documentoCajadetalle.fechaModificacion = Date.Now
                    documentoCajaDetBL.InsertarNuevaFila(documentoCajadetalle)
                    '-----------------------------------------------------------------------------

                    objCierre = New cierreCaja
                    objCierre.idEntidadFinanciera = i.idestado
                    objCierre.idDocumento = idDocumento
                    objCierre.idEmpresa = documento.idEmpresa
                    objCierre.idEstablecimiento = i.idEstablecimiento
                    objCierre.periodo = GetPeriodo(periodoActual, False)
                    objCierre.fechaProceso = be.fechaActualizacion
                    objCierre.anio = be.anio
                    objCierre.mes = be.mes
                    objCierre.dia = be.fechaActualizacion.Value.Day
                    objCierre.montoMN = (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) '  i.SaldoAnterior.GetValueOrDefault + (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) 'i.SaldoCaja.GetValueOrDefault 'i.SaldoCajaCierre.GetValueOrDefault
                    objCierre.montoME = (i.IngresosME.GetValueOrDefault - i.SalidasME.GetValueOrDefault)
                    objCierre.usuarioActualizacion = be.usuarioActualizacion
                    objCierre.fechaActualizacion = DateTime.Now
                    listaCaja.Add(objCierre)
                Next
                cierreCajaBL.GrabarListaCierreCaja(listaCaja)
                ''------------------------------------------------------------------------------------------------------------------------
                For Each k In documento.cierreResultados

                    cierreResultadosBL.Insert(k, idDocumento)

                Next


                '-------------------------

                For Each z In documento.cierreCostoVenta

                    costoVentaBL.Insert(z, idDocumento)

                Next
                ' costoVentaBL.GetListado_cierreCostoVenta(documento.cierreCostoVenta)

                '------------------------- entregabless

                'For Each z In documento.cierreEntregables

                '    cierreEntregableBL.Insert(z, idDocumento)

                'Next




                '-------------------------------------

                HeliosData.empresaCierreMensual.Add(be)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Public Sub GrabarCierrePeriodo(be As empresaCierreMensual, documento As documento)
    '    Dim documentoCierre2 As New documento
    '    Dim documentoBL As New documentoBL
    '    Dim documentoCaja As New documentoCaja
    '    Dim documentoCajadetalle As New documentoCajaDetalle
    '    Dim documentoCajaBL As New documentoCajaBL
    '    Dim documentoCajaDetBL As New documentoCajaDetalleBL
    '    Dim costoVentaBL As New cierreCostoVentaBL
    '    Dim cajaBL As New estadosFinancierosBL
    '    Dim movimientosBL As New movimientoBL
    '    Dim listaCaja As New List(Of cierreCaja)
    '    Dim listaInv As New List(Of cierreinventario)
    '    Dim listaContableFull As New List(Of cierrecontable)
    '    Dim cierrecontableBL As New cierrecontableBL
    '    Dim obj As New cierreinventario
    '    Dim objCierre As New cierreCaja
    '    Dim cierrecontable As New cierrecontable()
    '    Dim inventarioBL As New totalesAlmacenBL
    '    Dim cierreInvBL As New cierreinventarioBL
    '    Dim cierreCajaBL As New cierreCajaBL
    '    Try

    '        'dfss()
    '        Dim con = HeliosData.empresaCierreMensual.Where(Function(o) o.idEmpresa = Gempresas.IdEmpresaRuc And
    '                                                        o.anio = be.anio And o.mes = be.mes).FirstOrDefault

    '        If Not IsNothing(con) Then
    '            Throw New Exception("El periodo ingresado ya está registrado" & vbCrLf & "ingrese otro porfavor!")
    '        End If
    '        Using ts As New TransactionScope
    '            'cerrando inventario
    '            Dim idDocumento = cierreInvBL.CerrarByPeriodo(documento)
    '            be.idDocumento = idDocumento
    '            'cierre costo de ventas
    '            '       costoVentaBL.GrabarListaCierreCostoVentaV2(documento.cierreCostoVenta.ToList, idDocumento, documento)

    '            'inventarioBL.GetCurarKardexCaberasCierre(documento.cierreinventario.ToList)
    '            Dim periodo As String = String.Format("{0:00}", be.mes) & be.anio
    '            Dim periodo2 As String = String.Format("{0:00}", be.mes) & "/" & be.anio
    '            Dim periodoAnt As String = String.Format("{0:00}", be.mes - 1) & be.anio
    '            ''Cierre Inventario
    '            'Dim lista = inventarioBL.GetProductosXempresa(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
    '            'listaInv = New List(Of cierreinventario)
    '            'For Each r In lista
    '            '    obj = New cierreinventario
    '            '    obj.idEmpresa = Gempresas.IdEmpresaRuc
    '            '    obj.idCentroCosto = GEstableciento.IdEstablecimiento
    '            '    obj.periodo = periodo
    '            '    obj.idAlmacen = r.idAlmacen
    '            '    obj.idItem = r.idItem
    '            '    obj.anio = be.anio
    '            '    obj.mes = be.mes
    '            '    obj.dia = be.fechaActualizacion.Value.Day
    '            '    obj.cantidad = r.cantidad
    '            '    obj.importe = r.importeSoles
    '            '    obj.importeUS = r.importeDolares
    '            '    obj.unidad = r.unidadMedida
    '            '    obj.usuarioModificacion = be.usuarioActualizacion
    '            '    obj.fechaModificacion = be.fechaActualizacion
    '            '    listaInv.Add(obj)
    '            'Next
    '            'cierreInvBL.CerrarInventario(listaInv)
    '            ''------------------------------------------------------------------------------------------------------------------------

    '            '' Cierre Cuentas Contables

    '            Dim listaContable = movimientosBL.GetCierreContablePeriodo(New asiento With {.periodo = periodo2, .idEmpresa = Gempresas.IdEmpresaRuc}, periodoAnt)
    '            listaContableFull = New List(Of cierrecontable)
    '            For Each r In listaContable
    '                cierrecontable = New cierrecontable()
    '                cierrecontable.idDocumento = idDocumento
    '                cierrecontable.idEmpresa = Gempresas.IdEmpresaRuc
    '                cierrecontable.idCentroCosto = GEstableciento.IdEstablecimiento
    '                cierrecontable.periodo = periodo
    '                cierrecontable.cuenta = r.cuenta
    '                cierrecontable.tipoasiento = r.tipo
    '                cierrecontable.anio = be.anio
    '                cierrecontable.mes = be.mes
    '                Select Case r.tipo
    '                    Case "D"
    '                        cierrecontable.monto = r.monto + r.Montocero
    '                        cierrecontable.montoUSD = r.montoUSD + r.MontoceroUSD
    '                    Case "H"
    '                        cierrecontable.monto = r.monto + r.Montocero
    '                        cierrecontable.montoUSD = r.montoUSD + r.MontoceroUSD
    '                End Select

    '                cierrecontable.usuarioActualizacion = be.usuarioActualizacion
    '                cierrecontable.fechaActualizacion = be.fechaActualizacion
    '                listaContableFull.Add(cierrecontable)
    '            Next r
    '            cierrecontableBL.GrabarListaAsientosCierre(listaContableFull)
    '            '----------------------------------------------------------------


    '            ''Cierre de cuentas financieras
    '            Dim listaCuentasFinancieras = cajaBL.GetEstadoCajasTodosDetalleByMensual(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .periodo = periodo2}, periodoAnt)

    '            listaCaja = New List(Of cierreCaja)
    '            Dim nuevaFechaCaja = New DateTime(be.anio, be.mes, 1, 0, 0, 0)
    '            nuevaFechaCaja = nuevaFechaCaja.AddMonths(1)
    '            For Each i In listaCuentasFinancieras
    '                documentoCierre2 = New documento
    '                documentoCierre2.idEmpresa = documento.idEmpresa
    '                documentoCierre2.idCentroCosto = documento.idCentroCosto
    '                documentoCierre2.tipoDoc = "-"
    '                documentoCierre2.fechaProceso = nuevaFechaCaja 'New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
    '                documentoCierre2.moneda = i.codigo
    '                documentoCierre2.idEntidad = i.idestado
    '                documentoCierre2.entidad = i.descripcion
    '                documentoCierre2.tipoEntidad = "EF"
    '                documentoCierre2.nrodocEntidad = "-"
    '                documentoCierre2.nroDoc = "-"
    '                documentoCierre2.tipoOperacion = StatusTipoOperacion.CIERRES
    '                documentoCierre2.usuarioActualizacion = be.usuarioActualizacion
    '                documentoCierre2.fechaActualizacion = Date.Now
    '                documentoBL.Insert(documentoCierre2)

    '                documentoCaja = New documentoCaja
    '                documentoCaja.idDocumento = documentoCierre2.idDocumento ' idDocumento
    '                documentoCaja.idEmpresa = documento.idEmpresa
    '                documentoCaja.idEstablecimiento = documento.idCentroCosto
    '                documentoCaja.entidadFinanciera = i.idestado
    '                documentoCaja.codigoLibro = StatusCodigoLibroContable.LIBRO_CAJA_Y_BANCOS
    '                documentoCaja.tipoMovimiento = "DC"
    '                documentoCaja.idPersonal = 0
    '                documentoCaja.fechaProceso = nuevaFechaCaja ' New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
    '                documentoCaja.periodo = String.Format("{0:00}", nuevaFechaCaja.Month) & "/" & nuevaFechaCaja.Year
    '                documentoCaja.fechaCobro = nuevaFechaCaja ' New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
    '                documentoCaja.tipoDocPago = "0"
    '                documentoCaja.numeroDoc = "-"
    '                documentoCaja.moneda = i.codigo
    '                documentoCaja.tipoOperacion = StatusTipoOperacion.CIERRES
    '                documentoCaja.numeroOperacion = "-"
    '                documentoCaja.tipoCambio = 1
    '                documentoCaja.montoSoles = i.SaldoAnterior.GetValueOrDefault + (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) '  i.SaldoCaja.GetValueOrDefault ' listaCuentasFinancieras.Sum(Function(o) o.SaldoCaja).GetValueOrDefault
    '                documentoCaja.montoUsd = 0
    '                documentoCaja.glosa = "Cierre de la EF. " & i.descripcion
    '                documentoCaja.entregado = "SI"
    '                documentoCaja.movimientoCaja = "CIE"
    '                documentoCaja.usuarioModificacion = be.usuarioActualizacion
    '                documentoCaja.fechaModificacion = Date.Now
    '                documentoCajaBL.Insert(documentoCaja, documentoCierre2.idDocumento)

    '                '---------------------------------------------------------------------
    '                documentoCajadetalle = New documentoCajaDetalle
    '                documentoCajadetalle.idDocumento = documentoCierre2.idDocumento ' idDocumento
    '                documentoCajadetalle.entidadFinanciera = i.idestado
    '                documentoCajadetalle.fecha = nuevaFechaCaja 'New DateTime(be.anio, be.mes + 1, 1, 0, 0, 0)
    '                documentoCajadetalle.idItem = 0
    '                documentoCajadetalle.DetalleItem = "Cierre de caja: " & i.descripcion
    '                documentoCajadetalle.montoSoles = i.SaldoAnterior.GetValueOrDefault + (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) ' i.SaldoCaja.GetValueOrDefault
    '                documentoCajadetalle.montoUsd = 0
    '                documentoCajadetalle.diferTipoCambio = 0
    '                documentoCajadetalle.entregado = "SI"
    '                documentoCajadetalle.documentoAfectado = idDocumento
    '                documentoCajadetalle.usuarioModificacion = be.usuarioActualizacion
    '                documentoCajadetalle.fechaModificacion = Date.Now
    '                documentoCajaDetBL.InsertarNuevaFila(documentoCajadetalle)
    '                '-----------------------------------------------------------------------------

    '                objCierre = New cierreCaja
    '                objCierre.idEntidadFinanciera = i.idestado
    '                objCierre.idDocumento = idDocumento
    '                objCierre.idEmpresa = documento.idEmpresa
    '                objCierre.idEstablecimiento = i.idEstablecimiento
    '                objCierre.periodo = periodo
    '                objCierre.fechaProceso = be.fechaActualizacion
    '                objCierre.anio = be.anio
    '                objCierre.mes = be.mes
    '                objCierre.dia = be.fechaActualizacion.Value.Day
    '                objCierre.montoMN = i.SaldoAnterior.GetValueOrDefault + (i.Ingresos.GetValueOrDefault - i.Salidas.GetValueOrDefault) 'i.SaldoCaja.GetValueOrDefault 'i.SaldoCajaCierre.GetValueOrDefault
    '                objCierre.montoME = 0
    '                objCierre.usuarioActualizacion = be.usuarioActualizacion
    '                objCierre.fechaActualizacion = DateTime.Now
    '                listaCaja.Add(objCierre)
    '            Next
    '            cierreCajaBL.GrabarListaCierreCaja(listaCaja)
    '            ''------------------------------------------------------------------------------------------------------------------------

    '            HeliosData.empresaCierreMensual.Add(be)
    '            HeliosData.SaveChanges()
    '            ts.Complete()
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Public Function GetCierresByEmpresa(be As empresaCierreMensual) As List(Of empresaCierreMensual)
        Return HeliosData.empresaCierreMensual.Where(Function(o) o.idEmpresa = be.idEmpresa And o.idCentroCosto = be.idCentroCosto).ToList()
    End Function

    Public Function EstadoMesCerrado(be As empresaCierreMensual) As Boolean
        Dim obj = HeliosData.empresaCierreMensual.Where(Function(o) o.idEmpresa = be.idEmpresa And o.idCentroCosto = be.idCentroCosto _
                                                            And o.anio = be.anio And o.mes = be.mes).FirstOrDefault
        If Not IsNothing(obj) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function EstadoMesCerradoInicioInventario(be As empresaCierreMensual) As Boolean
        Dim obj = HeliosData.empresaCierreMensual.Where(Function(o) o.idEmpresa = be.idEmpresa _
                                                            And o.anio = be.anio And o.mes = be.mes And o.tipoCierre = statusTipoCierre.AperturaEmpresa).FirstOrDefault
        If Not IsNothing(obj) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function EsInicioDeinventario(be As empresaCierreMensual) As Boolean
        Dim obj = HeliosData.empresaCierreMensual.Where(Function(o) o.idEmpresa = be.idEmpresa _
                                                            And o.anio = be.anio And o.mes = be.mes And o.tipoCierre = statusTipoCierre.AperturaEmpresa).FirstOrDefault

        If Not IsNothing(obj) Then
            Return True
        Else
            Return False
        End If
        Return True
    End Function

    Public Sub EliminarCierre(be As empresaCierreMensual)
        Dim invBL As New InventarioMovimientoBL
        Dim documentoBL As New documentoBL
        Using ts As New Transactions.TransactionScope
            Dim obj = HeliosData.empresaCierreMensual.Where(Function(o) o.idEmpresa = be.idEmpresa And o.anio = be.anio And o.mes = be.mes).FirstOrDefault
            'Dim c = HeliosData.cierreinventario.Where(Function(o) o.idEmpresa = Gempresas.IdEmpresaRuc And o.anio = be.anio And o.mes = be.mes).FirstOrDefault
            If Not IsNothing(obj) Then
                Dim docCajas = (From n In HeliosData.documentoCajaDetalle _
                         Where n.documentoAfectado = obj.idDocumento _
                         Select n.idDocumento).Distinct.ToList

                For Each i In docCajas
                    documentoBL.DeleteSingleVariable(i)
                Next
            End If

            If Not IsNothing(obj) Then
                If obj.idDocumento IsNot Nothing Then
                    invBL.DeleteInventarioPorDocumento(obj.idDocumento)
                    documentoBL.DeleteSingleVariable(obj.idDocumento)
                End If
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class

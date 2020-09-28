Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoPrestamosBL
    Inherits BaseBL



    Public Sub UpdateEstadoCuotaVencida(idcuota As Integer)
        Try
            Using ts As New TransactionScope
                Dim obj As documentoPrestamoDetalle = HeliosData.documentoPrestamoDetalle.Where(Function(o) o.secuencia = idcuota).FirstOrDefault
                If Not IsNothing(obj) Then
                    With obj
                        .tieneCosto = "S"
                    End With
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ListadoCuotasVencidasPO(tipo As String) As List(Of documentoPrestamoDetalle)
        Dim lista As New List(Of documentoPrestamoDetalle)
        Dim objPrestamo As New documentoPrestamoDetalle

        Dim consulta = (From n In HeliosData.prestamos _
                        Join h In HeliosData.documentoPrestamoDetalle _
                        On h.idDocumento Equals n.idDocumento
                       Where n.idEmpresa = Gempresas.IdEmpresaRuc And
                        n.tipoPrestamo = tipo And h.tieneCosto = "N" And
                       h.fechaVencimiento < DateTime.Now).ToList

        For Each i In consulta
            objPrestamo = New documentoPrestamoDetalle
            objPrestamo.idDocumento = i.n.idDocumento
            objPrestamo.tipoprestamo = i.n.tipoPrestamo
            objPrestamo.idCuota = i.h.secuencia
            objPrestamo.cuota = i.h.cuota
            objPrestamo.descripcion = i.h.descripcion
            objPrestamo.montoSoles = i.h.montoSoles
            objPrestamo.montoUsd = i.h.montoUsd
            objPrestamo.fechaVencimiento = i.h.fechaVencimiento
            objPrestamo.devengado = i.h.devengado
            objPrestamo.devengadoH = i.h.devengadoH
            objPrestamo.cuenta = i.h.cuenta
            lista.Add(objPrestamo)
        Next

        Return lista
    End Function

    Public Function PrestamoSinConfirmarDetalle(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle)
        Dim objMostrar As New documentoPrestamoDetalle
        Dim ListaDetalle As New List(Of documentoPrestamoDetalle)

        Dim consulta = (From p In HeliosData.documentoPrestamoDetalle _
                        Join c In HeliosData.prestamos _
                         On p.idDocumento Equals c.idDocumento _
                      Where p.idDocumento = strDocumentoAfectado _
                      And c.entregaPendiente = "NO").ToList


        For Each obj In consulta
            objMostrar = New documentoPrestamoDetalle
            objMostrar.idDocumento = obj.c.idDocumento
            objMostrar.tipoBeneficiario = obj.c.tipoBeneficiario
            objMostrar.idBeneficiario = obj.c.idBeneficiario
            objMostrar.moneda = obj.c.moneda
            objMostrar.montoprestamo = obj.c.monto
            objMostrar.montoprestamome = obj.c.montoUSD
            objMostrar.numcuotas = obj.c.numCuotas
            objMostrar.modopago = obj.c.modoPago
            objMostrar.fechainicio = obj.c.fechaInicio
            objMostrar.tipo = obj.c.tipo


            objMostrar.idCuota = obj.p.idCuota
            objMostrar.secuencia = obj.p.secuencia
            objMostrar.cuota = obj.p.cuota
            objMostrar.descripcion = obj.p.descripcion
            objMostrar.montoSoles = obj.p.montoSoles
            objMostrar.montoUsd = obj.p.montoUsd
            objMostrar.fechaVencimiento = obj.p.fechaVencimiento
            objMostrar.fechaPlazo = obj.p.fechaPlazo



            ListaDetalle.Add(objMostrar)
        Next
        Return ListaDetalle
    End Function



    Public Function ListadoMontosCuotas(idDoc As Integer) As List(Of documentoPrestamoDetalle)
        Dim lista As New List(Of documentoPrestamoDetalle)
        Dim objPrestamo As New documentoPrestamoDetalle

        Dim consulta = (From n In HeliosData.documentoPrestamoDetalle _
                       Where n.idDocumento = idDoc).ToList


        For Each i In consulta
            objPrestamo = New documentoPrestamoDetalle
            objPrestamo.idDocumento = i.idDocumento
            objPrestamo.idCuota = i.idCuota
            objPrestamo.secuencia = i.secuencia
            objPrestamo.descripcion = i.descripcion
            objPrestamo.montoSoles = i.montoSoles
            objPrestamo.montoUsd = i.montoUsd
            objPrestamo.cuenta = i.cuenta
            objPrestamo.cuentaH = i.cuentaH
            objPrestamo.devengado = i.devengado
            objPrestamo.devengadoH = i.devengadoH


            lista.Add(objPrestamo)
        Next

        Return lista
    End Function





    Public Function PrestamoListadoDetalle(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle)
        Dim objMostrar As New documentoPrestamoDetalle
        Dim ListaDetalle As New List(Of documentoPrestamoDetalle)

        Dim consulta = (From p In HeliosData.documentoPrestamoDetalle _
                        Join c In HeliosData.prestamos _
                         On p.idDocumento Equals c.idDocumento _
                      Where p.idDocumento = strDocumentoAfectado).ToList


        For Each obj In consulta
            objMostrar = New documentoPrestamoDetalle
            objMostrar.idDocumento = obj.c.idDocumento
            objMostrar.tipoBeneficiario = obj.c.tipoBeneficiario
            objMostrar.idBeneficiario = obj.c.idBeneficiario
            objMostrar.moneda = obj.c.moneda
            objMostrar.montoprestamo = obj.c.monto
            objMostrar.montoprestamome = obj.c.montoUSD
            objMostrar.numcuotas = obj.c.numCuotas
            objMostrar.modopago = obj.c.modoPago
            objMostrar.fechainicio = obj.c.fechaInicio
            objMostrar.tipo = obj.c.tipo


            objMostrar.idCuota = obj.p.idCuota
            objMostrar.secuencia = obj.p.secuencia
            objMostrar.cuota = obj.p.cuota
            objMostrar.descripcion = obj.p.descripcion
            objMostrar.montoSoles = obj.p.montoSoles
            objMostrar.montoUsd = obj.p.montoUsd
            objMostrar.fechaVencimiento = obj.p.fechaVencimiento
            objMostrar.fechaPlazo = obj.p.fechaPlazo



            ListaDetalle.Add(objMostrar)
        Next
        Return ListaDetalle
    End Function




    Public Sub InsertPrestamoRecibido(documentoBE As documento, prestamo As prestamos, listaDocumentos As List(Of documentoPrestamos), listaDetalle As List(Of documentoPrestamoDetalle))
        Dim documentoBL As New documentoBL
        Dim AsientoBL As New AsientoBL
        Dim prestamoBL As New prestamosBL


        Using ts As New TransactionScope()

            documentoBL.Insert(documentoBE)
            prestamo.idDocumento = documentoBE.idDocumento
            prestamoBL.SavePrestamoRec(prestamo, documentoBE.idDocumento)

            For Each i In listaDocumentos
                Dim codCuota = Me.InsertProgramado(i, documentoBE.idDocumento)
                For Each detail In listaDetalle
                    If i.referencia = detail.referencia Then
                        Me.InsertDetallePrestamo(detail, documentoBE.idDocumento, codCuota)
                    End If
                Next
            Next
            AsientoBL.SavebyGroupDoc(documentoBE)
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub
    'Public Sub InsertPrestamoRecibido(documentoBE As documento, prestamo As prestamos, listaDocumentos As List(Of documentoPrestamos))
    '    Dim documentoBL As New documentoBL
    '    Dim AsientoBL As New AsientoBL
    '    Dim prestamoBL As New prestamosBL


    '    Using ts As New TransactionScope()
    '        ' If prestamoBL.PrestamoEstadoAprobado(documentoBE.IdDocumentoAfectado) = False Then
    '        documentoBL.Insert(documentoBE)
    '        'Dim prestamo As prestamos = HeliosData.prestamos.Where(Function(o) o.codigo = documentoBE.IdDocumentoAfectado).FirstOrDefault
    '        'prestamo.entregaPendiente = "SI"
    '        'prestamo.idDocumento = documentoBE.idDocumento
    '        prestamo.idDocumento = documentoBE.idDocumento
    '        prestamoBL.Save(prestamo)

    '        'HeliosData.ObjectStateManager.GetObjectStateEntry(prestamo).State.ToString()
    '        For Each i In listaDocumentos
    '            Me.InsertProgramado(i, documentoBE.idDocumento)
    '        Next
    '        AsientoBL.SavebyGroupDoc(documentoBE)
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '        'Else
    '        'Throw New Exception("El prestámo ya fue aprobado!!")
    '        'End If
    '    End Using
    'End Sub





    Public Function ListadoFechasCuotas(idDoc As Integer) As List(Of documentoPrestamos)
        Dim lista As New List(Of documentoPrestamos)
        Dim objPrestamo As New documentoPrestamos

        Dim consulta = (From n In HeliosData.documentoPrestamos _
                       Where n.idDocumento = idDoc).ToList


        For Each i In consulta
            objPrestamo = New documentoPrestamos
            objPrestamo.idDocumento = i.idDocumento
            objPrestamo.idCuota = i.idCuota
            objPrestamo.referencia = i.referencia
            objPrestamo.fechaVcto = i.fechaVcto
            objPrestamo.fechaPlazo = i.fechaPlazo

            lista.Add(objPrestamo)
        Next

        Return lista
    End Function



    Public Sub UpdateFechaDesembolso(documentoBE As prestamos, listaDocumentos As List(Of documentoPrestamos))
        Dim prestamoBL As New prestamosBL

        prestamoBL.UpdateFechaPrestamo(documentoBE)

        Using ts As New TransactionScope()
            For Each i In listaDocumentos

                Dim docPrestamos As documentoPrestamos = HeliosData.documentoPrestamos.Where(Function(o) _
                                            o.idDocumento = i.idDocumento _
                                            And o.idCuota = i.idCuota).First()
                docPrestamos.fechaVcto = i.fechaVcto
                docPrestamos.fechaPlazo = i.fechaPlazo

                Me.UpdateFechaDesembolsoDetalle(i.idDocumento, i.idCuota, i.fechaVcto, i.fechaPlazo)
            Next
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub

    Public Sub UpdateFechaDesembolsoDetalle(iddocumento As Integer, idcuota As Integer, fechaven As Date, fechaplazo As Date)
        Dim prestamoBL As New prestamosBL

        Dim consulta = HeliosData.documentoPrestamoDetalle.Where(Function(o) _
                                                             o.idDocumento = iddocumento _
                                                                And o.idCuota = idcuota).ToList
        Using ts As New TransactionScope()
            For Each i In consulta

                Dim docPrestamoDetalle As documentoPrestamoDetalle = HeliosData.documentoPrestamoDetalle.Where(Function(o) _
                                                                                                                      o.idDocumento = i.idDocumento _
                                                                                                      And o.idCuota = i.idCuota And o.secuencia = i.secuencia).First()
                docPrestamoDetalle.fechaVencimiento = fechaven
                docPrestamoDetalle.fechaPlazo = fechaplazo

            Next
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub



    '    Public Function ListadoPrestamosPendientes(strEmpresa As String, intIdEstablecimiento As Integer, intIdBeneficiario As Integer, strPeriodo As String, strTipoMovimiento As String) As List(Of documentoPrestamos)
    '        Dim lista As New List(Of documentoPrestamos)
    '        Dim objPrestamo As New documentoPrestamos

    '        Dim consulta = (From n In HeliosData.prestamos _
    '                       Join docpres In HeliosData.documentoPrestamos _
    '                       On n.idDocumento Equals docpres.idDocumento _
    '                       Join EF In HeliosData.estadosFinancieros _
    '                       On docpres.entidadFinanciera Equals EF.idestado _
    '                       Where docpres.idEmpresa = strEmpresa And _
    '                       docpres.idEstablecimiento = intIdEstablecimiento _
    '                       And docpres.idBeneficiario = intIdBeneficiario And _
    '                       docpres.tipoMovimiento = strTipoMovimiento And _
    '                       n.periodo = strPeriodo).ToList


    '        For Each i In consulta
    '            objPrestamo = New documentoPrestamos
    '            objPrestamo.idDocumento = i.docpres.idDocumento
    '            objPrestamo.idCuota = i.docpres.idCuota

    '            objPrestamo.TipoDocPrestamo = "VOUCHER DE CAJA, " & i.n.nroDoc
    '            objPrestamo.NroPrestamo = i.n.nroDoc
    '            objPrestamo.fecha = i.n.fechaPrestamo

    '            objPrestamo.moneda = i.n.moneda
    '            objPrestamo.tipoCambio = i.n.tipoCambio
    '            objPrestamo.CapitalMN = i.n.monto
    '            objPrestamo.CapitalME = i.n.montoUSD
    '            objPrestamo.CapitalIMN = i.n.montoInteresSoles
    '            objPrestamo.CapitalIME = i.n.montoInteresUSD


    '            '------------------------------------------------------
    '            objPrestamo.fechaVcto = i.docpres.fechaVcto
    '            objPrestamo.numeroDocumento = i.docpres.numeroDocumento
    '            objPrestamo.referencia = i.docpres.referencia

    '            objPrestamo.montoSoles = i.docpres.montoSoles
    '            objPrestamo.montoDolares = i.docpres.montoDolares


    '            '--------------PAGOS/COBROS-----------------------------------
    '            Dim xCobrado = Aggregate x In HeliosData.documentoCajaDetalle _
    '                        Where x.documentoAfectado = i.docpres.idDocumento _
    '                        And x.entregado = "C" And x.idItem = i.docpres.idCuota _
    '        Into nc = Sum(x.montoSoles), _
    '             nce = Sum(x.montoUsd)


    '            objPrestamo.ImportePagoCapitalMN = xCobrado.nc.GetValueOrDefault
    '            objPrestamo.ImportePagoCapitalME = xCobrado.nce.GetValueOrDefault

    '            Dim xCobrado2 = Aggregate x In HeliosData.documentoCajaDetalle _
    '           Where x.documentoAfectado = i.docpres.idDocumento _
    '           And x.entregado = "I" And x.idItem = i.docpres.idCuota _
    'Into nc = Sum(x.montoSoles), _
    'nce = Sum(x.montoUsd)

    '            objPrestamo.ImportePagoInteresMN = xCobrado2.nc.GetValueOrDefault
    '            objPrestamo.ImportePagoInteresME = xCobrado2.nce.GetValueOrDefault

    '            'Dim saldo As Decimal = i.docpres.montoSoles - xCobrado.nc.GetValueOrDefault
    '            'If saldo <= 0 Then
    '            '    objPrestamo.InfoCuota = "Cuota cancelada"
    '            'Else
    '            '    objPrestamo.InfoCuota = "Cuota pendiente"
    '            'End If
    '            lista.Add(objPrestamo)
    '        Next

    '        Return lista
    '    End Function



    Public Sub InsertPrestamoOtorgado(documentoBE As documento, listaDocumentos As List(Of documentoPrestamos), listaDetalle As List(Of documentoPrestamoDetalle))
        Dim documentoBL As New documentoBL
        Dim AsientoBL As New AsientoBL
        Dim prestamoBL As New prestamosBL

        Using ts As New TransactionScope()
            If prestamoBL.PrestamoEstadoAprobado(documentoBE.IdDocumentoAfectado) = False Then
                documentoBL.Insert(documentoBE)

                For Each i In listaDocumentos
                    Dim codCuota = Me.InsertProgramado(i, documentoBE.idDocumento)
                    For Each detail In listaDetalle
                        If i.referencia = detail.referencia Then
                            Me.InsertDetallePrestamo(detail, documentoBE.idDocumento, codCuota)
                        End If
                    Next
                Next

                AsientoBL.SavebyGroupDoc(documentoBE)

                Dim prestamo As prestamos = HeliosData.prestamos.Where(Function(o) o.codigo = documentoBE.IdDocumentoAfectado).FirstOrDefault
                prestamo.entregaPendiente = "SI"
                prestamo.idDocumento = documentoBE.idDocumento


                HeliosData.SaveChanges()
                ts.Complete()
            Else
                Throw New Exception("El prestámo ya fue aprobado!!")
            End If
        End Using
    End Sub



    Public Function InsertDetallePrestamo(ByVal documentoPrestamosBE As documentoPrestamoDetalle, intIdDocumento As Integer, intCuota As Integer) As Integer
        Dim docPrestamo As New documentoPrestamoDetalle
        Dim numeracionBL As New numeracionBoletasBL

        Using ts As New TransactionScope
            With docPrestamo

                .idDocumento = intIdDocumento
                .idCuota = intCuota
                .descripcion = documentoPrestamosBE.descripcion
                .montoSoles = documentoPrestamosBE.montoSoles
                .montoUsd = documentoPrestamosBE.montoUsd
                .estadoPago = documentoPrestamosBE.estadoPago
                .cuota = documentoPrestamosBE.cuota
                .fechaVencimiento = documentoPrestamosBE.fechaVencimiento
                .fechaPlazo = documentoPrestamosBE.fechaPlazo
                .cuenta = documentoPrestamosBE.cuenta
                .tieneCosto = documentoPrestamosBE.tieneCosto
                .cuentaH = documentoPrestamosBE.cuentaH
                .devengado = documentoPrestamosBE.devengado
                .devengadoH = documentoPrestamosBE.devengadoH

            End With

            HeliosData.documentoPrestamoDetalle.Add(docPrestamo)
            HeliosData.SaveChanges()
            ts.Complete()

            Return documentoPrestamosBE.idCuota
        End Using
    End Function


    Public Function Insert(ByVal documentoPrestamosBE As documentoPrestamos) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoPrestamos.Add(documentoPrestamosBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoPrestamosBE.idCuota
        End Using
    End Function


    Public Function InsertProgramado(ByVal documentoPrestamosBE As documentoPrestamos, intIdDocumento As Integer) As Integer
        Dim docPrestamo As New documentoPrestamos
        Dim numeracionBL As New numeracionBoletasBL
        ' Dim cval As Integer
        Using ts As New TransactionScope
            docPrestamo = New documentoPrestamos

            docPrestamo.idDocumento = intIdDocumento
            docPrestamo.idEmpresa = documentoPrestamosBE.idEmpresa
            docPrestamo.idEstablecimiento = documentoPrestamosBE.idEstablecimiento
            docPrestamo.cuentaContable = documentoPrestamosBE.cuentaContable
            docPrestamo.tipoMovimiento = documentoPrestamosBE.tipoMovimiento

            'If documentoPrestamosBE.tipoMovimiento = "PO" Then
            docPrestamo.tipoBeneficiario = documentoPrestamosBE.tipoBeneficiario
            docPrestamo.idBeneficiario = documentoPrestamosBE.idBeneficiario
            'End If



            'docPrestamo.tipoDocumento = documentoPrestamosBE.tipoDocumento
            'cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentoPrestamosBE.IdNumeracion))

            'docPrestamo.numeroDocumento = cval ' documentoPrestamosBE.numeroDocumento



            docPrestamo.fecha = documentoPrestamosBE.fecha
            docPrestamo.fechaVcto = documentoPrestamosBE.fechaVcto
            docPrestamo.referencia = documentoPrestamosBE.referencia
            docPrestamo.fechaPlazo = documentoPrestamosBE.fechaPlazo
            'docPrestamo.entidadFinanciera = documentoPrestamosBE.entidadFinanciera
            'docPrestamo.numeroOperacion = documentoPrestamosBE.numeroOperacion
            docPrestamo.moneda = documentoPrestamosBE.moneda

            docPrestamo.tipoCambio = documentoPrestamosBE.tipoCambio
            docPrestamo.montoSoles = documentoPrestamosBE.montoSoles
            docPrestamo.montoDolares = documentoPrestamosBE.montoDolares
            'docPrestamo.montoInteresSoles = documentoPrestamosBE.montoInteresSoles
            'docPrestamo.montoInteresUSD = documentoPrestamosBE.montoInteresUSD
            docPrestamo.entregado = documentoPrestamosBE.entregado
            'docPrestamo.modulo = documentoPrestamosBE.modulo
            docPrestamo.usuarioActualizacion = documentoPrestamosBE.usuarioActualizacion
            docPrestamo.fechaActualizacion = documentoPrestamosBE.fechaActualizacion

            ''''''''''
            'docPrestamo.seguro = documentoPrestamosBE.seguro
            'docPrestamo.portes = documentoPrestamosBE.portes
            'docPrestamo.envCuenta = documentoPrestamosBE.envCuenta


            'docPrestamo.montoSeguro = documentoPrestamosBE.montoSeguro
            'docPrestamo.montoSeguroME = documentoPrestamosBE.montoSeguroME
            'docPrestamo.montoPortes = documentoPrestamosBE.montoPortes
            'docPrestamo.montoPortesME = documentoPrestamosBE.montoPortesME
            'docPrestamo.montoOtro = documentoPrestamosBE.montoOtro
            'docPrestamo.montoOtroME = documentoPrestamosBE.montoOtroME
            'docPrestamo.montoEnvCuenta = documentoPrestamosBE.montoEnvCuenta
            'docPrestamo.montoEnvCuentaME = documentoPrestamosBE.montoEnvCuentaME


            'docPrestamo.intMoratorio = documentoPrestamosBE.intMoratorio
            'docPrestamo.IntCompensatorio = documentoPrestamosBE.IntCompensatorio
            'docPrestamo.otros = documentoPrestamosBE.otros
            'docPrestamo.otros1 = documentoPrestamosBE.otros1
            'docPrestamo.fechaPlazo = documentoPrestamosBE.fechaPlazo


            'docPrestamo.intMoratorio = documentoPrestamosBE.intMoratorio
            'docPrestamo.intMoratorioME = documentoPrestamosBE.intMoratorioME
            'docPrestamo.IntCompensatorio = documentoPrestamosBE.IntCompensatorio
            'docPrestamo.IntCompensatorioME = documentoPrestamosBE.IntCompensatorioME
            'docPrestamo.otros = documentoPrestamosBE.otros
            'docPrestamo.otrosME = documentoPrestamosBE.otrosME
            'docPrestamo.otros1 = documentoPrestamosBE.otros1
            'docPrestamo.otros1ME = documentoPrestamosBE.otros1ME

            docPrestamo.estadoPago = documentoPrestamosBE.estadoPago
            ''''''''''''''



            'End With

            HeliosData.documentoPrestamos.Add(docPrestamo)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoPrestamosBE.idCuota = docPrestamo.idCuota
            Return documentoPrestamosBE.idCuota
        End Using
    End Function

    'Public Function InsertProgramado(ByVal documentoPrestamosBE As documentoPrestamos, intIdDocumento As Integer) As Integer
    '    Dim docPrestamo As New documentoPrestamos
    '    Dim numeracionBL As New numeracionBoletasBL
    '    Dim cval As Integer
    '    Using ts As New TransactionScope
    '        docPrestamo = New documentoPrestamos

    '        docPrestamo.idDocumento = intIdDocumento
    '        docPrestamo.idEmpresa = documentoPrestamosBE.idEmpresa
    '        docPrestamo.idEstablecimiento = documentoPrestamosBE.idEstablecimiento
    '        docPrestamo.cuentaContable = documentoPrestamosBE.cuentaContable
    '        docPrestamo.tipoMovimiento = documentoPrestamosBE.tipoMovimiento
    '        docPrestamo.tieneCosto = documentoPrestamosBE.tieneCosto
    '        'If documentoPrestamosBE.tipoMovimiento = "PO" Then
    '        docPrestamo.tipoBeneficiario = documentoPrestamosBE.tipoBeneficiario
    '        docPrestamo.idBeneficiario = documentoPrestamosBE.idBeneficiario
    '        'End If

    '        docPrestamo.tipoDocumento = documentoPrestamosBE.tipoDocumento
    '        cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentoPrestamosBE.IdNumeracion))

    '        docPrestamo.numeroDocumento = cval ' documentoPrestamosBE.numeroDocumento
    '        docPrestamo.fecha = documentoPrestamosBE.fecha
    '        docPrestamo.fechaVcto = documentoPrestamosBE.fechaVcto
    '        docPrestamo.referencia = documentoPrestamosBE.referencia
    '        'docPrestamo.entidadFinanciera = documentoPrestamosBE.entidadFinanciera
    '        'docPrestamo.numeroOperacion = documentoPrestamosBE.numeroOperacion
    '        docPrestamo.moneda = documentoPrestamosBE.moneda
    '        docPrestamo.interes = documentoPrestamosBE.interes
    '        docPrestamo.tipoCambio = documentoPrestamosBE.tipoCambio
    '        docPrestamo.montoSoles = documentoPrestamosBE.montoSoles
    '        docPrestamo.montoDolares = documentoPrestamosBE.montoDolares
    '        docPrestamo.montoInteresSoles = documentoPrestamosBE.montoInteresSoles
    '        docPrestamo.montoInteresUSD = documentoPrestamosBE.montoInteresUSD
    '        docPrestamo.entregado = documentoPrestamosBE.entregado
    '        docPrestamo.modulo = documentoPrestamosBE.modulo
    '        docPrestamo.usuarioActualizacion = documentoPrestamosBE.usuarioActualizacion
    '        docPrestamo.fechaActualizacion = documentoPrestamosBE.fechaActualizacion

    '        ''''''''''
    '        docPrestamo.seguro = documentoPrestamosBE.seguro
    '        docPrestamo.portes = documentoPrestamosBE.portes
    '        docPrestamo.envCuenta = documentoPrestamosBE.envCuenta


    '        docPrestamo.montoSeguro = documentoPrestamosBE.montoSeguro
    '        docPrestamo.montoSeguroME = documentoPrestamosBE.montoSeguroME
    '        docPrestamo.montoPortes = documentoPrestamosBE.montoPortes
    '        docPrestamo.montoPortesME = documentoPrestamosBE.montoPortesME
    '        docPrestamo.montoOtro = documentoPrestamosBE.montoOtro
    '        docPrestamo.montoOtroME = documentoPrestamosBE.montoOtroME
    '        docPrestamo.montoEnvCuenta = documentoPrestamosBE.montoEnvCuenta
    '        docPrestamo.montoEnvCuentaME = documentoPrestamosBE.montoEnvCuentaME


    '        docPrestamo.intMoratorio = documentoPrestamosBE.intMoratorio
    '        docPrestamo.IntCompensatorio = documentoPrestamosBE.IntCompensatorio
    '        docPrestamo.otros = documentoPrestamosBE.otros
    '        docPrestamo.otros1 = documentoPrestamosBE.otros1
    '        docPrestamo.fechaPlazo = documentoPrestamosBE.fechaPlazo


    '        docPrestamo.intMoratorio = documentoPrestamosBE.intMoratorio
    '        docPrestamo.intMoratorioME = documentoPrestamosBE.intMoratorioME
    '        docPrestamo.IntCompensatorio = documentoPrestamosBE.IntCompensatorio
    '        docPrestamo.IntCompensatorioME = documentoPrestamosBE.IntCompensatorioME
    '        docPrestamo.otros = documentoPrestamosBE.otros
    '        docPrestamo.otrosME = documentoPrestamosBE.otrosME
    '        docPrestamo.otros1 = documentoPrestamosBE.otros1
    '        docPrestamo.otros1ME = documentoPrestamosBE.otros1ME

    '        docPrestamo.estadoPago = documentoPrestamosBE.estadoPago
    '        ''''''''''''''



    '        'End With

    '        HeliosData.documentoPrestamos.Add(docPrestamo)
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '        documentoPrestamosBE.idCuota = docPrestamo.idCuota
    '        Return documentoPrestamosBE.idCuota
    '    End Using
    'End Function

    'Public Function SavePrestamo(objPrestamo As prestamos, objDocumento As documento) As Integer
    '    Dim prestamoBL As New prestamosBL
    '    Dim DocumentoBL As New documentoBL
    '    Using ts As New TransactionScope
    '        prestamoBL.Save(objPrestamo)
    '        DocumentoBL.Insert(objDocumento)
    '        '    Me.Insert (objDocumento.documentocompra, objDocumento.idDocumento)
    '    End Using
    'End Function


    Public Sub Update(ByVal documentoPrestamosBE As documentoPrestamos)
        Using ts As New TransactionScope
            Dim docPrestamos As documentoPrestamos = HeliosData.documentoPrestamos.Where(Function(o) _
                                            o.idDocumento = documentoPrestamosBE.idDocumento _
                                            And o.idCuota = documentoPrestamosBE.idCuota).First()

            docPrestamos.idEmpresa = documentoPrestamosBE.idEmpresa
            docPrestamos.idEstablecimiento = documentoPrestamosBE.idEstablecimiento
            docPrestamos.cuentaContable = documentoPrestamosBE.cuentaContable
            docPrestamos.tipoMovimiento = documentoPrestamosBE.tipoMovimiento
            docPrestamos.tipoBeneficiario = documentoPrestamosBE.tipoBeneficiario
            docPrestamos.idBeneficiario = documentoPrestamosBE.idBeneficiario
            'docPrestamos.tipoDocumento = documentoPrestamosBE.tipoDocumento
            'docPrestamos.numeroDocumento = documentoPrestamosBE.numeroDocumento
            docPrestamos.fecha = documentoPrestamosBE.fecha
            docPrestamos.referencia = documentoPrestamosBE.referencia
            'docPrestamos.entidadFinanciera = documentoPrestamosBE.entidadFinanciera
            'docPrestamos.numeroOperacion = documentoPrestamosBE.numeroOperacion
            docPrestamos.moneda = documentoPrestamosBE.moneda
            'docPrestamos.interes = documentoPrestamosBE.interes
            docPrestamos.tipoCambio = documentoPrestamosBE.tipoCambio
            docPrestamos.montoSoles = documentoPrestamosBE.montoSoles
            docPrestamos.montoDolares = documentoPrestamosBE.montoDolares
            'docPrestamos.montoInteresSoles = documentoPrestamosBE.montoInteresSoles
            'docPrestamos.montoInteresUSD = documentoPrestamosBE.montoInteresUSD
            docPrestamos.entregado = documentoPrestamosBE.entregado
            ' docPrestamos.modulo = documentoPrestamosBE.modulo
            docPrestamos.usuarioActualizacion = documentoPrestamosBE.usuarioActualizacion
            docPrestamos.fechaActualizacion = documentoPrestamosBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docPrestamos).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoPrestamosBE As documentoPrestamos)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoPrestamosBE)
    End Sub

    Public Function GetListar_documentoPrestamos() As List(Of documentoPrestamos)
        Return (From a In HeliosData.documentoPrestamos Select a).ToList
    End Function

    Public Function GetUbicar_documentoPrestamosPorID(idCuota As Integer) As documentoPrestamos
        Return (From a In HeliosData.documentoPrestamos
                 Where a.idCuota = idCuota Select a).First
    End Function
End Class

Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity.DbFunctions
Public Class documentoCajaBL
    Inherits BaseBL



    Public Sub ConfirmacionDineroBancario(be As List(Of documentoCaja))

        Try

            Using ts As New TransactionScope


                For Each i In be

                    Dim prod = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = i.idDocumento).Single

                    prod.entidadFinancieraDestino = i.entidadFinancieraDestino
                    prod.idCajaUsuarioDestino = i.idCajaUsuarioDestino
                    prod.tipoEntidadFinanciera = i.tipoEntidadFinanciera
                    prod.fechaProcesoDestino = DateTime.Now

                    Dim periodoActual = DateTime.Now
                    prod.periodo = GetPeriodo(periodoActual, True)


                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End Using


        Catch ex As Exception

        End Try

    End Sub




    Public Sub ConfirmarEntregaDeDinero(idCierre As Integer, be As cajaUsuario, bl As List(Of estadosFinancierosConfiguracionPagos), userTransc As documentoCaja)

        Try
            'Using ts As New TransactionScope
            Dim cajausuariosa As New CajaUsuarioBL


            Dim Query = (From i In HeliosData.documentoCaja
                         Where i.idCajaUsuario = be.idcajaUsuario).ToList


            cajausuariosa.ConfirmarEntregaDinero(be.idcajaUsuario, idCierre)


            If Query.Count > 0 Then
                EntregaDeDinero(Query, bl, userTransc)
            End If
            'End Using
        Catch ex As Exception

        End Try
    End Sub


    Public Sub EntregaDeDinero(be As List(Of documentoCaja), bl As List(Of estadosFinancierosConfiguracionPagos), userTransc As documentoCaja)
        Try


            Dim idCajaUsd = (From i In bl Where i.moneda = "2" And i.tipoCaja = "EF").FirstOrDefault
            Dim idCajaPen = (From i In bl Where i.moneda = "1" And i.tipoCaja = "EF").FirstOrDefault



            Using ts As New TransactionScope


                For Each i In be

                    If i.tipoEntidadFinanciera Is Nothing Then
                        If i.moneda = "1" Then
                            Dim prod = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = i.idDocumento).Single
                            prod.entidadFinancieraDestino = idCajaPen.identidad
                            prod.idCajaUsuarioDestino = idCajaPen.IDCaja
                            prod.tipoEntidadFinanciera = idCajaPen.tipoCaja
                            prod.fechaProcesoDestino = DateTime.Now

                            prod.idRol = userTransc.idRol
                            prod.IdUsuarioTransaccion = userTransc.IdUsuarioTransaccion

                            Dim periodoActual = DateTime.Now
                            prod.periodo = GetPeriodo(periodoActual, True)
                        ElseIf i.moneda = "2" Then
                            Dim prod = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = i.idDocumento).Single
                            prod.entidadFinancieraDestino = idCajaUsd.identidad
                            prod.idCajaUsuarioDestino = idCajaPen.IDCaja
                            prod.tipoEntidadFinanciera = idCajaPen.tipoCaja
                            prod.fechaProcesoDestino = DateTime.Now

                            prod.idRol = userTransc.idRol
                            prod.IdUsuarioTransaccion = userTransc.IdUsuarioTransaccion

                        End If
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub PagoCompensacionVentas(objDocumento As documento)

        Dim anticipoBL As New DocumentoAnticipoConciliacionBL
        Dim docAnticipoBL As New documentoAnticipoBL

        Using ts As New TransactionScope
            If Not IsNothing(objDocumento) Then

                Dim venta = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = objDocumento.idDocumento).SingleOrDefault

                venta.estadoCobro = objDocumento.documentoventaAbarrotes.estadoCobro


                If objDocumento.ListaDetalleAnticipos IsNot Nothing Then


                    If objDocumento.ListaDetalleAnticipos.Count > 0 Then

                        For Each i In objDocumento.ListaDetalleAnticipos
                            i.idDocumentoPadre = venta.idDocumento
                            'i.docAfectado = codDocumentoVenta
                            anticipoBL.Insert(i)

                            Dim ant = docAnticipoBL.GetANTReclamacionesXDocumento(New documentoventaAbarrotes With {.idDocumento = i.idDocumento})
                            Dim Docanticipo = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = i.idDocumento).Single
                            If ant.SaldoReclamacion <= 0 Then
                                Docanticipo.estadoCobro = General.Anticipo.EstadoCobroNotaCredito.Completado
                            Else
                                If ant.TotalNotas.GetValueOrDefault > 0 Then
                                    Docanticipo.estadoCobro = General.Anticipo.EstadoCobroNotaCredito.Parcial
                                Else
                                    Docanticipo.estadoCobro = General.Anticipo.EstadoCobroNotaCredito.Pendiente
                                End If
                            End If

                        Next
                    End If
                End If


            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub PagoCompensacionCompras(objDocumento As documento)

        Dim anticipoBL As New DocumentoAnticipoConciliacionCompraBL
        Dim docAnticipoBL As New documentoAnticipoBL

        Using ts As New TransactionScope
            If Not IsNothing(objDocumento) Then

                Dim venta = HeliosData.documentocompra.Where(Function(o) o.idDocumento = objDocumento.idDocumento).SingleOrDefault

                venta.estadoPago = objDocumento.documentocompra.estadoPago


                If objDocumento.ListaDetalleAnticiposCompra IsNot Nothing Then


                    If objDocumento.ListaDetalleAnticiposCompra.Count > 0 Then

                        For Each i In objDocumento.ListaDetalleAnticiposCompra
                            i.idDocumentoPadre = venta.idDocumento
                            'i.docAfectado = codDocumentoVenta
                            anticipoBL.Insert(i)

                            Dim ant = docAnticipoBL.GetANTReclamacionesXDocumentoCompra(New documentocompra With {.idDocumento = i.idDocumento})
                            Dim Docanticipo = HeliosData.documentocompra.Where(Function(o) o.idDocumento = i.idDocumento).Single
                            If ant.SaldoReclamacion <= 0 Then
                                Docanticipo.estadoPago = General.Anticipo.EstadoCobroNotaCredito.Completado
                            Else
                                If ant.TotalNotas.GetValueOrDefault > 0 Then
                                    Docanticipo.estadoPago = General.Anticipo.EstadoCobroNotaCredito.Parcial
                                Else
                                    Docanticipo.estadoPago = General.Anticipo.EstadoCobroNotaCredito.Pendiente
                                End If
                            End If

                        Next
                    End If
                End If


            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub ConfirmarPagoTarjeta(idDoc As Integer, fecha As DateTime)
        Using ts As New TransactionScope()
            Dim consulta = (From i In HeliosData.documentoCaja
                            Where i.idDocumento = idDoc).FirstOrDefault

            consulta.estadopago = 2
            consulta.fechaCobro = fecha

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetPagosTarjetaxConfirmar(be As documentoCaja) As List(Of documentoCaja)
        Dim doccompra As New documentoCaja
        Dim lista As New List(Of documentoCaja)



        Dim consulta = (From caja In HeliosData.documentoCaja
                        Join cli In HeliosData.entidad On cli.idEntidad Equals caja.codigoProveedor
                        Where caja.formapago = "006" And caja.estadopago = 1 And
                       caja.fechaProceso.Value.Year = be.fechaProceso.Value.Year And
                        caja.fechaProceso.Value.Month = be.fechaProceso.Value.Month And
                       caja.tipoMovimiento = "DC" And caja.idEmpresa = be.idEmpresa).ToList

        For Each i In consulta
            doccompra = New documentoCaja
            doccompra.idDocumento = i.caja.idDocumento
            doccompra.IdProveedor = i.caja.codigoProveedor
            doccompra.NombreEntidad = i.cli.nombreCompleto
            doccompra.tipo = i.cli.tipoEntidad
            doccompra.NumeroDocumento = i.cli.nrodoc
            doccompra.formapago = i.caja.formapago
            doccompra.tipoDocPago = i.caja.tipoDocPago
            doccompra.numeroDoc = i.caja.numeroDoc
            doccompra.fechaProceso = i.caja.fechaProceso
            doccompra.fechaCobro = i.caja.fechaCobro
            doccompra.moneda = i.caja.moneda
            doccompra.tipoOperacion = i.caja.tipoOperacion
            doccompra.montoSoles = i.caja.montoSoles
            doccompra.movimientoCaja = i.caja.movimientoCaja
            doccompra.numeroOperacion = i.caja.numeroOperacion



            lista.Add(doccompra)
        Next


        Return lista
    End Function

    Public Sub PagoDocCompras(objDocumento As documento)
        Dim anticipoBL As New DocumentoAnticipoConciliacionCompraBL
        Dim docAnticipoBL As New documentoAnticipoBL

        Using ts As New TransactionScope
            If Not IsNothing(objDocumento.ListaCustomDocumento) Then

                Dim compra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = objDocumento.idDocumento).FirstOrDefault

                compra.estadoPago = objDocumento.documentocompra.estadoPago

                For Each i In objDocumento.ListaCustomDocumento

                    If compra.monedaDoc = "1" Then
                        Dim saldo = SaldoCajaOnline(i.documentoCaja)
                        If i.documentoCaja.montoSoles <= saldo Then
                            SaveCajaCompra(i, objDocumento.idDocumento, Nothing)
                        Else
                            Throw New Exception("No hay Saldo suficiente")
                        End If
                    Else
                        Dim saldo = SaldoCajaME(i.documentoCaja)
                        If i.documentoCaja.montoUsd <= saldo Then
                            SaveCajaCompra(i, objDocumento.idDocumento, Nothing)
                        Else
                            Throw New Exception("No hay Saldo suficiente")
                        End If
                    End If
                Next


                If objDocumento.ListaDetalleAnticiposCompra IsNot Nothing Then
                    If objDocumento.ListaDetalleAnticiposCompra.Count > 0 Then
                        For Each i In objDocumento.ListaDetalleAnticiposCompra
                            i.idDocumentoPadre = compra.idDocumento
                            'i.docAfectado = codDocumentoVenta
                            i.numero = 1
                            anticipoBL.Insert(i)

                            Dim ant = docAnticipoBL.GetANTReclamacionesXDocumentoCompra(New documentocompra With {.idDocumento = i.idDocumento})
                            Dim Docanticipo = HeliosData.documentocompra.Where(Function(o) o.idDocumento = i.idDocumento).Single
                            If ant.SaldoReclamacion <= 0 Then
                                Docanticipo.estadoPago = General.Anticipo.EstadoCobroNotaCredito.Completado
                            Else
                                If ant.TotalNotas.GetValueOrDefault > 0 Then
                                    Docanticipo.estadoPago = General.Anticipo.EstadoCobroNotaCredito.Parcial
                                Else
                                    Docanticipo.estadoPago = General.Anticipo.EstadoCobroNotaCredito.Pendiente
                                End If
                            End If

                        Next
                    End If
                End If

            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function SaldoCajaOnlineAdmi(caja As documentoCaja) As Decimal

        Dim fechaActual = New Date(caja.fechaProceso.Value.Year, caja.fechaProceso.Value.Month, caja.fechaProceso.Value.Day) '1)
        Dim fechaAnterior = fechaActual.AddMonths(-1)

        Dim periodo = String.Format("{0:00}", caja.fechaProceso.Value.Month) & "/" & caja.fechaProceso.Value.Year

        Dim saldoCaja = (From i In HeliosData.estadosFinancieros
                         Where i.idestado = caja.entidadFinancieraDestino
                         Select
                                SaldoAnterior = (From DocumentoCaja In HeliosData.cierreCaja
                                                 Where
                                            DocumentoCaja.idEntidadFinanciera = i.idestado And
                                            DocumentoCaja.periodo = periodo
                                                 Select DocumentoCaja.montoMN).FirstOrDefault,
                           cobros = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinanciera = i.idestado And
                                         DocumentoCaja.tipoMovimiento = "DC" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                            pagos = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinanciera = i.idestado And
                                         DocumentoCaja.tipoMovimiento = "PG" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?))
                            ).FirstOrDefault



        Dim saldo = saldoCaja.SaldoAnterior.GetValueOrDefault + saldoCaja.cobros.GetValueOrDefault - saldoCaja.pagos.GetValueOrDefault

        Return saldo
    End Function

    Public Function SaldoCajaOnline(caja As documentoCaja) As Decimal

        Dim fechaActual = New Date(caja.fechaProceso.Value.Year, caja.fechaProceso.Value.Month, caja.fechaProceso.Value.Day) '1)
        Dim fechaAnterior = fechaActual.AddMonths(-1)
        Dim saldo As Decimal = 0.0
        Dim periodo = String.Format("{0:00}", caja.fechaProceso.Value.Month) & "/" & caja.fechaProceso.Value.Year

        If caja.tipoEntidadFinanciera = "EP" Then
            Dim saldoCaja = (From i In HeliosData.estadosFinancieros
                             Where i.idestado = caja.entidadFinanciera
                             Select
                                SaldoAnterior = (From DocumentoCaja In HeliosData.cierreCaja
                                                 Where
                                            DocumentoCaja.idEntidadFinanciera = i.idestado And
                                            DocumentoCaja.periodo = periodo
                                                 Select DocumentoCaja.montoMN).FirstOrDefault,
                           cobros = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinancieraDestino = i.idestado And
                                         DocumentoCaja.tipoMovimiento = "DC" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                            pagos = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinancieraDestino = i.idestado And
                                         DocumentoCaja.tipoMovimiento = "PG" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?))
                            ).FirstOrDefault

            saldo = saldoCaja.SaldoAnterior.GetValueOrDefault + saldoCaja.cobros.GetValueOrDefault - saldoCaja.pagos.GetValueOrDefault


        Else
            Dim saldoCaja = (From i In HeliosData.estadosFinancieros
                             Where i.idestado = caja.entidadFinancieraDestino
                             Select
                                SaldoAnterior = (From DocumentoCaja In HeliosData.cierreCaja
                                                 Where
                                            DocumentoCaja.idEntidadFinanciera = i.idestado And
                                            DocumentoCaja.periodo = periodo
                                                 Select DocumentoCaja.montoMN).FirstOrDefault,
                           cobros = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinancieraDestino = i.idestado And
                                         DocumentoCaja.tipoMovimiento = "DC" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                            pagos = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinancieraDestino = i.idestado And
                                         DocumentoCaja.tipoMovimiento = "PG" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?))
                            ).FirstOrDefault

            saldo = saldoCaja.SaldoAnterior.GetValueOrDefault + saldoCaja.cobros.GetValueOrDefault - saldoCaja.pagos.GetValueOrDefault


        End If

        Return saldo
    End Function

    Public Function SaldoCajaME(caja As documentoCaja) As Decimal

        Dim fechaActual = New Date(caja.fechaProceso.Value.Year, caja.fechaProceso.Value.Month, caja.fechaProceso.Value.Day) '1)
        Dim fechaAnterior = fechaActual.AddMonths(-1)

        Dim periodo = String.Format("{0:00}", caja.fechaProceso.Value.Month) & "/" & caja.fechaProceso.Value.Year

        Dim saldoCaja = (From i In HeliosData.estadosFinancieros
                         Where i.idestado = caja.entidadFinanciera
                         Select
                                SaldoAnterior = (From DocumentoCaja In HeliosData.cierreCaja
                                                 Where
                                            DocumentoCaja.idEntidadFinanciera = i.idestado And
                                            DocumentoCaja.periodo = periodo
                                                 Select DocumentoCaja.montoME).FirstOrDefault,
                           cobros = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinanciera = i.idestado And
                                         DocumentoCaja.tipoMovimiento = "DC" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoUsd
                                         }) Into Sum(t1.montoUsd)), Decimal?)),
                            pagos = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinanciera = i.idestado And
                                         DocumentoCaja.tipoMovimiento = "PG" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoUsd
                                         }) Into Sum(t1.montoUsd)), Decimal?))
                            ).FirstOrDefault



        Dim saldo = saldoCaja.SaldoAnterior.GetValueOrDefault + saldoCaja.cobros.GetValueOrDefault - saldoCaja.pagos.GetValueOrDefault

        Return saldo
    End Function

    Public Sub PagoDocVentas(objDocumento As documento)

        Dim cronogramaBL As New CronogramaBL
        Using ts As New TransactionScope
            If Not IsNothing(objDocumento.ListaCustomDocumento) Then
                Dim codigoReferencia = objDocumento.IdDocumentoAfectado

                Dim venta = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = objDocumento.idDocumento).SingleOrDefault

                venta.estadoCobro = objDocumento.documentoventaAbarrotes.estadoCobro

                For Each i In objDocumento.ListaCustomDocumento
                    SaveCajaCompra(i, objDocumento.idDocumento, Nothing)
                Next

                Dim TieneCronograma = HeliosData.Cronograma.Any(Function(o) o.idDocumentoRef = codigoReferencia)

                If TieneCronograma Then
                    'Validacion de Pagos
                    Dim listaCronogramas = (From n In objDocumento.ListaCustomDocumento
                                            Select n.documentoCaja.idcosto).Distinct.ToList


                    For Each cro In listaCronogramas
                        cronogramaBL.ActualizarCronogramaCuota(cro)
                    Next

                End If
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Function ConteoVoucher(tipoDoc As String)
        Dim conteo = (From i In HeliosData.documentoCaja
                      Where i.tipoDocPago = tipoDoc).Count
        conteo = conteo + 1
        Return conteo
    End Function

    Private Sub SaveCajaCompra(nCaja As documento, intIdCompra As Integer, listaVenta As List(Of documentocompradetalle))
        Dim nDetalle As documentoCajaDetalle
        Dim DocumentoBL As New documentoBL
        Dim documentoCajaBL As New documentoCajaBL
        Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        Dim cajaExtranjeraBL As New movimientocajaextranjeraBL
        Using ts As New TransactionScope
            'nCaja.documentoCaja.numeroDoc = nCaja.nroDoc
            'conteo de numero voucher contable

            Dim nroVoucher = ConteoVoucher(nCaja.documentoCaja.tipoDocPago)
            nCaja.documentoCaja.numeroDoc = nroVoucher
            nCaja.nroDoc = nroVoucher
            DocumentoBL.Insert(nCaja)
            '////////

            documentoCajaBL.Insert(nCaja.documentoCaja, nCaja.idDocumento)
            cajaExtranjeraBL.GrabarListaPagos(nCaja.documentoCaja, nCaja.idDocumento)
            For Each i In nCaja.documentoCaja.documentoCajaDetalle
                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = nCaja.idDocumento
                nDetalle.documentoAfectado = intIdCompra
                nDetalle.documentoAfectadodetalle = i.documentoAfectadodetalle ' articuloVenta.secuencia
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoSolesTransacc = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.montoUsdTransacc = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.otroMN = i.otroMN
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            '   documentoCajaDetalleBL.Insert(nCaja, nCaja.idDocumento, intIdCompra)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function GetResumenXFormaPago(be As documentoCaja) As List(Of documentoCaja)
        'And
        'n.entidadFinanciera = be.entidadFinanciera
        Dim consultaCaja = (From n In HeliosData.documentoCaja
                            Join tbl In HeliosData.tabladetalle
                                    On tbl.codigoDetalle Equals n.formapago
                            Where
                                tbl.idtabla = 1 And
                                n.idEmpresa = be.idEmpresa And
                                n.idEstablecimiento = be.idEstablecimiento And
                                n.idCajaUsuario = be.idCajaUsuario And
                                be.ListaIDCajas.Contains(n.entidadFinanciera)
                            Select
                               n.formapago, tbl.descripcion, tbl.codigoDetalle,
                               pagos = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCaja
                                                   Where
                                                       dc.tipoMovimiento = "PG" And
                                                       dc.formapago = n.formapago And
                                                       dc.idEmpresa = n.idEmpresa And
                                                       dc.idEstablecimiento = n.idEstablecimiento And
                                                       dc.idCajaUsuario = be.idCajaUsuario And
                                                       be.ListaIDCajas.Contains(dc.entidadFinanciera)
                                                   Select New With {
                                                       dc.montoSoles
                                                       }) Into Sum(t1.montoSoles)), Decimal?)),
                                Cobros = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCaja
                                                   Where
                                                       dc.tipoMovimiento = "DC" And
                                                       dc.formapago = n.formapago And
                                                       dc.idEmpresa = n.idEmpresa And
                                                       dc.idEstablecimiento = n.idEstablecimiento And
                                                       dc.idCajaUsuario = be.idCajaUsuario And
                                                       be.ListaIDCajas.Contains(dc.entidadFinanciera)
                                                   Select New With {
                                                       dc.montoSoles
                                                       }) Into Sum(t1.montoSoles)), Decimal?))).Distinct.ToList


        GetResumenXFormaPago = New List(Of documentoCaja)
            For Each i In consultaCaja
            GetResumenXFormaPago.Add(New documentoCaja With
                                         {
                                         .idformaPago = i.codigoDetalle,
                                         .formapago = i.descripcion,
                                         .TotalEgresos = i.pagos.GetValueOrDefault,
                                         .TotalIngresos = i.Cobros.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GastosFinanzas(documentoCaja As documentoCaja) As List(Of documentoCaja)
        'Return HeliosData.documentoCaja.Where(Function(o) o.idEmpresa = documentoCaja.idEmpresa And
        '                                          o.idEstablecimiento = documentoCaja.idEstablecimiento And
        '                                          o.asientoCosto = documentoCaja.asientoCosto).ToList
        Dim lista As New List(Of documentoCaja)
        Dim objeto As New documentoCaja

        Dim consulta = (From c In HeliosData.documentoCaja
                        Join asi In HeliosData.asiento
                        On asi.idDocumento Equals c.idDocumento
                        Join mov In HeliosData.movimiento
                        On mov.idAsiento Equals asi.idAsiento
                        Join cost In HeliosData.recursoCosto
                        On cost.idCosto Equals mov.idCosto
                        Join cuen In HeliosData.cuentaplanContableEmpresa
                        On cuen.idCosto Equals mov.idCosto
                        Where c.idEmpresa = documentoCaja.idEmpresa _
              And c.idEstablecimiento = documentoCaja.idEstablecimiento _
              And mov.idCosto = documentoCaja.idcosto And mov.tipoCosto = "PG"
                        Order By c.fechaProceso).ToList

        For Each i In consulta
            objeto = New documentoCaja

            objeto.idDocumento = i.c.idDocumento
            objeto.movimientoCaja = i.c.movimientoCaja
            objeto.fechaCobro = i.c.fechaCobro
            objeto.entidadFinanciera = i.c.entidadFinanciera
            objeto.tipoDocPago = i.c.tipoDocPago
            objeto.numeroDoc = i.c.numeroDoc
            objeto.moneda = i.c.moneda
            objeto.montoSoles = i.mov.monto
            objeto.montoUsd = i.mov.montoUSD
            objeto.glosa = i.c.glosa
            objeto.idcosto = i.mov.idCosto
            objeto.tipoCosto = "HG"
            objeto.nombreCosto = i.cost.nombreCosto
            objeto.idEstado = i.mov.idmovimiento
            objeto.cuentaCosteo = i.cuen.cuenta

            lista.Add(objeto)

        Next
        Return lista
    End Function

    Public Function SaveGroupCajaReconocimiento(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Dim numeracionBL As New numeracionBoletasBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Dim cierreCajaBL As New cierreCajaBL
        Try
            Dim fechaActual = New Date(objDocumentoBE.documentoCaja.fechaProceso.Value.Year, objDocumentoBE.documentoCaja.fechaProceso.Value.Month, 1)
            Dim fechaAnterior = fechaActual.AddMonths(-1)

            'si es false es porque no esta dentro del inicio de operaciones
            Dim valor = empresaCierreMensualBL.GetValidaFechaInicioOperacion(objDocumentoBE.idEmpresa, fechaActual, objDocumentoBE.idCentroCosto)
            If valor = "False" Then
                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month, objDocumentoBE.idCentroCosto) = False Then
                    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                End If
            ElseIf valor = "True" Then
                Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
            Else
                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                'If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month) = False Then
                '    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                'End If
            End If

            Using ts As New TransactionScope()
                Dim numeracionAuto = numeracionBL.GenerarNumeroPorCodigoEmpresa("OES", objDocumentoBE.idEmpresa, "9901", objDocumentoBE.idCentroCosto)
                If numeracionAuto IsNot Nothing Then
                    Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                    Dim ventaoriginal As documentoventaAbarrotes = (HeliosData.documentoventaAbarrotes.Where(Function(o) _
                                                                o.idDocumento = codigoPadre)).FirstOrDefault


                    objDocumentoBE.nroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                    documentoBL.Insert(objDocumentoBE)
                    '-------------------------------------------------------------------------------------------
                    objDocumentoBE.documentoCaja.numeroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                    idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                    '------------------------------------------------------------------------------------------------
                    cajaDetalleBL.InsertPagosDeCajaRec(objDocumentoBE, idDocumentoRecuperado, ventaoriginal.moneda)
                    AsientoBL.SavebyGroupDoc(objDocumentoBE)

                    Dim ventaDetalle = (From n In HeliosData.documentoventaAbarrotesDet
                                        Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO).Count
                    If ventaDetalle > 0 Then
                        ventaoriginal.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    Else
                        ventaoriginal.estadoCobro = TIPO_VENTA.PAGO.COBRADO
                    End If
                End If

                HeliosData.SaveChanges()
                ts.Complete()
                'Return idDocumentoRecuperado
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveCompensacionAnticipo(objDocumento As documento) As Integer

        Dim compraDetalleBL As New documentoCajaDetalleBL
        Dim inventario As New InventarioMovimientoBL
        Dim asientoBL As New AsientoBL
        Dim cajaBL As New documentoCajaDetalleBL
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento
        Dim objetoCaja As New documentoCajaBL

        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL

        Dim numeracionBL As New numeracionBoletasBL

        Try
            Using ts As New TransactionScope()
                documentoBL.Insert(objDocumento)
                'Dim codCompra = objDocumento.idDocumento
                Dim codCompra = objDocumento.documentoCaja.idDocumento
                Dim compra As documentoCaja = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = objDocumento.documentoCaja.idDocumento).FirstOrDefault

                'Try
                '    Using ts As New TransactionScope()
                Dim numeracionAuto = numeracionBL.GenerarNumeroPorCodigoEmpresa("OES", objDocumento.idEmpresa, "9901", objDocumento.idCentroCosto)
                If numeracionAuto IsNot Nothing Then
                    objDocumento.nroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                    documentoBL.Insert(objDocumento)
                    objDocumento.documentoCaja.numeroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                    InsertME(objDocumento.documentoCaja, objDocumento.idDocumento)

                    cajaDetalleBL.InsertCajaME(objDocumento, objDocumento.idDocumento, objDocumento.documentoCaja.entidadFinanciera)
                    asientoBL.SavebyGroupDoc(objDocumento)

                    Dim ventaDetalle = (From n In HeliosData.documentoCajaDetalle
                                        Where n.idDocumento = codCompra
                                        Select
                                            n.idDocumento,
                                            n.montoSoles,
                                            pagos = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCajaDetalle
                                                   Join i In HeliosData.documentoCaja On dc.idDocumento Equals i.idDocumento
                                                   Where
                                                       dc.idCajaPadre = n.idDocumento And i.movimientoCaja = "AC"
                                                   Select New With {
                                                       dc.montoSoles
                                                       }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault



                    If ventaDetalle.montoSoles > ventaDetalle.pagos.GetValueOrDefault Then
                        compra.estado = "P"
                    Else
                        compra.estado = "U"
                    End If

                    HeliosData.SaveChanges()
                    ts.Complete()

                End If
                Return objDocumento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUbicar_documentoAnticipoPorID(idDocumento As Integer) As documentoCaja
        Dim docCompra As New documentoCaja

        Dim com = (From a In HeliosData.documentoCaja
                   Where a.idDocumento = idDocumento).FirstOrDefault

        If Not IsNothing(com) Then
            docCompra = New documentoCaja
            docCompra.idDocumento = com.idDocumento
            docCompra.codigoLibro = com.codigoLibro
            docCompra.idEmpresa = com.idEmpresa
            docCompra.idEstablecimiento = com.idEstablecimiento
            docCompra.fechaProceso = com.fechaProceso
            docCompra.periodo = com.periodo
            docCompra.tipoDocPago = com.tipoDocPago
            docCompra.numeroDoc = com.numeroDoc
            docCompra.codigoProveedor = com.codigoProveedor

            docCompra.tipoPersona = com.tipoPersona
            docCompra.moneda = com.moneda
            docCompra.tipoCambio = com.tipoCambio


            docCompra.montoSoles = com.montoSoles
            docCompra.montoUsd = com.montoUsd


            docCompra.estadopago = com.estadopago
            docCompra.glosa = com.glosa

        End If



        Return docCompra
    End Function


    Public Function UbicarAnticiposProveedor(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentoCaja)
        Dim doccompra As New documentoCaja
        Dim compraLista As New List(Of documentoCaja)
        Dim list As New List(Of String)

        Dim con = (From c In HeliosData.documentoCaja
                   Join ent In HeliosData.entidad
                   On c.codigoProveedor Equals ent.idEntidad
                   Join tbl In HeliosData.tabladetalle
                  On c.tipoDocPago Equals tbl.codigoDetalle
                   Where
                 (New String() {"AO"}).Contains(c.movimientoCaja) And
                  c.idEmpresa = strEmpresa And c.idEstablecimiento = intIdEstablecimiento _
                  And ent.nrodoc = strRuc And ent.tipoEntidad = "PR" _
                  And tbl.idtabla = 10 And
                  (New String() {"N", "P"}).Contains(c.estado) And
                  c.periodo = strPeriodo
                   Select
                 tbl.descripcion,
                 c.idDocumento,
                 c.movimientoCaja,
                 c.periodo,
                 c.fechaProceso,
                 c.numeroDoc,
                 c.tipoDocPago,
                 c.moneda,
                 c.montoSoles,
                 c.tipoCambio,
                 c.montoUsd,
                 c.estado,
                c.entidadFinanciera,
                c.formapago,
                 c.numeroOperacion,
                c.ctaCorrienteDeposito,
                c.bancoEntidad,
                 c.tipoOperacion,
                  pagos = (CType((Aggregate t1 In
                                        (From p In HeliosData.documentoCajaDetalle
                                         Join k In HeliosData.documentoCaja
                                          On k.idDocumento Equals p.idDocumento
                                         Where
                                         p.idCajaPadre = c.idDocumento And k.movimientoCaja = "AC"
                                         Select New With {
                                             p.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?))).ToList


        For Each i In con
            doccompra = New documentoCaja
            doccompra.idDocumento = i.idDocumento
            doccompra.movimientoCaja = i.movimientoCaja
            doccompra.periodo = i.periodo
            doccompra.fechaProceso = i.fechaProceso
            doccompra.numeroDoc = i.numeroDoc
            doccompra.tipoDocPago = i.tipoDocPago
            doccompra.moneda = i.moneda
            doccompra.glosa = i.descripcion
            doccompra.montoSoles = i.montoSoles - i.pagos.GetValueOrDefault
            doccompra.montoUsd = i.montoUsd
            doccompra.estado = i.estado

            doccompra.entidadFinanciera = i.entidadFinanciera
            doccompra.formapago = i.formapago
            doccompra.numeroOperacion = i.numeroOperacion
            doccompra.ctaCorrienteDeposito = i.ctaCorrienteDeposito
            doccompra.bancoEntidad = i.bancoEntidad
            doccompra.tipoOperacion = i.tipoOperacion

            compraLista.Add(doccompra)
        Next
        Return compraLista
    End Function

    Public Function ObtenerCajaOnlineMensual(ByVal anioPeriodo As String, ByVal mesPeriodo As String, EmpresaId As String) As List(Of documentoCaja)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")


        Dim obj As New documentoCaja
        Dim Lista As New List(Of documentoCaja)
        Try
            Dim con = From ef In HeliosData.estadosFinancieros
                      Where
                      ef.idEmpresa = EmpresaId
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
                                         c.tipoMovimiento = "DC" And Not c.tipoOperacion = StatusTipoOperacion.CIERRES And
                                              c.idEmpresa = EmpresaId And
                                         c.fechaProceso.Value.Year = FechaAct.Year And c.fechaProceso.Value.Month = FechaAct.Month
                                         Select New With {
                                             c.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                     Salida = (CType((Aggregate t1 In
                                      (From c In HeliosData.documentoCaja
                                       Where
                                       c.entidadFinanciera = CStr(ef.idestado) And
                                       c.tipoMovimiento = "PG" And Not c.tipoOperacion = StatusTipoOperacion.CIERRES And
                                            c.idEmpresa = EmpresaId And
                                        c.fechaProceso.Value.Year = FechaAct.Year And c.fechaProceso.Value.Month = FechaAct.Month
                                       Select New With {
                                           c.montoSoles
                                       }) Into Sum(t1.montoSoles)), Decimal?)),
                   SaldoAnterior = (From c In HeliosData.cierreCaja
                                    Where
                                         c.idEntidadFinanciera = ef.idestado And
                                         c.periodo = periodo_Anterior And
                                         c.idEmpresa = EmpresaId
                                    Select New With {
                                             c.montoMN
                                         }).FirstOrDefault().montoMN


            For Each i In con
                obj = New documentoCaja
                obj.NombreCaja = i.descripcion
                obj.NumeroDocumento = i.codigo
                obj.entidadFinanciera = i.tipo
                obj.montoSoles = i.Ingreso.GetValueOrDefault - i.Salida.GetValueOrDefault + i.SaldoAnterior.GetValueOrDefault
                'obj.Salidas = i.Salida.GetValueOrDefault
                Lista.Add(obj)
            Next

        Catch ex As Exception
            Throw ex
        End Try


        Return Lista


    End Function

    Public Function GetUbicar_documentoCajaID(idDocumento As Integer) As documentoCaja
        Dim docCaja As New documentoCaja

        Dim com = (From a In HeliosData.documentoCaja
                   Where a.idDocumento = idDocumento).FirstOrDefault

        If Not IsNothing(com) Then
            docCaja = New documentoCaja
            docCaja.idDocumento = com.idDocumento
            docCaja.codigoLibro = com.codigoLibro
            docCaja.idEmpresa = com.idEmpresa

            docCaja.fechaProceso = com.fechaProceso
            docCaja.periodo = com.periodo

            docCaja.numeroDoc = com.numeroDoc

        End If

        Return docCaja
    End Function

    Public Function ObtenerCajaOnlineAnual(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer) As List(Of documentoCaja)
        'Dim MesHoy = DateTime.Now.Month

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Dim obj As New documentoCaja
        Dim Lista As New List(Of documentoCaja)
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
                                         c.tipoMovimiento = "DC" And Not c.tipoOperacion = StatusTipoOperacion.CIERRES And
                                         c.periodo = periodo_Actual
                                         Select New With {
                                             c.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                     Salida = (CType((Aggregate t1 In
                                      (From c In HeliosData.documentoCaja
                                       Where
                                       c.entidadFinanciera = CStr(ef.idestado) And
                                       c.tipoMovimiento = "PG" And Not c.tipoOperacion = StatusTipoOperacion.CIERRES And
                                        c.periodo = periodo_Actual
                                       Select New With {
                                           c.montoSoles
                                       }) Into Sum(t1.montoSoles)), Decimal?)),
                                  SaldoAnterior = (From c In HeliosData.cierreCaja
                                                   Where
                                         c.idEntidadFinanciera = ef.idestado And
                                         c.periodo = periodo_Anterior And
                                         c.idEmpresa = Gempresas.IdEmpresaRuc
                                                   Select New With {
                                             c.montoMN
                                         }).FirstOrDefault().montoMN


            For Each i In con
                obj = New documentoCaja
                obj.NombreCaja = i.descripcion
                obj.NumeroDocumento = i.codigo
                obj.entidadFinanciera = i.tipo
                obj.montoSoles = i.Ingreso.GetValueOrDefault - i.Salida.GetValueOrDefault + i.SaldoAnterior.GetValueOrDefault
                'obj.Salidas = i.Salida.GetValueOrDefault
                Lista.Add(obj)
            Next

        Catch ex As Exception
            Throw ex
        End Try


        Return Lista


    End Function

    Public Sub CambiarPeriodoCaja(be As documentoCaja)
        Using ts As New TransactionScope
            Dim obj = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = be.idDocumento).FirstOrDefault
            obj.periodo = be.periodo

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetSaldosCajaEntranjera(be As estadosFinancieros) As List(Of documentoCaja)
        Dim obj As New documentoCaja
        Dim Lista As New List(Of documentoCaja)

        Dim ListaMovimientos As New List(Of String)
        ListaMovimientos.Add("OEC")
        ListaMovimientos.Add("VELC")
        ListaMovimientos.Add("NOTE")
        ListaMovimientos.Add("CCR")

        Dim monedas As New List(Of String)
        monedas.Add(TipoMoneda.Extranjero)
        monedas.Add(TipoMoneda.Nacional)
        ' = "OEC" _
        Dim con = (From caja In HeliosData.documentoCaja
                   Group Join mov In HeliosData.movimientocajaextranjera On caja.idDocumento Equals mov.idDocumento Into mov_join = Group
                   From mov In mov_join.DefaultIfEmpty()
                   Where
                   caja.idEmpresa = be.idEmpresa And
                   CLng(caja.idEstablecimiento) = be.idEstablecimiento And
                   caja.entidadFinancieraDestino = CStr(be.idestado) _
                   And ListaMovimientos.Contains(caja.movimientoCaja) _
                   And caja.estadopago = StatusPagoMonedaExtranjera.Pendiente And monedas.Contains(caja.moneda)
                   Group New With {caja, mov} By
                   caja.idDocumento,
                   caja.idEmpresa,
                   caja.idEstablecimiento,
                   caja.entidadFinancieraDestino,
                   caja.moneda,
                   caja.montoUsd,
                   caja.montoSoles,
                   caja.tipoCambio,
                   caja.fechaProceso
                   Into g = Group
                   Select
                   IdDocumento = CType(idDocumento, Int32?),
                   idEmpresa,
                   idEstablecimiento,
                   entidadFinancieraDestino,
                   moneda,
                   montoUsd,
                   montoSoles,
                   tipoCambio,
                   fechaProceso,
                   mov = CType(g.Sum(Function(p) p.mov.importe), Decimal?)).ToList

        For Each i In con
            obj = New documentoCaja
            obj.idDocumento = i.IdDocumento
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.entidadFinancieraDestino = i.entidadFinancieraDestino
            obj.moneda = i.moneda
            obj.montoUsd = i.montoUsd
            obj.montoSoles = i.montoSoles
            obj.ImporteDesembolsado = i.mov.GetValueOrDefault
            obj.fechaProceso = i.fechaProceso
            obj.tipoCambio = i.tipoCambio
            Lista.Add(obj)
        Next
        Return Lista

    End Function

    Public Function GetDepositosExtranjeros(be As estadosFinancieros) As List(Of documentoCaja)
        Dim obj As New documentoCaja
        Dim Lista As New List(Of documentoCaja)

        Dim ListaMovimientos As New List(Of String)
        ListaMovimientos.Add("OEC")
        ListaMovimientos.Add("VELC")
        ListaMovimientos.Add("NOTE")
        ListaMovimientos.Add("CCR")

        Dim con = (From caja In HeliosData.documentoCaja
                   Group Join mov In HeliosData.movimientocajaextranjera On caja.idDocumento Equals mov.idDocumento Into mov_join = Group
                   From mov In mov_join.DefaultIfEmpty()
                   Where
                       caja.idEmpresa = be.idEmpresa And
                       CLng(caja.idEstablecimiento) = be.idEstablecimiento And
                       caja.entidadFinanciera = CStr(be.idestado) _
                       And caja.fechaProceso.Value.Month = be.fechaBalance.Value.Month _
                       And caja.fechaProceso.Value.Year = be.fechaBalance.Value.Year _
                       And ListaMovimientos.Contains(caja.movimientoCaja) And caja.moneda = TipoMoneda.Extranjero
                   Group New With {caja, mov} By
                       caja.idDocumento,
                       caja.idEmpresa,
                       caja.idEstablecimiento,
                       caja.entidadFinanciera,
                       caja.moneda,
                       caja.montoUsd,
                       caja.montoSoles,
                       caja.tipoCambio,
                       caja.fechaProceso,
                       caja.estadopago
                       Into g = Group
                   Select
                       IdDocumento = CType(idDocumento, Int32?),
                       idEmpresa,
                       idEstablecimiento,
                       entidadFinanciera,
                       moneda,
                       montoUsd,
                       montoSoles,
                       tipoCambio,
                       fechaProceso,
                       estadopago,
                       mov = CType(g.Sum(Function(p) p.mov.importe), Decimal?)).ToList

        For Each i In con
            obj = New documentoCaja
            obj.idDocumento = i.IdDocumento
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.entidadFinanciera = i.entidadFinanciera
            obj.moneda = i.moneda
            obj.montoUsd = i.montoUsd
            obj.montoSoles = i.montoSoles
            obj.ImporteDesembolsado = i.mov.GetValueOrDefault
            obj.fechaProceso = i.fechaProceso
            obj.tipoCambio = i.tipoCambio
            obj.estadopago = i.estadopago
            Lista.Add(obj)
        Next
        Return Lista

    End Function

    Public Function SaveGroupCajaDocsME(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Dim docactualizar As Integer = 0
        Try
            Using ts As New TransactionScope()
                Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                Dim ventaoriginal As documentocompra = (HeliosData.documentocompra.Where(Function(o) _
                                                            o.idDocumento = codigoPadre)).FirstOrDefault

                documentoBL.Insert(objDocumentoBE)
                idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                'cajaDetalleBL.InsertPagosDeCajaCompraME(objDocumentoBE, idDocumentoRecuperado, objDocumentoBE.documentoCaja.entidadFinanciera, listaDetalle, ventaoriginal.monedaDoc)
                cajaDetalleBL.GetPagoDetalleSave(objDocumentoBE, idDocumentoRecuperado, ventaoriginal.monedaDoc)
                'cajaDetalleBL.InsertCajaME(objDocumentoBE, idDocumentoRecuperado, objDocumentoBE.documentoCaja.entidadFinanciera)

                AsientoBL.SavebyGroupDoc(objDocumentoBE)

                'Dim ventaDetalle = (From n In HeliosData.documentocompradetalle _
                '                   Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count

                'If ventaDetalle > 0 Then
                '    ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                'Else
                '    ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                'End If


                For Each j In objDocumentoBE.documentoCaja.documentoCajaDetalle
                    If docactualizar = j.documentoAfectado Then
                    Else
                        docactualizar = j.documentoAfectado
                        Me.updatedocumentosCompra(docactualizar)

                    End If
                Next

                HeliosData.SaveChanges()
                ts.Complete()
                'Return idDocumentoRecuperado
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function updatedocumentosCompra(iddocuemtno As Integer)

        Using ts As New TransactionScope()
            Dim ventaoriginal As documentocompra = (HeliosData.documentocompra.Where(Function(o) _
                                                                o.idDocumento = iddocuemtno)).FirstOrDefault

            Dim ventaDetalle = (From n In HeliosData.documentocompradetalle
                                Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count

            If ventaDetalle > 0 Then
                ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            Else
                ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PAGADO
            End If

            HeliosData.SaveChanges()
            ts.Complete()
            'Return idDocumentoRecuperado
            Return ventaoriginal.idDocumento
        End Using
    End Function


    Public Function SaveGroupCajaMEAsiento(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Try
            Using ts As New TransactionScope()
                'Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                'Dim ventaoriginal As documentoLibroDiario = (HeliosData.documentoLibroDiario.Where(Function(o) _
                '                                            o.idDocumento = codigoPadre)).FirstOrDefault

                documentoBL.Insert(objDocumentoBE)

                idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                'cajaDetalleBL.GetPagoDetalleSave(objDocumentoBE, idDocumentoRecuperado, ventaoriginal.monedaDoc)
                cajaDetalleBL.InsertPagosDeCajaLibroME(objDocumentoBE, idDocumentoRecuperado, listaDetalle)
                'cajaDetalleBL.InsertCajaME(objDocumentoBE, idDocumentoRecuperado, objDocumentoBE.documentoCaja.entidadFinanciera)


                AsientoBL.SavebyGroupDoc(objDocumentoBE)

                'Dim ventaDetalle = (From n In HeliosData.documentoLibroDiarioDetalle _
                '                   Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count

                'If ventaDetalle > 0 Then
                '    ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                'Else
                '    ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                'End If

                HeliosData.SaveChanges()
                ts.Complete()
                'Return idDocumentoRecuperado
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function GetFlujoEfectivo() As List(Of documentoCaja)
        Dim obj As New documentoCaja
        Dim lista As New List(Of documentoCaja)
        Dim con = (From c In HeliosData.documentoCaja
                   Join t In HeliosData.tabladetalle On New With {.CodigoDetalle = c.tipoOperacion} Equals New With {.CodigoDetalle = t.codigoDetalle}
                   Where
                  CLng(t.idtabla) = 12 _
                  And c.idEmpresa = Gempresas.IdEmpresaRuc
                   Group New With {c, t} By
                  c.tipoOperacion,
                  t.descripcion,
                  c.tipoMovimiento
                  Into g = Group
                   Order By
                  tipoMovimiento
                   Select
                  tipoOperacion,
                  descripcion,
                  tipoMovimiento,
                  total = CType(g.Sum(Function(p) p.c.montoSoles), Decimal?)).ToList


        For Each i In con
            obj = New documentoCaja
            obj.tipoOperacion = i.descripcion
            obj.tipoMovimiento = i.tipoMovimiento
            obj.montoSoles = i.total
            lista.Add(obj)
        Next
        Return lista
    End Function
    '                  And c.idEstablecimiento = GEstableciento.IdEstablecimiento _
    Public Function GetFlujoEfectivoByDia(be As documentoCaja) As List(Of documentoCaja)
        Dim obj As New documentoCaja
        Dim lista As New List(Of documentoCaja)
        Dim con = (From c In HeliosData.documentoCaja
                   Join t In HeliosData.tabladetalle On New With {.CodigoDetalle = c.tipoOperacion} Equals New With {.CodigoDetalle = t.codigoDetalle}
                   Where
                  CLng(t.idtabla) = 12 _
                  And c.idEmpresa = be.idEmpresa _
                  And c.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
                  And c.fechaProceso.Value.Month = be.fechaProceso.Value.Month _
                  And c.fechaProceso.Value.Day = be.fechaProceso.Value.Day _
                       And c.estado = "1"
                   Group New With {c, t} By
                  c.tipoOperacion,
                  t.descripcion,
                  c.tipoMovimiento
                  Into g = Group
                   Order By
                  tipoMovimiento
                   Select
                  tipoOperacion,
                  descripcion,
                  tipoMovimiento,
                  total = CType(g.Sum(Function(p) p.c.montoSoles), Decimal?)).ToList





        For Each i In con
            obj = New documentoCaja
            obj.tipoOperacion = i.tipoOperacion
            obj.tipoMovimiento = i.tipoMovimiento
            obj.montoSoles = i.total.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetFlujoEfectivoByDiaAllEmpresa(be As documentoCaja) As List(Of documentoCaja)
        Dim obj As New documentoCaja
        Dim lista As New List(Of documentoCaja)
        Dim con = (From c In HeliosData.documentoCaja
                   Join t In HeliosData.tabladetalle On New With {.CodigoDetalle = c.tipoOperacion} Equals New With {.CodigoDetalle = t.codigoDetalle}
                   Join emp In HeliosData.empresa On emp.idEmpresa Equals c.idEmpresa
                   Join cen In HeliosData.centrocosto On cen.idCentroCosto Equals c.idEstablecimiento
                   Where
                  CLng(t.idtabla) = 12 _
                  And c.fechaProceso.Value.Year = be.fechaProceso.Value.Year _
                  And c.fechaProceso.Value.Month = be.fechaProceso.Value.Month _
                  And c.fechaProceso.Value.Day = be.fechaProceso.Value.Day
                   Group New With {c, t} By
                  emp.nombreCorto,
                  c.idEmpresa,
                  c.idEstablecimiento,
                  cen.nombre,
                  c.tipoOperacion,
                  t.descripcion,
                  c.tipoMovimiento
                  Into g = Group
                   Order By
                  tipoMovimiento
                   Select
                  idEmpresa,
                  nombreCorto,
                  idEstablecimiento,
                  nombre,
                  tipoOperacion,
                  descripcion,
                  tipoMovimiento,
                  total = CType(g.Sum(Function(p) p.c.montoSoles), Decimal?)).ToList





        For Each i In con
            obj = New documentoCaja
            obj.NomCortoEmpresa = i.nombreCorto
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.NomCortoEstablecimiento = i.nombre
            obj.tipoOperacion = i.descripcion
            obj.tipoMovimiento = i.tipoMovimiento
            obj.montoSoles = i.total
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function ListadoComprobantesPagoPadre(iNtPadre As Integer) As List(Of documentoCaja)
        Dim lista As New List(Of documentoCaja)
        Dim a As New documentoCaja

        Dim cc = (From c In HeliosData.documentoCaja
                  Join det In HeliosData.documentoCajaDetalle
                 On c.idDocumento Equals det.idDocumento
                  Join pres In HeliosData.documentoPrestamoDetalle
                 On det.documentoAfectado Equals pres.idCuota
                  Where pres.idDocumento = iNtPadre
                  Group det By
                       c.idDocumento, c.fechaCobro, c.tipoDocPago, c.numeroDoc, c.numeroOperacion, c.tipoCambio, c.moneda, c.tipoOperacion, c.montoSoles, c.montoUsd
                          Into g = Group
                  Select New With {.idDoc = idDocumento,
                                          .fecha = fechaCobro,
                                           .TipoDoc = tipoDocPago,
                                           .NumeroDoc = numeroDoc,
                                           .NumeroOper = numeroOperacion,
                                            .moNeda = moneda,
                                            .tipocambio = tipoCambio,
                                            .tipoOperacion = tipoOperacion,
                                           .importeMN = montoSoles,
                                           .importeME = montoUsd
                                       }
                                   ).ToList


        For Each i In cc
            a = New documentoCaja
            a.idDocumento = i.idDoc
            a.fechaCobro = i.fecha
            a.tipoDocPago = i.TipoDoc
            a.numeroDoc = i.NumeroDoc
            a.numeroOperacion = i.NumeroOper
            a.moneda = i.moNeda
            a.tipoCambio = i.tipocambio
            a.tipoOperacion = i.tipoOperacion
            a.montoSoles = i.importeMN
            a.montoUsd = i.importeME
            lista.Add(a)
        Next

        Return lista
    End Function


    Public Function PagosPorPrestamo(iNtPadre As Integer) As documentoCaja
        Dim lista As New documentoCaja
        Dim a As New documentoCaja
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)

        Dim cc = (From c In HeliosData.documentoCaja
                  Join det In HeliosData.documentoCajaDetalle
                 On c.idDocumento Equals det.idDocumento
                  Join pres In HeliosData.documentoPrestamoDetalle
                 On det.documentoAfectado Equals pres.idCuota
                  Where pres.idDocumento = iNtPadre
                  Group det By
                       c.idDocumento, c.montoSoles, c.montoUsd
                          Into g = Group
                  Select New With {.idDoc = idDocumento,
                                           .importeMN = montoSoles,
                                           .importeME = montoUsd
                                       }
                                   ).ToList


        For Each i In cc
            monto += i.importeMN
            montome += i.importeME
        Next
        lista = New documentoCaja
        lista.montoSoles = monto
        lista.montoUsd = montome


        Return lista
    End Function


    Public Function GetMovimientoXusuarioInfo(intUsuario As Integer, fechaActual As Date) As List(Of documentoCaja)
        Dim consulta = (From n In HeliosData.documentoCaja
                        Where n.usuarioModificacion = intUsuario _
                       And n.fechaCobro.Value.Year = fechaActual.Year _
                       And n.fechaCobro.Value.Month = fechaActual.Month _
                       And n.fechaCobro.Value.Day = fechaActual.Day).ToList

        Return consulta
    End Function

    Public Function SaveGroupAnticipoME(objDocumentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim anticipobl As New documentoAnticipoBL
        Dim cajaDetalleBL As New documentoAnticipoDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Try
            Using ts As New TransactionScope()
                Dim codigoPadre = objDocumentoBE.documentoAnticipo.documentoAnticipoDetalle(0).documentoAfectado
                Dim ventaoriginal As documentocompra = (HeliosData.documentocompra.Where(Function(o) _
                                                            o.idDocumento = codigoPadre)).FirstOrDefault

                documentoBL.Insert(objDocumentoBE)
                idDocumentoRecuperado = anticipobl.InsertAntDesc(objDocumentoBE.documentoAnticipo, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertPagosConAnticipoME(objDocumentoBE, idDocumentoRecuperado)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)

                Dim ventaDetalle = (From n In HeliosData.documentocompradetalle
                                    Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count

                If ventaDetalle > 0 Then
                    ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                Else
                    ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                End If

                HeliosData.SaveChanges()
                ts.Complete()
                Return idDocumentoRecuperado

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function SavePrestamoGroup(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Try
            Using ts As New TransactionScope()
                Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).idDocumento
                Dim ventaoriginal As prestamos = (HeliosData.prestamos.Where(Function(o) _
                                                            o.idDocumento = codigoPadre)).FirstOrDefault

                documentoBL.Insert(objDocumentoBE)
                idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertPagosDeCajaPrestamoME(objDocumentoBE, idDocumentoRecuperado, objDocumentoBE.documentoCaja.entidadFinanciera)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)



                Dim CON = (From cuota In objDocumentoBE.documentoCaja.documentoCajaDetalle
                           Select cuota.documentoAfectado).Distinct
                CON.ToList()
                For Each i In CON
                    Dim updatEcuota = (From n In HeliosData.documentoPrestamoDetalle
                                       Where n.idCuota = i _
                                  And n.estadoPago = "PN").Count
                    If updatEcuota > 0 Then
                    Else
                        Me.UpdateCuotaEstado(ventaoriginal.idDocumento, i)
                    End If
                Next


                Dim ventaDetalle = (From n In HeliosData.documentoPrestamoDetalle
                                    Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count
                If ventaDetalle > 0 Then
                    ventaoriginal.estado = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                Else
                    ventaoriginal.estado = TIPO_COMPRA.PAGO.PAGADO
                End If
                HeliosData.SaveChanges()
                ts.Complete()
                Return idDocumentoRecuperado

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub UpdateCuotaEstado(iddocumento As Integer, idcuota As Integer)
        Using ts As New TransactionScope
            Dim documento As documentoPrestamos = HeliosData.documentoPrestamos.Where(Function(o) _
                                            o.idDocumento = iddocumento And o.idCuota = idcuota).First()

            documento.estadoPago = "PG"

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub



    Public Function ListadoPagosPrestamo(inicio As Date, fin As Date) As List(Of documentoCaja)
        Dim lista As New List(Of documentoCaja)
        Dim objPrestamo As New documentoCaja
        Dim entidadbl As New entidadBL

        Dim consulta = (From n In HeliosData.documentoCaja
                        Join pres In HeliosData.documentoCajaDetalle
                         On pres.idDocumento Equals n.idDocumento
                        Join doc In HeliosData.prestamos
                         On pres.documentoAfectado Equals doc.idDocumento
                        Where n.tipoOperacion = "TPP" And
                       n.fechaProceso >= inicio And n.fechaProceso <= fin _
                       And n.idEmpresa = Gempresas.IdEmpresaRuc).ToList

        For Each i In consulta
            objPrestamo = New documentoCaja
            objPrestamo.idDocumento = i.pres.documentoAfectado

            objPrestamo.numeroDoc = i.doc.nroDoc
            objPrestamo.fechaProceso = i.pres.fecha

            objPrestamo.tipoMovimiento = i.pres.DetalleItem

            With entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, i.doc.tipoBeneficiario, i.doc.idBeneficiario)

                objPrestamo.codigoLibro = .nombreCompleto
            End With

            objPrestamo.montoSoles = i.pres.montoSoles
            objPrestamo.montoUsd = i.pres.montoUsd
            objPrestamo.tipoOperacion = "PAGO"
            lista.Add(objPrestamo)
        Next

        Return lista
    End Function


    Function RecuperarSumaEFxitem(intiDEF As Integer, intAnio As Integer, intMes As Integer) As documentoCaja
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0

        Dim Entradas = Aggregate n In HeliosData.documentoCaja
                       Where n.idEmpresa = Gempresas.IdEmpresaRuc And n.idEstablecimiento = GEstableciento.IdEstablecimiento _
                       And n.tipoMovimiento = "DC" _
                       And n.entidadFinanciera = intiDEF And n.fechaProceso.Value.Year = intAnio And n.fechaProceso.Value.Month = intMes
                       Into sumMN = Sum(n.montoSoles), sumME = Sum(n.montoUsd)

        Dim Salidas = Aggregate n In HeliosData.documentoCaja
                       Where n.idEmpresa = Gempresas.IdEmpresaRuc And n.idEstablecimiento = GEstableciento.IdEstablecimiento _
                       And n.tipoMovimiento = "PG" _
                       And n.entidadFinanciera = intiDEF And n.fechaProceso.Value.Year = intAnio And n.fechaProceso.Value.Month = intMes
                       Into sumMN = Sum(n.montoSoles), sumME = Sum(n.montoUsd)


        totalMN = Entradas.sumMN.GetValueOrDefault - Salidas.sumMN.GetValueOrDefault
        totalME = Entradas.sumME.GetValueOrDefault - Salidas.sumME.GetValueOrDefault

        Return New documentoCaja With {.montoSoles = totalMN,
                                          .montoUsd = totalME}
    End Function

    Public Function ListaDeCajasPorCerrar(be As documentoCaja) As List(Of documentoCaja)
        Dim lista As New List(Of documentoCaja)
        Dim obj As New documentoCaja
        Dim cierreBL As New cierreCajaBL
        Dim cierre As New cierreCaja
        Dim consulta = (From p In HeliosData.estadosFinancieros
                        Group Join c In HeliosData.documentoCaja
                      On p.idestado Equals c.entidadFinanciera
                      Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where p.idEmpresa = be.idEmpresa _
                            And p.idEstablecimiento = be.idEstablecimiento _
                      And c.periodo = be.periodo
                        Group c By
                      p.idestado, p.descripcion, p.tipo, p.codigo, p.cuenta, c.tipoMovimiento, p.tipocambio
                      Into g = Group
                        Select New With {.idEF = idestado,
                                       .DescripcionEF = descripcion,
                                       .tipoEF = tipo,
                                       .moneda = codigo,
                                       .cuenta = cuenta,
                                       .tipocambio = tipocambio,
                                       g, .ImporteMN = g.Sum(Function(c) If(tipoMovimiento = "PG", c.montoSoles * -1, c.montoSoles)),
                                       .ImporteME = g.Sum(Function(c) If(tipoMovimiento = "PG", c.montoUsd * -1, c.montoUsd))
                                   }
                               ).ToList

        Dim duplicateRows = (From row In consulta
                             Group row By row.idEF, row.DescripcionEF, row.tipoEF, row.moneda, row.cuenta, row.tipocambio Into t = Group
                             Select New With {.idEF = idEF,
                            .DescripCionEF = DescripcionEF,
                            .tipoEF = tipoEF,
                            .moneda = moneda,
                            .tipocambio = tipocambio,
                            .Cuenta = cuenta,
                            .SUmaMN = t.Sum(Function(o) o.ImporteMN),
                            .SUmaME = t.Sum(Function(o) o.ImporteME)}).ToList

        Dim montoMN As Decimal = 0
        Dim montoME As Decimal = 0

        For Each i In duplicateRows
            cierre = cierreBL.RecuperarCierreCajaAnterior(AnioGeneral, MesGeneral - 1, i.idEF)
            If Not IsNothing(cierre) Then
                montoMN = cierre.montoMN.GetValueOrDefault
                montoME = cierre.montoME.GetValueOrDefault
            Else
                montoMN = 0
                montoME = 0
            End If

            Dim c As New documentoCaja
            c = RecuperarSumaEFxitem(i.idEF, AnioGeneral, MesGeneral)
            montoMN = montoMN + c.montoSoles
            montoME = montoME + c.montoUsd

            obj = New documentoCaja() With
                               {
                                .entidadFinanciera = i.idEF,
                                .NombreEntidad = i.DescripCionEF,
                                .tipousuario = i.tipoEF,
                                .moneda = i.moneda,
                                .tipoCambio = i.tipocambio,
                                .codigoLibro = i.Cuenta,
                                .montoSoles = i.SUmaMN.GetValueOrDefault,
                                .montoUsd = i.SUmaME.GetValueOrDefault
                                }
            lista.Add(obj)
        Next
        Return lista

    End Function

    Public Function ListaDeCajasPorCerrar2(be As documentoCaja) As List(Of documentoCaja)
        Dim lista As New List(Of documentoCaja)
        Dim obj As New documentoCaja
        Dim cierreBL As New cierreCajaBL
        Dim cierre As New cierreCaja
        Dim consulta = (From p In HeliosData.estadosFinancieros
                        Where p.idEmpresa = be.idEmpresa).ToList




        Dim montoMN As Decimal = 0
        Dim montoME As Decimal = 0

        For Each i In consulta
            cierre = cierreBL.RecuperarCierreCajaAnterior(AnioGeneral, MesGeneral - 1, i.idestado)
            If Not IsNothing(cierre) Then
                montoMN = cierre.montoMN.GetValueOrDefault
                montoME = cierre.montoME.GetValueOrDefault
            Else
                montoMN = 0
                montoME = 0
            End If

            Dim c As New documentoCaja
            c = RecuperarSumaEFxitem(i.idestado, AnioGeneral, MesGeneral)
            montoMN = montoMN + c.montoSoles
            montoME = montoME + c.montoUsd

            obj = New documentoCaja() With
                               {
                                .entidadFinanciera = i.idestado,
                                .NombreEntidad = i.descripcion,
                                .tipousuario = i.tipo,
                                .moneda = i.codigo,
                                .tipoCambio = i.tipocambio,
                                .codigoLibro = i.cuenta,
                                .montoSoles = montoMN,
                                .montoUsd = montoME
                                }
            lista.Add(obj)
        Next
        Return lista

    End Function

#Region "HISTORIAL PAGO"

    'Private Sub GetEditarCajaDocumento(idDocumento As Integer)
    '    Dim cajaBL As New documentoCajaBL
    '    Dim cajadetBL As New documentoCajaDetalleBL
    '    Dim listapagos = GetPagoByComprobanteV2(idDocumento)
    '    For Each i In listapagos
    '        Dim caja = cajaBL.GetUbicar_documentoCajaPorID(i.idDocumento)
    '        Dim cajadetalle = cajadetBL.GetUbicar_DetallePorIdDocumento(i.idDocumento)
    '        For Each i In cajadetalle
    '            i.docu
    '        Next
    '    Next
    '  End Sub

    Public Function GetPagoByComprobanteV2(idDocumento As Integer) As List(Of documento)
        Dim a As New documentoCaja
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim documentoBE As New documento

        Dim cc = (From c In HeliosData.documentoCaja
                  Join doc In HeliosData.documento On doc.idDocumento Equals c.idDocumento
                  Join det In HeliosData.documentoCajaDetalle On c.idDocumento Equals det.idDocumento
                  Where det.documentoAfectado = idDocumento).Distinct.ToList


        GetPagoByComprobanteV2 = New List(Of documento)
        For Each i In cc
            Dim Listadeta = cajaDetalleBL.GetUbicar_DetallePorIdDocumento(i.doc.idDocumento)
            documentoBE = New documento
            documentoBE = i.doc
            documentoBE.documentoCaja = i.c
            'For Each d In Listadeta
            '    documentoBE.documentoCaja.documentoCajaDetalle.Add(d)
            'Next
            GetPagoByComprobanteV2.Add(documentoBE)
        Next
    End Function

    Public Function GetPagoByComprobante(idDocumento As Integer) As List(Of documento)
        Dim be As documento
        Dim a As New documentoCaja
        Dim cajaDetBL As New documentoCajaDetalleBL
        Dim detail As documentoCajaDetalle
        Dim cc = (From c In HeliosData.documentoCaja
                  Join doc In HeliosData.documento On doc.idDocumento Equals c.idDocumento
                  Join det In HeliosData.documentoCajaDetalle On c.idDocumento Equals det.idDocumento
                  Where det.documentoAfectado = idDocumento).Distinct.ToList



        GetPagoByComprobante = New List(Of documento)
        For Each i In cc
            Dim detalle = cajaDetBL.GetUbicar_DetallePorIdDocumento(i.doc.idDocumento)

            be = New documento With
            {
            .idDocumento = i.doc.idDocumento,
            .idEmpresa = i.doc.idEmpresa,
            .idCentroCosto = i.doc.idCentroCosto,
            .idProyecto = i.doc.idProyecto,
            .tipoDoc = i.doc.tipoDoc,
            .fechaProceso = i.doc.fechaProceso,
            .moneda = i.doc.moneda,
            .idEntidad = i.doc.idEntidad,
            .entidad = i.doc.entidad,
            .tipoEntidad = i.doc.tipoEntidad,
            .nrodocEntidad = i.doc.nrodocEntidad,
            .nroDoc = i.doc.nroDoc,
            .idOrden = i.doc.idOrden,
            .tipoOperacion = i.doc.tipoOperacion,
            .usuarioActualizacion = i.doc.usuarioActualizacion,
            .fechaActualizacion = i.doc.fechaActualizacion
            }

            be.documentoCaja = New documentoCaja With
            {
            .idDocumento = i.c.idDocumento,
            .idEmpresa = i.c.idEmpresa,
            .idEstablecimiento = i.c.idEstablecimiento,
            .codigoLibro = i.c.codigoLibro,
            .tipoMovimiento = i.c.tipoMovimiento,
            .codigoProveedor = i.c.codigoProveedor,
            .idPersonal = i.c.idPersonal,
            .tipoPersona = i.c.tipoPersona,
            .fechaProceso = i.c.fechaProceso,
            .periodo = i.c.periodo,
            .fechaCobro = i.c.fechaCobro,
            .tipoDocPago = i.c.tipoDocPago,
            .formapago = i.c.formapago,
            .numeroDoc = i.c.numeroDoc,
            .moneda = i.c.moneda,
            .entidadFinanciera = i.c.entidadFinanciera,
            .entidadFinancieraDestino = i.c.entidadFinancieraDestino,
            .tipoOperacion = i.c.tipoOperacion,
            .numeroOperacion = i.c.numeroOperacion,
            .tipoCambio = i.c.tipoCambio,
            .montoSoles = i.c.montoSoles,
            .montoUsd = i.c.montoUsd,
            .glosa = i.c.glosa,
            .entregado = i.c.entregado,
            .bancoEntidad = i.c.bancoEntidad,
            .ctaCorrienteDeposito = i.c.ctaCorrienteDeposito,
            .ctaIntebancaria = i.c.ctaIntebancaria,
            .movimientoCaja = i.c.movimientoCaja,
            .idcosto = i.c.idcosto,
            .asientoCosto = i.c.asientoCosto,
            .estado = i.c.estado,
            .estadopago = i.c.estadopago,
            .idCajaUsuario = i.c.idCajaUsuario,
            .usuarioModificacion = i.c.usuarioModificacion,
            .fechaModificacion = i.c.fechaModificacion
            }

            For Each x In detalle
                detail = New documentoCajaDetalle With
                {
                .idDocumento = x.idDocumento,
                .secuencia = x.secuencia,
                .entidadFinanciera = x.entidadFinanciera,
                .fecha = x.fecha,
                .idItem = x.idItem,
                .DetalleItem = x.DetalleItem,
                .otroMN = x.otroMN,
                .codigoLote = x.otroMN,
                .montoSoles = x.montoSoles,
                .montoSolesTransacc = x.montoSolesTransacc,
                .montoUsdTransacc = x.montoUsdTransacc,
                .montoUsd = x.montoUsd,
                .tipoCambioTransacc = x.tipoCambioTransacc,
                .diferTipoCambio = x.diferTipoCambio,
                .entregado = x.entregado,
                .documentoAfectado = x.documentoAfectado,
                .documentoAfectadodetalle = x.documentoAfectadodetalle,
                .idCajaPadre = x.idCajaPadre,
                .estado = x.estado,
                .idCajaUsuario = x.idCajaUsuario,
                .usuarioModificacion = x.usuarioModificacion,
                .fechaModificacion = x.fechaModificacion
                }
                be.documentoCaja.documentoCajaDetalle.Add(detail)
            Next
            '   be.documentoCaja.documentoCajaDetalle = detalle.ToList
            GetPagoByComprobante.Add(be)
        Next
    End Function

    ''' <summary>
    ''' Id comprobante de origen
    ''' </summary>
    ''' <param name="iNtPadre"></param>
    ''' <returns></returns>
    ''' 

    Public Function HistorialCobrosCajeroAdmi(iNtPadre As Integer) As List(Of documentoCaja)
        Dim consulta = ListadoComprobaNtesXidPadre(iNtPadre).Union(ListadoComprobaNtesXidPadreCajero(iNtPadre)).ToList


        Return consulta
    End Function


    Public Function ListadoComprobaNtesXidPadreCajero(iNtPadre As Integer) As List(Of documentoCaja)
        Dim lista As New List(Of documentoCaja)
        Dim a As New documentoCaja

        Dim cc = (From c In HeliosData.documentoCaja
                  Join det In HeliosData.documentoCajaDetalle
                 On c.idDocumento Equals det.idDocumento
                  Join entFinanciera In HeliosData.estadosFinancieros
                          On entFinanciera.idestado Equals c.entidadFinanciera
                  Join formaPagos In HeliosData.tabladetalle
                          On formaPagos.codigoDetalle Equals c.formapago
                  Where det.documentoAfectado = iNtPadre And
                      formaPagos.idtabla = 1
                  Group det By
                      c.idDocumento,
                      c.idEmpresa,
                      c.idEstablecimiento,
                      c.codigoLibro,
                      c.tipoMovimiento,
                      c.codigoProveedor,
                      c.idPersonal,
                      c.tipoPersona,
                      c.fechaProceso,
                      c.periodo,
                      c.fechaCobro,
                      c.tipoDocPago,
                      c.formapago,
                      NombreFormPago = formaPagos.descripcion,
                      c.numeroDoc,
                      c.moneda,
                      NomEnt1 = entFinanciera.descripcion,
                      c.entidadFinanciera,
                      c.entidadFinancieraDestino,
                      c.tipoOperacion,
                      c.numeroOperacion,
                      c.tipoCambio,
                      c.glosa,
                      c.entregado,
                      c.bancoEntidad,
                      c.ctaCorrienteDeposito,
                      c.ctaIntebancaria,
                      c.movimientoCaja,
                      c.idcosto,
                      c.asientoCosto,
                      c.estado,
                      c.estadopago,
                      c.idCajaUsuario,
                      c.usuarioModificacion,
                      c.fechaModificacion,
                       c.montoSoles,
                      c.montoUsd
                      Into g = Group
                  Select New With {
                      .idDocumento = idDocumento,
                      .idEmpresa = idEmpresa,
                      .idEstablecimiento = idEstablecimiento,
                      .codigoLibro = codigoLibro,
                      .tipoMovimiento = tipoMovimiento,
                      .codigoProveedor = codigoProveedor,
                      .idPersonal = idPersonal,
                      .tipoPersona = tipoPersona,
                      .fechaProceso = fechaProceso,
                      .periodo = periodo,
                      .fechaCobro = fechaCobro,
                      .tipoDocPago = tipoDocPago,
                      .formapago = formapago,
                      .NombreFormPago = NombreFormPago,
                      .numeroDoc = numeroDoc,
                      .moneda = moneda,
                      .entidadFinanciera = entidadFinanciera,
                      .NombreEntiFinanciera = NomEnt1,
                      .entidadFinancieraDestino = entidadFinancieraDestino,
                      .tipoOperacion = tipoOperacion,
                      .numeroOperacion = numeroOperacion,
                      .tipoCambio = tipoCambio,
                      .glosa = glosa,
                      .entregado = entregado,
                      .bancoEntidad = bancoEntidad,
                      .ctaCorrienteDeposito = ctaCorrienteDeposito,
                      .ctaIntebancaria = ctaIntebancaria,
                      .movimientoCaja = movimientoCaja,
                      .idcosto = idcosto,
                      .asientoCosto = asientoCosto,
                      .estado = estado,
                      .estadopago = estadopago,
                      .idCajaUsuario = idCajaUsuario,
                      .usuarioModificacion = usuarioModificacion,
                      .fechaModificacion = fechaModificacion,
                      .montoCajaSoles = montoSoles,
                      .montoCajaME = montoUsd,
                      g, .importeMN = g.Sum(Function(c) c.montoSoles),
                      .importeME = g.Sum(Function(c) c.montoUsd)
                      }
                      ).ToList


        For Each i In cc
            a = New documentoCaja
            a.idDocumento = i.idDocumento
            a.idEmpresa = i.idEmpresa
            a.idEstablecimiento = i.idEstablecimiento
            a.codigoLibro = i.codigoLibro
            a.tipoMovimiento = i.tipoMovimiento
            a.codigoProveedor = i.codigoProveedor
            a.idPersonal = i.idPersonal
            a.tipoPersona = i.tipoPersona
            a.fechaProceso = i.fechaProceso
            a.periodo = i.periodo
            a.fechaCobro = i.fechaCobro
            a.tipoDocPago = i.tipoDocPago
            a.formapago = i.NombreFormPago
            a.numeroDoc = i.numeroDoc
            a.moneda = i.moneda
            a.NombreCaja = i.NombreEntiFinanciera
            a.entidadFinanciera = i.entidadFinanciera
            a.entidadFinancieraDestino = i.entidadFinancieraDestino
            a.tipoOperacion = i.tipoOperacion
            a.numeroOperacion = i.numeroOperacion
            a.tipoCambio = i.tipoCambio
            a.glosa = i.glosa
            a.entregado = i.entregado
            a.bancoEntidad = i.bancoEntidad
            a.ctaCorrienteDeposito = i.ctaCorrienteDeposito
            a.ctaIntebancaria = i.ctaIntebancaria
            a.movimientoCaja = i.movimientoCaja
            a.idcosto = i.idcosto
            a.asientoCosto = i.asientoCosto
            a.estado = i.estado
            a.estadopago = i.estadopago
            a.idCajaUsuario = i.idCajaUsuario
            a.usuarioModificacion = i.usuarioModificacion
            a.fechaModificacion = i.fechaModificacion
            a.montoSoles = i.importeMN
            a.montoUsd = i.importeME
            a.montoSolesTransacc = i.montoCajaSoles.GetValueOrDefault
            a.montoUsdTransacc = i.montoCajaME.GetValueOrDefault
            lista.Add(a)
        Next
        Return lista
    End Function


    Public Function ListadoComprobaNtesXidPadre(iNtPadre As Integer) As List(Of documentoCaja)
        Dim lista As New List(Of documentoCaja)
        Dim a As New documentoCaja

        Dim cc = (From c In HeliosData.documentoCaja
                  Join det In HeliosData.documentoCajaDetalle
                 On c.idDocumento Equals det.idDocumento
                  Join entFinanciera In HeliosData.estadosFinancieros
                          On entFinanciera.idestado Equals c.entidadFinancieraDestino
                  Join formaPagos In HeliosData.tabladetalle
                          On formaPagos.codigoDetalle Equals c.formapago
                  Where det.documentoAfectado = iNtPadre And
                      formaPagos.idtabla = 1 And c.entidadFinanciera = Nothing And entFinanciera.tipo <> "EP"
                  Group det By
                      c.idDocumento,
                      c.idEmpresa,
                      c.idEstablecimiento,
                      c.codigoLibro,
                      c.tipoMovimiento,
                      c.codigoProveedor,
                      c.idPersonal,
                      c.tipoPersona,
                      c.fechaProceso,
                      c.periodo,
                      c.fechaCobro,
                      c.tipoDocPago,
                      c.formapago,
                      NombreFormPago = formaPagos.descripcion,
                      c.numeroDoc,
                      c.moneda,
                      NomEnt1 = entFinanciera.descripcion,
                      c.entidadFinanciera,
                      c.entidadFinancieraDestino,
                      c.tipoOperacion,
                      c.numeroOperacion,
                      c.tipoCambio,
                      c.glosa,
                      c.entregado,
                      c.bancoEntidad,
                      c.ctaCorrienteDeposito,
                      c.ctaIntebancaria,
                      c.movimientoCaja,
                      c.idcosto,
                      c.asientoCosto,
                      c.estado,
                      c.estadopago,
                      c.idCajaUsuario,
                      c.usuarioModificacion,
                      c.fechaModificacion,
                       c.montoSoles,
                      c.montoUsd
                      Into g = Group
                  Select New With {
                      .idDocumento = idDocumento,
                      .idEmpresa = idEmpresa,
                      .idEstablecimiento = idEstablecimiento,
                      .codigoLibro = codigoLibro,
                      .tipoMovimiento = tipoMovimiento,
                      .codigoProveedor = codigoProveedor,
                      .idPersonal = idPersonal,
                      .tipoPersona = tipoPersona,
                      .fechaProceso = fechaProceso,
                      .periodo = periodo,
                      .fechaCobro = fechaCobro,
                      .tipoDocPago = tipoDocPago,
                      .formapago = formapago,
                      .NombreFormPago = NombreFormPago,
                      .numeroDoc = numeroDoc,
                      .moneda = moneda,
                      .entidadFinanciera = entidadFinanciera,
                      .NombreEntiFinanciera = NomEnt1,
                      .entidadFinancieraDestino = entidadFinancieraDestino,
                      .tipoOperacion = tipoOperacion,
                      .numeroOperacion = numeroOperacion,
                      .tipoCambio = tipoCambio,
                      .glosa = glosa,
                      .entregado = entregado,
                      .bancoEntidad = bancoEntidad,
                      .ctaCorrienteDeposito = ctaCorrienteDeposito,
                      .ctaIntebancaria = ctaIntebancaria,
                      .movimientoCaja = movimientoCaja,
                      .idcosto = idcosto,
                      .asientoCosto = asientoCosto,
                      .estado = estado,
                      .estadopago = estadopago,
                      .idCajaUsuario = idCajaUsuario,
                      .usuarioModificacion = usuarioModificacion,
                      .fechaModificacion = fechaModificacion,
                      .montoCajaSoles = montoSoles,
                      .montoCajaME = montoUsd,
                      g, .importeMN = g.Sum(Function(c) c.montoSoles),
                      .importeME = g.Sum(Function(c) c.montoUsd)
                      }
                      ).ToList


        For Each i In cc
            a = New documentoCaja
            a.idDocumento = i.idDocumento
            a.idEmpresa = i.idEmpresa
            a.idEstablecimiento = i.idEstablecimiento
            a.codigoLibro = i.codigoLibro
            a.tipoMovimiento = i.tipoMovimiento
            a.codigoProveedor = i.codigoProveedor
            a.idPersonal = i.idPersonal
            a.tipoPersona = i.tipoPersona
            a.fechaProceso = i.fechaProceso
            a.periodo = i.periodo
            a.fechaCobro = i.fechaCobro
            a.tipoDocPago = i.tipoDocPago
            a.formapago = i.NombreFormPago
            a.numeroDoc = i.numeroDoc
            a.moneda = i.moneda
            a.NombreCaja = i.NombreEntiFinanciera
            a.entidadFinanciera = i.entidadFinanciera
            a.entidadFinancieraDestino = i.entidadFinancieraDestino
            a.tipoOperacion = i.tipoOperacion
            a.numeroOperacion = i.numeroOperacion
            a.tipoCambio = i.tipoCambio
            a.glosa = i.glosa
            a.entregado = i.entregado
            a.bancoEntidad = i.bancoEntidad
            a.ctaCorrienteDeposito = i.ctaCorrienteDeposito
            a.ctaIntebancaria = i.ctaIntebancaria
            a.movimientoCaja = i.movimientoCaja
            a.idcosto = i.idcosto
            a.asientoCosto = i.asientoCosto
            a.estado = i.estado
            a.estadopago = i.estadopago
            a.idCajaUsuario = i.idCajaUsuario
            a.usuarioModificacion = i.usuarioModificacion
            a.fechaModificacion = i.fechaModificacion
            a.montoSoles = i.importeMN
            a.montoUsd = i.importeME
            a.montoSolesTransacc = i.montoCajaSoles.GetValueOrDefault
            a.montoUsdTransacc = i.montoCajaME.GetValueOrDefault
            lista.Add(a)
        Next
        Return lista
    End Function



    'Public Function ListadoComprobaNtesXidPadre(iNtPadre As Integer) As List(Of documentoCaja)
    '    Dim lista As New List(Of documentoCaja)
    '    Dim a As New documentoCaja

    '    Dim cc = (From c In HeliosData.documentoCaja
    '              Join det In HeliosData.documentoCajaDetalle
    '             On c.idDocumento Equals det.idDocumento
    '              Where det.documentoAfectado = iNtPadre
    '              Group det By
    '                   c.idDocumento,
    '                  c.formapago,
    '                  c.periodo,
    '                  c.fechaCobro,
    '                  c.fechaProceso,
    '                  c.fechaModificacion,
    '                  c.tipoDocPago,
    '                  c.numeroDoc,
    '                  c.numeroOperacion,
    '                  c.tipoCambio,
    '                  c.moneda,
    '                  c.tipoOperacion
    '                      Into g = Group
    '              Select New With {.idDoc = idDocumento,
    '                  .periodo = periodo,
    '                  .fecha = fechaCobro,
    '                  .fechaProceso = fechaProceso,
    '                  .fechaModificacion = fechaModificacion,
    '                  .formaPago = formapago,
    '                  .TipoDoc = tipoDocPago,
    '                  .NumeroDoc = numeroDoc,
    '                  .NumeroOper = numeroOperacion,
    '                  .moNeda = moneda,
    '                  .tipocambio = tipoCambio,
    '                  .tipoOperacion = tipoOperacion,
    '                  g, .importeMN = g.Sum(Function(c) c.montoSoles),
    '                  .importeME = g.Sum(Function(c) c.montoUsd)
    '                  }
    '                  ).ToList


    '    For Each i In cc
    '        a = New documentoCaja
    '        a.periodo = i.periodo
    '        a.idDocumento = i.idDoc
    '        a.formapago = i.formaPago
    '        a.fechaCobro = i.fecha
    '        a.fechaProceso = i.fechaProceso
    '        a.fechaModificacion = i.fechaModificacion
    '        a.tipoDocPago = i.TipoDoc
    '        a.numeroDoc = i.NumeroDoc
    '        a.numeroOperacion = i.NumeroOper
    '        a.moneda = i.moNeda
    '        a.tipoCambio = i.tipocambio
    '        a.tipoOperacion = i.tipoOperacion
    '        a.montoSoles = i.importeMN
    '        a.montoUsd = i.importeME
    '        lista.Add(a)
    '    Next
    '    Return lista
    'End Function

    'Public Function GetHistorialPagosMembresia(idDocumentoMembresia As Integer) As List(Of documentoCaja)
    '    Dim lista As New List(Of documentoCaja)
    '    Dim a As New documentoCaja

    '    Dim cc = (From c In HeliosData.documentoCaja
    '              Join det In HeliosData.documentoCajaDetalle
    '             On c.idDocumento Equals det.idDocumento
    '              Where det.documentoAfectado = idDocumentoMembresia
    '              Group det By
    '                   c.idDocumento, c.periodo, c.fechaCobro, c.tipoDocPago, c.numeroDoc, c.numeroOperacion, c.tipoCambio, c.moneda, c.tipoOperacion
    '                      Into g = Group
    '              Select New With {.idDoc = idDocumento,
    '                                        .periodo = periodo,
    '                                      .fecha = fechaCobro,
    '                                       .TipoDoc = tipoDocPago,
    '                                       .NumeroDoc = numeroDoc,
    '                                       .NumeroOper = numeroOperacion,
    '                                        .moNeda = moneda,
    '                                        .tipocambio = tipoCambio,
    '                                        .tipoOperacion = tipoOperacion,
    '                                       g, .importeMN = g.Sum(Function(c) c.montoSoles),
    '                                       .importeME = g.Sum(Function(c) c.montoUsd)
    '                                   }
    '                               ).ToList


    '    For Each i In cc
    '        a = New documentoCaja
    '        a.periodo = i.periodo
    '        a.idDocumento = i.idDoc
    '        a.fechaCobro = i.fecha
    '        a.tipoDocPago = i.TipoDoc
    '        a.numeroDoc = i.NumeroDoc
    '        a.numeroOperacion = i.NumeroOper
    '        a.moneda = i.moNeda
    '        a.tipoCambio = i.tipocambio
    '        a.tipoOperacion = i.tipoOperacion
    '        a.montoSoles = i.importeMN
    '        a.montoUsd = i.importeME
    '        lista.Add(a)
    '    Next
    '    Return lista
    'End Function
#End Region

    Public Sub InsertCajadetalle(i As documentocompradetalle, intIdDocumentoCompra As Integer, intIdDocumentoCaja As Integer)
        Dim documentoCajaDetalle As New documentoCajaDetalle

        Using ts As New TransactionScope
            '          For Each i As documentocompradetalle In docBase.documentocompradetalle
            documentoCajaDetalle = New documentoCajaDetalle
            documentoCajaDetalle.idDocumento = intIdDocumentoCaja
            documentoCajaDetalle.documentoAfectado = intIdDocumentoCompra
            documentoCajaDetalle.documentoAfectadodetalle = i.secuencia
            documentoCajaDetalle.fecha = i.FechaDoc
            documentoCajaDetalle.idItem = i.idItem
            documentoCajaDetalle.DetalleItem = i.descripcionItem
            documentoCajaDetalle.montoSoles = i.importe
            documentoCajaDetalle.montoUsd = i.importeUS


            documentoCajaDetalle.entregado = "SI"
            documentoCajaDetalle.diferTipoCambio = 0


            documentoCajaDetalle.usuarioModificacion = i.usuarioModificacion
            documentoCajaDetalle.fechaModificacion = DateTime.Now
            HeliosData.documentoCajaDetalle.Add(documentoCajaDetalle)
            '   Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertCajadetalleVenta(i As documentoventaAbarrotesDet, intIdDocumentoVenta As Integer, intIdDocumentoCaja As Integer, SecVentaDetalle As Integer)
        Dim documentoCajaDetalle As New documentoCajaDetalle

        Using ts As New TransactionScope
            '          For Each i As documentocompradetalle In docBase.documentocompradetalle
            documentoCajaDetalle = New documentoCajaDetalle
            documentoCajaDetalle.idDocumento = intIdDocumentoCaja
            documentoCajaDetalle.documentoAfectado = intIdDocumentoVenta
            documentoCajaDetalle.documentoAfectadodetalle = SecVentaDetalle
            documentoCajaDetalle.fecha = i.FechaDoc
            documentoCajaDetalle.idItem = i.idItem
            documentoCajaDetalle.DetalleItem = i.DetalleItem
            documentoCajaDetalle.montoSoles = i.importeMN
            documentoCajaDetalle.montoUsd = i.importeME


            documentoCajaDetalle.entregado = "SI"
            documentoCajaDetalle.diferTipoCambio = 0


            documentoCajaDetalle.usuarioModificacion = i.usuarioModificacion
            documentoCajaDetalle.fechaModificacion = DateTime.Now
            HeliosData.documentoCajaDetalle.Add(documentoCajaDetalle)
            '   Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function InsertDocumentoCaja(docBase As documentocompra) As Integer
        Dim documentoCaja As New documentoCaja
        Dim documento As New documento
        Dim documentoBL As New documentoBL
        Dim codigoReturn As Integer = 0


        Using ts As New TransactionScope

            documento = New documento
            documento.idEmpresa = Gempresas.IdEmpresaRuc
            documento.idCentroCosto = GEstableciento.IdEstablecimiento
            documento.tipoDoc = "109"
            documento.fechaProceso = docBase.fechaDoc
            documento.nroDoc = Nothing
            documento.idOrden = Nothing
            documento.tipoOperacion = "9907"
            documento.usuarioActualizacion = docBase.usuarioActualizacion
            documento.fechaActualizacion = docBase.fechaActualizacion
            documentoBL.Insert(documento)
            codigoReturn = documento.idDocumento
            With documentoCaja
                .idDocumento = codigoReturn
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .codigoLibro = "9907"
                .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                .codigoProveedor = Nothing
                .fechaProceso = docBase.fechaDoc
                .periodo = PeriodoGeneral
                .fechaCobro = docBase.fechaDoc
                .tipoDocPago = "109"
                .numeroDoc = Nothing
                .moneda = docBase.monedaDoc
                .entidadFinanciera = docBase.CajaSeleccionada
                '.entidadFinancieraDestino = Nothing
                .numeroOperacion = Nothing
                .tipoCambio = 3.0
                .montoSoles = docBase.importeTotal
                .montoUsd = docBase.importeUS
                .glosa = docBase.glosa
                .entregado = "SI"
                .bancoEntidad = Nothing
                .ctaCorrienteDeposito = Nothing
                .usuarioModificacion = docBase.usuarioActualizacion
                .fechaModificacion = DateTime.Now
            End With
            HeliosData.documentoCaja.Add(documentoCaja)
            HeliosData.SaveChanges()
            ts.Complete()
            Return codigoReturn
        End Using
    End Function

    Public Function InsertDocumentoCajaVenta(docBase As documentoventaAbarrotes) As Integer
        Dim documentoCaja As New documentoCaja
        Dim documento As New documento
        Dim documentoBL As New documentoBL
        Dim codigoReturn As Integer = 0
        Dim SumMN As Decimal = 0
        Dim SumME As Decimal = 0

        Using ts As New TransactionScope
            SumMN = 0
            SumME = 0
            For Each i In docBase.documentoventaAbarrotesDet
                If i.estadoPago = TIPO_VENTA.PAGO.COBRADO Then
                    SumMN += i.importeMN
                    SumME += i.importeME
                End If
            Next
            documento = New documento
            documento.idEmpresa = docBase.idEmpresa
            documento.idCentroCosto = docBase.idEstablecimiento
            documento.tipoDoc = "109"
            documento.fechaProceso = docBase.fechaDoc
            documento.nroDoc = docBase.serieVenta & "-" & docBase.numeroVenta
            documento.idOrden = Nothing
            documento.tipoOperacion = "9908"
            documento.usuarioActualizacion = docBase.usuarioActualizacion
            documento.fechaActualizacion = docBase.fechaActualizacion
            documentoBL.Insert(documento)
            codigoReturn = documento.idDocumento
            With documentoCaja
                .movimientoCaja = MovimientoCaja.VentaDirectaPOS
                .idDocumento = codigoReturn
                .idEmpresa = docBase.idEmpresa
                .idEstablecimiento = docBase.idEstablecimiento
                .codigoLibro = "14"
                .tipoOperacion = "9908"
                .tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                .codigoProveedor = Nothing
                .fechaProceso = docBase.fechaDoc
                .periodo = PeriodoGeneral
                .fechaCobro = docBase.fechaDoc
                .tipoDocPago = "109"
                .numeroDoc = Nothing

                .moneda = docBase.moneda
                .entidadFinanciera = docBase.CajaSeleccionada
                '.entidadFinancieraDestino = Nothing
                .numeroOperacion = Nothing
                .tipoCambio = docBase.tipoCambio
                .montoSoles = SumMN
                .montoUsd = SumME
                .glosa = docBase.glosa
                .entregado = "SI"
                .bancoEntidad = Nothing
                .ctaCorrienteDeposito = Nothing
                .usuarioModificacion = docBase.usuarioActualizacion ' CStr(docBase.usuarioActualizacion)
                .fechaModificacion = DateTime.Now
            End With
            HeliosData.documentoCaja.Add(documentoCaja)
            HeliosData.SaveChanges()
            ts.Complete()
            Return codigoReturn
        End Using
    End Function


    Public Function ResumenTransaccionesFullUsers(intIdPadre As Integer, strTipoMov As String) As List(Of documentoCaja)
        Dim lista As New List(Of documentoCaja)
        Dim obj As New documentoCaja


        Dim con = (From i In HeliosData.cajaUsuario
                   Join per In HeliosData.Persona
                  On per.idPersona Equals i.idPersona And per.idEmpresa Equals i.idEmpresa
                   Group Join caja In HeliosData.documentoCaja
                  On caja.usuarioModificacion Equals i.idcajaUsuario
                  Into ords = Group
                   From c In ords.DefaultIfEmpty
                   Where i.idPadre = intIdPadre And c.tipoMovimiento = strTipoMov
                   Group c By
                      per.nombreCompleto, i.idPersona
                          Into g = Group
                   Select New With {.Perso = nombreCompleto,
                                          .idperso = idPersona,
                                           g, .importeMN = g.Sum(Function(c) c.montoSoles),
                                           .importeME = g.Sum(Function(c) c.montoUsd)
                                       }
                                   ).ToList


        For Each i In con
            obj = New documentoCaja
            obj.IdProveedor = i.idperso
            obj.NombreEntidad = i.Perso
            obj.montoSoles = i.importeMN
            obj.montoUsd = i.importeME
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function ResumenTransaccionesUsuarios(intIdUserCaja As Integer, strTipoMov As String) As documentoCaja
        Dim docCaja As New documentoCaja
        Dim listaUsers As New List(Of String)

        Dim users = (From i In HeliosData.cajaUsuario
                     Where i.idPadre = intIdUserCaja).ToList

        For Each i In users
            listaUsers.Add(i.idcajaUsuario)
        Next

        Dim totalTra = Aggregate n In HeliosData.documentoCaja
                  Where listaUsers.Contains(n.usuarioModificacion) And n.tipoMovimiento = strTipoMov
           Into mn = Sum(n.montoSoles),
                mne = Sum(n.montoUsd)


        docCaja = New documentoCaja
        docCaja.usuarioModificacion = "Per"
        docCaja.montoSoles = totalTra.mn.GetValueOrDefault
        docCaja.montoUsd = totalTra.mne.GetValueOrDefault


        Return docCaja
    End Function

    Public Function ResumenTransaccionesxUsuarioDEP(intIdUserCaja As Integer) As documentoCaja
        Dim docCaja As New documentoCaja
        Dim lista As New List(Of String)
        lista.Add("105")
        lista.Add("17")
        lista.Add("9906")

        Dim totalTra = Aggregate n In HeliosData.documentoCaja
                  Where n.usuarioModificacion = intIdUserCaja And n.tipoMovimiento = "DC" And Not lista.Contains(n.codigoLibro)
           Into mn = Sum(n.montoSoles),
                mne = Sum(n.montoUsd)

        Dim totalTra2 = Aggregate n In HeliosData.documentoCaja
                 Where n.usuarioModificacion = intIdUserCaja And n.tipoMovimiento = "PG" And Not lista.Contains(n.codigoLibro)
          Into mn = Sum(n.montoSoles),
               mne = Sum(n.montoUsd)


        docCaja = New documentoCaja
        docCaja.usuarioModificacion = "Per"
        docCaja.MontoIngresosMN = totalTra.mn.GetValueOrDefault
        docCaja.MontoIngresosME = totalTra.mne.GetValueOrDefault
        docCaja.MontoEgresosMN = totalTra2.mn.GetValueOrDefault
        docCaja.MontoEgresosME = totalTra2.mne.GetValueOrDefault


        Return docCaja
    End Function

    Public Function GetSaldoCuentaFinancieraXusuario(documentoBE As documentoCaja) As documentoCaja
        Dim docCaja As New documentoCaja
        Dim lista As New List(Of String)
        lista.Add("105")

        Dim totalTra = Aggregate n In HeliosData.documentoCaja
                  Where n.usuarioModificacion = documentoBE.usuarioModificacion And n.tipoMovimiento = "DC" And Not lista.Contains(n.codigoLibro) And n.entidadFinanciera = documentoBE.entidadFinanciera
           Into mn = Sum(n.montoSoles),
                mne = Sum(n.montoUsd)

        Dim totalTra2 = Aggregate n In HeliosData.documentoCaja
                 Where n.usuarioModificacion = documentoBE.usuarioModificacion And n.tipoMovimiento = "PG" And Not lista.Contains(n.codigoLibro) And n.entidadFinanciera = documentoBE.entidadFinanciera
          Into mn = Sum(n.montoSoles),
               mne = Sum(n.montoUsd)


        docCaja = New documentoCaja
        docCaja.usuarioModificacion = "Per"
        docCaja.MontoIngresosMN = totalTra.mn.GetValueOrDefault
        docCaja.MontoIngresosME = totalTra.mne.GetValueOrDefault
        docCaja.MontoEgresosMN = totalTra2.mn.GetValueOrDefault
        docCaja.MontoEgresosME = totalTra2.mne.GetValueOrDefault


        Return docCaja
    End Function

    Public Function GetCobrosPorMes(intIdEstablecimiento As Integer, anio As String) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim listaTipoSituacion As New List(Of String)
        Dim objRecurso As New documentoCaja

        Dim consulta = (From doc In HeliosData.documento
                        Group Join compra In HeliosData.documentoCaja
                      On doc.idDocumento Equals compra.idDocumento
                      Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where c.fechaProceso.Value.Year = anio _
                      And c.idEstablecimiento = intIdEstablecimiento _
                      And c.tipoMovimiento = "DC"
                        Group c By
                      c.periodo
                          Into g = Group
                        Select New With {.fecha = periodo,
                                          g, .CountCompras = g.Count(Function(c) c.idEmpresa),
                                           .importeMN = g.Sum(Function(c) c.montoSoles),
                                           .importeME = g.Sum(Function(c) c.montoUsd)
                                       }
                                   )


        For Each obj In consulta
            objRecurso = New documentoCaja
            objRecurso.periodo = obj.fecha
            'objRecurso.tipoVenta = obj.tipoVenta
            'objRecurso.CountVentas = obj.CountCompras
            objRecurso.montoSoles = obj.importeMN
            objRecurso.montoUsd = obj.importeME
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function

    Public Function ObtenerCajaPagoPorVentaSL(ByVal idDocumentoVenta As Integer) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja
        Dim consulta = (From n In HeliosData.documentoCaja
                        Group Join EF In HeliosData.documentoCajaDetalle
                       On n.idDocumento Equals EF.idDocumento
                        Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where c.documentoAfectado = idDocumentoVenta
                        Group n By
                  n.codigoLibro, n.montoSoles, n.montoUsd
                   Into g = Group
                        Select New With {.codigoLibro = codigoLibro,
                                    .TotalMontoMN = montoSoles,
                                      .TotalMontoME = montoUsd}
                          ).FirstOrDefault

        'For Each items In consulta4
        If (Not IsNothing(consulta)) Then
            docCuenta = New documentoCaja
            docCuenta.idDocumento = idDocumentoVenta
            docCuenta.codigoLibro = consulta.codigoLibro
            docCuenta.montoSoles = consulta.TotalMontoMN
            docCuenta.montoUsd = consulta.TotalMontoME
            Lista.Add(docCuenta)
        End If

        'Next

        Dim consultaAnt = (From n In HeliosData.documentoAnticipoDetalle
                           Where n.docAfectado = idDocumentoVenta
                           Group n By
                 n.codigoOperacion
                  Into g = Group
                           Select New With {.codigoLibro = codigoOperacion,
                                        g, .TotalMontoMN = g.Sum(Function(p) p.importeMN),
                                   .TotalMontoME = g.Sum(Function(p) p.importeME)
                         }).FirstOrDefault

        If (Not IsNothing(consultaAnt)) Then
            docCuenta = New documentoCaja
            docCuenta.idDocumento = idDocumentoVenta
            docCuenta.codigoLibro = consultaAnt.codigoLibro
            docCuenta.montoSoles = consultaAnt.TotalMontoMN
            docCuenta.montoUsd = consultaAnt.TotalMontoME
            Lista.Add(docCuenta)
        End If
        Return Lista
    End Function

    Public Function GetListarPagosPorANioReporte(ANio As Integer, strTipoMov As String) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim listaTipoCompra As New List(Of String)
        Dim objRecurso As New documentoCaja

        Dim consulta = (From compra In HeliosData.documentoCaja
                        Where compra.fechaProceso.Value.Year = ANio _
                       And compra.idEmpresa = Gempresas.IdEmpresaRuc _
                       And compra.tipoMovimiento = strTipoMov
                        Group compra By
                       compra.periodo Into g = Group
                        Select New With {g, .SumaMN = g.Sum(Function(c) c.montoSoles),
                                            .SumaME = g.Sum(Function(c) c.montoUsd),
                                         .fecha = periodo}
                                 ).ToList

        For Each obj In consulta
            objRecurso = New documentoCaja
            objRecurso.periodo = obj.fecha
            objRecurso.montoSoles = obj.SumaMN
            objRecurso.montoUsd = obj.SumaME
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function


#Region "CIERRES CAJAS"
    Public Function GetObtenerCierreCajasModulos(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, intIdUser As String) As List(Of documentoCaja)
        Dim ListaTipoOperacion As New List(Of String)
        ListaTipoOperacion.Add("02")
        ListaTipoOperacion.Add("01")
        ListaTipoOperacion.Add("100")
        ListaTipoOperacion.Add("101")
        ListaTipoOperacion.Add("104")
        ListaTipoOperacion.Add("9907")
        ListaTipoOperacion.Add("9908")
        ListaTipoOperacion.Add("12.1")
        ListaTipoOperacion.Add("12.2")
        ListaTipoOperacion.Add("103")


        'Group Join c In HeliosData.cajaUsuario _
        'On p.usuarioModificacion Equals c.idcajaUsuario _
        'Into ords = Group _
        'From c In ords.DefaultIfEmpty _

        Dim mov As New documentoCaja
        Dim lista As New List(Of documentoCaja)
        Dim consulta = (From p In HeliosData.documentoCaja
                        Where p.idEmpresa = strEmpresa _
                  And p.idEstablecimiento = intIdEstablecimiento _
                  And p.periodo = strPeriodo _
                  And p.usuarioModificacion = intIdUser _
                  And ListaTipoOperacion.Contains(p.codigoLibro)
                        Group p By
                  p.codigoLibro, p.usuarioModificacion
                  Into g = Group
                        Select New With {.codigoLibro = codigoLibro,
                                  g, .TotalMontoMN = g.Sum(Function(p) p.montoSoles),
                                   .TotalMontoME = g.Sum(Function(p) p.montoUsd)
                              }
                          ).ToList


        For Each i In consulta
            mov = New documentoCaja
            mov.codigoLibro = i.codigoLibro
            mov.montoSoles = i.TotalMontoMN
            mov.montoUsd = i.TotalMontoME
            lista.Add(mov)
        Next
        Return lista
    End Function

#End Region

    Public Function SumaxTipoEF(strTipo As String, strTipoMov As String) As documentoCaja


        Dim totals3 = Aggregate p In HeliosData.documentoCaja
                      Join ef In HeliosData.estadosFinancieros
                      On p.entidadFinanciera Equals ef.idestado
                            Where ef.tipo = strTipo And p.tipoMovimiento = strTipoMov _
                            And p.idEmpresa = Gempresas.IdEmpresaRuc
            Into mn = Sum(p.montoSoles),
                 mne = Sum(p.montoUsd)


        Dim EFX As New documentoCaja With {.montoSoles = totals3.mn.GetValueOrDefault,
                                          .montoUsd = totals3.mne.GetValueOrDefault}

        Return EFX

    End Function

    'Public Function BalanceByTipoEF(strTipo As String, strTipoMov As String) As documentoCaja


    '    Dim totals3 = Aggregate p In HeliosData.documentoCaja _
    '                  Join ef In HeliosData.estadosFinancieros _
    '                  On p.entidadFinanciera Equals ef.idestado _
    '                        Where ef.tipo = strTipo And p.tipoMovimiento = strTipoMov _
    '                        And p.idEmpresa = Gempresas.IdEmpresaRuc _
    '        Into mn = Sum(p.montoSoles), _
    '             mne = Sum(p.montoUsd)


    '    Dim EFX As New documentoCaja With {.montoSoles = totals3.mn.GetValueOrDefault,
    '                                      .montoUsd = totals3.mne.GetValueOrDefault}

    '    Return EFX

    'End Function

    Public Function SumaxINgresosEgresos(strTipoMov As String) As List(Of documentoCaja)
        Dim EFX As New documentoCaja
        Dim lista As New List(Of documentoCaja)
        'Dim totals3 = Aggregate p In HeliosData.documentoCaja _
        '                    Where p.idEmpresa = Gempresas.IdEmpresaRuc _
        '                    And p.fechaCobro.Value.Month = MesGeneral _
        '                    And p.fechaCobro.Value.Year = AnioGeneral _
        '    Into mn = Sum(p.montoSoles), _
        '         mne = Sum(p.montoUsd)


        Dim totales = (From p In HeliosData.documentoCaja
                       Where p.idEmpresa = Gempresas.IdEmpresaRuc _
                            And p.fechaCobro.Value.Month = MesGeneral _
                            And p.fechaCobro.Value.Year = AnioGeneral
                       Group p By
                  p.tipoMovimiento
                  Into g = Group
                       Select New With {.tipoMov = tipoMovimiento,
                                  g, .TotalMontoMN = g.Sum(Function(p) p.montoSoles),
                                   .TotalMontoME = g.Sum(Function(p) p.montoUsd)
                              }
                          ).ToList


        For Each i In totales
            '   EFX = New documentoCaja

            If totales.Count = 1 Then


                Select Case i.tipoMov
                    Case "PG"

                        EFX = New documentoCaja
                        EFX.tipoMovimiento = "CB"
                        EFX.montoSoles = 0
                        EFX.montoUsd = 0
                        lista.Add(EFX)

                        EFX = New documentoCaja
                        EFX.tipoMovimiento = i.tipoMov
                        EFX.montoSoles = i.TotalMontoMN.GetValueOrDefault
                        EFX.montoUsd = i.TotalMontoME.GetValueOrDefault
                        lista.Add(EFX)


                    Case Else

                        EFX = New documentoCaja
                        EFX.tipoMovimiento = i.tipoMov
                        EFX.montoSoles = i.TotalMontoMN.GetValueOrDefault
                        EFX.montoUsd = i.TotalMontoME.GetValueOrDefault
                        lista.Add(EFX)

                        EFX = New documentoCaja
                        EFX.tipoMovimiento = "PG"
                        EFX.montoSoles = 0
                        EFX.montoUsd = 0
                        lista.Add(EFX)



                End Select

            Else 'mayor a cero y a uNo
                EFX = New documentoCaja
                EFX.tipoMovimiento = i.tipoMov
                EFX.montoSoles = i.TotalMontoMN.GetValueOrDefault
                EFX.montoUsd = i.TotalMontoME.GetValueOrDefault
                lista.Add(EFX)
            End If


        Next


        Return lista

    End Function

    Public Function SumaxINgresosEgresosAnual() As List(Of documentoCaja)
        Dim EFX As New documentoCaja
        Dim lista As New List(Of documentoCaja)

        Dim totales = (From p In HeliosData.documentoCaja
                       Where p.idEmpresa = Gempresas.IdEmpresaRuc _
                            And p.fechaCobro.Value.Year = AnioGeneral
                       Group p By
                  p.tipoMovimiento
                  Into g = Group
                       Select New With {.tipoMov = tipoMovimiento,
                                  g, .TotalMontoMN = g.Sum(Function(p) p.montoSoles),
                                   .TotalMontoME = g.Sum(Function(p) p.montoUsd)
                              }
                          ).ToList


        For Each i In totales
            '   EFX = New documentoCaja

            If totales.Count = 1 Then


                Select Case i.tipoMov
                    Case "PG"

                        EFX = New documentoCaja
                        EFX.tipoMovimiento = "CB"
                        EFX.montoSoles = 0
                        EFX.montoUsd = 0
                        lista.Add(EFX)

                        EFX = New documentoCaja
                        EFX.tipoMovimiento = i.tipoMov
                        EFX.montoSoles = i.TotalMontoMN.GetValueOrDefault
                        EFX.montoUsd = i.TotalMontoME.GetValueOrDefault
                        lista.Add(EFX)


                    Case Else

                        EFX = New documentoCaja
                        EFX.tipoMovimiento = i.tipoMov
                        EFX.montoSoles = i.TotalMontoMN.GetValueOrDefault
                        EFX.montoUsd = i.TotalMontoME.GetValueOrDefault
                        lista.Add(EFX)

                        EFX = New documentoCaja
                        EFX.tipoMovimiento = "PG"
                        EFX.montoSoles = 0
                        EFX.montoUsd = 0
                        lista.Add(EFX)



                End Select

            Else 'mayor a cero y a uNo
                EFX = New documentoCaja
                EFX.tipoMovimiento = i.tipoMov
                EFX.montoSoles = i.TotalMontoMN.GetValueOrDefault
                EFX.montoUsd = i.TotalMontoME.GetValueOrDefault
                lista.Add(EFX)
            End If


        Next


        Return lista

    End Function

    Public Sub EditarGroupCaja(objDocumentoBE As documento)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cierreCajaBL As New cierreCajaBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Try

            Dim fechaActual = New Date(objDocumentoBE.documentoCaja.fechaProceso.Value.Year, objDocumentoBE.documentoCaja.fechaProceso.Value.Month, 1)
            Dim fechaAnterior = fechaActual.AddMonths(-1)

            'si es false es porque no esta dentro del inicio de operaciones
            Dim valor = empresaCierreMensualBL.GetValidaFechaInicioOperacion(objDocumentoBE.idEmpresa, fechaActual, objDocumentoBE.idCentroCosto)
            If valor = "False" Then
                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month, objDocumentoBE.idCentroCosto) = False Then
                    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                End If
            ElseIf valor = "True" Then
                Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
            Else
                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                'If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month) = False Then
                '    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                'End If
            End If


            Using ts As New TransactionScope()
                documentoBL.Update(objDocumentoBE)
                Me.Update(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                AsientoBL.DeleteGroup(objDocumentoBE.idDocumento)
                cajaDetalleBL.EditarGrupo(objDocumentoBE, objDocumentoBE.idDocumento)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ConciliarCheque(objDocCaja As documentoCaja, objDocumentoBE As documento, cajaUsuario As cajaUsuario)
        Dim AsientoBL As New AsientoBL
        Dim CajaUsuarioBL As New CajaUsuarioBL

        Try
            If Not IsNothing(objDocCaja.numeroOperacion) Then
                Dim consultaValida = (From i In HeliosData.documentoCaja
                                      Where i.entregado = "SI" And i.idDocumento = objDocCaja.idDocumento).Count

                If consultaValida > 0 Then
                    Throw New Exception("El cheque ya fue conciliado")
                Else
                    Using ts As New TransactionScope()
                        Dim docCaja As documentoCaja = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = objDocCaja.idDocumento).First
                        docCaja.fechaCobro = objDocCaja.fechaCobro
                        docCaja.numeroOperacion = objDocCaja.numeroOperacion
                        docCaja.entregado = objDocCaja.entregado
                        'HeliosData.ObjectStateManager.GetObjectStateEntry(docCaja).State.ToString()

                        CajaUsuarioBL.ActualizarMontoCajaUsuarioCompras(cajaUsuario)
                        AsientoBL.SavebyGroupDoc(objDocumentoBE)
                        HeliosData.SaveChanges()
                        ts.Complete()
                    End Using
                End If
            Else
                Using ts As New TransactionScope()
                    Dim docCaja As documentoCaja = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = objDocCaja.idDocumento).First
                    docCaja.fechaCobro = objDocCaja.fechaCobro
                    docCaja.numeroOperacion = objDocCaja.numeroOperacion
                    docCaja.entregado = objDocCaja.entregado
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(docCaja).State.ToString()

                    CajaUsuarioBL.DeleteTotalesCajaUsuarioDocCajaDetalle(objDocumentoBE.idDocumento, objDocumentoBE.usuarioActualizacion, objDocumentoBE.IdDocumentoAfectado)
                    AsientoBL.DeleteGroup(objDocumentoBE.idDocumento)

                    HeliosData.SaveChanges()
                    ts.Complete()
                End Using
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function VerificarConciliarCheque(objDocCaja As documentoCaja) As Boolean
        Try
            Select Case objDocCaja.entregado
                Case "SI"
                    Dim consultaValida = (From i In HeliosData.documentoCaja
                                          Where i.entregado = "SI" And i.idDocumento = objDocCaja.idDocumento).Count

                    If consultaValida > 0 Then
                        Throw New Exception("El cheque ya fue conciliado")
                    Else
                        Return True
                    End If
                Case "NO"
                    Dim consultaValida = (From i In HeliosData.documentoCaja
                                          Where i.entregado = "NO" And i.idDocumento = objDocCaja.idDocumento).Count

                    If consultaValida = 0 Then
                        Return True
                    Else
                        Throw New Exception("Cheque sin conciliar")
                    End If
            End Select


        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function

    Public Function SaveGroupCaja(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Try
            Using ts As New TransactionScope()
                Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                Dim ventaoriginal As documentocompra = (HeliosData.documentocompra.Where(Function(o) _
                                                            o.idDocumento = codigoPadre)).FirstOrDefault

                documentoBL.Insert(objDocumentoBE)
                idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertPagosDeCajaCompra(objDocumentoBE, idDocumentoRecuperado)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)


                Dim ventaDetalle = (From n In HeliosData.documentocompradetalle
                                    Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count

                If ventaDetalle > 0 Then
                    ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                Else
                    ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                End If

                HeliosData.SaveChanges()
                ts.Complete()
                Return idDocumentoRecuperado

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveGroupCajaVentas(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Try
            Using ts As New TransactionScope()
                Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                Dim ventaoriginal As documentoventaAbarrotes = (HeliosData.documentoventaAbarrotes.Where(Function(o) _
                                                            o.idDocumento = codigoPadre)).FirstOrDefault

                documentoBL.Insert(objDocumentoBE)
                idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertPagosDeCaja(objDocumentoBE, idDocumentoRecuperado)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)


                Dim ventaDetalle = (From n In HeliosData.documentoventaAbarrotesDet
                                    Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO).Count

                If ventaDetalle > 0 Then
                    ventaoriginal.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                Else
                    ventaoriginal.estadoCobro = TIPO_VENTA.PAGO.COBRADO
                End If


                HeliosData.SaveChanges()
                ts.Complete()
                Return idDocumentoRecuperado
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GrabarExcedenteCompra(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Try
            Using ts As New TransactionScope()
                Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                Dim ventaoriginal As documentocompra = (HeliosData.documentocompra.Where(Function(o) _
                                                            o.idDocumento = codigoPadre)).FirstOrDefault

                documentoBL.Insert(objDocumentoBE)
                idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertPagosDeCajaCompra(objDocumentoBE, idDocumentoRecuperado)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)


                Dim ventaDetalle = (From n In HeliosData.documentocompradetalle
                                    Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO).Count

                If ventaDetalle > 0 Then
                    ventaoriginal.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                Else
                    ventaoriginal.estadoPago = TIPO_VENTA.PAGO.COBRADO
                End If

                HeliosData.SaveChanges()
                ts.Complete()
                Return idDocumentoRecuperado
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GrabarExcedenteVenta(objDocumentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Try
            Using ts As New TransactionScope()
                Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                Dim ventaoriginal As documentoventaAbarrotes = (HeliosData.documentoventaAbarrotes.Where(Function(o) _
                                                            o.idDocumento = codigoPadre)).FirstOrDefault

                documentoBL.Insert(objDocumentoBE)
                idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertPagosDeCaja(objDocumentoBE, idDocumentoRecuperado)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)


                Dim ventaDetalle = (From n In HeliosData.documentoventaAbarrotesDet
                                    Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count

                If ventaDetalle > 0 Then
                    ventaoriginal.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                Else
                    ventaoriginal.estadoCobro = TIPO_COMPRA.PAGO.PAGADO
                End If

                HeliosData.SaveChanges()
                ts.Complete()
                Return idDocumentoRecuperado
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveGroupCajaNotas(objDocumentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cImporteCompraMN As Decimal = 0
        Dim cImporteCompraME As Decimal = 0
        Dim cNCmn As Decimal = 0
        Dim cNCme As Decimal = 0
        Dim NBmn As Decimal = 0
        Dim NBme As Decimal = 0
        Dim cImportePagadomn As Decimal = 0
        Dim cImportePagadome As Decimal = 0
        Dim Totalmn As Decimal = 0
        Dim Totalme As Decimal = 0
        Dim intIdCompra As Integer

        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0
        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim CajaUsuarioBL As New CajaUsuarioBL
        Dim idDocumentoRecuperado As Integer
        Try
            Using ts As New TransactionScope()

                intIdCompra = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                Dim nDocumentoCompra As documentocompra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = intIdCompra).First
                '   
                Dim MontoPagadoDec As Decimal? = (From i In HeliosData.documentoCajaDetalle
                                                  Where i.documentoAfectado = intIdCompra
                                                  Select i.montoSoles).Sum

                If IsNothing(MontoPagadoDec) Then
                    MontoPagadoDec = 0
                End If


                '     Dim conDetalleCompra As List(Of documentocompradetalle) = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = intIdCompra).ToList
                Dim totals3 = Aggregate p In HeliosData.documentocompradetalle
                              Where p.idDocumento = intIdCompra
              Into mn = Sum(p.importe),
                   mne = Sum(p.importeUS)



                cTotalmn = totals3.mn '- NC.NCmn.GetValueOrDefault + DB.DBmn.GetValueOrDefault
                cTotalme = totals3.mne '- NC.NCmne.GetValueOrDefault + DB.DBmne.GetValueOrDefault

                '  End If

                With nDocumentoCompra
                    If MontoPagadoDec >= cTotalmn Then
                        Throw New Exception("El documento ya está pagado!")
                    Else
                        cImporteCompraMN = objDocumentoBE.documentoCaja.DeudaEvalMN
                        cImporteCompraME = objDocumentoBE.documentoCaja.DeudaEvalME
                        cImportePagadomn = objDocumentoBE.documentoCaja.montoSoles
                        cImportePagadome = objDocumentoBE.documentoCaja.montoUsd
                        documentoBL.Insert(objDocumentoBE)
                        idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                        cajaDetalleBL.Insert(objDocumentoBE, objDocumentoBE.idDocumento, objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado)
                        AsientoBL.SavebyGroupDoc(objDocumentoBE)
                        Totalmn = cImporteCompraMN - cImportePagadomn
                        If Totalmn <= 0 Then
                            'documento pagado
                            .estadoPago = Nota_Credito.DINERO_ENTREGADO
                            'HeliosData.ObjectStateManager.GetObjectStateEntry(nDocumentoCompra).State.ToString()
                        Else
                            .estadoPago = Nota_Credito.DINERO_PENDIENTE_DE_ENTREGA
                            'HeliosData.ObjectStateManager.GetObjectStateEntry(nDocumentoCompra).State.ToString()
                        End If

                        HeliosData.SaveChanges()
                        ts.Complete()
                        Return idDocumentoRecuperado
                    End If

                End With
                '    End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function SaveGroupCajaPrestamo(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cImporteCompraMN As Decimal = 0
        Dim cImporteCompraME As Decimal = 0
        Dim cNCmn As Decimal = 0
        Dim cNCme As Decimal = 0
        Dim NBmn As Decimal = 0
        Dim NBme As Decimal = 0
        Dim cImportePagadomn As Decimal = 0
        Dim cImportePagadome As Decimal = 0
        Dim Totalmn As Decimal = 0
        Dim Totalme As Decimal = 0
        Dim intIdCompra As Integer

        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0
        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim CajaUsuarioBL As New CajaUsuarioBL
        Dim idDocumentoRecuperado As Integer
        Dim TipoCobro As String
        Try
            Using ts As New TransactionScope()
                intIdCompra = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                TipoCobro = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).entregado
                Dim nDocumentoCompra As prestamos = HeliosData.prestamos.Where(Function(o) o.idDocumento = intIdCompra).First
                '   


                '    If conDetalleCompra.Count > 0 Then
                Select Case TipoCobro

                    Case "C"
                        Dim totals3 = Aggregate p In HeliosData.documentoCajaDetalle
                        Where p.documentoAfectado = intIdCompra And p.entregado = "C"
                        Into nc = Sum(p.montoSoles),
                        nce = Sum(p.montoUsd)

                        cTotalmn = nDocumentoCompra.monto - totals3.nc.GetValueOrDefault
                        cTotalme = nDocumentoCompra.montoUSD - totals3.nce.GetValueOrDefault
                    Case "I"

                        Dim totals3 = Aggregate p In HeliosData.documentoCajaDetalle
                        Where p.documentoAfectado = intIdCompra And p.entregado = "I"
                        Into nc = Sum(p.montoSoles),
                        nce = Sum(p.montoUsd)



                    Case "S"

                        Dim totals3 = Aggregate p In HeliosData.documentoCajaDetalle
                        Where p.documentoAfectado = intIdCompra And p.entregado = "S"
                        Into nc = Sum(p.montoSoles),
                        nce = Sum(p.montoUsd)



                    Case "T"

                        Dim totals3 = Aggregate p In HeliosData.documentoCajaDetalle
                        Where p.documentoAfectado = intIdCompra And p.entregado = "T"
                        Into nc = Sum(p.montoSoles),
                        nce = Sum(p.montoUsd)

                        cTotalmn = (nDocumentoCompra.monto - totals3.nc.GetValueOrDefault)
                        cTotalme = (nDocumentoCompra.montoUSD - totals3.nce.GetValueOrDefault)


                End Select

                '  End If

                With nDocumentoCompra
                    'If MontoPagadoDec >= cTotalmn Then
                    '    Throw New Exception("El prestamo ya está cobrado!")
                    'Else


                    '    Totalmn = cImporteCompraMN - cImportePagadomn
                    If cTotalmn <= 0 Then
                        'documento pagado

                        .estado = TIPO_VENTA.PAGO.COBRADO
                        'HeliosData.ObjectStateManager.GetObjectStateEntry(nDocumentoCompra).State.ToString()
                        Throw New Exception("El prestamo ya está cobrado!")
                    Else
                        cImporteCompraMN = objDocumentoBE.documentoCaja.DeudaEvalMN
                        cImporteCompraME = objDocumentoBE.documentoCaja.DeudaEvalME
                        cImportePagadomn = objDocumentoBE.documentoCaja.montoSoles
                        cImportePagadome = objDocumentoBE.documentoCaja.montoUsd
                        documentoBL.Insert(objDocumentoBE)
                        idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                        cajaDetalleBL.Insert(objDocumentoBE, objDocumentoBE.idDocumento, objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado)
                        AsientoBL.SavebyGroupDoc(objDocumentoBE)

                        .estado = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        'HeliosData.ObjectStateManager.GetObjectStateEntry(nDocumentoCompra).State.ToString()
                    End If

                    HeliosData.SaveChanges()
                    ts.Complete()
                    Return idDocumentoRecuperado
                    '   End If
                End With
                '    End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveGroupCajaNotacredito(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cImporteCompraMN As Decimal = 0
        Dim cImporteCompraME As Decimal = 0
        Dim cNCmn As Decimal = 0
        Dim cNCme As Decimal = 0
        Dim NBmn As Decimal = 0
        Dim NBme As Decimal = 0
        Dim cImportePagadomn As Decimal = 0
        Dim cImportePagadome As Decimal = 0
        Dim Totalmn As Decimal = 0
        Dim Totalme As Decimal = 0
        Dim intIdCompra As Integer

        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0
        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim CajaUsuarioBL As New CajaUsuarioBL
        Dim idDocumentoRecuperado As Integer
        Try
            Using ts As New TransactionScope()
                intIdCompra = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                Dim nDocumentoCompra As documentocompra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = intIdCompra).First
                '   
                Dim MontoPagadoDec As Decimal? = (From i In HeliosData.documentoCajaDetalle
                                                  Where i.documentoAfectado = intIdCompra
                                                  Select i.montoSoles).Sum

                If IsNothing(MontoPagadoDec) Then
                    MontoPagadoDec = 0
                End If

                '     Dim conDetalleCompra As List(Of documentocompradetalle) = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = intIdCompra).ToList
                Dim totals3 = Aggregate p In HeliosData.documentocompradetalle
                              Where p.idDocumento = intIdCompra
              Into nc = Sum(p.notaCreditoMN),
                   nce = Sum(p.notaCreditoME),
                   nd = Sum(p.notaDebitoMN),
                   nde = Sum(p.notaDebitoME),
                   mn = Sum(p.importe),
                   mne = Sum(p.importeUS)

                '    If conDetalleCompra.Count > 0 Then

                cTotalmn = totals3.mn - totals3.nc.GetValueOrDefault + totals3.nd.GetValueOrDefault
                cTotalme = totals3.mne - totals3.nce.GetValueOrDefault + totals3.nde.GetValueOrDefault

                '  End If

                With nDocumentoCompra
                    If MontoPagadoDec >= cTotalmn Then
                        Throw New Exception("El documento ya está cobrado!")
                    Else
                        cImporteCompraMN = objDocumentoBE.documentoCaja.DeudaEvalMN
                        cImporteCompraME = objDocumentoBE.documentoCaja.DeudaEvalME
                        cImportePagadomn = objDocumentoBE.documentoCaja.montoSoles
                        cImportePagadome = objDocumentoBE.documentoCaja.montoUsd
                        documentoBL.Insert(objDocumentoBE)
                        idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                        cajaDetalleBL.Insert(objDocumentoBE, objDocumentoBE.idDocumento, objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado)
                        AsientoBL.SavebyGroupDoc(objDocumentoBE)
                        If Not IsNothing(cajaUsuario) Then
                            CajaUsuarioBL.ActualizarMontoCajaUsuarioCompras(cajaUsuario)
                        End If
                        Totalmn = cImporteCompraMN - cImportePagadomn
                        If Totalmn <= 0 Then
                            'documento pagado

                            .estadoPago = TIPO_VENTA.PAGO.COBRADO
                            'HeliosData.ObjectStateManager.GetObjectStateEntry(nDocumentoCompra).State.ToString()
                        Else
                            .estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                            'HeliosData.ObjectStateManager.GetObjectStateEntry(nDocumentoCompra).State.ToString()
                        End If

                        HeliosData.SaveChanges()
                        ts.Complete()
                        Return idDocumentoRecuperado
                    End If


                End With
                '    End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Property CajaAperturaIDDoc As Integer


    Public Function SaveCajaAdministrativaApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cajaUsuarioBL As New CajaUsuarioBL
        Dim cajaUsuarioDetalleBL As New cajaUsuarioDetalleBL
        Dim x As Integer = 0
        Try
            Using ts As New TransactionScope

                'Dim consulta = (From n In HeliosData.cajaUsuario
                '                Where n.idPersona = objCajaUsuarioBE.idPersona _
                '           And n.estadoCaja = "A").FirstOrDefault

                Dim cajeroAD = HeliosData.cajaUsuario.Any(Function(o) o.estadoCaja = "A" And o.idEmpresa = objCajaUsuarioBE.idEmpresa And
                                                              o.idEstablecimiento = objCajaUsuarioBE.idEstablecimiento And
                                                              o.tipoCaja = objCajaUsuarioBE.tipoCaja)

                If cajeroAD = True Then
                    Throw New Exception("La Caja Administrativa ya esta Aperturada")
                End If


                '  If consulta Is Nothing Then
                x = cajaUsuarioBL.InsertUserCaja(objCajaUsuarioBE, CajaAperturaIDDoc)
                For Each i In objCajaUsuarioBE.cajaUsuariodetalle
                    i.idcajaUsuario = x
                    cajaUsuarioDetalleBL.InsertarNuevo(i)
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return x
                'Else
                '    Throw New Exception("El usuario ya tiene una caja asignada, debe cerrar primero.!")
                'End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveCajaAperturaUsuarioPc(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cajaUsuarioBL As New CajaUsuarioBL
        Dim cajaUsuarioDetalleBL As New cajaUsuarioDetalleBL
        Dim x As Integer = 0
        Try
            Using ts As New TransactionScope

                'Dim consulta = (From n In HeliosData.cajaUsuario
                '                Where n.idPersona = objCajaUsuarioBE.idPersona _
                '           And n.estadoCaja = "A").FirstOrDefault

                Dim cajeroPC = HeliosData.cajaUsuario.Any(Function(o) o.estadoCaja = "A" And
                                                              o.idPersona = objCajaUsuarioBE.idPersona And o.idEmpresa = objCajaUsuarioBE.idEmpresa And
                                                              o.idEstablecimiento = objCajaUsuarioBE.idEstablecimiento And
                                                              o.IDRol = objCajaUsuarioBE.IDRol)

                If cajeroPC = True Then
                    Throw New Exception("El usuario con este Cargo Tiene Caja Abierta")
                End If


                '  If consulta Is Nothing Then
                x = cajaUsuarioBL.InsertUserCaja(objCajaUsuarioBE, CajaAperturaIDDoc)
                For Each i In objCajaUsuarioBE.cajaUsuariodetalle
                    i.idcajaUsuario = x
                    cajaUsuarioDetalleBL.InsertarNuevo(i)
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return x
                'Else
                '    Throw New Exception("El usuario ya tiene una caja asignada, debe cerrar primero.!")
                'End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function SaveGroupCajaGeneralApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cajaUsuarioBL As New CajaUsuarioBL
        Dim cajaUsuarioDetalleBL As New cajaUsuarioDetalleBL
        Dim x As Integer = 0
        Try
            Using ts As New TransactionScope

                'Dim consulta = (From n In HeliosData.cajaUsuario
                '                Where n.idPersona = objCajaUsuarioBE.idPersona _
                '           And n.estadoCaja = "A").FirstOrDefault

                Dim cajeroPC = HeliosData.cajaUsuario.Any(Function(o) o.estadoCaja = "A" And o.tipoCaja = objCajaUsuarioBE.tipoCaja)

                If cajeroPC = True Then
                    Throw New Exception("La caja general ya esta aperturada")
                End If


                '  If consulta Is Nothing Then
                x = cajaUsuarioBL.InsertUserCaja(objCajaUsuarioBE, CajaAperturaIDDoc)
                For Each i In objCajaUsuarioBE.cajaUsuariodetalle
                    i.idcajaUsuario = x
                    cajaUsuarioDetalleBL.InsertarNuevo(i)
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return x
                'Else
                '    Throw New Exception("El usuario ya tiene una caja asignada, debe cerrar primero.!")
                'End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveGroupCajaApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cajaUsuarioBL As New CajaUsuarioBL
        Dim cajaUsuarioDetalleBL As New cajaUsuarioDetalleBL
        Dim x As Integer = 0
        Try
            Using ts As New TransactionScope

                'Dim consulta = (From n In HeliosData.cajaUsuario
                '                Where n.idPersona = objCajaUsuarioBE.idPersona _
                '           And n.estadoCaja = "A").FirstOrDefault

                Dim cajeroPC = HeliosData.cajaUsuario.Any(Function(o) o.estadoCaja = "A" And o.idPersona = objCajaUsuarioBE.idPersona And
                                                              o.IDRol = objCajaUsuarioBE.IDRol)

                If cajeroPC = True Then
                    Throw New Exception("Esta pc ya tiene una caja activa")
                End If


                '  If consulta Is Nothing Then
                x = cajaUsuarioBL.InsertUserCaja(objCajaUsuarioBE, CajaAperturaIDDoc)
                    For Each i In objCajaUsuarioBE.cajaUsuariodetalle
                        i.idcajaUsuario = x
                        cajaUsuarioDetalleBL.InsertarNuevo(i)
                    Next
                    HeliosData.SaveChanges()
                    ts.Complete()
                    Return x
                'Else
                '    Throw New Exception("El usuario ya tiene una caja asignada, debe cerrar primero.!")
                'End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateGroupCajaApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario))
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cajaUsuarioBL As New CajaUsuarioBL
        Dim cajaUsuario As New cajaUsuario
        Try
            Using ts As New TransactionScope

                Dim usuarioCaja As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = objCajaUsuarioBE.idcajaUsuario).First
                Select Case usuarioCaja.estadoCaja
                    Case "A"
                        cajaUsuarioBL.Editar(objCajaUsuarioBE)

                        Dim consultaLista = HeliosData.documentoCaja.Where(Function(o) o.usuarioModificacion = objCajaUsuarioBE.idcajaUsuario And o.codigoLibro = "105").ToList

                        For Each i In consultaLista
                            documentoBL.DeleteSingleVariable(i.idDocumento)
                        Next
                        documentoBL.Insert(objDocumentoBE)
                        objDocumentoBE.documentoCaja.usuarioModificacion = objCajaUsuarioBE.idcajaUsuario
                        CajaEntradaSalida(objDocumentoBE, objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)

                        For Each i In listaSubUsers
                            '   cajaUsuarioBL.EliminarCajaPorIdUsuario(i.idcajaUsuario)
                            cajaUsuarioBL.Editar(i)
                        Next
                        AsientoBL.SavebyGroupDoc(objDocumentoBE)

                    Case "C"
                        Throw New Exception("Está caja se encuentra cerrada, no puede realizar esta operación!")
                End Select


                'Dim consulta = (From cd In HeliosData.documentoCajaDetalle
                '                Join dc In HeliosData.documentoCaja
                '                On cd.idDocumento Equals dc.idDocumento _
                '               Where cd.documentoAfectado = objDocumentoBE.idDocumento And
                '               dc.tipoMovimiento = "DC" Select cd).FirstOrDefault

                'If Not IsNothing(consulta) Then
                '    AsientoBL.DeleteGroup(consulta.idDocumento)
                '    'ElimiNarCajasHijasXpadre(objCajaUsuarioBE.idcajaUsuario)
                '    documentoBL.Update(objDocumentoBE)
                '    updateCajaEntradaSalida(objDocumentoBE, objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento, consulta.idDocumento)

                '    cajaUsuarioBL.Editar(objCajaUsuarioBE)
                '    objDocumentoBE.idDocumento = consulta.idDocumento
                '    AsientoBL.SavebyGroupDoc(objDocumentoBE)

                '    For Each i In listaSubUsers

                '        UpdateCajaUser(i, objCajaUsuarioBE.documentoApertura)
                '    Next

                '    HeliosData.SaveChanges()
                '    ts.Complete()
                'Else
                '    Throw New Exception("El usuario ya tiene un caja activa, debe cerrar primero la caja.")
                'End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub ElimiNarCajasHijasXpadre(iNtIdPadre As Integer)
        Dim coN = (From N In HeliosData.cajaUsuario
                   Where N.idPadre = iNtIdPadre).ToList

        For Each i In coN
            ElimiNarCajaUser(i)
        Next

    End Sub


    Sub EditarCajasHijasXpadre(iNtIdPadre As Integer)
        Dim coN = (From N In HeliosData.cajaUsuario
                   Where N.idPadre = iNtIdPadre).ToList

        For Each i In coN
            '  UpdateCajaUser(i)
        Next

    End Sub

    Sub ElimiNarCajaUser(obj As cajaUsuario)
        Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = obj.idcajaUsuario).First
        Using ts As New TransactionScope
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Sub UpdateCajaUser(obj As cajaUsuario, docApertura As Integer)
        Dim objNewUser As New cajaUsuario
        Dim consulta As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = obj.idcajaUsuario).FirstOrDefault
        Using ts As New TransactionScope

            If IsNothing(consulta) Then
                objNewUser = New cajaUsuario

                objNewUser.idEmpresa = obj.idEmpresa
                objNewUser.idEstablecimiento = obj.idEstablecimiento
                objNewUser.idPersona = obj.idPersona
                objNewUser.claveIngreso = obj.claveIngreso
                objNewUser.periodo = obj.periodo
                objNewUser.documentoApertura = docApertura
                '  .documentoCierre = cajaUsuarioBE.idPersona
                objNewUser.idCajaOrigen = obj.idCajaOrigen
                objNewUser.idCajaDestino = obj.idCajaDestino
                objNewUser.idCajaCierre = obj.idCajaCierre
                objNewUser.fechaRegistro = obj.fechaRegistro
                objNewUser.fechaCierre = obj.fechaCierre
                objNewUser.moneda = obj.moneda
                objNewUser.tipoCambio = obj.tipoCambio
                objNewUser.fondoMN = obj.fondoMN
                objNewUser.fondoME = obj.fondoME
                objNewUser.ingresoAdicMN = obj.ingresoAdicMN
                objNewUser.ingresoAdicME = obj.ingresoAdicME
                objNewUser.otrosIngresosMN = obj.otrosIngresosMN
                objNewUser.otrosIngresosME = obj.otrosIngresosME
                objNewUser.otrosEgresosMN = obj.otrosEgresosMN
                objNewUser.otrosEgresosME = obj.otrosEgresosME
                objNewUser.estadoCaja = obj.estadoCaja
                objNewUser.enUso = obj.enUso
                objNewUser.usuarioActualizacion = obj.usuarioActualizacion
                objNewUser.fechaActualizacion = obj.fechaActualizacion
            Else

                consulta.fondoMN = obj.fondoMN
                consulta.fondoME = obj.fondoME
            End If

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Sub CajaEntradaSalida(documentoBE As documento, documentoCajaBE As documentoCaja, intIdDocumento As Integer)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Try
            Using ts As New TransactionScope()
                Me.InserParam(documentoCajaBE, intIdDocumento, "PG")
                CajaAperturaIDDoc = intIdDocumento
                cajaDetalleBL.InsertApertura(documentoBE, intIdDocumento)

                documentoBL.Insert(documentoBE)
                Me.InserParam2(documentoCajaBE, documentoBE.idDocumento, "DC")
                cajaDetalleBL.InsertTransferencia(documentoBE, documentoBE.idDocumento, intIdDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub updateCajaEntradaSalida(documentoBE As documento, documentoCajaBE As documentoCaja, intIdDocumento As Integer, intIdDocumentoDC As Integer)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Try
            Using ts As New TransactionScope()
                Me.UpdateParam(documentoCajaBE, intIdDocumento, "PG")
                CajaAperturaIDDoc = intIdDocumento
                cajaDetalleBL.UpdateApertura(documentoBE, intIdDocumento)

                documentoBL.Update(documentoBE)
                Me.UpdateParam2(documentoCajaBE, intIdDocumentoDC, "DC")
                cajaDetalleBL.UpdateTransferencia(documentoBE, intIdDocumentoDC, intIdDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SaveGroupCajaOtrosMovimientos(objDocumentoBE As documento)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope()
                documentoBL.Insert(objDocumentoBE)
                CajaEntradaSalida(objDocumentoBE, objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                'Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                'cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function SaveGroupCajaOtrosMovimientosSingle(objDocumentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope()
                documentoBL.Insert(objDocumentoBE)
                Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GrabarEFApertura(objDocumentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope()
                documentoBL.Insert(objDocumentoBE)
                Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateGroupCajaOtrosMovimientosSingle(objDocumentoBE As documento)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL

        Try
            Using ts As New TransactionScope()
                documentoBL.Update(objDocumentoBE)
                Delete(objDocumentoBE.idDocumento)
                Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)
                'Me.Update(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                'cajaDetalleBL.UpdateOtrosMov(objDocumentoBE, objDocumentoBE.idDocumento)
                'AsientoBL.DeleteGroup(objDocumentoBE.idDocumento)
                'AsientoBL.SavebyGroupDoc(objDocumentoBE)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function SaveGroupCajaDefault(objDocumentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cajaUsuarioBL As New CajaUsuarioBL
        Try
            Using ts As New TransactionScope()
                documentoBL.Insert(objDocumentoBE)
                Me.InsertApertura(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveGroupCajaDefaultGym(objDocumentoBE As documento, idMembresia As Integer) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cajaUsuarioBL As New CajaUsuarioBL
        Try
            Using ts As New TransactionScope()
                documentoBL.Insert(objDocumentoBE)
                Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertGym(objDocumentoBE, objDocumentoBE.idDocumento, idMembresia)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveCerrarCaja(objDocumentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope()
                documentoBL.Insert(objDocumentoBE)
                Me.InsertCierre(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SaveCajaExcedente(objDocumentoBE As documento)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope()
                documentoBL.Insert(objDocumentoBE)
                Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.Insert(objDocumentoBE, objDocumentoBE.idDocumento, objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Insert(ByVal documentoCajaBE As documentoCaja, intDocumento As Integer) As Integer
        Dim nDocumentoCaja As New documentoCaja
        Using ts As New TransactionScope

            With nDocumentoCaja
                .estado = documentoCajaBE.estado
                .codigoLibro = documentoCajaBE.codigoLibro
                .idDocumento = intDocumento
                .idEmpresa = documentoCajaBE.idEmpresa
                .idEstablecimiento = documentoCajaBE.idEstablecimiento
                .tipoMovimiento = documentoCajaBE.tipoMovimiento
                .codigoProveedor = documentoCajaBE.codigoProveedor
                .periodo = documentoCajaBE.periodo
                .fechaProceso = documentoCajaBE.fechaProceso
                .fechaCobro = documentoCajaBE.fechaCobro
                .tipoDocPago = documentoCajaBE.tipoDocPago
                .formapago = documentoCajaBE.formapago
                .numeroDoc = documentoCajaBE.numeroDoc
                .moneda = documentoCajaBE.moneda
                .entidadFinanciera = documentoCajaBE.entidadFinanciera
                .entidadFinancieraDestino = documentoCajaBE.entidadFinancieraDestino
                .tipoOperacion = documentoCajaBE.tipoOperacion
                .numeroOperacion = documentoCajaBE.numeroOperacion
                .bancoEntidad = documentoCajaBE.bancoEntidad
                .ctaCorrienteDeposito = documentoCajaBE.ctaCorrienteDeposito
                .tipoCambio = documentoCajaBE.tipoCambio
                .montoSoles = documentoCajaBE.montoSoles
                .montoUsd = documentoCajaBE.montoUsd
                .glosa = documentoCajaBE.glosa
                .entregado = documentoCajaBE.entregado
                .idCajaUsuario = documentoCajaBE.idCajaUsuario
                .idCajaUsuarioDestino = documentoCajaBE.idCajaUsuarioDestino
                .tipoEntidadFinanciera = documentoCajaBE.tipoEntidadFinanciera
                .idcosto = documentoCajaBE.idcosto
                .movimientoCaja = documentoCajaBE.movimientoCaja
                .estadopago = documentoCajaBE.estadopago
                .usuarioModificacion = documentoCajaBE.usuarioModificacion
                .fechaModificacion = documentoCajaBE.fechaModificacion
                .fechaProcesoDestino = documentoCajaBE.fechaProcesoDestino
                .idRol = documentoCajaBE.idRol
                .IdUsuarioTransaccion = documentoCajaBE.IdUsuarioTransaccion
                .confirmacionOperacion = documentoCajaBE.confirmacionOperacion
                .fechaconfirmacionOperacion = documentoCajaBE.fechaconfirmacionOperacion
            End With
            HeliosData.documentoCaja.Add(nDocumentoCaja)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoCajaBE.idDocumento = nDocumentoCaja.idDocumento
            Return nDocumentoCaja.idDocumento
        End Using
    End Function


    Public Function InserParam(ByVal documentoCajaBE As documentoCaja, intDocumento As Integer, strTipoMov As String) As Integer
        Dim nDocumentoCaja As New documentoCaja
        Using ts As New TransactionScope

            With nDocumentoCaja
                .idDocumento = intDocumento
                .movimientoCaja = documentoCajaBE.movimientoCaja
                .tipoOperacion = documentoCajaBE.tipoOperacion
                .codigoLibro = documentoCajaBE.codigoLibro
                .idEmpresa = documentoCajaBE.idEmpresa
                .idEstablecimiento = documentoCajaBE.idEstablecimiento
                .tipoMovimiento = strTipoMov
                .periodo = documentoCajaBE.periodo
                .codigoProveedor = documentoCajaBE.codigoProveedor
                .fechaProceso = documentoCajaBE.fechaProceso
                .fechaCobro = documentoCajaBE.fechaCobro
                .tipoDocPago = documentoCajaBE.tipoDocPago
                .numeroDoc = documentoCajaBE.numeroDoc
                .moneda = documentoCajaBE.moneda
                .entidadFinanciera = documentoCajaBE.entidadFinanciera
                .entidadFinancieraDestino = documentoCajaBE.entidadFinancieraDestino
                .numeroOperacion = documentoCajaBE.numeroOperacion
                .tipoCambio = documentoCajaBE.tipoCambio
                .montoSoles = documentoCajaBE.montoSoles
                .montoUsd = documentoCajaBE.montoUsd
                .glosa = documentoCajaBE.glosa
                .idCajaUsuario = documentoCajaBE.idCajaUsuario
                .entregado = documentoCajaBE.entregado
                .usuarioModificacion = documentoCajaBE.usuarioModificacion
                .fechaModificacion = documentoCajaBE.fechaModificacion
            End With
            HeliosData.documentoCaja.Add(nDocumentoCaja)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoCajaBE.idDocumento = nDocumentoCaja.idDocumento
            Return nDocumentoCaja.idDocumento
        End Using
    End Function

    Public Function UpdateParam(ByVal documentoCajaBE As documentoCaja, intDocumento As Integer, strTipoMov As String) As Integer
        Dim nDocumentoCaja As New documentoCaja
        Using ts As New TransactionScope

            Dim docCompra As documentoCaja = HeliosData.documentoCaja.Where(Function(o) _
                                          o.idDocumento = intDocumento).First()

            With docCompra
                '.idDocumento = intDocumento
                .idEmpresa = documentoCajaBE.idEmpresa
                .idEstablecimiento = documentoCajaBE.idEstablecimiento
                .tipoMovimiento = strTipoMov
                .codigoProveedor = documentoCajaBE.codigoProveedor
                .codigoLibro = documentoCajaBE.codigoLibro
                .periodo = documentoCajaBE.periodo
                .fechaProceso = documentoCajaBE.fechaProceso
                .fechaCobro = documentoCajaBE.fechaCobro
                .tipoDocPago = documentoCajaBE.tipoDocPago
                .numeroDoc = documentoCajaBE.numeroDoc

                .moneda = documentoCajaBE.moneda
                .entidadFinanciera = documentoCajaBE.entidadFinanciera
                .entidadFinancieraDestino = documentoCajaBE.entidadFinancieraDestino
                .tipoOperacion = documentoCajaBE.tipoOperacion
                .numeroOperacion = documentoCajaBE.numeroOperacion
                .tipoCambio = documentoCajaBE.tipoCambio
                .montoSoles = documentoCajaBE.montoSoles
                .montoUsd = documentoCajaBE.montoUsd
                .glosa = documentoCajaBE.glosa
                .entregado = documentoCajaBE.entregado
                .usuarioModificacion = documentoCajaBE.usuarioModificacion
                .fechaModificacion = documentoCajaBE.fechaModificacion
            End With
            HeliosData.SaveChanges()
            ts.Complete()
            documentoCajaBE.idDocumento = nDocumentoCaja.idDocumento
            Return nDocumentoCaja.idDocumento
        End Using
    End Function



    Public Function InserParam2(ByVal documentoCajaBE As documentoCaja, intDocumento As Integer, strTipoMov As String) As Integer
        Dim nDocumentoCaja As New documentoCaja
        Using ts As New TransactionScope

            With nDocumentoCaja
                .idDocumento = intDocumento
                .movimientoCaja = documentoCajaBE.movimientoCaja
                .tipoOperacion = documentoCajaBE.tipoOperacion
                .codigoLibro = documentoCajaBE.codigoLibro
                .idEmpresa = documentoCajaBE.idEmpresa
                .idEstablecimiento = documentoCajaBE.idEstablecimiento
                .tipoMovimiento = strTipoMov
                .codigoProveedor = documentoCajaBE.codigoProveedor
                .periodo = documentoCajaBE.periodo
                .fechaProceso = documentoCajaBE.fechaProceso
                .fechaCobro = documentoCajaBE.fechaCobro
                .tipoDocPago = documentoCajaBE.tipoDocPago
                .numeroDoc = documentoCajaBE.numeroDoc
                .moneda = documentoCajaBE.moneda
                .entidadFinanciera = documentoCajaBE.entidadFinancieraDestino
                .entidadFinancieraDestino = Nothing
                .numeroOperacion = documentoCajaBE.numeroOperacion
                .tipoCambio = documentoCajaBE.tipoCambio
                .montoSoles = documentoCajaBE.montoSoles
                .montoUsd = documentoCajaBE.montoUsd


                .glosa = documentoCajaBE.glosa
                .entregado = documentoCajaBE.entregado
                .usuarioModificacion = documentoCajaBE.usuarioModificacion
                .fechaModificacion = documentoCajaBE.fechaModificacion
            End With
            HeliosData.documentoCaja.Add(nDocumentoCaja)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoCajaBE.idDocumento = nDocumentoCaja.idDocumento
            Return nDocumentoCaja.idDocumento
        End Using
    End Function

    Public Function UpdateParam2(ByVal documentoCajaBE As documentoCaja, intDocumento As Integer, strTipoMov As String) As Integer
        Dim nDocumentoCaja As New documentoCaja
        Using ts As New TransactionScope

            Dim docCompra As documentoCaja = HeliosData.documentoCaja.Where(Function(o) _
                                         o.idDocumento = intDocumento).First()

            With docCompra
                '.idDocumento = intDocumento
                .idEmpresa = documentoCajaBE.idEmpresa
                .idEstablecimiento = documentoCajaBE.idEstablecimiento
                .tipoMovimiento = strTipoMov
                .codigoProveedor = documentoCajaBE.codigoProveedor
                .codigoLibro = documentoCajaBE.codigoLibro
                .periodo = documentoCajaBE.periodo
                .fechaProceso = documentoCajaBE.fechaProceso
                .fechaCobro = documentoCajaBE.fechaCobro
                .tipoDocPago = documentoCajaBE.tipoDocPago
                .numeroDoc = documentoCajaBE.numeroDoc

                .moneda = documentoCajaBE.moneda
                .entidadFinanciera = documentoCajaBE.entidadFinanciera
                .entidadFinancieraDestino = documentoCajaBE.entidadFinancieraDestino
                .tipoOperacion = documentoCajaBE.tipoOperacion
                .numeroOperacion = documentoCajaBE.numeroOperacion
                .tipoCambio = documentoCajaBE.tipoCambio
                .montoSoles = documentoCajaBE.montoSoles
                .montoUsd = documentoCajaBE.montoUsd


                .glosa = documentoCajaBE.glosa
                .entregado = documentoCajaBE.entregado
                .usuarioModificacion = documentoCajaBE.usuarioModificacion
                .fechaModificacion = documentoCajaBE.fechaModificacion
            End With
            HeliosData.SaveChanges()
            ts.Complete()
            documentoCajaBE.idDocumento = nDocumentoCaja.idDocumento
            Return nDocumentoCaja.idDocumento
        End Using
    End Function

    Public Function InsertApertura(ByVal documentoCajaBE As documentoCaja, intDocumento As Integer) As Integer
        Dim nDocumentoCaja As New documentoCaja
        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer = 0
        Using ts As New TransactionScope

            With nDocumentoCaja
                .idDocumento = intDocumento
                .idEmpresa = documentoCajaBE.idEmpresa
                .idEstablecimiento = documentoCajaBE.idEstablecimiento
                .tipoMovimiento = documentoCajaBE.tipoMovimiento
                .codigoProveedor = documentoCajaBE.codigoProveedor
                .fechaProceso = documentoCajaBE.fechaProceso
                .fechaCobro = documentoCajaBE.fechaCobro
                .tipoDocPago = documentoCajaBE.tipoDocPago
                cval = Convert.ToInt32(numeracionBL.GenerarNumero(documentoCajaBE.idEmpresa, documentoCajaBE.idEstablecimiento, documentoCajaBE.TipoDocumentoPago, documentoCajaBE.numeroOperacion))

                .numeroDoc = cval

                .moneda = documentoCajaBE.moneda
                .entidadFinanciera = documentoCajaBE.entidadFinanciera
                .numeroOperacion = documentoCajaBE.numeroOperacion
                .tipoCambio = documentoCajaBE.tipoCambio
                .montoSoles = documentoCajaBE.montoSoles
                .montoUsd = documentoCajaBE.montoUsd


                .glosa = documentoCajaBE.glosa
                .entregado = documentoCajaBE.entregado
                .usuarioModificacion = documentoCajaBE.usuarioModificacion
                .fechaModificacion = documentoCajaBE.fechaModificacion
            End With
            HeliosData.documentoCaja.Add(nDocumentoCaja)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoCajaBE.idDocumento = nDocumentoCaja.idDocumento
            Return nDocumentoCaja.idDocumento
        End Using
    End Function


    Public Function InsertCierre(ByVal documentoCajaBE As documentoCaja, intDocumento As Integer) As Integer
        Dim nDocumentoCaja As New documentoCaja
        Using ts As New TransactionScope

            With nDocumentoCaja
                .idDocumento = intDocumento
                .idEmpresa = documentoCajaBE.idEmpresa
                .idEstablecimiento = documentoCajaBE.idEstablecimiento
                .tipoMovimiento = documentoCajaBE.tipoMovimiento
                .codigoProveedor = documentoCajaBE.codigoProveedor
                .fechaProceso = documentoCajaBE.fechaProceso
                .fechaCobro = documentoCajaBE.fechaCobro
                .tipoDocPago = documentoCajaBE.tipoDocPago
                .codigoLibro = documentoCajaBE.codigoLibro
                .periodo = documentoCajaBE.periodo
                .numeroDoc = documentoCajaBE.numeroDoc

                .moneda = documentoCajaBE.moneda
                .entidadFinanciera = documentoCajaBE.entidadFinanciera
                .numeroOperacion = documentoCajaBE.numeroOperacion
                .tipoCambio = documentoCajaBE.tipoCambio
                .montoSoles = documentoCajaBE.montoSoles
                .montoUsd = documentoCajaBE.montoUsd


                .glosa = documentoCajaBE.glosa
                .entregado = documentoCajaBE.entregado
                .usuarioModificacion = documentoCajaBE.usuarioModificacion
                .fechaModificacion = documentoCajaBE.fechaModificacion
            End With
            HeliosData.documentoCaja.Add(nDocumentoCaja)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoCajaBE.idDocumento = nDocumentoCaja.idDocumento
            Return nDocumentoCaja.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoCajaBE As documentoCaja, intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim docCaja As documentoCaja = HeliosData.documentoCaja.Where(Function(o) _
                                            o.idDocumento = intIdDocumento).First()

            docCaja.idEmpresa = documentoCajaBE.idEmpresa
            docCaja.idEstablecimiento = documentoCajaBE.idEstablecimiento
            docCaja.tipoMovimiento = documentoCajaBE.tipoMovimiento
            docCaja.codigoProveedor = documentoCajaBE.codigoProveedor
            docCaja.fechaProceso = documentoCajaBE.fechaProceso
            docCaja.fechaCobro = documentoCajaBE.fechaCobro
            docCaja.tipoDocPago = documentoCajaBE.tipoDocPago
            docCaja.numeroDoc = documentoCajaBE.numeroDoc

            docCaja.moneda = documentoCajaBE.moneda
            docCaja.entidadFinanciera = documentoCajaBE.entidadFinanciera
            docCaja.numeroOperacion = documentoCajaBE.numeroOperacion
            docCaja.tipoCambio = documentoCajaBE.tipoCambio
            docCaja.montoSoles = documentoCajaBE.montoSoles
            docCaja.montoUsd = documentoCajaBE.montoUsd
            docCaja.glosa = documentoCajaBE.glosa
            docCaja.entregado = documentoCajaBE.entregado
            docCaja.usuarioModificacion = documentoCajaBE.usuarioModificacion
            docCaja.fechaModificacion = documentoCajaBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docCaja).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim documentocaja As documentoCaja = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = intIdDocumento).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentocaja)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetListar_documentoCaja() As List(Of documentoCaja)
        Return (From a In HeliosData.documentoCaja Select a).ToList
    End Function

    Public Function GetUbicar_documentoCajaPorID(idDocumento As Integer) As documentoCaja
        Return (From a In HeliosData.documentoCaja
                Where a.idDocumento = idDocumento Select a).First
    End Function

    Public Function GetUbicarPagosComprobante(idDocumento As Integer) As List(Of documentoCajaDetalle)
        Return (From a In HeliosData.documentoCajaDetalle _
                    .Include("documentocaja") _
                    .Include("documento")
                Where a.documentoAfectado = idDocumento).ToList
    End Function

    Public Function GetKardexCajaTramiteDocAdministracion(be As documentoCaja) As List(Of documentoCaja)
        Dim consulta = HeliosData.documentoCaja.Join(HeliosData.documentoCajaDetalle, Function(caja) caja.idDocumento, Function(det) det.idDocumento, Function(caja, det) New With
                                                                                                                                                          {
                                                                                                                                                          .documentoCaja = caja,
                                                                                                                                                          .cajadet = det
                                                                                                                                                          }) _
        .Join(HeliosData.estadosFinancieros, Function(caja2) CInt(caja2.documentoCaja.entidadFinancieraDestino), Function(efe) efe.idestado, Function(caja2, efe) New With
                                                                                                                                                          {
                                                                                                                                                          .cuentafinanciera = efe,
                                                                                                                                                          .documentoCaja = caja2.documentoCaja,
                                                                                                                                                          .documentoCajadetalle = caja2.cajadet
                                                                                                                                                          }) _
                                             .Where(Function(o) o.documentoCaja.idEmpresa = be.idEmpresa And
                                                                 o.documentoCaja.entidadFinancieraDestino = be.entidadFinancieraDestino And
                                                                 o.documentoCaja.tipoEntidadFinanciera = be.tipoEntidadFinanciera And
                                                                 o.documentoCaja.fechaProcesoDestino.Value.Year = be.fechaCobro.Value.Year And
                                                                 o.documentoCaja.fechaProcesoDestino.Value.Month = be.fechaCobro.Value.Month And
                                                                 o.documentoCaja.movimientoCaja <> "AC").OrderBy(Function(o) o.documentoCaja.fechaCobro).ToList


        GetKardexCajaTramiteDocAdministracion = New List(Of documentoCaja)
        Dim nomOper As String = String.Empty
        For Each i In consulta

            Select Case i.documentoCaja.tipoOperacion
                Case "9912"
                    nomOper = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    nomOper = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    nomOper = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    nomOper = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    nomOper = "PAGO A PROVEEDOR"
                Case "9908"
                    nomOper = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    nomOper = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    nomOper = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    nomOper = "VENTA"
                Case "12.1"
                    nomOper = "VENTA TICKET BOLETA"
                Case "12.2"
                    nomOper = "VENTA TICKET FACTURA"
                Case "17"
                    nomOper = "APORTES"
                Case "103"
                    nomOper = "ANTICIPOS RECIBIDOS"
                Case "104"
                    nomOper = "ANTICIPOS OTORGADOS"
                Case "21"
                    nomOper = "PAGO POR COMPENSACION"
                Case "9927"
                    nomOper = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    nomOper = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    nomOper = "REVERSIONES"
            End Select


            GetKardexCajaTramiteDocAdministracion.Add(New documentoCaja With
                              {
                               .estado = i.documentoCaja.estado,
                               .NombreOperacion = nomOper,
                               .tipoOperacion = i.documentoCaja.tipoOperacion,
                               .idDocumento = i.documentoCaja.idDocumento,
                               .IdEntidadFinanciera = i.cuentafinanciera.idestado,
                               .NombreCaja = i.cuentafinanciera.descripcion,
                               .entidadFinanciera = i.cuentafinanciera.tipo,
                               .fechaCobro = i.documentoCaja.fechaCobro,
                               .tipoMovimiento = i.documentoCaja.tipoMovimiento,
                               .TipoDocumentoPago = String.Concat(i.documentoCaja.tipoDocPago, ":", i.documentoCajadetalle.DetalleItem),
                               .tipoDocPago = i.documentoCaja.tipoDocPago,
                               .numeroDoc = i.documentoCaja.numeroDoc,
                               .NumeroDocumento = i.documentoCaja.numeroDoc,
                               .glosa = i.documentoCaja.glosa,
                               .montoSoles = i.documentoCajadetalle.montoSoles,
                               .tipoCambio = i.documentoCaja.tipoCambio,
                               .montoUsd = i.documentoCajadetalle.montoUsd,
                               .DetalleItem = i.documentoCajadetalle.DetalleItem,
                               .tipousuario = "Responsable",
                               .codigo = i.documentoCajadetalle.documentoAfectado
                              })
        Next


    End Function

    Public Function GetKardexCajaTramiteDoc(be As documentoCaja) As List(Of documentoCaja)
        Dim consulta = HeliosData.documentoCaja.Join(HeliosData.documentoCajaDetalle, Function(caja) caja.idDocumento, Function(det) det.idDocumento, Function(caja, det) New With
                                                                                                                                                          {
                                                                                                                                                          .documentoCaja = caja,
                                                                                                                                                          .cajadet = det
                                                                                                                                                          }) _
        .Join(HeliosData.estadosFinancieros, Function(caja2) CInt(caja2.documentoCaja.entidadFinanciera), Function(efe) efe.idestado, Function(caja2, efe) New With
                                                                                                                                                          {
                                                                                                                                                          .cuentafinanciera = efe,
                                                                                                                                                          .documentoCaja = caja2.documentoCaja,
                                                                                                                                                          .documentoCajadetalle = caja2.cajadet
                                                                                                                                                          }) _
                                             .Where(Function(o) o.documentoCaja.idEmpresa = be.idEmpresa And
                                                                 o.documentoCaja.entidadFinanciera = be.entidadFinanciera And
                                                                 o.documentoCaja.entidadFinancieraDestino Is Nothing And
                                                                 o.documentoCaja.fechaCobro.Value.Year = be.fechaCobro.Value.Year And
                                                                 o.documentoCaja.fechaCobro.Value.Month = be.fechaCobro.Value.Month And
                                                                 o.documentoCaja.movimientoCaja <> "AC").OrderBy(Function(o) o.documentoCaja.fechaCobro).ToList


        GetKardexCajaTramiteDoc = New List(Of documentoCaja)
        Dim nomOper As String = String.Empty
        For Each i In consulta

            Select Case i.documentoCaja.tipoOperacion
                Case "9912"
                    nomOper = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    nomOper = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    nomOper = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    nomOper = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    nomOper = "PAGO A PROVEEDOR"
                Case "9908"
                    nomOper = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    nomOper = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    nomOper = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    nomOper = "VENTA"
                Case "12.1"
                    nomOper = "VENTA TICKET BOLETA"
                Case "12.2"
                    nomOper = "VENTA TICKET FACTURA"
                Case "17"
                    nomOper = "APORTES"
                Case "103"
                    nomOper = "ANTICIPOS RECIBIDOS"
                Case "104"
                    nomOper = "ANTICIPOS OTORGADOS"
                Case "21"
                    nomOper = "PAGO POR COMPENSACION"
                Case "9927"
                    nomOper = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    nomOper = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    nomOper = "REVERSIONES"
            End Select


            GetKardexCajaTramiteDoc.Add(New documentoCaja With
                              {
                               .estado = i.documentoCaja.estado,
                               .NombreOperacion = nomOper,
                               .tipoOperacion = i.documentoCaja.tipoOperacion,
                               .idDocumento = i.documentoCaja.idDocumento,
                               .IdEntidadFinanciera = i.cuentafinanciera.idestado,
                               .NombreCaja = i.cuentafinanciera.descripcion,
                               .entidadFinanciera = i.cuentafinanciera.tipo,
                               .fechaCobro = i.documentoCaja.fechaCobro,
                               .tipoMovimiento = i.documentoCaja.tipoMovimiento,
                               .TipoDocumentoPago = String.Concat(i.documentoCaja.tipoDocPago, ":", i.documentoCajadetalle.DetalleItem),
                               .tipoDocPago = i.documentoCaja.tipoDocPago,
                               .numeroDoc = i.documentoCaja.numeroDoc,
                               .NumeroDocumento = i.documentoCaja.numeroDoc,
                               .glosa = i.documentoCaja.glosa,
                               .montoSoles = i.documentoCajadetalle.montoSoles,
                               .tipoCambio = i.documentoCaja.tipoCambio,
                               .montoUsd = i.documentoCajadetalle.montoUsd,
                               .DetalleItem = i.documentoCajadetalle.DetalleItem,
                               .tipousuario = "Responsable",
                               .codigo = i.documentoCajadetalle.documentoAfectado
                              })
        Next


    End Function


    Public Function ObtenerCajaOnlineConTramiteDocPOS(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)

        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL
        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)

        Dim fechaPeriodo = GetPeriodoConvertirToDate(strPeriodo)
        Dim consulta = (From c In HeliosData.documentoCaja
                        Join cajadetalle In HeliosData.documentoCajaDetalle
                        On cajadetalle.idDocumento Equals c.idDocumento
                        Group Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.entidadFinanciera
                        Into ords1 = Group
                        From x In ords1.DefaultIfEmpty
                        Where c.idEmpresa = strIdEmpresa _
                        And Not listaEstado.Contains(c.movimientoCaja) _
                        And c.fechaCobro.Value.Year = fechaPeriodo.Year _
                        And c.fechaCobro.Value.Month = fechaPeriodo.Month _
                        And c.entidadFinanciera = strEntidadFinanciera
                        Order By c.fechaCobro
                        Select
                        c.estado,
                        c.tipoOperacion,
                        c.idDocumento,
                        x.idestado,
                        x.descripcion,
                        x.tipo,
                        c.fechaCobro,
                        c.tipoMovimiento,
                        cajadetalle.DetalleItem,
                        c.tipoDocPago,
                        c.numeroDoc,
                        c.glosa,
                        cajadetalle.montoSoles,
                        c.tipoCambio,
                        cajadetalle.montoUsd,
                            cajadetalle.documentoAfectado).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.estado = obj.estado
            objMostrarEncaja.idDocumento = obj.idDocumento
            objMostrarEncaja.IdEntidadFinanciera = obj.idestado
            objMostrarEncaja.NombreCaja = obj.descripcion
            objMostrarEncaja.entidadFinanciera = obj.tipo
            objMostrarEncaja.fechaCobro = obj.fechaCobro
            objMostrarEncaja.tipoMovimiento = obj.tipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.tipoDocPago, ":", obj.DetalleItem)
            objMostrarEncaja.tipoDocPago = obj.tipoDocPago
            objMostrarEncaja.NumeroDocumento = obj.numeroDoc
            objMostrarEncaja.glosa = obj.glosa
            objMostrarEncaja.montoSoles = obj.montoSoles
            objMostrarEncaja.montoSolesTransacc = 0
            objMostrarEncaja.tipoCambio = obj.tipoCambio
            objMostrarEncaja.montoUsd = obj.montoUsd.GetValueOrDefault
            objMostrarEncaja.montoUsdTransacc = 0
            objMostrarEncaja.dni = String.Empty
            objMostrarEncaja.DetalleItem = obj.DetalleItem
            objMostrarEncaja.montoMNSalida = 0 ' obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            objMostrarEncaja.tipousuario = "Responsable"
            Select Case obj.tipoOperacion
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "9908"
                    objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
                Case "9937"
                    objMostrarEncaja.NombreOperacion = "PAGO RECLAMACION"
                Case "9938"
                    objMostrarEncaja.NombreOperacion = "COBRO RECLAMACION"
            End Select

            objMostrarEncaja.idCajaUsuario = obj.documentoAfectado

            ListaCaja.Add(objMostrarEncaja)

        Next

        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnlineConTramiteDoc(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)

        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL
        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)

        Dim fechaPeriodo = GetPeriodoConvertirToDate(strPeriodo)
        Dim consulta = (From c In HeliosData.documentoCaja
                        Join cajadetalle In HeliosData.documentoCajaDetalle
                        On cajadetalle.idDocumento Equals c.idDocumento
                        Group Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.entidadFinancieraDestino
                        Into ords1 = Group
                        From x In ords1.DefaultIfEmpty
                        Where c.idEmpresa = strIdEmpresa _
                        And Not listaEstado.Contains(c.movimientoCaja) _
                        And c.fechaCobro.Value.Year = fechaPeriodo.Year _
                        And c.fechaCobro.Value.Month = fechaPeriodo.Month _
                        And c.entidadFinancieraDestino = strEntidadFinanciera
                        Order By c.fechaCobro
                        Select
                        c.estado,
                        c.tipoOperacion,
                        c.idDocumento,
                        x.idestado,
                        x.descripcion,
                        x.tipo,
                        c.fechaCobro,
                        c.tipoMovimiento,
                        cajadetalle.DetalleItem,
                        c.tipoDocPago,
                        c.numeroDoc,
                        c.glosa,
                        cajadetalle.montoSoles,
                        c.tipoCambio,
                        cajadetalle.montoUsd,
                            cajadetalle.documentoAfectado).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.estado = obj.estado
            objMostrarEncaja.idDocumento = obj.idDocumento
            objMostrarEncaja.IdEntidadFinanciera = obj.idestado
            objMostrarEncaja.NombreCaja = obj.descripcion
            objMostrarEncaja.entidadFinanciera = obj.tipo
            objMostrarEncaja.fechaCobro = obj.fechaCobro
            objMostrarEncaja.tipoMovimiento = obj.tipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.tipoDocPago, ":", obj.DetalleItem)
            objMostrarEncaja.tipoDocPago = obj.tipoDocPago
            objMostrarEncaja.NumeroDocumento = obj.numeroDoc
            objMostrarEncaja.glosa = obj.glosa
            objMostrarEncaja.montoSoles = obj.montoSoles
            objMostrarEncaja.montoSolesTransacc = 0
            objMostrarEncaja.tipoCambio = obj.tipoCambio
            objMostrarEncaja.montoUsd = obj.montoUsd.GetValueOrDefault
            objMostrarEncaja.montoUsdTransacc = 0
            objMostrarEncaja.dni = String.Empty
            objMostrarEncaja.DetalleItem = obj.DetalleItem
            objMostrarEncaja.montoMNSalida = 0 ' obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            objMostrarEncaja.tipousuario = "Responsable"
            Select Case obj.tipoOperacion
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "9908"
                    objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
                Case "9937"
                    objMostrarEncaja.NombreOperacion = "PAGO RECLAMACION"
                Case "9938"
                    objMostrarEncaja.NombreOperacion = "COBRO RECLAMACION"
            End Select

            objMostrarEncaja.idCajaUsuario = obj.documentoAfectado

            ListaCaja.Add(objMostrarEncaja)

        Next

        Return ListaCaja
    End Function

    Public Function GetKardexCajaAdministracion(be As documentoCaja) As List(Of documentoCaja)
        Dim consulta = HeliosData.documentoCaja.Join(HeliosData.documentoCajaDetalle, Function(caja) caja.idDocumento, Function(det) det.idDocumento, Function(caja, det) New With
                                                                                                                                                          {
                                                                                                                                                          .documentoCaja = caja,
                                                                                                                                                          .cajadet = det
                                                                                                                                                          }) _
        .Join(HeliosData.estadosFinancieros, Function(caja2) CInt(caja2.documentoCaja.entidadFinancieraDestino), Function(efe) efe.idestado, Function(caja2, efe) New With
                                                                                                                                                          {
                                                                                                                                                          .cuentafinanciera = efe,
                                                                                                                                                          .documentoCaja = caja2.documentoCaja,
                                                                                                                                                          .documentoCajadetalle = caja2.cajadet
                                                                                                                                                          }) _
                                             .Where(Function(o) o.documentoCaja.idEmpresa = be.idEmpresa And
                                                                 o.documentoCaja.entidadFinancieraDestino = be.entidadFinancieraDestino And
                                                                 o.documentoCaja.tipoEntidadFinanciera = be.tipoEntidadFinanciera And
                                                                 o.documentoCaja.fechaCobro.Value.Year = be.fechaCobro.Value.Year And
                                                                 o.documentoCaja.fechaCobro.Value.Month = be.fechaCobro.Value.Month).OrderBy(Function(o) o.documentoCaja.fechaCobro).ToList


        GetKardexCajaAdministracion = New List(Of documentoCaja)
        Dim nomOper As String = String.Empty
        For Each i In consulta

            Select Case i.documentoCaja.tipoOperacion
                Case "9912"
                    nomOper = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    nomOper = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    nomOper = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    nomOper = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    nomOper = "PAGO A PROVEEDOR"
                Case "9908"
                    nomOper = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    nomOper = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    nomOper = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    nomOper = "VENTA"
                Case "12.1"
                    nomOper = "VENTA TICKET BOLETA"
                Case "12.2"
                    nomOper = "VENTA TICKET FACTURA"
                Case "17"
                    nomOper = "APORTES"
                Case "103"
                    nomOper = "ANTICIPOS RECIBIDOS"
                Case "104"
                    nomOper = "ANTICIPOS OTORGADOS"
                Case "21"
                    nomOper = "PAGO POR COMPENSACION"
                Case "9927"
                    nomOper = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    nomOper = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    nomOper = "REVERSIONES"
            End Select


            GetKardexCajaAdministracion.Add(New documentoCaja With
                              {
                               .estado = i.documentoCaja.estado,
                               .NombreOperacion = nomOper,
                               .tipoOperacion = i.documentoCaja.tipoOperacion,
                               .idDocumento = i.documentoCaja.idDocumento,
                               .IdEntidadFinanciera = i.cuentafinanciera.idestado,
                               .NombreCaja = i.cuentafinanciera.descripcion,
                               .entidadFinanciera = i.cuentafinanciera.tipo,
                               .fechaCobro = i.documentoCaja.fechaCobro,
                               .tipoMovimiento = i.documentoCaja.tipoMovimiento,
                               .TipoDocumentoPago = String.Concat(i.documentoCaja.tipoDocPago, ":", i.documentoCajadetalle.DetalleItem),
                               .tipoDocPago = i.documentoCaja.tipoDocPago,
                               .numeroDoc = i.documentoCaja.numeroDoc,
                               .NumeroDocumento = i.documentoCaja.numeroDoc,
                               .glosa = i.documentoCaja.glosa,
                               .montoSoles = i.documentoCajadetalle.montoSoles,
                               .tipoCambio = i.documentoCaja.tipoCambio,
                               .montoUsd = i.documentoCajadetalle.montoUsd,
                               .DetalleItem = i.documentoCajadetalle.DetalleItem,
                               .tipousuario = "Responsable",
                               .codigo = i.documentoCajadetalle.documentoAfectado
                              })
        Next


    End Function



    Public Function GetKardexCaja(be As documentoCaja) As List(Of documentoCaja)
        Dim consulta = HeliosData.documentoCaja.Join(HeliosData.documentoCajaDetalle, Function(caja) caja.idDocumento, Function(det) det.idDocumento, Function(caja, det) New With
                                                                                                                                                          {
                                                                                                                                                          .documentoCaja = caja,
                                                                                                                                                          .cajadet = det
                                                                                                                                                          }) _
        .Join(HeliosData.estadosFinancieros, Function(caja2) CInt(caja2.documentoCaja.entidadFinanciera), Function(efe) efe.idestado, Function(caja2, efe) New With
                                                                                                                                                          {
                                                                                                                                                          .cuentafinanciera = efe,
                                                                                                                                                          .documentoCaja = caja2.documentoCaja,
                                                                                                                                                          .documentoCajadetalle = caja2.cajadet
                                                                                                                                                          }) _
                                             .Where(Function(o) o.documentoCaja.idEmpresa = be.idEmpresa And
                                                                 o.documentoCaja.entidadFinanciera = be.entidadFinanciera And
                                                                 o.documentoCaja.fechaCobro.Value.Year = be.fechaCobro.Value.Year And
                                                                 o.documentoCaja.entidadFinancieraDestino Is Nothing And
                                                                 o.documentoCaja.fechaCobro.Value.Month = be.fechaCobro.Value.Month).OrderBy(Function(o) o.documentoCaja.fechaCobro).ToList


        GetKardexCaja = New List(Of documentoCaja)
        Dim nomOper As String = String.Empty
        For Each i In consulta

            Select Case i.documentoCaja.tipoOperacion
                Case "9912"
                    nomOper = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    nomOper = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    nomOper = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    nomOper = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    nomOper = "PAGO A PROVEEDOR"
                Case "9908"
                    nomOper = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    nomOper = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    nomOper = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    nomOper = "VENTA"
                Case "12.1"
                    nomOper = "VENTA TICKET BOLETA"
                Case "12.2"
                    nomOper = "VENTA TICKET FACTURA"
                Case "17"
                    nomOper = "APORTES"
                Case "103"
                    nomOper = "ANTICIPOS RECIBIDOS"
                Case "104"
                    nomOper = "ANTICIPOS OTORGADOS"
                Case "21"
                    nomOper = "PAGO POR COMPENSACION"
                Case "9927"
                    nomOper = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    nomOper = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    nomOper = "REVERSIONES"
            End Select


            GetKardexCaja.Add(New documentoCaja With
                              {
                               .estado = i.documentoCaja.estado,
                               .NombreOperacion = nomOper,
                               .tipoOperacion = i.documentoCaja.tipoOperacion,
                               .idDocumento = i.documentoCaja.idDocumento,
                               .IdEntidadFinanciera = i.cuentafinanciera.idestado,
                               .NombreCaja = i.cuentafinanciera.descripcion,
                               .entidadFinanciera = i.cuentafinanciera.tipo,
                               .fechaCobro = i.documentoCaja.fechaCobro,
                               .tipoMovimiento = i.documentoCaja.tipoMovimiento,
                               .TipoDocumentoPago = String.Concat(i.documentoCaja.tipoDocPago, ":", i.documentoCajadetalle.DetalleItem),
                               .tipoDocPago = i.documentoCaja.tipoDocPago,
                               .numeroDoc = i.documentoCaja.numeroDoc,
                               .NumeroDocumento = i.documentoCaja.numeroDoc,
                               .glosa = i.documentoCaja.glosa,
                               .montoSoles = i.documentoCajadetalle.montoSoles,
                               .tipoCambio = i.documentoCaja.tipoCambio,
                               .montoUsd = i.documentoCajadetalle.montoUsd,
                               .DetalleItem = i.documentoCajadetalle.DetalleItem,
                               .tipousuario = "Responsable",
                               .codigo = i.documentoCajadetalle.documentoAfectado
                              })
        Next


    End Function


    Public Function ObtenerCajaOnlinePOS(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL
        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)
        'Dim periodoAnterior = CInt(strMEs) - 1
        'periodoAnterior = String.Format("{0:00}", periodoAnterior)
        'Dim periodoAnterior2 = CStr(periodoAnterior) & strAnio


        ',
        'SaldoAnteriorEF = (From cc In HeliosData.cierreCaja _
        '            Where _
        '            cc.idEmpresa = Gempresas.IdEmpresaRuc And _
        '            cc.periodo = periodoAnterior2 And _
        '            cc.idEntidadFinanciera = x.idestado _
        '            Select New With
        '                   {
        '                       cc.montoMN
        '                   }).FirstOrDefault().montoMN
        '  Dim fechaPeriodo = GetPeriodoConvertirToDate(strPeriodo)
        Dim fechaPeriodo = CType("1/" & strPeriodo, DateTime)

        Dim consulta = (From c In HeliosData.documentoCaja
                        Join cajadetalle In HeliosData.documentoCajaDetalle
                            On cajadetalle.idDocumento Equals c.idDocumento
                        Group Join tipo In HeliosData.estadosFinancieros
                            On tipo.idestado Equals c.entidadFinanciera
                        Into ords1 = Group
                        From x In ords1.DefaultIfEmpty
                        Where c.idEmpresa = strIdEmpresa _
                            And c.fechaCobro.Value.Year = fechaPeriodo.Year _
                            And c.fechaCobro.Value.Month = fechaPeriodo.Month _
                            And c.entidadFinanciera = strEntidadFinanciera
                        Order By c.fechaCobro
                        Select
                            c.estado,
                            c.tipoOperacion,
                        c.idDocumento,
                        x.idestado,
                        x.descripcion,
                        x.tipo,
                        c.fechaCobro,
                        c.tipoMovimiento,
                        cajadetalle.DetalleItem,
                        c.tipoDocPago,
                        c.numeroDoc,
                        c.glosa,
                        cajadetalle.montoSoles,
                        c.tipoCambio,
                        cajadetalle.montoUsd,
                            cajadetalle.documentoAfectado).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.estado = obj.estado
            objMostrarEncaja.idDocumento = obj.idDocumento
            objMostrarEncaja.IdEntidadFinanciera = obj.idestado
            objMostrarEncaja.NombreCaja = obj.descripcion
            objMostrarEncaja.entidadFinanciera = obj.tipo
            objMostrarEncaja.fechaCobro = obj.fechaCobro
            objMostrarEncaja.tipoMovimiento = obj.tipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.tipoDocPago, ":", obj.DetalleItem)
            objMostrarEncaja.tipoDocPago = obj.tipoDocPago
            objMostrarEncaja.NumeroDocumento = obj.numeroDoc
            objMostrarEncaja.glosa = obj.glosa
            objMostrarEncaja.montoSoles = obj.montoSoles
            objMostrarEncaja.montoSolesTransacc = 0
            objMostrarEncaja.tipoCambio = obj.tipoCambio
            objMostrarEncaja.montoUsd = obj.montoUsd.GetValueOrDefault
            objMostrarEncaja.montoUsdTransacc = 0
            objMostrarEncaja.dni = String.Empty
            objMostrarEncaja.DetalleItem = obj.DetalleItem
            objMostrarEncaja.montoMNSalida = 0 ' obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            objMostrarEncaja.tipousuario = "Responsable"
            Select Case obj.tipoOperacion
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "9908"
                    objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
            End Select

            'objMostrarEncaja.documentoCajaDetalle = New documentoCajaDetalle


            ListaCaja.Add(objMostrarEncaja)
            'Dim conEFExiste = ListaCaja.Where(Function(o) o.IdEntidadFinanciera = obj.idestado).Count
            'If conEFExiste = 0 Then
            '    'SaldoAnterior
            '    If obj.SaldoAnteriorEF.GetValueOrDefault > 0 Then
            '        objMostrarEncaja = New documentoCaja
            '        objMostrarEncaja.idDocumento = 0
            '        objMostrarEncaja.IdEntidadFinanciera = obj.idestado
            '        objMostrarEncaja.NombreCaja = obj.descripcion
            '        objMostrarEncaja.entidadFinanciera = obj.tipo
            '        objMostrarEncaja.fechaCobro = obj.fechaCobro
            '        objMostrarEncaja.tipoMovimiento = obj.tipoMovimiento
            '        objMostrarEncaja.TipoDocumentoPago = "Cierre"
            '        objMostrarEncaja.tipoDocPago = obj.tipoDocPago
            '        objMostrarEncaja.NumeroDocumento = obj.numeroDoc
            '        objMostrarEncaja.glosa = "Cierre"
            '        objMostrarEncaja.montoSoles = obj.SaldoAnteriorEF.GetValueOrDefault
            '        objMostrarEncaja.montoSolesTransacc = 0
            '        objMostrarEncaja.tipoCambio = obj.tipoCambio
            '        objMostrarEncaja.montoUsd = 0
            '        objMostrarEncaja.montoUsdTransacc = 0
            '        objMostrarEncaja.dni = String.Empty
            '        objMostrarEncaja.DetalleItem = "Cierre"
            '        objMostrarEncaja.montoMNSalida = 0 ' obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            '        objMostrarEncaja.tipousuario = "Responsable"
            '        objMostrarEncaja.NombreOperacion = "CIERRE"
            '        ListaCaja.Add(objMostrarEncaja)
            '    End If
            'End If
        Next

        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnline(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL
        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)
        'Dim periodoAnterior = CInt(strMEs) - 1
        'periodoAnterior = String.Format("{0:00}", periodoAnterior)
        'Dim periodoAnterior2 = CStr(periodoAnterior) & strAnio


        ',
        'SaldoAnteriorEF = (From cc In HeliosData.cierreCaja _
        '            Where _
        '            cc.idEmpresa = Gempresas.IdEmpresaRuc And _
        '            cc.periodo = periodoAnterior2 And _
        '            cc.idEntidadFinanciera = x.idestado _
        '            Select New With
        '                   {
        '                       cc.montoMN
        '                   }).FirstOrDefault().montoMN
        '  Dim fechaPeriodo = GetPeriodoConvertirToDate(strPeriodo)
        Dim fechaPeriodo = CType("1/" & strPeriodo, DateTime)

        Dim consulta = (From c In HeliosData.documentoCaja
                        Join cajadetalle In HeliosData.documentoCajaDetalle
                            On cajadetalle.idDocumento Equals c.idDocumento
                        Group Join tipo In HeliosData.estadosFinancieros
                            On tipo.idestado Equals c.entidadFinancieraDestino
                        Into ords1 = Group
                        From x In ords1.DefaultIfEmpty
                        Where c.idEmpresa = strIdEmpresa _
                            And c.fechaCobro.Value.Year = fechaPeriodo.Year _
                            And c.fechaCobro.Value.Month = fechaPeriodo.Month _
                            And c.entidadFinancieraDestino = strEntidadFinanciera
                        Order By c.fechaCobro
                        Select
                            c.estado,
                            c.tipoOperacion,
                        c.idDocumento,
                        x.idestado,
                        x.descripcion,
                        x.tipo,
                        c.fechaCobro,
                        c.tipoMovimiento,
                        cajadetalle.DetalleItem,
                        c.tipoDocPago,
                        c.numeroDoc,
                        c.glosa,
                        cajadetalle.montoSoles,
                        c.tipoCambio,
                        cajadetalle.montoUsd,
                            cajadetalle.documentoAfectado).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.estado = obj.estado
            objMostrarEncaja.idDocumento = obj.idDocumento
            objMostrarEncaja.IdEntidadFinanciera = obj.idestado
            objMostrarEncaja.NombreCaja = obj.descripcion
            objMostrarEncaja.entidadFinanciera = obj.tipo
            objMostrarEncaja.fechaCobro = obj.fechaCobro
            objMostrarEncaja.tipoMovimiento = obj.tipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.tipoDocPago, ":", obj.DetalleItem)
            objMostrarEncaja.tipoDocPago = obj.tipoDocPago
            objMostrarEncaja.NumeroDocumento = obj.numeroDoc
            objMostrarEncaja.glosa = obj.glosa
            objMostrarEncaja.montoSoles = obj.montoSoles
            objMostrarEncaja.montoSolesTransacc = 0
            objMostrarEncaja.tipoCambio = obj.tipoCambio
            objMostrarEncaja.montoUsd = obj.montoUsd.GetValueOrDefault
            objMostrarEncaja.montoUsdTransacc = 0
            objMostrarEncaja.dni = String.Empty
            objMostrarEncaja.DetalleItem = obj.DetalleItem
            objMostrarEncaja.montoMNSalida = 0 ' obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            objMostrarEncaja.tipousuario = "Responsable"
            Select Case obj.tipoOperacion
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "9908"
                    objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
            End Select

            'objMostrarEncaja.documentoCajaDetalle = New documentoCajaDetalle


            ListaCaja.Add(objMostrarEncaja)
            'Dim conEFExiste = ListaCaja.Where(Function(o) o.IdEntidadFinanciera = obj.idestado).Count
            'If conEFExiste = 0 Then
            '    'SaldoAnterior
            '    If obj.SaldoAnteriorEF.GetValueOrDefault > 0 Then
            '        objMostrarEncaja = New documentoCaja
            '        objMostrarEncaja.idDocumento = 0
            '        objMostrarEncaja.IdEntidadFinanciera = obj.idestado
            '        objMostrarEncaja.NombreCaja = obj.descripcion
            '        objMostrarEncaja.entidadFinanciera = obj.tipo
            '        objMostrarEncaja.fechaCobro = obj.fechaCobro
            '        objMostrarEncaja.tipoMovimiento = obj.tipoMovimiento
            '        objMostrarEncaja.TipoDocumentoPago = "Cierre"
            '        objMostrarEncaja.tipoDocPago = obj.tipoDocPago
            '        objMostrarEncaja.NumeroDocumento = obj.numeroDoc
            '        objMostrarEncaja.glosa = "Cierre"
            '        objMostrarEncaja.montoSoles = obj.SaldoAnteriorEF.GetValueOrDefault
            '        objMostrarEncaja.montoSolesTransacc = 0
            '        objMostrarEncaja.tipoCambio = obj.tipoCambio
            '        objMostrarEncaja.montoUsd = 0
            '        objMostrarEncaja.montoUsdTransacc = 0
            '        objMostrarEncaja.dni = String.Empty
            '        objMostrarEncaja.DetalleItem = "Cierre"
            '        objMostrarEncaja.montoMNSalida = 0 ' obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            '        objMostrarEncaja.tipousuario = "Responsable"
            '        objMostrarEncaja.NombreOperacion = "CIERRE"
            '        ListaCaja.Add(objMostrarEncaja)
            '    End If
            'End If
        Next

        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnlineXIdCaja(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strperiodo As String, ByVal strEntidadFinanciera As String, idCaja As Integer) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL

        Dim fechaPeriodo = GetPeriodoConvertirToDate(strperiodo)
        Dim consulta = (From c In HeliosData.documentoCaja
                        Join cajadetalle In HeliosData.documentoCajaDetalle
                            On cajadetalle.idDocumento Equals c.idDocumento
                        Join tip In HeliosData.estadosFinancieros
                            On tip.idestado Equals c.entidadFinanciera
                        Where c.idEmpresa = strIdEmpresa _
                            And c.fechaProceso.Value.Year = fechaPeriodo.Year _
                            And c.fechaProceso.Value.Month = fechaPeriodo.Month _
                            And c.entidadFinanciera = strEntidadFinanciera _
                            And c.idCajaUsuario = idCaja
                        Order By cajadetalle.fecha).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.idDocumento = obj.c.idDocumento
            objMostrarEncaja.IdEntidadFinanciera = obj.tip.idestado
            objMostrarEncaja.fechaCobro = obj.cajadetalle.fecha
            objMostrarEncaja.tipoMovimiento = obj.c.tipoMovimiento
            objMostrarEncaja.saldoMN = obj.c.montoSoles
            objMostrarEncaja.fechaProceso = obj.c.fechaCobro
            Select Case obj.c.tipoMovimiento
                Case "DC"
                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                    Select Case obj.c.movimientoCaja
                        Case "TEC"
                            objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.TRANSFERENCIA_CAJA
                        Case "OEC"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ENTRADAS_CAJA
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                        Case "OSC"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.SALIDA_CAJA
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                        Case "VTAG"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_GENERAL
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                        Case "VPOS"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_POS
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                        Case "IPV"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_TICKET
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                        Case "AR"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ANTICPO_RECIBIDO
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                        Case Else
                            objMostrarEncaja.NomCajaDestino = "OTROS"
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                    End Select
                Case "PG"
                    Select Case obj.c.movimientoCaja
                        Case "TEC"
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.TRANSFERENCIA_CAJA
                        Case "OEC"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ENTRADAS_CAJA
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                        Case "OSC"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.SALIDA_CAJA
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                        Case "VTAG"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_GENERAL
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                        Case "VPOS"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_POS
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                        Case "IPV"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_TICKET
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                        Case "AR"
                            objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ANTICPO_RECIBIDO
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                        Case Else
                            objMostrarEncaja.NomCajaDestino = "OTROS"
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio

                    End Select
                Case "ANT-C"
                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio

            End Select
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.c.TipoDocumentoPago, ":", obj.cajadetalle.DetalleItem)
            objMostrarEncaja.tipoDocPago = obj.c.tipoDocPago
            objMostrarEncaja.NumeroDocumento = obj.c.numeroDoc
            objMostrarEncaja.glosa = obj.c.glosa
            objMostrarEncaja.montoSoles = obj.cajadetalle.montoSoles
            objMostrarEncaja.montoSolesTransacc = obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            objMostrarEncaja.montoUsdTransacc = obj.cajadetalle.montoUsdTransacc.GetValueOrDefault
            objMostrarEncaja.montoUsd = obj.cajadetalle.montoUsd
            objMostrarEncaja.NombreCaja = obj.tip.descripcion
            objMostrarEncaja.entidadFinanciera = obj.tip.tipo
            objMostrarEncaja.dni = String.Empty
            objMostrarEncaja.DetalleItem = obj.cajadetalle.DetalleItem
            objMostrarEncaja.tipousuario = "Responsable"
            objMostrarEncaja.usuarioModificacion = obj.c.usuarioModificacion
            objMostrarEncaja.tipoOperacion = obj.c.tipoOperacion
            Select Case obj.c.tipoOperacion
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "9908"
                    objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                    '   End If
                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
            End Select

            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnlineXDocumento(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL
        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)

        Dim consulta = (From c In HeliosData.documentoCaja
                        Group Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.entidadFinanciera
                        Into ords1 = Group
                        From x In ords1.DefaultIfEmpty
                        Where c.idEmpresa = strIdEmpresa _
                        And Not listaEstado.Contains(c.movimientoCaja) _
                        And c.periodo = strPeriodo _
                        And c.entidadFinanciera = strEntidadFinanciera
                        Order By c.fechaProceso
                        Select
                        c.tipoOperacion,
                        c.idDocumento,
                        x.idestado,
                        x.descripcion,
                        x.tipo,
                        c.fechaCobro,
                        c.tipoMovimiento,
                            c.tipoDocPago,
                        c.numeroDoc,
                        c.glosa,
                        c.montoSoles,
                        c.tipoCambio,
                        c.montoUsd
                            ).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.idDocumento = obj.idDocumento
            objMostrarEncaja.IdEntidadFinanciera = obj.idestado
            objMostrarEncaja.NombreCaja = obj.descripcion
            objMostrarEncaja.entidadFinanciera = obj.tipo
            objMostrarEncaja.fechaCobro = obj.fechaCobro
            objMostrarEncaja.tipoMovimiento = obj.tipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.tipoDocPago)
            objMostrarEncaja.tipoDocPago = obj.tipoDocPago
            objMostrarEncaja.NumeroDocumento = obj.numeroDoc
            objMostrarEncaja.glosa = obj.glosa
            objMostrarEncaja.montoSoles = obj.montoSoles
            objMostrarEncaja.montoSolesTransacc = 0
            objMostrarEncaja.tipoCambio = obj.tipoCambio
            objMostrarEncaja.montoUsd = obj.montoUsd.GetValueOrDefault
            objMostrarEncaja.montoUsdTransacc = 0
            objMostrarEncaja.dni = String.Empty
            'objMostrarEncaja.DetalleItem = obj.DetalleItem
            objMostrarEncaja.montoMNSalida = 0 ' obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            objMostrarEncaja.tipousuario = "Responsable"
            Select Case obj.tipoOperacion
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "9908"
                    objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
            End Select

            ListaCaja.Add(objMostrarEncaja)

        Next

        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnlineXDocumentoConTramiteDoc(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL
        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)

        Dim consulta = (From c In HeliosData.documentoCaja
                        Group Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.entidadFinanciera
                        Into ords1 = Group
                        From x In ords1.DefaultIfEmpty
                        Where c.idEmpresa = strIdEmpresa _
                        And Not listaEstado.Contains(c.movimientoCaja) _
                        And c.periodo = strPeriodo _
                        And c.entidadFinanciera = strEntidadFinanciera
                        Order By c.fechaProceso
                        Select
                        c.tipoOperacion,
                        c.idDocumento,
                        x.idestado,
                        x.descripcion,
                        x.tipo,
                        c.fechaCobro,
                        c.tipoMovimiento,
                            c.tipoDocPago,
                        c.numeroDoc,
                        c.glosa,
                        c.montoSoles,
                        c.tipoCambio,
                        c.montoUsd
                            ).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.idDocumento = obj.idDocumento
            objMostrarEncaja.IdEntidadFinanciera = obj.idestado
            objMostrarEncaja.NombreCaja = obj.descripcion
            objMostrarEncaja.entidadFinanciera = obj.tipo
            objMostrarEncaja.fechaCobro = obj.fechaCobro
            objMostrarEncaja.tipoMovimiento = obj.tipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.tipoDocPago)
            objMostrarEncaja.tipoDocPago = obj.tipoDocPago
            objMostrarEncaja.NumeroDocumento = obj.numeroDoc
            objMostrarEncaja.glosa = obj.glosa
            objMostrarEncaja.montoSoles = obj.montoSoles
            objMostrarEncaja.montoSolesTransacc = 0
            objMostrarEncaja.tipoCambio = obj.tipoCambio
            objMostrarEncaja.montoUsd = obj.montoUsd.GetValueOrDefault
            objMostrarEncaja.montoUsdTransacc = 0
            objMostrarEncaja.dni = String.Empty
            'objMostrarEncaja.DetalleItem = obj.DetalleItem
            objMostrarEncaja.montoMNSalida = 0 ' obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            objMostrarEncaja.tipousuario = "Responsable"
            Select Case obj.tipoOperacion
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "9908"
                    objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
            End Select

            ListaCaja.Add(objMostrarEncaja)

        Next

        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnlineXDocumentoXId(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, stridCaja As Integer) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL
        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)

        Dim consulta = (From c In HeliosData.documentoCaja
                        Group Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.entidadFinanciera
                        Into ords1 = Group
                        From x In ords1.DefaultIfEmpty
                        Where c.idEmpresa = strIdEmpresa _
                        And c.periodo = strPeriodo _
                        And c.entidadFinanciera = strEntidadFinanciera _
                        And c.idCajaUsuario = stridCaja
                        Order By c.fechaProceso
                        Select
                        c.tipoOperacion,
                        c.idDocumento,
                        x.idestado,
                        x.descripcion,
                        x.tipo,
                        c.fechaCobro,
                        c.tipoMovimiento,
                            c.tipoDocPago,
                        c.numeroDoc,
                        c.glosa,
                        c.montoSoles,
                        c.tipoCambio,
                        c.montoUsd
                            ).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.idDocumento = obj.idDocumento
            objMostrarEncaja.IdEntidadFinanciera = obj.idestado
            objMostrarEncaja.NombreCaja = obj.descripcion
            objMostrarEncaja.entidadFinanciera = obj.tipo
            objMostrarEncaja.fechaCobro = obj.fechaCobro
            objMostrarEncaja.tipoMovimiento = obj.tipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.tipoDocPago)
            objMostrarEncaja.tipoDocPago = obj.tipoDocPago
            objMostrarEncaja.NumeroDocumento = obj.numeroDoc
            objMostrarEncaja.glosa = obj.glosa
            objMostrarEncaja.montoSoles = obj.montoSoles
            objMostrarEncaja.montoSolesTransacc = 0
            objMostrarEncaja.tipoCambio = obj.tipoCambio
            objMostrarEncaja.montoUsd = obj.montoUsd.GetValueOrDefault
            objMostrarEncaja.montoUsdTransacc = 0
            objMostrarEncaja.dni = String.Empty
            'objMostrarEncaja.DetalleItem = obj.DetalleItem
            objMostrarEncaja.montoMNSalida = 0 ' obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            objMostrarEncaja.tipousuario = "Responsable"
            Select Case obj.tipoOperacion
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "9908"
                    objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                Case "105" 'APERTURA DE CAJAS
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                Case "01" 'VENTAS
                    objMostrarEncaja.NombreOperacion = "VENTA"
                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "VENTA TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
            End Select

            ListaCaja.Add(objMostrarEncaja)

        Next

        Return ListaCaja
    End Function


    Public Function ObtenerCajasMovimientosPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim cajaBL As New estadosFinancierosBL

        Dim consulta = (From c In HeliosData.documentoCaja
                        Join cajadetalle In HeliosData.documentoCajaDetalle
                        On cajadetalle.idDocumento Equals c.idDocumento
                        Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.entidadFinanciera
                        Join caja In HeliosData.cajaUsuario
                        On caja.idcajaUsuario Equals c.usuarioModificacion
                        Where c.idEmpresa = Gempresas.IdEmpresaRuc _
                        And c.idEstablecimiento = intIdEstablecimiento _
                        And c.periodo = strPeriodo).ToList


        For Each obj In consulta
            objMostrarEncaja = New documentoCaja

            objMostrarEncaja.fechaCobro = obj.c.fechaCobro
            objMostrarEncaja.tipoMovimiento = obj.c.tipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.c.tipoDocPago, ":", obj.cajadetalle.DetalleItem)
            objMostrarEncaja.NumeroDocumento = obj.c.numeroDoc
            objMostrarEncaja.glosa = obj.c.glosa
            objMostrarEncaja.montoSoles = obj.cajadetalle.montoSoles
            objMostrarEncaja.montoUsd = obj.cajadetalle.montoUsd
            objMostrarEncaja.NombreCaja = cajaBL.GetUbicar_estadosFinancierosPorID(obj.c.entidadFinanciera).descripcion
            objMostrarEncaja.entidadFinanciera = obj.tipo.tipo
            objMostrarEncaja.dni = obj.caja.idPersona
            If IsNothing(obj.caja.idPadre) Then
                objMostrarEncaja.tipousuario = "Responsable"
            Else
                objMostrarEncaja.tipousuario = "USuario dependiente"
            End If

            Select Case obj.c.codigoLibro
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"

                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "02" ' COMPRAS
                    'DocumentoCompra = DocumentoCompraBL.GetUbicar_documentocompraPorID(obj.IdCompra)
                    'If Not IsNothing(DocumentoCompra) Then
                    '    With DocumentoCompra
                    'objMostrarEncaja.NombreEntidad = entidadBL.GetUbicarEntidadPorID(.idProveedor).First.nombreCompleto
                    'objMostrarEncaja.Comprobante = tablaDetalleBL.GetUbicarTablaID(10, .tipoDoc).descripcion.Substring(0, 3)
                    'objMostrarEncaja.SerieCompra = .serie
                    'objMostrarEncaja.numeroCompra = .numeroDoc
                    'objMostrarEncaja.monedaCompra = .monedaDoc
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                    '    End With
                    'End If
                Case "105" 'APERTURA DE CAJAS
                    'persona = personaBL.ObtenerPersonaNumDoc(strIdEmpresa, obj.IdPersona)
                    'If Not IsNothing(persona) Then
                    '    objMostrarEncaja.NombreEntidad = persona.nombreCompleto
                    '    objMostrarEncaja.Comprobante = "VOUCHER DE CAJA"
                    '    objMostrarEncaja.SerieCompra = 0
                    '    objMostrarEncaja.numeroCompra = 0
                    '    objMostrarEncaja.monedaCompra = 0
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                    '   End If
                Case "01" 'VENTAS
                    'DocumentoVenta = DocumentoVentaBL.GetUbicar_documentoventaAbarrotesPorID(obj.IdCompra)
                    'If Not IsNothing(DocumentoVenta) Then
                    '    With DocumentoVenta
                    '        objMostrarEncaja.NombreEntidad = "Varios" ' entidadBL.GetUbicarEntidadPorID(.id).First.nombreCompleto
                    '        objMostrarEncaja.Comprobante = "VOUCHER DE CAJA" 'tablaDetalleBL.GetUbicarTablaID(10, .tipoDoc).descripcion.Substring(0, 3)
                    '        objMostrarEncaja.SerieCompra = .serie
                    '        objMostrarEncaja.numeroCompra = .numeroDoc
                    '        objMostrarEncaja.monedaCompra = .moneda
                    objMostrarEncaja.NombreOperacion = "VENTA"
                    '    End With
                    'End If

                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
            End Select

            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function


#Region "OTROS MOVIMIENTOS EN CAJA"

    Public Function ObtenerMovimientosPorPeriodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim lista As New List(Of String)
        lista.Add(MovimientoCaja.TrasferenciaEntreCajas)
        lista.Add(MovimientoCaja.Otras_Entradas)
        lista.Add(MovimientoCaja.Otras_Saliadas)
        Dim consulta = From c In HeliosData.documentoCaja
                       Join d In HeliosData.documento
                        On c.idDocumento Equals d.idDocumento
                       Group Join ent1 In HeliosData.estadosFinancieros
                        On c.entidadFinanciera Equals ent1.idestado
                        Into ords1 = Group
                       From x In ords1.DefaultIfEmpty
                       Group Join ent2 In HeliosData.estadosFinancieros
                        On c.entidadFinancieraDestino Equals ent2.idestado
                        Into ords2 = Group
                       From x1 In ords2.DefaultIfEmpty
                       Where c.idEmpresa = strIdEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                        And c.periodo = strPeriodo And lista.Contains(c.movimientoCaja)
                       Order By c.fechaProceso
                       Select New With {
                            .idDocumento = c.idDocumento,
                            .movimiento = c.tipoOperacion,
                            .cajaOrigen = x.descripcion,
                            .cajaDestino = x1.descripcion,
                            .moneda = c.moneda,
                            .tipoCambio = c.tipoCambio,
                            .FechaCobro = c.fechaCobro,
                            .TipoMovimiento = c.tipoMovimiento,
                            .TipoDoc = c.tipoDocPago,
                            .NumDoc = d.nroDoc,
                            .numOperacion = c.numeroOperacion,
                            .Glosa = c.glosa,
                            .MontoSoles = c.montoSoles,
                            .MontoDolares = c.montoUsd}

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja() With
                               {
                                .idDocumento = obj.idDocumento,
                            .tipoOperacion = obj.movimiento,
                            .NomCajaOrigen = obj.cajaOrigen,
                            .NomCajaDestino = obj.cajaDestino,
                            .moneda = obj.moneda,
                            .tipoCambio = obj.tipoCambio,
                            .fechaCobro = obj.FechaCobro,
                            .tipoMovimiento = obj.TipoMovimiento,
                            .tipoDocPago = obj.TipoDoc,
                            .numeroDoc = obj.NumDoc,
                            .numeroOperacion = obj.numOperacion,
                            .glosa = obj.Glosa,
                            .montoSoles = obj.MontoSoles,
                            .montoUsd = obj.MontoDolares
                                 }
            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function

    Public Function ObtenerMovimientosPorDia(strIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim lista As New List(Of String)
        lista.Add("TEC")
        lista.Add("OEC")
        lista.Add("OSC")
        Dim consulta = From c In HeliosData.documentoCaja
                       Join d In HeliosData.documento
                        On c.idDocumento Equals d.idDocumento
                       Group Join ent1 In HeliosData.estadosFinancieros
                        On c.entidadFinanciera Equals ent1.idestado
                        Into ords1 = Group
                       From x In ords1.DefaultIfEmpty
                       Group Join ent2 In HeliosData.estadosFinancieros
                        On c.entidadFinancieraDestino Equals ent2.idestado
                        Into ords2 = Group
                       From x1 In ords2.DefaultIfEmpty
                       Where c.idEmpresa = strIdEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                        And c.fechaCobro.Value.Day = CDate(DateTime.Now).Day _
                        And c.fechaCobro.Value.Month = CDate(DateTime.Now).Month _
                        And c.fechaCobro.Value.Year = CDate(DateTime.Now).Year And lista.Contains(c.tipoOperacion)
                       Select New With {
                            .idDocumento = c.idDocumento,
                            .movimiento = c.tipoOperacion,
                            .cajaOrigen = x.descripcion,
                            .cajaDestino = x1.descripcion,
                            .moneda = c.moneda,
                            .tipoCambio = c.tipoCambio,
                            .FechaCobro = c.fechaCobro,
                            .TipoMovimiento = c.tipoMovimiento,
                            .TipoDoc = c.tipoDocPago,
                            .NumDoc = d.nroDoc,
                            .numOperacion = c.numeroOperacion,
                            .Glosa = c.glosa,
                            .MontoSoles = c.montoSoles,
                            .MontoDolares = c.montoUsd}

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja() With
                               {
                                .idDocumento = obj.idDocumento,
                            .tipoOperacion = obj.movimiento,
                            .NomCajaOrigen = obj.cajaOrigen,
                            .NomCajaDestino = obj.cajaDestino,
                            .moneda = obj.moneda,
                            .tipoCambio = obj.tipoCambio,
                            .fechaCobro = obj.FechaCobro,
                            .tipoMovimiento = obj.TipoMovimiento,
                            .tipoDocPago = obj.TipoDoc,
                            .numeroDoc = obj.NumDoc,
                            .numeroOperacion = obj.numOperacion,
                            .glosa = obj.Glosa,
                            .montoSoles = obj.MontoSoles,
                            .montoUsd = obj.MontoDolares
                                 }
            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function
#End Region

    'Public Sub EliminarDocumentoPorIdPadre(intIdDocumentoPadre As Integer)
    '    Dim totalesCajaUsuario As New CajaUsuarioBL
    '    Using ts As New TransactionScope
    '        Dim consulta = (From n In HeliosData.documentoCajaDetalle _
    '                       Where n.documentoAfectado = intIdDocumentoPadre _
    '                       Select n).ToList

    '        For Each i As documentoCajaDetalle In consulta
    '            totalesCajaUsuario.DeleteTotalesCajaUsuarioCompra(i.documentoAfectado, i.usuarioModificacion)
    '            EliminarDocCaja(i.idDocumento)
    '        Next
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    'End Sub
    Public Sub EliminarDocumentoPorIdPadreSL(ByVal ojbDocumento As documento)
        Dim totalesCajaUsuario As New CajaUsuarioBL
        Dim notificacionAlmacen As New notificacionAlmacenBL
        Using ts As New TransactionScope
            Dim consulta = (From n In HeliosData.documentoCajaDetalle
                            Where n.documentoAfectado = ojbDocumento.idDocumento
                            Select n).ToList

            notificacionAlmacen.notificaionesCaja(ojbDocumento)

            For Each i As documentoCajaDetalle In consulta
                EliminarDocCaja(i.idDocumento)

            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Sub EliminarDocCaja(intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = intIdDocumento).First

            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function ObtenerCajaOnlinePorDia(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL

        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL

        Dim persona As New Persona
        Dim personaBL As New PersonaBL

        Dim consulta = (From c In HeliosData.documentoCaja
                        Join cajadetalle In HeliosData.documentoCajaDetalle
                        On cajadetalle.idDocumento Equals c.idDocumento
                        Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.entidadFinanciera
                        Join caja In HeliosData.cajaUsuario
                        On caja.idcajaUsuario Equals c.usuarioModificacion
                        Where c.idEmpresa = strIdEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                        And c.fechaCobro.Value.Day = CDate(DateTime.Now).Day _
                       And c.fechaCobro.Value.Month = CDate(DateTime.Now).Month _
                       And c.fechaCobro.Value.Year = CDate(DateTime.Now).Year _
                        And c.entidadFinanciera = strEntidadFinanciera).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja

            objMostrarEncaja.fechaCobro = obj.c.fechaCobro
            objMostrarEncaja.tipoMovimiento = obj.c.tipoMovimiento
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.c.tipoDocPago, ":", obj.cajadetalle.DetalleItem)
            objMostrarEncaja.NumeroDocumento = obj.c.numeroDoc
            objMostrarEncaja.glosa = obj.c.glosa
            objMostrarEncaja.montoSoles = obj.cajadetalle.montoSoles
            objMostrarEncaja.montoUsd = obj.cajadetalle.montoUsd
            objMostrarEncaja.NombreCaja = String.Empty
            objMostrarEncaja.entidadFinanciera = obj.tipo.tipo
            objMostrarEncaja.dni = obj.caja.idPersona
            If IsNothing(obj.caja.idPadre) Then
                objMostrarEncaja.tipousuario = "Responsable"
            Else
                objMostrarEncaja.tipousuario = "USuario dependiente"
            End If

            Select Case obj.c.codigoLibro
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"

                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "02" ' COMPRAS
                    'DocumentoCompra = DocumentoCompraBL.GetUbicar_documentocompraPorID(obj.IdCompra)
                    'If Not IsNothing(DocumentoCompra) Then
                    '    With DocumentoCompra
                    'objMostrarEncaja.NombreEntidad = entidadBL.GetUbicarEntidadPorID(.idProveedor).First.nombreCompleto
                    'objMostrarEncaja.Comprobante = tablaDetalleBL.GetUbicarTablaID(10, .tipoDoc).descripcion.Substring(0, 3)
                    'objMostrarEncaja.SerieCompra = .serie
                    'objMostrarEncaja.numeroCompra = .numeroDoc
                    'objMostrarEncaja.monedaCompra = .monedaDoc
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                    '    End With
                    'End If
                Case "105" 'APERTURA DE CAJAS
                    'persona = personaBL.ObtenerPersonaNumDoc(strIdEmpresa, obj.IdPersona)
                    'If Not IsNothing(persona) Then
                    '    objMostrarEncaja.NombreEntidad = persona.nombreCompleto
                    '    objMostrarEncaja.Comprobante = "VOUCHER DE CAJA"
                    '    objMostrarEncaja.SerieCompra = 0
                    '    objMostrarEncaja.numeroCompra = 0
                    '    objMostrarEncaja.monedaCompra = 0
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                    '   End If
                Case "01" 'VENTAS
                    'DocumentoVenta = DocumentoVentaBL.GetUbicar_documentoventaAbarrotesPorID(obj.IdCompra)
                    'If Not IsNothing(DocumentoVenta) Then
                    '    With DocumentoVenta
                    '        objMostrarEncaja.NombreEntidad = "Varios" ' entidadBL.GetUbicarEntidadPorID(.id).First.nombreCompleto
                    '        objMostrarEncaja.Comprobante = "VOUCHER DE CAJA" 'tablaDetalleBL.GetUbicarTablaID(10, .tipoDoc).descripcion.Substring(0, 3)
                    '        objMostrarEncaja.SerieCompra = .serie
                    '        objMostrarEncaja.numeroCompra = .numeroDoc
                    '        objMostrarEncaja.monedaCompra = .moneda
                    objMostrarEncaja.NombreOperacion = "VENTA"
                    '    End With
                    'End If

                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
            End Select

            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnlinePorRango(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strEntidadFinanciera As String, desde As Date, hasta As Date) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)

        Dim consulta = From c In HeliosData.documentoCaja
                       Join d In HeliosData.documento
                        On c.idDocumento Equals d.idDocumento
                       Where c.idEmpresa = strIdEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                        And c.fechaCobro >= desde _
                       And c.fechaCobro <= hasta _
                        And c.entidadFinanciera = strEntidadFinanciera
                       Select New With {.FechaCobro = c.fechaCobro,
                                         .TipoMovimiento = c.tipoMovimiento,
                                         .TipoDoc = d.tipoDoc,
                                         .NumDoc = d.nroDoc, .Glosa = c.glosa,
                                         .MontoSoles = c.montoSoles,
                                         .MontoDolares = c.montoUsd}

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja() With
                               {
                                .fechaCobro = obj.FechaCobro,
                                .tipoMovimiento = obj.TipoMovimiento,
                                .TipoDocumentoPago = obj.TipoDoc,
                                .NumeroDocumento = obj.NumDoc,
                                .glosa = obj.Glosa,
                                .montoSoles = obj.MontoSoles,
                                .montoUsd = obj.MontoDolares
                                 }
            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function



    Public Function InsertME(ByVal documentoCajaBE As documentoCaja, intDocumento As Integer) As Integer
        Dim nDocumentoCaja As New documentoCaja
        Using ts As New TransactionScope

            With nDocumentoCaja
                .codigoLibro = documentoCajaBE.codigoLibro
                .idDocumento = intDocumento
                .idEmpresa = documentoCajaBE.idEmpresa
                .idEstablecimiento = documentoCajaBE.idEstablecimiento
                .tipoMovimiento = documentoCajaBE.tipoMovimiento
                .codigoProveedor = documentoCajaBE.codigoProveedor
                .periodo = documentoCajaBE.periodo
                .formapago = documentoCajaBE.formapago
                .fechaCobro = documentoCajaBE.fechaCobro
                .tipoDocPago = documentoCajaBE.tipoDocPago
                .numeroDoc = documentoCajaBE.numeroDoc
                .idPersonal = documentoCajaBE.idPersonal
                .moneda = documentoCajaBE.moneda
                .entidadFinanciera = documentoCajaBE.entidadFinanciera
                .entidadFinancieraDestino = documentoCajaBE.entidadFinancieraDestino
                .tipoOperacion = documentoCajaBE.tipoOperacion
                .numeroOperacion = documentoCajaBE.numeroOperacion
                .bancoEntidad = documentoCajaBE.bancoEntidad
                .ctaCorrienteDeposito = documentoCajaBE.ctaCorrienteDeposito
                .tipoCambio = documentoCajaBE.tipoCambio
                .montoSoles = documentoCajaBE.montoSoles
                .montoUsd = documentoCajaBE.montoUsd
                .tipoPersona = documentoCajaBE.tipoPersona
                .idCajaUsuario = documentoCajaBE.idCajaUsuario
                .idCajaUsuarioDestino = documentoCajaBE.idCajaUsuarioDestino
                .glosa = documentoCajaBE.glosa
                .entregado = documentoCajaBE.entregado
                .ctaIntebancaria = documentoCajaBE.ctaIntebancaria
                .movimientoCaja = documentoCajaBE.movimientoCaja
                .estado = documentoCajaBE.estado
                .tipoEntidadFinanciera = documentoCajaBE.tipoEntidadFinanciera
                .usuarioModificacion = documentoCajaBE.usuarioModificacion
                .fechaModificacion = documentoCajaBE.fechaModificacion
                .fechaProceso = documentoCajaBE.fechaProceso
                .estadopago = StatusPagoMonedaExtranjera.Pendiente
                .fechaProcesoDestino = documentoCajaBE.fechaProcesoDestino
                .idRol = documentoCajaBE.idRol
                .IdUsuarioTransaccion = documentoCajaBE.IdUsuarioTransaccion
            End With
            HeliosData.documentoCaja.Add(nDocumentoCaja)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoCajaBE.idDocumento = nDocumentoCaja.idDocumento
            Return nDocumentoCaja.idDocumento
        End Using
    End Function

    Public Function ListaChequesPorProveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer, strPeriodo As String)
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja
        Dim consulta = (From n In HeliosData.documentoCaja
                        Join EF In HeliosData.estadosFinancieros
                       On n.entidadFinanciera Equals EF.idestado
                        Where n.idEstablecimiento = intIdEstablecimiento _
                       And n.codigoProveedor = intIdProveedor _
                       And n.tipoDocPago = "007" _
                       And n.codigoLibro = "02" _
                       And n.periodo = strPeriodo).ToList

        For Each i In consulta
            docCuenta = New documentoCaja
            docCuenta.NombreCaja = i.EF.descripcion
            docCuenta.idDocumento = i.n.idDocumento
            docCuenta.tipoDocPago = "CHEQUE"
            docCuenta.numeroDoc = i.n.numeroDoc
            docCuenta.fechaProceso = i.n.fechaProceso
            Select Case i.n.entregado
                Case "SI"
                    docCuenta.fechaCobro = i.n.fechaCobro
                    docCuenta.numeroOperacion = i.n.numeroOperacion
                Case "NO"
                    docCuenta.fechaCobro = Nothing
                    docCuenta.numeroOperacion = Nothing
            End Select

            docCuenta.moneda = i.n.moneda
            docCuenta.montoSoles = i.n.montoSoles
            docCuenta.montoUsd = i.n.montoUsd
            docCuenta.usuarioModificacion = i.n.usuarioModificacion
            docCuenta.entregado = i.n.entregado
            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function


    Public Function ListaChequesPendientesXProveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer, strPeriodo As String) As Integer
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja
        Return (From n In HeliosData.documentoCaja
                Join EF In HeliosData.estadosFinancieros
                       On n.entidadFinanciera Equals EF.idestado
                Where n.idEstablecimiento = intIdEstablecimiento _
                       And n.codigoProveedor = intIdProveedor _
                       And n.tipoDocPago = "007" _
                       And n.entregado = "NO").Count


    End Function

    ''' <summary>
    ''' Función que devuelve el número de compras pendientes de pago
    ''' </summary>
    ''' <param name="intIdEstablecimiento"></param>
    ''' <param name="intIdProveedor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaComprasPendientesXproveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer) As Integer
        Dim listaDoc As New List(Of String)
        listaDoc.Add(TIPO_COMPRA.COMPRA_AL_CREDITO)
        listaDoc.Add(TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION)
        listaDoc.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)
        listaDoc.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)

        Return (From n In HeliosData.documentocompra
                Where n.idCentroCosto = intIdEstablecimiento _
                       And n.idProveedor = intIdProveedor _
                       And listaDoc.Contains(n.tipoCompra) _
                       And n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count


    End Function

    ''' <summary>
    ''' Anular Operaciones: Otras entradas y salidas de caja
    ''' </summary>
    Public Sub AnularOtrosPagos(be As documento)
        Dim asientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope()
                asientoBL.DeletePorDocumento(be.idDocumento)
                Dim caja = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = be.idDocumento).Single

                Select Case caja.estado
                    Case "0"
                        Throw New Exception("Está transacción ya fue anulada, elija otra.")
                End Select

                caja.estado = "0"
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function SaveGroupCajaOtrosMovimientosSingleME(objDocumentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim numeracionBL As New numeracionBoletasBL
        Dim cierreCajaBL As New cierreCajaBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Dim docCajaBl As New documentoCajaBL

        Dim tipoDocInterno As String = String.Empty
        Dim nroDocInterno As String = String.Empty
        Dim serieDocInterno As String = String.Empty

        Try
            Using ts As New TransactionScope()
                Dim fechaActual = New Date(objDocumentoBE.documentoCaja.fechaProceso.Value.Year, objDocumentoBE.documentoCaja.fechaProceso.Value.Month, 1)
                Dim fechaAnterior = fechaActual.AddMonths(-1)

                'si es false es porque no esta dentro del inicio de operaciones
                Dim valor = empresaCierreMensualBL.GetValidaFechaInicioOperacion(objDocumentoBE.idEmpresa, fechaActual, objDocumentoBE.idCentroCosto)
                If valor = "False" Then
                    If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                        Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                    End If

                    If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month, objDocumentoBE.idCentroCosto) = False Then
                        Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                    End If
                ElseIf valor = "True" Then
                    Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
                Else
                    If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                        Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                    End If

                    'If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month) = False Then
                    '    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                    'End If
                End If

                'If empresaCierreMensualBL.EsInicioDeinventario(New empresaCierreMensual With
                '                                {.idEmpresa = objDocumentoBE.idEmpresa,
                '                                 .anio = fechaAnterior.Year,
                '                                 .mes = fechaAnterior.Month}) = True Then
                '    Throw New Exception("No puede ingresar en el cierre de inicio: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                'Else

                'End If



                'Dim numeracionAuto = numeracionBL.GenerarNumeroPorCodigoEmpresa("OES", objDocumentoBE.idEmpresa, "9901", objDocumentoBE.idCentroCosto)

                If (objDocumentoBE.IdPerfil > 0) Then
                    Dim numeracionAuto = numeracionBL.NumeracionBoletasSelV2(objDocumentoBE.idCentroCosto, objDocumentoBE.tipo, "9901", objDocumentoBE.IdPerfil)
                    If (Not IsNothing(numeracionAuto)) Then
                        serieDocInterno = numeracionAuto.serie
                        tipoDocInterno = numeracionAuto.tipo
                        nroDocInterno = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(numeracionAuto.IdEnumeracion))


                        Dim saldo As Decimal = 0

                        If objDocumentoBE.documentoCaja.tipoEntidadFinanciera = "EF" Then
                            saldo = docCajaBl.SaldoCajaOnlineAdmi(New documentoCaja With {.fechaProceso = DateTime.Now,
                                                                                  .entidadFinancieraDestino = objDocumentoBE.documentoCaja.entidadFinancieraDestino})
                        ElseIf objDocumentoBE.documentoCaja.tipoEntidadFinanciera = "EP" Then
                            saldo = docCajaBl.SaldoCajaOnline(New documentoCaja With {.fechaProceso = DateTime.Now,
                                                                                  .entidadFinanciera = objDocumentoBE.documentoCaja.entidadFinanciera, .tipoEntidadFinanciera = "EP"})
                        End If
                        'Dim saldo = docCajaBl.SaldoCajaOnline(New documentoCaja With {.fechaProceso = DateTime.Now,
                        '                                                          .entidadFinanciera = objDocumentoBE.documentoCaja.entidadFinanciera})

                        If objDocumentoBE.documentoCaja.MontoIngresosMN <= saldo Then

                            objDocumentoBE.nroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                            documentoBL.Insert(objDocumentoBE)
                            objDocumentoBE.documentoCaja.estado = "1"
                            objDocumentoBE.documentoCaja.numeroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                            InsertME(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                            'cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)
                            cajaDetalleBL.InsertCajaME(objDocumentoBE, objDocumentoBE.idDocumento, objDocumentoBE.documentoCaja.entidadFinanciera)
                            AsientoBL.SavebyGroupDoc(objDocumentoBE)
                            HeliosData.SaveChanges()
                            ts.Complete()
                        Else
                            Throw New Exception("No hay Saldo Suficiente")

                        End If





                    Else
                        Throw New Exception("Verificar Permiso")
                    End If
                Else
                    Throw New Exception("Verificar datos")
                End If




            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objDocumentoBE.idDocumento
    End Function

    Public Function BuscarCajaOtrosMovimientosSingleME() As Decimal
        Dim lista As New List(Of String)
        lista.Add("2")
        lista.Add("0")

        Dim listaTipoMovimiento As New List(Of String)
        listaTipoMovimiento.Add("DC")
        listaTipoMovimiento.Add("ANT-C")

        Try
            Using ts As New TransactionScope

                Dim totales = (From p In HeliosData.documentoCaja
                               Join d In HeliosData.documentoCajaDetalle
                                                      On p.idDocumento Equals d.idDocumento
                               Where listaTipoMovimiento.Contains(p.tipoMovimiento)
                               Group d By
                 p.tipoMovimiento
                 Into g = Group
                               Select New With {.tipoMov = tipoMovimiento,
                                 g, .montoUSD = g.Sum(Function(p) p.montoUsd)
                                                             }
                         ).FirstOrDefault


                If (Not IsNothing(totales)) Then
                    Return totales.montoUSD
                Else
                    Return 0
                End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SaveGroupCajaOtrosMovimientosME(objDocumentoBE As documento)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim cierreCajaBL As New cierreCajaBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Try
            Using ts As New TransactionScope()

                Dim fechaActual = New Date(objDocumentoBE.documentoCaja.fechaProceso.Value.Year, objDocumentoBE.documentoCaja.fechaProceso.Value.Month, 1)
                Dim fechaAnterior = fechaActual.AddMonths(-1)

                'si es false es porque no esta dentro del inicio de operaciones
                Dim valor = empresaCierreMensualBL.GetValidaFechaInicioOperacion(objDocumentoBE.idEmpresa, fechaActual, objDocumentoBE.idCentroCosto)
                If valor = "False" Then
                    If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                        Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                    End If

                    If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month, objDocumentoBE.idCentroCosto) = False Then
                        Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                    End If
                ElseIf valor = "True" Then
                    Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
                Else
                    If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                        Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                    End If

                    'If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month) = False Then
                    '    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                    'End If
                End If

                CajaEntradaSalidaME(objDocumentoBE, objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                'Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                'cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub CajaEntradaSalidaME(documentoBE As documento, documentoCajaBE As documentoCaja, intIdDocumento As Integer)
    '    Dim documentoBL As New documentoBL
    '    Dim cajaDetalleBL As New documentoCajaDetalleBL
    '    Try
    '        Using ts As New TransactionScope()
    '            Me.InserParam(documentoCajaBE, intIdDocumento, "PG")
    '            CajaAperturaIDDoc = intIdDocumento
    '            cajaDetalleBL.InsertAperturaME(documentoBE, intIdDocumento, documentoCajaBE.entidadFinanciera)

    '            documentoBL.Insert(documentoBE)
    '            Me.InserParam2(documentoCajaBE, documentoBE.idDocumento, "DC")
    '            cajaDetalleBL.InsertTransferenciaME(documentoBE, documentoBE.idDocumento, intIdDocumento)
    '            HeliosData.SaveChanges()
    '            ts.Complete()
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Sub CajaEntradaSalidaME(documentoBE As documento, documentoCajaBE As documentoCaja, intIdDocumento As Integer)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim idDocOrigen As Integer
        Dim idDocDestino As Integer
        Dim listadocumentoDestino As List(Of documentoCajaDetalle)
        Dim AsientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope()
                'documentoBL.Insert(documentoBE)
                'CajaAperturaIDDoc = intIdDocumento
                idDocOrigen = documentoBL.InsertTranferencia(documentoBE)
                Me.InserParam(documentoCajaBE, idDocOrigen, "PG")
                listadocumentoDestino = cajaDetalleBL.InsertAperturaME(documentoBE, idDocOrigen, documentoCajaBE.entidadFinanciera)


                idDocDestino = documentoBL.InsertTranferencia(documentoBE)
                Me.InserParam2(documentoCajaBE, idDocDestino, "DC")
                'cajaDetalleBL.InsertAperturaME(documentoBE, intIdDocumento, documentoCajaBE.entidadFinanciera)
                cajaDetalleBL.Getransferencia(documentoBE, idDocDestino)

                documentoBE.idDocumento = idDocOrigen
                AsientoBL.SavebyGroupDoc(documentoBE)

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function ObtenerCajaOnlineME2(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL
        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)

        'Join caja In HeliosData.cajaUsuario _
        '               On caja.idcajaUsuario Equals c.usuarioModificacion _

        Dim consulta = (From c In HeliosData.documentoCaja
                        Join cajadetalle In HeliosData.documentoCajaDetalle
                        On cajadetalle.idDocumento Equals c.idDocumento
                        Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.entidadFinanciera
                        Where c.idEmpresa = strIdEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                        And c.periodo = strPeriodo _
                        And c.entidadFinanciera = strEntidadFinanciera
                        Order By cajadetalle.fecha).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.idDocumento = obj.c.idDocumento
            objMostrarEncaja.IdEntidadFinanciera = obj.tipo.idestado
            objMostrarEncaja.fechaCobro = obj.cajadetalle.fecha
            objMostrarEncaja.tipoMovimiento = obj.c.tipoMovimiento
            objMostrarEncaja.saldoMN = obj.c.montoSoles
            objMostrarEncaja.fechaProceso = obj.c.fechaCobro
            Select Case obj.c.tipoMovimiento
                Case "DC"
                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                    Select Case obj.c.tipoOperacion
                        Case "TEC"
                            objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                        Case Else
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                    End Select
                Case "PG"
                    Select Case obj.c.tipoOperacion
                        Case "TEC"
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                        Case Else
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                    End Select
                Case "ANT-C"
                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio

            End Select
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.c.TipoDocumentoPago, ":", obj.cajadetalle.DetalleItem)
            objMostrarEncaja.tipoDocPago = obj.c.tipoDocPago
            objMostrarEncaja.NumeroDocumento = obj.c.numeroDoc
            objMostrarEncaja.glosa = obj.c.glosa
            objMostrarEncaja.montoSoles = obj.cajadetalle.montoSoles
            objMostrarEncaja.montoSolesTransacc = obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            objMostrarEncaja.montoUsdTransacc = obj.cajadetalle.montoUsdTransacc.GetValueOrDefault
            objMostrarEncaja.montoUsd = obj.cajadetalle.montoUsd
            objMostrarEncaja.NombreCaja = obj.tipo.descripcion
            objMostrarEncaja.entidadFinanciera = obj.tipo.tipo
            objMostrarEncaja.dni = String.Empty
            objMostrarEncaja.DetalleItem = obj.cajadetalle.DetalleItem
            'If IsNothing(obj.caja.idPadre) Then
            objMostrarEncaja.tipousuario = "Responsable"

            'Else
            'objMostrarEncaja.tipousuario = "USuario dependiente"
            'End If

            Select Case obj.c.codigoLibro
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "9908"
                    objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    'DocumentoCompra = DocumentoCompraBL.GetUbicar_documentocompraPorID(obj.IdCompra)
                    'If Not IsNothing(DocumentoCompra) Then
                    '    With DocumentoCompra
                    'objMostrarEncaja.NombreEntidad = entidadBL.GetUbicarEntidadPorID(.idProveedor).First.nombreCompleto
                    'objMostrarEncaja.Comprobante = tablaDetalleBL.GetUbicarTablaID(10, .tipoDoc).descripcion.Substring(0, 3)
                    'objMostrarEncaja.SerieCompra = .serie
                    'objMostrarEncaja.numeroCompra = .numeroDoc
                    'objMostrarEncaja.monedaCompra = .monedaDoc
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                    '    End With
                    'End If
                Case "105" 'APERTURA DE CAJAS
                    'persona = personaBL.ObtenerPersonaNumDoc(strIdEmpresa, obj.IdPersona)
                    'If Not IsNothing(persona) Then
                    '    objMostrarEncaja.NombreEntidad = persona.nombreCompleto
                    '    objMostrarEncaja.Comprobante = "VOUCHER DE CAJA"
                    '    objMostrarEncaja.SerieCompra = 0
                    '    objMostrarEncaja.numeroCompra = 0
                    '    objMostrarEncaja.monedaCompra = 0
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                    '   End If
                Case "01" 'VENTAS
                    'DocumentoVenta = DocumentoVentaBL.GetUbicar_documentoventaAbarrotesPorID(obj.IdCompra)
                    'If Not IsNothing(DocumentoVenta) Then
                    '    With DocumentoVenta
                    '        objMostrarEncaja.NombreEntidad = "Varios" ' entidadBL.GetUbicarEntidadPorID(.id).First.nombreCompleto
                    '        objMostrarEncaja.Comprobante = "VOUCHER DE CAJA" 'tablaDetalleBL.GetUbicarTablaID(10, .tipoDoc).descripcion.Substring(0, 3)
                    '        objMostrarEncaja.SerieCompra = .serie
                    '        objMostrarEncaja.numeroCompra = .numeroDoc
                    '        objMostrarEncaja.monedaCompra = .moneda
                    objMostrarEncaja.NombreOperacion = "VENTA"
                    '    End With
                    'End If
                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
            End Select

            ListaCaja.Add(objMostrarEncaja)
        Next
        Return ListaCaja
    End Function

    Public Function ObtenerCajaOnlineME(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL
        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)

        'Join caja In HeliosData.cajaUsuario _
        '               On caja.idcajaUsuario Equals c.usuarioModificacion _


        'And c.idEstablecimiento = intIdEstablecimiento _

        Dim consulta = (From c In HeliosData.documentoCaja
                        Join cajadetalle In HeliosData.documentoCajaDetalle
                        On cajadetalle.idDocumento Equals c.idDocumento
                        Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.entidadFinanciera
                        Where c.idEmpresa = strIdEmpresa _
                        And c.periodo = strPeriodo _
                        And c.entidadFinanciera = strEntidadFinanciera
                        Order By cajadetalle.fecha).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.idDocumento = obj.c.idDocumento
            objMostrarEncaja.IdEntidadFinanciera = obj.tipo.idestado
            objMostrarEncaja.fechaCobro = obj.cajadetalle.fecha
            objMostrarEncaja.tipoMovimiento = obj.c.tipoMovimiento
            objMostrarEncaja.saldoMN = obj.c.montoSoles
            objMostrarEncaja.fechaProceso = obj.c.fechaCobro
            Select Case obj.c.tipoMovimiento
                Case "DC"
                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                    Select Case obj.c.tipoOperacion
                        Case "TEC"
                            objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                        Case Else
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                    End Select
                Case "PG"
                    Select Case obj.c.tipoOperacion
                        Case "TEC"
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                        Case Else
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                    End Select
                Case "ANT-C"
                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio

            End Select
            objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.c.TipoDocumentoPago, ":", obj.cajadetalle.DetalleItem)
            objMostrarEncaja.tipoDocPago = obj.c.tipoDocPago
            objMostrarEncaja.NumeroDocumento = obj.c.numeroDoc
            objMostrarEncaja.glosa = obj.c.glosa
            objMostrarEncaja.montoSoles = obj.cajadetalle.montoSoles
            objMostrarEncaja.montoSolesTransacc = obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
            objMostrarEncaja.montoUsdTransacc = obj.cajadetalle.montoUsdTransacc.GetValueOrDefault
            objMostrarEncaja.montoUsd = obj.cajadetalle.montoUsd
            objMostrarEncaja.NombreCaja = obj.tipo.descripcion
            objMostrarEncaja.entidadFinanciera = obj.tipo.tipo
            objMostrarEncaja.dni = String.Empty
            objMostrarEncaja.DetalleItem = obj.cajadetalle.DetalleItem
            'If IsNothing(obj.caja.idPadre) Then
            objMostrarEncaja.tipousuario = "Responsable"

            'Else
            'objMostrarEncaja.tipousuario = "USuario dependiente"
            'End If

            Select Case obj.c.codigoLibro
                Case "9912"
                    objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                Case "9909"
                    objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                Case "9910"
                    objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                Case "9911"
                    objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                Case "9907"
                    objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                Case "9908"
                    objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                Case "02" ' COMPRAS
                    'DocumentoCompra = DocumentoCompraBL.GetUbicar_documentocompraPorID(obj.IdCompra)
                    'If Not IsNothing(DocumentoCompra) Then
                    '    With DocumentoCompra
                    'objMostrarEncaja.NombreEntidad = entidadBL.GetUbicarEntidadPorID(.idProveedor).First.nombreCompleto
                    'objMostrarEncaja.Comprobante = tablaDetalleBL.GetUbicarTablaID(10, .tipoDoc).descripcion.Substring(0, 3)
                    'objMostrarEncaja.SerieCompra = .serie
                    'objMostrarEncaja.numeroCompra = .numeroDoc
                    'objMostrarEncaja.monedaCompra = .monedaDoc
                    objMostrarEncaja.NombreOperacion = "COMPRA"
                    '    End With
                    'End If
                Case "105" 'APERTURA DE CAJAS
                    'persona = personaBL.ObtenerPersonaNumDoc(strIdEmpresa, obj.IdPersona)
                    'If Not IsNothing(persona) Then
                    '    objMostrarEncaja.NombreEntidad = persona.nombreCompleto
                    '    objMostrarEncaja.Comprobante = "VOUCHER DE CAJA"
                    '    objMostrarEncaja.SerieCompra = 0
                    '    objMostrarEncaja.numeroCompra = 0
                    '    objMostrarEncaja.monedaCompra = 0
                    objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                    '   End If
                Case "01" 'VENTAS
                    'DocumentoVenta = DocumentoVentaBL.GetUbicar_documentoventaAbarrotesPorID(obj.IdCompra)
                    'If Not IsNothing(DocumentoVenta) Then
                    '    With DocumentoVenta
                    '        objMostrarEncaja.NombreEntidad = "Varios" ' entidadBL.GetUbicarEntidadPorID(.id).First.nombreCompleto
                    '        objMostrarEncaja.Comprobante = "VOUCHER DE CAJA" 'tablaDetalleBL.GetUbicarTablaID(10, .tipoDoc).descripcion.Substring(0, 3)
                    '        objMostrarEncaja.SerieCompra = .serie
                    '        objMostrarEncaja.numeroCompra = .numeroDoc
                    '        objMostrarEncaja.monedaCompra = .moneda
                    objMostrarEncaja.NombreOperacion = "VENTA"
                    '    End With
                    'End If
                Case "12.1"
                    objMostrarEncaja.NombreOperacion = "TICKET BOLETA"
                Case "12.2"
                    objMostrarEncaja.NombreOperacion = "TICKET FACTURA"
                Case "17"
                    objMostrarEncaja.NombreOperacion = "APORTES"
                Case "103"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS RECIBIDOS"
                Case "104"
                    objMostrarEncaja.NombreOperacion = "ANTICIPOS OTORGADOS"
                Case "21"
                    objMostrarEncaja.NombreOperacion = "PAGO POR COMPENSACION"
                Case "9927"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A CLIENTE"
                Case "9928"
                    objMostrarEncaja.NombreOperacion = "DEVOLUCION DE ANTICIPO A PROVEEDOR"
                Case "9926"
                    objMostrarEncaja.NombreOperacion = "REVERSIONES"
            End Select

            ListaCaja.Add(objMostrarEncaja)
        Next
        Return ListaCaja
    End Function

    Public Function GrabarPagoMembresia(objDocumentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Dim entidadmembresiaBL As New Entidadmembresia_GymBL
        Try
            Using ts As New TransactionScope()
                Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                Dim venta As Entidadmembresia_Gym = (HeliosData.Entidadmembresia_Gym.Where(Function(o) _
                                                            o.idDocumento = codigoPadre)).FirstOrDefault

                documentoBL.Insert(objDocumentoBE)
                idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                cajaDetalleBL.GetPagoDetalleMembresia(objDocumentoBE, idDocumentoRecuperado, "1")
                AsientoBL.SavebyGroupDoc(objDocumentoBE)

                'Hallando el saldo de la venta, actualizando el estado de pago
                Dim pagos = entidadmembresiaBL.GetDocumentoCajaMembresiaByDocumento(venta.idDocumento)
                Dim saldo = pagos.importe - pagos.CustomDocumentoCaja.montoSoles

                If saldo > 0 Then
                    If pagos.CustomDocumentoCaja.montoSoles.GetValueOrDefault = 0 Then
                        venta.statusPago = Gimnasio_EstadoMembresiaPago.Pendiente
                    Else
                        venta.statusPago = Gimnasio_EstadoMembresiaPago.PagoParcial
                    End If
                Else
                    venta.statusPago = Gimnasio_EstadoMembresiaPago.Completo
                End If
                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveGroupCajaME(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Dim cajaExtranjeraBL As New movimientocajaextranjeraBL
        Dim numeracionBL As New numeracionBoletasBL
        Dim cierreCajaBL As New cierreCajaBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Try

            'Dim fechaActual = objDocumentoBE.documentoCaja.fechaProceso
            'Dim fechaAnterior = fechaActual.Value.AddMonths(-1)
            Dim fechaActual = New Date(objDocumentoBE.documentoCaja.fechaProceso.Value.Year, objDocumentoBE.documentoCaja.fechaProceso.Value.Month, 1)
            Dim fechaAnterior = fechaActual.AddMonths(-1)

            'si es false es porque no esta dentro del inicio de operaciones
            Dim valor = empresaCierreMensualBL.GetValidaFechaInicioOperacion(objDocumentoBE.idEmpresa, fechaActual, objDocumentoBE.idCentroCosto)
            If valor = "False" Then
                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month, objDocumentoBE.idCentroCosto) = False Then
                    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                End If
            ElseIf valor = "True" Then
                Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
            Else
                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                'If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month) = False Then
                '    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                'End If
            End If

            Using ts As New TransactionScope()
                Dim numeracionAuto = numeracionBL.GenerarNumeroPorCodigoEmpresa("OES", objDocumentoBE.idEmpresa, "9901", objDocumentoBE.idCentroCosto)
                If numeracionAuto IsNot Nothing Then
                    Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                    Dim ventaoriginal As documentocompra = (HeliosData.documentocompra.Where(Function(o) _
                                                                o.idDocumento = codigoPadre)).FirstOrDefault

                    objDocumentoBE.nroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                    documentoBL.Insert(objDocumentoBE)

                    objDocumentoBE.documentoCaja.numeroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                    idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                    cajaDetalleBL.GetPagoDetalleSave(objDocumentoBE, idDocumentoRecuperado, ventaoriginal.monedaDoc)
                    'cajaDetalleBL.InsertPagosDeCajaCompraME(objDocumentoBE, idDocumentoRecuperado, objDocumentoBE.documentoCaja.entidadFinanciera, listaDetalle, ventaoriginal.monedaDoc)
                    'cajaDetalleBL.InsertCajaME(objDocumentoBE, idDocumentoRecuperado, objDocumentoBE.documentoCaja.entidadFinanciera)

                    AsientoBL.SavebyGroupDoc(objDocumentoBE)

                    Dim ventaDetalle = (From n In HeliosData.documentocompradetalle
                                        Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO _
                                        And n.bonificacion <> "S").Count

                    If ventaDetalle > 0 Then
                        ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    Else
                        ventaoriginal.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                    End If

                    If objDocumentoBE.documentoCaja.moneda = "2" Then
                        cajaExtranjeraBL.GrabarListaPagos(objDocumentoBE.documentoCaja, idDocumentoRecuperado)
                    End If
                Else
                    Throw New Exception("Falta configurar numeración")
                End If

                HeliosData.SaveChanges()
                ts.Complete()
                'Return idDocumentoRecuperado
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveGroupCajaVentasME(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim idDocumentoRecuperado As Integer
        Dim numeracionBL As New numeracionBoletasBL
        Dim cierreCajaBL As New cierreCajaBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Try
            Dim fechaActual = New Date(objDocumentoBE.documentoCaja.fechaProceso.Value.Year, objDocumentoBE.documentoCaja.fechaProceso.Value.Month, 1)
            Dim fechaAnterior = fechaActual.AddMonths(-1)

            'si es false es porque no esta dentro del inicio de operaciones
            Dim valor = empresaCierreMensualBL.GetValidaFechaInicioOperacion(objDocumentoBE.idEmpresa, fechaActual, objDocumentoBE.idCentroCosto)
            If valor = "False" Then
                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month, objDocumentoBE.idCentroCosto) = False Then
                    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                End If
            ElseIf valor = "True" Then
                Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
            Else
                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                'If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month) = False Then
                '    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                'End If
            End If

            Using ts As New TransactionScope()
                Dim numeracionAuto = numeracionBL.GenerarNumeroPorCodigoEmpresa("OES", Gempresas.IdEmpresaRuc, "9901", objDocumentoBE.idCentroCosto)
                If numeracionAuto IsNot Nothing Then
                    Dim codigoPadre = objDocumentoBE.documentoCaja.documentoCajaDetalle(0).documentoAfectado
                    Dim ventaoriginal As documentoventaAbarrotes = (HeliosData.documentoventaAbarrotes.Where(Function(o) _
                                                                o.idDocumento = codigoPadre)).FirstOrDefault


                    objDocumentoBE.nroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                    documentoBL.Insert(objDocumentoBE)
                    '-------------------------------------------------------------------------------------------
                    objDocumentoBE.documentoCaja.numeroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                    idDocumentoRecuperado = Me.Insert(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                    '------------------------------------------------------------------------------------------------
                    cajaDetalleBL.InsertPagosDeCajaMENew(objDocumentoBE, idDocumentoRecuperado, ventaoriginal.moneda)
                    AsientoBL.SavebyGroupDoc(objDocumentoBE)

                    Dim ventaDetalle = (From n In HeliosData.documentoventaAbarrotesDet
                                        Where n.idDocumento = ventaoriginal.idDocumento AndAlso n.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO).Count
                    If ventaDetalle > 0 Then
                        ventaoriginal.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    Else
                        ventaoriginal.estadoCobro = TIPO_VENTA.PAGO.COBRADO
                    End If
                End If

                HeliosData.SaveChanges()
                ts.Complete()
                'Return idDocumentoRecuperado
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerCajaOnlineSaldosME(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL
        Dim strPeriodo As String = String.Concat(strMEs, "/", strAnio)

        Dim listaTipoMov As New List(Of String)
        listaTipoMov.Add("DC")
        listaTipoMov.Add("ANT-C")

        Dim consulta = (From c In HeliosData.documentoCaja
                        Join cajadetalle In HeliosData.documentoCajaDetalle
                  On cajadetalle.idDocumento Equals c.idDocumento
                        Where c.idEmpresa = strIdEmpresa _
                  And c.idEstablecimiento = intIdEstablecimiento _
                  And c.periodo = strPeriodo _
                  And c.entidadFinanciera = strEntidadFinanciera _
                  And c.tipoMovimiento = "DC"
                        Order By cajadetalle.fecha).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoCaja
            objMostrarEncaja.idDocumento = obj.c.idDocumento
            objMostrarEncaja.fechaCobro = obj.c.fechaCobro
            objMostrarEncaja.tipoMovimiento = obj.c.tipoMovimiento
            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio

            objMostrarEncaja.moneda = obj.c.moneda
            'Dim consulta2 = (From x In HeliosData.documentoCajaDetalle
            '                Where x.idCajaPadre = obj.cajadetalle.idDocumento).ToList

            Dim consulta2 = Aggregate n In HeliosData.documentoCajaDetalle
                Where n.idCajaPadre = obj.cajadetalle.secuencia
         Into mn = Sum(n.montoSoles),
              mne = Sum(n.montoUsd)


            If (Not IsNothing(consulta2)) Then
                objMostrarEncaja.montoSoles = obj.cajadetalle.montoSoles - consulta2.mn.GetValueOrDefault
                objMostrarEncaja.montoUsd = obj.cajadetalle.montoUsd - consulta2.mne.GetValueOrDefault
            Else
                objMostrarEncaja.montoSoles = obj.cajadetalle.montoSoles
                objMostrarEncaja.montoUsd = obj.cajadetalle.montoUsd
            End If

            ListaCaja.Add(objMostrarEncaja)
        Next
        Return ListaCaja
    End Function


    Public Function ObtenerCajaDetallePorId(ByVal idDocumentoVenta As Integer) As documentoCaja
        Dim docCuenta As New documentoCaja
        Dim consulta = (From n In HeliosData.documentoCaja
                        Join EF In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals EF.idDocumento
                        Where n.idDocumento = idDocumentoVenta).FirstOrDefault

        'For Each items In consulta4
        If (Not IsNothing(consulta)) Then
            docCuenta = New documentoCaja
            docCuenta.idDocumento = consulta.n.idDocumento
            docCuenta.idEmpresa = consulta.n.idEmpresa
            docCuenta.idEstablecimiento = consulta.n.idEstablecimiento
            docCuenta.codigoLibro = consulta.n.idEmpresa
            docCuenta.tipoMovimiento = consulta.n.tipoMovimiento
            docCuenta.codigoProveedor = consulta.n.codigoProveedor
            docCuenta.fechaProceso = consulta.n.fechaProceso
            docCuenta.periodo = consulta.n.periodo
            docCuenta.fechaCobro = consulta.n.fechaCobro
            docCuenta.tipoDocPago = consulta.n.tipoDocPago
            docCuenta.numeroDoc = consulta.n.numeroDoc
            docCuenta.moneda = consulta.n.moneda
            docCuenta.entidadFinanciera = consulta.n.entidadFinanciera
            docCuenta.entidadFinancieraDestino = consulta.n.entidadFinancieraDestino
            docCuenta.tipoOperacion = consulta.n.tipoOperacion
            docCuenta.numeroOperacion = consulta.n.numeroOperacion
            docCuenta.tipoCambio = consulta.n.tipoCambio
            docCuenta.montoSoles = consulta.n.montoSoles
            docCuenta.montoUsd = consulta.n.montoUsd
            docCuenta.glosa = consulta.n.glosa
            docCuenta.entregado = consulta.n.entregado
            docCuenta.bancoEntidad = consulta.n.bancoEntidad
            docCuenta.ctaCorrienteDeposito = consulta.n.ctaCorrienteDeposito
            docCuenta.ctaIntebancaria = consulta.n.ctaIntebancaria
            docCuenta.movimientoCaja = consulta.n.movimientoCaja
            docCuenta.estado = consulta.n.estado
            docCuenta.usuarioModificacion = consulta.n.usuarioModificacion
            docCuenta.fechaModificacion = consulta.n.fechaModificacion
            docCuenta.IdProveedor = consulta.EF.documentoAfectado
        End If

        Return docCuenta
    End Function
    Public Function UbicarDocCajaXIdEntidadOrigen(intEntidadFinan As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer
        Dim obj As New cajaUsuario
        Dim lista As New List(Of cajaUsuario)

        Dim consulta = (From n In HeliosData.documentoCaja
                        Where n.idEmpresa = strEmpresa And n.idEstablecimiento = intEstablecimiento _
                      And n.entidadFinanciera = intEntidadFinan).Count

        Return consulta
    End Function

    Public Function ObtenerMovimientosPorPeriodoFinanzasXiDCaja(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, idCaja As Integer) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)

        Dim fechaPeriodo = GetPeriodoConvertirToDate(strPeriodo)

        Dim Consulta = (From c In HeliosData.documentoCaja
                        Join e In HeliosData.estadosFinancieros On New With {.EntidadFinanciera = c.entidadFinanciera} Equals New With {.EntidadFinanciera = CStr(e.idestado)}
                        Join e2 In HeliosData.estadosFinancieros On New With {.EntidadFinanciera = c.entidadFinanciera} Equals New With {.EntidadFinanciera = CStr(e2.idestado)}
                        Where
                            c.movimientoCaja = strMovimiento And
                            c.idEmpresa = strIdEmpresa And
                            CLng(c.idEstablecimiento) = intIdEstablecimiento And
                            c.fechaProceso.Value.Year = fechaPeriodo.Year _
                            And c.fechaProceso.Value.Month = fechaPeriodo.Month _
                            And c.idCajaUsuario = idCaja
                        Group New With {c, e, e2} By
                            c.idDocumento,
                            c.tipoOperacion,
                            e.descripcion,
                            Column1 = e2.descripcion,
                            c.moneda,
                            c.tipoCambio,
                            c.fechaCobro,
                            c.tipoMovimiento,
                            c.tipoDocPago,
                            c.numeroDoc,
                            c.numeroOperacion,
                            c.glosa,
                            c.montoSoles,
                            c.montoUsd,
                            c.tipoPersona,
                            c.idPersonal,
                            c.movimientoCaja,
                            c.fechaProceso
                            Into g = Group
                        Order By
                            fechaProceso
                        Select
                            idDocumento,
                            tipoOperacion,
                            cajaOrigen = descripcion,
                            cajaDestino = Column1,
                            moneda,
                            tipoCambio,
                            fechaCobro,
                            tipoMovimiento,
                            tipoDocPago,
                            numeroDoc,
                            numeroOperacion,
                            glosa,
                            montoSoles,
                            montoUsd,
                            tipoPersona,
                            idPersonal,
                            movimientoCaja,
                            fechaProceso,
                            montoMN = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCajaDetalle
                                                   Where
                                                       dc.idCajaPadre = idDocumento
                                                   Select New With {
                                                       dc.montoSoles
                                                       }) Into Sum(t1.montoSoles)), Decimal?)),
                            montoME = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCajaDetalle
                                                   Where
                                                       dc.idCajaPadre = idDocumento
                                                   Select New With {
                                                       dc.montoUsd
                                                       }) Into Sum(t1.montoUsd)), Decimal?))).ToList


        For Each obj In Consulta
            objMostrarEncaja = New documentoCaja() With
                               {
                                .idDocumento = obj.idDocumento,
                                .tipoOperacion = obj.tipoOperacion,
                                .NomCajaOrigen = obj.cajaOrigen,
                                .NomCajaDestino = obj.cajaDestino,
                                .moneda = obj.moneda,
                                .tipoCambio = obj.tipoCambio,
                                .fechaCobro = obj.fechaCobro,
                                .fechaProceso = obj.fechaProceso,
                                .tipoMovimiento = obj.tipoMovimiento,
                                .tipoDocPago = obj.tipoDocPago,
                                .numeroDoc = obj.numeroDoc,
                                .numeroOperacion = obj.numeroOperacion,
                                .glosa = obj.glosa,
                                .montoSoles = obj.montoSoles.GetValueOrDefault,
                                .montoUsd = obj.montoUsd.GetValueOrDefault,
                                .tipoPersona = obj.tipoPersona,
                                .idPersonal = obj.idPersonal,
                                .movimientoCaja = obj.movimientoCaja,
                                .MontoEgresosMN = obj.montoMN.GetValueOrDefault,
                                .MontoEgresosME = obj.montoME.GetValueOrDefault
                                 }
            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function

    Public Function GetOperacionesCaja(be As documentoCaja) As List(Of documentoCaja)
        GetOperacionesCaja = New List(Of documentoCaja)

        ' Dim result = warmCountries.Join(europeanCountries, Function(warm) warm, Function(european) european, Function(warm, european) warm)

        If be.tipousuario = "GNR" Then
            Dim con = HeliosData.documentoCaja.Join(HeliosData.estadosFinancieros, Function(caja) CStr(caja.entidadFinancieraDestino), Function(efe) CStr(efe.idestado), Function(caja, efe) _
                                               New With
                                               {
                                               .doccaja = caja,
                                               .enti = efe
                                               }).Where(Function(o) _
                                                    o.doccaja.idEmpresa = be.idEmpresa And
                                                    o.doccaja.idEstablecimiento = be.idEstablecimiento And
                                                    o.doccaja.movimientoCaja = be.movimientoCaja).ToList

            For Each i In con
                GetOperacionesCaja.Add(New documentoCaja With
                                       {
                                       .idDocumento = i.doccaja.idDocumento,
                                       .idEmpresa = i.doccaja.idEmpresa,
                .idEstablecimiento = i.doccaja.idEstablecimiento,
                .codigoLibro = i.doccaja.codigoLibro,
                .tipoMovimiento = i.doccaja.tipoMovimiento,
                .codigoProveedor = i.doccaja.codigoProveedor,
                .idPersonal = i.doccaja.idPersonal,
                .tipoPersona = i.doccaja.tipoPersona,
                .fechaProceso = i.doccaja.fechaProceso,
                .periodo = i.doccaja.periodo,
                .fechaCobro = i.doccaja.fechaCobro,
                .tipoDocPago = i.doccaja.tipoDocPago,
                .formapago = i.doccaja.formapago,
                .numeroDoc = i.doccaja.numeroDoc,
                .moneda = i.doccaja.moneda,
                 .NomCajaOrigen = i.enti.descripcion,
                .entidadFinanciera = i.doccaja.entidadFinanciera,
                .entidadFinancieraDestino = i.doccaja.entidadFinancieraDestino,
                .tipoOperacion = i.doccaja.tipoOperacion,
                .numeroOperacion = i.doccaja.numeroOperacion,
                .tipoCambio = i.doccaja.tipoCambio,
                .montoSoles = i.doccaja.montoSoles,
                .montoUsd = i.doccaja.montoUsd,
                .glosa = i.doccaja.glosa,
                .entregado = i.doccaja.entregado,
                .bancoEntidad = i.doccaja.bancoEntidad,
                .ctaCorrienteDeposito = i.doccaja.ctaCorrienteDeposito,
                .ctaIntebancaria = i.doccaja.ctaIntebancaria,
                .movimientoCaja = i.doccaja.movimientoCaja,
                .idcosto = i.doccaja.idcosto,
                .asientoCosto = i.doccaja.asientoCosto,
                .estado = i.doccaja.estado,
                .estadopago = i.doccaja.estadopago,
                .idCajaUsuario = i.doccaja.idCajaUsuario,
                .usuarioModificacion = i.doccaja.usuarioModificacion,
                .fechaModificacion = i.doccaja.fechaModificacion
                 })
            Next


        ElseIf be.tipousuario = "POS" Then
            Dim con = HeliosData.documentoCaja.Join(HeliosData.estadosFinancieros, Function(caja) caja.entidadFinanciera, Function(efe) CStr(efe.idestado), Function(caja, efe) _
                                                           New With
                                                           {
                                                           .doccaja = caja,
                                                           .enti = efe
                                                           }).Where(Function(o) _
                                                                o.doccaja.idEmpresa = be.idEmpresa And
                                                                o.doccaja.idEstablecimiento = be.idEstablecimiento And
                                                                o.doccaja.movimientoCaja = be.movimientoCaja).ToList

            For Each i In con
                GetOperacionesCaja.Add(New documentoCaja With
                                       {
                                       .idDocumento = i.doccaja.idDocumento,
                                       .idEmpresa = i.doccaja.idEmpresa,
                .idEstablecimiento = i.doccaja.idEstablecimiento,
                .codigoLibro = i.doccaja.codigoLibro,
                .tipoMovimiento = i.doccaja.tipoMovimiento,
                .codigoProveedor = i.doccaja.codigoProveedor,
                .idPersonal = i.doccaja.idPersonal,
                .tipoPersona = i.doccaja.tipoPersona,
                .fechaProceso = i.doccaja.fechaProceso,
                .periodo = i.doccaja.periodo,
                .fechaCobro = i.doccaja.fechaCobro,
                .tipoDocPago = i.doccaja.tipoDocPago,
                .formapago = i.doccaja.formapago,
                .numeroDoc = i.doccaja.numeroDoc,
                .moneda = i.doccaja.moneda,
                 .NomCajaOrigen = i.enti.descripcion,
                .entidadFinanciera = i.doccaja.entidadFinanciera,
                .entidadFinancieraDestino = i.doccaja.entidadFinancieraDestino,
                .tipoOperacion = i.doccaja.tipoOperacion,
                .numeroOperacion = i.doccaja.numeroOperacion,
                .tipoCambio = i.doccaja.tipoCambio,
                .montoSoles = i.doccaja.montoSoles,
                .montoUsd = i.doccaja.montoUsd,
                .glosa = i.doccaja.glosa,
                .entregado = i.doccaja.entregado,
                .bancoEntidad = i.doccaja.bancoEntidad,
                .ctaCorrienteDeposito = i.doccaja.ctaCorrienteDeposito,
                .ctaIntebancaria = i.doccaja.ctaIntebancaria,
                .movimientoCaja = i.doccaja.movimientoCaja,
                .idcosto = i.doccaja.idcosto,
                .asientoCosto = i.doccaja.asientoCosto,
                .estado = i.doccaja.estado,
                .estadopago = i.doccaja.estadopago,
                .idCajaUsuario = i.doccaja.idCajaUsuario,
                .usuarioModificacion = i.doccaja.usuarioModificacion,
                .fechaModificacion = i.doccaja.fechaModificacion
                 })
            Next

        End If

        Return GetOperacionesCaja

    End Function


    Public Function ObtenerMovimientosPorPeriodoFinanzas(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim listaEstado As New List(Of String)
        'Dim fechaPeriodo = General.GetPeriodoConvertirToDate(strPeriodo)
        Dim fechaPeriodo = CType("1/" & strPeriodo, Date)


        'listaEstado.Add("AC")
        'listaEstado.Add("DV")

        listaEstado.Add("1")
        listaEstado.Add("0")


        Dim Consulta = (From c In HeliosData.documentoCaja
                        Join e In HeliosData.estadosFinancieros On c.entidadFinanciera Equals e.idestado
                        Where
                            c.movimientoCaja = strMovimiento And
                            c.idEmpresa = strIdEmpresa And
                            CLng(c.idEstablecimiento) = intIdEstablecimiento And
                            c.fechaProceso.Value.Year = fechaPeriodo.Year And
                            c.fechaProceso.Value.Month = fechaPeriodo.Month And
                            listaEstado.Contains(c.estado)
                        Group New With {c, e} By
                            c.idDocumento,
                            c.tipoOperacion,
                            e.descripcion,
                            Column1 = e.descripcion,
                            c.moneda,
                            c.tipoCambio,
                            c.fechaCobro,
                            c.tipoMovimiento,
                            c.tipoDocPago,
                            c.numeroDoc,
                            c.numeroOperacion,
                            c.glosa,
                            c.montoSoles,
                            c.montoUsd,
                            c.tipoPersona,
                            c.idPersonal,
                            c.movimientoCaja,
                            c.fechaProceso,
                            c.estado,
                            c.usuarioModificacion
                            Into g = Group
                        Order By
                            fechaProceso
                        Select
                            idDocumento,
                            tipoOperacion,
                            cajaOrigen = descripcion,
                            cajaDestino = Column1,
                            moneda,
                            tipoCambio,
                            fechaCobro,
                            tipoMovimiento,
                            tipoDocPago,
                            numeroDoc,
                            numeroOperacion,
                            glosa,
                            montoSoles,
                            montoUsd,
                            tipoPersona,
                            idPersonal,
                            movimientoCaja,
                            fechaProceso,
                            estado,
                            usuarioModificacion,
                            montoMN = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCajaDetalle
                                                   Where
                                                       listaEstado.Contains(dc.documentoCaja.movimientoCaja) And
                                                       dc.idCajaPadre = idDocumento
                                                   Select New With {
                                                       dc.montoSoles
                                                       }) Into Sum(t1.montoSoles)), Decimal?)),
                            montoME = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCajaDetalle
                                                   Where
                                                      listaEstado.Contains(dc.documentoCaja.movimientoCaja) And
                                                       dc.idCajaPadre = idDocumento
                                                   Select New With {
                                                       dc.montoUsd
                                                       }) Into Sum(t1.montoUsd)), Decimal?))).ToList

        'Dim Consulta = (From c In HeliosData.documentoCaja
        '                Join e In HeliosData.estadosFinancieros On New With {.EntidadFinanciera = c.entidadFinanciera} Equals New With {.EntidadFinanciera = CStr(e.idestado)}
        '                Join e2 In HeliosData.estadosFinancieros On New With {.EntidadFinanciera = c.entidadFinanciera} Equals New With {.EntidadFinanciera = CStr(e2.idestado)}
        '                Where
        '                    c.movimientoCaja = strMovimiento And
        '                    c.idEmpresa = strIdEmpresa And
        '                    CLng(c.idEstablecimiento) = intIdEstablecimiento And
        '                    c.fechaProceso.Value.Year = fechaPeriodo.Year And
        '                    c.fechaProceso.Value.Month = fechaPeriodo.Month And
        '                    tipoEstado.Contains(c.estado)
        '                Group New With {c, e, e2} By
        '                    c.idDocumento,
        '                    c.tipoOperacion,
        '                    e.descripcion,
        '                    Column1 = e2.descripcion,
        '                    c.moneda,
        '                    c.tipoCambio,
        '                    c.fechaCobro,
        '                    c.tipoMovimiento,
        '                    c.tipoDocPago,
        '                    c.numeroDoc,
        '                    c.numeroOperacion,
        '                    c.glosa,
        '                    c.montoSoles,
        '                    c.montoUsd,
        '                    c.tipoPersona,
        '                    c.idPersonal,
        '                    c.movimientoCaja,
        '                    c.fechaProceso,
        '                    c.estado
        '                    Into g = Group
        '                Order By
        '                    fechaProceso
        '                Select
        '                    idDocumento,
        '                    tipoOperacion,
        '                    cajaOrigen = descripcion,
        '                    cajaDestino = Column1,
        '                    moneda,
        '                    tipoCambio,
        '                    fechaCobro,
        '                    tipoMovimiento,
        '                    tipoDocPago,
        '                    numeroDoc,
        '                    numeroOperacion,
        '                    glosa,
        '                    montoSoles,
        '                    montoUsd,
        '                    tipoPersona,
        '                    idPersonal,
        '                    movimientoCaja,
        '                    fechaProceso,
        '                    estado,
        '                    montoMN = (CType((Aggregate t1 In
        '                                          (From dc In HeliosData.documentoCajaDetalle
        '                                           Where
        '                                               listaEstado.Contains(dc.documentoCaja.movimientoCaja) And
        '                                               dc.idCajaPadre = idDocumento
        '                                           Select New With {
        '                                               dc.montoSoles
        '                                               }) Into Sum(t1.montoSoles)), Decimal?)),
        '                    montoME = (CType((Aggregate t1 In
        '                                          (From dc In HeliosData.documentoCajaDetalle
        '                                           Where
        '                                              listaEstado.Contains(dc.documentoCaja.movimientoCaja) And
        '                                               dc.idCajaPadre = idDocumento
        '                                           Select New With {
        '                                               dc.montoUsd
        '                                               }) Into Sum(t1.montoUsd)), Decimal?))).ToList


        For Each obj In Consulta
            objMostrarEncaja = New documentoCaja() With
                               {
                                .idDocumento = obj.idDocumento,
                                .tipoOperacion = obj.tipoOperacion,
                                .NomCajaOrigen = obj.cajaOrigen,
                                .NomCajaDestino = obj.cajaDestino,
                                .moneda = obj.moneda,
                                .tipoCambio = obj.tipoCambio,
                                .fechaCobro = obj.fechaCobro,
                                .fechaProceso = obj.fechaProceso,
                                .tipoMovimiento = obj.tipoMovimiento,
                                .tipoDocPago = obj.tipoDocPago,
                                .numeroDoc = obj.numeroDoc,
                                .numeroOperacion = obj.numeroOperacion,
                                .glosa = obj.glosa,
                                .montoSoles = obj.montoSoles.GetValueOrDefault,
                                .montoUsd = obj.montoUsd.GetValueOrDefault,
                                .tipoPersona = obj.tipoPersona,
                                .idPersonal = obj.idPersonal.GetValueOrDefault,
                                .usuarioModificacion = obj.usuarioModificacion,
                                .movimientoCaja = obj.movimientoCaja,
                                .MontoEgresosMN = obj.montoMN.GetValueOrDefault,
                                .MontoEgresosME = obj.montoME.GetValueOrDefault,
                                .estado = obj.estado}

            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function

    'Public Function ObtenerMovimientosPorPeriodoFinanzas(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String) As List(Of documentoCaja)
    '    Dim objMostrarEncaja As documentoCaja
    '    Dim ListaCaja As New List(Of documentoCaja)

    '    Dim consulta = From c In HeliosData.documentoCaja
    '                   Join d In HeliosData.documento
    '                   On c.idDocumento Equals d.idDocumento
    '                   Group Join ent1 In HeliosData.estadosFinancieros
    '                       On c.entidadFinanciera Equals ent1.idestado
    '                       Into ords1 = Group
    '                   From x In ords1.DefaultIfEmpty
    '                   Group Join ent2 In HeliosData.estadosFinancieros
    '                    On c.entidadFinancieraDestino Equals ent2.idestado
    '                    Into ords2 = Group
    '                   From x1 In ords2.DefaultIfEmpty
    '                   Where c.idEmpresa = strIdEmpresa _
    '                   And c.idEstablecimiento = intIdEstablecimiento _
    '                   And c.periodo = strPeriodo And c.movimientoCaja = strMovimiento
    '                   Order By c.fechaProceso
    '                   Select New With {
    '                       .idDocumento = c.idDocumento,
    '                       .movimiento = c.tipoOperacion,
    '                       .cajaOrigen = x.descripcion,
    '                       .cajaDestino = x1.descripcion,
    '                       .moneda = c.moneda,
    '                       .tipoCambio = c.tipoCambio,
    '                       .FechaCobro = c.fechaCobro,
    '                       .TipoMovimiento = c.tipoMovimiento,
    '                       .TipoDoc = c.tipoDocPago,
    '                       .NumDoc = d.nroDoc,
    '                       .numOperacion = c.numeroOperacion,
    '                       .Glosa = c.glosa,
    '                       .MontoSoles = c.montoSoles,
    '                       .MontoDolares = c.montoUsd,
    '                       .movimientoCaja = c.movimientoCaja}

    '    For Each obj In consulta
    '        objMostrarEncaja = New documentoCaja() With
    '                           {
    '                            .idDocumento = obj.idDocumento,
    '                        .tipoOperacion = obj.movimiento,
    '                        .NomCajaOrigen = obj.cajaOrigen,
    '                        .NomCajaDestino = obj.cajaDestino,
    '                        .moneda = obj.moneda,
    '                        .tipoCambio = obj.tipoCambio,
    '                        .fechaCobro = obj.FechaCobro,
    '                        .tipoMovimiento = obj.TipoMovimiento,
    '                        .tipoDocPago = obj.TipoDoc,
    '                        .numeroDoc = obj.NumDoc,
    '                        .numeroOperacion = obj.numOperacion,
    '                        .glosa = obj.Glosa,
    '                        .montoSoles = obj.MontoSoles,
    '                        .montoUsd = obj.MontoDolares,
    '                            .movimientoCaja = obj.movimientoCaja
    '                             }
    '        ListaCaja.Add(objMostrarEncaja)
    '    Next

    '    Return ListaCaja
    'End Function

    'Public Function ObtenerMovimientosPorPeriodoFinanzasXiDCaja(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, idCaja As Integer) As List(Of documentoCaja)
    '    Dim objMostrarEncaja As documentoCaja
    '    Dim ListaCaja As New List(Of documentoCaja)

    '    Dim consulta = From c In HeliosData.documentoCaja
    '                   Join d In HeliosData.documento
    '                    On c.idDocumento Equals d.idDocumento
    '                   Group Join ent1 In HeliosData.estadosFinancieros
    '                    On c.entidadFinanciera Equals ent1.idestado
    '                    Into ords1 = Group
    '                   From x In ords1.DefaultIfEmpty
    '                   Group Join ent2 In HeliosData.estadosFinancieros
    '                    On c.entidadFinancieraDestino Equals ent2.idestado
    '                    Into ords2 = Group
    '                   From x1 In ords2.DefaultIfEmpty
    '                   Where c.idEmpresa = strIdEmpresa _
    '                    And c.idEstablecimiento = intIdEstablecimiento _
    '                    And c.periodo = strPeriodo And c.movimientoCaja = strMovimiento _
    '                    And c.idCajaUsuario = idCaja
    '                   Order By c.fechaProceso
    '                   Select New With {
    '                        .idDocumento = c.idDocumento,
    '                        .movimiento = c.tipoOperacion,
    '                        .cajaOrigen = x.descripcion,
    '                        .cajaDestino = x1.descripcion,
    '                        .moneda = c.moneda,
    '                        .tipoCambio = c.tipoCambio,
    '                        .FechaCobro = c.fechaCobro,
    '                        .TipoMovimiento = c.tipoMovimiento,
    '                        .TipoDoc = c.tipoDocPago,
    '                        .NumDoc = d.nroDoc,
    '                        .numOperacion = c.numeroOperacion,
    '                        .Glosa = c.glosa,
    '                        .MontoSoles = c.montoSoles,
    '                        .MontoDolares = c.montoUsd,
    '                        .movimientoCaja = c.movimientoCaja}

    '    For Each obj In consulta
    '        objMostrarEncaja = New documentoCaja() With
    '                           {
    '                            .idDocumento = obj.idDocumento,
    '                        .tipoOperacion = obj.movimiento,
    '                        .NomCajaOrigen = obj.cajaOrigen,
    '                        .NomCajaDestino = obj.cajaDestino,
    '                        .moneda = obj.moneda,
    '                        .tipoCambio = obj.tipoCambio,
    '                        .fechaCobro = obj.FechaCobro,
    '                        .tipoMovimiento = obj.TipoMovimiento,
    '                        .tipoDocPago = obj.TipoDoc,
    '                        .numeroDoc = obj.NumDoc,
    '                        .numeroOperacion = obj.numOperacion,
    '                        .glosa = obj.Glosa,
    '                        .montoSoles = obj.MontoSoles,
    '                        .montoUsd = obj.MontoDolares,
    '                            .movimientoCaja = obj.movimientoCaja
    '                             }
    '        ListaCaja.Add(objMostrarEncaja)
    '    Next

    '    Return ListaCaja
    'End Function


    Public Function GetItemsNoAsignadosFinanzas(documentoCaja As documentoCaja) As List(Of documentoCaja)
        'Return HeliosData.documentoCaja.Where(Function(o) o.idEmpresa = documentoCaja.idEmpresa And
        '                                          o.idEstablecimiento = documentoCaja.idEstablecimiento And
        '                                          o.asientoCosto = documentoCaja.asientoCosto).ToList
        Dim lista As New List(Of documentoCaja)
        Dim objeto As New documentoCaja

        Dim consulta = (From c In HeliosData.documentoCaja
                        Join asi In HeliosData.asiento
                        On asi.idDocumento Equals c.idDocumento
                        Join mov In HeliosData.movimiento
                        On mov.idAsiento Equals asi.idAsiento
                        Join cost In HeliosData.recursoCosto
                                On cost.idCosto Equals mov.idCosto
                        Where c.idEmpresa = documentoCaja.idEmpresa _
              And c.idEstablecimiento = documentoCaja.idEstablecimiento _
              And mov.idCosto = documentoCaja.idcosto And mov.tipoCosto = "PC"
                        Order By c.fechaProceso).ToList

        For Each i In consulta
            objeto = New documentoCaja

            objeto.idDocumento = i.c.idDocumento
            objeto.movimientoCaja = i.c.movimientoCaja
            objeto.fechaCobro = i.c.fechaCobro
            objeto.entidadFinanciera = i.c.entidadFinanciera
            objeto.tipoDocPago = i.c.tipoDocPago
            objeto.numeroDoc = i.c.numeroDoc
            objeto.moneda = i.c.moneda
            objeto.montoSoles = i.mov.monto
            objeto.montoUsd = i.mov.montoUSD
            objeto.glosa = i.c.glosa
            objeto.idcosto = i.mov.idCosto
            objeto.tipoCosto = "HC"
            objeto.nombreCosto = i.cost.nombreCosto
            objeto.idEstado = i.mov.idmovimiento

            lista.Add(objeto)

        Next
        Return lista
    End Function


    'Function ListaTotalXCaja(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer) As documentoCaja
    '    Dim lista As New List(Of documentoCaja)
    '    Dim nDocumentoCaja As New documentoCaja
    '    Dim listaDocCaja As New List(Of documentoCaja)

    '    Using ts As New TransactionScope
    '        Select Case tipo
    '            Case "XTodo"
    '                Dim consulta = (From d In HeliosData.documentoCaja
    '                                Where
    '                                                d.idEmpresa = strEmpresa And
    '                                            d.idEstablecimiento = idEstablec And
    '                                            d.fechaProceso.Value.Year = intAnio
    '                                Group d By d.idEmpresa Into g = Group
    '                                Select
    '                                    Aporte = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "AP" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    Otorgados = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "AO" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    Recibidos = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "AR" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    OtrasEntradas = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "OEC" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    OtrasSalidas = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "OSC" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    PreVenta = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "IPV" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    Compra = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "CCR" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    VentaPost = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "VPOS" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    ventaContado = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "VTAG" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault


    '                If (Not IsNothing(consulta)) Then
    '                    nDocumentoCaja = New documentoCaja
    '                    With nDocumentoCaja
    '                        .Aporte = consulta.Aporte.GetValueOrDefault
    '                        .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
    '                        .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
    '                        .anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
    '                        .anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
    '                        .ticket = consulta.PreVenta.GetValueOrDefault
    '                        .cuentasXPagar = consulta.Compra.GetValueOrDefault
    '                        .ventaPost = consulta.VentaPost.GetValueOrDefault
    '                        .ventaContado = consulta.ventaContado.GetValueOrDefault
    '                    End With
    '                End If
    '            Case "XPeriodo"
    '                Dim consulta = (From d In HeliosData.documentoCaja
    '                                Where
    '                                          d.fechaProceso.Value.Year = intAnio And
    '                                          d.fechaProceso.Value.Month = intMes And
    '                                           d.idEmpresa = strEmpresa And
    '                                            d.idEstablecimiento = idEstablec
    '                                Group d By d.idEmpresa Into g = Group
    '                                Select
    '                                    Aporte = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "AP" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    Otorgados = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "AO" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    Recibidos = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "AR" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    OtrasEntradas = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "OEC" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    OtrasSalidas = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "OSC" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    PreVenta = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "IPV" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    Compra = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "CCR" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    VentaPost = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "VPOS" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    ventaContado = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "VTAG" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault

    '                If (Not IsNothing(consulta)) Then
    '                    nDocumentoCaja = New documentoCaja
    '                    With nDocumentoCaja
    '                        .Aporte = consulta.Aporte.GetValueOrDefault
    '                        .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
    '                        .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
    '                        .anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
    '                        .anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
    '                        .ticket = consulta.PreVenta.GetValueOrDefault
    '                        .cuentasXPagar = consulta.Compra.GetValueOrDefault
    '                        .ventaPost = consulta.VentaPost.GetValueOrDefault
    '                        .ventaContado = consulta.ventaContado.GetValueOrDefault
    '                    End With
    '                End If

    '            Case "XDia"
    '                Dim consulta = (From d In HeliosData.documentoCaja
    '                                Where
    '                                                        (d.fechaProceso) >= fechaInicio And
    '                                            (d.fechaProceso) <= fechaFin And
    '                                            d.idEmpresa = strEmpresa And
    '                                            d.idEstablecimiento = idEstablec
    '                                Group d By d.idEmpresa Into g = Group
    '                                Select
    '                                    Aporte = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "AP" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    Otorgados = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "AO" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    Recibidos = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "AR" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    OtrasEntradas = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "OEC" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    OtrasSalidas = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "OSC" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    PreVenta = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "IPV" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    Compra = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "CCR" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    VentaPost = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "VPOS" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?)),
    '                                    ventaContado = (CType((Aggregate t1 In
    '                                (From a In HeliosData.documentoCaja
    '                                 Where
    '                                    a.movimientoCaja = "VTAG" And
    '                                     listaidPersona.Contains(a.usuarioModificacion)
    '                                 Select New With {
    '                                    a.montoSoles
    '                                }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault

    '                If (Not IsNothing(consulta)) Then
    '                    nDocumentoCaja = New documentoCaja
    '                    With nDocumentoCaja
    '                        .Aporte = consulta.Aporte.GetValueOrDefault
    '                        .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
    '                        .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
    '                        .anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
    '                        .anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
    '                        .ticket = consulta.PreVenta.GetValueOrDefault
    '                        .cuentasXPagar = consulta.Compra.GetValueOrDefault
    '                        .ventaPost = consulta.VentaPost.GetValueOrDefault
    '                        .ventaContado = consulta.ventaContado.GetValueOrDefault
    '                    End With
    '                End If

    '        End Select

    '        Return nDocumentoCaja

    '    End Using
    'End Function

    Function ListaTotalXCaja(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer, intDia As Integer) As documentoCaja
        Dim lista As New List(Of documentoCaja)
        Dim nDocumentoCaja As New documentoCaja
        Dim listaDocCaja As New List(Of documentoCaja)

        Using ts As New TransactionScope
            Select Case tipo
                Case "XTodo"
                    Dim consulta = (From d In HeliosData.documentoCaja
                                    Where
                                                    d.idEmpresa = strEmpresa And
                                                d.idEstablecimiento = idEstablec And
                                                d.fechaProceso.Value.Year = intAnio
                                    Group d By d.idEmpresa Into g = Group
                                    Select
                                        Aporte = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AP" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Otorgados = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AO" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Recibidos = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AR" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasEntradas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OEC" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasSalidas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OSC" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        PreVenta = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "IPV" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Compra = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "CCR" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        VentaPost = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VPOS" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        ventaContado = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VTAG" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault


                    If (Not IsNothing(consulta)) Then
                        nDocumentoCaja = New documentoCaja
                        With nDocumentoCaja
                            .Aporte = consulta.Aporte.GetValueOrDefault
                            .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
                            .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
                            .anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
                            .anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
                            .ticket = consulta.PreVenta.GetValueOrDefault
                            .cuentasXPagar = consulta.Compra.GetValueOrDefault
                            .ventaPost = consulta.VentaPost.GetValueOrDefault
                            .ventaContado = consulta.ventaContado.GetValueOrDefault
                        End With
                    End If
                Case "XPeriodo"
                    Dim consulta = (From d In HeliosData.documentoCaja
                                    Where
                                              d.fechaProceso.Value.Year = intAnio And
                                              d.fechaProceso.Value.Month = intMes And
                                               d.idEmpresa = strEmpresa And
                                                d.idEstablecimiento = idEstablec
                                    Group d By d.idEmpresa Into g = Group
                                    Select
                                        Aporte = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AP" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Otorgados = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AO" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Recibidos = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AR" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasEntradas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OEC" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasSalidas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OSC" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        PreVenta = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "IPV" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Compra = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "CCR" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        VentaPost = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VPOS" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        ventaContado = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VTAG" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault

                    If (Not IsNothing(consulta)) Then
                        nDocumentoCaja = New documentoCaja
                        With nDocumentoCaja
                            .Aporte = consulta.Aporte.GetValueOrDefault
                            .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
                            .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
                            .anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
                            .anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
                            .ticket = consulta.PreVenta.GetValueOrDefault
                            .cuentasXPagar = consulta.Compra.GetValueOrDefault
                            .ventaPost = consulta.VentaPost.GetValueOrDefault
                            .ventaContado = consulta.ventaContado.GetValueOrDefault
                        End With
                    End If

                Case "XDia"
                    Dim consulta = (From d In HeliosData.documentoCaja
                                    Where
                                                            (d.fechaProceso) >= fechaInicio And
                                                (d.fechaProceso) <= fechaFin And
                                                d.idEmpresa = strEmpresa And
                                                d.idEstablecimiento = idEstablec
                                    Group d By d.idEmpresa Into g = Group
                                    Select
                                        Aporte = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AP" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Otorgados = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AO" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Recibidos = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AR" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasEntradas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OEC" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasSalidas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OSC" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        PreVenta = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "IPV" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Compra = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "CCR" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        VentaPost = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VPOS" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        ventaContado = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VTAG" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault

                    If (Not IsNothing(consulta)) Then
                        nDocumentoCaja = New documentoCaja
                        With nDocumentoCaja
                            .Aporte = consulta.Aporte.GetValueOrDefault
                            .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
                            .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
                            .anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
                            .anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
                            .ticket = consulta.PreVenta.GetValueOrDefault
                            .cuentasXPagar = consulta.Compra.GetValueOrDefault
                            .ventaPost = consulta.VentaPost.GetValueOrDefault
                            .ventaContado = consulta.ventaContado.GetValueOrDefault
                        End With
                    End If

                Case "XHora"
                    Dim consulta = (From d In HeliosData.documentoCaja
                                    Where
                                              d.fechaProceso.Value.Year = intAnio And
                                             d.fechaProceso.Value.Month = intMes And
                                             d.fechaProceso.Value.Day = intDia And
                                        d.fechaProceso.Value.Hour >= fechaInicio.Hour And
                                        d.fechaProceso.Value.Hour <= fechaFin.Hour And
                                               d.idEmpresa = strEmpresa And
                                                d.idEstablecimiento = idEstablec
                                    Group d By d.idEmpresa Into g = Group
                                    Select
                                        Aporte = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AP" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Otorgados = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AO" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Recibidos = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AR" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasEntradas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OEC" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasSalidas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OSC" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        PreVenta = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "IPV" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Compra = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "CCR" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        VentaPost = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VPOS" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        ventaContado = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VTAG" And
                                         listaidPersona.Contains(a.usuarioModificacion)
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault

                    If (Not IsNothing(consulta)) Then
                        nDocumentoCaja = New documentoCaja
                        With nDocumentoCaja
                            .Aporte = consulta.Aporte.GetValueOrDefault
                            .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
                            .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
                            .anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
                            .anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
                            .ticket = consulta.PreVenta.GetValueOrDefault
                            .cuentasXPagar = consulta.Compra.GetValueOrDefault
                            .ventaPost = consulta.VentaPost.GetValueOrDefault
                            .ventaContado = consulta.ventaContado.GetValueOrDefault
                        End With
                    End If

            End Select

            Return nDocumentoCaja

        End Using
    End Function
    Public Function ObtenerCajaOnlineXUsuario(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strperiodo As String, ByVal strEntidadFinanciera As String, listasuarios As List(Of String), tipo As String, fechainicio As DateTime, fechaFin As DateTime, intAnio As Integer) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim DocumentoCompraBL As New documentocompraBL
        Dim DocumentoCompra As New documentocompra
        Dim DocumentoVenta As New documentoventaAbarrotes
        Dim DocumentoVentaBL As New documentoventaAbarrotesBL
        Dim entidadBL As New entidadBL
        Dim tablaDetalleBL As New tabladetalleBL
        Dim persona As New Persona
        Dim personaBL As New PersonaBL

        Select Case tipo
            Case "XPeriodo"
                Dim consulta = (From c In HeliosData.documentoCaja
                                Join cajadetalle In HeliosData.documentoCajaDetalle
                      On cajadetalle.idDocumento Equals c.idDocumento
                                Join tip In HeliosData.estadosFinancieros
                      On tip.idestado Equals c.entidadFinanciera
                                Where c.idEmpresa = strIdEmpresa _
                      And c.periodo = strperiodo _
                      And c.entidadFinanciera = strEntidadFinanciera _
                      And listasuarios.Contains(c.usuarioModificacion)
                                Order By cajadetalle.fecha).ToList

                For Each obj In consulta
                    objMostrarEncaja = New documentoCaja
                    objMostrarEncaja.idDocumento = obj.c.idDocumento
                    objMostrarEncaja.IdEntidadFinanciera = obj.tip.idestado
                    objMostrarEncaja.fechaCobro = obj.cajadetalle.fecha
                    objMostrarEncaja.tipoMovimiento = obj.c.tipoMovimiento
                    objMostrarEncaja.saldoMN = obj.c.montoSoles
                    objMostrarEncaja.fechaProceso = obj.c.fechaCobro
                    Select Case obj.c.tipoMovimiento
                        Case "DC"
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                            Select Case obj.c.movimientoCaja
                                Case "TEC"
                                    objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.TRANSFERENCIA_CAJA
                                Case "OEC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ENTRADAS_CAJA
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "OSC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.SALIDA_CAJA
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "VTAG"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_GENERAL
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "VPOS"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_POS
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "IPV"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_TICKET
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "AR"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ANTICPO_RECIBIDO
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case Else
                                    objMostrarEncaja.NomCajaDestino = "OTROS"
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                            End Select
                        Case "PG"
                            Select Case obj.c.movimientoCaja
                                Case "TEC"
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.TRANSFERENCIA_CAJA
                                Case "OEC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ENTRADAS_CAJA
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "OSC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.SALIDA_CAJA
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "VTAG"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_GENERAL
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "VPOS"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_POS
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "IPV"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_TICKET
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "AR"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ANTICPO_RECIBIDO
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case Else
                                    objMostrarEncaja.NomCajaDestino = "OTROS"
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio

                            End Select
                        Case "ANT-C"
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio

                    End Select
                    objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.c.TipoDocumentoPago, ":", obj.cajadetalle.DetalleItem)
                    objMostrarEncaja.tipoDocPago = obj.c.tipoDocPago
                    objMostrarEncaja.NumeroDocumento = obj.c.numeroDoc
                    objMostrarEncaja.glosa = obj.c.glosa
                    objMostrarEncaja.montoSoles = obj.cajadetalle.montoSoles
                    objMostrarEncaja.montoSolesTransacc = obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
                    objMostrarEncaja.montoUsdTransacc = obj.cajadetalle.montoUsdTransacc.GetValueOrDefault
                    objMostrarEncaja.montoUsd = obj.cajadetalle.montoUsd
                    objMostrarEncaja.NombreCaja = obj.tip.descripcion
                    objMostrarEncaja.entidadFinanciera = obj.tip.tipo
                    objMostrarEncaja.dni = String.Empty
                    objMostrarEncaja.DetalleItem = obj.cajadetalle.DetalleItem
                    objMostrarEncaja.tipousuario = "Responsable"
                    objMostrarEncaja.usuarioModificacion = obj.c.usuarioModificacion
                    objMostrarEncaja.tipoOperacion = obj.c.tipoOperacion
                    Select Case obj.c.tipoOperacion
                        Case "9912"
                            objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                        Case "9909"
                            objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                        Case "9910"
                            objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                        Case "9911"
                            objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                        Case "9907"
                            objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                        Case "9908"
                            objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                        Case "02" ' COMPRAS
                            objMostrarEncaja.NombreOperacion = "COMPRA"
                        Case "105" 'APERTURA DE CAJAS
                            objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                            '   End If
                        Case "01" 'VENTAS
                            objMostrarEncaja.NombreOperacion = "VENTA"
                        Case "12.1"
                            objMostrarEncaja.NombreOperacion = "TICKET BOLETA"
                        Case "12.2"
                            objMostrarEncaja.NombreOperacion = "TICKET FACTURA"
                        Case "17"
                            objMostrarEncaja.NombreOperacion = "APORTES"
                        Case "9908"
                            objMostrarEncaja.NombreOperacion = "INGRESO POR ANTICIPOS"
                    End Select

                    ListaCaja.Add(objMostrarEncaja)
                Next
            Case "XTodo"
                Dim consulta = (From c In HeliosData.documentoCaja
                                Join cajadetalle In HeliosData.documentoCajaDetalle
                     On cajadetalle.idDocumento Equals c.idDocumento
                                Join tip In HeliosData.estadosFinancieros
                     On tip.idestado Equals c.entidadFinanciera
                                Where c.idEmpresa = strIdEmpresa _
                     And c.fechaProceso.Value.Year = intAnio _
                     And c.entidadFinanciera = strEntidadFinanciera _
                      And listasuarios.Contains(c.usuarioModificacion)
                                Order By cajadetalle.fecha).ToList

                For Each obj In consulta
                    objMostrarEncaja = New documentoCaja
                    objMostrarEncaja.idDocumento = obj.c.idDocumento
                    objMostrarEncaja.IdEntidadFinanciera = obj.tip.idestado
                    objMostrarEncaja.fechaCobro = obj.cajadetalle.fecha
                    objMostrarEncaja.tipoMovimiento = obj.c.tipoMovimiento
                    objMostrarEncaja.saldoMN = obj.c.montoSoles
                    objMostrarEncaja.fechaProceso = obj.c.fechaCobro
                    Select Case obj.c.tipoMovimiento
                        Case "DC"
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                            Select Case obj.c.movimientoCaja
                                Case "TEC"
                                    objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.TRANSFERENCIA_CAJA
                                Case "OEC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ENTRADAS_CAJA
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "OSC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.SALIDA_CAJA
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "VTAG"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_GENERAL
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "VPOS"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_POS
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "IPV"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_TICKET
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "AR"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ANTICPO_RECIBIDO
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case Else
                                    objMostrarEncaja.NomCajaDestino = "OTROS"
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                            End Select
                        Case "PG"
                            Select Case obj.c.movimientoCaja
                                Case "TEC"
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.TRANSFERENCIA_CAJA
                                Case "OEC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ENTRADAS_CAJA
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "OSC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.SALIDA_CAJA
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "VTAG"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_GENERAL
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "VPOS"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_POS
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "IPV"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_TICKET
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "AR"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ANTICPO_RECIBIDO
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case Else
                                    objMostrarEncaja.NomCajaDestino = "OTROS"
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio

                            End Select
                        Case "ANT-C"
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio

                    End Select
                    objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.c.TipoDocumentoPago, ":", obj.cajadetalle.DetalleItem)
                    objMostrarEncaja.tipoDocPago = obj.c.tipoDocPago
                    objMostrarEncaja.NumeroDocumento = obj.c.numeroDoc
                    objMostrarEncaja.glosa = obj.c.glosa
                    objMostrarEncaja.montoSoles = obj.cajadetalle.montoSoles
                    objMostrarEncaja.montoSolesTransacc = obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
                    objMostrarEncaja.montoUsdTransacc = obj.cajadetalle.montoUsdTransacc.GetValueOrDefault
                    objMostrarEncaja.montoUsd = obj.cajadetalle.montoUsd
                    objMostrarEncaja.NombreCaja = obj.tip.descripcion
                    objMostrarEncaja.entidadFinanciera = obj.tip.tipo
                    objMostrarEncaja.dni = String.Empty
                    objMostrarEncaja.DetalleItem = obj.cajadetalle.DetalleItem
                    objMostrarEncaja.tipousuario = "Responsable"
                    objMostrarEncaja.usuarioModificacion = obj.c.usuarioModificacion
                    objMostrarEncaja.tipoOperacion = obj.c.tipoOperacion
                    Select Case obj.c.tipoOperacion
                        Case "9912"
                            objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                        Case "9909"
                            objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                        Case "9910"
                            objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                        Case "9911"
                            objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                        Case "9907"
                            objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                        Case "9908"
                            objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                        Case "02" ' COMPRAS
                            objMostrarEncaja.NombreOperacion = "COMPRA"
                        Case "105" 'APERTURA DE CAJAS
                            objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                            '   End If
                        Case "01" 'VENTAS
                            objMostrarEncaja.NombreOperacion = "VENTA"
                        Case "12.1"
                            objMostrarEncaja.NombreOperacion = "TICKET BOLETA"
                        Case "12.2"
                            objMostrarEncaja.NombreOperacion = "TICKET FACTURA"
                        Case "17"
                            objMostrarEncaja.NombreOperacion = "APORTES"
                        Case "9908"
                            objMostrarEncaja.NombreOperacion = "INGRESO POR ANTICIPOS"
                    End Select

                    ListaCaja.Add(objMostrarEncaja)
                Next
            Case "XDia"
                Dim consulta = (From c In HeliosData.documentoCaja
                                Join cajadetalle In HeliosData.documentoCajaDetalle
                     On cajadetalle.idDocumento Equals c.idDocumento
                                Join tip In HeliosData.estadosFinancieros
                     On tip.idestado Equals c.entidadFinanciera
                                Where c.idEmpresa = strIdEmpresa _
                     And c.fechaProceso >= fechainicio _
                     And c.fechaProceso <= fechainicio _
                     And c.entidadFinanciera = strEntidadFinanciera _
                      And listasuarios.Contains(c.usuarioModificacion)
                                Order By cajadetalle.fecha).ToList

                For Each obj In consulta
                    objMostrarEncaja = New documentoCaja
                    objMostrarEncaja.idDocumento = obj.c.idDocumento
                    objMostrarEncaja.IdEntidadFinanciera = obj.tip.idestado
                    objMostrarEncaja.fechaCobro = obj.cajadetalle.fecha
                    objMostrarEncaja.tipoMovimiento = obj.c.tipoMovimiento
                    objMostrarEncaja.saldoMN = obj.c.montoSoles
                    objMostrarEncaja.fechaProceso = obj.c.fechaCobro
                    Select Case obj.c.tipoMovimiento
                        Case "DC"
                            objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                            Select Case obj.c.movimientoCaja
                                Case "TEC"
                                    objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.TRANSFERENCIA_CAJA
                                Case "OEC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ENTRADAS_CAJA
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "OSC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.SALIDA_CAJA
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "VTAG"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_GENERAL
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "VPOS"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_POS
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "IPV"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_TICKET
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "AR"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ANTICPO_RECIBIDO
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case Else
                                    objMostrarEncaja.NomCajaDestino = "OTROS"
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                            End Select
                        Case "PG"
                            Select Case obj.c.movimientoCaja
                                Case "TEC"
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.TRANSFERENCIA_CAJA
                                Case "OEC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ENTRADAS_CAJA
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                    objMostrarEncaja.tipoCambio = obj.c.tipoCambio
                                Case "OSC"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.SALIDA_CAJA
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "VTAG"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_GENERAL
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "VPOS"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_POS
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "IPV"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.INGRESO_VENTA_TICKET
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case "AR"
                                    objMostrarEncaja.NomCajaDestino = TIPO_MOVIMIENTO.ANTICPO_RECIBIDO
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio
                                Case Else
                                    objMostrarEncaja.NomCajaDestino = "OTROS"
                                    objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                                    objMostrarEncaja.difTipoCambio = obj.c.tipoCambio

                            End Select
                        Case "ANT-C"
                            objMostrarEncaja.tipoCambio = obj.cajadetalle.diferTipoCambio
                            objMostrarEncaja.difTipoCambio = obj.c.tipoCambio

                    End Select
                    objMostrarEncaja.TipoDocumentoPago = String.Concat(obj.c.TipoDocumentoPago, ":", obj.cajadetalle.DetalleItem)
                    objMostrarEncaja.tipoDocPago = obj.c.tipoDocPago
                    objMostrarEncaja.NumeroDocumento = obj.c.numeroDoc
                    objMostrarEncaja.glosa = obj.c.glosa
                    objMostrarEncaja.montoSoles = obj.cajadetalle.montoSoles
                    objMostrarEncaja.montoSolesTransacc = obj.cajadetalle.montoSolesTransacc.GetValueOrDefault
                    objMostrarEncaja.montoUsdTransacc = obj.cajadetalle.montoUsdTransacc.GetValueOrDefault
                    objMostrarEncaja.montoUsd = obj.cajadetalle.montoUsd
                    objMostrarEncaja.NombreCaja = obj.tip.descripcion
                    objMostrarEncaja.entidadFinanciera = obj.tip.tipo
                    objMostrarEncaja.dni = String.Empty
                    objMostrarEncaja.DetalleItem = obj.cajadetalle.DetalleItem
                    objMostrarEncaja.tipousuario = "Responsable"
                    objMostrarEncaja.usuarioModificacion = obj.c.usuarioModificacion
                    objMostrarEncaja.tipoOperacion = obj.c.tipoOperacion
                    Select Case obj.c.tipoOperacion
                        Case "9912"
                            objMostrarEncaja.NombreOperacion = "INGRESO DINERO POR NOTA CREDITO"
                        Case "9909"
                            objMostrarEncaja.NombreOperacion = "OTRAS ENTRADAS DE DINERO"
                        Case "9910"
                            objMostrarEncaja.NombreOperacion = "OTRAS SALIDAS DE DINERO"
                        Case "9911"
                            objMostrarEncaja.NombreOperacion = "TRANFERENCIA ENTRE CAJAS"
                        Case "9907"
                            objMostrarEncaja.NombreOperacion = "PAGO A PROVEEDOR"
                        Case "9908"
                            objMostrarEncaja.NombreOperacion = "COBRO A CLIENTES"
                        Case "02" ' COMPRAS
                            objMostrarEncaja.NombreOperacion = "COMPRA"
                        Case "105" 'APERTURA DE CAJAS
                            objMostrarEncaja.NombreOperacion = "APERTURA DE CAJA"
                            '   End If
                        Case "01" 'VENTAS
                            objMostrarEncaja.NombreOperacion = "VENTA"
                        Case "12.1"
                            objMostrarEncaja.NombreOperacion = "TICKET BOLETA"
                        Case "12.2"
                            objMostrarEncaja.NombreOperacion = "TICKET FACTURA"
                        Case "17"
                            objMostrarEncaja.NombreOperacion = "APORTES"
                        Case "9908"
                            objMostrarEncaja.NombreOperacion = "INGRESO POR ANTICIPOS"
                    End Select

                    ListaCaja.Add(objMostrarEncaja)
                Next
        End Select

        Return ListaCaja
    End Function

    Public Function ResumenCiereCaja(strEmpresa As String, intIdEstablecimiento As Integer, intIdCaja As Integer, estado As String) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja

        Dim consulta = (From e In HeliosData.estadosFinancieros
                        Join c In HeliosData.cajaUsuariodetalle On New With {.Idestado = e.idestado} Equals New With {.Idestado = CInt(c.idEntidad)}
                        Where
                                CLng(c.idcajaUsuario) = intIdCaja And
                                c.cajaUsuario.estadoCaja = "A" And
                                c.cajaUsuario.idEmpresa = strEmpresa And
                                CLng(c.cajaUsuario.idEstablecimiento) = intIdEstablecimiento
                        Group New With {e, c} By
                                e.tipo,
                                e.descripcion,
                                c.importeMN,
                                c.idcajaUsuario,
                                e.idestado,
                                e.codigo
                        Into g = Group
                        Select
                                tipo,
                                descripcion,
                                Idestado = CType(idestado, Int32?),
                                importeMN,
                                idcajaUsuario,
                                codigo,
                                ingresosMN = (CType((Aggregate t1 In
                                                         (From dc In HeliosData.documentoCaja
                                                          Where
                                                              dc.estado = "1" And
                                                              dc.idCajaUsuario = idcajaUsuario And
                                                              dc.entidadFinanciera = CStr(idestado) And
                                                              dc.tipoMovimiento = "DC"
                                                          Select New With {
                                                              dc.montoSoles
                                                              }) Into Sum(t1.montoSoles)), Decimal?)),
                            egresoMN = (CType((Aggregate t1 In
                                                   (From dc In HeliosData.documentoCaja
                                                    Where
                                                        dc.estado = "1" And
                                                        dc.idCajaUsuario = idcajaUsuario And
                                                        dc.entidadFinanciera = CStr(idestado) And
                                                        dc.tipoMovimiento = "PG"
                                                    Select New With {
                                                        dc.montoSoles
                                                        }) Into Sum(t1.montoSoles)), Decimal?))).ToList

        For Each item In consulta
            docCuenta = New documentoCaja

            docCuenta.idCajaUsuario = item.idcajaUsuario
            docCuenta.idEstado = item.Idestado
            docCuenta.codigo = item.codigo
            docCuenta.tipo = item.tipo
            docCuenta.DetalleItem = item.descripcion
            docCuenta.montoSoles = item.importeMN.GetValueOrDefault
            docCuenta.MontoIngresosMN = item.ingresosMN.GetValueOrDefault
            docCuenta.MontoEgresosMN = item.egresoMN.GetValueOrDefault

            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function

    Public Function ListaReversionXDoc(strEmpresa As String, intIdEstablecimiento As Integer, idDocumento As Integer) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja

        Dim consulta = (From dc In HeliosData.documentoCajaDetalle
                        Where
                            CLng(dc.idCajaPadre) = idDocumento And
                            dc.documentoCaja.idEmpresa = strEmpresa And
                            dc.documentoCaja.idEstablecimiento = intIdEstablecimiento
                        Select
                                dc.DetalleItem,
                                FechaProceso = CType(dc.documentoCaja.fechaProceso, DateTime?),
                                MontoSoles = CType(dc.documentoCaja.montoSoles, Decimal?),
                                MontoUsd = CType(dc.documentoCaja.montoUsd, Decimal?)).ToList

        For Each item In consulta
            docCuenta = New documentoCaja

            docCuenta.DetalleItem = item.DetalleItem
            docCuenta.fechaProceso = item.FechaProceso
            docCuenta.montoSoles = item.MontoSoles
            docCuenta.montoUsd = item.MontoUsd
            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function

    Public Function ObtenerMovimientosPorPeriodoFinanzasInforGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, intAnio As Integer, intMes As Integer, strMovimiento As String, tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)

        Select Case tipo
            Case "XTodo"
                Dim consulta = From c In HeliosData.documentoCaja
                               Join d In HeliosData.documento
                               On c.idDocumento Equals d.idDocumento
                               Group Join ent1 In HeliosData.estadosFinancieros
                                   On c.entidadFinanciera Equals ent1.idestado
                                   Into ords1 = Group
                               From x In ords1.DefaultIfEmpty
                               Group Join ent2 In HeliosData.estadosFinancieros
                                On c.entidadFinancieraDestino Equals ent2.idestado
                                Into ords2 = Group
                               From x1 In ords2.DefaultIfEmpty
                               Where c.idEmpresa = strIdEmpresa _
                               And c.idEstablecimiento = intIdEstablecimiento _
                               And c.fechaProceso.Value.Year = intAnio And
                               c.movimientoCaja = strMovimiento And
                               listaUsuario.Contains(c.usuarioModificacion)
                               Order By c.fechaProceso
                               Select New With {
                                   .idDocumento = c.idDocumento,
                                   .movimiento = c.tipoOperacion,
                                   .cajaOrigen = x.descripcion,
                                   .cajaDestino = x1.descripcion,
                                   .moneda = c.moneda,
                                   .tipoCambio = c.tipoCambio,
                                   .FechaCobro = c.fechaCobro,
                                   .TipoMovimiento = c.tipoMovimiento,
                                   .TipoDoc = c.tipoDocPago,
                                   .NumDoc = d.nroDoc,
                                   .numOperacion = c.numeroOperacion,
                                   .Glosa = c.glosa,
                                   .MontoSoles = c.montoSoles,
                                   .MontoDolares = c.montoUsd,
                                   .movimientoCaja = c.movimientoCaja,
                                   .usuarioModificacion = c.usuarioModificacion}

                For Each obj In consulta
                    objMostrarEncaja = New documentoCaja() With
                                       {
                                        .idDocumento = obj.idDocumento,
                                    .tipoOperacion = obj.movimiento,
                                    .NomCajaOrigen = obj.cajaOrigen,
                                    .NomCajaDestino = obj.cajaDestino,
                                    .moneda = obj.moneda,
                                    .tipoCambio = obj.tipoCambio,
                                    .fechaCobro = obj.FechaCobro,
                                    .tipoMovimiento = obj.TipoMovimiento,
                                    .tipoDocPago = obj.TipoDoc,
                                    .numeroDoc = obj.NumDoc,
                                    .numeroOperacion = obj.numOperacion,
                                    .glosa = obj.Glosa,
                                    .montoSoles = obj.MontoSoles,
                                    .montoUsd = obj.MontoDolares,
                                        .movimientoCaja = obj.movimientoCaja,
                                        .usuarioModificacion = obj.usuarioModificacion
                                         }
                    ListaCaja.Add(objMostrarEncaja)
                Next
            Case "XDia"
                Dim consulta = From c In HeliosData.documentoCaja
                               Join d In HeliosData.documento
                               On c.idDocumento Equals d.idDocumento
                               Group Join ent1 In HeliosData.estadosFinancieros
                                   On c.entidadFinanciera Equals ent1.idestado
                                   Into ords1 = Group
                               From x In ords1.DefaultIfEmpty
                               Group Join ent2 In HeliosData.estadosFinancieros
                                On c.entidadFinancieraDestino Equals ent2.idestado
                                Into ords2 = Group
                               From x1 In ords2.DefaultIfEmpty
                               Where c.idEmpresa = strIdEmpresa _
                               And c.idEstablecimiento = intIdEstablecimiento _
                               And c.fechaProceso >= fechainicio And
                               c.fechaProceso <= fechaFin And
                               c.movimientoCaja = strMovimiento And
                               listaUsuario.Contains(c.usuarioModificacion)
                               Order By c.fechaProceso
                               Select New With {
                                   .idDocumento = c.idDocumento,
                                   .movimiento = c.tipoOperacion,
                                   .cajaOrigen = x.descripcion,
                                   .cajaDestino = x1.descripcion,
                                   .moneda = c.moneda,
                                   .tipoCambio = c.tipoCambio,
                                   .FechaCobro = c.fechaCobro,
                                   .TipoMovimiento = c.tipoMovimiento,
                                   .TipoDoc = c.tipoDocPago,
                                   .NumDoc = d.nroDoc,
                                   .numOperacion = c.numeroOperacion,
                                   .Glosa = c.glosa,
                                   .MontoSoles = c.montoSoles,
                                   .MontoDolares = c.montoUsd,
                                     .movimientoCaja = c.movimientoCaja,
                                  .usuarioModificacion = c.usuarioModificacion}

                For Each obj In consulta
                    objMostrarEncaja = New documentoCaja() With
                                       {
                                        .idDocumento = obj.idDocumento,
                                    .tipoOperacion = obj.movimiento,
                                    .NomCajaOrigen = obj.cajaOrigen,
                                    .NomCajaDestino = obj.cajaDestino,
                                    .moneda = obj.moneda,
                                    .tipoCambio = obj.tipoCambio,
                                    .fechaCobro = obj.FechaCobro,
                                    .tipoMovimiento = obj.TipoMovimiento,
                                    .tipoDocPago = obj.TipoDoc,
                                    .numeroDoc = obj.NumDoc,
                                    .numeroOperacion = obj.numOperacion,
                                    .glosa = obj.Glosa,
                                    .montoSoles = obj.MontoSoles,
                                    .montoUsd = obj.MontoDolares,
                                        .movimientoCaja = obj.movimientoCaja,
                                        .usuarioModificacion = obj.usuarioModificacion
                                         }
                    ListaCaja.Add(objMostrarEncaja)
                Next
            Case "XPeriodo"
                Dim consulta = From c In HeliosData.documentoCaja
                               Join d In HeliosData.documento
                               On c.idDocumento Equals d.idDocumento
                               Group Join ent1 In HeliosData.estadosFinancieros
                                   On c.entidadFinanciera Equals ent1.idestado
                                   Into ords1 = Group
                               From x In ords1.DefaultIfEmpty
                               Group Join ent2 In HeliosData.estadosFinancieros
                                On c.entidadFinancieraDestino Equals ent2.idestado
                                Into ords2 = Group
                               From x1 In ords2.DefaultIfEmpty
                               Where c.idEmpresa = strIdEmpresa _
                               And c.idEstablecimiento = intIdEstablecimiento _
                               And c.fechaProceso.Value.Year = intAnio And
                               c.fechaProceso.Value.Month = intMes And
                               c.movimientoCaja = strMovimiento And
                               listaUsuario.Contains(c.usuarioModificacion)
                               Order By c.fechaProceso
                               Select New With {
                                   .idDocumento = c.idDocumento,
                                   .movimiento = c.tipoOperacion,
                                   .cajaOrigen = x.descripcion,
                                   .cajaDestino = x1.descripcion,
                                   .moneda = c.moneda,
                                   .tipoCambio = c.tipoCambio,
                                   .FechaCobro = c.fechaCobro,
                                   .TipoMovimiento = c.tipoMovimiento,
                                   .TipoDoc = c.tipoDocPago,
                                   .NumDoc = d.nroDoc,
                                   .numOperacion = c.numeroOperacion,
                                   .Glosa = c.glosa,
                                   .MontoSoles = c.montoSoles,
                                   .MontoDolares = c.montoUsd,
                                     .movimientoCaja = c.movimientoCaja,
                                    .usuarioModificacion = c.usuarioModificacion}

                For Each obj In consulta
                    objMostrarEncaja = New documentoCaja() With
                                       {
                                        .idDocumento = obj.idDocumento,
                                    .tipoOperacion = obj.movimiento,
                                    .NomCajaOrigen = obj.cajaOrigen,
                                    .NomCajaDestino = obj.cajaDestino,
                                    .moneda = obj.moneda,
                                    .tipoCambio = obj.tipoCambio,
                                    .fechaCobro = obj.FechaCobro,
                                    .tipoMovimiento = obj.TipoMovimiento,
                                    .tipoDocPago = obj.TipoDoc,
                                    .numeroDoc = obj.NumDoc,
                                    .numeroOperacion = obj.numOperacion,
                                    .glosa = obj.Glosa,
                                    .montoSoles = obj.MontoSoles,
                                    .montoUsd = obj.MontoDolares,
                                        .movimientoCaja = obj.movimientoCaja,
                                        .usuarioModificacion = obj.usuarioModificacion
                                         }
                    ListaCaja.Add(objMostrarEncaja)
                Next
        End Select



        Return ListaCaja
    End Function

    Public Function SaveGroupCajaReversiones(objDocumentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim numeracionBL As New numeracionBoletasBL
        Dim cierreCajaBL As New cierreCajaBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Try

            Dim fechaActual = New Date(objDocumentoBE.documentoCaja.fechaProceso.Value.Year, objDocumentoBE.documentoCaja.fechaProceso.Value.Month, 1)
            Dim fechaAnterior = fechaActual.AddMonths(-1)

            'si es false es porque no esta dentro del inicio de operaciones
            Dim valor = empresaCierreMensualBL.GetValidaFechaInicioOperacion(objDocumentoBE.idEmpresa, fechaActual, objDocumentoBE.idCentroCosto)
            If valor = "False" Then
                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month, objDocumentoBE.idCentroCosto) = False Then
                    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                End If
            ElseIf valor = "True" Then
                Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
            Else
                If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaActual.Year, fechaActual.Month, objDocumentoBE.idCentroCosto) Then
                    Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                End If

                'If cierreCajaBL.CajaTienePeriodoCerradoV2(objDocumentoBE.idEmpresa, fechaAnterior.Year, fechaAnterior.Month) = False Then
                '    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                'End If
            End If

            Using ts As New TransactionScope()
                Dim numeracionAuto = numeracionBL.GenerarNumeroPorCodigoEmpresa("OES", objDocumentoBE.idEmpresa, "9901", objDocumentoBE.idCentroCosto)
                If numeracionAuto IsNot Nothing Then
                    objDocumentoBE.nroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                    documentoBL.Insert(objDocumentoBE)
                    objDocumentoBE.documentoCaja.numeroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                    InsertME(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                    'cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)
                    cajaDetalleBL.InsertCajaME(objDocumentoBE, objDocumentoBE.idDocumento, objDocumentoBE.documentoCaja.entidadFinanciera)
                    AsientoBL.SavebyGroupDoc(objDocumentoBE)

                    If (Not IsNothing(objDocumentoBE.documentoCaja.documentoCajaDetalle(0).idCajaPadre)) Then
                        updateEstadoCaja(objDocumentoBE.documentoCaja.documentoCajaDetalle(0).idCajaPadre, objDocumentoBE.documentoCaja.tipo)
                    End If
                    HeliosData.SaveChanges()
                    ts.Complete()
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objDocumentoBE.idDocumento
    End Function

    Public Function ObtenerMovCajaReversion(strEmpresa As String, anio As Integer, mes As Integer) As List(Of documentoCaja)
        Dim docCuenta As New documentoCaja
        Dim listaDoc As New List(Of documentoCaja)
        Dim consulta = (From n In HeliosData.documentoCaja
                        Join EF In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals EF.idDocumento
                        Where n.estado = "A" And n.movimientoCaja = "RV" And n.idEmpresa = strEmpresa _
                            And n.fechaProceso.Value.Year = anio _
                            And n.fechaProceso.Value.Month = mes).ToList

        'For Each items In consulta4
        If (Not IsNothing(consulta)) Then
            For Each items In consulta
                docCuenta = New documentoCaja
                docCuenta.idDocumento = items.n.idDocumento
                docCuenta.idEmpresa = items.n.idEmpresa
                docCuenta.idEstablecimiento = items.n.idEstablecimiento
                docCuenta.codigoLibro = items.n.idEmpresa
                docCuenta.tipoMovimiento = items.n.tipoMovimiento
                docCuenta.codigoProveedor = items.n.codigoProveedor
                docCuenta.fechaProceso = items.n.fechaProceso
                docCuenta.periodo = items.n.periodo
                docCuenta.fechaCobro = items.n.fechaCobro
                docCuenta.tipoDocPago = items.n.tipoDocPago
                docCuenta.numeroDoc = items.n.numeroDoc
                docCuenta.moneda = items.n.moneda
                docCuenta.entidadFinanciera = items.n.entidadFinanciera
                docCuenta.entidadFinancieraDestino = items.n.entidadFinancieraDestino
                docCuenta.tipoOperacion = items.n.tipoOperacion
                docCuenta.numeroOperacion = items.n.numeroOperacion
                docCuenta.tipoCambio = items.n.tipoCambio
                docCuenta.montoSoles = items.n.montoSoles
                docCuenta.montoUsd = items.n.montoUsd
                docCuenta.glosa = items.n.glosa
                docCuenta.entregado = items.n.entregado
                docCuenta.bancoEntidad = items.n.bancoEntidad
                docCuenta.ctaCorrienteDeposito = items.n.ctaCorrienteDeposito
                docCuenta.ctaIntebancaria = items.n.ctaIntebancaria
                docCuenta.movimientoCaja = items.n.movimientoCaja
                docCuenta.estado = items.n.estado
                docCuenta.usuarioModificacion = items.n.usuarioModificacion
                docCuenta.fechaModificacion = items.n.fechaModificacion
                docCuenta.idEstado = items.EF.idCajaPadre
                listaDoc.Add(docCuenta)
            Next

        End If

        Return listaDoc
    End Function

    Public Function ObtenerHistorialReversion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, tipoEstado As List(Of String)) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim fechaPeriodo = General.GetPeriodoConvertirToDate(strPeriodo)
        Dim listaEstado As New List(Of String)

        listaEstado.Add("RV")

        Dim Consulta = (From c In HeliosData.documentoCaja
                        Join e In HeliosData.estadosFinancieros On New With {.EntidadFinanciera = c.entidadFinanciera} Equals New With {.EntidadFinanciera = CStr(e.idestado)}
                        Join e2 In HeliosData.estadosFinancieros On New With {.EntidadFinanciera = c.entidadFinanciera} Equals New With {.EntidadFinanciera = CStr(e2.idestado)}
                        Where
                            c.idEmpresa = strIdEmpresa And
                            CLng(c.idEstablecimiento) = intIdEstablecimiento And
                            c.fechaProceso.Value.Year = fechaPeriodo.Year And
                            c.fechaProceso.Value.Month = fechaPeriodo.Month And
                            tipoEstado.Contains(c.estado) And
                            c.movimientoCaja <> strMovimiento
                        Group New With {c, e, e2} By
                            c.idDocumento,
                            c.tipoOperacion,
                            e.descripcion,
                            Column1 = e2.descripcion,
                            c.moneda,
                            c.tipoCambio,
                            c.fechaCobro,
                            c.tipoMovimiento,
                            c.tipoDocPago,
                            c.numeroDoc,
                            c.numeroOperacion,
                            c.glosa,
                            c.montoSoles,
                            c.montoUsd,
                            c.tipoPersona,
                            c.idPersonal,
                            c.movimientoCaja,
                            c.fechaProceso,
                            c.estado
                            Into g = Group
                        Order By
                            fechaProceso
                        Select
                            idDocumento,
                            tipoOperacion,
                            cajaOrigen = descripcion,
                            cajaDestino = Column1,
                            moneda,
                            tipoCambio,
                            fechaCobro,
                            tipoMovimiento,
                            tipoDocPago,
                            numeroDoc,
                            numeroOperacion,
                            glosa,
                            montoSoles,
                            montoUsd,
                            tipoPersona,
                            idPersonal,
                            movimientoCaja,
                            fechaProceso,
                            estado,
                            montoMN = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCajaDetalle
                                                   Where
                                                       listaEstado.Contains(dc.documentoCaja.movimientoCaja) And
                                                       dc.idCajaPadre = idDocumento
                                                   Select New With {
                                                       dc.montoSoles
                                                       }) Into Sum(t1.montoSoles)), Decimal?)),
                            montoME = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCajaDetalle
                                                   Where
                                                      listaEstado.Contains(dc.documentoCaja.movimientoCaja) And
                                                       dc.idCajaPadre = idDocumento
                                                   Select New With {
                                                       dc.montoUsd
                                                       }) Into Sum(t1.montoUsd)), Decimal?))).ToList


        For Each obj In Consulta
            objMostrarEncaja = New documentoCaja() With
                               {
                                .idDocumento = obj.idDocumento,
                                .tipoOperacion = obj.tipoOperacion,
                                .NomCajaOrigen = obj.cajaOrigen,
                                .NomCajaDestino = obj.cajaDestino,
                                .moneda = obj.moneda,
                                .tipoCambio = obj.tipoCambio,
                                .fechaCobro = obj.fechaCobro,
                                .fechaProceso = obj.fechaProceso,
                                .tipoMovimiento = obj.tipoMovimiento,
                                .tipoDocPago = obj.tipoDocPago,
                                .numeroDoc = obj.numeroDoc,
                                .numeroOperacion = obj.numeroOperacion,
                                .glosa = obj.glosa,
                                .montoSoles = obj.montoSoles.GetValueOrDefault,
                                .montoUsd = obj.montoUsd.GetValueOrDefault,
                                .tipoPersona = obj.tipoPersona,
                                .idPersonal = obj.idPersonal.GetValueOrDefault,
                                .movimientoCaja = obj.movimientoCaja,
                                    .MontoEgresosMN = obj.montoMN.GetValueOrDefault,
                                .MontoEgresosME = obj.montoME.GetValueOrDefault,
                                .estado = obj.estado
                                 }
            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function

    Public Sub ConfirmacionBancaria(be As List(Of documentoCaja))
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim numeracionBL As New numeracionBoletasBL
        Try
            'Using ts As New TransactionScope()
            For Each i In be

                    Me.updateTransaccionBanco(i)

                Next


            'End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Sub updateTransaccionBanco(be As documentoCaja)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim numeracionBL As New numeracionBoletasBL
        Try
            Using ts As New TransactionScope()


                Dim DocCaja = (From n In HeliosData.documentoCaja
                               Where n.idDocumento = be.idDocumento).First
                DocCaja.confirmacionOperacion = be.confirmacionOperacion
                DocCaja.idRol = be.idRol
                DocCaja.IdUsuarioTransaccion = be.IdUsuarioTransaccion
                DocCaja.fechaconfirmacionOperacion = be.fechaconfirmacionOperacion


                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub updateEstadoCaja(idDocumento As Integer, estado As String)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim numeracionBL As New numeracionBoletasBL
        Try
            Using ts As New TransactionScope()

                If (idDocumento > 0) Then
                    Dim DocCaja = (From n In HeliosData.documentoCaja
                                   Where n.idDocumento = idDocumento).First
                    DocCaja.estado = estado
                End If
                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ObtenerMovCajaDevolucion(strEmpresa As String, anio As Integer, mes As Integer, tipo As List(Of String), listaEstado As List(Of String), listaMov As List(Of String)) As List(Of documentoCaja)
        Dim docCuenta As New documentoCaja
        Dim listaDoc As New List(Of documentoCaja)

        Dim consulta = (From n In HeliosData.documentoCaja
                        Join EF In HeliosData.documentoCajaDetalle
                         On n.idDocumento Equals EF.idDocumento
                        Where listaEstado.Contains(n.estado) _
                            And tipo.Contains(n.tipoMovimiento) _
                            And listaMov.Contains(n.movimientoCaja) And n.idEmpresa = strEmpresa _
                            And n.fechaProceso.Value.Year = anio _
                            And n.fechaProceso.Value.Month = mes).ToList

        'For Each items In consulta4
        If (Not IsNothing(consulta)) Then
            For Each items In consulta
                docCuenta = New documentoCaja
                docCuenta.idDocumento = items.n.idDocumento
                docCuenta.idEmpresa = items.n.idEmpresa
                docCuenta.idEstablecimiento = items.n.idEstablecimiento
                docCuenta.codigoLibro = items.n.idEmpresa
                docCuenta.tipoMovimiento = items.n.tipoMovimiento
                docCuenta.codigoProveedor = items.n.codigoProveedor
                docCuenta.fechaProceso = items.n.fechaProceso
                docCuenta.periodo = items.n.periodo
                docCuenta.fechaCobro = items.n.fechaCobro
                docCuenta.tipoDocPago = items.n.tipoDocPago
                docCuenta.numeroDoc = items.n.numeroDoc
                docCuenta.moneda = items.n.moneda
                docCuenta.entidadFinanciera = items.n.entidadFinanciera
                docCuenta.entidadFinancieraDestino = items.n.entidadFinancieraDestino
                docCuenta.tipoOperacion = items.n.tipoOperacion
                docCuenta.numeroOperacion = items.n.numeroOperacion
                docCuenta.tipoCambio = items.n.tipoCambio
                docCuenta.montoSoles = items.n.montoSoles
                docCuenta.montoUsd = items.n.montoUsd
                docCuenta.glosa = items.n.glosa
                docCuenta.entregado = items.n.entregado
                docCuenta.bancoEntidad = items.n.bancoEntidad
                docCuenta.ctaCorrienteDeposito = items.n.ctaCorrienteDeposito
                docCuenta.ctaIntebancaria = items.n.ctaIntebancaria
                docCuenta.movimientoCaja = items.n.movimientoCaja
                docCuenta.estado = items.n.estado
                docCuenta.usuarioModificacion = items.n.usuarioModificacion
                docCuenta.fechaModificacion = items.n.fechaModificacion
                docCuenta.idEstado = items.EF.idCajaPadre
                listaDoc.Add(docCuenta)
            Next

        End If

        Return listaDoc
    End Function

    Public Function ObtenerAnticiposConDevolucion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, listaMovimiento As List(Of String), tipoEstado As List(Of String), listaTransac As List(Of String)) As List(Of documentoCaja)
        Dim objMostrarEncaja As documentoCaja
        Dim ListaCaja As New List(Of documentoCaja)
        Dim fechaPeriodo = General.GetPeriodoConvertirToDate(strPeriodo)
        'Dim listaEstado As New List(Of String)

        'listaEstado.Add("DV")

        Dim Consulta = (From c In HeliosData.documentoCaja
                        Join e In HeliosData.estadosFinancieros On New With {.EntidadFinanciera = c.entidadFinanciera} Equals New With {.EntidadFinanciera = CStr(e.idestado)}
                        Join e2 In HeliosData.estadosFinancieros On New With {.EntidadFinanciera = c.entidadFinanciera} Equals New With {.EntidadFinanciera = CStr(e2.idestado)}
                        Where
                            listaMovimiento.Contains(c.movimientoCaja) And
                            c.idEmpresa = strIdEmpresa And
                            CLng(c.idEstablecimiento) = intIdEstablecimiento And
                            c.fechaProceso.Value.Year = fechaPeriodo.Year And
                            c.fechaProceso.Value.Month = fechaPeriodo.Month And
                            tipoEstado.Contains(c.estado)
                        Group New With {c, e, e2} By
                            c.idDocumento,
                            c.tipoOperacion,
                            e.descripcion,
                            Column1 = e2.descripcion,
                            c.moneda,
                            c.tipoCambio,
                            c.fechaCobro,
                            c.tipoMovimiento,
                            c.tipoDocPago,
                            c.numeroDoc,
                            c.numeroOperacion,
                            c.glosa,
                            c.montoSoles,
                            c.montoUsd,
                            c.tipoPersona,
                            c.idPersonal,
                            c.movimientoCaja,
                            c.fechaProceso,
                            c.estado
                            Into g = Group
                        Order By
                            fechaProceso
                        Select
                            idDocumento,
                            tipoOperacion,
                            cajaOrigen = descripcion,
                            cajaDestino = Column1,
                            moneda,
                            tipoCambio,
                            fechaCobro,
                            tipoMovimiento,
                            tipoDocPago,
                            numeroDoc,
                            numeroOperacion,
                            glosa,
                            montoSoles,
                            montoUsd,
                            tipoPersona,
                            idPersonal,
                            movimientoCaja,
                            fechaProceso,
                            estado,
                            montoMN = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCajaDetalle
                                                   Where
                                                       listaTransac.Contains(dc.documentoCaja.movimientoCaja) And
                                                       dc.idCajaPadre = idDocumento
                                                   Select New With {
                                                       dc.montoSoles
                                                       }) Into Sum(t1.montoSoles)), Decimal?)),
                            montoME = (CType((Aggregate t1 In
                                                  (From dc In HeliosData.documentoCajaDetalle
                                                   Where
                                                      listaTransac.Contains(dc.documentoCaja.movimientoCaja) And
                                                       dc.idCajaPadre = idDocumento
                                                   Select New With {
                                                       dc.montoUsd
                                                       }) Into Sum(t1.montoUsd)), Decimal?))).ToList


        For Each obj In Consulta
            objMostrarEncaja = New documentoCaja() With
                               {
                                .idDocumento = obj.idDocumento,
                                .tipoOperacion = obj.tipoOperacion,
                                .NomCajaOrigen = obj.cajaOrigen,
                                .NomCajaDestino = obj.cajaDestino,
                                .moneda = obj.moneda,
                                .tipoCambio = obj.tipoCambio,
                                .fechaCobro = obj.fechaCobro,
                                .fechaProceso = obj.fechaProceso,
                                .tipoMovimiento = obj.tipoMovimiento,
                                .tipoDocPago = obj.tipoDocPago,
                                .numeroDoc = obj.numeroDoc,
                                .numeroOperacion = obj.numeroOperacion,
                                .glosa = obj.glosa,
                                .montoSoles = obj.montoSoles.GetValueOrDefault,
                                .montoUsd = obj.montoUsd.GetValueOrDefault,
                                .tipoPersona = obj.tipoPersona,
                                .idPersonal = obj.idPersonal.GetValueOrDefault,
                                .movimientoCaja = obj.movimientoCaja,
                                    .MontoEgresosMN = obj.montoMN.GetValueOrDefault,
                                .MontoEgresosME = obj.montoME.GetValueOrDefault,
                                .estado = obj.estado
                                 }
            ListaCaja.Add(objMostrarEncaja)
        Next

        Return ListaCaja
    End Function

    Public Function ResumenEntidadesFinancieras(cajaBE As cajaUsuario, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja

        Dim consulta = (From e In HeliosData.estadosFinancieros
                        Join c In HeliosData.cajaUsuariodetalle On New With {.Idestado = e.idestado} Equals New With {.Idestado = CInt(c.idEntidad)}
                        Where
                                listaPersona.Contains(c.cajaUsuario.idcajaUsuario) And
                                c.cajaUsuario.estadoCaja = cajaBE.estadoCaja And
                                c.cajaUsuario.idEmpresa = cajaBE.idEmpresa And
                                CLng(c.cajaUsuario.idEstablecimiento) = cajaBE.idEstablecimiento
                        Group New With {e, c} By
                                e.tipo,
                                e.descripcion,
                                c.importeMN,
                                c.idcajaUsuario,
                                e.idestado,
                                e.codigo,
                            c.cajaUsuario.fechaRegistro
                        Into g = Group
                        Select
                                tipo,
                                descripcion,
                                Idestado = CType(idestado, Int32?),
                                importeMN,
                                idcajaUsuario,
                                codigo,
                            fechaRegistro).ToList

        For Each item In consulta
            docCuenta = New documentoCaja

            docCuenta.idCajaUsuario = item.idcajaUsuario
            docCuenta.idEstado = item.Idestado
            docCuenta.codigo = item.codigo
            docCuenta.tipo = item.tipo
            docCuenta.DetalleItem = item.descripcion
            docCuenta.montoSoles = item.importeMN.GetValueOrDefault
            docCuenta.fechaProceso = item.fechaRegistro
            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function

    Function ListaResumenXEntidad(listaidPersona As List(Of Integer), fechaInicio As DateTime, fechaFin As DateTime, tipo As String,
                           strEmpresa As String, idEstablec As Integer, intAnio As Integer,
                           intMes As Integer, intDia As Integer, IdEntidad As Integer) As documentoCaja

        Dim lista As New List(Of documentoCaja)
        Dim nDocumentoCaja As New documentoCaja
        Dim listaDocCaja As New List(Of documentoCaja)
        Dim tipoventas As New List(Of String)
        tipoventas.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
        tipoventas.Add(TIPO_VENTA.VENTA_AL_TICKET)
        Dim tipoventasElectronicas As New List(Of String)
        tipoventasElectronicas.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        tipoventasElectronicas.Add(TIPO_VENTA.VENTA_AL_TICKET)

        Using ts As New TransactionScope
            Select Case tipo
                Case "XTODO"
                    Dim consulta = (From d In HeliosData.documentoCaja
                                    Where
                                                    d.idEmpresa = strEmpresa And
                                                d.idEstablecimiento = idEstablec And
                                                d.fechaProceso.Value.Year = intAnio
                                    Group d By d.idEmpresa Into g = Group
                                    Select
                                        Aporte = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AP" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        transferenciaRecibido = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "TEC" And
                                         a.tipoMovimiento = "DC" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                    transferenciaOtorgado = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "TEC" And
                                         a.tipoMovimiento = "PG" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Otorgados = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AO" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Recibidos = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AR" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasEntradas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OEC" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasSalidas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OSC" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        PreVenta = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "IPV" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Compra = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "CCR" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        VentaPost = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        tipoventas.Contains(a.movimientoCaja) And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                         VentaElectronicas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        tipoventasElectronicas.Contains(a.movimientoCaja) And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        ventaContado = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VTAG" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault


                    If (Not IsNothing(consulta)) Then
                        nDocumentoCaja = New documentoCaja
                        With nDocumentoCaja
                            .Aporte = consulta.Aporte.GetValueOrDefault
                            .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
                            .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
                            .anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
                            .anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
                            .ticket = consulta.PreVenta.GetValueOrDefault
                            .cuentasXPagar = consulta.Compra.GetValueOrDefault
                            .ventaPost = consulta.VentaPost.GetValueOrDefault
                            .ventaContado = consulta.ventaContado.GetValueOrDefault
                            .transferenciaRecibido = consulta.transferenciaRecibido.GetValueOrDefault
                            .transferenciaOtorgado = consulta.transferenciaOtorgado.GetValueOrDefault
                            .VentaElectronicas = consulta.VentaElectronicas.GetValueOrDefault
                        End With
                    End If
                Case "XPERIODO"
                    Dim consulta = (From d In HeliosData.documentoCaja
                                    Where
                                                    d.idEmpresa = strEmpresa And
                                                d.idEstablecimiento = idEstablec And
                                                d.fechaProceso.Value.Year = intAnio And
                                        d.fechaProceso.Value.Month = intMes
                                    Group d By d.idEmpresa Into g = Group
                                    Select
                                        Aporte = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AP" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        transferenciaRecibido = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "TEC" And
                                         a.tipoMovimiento = "DC" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                    transferenciaOtorgado = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "TEC" And
                                         a.tipoMovimiento = "PG" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Otorgados = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AO" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Recibidos = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AR" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasEntradas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OEC" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasSalidas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OSC" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        PreVenta = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "IPV" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Compra = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "CCR" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        VentaPost = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        tipoventas.Contains(a.movimientoCaja) And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                         VentaElectronicas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        tipoventasElectronicas.Contains(a.movimientoCaja) And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        ventaContado = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VTAG" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault


                    If (Not IsNothing(consulta)) Then
                        nDocumentoCaja = New documentoCaja
                        With nDocumentoCaja
                            .Aporte = consulta.Aporte.GetValueOrDefault
                            .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
                            .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
                            .anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
                            .anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
                            '.ticket = consulta.PreVenta.GetValueOrDefault
                            .cuentasXPagar = consulta.Compra.GetValueOrDefault
                            .ventaPost = consulta.VentaPost.GetValueOrDefault
                            .ventaContado = consulta.ventaContado.GetValueOrDefault
                            .transferenciaRecibido = consulta.transferenciaRecibido.GetValueOrDefault
                            .transferenciaOtorgado = consulta.transferenciaOtorgado.GetValueOrDefault
                            .VentaElectronicas = consulta.VentaElectronicas.GetValueOrDefault
                        End With
                    End If

                Case "XDIA"
                    Dim consulta = (From d In HeliosData.documentoCaja
                                    Where
                                                    d.idEmpresa = strEmpresa And
                                                d.idEstablecimiento = idEstablec And
                                                d.fechaProceso.Value.Year = intAnio And
                                        d.fechaProceso.Value.Month = intMes And
                                         d.fechaProceso.Value.Day = intDia
                                    Group d By d.idEmpresa Into g = Group
                                    Select
                                        Aporte = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AP" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        transferenciaRecibido = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "TEC" And
                                         a.tipoMovimiento = "DC" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                    transferenciaOtorgado = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "TEC" And
                                         a.tipoMovimiento = "PG" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Otorgados = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AO" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Recibidos = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "AR" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasEntradas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OEC" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasSalidas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OSC" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        PreVenta = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "IPV" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Compra = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "CCR" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        VentaPost = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        tipoventas.Contains(a.movimientoCaja) And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                         VentaElectronicas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        tipoventasElectronicas.Contains(a.movimientoCaja) And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        ventaContado = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "VTAG" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault


                    If (Not IsNothing(consulta)) Then
                        nDocumentoCaja = New documentoCaja
                        With nDocumentoCaja
                            .Aporte = consulta.Aporte.GetValueOrDefault
                            .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
                            .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
                            .anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
                            .anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
                            '.cuentasXcobrar = consulta..GetValueOrDefault
                            .cuentasXPagar = consulta.Compra.GetValueOrDefault
                            .ventaPost = consulta.VentaPost.GetValueOrDefault
                            .ventaContado = consulta.ventaContado.GetValueOrDefault
                            .transferenciaRecibido = consulta.transferenciaRecibido.GetValueOrDefault
                            .transferenciaOtorgado = consulta.transferenciaOtorgado.GetValueOrDefault
                            .VentaElectronicas = consulta.VentaElectronicas.GetValueOrDefault
                        End With
                    End If

                Case "XHORA"

                Case "XESTADO"
                    Dim consulta = (From d In HeliosData.documentoCaja
                                    Where
                                        d.idEmpresa = strEmpresa And
                                        d.idEstablecimiento = idEstablec And
                                        TruncateTime(d.fechaProceso) >= fechaInicio.Date
                                    Group d By d.idEmpresa Into g = Group
                                    Select
                                        OtrasEntradas = (CType((Aggregate t1 In
                                                                    (From a In HeliosData.documentoCaja
                                                                     Where
                                                                         a.movimientoCaja = "OEC" And
                                                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad And
                                         a.estado = 1
                                                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        OtrasSalidas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = "OSC" And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad And
                                         a.estado = 1
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        cuentasXpagar = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = MovimientoCaja.PagoProveedor And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        cuentasXcobrar = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = MovimientoCaja.CobroCliente And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        VentaPost = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        tipoventas.Contains(a.movimientoCaja) And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                         VentaElectronicas = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        tipoventasElectronicas.Contains(a.movimientoCaja) And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        notaVenta = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        Ventaheredada = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.movimientoCaja = TIPO_VENTA.VENTA_HEREDAD And
                                         listaidPersona.Contains(a.idCajaUsuario) And
                                        a.entidadFinanciera = IdEntidad
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault


                    If (Not IsNothing(consulta)) Then
                        nDocumentoCaja = New documentoCaja
                        With nDocumentoCaja
                            '.Aporte = consulta.Aporte.GetValueOrDefault
                            .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
                            .otrasSalidas = consulta.OtrasSalidas.GetValueOrDefault
                            .cuentasXcobrar = consulta.cuentasXcobrar.GetValueOrDefault
                            .cuentasXPagar = consulta.cuentasXpagar.GetValueOrDefault
                            .ventaPost = consulta.VentaPost.GetValueOrDefault
                            .notaVenta = consulta.notaVenta.GetValueOrDefault
                            .VentaHeredadaMN = consulta.Ventaheredada.GetValueOrDefault
                            .VentaElectronicas = consulta.VentaElectronicas.GetValueOrDefault
                            '.anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
                            '.anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
                            '.transferenciaRecibido = consulta.transferenciaRecibido.GetValueOrDefault
                            '.transferenciaOtorgado = consulta.transferenciaOtorgado.GetValueOrDefault
                        End With
                    End If

            End Select

            Return nDocumentoCaja

        End Using
    End Function

    Public Function GetMovimientosCajaCajeroTipoMonedaAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim lista = GetMovimientosCajaCajeroPENAdmi(be).Union(GetMovimientosCajaCajeroUSDAdmi(be)).ToList
        Return lista
    End Function

    Public Function GetMovimientosEfectivoCajero(be As cajaUsuario) As List(Of documentoCaja)
        Dim lista = GetMovimientosEfectivoCajeroPEN(be).Union(GetMovimientosEfectivoCajeroUSD(be)).ToList
        Return lista
    End Function

    Public Function GetMovimientosCajaCajeroTipoMoneda(be As cajaUsuario) As List(Of documentoCaja)
        Dim lista = GetMovimientosCajaCajeroPEN(be).Union(GetMovimientosCajaCajeroUSD(be)).ToList
        Return lista
    End Function


    Public Function GetMovimientosCajaCajeroUSDAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuarioDestino) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.moneda = "2" And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProcesoDestino.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProcesoDestino.Value.Month = be.fechaCierre.Value.Month And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1
                   Group caja By caja.movimientoCaja Into g = Group
                   Select
                       movimientoCaja,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoUsd), Decimal?)).ToList

        GetMovimientosCajaCajeroUSDAdmi = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaCajeroUSDAdmi.Add(New documentoCaja With
                                         {
                                         .moneda = "2",
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoUsd = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GetMovimientosEfectivoCajeroUSD(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim listaBancarios As New List(Of String)
        listaBancarios.Add("BC")

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.moneda = "2" And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1 And Not listaBancarios.Contains(caja.tipoEntidadFinanciera)
                   Group caja By caja.movimientoCaja Into g = Group
                   Select
                       movimientoCaja,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoUsd), Decimal?)).ToList

        GetMovimientosEfectivoCajeroUSD = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosEfectivoCajeroUSD.Add(New documentoCaja With
                                         {
                                         .moneda = "2",
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoUsd = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GetMovimientosCajaCajeroUSD(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.moneda = "2" And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1
                   Group caja By caja.movimientoCaja Into g = Group
                   Select
                       movimientoCaja,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoUsd), Decimal?)).ToList

        GetMovimientosCajaCajeroUSD = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaCajeroUSD.Add(New documentoCaja With
                                         {
                                         .moneda = "2",
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoUsd = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GetMovimientosBancariosConfirmados(be As documentoCaja) As List(Of documentoCaja)
        Dim list As New List(Of documentoCaja)
        Dim listaEntidMovimientosades As New List(Of String)
        listaEntidMovimientosades.Add("BC")


        Dim consulta = (From caja In HeliosData.documentoCaja
                        Join l In HeliosData.tabladetalle On l.codigoDetalle Equals caja.formapago
                        Where
                     CLng(caja.entidadFinancieraDestino) = be.entidadFinancieraDestino And
                       caja.idEmpresa = be.idEmpresa And
                       caja.moneda = "1" And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProcesoDestino.Value.Year = be.fechaProcesoDestino.Value.Year And
                       caja.fechaProcesoDestino.Value.Month = be.fechaProcesoDestino.Value.Month And
                       listaEntidMovimientosades.Contains(caja.tipoEntidadFinanciera) And
                       caja.confirmacionOperacion = "SI" And
                       caja.estado = 1 And l.idtabla = 1
                        Select
                                iddocumento = caja.idDocumento,
                                identidad = caja.entidadFinancieraDestino,
                            nroOperacion = caja.numeroOperacion,
                            NameformaPago = l.descripcion,
                            formaPago = caja.formapago,
                                doc = (From i In HeliosData.documentoventaAbarrotes
                                       Join h In HeliosData.documentoCajaDetalle
                                                 On i.idDocumento Equals h.documentoAfectado
                                       Where h.idDocumento = caja.idDocumento).FirstOrDefault,
                            fecha = caja.fechaProcesoDestino,
                            montosoles = caja.montoSoles).ToList

        For Each j In consulta
            Dim obj As New documentoCaja
            obj.idDocumento = j.iddocumento
            obj.entidadFinancieraDestino = j.identidad
            obj.fechaProcesoDestino = j.fecha
            obj.montoSoles = j.montosoles
            obj.SerieCompra = j.doc.i.serieVenta
            obj.numeroCompra = j.doc.i.numeroVenta
            obj.tipoDocCompra = j.doc.i.tipoDocumento
            obj.formapago = j.formaPago
            obj.numeroOperacion = j.nroOperacion
            obj.formaPagoName = j.NameformaPago
            list.Add(obj)
        Next


        Return list
    End Function

    Public Function GetMovimientosBancariosPendientes(be As documentoCaja) As List(Of documentoCaja)
        Dim list As New List(Of documentoCaja)
        Dim listaEntidMovimientosades As New List(Of String)
        listaEntidMovimientosades.Add("BC")


        Dim consulta = (From caja In HeliosData.documentoCaja
                        Join l In HeliosData.tabladetalle On l.codigoDetalle Equals caja.formapago
                        Where
                     CLng(caja.entidadFinancieraDestino) = be.entidadFinancieraDestino And
                       caja.idEmpresa = be.idEmpresa And
                       caja.moneda = "1" And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProcesoDestino.Value.Year = be.fechaProcesoDestino.Value.Year And
                       caja.fechaProcesoDestino.Value.Month = be.fechaProcesoDestino.Value.Month And
                       listaEntidMovimientosades.Contains(caja.tipoEntidadFinanciera) And
                       caja.confirmacionOperacion = "NO" And
                       caja.estado = 1 And l.idtabla = 1
                        Select
                                iddocumento = caja.idDocumento,
                                identidad = caja.entidadFinancieraDestino,
                            nroOperacion = caja.numeroOperacion,
                            NameformaPago = l.descripcion,
                            formaPago = caja.formapago,
                                doc = (From i In HeliosData.documentoventaAbarrotes
                                       Join h In HeliosData.documentoCajaDetalle
                                                 On i.idDocumento Equals h.documentoAfectado
                                       Where h.idDocumento = caja.idDocumento).FirstOrDefault,
                            fecha = caja.fechaProcesoDestino,
                            montosoles = caja.montoSoles).ToList

        For Each j In consulta
            Dim obj As New documentoCaja
            obj.idDocumento = j.iddocumento
            obj.entidadFinancieraDestino = j.identidad
            obj.fechaProcesoDestino = j.fecha
            obj.montoSoles = j.montosoles
            obj.SerieCompra = j.doc.i.serieVenta
            obj.numeroCompra = j.doc.i.numeroVenta
            obj.tipoDocCompra = j.doc.i.tipoDocumento
            obj.formapago = j.formaPago
            obj.numeroOperacion = j.nroOperacion
            obj.formaPagoName = j.NameformaPago
            list.Add(obj)
        Next


        Return list
    End Function

    Public Function GetMovimientosCajaCajeroPENAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuarioDestino) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.moneda = "1" And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProcesoDestino.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProcesoDestino.Value.Month = be.fechaCierre.Value.Month And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1
                   Group caja By caja.movimientoCaja Into g = Group
                   Select
                       movimientoCaja,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosCajaCajeroPENAdmi = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaCajeroPENAdmi.Add(New documentoCaja With
                                         {
                                         .moneda = "1",
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function


    Public Function GetMovimientosEfectivoCajeroPEN(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)


        Dim listaBancarios As New List(Of String)
        listaBancarios.Add("BC")
        listaBancarios.Add("TC")


        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.moneda = "1" And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1 And Not listaBancarios.Contains(caja.tipoEntidadFinanciera)
                   Group caja By caja.movimientoCaja Into g = Group
                   Select
                       movimientoCaja,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosEfectivoCajeroPEN = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosEfectivoCajeroPEN.Add(New documentoCaja With
                                         {
                                         .moneda = "1",
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function


    Public Function GetMovimientosCajaCajeroPEN(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)


        'Dim listaBancarios As New List(Of String)
        'listaBancarios.Add("BC")


        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.moneda = "1" And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1
                   Group caja By caja.movimientoCaja Into g = Group
                   Select
                       movimientoCaja,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosCajaCajeroPEN = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaCajeroPEN.Add(New documentoCaja With
                                         {
                                         .moneda = "1",
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function


    Public Function GetMovimientosCajaCajero(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1
                   Group caja By caja.movimientoCaja Into g = Group
                   Select
                       movimientoCaja,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosCajaCajero = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaCajero.Add(New documentoCaja With
                                         {
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function


    Public Function GetMovimientosCajaCajeroDetalleAdmi(be As cajaUsuario) As List(Of documentoCaja)

        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Join cajadet In HeliosData.documentoCajaDetalle
                       On cajadet.idDocumento Equals caja.idDocumento
                   Join venta In HeliosData.documento
                       On venta.idDocumento Equals cajadet.documentoAfectado
                   Where
                       CLng(caja.idCajaUsuarioDestino) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProcesoDestino.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProcesoDestino.Value.Month = be.fechaCierre.Value.Month And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1
                   Group cajadet By
                       caja.movimientoCaja,
                       venta.idDocumento,
                       venta.nroDoc,
                       IdCajaDoc = caja.idDocumento,
                       caja.formapago,
                       caja.numeroOperacion,
                       caja.glosa,
                       caja.moneda,
                       caja.tipoMovimiento Into g = Group
                   Select
                       movimientoCaja,
                       tipoMovimiento,
                       idDocumento,
                       nroDoc,
                       IdCajaDoc,
                       formapago,
                       numeroOperacion,
                       glosa,
                       moneda,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?),
                       SumatoriaMovimientoME = CType(g.Sum(Function(p) p.montoUsd), Decimal?)).ToList



        GetMovimientosCajaCajeroDetalleAdmi = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaCajeroDetalleAdmi.Add(New documentoCaja With
                                         {
                                         .movimientoCaja = i.movimientoCaja,
                                         .tipoMovimiento = i.tipoMovimiento,
                                         .idDocumento = i.idDocumento,
                                         .NumeroDocumento = i.nroDoc,' $"{i.serieVenta}-{i.numeroVenta}",
                                         .idcosto = i.IdCajaDoc,
                                         .formapago = i.formapago,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault,
                                         .montoUsd = i.SumatoriaMovimientoME.GetValueOrDefault,
                                         .numeroOperacion = i.numeroOperacion,
                                         .glosa = i.glosa,
                                         .moneda = i.moneda
                                         })
        Next

    End Function

    Public Function GetMovimientosCajaCajeroDetalle(be As cajaUsuario) As List(Of documentoCaja)

        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        'Dim listaBancarios As New List(Of String)
        'listaBancarios.Add("BC")

        Dim con = (From caja In HeliosData.documentoCaja
                   Join cajadet In HeliosData.documentoCajaDetalle
                       On cajadet.idDocumento Equals caja.idDocumento
                   Join venta In HeliosData.documento
                       On venta.idDocumento Equals cajadet.documentoAfectado
                   Where
                       CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1 'And Not listaBancarios.Contains(caja.tipoEntidadFinanciera)
                   Group cajadet By
                       caja.movimientoCaja,
                       venta.idDocumento,
                       venta.nroDoc,
                       IdCajaDoc = caja.idDocumento,
                       caja.formapago,
                       caja.numeroOperacion,
                       caja.glosa,
                       caja.moneda,
                       caja.tipoMovimiento Into g = Group
                   Select
                       movimientoCaja,
                       tipoMovimiento,
                       idDocumento,
                       nroDoc,
                       IdCajaDoc,
                       formapago,
                       numeroOperacion,
                       glosa,
                       moneda,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?),
                       SumatoriaMovimientoME = CType(g.Sum(Function(p) p.montoUsd), Decimal?)).ToList



        GetMovimientosCajaCajeroDetalle = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaCajeroDetalle.Add(New documentoCaja With
                                         {
                                         .movimientoCaja = i.movimientoCaja,
                                         .tipoMovimiento = i.tipoMovimiento,
                                         .idDocumento = i.idDocumento,
                                         .NumeroDocumento = i.nroDoc,' $"{i.serieVenta}-{i.numeroVenta}",
                                         .idcosto = i.IdCajaDoc,
                                         .formapago = i.formapago,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault,
                                         .montoUsd = i.SumatoriaMovimientoME.GetValueOrDefault,
                                         .numeroOperacion = i.numeroOperacion,
                                         .glosa = i.glosa,
                                         .moneda = i.moneda
                                         })
        Next

    End Function


    Public Function GetMovimientosFormaPagoCajeroMonedaAdmi(be As cajaUsuario) As List(Of documentoCaja)

        Dim Query = GetMovimientosFormaPagoCajeroPENAdmi(be).Union(GetMovimientosFormaPagoCajeroUSDAdmi(be)).ToList

        Return Query
    End Function

    Public Function GetMovimientosFormaPagoCajeroMoneda(be As cajaUsuario) As List(Of documentoCaja)

        Dim Query = GetMovimientosFormaPagoCajeroPEN(be).Union(GetMovimientosFormaPagoCajeroUSD(be)).ToList

        Return Query
    End Function


    Public Function GetMovimientosFormaPagoCajeroUSDAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuarioDestino) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProcesoDestino.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProcesoDestino.Value.Month = be.fechaCierre.Value.Month And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.moneda = "2" And
                       caja.estado = 1
                   Group caja By caja.tipoMovimiento, caja.formapago Into g = Group
                   Select
                       formapago, tipoMovimiento,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoUsd), Decimal?)).ToList

        GetMovimientosFormaPagoCajeroUSDAdmi = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosFormaPagoCajeroUSDAdmi.Add(New documentoCaja With
                                         {
                                         .tipoMovimiento = i.tipoMovimiento,
                                         .formapago = i.formapago,
                                         .moneda = "2",
                                         .montoUsd = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GetMovimientosFormaPagoCajeroUSD(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        'Dim listaBancarios As New List(Of String)
        'listaBancarios.Add("BC")

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.moneda = "2" And
                       caja.estado = 1 'And Not listaBancarios.Contains(caja.tipoEntidadFinanciera)
                   Group caja By caja.tipoMovimiento, caja.formapago Into g = Group
                   Select
                       formapago, tipoMovimiento,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoUsd), Decimal?)).ToList

        GetMovimientosFormaPagoCajeroUSD = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosFormaPagoCajeroUSD.Add(New documentoCaja With
                                         {
                                         .tipoMovimiento = i.tipoMovimiento,
                                         .formapago = i.formapago,
                                         .moneda = "2",
                                         .montoUsd = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function


    Public Function GetMovimientosFormaPagoCajeroPENAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuarioDestino) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProcesoDestino.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProcesoDestino.Value.Month = be.fechaCierre.Value.Month And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.moneda = "1" And
                       caja.estado = 1
                   Group caja By caja.tipoMovimiento, caja.formapago Into g = Group
                   Select
                       formapago, tipoMovimiento,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosFormaPagoCajeroPENAdmi = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosFormaPagoCajeroPENAdmi.Add(New documentoCaja With
                                         {
                                         .tipoMovimiento = i.tipoMovimiento,
                                         .formapago = i.formapago,
                                         .moneda = "1",
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GetMovimientosFormaPagoCajeroPEN(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)
        'Dim listaBancarios As New List(Of String)
        'listaBancarios.Add("BC")


        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.moneda = "1" And
                       caja.estado = 1 'And Not listaBancarios.Contains(caja.tipoEntidadFinanciera)
                   Group caja By caja.tipoMovimiento, caja.formapago Into g = Group
                   Select
                       formapago, tipoMovimiento,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosFormaPagoCajeroPEN = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosFormaPagoCajeroPEN.Add(New documentoCaja With
                                         {
                                         .tipoMovimiento = i.tipoMovimiento,
                                         .formapago = i.formapago,
                                         .moneda = "1",
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GetMovimientosFormaPagoCajero(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                     CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1
                   Group caja By caja.tipoMovimiento, caja.formapago Into g = Group
                   Select
                       formapago, tipoMovimiento,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosFormaPagoCajero = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosFormaPagoCajero.Add(New documentoCaja With
                                         {
                                         .tipoMovimiento = i.tipoMovimiento,
                                         .formapago = i.formapago,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function


    Public Function GetMovimientosFormaPagoCajeroDetalleAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Join ef In HeliosData.estadosFinancieros
                       On ef.idestado Equals caja.entidadFinanciera
                   Where
                     CLng(caja.idCajaUsuarioDestino) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProcesoDestino.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProcesoDestino.Value.Month = be.fechaCierre.Value.Month And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1
                   Select
                       caja.idDocumento,
                       caja.tipoDocPago,
                       caja.numeroDoc,
                       caja.formapago,
                       caja.numeroOperacion,
                       caja.movimientoCaja,
                       caja.tipoMovimiento,
                       caja.moneda,
                       ef.descripcion,
                       ef.nroCtaCorriente,
                       ef.tipo,
                       caja.montoSoles,
                       caja.montoUsd).ToList

        GetMovimientosFormaPagoCajeroDetalleAdmi = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosFormaPagoCajeroDetalleAdmi.Add(New documentoCaja With
                                         {
                                         .idDocumento = i.idDocumento,
                                         .tipoDocPago = i.tipoDocPago,
                                         .numeroDoc = i.numeroDoc,
                                         .formapago = i.formapago,
                                         .tipoMovimiento = i.tipoMovimiento,
                                         .numeroOperacion = i.numeroOperacion,
                                         .movimientoCaja = i.movimientoCaja,
                                         .entidadFinanciera = i.descripcion,
                                         .ctaCorrienteDeposito = i.nroCtaCorriente,
                                         .tipo = i.tipo,
                                         .montoSoles = i.montoSoles,
                                         .moneda = i.moneda,
                                         .montoUsd = i.montoUsd
                                         })
        Next

    End Function

    Public Function GetMovimientosFormaPagoCajeroDetalle(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)


        'Dim listaBancarios As New List(Of String)
        'listaBancarios.Add("BC")

        Dim con = (From caja In HeliosData.documentoCaja
                   Join ef In HeliosData.estadosFinancieros
                       On ef.idestado Equals caja.entidadFinanciera
                   Where
                     CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1 'And Not listaBancarios.Contains(caja.tipoEntidadFinanciera)
                   Select
                       caja.idDocumento,
                       caja.tipoDocPago,
                       caja.numeroDoc,
                       caja.formapago,
                       caja.numeroOperacion,
                       caja.movimientoCaja,
                       caja.tipoMovimiento,
                       caja.moneda,
                       ef.descripcion,
                       ef.nroCtaCorriente,
                       ef.tipo,
                       caja.montoSoles,
                       caja.montoUsd).ToList

        GetMovimientosFormaPagoCajeroDetalle = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosFormaPagoCajeroDetalle.Add(New documentoCaja With
                                         {
                                         .idDocumento = i.idDocumento,
                                         .tipoDocPago = i.tipoDocPago,
                                         .numeroDoc = i.numeroDoc,
                                         .formapago = i.formapago,
                                         .tipoMovimiento = i.tipoMovimiento,
                                         .numeroOperacion = i.numeroOperacion,
                                         .movimientoCaja = i.movimientoCaja,
                                         .entidadFinanciera = i.descripcion,
                                         .ctaCorrienteDeposito = i.nroCtaCorriente,
                                         .tipo = i.tipo,
                                         .montoSoles = i.montoSoles,
                                         .moneda = i.moneda,
                                         .montoUsd = i.montoUsd
                                         })
        Next

    End Function


    Public Function GetMovimientosCajaComprobanteVentasAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        'listaMovimientos.Add("OEC")
        'listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        'listaMovimientos.Add("OSC")
        'listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        'listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Join cajadetalle In HeliosData.documentoCajaDetalle
                       On cajadetalle.idDocumento Equals caja.idDocumento
                   Join venta In HeliosData.documentoventaAbarrotes
                       On venta.idDocumento Equals cajadetalle.documentoAfectado
                   Where
                     CLng(caja.idCajaUsuarioDestino) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProcesoDestino.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProcesoDestino.Value.Month = be.fechaCierre.Value.Month And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1
                   Group cajadetalle By
                       venta.idDocumento, venta.moneda, caja.formapago, venta.tipoDocumento, venta.numeroVenta, venta.serieVenta, venta.ImporteNacional, venta.ImporteExtranjero
                       Into g = Group
                   Select
                       idDocumento,
                       tipoDocumento,
                       serieVenta,
                       numeroVenta,
                       ImporteNacional,
                       ImporteExtranjero,
                       formapago,
                       moneda,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?),
                       SumatoriaMovimientoUSD = CType(g.Sum(Function(p) p.montoUsd), Decimal?)).ToList

        GetMovimientosCajaComprobanteVentasAdmi = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaComprobanteVentasAdmi.Add(New documentoCaja With
                                         {
                                         .idDocumento = i.idDocumento,
                                         .tipoDocPago = i.tipoDocumento,
                                         .NumeroDocumento = $"{i.serieVenta}-{i.numeroVenta}",
                                         .ImporteDesembolsado = i.ImporteNacional,
                                         .ImporteDesembolsadoME = i.ImporteExtranjero,
                                         .moneda = i.moneda,
                                         .formapago = i.formapago,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault,
                                         .montoUsd = i.SumatoriaMovimientoUSD.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GetMovimientosCajaComprobanteVentas(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        'listaMovimientos.Add("OEC")
        'listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        'listaMovimientos.Add("OSC")
        'listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        'listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)
        'Dim listaBancarios As New List(Of String)
        'listaBancarios.Add("BC")


        Dim con = (From caja In HeliosData.documentoCaja
                   Join cajadetalle In HeliosData.documentoCajaDetalle
                       On cajadetalle.idDocumento Equals caja.idDocumento
                   Join venta In HeliosData.documentoventaAbarrotes
                       On venta.idDocumento Equals cajadetalle.documentoAfectado
                   Where
                     CLng(caja.idCajaUsuario) = be.idcajaUsuario And
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja) And
                       caja.estado = 1 'And Not listaBancarios.Contains(caja.tipoEntidadFinanciera)
                   Group cajadetalle By
                       venta.idDocumento, venta.moneda, caja.formapago, venta.tipoDocumento, venta.numeroVenta, venta.serieVenta, venta.ImporteNacional, venta.ImporteExtranjero
                       Into g = Group
                   Select
                       idDocumento,
                       tipoDocumento,
                       serieVenta,
                       numeroVenta,
                       ImporteNacional,
                       ImporteExtranjero,
                       formapago,
                       moneda,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?),
                       SumatoriaMovimientoUSD = CType(g.Sum(Function(p) p.montoUsd), Decimal?)).ToList

        GetMovimientosCajaComprobanteVentas = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaComprobanteVentas.Add(New documentoCaja With
                                         {
                                         .idDocumento = i.idDocumento,
                                         .tipoDocPago = i.tipoDocumento,
                                         .NumeroDocumento = $"{i.serieVenta}-{i.numeroVenta}",
                                         .ImporteDesembolsado = i.ImporteNacional,
                                         .ImporteDesembolsadoME = i.ImporteExtranjero,
                                         .moneda = i.moneda,
                                         .formapago = i.formapago,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault,
                                         .montoUsd = i.SumatoriaMovimientoUSD.GetValueOrDefault
                                         })
        Next

    End Function


    Public Function GetMovimientosCajaFullCajerosAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim listaCajasActivas = be.CustomListaUsuarios.ToList

        Dim con = (From DocumentoCaja In HeliosData.documentoCaja
                   Where
                       listaCajasActivas.Contains(DocumentoCaja.idCajaUsuarioDestino) And
                       listaMovimientos.Contains(DocumentoCaja.movimientoCaja)
                   Group DocumentoCaja By
                       DocumentoCaja.movimientoCaja,
                       DocumentoCaja.idCajaUsuarioDestino
                       Into g = Group
                   Select
                       idCajaUsuarioDestino,
                       movimientoCaja,
                       SumaTotal = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosCajaFullCajerosAdmi = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaFullCajerosAdmi.Add(New documentoCaja With
                                         {
                                         .idCajaUsuario = i.idCajaUsuarioDestino,
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoSoles = i.SumaTotal.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GetMovimientosCajaFullCajeros(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim listaCajasActivas = be.CustomListaUsuarios.ToList

        Dim con = (From DocumentoCaja In HeliosData.documentoCaja
                   Where
                       listaCajasActivas.Contains(DocumentoCaja.idCajaUsuario) And
                       listaMovimientos.Contains(DocumentoCaja.movimientoCaja)
                   Group DocumentoCaja By
                       DocumentoCaja.movimientoCaja,
                       DocumentoCaja.idCajaUsuario
                       Into g = Group
                   Select
                       idCajaUsuario,
                       movimientoCaja,
                       SumaTotal = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosCajaFullCajeros = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaFullCajeros.Add(New documentoCaja With
                                         {
                                         .idCajaUsuario = i.idCajaUsuario,
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoSoles = i.SumaTotal.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GetMovimientosCajaCajeroUnidadNegocio(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja)
                   Group caja By caja.movimientoCaja Into g = Group
                   Select
                       movimientoCaja,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosCajaCajeroUnidadNegocio = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaCajeroUnidadNegocio.Add(New documentoCaja With
                                         {
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function GetMovimientosCajaCajeroUnidadNegocioCajeros(be As cajaUsuario) As List(Of documentoCaja)
        Dim listaMovimientos As New List(Of String)
        listaMovimientos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        listaMovimientos.Add("OEC")
        listaMovimientos.Add(MovimientoCaja.Otras_Entradas_Especial)
        listaMovimientos.Add("OSC")
        listaMovimientos.Add(MovimientoCaja.PagoProveedor)
        listaMovimientos.Add(MovimientoCaja.CobroCliente)
        listaMovimientos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        listaMovimientos.Add(TIPO_VENTA.VENTA_HEREDAD)

        ' Dim listaCajasActivas = be.CustomListaUsuarios.ToList

        'caja.idEmpresa = be.idEmpresa And
        'caja.idEstablecimiento = be.idEstablecimiento And

        'listaMovimientos.Contains(caja.movimientoCaja) And
        'listaCajasActivas.Contains()

        Dim con = (From caja In HeliosData.documentoCaja
                   Where
                       caja.idEmpresa = be.idEmpresa And
                       caja.idEstablecimiento = be.idEstablecimiento And
                       caja.fechaProceso.Value.Year = be.fechaCierre.Value.Year And
                       caja.fechaProceso.Value.Month = be.fechaCierre.Value.Month And
                       caja.fechaProceso.Value.Day = be.fechaCierre.Value.Day And
                       listaMovimientos.Contains(caja.movimientoCaja)
                   Group caja By caja.idCajaUsuario, caja.movimientoCaja Into g = Group
                   Select
                       idCajaUsuario,
                       movimientoCaja,
                       SumatoriaMovimiento = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).ToList

        GetMovimientosCajaCajeroUnidadNegocioCajeros = New List(Of documentoCaja)

        For Each i In con
            GetMovimientosCajaCajeroUnidadNegocioCajeros.Add(New documentoCaja With
                                         {
                                         .idCajaUsuario = i.idCajaUsuario,
                                         .movimientoCaja = i.movimientoCaja,
                                         .montoSoles = i.SumatoriaMovimiento.GetValueOrDefault
                                         })
        Next

    End Function

    Public Function ListaResumenXEntidadV2(listaidPersona As List(Of Integer), fechaInicio As DateTime, fechaFin As DateTime, strEmpresa As String, idEstablec As Integer, ListaCuentasFinancieras As List(Of Integer)) As documentoCaja

        Dim lista As New List(Of documentoCaja)
        Dim nDocumentoCaja As New documentoCaja
        Dim listaDocCaja As New List(Of documentoCaja)
        Dim tipoventas As New List(Of String)
        tipoventas.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
        tipoventas.Add(TIPO_VENTA.VENTA_AL_TICKET)
        Dim tipoventasElectronicas As New List(Of String)
        tipoventasElectronicas.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        tipoventasElectronicas.Add(TIPO_VENTA.VENTA_AL_TICKET)

        Using ts As New TransactionScope
            Dim consulta = (From d In HeliosData.documentoCaja
                            Where
                                d.idEmpresa = strEmpresa And
                                d.idEstablecimiento = idEstablec And
                                TruncateTime(d.fechaProceso) >= fechaInicio.Date
                            Group d By d.idEmpresa Into g = Group
                            Select
                                OtrasEntradas = (CType((Aggregate t1 In (From a In HeliosData.documentoCaja
                                                                         Where
                                                   TruncateTime(a.fechaProceso) = fechaInicio.Date And
                                                    a.movimientoCaja = "OEC" And
                                                    listaidPersona.Contains(a.idCajaUsuario) And
                                                    ListaCuentasFinancieras.Contains(a.entidadFinanciera) And
                                                    a.estado = 1
                                                                         Select New With
                                                   {
                                                   a.montoSoles
                                                   }) Into Sum(t1.montoSoles)), Decimal?)),
                                OtrasEntradasEspeciales = (CType((Aggregate t1 In
                                                             (From a In HeliosData.documentoCaja
                                                              Where
                                                              TruncateTime(a.fechaProceso) = fechaInicio.Date And
                                                              a.movimientoCaja = MovimientoCaja.Otras_Entradas_Especial And listaidPersona.Contains(a.idCajaUsuario) And ListaCuentasFinancieras.Contains(a.entidadFinanciera) And
                                                              a.estado = 1
                                                              Select New With {
                                          a.montoSoles
                                          }) Into Sum(t1.montoSoles)), Decimal?)),
                                otrasSalidas = (CType((Aggregate t1 In
                                                  (From a In HeliosData.documentoCaja
                                                   Where
                                                       TruncateTime(a.fechaProceso) = fechaInicio.Date And
                                                       a.movimientoCaja = "OSC" And
                                                       listaidPersona.Contains(a.idCajaUsuario) And
                                                       ListaCuentasFinancieras.Contains(a.entidadFinanciera) And
                                                       a.estado = 1
                                                   Select New With {
                                                    a.montoSoles
                                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                               cuentasXpagar = (CType((Aggregate t1 In
                                                 (From a In HeliosData.documentoCaja
                                                  Where
                                                      TruncateTime(a.fechaProceso) = fechaInicio.Date And
                                                      a.movimientoCaja = MovimientoCaja.PagoProveedor And
                                                      listaidPersona.Contains(a.idCajaUsuario) And
                                                      ListaCuentasFinancieras.Contains(a.entidadFinanciera)
                                                  Select New With {
                                                      a.montoSoles
                                                      }) Into Sum(t1.montoSoles)), Decimal?)),
                                cuentasXcobrar = (CType((Aggregate t1 In
                                                             (From a In HeliosData.documentoCaja
                                                              Where
                                                                  TruncateTime(a.fechaProceso) = fechaInicio.Date And
                                                                  a.movimientoCaja = MovimientoCaja.CobroCliente And
                                                                  listaidPersona.Contains(a.idCajaUsuario) And
                                                                  ListaCuentasFinancieras.Contains(a.entidadFinanciera)
                                                              Select New With {
                                                      a.montoSoles
                                                      }) Into Sum(t1.montoSoles)), Decimal?)),
                                VentaPost = (CType((Aggregate t1 In
                                                        (From a In HeliosData.documentoCaja
                                                         Where
                                                             TruncateTime(a.fechaProceso) = fechaInicio.Date And
                                                             tipoventas.Contains(a.movimientoCaja) And
                                                             listaidPersona.Contains(a.idCajaUsuario) And
                                                             ListaCuentasFinancieras.Contains(a.entidadFinanciera)
                                                         Select New With {
                                                             a.montoSoles
                                                             }) Into Sum(t1.montoSoles)), Decimal?)),
                                VentaElectronicas = (CType((Aggregate t1 In
                                                                (From a In HeliosData.documentoCaja
                                                                 Where
                                                                     TruncateTime(a.fechaProceso) = fechaInicio.Date And
                                                                     tipoventasElectronicas.Contains(a.movimientoCaja) And
                                                                     listaidPersona.Contains(a.idCajaUsuario) And
                                                                     ListaCuentasFinancieras.Contains(a.entidadFinanciera)
                                                                 Select New With {
                                                                     a.montoSoles
                                                                     }) Into Sum(t1.montoSoles)), Decimal?)),
                                notaVenta = (CType((Aggregate t1 In
                                                        (From a In HeliosData.documentoCaja
                                                         Where
                                                             TruncateTime(a.fechaProceso) = fechaInicio.Date And
                                                             a.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA And
                                                             listaidPersona.Contains(a.idCajaUsuario) And
                                                             ListaCuentasFinancieras.Contains(a.entidadFinanciera)
                                                         Select New With {
                                                             a.montoSoles
                                                             }) Into Sum(t1.montoSoles)), Decimal?)),
                                Ventaheredada = (CType((Aggregate t1 In
                                                            (From a In HeliosData.documentoCaja
                                                             Where
                                                                 TruncateTime(a.fechaProceso) = fechaInicio.Date And
                                                                 a.movimientoCaja = TIPO_VENTA.VENTA_HEREDAD And
                                                                 listaidPersona.Contains(a.idCajaUsuario) And
                                                                 ListaCuentasFinancieras.Contains(a.entidadFinanciera)
                                                             Select New With {
                                                                 a.montoSoles
                                                                 }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault


            If (Not IsNothing(consulta)) Then
                nDocumentoCaja = New documentoCaja
                With nDocumentoCaja
                    .EntradaDineroEspecial = consulta.OtrasEntradasEspeciales.GetValueOrDefault
                    '.Aporte = consulta.Aporte.GetValueOrDefault
                    .otrasEntradas = consulta.OtrasEntradas.GetValueOrDefault
                    .otrasSalidas = consulta.otrasSalidas.GetValueOrDefault
                    .cuentasXcobrar = consulta.cuentasXcobrar.GetValueOrDefault
                    .cuentasXPagar = consulta.cuentasXpagar.GetValueOrDefault
                    .ventaPost = consulta.VentaPost.GetValueOrDefault
                    .notaVenta = consulta.notaVenta.GetValueOrDefault
                    .VentaHeredadaMN = consulta.Ventaheredada.GetValueOrDefault
                    .VentaElectronicas = consulta.VentaElectronicas.GetValueOrDefault
                    '.anticiposOtorgados = consulta.Otorgados.GetValueOrDefault
                    '.anticiposRecibidos = consulta.Recibidos.GetValueOrDefault
                    '.transferenciaRecibido = consulta.transferenciaRecibido.GetValueOrDefault
                    '.transferenciaOtorgado = consulta.transferenciaOtorgado.GetValueOrDefault
                End With
            End If



            Return nDocumentoCaja

        End Using
    End Function

    'Public Function DocCajaXDocumento(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
    '    Dim Lista As New List(Of documentoCaja)
    '    Dim docCuenta As New documentoCaja

    '    Dim consulta = (From a In HeliosData.documentoCaja
    '                    Group Join b In HeliosData.entidad On CInt(a.codigoProveedor) Equals b.idEntidad
    '                        Into ov = Group
    '                    From x In ov.DefaultIfEmpty()
    '                    Where
    '                        listaPersona.Contains(a.idCajaUsuario) And
    '                        a.movimientoCaja = cajaBE.movimientoCaja And
    '                        a.idEmpresa = cajaBE.idEmpresa And
    '                        a.idEstablecimiento = cajaBE.idEstablecimiento And
    '                        a.entidadFinanciera = cajaBE.entidadFinanciera
    '                    Select
    '                        a.fechaProceso,
    '                        a.tipoDocPago,
    '                        a.numeroDoc,
    '                        a.montoSoles,
    '                        a.montoUsd,
    '                        a.movimientoCaja,
    '                        x.nombreCompleto,
    '                        numero = a.numeroDoc).ToList

    '    For Each item In consulta
    '        docCuenta = New documentoCaja

    '        docCuenta.fechaProceso = item.fechaProceso
    '        docCuenta.tipoDocPago = item.tipoDocPago
    '        docCuenta.numeroDoc = item.numeroDoc
    '        docCuenta.montoSoles = item.montoSoles.GetValueOrDefault
    '        docCuenta.montoUsd = item.montoUsd.GetValueOrDefault
    '        docCuenta.movimientoCaja = item.movimientoCaja
    '        docCuenta.NombreEntidad = item.nombreCompleto
    '        docCuenta.NumeroDocumento = item.numero

    '        Lista.Add(docCuenta)
    '    Next
    '    Return Lista
    'End Function

    Public Function DocCajaXDocumento(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja

        Dim consulta = (From a In HeliosData.documentoCajaDetalle
                        Join c In HeliosData.documentoventaAbarrotes On CInt(a.documentoAfectado) Equals c.idDocumento
                        Where
                            listaPersona.Contains(a.idCajaUsuario) And
                            a.documentoCaja.fechaProceso.Value.Year = cajaBE.fechaProceso.Value.Year And
                            a.documentoCaja.fechaProceso.Value.Month = cajaBE.fechaProceso.Value.Month And
                            a.documentoCaja.fechaProceso.Value.Day = cajaBE.fechaProceso.Value.Day And
                            a.documentoCaja.movimientoCaja = cajaBE.movimientoCaja And
                            a.documentoCaja.idEmpresa = cajaBE.idEmpresa And
                            a.documentoCaja.idEstablecimiento = cajaBE.idEstablecimiento And
                            cajaBE.ListaIDCajas.Contains(a.documentoCaja.entidadFinanciera)
                        Group New With {a.documentoCaja, c} By
                            FechaProceso = CType(a.documentoCaja.fechaProceso, DateTime?),
                            a.documentoCaja.tipoDocPago,
                            c.numeroVenta,
                            a.documentoCaja.movimientoCaja,
                            c.nombrePedido,
                            a.documentoCaja.glosa
                            Into g = Group
                        Select
                            FechaProceso = CType(FechaProceso, DateTime?),
                            tipoDocPago,
                            numeroVenta,
                            movimientoCaja,
                            nombrePedido,
                            totalPagoventaMN = CType(g.Sum(Function(p) p.documentoCaja.montoSoles), Decimal?),
                            totalPagoventaME = CType(g.Sum(Function(p) p.documentoCaja.montoUsd), Decimal?),
                            glosa).ToList

        For Each item In consulta
            docCuenta = New documentoCaja

            docCuenta.fechaProceso = item.FechaProceso
            docCuenta.tipoDocPago = item.tipoDocPago
            docCuenta.montoSoles = item.totalPagoventaMN.GetValueOrDefault
            docCuenta.montoUsd = item.totalPagoventaME.GetValueOrDefault
            docCuenta.movimientoCaja = item.movimientoCaja
            docCuenta.NombreEntidad = item.nombrePedido
            docCuenta.numeroDoc = item.numeroVenta
            docCuenta.glosa = item.glosa

            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function
    Public Function GetMovimientosByFormaPago(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja

        Dim consulta = (From a In HeliosData.documentoCajaDetalle
                        Join c In HeliosData.documentoventaAbarrotes
                            On CInt(a.documentoAfectado) Equals c.idDocumento
                        Join doc In HeliosData.documento
                            On doc.idDocumento Equals a.idDocumento
                        Where
                        listaPersona.Contains(a.idCajaUsuario) And
                            a.documentoCaja.idEmpresa = cajaBE.idEmpresa And
                            a.documentoCaja.idEstablecimiento = cajaBE.idEstablecimiento And
                            cajaBE.ListaIDCajas.Contains(a.documentoCaja.entidadFinanciera) And
                            a.documentoCaja.formapago = cajaBE.IDformapago
                        Group New With {a.documentoCaja, c} By
                            doc.entidad,
                            doc.nrodocEntidad,
                            a.documentoCaja.tipoMovimiento
                            Into g = Group
                        Select
                            entidad,
                            nrodocEntidad,
                            tipoMovimiento,
                            totalMN = CType(g.Sum(Function(p) p.documentoCaja.montoSoles), Decimal?),
                            totalME = CType(g.Sum(Function(p) p.documentoCaja.montoUsd), Decimal?)).ToList

        For Each item In consulta
            docCuenta = New documentoCaja
            docCuenta.NombreEntidad = item.entidad
            docCuenta.numeroDoc = item.nrodocEntidad
            docCuenta.tipoMovimiento = item.tipoMovimiento
            docCuenta.montoSoles = item.totalMN.GetValueOrDefault
            docCuenta.montoUsd = item.totalME.GetValueOrDefault
            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function

    Public Function DocCajaUnitXDocumento(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja

        Dim consulta = (From a In HeliosData.documentoCaja
                        Where
                            a.fechaProceso.Value.Year = cajaBE.fechaProceso.Value.Year And
                            a.fechaProceso.Value.Month = cajaBE.fechaProceso.Value.Month And
                            a.fechaProceso.Value.Day = cajaBE.fechaProceso.Value.Day And
                            listaPersona.Contains(a.idCajaUsuario) And
                            a.movimientoCaja = cajaBE.movimientoCaja And
                            a.idEmpresa = cajaBE.idEmpresa And
                            a.idEstablecimiento = cajaBE.idEstablecimiento And
                            cajaBE.ListaIDCajas.Contains(a.entidadFinanciera) And
                            a.estado = 1
                        Select
                            a.fechaProceso,
                            a.tipoDocPago,
                            a.numeroDoc,
                            a.montoSoles,
                            a.montoUsd,
                            a.movimientoCaja,
                            a.glosa,
                            a.tipoPersona,
                            a.idPersonal,
                            numero = a.numeroDoc).ToList

        For Each item In consulta
            docCuenta = New documentoCaja

            docCuenta.fechaProceso = item.fechaProceso
            docCuenta.tipoDocPago = item.tipoDocPago
            docCuenta.montoSoles = item.montoSoles.GetValueOrDefault
            docCuenta.montoUsd = item.montoUsd.GetValueOrDefault
            docCuenta.movimientoCaja = item.movimientoCaja
            docCuenta.numeroDoc = item.numeroDoc
            docCuenta.idPersonal = item.idPersonal
            docCuenta.tipoPersona = item.tipoPersona
            docCuenta.glosa = item.glosa

            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function

    Public Function DocCajaXDocumentoVentas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja
        Dim tipoVentas As New List(Of String)
        tipoVentas.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
        tipoVentas.Add(TIPO_VENTA.VENTA_AL_TICKET)

        Dim consulta = (From a In HeliosData.documentoCajaDetalle
                        Join c In HeliosData.documentoventaAbarrotes On CInt(a.documentoAfectado) Equals c.idDocumento
                        Where
                            a.documentoCaja.fechaProceso.Value.Year = cajaBE.fechaProceso.Value.Year And
                            a.documentoCaja.fechaProceso.Value.Month = cajaBE.fechaProceso.Value.Month And
                            a.documentoCaja.fechaProceso.Value.Day = cajaBE.fechaProceso.Value.Day And
                            listaPersona.Contains(a.documentoCaja.idCajaUsuario) And
                            tipoVentas.Contains(a.documentoCaja.movimientoCaja) And
                            a.documentoCaja.idEmpresa = cajaBE.idEmpresa And
                            a.documentoCaja.idEstablecimiento = cajaBE.idEstablecimiento And
                            cajaBE.ListaIDCajas.Contains(a.documentoCaja.entidadFinanciera)
                        Group New With {a.documentoCaja, c} By
                            FechaProceso = CType(a.documentoCaja.fechaProceso, DateTime?),
                            a.documentoCaja.tipoDocPago,
                            c.serieVenta,
                            c.numeroVenta,
                            a.documentoCaja.movimientoCaja,
                            c.nombrePedido,
                            a.documentoCaja.glosa,
                            c.idDocumento
                            Into g = Group
                        Select
                            FechaProceso = CType(FechaProceso, DateTime?),
                            tipoDocPago,
                            serieVenta,
                            numeroVenta,
                            totalPagoventaMN = CType(g.Sum(Function(p) p.documentoCaja.montoSoles), Decimal?),
                            totalPagoventaME = CType(g.Sum(Function(p) p.documentoCaja.montoUsd), Decimal?),
                            movimientoCaja,
                            nombrePedido,
                            idDocumento,
                            glosa).ToList

        For Each item In consulta
            docCuenta = New documentoCaja
            docCuenta.idDocumento = item.idDocumento
            docCuenta.fechaProceso = item.FechaProceso
            docCuenta.tipoDocPago = item.tipoDocPago
            docCuenta.numeroDoc = String.Format("{0} - {1}", item.serieVenta, item.numeroVenta)
            docCuenta.montoSoles = item.totalPagoventaMN.GetValueOrDefault
            docCuenta.montoUsd = item.totalPagoventaME.GetValueOrDefault
            docCuenta.movimientoCaja = item.movimientoCaja
            docCuenta.NombreEntidad = item.nombrePedido
            docCuenta.glosa = item.glosa

            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function

    Public Function DocCajaXDocumentoVentasElectronicas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim Lista As New List(Of documentoCaja)
        Dim docCuenta As New documentoCaja
        Dim tipoVentas As New List(Of String)
        tipoVentas.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        tipoVentas.Add(TIPO_VENTA.VENTA_AL_TICKET)

        Dim consulta = (From a In HeliosData.documentoCajaDetalle
                        Join c In HeliosData.documentoventaAbarrotes On CInt(a.documentoAfectado) Equals c.idDocumento
                        Where
                            a.documentoCaja.fechaProceso.Value.Year = cajaBE.fechaProceso.Value.Year And
                            a.documentoCaja.fechaProceso.Value.Month = cajaBE.fechaProceso.Value.Month And
                            a.documentoCaja.fechaProceso.Value.Day = cajaBE.fechaProceso.Value.Day And
                            listaPersona.Contains(a.documentoCaja.idCajaUsuario) And
                            tipoVentas.Contains(a.documentoCaja.movimientoCaja) And
                            a.documentoCaja.idEmpresa = cajaBE.idEmpresa And
                            a.documentoCaja.idEstablecimiento = cajaBE.idEstablecimiento And
                            cajaBE.ListaIDCajas.Contains(a.documentoCaja.entidadFinanciera)
                        Group New With {a.documentoCaja, c} By
                            FechaProceso = CType(a.documentoCaja.fechaProceso, DateTime?),
                            a.documentoCaja.tipoDocPago,
                            c.numeroVenta,
                            a.documentoCaja.movimientoCaja,
                            c.nombrePedido,
                            a.documentoCaja.glosa
                            Into g = Group
                        Select
                            FechaProceso = CType(FechaProceso, DateTime?),
                            tipoDocPago,
                            numeroVenta,
                            totalPagoventaMN = CType(g.Sum(Function(p) p.documentoCaja.montoSoles), Decimal?),
                            totalPagoventaME = CType(g.Sum(Function(p) p.documentoCaja.montoUsd), Decimal?),
                            movimientoCaja,
                            nombrePedido,
                            glosa).ToList

        For Each item In consulta
            docCuenta = New documentoCaja

            docCuenta.fechaProceso = item.FechaProceso
            docCuenta.tipoDocPago = item.tipoDocPago
            docCuenta.numeroDoc = item.numeroVenta
            docCuenta.montoSoles = item.totalPagoventaMN.GetValueOrDefault
            docCuenta.montoUsd = item.totalPagoventaME.GetValueOrDefault
            docCuenta.movimientoCaja = item.movimientoCaja
            docCuenta.NombreEntidad = item.nombrePedido
            docCuenta.glosa = item.glosa

            Lista.Add(docCuenta)
        Next
        Return Lista
    End Function


    'Public Function DocCajaXDocumentoVentas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
    '    Dim Lista As New List(Of documentoCaja)
    '    Dim docCuenta As New documentoCaja
    '    Dim tipoVentas As New List(Of String)
    '    tipoVentas.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
    '    tipoVentas.Add(TIPO_VENTA.VENTA_AL_TICKET)

    '    Dim consulta = (From a In HeliosData.documentoCaja
    '                    Join b In HeliosData.entidad On CInt(a.codigoProveedor) Equals b.idEntidad
    '                    Where
    '                        listaPersona.Contains(a.idCajaUsuario) And
    '                        tipoVentas.Contains(a.movimientoCaja) And
    '                        a.idEmpresa = cajaBE.idEmpresa And
    '                        a.idEstablecimiento = cajaBE.idEstablecimiento And
    '                        a.entidadFinanciera = cajaBE.entidadFinanciera
    '                    Select
    '                        a.fechaProceso,
    '                        a.tipoDocPago,
    '                        a.numeroDoc,
    '                        a.montoSoles,
    '                        a.montoUsd,
    '                        a.movimientoCaja,
    '                        b.nombreCompleto,
    '                        numero = a.numeroDoc).ToList

    '    For Each item In consulta
    '        docCuenta = New documentoCaja

    '        docCuenta.fechaProceso = item.fechaProceso
    '        docCuenta.tipoDocPago = item.tipoDocPago
    '        docCuenta.numeroDoc = item.numeroDoc
    '        docCuenta.montoSoles = item.montoSoles.GetValueOrDefault
    '        docCuenta.montoUsd = item.montoUsd.GetValueOrDefault
    '        docCuenta.movimientoCaja = item.movimientoCaja
    '        docCuenta.NombreEntidad = item.nombreCompleto
    '        docCuenta.NumeroDocumento = item.numero

    '        Lista.Add(docCuenta)
    '    Next
    '    Return Lista
    'End Function

    Public Function DocCajaXResumenXID(cajaBE As documentoCaja) As documentoCaja
        Dim nDocumentoCaja As New documentoCaja

        Dim consulta = (From d In HeliosData.documentoCaja
                        Where
                                                    d.idEmpresa = cajaBE.idEmpresa And
                                                d.idEstablecimiento = cajaBE.idEstablecimiento
                        Group d By d.idEmpresa Into g = Group
                        Select
                                     EGRESOS = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.tipoMovimiento = "PG" And
                                         (a.idCajaUsuario) = cajaBE.idCajaUsuario
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?)),
                                        INGRESOS = (CType((Aggregate t1 In
                                    (From a In HeliosData.documentoCaja
                                     Where
                                        a.tipoMovimiento = "DC" And
                                         (a.idCajaUsuario) = cajaBE.idCajaUsuario
                                     Select New With {
                                        a.montoSoles
                                    }) Into Sum(t1.montoSoles)), Decimal?))).FirstOrDefault

        If (Not IsNothing(consulta)) Then
            nDocumentoCaja = New documentoCaja
            With nDocumentoCaja

                .otrasEntradas = consulta.INGRESOS.GetValueOrDefault
                .otrasSalidas = consulta.EGRESOS.GetValueOrDefault

            End With
        End If


        Return nDocumentoCaja
    End Function

End Class

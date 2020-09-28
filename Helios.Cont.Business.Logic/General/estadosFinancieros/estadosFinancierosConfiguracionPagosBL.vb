Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class estadosFinancierosConfiguracionPagosBL
    Inherits BaseBL

    Public Function GetPaySaldoCaja(Be As estadosFinancierosConfiguracionPagos) As estadosFinancierosConfiguracionPagos

        Dim fechaActual = New Date(Be.fecha.Year, Be.fecha.Month, Be.fecha.Day) '1)
        Dim fechaAnterior = fechaActual.AddMonths(-1)

        Dim periodo = String.Format("{0:00}", Be.fecha.Month) & "/" & Be.fecha.Year


        Dim consuta = (From n In HeliosData.estadosFinancierosConfiguracionPagos
                       Join Tbl In HeliosData.tabladetalle
                           On n.tipo Equals Tbl.codigoDetalle
                       Where
                           Tbl.idtabla = 1 And
                           n.idEmpresa = Be.idEmpresa And
                           n.idEstablecimiento = Be.idEstablecimiento And
                           n.identidad = Be.identidad
                       Select
                            IDFormaPago = Tbl.codigoDetalle,
                           FormaPago = Tbl.descripcion,
                           idConfiguracion = n.idConfiguracion,
                           idEmpresa = n.idEmpresa,
                           idEstablecimiento = n.idEstablecimiento,
                           identidad = n.identidad,
                           moneda = n.moneda,
                           tipo = n.tipo,
                           fechacea = n.fecha,
                           entidad = n.entidad,
                           SaldoAnterior = (From DocumentoCaja In HeliosData.cierreCaja
                                            Where
                                            DocumentoCaja.idEntidadFinanciera = n.identidad And
                                            DocumentoCaja.periodo = periodo
                                            Select DocumentoCaja.montoMN).FirstOrDefault,
                           cobros = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinanciera = n.identidad And
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
                                         DocumentoCaja.entidadFinanciera = n.identidad And
                                         DocumentoCaja.tipoMovimiento = "PG" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?))
                       ).FirstOrDefault

        ' GetPaySaldoCaja = New estadosFinancierosConfiguracionPagos

        GetPaySaldoCaja = (New estadosFinancierosConfiguracionPagos With
                                    {
                                    .IDFormaPago = consuta.IDFormaPago,
                                    .FormaPago = consuta.FormaPago,
                                    .idConfiguracion = consuta.idConfiguracion,
                                    .idEmpresa = consuta.idEmpresa,
                                    .idEstablecimiento = consuta.idEstablecimiento,
                                    .identidad = consuta.identidad,
                                    .moneda = consuta.moneda,
                                    .tipo = consuta.tipo,
                                    .fecha = consuta.fechacea,
                                    .entidad = consuta.entidad,
                                    .MontoCaja = consuta.SaldoAnterior.GetValueOrDefault + consuta.cobros.GetValueOrDefault - consuta.pagos.GetValueOrDefault
                                    })


    End Function

    Public Function GetConfigurationPaySaldoCajero(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)

        Dim fechaActual = New Date(Be.fecha.Year, Be.fecha.Month, Be.fecha.Day) '1)
        Dim fechaAnterior = fechaActual.AddMonths(-1)

        Dim periodo = String.Format("{0:00}", Be.fecha.Month) & "/" & Be.fecha.Year


        Dim consuta = (From n In HeliosData.estadosFinancierosConfiguracionPagos
                       Join Cajas In HeliosData.cajaUsuariodetalle
                           On Cajas.idEntidad Equals n.identidad And
                      n.idConfiguracion Equals Cajas.idConfiguracion
                       Join Tbl In HeliosData.tabladetalle
                       On n.tipo Equals Tbl.codigoDetalle
                       Where
                           Tbl.idtabla = 1 And
                           n.idEmpresa = Be.idEmpresa And
                           n.idEstablecimiento = Be.idEstablecimiento And
                           n.tipoCaja = Be.tipoCaja And
                           Cajas.idcajaUsuario = Be.IDCaja
                       Select
                            IDFormaPago = Tbl.codigoDetalle,
                           FormaPago = Tbl.descripcion,
                           idConfiguracion = n.idConfiguracion,
                           idEmpresa = n.idEmpresa,
                           idEstablecimiento = n.idEstablecimiento,
                           identidad = n.identidad,
                           moneda = n.moneda,
                           tipo = n.tipo,
                           fechacea = n.fecha,
                           entidad = n.entidad,
                           SaldoAnterior = (From DocumentoCaja In HeliosData.cierreCaja
                                            Where
                                            DocumentoCaja.idEntidadFinanciera = n.identidad And
                                            DocumentoCaja.periodo = periodo
                                            Select DocumentoCaja.montoMN).FirstOrDefault,
                           SaldoAnteriorME = (From DocumentoCaja In HeliosData.cierreCaja
                                              Where
                                            DocumentoCaja.idEntidadFinanciera = n.identidad And
                                            DocumentoCaja.periodo = periodo
                                              Select DocumentoCaja.montoME).FirstOrDefault,
                           cobrosMN = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinanciera = n.identidad And
                                         DocumentoCaja.tipoMovimiento = "DC" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day _
                                         And DocumentoCaja.idCajaUsuario = Be.IDCaja
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                           cobrosME = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinanciera = n.identidad And
                                         DocumentoCaja.tipoMovimiento = "DC" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day _
                                         And DocumentoCaja.idCajaUsuario = Be.IDCaja
                                     Select New With {
                                             DocumentoCaja.montoUsd
                                         }) Into Sum(t1.montoUsd)), Decimal?)),
                            pagosMN = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinanciera = n.identidad And
                                         DocumentoCaja.tipoMovimiento = "PG" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day _
                                         And DocumentoCaja.idCajaUsuario = Be.IDCaja
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                           pagosME = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinanciera = n.identidad And
                                         DocumentoCaja.tipoMovimiento = "PG" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProceso.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProceso.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProceso.Value.Day <= fechaActual.Day _
                                         And DocumentoCaja.idCajaUsuario = Be.IDCaja
                                     Select New With {
                                             DocumentoCaja.montoUsd
                                         }) Into Sum(t1.montoUsd)), Decimal?))
                       ).ToList




        GetConfigurationPaySaldoCajero = New List(Of estadosFinancierosConfiguracionPagos)
        For Each i In consuta
            GetConfigurationPaySaldoCajero.Add(New estadosFinancierosConfiguracionPagos With
                                    {
                                    .IDFormaPago = i.IDFormaPago,
                                    .FormaPago = i.FormaPago,
                                    .idConfiguracion = i.idConfiguracion,
                                    .idEmpresa = i.idEmpresa,
                                    .idEstablecimiento = i.idEstablecimiento,
                                    .identidad = i.identidad,
                                    .moneda = i.moneda,
                                    .tipo = i.tipo,
                                    .fecha = i.fechacea,
                                    .entidad = i.entidad,
                                    .MontoCaja = i.SaldoAnterior.GetValueOrDefault + i.cobrosMN.GetValueOrDefault - i.pagosMN.GetValueOrDefault,
                                    .MontoCajaME = i.SaldoAnteriorME.GetValueOrDefault + i.cobrosME.GetValueOrDefault - i.pagosME.GetValueOrDefault
                                    })
        Next

    End Function

    Public Function GetConfigurationPaySaldo(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)

        Dim fechaActual = New Date(Be.fecha.Year, Be.fecha.Month, Be.fecha.Day) '1)
        Dim fechaAnterior = fechaActual.AddMonths(-1)

        Dim periodo = String.Format("{0:00}", Be.fecha.Month) & "/" & Be.fecha.Year


        Dim consuta = (From n In HeliosData.estadosFinancierosConfiguracionPagos
                       Join Cajas In HeliosData.cajaUsuariodetalle
                           On Cajas.idEntidad Equals n.identidad And
                      n.idConfiguracion Equals Cajas.idConfiguracion
                       Join Tbl In HeliosData.tabladetalle
                       On n.tipo Equals Tbl.codigoDetalle
                       Where
                           Tbl.idtabla = 1 And
                           n.idEmpresa = Be.idEmpresa And
                           n.idEstablecimiento = Be.idEstablecimiento And
                           Cajas.idcajaUsuario = Be.IDCaja
                       Select
                            IDFormaPago = Tbl.codigoDetalle,
                           FormaPago = Tbl.descripcion,
                           idConfiguracion = n.idConfiguracion,
                           idEmpresa = n.idEmpresa,
                           idEstablecimiento = n.idEstablecimiento,
                           identidad = n.identidad,
                           moneda = n.moneda,
                           tipo = n.tipo,
                           fechacea = n.fecha,
                           entidad = n.entidad,
                           SaldoAnterior = (From DocumentoCaja In HeliosData.cierreCaja
                                            Where
                                            DocumentoCaja.idEntidadFinanciera = n.identidad And
                                            DocumentoCaja.periodo = periodo
                                            Select DocumentoCaja.montoMN).FirstOrDefault,
                           SaldoAnteriorME = (From DocumentoCaja In HeliosData.cierreCaja
                                              Where
                                            DocumentoCaja.idEntidadFinanciera = n.identidad And
                                            DocumentoCaja.periodo = periodo
                                              Select DocumentoCaja.montoME).FirstOrDefault,
                           cobrosMN = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinancieraDestino = n.identidad And
                                         DocumentoCaja.tipoMovimiento = "DC" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                           cobrosME = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinancieraDestino = n.identidad And
                                         DocumentoCaja.tipoMovimiento = "DC" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoUsd
                                         }) Into Sum(t1.montoUsd)), Decimal?)),
                            pagosMN = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinancieraDestino = n.identidad And
                                         DocumentoCaja.tipoMovimiento = "PG" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoSoles
                                         }) Into Sum(t1.montoSoles)), Decimal?)),
                           pagosME = (CType((Aggregate t1 In
                                    (From DocumentoCaja In HeliosData.documentoCaja
                                     Where
                                         DocumentoCaja.entidadFinancieraDestino = n.identidad And
                                         DocumentoCaja.tipoMovimiento = "PG" _
                                         And Not DocumentoCaja.tipoOperacion = "9906" _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Year = fechaActual.Year _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Month = fechaActual.Month _
                                         And DocumentoCaja.fechaProcesoDestino.Value.Day <= fechaActual.Day
                                     Select New With {
                                             DocumentoCaja.montoUsd
                                         }) Into Sum(t1.montoUsd)), Decimal?))
                       ).ToList




        GetConfigurationPaySaldo = New List(Of estadosFinancierosConfiguracionPagos)
        For Each i In consuta
            GetConfigurationPaySaldo.Add(New estadosFinancierosConfiguracionPagos With
                                    {
                                    .IDFormaPago = i.IDFormaPago,
                                    .FormaPago = i.FormaPago,
                                    .idConfiguracion = i.idConfiguracion,
                                    .idEmpresa = i.idEmpresa,
                                    .idEstablecimiento = i.idEstablecimiento,
                                    .identidad = i.identidad,
                                    .moneda = i.moneda,
                                    .tipo = i.tipo,
                                    .fecha = i.fechacea,
                                    .entidad = i.entidad,
                                    .MontoCaja = i.SaldoAnterior.GetValueOrDefault + i.cobrosMN.GetValueOrDefault - i.pagosMN.GetValueOrDefault,
                                    .MontoCajaME = i.SaldoAnteriorME.GetValueOrDefault + i.cobrosME.GetValueOrDefault - i.pagosME.GetValueOrDefault
                                    })
        Next

    End Function

    Public Function ConfiguracionTieneCajasActivas(idConfiguracion As Integer) As Boolean
        Dim con = (From c In HeliosData.cajaUsuario
                   Join cd In HeliosData.cajaUsuariodetalle
                      On cd.idcajaUsuario Equals c.idcajaUsuario
                   Where cd.idConfiguracion = idConfiguracion And c.estadoCaja = "A").Count

        If con > 0 Then
            ConfiguracionTieneCajasActivas = True
        Else
            ConfiguracionTieneCajasActivas = False
        End If
    End Function

    Public Sub GrabarConfiguracionList(lista As List(Of estadosFinancierosConfiguracionPagos))
        Using ts As New TransactionScope
            EliminarConfig(lista(0).idEmpresa, lista(0).idEstablecimiento)
            HeliosData.estadosFinancierosConfiguracionPagos.AddRange(lista)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarConfig(idEmpresa As String, IDEstablecimiento As Integer)
        Using ts As New TransactionScope
            Dim obj = HeliosData.estadosFinancierosConfiguracionPagos.Where(Function(o) o.idEmpresa = idEmpresa And o.idEstablecimiento = IDEstablecimiento).ToList
            HeliosData.estadosFinancierosConfiguracionPagos.RemoveRange(obj)
            'For Each i In obj
            '    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
            'Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetConfigurationPay(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)

        Dim consuta = (From n In HeliosData.estadosFinancierosConfiguracionPagos
                       Join Tbl In HeliosData.tabladetalle
                           On n.tipo Equals Tbl.codigoDetalle
                       Where
                           Tbl.idtabla = 1 And
                           n.idEmpresa = Be.idEmpresa And
                           n.idEstablecimiento = Be.idEstablecimiento
                       ).ToList

        GetConfigurationPay = New List(Of estadosFinancierosConfiguracionPagos)
        For Each i In consuta
            GetConfigurationPay.Add(New estadosFinancierosConfiguracionPagos With
                                    {
                                    .IDFormaPago = i.Tbl.codigoDetalle,
                                    .FormaPago = i.Tbl.descripcion,
                                    .idConfiguracion = i.n.idConfiguracion,
                                    .idEmpresa = i.n.idEmpresa,
                                    .idEstablecimiento = i.n.idEstablecimiento,
                                    .identidad = i.n.identidad,
                                    .moneda = i.n.moneda,
                                    .tipo = i.n.tipo,
                                    .fecha = i.n.fecha,
                                    .entidad = i.n.entidad,
                                    .tipoCaja = i.n.tipoCaja
                                    })
        Next

    End Function

    Public Function BuscarConfiguracionCreada(idemp As String, idestab As String, idconf As Integer) As Integer

        Dim consulta = (From i In HeliosData.estadosFinancierosConfiguracionPagos
                        Join h In HeliosData.cajaUsuariodetalle On i.idConfiguracion Equals h.idConfiguracion
                        Where i.idEmpresa = idemp And i.idEstablecimiento = idestab And i.idConfiguracion = idconf).FirstOrDefault


        If consulta IsNot Nothing Then

            Return consulta.i.idConfiguracion
        Else
            Return 0
        End If


    End Function


    Public Function GetConfigurationPayBancarios(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)


        Dim con = From n In HeliosData.cajaUsuariodetalle
                  Join est In HeliosData.estadosFinancierosConfiguracionPagos
                      On est.identidad Equals n.idEntidad And
                      n.idConfiguracion Equals est.idConfiguracion
                  Join Tbl In HeliosData.tabladetalle
                      On est.tipo Equals Tbl.codigoDetalle
                  Where
                      Tbl.idtabla = 1 And
                      n.idcajaUsuario = Be.IDCaja And
                      est.identidad = Be.identidad And
                      est.tipoCaja = Be.tipoCaja


        GetConfigurationPayBancarios = New List(Of estadosFinancierosConfiguracionPagos)
        For Each i In con
            GetConfigurationPayBancarios.Add(New estadosFinancierosConfiguracionPagos With
                                    {
                                    .IDFormaPago = i.Tbl.codigoDetalle,
                                    .FormaPago = i.Tbl.descripcion,
                                    .idConfiguracion = i.n.idConfiguracion,
                                    .idEmpresa = i.est.idEmpresa,
                                    .idEstablecimiento = i.est.idEstablecimiento,
                                    .identidad = i.n.idEntidad,
                                    .moneda = i.est.moneda,
                                    .tipo = i.est.tipo,
                                    .fecha = i.est.fecha,
                                    .entidad = i.est.entidad,
                                    .IDCaja = i.n.idcajaUsuario,
                                    .tipoCaja = i.est.tipoCaja
                                    })
        Next

    End Function


    Public Function GetConfigurationPayCaja(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)
        'Dim consuta = (From n In HeliosData.estadosFinancierosConfiguracionPagos
        '               Join Tbl In HeliosData.tabladetalle
        '                       On n.tipo Equals Tbl.codigoDetalle
        '               Join cajaUsuario In HeliosData.cajaUsuariodetalle
        '                   On cajaUsuario.idConfiguracion Equals n.idConfiguracion
        '               Where
        '                   n.idEmpresa = Be.idEmpresa And
        '                   n.idEstablecimiento = Be.idEstablecimiento And
        '                   Tbl.idtabla = 1 And
        '                   cajaUsuario.idcajaUsuario = Be.IDCaja
        '               ).ToList

        Dim con = From n In HeliosData.cajaUsuariodetalle
                  Join est In HeliosData.estadosFinancierosConfiguracionPagos
                      On est.identidad Equals n.idEntidad And
                      n.idConfiguracion Equals est.idConfiguracion
                  Join Tbl In HeliosData.tabladetalle
                      On est.tipo Equals Tbl.codigoDetalle
                  Where
                      Tbl.idtabla = 1 And
                      n.idcajaUsuario = Be.IDCaja


        GetConfigurationPayCaja = New List(Of estadosFinancierosConfiguracionPagos)
        For Each i In con
            GetConfigurationPayCaja.Add(New estadosFinancierosConfiguracionPagos With
                                    {
                                    .IDFormaPago = i.Tbl.codigoDetalle,
                                    .FormaPago = i.Tbl.descripcion,
                                    .idConfiguracion = i.n.idConfiguracion,
                                    .idEmpresa = i.est.idEmpresa,
                                    .idEstablecimiento = i.est.idEstablecimiento,
                                    .identidad = i.n.idEntidad,
                                    .moneda = i.est.moneda,
                                    .tipo = i.est.tipo,
                                    .fecha = i.est.fecha,
                                    .entidad = i.est.entidad,
                                    .IDCaja = i.n.idcajaUsuario,
                                    .tipoCaja = i.est.tipoCaja
                                    })
        Next

    End Function

End Class

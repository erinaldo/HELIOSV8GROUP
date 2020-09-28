Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class CajaUsuarioBL
    Inherits BaseBL

    Public Function ListBoxClosedPendingUser(be As cajaUsuario) As Integer
        Try
            Dim MyList As New List(Of cajaUsuario)

            Dim query = (From i In HeliosData.cajaUsuario
                         Where i.estadoCaja = "C" And i.tipoCaja = "POS" And i.idPadre = 0 And
                             i.idPersona = be.idPersona And i.idEmpresa = be.idEmpresa And
                             i.idEstablecimiento = be.idEstablecimiento).Count
            Return query

        Catch ex As Exception

        End Try

    End Function


    Public Function ListPendingForUserWithImport(be As cajaUsuario) As List(Of cajaUsuario)
        Try
            Dim MyList As New List(Of cajaUsuario)

            Dim query = (From i In HeliosData.cajaUsuario
                         Where i.estadoCaja = "C" And i.tipoCaja = "POS" And i.idPadre = 0 And
                               i.idEmpresa = be.idEmpresa And
                             i.idEstablecimiento = be.idEstablecimiento And
                             i.idPersona = be.idPersona
                         Select
                                 i.idcajaUsuario,
                             i.idPersona,
                             i.namepc,
                             i.fechaRegistro,
                             i.fechaCierre,
                                 CobroPen = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "DC" And
                                              d.moneda = "1" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoSoles
                                            }) Into Sum(t1.montoSoles)), Decimal?)),
                             PagoPen = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "PG" And
                                              d.moneda = "1" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoSoles
                                            }) Into Sum(t1.montoSoles)), Decimal?)),
                             CobroUsd = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "DC" And
                                              d.moneda = "2" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoUsd
                                            }) Into Sum(t1.montoUsd)), Decimal?)),
                             PagoUsd = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "PG" And
                                              d.moneda = "2" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoUsd
                                            }) Into Sum(t1.montoUsd)), Decimal?))
                                                                     ).ToList

            For Each i In query
                Dim obj As New cajaUsuario
                obj.idPersona = i.idPersona
                obj.idcajaUsuario = i.idcajaUsuario
                obj.namepc = i.namepc
                obj.fechaRegistro = i.fechaRegistro
                obj.fechaCierre = i.fechaCierre
                obj.montoMN = i.CobroPen.GetValueOrDefault - i.PagoPen.GetValueOrDefault
                obj.montoME = i.CobroUsd.GetValueOrDefault - i.PagoUsd.GetValueOrDefault

                MyList.Add(obj)
            Next


            Return MyList

        Catch ex As Exception

        End Try

    End Function

    Public Function ListBoxClosedPendingCount(be As cajaUsuario) As Integer
        Try
            Dim MyList As New List(Of cajaUsuario)

            Dim query = (From i In HeliosData.cajaUsuario
                         Where i.estadoCaja = "C" And i.tipoCaja = "POS" And i.idPadre = 0 And
                               i.idEmpresa = be.idEmpresa And
                             i.idEstablecimiento = be.idEstablecimiento).Count


            Return query

        Catch ex As Exception

        End Try

    End Function

    Public Function ListBoxClosedPending(be As cajaUsuario) As List(Of cajaUsuario)
        Try
            Dim MyList As New List(Of cajaUsuario)

            Dim query = (From i In HeliosData.cajaUsuario
                         Where i.estadoCaja = "C" And i.tipoCaja = "POS" And i.idPadre = 0 And
                               i.idEmpresa = be.idEmpresa And
                             i.idEstablecimiento = be.idEstablecimiento
                         Select
                                 i.idcajaUsuario,
                             i.idPersona,
                             i.namepc,
                             i.fechaRegistro,
                                 CobroPen = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "DC" And
                                              d.moneda = "1" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoSoles
                                            }) Into Sum(t1.montoSoles)), Decimal?)),
                             PagoPen = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "PG" And
                                              d.moneda = "1" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoSoles
                                            }) Into Sum(t1.montoSoles)), Decimal?)),
                             CobroUsd = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "DC" And
                                              d.moneda = "2" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoUsd
                                            }) Into Sum(t1.montoUsd)), Decimal?)),
                             PagoUsd = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "PG" And
                                              d.moneda = "2" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoUsd
                                            }) Into Sum(t1.montoUsd)), Decimal?))
                                                                     ).ToList

            For Each i In query
                Dim obj As New cajaUsuario
                obj.idPersona = i.idPersona
                obj.idcajaUsuario = i.idcajaUsuario
                obj.namepc = i.namepc
                obj.fechaRegistro = i.fechaRegistro
                obj.montoMN = i.CobroPen.GetValueOrDefault - i.PagoPen.GetValueOrDefault
                obj.montoME = i.CobroUsd.GetValueOrDefault - i.PagoUsd.GetValueOrDefault

                MyList.Add(obj)
            Next


            Return MyList

        Catch ex As Exception

        End Try

    End Function


    Public Function ListBoxOpen(be As cajaUsuario) As List(Of cajaUsuario)
        Try
            Dim MyList As New List(Of cajaUsuario)

            Dim query = (From i In HeliosData.cajaUsuario
                         Where i.estadoCaja = "A" And i.tipoCaja = "POS" And
                               i.idEmpresa = be.idEmpresa And
                             i.idEstablecimiento = be.idEstablecimiento
                         Select
                                 i.idcajaUsuario,
                             i.idPersona,
                             i.namepc,
                             i.fechaRegistro,
                                 CobroPen = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "DC" And
                                              d.moneda = "1" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoSoles
                                            }) Into Sum(t1.montoSoles)), Decimal?)),
                             PagoPen = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "PG" And
                                              d.moneda = "1" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoSoles
                                            }) Into Sum(t1.montoSoles)), Decimal?)),
                             CobroUsd = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "DC" And
                                              d.moneda = "2" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoUsd
                                            }) Into Sum(t1.montoUsd)), Decimal?)),
                             PagoUsd = (CType((Aggregate t1 In
                                            (From d In HeliosData.documentoCaja
                                             Where
                                              d.idCajaUsuario = i.idcajaUsuario And
                                              d.tipoMovimiento = "PG" And
                                              d.moneda = "2" And
                                                 d.idEmpresa = be.idEmpresa And
                                                 d.idEstablecimiento = be.idEstablecimiento
                                             Select New With {
                                              d.montoUsd
                                            }) Into Sum(t1.montoUsd)), Decimal?))
                                                                     ).ToList

            For Each i In query
                Dim obj As New cajaUsuario
                obj.idPersona = i.idPersona
                obj.idcajaUsuario = i.idcajaUsuario
                obj.namepc = i.namepc
                obj.fechaRegistro = i.fechaRegistro
                obj.montoMN = i.CobroPen.GetValueOrDefault - i.PagoPen.GetValueOrDefault
                obj.montoME = i.CobroUsd.GetValueOrDefault - i.PagoUsd.GetValueOrDefault

                MyList.Add(obj)
            Next


            Return MyList

        Catch ex As Exception

        End Try

    End Function


    Public Function CajaUsuarioPeriodoSinRecocimiento(be As cajaUsuario) As List(Of cajaUsuario)
        Dim listaDetalle As List(Of cajaUsuariodetalle)
        Dim obj As cajaUsuario
        Dim con = HeliosData.cajaUsuario _
            .Include("cajaUsuariodetalle") _
            .Where(Function(o) o.idEmpresa = be.idEmpresa And
            o.idEstablecimiento = be.idEstablecimiento And
            o.fechaRegistro.Value.Year = be.fechaRegistro.Value.Year And
            o.fechaRegistro.Value.Month = be.fechaRegistro.Value.Month And
            o.idPersona = be.idPersona And o.idPadre = 0 And o.estadoCaja = "C")

        CajaUsuarioPeriodoSinRecocimiento = New List(Of cajaUsuario)
        For Each i In con

            obj = New cajaUsuario With
            {
            .idcajaUsuario = i.idcajaUsuario,
            .idPersona = i.idPersona,
            .claveIngreso = i.claveIngreso,
            .documentoApertura = i.documentoApertura,
            .documentoCierre = i.documentoCierre,
            .idCajaOrigen = i.idCajaOrigen,
            .idCajaDestino = i.idCajaDestino,
            .idCajaCierre = i.idCajaCierre,
            .fechaRegistro = i.fechaRegistro,
            .fechaCierre = i.fechaCierre,
            .moneda = i.moneda,
            .tipoCambio = i.tipoCambio,
            .fondoMN = i.fondoMN,
            .fondoME = i.fondoME,
            .ingresoAdicMN = i.ingresoAdicMN,
            .ingresoAdicME = i.ingresoAdicME,
            .otrosIngresosME = i.otrosIngresosME,
            .otrosIngresosMN = i.otrosIngresosMN,
            .otrosEgresosMN = i.otrosEgresosMN,
            .otrosEgresosME = i.otrosEgresosME,
            .estadoCaja = i.estadoCaja,
            .enUso = i.enUso,
            .idPadre = i.idPadre
            }


            listaDetalle = New List(Of cajaUsuariodetalle)
            For Each det In i.cajaUsuariodetalle.ToList
                listaDetalle.Add(New cajaUsuariodetalle With
                                 {
                                 .idcajaUsuario = det.idcajaUsuario,
                                 .secuencia = det.secuencia,
                                 .idEntidad = det.idEntidad,
                                 .moneda = det.moneda,
                                 .importeMN = det.importeMN,
                                 .idConfiguracion = det.idConfiguracion
                                 })
            Next
            obj.cajaUsuariodetalle = listaDetalle
            CajaUsuarioPeriodoSinRecocimiento.Add(obj)
        Next
    End Function

    '.Include("cajaUsuarioDineroEntregado")
    Public Function CajaUsuarioSelPeriodo(be As cajaUsuario) As List(Of cajaUsuario)
        Dim listaDetalle As List(Of cajaUsuariodetalle)
        Dim obj As cajaUsuario
        Dim con = HeliosData.cajaUsuario _
            .Include("cajaUsuariodetalle") _
            .Where(Function(o) o.idEmpresa = be.idEmpresa And
            o.idEstablecimiento = be.idEstablecimiento And
            o.fechaRegistro.Value.Year = be.fechaRegistro.Value.Year And
            o.fechaRegistro.Value.Month = be.fechaRegistro.Value.Month And
            o.idPersona = be.idPersona)

        CajaUsuarioSelPeriodo = New List(Of cajaUsuario)
        For Each i In con

            obj = New cajaUsuario With
            {
            .idcajaUsuario = i.idcajaUsuario,
            .idPersona = i.idPersona,
            .claveIngreso = i.claveIngreso,
            .documentoApertura = i.documentoApertura,
            .documentoCierre = i.documentoCierre,
            .idCajaOrigen = i.idCajaOrigen,
            .idCajaDestino = i.idCajaDestino,
            .idCajaCierre = i.idCajaCierre,
            .fechaRegistro = i.fechaRegistro,
            .fechaCierre = i.fechaCierre,
            .moneda = i.moneda,
            .tipoCambio = i.tipoCambio,
            .fondoMN = i.fondoMN,
            .fondoME = i.fondoME,
            .ingresoAdicMN = i.ingresoAdicMN,
            .ingresoAdicME = i.ingresoAdicME,
            .otrosIngresosME = i.otrosIngresosME,
            .otrosIngresosMN = i.otrosIngresosMN,
            .otrosEgresosMN = i.otrosEgresosMN,
            .otrosEgresosME = i.otrosEgresosME,
            .estadoCaja = i.estadoCaja,
            .enUso = i.enUso,
            .idPadre = i.idPadre
            }


            listaDetalle = New List(Of cajaUsuariodetalle)
            For Each det In i.cajaUsuariodetalle.ToList
                listaDetalle.Add(New cajaUsuariodetalle With
                                 {
                                 .idcajaUsuario = det.idcajaUsuario,
                                 .secuencia = det.secuencia,
                                 .idEntidad = det.idEntidad,
                                 .moneda = det.moneda,
                                 .importeMN = det.importeMN,
                                 .idConfiguracion = det.idConfiguracion
                                 })
            Next
            obj.cajaUsuariodetalle = listaDetalle
            CajaUsuarioSelPeriodo.Add(obj)
        Next
    End Function

    Public Function GetCajasActivasTotalXdia(be As documentoCaja) As cajaUsuario
        GetCajasActivasTotalXdia = New cajaUsuario
        Select Case be.estado
            Case 1 ' por dia
                Dim cosulta = Aggregate c In HeliosData.cajaUsuario
                         Join cd In HeliosData.cajaUsuariodetalle
                             On cd.idcajaUsuario Equals c.idcajaUsuario
                             Where c.idEmpresa = be.idEmpresa _
                                 And c.fechaRegistro.Value.Year = be.fechaProceso.Value.Year _
                                 And c.fechaRegistro.Value.Month = be.fechaProceso.Value.Month _
                                 And c.fechaRegistro.Value.Day = be.fechaProceso.Value.Day _
                                 And c.estadoCaja = "A"
                                 Into
                         SumaMN = Sum(cd.importeMN),
                         SumaME = Sum(cd.importeME)



                GetCajasActivasTotalXdia.fondoMN = cosulta.SumaMN.GetValueOrDefault
                GetCajasActivasTotalXdia.fondoME = cosulta.SumaME.GetValueOrDefault
            Case 2 'acumulado

                Dim cosulta = Aggregate c In HeliosData.cajaUsuario
                                  Join cd In HeliosData.cajaUsuariodetalle
                                      On cd.idcajaUsuario Equals c.idcajaUsuario
                                      Where c.idEmpresa = be.idEmpresa _
                                          And c.estadoCaja = "A"
                                          Into
                                  SumaMN = Sum(cd.importeMN),
                                  SumaME = Sum(cd.importeME)

                GetCajasActivasTotalXdia.fondoMN = cosulta.SumaMN.GetValueOrDefault
                GetCajasActivasTotalXdia.fondoME = cosulta.SumaME.GetValueOrDefault
        End Select

    End Function

    Public Function ObtenerCajaUsuarioFull(empresa As String, idEstable As Integer) As List(Of cajaUsuario)
        Dim objMostrarEncaja As New cajaUsuario
        Dim listaEncaja As New List(Of cajaUsuario)

        Dim consulta = (From c In HeliosData.cajaUsuario
                        Where c.estadoCaja = "A" And
                            c.idEmpresa = empresa And
                            c.idEstablecimiento = idEstable
                        Select New With {.idPersona = c.idPersona,
                                        .idCaja = c.idcajaUsuario,
                                        .estado = c.estadoCaja,
                                            .fechaRegistro = c.fechaRegistro}).ToList

        If (Not IsNothing(consulta)) Then
            For Each i In consulta
                objMostrarEncaja = New cajaUsuario() With
                             {
                                    .idPersona = i.idPersona,
                                    .idcajaUsuario = i.idCaja,
                                     .estadoCaja = i.estado,
                                    .fechaRegistro = i.fechaRegistro}
                listaEncaja.Add(objMostrarEncaja)
            Next

        End If
        Return listaEncaja
    End Function

    Public Function ObtenerCajaUsuarioDia(be As cajaUsuario) As List(Of cajaUsuario)
        Dim objMostrarEncaja As New cajaUsuario
        Dim listaEncaja As New List(Of cajaUsuario)

        Dim consulta = (From c In HeliosData.cajaUsuario
                        Where
                            c.idEmpresa = be.idEmpresa And
                            c.idEstablecimiento = be.idEstablecimiento And
                            c.fechaRegistro.Value.Year = be.fechaRegistro.Value.Year And
                            c.fechaRegistro.Value.Month = be.fechaRegistro.Value.Month And
                            c.fechaRegistro.Value.Day = be.fechaRegistro.Value.Day
                        Select New With
                            {.idPersona = c.idPersona,
                            .idCaja = c.idcajaUsuario,
                            .estado = c.estadoCaja,
                            .fechaRegistro = c.fechaRegistro,
                            .fechaCierre = c.fechaCierre
                            }).ToList

        If (Not IsNothing(consulta)) Then
            For Each i In consulta
                objMostrarEncaja = New cajaUsuario() With
                             {
                                    .idPersona = i.idPersona,
                                    .idcajaUsuario = i.idCaja,
                                     .estadoCaja = i.estado,
                                    .fechaRegistro = i.fechaRegistro,
                                    .fechaCierre = i.fechaCierre.GetValueOrDefault
                }
                listaEncaja.Add(objMostrarEncaja)
            Next

        End If
        Return listaEncaja
    End Function

    Public Function ListadoCajaAsigConteo(strIdEmpresa As String, intEstablec As Integer) As Integer

        Dim consulta = (From s In HeliosData.cajaUsuario
                        Where s.idEmpresa = strIdEmpresa _
                        And s.idEstablecimiento = intEstablec _
                          And s.estadoCaja = "A"
                        Select s).Count

        Return consulta
    End Function

    Public Function ListadoCajaFullConteo(strIdEmpresa As String, intEstablec As Integer) As Integer

        Dim consulta = (From CajaUsuario In HeliosData.cajaUsuario
                        Where CajaUsuario.idEmpresa = strIdEmpresa And CajaUsuario.idEstablecimiento = intEstablec
                        Group CajaUsuario By
                                CajaUsuario.usuarioActualizacion,
                                CajaUsuario.idPersona
                                Into g = Group
                        Order By
                        usuarioActualizacion
                        Select
                        usuarioActualizacion,
                        Column1 = g.Max(Function(p) p.idPersona),
                        Column2 = CType(g.Max(Function(p) p.fechaRegistro), DateTime?),
                        Column3 = CType(g.Max(Function(p) p.idcajaUsuario), Int32?),
                        Column4 = g.Min(Function(p) p.estadoCaja)
).Count

        Return consulta
    End Function

    Public Sub EditarCajaUsuarioNuevo(objCajaUsuarioBE As cajaUsuario)
        Dim documentoBL As New documentoBL
        Dim cajaDetalleBL As New cajaUsuarioDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim cajaUsuarioBL As New CajaUsuarioBL
        Dim cajaUsuarioDetalleBL As New cajaUsuarioDetalleBL
        Try
            Using ts As New TransactionScope
                cajaUsuarioBL.Editar(objCajaUsuarioBE)
                cajaDetalleBL.EliminarDetalle(objCajaUsuarioBE)
                For Each i In objCajaUsuarioBE.cajaUsuariodetalle
                    cajaUsuarioDetalleBL.InsertarNuevo(i)
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ResumenTransaccionesXusuarioCajaPago(be As cajaUsuario) As List(Of cajaUsuario)
        Dim obj As New cajaUsuario
        Dim list As New List(Of cajaUsuario)
        Dim finanzaBL As New estadosFinancierosBL
        Dim finanza As New estadosFinancieros

        Dim consulta = (From n In HeliosData.usp_ResumenTransaccionesXusuarioCaja(be.idPersona, be.idcajaUsuario)
                        Select n).ToList


        For Each i In consulta

            Dim Cobros = (From d In HeliosData.documentoCajaDetalle
                          Join f In HeliosData.estadosFinancieros On New With {.Idestado = d.documentoCaja.entidadFinanciera} Equals New With {.Idestado = CStr(f.idestado)}
                          Where
                                    CLng(d.idCajaUsuario) = i.idcajaUsuario And
                                    d.documentoCaja.entidadFinanciera = CStr(i.idEntidad) And
                                    d.documentoCaja.tipoMovimiento = "DC" And
                                    d.documentoCaja.estado = "1"
                          Group New With {f, d} By
                                    f.descripcion,
                                    f.cuenta
                                    Into g = Group
                          Select
                                    Column1 = CType(g.Sum(Function(p) p.d.montoSoles), Decimal?),
                                    descripcion,
                                    cuenta).FirstOrDefault

            Dim Pagos = (From d In HeliosData.documentoCajaDetalle
                         Join f In HeliosData.estadosFinancieros On New With {.Idestado = d.documentoCaja.entidadFinanciera} Equals New With {.Idestado = CStr(f.idestado)}
                         Where
                                     CLng(d.idCajaUsuario) = i.idcajaUsuario And
                                     d.documentoCaja.entidadFinanciera = CStr(i.idEntidad) And
                                     d.documentoCaja.tipoMovimiento = "PG" And
                                     d.documentoCaja.estado = "1"
                         Group New With {f, d} By
                                     f.descripcion,
                                     f.cuenta
                                     Into g = Group
                         Select
                                     Column1 = CType(g.Sum(Function(p) p.d.montoSoles), Decimal?),
                                     descripcion,
                                     cuenta).FirstOrDefault

            'finanza = finanzaBL.GetUbicar_estadosFinancierosPorID(i.idEntidad)

            obj = New cajaUsuario
            obj.idEmpresa = finanza.idEmpresa
            obj.idEstablecimiento = finanza.idEstablecimiento
            obj.idcajaUsuario = i.idcajaUsuario
            obj.idPersona = be.idPersona
            obj.idEntidad = i.idEntidad
            obj.NombreEntidad = i.descripcion
            obj.Tipo = i.tipo
            obj.moneda = i.moneda
            obj.fondoMN = i.Inicio
            obj.fondoME = i.InicioME
            obj.ingresoAdicMN = i.ingresos
            obj.ingresoAdicME = i.ingresosME
            obj.otrosEgresosMN = i.egresos
            obj.otrosEgresosME = i.egresosME

            If (Not IsNothing(Cobros) And Not IsNothing(Pagos)) Then
                obj.otrosIngresosMN = CDec(Cobros.Column1.GetValueOrDefault - Pagos.Column1.GetValueOrDefault) + obj.fondoMN
                obj.cuentaCajaOrigen = Cobros.cuenta
            ElseIf (Not IsNothing(Cobros) And IsNothing(Pagos)) Then
                obj.otrosIngresosMN = CDec(Cobros.Column1.GetValueOrDefault) + obj.fondoMN
                obj.cuentaCajaOrigen = Cobros.cuenta
            ElseIf (IsNothing(Cobros) And Not IsNothing(Pagos)) Then
                obj.otrosIngresosMN = obj.fondoMN - Pagos.Column1.GetValueOrDefault
                obj.cuentaCajaOrigen = Pagos.cuenta
            Else
                obj.otrosIngresosMN = 0.0 + obj.fondoMN
                obj.cuentaCajaOrigen = 0
            End If

            list.Add(obj)
        Next
        Return list
    End Function

    Public Function ResumenTransaccionesXusuarioCaja(be As cajaUsuario) As List(Of cajaUsuario)
        Dim obj As New cajaUsuario
        Dim list As New List(Of cajaUsuario)
        Dim finanzaBL As New estadosFinancierosBL
        Dim finanza As New estadosFinancieros

        Dim consulta = (From n In HeliosData.usp_ResumenTransaccionesXusuarioCaja(be.idPersona, be.idcajaUsuario)
                        Select n).ToList


        For Each i In consulta

            finanza = finanzaBL.GetUbicar_estadosFinancierosPorID(i.idEntidad)

            obj = New cajaUsuario
            obj.idEmpresa = finanza.idEmpresa
            obj.idEstablecimiento = finanza.idEstablecimiento
            obj.idcajaUsuario = i.idcajaUsuario
            obj.idPersona = be.idPersona
            obj.idEntidad = i.idEntidad
            obj.NombreEntidad = i.descripcion
            obj.Tipo = i.tipo
            obj.moneda = i.moneda
            obj.fondoMN = i.Inicio
            obj.fondoME = i.InicioME
            obj.ingresoAdicMN = i.ingresos
            obj.ingresoAdicME = i.ingresosME
            obj.otrosEgresosMN = i.egresos
            obj.otrosEgresosME = i.egresosME
            obj.cuentaCajaOrigen = finanza.cuenta
            list.Add(obj)
        Next
        Return list
    End Function

    Public Function usp_ResumenTransaccionesXusuarioCajaXCierre(be As cajaUsuario) As List(Of cajaUsuario)
        Dim obj As New cajaUsuario
        Dim list As New List(Of cajaUsuario)

        Dim consulta = (From n In HeliosData.usp_ResumenTransaccionesXusuarioCajaXCierre(be.idPersona, be.idcajaUsuario, be.fechaRegistro)
                        Select n).ToList

        For Each i In consulta
            obj = New cajaUsuario
            obj.idcajaUsuario = i.idcajaUsuario
            obj.idPersona = be.idPersona
            obj.idEntidad = i.idEntidad
            obj.NombreEntidad = i.descripcion
            obj.Tipo = i.tipo
            obj.moneda = i.moneda
            obj.fondoMN = i.Inicio
            obj.fondoME = i.InicioME
            obj.ingresoAdicMN = i.ingresos
            obj.ingresoAdicME = i.ingresosME
            obj.otrosEgresosMN = i.egresos
            obj.otrosEgresosME = i.egresosME
            list.Add(obj)
        Next
        Return list
    End Function

    Public Function ValidarUsuarioCajaAbierto(intIdPersona As Integer) As cajaUsuario
        'Return (From n In HeliosData.cajaUsuario Where n.idPersona = intIdPersona _
        '            And n.estadoCaja = "A" And n.idEmpresa = Gempresas.IdEmpresaRuc _
        '            And n.idEstablecimiento = GEstableciento.IdEstablecimiento).FirstOrDefault

        Return (From n In HeliosData.cajaUsuario Where n.idPersona = intIdPersona _
                    And n.estadoCaja = "A").FirstOrDefault

    End Function

    Public Function UbicarCajaUsuarioAbierto(intIdCajaUsuario As Integer, strEstado As String) As cajaUsuario
        Return (From n In HeliosData.cajaUsuario Where n.idcajaUsuario = intIdCajaUsuario _
                And n.estadoCaja = strEstado).First

    End Function

    Public Function UbicarCajaUsuarioPorID(intIdCajaUsuario As Integer) As cajaUsuario
        Return (From n In HeliosData.cajaUsuario Where n.idcajaUsuario = intIdCajaUsuario).First

    End Function

    Public Sub UpdateCajaUsuario(ByVal objTotalMonto As cajaUsuario, objDeleteTotales As cajaUsuario)
        Dim objNuevo As New cajaUsuario()
        Dim objTotal As New cajaUsuario()
        Using ts As New TransactionScope()

            DeleteTotalesCajaUsuario(objDeleteTotales.IdDocumentoVenta, objDeleteTotales.idcajaUsuario)

            With objTotalMonto

                objNuevo = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = .idcajaUsuario).FirstOrDefault

                If Not IsNothing(objNuevo) Then

                    objNuevo.ingresoAdicMN = objNuevo.ingresoAdicMN + .ingresoAdicMN
                    objNuevo.ingresoAdicME = objNuevo.ingresoAdicME + .ingresoAdicME

                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Else
                    'objTotal = New cajaUsuario()
                    'objTotal.idEmpresa = i.idEmpresa
                    'objTotal.idEstablecimiento = i.idEstablecimiento
                    'objTotal.idAlmacen = i.idAlmacen
                    'objTotal.origenRecaudo = i.origenRecaudo
                    'objTotal.tipoCambio = i.tipoCambio
                    'objTotal.tipoExistencia = i.tipoExistencia
                    'objTotal.idItem = i.idItem
                    'objTotal.descripcion = i.descripcion
                    'objTotal.idUnidad = i.idUnidad
                    'objTotal.unidadMedida = i.unidadMedida
                    'objTotal.Modulo = i.Modulo

                    'objTotal.cantidad = i.cantidad
                    'objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                    'objTotal.importeSoles = i.importeSoles

                    'objTotal.importeDolares = i.importeDolares
                    'objTotal.montoIsc = i.montoIsc
                    'objTotal.montoIscUS = i.montoIscUS

                    'SaveSIngle(objTotal)
                End If

            End With


            HeliosData.SaveChanges()
            ts.Complete()

        End Using

    End Sub


    Public Sub CerrarCajasActivasPC(be As List(Of cajaUsuario))
        Using ts As New TransactionScope
            For Each i In be
                CerrarCajaUsuarioPC(i)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub CerrarCajasActivas(be As List(Of cajaUsuario))
        Using ts As New TransactionScope
            For Each i In be
                CerrarCajaUsuario(i)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function CerrarCajaUsuario(nCajaUsuario As cajaUsuario, nDocumento As documento) As cajaUsuario
        Dim objNuevo As New cajaUsuario()
        Dim docCajaBL As New documentoCajaBL
        Dim cajaEntregaBL As New cajaUsuarioDineroEntregadoBL

        Dim consultaValida = (From n In HeliosData.cajaUsuario
                              Where n.estadoCaja = "C" And
                             n.idcajaUsuario = nCajaUsuario.idcajaUsuario).FirstOrDefault

        If IsNothing(consultaValida) Then
            Using ts As New TransactionScope()
                'If nDocumento.documentoCaja.documentoCajaDetalle.Count > 0 Then
                '    docCajaBL.SaveCerrarCaja(nDocumento)
                'End If
                objNuevo = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = nCajaUsuario.idcajaUsuario).First
                objNuevo.documentoCierre = nDocumento.idDocumento
                objNuevo.estadoCaja = nCajaUsuario.estadoCaja
                objNuevo.fechaCierre = nCajaUsuario.fechaCierre
                objNuevo.enUso = nCajaUsuario.enUso

                objNuevo.ingresoAdicMN = nCajaUsuario.ingresoAdicMN
                objNuevo.ingresoAdicME = nCajaUsuario.ingresoAdicME
                objNuevo.otrosEgresosMN = nCajaUsuario.otrosEgresosMN
                objNuevo.otrosEgresosME = nCajaUsuario.otrosEgresosME
                objNuevo.idCajaCierre = nCajaUsuario.idCajaCierre

                'If Not IsNothing(nDocumento.CustomDocumentoCaja) Then
                '    docCajaBL.SaveCerrarCaja(nDocumento.CustomDocumentoCaja)
                'End If
                If nCajaUsuario.cajaUsuarioDineroEntregado IsNot Nothing Then
                    If nCajaUsuario.cajaUsuarioDineroEntregado.Count > 0 Then
                        For Each r In nCajaUsuario.cajaUsuarioDineroEntregado
                            cajaEntregaBL.GetGrabarCierreCaja(r)
                        Next
                    End If
                End If

                HeliosData.SaveChanges()
                ts.Complete()
                Return objNuevo
            End Using
        Else
            Throw New Exception("La caja ya esta cerrada!")
        End If


    End Function

    Public Function CerrarCajaUsuarioPC(nCajaUsuario As cajaUsuario) As cajaUsuario
        Dim objNuevo As New cajaUsuario()
        Dim docCajaBL As New documentoCajaBL
        Dim cajaEntregaBL As New cajaUsuarioDineroEntregadoBL

        Dim consultaValida = (From n In HeliosData.cajaUsuario
                              Where n.idcajaUsuario = nCajaUsuario.idcajaUsuario And n.namepc = nCajaUsuario.namepc).Single


        Using ts As New TransactionScope()

            consultaValida.estadoCaja = nCajaUsuario.estadoCaja
            consultaValida.enUso = nCajaUsuario.enUso
            consultaValida.fechaCierre = nCajaUsuario.fechaCierre

            If nCajaUsuario.idPadre IsNot Nothing Then
                consultaValida.idPadre = nCajaUsuario.idPadre
            End If

            'If nDocumento.documentoCaja.documentoCajaDetalle.Count > 0 Then
            '    docCajaBL.SaveCerrarCaja(nDocumento)
            'End If


            'If Not IsNothing(nDocumento.CustomDocumentoCaja) Then
            '    docCajaBL.SaveCerrarCaja(nDocumento.CustomDocumentoCaja)
            'End If
            If nCajaUsuario.cajaUsuarioDineroEntregado IsNot Nothing Then
                If nCajaUsuario.cajaUsuarioDineroEntregado.Count > 0 Then
                    For Each r In nCajaUsuario.cajaUsuarioDineroEntregado
                        cajaEntregaBL.GetGrabarCierreCaja(r)
                    Next
                End If
            End If

            HeliosData.SaveChanges()
            ts.Complete()
            Return objNuevo
        End Using
    End Function

    Public Function CerrarCajaUsuario(nCajaUsuario As cajaUsuario) As cajaUsuario
        Dim objNuevo As New cajaUsuario()
        Dim docCajaBL As New documentoCajaBL
        Dim cajaEntregaBL As New cajaUsuarioDineroEntregadoBL

        Dim consultaValida = (From n In HeliosData.cajaUsuario
                              Where n.idcajaUsuario = nCajaUsuario.idcajaUsuario).Single


        Using ts As New TransactionScope()

            consultaValida.estadoCaja = nCajaUsuario.estadoCaja
            consultaValida.enUso = nCajaUsuario.enUso
            consultaValida.fechaCierre = nCajaUsuario.fechaCierre

            If nCajaUsuario.idPadre IsNot Nothing Then
                consultaValida.idPadre = nCajaUsuario.idPadre

            End If
            'If nDocumento.documentoCaja.documentoCajaDetalle.Count > 0 Then
            '    docCajaBL.SaveCerrarCaja(nDocumento)
            'End If


            'If Not IsNothing(nDocumento.CustomDocumentoCaja) Then
            '    docCajaBL.SaveCerrarCaja(nDocumento.CustomDocumentoCaja)
            'End If
            If nCajaUsuario.cajaUsuarioDineroEntregado IsNot Nothing Then
                If nCajaUsuario.cajaUsuarioDineroEntregado.Count > 0 Then
                    For Each r In nCajaUsuario.cajaUsuarioDineroEntregado
                        cajaEntregaBL.GetGrabarCierreCaja(r)
                    Next
                End If
            End If

            HeliosData.SaveChanges()
            ts.Complete()
            Return objNuevo
        End Using
    End Function

    Public Sub CerrarAbrirCajaSubUsuario(nCajaUsuario As cajaUsuario)
        Dim objNuevo As New cajaUsuario()
        Dim docCajaBL As New documentoCajaBL

        'Dim consultaValida = (From n In HeliosData.cajaUsuario _
        '                     Where n.estadoCaja = "C" And
        '                     n.idcajaUsuario = nCajaUsuario.idcajaUsuario).FirstOrDefault

        'If IsNothing(consultaValida) Then
        Using ts As New TransactionScope()
            objNuevo = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = nCajaUsuario.idcajaUsuario).First
            objNuevo.estadoCaja = nCajaUsuario.estadoCaja
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
        'Else
        'Throw New Exception("La caja ya esta cerrada!")
        'End If


    End Sub

    Public Sub AperturarCajaUsuario(nCajaUsuario As cajaUsuario, nDocumento As documento)
        Dim objNuevo As New cajaUsuario()
        Dim docCajaBL As New documentoCajaBL

        Dim consultaValida = (From n In HeliosData.cajaUsuario
                              Where n.estadoCaja = "A" And
                              n.idcajaUsuario = nCajaUsuario.idcajaUsuario).FirstOrDefault

        If IsNothing(consultaValida) Then
            Using ts As New TransactionScope()
                docCajaBL.SaveCerrarCaja(nDocumento)
                objNuevo = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = nCajaUsuario.idcajaUsuario).First
                objNuevo.documentoCierre = nDocumento.idDocumento
                objNuevo.estadoCaja = nCajaUsuario.estadoCaja
                objNuevo.fechaCierre = nCajaUsuario.fechaCierre
                objNuevo.enUso = nCajaUsuario.enUso

                objNuevo.ingresoAdicMN = nCajaUsuario.ingresoAdicMN
                objNuevo.ingresoAdicME = nCajaUsuario.ingresoAdicME
                objNuevo.otrosEgresosMN = nCajaUsuario.otrosEgresosMN
                objNuevo.otrosEgresosME = nCajaUsuario.otrosEgresosME
                objNuevo.idCajaCierre = Nothing
                'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Else
            Throw New Exception("La caja ya esta cerrada!")
        End If


    End Sub


    Public Sub UpdateCajaUsuarioCompras(ByVal objTotalMonto As cajaUsuario, objDeleteTotales As cajaUsuario)
        Dim objNuevo As New cajaUsuario()
        Dim objTotal As New cajaUsuario()
        Using ts As New TransactionScope()

            DeleteTotalesCajaUsuarioCompras(objDeleteTotales.IdDocumentoVenta, objDeleteTotales.idcajaUsuario)

            With objTotalMonto

                objNuevo = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = .idcajaUsuario).FirstOrDefault

                If Not IsNothing(objNuevo) Then

                    objNuevo.otrosEgresosMN = objNuevo.otrosEgresosMN + .otrosEgresosMN
                    objNuevo.otrosEgresosME = objNuevo.otrosEgresosME + .otrosEgresosME

                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Else
                    'objTotal = New cajaUsuario()
                    'objTotal.idEmpresa = i.idEmpresa
                    'objTotal.idEstablecimiento = i.idEstablecimiento
                    'objTotal.idAlmacen = i.idAlmacen
                    'objTotal.origenRecaudo = i.origenRecaudo
                    'objTotal.tipoCambio = i.tipoCambio
                    'objTotal.tipoExistencia = i.tipoExistencia
                    'objTotal.idItem = i.idItem
                    'objTotal.descripcion = i.descripcion
                    'objTotal.idUnidad = i.idUnidad
                    'objTotal.unidadMedida = i.unidadMedida
                    'objTotal.Modulo = i.Modulo

                    'objTotal.cantidad = i.cantidad
                    'objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                    'objTotal.importeSoles = i.importeSoles

                    'objTotal.importeDolares = i.importeDolares
                    'objTotal.montoIsc = i.montoIsc
                    'objTotal.montoIscUS = i.montoIscUS

                    'SaveSIngle(objTotal)
                End If

            End With


            HeliosData.SaveChanges()
            ts.Complete()

        End Using

    End Sub

    Public Sub UpdateCajaUsuarioCompras2(ByVal objTotalMonto As cajaUsuario, objDeleteTotales As cajaUsuario, objDocCompra As documentocompra)
        Dim objNuevo As New cajaUsuario()
        Dim objdetalleCaja As New cajaUsuariodetalle()
        Dim objTotal As New cajaUsuario()
        Using ts As New TransactionScope()

            DeleteTotalesCajaUsuarioCompras(objDeleteTotales.IdDocumentoVenta, objDeleteTotales.idcajaUsuario)

            With objTotalMonto

                objNuevo = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = .idcajaUsuario).FirstOrDefault

                If Not IsNothing(objNuevo) Then

                    objNuevo.otrosEgresosMN = objNuevo.otrosEgresosMN + .otrosEgresosMN
                    objNuevo.otrosEgresosME = objNuevo.otrosEgresosME + .otrosEgresosME

                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Else
                    'objTotal = New cajaUsuario()
                    'objTotal.idEmpresa = i.idEmpresa
                    'objTotal.idEstablecimiento = i.idEstablecimiento
                    'objTotal.idAlmacen = i.idAlmacen
                    'objTotal.origenRecaudo = i.origenRecaudo
                    'objTotal.tipoCambio = i.tipoCambio
                    'objTotal.tipoExistencia = i.tipoExistencia
                    'objTotal.idItem = i.idItem
                    'objTotal.descripcion = i.descripcion
                    'objTotal.idUnidad = i.idUnidad
                    'objTotal.unidadMedida = i.unidadMedida
                    'objTotal.Modulo = i.Modulo

                    'objTotal.cantidad = i.cantidad
                    'objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                    'objTotal.importeSoles = i.importeSoles

                    'objTotal.importeDolares = i.importeDolares
                    'objTotal.montoIsc = i.montoIsc
                    'objTotal.montoIscUS = i.montoIscUS

                    'SaveSIngle(objTotal)
                End If

                'objdetalleCaja = HeliosData.cajaUsuariodetalle.Where(Function(o) o.idcajaUsuario = .idcajaUsuario And
                '                                                   o.tipoDoc = objDocCompra.tipoDoc And
                '                                                   o.tipoVenta = objDocCompra.tipoCompra).FirstOrDefault


                objdetalleCaja.importeMN = objdetalleCaja.importeMN + .otrosEgresosMN
                objdetalleCaja.importeME = objdetalleCaja.importeME + .otrosEgresosME

                'HeliosData.ObjectStateManager.GetObjectStateEntry(objdetalleCaja).State.ToString()

            End With


            HeliosData.SaveChanges()
            ts.Complete()

        End Using

    End Sub

    Public Sub ActualizarMontoCajaUsuario(ByVal docCaja As cajaUsuario)
        Dim cajaDetalle As New cajaUsuarioDetalleBL
        Try
            Using ts As New TransactionScope()
                ActualizarMontos(docCaja)
                cajaDetalle.InsertarNuevoIngreso(docCaja.cajaUsuariodetalle.First)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub ActualizarMontoCajaUsuarioCompras(ByVal docCaja As cajaUsuario)
        Dim cajaDetalle As New cajaUsuarioDetalleBL
        Try
            Using ts As New TransactionScope()
                ActualizarMontoCompra(docCaja)
                cajaDetalle.InsertarNuevoIngreso(docCaja.cajaUsuariodetalle.First)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub ActualizarMontos(ByVal docCaja As cajaUsuario)
        Try
            Using ts As New TransactionScope()

                Dim Detalle As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = docCaja.idcajaUsuario).First
                If IsNothing(Detalle.ingresoAdicMN) Then
                    Detalle.ingresoAdicMN = 0
                End If

                If IsNothing(Detalle.ingresoAdicME) Then
                    Detalle.ingresoAdicME = 0
                End If

                Detalle.ingresoAdicMN = CDec(Detalle.ingresoAdicMN) + CDec(docCaja.ingresoAdicMN)
                Detalle.ingresoAdicME = CDec(Detalle.ingresoAdicME) + CDec(docCaja.ingresoAdicME)

                'HeliosData.ObjectStateManager.GetObjectStateEntry(Detalle).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub ActualizarMontoCompra(ByVal docCaja As cajaUsuario)
        Try
            Using ts As New TransactionScope()

                Dim Detalle As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = docCaja.idcajaUsuario).First
                If IsNothing(Detalle.otrosEgresosMN) Then
                    Detalle.otrosEgresosMN = 0
                End If

                If IsNothing(Detalle.otrosEgresosME) Then
                    Detalle.otrosEgresosME = 0
                End If

                Detalle.otrosEgresosMN = CDec(Detalle.otrosEgresosMN) + CDec(docCaja.otrosEgresosMN)
                Detalle.otrosEgresosME = CDec(Detalle.otrosEgresosME) + CDec(docCaja.otrosEgresosME)

                'HeliosData.ObjectStateManager.GetObjectStateEntry(Detalle).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub DeleteTotalesCajaUsuario(ByVal intIdDocumentoVenta As Integer, intIdCajaUsuario As Integer)
        Dim cajaUsarioDetalleBL As New cajaUsuarioDetalleBL()
        Try
            Using ts As New TransactionScope()
                DeleteCajaUsuario(intIdDocumentoVenta, intIdCajaUsuario)
                cajaUsarioDetalleBL.DeleteTotalesCajaUsuarioDetalle(intIdDocumentoVenta, intIdCajaUsuario)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteTotalesCajaUsuarioDocCajaDetalle(ByVal intIdDocumentoCaja As Integer, intIdCajaUsuario As Integer, intIdDocCompra As Integer)
        Dim cajaUsarioDetalleBL As New cajaUsuarioDetalleBL()
        Try
            Using ts As New TransactionScope()
                DeleteCajaUsuarioCajaDet(intIdDocumentoCaja, intIdCajaUsuario)
                'cajaUsarioDetalleBL.DeleteTotalesCajaUsuarioDetalleCaja(intIdDocumentoCaja, intIdCajaUsuario, intIdDocCompra)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteTotalesCajaUsuarioDocCajaDetallePrestamoOT(ByVal intIdDocumentoCaja As Integer, intIdCajaUsuario As Integer, intIdDocCompra As Integer)
        Dim cajaUsarioDetalleBL As New cajaUsuarioDetalleBL()
        Try
            Using ts As New TransactionScope()
                DeleteCajaUsuarioCajaDet(intIdDocumentoCaja, intIdCajaUsuario)
                cajaUsarioDetalleBL.DeleteTotalesCajaUsuarioDetalleCajaPrestamoOT(intIdDocumentoCaja, intIdCajaUsuario, intIdDocCompra)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteCajaUsuarioCajaDet(ByVal intIdDocCaja As Integer, intIdCajaUsuario As Integer)
        Dim objNuevo As New cajaUsuario()
        Try
            Using ts As New TransactionScope()

                Dim objBackDoc = (From k In HeliosData.documentoCaja
                                  Where k.idDocumento = intIdDocCaja).FirstOrDefault

                If Not IsNothing(objBackDoc) Then

                    objNuevo = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = intIdCajaUsuario).FirstOrDefault

                    If Not IsNothing(objNuevo) Then
                        objNuevo.otrosEgresosMN = objNuevo.otrosEgresosMN - objBackDoc.montoSoles
                        objNuevo.otrosEgresosME = objNuevo.otrosEgresosME - objBackDoc.montoUsd
                        'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                    End If

                End If

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteTotalesCajaUsuarioCompra(ByVal intIdDocumentoCompra As Integer, intIdCajaUsuario As Integer)
        Dim cajaUsarioDetalleBL As New cajaUsuarioDetalleBL()
        Try
            Using ts As New TransactionScope()
                DeleteCajaUsuarioCompras(intIdDocumentoCompra, intIdCajaUsuario)
                cajaUsarioDetalleBL.DeleteTotalesCajaUsuarioDetalleCompra(intIdDocumentoCompra, intIdCajaUsuario)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteTotalesCajaUsuarioCompras(ByVal intIdDocumentoCompra As Integer, intIdCajaUsuario As Integer)
        Dim cajaUsarioDetalleBL As New cajaUsuarioDetalleBL()
        Try
            Using ts As New TransactionScope()
                DeleteCajaUsuarioCompras(intIdDocumentoCompra, intIdCajaUsuario)
                cajaUsarioDetalleBL.DeleteTotalesCajaUsuarioDetalleCompra(intIdDocumentoCompra, intIdCajaUsuario)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteCajaUsuario(ByVal intIdDocumentoVenta As Integer, intIdCajaUsuario As Integer)
        Dim objNuevo As New cajaUsuario()
        Try
            Using ts As New TransactionScope()

                Dim objBackDoc = (From k In HeliosData.documentoventaAbarrotes
                                  Where k.idDocumento = intIdDocumentoVenta).First

                objNuevo = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = intIdCajaUsuario).FirstOrDefault

                If Not IsNothing(objNuevo) Then
                    objNuevo.ingresoAdicMN = objNuevo.ingresoAdicMN - objBackDoc.ImporteNacional
                    objNuevo.ingresoAdicME = objNuevo.ingresoAdicME - objBackDoc.ImporteExtranjero
                End If

                'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteCajaUsuarioCompras(ByVal intIdDocumentoCompra As Integer, intIdCajaUsuario As Integer)
        Dim objNuevo As New cajaUsuario()
        Try
            Using ts As New TransactionScope()

                Dim objBackDoc = (From k In HeliosData.documentocompra
                                  Where k.idDocumento = intIdDocumentoCompra).First

                objNuevo = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = intIdCajaUsuario).FirstOrDefault

                If Not IsNothing(objNuevo) Then
                    objNuevo.otrosEgresosMN = objNuevo.otrosEgresosMN - objBackDoc.importeTotal
                    objNuevo.otrosEgresosME = objNuevo.otrosEgresosME - objBackDoc.importeUS
                End If

                'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Insert(ByVal cajaUsuarioBE As cajaUsuario) As Integer
        Using ts As New TransactionScope

            Dim consulta = (From n In HeliosData.cajaUsuario
                            Where n.idPersona = cajaUsuarioBE.idPersona _
                            And n.idCajaOrigen = cajaUsuarioBE.idCajaOrigen _
                            And n.idCajaDestino = cajaUsuarioBE.idCajaDestino _
                            And n.estadoCaja = "A" _
                            And n.enUso = "S").FirstOrDefault

            If IsNothing(consulta) Then
                HeliosData.cajaUsuario.Add(cajaUsuarioBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return cajaUsuarioBE.idcajaUsuario
            Else
                Throw New Exception("El usuario ya tiene una caja asignada, debe cerrar primero.!")
            End If



        End Using
    End Function

    Public Function InsertUserCaja(ByVal cajaUsuarioBE As cajaUsuario, intIdDocumento As Integer) As Integer
        Dim cajaUsuarioBE2 As New cajaUsuario
        Using ts As New TransactionScope


            'Dim consulta = (From n In HeliosData.cajaUsuario
            '                Where n.idPersona = cajaUsuarioBE.idPersona _
            '               And n.estadoCaja = "A").FirstOrDefault

            'Dim cajeroPC = HeliosData.cajaUsuario.Any(Function(o) o.estadoCaja = "A" And o.namepc = cajaUsuarioBE.namepc)

            'If cajeroPC = True Then
            '    Throw New Exception("Esta pc ya tiene una caja activa")
            'End If

            'Dim consulta = (From n In HeliosData.cajaUsuario _
            '               Where n.idPersona = cajaUsuarioBE.idPersona _
            '               And n.idCajaOrigen = cajaUsuarioBE.idCajaOrigen _
            '               And n.idCajaDestino = cajaUsuarioBE.idCajaDestino _
            '               And n.estadoCaja = "A" _
            '               And n.enUso = "S").FirstOrDefault

            '   If IsNothing(consulta) Then
            With cajaUsuarioBE2
                .tipoCaja = cajaUsuarioBE.tipoCaja
                .IDRol = cajaUsuarioBE.IDRol
                .idPadre = 0
                .namepc = cajaUsuarioBE.namepc
                .idEmpresa = cajaUsuarioBE.idEmpresa
                .idEstablecimiento = cajaUsuarioBE.idEstablecimiento
                .idPersona = cajaUsuarioBE.idPersona
                .claveIngreso = cajaUsuarioBE.claveIngreso
                .periodo = cajaUsuarioBE.periodo
                .documentoApertura = intIdDocumento
                '  .documentoCierre = cajaUsuarioBE.idPersona
                .idCajaOrigen = cajaUsuarioBE.idCajaOrigen
                .idCajaDestino = cajaUsuarioBE.idCajaDestino
                .idCajaCierre = cajaUsuarioBE.idCajaCierre
                .fechaRegistro = cajaUsuarioBE.fechaRegistro
                .fechaCierre = cajaUsuarioBE.fechaCierre
                .moneda = cajaUsuarioBE.moneda
                .tipoCambio = cajaUsuarioBE.tipoCambio
                .fondoMN = cajaUsuarioBE.fondoMN
                .fondoME = cajaUsuarioBE.fondoME
                .ingresoAdicMN = cajaUsuarioBE.ingresoAdicMN
                .ingresoAdicME = cajaUsuarioBE.ingresoAdicME
                .otrosIngresosMN = cajaUsuarioBE.otrosIngresosMN
                .otrosIngresosME = cajaUsuarioBE.otrosIngresosME
                .otrosEgresosMN = cajaUsuarioBE.otrosEgresosMN
                .otrosEgresosME = cajaUsuarioBE.otrosEgresosME
                .estadoCaja = cajaUsuarioBE.estadoCaja
                .enUso = cajaUsuarioBE.enUso
                .usuarioActualizacion = cajaUsuarioBE.usuarioActualizacion
                .fechaActualizacion = cajaUsuarioBE.fechaActualizacion
            End With
            HeliosData.cajaUsuario.Add(cajaUsuarioBE2)
            HeliosData.SaveChanges()
            ts.Complete()
            Return cajaUsuarioBE2.idcajaUsuario
            'Else
            '    Throw New Exception("El usuario ya tiene una caja asignada, debe cerrar primero.!")
            'End If
        End Using
    End Function

    Public Function InsertUserCajaSubUser(ByVal cajaUsuarioBE As cajaUsuario, intIdDocumento As Integer, codigoCaja As Integer) As Integer
        Dim cajaUsuarioBE2 As New cajaUsuario
        Using ts As New TransactionScope

            With cajaUsuarioBE2
                .idPadre = codigoCaja
                .idEmpresa = cajaUsuarioBE.idEmpresa
                .idEstablecimiento = cajaUsuarioBE.idEstablecimiento
                .idPersona = cajaUsuarioBE.idPersona
                .claveIngreso = cajaUsuarioBE.claveIngreso
                .periodo = cajaUsuarioBE.periodo
                .documentoApertura = intIdDocumento
                '  .documentoCierre = cajaUsuarioBE.idPersona
                .idCajaOrigen = cajaUsuarioBE.idCajaOrigen
                .idCajaDestino = cajaUsuarioBE.idCajaDestino
                .idCajaCierre = cajaUsuarioBE.idCajaCierre
                .fechaRegistro = cajaUsuarioBE.fechaRegistro
                .fechaCierre = cajaUsuarioBE.fechaCierre
                .moneda = cajaUsuarioBE.moneda
                .tipoCambio = cajaUsuarioBE.tipoCambio
                .fondoMN = cajaUsuarioBE.fondoMN
                .fondoME = cajaUsuarioBE.fondoME
                .ingresoAdicMN = cajaUsuarioBE.ingresoAdicMN
                .ingresoAdicME = cajaUsuarioBE.ingresoAdicME
                .otrosIngresosMN = cajaUsuarioBE.otrosIngresosMN
                .otrosIngresosME = cajaUsuarioBE.otrosIngresosME
                .otrosEgresosMN = cajaUsuarioBE.otrosEgresosMN
                .otrosEgresosME = cajaUsuarioBE.otrosEgresosME
                .estadoCaja = cajaUsuarioBE.estadoCaja
                .enUso = cajaUsuarioBE.enUso
                .usuarioActualizacion = cajaUsuarioBE.usuarioActualizacion
                .fechaActualizacion = cajaUsuarioBE.fechaActualizacion
            End With
            HeliosData.cajaUsuario.Add(cajaUsuarioBE2)
            HeliosData.SaveChanges()
            ts.Complete()
            Return cajaUsuarioBE2.idcajaUsuario

        End Using
    End Function


    Public Sub ConfirmarEntregaDinero(idCaja As Integer, idCajaResp As Integer)
        Using ts As New TransactionScope
            Dim usuariocaja As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = idCaja).First

            If usuariocaja IsNot Nothing Then
                usuariocaja.idPadre = idCajaResp
            End If
            'HeliosData.ObjectStateManager.GetObjectStateEntry(usuariocaja).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Editar(ByVal cajaUsuarioBE As cajaUsuario)
        Using ts As New TransactionScope
            Dim usuariocaja As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = cajaUsuarioBE.idcajaUsuario).First

            With usuariocaja
                .idPersona = cajaUsuarioBE.idPersona
                .idCajaOrigen = cajaUsuarioBE.idCajaOrigen
                .fechaRegistro = cajaUsuarioBE.fechaRegistro
                .fondoMN = cajaUsuarioBE.fondoMN
                .fondoME = cajaUsuarioBE.fondoME
                .ingresoAdicMN = cajaUsuarioBE.ingresoAdicMN
                .ingresoAdicME = cajaUsuarioBE.ingresoAdicME
                .otrosIngresosMN = cajaUsuarioBE.otrosIngresosMN
                .otrosIngresosME = cajaUsuarioBE.otrosIngresosME
                .otrosEgresosMN = cajaUsuarioBE.otrosEgresosMN
                .otrosEgresosME = cajaUsuarioBE.otrosEgresosME
                .idCajaDestino = cajaUsuarioBE.idCajaDestino
                .usuarioActualizacion = cajaUsuarioBE.usuarioActualizacion
                .fechaActualizacion = cajaUsuarioBE.fechaActualizacion
                .claveIngreso = cajaUsuarioBE.claveIngreso
            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(usuariocaja).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
            cajaUsuarioBE.documentoApertura = usuariocaja.documentoApertura
        End Using
    End Sub



    Public Sub HabilitarUsoDeCajaUser(ByVal cajaUsuarioBE As cajaUsuario)
        Using ts As New TransactionScope
            Dim usuariocaja As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = cajaUsuarioBE.idcajaUsuario).First
            With usuariocaja
                .estadoCaja = cajaUsuarioBE.estadoCaja
                .enUso = cajaUsuarioBE.enUso
            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(usuariocaja).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Eliminar(ByVal cajaUsuarioBE As cajaUsuario)
        Using ts As New TransactionScope
            Dim usuariocaja As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = cajaUsuarioBE.idcajaUsuario).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(usuariocaja)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarCajaPorIdUsuario(ByVal idCajaUsuario As Integer)
        Using ts As New TransactionScope
            Dim usuariocaja As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = idCajaUsuario).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(usuariocaja)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarCajaUsuarioFull(ByVal cajaUsuarioBE As cajaUsuario)
        Dim documentoBL As New documentoBL

        Using ts As New TransactionScope

            Eliminar(cajaUsuarioBE)
            Dim LIstaEliminadosApertura As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = cajaUsuarioBE.documentoApertura).ToList
            For Each i As documentoCajaDetalle In LIstaEliminadosApertura
                documentoBL.DeleteSingleVariable(i.idDocumento)
            Next
            If Not IsNothing(cajaUsuarioBE.documentoCierre) Then
                documentoBL.DeleteSingleVariable(cajaUsuarioBE.documentoCierre)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ListarPorCaja(intIdCaja As Integer) As List(Of cajaUsuario)
        Return (From n In HeliosData.cajaUsuario
                Where n.idCajaOrigen = intIdCaja Select n).ToList

    End Function

    Public Function ListarPorCajaPorPeriodo(intIdCaja As Integer, strPeriodo As String) As List(Of cajaUsuario)


        Return (From n In HeliosData.cajaUsuario
                Where n.idCajaOrigen = intIdCaja And
                n.periodo = strPeriodo Select n).ToList

    End Function

    Public Function ListaCajasHabilitadas(strIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of cajaUsuario)
        Dim obj As New cajaUsuario
        Dim lista As New List(Of cajaUsuario)
        Dim consulta = (From n In HeliosData.cajaUsuario
                        Where n.idEmpresa = strIdEmpresa _
                        And n.idEstablecimiento = intIdEstablecimiento).ToList

        For Each i In consulta
            obj = New cajaUsuario
            obj.idcajaUsuario = i.idcajaUsuario
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.fechaRegistro = i.fechaRegistro
            obj.NombrePersona = String.Empty
            obj.idPersona = i.idPersona
            obj.idCajaOrigen = i.idCajaOrigen
            obj.fondoMN = i.fondoMN
            obj.fondoME = i.fondoME
            obj.moneda = i.moneda
            obj.tipoCambio = i.tipoCambio
            obj.estadoCaja = IIf(i.estadoCaja = "A", "Abierta", "cerrada")
            obj.enUso = i.enUso
            lista.Add(obj)
        Next
        Return lista
    End Function


    Public Function UbicarCajasHijasXpadre(iNtIdPadre As Integer) As List(Of cajaUsuario)
        Dim obj As New cajaUsuario
        Dim lista As New List(Of cajaUsuario)
        Dim consulta = (From n In HeliosData.cajaUsuario
                        Where n.idPadre = iNtIdPadre).ToList

        For Each i In consulta
            obj = New cajaUsuario
            obj.idcajaUsuario = i.idcajaUsuario
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.fechaRegistro = i.fechaRegistro
            obj.NombrePersona = String.Empty
            obj.idPersona = i.idPersona
            obj.idCajaOrigen = i.idCajaOrigen
            obj.fondoMN = i.fondoMN
            obj.fondoME = i.fondoME
            obj.moneda = i.moneda
            obj.tipoCambio = i.tipoCambio
            obj.ingresoAdicMN = i.ingresoAdicMN
            obj.ingresoAdicME = i.ingresoAdicME
            obj.otrosIngresosMN = i.otrosIngresosMN
            obj.otrosIngresosME = i.otrosIngresosME
            obj.otrosEgresosMN = i.otrosEgresosMN
            obj.otrosEgresosME = i.otrosEgresosME
            obj.estadoCaja = IIf(i.estadoCaja = "A", "Abierta", "cerrada")
            obj.enUso = i.enUso
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function UbicarCajasHijasFull(ListadoPadres As List(Of Integer)) As List(Of cajaUsuario)
        Dim obj As New cajaUsuario
        Dim lista As New List(Of cajaUsuario)

        Dim consulta = (From n In HeliosData.cajaUsuario
                        Where n.idEmpresa = Gempresas.IdEmpresaRuc And n.idEstablecimiento = GEstableciento.IdEstablecimiento _
                       And ListadoPadres.Contains(n.idPadre)).ToList()

        For Each i In consulta
            obj = New cajaUsuario
            obj.idcajaUsuario = i.idcajaUsuario
            obj.idPadre = i.idPadre
            obj.idEmpresa = i.idEmpresa
            obj.idEstablecimiento = i.idEstablecimiento
            obj.fechaRegistro = i.fechaRegistro
            obj.NombrePersona = String.Empty
            obj.idPersona = i.idPersona
            obj.idCajaOrigen = i.idCajaOrigen
            obj.idCajaDestino = i.idCajaDestino
            obj.fondoMN = i.fondoMN
            obj.fondoME = i.fondoME
            obj.moneda = i.moneda
            obj.tipoCambio = i.tipoCambio
            obj.ingresoAdicMN = i.ingresoAdicMN
            obj.ingresoAdicME = i.ingresoAdicME
            obj.otrosIngresosMN = i.otrosIngresosMN
            obj.otrosIngresosME = i.otrosIngresosME
            obj.otrosEgresosMN = i.otrosEgresosMN
            obj.otrosEgresosME = i.otrosEgresosME
            obj.estadoCaja = IIf(i.estadoCaja = "A", "Abierta", "cerrada")
            obj.enUso = i.enUso
            lista.Add(obj)
        Next
        Return lista
    End Function


    'Public Function UbicarCajaAsignadaUser(strNumDocUser As String, strEstadoCaja As String, InUso As String,
    '                                       strClave As String) As cajaUsuario
    '    Return (From n In HeliosData.cajaUsuario _
    '            Where n.idPersona = strNumDocUser And _
    '            n.estadoCaja = strEstadoCaja And _
    '            n.claveIngreso = strClave).FirstOrDefault
    'End Function

    Public Function UbicarCajaAsignadaUser(strNumDocUser As String, strEstadoCaja As String, InUso As String,
                                       strClave As String) As cajaUsuario

        Dim obj As New cajaUsuario
        Dim CAjaUsuario = (From n In HeliosData.cajaUsuario
                           Where n.idPersona = strNumDocUser And
                           n.estadoCaja = strEstadoCaja).FirstOrDefault

        'And _
        '                   n.idcajaUsuario = strClave

        If (Not IsNothing(CAjaUsuario)) Then
            obj = New cajaUsuario
            obj.idcajaUsuario = CAjaUsuario.idcajaUsuario
            obj.idEmpresa = CAjaUsuario.idEmpresa
            obj.idEstablecimiento = CAjaUsuario.idEstablecimiento
            obj.documentoApertura = CAjaUsuario.documentoApertura
            obj.documentoCierre = CAjaUsuario.documentoCierre
            obj.idPersona = CAjaUsuario.idPersona
            '  obj.NombrePersona = CAjaUsuario.nombreCompleto
            obj.idCajaOrigen = CAjaUsuario.idCajaOrigen
            'obj.idCajaDestino = CAjaUsuario.idCajaDestino
            obj.idCajaCierre = CAjaUsuario.idCajaCierre
            obj.periodo = CAjaUsuario.periodo
            obj.fechaRegistro = CAjaUsuario.fechaRegistro
            obj.fechaCierre = CAjaUsuario.fechaCierre
            'SE CAMBIO POR NO USAS LOS EGRESOS Y INGRESOS DE LA TABLA CAJAUSUARIUO
            'obj.fondoMN = (CDec(CAjaUsuario.fondoMN).ToString("N2") - CDec(CAjaUsuario.otrosEgresosMN).ToString("N2")) + CDec(CAjaUsuario.ingresoAdicMN).ToString("N2")
            'obj.fondoME = (CDec(CAjaUsuario.fondoME).ToString("N2") - CDec(CAjaUsuario.otrosEgresosME).ToString("N2")) + CDec(CAjaUsuario.ingresoAdicME).ToString("N2")
            obj.fondoMN = (CDec(CAjaUsuario.fondoMN).ToString("N2"))
            obj.fondoME = (CDec(CAjaUsuario.fondoME).ToString("N2"))
            obj.moneda = CAjaUsuario.moneda
            obj.tipoCambio = CAjaUsuario.tipoCambio
            obj.ingresoAdicMN = CAjaUsuario.ingresoAdicMN
            obj.ingresoAdicME = CAjaUsuario.ingresoAdicME
            obj.otrosIngresosMN = CAjaUsuario.otrosIngresosMN
            obj.otrosIngresosME = CAjaUsuario.otrosIngresosME
            obj.otrosEgresosMN = CAjaUsuario.otrosEgresosMN
            obj.otrosEgresosME = CAjaUsuario.otrosEgresosME
            obj.idPadre = CAjaUsuario.idPadre
            obj.estadoCaja = IIf(CAjaUsuario.estadoCaja = "A", "Abierta", "cerrada")
            obj.enUso = CAjaUsuario.enUso
            Return obj
        Else
            Return Nothing
        End If
    End Function


    Public Function UbicarCajaUsuarioXID(ByVal intIdCaja As Integer) As cajaUsuario
        Dim objMostrarEncaja As New cajaUsuario

        Dim consulta = (From c In HeliosData.cajaUsuario
                        Where c.idcajaUsuario = intIdCaja).FirstOrDefault


        Return consulta
    End Function

    Public Function ObtenerCajaUser(ByVal intIdCaja As Integer) As cajaUsuario
        Dim objMostrarEncaja As New cajaUsuario

        Dim consulta = (From c In HeliosData.cajaUsuario
                        Join p In HeliosData.Persona
                       On c.idPersona Equals p.idPersona
                        Where c.idcajaUsuario = intIdCaja
                        Select New With {.fechaRegistro = c.fechaRegistro,
                                         .Nombre = p.nombreCompleto,
                                         .DNI = p.idPersona,
                                        .MontoSoles = c.fondoMN,
                                       .MontoDolares = c.fondoME,
                                         .tipoCambio = c.tipoCambio,
                                         .claveUsuario = c.claveIngreso,
                                         .cuentaorigen = c.idCajaOrigen,
                                         .cuentaDestino = c.idCajaDestino,
                                         .idDocumento = c.documentoApertura,
                                         .tipoCaja = c.tipoCaja,
                                         .idCajaUsuario = c.idcajaUsuario}).FirstOrDefault

        If (Not IsNothing(consulta)) Then

            Dim cuentaOrigen = (From cd In HeliosData.estadosFinancieros
                                Where cd.idestado = consulta.cuentaorigen).First

            Dim cuentaDestino = (From cd In HeliosData.estadosFinancieros
                                 Where cd.idestado = consulta.cuentaDestino).First

            objMostrarEncaja = New cajaUsuario() With
                              {
                                  .IdDocumentoVenta = consulta.idDocumento,
                               .fechaRegistro = consulta.fechaRegistro,
                               .NombrePersona = consulta.Nombre,
                               .idPersona = consulta.DNI,
                               .fondoMN = consulta.MontoSoles,
                               .fondoME = consulta.MontoDolares,
                               .tipoCambio = consulta.tipoCambio,
                               .claveIngreso = consulta.claveUsuario,
                               .idCajaOrigen = cuentaOrigen.idestado,
                               .idCajaDestino = cuentaDestino.idestado,
                               .cuentaCajaOrigen = cuentaOrigen.cuenta,
                               .CuentaCajaDestino = cuentaDestino.cuenta,
                               .NombreCajaOrigen = cuentaOrigen.descripcion,
                               .NombreCajaDestino = cuentaDestino.descripcion,
                                  .idcajaUsuario = consulta.idCajaUsuario,
                                  .tipoCaja = consulta.tipoCaja
                                }
        End If

        Return objMostrarEncaja
    End Function

    Public Function ObtenerCajaUsuarioFullEstado() As List(Of cajaUsuario)
        Dim objMostrarEncaja As New cajaUsuario
        Dim listaEncaja As New List(Of cajaUsuario)


        Dim consulta2 = (From CajaUsuario In HeliosData.cajaUsuario
                         Group CajaUsuario By
                           CajaUsuario.usuarioActualizacion,
                           CajaUsuario.idPersona
                          Into g = Group
                         Order By
                           usuarioActualizacion
                         Select
                           usuarioActualizacion,
                           Column1 = g.Max(Function(p) p.idPersona),
                           Column2 = CType(g.Max(Function(p) p.fechaRegistro), DateTime?),
                           Column3 = CType(g.Max(Function(p) p.idcajaUsuario), Int32?),
                           Column4 = g.Min(Function(p) p.estadoCaja)
).ToList




        'Dim consulta = (From cajaUsuario In HeliosData.cajaUsuario _
        '                Group cajaUsuario By cajaUsuario.idcajaUsuario, cajaUsuario.idEmpresa, _

        If (Not IsNothing(consulta2)) Then
            For Each i In consulta2
                objMostrarEncaja = New cajaUsuario() With
                             {
                                    .idPersona = i.Column1,
                                    .idcajaUsuario = i.Column3,
                                     .estadoCaja = i.Column4,
                                    .fechaRegistro = i.Column2}
                listaEncaja.Add(objMostrarEncaja)
            Next

        End If
        Return listaEncaja

    End Function

    Public Function ValidarCajaXUsuario(intIdPersona As Integer) As cajaUsuario
        Dim cajausuarioBL As New cajaUsuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)

        Dim consulta = (From CajaUsuario In HeliosData.cajaUsuario
                        Where CajaUsuario.idPersona = intIdPersona _
                    And CajaUsuario.estadoCaja = "C" And CajaUsuario.idEmpresa = Gempresas.IdEmpresaRuc _
                    And CajaUsuario.idEstablecimiento = GEstableciento.IdEstablecimiento
                        Group CajaUsuario By CajaUsuario.idcajaUsuario, CajaUsuario.idEmpresa,
                          CajaUsuario.idEstablecimiento,
                          CajaUsuario.idPersona,
                          CajaUsuario.claveIngreso,
                          CajaUsuario.documentoApertura,
                          CajaUsuario.documentoCierre,
                          CajaUsuario.idCajaOrigen,
                          CajaUsuario.idCajaDestino,
                          CajaUsuario.idCajaCierre,
                          CajaUsuario.periodo,
                          CajaUsuario.fechaRegistro,
                          CajaUsuario.moneda,
                          CajaUsuario.tipoCambio,
                          CajaUsuario.fondoMN,
                          CajaUsuario.fondoME,
                          CajaUsuario.ingresoAdicMN,
                          CajaUsuario.ingresoAdicME,
                          CajaUsuario.otrosIngresosMN,
                          CajaUsuario.otrosIngresosME,
                          CajaUsuario.otrosEgresosMN,
                          CajaUsuario.otrosEgresosME,
                          CajaUsuario.estadoCaja,
                          CajaUsuario.enUso,
                          CajaUsuario.idPadre,
                          CajaUsuario.usuarioActualizacion,
                          CajaUsuario.fechaActualizacion
                         Into g = Group Select Column1 = CType(g.Max(Function(p) p.fechaCierre), DateTime?),
 idcajaUsuario,
  idEmpresa,
  idEstablecimiento,
  idPersona,
  claveIngreso,
  documentoApertura,
  documentoCierre,
  idCajaOrigen,
  idCajaDestino,
  idCajaCierre,
  periodo,
  fechaRegistro,
  moneda,
  tipoCambio,
  fondoMN,
  fondoME,
  ingresoAdicMN,
  ingresoAdicME,
  otrosIngresosMN,
  otrosIngresosME,
  otrosEgresosMN,
  otrosEgresosME,
  estadoCaja,
  enUso,
  idPadre,
  usuarioActualizacion,
  fechaActualizacion).ToList

        If (consulta.Count > 0) Then
            cajausuarioBL.fechaCierre = consulta(0).Column1
            cajausuarioBL.idEmpresa = consulta(0).idEmpresa
            cajausuarioBL.idEstablecimiento = consulta(0).idEstablecimiento
            cajausuarioBL.idPersona = consulta(0).idPersona
            cajausuarioBL.claveIngreso = consulta(0).claveIngreso
            cajausuarioBL.documentoApertura = consulta(0).documentoApertura
            cajausuarioBL.idCajaOrigen = consulta(0).idCajaOrigen
            cajausuarioBL.idCajaDestino = consulta(0).idCajaDestino
            cajausuarioBL.idCajaCierre = consulta(0).idCajaCierre
            cajausuarioBL.idcajaUsuario = consulta(0).idcajaUsuario
            cajausuarioBL.periodo = consulta(0).periodo
            cajausuarioBL.fechaRegistro = consulta(0).fechaRegistro
            cajausuarioBL.moneda = consulta(0).moneda
            cajausuarioBL.tipoCambio = consulta(0).tipoCambio
            cajausuarioBL.fondoMN = consulta(0).fondoMN
            cajausuarioBL.fondoME = consulta(0).fondoME
            cajausuarioBL.ingresoAdicMN = consulta(0).ingresoAdicMN
            cajausuarioBL.ingresoAdicME = consulta(0).ingresoAdicME
            cajausuarioBL.otrosIngresosMN = consulta(0).otrosIngresosMN
            cajausuarioBL.otrosIngresosME = consulta(0).otrosIngresosME
            cajausuarioBL.otrosEgresosMN = consulta(0).otrosEgresosMN
            cajausuarioBL.otrosEgresosME = consulta(0).otrosEgresosME
            cajausuarioBL.estadoCaja = consulta(0).estadoCaja
            cajausuarioBL.enUso = consulta(0).enUso
            cajausuarioBL.idPadre = consulta(0).idPadre
            cajausuarioBL.usuarioActualizacion = consulta(0).usuarioActualizacion
            cajausuarioBL.fechaActualizacion = consulta(0).fechaActualizacion
        ElseIf (consulta.Count = 0) Then

            Dim consulta2 = (From CajaUsuario In HeliosData.cajaUsuario
                             Where CajaUsuario.idPersona = intIdPersona _
                         And CajaUsuario.estadoCaja = "A" And CajaUsuario.idEmpresa = Gempresas.IdEmpresaRuc _
                         And CajaUsuario.idEstablecimiento = GEstableciento.IdEstablecimiento
                             Group CajaUsuario By CajaUsuario.idcajaUsuario, CajaUsuario.idEmpresa,
                              CajaUsuario.idEstablecimiento,
                              CajaUsuario.idPersona,
                              CajaUsuario.claveIngreso,
                              CajaUsuario.documentoApertura,
                              CajaUsuario.documentoCierre,
                              CajaUsuario.idCajaOrigen,
                              CajaUsuario.idCajaDestino,
                              CajaUsuario.idCajaCierre,
                              CajaUsuario.periodo,
                              CajaUsuario.fechaRegistro,
                              CajaUsuario.moneda,
                              CajaUsuario.tipoCambio,
                              CajaUsuario.fondoMN,
                              CajaUsuario.fondoME,
                              CajaUsuario.ingresoAdicMN,
                              CajaUsuario.ingresoAdicME,
                              CajaUsuario.otrosIngresosMN,
                              CajaUsuario.otrosIngresosME,
                              CajaUsuario.otrosEgresosMN,
                              CajaUsuario.otrosEgresosME,
                              CajaUsuario.estadoCaja,
                              CajaUsuario.enUso,
                              CajaUsuario.idPadre,
                              CajaUsuario.usuarioActualizacion,
                              CajaUsuario.fechaActualizacion
                             Into g = Group Select Column1 = CType(g.Max(Function(p) p.fechaCierre), DateTime?),
idcajaUsuario,
 idEmpresa,
 idEstablecimiento,
 idPersona,
 claveIngreso,
 documentoApertura,
 documentoCierre,
 idCajaOrigen,
 idCajaDestino,
 idCajaCierre,
 periodo,
 fechaRegistro,
 moneda,
 tipoCambio,
 fondoMN,
 fondoME,
 ingresoAdicMN,
 ingresoAdicME,
 otrosIngresosMN,
 otrosIngresosME,
 otrosEgresosMN,
 otrosEgresosME,
 estadoCaja,
 enUso,
 idPadre,
 usuarioActualizacion,
 fechaActualizacion).ToList

            If (consulta2.Count > 0) Then
                cajausuarioBL.fechaCierre = consulta2(0).Column1
                cajausuarioBL.idEmpresa = consulta2(0).idEmpresa
                cajausuarioBL.idEstablecimiento = consulta2(0).idEstablecimiento
                cajausuarioBL.idPersona = consulta2(0).idPersona
                cajausuarioBL.claveIngreso = consulta2(0).claveIngreso
                cajausuarioBL.documentoApertura = consulta2(0).documentoApertura
                cajausuarioBL.idCajaOrigen = consulta2(0).idCajaOrigen
                cajausuarioBL.idCajaDestino = consulta2(0).idCajaDestino
                cajausuarioBL.idCajaCierre = consulta2(0).idCajaCierre
                cajausuarioBL.idcajaUsuario = consulta2(0).idcajaUsuario
                cajausuarioBL.periodo = consulta2(0).periodo
                cajausuarioBL.fechaRegistro = consulta2(0).fechaRegistro
                cajausuarioBL.moneda = consulta2(0).moneda
                cajausuarioBL.tipoCambio = consulta2(0).tipoCambio
                cajausuarioBL.fondoMN = consulta2(0).fondoMN
                cajausuarioBL.fondoME = consulta2(0).fondoME
                cajausuarioBL.ingresoAdicMN = consulta2(0).ingresoAdicMN
                cajausuarioBL.ingresoAdicME = consulta2(0).ingresoAdicME
                cajausuarioBL.otrosIngresosMN = consulta2(0).otrosIngresosMN
                cajausuarioBL.otrosIngresosME = consulta2(0).otrosIngresosME
                cajausuarioBL.otrosEgresosMN = consulta2(0).otrosEgresosMN
                cajausuarioBL.otrosEgresosME = consulta2(0).otrosEgresosME
                cajausuarioBL.estadoCaja = consulta2(0).estadoCaja
                cajausuarioBL.enUso = consulta2(0).enUso
                cajausuarioBL.idPadre = consulta2(0).idPadre
                cajausuarioBL.usuarioActualizacion = consulta2(0).usuarioActualizacion
                cajausuarioBL.fechaActualizacion = consulta2(0).fechaActualizacion
            End If

        End If
        Return cajausuarioBL


    End Function

    Public Function UbicarCajaXPersona(intPersona As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer
        Dim obj As New cajaUsuario
        Dim lista As New List(Of cajaUsuario)

        Dim consulta = (From n In HeliosData.cajaUsuario
                        Where n.idEmpresa = strEmpresa And n.idEstablecimiento = intEstablecimiento _
                       And n.idPersona = intPersona).Count

        Return consulta
    End Function

    Public Function UbicarCajaXIdEntidadOrigen(intEntidadFinan As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer
        Dim obj As New cajaUsuario
        Dim lista As New List(Of cajaUsuario)

        Dim consulta = (From n In HeliosData.cajaUsuario
                        Join d In HeliosData.cajaUsuariodetalle
                        On n.idcajaUsuario Equals d.idcajaUsuario
                        Where n.idEmpresa = strEmpresa And n.idEstablecimiento = intEstablecimiento _
                       And d.idEntidad = intEntidadFinan).Count

        Return consulta
    End Function

    Public Function ObtenerCajaUsuarioFullXpersona(strEmpresa As String, idEstablec As Integer, periodo As String, idPersonal As Integer) As List(Of cajaUsuario)
        Dim objMostrarEncaja As New cajaUsuario
        Dim listaEncaja As New List(Of cajaUsuario)


        Dim consulta2 = (From cd In HeliosData.cajaUsuariodetalle
                         Where
  cd.cajaUsuario.idPersona = CStr(idPersonal) And
  cd.cajaUsuario.idEmpresa = strEmpresa And
  CLng(cd.cajaUsuario.idEstablecimiento) = idEstablec And
  cd.cajaUsuario.periodo = periodo
                         Group cd.cajaUsuario By
  cd.cajaUsuario.idPersona,
  cd.cajaUsuario.fechaRegistro,
  IdcajaUsuario = CType(cd.cajaUsuario.idcajaUsuario, Int32?),
  cd.cajaUsuario.estadoCaja
 Into g = Group
                         Select
  IdcajaUsuario = CType(IdcajaUsuario, Int32?),
  idPersona,
  apeturaMN = CType(g.Sum(Function(p) p.fondoMN), Decimal?),
  estadoCaja,
  fechaRegistro,
  ingreso = (CType((Aggregate t1 In
    (From d In HeliosData.documentoCaja
     Where
      d.idCajaUsuario = IdcajaUsuario And
      d.tipoMovimiento = "DC"
     Select New With {
      d.montoSoles
    }) Into Sum(t1.montoSoles)), Decimal?)),
  egresos = (CType((Aggregate t1 In
    (From d In HeliosData.documentoCaja
     Where
      d.idCajaUsuario = IdcajaUsuario And
      d.tipoMovimiento = "PG"
     Select New With {
      d.montoSoles
    }) Into Sum(t1.montoSoles)), Decimal?))).ToList




        'Dim consulta = (From cajaUsuario In HeliosData.cajaUsuario _
        '                Group cajaUsuario By cajaUsuario.idcajaUsuario, cajaUsuario.idEmpresa, _

        If (Not IsNothing(consulta2)) Then
            For Each i In consulta2
                objMostrarEncaja = New cajaUsuario() With
                             {
                                    .idPersona = i.idPersona,
                                    .idcajaUsuario = i.IdcajaUsuario,
                                     .estadoCaja = i.estadoCaja,
                                    .fechaRegistro = i.fechaRegistro,
                                    .fondoMN = i.apeturaMN.GetValueOrDefault,
                                    .ingresoAdicMN = i.ingreso.GetValueOrDefault,
                                    .otrosEgresosMN = i.egresos.GetValueOrDefault
                                    }
                listaEncaja.Add(objMostrarEncaja)
            Next

        End If
        Return listaEncaja

    End Function

    Public Function VerificarCajaEstadoXUsuario(idPersona As String) As Boolean
        Dim obj As New cajaUsuario
        Dim estado As Boolean
        Dim consulta = (From c In HeliosData.cajaUsuario
                        Where c.idPersona = CStr(idPersona) And
                            c.estadoCaja = "A"
                        Select New With {
                            c.idcajaUsuario
                            }).Count

        If (consulta = 0) Then
            estado = False
        ElseIf (consulta = 1) Then
            estado = True
        End If

        Return estado
    End Function

    Public Function ListadoCajaXEstado(caja As cajaUsuario) As List(Of cajaUsuario)
        Dim cajaBE As New cajaUsuario
        Dim Listacaja As New List(Of cajaUsuario)

        Dim consulta = (From s In HeliosData.ListaPersonasXCaja(caja.estadoCaja, caja.idEmpresa, caja.idEstablecimiento)).ToList

        For Each i In consulta
            cajaBE = New cajaUsuario() With
                             {
                             .idEmpresa = i.idEmpresa,
                             .idEstablecimiento = i.idEstablecimiento,
                             .fechaCierre = i.fechaCierre,
                             .fechaRegistro = i.fechaRegistro,
                                    .idPersona = i.IDUsuario,
                                    .idcajaUsuario = i.idcajaUsuario,
                                     .estadoCaja = i.estadoCaja,
                                    .NombrePersona = i.Nombres & " " & i.ApellidoPaterno & " " & i.ApellidoMaterno,
                                   .numeroDocumento = i.NroDocumento,
                                   .tipoCaja = i.tipoCaja,
                                   .IDRol = i.IDRol
                                     }
            Listacaja.Add(cajaBE)
        Next

        Return Listacaja
    End Function


    Public Function UbicarCajeroIDUsuarioActivaPC(caja As cajaUsuario) As cajaUsuario
        UbicarCajeroIDUsuarioActivaPC = Nothing
        Dim i = HeliosData.cajaUsuario.Where(Function(o) o.idPersona = caja.idPersona And o.estadoCaja = "A" And o.namepc = caja.namepc _
                                              And o.idEmpresa = caja.idEmpresa And o.idEstablecimiento = caja.idEstablecimiento _
                                              And o.IDRol = caja.IDRol And o.tipoCaja = caja.tipoCaja).ToList.SingleOrDefault

        If i IsNot Nothing Then
            UbicarCajeroIDUsuarioActivaPC = New cajaUsuario() With
                             {
                                    .idPersona = i.idPersona,
                                    .idcajaUsuario = i.idcajaUsuario,
                                    .estadoCaja = i.estadoCaja,
                                    .NombrePersona = i.NombrePersona,
                                    .numeroDocumento = i.numeroDocumento,
                                    .namepc = i.namepc,
                                    .IDRol = i.IDRol,
                                    .tipoCaja = i.tipoCaja
                                     }
        End If

    End Function

    Public Function UbicarCajeroIDUsuarioActiva(caja As cajaUsuario) As cajaUsuario
        UbicarCajeroIDUsuarioActiva = Nothing
        Dim i = HeliosData.cajaUsuario.Where(Function(o) o.idPersona = caja.idPersona And o.estadoCaja = "A" And o.idEmpresa = caja.idEmpresa And o.idEstablecimiento = caja.idEstablecimiento).ToList.SingleOrDefault

        If i IsNot Nothing Then
            UbicarCajeroIDUsuarioActiva = New cajaUsuario() With
                             {
                                    .idPersona = i.idPersona,
                                    .idcajaUsuario = i.idcajaUsuario,
                                    .estadoCaja = i.estadoCaja,
                                    .NombrePersona = i.NombrePersona,
                                    .numeroDocumento = i.numeroDocumento
                                     }
        End If

    End Function

#Region "Transporte"
    Public Function CerrarCajaUsuarioTrasnporte(nCajaUsuario As cajaUsuario) As cajaUsuario
        Dim objNuevo As New cajaUsuario()
        Dim docCajaBL As New documentoCajaBL
        Dim cajaEntregaBL As New cajaUsuarioDineroEntregadoBL

        Dim consultaValida = (From n In HeliosData.cajaUsuario
                              Where n.estadoCaja = "C" And
                             n.idcajaUsuario = nCajaUsuario.idcajaUsuario).FirstOrDefault

        If IsNothing(consultaValida) Then
            Using ts As New TransactionScope()

                objNuevo = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = nCajaUsuario.idcajaUsuario).First
                objNuevo.estadoCaja = nCajaUsuario.estadoCaja
                objNuevo.fechaCierre = nCajaUsuario.fechaCierre
                objNuevo.enUso = nCajaUsuario.enUso

                objNuevo.ingresoAdicMN = nCajaUsuario.ingresoAdicMN
                objNuevo.otrosEgresosMN = nCajaUsuario.otrosEgresosMN

                HeliosData.SaveChanges()
                ts.Complete()
                Return objNuevo
            End Using
        Else
            Throw New Exception("La caja ya esta cerrada!")
        End If


    End Function

#End Region


End Class

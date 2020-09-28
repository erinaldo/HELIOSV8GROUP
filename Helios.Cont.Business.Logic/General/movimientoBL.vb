Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports Helios.General.Constantes
Public Class movimientoBL
    Inherits BaseBL

    Public Function TxtPleLibroDiario(periodo As String, empresa As String) As List(Of usp_PleLibroDiario_Result)
        Return HeliosData.usp_PleLibroDiario(periodo, empresa).ToList
    End Function


    Public Function TxtPleLibroDiarioV2(empresa As String, anio As String, mes As String) As List(Of movimiento)
        Dim fechaPeriodo As DateTime
        fechaPeriodo = Format(Now, anio & "-" & mes & "-01")


        Dim objeto As New movimiento
        Dim lista As New List(Of movimiento)

        Dim consulta = (From movimientoes In HeliosData.movimiento
                        Where
                          movimientoes.asiento.fechaProceso.Value.Year = fechaPeriodo.Year And
                          movimientoes.asiento.fechaProceso.Value.Month = fechaPeriodo.Month And
                          movimientoes.asiento.idEmpresa = empresa
                        Group New With {movimientoes, movimientoes.asiento.documento, movimientoes.asiento} By
                          movimientoes.cuenta,
                          movimientoes.asiento.documento.idDocumento,
                          movimientoes.tipo,
                          Column1 = movimientoes.tipo,
                          movimientoes.asiento.periodo,
                          movimientoes.asiento.documento.entidad,
                          movimientoes.asiento.documento.tipoEntidad,
                          movimientoes.asiento.documento.nrodocEntidad,
                          fechaProceso = CType(movimientoes.asiento.fechaProceso, DateTime?),
                          movimientoes.asiento.documento.nroDoc,
                          movimientoes.asiento.documento.tipoDoc,
                          movimientoes.asiento.glosa,
                          movimientoes.asiento.documento.moneda,
                          movimientoes.asiento.documento.idEntidad,
                          movimientoes.asiento.idAsiento
                 Into g = Group
                        Order By
                          idAsiento,
                          idDocumento,
                          tipo,
                          cuenta
                        Select
                          idAsiento,
                          idDocumento,
                          nroDoc,
                          cuenta,
                          tipo,
                          monto = CType(g.Sum(Function(p) p.movimientoes.monto), Decimal?),
                          montoUSD = CType(g.Sum(Function(p) p.movimientoes.montoUSD), Decimal?),
                          periodo,
                          entidad,
                          tipoEntidad,
                          nrodocEntidad,
                          fechaProceso = CType(fechaProceso, DateTime?),
                          tipoDoc,
                          glosa,
                          moneda,
                          idEntidad,
                          docEntidad = If(tipoEntidad = "PR",
                                         ((From entidads In HeliosData.entidad
                                           Where
                                         entidads.idEntidad = idEntidad
                                           Select New With {
                                         entidads.tipoDoc
                                         }).FirstOrDefault().tipoDoc),
                                         If(tipoEntidad = "CL",
                                         ((From entidads In HeliosData.entidad
                                           Where
                                         entidads.idEntidad = idEntidad
                                           Select New With {
                                         entidads.tipoDoc
                                         }).FirstOrDefault().tipoDoc), Nothing)),
                                         nroDocNuevo = If(
                                         tipoEntidad = "PR",
                                         ((From entidads In HeliosData.entidad
                                           Where
                                         entidads.idEntidad = idEntidad
                                           Select New With {
                                         entidads.nrodoc
                                         }).FirstOrDefault().nrodoc), If(
                                         tipoEntidad = "CL",
                                         ((From entidads In HeliosData.entidad
                                           Where
                                         entidads.idEntidad = idEntidad
                                           Select New With {
                                         entidads.nrodoc
                                         }).FirstOrDefault().nrodoc), Nothing))).ToList

        For Each i In consulta
            objeto = New movimiento
            objeto.idAsiento = i.idAsiento
            objeto.idDocumento = i.idDocumento
            objeto.cuenta = i.cuenta
            objeto.tipo = i.tipo
            objeto.monto = i.monto
            objeto.montoUSD = i.montoUSD
            objeto.periodo = i.periodo
            objeto.entidad = i.entidad
            objeto.tipoEntidad = i.tipoEntidad
            objeto.nrodocEntidad = i.nroDocNuevo
            objeto.fechaProceso = i.fechaProceso
            objeto.nroDoc = i.nroDoc
            objeto.tipoDoc = i.tipoDoc
            objeto.glosa = i.glosa
            objeto.moneda = i.moneda
            objeto.idEntidad = i.idEntidad
            objeto.docEntidad = i.docEntidad

            lista.Add(objeto)

        Next

        Return lista
    End Function

    Public Function CuentaOtrosIngresoMensual(anioPeriodo As String, mesPeriodo As String, EmpresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.entidad
                            Where tip.idEmpresa = EmpresaId
                            Select
                        tip.idEmpresa, tip.nombreCompleto,
                        DEBE77 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("77") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER77 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("77") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE75 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("75") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER75 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("75") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE76 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("76") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER76 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("76") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
     DEBE77CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("77") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER77CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("77") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE75CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("75") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER75CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("75") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE76CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("76") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER76CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("76") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "77"
                obj.debeSaldoS = consulta.DEBE77.GetValueOrDefault + consulta.DEBE77CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER77.GetValueOrDefault + consulta.HABER77CIERRE.GetValueOrDefault

                obj.debe75 = consulta.DEBE75.GetValueOrDefault + consulta.DEBE75CIERRE.GetValueOrDefault
                obj.haber75 = consulta.HABER75.GetValueOrDefault + consulta.HABER75CIERRE.GetValueOrDefault

                obj.debe76 = consulta.DEBE76.GetValueOrDefault + consulta.DEBE76CIERRE.GetValueOrDefault
                obj.haber76 = consulta.HABER76.GetValueOrDefault + consulta.HABER76CIERRE.GetValueOrDefault



                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "77"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0

                obj.debe75 = 0
                obj.haber75 = 0

                obj.debe76 = 0
                obj.haber76 = 0



                obj.monto = 0
            End If


        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function InsertDefaultCosteo(ByVal nMovimiento As movimiento, intIdAsiento As Integer) As Integer
        Dim nMovimientos As New movimiento
        Using ts As New TransactionScope
            'Se inserta asiento
            With nMovimientos
                nMovimientos.idAsiento = intIdAsiento
                nMovimientos.cuenta = nMovimiento.cuenta
                nMovimientos.descripcion = nMovimiento.descripcion
                nMovimientos.tipo = nMovimiento.tipo
                nMovimientos.monto = nMovimiento.monto
                nMovimientos.montoUSD = nMovimiento.montoUSD
                nMovimientos.fechaActualizacion = nMovimiento.fechaActualizacion
                nMovimientos.usuarioActualizacion = nMovimiento.usuarioActualizacion
                nMovimientos.tipoCosto = nMovimiento.tipoCosto
                nMovimientos.idCosto = nMovimiento.idCosto
            End With
            HeliosData.movimiento.Add(nMovimientos)
            HeliosData.SaveChanges()
            ts.Complete()
            Return nMovimientos.idmovimiento
        End Using
    End Function


    Public Function CuentaUtilidadOperativaMensual(anioPeriodo As String, mesPeriodo As String, EmpresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.entidad
                            Where tip.idEmpresa = EmpresaId
                            Select
                        tip.idEmpresa, tip.nombreCompleto,
                        DEBE94 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("94") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER94 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("94") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE95 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("95") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER95 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("95") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE97 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("97") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER97 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("97") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE94CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("94") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER94CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("94") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE95CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("95") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER95CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("95") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE97CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("97") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER97CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("97") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "695"
                obj.debeSaldoS = consulta.DEBE94.GetValueOrDefault + consulta.DEBE94CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER94.GetValueOrDefault + consulta.HABER94CIERRE.GetValueOrDefault

                obj.debe95 = consulta.DEBE95.GetValueOrDefault + consulta.DEBE95CIERRE.GetValueOrDefault
                obj.haber95 = consulta.HABER95.GetValueOrDefault + consulta.HABER95CIERRE.GetValueOrDefault

                obj.debe97 = consulta.DEBE97.GetValueOrDefault + consulta.DEBE97CIERRE.GetValueOrDefault
                obj.haber97 = consulta.HABER97.GetValueOrDefault + consulta.HABER97CIERRE.GetValueOrDefault

                obj.monto = 0
            Else

                obj = New movimiento
                obj.cuenta = "695"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0

                obj.debe95 = 0
                obj.haber95 = 0

                obj.debe97 = 0
                obj.haber97 = 0

                obj.monto = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaCostoVentaMensual(anioPeriodo As String, mesPeriodo As String, EmpresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.entidad
                            Where tip.idEmpresa = EmpresaId
                            Select
                        tip.idEmpresa, tip.nombreCompleto,
                        DEBE692 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("692") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER692 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("692") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE693 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("693") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER693 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("693") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE694 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("694") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER694 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("694") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE695 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("695") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER695 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("695") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE692CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("692") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER692CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("692") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE693CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("693") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER693CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("693") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE694CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.periodo = periodo_Anterior And w.cuenta.StartsWith("694") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER694CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("694") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE695CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("695") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER695CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("695") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "695"
                obj.debeSaldoS = consulta.DEBE692.GetValueOrDefault + consulta.DEBE692CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER692.GetValueOrDefault + consulta.HABER692CIERRE.GetValueOrDefault

                obj.debe693 = consulta.DEBE693.GetValueOrDefault + consulta.DEBE693CIERRE.GetValueOrDefault
                obj.haber693 = consulta.HABER693.GetValueOrDefault + consulta.HABER693CIERRE.GetValueOrDefault

                obj.debe694 = consulta.DEBE694.GetValueOrDefault + consulta.DEBE694CIERRE.GetValueOrDefault
                obj.haber694 = consulta.HABER694.GetValueOrDefault + consulta.HABER694CIERRE.GetValueOrDefault

                obj.debe695 = consulta.DEBE695.GetValueOrDefault + consulta.DEBE695CIERRE.GetValueOrDefault
                obj.haber695 = consulta.HABER695.GetValueOrDefault + consulta.HABER695CIERRE.GetValueOrDefault

                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "695"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0

                obj.debe693 = 0
                obj.haber693 = 0

                obj.debe694 = 0
                obj.haber694 = 0

                obj.debe695 = 0
                obj.haber695 = 0

                obj.monto = 0
            End If


        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function




    Public Function CuentaVentasNetas2Mensual(anioPeriodo As String, mesPeriodo As String, EmpresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)


        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.entidad
                            Where tip.idEmpresa = EmpresaId
                            Select
                        tip.idEmpresa, tip.nombreCompleto,
                        DEBE709 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("709") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER709 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("709") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE73 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("73") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER73 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                       asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("73") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE74 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("74") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER74 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("74") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE691 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("691") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER691 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = EmpresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("691") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE709CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("709") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER709CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("709") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE73CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("73") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER73CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                       m.periodo = periodo_Anterior And m.cuenta.StartsWith("73") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE74CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("74") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER74CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("74") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE691CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("691") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER691CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("691") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault



            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = consulta.DEBE709.GetValueOrDefault + consulta.DEBE709CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER709.GetValueOrDefault + consulta.HABER709CIERRE.GetValueOrDefault
                obj.debe73 = consulta.DEBE73.GetValueOrDefault + consulta.DEBE73CIERRE.GetValueOrDefault
                obj.haber73 = consulta.HABER73.GetValueOrDefault + consulta.HABER73CIERRE.GetValueOrDefault

                obj.debe74 = consulta.DEBE74.GetValueOrDefault + consulta.DEBE74CIERRE.GetValueOrDefault
                obj.haber74 = consulta.HABER74.GetValueOrDefault + consulta.HABER74CIERRE.GetValueOrDefault

                obj.debe691 = consulta.DEBE691.GetValueOrDefault + consulta.DEBE691CIERRE.GetValueOrDefault
                obj.haber691 = consulta.HABER691.GetValueOrDefault + consulta.HABER691CIERRE.GetValueOrDefault

                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe73 = 0
                obj.haber73 = 0

                obj.debe74 = 0
                obj.haber74 = 0

                obj.debe691 = 0
                obj.haber691 = 0

                obj.monto = 0

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function



    Public Function CuentaVentasNetasMensual(anioPeriodo As String, mesPeriodo As String, empresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)


        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year



        Try


            Dim consulta = (From tip In HeliosData.entidad
                            Where tip.idEmpresa = empresaId
                            Select
                        tip.idEmpresa, tip.nombreCompleto,
                        DEBE701 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = empresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("701") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER701 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = empresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("701") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE702 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = empresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("702") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER702 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = empresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("702") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE703 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = empresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("703") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER703 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = empresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("703") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE704 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = empresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And w.cuenta.StartsWith("704") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER704 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = empresaId And
                        asiento.fechaProceso.Value.Year = FechaAct.Year And asiento.fechaProceso.Value.Month = FechaAct.Month And m.cuenta.StartsWith("704") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
     DEBE701CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = empresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("701") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER701CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = empresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("701") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE702CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = empresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("702") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER702CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = empresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("702") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE703CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = empresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("703") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER703CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = empresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("703") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE704CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = empresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("704") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER704CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = empresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("704") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = consulta.DEBE701.GetValueOrDefault + consulta.DEBE701CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER701.GetValueOrDefault + consulta.HABER701CIERRE.GetValueOrDefault
                obj.debe702 = consulta.DEBE702.GetValueOrDefault + consulta.DEBE702CIERRE.GetValueOrDefault
                obj.haber702 = consulta.HABER702.GetValueOrDefault + consulta.HABER702CIERRE.GetValueOrDefault

                obj.debe703 = consulta.DEBE703.GetValueOrDefault + consulta.DEBE703CIERRE.GetValueOrDefault
                obj.haber703 = consulta.HABER703.GetValueOrDefault + consulta.HABER703CIERRE.GetValueOrDefault

                obj.debe704 = consulta.DEBE704.GetValueOrDefault + consulta.DEBE704CIERRE.GetValueOrDefault
                obj.haber704 = consulta.HABER704.GetValueOrDefault + consulta.HABER704CIERRE.GetValueOrDefault

                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe702 = 0
                obj.haber702 = 0

                obj.debe703 = 0
                obj.haber703 = 0

                obj.debe704 = 0
                obj.haber704 = 0

                obj.monto = 0
            End If



        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function



    Public Function GetCierreContablePeriodo(be As asiento, periodoAnt As String) As List(Of movimiento)

        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)
        Dim fechaActual = GetPeriodoConvertirToDate(be.periodo)

        Dim consulta = (From m In HeliosData.movimiento
                        Join ast In HeliosData.asiento
                            On ast.idAsiento Equals m.idAsiento
                        Where
                            ast.idEmpresa = be.idEmpresa And
                            ast.idCentroCostos = be.idCentroCostos
                        Select New With
                             {
                             m.cuenta,
                             m.tipo,
                             .montoCierreMN = (From c In HeliosData.cierrecontable
                                               Where
                                                  c.periodo = periodoAnt And
                                                  c.cuenta = m.cuenta And
                                                  c.tipoasiento = m.tipo
                                               Select New With
                                                            {
                                                            c.monto
                                                            }).FirstOrDefault().monto,
                             .montoCierreME = (From c In HeliosData.cierrecontable
                                               Where
                                                  c.periodo = periodoAnt And
                                                  c.cuenta = m.cuenta And
                                                  c.tipoasiento = m.tipo
                                               Select New With
                                                            {
                                                            c.montoUSD
                                                            }).FirstOrDefault().montoUSD,
                             .MN_acual = (Aggregate c In HeliosData.movimiento
                                          Join a In HeliosData.asiento
                                                 On a.idAsiento Equals c.idAsiento
                                          Where
                                             a.fechaProceso.Value.Year = fechaActual.Year And
                                             a.fechaProceso.Value.Month = fechaActual.Month And
                                             c.cuenta = m.cuenta And
                                             c.tipo = m.tipo
                                          Into Sum(c.monto)),
                             .ME_acual = (Aggregate c In HeliosData.movimiento
                                          Join a In HeliosData.asiento
                                                 On a.idAsiento Equals c.idAsiento
                                          Where
                                             a.fechaProceso.Value.Year = fechaActual.Year And
                                             a.fechaProceso.Value.Month = fechaActual.Month And
                                             c.cuenta = m.cuenta And
                                             c.tipo = m.tipo
                                          Into Sum(c.montoUSD))}).Distinct.ToList

        'Dim consulta = (From m In HeliosData.movimiento
        '                Join ast In HeliosData.asiento
        '                    On ast.idAsiento Equals m.idAsiento
        '                Where
        '                    ast.idEmpresa = be.idEmpresa
        '                Select New With
        '                     {
        '                     m.cuenta,
        '                     m.tipo,
        '                     .montoCierreMN = (From c In HeliosData.cierrecontable
        '                                       Where
        '                                          c.periodo = periodoAnt And
        '                                          c.cuenta = m.cuenta And
        '                                          c.tipoasiento = m.tipo
        '                                       Select New With
        '                                                    {
        '                                                    c.monto
        '                                                    }).FirstOrDefault().monto,
        '                     .montoCierreME = (From c In HeliosData.cierrecontable
        '                                       Where
        '                                          c.periodo = periodoAnt And
        '                                          c.cuenta = m.cuenta And
        '                                          c.tipoasiento = m.tipo
        '                                       Select New With
        '                                                    {
        '                                                    c.montoUSD
        '                                                    }).FirstOrDefault().montoUSD,
        '                     .MN_acual = (Aggregate c In HeliosData.movimiento
        '                                  Join a In HeliosData.asiento
        '                                         On a.idAsiento Equals c.idAsiento
        '                                  Where
        '                                     a.periodo = be.periodo And
        '                                     c.cuenta = m.cuenta And
        '                                     c.tipo = m.tipo
        '                                  Into Sum(c.monto)),
        '                     .ME_acual = (Aggregate c In HeliosData.movimiento
        '                                  Join a In HeliosData.asiento
        '                                         On a.idAsiento Equals c.idAsiento
        '                                  Where
        '                                     a.periodo = be.periodo And
        '                                     c.cuenta = m.cuenta And
        '                                     c.tipo = m.tipo
        '                                  Into Sum(c.montoUSD))}).Distinct.ToList



        lista = New List(Of movimiento)
        For Each i In consulta
            obj = New movimiento
            obj.cuenta = i.cuenta
            obj.tipo = i.tipo
            obj.Montocero = i.montoCierreMN.GetValueOrDefault
            obj.MontoceroUSD = i.montoCierreME.GetValueOrDefault
            obj.monto = i.MN_acual.GetValueOrDefault
            obj.montoUSD = i.ME_acual.GetValueOrDefault
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function CuentaOtrosIngreso(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.entidad _
                        Where tip.idEmpresa = Gempresas.IdEmpresaRuc _
                        Select
                        tip.idEmpresa, tip.nombreCompleto,
                        DEBE77 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento _
                       On w.idAsiento Equals asiento.idAsiento _
                        Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("77") And w.tipo = "D"
                        Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER77 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento _
                       On m.idAsiento Equals asiento.idAsiento _
                        Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("77") And m.tipo = "H"
                        Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE75 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento _
                       On w.idAsiento Equals asiento.idAsiento _
                        Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("75") And w.tipo = "D"
                        Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER75 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento _
                       On m.idAsiento Equals asiento.idAsiento _
                        Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("75") And m.tipo = "H"
                        Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE76 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento _
                       On w.idAsiento Equals asiento.idAsiento _
                        Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("76") And w.tipo = "D"
                        Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER76 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento _
                       On m.idAsiento Equals asiento.idAsiento _
                        Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("76") And m.tipo = "H"
                        Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
     DEBE77CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                        Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("77") And w.tipoasiento = "D"
                        Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER77CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                        Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("77") And m.tipoasiento = "H"
                        Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE75CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                        Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("75") And w.tipoasiento = "D"
                        Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER75CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                        Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("75") And m.tipoasiento = "H"
                        Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE76CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                        Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("76") And w.tipoasiento = "D"
                        Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER76CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                        Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("76") And m.tipoasiento = "H"
                        Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "77"
                obj.debeSaldoS = consulta.DEBE77.GetValueOrDefault + consulta.DEBE77CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER77.GetValueOrDefault + consulta.HABER77CIERRE.GetValueOrDefault

                obj.debe75 = consulta.DEBE75.GetValueOrDefault + consulta.DEBE75CIERRE.GetValueOrDefault
                obj.haber75 = consulta.HABER75.GetValueOrDefault + consulta.HABER75CIERRE.GetValueOrDefault

                obj.debe76 = consulta.DEBE76.GetValueOrDefault + consulta.DEBE76CIERRE.GetValueOrDefault
                obj.haber76 = consulta.HABER76.GetValueOrDefault + consulta.HABER76CIERRE.GetValueOrDefault



                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "77"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0

                obj.debe75 = 0
                obj.haber75 = 0

                obj.debe76 = 0
                obj.haber76 = 0



                obj.monto = 0
            End If


        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaUtilidadOperativa(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.entidad
                            Where tip.idEmpresa = Gempresas.IdEmpresaRuc
                            Select
                        tip.idEmpresa, tip.nombreCompleto,
                        DEBE94 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("94") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER94 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("94") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE95 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("95") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER95 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("95") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE97 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("97") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER97 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("97") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE94CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("94") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER94CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("94") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE95CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("95") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER95CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("95") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE97CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("97") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER97CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("97") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "695"
                obj.debeSaldoS = consulta.DEBE94.GetValueOrDefault + consulta.DEBE94CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER94.GetValueOrDefault + consulta.HABER94CIERRE.GetValueOrDefault

                obj.debe95 = consulta.DEBE95.GetValueOrDefault + consulta.DEBE95CIERRE.GetValueOrDefault
                obj.haber95 = consulta.HABER95.GetValueOrDefault + consulta.HABER95CIERRE.GetValueOrDefault

                obj.debe97 = consulta.DEBE97.GetValueOrDefault + consulta.DEBE97CIERRE.GetValueOrDefault
                obj.haber97 = consulta.HABER97.GetValueOrDefault + consulta.HABER97CIERRE.GetValueOrDefault

                obj.monto = 0
            Else

                obj = New movimiento
                obj.cuenta = "695"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0

                obj.debe95 = 0
                obj.haber95 = 0

                obj.debe97 = 0
                obj.haber97 = 0

                obj.monto = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaCostoVenta(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.entidad
                            Where tip.idEmpresa = Gempresas.IdEmpresaRuc
                            Select
                        tip.idEmpresa, tip.nombreCompleto,
                        DEBE692 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("692") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER692 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("692") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE693 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("693") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER693 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("693") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE694 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("694") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER694 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("694") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE695 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("695") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER695 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("695") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE692CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("692") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER692CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("692") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE693CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("693") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER693CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("693") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE694CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Anterior And w.cuenta.StartsWith("694") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER694CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("694") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE695CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("695") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER695CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("695") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "695"
                obj.debeSaldoS = consulta.DEBE692.GetValueOrDefault + consulta.DEBE692CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER692.GetValueOrDefault + consulta.HABER692CIERRE.GetValueOrDefault

                obj.debe693 = consulta.DEBE693.GetValueOrDefault + consulta.DEBE693CIERRE.GetValueOrDefault
                obj.haber693 = consulta.HABER693.GetValueOrDefault + consulta.HABER693CIERRE.GetValueOrDefault

                obj.debe694 = consulta.DEBE694.GetValueOrDefault + consulta.DEBE694CIERRE.GetValueOrDefault
                obj.haber694 = consulta.HABER694.GetValueOrDefault + consulta.HABER694CIERRE.GetValueOrDefault

                obj.debe695 = consulta.DEBE695.GetValueOrDefault + consulta.DEBE695CIERRE.GetValueOrDefault
                obj.haber695 = consulta.HABER695.GetValueOrDefault + consulta.HABER695CIERRE.GetValueOrDefault

                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "695"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0

                obj.debe693 = 0
                obj.haber693 = 0

                obj.debe694 = 0
                obj.haber694 = 0

                obj.debe695 = 0
                obj.haber695 = 0

                obj.monto = 0
            End If


        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function


    Public Function CuentaVentasNetas2(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)


        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.entidad
                            Where tip.idEmpresa = Gempresas.IdEmpresaRuc
                            Select
                        tip.idEmpresa, tip.nombreCompleto,
                        DEBE709 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("709") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER709 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("709") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE73 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("73") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER73 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                       asiento.periodo = periodo_Actual And m.cuenta.StartsWith("73") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE74 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("74") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER74 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("74") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE691 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("691") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER691 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("691") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE709CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("709") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER709CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("709") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE73CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("73") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER73CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                       m.periodo = periodo_Anterior And m.cuenta.StartsWith("73") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE74CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("74") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER74CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("74") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE691CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("691") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER691CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("691") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault



            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = consulta.DEBE709.GetValueOrDefault + consulta.DEBE709CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER709.GetValueOrDefault + consulta.HABER709CIERRE.GetValueOrDefault
                obj.debe73 = consulta.DEBE73.GetValueOrDefault + consulta.DEBE73CIERRE.GetValueOrDefault
                obj.haber73 = consulta.HABER73.GetValueOrDefault + consulta.HABER73CIERRE.GetValueOrDefault

                obj.debe74 = consulta.DEBE74.GetValueOrDefault + consulta.DEBE74CIERRE.GetValueOrDefault
                obj.haber74 = consulta.HABER74.GetValueOrDefault + consulta.HABER74CIERRE.GetValueOrDefault

                obj.debe691 = consulta.DEBE691.GetValueOrDefault + consulta.DEBE691CIERRE.GetValueOrDefault
                obj.haber691 = consulta.HABER691.GetValueOrDefault + consulta.HABER691CIERRE.GetValueOrDefault

                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe73 = 0
                obj.haber73 = 0

                obj.debe74 = 0
                obj.haber74 = 0

                obj.debe691 = 0
                obj.haber691 = 0

                obj.monto = 0

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaVentasNetas(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)


        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year



        Try


            Dim consulta = (From tip In HeliosData.entidad
                            Where tip.idEmpresa = Gempresas.IdEmpresaRuc
                            Select
                        tip.idEmpresa, tip.nombreCompleto,
                        DEBE701 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("701") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER701 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("701") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE702 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("702") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER702 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("702") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE703 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("703") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER703 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("703") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE704 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("704") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER704 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("704") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
     DEBE701CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("701") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER701CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("701") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE702CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("702") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER702CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("702") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE703CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("703") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER703CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("703") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE704CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("704") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER704CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Actual And m.cuenta.StartsWith("704") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = consulta.DEBE701.GetValueOrDefault + consulta.DEBE701CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER701.GetValueOrDefault + consulta.HABER701CIERRE.GetValueOrDefault
                obj.debe702 = consulta.DEBE702.GetValueOrDefault + consulta.DEBE702CIERRE.GetValueOrDefault
                obj.haber702 = consulta.HABER702.GetValueOrDefault + consulta.HABER702CIERRE.GetValueOrDefault

                obj.debe703 = consulta.DEBE703.GetValueOrDefault + consulta.DEBE703CIERRE.GetValueOrDefault
                obj.haber703 = consulta.HABER703.GetValueOrDefault + consulta.HABER703CIERRE.GetValueOrDefault

                obj.debe704 = consulta.DEBE704.GetValueOrDefault + consulta.DEBE704CIERRE.GetValueOrDefault
                obj.haber704 = consulta.HABER704.GetValueOrDefault + consulta.HABER704CIERRE.GetValueOrDefault

                obj.monto = 0
            Else

                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe702 = 0
                obj.haber702 = 0
                obj.debe703 = 0
                obj.haber703 = 0
                obj.debe704 = 0
                obj.haber704 = 0
                obj.monto = 0

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaAnticipos(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = Gempresas.IdEmpresaRuc
                            Select
                        tip.idEmpresa, tip.razonSocial,
                        DEBE422 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("422") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER422 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("422") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE432 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("432") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER432 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("432") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE122 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("122") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER122 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("122") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE132 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("132") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER132 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("132") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE422CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("422") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER422CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("422") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE432CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("432") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER432CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("432") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE122CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("122") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER122CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("122") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE132CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("132") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER132CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("132") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault



            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = consulta.DEBE422.GetValueOrDefault + consulta.DEBE422CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER422.GetValueOrDefault + consulta.HABER422CIERRE.GetValueOrDefault
                obj.debe432 = consulta.DEBE432.GetValueOrDefault + consulta.DEBE432CIERRE.GetValueOrDefault
                obj.haber432 = consulta.HABER432.GetValueOrDefault + consulta.HABER432CIERRE.GetValueOrDefault

                obj.debe122 = consulta.DEBE122.GetValueOrDefault + consulta.DEBE122CIERRE.GetValueOrDefault
                obj.haber122 = consulta.HABER122.GetValueOrDefault + consulta.HABER122CIERRE.GetValueOrDefault

                obj.debe132 = consulta.DEBE132.GetValueOrDefault + consulta.DEBE132CIERRE.GetValueOrDefault
                obj.haber132 = consulta.HABER132.GetValueOrDefault + consulta.HABER132CIERRE.GetValueOrDefault

                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe432 = 0
                obj.haber432 = 0

                obj.debe122 = 0
                obj.haber122 = 0

                obj.debe132 = 0
                obj.haber132 = 0

                obj.monto = 0

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaCobroComercial(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = Gempresas.IdEmpresaRuc
                            Select
                        tip.idEmpresa, tip.razonSocial,
                        DEBE12 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("12") And Not w.cuenta.StartsWith("122") And Not w.cuenta.StartsWith("123") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER12 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("12") And Not m.cuenta.StartsWith("122") And Not m.cuenta.StartsWith("123") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE13 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("13") And Not w.cuenta.StartsWith("132") And Not w.cuenta.StartsWith("133") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER13 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("13") And Not m.cuenta.StartsWith("132") And Not m.cuenta.StartsWith("133") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE12CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("12") And Not w.cuenta.StartsWith("122") And Not w.cuenta.StartsWith("123") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER12CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("12") And Not m.cuenta.StartsWith("122") And Not m.cuenta.StartsWith("123") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE13CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("13") And Not w.cuenta.StartsWith("132") And Not w.cuenta.StartsWith("133") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER13CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("13") And Not m.cuenta.StartsWith("132") And Not m.cuenta.StartsWith("133") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "12"
                obj.debeSaldoS = consulta.DEBE12.GetValueOrDefault + consulta.DEBE12CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER12.GetValueOrDefault + consulta.HABER12CIERRE.GetValueOrDefault
                obj.debe13 = consulta.DEBE13.GetValueOrDefault + consulta.DEBE13CIERRE.GetValueOrDefault
                obj.haber13 = consulta.HABER13.GetValueOrDefault + consulta.HABER13CIERRE.GetValueOrDefault
                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "12"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe13 = 0
                obj.haber13 = 0
                obj.monto = 0
            End If


        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaPagoLetras(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try

            Dim list As New List(Of String)
            Dim listCobro As New List(Of String)

            list.Add("423")
            list.Add("433")
            listCobro.Add("123")
            listCobro.Add("133")


            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = Gempresas.IdEmpresaRuc
                            Select
                        tip.idEmpresa, tip.razonSocial,
                        DEBE = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And list.Contains(w.cuenta) And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And list.Contains(m.cuenta) And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBELetras = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And listCobro.Contains(w.cuenta) And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABERLetras = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And listCobro.Contains(m.cuenta) And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBECIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And list.Contains(w.cuenta) And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABERCIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And list.Contains(m.cuenta) And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBELetrasCIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And listCobro.Contains(w.cuenta) And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABERLetrasCIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And listCobro.Contains(m.cuenta) And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "423"
                obj.debeSaldoS = consulta.DEBE.GetValueOrDefault + consulta.DEBECIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER.GetValueOrDefault + consulta.HABERCIERRE.GetValueOrDefault
                obj.debeLetra = consulta.DEBELetras.GetValueOrDefault + consulta.DEBELetrasCIERRE.GetValueOrDefault
                obj.haberLetra = consulta.HABERLetras.GetValueOrDefault + consulta.HABERLetrasCIERRE.GetValueOrDefault
                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "423"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debeLetra = 0
                obj.haberLetra = 0
                obj.monto = 0
            End If


        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaPagoComercialRel(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year


        Try


            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = Gempresas.IdEmpresaRuc
                            Select
                        tip.idEmpresa, tip.razonSocial,
                        DEBE12 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("43") And Not w.cuenta.StartsWith("432") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER12 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("43") And Not m.cuenta.StartsWith("432") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE40111 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("40111") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER40111 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("40111") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                      DEBE40 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("40") And Not w.cuenta.StartsWith("40111") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER40 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("40") And Not m.cuenta.StartsWith("40111") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE12CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("43") And Not w.cuenta.StartsWith("432") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER12CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("43") And Not m.cuenta.StartsWith("432") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE40111CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("40111") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER40111CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("40111") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                      DEBE40CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("40") And Not w.cuenta.StartsWith("40111") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER40CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("40") And Not m.cuenta.StartsWith("40111") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault


            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "43"
                obj.debeSaldoS = consulta.DEBE12.GetValueOrDefault + consulta.DEBE12CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER12.GetValueOrDefault + consulta.HABER12CIERRE.GetValueOrDefault
                obj.debe40111 = consulta.DEBE40111.GetValueOrDefault + consulta.DEBE40111CIERRE.GetValueOrDefault
                obj.haber40111 = consulta.HABER40111.GetValueOrDefault + consulta.HABER40111CIERRE.GetValueOrDefault
                obj.debe40 = consulta.DEBE40.GetValueOrDefault + consulta.DEBE40CIERRE.GetValueOrDefault
                obj.haber40 = consulta.HABER40.GetValueOrDefault + consulta.HABER40CIERRE.GetValueOrDefault
                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "43"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe40111 = 0
                obj.haber40111 = 0
                obj.debe40 = 0
                obj.haber40 = 0
                obj.monto = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaPagoComercial(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year



        Try


            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = Gempresas.IdEmpresaRuc
                            Select
                        tip.idEmpresa, tip.razonSocial,
                        DEBE12 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("42") And Not w.cuenta.StartsWith("422") And Not w.cuenta.StartsWith("423") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER12 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("42") And Not m.cuenta.StartsWith("422") And Not m.cuenta.StartsWith("423") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE16 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("16") And Not w.cuenta.StartsWith("1681") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER16 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("16") And Not m.cuenta.StartsWith("1681") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE12CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("42") And Not w.cuenta.StartsWith("422") And Not w.cuenta.StartsWith("423") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER12CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("42") And Not m.cuenta.StartsWith("422") And Not m.cuenta.StartsWith("423") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE16CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("16") And Not w.cuenta.StartsWith("1681") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER16CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("16") And Not m.cuenta.StartsWith("1681") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault




            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "42"
                obj.debeSaldoS = consulta.DEBE12.GetValueOrDefault + consulta.DEBE12CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER12.GetValueOrDefault + consulta.HABER12CIERRE.GetValueOrDefault
                obj.debe16 = consulta.DEBE16.GetValueOrDefault + consulta.DEBE16CIERRE.GetValueOrDefault
                obj.haber16 = consulta.HABER16.GetValueOrDefault + consulta.HABER16CIERRE.GetValueOrDefault
                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "42"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe16 = 0
                obj.haber16 = 0
                obj.monto = 0
            End If


            'If obj.monto < 0 Then
            '    'obj.monto = obj.monto * -1
            '    obj.tipo = "H"
            'Else
            '    obj.tipo = "D"
            'End If


        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaEntregaRendir(asientoBE As asiento) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try

            Dim list As New List(Of String)
            Dim listCobro As New List(Of String)

            list.Add("1413")
            list.Add("1433")
            list.Add("1443")
            list.Add("1681")



            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = Gempresas.IdEmpresaRuc
                            Select
                        tip.idEmpresa, tip.razonSocial,
                        DEBE = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And list.Contains(w.cuenta) And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And list.Contains(m.cuenta) And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                      DEBE14 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And w.cuenta.StartsWith("14") And Not w.cuenta.StartsWith("1413") And Not w.cuenta.StartsWith("1433") And Not w.cuenta.StartsWith("1443") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER14 = (CType((Aggregate t1 In
                        (From m In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On m.idAsiento Equals asiento.idAsiento
                         Where
                        asiento.idEmpresa = Gempresas.IdEmpresaRuc And
                        asiento.periodo = periodo_Actual And m.cuenta.StartsWith("14") And Not m.cuenta.StartsWith("1413") And Not m.cuenta.StartsWith("1433") And Not m.cuenta.StartsWith("1443") And m.tipo = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
     DEBECIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And list.Contains(w.cuenta) And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABERCIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And list.Contains(m.cuenta) And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                      DEBE14CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = Gempresas.IdEmpresaRuc And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("14") And Not w.cuenta.StartsWith("1413") And Not w.cuenta.StartsWith("1433") And Not w.cuenta.StartsWith("1443") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER14CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("14") And Not m.cuenta.StartsWith("1413") And Not m.cuenta.StartsWith("1433") And Not m.cuenta.StartsWith("1443") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "1413"
                obj.debeSaldoS = consulta.DEBE.GetValueOrDefault + consulta.DEBECIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER.GetValueOrDefault + consulta.HABERCIERRE.GetValueOrDefault
                obj.debe14 = consulta.DEBE14.GetValueOrDefault + consulta.DEBE14CIERRE.GetValueOrDefault
                obj.haber14 = consulta.HABER14.GetValueOrDefault + consulta.HABER14CIERRE.GetValueOrDefault
                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "1413"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe14 = 0
                obj.haber14 = 0
                obj.monto = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    ''' <summary>
    ''' Reporte Banance General de Cuentas Contables
    ''' </summary>
    ''' <param name="asientoBE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BalanceGeneralAnual(asientoBE As asiento) As List(Of movimiento)
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = DateTime.Now
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = DateTime.Now

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year


        Try
            Dim con = (From mov In HeliosData.movimiento
                       Join asiento In HeliosData.asiento
                       On mov.idAsiento Equals asiento.idAsiento
                       Where
                       asiento.idEmpresa = Gempresas.IdEmpresaRuc
                       Group mov By
            mov.tipo,
            mov.cuenta
            Into g = Group
                       Select
                       cuenta = cuenta.Substring(1 - 1, 2),
                       TOTAL_DEBE_ANT = (CType((Aggregate t3 In
                                                (From m In HeliosData.movimiento
                                                 Join a In HeliosData.asiento
                                                  On m.idAsiento Equals a.idAsiento
                                                 Where
                                                 a.idEmpresa = Gempresas.IdEmpresaRuc And
                                                 a.periodo = periodo_Actual And
                                                 m.tipo = "D" And
                                                 m.cuenta = cuenta
                                                 Select New With {
                                                     m.monto
                                                 }) Into Sum(t3.monto)), Decimal?)),
                             TOTAL_HABER_ANT = (CType((Aggregate t3 In
                                                       (From m In HeliosData.movimiento
                                                        Join a In HeliosData.asiento
                                                          On m.idAsiento Equals a.idAsiento
                                                        Where
                                                        a.idEmpresa = Gempresas.IdEmpresaRuc And
                                                       a.periodo = periodo_Actual And
                                                        m.tipo = "H" And
                                                        m.cuenta = cuenta
                                                        Select New With {
                                                            m.monto
                                                        }) Into Sum(t3.monto)), Decimal?)),
                                    TOTAL_DEBE_CIERRE = (CType((Aggregate t3 In
                                                (From m In HeliosData.cierrecontable
                                                 Where
                                                 m.idEmpresa = Gempresas.IdEmpresaRuc And
                                                 m.periodo = periodo_Anterior And
                                                 m.tipoasiento = "D" And
                                                 m.cuenta = cuenta
                                                 Select New With {
                                                     m.monto
                                                 }) Into Sum(t3.monto)), Decimal?)),
                             TOTAL_HABER_CIERRE = (CType((Aggregate t3 In
                                                       (From m In HeliosData.cierrecontable
                                                        Where
                                                        m.idEmpresa = Gempresas.IdEmpresaRuc And
                                                        m.periodo = periodo_Anterior And
                                                        m.tipoasiento = "H" And
                                                        m.cuenta = cuenta
                                                        Select New With {
                                                            m.monto
                                                        }) Into Sum(t3.monto)), Decimal?))).Distinct().ToList



            Dim suma = (From n In con
                        Group n By
                      n.cuenta
                      Into g = Group
                        Select New With {.cuenta = cuenta,
                                       g, .SumaDebe = g.Sum(Function(c) c.TOTAL_DEBE_ANT),
                                       .sumaHeber = g.Sum(Function(c) c.TOTAL_HABER_ANT),
                                       .SumaDebeCierre = g.Sum(Function(c) c.TOTAL_DEBE_CIERRE),
                                       .sumaHeberCierre = g.Sum(Function(c) c.TOTAL_HABER_CIERRE)}).ToList


            For Each i In suma
                obj = New movimiento
                obj.cuenta = i.cuenta
                obj.debeSaldoS = i.SumaDebe.GetValueOrDefault + i.SumaDebeCierre.GetValueOrDefault
                obj.haberSaldoS = i.sumaHeber.GetValueOrDefault + i.sumaHeberCierre.GetValueOrDefault
                obj.monto = 0
                If obj.monto < 0 Then

                    obj.tipo = "H"
                Else
                    obj.tipo = "D"
                End If

                lista.Add(obj)
            Next


        Catch ex As Exception
            Throw ex
        End Try
        Return lista
    End Function

    Public Function BuscarCuentasBalance(strPeriodo As Integer) As List(Of movimiento)
        Dim sw As New System.Diagnostics.Stopwatch
        Dim lista2 As New List(Of movimiento)
        Dim montocero As Integer = 0
        Dim objMostrarEncaja As movimiento
        Dim conteo As Integer = 0
        Dim var As String = Nothing

        Dim mov = (From movimiento In HeliosData.movimiento
                       Join asiento In HeliosData.asiento _
                       On movimiento.idAsiento Equals asiento.idAsiento _
                       Join cuenta In HeliosData.cuentaplanContableEmpresa _
                      On cuenta.idEmpresa Equals asiento.idEmpresa _
                       And cuenta.cuenta Equals movimiento.cuenta).ToList

        For Each m In mov
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.cuenta = m.movimiento.cuenta
            objMostrarEncaja.tipo = m.movimiento.tipo
            objMostrarEncaja.monto = m.movimiento.monto
            lista2.Add(objMostrarEncaja)
        Next

        Return lista2
    End Function

    Public Function BuscarCuentasFull(strPeriodo As Integer) As List(Of movimiento)
        Dim sw As New System.Diagnostics.Stopwatch
        Dim lista2 As New List(Of movimiento)
        Dim montocero As Integer = 0
        Dim objMostrarEncaja As movimiento
        Dim conteo As Integer = 0
        Dim var As String = Nothing
        '   Dim cuentaBL As New cuentaplanContableEmpresaBL
        Dim mov = (From movimiento In HeliosData.movimiento
                       Join asiento In HeliosData.asiento _
                       On movimiento.idAsiento Equals asiento.idAsiento _
                      Group Join cuenta In HeliosData.cuentaplanContableEmpresa _
                      On cuenta.idEmpresa Equals asiento.idEmpresa _
                       And cuenta.cuenta Equals movimiento.cuenta _
                        Into ords = Group _
                        From z In ords.DefaultIfEmpty _
                       Where asiento.fechaProceso.Value.Year = (strPeriodo) _
                         Group movimiento By _
                                  movimiento.cuenta _
                                    Into g = Group _
                                  Select New With {
                                                   g, .TotalMN = g.Sum(Function(n) n.monto),
                                                    .TotalME = g.Sum(Function(n) n.montoUSD),
                                                   .cuenta = cuenta}).ToList

        sw = System.Diagnostics.Stopwatch.StartNew()
        For Each m In mov
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.cuenta = m.cuenta
            'objMostrarEncaja.cuentaPadre = m.cuentapadre
            objMostrarEncaja.monto = m.TotalMN
            lista2.Add(objMostrarEncaja)

        Next

        Dim elapsed As Long
        elapsed = sw.ElapsedTicks  ' or sw.ElapsedTicks
        Console.WriteLine("Total query time: {0} ms.", elapsed)

        Return lista2
    End Function

    Public Function RecuperarCierreContableAnteriorHojaTrabajo(intAnio As Integer, intMes As Integer, strCuenta As String) As cierrecontable
        Dim consulta = (From n In HeliosData.cierrecontable _
                       Where n.anio = intAnio And n.mes = intMes _
                       And n.cuenta = strCuenta _
                        Group n By n.cuenta Into g = Group _
                        Select cuenta, _
                        Debe = CType(g.Sum(Function(n) (If(n.tipoasiento = "D", n.monto, 0))), Decimal?),
                        Haber = CType(g.Sum(Function(n) (If(n.tipoasiento = "H", n.monto, 0))), Decimal?)).SingleOrDefault

        Dim cierre As New cierrecontable With {.cuenta = consulta.cuenta,
                                               .monto = consulta.Debe,
                                               .montoUSD = consulta.Haber}

        Return cierre
    End Function

    Public Function RecuperarCierreContableAnterior(intAnio As Integer, intMes As Integer, strCuenta As String) As cierrecontable
        Dim consulta = (From n In HeliosData.cierrecontable _
                       Where n.anio = intAnio And n.mes = intMes _
                       And n.cuenta = strCuenta).SingleOrDefault


        Return consulta
    End Function

    Function RecuperarSumaMovxCuentas(strCuenta As String, intAnio As Integer, intMes As Integer) As movimiento
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0

        Dim consulta = (Aggregate p In HeliosData.asiento _
                   Group Join c In HeliosData.movimiento _
                  On p.idAsiento Equals c.idAsiento _
                  Into ords = Group _
                  From c In ords.DefaultIfEmpty _
                  Where p.idEmpresa = Gempresas.IdEmpresaRuc _
                  And p.fechaProceso.Value.Month = CInt(intMes) _
                  And p.fechaProceso.Value.Year = intAnio _
                  And c.cuenta = strCuenta _
                  Into TotalMontoMN = Sum(c.monto),
                       TotalMontoME = Sum(c.montoUSD))


        totalMN = consulta.TotalMontoMN.GetValueOrDefault
        totalME = consulta.TotalMontoME.GetValueOrDefault

        Return New movimiento With {.monto = totalMN,
                                          .montoUSD = totalME}
    End Function

    Public Function GetObetnerCierrePorPeriodo(strEmpresa As String, intIdEstablecimiento As Integer, anio As Integer, mes As String) As List(Of movimiento)

        Dim cierre As New cierrecontable
        Dim mov As New movimiento
        Dim lista As New List(Of movimiento)
        Dim consulta = (From p In HeliosData.asiento _
                  Group Join c In HeliosData.movimiento _
                 On p.idAsiento Equals c.idAsiento _
                 Into ords = Group _
                 From c In ords.DefaultIfEmpty _
                 Where p.idEmpresa = strEmpresa _
                 And p.fechaProceso.Value.Month = CInt(mes) _
                 And p.fechaProceso.Value.Year = anio _
                 Group c By _
                 c.cuenta, c.tipo _
                 Into g = Group _
                 Select New With {.cuenta = cuenta,
                                  .tipoAsiento = tipo,
        g, .TotalMontoMN = g.Sum(Function(c) c.monto),
         .TotalMontoME = g.Sum(Function(c) c.montoUSD)
                              }
                          ).ToList

        Dim montoMN As Decimal = 0
        Dim montoME As Decimal = 0

        For Each i In consulta
            cierre = RecuperarCierreContableAnterior(AnioGeneral, MesGeneral - 1, i.cuenta)
            If Not IsNothing(cierre) Then
                montoMN = cierre.monto.GetValueOrDefault
                montoME = cierre.montoUSD.GetValueOrDefault
            Else
                montoMN = 0
                montoME = 0
            End If

            Dim c As New movimiento
            c = RecuperarSumaMovxCuentas(i.cuenta, AnioGeneral, MesGeneral)
            montoMN = montoMN + c.monto
            montoME = montoME + c.montoUSD


            mov = New movimiento
            mov.cuenta = i.cuenta
            mov.tipo = i.tipoAsiento
            mov.monto = montoMN
            mov.montoUSD = montoME
            lista.Add(mov)
        Next
        Return lista
    End Function

    Public Function InsertDefault(ByVal nMovimiento As movimiento, intIdAsiento As Integer) As Integer
        Dim nMovimientos As New movimiento
        Using ts As New TransactionScope
            'Se inserta asiento
            With nMovimientos
                nMovimientos.idAsiento = intIdAsiento
                nMovimientos.cuenta = nMovimiento.cuenta
                nMovimientos.descripcion = nMovimiento.descripcion
                nMovimientos.tipo = nMovimiento.tipo
                nMovimientos.monto = nMovimiento.monto
                nMovimientos.montoUSD = nMovimiento.montoUSD
                nMovimientos.fechaActualizacion = nMovimiento.fechaActualizacion
                nMovimientos.usuarioActualizacion = nMovimiento.usuarioActualizacion
            End With
            HeliosData.movimiento.Add(nMovimientos)
            HeliosData.SaveChanges()
            ts.Complete()
            Return nMovimientos.idmovimiento
        End Using
    End Function

    Public Function UbicarMovimientoPorAsiento(intIdAsiento As Integer) As List(Of movimiento)
        Return (From a In HeliosData.movimiento Where a.idAsiento = intIdAsiento Select a).ToList
    End Function


    'Public Function BuscarMovimientosFull(strPeriodo As Integer) As List(Of movimiento)
    '    Dim sw As New System.Diagnostics.Stopwatch
    '    Dim lista2 As New List(Of movimiento)
    '    Dim montocero As Integer = 0
    '    Dim objMostrarEncaja As movimiento
    '    Dim conteo As Integer = 0
    '    Dim var As String = Nothing
    '    Dim cuentaBL As New cuentaplanContableEmpresaBL
    '    Dim mov = (From movimiento In HeliosData.movimiento
    '               Join asiento In HeliosData.asiento _
    '               On movimiento.idAsiento Equals asiento.idAsiento _
    '               Where asiento.fechaProceso.Value.Year = (strPeriodo) _
    '               Group movimiento By _
    '               asiento.idEmpresa,
    '                           movimiento.cuenta,
    '                           movimiento.tipo _
    '                             Into g = Group _
    '                           Select New With {
    '                                            g, .TotalMN = g.Sum(Function(n) n.monto),
    '                                             .TotalME = g.Sum(Function(n) n.montoUSD),
    '                                            .cuenta = cuenta,
    '                                            .tipo = tipo,
    '                                            .idempresa = idEmpresa}).ToList

    '    Dim mov2 = (From movimiento In HeliosData.movimiento
    '                Join asiento In HeliosData.asiento _
    '                On movimiento.idAsiento Equals asiento.idAsiento _
    '                Where asiento.fechaProceso.Value.Year = (strPeriodo) _
    '                And movimiento.tipo = "H"
    '               Group movimiento By _
    '                            asiento.idEmpresa,
    '                           movimiento.cuenta,
    '                           movimiento.tipo _
    '                             Into g = Group _
    '                           Select New With {
    '                                            g, .TotalMN = g.Sum(Function(n) n.monto),
    '                                             .TotalME = g.Sum(Function(n) n.montoUSD),
    '                                            .cuenta = cuenta,
    '                                            .tipo = tipo,
    '                                            .idempresa = idEmpresa}).ToList


    '    sw = System.Diagnostics.Stopwatch.StartNew()

    '    Dim varStruing As cuentaplanContableEmpresa
    '    For Each m In mov
    '        objMostrarEncaja = New movimiento()
    '        varStruing = Nothing
    '        varStruing = cuentaBL.ObtenerCuentaPorID(m.idempresa, m.cuenta)
    '        If IsNothing(varStruing) Then
    '            objMostrarEncaja.descripcion = ("dd")
    '        Else
    '            objMostrarEncaja.descripcion = varStruing.descripcion
    '        End If

    '        objMostrarEncaja.cuenta = m.cuenta
    '        objMostrarEncaja.tipo = m.tipo
    '        For Each m2 In mov2
    '            Select Case m.cuenta
    '                Case Is = m2.cuenta
    '                    If (m2.tipo = "H" And m.tipo = "D") Then
    '                        objMostrarEncaja.monto = m.TotalMN
    '                        objMostrarEncaja.Montocero = m2.TotalMN
    '                        objMostrarEncaja.montoUSD = m.TotalME
    '                        objMostrarEncaja.MontoceroUSD = m2.TotalME
    '                        conteo = m2.cuenta
    '                        lista2.Add(objMostrarEncaja)
    '                    End If
    '            End Select
    '        Next

    '        Select Case m.cuenta
    '            Case Is = m.cuenta
    '                If (m.tipo = "H" And m.cuenta <> conteo) Then
    '                    objMostrarEncaja.monto = montocero
    '                    objMostrarEncaja.Montocero = m.TotalMN
    '                    objMostrarEncaja.montoUSD = montocero
    '                    objMostrarEncaja.MontoceroUSD = m.TotalME
    '                    lista2.Add(objMostrarEncaja)
    '                End If
    '        End Select
    '        If (conteo <> m.cuenta And m.tipo = "D") Then
    '            objMostrarEncaja.monto = m.TotalMN
    '            objMostrarEncaja.Montocero = montocero
    '            objMostrarEncaja.montoUSD = m.TotalME
    '            objMostrarEncaja.MontoceroUSD = montocero
    '            lista2.Add(objMostrarEncaja)
    '        End If
    '    Next

    '    Dim elapsed As Long
    '    elapsed = sw.ElapsedTicks ' or sw.ElapsedTicks
    '    Console.WriteLine("Total query time: {0} ms.", elapsed)

    '    Return lista2
    'End Function

    Public Function BuscarMovimientosFull(strPeriodo As Integer) As List(Of movimiento)
        Dim sw As New System.Diagnostics.Stopwatch
        Dim lista2 As New List(Of movimiento)
        Dim montocero As Integer = 0
        Dim objMostrarEncaja As movimiento
        Dim conteo As Integer = 0
        Dim var As String = Nothing
        '   Dim cuentaBL As New cuentaplanContableEmpresaBL
        Dim mov = (From movimiento In HeliosData.movimiento
                       Join asiento In HeliosData.asiento _
                       On movimiento.idAsiento Equals asiento.idAsiento _
                      Group Join cuenta In HeliosData.cuentaplanContableEmpresa _
                      On cuenta.idEmpresa Equals asiento.idEmpresa _
                       And cuenta.cuenta Equals movimiento.cuenta _
                        Into ords = Group _
                        From z In ords.DefaultIfEmpty _
                       Where asiento.fechaProceso.Value.Year = (strPeriodo) _
                         Group movimiento By _
                                  movimiento.cuenta,
                                  z.descripcion, _
                                  movimiento.tipo _
                                    Into g = Group _
                                  Select New With {
                                                   g, .TotalMN = g.Sum(Function(n) n.monto),
                                                    .TotalME = g.Sum(Function(n) n.montoUSD),
                                                   .cuenta = cuenta,
                                                   .tipo = tipo,
                                                    .descripcion = descripcion}).ToList

        Dim mov2 = (From movimiento In HeliosData.movimiento
                       Join asiento In HeliosData.asiento _
                       On movimiento.idAsiento Equals asiento.idAsiento _
                      Group Join cuenta In HeliosData.cuentaplanContableEmpresa _
                      On cuenta.idEmpresa Equals asiento.idEmpresa _
                       And cuenta.cuenta Equals movimiento.cuenta _
                        Into ords = Group _
                        From z In ords.DefaultIfEmpty _
                       Where asiento.fechaProceso.Value.Year = (strPeriodo) _
                         Group movimiento By _
                                  movimiento.cuenta,
                                  z.descripcion, _
                                  movimiento.tipo _
                                    Into g = Group _
                                  Select New With {
                                                   g, .TotalMN = g.Sum(Function(n) n.monto),
                                                    .TotalME = g.Sum(Function(n) n.montoUSD),
                                                   .cuenta = cuenta,
                                                   .tipo = tipo,
                                                    .descripcion = descripcion}).ToList


        sw = System.Diagnostics.Stopwatch.StartNew()
        '  Dim varStruing As cuentaplanContableEmpresa
        For Each m In mov
            objMostrarEncaja = New movimiento()
            'varStruing = Nothing
            'varStruing = cuentaBL.ObtenerCuentaPorID(m.idempresa, m.cuenta)
            'If IsNothing(varStruing) Then
            '    objMostrarEncaja.descripcion = ("dd")
            'Else
            '    objMostrarEncaja.descripcion = varStruing.descripcion
            'End If
            objMostrarEncaja.descripcion = m.descripcion
            objMostrarEncaja.cuenta = m.cuenta
            objMostrarEncaja.tipo = m.tipo
            For Each m2 In mov2
                Select Case m.cuenta
                    Case Is = m2.cuenta
                        If (m2.tipo = "H" And m.tipo = "D") Then
                            objMostrarEncaja.monto = m.TotalMN
                            objMostrarEncaja.Montocero = m2.TotalMN
                            objMostrarEncaja.montoUSD = m.TotalME
                            objMostrarEncaja.MontoceroUSD = m2.TotalME
                            conteo = m2.cuenta
                            lista2.Add(objMostrarEncaja)
                        End If
                End Select
            Next

            Select Case m.cuenta
                Case Is = m.cuenta
                    If (m.tipo = "H" And m.cuenta <> conteo) Then
                        objMostrarEncaja.monto = montocero
                        objMostrarEncaja.Montocero = m.TotalMN
                        objMostrarEncaja.montoUSD = montocero
                        objMostrarEncaja.MontoceroUSD = m.TotalME
                        lista2.Add(objMostrarEncaja)
                    End If
            End Select
            If (conteo <> m.cuenta And m.tipo = "D") Then
                objMostrarEncaja.monto = m.TotalMN
                objMostrarEncaja.Montocero = montocero
                objMostrarEncaja.montoUSD = m.TotalME
                objMostrarEncaja.MontoceroUSD = montocero
                lista2.Add(objMostrarEncaja)
            End If
        Next

        Dim elapsed As Long
        elapsed = sw.ElapsedTicks  ' or sw.ElapsedTicks
        Console.WriteLine("Total query time: {0} ms.", elapsed)

        Return lista2
    End Function

    Public Function BuscarMovimientosPorMes(strPeriodo As Integer, intMes As Integer) As List(Of movimiento)
        Dim lista2 As New List(Of movimiento)
        Dim montocero As Integer = 0
        Dim objMostrarEncaja As movimiento
        Dim conteo As Integer = 0
        Dim var As String = Nothing
        Dim mov = (From movimiento In HeliosData.movimiento
                    Join asiento In HeliosData.asiento _
                On movimiento.idAsiento Equals asiento.idAsiento _
                Join cuenta In HeliosData.cuentaplanContableEmpresa _
                On cuenta.idEmpresa Equals asiento.idEmpresa _
                And cuenta.cuenta Equals movimiento.cuenta _
                  Where asiento.fechaProceso.Value.Year = (strPeriodo) _
                  And asiento.fechaProceso.Value.Month = (intMes) _
                      Group movimiento By _
                               movimiento.cuenta,
                             cuenta.descripcion, _
                             movimiento.tipo _
                                 Into g = Group _
                               Select New With {
                                                g, .TotalMN = g.Sum(Function(n) n.monto),
                                                 .TotalME = g.Sum(Function(n) n.montoUSD),
                                                .cuenta = cuenta,
                                                .tipo = tipo,
                                                 .descripcion = descripcion}).ToList

        Dim mov2 = (From movimiento In HeliosData.movimiento
                    Join asiento In HeliosData.asiento _
                On movimiento.idAsiento Equals asiento.idAsiento _
                Join cuenta In HeliosData.cuentaplanContableEmpresa _
                On cuenta.idEmpresa Equals asiento.idEmpresa _
                And cuenta.cuenta Equals movimiento.cuenta _
                   Where asiento.fechaProceso.Value.Year = (strPeriodo) _
                  And asiento.fechaProceso.Value.Month = (intMes) _
                And movimiento.tipo = "H"
                 Group movimiento By _
                             movimiento.cuenta,
                           cuenta.descripcion, _
                             movimiento.tipo _
                             Into g = Group _
                             Select New With {
                                              g, .TotalMN = g.Sum(Function(n) n.monto),
                                               .TotalME = g.Sum(Function(n) n.montoUSD),
                                              .cuenta = cuenta,
                                                .tipo = tipo,
                                              .descripcion = descripcion}).ToList

        For Each m In mov
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.descripcion = m.descripcion
            objMostrarEncaja.cuenta = m.cuenta
            objMostrarEncaja.tipo = m.tipo
            For Each m2 In mov2
                Select Case m.cuenta
                    Case Is = m2.cuenta
                        If (m2.tipo = "H" And m.tipo = "D") Then
                            objMostrarEncaja.monto = m.TotalMN
                            objMostrarEncaja.Montocero = m2.TotalMN
                            objMostrarEncaja.montoUSD = m.TotalME
                            objMostrarEncaja.MontoceroUSD = m2.TotalME
                            conteo = m2.cuenta
                            lista2.Add(objMostrarEncaja)
                        End If
                End Select
            Next

            Select Case m.cuenta
                Case Is = m.cuenta
                    If (m.tipo = "H" And m.cuenta <> conteo) Then
                        objMostrarEncaja.monto = montocero
                        objMostrarEncaja.Montocero = m.TotalMN
                        objMostrarEncaja.montoUSD = montocero
                        objMostrarEncaja.MontoceroUSD = m.TotalME
                        lista2.Add(objMostrarEncaja)
                    End If
            End Select
            If (conteo <> m.cuenta And m.tipo = "D") Then
                objMostrarEncaja.monto = m.TotalMN
                objMostrarEncaja.Montocero = montocero
                objMostrarEncaja.montoUSD = m.TotalME
                objMostrarEncaja.MontoceroUSD = montocero
                lista2.Add(objMostrarEncaja)
            End If
        Next
        Return lista2
    End Function

    Public Function BuscarMovimientosPorAcumulado(strFechaDesde As Date, strFechaHasta As Date) As List(Of movimiento)
        Dim lista2 As New List(Of movimiento)
        Dim montocero As Integer = 0
        Dim objMostrarEncaja As movimiento
        Dim conteo As Integer = 0
        Dim var As String = Nothing
        Dim mov = (From movimiento In HeliosData.movimiento
                    Join asiento In HeliosData.asiento _
                On movimiento.idAsiento Equals asiento.idAsiento _
                Join cuenta In HeliosData.cuentaplanContableEmpresa _
                On cuenta.idEmpresa Equals asiento.idEmpresa _
                And cuenta.cuenta Equals movimiento.cuenta _
                  Where asiento.fechaProceso.Value > strFechaDesde _
                    And asiento.fechaProceso.Value < strFechaHasta _
                      Group movimiento By _
                               movimiento.cuenta,
                             cuenta.descripcion, _
                             movimiento.tipo _
                                 Into g = Group _
                               Select New With {
                                                g, .TotalMN = g.Sum(Function(n) n.monto),
                                                 .TotalME = g.Sum(Function(n) n.montoUSD),
                                                .cuenta = cuenta,
                                                .tipo = tipo,
                                                 .descripcion = descripcion}).ToList

        Dim mov2 = (From movimiento In HeliosData.movimiento
                    Join asiento In HeliosData.asiento _
                On movimiento.idAsiento Equals asiento.idAsiento _
                Join cuenta In HeliosData.cuentaplanContableEmpresa _
                On cuenta.idEmpresa Equals asiento.idEmpresa _
                And cuenta.cuenta Equals movimiento.cuenta _
                       Where asiento.fechaProceso.Value > strFechaDesde _
                    And asiento.fechaProceso.Value < strFechaHasta _
                And movimiento.tipo = "H"
                 Group movimiento By _
                             movimiento.cuenta,
                           cuenta.descripcion, _
                             movimiento.tipo _
                             Into g = Group _
                             Select New With {
                                              g, .TotalMN = g.Sum(Function(n) n.monto),
                                               .TotalME = g.Sum(Function(n) n.montoUSD),
                                              .cuenta = cuenta,
                                                .tipo = tipo,
                                              .descripcion = descripcion}).ToList

        For Each m In mov
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.descripcion = m.descripcion
            objMostrarEncaja.cuenta = m.cuenta
            objMostrarEncaja.tipo = m.tipo
            For Each m2 In mov2
                Select Case m.cuenta
                    Case Is = m2.cuenta
                        If (m2.tipo = "H" And m.tipo = "D") Then
                            objMostrarEncaja.monto = m.TotalMN
                            objMostrarEncaja.Montocero = m2.TotalMN
                            objMostrarEncaja.montoUSD = m.TotalME
                            objMostrarEncaja.MontoceroUSD = m2.TotalME
                            conteo = m2.cuenta
                            lista2.Add(objMostrarEncaja)
                        End If
                End Select
            Next

            Select Case m.cuenta
                Case Is = m.cuenta
                    If (m.tipo = "H" And m.cuenta <> conteo) Then
                        objMostrarEncaja.monto = montocero
                        objMostrarEncaja.Montocero = m.TotalMN
                        objMostrarEncaja.montoUSD = montocero
                        objMostrarEncaja.MontoceroUSD = m.TotalME
                        lista2.Add(objMostrarEncaja)
                    End If
            End Select
            If (conteo <> m.cuenta And m.tipo = "D") Then
                objMostrarEncaja.monto = m.TotalMN
                objMostrarEncaja.Montocero = montocero
                objMostrarEncaja.montoUSD = m.TotalME
                objMostrarEncaja.MontoceroUSD = montocero
                lista2.Add(objMostrarEncaja)
            End If
        Next
        Return lista2
    End Function

    Public Function GetUbicarDocumentoDetallePorIdDocumento(strCuenta As String) As List(Of movimiento)
        Dim lista2 As New List(Of movimiento)
        Dim objMostrarEncaja As movimiento
        Dim montocero As Integer = 0
        Dim idAsiento As Integer = 0
        Dim lista = (From mov In HeliosData.movimiento
                 Where mov.cuenta = strCuenta).ToList

        For Each m In lista
            objMostrarEncaja = New movimiento()
            idAsiento = m.idAsiento

            Dim consulta = (From doc In HeliosData.documento
                            Join asiento In HeliosData.asiento
                            On doc.idDocumento Equals asiento.idDocumento
                            Join detalle In HeliosData.tabladetalle
                            On detalle.codigoDetalle Equals asiento.codigoLibro
                            Where asiento.idAsiento = idAsiento _
                            And detalle.idtabla = 8).FirstOrDefault

            objMostrarEncaja.tipo = m.tipo
            objMostrarEncaja.descripcion = m.descripcion
            objMostrarEncaja.fechaActualizacion = m.fechaActualizacion
            objMostrarEncaja.idmovimiento = m.idmovimiento
            objMostrarEncaja.nombreEntidad = consulta.asiento.nombreEntidad
            objMostrarEncaja.nroDoc = consulta.doc.nroDoc
            objMostrarEncaja.origen = consulta.detalle.descripcion

            If (m.tipo = "D") Then
                objMostrarEncaja.monto = m.monto
                objMostrarEncaja.Montocero = montocero

                objMostrarEncaja.montoUSD = m.montoUSD
                objMostrarEncaja.MontoceroUSD = montocero
            Else
                objMostrarEncaja.Montocero = montocero
                objMostrarEncaja.monto = m.monto

                objMostrarEncaja.MontoceroUSD = montocero
                objMostrarEncaja.montoUSD = m.montoUSD

            End If
            lista2.Add(objMostrarEncaja)
        Next
        Return lista2
    End Function

    Public Function GetUbicarMovimiento(strCuenta As String) As List(Of movimiento)
        Dim lista2 As New List(Of movimiento)
        Dim objMostrarEncaja As movimiento

        Dim mov = (From movimiento In HeliosData.movimiento
                   Join asiento In HeliosData.asiento
                   On asiento.idAsiento Equals movimiento.idAsiento
                   Join cuenta In HeliosData.cuentaplanContableEmpresa _
                   On cuenta.cuenta Equals movimiento.cuenta _
                   Where movimiento.cuenta = strCuenta
                   Group movimiento By _
                           movimiento.cuenta,
                            cuenta.descripcion, _
                            asiento.nombreEntidad _
                            Into g = Group _
                            Select New With {.descripcion = descripcion,
                                            .cuenta = cuenta,
                                            .nombreEntidad = nombreEntidad}).ToList

        For Each m In mov
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.cuenta = m.cuenta
            objMostrarEncaja.descripcion = m.descripcion
            objMostrarEncaja.nombreEntidad = m.nombreEntidad

            lista2.Add(objMostrarEncaja)
        Next
        Return lista2
    End Function

    Public Function UbicarAsientoXidDocumento(intIdDocumento As Integer) As List(Of movimiento)
        Dim listaAsiento As New List(Of movimiento)
        Dim movimientos As New movimiento
        Dim consulta = (From n In HeliosData.asiento _
                       Join mov In HeliosData.movimiento _
                       On n.idAsiento Equals mov.idAsiento _
                       Where n.idDocumento = intIdDocumento).ToList

        For Each i In consulta
            movimientos = New movimiento
            movimientos.idmovimiento = i.mov.idmovimiento
            movimientos.idAsiento = i.n.idAsiento
            movimientos.tipoAsiento = i.n.tipoAsiento
            movimientos.fechaActualizacion = i.n.fechaProceso
            movimientos.glosa = i.n.glosa
            movimientos.cuenta = i.mov.cuenta
            movimientos.descripcion = i.mov.descripcion
            movimientos.tipo = i.mov.tipo
            movimientos.monto = i.mov.monto
            movimientos.montoUSD = i.mov.montoUSD

            movimientos.asiento = New asiento
            movimientos.asiento.glosa = i.n.glosa
            listaAsiento.Add(movimientos)
        Next
        Return listaAsiento
    End Function

    Public Function UbicarMovimientosXidDocumento(intIdAsiento As Integer) As List(Of movimiento)
        Return (From mov In HeliosData.movimiento _
                       Where mov.idAsiento = intIdAsiento).ToList

    End Function


    Public Function BalanceGeneralMensual(anioPeriodo As String, mesPeriodo As String, empresaId As String) As List(Of movimiento)
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year


        Try
            Dim con = (From mov In HeliosData.movimiento
                       Join asiento In HeliosData.asiento
                       On mov.idAsiento Equals asiento.idAsiento
                       Where
                       asiento.idEmpresa = empresaId
                       Group mov By
            mov.tipo,
            mov.cuenta
            Into g = Group
                       Select
                       cuenta = cuenta.Substring(1 - 1, 2),
                       TOTAL_DEBE_ANT = (CType((Aggregate t3 In
                                                (From m In HeliosData.movimiento
                                                 Join a In HeliosData.asiento
                                                  On m.idAsiento Equals a.idAsiento
                                                 Where
                                                     a.idEmpresa = empresaId And
                                                     a.fechaProceso.Value.Year = FechaAct.Year And
                                                     a.fechaProceso.Value.Month = FechaAct.Month And
                                                     m.tipo = "D" And
                                                     m.cuenta.StartsWith(cuenta)
                                                 Select New With {
                                                     m.monto
                                                 }) Into Sum(t3.monto)), Decimal?)),
                             TOTAL_HABER_ANT = (CType((Aggregate t3 In
                                                       (From m In HeliosData.movimiento
                                                        Join a In HeliosData.asiento
                                                          On m.idAsiento Equals a.idAsiento
                                                        Where
                                                            a.idEmpresa = empresaId And
                                                            a.fechaProceso.Value.Year = FechaAct.Year And
                                                            a.fechaProceso.Value.Month = FechaAct.Month And
                                                            m.tipo = "H" And
                                                        m.cuenta.StartsWith(cuenta)
                                                        Select New With {
                                                            m.monto
                                                        }) Into Sum(t3.monto)), Decimal?)),
                                    TOTAL_DEBE_CIERRE = (CType((Aggregate t3 In
                                                (From m In HeliosData.cierrecontable
                                                 Where
                                                 m.idEmpresa = empresaId And
                                                 m.periodo = periodo_Anterior And
                                                 m.tipoasiento = "D" And
                                                 m.cuenta.StartsWith(cuenta)
                                                 Select New With {
                                                     m.monto
                                                 }) Into Sum(t3.monto)), Decimal?)),
                             TOTAL_HABER_CIERRE = (CType((Aggregate t3 In
                                                       (From m In HeliosData.cierrecontable
                                                        Where
                                                        m.idEmpresa = empresaId And
                                                        m.periodo = periodo_Anterior And
                                                        m.tipoasiento = "H" And
                                                        m.cuenta.StartsWith(cuenta)
                                                        Select New With {
                                                            m.monto
                                                        }) Into Sum(t3.monto)), Decimal?))).Distinct().ToList



            Dim suma = (From n In con
                        Group n By
                       n.cuenta
                       Into g = Group
                        Select New With {.cuenta = cuenta,
                                         g, .SumaDebe = g.Sum(Function(c) c.TOTAL_DEBE_ANT),
                                         .sumaHeber = g.Sum(Function(c) c.TOTAL_HABER_ANT),
                                         .SumaDebeCierre = g.Sum(Function(c) c.TOTAL_DEBE_CIERRE),
                                         .sumaHeberCierre = g.Sum(Function(c) c.TOTAL_HABER_CIERRE)}).ToList


            For Each i In suma
                obj = New movimiento
                obj.cuenta = i.cuenta
                obj.debeSaldoS = i.SumaDebe.GetValueOrDefault + i.SumaDebeCierre.GetValueOrDefault
                obj.haberSaldoS = i.sumaHeber.GetValueOrDefault + i.sumaHeberCierre.GetValueOrDefault
                obj.monto = 0
                If obj.monto < 0 Then

                    obj.tipo = "H"
                Else
                    obj.tipo = "D"
                End If

                lista.Add(obj)
            Next


        Catch ex As Exception
            Throw ex
        End Try
        Return lista
    End Function

    Public Function CuentaPagoComercialMensual(anioPeriodo As String, mesPeriodo As String, EmpresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try

            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = EmpresaId
                            Select
                                tip.idEmpresa, tip.razonSocial,
                                DEBE12 = (CType((Aggregate t1 In
                                                     (From w In HeliosData.movimiento
                                                      Join asiento In HeliosData.asiento
                                                          On w.idAsiento Equals asiento.idAsiento
                                                      Where
                                                          asiento.idEmpresa = EmpresaId And
                                                          asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                          asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                          w.cuenta.StartsWith("42") And Not w.cuenta.StartsWith("422") And Not w.cuenta.StartsWith("423") And w.tipo = "D"
                                                      Select New With {
                             w.monto
                             }) Into Sum(t1.monto)), Decimal?)),
                                HABER12 = (CType((Aggregate t1 In
                                                      (From m In HeliosData.movimiento
                                                       Join asiento In HeliosData.asiento
                                                           On m.idAsiento Equals asiento.idAsiento
                                                       Where
                                                           asiento.idEmpresa = EmpresaId And
                                                           asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                          asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                           m.cuenta.StartsWith("42") And Not m.cuenta.StartsWith("422") And Not m.cuenta.StartsWith("423") And m.tipo = "H"
                                                       Select New With {
                                                           m.monto
                                                           }) Into Sum(t1.monto)), Decimal?)),
                                DEBE16 = (CType((Aggregate t1 In
                                                     (From w In HeliosData.movimiento
                                                      Join asiento In HeliosData.asiento
                                                          On w.idAsiento Equals asiento.idAsiento
                                                      Where
                                                          asiento.idEmpresa = EmpresaId And
                                                          asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                          asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                          w.cuenta.StartsWith("16") And Not w.cuenta.StartsWith("1681") And w.tipo = "D"
                                                      Select New With {
                                                          w.monto
                                                          }) Into Sum(t1.monto)), Decimal?)),
                                HABER16 = (CType((Aggregate t1 In
                                                      (From m In HeliosData.movimiento
                                                       Join asiento In HeliosData.asiento
                                                           On m.idAsiento Equals asiento.idAsiento
                                                       Where
                                                           asiento.idEmpresa = EmpresaId And
                                                           asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                           asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                           m.cuenta.StartsWith("16") And Not m.cuenta.StartsWith("1681") And m.tipo = "H"
                                                       Select New With {
                                                           m.monto
                                                           }) Into Sum(t1.monto)), Decimal?)),
                                DEBE12CIERRE = (CType((Aggregate t1 In
                                                           (From w In HeliosData.cierrecontable
                                                            Where
                                                                w.idEmpresa = EmpresaId And
                                                                w.periodo = periodo_Anterior And 
                                                                w.cuenta.StartsWith("42") And Not w.cuenta.StartsWith("422") And Not w.cuenta.StartsWith("423") And w.tipoasiento = "D"
                                                            Select New With {
                                                                w.monto
                                                                }) Into Sum(t1.monto)), Decimal?)),
                                HABER12CIERRE = (CType((Aggregate t1 In
                                                            (From m In HeliosData.cierrecontable
                                                             Where
                                                                 m.idEmpresa = EmpresaId And
                                                                 m.periodo = periodo_Anterior And m.cuenta.StartsWith("42") And Not m.cuenta.StartsWith("422") And Not m.cuenta.StartsWith("423") And m.tipoasiento = "H"
                                                             Select New With {
                                                                 m.monto
                                                                 }) Into Sum(t1.monto)), Decimal?)),
                                DEBE16CIERRE = (CType((Aggregate t1 In
                                                           (From w In HeliosData.cierrecontable
                                                            Where
                                                                w.idEmpresa = EmpresaId And
                                                                w.periodo = periodo_Anterior And w.cuenta.StartsWith("16") And Not w.cuenta.StartsWith("1681") And w.tipoasiento = "D"
                                                            Select New With {
                                                                w.monto
                                                                }) Into Sum(t1.monto)), Decimal?)),
                                HABER16CIERRE = (CType((Aggregate t1 In
                                                            (From m In HeliosData.cierrecontable
                                                             Where
                                                                 m.idEmpresa = EmpresaId And
                                                                 m.periodo = periodo_Anterior And m.cuenta.StartsWith("16") And Not m.cuenta.StartsWith("1681") And m.tipoasiento = "H"
                                                             Select New With {
                                                                 m.monto
                                                                 }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault




            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "42"
                obj.debeSaldoS = consulta.DEBE12.GetValueOrDefault + consulta.DEBE12CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER12.GetValueOrDefault + consulta.HABER12CIERRE.GetValueOrDefault
                obj.debe16 = consulta.DEBE16.GetValueOrDefault + consulta.DEBE16CIERRE.GetValueOrDefault
                obj.haber16 = consulta.HABER16.GetValueOrDefault + consulta.HABER16CIERRE.GetValueOrDefault
                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "42"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe16 = 0
                obj.haber16 = 0
                obj.monto = 0
            End If


            'If obj.monto < 0 Then
            '    'obj.monto = obj.monto * -1
            '    obj.tipo = "H"
            'Else
            '    obj.tipo = "D"
            'End If


        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaPagoComercialRelMensual(anioPeriodo As String, mesPeriodo As String, EmpresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year


        Try


            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = EmpresaId
                            Select
                        tip.idEmpresa, tip.razonSocial,
                        DEBE12 = (CType((Aggregate t1 In
                        (From w In HeliosData.movimiento
                         Join asiento In HeliosData.asiento
                       On w.idAsiento Equals asiento.idAsiento
                         Where
                             asiento.idEmpresa = EmpresaId And
                             asiento.fechaProceso.Value.Year = FechaAct.Year And
                             asiento.fechaProceso.Value.Month = FechaAct.Month And
                             w.cuenta.StartsWith("43") And Not w.cuenta.StartsWith("432") And w.tipo = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER12 = (CType((Aggregate t1 In
                                              (From m In HeliosData.movimiento
                                               Join asiento In HeliosData.asiento
                                                   On m.idAsiento Equals asiento.idAsiento
                                               Where
                                                   asiento.idEmpresa = EmpresaId And
                                                   asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                   asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                   m.cuenta.StartsWith("43") And Not m.cuenta.StartsWith("432") And m.tipo = "H"
                                               Select New With {
                                                   m.monto
                                                   }) Into Sum(t1.monto)), Decimal?)),
                                DEBE40111 = (CType((Aggregate t1 In
                                                        (From w In HeliosData.movimiento
                                                         Join asiento In HeliosData.asiento
                                                             On w.idAsiento Equals asiento.idAsiento
                                                         Where
                                                             asiento.idEmpresa = EmpresaId And
                                                             asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                             asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                             w.cuenta.StartsWith("40111") And w.tipo = "D"
                                                         Select New With {
                                                             w.monto
                                                             }) Into Sum(t1.monto)), Decimal?)),
                                HABER40111 = (CType((Aggregate t1 In
                                                         (From m In HeliosData.movimiento
                                                          Join asiento In HeliosData.asiento
                                                              On m.idAsiento Equals asiento.idAsiento
                                                          Where
                                                              asiento.idEmpresa = EmpresaId And
                                                              asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                              asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                              m.cuenta.StartsWith("40111") And m.tipo = "H"
                                                          Select New With {
                                                              m.monto
                                                              }) Into Sum(t1.monto)), Decimal?)),
                                DEBE40 = (CType((Aggregate t1 In
                                                     (From w In HeliosData.movimiento
                                                      Join asiento In HeliosData.asiento
                                                          On w.idAsiento Equals asiento.idAsiento
                                                      Where
                                                          asiento.idEmpresa = EmpresaId And
                                                          asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                          asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                          w.cuenta.StartsWith("40") And Not w.cuenta.StartsWith("40111") And w.tipo = "D"
                                                      Select New With {
                                                          w.monto
                                                          }) Into Sum(t1.monto)), Decimal?)),
                                HABER40 = (CType((Aggregate t1 In
                                                      (From m In HeliosData.movimiento
                                                       Join asiento In HeliosData.asiento
                                                           On m.idAsiento Equals asiento.idAsiento
                                                       Where
                                                           asiento.idEmpresa = EmpresaId And
                                                           asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                           asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                           m.cuenta.StartsWith("40") And Not m.cuenta.StartsWith("40111") And m.tipo = "H"
                                                       Select New With {
                                                           m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
    DEBE12CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("43") And Not w.cuenta.StartsWith("432") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER12CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("43") And Not m.cuenta.StartsWith("432") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE40111CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("40111") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER40111CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("40111") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                      DEBE40CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("40") And Not w.cuenta.StartsWith("40111") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER40CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("40") And Not m.cuenta.StartsWith("40111") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault


            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "43"
                obj.debeSaldoS = consulta.DEBE12.GetValueOrDefault + consulta.DEBE12CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER12.GetValueOrDefault + consulta.HABER12CIERRE.GetValueOrDefault
                obj.debe40111 = consulta.DEBE40111.GetValueOrDefault + consulta.DEBE40111CIERRE.GetValueOrDefault
                obj.haber40111 = consulta.HABER40111.GetValueOrDefault + consulta.HABER40111CIERRE.GetValueOrDefault
                obj.debe40 = consulta.DEBE40.GetValueOrDefault + consulta.DEBE40CIERRE.GetValueOrDefault
                obj.haber40 = consulta.HABER40.GetValueOrDefault + consulta.HABER40CIERRE.GetValueOrDefault
                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "43"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe40111 = 0
                obj.haber40111 = 0
                obj.debe40 = 0
                obj.haber40 = 0
                obj.monto = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaPagoLetrasMensual(anioPeriodo As String, mesPeriodo As String, EmpresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)


        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try

            Dim list As New List(Of String)
            Dim listCobro As New List(Of String)

            list.Add("423")
            list.Add("433")
            listCobro.Add("123")
            listCobro.Add("133")


            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = EmpresaId
                            Select
                                tip.idEmpresa, tip.razonSocial,
                                DEBE = (CType((Aggregate t1 In
                                                   (From w In HeliosData.movimiento
                                                    Join asiento In HeliosData.asiento
                                                        On w.idAsiento Equals asiento.idAsiento
                                                    Where
                                                        asiento.idEmpresa = EmpresaId And
                                                        asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                        asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                        list.Contains(w.cuenta) And w.tipo = "D"
                                                    Select New With {
                                                        w.monto
                                                        }) Into Sum(t1.monto)), Decimal?)),
                                HABER = (CType((Aggregate t1 In
                                                    (From m In HeliosData.movimiento
                                                     Join asiento In HeliosData.asiento
                                                         On m.idAsiento Equals asiento.idAsiento
                                                     Where
                                                         asiento.idEmpresa = EmpresaId And
                                                         asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                         asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                         list.Contains(m.cuenta) And m.tipo = "H"
                                                     Select New With {
                                                         m.monto
                                                         }) Into Sum(t1.monto)), Decimal?)),
                                DEBELetras = (CType((Aggregate t1 In
                                                         (From w In HeliosData.movimiento
                                                          Join asiento In HeliosData.asiento
                                                              On w.idAsiento Equals asiento.idAsiento
                                                          Where
                                                              asiento.idEmpresa = EmpresaId And
                                                              asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                              asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                              listCobro.Contains(w.cuenta) And w.tipo = "D"
                                                          Select New With {
                                                              w.monto
                                                              }) Into Sum(t1.monto)), Decimal?)),
                                HABERLetras = (CType((Aggregate t1 In
                                                          (From m In HeliosData.movimiento
                                                           Join asiento In HeliosData.asiento
                                                               On m.idAsiento Equals asiento.idAsiento
                                                           Where
                                                               asiento.idEmpresa = EmpresaId And
                                                               asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                               asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                               listCobro.Contains(m.cuenta) And m.tipo = "H"
                                                           Select New With {
                                                               m.monto
                                                               }) Into Sum(t1.monto)), Decimal?)),
                                DEBECIERRE = (CType((Aggregate t1 In
                                                         (From w In HeliosData.cierrecontable
                                                          Where
                                                              w.idEmpresa = EmpresaId And
                                                              w.periodo = periodo_Anterior And list.Contains(w.cuenta) And w.tipoasiento = "D"
                                                          Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABERCIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And list.Contains(m.cuenta) And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBELetrasCIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And listCobro.Contains(w.cuenta) And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABERLetrasCIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And listCobro.Contains(m.cuenta) And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "423"
                obj.debeSaldoS = consulta.DEBE.GetValueOrDefault + consulta.DEBECIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER.GetValueOrDefault + consulta.HABERCIERRE.GetValueOrDefault
                obj.debeLetra = consulta.DEBELetras.GetValueOrDefault + consulta.DEBELetrasCIERRE.GetValueOrDefault
                obj.haberLetra = consulta.HABERLetras.GetValueOrDefault + consulta.HABERLetrasCIERRE.GetValueOrDefault
                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "423"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debeLetra = 0
                obj.haberLetra = 0
                obj.monto = 0
            End If


        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaCobroComercialMensual(anioPeriodo As String, mesPeriodo As String, EmpresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = EmpresaId
                            Select
                                tip.idEmpresa, tip.razonSocial,
                                DEBE12 = (CType((Aggregate t1 In
                                                     (From w In HeliosData.movimiento
                                                      Join asiento In HeliosData.asiento
                                                          On w.idAsiento Equals asiento.idAsiento
                                                      Where
                                                          asiento.idEmpresa = EmpresaId And
                                                          asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                          asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                          w.cuenta.StartsWith("12") And Not w.cuenta.StartsWith("122") And Not w.cuenta.StartsWith("123") And w.tipo = "D"
                                                      Select New With {
                                                          w.monto
                                                          }) Into Sum(t1.monto)), Decimal?)),
                                HABER12 = (CType((Aggregate t1 In
                                                      (From m In HeliosData.movimiento
                                                       Join asiento In HeliosData.asiento
                                                           On m.idAsiento Equals asiento.idAsiento
                                                       Where
                                                           asiento.idEmpresa = EmpresaId And
                                                           asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                           asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                           m.cuenta.StartsWith("12") And Not m.cuenta.StartsWith("122") And Not m.cuenta.StartsWith("123") And m.tipo = "H"
                                                       Select New With {
                                                           m.monto
                                                           }) Into Sum(t1.monto)), Decimal?)),
                                DEBE13 = (CType((Aggregate t1 In
                                                     (From w In HeliosData.movimiento
                                                      Join asiento In HeliosData.asiento
                                                          On w.idAsiento Equals asiento.idAsiento
                                                      Where
                                                          asiento.idEmpresa = EmpresaId And
                                                          asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                          asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                          w.cuenta.StartsWith("13") And Not w.cuenta.StartsWith("132") And Not w.cuenta.StartsWith("133") And w.tipo = "D"
                                                      Select New With {
                                                          w.monto
                                                          }) Into Sum(t1.monto)), Decimal?)),
                                HABER13 = (CType((Aggregate t1 In
                                                      (From m In HeliosData.movimiento
                                                       Join asiento In HeliosData.asiento
                                                           On m.idAsiento Equals asiento.idAsiento
                                                       Where
                                                           asiento.idEmpresa = EmpresaId And
                                                           asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                           asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                           m.cuenta.StartsWith("13") And Not m.cuenta.StartsWith("132") And Not m.cuenta.StartsWith("133") And m.tipo = "H"
                                                       Select New With {
                                                           m.monto
                                                           }) Into Sum(t1.monto)), Decimal?)),
                                DEBE12CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("12") And Not w.cuenta.StartsWith("122") And Not w.cuenta.StartsWith("123") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER12CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("12") And Not m.cuenta.StartsWith("122") And Not m.cuenta.StartsWith("123") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE13CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("13") And Not w.cuenta.StartsWith("132") And Not w.cuenta.StartsWith("133") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER13CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("13") And Not m.cuenta.StartsWith("132") And Not m.cuenta.StartsWith("133") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "12"
                obj.debeSaldoS = consulta.DEBE12.GetValueOrDefault + consulta.DEBE12CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER12.GetValueOrDefault + consulta.HABER12CIERRE.GetValueOrDefault
                obj.debe13 = consulta.DEBE13.GetValueOrDefault + consulta.DEBE13CIERRE.GetValueOrDefault
                obj.haber13 = consulta.HABER13.GetValueOrDefault + consulta.HABER13CIERRE.GetValueOrDefault
                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "12"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe13 = 0
                obj.haber13 = 0
                obj.monto = 0
            End If


        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function


    Public Function CuentaAnticiposMensual(anioPeriodo As String, mesPeriodo As String, EmpresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try


            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = EmpresaId
                            Select
                                tip.idEmpresa, tip.razonSocial,
                                DEBE422 = (CType((Aggregate t1 In
                                                      (From w In HeliosData.movimiento
                                                       Join asiento In HeliosData.asiento
                                                           On w.idAsiento Equals asiento.idAsiento
                                                       Where
                                                           asiento.idEmpresa = EmpresaId And
                                                           asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                           asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                           w.cuenta.StartsWith("422") And w.tipo = "D"
                                                       Select New With {
                                                           w.monto
                                                           }) Into Sum(t1.monto)), Decimal?)),
                                HABER422 = (CType((Aggregate t1 In
                                                       (From m In HeliosData.movimiento
                                                        Join asiento In HeliosData.asiento
                                                            On m.idAsiento Equals asiento.idAsiento
                                                        Where
                                                            asiento.idEmpresa = EmpresaId And
                                                            asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                            asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                            m.cuenta.StartsWith("422") And m.tipo = "H"
                                                        Select New With {
                                                            m.monto
                                                            }) Into Sum(t1.monto)), Decimal?)),
                                DEBE432 = (CType((Aggregate t1 In
                                                      (From w In HeliosData.movimiento
                                                       Join asiento In HeliosData.asiento
                                                           On w.idAsiento Equals asiento.idAsiento
                                                       Where
                                                           asiento.idEmpresa = EmpresaId And
                                                           asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                           asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                           w.cuenta.StartsWith("432") And w.tipo = "D"
                                                       Select New With {
                                                           w.monto
                                                           }) Into Sum(t1.monto)), Decimal?)),
                                HABER432 = (CType((Aggregate t1 In
                                                       (From m In HeliosData.movimiento
                                                        Join asiento In HeliosData.asiento
                                                            On m.idAsiento Equals asiento.idAsiento
                                                        Where
                                                            asiento.idEmpresa = EmpresaId And
                                                            asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                            asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                            m.cuenta.StartsWith("432") And m.tipo = "H"
                                                        Select New With {
                                                            m.monto
                                                            }) Into Sum(t1.monto)), Decimal?)),
                                DEBE122 = (CType((Aggregate t1 In
                                                      (From w In HeliosData.movimiento
                                                       Join asiento In HeliosData.asiento
                                                           On w.idAsiento Equals asiento.idAsiento
                                                       Where
                                                           asiento.idEmpresa = EmpresaId And
                                                           asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                           asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                           w.cuenta.StartsWith("122") And w.tipo = "D"
                                                       Select New With {
                                                           w.monto
                                                           }) Into Sum(t1.monto)), Decimal?)),
                                HABER122 = (CType((Aggregate t1 In
                                                       (From m In HeliosData.movimiento
                                                        Join asiento In HeliosData.asiento
                                                            On m.idAsiento Equals asiento.idAsiento
                                                        Where
                                                            asiento.idEmpresa = EmpresaId And
                                                            asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                            asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                            m.cuenta.StartsWith("122") And m.tipo = "H"
                                                        Select New With {
                                                            m.monto
                                                            }) Into Sum(t1.monto)), Decimal?)),
                                DEBE132 = (CType((Aggregate t1 In
                                                      (From w In HeliosData.movimiento
                                                       Join asiento In HeliosData.asiento
                                                           On w.idAsiento Equals asiento.idAsiento
                                                       Where
                                                           asiento.idEmpresa = EmpresaId And
                                                           asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                           asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                           w.cuenta.StartsWith("132") And w.tipo = "D"
                                                       Select New With {
                                                           w.monto
                                                           }) Into Sum(t1.monto)), Decimal?)),
                                HABER132 = (CType((Aggregate t1 In
                                                       (From m In HeliosData.movimiento
                                                        Join asiento In HeliosData.asiento
                                                            On m.idAsiento Equals asiento.idAsiento
                                                        Where
                                                            asiento.idEmpresa = EmpresaId And
                                                            asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                            asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                            m.cuenta.StartsWith("132") And m.tipo = "H"
                                                        Select New With {
                                                            m.monto
                                                            }) Into Sum(t1.monto)), Decimal?)),
    DEBE422CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("422") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER422CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("422") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE432CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("432") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER432CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("432") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                       DEBE122CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("122") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER122CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("122") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        DEBE132CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("132") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER132CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("132") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault



            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = consulta.DEBE422.GetValueOrDefault + consulta.DEBE422CIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER422.GetValueOrDefault + consulta.HABER422CIERRE.GetValueOrDefault
                obj.debe432 = consulta.DEBE432.GetValueOrDefault + consulta.DEBE432CIERRE.GetValueOrDefault
                obj.haber432 = consulta.HABER432.GetValueOrDefault + consulta.HABER432CIERRE.GetValueOrDefault

                obj.debe122 = consulta.DEBE122.GetValueOrDefault + consulta.DEBE122CIERRE.GetValueOrDefault
                obj.haber122 = consulta.HABER122.GetValueOrDefault + consulta.HABER122CIERRE.GetValueOrDefault

                obj.debe132 = consulta.DEBE132.GetValueOrDefault + consulta.DEBE132CIERRE.GetValueOrDefault
                obj.haber132 = consulta.HABER132.GetValueOrDefault + consulta.HABER132CIERRE.GetValueOrDefault

                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "422"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe432 = 0
                obj.haber432 = 0

                obj.debe122 = 0
                obj.haber122 = 0

                obj.debe132 = 0
                obj.haber132 = 0

                obj.monto = 0

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Function CuentaEntregaRendirMensual(anioPeriodo As String, mesPeriodo As String, EmpresaId As String) As movimiento
        Dim obj As New movimiento
        Dim lista As New List(Of movimiento)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & "/" & FechaAnt.Year
        periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        Try

            Dim list As New List(Of String)
            Dim listCobro As New List(Of String)

            list.Add("1413")
            list.Add("1433")
            list.Add("1443")
            list.Add("1681")



            Dim consulta = (From tip In HeliosData.empresa
                            Where tip.idEmpresa = EmpresaId
                            Select
                                tip.idEmpresa, tip.razonSocial,
                                DEBE = (CType((Aggregate t1 In
                                                   (From w In HeliosData.movimiento
                                                    Join asiento In HeliosData.asiento
                                                        On w.idAsiento Equals asiento.idAsiento
                                                    Where
                                                        asiento.idEmpresa = EmpresaId And
                                                        asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                        asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                        list.Contains(w.cuenta) And w.tipo = "D"
                                                    Select New With {
                                                        w.monto
                                                        }) Into Sum(t1.monto)), Decimal?)),
                                HABER = (CType((Aggregate t1 In
                                                    (From m In HeliosData.movimiento
                                                     Join asiento In HeliosData.asiento
                                                         On m.idAsiento Equals asiento.idAsiento
                                                     Where
                                                         asiento.idEmpresa = EmpresaId And
                                                         asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                        asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                         list.Contains(m.cuenta) And m.tipo = "H"
                                                     Select New With {
                                                         m.monto
                                                         }) Into Sum(t1.monto)), Decimal?)),
                                DEBE14 = (CType((Aggregate t1 In
                                                     (From w In HeliosData.movimiento
                                                      Join asiento In HeliosData.asiento
                                                          On w.idAsiento Equals asiento.idAsiento
                                                      Where
                                                          asiento.idEmpresa = EmpresaId And
                                                          asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                        asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                          w.cuenta.StartsWith("14") And Not w.cuenta.StartsWith("1413") And Not w.cuenta.StartsWith("1433") And Not w.cuenta.StartsWith("1443") And w.tipo = "D"
                                                      Select New With {
                                                          w.monto
                                                          }) Into Sum(t1.monto)), Decimal?)),
                                HABER14 = (CType((Aggregate t1 In
                                                      (From m In HeliosData.movimiento
                                                       Join asiento In HeliosData.asiento
                                                           On m.idAsiento Equals asiento.idAsiento
                                                       Where
                                                           asiento.idEmpresa = EmpresaId And
                                                           asiento.fechaProceso.Value.Year = FechaAct.Year And
                                                           asiento.fechaProceso.Value.Month = FechaAct.Month And
                                                           m.cuenta.StartsWith("14") And Not m.cuenta.StartsWith("1413") And Not m.cuenta.StartsWith("1433") And Not m.cuenta.StartsWith("1443") And m.tipo = "H"
                                                       Select New With {
                                                           m.monto
                                                           }) Into Sum(t1.monto)), Decimal?)),
                                DEBECIERRE = (CType((Aggregate t1 In
                                                         (From w In HeliosData.cierrecontable
                                                          Where
                                                              w.idEmpresa = EmpresaId And
                                                              w.periodo = periodo_Anterior And 
                                                              list.Contains(w.cuenta) And w.tipoasiento = "D"
                                                          Select New With {
                                                              w.monto
                                                              }) Into Sum(t1.monto)), Decimal?)),
                                HABERCIERRE = (CType((Aggregate t1 In
                                                          (From m In HeliosData.cierrecontable
                                                           Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And list.Contains(m.cuenta) And m.tipoasiento = "H"
                                                           Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                      DEBE14CIERRE = (CType((Aggregate t1 In
                        (From w In HeliosData.cierrecontable
                         Where
                        w.idEmpresa = EmpresaId And
                        w.periodo = periodo_Anterior And w.cuenta.StartsWith("14") And Not w.cuenta.StartsWith("1413") And Not w.cuenta.StartsWith("1433") And Not w.cuenta.StartsWith("1443") And w.tipoasiento = "D"
                         Select New With {
                        w.monto
                        }) Into Sum(t1.monto)), Decimal?)),
                        HABER14CIERRE = (CType((Aggregate t1 In
                        (From m In HeliosData.cierrecontable
                         Where
                        m.idEmpresa = EmpresaId And
                        m.periodo = periodo_Anterior And m.cuenta.StartsWith("14") And Not m.cuenta.StartsWith("1413") And Not m.cuenta.StartsWith("1433") And Not m.cuenta.StartsWith("1443") And m.tipoasiento = "H"
                         Select New With {
                        m.monto
                        }) Into Sum(t1.monto)), Decimal?))).Distinct().FirstOrDefault

            If Not IsNothing(consulta) Then
                obj = New movimiento
                obj.cuenta = "1413"
                obj.debeSaldoS = consulta.DEBE.GetValueOrDefault + consulta.DEBECIERRE.GetValueOrDefault
                obj.haberSaldoS = consulta.HABER.GetValueOrDefault + consulta.HABERCIERRE.GetValueOrDefault
                obj.debe14 = consulta.DEBE14.GetValueOrDefault + consulta.DEBE14CIERRE.GetValueOrDefault
                obj.haber14 = consulta.HABER14.GetValueOrDefault + consulta.HABER14CIERRE.GetValueOrDefault
                obj.monto = 0
            Else
                obj = New movimiento
                obj.cuenta = "1413"
                obj.debeSaldoS = 0
                obj.haberSaldoS = 0
                obj.debe14 = 0
                obj.haber14 = 0
                obj.monto = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return obj
    End Function

    Public Sub EditarMovimientosContablesByAsiento(movimiento As movimiento)
        Using ts As New TransactionScope

            Dim obj = HeliosData.movimiento.Where(Function(o) o.idmovimiento = movimiento.idmovimiento).FirstOrDefault

            obj.cuenta = movimiento.cuenta
            obj.descripcion = movimiento.descripcion
            obj.monto = movimiento.monto
            obj.montoUSD = movimiento.monto
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class

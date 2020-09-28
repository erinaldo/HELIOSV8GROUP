Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class cierrecontableBL
    Inherits BaseBL

    Public Function ReporteSaldoInicioXperiodo(intAnio As Integer, intMes As Integer) As List(Of cierrecontable)
        Dim mov As New cierrecontable
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Dim Lista As New List(Of cierrecontable)
        Dim consulta = (From cierre In HeliosData.cierrecontable
                        Where cierre.anio = intAnio And cierre.mes = intMes - 1
                        Group cierre By cierre.cuenta Into g = Group
                        Select cuenta,
                           Debe = CType(g.Sum(Function(p) (If(p.tipoasiento = "D", p.monto, 0))), Decimal?),
                           Haber = CType(g.Sum(Function(p) (If(p.tipoasiento = "H", p.monto, 0))), Decimal?)).ToList


        Dim montoMN As Decimal = 0
        Dim montoME As Decimal = 0
        For Each i In consulta
            mov = New cierrecontable
            mov.cuenta = i.cuenta
            mov.usuarioActualizacion = cuentaBL.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Mid(i.cuenta, 1, 2)).descripcion
            mov.monto = i.Debe
            mov.montoUSD = i.Haber
            Lista.Add(mov)
        Next

        Return Lista
    End Function


    Public Function ReporteSaldoInicioXperiodoHojaTrabajo(intAnio As Integer, intMes As Integer, idEmpresa As String) As List(Of cierrecontable)
        Dim mov As New cierrecontable
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Dim cuenta As New cuentaplanContableEmpresa
        Dim Lista As New List(Of cierrecontable)

        'Dim consulta = (From n In HeliosData.usp_HojaTrabajoMensual(AnioGeneral, intMes - 1, AnioGeneral, intMes, Gempresas.IdEmpresaRuc)
        '                Select n).ToList

        'Dim periodo_Anterior = String.Format("{0:00}", intMes - 1) & "/" & intAnio
        'periodo_Anterior = periodo_Anterior.Replace("/", "")
        'Dim periodo_Actual = String.Format("{0:00}", intMes) & "/" & intAnio

        Dim fechaConsulta = New Date(intAnio, intMes, 1)
        Dim fechaAnterior = fechaConsulta.AddMonths(-1)
        'Dim periodo_Anterior = String.Format("{0:00}", fechaAnterior.Month) & "/" & fechaAnterior.Year
        Dim periodo_Anterior = String.Format("{0:00}", fechaAnterior.Month) & fechaAnterior.Year
        'Dim consulta = (From n In HeliosData.usp_HojaTrabajoMensual_Tributario(periodoAnt, periodoActual, Gempresas.IdEmpresaRuc)
        '                Select n).ToList
        'Dim consulta = (From n In HeliosData.usp_ReporteHojaTrabajoMensual(periodo_Anterior, periodo_Actual, idEmpresa)
        '                Select n).ToList

        Dim consulta = (From n In HeliosData.usp_ReporteHojaTrabajoMensual_V2(periodo_Anterior, fechaConsulta.Year, fechaConsulta.Month, idEmpresa)
                        Select n).ToList

        'Dim consulta = (From movimiento In HeliosData.movimiento _
        '               Group Join m In HeliosData.cierrecontable On New With {movimiento.cuenta} Equals New With {m.cuenta} Into m_join = Group _
        '               From m In m_join.DefaultIfEmpty() _
        '               Group Join asi In HeliosData.asiento On New With {movimiento.idAsiento} Equals New With {asi.idAsiento} Into asi_join = Group _
        '               From asi In asi_join.DefaultIfEmpty() _
        '               Group New With {movimiento, m, asi} By _
        '               movimiento.cuenta, m.mes, m.tipoasiento, m.monto _
        '               Into g = Group _
        '               Select _
        '               cuenta,
        '               TOTAL_DEBE = If(tipoasiento = "D" And CLng(mes) = intMes - 1, monto, 0),
        '               TOTAL_HABER = If(tipoasiento = "H" And CLng(mes) = intMes - 1, monto, 0),
        '               Column1 = CType(g.Sum(Function(p) (If(p.movimiento.tipo = "D" And CLng(p.asi.fechaProceso.Value.Month) = intMes, p.movimiento.monto, 0))), Decimal?),
        '               Column2 = CType(g.Sum(Function(p) (If(p.movimiento.tipo = "H" And CLng(p.asi.fechaProceso.Value.Month) = intMes, p.movimiento.monto, 0))), Decimal?)).Distinct.ToList()


        'Dim consultaFull = (From movx In HeliosData.movimiento _
        '                    Join asiento In HeliosData.asiento _
        '                    On asiento.idAsiento Equals movx.idAsiento _
        '                    Group Join c In HeliosData.cierrecontable On New With {movx.cuenta} Equals New With {c.cuenta} Into c_join = Group _
        '                    From c In c_join.DefaultIfEmpty() _
        '                    Group New With {c, movx} By _
        '                    c.cuenta, _
        '                    CuentaMov = movx.cuenta _
        '                    Into g = Group
        '                    Select Cuenta = cuenta,
        '                    CuentaMov = CuentaMov,
        '                    DebeCierre = CType(g.Sum(Function(p) (If(p.c.tipoasiento = "D", p.c.monto, 0))), Decimal?), _
        '                    HaberCierre = CType(g.Sum(Function(p) (If(p.c.tipoasiento = "H", p.c.monto, 0))), Decimal?),
        '                    DebeMov = CType(g.Sum(Function(p) (If(p.movx.tipo = "D", p.movx.monto, 0))), Decimal?),
        '                    HaberMov = CType(g.Sum(Function(p) (If(p.movx.tipo = "H", p.movx.monto, 0))), Decimal?)).tolist

        Dim montoMN As Decimal = 0
        Dim montoME As Decimal = 0
        For Each i In consulta
            cuenta = cuentaBL.ObtenerCuentaPorID(idEmpresa, i.cuenta)

            mov = New cierrecontable
            'mov.nomCuenta = cuentaBL.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Mid(i.cuenta, 1, 2)).descripcion
            If Not IsNothing(cuenta) Then
                mov.nomCuenta = cuenta.descripcion
            Else
                mov.nomCuenta = "-"
            End If

            mov.cuentaCierre = i.cuenta
            mov.cuentaMovimiento = String.Empty
            'mov.DebeCierre = i.TOTAL_DEBE.GetValueOrDefault
            'mov.HaberCierre = i.TOTAL_HABER.GetValueOrDefault
            'mov.DebeMovimiento = i.Column1.GetValueOrDefault
            'mov.HaberMovimiento = i.Column2.GetValueOrDefault
            mov.DebeCierre = i.TOTAL_DEBE_ANT.GetValueOrDefault
            mov.HaberCierre = i.TOTAL_HABER_ANT.GetValueOrDefault
            mov.DebeMovimiento = i.TOTAL_DEBE.GetValueOrDefault
            mov.HaberMovimiento = i.TOTAL_HABER.GetValueOrDefault
            Lista.Add(mov)
        Next

        Return Lista
    End Function


    Public Function RecuperarEstadoCierrePeriodo(strEmpresa As String, intIdEstablec As Integer, strPeriodo As String) As cierrecontable
        Return (From n In HeliosData.cierrecontable.Where(Function(o) o.idEmpresa = strEmpresa _
                                                                And o.idCentroCosto = intIdEstablec _
                                                                And o.periodo = strPeriodo)).FirstOrDefault
    End Function

    Public Sub AperturarPeriodo(strEmpresa As String, intIdEstablec As Integer, strPeriodo As String)
        Try
            Dim consulta As List(Of cierrecontable) = HeliosData.cierrecontable.Where(Function(o) o.idEmpresa = strEmpresa _
                                                                                           And o.idCentroCosto = intIdEstablec _
                                                                                            And o.periodo = strPeriodo).ToList

            For Each i In consulta
                UpdateEstado(i)
            Next
            HeliosData.SaveChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateEstado(objCierre As cierrecontable)
        Using ts As New TransactionScope
            Dim empresa As String = objCierre.idEmpresa
            Dim establec As Integer = objCierre.idCentroCosto
            Dim periodo As String = objCierre.periodo
            Dim cuenta As String = objCierre.cuenta
            Dim tipoAsiento As String = objCierre.tipoasiento.Trim
            Dim cierre As cierrecontable = HeliosData.cierrecontable.Where(Function(o) o.idEmpresa = empresa _
                                                                                 And o.idCentroCosto = establec _
                                                                                 And o.periodo = periodo _
                                                                                 And o.cuenta = cuenta _
                                                                                 And o.tipoasiento = tipoAsiento).FirstOrDefault


            'HeliosData.ObjectStateManager.GetObjectStateEntry(cierre).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function CierreCerrado(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As Boolean
        Dim conteo = (From n In HeliosData.cierrecontable _
                     Where n.idEmpresa = strIdEmpresa And n.idCentroCosto = intIdEstablecimiento _
                     And n.periodo = strPeriodo).Count

        If conteo > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub GrabarListaAsientos(lista As List(Of cierrecontable), asiento As asiento, documento As documento)
        Dim documentoBL As New documentoBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Dim AsientoBL As New AsientoBL
        Dim libroBL As New documentoLibroDiarioBL
        Try
            Using ts As New TransactionScope
                documentoBL.Insert(documento)
                libroBL.InsertCabecera(documento.documentoLibroDiario, documento.idDocumento)
                For Each i As documentoLibroDiarioDetalle In documento.documentoLibroDiario.documentoLibroDiarioDetalle
                    docDetalle = New documentoLibroDiarioDetalle With {
                        .idDocumento = documento.idDocumento,
                        .cuenta = i.cuenta,
                        .idItem = i.idItem,
                        .descripcion = i.descripcion,
                        .tipoAsiento = i.tipoAsiento,
                        .importeMN = i.importeMN,
                        .importeME = i.importeME,
                        .usuarioActualizacion = i.usuarioActualizacion,
                        .fechaActualizacion = i.fechaActualizacion
                        }
                    HeliosData.documentoLibroDiarioDetalle.Add(docDetalle)
                Next
                'For Each i In lista
                '    Insert(i)
                'Next
                AsientoBL.Insert(asiento, documento.idDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarListaAsientosCierre(lista As List(Of cierrecontable))
        Try
            Using ts As New TransactionScope
                For Each i In lista
                    Insert(i)
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateListaAsientos(lista As List(Of cierrecontable))

        Try
            Using ts As New TransactionScope
                For Each i In lista
                    Dim empresa As String = i.idEmpresa
                    Dim establec As Integer = i.idCentroCosto
                    Dim periodo As String = i.periodo
                    Dim cuenta As String = i.cuenta
                    Dim tipoAsiento As String = i.tipoasiento
                    Dim item As cierrecontable = HeliosData.cierrecontable.Where(Function(o) o.idEmpresa = empresa _
                                                                                       And o.idCentroCosto = establec _
                                                                                       And o.periodo = periodo _
                                                                                       And o.cuenta = cuenta _
                                                                                       And o.tipoasiento = tipoAsiento).FirstOrDefault

                    If Not IsNothing(item) Then
                        Update(i)
                    Else
                        Insert(i)
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Insert(ByVal cierrecontableBE As cierrecontable)
        Dim cierre As New cierrecontable
        Using ts As New TransactionScope
            With cierre
                .idDocumento = cierrecontableBE.idDocumento
                .idEmpresa = cierrecontableBE.idEmpresa
                .idCentroCosto = cierrecontableBE.idCentroCosto
                .periodo = cierrecontableBE.periodo
                .tipoasiento = cierrecontableBE.tipoasiento
                .cuenta = cierrecontableBE.cuenta
                .anio = cierrecontableBE.anio
                .mes = cierrecontableBE.mes
                .monto = cierrecontableBE.monto
                .montoUSD = cierrecontableBE.montoUSD
                .usuarioActualizacion = cierrecontableBE.usuarioActualizacion
                .fechaActualizacion = cierrecontableBE.fechaActualizacion
            End With
            HeliosData.cierrecontable.Add(cierre)
            HeliosData.SaveChanges()
            ts.Complete()
            '    Return cierre.idEmpresa
        End Using
    End Sub

    Public Sub Update(ByVal cierrecontableBE As cierrecontable)
        Using ts As New TransactionScope
            Dim cierreCont As cierrecontable = HeliosData.cierrecontable.Where(Function(o) _
                                            o.idEmpresa = cierrecontableBE.idEmpresa _
                                            And o.idCentroCosto = cierrecontableBE.idCentroCosto _
                                            And o.periodo = cierrecontableBE.periodo _
                                            And o.cuenta = cierrecontableBE.cuenta _
                                            And o.tipoasiento = cierrecontableBE.tipoasiento).First


            With cierreCont
                '.idEmpresa = cierrecontableBE.idEmpresa
                '.idCentroCosto = cierrecontableBE.idCentroCosto
                '.periodo = cierrecontableBE.periodo
                '  .tipoasiento = cierrecontableBE.tipoasiento
                '    .cuenta = cierrecontableBE.cuenta
                '.anio = cierrecontableBE.anio
                '.mes = cierrecontableBE.mes
                .monto = cierrecontableBE.monto
                .montoUSD = cierrecontableBE.montoUSD
                .usuarioActualizacion = cierrecontableBE.usuarioActualizacion
                .fechaActualizacion = cierrecontableBE.fechaActualizacion
            End With

            'HeliosData.ObjectStateManager.GetObjectStateEntry(cierreCont).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal cierrecontableBE As cierrecontable)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(cierrecontableBE)
    End Sub

    Public Function GetListar_cierrecontable() As List(Of cierrecontable)
        Return (From a In HeliosData.cierrecontable Select a).ToList
    End Function

    Public Function GetUbicar_cierrecontablePorID(idEmpresa As Integer) As cierrecontable
        Return (From a In HeliosData.cierrecontable
                Where a.idEmpresa = idEmpresa Select a).First
    End Function

    Public Function GetCargarCierrePorPeriodo(idEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of cierrecontable)
        Return (From a In HeliosData.cierrecontable
                Where a.idEmpresa = idEmpresa And _
                a.periodo = strPeriodo).ToList
    End Function

    Public Sub EliminarCierreContable(cierreBE As cierrecontable)
        Dim consulta = (From i In HeliosData.cierrecontable _
                       Where i.idEmpresa = cierreBE.idEmpresa _
                       And i.periodo = cierreBE.periodo).ToList

        For Each n In consulta
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(n)
        Next
        HeliosData.SaveChanges()
    End Sub
    
End Class

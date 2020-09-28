Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class HojaTrabajoFinalRPT
    Inherits BaseBL


    Public Function ListarDetalleXCuenta(intAnio As Integer, intMes As Integer, cuenta As String) As List(Of movimiento)
        Dim mov As New movimiento
        Dim Lista As New List(Of movimiento)

        Dim PeriodoNuevo = String.Format("{0:00}", intMes) & "/" & intAnio

        'Dim consulta = (From Movimiento In HeliosData.movimiento _
        '                    Join asiento In HeliosData.asiento _
        '                    On asiento.idAsiento Equals Movimiento.idAsiento _
        '                    Join doc In HeliosData.documento _
        '                    On doc.idDocumento Equals asiento.idDocumento _
        '                    Where asiento.fechaProceso.Value.Year = intAnio _
        '                    And asiento.fechaProceso.Value.Month = intMes _
        '                    And Movimiento.cuenta = cuenta).ToList

        Dim consulta = (From Movimiento In HeliosData.movimiento
                        Join asiento In HeliosData.asiento
                            On asiento.idAsiento Equals Movimiento.idAsiento
                        Join doc In HeliosData.documento
                            On doc.idDocumento Equals asiento.idDocumento
                        Where asiento.periodo = PeriodoNuevo _
                            And Movimiento.cuenta = cuenta).ToList


        Dim montoMN As Decimal = 0
        Dim montoME As Decimal = 0
        For Each i In consulta
            mov = New movimiento
            mov.cuenta = i.Movimiento.cuenta
            mov.descripcion = i.Movimiento.descripcion
            mov.tipo = i.Movimiento.tipo
            mov.monto = i.Movimiento.monto
            mov.montoUSD = i.Movimiento.montoUSD
            mov.glosa = i.asiento.glosa
            mov.idDocumentoRef = i.asiento.idDocumento
            mov.codigoLibro = i.asiento.codigoLibro
            mov.tipoOperacion = i.doc.tipoOperacion
            Lista.Add(mov)
        Next

        Return Lista
    End Function

    Public Function BuscarHojaTrabajoFinalFullReporte(strPeriodo As Integer) As List(Of movimiento)
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

                            If (objMostrarEncaja.monto > objMostrarEncaja.Montocero) Then
                                objMostrarEncaja.debeSaldoS = objMostrarEncaja.monto - objMostrarEncaja.Montocero
                                objMostrarEncaja.haberSaldoS = 0.0
                            Else
                                objMostrarEncaja.haberSaldoS = objMostrarEncaja.Montocero - objMostrarEncaja.monto
                                objMostrarEncaja.debeSaldoS = 0.0
                            End If

                            If (objMostrarEncaja.montoUSD > objMostrarEncaja.MontoceroUSD) Then
                                objMostrarEncaja.debeSaldoUSD = objMostrarEncaja.montoUSD - objMostrarEncaja.MontoceroUSD
                                objMostrarEncaja.haverSaldoUSD = 0.0
                            Else
                                objMostrarEncaja.haverSaldoUSD = objMostrarEncaja.MontoceroUSD - objMostrarEncaja.montoUSD
                                objMostrarEncaja.debeSaldoUSD = 0.0
                            End If


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

    Public Function ReporteHojaTrabajoXperiodo(intAnio As Integer, intMes As Integer) As List(Of movimiento)
        Dim mov As New movimiento
        Dim cierreBL As New movimientoBL
        Dim cierre As New cierrecontable
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Dim Lista As New List(Of movimiento)

        Dim consulta = (From Movimiento In HeliosData.movimiento _
                            Join asiento In HeliosData.asiento _
                            On asiento.idAsiento Equals Movimiento.idAsiento _
                            Where asiento.fechaProceso.Value.Year = intAnio _
                            And asiento.fechaProceso.Value.Month = intMes _
                           Group Movimiento By Movimiento.cuenta Into g = Group _
                           Select cuenta, _
                           Debe = CType(g.Sum(Function(p) (If(p.tipo = "D", p.monto, 0))), Decimal?),
                           Haber = CType(g.Sum(Function(p) (If(p.tipo = "H", p.monto, 0))), Decimal?)).ToList


        Dim montoMN As Decimal = 0
        Dim montoME As Decimal = 0
        For Each i In consulta
            mov = New movimiento
            'cierre = cierreBL.RecuperarCierreContableAnteriorHojaTrabajo(AnioGeneral, MesGeneral - 1, i.cuenta)
            'If Not IsNothing(cierre) Then
            '    montoMN = cierre.monto.GetValueOrDefault
            '    montoME = cierre.montoUSD.GetValueOrDefault
            'Else
            '    montoMN = 0
            '    montoME = 0
            'End If
            'mov.Montocero = montoMN
            'mov.MontoceroUSD = montoME

            mov.cuenta = i.cuenta
            mov.descripcion = cuentaBL.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Mid(i.cuenta, 1, 2)).descripcion
            mov.debeSaldoS = i.Debe
            mov.haberSaldoS = i.Haber
            Lista.Add(mov)
        Next

        Return Lista
    End Function

    Public Function BuscarHojaTrabajoFinalPorMesReporte(strPeriodo As String, intMes As String) As List(Of movimiento)
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
                    Where asiento.fechaProceso.Value.Year = strPeriodo _
                    And asiento.fechaProceso.Value.Month = intMes _
                      Group movimiento By _
                      movimiento.cuenta,
                      cuenta.descripcion, _
                      movimiento.tipo _
                      Into g = Group _
                      Select New With {g, .TotalMN = g.Sum(Function(n) n.monto),
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
                   Where asiento.fechaProceso.Value.Year = strPeriodo _
                  And asiento.fechaProceso.Value.Month = intMes _
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

                            If (objMostrarEncaja.monto > objMostrarEncaja.Montocero) Then
                                objMostrarEncaja.debeSaldoS = objMostrarEncaja.monto - objMostrarEncaja.Montocero
                                objMostrarEncaja.haberSaldoS = 0.0
                            Else
                                objMostrarEncaja.haberSaldoS = objMostrarEncaja.Montocero - objMostrarEncaja.monto
                                objMostrarEncaja.debeSaldoS = 0.0
                            End If

                            If (objMostrarEncaja.montoUSD > objMostrarEncaja.MontoceroUSD) Then
                                objMostrarEncaja.debeSaldoUSD = objMostrarEncaja.montoUSD - objMostrarEncaja.MontoceroUSD
                                objMostrarEncaja.haverSaldoUSD = 0.0
                            Else
                                objMostrarEncaja.haverSaldoUSD = objMostrarEncaja.MontoceroUSD - objMostrarEncaja.montoUSD
                                objMostrarEncaja.debeSaldoUSD = 0.0
                            End If

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

    Public Function BuscarHojaTrabajoFinalPorAcumuladoReporte(strFechaDesde As Date, strFechaHasta As Date) As List(Of movimiento)
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

                            If (objMostrarEncaja.monto > objMostrarEncaja.Montocero) Then
                                objMostrarEncaja.debeSaldoS = objMostrarEncaja.monto - objMostrarEncaja.Montocero
                                objMostrarEncaja.haberSaldoS = 0.0
                            Else
                                objMostrarEncaja.haberSaldoS = objMostrarEncaja.Montocero - objMostrarEncaja.monto
                                objMostrarEncaja.debeSaldoS = 0.0
                            End If

                            If (objMostrarEncaja.montoUSD > objMostrarEncaja.MontoceroUSD) Then
                                objMostrarEncaja.debeSaldoUSD = objMostrarEncaja.montoUSD - objMostrarEncaja.MontoceroUSD
                                objMostrarEncaja.haverSaldoUSD = 0.0
                            Else
                                objMostrarEncaja.haverSaldoUSD = objMostrarEncaja.MontoceroUSD - objMostrarEncaja.montoUSD
                                objMostrarEncaja.debeSaldoUSD = 0.0
                            End If

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
End Class

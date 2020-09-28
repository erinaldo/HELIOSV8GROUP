Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class InformeClasesRPT
    Inherits BaseBL

    Public Function BuscarInformePorClaseReporte(strCuenta As String, anio As String) As List(Of movimiento)
        Dim lista2 As New List(Of movimiento)
        Dim TotalDS, TotalHS, TotalDUSD, TotalHUSD As Decimal
        Dim objMostrarEncaja As movimiento
        Dim cuentaPadre As String = Nothing
        Dim mov = (From movimiento In HeliosData.movimiento
           Join cuenta In HeliosData.cuentaplanContableEmpresa _
                        On cuenta.cuenta Equals movimiento.cuenta _
                    Where movimiento.cuenta.StartsWith(strCuenta)
                      Group movimiento By _
                               movimiento.cuenta,
        cuenta.descripcion _
                                 Into g = Group _
                               Select New With {.descripcion = descripcion,
                                                .cuenta = cuenta}).ToList

        For Each m In mov
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.cuenta = m.cuenta
            objMostrarEncaja.glosa = m.descripcion
            objMostrarEncaja.fechaActualizacion = Nothing
            cuentaPadre = m.cuenta
            lista2.Add(objMostrarEncaja)

            Dim movdet = (From movimiento In HeliosData.movimiento
                   Join asiento In HeliosData.asiento _
               On movimiento.idAsiento Equals asiento.idAsiento _
                Where movimiento.cuenta = cuentaPadre _
                And asiento.fechaProceso.Value.Year = anio _
                And asiento.idEmpresa = Gempresas.IdEmpresaRuc)

            For Each m2 In movdet
                objMostrarEncaja = New movimiento()
                objMostrarEncaja.fechaActualizacion = m2.asiento.fechaProceso
                objMostrarEncaja.glosa = m.descripcion
                objMostrarEncaja.nombreEntidad = m2.asiento.nombreEntidad
                objMostrarEncaja.cuenta = m2.movimiento.cuenta
                objMostrarEncaja.descripcion = m2.movimiento.descripcion

                If (m2.movimiento.tipo = "D") Then
                    objMostrarEncaja.monto = m2.movimiento.monto
                    objMostrarEncaja.Montocero = m2.movimiento.Montocero

                    objMostrarEncaja.montoUSD = m2.movimiento.montoUSD
                    objMostrarEncaja.MontoceroUSD = m2.movimiento.MontoceroUSD

                    TotalDS += m2.movimiento.monto
                    TotalDUSD += m2.movimiento.montoUSD

                Else
                    objMostrarEncaja.monto = m2.movimiento.Montocero
                    objMostrarEncaja.Montocero = m2.movimiento.monto

                    objMostrarEncaja.montoUSD = m2.movimiento.MontoceroUSD
                    objMostrarEncaja.MontoceroUSD = m2.movimiento.montoUSD

                    TotalHS += m2.movimiento.monto
                    TotalHUSD += m2.movimiento.montoUSD
                End If

                lista2.Add(objMostrarEncaja)
            Next
            If (movdet.Count > 0) Then
                objMostrarEncaja = New movimiento()
                objMostrarEncaja.descripcion = "TOTAL"
                objMostrarEncaja.monto = TotalDS
                objMostrarEncaja.Montocero = TotalHS

                objMostrarEncaja.montoUSD = TotalDUSD
                objMostrarEncaja.MontoceroUSD = TotalHUSD
                lista2.Add(objMostrarEncaja)
            End If
        Next
        Return lista2
    End Function

    Public Function BuscarInformePorClaseAcumuladoReporte(strFechaDesde As Date, strFechaHasta As Date, strCuenta As String) As List(Of movimiento)
        Dim lista2 As New List(Of movimiento)
        Dim TotalDS, TotalHS, TotalDUSD, TotalHUSD As Decimal
        Dim objMostrarEncaja As movimiento
        Dim cuentaPadre As String = Nothing
        Dim mov = (From movimiento In HeliosData.movimiento
           Join cuenta In HeliosData.cuentaplanContableEmpresa _
                        On cuenta.cuenta Equals movimiento.cuenta _
                    Where movimiento.cuenta.StartsWith(strCuenta)
                      Group movimiento By _
                               movimiento.cuenta,
        cuenta.descripcion _
                                 Into g = Group _
                               Select New With {.descripcion = descripcion,
                                                .cuenta = cuenta}).ToList

        For Each m In mov
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.cuenta = m.cuenta
            objMostrarEncaja.glosa = m.descripcion
            objMostrarEncaja.fechaActualizacion = Nothing
            cuentaPadre = m.cuenta
            lista2.Add(objMostrarEncaja)

            Dim movdet = (From movimiento In HeliosData.movimiento
                   Join asiento In HeliosData.asiento _
               On movimiento.idAsiento Equals asiento.idAsiento _
                Where movimiento.cuenta = cuentaPadre _
                And asiento.fechaProceso.Value > strFechaDesde _
                    And asiento.fechaProceso.Value < strFechaHasta _
                    And asiento.idEmpresa = Gempresas.IdEmpresaRuc)

            For Each m2 In movdet
                objMostrarEncaja = New movimiento()
                objMostrarEncaja.fechaActualizacion = m2.asiento.fechaProceso
                objMostrarEncaja.glosa = m.descripcion
                objMostrarEncaja.nombreEntidad = m2.asiento.nombreEntidad
                objMostrarEncaja.cuenta = m2.movimiento.cuenta
                objMostrarEncaja.descripcion = m2.movimiento.descripcion

                If (m2.movimiento.tipo = "D") Then
                    objMostrarEncaja.monto = m2.movimiento.monto
                    objMostrarEncaja.Montocero = m2.movimiento.Montocero

                    objMostrarEncaja.montoUSD = m2.movimiento.montoUSD
                    objMostrarEncaja.MontoceroUSD = m2.movimiento.MontoceroUSD

                    TotalDS += m2.movimiento.monto
                    TotalDUSD += m2.movimiento.montoUSD

                Else
                    objMostrarEncaja.monto = m2.movimiento.Montocero
                    objMostrarEncaja.Montocero = m2.movimiento.monto

                    objMostrarEncaja.montoUSD = m2.movimiento.MontoceroUSD
                    objMostrarEncaja.MontoceroUSD = m2.movimiento.montoUSD

                    TotalHS += m2.movimiento.monto
                    TotalHUSD += m2.movimiento.montoUSD
                End If

                lista2.Add(objMostrarEncaja)
            Next
            If (movdet.Count > 0) Then
                objMostrarEncaja = New movimiento()
                objMostrarEncaja.descripcion = "TOTAL"
                objMostrarEncaja.monto = TotalDS
                objMostrarEncaja.Montocero = TotalHS

                objMostrarEncaja.montoUSD = TotalDUSD
                objMostrarEncaja.MontoceroUSD = TotalHUSD
                lista2.Add(objMostrarEncaja)
            End If
        Next
        Return lista2
    End Function

    Public Function BuscarInformePorClaseMesReporte(anio As String, mes As String, strCuenta As String) As List(Of movimiento)
        Dim lista2 As New List(Of movimiento)
        Dim TotalDS, TotalHS, TotalDUSD, TotalHUSD As Decimal
        Dim objMostrarEncaja As movimiento
        Dim cuentaPadre As String = Nothing
        Dim mov = (From movimiento In HeliosData.movimiento
           Join cuenta In HeliosData.cuentaplanContableEmpresa _
                        On cuenta.cuenta Equals movimiento.cuenta _
                    Where movimiento.cuenta.StartsWith(strCuenta)
                      Group movimiento By _
                               movimiento.cuenta,
        cuenta.descripcion _
                                 Into g = Group _
                               Select New With {.descripcion = descripcion,
                                                .cuenta = cuenta}).ToList

        For Each m In mov
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.cuenta = m.cuenta
            objMostrarEncaja.glosa = m.descripcion
            objMostrarEncaja.fechaActualizacion = Nothing
            cuentaPadre = m.cuenta
            lista2.Add(objMostrarEncaja)

            Dim movdet = (From movimiento In HeliosData.movimiento
                   Join asiento In HeliosData.asiento _
               On movimiento.idAsiento Equals asiento.idAsiento _
                Where movimiento.cuenta = cuentaPadre And _
            asiento.fechaProceso.Value.Year = anio _
                  And asiento.fechaProceso.Value.Month = mes _
                  And asiento.idEmpresa = Gempresas.IdEmpresaRuc)

            For Each m2 In movdet
                objMostrarEncaja = New movimiento()
                objMostrarEncaja.fechaActualizacion = m2.asiento.fechaProceso
                objMostrarEncaja.glosa = m.descripcion
                objMostrarEncaja.nombreEntidad = m2.asiento.nombreEntidad
                objMostrarEncaja.cuenta = m2.movimiento.cuenta
                objMostrarEncaja.descripcion = m2.movimiento.descripcion

                If (m2.movimiento.tipo = "D") Then
                    objMostrarEncaja.monto = m2.movimiento.monto
                    objMostrarEncaja.Montocero = m2.movimiento.Montocero

                    objMostrarEncaja.montoUSD = m2.movimiento.montoUSD
                    objMostrarEncaja.MontoceroUSD = m2.movimiento.MontoceroUSD

                    TotalDS += m2.movimiento.monto
                    TotalDUSD += m2.movimiento.montoUSD

                Else
                    objMostrarEncaja.monto = m2.movimiento.Montocero
                    objMostrarEncaja.Montocero = m2.movimiento.monto

                    objMostrarEncaja.montoUSD = m2.movimiento.MontoceroUSD
                    objMostrarEncaja.MontoceroUSD = m2.movimiento.montoUSD

                    TotalHS += m2.movimiento.monto
                    TotalHUSD += m2.movimiento.montoUSD
                End If

                lista2.Add(objMostrarEncaja)
            Next
            If (movdet.Count > 0) Then
                objMostrarEncaja = New movimiento()
                objMostrarEncaja.descripcion = "TOTAL"
                objMostrarEncaja.monto = TotalDS
                objMostrarEncaja.Montocero = TotalHS

                objMostrarEncaja.montoUSD = TotalDUSD
                objMostrarEncaja.MontoceroUSD = TotalHUSD
                lista2.Add(objMostrarEncaja)
            End If
        Next
        Return lista2
    End Function

End Class
